//$910B79D4
import { Component, ViewChild, OnInit, ApplicationRef, ChangeDetectorRef, Input } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { MedicalOncologySpecialityFormViewModel, OncologyGridResultModel, ChemotherapyRadiotherapyRequestResponse } from './MedicalOncologySpecialityFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MedicalOncology, ChemoRadioCureProtocol, ChemotherapyRadiotherapy } from 'NebulaClient/Model/AtlasClientModel';

import { SpecialityBasedObjectForm } from '../Tibbi_Surec_Evrensel_Modulu/SpecialityBasedObjectForm';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { UserTemplateModel } from '../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel';
import { ChemoRadioOrderDetailItem, GetTemplateCureProtocolItem } from '../Kemoterapi_ve_Radyoterapi_Modulu/ChemotherapyRadiotherapyFormViewModel';
import { request } from 'http';
import { TTException } from 'app/NebulaClient/Utils/Exceptions/TTException';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'MedicalOncologySpecialityForm',
    templateUrl: './MedicalOncologySpecialityForm.html',
    providers: [MessageService]
})
export class MedicalOncologySpecialityForm extends SpecialityBasedObjectForm implements OnInit {
    Description: TTVisual.ITTRichTextBoxControl;
    FirstLineTreatment: TTVisual.ITTRichTextBoxControl;
    InterimEvaluation: TTVisual.ITTRichTextBoxControl;
    labelDescription: TTVisual.ITTLabel;
    labelFirstLineTreatment: TTVisual.ITTLabel;
    labelInterimEvaluation: TTVisual.ITTLabel;
    labelM2: TTVisual.ITTLabel;
    labelNB: TTVisual.ITTLabel;
    labelPathology: TTVisual.ITTLabel;
    labelPreTreatmentStaging: TTVisual.ITTLabel;
    labelPS: TTVisual.ITTLabel;
    labelSecondLineTreatment: TTVisual.ITTLabel;
    labelStory: TTVisual.ITTLabel;
    labelTA: TTVisual.ITTLabel;
    M2: TTVisual.ITTTextBox;
    NB: TTVisual.ITTTextBox;
    Pathology: TTVisual.ITTRichTextBoxControl;
    PreTreatmentStaging: TTVisual.ITTRichTextBoxControl;
    PS: TTVisual.ITTTextBox;
    SecondLineTreatment: TTVisual.ITTRichTextBoxControl;
    Story: TTVisual.ITTRichTextBoxControl;
    TA: TTVisual.ITTTextBox;
    public medicalOncologySpecialityFormViewModel: MedicalOncologySpecialityFormViewModel = new MedicalOncologySpecialityFormViewModel();
    public BMIValue: any;
    public showOldOncologyForm: boolean;
    public showOncologyGrid: boolean = true;
    public createRequest: boolean = false;
    public selectedProtocol: ChemoRadioCureProtocol;
    public showUserTemplatePopUp: boolean = false;

    @Input() set MedicalOncology(value: Guid) {
        this.ObjectID = value;
        this.showOncologyGrid = false;
    }

    public get _MedicalOncology(): MedicalOncology {
        return this._TTObject as MedicalOncology;
    }


