//$734A9EEF
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { EvdeSaglikBasvuruKaydetForm } from './EvdeSaglikBasvuruKaydetForm';
import { EvdeSaglikBasvuruSorgulaSilForm } from './EvdeSaglikBasvuruSorgulaSilForm';
import { EvdeSaglikHizmetEmirleriForm } from './EvdeSaglikHizmetEmirleriForm';

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [EvdeSaglikBasvuruKaydetForm, EvdeSaglikBasvuruSorgulaSilForm, EvdeSaglikHizmetEmirleriForm],
	exports: [EvdeSaglikBasvuruKaydetForm, EvdeSaglikBasvuruSorgulaSilForm, EvdeSaglikHizmetEmirleriForm],
	entryComponents: [EvdeSaglikBasvuruKaydetForm, EvdeSaglikBasvuruSorgulaSilForm, EvdeSaglikHizmetEmirleriForm]
})
export class EvdeSaglikHizmetleriModule {
	static dynamicComponentsMap = {
		EvdeSaglikBasvuruKaydetForm, 
		EvdeSaglikBasvuruSorgulaSilForm, 
		EvdeSaglikHizmetEmirleriForm
	};
 }

