//$2E162944
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ManagerPrescriptionCountForm } from './ManagerPrescriptionCountForm'; 
import { RouterModule, Routes } from '@angular/router';
const routes: Routes = [
    {
        path: '',
        component: ManagerPrescriptionCountForm
    }

    //{ path: 'receteistatistik', component: ManagerPrescriptionCountForm }
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,    
            RouterModule.forChild(routes)],
declarations: [
    ManagerPrescriptionCountForm
 ],
exports: [
    ManagerPrescriptionCountForm
]
})
export class ReceteIstatistikModule {
	static dynamicComponentsMap = {
		ManagerPrescriptionCountForm
	};
 }

