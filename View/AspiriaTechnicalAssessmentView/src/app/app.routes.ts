import { Routes } from '@angular/router';
import { ToysComponent } from './content/toys-component/toys.component';

export const routes: Routes = [
    {
        path: 'toys', component: ToysComponent
    },
    {
        path: '**', component: ToysComponent
    }
];
