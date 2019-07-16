
import { Component, OnInit } from "@angular/core";
import { UserService } from "../../services/user.service";
import { UserDetails } from "../../models/userDetails";
@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
   
})
export class UserComponent implements OnInit {


    userDetails: UserDetails = new UserDetails();
    roles: string;
    constructor(private userService: UserService) { }
    
    ngOnInit() {
        this.userService.getUserProfile().subscribe(
            res => {
                this.userDetails = res;
   
            },
            err => {
                console.log(err);
            },
        );
        this.roles = this.userService.getRolesName();
      
    }
    onLogout() {
        this.userService.onLogout();
    }
   

   

}