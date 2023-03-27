import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { CashOfficeWorkListForm } from './CashOfficeWorkListForm';

const routes: Routes = [
    {
        path: '',
        component: CashOfficeWorkListForm,
    },
];

@NgModule({
    declarations: [],
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule,
    RouterModule.forChild(routes)],
    providers: [],
    exports: []
})
export class CashOfficeWorkListModule {
	static dynamicComponentsMap = {

	};

}