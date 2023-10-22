import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksListComponent } from './components/books-list/books-list.component';
import { AddAuthorDialogComponent } from './components/books-list/add-author-dialog/add-author-dialog.component';
import { DialogModule } from 'primeng/dialog';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { FormsModule } from '@angular/forms';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { MessageService } from 'primeng/api';


@NgModule({
  declarations: [
    BooksListComponent,
    AddAuthorDialogComponent
  ],
  imports: [
    CommonModule,
    DialogModule,
    InputTextareaModule,
    FormsModule,
    ProgressSpinnerModule
  ],
  providers: [
    MessageService
  ]
})
export class BooksModule { }
