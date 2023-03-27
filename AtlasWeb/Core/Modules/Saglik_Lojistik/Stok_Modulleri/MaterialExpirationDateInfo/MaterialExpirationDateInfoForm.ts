import { Component, OnInit, Input , Renderer2} from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { Stock} from 'NebulaClient/Model/AtlasClientModel';

import { MaterialExpirationDateInfoFormViewModel } from './MaterialExpirationDateInfoFormViewModel';
import { IModalService } from 'app/Fw/Services/IModalService';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';

@Component({
    selector: 'MaterialExpirationDateInfoForm',
    templateUrl: './MaterialExpirationDateInfoForm.html',
    providers: [MessageService, SystemApiService]
})

export class MaterialExpirationDateInfoForm extends TTUnboundForm implements OnInit {

    public MaterialExpirationDateInfoFormViewModel: MaterialExpirationDateInfoFormViewModel = new MaterialExpirationDateInfoFormViewModel();
    public MaterialList: Array<any> = new Array<any>();
    public Temporarylist: Array<Stock.GetCriticalStockLevelsNQL_Class>;
    public DayQueryNumber: number = 180;

    private MaterialExpirationDateInfoForm_DocumentUrl: string = '/api/MaterialExpirationDateInfoService/MaterialExpirationDateInfoForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, 
        public systemApiService: SystemApiService, private renderer: Renderer2, protected modalService: IModalService) {
        super('MaterialExpirationDateInfo', 'MaterialExpirationDateInfoForm');
        this.initViewModel();
    }

    public initViewModel(): void {
        this.MaterialExpirationDateInfoFormViewModel = new MaterialExpirationDateInfoFormViewModel();
    }

    async ngOnInit() {
        this.FillMaterialTreeForStock();
    }

	private _StoreObjectId: string;
    @Input() set StoreObjectId(object: string) {
        if (object != null && this._StoreObjectId != object) {
            this._StoreObjectId = object;
                this.GetMaterialListWithFilter();
        }
    }
    get StoreObjectId(): string {
        return this._StoreObjectId;
    }

	private _IsAutoFill: boolean;
    @Input() set IsAutoFill(object: boolean) {
        if (object != null && this._IsAutoFill != object) {
            this._IsAutoFill = object;
            if (this._IsAutoFill == true && this._StoreObjectId != null)
                this.GetMaterialListWithFilter();
        }
    }

    get IsAutoFill(): boolean {
        return this._IsAutoFill;
    }

    rowPrepared(row: any) {
        if (row.rowType == "data") {
            if (row.data.DayLife != null) {
                if (row.data.DayLife < 1) {
                    if(row.rowElement.firstItem() !== null && row.rowElement.firstItem() !== null)
                        this.renderer.setStyle(row.rowElement.firstItem(), "background-color", "#ff7d79");
                 }
            }
        }
    }
    public tempmat: any;
    async GetMaterialListWithFilter() {

        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/MaterialExpirationDateInfoService/getMaterialsInfoByExprationDate';
            let body = { 'StoreObjectId': this._StoreObjectId, 'DayQueryNumber': this.DayQueryNumber };
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.MaterialList = result;
                    this.onSelectedMaterialTreeChanged(this.tempmat);
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }
    onSelectedMaterialTreeChanged(data){
        if (data != null && data.value!=null) {
            this.Temporarylist=this.MaterialList.filter(x =>x.MaterialTree== data.value);
            this.tempmat = data;
        }
        else {
            this.Temporarylist = this.MaterialList;
            this.tempmat = data;
        }

    }
    public MaterialTreeForStock;
    async FillMaterialTreeForStock() {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/LogisticDashboard/FillMaterialTreeForStock';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.MaterialTreeForStock = result;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

    }

    onToolbarPreparing(e) {
        e.toolbarOptions.items.unshift({
            location: 'after',
            widget: 'dxButton',
            options: {
                icon: 'fa fa-file-text-o',
                onClick: this.printMaterialExpirationReport.bind(this)
            }
        });
    }

    public async printMaterialExpirationReport(): Promise<ModalActionResult> {
        var data = {
            StoreObjectId: this._StoreObjectId,
            DayQueryNumber: this.DayQueryNumber
        }
        let reportData: DynamicReportParameters = {

            Code: 'MATERIALEXPIRATIONREPORT',
            ReportParams: { StoreObjectId: data.StoreObjectId.toString(), DayQueryNumber: data.DayQueryNumber },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Miadı Dolan İlaç/Malzemeler RAPORU"

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