import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cover } from '../models/cover.model';

@Injectable({
	providedIn: 'root'
})
export class CoversService {
	readonly apiUrl = 'http://localhost:5177/api/';

	constructor(private httpClient: HttpClient) { }

	public getCover(id: string): Promise<Cover> {
		return this.httpClient.get<Cover>(this.apiUrl + 'covers', { params: { 'id': id } as any }).toPromise();
	}
}
