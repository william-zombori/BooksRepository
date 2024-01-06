import { Author } from "./author.model";
import { Cover } from "./cover.model";

export interface Book {
    id: string;
    title: string;
    description: string;
    author: Author;
    cover: Cover;
    isCoverImageChanged: boolean;
}

export interface BooksFilterDto {
    title: string;
    description: string;
    authorIds: string[];
    skipNrOfElements: number;
    takeNrOfElements: number;
}

export declare class PaginatedResults<T> {
    constructor();
    records: T[];
    recordsCount: number;
}
