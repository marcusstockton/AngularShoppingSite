import { User } from '../auth/user';
import { ItemCondition } from '../item-conditions/itemCondition';
import { ItemCategory } from '../item-categories/itemCategory';
import { DeliveryOption } from '../delivery-options/deliveryOption';

export class Item {
    constructor(
      public id: number,
      public title: string,
      public description: string,
      public price: number,
      public createdDate: Date,
      public createdBy: User,
      public itemCondition: ItemCondition,
      public itemCategory: ItemCategory,
      public deliveryOption: DeliveryOption) {

      }
  }
