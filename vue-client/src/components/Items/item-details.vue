<template>
	<div v-if="isLoading" >
		<p>Loading</p>
	</div>
    <div v-else>
        <fieldset class="border p-2">
            <legend class="w-auto">Item Details</legend>
            <dl>
                <dt>Name</dt>
                <dd>{{ itemDetails.name }}</dd>
                <dt>Title</dt>
                <dd>{{ itemDetails.title }}</dd>
                <dt>Description</dt>
                <dd>{{ itemDetails.description }}</dd>
                <dt>Price</dt>
                <dd>{{ itemDetails.price | currency('£')}}</dd>
                <dt>Created Date</dt>
                <dd>{{ itemDetails.createdDate | formatDate }}</dd>
                <dt>Created By</dt>
                <dd>{{ itemDetails.createdBy.username }}</dd>
                <span v-if="itemDetails.updatedDate">
                    <dt>Updated Date</dt>
                    <dd>{{ itemDetails.updatedDate | formatDate }}</dd>
                </span>
                <span v-if="itemDetails.updatedBy">
                    <dt>Updated By</dt>
                    <dd>{{ itemDetails.updatedBy.username }}</dd>
                </span>
            </dl>
        </fieldset>
        <div class="row">
            <div class="col-md-6">
                <fieldset class="border p-2" v-if="itemDetails.images">
                    <legend class="w-auto">Images</legend>
                        <div style="max-width:100%; height:auto;">
                            <b-carousel
                                id="carousel-fade"
                                style="text-shadow: 0px 0px 2px #000"
                                fade
                                controls
                                indicators>
                                <b-carousel-slide v-for="image in itemDetails.images" :key="image.fileName" v-bind:img-src="'https://localhost:5001/api/' + image.path" v-bind:img-alt="image.filename"></b-carousel-slide>
                            </b-carousel>
                        </div>
                </fieldset>
            </div>
            <div class="col-md-6">
                <fieldset class="border p-2" v-if="itemDetails.reviews.length">
                    <legend class="w-auto">Reviews</legend>
                    <span v-for="review in itemDetails.reviews" :key="review.id">
                        <dl>
                            <dt>Rating</dt>
                            <dd>{{ review.rating }} / 5</dd>
                            <dt>Title</dt>
                            <dd>{{ review.title }}</dd>
                            <dt>Description</dt>
                            <dd>{{ review.description }}</dd>
                            <dt>Created Date</dt>
                            <dd>{{ review.createdDate | formatDate }}</dd>
                        </dl>
                    </span>
                </fieldset>
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import Vue from 'vue';
import axios from 'axios';
import Vue2Filters from 'vue2-filters';

Vue.use(Vue2Filters);

export default Vue.extend({
    // code here
	props: { },
    data() {
        return {
            itemDetails: {} as any,
            isLoading: Boolean
        };
    },
    mounted() {
        const itemId = this.$route.params.id;
		this.isLoading = true;
        axios.get('https://localhost:5001/api/Items/' + itemId)
            .then((response) => {
				this.isLoading = false;
                this.itemDetails = response.data;
                console.log(this.itemDetails);
            })
            .catch(err => {
                console.log(err); 
				this.isLoading = false;
            });
    },
    
});
</script>

<style>

</style>