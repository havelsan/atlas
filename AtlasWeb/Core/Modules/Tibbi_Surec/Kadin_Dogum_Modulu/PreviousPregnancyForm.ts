//$80DF0917
import { Component, OnInit, NgZone } from '@angular/core';
import { PreviousPregnancyFormViewModel, PreviousPregnancyComponentInfoViewModel } from './PreviousPregnancyFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';


import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Pregnancy } from 'NebulaClient/Model/AtlasClientModel';

import { IndicationReason } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyComplications } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumaYardimEden } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumunGerceklestigiYer } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSezaryanEndikasyonlar } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


import { PregnancyResultComponentInfoViewModel } from './PregnancyResultFormViewModel';
import { PregnancyResultForm } from './PregnancyResultForm';

@Component({
    selector: 'PreviousPregnancyForm',
    templateUrl: './PreviousPregnancyForm.html',
    providers: [MessageService]
})
export class PreviousPregnancyForm extends TTVisual.TTForm implements OnInit {
    BirthHelper: TTVisual.ITTObjectListBox;
    BirthLocation: TTVisual.ITTObjectListBox;
    BirthTerminationDate: TTVisual.ITTDateTimePicker;
    BirthType: TTVisual.ITTObjectListBox;
    CesareanIndication: TTVisual.ITTObjectListBox;
    ComplicationPregnancyComplications: TTVisual.ITTListBoxColumn;
    ComplicationsDescriptionPregnancyComplications: TTVisual.ITTTextBoxColumn;
    IndicationReasons: TTVisual.ITTGrid;
    IndicationsIndicationReason: TTVisual.ITTListBoxColumn;
    labelBirthHelper: TTVisual.ITTLabel;
    labelBirthLocation: TTVisual.ITTLabel;
    labelBirthTerminationDate: TTVisual.ITTLabel;
    labelBirthType: TTVisual.ITTLabel;
    labelCesareanIndication: TTVisual.ITTLabel;
    labelPregnancyHistory: TTVisual.ITTLabel;
    labelPregnancyPhysiology: TTVisual.ITTLabel;
    labelPregnancyPhysiologyInfo: TTVisual.ITTLabel;
    PregnancyComplications: TTVisual.ITTGrid;
    PregnancyHistory: TTVisual.ITTTextBox;
    PregnancyPhysiology: TTVisual.ITTEnumComboBox;
    PregnancyPhysiologyInfo: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    public IndicationReasonsColumns = [];
    public PregnancyComplicationsColumns = [];
    public previousPregnancyFormViewModel: PreviousPregnancyFormViewModel = new PreviousPregnancyFormViewModel();
    public get _Pregnancy(): Pregnancy {
        return this._TTObject as Pregnancy;
    }
    private PreviousPregnancyForm_DocumentUrl: string = '/api/PregnancyService/PreviousPregnancyForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super('PREGNANCY', 'PreviousPregnancyForm');
        this._DocumentServiceUrl = this.PreviousPregnancyForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public static getComponentInfoViewModel(patientId: Guid): PreviousPregnancyComponentInfoViewModel {
        let componentInfoViewModel = new PreviousPregnancyComponentInfoViewModel();
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('25984dea-a4a6-4e5f-9f38-37c9420c84d1');
        queryParameters.QueryDefID = new Guid('2d502751-d75c-482b-85ca-ad4cd8abcb78');
        let parameters = {};
        parameters['PATIENT'] = new GuidParam(patientId);
        queryParameters.Parameters = parameters;
        componentInfoViewModel.previousPregnancyQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'PreviousPregnancyForm';
        componentInfo.ModuleName = 'KadinDogumModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Kadin_Dogum_Modulu/KadinDogumModule';
        componentInfoViewModel.previousPregnancyComponentInfo = componentInfo;
        return componentInfoViewModel;
    }

