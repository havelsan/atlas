//$CE8C9843
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { CancerScreeningForm } from './CancerScreeningForm';
import { BreastScreeningForm } from './BreastScreeningForm';
import { ProstateScreeningForm } from './ProstateScreeningForm';
import { SmearScreeningForm } from './SmearScreeningForm';
import { CigaretteInspectionForm } from './CigaretteInspectionForm';
import { CigaretteExaminationForm } from './CigaretteExaminationForm';
import { CigaretteAssessmentForm } from './CigaretteAssessmentForm';

const routes: Routes = [
    {
        path: '',
        component: CancerScreeningForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
    CancerScreeningForm, BreastScreeningForm, ProstateScreeningForm, SmearScreeningForm, CigaretteInspectionForm, CigaretteExaminationForm, CigaretteAssessmentForm 

 ],
 exports: [
     CancerScreeningForm, BreastScreeningForm, ProstateScreeningForm, SmearScreeningForm, CigaretteInspectionForm, CigaretteExaminationForm, CigaretteAssessmentForm 
  ],
  entryComponents: [
      CancerScreeningForm, BreastScreeningForm, ProstateScreeningForm, SmearScreeningForm, CigaretteInspectionForm, CigaretteExaminationForm, CigaretteAssessmentForm 
   ]
})
export class KetemModule {
	static dynamicComponentsMap = {
        CancerScreeningForm, 
        BreastScreeningForm,
        ProstateScreeningForm,
        SmearScreeningForm,
        CigaretteInspectionForm,
        CigaretteExaminationForm,
        CigaretteAssessmentForm,
	};
 }

