import { Component, ViewChild, HostListener } from '@angular/core';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

import { LaboratoryRequestSampleAcceptionForm } from "./LaboratoryRequestSampleAcceptionForm";
import { IHelpService } from 'Fw/Services/IHelpService';
import { helpFormModuleMap } from 'app/help-data';




@Component({
    selector: "laboratory-request-main-form",
    inputs: ['Model'],
    templateUrl: './LaboratoryRequestMainForm.html',
    providers: [SystemApiService],
})
export class LaboratoryRequestMainForm {
    @ViewChild(LaboratoryRequestSampleAcceptionForm) sampleAcceptForm: LaboratoryRequestSampleAcceptionForm;

    public ShowAcceptedForm : boolean = false;

    select(data: any) {
        this.sampleAcceptForm.LaboratoryWorkListItemMasterModel = data;
        if (data == null){
            this.ShowAcceptedForm = true;
        }else{
            this.ShowAcceptedForm = false;
        }
    }

    select2(data: any) {
        this.sampleAcceptForm.QueryParameter = data;
        if (data == null){
            this.ShowAcceptedForm = true;
        }else{
            this.ShowAcceptedForm = false;
        }
    }

    btnListClick(data: any) {
        this.sampleAcceptForm.LaboratoryWorkListItemMasterModel = null;
        //this.sampleAcceptForm.loadViewModel();
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