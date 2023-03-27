//$83EBEEEF
import { Component, Input } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ShowAuditFormViewModel, LogDataSource } from './AuditQueryFormViewModel';
import { AuditObject } from 'Fw/Services/IAuditObjectService';

@Component({
    selector: 'ShowAuditForm',
    templateUrl: './ShowAuditForm.html',
    providers: [MessageService]
})
export class ShowAuditForm {

    loadingVisible: boolean;
    @Input() Objects: Array<AuditObject>;

    public AuditColumns = [
        {
            'caption': i18n("M16821", "İşlem Adı"),
            dataField: 'OperationName',
            allowSorting: true
        },
        {
            'caption': 'Tarih',
            dataField: 'Date',
            dataType: 'date',
            format: 'dd/MM/yyyy hh:mm',
            allowSorting: true
        },
        {
            'caption': i18n("M11798", "Bilgisayar Ip"),
            dataField: 'PcIp',
            allowSorting: true
        },
        {
            'caption': i18n("M15739", "Hesap Adı"),
            dataField: 'AccountName',
            allowSorting: true
        },
        {
            'caption': 'İz Id',
            dataField: 'IzId',
            allowSorting: true
        }

    ];

    public AuditDetailsColumns = [
        {
            'caption': i18n("M10514", "Adı"),
            dataField: 'Caption',
            allowSorting: true
        },
        {
            'caption': i18n("M12524", "Eski Değer"),
            dataField: 'Value2',
            allowSorting: true
        },
        {
            'caption': i18n("M12524", "Yeni Değer"),
            dataField: 'Value',
            allowSorting: true
        }

    ];


    public ViewModel: ShowAuditFormViewModel = new ShowAuditFormViewModel();

    public setInputParam(value: any) {
        this.Objects = value;
        this.ViewModel.auditObjectIDs = this.Objects;
        let apiUrl: string = '/api/AuditQuery/ShowAuditsFormOpen';
        this.httpService.post(apiUrl, this.ViewModel).then(
            x => {
                this.ViewModel = x as ShowAuditFormViewModel;
                this.loadingVisible = false;
            }
        );

        /*let apiUrl_2: string = '/api/AuditQuery/GetObjectAuditRecords';
        this.httpService.post(apiUrl_2, this.ViewModel).then(
            x => {
                this.ViewModel = x as ShowAuditFormViewModel;
                this.loadingVisible = false;
            }
        );*/
    }

    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        this.loadingVisible = true;
        this.ViewModel.LogDataSource = new Array<LogDataSource>();
        //this.ObjectId = new Guid("059ea70c-1de7-478a-9f74-1f4fde31afad");
    }

    selectLog(data) {
        if (data.selectedRowsData.length > 0) {
            let apiUrl: string = '/api/AuditQuery/AuditQueryDetail?auditId=' + new Guid(data.selectedRowsData[0].AuditId);
            this.httpService.get<any>(apiUrl).then(
                x => {
                    this.ViewModel.LogDataSourceDetails = x;
                }

            );
        }
    }
    selectObject(data: any) {
        let apiUrl: string = '/api/AuditQuery/GetObjectAuditRecords?auditObjectID=' + new Guid(data.value);
        this.httpService.get<Array<LogDataSource>>(apiUrl).then(
            x => {
                this.ViewModel.LogDataSource = x as Array<LogDataSource>;
                this.loadingVisible = false;
            }
        );
    }
}
