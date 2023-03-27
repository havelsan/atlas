//$B88AB63F
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientDocumentUploadForm } from './PatientDocumentUploadForm';
import { PatientDocumentDownloadForm } from './PatientDocumentDownloadForm';

const routes: Routes = [
    {
        path: '',
        component: PatientDocumentUploadForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
    PatientDocumentUploadForm, PatientDocumentDownloadForm
    ],
    exports: [
        PatientDocumentUploadForm, PatientDocumentDownloadForm
     ],
    entryComponents: [
         PatientDocumentUploadForm, PatientDocumentDownloadForm
      ]
})
export class HastaDokumantasyonModule {
	static dynamicComponentsMap = {
		PatientDocumentUploadForm, 
		PatientDocumentDownloadForm
	};
 }

