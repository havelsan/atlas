//$EF9D2126
import { Component, OnInit, NgZone } from '@angular/core';
import { AppointmentFormBaseViewModel } from './AppointmentFormBaseViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseAction } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';


@Component({
    selector: 'AppointmentFormBase',
    templateUrl: './AppointmentFormBase.html',
    providers: [MessageService]
})
export class AppointmentFormBase extends TTVisual.TTForm implements OnInit {
    tttextboxDescription: TTVisual.ITTTextBox;
    public appointmentFormBaseViewModel: AppointmentFormBaseViewModel = new AppointmentFormBaseViewModel();
    public get _BaseAction(): BaseAction {
        return this._TTObject as BaseAction;
    }
    private AppointmentFormBase_DocumentUrl: string = '/api/BaseActionService/AppointmentFormBase';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('BASEACTION', 'AppointmentFormBase');
        this._DocumentServiceUrl = this.AppointmentFormBase_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        // TODO ServerSideFormPosta taşı!
        //if (transDef != null)
        //            this._BaseAction.CompleteMyNewAppoinments();
    }
    protected async PreScript(): Promise<void> {
        //let index: number = 0;
        //this.tttextboxDescription.Text = '\"\';
        ////TextBox pDescriptionBox = (TextBox)this.pnlControls.Controls["tttextboxDescription"];
        ////pDescriptionBox.ScrollBars = ScrollBars.Vertical;

        //if (this._BaseAction.GetStateHistory().length > 1) {
        //    index = this._BaseAction.GetStateHistory().length - 1;
        //    if (this._BaseAction.GetStateHistory()[index].IsUndo === true) {
        //        this.tttextboxDescription.Text = (await BaseActionService.GetFullCompletedAppointmentDescription(this._BaseAction));
        //    }
        //    else {
        //        this.tttextboxDescription.Text = (await BaseActionService.GetFullAppointmentDescription(this._BaseAction));
        //    }
        //}
        //else {
        //    this.tttextboxDescription.Text = (await BaseActionService.GetFullAppointmentDescription(this._BaseAction));
        //}
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseAction();
        this.appointmentFormBaseViewModel = new AppointmentFormBaseViewModel();
        this._ViewModel = this.appointmentFormBaseViewModel;
        this.appointmentFormBaseViewModel._BaseAction = this._TTObject as BaseAction;
    }

    protected loadViewModel() {
        let that = this;

        that.appointmentFormBaseViewModel = this._ViewModel as AppointmentFormBaseViewModel;
        that._TTObject = this.appointmentFormBaseViewModel._BaseAction;
        if (this.appointmentFormBaseViewModel == null)
            this.appointmentFormBaseViewModel = new AppointmentFormBaseViewModel();
        if (this.appointmentFormBaseViewModel._BaseAction == null)
            this.appointmentFormBaseViewModel._BaseAction = new BaseAction();

    }

    async ngOnInit()  {
        let that = this;
        await this.load(AppointmentFormBaseViewModel);
  
    }




    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.tttextboxDescription = new TTVisual.TTTextBox();
        this.tttextboxDescription.Multiline = true;
        this.tttextboxDescription.Name = "tttextboxDescription";
        this.tttextboxDescription.TabIndex = 11;

        this.Controls = [this.tttextboxDescription];

    }


}
