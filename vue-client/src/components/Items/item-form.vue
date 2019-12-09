<template>
<div>
    <h1>Item Form</h1>
    <form class="form" id="app" @submit="checkForm" novalidate="true">
        <div class="field text-danger">
            <p v-if="errors.length > 0">
                <b>Please correct the following error(s):</b>
                <ul>
                    <li v-for="(error, index) in errors" v-bind:key="index">
                        {{ error }}
                    </li>
                </ul>
            </p>
        </div>

        <div class="field">
            <label class="label" for="title">Title</label>
            <div class="control">
                <input v-model="form.title" id="title" class="input" type="text" placeholder="Title">
            </div>
        </div>
        <div class="field">
            <label class="label" for="description">Description</label>
            <div class="control">
                <input v-model="form.description" id="description" class="input" type="text" placeholder="Description">
            </div>
        </div>
        <div class="field">
            <label class="label" for="price">Price</label>
            <div class="control">
                <input v-model="form.price" id="price" class="input" type="number" placeholder="0.00">
            </div>
        </div>
        <div class="field">
            <label class="label">Images
                <input type="file" id="images" ref="images" multiple v-on:change="handleFileUploads()"/>
            </label>
        </div>      
        <button v-on:click="submitNewItem()">Submit</button>  
    </form>
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
                images: [],
            },
            errors: []
        };
    },
    props: ['item'],
    mounted() {
        const itemId = this.$route.params.id;
        if(itemId) {
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
    methods: {
        // Handles a file upload
        handleFileUploads(){
            this.form.images = this.$refs.images.images;
        },

        // Submits the form to the server.
        submitNewItem() {
            let formData = new FormData();
            formData.append('title', this.form.title);
            formData.append('description', this.form.description);
            formData.append('price', this.form.price);

            this.form.images.forEach((element) => {
                formData.append('images', element);
            });
            
            for(let pair of formData.entries()){
                console.log(pair);
            }
            
        },

        checkForm: function(e) {
            this.errors = [];

            if (this.form.title && this.form.desc && this.form.price) {
                return true;
            }

            if (!this.form.title) {
                this.errors.push('Title required.');
            }
            if (!this.form.desc) {
                this.errors.push('Description required.');
            }
            if (!this.form.price) {
                this.errors.push('Price required.');
            }
            e.preventDefault();
        },
    },
});
</script>
<style>

</style>