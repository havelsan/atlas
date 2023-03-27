import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { DxReportDesignerModule } from 'devexpress-reporting-angular';
import { KioskSurveyDefinition } from './Anket_Modulu/KioskSurveyDefinition';
import { KioskDeviceDefinition } from './Kiosk_Cihaz_Tanimi/KioskDeviceDefinition';
import { KioskNotificationDefinition } from './Duyuru_Tanimi/KioskNotificationDefinition';
import { ComplaintSuggestion } from './Sikayet_Oneri_Modulu/ComplaintSuggestion';
import { SurveyGraphicComponent } from './Anket_Modulu/SurveyGraphicComponent';


const paths: Routes = [
    {
        path: 'surveydefinition',
        component: KioskSurveyDefinition
    }, {
        path: 'kioskDevice',
        component: KioskDeviceDefinition
    }
    , {
        path: 'kioskNotification',
        component: KioskNotificationDefinition
    },
    {
        path: 'kioskComplaintSuggestion',
        component: ComplaintSuggestion
    }
];

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, DxReportDesignerModule, RouterModule.forChild(paths)],
    declarations: [KioskSurveyDefinition, KioskDeviceDefinition, KioskNotificationDefinition, ComplaintSuggestion,SurveyGraphicComponent],
    exports: [],
    entryComponents: [KioskSurveyDefinition, KioskDeviceDefinition, KioskNotificationDefinition, ComplaintSuggestion,SurveyGraphicComponent]
})
export class KioskDefinitionModule {
    static dynamicComponentsMap = {
        KioskSurveyDefinition,
        KioskDeviceDefinition,
        KioskNotificationDefinition,
        ComplaintSuggestion,
        SurveyGraphicComponent
        
    };
}
