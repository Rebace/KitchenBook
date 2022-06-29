import {Component, Input, NgModule} from '@angular/core';
import {UserService} from '../services/account.service';
import {Router} from '@angular/router';
import {User} from '../models/user';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})


export class HeaderComponent {
    public formLogin = false;
    public formPassword = false;
    public userName = '';

    constructor(private userService: UserService, private router: Router) {
    }

    public ngOnInit() {
        if ((getCookie('Login') == null) || (getCookie('Token') == null))
        {
            return;
        }

        this.userService.authorization().subscribe(
            (result: User) => {
                let user = <User>result;
                if (user != null)
                {
                    this.userName = user.name;
                }
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

    public onSubmitRedirection(linq: string): void {
        linq = '/' + linq;
        this.router.navigateByUrl(linq)
    }

    public onSubmitExit(): void {
        document.cookie = "Login=; path=/";
        document.cookie = "Token=; path=/";
        window.location.reload();
    }
}

function getCookie(name: string) {
    let matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}
