//$7710061A
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyTestProcedureFormViewModel } from './RadiologyTestProcedureFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DPADetailFirmPriceOffer, Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTestBaseForm } from "Modules/Tibbi_Surec/Radyoloji_Modulu/RadiologyTestBaseForm";
import { RadiologyTestService } from "ObjectClassService/RadiologyTestService";
import { SubActionMatPricingDet } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyRepeatReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { ResRadiologyEquipment } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SagSol } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { RadiologyBarcodeInfo } from 'app/Barcode/Models/RadiologyBarcodeInfo';
import { CommonService } from 'ObjectClassService/CommonService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ClickFunctionParams, ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'RadiologyTestProcedureForm',
    templateUrl: './RadiologyTestProcedureForm.html',
    providers: [MessageService,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }
    ]
})
export class RadiologyTestProcedureForm extends RadiologyTestBaseForm implements OnInit {
    Emergency: TTVisual.ITTCheckBox;
    ActionDate: TTVisual.ITTDateTimePicker;
    RequestNo: TTVisual.ITTTextBox;
    AccessionNo: TTVisual.ITTTextBox;
    Amount: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    buttonOpenTeleTipResults: TTVisual.ITTButton;
    cmbDentalPosition: TTVisual.ITTEnumComboBox;
    cmbToothNumber: TTVisual.ITTEnumComboBox;
    cmdPrntRequestNo: TTVisual.ITTButton;
    cmdSendPACS: TTVisual.ITTButton;
    CommonDescription: TTVisual.ITTTextBox;
    Deparment: TTVisual.ITTObjectListBox;
    Description: TTVisual.ITTTextBox;
    DisTaahhutNo: TTVisual.ITTTextBox;
    DistributionType: TTVisual.ITTTextBoxColumn;
    DPADetailFirmPriceOffer: TTVisual.ITTListBoxColumn;
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
    lblToothNumber: TTVisual.ITTLabel;
    malzemeBrans: TTVisual.ITTTextBoxColumn;
    malzemeCokluOzelDurum: TTVisual.ITTButtonColumn;
    malzemeOzelDurum: TTVisual.ITTListBoxColumn;
    malzemeSatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    malzemeTuru: TTVisual.ITTListBoxColumn;
    Material: TTVisual.ITTListBoxColumn;
    Materials: TTVisual.ITTGrid;
    OwnerType: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    ProcedureObject: TTVisual.ITTObjectListBox;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    RepeatReason: TTVisual.ITTObjectListBox;
    SurgeryDirectPurchaseGrids: TTVisual.ITTGrid;
    taniCokluOzelDurum: TTVisual.ITTButtonColumn;
    taniOzelDurum: TTVisual.ITTListBoxColumn;
    TestTechnicianNote: TTVisual.ITTTextBox;
    ttBarcodePreviewCheck: TTVisual.ITTCheckBox;
    ttbuttonToothSchema: TTVisual.ITTButton;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttlabelBirim: TTVisual.ITTLabel;
    ttlabelDrAnesteziTescilNo: TTVisual.ITTLabel;
    ttlabelSagSol: TTVisual.ITTLabel;
    TTListBoxDrAnesteziTescilNo: TTVisual.ITTObjectListBox;
    TTListBoxKesi: TTVisual.ITTObjectListBox;
    TTListBoxSagSol: TTVisual.ITTObjectListBox;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttPrintRequestBarcode: TTVisual.ITTButton;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttextboxBirim: TTVisual.ITTTextBox;
    txtBarcode: TTVisual.ITTTextBoxColumn;
    txtKesinlesenMiktar: TTVisual.ITTTextBoxColumn;
    public GridEpisodeDiagnosisColumns = [];
    public MaterialsColumns = [];
    public SurgeryDirectPurchaseGridsColumns = [];
    public radiologyTestProcedureFormViewModel: RadiologyTestProcedureFormViewModel = new RadiologyTestProcedureFormViewModel();
    public get _RadiologyTest(): RadiologyTest {
        return this._TTObject as RadiologyTest;
    }
    private RadiologyTestProcedureForm_DocumentUrl: string = '/api/RadiologyTestService/RadiologyTestProcedureForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private barcodePrintService: IBarcodePrintService,
        private objectContextService: ObjectContextService,
        protected ngZone: NgZone,
        protected helpMenuService: HelpMenuService,
        private sideBarMenuService: ISidebarMenuService,
        protected modalService: IModalService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RadiologyTestProcedureForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let patientDocumentUpload = new DynamicSidebarMenuItem();
        patientDocumentUpload.key = 'patientDocumentUpload';
        patientDocumentUpload.icon = 'ai ai-hasta-dokuman-ekle';
        patientDocumentUpload.label = i18n("M15178", "Hasta Dokümanı Ekle");
        patientDocumentUpload.componentInstance = this.helpMenuService;
        patientDocumentUpload.clickFunction = this.helpMenuService.patientDocumentUpload;
        patientDocumentUpload.parameterFunctionInstance = this;
        patientDocumentUpload.getParamsFunction = this.getClickFunctionParams;
        patientDocumentUpload.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', patientDocumentUpload);

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

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('patientDocumentUpload');
        this.sideBarMenuService.removeMenu('pathologyRequest');
    }


    public getClickFunctionParams(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this.radiologyTestProcedureFormViewModel._RadiologyTest.Radiology.ObjectID, this.radiologyTestProcedureFormViewModel._RadiologyTest.Episode.ObjectID, new Guid(this.radiologyTestProcedureFormViewModel._RadiologyTest.Episode.Patient.toString())));
        return clickFunctionParams;
    }


    private async buttonOpenTeleTipResults_Click(): Promise<void> {
        //Teletip username password ile replace edilecek , commentout lu kisim acilacak
        // Test guid
        //System.Diagnostics.Process.Start("http://xxxxxx.com/?GUID=82d1824f-3117-44e2-82f6-004466b148f4");
    }


    public async cmdPrintRequestNo_Click(): Promise<void> {

        let apiUrl: string = 'api/RadiologyTestService/PrepareRadiologyBarcode?RadiologyTestObjectID=' + this._RadiologyTest.ObjectID.toString();
        let result: Array<RadiologyBarcodeInfo> = await this.httpService.get<Array<RadiologyBarcodeInfo>>(apiUrl);

        if (this.radiologyTestProcedureFormViewModel.NewRadiologyBarcode) {
            for (var i = 0; i < result.length; i++) {
                await this.barcodePrintService.printAllBarcode(result[i], "generateRadiologyBarcodeNew", "printRadiologyBarcodeNew");
            }
        } else {
            for (var i = 0; i < result.length; i++) {

                await this.barcodePrintService.printAllBarcode(result[i], "generateRadiologyBarcode", "printRadiologyBarcode");

            }
        }



    }

    public async cmdSendPACS_Click(): Promise<void> {
        (await RadiologyTestService.SendRadiologyTestToPACS(this._RadiologyTest));
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
        //         if (radiologyTestDentalForm != null)
        //             radiologyTestDentalForm.ShowReadOnly(this,_RadiologyTest);
        let a = 1;
    }
    public async ttPrintRequestBarcode_Click(): Promise<void> {
        /*let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
        let cache: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
        cache.push("VALUE", this._RadiologyTest.ObjectID);
        parameters.push("TTOBJECTID", cache);
        if (this.ttBarcodePreviewCheck.Value === true) {
            TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_RadiologyRequestBarcode, true, 1, parameters);
        }
        else {
            TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_RadiologyRequestBarcode, false, 1, parameters);
        }*/
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        /*   super.ClientSidePostScript(transDef);
           let hasMaterial: boolean = false;
           if (this.Materials.Rows.length > 0) {
               for (let row of this.Materials.Rows) {
                   if (row.Cells["Amount"].Value !== null)
                       hasMaterial = true;
               }
           }
           if (!hasMaterial) {
               let result: string = TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Malzeme seçmediniz. Devam etmek istediğinize emin misiniz?", 1);
               if (result === "H") {
                   let message: string = (await SystemMessageService.GetMessage(488));
                   throw new TTException(message);
               }
           }
           if (transDef !== null) {
               if (transDef.FromStateDefID === RadiologyTest.RadiologyTestStates.Procedure && transDef.ToStateDefID === RadiologyTest.RadiologyTestStates.Reject)
                   DisplayRadiologyRejectReason();
           }
           */

        super.ClientSidePostScript(transDef);
        if (transDef !== null) {
            if (transDef.FromStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.Procedure.valueOf() && transDef.ToStateDefID.valueOf() === RadiologyTest.RadiologyTestStates.Cancelled.valueOf()) {

                let getDescription: string = await TTVisual.InputForm.GetText(i18n("M16531", "İptal açıklaması giriniz."), "", false, true);
                if (String.isNullOrEmpty(getDescription) === false)
                    this._RadiologyTest.ReasonOfCancel = getDescription;
                else
                    throw new TTException(i18n("M16532", "İptal açıklaması girmelisiniz!"));
            }
        }
    }
    protected async ClientSidePreScript(): Promise<void> {




    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        //Asagıdakı kontrol clıentsıde postscrıpte tasındı.
        /* bool hasMaterial = false;
        if (Materials.Rows.Count > 0)
        {
            foreach (ITTGridRow row in Materials.Rows)
                if (row.Cells["Amount"].Value != null)
                hasMaterial = true;
        }
        if (!hasMaterial)
        {
            string result = Show Box.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Malzeme seçmediniz. Devam etmek istediğinize emin misiniz?", 1);
            if (result == "H")
            {
                String message = SystemMessage.GetMessage(488);
                throw new TTUtils.TTException(message);

            }
        }
        */

        if (this._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids.length > 0) {
            let materials: Array<DPADetailFirmPriceOffer> = new Array<DPADetailFirmPriceOffer>();
            for (let sdg of this._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids) {
                if (materials.length > 0 && materials.Contains(sdg.DPADetailFirmPriceOffer)) {
                    throw new TTException(i18n("M11354", "Aynı Malzemeyi Birden Fazla Giremezsiniz ! "));
                }
                else materials.push(sdg.DPADetailFirmPriceOffer);
            }
        }
        for (let sdg of this._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids) {
            if (sdg.UBBCode == null) {
                this._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids.pop();
            }
        }





        if (transDef !== null) {
            if (transDef.ToStateDefID === RadiologyTest.RadiologyTestStates.Completed || transDef.ToStateDefID === RadiologyTest.RadiologyTestStates.Approve || transDef.ToStateDefID === RadiologyTest.RadiologyTestStates.ResultEntry) {
                for (let sdg of this._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids) {
                    let titubbPrice: SubActionMatPricingDet = new SubActionMatPricingDet(this._RadiologyTest.ObjectContext);
                    titubbPrice.PatientPrice = 0;
                    titubbPrice.SubActionMaterial = sdg;
                    if (sdg.DPADetailFirmPriceOffer !== null && sdg.DPADetailFirmPriceOffer.OfferedSUTCode !== null) {
                        titubbPrice.ExternalCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode;
                        titubbPrice.Description = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTName;
                        titubbPrice.PayerPrice = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTPrice;
                    }
                    //                else
                    //                {
                    //                    titubbPrice.ExternalCode = "KODSUZ";
                    //                    titubbPrice.Description = productDefinition.Name;
                    //                    titubbPrice.PayerPrice = 0;
                    //                }
                    titubbPrice.ProductDefinition = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product;
                }
            }
        }
        //let malzemeObjectID: Guid = new Guid((await SystemParameterService.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.toString())));
        //for (let sdg of this._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids) {
        //    sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
        //    sdg.Material = <Material>this._RadiologyTest.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
        //    sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product !== null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
        //    sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
        //}
    }
    protected async PreScript() {
        super.PreScript();
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("RADIOLOGYTEST", this.radiologyTestProcedureFormViewModel._RadiologyTest.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
        await this.load(RadiologyTestProcedureFormViewModel);

    }

    btnShowLISResultViewForAllEpisodes_Click(): void {
        this.viewResultURL = "";
        this.GetViewResultURLForAllEpisodes(this.radiologyTestProcedureFormViewModel.EpisodeID, this.radiologyTestProcedureFormViewModel.PatientTCNo).then(() => {
            this.openInNewTab(this.viewResultURL);
        });
    }



    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RadiologyTest();
        this.radiologyTestProcedureFormViewModel = new RadiologyTestProcedureFormViewModel();
        this._ViewModel = this.radiologyTestProcedureFormViewModel;
        this.radiologyTestProcedureFormViewModel._RadiologyTest = this._TTObject as RadiologyTest;
        this.radiologyTestProcedureFormViewModel._RadiologyTest.ResUser = new ResUser();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.SagSol = new SagSol();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.AyniFarkliKesi = new AyniFarkliKesi();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.Equipment = new ResRadiologyEquipment();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.ProcedureObject = new ProcedureDefinition();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.Department = new ResRadiologyDepartment();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.RepeatReason = new RadiologyRepeatReasonDefinition();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.RadiologyTestTreatmentMaterial = new Array<RadiologyMaterial>();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids = new Array<SurgeryDirectPurchaseGrid>();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.Radiology = new Radiology();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.Radiology.RequestDoctor = new ResUser();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.Episode = new Episode();
        this.radiologyTestProcedureFormViewModel._RadiologyTest.Episode.Diagnosis = new Array<DiagnosisGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyTestProcedureFormViewModel = this._ViewModel as RadiologyTestProcedureFormViewModel;
        that._TTObject = this.radiologyTestProcedureFormViewModel._RadiologyTest;
        if (this.radiologyTestProcedureFormViewModel == null)
            this.radiologyTestProcedureFormViewModel = new RadiologyTestProcedureFormViewModel();
        if (this.radiologyTestProcedureFormViewModel._RadiologyTest == null)
            this.radiologyTestProcedureFormViewModel._RadiologyTest = new RadiologyTest();
        let resUserObjectID = that.radiologyTestProcedureFormViewModel._RadiologyTest["ResUser"];
        if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
            let resUser = that.radiologyTestProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
            if (resUser) {
                that.radiologyTestProcedureFormViewModel._RadiologyTest.ResUser = resUser;
            }
        }
        let sagSolObjectID = that.radiologyTestProcedureFormViewModel._RadiologyTest["SagSol"];
        if (sagSolObjectID != null && (typeof sagSolObjectID === 'string')) {
            let sagSol = that.radiologyTestProcedureFormViewModel.SagSols.find(o => o.ObjectID.toString() === sagSolObjectID.toString());
            if (sagSol) {
                that.radiologyTestProcedureFormViewModel._RadiologyTest.SagSol = sagSol;
            }
        }
        let ayniFarkliKesiObjectID = that.radiologyTestProcedureFormViewModel._RadiologyTest["AyniFarkliKesi"];
        if (ayniFarkliKesiObjectID != null && (typeof ayniFarkliKesiObjectID === 'string')) {
            let ayniFarkliKesi = that.radiologyTestProcedureFormViewModel.AyniFarkliKesis.find(o => o.ObjectID.toString() === ayniFarkliKesiObjectID.toString());
            if (ayniFarkliKesi) {
                that.radiologyTestProcedureFormViewModel._RadiologyTest.AyniFarkliKesi = ayniFarkliKesi;
            }
        }
        let equipmentObjectID = that.radiologyTestProcedureFormViewModel._RadiologyTest["Equipment"];
        if (equipmentObjectID != null && (typeof equipmentObjectID === 'string')) {
            let equipment = that.radiologyTestProcedureFormViewModel.ResRadiologyEquipments.find(o => o.ObjectID.toString() === equipmentObjectID.toString());
            if (equipment) {
                that.radiologyTestProcedureFormViewModel._RadiologyTest.Equipment = equipment;
            }
        }
        let procedureObjectObjectID = that.radiologyTestProcedureFormViewModel._RadiologyTest["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
            let procedureObject = that.radiologyTestProcedureFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
            if (procedureObject) {
                that.radiologyTestProcedureFormViewModel._RadiologyTest.ProcedureObject = procedureObject;
            }
        }
        let departmentObjectID = that.radiologyTestProcedureFormViewModel._RadiologyTest["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === 'string')) {
            let department = that.radiologyTestProcedureFormViewModel.ResRadiologyDepartments.find(o => o.ObjectID.toString() === departmentObjectID.toString());
            if (department) {
                that.radiologyTestProcedureFormViewModel._RadiologyTest.Department = department;
            }
        }
        let repeatReasonObjectID = that.radiologyTestProcedureFormViewModel._RadiologyTest["RepeatReason"];
        if (repeatReasonObjectID != null && (typeof repeatReasonObjectID === 'string')) {
            let repeatReason = that.radiologyTestProcedureFormViewModel.RadiologyRepeatReasonDefinitions.find(o => o.ObjectID.toString() === repeatReasonObjectID.toString());
            if (repeatReason) {
                that.radiologyTestProcedureFormViewModel._RadiologyTest.RepeatReason = repeatReason;
            }
        }
        that.radiologyTestProcedureFormViewModel._RadiologyTest.RadiologyTestTreatmentMaterial = that.radiologyTestProcedureFormViewModel.MaterialsGridList;
        for (let detailItem of that.radiologyTestProcedureFormViewModel.MaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.radiologyTestProcedureFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.radiologyTestProcedureFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.radiologyTestProcedureFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let malzemeTuru = that.radiologyTestProcedureFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
                if (malzemeTuru) {
                    detailItem.MalzemeTuru = malzemeTuru;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.radiologyTestProcedureFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        that.radiologyTestProcedureFormViewModel._RadiologyTest.RadiologyTest_SurgeryDirectPurchaseGrids = that.radiologyTestProcedureFormViewModel.SurgeryDirectPurchaseGridsGridList;
        for (let detailItem of that.radiologyTestProcedureFormViewModel.SurgeryDirectPurchaseGridsGridList) {
            let dPADetailFirmPriceOfferObjectID = detailItem["DPADetailFirmPriceOffer"];
            if (dPADetailFirmPriceOfferObjectID != null && (typeof dPADetailFirmPriceOfferObjectID === 'string')) {
                let dPADetailFirmPriceOffer = that.radiologyTestProcedureFormViewModel.DPADetailFirmPriceOffers.find(o => o.ObjectID.toString() === dPADetailFirmPriceOfferObjectID.toString());
                if (dPADetailFirmPriceOffer) {
                    detailItem.DPADetailFirmPriceOffer = dPADetailFirmPriceOffer;
                }
                if (dPADetailFirmPriceOffer != null) {
                    let offeredUBBObjectID = dPADetailFirmPriceOffer["OfferedUBB"];
                    if (offeredUBBObjectID != null && (typeof offeredUBBObjectID === 'string')) {
                        let offeredUBB = that.radiologyTestProcedureFormViewModel.ProductDefinitions.find(o => o.ObjectID.toString() === offeredUBBObjectID.toString());
                        if (offeredUBB) {
                            dPADetailFirmPriceOffer.OfferedUBB = offeredUBB;
                        }
                    }
                }
                if (dPADetailFirmPriceOffer != null) {
                    let directPurchaseActionDetailObjectID = dPADetailFirmPriceOffer["DirectPurchaseActionDetail"];
                    if (directPurchaseActionDetailObjectID != null && (typeof directPurchaseActionDetailObjectID === 'string')) {
                        let directPurchaseActionDetail = that.radiologyTestProcedureFormViewModel.DirectPurchaseActionDetails.find(o => o.ObjectID.toString() === directPurchaseActionDetailObjectID.toString());
                        if (directPurchaseActionDetail) {
                            dPADetailFirmPriceOffer.DirectPurchaseActionDetail = directPurchaseActionDetail;
                        }
                    }
                }
            }
        }
        let radiologyObjectID = that.radiologyTestProcedureFormViewModel._RadiologyTest["EpisodeAction"];
        if (radiologyObjectID != null && (typeof radiologyObjectID === 'string')) {
            let radiology = that.radiologyTestProcedureFormViewModel.Radiologys.find(o => o.ObjectID.toString() === radiologyObjectID.toString());
            if (radiology) {
                that.radiologyTestProcedureFormViewModel._RadiologyTest.Radiology = radiology;
            }
            if (radiology != null) {
                let requestDoctorObjectID = radiology["RequestDoctor"];
                if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
                    let requestDoctor = that.radiologyTestProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
                    if (requestDoctor) {
                        radiology.RequestDoctor = requestDoctor;
                    }
                }
            }
        }
        let episodeObjectID = that.radiologyTestProcedureFormViewModel._RadiologyTest["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.radiologyTestProcedureFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.radiologyTestProcedureFormViewModel._RadiologyTest.Episode = episode;
            }
            that.radiologyTestProcedureFormViewModel._RadiologyTest.Radiology.Episode = episode;
            if (episode != null) {
                episode.Diagnosis = that.radiologyTestProcedureFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.radiologyTestProcedureFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.radiologyTestProcedureFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.radiologyTestProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                    let ozelDurumObjectID = detailItem["OzelDurum"];
                    if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                        let ozelDurum = that.radiologyTestProcedureFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                        if (ozelDurum) {
                            detailItem.OzelDurum = ozelDurum;
                        }
                    }
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(RadiologyTestProcedureFormViewModel);
        this.AddHelpMenu();

    }


    public onEmergencyChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.Emergency != event) {
                this._RadiologyTest.Emergency = event;
            }
        }
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

    public onRepeatReasonChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.RepeatReason != event) {
                this._RadiologyTest.RepeatReason = event;
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

    public onTTListBoxSagSolChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.SagSol != event) {
                this._RadiologyTest.SagSol = event;
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

    public ontttextboxBirimChanged(event): void {
        if (event != null) {
            if (this._RadiologyTest != null && this._RadiologyTest.birim != event) {
                this._RadiologyTest.birim = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.CommonDescription, "Text", this.__ttObject, "GeneralDescription");
        redirectProperty(this.tttextboxBirim, "Text", this.__ttObject, "birim");
        redirectProperty(this.cmbToothNumber, "Value", this.__ttObject, "TestToothNumber");
        redirectProperty(this.cmbDentalPosition, "Value", this.__ttObject, "DentalPosition");
        redirectProperty(this.DisTaahhutNo, "Text", this.__ttObject, "DisTaahhutNo");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.TestTechnicianNote, "Text", this.__ttObject, "TechnicianNote");
        redirectProperty(this.OwnerType, "Text", this.__ttObject, "OwnerType");
    }

    public initFormControls(): void {
        this.cmdPrntRequestNo = new TTVisual.TTButton();
        this.cmdPrntRequestNo.Text = i18n("M27400", "Barkod Bas");
        this.cmdPrntRequestNo.Name = "cmdPrntRequestNo";
        this.cmdPrntRequestNo.TabIndex = 4;

        this.cmdSendPACS = new TTVisual.TTButton();
        this.cmdSendPACS.Text = i18n("M12352", "Çekim İsteği Gönder");
        this.cmdSendPACS.Name = "cmdSendPACS";
        this.cmdSendPACS.TabIndex = 5;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 10;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M23303", "Tetkik Bilgileri");
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.buttonOpenTeleTipResults = new TTVisual.TTButton();
        this.buttonOpenTeleTipResults.Text = "Hastanın geçmiş teletıp bilgileri";
        this.buttonOpenTeleTipResults.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.buttonOpenTeleTipResults.Name = "buttonOpenTeleTipResults";
        this.buttonOpenTeleTipResults.TabIndex = 82;

        this.TTListBoxDrAnesteziTescilNo = new TTVisual.TTObjectListBox();
        this.TTListBoxDrAnesteziTescilNo.ListDefName = "ResUserListDefinition";
        this.TTListBoxDrAnesteziTescilNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxDrAnesteziTescilNo.Name = "TTListBoxDrAnesteziTescilNo";
        this.TTListBoxDrAnesteziTescilNo.TabIndex = 5;

        this.TTListBoxSagSol = new TTVisual.TTObjectListBox();
        this.TTListBoxSagSol.ListDefName = "SagSolListDefinition";
        this.TTListBoxSagSol.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxSagSol.Name = "TTListBoxSagSol";
        this.TTListBoxSagSol.TabIndex = 7;

        this.TTListBoxKesi = new TTVisual.TTObjectListBox();
        this.TTListBoxKesi.ListDefName = "AyniFarkliKesiListDefinition";
        this.TTListBoxKesi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TTListBoxKesi.Name = "TTListBoxKesi";
        this.TTListBoxKesi.TabIndex = 6;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M12031", " Bölüm");
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 0;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 12;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M12222", "Cihaz");
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 2;

        this.DisTaahhutNo = new TTVisual.TTTextBox();
        this.DisTaahhutNo.Name = "DisTaahhutNo";
        this.DisTaahhutNo.TabIndex = 11;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M23112", "Teknisyen Notu");
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 66;

        this.Equipment = new TTVisual.TTObjectListBox();
        this.Equipment.ReadOnly = true;
        this.Equipment.ListDefName = "ResRadiologyEquipmentListDefinition";
        this.Equipment.Name = "Equipment";
        this.Equipment.TabIndex = 2;

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

        this.TestTechnicianNote = new TTVisual.TTTextBox();
        this.TestTechnicianNote.Multiline = true;
        this.TestTechnicianNote.Name = "TestTechnicianNote";
        this.TestTechnicianNote.TabIndex = 13;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M23125", "Tekrar Nedeni");
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 2;

        this.RepeatReason = new TTVisual.TTObjectListBox();
        //this.RepeatReason.ReadOnly = true;
        this.RepeatReason.ListDefName = "RadiologyRepeatReasonListDefinition";
        this.RepeatReason.Name = "RepeatReason";
        this.RepeatReason.TabIndex = 3;

        this.ttlabelSagSol = new TTVisual.TTLabel();
        this.ttlabelSagSol.Text = i18n("M21122", "Sağ / Sol");
        this.ttlabelSagSol.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelSagSol.Name = "ttlabelSagSol";
        this.ttlabelSagSol.TabIndex = 77;

        this.tttextboxBirim = new TTVisual.TTTextBox();
        this.tttextboxBirim.Name = "tttextboxBirim";
        this.tttextboxBirim.TabIndex = 4;

        this.ttlabelBirim = new TTVisual.TTLabel();
        this.ttlabelBirim.Text = "Birim";
        this.ttlabelBirim.Name = "ttlabelBirim";
        this.ttlabelBirim.TabIndex = 81;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "Aynı Kesi/ Farklı Seans";
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 75;

        this.lblToothNumber = new TTVisual.TTLabel();
        this.lblToothNumber.Text = i18n("M12917", "Diş Numarası");
        this.lblToothNumber.Name = "lblToothNumber";
        this.lblToothNumber.TabIndex = 30;

        this.ttlabelDrAnesteziTescilNo = new TTVisual.TTLabel();
        this.ttlabelDrAnesteziTescilNo.Text = i18n("M10968", "Anestezi Dr. Tescil No.");
        this.ttlabelDrAnesteziTescilNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelDrAnesteziTescilNo.Name = "ttlabelDrAnesteziTescilNo";
        this.ttlabelDrAnesteziTescilNo.TabIndex = 81;

        this.cmbToothNumber = new TTVisual.TTEnumComboBox();
        this.cmbToothNumber.DataTypeName = "ToothNumberEnum";
        this.cmbToothNumber.BackColor = "#F0F0F0";
        this.cmbToothNumber.Enabled = false;
        this.cmbToothNumber.Name = "cmbToothNumber";
        this.cmbToothNumber.TabIndex = 9;

        this.cmbDentalPosition = new TTVisual.TTEnumComboBox();
        this.cmbDentalPosition.DataTypeName = "DentalPositionEnum";
        this.cmbDentalPosition.BackColor = "#F0F0F0";
        this.cmbDentalPosition.Enabled = false;
        this.cmbDentalPosition.Name = "cmbDentalPosition";
        this.cmbDentalPosition.TabIndex = 10;

        this.labelDisTaahhutNo = new TTVisual.TTLabel();
        this.labelDisTaahhutNo.Text = i18n("M12945", "Diş Taahhüt Numarası");
        this.labelDisTaahhutNo.Name = "labelDisTaahhutNo";
        this.labelDisTaahhutNo.TabIndex = 38;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M12919", "Diş Pozisyon");
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 30;

        this.ttbuttonToothSchema = new TTVisual.TTButton();
        this.ttbuttonToothSchema.Text = i18n("M12940", "Diş Şeması");
        this.ttbuttonToothSchema.Name = "ttbuttonToothSchema";
        this.ttbuttonToothSchema.TabIndex = 8;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 0;
        this.tttabpage2.Text = i18n("M18553", "Malzeme Bilgileri");
        this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage2.Name = "tttabpage2";

        this.Materials = new TTVisual.TTGrid();
        this.Materials.Name = "Materials";
        this.Materials.TabIndex = 75;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "ConsumableMaterialAndDrugList";
        this.Material.DataMember = "Material";
        this.Material.Required = false;
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
        this.malzemeSatinAlisTarihi.DataMember = "MalzemeSatinAlisTarihi";
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
        this.SurgeryDirectPurchaseGrids.Name = "SurgeryDirectPurchaseGrids";
        this.SurgeryDirectPurchaseGrids.TabIndex = 0;
        this.SurgeryDirectPurchaseGrids.AllowUserToAddRows = true;
        this.SurgeryDirectPurchaseGrids.AllowUserToDeleteRows = true;

        this.DPADetailFirmPriceOffer = new TTVisual.TTListBoxColumn();
        this.DPADetailFirmPriceOffer.ListDefName = "DirectPurchaseActionDetailList";
        this.DPADetailFirmPriceOffer.DataMember = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOffer.DisplayIndex = 0;
        this.DPADetailFirmPriceOffer.HeaderText = i18n("M10240", "22F Malzeme");
        this.DPADetailFirmPriceOffer.Name = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOffer.Width = 300;

        this.txtBarcode = new TTVisual.TTTextBoxColumn();
        this.txtBarcode.DataMember = "ProductNumber";
        this.txtBarcode.DisplayIndex = 1;
        this.txtBarcode.HeaderText = i18n("M27321", "Barkod");
        this.txtBarcode.Name = "txtBarcode";
        this.txtBarcode.ReadOnly = true;
        this.txtBarcode.Width = 100;

        this.txtKesinlesenMiktar = new TTVisual.TTTextBoxColumn();
        this.txtKesinlesenMiktar.DataMember = "CertainAmount";
        this.txtKesinlesenMiktar.DisplayIndex = 2;
        this.txtKesinlesenMiktar.HeaderText = i18n("M17504", "Kesinleşen Miktar");
        this.txtKesinlesenMiktar.Name = "txtKesinlesenMiktar";
        this.txtKesinlesenMiktar.ReadOnly = true;
        this.txtKesinlesenMiktar.Width = 400;

        this.OwnerType = new TTVisual.TTTextBox();
        this.OwnerType.Name = "OwnerType";
        this.OwnerType.TabIndex = 77;
        this.OwnerType.Visible = false;

        this.CommonDescription = new TTVisual.TTTextBox();
        this.CommonDescription.Multiline = true;
        this.CommonDescription.BackColor = "#F0F0F0";
        this.CommonDescription.ReadOnly = true;
        this.CommonDescription.Name = "CommonDescription";
        this.CommonDescription.TabIndex = 9;
        this.CommonDescription.Height = "100px";

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#F0F0F0";
        this.PREDIAGNOSIS.ReadOnly = true;
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 8;
        this.PREDIAGNOSIS.Height = "100px";

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 7;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ReadOnly = true;
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 3;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.CustomFormat = "";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;
        this.ActionDate.ReadOnly = true;

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

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M14678", "Genel Açıklamalar");
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 5;

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
        this.GridEpisodeDiagnosis.TabIndex = 6;

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
        this.EntryActionType.Width = 100;

        this.taniOzelDurum = new TTVisual.TTListBoxColumn();
        this.taniOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.taniOzelDurum.DataMember = "OzelDurum";
        this.taniOzelDurum.DisplayIndex = 7;
        this.taniOzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.taniOzelDurum.Name = "taniOzelDurum";
        this.taniOzelDurum.Width = 100;

        this.taniCokluOzelDurum = new TTVisual.TTButtonColumn();
        this.taniCokluOzelDurum.DisplayIndex = 8;
        this.taniCokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.taniCokluOzelDurum.Name = "taniCokluOzelDurum";
        this.taniCokluOzelDurum.Width = 100;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Aynı Kesi/ Farklı Seans";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 75;

        this.ttPrintRequestBarcode = new TTVisual.TTButton();
        this.ttPrintRequestBarcode.BackColor = "#FFFACD";
        this.ttPrintRequestBarcode.Text = i18n("M11542", "Barkod Yazdır");
        this.ttPrintRequestBarcode.Name = "ttPrintRequestBarcode";
        this.ttPrintRequestBarcode.TabIndex = 8;

        this.ttBarcodePreviewCheck = new TTVisual.TTCheckBox();
        this.ttBarcodePreviewCheck.Value = false;
        this.ttBarcodePreviewCheck.Text = i18n("M11543", "Barkod Yazdır Önizleme ");
        this.ttBarcodePreviewCheck.Title = i18n("M11543", "Barkod Yazdır Önizleme ");
        //this.ttBarcodePreviewCheck.Font = "Name=Tahoma, Size=6,75, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttBarcodePreviewCheck.Name = "ttBarcodePreviewCheck";
        this.ttBarcodePreviewCheck.TabIndex = 79;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Text = i18n("M27300", "Acil");
        this.Emergency.Title = i18n("M27300", "Acil");
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 80;

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

        this.MaterialsColumns = [this.Material, this.Barcode, this.DistributionType, this.Amount, this.kodsuzMalzemeFiyati, this.malzemeTuru, this.kdv, this.malzemeBrans, this.malzemeSatinAlisTarihi, this.malzemeOzelDurum, this.malzemeCokluOzelDurum];
        this.SurgeryDirectPurchaseGridsColumns = [this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.taniOzelDurum, this.taniCokluOzelDurum];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3];
        this.tttabpage1.Controls = [this.buttonOpenTeleTipResults, this.TTListBoxDrAnesteziTescilNo, this.TTListBoxSagSol, this.TTListBoxKesi, this.ttlabel4, this.Description, this.ttlabel5, this.DisTaahhutNo, this.ttlabel10, this.Equipment, this.ProcedureObject, this.ttlabel9, this.Deparment, this.ttlabel1, this.TestTechnicianNote, this.ttlabel2, this.RepeatReason, this.ttlabelSagSol, this.tttextboxBirim, this.ttlabelBirim, this.ttlabel8, this.lblToothNumber, this.ttlabelDrAnesteziTescilNo, this.cmbToothNumber, this.cmbDentalPosition, this.labelDisTaahhutNo, this.ttlabel12, this.ttbuttonToothSchema];
        this.tttabpage2.Controls = [this.Materials];
        this.tttabpage3.Controls = [this.SurgeryDirectPurchaseGrids];
        this.Controls = [this.cmdPrntRequestNo, this.cmdSendPACS, this.tttabcontrol1, this.tttabpage1, this.buttonOpenTeleTipResults, this.TTListBoxDrAnesteziTescilNo, this.TTListBoxSagSol, this.TTListBoxKesi, this.ttlabel4, this.Description, this.ttlabel5, this.DisTaahhutNo, this.ttlabel10, this.Equipment, this.ProcedureObject, this.ttlabel9, this.Deparment, this.ttlabel1, this.TestTechnicianNote, this.ttlabel2, this.RepeatReason, this.ttlabelSagSol, this.tttextboxBirim, this.ttlabelBirim, this.ttlabel8, this.lblToothNumber, this.ttlabelDrAnesteziTescilNo, this.cmbToothNumber, this.cmbDentalPosition, this.labelDisTaahhutNo, this.ttlabel12, this.ttbuttonToothSchema, this.tttabpage2, this.Materials, this.Material, this.Barcode, this.DistributionType, this.Amount, this.kodsuzMalzemeFiyati, this.malzemeTuru, this.kdv, this.malzemeBrans, this.malzemeSatinAlisTarihi, this.malzemeOzelDurum, this.malzemeCokluOzelDurum, this.tttabpage3, this.SurgeryDirectPurchaseGrids, this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar, this.OwnerType, this.CommonDescription, this.PREDIAGNOSIS, this.ttlabel6, this.ttobjectlistbox1, this.ActionDate, this.labelProcessTime, this.ttlabel13, this.ttlabel7, this.ttlabel15, this.PATIENTGROUPENUM, this.ttlabel16, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.taniOzelDurum, this.taniCokluOzelDurum, this.ReasonForAdmission, this.ttlabel3, this.ttPrintRequestBarcode, this.ttBarcodePreviewCheck, this.Emergency, this.RequestNo, this.AccessionNo];

    }


}
