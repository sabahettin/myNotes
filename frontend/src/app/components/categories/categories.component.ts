import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { RouterLink } from '@angular/router';
import { HttpService } from '../../services/http.service';
import { CategoryModel } from '../../models/category.model';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { SwalService } from '../../services/swal.service';
import { CategoryPipe } from '../../pipe/category.pipe';

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule, FormValidateDirective, CategoryPipe],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css'
})
export class CategoriesComponent implements OnInit {

  categories : CategoryModel[] = [];
  categoryModel : CategoryModel = new CategoryModel();
  search : string ="";
  isAddBtnVisible: any;
  isUpdateBtnVisible: any;
  isCancelBtnVisible: any;

    constructor(
      private http : HttpService,
      private swal: SwalService
    ){}

  ngOnInit(): void {
    this.getAll();
    // this.swal.callSwal("Title", "text",()=>{
    //   alert("Delete is successful");
    // });
  }

    getAll(){
      this.http.post<CategoryModel[]>("Categories/GetAll", {}, (res)=>{
        this.categories = res.data;
        this.isAddBtnVisible = true;
        this.isUpdateBtnVisible = false;
        this.isCancelBtnVisible = false;
      });
    }
    add(form:NgForm){
      if(form.valid){
        this.http.post<string>("Categories/Create",this.categoryModel,(res)=>{
          this.swal.callToast(res.data, "success");
          const categoryNameInput = document.getElementById("categoryNameInput") as HTMLInputElement | null;
      
          if (categoryNameInput) {
            categoryNameInput.value = "";
          }
          this.getAll();
          this.categoryModel = new CategoryModel();
        })
      }
    }
    delete(id:string, categoryName:string){
      this.swal.callSwal("Delete Category?",`Do you want to delete ${categoryName}?,` ,()=>{
        this.http.post<string>("Categories/DeleteById", {id:id}, (res)=>{
            this.swal.callToast(res.data,"info");
            this.getAll();
        })
      })
    }
    get(data:CategoryModel){
      this.categoryModel = {...data};
      this.isAddBtnVisible = false;
      this.isUpdateBtnVisible = true;
      this.isCancelBtnVisible = true;
    }
    update(form:NgForm){
      if(form.valid){
        this.http.post<string>("Categories/Update",this.categoryModel,(res)=>{
          this.swal.callToast(res.data, "success");
          const categoryNameInput = document.getElementById("categoryNameInput") as HTMLInputElement | null;
      
          if (categoryNameInput) {
            categoryNameInput.value = "";
          }
          this.getAll();
          this.categoryModel = new CategoryModel();
        })
      }
    }
    cancel(){
      this.isAddBtnVisible = true;
      this.isUpdateBtnVisible = false;
      this.isCancelBtnVisible = false;
      const categoryNameInput = document.getElementById("categoryNameInput") as HTMLInputElement | null;
      if (categoryNameInput) {
        categoryNameInput.value = "";
      }
    }
}
