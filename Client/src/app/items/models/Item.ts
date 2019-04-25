import { IReview } from 'src/app/reviews/models/review';

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
    reviews: IReview[],
}
