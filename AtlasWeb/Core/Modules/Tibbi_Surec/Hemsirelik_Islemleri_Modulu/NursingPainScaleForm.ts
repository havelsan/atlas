//$BBAC80A5
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingPainScaleFormViewModel } from './NursingPainScaleFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingPainScale } from 'NebulaClient/Model/AtlasClientModel';
import { PainChangingSituationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PainFrequencyDefiniton } from 'NebulaClient/Model/AtlasClientModel';
import { PainPlaceDefition } from 'NebulaClient/Model/AtlasClientModel';
import { PainQualityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PainScaleDecreaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { PainScaleIncreaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';

@Component({
    selector: 'NursingPainScaleForm',
    templateUrl: './NursingPainScaleForm.html',
    providers: [MessageService]
})
export class NursingPainScaleForm extends BaseNursingDataEntryForm implements OnInit {
    AchingSide: TTVisual.ITTTextBox;
    ApplicationDate: TTVisual.ITTDateTimePicker;
    DurationofPain: TTVisual.ITTTextBox;
    labelAchingSide: TTVisual.ITTLabel;
    labelApplicationDate: TTVisual.ITTLabel;
    labelDurationofPain: TTVisual.ITTLabel;
    labelPainDetail: TTVisual.ITTLabel;
    labelPainFaceScale: TTVisual.ITTLabel;
    labelPainFrequency: TTVisual.ITTLabel;
    labelPainPlaces: TTVisual.ITTLabel;
    labelPainQuality: TTVisual.ITTLabel;
    labelPainQualityDescription: TTVisual.ITTLabel;
    labelPainTime: TTVisual.ITTLabel;
    labelPostNursingInitiative: TTVisual.ITTLabel;
    NursingPainScalePainScaleDecreaseGrid: TTVisual.ITTListBoxColumn;
    NursingPainScalePainScaleIncreaseGrid: TTVisual.ITTListBoxColumn;
    PainChangingSituationPainScaleDecreaseGrid: TTVisual.ITTListBoxColumn;
    PainChangingSituationPainScaleIncreaseGrid: TTVisual.ITTListBoxColumn;
    PainDetail: TTVisual.ITTTextBox;
    PainFaceScale: TTVisual.ITTEnumComboBox;
    PainFrequency: TTVisual.ITTObjectListBox;
    PainPlaces: TTVisual.ITTObjectListBox;
    PainQuality: TTVisual.ITTObjectListBox;
    PainQualityDescription: TTVisual.ITTTextBox;
    PainScaleDecreaseGrid: TTVisual.ITTGrid;
    PainScaleIncreaseGrids: TTVisual.ITTGrid;
    PainTime: TTVisual.ITTTextBox;
    PostNursingInitiative: TTVisual.ITTEnumComboBox;
    public PainScaleDecreaseGridColumns = [];
    public PainScaleIncreaseGridsColumns = [];
    public nursingPainScaleFormViewModel: NursingPainScaleFormViewModel = new NursingPainScaleFormViewModel();
    public get _NursingPainScale(): NursingPainScale {
        return this._TTObject as NursingPainScale;
    }
    private NursingPainScaleForm_DocumentUrl: string = '/api/NursingPainScaleService/NursingPainScaleForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone,
        protected reportService: AtlasReportService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingPainScaleForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingPainScale();
        this.nursingPainScaleFormViewModel = new NursingPainScaleFormViewModel();
        this._ViewModel = this.nursingPainScaleFormViewModel;
        this.nursingPainScaleFormViewModel._NursingPainScale = this._TTObject as NursingPainScale;
        this.nursingPainScaleFormViewModel._NursingPainScale.PainScaleIncreaseGrids = new Array<PainScaleIncreaseGrid>();
        this.nursingPainScaleFormViewModel._NursingPainScale.PainScaleDecreaseGrid = new Array<PainScaleDecreaseGrid>();
        this.nursingPainScaleFormViewModel._NursingPainScale.PainQuality = new PainQualityDefinition();
        this.nursingPainScaleFormViewModel._NursingPainScale.PainFrequency = new PainFrequencyDefiniton();
        this.nursingPainScaleFormViewModel._NursingPainScale.PainPlaces = new PainPlaceDefition();
    }

    protected loadViewModel() {
        let that = this;
        that.nursingPainScaleFormViewModel = this._ViewModel as NursingPainScaleFormViewModel;
        that._TTObject = this.nursingPainScaleFormViewModel._NursingPainScale;
        if (this.nursingPainScaleFormViewModel == null)
            this.nursingPainScaleFormViewModel = new NursingPainScaleFormViewModel();
        if (this.nursingPainScaleFormViewModel._NursingPainScale == null)
            this.nursingPainScaleFormViewModel._NursingPainScale = new NursingPainScale();
        //that.nursingPainScaleFormViewModel._NursingPainScale.PainScaleIncreaseGrids = that.nursingPainScaleFormViewModel.SelectedChangingSituationIncreaseList;
        //for (let detailItem of that.nursingPainScaleFormViewModel.SelectedChangingSituationIncreaseList) {
        //    let nursingPainScaleObjectID = detailItem["NursingPainScale"];
        //    if (nursingPainScaleObjectID != null && (typeof nursingPainScaleObjectID === "string")) {
        //        let nursingPainScale = that.nursingPainScaleFormViewModel.NursingPainScales.find(o => o.ObjectID.toString() === nursingPainScaleObjectID.toString());
        //        detailItem.NursingPainScale = nursingPainScale;
        //    }
        //    let painChangingSituationObjectID = detailItem["PainChangingSituation"];
        //    if (painChangingSituationObjectID != null && (typeof painChangingSituationObjectID === "string")) {
        //        let painChangingSituation = that.nursingPainScaleFormViewModel.PainChangingSituationDefinitions.find(o => o.ObjectID.toString() === painChangingSituationObjectID.toString());
        //        detailItem.PainChangingSituation = painChangingSituation;
        //    }
        //}
        //that.nursingPainScaleFormViewModel._NursingPainScale.PainScaleDecreaseGrid = that.nursingPainScaleFormViewModel.SelectedChangingSituationDecreaseList;
        //for (let detailItem of that.nursingPainScaleFormViewModel.SelectedChangingSituationDecreaseList) {
        //    let nursingPainScaleObjectID = detailItem["NursingPainScale"];
        //    if (nursingPainScaleObjectID != null && (typeof nursingPainScaleObjectID === "string")) {
        //        let nursingPainScale = that.nursingPainScaleFormViewModel.NursingPainScales.find(o => o.ObjectID.toString() === nursingPainScaleObjectID.toString());
        //        detailItem.NursingPainScale = nursingPainScale;
        //    }
        //    let painChangingSituationObjectID = detailItem["PainChangingSituation"];
        //    if (painChangingSituationObjectID != null && (typeof painChangingSituationObjectID === "string")) {
        //        let painChangingSituation = that.nursingPainScaleFormViewModel.PainChangingSituationDefinitions.find(o => o.ObjectID.toString() === painChangingSituationObjectID.toString());
        //        detailItem.PainChangingSituation = painChangingSituation;
        //    }
        //}
        let painQualityObjectID = that.nursingPainScaleFormViewModel._NursingPainScale["PainQuality"];
        if (painQualityObjectID != null && (typeof painQualityObjectID === "string")) {
            let painQuality = that.nursingPainScaleFormViewModel.PainQualityDefinitions.find(o => o.ObjectID.toString() === painQualityObjectID.toString());
             if (painQuality) {
                that.nursingPainScaleFormViewModel._NursingPainScale.PainQuality = painQuality;
            }
        }
        let painFrequencyObjectID = that.nursingPainScaleFormViewModel._NursingPainScale["PainFrequency"];
        if (painFrequencyObjectID != null && (typeof painFrequencyObjectID === "string")) {
            let painFrequency = that.nursingPainScaleFormViewModel.PainFrequencyDefinitons.find(o => o.ObjectID.toString() === painFrequencyObjectID.toString());
             if (painFrequency) {
                that.nursingPainScaleFormViewModel._NursingPainScale.PainFrequency = painFrequency;
            }
        }
        let painPlacesObjectID = that.nursingPainScaleFormViewModel._NursingPainScale["PainPlaces"];
        if (painPlacesObjectID != null && (typeof painPlacesObjectID === "string")) {
            let painPlaces = that.nursingPainScaleFormViewModel.PainPlaceDefitions.find(o => o.ObjectID.toString() === painPlacesObjectID.toString());
             if (painPlaces) {
                that.nursingPainScaleFormViewModel._NursingPainScale.PainPlaces = painPlaces;
            }
        }

        this.fillPainChangingDefinitions();

    }
    PainChangingSituationIncresingDefinitions: Array<PainChangingSituationDefinition> = new Array<PainChangingSituationDefinition>();
    PainChangingSituationDecreasingDefinitions: Array<PainChangingSituationDefinition> = new Array<PainChangingSituationDefinition>();
    public fillPainChangingDefinitions() {
        for (let data of this.nursingPainScaleFormViewModel.PainChangingSituationDefinitions) {
            if (data.Increasing == true)
                this.PainChangingSituationIncresingDefinitions.push(data);
            if (data.Decreasing == true)
                this.PainChangingSituationDecreasingDefinitions.push(data);
        }
    }

    async ngOnInit() {
        let that = this;
        await this.load(NursingPainScaleFormViewModel);
  
    }


    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.nursingPainScaleFormViewModel.ReadOnly = (this.nursingPainScaleFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.nursingPainScaleFormViewModel.ReadOnly)
            this.DropStateButton(NursingPainScale.NursingPainScaleStates.Cancelled);

        this.ArrangeFormControl();
        super.ClientSidePreScript();
    }

    ArrangeFormControl() {
        this.PainQuality.ReadOnly = this.nursingPainScaleFormViewModel.ReadOnly;
        this.PainQuality.Enabled = !this.nursingPainScaleFormViewModel.ReadOnly;

        this.PainPlaces.ReadOnly = this.nursingPainScaleFormViewModel.ReadOnly;
        this.PainPlaces.Enabled = !this.nursingPainScaleFormViewModel.ReadOnly;

        this.AchingSide.ReadOnly = this.nursingPainScaleFormViewModel.ReadOnly;
        this.AchingSide.Enabled = !this.nursingPainScaleFormViewModel.ReadOnly;

        this.PainDetail.ReadOnly = this.nursingPainScaleFormViewModel.ReadOnly;
        this.PainDetail.Enabled = !this.nursingPainScaleFormViewModel.ReadOnly;

        this.PainFrequency.ReadOnly = this.nursingPainScaleFormViewModel.ReadOnly;
        this.PainFrequency.Enabled = !this.nursingPainScaleFormViewModel.ReadOnly;

        this.PainTime.ReadOnly = this.nursingPainScaleFormViewModel.ReadOnly;
        this.PainTime.Enabled = !this.nursingPainScaleFormViewModel.ReadOnly;

        this.DurationofPain.ReadOnly = this.nursingPainScaleFormViewModel.ReadOnly;
        this.DurationofPain.Enabled = !this.nursingPainScaleFormViewModel.ReadOnly;

        this.PainFaceScale.ReadOnly = this.nursingPainScaleFormViewModel.ReadOnly;
        this.PainFaceScale.Enabled = !this.nursingPainScaleFormViewModel.ReadOnly;

        this.PainQualityDescription.ReadOnly = this.nursingPainScaleFormViewModel.ReadOnly;
        this.PainQualityDescription.Enabled = !this.nursingPainScaleFormViewModel.ReadOnly;
    }
    printReport() {
        let a: any = this.nursingPainScaleFormViewModel._NursingPainScale["NursingApplication"];
        if (a != null) {
            const TTOBJECTID = new GuidParam(a);
            let reportParameters: any = { 'TTOBJECTID': TTOBJECTID };
            this.reportService.showReport('NursingPainScaleReport', reportParameters);
        }
    }

    PainScaleIncreaseGridsChanged(event) {
        if (event != null) {
            if (this._NursingPainScale != null && this.nursingPainScaleFormViewModel._NursingPainScale.PainScaleIncreaseGrids != event) {
                this._NursingPainScale.PainScaleIncreaseGrids = event;
            }
        }
    }

    PainScaleDecreaseGridChanged(event) {
        if (event != null) {
            if (this._NursingPainScale != null && this.nursingPainScaleFormViewModel._NursingPainScale.PainScaleDecreaseGrid != event) {
                this._NursingPainScale.PainScaleDecreaseGrid = event;
            }
        }
    }

    public onAchingSideChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.AchingSide != event) {
                this._NursingPainScale.AchingSide = event;
            }
        }
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.ApplicationDate != event) {
                this._NursingPainScale.ApplicationDate = event;
            }
        }
    }

    public onDurationofPainChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.DurationofPain != event) {
                this._NursingPainScale.DurationofPain = event;
            }
        }
    }

    public onPainDetailChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.PainDetail != event) {
                this._NursingPainScale.PainDetail = event;
            }
        }
    }

    public onPainFaceScaleChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.PainFaceScale != event) {
                this._NursingPainScale.PainFaceScale = event;
            }
        }
    }

    public onPainFrequencyChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.PainFrequency != event) {
                this._NursingPainScale.PainFrequency = event;
            }
        }
    }

    public onPainPlacesChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.PainPlaces != event) {
                this._NursingPainScale.PainPlaces = event;
            }
        }
    }

    public onPainQualityChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.PainQuality != event) {
                this._NursingPainScale.PainQuality = event;
            }
        }
    }

    public onPainQualityDescriptionChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.PainQualityDescription != event) {
                this._NursingPainScale.PainQualityDescription = event;
            }
        }
    }

    public onPainTimeChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.PainTime != event) {
                this._NursingPainScale.PainTime = event;
            }
        }
    }

    public onPostNursingInitiativeChanged(event): void {
        if (event != null) {
            if (this._NursingPainScale != null && this._NursingPainScale.PostNursingInitiative != event) {
                this._NursingPainScale.PostNursingInitiative = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.PainDetail, "Text", this.__ttObject, "PainDetail");
        redirectProperty(this.PainTime, "Text", this.__ttObject, "PainTime");
        redirectProperty(this.DurationofPain, "Text", this.__ttObject, "DurationofPain");
        redirectProperty(this.AchingSide, "Text", this.__ttObject, "AchingSide");
        redirectProperty(this.PostNursingInitiative, "Value", this.__ttObject, "PostNursingInitiative");
        redirectProperty(this.PainQualityDescription, "Text", this.__ttObject, "PainQualityDescription");
        redirectProperty(this.PainFaceScale, "Value", this.__ttObject, "PainFaceScale");
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
    }

    public initFormControls(): void {
        this.labelPostNursingInitiative = new TTVisual.TTLabel();
        this.labelPostNursingInitiative.Text = "Hemşirelik Girişimi Sonrası";
        this.labelPostNursingInitiative.Name = "labelPostNursingInitiative";
        this.labelPostNursingInitiative.TabIndex = 23;

        this.PostNursingInitiative = new TTVisual.TTEnumComboBox();
        this.PostNursingInitiative.DataTypeName = "PostNursingInitiativesEnum";
        this.PostNursingInitiative.Name = "PostNursingInitiative";
        this.PostNursingInitiative.TabIndex = 22;

        this.PainScaleIncreaseGrids = new TTVisual.TTGrid();
        this.PainScaleIncreaseGrids.Name = "PainScaleIncreaseGrids";
        this.PainScaleIncreaseGrids.TabIndex = 23;

        this.NursingPainScalePainScaleIncreaseGrid = new TTVisual.TTListBoxColumn();
        this.NursingPainScalePainScaleIncreaseGrid.DataMember = "NursingPainScale";
        this.NursingPainScalePainScaleIncreaseGrid.DisplayIndex = 0;
        this.NursingPainScalePainScaleIncreaseGrid.HeaderText = "";
        this.NursingPainScalePainScaleIncreaseGrid.Name = "NursingPainScalePainScaleIncreaseGrid";
        this.NursingPainScalePainScaleIncreaseGrid.Width = 300;

        this.PainChangingSituationPainScaleIncreaseGrid = new TTVisual.TTListBoxColumn();
        this.PainChangingSituationPainScaleIncreaseGrid.DataMember = "PainChangingSituation";
        this.PainChangingSituationPainScaleIncreaseGrid.DisplayIndex = 1;
        this.PainChangingSituationPainScaleIncreaseGrid.HeaderText = "";
        this.PainChangingSituationPainScaleIncreaseGrid.Name = "PainChangingSituationPainScaleIncreaseGrid";
        this.PainChangingSituationPainScaleIncreaseGrid.Width = 300;

        this.PainScaleDecreaseGrid = new TTVisual.TTGrid();
        this.PainScaleDecreaseGrid.Name = "PainScaleDecreaseGrid";
        this.PainScaleDecreaseGrid.TabIndex = 22;

        this.NursingPainScalePainScaleDecreaseGrid = new TTVisual.TTListBoxColumn();
        this.NursingPainScalePainScaleDecreaseGrid.DataMember = "NursingPainScale";
        this.NursingPainScalePainScaleDecreaseGrid.DisplayIndex = 0;
        this.NursingPainScalePainScaleDecreaseGrid.HeaderText = "";
        this.NursingPainScalePainScaleDecreaseGrid.Name = "NursingPainScalePainScaleDecreaseGrid";
        this.NursingPainScalePainScaleDecreaseGrid.Width = 300;

        this.PainChangingSituationPainScaleDecreaseGrid = new TTVisual.TTListBoxColumn();
        this.PainChangingSituationPainScaleDecreaseGrid.DataMember = "PainChangingSituation";
        this.PainChangingSituationPainScaleDecreaseGrid.DisplayIndex = 1;
        this.PainChangingSituationPainScaleDecreaseGrid.HeaderText = "";
        this.PainChangingSituationPainScaleDecreaseGrid.Name = "PainChangingSituationPainScaleDecreaseGrid";
        this.PainChangingSituationPainScaleDecreaseGrid.Width = 300;

        this.labelPainQuality = new TTVisual.TTLabel();
        this.labelPainQuality.Text = i18n("M10592", "Ağrının Niteliği");
        this.labelPainQuality.Name = "labelPainQuality";
        this.labelPainQuality.TabIndex = 21;

        this.PainQuality = new TTVisual.TTObjectListBox();
        this.PainQuality.ListDefName = "PainQualityListDefinition";
        this.PainQuality.Name = "PainQuality";
        this.PainQuality.TabIndex = 20;

        this.labelPainFrequency = new TTVisual.TTLabel();
        this.labelPainFrequency.Text = i18n("M10593", "Ağrının Sıklığı");
        this.labelPainFrequency.Name = "labelPainFrequency";
        this.labelPainFrequency.TabIndex = 19;

        this.PainFrequency = new TTVisual.TTObjectListBox();
        this.PainFrequency.ListDefName = "PainFrequencyListDefiniton";
        this.PainFrequency.Name = "PainFrequency";
        this.PainFrequency.TabIndex = 18;

        this.labelPainPlaces = new TTVisual.TTLabel();
        this.labelPainPlaces.Text = i18n("M10594", "Ağrının Yeri");
        this.labelPainPlaces.Name = "labelPainPlaces";
        this.labelPainPlaces.TabIndex = 17;

        this.PainPlaces = new TTVisual.TTObjectListBox();
        this.PainPlaces.ListDefName = "PainPlaceListDefinition";
        this.PainPlaces.Name = "PainPlaces";
        this.PainPlaces.TabIndex = 16;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 15;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 14;

        this.labelPainFaceScale = new TTVisual.TTLabel();
        this.labelPainFaceScale.Text = i18n("M10587", "Ağrı Yüz Skalası");
        this.labelPainFaceScale.Name = "labelPainFaceScale";
        this.labelPainFaceScale.TabIndex = 13;

        this.PainFaceScale = new TTVisual.TTEnumComboBox();
        this.PainFaceScale.DataTypeName = "PainFaceScaleEnum";
        this.PainFaceScale.Name = "PainFaceScale";
        this.PainFaceScale.TabIndex = 12;

        this.labelPainQualityDescription = new TTVisual.TTLabel();
        this.labelPainQualityDescription.Text = i18n("M10582", "Ağrı Niteliği Açıklama");
        this.labelPainQualityDescription.Name = "labelPainQualityDescription";
        this.labelPainQualityDescription.TabIndex = 9;

        this.PainQualityDescription = new TTVisual.TTTextBox();
        this.PainQualityDescription.Name = "PainQualityDescription";
        this.PainQualityDescription.TabIndex = 8;

        this.AchingSide = new TTVisual.TTTextBox();
        this.AchingSide.Name = "AchingSide";
        this.AchingSide.TabIndex = 6;

        this.DurationofPain = new TTVisual.TTTextBox();
        this.DurationofPain.Name = "DurationofPain";
        this.DurationofPain.TabIndex = 4;

        this.PainTime = new TTVisual.TTTextBox();
        this.PainTime.Name = "PainTime";
        this.PainTime.TabIndex = 2;

        this.PainDetail = new TTVisual.TTTextBox();
        this.PainDetail.Name = "PainDetail";
        this.PainDetail.TabIndex = 0;

        this.labelAchingSide = new TTVisual.TTLabel();
        this.labelAchingSide.Text = i18n("M10596", "Ağrıyan Taraf");
        this.labelAchingSide.Name = "labelAchingSide";
        this.labelAchingSide.TabIndex = 7;

        this.labelDurationofPain = new TTVisual.TTLabel();
        this.labelDurationofPain.Text = i18n("M10584", "Ağrı Süresi");
        this.labelDurationofPain.Name = "labelDurationofPain";
        this.labelDurationofPain.TabIndex = 5;

        this.labelPainTime = new TTVisual.TTLabel();
        this.labelPainTime.Text = i18n("M19429", "Ne Zamandır Var");
        this.labelPainTime.Name = "labelPainTime";
        this.labelPainTime.TabIndex = 3;

        this.labelPainDetail = new TTVisual.TTLabel();
        this.labelPainDetail.Text = i18n("M10580", "Ağrı Detay");
        this.labelPainDetail.Name = "labelPainDetail";
        this.labelPainDetail.TabIndex = 1;

        this.PainScaleIncreaseGridsColumns = [this.NursingPainScalePainScaleIncreaseGrid, this.PainChangingSituationPainScaleIncreaseGrid];
        this.PainScaleDecreaseGridColumns = [this.NursingPainScalePainScaleDecreaseGrid, this.PainChangingSituationPainScaleDecreaseGrid];
        this.Controls = [this.labelPostNursingInitiative, this.PostNursingInitiative, this.PainScaleIncreaseGrids, this.NursingPainScalePainScaleIncreaseGrid, this.PainChangingSituationPainScaleIncreaseGrid, this.PainScaleDecreaseGrid, this.NursingPainScalePainScaleDecreaseGrid, this.PainChangingSituationPainScaleDecreaseGrid, this.labelPainQuality, this.PainQuality, this.labelPainFrequency, this.PainFrequency, this.labelPainPlaces, this.PainPlaces, this.labelApplicationDate, this.ApplicationDate, this.labelPainFaceScale, this.PainFaceScale, this.labelPainQualityDescription, this.PainQualityDescription, this.AchingSide, this.DurationofPain, this.PainTime, this.PainDetail, this.labelAchingSide, this.labelDurationofPain, this.labelPainTime, this.labelPainDetail];

    }


}
