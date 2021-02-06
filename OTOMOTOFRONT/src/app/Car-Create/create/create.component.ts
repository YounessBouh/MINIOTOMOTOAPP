import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CarService } from 'src/app/Services/car.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  CreateForm:FormGroup;
  CreateForm2:FormGroup;
  SingleFile:File=null;
  MultiFile:File[]=null;
  myFiles:File[]=[];

  fileToUpload: File = null;
  filesToUpload: File = null;
  fileName:string='';
  fileName2:string='';
  filesName:string[]=[];

  constructor(private fb:FormBuilder,private Carservice:CarService,private route:Router) {


  this.CreateForm=this.fb.group({
    'Brand':[''],
    'Model':[''],
    'Year':[''],
    'MileAge':[''],
    'Price':[''],
    'Description':[''],
    'PicURL':[''],
    'GearBox':[''],
    'State':[''],
    'Color':[''],
    'Doors':[''],
    'Logo':['']
  });

   }

  ngOnInit(): void {
  }
  Create()
  {
    if(this.filesName.length!=4 && this.fileName.length!=0)
    {
      return console.log("you should upload one Picture and 4 Pictures for Other Pictures");
    }
    else
    {
      this.CreateForm.patchValue({PicURL:this.fileName});

     for(let i=0;i<this.filesName.length;i++)
     {
       this.Pictures.push(new FormControl(this.filesName[i]));
     }
    }
  }


  onFileSelected(event)
  {
    this.SingleFile=<File>event.target.files[0];
  }

  onFilesSelected(event)
  {
    for (var i = 0; i < event.target.files.length; i++) {
      this.myFiles.push(event.target.files[i]);
     }

  }

Create2()
{
 const formData= new FormData();
   formData.append('PicURL',this.SingleFile);
   formData.append('Brand',this.Brand.value);
   formData.append('Model',this.Model.value);
   formData.append('Year',this.Year.value);
   formData.append('MileAge',this.MileAge.value);
   formData.append('Price',this.Price.value);
   formData.append('Description',this.Description.value);
   formData.append('GearBox',this.GearBox.value);
   formData.append('State',this.State.value);
   formData.append('Color',this.Color.value);
   formData.append('Doors',this.Doors.value);
   formData.append('Logo',this.Logo.value);

   for (let i = 0; i < this.myFiles.length; i++) {
     console.log(i);
     formData.append("Pictures", this.myFiles[i]);

    }

    this.Carservice.addCar(formData).subscribe(
      data=>{this.route.navigate(['/Cars'])}
    )

}

  get Brand()
 {
   return this.CreateForm.get('Brand');
 }
 get Model()
 {
   return this.CreateForm.get('Model');
 }
 get Year()
 {
   return this.CreateForm.get('Year');
 }
 get MileAge()
 {
   return this.CreateForm.get('MileAge');
 }
 get Price()
 {
   return this.CreateForm.get('Price');
 }
 get Description()
 {
   return this.CreateForm.get('Description');
 }
 get PicURL()
 {
   return this.CreateForm.get('PicURL');
 }
 get GearBox()
 {
   return this.CreateForm.get('GearBox');
 }
 get State()
 {
   return this.CreateForm.get('State');
 }
 get Color()
 {
   return this.CreateForm.get('Color');
 }
 get Doors()
 {
   return this.CreateForm.get('Doors');
 }
 get Logo()
 {
   return this.CreateForm.get('Logo');
 }

 get Pictures()
 {
   return this.CreateForm.get('Pictures') as FormArray;
 }



}
