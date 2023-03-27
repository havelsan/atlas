//$D301B451
import { Component, ViewChild, OnInit, ApplicationRef, Output, EventEmitter, Input, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PostpartumFollowUpFormViewModel } from './PostpartumFollowUpFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PostpartumFollowUp, SKRSKonjenitalAnomaliliDogumVarligi } from 'NebulaClient/Model/AtlasClientModel';
import { ComplicationDiagnosis } from 'NebulaClient/Model/AtlasClientModel';
import { PostpartumDangerSigns } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDemirLojistigiveDestegi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDVitaminiLojistigiveDestegi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGebelikLohusalikSeyrindeTehlikeIsareti } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICD } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKacinciLohusaIzlem } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKadinSagligiIslemleri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKonjenitalAnomaliVarligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPostpartumDepresyon } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSUterusInvolusyon } from 'NebulaClient/Model/AtlasClientModel';
import { WomanHealthOperations } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { WomanSpecialityObjectInfo } from './WomanSpecialityFormViewModel';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'PostpartumFollowUpForm',
    templateUrl: './PostpartumFollowUpForm.html',
    providers: [MessageService]
})
export class PostpartumFollowUpForm extends TTVisual.TTForm implements OnInit {
    ComplicationDiagnosis: TTVisual.ITTGrid;
    CongenitalAnomalies: TTVisual.ITTObjectListBox;
    DangerSigns: TTVisual.ITTGrid;
    Hemoglobin: TTVisual.ITTTextBox;
    InformerName: TTVisual.ITTTextBox;
    InformerPhone: TTVisual.ITTTextBox;
    IronLogisticsAndSupplement: TTVisual.ITTObjectListBox;
    labelCongenitalAnomaliesPresence: TTVisual.ITTLabel;
    labelHemoglobin: TTVisual.ITTLabel;
    labelInformerName: TTVisual.ITTLabel;
    labelInformerPhone: TTVisual.ITTLabel;
    labelIronLogisticsAndSupplement: TTVisual.ITTLabel;
    labelPostpartumDepression: TTVisual.ITTLabel;
    labelPregnancyDueDate: TTVisual.ITTLabel;
    labelUterusInvolution: TTVisual.ITTLabel;
    labelVitaminDSupplements: TTVisual.ITTLabel;
    labelWhichPostpartumFollowUp: TTVisual.ITTLabel;
    labelWomanHealth: TTVisual.ITTLabel;
    PostpartumDepression: TTVisual.ITTObjectListBox;
    PregnancyDueDate: TTVisual.ITTDateTimePicker;
    SKRSDangerSignsPostpartumDangerSigns: TTVisual.ITTListBoxColumn;
    SKRSICD10ComplicationDiagnosis: TTVisual.ITTListBoxColumn;
    SKRSWomanHealthOperationsWomanHealthOperations: TTVisual.ITTListBoxColumn;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    UterusInvolution: TTVisual.ITTObjectListBox;
    VitaminDSupplements: TTVisual.ITTObjectListBox;
    WhichPostpartumFollowUp: TTVisual.ITTObjectListBox;
    WomanHealthOperations: TTVisual.ITTGrid;
    public ComplicationDiagnosisColumns = [];
    public DangerSignsColumns = [];
    public WomanHealthOperationsColumns = [];
    public postpartumFollowUpFormViewModel: PostpartumFollowUpFormViewModel = new PostpartumFollowUpFormViewModel();
    public get _PostpartumFollowUp(): PostpartumFollowUp {
        return this._TTObject as PostpartumFollowUp;
    }
    private PostpartumFollowUpForm_DocumentUrl: string = '/api/PostpartumFollowUpService/PostpartumFollowUpForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super('POSTPARTUMFOLLOWUP', 'PostpartumFollowUpForm');
        this._DocumentServiceUrl = this.PostpartumFollowUpForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    @Output() sendViewModelToParent: EventEmitter<PostpartumFollowUpFormViewModel> = new EventEmitter<PostpartumFollowUpFormViewModel>();
    @Input() set womanSpecialityObjectInfo(value: WomanSpecialityObjectInfo) {
        if (value != null) {
            if (value.WomanSpecialityObject != null && value.WomanSpecialityObject.PostpartumFollowUp != null) {
                if (typeof value.WomanSpecialityObject.PostpartumFollowUp == "string") {
                    this.ObjectID = value.WomanSpecialityObject.PostpartumFollowUp;
                } else {
                    this.ObjectID = value.WomanSpecialityObject.PostpartumFollowUp.ObjectID;
                }
            }
            if (value.ActiveIDsModel != null) {
                this.ActiveIDsModel = value.ActiveIDsModel;
            }
        }
    }


