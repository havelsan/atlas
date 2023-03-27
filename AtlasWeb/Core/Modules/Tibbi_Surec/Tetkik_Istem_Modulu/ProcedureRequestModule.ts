import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { ProcedureRequestForm } from './ProcedureRequestForm';
import { RequestedProceduresForm } from './RequestedProceduresForm';
import { MostUsedProcedureRequestForm } from './MostUsedProcedureRequestForm';
import { ProceduresRequiredInfoForm } from './ProceduresRequiredInfoForm';
import { FwModule } from 'Fw/FwModule';
import { RadiologyTestRequestInfoForm } from '../Radyoloji_Modulu/RadiologyTestRequestInfoForm';
import { NuclearMedicineTestRequestInfoForm } from '../Nukleer_Tip_Modulu/NuclearMedicineTestRequestInfoForm';
import { PsychologyTestRequestInfoForm } from '../Psikolog_Modulu/PsychologyTestRequestInfoForm';
import { PathologyTestRequestInfoForm } from '../Patoloji_Modulu/PathologyTestRequestInfoForm';
import { BaseAdditionalInfoForm } from './BaseAdditionalInfoFormForm';
import { ProcedureRequestSharedService } from './ProcedureRequestSharedService';
import { TestResultsForm } from './TestResultsForm';
import { SUTRuleCheckResultsForm } from './SUTRuleCheckResultsForm';
import { RadyolojiModule } from '../Radyoloji_Modulu/RadyolojiModule';
import { QuickProcedureEntryForm } from './QuickProcedureEntryForm';
import { ManipulationProcedureRequestInfo } from '../Manipulasyon_Modulu/ManipulationProcedureRequestInfo';
import { AdditionalReportForm } from './AdditionalReportForm'; 
import { ProcedureResultInfoForm } from './ProcedureResultInfoForm'; 
import { SkinPrickTestResultForm } from './SkinPrickTestResultForm'; 
import { UserPackageForm } from './UserPackageForm'; 


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, RadyolojiModule],
    declarations: [ProcedureRequestForm, RequestedProceduresForm, MostUsedProcedureRequestForm, ProceduresRequiredInfoForm,
		RadiologyTestRequestInfoForm, NuclearMedicineTestRequestInfoForm, PsychologyTestRequestInfoForm, TestResultsForm,
		 SUTRuleCheckResultsForm, PathologyTestRequestInfoForm, BaseAdditionalInfoForm, AdditionalReportForm, 
        QuickProcedureEntryForm, ManipulationProcedureRequestInfo, ProcedureResultInfoForm, SkinPrickTestResultForm, UserPackageForm],
		exports: [ProcedureRequestForm, RequestedProceduresForm, MostUsedProcedureRequestForm, ProceduresRequiredInfoForm,
			RadiologyTestRequestInfoForm, NuclearMedicineTestRequestInfoForm, PsychologyTestRequestInfoForm, TestResultsForm, 
            SUTRuleCheckResultsForm, PathologyTestRequestInfoForm, QuickProcedureEntryForm, ManipulationProcedureRequestInfo, AdditionalReportForm, ProcedureResultInfoForm, SkinPrickTestResultForm, UserPackageForm],
		entryComponents: [ProcedureRequestForm, RequestedProceduresForm, MostUsedProcedureRequestForm, ProceduresRequiredInfoForm,
			RadiologyTestRequestInfoForm, NuclearMedicineTestRequestInfoForm, PsychologyTestRequestInfoForm, TestResultsForm, 
            SUTRuleCheckResultsForm, PathologyTestRequestInfoForm, QuickProcedureEntryForm, ManipulationProcedureRequestInfo, AdditionalReportForm, ProcedureResultInfoForm, SkinPrickTestResultForm, UserPackageForm],
		providers: [ProcedureRequestSharedService]
})
export class ProcedureRequestModule {
	static dynamicComponentsMap = {
		ProcedureRequestForm, 
		RequestedProceduresForm, 
		MostUsedProcedureRequestForm, 
		ProceduresRequiredInfoForm, 
		RadiologyTestRequestInfoForm, 
		NuclearMedicineTestRequestInfoForm, 
		PsychologyTestRequestInfoForm, 
		TestResultsForm, 
		SUTRuleCheckResultsForm, 
		PathologyTestRequestInfoForm, 
		QuickProcedureEntryForm, 
        ManipulationProcedureRequestInfo,
        AdditionalReportForm,
        ProcedureResultInfoForm,
        SkinPrickTestResultForm, UserPackageForm
	};
 }


