import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DispatchExaminationForm } from './DispatchExaminationForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';
import { ProcedureRequestModule } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestModule';
import { ProcedureRequestSharedService } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestSharedService';


@NgModule({
    imports: [CommonModule, HttpModule, DevExtremeModule, FwModule,
        PatientDemographicsModule, DiagnosisGridModule, ProcedureRequestModule],
    declarations: [
        DispatchExaminationForm
    ],
    exports: [
        DispatchExaminationForm
    ],
    entryComponents: [
        DispatchExaminationForm
    ],
    providers: [
        ProcedureRequestSharedService
    ]

})
export class DispatchExaminationPanelModule {
	static dynamicComponentsMap = {
		DispatchExaminationForm
	};


}

