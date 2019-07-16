import { Item } from "./item";

export class OrderItems {
    constructor(

        public item?: Item,
        public itemsCount?: number,
        public itemPrice?: number

    ) { }
}