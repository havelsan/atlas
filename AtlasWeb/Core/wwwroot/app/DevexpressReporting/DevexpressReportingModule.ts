import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { HvlDynamicReportComponent } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DxReportDesignerModule } from 'devexpress-reporting-angular';
import { HvlReportEditComponent } from 'app/Fw/Components/Reporting/HvlReportEditComponent';
import { HvlDashboardComponent } from 'app/Fw/Components/Reporting/HvlDashboardComponent';
import { HvlDashboardEditComponent } from 'app/Fw/Components/Reporting/HvlDashboardEditComponent';
import { HvlReportEditFormComponent } from 'app/Fw/Components/Reporting/HvlReportEditFormComponent';


const paths: Routes = [
    {
        path: 'reporting',
        component: HvlReportEditComponent
    },
    {
        path: 'reporting/edit',
        component: HvlReportEditFormComponent
    },
    {
        path: 'dashboard',
        component: HvlDashboardComponent
    },
    {
        path: 'dashboard/edit',
        component: HvlDashboardEditComponent
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, DxReportDesignerModule, RouterModule.forChild(paths)],
    declarations: [HvlDynamicReportComponent, HvlReportEditComponent, HvlDashboardEditComponent, HvlDashboardComponent , HvlReportEditFormComponent],
    exports: [HvlDynamicReportComponent, HvlReportEditComponent, HvlDashboardEditComponent, HvlDashboardComponent , HvlReportEditFormComponent,  RouterModule],
    entryComponents: [HvlDynamicReportComponent, HvlReportEditComponent, HvlDashboardEditComponent, HvlDashboardComponent , HvlReportEditFormComponent]
})
export class DevexpressReportingModule { 
	static dynamicComponentsMap = {
		HvlDynamicReportComponent, 
		HvlReportEditComponent, 
		HvlDashboardEditComponent, 
		HvlDashboardComponent, 
		HvlReportEditFormComponent, 
		RouterModule
	};
}
