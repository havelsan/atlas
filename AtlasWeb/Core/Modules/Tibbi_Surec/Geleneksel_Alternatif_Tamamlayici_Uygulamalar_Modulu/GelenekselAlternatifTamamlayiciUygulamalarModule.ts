//$3B202468
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
//import { TraditionalAlternativeRequestForm } from './TraditionalAlternativeRequestForm'; 
//import { TraditionalAlternativeProcedureForm } from './TraditionalAlternativeProcedureForm'; 
import { GetatExaminationForm } from './GetatExaminationForm'; 

const routes: Routes = [
    {
        path: '',
        component: GetatExaminationForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [ 
/*TraditionalAlternativeRequestForm,TraditionalAlternativeProcedureForm,*/GetatExaminationForm
 ], 
exports: [ 
/*TraditionalAlternativeRequestForm,TraditionalAlternativeProcedureForm,*/GetatExaminationForm
 ] 
})
export class GelenekselAlternatifTamamlayiciUygulamalarModule {
    static dynamicComponentsMap = {
        GetatExaminationForm
	};
 }

