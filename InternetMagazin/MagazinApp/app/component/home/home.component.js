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
import { Router } from "@angular/router";
import { UserService } from "../../services/user.service";
import { Item } from "../../models/item";
import { ItemService } from "../../services/item.service";
import { OrderItems } from "../../models/orderItems";
import { UserDetails } from "../../models/userDetails";
var HomeComponent = /** @class */ (function () {
    function HomeComponent(itemService, router, userService) {
        this.itemService = itemService;
        this.router = router;
        this.userService = userService;
        this.item = new Item();
        this.orderItem = new OrderItems();
        this.orderItems = new Array();
        this.userDetails = new UserDetails();
        this.displayCreate = 'none';
        this.displayUpdate = 'none';
        this.displayAddOrderItem = 'none';
    }
    HomeComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.loadItem();
        this.getRoles();
        this.userService.getUserProfile().subscribe(function (res) {
            _this.userDetails = res;
        }, function (err) {
            console.log(err);
        });
        this.getRoles();
    };
    HomeComponent.prototype.getRoles = function () {
        this.role = this.userService.getRolesName();
        if (this.role == "manager") {
            this.isManager = true;
            this.isUser = false;
        }
        else if (this.role == "user") {
            this.isUser = true;
            this.isManager = false;
        }
    };
    HomeComponent.prototype.loadItem = function () {
        var _this = this;
        this.itemService.getItems().
            subscribe(function (data) { return _this.items = data; });
    };
    HomeComponent.prototype.save = function () {
        var _this = this;
        if (this.item.id == null) {
            this.itemService.createItem(this.item)
                .subscribe(function (data) { return _this.items.push(data); });
            this.closeCreate();
        }
        else {
            this.itemService.updateItem(this.item)
                .subscribe(function (data) { return _this.loadItem(); });
            this.closeUpdate();
        }
    };
    HomeComponent.prototype.deleteItem = function (i) {
        var _this = this;
        this.itemService.deleteItem(i.id).subscribe(function (data) { return _this.loadItem(); });
    };
    HomeComponent.prototype.editItem = function (p) {
        this.item = p;
        this.openUpdate();
    };
    HomeComponent.prototype.saveOrderItem = function () {
        this.orderItems = JSON.parse(localStorage.getItem("order"));
        if (this.orderItems == null) {
            this.orderItems = new Array();
        }
        this.orderItem.itemPrice = this.orderItem.itemsCount * this.item.price;
        this.orderItems.push(this.orderItem);
        localStorage.setItem("order", JSON.stringify(this.orderItems));
        this.closeAddOrderItem();
    };
    HomeComponent.prototype.openCreate = function () {
        this.item = new Item();
        this.displayCreate = 'block';
    };
    HomeComponent.prototype.closeCreate = function () {
        this.displayCreate = 'none';
    };
    HomeComponent.prototype.openUpdate = function () {
        this.displayUpdate = 'block';
    };
    HomeComponent.prototype.closeUpdate = function () {
        this.displayUpdate = 'none';
    };
    HomeComponent.prototype.openAddOrderItem = function (i) {
        this.item = i;
        this.orderItem.item = i;
        this.displayAddOrderItem = 'block';
    };
    HomeComponent.prototype.closeAddOrderItem = function () {
        this.displayAddOrderItem = 'none';
    };
    HomeComponent = __decorate([
        Component({
            selector: 'app-home',
            templateUrl: './home.component.html',
        }),
        __metadata("design:paramtypes", [ItemService, Router, UserService])
    ], HomeComponent);
    return HomeComponent;
}());
export { HomeComponent };
//# sourceMappingURL=home.component.js.map