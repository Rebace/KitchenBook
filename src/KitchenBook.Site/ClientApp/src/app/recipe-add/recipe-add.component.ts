import {Component} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import {MatChipInputEvent} from '@angular/material/chips';
import {Step} from '../interface/step.interface';
import {Ingredient} from '../interface/ingredient.interface';

@Component({
    selector: 'tl-recipe-add',
    templateUrl: 'recipe-add.component.html',
    styleUrls: ['recipe-add.component.scss']
})

export class RecipeAddComponent {
    public recipeForm!: FormGroup;
    public firstDispatch: Boolean = true;
    addOnBlur = true;
    readonly separatorKeysCodes = [ENTER, COMMA] as const;
    fruits: string[] = [];
    timeList: number[] = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160];
    portionList: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
    steps: Array<Step> = [{id: 1, description: ""}];
    ingredients: Array<Ingredient> = [{id: 1,title: "", description: ""}];

    constructor(private fb: FormBuilder) {
        this._createForm();
    }

    private _createForm() {
        this.recipeForm = this.fb.group({
            'title': new FormControl('', [Validators.required]),
            'description': new FormControl('', [Validators.required]),
            'cookingTime': new FormControl('', [Validators.required]),
            'portions': new FormControl('', [Validators.required])
        });
    }

    add(event: MatChipInputEvent): void {
        const value = (event.value || '').trim();

        // Add our fruit
        if (value) {
            this.fruits.push(value);
        }

        // Clear the input value
        event.chipInput!.clear();
    }

    remove(fruit: string): void {
        const index = this.fruits.indexOf(fruit);

        if (index >= 0) {
            this.fruits.splice(index, 1);
        }
    }

    public addStep(): void {
        let index: number = this.steps.length + 1;
        let step: Step = {id: index, description: ""};
        this.steps.push(step);
    }

    public deleteStep(step: Step): void {
        if (this.steps.length <= 1)
        {
            return;
        }
        this.steps.splice(step.id - 1, 1);
        this.steps.forEach(element =>
        {
            if (element.id > step.id)
            {
                element.id -= 1;
            }
        })
    }

    public addIngredient(): void {
        let index: number = this.ingredients.length + 1;
        let ingredient: Ingredient = {id: index, title: "", description: ""};
        this.ingredients.push(ingredient);
    }

    public deleteIngredient(ingredient: Ingredient): void {
        if (this.ingredients.length <= 1)
        {
            return;
        }
        this.ingredients.splice(ingredient.id - 1, 1);
        this.ingredients.forEach(element =>
        {
            if (element.id > ingredient.id)
            {
                element.id -= 1;
            }
        })
    }

    public recipePublic(): void {
        this.firstDispatch = false;
        if (this.recipeForm.invalid) {
            return;
        }
    }
}
