import {NgModule} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {BrowserModule} from '@angular/platform-browser';
import {RecipeAddComponent} from './recipe-add.component';
import {RecipeAddRoutingModule} from './recipe-add-routing.module';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatChipsModule} from '@angular/material/chips';
import {MatIconModule} from '@angular/material/icon';


@NgModule({
    declarations: [
        RecipeAddComponent
    ],
    imports: [
        RecipeAddRoutingModule,
        HttpClientModule,
        BrowserModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatChipsModule,
        MatIconModule,
        FormsModule
    ],
    providers: [
    ]
})

export class RecipeAddModule {

}
