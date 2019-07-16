import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Item } from "../models/item";
import { retry } from "rxjs/operators";
import { Customer } from "../models/customer";
import { FormBuilder, Validators } from "@angular/forms";
import { User } from "../models/user";

@Injectable()
export class UsersService {
    private url = "/api/Users";
    constructor(private http: HttpClient) {

    }
   
    getUsers() {
        return this.http.get(this.url);
    }
    createCustomers(customer: Customer) {
        
        return this.http.post(this.url+"/createCustomer", customer);
    }
    createUser(user: User) {

        return this.http.post(this.url + "/createUser", user);
    }
    updateUser(user: User) {
        return this.http.put(this.url + '/updateUser', user);
    }
    updateCustomer(customer: Customer) {
        return this.http.put(this.url + '/updateCustomer', customer);
    }
    deleteUser(id: string) {
        return this.http.delete(this.url + '/user/' + id);
    }
    deleteCustomer(id: number) {
        return this.http.delete(this.url + '/customer/' + id);
    }

}