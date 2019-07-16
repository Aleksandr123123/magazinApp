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
import { UserService } from "../services/user.service";
var AppComponent = /** @class */ (function () {
    function AppComponent(userService) {
        this.userService = userService;
        this.title = "InternetMagazin";
    }
    AppComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.isLoggedIn = this.userService.isLoggin();
        setInterval(function () {
            _this.isLoggedIn = _this.userService.isLoggin();
            _this.getRoles();
        }, 500);
    };
    AppComponent.prototype.onLogout = function () {
        this.userService.onLogout();
    };
    AppComponent.prototype.getRoles = function () {
        if (this.userService.getRolesName() == "manager") {
            this.isManager = true;
            this.isUser = false;
        }
        else if (this.userService.getRolesName() == "user") {
            this.isUser = true;
            this.isManager = false;
        }
    };
    AppComponent = __decorate([
        Component({
            selector: 'app',
            templateUrl: './app.component.html',
            styleUrls: []
        }),
        __metadata("design:paramtypes", [UserService])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//# sourceMappingURL=app.js.map