<template>
<div>
    <h1>Item Form</h1>
    <section class="form">
        Form Goes Here
         <div class="field">
            <label class="label">Title</label>
            <div class="control">
                <input v-model="form.title" class="input" type="text" placeholder="Title">
            </div>
        </div>
        <div class="field">
            <label class="label">Description</label>
            <div class="control">
                <input v-model="form.description" class="input" type="text" placeholder="Description">
            </div>
        </div>
        <div class="field">
            <label class="label">Price</label>
            <div class="control">
                <input v-model="form.price" class="input" type="number" placeholder="0.00">
            </div>
        </div>
        <div class="field">
            <label class="label">Images</label>
            <div class="control">
                <input v-model="form.images" class="input" type="image" placeholder="Upload Images..">
            </div>
        </div>        
    </section>
</div>
</template>
<script lang="ts">
import Vue from 'vue';
import axios from 'axios';

export default Vue.extend({

    data() {
            return {
                form : {
                title: '',  
                description: '',
                price: '',
                images: []
            }
            };
        },
    mounted() {
        const itemId = this.$route.params.id;
        if(itemId){
            axios.get('https://localhost:5001/api/Items/' + itemId)
                .then((response) => {
                    let itemDetails = response.data;
                    this.form.title = itemDetails.title;
                    this.form.description = itemDetails.description;
                    this.form.price = itemDetails.price;
                })
                .catch((err) => {
                    console.log(err);
                });
        }
    },
});
</script>
<style>

</style>