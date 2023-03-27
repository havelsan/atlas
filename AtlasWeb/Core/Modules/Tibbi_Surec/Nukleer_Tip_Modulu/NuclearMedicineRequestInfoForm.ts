//$815D774A
import { Component, OnInit, NgZone } from '@angular/core';
import { NuclearMedicineRequestInfoFormViewModel } from './NuclearMedicineRequestInfoFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'NuclearMedicineRequestInfoForm',
    templateUrl: './NuclearMedicineRequestInfoForm.html',
    providers: [MessageService]
})
export class NuclearMedicineRequestInfoForm extends TTVisual.TTForm implements OnInit {
    IsEmergency: TTVisual.ITTCheckBox;
    labelPreInformation: TTVisual.ITTLabel;
    lblRequestCorrectionReason: TTVisual.ITTLabel;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    txtRequestCorrectionReason: TTVisual.ITTTextBox;
    public nuclearMedicineRequestInfoFormViewModel: NuclearMedicineRequestInfoFormViewModel = new NuclearMedicineRequestInfoFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineRequestInfoForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineRequestInfoForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('NUCLEARMEDICINE', 'NuclearMedicineRequestInfoForm');
        this._DocumentServiceUrl = this.NuclearMedicineRequestInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineRequestInfoFormViewModel = new NuclearMedicineRequestInfoFormViewModel();
        this._ViewModel = this.nuclearMedicineRequestInfoFormViewModel;
        this.nuclearMedicineRequestInfoFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineRequestInfoFormViewModel = this._ViewModel as NuclearMedicineRequestInfoFormViewModel;
        that._TTObject = this.nuclearMedicineRequestInfoFormViewModel._NuclearMedicine;
        if (this.nuclearMedicineRequestInfoFormViewModel == null)
            this.nuclearMedicineRequestInfoFormViewModel = new NuclearMedicineRequestInfoFormViewModel();
        if (this.nuclearMedicineRequestInfoFormViewModel._NuclearMedicine == null)
            this.nuclearMedicineRequestInfoFormViewModel._NuclearMedicine = new NuclearMedicine();

    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineRequestInfoFormViewModel);
  
    }

    public onIsEmergencyChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.IsEmergency != event) {
                this._NuclearMedicine.IsEmergency = event;
            }
        }
    }

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PreDiagnosis != event) {
                this._NuclearMedicine.PreDiagnosis = event;
            }
        }
    }

    public ontxtRequestCorrectionReasonChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RequestCorrectionReason != event) {
                this._NuclearMedicine.RequestCorrectionReason = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.txtRequestCorrectionReason, "Text", this.__ttObject, "RequestCorrectionReason");
        redirectProperty(this.IsEmergency, "Value", this.__ttObject, "IsEmergency");
    }

    public initFormControls(): void {
        this.labelPreInformation = new TTVisual.TTLabel();
        this.labelPreInformation.Text = "Kısa Anamnez ve Klinik Bulgular";
        this.labelPreInformation.ForeColor = "#000000";
        this.labelPreInformation.Name = "labelPreInformation";
        this.labelPreInformation.TabIndex = 12;

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Required = true;
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#FFE3C6";
        this.PREDIAGNOSIS.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 9;

        this.txtRequestCorrectionReason = new TTVisual.TTTextBox();
        this.txtRequestCorrectionReason.Multiline = true;
        this.txtRequestCorrectionReason.Name = "txtRequestCorrectionReason";
        this.txtRequestCorrectionReason.TabIndex = 4;
        this.txtRequestCorrectionReason.Visible = false;

        this.lblRequestCorrectionReason = new TTVisual.TTLabel();
        this.lblRequestCorrectionReason.Text = "İstek Düzeltme Nedeni";
        this.lblRequestCorrectionReason.Name = "lblRequestCorrectionReason";
        this.lblRequestCorrectionReason.TabIndex = 3;
        this.lblRequestCorrectionReason.Visible = false;

        this.IsEmergency = new TTVisual.TTCheckBox();
        this.IsEmergency.Value = false;
        this.IsEmergency.Text = "Acil";
        this.IsEmergency.Name = "IsEmergency";
        this.IsEmergency.TabIndex = 7;

        this.Controls = [this.labelPreInformation, this.PREDIAGNOSIS, this.txtRequestCorrectionReason, this.lblRequestCorrectionReason, this.IsEmergency];

    }


}
