import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { QueryListModule } from '../QueryList/query-list.module';
import { DevExtremeModule } from 'devextreme-angular';
import { FormEditorComponent } from './Views/form-editor.component';

const routesFormEditorModule: Routes = [
    {
        path: 'f',
        component: FormEditorComponent
    }
];

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule,
       QueryListModule, RouterModule.forChild(routesFormEditorModule)],
    declarations: [FormEditorComponent],
    exports: [FormEditorComponent],
    entryComponents: [FormEditorComponent]
})
export class FormEditorModule { 
	static dynamicComponentsMap = {
		FormEditorComponent, 
		RouterModule
	};
}
