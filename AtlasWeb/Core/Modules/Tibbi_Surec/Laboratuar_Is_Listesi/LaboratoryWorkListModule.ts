//$FDB182A0
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { LaboratoryRequestMainForm } from './LaboratoryRequestMainForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { PatientSearchModule } from '../PatientSearch/PatientSearchModule';
import { LaboratoryRequestSampleWorkListForm } from './LaboratoryRequestSampleWorkListForm';
import { LaboratoryMainWorkListForm } from './LaboratoryMainWorkListForm';
import { LaboratoryRequestSampleAcceptionForm } from './LaboratoryRequestSampleAcceptionForm';
import { LaboratoryMainForm } from './LaboratoryMainForm';
import { LaboratoryMainProcedureFlowsForm } from './LaboratoryMainProcedureFlowsForm';
import { LaboratorySampleAcceptBarcodeForm } from './LaboratorySampleAcceptBarcodeForm';

const routes: Routes = [
    {
        path: '',
        component: LaboratoryRequestMainForm,
    },

    { path: 'numunealma', component: LaboratoryRequestMainForm },
    { path: 'islistesi', component: LaboratoryMainForm },
    { path: 'barkodEkrani', component: LaboratorySampleAcceptBarcodeForm }
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule,
        DevExtremeModule, FwModule, PatientDemographicsModule, PatientSearchModule,
     RouterModule.forChild(routes)],
    declarations: [LaboratoryRequestMainForm, LaboratoryRequestSampleAcceptionForm, LaboratoryRequestSampleWorkListForm, LaboratoryMainWorkListForm, LaboratoryMainForm, LaboratoryMainProcedureFlowsForm, LaboratorySampleAcceptBarcodeForm ],
    exports: [LaboratoryRequestMainForm, LaboratoryRequestSampleAcceptionForm, LaboratoryRequestSampleWorkListForm, LaboratoryMainWorkListForm, LaboratoryMainForm, LaboratoryMainProcedureFlowsForm, LaboratorySampleAcceptBarcodeForm ],
    entryComponents: [LaboratoryRequestMainForm, LaboratoryRequestSampleAcceptionForm, LaboratoryRequestSampleWorkListForm, LaboratoryMainWorkListForm, LaboratoryMainForm, LaboratoryMainProcedureFlowsForm, LaboratorySampleAcceptBarcodeForm ]
})
export class LaboratoryWorkListModule {
	static dynamicComponentsMap = {
		LaboratoryRequestMainForm, 
		LaboratoryRequestSampleAcceptionForm, 
		LaboratoryRequestSampleWorkListForm, 
		LaboratoryMainWorkListForm, 
		LaboratoryMainForm, 
        LaboratoryMainProcedureFlowsForm,
        LaboratorySampleAcceptBarcodeForm
	};

}