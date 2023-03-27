//$357BF17C
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Component, Input, EventEmitter, OnChanges, SimpleChanges, ViewChild } from '@angular/core';
import { PatientAdmissionSearchFormViewModel } from "./PatientAdmissionSearchFormViewModel";
import { HvlAutoCompleteGrid } from "Fw/Components/HvlAutoCompleteGrid";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { TTAutoCompleteGrid, LoadDataSourceEventArgs, AutoCompleteMode, PagedResult } from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { Exception } from 'NebulaClient/Mscorlib/Exception';

@Component({
    selector: 'PatientAdmissionSearchForm',
    inputs: ['Width'],
    templateUrl: './PatientAdmissionSearchForm.html',
    outputs: ['SelectedPatientChanged']
})
export class PatientAdmissionSearchForm extends TTVisual.TTForm implements OnChanges {
    Width: String;
    @ViewChild(HvlAutoCompleteGrid) patientAutoInstance: HvlAutoCompleteGrid;
    public ViewModel: PatientAdmissionSearchFormViewModel;
    SelectedPatientChanged: EventEmitter<any> = new EventEmitter<any>();
    patientSearch: TTAutoCompleteGrid = new TTAutoCompleteGrid();

    ngOnChanges(changes: SimpleChanges) {
        if (changes['Width']) {
            if (!this.Width) {
                this.Width = "500px";
            }
            this.patientSearch.Width = this.Width;
        }
    }

