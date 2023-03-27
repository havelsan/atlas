//$02FA9AEA
import { Component, OnInit, NgZone } from '@angular/core';
import { InpatientPresciriptionFormViewModel } from './InpatientPresciriptionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DiagnosisForPresc } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderService } from "ObjectClassService/DrugOrderService";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { FrequencyEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InpatientDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientPrescriptionBaseForm } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Yatan_Hasta_Recetesi_Modulu/InpatientPrescriptionBaseForm";
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PrescriptionPaper } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionService, InPatientPhysicianApplication_Output } from 'Fw/Services/StockActionService';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
@Component({
    selector: 'InpatientPresciriptionForm',
    templateUrl: './InpatientPresciriptionForm.html',
    providers: [MessageService]
})
export class InpatientPresciriptionForm extends InpatientPrescriptionBaseForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    PackageAmount: TTVisual.ITTTextBoxColumn;
    cmdAddDetail: TTVisual.ITTButton;
    CodeDiagnosisForPresc: TTVisual.ITTTextBoxColumn;
    Day: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    DescriptionType: TTVisual.ITTEnumComboBoxColumn;
    DiagTabPage: TTVisual.ITTTabPage;
    DoseAmount: TTVisual.ITTTextBoxColumn;
    Drug: TTVisual.ITTListBoxColumn;
    DrugTabPage: TTVisual.ITTTabPage;
    Frequency: TTVisual.ITTEnumComboBoxColumn;
    FromResource: TTVisual.ITTObjectListBox;
    ID: TTVisual.ITTTextBox;
    EReceteNo: TTVisual.ITTTextBox;
    InpatientDrugOrders: TTVisual.ITTGrid;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelMasterResource: TTVisual.ITTLabel;
    labelPatientGroup: TTVisual.ITTLabel;
    labelPrescriptionNO: TTVisual.ITTLabel;
    labelPrescriptionType: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelQuarantineProtocolNo: TTVisual.ITTLabel;
    labelReasonForAdmission: TTVisual.ITTLabel;
    NameDiagnosisForPresc: TTVisual.ITTTextBoxColumn;
    PatientFullName: TTVisual.ITTTextBox;
    PrescriptionPaper: TTVisual.ITTObjectListBox;
    PrescriptionType: TTVisual.ITTEnumComboBox;
    ProtocolNo: TTVisual.ITTTextBox;
    QuarantineProtocolNo: TTVisual.ITTTextBox;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    SPTSDiagnosises: TTVisual.ITTGrid;
    ttenumcombobox1: TTVisual.ITTEnumComboBox;
    ttlabel2: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttoolstrip1: TTVisual.ITTToolStrip;
    UsageNote: TTVisual.ITTTextBoxColumn;

    public clinicName: string;
    public clinicRoom: string;
    public clinicBed: string;
    public clinicProtocolNo: string;
    public clinicDischargeDate: Date;
    public hasPhysicianApplication: boolean = true;


    public InpatientDrugOrdersColumns = [];
    public SPTSDiagnosisesColumns = [];
    public inpatientPresciriptionFormViewModel: InpatientPresciriptionFormViewModel = new InpatientPresciriptionFormViewModel();
    public get _InpatientPrescription(): InpatientPrescription {
        return this._TTObject as InpatientPrescription;
    }
    private InpatientPresciriptionForm_DocumentUrl: string = '/api/InpatientPrescriptionService/InpatientPresciriptionForm';
    constructor(protected httpService: NeHttpService, private objectContextService: ObjectContextService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.InpatientPresciriptionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async ClientSidePreScript(): Promise<void> {

        let output: InPatientPhysicianApplication_Output = await StockActionService.GetInPatientPhysicianApplication_InfoByEpisode(this._InpatientPrescription.Episode.ObjectID.toString());

        if (output != null) {
            this.hasPhysicianApplication = true;
            this.clinicProtocolNo = output.clinicProtocolNo;
            this.clinicBed = output.clinicBed;
            this.clinicRoom = output.clinicRoom;
            this.clinicName = output.clinicName;
            this.clinicDischargeDate = output.clinicDischargeDate;
        }
        else {
            this.hasPhysicianApplication = false;
        }
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
    private async InpatientDrugOrders_RowLeave(rowIndex: number, columnIndex: number): Promise<void> {
        let inpatientDrugOrderRow: TTVisual.ITTGridRow = this.InpatientDrugOrders.Rows[this.InpatientDrugOrders.CurrentCell.RowIndex];
        if (inpatientDrugOrderRow.Cells["Drug"].Value !== null) {
            if (inpatientDrugOrderRow.Cells["Frequency"].Value !== null && inpatientDrugOrderRow.Cells["DoseAmount"].Value !== null && inpatientDrugOrderRow.Cells["Day"].Value !== null) {
                let detailCount: number = (await DrugOrderService.GetDetailCount(<FrequencyEnum>inpatientDrugOrderRow.Cells["Frequency"].Value));
                let detailTimePeriod: number = (await DrugOrderService.GetDetailTimePeriod(<FrequencyEnum>inpatientDrugOrderRow.Cells["Frequency"].Value));
                let drugDefinition: DrugDefinition = <DrugDefinition>this._InpatientPrescription.ObjectContext.GetObject(new Guid(inpatientDrugOrderRow.Cells["Drug"].Value.toString()), "DRUGDEFINITION");
                let unitAmount: number = 0;
                let drugType: boolean = (await DrugOrderService.GetDrugUsedType(drugDefinition));
                if (drugType) {
                    unitAmount = <number>inpatientDrugOrderRow.Cells["DoseAmount"].Value;
                }
                else {
                    unitAmount = <number>inpatientDrugOrderRow.Cells["DoseAmount"].Value * <number>drugDefinition.Dose / <number>drugDefinition.Volume;
                }
                detailCount = detailCount * <number>inpatientDrugOrderRow.Cells["Day"].Value;
                inpatientDrugOrderRow.Cells["Amount"].Value = unitAmount * <number>(detailCount * <number>inpatientDrugOrderRow.Cells["Day"].Value);
            }
            else {
                throw new TTException((await SystemMessageService.GetMessage(1009)));
            }
        }
    }
    /*  private async tttoolstrip1_ItemClicked(item: TTVisual.ITTToolStripItem): Promise<void> {
         let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
          let prescritiontype: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
          switch (item.Name) {
              case "PrescriptionReportByDrungOrderIntroduction":
                  prescritiontype.push("VALUE", this._InpatientPrescription.PrescriptionType.Value.toString());
                  parameters.push("PRESCRIPTIONTYPE", prescritiontype);
                  prescritiontype.push("VALUE", this._InpatientPrescription.ObjectID.toString());
                  parameters.push("TTOBJECTID", prescritiontype);
                  TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_PrescriptionReportByDrungOrderIntroduction, true, 1, parameters);
                  break;
              default:
                  break;
      }
      }*/
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        /* let inpatientPrescription: InpatientPrescription = <InpatientPrescription>this._ttObject;
         let dictionary: Dictionary<Guid, Object> = new Dictionary<Guid, Object>();
         for (let i: number = 0; i < inpatientPrescription.InpatientDrugOrders.length; i++) {
             let guid: Guid = new Guid(this.InpatientDrugOrders.Rows[i].Cells[0].Value.toString());
             dictionary.push(guid, _ttObject);
             if (dictionary.containsKey(guid)) {

             }
         }*/
    }
    public doctorName;
    protected async PreScript() {

    let doctorObjID: any = this._InpatientPrescription.ProcedureDoctor;
        let doctor = await this.objectContextService.getObject(new Guid(doctorObjID), ResUser.ObjectDefID);
        if (doctor != null) {
            this.doctorName = (<ResUser>doctor).Name.toString();
        }
        /*  let diagnosisInfo: Dictionary<Guid, SPTSDiagnosisInfo> = new Dictionary<Guid, SPTSDiagnosisInfo>();
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
          let totalPrice: number = 0;
          for (let inpatientDrugOrder of this._InpatientPrescription.InpatientDrugOrders) {
              if (inpatientDrugOrder.Material.PackageAmount !== null) {
                  let drugDefinition: DrugDefinition = (<DrugDefinition>inpatientDrugOrder.Material);
                  if (inpatientDrugOrder.Amount > <number>inpatientDrugOrder.Material.PackageAmount.Value) {
                      inpatientDrugOrder.PackageAmount = Math.Ceiling(<number>inpatientDrugOrder.Amount / (<number>inpatientDrugOrder.Material.PackageAmount.Value));
                      inpatientDrugOrder.Amount = (<number>inpatientDrugOrder.PackageAmount) * (<number>inpatientDrugOrder.Material.PackageAmount.Value);
                  }
                  else {
                      inpatientDrugOrder.PackageAmount = 1;
                      inpatientDrugOrder.Amount = (<number>inpatientDrugOrder.Material.PackageAmount.Value);
                  }
              }
              if (inpatientDrugOrder.Material.CurrentPrice !== null && inpatientDrugOrder.PackageAmount !== null)
                  totalPrice += <number>inpatientDrugOrder.Material.CurrentPrice * <number>inpatientDrugOrder.PackageAmount;
          }
          this._InpatientPrescription.PrescriptionPrice = totalPrice;
          if (this._InpatientPrescription.IsInfectionApproval() === false)
              this.DropStateButton(InpatientPrescription.InpatientPrescriptionStates.InfectionApproval);*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InpatientPrescription();
        this.inpatientPresciriptionFormViewModel = new InpatientPresciriptionFormViewModel();
        this._ViewModel = this.inpatientPresciriptionFormViewModel;
        this.inpatientPresciriptionFormViewModel._InpatientPrescription = this._TTObject as InpatientPrescription;
        this.inpatientPresciriptionFormViewModel._InpatientPrescription.SPTSDiagnosises = new Array<DiagnosisForPresc>();
        this.inpatientPresciriptionFormViewModel._InpatientPrescription.InpatientDrugOrders = new Array<InpatientDrugOrder>();
        this.inpatientPresciriptionFormViewModel._InpatientPrescription.Episode = new Episode();
        this.inpatientPresciriptionFormViewModel._InpatientPrescription.Episode.Patient = new Patient();
        this.inpatientPresciriptionFormViewModel._InpatientPrescription.FromResource = new ResSection();
        this.inpatientPresciriptionFormViewModel._InpatientPrescription.PrescriptionPaper = new PrescriptionPaper();
    }

    protected loadViewModel() {
        let that = this;

        that.inpatientPresciriptionFormViewModel = this._ViewModel as InpatientPresciriptionFormViewModel;
        that._TTObject = this.inpatientPresciriptionFormViewModel._InpatientPrescription;
        if (this.inpatientPresciriptionFormViewModel == null)
            this.inpatientPresciriptionFormViewModel = new InpatientPresciriptionFormViewModel();
        if (this.inpatientPresciriptionFormViewModel._InpatientPrescription == null)
            this.inpatientPresciriptionFormViewModel._InpatientPrescription = new InpatientPrescription();
        that.inpatientPresciriptionFormViewModel._InpatientPrescription.SPTSDiagnosises = that.inpatientPresciriptionFormViewModel.SPTSDiagnosisesGridList;
        for (let detailItem of that.inpatientPresciriptionFormViewModel.SPTSDiagnosisesGridList) {
        }
        that.inpatientPresciriptionFormViewModel._InpatientPrescription.InpatientDrugOrders = that.inpatientPresciriptionFormViewModel.InpatientDrugOrdersGridList;
        for (let detailItem of that.inpatientPresciriptionFormViewModel.InpatientDrugOrdersGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.inpatientPresciriptionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
        let episodeObjectID = that.inpatientPresciriptionFormViewModel._InpatientPrescription["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.inpatientPresciriptionFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.inpatientPresciriptionFormViewModel._InpatientPrescription.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.inpatientPresciriptionFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let fromResourceObjectID = that.inpatientPresciriptionFormViewModel._InpatientPrescription["FromResource"];
        if (fromResourceObjectID != null && (typeof fromResourceObjectID === 'string')) {
            let fromResource = that.inpatientPresciriptionFormViewModel.ResSections.find(o => o.ObjectID.toString() === fromResourceObjectID.toString());
             if (fromResource) {
                that.inpatientPresciriptionFormViewModel._InpatientPrescription.FromResource = fromResource;
            }
        }
        let prescriptionPaperObjectID = that.inpatientPresciriptionFormViewModel._InpatientPrescription["PrescriptionPaper"];
        if (prescriptionPaperObjectID != null && (typeof prescriptionPaperObjectID === 'string')) {
            let prescriptionPaper = that.inpatientPresciriptionFormViewModel.PrescriptionPapers.find(o => o.ObjectID.toString() === prescriptionPaperObjectID.toString());
             if (prescriptionPaper) {
                that.inpatientPresciriptionFormViewModel._InpatientPrescription.PrescriptionPaper = prescriptionPaper;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(InpatientPresciriptionFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._InpatientPrescription != null && this._InpatientPrescription.ActionDate != event) {
                this._InpatientPrescription.ActionDate = event;
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





    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "Episode.HospitalProtocolNo");
        redirectProperty(this.PatientFullName, "Text", this.__ttObject, "Episode.Patient.FullName");
        redirectProperty(this.PrescriptionType, "Value", this.__ttObject, "PrescriptionType");
    }

    public initFormControls(): void {
        this.cmdAddDetail = new TTVisual.TTButton();
        this.cmdAddDetail.Text = i18n("M13423", "E Reçete Detay Ekleme");
        this.cmdAddDetail.Name = "cmdAddDetail";
        this.cmdAddDetail.TabIndex = 89;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 87;

        this.DiagTabPage = new TTVisual.TTTabPage();
        this.DiagTabPage.DisplayIndex = 0;
        this.DiagTabPage.TabIndex = 0;
        this.DiagTabPage.Text = i18n("M22790", "Tanılar");
        this.DiagTabPage.Name = "DiagTabPage";

        this.SPTSDiagnosises = new TTVisual.TTGrid();
        this.SPTSDiagnosises.Name = "SPTSDiagnosises";
        this.SPTSDiagnosises.TabIndex = 88;

        this.CodeDiagnosisForPresc = new TTVisual.TTTextBoxColumn();
        this.CodeDiagnosisForPresc.DataMember = "Code";
        this.CodeDiagnosisForPresc.DisplayIndex = 0;
        this.CodeDiagnosisForPresc.HeaderText = "Kodu";
        this.CodeDiagnosisForPresc.Name = "CodeDiagnosisForPresc";
        this.CodeDiagnosisForPresc.Width = 80;

        this.NameDiagnosisForPresc = new TTVisual.TTTextBoxColumn();
        this.NameDiagnosisForPresc.DataMember = "Name";
        this.NameDiagnosisForPresc.DisplayIndex = 1;
        this.NameDiagnosisForPresc.HeaderText = i18n("M10514", "Adı");
        this.NameDiagnosisForPresc.Name = "NameDiagnosisForPresc";
        this.NameDiagnosisForPresc.Width = 500;

        this.ttenumcombobox1 = new TTVisual.TTEnumComboBox();
        this.ttenumcombobox1.DataTypeName = "PatientGroupEnum";
        this.ttenumcombobox1.BackColor = "#F0F0F0";
        this.ttenumcombobox1.Enabled = false;
        this.ttenumcombobox1.Name = "ttenumcombobox1";
        this.ttenumcombobox1.TabIndex = 9;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 10;

        this.DrugTabPage = new TTVisual.TTTabPage();
        this.DrugTabPage.DisplayIndex = 0;
        this.DrugTabPage.BackColor = "#FFFFFF";
        this.DrugTabPage.TabIndex = 0;
        this.DrugTabPage.Text = i18n("M16389", "İlaçlar");
        this.DrugTabPage.Name = "DrugTabPage";

        this.InpatientDrugOrders = new TTVisual.TTGrid();
        this.InpatientDrugOrders.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InpatientDrugOrders.Name = "InpatientDrugOrders";
        this.InpatientDrugOrders.TabIndex = 0;
        this.InpatientDrugOrders.Height = 350;
        this.InpatientDrugOrders.AllowUserToAddRows = false;
        this.InpatientDrugOrders.AllowUserToDeleteRows = false;

        this.Drug = new TTVisual.TTListBoxColumn();
        this.Drug.ListDefName = "DrugList";
        this.Drug.DataMember = "Material";
        this.Drug.DisplayIndex = 0;
        this.Drug.HeaderText = i18n("M16287", "İlaç");
        this.Drug.Name = "Drug";
        this.Drug.ReadOnly = true;
        this.Drug.Width = 400;

        this.Frequency = new TTVisual.TTEnumComboBoxColumn();
        this.Frequency.DataTypeName = "FrequencyEnum";
        this.Frequency.DataMember = "Frequency";
        this.Frequency.DisplayIndex = 1;
        this.Frequency.HeaderText = i18n("M13285", "Doz Aralığı");
        this.Frequency.Name = "Frequency";
        this.Frequency.ReadOnly = true;
        this.Frequency.Width = 80;

        this.DoseAmount = new TTVisual.TTTextBoxColumn();
        this.DoseAmount.DataMember = "DoseAmount";
        this.DoseAmount.DisplayIndex = 2;
        this.DoseAmount.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmount.Name = "DoseAmount";
        this.DoseAmount.ReadOnly = true;
        this.DoseAmount.Width = 80;

        this.Day = new TTVisual.TTTextBoxColumn();
        this.Day.DataMember = "Day";
        this.Day.DisplayIndex = 3;
        this.Day.HeaderText = i18n("M14998", "Gün");
        this.Day.Name = "Day";
        this.Day.ReadOnly = true;
        this.Day.Width = 80;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 4;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 80;

        this.PackageAmount = new TTVisual.TTTextBoxColumn();
        this.PackageAmount.DataMember = "PackageAmount";
        this.PackageAmount.DisplayIndex = 5;
        this.PackageAmount.HeaderText = i18n("M20130", "Paket Adedi");
        this.PackageAmount.Name = "PackageAmount";
        this.PackageAmount.ReadOnly = true;
        this.PackageAmount.Width = 90;

        this.UsageNote = new TTVisual.TTTextBoxColumn();
        this.UsageNote.DataMember = "UsageNote";
        this.UsageNote.DisplayIndex = 6;
        this.UsageNote.HeaderText = i18n("M17992", "Kullanma Tarifi");
        this.UsageNote.Name = "UsageNote";
        this.UsageNote.ReadOnly = true;
        this.UsageNote.Width = 200;

        this.DescriptionType = new TTVisual.TTEnumComboBoxColumn();
        this.DescriptionType.DataTypeName = "DescriptionTypeEnum";
        this.DescriptionType.DataMember = "DescriptionType";
        this.DescriptionType.DisplayIndex = 7;
        this.DescriptionType.HeaderText = i18n("M10479", "Açıklama Türü");
        this.DescriptionType.Name = "DescriptionType";
        this.DescriptionType.Width = 100;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 8;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.ReadOnly = true;
        this.Description.Width = 100;

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

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = "#F0F0F0";
        this.ID.ReadOnly = true;
        this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ID.Name = "ID";
        this.ID.TabIndex = 0;


        this.EReceteNo = new TTVisual.TTTextBox();
        this.EReceteNo.BackColor = "#F0F0F0";
        this.EReceteNo.ReadOnly = true;
        this.EReceteNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.EReceteNo.Name = "EReceteNo";
        this.EReceteNo.TabIndex = 0;

        this.PatientFullName = new TTVisual.TTTextBox();
        this.PatientFullName.BackColor = "#F0F0F0";
        this.PatientFullName.ForeColor = "#FF0000";
        this.PatientFullName.ReadOnly = true;
        this.PatientFullName.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientFullName.Name = "PatientFullName";
        this.PatientFullName.TabIndex = 5;

        this.labelPatientGroup = new TTVisual.TTLabel();
        this.labelPatientGroup.Text = i18n("M15222", "Hasta Grubu");
        this.labelPatientGroup.BackColor = "#DCDCDC";
        this.labelPatientGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPatientGroup.ForeColor = "#000000";
        this.labelPatientGroup.Name = "labelPatientGroup";
        this.labelPatientGroup.TabIndex = 16;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.BackColor = "#DCDCDC";
        this.labelActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelActionDate.ForeColor = "#000000";
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 11;

        this.FromResource = new TTVisual.TTObjectListBox();
        this.FromResource.ReadOnly = true;
        this.FromResource.ListDefName = "ResourceListDefinition";
        this.FromResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FromResource.Name = "FromResource";
        this.FromResource.TabIndex = 7;

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
        this.labelID.TabIndex = 10;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 1;

        this.labelMasterResource = new TTVisual.TTLabel();
        this.labelMasterResource.Text = i18n("M14857", "Gönderen Bölüm");
        this.labelMasterResource.BackColor = "#DCDCDC";
        this.labelMasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMasterResource.ForeColor = "#000000";
        this.labelMasterResource.Name = "labelMasterResource";
        this.labelMasterResource.TabIndex = 12;

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

        this.tttoolstrip1 = new TTVisual.TTToolStrip();
        this.tttoolstrip1.ForeColor = "#000000";
        this.tttoolstrip1.Name = "tttoolstrip1";
        this.tttoolstrip1.TabIndex = 0;
        this.tttoolstrip1.Text = "tttoolstrip1";

        this.SPTSDiagnosisesColumns = [this.CodeDiagnosisForPresc, this.NameDiagnosisForPresc];
        this.InpatientDrugOrdersColumns = [this.Drug, this.Frequency, this.DoseAmount, this.Day, this.Amount, this.PackageAmount, this.UsageNote, this.DescriptionType, this.Description];
        this.tttabcontrol2.Controls = [this.DiagTabPage];
        this.DiagTabPage.Controls = [this.SPTSDiagnosises];
        this.tttabcontrol1.Controls = [this.DrugTabPage];
        this.DrugTabPage.Controls = [this.InpatientDrugOrders];
        this.Controls = [this.cmdAddDetail, this.tttabcontrol2, this.DiagTabPage, this.SPTSDiagnosises, this.CodeDiagnosisForPresc, this.NameDiagnosisForPresc, this.ttenumcombobox1, this.tttabcontrol1, this.DrugTabPage, this.InpatientDrugOrders, this.Drug, this.Frequency, this.DoseAmount, this.Day, this.Amount, this.UsageNote, this.DescriptionType, this.Description, this.QuarantineProtocolNo, this.ProtocolNo, this.ID, this.EReceteNo, this.PatientFullName, this.labelPatientGroup, this.labelActionDate, this.FromResource, this.ReasonForAdmission, this.labelID, this.ActionDate, this.labelMasterResource, this.labelProtocolNo, this.labelQuarantineProtocolNo, this.labelReasonForAdmission, this.PrescriptionType, this.labelPrescriptionType, this.ttlabel2, this.PrescriptionPaper, this.labelPrescriptionNO, this.tttoolstrip1];

    }


}
