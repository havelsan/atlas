//$555E95F1
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from "Fw/FwModule";
import { ActionForm } from './ActionForm';
import { EpisodeActionForm } from './EpisodeActionForm';
import { SpecialityBasedObjectForm } from './SpecialityBasedObjectForm';
import { BaseNewDoctorExaminationForm } from './BaseNewDoctorExaminationForm';
import { AppointmentFormBase } from './AppointmentFormBase';
import { SubactionProcedureAppointmentForm } from './SubactionProcedureAppointmentForm';
import { SubactionProcedureFlowableForm } from './SubactionProcedureFlowableForm';
import { BaseMultipleDataEntryForm } from './BaseMultipleDataEntryForm';
import { MultipleDataComponentModule } from './Dinamik_MultiData_Formu/MultipleDataComponentModule';
import { BaseAdditionalApplicationDescriptionForm } from './BaseAdditionalApplicationDescriptionForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, MultipleDataComponentModule],
    declarations: [ActionForm, EpisodeActionForm, BaseMultipleDataEntryForm, SpecialityBasedObjectForm
        , AppointmentFormBase, SubactionProcedureAppointmentForm, SubactionProcedureFlowableForm, BaseNewDoctorExaminationForm, BaseAdditionalApplicationDescriptionForm],
		exports: [ActionForm, EpisodeActionForm, BaseMultipleDataEntryForm, SpecialityBasedObjectForm
			, AppointmentFormBase, SubactionProcedureAppointmentForm, SubactionProcedureFlowableForm, BaseNewDoctorExaminationForm, BaseAdditionalApplicationDescriptionForm],
	entryComponents: [ActionForm, EpisodeActionForm, BaseMultipleDataEntryForm, SpecialityBasedObjectForm
				, AppointmentFormBase, SubactionProcedureAppointmentForm, SubactionProcedureFlowableForm, BaseNewDoctorExaminationForm, BaseAdditionalApplicationDescriptionForm]
		})
export class TibbiSurecEvrenselModule {
	static dynamicComponentsMap = {
		ActionForm, 
		EpisodeActionForm, 
		BaseMultipleDataEntryForm, 
		SpecialityBasedObjectForm, 
		AppointmentFormBase, 
		SubactionProcedureAppointmentForm, 
		SubactionProcedureFlowableForm, 
		BaseNewDoctorExaminationForm, 
		BaseAdditionalApplicationDescriptionForm
	};
 }


