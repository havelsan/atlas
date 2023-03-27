//$6A4829A2
import { Component, OnInit, OnDestroy } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

import { EnumItem } from "NebulaClient/Mscorlib/EnumItem";
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { IModalService } from "Fw/Services/IModalService";
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { UploadedDocument, UTSNotificationType } from 'NebulaClient/Model/AtlasClientModel';
import { HttpClient } from "@angular/common/http";
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';

@Component({
    selector: 'UTSBatchNotificationForm',
    templateUrl: './UTSBatchNotificationForm.html',
    providers: [MessageService]
})
export class UTSBatchNotificationForm implements OnInit, OnDestroy, IModal {
    document: UploadedDocument = new UploadedDocument();
    docs: Array<UploadedDocument> = new Array<UploadedDocument>();
    totalSize: number = 0;
    Description: string;
    StartDate: Date;
    EndDate: Date;
    currentPage: number = 0;
    gridDataSource: Array<UTSBatchGridDataType> = new Array<UTSBatchGridDataType>();
    SelectedNotificationType: UTSNotificationType = 0;
    private _modalInfo: ModalInfo;
    constructor(private modalStateService: ModalStateService,
        private sideBarMenuService: ISidebarMenuService,
        protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private barcodePrintService: IBarcodePrintService,
        private http: HttpClient, private http2: AtlasHttpService) {


    }

    public activeGridColumns;
    public BildirimGridColumns = [
        {
            'caption': this.getColumnCaptionForNotifID(),
            dataField: this.getColumnDataFieldForNotif(),
            allowSorting: true,
        },
        {
            'caption': "Malzeme Adı",
            dataField: 'ProductName',
            allowSorting: true
        },
        {
            'caption': "Hasta TC Kimlik Numarası",
            dataField: 'PatientUniqueID',
            allowSorting: true
        },
        {
            'caption': "Hasta Adı",
            dataField: 'PatientName',
            allowSorting: true
        },
        {
            'caption': "Ürün Numarası",
            dataField: 'ProductNo',
            allowSorting: true
        },

        {
            'caption': "Gönderen Kurum Numarası",
            dataField: 'SendingOrganizationNo',
            allowSorting: true
        },
        {
            'caption': "Eşsiz Kimlik",
            dataField: 'UniqueDeviceIdentifier',
            allowSorting: true
        },
        {
            'caption': "Lot/Batch Numarası",
            dataField: 'LotNumber',
            allowSorting: true
        },
        {
            'caption': "Seri/Sıra Numarası",
            dataField: 'SerialNumber',
            allowSorting: true
        },
        {
            'caption': "Bildirim Durumu",
            dataField: 'NotificationStatus',
            allowSorting: true
        }


    ];

    public getColumnDataFieldForNotif(){
        if (this.notificationType == UTSNotificationType.AlmaNotification)
            return 'DeliveryNotifID';
        else if (this.notificationType == UTSNotificationType.KullanmaIptalNotification)
            return 'UsageNotifID';
        else
            return 'ReceiveNotifID';
    }

    public getColumnCaptionForNotifID(){
        if (this.notificationType == UTSNotificationType.AlmaNotification)
            return "Verme Bildirim ID";
        else if (this.notificationType == UTSNotificationType.KullanmaIptalNotification)
            return "Kullanma Bildirim ID";
        else
            return "Alma Bildirim ID";
    }

    public get notificationTypes(): Array<EnumItem> {
        return UTSNotificationType.Items;
    }

    async ngOnInit() {
        this.listNotifications();
    }

    notificationType: any = UTSNotificationType.AlmaNotification;
    isAlmaNotification: boolean = true;
    UTSNotificationTypeChanged(data) {
        let that = this;
        this.notificationType = data.selectedItem.code;
        if (this.notificationType == UTSNotificationType.AlmaNotification)
            this.isAlmaNotification = true;
        else
            this.isAlmaNotification = false;
    }

    public listNotifications() {
        let param: GetGridDataInput = new GetGridDataInput();
        let apiUrl: string = "";
        param.sayfaNo = 0;
        param.startDate = this.StartDate;
        param.endDate = this.EndDate;
        if (this.notificationType == UTSNotificationType.AlmaNotification) {
            this.activeGridColumns = this.BildirimGridColumns; //TODO
            apiUrl = '/api/UTSIslemleriService/GetAlmaGridData';
        }
        else if (this.notificationType == UTSNotificationType.VermeNotification || this.notificationType == UTSNotificationType.KullanmaNotification) {
            this.activeGridColumns = this.BildirimGridColumns;
            apiUrl = '/api/UTSIslemleriService/GetVermeAndKullanimGridData';
        }
        else if (this.notificationType == UTSNotificationType.KullanmaIptalNotification) {
            this.activeGridColumns = this.BildirimGridColumns;
            apiUrl = '/api/UTSIslemleriService/GetKullanimIptalGridData';
        }

        this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.gridDataSource.push(x);
            }
        );
    }

    onStartDateChanged(){

    }

    onEndDateChanged(){

    }

    public setInputParam(value: Episode) {
        this.document.Episode = value;
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    onChange($event) {

    }

    public ngOnDestroy(): void {

    }


}
export class UTSBatchGridDataType {
    DeliveryNotifID: string;
    ReceiveNotifID: string;
    UsageNotifID: string;
    ProductName: string;
    ProductNo: string;
    SendingOrganizationNo: string; //Gönderen Kurum Kodu
    UniqueDeviceIdentifier: string; //Eşsiz Kimlik
    LotNumber: string; // Lot/Batch Numarası
    SerialNumber: string; // Seri Numarası
    PatientUniqueID: string;
    PatientName: string;
    NotificationStatus: string; //Bildirim Durumu
}

export class GetGridDataInput {
    public sayfaNo: number;
    public startDate: Date;
    public endDate: Date;
}

export class MakeNotificationInput {
    public DeliveryNotifID: string;
    public Amount: number;
    public NotificationInfo: UTSBatchGridDataType;
}

export class MakeUsageNotificationInput {
    public ReceiveNotifID: string;
    public Amount: number;
    public NotificationInfo: UTSBatchGridDataType;
    public PatientID: Guid;
}

