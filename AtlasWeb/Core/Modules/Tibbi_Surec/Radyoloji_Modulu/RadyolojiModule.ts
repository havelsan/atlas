//$2AE586D9
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { RadiologyTestApproveForm } from './RadiologyTestApproveForm';
import { RadiologyTestRejectForm } from './RadiologyTestRejectForm';
import { RadiologyTestProcedureForm } from './RadiologyTestProcedureForm';
import { RadiologyTestDentalToothSchema } from './RadiologyTestDentalToothSchema';
import { RadiologyTestAppointmentForm } from "./RadiologyTestAppointmentForm";
import { RadiologyTestCompletedForm } from './RadiologyTestCompletedForm';
import { RadiologyTestRequestAcceptionForm } from './RadiologyTestRequestAcceptionForm';
import { RadiologyTestResultEntryForm } from './RadiologyTestResultEntryForm';
import { RadiologyTestCokluOzelDurum } from './RadiologyTestCokluOzelDurum';
import { RadiologyTestBaseForm } from './RadiologyTestBaseForm';
import { RadiologyRequestForm } from './RadiologyRequestForm';
import { RadiologyRejectForm } from './RadiologyRejectForm';
import { RadiologyRequestInfoForm } from "./RadiologyRequestInfoForm";
import { RadiologyProcedureForm } from './RadiologyProcedureForm';
import { RadiologyCompletedForm } from './RadiologyCompletedForm';
import { RadiologyRequestDentalToothSchema } from './RadiologyRequestDentalToothSchema';
import { RadiologyDentalToothSchema } from './RadiologyDentalToothSchema';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { RadiologyTestCancelForm } from './RadiologyTestCancelForm';
import { PatientAllRadiologyTestResultsForm } from './PatientAllRadiologyTestResultsForm';
import { RadiologyTestAdditionalReportForm } from './RadiologyTestAdditionalReportForm';
import { AllPathologyReportsForm } from 'Modules/Tibbi_Surec/Patoloji_Modulu/AllPathologyReportsForm'; 
import { RadiologyTemplateForm } from './RadiologyTemplateForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule,  DiagnosisGridReadOnlyModule, TreatmentMaterialModule],
declarations: [
RadiologyTestApproveForm, RadiologyTestRejectForm, RadiologyTestProcedureForm, RadiologyTestDentalToothSchema,
RadiologyTestAppointmentForm,
RadiologyTestCompletedForm, RadiologyTestRequestAcceptionForm,
RadiologyTestResultEntryForm, RadiologyTestCokluOzelDurum, RadiologyTestBaseForm, RadiologyRequestForm,
    RadiologyRejectForm, RadiologyProcedureForm, RadiologyProcedureForm, RadiologyCompletedForm, RadiologyRequestInfoForm,
    RadiologyRequestDentalToothSchema, RadiologyDentalToothSchema,
    RadiologyTestCancelForm,
    PatientAllRadiologyTestResultsForm, RadiologyTestAdditionalReportForm, AllPathologyReportsForm, RadiologyTemplateForm
 ],
 exports: [
 RadiologyTestApproveForm, RadiologyTestRejectForm, RadiologyTestProcedureForm, RadiologyTestDentalToothSchema,
 RadiologyTestAppointmentForm,
 RadiologyTestCompletedForm, RadiologyTestRequestAcceptionForm,
 RadiologyTestResultEntryForm, RadiologyTestCokluOzelDurum, RadiologyTestBaseForm, RadiologyRequestForm,
	 RadiologyRejectForm, RadiologyProcedureForm, RadiologyProcedureForm, RadiologyCompletedForm, RadiologyRequestInfoForm,
	 RadiologyRequestDentalToothSchema, RadiologyDentalToothSchema,
	 RadiologyTestCancelForm,
     PatientAllRadiologyTestResultsForm, RadiologyTestAdditionalReportForm, AllPathologyReportsForm, RadiologyTemplateForm
  ],
  entryComponents: [
  RadiologyTestApproveForm, RadiologyTestRejectForm, RadiologyTestProcedureForm, RadiologyTestDentalToothSchema,
  RadiologyTestAppointmentForm,
  RadiologyTestCompletedForm, RadiologyTestRequestAcceptionForm,
  RadiologyTestResultEntryForm, RadiologyTestCokluOzelDurum, RadiologyTestBaseForm, RadiologyRequestForm,
	  RadiologyRejectForm, RadiologyProcedureForm, RadiologyProcedureForm, RadiologyCompletedForm, RadiologyRequestInfoForm,
	  RadiologyRequestDentalToothSchema, RadiologyDentalToothSchema,
	  RadiologyTestCancelForm,
      PatientAllRadiologyTestResultsForm, RadiologyTestAdditionalReportForm, AllPathologyReportsForm, RadiologyTemplateForm
   ]
})
export class RadyolojiModule {
	static dynamicComponentsMap = {
		RadiologyTestApproveForm, 
		RadiologyTestRejectForm, 
		RadiologyTestProcedureForm, 
		RadiologyTestDentalToothSchema, 
		RadiologyTestAppointmentForm, 
		RadiologyTestCompletedForm, 
		RadiologyTestRequestAcceptionForm, 
		RadiologyTestResultEntryForm, 
		RadiologyTestCokluOzelDurum, 
		RadiologyTestBaseForm, 
		RadiologyRequestForm, 
		RadiologyRejectForm, 
		RadiologyProcedureForm, 
		RadiologyCompletedForm, 
		RadiologyRequestInfoForm, 
		RadiologyRequestDentalToothSchema, 
		RadiologyDentalToothSchema, 
		RadiologyTestCancelForm, 
		PatientAllRadiologyTestResultsForm, 
        RadiologyTestAdditionalReportForm,
        AllPathologyReportsForm,
        RadiologyTemplateForm
	};
 }

