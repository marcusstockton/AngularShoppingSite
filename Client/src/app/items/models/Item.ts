import { IReview } from 'src/app/reviews/models/review';
import { User } from 'src/app/auth/models/user';
import {IItemCategory} from 'src/app/items/models/ItemCategory';

export class Item {

}

export interface IItem {
    name: string;
    title: string;
    description: string;
    price: number;
    id: string;
    createdDate: Date;
    updatedDate: Date;
    createdBy: User;
    updatedBy: User;
    reviews: IReview[];
    images: Array<File>;
    itemCategory: IItemCategory;
}

export interface IItemCreate {
    name: string;
    title: string;
    description: string;
    price: number;
    images: Array<File>;
}

export interface IItemDetails {
    name: string;
    title: string;
    description: string;
    price: number;
    reviews: Array<IReview>;
    images: Array<string>;
    createdBy: User;
    updatedBy: User;
}
