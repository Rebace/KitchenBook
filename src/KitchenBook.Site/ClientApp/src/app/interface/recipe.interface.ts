import {Ingredient} from './ingredient.interface';
import {Step} from './step.interface';

export interface RecipeShort {
    id: number;
    title: string;
    description: string;
    cookingTime: number;
    portions: number;
    stars: number;
    likes: number;
}

export interface RecipeFull {
    id: number;
    title: string;
    description: string;
    cookingTime: number;
    portions: number;
    stars: number;
    likes: number;
    RecipeSteps: Step[];
    RecipeIngredients: Ingredient[];
}
