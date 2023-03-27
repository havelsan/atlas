//$555A3473
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ReceiptForm } from './ReceiptForm';

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
declarations: [
ReceiptForm
 ],
exports: [
ReceiptForm
 ],
 entryComponents: [
	ReceiptForm
	 ]
	
})
export class MDS014HizmetKarsiligiMakbuzKesimiModule {
	static dynamicComponentsMap = {
		ReceiptForm
	};
 }

