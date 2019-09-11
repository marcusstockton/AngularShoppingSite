import { User } from 'src/app/auth/models/user';


export interface IItemCategory {
    description: string;
    createdBy: User;
    updatedBy: User;
    createdDate: Date;
    updatedDate: Date;
    id: string;
}
