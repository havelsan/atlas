//$94F68CFD
import { Component, OnInit, NgZone } from '@angular/core';
import { BloodProductPreparationFormViewModel } from './BloodProductPreparationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BloodProductRequest } from 'NebulaClient/Model/AtlasClientModel';
import { BloodProductRequestService } from "ObjectClassService/BloodProductRequestService";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { BloodBankBloodProducts } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'BloodProductPreparationForm',
    templateUrl: './BloodProductPreparationForm.html',
    providers: [MessageService]
})
export class BloodProductPreparationForm extends EpisodeActionForm implements OnInit {
    btnSend: TTVisual.ITTButton;
    chkBlock: TTVisual.ITTCheckBox;
    chkFiltrelenmis: TTVisual.ITTCheckBoxColumn;
    chkHB: TTVisual.ITTCheckBox;
    chkIsinlanmis: TTVisual.ITTCheckBoxColumn;
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
    tttextbox2: TTVisual.ITTTextBox;
    txtAmount: TTVisual.ITTTextBoxColumn;
    public ttgrid1Columns = [];
    public bloodProductPreparationFormViewModel: BloodProductPreparationFormViewModel = new BloodProductPreparationFormViewModel();
    public get _BloodProductRequest(): BloodProductRequest {
        return this._TTObject as BloodProductRequest;
    }
    private BloodProductPreparationForm_DocumentUrl: string = '/api/BloodProductRequestService/BloodProductPreparationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BloodProductPreparationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async btnSend_Click(): Promise<void> {
        //  Cursor current = Cursor.Current;
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
    protected async PreScript(): Promise<void> {
        super.PreScript();
        //this.cmdOK.Visible = false;
        this.DropStateButton(BloodProductRequest.BloodProductRequestStates.Completed);
        this.DropStateButton(BloodProductRequest.BloodProductRequestStates.BloodProductUsage);
        this.DropStateButton(BloodProductRequest.BloodProductRequestStates.BloodProductReady);
        this.DropStateButton(BloodProductRequest.BloodProductRequestStates.CrossMatch);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BloodProductRequest();
        this.bloodProductPreparationFormViewModel = new BloodProductPreparationFormViewModel();
        this._ViewModel = this.bloodProductPreparationFormViewModel;
        this.bloodProductPreparationFormViewModel._BloodProductRequest = this._TTObject as BloodProductRequest;
        this.bloodProductPreparationFormViewModel._BloodProductRequest.BloodProducts = new Array<BloodBankBloodProducts>();
    }

    protected loadViewModel() {
        let that = this;

        that.bloodProductPreparationFormViewModel = this._ViewModel as BloodProductPreparationFormViewModel;
        that._TTObject = this.bloodProductPreparationFormViewModel._BloodProductRequest;
        if (this.bloodProductPreparationFormViewModel == null)
            this.bloodProductPreparationFormViewModel = new BloodProductPreparationFormViewModel();
        if (this.bloodProductPreparationFormViewModel._BloodProductRequest == null)
            this.bloodProductPreparationFormViewModel._BloodProductRequest = new BloodProductRequest();
        that.bloodProductPreparationFormViewModel._BloodProductRequest.BloodProducts = that.bloodProductPreparationFormViewModel.ttgrid1GridList;
        for (let detailItem of that.bloodProductPreparationFormViewModel.ttgrid1GridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.bloodProductPreparationFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BloodProductPreparationFormViewModel);
  
    }


