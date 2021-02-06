import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateComponent } from './Car-Create/create/create.component';
import { DeleteComponent } from './Car-Delete/delete/delete.component';
import { DetailsComponent } from './Car-Details/details/details.component';
import { CarsListComponent } from './Car-List/cars-list/cars-list.component';
import { LoginComponent } from './Login/login/login.component';
import { RegisterComponent } from './Register/register/register.component';
import { AuthGuardService } from './Services/auth-guard.service';


const routes: Routes = [
  {path:"Cars",component:CarsListComponent},
  {path:"Cars/Create",component:CreateComponent,canActivate:[AuthGuardService]},
  {path:"Cars/:id",component:DetailsComponent},
  {path:"Login",component:LoginComponent},
  {path:"Register",component:RegisterComponent},
  {path:"Delete",component:DeleteComponent},
  {path:"**",component:CarsListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
