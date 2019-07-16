var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserComponent } from './component/user/user.component';
import { LoginComponent } from './component/login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { UserService } from './services/user.service';
import { AuthInterceptor } from './services/auth.interceptor';
import { DataService } from './data.service';
import { AppComponent } from './app';
import { AdminPanelComponent } from './component/admin-panel/admin-panel.component';
import { ForbiddenComponent } from './component/forbidden/forbidden.component';
import { HomeComponent } from './component/home/home.component';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            imports: [BrowserModule, FormsModule, HttpClientModule, AppRoutingModule, ReactiveFormsModule],
            providers: [UserService, DataService, { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
            declarations: [AppComponent, UserComponent, LoginComponent, HomeComponent, AdminPanelComponent, ForbiddenComponent],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map