    public onchkBlockChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsBlock != event) {
                this._BloodProductRequest.IsBlock = event;
            }
        }
    }

    public onchkHBChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsHB != event) {
                this._BloodProductRequest.IsHB = event;
            }
        }
    }

    public onchkNormalChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsNormalCross != event) {
                this._BloodProductRequest.IsNormalCross = event;
            }
        }
    }

    public onchkOtherChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsOtherReason != event) {
                this._BloodProductRequest.IsOtherReason = event;
            }
        }
    }

    public onchkPregnancyChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsPregnancy != event) {
                this._BloodProductRequest.IsPregnancy = event;
            }
        }
    }

    public onchkPrepareChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsPrepared != event) {
                this._BloodProductRequest.IsPrepared = event;
            }
        }
    }

    public onchkSurgeryChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsSurgery != event) {
                this._BloodProductRequest.IsSurgery = event;
            }
        }
    }

    public onchkTransfusedChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsTransfused != event) {
                this._BloodProductRequest.IsTransfused = event;
            }
        }
    }

    public onchkUrgentChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsUrgent != event) {
                this._BloodProductRequest.IsUrgent = event;
            }
        }
    }

    public onchkUrgentCrossChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsUrgentCross != event) {
                this._BloodProductRequest.IsUrgentCross = event;
            }
        }
    }

    public onchkWithoutCrossChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsWithoutCross != event) {
                this._BloodProductRequest.IsWithoutCross = event;
            }
        }
    }

    public onchkWithoutTestsChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsWithoutTests != event) {
                this._BloodProductRequest.IsWithoutTests = event;
            }
        }
    }

    public onchkWithTestChanged(event): void {
        if (event != null) {
            if (this._BloodProductRequest != null && this._BloodProductRequest.IsWithTests != event) {
                this._BloodProductRequest.IsWithTests = event;
            }
        }
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
        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M10469", "Açıklama");
        this.ttlabel3.BackColor = "#F0F0F0";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 14;
        this.ttlabel3.Visible = false;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 13;
        this.tttextbox2.Visible = false;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M17215", "Kan Ürün Özellikleri");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 10;

        this.btnSend = new TTVisual.TTButton();
        this.btnSend.Text = i18n("M16651", "İstek Tekrar Gönder");
        this.btnSend.Name = "btnSend";
        this.btnSend.TabIndex = 24;

        this.pnlUrgent = new TTVisual.TTPanel();
        this.pnlUrgent.AutoSize = true;
        this.pnlUrgent.Name = "pnlUrgent";
        this.pnlUrgent.TabIndex = 23;

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

        this.dtRequirement = new TTVisual.TTDateTimePicker();
        this.dtRequirement.CustomFormat = "";
        this.dtRequirement.Format = DateTimePickerFormat.Long;
        this.dtRequirement.Name = "dtRequirement";
        this.dtRequirement.TabIndex = 0;

        this.ttcheckbox5 = new TTVisual.TTCheckBox();
        this.ttcheckbox5.Value = false;
        this.ttcheckbox5.Text = i18n("M15518", "Hastaya kullanmak için istiyorum");
        this.ttcheckbox5.Name = "ttcheckbox5";
        this.ttcheckbox5.TabIndex = 9;
        this.ttcheckbox5.Visible = false;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M14746", "Gereksinim Tarihi");
        this.ttlabel1.BackColor = "#F0F0F0";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 1;

        this.ttcheckbox4 = new TTVisual.TTCheckBox();
        this.ttcheckbox4.Value = false;
        this.ttcheckbox4.Text = i18n("M17236", "Kanın hazırlanmasını istiyorum");
        this.ttcheckbox4.Name = "ttcheckbox4";
        this.ttcheckbox4.TabIndex = 8;
        this.ttcheckbox4.Visible = false;

        this.dtTransfused = new TTVisual.TTDateTimePicker();
        this.dtTransfused.Format = DateTimePickerFormat.Long;
        this.dtTransfused.Name = "dtTransfused";
        this.dtTransfused.TabIndex = 22;

        this.chkUrgent = new TTVisual.TTCheckBox();
        this.chkUrgent.Value = false;
        this.chkUrgent.Text = "Acil";
        this.chkUrgent.Name = "chkUrgent";
        this.chkUrgent.TabIndex = 5;

        this.dtPregnancy = new TTVisual.TTDateTimePicker();
        this.dtPregnancy.Format = DateTimePickerFormat.Long;
        this.dtPregnancy.Name = "dtPregnancy";
        this.dtPregnancy.TabIndex = 21;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M17197", "Kan Grubu");
        this.ttlabel2.BackColor = "#F0F0F0";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 2;
        this.ttlabel2.Visible = false;

        this.chkBlock = new TTVisual.TTCheckBox();
        this.chkBlock.Value = false;
        this.chkBlock.Text = i18n("M11960", "Bloke edilecek");
        this.chkBlock.Name = "chkBlock";
        this.chkBlock.TabIndex = 20;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 3;
        this.tttextbox1.Visible = false;

        this.chkOther = new TTVisual.TTCheckBox();
        this.chkOther.Value = false;
        this.chkOther.Text = i18n("M12780", "Diğer");
        this.chkOther.Name = "chkOther";
        this.chkOther.TabIndex = 19;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M12465", "Daha önce transfüzyon yapıldı mı?");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 10;

        this.chkHB = new TTVisual.TTCheckBox();
        this.chkHB.Value = false;
        this.chkHB.Text = i18n("M15586", "Hb Yükseltme");
        this.chkHB.Name = "chkHB";
        this.chkHB.TabIndex = 18;

        this.chkTransfused = new TTVisual.TTCheckBox();
        this.chkTransfused.Value = false;
        this.chkTransfused.Text = i18n("M14018", "Evet");
        this.chkTransfused.Name = "chkTransfused";
        this.chkTransfused.TabIndex = 11;

        this.chkPrepare = new TTVisual.TTCheckBox();
        this.chkPrepare.Value = false;
        this.chkPrepare.Text = i18n("M15577", "Hazırlanacak");
        this.chkPrepare.Name = "chkPrepare";
        this.chkPrepare.TabIndex = 17;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M14568", "Gebelik Öyküsü (Önceki Gebelikler)");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 12;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M17235", "Kanın hazırlanma durumu");
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 16;

        this.chkPregnancy = new TTVisual.TTCheckBox();
        this.chkPregnancy.Value = false;
        this.chkPregnancy.Text = i18n("M14018", "Evet");
        this.chkPregnancy.Name = "chkPregnancy";
        this.chkPregnancy.TabIndex = 13;

        this.chkSurgery = new TTVisual.TTCheckBox();
        this.chkSurgery.Value = false;
        this.chkSurgery.Text = "Ameliyat";
        this.chkSurgery.Name = "chkSurgery";
        this.chkSurgery.TabIndex = 15;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M17234", "Kanın hangi amaçla istendiği");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 14;

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
        this.ttgrid1.AllowUserToDeleteRows = false;
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
        this.txtAmount.Visible = false;
        this.txtAmount.Width = 100;

        this.chkIsinlanmis = new TTVisual.TTCheckBoxColumn();
        this.chkIsinlanmis.DisplayIndex = 2;
        this.chkIsinlanmis.HeaderText = "Işınlanmış";
        this.chkIsinlanmis.Name = "chkIsinlanmis";
        this.chkIsinlanmis.ReadOnly = true;
        this.chkIsinlanmis.Visible = false;
        this.chkIsinlanmis.Width = 70;

        this.chkFiltrelenmis = new TTVisual.TTCheckBoxColumn();
        this.chkFiltrelenmis.DisplayIndex = 3;
        this.chkFiltrelenmis.HeaderText = i18n("M14291", "Filtrelenmiş");
        this.chkFiltrelenmis.Name = "chkFiltrelenmis";
        this.chkFiltrelenmis.ReadOnly = true;
        this.chkFiltrelenmis.Visible = false;
        this.chkFiltrelenmis.Width = 80;

        this.ttgrid1Columns = [this.ttlistbox1, this.txtAmount, this.chkIsinlanmis, this.chkFiltrelenmis];
        this.ttgroupbox1.Controls = [this.btnSend, this.pnlUrgent, this.dtRequirement, this.ttcheckbox5, this.ttlabel1, this.ttcheckbox4, this.dtTransfused, this.chkUrgent, this.dtPregnancy, this.ttlabel2, this.chkBlock, this.tttextbox1, this.chkOther, this.ttlabel4, this.chkHB, this.chkTransfused, this.chkPrepare, this.ttlabel5, this.ttlabel7, this.chkPregnancy, this.chkSurgery, this.ttlabel6];
        this.pnlUrgent.Controls = [this.chkWithTest, this.chkWithoutTests, this.chkUrgentCross, this.chkWithoutCross, this.chkNormal];
        this.tttabcontrol1.Controls = [this.tttabpage1];
        this.tttabpage1.Controls = [this.ttgrid1];
        this.Controls = [this.ttlabel3, this.tttextbox2, this.ttgroupbox1, this.btnSend, this.pnlUrgent, this.chkWithTest, this.chkWithoutTests, this.chkUrgentCross, this.chkWithoutCross, this.chkNormal, this.dtRequirement, this.ttcheckbox5, this.ttlabel1, this.ttcheckbox4, this.dtTransfused, this.chkUrgent, this.dtPregnancy, this.ttlabel2, this.chkBlock, this.tttextbox1, this.chkOther, this.ttlabel4, this.chkHB, this.chkTransfused, this.chkPrepare, this.ttlabel5, this.ttlabel7, this.chkPregnancy, this.chkSurgery, this.ttlabel6, this.tttabcontrol1, this.tttabpage1, this.ttgrid1, this.ttlistbox1, this.txtAmount, this.chkIsinlanmis, this.chkFiltrelenmis];

    }


}
