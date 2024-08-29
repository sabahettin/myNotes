import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { FormValidateDirective } from 'form-validate-angular';
import { HttpService } from '../../services/http.service';
import { SwalService } from '../../services/swal.service';
import { CategoryModel } from '../../models/category.model';
import { CategoryPipe } from "../../pipe/category.pipe";
import {AngularEditorModule} from '@kolkov/angular-editor';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { NoteModel } from '../../models/note.model';
import { NotePipe } from '../../pipe/note.pipe';


@Component({
  selector: 'app-notes',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule, FormValidateDirective, CategoryPipe, AngularEditorModule, NotePipe],
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})

export class NotesComponent implements OnInit {

  config : AngularEditorConfig = {
    editable : true,
    spellcheck : true,
    height: '10rem',
    minHeight : '5rem',
    placeholder : 'Enter Note Here..',
    translate : 'no',
    defaultParagraphSeparator : 'p',
    defaultFontName : 'Arial',
    
  }

  notes: NoteModel[] = [];
  noteModel: NoteModel = new NoteModel();
  categories: CategoryModel[] = [];
  searchNote : string ="";
  search : string ="";
  isUpdateMode: boolean = false;

  constructor(
    private http: HttpService,
    private swal: SwalService
  ) {}

  ngOnInit(): void {
    this.getCategories();
  }

  // READ
  getAll() {
    this.http.post<NoteModel[]>("Notes/GetAll", {}, (res) => {
      this.notes = res.data;
      //this.resetForm();
    });
  }

  getByCategoryId(categoryId: any) {
    this.http.post<NoteModel[]>("Notes/GetByCategoryId", { categoryId: categoryId }, (res) => {
      this.notes = res.data;
      //this.resetForm();
    });
  }
  selectCategory(categoryId: string) {
    //this.noteModel.categoryId = categoryId;
    this.isUpdateMode = false; // Yeni not oluşturmak için güncelleme modundan çık
    this.getByCategoryId(categoryId);
  }
  getCategories() {
    this.http.post<CategoryModel[]>("Categories/GetAll", {}, (res) => {
      this.categories = res.data;
    });
  }

  selectNote(noteId: string) {
    this.isUpdateMode = true;  
    // Seçilen noteId'yi kullanarak notu bulup noteModel'e atama yapıyoruz
    this.http.post<NoteModel>("Notes/GetById", { id: noteId }, (res) => {
        this.noteModel = res.data; // Gelen veriyi noteModel'e atıyoruz
    });
}
// ADD,UPDATE,DELETE
  onSubmit(form: NgForm) {
    if (form.valid) {
      if (this.isUpdateMode) {
        this.updateNote();
      } else {
        this.addNote();
      }
      //this.resetForm(form);
    } else {
      this.swal.callToast("Please fill all the required fields.", "error");
    }
  }

  addNote() {
    this.http.post<string>("Notes/Create", this.noteModel, (res) => {
      this.swal.callToast(res.data, "success");
      this.getByCategoryId(this.noteModel.categoryId);

      this.noteModel = new NoteModel(); // Modeli sıfırlar
      this.isUpdateMode = false; // Update modunu sıfırlar
      
    }, (error) => {
      console.error("Error during addNote:", error);
    });
  }   

  updateNote() {
    this.http.post<string>("Notes/Update", this.noteModel, (res) => {
      this.swal.callToast(res.data, "success");
      this.getByCategoryId(this.noteModel.categoryId);
      this.noteModel = new NoteModel(); // Modeli sıfırlar
      this.isUpdateMode = false; // Update modunu sıfırlar
      this.isUpdateMode = false;
    });
  }

  deleteNote(noteId: string, categoryId :string) {
      this.swal.callSwal("Delete Note?",`Do you want to delete this note?,` ,()=>{
        this.http.post<string>("Notes/Delete", {id:noteId}, (res)=>{
            this.swal.callToast(res.data,"info");
            this.getByCategoryId(categoryId);
            this.isUpdateMode = false;
        })
    });
  }


// METHODYS
  cancel(form?: NgForm) {
    if (form) {
        form.resetForm(); // Formu sıfırlar
    }
    this.noteModel = new NoteModel(); // noteModel'i sıfırla
    this.isUpdateMode = false; // Update modunu kapat
}

  trackByFn(index: number, item: any): any {
    return item.id;
  }
  resetForm(form: NgForm) {
    form.resetForm(); // Formu resetler
    this.noteModel = new NoteModel(); // Modeli sıfırlar
    this.isUpdateMode = false; // Update modunu sıfırlar
  }
}
