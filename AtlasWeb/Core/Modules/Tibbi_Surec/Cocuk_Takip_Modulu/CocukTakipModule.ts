import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { VisitDetailsForm } from './VisitDetailsForm';
import { ChildGrowthStandardsForm } from './ChildGrowthStandardsForm';
import { FormEditorModule } from 'app/FormEditor/form-editor.module'; //<atlas-form-editor  için

const routes: Routes = [
    {
        path: '',
        component: ChildGrowthStandardsForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, FormEditorModule,
                RouterModule.forChild(routes)],
declarations: [
ChildGrowthStandardsForm, VisitDetailsForm
 ],
 exports: [
 ChildGrowthStandardsForm, VisitDetailsForm
  ],
  entryComponents: [
  ChildGrowthStandardsForm, VisitDetailsForm
   ]
})
export class CocukTakipModule {
	static dynamicComponentsMap = {
		ChildGrowthStandardsForm, 
		VisitDetailsForm
	};
 }

