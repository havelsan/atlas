import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule, DxPieChartModule } from 'devextreme-angular';
import { DoctorPerformance } from './DoctorPerformance';
import { DoctorPerformanceTermBasedOperation } from './DoctorPerformanceTermBasedOperation';
import { DoctorPerformanceGeneralOperation } from './DoctorPerformanceGeneralOperation';
import { DoctorPerformancePersonalOperation } from './DoctorPerformancePersonalOperation';
import { DoctorPerformanceTermOperation } from './DoctorPerformanceTermOperation';
import { DoctorPerformanceRuleOperation } from './DoctorPerformanceRuleOperation';
import { DPTermSelectComponent } from './DPTermSelectComponent';
import { DoctorPerformancePermissionOperation } from './DoctorPerformancePermissionOperation';
import { DoctorPerformanceCommissionDecision } from './DoctorPerformanceCommissionDecision';


const routes: Routes = [
    {
        path: '',
        component: DoctorPerformance
    }
];

@NgModule({
    declarations: [DoctorPerformance, DoctorPerformancePermissionOperation, DoctorPerformanceTermBasedOperation, DoctorPerformanceCommissionDecision, DoctorPerformanceGeneralOperation, DoctorPerformancePersonalOperation, DoctorPerformanceTermOperation, DPTermSelectComponent, DoctorPerformanceRuleOperation],
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule, RouterModule.forChild(routes), DxPieChartModule]
    //,providers: [GetMedulaDefinitionService]
})
export class DoctorPerformanceModule {
	static dynamicComponentsMap = {

	};

}