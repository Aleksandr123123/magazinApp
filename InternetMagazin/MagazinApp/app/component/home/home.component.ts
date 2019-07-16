import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { retry } from "rxjs/operators";
import { UserService } from "../../services/user.service";
import { Item } from "../../models/item";
import { ItemService } from "../../services/item.service";
import { OrderItems } from "../../models/orderItems";
import { UserDetails } from "../../models/userDetails";


@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
   })
export class HomeComponent implements OnInit {
    item: Item = new Item();
    items: Item[];
    orderItem: OrderItems = new OrderItems();
    orderItems = new Array<OrderItems>();
  
    userDetails: UserDetails = new UserDetails();
    role: any;
    isManager: boolean;
    isUser: boolean;
    displayCreate = 'none';
    displayUpdate = 'none';
    displayAddOrderItem = 'none';

    constructor(private itemService: ItemService, private router: Router, private userService: UserService) { }
    ngOnInit() {
        this.loadItem();
        this.getRoles();
        this.userService.getUserProfile().subscribe(
            res => {
                this.userDetails = res;

            },
            err => {
                console.log(err);
            },
        );
        this.getRoles();

    }
    getRoles() {
        this.role = this.userService.getRolesName();
        if (this.role == "manager") {
            this.isManager = true;
            this.isUser = false;

            
        } else if (this.role == "user")
        {
            this.isUser = true;
            this.isManager = false;
        }
       
    }
   
    loadItem() {
        this.itemService.getItems().
            subscribe((data: Item[]) => this.items = data);
    }
    save() {
        if (this.item.id == null) { 
        this.itemService.createItem(this.item)
            .subscribe((data: Item) => this.items.push(data));
        this.closeCreate();
    } else {
    this.itemService.updateItem(this.item)
        .subscribe(data => this.loadItem());

            this.closeUpdate();
        }
    }
    deleteItem(i: Item) {
        this.itemService.deleteItem(i.id).subscribe(data => this.loadItem());
     }
    
    editItem(p: Item) {
        this.item = p;
    
        this.openUpdate();
    }
    saveOrderItem() {
        this.orderItems = JSON.parse(localStorage.getItem("order"));
        if (this.orderItems == null) {

            this.orderItems = new Array<OrderItems>();
        }

        this.orderItem.itemPrice = this.orderItem.itemsCount * this.item.price;
        
        this.orderItems.push(this.orderItem);
        
        
        localStorage.setItem("order", JSON.stringify(this.orderItems));
        this.closeAddOrderItem();
    }
    openCreate() {
        this.item = new Item();
        this.displayCreate = 'block';
    }
    closeCreate() {
        this.displayCreate = 'none';
    }
    openUpdate() {
        this.displayUpdate = 'block';
    }
    closeUpdate() {
        this.displayUpdate = 'none';
    }
    openAddOrderItem(i: Item) {
        this.item = i;
        this.orderItem.item = i;
        this.displayAddOrderItem = 'block';
    }
    closeAddOrderItem() {
        this.displayAddOrderItem = 'none';
    }
}