//$9B10A5DB
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { XXXXXXEHIPForm } from './XXXXXXEHIPForm';

const routes: Routes = [
    {
        path: '',
        component: XXXXXXEHIPForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
XXXXXXEHIPForm
 ],
exports: [
XXXXXXEHIPForm
 ],
 entryComponents: [
    XXXXXXEHIPForm
     ]
    
})
export class XXXXXXEHIPModuleModule {
	static dynamicComponentsMap = {
		XXXXXXEHIPForm
	};
 }

