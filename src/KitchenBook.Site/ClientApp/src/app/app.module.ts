import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {RecipeListModule} from './recipe-list/recipe-list.module';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HeaderComponent} from './shared/header/header.component';
import {FooterComponent} from './shared/footer/footer.component';
import {LoginComponent} from './shared/login/login.component';
import {RegisterComponent} from './shared/register/register.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {UserService} from './shared/services/accountService';
import {RecipeAddModule} from './recipe-add/recipe-add.module';

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        FooterComponent,
        LoginComponent,
        RegisterComponent
    ],
    imports: [
        BrowserModule,
        RecipeListModule,
        RecipeAddModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [UserService],
    bootstrap: [AppComponent]
})
export class AppModule {
}
