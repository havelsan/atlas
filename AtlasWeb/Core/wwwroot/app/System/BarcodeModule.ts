//$6BBBBB27
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';

import { BarcodeSettingsView } from './Views/BarcodeSettingsView';

const routes: Routes = [
    {
        path: '',
        component: BarcodeSettingsView,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
    BarcodeSettingsView
 ],
 exports: [
     BarcodeSettingsView
  ],
  entryComponents: [
      BarcodeSettingsView
   ]
})
export class BarcodeModule { 
	static dynamicComponentsMap = {
		BarcodeSettingsView
	};
}

