import {Component, OnInit} from '@angular/core';
import {RecipeService} from '../recipe.service';
import {RecipeShort} from '../../interface/recipe.interface';

@Component({
    selector: 'tl-recipe-list',
    templateUrl: 'recipe-list-page.component.html',
    styleUrls: ['recipe-list-page.component.scss']
})

export class RecipeListPageComponent implements OnInit {
    constructor(private recipeService: RecipeService) {
    }

    public recipes: Array<RecipeShort> = [];

    public ngOnInit(): void {
        this.recipeService.getAll().subscribe((raw: RecipeShort[]) => {
            const recipes = <Array<RecipeShort>>raw;
            recipes.forEach(recipe => {
                this.recipes.push(<RecipeShort>recipe);
            });
        });
    }
}
