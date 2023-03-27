//$2C5285B0
import { Component, OnInit, Output, EventEmitter, Input, NgZone } from '@angular/core';
import { PregnancyFollowFormViewModel, PregnancyFollowGrid } from './PregnancyFollowFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import { plainToClass } from 'NebulaClient/ClassTransformer';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { PregnancyFollow, SKRSGestasyonelDiyabetTaramasi } from 'NebulaClient/Model/AtlasClientModel';

import { FetusFollow } from 'NebulaClient/Model/AtlasClientModel';
import { ObligedRiskFactors } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyComplications } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyDangerSign } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDemirLojistigiveDestegi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDVitaminiLojistigiveDestegi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIdrardaProtein } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKacinciGebeIzlem } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKadinSagligiIslemleri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKonjenitalAnomaliliDogumVarligi } from 'NebulaClient/Model/AtlasClientModel';


import { SystemApiService } from 'Fw/Services/SystemApiService';



import { WomanSpecialityObject } from 'NebulaClient/Model/AtlasClientModel';
import { CommonService } from "ObjectClassService/CommonService";
import { WomanSpecialityObjectInfo } from './WomanSpecialityFormViewModel';
import { GebelikIzlem } from '../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel';

@Component({
    selector: 'PregnancyFollowForm',
    templateUrl: './PregnancyFollowForm.html',
    providers: [SystemApiService, MessageService]
})
export class PregnancyFollowForm extends TTVisual.TTForm implements OnInit {
    AbdominalCircumferenceFetusGrowingDefinition: TTVisual.ITTTextBox;
    Anemia: TTVisual.ITTCheckBox;
    BabySizeFetusFollow: TTVisual.ITTTextBoxColumn;
    BabyWeightFetusFollow: TTVisual.ITTTextBoxColumn;
    BiparietalDiameterFetusGrowingDefinition: TTVisual.ITTTextBox;
    Bleeding: TTVisual.ITTCheckBox;
    CardiovascularDiseases: TTVisual.ITTCheckBox;
    Complaints: TTVisual.ITTTextBox;
    ComplicationPregnancyComplications: TTVisual.ITTListBoxColumn;
    ComplicationsDescriptionPregnancyComplications: TTVisual.ITTTextBoxColumn;
    CongenitalAnomalies: TTVisual.ITTObjectListBox;
    DangerDescriptionPregnancyDangerSign: TTVisual.ITTTextBoxColumn;
    DangerPregnancyDangerSign: TTVisual.ITTListBoxColumn;
    FemurLengthFetusGrowingDefinition: TTVisual.ITTTextBox;
    FetusFollow: TTVisual.ITTGrid;
    FKAFetusFollow: TTVisual.ITTTextBoxColumn;
    GestationalDiabetes: TTVisual.ITTCheckBox;
    HeadCircumferenceFetusGrowingDefinition: TTVisual.ITTTextBox;
    Hemoglobin: TTVisual.ITTTextBox;
    InformerName: TTVisual.ITTTextBox;
    InformerPhone: TTVisual.ITTMaskedTextBox;
    IronSupplements: TTVisual.ITTObjectListBox;
    labelAbdominalCircumferenceFetusGrowingDefinition: TTVisual.ITTLabel;
    labelBiparietalDiameterFetusGrowingDefinition: TTVisual.ITTLabel;
    labelComplaints: TTVisual.ITTLabel;
    labelCongenitalAnomalies: TTVisual.ITTLabel;
    labelFemurLengthFetusGrowingDefinition: TTVisual.ITTLabel;
    labelHeadCircumferenceFetusGrowingDefinition: TTVisual.ITTLabel;
    labelHemoglobin: TTVisual.ITTLabel;
    labelInformerName: TTVisual.ITTLabel;
    labelInformerPhone: TTVisual.ITTLabel;
    labelIronSupplements: TTVisual.ITTLabel;
    labelLengthFetusGrowingDefinition: TTVisual.ITTLabel;
    labelMotherWeight: TTVisual.ITTLabel;
    labelOpenness: TTVisual.ITTLabel;
    labelPelvicCondition: TTVisual.ITTLabel;
    labelPregnancyDiseasesDescription: TTVisual.ITTLabel;
    labelPregnancyWeekFetusGrowingDefinition: TTVisual.ITTLabel;
    labelPretibialEdema: TTVisual.ITTLabel;
    labelRiskFactors: TTVisual.ITTLabel;
    labelSkrsGestationalDiabetes: TTVisual.ITTLabel;
    labelUltrasonicFinding: TTVisual.ITTLabel;
    labelUrinaryProtein: TTVisual.ITTLabel;
    labelVaricose: TTVisual.ITTLabel;
    labelVitaminDSupplements: TTVisual.ITTLabel;
    labelWeightFetusGrowingDefinition: TTVisual.ITTLabel;
    labelWhichPregnancyFollow: TTVisual.ITTLabel;
    labelWomansHealthOperations: TTVisual.ITTLabel;
    LengthFetusGrowingDefinition: TTVisual.ITTTextBox;
    MotherWeight: TTVisual.ITTTextBox;
    Nausea: TTVisual.ITTCheckBox;
    ObligedRiskFactors: TTVisual.ITTGrid;
    Openness: TTVisual.ITTTextBox;
    PelvicCondition: TTVisual.ITTTextBox;
    PregnancyComplications: TTVisual.ITTGrid;
    PregnancyDangerSign: TTVisual.ITTGrid;
    PregnancyDiseasesDescription: TTVisual.ITTTextBox;
    PregnancyWeekFetusGrowingDefinition: TTVisual.ITTTextBox;
    PretibialEdema: TTVisual.ITTTextBox;
    RiskFactorDescriptionObligedRiskFactors: TTVisual.ITTTextBoxColumn;
    RiskFactorsObligedRiskFactors: TTVisual.ITTListBoxColumn;
    SkrsGestationalDiabetes: TTVisual.ITTObjectListBox;
    Tension: TTVisual.ITTCheckBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttgroupbox3: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    UltrasonicFinding: TTVisual.ITTTextBox;
    UrinaryProtein: TTVisual.ITTObjectListBox;
    Varicose: TTVisual.ITTTextBox;
    VitaminDSupplements: TTVisual.ITTObjectListBox;
    WeightFetusGrowingDefinition: TTVisual.ITTTextBox;
    WhichPregnancyFollow: TTVisual.ITTObjectListBox;
    WomansHealthOperations: TTVisual.ITTObjectListBox;
    public FetusFollowColumns = [];
    public ObligedRiskFactorsColumns = [];
    public PregnancyComplicationsColumns = [];
    public PregnancyDangerSignColumns = [];
    public showGebelikIzlem:boolean=false;
    public _gebelikIzlemList :Array<GebelikIzlem> =new Array<GebelikIzlem>();
    public pregnancyFollowFormViewModel: PregnancyFollowFormViewModel = new PregnancyFollowFormViewModel();
    public get _PregnancyFollow(): PregnancyFollow {
        return this._TTObject as PregnancyFollow;
    }
    private PregnancyFollowForm_DocumentUrl: string = '/api/PregnancyFollowService/PregnancyFollowForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        public systemApiService: SystemApiService,
        protected ngZone: NgZone) {
        super('PREGNANCYFOLLOW', 'PregnancyFollowForm');
        this._DocumentServiceUrl = this.PregnancyFollowForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    private editorConfig: any = {
        height: '90px',
        removePlugins: 'toolbar'
    };

    @Output() sendViewModelToParent: EventEmitter<PregnancyFollowFormViewModel> = new EventEmitter<PregnancyFollowFormViewModel>();
    @Input() set womanSpecialityObjectInfo(value: WomanSpecialityObjectInfo) {
        if (value != null) {
            if (value.WomanSpecialityObject != null && value.WomanSpecialityObject.PregnancyFollow != null) {
                if (typeof value.WomanSpecialityObject.PregnancyFollow == "string") {
                    this.ObjectID = value.WomanSpecialityObject.PregnancyFollow;
                } else {
                    this.ObjectID = value.WomanSpecialityObject.PregnancyFollow.ObjectID;
                }
            }
            if (value.ActiveIDsModel != null) {
                this.ActiveIDsModel = value.ActiveIDsModel;
            }
        }
    }

    // ***** Method declarations start *****

    private async GetPregnancyWeek(lastMenstrualPeriod: Date): Promise<number> {
        let currentDate: Date = await (CommonService.RecTime());
        currentDate = plainToClass(Date, currentDate);

        let weeks: number = Math.floor((currentDate.valueOf() - lastMenstrualPeriod.valueOf() + 1) / (1000 * 60 * 60 * 24) / 7);

        return Convert.ToInt32(weeks);
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        if (this._PregnancyFollow.Pregnancy != null && this.pregnancyFollowFormViewModel.LastMenstrualPeriod != null) {
            let pregnancWeek = await this.GetPregnancyWeek(Convert.ToDateTime(this.pregnancyFollowFormViewModel.LastMenstrualPeriod));
            this.PregnancyWeekFetusGrowingDefinition.Text = pregnancWeek.toString();
        }
    }

    showPregnancyFollowDeatil: boolean = false;
    showOldPregnancyFollowGridList: boolean = true;

    GetPregnancyFollowDeatil(value: any) {
        this.showPregnancyFollowDeatil = true;
        let _data: PregnancyFollowGrid = value as PregnancyFollowGrid;
        this.openDynamicComponent(_data.Defname, _data.ObjectId, "e63d630a-03f9-4d37-9a77-9c9e54e2f0e7", false);
    }

    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam);
        }
        else {
            this.showPregnancyFollowDeatil = false;
        }
    }


    //IInputParam inputları dinamiccomponentla set etmek için
    setInputParam(value: Object) {
        if (typeof value === "boolean") {
            this.showOldPregnancyFollowGridList = value; //Dinamik Component olarak açılmışsa eski gebe izlemler görünmemeli
        }
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PregnancyFollow();
        this.pregnancyFollowFormViewModel = new PregnancyFollowFormViewModel();
        this._ViewModel = this.pregnancyFollowFormViewModel;
        this.pregnancyFollowFormViewModel._PregnancyFollow = this._TTObject as PregnancyFollow;
	this.pregnancyFollowFormViewModel._PregnancyFollow.SkrsGestationalDiabetes = new SKRSGestasyonelDiyabetTaramasi();
        this.pregnancyFollowFormViewModel._PregnancyFollow.WomansHealthOperations = new SKRSKadinSagligiIslemleri();
        this.pregnancyFollowFormViewModel._PregnancyFollow.CongenitalAnomalies = new SKRSKonjenitalAnomaliliDogumVarligi();
        this.pregnancyFollowFormViewModel._PregnancyFollow.UrinaryProtein = new SKRSIdrardaProtein();
        this.pregnancyFollowFormViewModel._PregnancyFollow.FetusFollow = new Array<FetusFollow>();
        this.pregnancyFollowFormViewModel._PregnancyFollow.PregnancyDangerSign = new Array<PregnancyDangerSign>();
        this.pregnancyFollowFormViewModel._PregnancyFollow.ObligedRiskFactors = new Array<ObligedRiskFactors>();
        this.pregnancyFollowFormViewModel._PregnancyFollow.PregnancyComplications = new Array<PregnancyComplications>();
        this.pregnancyFollowFormViewModel._PregnancyFollow.VitaminDSupplements = new SKRSDVitaminiLojistigiveDestegi();
        this.pregnancyFollowFormViewModel._PregnancyFollow.IronSupplements = new SKRSDemirLojistigiveDestegi();
        this.pregnancyFollowFormViewModel._PregnancyFollow.WhichPregnancyFollow = new SKRSKacinciGebeIzlem();
    }

    protected loadViewModel() {
        let that = this;

        that.pregnancyFollowFormViewModel = this._ViewModel as PregnancyFollowFormViewModel;
        that._TTObject = this.pregnancyFollowFormViewModel._PregnancyFollow;
        if (this.pregnancyFollowFormViewModel == null)
            this.pregnancyFollowFormViewModel = new PregnancyFollowFormViewModel();
        if (this.pregnancyFollowFormViewModel._PregnancyFollow == null)
            this.pregnancyFollowFormViewModel._PregnancyFollow = new PregnancyFollow();
        let skrsGestationalDiabetesObjectID = that.pregnancyFollowFormViewModel._PregnancyFollow["SkrsGestationalDiabetes"];
        if (skrsGestationalDiabetesObjectID != null && (typeof skrsGestationalDiabetesObjectID === "string")) {
            let skrsGestationalDiabetes = that.pregnancyFollowFormViewModel.SKRSGestasyonelDiyabetTaramasis.find(o => o.ObjectID.toString() === skrsGestationalDiabetesObjectID.toString());
            if (skrsGestationalDiabetes) {
                that.pregnancyFollowFormViewModel._PregnancyFollow.SkrsGestationalDiabetes = skrsGestationalDiabetes;
            }
        }
        let womansHealthOperationsObjectID = that.pregnancyFollowFormViewModel._PregnancyFollow["WomansHealthOperations"];
        if (womansHealthOperationsObjectID != null && (typeof womansHealthOperationsObjectID === "string")) {
            let womansHealthOperations = that.pregnancyFollowFormViewModel.SKRSKadinSagligiIslemleris.find(o => o.ObjectID.toString() === womansHealthOperationsObjectID.toString());
            if (womansHealthOperations) {
                that.pregnancyFollowFormViewModel._PregnancyFollow.WomansHealthOperations = womansHealthOperations;
            }
        }
        let congenitalAnomaliesObjectID = that.pregnancyFollowFormViewModel._PregnancyFollow["CongenitalAnomalies"];
        if (congenitalAnomaliesObjectID != null && (typeof congenitalAnomaliesObjectID === "string")) {
            let congenitalAnomalies = that.pregnancyFollowFormViewModel.SKRSKonjenitalAnomaliliDogumVarligis.find(o => o.ObjectID.toString() === congenitalAnomaliesObjectID.toString());
            if (congenitalAnomalies) {
                that.pregnancyFollowFormViewModel._PregnancyFollow.CongenitalAnomalies = congenitalAnomalies;
            }
        }
        let urinaryProteinObjectID = that.pregnancyFollowFormViewModel._PregnancyFollow["UrinaryProtein"];
        if (urinaryProteinObjectID != null && (typeof urinaryProteinObjectID === "string")) {
            let urinaryProtein = that.pregnancyFollowFormViewModel.SKRSIdrardaProteins.find(o => o.ObjectID.toString() === urinaryProteinObjectID.toString());
            if (urinaryProtein) {
                that.pregnancyFollowFormViewModel._PregnancyFollow.UrinaryProtein = urinaryProtein;
            }
        }
        that.pregnancyFollowFormViewModel._PregnancyFollow.FetusFollow = that.pregnancyFollowFormViewModel.FetusFollowGridList;
        for (let detailItem of that.pregnancyFollowFormViewModel.FetusFollowGridList) {
        }
        that.pregnancyFollowFormViewModel._PregnancyFollow.PregnancyDangerSign = that.pregnancyFollowFormViewModel.PregnancyDangerSignGridList;
        for (let detailItem of that.pregnancyFollowFormViewModel.PregnancyDangerSignGridList) {
            let dangerObjectID = detailItem["Danger"];
            if (dangerObjectID != null && (typeof dangerObjectID === "string")) {
                let danger = that.pregnancyFollowFormViewModel.SKRSGebelikLohusalikSeyrindeTehlikeIsaretis.find(o => o.ObjectID.toString() === dangerObjectID.toString());
                if (danger) {
                    detailItem.Danger = danger;
                }
            }
        }
        that.pregnancyFollowFormViewModel._PregnancyFollow.ObligedRiskFactors = that.pregnancyFollowFormViewModel.ObligedRiskFactorsGridList;
        for (let detailItem of that.pregnancyFollowFormViewModel.ObligedRiskFactorsGridList) {
            let riskFactorsObjectID = detailItem["RiskFactors"];
            if (riskFactorsObjectID != null && (typeof riskFactorsObjectID === "string")) {
                let riskFactors = that.pregnancyFollowFormViewModel.SKRSGebelikBildirimiZorunluRiskFaktorleris.find(o => o.ObjectID.toString() === riskFactorsObjectID.toString());
                if (riskFactors) {
                    detailItem.RiskFactors = riskFactors;
                }
            }
        }
        that.pregnancyFollowFormViewModel._PregnancyFollow.PregnancyComplications = that.pregnancyFollowFormViewModel.PregnancyComplicationsGridList;
        for (let detailItem of that.pregnancyFollowFormViewModel.PregnancyComplicationsGridList) {
            let complicationObjectID = detailItem["Complication"];
            if (complicationObjectID != null && (typeof complicationObjectID === "string")) {
                let complication = that.pregnancyFollowFormViewModel.SKRSGebelikteRiskFaktorleris.find(o => o.ObjectID.toString() === complicationObjectID.toString());
                if (complication) {
                    detailItem.Complication = complication;
                }
            }
        }
        let vitaminDSupplementsObjectID = that.pregnancyFollowFormViewModel._PregnancyFollow["VitaminDSupplements"];
        if (vitaminDSupplementsObjectID != null && (typeof vitaminDSupplementsObjectID === "string")) {
            let vitaminDSupplements = that.pregnancyFollowFormViewModel.SKRSDVitaminiLojistigiveDestegis.find(o => o.ObjectID.toString() === vitaminDSupplementsObjectID.toString());
            if (vitaminDSupplements) {
                that.pregnancyFollowFormViewModel._PregnancyFollow.VitaminDSupplements = vitaminDSupplements;
            }
        }
        let ironSupplementsObjectID = that.pregnancyFollowFormViewModel._PregnancyFollow["IronSupplements"];
        if (ironSupplementsObjectID != null && (typeof ironSupplementsObjectID === "string")) {
            let ironSupplements = that.pregnancyFollowFormViewModel.SKRSDemirLojistigiveDestegis.find(o => o.ObjectID.toString() === ironSupplementsObjectID.toString());
            if (ironSupplements) {
                that.pregnancyFollowFormViewModel._PregnancyFollow.IronSupplements = ironSupplements;
            }
        }
        let whichPregnancyFollowObjectID = that.pregnancyFollowFormViewModel._PregnancyFollow["WhichPregnancyFollow"];
        if (whichPregnancyFollowObjectID != null && (typeof whichPregnancyFollowObjectID === "string")) {
            let whichPregnancyFollow = that.pregnancyFollowFormViewModel.SKRSKacinciGebeIzlems.find(o => o.ObjectID.toString() === whichPregnancyFollowObjectID.toString());
            if (whichPregnancyFollow) {
                that.pregnancyFollowFormViewModel._PregnancyFollow.WhichPregnancyFollow = whichPregnancyFollow;
            }
        }
        this.sendViewModelToParent.emit(that.pregnancyFollowFormViewModel);
    }

    async ngOnInit() {
        let that = this;
        await this.load(PregnancyFollowFormViewModel);

    }


    public onAnemiaChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.Anemia != event) {
                this._PregnancyFollow.Anemia = event;
            }
        }
    }

    public onBleedingChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.Bleeding != event) {
                this._PregnancyFollow.Bleeding = event;
            }
        }
    }

    public onCardiovascularDiseasesChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.CardiovascularDiseases != event) {
                this._PregnancyFollow.CardiovascularDiseases = event;
            }
        }
    }

    public onComplaintsChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.Complaints != event) {
                this._PregnancyFollow.Complaints = event;
            }
        }
    }

    public onCongenitalAnomaliesChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.CongenitalAnomalies != event) {
                this._PregnancyFollow.CongenitalAnomalies = event;
            }
        }
    }

    public onGestationalDiabetesChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.GestationalDiabetes != event) {
                this._PregnancyFollow.GestationalDiabetes = event;
            }
        }
    }

    public onHemoglobinChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.Hemoglobin != event) {
                this._PregnancyFollow.Hemoglobin = event;
            }
        }
    }

