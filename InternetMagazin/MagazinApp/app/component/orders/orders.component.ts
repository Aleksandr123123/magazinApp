import { OnInit, Component, AfterViewInit } from "@angular/core";
import { UsersComponent } from "../users/users.component";
import { OrderItems } from "../../models/orderItems";
import { OrdersService } from "../../services/orders.service";
import { Order } from "../../models/order";
import { UserService } from "../../services/user.service";
import { UserDetails } from "../../models/userDetails";
import { Route, Router } from "@angular/router";

@Component({
    selector: 'app-orders',
    templateUrl: './orders.component.html',
    
})
export class OrdersComponent implements OnInit {
    orderItem: OrderItems = new OrderItems(); 
    orderItems: OrderItems[];
    orderUser: Order = new Order();
    orderUsers: Order[];
    order: Order;
    orderIsNull = false;
    displayOrder = "none";

    userDetails: UserDetails = new UserDetails();
    constructor(public orderService: OrdersService, public userService: UserService, public route: Router) { }
    ngOnInit() {
        this.loadOrderItem();
       
        this.userService.getUserProfile().subscribe(
            res => {
                this.userDetails = res;

            },
            err => {
                console.log(err);
            },
        );
    }
    
    loadOrderItem() {

        this.orderItems = JSON.parse(localStorage.getItem("order"));
        if (this.orderItems!= null)
            this.orderIsNull = true;
    }
 
    loadOrder() {
        
        this.orderService.getOrdersByUser(this.userDetails.id).
            subscribe((data: Order[]) => this.orderUsers = data);
    }
    deleteOrder() {
        
        if (this.orderUser.status == "Новый") {
            this.orderService.deleteOrder(this.orderUser.id).subscribe(data => (this.closeOrder(), this.loadOrder()));
        } else {
            alert("Невозможно удалтиь заказ");
            this.closeOrder();
        }
    }
    save() {
        this.order = new Order();
        this.order.customerId = this.userDetails.id;
        this.order.orderItems = this.orderItems;
        this.orderService.createOrder(this.order).subscribe(
            res => {
                alert("Заказ отправлен на рассмотрение");
            },
            err => {
                alert("Заказ не отправлен на рассмотрение");

            },);
   
        localStorage.setItem("order", null);  
        this.order = new Order();
        this.orderIsNull = false;
    }
    openOrder(p: Order) {
        
        this.orderUser = p;
        this.displayOrder = 'block';
    }
    closeOrder() {
        this.displayOrder = 'none';
    }
}