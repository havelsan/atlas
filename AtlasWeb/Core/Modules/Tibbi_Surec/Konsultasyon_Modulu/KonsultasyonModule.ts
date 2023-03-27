//$D9A91C44
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ConsultationDoctorExaminationFormNew } from './ConsultationDoctorExaminationFormNew';
import { AppointmentFormConsultation } from './AppointmentFormConsultation';
import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';
import { ProcedureRequestModule } from '../Tetkik_Istem_Modulu/ProcedureRequestModule';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';
import { ProcedureRequestSharedService } from '../Tetkik_Istem_Modulu/ProcedureRequestSharedService';
import { ConsultationRequestForm } from './ConsultationRequestForm';
import { HastaRaporlariModule } from 'Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule';
@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, DiagnosisGridModule, ProcedureRequestModule, PatientDemographicsModule, TreatmentMaterialModule, PatientHistoryModule, HastaRaporlariModule],
declarations: [ ConsultationDoctorExaminationFormNew, AppointmentFormConsultation, ConsultationRequestForm ],
exports: [ConsultationDoctorExaminationFormNew, AppointmentFormConsultation, ConsultationRequestForm
],
entryComponents: [ConsultationDoctorExaminationFormNew, AppointmentFormConsultation, ConsultationRequestForm
],
providers: [ProcedureRequestSharedService]
})
export class KonsultasyonModule {
	static dynamicComponentsMap = {
		ConsultationDoctorExaminationFormNew, 
		AppointmentFormConsultation, 
		ConsultationRequestForm
	};
 }

