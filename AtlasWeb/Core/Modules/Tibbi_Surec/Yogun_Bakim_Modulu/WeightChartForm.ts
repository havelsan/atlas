//$08F7E5E0
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { WeightChartFormViewModel } from './WeightChartFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { WeightChart } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'WeightChartForm',
    templateUrl: './WeightChartForm.html',
    providers: [MessageService]
})
export class WeightChartForm extends BaseMultipleDataEntryForm implements OnInit {
    EntryDate: TTVisual.ITTDateTimePicker;
    HeadCircumference: TTVisual.ITTTextBox;
    labelEntryDate: TTVisual.ITTLabel;
    labelHeadCircumference: TTVisual.ITTLabel;
    labelLength: TTVisual.ITTLabel;
    labelMeasuringPerson: TTVisual.ITTLabel;
    labelRequesterPerson: TTVisual.ITTLabel;
    labelWeight: TTVisual.ITTLabel;
    Length: TTVisual.ITTTextBox;
    MeasuringPerson: TTVisual.ITTTextBox;
    RequesterPerson: TTVisual.ITTObjectListBox;
    Weight: TTVisual.ITTTextBox;
    public weightChartFormViewModel: WeightChartFormViewModel = new WeightChartFormViewModel();
    public get _WeightChart(): WeightChart {
        return this._TTObject as WeightChart;
    }
    private WeightChartForm_DocumentUrl: string = '/api/WeightChartService/WeightChartForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.WeightChartForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new WeightChart();
        this.weightChartFormViewModel = new WeightChartFormViewModel();
        this._ViewModel = this.weightChartFormViewModel;
        this.weightChartFormViewModel._WeightChart = this._TTObject as WeightChart;
        this.weightChartFormViewModel._WeightChart.RequesterPerson = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.weightChartFormViewModel = this._ViewModel as WeightChartFormViewModel;
        that._TTObject = this.weightChartFormViewModel._WeightChart;
        if (this.weightChartFormViewModel == null)
            this.weightChartFormViewModel = new WeightChartFormViewModel();
        if (this.weightChartFormViewModel._WeightChart == null)
            this.weightChartFormViewModel._WeightChart = new WeightChart();
        let requesterPersonObjectID = that.weightChartFormViewModel._WeightChart["RequesterPerson"];
        if (requesterPersonObjectID != null && (typeof requesterPersonObjectID === "string")) {
            let requesterPerson = that.weightChartFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requesterPersonObjectID.toString());
            if (requesterPerson) {
                that.weightChartFormViewModel._WeightChart.RequesterPerson = requesterPerson;
            }
        }

    }


    async ngOnInit() {
        await this.load();
    }

    public onEntryDateChanged(event): void {
        if (this._WeightChart != null && this._WeightChart.EntryDate != event) {
            this._WeightChart.EntryDate = event;
        }
    }

    public onHeadCircumferenceChanged(event): void {
        if (this._WeightChart != null && this._WeightChart.HeadCircumference != event) {
            this._WeightChart.HeadCircumference = event;
        }
    }

    public onLengthChanged(event): void {
        if (this._WeightChart != null && this._WeightChart.Length != event) {
            this._WeightChart.Length = event;
        }
    }

    public onMeasuringPersonChanged(event): void {
        if (this._WeightChart != null && this._WeightChart.MeasuringPerson != event) {
            this._WeightChart.MeasuringPerson = event;
        }
    }

    public onRequesterPersonChanged(event): void {
        if (this._WeightChart != null && this._WeightChart.RequesterPerson != event) {
            this._WeightChart.RequesterPerson = event;
        }
    }

    public onWeightChanged(event): void {
        if (this._WeightChart != null && this._WeightChart.Weight != event) {
            this._WeightChart.Weight = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.HeadCircumference, "Text", this.__ttObject, "HeadCircumference");
        redirectProperty(this.Length, "Text", this.__ttObject, "Length");
        redirectProperty(this.MeasuringPerson, "Text", this.__ttObject, "MeasuringPerson");
        redirectProperty(this.Weight, "Text", this.__ttObject, "Weight");
    }

    public initFormControls(): void {
        this.labelRequesterPerson = new TTVisual.TTLabel();
        this.labelRequesterPerson.Text = "Ölçümü Yapan";
        this.labelRequesterPerson.Name = "labelRequesterPerson";
        this.labelRequesterPerson.TabIndex = 13;

        this.RequesterPerson = new TTVisual.TTObjectListBox();
        this.RequesterPerson.ListDefName = "DoctorAndNurseList";
        this.RequesterPerson.Name = "RequesterPerson";
        this.RequesterPerson.TabIndex = 12;

        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 11;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 10;

        this.labelWeight = new TTVisual.TTLabel();
        this.labelWeight.Text = "Kilo";
        this.labelWeight.Name = "labelWeight";
        this.labelWeight.TabIndex = 9;

        this.Weight = new TTVisual.TTTextBox();
        this.Weight.Name = "Weight";
        this.Weight.TabIndex = 8;

        this.MeasuringPerson = new TTVisual.TTTextBox();
        this.MeasuringPerson.Name = "MeasuringPerson";
        this.MeasuringPerson.TabIndex = 4;

        this.Length = new TTVisual.TTTextBox();
        this.Length.Name = "Length";
        this.Length.TabIndex = 2;

        this.HeadCircumference = new TTVisual.TTTextBox();
        this.HeadCircumference.Name = "HeadCircumference";
        this.HeadCircumference.TabIndex = 0;

        this.labelMeasuringPerson = new TTVisual.TTLabel();
        this.labelMeasuringPerson.Text = "Ölçümü Yapan";
        this.labelMeasuringPerson.Name = "labelMeasuringPerson";
        this.labelMeasuringPerson.TabIndex = 5;

        this.labelLength = new TTVisual.TTLabel();
        this.labelLength.Text = "Boy";
        this.labelLength.Name = "labelLength";
        this.labelLength.TabIndex = 3;

        this.labelHeadCircumference = new TTVisual.TTLabel();
        this.labelHeadCircumference.Text = "Baş Çevresi";
        this.labelHeadCircumference.Name = "labelHeadCircumference";
        this.labelHeadCircumference.TabIndex = 1;

        this.Controls = [this.labelRequesterPerson, this.RequesterPerson, this.labelEntryDate, this.EntryDate, this.labelWeight, this.Weight, this.MeasuringPerson, this.Length, this.HeadCircumference, this.labelMeasuringPerson, this.labelLength, this.labelHeadCircumference];

    }


}
