//$22162BC5
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BaseStockActionDetailInForm } from './BaseStockActionDetailInForm';
import { BaseStockActionDetailForm } from './BaseStockActionDetailForm';
import { StockOutForm } from './StockOutForm';
import { StockActionBaseForm } from './StockActionBaseForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule],
    declarations: [
        BaseStockActionDetailInForm, BaseStockActionDetailForm, StockOutForm, StockActionBaseForm
    ],
    exports: [
        BaseStockActionDetailInForm, BaseStockActionDetailForm, StockOutForm, StockActionBaseForm
    ],
    entryComponents: [
        BaseStockActionDetailInForm, BaseStockActionDetailForm, StockOutForm, StockActionBaseForm
    ]
})
export class StokEvrenselModule {
	static dynamicComponentsMap = {
		BaseStockActionDetailInForm, 
		BaseStockActionDetailForm, 
		StockOutForm, 
		StockActionBaseForm
	};
 }

