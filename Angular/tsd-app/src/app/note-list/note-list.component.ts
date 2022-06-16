import { Component } from '@angular/core';

import { notes } from '../notes';

@Component({
  selector: 'app-note-list',
  templateUrl: './note-list.component.html',
})
export class NotesComponent {
  notes = notes;


}