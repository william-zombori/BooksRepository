import { Component, ViewChild } from '@angular/core';
import { AddAuthorDialogComponent } from './add-author-dialog/add-author-dialog.component';
import { PaggingInfoExtended } from 'src/books/models/paginated-results.model';
import { Author } from 'src/books/models/author.model';
import { BooksFilterDto } from 'src/books/models/book.model';

@Component({
	selector: 'app-books-list',
	templateUrl: './books-list.component.html',
	styleUrls: ['./books-list.component.scss']
})
export class BooksListComponent {
	@ViewChild('ad', { static: false }) newAuthorDialogue: AddAuthorDialogComponent;

	public dataKey = "id";
	public records: any[] = [];
	public loading = false;
	public totalRecords = 0;
	public rowsPerPageOptions = [5, 10, 25, 50, 100];
	public defaultRequest: PaggingInfoExtended;	// ToDo.........
	public authors: Author[] = [];
	public booksFilter: BooksFilterDto;


	public async getData(): Promise<void> {

	}

	public openNewAuthorDialog() {
		this.newAuthorDialogue.showDialog();
	}

	public filterChanged() {

	}
}
