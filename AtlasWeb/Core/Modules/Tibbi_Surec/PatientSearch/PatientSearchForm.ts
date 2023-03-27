//$74C4AA56
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Component, EventEmitter, OnChanges, SimpleChanges, ViewChild } from '@angular/core';
import { PatientSearchFormViewModel } from "./PatientSearchFormViewModel";
import { HvlAutoCompleteGrid } from "Fw/Components/HvlAutoCompleteGrid";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { TTAutoCompleteGrid, LoadDataSourceEventArgs, AutoCompleteMode, PagedResult } from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';
import { ServiceLocator } from "Fw/Services/ServiceLocator";

@Component({
    selector: 'PatientSearchForm',
    inputs: ['Width', 'Visible'],
    templateUrl: './PatientSearchForm.html',
    outputs: ['SelectedPatientChanged', 'SearchTextChanged']
})
export class PatientSearchForm extends TTVisual.TTForm implements OnChanges {

    Width: String;
    public ViewModel: PatientSearchFormViewModel; 164;
    Visible: boolean;

    @ViewChild(HvlAutoCompleteGrid) patientAutoInstance: HvlAutoCompleteGrid;
    SelectedPatientChanged: EventEmitter<any> = new EventEmitter<any>();
    SearchTextChanged: EventEmitter<string> = new EventEmitter<string>();
    patientSearch: TTAutoCompleteGrid = new TTAutoCompleteGrid();


