import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http';
import {Car} from '../Models/Car';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class CarService {


  constructor(private http:HttpClient,private authservice:AuthService) {}

  getAllCars():Observable<Car[]>
  {
    return this.http.get<Car[]>("https://localhost:5001/api/Car");
  }

  getSingleCar(id):Observable<Car>
  {
    return this.http.get<Car>("https://localhost:5001/api/Car/"+id);
  }

  addCar(data:FormData):Observable<any>
  {
    return this.http.post("https://localhost:5001/api/Car/Create",data);
  }

  DeleteCar(id):Observable<any>
  {
    return this.http.delete("https://localhost:5001/api/Car/Delete/"+id);
  }


}
