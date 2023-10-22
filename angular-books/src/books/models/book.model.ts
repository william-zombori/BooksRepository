import { Author } from "./author.model";

export interface Book {
    id: string;
    title: string;
    description: string;
    author: Author;
    image: Blob;
}
