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
