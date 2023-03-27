import { Component, ViewChild, HostListener } from '@angular/core';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { LaboratoryMainProcedureFlowsForm } from "./LaboratoryMainProcedureFlowsForm";
import { IHelpService } from 'Fw/Services/IHelpService';
import { helpFormModuleMap } from 'app/help-data';

@Component({
    selector: "laboratory-main-form",
    inputs: ['Model'],
    templateUrl: './LaboratoryMainForm.html',
    providers: [SystemApiService],
})
export class LaboratoryMainForm {
    @ViewChild(LaboratoryMainProcedureFlowsForm) procedureFlowsForm: LaboratoryMainProcedureFlowsForm;


    select(data: any) {
        this.procedureFlowsForm.LaboratoryWorkListItemMasterModel = data;
        if (data.PatientStatus == "Y")
            this.procedureFlowsForm.btnPrintBarcodeDisabled = false;
    }

    btnListClick(data: any) {
        this.procedureFlowsForm.LaboratoryWorkListItemMasterModel = null;
        //this.procedureFlowsForm.loadViewModel();
    }


    @HostListener('window:keydown.f1', ['$event'])
    onKeyDown(event: KeyboardEvent) {
        const formName = this.constructor.name;
        if (formName && helpFormModuleMap.has(formName) === true) {
            const helpFileName = helpFormModuleMap.get(formName);
            const helpService: IHelpService = ServiceLocator.Injector.get(IHelpService);
            helpService.showHelp(helpFileName);
            return false;
        }
    }

}