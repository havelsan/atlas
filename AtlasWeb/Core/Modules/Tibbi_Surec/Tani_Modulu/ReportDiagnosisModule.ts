import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { ReportDiagnosisForm } from './ReportDiagnosisForm';
import { FwModule } from 'Fw/FwModule';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule], //, ENabizModule
    declarations: [ ReportDiagnosisForm],
    exports: [ ReportDiagnosisForm],
    entryComponents: [ ReportDiagnosisForm ]
})
export class ReportDiagnosisModule {
	static dynamicComponentsMap = {
		ReportDiagnosisForm
	};
 }
