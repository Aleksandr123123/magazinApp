import { Order } from "./order";


export class Customer {
    constructor(
        public id?: number,
        public name?: string,
        public code?: string,
        public address?: string,
        public discount?: number,
        public orders?: Array<Order> ,
        public users?: any) { }

}


