//$B031EBC6
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DoctorPerformanceTermModel, DoctorPerformanceTermOperationViewModel, DoctorPerformanceTermStatesString, LookupColumn, DpKatsayiRaporModel } from './DoctorPerformanceViewModel';
import { DoctorPerformanceTerm } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

@Component({
    selector: "dp-term-operation",
    templateUrl: './DoctorPerformanceTermOperation.html'
})
export class DoctorPerformanceTermOperation implements OnInit {
    public doctorPerformanceTermOperationViewModel: DoctorPerformanceTermOperationViewModel;
    public dptStatesArray: Array<LookupColumn> = new Array<LookupColumn>();
    DPTermColumns = [];

    constructor(protected http: NeHttpService) {
        this.doctorPerformanceTermOperationViewModel = new DoctorPerformanceTermOperationViewModel();
    }

    ngOnInit() {
        this.dptStatesArray.push(new LookupColumn(DoctorPerformanceTerm.DoctorPerformanceTermStates.Open.toString(), DoctorPerformanceTermStatesString.Open,""));
        this.dptStatesArray.push(new LookupColumn(DoctorPerformanceTerm.DoctorPerformanceTermStates.Close.toString(), DoctorPerformanceTermStatesString.Close,""));
        this.dptStatesArray.push(new LookupColumn(DoctorPerformanceTerm.DoctorPerformanceTermStates.Cancelled.toString(), DoctorPerformanceTermStatesString.Cancelled,""));
        this.dptStatesArray.push(new LookupColumn(DoctorPerformanceTerm.DoctorPerformanceTermStates.Approved.toString(), DoctorPerformanceTermStatesString.Approved, ""));
        this.generateTermColumns();
        this.loadTermListDataSource();
    }

    loadTermListDataSource(): void {
        this.http.get<Array<DoctorPerformanceTermModel>>("api/DoctorPerformanceApi/GetAllDoctorPerformanceTerm").then(result => {
            this.doctorPerformanceTermOperationViewModel.TermList = result;
        }).catch(error => {
            this.errorHandlerForDPTermOperation(error);
        });
    }