    constructor(protected httpService: NeHttpService, services: ServiceContainer, protected messageService: MessageService) {
        super("CONVTEST", "ConvTestForm");
        this.ViewModel = new PatientSearchFormViewModel();
        let that = this;
        this.patientSearch.EnablePaging = false;
        this.patientSearch.AutoCompleteDisplayExpression = "NameSurname";
        this.patientSearch.Width = "380px";
        this.patientSearch.Height = "27px";
        this.patientSearch.PopupDialogWidth = "75%";
        this.patientSearch.PopupDialogHeight = "50%";
        this.patientSearch.ForeColor = "SlateGray";
        this.patientSearch.PlaceHolder = i18n("M30304", "Hasta Arama");
        this.patientSearch.SelectSingleResultAutomatically = true;
        this.patientSearch.ShowClearButton = true;
        this.patientSearch.Visible=true;
        this.patientSearch.Font = {
            Name: "'Open Sans', sans-serif",
            Bold: true,
            Size: 14
        };
        this.patientSearch.AutoCompleteMode = AutoCompleteMode.Grid;
        this.patientSearch.AutoCompleteGridColumns = [
            {
                dataField: "NameSurname",
                caption: i18n("M10517", "Adı Soyadı"),
                width: '40%'
            },
            {
                dataField: "FatherName",
                caption: i18n("M11390", "Baba Adı"),
                width: '20%'
            },
            {
                dataField: "Dob",
                caption: i18n("M13132", "Doğum Tarihi"),
                width: '20%'
            },
            {
                dataField: "CityOfBirth",
                caption: i18n("M13139", "Doğum Yeri"),
                width: '20%'
            }
        ];
        this.patientSearch.PopupDialogFieldConfig = [{
            Label: i18n("M10517", "Adı Soyadı"),
            Column: "ADSOYAD"
        }];
        this.patientSearch.PopupDialogGridColumns = [
            {
                dataField: "NameSurname",
                caption: i18n("M10517", "Adı Soyadı"),
                width: '40%'
            },
            {
                dataField: "FatherName",
                caption: i18n("M11390", "Baba Adı"),
                width: '20%'
            },
            {
                dataField: "Dob",
                caption: i18n("M13132", "Doğum Tarihi"),
                width: '20%'
            },
            {
                dataField: "CityOfBirth",
                caption: i18n("M13139", "Doğum Yeri"),
                width: '20%'
            }
        ];
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['Width']) {
            if (!this.Width) {
                this.Width = "500px";
            }
            this.patientSearch.Width = this.Width;
        }
        if (changes['Visible']) {
            if (!this.Visible) {
                this.Visible = true;
            }
            this.patientSearch.Visible = this.Visible;
        }
    }

    onTextChanged(text: string) {
        this.SearchTextChanged.emit(text);
    }
    
    onSelectedItemClear(event){
        this.SelectedPatientChanged.emit(null);
    }

    valueChanged(data: any) {
        if (data) {
            let that = this;
            let apiUrlForSelectedPatient: string = '/api/PatientSearchService/GetPatients?patientObjectID=' + data.ObjectID;
            that.httpService.get<PatientSearchFormViewModel>(apiUrlForSelectedPatient, PatientSearchFormViewModel)
                .then(response => {
                    let result = <PatientSearchFormViewModel>response;
                    that.ViewModel.PatientInfoLists = result.PatientInfoLists;
                    if (result.PatientSearchResult.PatientInfo) {
                        result.PatientSearchResult.PatientInfo.PatientIDandFullName = result.PatientSearchResult.PatientIDandFullName;
                        result.PatientSearchResult.PatientInfo.RefNo = result.PatientSearchResult.PatientRefNo;
                        result.PatientSearchResult.PatientInfo.MobilePhone = result.PatientSearchResult.PatientPhoneNumber;
                    }
                    that.SelectedPatientChanged.emit(result.PatientSearchResult.PatientInfo);
                })
                .catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
        }
        else {
            this.SelectedPatientChanged.emit(data);
        }
    }

   

    Clear() {
        this.patientAutoInstance.Clear();
        this.SelectedPatientChanged.emit(null);
    }

    onDataSourceRefresh(loader: LoadDataSourceEventArgs) {
     

        let that = this;
        let _searchText = loader.Filter;
        let resolved: PagedResult = new PagedResult();
        if (!loader.IsPopupDataSource) {
            loader.AsyncLoader = this.httpService.get<PagedResult>('api/PatientSearchService/PatientSearchForm?searchText=' + _searchText, PagedResult);
            this.httpService.get<PagedResult>('api/PatientSearchService/PatientSearchForm?searchText=' + _searchText, PagedResult).then(t => {
                let result = <PagedResult>t;
                if (result) {
                    //that.patientSearch.AutoCompleteDataSource = Util.ResolveProperty('PatientInfoLists.PatientList', result);
                    // this.controlPatientList(result.Data.length, _searchText);
                    if (result.Data.length > 10) {
                        resolved.Data = [];
                        that.patientAutoInstance.closeDialog();
                        that.patientAutoInstance.openPopupDialog();
                    }
                    else if (result.Data.length == 0) {
                        that.patientAutoInstance.closeDialog();
                        resolved.Data = result.Data;
                        that.SelectedPatientChanged.emit(null);
                        ServiceLocator.MessageService.showError(i18n("M11081", "Aradığınız Kriterlere Göre Bir Sonuç Bulunamadı."));
                    } else {
                        resolved.Data = result.Data;
                    }
                }
                return resolved;
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
        else {
            _searchText = that.patientAutoInstance.PopupDialogFieldConfig[0].Value;
            if (!_searchText || _searchText == '') {
                _searchText = this.patientAutoInstance.Text;
            }
            let skip: string = "&skip=" + (!loader.Skip ? "0" : loader.Skip.toString());
            let take: string = "&take=" + (!loader.Take ? "0" : loader.Take.toString());
            let requireCount: string = "&requireCount=" + (loader.RequireCount == true ? "true" : "false");
            let url: string = 'api/PatientSearchService/PatientSearchFormPaged?searchText=' + _searchText + skip + take + requireCount;
            loader.PopupAsyncLoader = this.httpService.get<PagedResult>(url, PagedResult);
            this.httpService.get<PagedResult>(url, PagedResult).then(t => {
                let result = <PagedResult>t;
                if (result) {
                    this.controlPatientList(result.Data.length, _searchText);
                }
                return result;
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
    }

    btnSearch_Click(): void {
        this.patientAutoInstance.openDialog();
        
    }

    controlPatientList(_length: number, searchText: String): void {

        if (_length == 0 && isNaN(+searchText))
            ServiceLocator.MessageService.showInfo(i18n("M10500", "Ad ve soyad ile ulaşamadığınız sonuçlar için T.C numarası ile aramayı deneyebilirsiniz."));
        else if (_length == 0) {
            ServiceLocator.MessageService.showInfo(i18n("M11080", "Aradığınız kriterlere ait hasta bulunamadı."));

            //yeni arşiv için confirm eklenebilir, bu component başka bi yerde kullanılır ise bi tane de flag lazım olabilir
            if (!isNaN(+searchText) && searchText.length == 11) {
                let p = new Patient();
                p.UniqueRefNo = +searchText;
                this.SelectedPatientChanged.emit(p);
            }
        }
    }

}