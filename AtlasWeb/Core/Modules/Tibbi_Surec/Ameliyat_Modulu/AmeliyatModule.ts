//$077F7B7E
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SurgeryRequestForm } from './SurgeryRequestForm';
import { SurgeryExtensionForm } from './SurgeryExtensionForm';
import { SurgeryForm } from './SurgeryForm';
import { SubSurgeryForm } from './SubSurgeryForm';
import { SurgeryProcedureForm } from './SurgeryProcedureForm';
import { SurgerySummaryForm } from './SurgerySummaryForm';
import { ProcedureRequestModule } from '../Tetkik_Istem_Modulu/ProcedureRequestModule';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { VitalSingsModule } from 'Modules/Tibbi_Surec/Vital_Bulgular/VitalSingsModule';
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';
import { SurgeryRejectReasonForm } from './SurgeryRejectReasonForm'; 
import { KvcRiskScoreForm } from './KvcRiskScoreForm';
import { SurgeryAppointmentForm } from './SurgeryAppointmentForm';
import { SurgeryAppointmentComponentForm } from './SurgeryAppointmentComponentForm';
import { PatientSearchModule } from '../PatientSearch/PatientSearchModule';
import { SafeSurgeryCheckListForm } from './SafeSurgeryCheckListForm'; 

const routes: Routes = [
    {
        path: 'ameliyatrandevuekrani',
        component: SurgeryAppointmentComponentForm,
    },
    {
        path: '',
        component: SurgeryRequestForm,
    }

];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
        RouterModule.forChild(routes), PatientDemographicsModule, DiagnosisGridModule, DiagnosisGridReadOnlyModule, PatientHistoryModule, TreatmentMaterialModule,
        VitalSingsModule, ProcedureRequestModule, PatientSearchModule],
declarations: [
    SurgeryRequestForm, SurgeryExtensionForm, SurgeryForm, SubSurgeryForm, SurgeryProcedureForm, SurgerySummaryForm, SurgeryRejectReasonForm, KvcRiskScoreForm, SurgeryAppointmentForm, SurgeryAppointmentComponentForm, SafeSurgeryCheckListForm
],
exports: [
    SurgeryRequestForm, SurgeryExtensionForm, SurgeryForm, SubSurgeryForm, SurgeryProcedureForm, SurgerySummaryForm, SurgeryRejectReasonForm, KvcRiskScoreForm, SurgeryAppointmentForm, SurgeryAppointmentComponentForm,  SafeSurgeryCheckListForm
],
entryComponents: [
    SurgeryRequestForm, SurgeryExtensionForm, SurgeryForm, SubSurgeryForm, SurgeryProcedureForm, SurgerySummaryForm, SurgeryRejectReasonForm, KvcRiskScoreForm, SurgeryAppointmentForm, SurgeryAppointmentComponentForm, SafeSurgeryCheckListForm
]
})

    //, SurgeryPreOpForm,SurgeryExpedForm, SurgeryReportForm, SurgeryControlForm
//SubSurgeryReportForm, SubSurgeryCancelledForm, SubSurgeryExpertForm, SubSurgeryCokluOzelDurumForm,
//EuroScoreOfProcedureForm, SurgeryPersonnelForm, SurgeryCancelledForm,SubSurgeryExpertForm
//SurgeryRequestForm, SurgeryControlForm, SurgeryCompletedForm,
//SurgeryForm, SurgeryPricingForm, IntensiveCareAfterSurgeryProcedureForm, IntensiveCareAfterSurgeryPostOpForm
export class AmeliyatModule {
	static dynamicComponentsMap = {
		SurgeryRequestForm, 
		SurgeryExtensionForm, 
		SurgeryForm, 
		SubSurgeryForm, 
		SurgeryProcedureForm, 
        SurgerySummaryForm,
        SurgeryRejectReasonForm,
        KvcRiskScoreForm,
        SurgeryAppointmentForm,
        SurgeryAppointmentComponentForm,
        SafeSurgeryCheckListForm
	};
 }

