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

export default class ItemForm extends Vue {

}
</script>
<style>

</style>