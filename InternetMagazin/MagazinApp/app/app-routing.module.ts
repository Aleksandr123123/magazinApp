import { Route, Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./component/login/login.component";
import { NgModel } from "@angular/forms";
import { NgModule } from "@angular/core";
import { AuthGuard } from "./services/auth.guard";
import { ForbiddenComponent } from "./component/forbidden/forbidden.component";
import { HomeComponent } from "./component/home/home.component";
import { UsersComponent } from "./component/users/users.component";
import { OrdersComponent } from "./component/orders/orders.component";

const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    {path: 'login', component: LoginComponent},
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'forbidden', component: ForbiddenComponent },
    { path: 'users', component: UsersComponent, canActivate: [AuthGuard] },
    { path: 'orders', component: OrdersComponent, canActivate: [AuthGuard] }
   
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }