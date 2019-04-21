export class Item implements IItem {
    Name: string;
    Title: string;
    Description: string;
    Price: number;
    Id: string;
    CreatedDate: Date;
    UpdatedDate: Date;
}

export interface IItem {
    Name: string;
    Title: string;
    Description: string;
    Price: number;
    Id: string;
    CreatedDate: Date;
    UpdatedDate: Date;
}
