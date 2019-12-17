<template>
  <div class="editarea">
    <div>
      <div class="editfields">
        <div>
          <label>Id: </label>
          <input v-if="addingItem" type="number" v-model="editingItem.id" ref="id" placeholder="id" />
          <label v-if="!addingItem" class="value">{{editingItem.id}}</label>
        </div>
        <div>
          <label>Name: </label>
          <input v-model="editingItem.name" ref="name" placeholder="name" />
        </div>
        <div>
          <label>Description: </label>
          <input v-model="editingItem.description" placeholder="description" @keyup.enter="save"/>
        </div>
        <div>
          <label>Price: </label>
          <input v-model="editingItem.price" placeholder="price" @keyup.enter="save"/>
        </div>
        <div>
          <label>Category: </label>
          <input v-model="editingItem.itemCategory" placeholder="category" @keyup.enter="save"/>
        </div>
      </div>
      <button @click="clear">Cancel</button>
      <button @click="save">Save</button>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Component, Emit, Prop, Watch } from 'vue-property-decorator';
import { Item } from './item';
@Component({})
export default class ItemDetail extends Vue {
  @Prop() item: Item;
  addingItem = !this.item;
  editingItem: Item | null;
  @Watch('item') onItemChanged(value: string, oldValue: string) {
    this.editingItem = this.cloneIt();
  }
  $refs: {
    id: HTMLElement;
    name: HTMLElement;
  };
  addItem() {
    const item = this.editingItem as Item;
    this.emitRefresh('add', item);
  }
  @Emit('unselect') clear() {
    this.editingItem = null;
  }
  cloneIt() {
    return Object.assign({}, this.item);
  }
  created() {
    this.editingItem = this.cloneIt();
  }
  @Emit('itemChanged') emitRefresh(mode: string, item: Item) {
    this.clear();
  }
  mounted() {
    if (this.addingItem && this.editingItem) {
      this.$refs.id.focus();
    } else {
      this.$refs.name.focus();
    }
  }
  save() {
    if (this.addingItem) {
      this.addItem();
    } else {
      this.updateItem();
    }
  }
  updateItem() {
    const item = this.editingItem as Item;
    this.emitRefresh('update', item);
  }
}
</script>

<style scoped>

</style>