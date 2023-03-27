//$FE8CABA4
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyTestRequestAcceptionFormViewModel } from "./RadiologyTestRequestAcceptionFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Appointment, RadiologyContrastTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyGridDepartmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyGridDepartmentDefinitionService } from "ObjectClassService/RadiologyGridDepartmentDefinitionService";
import { RadiologyGridEquipmentDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyGridEquipmentDefinitionService } from "ObjectClassService/RadiologyGridEquipmentDefinitionService";
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTestBaseForm } from "Modules/Tibbi_Surec/Radyoloji_Modulu/RadiologyTestBaseForm";
import { RadiologyTestDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { RadiologyBarcodeInfo } from 'app/Barcode/Models/RadiologyBarcodeInfo';

import { CommonService } from 'ObjectClassService/CommonService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from '../../../wwwroot/app/SidebarMenu/Models/DynamicSidebarMenuItem';




@Component({
    selector: 'RadiologyTestRequestAcceptionForm',
    templateUrl: './RadiologyTestRequestAcceptionForm.html',
    providers: [MessageService,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }
    ]
})
export class RadiologyTestRequestAcceptionForm extends RadiologyTestBaseForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    cmbDentalPosition: TTVisual.ITTEnumComboBox;
    cmbToothNumber: TTVisual.ITTEnumComboBox;
    cmdPrintRequestNo: TTVisual.ITTButton;
    CommonDescription: TTVisual.ITTTextBox;
    ContrastType: TTVisual.ITTEnumComboBox;
    Deparment: TTVisual.ITTObjectListBox;
    Description: TTVisual.ITTTextBox;
    DisTaahhutNo: TTVisual.ITTTextBox;
    DistributionType: TTVisual.ITTTextBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    Equipment: TTVisual.ITTObjectListBox;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GunuBirlikTakip: TTVisual.ITTCheckBox;
    labelContrastType: TTVisual.ITTLabel;
    Emergency: TTVisual.ITTCheckBox;
    labelDisTaahhutNo: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    labeltakipTipi: TTVisual.ITTLabel;
    labeltedaviTipi: TTVisual.ITTLabel;
    lblAge: TTVisual.ITTLabel;
    lblRequestNo: TTVisual.ITTLabel;
    lblAccessionNo: TTVisual.ITTLabel;
    lblToothNumber: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    Materials: TTVisual.ITTGrid;
    MedulaTakipBilgileriTabPage: TTVisual.ITTTabPage;
    OwnerType: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    ProcedureObject: TTVisual.ITTObjectListBox;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    RequestNo: TTVisual.ITTTextBox;
    AccessionNo: TTVisual.ITTTextBox;
    tabMaterial: TTVisual.ITTTabPage;
    TabSubaction: TTVisual.ITTTabControl;
    takipTipi: TTVisual.ITTListDefComboBox;
    tedaviTipi: TTVisual.ITTListDefComboBox;
    TestTechnicianNote: TTVisual.ITTTextBox;
    ttBarcodePreviewCheck: TTVisual.ITTCheckBox;
    ttbuttonToothSchema: TTVisual.ITTButton;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttPrintRequestBarcode: TTVisual.ITTButton;
    tttabpage1: TTVisual.ITTTabPage;
    tttextbox2: TTVisual.ITTTextBox;
    public GridEpisodeDiagnosisColumns = [];
    public MaterialsColumns = [];
    public ContrastType_Text ="";
    public radiologyTestRequestAcceptionFormViewModel: RadiologyTestRequestAcceptionFormViewModel = new RadiologyTestRequestAcceptionFormViewModel();
    public get _RadiologyTest(): RadiologyTest {
        return this._TTObject as RadiologyTest;
    }
    private RadiologyTestRequestAcceptionForm_DocumentUrl: string = '/api/RadiologyTestService/RadiologyTestRequestAcceptionForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private barcodePrintService: IBarcodePrintService,
        private objectContextService: ObjectContextService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RadiologyTestRequestAcceptionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    //otomatik barkod basma kapatıldı.
    /* protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo) {
         await super.setState(transDef, saveInfo);
         if (transDef !== null)
         {
             if (transDef.FromStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.RequestAcception.valueOf() && transDef.ToStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.Procedure.valueOf())
             {
                 await this.cmdPrintRequestNo_Click();
 
             }
         }
     }
     */


    // ***** Method declarations start *****

    public async cmdPrintRequestNo_Click(): Promise<void> {

        let apiUrl: string = 'api/RadiologyTestService/PrepareRadiologyBarcode?RadiologyTestObjectID=' + this._RadiologyTest.ObjectID.toString();
        let result: Array<RadiologyBarcodeInfo> = await this.httpService.get<Array<RadiologyBarcodeInfo>>(apiUrl);

        if (this.radiologyTestRequestAcceptionFormViewModel.NewRadiologyBarcode) {
            for (var i = 0; i < result.length; i++) {
                await this.barcodePrintService.printAllBarcode(result[i], "generateRadiologyBarcodeNew", "printRadiologyBarcodeNew");
            }
        } else {
            for (var i = 0; i < result.length; i++) {

                await this.barcodePrintService.printAllBarcode(result[i], "generateRadiologyBarcode", "printRadiologyBarcode");

            }
        }
    }


    private async GunuBirlikTakip_CheckedChanged(): Promise<void> {
        /*
        if (this.GunuBirlikTakip.Value === true) {
            //  this._Manipulation.CreateSubEpisode = true;
            this.TabSubaction.ShowTabPage(this.MedulaTakipBilgileriTabPage);
            this.tedaviTipi.Required = true;
            this.takipTipi.Required = true;
            //  this.bransKodu.Required = true;
            if (this._RadiologyTest.MedulaProvision === null) {
                let _medulaProvision: MedulaProvision = new MedulaProvision(this._RadiologyTest.ObjectContext);
                (await SubActionProcedureService.SetMedulaProvisionInitalProperties(_medulaProvision, this._RadiologyTest));
                this._RadiologyTest.MedulaProvision = _medulaProvision;
            }
        }
        else {
            // this._Manipulation.CreateSubEpisode = false;
            this.TabSubaction.HideTabPage(this.MedulaTakipBilgileriTabPage);
            this.tedaviTipi.Required = false;
            this.takipTipi.Required = false;
        }
        */
    }
    private async ttbuttonToothSchema_Click(): Promise<void> {
        //TODO:ShowEdit!
        //RadiologyTestDentalToothSchema radiologyTestDentalForm = new RadiologyTestDentalToothSchema();
        //if (radiologyTestDentalForm != null)
        //    radiologyTestDentalForm.ShowEdit(this.FindForm(),_RadiologyTest,true);

    }
    private async ttPrintRequestBarcode_Click(): Promise<void> {
        /*
        let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
        let cache: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
        cache.push("VALUE", this._RadiologyTest.ObjectID);
        parameters.push("TTOBJECTID", cache);
        if (this.ttBarcodePreviewCheck.Value === true) {
            TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_RadiologyRequestBarcode, true, 1, parameters);
        }
        else {
            TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_RadiologyRequestBarcode, false, 1, parameters);
        }
        */
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {

        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("RADIOLOGYTEST", this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.ObjectID, null);
        }

        super.AfterContextSavedScript(transDef);
        await this.load(RadiologyTestRequestAcceptionFormViewModel);

    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        if (transDef !== null) {
            if (transDef.FromStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.RequestAcception.valueOf() && transDef.ToStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.Cancelled.valueOf()) {

                let getDescription: string = await TTVisual.InputForm.GetText(i18n("M16531", "İptal açıklaması giriniz."), "", false, true);
                if (String.isNullOrEmpty(getDescription) === false)
                    this._RadiologyTest.ReasonOfCancel = getDescription;
                else
                    throw new TTException(i18n("M16532", "İptal açıklaması girmelisiniz!"));
            }

            if (transDef.FromStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.RequestAcception.valueOf() && transDef.ToStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.Appointment.valueOf()) {
                if (!this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Department)
                    throw new TTException("Bölüm boş geçilemez.");
                if (!this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Equipment)
                    throw new TTException("Cihaz boş geçilemez.");
            }
        }

    }
    protected async ClientSidePreScript(): Promise<void> {

        super.ClientSidePreScript();
        let thisAction: EpisodeAction = this._RadiologyTest.EpisodeAction;

        let radTestDef: RadiologyTestDefinition = await this.objectContextService.getObject<RadiologyTestDefinition>(this._RadiologyTest.ProcedureObject.ObjectID, RadiologyTestDefinition.ObjectDefID);
        if (radTestDef.IsRISEntegratedTest == true)
            this.DropStateButton(RadiologyTest.RadiologyTestStates.ResultEntry);
        else if (radTestDef.IsRISEntegratedTest == false)
            this.DropStateButton(RadiologyTest.RadiologyTestStates.Procedure);

    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        await super.PostScript(transDef);
        if (transDef !== null) {

            if (transDef.ToStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.Procedure.valueOf()) {
                if (String.isNullOrEmpty(this._ViewModel.AlertMessage) === false)
                    TTVisual.InfoBox.Alert(i18n("M23738", "Uyarı!"), "İstenilen tetkiğin (" + this._RadiologyTest.ProcedureObject.Code + '-' + this._RadiologyTest.ProcedureObject.Name + i18n("M10019", ")  uyarı mesajı bulunmaktadır. <br /> Uyarı : ") + this._ViewModel.AlertMessage, null, 250, 500);
            }
        }
    }
    protected async PreScript() {

        //this.DropStateButton(RadiologyTest.RadiologyTestStates.Completed);

        //TODO: objectdefs okunamıyor server a tasınacak?
        //this.SetTreatmentMaterialListFilter(<TTObjectDef>TTObjectDefManager.Instance.ObjectDefs["RadiologyMaterial"], <TTVisual.ITTGridColumn>this.Materials.Columns["Material"]);

        let thisAction: EpisodeAction = this._RadiologyTest.EpisodeAction;
        let radiology: Radiology = this._RadiologyTest.Radiology;
        let requestUser: ResUser = null;
        let radTestDefGuid: Guid = (<RadiologyTestDefinition>this._RadiologyTest.ProcedureObject).ObjectID;

        //TODO: objectState.User
        //if (radiology.ProcedureDoctor === null) {
        //    if (radiology.MasterAction instanceof HealthCommittee) {
        //        for (let objectState of radiology.GetStateHistory()) {
        //            if (objectState.StateDefID === Radiology.RadiologyStates.Request) {
        //                requestUser = <ResUser>objectState.User.UserObject;
        //                radiology.ProcedureDoctor = requestUser;
        //                radiology.RequestDoctor = requestUser;
        //                for (let radTest of radiology.RadiologyTests) {
        //                    if (radTest.ProcedureDoctor === null)
        //                        radTest.ProcedureDoctor = requestUser;
        //                }
        //            }
        //        }
        //    }
        //}

        if (this._RadiologyTest.Department === null) {
            let radTestDepartmentList: Array<any> = (await RadiologyGridDepartmentDefinitionService.GetRadGridDepartments(" WHERE RADIOLOGYTEST = '" + radTestDefGuid.toString() + "'"));
            if (radTestDepartmentList.length > 0)
                this._RadiologyTest.Department = (<RadiologyGridDepartmentDefinition>radTestDepartmentList[0]).Department;
        }
        if (this._RadiologyTest.Equipment === null) {
            let radTestEquipmentList: Array<any> = (await RadiologyGridEquipmentDefinitionService.GetRadGridEquipments(" WHERE RADIOLOGYTEST = '" + radTestDefGuid.toString() + "'"));
            if (radTestEquipmentList.length > 0)
                this._RadiologyTest.Equipment = (<RadiologyGridEquipmentDefinition>radTestEquipmentList[0]).Equipment;
        }

        //TODO:AppointmentWorks
        //let myNotApprovedAppointments: Promise<Array<Appointment>>;
        //myNotApprovedAppointments = this.MyNotApprovedAppointments(this._RadiologyTest.ObjectID);
        //this.MyNotApprovedAppointments(this._RadiologyTest.ObjectID).then(result => {
        //    let myNotApprovedAppointments: Array<Appointment>;
        //    myNotApprovedAppointments = result;
        //    if (myNotApprovedAppointments.length > 0) {
        //        if (myNotApprovedAppointments[0].Resource instanceof ResRadiologyEquipment) {
        //            this._RadiologyTest.Equipment = <ResRadiologyEquipment>myNotApprovedAppointments[0].Resource;
        //            this.DropStateButton(RadiologyTest.RadiologyTestStates.Appointment);
        //        }
        //    }
        //}
        //);

        super.PreScript();

    }
    public async MyNotApprovedAppointments(objectID: Guid): Promise<Array<Appointment>> {

        let objContext: TTObjectContext = new TTObjectContext(true);
        let retList: Array<Appointment> = <Array<Appointment>>objContext.QueryObjects("APPOINTMENT", "SUBACTIONPROCEDURE = " + objectID.toString() + " AND CURRENTSTATEDEFID = " + Appointment.AppointmentStates.NotApproved.toString(), "APPDATE");

        //LocalQuery client-server yapida anlamlı olmadıgı ıcın asagıdakı blok kapatıldı. queryObjects ıle Server dan sorgulanıyor ve retList donduruluyor.
        //for (let app of objContext.LocalQuery("APPOINTMENT", "SUBACTIONPROCEDURE = " + objectID.toString() + " AND CURRENTSTATEDEFID = " + Appointment.AppointmentStates.NotApproved.toString() , "APPDATE")) {
        //    if (retList.Contains(app) === false)
        //        retList.push(app);
        //}

        return retList;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RadiologyTest();
        this.radiologyTestRequestAcceptionFormViewModel = new RadiologyTestRequestAcceptionFormViewModel();
        this._ViewModel = this.radiologyTestRequestAcceptionFormViewModel;
        this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest = this._TTObject as RadiologyTest;
        this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Equipment = new ResRadiologyEquipment();
        this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.ProcedureObject = new ProcedureDefinition();
        this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Department = new ResRadiologyDepartment();
        this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.RadiologyTestTreatmentMaterial = new Array<RadiologyMaterial>();
        //this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.MedulaProvision = new MedulaProvision();
        //this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.MedulaProvision.TakipTipi = new TakipTipi();
        //this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.MedulaProvision.TedaviTipi = new TedaviTipi();
        this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Episode = new Episode();
        this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Episode.Patient = new Patient();
        this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Radiology = new Radiology();
        this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Radiology.RequestDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyTestRequestAcceptionFormViewModel = this._ViewModel as RadiologyTestRequestAcceptionFormViewModel;
        that._TTObject = this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest;
        if (this.radiologyTestRequestAcceptionFormViewModel == null)
            this.radiologyTestRequestAcceptionFormViewModel = new RadiologyTestRequestAcceptionFormViewModel();
        if (this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest == null)
            this.radiologyTestRequestAcceptionFormViewModel._RadiologyTest = new RadiologyTest();
        let equipmentObjectID = that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest["Equipment"];
        if (equipmentObjectID != null && (typeof equipmentObjectID === 'string')) {
            let equipment = that.radiologyTestRequestAcceptionFormViewModel.ResRadiologyEquipments.find(o => o.ObjectID.toString() === equipmentObjectID.toString());
            if (equipment) {
                that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Equipment = equipment;
            }
        }
        let procedureObjectObjectID = that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
            let procedureObject = that.radiologyTestRequestAcceptionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
            if (procedureObject) {
                that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.ProcedureObject = procedureObject;
            }
        }
        let departmentObjectID = that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === 'string')) {
            let department = that.radiologyTestRequestAcceptionFormViewModel.ResRadiologyDepartments.find(o => o.ObjectID.toString() === departmentObjectID.toString());
            if (department) {
                that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Department = department;
            }
        }
        that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.RadiologyTestTreatmentMaterial = that.radiologyTestRequestAcceptionFormViewModel.MaterialsGridList;
        for (let detailItem of that.radiologyTestRequestAcceptionFormViewModel.MaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.radiologyTestRequestAcceptionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.radiologyTestRequestAcceptionFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.radiologyTestRequestAcceptionFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        let medulaProvisionObjectID = that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest["MedulaProvision"];
        if (medulaProvisionObjectID != null && (typeof medulaProvisionObjectID === 'string')) {
            let medulaProvision = that.radiologyTestRequestAcceptionFormViewModel.MedulaProvisions.find(o => o.ObjectID.toString() === medulaProvisionObjectID.toString());
            //that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.MedulaProvision = medulaProvision;
            if (medulaProvision != null) {
                let takipTipiObjectID = medulaProvision["TakipTipi"];
                if (takipTipiObjectID != null && (typeof takipTipiObjectID === 'string')) {
                    let takipTipi = that.radiologyTestRequestAcceptionFormViewModel.TakipTipis.find(o => o.ObjectID.toString() === takipTipiObjectID.toString());
                    if (takipTipi) {
                        medulaProvision.TakipTipi = takipTipi;
                    }
                }
            }
            if (medulaProvision != null) {
                let tedaviTipiObjectID = medulaProvision["TedaviTipi"];
                if (tedaviTipiObjectID != null && (typeof tedaviTipiObjectID === 'string')) {
                    let tedaviTipi = that.radiologyTestRequestAcceptionFormViewModel.TedaviTipis.find(o => o.ObjectID.toString() === tedaviTipiObjectID.toString());
                    if (tedaviTipi) {
                        medulaProvision.TedaviTipi = tedaviTipi;
                    }
                }
            }
        }
        let episodeObjectID = that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.radiologyTestRequestAcceptionFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Episode = episode;
            }

            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.radiologyTestRequestAcceptionFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
            if (episode != null) {
                episode.Diagnosis = that.radiologyTestRequestAcceptionFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.radiologyTestRequestAcceptionFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.radiologyTestRequestAcceptionFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.radiologyTestRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let radiologyObjectID = that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest["EpisodeAction"];
        if (radiologyObjectID != null && (typeof radiologyObjectID === 'string')) {
            let radiology = that.radiologyTestRequestAcceptionFormViewModel.Radiologys.find(o => o.ObjectID.toString() === radiologyObjectID.toString());
            if (radiology) {
                that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Radiology = radiology;
            }
            that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Radiology.Episode = that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.Episode;
            if (radiology != null) {
                let requestDoctorObjectID = radiology["RequestDoctor"];
                if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
                    let requestDoctor = that.radiologyTestRequestAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
                    if (requestDoctor) {
                        radiology.RequestDoctor = requestDoctor;
                    }
                }
            }
        }

        if(that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.ContrastType == RadiologyContrastTypeEnum.Contrasty)
            this.ContrastType_Text ="Kontrastlı (İlaçlı)";
        else if(that.radiologyTestRequestAcceptionFormViewModel._RadiologyTest.ContrastType == RadiologyContrastTypeEnum.Unenhanced)
            this.ContrastType_Text ="Kontrastsız";

    }


    async ngOnInit() {
        let that = this;
        await this.load(RadiologyTestRequestAcceptionFormViewModel);
        this.AddHelpMenu();

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.ActionDate != event) {
                this._RadiologyTest.ActionDate = event;
            }
        }
    }

    public oncmbDentalPositionChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.DentalPosition != event) {
                this._RadiologyTest.DentalPosition = event;
            }
        }
    }

    public oncmbToothNumberChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.TestToothNumber != event) {
                this._RadiologyTest.TestToothNumber = event;
            }
        }
    }

    public onCommonDescriptionChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Radiology != null && this._RadiologyTest.Radiology.Description != event) {
                this._RadiologyTest.Radiology.Description = event;
            }
        }
    }

    public onContrastTypeChanged(event): void {
        if(this._RadiologyTest != null && this._RadiologyTest.ContrastType != event) { 
        this._RadiologyTest.ContrastType = event;
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

    public onEquipmentChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.Equipment != event) {
                this._RadiologyTest.Equipment = event;
            }
        }
    }

    public onGunuBirlikTakipChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.IsGunubirlikTakip != event) {
                this._RadiologyTest.IsGunubirlikTakip = event;
            }
        }
        this.GunuBirlikTakip_CheckedChanged();
    }

    public onOwnerTypeChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.OwnerType != event) {
                this._RadiologyTest.OwnerType = event;
            }
        }
    }

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Radiology != null && this._RadiologyTest.Radiology.PreDiagnosis != event) {
                this._RadiologyTest.Radiology.PreDiagnosis = event;
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

    public onRequestNoChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.RadiologyRequestNo != event) {
                this._RadiologyTest.RadiologyRequestNo = event;
            }
        }
    }

    public onAccessionNoChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.AccessionNo != event) {
                this._RadiologyTest.AccessionNo = event;
            }
        }
    }

    public ontakipTipiChanged(event): void {
        if (event != null) {
            //if (this._RadiologyTest != null &&
            //this._RadiologyTest.MedulaProvision != null && this._RadiologyTest.MedulaProvision.TakipTipi != event) {
            //this._RadiologyTest.MedulaProvision.TakipTipi = event;
            //}
        }
    }

    public ontedaviTipiChanged(event): void {
        if (event != null) {
            //if (this._RadiologyTest != null &&
            //this._RadiologyTest.MedulaProvision != null && this._RadiologyTest.MedulaProvision.TedaviTipi != event) {
            //this._RadiologyTest.MedulaProvision.TedaviTipi = event;
            //}
        }
    }

    public onTestTechnicianNoteChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.TechnicianNote != event) {
                this._RadiologyTest.TechnicianNote = event;
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

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._RadiologyTest != null &&
                this._RadiologyTest.Episode != null &&
                this._RadiologyTest.Episode.Patient != null && this._RadiologyTest.Episode.Patient.Age != event) {
                this._RadiologyTest.Episode.Patient.Age = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.RequestNo, "Text", this.__ttObject, "RadiologyRequestNo");
        redirectProperty(this.ContrastType, "Value", this.__ttObject, "ContrastType");
        redirectProperty(this.AccessionNo, "Text", this.__ttObject, "AccessionNo");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Episode.Patient.Age");
        redirectProperty(this.GunuBirlikTakip, "Value", this.__ttObject, "IsGunubirlikTakip");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "Radiology.PreDiagnosis");
        redirectProperty(this.CommonDescription, "Text", this.__ttObject, "Radiology.Description");
        redirectProperty(this.cmbToothNumber, "Value", this.__ttObject, "TestToothNumber");
        redirectProperty(this.cmbDentalPosition, "Value", this.__ttObject, "DentalPosition");
        redirectProperty(this.DisTaahhutNo, "Text", this.__ttObject, "DisTaahhutNo");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.TestTechnicianNote, "Text", this.__ttObject, "TechnicianNote");
        redirectProperty(this.tedaviTipi, "SelectedObject", this.__ttObject, "MedulaProvision.TedaviTipi");
        redirectProperty(this.takipTipi, "SelectedObject", this.__ttObject, "MedulaProvision.TakipTipi");
        redirectProperty(this.OwnerType, "Text", this.__ttObject, "OwnerType");
    }

    public initFormControls(): void {
        this.labelContrastType = new TTVisual.TTLabel();
        this.labelContrastType.Text = "Kontrastlı/ Kontrsatsız";
        this.labelContrastType.Name = "labelContrastType";
        this.labelContrastType.TabIndex = 82;
    
        this.ContrastType = new TTVisual.TTEnumComboBox();
        this.ContrastType.DataTypeName = "RadiologyContrastTypeEnum";
        this.ContrastType.Name = "ContrastType";
        this.ContrastType.TabIndex = 81;
        this.ContrastType.ReadOnly = true;
        this.ContrastType.Enabled = false;

        this.GunuBirlikTakip = new TTVisual.TTCheckBox();
        this.GunuBirlikTakip.Value = false;
        this.GunuBirlikTakip.Text = i18n("M15048", "Günübirlik Takip Al");
        this.GunuBirlikTakip.Title = i18n("M15048", "Günübirlik Takip Al");
        this.GunuBirlikTakip.Name = "GunuBirlikTakip";
        this.GunuBirlikTakip.TabIndex = 80;
        //this.GunuBirlikTakip.Font = "Name=Tahoma, Size=8, Units=3, GdiCharSet=1, GdiVerticalFont=False";


        this.ttBarcodePreviewCheck = new TTVisual.TTCheckBox();
        this.ttBarcodePreviewCheck.Value = false;
        this.ttBarcodePreviewCheck.Text = i18n("M11543", "Barkod Yazdır Önizleme ");
        this.ttBarcodePreviewCheck.Title = i18n("M11543", "Barkod Yazdır Önizleme ");
        this.ttBarcodePreviewCheck.Font = "Name=Tahoma, Size=8, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttBarcodePreviewCheck.Name = "ttBarcodePreviewCheck";
        this.ttBarcodePreviewCheck.TabIndex = 79;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Text = i18n("M27300", "Acil");
        this.Emergency.Title = i18n("M27300", "Acil");
        this.Emergency.Name = "Acil";
        this.Emergency.TabIndex = 81;
        //this.Emergency.Font = "Name=Tahoma, Size=8, Units=3, GdiCharSet=1, GdiVerticalFont=False";


        this.RequestNo = new TTVisual.TTTextBox();
        this.RequestNo.BackColor = "#F0F0F0";
        this.RequestNo.ReadOnly = true;
        this.RequestNo.Name = "RequestNo";
        this.RequestNo.TabIndex = 3;

        this.AccessionNo = new TTVisual.TTTextBox();
        this.AccessionNo.BackColor = "#F0F0F0";
        this.AccessionNo.ReadOnly = true;
        this.AccessionNo.Name = "AccessionNo";
        this.AccessionNo.TabIndex = 3;

        this.cmdPrintRequestNo = new TTVisual.TTButton();
        this.cmdPrintRequestNo.Text = i18n("M27400", "Barkod Bas");
        this.cmdPrintRequestNo.Name = "cmdPrintRequestNo";
        this.cmdPrintRequestNo.TabIndex = 4;

        this.TabSubaction = new TTVisual.TTTabControl();
        this.TabSubaction.Name = "TabSubaction";
        this.TabSubaction.TabIndex = 12;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M23303", "Tetkik Bilgileri");
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M12031", " Bölüm");
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 0;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 7;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M12222", "Cihaz");
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 2;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M23112", "Teknisyen Notu");
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 66;

        this.Equipment = new TTVisual.TTObjectListBox();
        this.Equipment.ListDefName = "ResRadiologyEquipmentListDefinition";
        this.Equipment.Name = "Equipment";
        this.Equipment.AutoCompleteDialogWidth = "30%";

        this.ProcedureObject = new TTVisual.TTObjectListBox();
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.ListDefName = "RadiologyTestListDefinition";
        this.ProcedureObject.Font = "Name=Tahoma, Size=9, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.TabIndex = 0;
        this.ProcedureObject.AutoCompleteDialogHeight = "600px";

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M10469", "Açıklama");
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 65;

        this.Deparment = new TTVisual.TTObjectListBox();
        this.Deparment.Required = true;
        this.Deparment.ListDefName = "ResRadiologyDepartmentListDefinition";
        this.Deparment.Name = "Deparment";
        this.Deparment.AutoCompleteDialogWidth = "30%";


        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "TETKİK";
        this.ttlabel1.Font = "Name=Tahoma, Size=9,75, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#FF0000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 70;

        this.DisTaahhutNo = new TTVisual.TTTextBox();
        this.DisTaahhutNo.Name = "DisTaahhutNo";
        this.DisTaahhutNo.TabIndex = 6;

        this.TestTechnicianNote = new TTVisual.TTTextBox();
        this.TestTechnicianNote.Multiline = true;
        this.TestTechnicianNote.Name = "TestTechnicianNote";
        this.TestTechnicianNote.TabIndex = 8;

        this.cmbToothNumber = new TTVisual.TTEnumComboBox();
        this.cmbToothNumber.DataTypeName = "ToothNumberEnum";
        this.cmbToothNumber.BackColor = "#F0F0F0";
        this.cmbToothNumber.Enabled = false;
        this.cmbToothNumber.Name = "cmbToothNumber";
        this.cmbToothNumber.TabIndex = 4;

        this.labelDisTaahhutNo = new TTVisual.TTLabel();
        this.labelDisTaahhutNo.Text = i18n("M12945", "Diş Taahhüt Numarası");
        this.labelDisTaahhutNo.Name = "labelDisTaahhutNo";
        this.labelDisTaahhutNo.TabIndex = 38;

        this.ttbuttonToothSchema = new TTVisual.TTButton();
        this.ttbuttonToothSchema.Text = i18n("M12940", "Diş Şeması");
        this.ttbuttonToothSchema.Name = "ttbuttonToothSchema";
        this.ttbuttonToothSchema.TabIndex = 3;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M12919", "Diş Pozisyon");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 30;

        this.cmbDentalPosition = new TTVisual.TTEnumComboBox();
        this.cmbDentalPosition.DataTypeName = "DentalPositionEnum";
        this.cmbDentalPosition.BackColor = "#F0F0F0";
        this.cmbDentalPosition.Enabled = false;
        this.cmbDentalPosition.Name = "cmbDentalPosition";
        this.cmbDentalPosition.TabIndex = 5;

        this.lblToothNumber = new TTVisual.TTLabel();
        this.lblToothNumber.Text = i18n("M12917", "Diş Numarası");
        this.lblToothNumber.Name = "lblToothNumber";
        this.lblToothNumber.TabIndex = 30;

        this.tabMaterial = new TTVisual.TTTabPage();
        this.tabMaterial.DisplayIndex = 1;
        this.tabMaterial.TabIndex = 1;
        this.tabMaterial.Text = i18n("M18553", "Malzeme Bilgileri");
        this.tabMaterial.Name = "tabMaterial";

        this.Materials = new TTVisual.TTGrid();
        this.Materials.Name = "Materials";
        this.Materials.TabIndex = 75;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "ConsumableMaterialAndDrugList";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M18545", "Malzeme");
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

        this.MedulaTakipBilgileriTabPage = new TTVisual.TTTabPage();
        this.MedulaTakipBilgileriTabPage.DisplayIndex = 2;
        this.MedulaTakipBilgileriTabPage.TabIndex = 2;
        this.MedulaTakipBilgileriTabPage.Text = i18n("M18817", "Medula Takip Bilgileri");
        this.MedulaTakipBilgileriTabPage.Name = "MedulaTakipBilgileriTabPage";

        this.takipTipi = new TTVisual.TTListDefComboBox();
        this.takipTipi.ListDefName = "TakipTipiListDefinition";
        this.takipTipi.Name = "takipTipi";
        this.takipTipi.TabIndex = 3;

        this.labeltakipTipi = new TTVisual.TTLabel();
        this.labeltakipTipi.Text = i18n("M22632", "Takibin Tipi");
        this.labeltakipTipi.Name = "labeltakipTipi";
        this.labeltakipTipi.TabIndex = 2;

        this.labeltedaviTipi = new TTVisual.TTLabel();
        this.labeltedaviTipi.Text = i18n("M23033", "Tedavi Tipi");
        this.labeltedaviTipi.Name = "labeltedaviTipi";
        this.labeltedaviTipi.TabIndex = 1;

        this.tedaviTipi = new TTVisual.TTListDefComboBox();
        this.tedaviTipi.ListDefName = "TedaviTipiListDefinition";
        this.tedaviTipi.Name = "tedaviTipi";
        this.tedaviTipi.TabIndex = 0;

        this.OwnerType = new TTVisual.TTTextBox();
        this.OwnerType.Name = "OwnerType";
        this.OwnerType.TabIndex = 77;
        this.OwnerType.Visible = false;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.BackColor = "#F0F0F0";
        this.tttextbox2.ReadOnly = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 6;

        this.CommonDescription = new TTVisual.TTTextBox();
        this.CommonDescription.Multiline = true;
        this.CommonDescription.BackColor = "#F0F0F0";
        this.CommonDescription.ReadOnly = true;
        this.CommonDescription.Name = "CommonDescription";
        this.CommonDescription.TabIndex = 11;
        this.CommonDescription.Height = "200px";

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#F0F0F0";
        this.PREDIAGNOSIS.ReadOnly = true;
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 10;
        this.PREDIAGNOSIS.Height = "200px";

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ReadOnly = true;
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 7;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.CustomFormat = "dd/MM/yyyy hh:mm";
        this.ActionDate.Format = DateTimePickerFormat.Long;
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
        this.GridEpisodeDiagnosis.TabIndex = 9;

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
        this.EpisodeDiagnose.Width = 350;

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
        this.EpisodeResponsibleUser.Width = 150;

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
        this.EntryActionType.Width = 110;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.lblAge = new TTVisual.TTLabel();
        this.lblAge.Text = i18n("M15336", "Hasta Yaşı");
        this.lblAge.Name = "lblAge";
        this.lblAge.TabIndex = 78;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 4;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M14678", "Genel Açıklamalar");
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 5;

        this.lblRequestNo = new TTVisual.TTLabel();
        this.lblRequestNo.Text = i18n("M16636", "İstek No");
        this.lblRequestNo.BackColor = "#DCDCDC";
        this.lblRequestNo.ForeColor = "#000000";
        this.lblRequestNo.Name = "lblRequestNo";
        this.lblRequestNo.TabIndex = 4;

        this.lblAccessionNo = new TTVisual.TTLabel();
        this.lblAccessionNo.Text = i18n("M16461", "İmaj Erişim No");
        this.lblAccessionNo.BackColor = "#DCDCDC";
        this.lblAccessionNo.ForeColor = "#000000";
        this.lblAccessionNo.Name = "lblAccessionNo";
        this.lblAccessionNo.TabIndex = 4;

        this.ttPrintRequestBarcode = new TTVisual.TTButton();
        this.ttPrintRequestBarcode.BackColor = "#FFFACD";
        this.ttPrintRequestBarcode.Text = i18n("M11542", "Barkod Yazdır");
        this.ttPrintRequestBarcode.Name = "ttPrintRequestBarcode";
        this.ttPrintRequestBarcode.TabIndex = 8;

        this.MaterialsColumns = [this.Material, this.Barcode, this.DistributionType, this.Amount];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.TabSubaction.Controls = [this.tttabpage1, this.tabMaterial, this.MedulaTakipBilgileriTabPage];
        this.tttabpage1.Controls = [this.ttlabel4, this.Description, this.ttlabel5, this.ttlabel10, this.Equipment, this.ProcedureObject, this.ttlabel9, this.Deparment, this.ttlabel1, this.DisTaahhutNo, this.TestTechnicianNote, this.cmbToothNumber, this.labelDisTaahhutNo, this.ttbuttonToothSchema, this.ttlabel2, this.cmbDentalPosition, this.lblToothNumber];
        this.tabMaterial.Controls = [this.Materials];
        this.MedulaTakipBilgileriTabPage.Controls = [this.takipTipi, this.labeltakipTipi, this.labeltedaviTipi, this.tedaviTipi];
        this.Controls = [this.labelContrastType, this.ContrastType,this.GunuBirlikTakip, this.ttBarcodePreviewCheck, this.RequestNo, this.AccessionNo, this.cmdPrintRequestNo, this.TabSubaction, this.tttabpage1, this.ttlabel4, this.Description, this.ttlabel5, this.ttlabel10, this.Equipment, this.ProcedureObject, this.ttlabel9, this.Deparment, this.ttlabel1, this.DisTaahhutNo, this.TestTechnicianNote, this.cmbToothNumber, this.labelDisTaahhutNo, this.ttbuttonToothSchema, this.ttlabel2, this.cmbDentalPosition, this.lblToothNumber, this.tabMaterial, this.Materials, this.Material, this.Barcode, this.DistributionType, this.Amount, this.MedulaTakipBilgileriTabPage, this.takipTipi, this.labeltakipTipi, this.labeltedaviTipi, this.tedaviTipi, this.OwnerType, this.tttextbox2, this.CommonDescription, this.PREDIAGNOSIS, this.ttobjectlistbox1, this.ActionDate, this.labelProcessTime, this.ttlabel13, this.ttlabel15, this.PATIENTGROUPENUM, this.ttlabel16, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ReasonForAdmission, this.lblAge, this.ttlabel6, this.ttlabel7, this.lblRequestNo, this.lblAccessionNo, this.ttPrintRequestBarcode, this.Emergency];

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
