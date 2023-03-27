//$4B2EA4F9
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ZForm1 } from './ZForm1';
import { ZForm2 } from './ZForm2';
import { ConvTestForm2 } from './ConvTestForm2';
import { ConvTestApprooveForm } from './ConvTestApprooveForm';

const routes: Routes = [
    {
        path: '',
        component: ZForm1,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
ZForm1, ZForm2, ConvTestForm2, ConvTestApprooveForm
 ],
exports: [
ZForm1, ZForm2, ConvTestForm2, ConvTestApprooveForm
 ],
 entryComponents: [
	ZForm1, ZForm2, ConvTestForm2, ConvTestApprooveForm
	 ]
	
})
export class TestModule {
	static dynamicComponentsMap = {
		ZForm1, 
		ZForm2, 
		ConvTestForm2, 
		ConvTestApprooveForm
	};
 }

