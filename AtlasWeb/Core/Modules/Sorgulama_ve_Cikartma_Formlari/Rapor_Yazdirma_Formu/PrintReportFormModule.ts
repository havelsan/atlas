import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PrintReportForm } from './PrintReportForm';
import { AtlasReportModule } from 'app/Report/AtlasReportModule';

const routes: Routes = [
    {
        path: '',
        component: PrintReportForm,
    },
    { path: 'raporlar', component: PrintReportForm },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, AtlasReportModule,
                RouterModule.forChild(routes)],
declarations: [
    PrintReportForm
 ],
 exports: [
     PrintReportForm
  ],
entryComponents: [
      PrintReportForm
   ]
})
export class PrintReportFormModule {
	static dynamicComponentsMap = {
		PrintReportForm
	};
 }
