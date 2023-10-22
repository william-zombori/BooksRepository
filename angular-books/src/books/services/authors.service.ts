import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Author } from '../models/author.model';

@Injectable({
	providedIn: 'root'
})
export class AuthorsService {

	constructor(private httpClient: HttpClient) { }

	public refreshAuthors = false;

	private _authors: Promise<Author[]>;
	get authors(): Promise<Author[]> {
		if (!this._authors || this.refreshAuthors) {
			this._authors = this.getAuthors();
			this.refreshAuthors = false;
		}

		return this._authors;
	}

	public getAuthors(): Promise<Author[]> {
		return this.httpClient.get<Author[]>(`/api/Authors`).toPromise();
	}

	public addAuthor(author: Author): Promise<any> {
		return this.httpClient.put<any>(`/api/eventIndicators/PutEventIndicatorOutlookText`, author).toPromise();
	}
}
