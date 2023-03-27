//$9FD6D508
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { VoucherMainForm } from './VoucherMainForm';
import { AccountVoucherEntryForm } from './AccountVoucherEntryForm';
import { AccountVoucherCodeDefinitionForm } from './AccountVoucherCodeDefinitionForm';
import { AccountPeriodDefintionForm } from './AccountPeriodDefintionForm';
import { AccountDayTermForm } from './AccountDayTermForm';
import { DefinitionFormModule } from 'app/DefinitionForm/definition-form.module';
import { AccountTotalDebtForm } from './AccountTotalDebtForm';

const routes: Routes = [
    {
        path: '',
        component: VoucherMainForm,
    }, {
        path: 'gelirgider',
        component: VoucherMainForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, DefinitionFormModule,
        RouterModule.forChild(routes)],
    declarations: [VoucherMainForm, AccountVoucherEntryForm, AccountVoucherCodeDefinitionForm, AccountPeriodDefintionForm, AccountTotalDebtForm, AccountDayTermForm],
    exports: [VoucherMainForm, AccountVoucherEntryForm, AccountVoucherCodeDefinitionForm, AccountPeriodDefintionForm, AccountTotalDebtForm, AccountDayTermForm],
    entryComponents: [VoucherMainForm, AccountVoucherEntryForm, AccountVoucherCodeDefinitionForm, AccountPeriodDefintionForm, AccountTotalDebtForm, AccountDayTermForm]
})
export class MDS058GelirGiderTakipIslemleriModule {
	static dynamicComponentsMap = {
		VoucherMainForm, 
		AccountVoucherEntryForm, 
		AccountVoucherCodeDefinitionForm, 
		AccountPeriodDefintionForm, 
		AccountTotalDebtForm, 
		AccountDayTermForm
	};
 }