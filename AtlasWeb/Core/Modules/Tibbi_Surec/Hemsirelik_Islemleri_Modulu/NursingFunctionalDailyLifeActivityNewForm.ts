//$068FF79A
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingFunctionalDailyLifeActivityNewFormViewModel } from './NursingFunctionalDailyLifeActivityNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingDailyLifeActivity } from 'NebulaClient/Model/AtlasClientModel';
import { NursingFunctionalDailyLifeActivity } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from "app/NebulaClient/Mscorlib/GuidParam";
import { DateParam } from 'app/NebulaClient/Mscorlib/DateParam';

@Component({
    selector: 'NursingFunctionalDailyLifeActivityNewForm',
    templateUrl: './NursingFunctionalDailyLifeActivityNewForm.html',
    providers: [MessageService]
})
export class NursingFunctionalDailyLifeActivityNewForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    DetailNote: TTVisual.ITTTextBoxColumn;
    FunctionalDailyLifeActivity: TTVisual.ITTListBoxColumn;
    Ischeck: TTVisual.ITTCheckBoxColumn;
    labelApplicationDate: TTVisual.ITTLabel;
    labelNote: TTVisual.ITTLabel;
    NursingFunctionalDailyLifeActivity: TTVisual.ITTGrid;
    tttextbox1: TTVisual.ITTTextBox;
    public NursingFunctionalDailyLifeActivityColumns = [];
    public FunctionalDailyLifeActivityListColumns = [];
    public nursingFunctionalDailyLifeActivityNewFormViewModel: NursingFunctionalDailyLifeActivityNewFormViewModel = new NursingFunctionalDailyLifeActivityNewFormViewModel();
    public get _NursingDailyLifeActivity(): NursingDailyLifeActivity {
        return this._TTObject as NursingDailyLifeActivity;
    }
    private NursingFunctionalDailyLifeActivityNewForm_DocumentUrl: string = '/api/NursingDailyLifeActivityService/NursingFunctionalDailyLifeActivityNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone,
        protected reportService: AtlasReportService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingFunctionalDailyLifeActivityNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    getCellData(cellData: any) {
        return Util.ResolveProperty(cellData.column.dataField, cellData.data);
    }

    setCellData(cellData: any, $event: any) {
        Util.SetPropertyValue(cellData.column.dataField, cellData.data, $event);
    }

    public initViewModel(): void {
        this._TTObject = new NursingDailyLifeActivity();
        this.nursingFunctionalDailyLifeActivityNewFormViewModel = new NursingFunctionalDailyLifeActivityNewFormViewModel();
        this._ViewModel = this.nursingFunctionalDailyLifeActivityNewFormViewModel;
        this.nursingFunctionalDailyLifeActivityNewFormViewModel._NursingDailyLifeActivity = this._TTObject as NursingDailyLifeActivity;
        this.nursingFunctionalDailyLifeActivityNewFormViewModel._NursingDailyLifeActivity.NursingFunctionalDailyLifeActivities = new Array<NursingFunctionalDailyLifeActivity>();
    }

    protected loadViewModel() {
        let that = this;

        that.nursingFunctionalDailyLifeActivityNewFormViewModel = this._ViewModel as NursingFunctionalDailyLifeActivityNewFormViewModel;
        that._TTObject = this.nursingFunctionalDailyLifeActivityNewFormViewModel._NursingDailyLifeActivity;
        if (this.nursingFunctionalDailyLifeActivityNewFormViewModel == null)
            this.nursingFunctionalDailyLifeActivityNewFormViewModel = new NursingFunctionalDailyLifeActivityNewFormViewModel();
        if (this.nursingFunctionalDailyLifeActivityNewFormViewModel._NursingDailyLifeActivity == null)
            this.nursingFunctionalDailyLifeActivityNewFormViewModel._NursingDailyLifeActivity = new NursingDailyLifeActivity();
        that.nursingFunctionalDailyLifeActivityNewFormViewModel._NursingDailyLifeActivity.NursingFunctionalDailyLifeActivities = that.nursingFunctionalDailyLifeActivityNewFormViewModel.NursingFunctionalDailyLifeActivityGridList;
        for (let detailItem of that.nursingFunctionalDailyLifeActivityNewFormViewModel.NursingFunctionalDailyLifeActivityGridList) {
            let dailyLifeActivityObjectID = detailItem["DailyLifeActivity"];
            if (dailyLifeActivityObjectID != null && (typeof dailyLifeActivityObjectID === 'string')) {
                let dailyLifeActivity = that.nursingFunctionalDailyLifeActivityNewFormViewModel.DailyLifeActivityDefinitions.find(o => o.ObjectID.toString() === dailyLifeActivityObjectID.toString());
                if (dailyLifeActivity) {
                    detailItem.DailyLifeActivity = dailyLifeActivity;
                }
            }
        }
        if (that.nursingFunctionalDailyLifeActivityNewFormViewModel.QuarantineInPatientDate != undefined)
            this.startDate = that.nursingFunctionalDailyLifeActivityNewFormViewModel.QuarantineInPatientDate;
        else
            this.startDate = new Date();

    }

    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.nursingFunctionalDailyLifeActivityNewFormViewModel.ReadOnly = (this.nursingFunctionalDailyLifeActivityNewFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.nursingFunctionalDailyLifeActivityNewFormViewModel.ReadOnly)
            this.DropStateButton(NursingDailyLifeActivity.NursingDailyLifeActivityStates.Cancelled);
        super.ClientSidePreScript();
    }
    public startDate: Date;
    public endDate: Date = new Date();
    public ShowGetPrintDatesPopUp: boolean = false;
    async printReportGetDate() {

        this.ShowGetPrintDatesPopUp = true;
    }

    printDateOkClick() {

        let a: any = this.nursingFunctionalDailyLifeActivityNewFormViewModel._NursingDailyLifeActivity.NursingApplication;
        if (a.ObjectID != undefined)
            a = a.ObjectID;

        while (this.startDate < this.endDate) {
            const TTOBJECTID = new GuidParam(a);
            const STARTTIME = new DateParam(this.startDate);
            this.printReport(TTOBJECTID, STARTTIME);
            this.startDate = this.startDate.AddDays(30);
        }
        this.ShowGetPrintDatesPopUp = false;
        if (this.nursingFunctionalDailyLifeActivityNewFormViewModel.QuarantineInPatientDate != undefined)
            this.startDate = this.nursingFunctionalDailyLifeActivityNewFormViewModel.QuarantineInPatientDate;
        else
            this.startDate = new Date();
    }
    printDateCancelClick() {
        this.ShowGetPrintDatesPopUp = false;
    }

    printReport(TTOBJECTID: GuidParam, STARTTIME: DateParam) {
        let reportParameters: any = {
            'TTOBJECTID': TTOBJECTID,
            'STARTTIME': STARTTIME
        };
        this.reportService.showReport('NursingFDLAReport', reportParameters);
    }

    async ngOnInit() {
        let that = this;
        await this.load(NursingFunctionalDailyLifeActivityNewFormViewModel);
  
    }


    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingDailyLifeActivity != null && this._NursingDailyLifeActivity.ApplicationDate != event) {
                this._NursingDailyLifeActivity.ApplicationDate = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._NursingDailyLifeActivity != null && this._NursingDailyLifeActivity.Note != event) {
                this._NursingDailyLifeActivity.Note = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Note");
    }

    public initFormControls(): void {
        this.NursingFunctionalDailyLifeActivity = new TTVisual.TTGrid();
        this.NursingFunctionalDailyLifeActivity.Name = "NursingFunctionalDailyLifeActivity";
        this.NursingFunctionalDailyLifeActivity.TabIndex = 4;

        this.Ischeck = new TTVisual.TTCheckBoxColumn();
        this.Ischeck.DataMember = "IsCheck";
        this.Ischeck.DisplayIndex = 0;
        this.Ischeck.HeaderText = "Evet/Hayır";
        this.Ischeck.Name = "Ischeck";
        this.Ischeck.Width = 60;

        this.FunctionalDailyLifeActivity = new TTVisual.TTListBoxColumn();
        this.FunctionalDailyLifeActivity.ListDefName = "FunctionalDailyLifeActivityListDefinition";
        this.FunctionalDailyLifeActivity.DataMember = "DailyLifeActivity";
        this.FunctionalDailyLifeActivity.DisplayIndex = 1;
        this.FunctionalDailyLifeActivity.HeaderText = i18n("M14455", "Fonksiyonel Değerlendirme");
        this.FunctionalDailyLifeActivity.MinimumWidth = 50;
        this.FunctionalDailyLifeActivity.Name = "FunctionalDailyLifeActivity";
        this.FunctionalDailyLifeActivity.Width = 250;
        this.FunctionalDailyLifeActivity.ReadOnly = true;

        this.DetailNote = new TTVisual.TTTextBoxColumn();
        this.DetailNote.DataMember = "DetailNote";
        this.DetailNote.DisplayIndex = 2;
        this.DetailNote.HeaderText = i18n("M10469", "Açıklama");
        this.DetailNote.MinimumWidth = 50;
        this.DetailNote.Name = "DetailNote";
        this.DetailNote.Width = 400;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 3;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 2;

        this.labelNote = new TTVisual.TTLabel();
        this.labelNote.Text = i18n("M14738", "Genl Not");
        this.labelNote.Name = "labelNote";
        this.labelNote.TabIndex = 1;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 0;

        this.NursingFunctionalDailyLifeActivityColumns = [this.FunctionalDailyLifeActivity, this.Ischeck, this.DetailNote];
        this.FunctionalDailyLifeActivityListColumns = [
            { caption: i18n("M14447", "Fonksiyon"), dataField: 'DailyLifeActivity.Name', fixed: true, width: '250px', allowEditing: false },
            { caption: '', dataField: 'IsCheck', dataType: 'boolean', fixed: true, width: '40px', allowEditing: true, cellTemplate: "chkTemplate" },
            { caption: i18n("M10469", "Açıklama"), dataField: 'DetailNote', fixed: true, width: '40%', allowEditing: true, cellTemplate: "explanationTemplate" }

        ];
        //this.NursingFunctionalDailyLifeActivityColumns = [
        //    { caption: 'Alan', dataField: 'FunctionalDailyLifeActivity.Name', fixed: true, width: '20%', allowEditing: false },
        //    { caption: 'Note', dataField: 'DetailNote', fixed: true, width: '20%', allowEditing: false }
        //    //this.Ischeck, this.FunctionalDailyLifeActivity, this.DetailNote
        //]
        this.Controls = [this.NursingFunctionalDailyLifeActivity, this.Ischeck, this.FunctionalDailyLifeActivity, this.DetailNote, this.labelApplicationDate, this.ApplicationDate, this.labelNote, this.tttextbox1];

    }

    public onSelectionChangedDailyLifeList($event) {
        //let dailyLifeActivity = this.nursingFunctionalDailyLifeActivityNewFormViewModel.DailyLifeActivityDefinitions.find(o => o.ObjectID.toString() === dailyLifeActivityObjectID.toString());
        //detailItem.DailyLifeActivity = dailyLifeActivity;
        //for (var i = 0; i < $event.currentSelectedRowKeys.length; i++)
        //{
        //    $event.
        //}
    }

}
