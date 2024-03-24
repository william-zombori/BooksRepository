import { Component, OnInit, ViewChild } from '@angular/core';
import { AddAuthorDialogComponent } from './add-author-dialog/add-author-dialog.component';
import { PaggingInfoExtended, PaginatedResults } from 'src/books/models/paginated-results.model';
import { Author } from 'src/books/models/author.model';
import { Book, BooksFilterDto } from 'src/books/models/book.model';
import { AuthorsService } from 'src/books/services/authors.service';
import { MessageService } from 'primeng/api';
import { BooksService } from 'src/books/services/books.service';
import { Table } from 'primeng/table';

@Component({
	selector: 'app-books-list',
	templateUrl: './books-list.component.html',
	styleUrls: ['./books-list.component.scss']
})
export class BooksListComponent implements OnInit {

	@ViewChild('booksTable', { static: false }) table: Table;
	@ViewChild('ad', { static: false }) newAuthorDialogue: AddAuthorDialogComponent;

	public dataKey = "id";
	public records: any[] = [];
	public loading = false;
	public totalRecords = 0;
	public rowsPerPageOptions = [5, 10, 25, 50, 100];
	public defaultRequest: PaggingInfoExtended = { pageNo: 1, itemsPerPage: 5, sortField: null, sortOrder: null };
	public authors: Author[] = [];
	public booksFilter: BooksFilterDto;
	public serverResponse: PaginatedResults<Book>;

	constructor(private authorsService: AuthorsService,
		private booksService: BooksService,
		private messageService: MessageService) {
	}

	async ngOnInit(): Promise<void> {
		this.booksFilter = {} as BooksFilterDto;
		this.booksFilter.authorIds = [];
		this.booksFilter.description = '';
		this.booksFilter.title = '';

		Promise.all([
			//await this.getAuthors(),
		]);

		await this.getData();
	}

	public async getData(): Promise<void> {
		this.loading = true;

		//ToDo: do first add authors and books to have data in the db....

		this.serverResponse = await this.booksService.getBooks(this.booksFilter);

		this.loading = false;
	}

	public openNewAuthorDialog() {
		this.newAuthorDialogue.showDialog();
	}

	public async filterChanged() {
		await this.getData();
	}

	private async getAuthors(): Promise<void> {
		this.authors = await this.authorsService.getAuthors();
	}
}
