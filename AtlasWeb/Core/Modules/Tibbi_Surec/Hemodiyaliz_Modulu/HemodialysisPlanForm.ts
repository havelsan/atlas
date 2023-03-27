//$3EE0E875
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { HemodialysisPlanFormViewModel } from './HemodialysisPlanFormViewModel';
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
import { SKRSDiyalizeGirmeSikligi, HemodialysisReports } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'HemodialysisPlanForm',
    templateUrl: './HemodialysisPlanForm.html',
    providers: [MessageService]
})
export class HemodialysisPlanForm extends EpisodeActionForm implements OnInit {
    DialysisFrequency: TTVisual.ITTObjectListBox;
    Duration: TTVisual.ITTTextBox;
    Emergency: TTVisual.ITTCheckBox;
    Information: TTVisual.ITTTextBox;
    IsWeekendInclude: TTVisual.ITTCheckBox;
    labelDialysisFrequency: TTVisual.ITTLabel;
    labelDuration: TTVisual.ITTLabel;
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
    public hemodialysisPlanFormViewModel: HemodialysisPlanFormViewModel = new HemodialysisPlanFormViewModel();
    public get _HemodialysisOrder(): HemodialysisOrder {
        return this._TTObject as HemodialysisOrder;
    }
    private HemodialysisPlanForm_DocumentUrl: string = '/api/HemodialysisOrderService/HemodialysisPlanForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.HemodialysisPlanForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    //load Panel
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }
    // .\load Panel


    showHemodialysisReportPopup: boolean = false;
    ShowReports() {
        if (this.hemodialysisPlanFormViewModel.IsSGKPatient == true) {
            this.loadPanelOperation(true, i18n("M20888", "Raporlar listeleniyor. Lütfen bekleyiniz."));
            this.httpService.post<HemodialysisPlanFormViewModel>("api/HemodialysisOrderService/GetMedulaReportInfo", HemodialysisPlanFormViewModel).then(response => {
                let result: HemodialysisPlanFormViewModel = <HemodialysisPlanFormViewModel>response;

                this.hemodialysisPlanFormViewModel.ReportList = result.ReportList;
                //this.hemodialysisPlanFormViewModel.Message = result.Message;

                this.showHemodialysisReportPopup = true;

                //if (this.hemodialysisPlanFormViewModel.Message != null && this.hemodialysisPlanFormViewModel.Message != "") {
                //    TTVisual.InfoBox.Alert(this.hemodialysisPlanFormViewModel.Message);
                //}

                this.loadPanelOperation(false, '');
            }).catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadPanelOperation(false, '');
            });
        } else {
            TTVisual.InfoBox.Alert("Medula Rapor Okuma Hatası!");
            this.loadPanelOperation(false, '');
        }
    }

    selectedReportItem: HemodialysisReports;
    async selectionReportChanged(value: any): Promise<void> {
        if (value) {
            this.selectedReportItem = value.selectedRowsData[0] as HemodialysisReports; //TODO Merve -> selectedRowsData doğru mu kontrol edilecek
        }
    }

    async SaveHemodialysisReport() {

        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.DiagnosisGroup = this.selectedReportItem.DiagnosisGroup;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.PackageProcedureInfo = this.selectedReportItem.PackageProcedureInfo;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.ReportDate = this.selectedReportItem.ReportDate;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.ReportEndDate = this.selectedReportItem.ReportEndDate;


        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.ReportInfo = this.selectedReportItem.ReportInfo;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.ReportNo = this.selectedReportItem.ReportNo;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.ReportStartDate = this.selectedReportItem.ReportStartDate;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.ReportTime = this.selectedReportItem.ReportTime;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.ReportType = this.selectedReportItem.ReportType;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.SessionDay = this.selectedReportItem.SessionDay;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.SessionLimit = this.selectedReportItem.SessionLimit;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisReports.TreatmentType = this.selectedReportItem.TreatmentType;


        this.showHemodialysisReportPopup = false;
        this.selectedReportItem = null;

    }

    async CancelHemodialysisReport() {
        this.showHemodialysisReportPopup = false;
        this.selectedReportItem = null;
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HemodialysisOrder();
        this.hemodialysisPlanFormViewModel = new HemodialysisPlanFormViewModel();
        this._ViewModel = this.hemodialysisPlanFormViewModel;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder = this._TTObject as HemodialysisOrder;
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisRequest = new HemodialysisRequest();
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.TreatmentEquipment = new ResEquipment();
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.TreatmentDiagnosisUnit = new ResTreatmentDiagnosisUnit();
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.PackageProcedure = new PackageProcedureDefinition();
        this.hemodialysisPlanFormViewModel._HemodialysisOrder.DialysisFrequency = new SKRSDiyalizeGirmeSikligi();
    }

    protected loadViewModel() {
        let that = this;
        that.hemodialysisPlanFormViewModel = this._ViewModel as HemodialysisPlanFormViewModel;
        that._TTObject = this.hemodialysisPlanFormViewModel._HemodialysisOrder;
        if (this.hemodialysisPlanFormViewModel == null)
            this.hemodialysisPlanFormViewModel = new HemodialysisPlanFormViewModel();
        if (this.hemodialysisPlanFormViewModel._HemodialysisOrder == null)
            this.hemodialysisPlanFormViewModel._HemodialysisOrder = new HemodialysisOrder();
        let hemodialysisRequestObjectID = that.hemodialysisPlanFormViewModel._HemodialysisOrder["HemodialysisRequest"];
        if (hemodialysisRequestObjectID != null && (typeof hemodialysisRequestObjectID === "string")) {
            let hemodialysisRequest = that.hemodialysisPlanFormViewModel.HemodialysisRequests.find(o => o.ObjectID.toString() === hemodialysisRequestObjectID.toString());
            if (hemodialysisRequest) {
                that.hemodialysisPlanFormViewModel._HemodialysisOrder.HemodialysisRequest = hemodialysisRequest;
            }
        }

        let treatmentEquipmentObjectID = that.hemodialysisPlanFormViewModel._HemodialysisOrder["TreatmentEquipment"];
        if (treatmentEquipmentObjectID != null && (typeof treatmentEquipmentObjectID === "string")) {
            let treatmentEquipment = that.hemodialysisPlanFormViewModel.ResEquipments.find(o => o.ObjectID.toString() === treatmentEquipmentObjectID.toString());
            if (treatmentEquipment) {
                that.hemodialysisPlanFormViewModel._HemodialysisOrder.TreatmentEquipment = treatmentEquipment;
            }
        }

        let treatmentDiagnosisUnitObjectID = that.hemodialysisPlanFormViewModel._HemodialysisOrder["TreatmentDiagnosisUnit"];
        if (treatmentDiagnosisUnitObjectID != null && (typeof treatmentDiagnosisUnitObjectID === "string")) {
            let treatmentDiagnosisUnit = that.hemodialysisPlanFormViewModel.ResTreatmentDiagnosisUnits.find(o => o.ObjectID.toString() === treatmentDiagnosisUnitObjectID.toString());
            if (treatmentDiagnosisUnit) {
                that.hemodialysisPlanFormViewModel._HemodialysisOrder.TreatmentDiagnosisUnit = treatmentDiagnosisUnit;
            }
        }

        let packageProcedureObjectID = that.hemodialysisPlanFormViewModel._HemodialysisOrder["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.hemodialysisPlanFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.hemodialysisPlanFormViewModel._HemodialysisOrder.PackageProcedure = packageProcedure;
            }
        }

        let dialysisFrequencyObjectID = that.hemodialysisPlanFormViewModel._HemodialysisOrder["DialysisFrequency"];
        if (dialysisFrequencyObjectID != null && (typeof dialysisFrequencyObjectID === "string")) {
            let dialysisFrequency = that.hemodialysisPlanFormViewModel.SKRSDiyalizeGirmeSikligis.find(o => o.ObjectID.toString() === dialysisFrequencyObjectID.toString());
            if (dialysisFrequency) {
                that.hemodialysisPlanFormViewModel._HemodialysisOrder.DialysisFrequency = dialysisFrequency;
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
        redirectProperty(this.Duration, "Text", this.__ttObject, "Duration");
        redirectProperty(this.IsWeekendInclude, "Value", this.__ttObject, "IsWeekendInclude");
        redirectProperty(this.Information, "Text", this.__ttObject, "Information");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
    }

    public initFormControls(): void {
        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Text = "Acil";
        this.Emergency.Title = "Acil";
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 26;

        this.IsWeekendInclude = new TTVisual.TTCheckBox();
        this.IsWeekendInclude.Value = false;
        this.IsWeekendInclude.Text = "Haftasonu Dahil";
        this.IsWeekendInclude.Title = "Haftasonu Dahil";
        this.IsWeekendInclude.Name = "IsWeekendInclude";
        this.IsWeekendInclude.TabIndex = 24;

        this.labelDuration = new TTVisual.TTLabel();
        this.labelDuration.Text = "Süre";
        this.labelDuration.Name = "labelDuration";
        this.labelDuration.TabIndex = 24;

        this.Duration = new TTVisual.TTTextBox();
        this.Duration.Required = true;
        this.Duration.BackColor = "#FFE3C6";
        this.Duration.Name = "Duration";
        this.Duration.TabIndex = 23;

        this.SessionDayRange = new TTVisual.TTTextBox();
        this.SessionDayRange.Name = "SessionDayRange";
        this.SessionDayRange.TabIndex = 2;

        this.SessionCount = new TTVisual.TTTextBox();
        this.SessionCount.Name = "SessionCount";
        this.SessionCount.TabIndex = 0;

        this.Information = new TTVisual.TTTextBox();
        this.Information.Name = "Information";
        this.Information.TabIndex = 19;

        this.labelTreatmentEquipment = new TTVisual.TTLabel();
        this.labelTreatmentEquipment.Text = "Tedavi Cihazı";
        this.labelTreatmentEquipment.Name = "labelTreatmentEquipment";
        this.labelTreatmentEquipment.TabIndex = 22;

        this.TreatmentEquipment = new TTVisual.TTObjectListBox();
        this.TreatmentEquipment.Required = true;
        this.TreatmentEquipment.ListDefName = "EquipmentListDefinition";
        this.TreatmentEquipment.Name = "TreatmentEquipment";
        this.TreatmentEquipment.TabIndex = 21;

        this.labelTreatmentDiagnosisUnit = new TTVisual.TTLabel();
        this.labelTreatmentDiagnosisUnit.Text = "Seans Birimi";
        this.labelTreatmentDiagnosisUnit.Name = "labelTreatmentDiagnosisUnit";
        this.labelTreatmentDiagnosisUnit.TabIndex = 24;

        this.TreatmentDiagnosisUnit = new TTVisual.TTObjectListBox();
        this.TreatmentDiagnosisUnit.ListDefName = "TreatmentDiagnosisUnitListDefinition";
        this.TreatmentDiagnosisUnit.Name = "TreatmentDiagnosisUnit";
        this.TreatmentDiagnosisUnit.TabIndex = 23;

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

        this.labelInformation = new TTVisual.TTLabel();
        this.labelInformation.Text = "Açıklama";
        this.labelInformation.Name = "labelInformation";
        this.labelInformation.TabIndex = 20;

        this.Controls = [this.labelSessionDayRangeType, this.IsWeekendInclude, this.labelDuration, this.Duration, this.Information, this.SessionDayRange, this.SessionCount, this.labelTreatmentEquipment, this.TreatmentEquipment, this.labelTreatmentDiagnosisUnit, this.TreatmentDiagnosisUnit, this.labelInformation, this.labelPackageProcedure, this.PackageProcedure, this.labelDialysisFrequency, this.DialysisFrequency, this.Emergency, this.labelTreatmentStartDateTime, this.TreatmentStartDateTime, this.SessionDayRangeType, this.labelSessionDayRange, this.labelSessionCount];

    }


}
