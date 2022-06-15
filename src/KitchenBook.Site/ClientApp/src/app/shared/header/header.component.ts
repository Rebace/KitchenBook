import {Component, Input, NgModule} from '@angular/core';
import {FormBuilder} from '@angular/forms';
import {UserService} from '../services/accountService';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})


export class HeaderComponent {
    public formLogin = false;
    public formPassword = false;
    public userName = '';

    constructor(private userService: UserService) {
    }
    public onInit() {
        this.userService.authentication().subscribe(
            (result) => {
                this.userName = <string>result;
            }
        );
    }
    public onSubmitLogin(): void {
        this.formPassword = false;
        this.formLogin = true;
    }

    public onSubmitRegister(): void {
        this.formPassword = true;
        this.formLogin = false;
    }

    public onSubmitClose(): void {
        this.formPassword = false;
        this.formLogin = false;
    }
}
