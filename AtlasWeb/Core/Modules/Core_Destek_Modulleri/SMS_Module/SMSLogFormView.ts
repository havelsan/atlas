import { Component, AfterViewInit } from "@angular/core";
import { MessageService } from "app/Fw/Services/MessageService";
import { NeHttpService } from "app/Fw/Services/NeHttpService";
import { SMSLogSearchModel } from "./SMSFormViewModel";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { SMSTypeEnum } from "./SMSTypeEnum";

@Component({
    selector: 'sms-log-form-view',
    templateUrl: './SMSLogFormView.html',
    providers: [MessageService]
})
export class SMSLogFormView implements AfterViewInit {

    public searchModel: SMSLogSearchModel;
    public SMSLogGridDataSource: DataSource;
    public rules: any;
    public SMSTypeDataSource = SMSTypeEnum.Items;
    
    public statusDataSource = [
        {
            Name: 'Başarılı',
            Value: 1
        },
        {
            Name: 'Başarısız',
            Value: 0
        },
    ];

    public logGridColumns = [
        {
            caption: 'Alıcı Adı',
            dataField: 'Recipientfirstname',
            width: 130
        },
        {
            caption: 'Alıcı Soyadı',
            dataField: 'Recipientsurname',
            width: 130
        },
        {
            caption: 'GSM No',
            dataField: 'PhoneNumber',
            width: 'auto'
        },
        {
            caption: 'Gönderim Durumu',
            dataField: 'Status',
            //width: 'auto'
        },
        {
            caption: 'SMS Metni',
            dataField: 'MessageText',
            //width: 'auto'
        },
        {
            caption: 'Gönderim Tarihi',
            dataField: 'LastUpdate',
            dataType: 'dateTime',
            format: 'dd.MM.yyyy HH:mm:ss'
            //width: 'auto'
        },
        {
            caption: 'Gönderen',
            dataField: 'Sendername',
            //width: 'auto'
        },
        {
            caption: 'Gönderen',
            dataField: 'SMSType',
            lookup: { dataSource: this.SMSTypeDataSource, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
            //width: 'auto'
        },
    ];

    constructor(private http: NeHttpService) {
        this.searchModel = new SMSLogSearchModel;
        this.rules = { "X": /[02-9]/ };
    }

    ngAfterViewInit(): void {
        let that = this;
        this.SMSLogGridDataSource = new DataSource({
            store: new CustomStore({
                //key: "ObjectID",
                load: async (loadOptions: any) => {
                    //if (Object.prototype.hasOwnProperty.call(loadOptions, 'select') == false) {

                    loadOptions.Params = {
                        SMSLogSearchModel: that.searchModel,
                    };

                    let res = await this.http.post<any>('/api/SMSFormApi/GetSMSLog', loadOptions);

                    return res;
                    // else
                    //     return new Promise<any>(resolve => {
                    //         let data = {
                    //             data: [],
                    //             groupCount: 0,
                    //             summary: [],
                    //             totalCount: 0
                    //         };
                    //         resolve(data)
                    //     });

                },
            }),
            paginate: true,
            pageSize: 50
        });
    }

    public onListClick() {
        this.SMSLogGridDataSource.reload();
    }

}