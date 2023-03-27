
import { DxReportDesignerModule } from 'devexpress-reporting-angular';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import {MedicalWasteContainerDefForm} from './MedicalWasteContainerDefForm';

const paths: Routes = [
    {
        path: '',
        component: MedicalWasteContainerDefForm
    }
];

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule, DxReportDesignerModule, RouterModule.forChild(paths)],
    declarations: [MedicalWasteContainerDefForm],
    exports: [],
    entryComponents: [MedicalWasteContainerDefForm]
})
export class MedicalWasteDefinitionModule { 
	static dynamicComponentsMap = {
        MedicalWasteContainerDefForm
	};
}