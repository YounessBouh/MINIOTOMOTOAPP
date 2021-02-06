

import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/Models/Car';
import { CarService } from 'src/app/Services/car.service';
import {Component, OnInit} from '@angular/core';
import {NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {NgxGalleryImage} from '@kolkov/ngx-gallery';
import {NgxGalleryAnimation} from '@kolkov/ngx-gallery';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  id;
  SingleCar:Car;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  path="/assets/Images/";


  constructor(private service:CarService,private route:ActivatedRoute)
  {
    this.route.params.subscribe(res =>{this.id=res['id']});
   this.getCar();
  }

  ngOnInit(): void {
    this.galleryOptions = [
      {
        width: '800px',
        height: '500px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      },
    ];

    this.galleryImages = [];
  }

  getCar()
  {
    this.service.getSingleCar(this.id).subscribe(
      data=>{this.SingleCar=data;
        console.log(this.SingleCar);
        for(let x=0;x<this.SingleCar.pictures.length;x++)
        {
          if(this.SingleCar.picURL.includes('https'))
          {
            this.galleryImages[x]={
              small: this.SingleCar.pictures[x],
              medium: this.SingleCar.pictures[x],
              big: this.SingleCar.pictures[x]
             }
          }
          else
          {
            this.galleryImages[x]={
              small:this.path+ this.SingleCar.pictures[x],
              medium: this.path+this.SingleCar.pictures[x],
              big: this.path+this.SingleCar.pictures[x]
             }
          }


        }

      }
    );


  }



}
