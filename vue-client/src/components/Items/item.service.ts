import axios from 'axios';

import { Item } from './item';

const api = 'https://localhost:5001/api';

class ItemService {
  constructor() {
    console.log('creating new instance of item.service');
  }

  public deleteItem(item: Item) {
    return axios.delete(`${api}/Items/${item.id}`);
  }
  public getItems() {
    return axios.get<Item[]>(`${api}/Items`);
  }
  public addItem(item: Item) {
    return axios.post(`${api}/Items/`, { item });
  }
  public updateItem(item: Item) {
    return axios.put(`${api}/Items/${item.id}`, { item });
  }
}

// Export a singleton instance in the global namespace
export const itemService = new ItemService();
