//$9C5A417D
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { CensusFixedFormStockCardRegistryForm } from './CensusFixedFormStockCardRegistryForm';
import { BaseCensusFixedForm } from './BaseCensusFixedForm';
import { CensusFixedNewForm } from './CensusFixedNewForm';
import { CensusFixedApprovalForm } from './CensusFixedApprovalForm';
import { CensusFixedCompletedForm } from './CensusFixedCompletedForm';

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
declarations: [
CensusFixedFormStockCardRegistryForm,
BaseCensusFixedForm, CensusFixedNewForm, CensusFixedApprovalForm, CensusFixedCompletedForm
 ],
 exports: [
 CensusFixedFormStockCardRegistryForm,
 BaseCensusFixedForm, CensusFixedNewForm, CensusFixedApprovalForm, CensusFixedCompletedForm
  ],
  entryComponents: [
  CensusFixedFormStockCardRegistryForm,
  BaseCensusFixedForm, CensusFixedNewForm, CensusFixedApprovalForm, CensusFixedCompletedForm
   ]
})
export class SayimDuzeltmeBelgesiModule {
	static dynamicComponentsMap = {
		CensusFixedFormStockCardRegistryForm, 
		BaseCensusFixedForm, 
		CensusFixedNewForm, 
		CensusFixedApprovalForm, 
		CensusFixedCompletedForm
	};
 }

