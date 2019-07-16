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
import { FormBuilder } from "@angular/forms";
import { Router } from "@angular/router";
var UserService = /** @class */ (function () {
    function UserService(http, fb, router) {
        this.http = http;
        this.fb = fb;
        this.router = router;
        this.baseUrl = '/api/account';
    }
    UserService.prototype.onLogout = function () {
        localStorage.clear();
        this.router.navigate(['/login']);
    };
    UserService.prototype.getUsers = function () {
        return this.http.get(this.baseUrl + '/users');
    };
    UserService.prototype.login = function (user) {
        return this.http.post(this.baseUrl + '/login', user);
    };
    UserService.prototype.getUserProfile = function () {
        return this.http.get(this.baseUrl + '/UserProfile');
    };
    UserService.prototype.getRolesName = function () {
        if (localStorage.getItem('token') != null) {
            var payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
            return payLoad.role;
        }
        return null;
    };
    UserService.prototype.roleMatch = function (allowedRoles) {
        var isMatch = false;
        var payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
        var userRole = payLoad.role;
        allowedRoles.forEach(function (element) {
            if (userRole == element) {
                isMatch = true;
                return false;
            }
        });
        return isMatch;
    };
    UserService.prototype.isLoggin = function () {
        var isLogin = false;
        var payLoad = localStorage.getItem('token');
        return payLoad != null;
    };
    UserService = __decorate([
        Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [HttpClient, FormBuilder, Router])
    ], UserService);
    return UserService;
}());
export { UserService };
//# sourceMappingURL=user.service.js.map