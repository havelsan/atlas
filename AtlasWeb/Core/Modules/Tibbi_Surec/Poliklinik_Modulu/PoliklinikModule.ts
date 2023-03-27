//$2E162944
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientExaminationDoctorFormNew } from './PatientExaminationDoctorFormNew';
import { ProcedureRequestModule } from '../Tetkik_Istem_Modulu/ProcedureRequestModule';
import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';
import { EpisodeActionWorkListModule } from '../Hasta_Is_Listesi/EpisodeActionWorkListModule';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { ConsultationRequestModule } from 'Modules/Tibbi_Surec/Konsultasyon_Istem_Modulu/ConsultationRequestModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { ProcedureRequestSharedService } from '../Tetkik_Istem_Modulu/ProcedureRequestSharedService';
import { SaglikKuruluModule } from '../Saglik_Kurulu_Modulu/SaglikKuruluModule';
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';
import { FormEditorModule } from 'app/FormEditor/form-editor.module'; 
import { HastaRaporlariModule } from 'Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule';
import { ENabizModule } from '../E_Nabiz_Modulu/ENabizModule';
import { AmeliyatModule } from 'Modules/Tibbi_Surec/Ameliyat_Modulu/AmeliyatModule';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, ProcedureRequestModule, ConsultationRequestModule, DiagnosisGridModule, SaglikKuruluModule,
            FormEditorModule, TreatmentMaterialModule, EpisodeActionWorkListModule, PatientDemographicsModule, PatientHistoryModule,ENabizModule,AmeliyatModule,
            HastaRaporlariModule],
declarations: [
    PatientExaminationDoctorFormNew
 ],
exports: [
    PatientExaminationDoctorFormNew
],
entryComponents:[PatientExaminationDoctorFormNew],

providers: [ProcedureRequestSharedService]
})
export class PoliklinikModule {
	static dynamicComponentsMap = {
		PatientExaminationDoctorFormNew
	};
 }

