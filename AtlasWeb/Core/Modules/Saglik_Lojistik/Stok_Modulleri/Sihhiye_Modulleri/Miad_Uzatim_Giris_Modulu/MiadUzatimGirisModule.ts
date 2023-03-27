//$4B83EB1F
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BaseExtendExpDateInForm } from './BaseExtendExpDateInForm'; 
import { ExtendExpDateInForm } from './ExtendExpDateInForm'; 
import { ExtendExpDateInCompForm } from './ExtendExpDateInCompForm'; 

const routes: Routes = [
    {
        path: '',
        component: BaseExtendExpDateInForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [ 
BaseExtendExpDateInForm,ExtendExpDateInForm,ExtendExpDateInCompForm
 ], 
 exports: [ 
 BaseExtendExpDateInForm,ExtendExpDateInForm,ExtendExpDateInCompForm
  ], 
  entryComponents: [ 
  BaseExtendExpDateInForm,ExtendExpDateInForm,ExtendExpDateInCompForm
   ] 
})
export class MiadUzatimGirisModule {
	static dynamicComponentsMap = {
		BaseExtendExpDateInForm, 
		ExtendExpDateInForm, 
		ExtendExpDateInCompForm
	};
 }

