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
import { UsersService } from "../../services/users.service";
import { Router } from "@angular/router";
import { UserService } from "../../services/user.service";
import { Customer } from "../../models/customer";
import { User } from "../../models/user";
import { Order } from "../../models/order";
import { OrdersService } from "../../services/orders.service";
var UsersComponent = /** @class */ (function () {
    function UsersComponent(usersService, router, userService, orderService) {
        this.usersService = usersService;
        this.router = router;
        this.userService = userService;
        this.orderService = orderService;
        this.customer = new Customer();
        this.userok = new User();
        this.order = new Order();
        this.isAll = true;
        this.displayCreate = 'none';
        this.displayUpdateUsers = 'none';
        this.displayUpdateCustomers = 'none';
        this.displayOrders = 'none';
        this.displayOrdersItem = 'none';
    }
    UsersComponent.prototype.ngOnInit = function () {
        this.loadCustomers();
    };
    UsersComponent.prototype.loadCustomers = function () {
        var _this = this;
        this.usersService.getUsers().
            subscribe(function (data) { return _this.customers = data; });
    };
    UsersComponent.prototype.loadUsers = function () {
        var _this = this;
        this.userService.getUsers().
            subscribe(function (data) { return _this.users = data; });
    };
    UsersComponent.prototype.getCustomers = function () {
        this.loadCustomers();
        this.isAll = true;
    };
    UsersComponent.prototype.loadAll = function () {
        this.loadCustomers();
        this.loadUsers();
    };
    UsersComponent.prototype.saveCustomer = function () {
        var _this = this;
        if (this.customer.id == null) {
            this.customer.users = this.userok;
            this.usersService.createCustomers(this.customer)
                .subscribe(function (data) {
                return _this.loadAll();
            });
            this.closeCreate();
        }
        else {
            this.usersService.updateCustomer(this.customer)
                .subscribe(function (data) { return _this.loadCustomers(); });
            this.closeUpdateCustomer();
        }
    };
    UsersComponent.prototype.deleteUser = function (u) {
        var _this = this;
        this.usersService.deleteUser(u.id).subscribe(function (data) { return _this.loadUsers(); });
    };
    UsersComponent.prototype.deleteCustomer = function (u) {
        var _this = this;
        this.usersService.deleteCustomer(u.id).subscribe(function (data) { return _this.loadCustomers(); });
    };
    UsersComponent.prototype.saveUser = function () {
        var _this = this;
        if (this.userok.id == null) {
            this.usersService.createUser(this.userok)
                .subscribe(function (data) { return _this.loadAll(); });
            this.closeCreate();
        }
        else {
            this.usersService.updateUser(this.userok)
                .subscribe(function (data) { return _this.loadUsers(); });
            this.closeUpdateUser();
        }
    };
    UsersComponent.prototype.getUsers = function () {
        this.loadUsers();
        this.isAll = false;
    };
    UsersComponent.prototype.setOrderStatus = function () {
        var _this = this;
        this.orderService.updateOrder(this.order).
            subscribe(function (data) { return _this.loadCustomers; });
        this.closeOrdersItem();
    };
    UsersComponent.prototype.editUsers = function (p) {
        this.userok = p;
        this.openUpdateUser();
    };
    UsersComponent.prototype.editCustomers = function (p) {
        this.customer = p;
        this.openUpdateCustomer();
    };
    UsersComponent.prototype.openCreate = function () {
        this.userok = new User();
        this.customer = new Customer();
        this.displayCreate = 'block';
    };
    UsersComponent.prototype.closeCreate = function () {
        this.displayCreate = 'none';
    };
    UsersComponent.prototype.openUpdateUser = function () {
        this.displayUpdateUsers = 'block';
    };
    UsersComponent.prototype.closeUpdateUser = function () {
        this.displayUpdateUsers = 'none';
    };
    UsersComponent.prototype.openUpdateCustomer = function () {
        this.displayUpdateCustomers = 'block';
    };
    UsersComponent.prototype.closeUpdateCustomer = function () {
        this.displayUpdateCustomers = 'none';
    };
    UsersComponent.prototype.openOrders = function (p) {
        this.customer = p;
        this.displayOrders = 'block';
    };
    UsersComponent.prototype.closeOrders = function () {
        this.displayOrders = 'none';
    };
    UsersComponent.prototype.openOrdersItem = function (p) {
        this.order = p;
        this.displayOrdersItem = 'block';
    };
    UsersComponent.prototype.closeOrdersItem = function () {
        this.displayOrdersItem = 'none';
    };
    UsersComponent = __decorate([
        Component({
            selector: 'app-users',
            templateUrl: './users.component.html',
            providers: [UsersService]
        }),
        __metadata("design:paramtypes", [UsersService, Router, UserService, OrdersService])
    ], UsersComponent);
    return UsersComponent;
}());
export { UsersComponent };
//# sourceMappingURL=users.component.js.map