import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { retry } from "rxjs/operators";
import { FormBuilder, Validators, FormGroup } from "@angular/forms";
import { resolveAny } from "dns";
import { Router } from "@angular/router";
import { User } from "../models/user";

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private http: HttpClient, private fb: FormBuilder,private router: Router) { }
    readonly baseUrl = '/api/account';
    
    onLogout() {
        localStorage.clear();
        this.router.navigate(['/login']);
    }
    getUsers() {
        return this.http.get(this.baseUrl + '/users');
    }
    login(user: User) {
        return this.http.post(this.baseUrl + '/login', user);
    }
    getUserProfile() {
        return this.http.get(this.baseUrl + '/UserProfile');
    }
    getRolesName() {
        if (localStorage.getItem('token') != null) {
            var payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
            return payLoad.role;
        }
        return null;
       
    }
    roleMatch(allowedRoles: Array<string>): boolean {
        var isMatch = false;
        var payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
        var userRole = payLoad.role;
        allowedRoles.forEach(element => {
            if (userRole == element) {
                isMatch = true;
                return false;
            }
            
        });
       
        return isMatch
    }
    isLoggin(): boolean {
        var isLogin = false;
        var payLoad = localStorage.getItem('token');
        return payLoad != null;

    }

   }