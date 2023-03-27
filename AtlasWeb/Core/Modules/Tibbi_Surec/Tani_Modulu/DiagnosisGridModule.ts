//$668863E2
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { DiagnosisGridForm } from './DiagnosisGridForm';
import { FwModule } from 'Fw/FwModule';
import { ENabizModule } from '../E_Nabiz_Modulu/ENabizModule';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, ENabizModule],
    declarations: [DiagnosisGridForm, ],
    exports: [DiagnosisGridForm],
    entryComponents: [DiagnosisGridForm]
})
export class DiagnosisGridModule {
	static dynamicComponentsMap = {
		DiagnosisGridForm
	};
 }

