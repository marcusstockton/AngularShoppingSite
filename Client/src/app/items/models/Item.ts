import { IReview } from 'src/app/reviews/models/review';
import { User } from 'src/app/auth/models/user';

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
    reviews: IReview[];
    createdBy: User;
    updatedBy: User;
}
