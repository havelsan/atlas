//$E5C838D5
import { NgModule } from '@angular/core';
import { Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from "Fw/FwModule";
import { ChngeStockLvlTypeComlatedForm } from "./ChngeStockLvlTypeComlatedForm";
import { ChangeStockLevelTypeForm } from "./ChangeStockLevelTypeForm";

const routes: Routes = [
    {
        path: ''

    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
declarations: [
ChngeStockLvlTypeComlatedForm, ChangeStockLevelTypeForm
 ],
 exports: [
 ChngeStockLvlTypeComlatedForm, ChangeStockLevelTypeForm
  ],
entryComponents: [
  ChngeStockLvlTypeComlatedForm, ChangeStockLevelTypeForm
   ]
})
export class MalDurumuDegistirmeModule {
	static dynamicComponentsMap = {
		ChngeStockLvlTypeComlatedForm, 
		ChangeStockLevelTypeForm
	};
 }

