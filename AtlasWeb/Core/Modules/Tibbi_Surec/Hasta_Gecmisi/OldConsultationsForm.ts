//$282B213D
import { Component, OnInit, NgZone } from '@angular/core';
import { OldConsultationsFormViewModel } from './OldConsultationsFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OldConsultationsForm',
    templateUrl: './OldConsultationsForm.html',
    providers: [MessageService]
})
export class OldConsultationsForm extends TTVisual.TTForm implements OnInit {
    public oldConsultationsFormViewModel: OldConsultationsFormViewModel = new OldConsultationsFormViewModel();
    public get _Consultation(): Consultation {
        return this._TTObject as Consultation;
    }
    private OldConsultationsForm_DocumentUrl: string = '/api/ConsultationService/OldConsultationsForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('CONSULTATION', 'OldConsultationsForm');
        this._DocumentServiceUrl = this.OldConsultationsForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Consultation();
        this.oldConsultationsFormViewModel = new OldConsultationsFormViewModel();
        this._ViewModel = this.oldConsultationsFormViewModel;
        this.oldConsultationsFormViewModel._Consultation = this._TTObject as Consultation;
    }

    protected loadViewModel() {
        let that = this;

        that.oldConsultationsFormViewModel = this._ViewModel as OldConsultationsFormViewModel;
        that._TTObject = this.oldConsultationsFormViewModel._Consultation;
        if (this.oldConsultationsFormViewModel == null)
            this.oldConsultationsFormViewModel = new OldConsultationsFormViewModel();
        if (this.oldConsultationsFormViewModel._Consultation == null)
            this.oldConsultationsFormViewModel._Consultation = new Consultation();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldConsultationsFormViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
