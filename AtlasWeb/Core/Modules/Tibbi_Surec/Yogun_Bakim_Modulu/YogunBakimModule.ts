//$CF1B8C7B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ApacheScoreForm } from './ApacheScoreForm';
import { GlaskowScoreForm } from './GlaskowScoreForm';
import { SapScoreForm } from './SapScoreForm';
import { IntensiveCareSpecialityObjForm } from './IntensiveCareSpecialityObjForm';
import { MultipleDataComponentModule } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/Dinamik_MultiData_Formu/MultipleDataComponentModule";
import { ApgarScoreForm } from './ApgarScoreForm';
import { BallardNeuromuscularScoreForm } from './BallardNeuromuscularScoreForm';
import { BallardPhysicalScoreForm } from './BallardPhysicalScoreForm';
import { GeneralInformationForm } from './GeneralInformationForm';
import { PhototherapyForm } from './PhototherapyForm';
import { SnappeIIScoreForm } from './SnappeIIScoreForm';
import { WeightChartForm } from './WeightChartForm';
import { NewBornIntensiveCareForm } from './NewBornIntensiveCareForm';
import { PrismScoreForm } from './PrismScoreForm';
import { FormEditorModule } from 'app/FormEditor/form-editor.module';

const routes: Routes = [
    {
        path: '',
        component: ApacheScoreForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, MultipleDataComponentModule, FormEditorModule,
        RouterModule.forChild(routes)],
    declarations: [
        ApacheScoreForm, SapScoreForm, IntensiveCareSpecialityObjForm, GlaskowScoreForm, ApgarScoreForm, BallardNeuromuscularScoreForm, PrismScoreForm,
        BallardPhysicalScoreForm, GeneralInformationForm, PhototherapyForm, SnappeIIScoreForm, WeightChartForm, NewBornIntensiveCareForm
    ],
    exports: [
        ApacheScoreForm, SapScoreForm, IntensiveCareSpecialityObjForm, GlaskowScoreForm, ApgarScoreForm, BallardNeuromuscularScoreForm, PrismScoreForm,
        BallardPhysicalScoreForm, GeneralInformationForm, PhototherapyForm, SnappeIIScoreForm, WeightChartForm, NewBornIntensiveCareForm
    ],
    entryComponents: [
        ApacheScoreForm, SapScoreForm, IntensiveCareSpecialityObjForm, GlaskowScoreForm, ApgarScoreForm, BallardNeuromuscularScoreForm, PrismScoreForm,
        BallardPhysicalScoreForm, GeneralInformationForm, PhototherapyForm, SnappeIIScoreForm, WeightChartForm, NewBornIntensiveCareForm
    ]
})
export class YogunBakimModule {
    static dynamicComponentsMap = {
        ApacheScoreForm,
        SapScoreForm,
        IntensiveCareSpecialityObjForm,
        GlaskowScoreForm,
        ApgarScoreForm,
        BallardNeuromuscularScoreForm,
        BallardPhysicalScoreForm,
        GeneralInformationForm,
        PhototherapyForm,
        SnappeIIScoreForm,
        WeightChartForm,
        NewBornIntensiveCareForm,
        PrismScoreForm
    };
}

