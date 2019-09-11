import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';

import ItemHome from './components/Items/item-home.vue';
import ItemList from './components/Items/item-list.vue';
import ItemDetails from './components/Items/item-details.vue';
import ItemForm from './components/Items/item-form.vue';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/About.vue'),
    },
    {
      path: '/items',
      component: ItemHome,
      children: [
        {
          path: '',
          name: 'items.list',
          component: ItemList,
        },
        {
          path: 'create',
          name: 'items.create',
          component: ItemForm,
        },
        {
          path: ':id',
          name: 'items.details',
          component: ItemDetails,
        },
        {
          path: ':id/edit',
          name: 'items.edit',
          component: ItemForm,
        },
      ],
    },
  ],
});
