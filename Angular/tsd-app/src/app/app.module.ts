import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NotesComponent } from './note-list/note-list.component';

@NgModule({
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: NotesComponent },
    ])
  ],
  declarations: [
    AppComponent,
    NotesComponent
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }