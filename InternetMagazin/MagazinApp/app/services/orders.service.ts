import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Order } from "../models/order";
import { retry } from "rxjs/operators";

@Injectable()
export class OrdersService {
    private url = "/api/Order";

    constructor(private http: HttpClient) {

    }
    createOrder(order: Order) {
        return this.http.post(this.url, order);
    }
    getOrdersByUser(customerId: string) {
        return this.http.get(this.url + "/getByNumber/" + customerId);
    }
    deleteOrder(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
    updateOrder(o: Order) {
        return this.http.put(this.url,o);
    }



}