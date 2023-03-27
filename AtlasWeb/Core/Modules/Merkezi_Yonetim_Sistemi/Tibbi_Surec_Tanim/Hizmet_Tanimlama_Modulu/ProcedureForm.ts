//$BAE7E575
import { Component, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ProcedureFormViewModel } from './ProcedureFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { GILDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { PackageProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PricingDetailDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PricingListDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedurePriceDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProvizyonTipi } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { RevenueSubAccountCodeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SubProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TakipTipi } from 'NebulaClient/Model/AtlasClientModel';
import { TedaviTipi } from 'NebulaClient/Model/AtlasClientModel';

import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RequiredDiagnoseProcedure } from 'NebulaClient/Model/AtlasClientModel';

@Component({
    selector: 'ProcedureForm',
    templateUrl: './ProcedureForm.html',
    providers: [MessageService]
})
export class ProcedureForm extends TTVisual.TTForm implements OnInit {
    Chargable: TTVisual.ITTCheckBox;
    Code: TTVisual.ITTTextBox;
    ControlDayCount: TTVisual.ITTTextBox;
    CreateInMedulaDontSendState: TTVisual.ITTCheckBox;
    DailyDayCount: TTVisual.ITTTextBox;
    DailyMedulaProvisionNecessity: TTVisual.ITTCheckBox;
    RightLeftInfoNeeded: TTVisual.ITTCheckBox;
    Description: TTVisual.ITTTextBox;
    DiagnosisDefinitionRequiredDiagnoseProcedure: TTVisual.ITTListBoxColumn;
    DoctorLabel: TTVisual.ITTLabel;
    DoctorListBox: TTVisual.ITTObjectListBox;
    DontBlockInvoice: TTVisual.ITTCheckBox;
    EmergencyDayCount: TTVisual.ITTTextBox;
    ExaminationDayCount: TTVisual.ITTTextBox;
    ExternalOperation: TTVisual.ITTCheckBox;
    ForbiddenForControl: TTVisual.ITTCheckBox;
    ForbiddenForDaily: TTVisual.ITTCheckBox;
    ForbiddenForEmergency: TTVisual.ITTCheckBox;
    ForbiddenForExamination: TTVisual.ITTCheckBox;
    ForbiddenForInpatient: TTVisual.ITTCheckBox;
    GILDefinition: TTVisual.ITTObjectListBox;
    IsResultNeeded: TTVisual.ITTCheckBox;
    IsVisible: TTVisual.ITTCheckBox;
    grdPrices: TTVisual.ITTGrid;
    GridRequiredDiagnosis: TTVisual.ITTGrid;
    GridSubProcedures: TTVisual.ITTGrid;
    HUVCode: TTVisual.ITTTextBox;
    HUVPoint: TTVisual.ITTTextBox;
    ID: TTVisual.ITTTextBox;
    InpatientDayCount: TTVisual.ITTTextBox;
    IsActive: TTVisual.ITTCheckBox;
    IsDescriptionNeeded: TTVisual.ITTCheckBox;
    labelCode: TTVisual.ITTLabel;
    labelControlDayCount: TTVisual.ITTLabel;
    labelDailyDayCount: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEmergencyDayCount: TTVisual.ITTLabel;
    labelExaminationDayCount: TTVisual.ITTLabel;
    labelGILDefinition: TTVisual.ITTLabel;
    labelHUVCode: TTVisual.ITTLabel;
    labelHUVPoint: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelInpatientDayCount: TTVisual.ITTLabel;
    labelMedulaReportNecessity: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelProcedureType: TTVisual.ITTLabel;
    labelQref: TTVisual.ITTLabel;
    RepetitionQueryNeeded: TTVisual.ITTCheckBox;
    labelSUTPoint: TTVisual.ITTLabel;
    lblGILCode: TTVisual.ITTLabel;
    lblGILPoint: TTVisual.ITTLabel;
    lblSUTAppendix: TTVisual.ITTLabel;
    lblSUTCode: TTVisual.ITTLabel;
    MedulaProcedureType: TTVisual.ITTEnumComboBox;
    MedulaProvisionProperties: TTVisual.ITTGroupBox;
    MedulaReportNecessity: TTVisual.ITTEnumComboBox;
    Name: TTVisual.ITTTextBox;
    OzelDurum: TTVisual.ITTObjectListBox;
    PackageProcedure: TTVisual.ITTObjectListBox;
    ParticipationProcedure: TTVisual.ITTCheckBox;
    PathologyOperationNeeded: TTVisual.ITTCheckBox;
    PreProcedureEntryNecessity: TTVisual.ITTCheckBox;
    Price: TTVisual.ITTTextBoxColumn;
    PriceEndDate: TTVisual.ITTDateTimePickerColumn;
    PriceList: TTVisual.ITTListDefComboBoxColumn;
    PriceStartDate: TTVisual.ITTDateTimePickerColumn;
    PricingDetail: TTVisual.ITTListBoxColumn;
    ProcedureType: TTVisual.ITTEnumComboBox;
    ProcType: TTVisual.ITTTextBox;
    ProvizyonTipi: TTVisual.ITTObjectListBox;
    Qref: TTVisual.ITTTextBox;
    QualifiedMedicalProcess: TTVisual.ITTCheckBox;
    QuickEntryAllowed: TTVisual.ITTCheckBox;
    ReportSelectionRequired: TTVisual.ITTCheckBox;
    REVENUESUBACCOUNTCODE: TTVisual.ITTObjectListBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    SUTPoint: TTVisual.ITTTextBox;
    tabProcedure: TTVisual.ITTTabControl;
    TakipTipi: TTVisual.ITTObjectListBox;
    TedaviTipi: TTVisual.ITTObjectListBox;
    tpPrices: TTVisual.ITTTabPage;
    tpProcedure: TTVisual.ITTTabPage;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttcheckbox2: TTVisual.ITTCheckBox;
    ttcheckbox3: TTVisual.ITTCheckBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel21: TTVisual.ITTLabel;
    ttlabel22: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTTabPage;
    ttlistboxcolumn1: TTVisual.ITTListBoxColumn;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    ttobjectlistbox2: TTVisual.ITTObjectListBox;
    tttextboxcolumn1: TTVisual.ITTTextBoxColumn;
    txtGILCode: TTVisual.ITTTextBox;
    txtGILPoint: TTVisual.ITTTextBox;
    txtSUTCode: TTVisual.ITTTextBox;
    public grdPricesColumns = [];
    public GridRequiredDiagnosisColumns = [];
    public GridSubProceduresColumns = [];
    public procedureFormViewModel: ProcedureFormViewModel = new ProcedureFormViewModel();
    public get _ProcedureDefinition(): ProcedureDefinition {
        return this._TTObject as ProcedureDefinition;
    }
    private ProcedureForm_DocumentUrl: string = '/api/ProcedureDefinitionService/ProcedureForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("PROCEDUREDEFINITION", "ProcedureForm");
        this._DocumentServiceUrl = this.ProcedureForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {

    }
    protected async PreScript(): Promise<void> {
        super.PreScript();

        if (this._ProcedureDefinition.ObjectDef != null)
            this.ProcType.Text = this._ProcedureDefinition.ObjectDef.toString();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ProcedureDefinition();
        this.procedureFormViewModel = new ProcedureFormViewModel();
        this._ViewModel = this.procedureFormViewModel;
        this.procedureFormViewModel._ProcedureDefinition = this._TTObject as ProcedureDefinition;
        this.procedureFormViewModel._ProcedureDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>();
        this.procedureFormViewModel._ProcedureDefinition.GILDefinition = new GILDefinition();
        this.procedureFormViewModel._ProcedureDefinition.PackageProcedure = new PackageProcedureDefinition();
        this.procedureFormViewModel._ProcedureDefinition.RevenueSubAccountCode = new RevenueSubAccountCodeDefinition();
        this.procedureFormViewModel._ProcedureDefinition.ProcedureTree = new ProcedureTreeDefinition();
        this.procedureFormViewModel._ProcedureDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();
        this.procedureFormViewModel._ProcedureDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>();
        this.procedureFormViewModel._ProcedureDefinition.MedulaProvisionTedaviTipi = new TedaviTipi();
        this.procedureFormViewModel._ProcedureDefinition.Doctor = new ResUser();
        this.procedureFormViewModel._ProcedureDefinition.TedaviTipi = new TedaviTipi();
        this.procedureFormViewModel._ProcedureDefinition.TakipTipi = new TakipTipi();
        this.procedureFormViewModel._ProcedureDefinition.ProvizyonTipi = new ProvizyonTipi();
        this.procedureFormViewModel._ProcedureDefinition.OzelDurum = new OzelDurum();
        this.procedureFormViewModel._ProcedureDefinition.ProcedurePrice = new Array<ProcedurePriceDefinition>();
  
    }


