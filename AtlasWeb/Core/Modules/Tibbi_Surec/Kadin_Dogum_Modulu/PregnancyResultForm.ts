//$E5264925
import { Component, OnInit, NgZone } from '@angular/core';
import { PregnancyResultFormViewModel, PregnancyResultComponentInfoViewModel } from './PregnancyResultFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PregnancyResult } from 'NebulaClient/Model/AtlasClientModel';
import { Pregnancy } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGebelikSonucu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKonjenitalAnomaliliDogumVarligi } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';



import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';


@Component({
    selector: 'PregnancyResultForm',
    templateUrl: './PregnancyResultForm.html',
    providers: [MessageService]
})
export class PregnancyResultForm extends TTVisual.TTForm implements OnInit {
    AfterBirthStory: TTVisual.ITTTextBox;
    BabyStatus: TTVisual.ITTEnumComboBox;
    BirthDescription: TTVisual.ITTTextBox;
    BirthResult: TTVisual.ITTObjectListBox;
    BirthTerminationDatePregnancy: TTVisual.ITTDateTimePicker;
    BirthType: TTVisual.ITTObjectListBox;
    BirthWeight: TTVisual.ITTTextBox;
    CesareanReason: TTVisual.ITTTextBox;
    CongenitalAnomalies: TTVisual.ITTObjectListBox;
    Gender: TTVisual.ITTEnumComboBox;
    labelAfterBirthStory: TTVisual.ITTLabel;
    labelBabyStatus: TTVisual.ITTLabel;
    labelBirthDescription: TTVisual.ITTLabel;
    labelBirthResult: TTVisual.ITTLabel;
    labelBirthTerminationDatePregnancy: TTVisual.ITTLabel;
    labelBirthType: TTVisual.ITTLabel;
    labelBirthWeight: TTVisual.ITTLabel;
    labelCesareanReason: TTVisual.ITTLabel;
    labelCongenitalAnomalies: TTVisual.ITTLabel;
    labelGender: TTVisual.ITTLabel;
    public pregnancyResultFormViewModel: PregnancyResultFormViewModel = new PregnancyResultFormViewModel();
    public get _PregnancyResult(): PregnancyResult {
        return this._TTObject as PregnancyResult;
    }
    private PregnancyResultForm_DocumentUrl: string = '/api/PregnancyResultService/PregnancyResultForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super('PREGNANCYRESULT', 'PregnancyResultForm');
        this._DocumentServiceUrl = this.PregnancyResultForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    IsPreviousPregnancy:boolean=false;
    public static getComponentInfoViewModel(pregnancyId: Guid,IsPreviousPregnancy?:boolean): PregnancyResultComponentInfoViewModel {
        let componentInfoViewModel = new PregnancyResultComponentInfoViewModel();
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('1a520a61-52a4-4fc9-9574-41fbf03885d5');
        queryParameters.QueryDefID = new Guid('c7ccecb9-7580-4c48-8b0b-82d8c776f3e2');
        let parameters = {};
        parameters['PREGNANCY'] = new GuidParam(pregnancyId);
        queryParameters.Parameters = parameters;
        componentInfoViewModel.pregnancyResultQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'PregnancyResultForm';
        componentInfo.ModuleName = 'KadinDogumModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Kadin_Dogum_Modulu/KadinDogumModule';
        
        let _inputParam = {};
        _inputParam['IsPreviousPregnancy'] = IsPreviousPregnancy;

        componentInfo.InputParam = new DynamicComponentInputParam(_inputParam, null);

        componentInfoViewModel.pregnancyResultComponentInfo = componentInfo;
        return componentInfoViewModel;
    }

