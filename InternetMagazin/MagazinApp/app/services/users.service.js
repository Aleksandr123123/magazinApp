var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
var UsersService = /** @class */ (function () {
    function UsersService(http) {
        this.http = http;
        this.url = "/api/Users";
    }
    UsersService.prototype.getUsers = function () {
        return this.http.get(this.url);
    };
    UsersService.prototype.createCustomers = function (customer) {
        return this.http.post(this.url + "/createCustomer", customer);
    };
    UsersService.prototype.createUser = function (user) {
        return this.http.post(this.url + "/createUser", user);
    };
    UsersService.prototype.updateUser = function (user) {
        return this.http.put(this.url + '/updateUser', user);
    };
    UsersService.prototype.updateCustomer = function (customer) {
        return this.http.put(this.url + '/updateCustomer', customer);
    };
    UsersService.prototype.deleteUser = function (id) {
        return this.http.delete(this.url + '/user/' + id);
    };
    UsersService.prototype.deleteCustomer = function (id) {
        return this.http.delete(this.url + '/customer/' + id);
    };
    UsersService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], UsersService);
    return UsersService;
}());
export { UsersService };
//# sourceMappingURL=users.service.js.map