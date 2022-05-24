import {Component, Input} from '@angular/core';

@Component({
  selector: 'tl-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.scss']
})

export class RecipeComponent {
  // @ts-ignore
  @Input() recipe: Recipe;

  ngOnInit()
  {
    console.log(this.recipe.title);
  }

}
