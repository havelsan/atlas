//$8A399A78
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyTestApproveFormViewModel } from './RadiologyTestApproveFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ITTObject } from 'NebulaClient/StorageManager/InstanceManagement/ITTObject';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTestBaseForm } from "Modules/Tibbi_Surec/Radyoloji_Modulu/RadiologyTestBaseForm";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SagSol } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';

@Component({
    selector: 'RadiologyTestApproveForm',
    templateUrl: './RadiologyTestApproveForm.html',
    providers: [MessageService]
})
export class RadiologyTestApproveForm extends RadiologyTestBaseForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AccessionNo: TTVisual.ITTTextBox;
    Amount: TTVisual.ITTTextBoxColumn;
    ApprovedBy: TTVisual.ITTObjectListBox;
    Barcode: TTVisual.ITTTextBoxColumn;
    cityOfBirth: TTVisual.ITTObjectListBox;
    cmdReport: TTVisual.ITTButton;
    cmdSaveAndPrint: TTVisual.ITTButton;
    CommonDescription: TTVisual.ITTTextBox;
    Deparment: TTVisual.ITTObjectListBox;
    Description: TTVisual.ITTTextBox;
    DisTaahhutNo: TTVisual.ITTTextBox;
    DistributionType: TTVisual.ITTTextBoxColumn;
    DPADetailFirmPriceOffer: TTVisual.ITTListBoxColumn;
    encboSex: TTVisual.ITTEnumComboBox;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    Equipment: TTVisual.ITTObjectListBox;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    kdv: TTVisual.ITTTextBoxColumn;
    kodsuzMalzemeFiyati: TTVisual.ITTTextBoxColumn;
    labelDisTaahhutNo: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    malzemeBrans: TTVisual.ITTTextBoxColumn;
    malzemeCokluOzelDurum: TTVisual.ITTButtonColumn;
    malzemeOzelDurum: TTVisual.ITTListBoxColumn;
    malzemeSatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    malzemeTuru: TTVisual.ITTListBoxColumn;
    Material: TTVisual.ITTListBoxColumn;
    Materials: TTVisual.ITTGrid;
    OwnerType: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PatientBirthDate: TTVisual.ITTDateTimePicker;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    ProcedureObject: TTVisual.ITTObjectListBox;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    ReportedBy: TTVisual.ITTObjectListBox;
    rtfReport: TTVisual.ITTRichTextBoxControl;
    SurgeryDirectPurchaseGrids: TTVisual.ITTGrid;
    tabAdditionalRequest: TTVisual.ITTTabPage;
    tabAnamnez: TTVisual.ITTTabPage;
    tabDescription: TTVisual.ITTTabPage;
    tanCokluOzelDurum: TTVisual.ITTButtonColumn;
    taniOzelDurum: TTVisual.ITTListBoxColumn;
    TestDate: TTVisual.ITTDateTimePicker;
    TestTechnicianNote: TTVisual.ITTTextBox;
    ttbuttonToothSchema: TTVisual.ITTButton;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    ttlabel19: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttlabelBirim: TTVisual.ITTLabel;
    ttlabelDrAnesteziTescilNo: TTVisual.ITTLabel;
    ttlabelKesi: TTVisual.ITTLabel;
    ttlabelSagSol: TTVisual.ITTLabel;
    TTListBox: TTVisual.ITTObjectListBox;
    TTListBoxDrAnesteziTescilNo: TTVisual.ITTObjectListBox;
    TTListBoxKesi: TTVisual.ITTObjectListBox;
    ttMasterResourceUserCheck: TTVisual.ITTCheckBox;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox4: TTVisual.ITTTextBox;
    tttextboxBirim: TTVisual.ITTTextBox;
    txtBarcode: TTVisual.ITTTextBoxColumn;
    txtKesinlesenMiktar: TTVisual.ITTTextBoxColumn;
    public GridEpisodeDiagnosisColumns = [];
    public MaterialsColumns = [];
    public SurgeryDirectPurchaseGridsColumns = [];
    public radiologyTestApproveFormViewModel: RadiologyTestApproveFormViewModel = new RadiologyTestApproveFormViewModel();
    public get _RadiologyTest(): RadiologyTest {
        return this._TTObject as RadiologyTest;
    }
    private RadiologyTestApproveForm_DocumentUrl: string = '/api/RadiologyTestService/RadiologyTestApproveForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RadiologyTestApproveForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async cmdReport_Click(): Promise<void> {

        if (this._RadiologyTest.AccessionNo != null)
        {
            let accessionNoStr: string = this._RadiologyTest.AccessionNo.toString();
            
            let sysparam: string = (await SystemParameterService.GetParameterValue("PACSVIEWERURL", null));
            let URLLink: string = "";

            if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "EXTREME") {
                URLLink = sysparam + "?an=" + accessionNoStr + "&usr=extreme";

            }
            else if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "COMPANY1") == "COMPANY2") {
                URLLink = sysparam + "?accession=" + accessionNoStr + "&patientid=" + this._RadiologyTest.Episode.Patient.UniqueRefNo.toString() + "&ietab=true";
            }
            else if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "XXXXXX") {
                URLLink = sysparam + "&accession=" +  accessionNoStr +"&StudyReload=1";
            }

            if (URLLink == null) {
                InfoBox.Alert(i18n("M16463", "İmaj gösterme linki bulunamadı!"));
            } else {
                let win = window.open(URLLink, '_blank');
                win.focus();
            }
        }else
        {
            InfoBox.Alert(i18n("M16463", "İmaj gösterme linki bulunamadı!"));
        }

    }
    public async cmdSaveAndPrint_Click(): Promise<void> {
        /*
        this._RadiologyTest.ObjectContext.Save();
        let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
        let objectID: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
        objectID.push("VALUE", this._RadiologyTest.ObjectID.toString());
        parameters.push("TTOBJECTID", objectID);
        TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_RadiologyTestResultReport, true, 1, parameters);
        */
    }
    public async GridEpisodeDiagnosis_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //TODO:ShowEdit!
        //if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
        //{

        //    RadiologyTestCokluOzelDurum rtcod = new RadiologyTestCokluOzelDurum();
        //    rtcod.ShowEdit(this.FindForm(), this._RadiologyTest);
        //}
        let a = 1;
    }
    public async Materials_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //TODO:ShowEdit!
        //if (((ITTGridCell)Materials.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
        //{
        //    RadiologyTestCokluOzelDurum rtcod = new RadiologyTestCokluOzelDurum();
        //    rtcod.ShowEdit(this.FindForm(), this._RadiologyTest);
        //}
        let a = 1;
    }
    public async ttbuttonToothSchema_Click(): Promise<void> {
        //TODO:ShowEdit!
        //RadiologyTestDentalToothSchema radiologyTestDentalForm = new RadiologyTestDentalToothSchema();
        //if (radiologyTestDentalForm != null)
        //    radiologyTestDentalForm.ShowReadOnly(this,_RadiologyTest);
        let a = 1;
    }
    public async ttMasterResourceUserCheck_CheckedChanged(): Promise<void> {
        if (this.ttMasterResourceUserCheck.Value === true) {
            this.ReportedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource.ObjectID.toString() + "'";
            this.ApprovedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource.ObjectID.toString() + "'";
        }
        else {
            this.ReportedBy.ListFilterExpression = null;
            this.ApprovedBy.ListFilterExpression = null;
        }
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        super.ClientSidePostScript(transDef);
        if (transDef !== null) {
            if (transDef.FromStateDefID === RadiologyTest.RadiologyTestStates.Approve && transDef.ToStateDefID === RadiologyTest.RadiologyTestStates.Procedure)
                this.DisplayRadiologyRepeatReason();
            if (transDef.FromStateDefID === RadiologyTest.RadiologyTestStates.Approve && transDef.ToStateDefID === RadiologyTest.RadiologyTestStates.Completed)
                this.LinkRadiologyTestToCopyReportInfo(transDef);
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
    }
    protected async PreScript() {
        super.PreScript();
        this.SetProcedureDoctorAsCurrentResource();
        if (!(<ITTObject>this._RadiologyTest).IsReadOnly) {
            //this._RadiologyTest.ApprovedBy = Common.CurrentResource;
            this._RadiologyTest.ApprovedBy = this._RadiologyTest.ProcedureDoctor;
        }
        if (this.ttMasterResourceUserCheck.Value !== null && this.ttMasterResourceUserCheck.Value === true) {
            this.ReportedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource + "'";
            this.ApprovedBy.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._RadiologyTest.MasterResource + "'";
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void>
    {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("RADIOLOGYTEST", this.radiologyTestApproveFormViewModel._RadiologyTest.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
        await this.load(RadiologyTestApproveFormViewModel);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RadiologyTest();
        this.radiologyTestApproveFormViewModel = new RadiologyTestApproveFormViewModel();
        this._ViewModel = this.radiologyTestApproveFormViewModel;
        this.radiologyTestApproveFormViewModel._RadiologyTest = this._TTObject as RadiologyTest;
        this.radiologyTestApproveFormViewModel._RadiologyTest.Episode = new Episode();
        this.radiologyTestApproveFormViewModel._RadiologyTest.Episode.Patient = new Patient();
       // this.radiologyTestApproveFormViewModel._RadiologyTest.Episode.Patient.CityOfBirth = new SKRSILKodlari();
        this.radiologyTestApproveFormViewModel._RadiologyTest.Episode.Patient.Sex = new SKRSCinsiyet();
        this.radiologyTestApproveFormViewModel._RadiologyTest.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.radiologyTestApproveFormViewModel._RadiologyTest.Radiology = new Radiology();
        this.radiologyTestApproveFormViewModel._RadiologyTest.Radiology.RequestDoctor = new ResUser();
        this.radiologyTestApproveFormViewModel._RadiologyTest.ResUser = new ResUser();
        this.radiologyTestApproveFormViewModel._RadiologyTest.SagSol = new SagSol();
        this.radiologyTestApproveFormViewModel._RadiologyTest.AyniFarkliKesi = new AyniFarkliKesi();
        this.radiologyTestApproveFormViewModel._RadiologyTest.Equipment = new ResRadiologyEquipment();
        this.radiologyTestApproveFormViewModel._RadiologyTest.ProcedureObject = new ProcedureDefinition();
        this.radiologyTestApproveFormViewModel._RadiologyTest.Department = new ResRadiologyDepartment();
        this.radiologyTestApproveFormViewModel._RadiologyTest.RadiologyTestTreatmentMaterial = new Array<RadiologyMaterial>();
        this.radiologyTestApproveFormViewModel._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids = new Array<SurgeryDirectPurchaseGrid>();
        this.radiologyTestApproveFormViewModel._RadiologyTest.ReportedBy = new ResUser();
        this.radiologyTestApproveFormViewModel._RadiologyTest.ProcedureDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyTestApproveFormViewModel = this._ViewModel as RadiologyTestApproveFormViewModel;
        that._TTObject = this.radiologyTestApproveFormViewModel._RadiologyTest;
        if (this.radiologyTestApproveFormViewModel == null)
            this.radiologyTestApproveFormViewModel = new RadiologyTestApproveFormViewModel();
        if (this.radiologyTestApproveFormViewModel._RadiologyTest == null)
            this.radiologyTestApproveFormViewModel._RadiologyTest = new RadiologyTest();
        let episodeObjectID = that.radiologyTestApproveFormViewModel._RadiologyTest["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.radiologyTestApproveFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.radiologyTestApproveFormViewModel._RadiologyTest.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.radiologyTestApproveFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                 /*   if (patient != null) {
                        let cityOfBirthObjectID = patient["CityOfBirth"];
                        if (cityOfBirthObjectID != null && (typeof cityOfBirthObjectID === 'string')) {
                            let cityOfBirth = that.radiologyTestApproveFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === cityOfBirthObjectID.toString());
                            patient.CityOfBirth = cityOfBirth;
                        }
                    }*/
                    if (patient != null) {
                        let sexObjectID = patient["Sex"];
                        if (sexObjectID != null && (typeof sexObjectID === 'string')) {
                            let sex = that.radiologyTestApproveFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === sexObjectID.toString());
                             if (sex) {
                                patient.Sex = sex;
                            }
                        }
                    }
                }
            }
            if (episode != null) {
                episode.Diagnosis = that.radiologyTestApproveFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.radiologyTestApproveFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.radiologyTestApproveFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.radiologyTestApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                         if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                    let ozelDurumObjectID = detailItem["OzelDurum"];
                    if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                        let ozelDurum = that.radiologyTestApproveFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                         if (ozelDurum) {
                            detailItem.OzelDurum = ozelDurum;
                        }
                    }
                }
            }
        }
        let radiologyObjectID = that.radiologyTestApproveFormViewModel._RadiologyTest["EpisodeAction"];
        if (radiologyObjectID != null && (typeof radiologyObjectID === 'string')) {
            let radiology = that.radiologyTestApproveFormViewModel.Radiologys.find(o => o.ObjectID.toString() === radiologyObjectID.toString());
             if (radiology) {
                that.radiologyTestApproveFormViewModel._RadiologyTest.Radiology = radiology;
            }
            that.radiologyTestApproveFormViewModel._RadiologyTest.Radiology.Episode = that.radiologyTestApproveFormViewModel._RadiologyTest.Episode;
            if (radiology != null) {
                let requestDoctorObjectID = radiology["RequestDoctor"];
                if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
                    let requestDoctor = that.radiologyTestApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
                     if (requestDoctor) {
                        radiology.RequestDoctor = requestDoctor;
                    }
                }
            }
        }
        let resUserObjectID = that.radiologyTestApproveFormViewModel._RadiologyTest["ResUser"];
        if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
            let resUser = that.radiologyTestApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
             if (resUser) {
                that.radiologyTestApproveFormViewModel._RadiologyTest.ResUser = resUser;
            }
        }
        let sagSolObjectID = that.radiologyTestApproveFormViewModel._RadiologyTest["SagSol"];
        if (sagSolObjectID != null && (typeof sagSolObjectID === 'string')) {
            let sagSol = that.radiologyTestApproveFormViewModel.SagSols.find(o => o.ObjectID.toString() === sagSolObjectID.toString());
             if (sagSol) {
                that.radiologyTestApproveFormViewModel._RadiologyTest.SagSol = sagSol;
            }
        }
        let ayniFarkliKesiObjectID = that.radiologyTestApproveFormViewModel._RadiologyTest["AyniFarkliKesi"];
        if (ayniFarkliKesiObjectID != null && (typeof ayniFarkliKesiObjectID === 'string')) {
            let ayniFarkliKesi = that.radiologyTestApproveFormViewModel.AyniFarkliKesis.find(o => o.ObjectID.toString() === ayniFarkliKesiObjectID.toString());
             if (ayniFarkliKesi) {
                that.radiologyTestApproveFormViewModel._RadiologyTest.AyniFarkliKesi = ayniFarkliKesi;
            }
        }
        let equipmentObjectID = that.radiologyTestApproveFormViewModel._RadiologyTest["Equipment"];
        if (equipmentObjectID != null && (typeof equipmentObjectID === 'string')) {
            let equipment = that.radiologyTestApproveFormViewModel.ResRadiologyEquipments.find(o => o.ObjectID.toString() === equipmentObjectID.toString());
             if (equipment) {
                that.radiologyTestApproveFormViewModel._RadiologyTest.Equipment = equipment;
            }
        }
        let procedureObjectObjectID = that.radiologyTestApproveFormViewModel._RadiologyTest["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
            let procedureObject = that.radiologyTestApproveFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
             if (procedureObject) {
                that.radiologyTestApproveFormViewModel._RadiologyTest.ProcedureObject = procedureObject;
            }
        }
        let departmentObjectID = that.radiologyTestApproveFormViewModel._RadiologyTest["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === 'string')) {
            let department = that.radiologyTestApproveFormViewModel.ResRadiologyDepartments.find(o => o.ObjectID.toString() === departmentObjectID.toString());
             if (department) {
                that.radiologyTestApproveFormViewModel._RadiologyTest.Department = department;
            }
        }
        that.radiologyTestApproveFormViewModel._RadiologyTest.RadiologyTestTreatmentMaterial = that.radiologyTestApproveFormViewModel.MaterialsGridList;
        for (let detailItem of that.radiologyTestApproveFormViewModel.MaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.radiologyTestApproveFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.radiologyTestApproveFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.radiologyTestApproveFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let malzemeTuruObjectID = detailItem["MalzemeTuru"];
            if (malzemeTuruObjectID != null && (typeof malzemeTuruObjectID === 'string')) {
                let malzemeTuru = that.radiologyTestApproveFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
                 if (malzemeTuru) {
                    detailItem.MalzemeTuru = malzemeTuru;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.radiologyTestApproveFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        that.radiologyTestApproveFormViewModel._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids = that.radiologyTestApproveFormViewModel.SurgeryDirectPurchaseGridsGridList;
        for (let detailItem of that.radiologyTestApproveFormViewModel.SurgeryDirectPurchaseGridsGridList) {
            let dPADetailFirmPriceOfferObjectID = detailItem["DPADetailFirmPriceOffer"];
            if (dPADetailFirmPriceOfferObjectID != null && (typeof dPADetailFirmPriceOfferObjectID === 'string')) {
                let dPADetailFirmPriceOffer = that.radiologyTestApproveFormViewModel.DPADetailFirmPriceOffers.find(o => o.ObjectID.toString() === dPADetailFirmPriceOfferObjectID.toString());
                 if (dPADetailFirmPriceOffer) {
                    detailItem.DPADetailFirmPriceOffer = dPADetailFirmPriceOffer;
                }
                if (dPADetailFirmPriceOffer != null) {
                    let offeredUBBObjectID = dPADetailFirmPriceOffer["OfferedUBB"];
                    if (offeredUBBObjectID != null && (typeof offeredUBBObjectID === 'string')) {
                        let offeredUBB = that.radiologyTestApproveFormViewModel.ProductDefinitions.find(o => o.ObjectID.toString() === offeredUBBObjectID.toString());
                         if (offeredUBB) {
                            dPADetailFirmPriceOffer.OfferedUBB = offeredUBB;
                        }
                    }
                }
                if (dPADetailFirmPriceOffer != null) {
                    let directPurchaseActionDetailObjectID = dPADetailFirmPriceOffer["DirectPurchaseActionDetail"];
                    if (directPurchaseActionDetailObjectID != null && (typeof directPurchaseActionDetailObjectID === 'string')) {
                        let directPurchaseActionDetail = that.radiologyTestApproveFormViewModel.DirectPurchaseActionDetails.find(o => o.ObjectID.toString() === directPurchaseActionDetailObjectID.toString());
                         if (directPurchaseActionDetail) {
                            dPADetailFirmPriceOffer.DirectPurchaseActionDetail = directPurchaseActionDetail;
                        }
                    }
                }
            }
        }
        let reportedByObjectID = that.radiologyTestApproveFormViewModel._RadiologyTest["ReportedBy"];
        if (reportedByObjectID != null && (typeof reportedByObjectID === 'string')) {
            let reportedBy = that.radiologyTestApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === reportedByObjectID.toString());
             if (reportedBy) {
                that.radiologyTestApproveFormViewModel._RadiologyTest.ReportedBy = reportedBy;
            }
        }
        let procedureDoctorObjectID = that.radiologyTestApproveFormViewModel._RadiologyTest["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.radiologyTestApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.radiologyTestApproveFormViewModel._RadiologyTest.ProcedureDoctor = procedureDoctor;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyTestApproveFormViewModel);
        this.AddHelpMenu();
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ActionDate != event) {
                this._RadiologyTest.ActionDate = event;
            }
        }
    }

    public onApprovedByChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ProcedureDoctor != event) {
                this._RadiologyTest.ProcedureDoctor = event;
            }
        }
    }

    public oncityOfBirthChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Episode != null &&
                this._RadiologyTest.Episode.Patient != null && this._RadiologyTest.Episode.Patient.BirthPlace != event) {
                this._RadiologyTest.Episode.Patient.BirthPlace = event;
            }
        }
    }

    public onCommonDescriptionChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.GeneralDescription != event) {
                this._RadiologyTest.GeneralDescription = event;
            }
        }
    }

    public onDeparmentChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.Department != event) {
                this._RadiologyTest.Department = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.Description != event) {
                this._RadiologyTest.Description = event;
            }
        }
    }

    public onDisTaahhutNoChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.DisTaahhutNo != event) {
                this._RadiologyTest.DisTaahhutNo = event;
            }
        }
    }

    public onencboSexChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Episode != null &&
                this._RadiologyTest.Episode.Patient != null && this._RadiologyTest.Episode.Patient.Sex != event) {
                this._RadiologyTest.Episode.Patient.Sex = event;
            }
        }
    }

    public onEquipmentChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.Equipment != event) {
                this._RadiologyTest.Equipment = event;
            }
        }
    }

    public onOwnerTypeChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.OwnerType != event) {
                this._RadiologyTest.OwnerType = event;
            }
        }
    }

    public onPatientBirthDateChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Episode != null &&
                this._RadiologyTest.Episode.Patient != null && this._RadiologyTest.Episode.Patient.BirthDate != event) {
                this._RadiologyTest.Episode.Patient.BirthDate = event;
            }
        }
    }

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.PreDiagnosis != event) {
                this._RadiologyTest.PreDiagnosis = event;
            }
        }
    }

    public onProcedureObjectChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ProcedureObject != event) {
                this._RadiologyTest.ProcedureObject = event;
            }
        }
    }

    public onReportedByChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ReportedBy != event) {
                this._RadiologyTest.ReportedBy = event;
            }
        }
    }

    public onrtfReportChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.Report != event) {
                this._RadiologyTest.Report = event;
            }
        }
    }

    public onTestDateChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.TestDate != event) {
                this._RadiologyTest.TestDate = event;
            }
        }
    }

    public onTestTechnicianNoteChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.TechnicianNote != event) {
                this._RadiologyTest.TechnicianNote = event;
            }
        }
    }

    public onTTListBoxChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.SagSol != event) {
                this._RadiologyTest.SagSol = event;
            }
        }
    }

    public onTTListBoxDrAnesteziTescilNoChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ResUser != event) {
                this._RadiologyTest.ResUser = event;
            }
        }
    }

    public onTTListBoxKesiChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.AyniFarkliKesi != event) {
                this._RadiologyTest.AyniFarkliKesi = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Radiology != null && this._RadiologyTest.Radiology.RequestDoctor != event) {
                this._RadiologyTest.Radiology.RequestDoctor = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Episode != null && this._RadiologyTest.Episode.HospitalProtocolNo != event) {
                this._RadiologyTest.Episode.HospitalProtocolNo = event;
            }
        }
    }

    public ontttextbox4Changed(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.AdditionalRequest != event) {
                this._RadiologyTest.AdditionalRequest = event;
            }
        }
    }

    public ontttextboxBirimChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.birim != event) {
                this._RadiologyTest.birim = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Episode.HospitalProtocolNo");
        redirectProperty(this.PatientBirthDate, "Value", this.__ttObject, "Episode.Patient.BirthDate");
        redirectProperty(this.encboSex, "Value", this.__ttObject, "Episode.Patient.Sex");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.CommonDescription, "Text", this.__ttObject, "GeneralDescription");
        redirectProperty(this.tttextbox4, "Text", this.__ttObject, "AdditionalRequest");
        redirectProperty(this.TestDate, "Value", this.__ttObject, "TestDate");
        redirectProperty(this.tttextboxBirim, "Text", this.__ttObject, "birim");
        redirectProperty(this.DisTaahhutNo, "Text", this.__ttObject, "DisTaahhutNo");
        redirectProperty(this.rtfReport, "Rtf", this.__ttObject, "Report");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.TestTechnicianNote, "Text", this.__ttObject, "TechnicianNote");
        redirectProperty(this.OwnerType, "Text", this.__ttObject, "OwnerType");
    }

    public initFormControls(): void {
        this.ttMasterResourceUserCheck = new TTVisual.TTCheckBox();
        this.ttMasterResourceUserCheck.Value = true;
        this.ttMasterResourceUserCheck.Text = i18n("M21102", "Sadece Bölüme Bağlı Kullanıcıları Listele");
        this.ttMasterResourceUserCheck.Name = "ttMasterResourceUserCheck";
        this.ttMasterResourceUserCheck.TabIndex = 12;

        this.cmdReport = new TTVisual.TTButton();
        this.cmdReport.Text = i18n("M16462", "İmaj Görüntüle");
        this.cmdReport.Name = "cmdReport";
        this.cmdReport.TabIndex = 13;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 4;

        this.OwnerType = new TTVisual.TTTextBox();
        this.OwnerType.Name = "OwnerType";
        this.OwnerType.TabIndex = 77;
        this.OwnerType.Visible = false;

        this.cityOfBirth = new TTVisual.TTObjectListBox();
        this.cityOfBirth.ReadOnly = true;
        this.cityOfBirth.ListDefName = "CityListDefinition";
        this.cityOfBirth.Name = "cityOfBirth";
        this.cityOfBirth.TabIndex = 5;

        this.encboSex = new TTVisual.TTEnumComboBox();
        this.encboSex.DataTypeName = "SexEnum";
        this.encboSex.BackColor = "#F0F0F0";
        this.encboSex.Enabled = false;
        this.encboSex.Name = "encboSex";
        this.encboSex.TabIndex = 7;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ReadOnly = true;
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 3;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = i18n("M16902", "İşlem Zamanı");
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 22;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel13.BackColor = "#DCDCDC";
        this.ttlabel13.ForeColor = "#000000";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 28;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = i18n("M17026", "Kabul Sebebi");
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 4;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.ttlabel16 = new TTVisual.TTLabel();
        this.ttlabel16.Text = i18n("M15222", "Hasta Grubu");
        this.ttlabel16.BackColor = "#DCDCDC";
        this.ttlabel16.ForeColor = "#000000";
        this.ttlabel16.Name = "ttlabel16";
        this.ttlabel16.TabIndex = 2;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.RowHeadersVisible = false;
        this.GridEpisodeDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 8;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = i18n("M20117", "Özgeçmiş");
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 60;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisListDefinition";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = i18n("M22736", "Tanı");
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 400;

        this.EpisodeDiagnosisType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnosisType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnosisType.DataMember = "DiagnosisType";
        this.EpisodeDiagnosisType.DisplayIndex = 2;
        this.EpisodeDiagnosisType.HeaderText = i18n("M22781", "Tanı Tipi");
        this.EpisodeDiagnosisType.Name = "EpisodeDiagnosisType";
        this.EpisodeDiagnosisType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 60;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = i18n("M14808", "Giriş Yapılan İşlem");
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.taniOzelDurum = new TTVisual.TTListBoxColumn();
        this.taniOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.taniOzelDurum.DataMember = "OzelDurum";
        this.taniOzelDurum.DisplayIndex = 7;
        this.taniOzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.taniOzelDurum.Name = "taniOzelDurum";
        this.taniOzelDurum.Width = 100;

        this.tanCokluOzelDurum = new TTVisual.TTButtonColumn();
        this.tanCokluOzelDurum.DisplayIndex = 8;
        this.tanCokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.tanCokluOzelDurum.Name = "tanCokluOzelDurum";
        this.tanCokluOzelDurum.Width = 100;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 14;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M23303", "Tetkik Bilgileri");
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.TTListBoxDrAnesteziTescilNo = new TTVisual.TTObjectListBox();
        this.TTListBoxDrAnesteziTescilNo.ListDefName = "ResUserListDefinition";
        this.TTListBoxDrAnesteziTescilNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxDrAnesteziTescilNo.Name = "TTListBoxDrAnesteziTescilNo";
        this.TTListBoxDrAnesteziTescilNo.TabIndex = 4;

        this.TTListBox = new TTVisual.TTObjectListBox();
        this.TTListBox.ListDefName = "SagSolListDefinition";
        this.TTListBox.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBox.Name = "TTListBox";
        this.TTListBox.TabIndex = 6;

        this.TTListBoxKesi = new TTVisual.TTObjectListBox();
        this.TTListBoxKesi.ListDefName = "AyniFarkliKesiListDefinition";
        this.TTListBoxKesi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxKesi.Name = "TTListBoxKesi";
        this.TTListBoxKesi.TabIndex = 5;

        this.cmdSaveAndPrint = new TTVisual.TTButton();
        this.cmdSaveAndPrint.Text = i18n("M17387", "Kaydet ve Önizle");
        this.cmdSaveAndPrint.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.cmdSaveAndPrint.Name = "cmdSaveAndPrint";
        this.cmdSaveAndPrint.TabIndex = 9;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M12031", " Bölüm");
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 0;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.BackColor = "#F0F0F0";
        this.Description.ReadOnly = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 7;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M12222", "Cihaz");
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 2;

        this.rtfReport = new TTVisual.TTRichTextBoxControl();
        this.rtfReport.TemplateGroupName = "RADIOLOGY";
        this.rtfReport.BackColor = "#FFFFFF";
        this.rtfReport.Name = "rtfReport";
        this.rtfReport.TabIndex = 14;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M19702", "Onaylanma Tarihi");
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 72;

        this.TestDate = new TTVisual.TTDateTimePicker();
        this.TestDate.Required = true;
        this.TestDate.BackColor = "#F0F0F0";
        this.TestDate.CustomFormat = "";
        this.TestDate.Format = DateTimePickerFormat.Long;
        this.TestDate.Enabled = true;
        this.TestDate.Name = "TestDate";
        this.TestDate.TabIndex = 2;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M23112", "Teknisyen Notu");
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 66;

        this.Equipment = new TTVisual.TTObjectListBox();
        this.Equipment.ReadOnly = true;
        this.Equipment.ListDefName = "ResRadiologyEquipmentListDefinition";
        this.Equipment.Name = "Equipment";
        this.Equipment.TabIndex = 1;

        this.ProcedureObject = new TTVisual.TTObjectListBox();
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.ListDefName = "RadiologyTestListDefinition";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.TabIndex = 0;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M10469", "Açıklama");
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 65;

        this.Deparment = new TTVisual.TTObjectListBox();
        this.Deparment.ReadOnly = true;
        this.Deparment.ListDefName = "ResRadiologyDepartmentListDefinition";
        this.Deparment.Name = "Deparment";
        this.Deparment.TabIndex = 1;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "TETKİK";
        this.ttlabel1.Font = "Name=Tahoma, Size=9,75, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#FF0000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 70;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "Rapor";
        this.ttlabel11.ForeColor = "#000000";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 12;

        this.TestTechnicianNote = new TTVisual.TTTextBox();
        this.TestTechnicianNote.Multiline = true;
        this.TestTechnicianNote.BackColor = "#F0F0F0";
        this.TestTechnicianNote.ReadOnly = true;
        this.TestTechnicianNote.Name = "TestTechnicianNote";
        this.TestTechnicianNote.TabIndex = 8;

        this.ttlabelKesi = new TTVisual.TTLabel();
        this.ttlabelKesi.Text = "Aynı Kesi/ Farklı Seans";
        this.ttlabelKesi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelKesi.Name = "ttlabelKesi";
        this.ttlabelKesi.TabIndex = 75;

        this.tttextboxBirim = new TTVisual.TTTextBox();
        this.tttextboxBirim.Name = "tttextboxBirim";
        this.tttextboxBirim.TabIndex = 3;

        this.ttlabelBirim = new TTVisual.TTLabel();
        this.ttlabelBirim.Text = "Birim";
        this.ttlabelBirim.Name = "ttlabelBirim";
        this.ttlabelBirim.TabIndex = 81;

        this.ttlabelSagSol = new TTVisual.TTLabel();
        this.ttlabelSagSol.Text = i18n("M21122", "Sağ / Sol");
        this.ttlabelSagSol.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelSagSol.Name = "ttlabelSagSol";
        this.ttlabelSagSol.TabIndex = 77;

        this.ttlabelDrAnesteziTescilNo = new TTVisual.TTLabel();
        this.ttlabelDrAnesteziTescilNo.Text = i18n("M10968", "Anestezi Dr. Tescil No.");
        this.ttlabelDrAnesteziTescilNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelDrAnesteziTescilNo.Name = "ttlabelDrAnesteziTescilNo";
        this.ttlabelDrAnesteziTescilNo.TabIndex = 81;

        this.DisTaahhutNo = new TTVisual.TTTextBox();
        this.DisTaahhutNo.Name = "DisTaahhutNo";
        this.DisTaahhutNo.TabIndex = 10;

        this.labelDisTaahhutNo = new TTVisual.TTLabel();
        this.labelDisTaahhutNo.Text = i18n("M12945", "Diş Taahhüt Numarası");
        this.labelDisTaahhutNo.Name = "labelDisTaahhutNo";
        this.labelDisTaahhutNo.TabIndex = 38;

        this.ttbuttonToothSchema = new TTVisual.TTButton();
        this.ttbuttonToothSchema.Text = i18n("M12940", "Diş Şeması");
        this.ttbuttonToothSchema.Name = "ttbuttonToothSchema";
        this.ttbuttonToothSchema.TabIndex = 11;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 0;
        this.tttabpage2.Text = i18n("M18553", "Malzeme Bilgileri");
        this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage2.Name = "tttabpage2";

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M21309", "Sarf");
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 74;

        this.Materials = new TTVisual.TTGrid();
        this.Materials.Name = "Materials";
        this.Materials.TabIndex = 75;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M21314", "Sarf Edilen Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 500;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 1;
        this.Barcode.HeaderText = "Barkodu";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 3;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 75;

        this.kodsuzMalzemeFiyati = new TTVisual.TTTextBoxColumn();
        this.kodsuzMalzemeFiyati.DataMember = "KodsuzMalzemeFiyati";
        this.kodsuzMalzemeFiyati.DisplayIndex = 4;
        this.kodsuzMalzemeFiyati.HeaderText = i18n("M17688", "Kodsuz Malzeme Fiyatı");
        this.kodsuzMalzemeFiyati.Name = "kodsuzMalzemeFiyati";
        this.kodsuzMalzemeFiyati.Visible = false;
        this.kodsuzMalzemeFiyati.Width = 100;

        this.malzemeTuru = new TTVisual.TTListBoxColumn();
        this.malzemeTuru.ListDefName = "MalzemeTuruListDefinition";
        this.malzemeTuru.DataMember = "MalzemeTuru";
        this.malzemeTuru.DisplayIndex = 5;
        this.malzemeTuru.HeaderText = i18n("M18650", "Malzemenin Türü");
        this.malzemeTuru.Name = "malzemeTuru";
        this.malzemeTuru.Visible = false;
        this.malzemeTuru.Width = 100;

        this.kdv = new TTVisual.TTTextBoxColumn();
        this.kdv.DataMember = "Kdv";
        this.kdv.DisplayIndex = 6;
        this.kdv.HeaderText = "KDV";
        this.kdv.Name = "kdv";
        this.kdv.Visible = false;
        this.kdv.Width = 100;

        this.malzemeBrans = new TTVisual.TTTextBoxColumn();
        this.malzemeBrans.DataMember = "MalzemeBrans";
        this.malzemeBrans.DisplayIndex = 7;
        this.malzemeBrans.HeaderText = i18n("M18636", "Malzemenin Branşı");
        this.malzemeBrans.Name = "malzemeBrans";
        this.malzemeBrans.Visible = false;
        this.malzemeBrans.Width = 100;

        this.malzemeSatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.malzemeSatinAlisTarihi.DataMember = "ActionDate";
        this.malzemeSatinAlisTarihi.DisplayIndex = 8;
        this.malzemeSatinAlisTarihi.HeaderText = i18n("M18604", "Malzeme Satın Alış Tarihi");
        this.malzemeSatinAlisTarihi.Name = "malzemeSatinAlisTarihi";
        this.malzemeSatinAlisTarihi.Visible = false;
        this.malzemeSatinAlisTarihi.Width = 100;

        this.malzemeOzelDurum = new TTVisual.TTListBoxColumn();
        this.malzemeOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.malzemeOzelDurum.DataMember = "OzelDurum";
        this.malzemeOzelDurum.DisplayIndex = 9;
        this.malzemeOzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.malzemeOzelDurum.Name = "malzemeOzelDurum";
        this.malzemeOzelDurum.Visible = false;
        this.malzemeOzelDurum.Width = 100;

        this.malzemeCokluOzelDurum = new TTVisual.TTButtonColumn();
        this.malzemeCokluOzelDurum.DisplayIndex = 10;
        this.malzemeCokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.malzemeCokluOzelDurum.Name = "malzemeCokluOzelDurum";
        this.malzemeCokluOzelDurum.Visible = false;
        this.malzemeCokluOzelDurum.Width = 100;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 2;
        this.tttabpage3.TabIndex = 1;
        this.tttabpage3.Text = "Doğrudan Teminle Alınan Malzemeler";
        this.tttabpage3.Name = "tttabpage3";

        this.SurgeryDirectPurchaseGrids = new TTVisual.TTGrid();
        this.SurgeryDirectPurchaseGrids.AllowUserToDeleteRows = false;
        this.SurgeryDirectPurchaseGrids.AllowUserToAddRows = false;
        this.SurgeryDirectPurchaseGrids.ReadOnly = true;
        this.SurgeryDirectPurchaseGrids.Name = "SurgeryDirectPurchaseGrids";
        this.SurgeryDirectPurchaseGrids.TabIndex = 0;

        this.DPADetailFirmPriceOffer = new TTVisual.TTListBoxColumn();
        this.DPADetailFirmPriceOffer.ListDefName = "DirectPurchaseActionDetailList";
        this.DPADetailFirmPriceOffer.DataMember = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOffer.DisplayIndex = 0;
        this.DPADetailFirmPriceOffer.HeaderText = i18n("M10240", "22F Malzeme");
        this.DPADetailFirmPriceOffer.Name = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOffer.Width = 500;

        this.txtBarcode = new TTVisual.TTTextBoxColumn();
        this.txtBarcode.DataMember = "ProductNumber";
        this.txtBarcode.DisplayIndex = 1;
        this.txtBarcode.HeaderText = "Barkod";
        this.txtBarcode.Name = "txtBarcode";
        this.txtBarcode.ReadOnly = true;
        this.txtBarcode.Width = 300;

        this.txtKesinlesenMiktar = new TTVisual.TTTextBoxColumn();
        this.txtKesinlesenMiktar.DataMember = "CertainAmount";
        this.txtKesinlesenMiktar.DisplayIndex = 2;
        this.txtKesinlesenMiktar.HeaderText = i18n("M17504", "Kesinleşen Miktar");
        this.txtKesinlesenMiktar.Name = "txtKesinlesenMiktar";
        this.txtKesinlesenMiktar.ReadOnly = true;
        this.txtKesinlesenMiktar.Width = "400";

        this.ReportedBy = new TTVisual.TTObjectListBox();
        this.ReportedBy.Required = true;
        this.ReportedBy.ListDefName = "ResUserListByReportNQL";
        this.ReportedBy.Name = "ReportedBy";
        this.ReportedBy.TabIndex = 10;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M20880", "Rapor Yazan");
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 28;

        this.ApprovedBy = new TTVisual.TTObjectListBox();
        this.ApprovedBy.Required = true;
        this.ApprovedBy.ListDefName = "SpecialistDoctorListDefinition";
        this.ApprovedBy.Name = "ApprovedBy";
        this.ApprovedBy.TabIndex = 11;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M22158", "Sorumlu Tabip");
        this.ttlabel12.BackColor = "#DCDCDC";
        this.ttlabel12.ForeColor = "#000000";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 28;

        this.PatientBirthDate = new TTVisual.TTDateTimePicker();
        this.PatientBirthDate.BackColor = "#F0F0F0";
        this.PatientBirthDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.PatientBirthDate.Format = DateTimePickerFormat.Custom;
        this.PatientBirthDate.Enabled = false;
        this.PatientBirthDate.Name = "PatientBirthDate";
        this.PatientBirthDate.TabIndex = 6;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = i18n("M15442", "Hastanın Doğum Tarihi");
        this.ttlabel14.BackColor = "#DCDCDC";
        this.ttlabel14.ForeColor = "#000000";
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 76;

        this.ttlabel17 = new TTVisual.TTLabel();
        this.ttlabel17.Text = i18n("M15443", "Hastanın Doğum Yeri");
        this.ttlabel17.BackColor = "#DCDCDC";
        this.ttlabel17.ForeColor = "#000000";
        this.ttlabel17.Name = "ttlabel17";
        this.ttlabel17.TabIndex = 75;

        this.ttlabel18 = new TTVisual.TTLabel();
        this.ttlabel18.Text = i18n("M15436", "Hastanın Cinsiyeti");
        this.ttlabel18.BackColor = "#DCDCDC";
        this.ttlabel18.ForeColor = "#000000";
        this.ttlabel18.Name = "ttlabel18";
        this.ttlabel18.TabIndex = 75;

        this.ttlabel19 = new TTVisual.TTLabel();
        this.ttlabel19.Text = i18n("M20545", "Prokotol No");
        this.ttlabel19.BackColor = "#DCDCDC";
        this.ttlabel19.ForeColor = "#000000";
        this.ttlabel19.Name = "ttlabel19";
        this.ttlabel19.TabIndex = 75;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 9;

        this.tabAnamnez = new TTVisual.TTTabPage();
        this.tabAnamnez.DisplayIndex = 0;
        this.tabAnamnez.TabIndex = 0;
        this.tabAnamnez.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.tabAnamnez.Name = "tabAnamnez";

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#F0F0F0";
        this.PREDIAGNOSIS.ReadOnly = true;
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 0;

        this.tabDescription = new TTVisual.TTTabPage();
        this.tabDescription.DisplayIndex = 1;
        this.tabDescription.TabIndex = 1;
        this.tabDescription.Text = i18n("M10483", "Açıklamalar");
        this.tabDescription.Name = "tabDescription";

        this.CommonDescription = new TTVisual.TTTextBox();
        this.CommonDescription.Multiline = true;
        this.CommonDescription.BackColor = "#F0F0F0";
        this.CommonDescription.ReadOnly = true;
        this.CommonDescription.Name = "CommonDescription";
        this.CommonDescription.TabIndex = 7;

        this.tabAdditionalRequest = new TTVisual.TTTabPage();
        this.tabAdditionalRequest.DisplayIndex = 2;
        this.tabAdditionalRequest.TabIndex = 2;
        this.tabAdditionalRequest.Text = i18n("M13522", "Ek İstek");
        this.tabAdditionalRequest.Name = "tabAdditionalRequest";

        this.tttextbox4 = new TTVisual.TTTextBox();
        this.tttextbox4.Multiline = true;
        this.tttextbox4.BackColor = "#F0F0F0";
        this.tttextbox4.ReadOnly = true;
        this.tttextbox4.Name = "tttextbox4";
        this.tttextbox4.TabIndex = 7;


        this.AccessionNo = new TTVisual.TTTextBox();
        this.AccessionNo.BackColor = "#F0F0F0";
        this.AccessionNo.ReadOnly = true;
        this.AccessionNo.Name = "AccessionNo";
        this.AccessionNo.TabIndex = 3;

        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.taniOzelDurum, this.tanCokluOzelDurum];
        this.MaterialsColumns = [this.Material, this.Barcode, this.DistributionType, this.Amount, this.kodsuzMalzemeFiyati, this.malzemeTuru, this.kdv, this.malzemeBrans, this.malzemeSatinAlisTarihi, this.malzemeOzelDurum, this.malzemeCokluOzelDurum];
        this.SurgeryDirectPurchaseGridsColumns = [this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3];
        this.tttabpage1.Controls = [this.TTListBoxDrAnesteziTescilNo, this.TTListBox, this.TTListBoxKesi, this.cmdSaveAndPrint, this.ttlabel4, this.Description, this.ttlabel5, this.rtfReport, this.ttlabel2, this.TestDate, this.ttlabel10, this.Equipment, this.ProcedureObject, this.ttlabel9, this.Deparment, this.ttlabel1, this.ttlabel11, this.TestTechnicianNote, this.ttlabelKesi, this.tttextboxBirim, this.ttlabelBirim, this.ttlabelSagSol, this.ttlabelDrAnesteziTescilNo, this.DisTaahhutNo, this.labelDisTaahhutNo, this.ttbuttonToothSchema];
        this.tttabpage2.Controls = [this.ttlabel3, this.Materials];
        this.tttabpage3.Controls = [this.SurgeryDirectPurchaseGrids];
        this.tttabcontrol2.Controls = [this.tabAnamnez, this.tabDescription, this.tabAdditionalRequest];
        this.tabAnamnez.Controls = [this.PREDIAGNOSIS];
        this.tabDescription.Controls = [this.CommonDescription];
        this.tabAdditionalRequest.Controls = [this.tttextbox4];
        this.Controls = [this.ttMasterResourceUserCheck, this.cmdReport, this.tttextbox1, this.OwnerType, this.cityOfBirth, this.encboSex, this.ttobjectlistbox1, this.ActionDate, this.labelProcessTime, this.ttlabel13, this.ttlabel15, this.PATIENTGROUPENUM, this.ttlabel16, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.taniOzelDurum, this.tanCokluOzelDurum, this.ReasonForAdmission, this.tttabcontrol1, this.tttabpage1, this.TTListBoxDrAnesteziTescilNo, this.TTListBox, this.TTListBoxKesi, this.cmdSaveAndPrint, this.ttlabel4, this.Description, this.ttlabel5, this.rtfReport, this.ttlabel2, this.TestDate, this.ttlabel10, this.Equipment, this.ProcedureObject, this.ttlabel9, this.Deparment, this.ttlabel1, this.ttlabel11, this.TestTechnicianNote, this.ttlabelKesi, this.tttextboxBirim, this.ttlabelBirim, this.ttlabelSagSol, this.ttlabelDrAnesteziTescilNo, this.DisTaahhutNo, this.labelDisTaahhutNo, this.ttbuttonToothSchema, this.tttabpage2, this.ttlabel3, this.Materials, this.Material, this.Barcode, this.DistributionType, this.Amount, this.kodsuzMalzemeFiyati, this.malzemeTuru, this.kdv, this.malzemeBrans, this.malzemeSatinAlisTarihi, this.malzemeOzelDurum, this.malzemeCokluOzelDurum, this.tttabpage3, this.SurgeryDirectPurchaseGrids, this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar, this.ReportedBy, this.ttlabel8, this.ApprovedBy, this.ttlabel12, this.PatientBirthDate, this.ttlabel14, this.ttlabel17, this.ttlabel18, this.ttlabel19, this.tttabcontrol2, this.tabAnamnez, this.PREDIAGNOSIS, this.tabDescription, this.CommonDescription, this.tabAdditionalRequest, this.tttextbox4, this.AccessionNo];

    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        let pathologyRequest = new DynamicSidebarMenuItem();
        pathologyRequest.key = 'pathologyRequest';
        pathologyRequest.icon = 'ai ai-chemical';
        pathologyRequest.label = i18n("M20230", "Patoloji İstek");
        pathologyRequest.componentInstance = this.helpMenuService;
        pathologyRequest.clickFunction = this.helpMenuService.onPathologyRequest;
        pathologyRequest.parameterFunctionInstance = this;
        pathologyRequest.getParamsFunction = this.getParamsFunctionForRadiology;
        pathologyRequest.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', pathologyRequest);
    }
    private RemoveMenuFromHelpMenu(): void {
  
        this.sideBarMenuService.removeMenu('pathologyRequest');
    }
}
