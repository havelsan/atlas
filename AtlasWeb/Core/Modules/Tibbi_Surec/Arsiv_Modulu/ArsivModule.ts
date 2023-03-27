//$B88AB63F
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { FCCAWorkListForm } from './FCCAWorkListForm';
import { FormFCAAArchive } from './FormFCAAArchive';
import { PatientDemographicsModule } from "../Hasta_Demografik_Bilgileri/PatientDemographicsModule";
import { PatientSearchModule } from '../PatientSearch/PatientSearchModule';

const routes: Routes = [
    {
        path: '',
        component: FCCAWorkListForm,
    },
    { path: 'islistesi', component: FCCAWorkListForm },
    { path: 'arsiv', component: FormFCAAArchive },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, PatientSearchModule,
                RouterModule.forChild(routes)],
declarations: [
FCCAWorkListForm, FormFCAAArchive
 ],
 exports: [
     FCCAWorkListForm, FormFCAAArchive
  ],
  entryComponents: [
      FCCAWorkListForm, FormFCAAArchive
   ]
})
export class ArsivModule {
	static dynamicComponentsMap = {
		FCCAWorkListForm, 
		FormFCAAArchive
	};
 }

