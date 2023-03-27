//$E5373EA0
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MedicalStuffPrescriptionForm } from './MedicalStuffPrescriptionForm';
import { MedicalStuffReportForm } from './MedicalStuffReportForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { ReportDiagnosisModule } from "Modules/Tibbi_Surec/Tani_Modulu/ReportDiagnosisModule";
import { DiagnosisGridReadOnlyModule } from "Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule";

const routes: Routes = [
    {
        path: '',
        component: MedicalStuffPrescriptionForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, ReportDiagnosisModule, DiagnosisGridReadOnlyModule,
                RouterModule.forChild(routes)],
declarations: [
MedicalStuffPrescriptionForm, MedicalStuffReportForm
 ],
 exports: [
 MedicalStuffPrescriptionForm, MedicalStuffReportForm
  ],
  entryComponents: [
  MedicalStuffPrescriptionForm, MedicalStuffReportForm
   ]
})
export class TibbiMalzemeModule {
	static dynamicComponentsMap = {
		MedicalStuffPrescriptionForm, 
		MedicalStuffReportForm
	};
 }

