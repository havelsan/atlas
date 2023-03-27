import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { InvoiceTermForm } from './InvoiceTermForm';
import { InvoiceAccountancyForm } from './InvoiceAccountancyForm';
import { InvoiceTermFormTab } from './InvoiceTermFormTab';
import { InvoiceCollectionTab } from './InvoiceCollectionTab';
import { InvoiceCollectionSearchForm } from './InvoiceCollectionSearchForm';
import { InvoicePaymentSearchForm } from './InvoicePaymentSearchForm';
import { InvoicePaymentForm } from './InvoicePaymentForm';
import { InvoiceCollectionSearchFormTabContainer } from './InvoiceCollectionSearchFormTabContainer';
import { InvoiceCollectionBoundFormTab } from './InvoiceCollectionBoundFormTab';
import { InvoiceSEPSearchForm } from './InvoiceSEPSearchForm';
import { InvoiceSEPSearchResultForm } from './InvoiceSEPSearchResultForm';
import { InvoiceEpisodeSearchResultForm } from './InvoiceEpisodeSearchResultForm';
import { InvoiceSEPForm } from './InvoiceSEPForm';
import { Invoice } from './Invoice';
import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { DiagnosisGridModule } from "Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule";
import { InvoiceAllInOneFormTab } from './InvoiceAllInOneFormTab';
import { InvoiceAllInOneForm } from './InvoiceAllInOneForm';
import { InvoiceAllInOneTabService } from './InvoiceAllInOneTabService';
import { InvoiceTabSerivce } from './InvoiceTabSerivce';
import { InvoiceTermFormTabService } from './InvoiceTermFormTabService';
import { AtlasReportModule } from 'app/Report/AtlasReportModule';
import { InvoiceReportForm } from './InvoiceReportForm';

const routes: Routes = [
    {
        path: '',
        component: Invoice,
    },
    {
        path: 'all',
        component: InvoiceAllInOneFormTab,
    },
    { path: 'donem', component: InvoiceTermFormTab },
    { path: 'icmal', component: InvoiceCollectionSearchFormTabContainer },
    { path: 'tahsilat', component: InvoicePaymentSearchForm },
    { path: 'report', component: InvoiceReportForm }
];

@NgModule({
    declarations: [InvoiceTermForm, InvoiceAccountancyForm, InvoiceTermFormTab, InvoiceCollectionBoundFormTab, InvoiceCollectionTab, InvoiceCollectionSearchForm, InvoiceCollectionSearchFormTabContainer, InvoiceSEPSearchResultForm,
        InvoiceEpisodeSearchResultForm, InvoiceSEPSearchForm, InvoiceSEPForm, Invoice, InvoicePaymentForm, InvoicePaymentSearchForm, InvoiceAllInOneFormTab, InvoiceAllInOneForm,InvoiceReportForm],

    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule, DiagnosisGridModule,AtlasReportModule,
        RouterModule.forChild(routes)],

    exports: [InvoiceTermForm, InvoiceAccountancyForm, InvoiceTermFormTab, InvoiceCollectionBoundFormTab, InvoiceCollectionTab, InvoiceCollectionSearchForm, InvoiceCollectionSearchFormTabContainer, InvoiceSEPSearchResultForm,
        InvoiceEpisodeSearchResultForm, InvoiceSEPSearchForm, InvoiceSEPForm, Invoice, InvoicePaymentForm, InvoicePaymentSearchForm, InvoiceAllInOneFormTab, InvoiceAllInOneForm,InvoiceReportForm],

    entryComponents: [InvoiceTermForm, InvoiceAccountancyForm, InvoiceTermFormTab, InvoiceCollectionBoundFormTab, InvoiceCollectionTab, InvoiceCollectionSearchForm, InvoiceCollectionSearchFormTabContainer, InvoiceSEPSearchResultForm,
        InvoiceEpisodeSearchResultForm, InvoiceSEPSearchForm, InvoiceSEPForm, Invoice, InvoicePaymentForm, InvoicePaymentSearchForm, InvoiceAllInOneFormTab, InvoiceAllInOneForm,InvoiceReportForm],

    providers: [GetMedulaDefinitionService, InvoiceAllInOneTabService, InvoiceTabSerivce,InvoiceTermFormTabService]
})
export class InvoiceModule {
    static dynamicComponentsMap = {
        InvoiceTermForm,
        InvoiceAccountancyForm,
        InvoiceTermFormTab,
        InvoiceCollectionBoundFormTab,
        InvoiceCollectionTab,
        InvoiceCollectionSearchForm,
        InvoiceCollectionSearchFormTabContainer,
        InvoiceSEPSearchResultForm,
        InvoiceEpisodeSearchResultForm,
        InvoiceSEPSearchForm,
        InvoiceSEPForm,
        Invoice,
        InvoicePaymentForm,
        InvoicePaymentSearchForm,
        InvoiceAllInOneFormTab,
        InvoiceAllInOneForm,
        InvoiceReportForm
    };

}