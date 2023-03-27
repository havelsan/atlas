//$B031EBC6
import { Component, OnInit, ViewChild } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DoctorPerformanceTermBasedOperationViewModel, BransGridModel, DoctorGridModel, DetailModel, LogGridModel, DiffDetailModel, SummaryGridModel, RuleGridModel, ServiceResultModel } from './DoctorPerformanceViewModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DxDataGridComponent } from 'devextreme-angular';
import { Guid } from '../NebulaClient/Mscorlib/Guid';

@Component({
    selector: "dp-term-based-operation",
    templateUrl: './DoctorPerformanceTermBasedOperation.html'
})
export class DoctorPerformanceTermBasedOperation implements OnInit {
    public doctorPerformanceTermBasedOperationViewModel: DoctorPerformanceTermBasedOperationViewModel;
    @ViewChild('logListGrid') detailLogGrid: DxDataGridComponent;
    BransColumns = [];
    DoctorColumns = [];
    DetailColumns = [];
    SummaryColumns = [];
    RuleColumns = [];
    LogColumns = [];
    LogDiffColumns = [];
    @ViewChild('procedureDetail') detailGrid: DxDataGridComponent;
    selectedLogs: Array<LogGridModel> = [];
    constructor(protected http: NeHttpService) {
        this.doctorPerformanceTermBasedOperationViewModel = new DoctorPerformanceTermBasedOperationViewModel();
    }
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';

