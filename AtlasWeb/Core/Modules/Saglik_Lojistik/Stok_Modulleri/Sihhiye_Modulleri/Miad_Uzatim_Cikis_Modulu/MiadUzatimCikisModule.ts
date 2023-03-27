//$1B71BA86
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ExtendExpDateOutForm } from './ExtendExpDateOutForm';
import { ExtendExpDateOutCompFom } from './ExtendExpDateOutCompFom';
import { BaseExtendExpDateOutForm } from './BaseExtendExpDateOutForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [
        ExtendExpDateOutForm, ExtendExpDateOutCompFom, BaseExtendExpDateOutForm
     ],
     exports: [
         ExtendExpDateOutForm, ExtendExpDateOutCompFom, BaseExtendExpDateOutForm
      ],
      entryComponents: [
          ExtendExpDateOutForm, ExtendExpDateOutCompFom, BaseExtendExpDateOutForm
       ]
    })
    export class MiadUzatimCikisModule {
	static dynamicComponentsMap = {
		ExtendExpDateOutForm, 
		ExtendExpDateOutCompFom, 
		BaseExtendExpDateOutForm
	};
 }
