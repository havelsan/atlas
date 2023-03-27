//$C30CE409
import { Component, OnInit, NgZone } from '@angular/core';
import { AppointmentFormManipulationViewModel } from './AppointmentFormManipulationViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AppointmentFormBase } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AppointmentFormBase";
import { Manipulation } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'AppointmentFormManipulation',
    templateUrl: './AppointmentFormManipulation.html',
    providers: [MessageService]
})
export class AppointmentFormManipulation extends AppointmentFormBase implements OnInit {
    ttlabel1: TTVisual.ITTLabel;
    tttextboxProtokolNo: TTVisual.ITTTextBox;
    public appointmentFormManipulationViewModel: AppointmentFormManipulationViewModel = new AppointmentFormManipulationViewModel();
    public get _Manipulation(): Manipulation {
        return this._TTObject as Manipulation;
    }
    private AppointmentFormManipulation_DocumentUrl: string = '/api/ManipulationService/AppointmentFormManipulation';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.AppointmentFormManipulation_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    //protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
    //    super.PostScript(transDef);
    // //   this._Manipulation.CompleteMyNewAppoinments();
    //}
    //protected async PreScript(): Promise<void> {
    //    super.PreScript();
    //    this.tttextboxDescription.Text = '\"\';
    //    //TextBox pDescriptionBox = (TextBox)tttextboxDescription;
    //    //pDescriptionBox.ScrollBars = ScrollBars.Vertical;

    //    tttextboxDescription.Text = (await BaseActionService.GetFullAppointmentDescription(this._Manipulation));
    //}

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Manipulation();
        this.appointmentFormManipulationViewModel = new AppointmentFormManipulationViewModel();
        this._ViewModel = this.appointmentFormManipulationViewModel;
        this.appointmentFormManipulationViewModel._Manipulation = this._TTObject as Manipulation;
    }

    protected loadViewModel() {
        let that = this;

        that.appointmentFormManipulationViewModel = this._ViewModel as AppointmentFormManipulationViewModel;
        that._TTObject = this.appointmentFormManipulationViewModel._Manipulation;
        if (this.appointmentFormManipulationViewModel == null)
            this.appointmentFormManipulationViewModel = new AppointmentFormManipulationViewModel();
        if (this.appointmentFormManipulationViewModel._Manipulation == null)
            this.appointmentFormManipulationViewModel._Manipulation = new Manipulation();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(AppointmentFormManipulationViewModel);
  
    }


    public ontttextboxProtokolNoChanged(event): void {
        if (event != null) {
            if (this._Manipulation != null && this._Manipulation.ProtocolNo != event) {
                this._Manipulation.ProtocolNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.tttextboxProtokolNo, "Text", this.__ttObject, "ProtocolNo");
    }

    public initFormControls(): void {
        this.tttextboxProtokolNo = new TTVisual.TTTextBox();
        this.tttextboxProtokolNo.BackColor = "#F0F0F0";
        this.tttextboxProtokolNo.ReadOnly = true;
        this.tttextboxProtokolNo.Name = "tttextboxProtokolNo";
        this.tttextboxProtokolNo.TabIndex = 9;

        this.tttextboxDescription = new TTVisual.TTTextBox();
        this.tttextboxDescription.Multiline = true;
        this.tttextboxDescription.Name = "tttextboxDescription";
        this.tttextboxDescription.TabIndex = 11;
        this.tttextboxDescription.Height = "150";

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M20566", "Protokol No");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 10;

        this.Controls = [this.tttextboxProtokolNo, this.tttextboxDescription, this.ttlabel1];

    }


}
