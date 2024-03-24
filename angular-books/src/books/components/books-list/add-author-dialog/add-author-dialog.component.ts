import { Component, EventEmitter, Output } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Author } from 'src/books/models/author.model';
import { AuthorsService } from 'src/books/services/authors.service';

@Component({
	selector: 'app-add-author-dialog',
	templateUrl: './add-author-dialog.component.html',
	styleUrls: ['./add-author-dialog.component.scss']
})

export class AddAuthorDialogComponent {
	@Output() refreshData = new EventEmitter<void>();

	public dialogVisible = false;
	isSaving = false;
	name: string;

	constructor(private authorsService: AuthorsService,
		private messageService: MessageService) { }

	public showDialog(): void {
		this.dialogVisible = true;
	}

	public hideDialog(): void {
		this.dialogVisible = false;
	}

	cancel(): void {
		this.name = "";

		this.hideDialog();
	}

	async save(): Promise<void> {
		this.isSaving = true;

		var author = {} as Author;
		author.name = this.name;

		try {
			await this.authorsService.addAuthor(author);

			this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Data saved successfully.' });
			this.refreshData.emit();
		}
		catch (error) {
			this.messageService.add({ severity: 'error', summary: 'Error', detail: "An error occurred while adding Author." });
		}
		finally {
			this.isSaving = false;
			this.hideDialog();
		}
	}
}