    public static pregnancyResultQueryResultLoaded(e: any) {

        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "BIRTHTERMINATIONDATE") {
                column.caption = i18n("M13125", "Doğum Sonlanma Tarihi");
            }
            if (column.dataField === "BIRTHWEIGHT") {
                column.caption = i18n("M13099", "Doğum Ağırlığı");
            }
            if (column.dataField === "GENDER") {
                column.caption = i18n("M12265", "Cinsiyet");
            }
            if (column.dataField === "BABYSTATUS") {
                column.caption = 'Bebeğin Durumu';
            }
            if (column.dataField === "BIRTHTYPE") {
                column.caption = i18n("M13146", "Doğum Yöntemi");
            }
            if (column.dataField === "BIRTHRESULT") {
                column.caption = i18n("M13147", "Doğuma Sonucu");
            }
            if (column.dataField === "CONGENITALANOMALIES") {
                column.caption = i18n("M17734", "Konjenital Anomalili Doğum");
            }
            if (column.dataField === "BIRTHDESCRIPTION") {
                column.caption = i18n("M13098", "Doğum Açıklaması");
            }
            if (column.dataField === "CESAREANREASON") {
                column.caption = i18n("M21773", "Sezaryan Nedeni");
            }
            if (column.dataField === "AFTERBIRTHSTORY") {
                column.caption = i18n("M13127", "Doğum Sonrası Öyküsü");
            }

        }
    }

    public setInputParam(value: boolean) {
        this.IsPreviousPregnancy=value['IsPreviousPregnancy'];
    }

    // *****Method declarations end *****


    public initViewModel(): void {
        this._TTObject = new PregnancyResult();
        this.pregnancyResultFormViewModel = new PregnancyResultFormViewModel();
        this._ViewModel = this.pregnancyResultFormViewModel;
        this.pregnancyResultFormViewModel._PregnancyResult = this._TTObject as PregnancyResult;
        this.pregnancyResultFormViewModel._PregnancyResult.BirthType = new SKRSDogumYontemi();
        this.pregnancyResultFormViewModel._PregnancyResult.CongenitalAnomalies = new SKRSKonjenitalAnomaliliDogumVarligi();
        this.pregnancyResultFormViewModel._PregnancyResult.BirthResult = new SKRSGebelikSonucu();
        this.pregnancyResultFormViewModel._PregnancyResult.Pregnancy = new Pregnancy();
    }

    protected loadViewModel() {
        let that = this;

        that.pregnancyResultFormViewModel = this._ViewModel as PregnancyResultFormViewModel;
        that._TTObject = this.pregnancyResultFormViewModel._PregnancyResult;
        if (this.pregnancyResultFormViewModel == null)
            this.pregnancyResultFormViewModel = new PregnancyResultFormViewModel();
        if (this.pregnancyResultFormViewModel._PregnancyResult == null)
            this.pregnancyResultFormViewModel._PregnancyResult = new PregnancyResult();
        let birthTypeObjectID = that.pregnancyResultFormViewModel._PregnancyResult["BirthType"];
        if (birthTypeObjectID != null && (typeof birthTypeObjectID === "string")) {
            let birthType = that.pregnancyResultFormViewModel.SKRSDogumYontemis.find(o => o.ObjectID.toString() === birthTypeObjectID.toString());
             if (birthType) {
                that.pregnancyResultFormViewModel._PregnancyResult.BirthType = birthType;
            }
        }
        let congenitalAnomaliesObjectID = that.pregnancyResultFormViewModel._PregnancyResult["CongenitalAnomalies"];
        if (congenitalAnomaliesObjectID != null && (typeof congenitalAnomaliesObjectID === "string")) {
            let congenitalAnomalies = that.pregnancyResultFormViewModel.SKRSKonjenitalAnomaliliDogumVarligis.find(o => o.ObjectID.toString() === congenitalAnomaliesObjectID.toString());
             if (congenitalAnomalies) {
                that.pregnancyResultFormViewModel._PregnancyResult.CongenitalAnomalies = congenitalAnomalies;
            }
        }
        let birthResultObjectID = that.pregnancyResultFormViewModel._PregnancyResult["BirthResult"];
        if (birthResultObjectID != null && (typeof birthResultObjectID === "string")) {
            let birthResult = that.pregnancyResultFormViewModel.SKRSGebelikSonucus.find(o => o.ObjectID.toString() === birthResultObjectID.toString());
             if (birthResult) {
                that.pregnancyResultFormViewModel._PregnancyResult.BirthResult = birthResult;
            }
        }
        let pregnancyObjectID = that.pregnancyResultFormViewModel._PregnancyResult["Pregnancy"];
        if (pregnancyObjectID != null && (typeof pregnancyObjectID === "string")) {
            let pregnancy = that.pregnancyResultFormViewModel.Pregnancys.find(o => o.ObjectID.toString() === pregnancyObjectID.toString());
             if (pregnancy) {
                that.pregnancyResultFormViewModel._PregnancyResult.Pregnancy = pregnancy;
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(PregnancyResultFormViewModel);
  
    }

    public onAfterBirthStoryChanged(event): void {
        if (event != null) {
            if (this._PregnancyResult != null && this._PregnancyResult.AfterBirthStory != event) {
                this._PregnancyResult.AfterBirthStory = event;
            }
        }
    }

    public onBabyStatusChanged(event): void {
        if (event != null) {
            if (this._PregnancyResult != null && this._PregnancyResult.BabyStatus != event) {
                this._PregnancyResult.BabyStatus = event;
            }
        }
    }

    public onBirthDescriptionChanged(event): void {
        if (event != null) {
            if (this._PregnancyResult != null && this._PregnancyResult.BirthDescription != event) {
                this._PregnancyResult.BirthDescription = event;
            }
        }
    }

    public onBirthResultChanged(event): void {
        if (event != null) {
            if (this._PregnancyResult != null && this._PregnancyResult.BirthResult != event) {
                this._PregnancyResult.BirthResult = event;
            }
        }
    }

    public onBirthTerminationDatePregnancyChanged(event): void {
        if (event != null) {
            if (this._PregnancyResult != null &&
                this._PregnancyResult.Pregnancy != null && this._PregnancyResult.Pregnancy.BirthTerminationDate != event) {
                this._PregnancyResult.Pregnancy.BirthTerminationDate = event;
            }
        }
    }

    public onBirthTypeChanged(event): void {
        if (event != null) {
            if (this._PregnancyResult != null && this._PregnancyResult.BirthType != event) {
                this._PregnancyResult.BirthType = event;
            }
        }
    }

    public onBirthWeightChanged(event): void {
        if (event != null) {
            if (this._PregnancyResult != null && this._PregnancyResult.BirthWeight != event) {
                this._PregnancyResult.BirthWeight = event;
            }
        }
    }

    public onCesareanReasonChanged(event): void {
        if (event != null) {
            if (this._PregnancyResult != null && this._PregnancyResult.CesareanReason != event) {
                this._PregnancyResult.CesareanReason = event;
            }
        }
    }

    public onCongenitalAnomaliesChanged(event): void {
        if (event != null) {
            if (this._PregnancyResult != null && this._PregnancyResult.CongenitalAnomalies != event) {
                this._PregnancyResult.CongenitalAnomalies = event;
            }
        }
    }

    public onGenderChanged(event): void {
        if (event != null) {
            if (this._PregnancyResult != null && this._PregnancyResult.Gender != event) {
                this._PregnancyResult.Gender = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.BirthTerminationDatePregnancy, "Value", this.__ttObject, "Pregnancy.BirthTerminationDate");
        redirectProperty(this.BirthWeight, "Text", this.__ttObject, "BirthWeight");
        redirectProperty(this.Gender, "Value", this.__ttObject, "Gender");
        redirectProperty(this.BabyStatus, "Value", this.__ttObject, "BabyStatus");
        redirectProperty(this.BirthDescription, "Text", this.__ttObject, "BirthDescription");
        redirectProperty(this.CesareanReason, "Text", this.__ttObject, "CesareanReason");
        redirectProperty(this.AfterBirthStory, "Text", this.__ttObject, "AfterBirthStory");
    }

    public initFormControls(): void {
        this.labelBirthType = new TTVisual.TTLabel();
        this.labelBirthType.Text = i18n("M13146", "Doğum Yöntemi");
        this.labelBirthType.Name = "labelBirthType";
        this.labelBirthType.TabIndex = 21;

        this.BirthType = new TTVisual.TTObjectListBox();
        this.BirthType.ListDefName = "SKRSDogumYontemiList";
        this.BirthType.Name = "BirthType";
        this.BirthType.TabIndex = 20;

        this.labelBabyStatus = new TTVisual.TTLabel();
        this.labelBabyStatus.Text = "Bebeğin Durumu";
        this.labelBabyStatus.Name = "labelBabyStatus";
        this.labelBabyStatus.TabIndex = 19;

        this.BabyStatus = new TTVisual.TTEnumComboBox();
        this.BabyStatus.DataTypeName = "BirthReportBabyStatus";
        this.BabyStatus.Name = "BabyStatus";
        this.BabyStatus.TabIndex = 18;

        this.labelCongenitalAnomalies = new TTVisual.TTLabel();
        this.labelCongenitalAnomalies.Text = i18n("M17735", "Konjenital Anomalili Doğum Varlığı");
        this.labelCongenitalAnomalies.Name = "labelCongenitalAnomalies";
        this.labelCongenitalAnomalies.TabIndex = 17;

        this.CongenitalAnomalies = new TTVisual.TTObjectListBox();
        this.CongenitalAnomalies.ListDefName = "SKRSKonjenitalAnomaliliDogumVarligiList";
        this.CongenitalAnomalies.Name = "CongenitalAnomalies";
        this.CongenitalAnomalies.TabIndex = 5;

        this.labelBirthResult = new TTVisual.TTLabel();
        this.labelBirthResult.Text = i18n("M13128", "Doğum Sonucu");
        this.labelBirthResult.Name = "labelBirthResult";
        this.labelBirthResult.TabIndex = 15;

        this.BirthResult = new TTVisual.TTObjectListBox();
        this.BirthResult.ListDefName = "SKRSGebelikSonucuList";
        this.BirthResult.Name = "BirthResult";
        this.BirthResult.TabIndex = 4;

        this.labelBirthTerminationDatePregnancy = new TTVisual.TTLabel();
        this.labelBirthTerminationDatePregnancy.Text = i18n("M13125", "Doğum Sonlanma Tarihi");
        this.labelBirthTerminationDatePregnancy.Name = "labelBirthTerminationDatePregnancy";
        this.labelBirthTerminationDatePregnancy.TabIndex = 13;

        this.BirthTerminationDatePregnancy = new TTVisual.TTDateTimePicker();
        this.BirthTerminationDatePregnancy.CustomFormat = "dd.MM.yyyy";
        this.BirthTerminationDatePregnancy.Format = DateTimePickerFormat.Custom;
        this.BirthTerminationDatePregnancy.Name = "BirthTerminationDatePregnancy";
        this.BirthTerminationDatePregnancy.TabIndex = 0;

        this.labelGender = new TTVisual.TTLabel();
        this.labelGender.Text = i18n("M12265", "Cinsiyet");
        this.labelGender.Name = "labelGender";
        this.labelGender.TabIndex = 11;

        this.Gender = new TTVisual.TTEnumComboBox();
        this.Gender.DataTypeName = "SexEnum";
        this.Gender.Name = "Gender";
        this.Gender.TabIndex = 2;

        this.labelCesareanReason = new TTVisual.TTLabel();
        this.labelCesareanReason.Text = i18n("M21775", "Sezaryen Nedeni");
        this.labelCesareanReason.Name = "labelCesareanReason";
        this.labelCesareanReason.TabIndex = 9;

        this.CesareanReason = new TTVisual.TTTextBox();
        this.CesareanReason.Name = "CesareanReason";
        this.CesareanReason.TabIndex = 7;

        this.BirthWeight = new TTVisual.TTTextBox();
        this.BirthWeight.Name = "BirthWeight";
        this.BirthWeight.TabIndex = 1;

        this.BirthDescription = new TTVisual.TTTextBox();
        this.BirthDescription.Name = "BirthDescription";
        this.BirthDescription.TabIndex = 6;

        this.AfterBirthStory = new TTVisual.TTTextBox();
        this.AfterBirthStory.Name = "AfterBirthStory";
        this.AfterBirthStory.TabIndex = 8;

        this.labelBirthWeight = new TTVisual.TTLabel();
        this.labelBirthWeight.Text = i18n("M13100", "Doğum Ağırlığı(gr)");
        this.labelBirthWeight.Name = "labelBirthWeight";
        this.labelBirthWeight.TabIndex = 7;

        this.labelBirthDescription = new TTVisual.TTLabel();
        this.labelBirthDescription.Text = i18n("M13098", "Doğum Açıklaması");
        this.labelBirthDescription.Name = "labelBirthDescription";
        this.labelBirthDescription.TabIndex = 3;

        this.labelAfterBirthStory = new TTVisual.TTLabel();
        this.labelAfterBirthStory.Text = i18n("M13127", "Doğum Sonrası Öyküsü");
        this.labelAfterBirthStory.Name = "labelAfterBirthStory";
        this.labelAfterBirthStory.TabIndex = 1;

        this.Controls = [this.labelBirthType, this.BirthType, this.labelBabyStatus, this.BabyStatus, this.labelCongenitalAnomalies, this.CongenitalAnomalies, this.labelBirthResult, this.BirthResult, this.labelBirthTerminationDatePregnancy, this.BirthTerminationDatePregnancy, this.labelGender, this.Gender, this.labelCesareanReason, this.CesareanReason, this.BirthWeight, this.BirthDescription, this.AfterBirthStory, this.labelBirthWeight, this.labelBirthDescription, this.labelAfterBirthStory];

    }


}
