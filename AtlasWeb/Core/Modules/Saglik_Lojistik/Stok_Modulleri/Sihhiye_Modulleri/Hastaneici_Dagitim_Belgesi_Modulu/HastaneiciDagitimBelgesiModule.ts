//$C36E80AF
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BaseSubStoreStockTransferForm } from './BaseSubStoreStockTransferForm';
import { SubStoreStockTransferApprovalForm } from './SubStoreStockTransferApprovalForm';
import { SubStoreStockTransferComplatedForm } from './SubStoreStockTransferComplatedForm';
import { SubStoreStockTransferStoreApprovalForm } from './SubStoreStockTransferStoreApprovalForm';
import { SubStoreStockTransferNewForm } from './SubStoreStockTransferNewForm';
import { MaterialMultiSelectModule } from '../../MaterialMultiSelect/MaterialMultiSelectModule';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, MaterialMultiSelectModule, FwModule],
    declarations: [
        BaseSubStoreStockTransferForm, SubStoreStockTransferApprovalForm, SubStoreStockTransferComplatedForm,
        SubStoreStockTransferStoreApprovalForm, SubStoreStockTransferNewForm
    ],
    exports: [
        BaseSubStoreStockTransferForm, SubStoreStockTransferApprovalForm, SubStoreStockTransferComplatedForm,
        SubStoreStockTransferStoreApprovalForm, SubStoreStockTransferNewForm
    ],
    entryComponents: [
        BaseSubStoreStockTransferForm, SubStoreStockTransferApprovalForm, SubStoreStockTransferComplatedForm,
        SubStoreStockTransferStoreApprovalForm, SubStoreStockTransferNewForm
    ]
})
export class XXXXXXiciDagitimBelgesiModule {
    static dynamicComponentsMap = {
        BaseSubStoreStockTransferForm,
        SubStoreStockTransferApprovalForm,
        SubStoreStockTransferComplatedForm,
        SubStoreStockTransferStoreApprovalForm,
        SubStoreStockTransferNewForm
    };
}

