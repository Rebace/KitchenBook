import {Component} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import {MatChipInputEvent} from '@angular/material/chips';
import {Router} from '@angular/router';
import { Step } from 'src/app/interface/step.interface';
import {Ingredient} from '../../interface/ingredient.interface';
import {RecipeService} from '../../services/recipe.service';
import {RecipeShort} from '../../interface/recipe.interface';

@Component({
    selector: 'tl-recipe-add',
    templateUrl: 'recipe-add.component.html',
    styleUrls: ['recipe-add.component.scss']
})

export class RecipeAddComponent {
    public recipeForm!: FormGroup;
    addOnBlur = true;
    readonly separatorKeysCodes = [ENTER, COMMA] as const;
    tags: string[] = [];
    timeList: number[] = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160];
    portionList: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
    steps: Array<Step> = [];
    ingredients: Array<Ingredient> = [];

    constructor(private fb: FormBuilder, private router: Router, private _recipeService: RecipeService) {
        this._createForm();
    }

    private _createForm() {
        this.recipeForm = this.fb.group({
            'title': new FormControl('', [Validators.required]),
            'description': new FormControl('', [Validators.required]),
            'cookingTime': new FormControl('', [Validators.required]),
            'portions': new FormControl('', [Validators.required])
        });

        this.addIngredient();
        this.addStep();
    }

    add(event: MatChipInputEvent): void {
        const value = (event.value || '').trim();

        // Add our fruit
        if (value) {
            this.tags.push(value);
        }

        // Clear the input value
        event.chipInput!.clear();
    }

    remove(fruit: string): void {
        const index = this.tags.indexOf(fruit);

        if (index >= 0) {
            this.tags.splice(index, 1);
        }
    }

    public addStep(): void {
        let step: Step = {Id: this.steps.length, Description: "stepDescription" + this.steps.length};
        this.steps.push(step);
        this.recipeForm.addControl(step.Description, new FormControl("", Validators.required));
    }

    public deleteStep(i: number): void {
        let step: Step = {Id: i, Description: "stepDescription" + i};
        if (this.steps.length > 1) {
            this.recipeForm.removeControl(step.Description);
            this.steps.splice(i, 1);
        }
    }

    public addIngredient(): void {
        let ingredient: Ingredient = {
            Id: this.ingredients.length,
            Title: "ingredientTitle" + this.ingredients.length,
            Description: "ingredientDescription" + this.ingredients.length
        };
        this.ingredients.push(ingredient);
        this.recipeForm.addControl(ingredient.Title, new FormControl("", Validators.required));
        this.recipeForm.addControl(ingredient.Description, new FormControl("", Validators.required));
    }

    public deleteIngredient(i: number): void {
        let ingredient: Ingredient = {Id: i, Title: "ingredientTitle" + i, Description: "ingredientDescription" + i};
        if (this.ingredients.length > 1) {
            this.recipeForm.removeControl(ingredient.Title);
            this.recipeForm.removeControl(ingredient.Description);
            this.ingredients.splice(i, 1);
        }
    }

    public recipePublic(): void {
        if (this.recipeForm.invalid) {
            Object.keys(this.recipeForm.controls)
                .forEach(controlName => this.recipeForm.controls[controlName].markAsTouched());
            return;
        }

        let stepsRecipe: Step[] = [];
        for (let i = 0; i < this.steps.length; i++) {
            let step: Step = {Id: i, Description: this.recipeForm.controls[this.steps[i].Description].value};
            stepsRecipe.push(step);
        }

        let ingredientsRecipe: Ingredient[] = [];
        for (let i = 0; i < this.ingredients.length; i++) {
            let ingredient: Ingredient = {
                Id: i,
                Title: this.recipeForm.controls[this.ingredients[i].Title].value,
                Description: this.recipeForm.controls[this.ingredients[i].Description].value
            };
            ingredientsRecipe.push(ingredient);
        }

        let recipe: RecipeShort = {
            id: 0,
            title: this.recipeForm.controls["title"].value,
            description: this.recipeForm.controls["description"].value,
            cookingTime: this.recipeForm.controls["cookingTime"].value,
            portions: this.recipeForm.controls["portions"].value,
            stars: 0,
            likes: 0
        }

        this._recipeService.addRecipe(recipe).subscribe(
            () => this.router.navigateByUrl('/')
        )
    }
}
