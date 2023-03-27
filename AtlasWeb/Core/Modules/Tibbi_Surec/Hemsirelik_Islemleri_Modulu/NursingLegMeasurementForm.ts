//$F6C9FA9D
import { Component, OnInit, NgZone} from '@angular/core';
import { NursingLegMeasurementFormViewModel } from './NursingLegMeasurementFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingLegMeasurement } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from "app/NebulaClient/Mscorlib/GuidParam";
@Component({
    selector: 'NursingLegMeasurementForm',
    templateUrl: './NursingLegMeasurementForm.html',
    providers: [MessageService]
})
export class NursingLegMeasurementForm extends BaseNursingDataEntryForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    labelActionDate: TTVisual.ITTLabel;
    labelLowerLeftLeg: TTVisual.ITTLabel;
    labelLowerRightLeg: TTVisual.ITTLabel;
    labelUpperLeftLeg: TTVisual.ITTLabel;
    labelUpperRightLeg: TTVisual.ITTLabel;
    LowerLeftLeg: TTVisual.ITTTextBox;
    LowerRightLeg: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    UpperLeftLeg: TTVisual.ITTTextBox;
    UpperRightLeg: TTVisual.ITTTextBox;
    public nursingLegMeasurementFormViewModel: NursingLegMeasurementFormViewModel = new NursingLegMeasurementFormViewModel();
    public get _NursingLegMeasurement(): NursingLegMeasurement {
        return this._TTObject as NursingLegMeasurement;
    }
    private NursingLegMeasurementForm_DocumentUrl: string = '/api/NursingLegMeasurementService/NursingLegMeasurementForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone, protected reportService: AtlasReportService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingLegMeasurementForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingLegMeasurement();
        this.nursingLegMeasurementFormViewModel = new NursingLegMeasurementFormViewModel();
        this._ViewModel = this.nursingLegMeasurementFormViewModel;
        this.nursingLegMeasurementFormViewModel._NursingLegMeasurement = this._TTObject as NursingLegMeasurement;
    }

    protected loadViewModel() {
        let that = this;
        that.nursingLegMeasurementFormViewModel = this._ViewModel as NursingLegMeasurementFormViewModel;
        that._TTObject = this.nursingLegMeasurementFormViewModel._NursingLegMeasurement;
        if (this.nursingLegMeasurementFormViewModel == null)
            this.nursingLegMeasurementFormViewModel = new NursingLegMeasurementFormViewModel();
        if (this.nursingLegMeasurementFormViewModel._NursingLegMeasurement == null)
            this.nursingLegMeasurementFormViewModel._NursingLegMeasurement = new NursingLegMeasurement();

    }

    printReport() {
        let a: any = this.nursingLegMeasurementFormViewModel._NursingLegMeasurement.NursingApplication;
        if (a.ObjectID != undefined)
            a = a.ObjectID;
        const TTOBJECTID = new GuidParam(a);
        let reportParameters: any = { 'TTOBJECTID': TTOBJECTID };
        this.reportService.showReport('NursingLegReport', reportParameters);
    }

    async ngOnInit() {
        await this.load();
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._NursingLegMeasurement != null && this._NursingLegMeasurement.ActionDate != event) {
                this._NursingLegMeasurement.ActionDate = event;
            }
        }
    }

    public onLowerLeftLegChanged(event): void {
        if (event != null) {
            if (this._NursingLegMeasurement != null && this._NursingLegMeasurement.LowerLeftLeg != event) {
                this._NursingLegMeasurement.LowerLeftLeg = event;
            }
        }
    }

    public onLowerRightLegChanged(event): void {
        if (event != null) {
            if (this._NursingLegMeasurement != null && this._NursingLegMeasurement.LowerRightLeg != event) {
                this._NursingLegMeasurement.LowerRightLeg = event;
            }
        }
    }

    public onUpperLeftLegChanged(event): void {
        if (event != null) {
            if (this._NursingLegMeasurement != null && this._NursingLegMeasurement.UpperLeftLeg != event) {
                this._NursingLegMeasurement.UpperLeftLeg = event;
            }
        }
    }

    public onUpperRightLegChanged(event): void {
        if (event != null) {
            if (this._NursingLegMeasurement != null && this._NursingLegMeasurement.UpperRightLeg != event) {
                this._NursingLegMeasurement.UpperRightLeg = event;
            }
        }
    }

    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.nursingLegMeasurementFormViewModel.ReadOnly = (this.nursingLegMeasurementFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.nursingLegMeasurementFormViewModel.ReadOnly)
            this.DropStateButton(NursingLegMeasurement.NursingLegMeasurementStates.Cancelled);

        this.ArrangeFormControl();

        super.ClientSidePreScript();
    }

    ArrangeFormControl() {
        this.ActionDate.ReadOnly = this.nursingLegMeasurementFormViewModel.ReadOnly;
        this.ActionDate.Enabled = !this.nursingLegMeasurementFormViewModel.ReadOnly;

        this.LowerRightLeg.ReadOnly = this.nursingLegMeasurementFormViewModel.ReadOnly;
        this.LowerRightLeg.Enabled = !this.nursingLegMeasurementFormViewModel.ReadOnly;

        this.LowerLeftLeg.ReadOnly = this.nursingLegMeasurementFormViewModel.ReadOnly;
        this.LowerLeftLeg.Enabled = !this.nursingLegMeasurementFormViewModel.ReadOnly;

        this.UpperRightLeg.ReadOnly = this.nursingLegMeasurementFormViewModel.ReadOnly;
        this.UpperRightLeg.Enabled = !this.nursingLegMeasurementFormViewModel.ReadOnly;

        this.UpperLeftLeg.ReadOnly = this.nursingLegMeasurementFormViewModel.ReadOnly;
        this.UpperLeftLeg.Enabled = !this.nursingLegMeasurementFormViewModel.ReadOnly;
    }

    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.LowerRightLeg, "Text", this.__ttObject, "LowerRightLeg");
        redirectProperty(this.LowerLeftLeg, "Text", this.__ttObject, "LowerLeftLeg");
        redirectProperty(this.UpperRightLeg, "Text", this.__ttObject, "UpperRightLeg");
        redirectProperty(this.UpperLeftLeg, "Text", this.__ttObject, "UpperLeftLeg");
    }

    public initFormControls(): void {
        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = "Tarih";
        this.labelActionDate.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 14;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 13;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "cm";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 12;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M22006", "Sol Bacak Ölçümü");
        this.ttlabel6.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 9;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M21130", "Sağ Bacak Ölçümü");
        this.ttlabel5.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 8;

        this.labelUpperLeftLeg = new TTVisual.TTLabel();
        this.labelUpperLeftLeg.Text = i18n("M22023", "Sol Üst: ");
        this.labelUpperLeftLeg.Name = "labelUpperLeftLeg";
        this.labelUpperLeftLeg.TabIndex = 7;

        this.UpperLeftLeg = new TTVisual.TTTextBox();
        this.UpperLeftLeg.Name = "UpperLeftLeg";
        this.UpperLeftLeg.TabIndex = 6;

        this.LowerLeftLeg = new TTVisual.TTTextBox();
        this.LowerLeftLeg.Name = "LowerLeftLeg";
        this.LowerLeftLeg.TabIndex = 4;

        this.UpperRightLeg = new TTVisual.TTTextBox();
        this.UpperRightLeg.Name = "UpperRightLeg";
        this.UpperRightLeg.TabIndex = 2;

        this.LowerRightLeg = new TTVisual.TTTextBox();
        this.LowerRightLeg.Name = "LowerRightLeg";
        this.LowerRightLeg.TabIndex = 0;

        this.labelLowerLeftLeg = new TTVisual.TTLabel();
        this.labelLowerLeftLeg.Text = i18n("M22004", "Sol Alt:");
        this.labelLowerLeftLeg.Name = "labelLowerLeftLeg";
        this.labelLowerLeftLeg.TabIndex = 5;

        this.labelUpperRightLeg = new TTVisual.TTLabel();
        this.labelUpperRightLeg.Text = i18n("M21154", "Sağ Üst:");
        this.labelUpperRightLeg.Name = "labelUpperRightLeg";
        this.labelUpperRightLeg.TabIndex = 3;

        this.labelLowerRightLeg = new TTVisual.TTLabel();
        this.labelLowerRightLeg.Text = i18n("M21128", "Sağ Alt: ");
        this.labelLowerRightLeg.Name = "labelLowerRightLeg";
        this.labelLowerRightLeg.TabIndex = 1;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "cm";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 12;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "cm";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 12;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "cm";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 12;

        this.Controls = [this.labelActionDate, this.ActionDate, this.ttlabel1, this.ttlabel6, this.ttlabel5, this.labelUpperLeftLeg, this.UpperLeftLeg, this.LowerLeftLeg, this.UpperRightLeg, this.LowerRightLeg, this.labelLowerLeftLeg, this.labelUpperRightLeg, this.labelLowerRightLeg, this.ttlabel2, this.ttlabel3, this.ttlabel4];

    }


}
