//$86D46304
import { Component, OnInit, NgZone } from '@angular/core';
import { AppointmentFormConsultationViewModel } from './AppointmentFormConsultationViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AppointmentFormBase } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AppointmentFormBase";
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';


@Component({
    selector: 'AppointmentFormConsultation',
    templateUrl: './AppointmentFormConsultation.html',
    providers: [MessageService]
})
export class AppointmentFormConsultation extends AppointmentFormBase implements OnInit {
    labelProtocolNo: TTVisual.ITTLabel;
    ProtocolNo: TTVisual.ITTTextBox;
    public appointmentFormConsultationViewModel: AppointmentFormConsultationViewModel = new AppointmentFormConsultationViewModel();
    public get _Consultation(): Consultation {
        return this._TTObject as Consultation;
    }
    private AppointmentFormConsultation_DocumentUrl: string = '/api/ConsultationService/AppointmentFormConsultation';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.AppointmentFormConsultation_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Consultation();
        this.appointmentFormConsultationViewModel = new AppointmentFormConsultationViewModel();
        this._ViewModel = this.appointmentFormConsultationViewModel;
        this.appointmentFormConsultationViewModel._Consultation = this._TTObject as Consultation;
    }

    protected loadViewModel() {
        let that = this;

        that.appointmentFormConsultationViewModel = this._ViewModel as AppointmentFormConsultationViewModel;
        that._TTObject = this.appointmentFormConsultationViewModel._Consultation;
        if (this.appointmentFormConsultationViewModel == null)
            this.appointmentFormConsultationViewModel = new AppointmentFormConsultationViewModel();
        if (this.appointmentFormConsultationViewModel._Consultation == null)
            this.appointmentFormConsultationViewModel._Consultation = new Consultation();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(AppointmentFormConsultationViewModel);
  
    }


    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.ProtocolNo != event) {
                this._Consultation.ProtocolNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
    }

    public initFormControls(): void {
        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 0;

        this.tttextboxDescription = new TTVisual.TTTextBox();
        this.tttextboxDescription.Multiline = true;
        this.tttextboxDescription.Name = "tttextboxDescription";
        this.tttextboxDescription.TabIndex = 11;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 10;

        this.Controls = [this.ProtocolNo, this.tttextboxDescription, this.labelProtocolNo];

    }


}
