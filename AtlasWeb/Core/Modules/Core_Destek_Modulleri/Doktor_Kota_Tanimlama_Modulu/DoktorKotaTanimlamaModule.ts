//$2733C2CD
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DoctorQuotaDefForm } from './DoctorQuotaDefForm';

const routes: Routes = [
    {
        path: '',
        component: DoctorQuotaDefForm,
    },
    {
        path: 'doctorquota',
        component: DoctorQuotaDefForm,
    },

];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
DoctorQuotaDefForm
 ],
exports: [
DoctorQuotaDefForm
 ],
 entryComponents: [
    DoctorQuotaDefForm
     ]
    
})
export class DoktorKotaTanimlamaModule {
	static dynamicComponentsMap = {
		DoctorQuotaDefForm
	};
 }

