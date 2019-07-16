export class UserLogin {
    constructor(userEmail?: string, password?: string) {
        this.userEmail = userEmail;
        this.password = password;
    }
    userEmail: string;
    password: string;
}