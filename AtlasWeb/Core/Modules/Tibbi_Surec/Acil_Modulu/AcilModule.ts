//$B122A1DB
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';

import { EmergencyTriageForm } from './EmergencyTriageForm';
import { EmergencySpecialityObjectForm } from './EmergencySpecialityObjectForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { AnamnezModule } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AnamnezModule';
const routes: Routes = [
    {
        path: '',
        component: EmergencyTriageForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, AnamnezModule,
                RouterModule.forChild(routes)],
declarations: [
    EmergencyTriageForm, EmergencySpecialityObjectForm
 ],
 exports: [
     EmergencyTriageForm, EmergencySpecialityObjectForm
  ],
  entryComponents: [
      EmergencyTriageForm, EmergencySpecialityObjectForm
   ]
})
export class AcilModule {
	static dynamicComponentsMap = {
		EmergencyTriageForm, 
		EmergencySpecialityObjectForm
	};
 }

