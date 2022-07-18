import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatTreeModule } from '@angular/material/tree';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { ManufacturingService } from './Services/ManufacturingService';
import { HttpClientModule } from '@angular/common/http';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { ChecklistDatabase, TreeChecklistExample } from './app.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    TreeChecklistExample,
  ],
  imports: [
    BrowserAnimationsModule,
  
    MatTreeModule,
    MatIconModule, 
    MatButtonModule,
    HttpClientModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule
  ],
  
  entryComponents: [TreeChecklistExample],
  providers: [ManufacturingService, ChecklistDatabase],
  bootstrap: [TreeChecklistExample]
})
export class AppModule { }