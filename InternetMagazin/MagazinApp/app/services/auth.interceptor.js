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
import { tap } from "rxjs/operators";
import { Router } from "@angular/router";
var AuthInterceptor = /** @class */ (function () {
    function AuthInterceptor(router) {
        this.router = router;
    }
    AuthInterceptor.prototype.intercept = function (req, next) {
        var _this = this;
        if (localStorage.getItem('token') != null) {
            var clonedReq = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
            });
            return next.handle(clonedReq).pipe(tap(function (succ) { }, function (err) {
                if (err.status == 401) {
                    localStorage.removeItem('token');
                    _this.router.navigateByUrl('/login');
                }
                else if (err.status == 403)
                    _this.router.navigateByUrl('/forbidden');
            }));
        }
        else
            return next.handle(req.clone());
    };
    AuthInterceptor = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [Router])
    ], AuthInterceptor);
    return AuthInterceptor;
}());
export { AuthInterceptor };
//# sourceMappingURL=auth.interceptor.js.map