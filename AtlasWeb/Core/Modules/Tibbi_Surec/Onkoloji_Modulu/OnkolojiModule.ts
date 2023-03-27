//$9CA8DB7A
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MedicalOncologySpecialityForm } from './MedicalOncologySpecialityForm'; 
import { KemoterapiveRadyoterapiModule } from '../Kemoterapi_ve_Radyoterapi_Modulu/KemoterapiveRadyoterapiModule';

const routes: Routes = [
    {
        path: '',
        component: MedicalOncologySpecialityForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule,KemoterapiveRadyoterapiModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [ 
MedicalOncologySpecialityForm
 ], 
exports: [ 
MedicalOncologySpecialityForm
 ] 
})
export class OnkolojiModule { 
    static dynamicComponentsMap = {
        MedicalOncologySpecialityForm
	};
}

