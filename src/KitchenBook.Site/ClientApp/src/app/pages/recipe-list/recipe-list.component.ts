import {Component, OnInit} from '@angular/core';
import {RecipeShort} from '../../interface/recipe.interface';
import {Router} from '@angular/router';
import {RecipeService} from '../../services/recipe.service';

@Component({
    selector: 'tl-recipe-list',
    templateUrl: 'recipe-list.component.html',
    styleUrls: ['recipe-list.component.scss']
})

export class RecipeListPageComponent implements OnInit {
    constructor(private recipeService: RecipeService, private router: Router) {
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

    public onSubmitRedirection(linq: string) {
        linq = '/' + linq;
        this.router.navigateByUrl(linq)
    }
}
