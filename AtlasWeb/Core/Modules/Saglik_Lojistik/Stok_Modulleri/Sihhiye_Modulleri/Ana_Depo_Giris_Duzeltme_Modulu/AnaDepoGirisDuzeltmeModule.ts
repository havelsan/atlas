//$DF0A27D7
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { InheldIncreasingProcessForm } from './InheldIncreasingProcessForm';
import { ActionInfoCorrectionForm } from './ActionInfoCorrectionForm';

/*const routes: Routes = [
    {
        path: '',
        component: InheldIncreasingProcessForm,
    },
];*/

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [
        InheldIncreasingProcessForm, ActionInfoCorrectionForm
    ],
    exports: [
        InheldIncreasingProcessForm, ActionInfoCorrectionForm
    ],
    entryComponents: [
        InheldIncreasingProcessForm, ActionInfoCorrectionForm
    ]
})
export class AnaDepoGirisDuzeltmeModule {
    static dynamicComponentsMap = {
        InheldIncreasingProcessForm,
        ActionInfoCorrectionForm,
    };
}

