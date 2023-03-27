import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule, XHRBackend } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { RouterModule, Routes } from '@angular/router';
import { GenelLcdForm } from './GenelLcdForm';
import { SimpleTimer } from 'ng2-simple-timer';
import { SurgeryLcdForm } from './SurgeryLcdForm';
import { ApiXHRBackend } from 'app/Fw/Services/HttpInterceptor';
import { GeneralLcdForm } from './GeneralLcdForm';
import { PoliclinicLcdForm } from './PoliclinicLcdForm';
import { CallPatientForm } from './CallPatientForm';
import { EmergenyCallPatientForm } from './EmergencyCallPatientForm';
import { PolLcdCalledPatientForm } from './PolLcdCalledPatientForm';
import { EmergencyLcdForm } from './EmergencyLcdForm';
import { NewBornLcdForm } from './NewBornLcdForm';

const routes: Routes = [
    {
        path: '',
        component: GenelLcdForm,
    },
    { path: 'hastacagri', component: GenelLcdForm },
    
    { path: 'surgery', component: SurgeryLcdForm },
    { path: 'emergency', component: EmergencyLcdForm },
    { path: 'generalLcdForm', component: GeneralLcdForm },
    { path: 'policlinicLcdForm', component: PoliclinicLcdForm },
    { path: 'emergenyCallPatientForm', component: EmergenyCallPatientForm },
    { path: 'polLcdCalledPatientForm', component: PolLcdCalledPatientForm },
    { path: 'newBorn', component: NewBornLcdForm },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, RouterModule.forChild(routes)],
    declarations: [GenelLcdForm, SurgeryLcdForm, EmergencyLcdForm, GeneralLcdForm, PoliclinicLcdForm, CallPatientForm, EmergenyCallPatientForm, PolLcdCalledPatientForm, NewBornLcdForm],
    exports: [GenelLcdForm],
    entryComponents: [GenelLcdForm],
    providers: [SimpleTimer,

        { provide: XHRBackend, useClass: ApiXHRBackend },

    ]
})
export class HastaCagriModule { 
	static dynamicComponentsMap = {
		GenelLcdForm
	};
}


