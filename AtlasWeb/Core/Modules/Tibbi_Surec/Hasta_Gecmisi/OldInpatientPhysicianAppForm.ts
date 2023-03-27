//$94AFAA01
import { Component, OnInit, NgZone } from '@angular/core';
import { OldInpatientPhysicianAppFormViewModel } from './OldInpatientPhysicianAppFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InPatientPhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OldInpatientPhysicianAppForm',
    templateUrl: './OldInpatientPhysicianAppForm.html',
    providers: [MessageService]
})
export class OldInpatientPhysicianAppForm extends TTVisual.TTForm implements OnInit {
    public oldInpatientPhysicianAppFormViewModel: OldInpatientPhysicianAppFormViewModel = new OldInpatientPhysicianAppFormViewModel();
    public get _InPatientPhysicianApplication(): InPatientPhysicianApplication {
        return this._TTObject as InPatientPhysicianApplication;
    }
    private OldInpatientPhysicianAppForm_DocumentUrl: string = '/api/InPatientPhysicianApplicationService/OldInpatientPhysicianAppForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('INPATIENTPHYSICIANAPPLICATION', 'OldInpatientPhysicianAppForm');
        this._DocumentServiceUrl = this.OldInpatientPhysicianAppForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InPatientPhysicianApplication();
        this.oldInpatientPhysicianAppFormViewModel = new OldInpatientPhysicianAppFormViewModel();
        this._ViewModel = this.oldInpatientPhysicianAppFormViewModel;
        this.oldInpatientPhysicianAppFormViewModel._InPatientPhysicianApplication = this._TTObject as InPatientPhysicianApplication;
    }

    protected loadViewModel() {
        let that = this;

        that.oldInpatientPhysicianAppFormViewModel = this._ViewModel as OldInpatientPhysicianAppFormViewModel;
        that._TTObject = this.oldInpatientPhysicianAppFormViewModel._InPatientPhysicianApplication;
        if (this.oldInpatientPhysicianAppFormViewModel == null)
            this.oldInpatientPhysicianAppFormViewModel = new OldInpatientPhysicianAppFormViewModel();
        if (this.oldInpatientPhysicianAppFormViewModel._InPatientPhysicianApplication == null)
            this.oldInpatientPhysicianAppFormViewModel._InPatientPhysicianApplication = new InPatientPhysicianApplication();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldInpatientPhysicianAppFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
