//$FFAD03B9
import { Component, OnInit, Input, NgZone } from '@angular/core';
import { RadiologyRequestInfoFormViewModel } from "./RadiologyRequestInfoFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { vmRequiredInfoFormProcedure } from "../Tetkik_Istem_Modulu/ProcedureRequestViewModel";



import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';




@Component({
    selector: 'RadiologyRequestInfoForm',
    templateUrl: './RadiologyRequestInfoForm.html',
    providers: [MessageService]
})
export class RadiologyRequestInfoForm extends TTVisual.TTForm implements OnInit {
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;

    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextbox4: TTVisual.ITTTextBox;
    public radiologyRequestInfoFormViewModel: RadiologyRequestInfoFormViewModel = new RadiologyRequestInfoFormViewModel();
    public get _Radiology(): Radiology {
        return this._TTObject as Radiology;
    }
    private RadiologyRequestInfoForm_DocumentUrl: string = '/api/RadiologyService/RadiologyRequestInfoForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("RADIOLOGY", "RadiologyRequestInfoForm");
        this._DocumentServiceUrl = this.RadiologyRequestInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    @Input() subActionObjectId: Guid;
    @Input() requestedProcedure: vmRequiredInfoFormProcedure;


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Radiology();
        this.radiologyRequestInfoFormViewModel = new RadiologyRequestInfoFormViewModel();
        this._ViewModel = this.radiologyRequestInfoFormViewModel;
        this.radiologyRequestInfoFormViewModel._Radiology = this._TTObject as Radiology;
        this.radiologyRequestInfoFormViewModel.subActionObjectId = this.subActionObjectId;
        this.radiologyRequestInfoFormViewModel.requestedProcedure = this.requestedProcedure;

    }

    protected loadViewModel() {
        let that = this;
        that.radiologyRequestInfoFormViewModel = this._ViewModel as RadiologyRequestInfoFormViewModel;
        that._TTObject = this.radiologyRequestInfoFormViewModel._Radiology;
        if (this.radiologyRequestInfoFormViewModel == null)
            this.radiologyRequestInfoFormViewModel = new RadiologyRequestInfoFormViewModel();
        if (this.radiologyRequestInfoFormViewModel._Radiology == null)
            this.radiologyRequestInfoFormViewModel._Radiology = new Radiology();

        if (this.radiologyRequestInfoFormViewModel != null) {
            this.radiologyRequestInfoFormViewModel.subActionObjectId = this.subActionObjectId;
            this.radiologyRequestInfoFormViewModel.requestedProcedure = this.requestedProcedure;
        }

    }

    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyRequestInfoFormViewModel);
  
    }


    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.PreDiagnosis != event) {
                this._Radiology.PreDiagnosis = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.Description != event) {
                this._Radiology.Description = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 17;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 14;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Multiline = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 14;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M15821", "Hizmet Adı");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 17;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.Multiline = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 14;


        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M15855", "Hizmet ID");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 17;

        this.tttextbox4 = new TTVisual.TTTextBox();
        this.tttextbox4.Multiline = true;
        this.tttextbox4.Name = "tttextbox4";
        this.tttextbox4.TabIndex = 14;

        this.Controls = [this.ttlabel2, this.tttextbox1, this.tttextbox2, this.ttlabel1, this.tttextbox3, this.ttlabel3, this.tttextbox4, this.ttlabel4 ];

    }




}