public onInformerNameChanged(event): void {
    if(this._PregnancyFollow != null && this._PregnancyFollow.InformerName != event) { 
    this._PregnancyFollow.InformerName = event;
}
}

public onInformerPhoneChanged(event): void {
    if(this._PregnancyFollow != null && this._PregnancyFollow.InformerPhone != event) { 
    this._PregnancyFollow.InformerPhone = event;
}
}
    public onIronSupplementsChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.IronSupplements != event) {
                this._PregnancyFollow.IronSupplements = event;
            }
        }
    }

    public onMotherWeightChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.MotherWeight != event) {
                this._PregnancyFollow.MotherWeight = event;
            }
        }
    }

    public onNauseaChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.Nausea != event) {
                this._PregnancyFollow.Nausea = event;
            }
        }
    }

    public onOpennessChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.Openness != event) {
                this._PregnancyFollow.Openness = event;
            }
        }
    }

    public onPelvicConditionChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.PelvicCondition != event) {
                this._PregnancyFollow.PelvicCondition = event;
            }
        }
    }

    public onPregnancyDiseasesDescriptionChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.PregnancyDiseasesDescription != event) {
                this._PregnancyFollow.PregnancyDiseasesDescription = event;
            }
        }
    }

    public onPretibialEdemaChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.PretibialEdema != event) {
                this._PregnancyFollow.PretibialEdema = event;
            }
        }
    }
    
    public onSkrsGestationalDiabetesChanged(event): void {
    if(this._PregnancyFollow != null && this._PregnancyFollow.SkrsGestationalDiabetes != event) { 
    this._PregnancyFollow.SkrsGestationalDiabetes = event;
}
}

    public onTensionChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.Tension != event) {
                this._PregnancyFollow.Tension = event;
            }
        }
    }

    public onUltrasonicFindingChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.UltrasonicFinding != event) {
                this._PregnancyFollow.UltrasonicFinding = event;
            }
        }
    }

    public onUrinaryProteinChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.UrinaryProtein != event) {
                this._PregnancyFollow.UrinaryProtein = event;
            }
        }
    }

    public onVaricoseChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.Varicose != event) {
                this._PregnancyFollow.Varicose = event;
            }
        }
    }

    public onVitaminDSupplementsChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.VitaminDSupplements != event) {
                this._PregnancyFollow.VitaminDSupplements = event;
            }
        }
    }

    public onWhichPregnancyFollowChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.WhichPregnancyFollow != event) {
                this._PregnancyFollow.WhichPregnancyFollow = event;
            }
        }
    }

    public onWomansHealthOperationsChanged(event): void {
        if (event != null) {
            if (this._PregnancyFollow != null && this._PregnancyFollow.WomansHealthOperations != event) {
                this._PregnancyFollow.WomansHealthOperations = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.Tension, "Value", this.__ttObject, "Tension");
        redirectProperty(this.GestationalDiabetes, "Value", this.__ttObject, "GestationalDiabetes");
        redirectProperty(this.CardiovascularDiseases, "Value", this.__ttObject, "CardiovascularDiseases");
        redirectProperty(this.Anemia, "Value", this.__ttObject, "Anemia");
        redirectProperty(this.Nausea, "Value", this.__ttObject, "Nausea");
        redirectProperty(this.Bleeding, "Value", this.__ttObject, "Bleeding");
        redirectProperty(this.PregnancyDiseasesDescription, "Text", this.__ttObject, "PregnancyDiseasesDescription");
        redirectProperty(this.MotherWeight, "Text", this.__ttObject, "MotherWeight");
        redirectProperty(this.Hemoglobin, "Text", this.__ttObject, "Hemoglobin");
    redirectProperty(this.InformerName, "Text", this.__ttObject, "InformerName");
    redirectProperty(this.InformerPhone, "Text", this.__ttObject, "InformerPhone");
        redirectProperty(this.PretibialEdema, "Text", this.__ttObject, "PretibialEdema");
        redirectProperty(this.Openness, "Text", this.__ttObject, "Openness");
        redirectProperty(this.Varicose, "Text", this.__ttObject, "Varicose");
        redirectProperty(this.PelvicCondition, "Text", this.__ttObject, "PelvicCondition");
        redirectProperty(this.UltrasonicFinding, "Text", this.__ttObject, "UltrasonicFinding");
        redirectProperty(this.Complaints, "Text", this.__ttObject, "Complaints");
    }

    public initFormControls(): void {
        this.labelInformerPhone = new TTVisual.TTLabel();
        this.labelInformerPhone.Text = "Bilgi Alınan Kişi Numarası";
        this.labelInformerPhone.Name = "labelInformerPhone";
        this.labelInformerPhone.TabIndex = 52;

        this.InformerPhone = new TTVisual.TTMaskedTextBox();
        this.InformerPhone.Mask = "000 0000000";
	    this.InformerPhone.Name = "InformerPhone";
	    this.InformerPhone.TabIndex = 51;

	    this.InformerName = new TTVisual.TTTextBox();
	    this.InformerName.Name = "InformerName";
	    this.InformerName.TabIndex = 49;
	    
        this.labelInformerName = new TTVisual.TTLabel();
        this.labelInformerName.Text = "Bilgi Alınan Kişi";
        this.labelInformerName.Name = "labelInformerName";
        this.labelInformerName.TabIndex = 50;

        this.labelSkrsGestationalDiabetes = new TTVisual.TTLabel();
        this.labelSkrsGestationalDiabetes.Text = "Gestasyonel Diyabet Taramasi";
        this.labelSkrsGestationalDiabetes.Name = "labelSkrsGestationalDiabetes";
        this.labelSkrsGestationalDiabetes.TabIndex = 48;

        this.SkrsGestationalDiabetes = new TTVisual.TTObjectListBox();
        this.SkrsGestationalDiabetes.ListDefName = "SKRSGestasyonelDiyabetTaramasiList";
        this.SkrsGestationalDiabetes.Name = "SkrsGestationalDiabetes";
        this.SkrsGestationalDiabetes.TabIndex = 47;	    
    
        this.labelWomansHealthOperations = new TTVisual.TTLabel();
        this.labelWomansHealthOperations.Text = i18n("M17064", "Kadın Sağlığı İşlemleri");
        this.labelWomansHealthOperations.Name = "labelWomansHealthOperations";
        this.labelWomansHealthOperations.TabIndex = 46;

        this.WomansHealthOperations = new TTVisual.TTObjectListBox();
        this.WomansHealthOperations.ListDefName = "SKRSKadinSagligiIslemleriList";
        this.WomansHealthOperations.Name = "WomansHealthOperations";
        this.WomansHealthOperations.TabIndex = 45;

        this.labelCongenitalAnomalies = new TTVisual.TTLabel();
        this.labelCongenitalAnomalies.Text = i18n("M17735", "Konjenital Anomalili Doğum Varlığı");
        this.labelCongenitalAnomalies.Name = "labelCongenitalAnomalies";
        this.labelCongenitalAnomalies.TabIndex = 44;

        this.CongenitalAnomalies = new TTVisual.TTObjectListBox();
        this.CongenitalAnomalies.ListDefName = "SKRSKonjenitalAnomaliliDogumVarligiList";
        this.CongenitalAnomalies.Name = "CongenitalAnomalies";
        this.CongenitalAnomalies.TabIndex = 43;

        this.labelUrinaryProtein = new TTVisual.TTLabel();
        this.labelUrinaryProtein.Text = i18n("M16195", "İdrarda Protein");
        this.labelUrinaryProtein.Name = "labelUrinaryProtein";
        this.labelUrinaryProtein.TabIndex = 42;

        this.UrinaryProtein = new TTVisual.TTObjectListBox();
        this.UrinaryProtein.ListDefName = "SKRSIdrardaProteinList";
        this.UrinaryProtein.Name = "UrinaryProtein";
        this.UrinaryProtein.TabIndex = 10;

        this.labelHemoglobin = new TTVisual.TTLabel();
        this.labelHemoglobin.Text = "Hemoglobin";
        this.labelHemoglobin.Name = "labelHemoglobin";
        this.labelHemoglobin.TabIndex = 40;

        this.Hemoglobin = new TTVisual.TTTextBox();
        this.Hemoglobin.Name = "Hemoglobin";
        this.Hemoglobin.TabIndex = 7;

        this.Varicose = new TTVisual.TTTextBox();
        this.Varicose.Name = "Varicose";
        this.Varicose.TabIndex = 13;

        this.UltrasonicFinding = new TTVisual.TTTextBox();
        this.UltrasonicFinding.Name = "UltrasonicFinding";
        this.UltrasonicFinding.TabIndex = 15;

        this.PretibialEdema = new TTVisual.TTTextBox();
        this.PretibialEdema.Name = "PretibialEdema";
        this.PretibialEdema.TabIndex = 11;

        this.PregnancyDiseasesDescription = new TTVisual.TTTextBox();
        this.PregnancyDiseasesDescription.Name = "PregnancyDiseasesDescription";
        this.PregnancyDiseasesDescription.TabIndex = 4;

        this.PelvicCondition = new TTVisual.TTTextBox();
        this.PelvicCondition.Name = "PelvicCondition";
        this.PelvicCondition.TabIndex = 14;

        this.Openness = new TTVisual.TTTextBox();
        this.Openness.Name = "Openness";
        this.Openness.TabIndex = 12;

        this.MotherWeight = new TTVisual.TTTextBox();
        this.MotherWeight.Name = "MotherWeight";
        this.MotherWeight.TabIndex = 5;

        this.Complaints = new TTVisual.TTTextBox();
        this.Complaints.Name = "Complaints";
        this.Complaints.TabIndex = 16;

        this.FetusFollow = new TTVisual.TTGrid();
        this.FetusFollow.Name = "FetusFollow";
        this.FetusFollow.TabIndex = 17;

        this.BabySizeFetusFollow = new TTVisual.TTTextBoxColumn();
        this.BabySizeFetusFollow.DataMember = "BabySize";
        this.BabySizeFetusFollow.DisplayIndex = 0;
        this.BabySizeFetusFollow.HeaderText = i18n("M11695", "Bebek Boyutu");
        this.BabySizeFetusFollow.Name = "BabySizeFetusFollow";
        this.BabySizeFetusFollow.Width = 80;

        this.BabyWeightFetusFollow = new TTVisual.TTTextBoxColumn();
        this.BabyWeightFetusFollow.DataMember = "BabyWeight";
        this.BabyWeightFetusFollow.DisplayIndex = 1;
        this.BabyWeightFetusFollow.HeaderText = i18n("M11707", "Bebek Kilo");
        this.BabyWeightFetusFollow.Name = "BabyWeightFetusFollow";
        this.BabyWeightFetusFollow.Width = 80;

        this.FKAFetusFollow = new TTVisual.TTTextBoxColumn();
        this.FKAFetusFollow.DataMember = "FKA";
        this.FKAFetusFollow.DisplayIndex = 2;
        this.FKAFetusFollow.HeaderText = "FKA";
        this.FKAFetusFollow.Name = "FKAFetusFollow";
        this.FKAFetusFollow.Width = 80;

        this.PregnancyDangerSign = new TTVisual.TTGrid();
        this.PregnancyDangerSign.Name = "PregnancyDangerSign";
        this.PregnancyDangerSign.TabIndex = 2;

        this.DangerPregnancyDangerSign = new TTVisual.TTListBoxColumn();
        this.DangerPregnancyDangerSign.ListDefName = "SKRSGebelikLohusalikSeyrindeTehlikeIsaretiList";
        this.DangerPregnancyDangerSign.DataMember = "Danger";
        this.DangerPregnancyDangerSign.DisplayIndex = 0;
        this.DangerPregnancyDangerSign.HeaderText = i18n("M23067", "Tehlike İşareti");
        this.DangerPregnancyDangerSign.Name = "DangerPregnancyDangerSign";
        this.DangerPregnancyDangerSign.Width = 300;

        this.DangerDescriptionPregnancyDangerSign = new TTVisual.TTTextBoxColumn();
        this.DangerDescriptionPregnancyDangerSign.DataMember = "DangerDescription";
        this.DangerDescriptionPregnancyDangerSign.DisplayIndex = 1;
        this.DangerDescriptionPregnancyDangerSign.HeaderText = i18n("M23068", "Tehlike Tanımı");
        this.DangerDescriptionPregnancyDangerSign.Name = "DangerDescriptionPregnancyDangerSign";
        this.DangerDescriptionPregnancyDangerSign.Width = 80;

        this.ObligedRiskFactors = new TTVisual.TTGrid();
        this.ObligedRiskFactors.Name = "ObligedRiskFactors";
        this.ObligedRiskFactors.TabIndex = 1;

        this.RiskFactorsObligedRiskFactors = new TTVisual.TTListBoxColumn();
        this.RiskFactorsObligedRiskFactors.ListDefName = "SKRSGebelikBildirimiZorunluRiskFaktorleriList";
        this.RiskFactorsObligedRiskFactors.DataMember = "RiskFactors";
        this.RiskFactorsObligedRiskFactors.DisplayIndex = 0;
        this.RiskFactorsObligedRiskFactors.HeaderText = i18n("M21046", "Risk Faktörü");
        this.RiskFactorsObligedRiskFactors.Name = "RiskFactorsObligedRiskFactors";
        this.RiskFactorsObligedRiskFactors.Width = 300;

        this.RiskFactorDescriptionObligedRiskFactors = new TTVisual.TTTextBoxColumn();
        this.RiskFactorDescriptionObligedRiskFactors.DataMember = "RiskFactorDescription";
        this.RiskFactorDescriptionObligedRiskFactors.DisplayIndex = 1;
        this.RiskFactorDescriptionObligedRiskFactors.HeaderText = i18n("M24794", "Zorunlu Risk Faktörü Açıklama");
        this.RiskFactorDescriptionObligedRiskFactors.Name = "RiskFactorDescriptionObligedRiskFactors";
        this.RiskFactorDescriptionObligedRiskFactors.Width = 80;

        this.PregnancyComplications = new TTVisual.TTGrid();
        this.PregnancyComplications.Name = "PregnancyComplications";
        this.PregnancyComplications.TabIndex = 0;

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

        this.labelVitaminDSupplements = new TTVisual.TTLabel();
        this.labelVitaminDSupplements.Text = "D Vitamini Lojistiği ve Desteği";
        this.labelVitaminDSupplements.Name = "labelVitaminDSupplements";
        this.labelVitaminDSupplements.TabIndex = 38;

        this.VitaminDSupplements = new TTVisual.TTObjectListBox();
        this.VitaminDSupplements.ListDefName = "SKRSDVitaminiLojistigiveDestegiList";
        this.VitaminDSupplements.Name = "VitaminDSupplements";
        this.VitaminDSupplements.TabIndex = 8;

        this.labelIronSupplements = new TTVisual.TTLabel();
        this.labelIronSupplements.Text = i18n("M12553", "Demir Lojistiği ve Desteği");
        this.labelIronSupplements.Name = "labelIronSupplements";
        this.labelIronSupplements.TabIndex = 36;

        this.IronSupplements = new TTVisual.TTObjectListBox();
        this.IronSupplements.ListDefName = "SKRSDemirLojistigiveDestegiList";
        this.IronSupplements.Name = "IronSupplements";
        this.IronSupplements.TabIndex = 9;

        this.labelWhichPregnancyFollow = new TTVisual.TTLabel();
        this.labelWhichPregnancyFollow.Text = i18n("M17046", "Kaçıncı Gebe İzlem");
        this.labelWhichPregnancyFollow.Name = "labelWhichPregnancyFollow";
        this.labelWhichPregnancyFollow.TabIndex = 34;

        this.WhichPregnancyFollow = new TTVisual.TTObjectListBox();
        this.WhichPregnancyFollow.ListDefName = "SKRSKacinciGebeIzlemList";
        this.WhichPregnancyFollow.Name = "WhichPregnancyFollow";
        this.WhichPregnancyFollow.TabIndex = 6;

        this.ttgroupbox3 = new TTVisual.TTGroupBox();
        this.ttgroupbox3.Text = i18n("M11720", "Beklenen Fetus Gelişimi");
        this.ttgroupbox3.Name = "ttgroupbox3";
        this.ttgroupbox3.TabIndex = 18;

        this.labelWeightFetusGrowingDefinition = new TTVisual.TTLabel();
        this.labelWeightFetusGrowingDefinition.Text = "Kilo";
        this.labelWeightFetusGrowingDefinition.Name = "labelWeightFetusGrowingDefinition";
        this.labelWeightFetusGrowingDefinition.TabIndex = 14;

        this.WeightFetusGrowingDefinition = new TTVisual.TTTextBox();
        this.WeightFetusGrowingDefinition.BackColor = "#F0F0F0";
        this.WeightFetusGrowingDefinition.ReadOnly = true;
        this.WeightFetusGrowingDefinition.Name = "WeightFetusGrowingDefinition";
        this.WeightFetusGrowingDefinition.TabIndex = 2;

        this.labelPregnancyWeekFetusGrowingDefinition = new TTVisual.TTLabel();
        this.labelPregnancyWeekFetusGrowingDefinition.Text = i18n("M14561", "Gebelik Haftası");
        this.labelPregnancyWeekFetusGrowingDefinition.Name = "labelPregnancyWeekFetusGrowingDefinition";
        this.labelPregnancyWeekFetusGrowingDefinition.TabIndex = 0;

        this.PregnancyWeekFetusGrowingDefinition = new TTVisual.TTTextBox();
        this.PregnancyWeekFetusGrowingDefinition.BackColor = "#F0F0F0";
        this.PregnancyWeekFetusGrowingDefinition.ReadOnly = true;
        this.PregnancyWeekFetusGrowingDefinition.Name = "PregnancyWeekFetusGrowingDefinition";
        this.PregnancyWeekFetusGrowingDefinition.TabIndex = 0;

        this.labelLengthFetusGrowingDefinition = new TTVisual.TTLabel();
        this.labelLengthFetusGrowingDefinition.Text = "Boy";
        this.labelLengthFetusGrowingDefinition.Name = "labelLengthFetusGrowingDefinition";
        this.labelLengthFetusGrowingDefinition.TabIndex = 10;

        this.LengthFetusGrowingDefinition = new TTVisual.TTTextBox();
        this.LengthFetusGrowingDefinition.BackColor = "#F0F0F0";
        this.LengthFetusGrowingDefinition.ReadOnly = true;
        this.LengthFetusGrowingDefinition.Name = "LengthFetusGrowingDefinition";
        this.LengthFetusGrowingDefinition.TabIndex = 1;

        this.labelHeadCircumferenceFetusGrowingDefinition = new TTVisual.TTLabel();
        this.labelHeadCircumferenceFetusGrowingDefinition.Text = "HC";
        this.labelHeadCircumferenceFetusGrowingDefinition.Name = "labelHeadCircumferenceFetusGrowingDefinition";
        this.labelHeadCircumferenceFetusGrowingDefinition.TabIndex = 8;

        this.HeadCircumferenceFetusGrowingDefinition = new TTVisual.TTTextBox();
        this.HeadCircumferenceFetusGrowingDefinition.BackColor = "#F0F0F0";
        this.HeadCircumferenceFetusGrowingDefinition.ReadOnly = true;
        this.HeadCircumferenceFetusGrowingDefinition.Name = "HeadCircumferenceFetusGrowingDefinition";
        this.HeadCircumferenceFetusGrowingDefinition.TabIndex = 6;

        this.labelFemurLengthFetusGrowingDefinition = new TTVisual.TTLabel();
        this.labelFemurLengthFetusGrowingDefinition.Text = "FL";
        this.labelFemurLengthFetusGrowingDefinition.Name = "labelFemurLengthFetusGrowingDefinition";
        this.labelFemurLengthFetusGrowingDefinition.TabIndex = 6;

        this.FemurLengthFetusGrowingDefinition = new TTVisual.TTTextBox();
        this.FemurLengthFetusGrowingDefinition.BackColor = "#F0F0F0";
        this.FemurLengthFetusGrowingDefinition.ReadOnly = true;
        this.FemurLengthFetusGrowingDefinition.Name = "FemurLengthFetusGrowingDefinition";
        this.FemurLengthFetusGrowingDefinition.TabIndex = 5;

        this.labelBiparietalDiameterFetusGrowingDefinition = new TTVisual.TTLabel();
        this.labelBiparietalDiameterFetusGrowingDefinition.Text = "BPD";
        this.labelBiparietalDiameterFetusGrowingDefinition.Name = "labelBiparietalDiameterFetusGrowingDefinition";
        this.labelBiparietalDiameterFetusGrowingDefinition.TabIndex = 4;

        this.BiparietalDiameterFetusGrowingDefinition = new TTVisual.TTTextBox();
        this.BiparietalDiameterFetusGrowingDefinition.BackColor = "#F0F0F0";
        this.BiparietalDiameterFetusGrowingDefinition.ReadOnly = true;
        this.BiparietalDiameterFetusGrowingDefinition.Name = "BiparietalDiameterFetusGrowingDefinition";
        this.BiparietalDiameterFetusGrowingDefinition.TabIndex = 4;

        this.labelAbdominalCircumferenceFetusGrowingDefinition = new TTVisual.TTLabel();
        this.labelAbdominalCircumferenceFetusGrowingDefinition.Text = "AC";
        this.labelAbdominalCircumferenceFetusGrowingDefinition.Name = "labelAbdominalCircumferenceFetusGrowingDefinition";
        this.labelAbdominalCircumferenceFetusGrowingDefinition.TabIndex = 2;

        this.AbdominalCircumferenceFetusGrowingDefinition = new TTVisual.TTTextBox();
        this.AbdominalCircumferenceFetusGrowingDefinition.BackColor = "#F0F0F0";
        this.AbdominalCircumferenceFetusGrowingDefinition.ReadOnly = true;
        this.AbdominalCircumferenceFetusGrowingDefinition.Name = "AbdominalCircumferenceFetusGrowingDefinition";
        this.AbdominalCircumferenceFetusGrowingDefinition.TabIndex = 3;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = "Tansiyon Nabız Gelecek";
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 19;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M14550", "Gebeliğe Bağlı Hastalıklar");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 3;

        this.Tension = new TTVisual.TTCheckBox();
        this.Tension.Value = false;
        this.Tension.Text = i18n("M22816", "Tansiyon");
        this.Tension.Title = i18n("M22816", "Tansiyon");
        this.Tension.Name = "Tension";
        this.Tension.TabIndex = 0;

        this.GestationalDiabetes = new TTVisual.TTCheckBox();
        this.GestationalDiabetes.Value = false;
        this.GestationalDiabetes.Text = i18n("M14575", "Gebelik Şekeri");
        this.GestationalDiabetes.Title = i18n("M14575", "Gebelik Şekeri");
        this.GestationalDiabetes.Name = "GestationalDiabetes";
        this.GestationalDiabetes.TabIndex = 1;

        this.Bleeding = new TTVisual.TTCheckBox();
        this.Bleeding.Value = false;
        this.Bleeding.Text = i18n("M17229", "Kanama");
        this.Bleeding.Title = i18n("M17229", "Kanama");
        this.Bleeding.Name = "Bleeding";
        this.Bleeding.TabIndex = 5;

        this.CardiovascularDiseases = new TTVisual.TTCheckBox();
        this.CardiovascularDiseases.Value = false;
        this.CardiovascularDiseases.Text = i18n("M12481", "Damar Hastalıkları");
        this.CardiovascularDiseases.Title = i18n("M12481", "Damar Hastalıkları");
        this.CardiovascularDiseases.Name = "CardiovascularDiseases";
        this.CardiovascularDiseases.TabIndex = 2;

        this.Nausea = new TTVisual.TTCheckBox();
        this.Nausea.Value = false;
        this.Nausea.Text = i18n("M12102", "Bulantı");
        this.Nausea.Title = i18n("M12102", "Bulantı");
        this.Nausea.Name = "Nausea";
        this.Nausea.TabIndex = 4;

        this.Anemia = new TTVisual.TTCheckBox();
        this.Anemia.Value = false;
        this.Anemia.Text = i18n("M10957", "Anemi");
        this.Anemia.Title = i18n("M10957", "Anemi");
        this.Anemia.Name = "Anemia";
        this.Anemia.TabIndex = 3;

        this.labelRiskFactors = new TTVisual.TTLabel();
        this.labelRiskFactors.Text = i18n("M14569", "Gebelik Risk Faktörleri");
        this.labelRiskFactors.Name = "labelRiskFactors";
        this.labelRiskFactors.TabIndex = 32;

        this.labelVaricose = new TTVisual.TTLabel();
        this.labelVaricose.Text = i18n("M24043", "Varis");
        this.labelVaricose.Name = "labelVaricose";
        this.labelVaricose.TabIndex = 30;

        this.labelUltrasonicFinding = new TTVisual.TTLabel();
        this.labelUltrasonicFinding.Text = i18n("M23709", "Ultrason Bulguları");
        this.labelUltrasonicFinding.Name = "labelUltrasonicFinding";
        this.labelUltrasonicFinding.TabIndex = 28;

        this.labelPretibialEdema = new TTVisual.TTLabel();
        this.labelPretibialEdema.Text = i18n("M20474", "Pretibial Ödem");
        this.labelPretibialEdema.Name = "labelPretibialEdema";
        this.labelPretibialEdema.TabIndex = 11;

        this.labelPregnancyDiseasesDescription = new TTVisual.TTLabel();
        this.labelPregnancyDiseasesDescription.Text = i18n("M14564", "Gebelik Hastalıkları Açıklama");
        this.labelPregnancyDiseasesDescription.Name = "labelPregnancyDiseasesDescription";
        this.labelPregnancyDiseasesDescription.TabIndex = 20;

        this.labelPelvicCondition = new TTVisual.TTLabel();
        this.labelPelvicCondition.Text = i18n("M20293", "Pelvis Durumu");
        this.labelPelvicCondition.Name = "labelPelvicCondition";
        this.labelPelvicCondition.TabIndex = 18;

        this.labelOpenness = new TTVisual.TTLabel();
        this.labelOpenness.Text = i18n("M10484", "Açıklık");
        this.labelOpenness.Name = "labelOpenness";
        this.labelOpenness.TabIndex = 16;

        this.labelMotherWeight = new TTVisual.TTLabel();
        this.labelMotherWeight.Text = i18n("M11044", "Anne Kilo");
        this.labelMotherWeight.Name = "labelMotherWeight";
        this.labelMotherWeight.TabIndex = 13;

        this.labelComplaints = new TTVisual.TTLabel();
        this.labelComplaints.Text = i18n("M22495", "Şikayetler");
        this.labelComplaints.Name = "labelComplaints";
        this.labelComplaints.TabIndex = 8;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Bildirimi Zorunlu Risk Faktörleri";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 32;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M14571", "Gebelik Seyrinde Tehlike İşareti");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 32;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Bebek Gelişimi Takip";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 20;

        this.FetusFollowColumns = [this.BabySizeFetusFollow, this.BabyWeightFetusFollow, this.FKAFetusFollow];
        this.PregnancyDangerSignColumns = [this.DangerPregnancyDangerSign, this.DangerDescriptionPregnancyDangerSign];
        this.ObligedRiskFactorsColumns = [this.RiskFactorsObligedRiskFactors, this.RiskFactorDescriptionObligedRiskFactors];
        this.PregnancyComplicationsColumns = [this.ComplicationPregnancyComplications, this.ComplicationsDescriptionPregnancyComplications];
        this.ttgroupbox3.Controls = [this.labelWeightFetusGrowingDefinition, this.WeightFetusGrowingDefinition, this.labelPregnancyWeekFetusGrowingDefinition, this.PregnancyWeekFetusGrowingDefinition, this.labelLengthFetusGrowingDefinition, this.LengthFetusGrowingDefinition, this.labelHeadCircumferenceFetusGrowingDefinition, this.HeadCircumferenceFetusGrowingDefinition, this.labelFemurLengthFetusGrowingDefinition, this.FemurLengthFetusGrowingDefinition, this.labelBiparietalDiameterFetusGrowingDefinition, this.BiparietalDiameterFetusGrowingDefinition, this.labelAbdominalCircumferenceFetusGrowingDefinition, this.AbdominalCircumferenceFetusGrowingDefinition];
        this.ttgroupbox1.Controls = [this.Tension, this.GestationalDiabetes, this.Bleeding, this.CardiovascularDiseases, this.Nausea, this.Anemia];
        this.Controls = [this.labelInformerPhone, this.InformerPhone, this.InformerName,this.labelWomansHealthOperations, this.WomansHealthOperations, this.labelCongenitalAnomalies, this.CongenitalAnomalies, this.labelUrinaryProtein, this.UrinaryProtein, this.labelHemoglobin, this.Hemoglobin, this.Varicose, this.labelInformerName, this.labelSkrsGestationalDiabetes, this.SkrsGestationalDiabetes, this.UltrasonicFinding, this.PretibialEdema, this.PregnancyDiseasesDescription, this.PelvicCondition, this.Openness, this.MotherWeight, this.Complaints, this.FetusFollow, this.BabySizeFetusFollow, this.BabyWeightFetusFollow, this.FKAFetusFollow, this.PregnancyDangerSign, this.DangerPregnancyDangerSign, this.DangerDescriptionPregnancyDangerSign, this.ObligedRiskFactors, this.RiskFactorsObligedRiskFactors, this.RiskFactorDescriptionObligedRiskFactors, this.PregnancyComplications, this.ComplicationPregnancyComplications, this.ComplicationsDescriptionPregnancyComplications, this.labelVitaminDSupplements, this.VitaminDSupplements, this.labelIronSupplements, this.IronSupplements, this.labelWhichPregnancyFollow, this.WhichPregnancyFollow, this.ttgroupbox3, this.labelWeightFetusGrowingDefinition, this.WeightFetusGrowingDefinition, this.labelPregnancyWeekFetusGrowingDefinition, this.PregnancyWeekFetusGrowingDefinition, this.labelLengthFetusGrowingDefinition, this.LengthFetusGrowingDefinition, this.labelHeadCircumferenceFetusGrowingDefinition, this.HeadCircumferenceFetusGrowingDefinition, this.labelFemurLengthFetusGrowingDefinition, this.FemurLengthFetusGrowingDefinition, this.labelBiparietalDiameterFetusGrowingDefinition, this.BiparietalDiameterFetusGrowingDefinition, this.labelAbdominalCircumferenceFetusGrowingDefinition, this.AbdominalCircumferenceFetusGrowingDefinition, this.ttgroupbox2, this.ttgroupbox1, this.Tension, this.GestationalDiabetes, this.Bleeding, this.CardiovascularDiseases, this.Nausea, this.Anemia, this.labelRiskFactors, this.labelVaricose, this.labelUltrasonicFinding, this.labelPretibialEdema, this.labelPregnancyDiseasesDescription, this.labelPelvicCondition, this.labelOpenness, this.labelMotherWeight, this.labelComplaints, this.ttlabel1, this.ttlabel2, this.ttlabel3];

    }

    public getGebelikIzlemInfo()
    {
        let that = this;
        that.httpService.get<Array<GebelikIzlem>>("/api/PatientExaminationService/GetGebelikIzlemList?FollowID=" + that._PregnancyFollow.ObjectID)
        .then(result => {
            if(result != null)
            {
                that.showGebelikIzlem = true;
                that._gebelikIzlemList = result;
            }
            
        })
        .catch(error => {
            console.log(error);
        });
        
    } 

    public onGebelikIzlemHiding()
    {
        this.showGebelikIzlem = false;
    }


}
