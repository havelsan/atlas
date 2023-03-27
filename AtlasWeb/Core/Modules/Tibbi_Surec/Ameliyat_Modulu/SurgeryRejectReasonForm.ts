//$7831D029
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { SurgeryRejectReasonFormViewModel } from './SurgeryRejectReasonFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SurgeryRejectReason } from 'NebulaClient/Model/AtlasClientModel';

import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'SurgeryRejectReasonForm',
    templateUrl: './SurgeryRejectReasonForm.html',
    providers: [MessageService]
})
export class SurgeryRejectReasonForm extends TTVisual.TTForm implements OnInit,IModal {
    labelOtherReasonExplanation: TTVisual.ITTLabel;
    LackOfMaterial: TTVisual.ITTCheckBox;
    OtherReason: TTVisual.ITTCheckBox;
    OtherReasonExplanation: TTVisual.ITTTextBox;
    PatientNotCome: TTVisual.ITTCheckBox;
    PreopPreparation: TTVisual.ITTCheckBox;
    ProlongSurgery: TTVisual.ITTCheckBox;
    public surgeryRejectReasonFormViewModel: SurgeryRejectReasonFormViewModel = new SurgeryRejectReasonFormViewModel();
    public get _SurgeryRejectReason(): SurgeryRejectReason {
        return this._TTObject as SurgeryRejectReason;
    }
    public statesPanelClass: string = "col-lg-6";
    private SurgeryRejectReasonForm_DocumentUrl: string = '/api/SurgeryRejectReasonService/SurgeryRejectReasonForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super('SURGERYREJECTREASON', 'SurgeryRejectReasonForm');
        this._DocumentServiceUrl = this.SurgeryRejectReasonForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SurgeryRejectReason();
        this.surgeryRejectReasonFormViewModel = new SurgeryRejectReasonFormViewModel();
        this._ViewModel = this.surgeryRejectReasonFormViewModel;
        this.surgeryRejectReasonFormViewModel._SurgeryRejectReason = this._TTObject as SurgeryRejectReason;
    }

    protected loadViewModel() {
        let that = this;
        that.surgeryRejectReasonFormViewModel = this._ViewModel as SurgeryRejectReasonFormViewModel;
        that._TTObject = this.surgeryRejectReasonFormViewModel._SurgeryRejectReason;
        if (this.surgeryRejectReasonFormViewModel == null)
            this.surgeryRejectReasonFormViewModel = new SurgeryRejectReasonFormViewModel();
        if (this.surgeryRejectReasonFormViewModel._SurgeryRejectReason == null)
            this.surgeryRejectReasonFormViewModel._SurgeryRejectReason = new SurgeryRejectReason();

    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);

        if( (this._SurgeryRejectReason.PatientNotCome == undefined || this._SurgeryRejectReason.PatientNotCome == false) &&
            (this._SurgeryRejectReason.PreopPreparation == undefined || this._SurgeryRejectReason.PreopPreparation == false) &&
            (this._SurgeryRejectReason.LackOfMaterial == undefined || this._SurgeryRejectReason.LackOfMaterial == false) &&
            (this._SurgeryRejectReason.ProlongSurgery == undefined || this._SurgeryRejectReason.ProlongSurgery == false) &&
            (this._SurgeryRejectReason.OtherReason == undefined || this._SurgeryRejectReason.OtherReason == false))
            {
                this.messageService.showInfo("En az bir adet neden seçmeniz gerekmektedir");
                throw new Exception(" En az bir adet neden seçmeniz gerekmektedir");
            }
        
        if(this._SurgeryRejectReason.OtherReason == true && 
            (this._SurgeryRejectReason.OtherReasonExplanation == undefined || this._SurgeryRejectReason.OtherReasonExplanation == ""))  
            {
                this.messageService.showInfo("Lütfen diğer nedenlere ait açıklama giriniz");
                throw new Exception(" Lütfen diğer nedenlere ait açıklama giriniz");
            }          
    }

    protected _modalInfo: ModalInfo;

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    inputParam: any;
    public async setInputParam(value: any) {
        this.inputParam = value;
    }

    async ngOnInit() {
        await this.load(SurgeryRejectReasonFormViewModel);
    }

    public onLackOfMaterialChanged(event): void {
        if (this._SurgeryRejectReason != null && this._SurgeryRejectReason.LackOfMaterial != event) {
            this._SurgeryRejectReason.LackOfMaterial = event;
        }
    }

    public onOtherReasonChanged(event): void {
        if (this._SurgeryRejectReason != null && this._SurgeryRejectReason.OtherReason != event) {
            this._SurgeryRejectReason.OtherReason = event;
        }

        if(event)
        {
            this.OtherReasonExplanation.ReadOnly = false;            
        }
        else    
        {
            this.OtherReasonExplanation.ReadOnly = true;
            this._SurgeryRejectReason.OtherReasonExplanation=null;
        }
    }

    public onOtherReasonExplanationChanged(event): void {
        if (this._SurgeryRejectReason != null && this._SurgeryRejectReason.OtherReasonExplanation != event) {
            this._SurgeryRejectReason.OtherReasonExplanation = event;
        }
    }

    public onPatientNotComeChanged(event): void {
        if (this._SurgeryRejectReason != null && this._SurgeryRejectReason.PatientNotCome != event) {
            this._SurgeryRejectReason.PatientNotCome = event;
        }
    }

    public onPreopPreparationChanged(event): void {
        if (this._SurgeryRejectReason != null && this._SurgeryRejectReason.PreopPreparation != event) {
            this._SurgeryRejectReason.PreopPreparation = event;
        }
    }

    public onProlongSurgeryChanged(event): void {
        if (this._SurgeryRejectReason != null && this._SurgeryRejectReason.ProlongSurgery != event) {
            this._SurgeryRejectReason.ProlongSurgery = event;
        }
    }

    protected async save()
    {
        // await super.save();
        if( (this._SurgeryRejectReason.PatientNotCome == undefined || this._SurgeryRejectReason.PatientNotCome == false) &&
        (this._SurgeryRejectReason.PreopPreparation == undefined || this._SurgeryRejectReason.PreopPreparation == false) &&
        (this._SurgeryRejectReason.LackOfMaterial == undefined || this._SurgeryRejectReason.LackOfMaterial == false) &&
        (this._SurgeryRejectReason.ProlongSurgery == undefined || this._SurgeryRejectReason.ProlongSurgery == false) &&
        (this._SurgeryRejectReason.OtherReason == undefined || this._SurgeryRejectReason.OtherReason == false))
            {
                this.messageService.showInfo("En az bir adet neden seçmeniz gerekmektedir");
                throw new Exception(" En az bir adet neden seçmeniz gerekmektedir");
            }
    
        if(this._SurgeryRejectReason.OtherReason == true && 
            (this._SurgeryRejectReason.OtherReasonExplanation == undefined || this._SurgeryRejectReason.OtherReasonExplanation == ""))  
            {
                this.messageService.showInfo("Lütfen diğer nedenlere ait açıklama giriniz");
                throw new Exception(" Lütfen diğer nedenlere ait açıklama giriniz");
            }  

        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._SurgeryRejectReason);
    }



    protected redirectProperties(): void {
        redirectProperty(this.LackOfMaterial, "Value", this.__ttObject, "LackOfMaterial");
        redirectProperty(this.PreopPreparation, "Value", this.__ttObject, "PreopPreparation");
        redirectProperty(this.PatientNotCome, "Value", this.__ttObject, "PatientNotCome");
        redirectProperty(this.ProlongSurgery, "Value", this.__ttObject, "ProlongSurgery");
        redirectProperty(this.OtherReason, "Value", this.__ttObject, "OtherReason");
        redirectProperty(this.OtherReasonExplanation, "Text", this.__ttObject, "OtherReasonExplanation");
    }

    public initFormControls(): void {
        this.labelOtherReasonExplanation = new TTVisual.TTLabel();
        this.labelOtherReasonExplanation.Text = "Diğer Neden Açıklaması";
        this.labelOtherReasonExplanation.Name = "labelOtherReasonExplanation";
        this.labelOtherReasonExplanation.TabIndex = 6;
        this.labelOtherReasonExplanation.Visible = false;

        this.OtherReasonExplanation = new TTVisual.TTTextBox();
        this.OtherReasonExplanation.Multiline = true;
        this.OtherReasonExplanation.Name = "OtherReasonExplanation";
        this.OtherReasonExplanation.TabIndex = 5;
        this.OtherReasonExplanation.ReadOnly = true;

        this.OtherReason = new TTVisual.TTCheckBox();
        this.OtherReason.Value = false;
        this.OtherReason.Title = "Diğer Nedenler";
        this.OtherReason.Name = "OtherReason";
        this.OtherReason.TabIndex = 4;

        this.ProlongSurgery = new TTVisual.TTCheckBox();
        this.ProlongSurgery.Value = false;
        this.ProlongSurgery.Title = "Diğer Ameliyatların Süresinin Uzaması";
        this.ProlongSurgery.Name = "ProlongSurgery";
        this.ProlongSurgery.TabIndex = 3;

        this.PatientNotCome = new TTVisual.TTCheckBox();
        this.PatientNotCome.Value = false;
        this.PatientNotCome.Title = "Hastanın Ameliyata Gelmemesi";
        this.PatientNotCome.Name = "PatientNotCome";
        this.PatientNotCome.TabIndex = 2;

        this.PreopPreparation = new TTVisual.TTCheckBox();
        this.PreopPreparation.Value = false;
        this.PreopPreparation.Title = "Preop Hazırlığının Tamamlanamaması";
        this.PreopPreparation.Name = "PreopPreparation";
        this.PreopPreparation.TabIndex = 1;

        this.LackOfMaterial = new TTVisual.TTCheckBox();
        this.LackOfMaterial.Value = false;
        this.LackOfMaterial.Title = "Malzeme Yokluğu";
        this.LackOfMaterial.Name = "LackOfMaterial";
        this.LackOfMaterial.TabIndex = 0;

        this.Controls = [this.labelOtherReasonExplanation, this.OtherReasonExplanation, this.OtherReason, this.ProlongSurgery, this.PatientNotCome, this.PreopPreparation, this.LackOfMaterial];

    }


}
