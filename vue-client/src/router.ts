import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';

import ItemHome from './components/Items/item-home.vue';
import ItemList from './components/Items/item-list.vue';
import ItemDetails from './components/Items/item-details.vue';
import ItemForm from './components/Items/item-form.vue';
import Login from './components/auth/Login.vue';
import Register from './components/auth/Register.vue';
import DeliveryOption from './components/delivery-options/DeliveryOption.vue';
import ItemCondition from './components/item-conditions/ItemCondition.vue';
import ItemCategory from './components/item-categories/ItemCategory.vue';

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
      path: '/login',
      name: 'login',
      component: Login,
    },
    {
      path: '/register',
      name: 'register',
      component: Register,
    },
    {
      path: '/item-category',
      name: 'item-category',
      component: ItemCategory,
    },
    {
      path: '/delivery-option',
      name: 'delivery-option',
      component: DeliveryOption,
    },
    {
      path: '/item-condition',
      name: 'item-condition',
      component: ItemCondition,
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
