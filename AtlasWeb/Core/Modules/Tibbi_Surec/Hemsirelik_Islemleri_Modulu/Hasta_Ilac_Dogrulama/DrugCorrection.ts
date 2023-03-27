//$E7D1164B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DrugCorrectionForm } from './DrugCorrectionForm';
import { SimpleTimer } from 'ng2-simple-timer';

const routes: Routes = [
    {
        path: '',
        component: DrugCorrectionForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
        RouterModule.forChild(routes)],
    declarations: [
        DrugCorrectionForm
    ],
    exports: [
        DrugCorrectionForm
    ],
    entryComponents: [
        DrugCorrectionForm
    ],
    providers: [SimpleTimer]
})
export class DrugCorrection {
	static dynamicComponentsMap = {
		DrugCorrectionForm
	};
 }

