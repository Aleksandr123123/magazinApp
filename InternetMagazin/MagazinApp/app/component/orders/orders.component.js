var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from "@angular/core";
import { OrderItems } from "../../models/orderItems";
import { OrdersService } from "../../services/orders.service";
import { Order } from "../../models/order";
import { UserService } from "../../services/user.service";
import { UserDetails } from "../../models/userDetails";
import { Router } from "@angular/router";
var OrdersComponent = /** @class */ (function () {
    function OrdersComponent(orderService, userService, route) {
        this.orderService = orderService;
        this.userService = userService;
        this.route = route;
        this.orderItem = new OrderItems();
        this.orderUser = new Order();
        this.orderIsNull = false;
        this.displayOrder = "none";
        this.userDetails = new UserDetails();
    }
    OrdersComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.loadOrderItem();
        this.userService.getUserProfile().subscribe(function (res) {
            _this.userDetails = res;
        }, function (err) {
            console.log(err);
        });
    };
    OrdersComponent.prototype.loadOrderItem = function () {
        this.orderItems = JSON.parse(localStorage.getItem("order"));
        if (this.orderItems != null)
            this.orderIsNull = true;
    };
    OrdersComponent.prototype.loadOrder = function () {
        var _this = this;
        this.orderService.getOrdersByUser(this.userDetails.id).
            subscribe(function (data) { return _this.orderUsers = data; });
    };
    OrdersComponent.prototype.deleteOrder = function () {
        var _this = this;
        if (this.orderUser.status == "Новый") {
            this.orderService.deleteOrder(this.orderUser.id).subscribe(function (data) { return (_this.closeOrder(), _this.loadOrder()); });
        }
        else {
            alert("Невозможно удалтиь заказ");
            this.closeOrder();
        }
    };
    OrdersComponent.prototype.save = function () {
        this.order = new Order();
        this.order.customerId = this.userDetails.id;
        this.order.orderItems = this.orderItems;
        this.orderService.createOrder(this.order).subscribe(function (res) {
            alert("Заказ отправлен на рассмотрение");
        }, function (err) {
            alert("Заказ не отправлен на рассмотрение");
        });
        localStorage.setItem("order", null);
        this.order = new Order();
        this.orderIsNull = false;
    };
    OrdersComponent.prototype.openOrder = function (p) {
        this.orderUser = p;
        this.displayOrder = 'block';
    };
    OrdersComponent.prototype.closeOrder = function () {
        this.displayOrder = 'none';
    };
    OrdersComponent = __decorate([
        Component({
            selector: 'app-orders',
            templateUrl: './orders.component.html',
        }),
        __metadata("design:paramtypes", [OrdersService, UserService, Router])
    ], OrdersComponent);
    return OrdersComponent;
}());
export { OrdersComponent };
//# sourceMappingURL=orders.component.js.map