//$F79E3FE0
import { Component, OnInit, NgZone } from '@angular/core';
import { OldWomanSpecialityFormViewModel } from './OldWomanSpecialityFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { WomanSpecialityObject } from 'NebulaClient/Model/AtlasClientModel';
import { FetusFollow } from 'NebulaClient/Model/AtlasClientModel';
import { Gynecology } from 'NebulaClient/Model/AtlasClientModel';
import { Infertility } from 'NebulaClient/Model/AtlasClientModel';
import { ObligedRiskFactors } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyComplications } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyDangerSign } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyFollow } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDemirLojistigiveDestegi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDVitaminiLojistigiveDestegi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIdrardaProtein } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKacinciGebeIzlem } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKadinSagligiIslemleri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKonjenitalAnomaliliDogumVarligi } from 'NebulaClient/Model/AtlasClientModel';


import { Convert } from "NebulaClient/Mscorlib/Convert";

@Component({
    selector: 'OldWomanSpecialityForm',
    templateUrl: './OldWomanSpecialityForm.html',
    providers: [MessageService]
})
export class OldWomanSpecialityForm extends TTVisual.TTForm implements OnInit {
    AnemiaPregnancyFollow: TTVisual.ITTCheckBox;
    BabySizeFetusFollow: TTVisual.ITTTextBoxColumn;
    BabyWeightFetusFollow: TTVisual.ITTTextBoxColumn;
    CandidaInfertility: TTVisual.ITTTextBox;
    CervixGynecology: TTVisual.ITTTextBox;
    ComplicationPregnancyComplications: TTVisual.ITTListBoxColumn;
    ComplicationsDescriptionPregnancyComplications: TTVisual.ITTTextBoxColumn;
    CongenitalAnomalies: TTVisual.ITTObjectListBox;
    DangerDescriptionPregnancyDangerSign: TTVisual.ITTTextBoxColumn;
    DangerPregnancyDangerSign: TTVisual.ITTListBoxColumn;
    FetusFollow: TTVisual.ITTGrid;
    FKAFetusFollow: TTVisual.ITTTextBoxColumn;
    IronSupplements: TTVisual.ITTObjectListBox;
    labelCandidaInfertility: TTVisual.ITTLabel;
    labelCervixGynecology: TTVisual.ITTLabel;
    labelCongenitalAnomalies: TTVisual.ITTLabel;
    labelIronSupplements: TTVisual.ITTLabel;
    labelUrinaryProtein: TTVisual.ITTLabel;
    labelVitaminDSupplements: TTVisual.ITTLabel;
    labelWhichPregnancyFollow: TTVisual.ITTLabel;
    labelWomansHealthOperations: TTVisual.ITTLabel;
    ObligedRiskFactors: TTVisual.ITTGrid;
    PregnancyComplications: TTVisual.ITTGrid;
    PregnancyDangerSign: TTVisual.ITTGrid;
    RiskFactorDescriptionObligedRiskFactors: TTVisual.ITTTextBoxColumn;
    RiskFactorsObligedRiskFactors: TTVisual.ITTListBoxColumn;
    UrinaryProtein: TTVisual.ITTObjectListBox;
    VitaminDSupplements: TTVisual.ITTObjectListBox;
    WhichPregnancyFollow: TTVisual.ITTObjectListBox;
    WomansHealthOperations: TTVisual.ITTObjectListBox;
    public FetusFollowColumns = [];
    public ObligedRiskFactorsColumns = [];
    public PregnancyComplicationsColumns = [];
    public PregnancyDangerSignColumns = [];
    public oldWomanSpecialityFormViewModel: OldWomanSpecialityFormViewModel = new OldWomanSpecialityFormViewModel();
    public get _WomanSpecialityObject(): WomanSpecialityObject {
        return this._TTObject as WomanSpecialityObject;
    }
    private OldWomanSpecialityForm_DocumentUrl: string = '/api/WomanSpecialityObjectService/OldWomanSpecialityForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('WOMANSPECIALITYOBJECT', 'OldWomanSpecialityForm');
        this._DocumentServiceUrl = this.OldWomanSpecialityForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public MarriageDuration: number;

