import {Component, Input} from '@angular/core';
import {Recipe} from '../../../interface/recipe.interface';

@Component({
    selector: 'tl-recipe',
    templateUrl: './recipe.component.html',
    styleUrls: ['./recipe.component.scss']
})

export class RecipeComponent {
    @Input() public recipe!: Recipe;
}