    private MedicalOncologySpecialityForm_DocumentUrl: string = '/api/MedicalOncologyService/MedicalOncologySpecialityForm';
    constructor(protected httpService: NeHttpService, private changeDetectorRef: ChangeDetectorRef, protected messageService: MessageService, private sideBarMenuService: ISidebarMenuService) {
        super(httpService, messageService);
        this._DocumentServiceUrl = this.MedicalOncologySpecialityForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****
    protected async PreScript() {
        super.PreScript();

        this.AddHelpMenu();

    }

    public initViewModel(): void {
        this._TTObject = new MedicalOncology();
        this.medicalOncologySpecialityFormViewModel = new MedicalOncologySpecialityFormViewModel();
        this._ViewModel = this.medicalOncologySpecialityFormViewModel;
        this.medicalOncologySpecialityFormViewModel._MedicalOncology = this._TTObject as MedicalOncology;
    }

    protected loadViewModel() {
        let that = this;
        that.medicalOncologySpecialityFormViewModel = this._ViewModel as MedicalOncologySpecialityFormViewModel;
        that._TTObject = this.medicalOncologySpecialityFormViewModel._MedicalOncology;
        if (this.medicalOncologySpecialityFormViewModel == null)
            this.medicalOncologySpecialityFormViewModel = new MedicalOncologySpecialityFormViewModel();
        if (this.medicalOncologySpecialityFormViewModel._MedicalOncology == null)
            this.medicalOncologySpecialityFormViewModel._MedicalOncology = new MedicalOncology();

        this.GetAllOncologyForms();
    }

    async ngOnInit() {
        await this.load(MedicalOncologySpecialityFormViewModel);
    }

    public onDescriptionChanged(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.Description != event) {
            this._MedicalOncology.Description = event;
        }
    }

