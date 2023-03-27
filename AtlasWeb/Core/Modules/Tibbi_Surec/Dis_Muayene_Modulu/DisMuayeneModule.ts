//$E63F6519
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DentalExaminationForm } from './DentalExaminationForm';
import { OrtodontiFormComponent } from './ortodontiForm.component';
import { DisTaahhutFormComponent } from './DisTaahhutForm.component';
import { BaseDentalEpisodeActionForm } from './BaseDentalEpisodeActionForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';
import { ProcedureRequestModule } from '../Tetkik_Istem_Modulu/ProcedureRequestModule';
import { ConsultationRequestModule } from 'Modules/Tibbi_Surec/Konsultasyon_Istem_Modulu/ConsultationRequestModule';
import { HastaRaporlariModule } from 'Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule';
import { AnamnezModule } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AnamnezModule';
import { DentalCommitmentForm } from './DentalCommitmentForm';
import { FormEditorModule } from 'app/FormEditor/form-editor.module'; 

/*const routes: Routes = [
    {
        path: '',
        component: DentalExaminationForm,
    },
];
*/
@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridModule, TreatmentMaterialModule,FormEditorModule,
        PatientHistoryModule, ProcedureRequestModule, ConsultationRequestModule, AnamnezModule, HastaRaporlariModule,
        /*RouterModule.forChild(routes)*/],
    declarations: [
        DentalExaminationForm, DentalCommitmentForm, BaseDentalEpisodeActionForm, OrtodontiFormComponent, DisTaahhutFormComponent
    ],
    exports: [
        DentalExaminationForm, DentalCommitmentForm, BaseDentalEpisodeActionForm, OrtodontiFormComponent, DisTaahhutFormComponent
    ],
    entryComponents: [
        DentalExaminationForm, DentalCommitmentForm, BaseDentalEpisodeActionForm, OrtodontiFormComponent, DisTaahhutFormComponent
    ]
})
export class DisMuayeneModule {
	static dynamicComponentsMap = {
		DentalExaminationForm, 
		DentalCommitmentForm, 
		BaseDentalEpisodeActionForm, 
		OrtodontiFormComponent, 
		DisTaahhutFormComponent
	};
 }

