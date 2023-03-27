//$2E162944
import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MedicalProcessMainForm } from './MedicalProcessMainForm';
import { EpisodeActionWorkListModule } from 'Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListModule';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, EpisodeActionWorkListModule],
    declarations: [
        MedicalProcessMainForm
    ],
    exports: [
       MedicalProcessMainForm
    ],
    entryComponents: [
       MedicalProcessMainForm
    ]
})
export class MedicalProcessMainModule {
	static dynamicComponentsMap = {
		MedicalProcessMainForm
	};

    static forRoot(): ModuleWithProviders<MedicalProcessMainModule> {
        return {
            ngModule: MedicalProcessMainModule
        };
    }
}

