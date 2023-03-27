//$0C49E9A4
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { TreatmentDischargeForm } from './TreatmentDischargeForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { XXXXXXlerArasiSevkModule } from "Modules/Tibbi_Surec/XXXXXXler_Arasi_Sevk_Modulu/XXXXXXlerArasiSevkModule";

const routes: Routes = [
    {
        path: '',
        component: TreatmentDischargeForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, XXXXXXlerArasiSevkModule,
                RouterModule.forChild(routes)],
declarations: [
TreatmentDischargeForm
 ],
 exports: [
 TreatmentDischargeForm
  ],
  entryComponents: [
  TreatmentDischargeForm
   ]
})
export class TaburcuIslemleriModule {
	static dynamicComponentsMap = {
		TreatmentDischargeForm
	};
 }

