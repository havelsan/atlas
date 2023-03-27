//$B88AB63F
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SMSFormView } from './SMSFormView';
import { DevExtremeModule } from 'devextreme-angular';
import { SMSPersonnelFormView } from './SMSPersonnelFormView';
import { SMSPatientFormView } from './SMSPatientFormView';
import { SMSLogFormView } from './SMSLogFormView';


const routes: Routes = [
    {
        path: '',
        component: SMSFormView,
    }

];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, DevExtremeModule, HttpModule, FwModule,
        RouterModule.forChild(routes)],
    declarations: [
        SMSFormView, SMSPersonnelFormView, SMSPatientFormView, SMSLogFormView
    ],
    exports: [
        SMSFormView, SMSPersonnelFormView, SMSPatientFormView, SMSLogFormView
    ],
    entryComponents: [
        SMSFormView, SMSPersonnelFormView, SMSPatientFormView, SMSLogFormView
    ]

})
export class SMSModule {
    static dynamicComponentsMap = {
        SMSFormView,
        SMSPersonnelFormView,
        SMSPatientFormView,
        SMSLogFormView
    };
}

