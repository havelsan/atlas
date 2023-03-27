//$6BBBBB27
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { TigEpisodeForm } from './TigEpisodeForm';

import { AtlasReportModule } from 'app/Report/AtlasReportModule';
import { AtlasDynamicFormModule } from "app/DynamicForm/AtlasDynamicFormModule";
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';
import { PatientSearchModule } from '../PatientSearch/PatientSearchModule';

const routes: Routes = [
    {
        path: '',
        component: TigEpisodeForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, AtlasDynamicFormModule, AtlasReportModule, PatientHistoryModule,
                RouterModule.forChild(routes), PatientSearchModule],
declarations: [
TigEpisodeForm
 ],
 exports: [
 TigEpisodeForm
  ],
entryComponents: [
  TigEpisodeForm
   ]
})
export class TIGModule {
	static dynamicComponentsMap = {
		TigEpisodeForm
	};
 }

