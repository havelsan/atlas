//$A9BB9C06
import { Component, OnInit, Input, ViewChild, NgZone, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { HemodialysisOrderFormViewModel } from './HemodialysisOrderFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { HemodialysisOrder } from 'NebulaClient/Model/AtlasClientModel';
import { HemodialysisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { PackageProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { ResTreatmentDiagnosisUnit } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDiyalizeGirmeSikligi } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { TTObjectStateTransitionDef } from '../../../wwwroot/app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { FormSaveInfo } from '../../../wwwroot/app/NebulaClient/Mscorlib/FormSaveInfo';


@Component({
    selector: 'HemodialysisOrderForm',
    templateUrl: './HemodialysisOrderForm.html',
    providers: [MessageService]
})
export class HemodialysisOrderForm extends EpisodeActionForm implements OnInit {
    DialysisFrequency: TTVisual.ITTObjectListBox;
    Duration: TTVisual.ITTTextBox;
    Emergency: TTVisual.ITTCheckBox;
    IDBaseAction: TTVisual.ITTTextBox;
    Information: TTVisual.ITTTextBox;
    IsWeekendInclude: TTVisual.ITTCheckBox;
    labelDialysisFrequency: TTVisual.ITTLabel;
    labelDuration: TTVisual.ITTLabel;
    labelIDBaseAction: TTVisual.ITTLabel;
    labelInformation: TTVisual.ITTLabel;
    labelPackageProcedure: TTVisual.ITTLabel;
    labelSessionCount: TTVisual.ITTLabel;
    labelSessionDayRange: TTVisual.ITTLabel;
    labelSessionDayRangeType: TTVisual.ITTLabel;
    labelTreatmentDiagnosisUnit: TTVisual.ITTLabel;
    labelTreatmentEquipment: TTVisual.ITTLabel;
    labelTreatmentStartDateTime: TTVisual.ITTLabel;
    PackageProcedure: TTVisual.ITTObjectListBox;
    SessionCount: TTVisual.ITTTextBox;
    SessionDayRange: TTVisual.ITTTextBox;
    SessionDayRangeType: TTVisual.ITTEnumComboBox;
    TreatmentDiagnosisUnit: TTVisual.ITTObjectListBox;
    TreatmentEquipment: TTVisual.ITTObjectListBox;
    TreatmentStartDateTime: TTVisual.ITTDateTimePicker;
    public hemodialysisOrderFormViewModel: HemodialysisOrderFormViewModel = new HemodialysisOrderFormViewModel();
    public get _HemodialysisOrder(): HemodialysisOrder {
        return this._TTObject as HemodialysisOrder;
    }
    private HemodialysisOrderForm_DocumentUrl: string = '/api/HemodialysisOrderService/HemodialysisOrderForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.HemodialysisOrderForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async PreScript() {
        this.hemodialysisOrderFormViewModel._HemodialysisOrder.HemodialysisRequest = this._hrObj;
        super.PreScript();
        if (this._hemodialysisRequest != null) {
            this.hemodialysisOrderFormViewModel._HemodialysisOrder.HemodialysisRequest = this._hemodialysisRequest;
            this._HemodialysisOrder.HemodialysisRequest = this._hemodialysisRequest;
            if (this.hemodialysisOrderFormViewModel.HemodialysisRequests == null) {
                this.hemodialysisOrderFormViewModel.HemodialysisRequests = new Array<HemodialysisRequest>();
                this.hemodialysisOrderFormViewModel.HemodialysisRequests.push(this._hemodialysisRequest);
            }
        }
    }
    //protected async PostScript() {
    //    let a = 1;
    //}
    _hemodialysisRequest: HemodialysisRequest;
    @Input() set HemodialysisRequest(value: HemodialysisRequest) {
        if (value != null) {
            this._hemodialysisRequest = value;
        }
    }
    get HemodialysisRequest(): HemodialysisRequest {
        return this.HemodialysisRequest;
    }

    _hrObj: HemodialysisRequest = new HemodialysisRequest;
    public setInputParam(value: any) {
        this._hrObj = value;
        this.hemodialysisOrderFormViewModel._HemodialysisOrder.HemodialysisRequest = this._hrObj;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HemodialysisOrder();
        this.hemodialysisOrderFormViewModel = new HemodialysisOrderFormViewModel();
        this._ViewModel = this.hemodialysisOrderFormViewModel;
        this.hemodialysisOrderFormViewModel._HemodialysisOrder = this._TTObject as HemodialysisOrder;
        this.hemodialysisOrderFormViewModel._HemodialysisOrder.TreatmentDiagnosisUnit = new ResTreatmentDiagnosisUnit();
        this.hemodialysisOrderFormViewModel._HemodialysisOrder.HemodialysisRequest = new HemodialysisRequest();
        this.hemodialysisOrderFormViewModel._HemodialysisOrder.TreatmentEquipment = new ResEquipment();
        this.hemodialysisOrderFormViewModel._HemodialysisOrder.PackageProcedure = new PackageProcedureDefinition();
        this.hemodialysisOrderFormViewModel._HemodialysisOrder.DialysisFrequency = new SKRSDiyalizeGirmeSikligi();
    }

    protected loadViewModel() {
        let that = this;
        that.hemodialysisOrderFormViewModel = this._ViewModel as HemodialysisOrderFormViewModel;
        that._TTObject = this.hemodialysisOrderFormViewModel._HemodialysisOrder;
        if (this.hemodialysisOrderFormViewModel == null)
            this.hemodialysisOrderFormViewModel = new HemodialysisOrderFormViewModel();
        if (this.hemodialysisOrderFormViewModel._HemodialysisOrder == null)
            this.hemodialysisOrderFormViewModel._HemodialysisOrder = new HemodialysisOrder();
        let hemodialysisRequestObjectID = that.hemodialysisOrderFormViewModel._HemodialysisOrder["HemodialysisRequest"];
        if (hemodialysisRequestObjectID != null && (typeof hemodialysisRequestObjectID === "string")) {
            let hemodialysisRequest = that.hemodialysisOrderFormViewModel.HemodialysisRequests.find(o => o.ObjectID.toString() === hemodialysisRequestObjectID.toString());
            if (hemodialysisRequest) {
                that.hemodialysisOrderFormViewModel._HemodialysisOrder.HemodialysisRequest = hemodialysisRequest;
            }
        }

        let treatmentEquipmentObjectID = that.hemodialysisOrderFormViewModel._HemodialysisOrder["TreatmentEquipment"];
        if (treatmentEquipmentObjectID != null && (typeof treatmentEquipmentObjectID === "string")) {
            let treatmentEquipment = that.hemodialysisOrderFormViewModel.ResEquipments.find(o => o.ObjectID.toString() === treatmentEquipmentObjectID.toString());
            if (treatmentEquipment) {
                that.hemodialysisOrderFormViewModel._HemodialysisOrder.TreatmentEquipment = treatmentEquipment;
            }
        }

        let treatmentDiagnosisUnitObjectID = that.hemodialysisOrderFormViewModel._HemodialysisOrder["TreatmentDiagnosisUnit"];
        if (treatmentDiagnosisUnitObjectID != null && (typeof treatmentDiagnosisUnitObjectID === "string")) {
            let treatmentDiagnosisUnit = that.hemodialysisOrderFormViewModel.ResTreatmentDiagnosisUnits.find(o => o.ObjectID.toString() === treatmentDiagnosisUnitObjectID.toString());
            if (treatmentDiagnosisUnit) {
                that.hemodialysisOrderFormViewModel._HemodialysisOrder.TreatmentDiagnosisUnit = treatmentDiagnosisUnit;
            }
        }

        let packageProcedureObjectID = that.hemodialysisOrderFormViewModel._HemodialysisOrder["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.hemodialysisOrderFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.hemodialysisOrderFormViewModel._HemodialysisOrder.PackageProcedure = packageProcedure;
            }
        }

        let dialysisFrequencyObjectID = that.hemodialysisOrderFormViewModel._HemodialysisOrder["DialysisFrequency"];
        if (dialysisFrequencyObjectID != null && (typeof dialysisFrequencyObjectID === "string")) {
            let dialysisFrequency = that.hemodialysisOrderFormViewModel.SKRSDiyalizeGirmeSikligis.find(o => o.ObjectID.toString() === dialysisFrequencyObjectID.toString());
            if (dialysisFrequency) {
                that.hemodialysisOrderFormViewModel._HemodialysisOrder.DialysisFrequency = dialysisFrequency;
            }
        }

    }

    async ngOnInit() {
        await this.load();
    }

    public onDialysisFrequencyChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.DialysisFrequency != event) {
            this._HemodialysisOrder.DialysisFrequency = event;
        }
    }

    public onDurationChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.Duration != event) {
            this._HemodialysisOrder.Duration = event;
        }
    }

    public onEmergencyChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.Emergency != event) {
            this._HemodialysisOrder.Emergency = event;
        }
    }

    public onIDBaseActionChanged(event): void {
        if (this._HemodialysisOrder != null &&
            this._HemodialysisOrder.HemodialysisRequest != null && this._HemodialysisOrder.HemodialysisRequest.ID != event) {
            this._HemodialysisOrder.HemodialysisRequest.ID = event;
        }
    }

    public onInformationChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.Information != event) {
            this._HemodialysisOrder.Information = event;
        }
    }

    public onIsWeekendIncludeChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.IsWeekendInclude != event) {
            this._HemodialysisOrder.IsWeekendInclude = event;
        }
    }

    public onPackageProcedureChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.PackageProcedure != event) {
            this._HemodialysisOrder.PackageProcedure = event;
        }
    }

    public onSessionCountChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.SessionCount != event) {
            this._HemodialysisOrder.SessionCount = event;
        }
    }

    public onSessionDayRangeChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.SessionDayRange != event) {
            this._HemodialysisOrder.SessionDayRange = event;
        }
    }

    public onSessionDayRangeTypeChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.SessionDayRangeType != event) {
            this._HemodialysisOrder.SessionDayRangeType = event;
        }
    }

    public onTreatmentDiagnosisUnitChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.TreatmentDiagnosisUnit != event) {
            this._HemodialysisOrder.TreatmentDiagnosisUnit = event;
        }
    }

    public onTreatmentEquipmentChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.TreatmentEquipment != event) {
            this._HemodialysisOrder.TreatmentEquipment = event;
        }
    }

    public onTreatmentStartDateTimeChanged(event): void {
        if (this._HemodialysisOrder != null && this._HemodialysisOrder.TreatmentStartDateTime != event) {
            this._HemodialysisOrder.TreatmentStartDateTime = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.TreatmentStartDateTime, "Value", this.__ttObject, "TreatmentStartDateTime");
        redirectProperty(this.SessionDayRange, "Text", this.__ttObject, "SessionDayRange");
        redirectProperty(this.SessionDayRangeType, "Value", this.__ttObject, "SessionDayRangeType");
        redirectProperty(this.SessionCount, "Text", this.__ttObject, "SessionCount");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.Information, "Text", this.__ttObject, "Information");
        redirectProperty(this.IDBaseAction, "Text", this.__ttObject, "HemodialysisRequest.ID");
        redirectProperty(this.Duration, "Text", this.__ttObject, "Duration");
        redirectProperty(this.IsWeekendInclude, "Value", this.__ttObject, "IsWeekendInclude");
    }

    public initFormControls(): void {
        this.IsWeekendInclude = new TTVisual.TTCheckBox();
        this.IsWeekendInclude.Value = false;
        this.IsWeekendInclude.Text = "Haftasonu Dahil";
        this.IsWeekendInclude.Title = "Haftasonu Dahil";
        this.IsWeekendInclude.Name = "IsWeekendInclude";
        this.IsWeekendInclude.TabIndex = 29;

        this.labelDuration = new TTVisual.TTLabel();
        this.labelDuration.Text = "Süre";
        this.labelDuration.Name = "labelDuration";
        this.labelDuration.TabIndex = 28;

        this.Duration = new TTVisual.TTTextBox();
        this.Duration.Name = "Duration";
        this.Duration.TabIndex = 27;

        this.IDBaseAction = new TTVisual.TTTextBox();
        this.IDBaseAction.Name = "IDBaseAction";
        this.IDBaseAction.TabIndex = 21;

        this.Information = new TTVisual.TTTextBox();
        this.Information.Name = "Information";
        this.Information.TabIndex = 19;

        this.SessionDayRange = new TTVisual.TTTextBox();
        this.SessionDayRange.Name = "SessionDayRange";
        this.SessionDayRange.TabIndex = 2;

        this.SessionCount = new TTVisual.TTTextBox();
        this.SessionCount.Name = "SessionCount";
        this.SessionCount.TabIndex = 0;

        this.labelTreatmentEquipment = new TTVisual.TTLabel();
        this.labelTreatmentEquipment.Text = "Tedavi Cihazı";
        this.labelTreatmentEquipment.Name = "labelTreatmentEquipment";
        this.labelTreatmentEquipment.TabIndex = 26;

        this.TreatmentEquipment = new TTVisual.TTObjectListBox();
        this.TreatmentEquipment.ListDefName = "EquipmentListDefinition";
        this.TreatmentEquipment.Name = "TreatmentEquipment";
        this.TreatmentEquipment.TabIndex = 25;

        this.labelTreatmentDiagnosisUnit = new TTVisual.TTLabel();
        this.labelTreatmentDiagnosisUnit.Text = "Seans Birimi";
        this.labelTreatmentDiagnosisUnit.Name = "labelTreatmentDiagnosisUnit";
        this.labelTreatmentDiagnosisUnit.TabIndex = 24;

        this.TreatmentDiagnosisUnit = new TTVisual.TTObjectListBox();
        this.TreatmentDiagnosisUnit.ListDefName = "TreatmentDiagnosisUnitListDefinition";
        this.TreatmentDiagnosisUnit.Name = "TreatmentDiagnosisUnit";
        this.TreatmentDiagnosisUnit.TabIndex = 23;

        this.labelIDBaseAction = new TTVisual.TTLabel();
        this.labelIDBaseAction.Text = "İşlem Nu. context'e eklemek için burada";
        this.labelIDBaseAction.Name = "labelIDBaseAction";
        this.labelIDBaseAction.TabIndex = 22;

        this.labelInformation = new TTVisual.TTLabel();
        this.labelInformation.Text = "Açıklama";
        this.labelInformation.Name = "labelInformation";
        this.labelInformation.TabIndex = 20;

        this.labelPackageProcedure = new TTVisual.TTLabel();
        this.labelPackageProcedure.Text = "İşlem";
        this.labelPackageProcedure.Name = "labelPackageProcedure";
        this.labelPackageProcedure.TabIndex = 16;

        this.PackageProcedure = new TTVisual.TTObjectListBox();
        this.PackageProcedure.ListDefName = "DialysisPackageProcedureList";
        this.PackageProcedure.Name = "PackageProcedure";
        this.PackageProcedure.TabIndex = 15;

        this.labelDialysisFrequency = new TTVisual.TTLabel();
        this.labelDialysisFrequency.Text = "Diyalize Girme Sıklığı";
        this.labelDialysisFrequency.Name = "labelDialysisFrequency";
        this.labelDialysisFrequency.TabIndex = 14;

        this.DialysisFrequency = new TTVisual.TTObjectListBox();
        this.DialysisFrequency.ListDefName = "SKRSDiyalizeGirmeSikligiList";
        this.DialysisFrequency.Name = "DialysisFrequency";
        this.DialysisFrequency.TabIndex = 13;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Text = "Acil";
        this.Emergency.Title = "Acil";
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 12;

        this.labelTreatmentStartDateTime = new TTVisual.TTLabel();
        this.labelTreatmentStartDateTime.Text = "Başlangıç Tarihi";
        this.labelTreatmentStartDateTime.Name = "labelTreatmentStartDateTime";
        this.labelTreatmentStartDateTime.TabIndex = 9;

        this.TreatmentStartDateTime = new TTVisual.TTDateTimePicker();
        this.TreatmentStartDateTime.Format = DateTimePickerFormat.Long;
        this.TreatmentStartDateTime.Name = "TreatmentStartDateTime";
        this.TreatmentStartDateTime.TabIndex = 8;

        this.labelSessionDayRangeType = new TTVisual.TTLabel();
        this.labelSessionDayRangeType.Text = "Seans Gün Aralığı Tipi";
        this.labelSessionDayRangeType.Name = "labelSessionDayRangeType";
        this.labelSessionDayRangeType.TabIndex = 5;

        this.SessionDayRangeType = new TTVisual.TTEnumComboBox();
        this.SessionDayRangeType.DataTypeName = "PeriodUnitTypeEnum";
        this.SessionDayRangeType.Name = "SessionDayRangeType";
        this.SessionDayRangeType.TabIndex = 4;

        this.labelSessionDayRange = new TTVisual.TTLabel();
        this.labelSessionDayRange.Text = "Seans Gün Aralığı";
        this.labelSessionDayRange.Name = "labelSessionDayRange";
        this.labelSessionDayRange.TabIndex = 3;

        this.labelSessionCount = new TTVisual.TTLabel();
        this.labelSessionCount.Text = "Seans Sayısı";
        this.labelSessionCount.Name = "labelSessionCount";
        this.labelSessionCount.TabIndex = 1;

        this.Controls = [this.IsWeekendInclude, this.labelDuration, this.Duration, this.IDBaseAction, this.Information, this.SessionDayRange, this.SessionCount, this.labelTreatmentEquipment, this.TreatmentEquipment, this.labelTreatmentDiagnosisUnit, this.TreatmentDiagnosisUnit, this.labelIDBaseAction, this.labelInformation, this.labelPackageProcedure, this.PackageProcedure, this.labelDialysisFrequency, this.DialysisFrequency, this.Emergency, this.labelTreatmentStartDateTime, this.TreatmentStartDateTime, this.labelSessionDayRangeType, this.SessionDayRangeType, this.labelSessionDayRange, this.labelSessionCount];

    }


}
