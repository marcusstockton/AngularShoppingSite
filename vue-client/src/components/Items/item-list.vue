<template>
<div>
    <h1>item list</h1>
    <router-link v-bind:to="'/items/create'" class="btn btn-primary">Create New</router-link>
    <div class="card-deck">
    <div v-for="item in itemList" :key="item.id" class="card mb-4 mr-3" style="min-width: 18rem;">
        <div class="card-body">
            <h4 class="card-header">{{ item.name | capitalize({ onlyFirstLetter: true })}}</h4>
            <router-link v-bind:to="'/items/' + item.id" class="btn btn-primary">Details</router-link>
            <p class="card-text">{{ item.title | capitalize({ onlyFirstLetter: true })}}</p>
            <p class="card-text">{{ item.description | truncate(100)}}</p>
            <p class="card-text">Price: {{ item.price | currency('£')}}</p>
            <p class="card-text">Created By: {{ item.createdBy.username }}</p>
            <p class="card-text">Created: {{ item.createdDate | formatDate }}</p>
            
        </div>
        <div class="card-footer" v-if=item.updatedDate>
            <small class="text-muted">Last updated {{ item.updatedDate | formatDate }}</small>
        </div>
    </div>
    </div>
</div>
</template>

<script lang="ts">
import Vue from 'vue';
import axios from 'axios';
import Vue2Filters from 'vue2-filters';
import moment from 'moment';

Vue.use(Vue2Filters);

export default Vue.extend({
    data() {
        return {
            itemList: [] as any,
        };
    },
    mounted() {
        axios.get('https://localhost:5001/api/Items')
            .then((response) => {
                this.itemList = [...response.data];
            })
            .catch((err) => {
                console.log(err);
            });
    },
});

Vue.filter('formatDate', (value: any) => {
  if (value) {
    return moment(String(value)).format('DD MMM YYYY hh:mm');
  }
});

</script>

<style scoped>

</style>