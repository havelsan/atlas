import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientCompareForm } from './PatientCompareForm';
import { PatientAdmissionSearchModule } from './PatientAdmissionSearch/PatientAdmissionSearchModule';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientAdmissionSearchModule],
    declarations: [
        PatientCompareForm
    ],
    exports: [
        PatientCompareForm
    ],
    entryComponents: [
        PatientCompareForm
    ]
})
export class PatientCompareModule { 
	static dynamicComponentsMap = {
		PatientCompareForm
	};
}

