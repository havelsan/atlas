
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';


import { AnamnesisForm } from './AnamnesisForm';
import { AnamnesisHistoryForm } from './AnamnesisHistoryForm';
import { VitalSingsModule } from 'Modules/Tibbi_Surec/Vital_Bulgular/VitalSingsModule';
import { AnamnesisNewForm } from './AnamnesisNewForm';

const routes: Routes = [
    {
        path: '',
        component: AnamnesisForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, VitalSingsModule,
    RouterModule.forChild(routes)],
    declarations: [AnamnesisForm, AnamnesisHistoryForm, AnamnesisNewForm],
    entryComponents: [AnamnesisForm, AnamnesisHistoryForm, AnamnesisNewForm],
    exports: [AnamnesisForm, AnamnesisHistoryForm, AnamnesisNewForm]
})

export class AnamnezModule {
	static dynamicComponentsMap = {
		AnamnesisForm, 
        AnamnesisHistoryForm,
        AnamnesisNewForm
	};
 }

