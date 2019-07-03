import { IReview } from 'src/app/reviews/models/review';
import { User } from 'src/app/auth/models/user';

export class Item {

}

export interface IItem {
    createdBy: User;
    name: string;
    title: string;
    description: string;
    price: number;
    id: string;
    createdDate: Date;
    updatedDate: Date;
    reviews: IReview[];
    images: Array<File>;
}

export interface IItemCreate {
    name: string;
    title: string;
    description: string;
    price: number;
}

export interface IItemDetails {
    name: string;
    title: string;
    description: string;
    price: number;
    reviews: Array<IReview>;
    images: Array<string>;
    createdBy: User;
    createdDate: Date;
}