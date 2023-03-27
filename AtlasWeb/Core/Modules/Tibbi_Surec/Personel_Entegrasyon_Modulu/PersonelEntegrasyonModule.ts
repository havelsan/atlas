//$B7BD530B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PersonnelIntegrationForm } from './PersonnelIntegrationForm';

const routes: Routes = [
    {
        path: '',
        component: PersonnelIntegrationForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
PersonnelIntegrationForm
 ],
 exports: [
 PersonnelIntegrationForm
  ],
  entryComponents: [
  PersonnelIntegrationForm
   ]
})
export class PersonelEntegrasyonModule {
	static dynamicComponentsMap = {
		PersonnelIntegrationForm
	};
 }