    private static async GetMarriageDuration(yearOfMarriage: number): Promise<number> {
        let x = new Date().getFullYear();
        let marriageDuration: number = Convert.ToInt32(new Date().getFullYear()) - yearOfMarriage;
        return marriageDuration;
    }

    protected async PreScript() {
        super.PreScript();
        //Evlilik Senesi
        if (this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.MarriageDate && this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.MarriageDate.toString().length == 4) {
            OldWomanSpecialityForm.GetMarriageDuration(Convert.ToInt32(this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.MarriageDate)).then(c => {
                this.MarriageDuration = c;
            });
        }
        else {
            this.MarriageDuration = null;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new WomanSpecialityObject();
        this.oldWomanSpecialityFormViewModel = new OldWomanSpecialityFormViewModel();
        this._ViewModel = this.oldWomanSpecialityFormViewModel;
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject = this._TTObject as WomanSpecialityObject;
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow = new PregnancyFollow();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow.PregnancyComplications = new Array<PregnancyComplications>();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow.ObligedRiskFactors = new Array<ObligedRiskFactors>();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow.PregnancyDangerSign = new Array<PregnancyDangerSign>();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow.FetusFollow = new Array<FetusFollow>();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow.WhichPregnancyFollow = new SKRSKacinciGebeIzlem();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow.WomansHealthOperations = new SKRSKadinSagligiIslemleri();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow.CongenitalAnomalies = new SKRSKonjenitalAnomaliliDogumVarligi();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow.UrinaryProtein = new SKRSIdrardaProtein();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow.VitaminDSupplements = new SKRSDVitaminiLojistigiveDestegi();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow.IronSupplements = new SKRSDemirLojistigiveDestegi();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.Infertility = new Infertility();
        this.oldWomanSpecialityFormViewModel._WomanSpecialityObject.Gynecology = new Gynecology();
    }

    protected loadViewModel() {
        let that = this;

        that.oldWomanSpecialityFormViewModel = this._ViewModel as OldWomanSpecialityFormViewModel;
        that._TTObject = this.oldWomanSpecialityFormViewModel._WomanSpecialityObject;
        if (this.oldWomanSpecialityFormViewModel == null)
            this.oldWomanSpecialityFormViewModel = new OldWomanSpecialityFormViewModel();
        if (this.oldWomanSpecialityFormViewModel._WomanSpecialityObject == null)
            this.oldWomanSpecialityFormViewModel._WomanSpecialityObject = new WomanSpecialityObject();
        let pregnancyFollowObjectID = that.oldWomanSpecialityFormViewModel._WomanSpecialityObject["PregnancyFollow"];
        if (pregnancyFollowObjectID != null && (typeof pregnancyFollowObjectID === "string")) {
            let pregnancyFollow = that.oldWomanSpecialityFormViewModel.PregnancyFollows.find(o => o.ObjectID.toString() === pregnancyFollowObjectID.toString());
             if (pregnancyFollow) {
                that.oldWomanSpecialityFormViewModel._WomanSpecialityObject.PregnancyFollow = pregnancyFollow;
            }
            if (pregnancyFollow != null) {
                pregnancyFollow.PregnancyComplications = that.oldWomanSpecialityFormViewModel.PregnancyComplicationsGridList;
                for (let detailItem of that.oldWomanSpecialityFormViewModel.PregnancyComplicationsGridList) {
                    let complicationObjectID = detailItem["Complication"];
                    if (complicationObjectID != null && (typeof complicationObjectID === "string")) {
                        let complication = that.oldWomanSpecialityFormViewModel.SKRSGebelikteRiskFaktorleris.find(o => o.ObjectID.toString() === complicationObjectID.toString());
                         if (complication) {
                            detailItem.Complication = complication;
                        }
                    }
                }
            }
            if (pregnancyFollow != null) {
                pregnancyFollow.ObligedRiskFactors = that.oldWomanSpecialityFormViewModel.ObligedRiskFactorsGridList;
                for (let detailItem of that.oldWomanSpecialityFormViewModel.ObligedRiskFactorsGridList) {
                    let riskFactorsObjectID = detailItem["RiskFactors"];
                    if (riskFactorsObjectID != null && (typeof riskFactorsObjectID === "string")) {
                        let riskFactors = that.oldWomanSpecialityFormViewModel.SKRSGebelikBildirimiZorunluRiskFaktorleris.find(o => o.ObjectID.toString() === riskFactorsObjectID.toString());
                         if (riskFactors) {
                            detailItem.RiskFactors = riskFactors;
                        }
                    }
                }
            }
            if (pregnancyFollow != null) {
                pregnancyFollow.PregnancyDangerSign = that.oldWomanSpecialityFormViewModel.PregnancyDangerSignGridList;
                for (let detailItem of that.oldWomanSpecialityFormViewModel.PregnancyDangerSignGridList) {
                    let dangerObjectID = detailItem["Danger"];
                    if (dangerObjectID != null && (typeof dangerObjectID === "string")) {
                        let danger = that.oldWomanSpecialityFormViewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis.find(o => o.ObjectID.toString() === dangerObjectID.toString());
                         if (danger) {
                            detailItem.Danger = danger;
                        }
                    }
                }
            }
            if (pregnancyFollow != null) {
                pregnancyFollow.FetusFollow = that.oldWomanSpecialityFormViewModel.FetusFollowGridList;
                for (let detailItem of that.oldWomanSpecialityFormViewModel.FetusFollowGridList) {
                }
            }
            if (pregnancyFollow != null) {
                let whichPregnancyFollowObjectID = pregnancyFollow["WhichPregnancyFollow"];
                if (whichPregnancyFollowObjectID != null && (typeof whichPregnancyFollowObjectID === "string")) {
                    let whichPregnancyFollow = that.oldWomanSpecialityFormViewModel.SKRSKacinciGebeIzlems.find(o => o.ObjectID.toString() === whichPregnancyFollowObjectID.toString());
                     if (whichPregnancyFollow) {
                        pregnancyFollow.WhichPregnancyFollow = whichPregnancyFollow;
                    }
                }
            }
            if (pregnancyFollow != null) {
                let womansHealthOperationsObjectID = pregnancyFollow["WomansHealthOperations"];
                if (womansHealthOperationsObjectID != null && (typeof womansHealthOperationsObjectID === "string")) {
                    let womansHealthOperations = that.oldWomanSpecialityFormViewModel.SKRSKadinSagligiIslemleris.find(o => o.ObjectID.toString() === womansHealthOperationsObjectID.toString());
                     if (womansHealthOperations) {
                        pregnancyFollow.WomansHealthOperations = womansHealthOperations;
                    }
                }
            }
            if (pregnancyFollow != null) {
                let congenitalAnomaliesObjectID = pregnancyFollow["CongenitalAnomalies"];
                if (congenitalAnomaliesObjectID != null && (typeof congenitalAnomaliesObjectID === "string")) {
                    let congenitalAnomalies = that.oldWomanSpecialityFormViewModel.SKRSKonjenitalAnomaliliDogumVarligis.find(o => o.ObjectID.toString() === congenitalAnomaliesObjectID.toString());
                     if (congenitalAnomalies) {
                        pregnancyFollow.CongenitalAnomalies = congenitalAnomalies;
                    }
                }
            }
            if (pregnancyFollow != null) {
                let urinaryProteinObjectID = pregnancyFollow["UrinaryProtein"];
                if (urinaryProteinObjectID != null && (typeof urinaryProteinObjectID === "string")) {
                    let urinaryProtein = that.oldWomanSpecialityFormViewModel.SKRSIdrardaProteins.find(o => o.ObjectID.toString() === urinaryProteinObjectID.toString());
                     if (urinaryProtein) {
                        pregnancyFollow.UrinaryProtein = urinaryProtein;
                    }
                }
            }
            if (pregnancyFollow != null) {
                let vitaminDSupplementsObjectID = pregnancyFollow["VitaminDSupplements"];
                if (vitaminDSupplementsObjectID != null && (typeof vitaminDSupplementsObjectID === "string")) {
                    let vitaminDSupplements = that.oldWomanSpecialityFormViewModel.SKRSDVitaminiLojistigiveDestegis.find(o => o.ObjectID.toString() === vitaminDSupplementsObjectID.toString());
                     if (vitaminDSupplements) {
                        pregnancyFollow.VitaminDSupplements = vitaminDSupplements;
                    }
                }
            }
            if (pregnancyFollow != null) {
                let ironSupplementsObjectID = pregnancyFollow["IronSupplements"];
                if (ironSupplementsObjectID != null && (typeof ironSupplementsObjectID === "string")) {
                    let ironSupplements = that.oldWomanSpecialityFormViewModel.SKRSDemirLojistigiveDestegis.find(o => o.ObjectID.toString() === ironSupplementsObjectID.toString());
                     if (ironSupplements) {
                        pregnancyFollow.IronSupplements = ironSupplements;
                    }
                }
            }
        }
        let infertilityObjectID = that.oldWomanSpecialityFormViewModel._WomanSpecialityObject["Infertility"];
        if (infertilityObjectID != null && (typeof infertilityObjectID === "string")) {
            let infertility = that.oldWomanSpecialityFormViewModel.Infertilitys.find(o => o.ObjectID.toString() === infertilityObjectID.toString());
             if (infertility) {
                that.oldWomanSpecialityFormViewModel._WomanSpecialityObject.Infertility = infertility;
            }
        }
        let gynecologyObjectID = that.oldWomanSpecialityFormViewModel._WomanSpecialityObject["Gynecology"];
        if (gynecologyObjectID != null && (typeof gynecologyObjectID === "string")) {
            let gynecology = that.oldWomanSpecialityFormViewModel.Gynecologys.find(o => o.ObjectID.toString() === gynecologyObjectID.toString());
             if (gynecology) {
                that.oldWomanSpecialityFormViewModel._WomanSpecialityObject.Gynecology = gynecology;
            }
        }

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OldWomanSpecialityFormViewModel);

    }


    public onAnemiaPregnancyFollowChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.PregnancyFollow != null && this._WomanSpecialityObject.PregnancyFollow.Anemia != event) {
                this._WomanSpecialityObject.PregnancyFollow.Anemia = event;
            }
        }
    }

    public onCandidaInfertilityChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Infertility != null && this._WomanSpecialityObject.Infertility.Candida != event) {
                this._WomanSpecialityObject.Infertility.Candida = event;
            }
        }
    }

    public onCervixGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.Cervix != event) {
                this._WomanSpecialityObject.Gynecology.Cervix = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.CandidaInfertility, "Text", this.__ttObject, "Infertility.Candida");
        redirectProperty(this.CervixGynecology, "Text", this.__ttObject, "Gynecology.Cervix");
        redirectProperty(this.AnemiaPregnancyFollow, "Value", this.__ttObject, "PregnancyFollow.Anemia");
    }

    public initFormControls(): void {
        this.AnemiaPregnancyFollow = new TTVisual.TTCheckBox();
        this.AnemiaPregnancyFollow.Value = false;
        this.AnemiaPregnancyFollow.Text = i18n("M10957", "Anemi");
        this.AnemiaPregnancyFollow.Name = "AnemiaPregnancyFollow";
        this.AnemiaPregnancyFollow.TabIndex = 4;

        this.labelCandidaInfertility = new TTVisual.TTLabel();
        this.labelCandidaInfertility.Text = "Candida";
        this.labelCandidaInfertility.Name = "labelCandidaInfertility";
        this.labelCandidaInfertility.TabIndex = 3;

        this.CandidaInfertility = new TTVisual.TTTextBox();
        this.CandidaInfertility.Name = "CandidaInfertility";
        this.CandidaInfertility.TabIndex = 2;

        this.labelCervixGynecology = new TTVisual.TTLabel();
        this.labelCervixGynecology.Text = i18n("M21661", "Serviks");
        this.labelCervixGynecology.Name = "labelCervixGynecology";
        this.labelCervixGynecology.TabIndex = 1;

        this.CervixGynecology = new TTVisual.TTTextBox();
        this.CervixGynecology.Name = "CervixGynecology";
        this.CervixGynecology.TabIndex = 0;

        this.Controls = [this.AnemiaPregnancyFollow, this.labelCandidaInfertility, this.CandidaInfertility, this.labelCervixGynecology, this.CervixGynecology];

    }


}