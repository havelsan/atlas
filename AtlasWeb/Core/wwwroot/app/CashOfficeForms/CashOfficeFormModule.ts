import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { CashOfficePatientForm } from '../CashOfficePatient/CashOfficePatientForm';
import { CashOfficeWorkListForm } from '../CashOfficeWorkList/CashOfficeWorkListForm';
import { CashOfficeFormView } from './CashOfficeFormView';
import { ObjectStateHelper } from '../Helper/ObjectStateHelper';
import { DefinitionService } from 'Fw/Services/DefinitionService';
import { MessageService } from 'Fw/Services/MessageService';
import { AtlasReportModule } from '../Report/AtlasReportModule';
import { CashOfficeFormsService } from './CashOfficeFormsService';

const routes: Routes = [
    {
        path: '',
        component: CashOfficeFormView,
    },
];

@NgModule({
    declarations: [CashOfficePatientForm, CashOfficeWorkListForm, CashOfficeFormView],
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule, AtlasReportModule,
        RouterModule.forChild(routes)],
    providers: [ObjectStateHelper, MessageService, DefinitionService,CashOfficeFormsService],
    exports: []
})
export class CashOfficeFormModule {
	static dynamicComponentsMap = {

	};


}