//$3969F081
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { HemodialysisRequestForm } from './HemodialysisRequestForm';
import { HemodialysisProcedureForm } from './HemodialysisProcedureForm';
import { HemodialysisPlanForm } from './HemodialysisPlanForm';
import { HemodialysisOrderForm } from './HemodialysisOrderForm';
import { HemodialysisOrderDetailForm } from './HemodialysisOrderDetailForm';

import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { HemodialysisAppointmentForm } from './HemodialysisAppointmentForm';
import { HemodialysisInstructionForm } from './HemodialysisInstructionForm';
import { InstructionListForm } from './InstructionListForm';

import { MultipleDataComponentModule } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/Dinamik_MultiData_Formu/MultipleDataComponentModule";

const routes: Routes = [
    {
        path: '',
        component: HemodialysisRequestForm,
    },
    //{ path: 'randevuarama', component: AppointmentListForm },
    { path: 'hemodiyalizrandevuverme', component: HemodialysisAppointmentForm }
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, MultipleDataComponentModule,
        RouterModule.forChild(routes)],
    declarations: [
        HemodialysisRequestForm, HemodialysisPlanForm, HemodialysisOrderForm, HemodialysisOrderDetailForm, HemodialysisProcedureForm, HemodialysisAppointmentForm, HemodialysisInstructionForm, InstructionListForm
    ],
    exports: [
        HemodialysisRequestForm, HemodialysisPlanForm, HemodialysisOrderForm, HemodialysisOrderDetailForm, HemodialysisProcedureForm, HemodialysisAppointmentForm, HemodialysisInstructionForm, InstructionListForm
    ],
    entryComponents: [
        HemodialysisRequestForm, HemodialysisPlanForm, HemodialysisOrderForm, HemodialysisOrderDetailForm, HemodialysisProcedureForm, HemodialysisAppointmentForm, HemodialysisInstructionForm, InstructionListForm
    ]
})
export class HemodiyalizModule {
    static dynamicComponentsMap = {
        HemodialysisRequestForm,
        HemodialysisPlanForm,
        HemodialysisOrderForm,
        HemodialysisOrderDetailForm,
        HemodialysisProcedureForm,
        HemodialysisAppointmentForm,
        HemodialysisInstructionForm,
        InstructionListForm
    };
}

