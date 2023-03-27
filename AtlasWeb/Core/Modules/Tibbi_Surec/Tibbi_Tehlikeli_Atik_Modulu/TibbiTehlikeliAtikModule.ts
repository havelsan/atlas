//$9FD6D508
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MeicalWasteForm } from './MeicalWasteForm';

const routes: Routes = [
    {
        path: '',
        component: MeicalWasteForm,
    }, {
        path: 'tibbiatik',
        component: MeicalWasteForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
MeicalWasteForm
 ],
 exports: [
 MeicalWasteForm
  ],
  entryComponents: [
  MeicalWasteForm
   ]
})
export class TibbiTehlikeliAtikModule {
	static dynamicComponentsMap = {
		MeicalWasteForm
	};
 }

