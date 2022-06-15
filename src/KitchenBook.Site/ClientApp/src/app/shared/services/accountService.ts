import {HttpClient} from '@angular/common/http';
import {Authenticate} from '../models/authenticate';
import {Injectable} from '@angular/core';

@Injectable()
export class UserService {
    private _userControllerLink = 'http://localhost:5000/user/';

    constructor(private http: HttpClient) {
    }

    public authentication() {
        return this.http.get(`${this._userControllerLink}authentication`);
    }

    public login(login: Authenticate) {
        return this.http.post(`${this._userControllerLink}login`, login);
    }

    public register(register: Authenticate) {
        return this.http.post(`${this._userControllerLink}register`, register);
    }
}
