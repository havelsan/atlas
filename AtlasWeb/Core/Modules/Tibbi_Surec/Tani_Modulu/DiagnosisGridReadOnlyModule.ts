//$668863E2
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { DiagnosisGridReadOnlyForm } from './DiagnosisGridReadOnlyForm';
import { FwModule } from 'Fw/FwModule';

 
@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [DiagnosisGridReadOnlyForm],
    exports: [DiagnosisGridReadOnlyForm],
    entryComponents: [DiagnosisGridReadOnlyForm]
})
export class DiagnosisGridReadOnlyModule {
	static dynamicComponentsMap = {
		DiagnosisGridReadOnlyForm
	};
 }

