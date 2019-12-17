import { User } from '@/components/auth/user';

export class Review {
    constructor(
        public id: number,
        public rating: number,
        public title: string,
        public description: string,
        public user: User,
    ) {

    }
}