    public initViewModel(): void {
        this._TTObject = new PostpartumFollowUp();
        this.postpartumFollowUpFormViewModel = new PostpartumFollowUpFormViewModel();
        this._ViewModel = this.postpartumFollowUpFormViewModel;
        this.postpartumFollowUpFormViewModel._PostpartumFollowUp = this._TTObject as PostpartumFollowUp;
        this.postpartumFollowUpFormViewModel._PostpartumFollowUp.WomanHealthOperations = new Array<WomanHealthOperations>();
        this.postpartumFollowUpFormViewModel._PostpartumFollowUp.DangerSigns = new Array<PostpartumDangerSigns>();
        this.postpartumFollowUpFormViewModel._PostpartumFollowUp.ComplicationDiagnosis = new Array<ComplicationDiagnosis>();
        this.postpartumFollowUpFormViewModel._PostpartumFollowUp.CongenitalAnomalies = new SKRSKonjenitalAnomaliliDogumVarligi();
        this.postpartumFollowUpFormViewModel._PostpartumFollowUp.UterusInvolution = new SKRSUterusInvolusyon();
        this.postpartumFollowUpFormViewModel._PostpartumFollowUp.PostpartumDepression = new SKRSPostpartumDepresyon();
        this.postpartumFollowUpFormViewModel._PostpartumFollowUp.VitaminDSupplements = new SKRSDVitaminiLojistigiveDestegi();
        this.postpartumFollowUpFormViewModel._PostpartumFollowUp.IronLogisticsAndSupplement = new SKRSDemirLojistigiveDestegi();
        this.postpartumFollowUpFormViewModel._PostpartumFollowUp.WhichPostpartumFollowUp = new SKRSKacinciLohusaIzlem();
    }

