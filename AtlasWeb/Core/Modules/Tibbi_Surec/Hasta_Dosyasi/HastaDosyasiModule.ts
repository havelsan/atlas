import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MainPatientFolderForm } from './MainPatientFolderForm';
import { PatientSearchWithDetailsModule } from '../Kayit_Kabul_Modulu/PatientSearchWithDetails/PatientSearchWithDetailsModule';
import { PatientAdmissionSearchModule } from '../Kayit_Kabul_Modulu/PatientAdmissionSearch/PatientAdmissionSearchModule';
import { EpisodeActionDisplayFormModule } from '../Hasta_Islemi_Goruntuleme/EpisodeActionDisplayFormModule';

const routes: Routes = [
    {
        path: '',
        component: MainPatientFolderForm,
    }
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, EpisodeActionDisplayFormModule, PatientSearchWithDetailsModule, PatientAdmissionSearchModule, RouterModule.forChild(routes)],
    declarations: [MainPatientFolderForm],
    exports: [MainPatientFolderForm],
    entryComponents: [MainPatientFolderForm]
})
export class HastaDosyasiModule {
	static dynamicComponentsMap = {
		MainPatientFolderForm
	};
 }

