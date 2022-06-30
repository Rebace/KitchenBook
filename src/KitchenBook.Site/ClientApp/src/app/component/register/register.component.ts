import {Component, EventEmitter, Input, Output} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {UserService} from '../../services/account.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
    @Output() public formClose = new EventEmitter();
    @Output() public formLogin = new EventEmitter();
    public registerForm!: FormGroup;
    public firstDispatch: Boolean = true;
    public successfulRegister: Boolean = true;

    public onSubmitLogin(): void {
        this.formLogin.emit();
    }

    public onSubmitClose(): void {
        this.formClose.emit();
    }

    constructor(private fb: FormBuilder, private userService: UserService) {
        this._createForm();
    }

    private _createForm() {
        this.registerForm = this.fb.group({
            'name': new FormControl('', [Validators.required, Validators.minLength(3)]),
            'login': new FormControl('', [Validators.required, Validators.minLength(5)]),
            'password': new FormControl('', [Validators.required, Validators.minLength(8)]),
            'repeat-password': new FormControl('', [Validators.required, Validators.minLength(8)])
        });
    }
    public register(): void {
        this.firstDispatch = false;
        if (this.registerForm.invalid) {
            return;
        }

        if (this.registerForm.controls['password'].value !== this.registerForm.controls['repeat-password'].value) {
            return;
        }

        const authenticate = {
            login: this.registerForm.controls['login'].value,
            password: this.registerForm.controls['password'].value,
            name: this.registerForm.controls['name'].value
        };

        this.userService.register(authenticate).subscribe(
            (result) => {
                window.location.reload();
            },
            (error) => {
                this.successfulRegister = false;
            }
        );
    }
}
