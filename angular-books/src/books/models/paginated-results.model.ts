export class PaginatedResults<T> {
    constructor() {
        this.records = [];
        this.recordsCount = 0;
    }
    records!: T[];
    recordsCount!: number;
}

export interface PaggingInfo {
    pageNo: number;
    itemsPerPage: number;
}

export interface PaggingInfoExtended extends PaggingInfo {
    sortField?: string;
    sortOrder?: number;
}