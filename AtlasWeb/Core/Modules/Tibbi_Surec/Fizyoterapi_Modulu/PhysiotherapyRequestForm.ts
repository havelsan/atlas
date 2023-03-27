//$30AA0F90
import { Component, OnInit, NgZone } from '@angular/core';
import { PhysiotherapyRequestFormViewModel } from './PhysiotherapyRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PhysiotherapyRequest } from 'NebulaClient/Model/AtlasClientModel';


import { PhysiotherapyOrderComponentInfoViewModel } from './PhysiotherapyOrderRequestFormViewModel';

import { PhysiotherapyOrderRequestForm } from './PhysiotherapyOrderRequestForm';

//<atlas-form-editor  i�in
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
//
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

//Raporlar için
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';

import { ModalStateService } from "Fw/Models/ModalInfo";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';


@Component({
    selector: 'PhysiotherapyRequestForm',
    templateUrl: './PhysiotherapyRequestForm.html',
    providers: [MessageService, NqlQueryService]
})
export class PhysiotherapyRequestForm extends TTVisual.TTForm implements OnInit {
    labelProtocolNo: TTVisual.ITTLabel;
    ProtocolNo: TTVisual.ITTTextBox;
    public physiotherapyRequestFormViewModel: PhysiotherapyRequestFormViewModel = new PhysiotherapyRequestFormViewModel();
    public get _PhysiotherapyRequest(): PhysiotherapyRequest {
        return this._TTObject as PhysiotherapyRequest;
    }
    private PhysiotherapyRequestForm_DocumentUrl: string = '/api/PhysiotherapyRequestService/PhysiotherapyRequestForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        private modalStateService: ModalStateService,
        protected ngZone: NgZone) {
        super('PHYSIOTHERAPYREQUEST', 'PhysiotherapyRequestForm');
        this._DocumentServiceUrl = this.PhysiotherapyRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public saveOrders: boolean = false;

    protected async save() {
        this.saveOrders = true;
        await super.save();
        this.saveOrders = false;
    }

    private txtVal: boolean = true;
    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo): Promise<void> {
        await super.setState(transDef, saveInfo);
        if (transDef != null && transDef.ToStateDefID.toString() == PhysiotherapyRequest.PhysiotherapyRequestStates.RequestAcception.toString()) {
            this.printPhysiotherapyRequestReport();
            this.modalStateService.callActionExecuted(DialogResult.OK, this.physiotherapyRequestFormViewModel._PhysiotherapyRequest.ObjectID, this.txtVal, true, false);
        }
    }

    protected async PreScript() {
        super.PreScript();

        let componentInfoViewModel: PhysiotherapyOrderComponentInfoViewModel;
        componentInfoViewModel = PhysiotherapyOrderRequestForm.getComponentInfoViewModel(this.physiotherapyRequestFormViewModel._PhysiotherapyRequest);
        this.physiotherapyOrderQueryParameters = componentInfoViewModel.physiotherapyOrderQueryParameters;
        this.physiotherapyOrderComponentInfo = componentInfoViewModel.physiotherapyOrderComponentInfo;
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

        this.refreshDynamicComponent();
    }

    public physiotherapyOrderComponentInfo: DynamicComponentInfo;
    public physiotherapyOrderQueryParameters: QueryParams;

    physiotherapyOrderQueryResultLoaded(e: any) {
        PhysiotherapyOrderRequestForm.physiotherapyOrderQueryResultLoaded(e);
    }

    //Rapor Yazdırma

    public printPhysiotherapyRequestReport() {
        const objectIdParam = new GuidParam(this.physiotherapyRequestFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('PhysiotherapyRequestReport', reportParameters);
    }


    // Grid row Güncelleme
    async onRowUpdating(value: any): Promise<void> {
        let that = this;
        let urlString: string = '/api/PhysiotherapyRequestService/PhysiotherapyOrderChanged?SessionCount=' + value.newData.SessionCount + '&Duration=' + value.newData.Duration + '&Dose=' + (value.newData.Dose != null ? value.newData.Dose : "") + '&ObjectID=' + value.oldData.OrderObjectId + '&ObjectDef=' + value.oldData.OrderObjectDefId;
        that.httpService.get<any>(urlString)
            .then(response => {
                this.refreshDynamicComponent();
                this.messageService.showSuccess("İşlem Başarılı Bir Şekilde Güncellendi");
            })
            .catch(error => {
                console.log(error);
            });
    }

    // Grid row Silme
    async onRowDeleting(value: any): Promise<void> {
        let that = this;
        let urlString: string = '/api/PhysiotherapyRequestService/PhysiotherapyOrderDeleted?ObjectID=' + value.data.OrderObjectId + '&ObjectDef=' + value.data.OrderObjectDefId;
        that.httpService.get<any>(urlString)
            .then(response => {
                this.refreshDynamicComponent();
                this.messageService.showSuccess("İşlem Başarılı Bir Şekilde Silindi");
            })
            .catch(error => {
                console.log(error);
            });
    }

    //Ekran Refresh İşlemleri için input
    public setInputParam(value: boolean) {
        if (value != null && value['isFTRworkList'] != null) {
            this._isFTRworkList = value['isFTRworkList']; // İş listesinden açıldığı zaman saydayı refresh yapabilemk için
        }

        if (value != null && value['openDinamicComp'] != null && typeof value['openDinamicComp'] === 'function') {
            //this.hasDinamicCompFunc = true;
            this.openDinamicCompFunc = value['openDinamicComp'];
        }
    }

    //Ekran Refresh İşlemleri
    public openDinamicCompFunc: Function;
    private _isFTRworkList: boolean = false;
    refreshDynamicComponent() {
        //if (this.openDinamicCompFunc != null) {
        //    this.openDinamicCompFunc(this.physiotherapyRequestFormViewModel._PhysiotherapyRequest.ObjectID, "PHYSIOTHERAPYREQUEST", null);
        //}
        //else if (this._isFTRworkList == true) {
        //    this.httpService.episodeActionWorkListSharedService.refreshWorklist(true);
        //}
        //else {
        //    this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PHYSIOTHERAPYREQUEST", this.physiotherapyRequestFormViewModel._PhysiotherapyRequest.ObjectID, null);
        //}
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PhysiotherapyRequest();
        this.physiotherapyRequestFormViewModel = new PhysiotherapyRequestFormViewModel();
        this._ViewModel = this.physiotherapyRequestFormViewModel;
        this.physiotherapyRequestFormViewModel._PhysiotherapyRequest = this._TTObject as PhysiotherapyRequest;
    }

    protected loadViewModel() {
        let that = this;

        that.physiotherapyRequestFormViewModel = this._ViewModel as PhysiotherapyRequestFormViewModel;
        that._TTObject = this.physiotherapyRequestFormViewModel._PhysiotherapyRequest;
        if (this.physiotherapyRequestFormViewModel == null)
            this.physiotherapyRequestFormViewModel = new PhysiotherapyRequestFormViewModel();
        if (this.physiotherapyRequestFormViewModel._PhysiotherapyRequest == null)
            this.physiotherapyRequestFormViewModel._PhysiotherapyRequest = new PhysiotherapyRequest();

    }

    async ngOnInit() {
        let that = this;
        await this.load(PhysiotherapyRequestFormViewModel);
  
    }


    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyRequest != null && this._PhysiotherapyRequest.ProtocolNo != event) {
                this._PhysiotherapyRequest.ProtocolNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
    }

    public initFormControls(): void {
        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 9;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 8;

        this.Controls = [this.labelProtocolNo, this.ProtocolNo];

    }


}