    protected loadViewModel() {
        let that = this;
        that.procedureFormViewModel = this._ViewModel as ProcedureFormViewModel;
        that._TTObject = this.procedureFormViewModel._ProcedureDefinition;
        if (this.procedureFormViewModel == null)
            this.procedureFormViewModel = new ProcedureFormViewModel();
        if (this.procedureFormViewModel._ProcedureDefinition == null)
            this.procedureFormViewModel._ProcedureDefinition = new ProcedureDefinition();





        let gILDefinitionObjectID = that.procedureFormViewModel._ProcedureDefinition["GILDefinition"];
        if (gILDefinitionObjectID != null && (typeof gILDefinitionObjectID === "string")) {
            let gILDefinition = that.procedureFormViewModel.GILDefinitions.find(o => o.ObjectID.toString() === gILDefinitionObjectID.toString());
            if (gILDefinition) {
                that.procedureFormViewModel._ProcedureDefinition.GILDefinition = gILDefinition;
            }
        }


        let packageProcedureObjectID = that.procedureFormViewModel._ProcedureDefinition["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.procedureFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.procedureFormViewModel._ProcedureDefinition.PackageProcedure = packageProcedure;
            }
        }


        let revenueSubAccountCodeObjectID = that.procedureFormViewModel._ProcedureDefinition["RevenueSubAccountCode"];
        if (revenueSubAccountCodeObjectID != null && (typeof revenueSubAccountCodeObjectID === "string")) {
            let revenueSubAccountCode = that.procedureFormViewModel.RevenueSubAccountCodeDefinitions.find(o => o.ObjectID.toString() === revenueSubAccountCodeObjectID.toString());
            if (revenueSubAccountCode) {
                that.procedureFormViewModel._ProcedureDefinition.RevenueSubAccountCode = revenueSubAccountCode;
            }
        }


        let procedureTreeObjectID = that.procedureFormViewModel._ProcedureDefinition["ProcedureTree"];
        if (procedureTreeObjectID != null && (typeof procedureTreeObjectID === "string")) {
            let procedureTree = that.procedureFormViewModel.ProcedureTreeDefinitions.find(o => o.ObjectID.toString() === procedureTreeObjectID.toString());
            if (procedureTree) {
                that.procedureFormViewModel._ProcedureDefinition.ProcedureTree = procedureTree;
            }
        }


