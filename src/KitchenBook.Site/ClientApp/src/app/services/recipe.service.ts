import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {RecipeFull, RecipeShort} from '../interface/recipe.interface';

@Injectable()
export class RecipeService {
    private _recipeControllerLink = '/api/recipe/';

    constructor(private http: HttpClient) {
    }

    public getAll(): Observable<RecipeShort[]> {
        return this.http.get<RecipeShort[]>(`${this._recipeControllerLink}get-all`);
    }

    public getById(recipeId: number) {
        return this.http.get(`${this._recipeControllerLink}${recipeId}`);
    }

    public addRecipe(recipe: RecipeShort) {
        return this.http.post(`${this._recipeControllerLink}create`, recipe);
    }

    public delete(recipeId: number) {
        this.http.request('delete', `${this._recipeControllerLink}${recipeId}/delete`).subscribe();
    }
}
