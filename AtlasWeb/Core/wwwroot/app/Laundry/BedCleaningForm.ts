//$B031EBC6
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { BedCleaningFormViewModel, BedCleaningFormResultModel } from './LaundryViewModel'
//import { Guid } from '../NebulaClient/Mscorlib/Guid';

@Component({
    selector: "bed-cleaning-form",
    templateUrl: './BedCleaningForm.html'
})
export class BedCleaningForm implements OnInit {

    public apiAddress: string = '/api/LaundryApi/';
    public bedCleaningFormViewModel: BedCleaningFormViewModel = new BedCleaningFormViewModel();
    public selectedBeds: Array<BedCleaningFormResultModel> = [];
    public bedStatus = [
        {
            Name: "Hepsi",
            ObjectID: 0
        },
        {
            Name: "Temiz",
            ObjectID: 1
        },
        {
            Name: "Kirli",
            ObjectID: 2
        }
    ];

    public BedColumns;
    GenerateBedColumns() {
        let that = this;
        this.BedColumns = [
            {
                caption: 'Birim',
                dataField: 'ResSection',
                width: '25%'
            }, {
                caption: 'Oda Grubu',
                dataField: 'RoomGroup',
                width: '20%'
            },
            {
                caption: 'Oda',
                dataField: 'Room',
                width: '25%'
            },
            {
                caption: 'Yatak',
                dataField: 'Bed',
                width: '20%'
            },
            {
                caption: 'Temiz',
                dataField: 'IsClean',
                dataType: 'boolean',
                width: '10%'
            } 
        ];
    }

    onContextMenuPreparingBedList(e: any): void {
        let that = this;
        let IsClean = false;
        let tempST: Array<BedCleaningFormResultModel> = [];

        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data') {


                if (that.selectedBeds.length === 0)//Hiç seçili yoksa sağ klik yaptığımız satırı işleme alsın diye eklendi.
                    tempST.push(e.row.data);
                else
                    tempST = that.selectedBeds;

                e.items = [{
                    text: "Temiz Olarak İşaretle",
                    //disabled: IsClean,
                    onItemClick: function () {
                        that.SetCleaningStatus(tempST, 1);
                    }
                },
                {
                    text: "Kirli Olarak İşaretle",
                    //disabled: !IsClean,
                    onItemClick: function () {
                        that.SetCleaningStatus(tempST, 2);
                    }
                }];
            }
        }
    }

    SetCleaningStatus(tempBeds: Array<BedCleaningFormResultModel>, type: number) {
        let Scs: any = {};

        Scs.Beds = tempBeds;
        Scs.Type = type;

        this.http.post<boolean>(this.apiAddress + "SetCleaningStatus", Scs).
            then(result => {
                if (type == 1)
                    ServiceLocator.MessageService.showSuccess("Seçili yataklar temiz olarak işaretlendi.");
                else
                    ServiceLocator.MessageService.showSuccess("Seçili yataklar kirli olarak işaretlendi.");
                if (result)
                    this.SearchBedWithStatus();
            }).catch(error => {
                //this.errorHandlerForDPTermOperation(error);
            });
    }

    constructor(protected http: NeHttpService) {
         
    }
  
    ngOnInit() {
        this.GenerateBedColumns();
    }

    SearchBedWithStatus(): void {
        this.http.get<Array<BedCleaningFormResultModel>>(this.apiAddress + "SearchBedWithStatus?QueryBedStatus="+ this.bedCleaningFormViewModel.QueryBedStatus).
            then(result => {
                this.bedCleaningFormViewModel.Result = result;
                this.GenerateBedColumns();
        }).catch(error => {
            //this.errorHandlerForDPTermOperation(error);
        });
    }
     
}