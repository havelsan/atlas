import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientAdmissionSearchForm } from './PatientAdmissionSearchForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [
        PatientAdmissionSearchForm
    ],
    exports: [
        PatientAdmissionSearchForm
    ],
    entryComponents: [
        PatientAdmissionSearchForm
    ]
})
export class PatientAdmissionSearchModule { 
	static dynamicComponentsMap = {
		PatientAdmissionSearchForm
	};
}

