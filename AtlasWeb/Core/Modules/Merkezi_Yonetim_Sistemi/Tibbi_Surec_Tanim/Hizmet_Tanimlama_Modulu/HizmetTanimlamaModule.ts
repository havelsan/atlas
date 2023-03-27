//$B88AB63F
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ProcedureForm } from './ProcedureForm';
import { LaboratoryTestDefinitionNewForm } from './LaboratoryTestDefinitionNewForm';
import { MainProcedureForm } from './MainProcedureForm';
import { DefinitionFormModule } from 'app/DefinitionForm/definition-form.module';
import { RadiologyTestDefinitionForm } from './RadiologyTestDefinitionForm';
import { PathologyTestDefinitionForm } from './PathologyTestDefinitionForm';
import { NuclearMedicineTestDefinitionForm } from './NuclearMedicineTestDefinitionForm';
import { DentalTreatmentDefinitionForm } from './DentalTreatmentDefinitionForm';
import { SurgeryDefinitionForm } from './SurgeryDefinitionForm';
import { OrtesisProsthesisDefinitionForm } from './OrtesisProsthesisDefinitionForm';
import { PhysiotherapyDefinitionForm } from './PhysiotherapyDefinitionForm';
import { EstheticAlternativeProcedureDefinitionForm } from './EstheticAlternativeProcedureDefinitionForm';
import { DialysisDefinitionForm } from './DialysisDefinitionForm';
import { DentalProsthesisDefinitionForm } from './DentalProsthesisDefinitionForm';
import { BloodBankTestDefinitionForm } from './BloodBankTestDefinitionForm';
import { ProcedurePriceDefinitionForm } from './ProcedurePriceDefinitionForm';
import { BulletinProcedureDefinitionForm } from './BulletinProcedureDefinitionForm';
import { AnesthesiaDefinitionForm } from './AnesthesiaDefinitionForm';
import { PackageProcedureDefinitionForm } from './PackageProcedureDefinitionForm';
import { SutRuleEngineDefinitionForm } from './SUTRuleEngineDefinitionForm';
import { SUTPricingUpdateForm } from './SUTPricingUpdateForm';
import { ProcedureMaterialMatchingForm } from './ProcedureMaterialMatchingForm';


const routes: Routes = [
    {
        path: '',
        component: MainProcedureForm,
    }

];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, DefinitionFormModule,
        RouterModule.forChild(routes)],
    declarations: [
        ProcedureForm, MainProcedureForm, LaboratoryTestDefinitionNewForm, RadiologyTestDefinitionForm, PathologyTestDefinitionForm,
        NuclearMedicineTestDefinitionForm, DentalTreatmentDefinitionForm, SurgeryDefinitionForm, OrtesisProsthesisDefinitionForm, PhysiotherapyDefinitionForm,
        EstheticAlternativeProcedureDefinitionForm, DialysisDefinitionForm, DentalProsthesisDefinitionForm, BloodBankTestDefinitionForm, ProcedurePriceDefinitionForm,
        BulletinProcedureDefinitionForm, AnesthesiaDefinitionForm, PackageProcedureDefinitionForm, SutRuleEngineDefinitionForm, SUTPricingUpdateForm,ProcedureMaterialMatchingForm
    ],
    exports: [
        ProcedureForm, MainProcedureForm, LaboratoryTestDefinitionNewForm, RadiologyTestDefinitionForm, PathologyTestDefinitionForm,
        NuclearMedicineTestDefinitionForm, DentalTreatmentDefinitionForm, SurgeryDefinitionForm, OrtesisProsthesisDefinitionForm, PhysiotherapyDefinitionForm,
        EstheticAlternativeProcedureDefinitionForm, DialysisDefinitionForm, DentalProsthesisDefinitionForm, BloodBankTestDefinitionForm, ProcedurePriceDefinitionForm,
        BulletinProcedureDefinitionForm, AnesthesiaDefinitionForm, PackageProcedureDefinitionForm, SutRuleEngineDefinitionForm, SUTPricingUpdateForm,ProcedureMaterialMatchingForm
    ],
    entryComponents: [
        ProcedureForm, MainProcedureForm, LaboratoryTestDefinitionNewForm, RadiologyTestDefinitionForm, PathologyTestDefinitionForm,
        NuclearMedicineTestDefinitionForm, DentalTreatmentDefinitionForm, SurgeryDefinitionForm, OrtesisProsthesisDefinitionForm, PhysiotherapyDefinitionForm,
        EstheticAlternativeProcedureDefinitionForm, DialysisDefinitionForm, DentalProsthesisDefinitionForm, BloodBankTestDefinitionForm, ProcedurePriceDefinitionForm,
        BulletinProcedureDefinitionForm, AnesthesiaDefinitionForm, PackageProcedureDefinitionForm, SutRuleEngineDefinitionForm, SUTPricingUpdateForm,ProcedureMaterialMatchingForm
    ]

})
export class HizmetTanimlamaModule {
    static dynamicComponentsMap = {
        ProcedureForm,
        MainProcedureForm,
        LaboratoryTestDefinitionNewForm,
        RadiologyTestDefinitionForm,
        PathologyTestDefinitionForm,
        NuclearMedicineTestDefinitionForm,
        DentalTreatmentDefinitionForm,
        SurgeryDefinitionForm,
        OrtesisProsthesisDefinitionForm,
        PhysiotherapyDefinitionForm,
        EstheticAlternativeProcedureDefinitionForm,
        DialysisDefinitionForm,
        DentalProsthesisDefinitionForm,
        BloodBankTestDefinitionForm,
        ProcedurePriceDefinitionForm,
        BulletinProcedureDefinitionForm,
        AnesthesiaDefinitionForm,
        PackageProcedureDefinitionForm,
        SutRuleEngineDefinitionForm,
        SUTPricingUpdateForm,
        ProcedureMaterialMatchingForm
    };
}

