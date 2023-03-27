//$FC607EA4
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { RegularObstetricNewForm } from './RegularObstetricNewForm';
import { BabyInformationForm } from './BabyInformationForm';

import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';
import { MultipleDataComponentModule } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/Dinamik_MultiData_Formu/MultipleDataComponentModule";

import { KayitKabulModule } from 'Modules/Tibbi_Surec/Kayit_Kabul_Modulu/KayitKabulModule';
import { TreatmentMaterialModule } from '../Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { ProcedureRequestModule } from '../Tetkik_Istem_Modulu/ProcedureRequestModule';

const routes: Routes = [
    {
        path: '',
        component: RegularObstetricNewForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, DiagnosisGridModule, MultipleDataComponentModule, KayitKabulModule, TreatmentMaterialModule, ProcedureRequestModule,
        RouterModule.forChild(routes)],
    declarations: [
        RegularObstetricNewForm,
        BabyInformationForm
    ],
    exports: [
        RegularObstetricNewForm,
        BabyInformationForm
    ],
    entryComponents: [
        RegularObstetricNewForm,
        BabyInformationForm
    ]
})
export class NormalDogumModule {
    static dynamicComponentsMap = {
        RegularObstetricNewForm,
        BabyInformationForm
    };
}

