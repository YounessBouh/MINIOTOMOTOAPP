import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { ReactiveFormsModule } from '@angular/forms';



import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateComponent } from './Car-Create/create/create.component';
import { DetailsComponent } from './Car-Details/details/details.component';
import { CarsListComponent } from './Car-List/cars-list/cars-list.component';
import { DeleteComponent } from './Car-Delete/delete/delete.component';
import { UpdateComponent } from './Car-Update/update/update.component';
import { FooterComponent } from './Footer/footer/footer.component';
import { LoginComponent } from './Login/login/login.component';
import { RegisterComponent } from './Register/register/register.component';
import { NavbarComponent } from './Nav-Bar/navbar/navbar.component';
import { CarService } from './Services/car.service';
import { AuthGuardService } from './Services/auth-guard.service';
import { UserService } from './Services/user.service';
import { AuthService } from './Services/auth.service';
import { TokenInterceptorService } from './Services/token-interceptor.service';



@NgModule({
  declarations: [
    AppComponent,
    CreateComponent,
    DetailsComponent,
    CarsListComponent,
    DeleteComponent,
    UpdateComponent,
    FooterComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    NgxGalleryModule,
    ReactiveFormsModule
  ],
  providers: [CarService,
    AuthGuardService,
    UserService,
    AuthService,
    {
      provide:HTTP_INTERCEPTORS,
      useClass:TokenInterceptorService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
