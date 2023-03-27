//$AA50A365
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { CreatingEpicrisisForm } from './CreatingEpicrisisForm'; 

const routes: Routes = [
    {
        path: '',
        component: CreatingEpicrisisForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [ 
CreatingEpicrisisForm
 ], 
exports: [ 
CreatingEpicrisisForm
 ] 
})
export class EpikrizModule {
    static dynamicComponentsMap = {
		CreatingEpicrisisForm
	};
 }

