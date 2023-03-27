//$32B00718
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PhototherapyFormViewModel } from './PhototherapyFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMultipleDataEntryForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryForm";
import { Phototherapy } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'PhototherapyForm',
    templateUrl: './PhototherapyForm.html',
    providers: [MessageService]
})
export class PhototherapyForm extends BaseMultipleDataEntryForm implements OnInit {
    Complication: TTVisual.ITTCheckBox;
    EntryDate: TTVisual.ITTDateTimePicker;
    labelEntryDate: TTVisual.ITTLabel;
    labelProcessDate: TTVisual.ITTLabel;
    labelProcessEndTime: TTVisual.ITTLabel;
    labelProcessStartTime: TTVisual.ITTLabel;
    labelRequesterPerson: TTVisual.ITTLabel;
    ProcessDate: TTVisual.ITTDateTimePicker;
    ProcessEndTime: TTVisual.ITTDateTimePicker;
    ProcessStartTime: TTVisual.ITTDateTimePicker;
    RequesterPerson: TTVisual.ITTObjectListBox;
    public phototherapyFormViewModel: PhototherapyFormViewModel = new PhototherapyFormViewModel();
    public get _Phototherapy(): Phototherapy {
        return this._TTObject as Phototherapy;
    }
    private PhototherapyForm_DocumentUrl: string = '/api/PhototherapyService/PhototherapyForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.PhototherapyForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public PhototherapyWeightTemp: number = -999;
    setPhototherapyWeightTemp(Weight: number) {
        if (this.PhototherapyWeightTemp != Weight) {
            this.PhototherapyWeightTemp = Weight;
            return true;
        }
        return false;
    }
    getPhototherapyWeightTemp(Weight: number) {
        if (this.PhototherapyWeightTemp != Weight) {
            return false;
        }
        return true;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Phototherapy();
        this.phototherapyFormViewModel = new PhototherapyFormViewModel();
        this._ViewModel = this.phototherapyFormViewModel;
        this.phototherapyFormViewModel._Phototherapy = this._TTObject as Phototherapy;
        this.phototherapyFormViewModel._Phototherapy.RequesterPerson = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.phototherapyFormViewModel = this._ViewModel as PhototherapyFormViewModel;
        that._TTObject = this.phototherapyFormViewModel._Phototherapy;
        if (this.phototherapyFormViewModel == null)
            this.phototherapyFormViewModel = new PhototherapyFormViewModel();
        if (this.phototherapyFormViewModel._Phototherapy == null)
            this.phototherapyFormViewModel._Phototherapy = new Phototherapy();
        let requesterPersonObjectID = that.phototherapyFormViewModel._Phototherapy["RequesterPerson"];
        if (requesterPersonObjectID != null && (typeof requesterPersonObjectID === "string")) {
            let requesterPerson = that.phototherapyFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requesterPersonObjectID.toString());
            if (requesterPerson) {
                that.phototherapyFormViewModel._Phototherapy.RequesterPerson = requesterPerson;
            }
        }