    protected loadViewModel() {
        let that = this;
        that.postpartumFollowUpFormViewModel = this._ViewModel as PostpartumFollowUpFormViewModel;
        that._TTObject = this.postpartumFollowUpFormViewModel._PostpartumFollowUp;
        if (this.postpartumFollowUpFormViewModel == null)
            this.postpartumFollowUpFormViewModel = new PostpartumFollowUpFormViewModel();
        if (this.postpartumFollowUpFormViewModel._PostpartumFollowUp == null)
            this.postpartumFollowUpFormViewModel._PostpartumFollowUp = new PostpartumFollowUp();
        that.postpartumFollowUpFormViewModel._PostpartumFollowUp.WomanHealthOperations = that.postpartumFollowUpFormViewModel.WomanHealthOperationsGridList;
        for (let detailItem of that.postpartumFollowUpFormViewModel.WomanHealthOperationsGridList) {
            let sKRSWomanHealthOperationsObjectID = detailItem["SKRSWomanHealthOperations"];
            if (sKRSWomanHealthOperationsObjectID != null && (typeof sKRSWomanHealthOperationsObjectID === "string")) {
                let sKRSWomanHealthOperations = that.postpartumFollowUpFormViewModel.SKRSKadinSagligiIslemleris.find(o => o.ObjectID.toString() === sKRSWomanHealthOperationsObjectID.toString());
                if (sKRSWomanHealthOperations) {
                    detailItem.SKRSWomanHealthOperations = sKRSWomanHealthOperations;
                }
            }

        }

        that.postpartumFollowUpFormViewModel._PostpartumFollowUp.DangerSigns = that.postpartumFollowUpFormViewModel.DangerSignsGridList;
        for (let detailItem of that.postpartumFollowUpFormViewModel.DangerSignsGridList) {
            let sKRSDangerSignsObjectID = detailItem["SKRSDangerSigns"];
            if (sKRSDangerSignsObjectID != null && (typeof sKRSDangerSignsObjectID === "string")) {
                let sKRSDangerSigns = that.postpartumFollowUpFormViewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis.find(o => o.ObjectID.toString() === sKRSDangerSignsObjectID.toString());
                if (sKRSDangerSigns) {
                    detailItem.SKRSDangerSigns = sKRSDangerSigns;
                }
            }

        }

        that.postpartumFollowUpFormViewModel._PostpartumFollowUp.ComplicationDiagnosis = that.postpartumFollowUpFormViewModel.ComplicationDiagnosisGridList;
        for (let detailItem of that.postpartumFollowUpFormViewModel.ComplicationDiagnosisGridList) {
            let sKRSICD10ObjectID = detailItem["SKRSICD10"];
            if (sKRSICD10ObjectID != null && (typeof sKRSICD10ObjectID === "string")) {
                let sKRSICD10 = that.postpartumFollowUpFormViewModel.SKRSICDs.find(o => o.ObjectID.toString() === sKRSICD10ObjectID.toString());
                if (sKRSICD10) {
                    detailItem.SKRSICD10 = sKRSICD10;
                }
            }

        }

        let congenitalAnomaliesPresenceObjectID = that.postpartumFollowUpFormViewModel._PostpartumFollowUp["CongenitalAnomalies"];
        if (congenitalAnomaliesPresenceObjectID != null && (typeof congenitalAnomaliesPresenceObjectID === "string")) {
            let congenitalAnomaliesPresence = that.postpartumFollowUpFormViewModel.SKRSKonjenitalAnomaliliDogumVarligis.find(o => o.ObjectID.toString() === congenitalAnomaliesPresenceObjectID.toString());
            if (congenitalAnomaliesPresence) {
                that.postpartumFollowUpFormViewModel._PostpartumFollowUp.CongenitalAnomalies = congenitalAnomaliesPresence;
            }
        }


        let uterusInvolutionObjectID = that.postpartumFollowUpFormViewModel._PostpartumFollowUp["UterusInvolution"];
        if (uterusInvolutionObjectID != null && (typeof uterusInvolutionObjectID === "string")) {
            let uterusInvolution = that.postpartumFollowUpFormViewModel.SKRSUterusInvolusyons.find(o => o.ObjectID.toString() === uterusInvolutionObjectID.toString());
            if (uterusInvolution) {
                that.postpartumFollowUpFormViewModel._PostpartumFollowUp.UterusInvolution = uterusInvolution;
            }
        }


        let postpartumDepressionObjectID = that.postpartumFollowUpFormViewModel._PostpartumFollowUp["PostpartumDepression"];
        if (postpartumDepressionObjectID != null && (typeof postpartumDepressionObjectID === "string")) {
            let postpartumDepression = that.postpartumFollowUpFormViewModel.SKRSPostpartumDepresyons.find(o => o.ObjectID.toString() === postpartumDepressionObjectID.toString());
            if (postpartumDepression) {
                that.postpartumFollowUpFormViewModel._PostpartumFollowUp.PostpartumDepression = postpartumDepression;
            }
        }


        let vitaminDSupplementsObjectID = that.postpartumFollowUpFormViewModel._PostpartumFollowUp["VitaminDSupplements"];
        if (vitaminDSupplementsObjectID != null && (typeof vitaminDSupplementsObjectID === "string")) {
            let vitaminDSupplements = that.postpartumFollowUpFormViewModel.SKRSDVitaminiLojistigiveDestegis.find(o => o.ObjectID.toString() === vitaminDSupplementsObjectID.toString());
            if (vitaminDSupplements) {
                that.postpartumFollowUpFormViewModel._PostpartumFollowUp.VitaminDSupplements = vitaminDSupplements;
            }
        }


        let ironLogisticsAndSupplementObjectID = that.postpartumFollowUpFormViewModel._PostpartumFollowUp["IronLogisticsAndSupplement"];
        if (ironLogisticsAndSupplementObjectID != null && (typeof ironLogisticsAndSupplementObjectID === "string")) {
            let ironLogisticsAndSupplement = that.postpartumFollowUpFormViewModel.SKRSDemirLojistigiveDestegis.find(o => o.ObjectID.toString() === ironLogisticsAndSupplementObjectID.toString());
            if (ironLogisticsAndSupplement) {
                that.postpartumFollowUpFormViewModel._PostpartumFollowUp.IronLogisticsAndSupplement = ironLogisticsAndSupplement;
            }
        }


        let whichPostpartumFollowUpObjectID = that.postpartumFollowUpFormViewModel._PostpartumFollowUp["WhichPostpartumFollowUp"];
        if (whichPostpartumFollowUpObjectID != null && (typeof whichPostpartumFollowUpObjectID === "string")) {
            let whichPostpartumFollowUp = that.postpartumFollowUpFormViewModel.SKRSKacinciLohusaIzlems.find(o => o.ObjectID.toString() === whichPostpartumFollowUpObjectID.toString());
            if (whichPostpartumFollowUp) {
                that.postpartumFollowUpFormViewModel._PostpartumFollowUp.WhichPostpartumFollowUp = whichPostpartumFollowUp;
            }
        }
        this.sendViewModelToParent.emit(that.postpartumFollowUpFormViewModel);

    }

