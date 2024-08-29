export class NoteModel {
    id: string;
    title: string;
    description: string;
    priority: string;
    categoryId: string;

    // Parametresiz constructor
    constructor() {
        this.id = '';
        this.title = '';
        this.description = '';
        this.priority = '';
        this.categoryId = '';
    }

}

