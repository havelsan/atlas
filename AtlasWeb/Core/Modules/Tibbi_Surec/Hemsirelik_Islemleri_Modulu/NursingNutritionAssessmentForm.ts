//$48F0EA40
import { Component, OnInit, NgZone } from '@angular/core';
import { NursingNutritionAssessmentFormViewModel } from './NursingNutritionAssessmentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNursingDataEntryForm } from "Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/BaseNursingDataEntryForm";
import { NursingNutritionAssessment } from 'NebulaClient/Model/AtlasClientModel';

import { NursingDietDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PanoramaDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SwallowDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ToothDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { UrgeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';



@Component({
    selector: 'NursingNutritionAssessmentForm',
    templateUrl: './NursingNutritionAssessmentForm.html',
    providers: [MessageService]
})
export class NursingNutritionAssessmentForm extends BaseNursingDataEntryForm implements OnInit {
    AbdominalCircle: TTVisual.ITTTextBox;
    ApplicationDate: TTVisual.ITTDateTimePicker;
    Gastronomy: TTVisual.ITTCheckBox;
    Height: TTVisual.ITTTextBox;
    labelAbdominalCircle: TTVisual.ITTLabel;
    labelApplicationDate: TTVisual.ITTLabel;
    labelHeight: TTVisual.ITTLabel;
    labelLeftLegCircle: TTVisual.ITTLabel;
    labelNursingDiet: TTVisual.ITTLabel;
    labelPanorama: TTVisual.ITTLabel;
    labelRightLegCircle: TTVisual.ITTLabel;
    labelSwallow: TTVisual.ITTLabel;
    labelTooth: TTVisual.ITTLabel;
    labelUrge: TTVisual.ITTLabel;
    labelWeight: TTVisual.ITTLabel;
    labelWeightChange: TTVisual.ITTLabel;
    labelWeightChangeNote: TTVisual.ITTLabel;
    LeftLegCircle: TTVisual.ITTTextBox;
    NasogastricTube: TTVisual.ITTCheckBox;
    NursingDiet: TTVisual.ITTObjectListBox;
    Panorama: TTVisual.ITTObjectListBox;
    RightLegCircle: TTVisual.ITTTextBox;
    Swallow: TTVisual.ITTObjectListBox;
    Tooth: TTVisual.ITTObjectListBox;
    Urge: TTVisual.ITTObjectListBox;
    Weight: TTVisual.ITTTextBox;
    WeightChange: TTVisual.ITTTextBox;
    WeightChangeNote: TTVisual.ITTTextBox;
    public nursingNutritionAssessmentFormViewModel: NursingNutritionAssessmentFormViewModel = new NursingNutritionAssessmentFormViewModel();
    public get _NursingNutritionAssessment(): NursingNutritionAssessment {
        return this._TTObject as NursingNutritionAssessment;
    }
    private NursingNutritionAssessmentForm_DocumentUrl: string = '/api/NursingNutritionAssessmentService/NursingNutritionAssessmentForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NursingNutritionAssessmentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NursingNutritionAssessment();
        this.nursingNutritionAssessmentFormViewModel = new NursingNutritionAssessmentFormViewModel();
        this._ViewModel = this.nursingNutritionAssessmentFormViewModel;
        this.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment = this._TTObject as NursingNutritionAssessment;
        this.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment.NursingDiet = new NursingDietDefinition();
        this.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment.Tooth = new ToothDefinition();
        this.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment.Urge = new UrgeDefinition();
        this.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment.Swallow = new SwallowDefinition();
        this.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment.Panorama = new PanoramaDefinition();
    }

    protected loadViewModel() {
        let that = this;

        that.nursingNutritionAssessmentFormViewModel = this._ViewModel as NursingNutritionAssessmentFormViewModel;
        that._TTObject = this.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment;
        if (this.nursingNutritionAssessmentFormViewModel == null)
            this.nursingNutritionAssessmentFormViewModel = new NursingNutritionAssessmentFormViewModel();
        if (this.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment == null)
            this.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment = new NursingNutritionAssessment();
        let nursingDietObjectID = that.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment["NursingDiet"];
        if (nursingDietObjectID != null && (typeof nursingDietObjectID === 'string')) {
            let nursingDiet = that.nursingNutritionAssessmentFormViewModel.NursingDietDefinitions.find(o => o.ObjectID.toString() === nursingDietObjectID.toString());
             if (nursingDiet) {
                that.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment.NursingDiet = nursingDiet;
            }
        }
        let toothObjectID = that.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment["Tooth"];
        if (toothObjectID != null && (typeof toothObjectID === 'string')) {
            let tooth = that.nursingNutritionAssessmentFormViewModel.ToothDefinitions.find(o => o.ObjectID.toString() === toothObjectID.toString());
             if (tooth) {
                that.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment.Tooth = tooth;
            }
        }
        let urgeObjectID = that.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment["Urge"];
        if (urgeObjectID != null && (typeof urgeObjectID === 'string')) {
            let urge = that.nursingNutritionAssessmentFormViewModel.UrgeDefinitions.find(o => o.ObjectID.toString() === urgeObjectID.toString());
             if (urge) {
                that.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment.Urge = urge;
            }
        }
        let swallowObjectID = that.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment["Swallow"];
        if (swallowObjectID != null && (typeof swallowObjectID === 'string')) {
            let swallow = that.nursingNutritionAssessmentFormViewModel.SwallowDefinitions.find(o => o.ObjectID.toString() === swallowObjectID.toString());
             if (swallow) {
                that.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment.Swallow = swallow;
            }
        }
        let panoramaObjectID = that.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment["Panorama"];
        if (panoramaObjectID != null && (typeof panoramaObjectID === 'string')) {
            let panorama = that.nursingNutritionAssessmentFormViewModel.PanoramaDefinitions.find(o => o.ObjectID.toString() === panoramaObjectID.toString());
             if (panorama) {
                that.nursingNutritionAssessmentFormViewModel._NursingNutritionAssessment.Panorama = panorama;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(NursingNutritionAssessmentFormViewModel);
  
    }


    protected async ClientSidePreScript(): Promise<void> {
        //TODO:ismail isteğin detayına göre açılacak
        //this.ReadOnly = true;
        if (this["NursAppReadOnly"] != null)
            this.nursingNutritionAssessmentFormViewModel.ReadOnly = (this.nursingNutritionAssessmentFormViewModel.ReadOnly || this["NursAppReadOnly"]);

        if (this.nursingNutritionAssessmentFormViewModel.ReadOnly)
            this.DropStateButton(NursingNutritionAssessment.NursingNutritionAssessmentStates.Cancelled);

        super.ClientSidePreScript();
    }

    public onAbdominalCircleChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.AbdominalCircle != event) {
                this._NursingNutritionAssessment.AbdominalCircle = event;
            }
        }
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.ApplicationDate != event) {
                this._NursingNutritionAssessment.ApplicationDate = event;
            }
        }
    }

    public onGastronomyChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.Gastronomy != event) {
                this._NursingNutritionAssessment.Gastronomy = event;
            }
        }
    }

    public onHeightChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.Height != event) {
                this._NursingNutritionAssessment.Height = event;
            }
        }
    }

    public onLeftLegCircleChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.LeftLegCircle != event) {
                this._NursingNutritionAssessment.LeftLegCircle = event;
            }
        }
    }

    public onNasogastricTubeChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.NasogastricTube != event) {
                this._NursingNutritionAssessment.NasogastricTube = event;
            }
        }
    }

    public onNursingDietChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.NursingDiet != event) {
                this._NursingNutritionAssessment.NursingDiet = event;
            }
        }
    }

    public onPanoramaChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.Panorama != event) {
                this._NursingNutritionAssessment.Panorama = event;
            }
        }
    }

    public onRightLegCircleChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.RightLegCircle != event) {
                this._NursingNutritionAssessment.RightLegCircle = event;
            }
        }
    }

    public onSwallowChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.Swallow != event) {
                this._NursingNutritionAssessment.Swallow = event;
            }
        }
    }

    public onToothChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.Tooth != event) {
                this._NursingNutritionAssessment.Tooth = event;
            }
        }
    }

    public onUrgeChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.Urge != event) {
                this._NursingNutritionAssessment.Urge = event;
            }
        }
    }

    public onWeightChangeChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.WeightChange != event) {
                this._NursingNutritionAssessment.WeightChange = event;
            }
        }
    }

    public onWeightChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.Weight != event) {
                this._NursingNutritionAssessment.Weight = event;
            }
        }
    }

    public onWeightChangeNoteChanged(event): void {
        if (event != null) {
            if (this._NursingNutritionAssessment != null && this._NursingNutritionAssessment.WeightChangeNote != event) {
                this._NursingNutritionAssessment.WeightChangeNote = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ApplicationDate, "Value", this.__ttObject, "ApplicationDate");
        redirectProperty(this.Weight, "Text", this.__ttObject, "Weight");
        redirectProperty(this.WeightChange, "Text", this.__ttObject, "WeightChange");
        redirectProperty(this.Height, "Text", this.__ttObject, "Height");
        redirectProperty(this.AbdominalCircle, "Text", this.__ttObject, "AbdominalCircle");
        redirectProperty(this.LeftLegCircle, "Text", this.__ttObject, "LeftLegCircle");
        redirectProperty(this.RightLegCircle, "Text", this.__ttObject, "RightLegCircle");
        redirectProperty(this.WeightChangeNote, "Text", this.__ttObject, "WeightChangeNote");
        redirectProperty(this.Gastronomy, "Value", this.__ttObject, "Gastronomy");
        redirectProperty(this.NasogastricTube, "Value", this.__ttObject, "NasogastricTube");
    }

    public initFormControls(): void {
        this.labelNursingDiet = new TTVisual.TTLabel();
        this.labelNursingDiet.Text = i18n("M20299", "Perhiz");
        this.labelNursingDiet.Name = "labelNursingDiet";
        this.labelNursingDiet.TabIndex = 29;

        this.NursingDiet = new TTVisual.TTObjectListBox();
        this.NursingDiet.ListDefName = "NursingDietListDefinition";
        this.NursingDiet.Name = "NursingDiet";
        this.NursingDiet.TabIndex = 28;

        this.labelTooth = new TTVisual.TTLabel();
        this.labelTooth.Text = i18n("M12970", "Diş Yapısı");
        this.labelTooth.Name = "labelTooth";
        this.labelTooth.TabIndex = 27;

        this.Tooth = new TTVisual.TTObjectListBox();
        this.Tooth.ListDefName = "ToothListDefinition";
        this.Tooth.Name = "Tooth";
        this.Tooth.TabIndex = 26;

        this.labelUrge = new TTVisual.TTLabel();
        this.labelUrge.Text = i18n("M16960", "İştah");
        this.labelUrge.Name = "labelUrge";
        this.labelUrge.TabIndex = 25;

        this.Urge = new TTVisual.TTObjectListBox();
        this.Urge.ListDefName = "UrgeListDefinition";
        this.Urge.Name = "Urge";
        this.Urge.TabIndex = 24;

        this.labelSwallow = new TTVisual.TTLabel();
        this.labelSwallow.Text = i18n("M24732", "Yutkunma");
        this.labelSwallow.Name = "labelSwallow";
        this.labelSwallow.TabIndex = 23;

        this.Swallow = new TTVisual.TTObjectListBox();
        this.Swallow.ListDefName = "SwallowListDefinition";
        this.Swallow.Name = "Swallow";
        this.Swallow.TabIndex = 22;

        this.labelPanorama = new TTVisual.TTLabel();
        this.labelPanorama.Text = i18n("M14691", "Genel Görünüm");
        this.labelPanorama.Name = "labelPanorama";
        this.labelPanorama.TabIndex = 21;

        this.Panorama = new TTVisual.TTObjectListBox();
        this.Panorama.ListDefName = "PanoramaListDefinition";
        this.Panorama.Name = "Panorama";
        this.Panorama.TabIndex = 20;

        this.labelApplicationDate = new TTVisual.TTLabel();
        this.labelApplicationDate.Text = i18n("M23772", "Uygulama Zamanı");
        this.labelApplicationDate.Name = "labelApplicationDate";
        this.labelApplicationDate.TabIndex = 19;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = "ApplicationDate";
        this.ApplicationDate.TabIndex = 18;

        this.NasogastricTube = new TTVisual.TTCheckBox();
        this.NasogastricTube.Value = false;
        this.NasogastricTube.Title = i18n("M19425", "Nazogastrik Tüp");
        this.NasogastricTube.Name = "NasogastricTube";
        this.NasogastricTube.TabIndex = 17;

        this.labelRightLegCircle = new TTVisual.TTLabel();
        this.labelRightLegCircle.Text = i18n("M21129", "Sağ Ayak Ölçümü(cm)");
        this.labelRightLegCircle.Name = "labelRightLegCircle";
        this.labelRightLegCircle.TabIndex = 16;

        this.RightLegCircle = new TTVisual.TTTextBox();
        this.RightLegCircle.Name = "RightLegCircle";
        this.RightLegCircle.TabIndex = 15;

        this.LeftLegCircle = new TTVisual.TTTextBox();
        this.LeftLegCircle.Name = "LeftLegCircle";
        this.LeftLegCircle.TabIndex = 13;

        this.AbdominalCircle = new TTVisual.TTTextBox();
        this.AbdominalCircle.Name = "AbdominalCircle";
        this.AbdominalCircle.TabIndex = 8;

        this.WeightChangeNote = new TTVisual.TTTextBox();
        this.WeightChangeNote.Name = "WeightChangeNote";
        this.WeightChangeNote.TabIndex = 6;

        this.WeightChange = new TTVisual.TTTextBox();
        this.WeightChange.Name = "WeightChange";
        this.WeightChange.TabIndex = 4;

        this.Height = new TTVisual.TTTextBox();
        this.Height.Name = "Height";
        this.Height.TabIndex = 2;

        this.Weight = new TTVisual.TTTextBox();
        this.Weight.Name = "Weight";
        this.Weight.TabIndex = 0;

        this.labelLeftLegCircle = new TTVisual.TTLabel();
        this.labelLeftLegCircle.Text = i18n("M22005", "Sol Ayak Ölçümü(cm)");
        this.labelLeftLegCircle.Name = "labelLeftLegCircle";
        this.labelLeftLegCircle.TabIndex = 14;

        this.Gastronomy = new TTVisual.TTCheckBox();
        this.Gastronomy.Value = false;
        this.Gastronomy.Title = i18n("M14526", "Gastronomi");
        this.Gastronomy.Name = "Gastronomy";
        this.Gastronomy.TabIndex = 12;

        this.labelAbdominalCircle = new TTVisual.TTLabel();
        this.labelAbdominalCircle.Text = i18n("M17303", "Karın Çevresi(cm)");
        this.labelAbdominalCircle.Name = "labelAbdominalCircle";
        this.labelAbdominalCircle.TabIndex = 9;

        this.labelWeightChangeNote = new TTVisual.TTLabel();
        this.labelWeightChangeNote.Text = i18n("M17562", "Kilo Değişiklik Notu");
        this.labelWeightChangeNote.Name = "labelWeightChangeNote";
        this.labelWeightChangeNote.TabIndex = 7;

        this.labelWeightChange = new TTVisual.TTLabel();
        this.labelWeightChange.Text = i18n("M17569", "Kilodaki Değişiklik");
        this.labelWeightChange.Name = "labelWeightChange";
        this.labelWeightChange.TabIndex = 5;

        this.labelHeight = new TTVisual.TTLabel();
        this.labelHeight.Text = i18n("M11992", "Boy(cm)");
        this.labelHeight.Name = "labelHeight";
        this.labelHeight.TabIndex = 3;

        this.labelWeight = new TTVisual.TTLabel();
        this.labelWeight.Text = "Kilo";
        this.labelWeight.Name = "labelWeight";
        this.labelWeight.TabIndex = 1;

        this.Controls = [this.labelNursingDiet, this.NursingDiet, this.labelTooth, this.Tooth, this.labelUrge, this.Urge, this.labelSwallow, this.Swallow, this.labelPanorama, this.Panorama, this.labelApplicationDate, this.ApplicationDate, this.NasogastricTube, this.labelRightLegCircle, this.RightLegCircle, this.LeftLegCircle, this.AbdominalCircle, this.WeightChangeNote, this.WeightChange, this.Height, this.Weight, this.labelLeftLegCircle, this.Gastronomy, this.labelAbdominalCircle, this.labelWeightChangeNote, this.labelWeightChange, this.labelHeight, this.labelWeight];

    }


}
