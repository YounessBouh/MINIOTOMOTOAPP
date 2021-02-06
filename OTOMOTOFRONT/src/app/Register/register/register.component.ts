import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user:any={};
  constructor(private userService:UserService,private authservice: AuthService,private route:Router) { }

  ngOnInit(): void {
  }

  Register(RegisterForm:NgForm)
  {
    console.log(RegisterForm.value);
    this.authservice.register(RegisterForm.value).subscribe(
      data=>{this.route.navigate(['/Login'])}
    )
   // RegisterForm.reset();
  }

}
