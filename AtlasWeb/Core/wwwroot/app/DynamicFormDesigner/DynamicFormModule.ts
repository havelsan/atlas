import { NgModule, Injector } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DynamicFormComponent } from './Views/dynamic-form.component';
import { DevExtremeModule } from 'devextreme-angular';

import { RouterModule, Routes } from '@angular/router';
import { DynamicFormDesignerComponent } from './Views/dynamic-form-designer.component';
import { FormsModule } from 'app/Formio/forms/forms.module';
import { ODataEditorComponent } from 'app/ODataEditor/Views/odata-editor.component';
import { registerCustomComponent } from 'app/Formio/forms/dynamicgrid/dynamic-grid-formio';
import { DynamicGrid } from 'app/Formio/forms/dynamicgrid/dynamic-grid';
import { HvlDynamicForm } from './Views/HvlDynamicForm';
import { FormioModule } from 'angular-formio';
import { DynamicFormHistory } from './Views/DynamicFormHistory';
import { registerCustomSelectComponent } from 'app/Formio/forms/customcomponents/select/custom-select-formio';
import { CustomSelectComponent } from 'app/Formio/forms/customcomponents/select/custom-select';
import { ImageAnnotationComponent } from 'app/Formio/forms/customcomponents/imageannotation/imageannotation';
import { registerImageAnnotationComponent } from 'app/Formio/forms/customcomponents/imageannotation/imageannotation-formio';
import { FileToBase64 } from 'app/FileToBase64/filetobase64';

const routes: Routes = [
  {
    path: 'designer',
    component: DynamicFormDesignerComponent,
  },
];

@NgModule({
  imports: [CommonModule, FormsModule, DevExtremeModule, ReactiveFormsModule, FormioModule, RouterModule.forChild(routes)],
  declarations: [
    DynamicFormComponent, DynamicFormDesignerComponent, ODataEditorComponent, DynamicGrid, HvlDynamicForm, DynamicFormHistory, CustomSelectComponent, ImageAnnotationComponent, FileToBase64
  ],
  exports: [DynamicFormComponent, DynamicFormDesignerComponent, ODataEditorComponent, DynamicGrid, HvlDynamicForm, DynamicFormHistory, CustomSelectComponent, ImageAnnotationComponent, FileToBase64],
  entryComponents: [ODataEditorComponent, DynamicGrid, HvlDynamicForm, DynamicFormHistory, CustomSelectComponent, ImageAnnotationComponent, FileToBase64]
})
export class DynamicFormModule {
  static dynamicComponentsMap = {
    DynamicFormComponent,
    DynamicFormDesignerComponent,
    DynamicGrid,
    CustomSelectComponent,
    ImageAnnotationComponent,
    HvlDynamicForm,
    DynamicFormHistory,
    ODataEditorComponent,
    FileToBase64
  };

  constructor(injector: Injector) {
    registerCustomComponent(injector);
    registerCustomSelectComponent(injector);
    registerImageAnnotationComponent(injector);

  }

}