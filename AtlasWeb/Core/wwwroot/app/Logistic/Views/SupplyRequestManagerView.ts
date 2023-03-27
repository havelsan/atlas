//$306AD69A
import { Component, Renderer2 } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { SupplyRequestManagerViewModel, QueryInput, SupplyRequestStatus, SupplyRequestStatusFastSoft} from '../Models/SupplyRequestManagerViewModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { UserHelper } from 'app/Helper/UserHelper';
import { MainStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { IModalService } from 'Fw/Services/IModalService';
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { SystemParameterService } from 'ObjectClassService/SystemParameterService';

@Component({
    selector: 'hvl-logistic-supplyRequestManager-view',
    inputs: ['Model'],
    templateUrl: './SupplyRequestManagerView.html'
})

export class SupplyRequestManagerView extends BaseComponent<SupplyRequestManagerViewModel> {

    constructor(container: ServiceContainer, private http: NeHttpService, protected messageService: MessageService, private modalService: IModalService, private renderer: Renderer2) {
        super(container);

    }
    public startDate: Date = new Date();
    public endDate: Date = new Date();
    public storeObjectID: Guid;
    public showLoadPanel = false;
    public LoadPanelMessage: string = 'Kayıtlar Yükleniyor, Lütfen Bekleyiniz.';
    public selecttableStores: Array<MainStoreDefinition> = new Array<MainStoreDefinition>();
    public dataStockActionSource: Array<SupplyRequestStatus> = new Array<SupplyRequestStatus>();
    public dataStockActionSourceFastSoft: Array<SupplyRequestStatusFastSoft> = new Array<SupplyRequestStatusFastSoft>();
    public isPurchaseEServiceFastsoft: boolean = false;

    async clientPreScript() {
        this.selecttableStores = await UserHelper.UseMainStoreResources;
        let PurchaseEServiceName: string = (await SystemParameterService.GetParameterValue('PURCHASESERVICENAME', ''));
        if (PurchaseEServiceName == 'FASTSOFT') {
            this.isPurchaseEServiceFastsoft = true;
        }
    }
    clientPostScript() {

    }
    SelectBoxChange(data: any) {
        this.storeObjectID = data.itemData.ObjectID;
    }

    public buttonText = i18n("M21339", "Satın Almaya Çıkmış İşler");
    public loadIndicatorVisible: boolean;
    async GetSupplyRequest(data) {
        let inputItem = new QueryInput;
        inputItem.storeObjID = this.storeObjectID;
        inputItem.endDate = this.endDate;
        inputItem.startDate = this.startDate;
        this.loadIndicatorVisible = true;
        this.buttonText = i18n("M14773", "Getiriliyor..");
        await this.getXXXXXXResult(inputItem);
        this.loadIndicatorVisible = false;
    }

    rowPrepared(row: any) {
        if (row.rowType == "data" && row.data.Status === 'Tamamlandı')
            if (row.rowElement.firstItem() !== null && row.rowElement.firstItem() !== null)
                this.renderer.setStyle(row.rowElement.firstItem(), "background-color", "#ff7d79");
    }

    async getXXXXXXResult(input: QueryInput) {
        let inputDvo = new QueryInput;
        inputDvo.startDate = input.startDate;
        inputDvo.endDate = input.endDate;
        inputDvo.storeObjID = input.storeObjID;
        let that = this;
        let PurchaseEServiceName: string = (await SystemParameterService.GetParameterValue('PURCHASESERVICENAME', ''));
        if (PurchaseEServiceName == 'XXXXXX') {
            this.isPurchaseEServiceFastsoft = false;
            let fullApiUrl: string = 'api/SupplyRequestManager/GetStatusPurchese';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <SupplyRequestManagerViewModel>res;
                    that.Model = result;
                    if (that.Model && that.Model.SupplyRequestStatusList) {
                        that.dataStockActionSource = that.Model.SupplyRequestStatusList;
                        this.buttonText = i18n("M21339", "Satın Almaya Çıkmış İşler");
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.buttonText = i18n("M21339", "Satın Almaya Çıkmış İşler");
                });
        }
        else if (PurchaseEServiceName == 'FASTSOFT') {
            this.isPurchaseEServiceFastsoft = true;
            this.showLoadPanel = true;
            let fullApiUrl: string = 'api/SupplyRequestManager/GetStatusPurcheseFastSoft';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <SupplyRequestManagerViewModel>res;
                    that.Model = result;
                    if (that.Model && that.Model.SupplyRequestStatusFastSoftList) {
                        that.dataStockActionSourceFastSoft = that.Model.SupplyRequestStatusFastSoftList;
                        this.buttonText = i18n("M21339", "Satın Almaya Çıkmış İşler");
                        this.showLoadPanel = false;
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.buttonText = i18n("M21339", "Satın Almaya Çıkmış İşler");
                    this.showLoadPanel = false;
                });
        }
        else {
            TTVisual.InfoBox.Alert(" PURCHASESERVICENAME parametresini kontrol ediniz!");
        }
    }
}