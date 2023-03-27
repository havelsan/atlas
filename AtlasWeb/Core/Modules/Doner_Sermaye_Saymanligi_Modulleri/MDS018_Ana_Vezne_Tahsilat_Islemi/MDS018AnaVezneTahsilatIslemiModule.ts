//$06B5B83E
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MainCashOfficeOperationForm } from './MainCashOfficeOperationForm';

const routes: Routes = [
    {
        path: '',
        component: MainCashOfficeOperationForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
        RouterModule.forChild(routes)],
    declarations: [
        MainCashOfficeOperationForm
    ],
    exports: [
        MainCashOfficeOperationForm
    ],
    entryComponents: [
        MainCashOfficeOperationForm
    ]
})
export class MDS018AnaVezneTahsilatIslemiModule {
	static dynamicComponentsMap = {
		MainCashOfficeOperationForm
	};
 }

