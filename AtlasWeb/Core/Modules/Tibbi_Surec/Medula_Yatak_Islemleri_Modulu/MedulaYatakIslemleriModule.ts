//$CE9A048C
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MedulaYatakEslestirmeForm } from './MedulaYatakEslestirmeForm';

const routes: Routes = [
    {
        path: '',
        component: MedulaYatakEslestirmeForm,
    }

];


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, RouterModule.forChild(routes)],
declarations: [
    MedulaYatakEslestirmeForm
 ],
 exports: [
     MedulaYatakEslestirmeForm
  ],
entryComponents: [
    MedulaYatakEslestirmeForm
   ]
})
export class MedulaYatakIslemleriModule {
	static dynamicComponentsMap = {
        MedulaYatakEslestirmeForm
	};
 }

