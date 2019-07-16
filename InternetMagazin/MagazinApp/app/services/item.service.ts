import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Item } from "../models/item";
import { retry } from "rxjs/operators";

@Injectable()
export class ItemService {
    private url = "/api/Item";
    constructor(private http: HttpClient) {

    }
    getItems() {
        return this.http.get(this.url);
    }
    createItem(item: Item) {
        return this.http.post(this.url+'/add', item);
    }
    updateItem(item: Item) {
        return this.http.put(this.url +'/update', item);
    }
    deleteItem(id: number) {
        return this.http.delete(this.url + '/' + id);
    }

}