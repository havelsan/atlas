//$07D10FD9
import { Component, OnInit } from '@angular/core';
import { HemodialysisOrderDetailFormViewModel } from './HemodialysisOrderDetailFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { HemodialysisOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAktifVitaminDKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAnemiTedavisiYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAntihipertansifIlacKullanimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDamarErisimYolu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDiyalizeGirmeSikligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDiyalizorAlani } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDiyalizorTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDiyalizTedavisiYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSFosforBaglayiciAjan } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKanAkimHizi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKATATER } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKullanilanDiyalizTedavisi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOncekiRRTYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPeritonDiyaliziKateterTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPeritonDiyaliziKomplikasyon } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPeritonDiyalizKateterYerlestirmeYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPeritonDiyalizTunelYonu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPeritonealGecirgenlikPET } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSinekalset } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTedavininSeyri } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { MessageIconEnum } from '../../../wwwroot/app/NebulaClient/Utils/Enums/MessageIconEnum';


@Component({
    selector: 'HemodialysisOrderDetailForm',
    templateUrl: './HemodialysisOrderDetailForm.html',
    providers: [MessageService]
})
export class HemodialysisOrderDetailForm extends TTVisual.TTForm implements OnInit {
    Allergy: TTVisual.ITTTextBox;
    AnemiaTreatmentMethod: TTVisual.ITTObjectListBox;
    Antihypertensive: TTVisual.ITTObjectListBox;
    AVFCare: TTVisual.ITTCheckBox;
    BloodFlow: TTVisual.ITTObjectListBox;
    BunPost: TTVisual.ITTTextBox;
    BunPre: TTVisual.ITTTextBox;
    CareNurse: TTVisual.ITTObjectListBox;
    Catheter: TTVisual.ITTObjectListBox;
    CatheterCare: TTVisual.ITTCheckBox;
    CatheterInsertionMethod: TTVisual.ITTObjectListBox;
    CatheterType: TTVisual.ITTObjectListBox;
    Device: TTVisual.ITTTextBox;
    Diagnosis: TTVisual.ITTTextBox;
    DialysateTransferSpeed: TTVisual.ITTTextBox;
    DialysisFrequency: TTVisual.ITTObjectListBox;
    DialysisTreatment: TTVisual.ITTObjectListBox;
    DialysisTreatmentMethod: TTVisual.ITTObjectListBox;
    DialyzatorArea: TTVisual.ITTObjectListBox;
    DialyzatorType: TTVisual.ITTObjectListBox;
    Doctor: TTVisual.ITTObjectListBox;
    Etiology: TTVisual.ITTTextBox;
    GeneralInfo: TTVisual.ITTTextBox;
    grpKtv: TTVisual.ITTGroupBox;
    grpSaglikNet: TTVisual.ITTGroupBox;
    Heparinization: TTVisual.ITTTextBox;
    Hepatitis: TTVisual.ITTTextBox;
    Information: TTVisual.ITTTextBox;
    Intravenous: TTVisual.ITTObjectListBox;
    Ktv: TTVisual.ITTTextBox;
    labelAllergy: TTVisual.ITTLabel;
    labelAnemiaTreatmentMethod: TTVisual.ITTLabel;
    labelAntihypertensive: TTVisual.ITTLabel;
    labelBloodFlow: TTVisual.ITTLabel;
    labelBunPost: TTVisual.ITTLabel;
    labelBunPre: TTVisual.ITTLabel;
    labelCareNurse: TTVisual.ITTLabel;
    labelCatheter: TTVisual.ITTLabel;
    labelCatheterInsertionMethod: TTVisual.ITTLabel;
    labelCatheterType: TTVisual.ITTLabel;
    labelDevice: TTVisual.ITTLabel;
    labelDiagnosis: TTVisual.ITTLabel;
    labelDialysateTransferSpeed: TTVisual.ITTLabel;
    labelDialysisFrequency: TTVisual.ITTLabel;
    labelDialysisTreatment: TTVisual.ITTLabel;
    labelDialysisTreatmentMethod: TTVisual.ITTLabel;
    labelDialyzatorArea: TTVisual.ITTLabel;
    labelDialyzatorType: TTVisual.ITTLabel;
    labelDoctor: TTVisual.ITTLabel;
    labelEtiology: TTVisual.ITTLabel;
    labelGeneralInfo: TTVisual.ITTLabel;
    labelHeparinization: TTVisual.ITTLabel;
    labelHepatitis: TTVisual.ITTLabel;
    labelInformation: TTVisual.ITTLabel;
    labelIntravenous: TTVisual.ITTLabel;
    labelKtv: TTVisual.ITTLabel;
    labelLiquid: TTVisual.ITTLabel;
    labelLiquidCa: TTVisual.ITTLabel;
    labelLiquidCH3COO: TTVisual.ITTLabel;
    labelLiquidCl: TTVisual.ITTLabel;
    labelLiquidHCO3: TTVisual.ITTLabel;
    labelLiquidK: TTVisual.ITTLabel;
    labelLiquidMg: TTVisual.ITTLabel;
    labelLiquidNa: TTVisual.ITTLabel;
    labelNurse: TTVisual.ITTLabel;
    labelPeritonealComplication: TTVisual.ITTLabel;
    labelPeritonealDialysisTunnel: TTVisual.ITTLabel;
    labelPET: TTVisual.ITTLabel;
    labelPhosphorusAgent: TTVisual.ITTLabel;
    labelPreviousRRT: TTVisual.ITTLabel;
    labelSessionDate: TTVisual.ITTLabel;
    labelSessionFinishTime: TTVisual.ITTLabel;
    labelSessionStartTime: TTVisual.ITTLabel;
    labelSinekalsetUsage: TTVisual.ITTLabel;
    labelSuggestions: TTVisual.ITTLabel;
    labelTreatmentCourse: TTVisual.ITTLabel;
    labelURR: TTVisual.ITTLabel;
    labelVitaminDusage: TTVisual.ITTLabel;
    labelWeightAfter: TTVisual.ITTLabel;
    labelWeightBefore: TTVisual.ITTLabel;
    Liquid: TTVisual.ITTTextBox;
    LiquidCa: TTVisual.ITTTextBox;
    LiquidCH3COO: TTVisual.ITTTextBox;
    LiquidCl: TTVisual.ITTTextBox;
    LiquidHCO3: TTVisual.ITTTextBox;
    LiquidK: TTVisual.ITTTextBox;
    LiquidMg: TTVisual.ITTTextBox;
    LiquidNa: TTVisual.ITTTextBox;
    Nurse: TTVisual.ITTObjectListBox;
    PeritonealComplication: TTVisual.ITTObjectListBox;
    PeritonealDialysisTunnel: TTVisual.ITTObjectListBox;
    PET: TTVisual.ITTObjectListBox;
    PhosphorusAgent: TTVisual.ITTObjectListBox;
    PreviousRRT: TTVisual.ITTObjectListBox;
    SessionDate: TTVisual.ITTDateTimePicker;
    SessionFinishTime: TTVisual.ITTDateTimePicker;
    SessionStartTime: TTVisual.ITTDateTimePicker;
    SinekalsetUsage: TTVisual.ITTObjectListBox;
    Suggestions: TTVisual.ITTTextBox;
    tabGenelBilgiler: TTVisual.ITTTabPage;
    tabSaglikNet: TTVisual.ITTTabPage;
    tabSeansBilgileri: TTVisual.ITTTabPage;
    TreatmentCourse: TTVisual.ITTObjectListBox;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel24: TTVisual.ITTLabel;
    ttlabel25: TTVisual.ITTLabel;
    ttlabel26: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    URR: TTVisual.ITTTextBox;
    VitaminDusage: TTVisual.ITTObjectListBox;
    WeightAfter: TTVisual.ITTTextBox;
    WeightBefore: TTVisual.ITTTextBox;
    public hemodialysisOrderDetailFormViewModel: HemodialysisOrderDetailFormViewModel = new HemodialysisOrderDetailFormViewModel();
    public get _HemodialysisOrderDetail(): HemodialysisOrderDetail {
        return this._TTObject as HemodialysisOrderDetail;
    }
    private HemodialysisOrderDetailForm_DocumentUrl: string = '/api/HemodialysisOrderDetailService/HemodialysisOrderDetailForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('HEMODIALYSISORDERDETAIL', 'HemodialysisOrderDetailForm');
        this._DocumentServiceUrl = this.HemodialysisOrderDetailForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async PreScript() {
        super.PreScript();
        if (this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Intravenous != null && this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Intravenous.KODU == "1") {
            this.AVFCare.ReadOnly = false;//Hastanın damar erişim yolu SKRS üzerinde 1 seçili ise AVF bakım yapıldı checkbox ı seçim için aktif olmalı.
        }

        if (this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Intravenous != null && (this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Intravenous.KODU == "3" || this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Intravenous.KODU == "4")) {
            this.CatheterCare.ReadOnly = false;//Hastanın damar erişim yolu SKRS üzerinde 3 – 4 seçili ise Katater bakımı yapıldı checkbox ı seçim için aktif olmalı. 
        }

        let messageText = "";
        if (this.hemodialysisOrderDetailFormViewModel.IsCatheterCareDone == false) {
            messageText = "Katater";
        }
        if (this.hemodialysisOrderDetailFormViewModel.IsAVFCareCareDone == false) {
            if (messageText == "") {
                messageText += "AVF";
            }
            else {
                messageText += " ve AVF";
            }
        }
        TTVisual.InfoBox.Alert("Uyarı", "Hastanın bir önceki seansında " + messageText + " bakımı yapılamıştır!", MessageIconEnum.WarningMessage)
    }

