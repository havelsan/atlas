
import { DxReportDesignerModule } from 'devexpress-reporting-angular';
import { ArchiveRoomsDefForm } from './ArchiveRoomsDefForm';
import {CabinetDefinitionForm} from './CabinetDefinitionForm';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';


const paths: Routes = [
    {
        path: '',
        component: ArchiveRoomsDefForm
    }
];

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule, DxReportDesignerModule, RouterModule.forChild(paths)],
    declarations: [ArchiveRoomsDefForm, CabinetDefinitionForm],
    exports: [CabinetDefinitionForm],
    entryComponents: [ArchiveRoomsDefForm]
})
export class ArchiveDefinitionModule { 
	static dynamicComponentsMap = {
        ArchiveRoomsDefForm,
        CabinetDefinitionForm
        
	};
}