    async ngOnInit() {
        let that = this;
        await this.load(PostpartumFollowUpFormViewModel);
    }

    public onCongenitalAnomaliesPresenceChanged(event): void {
        if (this._PostpartumFollowUp != null && this._PostpartumFollowUp.CongenitalAnomalies != event) {
            this._PostpartumFollowUp.CongenitalAnomalies = event;
        }
    }

    public onHemoglobinChanged(event): void {
        if (this._PostpartumFollowUp != null && this._PostpartumFollowUp.Hemoglobin != event) {
            this._PostpartumFollowUp.Hemoglobin = event;
        }
    }

    public onInformerNameChanged(event): void {
        if (this._PostpartumFollowUp != null && this._PostpartumFollowUp.InformerName != event) {
            this._PostpartumFollowUp.InformerName = event;
        }
    }

    public onInformerPhoneChanged(event): void {
        if (this._PostpartumFollowUp != null && this._PostpartumFollowUp.InformerPhone != event) {
            this._PostpartumFollowUp.InformerPhone = event;
        }
    }

    public onIronLogisticsAndSupplementChanged(event): void {
        if (this._PostpartumFollowUp != null && this._PostpartumFollowUp.IronLogisticsAndSupplement != event) {
            this._PostpartumFollowUp.IronLogisticsAndSupplement = event;
        }
    }

    public onPostpartumDepressionChanged(event): void {
        if (this._PostpartumFollowUp != null && this._PostpartumFollowUp.PostpartumDepression != event) {
            this._PostpartumFollowUp.PostpartumDepression = event;
        }
    }

    public onPregnancyDueDateChanged(event): void {
        if (this._PostpartumFollowUp != null && this._PostpartumFollowUp.PregnancyDueDate != event) {
            this._PostpartumFollowUp.PregnancyDueDate = event;
        }
    }

    public onUterusInvolutionChanged(event): void {
        if (this._PostpartumFollowUp != null && this._PostpartumFollowUp.UterusInvolution != event) {
            this._PostpartumFollowUp.UterusInvolution = event;
        }
    }

    public onVitaminDSupplementsChanged(event): void {
        if (this._PostpartumFollowUp != null && this._PostpartumFollowUp.VitaminDSupplements != event) {
            this._PostpartumFollowUp.VitaminDSupplements = event;
        }
    }

    public onWhichPostpartumFollowUpChanged(event): void {
        if (this._PostpartumFollowUp != null && this._PostpartumFollowUp.WhichPostpartumFollowUp != event) {
            this._PostpartumFollowUp.WhichPostpartumFollowUp = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.PregnancyDueDate, "Value", this.__ttObject, "PregnancyDueDate");
        redirectProperty(this.Hemoglobin, "Text", this.__ttObject, "Hemoglobin");
        redirectProperty(this.InformerName, "Text", this.__ttObject, "InformerName");
        redirectProperty(this.InformerPhone, "Text", this.__ttObject, "InformerPhone");
    }


