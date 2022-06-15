import {Component, EventEmitter, Output} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {UserService} from '../services/accountService';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})

export class LoginComponent {
    @Output() public formClose = new EventEmitter();
    @Output() public formPassword = new EventEmitter();
    public loginForm!: FormGroup;
    public firstDispatch: Boolean = true;
    public successfulLogin: Boolean = true;

    constructor(private fb: FormBuilder, private userService: UserService) {
        this._createForm();
    }

    private _createForm() {
        this.loginForm = this.fb.group({
            'login': new FormControl('', [Validators.required]),
            'password': new FormControl('', [Validators.required])
        });
    }

    public onSubmitRegister(): void {
        this.formPassword.emit();
    }

    public onSubmitClose(): void {
        this.formClose.emit();
    }

    public login(): void {
        this.firstDispatch = false;
        if (this.loginForm.invalid) {
            return;
        }

        const authenticate = {
            login: this.loginForm.controls['login'].value,
            password: this.loginForm.controls['password'].value,
            name: ''
        };
        this.userService.login(authenticate).subscribe(
            (result) => {
                window.location.reload();
            },
            (error) => {
                this.successfulLogin = false;
            }
        );
    }
}
