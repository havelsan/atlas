//$0C1F7208
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BaseMainStoreStockTransferForm } from './BaseMainStoreStockTransferForm';
import { MainStoreStockTransferNewForm } from './MainStoreStockTransferNewForm';
import { MainStoreStockTransferApprovalForm } from './MainStoreStockTransferApprovalForm';
import { MainStoreStockTransferStoreAppropvalForm } from './MainStoreStockTransferStoreAppropvalForm';
import { MainStoreStockTransferCompletedForm } from './MainStoreStockTransferCompletedForm';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [
        BaseMainStoreStockTransferForm, MainStoreStockTransferNewForm, MainStoreStockTransferApprovalForm,
        MainStoreStockTransferCompletedForm, MainStoreStockTransferStoreAppropvalForm
    ],
    exports: [
        BaseMainStoreStockTransferForm, MainStoreStockTransferNewForm, MainStoreStockTransferApprovalForm,
        MainStoreStockTransferCompletedForm, MainStoreStockTransferStoreAppropvalForm
    ],
    entryComponents: [
        BaseMainStoreStockTransferForm, MainStoreStockTransferNewForm, MainStoreStockTransferApprovalForm,
        MainStoreStockTransferCompletedForm, MainStoreStockTransferStoreAppropvalForm
    ]
})
export class XXXXXXIciAnaDepoTransferModule {
	static dynamicComponentsMap = {
		BaseMainStoreStockTransferForm, 
		MainStoreStockTransferNewForm, 
		MainStoreStockTransferApprovalForm, 
		MainStoreStockTransferCompletedForm, 
		MainStoreStockTransferStoreAppropvalForm
	};
 }

