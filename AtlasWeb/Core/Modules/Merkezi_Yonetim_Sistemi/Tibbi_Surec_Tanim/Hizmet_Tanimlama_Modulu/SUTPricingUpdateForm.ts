import { Component, OnInit, Input, AfterViewInit, ViewChild, Output, EventEmitter } from "@angular/core";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { PricingListDefinition, PricingListGroupDefinition, CurrencyTypeDefinition } from "app/NebulaClient/Model/AtlasClientModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DxDataGridComponent } from "devextreme-angular";
import { ShowBox } from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ShowBoxTypeEnum } from "app/NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { Type } from "app/NebulaClient/ClassTransformer";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";

@Component({
    selector: 'sut-pricing-update-form',
    templateUrl: './SUTPricingUpdateForm.html',
    providers: [MessageService, SystemApiService]
})
export class SUTPricingUpdateForm implements OnInit, AfterViewInit {

    public SutPriceColumns = [
        {
            caption: 'Var/Yok',
            dataField: 'IsExistText',
            width: 80
        },
        {
            caption: 'SUT Kodu',
            dataField: 'sutKodu'
        },
        {
            caption: 'Hizmet Adı',
            dataField: 'adi',
            width: 200
        },
        {
            caption: 'HBYS Fiyatı',
            dataField: 'eskiFiyat',
            width: 100
        },
        {
            caption: 'Yeni Fiyat',
            dataField: 'fiyat',
            width: 100
        },
        {
            caption: 'Hizmet Türü ',
            dataField: 'turAdi'
        },
        {
            caption: 'Hizmet Sut Eki ',
            dataField: 'listeAdi'
        },
    ];

    public SutPriceDataSource: Array<any>;
    public SelectedSUTPriceList: Array<any>;
    public SelectedDate: Date;
    public StartDate?: Date = null;
    public showLoadPanel = false;

    /**
     *
     */
    constructor(private http: NeHttpService) {

    }

    ngAfterViewInit(): void {

    }

    ngOnInit(): void {

    }

    public ListPrices() {
        let that = this;
        let input = {
            InputDate: that.SelectedDate
        };
        this.showLoadPanel = true;
        this.http.post<Array<any>>('api/ProcedureDefinitionService/GetChangedSUTPrice', input).then(res => {
            this.SutPriceDataSource = res;
            this.showLoadPanel = false;
            if (res != null && res.length > 0)
                ServiceLocator.MessageService.showInfo('Fiyatı farklı veya tanımlı olmayan hizmetler mevcut.');
            else
                ServiceLocator.MessageService.showSuccess('Farklı fiyata sahip ya da mevcut olmayan bir hizmet bulunamamıştır.');
        }).catch(err => {
            ServiceLocator.MessageService.showError(err);
            this.showLoadPanel = false;
        });
    }

    public onSutPriceRowPrepared(event: any) {
        if (event.rowType === 'data' && event.data && event.data.IsExists == false) {
            event.rowElement.firstItem().cells[1].bgColor = 'red'
        }
    }

    public async UpdatePrices() {
        let that = this;
        if (that.SelectedSUTPriceList != null && that.SelectedSUTPriceList.length > 0 && that.SelectedSUTPriceList.filter(x => x.IsExists === true).length > 0) {
            let existsCount = that.SelectedSUTPriceList.filter(x => x.IsExists === true).length;
            if (that.StartDate != null) {
                let input = {
                    UpdateList: that.SelectedSUTPriceList.filter(x => x.IsExists === true),
                    StartDate: that.StartDate
                }
                that.showLoadPanel = true;
                let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', '' + existsCount + ' adet hizmetin fiyatı güncellenecektir. Emin misiniz?');
                if (result === "OK") {
                    that.http.post<boolean>('api/ProcedureDefinitionService/UpdateSUTPrices', input).then(res => {
                        that.showLoadPanel = false;
                        that.ListPrices();
                        ServiceLocator.MessageService.showSuccess('Fiyatlar başarılı bir şekilde güncellenmiştir.');
                    }).catch(err => {
                        ServiceLocator.MessageService.showError(err);
                        that.showLoadPanel = false;
                    });
                }
            }
            else
                ServiceLocator.MessageService.showError("Lütfen Yeni Fiyat Başlangıç Tarihi alanını doldurunuz.");
        }
        else
            ServiceLocator.MessageService.showError("Güncellenecek fiyat yoktur.");
    }

    public async UpdateSUT() {
        let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', 'SUT Listesini güncellemek istediğinize emin misiniz?');
        if (result === "OK") {
            this.showLoadPanel = true;
            this.http.post<Array<any>>('api/ProcedureDefinitionService/UpdateSUT', null).then(res => {
                this.showLoadPanel = false;
                ServiceLocator.MessageService.showSuccess('Hizmetler başarılı bir şekilde güncellenmiştir.');
            }).catch(err => {
                this.showLoadPanel = false;
                ServiceLocator.MessageService.showError(err);
            });
        }
    }
}