//$70301B5A
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseNursingSystemInterrogationFormViewModel } from './BaseNursingSystemInterrogationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { BaseNursingSystemInterrogation } from 'NebulaClient/Model/AtlasClientModel';
import { NursingSystemInterrogation } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'BaseNursingSystemInterrogationForm',
    templateUrl: './BaseNursingSystemInterrogationForm.html',
    providers: [MessageService]
})
export class BaseNursingSystemInterrogationForm extends BaseNursingDataEntryForm implements OnInit {
    ApplicationDate: TTVisual.ITTDateTimePicker;
    labelApplicationDate: TTVisual.ITTLabel;
    NursingSystemInterrogations: TTVisual.ITTGrid;
    SystemInterrogationNursingSystemInterrogation: TTVisual.ITTListBoxColumn;
    public NursingSystemInterrogationsColumns = [];
    public baseNursingSystemInterrogationFormViewModel: BaseNursingSystemInterrogationFormViewModel = new BaseNursingSystemInterrogationFormViewModel();
    public get _BaseNursingSystemInterrogation(): BaseNursingSystemInterrogation {
        return this._TTObject as BaseNursingSystemInterrogation;
    }
    private BaseNursingSystemInterrogationForm_DocumentUrl: string = '/api/BaseNursingSystemInterrogationService/BaseNursingSystemInterrogationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseNursingSystemInterrogationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseNursingSystemInterrogation();
        this.baseNursingSystemInterrogationFormViewModel = new BaseNursingSystemInterrogationFormViewModel();
        this._ViewModel = this.baseNursingSystemInterrogationFormViewModel;
        this.baseNursingSystemInterrogationFormViewModel._BaseNursingSystemInterrogation = this._TTObject as BaseNursingSystemInterrogation;
        this.baseNursingSystemInterrogationFormViewModel._BaseNursingSystemInterrogation.NursingSystemInterrogations = new Array<NursingSystemInterrogation>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseNursingSystemInterrogationFormViewModel = this._ViewModel as BaseNursingSystemInterrogationFormViewModel;
        that._TTObject = this.baseNursingSystemInterrogationFormViewModel._BaseNursingSystemInterrogation;
        if (this.baseNursingSystemInterrogationFormViewModel == null)
            this.baseNursingSystemInterrogationFormViewModel = new BaseNursingSystemInterrogationFormViewModel();
        if (this.baseNursingSystemInterrogationFormViewModel._BaseNursingSystemInterrogation == null)
            this.baseNursingSystemInterrogationFormViewModel._BaseNursingSystemInterrogation = new BaseNursingSystemInterrogation();
        that.baseNursingSystemInterrogationFormViewModel._BaseNursingSystemInterrogation.NursingSystemInterrogations = that.baseNursingSystemInterrogationFormViewModel.NursingSystemInterrogationsGridList;
        for (let detailItem of that.baseNursingSystemInterrogationFormViewModel.NursingSystemInterrogationsGridList) {
            let systemInterrogationObjectID = detailItem["SystemInterrogation"];
            if (systemInterrogationObjectID != null && (typeof systemInterrogationObjectID === 'string')) {
                let systemInterrogation = that.baseNursingSystemInterrogationFormViewModel.SystemInterrogationDefinitions.find(o => o.ObjectID.toString() === systemInterrogationObjectID.toString());
                 if (systemInterrogation) {
                    detailItem.SystemInterrogation = systemInterrogation;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BaseNursingSystemInterrogationFormViewModel);
  
    }


    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.baseNursingSystemInterrogationFormViewModel.ReadOnly = (this.baseNursingSystemInterrogationFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.baseNursingSystemInterrogationFormViewModel.ReadOnly)
            this.DropStateButton(BaseNursingSystemInterrogation.BaseNursingDataEntryStates.Cancelled);
        super.ClientSidePreScript();
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._BaseNursingSystemInterrogation != null && this._BaseNursingSystemInterrogation.ApplicationDate != event) {
                this._BaseNursingSystemInterrogation.ApplicationDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
    }

    public initFormControls(): void {
        this.NursingSystemInterrogations = new TTVisual.TTGrid();
        this.NursingSystemInterrogations.Name = "NursingSystemInterrogations";
        this.NursingSystemInterrogations.TabIndex = 2;

        this.SystemInterrogationNursingSystemInterrogation = new TTVisual.TTListBoxColumn();
        this.SystemInterrogationNursingSystemInterrogation.DataMember = "SystemInterrogation";
        this.SystemInterrogationNursingSystemInterrogation.DisplayIndex = 0;
        this.SystemInterrogationNursingSystemInterrogation.HeaderText = i18n("M21922", "Sistem Sorguları");
        this.SystemInterrogationNursingSystemInterrogation.Name = "SystemInterrogationNursingSystemInterrogation";
        this.SystemInterrogationNursingSystemInterrogation.Width = 300;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 1;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 0;

        this.NursingSystemInterrogationsColumns = [this.SystemInterrogationNursingSystemInterrogation];
        this.Controls = [this.NursingSystemInterrogations, this.SystemInterrogationNursingSystemInterrogation, this.labelApplicationDate, this.ApplicationDate];

    }
    public onCheckValueChanged(event, obj) {
        if (event != undefined) {

            if (event)
            {
                let _tempObj: NursingSystemInterrogation = new NursingSystemInterrogation();
                _tempObj.SystemInterrogation = obj;

                this.baseNursingSystemInterrogationFormViewModel.NursingSystemInterrogationsGridList.push(_tempObj);
            }
            else {
                //var index = this.baseNursingSystemInterrogationFormViewModel.NursingSystemInterrogationsGridList.indexOf(_tempObj, 0);
                let index = this.baseNursingSystemInterrogationFormViewModel.NursingSystemInterrogationsGridList.map(function (x) { return x.SystemInterrogation.ObjectID.toString(); }).indexOf(obj.ObjectID.toString());
                if (index > -1) {
                    this.baseNursingSystemInterrogationFormViewModel.NursingSystemInterrogationsGridList.splice(index, 1);
                }
            }
        }
    }

    public isValueExists(ObjectID: string): boolean {
        if (this.baseNursingSystemInterrogationFormViewModel.NursingSystemInterrogationsGridList.length > 0)
            if (this.baseNursingSystemInterrogationFormViewModel.NursingSystemInterrogationsGridList.find(o => o.SystemInterrogation.ObjectID.toString() == ObjectID) != undefined)
                return true;

        return false;
    }


}
