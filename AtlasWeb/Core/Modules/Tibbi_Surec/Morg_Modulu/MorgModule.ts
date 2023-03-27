//$080BC4CC
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MorgueExDischargeForm } from './MorgueExDischargeForm';
import { MorgueProcedureForm } from './MorgueProcedureForm';
import { OutMorgueRequestForm } from './OutMorgueRequestForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { TreatmentMaterialModule } from '../Sarf_Malzeme_Modulu/TreatmentMaterialModule';

const routes: Routes = [
    {
        path: '',
        component: OutMorgueRequestForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, TreatmentMaterialModule,
                RouterModule.forChild(routes)],
declarations: [
MorgueExDischargeForm, MorgueProcedureForm, OutMorgueRequestForm
 ],
 exports: [
 MorgueExDischargeForm, MorgueProcedureForm, OutMorgueRequestForm,
 
  ],
  entryComponents: [
  MorgueExDischargeForm, MorgueProcedureForm, OutMorgueRequestForm,
  
   ]
})
export class MorgModule {
	static dynamicComponentsMap = {
		MorgueExDischargeForm, 
		MorgueProcedureForm, 
		OutMorgueRequestForm
	};
 }

