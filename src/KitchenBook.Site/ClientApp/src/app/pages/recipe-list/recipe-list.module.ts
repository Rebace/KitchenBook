import {NgModule} from '@angular/core';
import {RecipeListRoutingModule} from './recipe-list-routing.module';
import {HttpClientModule} from '@angular/common/http';
import {BrowserModule} from '@angular/platform-browser';
import {MatCardModule} from '@angular/material/card';
import {MatSliderModule} from '@angular/material/slider';
import {RecipeListPageComponent} from './recipe-list.component';
import {RecipeComponent} from '../../component/recipe.component/recipe.component';
import {RecipeService} from '../../services/recipe.service';

@NgModule({
    declarations: [
        RecipeListPageComponent,
        RecipeComponent
    ],
    imports: [
        RecipeListRoutingModule,
        HttpClientModule,
        BrowserModule,
        MatCardModule,
        MatSliderModule,
    ],
    providers: [
        RecipeService
    ]
})

export class RecipeListModule {

}