    public static previousPregnancyQueryResultLoaded(e: any) {

        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "BIRTHTERMINATIONDATE") {
                column.caption = i18n("M13125", "Doğum Sonlanma Tarihi");
            }
            if (column.dataField === "PREGNANCYHISTORY") {
                column.caption = i18n("M14567", "Gebelik Öyküsü");
            }
            if (column.dataField === "PREGNANCYPHYSIOLOGYTEXT") {
                column.caption = i18n("M14558", "Gebelik Fizyolojisi");
            }
            if (column.dataField === "PREGNANCYPHYSIOLOGYINFO") {
                column.caption = i18n("M14559", "Gebelik Fizyolojisi Açıklama");
            }
            if (column.dataField === "BIRTHTYPE") {
                column.caption = i18n("M13146", "Doğum Yöntemi");
            }
            if (column.dataField === "BIRTHHELPER") {
                column.caption = i18n("M13148", "Doğuma Yardım Eden");
            }
            if (column.dataField === "BIRTHLOCATION") {
                column.caption = i18n("M13149", "Doğumum Gerçekleştiği Yer");
            }
            if (column.dataField === "CESAREANINDICATION") {
                column.caption = i18n("M21772", "Sezaryan Endikasyonu");
            }

        }
    }


    //Geçmiş Gebeliğin Sonuç Bilgisi

    public pregnancyResultComponentInfo: DynamicComponentInfo;
    public pregnancyResultQueryParameters: QueryParams;

    protected async PreScript() {
        super.PreScript();
        let componentInfoViewModel: PregnancyResultComponentInfoViewModel;
        if (typeof this.previousPregnancyFormViewModel._Pregnancy == "string") {
            componentInfoViewModel = PregnancyResultForm.getComponentInfoViewModel(this.previousPregnancyFormViewModel._Pregnancy, true);
        } else {
            componentInfoViewModel = PregnancyResultForm.getComponentInfoViewModel(this.previousPregnancyFormViewModel._Pregnancy.ObjectID, true);
        }
        this.pregnancyResultQueryParameters = componentInfoViewModel.pregnancyResultQueryParameters;
        this.pregnancyResultComponentInfo = componentInfoViewModel.pregnancyResultComponentInfo;
    }

    pregnancyResultQueryResultLoaded(e: any) {
        PregnancyResultForm.pregnancyResultQueryResultLoaded(e);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Pregnancy();
        this.previousPregnancyFormViewModel = new PreviousPregnancyFormViewModel();
        this._ViewModel = this.previousPregnancyFormViewModel;
        this.previousPregnancyFormViewModel._Pregnancy = this._TTObject as Pregnancy;
        this.previousPregnancyFormViewModel._Pregnancy.IndicationReasons = new Array<IndicationReason>();
        this.previousPregnancyFormViewModel._Pregnancy.CesareanIndication = new SKRSSezaryanEndikasyonlar();
        this.previousPregnancyFormViewModel._Pregnancy.BirthType = new SKRSDogumYontemi();
        this.previousPregnancyFormViewModel._Pregnancy.BirthLocation = new SKRSDogumunGerceklestigiYer();
        this.previousPregnancyFormViewModel._Pregnancy.BirthHelper = new SKRSDogumaYardimEden();
        this.previousPregnancyFormViewModel._Pregnancy.PregnancyComplications = new Array<PregnancyComplications>();
    }

    protected loadViewModel() {
        let that = this;

        that.previousPregnancyFormViewModel = this._ViewModel as PreviousPregnancyFormViewModel;
        that._TTObject = this.previousPregnancyFormViewModel._Pregnancy;
        if (this.previousPregnancyFormViewModel == null)
            this.previousPregnancyFormViewModel = new PreviousPregnancyFormViewModel();
        if (this.previousPregnancyFormViewModel._Pregnancy == null)
            this.previousPregnancyFormViewModel._Pregnancy = new Pregnancy();
        that.previousPregnancyFormViewModel._Pregnancy.IndicationReasons = that.previousPregnancyFormViewModel.IndicationReasonsGridList;
        for (let detailItem of that.previousPregnancyFormViewModel.IndicationReasonsGridList) {
            let indicationsObjectID = detailItem["Indications"];
            if (indicationsObjectID != null && (typeof indicationsObjectID === "string")) {
                let indications = that.previousPregnancyFormViewModel.SKRSEndikasyonNedenleris.find(o => o.ObjectID.toString() === indicationsObjectID.toString());
                if (indications) {
                    detailItem.Indications = indications;
                }
            }
        }
        let cesareanIndicationObjectID = that.previousPregnancyFormViewModel._Pregnancy["CesareanIndication"];
        if (cesareanIndicationObjectID != null && (typeof cesareanIndicationObjectID === "string")) {
            let cesareanIndication = that.previousPregnancyFormViewModel.SKRSSezaryanEndikasyonlars.find(o => o.ObjectID.toString() === cesareanIndicationObjectID.toString());
            if (cesareanIndication) {
                that.previousPregnancyFormViewModel._Pregnancy.CesareanIndication = cesareanIndication;
            }
        }
        let birthTypeObjectID = that.previousPregnancyFormViewModel._Pregnancy["BirthType"];
        if (birthTypeObjectID != null && (typeof birthTypeObjectID === "string")) {
            let birthType = that.previousPregnancyFormViewModel.SKRSDogumYontemis.find(o => o.ObjectID.toString() === birthTypeObjectID.toString());
            if (birthType) {
                that.previousPregnancyFormViewModel._Pregnancy.BirthType = birthType;
            }
        }
        let birthLocationObjectID = that.previousPregnancyFormViewModel._Pregnancy["BirthLocation"];
        if (birthLocationObjectID != null && (typeof birthLocationObjectID === "string")) {
            let birthLocation = that.previousPregnancyFormViewModel.SKRSDogumunGerceklestigiYers.find(o => o.ObjectID.toString() === birthLocationObjectID.toString());
            if (birthLocation) {
                that.previousPregnancyFormViewModel._Pregnancy.BirthLocation = birthLocation;
            }
        }
        let birthHelperObjectID = that.previousPregnancyFormViewModel._Pregnancy["BirthHelper"];
        if (birthHelperObjectID != null && (typeof birthHelperObjectID === "string")) {
            let birthHelper = that.previousPregnancyFormViewModel.SKRSDogumaYardimEdens.find(o => o.ObjectID.toString() === birthHelperObjectID.toString());
            if (birthHelper) {
                that.previousPregnancyFormViewModel._Pregnancy.BirthHelper = birthHelper;
            }
        }
        that.previousPregnancyFormViewModel._Pregnancy.PregnancyComplications = that.previousPregnancyFormViewModel.PregnancyComplicationsGridList;
        for (let detailItem of that.previousPregnancyFormViewModel.PregnancyComplicationsGridList) {
            let complicationObjectID = detailItem["Complication"];
            if (complicationObjectID != null && (typeof complicationObjectID === "string")) {
                let complication = that.previousPregnancyFormViewModel.SKRSGebelikteRiskFaktorleris.find(o => o.ObjectID.toString() === complicationObjectID.toString());
                if (complication) {
                    detailItem.Complication = complication;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(PreviousPregnancyFormViewModel);

    }


    public onBirthHelperChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.BirthHelper != event) {
                this._Pregnancy.BirthHelper = event;
            }
        }
    }

    public onBirthLocationChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.BirthLocation != event) {
                this._Pregnancy.BirthLocation = event;
            }
        }
    }

    public onBirthTerminationDateChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.BirthTerminationDate != event) {
                this._Pregnancy.BirthTerminationDate = event;
            }
        }
    }

    public onBirthTypeChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.BirthType != event) {
                this._Pregnancy.BirthType = event;
            }
        }
    }

    public onCesareanIndicationChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.CesareanIndication != event) {
                this._Pregnancy.CesareanIndication = event;
            }
        }
    }

    public onPregnancyHistoryChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.PregnancyHistory != event) {
                this._Pregnancy.PregnancyHistory = event;
            }
        }
    }

    public onPregnancyPhysiologyChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.PregnancyPhysiology != event) {
                this._Pregnancy.PregnancyPhysiology = event;
            }
        }
    }

    public onPregnancyPhysiologyInfoChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.PregnancyPhysiologyInfo != event) {
                this._Pregnancy.PregnancyPhysiologyInfo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.PregnancyPhysiology, "Value", this.__ttObject, "PregnancyPhysiology");
        redirectProperty(this.PregnancyPhysiologyInfo, "Text", this.__ttObject, "PregnancyPhysiologyInfo");
        redirectProperty(this.BirthTerminationDate, "Value", this.__ttObject, "BirthTerminationDate");
        redirectProperty(this.PregnancyHistory, "Text", this.__ttObject, "PregnancyHistory");
    }

    public initFormControls(): void {
        this.IndicationReasons = new TTVisual.TTGrid();
        this.IndicationReasons.Name = "IndicationReasons";
        this.IndicationReasons.TabIndex = 20;

        this.IndicationsIndicationReason = new TTVisual.TTListBoxColumn();
        this.IndicationsIndicationReason.ListDefName = "SKRSEndikasyonNedenleriList";
        this.IndicationsIndicationReason.DataMember = "Indications";
        this.IndicationsIndicationReason.DisplayIndex = 0;
        this.IndicationsIndicationReason.HeaderText = i18n("M13717", "Endikasyon Nedenleri");
        this.IndicationsIndicationReason.Name = "IndicationsIndicationReason";
        this.IndicationsIndicationReason.Width = 300;

        this.labelCesareanIndication = new TTVisual.TTLabel();
        this.labelCesareanIndication.Text = i18n("M21772", "Sezaryan Endikasyonu");
        this.labelCesareanIndication.Name = "labelCesareanIndication";
        this.labelCesareanIndication.TabIndex = 19;

        this.CesareanIndication = new TTVisual.TTObjectListBox();
        this.CesareanIndication.ListDefName = "SKRSSezaryanEndikasyonlarList";
        this.CesareanIndication.Name = "CesareanIndication";
        this.CesareanIndication.TabIndex = 18;

        this.labelBirthType = new TTVisual.TTLabel();
        this.labelBirthType.Text = i18n("M13146", "Doğum Yöntemi");
        this.labelBirthType.Name = "labelBirthType";
        this.labelBirthType.TabIndex = 17;

        this.BirthType = new TTVisual.TTObjectListBox();
        this.BirthType.ListDefName = "SKRSDogumYontemiList";
        this.BirthType.Name = "BirthType";
        this.BirthType.TabIndex = 16;

        this.labelBirthLocation = new TTVisual.TTLabel();
        this.labelBirthLocation.Text = i18n("M13150", "Doğumun Gerçekleştiği Yer");
        this.labelBirthLocation.Name = "labelBirthLocation";
        this.labelBirthLocation.TabIndex = 15;

        this.BirthLocation = new TTVisual.TTObjectListBox();
        this.BirthLocation.ListDefName = "SKRSDogumunGerceklestigiYerList";
        this.BirthLocation.Name = "BirthLocation";
        this.BirthLocation.TabIndex = 14;

        this.labelBirthHelper = new TTVisual.TTLabel();
        this.labelBirthHelper.Text = i18n("M13148", "Doğuma Yardım Eden");
        this.labelBirthHelper.Name = "labelBirthHelper";
        this.labelBirthHelper.TabIndex = 13;

        this.BirthHelper = new TTVisual.TTObjectListBox();
        this.BirthHelper.ListDefName = "SKRSDogumaYardimEdenList";
        this.BirthHelper.Name = "BirthHelper";
        this.BirthHelper.TabIndex = 12;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M14569", "Gebelik Risk Faktörleri");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 11;

        this.PregnancyComplications = new TTVisual.TTGrid();
        this.PregnancyComplications.Name = "PregnancyComplications";
        this.PregnancyComplications.TabIndex = 4;

        this.ComplicationPregnancyComplications = new TTVisual.TTListBoxColumn();
        this.ComplicationPregnancyComplications.ListDefName = "SKRSGebelikteRiskFaktorleriList";
        this.ComplicationPregnancyComplications.DataMember = "Complication";
        this.ComplicationPregnancyComplications.DisplayIndex = 0;
        this.ComplicationPregnancyComplications.HeaderText = i18n("M21046", "Risk Faktörü");
        this.ComplicationPregnancyComplications.Name = "ComplicationPregnancyComplications";
        this.ComplicationPregnancyComplications.Width = 300;

        this.ComplicationsDescriptionPregnancyComplications = new TTVisual.TTTextBoxColumn();
        this.ComplicationsDescriptionPregnancyComplications.DataMember = "ComplicationsDescription";
        this.ComplicationsDescriptionPregnancyComplications.DisplayIndex = 1;
        this.ComplicationsDescriptionPregnancyComplications.HeaderText = i18n("M17722", "Komplikasyon Açıklaması");
        this.ComplicationsDescriptionPregnancyComplications.Name = "ComplicationsDescriptionPregnancyComplications";
        this.ComplicationsDescriptionPregnancyComplications.Width = 80;

        this.labelPregnancyPhysiologyInfo = new TTVisual.TTLabel();
        this.labelPregnancyPhysiologyInfo.Text = i18n("M14560", "Gebelik Fizyolojisi Açıklaması");
        this.labelPregnancyPhysiologyInfo.Name = "labelPregnancyPhysiologyInfo";
        this.labelPregnancyPhysiologyInfo.TabIndex = 7;

        this.PregnancyPhysiologyInfo = new TTVisual.TTTextBox();
        this.PregnancyPhysiologyInfo.Name = "PregnancyPhysiologyInfo";
        this.PregnancyPhysiologyInfo.TabIndex = 1;

        this.PregnancyHistory = new TTVisual.TTTextBox();
        this.PregnancyHistory.Name = "PregnancyHistory";
        this.PregnancyHistory.TabIndex = 3;

        this.labelPregnancyPhysiology = new TTVisual.TTLabel();
        this.labelPregnancyPhysiology.Text = i18n("M14558", "Gebelik Fizyolojisi");
        this.labelPregnancyPhysiology.Name = "labelPregnancyPhysiology";
        this.labelPregnancyPhysiology.TabIndex = 5;

        this.PregnancyPhysiology = new TTVisual.TTEnumComboBox();
        this.PregnancyPhysiology.DataTypeName = "PregnancyPhysiologyEnum";
        this.PregnancyPhysiology.Name = "PregnancyPhysiology";
        this.PregnancyPhysiology.TabIndex = 0;

        this.labelPregnancyHistory = new TTVisual.TTLabel();
        this.labelPregnancyHistory.Text = i18n("M14567", "Gebelik Öyküsü");
        this.labelPregnancyHistory.Name = "labelPregnancyHistory";
        this.labelPregnancyHistory.TabIndex = 3;

        this.labelBirthTerminationDate = new TTVisual.TTLabel();
        this.labelBirthTerminationDate.Text = i18n("M13125", "Doğum Sonlanma Tarihi");
        this.labelBirthTerminationDate.Name = "labelBirthTerminationDate";
        this.labelBirthTerminationDate.TabIndex = 1;

        this.BirthTerminationDate = new TTVisual.TTDateTimePicker();
        this.BirthTerminationDate.CustomFormat = "dd.MM.yyyy";
        this.BirthTerminationDate.Format = DateTimePickerFormat.Custom;
        this.BirthTerminationDate.Name = "BirthTerminationDate";
        this.BirthTerminationDate.TabIndex = 5;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M13717", "Endikasyon Nedenleri");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 19;

        this.IndicationReasonsColumns = [this.IndicationsIndicationReason];
        this.PregnancyComplicationsColumns = [this.ComplicationPregnancyComplications, this.ComplicationsDescriptionPregnancyComplications];
        this.Controls = [this.IndicationReasons, this.IndicationsIndicationReason, this.labelCesareanIndication, this.CesareanIndication, this.labelBirthType, this.BirthType, this.labelBirthLocation, this.BirthLocation, this.labelBirthHelper, this.BirthHelper, this.ttlabel1, this.PregnancyComplications, this.ComplicationPregnancyComplications, this.ComplicationsDescriptionPregnancyComplications, this.labelPregnancyPhysiologyInfo, this.PregnancyPhysiologyInfo, this.PregnancyHistory, this.labelPregnancyPhysiology, this.PregnancyPhysiology, this.labelPregnancyHistory, this.labelBirthTerminationDate, this.BirthTerminationDate, this.ttlabel2];

    }


}
