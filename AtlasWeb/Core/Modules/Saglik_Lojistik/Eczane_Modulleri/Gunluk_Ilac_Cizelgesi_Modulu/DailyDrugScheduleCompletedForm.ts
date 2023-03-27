//$F929C56E
import { Component, OnInit, NgZone } from '@angular/core';
import { DailyDrugScheduleCompletedFormViewModel } from './DailyDrugScheduleCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseDailyDrugScheduleForm } from "Modules/Saglik_Lojistik/Eczane_Modulleri/Gunluk_Ilac_Cizelgesi_Modulu/BaseDailyDrugScheduleForm";
import { DailyDrugSchedule } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugPatient } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugSchOrder } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugUnDrug } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'DailyDrugScheduleCompletedForm',
    templateUrl: './DailyDrugScheduleCompletedForm.html',
    providers: [MessageService]
})
export class DailyDrugScheduleCompletedForm extends BaseDailyDrugScheduleForm implements OnInit {
    public DailyDrugPatientsGridColumns = [];
    public DailyDrugSchOrdersGridColumns = [];
    public DailyDrugUnDrugsGridColumns = [];
    public dailyDrugScheduleCompletedFormViewModel: DailyDrugScheduleCompletedFormViewModel = new DailyDrugScheduleCompletedFormViewModel();
    public get _DailyDrugSchedule(): DailyDrugSchedule {
        return this._TTObject as DailyDrugSchedule;
    }
    private DailyDrugScheduleCompletedForm_DocumentUrl: string = '/api/DailyDrugScheduleService/DailyDrugScheduleCompletedForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.DailyDrugScheduleCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    DailyDrugOrderGetByDate_Click(){}
    DailyDrugPatientsGrid_CellContentClickEmitted(data: any){}

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DailyDrugSchedule();
        this.dailyDrugScheduleCompletedFormViewModel = new DailyDrugScheduleCompletedFormViewModel();
        this._ViewModel = this.dailyDrugScheduleCompletedFormViewModel;
        this.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule = this._TTObject as DailyDrugSchedule;
        this.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule.DailyDrugPatients = new Array<DailyDrugPatient>();
        this.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule.DailyDrugSchOrders = new Array<DailyDrugSchOrder>();
        this.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule.DailyDrugUnDrugs = new Array<DailyDrugUnDrug>();
        this.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule.Store = new Store();
        this.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule.DestinationStore = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.dailyDrugScheduleCompletedFormViewModel = this._ViewModel as DailyDrugScheduleCompletedFormViewModel;
        that._TTObject = this.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule;
        if (this.dailyDrugScheduleCompletedFormViewModel == null)
            this.dailyDrugScheduleCompletedFormViewModel = new DailyDrugScheduleCompletedFormViewModel();
        if (this.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule == null)
            this.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule = new DailyDrugSchedule();
        that.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule.DailyDrugPatients = that.dailyDrugScheduleCompletedFormViewModel.DailyDrugPatientsGridGridList;
        for (let detailItem of that.dailyDrugScheduleCompletedFormViewModel.DailyDrugPatientsGridGridList) {
            let episodeObjectID = detailItem["Episode"];
            if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
                let episode = that.dailyDrugScheduleCompletedFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                 if (episode) {
                    detailItem.Episode = episode;
                }
                if (episode != null) {
                    let patientObjectID = episode["Patient"];
                    if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                        let patient = that.dailyDrugScheduleCompletedFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                         if (patient) {
                            episode.Patient = patient;
                        }
                    }
                }
            }
        }
        that.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule.DailyDrugSchOrders = that.dailyDrugScheduleCompletedFormViewModel.DailyDrugSchOrdersGridGridList;
        for (let detailItem of that.dailyDrugScheduleCompletedFormViewModel.DailyDrugSchOrdersGridGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.dailyDrugScheduleCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let dailyDrugPatientObjectID = detailItem["DailyDrugPatient"];
            if (dailyDrugPatientObjectID != null && (typeof dailyDrugPatientObjectID === 'string')) {
                let dailyDrugPatient = that.dailyDrugScheduleCompletedFormViewModel.DailyDrugPatients.find(o => o.ObjectID.toString() === dailyDrugPatientObjectID.toString());
                 if (dailyDrugPatient) {
                    detailItem.DailyDrugPatient = dailyDrugPatient;
                }
                if (dailyDrugPatient != null) {
                    let episodeObjectID = dailyDrugPatient["Episode"];
                    if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
                        let episode = that.dailyDrugScheduleCompletedFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                         if (episode) {
                            dailyDrugPatient.Episode = episode;
                        }
                        if (episode != null) {
                            let patientObjectID = episode["Patient"];
                            if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                                let patient = that.dailyDrugScheduleCompletedFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                                 if (patient) {
                                    episode.Patient = patient;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule.DailyDrugUnDrugs = that.dailyDrugScheduleCompletedFormViewModel.DailyDrugUnDrugsGridGridList;
        for (let detailItem of that.dailyDrugScheduleCompletedFormViewModel.DailyDrugUnDrugsGridGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.dailyDrugScheduleCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let dailyDrugPatientObjectID = detailItem["DailyDrugPatient"];
            if (dailyDrugPatientObjectID != null && (typeof dailyDrugPatientObjectID === 'string')) {
                let dailyDrugPatient = that.dailyDrugScheduleCompletedFormViewModel.DailyDrugPatients.find(o => o.ObjectID.toString() === dailyDrugPatientObjectID.toString());
                 if (dailyDrugPatient) {
                    detailItem.DailyDrugPatient = dailyDrugPatient;
                }
                if (dailyDrugPatient != null) {
                    let episodeObjectID = dailyDrugPatient["Episode"];
                    if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
                        let episode = that.dailyDrugScheduleCompletedFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                         if (episode) {
                            dailyDrugPatient.Episode = episode;
                        }
                        if (episode != null) {
                            let patientObjectID = episode["Patient"];
                            if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                                let patient = that.dailyDrugScheduleCompletedFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                                 if (patient) {
                                    episode.Patient = patient;
                                }
                            }
                        }
                    }
                }
            }
        }
        let storeObjectID = that.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.dailyDrugScheduleCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule.Store = store;
            }
        }
        let destinationStoreObjectID = that.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.dailyDrugScheduleCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
             if (destinationStore) {
                that.dailyDrugScheduleCompletedFormViewModel._DailyDrugSchedule.DestinationStore = destinationStore;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(DailyDrugScheduleCompletedFormViewModel);
        this.FormCaption = i18n("M15036", "Günlük İlaç Çizelgesi İstek ( Yeni )");
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.ActionDate != event) {
                this._DailyDrugSchedule.ActionDate = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.DestinationStore != event) {
                this._DailyDrugSchedule.DestinationStore = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.StockActionID != event) {
                this._DailyDrugSchedule.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.Store != event) {
                this._DailyDrugSchedule.Store = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.StartDate != event) {
                this._DailyDrugSchedule.StartDate = event;
            }
        }
    }

    public onttdatetimepicker2Changed(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.EndDate != event) {
                this._DailyDrugSchedule.EndDate = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.ttdatetimepicker2, "Value", this.__ttObject, "EndDate");
    }

    public initFormControls(): void {
        this.tttabcontrol3 = new TTVisual.TTTabControl();
        this.tttabcontrol3.Name = "tttabcontrol3";
        this.tttabcontrol3.TabIndex = 15;

        this.PatientTab = new TTVisual.TTTabPage();
        this.PatientTab.DisplayIndex = 0;
        this.PatientTab.TabIndex = 0;
        this.PatientTab.Text = i18n("M15369", "Hastalar");
        this.PatientTab.Name = "PatientTab";

        this.DailyDrugPatientsGrid = new TTVisual.TTGrid();
        this.DailyDrugPatientsGrid.AllowUserToDeleteRows = false;
        this.DailyDrugPatientsGrid.Name = "DailyDrugPatientsGrid";
        this.DailyDrugPatientsGrid.TabIndex = 16;
        this.DailyDrugPatientsGrid.Height = 350;
        this.DailyDrugPatientsGrid.AllowUserToAddRows = false;

        this.selecetedPatient = new TTVisual.TTCheckBoxColumn();
        this.selecetedPatient.DataMember = "IsCheck";
        this.selecetedPatient.DisplayIndex = 0;
        this.selecetedPatient.HeaderText = i18n("M21507", "Seç");
        this.selecetedPatient.Name = "selecetedPatient";
        this.selecetedPatient.Width = 100;

        this.patinetFullName = new TTVisual.TTTextBoxColumn();
        this.patinetFullName.DataMember = "FullName";
        this.patinetFullName.DisplayIndex = 1;
        this.patinetFullName.HeaderText = i18n("M10517", "Adı Soyadı");
        this.patinetFullName.Name = "patinetFullName";
        this.patinetFullName.ReadOnly = true;
        this.patinetFullName.Width = 300;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 14;

        this.DrugListTab = new TTVisual.TTTabPage();
        this.DrugListTab.DisplayIndex = 0;
        this.DrugListTab.TabIndex = 0;
        this.DrugListTab.Text = i18n("M16389", "İlaçlar");
        this.DrugListTab.Name = "DrugListTab";

        this.DailyDrugSchOrdersGrid = new TTVisual.TTGrid();
        this.DailyDrugSchOrdersGrid.AllowUserToDeleteRows = false;
        this.DailyDrugSchOrdersGrid.Name = "DailyDrugSchOrdersGrid";
        this.DailyDrugSchOrdersGrid.TabIndex = 16;
        this.DailyDrugSchOrdersGrid.Height = 350;
        this.DailyDrugSchOrdersGrid.AllowUserToAddRows = false;

        this.drugOrderName = new TTVisual.TTTextBoxColumn();
        this.drugOrderName.DataMember = "Name";
        this.drugOrderName.DisplayIndex = 0;
        this.drugOrderName.HeaderText = i18n("M16294", "İlaç Adı");
        this.drugOrderName.Name = "drugOrderName";
        this.drugOrderName.ReadOnly = true;
        this.drugOrderName.Width = 325;

        this.DoseAmountDailyDrugSchOrder = new TTVisual.TTTextBoxColumn();
        this.DoseAmountDailyDrugSchOrder.DataMember = "DoseAmount";
        this.DoseAmountDailyDrugSchOrder.DisplayIndex = 1;
        this.DoseAmountDailyDrugSchOrder.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmountDailyDrugSchOrder.Name = "DoseAmountDailyDrugSchOrder";
        this.DoseAmountDailyDrugSchOrder.ReadOnly = true;
        this.DoseAmountDailyDrugSchOrder.Width = 100;

        this.patientFullName = new TTVisual.TTTextBoxColumn();
        this.patientFullName.DataMember = "FullName";
        this.patientFullName.DisplayIndex = 2;
        this.patientFullName.HeaderText = i18n("M15133", "Hasta Adı Soyadı");
        this.patientFullName.Name = "patientFullName";
        this.patientFullName.ReadOnly = true;
        this.patientFullName.Width = 325;

        this.UnDrugListTab = new TTVisual.TTTabPage();
        this.UnDrugListTab.DisplayIndex = 1;
        this.UnDrugListTab.TabIndex = 1;
        this.UnDrugListTab.Text = "Çıkmayan İlaçlar";
        this.UnDrugListTab.Name = "UnDrugListTab";

        this.DailyDrugUnDrugsGrid = new TTVisual.TTGrid();
        this.DailyDrugUnDrugsGrid.AllowUserToDeleteRows = false;
        this.DailyDrugUnDrugsGrid.Name = "DailyDrugUnDrugsGrid";
        this.DailyDrugUnDrugsGrid.TabIndex = 16;
        this.DailyDrugUnDrugsGrid.Height = 350;
        this.DailyDrugUnDrugsGrid.AllowUserToAddRows = false;

        this.UnDrugName = new TTVisual.TTTextBoxColumn();
        this.UnDrugName.DataMember = "Name";
        this.UnDrugName.DisplayIndex = 0;
        this.UnDrugName.HeaderText = i18n("M16294", "İlaç Adı");
        this.UnDrugName.Name = "UnDrugName";
        this.UnDrugName.ReadOnly = true;
        this.UnDrugName.Width = 325;

        this.DoseAmountDailyDrugUnDrug = new TTVisual.TTTextBoxColumn();
        this.DoseAmountDailyDrugUnDrug.DataMember = "DoseAmount";
        this.DoseAmountDailyDrugUnDrug.DisplayIndex = 1;
        this.DoseAmountDailyDrugUnDrug.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmountDailyDrugUnDrug.Name = "DoseAmountDailyDrugUnDrug";
        this.DoseAmountDailyDrugUnDrug.ReadOnly = true;
        this.DoseAmountDailyDrugUnDrug.Width = 80;

        this.patientNameSurname = new TTVisual.TTTextBoxColumn();
        this.patientNameSurname.DataMember = "FullName";
        this.patientNameSurname.DisplayIndex = 2;
        this.patientNameSurname.HeaderText = i18n("M15133", "Hasta Adı Soyadı");
        this.patientNameSurname.Name = "patientNameSurname";
        this.patientNameSurname.ReadOnly = true;
        this.patientNameSurname.Width = 250;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 4;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M13454", "Eczane Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 11;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "PharmacyStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 10;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M17628", "Klinik Depo");
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 9;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = "RoomAndSubStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 8;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 7;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 6;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 5;

        this.labelStartDate = new TTVisual.TTLabel();
        this.labelStartDate.Text = i18n("M11637", "Başlangıç Tarihi");
        this.labelStartDate.Name = "labelStartDate";
        this.labelStartDate.TabIndex = 3;

        this.labelEndDate = new TTVisual.TTLabel();
        this.labelEndDate.Text = i18n("M11939", "Bitiş Tarihi");
        this.labelEndDate.Name = "labelEndDate";
        this.labelEndDate.TabIndex = 1;

        this.DailyDrugOrderGetByDate = new TTVisual.TTButton();
        this.DailyDrugOrderGetByDate.Text = i18n("M14767", "Getir");
        this.DailyDrugOrderGetByDate.Name = "DailyDrugOrderGetByDate";
        this.DailyDrugOrderGetByDate.TabIndex = 12;

        this.ttdatetimepicker2 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker2.Required = true;
        this.ttdatetimepicker2.BackColor = "#FFE3C6";
        this.ttdatetimepicker2.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepicker2.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepicker2.Name = "ttdatetimepicker2";
        this.ttdatetimepicker2.TabIndex = 5;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.Required = true;
        this.ttdatetimepicker1.BackColor = "#FFE3C6";
        this.ttdatetimepicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 4;

        this.DailyDrugPatientsGridColumns = [this.selecetedPatient, this.patinetFullName];
        this.DailyDrugSchOrdersGridColumns = [this.drugOrderName, this.DoseAmountDailyDrugSchOrder, this.patientFullName];
        this.DailyDrugUnDrugsGridColumns = [this.UnDrugName, this.DoseAmountDailyDrugUnDrug, this.patientNameSurname];
        this.tttabcontrol3.Controls = [this.PatientTab];
        this.PatientTab.Controls = [this.DailyDrugPatientsGrid];
        this.tttabcontrol2.Controls = [this.DrugListTab, this.UnDrugListTab];
        this.DrugListTab.Controls = [this.DailyDrugSchOrdersGrid];
        this.UnDrugListTab.Controls = [this.DailyDrugUnDrugsGrid];
        this.Controls = [this.tttabcontrol3, this.PatientTab, this.DailyDrugPatientsGrid, this.selecetedPatient, this.patinetFullName, this.tttabcontrol2, this.DrugListTab, this.DailyDrugSchOrdersGrid, this.drugOrderName, this.DoseAmountDailyDrugSchOrder, this.patientFullName, this.UnDrugListTab, this.DailyDrugUnDrugsGrid, this.UnDrugName, this.DoseAmountDailyDrugUnDrug, this.patientNameSurname, this.StockActionID, this.labelStore, this.Store, this.labelDestinationStore, this.DestinationStore, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.labelStartDate, this.labelEndDate, this.DailyDrugOrderGetByDate, this.ttdatetimepicker2, this.ttdatetimepicker1];

        for (let control of this.Controls) {
                control.ReadOnly = true;
                control.Enabled = false;
        }
    }


}
