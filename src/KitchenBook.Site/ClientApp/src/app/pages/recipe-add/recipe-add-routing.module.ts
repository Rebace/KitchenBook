import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RecipeAddComponent} from './recipe-add.component';

const routes: Routes = [
    {
        path: 'recipe-add',
        component: RecipeAddComponent,
        children: []
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class RecipeAddRoutingModule {
}