        that.procedureFormViewModel._ProcedureDefinition.SubProcedureDefinitions = that.procedureFormViewModel.GridSubProceduresGridList;
        for (let detailItem of that.procedureFormViewModel.GridSubProceduresGridList) {
            let childProcedureDefinitionObjectID = detailItem["ChildProcedureDefinition"];
            if (childProcedureDefinitionObjectID != null && (typeof childProcedureDefinitionObjectID === "string")) {
                let childProcedureDefinition = that.procedureFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === childProcedureDefinitionObjectID.toString());
                if (childProcedureDefinition) {
                    detailItem.ChildProcedureDefinition = childProcedureDefinition;
                }
            }

        }

        that.procedureFormViewModel._ProcedureDefinition.RequiredDiagnoseProcedures = that.procedureFormViewModel.GridRequiredDiagnosisGridList;
        for (let detailItem of that.procedureFormViewModel.GridRequiredDiagnosisGridList) {
            let diagnosisDefinitionObjectID = detailItem["DiagnosisDefinition"];
            if (diagnosisDefinitionObjectID != null && (typeof diagnosisDefinitionObjectID === "string")) {
                let diagnosisDefinition = that.procedureFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnosisDefinitionObjectID.toString());
                if (diagnosisDefinition) {
                    detailItem.DiagnosisDefinition = diagnosisDefinition;
                }
            }
        }


        let medulaProvisionTedaviTipiObjectID = that.procedureFormViewModel._ProcedureDefinition["MedulaProvisionTedaviTipi"];
        if (medulaProvisionTedaviTipiObjectID != null && (typeof medulaProvisionTedaviTipiObjectID === "string")) {
            let medulaProvisionTedaviTipi = that.procedureFormViewModel.TedaviTipis.find(o => o.ObjectID.toString() === medulaProvisionTedaviTipiObjectID.toString());
            if (medulaProvisionTedaviTipi) {
                that.procedureFormViewModel._ProcedureDefinition.MedulaProvisionTedaviTipi = medulaProvisionTedaviTipi;
            }
        }


        let doctorObjectID = that.procedureFormViewModel._ProcedureDefinition["Doctor"];
        if (doctorObjectID != null && (typeof doctorObjectID === "string")) {
            let doctor = that.procedureFormViewModel.ResUsers.find(o => o.ObjectID.toString() === doctorObjectID.toString());
            if (doctor) {
                that.procedureFormViewModel._ProcedureDefinition.Doctor = doctor;
            }
        }


        let tedaviTipiObjectID = that.procedureFormViewModel._ProcedureDefinition["TedaviTipi"];
        if (tedaviTipiObjectID != null && (typeof tedaviTipiObjectID === "string")) {
            let tedaviTipi = that.procedureFormViewModel.TedaviTipis.find(o => o.ObjectID.toString() === tedaviTipiObjectID.toString());
            if (tedaviTipi) {
                that.procedureFormViewModel._ProcedureDefinition.TedaviTipi = tedaviTipi;
            }
        }


        let takipTipiObjectID = that.procedureFormViewModel._ProcedureDefinition["TakipTipi"];
        if (takipTipiObjectID != null && (typeof takipTipiObjectID === "string")) {
            let takipTipi = that.procedureFormViewModel.TakipTipis.find(o => o.ObjectID.toString() === takipTipiObjectID.toString());
            if (takipTipi) {
                that.procedureFormViewModel._ProcedureDefinition.TakipTipi = takipTipi;
            }
        }


        let provizyonTipiObjectID = that.procedureFormViewModel._ProcedureDefinition["ProvizyonTipi"];
        if (provizyonTipiObjectID != null && (typeof provizyonTipiObjectID === "string")) {
            let provizyonTipi = that.procedureFormViewModel.ProvizyonTipis.find(o => o.ObjectID.toString() === provizyonTipiObjectID.toString());
            if (provizyonTipi) {
                that.procedureFormViewModel._ProcedureDefinition.ProvizyonTipi = provizyonTipi;
            }
        }


        let ozelDurumObjectID = that.procedureFormViewModel._ProcedureDefinition["OzelDurum"];
        if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
            let ozelDurum = that.procedureFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
            if (ozelDurum) {
                that.procedureFormViewModel._ProcedureDefinition.OzelDurum = ozelDurum;
            }
        }


        that.procedureFormViewModel._ProcedureDefinition.ProcedurePrice = that.procedureFormViewModel.grdPricesGridList;
        for (let detailItem of that.procedureFormViewModel.grdPricesGridList) {
            let pricingDetailObjectID = detailItem["PricingDetail"];
            if (pricingDetailObjectID != null && (typeof pricingDetailObjectID === "string")) {
                let pricingDetail = that.procedureFormViewModel.PricingDetailDefinitions.find(o => o.ObjectID.toString() === pricingDetailObjectID.toString());
                if (pricingDetail) {
                    detailItem.PricingDetail = pricingDetail;
                }

                if (pricingDetail != null) {
                    let pricingListObjectID = pricingDetail["PricingList"];
                    if (pricingListObjectID != null && (typeof pricingListObjectID === "string")) {
                        let pricingList = that.procedureFormViewModel.PricingListDefinitions.find(o => o.ObjectID.toString() === pricingListObjectID.toString());
                        if (pricingList) {
                            pricingDetail.PricingList = pricingList;
                        }
                    }

                }
            }


        }

    }

    async ngOnInit() {
        await this.load();
    }

    public onChargableChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.Chargable != event) {
            this._ProcedureDefinition.Chargable = event;
        }
    }

    public onCodeChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.Code != event) {
            this._ProcedureDefinition.Code = event;
        }
    }

    public onControlDayCountChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ControlDayCount != event) {
            this._ProcedureDefinition.ControlDayCount = event;
        }
    }

    public onCreateInMedulaDontSendStateChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.CreateInMedulaDontSendState != event) {
            this._ProcedureDefinition.CreateInMedulaDontSendState = event;
        }
    }

    public onDailyDayCountChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.DailyDayCount != event) {
            this._ProcedureDefinition.DailyDayCount = event;
        }
    }

    public onDailyMedulaProvisionNecessityChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.DailyMedulaProvisionNecessity != event) {
            this._ProcedureDefinition.DailyMedulaProvisionNecessity = event;
        }
    }

    public onDescriptionChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.Description != event) {
            this._ProcedureDefinition.Description = event;
        }
    }

    public onDoctorListBoxChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.Doctor != event) {
            this._ProcedureDefinition.Doctor = event;
        }
    }

    public onDontBlockInvoiceChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.DontBlockInvoice != event) {
            this._ProcedureDefinition.DontBlockInvoice = event;
        }
    }

    public onEmergencyDayCountChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.EmergencyDayCount != event) {
            this._ProcedureDefinition.EmergencyDayCount = event;
        }
    }

    public onExaminationDayCountChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ExaminationDayCount != event) {
            this._ProcedureDefinition.ExaminationDayCount = event;
        }
    }

    public onExternalOperationChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ExternalOperation != event) {
            this._ProcedureDefinition.ExternalOperation = event;
        }
    }

    public onForbiddenForControlChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ForbiddenForControl != event) {
            this._ProcedureDefinition.ForbiddenForControl = event;
        }
    }

    public onForbiddenForDailyChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ForbiddenForDaily != event) {
            this._ProcedureDefinition.ForbiddenForDaily = event;
        }
    }

    public onForbiddenForEmergencyChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ForbiddenForEmergency != event) {
            this._ProcedureDefinition.ForbiddenForEmergency = event;
        }
    }

    public onForbiddenForExaminationChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ForbiddenForExamination != event) {
            this._ProcedureDefinition.ForbiddenForExamination = event;
        }
    }

    public onForbiddenForInpatientChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ForbiddenForInpatient != event) {
            this._ProcedureDefinition.ForbiddenForInpatient = event;
        }
    }

    public onRepetitionQueryNeededChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.RepetitionQueryNeeded != event) {
            this._ProcedureDefinition.RepetitionQueryNeeded = event;
        }
    }

    public onGILDefinitionChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.GILDefinition != event) {
            this._ProcedureDefinition.GILDefinition = event;
        }
    }

    public onHUVCodeChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.HUVCode != event) {
            this._ProcedureDefinition.HUVCode = event;
        }
    }

    public onHUVPointChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.HUVPoint != event) {
            this._ProcedureDefinition.HUVPoint = event;
        }
    }

    public onIDChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ID != event) {
            this._ProcedureDefinition.ID = event;
        }
    }

    public onInpatientDayCountChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.InpatientDayCount != event) {
            this._ProcedureDefinition.InpatientDayCount = event;
        }
    }

    public onIsActiveChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.IsActive != event) {
            this._ProcedureDefinition.IsActive = event;
        }
    }

    public onIsDescriptionNeededChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.IsDescriptionNeeded != event) {
            this._ProcedureDefinition.IsDescriptionNeeded = event;
        }
    }

    public onMedulaProcedureTypeChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.MedulaProcedureType != event) {
            this._ProcedureDefinition.MedulaProcedureType = event;
        }
    }

    public onMedulaReportNecessityChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.MedulaReportNecessity != event) {
            this._ProcedureDefinition.MedulaReportNecessity = event;
        }
    }

    public onIsResultNeededChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.IsResultNeeded != event) {
            this._ProcedureDefinition.IsResultNeeded = event;
        }
    }

    public onIsVisibleChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.IsVisible != event) {
            this._ProcedureDefinition.IsVisible = event;
        }
    }

    public onNameChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.Name != event) {
            this._ProcedureDefinition.Name = event;
        }
    }

    public onOzelDurumChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.OzelDurum != event) {
            this._ProcedureDefinition.OzelDurum = event;
        }
    }

    public onPackageProcedureChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.PackageProcedure != event) {
            this._ProcedureDefinition.PackageProcedure = event;
        }
    }

    public onParticipationProcedureChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ParticipationProcedure != event) {
            this._ProcedureDefinition.ParticipationProcedure = event;
        }
    }

    public onPathologyOperationNeededChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.PathologyOperationNeeded != event) {
            this._ProcedureDefinition.PathologyOperationNeeded = event;
        }
    }

    public onPreProcedureEntryNecessityChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.PreProcedureEntryNecessity != event) {
            this._ProcedureDefinition.PreProcedureEntryNecessity = event;
        }
    }

    public onProcedureTypeChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ProcedureType != event) {
            this._ProcedureDefinition.ProcedureType = event;
        }
    }

    public onProvizyonTipiChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ProvizyonTipi != event) {
            this._ProcedureDefinition.ProvizyonTipi = event;
        }
    }

    public onQrefChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.Qref != event) {
            this._ProcedureDefinition.Qref = event;
        }
    }

    public onQualifiedMedicalProcessChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.QualifiedMedicalProcess != event) {
            this._ProcedureDefinition.QualifiedMedicalProcess = event;
        }
    }

    public onQuickEntryAllowedChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.QuickEntryAllowed != event) {
            this._ProcedureDefinition.QuickEntryAllowed = event;
        }
    }

    public onReportSelectionRequiredChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ReportSelectionRequired != event) {
            this._ProcedureDefinition.ReportSelectionRequired = event;
        }
    }

    public onREVENUESUBACCOUNTCODEChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.RevenueSubAccountCode != event) {
            this._ProcedureDefinition.RevenueSubAccountCode = event;
        }
    }

    public onSUTAppendixChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.SUTAppendix != event) {
            this._ProcedureDefinition.SUTAppendix = event;
        }
    }

    public onSUTPointChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.SUTPoint != event) {
            this._ProcedureDefinition.SUTPoint = event;
        }
    }

    public onTakipTipiChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.TakipTipi != event) {
            this._ProcedureDefinition.TakipTipi = event;
        }
    }

    public onTedaviTipiChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.TedaviTipi != event) {
            this._ProcedureDefinition.TedaviTipi = event;
        }
    }

    public onttcheckbox1Changed(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.Chargable != event) {
            this._ProcedureDefinition.Chargable = event;
        }
    }

    public onttcheckbox2Changed(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.QuickEntryAllowed != event) {
            this._ProcedureDefinition.QuickEntryAllowed = event;
        }
    }

    public onttcheckbox3Changed(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.IsActive != event) {
            this._ProcedureDefinition.IsActive = event;
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.ProcedureTree != event) {
            this._ProcedureDefinition.ProcedureTree = event;
        }
    }

    public onttobjectlistbox2Changed(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.MedulaProvisionTedaviTipi != event) {
            this._ProcedureDefinition.MedulaProvisionTedaviTipi = event;
        }
    }

    public ontxtGILCodeChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.GILCode != event) {
            this._ProcedureDefinition.GILCode = event;
        }
    }

    public ontxtGILPointChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.GILPoint != event) {
            this._ProcedureDefinition.GILPoint = event;
        }
    }

    public ontxtSUTCodeChanged(event): void {
        if (this._ProcedureDefinition != null && this._ProcedureDefinition.SUTCode != event) {
            this._ProcedureDefinition.SUTCode = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.IsVisible, "Value", this.__ttObject, "IsVisible");
        redirectProperty(this.IsResultNeeded, "Value", this.__ttObject, "IsResultNeeded");
        redirectProperty(this.ProcedureType, "Value", this.__ttObject, "ProcedureType");
        redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
        redirectProperty(this.Chargable, "Value", this.__ttObject, "Chargable");
        redirectProperty(this.QuickEntryAllowed, "Value", this.__ttObject, "QuickEntryAllowed");
        redirectProperty(this.ReportSelectionRequired, "Value", this.__ttObject, "ReportSelectionRequired");
        redirectProperty(this.IsDescriptionNeeded, "Value", this.__ttObject, "IsDescriptionNeeded");
        redirectProperty(this.ParticipationProcedure, "Value", this.__ttObject, "ParticipationProcedure");
        redirectProperty(this.ExternalOperation, "Value", this.__ttObject, "ExternalOperation");
        redirectProperty(this.PathologyOperationNeeded, "Value", this.__ttObject, "PathologyOperationNeeded");
        redirectProperty(this.QualifiedMedicalProcess, "Value", this.__ttObject, "QualifiedMedicalProcess");
        redirectProperty(this.DontBlockInvoice, "Value", this.__ttObject, "DontBlockInvoice");
        redirectProperty(this.RepetitionQueryNeeded, "Value", this.__ttObject, "RepetitionQueryNeeded");
        redirectProperty(this.Name, "Text", this.__ttObject, "Name");
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.txtSUTCode, "Text", this.__ttObject, "SUTCode");
        redirectProperty(this.HUVCode, "Text", this.__ttObject, "HUVCode");
        redirectProperty(this.txtGILCode, "Text", this.__ttObject, "GILCode");
        redirectProperty(this.SUTPoint, "Text", this.__ttObject, "SUTPoint");
        redirectProperty(this.HUVPoint, "Text", this.__ttObject, "HUVPoint");
        redirectProperty(this.txtGILPoint, "Text", this.__ttObject, "GILPoint");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
        redirectProperty(this.EmergencyDayCount, "Text", this.__ttObject, "EmergencyDayCount");
        redirectProperty(this.ExaminationDayCount, "Text", this.__ttObject, "ExaminationDayCount");
        redirectProperty(this.ControlDayCount, "Text", this.__ttObject, "ControlDayCount");
        redirectProperty(this.InpatientDayCount, "Text", this.__ttObject, "InpatientDayCount");
        redirectProperty(this.DailyDayCount, "Text", this.__ttObject, "DailyDayCount");
        redirectProperty(this.ForbiddenForEmergency, "Value", this.__ttObject, "ForbiddenForEmergency");
        redirectProperty(this.ForbiddenForExamination, "Value", this.__ttObject, "ForbiddenForExamination");
        redirectProperty(this.ForbiddenForControl, "Value", this.__ttObject, "ForbiddenForControl");
        redirectProperty(this.ForbiddenForInpatient, "Value", this.__ttObject, "ForbiddenForInpatient");
        redirectProperty(this.ForbiddenForDaily, "Value", this.__ttObject, "ForbiddenForDaily");
        redirectProperty(this.Qref, "Text", this.__ttObject, "Qref");
        redirectProperty(this.ID, "Text", this.__ttObject, "ID");
        redirectProperty(this.DailyMedulaProvisionNecessity, "Value", this.__ttObject, "DailyMedulaProvisionNecessity");
        redirectProperty(this.MedulaProcedureType, "Value", this.__ttObject, "MedulaProcedureType");
        redirectProperty(this.MedulaReportNecessity, "Value", this.__ttObject, "MedulaReportNecessity");
        redirectProperty(this.PreProcedureEntryNecessity, "Value", this.__ttObject, "PreProcedureEntryNecessity");
        redirectProperty(this.CreateInMedulaDontSendState, "Value", this.__ttObject, "CreateInMedulaDontSendState");
        redirectProperty(this.ttcheckbox1, "Value", this.__ttObject, "Chargable");
        redirectProperty(this.ttcheckbox2, "Value", this.__ttObject, "QuickEntryAllowed");
        redirectProperty(this.ttcheckbox3, "Value", this.__ttObject, "ISACTIVE");
        redirectProperty(this.RightLeftInfoNeeded, "Value", this.__ttObject, "RightLeftInfoNeeded");
    }

    public initFormControls(): void {
        this.tabProcedure = new TTVisual.TTTabControl();
        this.tabProcedure.Name = "tabProcedure";
        this.tabProcedure.TabIndex = 20;

        this.tpProcedure = new TTVisual.TTTabPage();
        this.tpProcedure.DisplayIndex = 0;
        this.tpProcedure.TabIndex = 0;
        this.tpProcedure.Text = "Hizmet";
        this.tpProcedure.Name = "tpProcedure";

        this.RepetitionQueryNeeded = new TTVisual.TTCheckBox();
        this.RepetitionQueryNeeded.Value = false;
        this.RepetitionQueryNeeded.Text = "Mükerrerlik Sorgusu Gerektirir";
        this.RepetitionQueryNeeded.Name = "RepetitionQueryNeeded";
        this.RepetitionQueryNeeded.TabIndex = 65;

        this.IsResultNeeded = new TTVisual.TTCheckBox();
        this.IsResultNeeded.Value = false;
        this.IsResultNeeded.Text = "Sonuç Değeri Gerektirir";
        this.IsResultNeeded.Name = "IsResultNeeded";
        this.IsResultNeeded.TabIndex = 62;

        this.IsVisible = new TTVisual.TTCheckBox();
        this.IsVisible.Value = false;
        this.IsVisible.Text = "Hizmet Tetkik Gridinde Görünür";
        this.IsVisible.Name = "IsVisible";
        this.IsVisible.TabIndex = 63;

        this.labelProcedureType = new TTVisual.TTLabel();
        this.labelProcedureType.Text = "Hizmet Türü";
        this.labelProcedureType.Name = "labelProcedureType";
        this.labelProcedureType.TabIndex = 60;

        this.ProcedureType = new TTVisual.TTEnumComboBox();
        this.ProcedureType.DataTypeName = "ProcedureDefGroupEnum";
        this.ProcedureType.Name = "ProcedureType";
        this.ProcedureType.TabIndex = 59;


        this.ttlabel22 = new TTVisual.TTLabel();
        this.ttlabel22.Text = "Yasaklı Kabul Grubu";
        this.ttlabel22.Name = "ttlabel22";
        this.ttlabel22.TabIndex = 58;

        this.ttlabel21 = new TTVisual.TTLabel();
        this.ttlabel21.Text = "İşlem gün Adedi";
        this.ttlabel21.Name = "ttlabel21";
        this.ttlabel21.TabIndex = 57;

        this.IsDescriptionNeeded = new TTVisual.TTCheckBox();
        this.IsDescriptionNeeded.Value = false;
        this.IsDescriptionNeeded.Title = "Açıklama girilmesini gerektirir";
        this.IsDescriptionNeeded.Name = "IsDescriptionNeeded";
        this.IsDescriptionNeeded.TabIndex = 56;

        this.labelInpatientDayCount = new TTVisual.TTLabel();
        this.labelInpatientDayCount.Text = "Yatış";
        this.labelInpatientDayCount.Name = "labelInpatientDayCount";
        this.labelInpatientDayCount.TabIndex = 55;

        this.InpatientDayCount = new TTVisual.TTTextBox();
        this.InpatientDayCount.Name = "InpatientDayCount";
        this.InpatientDayCount.TabIndex = 54;

        this.QualifiedMedicalProcess = new TTVisual.TTCheckBox();
        this.QualifiedMedicalProcess.Value = false;
        this.QualifiedMedicalProcess.Title = "Nitelikli Tıbbi İşlem ";
        this.QualifiedMedicalProcess.Name = "QualifiedMedicalProcess";
        this.QualifiedMedicalProcess.TabIndex = 53;

        this.PathologyOperationNeeded = new TTVisual.TTCheckBox();
        this.PathologyOperationNeeded.Value = false;
        this.PathologyOperationNeeded.Title = "Patholoji İşlemi Zorunlu";
        this.PathologyOperationNeeded.Name = "PathologyOperationNeeded";
        this.PathologyOperationNeeded.TabIndex = 52;

        this.ExternalOperation = new TTVisual.TTCheckBox();
        this.ExternalOperation.Value = false;
        this.ExternalOperation.Title = "Dış Hizmet";
        this.ExternalOperation.Name = "ExternalOperation";
        this.ExternalOperation.TabIndex = 51;

        this.labelSUTPoint = new TTVisual.TTLabel();
        this.labelSUTPoint.Text = "SUT Puanı";
        this.labelSUTPoint.Name = "labelSUTPoint";
        this.labelSUTPoint.TabIndex = 50;

        this.SUTPoint = new TTVisual.TTTextBox();
        this.SUTPoint.Name = "SUTPoint";
        this.SUTPoint.TabIndex = 49;

        this.labelHUVPoint = new TTVisual.TTLabel();
        this.labelHUVPoint.Text = "HUV Puanı";
        this.labelHUVPoint.Name = "labelHUVPoint";
        this.labelHUVPoint.TabIndex = 48;

        this.HUVPoint = new TTVisual.TTTextBox();
        this.HUVPoint.Name = "HUVPoint";
        this.HUVPoint.TabIndex = 47;

        this.labelHUVCode = new TTVisual.TTLabel();
        this.labelHUVCode.Text = "HUV Kodu";
        this.labelHUVCode.Name = "labelHUVCode";
        this.labelHUVCode.TabIndex = 46;

        this.HUVCode = new TTVisual.TTTextBox();
        this.HUVCode.Name = "HUVCode";
        this.HUVCode.TabIndex = 45;

        this.ForbiddenForInpatient = new TTVisual.TTCheckBox();
        this.ForbiddenForInpatient.Value = false;
        this.ForbiddenForInpatient.Title = "Yatış";
        this.ForbiddenForInpatient.Name = "ForbiddenForInpatient";
        this.ForbiddenForInpatient.TabIndex = 44;

        this.ForbiddenForExamination = new TTVisual.TTCheckBox();
        this.ForbiddenForExamination.Value = false;
        this.ForbiddenForExamination.Title = "Muayene";
        this.ForbiddenForExamination.Name = "ForbiddenForExamination";
        this.ForbiddenForExamination.TabIndex = 43;

        this.ForbiddenForEmergency = new TTVisual.TTCheckBox();
        this.ForbiddenForEmergency.Value = false;
        this.ForbiddenForEmergency.Title = "Acil";
        this.ForbiddenForEmergency.Name = "ForbiddenForEmergency";
        this.ForbiddenForEmergency.TabIndex = 42;

        this.ForbiddenForDaily = new TTVisual.TTCheckBox();
        this.ForbiddenForDaily.Value = false;
        this.ForbiddenForDaily.Title = "Günübirlik";
        this.ForbiddenForDaily.Name = "ForbiddenForDaily";
        this.ForbiddenForDaily.TabIndex = 41;

        this.ForbiddenForControl = new TTVisual.TTCheckBox();
        this.ForbiddenForControl.Value = false;
        this.ForbiddenForControl.Title = "Kontrol";
        this.ForbiddenForControl.Name = "ForbiddenForControl";
        this.ForbiddenForControl.TabIndex = 40;

        this.labelExaminationDayCount = new TTVisual.TTLabel();
        this.labelExaminationDayCount.Text = "Muayene";
        this.labelExaminationDayCount.Name = "labelExaminationDayCount";
        this.labelExaminationDayCount.TabIndex = 39;

        this.ExaminationDayCount = new TTVisual.TTTextBox();
        this.ExaminationDayCount.Name = "ExaminationDayCount";
        this.ExaminationDayCount.TabIndex = 38;

        this.labelEmergencyDayCount = new TTVisual.TTLabel();
        this.labelEmergencyDayCount.Text = "Acil";
        this.labelEmergencyDayCount.Name = "labelEmergencyDayCount";
        this.labelEmergencyDayCount.TabIndex = 37;

        this.EmergencyDayCount = new TTVisual.TTTextBox();
        this.EmergencyDayCount.Name = "EmergencyDayCount";
        this.EmergencyDayCount.TabIndex = 36;

        this.labelDailyDayCount = new TTVisual.TTLabel();
        this.labelDailyDayCount.Text = "Günübirlik";
        this.labelDailyDayCount.Name = "labelDailyDayCount";
        this.labelDailyDayCount.TabIndex = 35;

        this.DailyDayCount = new TTVisual.TTTextBox();
        this.DailyDayCount.Name = "DailyDayCount";
        this.DailyDayCount.TabIndex = 34;

        this.labelControlDayCount = new TTVisual.TTLabel();
        this.labelControlDayCount.Text = "Kontrol";
        this.labelControlDayCount.Name = "labelControlDayCount";
        this.labelControlDayCount.TabIndex = 33;

        this.ControlDayCount = new TTVisual.TTTextBox();
        this.ControlDayCount.Name = "ControlDayCount";
        this.ControlDayCount.TabIndex = 32;

        this.labelGILDefinition = new TTVisual.TTLabel();
        this.labelGILDefinition.Text = "GİL";
        this.labelGILDefinition.Name = "labelGILDefinition";
        this.labelGILDefinition.TabIndex = 31;

        this.GILDefinition = new TTVisual.TTObjectListBox();
        this.GILDefinition.ListDefName = "GILListDefinition";
        this.GILDefinition.Name = "GILDefinition";
        this.GILDefinition.TabIndex = 30;

        this.ParticipationProcedure = new TTVisual.TTCheckBox();
        this.ParticipationProcedure.Value = false;
        this.ParticipationProcedure.Title = "Katılım Payı Hizmeti";
        this.ParticipationProcedure.Name = "ParticipationProcedure";
        this.ParticipationProcedure.TabIndex = 29;

        this.DontBlockInvoice = new TTVisual.TTCheckBox();
        this.DontBlockInvoice.Value = false;
        this.DontBlockInvoice.Title = "Fatura Engelleme";
        this.DontBlockInvoice.Name = "DontBlockInvoice";
        this.DontBlockInvoice.TabIndex = 28;

        this.txtSUTCode = new TTVisual.TTTextBox();
        this.txtSUTCode.Name = "txtSUTCode";
        this.txtSUTCode.TabIndex = 27;

        this.lblSUTCode = new TTVisual.TTLabel();
        this.lblSUTCode.Text = "SUT Kodu";
        this.lblSUTCode.Name = "lblSUTCode";
        this.lblSUTCode.TabIndex = 26;

        this.QuickEntryAllowed = new TTVisual.TTCheckBox();
        this.QuickEntryAllowed.Value = false;
        this.QuickEntryAllowed.Title = "Hızlı İşlem Giriş Yapılır";
        this.QuickEntryAllowed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.QuickEntryAllowed.Name = "QuickEntryAllowed";
        this.QuickEntryAllowed.TabIndex = 3;

        this.Chargable = new TTVisual.TTCheckBox();
        this.Chargable.Value = false;
        this.Chargable.Title = "Ücretlenir";
        this.Chargable.Name = "Chargable";
        this.Chargable.TabIndex = 25;

        this.ReportSelectionRequired = new TTVisual.TTCheckBox();
        this.ReportSelectionRequired.Value = false;
        this.ReportSelectionRequired.Title = "Rapor Seçimi Gerektirir";
        this.ReportSelectionRequired.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReportSelectionRequired.Name = "ReportSelectionRequired";
        this.ReportSelectionRequired.TabIndex = 3;

        this.SUTAppendix = new TTVisual.TTEnumComboBox();
        this.SUTAppendix.DataTypeName = "SUTHizmetEKEnum";
        this.SUTAppendix.Name = "SUTAppendix";
        this.SUTAppendix.TabIndex = 24;

        this.lblSUTAppendix = new TTVisual.TTLabel();
        this.lblSUTAppendix.Text = "SUT Eki";
        this.lblSUTAppendix.Name = "lblSUTAppendix";
        this.lblSUTAppendix.TabIndex = 23;

        this.txtGILCode = new TTVisual.TTTextBox();
        this.txtGILCode.Name = "txtGILCode";
        this.txtGILCode.TabIndex = 22;

        this.lblGILCode = new TTVisual.TTLabel();
        this.lblGILCode.Text = "GİL Kodu";
        this.lblGILCode.Name = "lblGILCode";
        this.lblGILCode.TabIndex = 21;

        this.txtGILPoint = new TTVisual.TTTextBox();
        this.txtGILPoint.Name = "txtGILPoint";
        this.txtGILPoint.TabIndex = 20;

        this.lblGILPoint = new TTVisual.TTLabel();
        this.lblGILPoint.Text = "GİL Puanı";
        this.lblGILPoint.Name = "lblGILPoint";
        this.lblGILPoint.TabIndex = 19;

        this.PackageProcedure = new TTVisual.TTObjectListBox();
        this.PackageProcedure.ListDefName = "PackageProcedureListDefinition";
        this.PackageProcedure.Name = "PackageProcedure";
        this.PackageProcedure.TabIndex = 18;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = "Paket Hizmeti";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 17;

        this.labelQref = new TTVisual.TTLabel();
        this.labelQref.Text = "Kısa Ad";
        this.labelQref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelQref.ForeColor = "#000000";
        this.labelQref.Name = "labelQref";
        this.labelQref.TabIndex = 10;

        this.labelName = new TTVisual.TTLabel();
        this.labelName.Text = "Hizmet Adı";
        this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelName.ForeColor = "#000000";
        this.labelName.Name = "labelName";
        this.labelName.TabIndex = 12;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = "Açıklama";
        this.labelDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelDescription.ForeColor = "#000000";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 16;

        this.ProcType = new TTVisual.TTTextBox();
        this.ProcType.BackColor = "#F0F0F0";
        // this.ProcType.ReadOnly = true;
        this.ProcType.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcType.Name = "ProcType";
        this.ProcType.TabIndex = 0;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Bağlı Olduğu Hizmet Grubu";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 15;

        this.IsActive = new TTVisual.TTCheckBox();
        this.IsActive.Value = false;
        this.IsActive.Title = "Aktif";
        this.IsActive.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IsActive.Name = "IsActive";
        this.IsActive.TabIndex = 3;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = "No";
        this.labelID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelID.ForeColor = "#000000";
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 11;

        this.Name = new TTVisual.TTTextBox();
        this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Name.Name = "Name";
        this.Name.TabIndex = 4;

        this.REVENUESUBACCOUNTCODE = new TTVisual.TTObjectListBox();
        this.REVENUESUBACCOUNTCODE.ListDefName = "RevenueSubAccountCodeDefList";
        this.REVENUESUBACCOUNTCODE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.REVENUESUBACCOUNTCODE.Name = "REVENUESUBACCOUNTCODE";
        this.REVENUESUBACCOUNTCODE.TabIndex = 7;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Kod";
        this.labelCode.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelCode.ForeColor = "#000000";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 9;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Muhasebe Gelir Hesap Kırınımı";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 14;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "ProcedureTreeListDefinition";
        this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 6;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = " Medula Hizmet Türü";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 9;

        this.GridSubProcedures = new TTVisual.TTGrid();
        this.GridSubProcedures.HideCancelledData = false;
        this.GridSubProcedures.AllowUserToResizeColumns = false;
        this.GridSubProcedures.AllowUserToResizeRows = false;
        this.GridSubProcedures.Name = "GridSubProcedures";
        this.GridSubProcedures.TabIndex = 0;

        this.ttlistboxcolumn1 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn1.ListDefName = "ProcedureListDefinition";
        this.ttlistboxcolumn1.ListFilterExpression = "OBJECTDEFNAME <> 'PACKAGEPROCEDUREDEFINITION'";
        this.ttlistboxcolumn1.DataMember = "ChildProcedureDefinition";
        this.ttlistboxcolumn1.Required = true;
        this.ttlistboxcolumn1.DisplayIndex = 0;
        this.ttlistboxcolumn1.HeaderText = "Hizmet";
        this.ttlistboxcolumn1.Name = "ttlistboxcolumn1";
        this.ttlistboxcolumn1.Width = 270;
        this.ttlistboxcolumn1.MinSearchLength = 3;

        this.tttextboxcolumn1 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn1.DataMember = "Amount";
        this.tttextboxcolumn1.Required = true;
        this.tttextboxcolumn1.DisplayIndex = 1;
        this.tttextboxcolumn1.HeaderText = "Miktar";
        this.tttextboxcolumn1.Name = "tttextboxcolumn1";
        this.tttextboxcolumn1.Width = 50;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 8;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Birlikte Ücretlendirilecek Hizmetler";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 9;

        this.Qref = new TTVisual.TTTextBox();
        this.Qref.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Qref.Name = "Qref";
        this.Qref.TabIndex = 1;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.ID = new TTVisual.TTTextBox();
        this.ID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ID.Name = "ID";
        this.ID.TabIndex = 2;

        this.ttlabel9 = new TTVisual.TTTabPage();
        this.ttlabel9.DisplayIndex = 1;
        this.ttlabel9.TabIndex = 1;
        this.ttlabel9.Text = "Medula";
        this.ttlabel9.Name = "ttlabel9";

        this.MedulaProvisionProperties = new TTVisual.TTGroupBox();
        this.MedulaProvisionProperties.Text = "Yeni Takip Alınması Gerekir";
        this.MedulaProvisionProperties.Name = "MedulaProvisionProperties";
        this.MedulaProvisionProperties.TabIndex = 31;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "Tedavi Tipi";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 28;

        this.DailyMedulaProvisionNecessity = new TTVisual.TTCheckBox();
        this.DailyMedulaProvisionNecessity.Value = false;
        this.DailyMedulaProvisionNecessity.Title = "Günübirlik Takip";
        this.DailyMedulaProvisionNecessity.Name = "DailyMedulaProvisionNecessity";
        this.DailyMedulaProvisionNecessity.TabIndex = 21;

        this.RightLeftInfoNeeded = new TTVisual.TTCheckBox();
        this.RightLeftInfoNeeded.Value = false;
        this.RightLeftInfoNeeded.Title = "Sağ / Sol Seçimi Zorunlu";
        this.RightLeftInfoNeeded.Name = "RightLeftInfoNeeded";
        this.RightLeftInfoNeeded.TabIndex = 21;

        this.ttobjectlistbox2 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox2.ListDefName = "TedaviTipiListDefinition";
        this.ttobjectlistbox2.Name = "ttobjectlistbox2";
        this.ttobjectlistbox2.TabIndex = 27;

        this.DoctorLabel = new TTVisual.TTLabel();
        this.DoctorLabel.Text = "Doktor";
        this.DoctorLabel.Name = "DoctorLabel";
        this.DoctorLabel.TabIndex = 30;

        this.DoctorListBox = new TTVisual.TTObjectListBox();
        this.DoctorListBox.ListDefName = "DoctorListDefinition";
        this.DoctorListBox.Name = "DoctorListBox";
        this.DoctorListBox.TabIndex = 29;

        this.CreateInMedulaDontSendState = new TTVisual.TTCheckBox();
        this.CreateInMedulaDontSendState.Value = false;
        this.CreateInMedulaDontSendState.Title = "Medulaya Gönderilmeyecek Durumunda Oluştur";
        this.CreateInMedulaDontSendState.Name = "CreateInMedulaDontSendState";
        this.CreateInMedulaDontSendState.TabIndex = 28;

        this.TedaviTipi = new TTVisual.TTObjectListBox();
        this.TedaviTipi.ListDefName = "TedaviTipiListDefinition";
        this.TedaviTipi.Name = "TedaviTipi";
        this.TedaviTipi.TabIndex = 27;

        this.TakipTipi = new TTVisual.TTObjectListBox();
        this.TakipTipi.ListDefName = "TakipTipiListDefinition";
        this.TakipTipi.Name = "TakipTipi";
        this.TakipTipi.TabIndex = 26;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Takibinin Tedavi Tipini Güncelle";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 25;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "Takibinin Takip Tipini Güncelle";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 24;

        this.ProvizyonTipi = new TTVisual.TTObjectListBox();
        this.ProvizyonTipi.ListDefName = "ProvizyonTipiListDefinition";
        this.ProvizyonTipi.Name = "ProvizyonTipi";
        this.ProvizyonTipi.TabIndex = 23;

        this.PreProcedureEntryNecessity = new TTVisual.TTCheckBox();
        this.PreProcedureEntryNecessity.Value = false;
        this.PreProcedureEntryNecessity.Title = "Ön Hizmet Kayıt Kontrolü Gerektirir";
        this.PreProcedureEntryNecessity.Name = "PreProcedureEntryNecessity";
        this.PreProcedureEntryNecessity.TabIndex = 22;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Takibinin Provizyon Tipini Güncelle";
        this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 11;

        this.MedulaProcedureType = new TTVisual.TTEnumComboBox();
        this.MedulaProcedureType.DataTypeName = "MedulaSUTGroupEnum";
        this.MedulaProcedureType.Name = "MedulaProcedureType";
        this.MedulaProcedureType.TabIndex = 17;

        this.OzelDurum = new TTVisual.TTObjectListBox();
        this.OzelDurum.ListDefName = "OzelDurumListDefinition";
        this.OzelDurum.Name = "OzelDurum";
        this.OzelDurum.TabIndex = 17;

        this.labelMedulaReportNecessity = new TTVisual.TTLabel();
        this.labelMedulaReportNecessity.Text = "Hizmet Kaydı İçin Rapor Zorunluluk Durumu";
        this.labelMedulaReportNecessity.Name = "labelMedulaReportNecessity";
        this.labelMedulaReportNecessity.TabIndex = 20;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "Özel Durum";
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 11;

        this.MedulaReportNecessity = new TTVisual.TTEnumComboBox();
        this.MedulaReportNecessity.DataTypeName = "MedulaRaporZorunluluguEnum";
        this.MedulaReportNecessity.Name = "MedulaReportNecessity";
        this.MedulaReportNecessity.TabIndex = 19;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = "Hizmet Kayıt Grubu";
        this.ttlabel12.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel12.ForeColor = "#000000";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 11;

        this.tpPrices = new TTVisual.TTTabPage();
        this.tpPrices.DisplayIndex = 2;
        this.tpPrices.TabIndex = 2;
        this.tpPrices.Text = "Fiyatlar";
        this.tpPrices.Name = "tpPrices";

        this.grdPrices = new TTVisual.TTGrid();
        this.grdPrices.AllowUserToDeleteRows = false;
        this.grdPrices.AllowUserToOrderColumns = true;
        this.grdPrices.AllowUserToResizeRows = false;
        this.grdPrices.Name = "grdPrices";
        this.grdPrices.TabIndex = 0;

        this.PricingDetail = new TTVisual.TTListBoxColumn();
        this.PricingDetail.ListDefName = "PricingDetailListDefinition";
        this.PricingDetail.DataMember = "PricingDetail";
        this.PricingDetail.DisplayIndex = 0;
        this.PricingDetail.HeaderText = "Fiyat";
        this.PricingDetail.Name = "PricingDetail";
        this.PricingDetail.Width = 400;

        this.PriceList = new TTVisual.TTListDefComboBoxColumn();
        this.PriceList.ListDefName = "PricingListListDefinition";
        this.PriceList.DataMember = "PricingList";
        this.PriceList.DisplayIndex = 1;
        this.PriceList.HeaderText = "Fiyat Listesi";
        this.PriceList.Name = "PriceList";
        this.PriceList.ReadOnly = true;
        this.PriceList.Width = 200;

        this.PriceStartDate = new TTVisual.TTDateTimePickerColumn();
        this.PriceStartDate.DataMember = "DateStart";
        this.PriceStartDate.DisplayIndex = 2;
        this.PriceStartDate.HeaderText = "Başlangıç Tarihi";
        this.PriceStartDate.Name = "PriceStartDate";
        this.PriceStartDate.ReadOnly = true;
        this.PriceStartDate.Width = 120;

        this.PriceEndDate = new TTVisual.TTDateTimePickerColumn();
        this.PriceEndDate.DataMember = "DateEnd";
        this.PriceEndDate.DisplayIndex = 3;
        this.PriceEndDate.HeaderText = "Bitiş Tarihi";
        this.PriceEndDate.Name = "PriceEndDate";
        this.PriceEndDate.ReadOnly = true;
        this.PriceEndDate.Width = 120;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.DisplayIndex = 4;
        this.Price.HeaderText = "Fiyat";
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Width = 80;

        this.ttcheckbox1 = new TTVisual.TTCheckBox();
        this.ttcheckbox1.Value = false;
        this.ttcheckbox1.Text = "Ücretlenir";
        this.ttcheckbox1.Name = "ttcheckbox1";
        this.ttcheckbox1.TabIndex = 25;

        this.ttcheckbox3 = new TTVisual.TTCheckBox();
        this.ttcheckbox3.Value = false;
        this.ttcheckbox3.Text = "Aktif";
        this.ttcheckbox3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttcheckbox3.Name = "ttcheckbox3";
        this.ttcheckbox3.TabIndex = 3;

        this.ttcheckbox2 = new TTVisual.TTCheckBox();
        this.ttcheckbox2.Value = false;
        this.ttcheckbox2.Text = "Hızlı İşlem Giriş Yapılır";
        this.ttcheckbox2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttcheckbox2.Name = "ttcheckbox2";
        this.ttcheckbox2.TabIndex = 3;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = "Zorunlu Tanılar";
        this.ttlabel13.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel13.ForeColor = "#000000";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 9;

        this.GridRequiredDiagnosis = new TTVisual.TTGrid();
        this.GridRequiredDiagnosis.Name = "GridRequiredDiagnosis";
        this.GridRequiredDiagnosis.TabIndex = 61;

        this.DiagnosisDefinitionRequiredDiagnoseProcedure = new TTVisual.TTListBoxColumn();
        this.DiagnosisDefinitionRequiredDiagnoseProcedure.AllowMultiSelect = true;
        this.DiagnosisDefinitionRequiredDiagnoseProcedure.ListDefName = "DiagnosisListDefinition";
        this.DiagnosisDefinitionRequiredDiagnoseProcedure.DataMember = "DiagnosisDefinition";
        this.DiagnosisDefinitionRequiredDiagnoseProcedure.DisplayIndex = 0;
        this.DiagnosisDefinitionRequiredDiagnoseProcedure.HeaderText = "";
        this.DiagnosisDefinitionRequiredDiagnoseProcedure.Name = "DiagnosisDefinitionRequiredDiagnoseProcedure";
        this.DiagnosisDefinitionRequiredDiagnoseProcedure.Width = 300;
        
        this.GridRequiredDiagnosisColumns = [this.DiagnosisDefinitionRequiredDiagnoseProcedure];
        this.GridSubProceduresColumns = [this.ttlistboxcolumn1, this.tttextboxcolumn1];
        this.grdPricesColumns = [this.PricingDetail, this.PriceList, this.PriceStartDate, this.PriceEndDate, this.Price];
        this.tabProcedure.Controls = [this.tpProcedure, this.ttlabel9, this.tpPrices];
        this.tpProcedure.Controls = [this.RepetitionQueryNeeded, this.IsVisible, this.IsResultNeeded, this.labelProcedureType, this.ProcedureType, this.ttlabel22, this.ttlabel21, this.ttlabel13, this.GridRequiredDiagnosis, this.IsDescriptionNeeded, this.labelInpatientDayCount, this.InpatientDayCount, this.QualifiedMedicalProcess, this.PathologyOperationNeeded, this.ExternalOperation, this.labelSUTPoint, this.SUTPoint, this.labelHUVPoint, this.HUVPoint, this.labelHUVCode, this.HUVCode, this.ForbiddenForInpatient, this.ForbiddenForExamination, this.ForbiddenForEmergency, this.ForbiddenForDaily, this.ForbiddenForControl, this.labelExaminationDayCount, this.ExaminationDayCount, this.labelEmergencyDayCount, this.EmergencyDayCount, this.labelDailyDayCount, this.DailyDayCount, this.labelControlDayCount, this.ControlDayCount, this.labelGILDefinition, this.GILDefinition, this.ParticipationProcedure, this.DontBlockInvoice, this.txtSUTCode, this.lblSUTCode, this.QuickEntryAllowed, this.Chargable, this.ReportSelectionRequired, this.SUTAppendix, this.lblSUTAppendix, this.txtGILCode, this.lblGILCode, this.txtGILPoint, this.lblGILPoint, this.PackageProcedure, this.ttlabel10, this.labelQref, this.labelName, this.labelDescription, this.ProcType, this.ttlabel1, this.IsActive, this.labelID, this.Name, this.REVENUESUBACCOUNTCODE, this.labelCode, this.ttlabel3, this.ttobjectlistbox1, this.ttlabel2, this.GridSubProcedures, this.Description, this.ttlabel4, this.Qref, this.Code, this.ID, this.RightLeftInfoNeeded];
        this.ttlabel9.Controls = [this.MedulaProvisionProperties, this.DoctorLabel, this.DoctorListBox, this.CreateInMedulaDontSendState, this.TedaviTipi, this.TakipTipi, this.ttlabel5, this.ttlabel8, this.ProvizyonTipi, this.PreProcedureEntryNecessity, this.ttlabel6, this.MedulaProcedureType, this.OzelDurum, this.labelMedulaReportNecessity, this.ttlabel7, this.MedulaReportNecessity, this.ttlabel12];
        this.MedulaProvisionProperties.Controls = [this.ttlabel11, this.DailyMedulaProvisionNecessity, this.ttobjectlistbox2];
        this.tpPrices.Controls = [this.grdPrices];

        this.Controls = [this.tabProcedure, this.tpProcedure, this.RepetitionQueryNeeded,  this.IsVisible, this.IsResultNeeded, this.labelProcedureType, this.ProcedureType, this.ttlabel22, this.ttlabel13, this.GridRequiredDiagnosis, this.DiagnosisDefinitionRequiredDiagnoseProcedure, this.ttlabel21, this.IsDescriptionNeeded, this.labelInpatientDayCount, this.InpatientDayCount, this.QualifiedMedicalProcess, this.PathologyOperationNeeded, this.ExternalOperation, this.labelSUTPoint, this.SUTPoint, this.labelHUVPoint, this.HUVPoint, this.labelHUVCode, this.HUVCode, this.ForbiddenForInpatient, this.ForbiddenForExamination, this.ForbiddenForEmergency, this.ForbiddenForDaily, this.ForbiddenForControl, this.labelExaminationDayCount, this.ExaminationDayCount, this.labelEmergencyDayCount, this.EmergencyDayCount, this.labelDailyDayCount, this.DailyDayCount, this.labelControlDayCount, this.ControlDayCount, this.labelGILDefinition, this.GILDefinition, this.ParticipationProcedure, this.DontBlockInvoice, this.txtSUTCode, this.lblSUTCode, this.QuickEntryAllowed, this.Chargable, this.ReportSelectionRequired, this.SUTAppendix, this.lblSUTAppendix, this.txtGILCode, this.lblGILCode, this.txtGILPoint, this.lblGILPoint, this.PackageProcedure, this.ttlabel10, this.labelQref, this.labelName, this.labelDescription, this.ProcType, this.ttlabel1, this.IsActive, this.labelID, this.Name, this.REVENUESUBACCOUNTCODE, this.labelCode, this.ttlabel3, this.ttobjectlistbox1, this.ttlabel2, this.GridSubProcedures, this.ttlistboxcolumn1, this.tttextboxcolumn1, this.Description, this.ttlabel4, this.Qref, this.Code, this.ID, this.ttlabel9, this.MedulaProvisionProperties, this.ttlabel11, this.DailyMedulaProvisionNecessity, this.ttobjectlistbox2, this.DoctorLabel, this.DoctorListBox, this.CreateInMedulaDontSendState, this.TedaviTipi, this.TakipTipi, this.ttlabel5, this.ttlabel8, this.ProvizyonTipi, this.PreProcedureEntryNecessity, this.ttlabel6, this.MedulaProcedureType, this.OzelDurum, this.labelMedulaReportNecessity, this.ttlabel7, this.MedulaReportNecessity, this.ttlabel12, this.tpPrices, this.grdPrices, this.PricingDetail, this.PriceList, this.PriceStartDate, this.PriceEndDate, this.Price, this.ttcheckbox1, this.ttcheckbox3, this.ttcheckbox2, this.RightLeftInfoNeeded];

    }


}
