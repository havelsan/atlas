//$6767B826
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { FollowingPatientsForm } from './FollowingPatientsForm'; 

const routes: Routes = [
    {
        path: '',
        component: FollowingPatientsForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [ 
FollowingPatientsForm
 ], 
exports: [ 
FollowingPatientsForm
 ] 
})
export class FollowingPatientandAdmissionModule { }

