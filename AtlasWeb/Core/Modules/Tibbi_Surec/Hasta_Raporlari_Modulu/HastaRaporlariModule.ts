//$CE9A048C
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { GlassesReportForm } from './GlassesReportForm';
import { MedulaTedaviRaporlari } from './MedulaTedaviRaporlari';
import { ParticipationFreeDrugReportNewForm } from './ParticipationFreeDrugReportNewForm';
import { StatusNotificationReportForm } from './StatusNotificationReportForm';
import { PatientAdmissionSearchModule } from "Modules/Tibbi_Surec/Kayit_Kabul_Modulu/PatientAdmissionSearch/PatientAdmissionSearchModule";
import { DiagnosisGridReadOnlyModule } from "Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule";
import { ReportDiagnosisModule } from "Modules/Tibbi_Surec/Tani_Modulu/ReportDiagnosisModule";
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { ForensicMedicalReportForm } from './ForensicMedicalReportForm';
import { ProcedureReportForm } from './ProcedureReportForm';
import { ReportApproveForm } from './ReportApproveForm';
import { EDurumBildirirRaporComponent } from './EDurumBildirirRaporComponent';
import { ERaporSorgulaComponent } from './ERaporSorgulaComponent';
import { IndustrialAccidentReportForm } from './IndustrialAccidentReportForm';
import { HastaNakilFormu } from './HastaNakilFormu';
import { DiabetesMellitusForm } from './DiabetesMellitusForm';

const routes: Routes = [
    {
        path: '',
        component: MedulaTedaviRaporlari,
    },
    { path: 'gozrecetesi', component: GlassesReportForm },
    { path: 'tedaviraporu', component: MedulaTedaviRaporlari },
    { path: 'ilacraporu', component: ParticipationFreeDrugReportNewForm },
    { path: 'durumbildirirraporu', component: StatusNotificationReportForm },
    { path: 'adlivakaformu', component: ForensicMedicalReportForm },
    { path: 'doktoronayekrani', component: ReportApproveForm },

];


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, ReportDiagnosisModule, PatientAdmissionSearchModule, DiagnosisGridReadOnlyModule, PatientDemographicsModule, RouterModule.forChild(routes)],
declarations: [
    DiabetesMellitusForm, GlassesReportForm, MedulaTedaviRaporlari, ParticipationFreeDrugReportNewForm, StatusNotificationReportForm, ForensicMedicalReportForm, ProcedureReportForm, ReportApproveForm, EDurumBildirirRaporComponent, ERaporSorgulaComponent, IndustrialAccidentReportForm, HastaNakilFormu
 ],
 exports: [
    DiabetesMellitusForm, GlassesReportForm, MedulaTedaviRaporlari, ParticipationFreeDrugReportNewForm, StatusNotificationReportForm, ForensicMedicalReportForm, ProcedureReportForm, ReportApproveForm, EDurumBildirirRaporComponent, ERaporSorgulaComponent, IndustrialAccidentReportForm, HastaNakilFormu
  ],
entryComponents: [
    DiabetesMellitusForm, GlassesReportForm, MedulaTedaviRaporlari, ParticipationFreeDrugReportNewForm, StatusNotificationReportForm, ForensicMedicalReportForm, ProcedureReportForm, ReportApproveForm, EDurumBildirirRaporComponent, ERaporSorgulaComponent, IndustrialAccidentReportForm, HastaNakilFormu
   ]
})
export class HastaRaporlariModule {
	static dynamicComponentsMap = {
		GlassesReportForm, 
        MedulaTedaviRaporlari, 
        DiabetesMellitusForm,
		ParticipationFreeDrugReportNewForm, 
		StatusNotificationReportForm, 
        ForensicMedicalReportForm,
        ProcedureReportForm,
        ReportApproveForm,
        IndustrialAccidentReportForm,
        HastaNakilFormu
	};
 }

