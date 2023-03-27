//$88F56184
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { InPatientAdmissionClinicProcedure } from "./InPatientAdmissionClinicProcedure";
import { InpatientAdmissionRequestForm } from './InpatientAdmissionRequestForm';
import { InPatientAdmissionBaseForm } from './InPatientAdmissionBaseForm';
import { InPatientTreatmentClinicAcceptionForm } from './InPatientTreatmentClinicAcceptionForm';
import { BedSelectionForm } from './BedSelectionForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { InPatientPhysicianApplicationForm } from './InPatientPhysicianApplicationForm';
import { ProcedureRequestSharedService } from '../Tetkik_Istem_Modulu/ProcedureRequestSharedService';
import { ProcedureRequestModule } from '../Tetkik_Istem_Modulu/ProcedureRequestModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { CompanionApplicationForm } from './CompanionApplicationForm';
import { InpatientAdmissinDepositMaterialForm } from './InpatientAdmissinDepositMaterialForm';
import { ConsultationRequestModule } from 'Modules/Tibbi_Surec/Konsultasyon_Istem_Modulu/ConsultationRequestModule';
import { FormEditorModule } from 'app/FormEditor/form-editor.module';
import { DietOrderDetailForm } from './DietOrderDetailForm';
import { DietOrderForm } from './DietOrderForm';
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';
import { AtlasReportModule } from 'app/Report/AtlasReportModule';
import { HemsirelikIslemleriModule } from '../Hemsirelik_Islemleri_Modulu/HemsirelikIslemleriModule';
import { HastaRaporlariModule } from 'Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule';
import { DrugOrderGridComponent } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponent';
import { NODTimeLineComponent } from './NODTimeLineComponent';
import { EpikrizModule } from 'Modules/Tibbi_Surec/Epikriz_Modulu/EpikrizModule';
import { LongInpatientReasonForm } from './LongInpatientReasonForm';
import { ShortInpatientReasonForm } from './ShortInpatientReasonForm';
import { PatientOnVacationForm } from './PatientOnVacationForm';
import { InpatientDepartmentsOccupancyRateForm } from './InpatientDepartmentsOccupancyRateForm';
import { AmeliyatModule } from 'Modules/Tibbi_Surec/Ameliyat_Modulu/AmeliyatModule';
import { OzellikliBakimIzlemForm } from './OzellikliBakimIzlemForm';

const routes: Routes = [
    {
        path: '',
        component: InPatientPhysicianApplicationForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule,
        HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, RouterModule.forChild(routes),
        DiagnosisGridModule, DiagnosisGridReadOnlyModule, ProcedureRequestModule, TreatmentMaterialModule, FormEditorModule, ConsultationRequestModule, PatientHistoryModule, AtlasReportModule, HemsirelikIslemleriModule, HastaRaporlariModule, EpikrizModule,
        AmeliyatModule
    ],
    declarations: [
        InpatientAdmissionRequestForm, InPatientAdmissionClinicProcedure, LongInpatientReasonForm, ShortInpatientReasonForm,
        DietOrderDetailForm, DietOrderForm, InPatientAdmissionBaseForm,
        InPatientTreatmentClinicAcceptionForm, BedSelectionForm,
        InPatientPhysicianApplicationForm, CompanionApplicationForm,
        InpatientAdmissinDepositMaterialForm, DrugOrderGridComponent
        , NODTimeLineComponent, PatientOnVacationForm, InpatientDepartmentsOccupancyRateForm, OzellikliBakimIzlemForm
    ],
    exports: [
        InpatientAdmissionRequestForm, InPatientAdmissionClinicProcedure, LongInpatientReasonForm, ShortInpatientReasonForm,
        DietOrderDetailForm, DietOrderForm
        , InPatientAdmissionBaseForm, InPatientTreatmentClinicAcceptionForm,
        BedSelectionForm, CompanionApplicationForm,
        InpatientAdmissinDepositMaterialForm, DrugOrderGridComponent,
        NODTimeLineComponent, PatientOnVacationForm, InpatientDepartmentsOccupancyRateForm, OzellikliBakimIzlemForm
    ],
    entryComponents: [
        InpatientAdmissionRequestForm, InPatientAdmissionClinicProcedure, LongInpatientReasonForm, ShortInpatientReasonForm,
        DietOrderDetailForm, DietOrderForm
        , InPatientAdmissionBaseForm, InPatientTreatmentClinicAcceptionForm,
        BedSelectionForm, CompanionApplicationForm,
        InpatientAdmissinDepositMaterialForm, DrugOrderGridComponent,
        NODTimeLineComponent, InPatientPhysicianApplicationForm, PatientOnVacationForm
    ],
    providers: [ProcedureRequestSharedService]
})
export class YatanHastaModule {
    static dynamicComponentsMap = {
        InpatientAdmissionRequestForm,
        InPatientAdmissionClinicProcedure,
        DietOrderDetailForm,
        DietOrderForm,
        InPatientAdmissionBaseForm,
        InPatientTreatmentClinicAcceptionForm,
        BedSelectionForm,
        CompanionApplicationForm,
        InpatientAdmissinDepositMaterialForm,
        DrugOrderGridComponent,
        NODTimeLineComponent,
        InPatientPhysicianApplicationForm,
        LongInpatientReasonForm,
        ShortInpatientReasonForm,
        PatientOnVacationForm,
        InpatientDepartmentsOccupancyRateForm,
        OzellikliBakimIzlemForm
    };
}

