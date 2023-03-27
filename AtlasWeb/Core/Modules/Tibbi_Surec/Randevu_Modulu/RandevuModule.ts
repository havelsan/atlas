//$8F64B516
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ScheduleForm } from './ScheduleForm';
import { AppointmentForm } from './AppointmentForm';
import { AppointmentListForm } from './AppointmentListForm';
import { GiveOrUpdateAppointmentForm } from './GiveOrUpdateAppointmentForm';
import { PatientSearchModule } from '../PatientSearch/PatientSearchModule';
import { InpatientAppInfoForm } from './InpatientAppInfoForm';
import { GivenInpatientAppointmentForm } from './GivenInpatientAppointmentForm';

const routes: Routes = [
    {
        path: '',
        component: AppointmentForm,
    },
    { path: 'randevuverme', component: AppointmentForm },
    //{ path: 'randevuarama', component: AppointmentListForm },
    { path: 'randevuplanlama', component: ScheduleForm },
    { path: 'randevuarama', component: AppointmentListForm },
    // { path: 'MHRSIstisnaBildirim', component: MHRSExceptionalForm },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, RouterModule.forChild(routes), PatientSearchModule],
    declarations: [
        //AdmissionAppointmentForm,
        ScheduleForm,
        AppointmentForm,
        AppointmentListForm,
        // MHRSExceptionalForm,
        GiveOrUpdateAppointmentForm,
        InpatientAppInfoForm,
        GivenInpatientAppointmentForm
    ],
    exports: [
        //AdmissionAppointmentForm,
        ScheduleForm,
        AppointmentForm,
        GiveOrUpdateAppointmentForm,
        AppointmentListForm,
        InpatientAppInfoForm,
        GivenInpatientAppointmentForm
        // MHRSExceptionalForm
    ],
    entryComponents: [
        //AdmissionAppointmentForm,
        ScheduleForm,
        AppointmentForm,
        GiveOrUpdateAppointmentForm,
        AppointmentListForm,
        InpatientAppInfoForm,
        GivenInpatientAppointmentForm
        // MHRSExceptionalForm
    ]
})
export class RandevuModule {
    static dynamicComponentsMap = {
        //AdmissionAppointmentForm, 
        ScheduleForm,
        AppointmentForm,
        GiveOrUpdateAppointmentForm,
        AppointmentListForm,
        InpatientAppInfoForm,
        GivenInpatientAppointmentForm
        // MHRSExceptionalForm
    };
}



