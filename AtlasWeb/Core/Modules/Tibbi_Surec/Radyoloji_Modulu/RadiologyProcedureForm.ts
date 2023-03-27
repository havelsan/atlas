//$87A2771D
import { Component, OnInit, NgZone } from '@angular/core';
import { RadiologyProcedureFormViewModel } from "./RadiologyProcedureFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';

import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";



@Component({
    selector: 'RadiologyProcedureForm',
    templateUrl: './RadiologyProcedureForm.html',
    providers: [MessageService]
})
export class RadiologyProcedureForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AllCheck: TTVisual.ITTCheckBox;
    Amount: TTVisual.ITTTextBoxColumn;
    Cancel: TTVisual.ITTButtonColumn;
    Check: TTVisual.ITTCheckBoxColumn;
    CurrentState: TTVisual.ITTStateComboBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridMaterial: TTVisual.ITTGrid;
    GridRadiologyTests: TTVisual.ITTGrid;
    labelPreInformation: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    Notes: TTVisual.ITTTextBoxColumn;
    PATIENTGROUPENUM: TTVisual.ITTEnumComboBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    public RTest: Array<any>;
    ReasonForAdmission: TTVisual.ITTObjectListBox;
    Report: TTVisual.ITTRichTextBoxControlColumn;
    RStore: TTVisual.ITTListBoxColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    UBBCode: TTVisual.ITTTextBoxColumn;
    public GridEpisodeDiagnosisColumns = [];
    public GridMaterialColumns = [];
    public GridRadiologyTestsColumns = [];
    public radiologyProcedureFormViewModel: RadiologyProcedureFormViewModel = new RadiologyProcedureFormViewModel();
    public get _Radiology(): Radiology {
        return this._TTObject as Radiology;
    }
    private RadiologyProcedureForm_DocumentUrl: string = '/api/RadiologyService/RadiologyProcedureForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RadiologyProcedureForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async GridMaterial_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        let enteredRow: TTVisual.ITTGridRow = this.GridMaterial.Rows[rowIndex];
        if (enteredRow !== null) {
            let currentTreatmentMaterial: BaseTreatmentMaterial = enteredRow.TTObject as BaseTreatmentMaterial;
            if (currentTreatmentMaterial !== null && currentTreatmentMaterial.Store !== null)
                this.Material.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = "; //+ ConnectionManager.GuidToString(currentTreatmentMaterial.Store.ObjectID);
        }
    }
    private async GridMaterial_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        let enteredRow: TTVisual.ITTGridRow = this.GridMaterial.Rows[rowIndex];
        if (enteredRow !== null) {
            let currentTreatmentMaterial: BaseTreatmentMaterial = enteredRow.TTObject as BaseTreatmentMaterial;
            if (currentTreatmentMaterial !== null && currentTreatmentMaterial.Store !== null)
                this.Material.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = "; //+ ConnectionManager.GuidToString(currentTreatmentMaterial.Store.ObjectID);
        }
    }
    private async GridMaterial_RowEnter(rowIndex: number, columnIndex: number): Promise<void> {
        let enteredRow: TTVisual.ITTGridRow = this.GridMaterial.Rows[rowIndex];
        if (enteredRow !== null) {
            let currentTreatmentMaterial: BaseTreatmentMaterial = enteredRow.TTObject as BaseTreatmentMaterial;
            if (currentTreatmentMaterial !== null && currentTreatmentMaterial.Store !== null)
                this.Material.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = "; //+ ConnectionManager.GuidToString(currentTreatmentMaterial.Store.ObjectID);
        }
    }
    private async GridRadiologyTests_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.GridRadiologyTests.CurrentCell !== null) {
            let test: RadiologyTest = <RadiologyTest>this.GridRadiologyTests.CurrentCell.OwningRow.TTObject;
            switch (this.GridRadiologyTests.CurrentCell.OwningColumn.Name) {
                case "Cancel":
                    // Rollback'li yapılacak
                    // Son test iptal edildiğinde bütün işlemi iptal etme veya bütün işlemi tamamlama yapılacak
                    //Cursor current = Cursor.Current;
                    //  Cursor.Current = Cursors.WaitCursor;
                    let savePoint: Guid = this._Radiology.ObjectContext.BeginSavePoint();
                    try {
                        let hasUncompletedTest: boolean = false;
                        if (test.CurrentStateDefID === RadiologyTest.RadiologyTestStates.RequestAcception) {
                            test.CurrentStateDefID = RadiologyTest.RadiologyTestStates.Cancelled;
                            for (let radTest of this._Radiology.RadiologyTests) {
                                if ((radTest.CurrentStateDefID !== RadiologyTest.RadiologyTestStates.Cancelled) && (radTest.CurrentStateDefID !== RadiologyTest.RadiologyTestStates.Completed) && (radTest.CurrentStateDefID !== RadiologyTest.RadiologyTestStates.Reject)) {
                                    hasUncompletedTest = true;
                                    break;
                                }
                            }
                            if (!hasUncompletedTest) {
                                this._Radiology.CurrentStateDefID = Radiology.RadiologyStates.Reject;
                            }
                            this._Radiology.ObjectContext.Save();
                        }
                        else {
                            TTVisual.InfoBox.Show(i18n("M16624", "İstek Kabul aşamasında olmayan test iptal edilemez!"));
                        }
                    }
                    catch (err) {
                        this._Radiology.ObjectContext.RollbackSavePoint(savePoint);
                        throw err;
                    }
                    finally {

                    }
                    break;
                default:
                    break;
            }
        }
    }
    protected async PreScript() {
        super.PreScript();
        //            this.RTest = this.GetChosenRadiologyTest(_Radiology);
        //
        //            TTGrid aa =    (TTGrid)this.ttgrid1;
        //            aa.VirtualMode = false;
        //            foreach(RadiologyTest deneme in this.RTest)
        //            {
        //
        //                //   this.ttgrid1.Rows.Add(new object[] {deneme.ProcedureObject,deneme.Description});
        //
        //                aa.Rows.Add(new object[] {deneme.ProcedureObject,deneme.Description});
        //
        //            }

        this.Material.ListFilterExpression = " 1=2 ";
        let storeObjectId: string = "";
        /*
        for (let userResource of Common.CurrentResource.UserResources) {
            if (userResource.Resource.Store !== null) {
                storeObjectId = storeObjectId + ConnectionManager.GuidToString(userResource.Resource.Store.ObjectID);
                storeObjectId = storeObjectId + ",";
            }
        }*/
        if (storeObjectId.length > 0) {
            storeObjectId = storeObjectId.substring(0, storeObjectId.length - 1);
            this.RStore.ListFilterExpression = "OBJECTID IN (" + storeObjectId + ")";
        }
    }
    public async GetChosenRadiologyTest(Rad: Radiology): Promise<Array<any>> {
        let RadiologTestx: Array<any> = this._Radiology.ObjectContext.QueryObjects("RadiologyTest", " RADIOLOGY = " ); //+ ConnectionManager.GuidToString(Rad.ObjectID));
        return RadiologTestx;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Radiology();
        this.radiologyProcedureFormViewModel = new RadiologyProcedureFormViewModel();
        this._ViewModel = this.radiologyProcedureFormViewModel;
        this.radiologyProcedureFormViewModel._Radiology = this._TTObject as Radiology;
        this.radiologyProcedureFormViewModel._Radiology.RadiologyTests = new Array<RadiologyTest>();
        this.radiologyProcedureFormViewModel._Radiology.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
        this.radiologyProcedureFormViewModel._Radiology.RequestDoctor = new ResUser();
        this.radiologyProcedureFormViewModel._Radiology.Episode = new Episode();
        this.radiologyProcedureFormViewModel._Radiology.Episode.Diagnosis = new Array<DiagnosisGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.radiologyProcedureFormViewModel = this._ViewModel as RadiologyProcedureFormViewModel;
        that._TTObject = this.radiologyProcedureFormViewModel._Radiology;
        if (this.radiologyProcedureFormViewModel == null)
            this.radiologyProcedureFormViewModel = new RadiologyProcedureFormViewModel();
        if (this.radiologyProcedureFormViewModel._Radiology == null)
            this.radiologyProcedureFormViewModel._Radiology = new Radiology();
        that.radiologyProcedureFormViewModel._Radiology.RadiologyTests = that.radiologyProcedureFormViewModel.GridRadiologyTestsGridList;
        for (let detailItem of that.radiologyProcedureFormViewModel.GridRadiologyTestsGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.radiologyProcedureFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
        that.radiologyProcedureFormViewModel._Radiology.TreatmentMaterials = that.radiologyProcedureFormViewModel.GridMaterialGridList;
        for (let detailItem of that.radiologyProcedureFormViewModel.GridMaterialGridList) {
            let storeObjectID = detailItem["Store"];
            if (storeObjectID != null && (typeof storeObjectID === 'string')) {
                let store = that.radiologyProcedureFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                 if (store) {
                    detailItem.Store = store;
                }
            }
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.radiologyProcedureFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.radiologyProcedureFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.radiologyProcedureFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        let requestDoctorObjectID = that.radiologyProcedureFormViewModel._Radiology["RequestDoctor"];
        if (requestDoctorObjectID != null && (typeof requestDoctorObjectID === 'string')) {
            let requestDoctor = that.radiologyProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestDoctorObjectID.toString());
             if (requestDoctor) {
                that.radiologyProcedureFormViewModel._Radiology.RequestDoctor = requestDoctor;
            }
        }
        let episodeObjectID = that.radiologyProcedureFormViewModel._Radiology["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.radiologyProcedureFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.radiologyProcedureFormViewModel._Radiology.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.radiologyProcedureFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.radiologyProcedureFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.radiologyProcedureFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                         if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.radiologyProcedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                         if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(RadiologyProcedureFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.ActionDate != event) {
                this._Radiology.ActionDate = event;
            }
        }
    }

    public onAllCheckChanged(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.AllCheck != event) {
                this._Radiology.AllCheck = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.RequestDoctor != event) {
                this._Radiology.RequestDoctor = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.PreDiagnosis != event) {
                this._Radiology.PreDiagnosis = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._Radiology != null && this._Radiology.Description != event) {
                this._Radiology.Description = event;
            }
        }
    }



    GridMaterial_CellValueChangedEmitted(data: any) {
        if (data && this.GridMaterial_CellValueChanged && data.Row && data.Column) {
            this.GridMaterial.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };
            this.GridMaterial_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "PreDiagnosis");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "Description");
        redirectProperty(this.AllCheck, "Value", this.__ttObject, "AllCheck");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 50;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M23295", "Tetkik");
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.GridRadiologyTests = new TTVisual.TTGrid();
        this.GridRadiologyTests.HideCancelledData = false;
        this.GridRadiologyTests.AllowUserToDeleteRows = false;
        this.GridRadiologyTests.ReadOnly = true;
        this.GridRadiologyTests.Name = "GridRadiologyTests";
        this.GridRadiologyTests.TabIndex = 0;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = "RadiologyTestListDefinition";
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 0;
        this.ProcedureObject.HeaderText = i18n("M23295", "Tetkik");
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.Width = 300;

        this.CurrentState = new TTVisual.TTStateComboBoxColumn();
        this.CurrentState.DataMember = "CURRENTSTATEDEFID";
        this.CurrentState.DisplayIndex = 1;
        this.CurrentState.HeaderText = i18n("M13372", "Durumu");
        this.CurrentState.Name = "CurrentState";
        this.CurrentState.Width = 150;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 2;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.Width = 200;

        this.Cancel = new TTVisual.TTButtonColumn();
        this.Cancel.Text = i18n("M16526", "İptal");
        this.Cancel.DisplayIndex = 3;
        this.Cancel.HeaderText = i18n("M16526", "İptal");
        this.Cancel.Name = "Cancel";
        this.Cancel.Width = 60;

        this.Report = new TTVisual.TTRichTextBoxControlColumn();
        this.Report.DataMember = "Report";
        this.Report.DisplayIndex = 4;
        this.Report.HeaderText = "Rapor";
        this.Report.Name = "Report";
        this.Report.Visible = false;
        this.Report.Width = 100;

        this.Check = new TTVisual.TTCheckBoxColumn();
        this.Check.DataMember = "Check";
        this.Check.DisplayIndex = 5;
        this.Check.HeaderText = i18n("M21507", "Seç");
        this.Check.Name = "Check";
        this.Check.Width = 30;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 0;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 0;
        this.tttabpage2.Text = i18n("M21309", "Sarf");
        this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage2.Name = "tttabpage2";

        this.GridMaterial = new TTVisual.TTGrid();
        this.GridMaterial.Name = "GridMaterial";
        this.GridMaterial.TabIndex = 0;

        this.RStore = new TTVisual.TTListBoxColumn();
        this.RStore.ListDefName = "StoreListDefinition";
        this.RStore.DataMember = "Store";
        this.RStore.DisplayIndex = 0;
        this.RStore.HeaderText = i18n("M12615", "Depo");
        this.RStore.Name = "RStore";
        this.RStore.Width = 210;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M21314", "Sarf Edilen Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 400;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 2;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 100;

        this.UBBCode = new TTVisual.TTTextBoxColumn();
        this.UBBCode.DataMember = "UBBCode";
        this.UBBCode.DisplayIndex = 3;
        this.UBBCode.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCode.Name = "UBBCode";
        this.UBBCode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 4;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.Notes = new TTVisual.TTTextBoxColumn();
        this.Notes.DataMember = "Note";
        this.Notes.DisplayIndex = 5;
        this.Notes.HeaderText = i18n("M10469", "Açıklama");
        this.Notes.Name = "Notes";
        this.Notes.Width = 100;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 5;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Multiline = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 6;

        this.AllCheck = new TTVisual.TTCheckBox();
        this.AllCheck.Value = false;
        this.AllCheck.Text = i18n("M23660", "Tümünü Seç");
        this.AllCheck.Name = "AllCheck";
        this.AllCheck.TabIndex = 57;
        this.AllCheck.Visible = false;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ReadOnly = true;
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 3;

        this.labelPreInformation = new TTVisual.TTLabel();
        this.labelPreInformation.Text = i18n("M17529", "Kısa Anamnez ve Klinik Bulgular");
        this.labelPreInformation.BackColor = "#DCDCDC";
        this.labelPreInformation.ForeColor = "#000000";
        this.labelPreInformation.Name = "labelPreInformation";
        this.labelPreInformation.TabIndex = 23;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.CustomFormat = "";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = i18n("M16902", "İşlem Zamanı");
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 22;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16667", "İstek Yapan Tabip");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 28;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10483", "Açıklamalar");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 27;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M17026", "Kabul Sebebi");
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 4;

        this.PATIENTGROUPENUM = new TTVisual.TTEnumComboBox();
        this.PATIENTGROUPENUM.DataTypeName = "PatientGroupEnum";
        this.PATIENTGROUPENUM.BackColor = "#F0F0F0";
        this.PATIENTGROUPENUM.Enabled = false;
        this.PATIENTGROUPENUM.Name = "PATIENTGROUPENUM";
        this.PATIENTGROUPENUM.TabIndex = 1;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M15222", "Hasta Grubu");
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 2;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.ReadOnly = true;
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

        this.ReasonForAdmission = new TTVisual.TTObjectListBox();
        this.ReasonForAdmission.ReadOnly = true;
        this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        this.ReasonForAdmission.Name = "ReasonForAdmission";
        this.ReasonForAdmission.TabIndex = 2;

        this.GridRadiologyTestsColumns = [this.ProcedureObject, this.CurrentState, this.Description, this.Cancel, this.Report, this.Check];
        this.GridMaterialColumns = [this.RStore, this.Material, this.Amount, this.UBBCode, this.DistributionType, this.Notes];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2];
        this.tttabpage1.Controls = [this.GridRadiologyTests];
        this.tttabpage2.Controls = [this.GridMaterial];
        this.Controls = [this.tttabcontrol1, this.tttabpage1, this.GridRadiologyTests, this.ProcedureObject, this.CurrentState, this.Description, this.Cancel, this.Report, this.Check, this.tttabpage2, this.GridMaterial, this.RStore, this.Material, this.Amount, this.UBBCode, this.DistributionType, this.Notes, this.tttextbox1, this.tttextbox2, this.AllCheck, this.ttobjectlistbox1, this.labelPreInformation, this.ActionDate, this.labelProcessTime, this.ttlabel2, this.ttlabel1, this.ttlabel8, this.PATIENTGROUPENUM, this.ttlabel9, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ReasonForAdmission];

    }


}
