﻿import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Recipe} from './shared/recipe.interface';
import {Observable} from 'rxjs';

@Injectable()
export class RecipeService {
    private _recipeControllerLink = 'http://localhost:5000/recipe/';

    constructor(private http: HttpClient) {
    }

    public GetAll(): Observable<Recipe[]> {
        return this.http.get<Recipe[]>(`${this._recipeControllerLink}get-all`);
    }

    public GetById(recipeId: number) {
        return this.http.get(`${this._recipeControllerLink}${recipeId}`);
    }

    public Create(recipe: Recipe) {
        return this.http.post(`${this._recipeControllerLink}create`, recipe);
    }

    public Delete(recipeId: number) {
        this.http.request('delete', `${this._recipeControllerLink}${recipeId}/delete`).subscribe();
    }
}
