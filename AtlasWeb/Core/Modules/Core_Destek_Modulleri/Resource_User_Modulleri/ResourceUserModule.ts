//$F6FDA019
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ResUserDefinitionForm } from './ResUserDefinitionForm';
import { ResUserForm } from './ResUserForm';
import { UserMainForm } from './UserMainForm';
import { DefinitionFormModule } from 'app/DefinitionForm/definition-form.module';


const routes: Routes = [
    {
        path: '',
        component: UserMainForm,
    }

];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, DefinitionFormModule,
                RouterModule.forChild(routes)],
declarations: [ 
    ResUserDefinitionForm, ResUserForm, UserMainForm
 ], 
exports: [ 
    ResUserDefinitionForm, ResUserForm, UserMainForm
 ], 
 entryComponents: [ 
     ResUserDefinitionForm, ResUserForm, UserMainForm
  ] 
})
export class ResourceUserModule {
	static dynamicComponentsMap = {
		ResUserDefinitionForm, 
		ResUserForm, 
		UserMainForm
	};
 }