        this.PhototherapyWeightTemp = that.phototherapyFormViewModel.PhototherapyDefinitionList[0].MinWeight;
    }


    async ngOnInit() {
        await this.load();
    }

    public onComplicationChanged(event): void {
        if (this._Phototherapy != null && this._Phototherapy.Complication != event) {
            this._Phototherapy.Complication = event;
        }
    }

    public onEntryDateChanged(event): void {
        if (this._Phototherapy != null && this._Phototherapy.EntryDate != event) {
            this._Phototherapy.EntryDate = event;
        }
    }

    public onProcessDateChanged(event): void {
        if (this._Phototherapy != null && this._Phototherapy.ProcessDate != event) {
            this._Phototherapy.ProcessDate = event;
        }
    }

    public onProcessEndTimeChanged(event): void {
        if (this._Phototherapy != null && this._Phototherapy.ProcessEndTime != event) {
            this._Phototherapy.ProcessEndTime = event;
        }
    }

    public onProcessStartTimeChanged(event): void {
        if (this._Phototherapy != null && this._Phototherapy.ProcessStartTime != event) {
            this._Phototherapy.ProcessStartTime = event;
        }
    }

    public onRequesterPersonChanged(event): void {
        if (this._Phototherapy != null && this._Phototherapy.RequesterPerson != event) {
            this._Phototherapy.RequesterPerson = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.EntryDate, "Value", this.__ttObject, "EntryDate");
        redirectProperty(this.Complication, "Value", this.__ttObject, "Complication");
        redirectProperty(this.ProcessDate, "Value", this.__ttObject, "ProcessDate");
        redirectProperty(this.ProcessEndTime, "Value", this.__ttObject, "ProcessEndTime");
        redirectProperty(this.ProcessStartTime, "Value", this.__ttObject, "ProcessStartTime");
    }

    public initFormControls(): void {
        this.labelRequesterPerson = new TTVisual.TTLabel();
        this.labelRequesterPerson.Text = "Sorumlu";
        this.labelRequesterPerson.Name = "labelRequesterPerson";
        this.labelRequesterPerson.TabIndex = 10;

        this.RequesterPerson = new TTVisual.TTObjectListBox();
        this.RequesterPerson.ListDefName = "DoctorAndNurseList";
        this.RequesterPerson.Name = "RequesterPerson";
        this.RequesterPerson.TabIndex = 9;

        this.labelEntryDate = new TTVisual.TTLabel();
        this.labelEntryDate.Text = "Giriş Yapılan Zaman";
        this.labelEntryDate.Name = "labelEntryDate";
        this.labelEntryDate.TabIndex = 8;

        this.EntryDate = new TTVisual.TTDateTimePicker();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.TabIndex = 7;

        this.labelProcessStartTime = new TTVisual.TTLabel();
        this.labelProcessStartTime.Text = "Başlangıç Saati";
        this.labelProcessStartTime.Name = "labelProcessStartTime";
        this.labelProcessStartTime.TabIndex = 6;

        this.ProcessStartTime = new TTVisual.TTDateTimePicker();
        this.ProcessStartTime.Format = DateTimePickerFormat.Long;
        this.ProcessStartTime.Name = "ProcessStartTime";
        this.ProcessStartTime.TabIndex = 5;

        this.labelProcessEndTime = new TTVisual.TTLabel();
        this.labelProcessEndTime.Text = "Bitiş Saati";
        this.labelProcessEndTime.Name = "labelProcessEndTime";
        this.labelProcessEndTime.TabIndex = 4;

        this.ProcessEndTime = new TTVisual.TTDateTimePicker();
        this.ProcessEndTime.Format = DateTimePickerFormat.Long;
        this.ProcessEndTime.Name = "ProcessEndTime";
        this.ProcessEndTime.TabIndex = 3;

        this.labelProcessDate = new TTVisual.TTLabel();
        this.labelProcessDate.Text = "İşlem Tarihi";
        this.labelProcessDate.Name = "labelProcessDate";
        this.labelProcessDate.TabIndex = 2;

        this.ProcessDate = new TTVisual.TTDateTimePicker();
        this.ProcessDate.Format = DateTimePickerFormat.Long;
        this.ProcessDate.Name = "ProcessDate";
        this.ProcessDate.TabIndex = 1;

        this.Complication = new TTVisual.TTCheckBox();
        this.Complication.Value = false;
        this.Complication.Text = "Komplikasyon Mevcut Mu?";
        this.Complication.Title = "Komplikasyon Mevcut Mu?";
        this.Complication.Name = "Complication";
        this.Complication.TabIndex = 0;

        this.Controls = [this.labelRequesterPerson, this.RequesterPerson, this.labelEntryDate, this.EntryDate, this.labelProcessStartTime, this.ProcessStartTime, this.labelProcessEndTime, this.ProcessEndTime, this.labelProcessDate, this.ProcessDate, this.Complication];

    }


}
