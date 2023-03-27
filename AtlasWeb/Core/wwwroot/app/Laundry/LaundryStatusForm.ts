//$B031EBC6
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';

import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { LaundryStatusFormViewModel, LinenGroupModel, LinenLocationModel, LinenTypeModel, LaundryStatusResultModel } from './LaundryViewModel'
import { Guid } from '../NebulaClient/Mscorlib/Guid';
@Component({
    selector: "laundry-status-form",
    templateUrl: './LaundryStatusForm.html'
})
export class LaundryStatusForm implements OnInit {

    public apiAddress: string = '/api/LaundryApi/';
    public laundryStatusFormViewModel: LaundryStatusFormViewModel = new LaundryStatusFormViewModel();
    public LinenGroupDataSource: Array<LinenGroupModel>;
    public LinenLocationDataSource: Array<LinenLocationModel>;
    public LinenTypeDataSource: Array<LinenTypeModel>;
    public LaundryStatusColumns;

    GenerateLaundryStatusColumns() {
        let that = this;
        this.LaundryStatusColumns = [
            {
                caption: 'Çamaşır Tipi',
                dataField: 'Type',
                lookup: { dataSource: that.LinenTypeDataSource, valueExpr: 'ObjectID', displayExpr: 'Type' },
                width: '20%'
            },
            {
                caption: 'Çamaşır Grubu',
                dataField: 'Group',
                lookup: { dataSource: that.LinenGroupDataSource, valueExpr: 'ObjectID', displayExpr: 'Name' },
                width: '20%'
            },
            {
                caption: 'Konumu',
                dataField: 'Location',
                lookup: { dataSource: that.LinenLocationDataSource, valueExpr: 'ObjectID', displayExpr: 'Location' },
                width: '20%'
            },
            {
                caption: 'Toplam Adet',
                dataField: 'TotalCount',
                width: '10%'
            }, {
                caption: 'Kullanımda Olanlar',
                dataField: 'UsedCount',
                width: '10%'
            }
            , {
                caption: 'Miadı Dolanlar',
                dataField: 'ExpiredCount',
                width: '10%'
            }
            //, {
            //    caption: 'Maksimum Yıkamayı Geçenler',
            //    dataField: 'ExceededMWC',
            //    width: '10%'
            //} 
        ];
    }

    
     

    

    constructor(protected http: NeHttpService) {
         
    }
  

  

    ngOnInit() {
        this.loadLinenGroupDataSource();
        this.loadLinenLocationDataSource();
        this.loadLinenTypeDataSource();
        this.GenerateLaundryStatusColumns();
    }


    SearchLaundryStatus(): void {
        this.http.post<Array<LaundryStatusResultModel>>(this.apiAddress + "SearchLaundryStatus", this.laundryStatusFormViewModel.Query).
            then(result => {
                this.laundryStatusFormViewModel.Result = result;
                this.GenerateLaundryStatusColumns();
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
        });
    }

    async loadLinenGroupDataSource(): Promise<void> {
        this.http.get<Array<LinenGroupModel>>(this.apiAddress + "GetAllLinenGroups").then(result => {
            this.LinenGroupDataSource  = result;
            return;
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
        });
    }
    async loadLinenLocationDataSource(): Promise<void> {
        this.http.get<Array<LinenLocationModel>>(this.apiAddress + "GetAllLinenLocations").then(result => {
            this.LinenLocationDataSource = result;
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
        });
    }
    async loadLinenTypeDataSource(): Promise<void> {
        this.http.get<Array<LinenTypeModel>>(this.apiAddress + "GetAllLinenTypes").then(result => {
            this.LinenTypeDataSource = result;
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
        });
    }
}