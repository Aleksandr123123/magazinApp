import { Component, OnInit } from "@angular/core";
import { UserLogin } from "../../models/user-login.model";
import { UserService } from "../../services/user.service";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styles: []
})
export class LoginComponent implements OnInit {
    login: UserLogin = new UserLogin();
    constructor(private service: UserService, private router: Router, ) { }
    ngOnInit() {
        if (localStorage.getItem('token') != null)
            this.router.navigateByUrl('/home');

    }
    onSubmit(form: NgForm) {
        this.service.login(form.value).subscribe(
            (res: any) => {
                localStorage.setItem('token', res.token);
                this.router.navigateByUrl('/home');
            }
        );
    }
}