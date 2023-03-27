//$324BCE72
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { Eye_Examination } from './Eye_Examination';
import { HastaRaporlariModule } from '../Hasta_Raporlari_Modulu/HastaRaporlariModule';

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, HastaRaporlariModule],
declarations: [
Eye_Examination
 ],
 exports: [
 Eye_Examination
  ],
  entryComponents: [
  Eye_Examination
   ]
})
export class GozMuayeneModule {
	static dynamicComponentsMap = {
		Eye_Examination
	};
 }

