import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginComponent } from './component/login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { UserService } from './services/user.service';
import { AuthInterceptor } from './services/auth.interceptor';
import { ForbiddenComponent } from './component/forbidden/forbidden.component';
import { HomeComponent } from './component/home/home.component';
import { AppComponent } from './component/app';
import { ItemService } from './services/item.service';
import { UserComponent } from './component/user/user.component';
import { UsersService } from './services/users.service';
import { UsersComponent } from './component/users/users.component';
import { OrdersComponent } from './component/orders/orders.component';
import { OrdersService } from './services/orders.service';
@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, AppRoutingModule, ReactiveFormsModule],
    providers: [UserService, ItemService, UsersService, OrdersService, { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
    declarations: [AppComponent, LoginComponent,UsersComponent,HomeComponent,OrdersComponent,ForbiddenComponent,UserComponent],
    
    bootstrap: [AppComponent]
})
export class AppModule { }