//$003C1CE1
import { Component, OnInit, NgZone } from '@angular/core';
import { LaboratoryRequestProcedureFormViewModel } from "./LaboratoryRequestProcedureFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";

import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";



@Component({
    selector: 'LaboratoryRequestProcedureForm',
    templateUrl: './LaboratoryRequestProcedureForm.html',
    providers: [MessageService]
})
export class LaboratoryRequestProcedureForm extends EpisodeActionForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    Cancel: TTVisual.ITTButtonColumn;
    cmdSendRequest: TTVisual.ITTButton;
    cokluOzelDurum: TTVisual.ITTButtonColumn;
    CurrentState: TTVisual.ITTStateComboBoxColumn;
    Detail: TTVisual.ITTButtonColumn;
    drAnestezitescilNo: TTVisual.ITTListBoxColumn;
    Gebelik: TTVisual.ITTEnumComboBox;
    GridLabProcedures: TTVisual.ITTGrid;
    islemTarihi: TTVisual.ITTDateTimePickerColumn;
    labelBarcode: TTVisual.ITTLabel;
    labelGebelik: TTVisual.ITTLabel;
    labelPreInformation: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    labelSonAdetTarihi: TTVisual.ITTLabel;
    LabProcedure: TTVisual.ITTTextBoxColumn;
    LongReport: TTVisual.ITTRichTextBoxControlColumn;
    ozelDurum: TTVisual.ITTListBoxColumn;
    PatientAge: TTVisual.ITTTextBox;
    PatientGroup: TTVisual.ITTEnumComboBox;
    PatientSex: TTVisual.ITTEnumComboBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ReasonForAdmisson: TTVisual.ITTTextBox;
    Reference: TTVisual.ITTTextBoxColumn;
    requestDoctor: TTVisual.ITTObjectListBox;
    Result: TTVisual.ITTTextBoxColumn;
    ResultNote: TTVisual.ITTTextBoxColumn;
    SampleRejectReason: TTVisual.ITTTextBoxColumn;
    SonAdetTarihi: TTVisual.ITTDateTimePicker;
    SpecialReference: TTVisual.ITTRichTextBoxControlColumn;
    TabControlLabProcedures: TTVisual.ITTTabControl;
    TabForInformations: TTVisual.ITTTabControl;
    TabPageFutureRequest: TTVisual.ITTTabPage;
    TabPageLabProcedures: TTVisual.ITTTabPage;
    textBarcode: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel3drawgradient: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttobjectlistbox2: TTVisual.ITTObjectListBox;
    ttPrintResultReport: TTVisual.ITTButton;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttextBarcode: TTVisual.ITTTextBox;
    tttextbox1: TTVisual.ITTTextBox;
    Unit: TTVisual.ITTTextBoxColumn;
    Urgent: TTVisual.ITTCheckBox;
    Warning: TTVisual.ITTEnumComboBoxColumn;
    WorkListDate: TTVisual.ITTDateTimePicker;
    public GridLabProceduresColumns = [];
    public laboratoryRequestProcedureFormViewModel: LaboratoryRequestProcedureFormViewModel = new LaboratoryRequestProcedureFormViewModel();
    public get _LaboratoryRequest(): LaboratoryRequest {
        return this._TTObject as LaboratoryRequest;
    }
    private LaboratoryRequestProcedureForm_DocumentUrl: string = '/api/LaboratoryRequestService/LaboratoryRequestProcedureForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.LaboratoryRequestProcedureForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async cmdSendRequest_Click(): Promise<void> {
        if (this._LaboratoryRequest.LaboratoryProcedures.length === 0) {
            let message: string = (await SystemMessageService.GetMessage(198));
            TTVisual.InfoBox.Show(message);
            return;
        }
        // Cursor current = Cursor.Current;
        //  Cursor.Current = Cursors.WaitCursor;
        try {
            //let sysparam: string = (await SystemParameterService.GetParameterValue("LABINTEGRATED", null));
            ////if(this._LaboratoryRequest.IsRequestSent == true)
            ////{
            ////    TTVisual.InfoBox.Show("İstek zaten gönderilmiştir.");
            ////    return;
            ////}

            //if (sysparam === "TRUE") {
            //    let messageID: Guid = (await LaboratoryRequestService.SendToLabASync(this._LaboratoryRequest)); //Entegrasyon için.
            //    let context: TTObjectContext = new TTObjectContext(false);
            //    let request: LaboratoryRequest = <LaboratoryRequest>context.GetObject(this._LaboratoryRequest.ObjectID, "LaboratoryRequest");
            //    if(messageID != null)
            //        request.MessageID = messageID.toString();
            //    request.IsRequestSent = true;
            //    context.Save();
            //}
        }
        catch (ex) {
            TTVisual.InfoBox.Show(ex);
        }
        finally {

        }
    }
    public async GridLabProcedures_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.GridLabProcedures.CurrentCell !== null) {
            let procedure: LaboratoryProcedure = <LaboratoryProcedure>this.GridLabProcedures.CurrentCell.OwningRow.TTObject;
            // MT Çoklu özel durum düğmesi basılınca Çoklu özel durum formu açılır.

            //TODO:ShowEdit!
            //if (((ITTGridCell)GridLabProcedures.CurrentCell).OwningColumn.Name == "cokluOzelDurum")
            //{
            //    LaboratoryCokluOzelDurumForm lcodf = new LaboratoryCokluOzelDurumForm();
            //    lcodf.ShowEdit(this.FindForm(), procedure, true);
            //}

            switch (this.GridLabProcedures.CurrentCell.OwningColumn.Name) {
                case "cokluOzelDurum":
                    //TODO:ShowEdit!
                    //if (procedure.LaboratorySubProcedures.Count > 0)
                    //{
                    //    LaboratoryCokluOzelDurumForm lcod = new LaboratoryCokluOzelDurumForm();
                    //    lcod.ShowEdit(this.FindForm(), procedure, true);
                    //}
                    break;
                case "Detail":
                    //TODO:ShowEdit!
                    //if (procedure.LaboratorySubProcedures.Count > 0)
                    //{
                    //    LaboratoryProcedureDetailForm detailForm = new LaboratoryProcedureDetailForm();
                    //    detailForm.ShowEdit(this.FindForm(), procedure, true);
                    //}
                    break;
                case "Cancel":
                    // Rollback'li yapılacak
                    // Son test iptal edildiğinde bütün işlemi iptal etme veya bütün işlemi tamamlama yapılacak
                    //TODO:ShowEdit!
                    //DialogResult result = MessageBox.Show("Seçmiş olduğunuz tetkik iptal edilecektir.Devam etmek istiyor musunuz?", "İstek iptal ediliyor...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result == DialogResult.Yes)
                    //{

                    //    Cursor current = Cursor.Current;
                    //    Cursor.Current = Cursors.WaitCursor;
                    //    Guid savePoint = this._LaboratoryRequest.ObjectContext.BeginSavePoint();
                    //    try
                    //    {
                    //        bool hasUncompletedTest = false;
                    //        if (procedure.CurrentStateDefID == LaboratoryProcedure.States.SampleAccept || procedure.CurrentStateDefID == LaboratoryProcedure.States.New) //this._LaboratoryRequest.CurrentStateDefID == LaboratoryRequest.States.RequestAcception) //|| procedure.CurrentStateDefID == LaboratoryProcedure.States.Procedure)
                    //        {
                    //            if(this._LaboratoryRequest.CurrentStateDefID == LaboratoryRequest.States.RequestAcception || this._LaboratoryRequest.CurrentStateDefID == LaboratoryRequest.States.Procedure)
                    //            {
                    //                if (procedure.LaboratorySubProcedures.Count > 0)
                    //                {
                    //                    foreach (LaboratorySubProcedure subProcedure in procedure.LaboratorySubProcedures)
                    //                    {
                    //                        subProcedure.CurrentStateDefID = LaboratorySubProcedure.States.Cancelled;
                    //                        LaboratoryRequest.CancelLabSubProcedure(subProcedure);
                    //                    }

                    //                }
                    //                procedure.CurrentStateDefID = LaboratoryProcedure.States.Cancelled;
                    //                procedure.Update();
                    //                LaboratoryRequest.CancelLabProcedure(procedure);
                    //                //                                foreach (LaboratoryProcedure labProcedure in this._LaboratoryRequest.LaboratoryProcedures)
                    //                //                                {
                    //                //                                    if ((labProcedure.CurrentStateDefID != LaboratoryProcedure.States.Cancelled)
                    //                //                                        && (labProcedure.CurrentStateDefID != LaboratoryProcedure.States.Completed)
                    //                //                                        && (labProcedure.CurrentStateDefID != LaboratoryProcedure.States.SampleReject))
                    //                //                                    {
                    //                //                                        hasUncompletedTest = true;
                    //                //                                        break;
                    //                //                                    }
                    //                //                                }
                    //                //                                if (!hasUncompletedTest)
                    //                //                                {
                    //                //                                    this._LaboratoryRequest.CancelLab();
                    //                //                                    this._LaboratoryRequest.CurrentStateDefID = LaboratoryRequest.States.Cancelled;
                    //                //                                }
                    //                this._LaboratoryRequest.ObjectContext.Save();
                    //            }
                    //            else
                    //            {
                    //                InfoBox.Show("'İptal gerçekleştirilemez!\r\n \r\nİptal İçin Gerekli Laboratuvar Durumu : 'İstek Kabul' veya 'İşlemde' olmalıdır"
                    //                             +"\r\n Mevcut Laboratuvar Durumu : ' " + this._LaboratoryRequest.CurrentStateDef.DisplayText.Trim() + " '");
                    //            }
                    //        }
                    //        else
                    //        {
                    //            InfoBox.Show("'İptal gerçekleştirilemez!\r\n \r\nİptal İçin Gerekli Tetkik Durumu : 'Numune Kabul' veya 'İstek' olmalıdır"
                    //                         +"\r\n Mevcut Tetkik Durumu : ' " + procedure.CurrentStateDef.DisplayText.Trim() + " '");
                    //        }
                    //    }
                    //    catch
                    //    {
                    //        this._LaboratoryRequest.ObjectContext.RollbackSavePoint(savePoint);

                    //        if (procedure.LaboratorySubProcedures.Count > 0)
                    //        {
                    //            foreach (LaboratorySubProcedure subProcedure in procedure.LaboratorySubProcedures)
                    //            {
                    //                LaboratoryRequest.RollbackCancelLabSubProcedure(subProcedure);
                    //            }
                    //        }

                    //        LaboratoryRequest.RollbackCancelLabProcedure(procedure);

                    //        throw;
                    //    }
                    //    finally
                    //    {
                    //        Cursor.Current = current;
                    //    }
                    //}
                    break;
                default:
                    break;
            }
        }
    }
    public async ttPrintResultReport_Click(): Promise<void> {
       /*let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
        let cache1: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
        cache1.push("VALUE", this._LaboratoryRequest.ObjectID.toString());
        parameters.push("TTOBJECTID", cache1);
        if ((this._LaboratoryRequest.BarcodeID !== undefined)) {
            let cache: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
            cache.push("VALUE", this._LaboratoryRequest.BarcodeID.Value.toString());
            parameters.push("BARCODEID", cache);
        }
        try {
            //TODO:Cursor!
            //this.Cursor = Cursors.WaitCursor;

            TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_LaboratoryBarcodeResultReport, true, 1, parameters);
        }
        catch (ex) {
            //TODO:Cursor!
            //this.Cursor = Cursors.Default;
            TTVisual.InfoBox.Show(ex.toString(), MessageIconEnum.ErrorMessage);
        }
        finally {

        }
        */
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef !== null && transDef.ToStateDefID === LaboratoryRequest.LaboratoryRequestStates.Completed) {
            for (let labProc of this._LaboratoryRequest.LaboratoryProcedures) {
                if (labProc.CurrentStateDefID !== LaboratoryProcedure.LaboratoryProcedureStates.Cancelled && labProc.CurrentStateDefID !== LaboratoryProcedure.LaboratoryProcedureStates.SampleReject && labProc.CurrentStateDefID !== LaboratoryProcedure.LaboratoryProcedureStates.Completed && labProc.CurrentStateDefID !== LaboratoryProcedure.LaboratoryProcedureStates.PendingCancel) {
                    labProc.CurrentStateDefID = LaboratoryProcedure.LaboratoryProcedureStates.Cancelled;
                    this._LaboratoryRequest.ObjectContext.Save();
                }
            }
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
    }
    protected async PreScript() {
        super.PreScript();
        if (this._LaboratoryRequest.BarcodeID != null) {
            this.labelBarcode.Visible = true;
            this.textBarcode.Visible = true;
            this.textBarcode.Text = this._LaboratoryRequest.BarcodeID.toString();
        }
        if (this._LaboratoryRequest.CurrentStateDefID === LaboratoryRequest.LaboratoryRequestStates.Procedure) {
            this.DropStateButton(LaboratoryRequest.LaboratoryRequestStates.Rejected);
            this.DropStateButton(LaboratoryRequest.LaboratoryRequestStates.Cancelled);
            this.cmdSendRequest.Visible = false;
        }
        let labManualResultEntry: Guid = new Guid("08c98bd6-2e6d-4b8e-96ce-e09b69936b4a");
       /* if (this._LaboratoryRequest.CurrentStateDefID === LaboratoryRequest.LaboratoryRequestStates.RequestAcception && Common.CurrentUser.IsSuperUser === false) {
            if (!Common.CurrentUser.HasRole(labManualResultEntry)) {
                this.DropStateButton(LaboratoryRequest.LaboratoryRequestStates.Procedure);
            }
        }
        if (this._LaboratoryRequest.CurrentStateDefID === LaboratoryRequest.LaboratoryRequestStates.RequestAcception && Common.CurrentUser.IsSuperUser === false)
            this.DropStateButton(LaboratoryRequest.LaboratoryRequestStates.Completed);
        if (this._LaboratoryRequest.CurrentStateDefID === LaboratoryRequest.LaboratoryRequestStates.Procedure && Common.CurrentUser.IsSuperUser === false) {
            if (!Common.CurrentUser.HasRole(labManualResultEntry)) {
                this.DropStateButton(LaboratoryRequest.LaboratoryRequestStates.Completed);
            }
        }
        this.TabForInformations.HideTabPage(this.TabPageFutureRequest);
        */
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new LaboratoryRequest();
        this.laboratoryRequestProcedureFormViewModel = new LaboratoryRequestProcedureFormViewModel();
        this._ViewModel = this.laboratoryRequestProcedureFormViewModel;
        this.laboratoryRequestProcedureFormViewModel._LaboratoryRequest = this._TTObject as LaboratoryRequest;
        this.laboratoryRequestProcedureFormViewModel._LaboratoryRequest.LaboratoryProcedures = new Array<LaboratoryProcedure>();
        this.laboratoryRequestProcedureFormViewModel._LaboratoryRequest.RequestDoctor = new ResUser();
        this.laboratoryRequestProcedureFormViewModel._LaboratoryRequest.ApprovedBy = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.laboratoryRequestProcedureFormViewModel = this._ViewModel as LaboratoryRequestProcedureFormViewModel;
        that._TTObject = this.laboratoryRequestProcedureFormViewModel._LaboratoryRequest;
        if (this.laboratoryRequestProcedureFormViewModel == null)
            this.laboratoryRequestProcedureFormViewModel = new LaboratoryRequestProcedureFormViewModel();
        if (this.laboratoryRequestProcedureFormViewModel._LaboratoryRequest == null)
            this.laboratoryRequestProcedureFormViewModel._LaboratoryRequest = new LaboratoryRequest();
        that.laboratoryRequestProcedureFormViewModel._LaboratoryRequest.LaboratoryProcedures = that.laboratoryRequestProcedureFormViewModel.GridLabProceduresGridList;
        for (let detailItem of that.laboratoryRequestProcedureFormViewModel.GridLabProceduresGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.laboratoryRequestProcedureFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let sampleRejectionReasonObjectID = detailItem["SampleRejectionReason"];
            if (sampleRejectionReasonObjectID != null && (typeof sampleRejectionReasonObjectID === 'string')) {
                let sampleRejectionReason = that.laboratoryRequestProcedureFormViewModel.LaboratoryRejectReasonDefinitions.find(o => o.ObjectID.toString() === sampleRejectionReasonObjectID.toString());
                 if (sampleRejectionReason) {
                    detailItem.SampleRejectionReason = sampleRejectionReason;
                }
            }
            let anesteziDoktorObjectID = detailItem["AnesteziDoktor"];
            if (anesteziDoktorObjectID != null && (typeof anesteziDoktorObjectID === 'string')) {
                let anesteziDoktor = that.laboratoryRequestProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === anesteziDoktorObjectID.toString());
                 if (anesteziDoktor) {
                    detailItem.AnesteziDoktor = anesteziDoktor;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.laboratoryRequestProcedureFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
        let requestDoctorObjectID = that.laboratoryRequestProcedureFormViewModel._LaboratoryRequest["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
            let requestDoctor = that.laboratoryRequestProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
             if (requestDoctor) {
                that.laboratoryRequestProcedureFormViewModel._LaboratoryRequest.RequestDoctor = requestDoctor;
            }
        }
        let approvedByObjectID = that.laboratoryRequestProcedureFormViewModel._LaboratoryRequest["ApprovedBy"];
        if (approvedByObjectID != null && (typeof approvedByObjectID === 'string')) {
            let approvedBy = that.laboratoryRequestProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === approvedByObjectID.toString());
             if (approvedBy) {
                that.laboratoryRequestProcedureFormViewModel._LaboratoryRequest.ApprovedBy = approvedBy;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(LaboratoryRequestProcedureFormViewModel);
  
    }


    public onGebelikChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Pregnancy != event) {
                this._LaboratoryRequest.Pregnancy = event;
            }
        }
    }

    public onPatientAgeChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.PatientAge != event) {
                this._LaboratoryRequest.PatientAge = event;
            }
        }
    }

    public onPatientSexChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.PatientSex != event) {
                this._LaboratoryRequest.PatientSex = event;
            }
        }
    }

    public onrequestDoctorChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.RequestDoctor != event) {
                this._LaboratoryRequest.RequestDoctor = event;
            }
        }
    }

    public onSonAdetTarihiChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.LastMensturationDate != event) {
                this._LaboratoryRequest.LastMensturationDate = event;
            }
        }
    }

    public onttobjectlistbox2Changed(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.ApprovedBy != event) {
                this._LaboratoryRequest.ApprovedBy = event;
            }
        }
    }

    public ontttextBarcodeChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Notes != event) {
                this._LaboratoryRequest.Notes = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Prediagnosis != event) {
                this._LaboratoryRequest.Prediagnosis = event;
            }
        }
    }

    public onUrgentChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.Urgent != event) {
                this._LaboratoryRequest.Urgent = event;
            }
        }
    }

    public onWorkListDateChanged(event): void {
        if (event != null) {
            if (this._LaboratoryRequest != null && this._LaboratoryRequest.WorkListDate != event) {
                this._LaboratoryRequest.WorkListDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.PatientAge, "Text", this.__ttObject, "PatientAge");
        redirectProperty(this.PatientSex, "Value", this.__ttObject, "PatientSex");
        redirectProperty(this.Urgent, "Value", this.__ttObject, "Urgent");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Prediagnosis");
        redirectProperty(this.tttextBarcode, "Text", this.__ttObject, "Notes");
        redirectProperty(this.Gebelik, "Value", this.__ttObject, "Pregnancy");
        redirectProperty(this.SonAdetTarihi, "Value", this.__ttObject, "LastMensturationDate");
        redirectProperty(this.WorkListDate, "Value", this.__ttObject, "WorkListDate");
    }

    public initFormControls(): void {
        this.textBarcode = new TTVisual.TTTextBox();
        this.textBarcode.BackColor = "#F0F0F0";
        this.textBarcode.ReadOnly = true;
        this.textBarcode.Name = "textBarcode";
        this.textBarcode.TabIndex = 52;
        this.textBarcode.Visible = false;

        this.labelBarcode = new TTVisual.TTLabel();
        this.labelBarcode.Text = "BarkodNo:";
        this.labelBarcode.Name = "labelBarcode";
        this.labelBarcode.TabIndex = 51;
        this.labelBarcode.Visible = false;

        this.cmdSendRequest = new TTVisual.TTButton();
        this.cmdSendRequest.Text = i18n("M16599", "İsteği Tekrar Gönder");
        this.cmdSendRequest.Name = "cmdSendRequest";
        this.cmdSendRequest.TabIndex = 50;

        this.TabControlLabProcedures = new TTVisual.TTTabControl();
        this.TabControlLabProcedures.Name = "TabControlLabProcedures";
        this.TabControlLabProcedures.TabIndex = 0;

        this.TabPageLabProcedures = new TTVisual.TTTabPage();
        this.TabPageLabProcedures.DisplayIndex = 0;
        this.TabPageLabProcedures.BackColor = "#FFFFFF";
        this.TabPageLabProcedures.TabIndex = 0;
        this.TabPageLabProcedures.Text = i18n("M23341", "Tetkikler");
        this.TabPageLabProcedures.Name = "TabPageLabProcedures";

        this.GridLabProcedures = new TTVisual.TTGrid();
        this.GridLabProcedures.HideCancelledData = false;
        this.GridLabProcedures.AllowUserToDeleteRows = false;
        this.GridLabProcedures.Name = "GridLabProcedures";
        this.GridLabProcedures.TabIndex = 0;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 0;
        this.ProcedureObject.HeaderText = "Obje";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.Visible = false;
        this.ProcedureObject.Width = 100;

        this.LabProcedure = new TTVisual.TTTextBoxColumn();
        this.LabProcedure.DataMember = "Name";
        this.LabProcedure.DisplayIndex = 1;
        this.LabProcedure.HeaderText = "Test adı";
        this.LabProcedure.Name = "LabProcedure";
        this.LabProcedure.ReadOnly = true;
        this.LabProcedure.Width = 180;

        this.CurrentState = new TTVisual.TTStateComboBoxColumn();
        this.CurrentState.DataMember = "CURRENTSTATEDEFID";
        this.CurrentState.DisplayIndex = 2;
        this.CurrentState.HeaderText = i18n("M13372", "Durumu");
        this.CurrentState.Name = "CurrentState";
        this.CurrentState.ReadOnly = true;
        this.CurrentState.Width = 100;

        this.SampleRejectReason = new TTVisual.TTTextBoxColumn();
        this.SampleRejectReason.DataMember = "Reason";
        this.SampleRejectReason.DisplayIndex = 3;
        this.SampleRejectReason.HeaderText = i18n("M19545", "Numune Red Sebebi");
        this.SampleRejectReason.Name = "SampleRejectReason";
        this.SampleRejectReason.ReadOnly = true;
        this.SampleRejectReason.Width = 120;

        this.Result = new TTVisual.TTTextBoxColumn();
        this.Result.DataMember = "Result";
        this.Result.DisplayIndex = 4;
        this.Result.HeaderText = i18n("M22078", "Sonuç");
        this.Result.Name = "Result";
        this.Result.ReadOnly = true;
        this.Result.Width = 80;

        this.Warning = new TTVisual.TTEnumComboBoxColumn();
        this.Warning.DataTypeName = "HighLowEnum";
        this.Warning.DataMember = "Warning";
        this.Warning.DisplayIndex = 5;
        this.Warning.HeaderText = i18n("M21289", "Sapma");
        this.Warning.Name = "Warning";
        this.Warning.ReadOnly = true;
        this.Warning.Width = 80;

        this.Reference = new TTVisual.TTTextBoxColumn();
        this.Reference.DataMember = "Reference";
        this.Reference.DisplayIndex = 6;
        this.Reference.HeaderText = i18n("M21012", "Referans Değer");
        this.Reference.Name = "Reference";
        this.Reference.Width = 100;

        this.SpecialReference = new TTVisual.TTRichTextBoxControlColumn();
        this.SpecialReference.DisplayText = i18n("M20079", "Özel Değerler");
        this.SpecialReference.DataMember = "SpecialReference";
        this.SpecialReference.DisplayIndex = 7;
        this.SpecialReference.HeaderText = i18n("M20079", "Özel Değerler");
        this.SpecialReference.Name = "SpecialReference";
        this.SpecialReference.ReadOnly = true;
        this.SpecialReference.Width = 100;

        this.Unit = new TTVisual.TTTextBoxColumn();
        this.Unit.DataMember = "Unit";
        this.Unit.DisplayIndex = 8;
        this.Unit.HeaderText = "Birim";
        this.Unit.Name = "Unit";
        this.Unit.ReadOnly = true;
        this.Unit.Width = 80;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12672", "Detay Gir");
        this.Detail.DisplayIndex = 9;
        this.Detail.HeaderText = i18n("M12671", "Detay");
        this.Detail.Name = "Detail";
        this.Detail.Width = 50;

        this.Cancel = new TTVisual.TTButtonColumn();
        this.Cancel.Text = i18n("M16526", "İptal");
        this.Cancel.DisplayIndex = 10;
        this.Cancel.HeaderText = i18n("M16526", "İptal");
        this.Cancel.Name = "Cancel";
        this.Cancel.Width = 50;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DisplayIndex = 11;
        this.Amount.HeaderText = i18n("M12341", "Çarpan");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Visible = false;
        this.Amount.Width = 100;

        this.ResultNote = new TTVisual.TTTextBoxColumn();
        this.ResultNote.DataMember = "ResultDescription";
        this.ResultNote.DisplayIndex = 12;
        this.ResultNote.HeaderText = i18n("M10469", "Açıklama");
        this.ResultNote.Name = "ResultNote";
        this.ResultNote.Width = 160;

        this.LongReport = new TTVisual.TTRichTextBoxControlColumn();
        this.LongReport.DisplayText = "Rapor";
        this.LongReport.TemplateGroupName = "LABORATORY";
        this.LongReport.DataMember = "LongReport";
        this.LongReport.DisplayIndex = 13;
        this.LongReport.HeaderText = "Rapor";
        this.LongReport.Name = "LongReport";
        this.LongReport.Width = 60;

        this.islemTarihi = new TTVisual.TTDateTimePickerColumn();
        this.islemTarihi.DataMember = "ActionDate";
        this.islemTarihi.DisplayIndex = 14;
        this.islemTarihi.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.islemTarihi.Name = "islemTarihi";
        this.islemTarihi.Width = 100;

        this.drAnestezitescilNo = new TTVisual.TTListBoxColumn();
        this.drAnestezitescilNo.ListDefName = "ResUserListDefinition";
        this.drAnestezitescilNo.DataMember = "AnesteziDoktor";
        this.drAnestezitescilNo.DisplayIndex = 15;
        this.drAnestezitescilNo.HeaderText = i18n("M10967", "Anestezi Dr. Tescil No");
        this.drAnestezitescilNo.Name = "drAnestezitescilNo";
        this.drAnestezitescilNo.Width = 100;

        this.ozelDurum = new TTVisual.TTListBoxColumn();
        this.ozelDurum.ListDefName = "OzelDurumListDefinition";
        this.ozelDurum.DataMember = "OzelDurum";
        this.ozelDurum.DisplayIndex = 16;
        this.ozelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.ozelDurum.Name = "ozelDurum";
        this.ozelDurum.Width = 100;

        this.cokluOzelDurum = new TTVisual.TTButtonColumn();
        this.cokluOzelDurum.Text = i18n("M12418", "Çoklu Özel Durum");
        this.cokluOzelDurum.DisplayIndex = 17;
        this.cokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.cokluOzelDurum.Name = "cokluOzelDurum";
        this.cokluOzelDurum.Width = 100;

        this.TabForInformations = new TTVisual.TTTabControl();
        this.TabForInformations.Name = "TabForInformations";
        this.TabForInformations.TabIndex = 44;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M14681", "Genel Bilgiler");
        this.tttabpage1.Name = "tttabpage1";

        this.PatientGroup = new TTVisual.TTEnumComboBox();
        this.PatientGroup.DataTypeName = "PatientGroupEnum";
        this.PatientGroup.BackColor = "#F0F0F0";
        this.PatientGroup.Enabled = false;
        this.PatientGroup.Name = "PatientGroup";
        this.PatientGroup.TabIndex = 0;

        this.PatientSex = new TTVisual.TTEnumComboBox();
        this.PatientSex.DataTypeName = "SexEnum";
        this.PatientSex.BackColor = "#F0F0F0";
        this.PatientSex.Enabled = false;
        this.PatientSex.Name = "PatientSex";
        this.PatientSex.TabIndex = 3;

        this.PatientAge = new TTVisual.TTTextBox();
        this.PatientAge.BackColor = "#F0F0F0";
        this.PatientAge.ReadOnly = true;
        this.PatientAge.Name = "PatientAge";
        this.PatientAge.TabIndex = 2;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M12265", "Cinsiyet");
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 46;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M24340", "Yaş (Yıl-Ay-Gün)");
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 45;

        this.ReasonForAdmisson = new TTVisual.TTTextBox();
        this.ReasonForAdmisson.BackColor = "#F0F0F0";
        this.ReasonForAdmisson.ReadOnly = true;
        this.ReasonForAdmisson.Name = "ReasonForAdmisson";
        this.ReasonForAdmisson.TabIndex = 1;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M17026", "Kabul Sebebi");
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 43;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M15222", "Hasta Grubu");
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 42;

        this.labelPreInformation = new TTVisual.TTLabel();
        this.labelPreInformation.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.labelPreInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPreInformation.ForeColor = "#000000";
        this.labelPreInformation.Name = "labelPreInformation";
        this.labelPreInformation.TabIndex = 37;

        this.Urgent = new TTVisual.TTCheckBox();
        this.Urgent.Value = false;
        this.Urgent.Text = "Acil";
        this.Urgent.Name = "Urgent";
        this.Urgent.TabIndex = 8;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M19476", "Not");
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 40;

        this.tttextBarcode = new TTVisual.TTTextBox();
        this.tttextBarcode.Multiline = true;
        this.tttextBarcode.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextBarcode.Name = "tttextBarcode";
        this.tttextBarcode.TabIndex = 5;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 4;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 3;
        this.tttabpage2.Text = i18n("M13517", "Ek Bilgiler");
        this.tttabpage2.Name = "tttabpage2";

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 41;

        this.requestDoctor = new TTVisual.TTObjectListBox();
        this.requestDoctor.ListDefName = "UserListDefinition";
        this.requestDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.requestDoctor.Name = "requestDoctor";
        this.requestDoctor.TabIndex = 42;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M19713", "Onaylayan Uzman");
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 41;

        this.ttobjectlistbox2 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox2.ListDefName = "UserListDefinition";
        this.ttobjectlistbox2.Name = "ttobjectlistbox2";
        this.ttobjectlistbox2.TabIndex = 43;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 2;
        this.tttabpage3.BackColor = "#FFFFFF";
        this.tttabpage3.TabIndex = 1;
        this.tttabpage3.Text = "Gebelik - S.A.T";
        this.tttabpage3.Name = "tttabpage3";

        this.Gebelik = new TTVisual.TTEnumComboBox();
        this.Gebelik.DataTypeName = "LaboratoryPregnancyEnum";
        this.Gebelik.Name = "Gebelik";
        this.Gebelik.TabIndex = 52;

        this.SonAdetTarihi = new TTVisual.TTDateTimePicker();
        this.SonAdetTarihi.Format = DateTimePickerFormat.Long;
        this.SonAdetTarihi.Name = "SonAdetTarihi";
        this.SonAdetTarihi.TabIndex = 54;

        this.labelSonAdetTarihi = new TTVisual.TTLabel();
        this.labelSonAdetTarihi.Text = i18n("M22037", "Son Adet Tarihi");
        this.labelSonAdetTarihi.ForeColor = "#000080";
        this.labelSonAdetTarihi.Name = "labelSonAdetTarihi";
        this.labelSonAdetTarihi.TabIndex = 55;

        this.labelGebelik = new TTVisual.TTLabel();
        this.labelGebelik.Text = "Gebelik";
        this.labelGebelik.ForeColor = "#000080";
        this.labelGebelik.Name = "labelGebelik";
        this.labelGebelik.TabIndex = 53;

        this.TabPageFutureRequest = new TTVisual.TTTabPage();
        this.TabPageFutureRequest.DisplayIndex = 3;
        this.TabPageFutureRequest.BackColor = "#FFFFFF";
        this.TabPageFutureRequest.TabIndex = 2;
        this.TabPageFutureRequest.Text = i18n("M16404", "İleri Tarihli İstek");
        this.TabPageFutureRequest.Visible = false;
        this.TabPageFutureRequest.Name = "TabPageFutureRequest";

        this.WorkListDate = new TTVisual.TTDateTimePicker();
        this.WorkListDate.CustomFormat = "DD.MM.YYYY hh:mi";
        this.WorkListDate.Format = DateTimePickerFormat.Long;
        this.WorkListDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.WorkListDate.Name = "WorkListDate";
        this.WorkListDate.TabIndex = 32;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = i18n("M16773", "İş Listesine Gelme Tarihi");
        this.labelProcessTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 33;

        this.ttlabel3drawgradient = new TTVisual.TTLabel();
        this.ttlabel3drawgradient.Name = "ttlabel3drawgradient";
        this.ttlabel3drawgradient.TabIndex = 45;

        this.ttPrintResultReport = new TTVisual.TTButton();
        this.ttPrintResultReport.BackColor = "#FFFAF0";
        this.ttPrintResultReport.Text = i18n("M18228", "Laboratuvar Sonuç Raporu");
        this.ttPrintResultReport.Name = "ttPrintResultReport";
        this.ttPrintResultReport.TabIndex = 53;

        this.GridLabProceduresColumns = [this.ProcedureObject, this.LabProcedure, this.CurrentState, this.SampleRejectReason, this.Result, this.Warning, this.Reference, this.SpecialReference, this.Unit, this.Detail, this.Cancel, this.Amount, this.ResultNote, this.LongReport, this.islemTarihi, this.drAnestezitescilNo, this.ozelDurum, this.cokluOzelDurum];
        this.TabControlLabProcedures.Controls = [this.TabPageLabProcedures];
        this.TabPageLabProcedures.Controls = [this.GridLabProcedures];
        this.TabForInformations.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3, this.TabPageFutureRequest];
        this.tttabpage1.Controls = [this.PatientGroup, this.PatientSex, this.PatientAge, this.ttlabel6, this.ttlabel5, this.ReasonForAdmisson, this.ttlabel4, this.ttlabel3, this.labelPreInformation, this.Urgent, this.ttlabel1, this.tttextBarcode, this.tttextbox1];
        this.tttabpage2.Controls = [this.ttlabel2, this.requestDoctor, this.ttlabel8, this.ttobjectlistbox2];
        this.tttabpage3.Controls = [this.Gebelik, this.SonAdetTarihi, this.labelSonAdetTarihi, this.labelGebelik];
        this.TabPageFutureRequest.Controls = [this.WorkListDate, this.labelProcessTime];
        this.Controls = [this.textBarcode, this.labelBarcode, this.cmdSendRequest, this.TabControlLabProcedures, this.TabPageLabProcedures, this.GridLabProcedures, this.ProcedureObject, this.LabProcedure, this.CurrentState, this.SampleRejectReason, this.Result, this.Warning, this.Reference, this.SpecialReference, this.Unit, this.Detail, this.Cancel, this.Amount, this.ResultNote, this.LongReport, this.islemTarihi, this.drAnestezitescilNo, this.ozelDurum, this.cokluOzelDurum, this.TabForInformations, this.tttabpage1, this.PatientGroup, this.PatientSex, this.PatientAge, this.ttlabel6, this.ttlabel5, this.ReasonForAdmisson, this.ttlabel4, this.ttlabel3, this.labelPreInformation, this.Urgent, this.ttlabel1, this.tttextBarcode, this.tttextbox1, this.tttabpage2, this.ttlabel2, this.requestDoctor, this.ttlabel8, this.ttobjectlistbox2, this.tttabpage3, this.Gebelik, this.SonAdetTarihi, this.labelSonAdetTarihi, this.labelGebelik, this.TabPageFutureRequest, this.WorkListDate, this.labelProcessTime, this.ttlabel3drawgradient, this.ttPrintResultReport];

    }


}
