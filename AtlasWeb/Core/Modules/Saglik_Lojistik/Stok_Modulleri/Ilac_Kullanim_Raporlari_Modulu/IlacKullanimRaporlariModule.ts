import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { FwModule } from 'Fw/FwModule';
import { DrugUsageReportForm } from './DrugUsageReportForm';
import { MaterialMultiSelectModule } from '../MaterialMultiSelect/MaterialMultiSelectModule';
import { PatientSearchModule } from 'Modules/Tibbi_Surec/PatientSearch/PatientSearchModule';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, MaterialMultiSelectModule, HttpClientModule, PatientSearchModule],
    declarations: [DrugUsageReportForm],
    exports: [DrugUsageReportForm],
    entryComponents: [DrugUsageReportForm]
})
export class IlacKullanimRaporlariModule {
	static dynamicComponentsMap = {
		DrugUsageReportForm
	};
 }

