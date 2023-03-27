//$DFF5FD96
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from "Fw/FwModule";
import { UserMessageReadingForm } from "./UserMessageReadingForm";
import { UserMessageSendingForm } from "./UserMessageSendingForm";
import { UserMessageBoxForm } from "./UserMessageBoxForm";
import { HttpClientModule } from '@angular/common/http';
const routes: Routes = [
    {
        path: '',
        component: UserMessageReadingForm,
    },
    { path: 'oku', component: UserMessageReadingForm },
    { path: 'gonder', component: UserMessageSendingForm },
    { path: 'box', component: UserMessageBoxForm },

];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, HttpClientModule,
        RouterModule.forChild(routes)],
    declarations: [UserMessageReadingForm, UserMessageSendingForm, UserMessageBoxForm],
    exports: [UserMessageReadingForm, UserMessageSendingForm, UserMessageBoxForm],
    entryComponents: [UserMessageReadingForm, UserMessageSendingForm, UserMessageBoxForm]
})
export class KullaniciMesajlariModule {
	static dynamicComponentsMap = {
		UserMessageReadingForm, 
		UserMessageSendingForm, 
		UserMessageBoxForm
	};

}

