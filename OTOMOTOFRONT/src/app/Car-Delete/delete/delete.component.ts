import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Car } from 'src/app/Models/Car';
import { CarService } from 'src/app/Services/car.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

CarsList:Car[];
path="/assets/Images/";

  constructor(private CarService:CarService,private route:Router)
  {
  this.CarService.getAllCars().subscribe(
    data=>{this.CarsList=data}
  );
  }

  ngOnInit(): void {

  }

  Delete(id)
  {

  this.CarService.DeleteCar(id).subscribe(
    data=>{this.route.navigate(['/Cars'])}
  );
  }




}
