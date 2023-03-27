//$A880311E
import { Component, OnInit, NgZone } from '@angular/core';
import { OutPatientPrescriptionThirdFormViewModel } from './OutPatientPrescriptionThirdFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DiagnosisForPresc } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientPrescriptionBaseForm } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Ayaktan_Hasta_Recetesi_Modulu/OutPatientPrescriptionBaseForm";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisForSPTS } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'OutPatientPrescriptionThirdForm',
    templateUrl: './OutPatientPrescriptionThirdForm.html',
    providers: [MessageService]
})
export class OutPatientPrescriptionThirdForm extends OutPatientPrescriptionBaseForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    BarcodeLevel: TTVisual.ITTTextBoxColumn;
    btnEReceteNoInQuiry: TTVisual.ITTButton;
    cmdAddDetail: TTVisual.ITTButton;
    cmdSelectBarcodeLevel: TTVisual.ITTButtonColumn;
    Code: TTVisual.ITTTextBoxColumn;
    Day: TTVisual.ITTTextBoxColumn;
    Diagnose: TTVisual.ITTListBoxColumn;
    DoseAmount: TTVisual.ITTTextBoxColumn;
    Drug: TTVisual.ITTListBoxColumn;
    DrugSupply: TTVisual.ITTEnumComboBoxColumn;
    DrugTabPage: TTVisual.ITTTabPage;
    EReceteNo: TTVisual.ITTTextBox;
    Frequency: TTVisual.ITTEnumComboBoxColumn;
    ID: TTVisual.ITTTextBox;
    labelEReceteNo: TTVisual.ITTLabel;
    labelPatientGroup: TTVisual.ITTLabel;
    labelPrescriptionType: TTVisual.ITTLabel;
    labelProtocolNoSubEpisode: TTVisual.ITTLabel;
    labelReceiptNO: TTVisual.ITTLabel;
    Name: TTVisual.ITTTextBoxColumn;
    OutPatientDrugOrders: TTVisual.ITTGrid;
    PackageAmount: TTVisual.ITTTextBoxColumn;
    PatientFullName: TTVisual.ITTTextBox;
    PatientGroup: TTVisual.ITTEnumComboBox;
    PrescriptionType: TTVisual.ITTEnumComboBox;
    ProtocolNoSubEpisode: TTVisual.ITTTextBox;
    ProvisionDetail: TTVisual.ITTRichTextBoxControlColumn;
    ProvisionResult: TTVisual.ITTCheckBoxColumn;
    ReceiptNO: TTVisual.ITTTextBox;
    ReceivedPrice: TTVisual.ITTTextBoxColumn;
    RequiredAmount: TTVisual.ITTTextBoxColumn;
    SPTSDiagnosises: TTVisual.ITTGrid;
    SPTSDiagnosisInfos: TTVisual.ITTGrid;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttextbox4: TTVisual.ITTTextBox;
    tttextbox6: TTVisual.ITTTextBox;
    UsageNote: TTVisual.ITTTextBoxColumn;
    public OutPatientDrugOrdersColumns = [];
    public SPTSDiagnosisesColumns = [];
    public SPTSDiagnosisInfosColumns = [];
    public outPatientPrescriptionThirdFormViewModel: OutPatientPrescriptionThirdFormViewModel = new OutPatientPrescriptionThirdFormViewModel();
    public get _OutPatientPrescription(): OutPatientPrescription {
        return this._TTObject as OutPatientPrescription;
    }
    private OutPatientPrescriptionThirdForm_DocumentUrl: string = '/api/OutPatientPrescriptionService/OutPatientPrescriptionThirdForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.OutPatientPrescriptionThirdForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async btnEReceteNoInQuiry_Click(): Promise<void> {

    }
    private async cmdAddDetail_Click(): Promise<void> {
     /*   if (String.isNullOrEmpty(this._OutPatientPrescription.EReceteNo) === false) {
            let currentUser: ResUser = <ResUser>Common.CurrentUser.UserObject;
            if (currentUser.UniqueNo.Equals(this._OutPatientPrescription.ProcedureDoctor.UniqueNo)) {
                let eReceteDetailForm: TTVisual.TTForm = new TTFormClasses.OutPatientPresDetailForm();
                eReceteDetailForm.ShowEdit(this, this._OutPatientPrescription, true);
            }
            else {
                TTVisual.InfoBox.Show("E-Reçete sizin adınıza alınmamış. Bu nedenle detay ekleyemezsiniz.", MessageIconEnum.ErrorMessage);
            }
        }
        else TTVisual.InfoBox.Show("Reçete E Reçete'ye yollanmamış. Bu nedenle detay ekleyemezsiniz.", MessageIconEnum.ErrorMessage);*/
    }
    private async OutPatientDrugOrders_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
      /*  if (this.OutPatientDrugOrders.CurrentCell.OwningColumn.Name === "cmdSelectBarcodeLevel") {
            if (this.OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value !== null) {
                let drugDefinition: DrugDefinition = <DrugDefinition>this._OutPatientPrescription.ObjectContext.GetObject(new Guid(this.OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value.toString()), "DRUGDEFINITION");
                let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                for (let barcodeLevel of drugDefinition.MaterialBarcodeLevels) {
                    multiSelectForm.AddMSItem(barcodeLevel.Name.toString(), barcodeLevel.Name.toString(), barcodeLevel);
                }
                let key: string = multiSelectForm.GetMSItem(ParentForm, "İlaç Formunu Seçiniz");
                if (!String.isNullOrEmpty(key)) {
                    this.OutPatientDrugOrders.Rows[rowIndex].Cells["BarcodeLevel"].Value = (<MaterialBarcodeLevel>multiSelectForm.MSSelectedItemObject).Name.toString();
                }
            }
        }*/
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
      /*  if (transDef !== null) {
            if (transDef.FromStateDefID === OutPatientPrescription.OutPatientPrescriptionStates.CompletedWithSign && transDef.ToStateDefID === OutPatientPrescription.OutPatientPrescriptionStates.Cancelled)
                this._OutPatientPrescription.CancelStockPrescriptionOut(this._OutPatientPrescription);
            if (transDef.FromStateDefID === OutPatientPrescription.OutPatientPrescriptionStates.Completed && transDef.ToStateDefID === OutPatientPrescription.OutPatientPrescriptionStates.Cancelled)
                this._OutPatientPrescription.CancelStockPrescriptionOut(this._OutPatientPrescription);
            if (transDef.FromStateDefID === OutPatientPrescription.OutPatientPrescriptionStates.CompletedWithSign && (transDef.ToStateDefID === OutPatientPrescription.OutPatientPrescriptionStates.Cancelled || transDef.ToStateDefID === OutPatientPrescription.OutPatientPrescriptionStates.Request))
                this.CancelERecete();
        }*/
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
    }
    protected async PreScript() {
        super.PreScript();
     /*   let diagForPres: Dictionary<Guid, string> = new Dictionary<Guid, string>();
        for (let diag of this._OutPatientPrescription.Episode.Diagnosis) {
            if (diagForPres.containsKey(diag.Diagnose.ObjectID) === false) {
                let diagForPresc: DiagnosisForPresc = new DiagnosisForPresc(this._OutPatientPrescription.ObjectContext);
                diagForPresc.Code = diag.Diagnose.Code;
                diagForPresc.Name = diag.Diagnose.Name.toString();
                this._OutPatientPrescription.SPTSDiagnosises.push(diagForPresc);
                diagForPres.push(diag.Diagnose.ObjectID, diag.Diagnose.Code);
            }
        }
        if (String.isNullOrEmpty(this._OutPatientPrescription.EReceteNo))
            this.DropStateButton(OutPatientPrescription.OutPatientPrescriptionStates.Request);
        if (this.OutPatientDrugOrders.Rows.length > 0) {
            for (let i: number = 0; i < this.OutPatientDrugOrders.Rows.length; i++) {
                if (this.OutPatientDrugOrders.Rows[i].Cells["PROVISIONDETAIL"].Value !== null) {
                    if (Convert.ToBoolean(this.OutPatientDrugOrders.Rows[i].Cells["PROVISIONRESULT"].Value)) {
                        (<TTGrid>this.OutPatientDrugOrders).Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                    }
                    else {
                        (<TTGrid>this.OutPatientDrugOrders).Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                else {
                    (<TTGrid>this.OutPatientDrugOrders).Rows[i].Cells["RECEIVEDPRICE"].ReadOnly = false;
                }
            }
        }*/
    }
    public async CancelERecete(): Promise<void> {
      /*  if (String.isNullOrEmpty(this._OutPatientPrescription.EReceteNo) === false) {
            let callerObject: Prescription.OutPatientPrescriptionWebCaller = new Prescription.OutPatientPrescriptionWebCaller();
            callerObject.ObjectID = this._OutPatientPrescription.ObjectID;
            if (String.isNullOrEmpty(this._OutPatientPrescription.ERecetePassword))
                throw new TTException("E reçete şirfeniz girilmemiş");
            let silIstekDvo: TTObjectClasses.EReceteIslemleri.ereceteSilIstekDVO = (await PrescriptionService.GetEReceteDelete(this._OutPatientPrescription));
            let imzalanacakXml: string = (await CommonService.SerializeObjectToXml(silIstekDvo));
            imzalanacakXml = imzalanacakXml.replace("ereceteSilIstekDVO", "imzaliEreceteSilBilgisi");
            let signedContent: number[] = CommonForm.SignContent(imzalanacakXml);
            if (signedContent === null)
                throw new TTException("E-reçete iptal içeriği imzalanamadı");
            let imzaliEreceteSilIstek: TTObjectClasses.EReceteIslemleri.imzaliEreceteSilIstekDVO = new TTObjectClasses.EReceteIslemleri.imzaliEreceteSilIstekDVO();
            imzaliEreceteSilIstek.doktorTcKimlikNo = silIstekDvo.doktorTcKimlikNo.toString();
            imzaliEreceteSilIstek.imzaliEreceteSil = signedContent;
            imzaliEreceteSilIstek.tesisKodu = silIstekDvo.tesisKodu.toString();
            imzaliEreceteSilIstek.surumNumarasi = "1";
            let response: EReceteIslemleri.imzaliEreceteSilCevapDVO = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(Sites.SiteLocalHost, this._OutPatientPrescription.ProcedureDoctor.UniqueNo.toString(), this._OutPatientPrescription.ERecetePassword.toString(), imzaliEreceteSilIstek);
            if (response !== null) {
                if (response.sonucKodu.Equals("0000")) {
                    TTVisual.InfoBox.Alert("E reçete başarıyla iptal edilmiştir.");
                }
                else {
                    if (!String.isNullOrEmpty(response.uyariMesaji))
                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
                    else throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
                }
            }
        }*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new OutPatientPrescription();
        this.outPatientPrescriptionThirdFormViewModel = new OutPatientPrescriptionThirdFormViewModel();
        this._ViewModel = this.outPatientPrescriptionThirdFormViewModel;
        this.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription = this._TTObject as OutPatientPrescription;
        this.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription.Episode = new Episode();
        this.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription.Episode.Patient = new Patient();
        this.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription.OutPatientDrugOrders = new Array<OutPatientDrugOrder>();
        this.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription.SPTSDiagnosises = new Array<DiagnosisForPresc>();
        this.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription.DiagnosisForSPTSs = new Array<DiagnosisForSPTS>();
    }

    protected loadViewModel() {
        let that = this;

        that.outPatientPrescriptionThirdFormViewModel = this._ViewModel as OutPatientPrescriptionThirdFormViewModel;
        that._TTObject = this.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription;
        if (this.outPatientPrescriptionThirdFormViewModel == null)
            this.outPatientPrescriptionThirdFormViewModel = new OutPatientPrescriptionThirdFormViewModel();
        if (this.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription == null)
            this.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription = new OutPatientPrescription();
        let episodeObjectID = that.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.outPatientPrescriptionThirdFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.outPatientPrescriptionThirdFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        that.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription.OutPatientDrugOrders = that.outPatientPrescriptionThirdFormViewModel.OutPatientDrugOrdersGridList;
        for (let detailItem of that.outPatientPrescriptionThirdFormViewModel.OutPatientDrugOrdersGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.outPatientPrescriptionThirdFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
        that.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription.SPTSDiagnosises = that.outPatientPrescriptionThirdFormViewModel.SPTSDiagnosisesGridList;
        for (let detailItem of that.outPatientPrescriptionThirdFormViewModel.SPTSDiagnosisesGridList) {
        }
        that.outPatientPrescriptionThirdFormViewModel._OutPatientPrescription.DiagnosisForSPTSs = that.outPatientPrescriptionThirdFormViewModel.SPTSDiagnosisInfosGridList;
        for (let detailItem of that.outPatientPrescriptionThirdFormViewModel.SPTSDiagnosisInfosGridList) {
            let sPTSDiagnosisInfoObjectID = detailItem["SPTSDiagnosisInfo"];
            if (sPTSDiagnosisInfoObjectID != null && (typeof sPTSDiagnosisInfoObjectID === 'string')) {
                let sPTSDiagnosisInfo = that.outPatientPrescriptionThirdFormViewModel.SPTSDiagnosisInfos.find(o => o.ObjectID.toString() === sPTSDiagnosisInfoObjectID.toString());
                 if (sPTSDiagnosisInfo) {
                    detailItem.SPTSDiagnosisInfo = sPTSDiagnosisInfo;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(OutPatientPrescriptionThirdFormViewModel);
  
    }


    public onEReceteNoChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.EReceteNo != event) {
                this._OutPatientPrescription.EReceteNo = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.ID != event) {
                this._OutPatientPrescription.ID = event;
            }
        }
    }

    public onPatientFullNameChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null &&
                this._OutPatientPrescription.Episode != null &&
                this._OutPatientPrescription.Episode.Patient != null && this._OutPatientPrescription.Episode.Patient.FullName != event) {
                this._OutPatientPrescription.Episode.Patient.FullName = event;
            }
        }
    }

    public onPrescriptionTypeChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.PrescriptionType != event) {
                this._OutPatientPrescription.PrescriptionType = event;
            }
        }
    }

    public onProtocolNoSubEpisodeChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null &&
                this._OutPatientPrescription.Episode != null && this._OutPatientPrescription.Episode.HospitalProtocolNo != event) {
                this._OutPatientPrescription.Episode.HospitalProtocolNo = event;
            }
        }
    }

    public onReceiptNOChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.ReceiptNO != event) {
                this._OutPatientPrescription.ReceiptNO = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.ActionDate != event) {
                this._OutPatientPrescription.ActionDate = event;
            }
        }
    }

    public ontttextbox4Changed(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.EReceteDescription != event) {
                this._OutPatientPrescription.EReceteDescription = event;
            }
        }
    }

    public ontttextbox6Changed(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.DiscriptionOfPharmacist != event) {
                this._OutPatientPrescription.DiscriptionOfPharmacist = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ID, "Text", this.__ttObject, "ID");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ProtocolNoSubEpisode, "Text", this.__ttObject, "Episode.HospitalProtocolNo");
        redirectProperty(this.PatientFullName, "Text", this.__ttObject, "Episode.Patient.FullName");
        redirectProperty(this.EReceteNo, "Text", this.__ttObject, "EReceteNo");
        redirectProperty(this.ReceiptNO, "Text", this.__ttObject, "ReceiptNO");
        redirectProperty(this.PrescriptionType, "Value", this.__ttObject, "PrescriptionType");
        redirectProperty(this.tttextbox4, "Text", this.__ttObject, "EReceteDescription");
        redirectProperty(this.tttextbox6, "Text", this.__ttObject, "DiscriptionOfPharmacist");
    }

    public initFormControls(): void {
        this.labelEReceteNo = new TTVisual.TTLabel();
        this.labelEReceteNo.Text = i18n("M13425", "E Reçete No");
        this.labelEReceteNo.Name = "labelEReceteNo";
        this.labelEReceteNo.TabIndex = 101;

        this.DigitalSignatureButton = new TTVisual.TTButton();
        this.DigitalSignatureButton.Text = i18n("M13510", "e-imza doğrulanamadı");
        this.DigitalSignatureButton.Name = "DigitalSignatureButton";
        this.DigitalSignatureButton.TabIndex = 95;
        this.DigitalSignatureButton.Visible = false;

        this.ProtocolNoSubEpisode = new TTVisual.TTTextBox();
        this.ProtocolNoSubEpisode.BackColor = "#F0F0F0";
        this.ProtocolNoSubEpisode.ReadOnly = true;
        this.ProtocolNoSubEpisode.Name = "ProtocolNoSubEpisode";
        this.ProtocolNoSubEpisode.TabIndex = 2;

        this.EReceteNo = new TTVisual.TTTextBox();
        this.EReceteNo.BackColor = "#F0F0F0";
        this.EReceteNo.ReadOnly = true;
        this.EReceteNo.Name = "EReceteNo";
        this.EReceteNo.TabIndex = 4;

        this.labelProtocolNoSubEpisode = new TTVisual.TTLabel();
        this.labelProtocolNoSubEpisode.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNoSubEpisode.Name = "labelProtocolNoSubEpisode";
        this.labelProtocolNoSubEpisode.TabIndex = 97;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 14;

        this.DrugTabPage = new TTVisual.TTTabPage();
        this.DrugTabPage.DisplayIndex = 0;
        this.DrugTabPage.BackColor = "#FFFFFF";
        this.DrugTabPage.TabIndex = 0;
        this.DrugTabPage.Text = i18n("M16389", "İlaçlar");
        this.DrugTabPage.Name = "DrugTabPage";

        this.OutPatientDrugOrders = new TTVisual.TTGrid();
        this.OutPatientDrugOrders.BackColor = "#DCDCDC";
        this.OutPatientDrugOrders.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.OutPatientDrugOrders.Name = "OutPatientDrugOrders";
        this.OutPatientDrugOrders.TabIndex = 0;
        this.OutPatientDrugOrders.AllowUserToDeleteRows = false;
        this.OutPatientDrugOrders.AllowUserToAddRows = false;

        this.ProvisionDetail = new TTVisual.TTRichTextBoxControlColumn();
        this.ProvisionDetail.DataMember = "SPTSProvisionDetail";
        this.ProvisionDetail.DisplayIndex = 0;
        this.ProvisionDetail.HeaderText = i18n("M20572", "Provizyon");
        this.ProvisionDetail.Name = "ProvisionDetail";
        this.ProvisionDetail.ReadOnly = true;
        this.ProvisionDetail.Width = 100;

        this.Drug = new TTVisual.TTListBoxColumn();
        this.Drug.ListDefName = "DrugList";
        this.Drug.DataMember = "Material";
        this.Drug.DisplayIndex = 1;
        this.Drug.HeaderText = i18n("M16287", "İlaç");
        this.Drug.Name = "Drug";
        this.Drug.ReadOnly = true;
        this.Drug.Width = 300;

        this.BarcodeLevel = new TTVisual.TTTextBoxColumn();
        this.BarcodeLevel.DataMember = "BarcodeLevel";
        this.BarcodeLevel.DisplayIndex = 2;
        this.BarcodeLevel.HeaderText = i18n("M10766", "Ambalaj İsmi");
        this.BarcodeLevel.Name = "BarcodeLevel";
        this.BarcodeLevel.ReadOnly = true;
        this.BarcodeLevel.Visible = false;
        this.BarcodeLevel.Width = 300;

        this.Frequency = new TTVisual.TTEnumComboBoxColumn();
        this.Frequency.DataTypeName = "FrequencyEnum";
        this.Frequency.DataMember = "Frequency";
        this.Frequency.DisplayIndex = 3;
        this.Frequency.HeaderText = i18n("M13285", "Doz Aralığı");
        this.Frequency.Name = "Frequency";
        this.Frequency.ReadOnly = true;
        this.Frequency.Width = 80;

        this.DoseAmount = new TTVisual.TTTextBoxColumn();
        this.DoseAmount.DataMember = "DoseAmount";
        this.DoseAmount.DisplayIndex = 4;
        this.DoseAmount.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmount.Name = "DoseAmount";
        this.DoseAmount.ReadOnly = true;
        this.DoseAmount.Width = 80;

        this.Day = new TTVisual.TTTextBoxColumn();
        this.Day.DataMember = "Day";
        this.Day.DisplayIndex = 5;
        this.Day.HeaderText = i18n("M14998", "Gün");
        this.Day.Name = "Day";
        this.Day.ReadOnly = true;
        this.Day.Width = 80;

        this.RequiredAmount = new TTVisual.TTTextBoxColumn();
        this.RequiredAmount.DataMember = "RequiredAmount";
        this.RequiredAmount.DisplayIndex = 6;
        this.RequiredAmount.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequiredAmount.Name = "RequiredAmount";
        this.RequiredAmount.ReadOnly = true;
        this.RequiredAmount.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 7;
        this.Amount.HeaderText = i18n("M17315", "Karşılanan Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 120;

        this.PackageAmount = new TTVisual.TTTextBoxColumn();
        this.PackageAmount.DataMember = "PackageAmount";
        this.PackageAmount.DisplayIndex = 8;
        this.PackageAmount.HeaderText = i18n("M20131", "Paket Adeti");
        this.PackageAmount.Name = "PackageAmount";
        this.PackageAmount.ReadOnly = true;
        this.PackageAmount.Width = 80;

        this.ReceivedPrice = new TTVisual.TTTextBoxColumn();
        this.ReceivedPrice.DataMember = "ReceivedPrice";
        this.ReceivedPrice.DisplayIndex = 9;
        this.ReceivedPrice.HeaderText = i18n("M16341", "İlaç Katılım Payı");
        this.ReceivedPrice.Name = "ReceivedPrice";
        this.ReceivedPrice.ReadOnly = true;
        this.ReceivedPrice.Width = 100;

        this.UsageNote = new TTVisual.TTTextBoxColumn();
        this.UsageNote.DataMember = "UsageNote";
        this.UsageNote.DisplayIndex = 10;
        this.UsageNote.HeaderText = i18n("M17992", "Kullanma Tarifi");
        this.UsageNote.Name = "UsageNote";
        this.UsageNote.ReadOnly = true;
        this.UsageNote.Width = 200;

        this.DrugSupply = new TTVisual.TTEnumComboBoxColumn();
        this.DrugSupply.DataTypeName = "OutPatientDrugSupplyEnum";
        this.DrugSupply.DataMember = "DrugSupply";
        this.DrugSupply.DisplayIndex = 11;
        this.DrugSupply.HeaderText = i18n("M17312", "Karşılama Durumu");
        this.DrugSupply.Name = "DrugSupply";
        this.DrugSupply.ToolTipText = i18n("M17312", "Karşılama Durumu");
        this.DrugSupply.Width = 100;

        this.cmdSelectBarcodeLevel = new TTVisual.TTButtonColumn();
        this.cmdSelectBarcodeLevel.Text = "Amb.Tipi Değ.";
        this.cmdSelectBarcodeLevel.UseColumnTextForButtonValue = true;
        this.cmdSelectBarcodeLevel.DisplayIndex = 12;
        this.cmdSelectBarcodeLevel.HeaderText = i18n("M21507", "Seç");
        this.cmdSelectBarcodeLevel.Name = "cmdSelectBarcodeLevel";
        this.cmdSelectBarcodeLevel.ReadOnly = true;
        this.cmdSelectBarcodeLevel.Visible = false;
        this.cmdSelectBarcodeLevel.Width = 100;

        this.ProvisionResult = new TTVisual.TTCheckBoxColumn();
        this.ProvisionResult.DataMember = "SPTSProvisionResult";
        this.ProvisionResult.DisplayIndex = 13;
        this.ProvisionResult.HeaderText = i18n("M20575", "Provizyon Durumu");
        this.ProvisionResult.Name = "ProvisionResult";
        this.ProvisionResult.ReadOnly = true;
        this.ProvisionResult.Visible = false;
        this.ProvisionResult.Width = 80;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = "#F0F0F0";
        this.ID.ReadOnly = true;
        this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ID.Name = "ID";
        this.ID.TabIndex = 0;

        this.ReceiptNO = new TTVisual.TTTextBox();
        this.ReceiptNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReceiptNO.Name = "ReceiptNO";
        this.ReceiptNO.TabIndex = 5;

        this.PatientFullName = new TTVisual.TTTextBox();
        this.PatientFullName.BackColor = "#F0F0F0";
        this.PatientFullName.ForeColor = "#FF0000";
        this.PatientFullName.ReadOnly = true;
        this.PatientFullName.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientFullName.Name = "PatientFullName";
        this.PatientFullName.TabIndex = 3;

        this.labelReceiptNO = new TTVisual.TTLabel();
        this.labelReceiptNO.Text = i18n("M18478", "Makbuz No");
        this.labelReceiptNO.BackColor = "#DCDCDC";
        this.labelReceiptNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReceiptNO.ForeColor = "#000000";
        this.labelReceiptNO.Name = "labelReceiptNO";
        this.labelReceiptNO.TabIndex = 44;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M17026", "Kabul Sebebi");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 64;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ReadOnly = true;
        this.ttobjectlistbox1.ListDefName = "ReasonForAdmissionListDefinition";
        this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 9;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M16886", "İşlem Tarihi");
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 61;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.BackColor = "#F0F0F0";
        this.ttdatetimepicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepicker1.Enabled = false;
        this.ttdatetimepicker1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 1;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M16866", "İşlem No");
        this.ttlabel6.BackColor = "#DCDCDC";
        this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 60;

        this.PrescriptionType = new TTVisual.TTEnumComboBox();
        this.PrescriptionType.DataTypeName = "PrescriptionTypeEnum";
        this.PrescriptionType.BackColor = "#F0F0F0";
        this.PrescriptionType.Enabled = false;
        this.PrescriptionType.Name = "PrescriptionType";
        this.PrescriptionType.TabIndex = 11;

        this.labelPrescriptionType = new TTVisual.TTLabel();
        this.labelPrescriptionType.Text = i18n("M20964", "Reçete Türü");
        this.labelPrescriptionType.BackColor = "#DCDCDC";
        this.labelPrescriptionType.ForeColor = "#000000";
        this.labelPrescriptionType.Name = "labelPrescriptionType";
        this.labelPrescriptionType.TabIndex = 7;

        this.PatientGroup = new TTVisual.TTEnumComboBox();
        this.PatientGroup.DataTypeName = "PatientGroupEnum";
        this.PatientGroup.BackColor = "#F0F0F0";
        this.PatientGroup.Enabled = false;
        this.PatientGroup.Name = "PatientGroup";
        this.PatientGroup.TabIndex = 10;

        this.labelPatientGroup = new TTVisual.TTLabel();
        this.labelPatientGroup.Text = i18n("M15222", "Hasta Grubu");
        this.labelPatientGroup.Name = "labelPatientGroup";
        this.labelPatientGroup.TabIndex = 3;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M15133", "Hasta Adı Soyadı");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 86;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 13;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M22790", "Tanılar");
        this.tttabpage1.Name = "tttabpage1";

        this.SPTSDiagnosises = new TTVisual.TTGrid();
        this.SPTSDiagnosises.ReadOnly = true;
        this.SPTSDiagnosises.Name = "SPTSDiagnosises";
        this.SPTSDiagnosises.TabIndex = 0;

        this.Code = new TTVisual.TTTextBoxColumn();
        this.Code.DataMember = "Code";
        this.Code.DisplayIndex = 0;
        this.Code.HeaderText = "Kodu";
        this.Code.Name = "Code";
        this.Code.Width = 100;

        this.Name = new TTVisual.TTTextBoxColumn();
        this.Name.DataMember = "Name";
        this.Name.DisplayIndex = 1;
        this.Name.HeaderText = i18n("M10514", "Adı");
        this.Name.Name = "Name";
        this.Name.Width = 600;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = i18n("M22265", "SPTS Tanıları");
        this.tttabpage2.Name = "tttabpage2";

        this.SPTSDiagnosisInfos = new TTVisual.TTGrid();
        this.SPTSDiagnosisInfos.Name = "SPTSDiagnosisInfos";
        this.SPTSDiagnosisInfos.TabIndex = 54;

        this.Diagnose = new TTVisual.TTListBoxColumn();
        this.Diagnose.ListDefName = "SPTSDiagnosisInfoDefinitionList";
        this.Diagnose.DataMember = "SPTSDiagnosisInfo";
        this.Diagnose.DisplayIndex = 0;
        this.Diagnose.HeaderText = i18n("M22736", "Tanı");
        this.Diagnose.Name = "Diagnose";
        this.Diagnose.Width = 600;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 2;
        this.tttabpage3.TabIndex = 2;
        this.tttabpage3.Text = i18n("M13810", "E-Reçete");
        this.tttabpage3.Name = "tttabpage3";

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M13422", "E Reçete Açıklaması");
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 101;

        this.tttextbox4 = new TTVisual.TTTextBox();
        this.tttextbox4.Multiline = true;
        this.tttextbox4.BackColor = "#F0F0F0";
        this.tttextbox4.ReadOnly = true;
        this.tttextbox4.Name = "tttextbox4";
        this.tttextbox4.TabIndex = 100;

        this.btnEReceteNoInQuiry = new TTVisual.TTButton();
        this.btnEReceteNoInQuiry.Text = i18n("M13826", "e-Reçete Numarası Sorgula");
        this.btnEReceteNoInQuiry.Name = "btnEReceteNoInQuiry";
        this.btnEReceteNoInQuiry.TabIndex = 100;

        this.cmdAddDetail = new TTVisual.TTButton();
        this.cmdAddDetail.Text = i18n("M13423", "E Reçete Detay Ekleme");
        this.cmdAddDetail.Name = "cmdAddDetail";
        this.cmdAddDetail.TabIndex = 89;

        this.tttabpage4 = new TTVisual.TTTabPage();
        this.tttabpage4.DisplayIndex = 3;
        this.tttabpage4.TabIndex = 3;
        this.tttabpage4.Text = i18n("M13450", "Eczacının Açıklaması");
        this.tttabpage4.Name = "tttabpage4";

        this.tttextbox6 = new TTVisual.TTTextBox();
        this.tttextbox6.Multiline = true;
        this.tttextbox6.BackColor = "#F0F0F0";
        this.tttextbox6.ReadOnly = true;
        this.tttextbox6.Name = "tttextbox6";
        this.tttextbox6.TabIndex = 98;

        this.OutPatientDrugOrdersColumns = [this.ProvisionDetail, this.Drug, this.BarcodeLevel, this.Frequency, this.DoseAmount, this.Day, this.RequiredAmount, this.Amount, this.PackageAmount, this.ReceivedPrice, this.UsageNote, this.DrugSupply, this.cmdSelectBarcodeLevel, this.ProvisionResult];
        this.SPTSDiagnosisesColumns = [this.Code, this.Name];
        this.SPTSDiagnosisInfosColumns = [this.Diagnose];
        this.tttabcontrol1.Controls = [this.DrugTabPage];
        this.DrugTabPage.Controls = [this.OutPatientDrugOrders];
        this.tttabcontrol2.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3, this.tttabpage4];
        this.tttabpage1.Controls = [this.SPTSDiagnosises];
        this.tttabpage2.Controls = [this.SPTSDiagnosisInfos];
        this.tttabpage3.Controls = [this.ttlabel8, this.tttextbox4, this.btnEReceteNoInQuiry, this.cmdAddDetail];
        this.tttabpage4.Controls = [this.tttextbox6];
        this.Controls = [this.labelEReceteNo, this.DigitalSignatureButton, this.ProtocolNoSubEpisode, this.EReceteNo, this.labelProtocolNoSubEpisode, this.tttabcontrol1, this.DrugTabPage, this.OutPatientDrugOrders, this.ProvisionDetail, this.Drug, this.BarcodeLevel, this.Frequency, this.DoseAmount, this.Day, this.RequiredAmount, this.Amount, this.PackageAmount, this.ReceivedPrice, this.UsageNote, this.DrugSupply, this.cmdSelectBarcodeLevel, this.ProvisionResult, this.ID, this.ReceiptNO, this.PatientFullName, this.labelReceiptNO, this.ttlabel2, this.ttobjectlistbox1, this.ttlabel4, this.ttdatetimepicker1, this.ttlabel6, this.PrescriptionType, this.labelPrescriptionType, this.PatientGroup, this.labelPatientGroup, this.ttlabel1, this.tttabcontrol2, this.tttabpage1, this.SPTSDiagnosises, this.Code, this.Name, this.tttabpage2, this.SPTSDiagnosisInfos, this.Diagnose, this.tttabpage3, this.ttlabel8, this.tttextbox4, this.btnEReceteNoInQuiry, this.cmdAddDetail, this.tttabpage4, this.tttextbox6];

    }


}
