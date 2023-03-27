//$30B9AC91
import { Component, OnInit, NgZone } from '@angular/core';
import { BloodProductRequestFormViewModel } from './BloodProductRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BloodBankBloodProducts } from 'NebulaClient/Model/AtlasClientModel';
import { BloodProductRequest } from 'NebulaClient/Model/AtlasClientModel';
import { BloodProductRequestService } from "ObjectClassService/BloodProductRequestService";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'BloodProductRequestForm',
    templateUrl: './BloodProductRequestForm.html',
    providers: [MessageService]
})
export class BloodProductRequestForm extends EpisodeActionForm implements OnInit {
    chkBlock: TTVisual.ITTCheckBox;
    chkFilter: TTVisual.ITTCheckBoxColumn;
    chkHB: TTVisual.ITTCheckBox;
    chkIsinlama: TTVisual.ITTCheckBoxColumn;
    chkNormal: TTVisual.ITTCheckBox;
    chkOther: TTVisual.ITTCheckBox;
    chkPregnancy: TTVisual.ITTCheckBox;
    chkPrepare: TTVisual.ITTCheckBox;
    chkSurgery: TTVisual.ITTCheckBox;
    chkTransfused: TTVisual.ITTCheckBox;
    chkUrgent: TTVisual.ITTCheckBox;
    chkUrgentCross: TTVisual.ITTCheckBox;
    chkWithoutCross: TTVisual.ITTCheckBox;
    chkWithoutTests: TTVisual.ITTCheckBox;
    chkWithTest: TTVisual.ITTCheckBox;
    dtPregnancy: TTVisual.ITTDateTimePicker;
    dtRequirement: TTVisual.ITTDateTimePicker;
    dtTransfused: TTVisual.ITTDateTimePicker;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    OzelDurum: TTVisual.ITTListBoxColumn;
    pnlUrgent: TTVisual.ITTPanel;
    ttcheckbox4: TTVisual.ITTCheckBox;
    ttcheckbox5: TTVisual.ITTCheckBox;
    ttgrid1: TTVisual.ITTGrid;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlistbox1: TTVisual.ITTListBoxColumn;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    txtAmount: TTVisual.ITTTextBoxColumn;
    public GridEpisodeDiagnosisColumns = [];
    public ttgrid1Columns = [];
    public bloodProductRequestFormViewModel: BloodProductRequestFormViewModel = new BloodProductRequestFormViewModel();
    public get _BloodProductRequest(): BloodProductRequest {
        return this._TTObject as BloodProductRequest;
    }
    private BloodProductRequestForm_DocumentUrl: string = '/api/BloodProductRequestService/BloodProductRequestForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BloodProductRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async chkBlock_CheckedChanged(): Promise<void> {
        if (this.chkBlock.Value !== null) {
            if (<boolean>this.chkBlock.Value) {
                this.chkPrepare.Value = false;
            }
        }
    }
    private async chkHB_CheckedChanged(): Promise<void> {
        if (this.chkHB.Value !== null) {
            if (<boolean>this.chkHB.Value) {
                this.chkSurgery.Value = false;
                this.chkOther.Value = false;
            }
        }
    }
    private async chkNormal_CheckedChanged(): Promise<void> {
        if (this.chkNormal.Value !== null) {
            if (<boolean>this.chkNormal.Value) {
                this.chkWithoutCross.Value = false;
                this.chkUrgentCross.Value = false;
            }
        }
    }
    private async chkOther_CheckedChanged(): Promise<void> {
        if (this.chkOther.Value !== null) {
            if (<boolean>this.chkOther.Value) {
                this.chkSurgery.Value = false;
                this.chkHB.Value = false;
            }
        }
    }
    private async chkPregnancy_CheckedChanged(): Promise<void> {
        if (this.chkPregnancy.Value !== null) {
            if (<boolean>this.chkPregnancy.Value) {
                this.dtPregnancy.Enabled = true;
            }
            else {
                this.dtPregnancy.Enabled = false;
            }
        }
    }
    private async chkPrepare_CheckedChanged(): Promise<void> {
        if (this.chkPrepare.Value !== null) {
            if (<boolean>this.chkPrepare.Value) {
                this.chkBlock.Value = false;
            }
        }
    }
    private async chkSurgery_CheckedChanged(): Promise<void> {
        if (this.chkSurgery.Value !== null) {
            if (<boolean>this.chkSurgery.Value) {
                this.chkHB.Value = false;
                this.chkOther.Value = false;
            }
        }
    }
    private async chkTransfused_CheckedChanged(): Promise<void> {
        if (this.chkTransfused.Value !== null) {
            if (<boolean>this.chkTransfused.Value) {
                this.dtTransfused.Enabled = true;
            }
            else {
                this.dtTransfused.Enabled = false;
            }
        }
    }
    private async chkUrgent_CheckedChanged(): Promise<void> {
        if (this.chkUrgent.Value !== null) {
            if (<boolean>this.chkUrgent.Value) {
                this.pnlUrgent.Visible = true;
            }
            else {
                this.pnlUrgent.Visible = false;
            }
        }
    }
    private async chkUrgentCross_CheckedChanged(): Promise<void> {
        if (this.chkUrgentCross.Value !== null) {
            if (<boolean>this.chkUrgentCross.Value) {
                this.chkWithoutCross.Value = false;
                this.chkNormal.Value = false;
            }
        }
    }
    private async chkWithoutCross_CheckedChanged(): Promise<void> {
        if (this.chkWithoutCross.Value !== null) {
            if (<boolean>this.chkWithoutCross.Value) {
                this.chkNormal.Value = false;
                this.chkUrgentCross.Value = false;
            }
        }
    }
    private async chkWithoutTests_CheckedChanged(): Promise<void> {
        if (this.chkWithoutTests.Value !== null) {
            if (<boolean>this.chkWithoutTests.Value) {
                this.chkWithTest.Value = false;
            }
        }
    }
    private async chkWithTest_CheckedChanged(): Promise<void> {
        if (this.chkWithTest.Value !== null) {
            if (<boolean>this.chkWithTest.Value) {
                this.chkWithoutTests.Value = false;
            }
        }
    }
    private async ttgrid1_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        //TODO:ShowEdit
        //if ((((ITTGridCell)ttgrid1.CurrentCell).OwningColumn != null) && (((ITTGridCell)ttgrid1.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
        //         {
        //             BloodBankBloodProducts_CokluOzelDurumForm codf = new BloodBankBloodProducts_CokluOzelDurumForm();
        //             BloodBankBloodProducts inp = (BloodBankBloodProducts)ttgrid1.CurrentCell.OwningRow.TTObject;
        //             codf.ShowEdit(this.FindForm(), inp);
        //         }
        let a = 1;
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        //Cursor current = Cursor.Current;
        //Cursor.Current = Cursors.WaitCursor;
        try {
            (await BloodProductRequestService.SendToBloodBank(this._BloodProductRequest)); //Entegrasyon için.
        }
        catch (ex) {
            throw ex;
        }
        finally {

        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        //COMPILE icin kapatildi. ayrica HBYS den istem LIS tarafindan  tetiklenecegi icin bu kod calistirilmayacak.
        //super.PostScript(transDef);
        //let oContext: TTObjectContext = this._BloodProductRequest.ObjectContext;
        //let liste: Array<BloodBankBloodProducts> = new Array<BloodBankBloodProducts>();
        //for (let productitem of this._BloodProductRequest.BloodProducts) {
        //    liste.push(productitem);
        //}
        //for (let product of liste) {
        //    if (product instanceof BloodBankBloodProducts) {
        //        let cloneCount: number = <number>product.Amount - 1;
        //        product.Amount = 1;

        //        for (let i: number = 0; i < cloneCount; i++) {
        //            let cloneProduct: BloodBankBloodProducts = null;
        //            cloneProduct = <BloodBankBloodProducts>product.Clone();
        //            //cloneProduct.EpisodeAction = product.EpisodeAction;
        //            TTSequence.allowSetSequenceValue = true;
        //            cloneProduct.ID.SetSequenceValue(0);
        //            cloneProduct.ID.GetNextValue();
        //            if (cloneProduct.IsIsinlama === true) {
        //                let subProduct: BloodBankSubProduct = new BloodBankSubProduct(oContext);
        //                let testDef: BloodBankTestDefinition = <BloodBankTestDefinition>oContext.GetObject(new Guid('392b0f3c-157c-4871-a7c3-694132300206'), 'BLOODBANKTESTDEFINITION');
        //                subProduct.ProcedureObject = testDef;
        //                subProduct.MasterResource = product.MasterResource;
        //                subProduct.FromResource = product.FromResource;
        //                subProduct.EpisodeAction = product.EpisodeAction;
        //                cloneProduct.BloodBankSubProducts.push(subProduct);
        //            }
        //            this._BloodProductRequest.BloodProducts.push(cloneProduct);
        //        }
        //        if (product.IsIsinlama === true) {
        //            let subProduct: BloodBankSubProduct = new BloodBankSubProduct(oContext);
        //            let testDef: BloodBankTestDefinition = <BloodBankTestDefinition>oContext.GetObject(new Guid('392b0f3c-157c-4871-a7c3-694132300206'), 'BLOODBANKTESTDEFINITION');
        //            subProduct.ProcedureObject = testDef;
        //            subProduct.MasterResource = product.MasterResource;
        //            subProduct.FromResource = product.FromResource;
        //            subProduct.EpisodeAction = product.EpisodeAction;
        //            product.BloodBankSubProducts.push(subProduct);
        //        }
        //    }
        //}
        //oContext.Save();
    }
    protected async PreScript(): Promise<void> {
        //super.PreScript();
        //this._BloodProductRequest.RequestDoctor = Common.CurrentResource;
        //this.DropStateButton(BloodProductRequest.BloodProductRequestStates.BloodProductSupply);
        //this.cmdOK.Visible = false;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BloodProductRequest();
        this.bloodProductRequestFormViewModel = new BloodProductRequestFormViewModel();
        this._ViewModel = this.bloodProductRequestFormViewModel;
        this.bloodProductRequestFormViewModel._BloodProductRequest = this._TTObject as BloodProductRequest;
        this.bloodProductRequestFormViewModel._BloodProductRequest.Episode = new Episode();
        this.bloodProductRequestFormViewModel._BloodProductRequest.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.bloodProductRequestFormViewModel._BloodProductRequest.BloodProducts = new Array<BloodBankBloodProducts>();
    }

    protected loadViewModel() {
        let that = this;

        that.bloodProductRequestFormViewModel = this._ViewModel as BloodProductRequestFormViewModel;
        that._TTObject = this.bloodProductRequestFormViewModel._BloodProductRequest;
        if (this.bloodProductRequestFormViewModel == null)
            this.bloodProductRequestFormViewModel = new BloodProductRequestFormViewModel();
        if (this.bloodProductRequestFormViewModel._BloodProductRequest == null)
            this.bloodProductRequestFormViewModel._BloodProductRequest = new BloodProductRequest();
        let episodeObjectID = that.bloodProductRequestFormViewModel._BloodProductRequest["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.bloodProductRequestFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.bloodProductRequestFormViewModel._BloodProductRequest.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.bloodProductRequestFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.bloodProductRequestFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.bloodProductRequestFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.bloodProductRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                         if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        that.bloodProductRequestFormViewModel._BloodProductRequest.BloodProducts = that.bloodProductRequestFormViewModel.ttgrid1GridList;
        for (let detailItem of that.bloodProductRequestFormViewModel.ttgrid1GridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.bloodProductRequestFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.bloodProductRequestFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                 if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BloodProductRequestFormViewModel);
  
    }


    public onchkBlockChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsBlock != event) {
                this._BloodProductRequest.IsBlock = event;
            }
        }
        this.chkBlock_CheckedChanged();
    }

    public onchkHBChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsHB != event) {
                this._BloodProductRequest.IsHB = event;
            }
        }
        this.chkHB_CheckedChanged();
    }

    public onchkNormalChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsNormalCross != event) {
                this._BloodProductRequest.IsNormalCross = event;
            }
        }
        this.chkNormal_CheckedChanged();
    }

    public onchkOtherChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsOtherReason != event) {
                this._BloodProductRequest.IsOtherReason = event;
            }
        }
        this.chkOther_CheckedChanged();
    }

    public onchkPregnancyChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsPregnancy != event) {
                this._BloodProductRequest.IsPregnancy = event;
            }
        }
        this.chkPregnancy_CheckedChanged();
    }

    public onchkPrepareChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsPrepared != event) {
                this._BloodProductRequest.IsPrepared = event;
            }
        }
        this.chkPrepare_CheckedChanged();
    }

    public onchkSurgeryChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsSurgery != event) {
                this._BloodProductRequest.IsSurgery = event;
            }
        }
        this.chkSurgery_CheckedChanged();
    }

    public onchkTransfusedChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsTransfused != event) {
                this._BloodProductRequest.IsTransfused = event;
            }
        }
        this.chkTransfused_CheckedChanged();
    }

    public onchkUrgentChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsUrgent != event) {
                this._BloodProductRequest.IsUrgent = event;
            }
        }
        this.chkUrgent_CheckedChanged();
    }

    public onchkUrgentCrossChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsUrgentCross != event) {
                this._BloodProductRequest.IsUrgentCross = event;
            }
        }
        this.chkUrgentCross_CheckedChanged();
    }

    public onchkWithoutCrossChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsWithoutCross != event) {
                this._BloodProductRequest.IsWithoutCross = event;
            }
        }
        this.chkWithoutCross_CheckedChanged();
    }

    public onchkWithoutTestsChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsWithoutTests != event) {
                this._BloodProductRequest.IsWithoutTests = event;
            }
        }
        this.chkWithoutTests_CheckedChanged();
    }

    public onchkWithTestChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsWithTests != event) {
                this._BloodProductRequest.IsWithTests = event;
            }
        }
        this.chkWithTest_CheckedChanged();
    }

    public ondtPregnancyChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.PregnancyDate != event) {
                this._BloodProductRequest.PregnancyDate = event;
            }
        }
    }

    public ondtRequirementChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.RequirementDate != event) {
                this._BloodProductRequest.RequirementDate = event;
            }
        }
    }

    public ondtTransfusedChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.TransfusedDate != event) {
                this._BloodProductRequest.TransfusedDate = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.chkTransfused, "Value", this.__ttObject, "IsTransfused");
        redirectProperty(this.dtTransfused, "Value", this.__ttObject, "TransfusedDate");
        redirectProperty(this.dtRequirement, "Value", this.__ttObject, "RequirementDate");
        redirectProperty(this.chkPregnancy, "Value", this.__ttObject, "IsPregnancy");
        redirectProperty(this.dtPregnancy, "Value", this.__ttObject, "PregnancyDate");
        redirectProperty(this.chkSurgery, "Value", this.__ttObject, "IsSurgery");
        redirectProperty(this.chkHB, "Value", this.__ttObject, "IsHB");
        redirectProperty(this.chkOther, "Value", this.__ttObject, "IsOtherReason");
        redirectProperty(this.chkPrepare, "Value", this.__ttObject, "IsPrepared");
        redirectProperty(this.chkBlock, "Value", this.__ttObject, "IsBlock");
        redirectProperty(this.chkUrgent, "Value", this.__ttObject, "IsUrgent");
        redirectProperty(this.chkNormal, "Value", this.__ttObject, "IsNormalCross");
        redirectProperty(this.chkWithoutCross, "Value", this.__ttObject, "IsWithoutCross");
        redirectProperty(this.chkUrgentCross, "Value", this.__ttObject, "IsUrgentCross");
        redirectProperty(this.chkWithoutTests, "Value", this.__ttObject, "IsWithoutTests");
        redirectProperty(this.chkWithTest, "Value", this.__ttObject, "IsWithTests");
    }

    public initFormControls(): void {
        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.RowHeadersVisible = false;
        this.GridEpisodeDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 4;

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
        this.EpisodeDiagnose.Width = 360;

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
        this.EntryActionType.Width = 150;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M17215", "Kan Ürün Özellikleri");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 10;

        this.pnlUrgent = new TTVisual.TTPanel();
        this.pnlUrgent.AutoSize = true;
        this.pnlUrgent.Name = "pnlUrgent";
        this.pnlUrgent.TabIndex = 23;
        this.pnlUrgent.Visible = false;

        this.chkWithTest = new TTVisual.TTCheckBox();
        this.chkWithTest.Value = false;
        this.chkWithTest.Text = i18n("M15587", "HbsAg, Anti HCV, Anti HIV, VDRL testleri hızlı tanı kitleri ile yapılarak");
        this.chkWithTest.Name = "chkWithTest";
        this.chkWithTest.TabIndex = 4;

        this.chkWithoutTests = new TTVisual.TTCheckBox();
        this.chkWithoutTests.Value = false;
        this.chkWithoutTests.Text = i18n("M15588", "HbsAg, Anti HCV, Anti HIV, VDRL testleri tamamlanmadan");
        this.chkWithoutTests.Name = "chkWithoutTests";
        this.chkWithoutTests.TabIndex = 3;

        this.chkUrgentCross = new TTVisual.TTCheckBox();
        this.chkUrgentCross.Value = false;
        this.chkUrgentCross.Text = i18n("M10421", "Acil Cross - Match Yapılarak");
        this.chkUrgentCross.Name = "chkUrgentCross";
        this.chkUrgentCross.TabIndex = 2;

        this.chkWithoutCross = new TTVisual.TTCheckBox();
        this.chkWithoutCross.Value = false;
        this.chkWithoutCross.Text = i18n("M12291", "Cross - Match Yapılmadan");
        this.chkWithoutCross.Name = "chkWithoutCross";
        this.chkWithoutCross.TabIndex = 1;

        this.chkNormal = new TTVisual.TTCheckBox();
        this.chkNormal.Value = false;
        this.chkNormal.Text = i18n("M19460", "Normal Cross Yapılarak");
        this.chkNormal.Name = "chkNormal";
        this.chkNormal.TabIndex = 0;

        this.dtTransfused = new TTVisual.TTDateTimePicker();
        this.dtTransfused.Format = DateTimePickerFormat.Long;
        this.dtTransfused.Name = "dtTransfused";
        this.dtTransfused.TabIndex = 22;

        this.dtPregnancy = new TTVisual.TTDateTimePicker();
        this.dtPregnancy.Format = DateTimePickerFormat.Long;
        this.dtPregnancy.Name = "dtPregnancy";
        this.dtPregnancy.TabIndex = 21;

        this.chkBlock = new TTVisual.TTCheckBox();
        this.chkBlock.Value = false;
        this.chkBlock.Text = i18n("M11960", "Bloke edilecek");
        this.chkBlock.Name = "chkBlock";
        this.chkBlock.TabIndex = 20;

        this.chkOther = new TTVisual.TTCheckBox();
        this.chkOther.Value = false;
        this.chkOther.Text = i18n("M12780", "Diğer");
        this.chkOther.Name = "chkOther";
        this.chkOther.TabIndex = 19;

        this.chkHB = new TTVisual.TTCheckBox();
        this.chkHB.Value = false;
        this.chkHB.Text = i18n("M15586", "Hb Yükseltme");
        this.chkHB.Name = "chkHB";
        this.chkHB.TabIndex = 18;

        this.chkPrepare = new TTVisual.TTCheckBox();
        this.chkPrepare.Value = false;
        this.chkPrepare.Text = i18n("M15577", "Hazırlanacak");
        this.chkPrepare.Name = "chkPrepare";
        this.chkPrepare.TabIndex = 17;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M17235", "Kanın hazırlanma durumu");
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 16;

        this.chkSurgery = new TTVisual.TTCheckBox();
        this.chkSurgery.Value = false;
        this.chkSurgery.Text = "Ameliyat";
        this.chkSurgery.Name = "chkSurgery";
        this.chkSurgery.TabIndex = 15;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M17234", "Kanın hangi amaçla istendiği");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 14;

        this.chkPregnancy = new TTVisual.TTCheckBox();
        this.chkPregnancy.Value = false;
        this.chkPregnancy.Text = i18n("M14018", "Evet");
        this.chkPregnancy.Name = "chkPregnancy";
        this.chkPregnancy.TabIndex = 13;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M14568", "Gebelik Öyküsü (Önceki Gebelikler)");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 12;

        this.chkTransfused = new TTVisual.TTCheckBox();
        this.chkTransfused.Value = false;
        this.chkTransfused.Text = i18n("M14018", "Evet");
        this.chkTransfused.Name = "chkTransfused";
        this.chkTransfused.TabIndex = 11;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M12465", "Daha önce transfüzyon yapıldı mı?");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 10;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 3;
        this.tttextbox1.Visible = false;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M17197", "Kan Grubu");
        this.ttlabel2.BackColor = "#F0F0F0";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 2;
        this.ttlabel2.Visible = false;

        this.chkUrgent = new TTVisual.TTCheckBox();
        this.chkUrgent.Value = false;
        this.chkUrgent.Text = "Acil";
        this.chkUrgent.Name = "chkUrgent";
        this.chkUrgent.TabIndex = 5;

        this.ttcheckbox4 = new TTVisual.TTCheckBox();
        this.ttcheckbox4.Value = false;
        this.ttcheckbox4.Text = i18n("M17236", "Kanın hazırlanmasını istiyorum");
        this.ttcheckbox4.Name = "ttcheckbox4";
        this.ttcheckbox4.TabIndex = 8;
        this.ttcheckbox4.Visible = false;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M14746", "Gereksinim Tarihi");
        this.ttlabel1.BackColor = "#F0F0F0";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 1;

        this.ttcheckbox5 = new TTVisual.TTCheckBox();
        this.ttcheckbox5.Value = false;
        this.ttcheckbox5.Text = i18n("M15518", "Hastaya kullanmak için istiyorum");
        this.ttcheckbox5.Name = "ttcheckbox5";
        this.ttcheckbox5.TabIndex = 9;
        this.ttcheckbox5.Visible = false;

        this.dtRequirement = new TTVisual.TTDateTimePicker();
        this.dtRequirement.CustomFormat = "";
        this.dtRequirement.Format = DateTimePickerFormat.Long;
        this.dtRequirement.Name = "dtRequirement";
        this.dtRequirement.TabIndex = 0;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 4;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M16711", "İstenen Kan Ürünü");
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.ttgrid1 = new TTVisual.TTGrid();
        this.ttgrid1.Required = true;
        this.ttgrid1.AllowUserToDeleteRows = false;
        this.ttgrid1.AllowUserToOrderColumns = true;
        this.ttgrid1.Name = "ttgrid1";
        this.ttgrid1.TabIndex = 0;

        this.ttlistbox1 = new TTVisual.TTListBoxColumn();
        this.ttlistbox1.ListDefName = "BloodBankBloodProductsList";
        this.ttlistbox1.DataMember = "ProcedureObject";
        this.ttlistbox1.DisplayIndex = 0;
        this.ttlistbox1.HeaderText = i18n("M17221", "Kan Ürünü");
        this.ttlistbox1.Name = "ttlistbox1";
        this.ttlistbox1.Width = 400;

        this.txtAmount = new TTVisual.TTTextBoxColumn();
        this.txtAmount.DataMember = "Amount";
        this.txtAmount.DisplayIndex = 1;
        this.txtAmount.HeaderText = i18n("M19030", "Miktar");
        this.txtAmount.Name = "txtAmount";
        this.txtAmount.Width = 100;

        this.chkIsinlama = new TTVisual.TTCheckBoxColumn();
        this.chkIsinlama.DataMember = "IsIsinlama";
        this.chkIsinlama.DisplayIndex = 2;
        this.chkIsinlama.HeaderText = i18n("M16033", "Işınlanmalı");
        this.chkIsinlama.Name = "chkIsinlama";
        this.chkIsinlama.Visible = false;
        this.chkIsinlama.Width = 70;

        this.chkFilter = new TTVisual.TTCheckBoxColumn();
        this.chkFilter.DataMember = "IsFilter";
        this.chkFilter.DisplayIndex = 3;
        this.chkFilter.HeaderText = i18n("M14290", "Filtrelenmeli");
        this.chkFilter.Name = "chkFilter";
        this.chkFilter.Visible = false;
        this.chkFilter.Width = 80;

        this.OzelDurum = new TTVisual.TTListBoxColumn();
        this.OzelDurum.ListDefName = "OzelDurumListDefinition";
        this.OzelDurum.DataMember = "OzelDurum";
        this.OzelDurum.DisplayIndex = 4;
        this.OzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.OzelDurum.Name = "OzelDurum";
        this.OzelDurum.Width = 100;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M17197", "Kan Grubu");
        this.ttlabel3.BackColor = "#F0F0F0";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 2;

        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.ttgrid1Columns = [this.ttlistbox1, this.txtAmount, this.chkIsinlama, this.chkFilter, this.OzelDurum];
        this.ttgroupbox1.Controls = [this.pnlUrgent, this.dtTransfused, this.dtPregnancy, this.chkBlock, this.chkOther, this.chkHB, this.chkPrepare, this.ttlabel7, this.chkSurgery, this.ttlabel6, this.chkPregnancy, this.ttlabel5, this.chkTransfused, this.ttlabel4, this.tttextbox1, this.ttlabel2, this.chkUrgent, this.ttcheckbox4, this.ttlabel1, this.ttcheckbox5, this.dtRequirement];
        this.pnlUrgent.Controls = [this.chkWithTest, this.chkWithoutTests, this.chkUrgentCross, this.chkWithoutCross, this.chkNormal];
        this.tttabcontrol1.Controls = [this.tttabpage1];
        this.tttabpage1.Controls = [this.ttgrid1];
        this.Controls = [this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ttgroupbox1, this.pnlUrgent, this.chkWithTest, this.chkWithoutTests, this.chkUrgentCross, this.chkWithoutCross, this.chkNormal, this.dtTransfused, this.dtPregnancy, this.chkBlock, this.chkOther, this.chkHB, this.chkPrepare, this.ttlabel7, this.chkSurgery, this.ttlabel6, this.chkPregnancy, this.ttlabel5, this.chkTransfused, this.ttlabel4, this.tttextbox1, this.ttlabel2, this.chkUrgent, this.ttcheckbox4, this.ttlabel1, this.ttcheckbox5, this.dtRequirement, this.tttabcontrol1, this.tttabpage1, this.ttgrid1, this.ttlistbox1, this.txtAmount, this.chkIsinlama, this.chkFilter, this.OzelDurum, this.ttlabel3];

    }


}
