import { NgModule, ModuleWithProviders} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { HcRejectedView } from './Views/HcRejectedView';
import { HcReportView } from './Views/HcReportView';
import { PatientView} from './Views/PatientView';
import { PatientListView } from './Views/PatientListView';
import { VoucherDistributingDocumentNewForm } from './Views/VoucherDistributingDocumentNewForm';

import { PatientService } from './Services/PatientService';
import { DevExtremeModule } from 'devextreme-angular';

@NgModule({
    declarations: [HcRejectedView, HcReportView, PatientView, PatientListView, VoucherDistributingDocumentNewForm],
    imports: [CommonModule, FormsModule, FwModule, DevExtremeModule],
    exports: [HcRejectedView, HcReportView, PatientView, PatientListView, VoucherDistributingDocumentNewForm],
    entryComponents: [HcRejectedView, HcReportView, PatientView, PatientListView, VoucherDistributingDocumentNewForm]
})
export class PatientModule {
	static dynamicComponentsMap = {
		HcRejectedView, 
		HcReportView, 
		PatientView, 
		PatientListView, 
		VoucherDistributingDocumentNewForm
	};

    static forRoot(): ModuleWithProviders<PatientModule> {
        return {
            ngModule: PatientModule,
            providers: [PatientService]
        };
    }
}