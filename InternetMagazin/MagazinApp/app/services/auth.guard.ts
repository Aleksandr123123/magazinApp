import { Injectable } from "@angular/core";
import {Router , NavigationExtras, Route, CanActivate, ActivatedRouteSnapshot, RouterState, RouterStateSnapshot} from "@angular/router"
import { Subject } from "rxjs";
import { UserService } from "./user.service";
import { retry } from "rxjs/operators";
@Injectable({
    providedIn: 'root'
}) 
export class AuthGuard implements CanActivate{
    
   constructor(private router: Router,private service: UserService) {
    }
    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): boolean {
        if (localStorage.getItem('token') != null) {
            let roles = next.data['permittedRoles'] as Array<string>;
            if (roles) {
                if (this.service.roleMatch(roles)) return true;
                else {
                    this.router.navigate(['/forbidden']);
                    return false;
                }
            }
            return true;
            
        }
            else {
                this.router.navigate(['/login'])
                return false;
            }
        }
    }
   

