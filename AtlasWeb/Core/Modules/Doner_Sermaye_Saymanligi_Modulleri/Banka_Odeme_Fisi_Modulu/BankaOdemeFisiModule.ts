//$1A984CE0
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BankPaymentDecountForm } from './BankPaymentDecountForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [BankPaymentDecountForm],
    exports: [BankPaymentDecountForm],
    entryComponents: [BankPaymentDecountForm]
})
export class BankaOdemeFisiModule {
	static dynamicComponentsMap = {
		BankPaymentDecountForm
	};
 }

