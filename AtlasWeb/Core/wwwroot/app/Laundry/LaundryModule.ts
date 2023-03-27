import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule, DxPieChartModule } from 'devextreme-angular';
import { LaundryMainForm } from './LaundryMainForm';
import { LaundryDefinitionForm } from './LaundryDefinitionForm';
import { LaundryStatusForm } from './LaundryStatusForm';
import { BedCleaningForm } from './BedCleaningForm';

const routes: Routes = [
    {
        path: '',
        component: LaundryMainForm
    }
];

@NgModule({
    declarations: [LaundryMainForm, LaundryDefinitionForm, LaundryStatusForm, BedCleaningForm],
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule, RouterModule.forChild(routes), DxPieChartModule]
    //,providers: [GetMedulaDefinitionService]
})
export class LaundryModule {
	static dynamicComponentsMap = {

	};

}