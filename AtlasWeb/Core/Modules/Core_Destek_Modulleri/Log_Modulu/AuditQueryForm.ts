//$2FF395B1
import { Component } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { AuditQueryFormViewModel, AuditQueryFilter, LogDataSource } from './AuditQueryFormViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

@Component({
    selector: 'AuditQueryForm',
    templateUrl: './AuditQueryForm.html',
    providers: [MessageService]
})
export class AuditQueryForm {
    loadingVisible: boolean;
    public ViewModel: AuditQueryFormViewModel = new AuditQueryFormViewModel();
    public QueryModel: AuditQueryFilter = new AuditQueryFilter();



    public AuditColumns = [
        {
            'caption': i18n("M16821", "İşlem Adı"),
            dataField: 'OperationName',
            allowSorting: true
        },
        {
            'caption': i18n("M22843",  'Tarih'),
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
            'caption': 'Log Id',
            dataField: 'AuditId',
            allowSorting: true
        },
        {
            'caption': 'Object Id',
            dataField: 'ObjectID',
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




    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        this.loadingVisible = false;
        this.QueryModel.StartDate = new Date();
        this.QueryModel.EndDate = new Date();
        this.ViewModel.LogDataSource = new Array<LogDataSource>();
        let apiUrl: string = '/api/AuditQuery/AuditFormOpen';
        this.httpService.get(apiUrl).then(
            x => {
                this.ViewModel = x as AuditQueryFormViewModel;
            }

        );
    }
    query() {
        this.loadingVisible = true;
        let apiUrl: string = '/api/AuditQuery/AuditQuery';
        this.httpService.post<any>(apiUrl, this.QueryModel).then(
            x => {
                this.ViewModel.LogDataSource = x.LogDataSource;
                this.loadingVisible = false;
            }

        );

    }

    selectLog(data) {
        let apiUrl: string = '/api/AuditQuery/AuditQueryDetail?auditId=' + new Guid(data.selectedRowsData[0].AuditId);
        this.httpService.get<any>(apiUrl).then(
            x => {
                this.ViewModel.LogDataSourceDetails = x;
            }

        );
    }




}
