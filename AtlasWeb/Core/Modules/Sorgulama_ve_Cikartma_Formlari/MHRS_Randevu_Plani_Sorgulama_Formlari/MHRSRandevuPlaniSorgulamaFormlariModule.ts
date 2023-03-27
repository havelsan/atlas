//$BE0A73D5
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MHRSYonetimForm } from './MHRSYonetimForm';

const routes: Routes = [
    {
        path: 'yonetim',
        component: MHRSYonetimForm,
    } 
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, RouterModule.forChild(routes)],
declarations: [
MHRSYonetimForm
 ],
 exports: [
 MHRSYonetimForm
  ],
entryComponents: [
  MHRSYonetimForm
   ]
})
export class MHRSRandevuPlaniSorgulamaFormlariModule {
	static dynamicComponentsMap = {
		MHRSYonetimForm
	};
 }