    generateTermColumns(): void {
        let that = this;
        this.DPTermColumns = [
            {
                caption: 'Dönem Adı',
                dataField: 'Name',
                dataType: 'string',
                width: '120',
                allowEditing: true
            },
            {
                caption: 'Baş.Tar.',
                dataField: 'StartDate',
                dataType: 'date',
                sortOrder: 'desc',
                sortIndex: 0,
                allowEditing: true
            },
            {
                caption: 'Bit.Tar.',
                dataField: 'EndDate',
                dataType: 'date',
                allowEditing: true
            },
            {
                caption: 'Durum',
                dataField: 'CurrentState',
                dataType: 'string',
                lookup: { dataSource: that.dptStatesArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                allowEditing: true
            },
            {
                caption: 'T.Puan',
                dataField: 'TotalPoint',
                dataType: 'string',
                allowEditing: false
            },{
                cellTemplate: 'bpkrReportCellTemplate',
                width: '12%',
                allowSorting: false
            }];
    }


    EditingConfig: any = {
        mode: 'form',
        allowUpdating: true,
        allowAdding: true,
        allowDeleting: false,
        texts: {
            deleteRow: 'Sil',
            addRow: 'Yeni Dönem Aç',
            editRow: 'Güncelle',
            confirmDeleteMessage: 'Doktor performans dönemi silinecek. Emin misiniz?'
        }
    };

    onRowUpdatingTermList(event: any): void {
        let controlModel: DoctorPerformanceTerm = new DoctorPerformanceTerm();

        controlModel.Name = event.oldData.Name;
        controlModel.StartDate = event.oldData.StartDate;
        controlModel.EndDate = event.oldData.EndDate;
        controlModel.CurrentStateDefID = event.oldData.CurrentState;

        if (event.newData.Name != undefined)
            controlModel.Name = event.newData.Name;
        if (event.newData.StartDate != undefined)
            controlModel.StartDate = event.newData.StartDate;
        if (event.newData.EndDate != undefined)
            controlModel.EndDate = event.newData.EndDate;
        if (event.newData.CurrentState != undefined)
            controlModel.CurrentStateDefID = event.newData.CurrentState;

        if (controlModel.StartDate > controlModel.EndDate) {
            ServiceLocator.MessageService.showError('Dönem başlangıç tarihi dönem bitiş tarihinden büyük olamaz.');
            event.cancel = true;
            return;
        }
        else if (controlModel.Name == "" || controlModel.Name == undefined || controlModel.Name == null) {
            ServiceLocator.MessageService.showError('Dönem adı boş olarak yeni dönem açılamaz.');
            event.cancel = true;
            return;
        }

        if (event.oldData.CurrentState == DoctorPerformanceTerm.DoctorPerformanceTermStates.Cancelled && event.newData.CurrentState == undefined){
            ServiceLocator.MessageService.showError('İptal edilmiş dönemde durum harici güncelleme işlemi yapılamaz.');
            event.cancel = true;
            return;
        }

        let model: DoctorPerformanceTerm = new DoctorPerformanceTerm();
        model.ObjectID = event.oldData.ObjectID;
        if (event.newData.Name != undefined)
            model.Name = event.newData.Name;
        if (event.newData.StartDate != undefined)
            model.StartDate = event.newData.StartDate;
        if (event.newData.EndDate != undefined)
            model.EndDate = event.newData.EndDate;
        if (event.newData.CurrentState != undefined)
            model.CurrentStateDefID = event.newData.CurrentState;

        let apiUrlForTaniKayit: string = '/api/DoctorPerformanceApi/UpdateDoctorPerformanceTerm';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            if (response) {
                ServiceLocator.MessageService.showSuccess("Dönem başarılı bir şekilde güncellendi.");
                this.loadTermListDataSource();
            }
        }).catch(error => {
            this.errorHandlerForDPTermOperation(error);
            this.loadTermListDataSource();
        });
    }
    errorHandlerForDPTermOperation(message: string): void {
        //this.loadPanelOperation(false, '');
        ServiceLocator.MessageService.showError(message);
        console.log(message);
    }

    onClickBPKRReport(row: any): void {

        this.http.get<Array<DpKatsayiRaporModel>>("api/DoctorPerformanceApi/GetUnitPerformanceMultipleReport?termID=" + row.data.ObjectID).then(result => {
            this.BPKRReportResults = result;
            this.showBPKRReportPopup = true;
        }).catch(error => {
            
        });
    }

    public showBPKRReportPopup: boolean = false;
    public BPKRReportResults: Array<DpKatsayiRaporModel> = new Array<DpKatsayiRaporModel>();
    public BPKRReportColumns = [
        {
            caption: 'Grup',
            dataField: 'GroupName',
            width: 'auto', 
            groupIndex: '0'
        }, {
            caption: 'Branş Kod',
            dataField: 'BranchCode',
            width: 'auto', 
            allowGrouping: false
        }, {
            caption: 'Branş Adı',
            dataField: 'BranchName',
            width: 'auto', 
            allowGrouping: false
        }, {
            caption: 'Doktor',
            dataField: 'PersonelName',
            width: 'auto',
            allowGrouping: false
        }, {
            caption: 'Oran',
            dataField: 'Ratio',
            width: 'auto',
            allowGrouping: false
        }, {
            caption: 'Oran P.',
            dataField: 'RatioPoint',
            width: 'auto',
            allowGrouping: false
        }, {
            caption: 'Toplam P.',
            dataField: 'TotalPoint',
            width: 'auto',
            allowGrouping: false
        }, {
            caption: 'Sonuç P.',
            dataField: 'LastPoint',
            width: 'auto',
            allowGrouping: false
        } 
    ];

    onRowInsertingTermList(event: any): void {

        if (event.data.StartDate > event.data.EndDate) {
            ServiceLocator.MessageService.showError('Dönem başlangıç tarihi dönem bitiş tarihinden büyük olamaz.');
            event.cancel = true;
            return;
        }
        else if (event.data.Name == "" || event.data.Name == undefined || event.data.Name == null) {
            ServiceLocator.MessageService.showError('Dönem adı boş olarak yeni dönem açılamaz.');
            event.cancel = true;
            return;
        } else if (event.data.CurrentState != DoctorPerformanceTerm.DoctorPerformanceTermStates.Open ) {
            ServiceLocator.MessageService.showError('Yeni dönem sadece Açık durumunda açılabilir.');
            event.cancel = true;
            return;
        }

        let model: DoctorPerformanceTerm = new DoctorPerformanceTerm();

        model.Name = event.data.Name;
        model.StartDate = event.data.StartDate;
        model.EndDate = event.data.EndDate;
        model.CurrentStateDefID = DoctorPerformanceTerm.DoctorPerformanceTermStates.Open;

        let apiUrlForTaniKayit: string = '/api/DoctorPerformanceApi/SaveNewDoctorPerformanceTerm';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            if (response) {
                ServiceLocator.MessageService.showSuccess("Dönem başarılı bir şekilde eklendi.");
                this.loadTermListDataSource();
            }
        }).catch(error => {
            this.errorHandlerForDPTermOperation(error);
            this.loadTermListDataSource();
        });
    }
}