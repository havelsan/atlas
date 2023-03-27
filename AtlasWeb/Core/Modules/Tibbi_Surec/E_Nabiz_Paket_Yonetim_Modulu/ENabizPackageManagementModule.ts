//$6BBBBB27
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ENabizPackagesForm } from './ENabizPackagesForm';
import { PatientSearchModule } from '../PatientSearch/PatientSearchModule';


const routes: Routes = [
    {
        path: '',
        component: ENabizPackagesForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule,
                RouterModule.forChild(routes)],
declarations: [
    ENabizPackagesForm
 ],
 exports: [
     ENabizPackagesForm
  ],
  entryComponents: [
      ENabizPackagesForm
   ]
})
export class ENabizPackageManagementModule {
	static dynamicComponentsMap = {
		ENabizPackagesForm
	};
 }

