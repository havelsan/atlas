//$62C1D080
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientDemographicsModule } from "../Hasta_Demografik_Bilgileri/PatientDemographicsModule";
import { DiagnosisGridReadOnlyModule } from "Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule";
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { OrthesisProsthesisCancelledForm } from './OrthesisProsthesisCancelledForm';
import { OrthesisProsthesisRequestForm } from './OrthesisProsthesisRequestForm';
import { OrthesisProsthesisForm } from './OrthesisProsthesisForm';

const routes: Routes = [
    {
        path: '',
        component: OrthesisProsthesisForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule, TreatmentMaterialModule,
        RouterModule.forChild(routes)],
    declarations: [
        OrthesisProsthesisForm, OrthesisProsthesisRequestForm, OrthesisProsthesisCancelledForm
        // OrthesisProsthesisProcedureForm,OrthesisProsthesisProcedure_CokluOzelDurumForm,
        // ,OrthesisProsthesisFinancialDepartmentForm,OrthesisProsthesisRequestAcceptionForm,
        // OrthesisProsthesisHealthCommitteeForm,OrthesisProsthesisHealthCommitteeApprovalForm,
        // OrthesisProsthesisDoctorApprovalForm,OrthesisProsthesisReturnForm,AppointmentFormOrthesis

    ],
    exports: [
        OrthesisProsthesisForm, OrthesisProsthesisRequestForm, OrthesisProsthesisCancelledForm
        // OrthesisProsthesisProcedureForm,OrthesisProsthesisProcedure_CokluOzelDurumForm,
        // ,OrthesisProsthesisFinancialDepartmentForm,OrthesisProsthesisRequestAcceptionForm,
        // OrthesisProsthesisHealthCommitteeForm,OrthesisProsthesisHealthCommitteeApprovalForm,
        // OrthesisProsthesisDoctorApprovalForm,OrthesisProsthesisReturnForm,AppointmentFormOrthesis,

    ],
    entryComponents: [
        OrthesisProsthesisForm, OrthesisProsthesisRequestForm, OrthesisProsthesisCancelledForm
        // OrthesisProsthesisProcedureForm,OrthesisProsthesisProcedure_CokluOzelDurumForm,
        // ,OrthesisProsthesisFinancialDepartmentForm,OrthesisProsthesisRequestAcceptionForm,
        // OrthesisProsthesisHealthCommitteeForm,OrthesisProsthesisHealthCommitteeApprovalForm,
        // OrthesisProsthesisDoctorApprovalForm,OrthesisProsthesisReturnForm,AppointmentFormOrthesis,

    ]
})
export class OrtezProtezModule {
    static dynamicComponentsMap = {
        OrthesisProsthesisForm,
        OrthesisProsthesisRequestForm,
        OrthesisProsthesisCancelledForm
    };
}

