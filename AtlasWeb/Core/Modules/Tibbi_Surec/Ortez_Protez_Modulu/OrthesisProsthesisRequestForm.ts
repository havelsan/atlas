//$BC0E8652
import { Component, OnInit, NgZone } from '@angular/core';
import { OrthesisProsthesisRequestFormViewModel } from './OrthesisProsthesisRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { OrthesisProsthesisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { OrthesisProsthesis_ReturnDescriptionsGrid } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesisProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { CommonService } from "ObjectClassService/CommonService";
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';


@Component({
    selector: 'OrthesisProsthesisRequestForm',
    templateUrl: './OrthesisProsthesisRequestForm.html',
    providers: [MessageService, AtlasReportService]
})
export class OrthesisProsthesisRequestForm extends EpisodeActionForm implements OnInit {
    Amount: TTVisual.ITTMaskedTextBoxColumn;
    EntryDate: TTVisual.ITTDateTimePickerColumn;
    IsPrintReport: TTVisual.ITTCheckBoxColumn;
    IsRequestReport: TTVisual.ITTCheckBoxColumn;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProcedureSpeciality: TTVisual.ITTLabel;
    LabelRequestDate: TTVisual.ITTLabel;
    MasterResource: TTVisual.ITTObjectListBox;
    OrthesisProsthesisProcedures: TTVisual.ITTGrid;
    OwnerUser: TTVisual.ITTTextBoxColumn;
    PatientPays: TTVisual.ITTCheckBoxColumn;
    PayRatioO: TTVisual.ITTEnumComboBoxColumn;
    Price: TTVisual.ITTTextBoxColumn;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ProcedureSpeciality: TTVisual.ITTObjectListBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    ReturnDescription: TTVisual.ITTTextBoxColumn;
    ReturnDescriptionGrid: TTVisual.ITTGrid;
    ReturnDescriptionsLabel: TTVisual.ITTLabel;
    SideO: TTVisual.ITTEnumComboBoxColumn;
    SpecificNote: TTVisual.ITTTextBoxColumn;
    Technician: TTVisual.ITTListBoxColumn;
    TotalDescription: TTVisual.ITTRichTextBoxControl;
    ttgroupbox1: TTVisual.ITTGroupBox;
    tttabcontrolDiagnose: TTVisual.ITTTabControl;
    tttabpageOrthesis: TTVisual.ITTTabPage;
    public OrthesisProsthesisProceduresColumns = [];
    public ReturnDescriptionGridColumns = [];
    public orthesisProsthesisRequestFormViewModel: OrthesisProsthesisRequestFormViewModel = new OrthesisProsthesisRequestFormViewModel();
    public ReturnDescriptionGrid_Visibility = false;
    public _saveCommandVisible = false;
    public get _OrthesisProsthesisRequest(): OrthesisProsthesisRequest {
        return this._TTObject as OrthesisProsthesisRequest;
    }
    private OrthesisProsthesisRequestForm_DocumentUrl: string = '/api/OrthesisProsthesisRequestService/OrthesisProsthesisRequestForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private reportService: AtlasReportService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.OrthesisProsthesisRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async OrthesisProsthesisProcedures_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        //if (this.OrthesisProsthesisProcedures.CurrentCell.OwningColumn.DataMember == "ProcedureObject") {
        //    await this.httpService.post("api/OrthesisProsthesisRequestService/GetEpisodeActionStateDefinition", value);
        //}
    }

    //private async getProceduresPrice(objectID: number): Promise<number> {
    //    if (this.OrthesisProsthesisProcedures.CurrentCell.OwningColumn.DataMember == "ProcedureObject") {
    //        await this.httpService.post("api/OrthesisProsthesisRequestService/getProceduresPrice", objectID);
    //    }
    //}

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
       
        this.orthesisProsthesisRequestFormViewModel.OrthesisProsthesisProceduresGridList.forEach(x => {
            if (x.Amount != null &&  parseInt(x.Amount.toString(),10) != x.Amount )
                throw new Exception(i18n("M19033", "Miktar Alanına Lütfen Sayısal Bir Değer Giriniz."));

        });
       
        super.ClientSidePostScript(transDef);
        if (transDef !== null)
        {
            if (transDef.ToStateDefID.valueOf() !== OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Cancelled.id) {
                this._OrthesisProsthesisRequest.IsInRequest = true;
            }

            if (transDef.FromStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.TechnicianSelection.id && transDef.ToStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Procedure.id) {
                this.orthesisProsthesisRequestFormViewModel.OrthesisProsthesisProceduresGridList.forEach(x => {
                    console.log(x.Technician);
                    if (x.Technician == null)
                        throw new Exception(i18n("M23115", "Teknisyen Seçimi Yapmadan Bu İşleme Devam Edemezsiniz."));
                    //if (x.Amount == null || x.Amount <= 0)
                    //    throw new Exception('Miktar Seçimi Yapmadan Bu İşleme Devam Edemezsiniz.');
                });
            }
            //else

            if (transDef.FromStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Pricing.id && transDef.ToStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.TechnicianSelection.id) {
                this.orthesisProsthesisRequestFormViewModel.OrthesisProsthesisProceduresGridList.forEach(x => {
                    if (x.PayRatio == null)
                        throw new Exception(i18n("M30916", "Ödeme Oranı Seçmeden Bu İşleme Devam Edemezsiniz."));
                    //if (x.Amount == null || x.Amount <= 0)
                    //    throw new Exception('Miktar Seçimi Yapmadan Bu İşleme Devam Edemezsiniz.');
                });
            }
            this._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Pricing;


            //if (transDef.ToStateDefID.valueOf() != OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Pricing.id) {//bi önceki adıma geçiyorsa kontrol etmesine gerek yok
            //if (transDef.FromStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Request.id && transDef.ToStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Pricing.id) {

            this.orthesisProsthesisRequestFormViewModel.OrthesisProsthesisProceduresGridList.forEach(x => {
                if (x.Amount == null || x.Amount <= 0)
                    throw new Exception(i18n("M19033", "Miktar Seçimi Yapmadan Bu İşleme Devam Edemezsiniz."));
                else if (x.ProcedureObject["SideSelect"] && x.Side == null)
                    throw new Exception(x.ProcedureObject.Name + ' isimli Malzeme İçin Taraf (Yön) Seçimi Yapmadan Bu İşleme Devam Edemezsiniz.');
            });
            //}


            //}

            if (transDef.ToStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.RequestReturn.id)
                await this.takeReturnReasonFromUser(i18n("M13214", "Doktora İade Sebebi :"));

            if (transDef.ToStateDefID.valueOf() == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Cancelled.id)
                await this.setReasonOfCancel(i18n("M16561", "İptal Sebebi :"));
        }

        //throw new Exception('Teknisyen Seçimi .');
    }

    async takeReturnReasonFromUser(note: string) {
        let returnReason: string = await InputForm.GetText(note + i18n("M14794", " Giriniz."), "", true, true);
        if (returnReason != null && returnReason != "" && typeof returnReason === "string") {
            let theGrid: OrthesisProsthesis_ReturnDescriptionsGrid = null;
            theGrid = new OrthesisProsthesis_ReturnDescriptionsGrid(this._EpisodeAction.ObjectContext);
            theGrid.Description = i18n("M16045", "İade - ") + returnReason;
            theGrid.EntryDate = (await CommonService.RecTime());
            // UserHelper.CurrentResource.then(x => { theGrid.UserName = x == null ? "" : x.Name});
            let currentUser: ResUser = <ResUser>TTUser.CurrentUser.UserObject;
            theGrid.UserName = currentUser.Name;
            this._OrthesisProsthesisRequest.ReturnDescriptions.push(theGrid);
        }
        else
            throw new Exception(i18n("M16073", "iade sebebini girmeden işleme devam edemezsiniz."));

    }

    async setReasonOfCancel(note: string) {
        let returnReason: string = await InputForm.GetText(note + i18n("M14794", " Giriniz."), "", true, true);
        if (returnReason != null && returnReason != "" && typeof returnReason === "string") {
            this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.ReasonOfCancel = i18n("M16527", "İptal - ") + returnReason;
        }
        else
            throw new Exception(i18n("M16563", "İptal sebebini girmeden işleme devam edemezsiniz."));

    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        if (this.ProcedureDoctor.SelectedObject === null)
            throw new Exception((await SystemMessageService.GetMessage(669)));
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();


        this.Technician.ListFilterExpression = "USERRESOURCES.RESOURCE = '" + this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.MasterResource.ObjectID + "'";
        //this.ProcedureDoctor.ListFilterExpression = "USERRESOURCES.RESOURCE = '" + this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.MasterResource.ObjectID + "'";

        if (OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Request != this._OrthesisProsthesisRequest.CurrentStateDefID)
        {
            this._saveCommandVisible = true;
            this.TotalDescription.Enabled = false;
            this.TotalDescription.ReadOnly = true;
        }

        //if (this._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Request) {
            this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.RequestAcception);
            this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.FinancialDepartmentControl);
            this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Appointment);
            this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.DoctorApproval);
            this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.FinancialDepartmentRejected);
            this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommittee);
            this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeApproval);
            this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeWithThreeSpecialist);
            this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.HealthCommitteeWithThreeSpecialistApproval);
        //}

        //state e göre kontrollerin visibility ayarlaması
        await this.arrangeVisibilityWithState();
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);
        //await this.load(OrthesisProsthesisRequestFormViewModel);
        this.arrangeVisibilityWithState();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new OrthesisProsthesisRequest();
        this.orthesisProsthesisRequestFormViewModel = new OrthesisProsthesisRequestFormViewModel();
        this._ViewModel = this.orthesisProsthesisRequestFormViewModel;
        this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest = this._TTObject as OrthesisProsthesisRequest;
        this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.MasterResource = new ResSection();
        this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures = new Array<OrthesisProsthesisProcedure>();
        this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.ProcedureDoctor = new ResUser();
        this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.ProcedureSpeciality = new SpecialityDefinition();
        this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.ReturnDescriptions = new Array<OrthesisProsthesis_ReturnDescriptionsGrid>();
    }

    protected loadViewModel() {
        let that = this;

        that.orthesisProsthesisRequestFormViewModel = this._ViewModel as OrthesisProsthesisRequestFormViewModel;
        that._TTObject = this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest;
        if (this.orthesisProsthesisRequestFormViewModel == null)
            this.orthesisProsthesisRequestFormViewModel = new OrthesisProsthesisRequestFormViewModel();
        if (this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest == null)
            this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest = new OrthesisProsthesisRequest();
        let masterResourceObjectID = that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
            let masterResource = that.orthesisProsthesisRequestFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
             if (masterResource) {
                that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.MasterResource = masterResource;
            }
        }
        that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures = that.orthesisProsthesisRequestFormViewModel.OrthesisProsthesisProceduresGridList;
        for (let detailItem of that.orthesisProsthesisRequestFormViewModel.OrthesisProsthesisProceduresGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
                let procedureObject = that.orthesisProsthesisRequestFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let technicianObjectID = detailItem["Technician"];
            if (technicianObjectID != null && (typeof technicianObjectID === "string")) {
                let technician = that.orthesisProsthesisRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === technicianObjectID.toString());
                 if (technician) {
                    detailItem.Technician = technician;
                }
            }
        }
        let procedureDoctorObjectID = that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.orthesisProsthesisRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.ProcedureDoctor = procedureDoctor;
            }
        }
        let procedureSpecialityObjectID = that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest["ProcedureSpeciality"];
        if (procedureSpecialityObjectID != null && (typeof procedureSpecialityObjectID === "string")) {
            let procedureSpeciality = that.orthesisProsthesisRequestFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === procedureSpecialityObjectID.toString());
             if (procedureSpeciality) {
                that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.ProcedureSpeciality = procedureSpeciality;
            }
        }
        that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.ReturnDescriptions = that.orthesisProsthesisRequestFormViewModel.ReturnDescriptionGridGridList;
        for (let detailItem of that.orthesisProsthesisRequestFormViewModel.ReturnDescriptionGridGridList) {
        }

    }

    async ngOnInit()  {
        let that = this;
        await this.load(OrthesisProsthesisRequestFormViewModel);
  
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

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._OrthesisProsthesisRequest != null && this._OrthesisProsthesisRequest.RequestDate != event) {
                this._OrthesisProsthesisRequest.RequestDate = event;
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



    OrthesisProsthesisProcedures_CellValueChangedEmitted(data: any) {
        if (data && this.OrthesisProsthesisProcedures_CellValueChanged && data.Row && data.Column) {
            this.OrthesisProsthesisProcedures.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };

            if (data.Row.TTObject.ProcedureObject != null && data.Column.DataMember == "ProcedureObject") {
                //if (!data.Row.TTObject.IsNew)
                //{
                //    this.messageService.showError("Kaydedilmiş orderları değiştiremezsiniz./İptal edip yeni order tanımlayabilirsiniz ya da  \nuygulanmamış order detaylarını değiştirmek için \'Verilen Diyet Detayları\' sekmesini kullanabilirsiniz");
                //    return false;
                //}

                if (data.Row.TTObject.ProcedureObject.DefaultAmount != null)
                    this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures[data.RowIndex].Amount = data.Row.TTObject.ProcedureObject.DefaultAmount;
                //else
                //    this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures[data.RowIndex].Amount = 1;

                if (data.Row.TTObject.ProcedureObject.Description != null)
                    this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures[data.RowIndex].ProcedureObject.Description = data.Row.TTObject.ProcedureObject.Description;

                let that = this;
                let reqDate = JSON.stringify(this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.RequestDate).substring(1, 11);
                let apiUrl: string = "api/OrthesisProsthesisRequestService/GetProceduresPrice?ProcedureDefID=" + data.Row.TTObject.ProcedureObject.ObjectID + "&ActionID=" + that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.MasterAction + "&ReqDate=" + reqDate;

                that.httpService.get<any>(apiUrl)
                    .then(response => {
                        that.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures[data.RowIndex].Price = response;
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
        redirectProperty(this.TotalDescription, "Rtf", this.__ttObject, "TotalDescription");
    }

    public actionIdForDemografic(): Guid
    {
        if (this._OrthesisProsthesisRequest.MasterAction != null ) {
            if (typeof this._OrthesisProsthesisRequest.MasterAction === "string") {
                return this._OrthesisProsthesisRequest.MasterAction;
            }
            else {
                return this._OrthesisProsthesisRequest.MasterAction.ObjectID;
            }
        }

            return this._OrthesisProsthesisRequest.ObjectID;
    }

    protected arrangeVisibilityWithState()
    {
        if (this._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Pricing) {

            //this.PatientPays.Visible = true;
            this.PayRatioO.Visible = true;

            if (this._OrthesisProsthesisRequest.ReturnDescriptions.length > 0)
                this.ReturnDescriptionGrid_Visibility = true;
            else
                this.ReturnDescriptionGrid_Visibility = false;
        }
        else if (this._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.RequestReturn) {
            this.OrthesisProsthesisProcedures.AllowUserToAddRows = true;

            if (this._OrthesisProsthesisRequest.ReturnDescriptions.length > 0)
                this.ReturnDescriptionGrid_Visibility = true;
            else
                this.ReturnDescriptionGrid_Visibility = false;
        }
        else if (this._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.TechnicianSelection) {
            //this.PatientPays.Visible = true;
            //this.PatientPays.ReadOnly = true;
            this.Technician.Visible = true;
            this.PayRatioO.Visible = true;
            this.PayRatioO.ReadOnly = true;

        }
        else if (this._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Request)
        {
            this.OrthesisProsthesisProcedures.AllowUserToAddRows = true;
            this.ProcedureObject.ReadOnly = false;
            this.ProcedureObject.Enabled = true;
        }

        //iadeyi tekrar iade etmesin istendi
        //if (this.orthesisProsthesisRequestFormViewModel.prevStateID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Procedure.toString() && this._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Pricing)
        //    this.DropStateButton(OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.RequestReturn);

    }

    public initFormControls(): void {
        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "ResourceListDefinition";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 17460;
        this.MasterResource.Visible = false;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M22474", "Şema");
        this.ttgroupbox1.BackColor = "#DCDCDC";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 201;

        this.tttabcontrolDiagnose = new TTVisual.TTTabControl();
        this.tttabcontrolDiagnose.Name = "tttabcontrolDiagnose";
        this.tttabcontrolDiagnose.TabIndex = 200;

        this.tttabpageOrthesis = new TTVisual.TTTabPage();
        this.tttabpageOrthesis.DisplayIndex = 0;
        this.tttabpageOrthesis.BackColor = "#FFFFFF";
        this.tttabpageOrthesis.TabIndex = 1;
        this.tttabpageOrthesis.Text = i18n("M19775", "Ortez Protez");
        this.tttabpageOrthesis.Name = "tttabpageOrthesis";

        this.OrthesisProsthesisProcedures = new TTVisual.TTGrid();
        this.OrthesisProsthesisProcedures.Name = "OrthesisProsthesisProcedures";
        this.OrthesisProsthesisProcedures.TabIndex = 0;
        this.OrthesisProsthesisProcedures.DeleteButtonWidth = "5%";
        this.OrthesisProsthesisProcedures.AllowUserToAddRows = false;
        // this.OrthesisProsthesisProcedures.AllowUserToAddRows = this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.CurrentStateDefID == OrthesisProsthesisRequest.OrthesisProsthesisRequestStates.Request ? true : false;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = "OrtesisProsthesisListDefinition";
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 0;
        this.ProcedureObject.HeaderText = i18n("M19781", "Ortez Protez İşlemi");
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.Width = "35%";
        //this.ProcedureObject.ReadOnly = true;
        //this.ProcedureObject.Enabled = false;
        this.ProcedureObject.EnabledBindingPath = "IsNew";

        this.SpecificNote = new TTVisual.TTTextBoxColumn();
        this.SpecificNote.DataMember = "ProcedureObject.Description";
        this.SpecificNote.DisplayIndex = 1;
        this.SpecificNote.HeaderText = i18n("M22256", "Spesifik Açıklama");
        this.SpecificNote.Name = "SpecificNote";
        this.SpecificNote.ReadOnly = true;
        this.SpecificNote.Width = "15%";

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DisplayIndex = 2;
        this.Price.DataMember = "Price";
        this.Price.HeaderText = i18n("M27328", "Fiyat");
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Width = 100;

        this.SideO = new TTVisual.TTEnumComboBoxColumn();
        this.SideO.DataTypeName = "RightLeftEnum";
        this.SideO.DataMember = "Side";
        this.SideO.DisplayIndex = 2;
        this.SideO.HeaderText = i18n("M22824", "Taraf");
        this.SideO.Name = "SideO";
        this.SideO.Width = "10%";

        this.Amount = new TTVisual.TTMaskedTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 3;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        // this.Amount.TextMaskFormat = "000".replace(/\s/g, "");
        // this.Amount.Mask = "000".replace(/\s/g, "");
        this.Amount.Width = "5%";

        this.IsPrintReport = new TTVisual.TTCheckBoxColumn();
        this.IsPrintReport.DataMember = "IsPrintReport";
        this.IsPrintReport.DisplayIndex = 4;
        this.IsPrintReport.HeaderText = "Rapor Bass";
        this.IsPrintReport.Name = "IsPrintReport";
        this.IsPrintReport.Visible = false;
        this.IsPrintReport.Width = 100;

        this.PatientPays = new TTVisual.TTCheckBoxColumn();
        this.PatientPays.DataMember = "PatientPay";
        this.PatientPays.DisplayIndex = 5;
        this.PatientPays.HeaderText = i18n("M15289", "Hasta Öder");
        this.PatientPays.Name = "PatientPays";
        this.PatientPays.Visible = false;
        this.PatientPays.Width = "10%";

        this.PayRatioO = new TTVisual.TTEnumComboBoxColumn();
        this.PayRatioO.DataTypeName = "OrthesisPayRatio";
        this.PayRatioO.DataMember = "PayRatio";
        this.PayRatioO.DisplayIndex = 7;
        this.PayRatioO.HeaderText = i18n("M30915", "Ödeme Oranı");
        this.PayRatioO.Name = "PayRatioO";
        this.PayRatioO.Visible = false;
        this.PayRatioO.Width = 100;

        this.IsRequestReport = new TTVisual.TTCheckBoxColumn();
        this.IsRequestReport.DataMember = "IsRequestReport";
        this.IsRequestReport.DisplayIndex = 6;
        this.IsRequestReport.HeaderText = i18n("M20812", "Rapor İste");
        this.IsRequestReport.Name = "IsRequestReport";
        this.IsRequestReport.Visible = false;
        this.IsRequestReport.Width = 100;

        this.Technician = new TTVisual.TTListBoxColumn();
        this.Technician.ListDefName = "TechnicianList";
        this.Technician.DataMember = "Technician";
        this.Technician.DisplayIndex = 7;
        this.Technician.HeaderText = "Teknisyen";
        this.Technician.Name = "Technician";
        this.Technician.Visible = false;
        this.Technician.Width = "20%";

        this.TotalDescription = new TTVisual.TTRichTextBoxControl();
        this.TotalDescription.DisplayText = i18n("M22539", "Tabip Notu");
        this.TotalDescription.TemplateGroupName = i18n("M19779", "Ortez Protez İstek Açıklaması");
        this.TotalDescription.BackColor = "#DCDCDC";
        this.TotalDescription.Name = "TotalDescription";
        this.TotalDescription.TabIndex = 199;

        this.LabelRequestDate = new TTVisual.TTLabel();
        this.LabelRequestDate.Text = i18n("M16650", "İstek Tarihi");
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
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.ReadOnly = true;
        this.ProcedureDoctor.Enabled = false;
        this.ProcedureDoctor.TabIndex = 4;

        this.labelProcedureSpeciality = new TTVisual.TTLabel();
        this.labelProcedureSpeciality.Text = i18n("M16606", "İsteğin Yapıldığı Uzmanlık Dalı");
        this.labelProcedureSpeciality.ForeColor = "#000000";
        this.labelProcedureSpeciality.Name = "labelProcedureSpeciality";
        this.labelProcedureSpeciality.TabIndex = 167;

        this.ProcedureSpeciality = new TTVisual.TTObjectListBox();
        this.ProcedureSpeciality.ListDefName = "SpecialityListDefinition";
        this.ProcedureSpeciality.Name = "ProcedureSpeciality";
        this.ProcedureSpeciality.TabIndex = 3;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M16935", "İşlemi Yapan Tabip");
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 165;

        this.ReturnDescriptionGrid = new TTVisual.TTGrid();
        this.ReturnDescriptionGrid.BackColor = "#DCDCDC";
        this.ReturnDescriptionGrid.ReadOnly = true;
        this.ReturnDescriptionGrid.Enabled = false;
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
        this.EntryDate.ReadOnly = true;
        this.EntryDate.Width = 200;

        this.ReturnDescription = new TTVisual.TTTextBoxColumn();
        this.ReturnDescription.DataMember = "Description";
        this.ReturnDescription.DisplayIndex = 1;
        this.ReturnDescription.HeaderText = i18n("M16047", "İade Açıklaması");
        this.ReturnDescription.Name = "ReturnDescription";
        this.ReturnDescription.ReadOnly = true;
        this.ReturnDescription.Width = 400;

        this.OwnerUser = new TTVisual.TTTextBoxColumn();
        this.OwnerUser.DataMember = "UserName";
        this.OwnerUser.DisplayIndex = 2;
        this.OwnerUser.HeaderText = i18n("M17894", "Kullanıcı Adı");
        this.OwnerUser.Name = "OwnerUser";
        this.OwnerUser.ReadOnly = false;
        this.OwnerUser.Width = 150;

        this.ReturnDescriptionsLabel = new TTVisual.TTLabel();
        this.ReturnDescriptionsLabel.Text = i18n("M16046", "İade Açıklamaları");
        this.ReturnDescriptionsLabel.ForeColor = "#000000";
        this.ReturnDescriptionsLabel.Name = "ReturnDescriptionsLabel";
        this.ReturnDescriptionsLabel.TabIndex = 17467;
        this.ReturnDescriptionsLabel.Visible = false;

        this.OrthesisProsthesisProceduresColumns = [this.ProcedureObject, this.SpecificNote, this.Price, this.SideO, this.Amount, this.IsPrintReport, this.PatientPays, this.PayRatioO, this.IsRequestReport, this.Technician];
        this.ReturnDescriptionGridColumns = [this.EntryDate, this.ReturnDescription, this.OwnerUser];
        this.tttabcontrolDiagnose.Controls = [this.tttabpageOrthesis];
        this.tttabpageOrthesis.Controls = [this.OrthesisProsthesisProcedures];
        this.Controls = [this.MasterResource, this.ttgroupbox1, this.tttabcontrolDiagnose, this.tttabpageOrthesis, this.OrthesisProsthesisProcedures, this.ProcedureObject, this.SpecificNote, this.Price, this.SideO, this.Amount, this.IsPrintReport, this.PatientPays, this.PayRatioO, this.IsRequestReport, this.Technician, this.TotalDescription, this.LabelRequestDate, this.RequestDate, this.ProcedureDoctor, this.labelProcedureSpeciality, this.ProcedureSpeciality, this.labelProcedureDoctor, this.ReturnDescriptionGrid, this.EntryDate, this.ReturnDescription, this.OwnerUser, this.ReturnDescriptionsLabel];

    }

    async PrintOrthesisProsthesisWorkRequestReport() {

        let hasNullTechnician: boolean = false;

        this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures.forEach(element => {
            if (element.Technician == null) {
                hasNullTechnician = true;
            }
        });

        if (hasNullTechnician)
        {
            this.messageService.showError(i18n("M23116", "Teknisyen seçimlerini kaydetmeden bu raporu alamazsınız."));
            return false;
        }

        this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.OrthesisProsthesisProcedures.forEach(element => {
                const objectIdParam = new GuidParam(this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.ObjectID);
                const prpcedureObjectIdParam = new GuidParam(element.ObjectID);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'PROCEDUREOBJECTID': prpcedureObjectIdParam };
                this.reportService.showReport('OrthesisProsthesisWorkRequest', reportParameters);
        });

    }

    async PrintOrthesisProsthesisCommitReport()
    {
        const objectIdParam = new GuidParam(this.orthesisProsthesisRequestFormViewModel._OrthesisProsthesisRequest.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('OrthesisProsthesisPatientCommitReport', reportParameters);
    }


}
