import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DynamicFormComponent } from './Views/dynamic-form.component';
import { DxButtonModule } from 'devextreme-angular';
import { DxTextBoxModule } from 'devextreme-angular';
import { DxCheckBoxModule } from 'devextreme-angular';
import { DxNumberBoxModule } from 'devextreme-angular';
import { DxSelectBoxModule } from 'devextreme-angular';
import { DxDateBoxModule } from 'devextreme-angular';
import { DxDataGridModule } from 'devextreme-angular';


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DxButtonModule,
    DxTextBoxModule,
    DxNumberBoxModule,
    DxCheckBoxModule,
    DxSelectBoxModule,
    DxDateBoxModule,
    DxDataGridModule,
  ],
  declarations: [
    DynamicFormComponent
  ],
  exports: [DynamicFormComponent],
  entryComponents: [DynamicFormComponent]
})
export class DynamicFormModule {
	static dynamicComponentsMap = {
		DynamicFormComponent
	};


}