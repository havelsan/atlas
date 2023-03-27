//$E01030E5
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PanicAlertFormViewModel } from './PanicAlertFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PathologyPanicAlert } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyPanicReasonDef } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { IModalService } from 'Fw/Services/IModalService';


@Component({
    selector: 'PanicAlertForm',
    templateUrl: './PanicAlertForm.html',
    providers: [MessageService]
})
export class PanicAlertForm extends TTVisual.TTForm implements OnInit, IModal {
    labelPanicAlertDate: TTVisual.ITTLabel;
    labelPathologyPanicReason: TTVisual.ITTLabel;
    PanicAlertDate: TTVisual.ITTDateTimePicker;
    PathologyPanicReason: TTVisual.ITTObjectListBox;
    public statesPanelClass: string = "col-lg-6";
    public _buttonCaption: string = "Rapor";
    public _buttonIcon: string = "fa fa-print";

    public panicAlertFormViewModel: PanicAlertFormViewModel = new PanicAlertFormViewModel();
    public get _PathologyPanicAlert(): PathologyPanicAlert {
        return this._TTObject as PathologyPanicAlert;
    }
    private PanicAlertForm_DocumentUrl: string = '/api/PathologyPanicAlertService/PanicAlertForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService) {
        super('PATHOLOGYPANICALERT', 'PanicAlertForm');
        this._DocumentServiceUrl = this.PanicAlertForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PathologyPanicAlert();
        this.panicAlertFormViewModel = new PanicAlertFormViewModel();
        this._ViewModel = this.panicAlertFormViewModel;
        this.panicAlertFormViewModel._PathologyPanicAlert = this._TTObject as PathologyPanicAlert;
        this.panicAlertFormViewModel._PathologyPanicAlert.PathologyPanicReason = new PathologyPanicReasonDef();
    }

    protected loadViewModel() {
        let that = this;
        that.panicAlertFormViewModel = this._ViewModel as PanicAlertFormViewModel;
        that._TTObject = this.panicAlertFormViewModel._PathologyPanicAlert;
        if (this.panicAlertFormViewModel == null)
            this.panicAlertFormViewModel = new PanicAlertFormViewModel();
        if (this.panicAlertFormViewModel._PathologyPanicAlert == null)
            this.panicAlertFormViewModel._PathologyPanicAlert = new PathologyPanicAlert();
        let pathologyPanicReasonObjectID = that.panicAlertFormViewModel._PathologyPanicAlert["PathologyPanicReason"];
        if (pathologyPanicReasonObjectID != null && (typeof pathologyPanicReasonObjectID === "string")) {
            let pathologyPanicReason = that.panicAlertFormViewModel.PathologyPanicReasonDefs.find(o => o.ObjectID.toString() === pathologyPanicReasonObjectID.toString());
            if (pathologyPanicReason) {
                that.panicAlertFormViewModel._PathologyPanicAlert.PathologyPanicReason = pathologyPanicReason;
            }
        }

    }



    async ngOnInit() {
        await this.load(PanicAlertFormViewModel);
    }

    public onPanicAlertDateChanged(event): void {

        if (event != null) {
            if (this._PathologyPanicAlert != null && this._PathologyPanicAlert.PanicAlertDate != event) {
                this._PathologyPanicAlert.PanicAlertDate = event;
            }
        }
    }

    public onPathologyPanicReasonChanged(event): void {
        if (event != null) {
            if (this._PathologyPanicAlert != null && this._PathologyPanicAlert.PathologyPanicReason != event) {
                this._PathologyPanicAlert.PathologyPanicReason = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.PanicAlertDate, "Value", this.__ttObject, "PanicAlertDate");
    }

    public initFormControls(): void {
        this.labelPathologyPanicReason = new TTVisual.TTLabel();
        this.labelPathologyPanicReason.Text = "Panik Bildirim Sebebi";
        this.labelPathologyPanicReason.Name = "labelPathologyPanicReason";
        this.labelPathologyPanicReason.TabIndex = 3;

        this.PathologyPanicReason = new TTVisual.TTObjectListBox();
        this.PathologyPanicReason.ListDefName = "PathologyPanicListDef";
        this.PathologyPanicReason.Name = "PathologyPanicReason";
        this.PathologyPanicReason.TabIndex = 2;

        this.labelPanicAlertDate = new TTVisual.TTLabel();
        this.labelPanicAlertDate.Text = "Panik Bildirim Tarihi";
        this.labelPanicAlertDate.Name = "labelPanicAlertDate";
        this.labelPanicAlertDate.TabIndex = 1;

        this.PanicAlertDate = new TTVisual.TTDateTimePicker();
        this.PanicAlertDate.Format = DateTimePickerFormat.Long;
        this.PanicAlertDate.Name = "PanicAlertDate";
        this.PanicAlertDate.TabIndex = 0;

        this.Controls = [this.labelPathologyPanicReason, this.PathologyPanicReason, this.labelPanicAlertDate, this.PanicAlertDate];

    }

    public setInputParam(value: any) {
        if (value != "")
            this.ObjectID = value as Guid;

    }
    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    protected AfterContextSavedScript(transDef: TTObjectStateTransitionDef): void {
        this.printPanicAlertForm();
    }


    printPanicAlertForm() {

        let reportData: DynamicReportParameters = {

            Code: 'PATOLOJIPANIKBILDIRIMFORMU',
            ReportParams: { ObjectID: this.panicAlertFormViewModel._PathologyPanicAlert.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Patoloji Panik Bildirim Formu"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }
}
