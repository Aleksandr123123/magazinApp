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
import { DataService } from "./data.service";
import { Item } from "./item";
import { Router } from "@angular/router";
import { UserService } from "./services/user.service";
var HomeComponent = /** @class */ (function () {
    function HomeComponent(dataService, router, userService) {
        this.dataService = dataService;
        this.router = router;
        this.userService = userService;
        this.item = new Item();
        this.tableMode = true;
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
    };
    HomeComponent.prototype.getRoles = function () {
        var payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
        if (payLoad.role == "manager") {
            this.roles = true;
        }
        else {
            this.roles = false;
        }
    };
    HomeComponent.prototype.loadItem = function () {
        var _this = this;
        this.dataService.getItems().
            subscribe(function (data) { return _this.items = data; });
    };
    HomeComponent.prototype.save = function () {
        var _this = this;
        this.dataService.createItem(this.item)
            .subscribe(function (data) { return _this.items.push(data); });
        this.cansel();
    };
    HomeComponent.prototype.cansel = function () {
        this.item = new Item();
        this.tableMode = true;
    };
    HomeComponent.prototype.add = function () {
        this.cansel();
        this.tableMode = false;
    };
    HomeComponent.prototype.onLogout = function () {
        localStorage.clear();
        this.router.navigate(['/user/login']);
    };
    HomeComponent = __decorate([
        Component({
            selector: 'app-home',
            templateUrl: './home.component.html',
            providers: [DataService]
        }),
        __metadata("design:paramtypes", [DataService, Router, UserService])
    ], HomeComponent);
    return HomeComponent;
}());
export { HomeComponent };
//# sourceMappingURL=app.component.js.map