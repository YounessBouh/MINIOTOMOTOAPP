import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/Models/Car';
import { CarService } from 'src/app/Services/car.service';

@Component({
  selector: 'app-cars-list',
  templateUrl: './cars-list.component.html',
  styleUrls: ['./cars-list.component.css']
})
export class CarsListComponent implements OnInit {

  CarsList:Car[];
  path="/assets/Images/"
  constructor(private CarService:CarService)
   {
    this.getCars()
   }

  ngOnInit(): void {
  }

  getCars()
  {
    this.CarService.getAllCars().subscribe(
      data=>{this.CarsList=data,console.log(this.CarsList)}
    );
  }

}
