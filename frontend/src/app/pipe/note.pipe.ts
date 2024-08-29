import { Pipe, PipeTransform } from '@angular/core';
import { NoteModel } from '../models/note.model';

@Pipe({
  name: 'note',
  standalone: true
})
export class NotePipe implements PipeTransform {

  transform(value: NoteModel[], searchNote: string): NoteModel[] {
    if (!searchNote || searchNote.trim() === '') {
      return value;
    }
    return value.filter(x => x.title.toLocaleLowerCase().includes(searchNote.toLocaleLowerCase()));
  }
}
