import {NgModule} from '@angular/core';
import {RecipeListPageComponent} from './recipe-list-page/recipe-list-page.component';
import {RecipeListRoutingModule} from './recipe-list-routing.module';
import {HttpClientModule} from '@angular/common/http';
import {RecipeService} from './recipe.service';
import {BrowserModule} from '@angular/platform-browser';
import {MatCardModule} from '@angular/material/card';
import {RecipeComponent} from './shared/recipe.component/recipe.component';

@NgModule({
    declarations: [
        RecipeListPageComponent,
        RecipeComponent
    ],
    imports: [
        RecipeListRoutingModule,
        HttpClientModule,
        BrowserModule,
        MatCardModule
    ],
    providers: [
        RecipeService
    ]
})

export class RecipeListModule {

}
