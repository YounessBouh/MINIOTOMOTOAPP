import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService:AuthService,private route:Router) { }

  ngOnInit(): void {
  }

  Login(LoginForm:NgForm)
  {

   this.authService.login(LoginForm.value).subscribe(
     data=>{this.authService.saveToken(data['jwtToken']); this.route.navigate(['/Cars'])}
   );

  }

}
