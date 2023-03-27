//$1E901114
import { Component, OnInit, NgZone } from '@angular/core';
import { InpatientPresciriptionDrugSupplyFormViewModel } from './InpatientPresciriptionDrugSupplyFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientPrescriptionBaseForm } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Yatan_Hasta_Recetesi_Modulu/InpatientPrescriptionBaseForm";
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ExternalPharmacy } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionPaper } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ObjectContextService } from 'Fw/Services/ObjectContextService';
@Component({
    selector: 'InpatientPresciriptionDrugSupplyForm',
    templateUrl: './InpatientPresciriptionDrugSupplyForm.html',
    providers: [MessageService]
})
export class InpatientPresciriptionDrugSupplyForm extends InpatientPrescriptionBaseForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    BarcodeLevel: TTVisual.ITTTextBoxColumn;
    btnEReceteNoInQuiry: TTVisual.ITTButton;
    cmdAddDetail: TTVisual.ITTButton;
    cmdSelectBarcodeLevel: TTVisual.ITTButtonColumn;
    Day: TTVisual.ITTTextBoxColumn;
    DistributionNo: TTVisual.ITTTextBox;
    DoseAmount: TTVisual.ITTTextBoxColumn;
    Drug: TTVisual.ITTListBoxColumn;
    EReceteNo: TTVisual.ITTTextBox;
    ExternalPharmacy: TTVisual.ITTObjectListBox;
    Frequency: TTVisual.ITTEnumComboBoxColumn;
    FromResource: TTVisual.ITTObjectListBox;
    InpatientDrugOrders: TTVisual.ITTGrid;
    labelActionDate: TTVisual.ITTLabel;
    labelDistributioınNo: TTVisual.ITTLabel;
    labelEReceteNo: TTVisual.ITTLabel;
    labelExternalPharmacy: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelPatientGroup: TTVisual.ITTLabel;
    labelPrescriptionNO: TTVisual.ITTLabel;
    labelPrescriptionType: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelQuarantineProtocolNo: TTVisual.ITTLabel;
    labelReasonForAdmission: TTVisual.ITTLabel;
    PackageAmount: TTVisual.ITTTextBoxColumn;
    PatientFullName: TTVisual.ITTTextBox;
    PrescriptionPaper: TTVisual.ITTObjectListBox;
    PrescriptionType: TTVisual.ITTEnumComboBox;
    ProtocolNo: TTVisual.ITTTextBox;
    QuarantineProtocolNo: TTVisual.ITTTextBox;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    State: TTVisual.ITTStateComboBoxColumn;
    ttdatetimepicker2: TTVisual.ITTDateTimePicker;
    ttenumcombobox1: TTVisual.ITTEnumComboBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    UsageNote: TTVisual.ITTTextBoxColumn;
    public InpatientDrugOrdersColumns = [];
    public inpatientPresciriptionDrugSupplyFormViewModel: InpatientPresciriptionDrugSupplyFormViewModel = new InpatientPresciriptionDrugSupplyFormViewModel();
    public get _InpatientPrescription(): InpatientPrescription {
        return this._TTObject as InpatientPrescription;
    }
    private InpatientPresciriptionDrugSupplyForm_DocumentUrl: string = '/api/InpatientPrescriptionService/InpatientPresciriptionDrugSupplyForm';
    constructor(protected httpService: NeHttpService, private objectContextService: ObjectContextService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.InpatientPresciriptionDrugSupplyForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async btnEReceteNoInQuiry_Click(): Promise<void> {

    }
    private async cmdAddDetail_Click(): Promise<void> {
      /*  if (String.isNullOrEmpty(this._InpatientPrescription.EReceteNo) === false) {
            let currentUser: ResUser = <ResUser>Common.CurrentUser.UserObject;
            if (currentUser.UniqueNo.Equals(this._InpatientPrescription.ProcedureDoctor.UniqueNo)) {
                let eReceteDetailForm: TTVisual.TTForm = new TTFormClasses.InpatientPresEReceteDetailForm();
                eReceteDetailForm.ShowEdit(this, this._InpatientPrescription, true);
            }
            else {
                TTVisual.InfoBox.Show("E-Reçete sizin adınıza alınmamış. Bu nedenle detay ekleyemezsiniz.", MessageIconEnum.ErrorMessage);
            }
        }
        else TTVisual.InfoBox.Show("Reçete E Reçete'ye yollanmamış. Bu nedenle detay ekleyemezsiniz.", MessageIconEnum.ErrorMessage);*/
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        await super.ClientSidePostScript(transDef);
       // if (transDef !== null && transDef.FromStateDefID === InpatientPrescription.InpatientPrescriptionStates.Completed && transDef.ToStateDefID === InpatientPrescription.InpatientPrescriptionStates.Cancelled)
         //   this._InpatientPrescription.CancelStockPrescriptionOut(this._InpatientPrescription);
    }
    protected async ClientSidePreScript() {
        await super.ClientSidePreScript();
    }
    public doctorName;
    ID;
    ActionDate;
    onActionDateChanged(data: any){}
    GridDiagnosisGridList;

    protected async PreScript() {

        let doctorObjID: any = this._InpatientPrescription.ProcedureDoctor;
        let doctor = await this.objectContextService.getObject(new Guid(doctorObjID), ResUser.ObjectDefID);
        if (doctor != null) {
            this.doctorName = (<ResUser>doctor).Name.toString();
        }


     /*   let diagnosisInfo: Dictionary<Guid, SPTSDiagnosisInfo> = new Dictionary<Guid, SPTSDiagnosisInfo>();
        let diags: Dictionary<Guid, DiagnosisDefinition> = new Dictionary<Guid, DiagnosisDefinition>();
        for (let diag of this._InpatientPrescription.Episode.Diagnosis) {
            if (!diags.containsKey(diag.Diagnose.ObjectID))
                diags.push(diag.Diagnose.ObjectID, diag.Diagnose);
        }
        if (diags.length > 0) {
            for (let diag of diags) {
                let diagForPresc: DiagnosisForPresc = new DiagnosisForPresc(this._InpatientPrescription.ObjectContext);
                diagForPresc.Code = diag.Value.Code;
                diagForPresc.Name = diag.Value.Name.toString();
                diagForPresc.Prescription = this._InpatientPrescription;
                for (let SPTSDiag of diag.Value.SPTSMatchICDs) {
                    if (!diagnosisInfo.containsKey(SPTSDiag.SPTSDiagnosisInfo.ObjectID)) {
                        diagnosisInfo.push(SPTSDiag.SPTSDiagnosisInfo.ObjectID, SPTSDiag.SPTSDiagnosisInfo);
                    }
                }
            }
            if (diagnosisInfo.length > 0) {
                for (let diagnosisSPTS of diagnosisInfo) {
                    let diagnosisForSPTS: DiagnosisForSPTS = new DiagnosisForSPTS(this._InpatientPrescription.ObjectContext);
                    diagnosisForSPTS.SPTSDiagnosisInfo = (<SPTSDiagnosisInfo>diagnosisSPTS.Value);
                    diagnosisForSPTS.Prescription = this._InpatientPrescription;
                }
            }
        }
        super.PreScript();
        if (!String.isNullOrEmpty(this._InpatientPrescription.EReceteNo))
            this.EReceteNo.Text = this._InpatientPrescription.EReceteNo;*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InpatientPrescription();
        this.inpatientPresciriptionDrugSupplyFormViewModel = new InpatientPresciriptionDrugSupplyFormViewModel();
        this._ViewModel = this.inpatientPresciriptionDrugSupplyFormViewModel;
        this.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription = this._TTObject as InpatientPrescription;
        this.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.InpatientDrugOrders = new Array<InpatientDrugOrder>();
        this.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.Episode = new Episode();
        this.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.Episode.Patient = new Patient();
        this.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.FromResource = new ResSection();
        this.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.ExternalPharmacy = new ExternalPharmacy();
        this.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.PrescriptionPaper = new PrescriptionPaper();
    }

    protected loadViewModel() {
        let that = this;

        that.inpatientPresciriptionDrugSupplyFormViewModel = this._ViewModel as InpatientPresciriptionDrugSupplyFormViewModel;
        that._TTObject = this.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription;
        if (this.inpatientPresciriptionDrugSupplyFormViewModel == null)
            this.inpatientPresciriptionDrugSupplyFormViewModel = new InpatientPresciriptionDrugSupplyFormViewModel();
        if (this.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription == null)
            this.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription = new InpatientPrescription();
        that.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.InpatientDrugOrders = that.inpatientPresciriptionDrugSupplyFormViewModel.InpatientDrugOrdersGridList;
        for (let detailItem of that.inpatientPresciriptionDrugSupplyFormViewModel.InpatientDrugOrdersGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.inpatientPresciriptionDrugSupplyFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let materialBarcodeLevelObjectID = detailItem["MaterialBarcodeLevel"];
            if (materialBarcodeLevelObjectID != null && (typeof materialBarcodeLevelObjectID === 'string')) {
                let materialBarcodeLevel = that.inpatientPresciriptionDrugSupplyFormViewModel.MaterialBarcodeLevels.find(o => o.ObjectID.toString() === materialBarcodeLevelObjectID.toString());
                 if (materialBarcodeLevel) {
                    detailItem.MaterialBarcodeLevel = materialBarcodeLevel;
                }
            }
        }
        let episodeObjectID = that.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.inpatientPresciriptionDrugSupplyFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.inpatientPresciriptionDrugSupplyFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let fromResourceObjectID = that.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription["FromResource"];
        if (fromResourceObjectID != null && (typeof fromResourceObjectID === 'string')) {
            let fromResource = that.inpatientPresciriptionDrugSupplyFormViewModel.ResSections.find(o => o.ObjectID.toString() === fromResourceObjectID.toString());
             if (fromResource) {
                that.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.FromResource = fromResource;
            }
        }
        let externalPharmacyObjectID = that.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription["ExternalPharmacy"];
        if (externalPharmacyObjectID != null && (typeof externalPharmacyObjectID === 'string')) {
            let externalPharmacy = that.inpatientPresciriptionDrugSupplyFormViewModel.ExternalPharmacys.find(o => o.ObjectID.toString() === externalPharmacyObjectID.toString());
             if (externalPharmacy) {
                that.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.ExternalPharmacy = externalPharmacy;
            }
        }
        let prescriptionPaperObjectID = that.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription["PrescriptionPaper"];
        if (prescriptionPaperObjectID != null && (typeof prescriptionPaperObjectID === 'string')) {
            let prescriptionPaper = that.inpatientPresciriptionDrugSupplyFormViewModel.PrescriptionPapers.find(o => o.ObjectID.toString() === prescriptionPaperObjectID.toString());
             if (prescriptionPaper) {
                that.inpatientPresciriptionDrugSupplyFormViewModel._InpatientPrescription.PrescriptionPaper = prescriptionPaper;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(InpatientPresciriptionDrugSupplyFormViewModel);
  
    }


    public onDistributionNoChanged(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.DistributionNo != event) {
                this._InpatientPrescription.DistributionNo = event;
            }
        }
    }

    public onEReceteNoChanged(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.EReceteNo != event) {
                this._InpatientPrescription.EReceteNo = event;
            }
        }
    }

    public onExternalPharmacyChanged(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.ExternalPharmacy != event) {
                this._InpatientPrescription.ExternalPharmacy = event;
            }
        }
    }

    public onFromResourceChanged(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.FromResource != event) {
                this._InpatientPrescription.FromResource = event;
            }
        }
    }

    public onPatientFullNameChanged(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null &&
                this._InpatientPrescription.Episode != null &&
                this._InpatientPrescription.Episode.Patient != null && this._InpatientPrescription.Episode.Patient.FullName != event) {
                this._InpatientPrescription.Episode.Patient.FullName = event;
            }
        }
    }

    public onPrescriptionPaperChanged(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.PrescriptionPaper != event) {
                this._InpatientPrescription.PrescriptionPaper = event;
            }
        }
    }

    public onPrescriptionTypeChanged(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.PrescriptionType != event) {
                this._InpatientPrescription.PrescriptionType = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null &&
                this._InpatientPrescription.Episode != null && this._InpatientPrescription.Episode.HospitalProtocolNo != event) {
                this._InpatientPrescription.Episode.HospitalProtocolNo = event;
            }
        }
    }


    public onttdatetimepicker2Changed(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.ActionDate != event) {
                this._InpatientPrescription.ActionDate = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.PrescriptionPrice != event) {
                this._InpatientPrescription.PrescriptionPrice = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.ID != event) {
                this._InpatientPrescription.ID = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "ID");
        redirectProperty(this.ttdatetimepicker2, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "Episode.HospitalProtocolNo");
        redirectProperty(this.PatientFullName, "Text", this.__ttObject, "Episode.Patient.FullName");
        redirectProperty(this.PrescriptionType, "Value", this.__ttObject, "PrescriptionType");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "PrescriptionPrice");
        redirectProperty(this.DistributionNo, "Text", this.__ttObject, "DistributionNo");
        redirectProperty(this.EReceteNo, "Text", this.__ttObject, "EReceteNo");
    }

    public initFormControls(): void {
        this.labelDistributioınNo = new TTVisual.TTLabel();
        this.labelDistributioınNo.Text = i18n("M12444", "Dağıtım No");
        this.labelDistributioınNo.Name = "labelDistributioınNo";
        this.labelDistributioınNo.TabIndex = 91;

        this.DistributionNo = new TTVisual.TTTextBox();
        this.DistributionNo.BackColor = "#F0F0F0";
        this.DistributionNo.ReadOnly = true;
        this.DistributionNo.Name = "DistributionNo";
        this.DistributionNo.TabIndex = 90;

        this.EReceteNo = new TTVisual.TTTextBox();
        this.EReceteNo.BackColor = "#F0F0F0";
        this.EReceteNo.ReadOnly = true;
        this.EReceteNo.Name = "EReceteNo";
        this.EReceteNo.TabIndex = 87;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 7;

        this.btnEReceteNoInQuiry = new TTVisual.TTButton();
        this.btnEReceteNoInQuiry.Text = i18n("M13826", "e-Reçete Numarası Sorgula");
        this.btnEReceteNoInQuiry.Name = "btnEReceteNoInQuiry";
        this.btnEReceteNoInQuiry.TabIndex = 89;

        this.labelEReceteNo = new TTVisual.TTLabel();
        this.labelEReceteNo.Text = i18n("M13825", "e-Reçete Numarası");
        this.labelEReceteNo.Name = "labelEReceteNo";
        this.labelEReceteNo.TabIndex = 88;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M20963", "Reçete Toplam Tutarı");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 46;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 12;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M16389", "İlaçlar");
        this.tttabpage1.Name = "tttabpage1";

        this.InpatientDrugOrders = new TTVisual.TTGrid();
        this.InpatientDrugOrders.Name = "InpatientDrugOrders";
        this.InpatientDrugOrders.TabIndex = 0;
        this.InpatientDrugOrders.AllowUserToDeleteRows = false;
        this.InpatientDrugOrders.AllowUserToAddRows = false;

        this.Drug = new TTVisual.TTListBoxColumn();
        this.Drug.ListDefName = "DrugList";
        this.Drug.DataMember = "Material";
        this.Drug.DisplayIndex = 0;
        this.Drug.HeaderText = i18n("M16287", "İlaç");
        this.Drug.Name = "Drug";
        this.Drug.ReadOnly = true;
        this.Drug.Width = 300;

        this.BarcodeLevel = new TTVisual.TTTextBoxColumn();
        this.BarcodeLevel.DataMember = "Name";
        this.BarcodeLevel.DisplayIndex = 1;
        this.BarcodeLevel.HeaderText = i18n("M10766", "Ambalaj İsmi");
        this.BarcodeLevel.Name = "BarcodeLevel";
        this.BarcodeLevel.ReadOnly = true;
        this.BarcodeLevel.Width = 300;

        this.Frequency = new TTVisual.TTEnumComboBoxColumn();
        this.Frequency.DataTypeName = "FrequencyEnum";
        this.Frequency.DataMember = "Frequency";
        this.Frequency.DisplayIndex = 2;
        this.Frequency.HeaderText = i18n("M13285", "Doz Aralığı");
        this.Frequency.Name = "Frequency";
        this.Frequency.ReadOnly = true;
        this.Frequency.Width = 80;

        this.DoseAmount = new TTVisual.TTTextBoxColumn();
        this.DoseAmount.DataMember = "DoseAmount";
        this.DoseAmount.DisplayIndex = 3;
        this.DoseAmount.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmount.Name = "DoseAmount";
        this.DoseAmount.ReadOnly = true;
        this.DoseAmount.Width = 80;

        this.Day = new TTVisual.TTTextBoxColumn();
        this.Day.DataMember = "Day";
        this.Day.DisplayIndex = 4;
        this.Day.HeaderText = i18n("M14998", "Gün");
        this.Day.Name = "Day";
        this.Day.ReadOnly = true;
        this.Day.Width = 80;

        this.PackageAmount = new TTVisual.TTTextBoxColumn();
        this.PackageAmount.DataMember = "PackageAmount";
        this.PackageAmount.DisplayIndex = 5;
        this.PackageAmount.HeaderText = i18n("M20130", "Paket Adedi");
        this.PackageAmount.Name = "PackageAmount";
        this.PackageAmount.Width = 80;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 6;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 80;

        this.UsageNote = new TTVisual.TTTextBoxColumn();
        this.UsageNote.DataMember = "UsageNote";
        this.UsageNote.DisplayIndex = 7;
        this.UsageNote.HeaderText = i18n("M17991", "Kullanma Açıklaması");
        this.UsageNote.Name = "UsageNote";
        this.UsageNote.ReadOnly = true;
        this.UsageNote.Width = 200;

        this.State = new TTVisual.TTStateComboBoxColumn();
        this.State.DataMember = "CURRENTSTATEDEFID";
        this.State.DisplayIndex = 8;
        this.State.HeaderText = "Durum";
        this.State.Name = "State";
        this.State.ReadOnly = true;
        this.State.Width = 100;

        this.cmdSelectBarcodeLevel = new TTVisual.TTButtonColumn();
        this.cmdSelectBarcodeLevel.DisplayIndex = 9;
        this.cmdSelectBarcodeLevel.HeaderText = i18n("M21507", "Seç");
        this.cmdSelectBarcodeLevel.Name = "cmdSelectBarcodeLevel";
        this.cmdSelectBarcodeLevel.Width = 80;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.BackColor = "#F0F0F0";
        this.tttextbox3.ReadOnly = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 0;

        this.QuarantineProtocolNo = new TTVisual.TTTextBox();
        this.QuarantineProtocolNo.BackColor = "#F0F0F0";
        this.QuarantineProtocolNo.ReadOnly = true;
        this.QuarantineProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.QuarantineProtocolNo.Name = "QuarantineProtocolNo";
        this.QuarantineProtocolNo.TabIndex = 4;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 3;

        this.PatientFullName = new TTVisual.TTTextBox();
        this.PatientFullName.BackColor = "#F0F0F0";
        this.PatientFullName.ForeColor = "#FF0000";
        this.PatientFullName.ReadOnly = true;
        this.PatientFullName.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientFullName.Name = "PatientFullName";
        this.PatientFullName.TabIndex = 5;

        this.FromResource = new TTVisual.TTObjectListBox();
        this.FromResource.ReadOnly = true;
        this.FromResource.ListDefName = "ResourceListDefinition";
        this.FromResource.Name = "FromResource";
        this.FromResource.TabIndex = 8;

        this.labelExternalPharmacy = new TTVisual.TTLabel();
        this.labelExternalPharmacy.Text = i18n("M12430", "Dağıtılacak Eczane");
        this.labelExternalPharmacy.Name = "labelExternalPharmacy";
        this.labelExternalPharmacy.TabIndex = 24;

        this.ExternalPharmacy = new TTVisual.TTObjectListBox();
        this.ExternalPharmacy.ReadOnly = true;
        this.ExternalPharmacy.ListDefName = "ExternalPharmacyList";
        this.ExternalPharmacy.Name = "ExternalPharmacy";
        this.ExternalPharmacy.TabIndex = 11;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16866", "İşlem No");
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 16;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 12;

        this.ttdatetimepicker2 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker2.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker2.Name = "ttdatetimepicker2";
        this.ttdatetimepicker2.TabIndex = 1;

        this.ttenumcombobox1 = new TTVisual.TTEnumComboBox();
        this.ttenumcombobox1.DataTypeName = "PatientGroupEnum";
        this.ttenumcombobox1.BackColor = "#F0F0F0";
        this.ttenumcombobox1.Enabled = false;
        this.ttenumcombobox1.Name = "ttenumcombobox1";
        this.ttenumcombobox1.TabIndex = 10;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 15;

        this.labelQuarantineProtocolNo = new TTVisual.TTLabel();
        this.labelQuarantineProtocolNo.Text = i18n("M17267", "Karantina Protokol No");
        this.labelQuarantineProtocolNo.BackColor = "#DCDCDC";
        this.labelQuarantineProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelQuarantineProtocolNo.ForeColor = "#000000";
        this.labelQuarantineProtocolNo.Name = "labelQuarantineProtocolNo";
        this.labelQuarantineProtocolNo.TabIndex = 18;

        this.labelPatientGroup = new TTVisual.TTLabel();
        this.labelPatientGroup.Text = i18n("M15222", "Hasta Grubu");
        this.labelPatientGroup.BackColor = "#DCDCDC";
        this.labelPatientGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPatientGroup.ForeColor = "#000000";
        this.labelPatientGroup.Name = "labelPatientGroup";
        this.labelPatientGroup.TabIndex = 16;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 9;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M14857", "Gönderen Bölüm");
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 12;

        this.labelReasonForAdmission = new TTVisual.TTLabel();
        this.labelReasonForAdmission.Text = i18n("M17026", "Kabul Sebebi");
        this.labelReasonForAdmission.BackColor = "#DCDCDC";
        this.labelReasonForAdmission.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReasonForAdmission.ForeColor = "#000000";
        this.labelReasonForAdmission.Name = "labelReasonForAdmission";
        this.labelReasonForAdmission.TabIndex = 17;

        this.PrescriptionType = new TTVisual.TTEnumComboBox();
        this.PrescriptionType.DataTypeName = "PrescriptionTypeEnum";
        this.PrescriptionType.BackColor = "#F0F0F0";
        this.PrescriptionType.Enabled = false;
        this.PrescriptionType.Name = "PrescriptionType";
        this.PrescriptionType.TabIndex = 6;

        this.labelPrescriptionType = new TTVisual.TTLabel();
        this.labelPrescriptionType.Text = i18n("M20964", "Reçete Türü");
        this.labelPrescriptionType.Name = "labelPrescriptionType";
        this.labelPrescriptionType.TabIndex = 7;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M15133", "Hasta Adı Soyadı");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 86;

        this.PrescriptionPaper = new TTVisual.TTObjectListBox();
        this.PrescriptionPaper.ReadOnly = true;
        this.PrescriptionPaper.ListDefName = "PrescriptionPaperListDefinition";
        this.PrescriptionPaper.Name = "PrescriptionPaper";
        this.PrescriptionPaper.TabIndex = 88;

        this.labelPrescriptionNO = new TTVisual.TTLabel();
        this.labelPrescriptionNO.Text = i18n("M20953", "Reçete No");
        this.labelPrescriptionNO.BackColor = "#DCDCDC";
        this.labelPrescriptionNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPrescriptionNO.ForeColor = "#000000";
        this.labelPrescriptionNO.Name = "labelPrescriptionNO";
        this.labelPrescriptionNO.TabIndex = 14;

        this.cmdAddDetail = new TTVisual.TTButton();
        this.cmdAddDetail.Text = i18n("M13423", "E Reçete Detay Ekleme");
        this.cmdAddDetail.Name = "cmdAddDetail";
        this.cmdAddDetail.TabIndex = 89;

        this.InpatientDrugOrdersColumns = [this.Drug, this.BarcodeLevel, this.Frequency, this.DoseAmount, this.Day, this.PackageAmount, this.Amount, this.UsageNote, this.State, this.cmdSelectBarcodeLevel];
        this.tttabcontrol1.Controls = [this.tttabpage1];
        this.tttabpage1.Controls = [this.InpatientDrugOrders];
        this.Controls = [this.labelDistributioınNo, this.DistributionNo, this.EReceteNo, this.tttextbox1, this.btnEReceteNoInQuiry, this.labelEReceteNo, this.ttlabel1, this.tttabcontrol1, this.tttabpage1, this.InpatientDrugOrders, this.Drug, this.BarcodeLevel, this.Frequency, this.DoseAmount, this.Day, this.PackageAmount, this.Amount, this.UsageNote, this.State, this.cmdSelectBarcodeLevel, this.tttextbox3, this.QuarantineProtocolNo, this.ProtocolNo, this.PatientFullName, this.FromResource, this.labelExternalPharmacy, this.ExternalPharmacy, this.labelID, this.labelActionDate, this.ttdatetimepicker2, this.ttenumcombobox1, this.labelProtocolNo, this.labelQuarantineProtocolNo, this.labelPatientGroup, this.ReasonForAdmission, this.ttlabel4, this.labelReasonForAdmission, this.PrescriptionType, this.labelPrescriptionType, this.ttlabel2, this.PrescriptionPaper, this.labelPrescriptionNO, this.cmdAddDetail];

    }


}
