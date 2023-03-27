//$8658D3B9
import { Component, OnInit } from '@angular/core';
import { DrugDeliveryActionNewFormViewModel } from './DrugDeliveryActionNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DrugDeliveryAction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDeliveryActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugDeliveryActionService, GetDetails_Output } from 'ObjectClassService/DrugDeliveryActionService';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ModalInfo } from 'Fw/Models/ModalInfo';


@Component({
    selector: 'DrugDeliveryActionNewForm',
    templateUrl: './DrugDeliveryActionNewForm.html',
    providers: [MessageService]
})
export class DrugDeliveryActionNewForm extends TTVisual.TTForm implements OnInit {

    selectedDetails: Array<DrugDeliveryActionDetail> = new Array<DrugDeliveryActionDetail>();

    ActionDate: TTVisual.ITTDateTimePicker;
    DrugDeliveryActionDetails: TTVisual.ITTGrid;
    DrugName: TTVisual.ITTTextBoxColumn;
    ID: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    ResDose: TTVisual.ITTTextBoxColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    tttextbox1: TTVisual.ITTTextBox;
    public DrugDeliveryActionDetailsColumns = [];
    public drugDeliveryActionNewFormViewModel: DrugDeliveryActionNewFormViewModel = new DrugDeliveryActionNewFormViewModel();
    public get _DrugDeliveryAction(): DrugDeliveryAction {
        return this._TTObject as DrugDeliveryAction;
    }
    private DrugDeliveryActionNewForm_DocumentUrl: string = '/api/DrugDeliveryActionService/DrugDeliveryActionNewForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('DRUGDELIVERYACTION', 'DrugDeliveryActionNewForm');
        this._DocumentServiceUrl = this.DrugDeliveryActionNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public async setInputParam(value: Object) {
        this._TTObject = value as DrugDeliveryAction;
        this.drugDeliveryActionNewFormViewModel = new DrugDeliveryActionNewFormViewModel();
        this._ViewModel = this.drugDeliveryActionNewFormViewModel;
        this.drugDeliveryActionNewFormViewModel._DrugDeliveryAction = value as DrugDeliveryAction;
        //await this.PreScript();

    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    protected isLoadViewModel(): boolean {
        return false;
    }

    // ***** Method declarations start *****

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        /* if (transDef !== null && transDef.ToStateDefID === DrugDeliveryAction.DrugDeliveryActionStates.Completed) {
             let parameter: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
             let objectID: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
             objectID.push('VALUE', this._DrugDeliveryAction.ObjectID.toString());
             parameter.push('TTOBJECTID', objectID);
             TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_DrugDeliveryReport, true, 1, parameter);
         }*/
    }

    protected async ClientSidePostScript()
    {
        this.drugDeliveryActionNewFormViewModel.DrugDeliveryActionDetailsGridList = this.selectedDetails;
    }

