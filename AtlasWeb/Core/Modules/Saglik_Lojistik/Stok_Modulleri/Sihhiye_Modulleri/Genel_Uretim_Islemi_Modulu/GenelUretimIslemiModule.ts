//$5D358C01
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { GeneralProductionActionCompForm } from './GeneralProductionActionCompForm';
import { GeneralProductionActionAppForm } from './GeneralProductionActionAppForm';
import { GeneralProductionActionNewForm } from './GeneralProductionActionNewForm';
import { BaseGeneralProductionActionFrom } from './BaseGeneralProductionActionFrom';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [
        GeneralProductionActionCompForm, GeneralProductionActionAppForm, GeneralProductionActionNewForm,
        BaseGeneralProductionActionFrom
    ],
    exports: [
        GeneralProductionActionCompForm, GeneralProductionActionAppForm, GeneralProductionActionNewForm,
        BaseGeneralProductionActionFrom
    ],
    entryComponents: [
        GeneralProductionActionCompForm, GeneralProductionActionAppForm, GeneralProductionActionNewForm,
        BaseGeneralProductionActionFrom
    ]
})
export class GenelUretimIslemiModule {
	static dynamicComponentsMap = {
		GeneralProductionActionCompForm, 
		GeneralProductionActionAppForm, 
		GeneralProductionActionNewForm, 
		BaseGeneralProductionActionFrom
	};
 }

