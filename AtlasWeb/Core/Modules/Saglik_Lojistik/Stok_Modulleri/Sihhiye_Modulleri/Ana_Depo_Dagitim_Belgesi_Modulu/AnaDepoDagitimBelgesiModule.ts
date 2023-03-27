//$8CCD9D8D
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MainStoreDistDocNewForm } from './MainStoreDistDocNewForm';
import { MainStoreDistDocApprovalForm } from './MainStoreDistDocApprovalForm';
import { MainStoreDistDocComplatedForm } from './MainStoreDistDocComplatedForm';
import { BaseMainStoreDistributionDocForm } from './BaseMainStoreDistributionDocForm';
import { MaterialMultiSelectModule } from '../../MaterialMultiSelect/MaterialMultiSelectModule';

// const routes: Routes = [
//     {
//         path: '',
//         component: BaseMainStoreDistributionDocForm,
//     },
// ];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,MaterialMultiSelectModule
    ],
    declarations: [
        BaseMainStoreDistributionDocForm, MainStoreDistDocNewForm, MainStoreDistDocApprovalForm,
        MainStoreDistDocComplatedForm
    ],
    exports: [
        BaseMainStoreDistributionDocForm, MainStoreDistDocNewForm, MainStoreDistDocApprovalForm,
        MainStoreDistDocComplatedForm
    ],
    entryComponents: [BaseMainStoreDistributionDocForm,MainStoreDistDocNewForm, MainStoreDistDocApprovalForm,
        MainStoreDistDocComplatedForm]
})
export class AnaDepoDagitimBelgesiModule {
    static dynamicComponentsMap = {
        BaseMainStoreDistributionDocForm,
        MainStoreDistDocApprovalForm,
        MainStoreDistDocComplatedForm,
        MainStoreDistDocNewForm
    };
}

