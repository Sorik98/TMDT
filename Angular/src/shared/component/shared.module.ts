import { NgModule }       from '@angular/core';
import { CommonModule }   from '@angular/common';
import { FormsModule }    from '@angular/forms';
import { CustomNotifier } from './notifier/notifier.component';
import { MatInputCommifiedDirective } from '@shared/directives/mat-input-conmmified';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule
  ],
  declarations: [
    CustomNotifier,
    MatInputCommifiedDirective,
    ImageUploadComponent
  ],
  exports:[
    CustomNotifier,
    MatInputCommifiedDirective,
    ImageUploadComponent,
    CommonModule,
    FormsModule,
  ],
  providers: [
    
  ]
})
export class SharedModule { }
