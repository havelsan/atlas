//$B2C6631C
import { Component, OnInit, NgZone } from '@angular/core';
import { NuclearMedicineApproveFormViewModel } from './NuclearMedicineApproveFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { RadyofarmasotikDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedRadPharmMatGrid } from 'NebulaClient/Model/AtlasClientModel';
import { NucMedTreatmentMat } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { NuclearMedicineTestInfo } from './NuclearMedicineReportedFormViewModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';

@Component({
    selector: 'NuclearMedicineApproveForm',
    templateUrl: './NuclearMedicineApproveForm.html',
    providers: [MessageService]
})
export class NuclearMedicineApproveForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    AmountDirectPurchaseGrid: TTVisual.ITTTextBoxColumn;
    barkod: TTVisual.ITTTextBoxColumn;
    //cmdReport: TTVisual.ITTButton;
    DirectPurchaseGrids: TTVisual.ITTGrid;
    DPADetailFirmPriceOffer: TTVisual.ITTListBoxColumn;
    DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid: TTVisual.ITTListBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnoseType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridNuclearMedicineMaterial: TTVisual.ITTGrid;
    InjectionDate: TTVisual.ITTDateTimePicker;
    IsEmergency: TTVisual.ITTCheckBox;
    IsInjection: TTVisual.ITTCheckBoxColumn;
    kdv: TTVisual.ITTTextBoxColumn;
    kodsuzMalzemeFiyatı: TTVisual.ITTTextBoxColumn;
    labelProcessTime: TTVisual.ITTLabel;
    malzemeBrans: TTVisual.ITTTextBoxColumn;
    malzemeCokluOzelDurum: TTVisual.ITTButtonColumn;
    malzemeOzelDurum: TTVisual.ITTListBoxColumn;
    malzemeSatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    malzemeTuru: TTVisual.ITTListBoxColumn;
    Material: TTVisual.ITTListBoxColumn;
    MaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    MaterialDirectPurchaseGrid: TTVisual.ITTListBoxColumn;
    Note: TTVisual.ITTTextBoxColumn;
    NuclearMedicine_RadyofarmasotikDirectPurchaseGrids: TTVisual.ITTGrid;
    NUCMEDDOCTORNOTE: TTVisual.ITTTabPage;
    nucMedSelectedTesttxt: TTVisual.ITTTextBox;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    PATIENTPHONENUMBER: TTVisual.ITTTextBox;
    PATIENTWEIGHT: TTVisual.ITTTextBox;
    PatientBirthDate: TTVisual.ITTDateTimePicker;
    PatientBirthPlace: TTVisual.ITTTextBox;
    PREDIAGNOSIS: TTVisual.ITTTextBox;
    ProcedureDate: TTVisual.ITTDateTimePicker;
    RADIOPHARMACYDESC: TTVisual.ITTTextBox;
    RadPharmMatTab: TTVisual.ITTTabPage;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    REQUESTDOCTOR: TTVisual.ITTObjectListBox;
    REQUESTDOCTORPHONE: TTVisual.ITTTextBox;
    RESPONSIBLEDOCTOR: TTVisual.ITTObjectListBox;
    SurgeryDirectPurchaseGrids: TTVisual.ITTGrid;
    TABNuclearMedicine: TTVisual.ITTTabControl;
    TabPageMaterial: TTVisual.ITTTabPage;
    taniCokluOzelDurum: TTVisual.ITTButtonColumn;
    taniOzelDurum: TTVisual.ITTListBoxColumn;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttdatetimepickercolumn1: TTVisual.ITTDateTimePickerColumn;
    ttgrid2: TTVisual.ITTGrid;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    TTListBox: TTVisual.ITTObjectListBox;
    ttlistboxcolumn1: TTVisual.ITTListBoxColumn;
    ttrichtextboxcontrol1: TTVisual.ITTRichTextBoxControl;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttabpage5: TTVisual.ITTTabPage;
    tttabpage6: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextboxcolumn1: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn2: TTVisual.ITTTextBoxColumn;
    txtBarcode: TTVisual.ITTTextBoxColumn;
    txtKesinlesenMiktar: TTVisual.ITTTextBoxColumn;
    Unit: TTVisual.ITTListBoxColumn;
    public DirectPurchaseGridsColumns = [];
    public TreatmentMaterialTypeName1: String;
    public TreatmentMaterialTypeName2: String;

    public ReadOnly1: boolean;
    public ReadOnly2: boolean;
    public nuclearMedicineTestInfo: NuclearMedicineTestInfo;

    public GridEpisodeDiagnosisColumns = [];
    public GridNuclearMedicineMaterialColumns = [];
    public NuclearMedicine_RadyofarmasotikDirectPurchaseGridsColumns = [];
    public SurgeryDirectPurchaseGridsColumns = [];
    public ttgrid2Columns = [];
    public nuclearMedicineApproveFormViewModel: NuclearMedicineApproveFormViewModel = new NuclearMedicineApproveFormViewModel();
    public get _NuclearMedicine(): NuclearMedicine {
        return this._TTObject as NuclearMedicine;
    }
    private NuclearMedicineApproveForm_DocumentUrl: string = '/api/NuclearMedicineService/NuclearMedicineApproveForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private sideBarMenuService: ISidebarMenuService, protected helpMenuService: HelpMenuService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.NuclearMedicineApproveForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async cmdImage_Click(): Promise<void> {
        //TODO:Showedit!
        //            string accessionNoStr = this._RadiologyTest.AccessionNo.ToString();
        //            string patientIdStr = this._RadiologyTest.EpisodeAction.Episode.Patient.ID.ToString();
        //            TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
        let url: string = '/api/NuclearMedicineService/RetrieveNuclearMedicineTestInfo';
        let input = { 'NuclearMedicineObjectID': this._NuclearMedicine.ObjectID.toString() };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<NuclearMedicineTestInfo>(url, input);
        this.nuclearMedicineTestInfo = result;

        let accessionNoStr: string = this.nuclearMedicineTestInfo.AccessionNo; //this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo.toString();
        let sysparam: string = (await SystemParameterService.GetParameterValue("PACSVIEWERURL", null));
        let URLLink: string = sysparam + "?an=" + accessionNoStr + "&usr=extreme"; //http://X.X.X.X:35005/?an=0000000&usr=extreme

        if (URLLink == null) {
            InfoBox.Alert(i18n("M16463", "İmaj gösterme linki bulunamadı!"));
        } else {
            let win = window.open(URLLink, '_blank');
            win.focus();
        }

    }

    private async GridEpisodeDiagnosis_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //TODO:ShowEdit
        //if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
        //{

        //    NuclearMedicineCokluOzelDurum nmcod = new NuclearMedicineCokluOzelDurum();
        //    nmcod.ShowEdit(this.FindForm(), this._NuclearMedicine);
        //}
        let a = 1;
    }
    private async GridNuclearMedicineMaterial_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //TODO:ShowEdit!
        //if (((ITTGridCell)GridNuclearMedicineMaterial.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
        //{

        //    NuclearMedicineCokluOzelDurum nmcod = new NuclearMedicineCokluOzelDurum();
        //    nmcod.ShowEdit(this.FindForm(), this._NuclearMedicine);
        //}
        let a = 1;
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        //let radioPharmaceuticalMaterialList: Array<Guid> = new Array<Guid>();
        //let radioPharmaceutical: boolean = false;
        //for (let radyofarmasotikDirectPurchaseGrid of this._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids) {
        //    radioPharmaceuticalMaterialList.push(radyofarmasotikDirectPurchaseGrid.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial.ObjectID);
        //}
        //for (let nuclearMedicineTest of this._NuclearMedicine.NuclearMedicineTests) {
        //    if (nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials !== null && nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials.length > 0) {
        //        for (let nuclearMedicineGridPharmDefinition of nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials) {
        //            if (nuclearMedicineGridPharmDefinition.RadioPharmaCeuticalMaterial !== null && !radioPharmaceuticalMaterialList.Contains(nuclearMedicineGridPharmDefinition.RadioPharmaCeuticalMaterial.ObjectID))
        //                radioPharmaceutical = true;
        //        }
        //    }
        //}
        //if (radioPharmaceutical && (await SystemParameterService.GetParameterValue('ISRADYOFARMASOTIKMATERIALCONTROL', 'TRUE')) === 'TRUE')
        //    throw new Exception('Yapılacak Nükleer Tıp işlemi için doğrudan temin ile alınan malzemeler eksik seçildi ! ');
        //if (transDef !== null) {
        //    if (transDef.ToStateDefID === NuclearMedicine.NuclearMedicineStates.Reported) {
        //        for (let sdg of this._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids) {
        //            let titubbPrice: SubActionMatPricingDet = new SubActionMatPricingDet(this._NuclearMedicine.ObjectContext);
        //            titubbPrice.PatientPrice = 0;
        //            titubbPrice.SubActionMaterial = sdg;
        //            if (sdg.DPADetailFirmPriceOffer !== null && sdg.DPADetailFirmPriceOffer.OfferedSUTCode !== null) {
        //                titubbPrice.ExternalCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode;
        //                titubbPrice.Description = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTName;
        //                titubbPrice.PayerPrice = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTPrice;
        //            }
        //            //                else
        //            //                {
        //            //                    titubbPrice.ExternalCode = "KODSUZ";
        //            //                    titubbPrice.Description = productDefinition.Name;
        //            //                    titubbPrice.PayerPrice = 0;
        //            //                }
        //            titubbPrice.ProductDefinition = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product;
        //        }
        //        for (let rdg of this._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids) {
        //            let titubbPrice: SubActionMatPricingDet = new SubActionMatPricingDet(this._NuclearMedicine.ObjectContext);
        //            titubbPrice.PatientPrice = 0;
        //            titubbPrice.SubActionMaterial = rdg;
        //            if (rdg.DPADetailFirmPriceOffer !== null && rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail !== null && rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode !== null && rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial !== null) {
        //                titubbPrice.ExternalCode = rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.SUTCode;
        //                titubbPrice.Description = rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial.Name;
        //                titubbPrice.PayerPrice = 0;
        //            }
        //        }
        //    }
        //}
        //let malzemeObjectID: Guid = new Guid((await SystemParameterService.GetParameterValue('22F_MALZEMEOBJECTID', Guid.Empty.toString())));
        //for (let sdg of this._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids) {
        //    sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
        //    sdg.Material = <Material>this._NuclearMedicine.ObjectContext.GetObject(malzemeObjectID, 'MATERIAL');
        //    sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product !== null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
        //    sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
        //}
        //for (let rdg of this._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids) {
        //    rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
        //    rdg.Material = <Material>this._NuclearMedicine.ObjectContext.GetObject(malzemeObjectID, 'MATERIAL');
        //    // rdg.UBBCode =  rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode != null ?  rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.ProductNumber : null;
        //    rdg.Amount = rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
        //}
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        this.AddHelpMenu();

    }
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let radiologyHistory = new DynamicSidebarMenuItem();
        radiologyHistory.key = 'radiologyHistory';
        radiologyHistory.icon = 'glyphicon glyphicon-cd';
        radiologyHistory.label = 'Radyoloji Sonuçları';
        radiologyHistory.componentInstance = this.helpMenuService;
        radiologyHistory.clickFunction = this.helpMenuService.openRadiologyHistory;
        radiologyHistory.parameterFunctionInstance = this;
        radiologyHistory.getParamsFunction = this.getClickFunctionParams;
        radiologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', radiologyHistory);

        let pathologyHistory = new DynamicSidebarMenuItem();
        pathologyHistory.key = 'pathologyHistory';
        pathologyHistory.icon = 'fas fa-notes-medical';
        pathologyHistory.label = 'Patoloji Sonuçları';
        pathologyHistory.componentInstance = this.helpMenuService;
        pathologyHistory.clickFunction = this.helpMenuService.openPathologyHistory;
        pathologyHistory.parameterFunctionInstance = this;
        pathologyHistory.getParamsFunction = this.getClickFunctionParams;
        pathologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', pathologyHistory);

        let testHistory = new DynamicSidebarMenuItem();
        testHistory.key = 'testHistory';
        testHistory.icon = 'fa fa-flask';
        testHistory.label = 'Laboratuvar Sonuçları';
        testHistory.componentInstance = this.helpMenuService;
        testHistory.clickFunction = this.helpMenuService.openTestHistory;
        testHistory.parameterFunctionInstance = this;
        testHistory.getParamsFunction = this.getClickFunctionParams;
        testHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', testHistory);

    }

    public RemoveMenuFromHelpMenu(): void {

        this.sideBarMenuService.removeMenu('radiologyHistory');
        this.sideBarMenuService.removeMenu('pathologyHistory');
        this.sideBarMenuService.removeMenu('testHistory');
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null) {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("NUCLEARMEDICINE", this.nuclearMedicineApproveFormViewModel._NuclearMedicine.ObjectID, null);

        }
        super.AfterContextSavedScript(transDef);
        await this.load(NuclearMedicineApproveFormViewModel);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new NuclearMedicine();
        this.nuclearMedicineApproveFormViewModel = new NuclearMedicineApproveFormViewModel();
        this._ViewModel = this.nuclearMedicineApproveFormViewModel;
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine = this._TTObject as NuclearMedicine;
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.NucMedTreatmentMats = new Array<NucMedTreatmentMat>();
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.RadPharmMaterials = new Array<NucMedRadPharmMatGrid>();
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids = new Array<SurgeryDirectPurchaseGrid>();
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids = new Array<RadyofarmasotikDirectPurchaseGrid>();
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.DirectPurchaseGrids = new Array<DirectPurchaseGrid>();
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.ResponsibleAcademicStaff = new ResUser();
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.Episode = new Episode();
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.Episode.Patient = new Patient();
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.RequestDoctor = new ResUser();
        this.nuclearMedicineApproveFormViewModel._NuclearMedicine.ResponsibleDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.nuclearMedicineApproveFormViewModel = this._ViewModel as NuclearMedicineApproveFormViewModel;
        that._TTObject = this.nuclearMedicineApproveFormViewModel._NuclearMedicine;
        if (this.nuclearMedicineApproveFormViewModel == null)
            this.nuclearMedicineApproveFormViewModel = new NuclearMedicineApproveFormViewModel();
        if (this.nuclearMedicineApproveFormViewModel._NuclearMedicine == null)
            this.nuclearMedicineApproveFormViewModel._NuclearMedicine = new NuclearMedicine();
        that.nuclearMedicineApproveFormViewModel._NuclearMedicine.NucMedTreatmentMats = that.nuclearMedicineApproveFormViewModel.GridNuclearMedicineMaterialGridList;
        for (let detailItem of that.nuclearMedicineApproveFormViewModel.GridNuclearMedicineMaterialGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineApproveFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let malzemeTuruObjectID = detailItem["MalzemeTuru"];
            if (malzemeTuruObjectID != null && (typeof malzemeTuruObjectID === "string")) {
                let malzemeTuru = that.nuclearMedicineApproveFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
                if (malzemeTuru) {
                    detailItem.MalzemeTuru = malzemeTuru;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
                let ozelDurum = that.nuclearMedicineApproveFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        that.nuclearMedicineApproveFormViewModel._NuclearMedicine.RadPharmMaterials = that.nuclearMedicineApproveFormViewModel.ttgrid2GridList;
        for (let detailItem of that.nuclearMedicineApproveFormViewModel.ttgrid2GridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineApproveFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let unitObjectID = detailItem["Unit"];
            if (unitObjectID != null && (typeof unitObjectID === "string")) {
                let unit = that.nuclearMedicineApproveFormViewModel.RadioPharmaceuticalUnitDefinitions.find(o => o.ObjectID.toString() === unitObjectID.toString());
                if (unit) {
                    detailItem.Unit = unit;
                }
            }
        }
        that.nuclearMedicineApproveFormViewModel._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids = that.nuclearMedicineApproveFormViewModel.SurgeryDirectPurchaseGridsGridList;
        for (let detailItem of that.nuclearMedicineApproveFormViewModel.SurgeryDirectPurchaseGridsGridList) {
            let dPADetailFirmPriceOfferObjectID = detailItem["DPADetailFirmPriceOffer"];
            if (dPADetailFirmPriceOfferObjectID != null && (typeof dPADetailFirmPriceOfferObjectID === "string")) {
                let dPADetailFirmPriceOffer = that.nuclearMedicineApproveFormViewModel.DPADetailFirmPriceOffers.find(o => o.ObjectID.toString() === dPADetailFirmPriceOfferObjectID.toString());
                if (dPADetailFirmPriceOffer) {
                    detailItem.DPADetailFirmPriceOffer = dPADetailFirmPriceOffer;
                }
                if (dPADetailFirmPriceOffer != null) {
                    let offeredUBBObjectID = dPADetailFirmPriceOffer["OfferedUBB"];
                    if (offeredUBBObjectID != null && (typeof offeredUBBObjectID === "string")) {
                        let offeredUBB = that.nuclearMedicineApproveFormViewModel.ProductDefinitions.find(o => o.ObjectID.toString() === offeredUBBObjectID.toString());
                        if (offeredUBB) {
                            dPADetailFirmPriceOffer.OfferedUBB = offeredUBB;
                        }
                    }
                }
                if (dPADetailFirmPriceOffer != null) {
                    let directPurchaseActionDetailObjectID = dPADetailFirmPriceOffer["DirectPurchaseActionDetail"];
                    if (directPurchaseActionDetailObjectID != null && (typeof directPurchaseActionDetailObjectID === "string")) {
                        let directPurchaseActionDetail = that.nuclearMedicineApproveFormViewModel.DirectPurchaseActionDetails.find(o => o.ObjectID.toString() === directPurchaseActionDetailObjectID.toString());
                        if (directPurchaseActionDetail) {
                            dPADetailFirmPriceOffer.DirectPurchaseActionDetail = directPurchaseActionDetail;
                        }
                    }
                }
            }
        }
        that.nuclearMedicineApproveFormViewModel._NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids = that.nuclearMedicineApproveFormViewModel.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList;
        for (let detailItem of that.nuclearMedicineApproveFormViewModel.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsGridList) {
            let dPADetailFirmPriceOfferObjectID = detailItem["DPADetailFirmPriceOffer"];
            if (dPADetailFirmPriceOfferObjectID != null && (typeof dPADetailFirmPriceOfferObjectID === "string")) {
                let dPADetailFirmPriceOffer = that.nuclearMedicineApproveFormViewModel.DPADetailFirmPriceOffers.find(o => o.ObjectID.toString() === dPADetailFirmPriceOfferObjectID.toString());
                if (dPADetailFirmPriceOffer) {
                    detailItem.DPADetailFirmPriceOffer = dPADetailFirmPriceOffer;
                }
            }
        }

        that.nuclearMedicineApproveFormViewModel._NuclearMedicine.DirectPurchaseGrids = that.nuclearMedicineApproveFormViewModel.DirectPurchaseGridsGridList;
        for (let detailItem of that.nuclearMedicineApproveFormViewModel.DirectPurchaseGridsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.nuclearMedicineApproveFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }

        let responsibleAcademicStaffObjectID = that.nuclearMedicineApproveFormViewModel._NuclearMedicine["ResponsibleAcademicStaff"];
        if (responsibleAcademicStaffObjectID != null && (typeof responsibleAcademicStaffObjectID === "string")) {
            let responsibleAcademicStaff = that.nuclearMedicineApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleAcademicStaffObjectID.toString());
            if (responsibleAcademicStaff) {
                that.nuclearMedicineApproveFormViewModel._NuclearMedicine.ResponsibleAcademicStaff = responsibleAcademicStaff;
            }
        }
        let episodeObjectID = that.nuclearMedicineApproveFormViewModel._NuclearMedicine["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.nuclearMedicineApproveFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.nuclearMedicineApproveFormViewModel._NuclearMedicine.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.nuclearMedicineApproveFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.nuclearMedicineApproveFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.nuclearMedicineApproveFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.nuclearMedicineApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                    let ozelDurumObjectID = detailItem["OzelDurum"];
                    if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
                        let ozelDurum = that.nuclearMedicineApproveFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                        if (ozelDurum) {
                            detailItem.OzelDurum = ozelDurum;
                        }
                    }
                }
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === "string")) {
                    let patient = that.nuclearMedicineApproveFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let requestDoctorObjectID = that.nuclearMedicineApproveFormViewModel._NuclearMedicine["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === "string")) {
            let requestDoctor = that.nuclearMedicineApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
            if (requestDoctor) {
                that.nuclearMedicineApproveFormViewModel._NuclearMedicine.RequestDoctor = requestDoctor;
            }
        }
        let masterResourceID = that.nuclearMedicineApproveFormViewModel._NuclearMedicine["MasterResource"];
       
        that.RESPONSIBLEDOCTOR.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + masterResourceID.toString() + '\'';



        let responsibleDoctorObjectID = that.nuclearMedicineApproveFormViewModel._NuclearMedicine["ResponsibleDoctor"];
        if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === "string")) {
            let responsibleDoctor = that.nuclearMedicineApproveFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
            if (responsibleDoctor) {
                that.nuclearMedicineApproveFormViewModel._NuclearMedicine.ResponsibleDoctor = responsibleDoctor;
            }
        }

    }

    //async ngOnInit() {
    //    await this.load();
    //}

    async ngOnInit() {
        let that = this;
        await this.load(NuclearMedicineApproveFormViewModel);
  

        that.TreatmentMaterialTypeName1 = 'NUCMEDTREATMENTMAT';
        that.TreatmentMaterialTypeName2 = 'NUCMEDRADPHARMMATGRID';

        that.ReadOnly1 = true;
        that.ReadOnly2 = true;
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ActionDate != event) {
                this._NuclearMedicine.ActionDate = event;
            }
        }
    }

    public onInjectionDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.InjectionDate != event) {
                this._NuclearMedicine.InjectionDate = event;
            }
        }
    }

    public onIsEmergencyChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.IsEmergency != event) {
                this._NuclearMedicine.IsEmergency = event;
            }
        }
    }

    public onPATIENTPHONENUMBERChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientPhoneNumber != event) {
                this._NuclearMedicine.PatientPhoneNumber = event;
            }
        }
    }

    public onPATIENTWEIGHTChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PatientWeight != event) {
                this._NuclearMedicine.PatientWeight = event;
            }
        }
    }

    public onPatientBirthDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null &&
                this._NuclearMedicine.Episode != null &&
                this._NuclearMedicine.Episode.Patient != null && this._NuclearMedicine.Episode.Patient.BirthDate != event) {
                this._NuclearMedicine.Episode.Patient.BirthDate = event;
            }
        }
    }

    public onPREDIAGNOSISChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PreDiagnosis != event) {
                this._NuclearMedicine.PreDiagnosis = event;
            }
        }
    }

    public onProcedureDateChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProcedureDate != event) {
                this._NuclearMedicine.ProcedureDate = event;
            }
        }
    }

    public onRADIOPHARMACYDESCChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RadioPharmacyDescription != event) {
                this._NuclearMedicine.RadioPharmacyDescription = event;
            }
        }
    }

    public onREQUESTDOCTORChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.RequestDoctor != event) {
                this._NuclearMedicine.RequestDoctor = event;
            }
        }
    }

    public onREQUESTDOCTORPHONEChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null &&
                this._NuclearMedicine.RequestDoctor != null && this._NuclearMedicine.RequestDoctor.PhoneNumber != event) {
                this._NuclearMedicine.RequestDoctor.PhoneNumber = event;
            }
        }
    }

    public onRESPONSIBLEDOCTORChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ResponsibleDoctor != event) {
                this._NuclearMedicine.ResponsibleDoctor = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.PharmaceuticalPrepDate != event) {
                this._NuclearMedicine.PharmaceuticalPrepDate = event;
            }
        }
    }

    public onTTListBoxChanged(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ResponsibleAcademicStaff != event) {
                this._NuclearMedicine.ResponsibleAcademicStaff = event;
            }
        }
    }

    public onttrichtextboxcontrol1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.Report != event) {
                this._NuclearMedicine.Report = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.NucMedDoctorNote != event) {
                this._NuclearMedicine.NucMedDoctorNote = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.ProtocolNo != event) {
                this._NuclearMedicine.ProtocolNo = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._NuclearMedicine != null && this._NuclearMedicine.TestSequenceNo != event) {
                this._NuclearMedicine.TestSequenceNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.PATIENTPHONENUMBER, "Text", this.__ttObject, "PatientPhoneNumber");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.InjectionDate, "Value", this.__ttObject, "InjectionDate");
        redirectProperty(this.ProcedureDate, "Value", this.__ttObject, "ProcedureDate");
        redirectProperty(this.PatientBirthDate, "Value", this.__ttObject, "Episode.Patient.BirthDate");
        redirectProperty(this.PATIENTWEIGHT, "Text", this.__ttObject, "PatientWeight");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "TestSequenceNo");
        redirectProperty(this.REQUESTDOCTORPHONE, "Text", this.__ttObject, "RequestDoctor.PhoneNumber");
        redirectProperty(this.IsEmergency, "Value", this.__ttObject, "IsEmergency");
        redirectProperty(this.PREDIAGNOSIS, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.RADIOPHARMACYDESC, "Text", this.__ttObject, "RadioPharmacyDescription");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "NucMedDoctorNote");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "Report");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "PharmaceuticalPrepDate");
    }

    public initFormControls(): void {
        this.TABNuclearMedicine = new TTVisual.TTTabControl();
        this.TABNuclearMedicine.Name = "TABNuclearMedicine";
        this.TABNuclearMedicine.TabIndex = 1;

        this.TabPageMaterial = new TTVisual.TTTabPage();
        this.TabPageMaterial.DisplayIndex = 0;
        this.TabPageMaterial.BackColor = "#FFFFFF";
        this.TabPageMaterial.TabIndex = 1;
        this.TabPageMaterial.Text = "Nükleer Tıp Sarf";
        this.TabPageMaterial.Name = "TabPageMaterial";

        this.GridNuclearMedicineMaterial = new TTVisual.TTGrid();
        this.GridNuclearMedicineMaterial.ReadOnly = true;
        this.GridNuclearMedicineMaterial.Name = "GridNuclearMedicineMaterial";
        this.GridNuclearMedicineMaterial.TabIndex = 1;

        this.MaterialActionDate = new TTVisual.TTDateTimePickerColumn();
        this.MaterialActionDate.Format = DateTimePickerFormat.Custom;
        this.MaterialActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.MaterialActionDate.DataMember = "ActionDate";
        this.MaterialActionDate.Required = true;
        this.MaterialActionDate.DisplayIndex = 0;
        this.MaterialActionDate.HeaderText = "Tarih/Saat";
        this.MaterialActionDate.Name = "MaterialActionDate";
        this.MaterialActionDate.Width = 180;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = "Sarf Edilen Malzemeler";
        this.Material.Name = "Material";
        this.Material.Width = 320;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 2;
        this.Amount.HeaderText = "Miktar";
        this.Amount.Name = "Amount";
        this.Amount.Width = 80;

        this.Note = new TTVisual.TTTextBoxColumn();
        this.Note.DataMember = "Note";
        this.Note.DisplayIndex = 3;
        this.Note.HeaderText = "Notlar";
        this.Note.Name = "Note";
        this.Note.Width = 220;

        this.malzemeSatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.malzemeSatinAlisTarihi.CustomFormat = "dd/MM/yyyy HH:mm";
        this.malzemeSatinAlisTarihi.DataMember = "MalzemeSatinAlisTarihi";
        this.malzemeSatinAlisTarihi.DisplayIndex = 4;
        this.malzemeSatinAlisTarihi.HeaderText = "Satın Alış Tarihi";
        this.malzemeSatinAlisTarihi.Name = "malzemeSatinAlisTarihi";
        this.malzemeSatinAlisTarihi.Visible = false;
        this.malzemeSatinAlisTarihi.Width = 100;

        this.kodsuzMalzemeFiyatı = new TTVisual.TTTextBoxColumn();
        this.kodsuzMalzemeFiyatı.DataMember = "KodsuzMalzemeFiyati";
        this.kodsuzMalzemeFiyatı.DisplayIndex = 5;
        this.kodsuzMalzemeFiyatı.HeaderText = "Kodsuz Malzeme Fiyatı";
        this.kodsuzMalzemeFiyatı.Name = "kodsuzMalzemeFiyatı";
        this.kodsuzMalzemeFiyatı.Visible = false;
        this.kodsuzMalzemeFiyatı.Width = 100;

        this.malzemeTuru = new TTVisual.TTListBoxColumn();
        this.malzemeTuru.ListDefName = "MalzemeTuruListDefinition";
        this.malzemeTuru.DataMember = "MalzemeTuru";
        this.malzemeTuru.DisplayIndex = 6;
        this.malzemeTuru.HeaderText = "Malzeme Türü";
        this.malzemeTuru.Name = "malzemeTuru";
        this.malzemeTuru.Visible = false;
        this.malzemeTuru.Width = 100;

        this.kdv = new TTVisual.TTTextBoxColumn();
        this.kdv.DataMember = "Kdv";
        this.kdv.DisplayIndex = 7;
        this.kdv.HeaderText = "KDV";
        this.kdv.Name = "kdv";
        this.kdv.Visible = false;
        this.kdv.Width = 100;

        this.malzemeBrans = new TTVisual.TTTextBoxColumn();
        this.malzemeBrans.DataMember = "MalzemeBrans";
        this.malzemeBrans.DisplayIndex = 8;
        this.malzemeBrans.HeaderText = "Malzemenin Branşı";
        this.malzemeBrans.Name = "malzemeBrans";
        this.malzemeBrans.Visible = false;
        this.malzemeBrans.Width = 100;

        this.malzemeOzelDurum = new TTVisual.TTListBoxColumn();
        this.malzemeOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.malzemeOzelDurum.DataMember = "OzelDurum";
        this.malzemeOzelDurum.DisplayIndex = 9;
        this.malzemeOzelDurum.HeaderText = "Özel Durum";
        this.malzemeOzelDurum.Name = "malzemeOzelDurum";
        this.malzemeOzelDurum.Visible = false;
        this.malzemeOzelDurum.Width = 100;

        this.malzemeCokluOzelDurum = new TTVisual.TTButtonColumn();
        this.malzemeCokluOzelDurum.DisplayIndex = 10;
        this.malzemeCokluOzelDurum.HeaderText = "Çoklu Özel Durum";
        this.malzemeCokluOzelDurum.Name = "malzemeCokluOzelDurum";
        this.malzemeCokluOzelDurum.Visible = false;
        this.malzemeCokluOzelDurum.Width = 100;

        this.barkod = new TTVisual.TTTextBoxColumn();
        this.barkod.DataMember = "Barcode";
        this.barkod.DisplayIndex = 11;
        this.barkod.HeaderText = "Barkod / UBB";
        this.barkod.Name = "barkod";
        this.barkod.Width = 100;

        this.RadPharmMatTab = new TTVisual.TTTabPage();
        this.RadPharmMatTab.DisplayIndex = 1;
        this.RadPharmMatTab.TabIndex = 2;
        this.RadPharmMatTab.Text = "Radyofarmasötik Madde Sarf";
        this.RadPharmMatTab.Name = "RadPharmMatTab";

        this.ttgrid2 = new TTVisual.TTGrid();
        this.ttgrid2.Name = "ttgrid2";
        this.ttgrid2.TabIndex = 1;

        this.ttdatetimepickercolumn1 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepickercolumn1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepickercolumn1.DataMember = "ActionDate";
        this.ttdatetimepickercolumn1.DisplayIndex = 0;
        this.ttdatetimepickercolumn1.HeaderText = "Tarih/Saat";
        this.ttdatetimepickercolumn1.Name = "ttdatetimepickercolumn1";
        this.ttdatetimepickercolumn1.ReadOnly = true;
        this.ttdatetimepickercolumn1.Width = 140;

        this.ttlistboxcolumn1 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn1.ListDefName = "TreatmentMaterialListDefinition";
        this.ttlistboxcolumn1.DataMember = "Material";
        this.ttlistboxcolumn1.DisplayIndex = 1;
        this.ttlistboxcolumn1.HeaderText = "Sarf Edilen Malzemeler";
        this.ttlistboxcolumn1.Name = "ttlistboxcolumn1";
        this.ttlistboxcolumn1.ReadOnly = true;
        this.ttlistboxcolumn1.Width = 320;

        this.IsInjection = new TTVisual.TTCheckBoxColumn();
        this.IsInjection.DataMember = "IsInjection";
        this.IsInjection.DisplayIndex = 2;
        this.IsInjection.HeaderText = "Enjeksiyon";
        this.IsInjection.Name = "IsInjection";
        this.IsInjection.ReadOnly = true;
        this.IsInjection.Width = 60;

        this.tttextboxcolumn1 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn1.DataMember = "Note";
        this.tttextboxcolumn1.DisplayIndex = 3;
        this.tttextboxcolumn1.HeaderText = "Erişkin Dozu";
        this.tttextboxcolumn1.Name = "tttextboxcolumn1";
        this.tttextboxcolumn1.ReadOnly = true;
        this.tttextboxcolumn1.Width = 100;

        this.tttextboxcolumn2 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn2.DataMember = "Amount";
        this.tttextboxcolumn2.DisplayIndex = 4;
        this.tttextboxcolumn2.HeaderText = "Verilen Aktivite(mCi)";
        this.tttextboxcolumn2.Name = "tttextboxcolumn2";
        this.tttextboxcolumn2.ReadOnly = true;
        this.tttextboxcolumn2.Width = 100;

        this.Unit = new TTVisual.TTListBoxColumn();
        this.Unit.ListDefName = "RadioPharmaceuticalUnitListDefinition";
        this.Unit.DataMember = "Unit";
        this.Unit.DisplayIndex = 5;
        this.Unit.HeaderText = "Birim";
        this.Unit.Name = "Unit";
        this.Unit.ReadOnly = true;
        this.Unit.Width = 80;

        this.tttabpage4 = new TTVisual.TTTabPage();
        this.tttabpage4.DisplayIndex = 2;
        this.tttabpage4.TabIndex = 3;
        this.tttabpage4.Text = "Doğrudan Teminle Alınan Malzemeler";
        this.tttabpage4.Name = "tttabpage4";

        this.SurgeryDirectPurchaseGrids = new TTVisual.TTGrid();
        this.SurgeryDirectPurchaseGrids.AllowUserToDeleteRows = false;
        this.SurgeryDirectPurchaseGrids.ReadOnly = true;
        this.SurgeryDirectPurchaseGrids.Name = "SurgeryDirectPurchaseGrids";
        this.SurgeryDirectPurchaseGrids.TabIndex = 0;

        this.DPADetailFirmPriceOffer = new TTVisual.TTListBoxColumn();
        this.DPADetailFirmPriceOffer.ListDefName = "DirectPurchaseActionDetailList";
        this.DPADetailFirmPriceOffer.DataMember = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOffer.DisplayIndex = 0;
        this.DPADetailFirmPriceOffer.HeaderText = "22F Malzeme";
        this.DPADetailFirmPriceOffer.Name = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOffer.Width = 300;

        this.txtBarcode = new TTVisual.TTTextBoxColumn();
        this.txtBarcode.DataMember = "ProductNumber";
        this.txtBarcode.DisplayIndex = 1;
        this.txtBarcode.HeaderText = "Barcod";
        this.txtBarcode.Name = "txtBarcode";
        this.txtBarcode.ReadOnly = true;
        this.txtBarcode.Width = 100;

        this.txtKesinlesenMiktar = new TTVisual.TTTextBoxColumn();
        this.txtKesinlesenMiktar.DataMember = "CertainAmount";
        this.txtKesinlesenMiktar.DisplayIndex = 2;
        this.txtKesinlesenMiktar.HeaderText = "Kesinleşen Miktar";
        this.txtKesinlesenMiktar.Name = "txtKesinlesenMiktar";
        this.txtKesinlesenMiktar.ReadOnly = true;
        this.txtKesinlesenMiktar.Width = 100;

        this.tttabpage6 = new TTVisual.TTTabPage();
        this.tttabpage6.DisplayIndex = 3;
        this.tttabpage6.TabIndex = 4;
        this.tttabpage6.Text = "Doğrudan Teminle Alınan Radyofarmasötik Malzemeler";
        this.tttabpage6.Name = "tttabpage6";

        this.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids = new TTVisual.TTGrid();
        this.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.Name = "NuclearMedicine_RadyofarmasotikDirectPurchaseGrids";
        this.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.TabIndex = 0;

        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid = new TTVisual.TTListBoxColumn();
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.ListDefName = "RadyofarmasotikDPADetaillList";
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.DataMember = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.DisplayIndex = 0;
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.HeaderText = "22F Radyofarmasotik Malzeme";
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.Name = "DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid";
        this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid.Width = 400;

        this.tttabpage5 = new TTVisual.TTTabPage();
        this.tttabpage5.DisplayIndex = 4;
        this.tttabpage5.TabIndex = 5;
        this.tttabpage5.Text = "Doğrudan Tedarik Edilen Malzemeler";
        this.tttabpage5.Name = "tttabpage5";

        this.DirectPurchaseGrids = new TTVisual.TTGrid();
        this.DirectPurchaseGrids.Name = "DirectPurchaseGrids";
        this.DirectPurchaseGrids.TabIndex = 0;
        this.DirectPurchaseGrids.ShowFilterCombo = true;
        this.DirectPurchaseGrids.FilterColumnName = "MaterialDirectPurchaseGrid";
        this.DirectPurchaseGrids.FilterLabel = i18n("M18545", "Malzeme");
        this.DirectPurchaseGrids.Filter = { ListDefName: "MaterialListDefinition" };
        this.DirectPurchaseGrids.AllowUserToAddRows = false;
        this.DirectPurchaseGrids.AllowUserToDeleteRows = false;
        this.DirectPurchaseGrids.DeleteButtonWidth = "5%";
        this.DirectPurchaseGrids.ShowTotalNumberOfRows = false;
        this.DirectPurchaseGrids.IsFilterLabelSingleLine = false;
        this.DirectPurchaseGrids.Height = "300";
        this.DirectPurchaseGrids.ReadOnly = true;
        this.DirectPurchaseGrids.Enabled = true;

        this.MaterialDirectPurchaseGrid = new TTVisual.TTListBoxColumn();
        this.MaterialDirectPurchaseGrid.ListDefName = "MaterialListDefinition";
        this.MaterialDirectPurchaseGrid.DataMember = "Material";
        this.MaterialDirectPurchaseGrid.DisplayIndex = 0;
        this.MaterialDirectPurchaseGrid.HeaderText = "Malzeme";
        this.MaterialDirectPurchaseGrid.Name = "MaterialDirectPurchaseGrid";
        this.MaterialDirectPurchaseGrid.Width = 300;
        this.MaterialDirectPurchaseGrid.AutoCompleteDialogWidth = '75%';
        this.MaterialDirectPurchaseGrid.AutoCompleteDialogHeight = '50%';

        this.AmountDirectPurchaseGrid = new TTVisual.TTTextBoxColumn();
        this.AmountDirectPurchaseGrid.DataMember = "Amount";
        this.AmountDirectPurchaseGrid.DisplayIndex = 1;
        this.AmountDirectPurchaseGrid.HeaderText = "Miktar";
        this.AmountDirectPurchaseGrid.Name = "AmountDirectPurchaseGrid";
        this.AmountDirectPurchaseGrid.Width = 80;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.BackColor = "#DCDCDC";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.ttlabel17 = new TTVisual.TTLabel();
        this.ttlabel17.Text = "Sorumlu Öğretim Üyesi";
        this.ttlabel17.Name = "ttlabel17";
        this.ttlabel17.TabIndex = 82;

        this.TTListBox = new TTVisual.TTObjectListBox();
        this.TTListBox.ReadOnly = true;
        this.TTListBox.ListDefName = "DoctorListDefinition";
        this.TTListBox.Name = "TTListBox";
        this.TTListBox.TabIndex = 19;

        //this.cmdReport = new TTVisual.TTButton();
        //this.cmdReport.Text = "İmaj Görüntüle";
        //this.cmdReport.Name = "cmdReport";
        //this.cmdReport.TabIndex = 20;

        this.ttlabel16 = new TTVisual.TTLabel();
        this.ttlabel16.Text = "Test Sıra No";
        this.ttlabel16.Name = "ttlabel16";
        this.ttlabel16.TabIndex = 15;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.BackColor = "#F0F0F0";
        this.ttdatetimepicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepicker1.Enabled = false;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 17;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.BackColor = "#F0F0F0";
        this.tttextbox3.ReadOnly = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 10;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Farmasötik Hazırla Tarihi";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 2;

        this.nucMedSelectedTesttxt = new TTVisual.TTTextBox();
        this.nucMedSelectedTesttxt.BackColor = "#F0F0F0";
        this.nucMedSelectedTesttxt.ReadOnly = true;
        this.nucMedSelectedTesttxt.Name = "nucMedSelectedTesttxt";
        this.nucMedSelectedTesttxt.TabIndex = 11;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Tetkik";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 17;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "AdmissionTypeListDef";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.RowHeadersVisible = false;
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 15;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = "Özgeçmiş";
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 60;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisDefinitionList";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = "Vaka Tanıları";
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 330;

        this.EpisodeDiagnoseType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnoseType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnoseType.DataMember = "DiagnosisType";
        this.EpisodeDiagnoseType.DisplayIndex = 2;
        this.EpisodeDiagnoseType.HeaderText = "Tanı Tipi";
        this.EpisodeDiagnoseType.Name = "EpisodeDiagnoseType";
        this.EpisodeDiagnoseType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = "Ana Tanı";
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 60;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = "Tanı Koyan";
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = "Tanı Giriş Tarihi";
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = "Giriş Yapılan İşlem";
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.taniOzelDurum = new TTVisual.TTListBoxColumn();
        this.taniOzelDurum.ListDefName = "OzelDurumListDefinition";
        this.taniOzelDurum.DataMember = "OzelDurum";
        this.taniOzelDurum.DisplayIndex = 7;
        this.taniOzelDurum.HeaderText = "Özel Durum";
        this.taniOzelDurum.Name = "taniOzelDurum";
        this.taniOzelDurum.Width = 180;

        this.taniCokluOzelDurum = new TTVisual.TTButtonColumn();
        this.taniCokluOzelDurum.DisplayIndex = 8;
        this.taniCokluOzelDurum.HeaderText = "Çoklu Özel Durum";
        this.taniCokluOzelDurum.Name = "taniCokluOzelDurum";
        this.taniCokluOzelDurum.Width = 100;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 16;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = "Kısa Anamnez ve Klinik Bulgular";
        this.tttabpage1.Name = "tttabpage1";

        this.PREDIAGNOSIS = new TTVisual.TTTextBox();
        this.PREDIAGNOSIS.Multiline = true;
        this.PREDIAGNOSIS.BackColor = "#F0F0F0";
        this.PREDIAGNOSIS.ReadOnly = true;
        this.PREDIAGNOSIS.Name = "PREDIAGNOSIS";
        this.PREDIAGNOSIS.TabIndex = 50;
        this.PREDIAGNOSIS.Height = "150px";

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = "N.T. Tabip Notu";
        this.tttabpage2.Name = "tttabpage2";

        this.RADIOPHARMACYDESC = new TTVisual.TTTextBox();
        this.RADIOPHARMACYDESC.Multiline = true;
        this.RADIOPHARMACYDESC.BackColor = "#F0F0F0";
        this.RADIOPHARMACYDESC.ReadOnly = true;
        this.RADIOPHARMACYDESC.Name = "RADIOPHARMACYDESC";
        this.RADIOPHARMACYDESC.TabIndex = 19;
        this.RADIOPHARMACYDESC.Height = "150px";

        this.NUCMEDDOCTORNOTE = new TTVisual.TTTabPage();
        this.NUCMEDDOCTORNOTE.DisplayIndex = 2;
        this.NUCMEDDOCTORNOTE.BackColor = "#FFFFFF";
        this.NUCMEDDOCTORNOTE.TabIndex = 3;
        this.NUCMEDDOCTORNOTE.Text = "Teknisyen Notu";
        this.NUCMEDDOCTORNOTE.Name = "NUCMEDDOCTORNOTE";

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 0;
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Height = "150px";

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 3;
        this.tttabpage3.BackColor = "#FFFFFF";
        this.tttabpage3.TabIndex = 2;
        this.tttabpage3.Text = "Rapor";
        this.tttabpage3.Name = "tttabpage3";

        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.DisplayText = "Rapor";
        this.ttrichtextboxcontrol1.BackColor = "#DCDCDC";
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 73;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.BackColor = "#F0F0F0";
        this.tttextbox2.ReadOnly = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 4;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = "Protokol No";
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 8;

        this.PatientBirthDate = new TTVisual.TTDateTimePicker();
        this.PatientBirthDate.BackColor = "#F0F0F0";
        this.PatientBirthDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.PatientBirthDate.Format = DateTimePickerFormat.Custom;
        this.PatientBirthDate.Enabled = false;
        this.PatientBirthDate.Name = "PatientBirthDate";
        this.PatientBirthDate.TabIndex = 7;

        this.PatientBirthPlace = new TTVisual.TTTextBox();
        this.PatientBirthPlace.BackColor = "#F0F0F0";
        this.PatientBirthPlace.ReadOnly = true;
        this.PatientBirthPlace.Name = "PatientBirthPlace";
        this.PatientBirthPlace.TabIndex = 8;

        this.IsEmergency = new TTVisual.TTCheckBox();
        this.IsEmergency.Value = false;
        this.IsEmergency.Text = "Acil";
        this.IsEmergency.Enabled = false;
        this.IsEmergency.Name = "IsEmergency";
        this.IsEmergency.TabIndex = 14;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = "Hastanın Doğum Tarihi";
        this.ttlabel14.BackColor = "#DCDCDC";
        this.ttlabel14.ForeColor = "#000000";
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 76;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = "Hastanın Doğum Yeri";
        this.ttlabel13.BackColor = "#DCDCDC";
        this.ttlabel13.ForeColor = "#000000";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 75;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.REQUESTDOCTOR = new TTVisual.TTObjectListBox();
        this.REQUESTDOCTOR.ReadOnly = true;
        this.REQUESTDOCTOR.ListDefName = "DoctorListDefinition";
        this.REQUESTDOCTOR.Name = "REQUESTDOCTOR";
        this.REQUESTDOCTOR.TabIndex = 12;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "İstek Yapan Tabip";
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 10;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "İşlem Zamanı";
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 0;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.REQUESTDOCTORPHONE = new TTVisual.TTTextBox();
        this.REQUESTDOCTORPHONE.BackColor = "#F0F0F0";
        this.REQUESTDOCTORPHONE.ReadOnly = true;
        this.REQUESTDOCTORPHONE.Name = "REQUESTDOCTORPHONE";
        this.REQUESTDOCTORPHONE.TabIndex = 13;

        this.ProcedureDate = new TTVisual.TTDateTimePicker();
        this.ProcedureDate.BackColor = "#F0F0F0";
        this.ProcedureDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ProcedureDate.Format = DateTimePickerFormat.Custom;
        this.ProcedureDate.Enabled = false;
        this.ProcedureDate.Name = "ProcedureDate";
        this.ProcedureDate.TabIndex = 6;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = "İstek Yapan Tabip Telefon";
        this.ttlabel10.BackColor = "#DCDCDC";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 12;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = "Hastanın Telefonu";
        this.ttlabel12.BackColor = "#DCDCDC";
        this.ttlabel12.ForeColor = "#000000";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 8;

        this.PATIENTPHONENUMBER = new TTVisual.TTTextBox();
        this.PATIENTPHONENUMBER.BackColor = "#F0F0F0";
        this.PATIENTPHONENUMBER.ReadOnly = true;
        this.PATIENTPHONENUMBER.Name = "PATIENTPHONENUMBER";
        this.PATIENTPHONENUMBER.TabIndex = 3;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "Hastanın Kilosu";
        this.ttlabel11.BackColor = "#DCDCDC";
        this.ttlabel11.ForeColor = "#000000";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 61;

        this.PATIENTWEIGHT = new TTVisual.TTTextBox();
        this.PATIENTWEIGHT.BackColor = "#F0F0F0";
        this.PATIENTWEIGHT.ReadOnly = true;
        this.PATIENTWEIGHT.Name = "PATIENTWEIGHT";
        this.PATIENTWEIGHT.TabIndex = 9;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Sorumlu Tabip";
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 66;

        this.RESPONSIBLEDOCTOR = new TTVisual.TTObjectListBox();
        this.RESPONSIBLEDOCTOR.ListDefName = "DoctorListDefinition";
        this.RESPONSIBLEDOCTOR.Name = "RESPONSIBLEDOCTOR";
        this.RESPONSIBLEDOCTOR.TabIndex = 18;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Enjeksiyon Zamanı";
        this.ttlabel6.BackColor = "#DCDCDC";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 63;

        this.InjectionDate = new TTVisual.TTDateTimePicker();
        this.InjectionDate.BackColor = "#F0F0F0";
        this.InjectionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.InjectionDate.Format = DateTimePickerFormat.Custom;
        this.InjectionDate.Enabled = false;
        this.InjectionDate.Name = "InjectionDate";
        this.InjectionDate.TabIndex = 5;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Kabul Sebebi";
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 60;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Hasta Grubu";
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 59;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = "Çekim Tarihi ve Saati";
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 48;

        this.GridNuclearMedicineMaterialColumns = [this.MaterialActionDate, this.Material, this.Amount, this.Note, this.malzemeSatinAlisTarihi, this.kodsuzMalzemeFiyatı, this.malzemeTuru, this.kdv, this.malzemeBrans, this.malzemeOzelDurum, this.malzemeCokluOzelDurum, this.barkod];
        this.ttgrid2Columns = [this.ttdatetimepickercolumn1, this.ttlistboxcolumn1, this.IsInjection, this.tttextboxcolumn1, this.tttextboxcolumn2, this.Unit];
        this.SurgeryDirectPurchaseGridsColumns = [this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar];
        this.NuclearMedicine_RadyofarmasotikDirectPurchaseGridsColumns = [this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid];
        this.DirectPurchaseGridsColumns = [this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.taniOzelDurum, this.taniCokluOzelDurum];
        this.TABNuclearMedicine.Controls = [this.TabPageMaterial, this.RadPharmMatTab, this.tttabpage4, this.tttabpage6];
        this.TabPageMaterial.Controls = [this.GridNuclearMedicineMaterial];
        this.RadPharmMatTab.Controls = [this.ttgrid2];
        this.tttabpage4.Controls = [this.SurgeryDirectPurchaseGrids];
        this.tttabpage6.Controls = [this.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids];
        this.tttabpage5.Controls = [this.DirectPurchaseGrids];
        this.ttgroupbox1.Controls = [this.ttlabel17, this.TTListBox, this.ttlabel16, this.ttdatetimepicker1, this.tttextbox3, this.ttlabel5, this.nucMedSelectedTesttxt, this.ttlabel1, this.ReasonForAdmission, this.GridEpisodeDiagnosis, this.tttabcontrol1, this.tttextbox2, this.ttlabel15, this.PatientBirthDate, this.PatientBirthPlace, this.IsEmergency, this.ttlabel14, this.ttlabel13, this.PATIENTGROUPENUM, this.REQUESTDOCTOR, this.ttlabel9, this.ttlabel8, this.ActionDate, this.REQUESTDOCTORPHONE, this.ProcedureDate, this.ttlabel10, this.ttlabel12, this.PATIENTPHONENUMBER, this.ttlabel11, this.PATIENTWEIGHT, this.ttlabel2, this.RESPONSIBLEDOCTOR, this.ttlabel6, this.InjectionDate, this.ttlabel4, this.ttlabel3, this.labelProcessTime];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2, this.NUCMEDDOCTORNOTE, this.tttabpage3];
        this.tttabpage1.Controls = [this.PREDIAGNOSIS];
        this.tttabpage2.Controls = [this.RADIOPHARMACYDESC];
        this.NUCMEDDOCTORNOTE.Controls = [this.tttextbox1];
        this.tttabpage3.Controls = [this.ttrichtextboxcontrol1];
        this.Controls = [this.TABNuclearMedicine, this.TabPageMaterial, this.GridNuclearMedicineMaterial, this.MaterialActionDate, this.Material, this.Amount, this.Note, this.malzemeSatinAlisTarihi, this.kodsuzMalzemeFiyatı, this.malzemeTuru, this.kdv, this.malzemeBrans, this.malzemeOzelDurum, this.malzemeCokluOzelDurum, this.barkod, this.RadPharmMatTab, this.ttgrid2, this.ttdatetimepickercolumn1, this.ttlistboxcolumn1, this.IsInjection, this.tttextboxcolumn1, this.tttextboxcolumn2, this.Unit, this.tttabpage4, this.SurgeryDirectPurchaseGrids, this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar, this.tttabpage6, this.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids, this.DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid, this.tttabpage5, this.DirectPurchaseGrids, this.MaterialDirectPurchaseGrid, this.AmountDirectPurchaseGrid, this.ttgroupbox1, this.ttlabel17, this.TTListBox, this.ttlabel16, this.ttdatetimepicker1, this.tttextbox3, this.ttlabel5, this.nucMedSelectedTesttxt, this.ttlabel1, this.ReasonForAdmission, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnoseType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.taniOzelDurum, this.taniCokluOzelDurum, this.tttabcontrol1, this.tttabpage1, this.PREDIAGNOSIS, this.tttabpage2, this.RADIOPHARMACYDESC, this.NUCMEDDOCTORNOTE, this.tttextbox1, this.tttabpage3, this.ttrichtextboxcontrol1, this.tttextbox2, this.ttlabel15, this.PatientBirthDate, this.PatientBirthPlace, this.IsEmergency, this.ttlabel14, this.ttlabel13, this.PATIENTGROUPENUM, this.REQUESTDOCTOR, this.ttlabel9, this.ttlabel8, this.ActionDate, this.REQUESTDOCTORPHONE, this.ProcedureDate, this.ttlabel10, this.ttlabel12, this.PATIENTPHONENUMBER, this.ttlabel11, this.PATIENTWEIGHT, this.ttlabel2, this.RESPONSIBLEDOCTOR, this.ttlabel6, this.InjectionDate, this.ttlabel4, this.ttlabel3, this.labelProcessTime];

    }


}
