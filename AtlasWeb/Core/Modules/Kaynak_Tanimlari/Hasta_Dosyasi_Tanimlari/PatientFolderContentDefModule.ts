
import { DxReportDesignerModule } from 'devexpress-reporting-angular';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientFolderContentDefForm} from './PatientFolderContentDefForm';

const paths: Routes = [
    {
        path: '',
        component: PatientFolderContentDefForm
    }
];

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule, DxReportDesignerModule, RouterModule.forChild(paths)],
    declarations: [PatientFolderContentDefForm],
    exports: [],
    entryComponents: [PatientFolderContentDefForm]
})
export class PatientFolderContentDefModule { 
	static dynamicComponentsMap = {
        PatientFolderContentDefForm
	};
}