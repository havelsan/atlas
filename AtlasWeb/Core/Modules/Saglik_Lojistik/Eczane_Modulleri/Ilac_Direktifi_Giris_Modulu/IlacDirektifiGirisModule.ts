//$5944EC89
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DrugOrderIntroductionNewForm } from './DrugOrderIntroductionNewForm';
import { ESignatureModule } from 'app/ESignature/esignature.module';
import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, ESignatureModule, DiagnosisGridModule],
declarations: [ DrugOrderIntroductionNewForm ],
exports: [ DrugOrderIntroductionNewForm ],
entryComponents: [ DrugOrderIntroductionNewForm ]
})
export class IlacDirektifiGirisModule {
	static dynamicComponentsMap = {
		DrugOrderIntroductionNewForm
	};
 }

