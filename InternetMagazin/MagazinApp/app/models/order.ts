import { OrderItems } from "./orderItems";

export class Order {
    constructor(
        public id?: number,
        public customerId?: string,
        public status?: string,
        public shipmentDate?: string,

        public orderNumber?: number,
        public orderItems?: Array<OrderItems>
    ) { }
}