//$3133E3A7
import { Component, OnInit, NgZone } from '@angular/core';
import { OutPatientPrescriptionApprovalFormViewModel } from './OutPatientPrescriptionApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DiagnosisForPresc } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisForSPTS } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientPrescriptionBaseForm } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Ayaktan_Hasta_Recetesi_Modulu/OutPatientPrescriptionBaseForm";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'OutPatientPrescriptionApprovalForm',
    templateUrl: './OutPatientPrescriptionApprovalForm.html',
    providers: [MessageService]
})
export class OutPatientPrescriptionApprovalForm extends OutPatientPrescriptionBaseForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    BarcodeLevel: TTVisual.ITTTextBoxColumn;
    cmdChangeDrug: TTVisual.ITTButtonColumn;
    cmdChangeDrugFull: TTVisual.ITTButtonColumn;
    cmdSelectBarcodeLevel: TTVisual.ITTButtonColumn;
    Code: TTVisual.ITTTextBoxColumn;
    Day: TTVisual.ITTTextBoxColumn;
    Diagnose: TTVisual.ITTListBoxColumn;
    DiscriptionOfPharmacist: TTVisual.ITTTextBox;
    DoseAmount: TTVisual.ITTTextBoxColumn;
    Drug: TTVisual.ITTListBoxColumn;
    DrugSupply: TTVisual.ITTEnumComboBoxColumn;
    DrugTabPage: TTVisual.ITTTabPage;
    Emergency: TTVisual.ITTCheckBox;
    Frequency: TTVisual.ITTEnumComboBoxColumn;
    ID: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelPatientGroup: TTVisual.ITTLabel;
    labelPrescriptionType: TTVisual.ITTLabel;
    labelProtocolNoSubEpisode: TTVisual.ITTLabel;
    labelReasonForAdmission: TTVisual.ITTLabel;
    Name: TTVisual.ITTTextBoxColumn;
    OutPatientDrugOrders: TTVisual.ITTGrid;
    PackageAmount: TTVisual.ITTTextBoxColumn;
    PatientFullName: TTVisual.ITTTextBox;
    PatientGroup: TTVisual.ITTEnumComboBox;
    PhysicianDrug: TTVisual.ITTListBoxColumn;
    PrescriptionType: TTVisual.ITTEnumComboBox;
    Price: TTVisual.ITTTextBoxColumn;
    ProtocolNoSubEpisode: TTVisual.ITTTextBox;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    ReceivedPrice: TTVisual.ITTTextBoxColumn;
    Report: TTVisual.ITTCheckBoxColumn;
    RequiredAmount: TTVisual.ITTTextBoxColumn;
    SPTSDiagnosises: TTVisual.ITTGrid;
    SPTSDiagnosisInfos: TTVisual.ITTGrid;
    StoreInheld: TTVisual.ITTTextBoxColumn;
    TenDaily: TTVisual.ITTCheckBoxColumn;
    ttlabel2: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    UnitPrice: TTVisual.ITTTextBoxColumn;
    UsageNote: TTVisual.ITTTextBoxColumn;
    public OutPatientDrugOrdersColumns = [];
    public SPTSDiagnosisesColumns = [];
    public SPTSDiagnosisInfosColumns = [];
    public outPatientPrescriptionApprovalFormViewModel: OutPatientPrescriptionApprovalFormViewModel = new OutPatientPrescriptionApprovalFormViewModel();
    public get _OutPatientPrescription(): OutPatientPrescription {
        return this._TTObject as OutPatientPrescription;
    }
    private OutPatientPrescriptionApprovalForm_DocumentUrl: string = '/api/OutPatientPrescriptionService/OutPatientPrescriptionApprovalForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.OutPatientPrescriptionApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async OutPatientDrugOrders_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
      /*  if (this.OutPatientDrugOrders.CurrentCell.OwningColumn.Name === "cmdSelectBarcodeLevel") {
            if (this.OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value !== null) {
                let levels: Dictionary<Guid, MaterialBarcodeLevel> = new Dictionary<Guid, MaterialBarcodeLevel>();
                let drugDefinition: DrugDefinition = <DrugDefinition>this._OutPatientPrescription.ObjectContext.GetObject(new Guid(this.OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value.toString()), "DRUGDEFINITION");
                let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                for (let barcodeLevel of drugDefinition.MaterialBarcodeLevels) {
                    if (levels.containsKey(barcodeLevel.ObjectID) === false)
                        levels.push(barcodeLevel.ObjectID, barcodeLevel);
                }
                if (levels.length === 0)
                    TTVisual.InfoBox.Show("Bu ilacın hiçbir ambalaj şekli tanımlanmamıştır.Ambalaj şekli tanımı yapıp işleme devam edebilirsiniz.", MessageIconEnum.InformationMessage);
                for (let level of levels) {
                    multiSelectForm.AddMSItem(level.Value.Name.toString(), level.Value.Name.toString(), level.Value);
                }
                let key: string = multiSelectForm.GetMSItem(ParentForm, "İlaç Formunu Seçiniz");
                if (!String.isNullOrEmpty(key)) {
                    this.OutPatientDrugOrders.Rows[rowIndex].Cells["BarcodeLevel"].Value = (<MaterialBarcodeLevel>multiSelectForm.MSSelectedItemObject).Name.toString();
                    (<OutPatientDrugOrder>this.OutPatientDrugOrders.Rows[rowIndex].TTObject).MaterialBarcodeLevel = <MaterialBarcodeLevel>multiSelectForm.MSSelectedItemObject;
                    if (this.OutPatientDrugOrders.Rows[rowIndex].Cells["PackageAmount"].Value !== null)
                        this.OutPatientDrugOrders.Rows[rowIndex].Cells["Amount"].Value = (<number>(<MaterialBarcodeLevel>multiSelectForm.MSSelectedItemObject).PackageAmount.Value) * (<number>this.OutPatientDrugOrders.Rows[rowIndex].Cells["PackageAmount"].Value);
                }
            }
        }
        //Muadiller
        if (this.OutPatientDrugOrders.CurrentCell.OwningColumn.Name === "cmdChangeDrug") {
            if (this.OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value !== null) {
                let rAmount: number = (this.OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value) === null ? 0 : (<number>this.OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value);
                let pharmacy: PharmacyStoreDefinition = null;
                pharmacy = <PharmacyStoreDefinition>this._OutPatientPrescription.MasterResource.Store;
                let drugDefinition: DrugDefinition = <DrugDefinition>this._OutPatientPrescription.ObjectContext.GetObject(new Guid(this.OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value.toString()), "DRUGDEFINITION");
                let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                for (let relation of drugDefinition.DrugRelations) {
                    if ((<Material>relation.RelationDrug).StockInheld(<Store>pharmacy) > rAmount) {
                        multiSelectForm.AddMSItem(relation.RelationDrug.Name, relation.RelationDrug.Name, relation.RelationDrug);
                    }
                }
                if (multiSelectForm.GetMSItemCount() === 0)
                    TTVisual.InfoBox.Show("Bu ilacın hiçbir muadilinin eczanede mevcudu yoktur", MessageIconEnum.InformationMessage);
                let key: string = multiSelectForm.GetMSItem(ParentForm, "Muadil Seçiniz");
                if (!String.isNullOrEmpty(key)) {
                    this.OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value = (<DrugDefinition>multiSelectForm.MSSelectedItemObject).ObjectID;
                    this.OutPatientDrugOrders.Rows[rowIndex].Cells["BarcodeLevel"].Value = null;
                    this.OutPatientDrugOrders.Rows[rowIndex].Cells["StoreInheld"].Value = (<Material>multiSelectForm.MSSelectedItemObject).StockInheld(<Store>pharmacy);
                    let i: number = <number>(await DrugOrderService.GetDetailCount(<FrequencyEnum>this.OutPatientDrugOrders.Rows[rowIndex].Cells["Frequency"].Value)) * <number>this.OutPatientDrugOrders.Rows[rowIndex].Cells["DoseAmount"].Value;
                    this.OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value = 1 + Math.Round(i / <number>(<Material>multiSelectForm.MSSelectedItemObject).PackageAmount);
                }
            }
        }
        //Muadil İlaçlar Full
        if (this.OutPatientDrugOrders.CurrentCell.OwningColumn.Name === "cmdChangeDrugFull") {
            if (this.OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value !== null) {
                let rAmount: number = (this.OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value) === null ? 0 : (<number>this.OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value);
                let pharmacy: PharmacyStoreDefinition = null;
                pharmacy = <PharmacyStoreDefinition>this._OutPatientPrescription.MasterResource.Store;
                let drugDefinition: DrugDefinition = <DrugDefinition>this._OutPatientPrescription.ObjectContext.GetObject(new Guid(this.OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value.toString()), "DRUGDEFINITION");
                let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                let objectContext: TTObjectContext = new TTObjectContext(true);
                if (pharmacy.ObjectID.toString() !== null) {
                    let drugsInStock: Array<any> = objectContext.QueryObjects("STOCK", "STORE = '" + pharmacy.ObjectID.toString() + "' AND INHELD > " + rAmount);
                    for (let stock of drugsInStock) {
                        if (stock.Material.MaterialType === "İlaç") {
                            multiSelectForm.AddMSItem(stock.Material.Name, stock.Material.Name, stock);
                        }
                    }
                    if (multiSelectForm.GetMSItemCount() === 0)
                        TTVisual.InfoBox.Show("Eczanede yeterli miktarda ilaç bulunmamaktadır.", MessageIconEnum.InformationMessage);
                    let key: string = multiSelectForm.GetMSItem(ParentForm, "Bir İlaç Seçiniz");
                    if (!String.isNullOrEmpty(key)) {
                        this.OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value = (<Stock>multiSelectForm.MSSelectedItemObject).Material.ObjectID;
                        this.OutPatientDrugOrders.Rows[rowIndex].Cells["BarcodeLevel"].Value = null;
                        this.OutPatientDrugOrders.Rows[rowIndex].Cells["StoreInheld"].Value = (<Stock>multiSelectForm.MSSelectedItemObject).Inheld;
                        let i: number = <number>(await DrugOrderService.GetDetailCount(<FrequencyEnum>this.OutPatientDrugOrders.Rows[rowIndex].Cells["Frequency"].Value)) * <number>this.OutPatientDrugOrders.Rows[rowIndex].Cells["DoseAmount"].Value;
                        this.OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value = 1 + Math.Round(i / <number>(<Stock>multiSelectForm.MSSelectedItemObject).Material.PackageAmount);
                    }
                }
            }
        }*/
    }
    private async OutPatientDrugOrders_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.OutPatientDrugOrders.CurrentCell.OwningColumn.Name === "PackageAmount") {
            let outPatientDrugOrderRow: TTVisual.ITTGridRow = this.OutPatientDrugOrders.Rows[this.OutPatientDrugOrders.CurrentCell.RowIndex];
            let drugOrder: OutPatientDrugOrder = (<OutPatientDrugOrder>outPatientDrugOrderRow.TTObject);
            if (drugOrder.PackageAmount !== null) {
                drugOrder.Amount = drugOrder.PackageAmount * drugOrder.Material.PackageAmount;
            }
        }
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
       /* if (transDef !== null && transDef.FromStateDefID === OutPatientPrescription.OutPatientPrescriptionStates.DrugControl && transDef.ToStateDefID === InpatientPrescription.InpatientPrescriptionStates.Cancelled)
            this._OutPatientPrescription.CancelStockPrescriptionOut(this._OutPatientPrescription);*/
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
      /*  let outPatientPrescription: OutPatientPrescription = <OutPatientPrescription>this._ttObject;
        let message: string = "";
        let messageCount: number = 0;
        if ((await SystemParameterService.GetParameterValue("INPATIENTPRESDRUGCONTROL", "FALSE")) === "TRUE") {
            for (let outPatientDrugOrder of outPatientPrescription.OutPatientDrugOrders) {
                if (outPatientDrugOrder.RequiredAmount > outPatientDrugOrder.Amount) {
                    message = message + " " + outPatientDrugOrder.Material.Name.toString() + " ilacının karşılanan miktarı istenen miktarından az olamaz. ";
                    messageCount = messageCount + 1;
                }
            }
        }
        if (messageCount > 0) {
            throw new Exception(message);
        }*/
    }
    protected async PreScript() {
        super.PreScript();
      /*  let pharmacy: PharmacyStoreDefinition = null;
        pharmacy = <PharmacyStoreDefinition>this._OutPatientPrescription.MasterResource.Store;
        //Tanılar yazılıyor.
        let diagForPres: Dictionary<Guid, string> = new Dictionary<Guid, string>();
        let diagnosisInfo: Dictionary<Guid, SPTSDiagnosisInfo> = new Dictionary<Guid, SPTSDiagnosisInfo>();
        for (let diag of this._OutPatientPrescription.Episode.Diagnosis) {
            if (diagForPres.containsKey(diag.Diagnose.ObjectID) === false) {
                let diagForPresc: DiagnosisForPresc = new DiagnosisForPresc(this._OutPatientPrescription.ObjectContext);
                diagForPresc.Code = diag.Diagnose.Code;
                diagForPresc.Name = diag.Diagnose.Name.toString();
                this._OutPatientPrescription.SPTSDiagnosises.push(diagForPresc);
                diagForPres.push(diag.Diagnose.ObjectID, diag.Diagnose.Code);
                for (let SPTSDiag of diag.Diagnose.SPTSMatchICDs) {
                    if (!diagnosisInfo.containsKey(SPTSDiag.SPTSDiagnosisInfo.ObjectID)) {
                        diagnosisInfo.push(SPTSDiag.SPTSDiagnosisInfo.ObjectID, SPTSDiag.SPTSDiagnosisInfo);
                    }
                }
            }
        }
        if (diagnosisInfo.length > 0) {
            for (let diagnosisSPTS of diagnosisInfo) {
                let diagnosisForSPTS: DiagnosisForSPTS = new DiagnosisForSPTS(this._OutPatientPrescription.ObjectContext);
                diagnosisForSPTS.SPTSDiagnosisInfo = (<SPTSDiagnosisInfo>diagnosisSPTS.Value);
                this._OutPatientPrescription.DiagnosisForSPTSs.push(diagnosisForSPTS);
            }
        }
        //Muadilleri listeler
        //            foreach (ITTGridRow drugOrderRow in this.OutPatientDrugOrders.Rows)
        //            {
        ////                OutPatientDrugOrder outPatientDrugOrder = (OutPatientDrugOrder)drugOrderRow.TTObject;
        ////                string objectIDs = string.Empty;
        ////                string filter = string.Empty;
        ////                foreach (DrugRelation relation in ((DrugDefinition)outPatientDrugOrder.Material).DrugRelations)
        ////                {
        ////                    objectIDs += ConnectionManager.GuidToString(relation.ObjectID) + ",";
        ////                }
        ////                if (objectIDs == string.Empty)
        ////                {
        ////                    ((ITTListBoxColumn)drugOrderRow.Cells[1]).ListFilterExpression = "";
        ////                }
        ////                else
        ////                {
        ////                    filter = objectIDs.Substring(0, filter.Length);
        ////                    ((ITTListBoxColumn)drugOrderRow.Cells[1]).ListFilterExpression = "OBJECTID in (" + filter + ")";
        ////                }
        //            }


        let allDrugInheld: boolean = true;
        for (let drugOrder of this._OutPatientPrescription.OutPatientDrugOrders) {
            if (drugOrder.Material.StockInheld(<Store>pharmacy) > drugOrder.Amount) {
                drugOrder.StoreInheld = drugOrder.Material.StockInheld(<Store>pharmacy);
            }
            else {
                drugOrder.StoreInheld = drugOrder.Material.StockInheld(<Store>pharmacy);
                //drugOrder.DrugSupply = OutPatientDrugSupplyEnum.UnSupply;
                allDrugInheld = false;
            }
        }*/
    }

    // *****Method declarations end *****

    onttdatetimepicker1Changed(data: any){}
    onEReceteNoChanged(data: any){}
    onReceiptNOChanged(data: any){}
    ttdatetimepicker1;
    EReceteNo;
    ReceiptNO;

    public initViewModel(): void {
        this._TTObject = new OutPatientPrescription();
        this.outPatientPrescriptionApprovalFormViewModel = new OutPatientPrescriptionApprovalFormViewModel();
        this._ViewModel = this.outPatientPrescriptionApprovalFormViewModel;
        this.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription = this._TTObject as OutPatientPrescription;
        this.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription.Episode = new Episode();
        this.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription.Episode.Patient = new Patient();
        this.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription.OutPatientDrugOrders = new Array<OutPatientDrugOrder>();
        this.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription.SPTSDiagnosises = new Array<DiagnosisForPresc>();
        this.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription.DiagnosisForSPTSs = new Array<DiagnosisForSPTS>();
    }

    protected loadViewModel() {
        let that = this;

        that.outPatientPrescriptionApprovalFormViewModel = this._ViewModel as OutPatientPrescriptionApprovalFormViewModel;
        that._TTObject = this.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription;
        if (this.outPatientPrescriptionApprovalFormViewModel == null)
            this.outPatientPrescriptionApprovalFormViewModel = new OutPatientPrescriptionApprovalFormViewModel();
        if (this.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription == null)
            this.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription = new OutPatientPrescription();
        let episodeObjectID = that.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.outPatientPrescriptionApprovalFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.outPatientPrescriptionApprovalFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        that.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription.OutPatientDrugOrders = that.outPatientPrescriptionApprovalFormViewModel.OutPatientDrugOrdersGridList;
        for (let detailItem of that.outPatientPrescriptionApprovalFormViewModel.OutPatientDrugOrdersGridList) {
            let physicianDrugObjectID = detailItem["PhysicianDrug"];
            if (physicianDrugObjectID != null && (typeof physicianDrugObjectID === 'string')) {
                let physicianDrug = that.outPatientPrescriptionApprovalFormViewModel.DrugDefinitions.find(o => o.ObjectID.toString() === physicianDrugObjectID.toString());
                 if (physicianDrug) {
                    detailItem.PhysicianDrug = physicianDrug;
                }
            }
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.outPatientPrescriptionApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
        that.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription.SPTSDiagnosises = that.outPatientPrescriptionApprovalFormViewModel.SPTSDiagnosisesGridList;
        for (let detailItem of that.outPatientPrescriptionApprovalFormViewModel.SPTSDiagnosisesGridList) {
        }
        that.outPatientPrescriptionApprovalFormViewModel._OutPatientPrescription.DiagnosisForSPTSs = that.outPatientPrescriptionApprovalFormViewModel.SPTSDiagnosisInfosGridList;
        for (let detailItem of that.outPatientPrescriptionApprovalFormViewModel.SPTSDiagnosisInfosGridList) {
            let sPTSDiagnosisInfoObjectID = detailItem["SPTSDiagnosisInfo"];
            if (sPTSDiagnosisInfoObjectID != null && (typeof sPTSDiagnosisInfoObjectID === 'string')) {
                let sPTSDiagnosisInfo = that.outPatientPrescriptionApprovalFormViewModel.SPTSDiagnosisInfos.find(o => o.ObjectID.toString() === sPTSDiagnosisInfoObjectID.toString());
                 if (sPTSDiagnosisInfo) {
                    detailItem.SPTSDiagnosisInfo = sPTSDiagnosisInfo;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(OutPatientPrescriptionApprovalFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.ActionDate != event) {
                this._OutPatientPrescription.ActionDate = event;
            }
        }
    }

    public onDiscriptionOfPharmacistChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.DiscriptionOfPharmacist != event) {
                this._OutPatientPrescription.DiscriptionOfPharmacist = event;
            }
        }
    }

    public onEmergencyChanged(event): void {
        if (event != null) {
            if (this._OutPatientPrescription != null && this._OutPatientPrescription.Emergency != event) {
                this._OutPatientPrescription.Emergency = event;
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



    OutPatientDrugOrders_CellValueChangedEmitted(data: any) {
        if (data && this.OutPatientDrugOrders_CellValueChanged && data.Row && data.Column) {
            this.OutPatientDrugOrders.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };
            this.OutPatientDrugOrders_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.ID, "Text", this.__ttObject, "ID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ProtocolNoSubEpisode, "Text", this.__ttObject, "Episode.HospitalProtocolNo");
        redirectProperty(this.PatientFullName, "Text", this.__ttObject, "Episode.Patient.FullName");
        redirectProperty(this.PrescriptionType, "Value", this.__ttObject, "PrescriptionType");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.DiscriptionOfPharmacist, "Text", this.__ttObject, "DiscriptionOfPharmacist");
    }

    public initFormControls(): void {
        this.ProtocolNoSubEpisode = new TTVisual.TTTextBox();
        this.ProtocolNoSubEpisode.BackColor = "#F0F0F0";
        this.ProtocolNoSubEpisode.ReadOnly = true;
        this.ProtocolNoSubEpisode.Name = "ProtocolNoSubEpisode";
        this.ProtocolNoSubEpisode.TabIndex = 2;

        this.DigitalSignatureButton = new TTVisual.TTButton();
        this.DigitalSignatureButton.Text = i18n("M13510", "e-imza doğrulanamadı");
        this.DigitalSignatureButton.Name = "DigitalSignatureButton";
        this.DigitalSignatureButton.TabIndex = 95;
        this.DigitalSignatureButton.Visible = false;

        this.PatientFullName = new TTVisual.TTTextBox();
        this.PatientFullName.BackColor = "#F0F0F0";
        this.PatientFullName.ForeColor = "#FF0000";
        this.PatientFullName.ReadOnly = true;
        this.PatientFullName.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientFullName.Name = "PatientFullName";
        this.PatientFullName.TabIndex = 3;

        this.labelProtocolNoSubEpisode = new TTVisual.TTLabel();
        this.labelProtocolNoSubEpisode.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNoSubEpisode.Name = "labelProtocolNoSubEpisode";
        this.labelProtocolNoSubEpisode.TabIndex = 97;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 12;

        this.DrugTabPage = new TTVisual.TTTabPage();
        this.DrugTabPage.DisplayIndex = 0;
        this.DrugTabPage.BackColor = "#FFFFFF";
        this.DrugTabPage.TabIndex = 0;
        this.DrugTabPage.Text = i18n("M16389", "İlaçlar");
        this.DrugTabPage.Name = "DrugTabPage";

        this.OutPatientDrugOrders = new TTVisual.TTGrid();
        this.OutPatientDrugOrders.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.OutPatientDrugOrders.Name = "OutPatientDrugOrders";
        this.OutPatientDrugOrders.TabIndex = 0;

        this.cmdChangeDrug = new TTVisual.TTButtonColumn();
        this.cmdChangeDrug.Text = i18n("M19155", "Muadiller");
        this.cmdChangeDrug.UseColumnTextForButtonValue = true;
        this.cmdChangeDrug.DisplayIndex = 0;
        this.cmdChangeDrug.HeaderText = "";
        this.cmdChangeDrug.Name = "cmdChangeDrug";
        this.cmdChangeDrug.ToolTipText = i18n("M19155", "Muadiller");
        this.cmdChangeDrug.Visible = false;
        this.cmdChangeDrug.Width = 100;

        this.cmdChangeDrugFull = new TTVisual.TTButtonColumn();
        this.cmdChangeDrugFull.Text = i18n("M19154", "Muadil İlaçlar");
        this.cmdChangeDrugFull.DisplayIndex = 1;
        this.cmdChangeDrugFull.HeaderText = " ";
        this.cmdChangeDrugFull.Name = "cmdChangeDrugFull";
        this.cmdChangeDrugFull.ToolTipText = i18n("M19154", "Muadil İlaçlar");
        this.cmdChangeDrugFull.Width = 100;

        this.cmdSelectBarcodeLevel = new TTVisual.TTButtonColumn();
        this.cmdSelectBarcodeLevel.Text = "Amb.Tipi Değ.";
        this.cmdSelectBarcodeLevel.UseColumnTextForButtonValue = true;
        this.cmdSelectBarcodeLevel.DisplayIndex = 2;
        this.cmdSelectBarcodeLevel.HeaderText = "";
        this.cmdSelectBarcodeLevel.Name = "cmdSelectBarcodeLevel";
        this.cmdSelectBarcodeLevel.ToolTipText = "Amb.Tipi Değ.";
        this.cmdSelectBarcodeLevel.Visible = false;
        this.cmdSelectBarcodeLevel.Width = 100;

        this.PhysicianDrug = new TTVisual.TTListBoxColumn();
        this.PhysicianDrug.ListDefName = "DrugList";
        this.PhysicianDrug.DataMember = "PhysicianDrug";
        this.PhysicianDrug.DisplayIndex = 3;
        this.PhysicianDrug.HeaderText = i18n("M16287", "İlaç");
        this.PhysicianDrug.Name = "PhysicianDrug";
        this.PhysicianDrug.ReadOnly = true;
        this.PhysicianDrug.Width = 300;

        this.Drug = new TTVisual.TTListBoxColumn();
        this.Drug.ListDefName = "DrugList";
        this.Drug.DataMember = "Material";
        this.Drug.Required = true;
        this.Drug.DisplayIndex = 4;
        this.Drug.HeaderText = i18n("M24102", "Verilecek İlaç");
        this.Drug.Name = "Drug";
        this.Drug.ReadOnly = true;
        this.Drug.Width = 300;

        this.BarcodeLevel = new TTVisual.TTTextBoxColumn();
        this.BarcodeLevel.DataMember = "BarcodeLevel";
        this.BarcodeLevel.DisplayIndex = 5;
        this.BarcodeLevel.HeaderText = i18n("M10766", "Ambalaj İsmi");
        this.BarcodeLevel.Name = "BarcodeLevel";
        this.BarcodeLevel.ReadOnly = true;
        this.BarcodeLevel.Visible = false;
        this.BarcodeLevel.Width = 300;

        this.Frequency = new TTVisual.TTEnumComboBoxColumn();
        this.Frequency.DataTypeName = "FrequencyEnum";
        this.Frequency.DataMember = "Frequency";
        this.Frequency.DisplayIndex = 6;
        this.Frequency.HeaderText = i18n("M13285", "Doz Aralığı");
        this.Frequency.Name = "Frequency";
        this.Frequency.ReadOnly = true;
        this.Frequency.Width = 80;

        this.DoseAmount = new TTVisual.TTTextBoxColumn();
        this.DoseAmount.DataMember = "DoseAmount";
        this.DoseAmount.DisplayIndex = 7;
        this.DoseAmount.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmount.Name = "DoseAmount";
        this.DoseAmount.ReadOnly = true;
        this.DoseAmount.Width = 80;

        this.Day = new TTVisual.TTTextBoxColumn();
        this.Day.DataMember = "Day";
        this.Day.DisplayIndex = 8;
        this.Day.HeaderText = i18n("M14998", "Gün");
        this.Day.Name = "Day";
        this.Day.ReadOnly = true;
        this.Day.Width = 80;

        this.RequiredAmount = new TTVisual.TTTextBoxColumn();
        this.RequiredAmount.DataMember = "RequiredAmount";
        this.RequiredAmount.DisplayIndex = 9;
        this.RequiredAmount.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequiredAmount.Name = "RequiredAmount";
        this.RequiredAmount.ReadOnly = true;
        this.RequiredAmount.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 10;
        this.Amount.HeaderText = i18n("M17315", "Karşılanan Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 120;

        this.PackageAmount = new TTVisual.TTTextBoxColumn();
        this.PackageAmount.DataMember = "PackageAmount";
        this.PackageAmount.DisplayIndex = 11;
        this.PackageAmount.HeaderText = i18n("M20130", "Paket Adedi");
        this.PackageAmount.Name = "PackageAmount";
        this.PackageAmount.Width = 80;

        this.StoreInheld = new TTVisual.TTTextBoxColumn();
        this.StoreInheld.DataMember = "StoreInheld";
        this.StoreInheld.DisplayIndex = 12;
        this.StoreInheld.HeaderText = i18n("M13460", "Eczane Mevcudu");
        this.StoreInheld.Name = "StoreInheld";
        this.StoreInheld.ReadOnly = true;
        this.StoreInheld.Width = 120;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.DisplayIndex = 13;
        this.UnitPrice.HeaderText = i18n("M11855", "Birim Fiyat");
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.Visible = false;
        this.UnitPrice.Width = 100;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.DisplayIndex = 14;
        this.Price.HeaderText = i18n("M23606", "Tutar");
        this.Price.Name = "Price";
        this.Price.Visible = false;
        this.Price.Width = 80;

        this.ReceivedPrice = new TTVisual.TTTextBoxColumn();
        this.ReceivedPrice.DataMember = "ReceivedPrice";
        this.ReceivedPrice.DisplayIndex = 15;
        this.ReceivedPrice.HeaderText = i18n("M16341", "İlaç Katılım Payı");
        this.ReceivedPrice.Name = "ReceivedPrice";
        this.ReceivedPrice.Visible = false;
        this.ReceivedPrice.Width = 140;

        this.UsageNote = new TTVisual.TTTextBoxColumn();
        this.UsageNote.DataMember = "UsageNote";
        this.UsageNote.DisplayIndex = 16;
        this.UsageNote.HeaderText = i18n("M17992", "Kullanma Tarifi");
        this.UsageNote.Name = "UsageNote";
        this.UsageNote.ReadOnly = true;
        this.UsageNote.Width = 200;

        this.Report = new TTVisual.TTCheckBoxColumn();
        this.Report.DataMember = "Report";
        this.Report.DisplayIndex = 17;
        this.Report.HeaderText = i18n("M20889", "Raporlu");
        this.Report.Name = "Report";
        this.Report.Width = 80;

        this.TenDaily = new TTVisual.TTCheckBoxColumn();
        this.TenDaily.DataMember = "TenDaily";
        this.TenDaily.DisplayIndex = 18;
        this.TenDaily.HeaderText = "On Günlük";
        this.TenDaily.Name = "TenDaily";
        this.TenDaily.Width = 100;

        this.DrugSupply = new TTVisual.TTEnumComboBoxColumn();
        this.DrugSupply.DataTypeName = "OutPatientDrugSupplyEnum";
        this.DrugSupply.DataMember = "DrugSupply";
        this.DrugSupply.Required = true;
        this.DrugSupply.DisplayIndex = 19;
        this.DrugSupply.HeaderText = i18n("M17312", "Karşılama Durumu");
        this.DrugSupply.Name = "DrugSupply";
        this.DrugSupply.ToolTipText = i18n("M17312", "Karşılama Durumu");
        this.DrugSupply.Width = 100;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = "#F0F0F0";
        this.ID.ReadOnly = true;
        this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ID.Name = "ID";
        this.ID.TabIndex = 0;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.BackColor = "#DCDCDC";
        this.labelActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelActionDate.ForeColor = "#000000";
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 85;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 1;

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 8;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16866", "İşlem No");
        this.labelID.BackColor = "#DCDCDC";
        this.labelID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelID.ForeColor = "#000000";
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 84;

        this.labelReasonForAdmission = new TTVisual.TTLabel();
        this.labelReasonForAdmission.Text = i18n("M17026", "Kabul Sebebi");
        this.labelReasonForAdmission.BackColor = "#DCDCDC";
        this.labelReasonForAdmission.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReasonForAdmission.ForeColor = "#000000";
        this.labelReasonForAdmission.Name = "labelReasonForAdmission";
        this.labelReasonForAdmission.TabIndex = 88;

        this.PrescriptionType = new TTVisual.TTEnumComboBox();
        this.PrescriptionType.DataTypeName = "PrescriptionTypeEnum";
        this.PrescriptionType.BackColor = "#F0F0F0";
        this.PrescriptionType.Enabled = false;
        this.PrescriptionType.Name = "PrescriptionType";
        this.PrescriptionType.TabIndex = 4;

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
        this.PatientGroup.TabIndex = 9;

        this.labelPatientGroup = new TTVisual.TTLabel();
        this.labelPatientGroup.Text = i18n("M15222", "Hasta Grubu");
        this.labelPatientGroup.Name = "labelPatientGroup";
        this.labelPatientGroup.TabIndex = 3;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 11;

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
        this.tttabpage3.Text = i18n("M13449", "Eczacının Açıklamaları");
        this.tttabpage3.Name = "tttabpage3";

        this.DiscriptionOfPharmacist = new TTVisual.TTTextBox();
        this.DiscriptionOfPharmacist.Multiline = true;
        this.DiscriptionOfPharmacist.Name = "DiscriptionOfPharmacist";
        this.DiscriptionOfPharmacist.TabIndex = 98;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Text = i18n("M10422", "Acil Durum");
        this.Emergency.Enabled = false;
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 16;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M15133", "Hasta Adı Soyadı");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 86;

        this.OutPatientDrugOrdersColumns = [this.cmdChangeDrug, this.cmdChangeDrugFull, this.cmdSelectBarcodeLevel, this.PhysicianDrug, this.Drug, this.BarcodeLevel, this.Frequency, this.DoseAmount, this.Day, this.RequiredAmount, this.Amount, this.PackageAmount, this.StoreInheld, this.UnitPrice, this.Price, this.ReceivedPrice, this.UsageNote, this.Report, this.TenDaily, this.DrugSupply];
        this.SPTSDiagnosisesColumns = [this.Code, this.Name];
        this.SPTSDiagnosisInfosColumns = [this.Diagnose];
        this.tttabcontrol1.Controls = [this.DrugTabPage];
        this.DrugTabPage.Controls = [this.OutPatientDrugOrders];
        this.tttabcontrol2.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3];
        this.tttabpage1.Controls = [this.SPTSDiagnosises];
        this.tttabpage2.Controls = [this.SPTSDiagnosisInfos];
        this.tttabpage3.Controls = [this.DiscriptionOfPharmacist];
        this.Controls = [this.ProtocolNoSubEpisode, this.DigitalSignatureButton, this.PatientFullName, this.labelProtocolNoSubEpisode, this.tttabcontrol1, this.DrugTabPage, this.OutPatientDrugOrders, this.cmdChangeDrug, this.cmdChangeDrugFull, this.cmdSelectBarcodeLevel, this.PhysicianDrug, this.Drug, this.BarcodeLevel, this.Frequency, this.DoseAmount, this.Day, this.RequiredAmount, this.Amount, this.PackageAmount, this.StoreInheld, this.UnitPrice, this.Price, this.ReceivedPrice, this.UsageNote, this.Report, this.TenDaily, this.DrugSupply, this.ID, this.labelActionDate, this.ActionDate, this.ReasonForAdmission, this.labelID, this.labelReasonForAdmission, this.PrescriptionType, this.labelPrescriptionType, this.PatientGroup, this.labelPatientGroup, this.tttabcontrol2, this.tttabpage1, this.SPTSDiagnosises, this.Code, this.Name, this.tttabpage2, this.SPTSDiagnosisInfos, this.Diagnose, this.tttabpage3, this.DiscriptionOfPharmacist, this.Emergency, this.ttlabel2];

    }


}
