import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book, BooksFilterDto, PaginatedResults } from '../models/book.model';

@Injectable({
	providedIn: 'root'
})
export class BooksService {
	readonly apiUrl = 'http://localhost:5177/api/';

	constructor(private httpClient: HttpClient) { }

	public addBook(book: Book): Promise<any> {
		return this.httpClient.put<any>(this.apiUrl + 'books', book).toPromise();
	}

	public getBook(id: string): Promise<Book> {
		return this.httpClient.get<Book>(this.apiUrl + 'books', { params: { 'id': id } as any }).toPromise();
	}

	public updateBook(book: Book): Promise<any> {
		return this.httpClient.post<any>(this.apiUrl + 'books', book).toPromise();
	}

	public deleteBook(book: Book): Promise<any> {
		return this.httpClient.delete<any>(this.apiUrl + 'books', { body: book }).toPromise();
	}

	public getBooks(filter: BooksFilterDto): Promise<PaginatedResults<Book[]>> {
		return this.httpClient.get<PaginatedResults<Book[]>>(this.apiUrl + 'books', { params: { 'filter': filter } as any }).toPromise();
	}
}
