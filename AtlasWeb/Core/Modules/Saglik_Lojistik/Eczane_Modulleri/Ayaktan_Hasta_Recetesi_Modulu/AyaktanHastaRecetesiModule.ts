//$78DEDD45
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { OutPatientPresDetailForm } from './OutPatientPresDetailForm';
import { OutPatientPrescriptionApprovalForm } from './OutPatientPrescriptionApprovalForm';
import { OutPatientPrescriptionBaseForm } from './OutPatientPrescriptionBaseForm';
import { OutPatientPrescriptionForm } from './OutPatientPrescriptionForm';
import { OutPatientPrescriptionThirdForm } from './OutPatientPrescriptionThirdForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';

const routes: Routes = [
    {
        path: '',
        component: OutPatientPresDetailForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule,
                RouterModule.forChild(routes)],
declarations: [
OutPatientPresDetailForm, OutPatientPrescriptionApprovalForm, OutPatientPrescriptionBaseForm,
OutPatientPrescriptionForm, OutPatientPrescriptionThirdForm
 ],
exports: [
OutPatientPresDetailForm, OutPatientPrescriptionApprovalForm, OutPatientPrescriptionBaseForm,
OutPatientPrescriptionForm, OutPatientPrescriptionThirdForm
 ],
 entryComponents: [
	OutPatientPresDetailForm, OutPatientPrescriptionApprovalForm, OutPatientPrescriptionBaseForm,
	OutPatientPrescriptionForm, OutPatientPrescriptionThirdForm
	 ]
	
})
export class AyaktanHastaRecetesiModule {
	static dynamicComponentsMap = {
		OutPatientPresDetailForm, 
		OutPatientPrescriptionApprovalForm, 
		OutPatientPrescriptionBaseForm, 
		OutPatientPrescriptionForm, 
		OutPatientPrescriptionThirdForm
	};
 }

