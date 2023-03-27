import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DocumentDefinitionView } from './Views/DocumentDefinitionView';
import { DevExtremeModule } from 'devextreme-angular';
import { AtlasReportModule } from '../Report/AtlasReportModule';
import { AtlasDynamicFormModule } from '../DynamicForm/AtlasDynamicFormModule';

const routes: Routes = [
    {
        path: '',
        component: DocumentDefinitionView,
    },
];

@NgModule({
    declarations: [DocumentDefinitionView],
    imports: [CommonModule, FormsModule, FwModule, DevExtremeModule, AtlasReportModule, AtlasDynamicFormModule,
        RouterModule.forChild(routes)],
    exports: [DocumentDefinitionView],
    entryComponents: [DocumentDefinitionView],
})
export class DocumentDefinitionFormsModule {
	static dynamicComponentsMap = {
		DocumentDefinitionView
	};

}