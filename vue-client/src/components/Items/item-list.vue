<template>
  <div>
    <div class="button-group">
      <button @click="getItems">Refresh</button>
      <button @click="enableAddMode" v-if="!addingItem && !selectedItem">Add</button>
    </div>
    <transition name="fade">
      <ul class="items" v-if="items && items.length">
        <li v-for="item in items" :key="item.id"
          class="item-container"
          :class="{selected: item === selectedItem}">
          <div class="item-element">
            <div class="badge" >{{item.id}}</div>
            <div class="item-text" @click="onSelect(item)">
              <div class="form-label">{{item.name}}</div>
              <div class="form-label">{{item.title}}</div>
              <div class="form-label">{{item.description}}</div>
              <div class="form-label">{{item.price}}</div>
              <div class="form-label">{{item.createdDate}}</div>
              <span v-if="item.itemCategory">
                <div class="form-label">{{item.itemCategory.description}}</div>
              </span>
              
            </div>
          </div>
          <button class="delete-button" @click="deleteItem(item)">Delete</button>
        </li>
      </ul>
    </transition>
    <transition name="fade">
    <ItemDetail
      v-if="selectedItem || addingItem"
      :item="selectedItem"
      @unselect="unselect"
      @itemChanged="itemChanged"></ItemDetail>
    </transition>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';
import ItemDetail from './item-details.vue';
import { itemService } from './item.service';
import { Item } from './item';
@Component({
  components: { ItemDetail },
})
export default class ItemList extends Vue {
  addingItem = false;
  selectedItem: Item | null = null;
  items: Item[] = [];
  created() {
    this.getItems();
  }
  deleteItem(item: Item) {
    return itemService.deleteItem(item).then(() => {
      this.items = this.items.filter((h) => h !== item);
      if (this.selectedItem === item) {
        this.selectedItem = null;
      }
    });
  }
  enableAddMode() {
    this.addingItem = true;
    this.selectedItem = null;
  }
  getItems() {
    this.items = [];
    this.selectedItem = null;
    return itemService.getItems().then((response) => (this.items = response.data));
  }
  itemChanged(mode: string, item: Item) {
    console.log('item changed', item);
    if (mode === 'add') {
      itemService.addItem(item).then(() => this.items.push(item));
    } else {
      itemService.updateItem(item).then(() => {
        const index = this.items.findIndex((h) => item.id === h.id);
        this.items.splice(index, 1, item);
      });
    }
  }
  onSelect(item: Item) {
    this.selectedItem = item;
  }
  unselect() {
    this.addingItem = false;
    this.selectedItem = null;
  }
}
</script>

<style scoped>

</style>