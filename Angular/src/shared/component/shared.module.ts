import { NgModule }       from '@angular/core';
import { CommonModule }   from '@angular/common';
import { FormsModule }    from '@angular/forms';
import { CustomNotifier } from './notifier/notifier.component';
import { MatInputCommifiedDirective } from '@shared/directives/mat-input-conmmified';
import { ImageUploadComponent } from './image-upload/image-upload.component';
import { MatButtonModule } from '@angular/material/button';
import { MoneyFormatPipe } from '@shared/pipe/money-format.pipe';
import { DateTimeFormatPipe } from '@shared/pipe/date-time-format.pipe';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule
  ],
  declarations: [
    CustomNotifier,
    MatInputCommifiedDirective,
    ImageUploadComponent,
    MoneyFormatPipe,
    DateTimeFormatPipe
  ],
  exports:[
    CustomNotifier,
    MatInputCommifiedDirective,
    ImageUploadComponent,
    MoneyFormatPipe,
    DateTimeFormatPipe,
    CommonModule,
    FormsModule,
  ],
  providers: [
    
  ]
})
export class SharedModule { }