    protected async PreScript(): Promise<void> {
        super.PreScript();

        this.drugDeliveryActionNewFormViewModel.DrugDeliveryActionDetailsGridList = new Array<DrugDeliveryActionDetail>();
        this._DrugDeliveryAction.DrugDeliveryActionDetails = new Array<DrugDeliveryActionDetail>();
        let episodeId: Guid = this._DrugDeliveryAction.Episode.ObjectID;
        let details: Array<GetDetails_Output> = await DrugDeliveryActionService.GetDetails(episodeId);
        for (let detail of details) {
            let drugDeliveryActionDetail: DrugDeliveryActionDetail = new DrugDeliveryActionDetail();
            drugDeliveryActionDetail.DrugName = detail.drugName;
            drugDeliveryActionDetail.ResDose = detail.Amount;
            drugDeliveryActionDetail.DrugOrderTransaction = detail.drugOrderTransaction;
            for (let orderDetail of detail.DrugOrderDetails) {
                drugDeliveryActionDetail.DrugOrderDetails = new Array<DrugOrderDetail>();
                drugDeliveryActionDetail.DrugOrderDetails.push(orderDetail);
                if (this.drugDeliveryActionNewFormViewModel.DrugOrderDetails.length === 0) {
                    this.drugDeliveryActionNewFormViewModel.DrugOrderDetails = new Array<DrugOrderDetail>();
                }
                this.drugDeliveryActionNewFormViewModel.DrugOrderDetails.push(orderDetail);
            }
            this.drugDeliveryActionNewFormViewModel.DrugDeliveryActionDetailsGridList.push(drugDeliveryActionDetail);
            this._DrugDeliveryAction.DrugDeliveryActionDetails.push(drugDeliveryActionDetail);

        }
        /* let allDrugOrderTransaction: Array<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class> =
             (await DrugOrderTransactionService.GetDrugOrderTransactionByEpisodeRQ(this._DrugDeliveryAction.Episode.ObjectID));
         let drugOrderList: Dictionary<Guid, DrugOrder> = new Dictionary<Guid, DrugOrder>();
         for (let drugOrderTransaction of allDrugOrderTransaction) {
             if (drugOrderList.containsKey(<Guid>drugOrderTransaction.Drugorder) === false) {
                 let trx: DrugOrderTransaction = <DrugOrderTransaction>this._DrugDeliveryAction.ObjectContext.GetObject(<Guid>drugOrderTransaction.ObjectID, 'DRUGORDERTRANSACTION');
                 let order: DrugOrder = <DrugOrder>this._DrugDeliveryAction.ObjectContext.GetObject(<Guid>drugOrderTransaction.Drugorder, 'DRUGORDER');
                 drugOrderList.push(<Guid>drugOrderTransaction.Drugorder, order);
                 let drugDefinition: DrugDefinition = <DrugDefinition>this._DrugDeliveryAction.ObjectContext.GetObject(<Guid>drugOrderTransaction.Drugdefinition, 'DRUGDEFINITION');
                 let drugType: boolean = (await DrugOrderService.GetDrugUsedType(drugDefinition));
                 if (drugType) {
                     if ((await DrugOrderTransactionService.GetRestDose(order)) > 0) {
                         let drugDeliveryActionDetail: DrugDeliveryActionDetail = this._DrugDeliveryAction.DrugDeliveryActionDetails.AddNew();
                         drugDeliveryActionDetail.ResDose = (await DrugOrderTransactionService.GetRestDose(order));
                         drugDeliveryActionDetail.DrugName = drugDefinition.Name;
                         drugDeliveryActionDetail.DrugOrderTransaction = trx;
                         for (let drugOrderDetail of order.DrugOrderDetails) {
                             if (drugOrderDetail.CurrentStateDefID === DrugOrderDetail.DrugOrderDetailStates.Supply ||
                                 drugOrderDetail.CurrentStateDefID === DrugOrderDetail.DrugOrderDetailStates.ExPharmacySupply) {
                                 drugDeliveryActionDetail.DrugOrderDetails.push(drugOrderDetail);
                             }
                         }
                     }
                 } else {
                     let resVolume: number = (await DrugOrderTransactionService.GetRestDose(order));
                     let resAmount: number = 0;
                     if (resVolume > 0) {
                         resAmount = Math.Truncate(resVolume / <number>drugDefinition.Volume);
                         if (resAmount > 0) {
                             let drugDeliveryActionDetail: DrugDeliveryActionDetail = this._DrugDeliveryAction.DrugDeliveryActionDetails.AddNew();
                             drugDeliveryActionDetail.ResDose = resAmount;
                             drugDeliveryActionDetail.DrugName = drugDefinition.Name;
                             drugDeliveryActionDetail.DrugOrderTransaction = trx;
                             for (let drugOrderDetail of order.DrugOrderDetails) {
                                 if (drugOrderDetail.CurrentStateDefID === DrugOrderDetail.DrugOrderDetailStates.Supply ||
                                     drugOrderDetail.CurrentStateDefID === DrugOrderDetail.DrugOrderDetailStates.ExPharmacySupply) {
                                     drugDeliveryActionDetail.DrugOrderDetails.push(drugOrderDetail);
                                 }
                             }
                         }
                     }
                 }
             }
         }*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DrugDeliveryAction();
        this.drugDeliveryActionNewFormViewModel = new DrugDeliveryActionNewFormViewModel();
        this._ViewModel = this.drugDeliveryActionNewFormViewModel;
        this.drugDeliveryActionNewFormViewModel._DrugDeliveryAction = this._TTObject as DrugDeliveryAction;
        this.drugDeliveryActionNewFormViewModel._DrugDeliveryAction.Episode = new Episode();
        this.drugDeliveryActionNewFormViewModel._DrugDeliveryAction.Episode.Patient = new Patient();
        this.drugDeliveryActionNewFormViewModel._DrugDeliveryAction.DrugDeliveryActionDetails = new Array<DrugDeliveryActionDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.drugDeliveryActionNewFormViewModel = this._ViewModel as DrugDeliveryActionNewFormViewModel;
        that._TTObject = this.drugDeliveryActionNewFormViewModel._DrugDeliveryAction;
        if (this.drugDeliveryActionNewFormViewModel == null)
            this.drugDeliveryActionNewFormViewModel = new DrugDeliveryActionNewFormViewModel();
        if (this.drugDeliveryActionNewFormViewModel._DrugDeliveryAction == null)
            this.drugDeliveryActionNewFormViewModel._DrugDeliveryAction = new DrugDeliveryAction();
        let episodeObjectID = that.drugDeliveryActionNewFormViewModel._DrugDeliveryAction['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.drugDeliveryActionNewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.drugDeliveryActionNewFormViewModel._DrugDeliveryAction.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode['Patient'];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.drugDeliveryActionNewFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        that.drugDeliveryActionNewFormViewModel._DrugDeliveryAction.DrugDeliveryActionDetails = that.drugDeliveryActionNewFormViewModel.DrugDeliveryActionDetailsGridList;
        for (let detailItem of that.drugDeliveryActionNewFormViewModel.DrugDeliveryActionDetailsGridList) {
        }

    }

    async ngOnInit() {
        await this.load();
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._DrugDeliveryAction != null && this._DrugDeliveryAction.ActionDate !== event) {
                this._DrugDeliveryAction.ActionDate = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._DrugDeliveryAction != null && this._DrugDeliveryAction.ID !== event) {
                this._DrugDeliveryAction.ID = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._DrugDeliveryAction != null &&
                this._DrugDeliveryAction.Episode != null &&
                this._DrugDeliveryAction.Episode.Patient != null && this._DrugDeliveryAction.Episode.Patient.FullName !== event) {
                this._DrugDeliveryAction.Episode.Patient.FullName = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ID, 'Text', this.__ttObject, 'ID');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
        redirectProperty(this.tttextbox1, 'Text', this.__ttObject, 'Episode.Patient.FullName');
    }

    public initFormControls(): void {
        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = '#F0F0F0';
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = 'tttextbox1';
        this.tttextbox1.TabIndex = 11;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = '#F0F0F0';
        this.ID.ReadOnly = true;
        this.ID.Name = 'ID';
        this.ID.TabIndex = 9;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16866", "İşlem No");
        this.labelID.Name = 'labelID';
        this.labelID.TabIndex = 10;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = 'labelActionDate';
        this.labelActionDate.TabIndex = 6;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = '#F0F0F0';
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 5;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M15133", "Hasta Adı Soyadı");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 6;

        this.DrugDeliveryActionDetails = new TTVisual.TTGrid();
        this.DrugDeliveryActionDetails.Name = 'DrugDeliveryActionDetails';
        this.DrugDeliveryActionDetails.TabIndex = 35;
        this.DrugDeliveryActionDetails.AllowUserToAddRows = false;
        this.DrugDeliveryActionDetails.AllowUserToDeleteRows = false;
        this.DrugDeliveryActionDetails.Height = 400;

        this.DrugName = new TTVisual.TTTextBoxColumn();
        this.DrugName.DataMember = 'DrugName';
        this.DrugName.DisplayIndex = 0;
        this.DrugName.HeaderText = i18n("M16287", "İlaç");
        this.DrugName.Name = 'DrugName';
        this.DrugName.Width = 400;

        this.ResDose = new TTVisual.TTTextBoxColumn();
        this.ResDose.DataMember = 'ResDose';
        this.ResDose.DisplayIndex = 1;
        this.ResDose.HeaderText = i18n("M17084", "Kalan Miktar");
        this.ResDose.Name = 'ResDose';
        this.ResDose.Width = 90;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M15498", "Hastanın Üzerindeki İlaçlar");
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 10;

        this.DrugDeliveryActionDetailsColumns = [this.DrugName, this.ResDose];
        this.Controls = [this.tttextbox1, this.ID, this.labelID, this.labelActionDate, this.ActionDate, this.ttlabel1, this.DrugDeliveryActionDetails, this.DrugName, this.ResDose, this.ttlabel2];

    }


}
