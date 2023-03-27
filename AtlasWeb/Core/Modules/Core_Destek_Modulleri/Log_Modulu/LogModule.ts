//$B88AB63F
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { AuditQueryForm } from './AuditQueryForm';
import { ShowAuditForm } from './ShowAuditForm';


const routes: Routes = [
    {
        path: '',
        component: AuditQueryForm,
    },
    { path: 'auditform', component: AuditQueryForm },
    { path: 'showauditform', component: ShowAuditForm }

];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                RouterModule.forChild(routes)],
declarations: [
    AuditQueryForm, ShowAuditForm
 ],
exports: [
    AuditQueryForm, ShowAuditForm
 ],
 entryComponents: [
    AuditQueryForm, ShowAuditForm
 ]

})
export class LogModule {
	static dynamicComponentsMap = {
		AuditQueryForm, 
		ShowAuditForm
	};
 }

