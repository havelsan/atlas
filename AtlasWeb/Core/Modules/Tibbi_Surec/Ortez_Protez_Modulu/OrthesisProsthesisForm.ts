//$A5B9C20F
import { Component, OnInit, NgZone } from '@angular/core';
import { OrthesisProsthesisFormViewModel } from './OrthesisProsthesisFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CodelessMaterialDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { CommonService } from "ObjectClassService/CommonService";
import { DPADetailFirmPriceOffer } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesisProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesisRequestService } from "ObjectClassService/OrthesisProsthesisRequestService";
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryDirectPurchaseGrid } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { OrthesisProsthesis_ReturnDescriptionsGrid } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProthesisRequestTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';


@Component({
    selector: 'OrthesisProsthesisForm',
    templateUrl: './OrthesisProsthesisForm.html',
    providers: [MessageService, AtlasReportService]
})
export class OrthesisProsthesisForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    AnesteziDrTescilNo: TTVisual.ITTListBoxColumn;
    AyniFarkliKesi: TTVisual.ITTListBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    ChiefTechnicianNote: TTVisual.ITTTextBox;
    CodelessDirectPurchase: TTVisual.ITTTabPage;
    CodelessMaterialDirectPurchaseGrids: TTVisual.ITTGrid;
    CokluOzelDurum: TTVisual.ITTButtonColumn;
    DirectPurchaseMaterials: TTVisual.ITTTabPage;
    DPADetailFirmPriceOffer: TTVisual.ITTListBoxColumn;
    DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid: TTVisual.ITTListBoxColumn;
    EntryDate: TTVisual.ITTDateTimePickerColumn;
    Kdv: TTVisual.ITTTextBoxColumn;
    KodsuzMalzemeFiyati: TTVisual.ITTTextBoxColumn;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProcedureSpeciality: TTVisual.ITTLabel;
    labelProcessDate: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    LabelRequestDate: TTVisual.ITTLabel;
    MActionDate: TTVisual.ITTDateTimePickerColumn;
    MalzemeBrans: TTVisual.ITTTextBoxColumn;
    MalzemeSatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    MalzemeTuru: TTVisual.ITTListBoxColumn;
    MAmount: TTVisual.ITTTextBoxColumn;
    MasterResource: TTVisual.ITTObjectListBox;
    MMaterial: TTVisual.ITTListBoxColumn;
    NoteChief: TTVisual.ITTTabPage;
    NotesTab: TTVisual.ITTTabControl;
    NoteTechnicanTab: TTVisual.ITTTabPage;
    NoteWarranty: TTVisual.ITTTabPage;
    OPDirectPurchaseGrid: TTVisual.ITTGrid;
    OrtesisProtesis: TTVisual.ITTTabPage;
    OrtezProtez_OzelDurum: TTVisual.ITTListBoxColumn;
    OrthesisProsthesisProcedures: TTVisual.ITTGrid;
    OwnerUser: TTVisual.ITTTextBoxColumn;
    PatientGroup: TTVisual.ITTEnumComboBox;
    PatientPays: TTVisual.ITTCheckBoxColumn;
    Price: TTVisual.ITTTextBoxColumn;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ProcedureSpeciality: TTVisual.ITTObjectListBox;
    ProtocolNo: TTVisual.ITTTextBox;
    RaporTakipNo: TTVisual.ITTTextBoxColumn;
    RequestDate: TTVisual.ITTDateTimePicker;
    ReturnDescription: TTVisual.ITTTextBoxColumn;
    ReturnDescriptionGrid: TTVisual.ITTGrid;
    ReturnDescriptionsLabel: TTVisual.ITTLabel;
    SideO: TTVisual.ITTEnumComboBoxColumn;
    SpecificNote: TTVisual.ITTTextBoxColumn;
    TabSubaction: TTVisual.ITTTabControl;
    Technician: TTVisual.ITTListBoxColumn;
    TechnicianNote: TTVisual.ITTTextBox;
    TotalDescription: TTVisual.ITTRichTextBoxControl;
    TreatmentMaterial: TTVisual.ITTTabPage;
    TreatmentMaterials: TTVisual.ITTGrid;
    ttlabel2: TTVisual.ITTLabel;
    ttlistboxcolumn1: TTVisual.ITTListBoxColumn;
    txtBarcode: TTVisual.ITTTextBoxColumn;
    txtKesinlesenMiktar: TTVisual.ITTTextBoxColumn;
    txtKesinMiktar: TTVisual.ITTTextBoxColumn;
    UBBCODE: TTVisual.ITTTextBoxColumn;
    WarrantyNote: TTVisual.ITTTextBox;
    public CodelessMaterialDirectPurchaseGridsColumns = [];
    public OPDirectPurchaseGridColumns = [];
    public OrthesisProsthesisProceduresColumns = [];
    public ReturnDescriptionGridColumns = [];
    public TreatmentMaterialsColumns = [];
    public orthesisProsthesisFormViewModel: OrthesisProsthesisFormViewModel = new OrthesisProsthesisFormViewModel();
    public ReturnDescriptionGrid_Visibility = false;

    public get _OrthesisProsthesisRequest(): OrthesisProsthesisRequest {
        return this._TTObject as OrthesisProsthesisRequest;
    }
    private OrthesisProsthesisForm_DocumentUrl: string = '/api/OrthesisProsthesisRequestService/OrthesisProsthesisForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected reportService: AtlasReportService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.OrthesisProsthesisForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async OrthesisProsthesisProcedures_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //TODO:Showedit!
        //if ((((ITTGridCell)OrthesisProsthesisProcedures.CurrentCell).OwningColumn != null) && (((ITTGridCell)OrthesisProsthesisProcedures.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
        //{
        //    OrthesisProsthesisProcedure_CokluOzelDurumForm codf = new OrthesisProsthesisProcedure_CokluOzelDurumForm();
        //    OrthesisProsthesisProcedure inp = (OrthesisProsthesisProcedure)OrthesisProsthesisProcedures.CurrentCell.OwningRow.TTObject;
        //    codf.ShowEdit(this.FindForm(), inp);
        //}
        let a = 1;
    }
    private async OrthesisProsthesisProcedures_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        //let changedCell: TTVisual.ITTGridCell = this.OrthesisProsthesisProcedures.Rows[rowIndex].Cells[columnIndex];
        //if (changedCell.OwningColumn.Name === this.AnesteziDrTescilNo.Name) {
        //    if (changedCell.Value !== null) {
        //        let obj: OrthesisProsthesisProcedure = <OrthesisProsthesisProcedure>changedCell.OwningRow.TTObject;
        //        let context: TTObjectContext = this._OrthesisProsthesisRequest.ObjectContext;
        //        let user: ResUser = <ResUser>context.GetObject(new Guid(changedCell.Value.toString()), typeof ResUser);
        //        obj.DrAnesteziTescilNo = user.DiplomaRegisterNo;
        //    }
        //}
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        if (transDef !== null) {
            if ((transDef.FromStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.RequestAcception.id && transDef.ToStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.RequestReturn.id)
                || (transDef.FromStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Procedure.id && transDef.ToStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Pricing.id))
            {
                 await this.AddReturnDescriptionInput_Local(i18n("M16848", "İşlem İade Sebebi :"), i18n("M16045", "İade - "));
            }

            if (transDef.ToStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Cancelled.id)
                await this.setReasonOfCancel(i18n("M16561", "İptal Sebebi :"), i18n("M16527", "İptal - "));
            else if (transDef.FromStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.ControlApproval.id && transDef.ToStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Procedure.id)
                await this.AddReturnDescriptionInput_Local(i18n("M16891", "İşlem Tekrar Sebebi :"), i18n("M16892", "İşlem Tekrarı - "));

            //Server tarafına taşındı

            //if (transDef.FromStateDefID.Equals(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.RequestAcception) && transDef.ToStateDefID.Equals(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Procedure)) {
            //    if (this._OrthesisProsthesisRequest.AuthorizedUsers.length === 0)
            //        this.SetAuthorizedUserBySelecting(this._OrthesisProsthesisRequest.MasterResource, UserTypeEnum.Technician, false);
            //}
        }
    }

    protected async AddReturnDescriptionInput_Local(note: string, type: string)
    {
        let returnReason: string = await InputForm.GetText(note + i18n("M14794", " Giriniz."), "", true, true);

        if (returnReason != null && returnReason != "" && typeof returnReason === "string") {
            let theGrid: OrthesisProsthesis_ReturnDescriptionsGrid = null;
            theGrid = new OrthesisProsthesis_ReturnDescriptionsGrid(this._EpisodeAction.ObjectContext);
            theGrid.Description = type + returnReason;
            theGrid.EntryDate = (await CommonService.RecTime());
            //UserHelper.CurrentResource.then(x => { theGrid.UserName = x == null ? "" : x.Name});
            //theGrid.UserName = UserHelper._currentResource === null ? "" : UserHelper._currentResource.Name;
            let currentUser: ResUser = <ResUser>TTUser.CurrentUser.UserObject;
            theGrid.UserName = currentUser.Name;
            this._OrthesisProsthesisRequest.ReturnDescriptions.push(theGrid);
        }
        else
            throw new Exception(i18n("M16073", "iade sebebini girmeden işleme devam edemezsiniz."));

    }

    async setReasonOfCancel(note: string, type: string) {
        let returnReason: string = await InputForm.GetText(note + i18n("M14794", " Giriniz."), "", true, true);
        if (returnReason != null && returnReason != "" && typeof returnReason === "string") {
            this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.ReasonOfCancel = type + returnReason;
        }
        else
            throw new Exception(i18n("M16563", "İptal sebebini girmeden işleme devam edemezsiniz."));

    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this.DirectPurchaseMaterialByPatient();
        if (this._OrthesisProsthesisRequest.ReturnDescriptions.length > 0 && (this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.ControlApproval || this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Procedure))
            this.ReturnDescriptionGrid_Visibility = true;
        else
            this.ReturnDescriptionGrid_Visibility = false;

        if (this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.ControlApproval )
        {
            this.ChiefTechnicianNote.ReadOnly = false;
            this.ChiefTechnicianNote.Enabled = true;
            this.TechnicianNote.ReadOnly = true;
            this.TechnicianNote.Enabled = false;
            this.WarrantyNote.ReadOnly = false;
            this.WarrantyNote.Enabled = true;
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        if (this.ProcedureDoctor.SelectedObject === null)
            throw new Exception((await SystemMessageService.GetMessage(669)));
        if (this._OrthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids.length > 0) {
            let materials: Array<DPADetailFirmPriceOffer> = new Array<DPADetailFirmPriceOffer>();
            for (let sdg of this._OrthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids) {
                if (materials.Contains(sdg.DPADetailFirmPriceOffer))
                    throw new TTException(i18n("M11354", "Aynı Malzemeyi Birden Fazla Giremezsiniz ! "));
                else materials.push(sdg.DPADetailFirmPriceOffer);
            }
        }
        if (this._OrthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids.length > 0) {
            let materials: Array<DPADetailFirmPriceOffer> = new Array<DPADetailFirmPriceOffer>();
            for (let cdg of this._OrthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids) {
                if (materials.Contains(cdg.DPADetailFirmPriceOffer))
                    throw new TTException(i18n("M11354", "Aynı Malzemeyi Birden Fazla Giremezsiniz ! "));
                else materials.push(cdg.DPADetailFirmPriceOffer);
            }
        }
        let malzemeObjectID: Guid = new Guid((await SystemParameterService.GetParameterValue('22F_MALZEMEOBJECTID', Guid.Empty.toString())));
       //malzemeObjectID malzemeyi getobject yaparken hata alıyor olmayan bir malzemeyi arıyor ve hata alıyor eski haline çevirdim.
        for (let sdg of this._OrthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids) {
            let material : Material = <Material>this._OrthesisProsthesisRequest.ObjectContext.GetObject(malzemeObjectID, 'MATERIAL');
            sdg.Material = material;
            sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product !== null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
            sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
        }
        for (let cdg of this._OrthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids) {
            let material: Material = <Material>this._OrthesisProsthesisRequest.ObjectContext.GetObject(malzemeObjectID, 'MATERIAL');
            cdg.Material = material;
            //cdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
            cdg.Amount = cdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
        }
        if (transDef !== null) {
            (await OrthesisProsthesisRequestService.MakingDirectPurchaseHasUsed(this._OrthesisProsthesisRequest));
            //if (transDef.ToStateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.ControlApproval || transDef.ToStateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.DoctorApproval || transDef.ToStateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Completed) {
            //    if (transDef.ToStateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Completed) {
            //        let savePointGuid: Guid = this._OrthesisProsthesisRequest.ObjectContext.BeginSavePoint();
            //        try {
            //            (await OrthesisProsthesisRequestService.CreateSubActionMatPricingDet(this._OrthesisProsthesisRequest));
            //            this._OrthesisProsthesisRequest.ObjectContext.Update();
            //        }
            //        catch (ex) {
            //            if (this._OrthesisProsthesisRequest.ObjectContext.HasSavePoint(savePointGuid))
            //                this._OrthesisProsthesisRequest.ObjectContext.RollbackSavePoint(savePointGuid);
            //            throw ex;
            //        }

            //    }
            //    else (await OrthesisProsthesisRequestService.CreateSubActionMatPricingDet(this._OrthesisProsthesisRequest));
            //}
        }
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        if (String.isNullOrEmpty(this._OrthesisProsthesisRequest.FinancialDepartmentNot)) {
            //Todo: ismail kontrol et
            // this.NotesTab.TabPages.Remove(this.NoteFinance);
        }
        if (this._OrthesisProsthesisRequest.CurrentStateDefID === OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.ControlApproval) {
            this.ChiefTechnicianNote.ReadOnly = false;
            this.TechnicianNote.ReadOnly = true;
            this.WarrantyNote.ReadOnly = false;
            this.WarrantyNote.Enabled = true;
        }

        this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.RequestAcception);
        this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.FinancialDepartmentControl);
        this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Appointment);
        this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.DoctorApproval);
        this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.FinancialDepartmentRejected);
        this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommittee);
        this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeApproval);
        this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeWithThreeSpecialist);
        this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeWithThreeSpecialistApproval);

        //Todo: ismail servera taşı
        // this.SetProcedureDoctorAsCurrentResource();
        // this.SetTreatmentMaterialListFilter(<TTObjectDef>TTObjectDefManager.Instance.ObjectDefs['BaseTreatmentMaterial'], <TTVisual.ITTGridColumn>this.TreatmentMaterials.Columns['MMaterial']);
        // episodedaki tüm Protez isteklerini toplayıp totalDescription alanına atar



        //if(_OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.States.Procedure.DoctorProcedure) // State kontrolüne gerek var mı? BB
        //{
            //Todo: ismail filtrelere genel olarak bakılır herhalde
        // this.SetDirectPurchaseListFilter(<TTVisual.ITTGridColumn>this.OPDirectPurchaseGrid.Columns['DPADetailFirmPriceOffer']);
        //}

        //            else if (this._OrthesisProsthesisRequest.CurrentStateDefID==OrthesisProsthesisRequest.States.RequestAcception)
        //            {
        //                //TODO: Burası geçici olarak kaldırıldı eski sistemden kopylandığı için, gerek görülmedi...YY
        //                //string totalDescription="";
        //                //foreach(OrthesisProsthesisRequest orthesisProsthesisRequest in this._OrthesisProsthesisRequest.Episode.OrthesisProsthesisRequests)
        //                //{
        //                //   totalDescription= totalDescription + " \n " + orthesisProsthesisRequest.Description;
        //                //}
        //                //if (totalDescription != "")
        //                //{
        //                //   this.TotalDescription.Text= "Ortez-Protez Raporu \n " + totalDescription;
        //                //}
        //
        //                if(this._OrthesisProsthesisRequest.ReturnDescriptions.Count > 0)
        //                {
        //                    this.ReturnDescriptionsLabel.Visible = true;
        //                    this.ReturnDescriptionGrid.Visible = true;
        //                }
        //
        //                foreach(OrthesisProsthesisProcedure procedure in this._OrthesisProsthesisRequest.OrthesisProsthesisProcedures)
        //                {
        //                    OrtesisProsthesisDefinition pDef = procedure.ProcedureObject as OrtesisProsthesisDefinition;
        //                    if(pDef != null && pDef.HealthCommitteeType.Value == OrthesisProsthesisHCType.HealthCommittee)
        //                        this.DropStateButton(OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist);
        //                    else if(pDef != null && pDef.HealthCommitteeType.Value == OrthesisProsthesisHCType.HealthCommitteeWithThreeSpecialist)
        //                        this.DropStateButton(OrthesisProsthesisRequest.States.HealthCommittee);
        //
        //                    break;//tek bir procedure olmalı
        //                }
        //            }
        let a = 1;
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);
        await this.load(OrthesisProsthesisFormViewModel);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new OrthesisProsthesisRequest();
        this.orthesisProsthesisFormViewModel = new OrthesisProsthesisFormViewModel();
        this._ViewModel = this.orthesisProsthesisFormViewModel;
        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest = this._TTObject as OrthesisProsthesisRequest;
        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.MasterResource = new ResSection();
        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures = new Array<OrthesisProsthesisProcedure>();
        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OrthesisProthesisReqTreatmentMaterials = new Array<OrthesisProthesisRequestTreatmentMaterial>();
        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids = new Array<SurgeryDirectPurchaseGrid>();
        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids = new Array<CodelessMaterialDirectPurchaseGrid>();
        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.ReturnDescriptions = new Array<OrthesisProsthesis_ReturnDescriptionsGrid>();
        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.ProcedureDoctor = new ResUser();
        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.ProcedureSpeciality = new SpecialityDefinition();
    }

    protected loadViewModel() {
        let that = this;

        that.orthesisProsthesisFormViewModel = this._ViewModel as OrthesisProsthesisFormViewModel;
        that._TTObject = this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest;
        if (this.orthesisProsthesisFormViewModel == null)
            this.orthesisProsthesisFormViewModel = new OrthesisProsthesisFormViewModel();
        if (this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest == null)
            this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest = new OrthesisProsthesisRequest();
        let masterResourceObjectID = that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
            let masterResource = that.orthesisProsthesisFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
             if (masterResource) {
                that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.MasterResource = masterResource;
            }
        }
        that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures = that.orthesisProsthesisFormViewModel.OrthesisProsthesisProceduresGridList;
        for (let detailItem of that.orthesisProsthesisFormViewModel.OrthesisProsthesisProceduresGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
                let procedureObject = that.orthesisProsthesisFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let technicianObjectID = detailItem["Technician"];
            if (technicianObjectID != null && (typeof technicianObjectID === "string")) {
                let technician = that.orthesisProsthesisFormViewModel.ResUsers.find(o => o.ObjectID.toString() === technicianObjectID.toString());
                 if (technician) {
                    detailItem.Technician = technician;
                }
            }
            let ayniFarkliKesiObjectID = detailItem["AyniFarkliKesi"];
            if (ayniFarkliKesiObjectID != null && (typeof ayniFarkliKesiObjectID === "string")) {
                let ayniFarkliKesi = that.orthesisProsthesisFormViewModel.AyniFarkliKesis.find(o => o.ObjectID.toString() === ayniFarkliKesiObjectID.toString());
                 if (ayniFarkliKesi) {
                    detailItem.AyniFarkliKesi = ayniFarkliKesi;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
                let ozelDurum = that.orthesisProsthesisFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
            let resUserObjectID = detailItem["ResUser"];
            if (resUserObjectID != null && (typeof resUserObjectID === "string")) {
                let resUser = that.orthesisProsthesisFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                 if (resUser) {
                    detailItem.ResUser = resUser;
                }
            }
        }
        that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OrthesisProthesisReqTreatmentMaterials = that.orthesisProsthesisFormViewModel.TreatmentMaterialsGridList;
        for (let detailItem of that.orthesisProsthesisFormViewModel.TreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.orthesisProsthesisFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let malzemeTuruObjectID = detailItem["MalzemeTuru"];
            if (malzemeTuruObjectID != null && (typeof malzemeTuruObjectID === "string")) {
                let malzemeTuru = that.orthesisProsthesisFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
                 if (malzemeTuru) {
                    detailItem.MalzemeTuru = malzemeTuru;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
                let ozelDurum = that.orthesisProsthesisFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids = that.orthesisProsthesisFormViewModel.OPDirectPurchaseGridGridList;
        for (let detailItem of that.orthesisProsthesisFormViewModel.OPDirectPurchaseGridGridList) {
            let dPADetailFirmPriceOfferObjectID = detailItem["DPADetailFirmPriceOffer"];
            if (dPADetailFirmPriceOfferObjectID != null && (typeof dPADetailFirmPriceOfferObjectID === "string")) {
                let dPADetailFirmPriceOffer = that.orthesisProsthesisFormViewModel.DPADetailFirmPriceOffers.find(o => o.ObjectID.toString() === dPADetailFirmPriceOfferObjectID.toString());
                 if (dPADetailFirmPriceOffer) {
                    detailItem.DPADetailFirmPriceOffer = dPADetailFirmPriceOffer;
                }
                if (dPADetailFirmPriceOffer != null) {
                    let offeredUBBObjectID = dPADetailFirmPriceOffer["OfferedUBB"];
                    if (offeredUBBObjectID != null && (typeof offeredUBBObjectID === "string")) {
                        let offeredUBB = that.orthesisProsthesisFormViewModel.ProductDefinitions.find(o => o.ObjectID.toString() === offeredUBBObjectID.toString());
                         if (offeredUBB) {
                            dPADetailFirmPriceOffer.OfferedUBB = offeredUBB;
                        }
                    }
                }
                if (dPADetailFirmPriceOffer != null) {
                    let directPurchaseActionDetailObjectID = dPADetailFirmPriceOffer["DirectPurchaseActionDetail"];
                    if (directPurchaseActionDetailObjectID != null && (typeof directPurchaseActionDetailObjectID === "string")) {
                        let directPurchaseActionDetail = that.orthesisProsthesisFormViewModel.DirectPurchaseActionDetails.find(o => o.ObjectID.toString() === directPurchaseActionDetailObjectID.toString());
                         if (directPurchaseActionDetail) {
                            dPADetailFirmPriceOffer.DirectPurchaseActionDetail = directPurchaseActionDetail;
                        }
                    }
                }
            }
        }
        that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids = that.orthesisProsthesisFormViewModel.CodelessMaterialDirectPurchaseGridsGridList;
        for (let detailItem of that.orthesisProsthesisFormViewModel.CodelessMaterialDirectPurchaseGridsGridList) {
            let dPADetailFirmPriceOfferObjectID = detailItem["DPADetailFirmPriceOffer"];
            if (dPADetailFirmPriceOfferObjectID != null && (typeof dPADetailFirmPriceOfferObjectID === "string")) {
                let dPADetailFirmPriceOffer = that.orthesisProsthesisFormViewModel.DPADetailFirmPriceOffers.find(o => o.ObjectID.toString() === dPADetailFirmPriceOfferObjectID.toString());
                 if (dPADetailFirmPriceOffer) {
                    detailItem.DPADetailFirmPriceOffer = dPADetailFirmPriceOffer;
                }
                if (dPADetailFirmPriceOffer != null) {
                    let directPurchaseActionDetailObjectID = dPADetailFirmPriceOffer["DirectPurchaseActionDetail"];
                    if (directPurchaseActionDetailObjectID != null && (typeof directPurchaseActionDetailObjectID === "string")) {
                        let directPurchaseActionDetail = that.orthesisProsthesisFormViewModel.DirectPurchaseActionDetails.find(o => o.ObjectID.toString() === directPurchaseActionDetailObjectID.toString());
                         if (directPurchaseActionDetail) {
                            dPADetailFirmPriceOffer.DirectPurchaseActionDetail = directPurchaseActionDetail;
                        }
                    }
                }
            }
        }
        that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.ReturnDescriptions = that.orthesisProsthesisFormViewModel.ReturnDescriptionGridGridList;
        for (let detailItem of that.orthesisProsthesisFormViewModel.ReturnDescriptionGridGridList) {
        }
        let procedureDoctorObjectID = that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.orthesisProsthesisFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.ProcedureDoctor = procedureDoctor;
            }
        }
        let procedureSpecialityObjectID = that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest["ProcedureSpeciality"];
        if (procedureSpecialityObjectID != null && (typeof procedureSpecialityObjectID === "string")) {
            let procedureSpeciality = that.orthesisProsthesisFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === procedureSpecialityObjectID.toString());
             if (procedureSpeciality) {
                that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.ProcedureSpeciality = procedureSpeciality;
            }
        }

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OrthesisProsthesisFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.ProcessDate != event) {
                this._OrthesisProsthesisRequest.ProcessDate = event;
            }
        }
    }

    public onChiefTechnicianNoteChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.ChiefTechnicianNote != event) {
                this._OrthesisProsthesisRequest.ChiefTechnicianNote = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.MasterResource != event) {
                this._OrthesisProsthesisRequest.MasterResource = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.ProcedureDoctor != event) {
                this._OrthesisProsthesisRequest.ProcedureDoctor = event;
            }
        }
    }

    public onProcedureSpecialityChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.ProcedureSpeciality != event) {
                this._OrthesisProsthesisRequest.ProcedureSpeciality = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.ProtocolNo != event) {
                this._OrthesisProsthesisRequest.ProtocolNo = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.RequestDate != event) {
                this._OrthesisProsthesisRequest.RequestDate = event;
            }
        }
    }

    public onTechnicianNoteChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.TechnicianNote != event) {
                this._OrthesisProsthesisRequest.TechnicianNote = event;
            }
        }
    }

    public onTotalDescriptionChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.TotalDescription != event) {
                this._OrthesisProsthesisRequest.TotalDescription = event;
            }
        }
    }

    public onWarrantyNoteChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.WarrantyNote != event) {
                this._OrthesisProsthesisRequest.WarrantyNote = event;
            }
        }
    }


    OrthesisProsthesisProcedures_CellValueChangedEmitted(data: any) {
        if (data && this.OrthesisProsthesisProcedures_CellValueChanged && data.Row && data.Column) {
            this.OrthesisProsthesisProcedures.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };

            if (data.Row.TTObject.ProcedureObject != null && data.Column.DataMember == "ProcedureObject") {
                if (data.Row.TTObject.ProcedureObject.Description != null)
                    this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures[data.RowIndex].ProcedureObject.Description = data.Row.TTObject.ProcedureObject.Description;

                let that = this;
                let reqDate = JSON.stringify(this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.RequestDate).substring(1, 11);
                let apiUrl: string = "api/OrthesisProsthesisRequestService/GetProceduresPrice?ProcedureDefID=" + data.Row.TTObject.ProcedureObject.ObjectID + "&ActionID=" + that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.MasterAction + "&ReqDate=" + reqDate;

                that.httpService.get<any>(apiUrl)
                    .then(response => {
                        that.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures[data.RowIndex].Price = response;
                    })
                    .catch(error => {
                        that.messageService.showError(error);

                    });
            }

            this.OrthesisProsthesisProcedures_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ProcessDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.TotalDescription, "Rtf", this.__ttObject, "TotalDescription");
        redirectProperty(this.TechnicianNote, "Text", this.__ttObject, "TechnicianNote");
        redirectProperty(this.ChiefTechnicianNote, "Text", this.__ttObject, "ChiefTechnicianNote");
        redirectProperty(this.WarrantyNote, "Text", this.__ttObject, "WarrantyNote");
    }

    public initFormControls(): void {
        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "ResourceListDefinition";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 17469;
        this.MasterResource.Visible = false;

        this.TotalDescription = new TTVisual.TTRichTextBoxControl();
        this.TotalDescription.DisplayText = i18n("M22539", "Tabip Notu");
        this.TotalDescription.TemplateGroupName = i18n("M19779", "Ortez Protez İstek Açıklaması");
        this.TotalDescription.BackColor = "#DCDCDC";
        this.TotalDescription.Name = "TotalDescription";
        this.TotalDescription.TabIndex = 133;
        this.TotalDescription.Enabled = false;
        this.TotalDescription.ReadOnly = true;

        this.TabSubaction = new TTVisual.TTTabControl();
        this.TabSubaction.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TabSubaction.Name = "TabSubaction";
        this.TabSubaction.TabIndex = 25;

        this.OrtesisProtesis = new TTVisual.TTTabPage();
        this.OrtesisProtesis.DisplayIndex = 0;
        this.OrtesisProtesis.BackColor = "#FFFFFF";
        this.OrtesisProtesis.TabIndex = 0;
        this.OrtesisProtesis.Text = i18n("M19775", "Ortez Protez");
        this.OrtesisProtesis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.OrtesisProtesis.Name = "OrtesisProtesis";

        this.OrthesisProsthesisProcedures = new TTVisual.TTGrid();
        this.OrthesisProsthesisProcedures.Name = "OrthesisProsthesisProcedures";
        this.OrthesisProsthesisProcedures.TabIndex = 0;
        this.OrthesisProsthesisProcedures.DeleteButtonWidth = "5%";
        this.OrthesisProsthesisProcedures.AllowUserToAddRows = false;
        this.OrthesisProsthesisProcedures.AllowUserToDeleteRows = false;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = "OrtesisProsthesisListDefinition";
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 0;
        this.ProcedureObject.HeaderText = i18n("M19781", "Ortez Protez İşlemi");
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.Enabled = false;
        this.ProcedureObject.Width = "30%";

        this.SpecificNote = new TTVisual.TTTextBoxColumn();
        this.SpecificNote.DataMember = "ProcedureObject.Description";
        this.SpecificNote.DisplayIndex = 1;
        this.SpecificNote.HeaderText = i18n("M22257", "Spesifik Durum");
        this.SpecificNote.Name = "SpecificNote";
        this.SpecificNote.ReadOnly = true;
        this.SpecificNote.Width = "15%";

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.DisplayIndex = 2;
        this.Price.HeaderText = i18n("M27328", "Fiyat");
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Width = 100;

        this.SideO = new TTVisual.TTEnumComboBoxColumn();
        this.SideO.DataTypeName = "RightLeftEnum";
        this.SideO.DataMember = "Side";
        this.SideO.DisplayIndex = 3;
        this.SideO.HeaderText = i18n("M22824", "Taraf");
        this.SideO.Name = "SideO";
        this.SideO.ReadOnly = true;
        this.SideO.Width = "10%";

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 4;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = "5%";
        this.Amount.ReadOnly = true;

        this.PatientPays = new TTVisual.TTCheckBoxColumn();
        this.PatientPays.DataMember = "PatientPay";
        this.PatientPays.DisplayIndex = 5;
        this.PatientPays.HeaderText = i18n("M15289", "Hasta Öder");
        this.PatientPays.Name = "PatientPays";
        this.PatientPays.Visible = false;
        this.PatientPays.Width = 100;

        this.Technician = new TTVisual.TTListBoxColumn();
        this.Technician.ListDefName = "TechnicianList";
        this.Technician.DataMember = "Technician";
        this.Technician.DisplayIndex = 6;
        this.Technician.HeaderText = i18n("M23104", "Teknisyen Adı");
        this.Technician.Name = "Technician";
        //this.Technician.Visible = false;
        this.Technician.ReadOnly = true;
        this.Technician.Enabled = false;
        this.Technician.Width = "20%";

        this.AyniFarkliKesi = new TTVisual.TTListBoxColumn();
        this.AyniFarkliKesi.ListDefName = "AyniFarkliKesiListDefinition";
        this.AyniFarkliKesi.DataMember = "AyniFarkliKesi";
        this.AyniFarkliKesi.DisplayIndex = 7;
        this.AyniFarkliKesi.HeaderText = "Ayni Farkli Kesi Bilgisi";
        this.AyniFarkliKesi.Name = "AyniFarkliKesi";
        this.AyniFarkliKesi.Visible = false;
        this.AyniFarkliKesi.Width = 100;

        this.OrtezProtez_OzelDurum = new TTVisual.TTListBoxColumn();
        this.OrtezProtez_OzelDurum.ListDefName = "OzelDurumListDefinition";
        this.OrtezProtez_OzelDurum.DataMember = "OzelDurum";
        this.OrtezProtez_OzelDurum.DisplayIndex = 8;
        this.OrtezProtez_OzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.OrtezProtez_OzelDurum.Name = "OrtezProtez_OzelDurum";
        this.OrtezProtez_OzelDurum.Visible = false;
        this.OrtezProtez_OzelDurum.Width = 100;

        this.AnesteziDrTescilNo = new TTVisual.TTListBoxColumn();
        this.AnesteziDrTescilNo.ListDefName = "ResUserListDefinition";
        this.AnesteziDrTescilNo.DataMember = "ResUser";
        this.AnesteziDrTescilNo.DisplayIndex = 9;
        this.AnesteziDrTescilNo.HeaderText = i18n("M10967", "Anestezi Dr. Tescil No");
        this.AnesteziDrTescilNo.Name = "AnesteziDrTescilNo";
        this.AnesteziDrTescilNo.Visible = false;
        this.AnesteziDrTescilNo.Width = 100;

        this.RaporTakipNo = new TTVisual.TTTextBoxColumn();
        this.RaporTakipNo.DataMember = "RaporTakipNo";
        this.RaporTakipNo.DisplayIndex = 10;
        this.RaporTakipNo.HeaderText = i18n("M20855", "Rapor Takip No");
        this.RaporTakipNo.Name = "RaporTakipNo";
        this.RaporTakipNo.ReadOnly = true;
        this.RaporTakipNo.Visible = false;
        this.RaporTakipNo.Width = 100;

        this.CokluOzelDurum = new TTVisual.TTButtonColumn();
        this.CokluOzelDurum.DisplayIndex = 11;
        this.CokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.CokluOzelDurum.Name = "CokluOzelDurum";
        this.CokluOzelDurum.Visible = false;
        this.CokluOzelDurum.Width = 100;

        this.TreatmentMaterial = new TTVisual.TTTabPage();
        this.TreatmentMaterial.DisplayIndex = 1;
        this.TreatmentMaterial.BackColor = "#FFFFFF";
        this.TreatmentMaterial.TabIndex = 0;
        this.TreatmentMaterial.Text = i18n("M21320", "Sarf Giriş");
        this.TreatmentMaterial.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TreatmentMaterial.Name = "TreatmentMaterial";

        this.TreatmentMaterials = new TTVisual.TTGrid();
        this.TreatmentMaterials.AllowUserToDeleteRows = false;
        this.TreatmentMaterials.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TreatmentMaterials.Name = "TreatmentMaterials";
        this.TreatmentMaterials.TabIndex = 23;

        this.MActionDate = new TTVisual.TTDateTimePickerColumn();
        this.MActionDate.Format = DateTimePickerFormat.Custom;
        this.MActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.MActionDate.DataMember = "ActionDate";
        this.MActionDate.DisplayIndex = 0;
        this.MActionDate.HeaderText = "Tarih/Saat";
        this.MActionDate.Name = "MActionDate";
        this.MActionDate.Width = 180;

        this.MMaterial = new TTVisual.TTListBoxColumn();
        this.MMaterial.ListDefName = "TreatmentMaterialListDefinition";
        this.MMaterial.DataMember = "Material";
        this.MMaterial.DisplayIndex = 1;
        this.MMaterial.HeaderText = i18n("M18545", "Malzeme");
        this.MMaterial.Name = "MMaterial";
        this.MMaterial.Width = 350;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = i18n("M27355", "Barkodu");
        this.Barcode.Name = "Barcode";
        this.Barcode.Width = 100;

        this.MAmount = new TTVisual.TTTextBoxColumn();
        this.MAmount.DataMember = "Amount";
        this.MAmount.DisplayIndex = 3;
        this.MAmount.HeaderText = i18n("M19030", "Miktar");
        this.MAmount.Name = "MAmount";
        this.MAmount.Width = 75;
        this.MAmount.ReadOnly = true;

        this.UBBCODE = new TTVisual.TTTextBoxColumn();
        this.UBBCODE.DataMember = "UBBCode";
        this.UBBCODE.DisplayIndex = 4;
        this.UBBCODE.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCODE.Name = "UBBCODE";
        this.UBBCODE.Width = 100;

        this.KodsuzMalzemeFiyati = new TTVisual.TTTextBoxColumn();
        this.KodsuzMalzemeFiyati.DataMember = "KodsuzMalzemeFiyati";
        this.KodsuzMalzemeFiyati.DisplayIndex = 5;
        this.KodsuzMalzemeFiyati.HeaderText = i18n("M17688", "Kodsuz Malzeme Fiyatı");
        this.KodsuzMalzemeFiyati.Name = "KodsuzMalzemeFiyati";
        this.KodsuzMalzemeFiyati.ReadOnly = true;
        this.KodsuzMalzemeFiyati.Visible = false;
        this.KodsuzMalzemeFiyati.Width = 100;

        this.MalzemeBrans = new TTVisual.TTTextBoxColumn();
        this.MalzemeBrans.DataMember = "MalzemeBrans";
        this.MalzemeBrans.DisplayIndex = 6;
        this.MalzemeBrans.HeaderText = i18n("M18556", "Malzeme Branş");
        this.MalzemeBrans.Name = "MalzemeBrans";
        this.MalzemeBrans.ReadOnly = true;
        this.MalzemeBrans.Visible = false;
        this.MalzemeBrans.Width = 100;

        this.Kdv = new TTVisual.TTTextBoxColumn();
        this.Kdv.DataMember = "Kdv";
        this.Kdv.DisplayIndex = 7;
        this.Kdv.HeaderText = "Kdv";
        this.Kdv.Name = "Kdv";
        this.Kdv.ReadOnly = true;
        this.Kdv.Visible = false;
        this.Kdv.Width = 100;

        this.MalzemeTuru = new TTVisual.TTListBoxColumn();
        this.MalzemeTuru.ListDefName = "MalzemeTuruListDefinition";
        this.MalzemeTuru.DataMember = "MalzemeTuru";
        this.MalzemeTuru.DisplayIndex = 8;
        this.MalzemeTuru.HeaderText = i18n("M18614", "Malzeme Türü");
        this.MalzemeTuru.Name = "MalzemeTuru";
        this.MalzemeTuru.Visible = false;
        this.MalzemeTuru.Width = 100;

        this.ttlistboxcolumn1 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn1.ListDefName = "OzelDurumListDefinition";
        this.ttlistboxcolumn1.DataMember = "OzelDurum";
        this.ttlistboxcolumn1.DisplayIndex = 9;
        this.ttlistboxcolumn1.HeaderText = i18n("M20080", "Özel Durum");
        this.ttlistboxcolumn1.Name = "ttlistboxcolumn1";
        this.ttlistboxcolumn1.Visible = false;
        this.ttlistboxcolumn1.Width = 100;

        this.MalzemeSatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MalzemeSatinAlisTarihi.DataMember = "MalzemeSatinAlisTarihi";
        this.MalzemeSatinAlisTarihi.DisplayIndex = 10;
        this.MalzemeSatinAlisTarihi.HeaderText = i18n("M18604", "Malzeme Satın Alış Tarihi");
        this.MalzemeSatinAlisTarihi.Name = "MalzemeSatinAlisTarihi";
        this.MalzemeSatinAlisTarihi.ReadOnly = true;
        this.MalzemeSatinAlisTarihi.Visible = false;
        this.MalzemeSatinAlisTarihi.Width = 100;

        this.DirectPurchaseMaterials = new TTVisual.TTTabPage();
        this.DirectPurchaseMaterials.DisplayIndex = 2;
        this.DirectPurchaseMaterials.TabIndex = 2;
        this.DirectPurchaseMaterials.Text = "Doğrudan Teminle Alınan Malzemeler";
        this.DirectPurchaseMaterials.Visible = false;
        this.DirectPurchaseMaterials.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DirectPurchaseMaterials.Name = "DirectPurchaseMaterials";

        this.OPDirectPurchaseGrid = new TTVisual.TTGrid();
        this.OPDirectPurchaseGrid.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.OPDirectPurchaseGrid.Name = "OPDirectPurchaseGrid";
        this.OPDirectPurchaseGrid.TabIndex = 0;

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
        this.txtBarcode.HeaderText = "Barkod";
        this.txtBarcode.Name = "txtBarcode";
        this.txtBarcode.ReadOnly = true;
        this.txtBarcode.Width = 100;

        this.txtKesinlesenMiktar = new TTVisual.TTTextBoxColumn();
        this.txtKesinlesenMiktar.DataMember = "CertainAmount";
        this.txtKesinlesenMiktar.DisplayIndex = 2;
        this.txtKesinlesenMiktar.HeaderText = i18n("M17504", "Kesinleşen Miktar");
        this.txtKesinlesenMiktar.Name = "txtKesinlesenMiktar";
        this.txtKesinlesenMiktar.ReadOnly = true;
        this.txtKesinlesenMiktar.Width = 60;

        this.CodelessDirectPurchase = new TTVisual.TTTabPage();
        this.CodelessDirectPurchase.DisplayIndex = 3;
        this.CodelessDirectPurchase.TabIndex = 3;
        this.CodelessDirectPurchase.Text = i18n("M23687", "UBB Kodsuz Doğrudan Temin Malzemeleri");
        this.CodelessDirectPurchase.Visible = false;
        this.CodelessDirectPurchase.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CodelessDirectPurchase.Name = "CodelessDirectPurchase";

        this.CodelessMaterialDirectPurchaseGrids = new TTVisual.TTGrid();
        this.CodelessMaterialDirectPurchaseGrids.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CodelessMaterialDirectPurchaseGrids.Name = "CodelessMaterialDirectPurchaseGrids";
        this.CodelessMaterialDirectPurchaseGrids.TabIndex = 0;

        this.DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid = new TTVisual.TTListBoxColumn();
        this.DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid.ListDefName = "CodelessMaterialDPADetailList";
        this.DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid.DataMember = "DPADetailFirmPriceOffer";
        this.DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid.DisplayIndex = 0;
        this.DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid.HeaderText = i18n("M17687", "Kodsuz Malzeme");
        this.DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid.Name = "DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid";
        this.DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid.Width = 300;

        this.txtKesinMiktar = new TTVisual.TTTextBoxColumn();
        this.txtKesinMiktar.DataMember = "CertainAmount";
        this.txtKesinMiktar.DisplayIndex = 1;
        this.txtKesinMiktar.HeaderText = i18n("M17504", "Kesinleşen Miktar");
        this.txtKesinMiktar.Name = "txtKesinMiktar";
        this.txtKesinMiktar.ReadOnly = true;
        this.txtKesinMiktar.Width = 100;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 0;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 1;
        //this.ActionDate.Visible = false;

        this.labelProcessDate = new TTVisual.TTLabel();
        this.labelProcessDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelProcessDate.BackColor = "#DCDCDC";
        this.labelProcessDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcessDate.ForeColor = "#000000";
        this.labelProcessDate.Name = "labelProcessDate";
        this.labelProcessDate.TabIndex = 115;
        this.labelProcessDate.Visible = false;

        this.ReturnDescriptionGrid = new TTVisual.TTGrid();
        this.ReturnDescriptionGrid.BackColor = "#DCDCDC";
        this.ReturnDescriptionGrid.ReadOnly = true;
        this.ReturnDescriptionGrid.Name = "ReturnDescriptionGrid";
        this.ReturnDescriptionGrid.TabIndex = 9;
        this.ReturnDescriptionGrid.Visible = false;
        this.ReturnDescriptionGrid.AllowUserToAddRows = false;
        this.ReturnDescriptionGrid.AllowUserToDeleteRows = false;

        this.EntryDate = new TTVisual.TTDateTimePickerColumn();
        this.EntryDate.Format = DateTimePickerFormat.Long;
        this.EntryDate.DataMember = "EntryDate";
        this.EntryDate.DisplayIndex = 0;
        this.EntryDate.HeaderText = "Tarih";
        this.EntryDate.Name = "EntryDate";
        this.EntryDate.Width = 200;
        this.EntryDate.ReadOnly = true;

        this.ReturnDescription = new TTVisual.TTTextBoxColumn();
        this.ReturnDescription.DataMember = "Description";
        this.ReturnDescription.DisplayIndex = 1;
        this.ReturnDescription.HeaderText = i18n("M16047", "İade Açıklaması");
        this.ReturnDescription.Name = "ReturnDescription";
        this.ReturnDescription.Width = 400;
        this.ReturnDescription.ReadOnly = true;

        this.OwnerUser = new TTVisual.TTTextBoxColumn();
        this.OwnerUser.DataMember = "UserName";
        this.OwnerUser.DisplayIndex = 2;
        this.OwnerUser.HeaderText = i18n("M17894", "Kullanıcı Adı");
        this.OwnerUser.Name = "OwnerUser";
        this.OwnerUser.ReadOnly = true;
        this.OwnerUser.Width = 150;

        this.ReturnDescriptionsLabel = new TTVisual.TTLabel();
        this.ReturnDescriptionsLabel.Text = i18n("M16046", "İade Açıklamaları");
        this.ReturnDescriptionsLabel.ForeColor = "#000000";
        this.ReturnDescriptionsLabel.Name = "ReturnDescriptionsLabel";
        this.ReturnDescriptionsLabel.TabIndex = 17467;
        this.ReturnDescriptionsLabel.Visible = false;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 126;

        this.LabelRequestDate = new TTVisual.TTLabel();
        this.LabelRequestDate.Text = i18n("M16650", "İstek Tarihi");
        this.LabelRequestDate.BackColor = "#DCDCDC";
        this.LabelRequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelRequestDate.ForeColor = "#000000";
        this.LabelRequestDate.Name = "LabelRequestDate";
        this.LabelRequestDate.TabIndex = 184;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 1;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.LinkedControlName = "MasterResource";
        this.ProcedureDoctor.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.ProcedureDoctor.ReadOnly = true;
        this.ProcedureDoctor.Enabled = false;
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 4;

        this.labelProcedureSpeciality = new TTVisual.TTLabel();
        this.labelProcedureSpeciality.Text = i18n("M16606", "İsteğin Yapıldığı Uzmanlık Dalı");
        this.labelProcedureSpeciality.BackColor = "#DCDCDC";
        this.labelProcedureSpeciality.ForeColor = "#000000";
        this.labelProcedureSpeciality.Name = "labelProcedureSpeciality";
        this.labelProcedureSpeciality.TabIndex = 167;

        this.ProcedureSpeciality = new TTVisual.TTObjectListBox();
        this.ProcedureSpeciality.ReadOnly = true;
        this.ProcedureSpeciality.Enabled = false;
        this.ProcedureSpeciality.ListDefName = "SpecialityListDefinition";
        this.ProcedureSpeciality.Name = "ProcedureSpeciality";
        this.ProcedureSpeciality.TabIndex = 3;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M16935", "İşlemi Yapan Tabip");
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 165;

        this.PatientGroup = new TTVisual.TTEnumComboBox();
        this.PatientGroup.DataTypeName = "PatientGroupEnum";
        this.PatientGroup.BackColor = "#F0F0F0";
        this.PatientGroup.Enabled = false;
        this.PatientGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientGroup.Name = "PatientGroup";
        this.PatientGroup.TabIndex = 2;
        this.PatientGroup.Visible = false;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M15222", "Hasta Grubu");
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 17459;
        this.ttlabel2.Visible = false;

        this.NotesTab = new TTVisual.TTTabControl();
        this.NotesTab.Name = "NotesTab";
        this.NotesTab.TabIndex = 17468;

        this.NoteTechnicanTab = new TTVisual.TTTabPage();
        this.NoteTechnicanTab.DisplayIndex = 0;
        this.NoteTechnicanTab.TabIndex = 0;
        this.NoteTechnicanTab.Text = i18n("M23112", "Teknisyen Notu");
        this.NoteTechnicanTab.Name = "NoteTechnicanTab";

        this.TechnicianNote = new TTVisual.TTTextBox();
        this.TechnicianNote.Multiline = true;
        this.TechnicianNote.Name = "TechnicianNote";
        this.TechnicianNote.TabIndex = 0;
        this.TechnicianNote.Height = "100";

        this.NoteChief = new TTVisual.TTTabPage();
        this.NoteChief.DisplayIndex = 1;
        this.NoteChief.BackColor = "#FFFFFF";
        this.NoteChief.TabIndex = 1;
        this.NoteChief.Text = i18n("M11595", "Baş Teknisyen Notu");
        this.NoteChief.Name = "NoteChief";

        this.ChiefTechnicianNote = new TTVisual.TTTextBox();
        this.ChiefTechnicianNote.Multiline = true;
        this.ChiefTechnicianNote.BackColor = "#F0F0F0";
        this.ChiefTechnicianNote.ReadOnly = true;
        this.ChiefTechnicianNote.Enabled = false;
        this.ChiefTechnicianNote.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ChiefTechnicianNote.Name = "ChiefTechnicianNote";
        this.ChiefTechnicianNote.TabIndex = 6;
        this.ChiefTechnicianNote.Height = "100";
        //this.ChiefTechnicianNote.Visible = false;

        this.NoteWarranty = new TTVisual.TTTabPage();
        this.NoteWarranty.DisplayIndex = 2;
        this.NoteWarranty.TabIndex = 2;
        this.NoteWarranty.Text = i18n("M14514", "Garanti Notu Açıklaması");
        this.NoteWarranty.Name = "NoteWarranty";

        this.WarrantyNote = new TTVisual.TTTextBox();
        this.WarrantyNote.Multiline = true;
        this.WarrantyNote.BackColor = "#F0F0F0";
        this.WarrantyNote.ReadOnly = true;
        this.WarrantyNote.Enabled = false;
        this.WarrantyNote.Name = "WarrantyNote";
        this.WarrantyNote.TabIndex = 0;
        this.WarrantyNote.Height = "100";

        this.OrthesisProsthesisProceduresColumns = [this.ProcedureObject, this.SpecificNote, this.Price, this.SideO, this.Amount, this.PatientPays, this.Technician, this.AyniFarkliKesi, this.OrtezProtez_OzelDurum, this.AnesteziDrTescilNo, this.RaporTakipNo, this.CokluOzelDurum];
        this.TreatmentMaterialsColumns = [this.MActionDate, this.MMaterial, this.Barcode, this.MAmount, this.UBBCODE, this.KodsuzMalzemeFiyati, this.MalzemeBrans, this.Kdv, this.MalzemeTuru, this.ttlistboxcolumn1, this.MalzemeSatinAlisTarihi];
        this.OPDirectPurchaseGridColumns = [this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar];
        this.CodelessMaterialDirectPurchaseGridsColumns = [this.DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid, this.txtKesinMiktar];
        this.ReturnDescriptionGridColumns = [this.EntryDate, this.ReturnDescription, this.OwnerUser];
        this.TabSubaction.Controls = [this.OrtesisProtesis, this.TreatmentMaterial, this.DirectPurchaseMaterials, this.CodelessDirectPurchase];
        this.OrtesisProtesis.Controls = [this.OrthesisProsthesisProcedures];
        this.TreatmentMaterial.Controls = [this.TreatmentMaterials];
        this.DirectPurchaseMaterials.Controls = [this.OPDirectPurchaseGrid];
        this.CodelessDirectPurchase.Controls = [this.CodelessMaterialDirectPurchaseGrids];
        this.NotesTab.Controls = [this.NoteTechnicanTab, this.NoteChief, this.NoteWarranty];
        this.NoteTechnicanTab.Controls = [this.TechnicianNote];
        this.NoteChief.Controls = [this.ChiefTechnicianNote];
        this.NoteWarranty.Controls = [this.WarrantyNote];
        this.Controls = [this.MasterResource, this.TotalDescription, this.TabSubaction, this.OrtesisProtesis, this.OrthesisProsthesisProcedures, this.ProcedureObject, this.SpecificNote, this.Price, this.SideO, this.Amount, this.PatientPays, this.Technician, this.AyniFarkliKesi, this.OrtezProtez_OzelDurum, this.AnesteziDrTescilNo, this.RaporTakipNo, this.CokluOzelDurum, this.TreatmentMaterial, this.TreatmentMaterials, this.MActionDate, this.MMaterial, this.Barcode, this.MAmount, this.UBBCODE, this.KodsuzMalzemeFiyati, this.MalzemeBrans, this.Kdv, this.MalzemeTuru, this.ttlistboxcolumn1, this.MalzemeSatinAlisTarihi, this.DirectPurchaseMaterials, this.OPDirectPurchaseGrid, this.DPADetailFirmPriceOffer, this.txtBarcode, this.txtKesinlesenMiktar, this.CodelessDirectPurchase, this.CodelessMaterialDirectPurchaseGrids, this.DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid, this.txtKesinMiktar, this.ProtocolNo, this.ActionDate, this.labelProcessDate, this.ReturnDescriptionGrid, this.EntryDate, this.ReturnDescription, this.OwnerUser, this.ReturnDescriptionsLabel, this.labelProtocolNo, this.LabelRequestDate, this.RequestDate, this.ProcedureDoctor, this.labelProcedureSpeciality, this.ProcedureSpeciality, this.labelProcedureDoctor, this.PatientGroup, this.ttlabel2, this.NotesTab, this.NoteTechnicanTab, this.TechnicianNote, this.NoteChief, this.ChiefTechnicianNote, this.NoteWarranty, this.WarrantyNote];

    }

    async PrintOrthesisProsthesisWorkRequestReport() {

        let hasNullTechnician: boolean = false;

        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures.forEach(element => {
            if (element.Technician == null) {
                hasNullTechnician = true;
            }
        });

        if (hasNullTechnician) {
            this.messageService.showError(i18n("M23116", "Teknisyen seçimlerini kaydetmeden bu raporu alamazsınız."));
            return false;
        }

        this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures.forEach(element => {
            const objectIdParam = new GuidParam(this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.ObjectID);
            const prpcedureObjectIdParam = new GuidParam(element.ObjectID);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'PROCEDUREOBJECTID': prpcedureObjectIdParam };
            this.reportService.showReport('OrthesisProsthesisWorkRequest', reportParameters);
        });

    }

    async PrintOrthesisProsthesisCommitReport() {
        const objectIdParam = new GuidParam(this.orthesisProsthesisFormViewModel._OrthesisProsthesisRequest.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('OrthesisProsthesisPatientCommitReport', reportParameters);
    }

}