    public getPreviousOrderDetail() {
        let that = this;
        let fullApiUrl: string = "";
        fullApiUrl = 'api/HemodialysisOrderDetailService/getPreviousOrderDetail';
        //if (typeof this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.EpisodeAction == 'string') {
        //    fullApiUrl = 'api/HemodialysisOrderDetailService/getPreviousOrderDetail?requestObjectId=' + this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.EpisodeAction + '&sessionDate=' + this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.SessionDate.toDateString();
        //} else {
        //    fullApiUrl = 'api/HemodialysisOrderDetailService/getPreviousOrderDetail?requestObjectId=' + this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.EpisodeAction.ObjectID + '&sessionDate=' + this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.SessionDate.toDateString();
        //}

        that.httpService.post<HemodialysisOrderDetail>(fullApiUrl, this.hemodialysisOrderDetailFormViewModel).then((response) => {
            //let result: HemodialysisOrderDetail = <HemodialysisOrderDetail>response;
            ////this.initFormControls();
            //this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail = result;
            //this._ViewModel = this.hemodialysisOrderDetailFormViewModel;
            //this.loadViewModel();
            //this.PreScript();

            let _hemodialysisOrderDetail = response as HemodialysisOrderDetail;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Allergy = _hemodialysisOrderDetail.Allergy;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.AnemiaTreatmentMethod = _hemodialysisOrderDetail.AnemiaTreatmentMethod;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Antihypertensive = _hemodialysisOrderDetail.Antihypertensive;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.AVFCare = _hemodialysisOrderDetail.AVFCare;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.BloodFlow = _hemodialysisOrderDetail.BloodFlow;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.BunPost = _hemodialysisOrderDetail.BunPost;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.BunPre = _hemodialysisOrderDetail.BunPre;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.CareNurse = _hemodialysisOrderDetail.CareNurse;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.CatheterCare = _hemodialysisOrderDetail.CatheterCare;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Catheter = _hemodialysisOrderDetail.Catheter;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.CatheterInsertionMethod = _hemodialysisOrderDetail.CatheterInsertionMethod;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.CatheterType = _hemodialysisOrderDetail.CatheterType;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Device = _hemodialysisOrderDetail.Device;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Diagnosis = _hemodialysisOrderDetail.Diagnosis;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialysateTransferSpeed = _hemodialysisOrderDetail.DialysateTransferSpeed;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialysisFrequency = _hemodialysisOrderDetail.DialysisFrequency;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialysisTreatment = _hemodialysisOrderDetail.DialysisTreatment;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialysisTreatmentMethod = _hemodialysisOrderDetail.DialysisTreatmentMethod;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialyzatorArea = _hemodialysisOrderDetail.DialyzatorArea;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialyzatorType = _hemodialysisOrderDetail.DialyzatorType;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Doctor = _hemodialysisOrderDetail.Doctor;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Etiology = _hemodialysisOrderDetail.Etiology;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.GeneralInfo = _hemodialysisOrderDetail.GeneralInfo;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Heparinization = _hemodialysisOrderDetail.Heparinization;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Hepatitis = _hemodialysisOrderDetail.Hepatitis;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Information = _hemodialysisOrderDetail.Information;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Intravenous = _hemodialysisOrderDetail.Intravenous;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Ktv = _hemodialysisOrderDetail.Ktv;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.LiquidCa = _hemodialysisOrderDetail.LiquidCa;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.LiquidCH3COO = _hemodialysisOrderDetail.LiquidCH3COO;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Liquid = _hemodialysisOrderDetail.Liquid;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.LiquidCl = _hemodialysisOrderDetail.LiquidCl;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.LiquidHCO3 = _hemodialysisOrderDetail.LiquidHCO3;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.LiquidK = _hemodialysisOrderDetail.LiquidK;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.LiquidMg = _hemodialysisOrderDetail.LiquidMg;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.LiquidNa = _hemodialysisOrderDetail.LiquidNa;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Nurse = _hemodialysisOrderDetail.Nurse;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PeritonealComplication = _hemodialysisOrderDetail.PeritonealComplication;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PeritonealDialysisTunnel = _hemodialysisOrderDetail.PeritonealDialysisTunnel;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PET = _hemodialysisOrderDetail.PET;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PhosphorusAgent = _hemodialysisOrderDetail.PhosphorusAgent;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PreviousRRT = _hemodialysisOrderDetail.PreviousRRT;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.SinekalsetUsage = _hemodialysisOrderDetail.SinekalsetUsage;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Suggestions = _hemodialysisOrderDetail.Suggestions;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.TreatmentCourse = _hemodialysisOrderDetail.TreatmentCourse;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.URR = _hemodialysisOrderDetail.URR;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.VitaminDusage = _hemodialysisOrderDetail.VitaminDusage;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.BunPost = _hemodialysisOrderDetail.BunPost;
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.BunPost = _hemodialysisOrderDetail.BunPost;

            this.loadViewModel();
            this.PreScript();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HemodialysisOrderDetail();
        this.hemodialysisOrderDetailFormViewModel = new HemodialysisOrderDetailFormViewModel();
        this._ViewModel = this.hemodialysisOrderDetailFormViewModel;
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail = this._TTObject as HemodialysisOrderDetail;
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Antihypertensive = new SKRSAntihipertansifIlacKullanimDurumu();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PeritonealComplication = new SKRSPeritonDiyaliziKomplikasyon();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PeritonealDialysisTunnel = new SKRSPeritonDiyalizTunelYonu();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.CatheterInsertionMethod = new SKRSPeritonDiyalizKateterYerlestirmeYontemi();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.CatheterType = new SKRSPeritonDiyaliziKateterTipi();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialysisTreatment = new SKRSKullanilanDiyalizTedavisi();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Catheter = new SKRSKATATER();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PET = new SKRSPeritonealGecirgenlikPET();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.SinekalsetUsage = new SKRSSinekalset();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PreviousRRT = new SKRSOncekiRRTYontemi();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PhosphorusAgent = new SKRSFosforBaglayiciAjan();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialysisFrequency = new SKRSDiyalizeGirmeSikligi();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.BloodFlow = new SKRSKanAkimHizi();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialyzatorArea = new SKRSDiyalizorAlani();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialyzatorType = new SKRSDiyalizorTipi();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Intravenous = new SKRSDamarErisimYolu();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.CareNurse = new ResUser();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Nurse = new ResUser();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Doctor = new ResUser();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialysisTreatmentMethod = new SKRSDiyalizTedavisiYontemi();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.TreatmentCourse = new SKRSTedavininSeyri();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.VitaminDusage = new SKRSAktifVitaminDKullanimi();
        this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.AnemiaTreatmentMethod = new SKRSAnemiTedavisiYontemi();
    }

    protected loadViewModel() {
        let that = this;
        that.hemodialysisOrderDetailFormViewModel = this._ViewModel as HemodialysisOrderDetailFormViewModel;
        that._TTObject = this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail;
        if (this.hemodialysisOrderDetailFormViewModel == null)
            this.hemodialysisOrderDetailFormViewModel = new HemodialysisOrderDetailFormViewModel();
        if (this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail == null)
            this.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail = new HemodialysisOrderDetail();
        let antihypertensiveObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["Antihypertensive"];
        if (antihypertensiveObjectID != null && (typeof antihypertensiveObjectID === "string")) {
            let antihypertensive = that.hemodialysisOrderDetailFormViewModel.SKRSAntihipertansifIlacKullanimDurumus.find(o => o.ObjectID.toString() === antihypertensiveObjectID.toString());
            if (antihypertensive) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Antihypertensive = antihypertensive;
            }
        }

        let peritonealComplicationObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["PeritonealComplication"];
        if (peritonealComplicationObjectID != null && (typeof peritonealComplicationObjectID === "string")) {
            let peritonealComplication = that.hemodialysisOrderDetailFormViewModel.SKRSPeritonDiyaliziKomplikasyons.find(o => o.ObjectID.toString() === peritonealComplicationObjectID.toString());
            if (peritonealComplication) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PeritonealComplication = peritonealComplication;
            }
        }

        let peritonealDialysisTunnelObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["PeritonealDialysisTunnel"];
        if (peritonealDialysisTunnelObjectID != null && (typeof peritonealDialysisTunnelObjectID === "string")) {
            let peritonealDialysisTunnel = that.hemodialysisOrderDetailFormViewModel.SKRSPeritonDiyalizTunelYonus.find(o => o.ObjectID.toString() === peritonealDialysisTunnelObjectID.toString());
            if (peritonealDialysisTunnel) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PeritonealDialysisTunnel = peritonealDialysisTunnel;
            }
        }

