//$94B919FA
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { HalfDoseDestructionForm } from './HalfDoseDestructionForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule,
    ],
    declarations: [
        HalfDoseDestructionForm
    ],
    exports: [
        HalfDoseDestructionForm
    ],
    entryComponents: [
        HalfDoseDestructionForm
    ]
})
export class YarimDozImhaModule {
    static dynamicComponentsMap = {
        HalfDoseDestructionForm,
    };
}

