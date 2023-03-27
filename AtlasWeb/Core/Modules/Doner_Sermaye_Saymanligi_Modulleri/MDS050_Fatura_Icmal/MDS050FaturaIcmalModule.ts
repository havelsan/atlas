//$EFC8A5C7
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { InvoiceCollectionBoundForm } from './InvoiceCollectionBoundForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [InvoiceCollectionBoundForm],
    exports: [InvoiceCollectionBoundForm],
    entryComponents: [InvoiceCollectionBoundForm]
})
export class MDS050FaturaIcmalModule {
	static dynamicComponentsMap = {
		InvoiceCollectionBoundForm
	};
 }

