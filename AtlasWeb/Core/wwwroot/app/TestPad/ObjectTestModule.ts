import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { ObjectTestComponent } from './Views/object-test.component';

const routes: Routes = [
    {
        path: '',
        component: ObjectTestComponent,
    }
];

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule,
        RouterModule.forChild(routes)
    ],
    declarations: [ObjectTestComponent],
    bootstrap: [ObjectTestComponent]
})
export class ObjectTestModule { 
	static dynamicComponentsMap = {

	};
}