        let catheterInsertionMethodObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["CatheterInsertionMethod"];
        if (catheterInsertionMethodObjectID != null && (typeof catheterInsertionMethodObjectID === "string")) {
            let catheterInsertionMethod = that.hemodialysisOrderDetailFormViewModel.SKRSPeritonDiyalizKateterYerlestirmeYontemis.find(o => o.ObjectID.toString() === catheterInsertionMethodObjectID.toString());
            if (catheterInsertionMethod) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.CatheterInsertionMethod = catheterInsertionMethod;
            }
        }

        let catheterTypeObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["CatheterType"];
        if (catheterTypeObjectID != null && (typeof catheterTypeObjectID === "string")) {
            let catheterType = that.hemodialysisOrderDetailFormViewModel.SKRSPeritonDiyaliziKateterTipis.find(o => o.ObjectID.toString() === catheterTypeObjectID.toString());
            if (catheterType) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.CatheterType = catheterType;
            }
        }

        let dialysisTreatmentObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["DialysisTreatment"];
        if (dialysisTreatmentObjectID != null && (typeof dialysisTreatmentObjectID === "string")) {
            let dialysisTreatment = that.hemodialysisOrderDetailFormViewModel.SKRSKullanilanDiyalizTedavisis.find(o => o.ObjectID.toString() === dialysisTreatmentObjectID.toString());
            if (dialysisTreatment) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialysisTreatment = dialysisTreatment;
            }
        }

        let catheterObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["Catheter"];
        if (catheterObjectID != null && (typeof catheterObjectID === "string")) {
            let catheter = that.hemodialysisOrderDetailFormViewModel.SKRSKATATERs.find(o => o.ObjectID.toString() === catheterObjectID.toString());
            if (catheter) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Catheter = catheter;
            }
        }

        let pETObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["PET"];
        if (pETObjectID != null && (typeof pETObjectID === "string")) {
            let pET = that.hemodialysisOrderDetailFormViewModel.SKRSPeritonealGecirgenlikPETs.find(o => o.ObjectID.toString() === pETObjectID.toString());
            if (pET) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PET = pET;
            }
        }

        let sinekalsetUsageObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["SinekalsetUsage"];
        if (sinekalsetUsageObjectID != null && (typeof sinekalsetUsageObjectID === "string")) {
            let sinekalsetUsage = that.hemodialysisOrderDetailFormViewModel.SKRSSinekalsets.find(o => o.ObjectID.toString() === sinekalsetUsageObjectID.toString());
            if (sinekalsetUsage) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.SinekalsetUsage = sinekalsetUsage;
            }
        }

        let previousRRTObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["PreviousRRT"];
        if (previousRRTObjectID != null && (typeof previousRRTObjectID === "string")) {
            let previousRRT = that.hemodialysisOrderDetailFormViewModel.SKRSOncekiRRTYontemis.find(o => o.ObjectID.toString() === previousRRTObjectID.toString());
            if (previousRRT) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PreviousRRT = previousRRT;
            }
        }

        let phosphorusAgentObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["PhosphorusAgent"];
        if (phosphorusAgentObjectID != null && (typeof phosphorusAgentObjectID === "string")) {
            let phosphorusAgent = that.hemodialysisOrderDetailFormViewModel.SKRSFosforBaglayiciAjans.find(o => o.ObjectID.toString() === phosphorusAgentObjectID.toString());
            if (phosphorusAgent) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.PhosphorusAgent = phosphorusAgent;
            }
        }

        let dialysisFrequencyObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["DialysisFrequency"];
        if (dialysisFrequencyObjectID != null && (typeof dialysisFrequencyObjectID === "string")) {
            let dialysisFrequency = that.hemodialysisOrderDetailFormViewModel.SKRSDiyalizeGirmeSikligis.find(o => o.ObjectID.toString() === dialysisFrequencyObjectID.toString());
            if (dialysisFrequency) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialysisFrequency = dialysisFrequency;
            }
        }

        let bloodFlowObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["BloodFlow"];
        if (bloodFlowObjectID != null && (typeof bloodFlowObjectID === "string")) {
            let bloodFlow = that.hemodialysisOrderDetailFormViewModel.SKRSKanAkimHizis.find(o => o.ObjectID.toString() === bloodFlowObjectID.toString());
            if (bloodFlow) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.BloodFlow = bloodFlow;
            }
        }

        let dialyzatorAreaObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["DialyzatorArea"];
        if (dialyzatorAreaObjectID != null && (typeof dialyzatorAreaObjectID === "string")) {
            let dialyzatorArea = that.hemodialysisOrderDetailFormViewModel.SKRSDiyalizorAlanis.find(o => o.ObjectID.toString() === dialyzatorAreaObjectID.toString());
            if (dialyzatorArea) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialyzatorArea = dialyzatorArea;
            }
        }

        let dialyzatorTypeObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["DialyzatorType"];
        if (dialyzatorTypeObjectID != null && (typeof dialyzatorTypeObjectID === "string")) {
            let dialyzatorType = that.hemodialysisOrderDetailFormViewModel.SKRSDiyalizorTipis.find(o => o.ObjectID.toString() === dialyzatorTypeObjectID.toString());
            if (dialyzatorType) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialyzatorType = dialyzatorType;
            }
        }

        let intravenousObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["Intravenous"];
        if (intravenousObjectID != null && (typeof intravenousObjectID === "string")) {
            let intravenous = that.hemodialysisOrderDetailFormViewModel.SKRSDamarErisimYolus.find(o => o.ObjectID.toString() === intravenousObjectID.toString());
            if (intravenous) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Intravenous = intravenous;
            }
        }

        let careNurseObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["CareNurse"];
        if (careNurseObjectID != null && (typeof careNurseObjectID === "string")) {
            let careNurse = that.hemodialysisOrderDetailFormViewModel.ResUsers.find(o => o.ObjectID.toString() === careNurseObjectID.toString());
            if (careNurse) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.CareNurse = careNurse;
            }
        }

        let nurseObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["Nurse"];
        if (nurseObjectID != null && (typeof nurseObjectID === "string")) {
            let nurse = that.hemodialysisOrderDetailFormViewModel.ResUsers.find(o => o.ObjectID.toString() === nurseObjectID.toString());
            if (nurse) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Nurse = nurse;
            }
        }

        let doctorObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["Doctor"];
        if (doctorObjectID != null && (typeof doctorObjectID === "string")) {
            let doctor = that.hemodialysisOrderDetailFormViewModel.ResUsers.find(o => o.ObjectID.toString() === doctorObjectID.toString());
            if (doctor) {
                that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.Doctor = doctor;
            }

            let dialysisTreatmentMethodObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["DialysisTreatmentMethod"];
            if (dialysisTreatmentMethodObjectID != null && (typeof dialysisTreatmentMethodObjectID === "string")) {
                let dialysisTreatmentMethod = that.hemodialysisOrderDetailFormViewModel.SKRSDiyalizTedavisiYontemis.find(o => o.ObjectID.toString() === dialysisTreatmentMethodObjectID.toString());
                if (dialysisTreatmentMethod) {
                    that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.DialysisTreatmentMethod = dialysisTreatmentMethod;
                }
            }

            let treatmentCourseObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["TreatmentCourse"];
            if (treatmentCourseObjectID != null && (typeof treatmentCourseObjectID === "string")) {
                let treatmentCourse = that.hemodialysisOrderDetailFormViewModel.SKRSTedavininSeyris.find(o => o.ObjectID.toString() === treatmentCourseObjectID.toString());
                if (treatmentCourse) {
                    that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.TreatmentCourse = treatmentCourse;
                }
            }

            let vitaminDusageObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["VitaminDusage"];
            if (vitaminDusageObjectID != null && (typeof vitaminDusageObjectID === "string")) {
                let vitaminDusage = that.hemodialysisOrderDetailFormViewModel.SKRSAktifVitaminDKullanimis.find(o => o.ObjectID.toString() === vitaminDusageObjectID.toString());
                if (vitaminDusage) {
                    that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.VitaminDusage = vitaminDusage;
                }
            }

            let anemiaTreatmentMethodObjectID = that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail["AnemiaTreatmentMethod"];
            if (anemiaTreatmentMethodObjectID != null && (typeof anemiaTreatmentMethodObjectID === "string")) {
                let anemiaTreatmentMethod = that.hemodialysisOrderDetailFormViewModel.SKRSAnemiTedavisiYontemis.find(o => o.ObjectID.toString() === anemiaTreatmentMethodObjectID.toString());
                if (anemiaTreatmentMethod) {
                    that.hemodialysisOrderDetailFormViewModel._HemodialysisOrderDetail.AnemiaTreatmentMethod = anemiaTreatmentMethod;
                }
            }

        }
    }
    async ngOnInit() {
        await this.load();
    }

    public onAllergyChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Allergy != event) {
            this._HemodialysisOrderDetail.Allergy = event;
        }
    }

    public onAnemiaTreatmentMethodChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.AnemiaTreatmentMethod != event) {
            this._HemodialysisOrderDetail.AnemiaTreatmentMethod = event;
        }
    }

    public onAntihypertensiveChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Antihypertensive != event) {
            this._HemodialysisOrderDetail.Antihypertensive = event;
        }
    }

    public onAVFCareChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.AVFCare != event) {
            this._HemodialysisOrderDetail.AVFCare = event;
        }
    }

    public onBloodFlowChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.BloodFlow != event) {
            this._HemodialysisOrderDetail.BloodFlow = event;
        }
    }

    public onBunPostChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.BunPost != event) {
            this._HemodialysisOrderDetail.BunPost = event;
        }
    }

    public onBunPreChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.BunPre != event) {
            this._HemodialysisOrderDetail.BunPre = event;
        }
    }

    public onCareNurseChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.CareNurse != event) {
            this._HemodialysisOrderDetail.CareNurse = event;
        }
    }

    public onCatheterCareChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.CatheterCare != event) {
            this._HemodialysisOrderDetail.CatheterCare = event;
        }
    }

    public onCatheterChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Catheter != event) {
            this._HemodialysisOrderDetail.Catheter = event;
        }
    }

    public onCatheterInsertionMethodChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.CatheterInsertionMethod != event) {
            this._HemodialysisOrderDetail.CatheterInsertionMethod = event;
        }
    }

    public onCatheterTypeChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.CatheterType != event) {
            this._HemodialysisOrderDetail.CatheterType = event;
        }
    }

    public onDeviceChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Device != event) {
            this._HemodialysisOrderDetail.Device = event;
        }
    }

    public onDiagnosisChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Diagnosis != event) {
            this._HemodialysisOrderDetail.Diagnosis = event;
        }
    }

    public onDialysateTransferSpeedChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.DialysateTransferSpeed != event) {
            this._HemodialysisOrderDetail.DialysateTransferSpeed = event;
        }
    }

    public onDialysisFrequencyChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.DialysisFrequency != event) {
            this._HemodialysisOrderDetail.DialysisFrequency = event;
        }
    }

    public onDialysisTreatmentChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.DialysisTreatment != event) {
            this._HemodialysisOrderDetail.DialysisTreatment = event;
        }
    }

    public onDialysisTreatmentMethodChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.DialysisTreatmentMethod != event) {
            this._HemodialysisOrderDetail.DialysisTreatmentMethod = event;
        }
    }

    public onDialyzatorAreaChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.DialyzatorArea != event) {
            this._HemodialysisOrderDetail.DialyzatorArea = event;
        }
    }

    public onDialyzatorTypeChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.DialyzatorType != event) {
            this._HemodialysisOrderDetail.DialyzatorType = event;
        }
    }

    public onDoctorChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Doctor != event) {
            this._HemodialysisOrderDetail.Doctor = event;
        }
    }

    public onEtiologyChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Etiology != event) {
            this._HemodialysisOrderDetail.Etiology = event;
        }
    }

    public onGeneralInfoChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.GeneralInfo != event) {
            this._HemodialysisOrderDetail.GeneralInfo = event;
        }
    }

    public onHeparinizationChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Heparinization != event) {
            this._HemodialysisOrderDetail.Heparinization = event;
        }
    }

    public onHepatitisChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Hepatitis != event) {
            this._HemodialysisOrderDetail.Hepatitis = event;
        }
    }

    public onInformationChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Information != event) {
            this._HemodialysisOrderDetail.Information = event;
        }
    }

    public onIntravenousChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Intravenous != event) {
            this._HemodialysisOrderDetail.Intravenous = event;
            if (this._HemodialysisOrderDetail.Intravenous != null && this._HemodialysisOrderDetail.Intravenous.KODU == "1") {
                this.AVFCare.ReadOnly = false;//Hastanın damar erişim yolu SKRS üzerinde 1 seçili ise AVF bakım yapıldı checkbox ı seçim için aktif olmalı.
            } else {
                this.AVFCare.ReadOnly = true;//Hastanın damar erişim yolu SKRS üzerinde 1 seçili değilse AVF bakım yapıldı checkbox ı pasif olmalı.
            }

            if (this._HemodialysisOrderDetail.Intravenous != null && (this._HemodialysisOrderDetail.Intravenous.KODU == "3" || this._HemodialysisOrderDetail.Intravenous.KODU == "4")) {
                this.CatheterCare.ReadOnly = false;//Hastanın damar erişim yolu SKRS üzerinde 3 – 4 seçili ise Katater bakımı yapıldı checkbox ı seçim için aktif olmalı. 
            } else {
                this.CatheterCare.ReadOnly = true;//Hastanın damar erişim yolu SKRS üzerinde 3 – 4 seçili değilse Katater bakımı yapıldı checkbox ı pasif olmalı. 
            }
        }
    }

    public onKtvChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Ktv != event) {
            this._HemodialysisOrderDetail.Ktv = event;
        }
    }

    public onLiquidCaChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.LiquidCa != event) {
            this._HemodialysisOrderDetail.LiquidCa = event;
        }
    }

    public onLiquidCH3COOChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.LiquidCH3COO != event) {
            this._HemodialysisOrderDetail.LiquidCH3COO = event;
        }
    }

    public onLiquidChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Liquid != event) {
            this._HemodialysisOrderDetail.Liquid = event;
        }
    }

    public onLiquidClChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.LiquidCl != event) {
            this._HemodialysisOrderDetail.LiquidCl = event;
        }
    }

    public onLiquidHCO3Changed(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.LiquidHCO3 != event) {
            this._HemodialysisOrderDetail.LiquidHCO3 = event;
        }
    }

    public onLiquidKChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.LiquidK != event) {
            this._HemodialysisOrderDetail.LiquidK = event;
        }
    }

    public onLiquidMgChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.LiquidMg != event) {
            this._HemodialysisOrderDetail.LiquidMg = event;
        }
    }

    public onLiquidNaChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.LiquidNa != event) {
            this._HemodialysisOrderDetail.LiquidNa = event;
        }
    }

    public onNurseChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Nurse != event) {
            this._HemodialysisOrderDetail.Nurse = event;
        }
    }

    public onPeritonealComplicationChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.PeritonealComplication != event) {
            this._HemodialysisOrderDetail.PeritonealComplication = event;
        }
    }

    public onPeritonealDialysisTunnelChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.PeritonealDialysisTunnel != event) {
            this._HemodialysisOrderDetail.PeritonealDialysisTunnel = event;
        }
    }

    public onPETChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.PET != event) {
            this._HemodialysisOrderDetail.PET = event;
        }
    }

    public onPhosphorusAgentChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.PhosphorusAgent != event) {
            this._HemodialysisOrderDetail.PhosphorusAgent = event;
        }
    }

    public onPreviousRRTChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.PreviousRRT != event) {
            this._HemodialysisOrderDetail.PreviousRRT = event;
        }
    }

    public onSessionDateChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.SessionDate != event) {
            this._HemodialysisOrderDetail.SessionDate = event;
        }
    }

    public onSessionFinishTimeChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.SessionFinishTime != event) {
            this._HemodialysisOrderDetail.SessionFinishTime = event;
        }
    }

    public onSessionStartTimeChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.SessionStartTime != event) {
            this._HemodialysisOrderDetail.SessionStartTime = event;
        }
    }

    public onSinekalsetUsageChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.SinekalsetUsage != event) {
            this._HemodialysisOrderDetail.SinekalsetUsage = event;
        }
    }

    public onSuggestionsChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.Suggestions != event) {
            this._HemodialysisOrderDetail.Suggestions = event;
        }
    }

    public onTreatmentCourseChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.TreatmentCourse != event) {
            this._HemodialysisOrderDetail.TreatmentCourse = event;
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.SessionDate != event) {
            this._HemodialysisOrderDetail.SessionDate = event;
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.DialysisFrequency != event) {
            this._HemodialysisOrderDetail.DialysisFrequency = event;
        }
    }

    public onURRChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.URR != event) {
            this._HemodialysisOrderDetail.URR = event;
        }
    }

    public onVitaminDusageChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.VitaminDusage != event) {
            this._HemodialysisOrderDetail.VitaminDusage = event;
        }
    }

    public onWeightAfterChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.WeightAfter != event) {
            this._HemodialysisOrderDetail.WeightAfter = event;
        }
    }

    public onWeightBeforeChanged(event): void {
        if (this._HemodialysisOrderDetail != null && this._HemodialysisOrderDetail.WeightBefore != event) {
            this._HemodialysisOrderDetail.WeightBefore = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.SessionDate, "Value", this.__ttObject, "SessionDate");
        redirectProperty(this.Etiology, "Text", this.__ttObject, "Etiology");
        redirectProperty(this.Diagnosis, "Text", this.__ttObject, "Diagnosis");
        redirectProperty(this.Suggestions, "Text", this.__ttObject, "Suggestions");
        redirectProperty(this.Hepatitis, "Text", this.__ttObject, "Hepatitis");
        redirectProperty(this.Heparinization, "Text", this.__ttObject, "Heparinization");
        redirectProperty(this.Allergy, "Text", this.__ttObject, "Allergy");
        redirectProperty(this.GeneralInfo, "Text", this.__ttObject, "GeneralInfo");
        redirectProperty(this.LiquidNa, "Text", this.__ttObject, "LiquidNa");
        redirectProperty(this.LiquidCl, "Text", this.__ttObject, "LiquidCl");
        redirectProperty(this.LiquidK, "Text", this.__ttObject, "LiquidK");
        redirectProperty(this.LiquidCH3COO, "Text", this.__ttObject, "LiquidCH3COO");
        redirectProperty(this.LiquidCa, "Text", this.__ttObject, "LiquidCa");
        redirectProperty(this.LiquidHCO3, "Text", this.__ttObject, "LiquidHCO3");
        redirectProperty(this.LiquidMg, "Text", this.__ttObject, "LiquidMg");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "SessionDate");
        redirectProperty(this.Liquid, "Text", this.__ttObject, "Liquid");
        redirectProperty(this.WeightBefore, "Text", this.__ttObject, "WeightBefore");
        redirectProperty(this.SessionStartTime, "Value", this.__ttObject, "SessionStartTime");
        redirectProperty(this.SessionFinishTime, "Value", this.__ttObject, "SessionFinishTime");
        redirectProperty(this.DialysateTransferSpeed, "Text", this.__ttObject, "DialysateTransferSpeed");
        redirectProperty(this.WeightAfter, "Text", this.__ttObject, "WeightAfter");
        redirectProperty(this.Device, "Text", this.__ttObject, "Device");
        redirectProperty(this.CatheterCare, "Value", this.__ttObject, "CatheterCare");
        redirectProperty(this.AVFCare, "Value", this.__ttObject, "AVFCare");
        redirectProperty(this.Information, "Text", this.__ttObject, "Information");
        redirectProperty(this.BunPre, "Text", this.__ttObject, "BunPre");
        redirectProperty(this.BunPost, "Text", this.__ttObject, "BunPost");
        redirectProperty(this.URR, "Text", this.__ttObject, "URR");
        redirectProperty(this.Ktv, "Text", this.__ttObject, "Ktv");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 0;

        this.tabGenelBilgiler = new TTVisual.TTTabPage();
        this.tabGenelBilgiler.DisplayIndex = 0;
        this.tabGenelBilgiler.TabIndex = 0;
        this.tabGenelBilgiler.Text = "Genel Bilgiler";
        this.tabGenelBilgiler.Name = "tabGenelBilgiler";

        this.labelAntihypertensive = new TTVisual.TTLabel();
        this.labelAntihypertensive.Text = "Antihipertansif İlaç Kullanımı";
        this.labelAntihypertensive.Name = "labelAntihypertensive";
        this.labelAntihypertensive.TabIndex = 39;

        this.Antihypertensive = new TTVisual.TTObjectListBox();
        this.Antihypertensive.ListDefName = "";
        this.Antihypertensive.Name = "Antihypertensive";
        this.Antihypertensive.TabIndex = 38;

        this.labelPeritonealComplication = new TTVisual.TTLabel();
        this.labelPeritonealComplication.Text = "Periton Diyaliz Komplikasyon";
        this.labelPeritonealComplication.Name = "labelPeritonealComplication";
        this.labelPeritonealComplication.TabIndex = 37;

        this.PeritonealComplication = new TTVisual.TTObjectListBox();
        this.PeritonealComplication.ListDefName = "SKRSPeritonDiyaliziKomplikasyonList";
        this.PeritonealComplication.Name = "PeritonealComplication";
        this.PeritonealComplication.TabIndex = 36;

        this.labelPeritonealDialysisTunnel = new TTVisual.TTLabel();
        this.labelPeritonealDialysisTunnel.Text = "Periton Diyaliz Tünel Yönü";
        this.labelPeritonealDialysisTunnel.Name = "labelPeritonealDialysisTunnel";
        this.labelPeritonealDialysisTunnel.TabIndex = 35;

        this.PeritonealDialysisTunnel = new TTVisual.TTObjectListBox();
        this.PeritonealDialysisTunnel.ListDefName = "SKRSPeritonDiyalizTunelYonuList";
        this.PeritonealDialysisTunnel.Name = "PeritonealDialysisTunnel";
        this.PeritonealDialysisTunnel.TabIndex = 34;

        this.labelCatheterInsertionMethod = new TTVisual.TTLabel();
        this.labelCatheterInsertionMethod.Text = "Periton Diyaliz Kateter Yerleştirme Yöntemi";
        this.labelCatheterInsertionMethod.Name = "labelCatheterInsertionMethod";
        this.labelCatheterInsertionMethod.TabIndex = 33;

        this.CatheterInsertionMethod = new TTVisual.TTObjectListBox();
        this.CatheterInsertionMethod.ListDefName = "SKRSPeritonDiyalizKateterYerlestirmeYontemiList";
        this.CatheterInsertionMethod.Name = "CatheterInsertionMethod";
        this.CatheterInsertionMethod.TabIndex = 32;

        this.labelCatheterType = new TTVisual.TTLabel();
        this.labelCatheterType.Text = "Periton Diyalizi Kateter Tipi";
        this.labelCatheterType.Name = "labelCatheterType";
        this.labelCatheterType.TabIndex = 31;

        this.CatheterType = new TTVisual.TTObjectListBox();
        this.CatheterType.ListDefName = "SKRSPeritonDiyaliziKateterTipiList";
        this.CatheterType.Name = "CatheterType";
        this.CatheterType.TabIndex = 30;

        this.labelDialysisTreatment = new TTVisual.TTLabel();
        this.labelDialysisTreatment.Text = "Kullanılan Diyaliz Tedavisi";
        this.labelDialysisTreatment.Name = "labelDialysisTreatment";
        this.labelDialysisTreatment.TabIndex = 29;

        this.DialysisTreatment = new TTVisual.TTObjectListBox();
        this.DialysisTreatment.ListDefName = "SKRSKullanilanDiyalizTedavisiList";
        this.DialysisTreatment.Name = "DialysisTreatment";
        this.DialysisTreatment.TabIndex = 28;

        this.labelCatheter = new TTVisual.TTLabel();
        this.labelCatheter.Text = "Katater";
        this.labelCatheter.Name = "labelCatheter";
        this.labelCatheter.TabIndex = 27;

        this.Catheter = new TTVisual.TTObjectListBox();
        this.Catheter.ListDefName = "SKRSKATATERList";
        this.Catheter.Name = "Catheter";
        this.Catheter.TabIndex = 26;

        this.labelPET = new TTVisual.TTLabel();
        this.labelPET.Text = "Peritoneal Gecirgenlik (PET)";
        this.labelPET.Name = "labelPET";
        this.labelPET.TabIndex = 25;

        this.PET = new TTVisual.TTObjectListBox();
        this.PET.ListDefName = "SKRSPeritonealGecirgenlikPETList";
        this.PET.Name = "PET";
        this.PET.TabIndex = 24;

        this.labelSinekalsetUsage = new TTVisual.TTLabel();
        this.labelSinekalsetUsage.Text = "Sinekalset Kullanımı";
        this.labelSinekalsetUsage.Name = "labelSinekalsetUsage";
        this.labelSinekalsetUsage.TabIndex = 23;

        this.SinekalsetUsage = new TTVisual.TTObjectListBox();
        this.SinekalsetUsage.ListDefName = "SKRSSinekalsetList";
        this.SinekalsetUsage.Name = "SinekalsetUsage";
        this.SinekalsetUsage.TabIndex = 22;

        this.labelPreviousRRT = new TTVisual.TTLabel();
        this.labelPreviousRRT.Text = "Önceki RRT Yöntemi";
        this.labelPreviousRRT.Name = "labelPreviousRRT";
        this.labelPreviousRRT.TabIndex = 21;

        this.PreviousRRT = new TTVisual.TTObjectListBox();
        this.PreviousRRT.ListDefName = "SKRSOncekiRRTYontemiList";
        this.PreviousRRT.Name = "PreviousRRT";
        this.PreviousRRT.TabIndex = 20;

        this.labelPhosphorusAgent = new TTVisual.TTLabel();
        this.labelPhosphorusAgent.Text = "Fosfor Bağlayıcı Ajan";
        this.labelPhosphorusAgent.Name = "labelPhosphorusAgent";
        this.labelPhosphorusAgent.TabIndex = 19;

        this.PhosphorusAgent = new TTVisual.TTObjectListBox();
        this.PhosphorusAgent.ListDefName = "SKRSFosforBaglayiciAjanList";
        this.PhosphorusAgent.Name = "PhosphorusAgent";
        this.PhosphorusAgent.TabIndex = 18;

        this.labelDialysisFrequency = new TTVisual.TTLabel();
        this.labelDialysisFrequency.Text = "Diyalize Girme Sıklığı";
        this.labelDialysisFrequency.Name = "labelDialysisFrequency";
        this.labelDialysisFrequency.TabIndex = 17;

        this.DialysisFrequency = new TTVisual.TTObjectListBox();
        this.DialysisFrequency.ListDefName = "SKRSDiyalizeGirmeSikligiList";
        this.DialysisFrequency.Name = "DialysisFrequency";
        this.DialysisFrequency.TabIndex = 16;
        this.DialysisFrequency.Required = true;

        this.labelSuggestions = new TTVisual.TTLabel();
        this.labelSuggestions.Text = "Öneriler";
        this.labelSuggestions.Name = "labelSuggestions";
        this.labelSuggestions.TabIndex = 15;

        this.Suggestions = new TTVisual.TTTextBox();
        this.Suggestions.Name = "Suggestions";
        this.Suggestions.TabIndex = 14;

        this.labelSessionDate = new TTVisual.TTLabel();
        this.labelSessionDate.Text = "Diyalize BaşlamaTarihi";
        this.labelSessionDate.Name = "labelSessionDate";
        this.labelSessionDate.TabIndex = 13;

        this.SessionDate = new TTVisual.TTDateTimePicker();
        this.SessionDate.Format = DateTimePickerFormat.Long;
        this.SessionDate.Name = "SessionDate";
        this.SessionDate.TabIndex = 12;

        this.labelHepatitis = new TTVisual.TTLabel();
        this.labelHepatitis.Text = "Hepatit Açıklama";
        this.labelHepatitis.Name = "labelHepatitis";
        this.labelHepatitis.TabIndex = 11;

        this.Hepatitis = new TTVisual.TTTextBox();
        this.Hepatitis.Name = "Hepatitis";
        this.Hepatitis.TabIndex = 10;

        this.labelHeparinization = new TTVisual.TTLabel();
        this.labelHeparinization.Text = "Heparinizasyon";
        this.labelHeparinization.Name = "labelHeparinization";
        this.labelHeparinization.TabIndex = 9;

        this.Heparinization = new TTVisual.TTTextBox();
        this.Heparinization.Name = "Heparinization";
        this.Heparinization.TabIndex = 8;

        this.labelGeneralInfo = new TTVisual.TTLabel();
        this.labelGeneralInfo.Text = "Açıklama";
        this.labelGeneralInfo.Name = "labelGeneralInfo";
        this.labelGeneralInfo.TabIndex = 7;

        this.GeneralInfo = new TTVisual.TTTextBox();
        this.GeneralInfo.Name = "GeneralInfo";
        this.GeneralInfo.TabIndex = 6;

        this.labelEtiology = new TTVisual.TTLabel();
        this.labelEtiology.Text = "Etiyolojisi";
        this.labelEtiology.Name = "labelEtiology";
        this.labelEtiology.TabIndex = 5;

        this.Etiology = new TTVisual.TTTextBox();
        this.Etiology.Name = "Etiology";
        this.Etiology.TabIndex = 4;

        this.labelDiagnosis = new TTVisual.TTLabel();
        this.labelDiagnosis.Text = "Tanı Açıklama";
        this.labelDiagnosis.Name = "labelDiagnosis";
        this.labelDiagnosis.TabIndex = 3;

        this.Diagnosis = new TTVisual.TTTextBox();
        this.Diagnosis.Name = "Diagnosis";
        this.Diagnosis.TabIndex = 2;

        this.labelAllergy = new TTVisual.TTLabel();
        this.labelAllergy.Text = "Alerji";
        this.labelAllergy.Name = "labelAllergy";
        this.labelAllergy.TabIndex = 1;

        this.Allergy = new TTVisual.TTTextBox();
        this.Allergy.Name = "Allergy";
        this.Allergy.TabIndex = 0;

        this.tabSeansBilgileri = new TTVisual.TTTabPage();
        this.tabSeansBilgileri.DisplayIndex = 1;
        this.tabSeansBilgileri.TabIndex = 1;
        this.tabSeansBilgileri.Text = "Seans Bilgileri";
        this.tabSeansBilgileri.Name = "tabSeansBilgileri";

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = "Diyaliz Sıvısı";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 51;

        this.LiquidNa = new TTVisual.TTTextBox();
        this.LiquidNa.Name = "LiquidNa";
        this.LiquidNa.TabIndex = 22;

        this.labelLiquidNa = new TTVisual.TTLabel();
        this.labelLiquidNa.Text = "Na";
        this.labelLiquidNa.Name = "labelLiquidNa";
        this.labelLiquidNa.TabIndex = 23;

        this.labelLiquidK = new TTVisual.TTLabel();
        this.labelLiquidK.Text = "K";
        this.labelLiquidK.Name = "labelLiquidK";
        this.labelLiquidK.TabIndex = 19;

        this.LiquidK = new TTVisual.TTTextBox();
        this.LiquidK.Name = "LiquidK";
        this.LiquidK.TabIndex = 18;

        this.LiquidCa = new TTVisual.TTTextBox();
        this.LiquidCa.Name = "LiquidCa";
        this.LiquidCa.TabIndex = 10;

        this.labelLiquidCa = new TTVisual.TTLabel();
        this.labelLiquidCa.Text = "Ca";
        this.labelLiquidCa.Name = "labelLiquidCa";
        this.labelLiquidCa.TabIndex = 11;

        this.labelLiquidMg = new TTVisual.TTLabel();
        this.labelLiquidMg.Text = "Mg";
        this.labelLiquidMg.Name = "labelLiquidMg";
        this.labelLiquidMg.TabIndex = 21;

        this.LiquidMg = new TTVisual.TTTextBox();
        this.LiquidMg.Name = "LiquidMg";
        this.LiquidMg.TabIndex = 20;

        this.LiquidCl = new TTVisual.TTTextBox();
        this.LiquidCl.Name = "LiquidCl";
        this.LiquidCl.TabIndex = 14;

        this.labelLiquidCl = new TTVisual.TTLabel();
        this.labelLiquidCl.Text = "Cl";
        this.labelLiquidCl.Name = "labelLiquidCl";
        this.labelLiquidCl.TabIndex = 15;

        this.LiquidCH3COO = new TTVisual.TTTextBox();
        this.LiquidCH3COO.Name = "LiquidCH3COO";
        this.LiquidCH3COO.TabIndex = 12;

        this.labelLiquidCH3COO = new TTVisual.TTLabel();
        this.labelLiquidCH3COO.Text = "CH3COO";
        this.labelLiquidCH3COO.Name = "labelLiquidCH3COO";
        this.labelLiquidCH3COO.TabIndex = 13;

        this.LiquidHCO3 = new TTVisual.TTTextBox();
        this.LiquidHCO3.Name = "LiquidHCO3";
        this.LiquidHCO3.TabIndex = 16;

        this.labelLiquidHCO3 = new TTVisual.TTLabel();
        this.labelLiquidHCO3.Text = "HCO3";
        this.labelLiquidHCO3.Name = "labelLiquidHCO3";
        this.labelLiquidHCO3.TabIndex = 17;

        this.ttlabel26 = new TTVisual.TTLabel();
        this.ttlabel26.Text = "Ateş";
        this.ttlabel26.Name = "ttlabel26";
        this.ttlabel26.TabIndex = 50;

        this.ttlabel25 = new TTVisual.TTLabel();
        this.ttlabel25.Text = "Nabız";
        this.ttlabel25.Name = "ttlabel25";
        this.ttlabel25.TabIndex = 49;

        this.ttlabel24 = new TTVisual.TTLabel();
        this.ttlabel24.Text = "Servis";
        this.ttlabel24.Name = "ttlabel24";
        this.ttlabel24.TabIndex = 48;

        this.labelBloodFlow = new TTVisual.TTLabel();
        this.labelBloodFlow.Text = "Kan Akım Hız Aralığı (ml/dk)";
        this.labelBloodFlow.Name = "labelBloodFlow";
        this.labelBloodFlow.TabIndex = 47;

        this.BloodFlow = new TTVisual.TTObjectListBox();
        this.BloodFlow.ListDefName = "SKRSKanAkimHiziList";
        this.BloodFlow.Name = "BloodFlow";
        this.BloodFlow.TabIndex = 46;

        this.labelDialyzatorArea = new TTVisual.TTLabel();
        this.labelDialyzatorArea.Text = "Diyalizör Alanı";
        this.labelDialyzatorArea.Name = "labelDialyzatorArea";
        this.labelDialyzatorArea.TabIndex = 45;

        this.DialyzatorArea = new TTVisual.TTObjectListBox();
        this.DialyzatorArea.ListDefName = "SKRSDiyalizorAlaniList";
        this.DialyzatorArea.Name = "DialyzatorArea";
        this.DialyzatorArea.TabIndex = 44;

        this.labelDialyzatorType = new TTVisual.TTLabel();
        this.labelDialyzatorType.Text = "Diyalizör Tipi";
        this.labelDialyzatorType.Name = "labelDialyzatorType";
        this.labelDialyzatorType.TabIndex = 43;

        this.DialyzatorType = new TTVisual.TTObjectListBox();
        this.DialyzatorType.ListDefName = "SKRSDiyalizorTipiList";
        this.DialyzatorType.Name = "DialyzatorType";
        this.DialyzatorType.TabIndex = 42;

        this.labelIntravenous = new TTVisual.TTLabel();
        this.labelIntravenous.Text = "Damar Yolu";
        this.labelIntravenous.Name = "labelIntravenous";
        this.labelIntravenous.TabIndex = 41;

        this.Intravenous = new TTVisual.TTObjectListBox();
        this.Intravenous.ListDefName = "SKRSDamarErisimYoluList";
        this.Intravenous.Name = "Intravenous";
        this.Intravenous.TabIndex = 40;

        this.labelCareNurse = new TTVisual.TTLabel();
        this.labelCareNurse.Text = "Destek Tedavi Hemşiresi";
        this.labelCareNurse.Name = "labelCareNurse";
        this.labelCareNurse.TabIndex = 39;

        this.CareNurse = new TTVisual.TTObjectListBox();
        this.CareNurse.ListDefName = "DoctorAndNurseList";
        this.CareNurse.Name = "CareNurse";
        this.CareNurse.TabIndex = 38;

        this.labelNurse = new TTVisual.TTLabel();
        this.labelNurse.Text = "Hemşire";
        this.labelNurse.Name = "labelNurse";
        this.labelNurse.TabIndex = 37;

        this.Nurse = new TTVisual.TTObjectListBox();
        this.Nurse.ListDefName = "DoctorAndNurseList";
        this.Nurse.Name = "Nurse";
        this.Nurse.TabIndex = 36;

        this.labelDoctor = new TTVisual.TTLabel();
        this.labelDoctor.Text = "Doktor";
        this.labelDoctor.Name = "labelDoctor";
        this.labelDoctor.TabIndex = 35;

        this.Doctor = new TTVisual.TTObjectListBox();
        this.Doctor.ListDefName = "DoktorDefinitionList";
        this.Doctor.Name = "Doctor";
        this.Doctor.TabIndex = 34;

        this.labelWeightBefore = new TTVisual.TTLabel();
        this.labelWeightBefore.Text = "Seans Öncesi Ağırlık (KG)";
        this.labelWeightBefore.Name = "labelWeightBefore";
        this.labelWeightBefore.TabIndex = 33;

        this.WeightBefore = new TTVisual.TTTextBox();
        this.WeightBefore.Name = "WeightBefore";
        this.WeightBefore.TabIndex = 32;

        this.labelWeightAfter = new TTVisual.TTLabel();
        this.labelWeightAfter.Text = "Seans Sonrası Ağırlık (KG)";
        this.labelWeightAfter.Name = "labelWeightAfter";
        this.labelWeightAfter.TabIndex = 31;

        this.WeightAfter = new TTVisual.TTTextBox();
        this.WeightAfter.Name = "WeightAfter";
        this.WeightAfter.TabIndex = 30;

        this.labelSessionStartTime = new TTVisual.TTLabel();
        this.labelSessionStartTime.Text = "Seans Başlangıç Saati";
        this.labelSessionStartTime.Name = "labelSessionStartTime";
        this.labelSessionStartTime.TabIndex = 29;

        this.SessionStartTime = new TTVisual.TTDateTimePicker();
        this.SessionStartTime.Format = DateTimePickerFormat.Long;
        this.SessionStartTime.Name = "SessionStartTime";
        this.SessionStartTime.TabIndex = 28;

        this.labelSessionFinishTime = new TTVisual.TTLabel();
        this.labelSessionFinishTime.Text = "Seans Bitiş Saati";
        this.labelSessionFinishTime.Name = "labelSessionFinishTime";
        this.labelSessionFinishTime.TabIndex = 27;

        this.SessionFinishTime = new TTVisual.TTDateTimePicker();
        this.SessionFinishTime.Format = DateTimePickerFormat.Long;
        this.SessionFinishTime.Name = "SessionFinishTime";
        this.SessionFinishTime.TabIndex = 26;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Diyalize BaşlamaTarihi";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 25;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 24;

        this.labelLiquid = new TTVisual.TTLabel();
        this.labelLiquid.Text = "Çekilecek Sıvı (ml)";
        this.labelLiquid.Name = "labelLiquid";
        this.labelLiquid.TabIndex = 9;

        this.Liquid = new TTVisual.TTTextBox();
        this.Liquid.Name = "Liquid";
        this.Liquid.TabIndex = 8;

        this.labelInformation = new TTVisual.TTLabel();
        this.labelInformation.Text = "Seans Açıklama";
        this.labelInformation.Name = "labelInformation";
        this.labelInformation.TabIndex = 7;

        this.Information = new TTVisual.TTTextBox();
        this.Information.Name = "Information";
        this.Information.TabIndex = 6;

        this.labelDialysateTransferSpeed = new TTVisual.TTLabel();
        this.labelDialysateTransferSpeed.Text = "Diyalizat Aktarım Hızı";
        this.labelDialysateTransferSpeed.Name = "labelDialysateTransferSpeed";
        this.labelDialysateTransferSpeed.TabIndex = 5;

        this.DialysateTransferSpeed = new TTVisual.TTTextBox();
        this.DialysateTransferSpeed.Name = "DialysateTransferSpeed";
        this.DialysateTransferSpeed.TabIndex = 4;

        this.labelDevice = new TTVisual.TTLabel();
        this.labelDevice.Text = "Cihaz";
        this.labelDevice.Name = "labelDevice";
        this.labelDevice.TabIndex = 3;

        this.Device = new TTVisual.TTTextBox();
        this.Device.Name = "Device";
        this.Device.TabIndex = 2;

        this.CatheterCare = new TTVisual.TTCheckBox();
        this.CatheterCare.Value = false;
        this.CatheterCare.Text = "Katater Bakımı Yapıldı mı?";
        this.CatheterCare.Title = "Katater Bakımı Yapıldı mı?";
        this.CatheterCare.Name = "CatheterCare";
        this.CatheterCare.TabIndex = 1;
        this.CatheterCare.ReadOnly = true;

        this.AVFCare = new TTVisual.TTCheckBox();
        this.AVFCare.Value = false;
        this.AVFCare.Text = "AVF Bakımı Yapıldı mı?";
        this.AVFCare.Title = "AVF Bakımı Yapıldı mı?";
        this.AVFCare.Name = "AVFCare";
        this.AVFCare.TabIndex = 0;
        this.AVFCare.ReadOnly = true;

        this.tabSaglikNet = new TTVisual.TTTabPage();
        this.tabSaglikNet.DisplayIndex = 2;
        this.tabSaglikNet.TabIndex = 2;
        this.tabSaglikNet.Text = "Sağlık Net / Kt/V";
        this.tabSaglikNet.Name = "tabSaglikNet";

        this.grpKtv = new TTVisual.TTGroupBox();
        this.grpKtv.Text = "Kt/V";
        this.grpKtv.Name = "grpKtv";
        this.grpKtv.TabIndex = 19;

        this.labelURR = new TTVisual.TTLabel();
        this.labelURR.Text = "URR";
        this.labelURR.Name = "labelURR";
        this.labelURR.TabIndex = 21;

        this.labelBunPre = new TTVisual.TTLabel();
        this.labelBunPre.Text = "BUN Pre";
        this.labelBunPre.Name = "labelBunPre";
        this.labelBunPre.TabIndex = 3;

        this.labelKtv = new TTVisual.TTLabel();
        this.labelKtv.Text = "Kt/V";
        this.labelKtv.Name = "labelKtv";
        this.labelKtv.TabIndex = 5;

        this.Ktv = new TTVisual.TTTextBox();
        this.Ktv.Name = "Ktv";
        this.Ktv.TabIndex = 4;
        this.Ktv.Required = true;

        this.URR = new TTVisual.TTTextBox();
        this.URR.Name = "URR";
        this.URR.TabIndex = 20;
        this.URR.Required = true;

        this.BunPre = new TTVisual.TTTextBox();
        this.BunPre.Name = "BunPre";
        this.BunPre.TabIndex = 2;
        this.BunPre.Required = true;

        this.labelBunPost = new TTVisual.TTLabel();
        this.labelBunPost.Text = "BUN Post";
        this.labelBunPost.Name = "labelBunPost";
        this.labelBunPost.TabIndex = 1;

        this.BunPost = new TTVisual.TTTextBox();
        this.BunPost.Name = "BunPost";
        this.BunPost.TabIndex = 0;
        this.BunPost.Required = true;

        this.grpSaglikNet = new TTVisual.TTGroupBox();
        this.grpSaglikNet.Text = "Sağlık Net";
        this.grpSaglikNet.Name = "grpSaglikNet";
        this.grpSaglikNet.TabIndex = 18;

        this.DialysisTreatmentMethod = new TTVisual.TTObjectListBox();
        this.DialysisTreatmentMethod.ListDefName = "SKRSDiyalizTedavisiYontemiList";
        this.DialysisTreatmentMethod.Name = "DialysisTreatmentMethod";
        this.DialysisTreatmentMethod.TabIndex = 10;
        this.DialysisTreatmentMethod.Required = true;

        this.labelTreatmentCourse = new TTVisual.TTLabel();
        this.labelTreatmentCourse.Text = "Tedavinin Seyri";
        this.labelTreatmentCourse.Name = "labelTreatmentCourse";
        this.labelTreatmentCourse.TabIndex = 17;

        this.TreatmentCourse = new TTVisual.TTObjectListBox();
        this.TreatmentCourse.ListDefName = "SKRSTedavininSeyriList";
        this.TreatmentCourse.Name = "TreatmentCourse";
        this.TreatmentCourse.TabIndex = 16;
        this.TreatmentCourse.Required = true;

        this.labelDialysisTreatmentMethod = new TTVisual.TTLabel();
        this.labelDialysisTreatmentMethod.Text = "Diyaliz Tedavi Yöntemi";
        this.labelDialysisTreatmentMethod.Name = "labelDialysisTreatmentMethod";
        this.labelDialysisTreatmentMethod.TabIndex = 11;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "SKRSDiyalizeGirmeSikligiList";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 8;

        this.labelVitaminDusage = new TTVisual.TTLabel();
        this.labelVitaminDusage.Text = "Aktif Vitamin D Kullanımı";
        this.labelVitaminDusage.Name = "labelVitaminDusage";
        this.labelVitaminDusage.TabIndex = 15;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Diyalize Girme Sıklığı";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 9;

        this.VitaminDusage = new TTVisual.TTObjectListBox();
        this.VitaminDusage.ListDefName = "SKRSAktifVitaminDKullanimiList";
        this.VitaminDusage.Name = "VitaminDusage";
        this.VitaminDusage.TabIndex = 14;
        this.VitaminDusage.Required = true;

        this.AnemiaTreatmentMethod = new TTVisual.TTObjectListBox();
        this.AnemiaTreatmentMethod.ListDefName = "SKRSAnemiTedavisiYontemiList";
        this.AnemiaTreatmentMethod.Name = "AnemiaTreatmentMethod";
        this.AnemiaTreatmentMethod.TabIndex = 12;
        this.AnemiaTreatmentMethod.Required = true;

        this.labelAnemiaTreatmentMethod = new TTVisual.TTLabel();
        this.labelAnemiaTreatmentMethod.Text = "Anemi Tedavi Yöntemi";
        this.labelAnemiaTreatmentMethod.Name = "labelAnemiaTreatmentMethod";
        this.labelAnemiaTreatmentMethod.TabIndex = 13;

        this.tttabcontrol1.Controls = [this.tabGenelBilgiler, this.tabSeansBilgileri, this.tabSaglikNet];
        this.tabGenelBilgiler.Controls = [this.labelAntihypertensive, this.Antihypertensive, this.labelPeritonealComplication, this.PeritonealComplication, this.labelPeritonealDialysisTunnel, this.PeritonealDialysisTunnel, this.labelCatheterInsertionMethod, this.CatheterInsertionMethod, this.labelCatheterType, this.CatheterType, this.labelDialysisTreatment, this.DialysisTreatment, this.labelCatheter, this.Catheter, this.labelPET, this.PET, this.labelSinekalsetUsage, this.SinekalsetUsage, this.labelPreviousRRT, this.PreviousRRT, this.labelPhosphorusAgent, this.PhosphorusAgent, this.labelDialysisFrequency, this.DialysisFrequency, this.labelSuggestions, this.Suggestions, this.labelSessionDate, this.SessionDate, this.labelHepatitis, this.Hepatitis, this.labelHeparinization, this.Heparinization, this.labelGeneralInfo, this.GeneralInfo, this.labelEtiology, this.Etiology, this.labelDiagnosis, this.Diagnosis, this.labelAllergy, this.Allergy];
        this.tabSeansBilgileri.Controls = [this.ttgroupbox1, this.ttlabel26, this.ttlabel25, this.ttlabel24, this.labelBloodFlow, this.BloodFlow, this.labelDialyzatorArea, this.DialyzatorArea, this.labelDialyzatorType, this.DialyzatorType, this.labelIntravenous, this.Intravenous, this.labelCareNurse, this.CareNurse, this.labelNurse, this.Nurse, this.labelDoctor, this.Doctor, this.labelWeightBefore, this.WeightBefore, this.labelWeightAfter, this.WeightAfter, this.labelSessionStartTime, this.SessionStartTime, this.labelSessionFinishTime, this.SessionFinishTime, this.ttlabel1, this.ttdatetimepicker1, this.labelLiquid, this.Liquid, this.labelInformation, this.Information, this.labelDialysateTransferSpeed, this.DialysateTransferSpeed, this.labelDevice, this.Device, this.CatheterCare, this.AVFCare];
        this.ttgroupbox1.Controls = [this.LiquidNa, this.labelLiquidNa, this.labelLiquidK, this.LiquidK, this.LiquidCa, this.labelLiquidCa, this.labelLiquidMg, this.LiquidMg, this.LiquidCl, this.labelLiquidCl, this.LiquidCH3COO, this.labelLiquidCH3COO, this.LiquidHCO3, this.labelLiquidHCO3];
        this.tabSaglikNet.Controls = [this.grpKtv, this.grpSaglikNet];
        this.grpKtv.Controls = [this.labelURR, this.labelBunPre, this.labelKtv, this.Ktv, this.URR, this.BunPre, this.labelBunPost, this.BunPost];
        this.grpSaglikNet.Controls = [this.DialysisTreatmentMethod, this.labelTreatmentCourse, this.TreatmentCourse, this.labelDialysisTreatmentMethod, this.ttobjectlistbox1, this.labelVitaminDusage, this.ttlabel2, this.VitaminDusage, this.AnemiaTreatmentMethod, this.labelAnemiaTreatmentMethod];
        this.Controls = [this.tttabcontrol1, this.tabGenelBilgiler, this.labelAntihypertensive, this.Antihypertensive, this.labelPeritonealComplication, this.PeritonealComplication, this.labelPeritonealDialysisTunnel, this.PeritonealDialysisTunnel, this.labelCatheterInsertionMethod, this.CatheterInsertionMethod, this.labelCatheterType, this.CatheterType, this.labelDialysisTreatment, this.DialysisTreatment, this.labelCatheter, this.Catheter, this.labelPET, this.PET, this.labelSinekalsetUsage, this.SinekalsetUsage, this.labelPreviousRRT, this.PreviousRRT, this.labelPhosphorusAgent, this.PhosphorusAgent, this.labelDialysisFrequency, this.DialysisFrequency, this.labelSuggestions, this.Suggestions, this.labelSessionDate, this.SessionDate, this.labelHepatitis, this.Hepatitis, this.labelHeparinization, this.Heparinization, this.labelGeneralInfo, this.GeneralInfo, this.labelEtiology, this.Etiology, this.labelDiagnosis, this.Diagnosis, this.labelAllergy, this.Allergy, this.tabSeansBilgileri, this.ttgroupbox1, this.LiquidNa, this.labelLiquidNa, this.labelLiquidK, this.LiquidK, this.LiquidCa, this.labelLiquidCa, this.labelLiquidMg, this.LiquidMg, this.LiquidCl, this.labelLiquidCl, this.LiquidCH3COO, this.labelLiquidCH3COO, this.LiquidHCO3, this.labelLiquidHCO3, this.ttlabel26, this.ttlabel25, this.ttlabel24, this.labelBloodFlow, this.BloodFlow, this.labelDialyzatorArea, this.DialyzatorArea, this.labelDialyzatorType, this.DialyzatorType, this.labelIntravenous, this.Intravenous, this.labelCareNurse, this.CareNurse, this.labelNurse, this.Nurse, this.labelDoctor, this.Doctor, this.labelWeightBefore, this.WeightBefore, this.labelWeightAfter, this.WeightAfter, this.labelSessionStartTime, this.SessionStartTime, this.labelSessionFinishTime, this.SessionFinishTime, this.ttlabel1, this.ttdatetimepicker1, this.labelLiquid, this.Liquid, this.labelInformation, this.Information, this.labelDialysateTransferSpeed, this.DialysateTransferSpeed, this.labelDevice, this.Device, this.CatheterCare, this.AVFCare, this.tabSaglikNet, this.grpKtv, this.labelURR, this.labelBunPre, this.labelKtv, this.Ktv, this.URR, this.BunPre, this.labelBunPost, this.BunPost, this.grpSaglikNet, this.DialysisTreatmentMethod, this.labelTreatmentCourse, this.TreatmentCourse, this.labelDialysisTreatmentMethod, this.ttobjectlistbox1, this.labelVitaminDusage, this.ttlabel2, this.VitaminDusage, this.AnemiaTreatmentMethod, this.labelAnemiaTreatmentMethod];

    }


}
