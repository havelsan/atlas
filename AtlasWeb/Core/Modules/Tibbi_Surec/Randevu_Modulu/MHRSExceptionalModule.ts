import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { MHRSExceptionalForm } from './MHRSExceptionalForm';
import { FwModule } from 'Fw/FwModule';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, DevExtremeModule, FwModule],
    declarations: [MHRSExceptionalForm],
    exports: [MHRSExceptionalForm],
    entryComponents: [MHRSExceptionalForm ]
})
export class MHRSExceptionalModule {
	static dynamicComponentsMap = {
		MHRSExceptionalForm
	};
 }
