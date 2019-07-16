import { Component, OnInit, AfterViewInit } from "@angular/core";
import { UserService } from "../services/user.service";
import { isMainThread } from "worker_threads";

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: []

})
export class AppComponent implements OnInit {
    isLoggedIn: boolean;
    title = "InternetMagazin";
    isManager: boolean;
    isUser: boolean;

    constructor(private userService: UserService) { }
    ngOnInit() {
        this.isLoggedIn = this.userService.isLoggin();
        
        setInterval(() => {
            this.isLoggedIn = this.userService.isLoggin();
            this.getRoles();
            
        }, 500)
    }
    
    onLogout() {
        this.userService.onLogout();
    }
    getRoles() {
        if (this.userService.getRolesName() == "manager") {
            this.isManager = true;
            this.isUser = false;

        } else if (this.userService.getRolesName() == "user") {
        this.isUser = true;
            this.isManager = false;
        }

    }
    
}