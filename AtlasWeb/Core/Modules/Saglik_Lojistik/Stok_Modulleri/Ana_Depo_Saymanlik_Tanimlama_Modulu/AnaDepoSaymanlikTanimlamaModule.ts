//$265B0661
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MainStoreDefinitionForm } from "./MainStoreDefinitionForm";

const routes: Routes = [
    {
        path: '',
        component: MainStoreDefinitionForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
    MainStoreDefinitionForm
 ],
exports: [
    MainStoreDefinitionForm
 ],
 entryComponents: [
     MainStoreDefinitionForm
  ]
})
export class AnaDepoSaymanlikTanimlamaModule {
	static dynamicComponentsMap = {
		MainStoreDefinitionForm
	};
 }

