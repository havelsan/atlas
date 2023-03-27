//$33FA306F
import { Component, OnInit  } from '@angular/core';
import { DrugDoseCompletionFormViewModel } from './DrugDoseCompletionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DrugDoseCompletion } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDoseCompletionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'DrugDoseCompletionForm',
    templateUrl: './DrugDoseCompletionForm.html',
    providers: [MessageService]
})
export class DrugDoseCompletionForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBoxColumn;
    Completed: TTVisual.ITTCheckBoxColumn;
    DrugDoseCompletionDetails: TTVisual.ITTGrid;
    ID: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelPatientIDandFullNamePatient: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    PatientIDandFullNamePatient: TTVisual.ITTTextBox;
    public DrugDoseCompletionDetailsColumns = [];
    public drugDoseCompletionFormViewModel: DrugDoseCompletionFormViewModel = new DrugDoseCompletionFormViewModel();
    public get _DrugDoseCompletion(): DrugDoseCompletion {
        return this._TTObject as DrugDoseCompletion;
    }
    private DrugDoseCompletionForm_DocumentUrl: string = '/api/DrugDoseCompletionService/DrugDoseCompletionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('DRUGDOSECOMPLETION', 'DrugDoseCompletionForm');
        this._DocumentServiceUrl = this.DrugDoseCompletionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PreScript(): Promise<void> {
        super.PreScript();
        /*let drugDoseCompletion: DrugDoseCompletion = this._DrugDoseCompletion;
        let myDrugOrderTransaction: Array<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class> = (await DrugOrderTransactionService.GetDrugOrderTransactionByEpisodeRQ(this._DrugDoseCompletion.Episode.ObjectID));
        //IList myDrugOrderTransactions = drugDoseCompletion.ObjectContext.QueryObjects("DRUGORDERTRANSACTION", "DRUGORDER.EPISODE.OBJECTID = '" + _DrugDoseCompletion.Episode.ObjectID.ToString() + "' AND INOUT = 1");

        for (let drugOrderTransaction of myDrugOrderTransaction) {
            //cmdOK.Visible = false;
            let drugDefinition: DrugDefinition = <DrugDefinition>this._DrugDoseCompletion.ObjectContext.GetObject(<Guid>drugOrderTransaction.Drugdefinition, 'DRUGDEFINITION');
            let drugType: boolean = (await DrugOrderService.GetDrugUsedType(drugDefinition));
            if (!drugType) {
                let restDose: number = 0;
                let order: DrugOrder = <DrugOrder>this._DrugDoseCompletion.ObjectContext.GetObject(<Guid>drugOrderTransaction.Drugorder, 'DRUGORDER');
                restDose = (await DrugOrderTransactionService.GetRestDose(order));
                if (restDose > 0) {
                    let drugOrder: DrugOrder = order;
                    let drugDoseCompletionDetail: DrugDoseCompletionDetail = new DrugDoseCompletionDetail(drugDoseCompletion.ObjectContext);
                    drugDoseCompletionDetail.Amount = restDose;
                    drugDoseCompletionDetail.Day = drugOrder.Day;
                    drugDoseCompletionDetail.DoseAmount = drugOrder.DoseAmount;
                    drugDoseCompletionDetail.DrugOrder = drugOrder;
                    drugDoseCompletionDetail.Episode = drugOrder.Episode;
                    drugDoseCompletionDetail.Frequency = drugOrder.Frequency;
                    drugDoseCompletionDetail.FromResource = drugOrder.FromResource;
                    drugDoseCompletionDetail.Material = drugOrder.Material;
                    drugDoseCompletionDetail.UsageNote = drugOrder.UsageNote;
                    drugDoseCompletionDetail.DrugDoseCompletion = drugDoseCompletion;
                    drugDoseCompletionDetail.CurrentStateDefID = DrugDoseCompletionDetail.DrugDoseCompletionDetailStates.Planned;
                    drugDoseCompletionDetail.Update();
                    drugDoseCompletionDetail.CurrentStateDefID = DrugDoseCompletionDetail.DrugDoseCompletionDetailStates.UseRestDose;
                }
            }
        }*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DrugDoseCompletion();
        this.drugDoseCompletionFormViewModel = new DrugDoseCompletionFormViewModel();
        this._ViewModel = this.drugDoseCompletionFormViewModel;
        this.drugDoseCompletionFormViewModel._DrugDoseCompletion = this._TTObject as DrugDoseCompletion;
        this.drugDoseCompletionFormViewModel._DrugDoseCompletion.Episode = new Episode();
        this.drugDoseCompletionFormViewModel._DrugDoseCompletion.Episode.Patient = new Patient();
        this.drugDoseCompletionFormViewModel._DrugDoseCompletion.DrugDoseCompletionDetails = new Array<DrugDoseCompletionDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.drugDoseCompletionFormViewModel = this._ViewModel as DrugDoseCompletionFormViewModel;
        that._TTObject = this.drugDoseCompletionFormViewModel._DrugDoseCompletion;
        if (this.drugDoseCompletionFormViewModel == null)
            this.drugDoseCompletionFormViewModel = new DrugDoseCompletionFormViewModel();
        if (this.drugDoseCompletionFormViewModel._DrugDoseCompletion == null)
            this.drugDoseCompletionFormViewModel._DrugDoseCompletion = new DrugDoseCompletion();
        let episodeObjectID = that.drugDoseCompletionFormViewModel._DrugDoseCompletion["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.drugDoseCompletionFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.drugDoseCompletionFormViewModel._DrugDoseCompletion.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === "string")) {
                    let patient = that.drugDoseCompletionFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        that.drugDoseCompletionFormViewModel._DrugDoseCompletion.DrugDoseCompletionDetails = that.drugDoseCompletionFormViewModel.DrugDoseCompletionDetailsGridList;
        for (let detailItem of that.drugDoseCompletionFormViewModel.DrugDoseCompletionDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.drugDoseCompletionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }

    }

    async ngOnInit() {
        await this.load();
        this.FormCaption = 'Hastanın İlaç Doz Bitirme';
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._DrugDoseCompletion != null && this._DrugDoseCompletion.ActionDate != event) {
                this._DrugDoseCompletion.ActionDate = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._DrugDoseCompletion != null && this._DrugDoseCompletion.ID != event) {
                this._DrugDoseCompletion.ID = event;
            }
        }
    }

    public onPatientIDandFullNamePatientChanged(event): void {
        if (event != null) {
            if (this._DrugDoseCompletion != null &&
                this._DrugDoseCompletion.Episode != null &&
                this._DrugDoseCompletion.Episode.Patient != null && this._DrugDoseCompletion.Episode.Patient.PatientIDandFullName != event) {
                this._DrugDoseCompletion.Episode.Patient.PatientIDandFullName = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ID, "Text", this.__ttObject, "ID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.PatientIDandFullNamePatient, "Text", this.__ttObject, "Episode.Patient.PatientIDandFullName");
    }

    public initFormControls(): void {
        this.labelPatientIDandFullNamePatient = new TTVisual.TTLabel();
        this.labelPatientIDandFullNamePatient.Text = i18n("M15134", "Hasta Adı ve Soyadı");
        this.labelPatientIDandFullNamePatient.Name = "labelPatientIDandFullNamePatient";
        this.labelPatientIDandFullNamePatient.TabIndex = 6;

        this.PatientIDandFullNamePatient = new TTVisual.TTTextBox();
        this.PatientIDandFullNamePatient.BackColor = "#F0F0F0";
        this.PatientIDandFullNamePatient.ForeColor = "#FF0000";
        this.PatientIDandFullNamePatient.ReadOnly = true;
        this.PatientIDandFullNamePatient.Name = "PatientIDandFullNamePatient";
        this.PatientIDandFullNamePatient.TabIndex = 5;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = "#F0F0F0";
        this.ID.ReadOnly = true;
        this.ID.Name = "ID";
        this.ID.TabIndex = 3;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16866", "İşlem No");
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 4;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 2;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 1;

        this.DrugDoseCompletionDetails = new TTVisual.TTGrid();
        this.DrugDoseCompletionDetails.Name = "DrugDoseCompletionDetails";
        this.DrugDoseCompletionDetails.TabIndex = 0;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "DrugList";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M16287", "İlaç");
        this.Material.Name = "Material";
        this.Material.Width = 400;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 1;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 80;

        this.Completed = new TTVisual.TTCheckBoxColumn();
        this.Completed.DataMember = "DrugDone";
        this.Completed.DisplayIndex = 2;
        this.Completed.HeaderText = i18n("M11928", "Bitir");
        this.Completed.Name = "Completed";
        this.Completed.Width = 50;

        this.DrugDoseCompletionDetailsColumns = [this.Material, this.Amount, this.Completed];
        this.Controls = [this.labelPatientIDandFullNamePatient, this.PatientIDandFullNamePatient, this.ID, this.labelID, this.labelActionDate, this.ActionDate, this.DrugDoseCompletionDetails, this.Material, this.Amount, this.Completed];

    }


}
