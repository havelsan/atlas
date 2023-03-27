//$5029A774
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ChattelDocumentInputWithAccountancyCompletedForm } from './ChattelDocumentInputWithAccountancyCompletedForm';
import { ChattelDocumentInputWithAccountancyNewForm } from './ChattelDocumentInputWithAccountancyNewForm';
import { BaseChattelDocumentInputWithAccountancyForm } from './BaseChattelDocumentInputWithAccountancyForm';
import { ChattelDocumentInputWithAccountancyApproveForm } from './ChattelDocumentInputWithAccountancyApproveForm';
import { BaseChattelDocumentForm } from './BaseChattelDocumentForm';
import { ChattelDocumentOutputWithAccountancyCompletedForm } from './ChattelDocumentOutputWithAccountancyCompletedForm';
import { ChattelDocumentOutputWithAccountancyApproveForm } from './ChattelDocumentOutputWithAccountancyApproveForm';
import { BaseChattelDocumentOutputWithAccountancy } from './BaseChattelDocumentOutputWithAccountancy';
import { ChattelDocumentOutputWithAccountancyNewForm } from './ChattelDocumentOutputWithAccountancyNewForm';
import { ChattelDocumentWithPurchaseApproveForm } from './ChattelDocumentWithPurchaseApproveForm';
import { BaseChattelDocumentWithPurchaseForm } from './BaseChattelDocumentWithPurchaseForm';
import { ChattelDocumentWithPurchaseCompletedForm } from './ChattelDocumentWithPurchaseCompletedForm';
import { ChattelDocumentWithPurchaseNewForm } from './ChattelDocumentWithPurchaseNewForm';
import { ChattelDocumentWithPurchaseFixDocumentForm } from './ChattelDocumentWithPurchaseFixDocumentForm';
import { ChattelDocumentInputWithAccountancyFixDocument } from './ChattelDocumentInputWithAccountancyFixDocument';
import { LogisticFormsModule } from 'app/Logistic/LogisticFormsModule';

const routes: Routes = [
    {
        path: '',
        component: ChattelDocumentInputWithAccountancyCompletedForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, LogisticFormsModule,
        RouterModule.forChild(routes)],
    declarations: [
        ChattelDocumentInputWithAccountancyCompletedForm, ChattelDocumentInputWithAccountancyNewForm,
        BaseChattelDocumentInputWithAccountancyForm, ChattelDocumentInputWithAccountancyApproveForm,
        BaseChattelDocumentForm, ChattelDocumentOutputWithAccountancyCompletedForm,
        ChattelDocumentOutputWithAccountancyApproveForm, BaseChattelDocumentOutputWithAccountancy,
        ChattelDocumentOutputWithAccountancyNewForm,
        ChattelDocumentWithPurchaseApproveForm, BaseChattelDocumentWithPurchaseForm,
        ChattelDocumentWithPurchaseCompletedForm, ChattelDocumentWithPurchaseNewForm, ChattelDocumentWithPurchaseFixDocumentForm,
        ChattelDocumentInputWithAccountancyFixDocument
    ],
    exports: [
        ChattelDocumentInputWithAccountancyCompletedForm, ChattelDocumentInputWithAccountancyNewForm,
        BaseChattelDocumentInputWithAccountancyForm, ChattelDocumentInputWithAccountancyApproveForm,
        BaseChattelDocumentForm, ChattelDocumentOutputWithAccountancyCompletedForm,
        ChattelDocumentOutputWithAccountancyApproveForm, BaseChattelDocumentOutputWithAccountancy,
        ChattelDocumentOutputWithAccountancyNewForm,
        ChattelDocumentWithPurchaseApproveForm, BaseChattelDocumentWithPurchaseForm,
        ChattelDocumentWithPurchaseCompletedForm, ChattelDocumentWithPurchaseNewForm, ChattelDocumentWithPurchaseFixDocumentForm,
        ChattelDocumentInputWithAccountancyFixDocument
    ],
    entryComponents: [
        ChattelDocumentInputWithAccountancyCompletedForm, ChattelDocumentInputWithAccountancyNewForm,
        BaseChattelDocumentInputWithAccountancyForm, ChattelDocumentInputWithAccountancyApproveForm,
        BaseChattelDocumentForm, ChattelDocumentOutputWithAccountancyCompletedForm,
        ChattelDocumentOutputWithAccountancyApproveForm, BaseChattelDocumentOutputWithAccountancy,
        ChattelDocumentOutputWithAccountancyNewForm,
        ChattelDocumentWithPurchaseApproveForm, BaseChattelDocumentWithPurchaseForm,
        ChattelDocumentWithPurchaseCompletedForm, ChattelDocumentWithPurchaseNewForm, ChattelDocumentWithPurchaseFixDocumentForm,
        ChattelDocumentInputWithAccountancyFixDocument
    ]
})
export class TasinirMalIslemModule {
    static dynamicComponentsMap = {
        ChattelDocumentInputWithAccountancyCompletedForm,
        ChattelDocumentInputWithAccountancyNewForm,
        BaseChattelDocumentInputWithAccountancyForm,
        ChattelDocumentInputWithAccountancyApproveForm,
        BaseChattelDocumentForm,
        ChattelDocumentOutputWithAccountancyCompletedForm,
        ChattelDocumentOutputWithAccountancyApproveForm,
        BaseChattelDocumentOutputWithAccountancy,
        ChattelDocumentOutputWithAccountancyNewForm,
        ChattelDocumentWithPurchaseApproveForm,
        BaseChattelDocumentWithPurchaseForm,
        ChattelDocumentWithPurchaseCompletedForm,
        ChattelDocumentWithPurchaseNewForm,
        ChattelDocumentWithPurchaseFixDocumentForm,
        ChattelDocumentInputWithAccountancyFixDocument
    };
}