        //this.loadPanelOperation(false, "");
        //this.loadPanelOperation(true,  "Mesaj");
    }
    ngOnInit() {
        this.generateDoctorColumn();
        this.generateBransColumn();
        this.generateDetailColumn();
        this.generateLogColumn();
        this.generateLogDiffColumn();
        this.generateSummaryColumn();
        this.generateRuleColumn();
        this.loadBransListDataSource();
    }


    public loadRuleDescData(details: Array<DetailModel>): void {
        this.doctorPerformanceTermBasedOperationViewModel.RuleList = new Array<RuleGridModel>();
        let tempSummary = details.reduce(function(rv, x) {
            (rv[x["RuleName"]] = rv[x["RuleName"]] || []).push(x);
            return rv;
          }, {});

          for (let item in tempSummary)
          {
              if (item != undefined && item != "" && item != "null")
              {
                  let name = "", code = "", count = 0, summ = 0;
                  for (let index = 0; index < tempSummary[item].length; index++) {
                      let element = tempSummary[item][index];
                      name  = element.RuleName;
                      count = index + 1;
                      summ += element.Point;
                  }
                  let dataInner = new RuleGridModel();
                  dataInner.Rule = name;
                  dataInner.TotalCount = count;
                  dataInner.TotalPoint = summ;
                  this.doctorPerformanceTermBasedOperationViewModel.RuleList.push(dataInner);
              }
          }

   }

    public loadSummaryData(details: Array<DetailModel>): void {
        this.doctorPerformanceTermBasedOperationViewModel.SummaryList = new Array<SummaryGridModel>();
         let tempSummary = details.reduce(function(rv, x) {
             (rv[x["Code"]] = rv[x["Code"]] || []).push(x);
             return rv;
           }, {});
           //console.log(tempSummary);

           for (let item in tempSummary)
           {
               if (item != undefined)
               {
                   let name = "", code = "", count = 0, summ = 0;
                   for (let index = 0; index < tempSummary[item].length; index++) {
                       let element = tempSummary[item][index];
                       name  = element.Name;
                       code = element.Code;
                        count = index + 1;
                        summ += element.CalcPoint;
                   }


                   let dataInner = new SummaryGridModel();
                   dataInner.Code = code;
                   dataInner.Name = name;
                   dataInner.TotalCount = count;
                   dataInner.TotalPoint = summ;
                   this.doctorPerformanceTermBasedOperationViewModel.SummaryList.push(dataInner);
               }
        }
        this.generateSummaryColumn();
    }

    generateSummaryColumn(): void {
        this.SummaryColumns = [
            {
            caption: 'Kod',
            dataField: 'Code',
            dataType: 'string',
            sortOrder: 'asc',
                sortIndex: 0,
                fixed: true,
            width: '20%'

        }, {
            caption: 'Adı',
            dataField: 'Name',
                dataType: 'string',
                fixed: true,
            width: '60%'
        }, {
            caption: 'Adet',
            dataField: 'TotalCount',
                dataType: 'number',
                fixed: true,
            width: '10%'
        }, {
            caption: 'Puan',
            dataField: 'TotalPoint',
                dataType: 'number',
                fixed: true,
            width: '10%'
            }, {
                caption: this.getDoctorDetailInfo()  ,
            width: '100%'
            }];
    }

    
    getDoctorDetailInfo() {
        let bransName = "";
        for (var i = 0; i < this.doctorPerformanceTermBasedOperationViewModel.BransList.length; i++) {
            if (this.doctorPerformanceTermBasedOperationViewModel.BransList[i].ObjectID == this.doctorPerformanceTermBasedOperationViewModel.SelectedBrans) {
                bransName = this.doctorPerformanceTermBasedOperationViewModel.BransList[i].Name;
            }

        }

        for (var i = 0; i < this.doctorPerformanceTermBasedOperationViewModel.DoctorList.length; i++) {
            if (this.doctorPerformanceTermBasedOperationViewModel.DoctorList[i].ObjectID == this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor) {
                let selectedDr = this.doctorPerformanceTermBasedOperationViewModel.DoctorList[i];
                return bransName + ' / '+selectedDr.Title + ' ' + selectedDr.Name + ' - ' + selectedDr.UniqueRefNo;
            }
                
        }
    }

    generateRuleColumn(): void {
        this.RuleColumns = [
            {
            caption: 'Kural',
            dataField: 'Rule',
            dataType: 'string',
            sortOrder: 'asc',
            sortIndex: 0
        }, {
            caption: 'Adet',
            dataField: 'TotalCount',
            dataType: 'number'
        } ];
    }
    generateLogColumn(): void {
        this.LogColumns = [
            {
                caption: 'Sorgu Tarihi',
                dataField: 'ExecDate',
                dataType: 'date',
                format: 'shortDateShortTime',
                width: '50%',
                sortOrder: 'desc',
                sortIndex: 0
            }, {
                caption: 'Toplam Puan',
                dataField: 'TotalCalcPoint',
                width: '38%',
                dataType: 'number'
            },
        {
            cellTemplate: 'loadDetailCellTemplate',
            width: '12%',
            allowSorting: false
        }];
    }
    generateBransColumn(): void {
        this.BransColumns = [
            {
                caption: 'Kod',
                dataField: 'Code',
                dataType: 'string',
                sortOrder: 'asc',
                sortIndex: 0
            }, {
                caption: 'Branş Adı',
                dataField: 'Name',
                dataType: 'string'
            },
            {
                cellTemplate: 'loadDetailCellTemplate',
                width: '12%',
                allowSorting: false
            }];
    }
    generateDoctorColumn(): void {
        this.DoctorColumns = [
              {
                caption: 'Doktor',
                dataField: 'Name',
                dataType: 'string',
                width: '50%',
                sortOrder: 'asc',
                sortIndex: 0
            }, {
                caption: 'B1',
                dataField: 'B1Point',
                dataType: 'number',
                width: '10%'
              }, {
                  caption: 'B2',
                  dataField: 'B2Point',
                  dataType: 'number',
                  width: '10%'
            }, {
                caption: 'B3',
                dataField: 'B3Point',
                dataType: 'number',
                width: '10%'
              }, {
                  caption: 'Tarih',
                  dataField: 'LastExecDate',
                  dataType: 'date',
                  format: 'shortDateShortTime',
                  width: '20%'
              }
        ];
    }
    generateLogDiffColumn(): void {
        this.LogDiffColumns = [
            {
                caption: 'Kod',
                dataField: 'Code',
                dataType: 'string',
                sortOrder: 'asc',
                sortIndex: 0
            }, {
                caption: 'Hizmet',
                dataField: 'Name',
                dataType: 'string'
            },   {
                caption: 'Hasta',
                dataField: 'PatientName',
                dataType: 'string'
            }, {
                caption: 'Tarih',
                dataField: 'PerformedDate',
                format: 'shortDateShortTime',
                dataType: 'date'
            }, {
                caption: 'Kabul',
                dataField: 'ProtocolNo',
                dataType: 'string'
            }, {
                caption: 'E.Puan',
                dataField: 'OldPoint',
                dataType: 'number'
            }, {
                caption: 'Y.Puan',
                dataField: 'NewPoint',
                dataType: 'number'
            }, {
                caption: 'Açıklama',
                dataField: 'DiffDescription',
                dataType: 'number'
            },
            {
                caption: 'Kural Açıklaması',
                dataField: 'RuleDescription',
                dataType: 'string'
            }
        ];
    }
    generateDetailColumn(): void {
        this.DetailColumns = [
            {
                caption: 'Kod',
                dataField: 'Code',
                dataType: 'string',
                sortOrder: 'asc',
                allowEditing: false,
                sortIndex: 3
            }, {
                caption: 'Hizmet',
                dataField: 'Name',
                dataType: 'string',
                allowEditing: false
            },   {
                caption: 'Hasta',
                dataField: 'PatientName',
                dataType: 'string',
                allowEditing: false,
                sortIndex: 1
            }, {
                caption: 'Tarih',
                dataField: 'PerformedDate',
                format: 'shortDateShortTime',
                dataType: 'date',
                allowEditing: false
            }, {
                caption: 'Kabul',
                dataField: 'ProtocolNo',
                dataType: 'string',
                allowEditing: false,
                sortIndex: 2
            }, {
                caption: 'Puan',
                dataField: 'CalcPoint',
                dataType: 'number',
                allowEditing: false
            }, {
                caption: 'Kural',
                dataField: 'RuleName',
                dataType: 'string',
                allowEditing: false
            }, {
                caption: 'Doktor',
                dataField: 'DoctorName',
                dataType: 'string',
                allowEditing: false,
                sortIndex: 0
            }, {
                caption: 'Birim',
                dataField: 'RessectionName',
                dataType: 'string',
                allowEditing: false
            }, {
                caption: 'Tedavi Türü',
                dataField: 'PatientStatus',
                dataType: 'string',
                allowEditing: false
            },{
                caption: 'Sıfırlama',
                dataField: 'IsModified',
                dataType: 'boolean',
                allowEditing: true
            }
        ];
    }
    onRowUpdatingDetailList(event: any): void {
        if (event.newData.IsModified != null && event.newData.IsModified !== undefined) {
            let tempST: Array<any> = [];
            tempST.push(event.key);
            this.puanSifirlaGeriAl(tempST, event.newData.IsModified);
        }
    }
    puanSifirlaGeriAl(st: Array<any>, state: boolean): void {

        let apiUrlForTransactionHizmetKayit: string = '/api/DoctorPerformanceApi/puanSifirlaGeriAl?state=' + state;
        this.loadPanelOperation(true, "Hizmet puan sıfırlama işlemi yapılıyor, lütfen bekleyiniz.");

        this.http.post<Array<DetailModel>>(apiUrlForTransactionHizmetKayit, st).then(response => {
            for (let i = 0; i < response.length; i++) {
                for (let j = 0; j < this.doctorPerformanceTermBasedOperationViewModel.DetailList.length; j++) {
                    if (response[i].ObjectID == this.doctorPerformanceTermBasedOperationViewModel.DetailList[j].ObjectID) {
                        this.doctorPerformanceTermBasedOperationViewModel.DetailList[j].IsModified = response[i].IsModified;
                        this.doctorPerformanceTermBasedOperationViewModel.DetailList[j].CalcPoint = response[i].CalcPoint;
                        this.doctorPerformanceTermBasedOperationViewModel.DetailList[j].RuleName = response[i].RuleName;
                        this.doctorPerformanceTermBasedOperationViewModel.DetailList[j].RuleDescription = response[i].RuleDescription;
                    }
                }
            }
            this.loadSummaryData(this.doctorPerformanceTermBasedOperationViewModel.DetailList);
            this.loadRuleDescData(this.doctorPerformanceTermBasedOperationViewModel.DetailList);
            this.loadPanelOperation(false, "");
        }).catch(error => {
            this.errorHandlerForDPTermBasedOperation(error);
            });


    }
    loadBransListDataSource(): void {
        this.http.get<Array<BransGridModel>>("api/DoctorPerformanceApi/GetBransList").then(result => {
            this.doctorPerformanceTermBasedOperationViewModel.BransList = result;
        }).catch(error => {
            this.errorHandlerForDPTermBasedOperation(error);
        });
    }
    loadDoctorListDataSource(): void {
        this.http.get<Array<DoctorGridModel>>("api/DoctorPerformanceApi/GetDoctorList?selectedBransID=" + this.doctorPerformanceTermBasedOperationViewModel.SelectedBrans).then(result => {
            this.doctorPerformanceTermBasedOperationViewModel.DoctorList = result;
        }).catch(error => {
            this.errorHandlerForDPTermBasedOperation(error);
        });
    }

    btnGetDoctorPerformanceDetailsClick(): void {
        if (this.selectedTerm == null || this.selectedTerm == undefined){
            ServiceLocator.MessageService.showError('Listeleme yapabilmek için dönem seçimi zorunludur. Lütfen dönem seçiniz.');
            return;
        }
        else if (this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor == null || this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor == undefined) {
            ServiceLocator.MessageService.showError('Listeleme yapabilmek için doktor seçimi zorunludur. Lütfen doktor seçiniz.');
            return;
        }
        this.loadPanelOperation(true, "Döneme ait detaylı hizmetler hesaplanıyor. Lütfen bekleyiniz.");
        this.http.get<ServiceResultModel>("api/DoctorPerformanceApi/GetNewDetailData?termID=" + this.selectedTerm + "&doctorID=" + this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor).then(result => {


            this.loadSummaryData(result.DetailList);
            this.loadRuleDescData(result.DetailList);
            this.setDoctorListExecProp(result);
            this.doctorPerformanceTermBasedOperationViewModel.DetailList = result.DetailList;
            this.loadDetailLogData();
            this.loadPanelOperation(false, "");
        }).catch(error => {
            this.errorHandlerForDPTermBasedOperation(error);
        });
    }
    setDoctorListExecProp(result: ServiceResultModel): any {
        for (let index = 0; index < this.doctorPerformanceTermBasedOperationViewModel.DoctorList.length; index++) {
            const element = this.doctorPerformanceTermBasedOperationViewModel.DoctorList[index];
            if (element.ObjectID == this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor)
            {
                element.B1Point = result.B1Point;
                element.B2Point = result.B2Point;
                element.B3Point = result.B3Point;
                element.LastExecDate = result.LastExecDate;
            }
        }
    }
    public selectedTerm: any;
    termValueChanged(event: any) {
        console.log("Term value changed");
        console.log(event);
        console.log(this.selectedTerm);
    }

    onRowClickBransList(event: any) {
        if (event.data.ObjectID != this.doctorPerformanceTermBasedOperationViewModel.SelectedBrans) {
            this.doctorPerformanceTermBasedOperationViewModel.SelectedBrans = event.data.ObjectID;
            this.loadDoctorListDataSource();
        }
    }

    loadDetailData(): void {
       
        if (this.selectedTerm != null && this.selectedTerm != undefined) {
            this.loadPanelOperation(true, "Döneme ait detaylı hizmetler getiriliyor. Lütfen bekleyiniz.");
            this.http.get<ServiceResultModel>("api/DoctorPerformanceApi/GetDetailData?termID=" + this.selectedTerm + "&doctorID=" + this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor).then(result => {
                this.loadSummaryData(result.DetailList);
                this.loadRuleDescData(result.DetailList);
                this.setDoctorListExecProp(result);
                this.doctorPerformanceTermBasedOperationViewModel.DetailList = result.DetailList;
                this.loadPanelOperation(false, "");
            }).catch(error => {
                this.errorHandlerForDPTermBasedOperation(error);
            });
        }
        else
            ServiceLocator.MessageService.showError("Detaylar görüntülenebilmesi için ilgili dönemin seçili olması lazım.");
    }

    loadDetailLogData(): void {
        this.http.get<Array<LogGridModel>>("api/DoctorPerformanceApi/GetDetailLogData?termID=" + this.selectedTerm + "&doctorID=" + this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor).then(logs => {
            this.doctorPerformanceTermBasedOperationViewModel.LogList = logs;
        }).catch(error => {
            this.errorHandlerForDPTermBasedOperation(error);
        });
    }

    onRowClickDoctorList(event: any) {
        if (event.data.ObjectID != this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor) {
            this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor = event.data.ObjectID;
            this.loadDetailData();
            this.loadDetailLogData();
        }
    }

    onSelectionChangedLogList(event: any) {
        console.log(event);
        console.log(this.selectedLogs);
        if (this.selectedLogs.length > 2){
            if (event.currentSelectedRowKeys != null && event.currentSelectedRowKeys.length > 0)
            {
                //for (var i = 0; i < this.selectedLogs.length; i++) {
                //    if (this.selectedLogs[i].ObjectID == event.currentSelectedRowKeys[0].ObjectID)
                this.detailLogGrid.instance.deselectRows(event.currentSelectedRowKeys);
                //}
                //var keys = this.detailLogGrid.instance.getSelectedRowKeys();
                //this.detailLogGrid.instance.deselectRows(keys);
            }
        }
    }

    onClickCalculateDetailLogDiff(): void {
        if (this.selectedLogs.length == 2) {

            this.http.get<Array<DiffDetailModel>>("api/DoctorPerformanceApi/CalculateDetailLogDiff?firstLogID=" + this.selectedLogs[0].ObjectID + "&secondLogID=" + this.selectedLogs[1].ObjectID).then(result => {
                this.doctorPerformanceTermBasedOperationViewModel.LogDiffList = result;
            }).catch(error => {
                this.errorHandlerForDPTermBasedOperation(error);
            });
        }
        else {
            ServiceLocator.MessageService.showError('Fark hesaplaması yapabilmek için 2 log satırı seçili olması gerekli.');
        }
    }
    onClickLoadLogDetails(row: any): void {
        console.log(row.data.ObjectID);
        this.http.get<Array<DetailModel>>("api/DoctorPerformanceApi/GetLogDetailData?logID=" + this.selectedLogs[0].ObjectID).then(result => {
            this.doctorPerformanceTermBasedOperationViewModel.LogDetailList = result;
        }).catch(error => {
            this.errorHandlerForDPTermBasedOperation(error);
        });
    }
    onClickLoadAllDetailsOfaBrans(row: any): void {
        if (this.selectedTerm == null || this.selectedTerm == undefined) {
            ServiceLocator.MessageService.showError('Listeleme yapabilmek için dönem seçimi zorunludur. Lütfen dönem seçiniz.');
            return;
        }
        this.http.get<ServiceResultModel>("api/DoctorPerformanceApi/GetAllDetailsOfaTermOrBrans?termID=" + this.selectedTerm + "&bransID=" + row.data.ObjectID).then(result => {
            this.loadSummaryData(result.DetailList);
            this.loadRuleDescData(result.DetailList);
            
            this.doctorPerformanceTermBasedOperationViewModel.DetailList = result.DetailList;
            this.loadPanelOperation(false, "");
        }).catch(error => {
            this.errorHandlerForDPTermBasedOperation(error);
        });
    }

    onClickLoadAllDetailsOfaTerm(): void {
        if (this.selectedTerm == null || this.selectedTerm == undefined) {
            ServiceLocator.MessageService.showError('Listeleme yapabilmek için dönem seçimi zorunludur. Lütfen dönem seçiniz.');
            return;
        }
        this.http.get<ServiceResultModel>("api/DoctorPerformanceApi/GetAllDetailsOfaTermOrBrans?termID=" + this.selectedTerm ).then(result => {
            this.loadSummaryData(result.DetailList);
            this.loadRuleDescData(result.DetailList);
             
            this.doctorPerformanceTermBasedOperationViewModel.DetailList = result.DetailList;
            this.loadPanelOperation(false, "");
        }).catch(error => {
            this.errorHandlerForDPTermBasedOperation(error);
        });
    }

    errorHandlerForDPTermBasedOperation(message: string): void {
        this.loadPanelOperation(false, '');
        ServiceLocator.MessageService.showError(message);
        console.log(message);
    }



    onSelectionChangedSummaryList(event: any) {
        if (event.selectedRowKeys != null && event.selectedRowKeys != undefined && event.selectedRowKeys.length > 0)
            this.detailGrid.instance.filter(x => x.Code ==  event.selectedRowKeys[0].Code);
        else
            this.detailGrid.instance.clearFilter();

        console.log(event);
    }

    onSelectionChangedRuleList(event: any) {
        if (event.selectedRowKeys != null && event.selectedRowKeys != undefined && event.selectedRowKeys.length > 0)
            this.detailGrid.instance.filter(x => x.RuleName == event.selectedRowKeys[0].Rule);
        else
            this.detailGrid.instance.clearFilter();

        console.log(event);
    }
    public selectedTransactions: Array<DetailModel> = [];
    onToolbarPreparingTransactionList(event: any): void {
        let that = this;
        event.toolbarOptions.items.unshift(
            {
                location: 'after',
                widget: 'dxButton',
                options: {
                    icon: 'refresh',
                    text: 'Toplu Sıfırla/Geri al',
                    type: 'btn btn-default',
                    onClick: that.puanSifirlaGeriAlToplu.bind(that)
                }
            });
    }

    puanSifirlaGeriAlToplu(): void {
        let tempST: Array<DetailModel> = [];
        let that = this;
        if (that.selectedTransactions.length === 0)//Hiç seçili yoksa sağ klik yaptığımız satırı işleme alsın diye eklendi.
        {
            ServiceLocator.MessageService.showError('Toplu işlem yapabilmek için lütfen en az bir tane hizmet seçiniz.');
            return;
        }
        else
            tempST = that.selectedTransactions;

        let firstValue: boolean;

        if (tempST.length > 1) {
            for (var i = 0; i < tempST.length; i++) {
                let item = tempST[i];
                
                if (i == 0)
                    firstValue = item.IsModified;
                else {
                    if (firstValue != item.IsModified) {
                        ServiceLocator.MessageService.showError('Toplu işlem yapabilmek için seçili hizmetlerin sıfırlanma durumları aynı olmalıdır.');
                        return;
                    }
                }
            }
        }
        that.puanSifirlaGeriAl(tempST, !firstValue);

    }
    customizePoint(data) {
        return Math.Round(data.value, 2) + " puan.";
    }

    gridRowCount(data: any) {
        return data.value + " adet.";
    }

    onFileSavingSummaryList(event: any) {
        
        for (var i = 0; i < this.doctorPerformanceTermBasedOperationViewModel.DoctorList.length; i++) {
            if (this.doctorPerformanceTermBasedOperationViewModel.DoctorList[i].ObjectID == this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor)
                event.fileName = this.doctorPerformanceTermBasedOperationViewModel.DoctorList[i].Name + "_ÖzetPuanListesi";
        }
        
    }

    onFileSavingDetailList(event: any) {

        for (var i = 0; i < this.doctorPerformanceTermBasedOperationViewModel.DoctorList.length; i++) {
            if (this.doctorPerformanceTermBasedOperationViewModel.DoctorList[i].ObjectID == this.doctorPerformanceTermBasedOperationViewModel.SelectedDoctor)
                event.fileName = this.doctorPerformanceTermBasedOperationViewModel.DoctorList[i].Name + "_DetaylıPuanListesi";
        }

    }
}