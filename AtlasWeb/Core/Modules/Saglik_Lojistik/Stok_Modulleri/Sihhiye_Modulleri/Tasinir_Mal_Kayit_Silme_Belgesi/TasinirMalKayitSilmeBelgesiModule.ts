//$4380A554
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DeleteRecordDocumentDestroyableStockCardRegistryForm } from './DeleteRecordDocumentDestroyableStockCardRegistryForm';
import { BaseDeleteRecordDocumentDestroyableForm } from './BaseDeleteRecordDocumentDestroyableForm';
import { DeleteRecordDocumentDestroyableCompletedForm } from './DeleteRecordDocumentDestroyableCompletedForm';
import { DeleteRecordDocumentDestroyableForm } from './DeleteRecordDocumentDestroyableForm';
import { DeleteRecordDocumentDestroyableInspectionForm } from './DeleteRecordDocumentDestroyableInspectionForm';
import { DeleteRecordDocumentDestroyableApproveForm } from './DeleteRecordDocumentDestroyableApproveForm';
import { BaseDeleteRecordDocumentForm } from './BaseDeleteRecordDocumentForm';


const routes: Routes = [
    {
        path: '',
        component: DeleteRecordDocumentDestroyableStockCardRegistryForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
DeleteRecordDocumentDestroyableStockCardRegistryForm, BaseDeleteRecordDocumentDestroyableForm,
DeleteRecordDocumentDestroyableCompletedForm, DeleteRecordDocumentDestroyableForm,
DeleteRecordDocumentDestroyableInspectionForm, DeleteRecordDocumentDestroyableApproveForm,
BaseDeleteRecordDocumentForm
 ],
 exports: [
	DeleteRecordDocumentDestroyableStockCardRegistryForm, BaseDeleteRecordDocumentDestroyableForm,
	DeleteRecordDocumentDestroyableCompletedForm, DeleteRecordDocumentDestroyableForm,
	DeleteRecordDocumentDestroyableInspectionForm, DeleteRecordDocumentDestroyableApproveForm,
	BaseDeleteRecordDocumentForm
	 ],
entryComponents: [
		DeleteRecordDocumentDestroyableStockCardRegistryForm, BaseDeleteRecordDocumentDestroyableForm,
		DeleteRecordDocumentDestroyableCompletedForm, DeleteRecordDocumentDestroyableForm,
		DeleteRecordDocumentDestroyableInspectionForm, DeleteRecordDocumentDestroyableApproveForm,
		BaseDeleteRecordDocumentForm
		 ]
})
export class TasinirMalKayitSilmeBelgesiModule {
	static dynamicComponentsMap = {
		DeleteRecordDocumentDestroyableStockCardRegistryForm, 
		BaseDeleteRecordDocumentDestroyableForm, 
		DeleteRecordDocumentDestroyableCompletedForm, 
		DeleteRecordDocumentDestroyableForm, 
		DeleteRecordDocumentDestroyableInspectionForm, 
		DeleteRecordDocumentDestroyableApproveForm, 
		BaseDeleteRecordDocumentForm
	};
 }

