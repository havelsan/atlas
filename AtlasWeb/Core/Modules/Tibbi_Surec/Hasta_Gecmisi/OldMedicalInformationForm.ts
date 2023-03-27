//$C92E302F
import { Component, OnInit, NgZone } from '@angular/core';
import { OldMedicalInformationFormViewModel } from './OldMedicalInformationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MedicalInformation } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OldMedicalInformationForm',
    templateUrl: './OldMedicalInformationForm.html',
    providers: [MessageService]
})
export class OldMedicalInformationForm extends TTVisual.TTForm implements OnInit {
    public oldMedicalInformationFormViewModel: OldMedicalInformationFormViewModel = new OldMedicalInformationFormViewModel();
    public get _MedicalInformation(): MedicalInformation {
        return this._TTObject as MedicalInformation;
    }
    private OldMedicalInformationForm_DocumentUrl: string = '/api/MedicalInformationService/OldMedicalInformationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('MEDICALINFORMATION', 'OldMedicalInformationForm');
        this._DocumentServiceUrl = this.OldMedicalInformationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MedicalInformation();
        this.oldMedicalInformationFormViewModel = new OldMedicalInformationFormViewModel();
        this._ViewModel = this.oldMedicalInformationFormViewModel;
        this.oldMedicalInformationFormViewModel._MedicalInformation = this._TTObject as MedicalInformation;
    }

    protected loadViewModel() {
        let that = this;

        that.oldMedicalInformationFormViewModel = this._ViewModel as OldMedicalInformationFormViewModel;
        that._TTObject = this.oldMedicalInformationFormViewModel._MedicalInformation;
        if (this.oldMedicalInformationFormViewModel == null)
            this.oldMedicalInformationFormViewModel = new OldMedicalInformationFormViewModel();
        if (this.oldMedicalInformationFormViewModel._MedicalInformation == null)
            this.oldMedicalInformationFormViewModel._MedicalInformation = new MedicalInformation();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldMedicalInformationFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
