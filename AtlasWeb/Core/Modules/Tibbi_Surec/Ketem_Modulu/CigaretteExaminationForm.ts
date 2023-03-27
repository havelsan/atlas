//$77B592F7
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { CigaretteExaminationFormViewModel } from './CigaretteExaminationFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CigaretteExamination } from 'NebulaClient/Model/AtlasClientModel';

import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';

@Component({
    selector: 'CigaretteExaminationForm',
    templateUrl: './CigaretteExaminationForm.html',
    providers: [MessageService]
})
export class CigaretteExaminationForm extends TTVisual.TTForm implements OnInit {
    AKCOtherCancers: TTVisual.ITTCheckBox;
    Angina: TTVisual.ITTCheckBox;
    BadTaste: TTVisual.ITTCheckBox;
    BloodSpitting: TTVisual.ITTCheckBox;
    CardiovascularSystem: TTVisual.ITTTextBox;
    CerebrovascularSurgery: TTVisual.ITTCheckBox;
    ChestPain: TTVisual.ITTCheckBox;
    ChestRadiography: TTVisual.ITTTextBox;
    CoatedTongue: TTVisual.ITTCheckBox;
    COCarboxyHB: TTVisual.ITTTextBox;
    Constipation: TTVisual.ITTCheckBox;
    Convulsion: TTVisual.ITTCheckBox;
    Cough: TTVisual.ITTCheckBox;
    Diarrhea: TTVisual.ITTCheckBox;
    DM: TTVisual.ITTCheckBox;
    Dysuria: TTVisual.ITTCheckBox;
    EKG: TTVisual.ITTTextBox;
    Embolism: TTVisual.ITTCheckBox;
    Epilepsy: TTVisual.ITTCheckBox;
    GastricAcidity: TTVisual.ITTCheckBox;
    GastrointestinalSystem: TTVisual.ITTTextBox;
    GB1: TTVisual.ITTGroupBox;
    GB2: TTVisual.ITTGroupBox;
    gb3: TTVisual.ITTGroupBox;
    gb5: TTVisual.ITTGroupBox;
    gb7: TTVisual.ITTGroupBox;
    gb8: TTVisual.ITTGroupBox;
    gb9: TTVisual.ITTGroupBox;
    gp6: TTVisual.ITTGroupBox;
    HeadacheAndDizziness: TTVisual.ITTCheckBox;
    HeadNeck: TTVisual.ITTTextBox;
    HeadTrauma: TTVisual.ITTCheckBox;
    HowHeSheFeels: TTVisual.ITTTextBox;
    HT: TTVisual.ITTCheckBox;
    Hyperlipidemia: TTVisual.ITTCheckBox;
    InfarctionAngina: TTVisual.ITTCheckBox;
    KrBronchitis: TTVisual.ITTCheckBox;
    labelCardiovascularSystem: TTVisual.ITTLabel;
    labelChestRadiography: TTVisual.ITTLabel;
    labelCOCarboxyHB: TTVisual.ITTLabel;
    labelEKG: TTVisual.ITTLabel;
    labelGastrointestinalSystem: TTVisual.ITTLabel;
    labelHeadNeck: TTVisual.ITTLabel;
    labelHowHeSheFeels: TTVisual.ITTLabel;
    labelMedicineHistory: TTVisual.ITTLabel;
    labelOperationInfo: TTVisual.ITTLabel;
    labelPreviousDiseases: TTVisual.ITTLabel;
    labelPreviousPsychologicalTrt: TTVisual.ITTLabel;
    labelPulse: TTVisual.ITTLabel;
    labelRespirationRate: TTVisual.ITTLabel;
    labelRespiratorySystem: TTVisual.ITTLabel;
    labelSFT: TTVisual.ITTLabel;
    labelSkinMucosa: TTVisual.ITTLabel;
    labelTensionArterial: TTVisual.ITTLabel;
    LibidoLoss: TTVisual.ITTCheckBox;
    MedicineHistory: TTVisual.ITTTextBox;
    NasalBlockage: TTVisual.ITTCheckBox;
    Nausea: TTVisual.ITTCheckBox;
    Nocturia: TTVisual.ITTCheckBox;
    OperationInfo: TTVisual.ITTTextBox;
    Ortopne: TTVisual.ITTCheckBox;
    Palpitation: TTVisual.ITTCheckBox;
    Phlegm: TTVisual.ITTCheckBox;
    PND: TTVisual.ITTCheckBox;
    PreviousDiseases: TTVisual.ITTTextBox;
    PreviousPsychologicalTrt: TTVisual.ITTEnumComboBox;
    PUlcus: TTVisual.ITTCheckBox;
    Pulse: TTVisual.ITTTextBox;
    RedEye: TTVisual.ITTCheckBox;
    RespirationRate: TTVisual.ITTTextBox;
    RespiratorySystem: TTVisual.ITTTextBox;
    SFT: TTVisual.ITTTextBox;
    ShortnessOfBreath: TTVisual.ITTCheckBox;
    SkinMucosa: TTVisual.ITTTextBox;
    TensionArterial: TTVisual.ITTTextBox;
    ttgroupbox4: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    tttextbox1: TTVisual.ITTTextBox;
    YellowTeeth: TTVisual.ITTCheckBox;
    public _buttonCaption: string = "Yazdır";
    public _buttonIcon: string = "fa fa-print";
    public statesPanelClass: string = "col-lg-6";
    public cigaretteExaminationFormViewModel: CigaretteExaminationFormViewModel = new CigaretteExaminationFormViewModel();
    public get _CigaretteExamination(): CigaretteExamination {
        return this._TTObject as CigaretteExamination;
    }
    private CigaretteExaminationForm_DocumentUrl: string = '/api/CigaretteExaminationService/CigaretteExaminationForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService) {
        super('CIGARETTEEXAMINATION', 'CigaretteExaminationForm');
        this._DocumentServiceUrl = this.CigaretteExaminationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new CigaretteExamination();
        this.cigaretteExaminationFormViewModel = new CigaretteExaminationFormViewModel();
        this._ViewModel = this.cigaretteExaminationFormViewModel;
        this.cigaretteExaminationFormViewModel._CigaretteExamination = this._TTObject as CigaretteExamination;
    }

    protected loadViewModel() {
        let that = this;
        that.cigaretteExaminationFormViewModel = this._ViewModel as CigaretteExaminationFormViewModel;
        that._TTObject = this.cigaretteExaminationFormViewModel._CigaretteExamination;
        if (this.cigaretteExaminationFormViewModel == null)
            this.cigaretteExaminationFormViewModel = new CigaretteExaminationFormViewModel();
        if (this.cigaretteExaminationFormViewModel._CigaretteExamination == null)
            this.cigaretteExaminationFormViewModel._CigaretteExamination = new CigaretteExamination();

    }

    async ngOnInit() {
        await this.load(CigaretteExaminationFormViewModel);
    }

    public onAKCOtherCancersChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.AKCOtherCancers != event) {
            this._CigaretteExamination.AKCOtherCancers = event;
        }
    }

    public onAnginaChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Angina != event) {
            this._CigaretteExamination.Angina = event;
        }
    }

    public onBadTasteChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.BadTaste != event) {
            this._CigaretteExamination.BadTaste = event;
        }
    }

    public onBloodSpittingChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.BloodSpitting != event) {
            this._CigaretteExamination.BloodSpitting = event;
        }
    }

    public onCardiovascularSystemChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.CardiovascularSystem != event) {
            this._CigaretteExamination.CardiovascularSystem = event;
        }
    }

    public onCerebrovascularSurgeryChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.CerebrovascularSurgery != event) {
            this._CigaretteExamination.CerebrovascularSurgery = event;
        }
    }

    public onChestPainChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.ChestPain != event) {
            this._CigaretteExamination.ChestPain = event;
        }
    }

    public onChestRadiographyChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.ChestRadiography != event) {
            this._CigaretteExamination.ChestRadiography = event;
        }
    }

    public onCoatedTongueChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.CoatedTongue != event) {
            this._CigaretteExamination.CoatedTongue = event;
        }
    }

    public onCOCarboxyHBChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.COCarboxyHB != event) {
            this._CigaretteExamination.COCarboxyHB = event;
        }
    }

    public onConstipationChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Constipation != event) {
            this._CigaretteExamination.Constipation = event;
        }
    }

    public onConvulsionChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Convulsion != event) {
            this._CigaretteExamination.Convulsion = event;
        }
    }

    public onCoughChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Cough != event) {
            this._CigaretteExamination.Cough = event;
        }
    }

    public onDiarrheaChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Diarrhea != event) {
            this._CigaretteExamination.Diarrhea = event;
        }
    }

    public onDMChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.DM != event) {
            this._CigaretteExamination.DM = event;
        }
    }

    public onDysuriaChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Dysuria != event) {
            this._CigaretteExamination.Dysuria = event;
        }
    }

    public onEKGChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.EKG != event) {
            this._CigaretteExamination.EKG = event;
        }
    }

    public onEmbolismChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Embolism != event) {
            this._CigaretteExamination.Embolism = event;
        }
    }

    public onEpilepsyChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Epilepsy != event) {
            this._CigaretteExamination.Epilepsy = event;
        }
    }

    public onGastricAcidityChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.GastricAcidity != event) {
            this._CigaretteExamination.GastricAcidity = event;
        }
    }

    public onGastrointestinalSystemChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.GastrointestinalSystem != event) {
            this._CigaretteExamination.GastrointestinalSystem = event;
        }
    }

    public onHeadacheAndDizzinessChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.HeadacheAndDizziness != event) {
            this._CigaretteExamination.HeadacheAndDizziness = event;
        }
    }

    public onHeadNeckChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.HeadNeck != event) {
            this._CigaretteExamination.HeadNeck = event;
        }
    }

    public onHeadTraumaChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.HeadTrauma != event) {
            this._CigaretteExamination.HeadTrauma = event;
        }
    }

    public onHowHeSheFeelsChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.HowHeSheFeels != event) {
            this._CigaretteExamination.HowHeSheFeels = event;
        }
    }

    public onHTChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.HT != event) {
            this._CigaretteExamination.HT = event;
        }
    }

    public onHyperlipidemiaChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Hyperlipidemia != event) {
            this._CigaretteExamination.Hyperlipidemia = event;
        }
    }

    public onInfarctionAnginaChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.InfarctionAngina != event) {
            this._CigaretteExamination.InfarctionAngina = event;
        }
    }

    public onKrBronchitisChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.KrBronchitis != event) {
            this._CigaretteExamination.KrBronchitis = event;
        }
    }

    public onLibidoLossChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.LibidoLoss != event) {
            this._CigaretteExamination.LibidoLoss = event;
        }
    }

    public onMedicineHistoryChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.MedicineHistory != event) {
            this._CigaretteExamination.MedicineHistory = event;
        }
    }

    public onNasalBlockageChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.NasalBlockage != event) {
            this._CigaretteExamination.NasalBlockage = event;
        }
    }

    public onNauseaChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Nausea != event) {
            this._CigaretteExamination.Nausea = event;
        }
    }

    public onNocturiaChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Nocturia != event) {
            this._CigaretteExamination.Nocturia = event;
        }
    }

    public onOperationInfoChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.OperationInfo != event) {
            this._CigaretteExamination.OperationInfo = event;
        }
    }

    public onOrtopneChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Ortopne != event) {
            this._CigaretteExamination.Ortopne = event;
        }
    }

    public onPalpitationChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Palpitation != event) {
            this._CigaretteExamination.Palpitation = event;
        }
    }

    public onPhlegmChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Phlegm != event) {
            this._CigaretteExamination.Phlegm = event;
        }
    }

    public onPNDChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.PND != event) {
            this._CigaretteExamination.PND = event;
        }
    }

    public onPreviousDiseasesChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.PreviousDiseases != event) {
            this._CigaretteExamination.PreviousDiseases = event;
        }
    }

    public onPreviousPsychologicalTrtChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.PreviousPsychologicalTrt != event) {
            this._CigaretteExamination.PreviousPsychologicalTrt = event;
        }
    }

    public onPUlcusChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.PUlcus != event) {
            this._CigaretteExamination.PUlcus = event;
        }
    }

    public onPulseChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.Pulse != event) {
            this._CigaretteExamination.Pulse = event;
        }
    }

    public onRedEyeChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.RedEye != event) {
            this._CigaretteExamination.RedEye = event;
        }
    }

    public onRespirationRateChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.RespirationRate != event) {
            this._CigaretteExamination.RespirationRate = event;
        }
    }

    public onRespiratorySystemChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.RespiratorySystem != event) {
            this._CigaretteExamination.RespiratorySystem = event;
        }
    }

    public onSFTChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.SFT != event) {
            this._CigaretteExamination.SFT = event;
        }
    }

    public onShortnessOfBreathChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.ShortnessOfBreath != event) {
            this._CigaretteExamination.ShortnessOfBreath = event;
        }
    }

    public onSkinMucosaChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.SkinMucosa != event) {
            this._CigaretteExamination.SkinMucosa = event;
        }
    }

    public onTensionArterialChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.TensionArterial != event) {
            this._CigaretteExamination.TensionArterial = event;
        }
    }

    public ontttextbox1Changed(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.GenitourinarySystem != event) {
            this._CigaretteExamination.GenitourinarySystem = event;
        }
    }

    public onYellowTeethChanged(event): void {
        if (this._CigaretteExamination != null && this._CigaretteExamination.YellowTeeth != event) {
            this._CigaretteExamination.YellowTeeth = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.HeadacheAndDizziness, "Value", this.__ttObject, "HeadacheAndDizziness");
        redirectProperty(this.RedEye, "Value", this.__ttObject, "RedEye");
        redirectProperty(this.YellowTeeth, "Value", this.__ttObject, "YellowTeeth");
        redirectProperty(this.CoatedTongue, "Value", this.__ttObject, "CoatedTongue");
        redirectProperty(this.BadTaste, "Value", this.__ttObject, "BadTaste");
        redirectProperty(this.NasalBlockage, "Value", this.__ttObject, "NasalBlockage");
        redirectProperty(this.PreviousDiseases, "Text", this.__ttObject, "PreviousDiseases");
        redirectProperty(this.MedicineHistory, "Text", this.__ttObject, "MedicineHistory");
        redirectProperty(this.OperationInfo, "Text", this.__ttObject, "OperationInfo");
        redirectProperty(this.TensionArterial, "Text", this.__ttObject, "TensionArterial");
        redirectProperty(this.Pulse, "Text", this.__ttObject, "Pulse");
        redirectProperty(this.RespirationRate, "Text", this.__ttObject, "RespirationRate");
        redirectProperty(this.SkinMucosa, "Text", this.__ttObject, "SkinMucosa");
        redirectProperty(this.HeadNeck, "Text", this.__ttObject, "HeadNeck");
        redirectProperty(this.RespiratorySystem, "Text", this.__ttObject, "RespiratorySystem");
        redirectProperty(this.CardiovascularSystem, "Text", this.__ttObject, "CardiovascularSystem");
        redirectProperty(this.GastrointestinalSystem, "Text", this.__ttObject, "GastrointestinalSystem");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "GenitourinarySystem");
        redirectProperty(this.ChestRadiography, "Text", this.__ttObject, "ChestRadiography");
        redirectProperty(this.EKG, "Text", this.__ttObject, "EKG");
        redirectProperty(this.COCarboxyHB, "Text", this.__ttObject, "COCarboxyHB");
        redirectProperty(this.SFT, "Text", this.__ttObject, "SFT");
        redirectProperty(this.Cough, "Value", this.__ttObject, "Cough");
        redirectProperty(this.Phlegm, "Value", this.__ttObject, "Phlegm");
        redirectProperty(this.ShortnessOfBreath, "Value", this.__ttObject, "ShortnessOfBreath");
        redirectProperty(this.BloodSpitting, "Value", this.__ttObject, "BloodSpitting");
        redirectProperty(this.ChestPain, "Value", this.__ttObject, "ChestPain");
        redirectProperty(this.Angina, "Value", this.__ttObject, "Angina");
        redirectProperty(this.Ortopne, "Value", this.__ttObject, "Ortopne");
        redirectProperty(this.Palpitation, "Value", this.__ttObject, "Palpitation");
        redirectProperty(this.PND, "Value", this.__ttObject, "PND");
        redirectProperty(this.Convulsion, "Value", this.__ttObject, "Convulsion");
        redirectProperty(this.Epilepsy, "Value", this.__ttObject, "Epilepsy");
        redirectProperty(this.HeadTrauma, "Value", this.__ttObject, "HeadTrauma");
        redirectProperty(this.CerebrovascularSurgery, "Value", this.__ttObject, "CerebrovascularSurgery");
        redirectProperty(this.Nausea, "Value", this.__ttObject, "Nausea");
        redirectProperty(this.Constipation, "Value", this.__ttObject, "Constipation");
        redirectProperty(this.Diarrhea, "Value", this.__ttObject, "Diarrhea");
        redirectProperty(this.GastricAcidity, "Value", this.__ttObject, "GastricAcidity");
        redirectProperty(this.Dysuria, "Value", this.__ttObject, "Dysuria");
        redirectProperty(this.Nocturia, "Value", this.__ttObject, "Nocturia");
        redirectProperty(this.LibidoLoss, "Value", this.__ttObject, "LibidoLoss");
        redirectProperty(this.PreviousPsychologicalTrt, "Value", this.__ttObject, "PreviousPsychologicalTrt");
        redirectProperty(this.HowHeSheFeels, "Text", this.__ttObject, "HowHeSheFeels");
        redirectProperty(this.HT, "Value", this.__ttObject, "HT");
        redirectProperty(this.DM, "Value", this.__ttObject, "DM");
        redirectProperty(this.Hyperlipidemia, "Value", this.__ttObject, "Hyperlipidemia");
        redirectProperty(this.InfarctionAngina, "Value", this.__ttObject, "InfarctionAngina");
        redirectProperty(this.KrBronchitis, "Value", this.__ttObject, "KrBronchitis");
        redirectProperty(this.PUlcus, "Value", this.__ttObject, "PUlcus");
        redirectProperty(this.Embolism, "Value", this.__ttObject, "Embolism");
        redirectProperty(this.AKCOtherCancers, "Value", this.__ttObject, "AKCOtherCancers");
    }

    public initFormControls(): void {
        this.gb9 = new TTVisual.TTGroupBox();
        this.gb9.Text = "Diğer Bilgiler";
        this.gb9.Name = "gb9";
        this.gb9.TabIndex = 8;

        this.labelSFT = new TTVisual.TTLabel();
        this.labelSFT.Text = "SFT";
        this.labelSFT.Name = "labelSFT";
        this.labelSFT.TabIndex = 31;

        this.SFT = new TTVisual.TTTextBox();
        this.SFT.Multiline = true;
        this.SFT.Name = "SFT";
        this.SFT.TabIndex = 30;

        this.labelCOCarboxyHB = new TTVisual.TTLabel();
        this.labelCOCarboxyHB.Text = "CO Karboksi HB";
        this.labelCOCarboxyHB.Name = "labelCOCarboxyHB";
        this.labelCOCarboxyHB.TabIndex = 29;

        this.COCarboxyHB = new TTVisual.TTTextBox();
        this.COCarboxyHB.Multiline = true;
        this.COCarboxyHB.Name = "COCarboxyHB";
        this.COCarboxyHB.TabIndex = 28;

        this.labelEKG = new TTVisual.TTLabel();
        this.labelEKG.Text = "EKG";
        this.labelEKG.Name = "labelEKG";
        this.labelEKG.TabIndex = 27;

        this.EKG = new TTVisual.TTTextBox();
        this.EKG.Multiline = true;
        this.EKG.Name = "EKG";
        this.EKG.TabIndex = 26;

        this.labelChestRadiography = new TTVisual.TTLabel();
        this.labelChestRadiography.Text = "Akciğer Grafisi";
        this.labelChestRadiography.Name = "labelChestRadiography";
        this.labelChestRadiography.TabIndex = 25;

        this.ChestRadiography = new TTVisual.TTTextBox();
        this.ChestRadiography.Multiline = true;
        this.ChestRadiography.Name = "ChestRadiography";
        this.ChestRadiography.TabIndex = 24;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Genitoüriner Sistem";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 23;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 22;

        this.labelGastrointestinalSystem = new TTVisual.TTLabel();
        this.labelGastrointestinalSystem.Text = "Gastrointestinal Sistem";
        this.labelGastrointestinalSystem.Name = "labelGastrointestinalSystem";
        this.labelGastrointestinalSystem.TabIndex = 21;

        this.GastrointestinalSystem = new TTVisual.TTTextBox();
        this.GastrointestinalSystem.Multiline = true;
        this.GastrointestinalSystem.Name = "GastrointestinalSystem";
        this.GastrointestinalSystem.TabIndex = 20;

        this.labelCardiovascularSystem = new TTVisual.TTLabel();
        this.labelCardiovascularSystem.Text = "Kardiyovasküler Sistem";
        this.labelCardiovascularSystem.Name = "labelCardiovascularSystem";
        this.labelCardiovascularSystem.TabIndex = 19;

        this.CardiovascularSystem = new TTVisual.TTTextBox();
        this.CardiovascularSystem.Multiline = true;
        this.CardiovascularSystem.Name = "CardiovascularSystem";
        this.CardiovascularSystem.TabIndex = 18;

        this.labelRespiratorySystem = new TTVisual.TTLabel();
        this.labelRespiratorySystem.Text = "Solunum Sistemi";
        this.labelRespiratorySystem.Name = "labelRespiratorySystem";
        this.labelRespiratorySystem.TabIndex = 17;

        this.RespiratorySystem = new TTVisual.TTTextBox();
        this.RespiratorySystem.Multiline = true;
        this.RespiratorySystem.Name = "RespiratorySystem";
        this.RespiratorySystem.TabIndex = 16;

        this.labelHeadNeck = new TTVisual.TTLabel();
        this.labelHeadNeck.Text = "Baş-Boyun";
        this.labelHeadNeck.Name = "labelHeadNeck";
        this.labelHeadNeck.TabIndex = 15;

        this.HeadNeck = new TTVisual.TTTextBox();
        this.HeadNeck.Multiline = true;
        this.HeadNeck.Name = "HeadNeck";
        this.HeadNeck.TabIndex = 14;

        this.labelSkinMucosa = new TTVisual.TTLabel();
        this.labelSkinMucosa.Text = "Cilt-Mukoza";
        this.labelSkinMucosa.Name = "labelSkinMucosa";
        this.labelSkinMucosa.TabIndex = 13;

        this.SkinMucosa = new TTVisual.TTTextBox();
        this.SkinMucosa.Multiline = true;
        this.SkinMucosa.Name = "SkinMucosa";
        this.SkinMucosa.TabIndex = 12;

        this.labelRespirationRate = new TTVisual.TTLabel();
        this.labelRespirationRate.Text = "Solunum Sayısı";
        this.labelRespirationRate.Name = "labelRespirationRate";
        this.labelRespirationRate.TabIndex = 11;

        this.RespirationRate = new TTVisual.TTTextBox();
        this.RespirationRate.Multiline = true;
        this.RespirationRate.Name = "RespirationRate";
        this.RespirationRate.TabIndex = 10;

        this.labelPulse = new TTVisual.TTLabel();
        this.labelPulse.Text = "Nabız";
        this.labelPulse.Name = "labelPulse";
        this.labelPulse.TabIndex = 9;

        this.Pulse = new TTVisual.TTTextBox();
        this.Pulse.Multiline = true;
        this.Pulse.Name = "Pulse";
        this.Pulse.TabIndex = 8;

        this.labelTensionArterial = new TTVisual.TTLabel();
        this.labelTensionArterial.Text = "Tansiyon Arteriyel";
        this.labelTensionArterial.Name = "labelTensionArterial";
        this.labelTensionArterial.TabIndex = 7;

        this.TensionArterial = new TTVisual.TTTextBox();
        this.TensionArterial.Multiline = true;
        this.TensionArterial.Name = "TensionArterial";
        this.TensionArterial.TabIndex = 6;

        this.labelOperationInfo = new TTVisual.TTLabel();
        this.labelOperationInfo.Text = "Kaza/Operasyon Bilgisi";
        this.labelOperationInfo.Name = "labelOperationInfo";
        this.labelOperationInfo.TabIndex = 5;

        this.OperationInfo = new TTVisual.TTTextBox();
        this.OperationInfo.Multiline = true;
        this.OperationInfo.Name = "OperationInfo";
        this.OperationInfo.TabIndex = 4;

        this.labelMedicineHistory = new TTVisual.TTLabel();
        this.labelMedicineHistory.Text = "İlaç Öyküsü";
        this.labelMedicineHistory.Name = "labelMedicineHistory";
        this.labelMedicineHistory.TabIndex = 3;

        this.MedicineHistory = new TTVisual.TTTextBox();
        this.MedicineHistory.Multiline = true;
        this.MedicineHistory.Name = "MedicineHistory";
        this.MedicineHistory.TabIndex = 2;

        this.labelPreviousDiseases = new TTVisual.TTLabel();
        this.labelPreviousDiseases.Text = "Geçirdiği Hastalıklar";
        this.labelPreviousDiseases.Name = "labelPreviousDiseases";
        this.labelPreviousDiseases.TabIndex = 1;

        this.PreviousDiseases = new TTVisual.TTTextBox();
        this.PreviousDiseases.Multiline = true;
        this.PreviousDiseases.Name = "PreviousDiseases";
        this.PreviousDiseases.TabIndex = 0;

        this.gb8 = new TTVisual.TTGroupBox();
        this.gb8.Text = "Soy Geçmiş";
        this.gb8.Name = "gb8";
        this.gb8.TabIndex = 7;

        this.AKCOtherCancers = new TTVisual.TTCheckBox();
        this.AKCOtherCancers.Value = false;
        this.AKCOtherCancers.Title = "AKC/Diğer Kanserler";
        this.AKCOtherCancers.Name = "AKCOtherCancers";
        this.AKCOtherCancers.TabIndex = 7;

        this.Embolism = new TTVisual.TTCheckBox();
        this.Embolism.Value = false;
        this.Embolism.Title = "Damar Tıkanıklığı";
        this.Embolism.Name = "Embolism";
        this.Embolism.TabIndex = 6;

        this.PUlcus = new TTVisual.TTCheckBox();
        this.PUlcus.Value = false;
        this.PUlcus.Title = "P.Ulcus";
        this.PUlcus.Name = "PUlcus";
        this.PUlcus.TabIndex = 5;

        this.KrBronchitis = new TTVisual.TTCheckBox();
        this.KrBronchitis.Value = false;
        this.KrBronchitis.Title = "KR/Bronşit";
        this.KrBronchitis.Name = "KrBronchitis";
        this.KrBronchitis.TabIndex = 4;

        this.InfarctionAngina = new TTVisual.TTCheckBox();
        this.InfarctionAngina.Value = false;
        this.InfarctionAngina.Title = "Enfarktüs/Angina";
        this.InfarctionAngina.Name = "InfarctionAngina";
        this.InfarctionAngina.TabIndex = 3;

        this.Hyperlipidemia = new TTVisual.TTCheckBox();
        this.Hyperlipidemia.Value = false;
        this.Hyperlipidemia.Title = "Hiperlipidemi";
        this.Hyperlipidemia.Name = "Hyperlipidemia";
        this.Hyperlipidemia.TabIndex = 2;

        this.DM = new TTVisual.TTCheckBox();
        this.DM.Value = false;
        this.DM.Title = "DM";
        this.DM.Name = "DM";
        this.DM.TabIndex = 1;

        this.HT = new TTVisual.TTCheckBox();
        this.HT.Value = false;
        this.HT.Title = "HT";
        this.HT.Name = "HT";
        this.HT.TabIndex = 0;

        this.gb7 = new TTVisual.TTGroupBox();
        this.gb7.Text = "Psikolojik Problemler";
        this.gb7.Name = "gb7";
        this.gb7.TabIndex = 6;

        this.labelHowHeSheFeels = new TTVisual.TTLabel();
        this.labelHowHeSheFeels.Text = "Son İki Haftadır Nasıl Hissediyor?";
        this.labelHowHeSheFeels.Name = "labelHowHeSheFeels";
        this.labelHowHeSheFeels.TabIndex = 3;

        this.HowHeSheFeels = new TTVisual.TTTextBox();
        this.HowHeSheFeels.Multiline = true;
        this.HowHeSheFeels.Name = "HowHeSheFeels";
        this.HowHeSheFeels.TabIndex = 2;

        this.labelPreviousPsychologicalTrt = new TTVisual.TTLabel();
        this.labelPreviousPsychologicalTrt.Text = "Daha Önce Psikolojik Tedavi Aldı Mı?";
        this.labelPreviousPsychologicalTrt.Name = "labelPreviousPsychologicalTrt";
        this.labelPreviousPsychologicalTrt.TabIndex = 1;

        this.PreviousPsychologicalTrt = new TTVisual.TTEnumComboBox();
        this.PreviousPsychologicalTrt.DataTypeName = "YesNoEnum";
        this.PreviousPsychologicalTrt.Name = "PreviousPsychologicalTrt";
        this.PreviousPsychologicalTrt.TabIndex = 0;

        this.gp6 = new TTVisual.TTGroupBox();
        this.gp6.Text = "Ürogenital Sistem";
        this.gp6.Name = "gp6";
        this.gp6.TabIndex = 5;

        this.LibidoLoss = new TTVisual.TTCheckBox();
        this.LibidoLoss.Value = false;
        this.LibidoLoss.Title = "Libido Kaybı";
        this.LibidoLoss.Name = "LibidoLoss";
        this.LibidoLoss.TabIndex = 2;

        this.Dysuria = new TTVisual.TTCheckBox();
        this.Dysuria.Value = false;
        this.Dysuria.Title = "Dizüri";
        this.Dysuria.Name = "Dysuria";
        this.Dysuria.TabIndex = 1;

        this.Nocturia = new TTVisual.TTCheckBox();
        this.Nocturia.Value = false;
        this.Nocturia.Title = "Noktüri";
        this.Nocturia.Name = "Nocturia";
        this.Nocturia.TabIndex = 0;

        this.gb5 = new TTVisual.TTGroupBox();
        this.gb5.Text = "Gastrointestinal Sistem Yakınmaları";
        this.gb5.Name = "gb5";
        this.gb5.TabIndex = 4;

        this.GastricAcidity = new TTVisual.TTCheckBox();
        this.GastricAcidity.Value = false;
        this.GastricAcidity.Title = "Midede Ekşime";
        this.GastricAcidity.Name = "GastricAcidity";
        this.GastricAcidity.TabIndex = 3;

        this.Constipation = new TTVisual.TTCheckBox();
        this.Constipation.Value = false;
        this.Constipation.Title = "Kabız";
        this.Constipation.Name = "Constipation";
        this.Constipation.TabIndex = 2;

        this.Diarrhea = new TTVisual.TTCheckBox();
        this.Diarrhea.Value = false;
        this.Diarrhea.Title = "İshal";
        this.Diarrhea.Name = "Diarrhea";
        this.Diarrhea.TabIndex = 1;

        this.Nausea = new TTVisual.TTCheckBox();
        this.Nausea.Value = false;
        this.Nausea.Title = "Bulantı";
        this.Nausea.Name = "Nausea";
        this.Nausea.TabIndex = 0;

        this.ttgroupbox4 = new TTVisual.TTGroupBox();
        this.ttgroupbox4.Text = "Nörolojik Sistem Yakınmaları";
        this.ttgroupbox4.Name = "ttgroupbox4";
        this.ttgroupbox4.TabIndex = 3;

        this.HeadTrauma = new TTVisual.TTCheckBox();
        this.HeadTrauma.Value = false;
        this.HeadTrauma.Title = "Kafa Travması";
        this.HeadTrauma.Name = "HeadTrauma";
        this.HeadTrauma.TabIndex = 3;

        this.Epilepsy = new TTVisual.TTCheckBox();
        this.Epilepsy.Value = false;
        this.Epilepsy.Title = "Epilepsi";
        this.Epilepsy.Name = "Epilepsy";
        this.Epilepsy.TabIndex = 2;

        this.CerebrovascularSurgery = new TTVisual.TTCheckBox();
        this.CerebrovascularSurgery.Value = false;
        this.CerebrovascularSurgery.Title = "Serebrovasküler Cerrahi";
        this.CerebrovascularSurgery.Name = "CerebrovascularSurgery";
        this.CerebrovascularSurgery.TabIndex = 1;

        this.Convulsion = new TTVisual.TTCheckBox();
        this.Convulsion.Value = false;
        this.Convulsion.Title = "Konvülsiyon";
        this.Convulsion.Name = "Convulsion";
        this.Convulsion.TabIndex = 0;

        this.gb3 = new TTVisual.TTGroupBox();
        this.gb3.Text = "Kardiyovasküler Sistem Yakınmaları";
        this.gb3.Name = "gb3";
        this.gb3.TabIndex = 2;

        this.Palpitation = new TTVisual.TTCheckBox();
        this.Palpitation.Value = false;
        this.Palpitation.Title = "Çarpıntı";
        this.Palpitation.Name = "Palpitation";
        this.Palpitation.TabIndex = 3;

        this.Ortopne = new TTVisual.TTCheckBox();
        this.Ortopne.Value = false;
        this.Ortopne.Title = "Ortopne";
        this.Ortopne.Name = "Ortopne";
        this.Ortopne.TabIndex = 2;

        this.PND = new TTVisual.TTCheckBox();
        this.PND.Value = false;
        this.PND.Title = "PND";
        this.PND.Name = "PND";
        this.PND.TabIndex = 1;

        this.Angina = new TTVisual.TTCheckBox();
        this.Angina.Value = false;
        this.Angina.Title = "Angina";
        this.Angina.Name = "Angina";
        this.Angina.TabIndex = 0;

        this.GB2 = new TTVisual.TTGroupBox();
        this.GB2.Text = "Solunum Sistemi";
        this.GB2.Name = "GB2";
        this.GB2.TabIndex = 1;

        this.ChestPain = new TTVisual.TTCheckBox();
        this.ChestPain.Value = false;
        this.ChestPain.Title = "Göğüs Ağrısı";
        this.ChestPain.Name = "ChestPain";
        this.ChestPain.TabIndex = 4;

        this.BloodSpitting = new TTVisual.TTCheckBox();
        this.BloodSpitting.Value = false;
        this.BloodSpitting.Title = "Kan Tükürme";
        this.BloodSpitting.Name = "BloodSpitting";
        this.BloodSpitting.TabIndex = 3;

        this.ShortnessOfBreath = new TTVisual.TTCheckBox();
        this.ShortnessOfBreath.Value = false;
        this.ShortnessOfBreath.Title = "Nefes Darlığı";
        this.ShortnessOfBreath.Name = "ShortnessOfBreath";
        this.ShortnessOfBreath.TabIndex = 2;

        this.Phlegm = new TTVisual.TTCheckBox();
        this.Phlegm.Value = false;
        this.Phlegm.Title = "Balgam";
        this.Phlegm.Name = "Phlegm";
        this.Phlegm.TabIndex = 1;

        this.Cough = new TTVisual.TTCheckBox();
        this.Cough.Value = false;
        this.Cough.Title = "Öksürük";
        this.Cough.Name = "Cough";
        this.Cough.TabIndex = 0;

        this.GB1 = new TTVisual.TTGroupBox();
        this.GB1.Text = "Baş ve Boyun";
        this.GB1.Name = "GB1";
        this.GB1.TabIndex = 0;

        this.NasalBlockage = new TTVisual.TTCheckBox();
        this.NasalBlockage.Value = false;
        this.NasalBlockage.Title = "Burun Tıkanıklığı";
        this.NasalBlockage.Name = "NasalBlockage";
        this.NasalBlockage.TabIndex = 5;

        this.BadTaste = new TTVisual.TTCheckBox();
        this.BadTaste.Value = false;
        this.BadTaste.Title = "Kötü Tat";
        this.BadTaste.Name = "BadTaste";
        this.BadTaste.TabIndex = 4;

        this.CoatedTongue = new TTVisual.TTCheckBox();
        this.CoatedTongue.Value = false;
        this.CoatedTongue.Title = "Paslı Dil";
        this.CoatedTongue.Name = "CoatedTongue";
        this.CoatedTongue.TabIndex = 3;

        this.YellowTeeth = new TTVisual.TTCheckBox();
        this.YellowTeeth.Value = false;
        this.YellowTeeth.Title = "Dişlerde Sararma";
        this.YellowTeeth.Name = "YellowTeeth";
        this.YellowTeeth.TabIndex = 2;

        this.RedEye = new TTVisual.TTCheckBox();
        this.RedEye.Value = false;
        this.RedEye.Title = "Gözlerde Kızarıklık/Kanlanma";
        this.RedEye.Name = "RedEye";
        this.RedEye.TabIndex = 1;

        this.HeadacheAndDizziness = new TTVisual.TTCheckBox();
        this.HeadacheAndDizziness.Value = false;
        this.HeadacheAndDizziness.Title = "Baş Ağrısı ve Dönmesi";
        this.HeadacheAndDizziness.Name = "HeadacheAndDizziness";
        this.HeadacheAndDizziness.TabIndex = 0;

        this.gb9.Controls = [this.labelSFT, this.SFT, this.labelCOCarboxyHB, this.COCarboxyHB, this.labelEKG, this.EKG, this.labelChestRadiography, this.ChestRadiography, this.ttlabel1, this.tttextbox1, this.labelGastrointestinalSystem, this.GastrointestinalSystem, this.labelCardiovascularSystem, this.CardiovascularSystem, this.labelRespiratorySystem, this.RespiratorySystem, this.labelHeadNeck, this.HeadNeck, this.labelSkinMucosa, this.SkinMucosa, this.labelRespirationRate, this.RespirationRate, this.labelPulse, this.Pulse, this.labelTensionArterial, this.TensionArterial, this.labelOperationInfo, this.OperationInfo, this.labelMedicineHistory, this.MedicineHistory, this.labelPreviousDiseases, this.PreviousDiseases];
        this.gb8.Controls = [this.AKCOtherCancers, this.Embolism, this.PUlcus, this.KrBronchitis, this.InfarctionAngina, this.Hyperlipidemia, this.DM, this.HT];
        this.gb7.Controls = [this.labelHowHeSheFeels, this.HowHeSheFeels, this.labelPreviousPsychologicalTrt, this.PreviousPsychologicalTrt];
        this.gp6.Controls = [this.LibidoLoss, this.Dysuria, this.Nocturia];
        this.gb5.Controls = [this.GastricAcidity, this.Constipation, this.Diarrhea, this.Nausea];
        this.ttgroupbox4.Controls = [this.HeadTrauma, this.Epilepsy, this.CerebrovascularSurgery, this.Convulsion];
        this.gb3.Controls = [this.Palpitation, this.Ortopne, this.PND, this.Angina];
        this.GB2.Controls = [this.ChestPain, this.BloodSpitting, this.ShortnessOfBreath, this.Phlegm, this.Cough];
        this.GB1.Controls = [this.NasalBlockage, this.BadTaste, this.CoatedTongue, this.YellowTeeth, this.RedEye, this.HeadacheAndDizziness];
        this.Controls = [this.gb9, this.labelSFT, this.SFT, this.labelCOCarboxyHB, this.COCarboxyHB, this.labelEKG, this.EKG, this.labelChestRadiography, this.ChestRadiography, this.ttlabel1, this.tttextbox1, this.labelGastrointestinalSystem, this.GastrointestinalSystem, this.labelCardiovascularSystem, this.CardiovascularSystem, this.labelRespiratorySystem, this.RespiratorySystem, this.labelHeadNeck, this.HeadNeck, this.labelSkinMucosa, this.SkinMucosa, this.labelRespirationRate, this.RespirationRate, this.labelPulse, this.Pulse, this.labelTensionArterial, this.TensionArterial, this.labelOperationInfo, this.OperationInfo, this.labelMedicineHistory, this.MedicineHistory, this.labelPreviousDiseases, this.PreviousDiseases, this.gb8, this.AKCOtherCancers, this.Embolism, this.PUlcus, this.KrBronchitis, this.InfarctionAngina, this.Hyperlipidemia, this.DM, this.HT, this.gb7, this.labelHowHeSheFeels, this.HowHeSheFeels, this.labelPreviousPsychologicalTrt, this.PreviousPsychologicalTrt, this.gp6, this.LibidoLoss, this.Dysuria, this.Nocturia, this.gb5, this.GastricAcidity, this.Constipation, this.Diarrhea, this.Nausea, this.ttgroupbox4, this.HeadTrauma, this.Epilepsy, this.CerebrovascularSurgery, this.Convulsion, this.gb3, this.Palpitation, this.Ortopne, this.PND, this.Angina, this.GB2, this.ChestPain, this.BloodSpitting, this.ShortnessOfBreath, this.Phlegm, this.Cough, this.GB1, this.NasalBlockage, this.BadTaste, this.CoatedTongue, this.YellowTeeth, this.RedEye, this.HeadacheAndDizziness];

    }

    printCigaretteExaminationForm() {
        let reportData: DynamicReportParameters = {

            Code: 'SIGARAMUAYENEFORMU',
            ReportParams: { ObjectID: this._CigaretteExamination.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "SİGARA MUAYENE FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
}
