import { Component, OnInit } from "@angular/core";
import { UsersService } from "../../services/users.service";
import { Router } from "@angular/router";
import { UserService } from "../../services/user.service";
import { Customer } from "../../models/customer";
import { User } from "../../models/user";
import { OrderItems } from "../../models/orderItems";
import { Order } from "../../models/order";
import { OrdersComponent } from "../orders/orders.component";
import { OrdersService } from "../../services/orders.service";
import { retry } from "rxjs/operators";

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
    providers: [UsersService]
})
export class UsersComponent implements OnInit {
    customer: Customer = new Customer();
    userok: User = new User();
    customers: Customer[];
    users: User[];
    order: Order = new Order();

    isAll = true;

    displayCreate = 'none';
    displayUpdateUsers = 'none';
    displayUpdateCustomers = 'none';
    displayOrders = 'none';
    displayOrdersItem = 'none';
    constructor(private usersService: UsersService, private router: Router,private userService: UserService,private orderService: OrdersService) { }

    ngOnInit() {
        this.loadCustomers();
     
    }
    loadCustomers() {
        this.usersService.getUsers().
            subscribe((data: Customer[]) => this.customers = data);
    }
    loadUsers() {
        this.userService.getUsers().
            subscribe((data: User[]) => this.users = data);
         }
    getCustomers() {
        this.loadCustomers();
        this.isAll = true;
    }
    loadAll() {
        this.loadCustomers();
        this.loadUsers();
    }
    saveCustomer() {
        if (this.customer.id == null) {
            this.customer.users = this.userok;
            this.usersService.createCustomers(this.customer)
                .subscribe(data =>
                    this.loadAll()
                    );
            this.closeCreate();
        } else {
            this.usersService.updateCustomer(this.customer)
                .subscribe(data => this.loadCustomers());
            this.closeUpdateCustomer();
        }
       
    }
    deleteUser(u: User) {
        this.usersService.deleteUser(u.id).subscribe(data => this.loadUsers());
    }
    deleteCustomer(u: Customer) {
        this.usersService.deleteCustomer(u.id).subscribe(data => this.loadCustomers());
    }

    saveUser() {
        if (this.userok.id == null) {
            this.usersService.createUser(this.userok)
                .subscribe(data => this.loadAll());
            this.closeCreate();
        } else {
            this.usersService.updateUser(this.userok)
                .subscribe(data => this.loadUsers());
            this.closeUpdateUser();
        }
    }
    getUsers() {
        this.loadUsers();
        this.isAll = false;

    }
    setOrderStatus() {
  
            this.orderService.updateOrder(this.order).
                subscribe(data => this.loadCustomers);
        this.closeOrdersItem();
        
        
    }

    editUsers(p: User) {
        this.userok = p;

        this.openUpdateUser();
    }
    editCustomers(p: Customer) {
        this.customer = p;

        this.openUpdateCustomer();
    }

    openCreate() {
        this.userok = new User();
        this.customer = new Customer();
        this.displayCreate = 'block';
    }
    closeCreate() {
        this.displayCreate = 'none';
    }
    openUpdateUser() {
        this.displayUpdateUsers = 'block';
    }
    closeUpdateUser() {
        this.displayUpdateUsers = 'none';
    }
    openUpdateCustomer() {
        this.displayUpdateCustomers = 'block';
    }
    closeUpdateCustomer() {
        this.displayUpdateCustomers = 'none';
    }
    openOrders(p: Customer) {
        this.customer = p;
        this.displayOrders = 'block';
    }
    closeOrders() {
        this.displayOrders = 'none';
    }
    
    openOrdersItem(p: Order) {
        this.order = p;
        this.displayOrdersItem = 'block';
    }
    closeOrdersItem() {
        this.displayOrdersItem = 'none';
    }
}