    public initFormControls(): void {
        this.WomanHealthOperations = new TTVisual.TTGrid();
        this.WomanHealthOperations.Name = "WomanHealthOperations";
        this.WomanHealthOperations.TabIndex = 22;
        this.WomanHealthOperations.ReadOnly = true;
        this.WomanHealthOperations.Height = "200px";
        this.WomanHealthOperations.ShowFilterCombo = true;
        this.WomanHealthOperations.FilterColumnName = "SKRSWomanHealthOperationsWomanHealthOperations";
        this.WomanHealthOperations.Filter = { ListDefName: "SKRSKadinSagligiIslemleriList" };
        this.WomanHealthOperations.FilterLabel = i18n("M23785", "Kadın Sağlığı İşlemleri");
        this.WomanHealthOperations.AllowUserToAddRows = false;
        this.WomanHealthOperations.DeleteButtonWidth = "5%";
        this.WomanHealthOperations.AllowUserToDeleteRows = true;
        this.WomanHealthOperations.IsFilterLabelSingleLine = true;

        this.SKRSWomanHealthOperationsWomanHealthOperations = new TTVisual.TTListBoxColumn();
        this.SKRSWomanHealthOperationsWomanHealthOperations.ListDefName = "SKRSKadinSagligiIslemleriList";
        this.SKRSWomanHealthOperationsWomanHealthOperations.DataMember = "SKRSWomanHealthOperations";
        this.SKRSWomanHealthOperationsWomanHealthOperations.DisplayIndex = 0;
        this.SKRSWomanHealthOperationsWomanHealthOperations.HeaderText = "Kadın Sağlığı İşlemleri";
        this.SKRSWomanHealthOperationsWomanHealthOperations.Name = "SKRSWomanHealthOperationsWomanHealthOperations";
        this.SKRSWomanHealthOperationsWomanHealthOperations.Width = 300;



        this.DangerSigns = new TTVisual.TTGrid();
        this.DangerSigns.Name = "DangerSigns";
        this.DangerSigns.TabIndex = 21;
        this.DangerSigns.ReadOnly = true;
        this.DangerSigns.Height = "200px";
        this.DangerSigns.ShowFilterCombo = true;
        this.DangerSigns.FilterColumnName = "SKRSDangerSignsPostpartumDangerSigns";
        this.DangerSigns.Filter = { ListDefName: "SKRSGebelikLohusalikSeyrindeTehlikeIsaretiList" };
        this.DangerSigns.FilterLabel = i18n("M23785", "Lohusalık Seyrinde Tehlike İşareti");
        this.DangerSigns.AllowUserToAddRows = false;
        this.DangerSigns.DeleteButtonWidth = "5%";
        this.DangerSigns.AllowUserToDeleteRows = true;
        this.DangerSigns.IsFilterLabelSingleLine = true;


        this.SKRSDangerSignsPostpartumDangerSigns = new TTVisual.TTListBoxColumn();
        this.SKRSDangerSignsPostpartumDangerSigns.ListDefName = "SKRSGebelikLohusalikSeyrindeTehlikeIsaretiList";
        this.SKRSDangerSignsPostpartumDangerSigns.DataMember = "SKRSDangerSigns";
        this.SKRSDangerSignsPostpartumDangerSigns.DisplayIndex = 0;
        this.SKRSDangerSignsPostpartumDangerSigns.HeaderText = "Lohusalık Seyrinde Tehlike İşareti";
        this.SKRSDangerSignsPostpartumDangerSigns.Name = "SKRSDangerSignsPostpartumDangerSigns";
        this.SKRSDangerSignsPostpartumDangerSigns.Width = 300;

        this.ComplicationDiagnosis = new TTVisual.TTGrid();
        this.ComplicationDiagnosis.Name = "ComplicationDiagnosis";
        this.ComplicationDiagnosis.TabIndex = 20;
        this.ComplicationDiagnosis.Height = "200px";
        this.ComplicationDiagnosis.ShowFilterCombo = true;
        this.ComplicationDiagnosis.FilterColumnName = "SKRSICD10ComplicationDiagnosis";
        this.ComplicationDiagnosis.Filter = { ListDefName: "SKRSICDList" };
        this.ComplicationDiagnosis.FilterLabel = i18n("M23785", "Komplikasyon Tanı Bilgisi");
        this.ComplicationDiagnosis.AllowUserToAddRows = false;
        this.ComplicationDiagnosis.DeleteButtonWidth = "5%";
        this.ComplicationDiagnosis.AllowUserToDeleteRows = true;
        this.ComplicationDiagnosis.IsFilterLabelSingleLine = true;

        this.SKRSICD10ComplicationDiagnosis = new TTVisual.TTListBoxColumn();
        this.SKRSICD10ComplicationDiagnosis.ListDefName = "SKRSICDList";
        this.SKRSICD10ComplicationDiagnosis.DataMember = "SKRSICD10";
        this.SKRSICD10ComplicationDiagnosis.DisplayIndex = 0;
        this.SKRSICD10ComplicationDiagnosis.HeaderText = "Komplikasyon Tanı Bilgisi";
        this.SKRSICD10ComplicationDiagnosis.Name = "SKRSICD10ComplicationDiagnosis";
        this.SKRSICD10ComplicationDiagnosis.Width = 300;

        this.labelCongenitalAnomaliesPresence = new TTVisual.TTLabel();
        this.labelCongenitalAnomaliesPresence.Text = "Konjenital Anomali Varlığı";
        this.labelCongenitalAnomaliesPresence.Name = "labelCongenitalAnomaliesPresence";
        this.labelCongenitalAnomaliesPresence.TabIndex = 19;

        this.CongenitalAnomalies = new TTVisual.TTObjectListBox();
        this.CongenitalAnomalies.ListDefName = "SKRSKonjenitalAnomaliliDogumVarligiList";
        this.CongenitalAnomalies.Name = "CongenitalAnomalies";
        this.CongenitalAnomalies.TabIndex = 18;
        this.CongenitalAnomalies.Required = true;

        this.labelUterusInvolution = new TTVisual.TTLabel();
        this.labelUterusInvolution.Text = "Uterus Involusyon";
        this.labelUterusInvolution.Name = "labelUterusInvolution";
        this.labelUterusInvolution.TabIndex = 17;

        this.UterusInvolution = new TTVisual.TTObjectListBox();
        this.UterusInvolution.ListDefName = "SKRSUterusInvolusyonList";
        this.UterusInvolution.Name = "UterusInvolution";
        this.UterusInvolution.TabIndex = 16;
        this.UterusInvolution.Required = true;

        this.labelPostpartumDepression = new TTVisual.TTLabel();
        this.labelPostpartumDepression.Text = "Postpartum Depresyon";
        this.labelPostpartumDepression.Name = "labelPostpartumDepression";
        this.labelPostpartumDepression.TabIndex = 15;

        this.PostpartumDepression = new TTVisual.TTObjectListBox();
        this.PostpartumDepression.ListDefName = "SKRSPostpartumDepresyonList";
        this.PostpartumDepression.Name = "PostpartumDepression";
        this.PostpartumDepression.TabIndex = 14;
        this.PostpartumDepression.Required = true;

        this.labelVitaminDSupplements = new TTVisual.TTLabel();
        this.labelVitaminDSupplements.Text = "D Vitamini Lojistiği ve Desteği";
        this.labelVitaminDSupplements.Name = "labelVitaminDSupplements";
        this.labelVitaminDSupplements.TabIndex = 13;

        this.VitaminDSupplements = new TTVisual.TTObjectListBox();
        this.VitaminDSupplements.ListDefName = "SKRSDVitaminiLojistigiveDestegiList";
        this.VitaminDSupplements.Name = "VitaminDSupplements";
        this.VitaminDSupplements.TabIndex = 12;
        this.VitaminDSupplements.Required = true;

        this.labelIronLogisticsAndSupplement = new TTVisual.TTLabel();
        this.labelIronLogisticsAndSupplement.Text = "Demir Lojistiği ve Desteği";
        this.labelIronLogisticsAndSupplement.Name = "labelIronLogisticsAndSupplement";
        this.labelIronLogisticsAndSupplement.TabIndex = 11;

        this.IronLogisticsAndSupplement = new TTVisual.TTObjectListBox();
        this.IronLogisticsAndSupplement.ListDefName = "SKRSDemirLojistigiveDestegiList";
        this.IronLogisticsAndSupplement.Name = "IronLogisticsAndSupplement";
        this.IronLogisticsAndSupplement.TabIndex = 10;
        this.IronLogisticsAndSupplement.Required = true;

        this.labelWhichPostpartumFollowUp = new TTVisual.TTLabel();
        this.labelWhichPostpartumFollowUp.Text = "Kaçıncı Lohusa İzlem";
        this.labelWhichPostpartumFollowUp.Name = "labelWhichPostpartumFollowUp";
        this.labelWhichPostpartumFollowUp.TabIndex = 9;

        this.WhichPostpartumFollowUp = new TTVisual.TTObjectListBox();
        this.WhichPostpartumFollowUp.ListDefName = "SKRSKacinciLohusaIzlemList";
        this.WhichPostpartumFollowUp.Name = "WhichPostpartumFollowUp";
        this.WhichPostpartumFollowUp.TabIndex = 8;
        this.WhichPostpartumFollowUp.Required = true;

        this.labelInformerPhone = new TTVisual.TTLabel();
        this.labelInformerPhone.Text = "Bilgi Alınan Kişi Telefon No";
        this.labelInformerPhone.Name = "labelInformerPhone";
        this.labelInformerPhone.TabIndex = 7;

        this.InformerPhone = new TTVisual.TTTextBox();
        this.InformerPhone.Name = "InformerPhone";
        this.InformerPhone.TabIndex = 6;

        this.InformerName = new TTVisual.TTTextBox();
        this.InformerName.Name = "InformerName";
        this.InformerName.TabIndex = 4;

        this.Hemoglobin = new TTVisual.TTTextBox();
        this.Hemoglobin.Name = "Hemoglobin";
        this.Hemoglobin.TabIndex = 2;

        this.labelInformerName = new TTVisual.TTLabel();
        this.labelInformerName.Text = "Bilgi Alınan Kişi";
        this.labelInformerName.Name = "labelInformerName";
        this.labelInformerName.TabIndex = 5;

        this.labelHemoglobin = new TTVisual.TTLabel();
        this.labelHemoglobin.Text = "Hemoglobin";
        this.labelHemoglobin.Name = "labelHemoglobin";
        this.labelHemoglobin.TabIndex = 3;

        this.labelPregnancyDueDate = new TTVisual.TTLabel();
        this.labelPregnancyDueDate.Text = "Gebelik Sonlanma Tarihi";
        this.labelPregnancyDueDate.Name = "labelPregnancyDueDate";
        this.labelPregnancyDueDate.TabIndex = 1;

        this.PregnancyDueDate = new TTVisual.TTDateTimePicker();
        this.PregnancyDueDate.Format = DateTimePickerFormat.Long;
        this.PregnancyDueDate.Name = "PregnancyDueDate";
        this.PregnancyDueDate.TabIndex = 0;
        this.PregnancyDueDate.Required = true;

        this.labelWomanHealth = new TTVisual.TTLabel();
        this.labelWomanHealth.Text = "Kadın Sağlığı İşlemleri";
        this.labelWomanHealth.Name = "labelWomanHealth";
        this.labelWomanHealth.TabIndex = 1;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "Komplikasyon Tanı Bilgisi";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 1;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "Lohusalık Seyrinde Tehlike İşareti";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 1;

        this.WomanHealthOperationsColumns = [this.SKRSWomanHealthOperationsWomanHealthOperations];
        this.DangerSignsColumns = [this.SKRSDangerSignsPostpartumDangerSigns];
        this.ComplicationDiagnosisColumns = [this.SKRSICD10ComplicationDiagnosis];
        this.Controls = [this.WomanHealthOperations, this.SKRSWomanHealthOperationsWomanHealthOperations, this.DangerSigns, this.SKRSDangerSignsPostpartumDangerSigns, this.ComplicationDiagnosis, this.SKRSICD10ComplicationDiagnosis, this.labelCongenitalAnomaliesPresence, this.CongenitalAnomalies, this.labelUterusInvolution, this.UterusInvolution, this.labelPostpartumDepression, this.PostpartumDepression, this.labelVitaminDSupplements, this.VitaminDSupplements, this.labelIronLogisticsAndSupplement, this.IronLogisticsAndSupplement, this.labelWhichPostpartumFollowUp, this.WhichPostpartumFollowUp, this.labelInformerPhone, this.InformerPhone, this.InformerName, this.Hemoglobin, this.labelInformerName, this.labelHemoglobin, this.labelPregnancyDueDate, this.PregnancyDueDate, this.labelWomanHealth, this.ttlabel8, this.ttlabel9];

    }


}