    constructor(services: ServiceContainer, protected messageService: MessageService, protected httpService: NeHttpService) {
        super("CONVTEST", "ConvTestForm");
        this.ViewModel = new PatientAdmissionSearchFormViewModel();
        let that = this;
        this.patientSearch.EnablePaging = false;
        this.patientSearch.SelectSingleResultAutomatically = true;
        this.patientSearch.AutoCompleteDisplayExpression = "NameSurname";
        this.patientSearch.Width = "380px";
        this.patientSearch.Height = "27px";
        this.patientSearch.PopupDialogWidth = "75%";
        this.patientSearch.PopupDialogHeight = "50%";
        this.patientSearch.ForeColor = "SlateGray";
        this.patientSearch.PlaceHolder = i18n("M30304", "Hasta Arama");
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

    private _isReadOnly: boolean;
    @Input() set IsReadOnly(value: boolean) {
        this._isReadOnly = value;
        this.patientSearch.Enabled = value;
    }
    get IsReadOnly(): boolean {
        return this._isReadOnly;
    }

    @Input() getInfoFromKPS: boolean;


    @Input() set ClearValue(value: boolean) {
        if (value == true) {
            this.patientSearch.SearchText = "";
        }
    }

    valueChanged(data: any) {
        if (data) {
            let that = this;
            let apiUrlForSelectedPatient: string = '/api/PatientAdmissionSearchService/GetPatientAdmissions?patientObjectID=' + data.ObjectID;
            this.httpService.get<any>(apiUrlForSelectedPatient)
                .then(response => {
                    let result = response;
                    that.ViewModel.PatientInfoLists = result.PatientInfoLists;
                    that.SelectedPatientChanged.emit(result.PatientSearchResult.PatientInfo);
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }

    Clear() {
        this.patientAutoInstance.Clear();
    }

    public notLoaded: boolean = false;
    onDataSourceRefresh(loader: LoadDataSourceEventArgs) {
        let that = this;
        let _searchText = loader.Filter;
        let resolved: PagedResult = new PagedResult();
        if (!loader.IsPopupDataSource) {
            loader.AsyncLoader = this.httpService.get<any>('api/PatientAdmissionSearchService/PatientAdmissionSearchForm?searchText=' + _searchText).then(t => {
                let result = t;
                if (result) {
                    this.controlPatientList(result.PatientInfoLists, _searchText, true);
                    if (this.notLoaded == false) {
                        if (result.PatientInfoLists.PatientList.length > 10) {
                            resolved.Data = [];
                            that.patientAutoInstance.closeDialog();
                            that.patientAutoInstance.openPopupDialog();
                        }
                        else {
                            resolved.Data = result.PatientInfoLists.PatientList;
                        }
                    }
                }
                this.patientAutoInstance.isPatientSearch = true;
                return resolved;
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
            let url: string = 'api/PatientAdmissionSearchService/PatientAdmissionSearchFormPaged?searchText=' + _searchText + skip + take + requireCount;
            loader.PopupAsyncLoader = this.httpService.get<any>(url).then(t => {
                let result = t;
                if (result) {
                    this.controlPatientList(result.Data, _searchText, false);
                }
                return result;
            });
        }


    }

    btnSearch_Click(): void {

        this.patientAutoInstance.openDialog();

    }

    protected async controlPatientList(PatientInfoLists: any, searchText: String, privacy: Boolean) {
        if (PatientInfoLists.PatientList == undefined){
            //if (privacy == true && PatientInfoLists.length == 1 && PatientInfoLists[0].Privacy == true && PatientInfoLists.hasGizliHastaKabulRoleID != true) {
            //    ServiceLocator.MessageService.showInfo("Sorgulanan kişinin gizli hasta kaydı mevcuttur.Yetkili kişi ile görüşünüz.");
            //    this.notLoaded = true;
            //}
            /*else*/ if (PatientInfoLists.length == 0 && isNaN(+searchText)) {
                ServiceLocator.MessageService.showInfo(i18n("M10500", "Ad ve soyad ile ulaşamadığınız sonuçlar için T.C numarası ile aramayı deneyebilirsiniz."));
                this.notLoaded = false;
            }
            else if (PatientInfoLists.length == 0) {
                this.patientAutoInstance.closeDialog();
                ServiceLocator.MessageService.showInfo(i18n("M11080", "Aradığınız kriterlere ait hasta bulunamadı."));

                //yeni arşiv için confirm eklenebilir, bu component başka bi yerde kullanılır ise bi tane de flag lazım olabilir
                if (!isNaN(+searchText) && searchText.length == 11) {
                    let p = new Patient();
                    p.UniqueRefNo = +searchText;
                    this.SelectedPatientChanged.emit(p);
                }
                this.notLoaded = false;
            }
        }else{
            //if (privacy == true && PatientInfoLists.PatientList.length == 1 && PatientInfoLists.PatientList[0].Privacy == true && PatientInfoLists.hasGizliHastaKabulRoleID != true) {
            //    ServiceLocator.MessageService.showInfo("Sorgulanan kişinin gizli hasta kaydı mevcuttur.Yetkili kişi ile görüşünüz.");
            //    this.notLoaded = true;
            //}
            /*else*/ if (PatientInfoLists.PatientList.length == 0 && isNaN(+searchText)) {
                this.patientAutoInstance.closeDialog();
                ServiceLocator.MessageService.showInfo(i18n("M10500", "Ad ve soyad ile ulaşamadığınız sonuçlar için T.C numarası ile aramayı deneyebilirsiniz."));
                this.notLoaded = false;
            }
            else if (PatientInfoLists.PatientList.length == 0) {
                this.patientAutoInstance.closeDialog();
                try {
                    if (this.getInfoFromKPS) {

                        await this.CheckOrdersToCancel();

                    }
                    else
                        ServiceLocator.MessageService.showInfo(i18n("M11080", "Aradığınız kriterlere ait hasta bulunamadı."));

                    //yeni arşiv için confirm eklenebilir, bu component başka bi yerde kullanılır ise bi tane de flag lazım olabilir
                    if (!isNaN(+searchText) && searchText.length == 11) {
                        let p = new Patient();
                        p.UniqueRefNo = +searchText;
                        this.SelectedPatientChanged.emit(p);
                    }
                } catch (error) {

                }
                this.notLoaded = false;

            }
        }

    }

    protected async CheckOrdersToCancel() {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M19737", "Kayıt bulunamadı yeni arşiv oluşturulsun mu?"), "Arşiv Oluşturma");
        if (result === 'V') {
            throw new Exception(i18n("M22555", "Aradığınız kriterlere ait hasta bulunamadı."));
        }
    }
}



