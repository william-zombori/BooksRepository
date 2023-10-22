import { Component, ViewChild } from '@angular/core';
import { AddAuthorDialogComponent } from './add-author-dialog/add-author-dialog.component';

@Component({
	selector: 'app-books-list',
	templateUrl: './books-list.component.html',
	styleUrls: ['./books-list.component.scss']
})
export class BooksListComponent {
	@ViewChild('ad', { static: false }) newAuthorDialogue: AddAuthorDialogComponent;

	public async getData(): Promise<void> {

	}

	public openNewAuthorDialog() {
		this.newAuthorDialogue.showDialog();
	}
}