    public onFirstLineTreatmentChanged(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.FirstLineTreatment != event) {
            this._MedicalOncology.FirstLineTreatment = event;
        }
    }

    public onInterimEvaluationChanged(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.InterimEvaluation != event) {
            this._MedicalOncology.InterimEvaluation = event;
        }
    }

    public onM2Changed(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.M2 != event) {
            this._MedicalOncology.M2 = event;
        }
    }

    public onNBChanged(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.NB != event) {
            this._MedicalOncology.NB = event;
        }
    }

    public onPathologyChanged(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.Pathology != event) {
            this._MedicalOncology.Pathology = event;
        }
    }

    public onPreTreatmentStagingChanged(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.PreTreatmentStaging != event) {
            this._MedicalOncology.PreTreatmentStaging = event;
        }
    }

    public onPSChanged(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.PS != event) {
            this._MedicalOncology.PS = event;
        }
    }

    public onSecondLineTreatmentChanged(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.SecondLineTreatment != event) {
            this._MedicalOncology.SecondLineTreatment = event;
        }
    }

    public onStoryChanged(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.Story != event) {
            this._MedicalOncology.Story = event;
        }
    }

    public onTAChanged(event): void {
        if (this._MedicalOncology != null && this._MedicalOncology.TA != event) {
            this._MedicalOncology.TA = event;
        }
    }


    public OncologyForms;
    async GetAllOncologyForms() {

        let that = this;
        let apiUrlForPASearchUrl: string;
        let patientId: Guid = this.medicalOncologySpecialityFormViewModel._Patient.ObjectID;
        apiUrlForPASearchUrl = '/api/MedicalOncologyService/GetAllPatientBasedOncologyForms';

        let body = "";
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        try {
            let apiUrl: string = '/api/MedicalOncologyService/GetAllPatientBasedOncologyForms?patientId=' + patientId;
            let result = await this.httpService.get<Array<OncologyGridResultModel>>(apiUrl);
            if (result) {
                this.OncologyForms = result;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

    }



    public onRowPrepared(value: any) {
        let data: OncologyGridResultModel = value.data as OncologyGridResultModel;
        if (data != null && data.PhysicianApplicationId.toString().Equals(this.medicalOncologySpecialityFormViewModel.actionId)) {
            value.rowElement.firstItem().style.backgroundColor = '#FFE8B9';
        }
    }

    public onHeightChanged(event): void {
        if (event != null) {
            if (this._MedicalOncology != null && this._MedicalOncology.Height != event) {
                this._MedicalOncology.Height = event;
                this.calculateBMI();
            }
        }
    }

    public onWeightChanged(event): void {
        if (event != null) {
            if (this._MedicalOncology != null && this._MedicalOncology.Weight != event) {
                this._MedicalOncology.Weight = event;
                this.calculateBMI();
            }
        }
    }

    calculateBMI() {
        if (this._MedicalOncology.Height != undefined && this._MedicalOncology.Weight != undefined) {
            let weight = this._MedicalOncology.Weight;
            let height = this._MedicalOncology.Height;
            this.medicalOncologySpecialityFormViewModel.BMIValue = Number((weight / ((height / 100) ** 2)).toFixed(2));
        }
    }

    public oldOncologyFormID;
    public async selectionChangedHandlerOnForms(event) {
        try {
            this.oldOncologyFormID = event.selectedRowKeys[0];
            this.showOldOncologyForm = true;
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

        this.changeDetectorRef.detectChanges();
    }

    public popUpClosed(e: any) {
        this.showOldOncologyForm = false;
        this.showOncologyGrid = true;
    }

    
    public async OpenChemoRadioPopUp() {

        if(this.medicalOncologySpecialityFormViewModel.hasDiagnosis == false)
        {
            this.messageService.showError("Ön Tanı ya da Tanı girişi yapılmadan istem yapılamaz");
            return;
        }
        if(this.medicalOncologySpecialityFormViewModel.hasChemoRadioRequest == true)
        {
            this.messageService.showError("Bu kabulde daha önce oluşturulmuş bir kemoterapi / radyoterapi isteği bulunmaktadır");
            return;
        }

        let that = this;
        await this.httpService.get<any>('/api/MedicalOncologyService/CreateProtocolSourceList').then(response => {
            let result = response;
            if (result) {
                this.medicalOncologySpecialityFormViewModel.userTemplateList = result;
                this.createRequest = true;
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });
    }
    
    public closeProcedurePlanningFormPopUp(event : boolean = null){
        this.showProcedurePlanningForm = false;
    }

    public ChemoRadioRequestDescription: string;
    public createdChemotherapyObject: ChemotherapyRadiotherapy;
    public showProcedurePlanningForm: boolean = false;
    public async CreateChemoRadioRequest() {
        let that = this;
        let requestURL : string = '/api/EpisodeActionService/CreateChemotheraphyRadiotheraphyRequest?actionId=' + this.medicalOncologySpecialityFormViewModel.actionId + "&requestDescription=" + this.ChemoRadioRequestDescription ;
        if(this.protocolObjectID != null)
        {
            requestURL = requestURL + "&protocolID=" + this.protocolObjectID;
        }
        else
        {
            requestURL = requestURL + "&protocolID=";
        }
        that.httpService.get<ChemotherapyRadiotherapyRequestResponse>(requestURL).then(
           async result => {
                this.messageService.showInfo("İstek Oluşturuldu");
                let messageBoxResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "İstem Planlamak İstiyor musunuz? "), 1);
                if (messageBoxResult === "E") {                                                       
                    that.showProcedurePlanningForm = true;
                    that.createdChemotherapyObject = result.chemotherapyRadiotherapy; 
                }
                this.createRequest = false;
                this.medicalOncologySpecialityFormViewModel.hasChemoRadioRequest = true;
            }).catch(error => {
                this.messageService.showError(error);
            });
    }

    public protocolObjectID: Guid;
    async SelectUserTemplate(event: any): Promise<void> {
        if (event.itemData != null) {

            if (event.itemData.ObjectID != null) {

                this.protocolObjectID = event.itemData.TAObjectID;
                let apiUrl: string = 'api/ChemotherapyRadiotherapyService/GetProtocolItemByTemplate?templateId=' + event.itemData.ObjectID.toString();
                await this.httpService.get<GetTemplateCureProtocolItem>(apiUrl).then(result => {
                    let templateCureProtocol = result as GetTemplateCureProtocolItem;
                    this.selectedProtocol = new ChemoRadioCureProtocol();
                    this.selectedProtocol.AfterCureTime = templateCureProtocol.cureProtocol.AfterCureTime;
                    this.selectedProtocol.CureCount = templateCureProtocol.cureProtocol.CureCount;
                    this.selectedProtocol.CureDescription = templateCureProtocol.cureProtocol.CureDescription;
                    this.selectedProtocol.CureTime = templateCureProtocol.cureProtocol.CureTime;
                    this.selectedProtocol.DrugDose = templateCureProtocol.cureProtocol.DrugDose;
                    this.selectedProtocol.IsRadiotherapyCure = templateCureProtocol.cureProtocol.IsRadiotherapyCure;
                    this.selectedProtocol.PreCureMinute = templateCureProtocol.cureProtocol.PreCureMinute;
                    this.selectedProtocol.RepetitiveDayCount = templateCureProtocol.cureProtocol.RepetitiveDayCount;
                    this.selectedProtocol.SolventDose = templateCureProtocol.cureProtocol.SolventDose;
                    this.selectedProtocol.Material = templateCureProtocol.Material;
                    this.selectedProtocol.EtkinMadde = templateCureProtocol.EtkinMadde;
                    this.selectedProtocol.ChemotherapyApplyMethod = templateCureProtocol.ApplyMethod;
                    this.selectedProtocol.ChemotherapyApplySubMethod = templateCureProtocol.ApplySubMethod;
                    this.selectedProtocol.RadiotherapyXRayTypeDef = templateCureProtocol.RadiotherapyXRayTypeDef;
                    this.selectedProtocol.Solvent = templateCureProtocol.Solvent;
                  
                    this.showUserTemplatePopUp = true;
                });

       
            }
        }

    }



    protected redirectProperties(): void {
        redirectProperty(this.PreTreatmentStaging, "Rtf", this.__ttObject, "PreTreatmentStaging");
        redirectProperty(this.InterimEvaluation, "Rtf", this.__ttObject, "InterimEvaluation");
        redirectProperty(this.FirstLineTreatment, "Rtf", this.__ttObject, "FirstLineTreatment");
        redirectProperty(this.SecondLineTreatment, "Rtf", this.__ttObject, "SecondLineTreatment");
        redirectProperty(this.PS, "Text", this.__ttObject, "PS");
        redirectProperty(this.TA, "Text", this.__ttObject, "TA");
        redirectProperty(this.NB, "Text", this.__ttObject, "NB");
        redirectProperty(this.M2, "Text", this.__ttObject, "M2");
        redirectProperty(this.Story, "Rtf", this.__ttObject, "Story");
        redirectProperty(this.Pathology, "Rtf", this.__ttObject, "Pathology");
        redirectProperty(this.Description, "Rtf", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelM2 = new TTVisual.TTLabel();
        this.labelM2.Text = "M2";
        this.labelM2.Name = "labelM2";
        this.labelM2.TabIndex = 21;

        this.M2 = new TTVisual.TTTextBox();
        this.M2.Name = "M2";
        this.M2.TabIndex = 20;

        this.NB = new TTVisual.TTTextBox();
        this.NB.Name = "NB";
        this.NB.TabIndex = 18;

        this.TA = new TTVisual.TTTextBox();
        this.TA.Name = "TA";
        this.TA.TabIndex = 16;

        this.PS = new TTVisual.TTTextBox();
        this.PS.Name = "PS";
        this.PS.TabIndex = 14;

        this.labelNB = new TTVisual.TTLabel();
        this.labelNB.Text = "NB";
        this.labelNB.Name = "labelNB";
        this.labelNB.TabIndex = 19;

        this.labelTA = new TTVisual.TTLabel();
        this.labelTA.Text = "TA";
        this.labelTA.Name = "labelTA";
        this.labelTA.TabIndex = 17;

        this.labelPS = new TTVisual.TTLabel();
        this.labelPS.Text = "PS";
        this.labelPS.Name = "labelPS";
        this.labelPS.TabIndex = 15;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = "Açıklama";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 13;

        this.Description = new TTVisual.TTRichTextBoxControl();
        this.Description.Name = "Description";
        this.Description.TabIndex = 12;

        this.labelPathology = new TTVisual.TTLabel();
        this.labelPathology.Text = "Patoloji";
        this.labelPathology.Name = "labelPathology";
        this.labelPathology.TabIndex = 11;

        this.Pathology = new TTVisual.TTRichTextBoxControl();
        this.Pathology.Name = "Pathology";
        this.Pathology.TabIndex = 10;

        this.labelStory = new TTVisual.TTLabel();
        this.labelStory.Text = "Öykü";
        this.labelStory.Name = "labelStory";
        this.labelStory.TabIndex = 9;

        this.Story = new TTVisual.TTRichTextBoxControl();
        this.Story.Name = "Story";
        this.Story.TabIndex = 8;

        this.labelSecondLineTreatment = new TTVisual.TTLabel();
        this.labelSecondLineTreatment.Text = "İkinci Basamak Tedavi";
        this.labelSecondLineTreatment.Name = "labelSecondLineTreatment";
        this.labelSecondLineTreatment.TabIndex = 7;

        this.SecondLineTreatment = new TTVisual.TTRichTextBoxControl();
        this.SecondLineTreatment.Name = "SecondLineTreatment";
        this.SecondLineTreatment.TabIndex = 6;

        this.labelFirstLineTreatment = new TTVisual.TTLabel();
        this.labelFirstLineTreatment.Text = "İlk Basamak Tedavi";
        this.labelFirstLineTreatment.Name = "labelFirstLineTreatment";
        this.labelFirstLineTreatment.TabIndex = 5;

        this.FirstLineTreatment = new TTVisual.TTRichTextBoxControl();
        this.FirstLineTreatment.Name = "FirstLineTreatment";
        this.FirstLineTreatment.TabIndex = 4;

        this.labelInterimEvaluation = new TTVisual.TTLabel();
        this.labelInterimEvaluation.Text = "Ara Değerlendirme";
        this.labelInterimEvaluation.Name = "labelInterimEvaluation";
        this.labelInterimEvaluation.TabIndex = 3;

        this.InterimEvaluation = new TTVisual.TTRichTextBoxControl();
        this.InterimEvaluation.Name = "InterimEvaluation";
        this.InterimEvaluation.TabIndex = 2;

        this.labelPreTreatmentStaging = new TTVisual.TTLabel();
        this.labelPreTreatmentStaging.Text = "Tedavi Öncesi Evreleme";
        this.labelPreTreatmentStaging.Name = "labelPreTreatmentStaging";
        this.labelPreTreatmentStaging.TabIndex = 1;

        this.PreTreatmentStaging = new TTVisual.TTRichTextBoxControl();
        this.PreTreatmentStaging.Name = "PreTreatmentStaging";
        this.PreTreatmentStaging.TabIndex = 0;

        this.Controls = [this.labelM2, this.M2, this.NB, this.TA, this.PS, this.labelNB, this.labelTA, this.labelPS, this.labelDescription, this.Description, this.labelPathology, this.Pathology, this.labelStory, this.Story, this.labelSecondLineTreatment, this.SecondLineTreatment, this.labelFirstLineTreatment, this.FirstLineTreatment, this.labelInterimEvaluation, this.InterimEvaluation, this.labelPreTreatmentStaging, this.PreTreatmentStaging];

    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let chemoRadioRequest = new DynamicSidebarMenuItem();
        chemoRadioRequest.key = 'chemoRadioRequest';
        chemoRadioRequest.icon = 'fa fa-plus-square';
        chemoRadioRequest.label = 'Kemoterapi / Radyoterapi';
        chemoRadioRequest.componentInstance = this;
        chemoRadioRequest.clickFunction = this.OpenChemoRadioPopUp;
        chemoRadioRequest.parameterFunctionInstance = this;
        chemoRadioRequest.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', chemoRadioRequest);

    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('chemoRadioRequest');

    }


}
