import {HttpClient} from '@angular/common/http';
import {Authenticate} from '../models/authenticate';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {RecipeShort} from '../../interface/recipe.interface';
import {User} from '../models/user';

@Injectable()
export class UserService {
    private _userControllerLink = '/api/users/';

    constructor(private http: HttpClient) {
    }

    public authorization(): Observable<User> {
        return this.http.get<User>(`${this._userControllerLink}get-authorized`);
    }

    public login(login: Authenticate) {
        return this.http.post(`${this._userControllerLink}login`, login);
    }

    public register(register: Authenticate) {
        return this.http.post(`${this._userControllerLink}register`, register);
    }
}
