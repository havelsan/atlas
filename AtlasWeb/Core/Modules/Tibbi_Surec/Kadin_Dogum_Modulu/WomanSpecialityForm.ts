//$D67FCAB2
import { Component, OnInit, NgZone } from '@angular/core';
import { WomanSpecialityFormViewModel, WomanSpecialityObjectInfo } from './WomanSpecialityFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BloodGroupEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { SpecialityBasedObjectForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SpecialityBasedObjectForm";
import { VarYokGarantiEnum } from 'NebulaClient/Model/AtlasClientModel';
import { WomanSpecialityObject } from 'NebulaClient/Model/AtlasClientModel';
import { Gynecology } from 'NebulaClient/Model/AtlasClientModel';
import { ReproductiveAbnormalityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { plainToClass } from "NebulaClient/ClassTransformer";

import { InfertilityFormViewModel } from "./InfertilityFormViewModel";
import { InfertilityPatientInformationFormViewModel } from "./InfertilityPatientInformationFormViewModel";
import { PregnancyStartFormViewModel } from "./PregnancyStartFormViewModel";

import { PregnancyFollowFormViewModel } from "./PregnancyFollowFormViewModel";


import { PregnancyResultComponentInfoViewModel } from './PregnancyResultFormViewModel';
import { PregnancyResultForm } from './PregnancyResultForm';

import { PreviousPregnancyComponentInfoViewModel } from './PreviousPregnancyFormViewModel';
import { PreviousPregnancyForm } from './PreviousPregnancyForm';

//<atlas-form-editor  için
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
//

import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';

import { CommonService } from "ObjectClassService/CommonService";
import { PostpartumFollowUpFormViewModel } from "./PostpartumFollowUpFormViewModel";
import { IActiveTabService } from 'Fw/Services/IActiveTabService';

@Component({
    selector: 'WomanSpecialityForm',
    templateUrl: './WomanSpecialityForm.html',
    providers: [MessageService, NqlQueryService]
})
export class WomanSpecialityForm extends SpecialityBasedObjectForm implements OnInit {
    Abortion: TTVisual.ITTTextBox;
    BasalUltrasoundGynecology: TTVisual.ITTTextBox;
    btnPregnancyStart: TTVisual.ITTButton;
    CervixGynecology: TTVisual.ITTTextBox;
    CurrentBirthControlMethodGynecology: TTVisual.ITTEnumComboBox;
    DC: TTVisual.ITTTextBox;
    DegreeOfRelationship: TTVisual.ITTEnumComboBox;
    DyspareuniaGynecology: TTVisual.ITTCheckBox;
    DyspareuniaInformationGynecology: TTVisual.ITTTextBox;
    DysuriaGynecology: TTVisual.ITTCheckBox;
    DysuriaInformationGynecology: TTVisual.ITTTextBox;
    GenitalAbnormalitiesGynecology: TTVisual.ITTEnumComboBox;
    GenitalAbnormalitiesInfoGynecology: TTVisual.ITTTextBox;
    GenitalExaminationGynecology: TTVisual.ITTTextBox;
    gridPregnancyCalendar: TTVisual.ITTGrid;
    GynecologicalHistoryGynecology: TTVisual.ITTTextBox;
    HirsutismGynecology: TTVisual.ITTCheckBox;
    HirsutismInformationGynecology: TTVisual.ITTTextBox;
    HusbandBloodGroup: TTVisual.ITTEnumComboBox;
    HusbandFullName: TTVisual.ITTTextBox;
    labelAbortion: TTVisual.ITTLabel;
    labelBasalUltrasoundGynecology: TTVisual.ITTLabel;
    labelBloodGroup: TTVisual.ITTLabel;
    labelCervixGynecology: TTVisual.ITTLabel;
    labelCurrentBirthControlMethodGynecology: TTVisual.ITTLabel;
    labelDC: TTVisual.ITTLabel;
    labelDegreeOfRelationship: TTVisual.ITTLabel;
    labelDyspareuniaInformationGynecology: TTVisual.ITTLabel;
    labelDysuriaInformationGynecology: TTVisual.ITTLabel;
    labelGenitalAbnormalitiesGynecology: TTVisual.ITTLabel;
    labelGenitalAbnormalitiesInfoGynecology: TTVisual.ITTLabel;
    labelGenitalExaminationGynecology: TTVisual.ITTLabel;
    labelGynecologicalHistoryGynecology: TTVisual.ITTLabel;
    labelHirsutismInformationGynecology: TTVisual.ITTLabel;
    labelHusbandBloodGroup: TTVisual.ITTLabel;
    labelHusbandFullName: TTVisual.ITTLabel;
    labelLastExaminationDateGynecology: TTVisual.ITTLabel;
    labelLastSmearDateGynecology: TTVisual.ITTLabel;
    labelLivingBabies: TTVisual.ITTLabel;
    labelMarriageDate: TTVisual.ITTLabel;
    labelMarriageDuration: TTVisual.ITTLabel;
    labelMenstrualCycleAbnormalitiesGynecology: TTVisual.ITTLabel;
    labelMenstrualCycleInformationGynecology: TTVisual.ITTLabel;
    labelNumberOfPregnancy: TTVisual.ITTLabel;
    labelParity: TTVisual.ITTLabel;
    labelPelvicExaminationGynecology: TTVisual.ITTLabel;
    labelPreviousBirthControlMethodGynecology: TTVisual.ITTLabel;
    labelReproductiveAbnormalitiesInfoGynecology: TTVisual.ITTLabel;
    labelReproductiveAbnormalityGynecology: TTVisual.ITTLabel;
    labelRhIncompatibility: TTVisual.ITTLabel;
    labelTumorMarkersGynecology: TTVisual.ITTLabel;
    labelUterusGynecology: TTVisual.ITTLabel;
    labelVaginalDischargeInformationGynecology: TTVisual.ITTLabel;
    labelVulvaVagenGynecology: TTVisual.ITTLabel;
    LastExaminationDateGynecology: TTVisual.ITTDateTimePicker;
    LastSmearDateGynecology: TTVisual.ITTDateTimePicker;
    LivingBabies: TTVisual.ITTTextBox;
    MarriageDate: TTVisual.ITTMaskedTextBox;
    MarriageDuration: TTVisual.ITTTextBox;
    MenstrualCycleAbnormalitiesGynecology: TTVisual.ITTEnumComboBox;
    MenstrualCycleInformationGynecology: TTVisual.ITTTextBox;
    NumberOfPregnancy: TTVisual.ITTTextBox;
    Parity: TTVisual.ITTTextBox;
    PelvicExaminationGynecology: TTVisual.ITTTextBox;
    PreviousBirthControlMethodGynecology: TTVisual.ITTEnumComboBox;
    ReproductiveAbnormalitiesInfoGynecology: TTVisual.ITTTextBox;
    ReproductiveAbnormalityGynecology: TTVisual.ITTObjectListBox;
    RhIncompatibility: TTVisual.ITTEnumComboBox;
    tabGynecology: TTVisual.ITTTabPage;
    tabInfertility: TTVisual.ITTTabPage;
    tabPregCalendar: TTVisual.ITTTabPage;
    tabPregnancy: TTVisual.ITTTabPage;
    ttbutton1: TTVisual.ITTButton;
    tttabcontrol1: TTVisual.ITTTabControl;
    TumorMarkersGynecology: TTVisual.ITTTextBox;
    UterusGynecology: TTVisual.ITTTextBox;
    VaginalDischargeGynecology: TTVisual.ITTCheckBox;
    VaginalDischargeInformationGynecology: TTVisual.ITTTextBox;
    VulvaVagenGynecology: TTVisual.ITTTextBox;
    WomanBloodGroup: TTVisual.ITTEnumComboBox;
    public gridPregnancyCalendarColumns = [];
    public womanSpecialityFormViewModel: WomanSpecialityFormViewModel = new WomanSpecialityFormViewModel();
    RecentActiveTab: string;
    ActivePage: string;


    public get _WomanSpecialityObject(): WomanSpecialityObject {
        return this._TTObject as WomanSpecialityObject;
    }
    private WomanSpecialityForm_DocumentUrl: string = '/api/WomanSpecialityObjectService/WomanSpecialityForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone,
        protected tabService: IActiveTabService,
        ) {
        super(httpService, messageService);
        this._DocumentServiceUrl = this.WomanSpecialityForm_DocumentUrl;
        this.rules = { "X": /^[0-9]{2}$/ };
        this.initViewModel();
        this.initFormControls();
    }

    TabPanelClick(source) {
        this.tabService.setActiveTab(source, 'wsf');
        this.RecentActiveTab = source;
    }


    // ***** Method declarations start *****
    _womanSpecialityObjectInfo: WomanSpecialityObjectInfo = new WomanSpecialityObjectInfo;
    rules: any;
    protected async PreScript() {
        super.PreScript();

        //Kan Uyuşmazlığı
        if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.WomanBloodGroup != null && this._WomanSpecialityObject.HusbandBloodGroup != null) {
            await WomanSpecialityForm.GetRhIncompatibility(Convert.ToInt32(this._WomanSpecialityObject.WomanBloodGroup.toString()), Convert.ToInt32(this._WomanSpecialityObject.HusbandBloodGroup.toString())).then(c => {
                this._WomanSpecialityObject.RhIncompatibility = c;
            });
        }
        else {
            this._WomanSpecialityObject.RhIncompatibility = null;
        }

        //Evlilik Senesi
        if (this.womanSpecialityFormViewModel._WomanSpecialityObject.MarriageDate && this.womanSpecialityFormViewModel._WomanSpecialityObject.MarriageDate.toString().length == 4) {
            WomanSpecialityForm.GetMarriageDuration(Convert.ToInt32(this.womanSpecialityFormViewModel._WomanSpecialityObject.MarriageDate)).then(c => {
                this.MarriageDuration.Text = c.toString();
            });
        }
        else {
            this.MarriageDuration.Text = "";
        }


        this._womanSpecialityObjectInfo.WomanSpecialityObject = this.womanSpecialityFormViewModel._WomanSpecialityObject;
        this._womanSpecialityObjectInfo.ActiveIDsModel = this.ActiveIDsModel;
    }

    public static async GetRhIncompatibility(motherGroup: number, fatherGroup: number): Promise<number> {
        let negativeGroups: Array<BloodGroupEnum> = new Array<BloodGroupEnum>();
        negativeGroups.push(BloodGroupEnum.ABNEGATIVE);
        negativeGroups.push(BloodGroupEnum.ANEGATIVE);
        negativeGroups.push(BloodGroupEnum.BNEGATIVE);
        negativeGroups.push(BloodGroupEnum.ONEGATIVE);
        let positiveGroups: Array<BloodGroupEnum> = new Array<BloodGroupEnum>();
        positiveGroups.push(BloodGroupEnum.ABPOSITIVE);
        positiveGroups.push(BloodGroupEnum.APOZITIVE);
        positiveGroups.push(BloodGroupEnum.BPOSITIVE);
        positiveGroups.push(BloodGroupEnum.OPOSITIVE);
        let result;
        if (negativeGroups.includes(motherGroup) && positiveGroups.includes(fatherGroup)) {
            result = VarYokGarantiEnum.V;
        }
        else {
            result = VarYokGarantiEnum.Y;
        }
        return result;
    }


    private static async GetMarriageDuration(yearOfMarriage: number): Promise<number> {
        let x = new Date().getFullYear();
        let marriageDuration: number = Convert.ToInt32(new Date().getFullYear()) - yearOfMarriage;
        return marriageDuration;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new WomanSpecialityObject();
        this.womanSpecialityFormViewModel = new WomanSpecialityFormViewModel();
        this._ViewModel = this.womanSpecialityFormViewModel;
        this.womanSpecialityFormViewModel._WomanSpecialityObject = this._TTObject as WomanSpecialityObject;
        this.womanSpecialityFormViewModel._WomanSpecialityObject.Gynecology = new Gynecology();
        this.womanSpecialityFormViewModel._WomanSpecialityObject.Gynecology.ReproductiveAbnormality = new ReproductiveAbnormalityDefinition();
    }

    protected loadViewModel() {
        let that = this;
        that.womanSpecialityFormViewModel = this._ViewModel as WomanSpecialityFormViewModel;
        that._TTObject = this.womanSpecialityFormViewModel._WomanSpecialityObject;
        if (this.womanSpecialityFormViewModel == null)
            this.womanSpecialityFormViewModel = new WomanSpecialityFormViewModel();
        if (this.womanSpecialityFormViewModel._WomanSpecialityObject == null)
            this.womanSpecialityFormViewModel._WomanSpecialityObject = new WomanSpecialityObject();
        let gynecologyObjectID = that.womanSpecialityFormViewModel._WomanSpecialityObject["Gynecology"];
        if (gynecologyObjectID != null && (typeof gynecologyObjectID === "string")) {
            let gynecology = that.womanSpecialityFormViewModel.Gynecologys.find(o => o.ObjectID.toString() === gynecologyObjectID.toString());
            if (gynecology) {
                that.womanSpecialityFormViewModel._WomanSpecialityObject.Gynecology = gynecology;
            }
            if (gynecology != null) {
                let reproductiveAbnormalityObjectID = gynecology["ReproductiveAbnormality"];
                if (reproductiveAbnormalityObjectID != null && (typeof reproductiveAbnormalityObjectID === "string")) {
                    let reproductiveAbnormality = that.womanSpecialityFormViewModel.ReproductiveAbnormalityDefinitions.find(o => o.ObjectID.toString() === reproductiveAbnormalityObjectID.toString());
                    if (reproductiveAbnormality) {
                        gynecology.ReproductiveAbnormality = reproductiveAbnormality;
                    }
                }
            }
        }
        if (this.womanSpecialityFormViewModel._Patient.ActivePregnancy != null) {
            this.isPregnancyActive = true;
            this.womanSpecialityFormViewModel._IsPregnancyStarted = true;
        } else {
            this.womanSpecialityFormViewModel._IsPregnancyStarted = false;
        }


        this.ActivePage = this.tabService.getActiveTab('wsf');
        if (this.ActivePage === undefined) {
            this.ActivePage = 'gynecology';

        } else if (this.ActivePage !== undefined) {
            if (this.ActivePage === 'gynecology')
                this.openGynecologyTab = true;
            if (this.ActivePage === 'infertilite')
                this.openInfertiliteTab = true;
            if (this.ActivePage === 'gebeIzlem')
                this.openGebeIzlemTab = true;
            if (this.ActivePage === 'gebelikTakvimi')
                this.openGebelikTakvimiTab = true;  
            if (this.ActivePage === 'lohusaIzlem')
                this.openLohusaIzlemTab = true;
        }
     
        this.RecentActiveTab = this.ActivePage;

    
    }


    async ngOnInit() {
        let that = this;
        await this.load(WomanSpecialityFormViewModel);

    }

   
    public openInfertiliteTab: boolean = false;
    public openInfertilite() {
        this.openInfertiliteTab = true;
    }

    public openGynecologyTab: boolean = false;
    public openGynecology() {
        this.openGynecologyTab = true;
    }

    public openGebeIzlemTab: boolean = false;
    public openGebeIzlem() {
        this.openGebeIzlemTab = true;
    }

    public openGebelikTakvimiTab: boolean = false;
    public openGebelikTakvimi() {
        this.openGebelikTakvimiTab = true;
    }

    public openLohusaIzlemTab: boolean = false;
    public openLohusaIzlem() {
        this.openLohusaIzlemTab = true;
    }


    // View Modellerin doldurulmaları için Eventler
    isInfertilityActive: any = false;
    isPregnancyActive: any = false;
    isPregnancyTabActive: any = false;
    isPostpartumActive: any = false;
    selectTab(e) {
        let selectedItem: string = e.addedItems[0].title;
        if (selectedItem == i18n("M16511", "İnfertilite")) {
            this.isInfertilityActive = true;
        }
        if (selectedItem == i18n("M14543", "Gebe İzlem") /*&& this.isPregnancyActive == true*/) {
            if (this.isPregnancyNew == true) {
                TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), 'Gebe izlem işlemi yapabilmek için gebeliği kaydediniz!', MessageIconEnum.WarningMessage);
            } else {
                this.isPregnancyTabActive = true;
            }
        }

        if (selectedItem == i18n("M16511", "Lohusa İzlem")) {
            this.isPostpartumActive = true;
        }
    }

    public setInfertilityViewModel(infertilityFormViewModel: InfertilityFormViewModel) {
        this.womanSpecialityFormViewModel._InfertilityFormViewModel = infertilityFormViewModel;
        this.womanSpecialityFormViewModel._InfertilityFormViewModel._Patient = this.womanSpecialityFormViewModel._Patient;
    }
    public setInfertilityPatientInfoViewModel(infertilityPatientInformationFormViewModel: InfertilityPatientInformationFormViewModel) {
        this.womanSpecialityFormViewModel._InfertilityPatientInformationFormViewModel = infertilityPatientInformationFormViewModel;
    }
    public setPregnancyStartViewModel(pregnancyStartFormViewModel: PregnancyStartFormViewModel) {
        this.womanSpecialityFormViewModel._PregnancyStartFormViewModel = pregnancyStartFormViewModel;
        this.womanSpecialityFormViewModel._PregnancyStartFormViewModel._Patient = this.womanSpecialityFormViewModel._Patient;
    }
    public setPregnancyFollowViewModel(pregnancyFollowFormViewModel: PregnancyFollowFormViewModel) {
        this.womanSpecialityFormViewModel._PregnancyFollowFormViewModel = pregnancyFollowFormViewModel;
    }
    public setPostpartumFollowViewModel(postpartumFollowUpFormViewModel: PostpartumFollowUpFormViewModel) {
        this.womanSpecialityFormViewModel._PostpartumFollowUpFormViewModel = postpartumFollowUpFormViewModel;
    }

    /*Gebelik Başlatma ******************************************************************************************************************************************************/
    isPregnancyNew: boolean = false;
    // showPregnancyStartPopup: boolean = false;
    public ShowPregnancyStartModal() {
        this.womanSpecialityFormViewModel.showPregnancyStartPopup = true;
    }
    public CancelPregnancyStartModal() {
        this.womanSpecialityFormViewModel._IsPregnancyStarted = false;
        this.womanSpecialityFormViewModel.showPregnancyStartPopup = false;
    }
    public async SavePregnancyStart($event) {
        this.womanSpecialityFormViewModel.showPregnancyStartPopup = false;
        this.isPregnancyNew = true;
        this.womanSpecialityFormViewModel._Patient.ActivePregnancy = this.womanSpecialityFormViewModel._PregnancyStartFormViewModel._Pregnancy;
        this.isPregnancyActive = true;
        this.womanSpecialityFormViewModel.PregnancyWeek = Convert.ToInt32(await this.GetPregnancyWeek(this.womanSpecialityFormViewModel._PregnancyStartFormViewModel._Pregnancy.LastMenstrualPeriod));
        this.womanSpecialityFormViewModel._IsPregnancyStarted = true;
    }

    private async GetPregnancyWeek(lastMenstrualPeriod: Date): Promise<number> {
        let currentDate: Date = await (CommonService.RecTime());
        currentDate = plainToClass(Date, currentDate);

        let today: Date = await (CommonService.RecTime());
        today = plainToClass(Date, today);
        let weeks: number = Math.floor((currentDate.valueOf() - lastMenstrualPeriod.valueOf() + 1) / (1000 * 60 * 60 * 24) / 7);

        return weeks;
    }

    /*Gebelik Sonucu *********************************************************************************************************************************************************/
    showPregnancyResultPopup: boolean = false;
    public pregnancyResultComponentInfo: DynamicComponentInfo;
    public pregnancyResultQueryParameters: QueryParams;

    public ShowPregnancyResultModal() {
        this.showPregnancyResultPopup = true;
        let componentInfoViewModel: PregnancyResultComponentInfoViewModel;
        if (typeof this.womanSpecialityFormViewModel._Patient.ActivePregnancy == "string") {
            componentInfoViewModel = PregnancyResultForm.getComponentInfoViewModel(this.womanSpecialityFormViewModel._Patient.ActivePregnancy, false);
        } else {
            componentInfoViewModel = PregnancyResultForm.getComponentInfoViewModel(this.womanSpecialityFormViewModel._Patient.ActivePregnancy.ObjectID, false);
        }
        this.pregnancyResultQueryParameters = componentInfoViewModel.pregnancyResultQueryParameters;
        this.pregnancyResultComponentInfo = componentInfoViewModel.pregnancyResultComponentInfo;
    }
    public CancelPregnancyResultModal() {
        this.showPregnancyResultPopup = false;
        this.womanSpecialityFormViewModel._PregnancyResultFormViewModel = null;
    }
    public async SavePregnancyResult($event) {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M14572", "Gebelik Sonlandırma İptal"), i18n("M18961", "Mevcut gebelik sonlandırılacaktır. Sonrasında düzenleme yapılamayacaktır.\r\n\r\n Gebeliğin sonlandırılmasını onaylıyor musunuz?"));
        if (result === "E") {
            this.showPregnancyResultPopup = false;
            this.womanSpecialityFormViewModel._IsPregnancyStarted = false;
            this.isPregnancyActive = false;
        }
    }

    pregnancyResultQueryResultLoaded(e: any) {
        PregnancyResultForm.pregnancyResultQueryResultLoaded(e);
    }

    /*Geçmiş Gebelik Bilgileri **************************************************************************************************************************************************/
    showPreviousPregnancyPopup: boolean = false;
    public previousPregnancyComponentInfo: DynamicComponentInfo;
    public previousPregnancyQueryParameters: QueryParams;

    public ShowPreviousPregnancyModal() {
        this.showPreviousPregnancyPopup = true;
        let componentInfoViewModel: PreviousPregnancyComponentInfoViewModel = PreviousPregnancyForm.getComponentInfoViewModel(this.womanSpecialityFormViewModel._Patient.ObjectID);
        this.previousPregnancyQueryParameters = componentInfoViewModel.previousPregnancyQueryParameters;
        this.previousPregnancyComponentInfo = componentInfoViewModel.previousPregnancyComponentInfo;
    }
    public CancelPreviousPregnancyModal() {
        this.showPreviousPregnancyPopup = (!this.showPreviousPregnancyPopup);
    }
    public SavePreviousPregnancy($event) {
        this.showPreviousPregnancyPopup = false;
    }

    previousPregnancyQueryResultLoaded(e: any) {
        PreviousPregnancyForm.previousPregnancyQueryResultLoaded(e);
    }


    // View Modellerin doldurulmaları için Eventler Bitti

    public onAbortionChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.Abortion != event) {
                this._WomanSpecialityObject.Abortion = event;
            }
        }
    }

    public onBasalUltrasoundGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.BasalUltrasound != event) {
                this._WomanSpecialityObject.Gynecology.BasalUltrasound = event;
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

    public onCurrentBirthControlMethodGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.CurrentBirthControlMethod != event) {
                this._WomanSpecialityObject.Gynecology.CurrentBirthControlMethod = event;
            }
        }
    }

    public onDCChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.DC != event) {
                this._WomanSpecialityObject.DC = event;
            }
        }
    }

    public onDegreeOfRelationshipChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.DegreeOfRelationship != event) {
                this._WomanSpecialityObject.DegreeOfRelationship = event;
            }
        }
    }

    public onDyspareuniaGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.Dyspareunia != event) {
                this._WomanSpecialityObject.Gynecology.Dyspareunia = event;
            }
        }
    }

    public onDyspareuniaInformationGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.DyspareuniaInformation != event) {
                this._WomanSpecialityObject.Gynecology.DyspareuniaInformation = event;
            }
        }
    }

    public onDysuriaGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.Dysuria != event) {
                this._WomanSpecialityObject.Gynecology.Dysuria = event;
            }
        }
    }

    public onDysuriaInformationGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.DysuriaInformation != event) {
                this._WomanSpecialityObject.Gynecology.DysuriaInformation = event;
            }
        }
    }

    public onGenitalAbnormalitiesGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.GenitalAbnormalities != event) {
                this._WomanSpecialityObject.Gynecology.GenitalAbnormalities = event;
            }
        }
    }

    public onGenitalAbnormalitiesInfoGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.GenitalAbnormalitiesInfo != event) {
                this._WomanSpecialityObject.Gynecology.GenitalAbnormalitiesInfo = event;
            }
        }
    }

    public onGenitalExaminationGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.GenitalExamination != event) {
                this._WomanSpecialityObject.Gynecology.GenitalExamination = event;
            }
        }
    }

    public onGynecologicalHistoryGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.GynecologicalHistory != event) {
                this._WomanSpecialityObject.Gynecology.GynecologicalHistory = event;
            }
        }
    }

    public onHirsutismGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.Hirsutism != event) {
                this._WomanSpecialityObject.Gynecology.Hirsutism = event;
            }
        }
    }

    public onHirsutismInformationGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.HirsutismInformation != event) {
                this._WomanSpecialityObject.Gynecology.HirsutismInformation = event;
            }
        }
    }

    public onHusbandBloodGroupChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.HusbandBloodGroup != event) {
                this._WomanSpecialityObject.HusbandBloodGroup = event;
                if (this._WomanSpecialityObject.WomanBloodGroup != null) {
                    WomanSpecialityForm.GetRhIncompatibility(Convert.ToInt32(this._WomanSpecialityObject.WomanBloodGroup.toString()), Convert.ToInt32(this._WomanSpecialityObject.HusbandBloodGroup.toString())).then(c => {
                        this._WomanSpecialityObject.RhIncompatibility = c;
                    });
                }
            }
        }
    }
    public onWomanBloodGroupChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.WomanBloodGroup != event) {
                this._WomanSpecialityObject.WomanBloodGroup = event;
                if (this._WomanSpecialityObject.HusbandBloodGroup != null) {
                    WomanSpecialityForm.GetRhIncompatibility(Convert.ToInt32(this._WomanSpecialityObject.WomanBloodGroup.toString()), Convert.ToInt32(this._WomanSpecialityObject.HusbandBloodGroup.toString())).then(c => {
                        this._WomanSpecialityObject.RhIncompatibility = c;
                    });
                }
            }
        }
    }

    public onHusbandFullNameChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.HusbandFullName != event) {
                this._WomanSpecialityObject.HusbandFullName = event;
            }
        }
    }

    public onLastExaminationDateGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.LastExaminationDate != event) {
                this._WomanSpecialityObject.Gynecology.LastExaminationDate = event;
            }
        }
    }

    public onLastSmearDateGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.LastSmearDate != event) {
                this._WomanSpecialityObject.Gynecology.LastSmearDate = event;
            }
        }
    }

    public onLivingBabiesChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.LivingBabies != event) {
                this._WomanSpecialityObject.LivingBabies = event;
            }
        }
    }

    public onMarriageDateChanged(event): void {
        //if (event != null) {
        //    if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.MarriageDate != event) {
        //        this._WomanSpecialityObject.MarriageDate = event;
        //    }
        //}
        //this.MarriageDate_TextChanged();
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.MarriageDate != event) {
                this._WomanSpecialityObject.MarriageDate = event.value;
                if (this._WomanSpecialityObject.MarriageDate.toString().length == 4) {
                    WomanSpecialityForm.GetMarriageDuration(Convert.ToInt32(this._WomanSpecialityObject.MarriageDate)).then(c => {
                        this.MarriageDuration.Text = c.toString();
                    });
                }
                else {
                    this.MarriageDuration.Text = "";
                }
            }
        }
    }

    public onMenstrualCycleAbnormalitiesGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.MenstrualCycleAbnormalities != event) {
                this._WomanSpecialityObject.Gynecology.MenstrualCycleAbnormalities = event;
            }
        }
    }

    public onMenstrualCycleInformationGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.MenstrualCycleInformation != event) {
                this._WomanSpecialityObject.Gynecology.MenstrualCycleInformation = event;
            }
        }
    }

    public onNumberOfPregnancyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.NumberOfPregnancy != event) {
                this._WomanSpecialityObject.NumberOfPregnancy = event;
            }
        }
    }

    public onParityChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.Parity != event) {
                this._WomanSpecialityObject.Parity = event;
            }
        }
    }

    public onPelvicExaminationGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.PelvicExamination != event) {
                this._WomanSpecialityObject.Gynecology.PelvicExamination = event;
            }
        }
    }

    public onPreviousBirthControlMethodGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.PreviousBirthControlMethod != event) {
                this._WomanSpecialityObject.Gynecology.PreviousBirthControlMethod = event;
            }
        }
    }

    public onReproductiveAbnormalitiesInfoGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.ReproductiveAbnormalitiesInfo != event) {
                this._WomanSpecialityObject.Gynecology.ReproductiveAbnormalitiesInfo = event;
            }
        }
    }

    public onReproductiveAbnormalityGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.ReproductiveAbnormality != event) {
                this._WomanSpecialityObject.Gynecology.ReproductiveAbnormality = event;
            }
        }
    }

    public onRhIncompatibilityChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null && this._WomanSpecialityObject.RhIncompatibility != event) {
                this._WomanSpecialityObject.RhIncompatibility = event;
            }
        }
    }

    public onTumorMarkersGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.TumorMarkers != event) {
                this._WomanSpecialityObject.Gynecology.TumorMarkers = event;
            }
        }
    }

    public onUterusGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.Uterus != event) {
                this._WomanSpecialityObject.Gynecology.Uterus = event;
            }
        }
    }

    public onVaginalDischargeGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.VaginalDischarge != event) {
                this._WomanSpecialityObject.Gynecology.VaginalDischarge = event;
            }
        }
    }

    public onVaginalDischargeInformationGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.VaginalDischargeInformation != event) {
                this._WomanSpecialityObject.Gynecology.VaginalDischargeInformation = event;
            }
        }
    }

    public onVulvaVagenGynecologyChanged(event): void {
        if (event != null) {
            if (this._WomanSpecialityObject != null &&
                this._WomanSpecialityObject.Gynecology != null && this._WomanSpecialityObject.Gynecology.VulvaVagen != event) {
                this._WomanSpecialityObject.Gynecology.VulvaVagen = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.WomanBloodGroup, "Value", this.__ttObject, "WomanBloodGroup");
        redirectProperty(this.HusbandFullName, "Text", this.__ttObject, "HusbandFullName");
        redirectProperty(this.DegreeOfRelationship, "Value", this.__ttObject, "DegreeOfRelationship");
        redirectProperty(this.NumberOfPregnancy, "Text", this.__ttObject, "NumberOfPregnancy");
        redirectProperty(this.Parity, "Text", this.__ttObject, "Parity");
        redirectProperty(this.MarriageDate, "Text", this.__ttObject, "MarriageDate");
        redirectProperty(this.LivingBabies, "Text", this.__ttObject, "LivingBabies");
        redirectProperty(this.Abortion, "Text", this.__ttObject, "Abortion");
        redirectProperty(this.HusbandBloodGroup, "Value", this.__ttObject, "HusbandBloodGroup");
        redirectProperty(this.RhIncompatibility, "Value", this.__ttObject, "RhIncompatibility");
        redirectProperty(this.DC, "Text", this.__ttObject, "DC");
        redirectProperty(this.LastExaminationDateGynecology, "Value", this.__ttObject, "Gynecology.LastExaminationDate");
        redirectProperty(this.LastSmearDateGynecology, "Value", this.__ttObject, "Gynecology.LastSmearDate");
        redirectProperty(this.PreviousBirthControlMethodGynecology, "Value", this.__ttObject, "Gynecology.PreviousBirthControlMethod");
        redirectProperty(this.CurrentBirthControlMethodGynecology, "Value", this.__ttObject, "Gynecology.CurrentBirthControlMethod");
        redirectProperty(this.GenitalAbnormalitiesGynecology, "Value", this.__ttObject, "Gynecology.GenitalAbnormalities");
        redirectProperty(this.GenitalAbnormalitiesInfoGynecology, "Text", this.__ttObject, "Gynecology.GenitalAbnormalitiesInfo");
        redirectProperty(this.MenstrualCycleAbnormalitiesGynecology, "Value", this.__ttObject, "Gynecology.MenstrualCycleAbnormalities");
        redirectProperty(this.MenstrualCycleInformationGynecology, "Text", this.__ttObject, "Gynecology.MenstrualCycleInformation");
        redirectProperty(this.ReproductiveAbnormalitiesInfoGynecology, "Text", this.__ttObject, "Gynecology.ReproductiveAbnormalitiesInfo");
        redirectProperty(this.GynecologicalHistoryGynecology, "Text", this.__ttObject, "Gynecology.GynecologicalHistory");
        redirectProperty(this.GenitalExaminationGynecology, "Text", this.__ttObject, "Gynecology.GenitalExamination");
        redirectProperty(this.PelvicExaminationGynecology, "Text", this.__ttObject, "Gynecology.PelvicExamination");
        redirectProperty(this.VulvaVagenGynecology, "Text", this.__ttObject, "Gynecology.VulvaVagen");
        redirectProperty(this.CervixGynecology, "Text", this.__ttObject, "Gynecology.Cervix");
        redirectProperty(this.UterusGynecology, "Text", this.__ttObject, "Gynecology.Uterus");
        redirectProperty(this.BasalUltrasoundGynecology, "Text", this.__ttObject, "Gynecology.BasalUltrasound");
        redirectProperty(this.TumorMarkersGynecology, "Text", this.__ttObject, "Gynecology.TumorMarkers");
        redirectProperty(this.DysuriaGynecology, "Value", this.__ttObject, "Gynecology.Dysuria");
        redirectProperty(this.DysuriaInformationGynecology, "Text", this.__ttObject, "Gynecology.DysuriaInformation");
        redirectProperty(this.DyspareuniaGynecology, "Value", this.__ttObject, "Gynecology.Dyspareunia");
        redirectProperty(this.DyspareuniaInformationGynecology, "Text", this.__ttObject, "Gynecology.DyspareuniaInformation");
        redirectProperty(this.HirsutismGynecology, "Value", this.__ttObject, "Gynecology.Hirsutism");
        redirectProperty(this.HirsutismInformationGynecology, "Text", this.__ttObject, "Gynecology.HirsutismInformation");
        redirectProperty(this.VaginalDischargeGynecology, "Value", this.__ttObject, "Gynecology.VaginalDischarge");
        redirectProperty(this.VaginalDischargeInformationGynecology, "Text", this.__ttObject, "Gynecology.VaginalDischargeInformation");
    }

    public initFormControls(): void {

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 14;

        this.tabGynecology = new TTVisual.TTTabPage();
        this.tabGynecology.DisplayIndex = 0;
        this.tabGynecology.TabIndex = 0;
        this.tabGynecology.Text = i18n("M16993", "Jinekoloji");
        this.tabGynecology.Name = "tabGynecology";

        this.labelReproductiveAbnormalityGynecology = new TTVisual.TTLabel();
        this.labelReproductiveAbnormalityGynecology.Text = i18n("M23942", "Üreme Organı Anomalisi");
        this.labelReproductiveAbnormalityGynecology.Name = "labelReproductiveAbnormalityGynecology";
        this.labelReproductiveAbnormalityGynecology.TabIndex = 47;

        this.ReproductiveAbnormalityGynecology = new TTVisual.TTObjectListBox();
        this.ReproductiveAbnormalityGynecology.ListDefName = "ReproductiveAbnormalityList";
        this.ReproductiveAbnormalityGynecology.Name = "ReproductiveAbnormalityGynecology";
        this.ReproductiveAbnormalityGynecology.TabIndex = 46;

        this.labelVulvaVagenGynecology = new TTVisual.TTLabel();
        this.labelVulvaVagenGynecology.Text = i18n("M24186", "Vulva Vagen");
        this.labelVulvaVagenGynecology.Name = "labelVulvaVagenGynecology";
        this.labelVulvaVagenGynecology.TabIndex = 45;

        this.VulvaVagenGynecology = new TTVisual.TTTextBox();
        this.VulvaVagenGynecology.Name = "VulvaVagenGynecology";
        this.VulvaVagenGynecology.TabIndex = 44;

        this.labelVaginalDischargeInformationGynecology = new TTVisual.TTLabel();
        this.labelVaginalDischargeInformationGynecology.Text = i18n("M24013", "Vajinal Akıntı Açıklama");
        this.labelVaginalDischargeInformationGynecology.Name = "labelVaginalDischargeInformationGynecology";
        this.labelVaginalDischargeInformationGynecology.TabIndex = 43;

        this.VaginalDischargeInformationGynecology = new TTVisual.TTTextBox();
        this.VaginalDischargeInformationGynecology.Name = "VaginalDischargeInformationGynecology";
        this.VaginalDischargeInformationGynecology.TabIndex = 42;

        this.VaginalDischargeGynecology = new TTVisual.TTCheckBox();
        this.VaginalDischargeGynecology.Value = false;
        this.VaginalDischargeGynecology.Text = i18n("M24012", "Vajinal Akıntı");
        this.VaginalDischargeGynecology.Title = i18n("M24012", "Vajinal Akıntı");
        this.VaginalDischargeGynecology.Name = "VaginalDischargeGynecology";
        this.VaginalDischargeGynecology.TabIndex = 41;

        this.labelUterusGynecology = new TTVisual.TTLabel();
        this.labelUterusGynecology.Text = "Uterus";
        this.labelUterusGynecology.Name = "labelUterusGynecology";
        this.labelUterusGynecology.TabIndex = 40;

        this.UterusGynecology = new TTVisual.TTTextBox();
        this.UterusGynecology.Name = "UterusGynecology";
        this.UterusGynecology.TabIndex = 39;

        this.labelTumorMarkersGynecology = new TTVisual.TTLabel();
        this.labelTumorMarkersGynecology.Text = i18n("M23652", "Tümör Belirleyiciler");
        this.labelTumorMarkersGynecology.Name = "labelTumorMarkersGynecology";
        this.labelTumorMarkersGynecology.TabIndex = 38;

        this.TumorMarkersGynecology = new TTVisual.TTTextBox();
        this.TumorMarkersGynecology.Name = "TumorMarkersGynecology";
        this.TumorMarkersGynecology.TabIndex = 37;

        this.labelReproductiveAbnormalitiesInfoGynecology = new TTVisual.TTLabel();
        this.labelReproductiveAbnormalitiesInfoGynecology.Text = i18n("M23939", "Üreme Organı Anomalileri Açıklama");
        this.labelReproductiveAbnormalitiesInfoGynecology.Name = "labelReproductiveAbnormalitiesInfoGynecology";
        this.labelReproductiveAbnormalitiesInfoGynecology.TabIndex = 36;

        this.ReproductiveAbnormalitiesInfoGynecology = new TTVisual.TTTextBox();
        this.ReproductiveAbnormalitiesInfoGynecology.Name = "ReproductiveAbnormalitiesInfoGynecology";
        this.ReproductiveAbnormalitiesInfoGynecology.TabIndex = 35;

        this.labelPreviousBirthControlMethodGynecology = new TTVisual.TTLabel();
        this.labelPreviousBirthControlMethodGynecology.Text = i18n("M20005", "Önceki Doğum Kontrol Yöntemi");
        this.labelPreviousBirthControlMethodGynecology.Name = "labelPreviousBirthControlMethodGynecology";
        this.labelPreviousBirthControlMethodGynecology.TabIndex = 34;

        this.PreviousBirthControlMethodGynecology = new TTVisual.TTEnumComboBox();
        this.PreviousBirthControlMethodGynecology.DataTypeName = "BirthControlMethodEnum";
        this.PreviousBirthControlMethodGynecology.Name = "PreviousBirthControlMethodGynecology";
        this.PreviousBirthControlMethodGynecology.TabIndex = 33;

        this.labelPelvicExaminationGynecology = new TTVisual.TTLabel();
        this.labelPelvicExaminationGynecology.Text = i18n("M20292", "Pelvik Muayene");
        this.labelPelvicExaminationGynecology.Name = "labelPelvicExaminationGynecology";
        this.labelPelvicExaminationGynecology.TabIndex = 32;

        this.PelvicExaminationGynecology = new TTVisual.TTTextBox();
        this.PelvicExaminationGynecology.Name = "PelvicExaminationGynecology";
        this.PelvicExaminationGynecology.TabIndex = 31;

        this.labelMenstrualCycleInformationGynecology = new TTVisual.TTLabel();
        this.labelMenstrualCycleInformationGynecology.Text = i18n("M18880", "Menstural Siklus Açıklama");
        this.labelMenstrualCycleInformationGynecology.Name = "labelMenstrualCycleInformationGynecology";
        this.labelMenstrualCycleInformationGynecology.TabIndex = 30;

        this.MenstrualCycleInformationGynecology = new TTVisual.TTTextBox();
        this.MenstrualCycleInformationGynecology.Name = "MenstrualCycleInformationGynecology";
        this.MenstrualCycleInformationGynecology.TabIndex = 29;

        this.labelMenstrualCycleAbnormalitiesGynecology = new TTVisual.TTLabel();
        this.labelMenstrualCycleAbnormalitiesGynecology.Text = i18n("M18881", "Menstural Siklus Anomalisi");
        this.labelMenstrualCycleAbnormalitiesGynecology.Name = "labelMenstrualCycleAbnormalitiesGynecology";
        this.labelMenstrualCycleAbnormalitiesGynecology.TabIndex = 28;

        this.MenstrualCycleAbnormalitiesGynecology = new TTVisual.TTEnumComboBox();
        this.MenstrualCycleAbnormalitiesGynecology.DataTypeName = "MenstrualCycleAbnormalitiesEnum";
        this.MenstrualCycleAbnormalitiesGynecology.Name = "MenstrualCycleAbnormalitiesGynecology";
        this.MenstrualCycleAbnormalitiesGynecology.TabIndex = 27;

        this.labelLastSmearDateGynecology = new TTVisual.TTLabel();
        this.labelLastSmearDateGynecology.Text = i18n("M22065", "Son Smear Tarihi");
        this.labelLastSmearDateGynecology.Name = "labelLastSmearDateGynecology";
        this.labelLastSmearDateGynecology.TabIndex = 26;

        this.LastSmearDateGynecology = new TTVisual.TTDateTimePicker();
        this.LastSmearDateGynecology.Format = DateTimePickerFormat.Long;
        this.LastSmearDateGynecology.Name = "LastSmearDateGynecology";
        this.LastSmearDateGynecology.TabIndex = 25;

        this.labelLastExaminationDateGynecology = new TTVisual.TTLabel();
        this.labelLastExaminationDateGynecology.Text = i18n("M22051", "Son Jinekolojik Muayene Tarihi");
        this.labelLastExaminationDateGynecology.Name = "labelLastExaminationDateGynecology";
        this.labelLastExaminationDateGynecology.TabIndex = 24;

        this.LastExaminationDateGynecology = new TTVisual.TTDateTimePicker();
        this.LastExaminationDateGynecology.Format = DateTimePickerFormat.Long;
        this.LastExaminationDateGynecology.Name = "LastExaminationDateGynecology";
        this.LastExaminationDateGynecology.TabIndex = 23;

        this.labelHirsutismInformationGynecology = new TTVisual.TTLabel();
        this.labelHirsutismInformationGynecology.Text = i18n("M23683", "Tüylenme Açıklama");
        this.labelHirsutismInformationGynecology.Name = "labelHirsutismInformationGynecology";
        this.labelHirsutismInformationGynecology.TabIndex = 22;

        this.HirsutismInformationGynecology = new TTVisual.TTTextBox();
        this.HirsutismInformationGynecology.Name = "HirsutismInformationGynecology";
        this.HirsutismInformationGynecology.TabIndex = 21;

        this.HirsutismGynecology = new TTVisual.TTCheckBox();
        this.HirsutismGynecology.Value = false;
        this.HirsutismGynecology.Text = i18n("M23682", "Tüylenme");
        this.HirsutismGynecology.Title = i18n("M23682", "Tüylenme");
        this.HirsutismGynecology.Name = "HirsutismGynecology";
        this.HirsutismGynecology.TabIndex = 20;

        this.labelGynecologicalHistoryGynecology = new TTVisual.TTLabel();
        this.labelGynecologicalHistoryGynecology.Text = i18n("M16994", "Jinekolojik Anamnez");
        this.labelGynecologicalHistoryGynecology.Name = "labelGynecologicalHistoryGynecology";
        this.labelGynecologicalHistoryGynecology.TabIndex = 19;

        this.GynecologicalHistoryGynecology = new TTVisual.TTTextBox();
        this.GynecologicalHistoryGynecology.Name = "GynecologicalHistoryGynecology";
        this.GynecologicalHistoryGynecology.TabIndex = 18;

        this.labelGenitalExaminationGynecology = new TTVisual.TTLabel();
        this.labelGenitalExaminationGynecology.Text = i18n("M14735", "Genital Bölge Muayene");
        this.labelGenitalExaminationGynecology.Name = "labelGenitalExaminationGynecology";
        this.labelGenitalExaminationGynecology.TabIndex = 17;

        this.GenitalExaminationGynecology = new TTVisual.TTTextBox();
        this.GenitalExaminationGynecology.Name = "GenitalExaminationGynecology";
        this.GenitalExaminationGynecology.TabIndex = 16;

        this.labelGenitalAbnormalitiesInfoGynecology = new TTVisual.TTLabel();
        this.labelGenitalAbnormalitiesInfoGynecology.Text = i18n("M14734", "Genital Bölge Anomalisi Açıklama");
        this.labelGenitalAbnormalitiesInfoGynecology.Name = "labelGenitalAbnormalitiesInfoGynecology";
        this.labelGenitalAbnormalitiesInfoGynecology.TabIndex = 15;

        this.GenitalAbnormalitiesInfoGynecology = new TTVisual.TTTextBox();
        this.GenitalAbnormalitiesInfoGynecology.Name = "GenitalAbnormalitiesInfoGynecology";
        this.GenitalAbnormalitiesInfoGynecology.TabIndex = 14;

        this.labelGenitalAbnormalitiesGynecology = new TTVisual.TTLabel();
        this.labelGenitalAbnormalitiesGynecology.Text = i18n("M14733", "Genital Bölge Anomalisi");
        this.labelGenitalAbnormalitiesGynecology.Name = "labelGenitalAbnormalitiesGynecology";
        this.labelGenitalAbnormalitiesGynecology.TabIndex = 13;

        this.GenitalAbnormalitiesGynecology = new TTVisual.TTEnumComboBox();
        this.GenitalAbnormalitiesGynecology.DataTypeName = "GenitalAbnormalitiesEnum";
        this.GenitalAbnormalitiesGynecology.Name = "GenitalAbnormalitiesGynecology";
        this.GenitalAbnormalitiesGynecology.TabIndex = 12;

        this.labelDysuriaInformationGynecology = new TTVisual.TTLabel();
        this.labelDysuriaInformationGynecology.Text = i18n("M16194", "İdrar Yaparken Ağrı/Yanma Açıklama");
        this.labelDysuriaInformationGynecology.Name = "labelDysuriaInformationGynecology";
        this.labelDysuriaInformationGynecology.TabIndex = 11;

        this.DysuriaInformationGynecology = new TTVisual.TTTextBox();
        this.DysuriaInformationGynecology.Name = "DysuriaInformationGynecology";
        this.DysuriaInformationGynecology.TabIndex = 10;

        this.DysuriaGynecology = new TTVisual.TTCheckBox();
        this.DysuriaGynecology.Value = false;
        this.DysuriaGynecology.Text = i18n("M16193", "İdrar Yaparken Ağrı/Yanma");
        this.DysuriaGynecology.Title = i18n("M16193", "İdrar Yaparken Ağrı/Yanma");
        this.DysuriaGynecology.Name = "DysuriaGynecology";
        this.DysuriaGynecology.TabIndex = 9;

        this.labelDyspareuniaInformationGynecology = new TTVisual.TTLabel();
        this.labelDyspareuniaInformationGynecology.Text = i18n("M12261", "Cinsel İlişki Sırasında Ağrı,Kanama Açıklama");
        this.labelDyspareuniaInformationGynecology.Name = "labelDyspareuniaInformationGynecology";
        this.labelDyspareuniaInformationGynecology.TabIndex = 8;

        this.DyspareuniaInformationGynecology = new TTVisual.TTTextBox();
        this.DyspareuniaInformationGynecology.Name = "DyspareuniaInformationGynecology";
        this.DyspareuniaInformationGynecology.TabIndex = 7;

        this.DyspareuniaGynecology = new TTVisual.TTCheckBox();
        this.DyspareuniaGynecology.Value = false;
        this.DyspareuniaGynecology.Text = i18n("M12260", "Cinsel İlişki Sırasında Ağrı,Kanama");
        this.DyspareuniaGynecology.Title = i18n("M12260", "Cinsel İlişki Sırasında Ağrı,Kanama");
        this.DyspareuniaGynecology.Name = "DyspareuniaGynecology";
        this.DyspareuniaGynecology.TabIndex = 6;

        this.labelCurrentBirthControlMethodGynecology = new TTVisual.TTLabel();
        this.labelCurrentBirthControlMethodGynecology.Text = i18n("M15004", "Güncel Doğum Kontrol Yöntemi");
        this.labelCurrentBirthControlMethodGynecology.Name = "labelCurrentBirthControlMethodGynecology";
        this.labelCurrentBirthControlMethodGynecology.TabIndex = 5;

        this.CurrentBirthControlMethodGynecology = new TTVisual.TTEnumComboBox();
        this.CurrentBirthControlMethodGynecology.DataTypeName = "BirthControlMethodEnum";
        this.CurrentBirthControlMethodGynecology.Name = "CurrentBirthControlMethodGynecology";
        this.CurrentBirthControlMethodGynecology.TabIndex = 4;

        this.labelCervixGynecology = new TTVisual.TTLabel();
        this.labelCervixGynecology.Text = i18n("M21661", "Serviks");
        this.labelCervixGynecology.Name = "labelCervixGynecology";
        this.labelCervixGynecology.TabIndex = 3;

        this.CervixGynecology = new TTVisual.TTTextBox();
        this.CervixGynecology.Name = "CervixGynecology";
        this.CervixGynecology.TabIndex = 2;

        this.labelBasalUltrasoundGynecology = new TTVisual.TTLabel();
        this.labelBasalUltrasoundGynecology.Text = i18n("M11674", "Bazal Ultrason");
        this.labelBasalUltrasoundGynecology.Name = "labelBasalUltrasoundGynecology";
        this.labelBasalUltrasoundGynecology.TabIndex = 1;

        this.BasalUltrasoundGynecology = new TTVisual.TTTextBox();
        this.BasalUltrasoundGynecology.Name = "BasalUltrasoundGynecology";
        this.BasalUltrasoundGynecology.TabIndex = 0;

        this.tabInfertility = new TTVisual.TTTabPage();
        this.tabInfertility.DisplayIndex = 1;
        this.tabInfertility.TabIndex = 1;
        this.tabInfertility.Text = i18n("M16511", "İnfertilite");
        this.tabInfertility.Name = "tabInfertility";

        this.tabPregnancy = new TTVisual.TTTabPage();
        this.tabPregnancy.DisplayIndex = 2;
        this.tabPregnancy.TabIndex = 2;
        this.tabPregnancy.Text = i18n("M14543", "Gebe İzlem");
        this.tabPregnancy.Name = "tabPregnancy";

        this.tabPregCalendar = new TTVisual.TTTabPage();
        this.tabPregCalendar.DisplayIndex = 3;
        this.tabPregCalendar.TabIndex = 3;
        this.tabPregCalendar.Text = i18n("M14576", "Gebelik Takvimi");
        this.tabPregCalendar.Name = "tabPregCalendar";

        this.gridPregnancyCalendar = new TTVisual.TTGrid();
        this.gridPregnancyCalendar.Name = "gridPregnancyCalendar";
        this.gridPregnancyCalendar.TabIndex = 0;

        this.Parity = new TTVisual.TTTextBox();
        this.Parity.Name = "Parity";
        this.Parity.TabIndex = 6;
        this.Parity.ReadOnly = true;

        this.NumberOfPregnancy = new TTVisual.TTTextBox();
        this.NumberOfPregnancy.Name = "NumberOfPregnancy";
        this.NumberOfPregnancy.TabIndex = 5;
        this.NumberOfPregnancy.ReadOnly = true;

        this.LivingBabies = new TTVisual.TTTextBox();
        this.LivingBabies.Name = "LivingBabies";
        this.LivingBabies.TabIndex = 9;
        this.LivingBabies.ReadOnly = true;

        this.HusbandFullName = new TTVisual.TTTextBox();
        this.HusbandFullName.Name = "HusbandFullName";
        this.HusbandFullName.TabIndex = 3;

        this.DC = new TTVisual.TTTextBox();
        this.DC.Name = "DC";
        this.DC.TabIndex = 13;
        this.DC.ReadOnly = true;

        this.Abortion = new TTVisual.TTTextBox();
        this.Abortion.Name = "Abortion";
        this.Abortion.TabIndex = 10;
        this.Abortion.ReadOnly = true;

        this.MarriageDuration = new TTVisual.TTTextBox();
        this.MarriageDuration.BackColor = "#F0F0F0";
        this.MarriageDuration.ReadOnly = true;
        this.MarriageDuration.Name = "MarriageDuration";
        this.MarriageDuration.TabIndex = 8;

        this.ttbutton1 = new TTVisual.TTButton();
        this.ttbutton1.Text = i18n("M15193", "Hasta Eşi Seç");
        this.ttbutton1.Name = "ttbutton1";
        this.ttbutton1.TabIndex = 1;

        this.labelBloodGroup = new TTVisual.TTLabel();
        this.labelBloodGroup.Text = i18n("M15464", "Hastanın Kan Grubu");
        this.labelBloodGroup.Name = "labelBloodGroup";
        this.labelBloodGroup.TabIndex = 27;

        this.MarriageDate = new TTVisual.TTMaskedTextBox();
        this.MarriageDate.Mask = "0000";
        this.MarriageDate.Name = "MarriageDate";
        this.MarriageDate.TabIndex = 7;

        this.labelMarriageDate = new TTVisual.TTLabel();
        this.labelMarriageDate.Text = i18n("M14025", "Evlilik Senesi");
        this.labelMarriageDate.Name = "labelMarriageDate";
        this.labelMarriageDate.TabIndex = 25;

        this.btnPregnancyStart = new TTVisual.TTButton();
        this.btnPregnancyStart.Text = i18n("M14553", "Gebelik Başlat");
        this.btnPregnancyStart.Name = "btnPregnancyStart";
        this.btnPregnancyStart.TabIndex = 2;

        this.labelMarriageDuration = new TTVisual.TTLabel();
        this.labelMarriageDuration.Text = i18n("M14028", "Evlilik Süresi :");
        this.labelMarriageDuration.Name = "labelMarriageDuration";
        this.labelMarriageDuration.TabIndex = 20;

        this.labelRhIncompatibility = new TTVisual.TTLabel();
        this.labelRhIncompatibility.Text = i18n("M21043", "Rh Kan Uyuşmazlığı");
        this.labelRhIncompatibility.Name = "labelRhIncompatibility";
        this.labelRhIncompatibility.TabIndex = 17;

        this.RhIncompatibility = new TTVisual.TTEnumComboBox();
        this.RhIncompatibility.DataTypeName = "VarYokGarantiEnum";
        this.RhIncompatibility.BackColor = "#F0F0F0";
        this.RhIncompatibility.Enabled = false;
        this.RhIncompatibility.Name = "RhIncompatibility";
        this.RhIncompatibility.TabIndex = 12;

        this.labelParity = new TTVisual.TTLabel();
        this.labelParity.Text = i18n("M20211", "Parite");
        this.labelParity.Name = "labelParity";
        this.labelParity.TabIndex = 15;

        this.labelNumberOfPregnancy = new TTVisual.TTLabel();
        this.labelNumberOfPregnancy.Text = i18n("M14570", "Gebelik Sayısı");
        this.labelNumberOfPregnancy.Name = "labelNumberOfPregnancy";
        this.labelNumberOfPregnancy.TabIndex = 13;

        this.labelLivingBabies = new TTVisual.TTLabel();
        this.labelLivingBabies.Text = i18n("M24348", "Yaşayan");
        this.labelLivingBabies.Name = "labelLivingBabies";
        this.labelLivingBabies.TabIndex = 11;

        this.labelHusbandFullName = new TTVisual.TTLabel();
        this.labelHusbandFullName.Text = i18n("M13914", "Eşinin Adı Soyadı");
        this.labelHusbandFullName.Name = "labelHusbandFullName";
        this.labelHusbandFullName.TabIndex = 9;

        this.labelHusbandBloodGroup = new TTVisual.TTLabel();
        this.labelHusbandBloodGroup.Text = i18n("M13916", "Eşinin Kan Grubu");
        this.labelHusbandBloodGroup.Name = "labelHusbandBloodGroup";
        this.labelHusbandBloodGroup.TabIndex = 7;

        this.HusbandBloodGroup = new TTVisual.TTEnumComboBox();
        this.HusbandBloodGroup.DataTypeName = "BloodGroupEnum";
        this.HusbandBloodGroup.Name = "HusbandBloodGroup";
        this.HusbandBloodGroup.TabIndex = 11;

        this.WomanBloodGroup = new TTVisual.TTEnumComboBox();
        this.WomanBloodGroup.DataTypeName = "BloodGroupEnum";
        this.WomanBloodGroup.Name = "WomanBloodGroup";
        this.WomanBloodGroup.TabIndex = 28;

        this.labelDegreeOfRelationship = new TTVisual.TTLabel();
        this.labelDegreeOfRelationship.Text = i18n("M10638", "Akrabalık Durumu");
        this.labelDegreeOfRelationship.Name = "labelDegreeOfRelationship";
        this.labelDegreeOfRelationship.TabIndex = 5;

        this.DegreeOfRelationship = new TTVisual.TTEnumComboBox();
        this.DegreeOfRelationship.DataTypeName = "DegreeOfBloodRelativesEnum";
        this.DegreeOfRelationship.Name = "DegreeOfRelationship";
        this.DegreeOfRelationship.TabIndex = 4;

        this.labelDC = new TTVisual.TTLabel();
        this.labelDC.Text = "D&C";
        this.labelDC.Name = "labelDC";
        this.labelDC.TabIndex = 3;

        this.labelAbortion = new TTVisual.TTLabel();
        this.labelAbortion.Text = i18n("M10414", "Abortus");
        this.labelAbortion.Name = "labelAbortion";
        this.labelAbortion.TabIndex = 1;

        this.gridPregnancyCalendarColumns = [];
        this.tttabcontrol1.Controls = [this.tabGynecology, this.tabInfertility, this.tabPregnancy, this.tabPregCalendar];
        this.tabGynecology.Controls = [this.labelReproductiveAbnormalityGynecology, this.ReproductiveAbnormalityGynecology, this.labelVulvaVagenGynecology, this.VulvaVagenGynecology, this.labelVaginalDischargeInformationGynecology, this.VaginalDischargeInformationGynecology, this.VaginalDischargeGynecology, this.labelUterusGynecology, this.UterusGynecology, this.labelTumorMarkersGynecology, this.TumorMarkersGynecology, this.labelReproductiveAbnormalitiesInfoGynecology, this.ReproductiveAbnormalitiesInfoGynecology, this.labelPreviousBirthControlMethodGynecology, this.PreviousBirthControlMethodGynecology, this.labelPelvicExaminationGynecology, this.PelvicExaminationGynecology, this.labelMenstrualCycleInformationGynecology, this.MenstrualCycleInformationGynecology, this.labelMenstrualCycleAbnormalitiesGynecology, this.MenstrualCycleAbnormalitiesGynecology, this.labelLastSmearDateGynecology, this.LastSmearDateGynecology, this.labelLastExaminationDateGynecology, this.LastExaminationDateGynecology, this.labelHirsutismInformationGynecology, this.HirsutismInformationGynecology, this.HirsutismGynecology, this.labelGynecologicalHistoryGynecology, this.GynecologicalHistoryGynecology, this.labelGenitalExaminationGynecology, this.GenitalExaminationGynecology, this.labelGenitalAbnormalitiesInfoGynecology, this.GenitalAbnormalitiesInfoGynecology, this.labelGenitalAbnormalitiesGynecology, this.GenitalAbnormalitiesGynecology, this.labelDysuriaInformationGynecology, this.DysuriaInformationGynecology, this.DysuriaGynecology, this.labelDyspareuniaInformationGynecology, this.DyspareuniaInformationGynecology, this.DyspareuniaGynecology, this.labelCurrentBirthControlMethodGynecology, this.CurrentBirthControlMethodGynecology, this.labelCervixGynecology, this.CervixGynecology, this.labelBasalUltrasoundGynecology, this.BasalUltrasoundGynecology];
        this.tabPregCalendar.Controls = [this.gridPregnancyCalendar];
        this.Controls = [this.WomanBloodGroup, this.tttabcontrol1, this.tabGynecology, this.labelReproductiveAbnormalityGynecology, this.ReproductiveAbnormalityGynecology, this.labelVulvaVagenGynecology, this.VulvaVagenGynecology, this.labelVaginalDischargeInformationGynecology, this.VaginalDischargeInformationGynecology, this.VaginalDischargeGynecology, this.labelUterusGynecology, this.UterusGynecology, this.labelTumorMarkersGynecology, this.TumorMarkersGynecology, this.labelReproductiveAbnormalitiesInfoGynecology, this.ReproductiveAbnormalitiesInfoGynecology, this.labelPreviousBirthControlMethodGynecology, this.PreviousBirthControlMethodGynecology, this.labelPelvicExaminationGynecology, this.PelvicExaminationGynecology, this.labelMenstrualCycleInformationGynecology, this.MenstrualCycleInformationGynecology, this.labelMenstrualCycleAbnormalitiesGynecology, this.MenstrualCycleAbnormalitiesGynecology, this.labelLastSmearDateGynecology, this.LastSmearDateGynecology, this.labelLastExaminationDateGynecology, this.LastExaminationDateGynecology, this.labelHirsutismInformationGynecology, this.HirsutismInformationGynecology, this.HirsutismGynecology, this.labelGynecologicalHistoryGynecology, this.GynecologicalHistoryGynecology, this.labelGenitalExaminationGynecology, this.GenitalExaminationGynecology, this.labelGenitalAbnormalitiesInfoGynecology, this.GenitalAbnormalitiesInfoGynecology, this.labelGenitalAbnormalitiesGynecology, this.GenitalAbnormalitiesGynecology, this.labelDysuriaInformationGynecology, this.DysuriaInformationGynecology, this.DysuriaGynecology, this.labelDyspareuniaInformationGynecology, this.DyspareuniaInformationGynecology, this.DyspareuniaGynecology, this.labelCurrentBirthControlMethodGynecology, this.CurrentBirthControlMethodGynecology, this.labelCervixGynecology, this.CervixGynecology, this.labelBasalUltrasoundGynecology, this.BasalUltrasoundGynecology, this.tabInfertility, this.tabPregnancy, this.tabPregCalendar, this.gridPregnancyCalendar, this.Parity, this.NumberOfPregnancy, this.LivingBabies, this.HusbandFullName, this.DC, this.Abortion, this.MarriageDuration, this.ttbutton1, this.labelBloodGroup, this.MarriageDate, this.labelMarriageDate, this.btnPregnancyStart, this.labelMarriageDuration, this.labelRhIncompatibility, this.RhIncompatibility, this.labelParity, this.labelNumberOfPregnancy, this.labelLivingBabies, this.labelHusbandFullName, this.labelHusbandBloodGroup, this.HusbandBloodGroup, this.labelDegreeOfRelationship, this.DegreeOfRelationship, this.labelDC, this.labelAbortion];

    }


}
