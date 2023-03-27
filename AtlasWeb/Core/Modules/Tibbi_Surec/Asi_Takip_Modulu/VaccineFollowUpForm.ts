//$102B80BA
import { Component, OnInit, NgZone, ViewChild  } from '@angular/core';
import { VaccineFollowUpFormViewModel, VaccineDefinitionsModel, ConfirmObj, LoginUserInfo } from "./VaccineFollowUpFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { SKRSAsiKodu } from 'NebulaClient/Model/AtlasClientModel';
import { VaccineDetails } from 'NebulaClient/Model/AtlasClientModel';
import { VaccineFollowUp } from 'NebulaClient/Model/AtlasClientModel';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DxDataGridComponent, DxAccordionComponent } from 'devextreme-angular';
import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'Fw/Models/DynamicComponentInputParam';
import { IModalService } from "Fw/Services/IModalService";

@Component({
    selector: 'VaccineFollowUpForm',
    templateUrl: './VaccineFollowUpForm.html',
    providers: [MessageService]
})
export class VaccineFollowUpForm extends EpisodeActionForm implements OnInit, IModal {
    @ViewChild('vaccinedetails') vaccineDetailsGrid: DxDataGridComponent;

    ApplicationDateVaccineDetails: TTVisual.ITTDateTimePickerColumn;
    AppointmentDateVaccineDetails: TTVisual.ITTDateTimePickerColumn;
    NotesVaccineDetails: TTVisual.ITTTextBoxColumn;
    PeriodNameVaccineDetails: TTVisual.ITTTextBoxColumn;
    PeriodRangeVaccineDetails: TTVisual.ITTTextBoxColumn;
    PeriodUnitVaccineDetails: TTVisual.ITTEnumComboBoxColumn;
    VaccineDetails: TTVisual.ITTGrid;
    VaccineNameVaccineDetails: TTVisual.ITTTextBoxColumn;
    public selectedVaccines: Array<VaccineDefinitionsModel> = [];

    public vaccineFollowUpFormViewModel: VaccineFollowUpFormViewModel = new VaccineFollowUpFormViewModel();
    public vaccineDefinitionsResult: VaccineDefinitionsModel[] = [];
    public showVaccinedefinitionsPopup = false;
    public periodUnitArray: Array<any> = [];
    public PeriodUnitCache: any;
    VaccinePeriodColumns = [];
    VaccineDetailsColumns = [];
    VaccineListColumns = [];
    VaccineRow: VaccineDetails = new VaccineDetails();
    IsVaccineDetailReadOnly = true;
    public get _VaccineFollowUp(): VaccineFollowUp {
        return this._TTObject as VaccineFollowUp;
    }
    private VaccineFollowUpForm_DocumentUrl: string = '/api/VaccineFollowUpService/VaccineFollowUpForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone, protected modalService: IModalService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.VaccineFollowUpForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.showVaccinedefinitionsPopup = false;
    }


    // ***** Method declarations start *****

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new VaccineFollowUp();
        this.vaccineFollowUpFormViewModel = new VaccineFollowUpFormViewModel();
        this._ViewModel = this.vaccineFollowUpFormViewModel;
        this.vaccineFollowUpFormViewModel._VaccineFollowUp = this._TTObject as VaccineFollowUp;
        this.vaccineFollowUpFormViewModel._VaccineFollowUp.VaccineDetails = new Array<VaccineDetails>();
    }

    protected loadViewModel() {
        let that = this;
        that.vaccineFollowUpFormViewModel = this._ViewModel as VaccineFollowUpFormViewModel;
        that._TTObject = this.vaccineFollowUpFormViewModel._VaccineFollowUp;
        if (this.vaccineFollowUpFormViewModel == null)
            this.vaccineFollowUpFormViewModel = new VaccineFollowUpFormViewModel();
        if (this.vaccineFollowUpFormViewModel._VaccineFollowUp == null)
            this.vaccineFollowUpFormViewModel._VaccineFollowUp = new VaccineFollowUp();
        that.vaccineFollowUpFormViewModel._VaccineFollowUp.VaccineDetails = that.vaccineFollowUpFormViewModel.VaccineDetailsGridList;
       

    }

    async ngOnInit() {
        this.showVaccinedefinitionsPopup = false;
        //await this.load();
        let that = this;
        let promiseArray: Array<Promise<any>> = new Array<any>();
        promiseArray.push(this.PeriodUnit());

        Promise.all(promiseArray).then((sonuc: Array<any>) => {
            that.periodUnitArray = sonuc[0];

            that.GenerateVaccinePeriodListColumns();
            that.GenerateVaccineListColumns();
            that.LoadVaccineFollowupFromPatientID();


        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
        });





    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.VaccineDetails = new TTVisual.TTGrid();
        this.VaccineDetails.Name = "VaccineDetails";
        this.VaccineDetails.TabIndex = 0;

        this.VaccineNameVaccineDetails = new TTVisual.TTTextBoxColumn();
        this.VaccineNameVaccineDetails.DataMember = "VaccineName";
        this.VaccineNameVaccineDetails.DisplayIndex = 0;
        this.VaccineNameVaccineDetails.HeaderText = i18n("M11196", "Aşı Adı");
        this.VaccineNameVaccineDetails.Name = "VaccineNameVaccineDetails";
        this.VaccineNameVaccineDetails.ReadOnly = true;
        this.VaccineNameVaccineDetails.Width = 150;

        this.PeriodNameVaccineDetails = new TTVisual.TTTextBoxColumn();
        this.PeriodNameVaccineDetails.DataMember = "PeriodName";
        this.PeriodNameVaccineDetails.DisplayIndex = 1;
        this.PeriodNameVaccineDetails.HeaderText = i18n("M20309", "Periyod Adı");
        this.PeriodNameVaccineDetails.Name = "PeriodNameVaccineDetails";
        this.PeriodNameVaccineDetails.ReadOnly = true;
        this.PeriodNameVaccineDetails.Width = 150;

        this.PeriodRangeVaccineDetails = new TTVisual.TTTextBoxColumn();
        this.PeriodRangeVaccineDetails.DataMember = "PeriodRange";
        this.PeriodRangeVaccineDetails.DisplayIndex = 2;
        this.PeriodRangeVaccineDetails.HeaderText = i18n("M20314", "Periyod Süresi");
        this.PeriodRangeVaccineDetails.Name = "PeriodRangeVaccineDetails";
        this.PeriodRangeVaccineDetails.Width = 80;

        this.PeriodUnitVaccineDetails = new TTVisual.TTEnumComboBoxColumn();
        this.PeriodUnitVaccineDetails.DataTypeName = "PeriodUnitTypeEnum";
        this.PeriodUnitVaccineDetails.DataMember = "PeriodUnit";
        this.PeriodUnitVaccineDetails.DisplayIndex = 3;
        this.PeriodUnitVaccineDetails.HeaderText = "Birim";
        this.PeriodUnitVaccineDetails.Name = "PeriodUnitVaccineDetails";
        this.PeriodUnitVaccineDetails.Width = 80;

        this.AppointmentDateVaccineDetails = new TTVisual.TTDateTimePickerColumn();
        this.AppointmentDateVaccineDetails.DataMember = "AppointmentDate";
        this.AppointmentDateVaccineDetails.DisplayIndex = 4;
        this.AppointmentDateVaccineDetails.HeaderText = i18n("M20740", "Randevu Tarihi");
        this.AppointmentDateVaccineDetails.Name = "AppointmentDateVaccineDetails";
        this.AppointmentDateVaccineDetails.Width = 180;

        this.ApplicationDateVaccineDetails = new TTVisual.TTDateTimePickerColumn();
        this.ApplicationDateVaccineDetails.DataMember = "ApplicationDate";
        this.ApplicationDateVaccineDetails.DisplayIndex = 5;
        this.ApplicationDateVaccineDetails.HeaderText = i18n("M23763", "Uygulama Tarihi");
        this.ApplicationDateVaccineDetails.Name = "ApplicationDateVaccineDetails";
        this.ApplicationDateVaccineDetails.Width = 180;

        this.NotesVaccineDetails = new TTVisual.TTTextBoxColumn();
        this.NotesVaccineDetails.DataMember = "Notes";
        this.NotesVaccineDetails.DisplayIndex = 6;
        this.NotesVaccineDetails.HeaderText = i18n("M19476", "Not");
        this.NotesVaccineDetails.Name = "NotesVaccineDetails";
        this.NotesVaccineDetails.Width = 150;

        this.VaccineDetailsColumns = [this.VaccineNameVaccineDetails, this.PeriodNameVaccineDetails, this.PeriodRangeVaccineDetails, this.PeriodUnitVaccineDetails, this.AppointmentDateVaccineDetails, this.ApplicationDateVaccineDetails, this.NotesVaccineDetails];
        this.Controls = [this.VaccineDetails, this.VaccineNameVaccineDetails, this.PeriodNameVaccineDetails, this.PeriodRangeVaccineDetails, this.PeriodUnitVaccineDetails, this.AppointmentDateVaccineDetails, this.ApplicationDateVaccineDetails, this.NotesVaccineDetails];

    }

    onPrepareVaccineCalendar(): void {
        let that = this;
        let apiUrlForVaccineCalendar: string = '/api/VaccineFollowUpService/PrepareVaccineCalendar?PatientID=' + this.vaccineFollowUpFormViewModel.PatientID + '&fromPrepareCalendar=true';

        that.httpService.get<any>(apiUrlForVaccineCalendar)
            .then(response => {
                this.vaccineDefinitionsResult = response;
                this.showVaccinedefinitionsPopup = true;
            })
            .catch(error => {
                console.log(error);
            });
    }

    public setInputParam(value: Object) {

        if (value != null) {
            this._TTObject = value as VaccineFollowUp;
            this.vaccineFollowUpFormViewModel = new VaccineFollowUpFormViewModel();
            this._ViewModel = this.vaccineFollowUpFormViewModel;
            this.vaccineFollowUpFormViewModel._VaccineFollowUp = value as VaccineFollowUp;


        }
    }
    /*private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }*/

    VaccineDefinitionsColumns = [
        { caption: i18n("M11207", "Aşı Kodu"), dataField: 'VaccineCode', fixed: true, width: '20%', allowEditing: false },
        { caption: i18n("M11196", "Aşı Adı"), dataField: 'VaccineName', fixed: true, width: '60%', allowEditing: false },
        { caption: i18n("M11637", "Başlangıç Tarihi"), dataField: 'StartDate', fixed: true, width: '20%', format: 'dd/MM/yyyy', dataType: 'date', allowEditing: true }

    ];

    public async PeriodUnit(): Promise<any> {
        let enumName: string = "PeriodUnitTypeEnum";
        if (!this.PeriodUnitCache) {
            this.PeriodUnitCache = await this.httpService.get('/api/VaccineFollowUpService/GetEnumValues?enumName=' + enumName);
            return this.PeriodUnitCache;
        }
        else {
            return this.PeriodUnitCache;
        }
    }

    GenerateVaccinePeriodListColumns() {
        let that = this;
        this.VaccinePeriodColumns = [
            { caption: i18n("M20313", "Periyod No"), dataField: 'PeriodNo', fixed: true, width: '15%', allowSorting: false, allowEditing: false },
            { caption: i18n("M20309", "Periyod Adı"), dataField: 'PeriodName', fixed: true, width: '25%', allowSorting: false, allowEditing: false},
            { caption: i18n("M20314", "Periyod Süresi"), dataField: 'Period', fixed: true, width: '20%', allowSorting: false, allowEditing: false},
            { caption: i18n("M20310", "Periyod Birimi"), dataField: 'PeriodUnit', fixed: true, width: '20%', lookup: { dataSource: that.periodUnitArray, valueExpr: 'Value', displayExpr: 'Name' }, allowSorting: false, allowEditing: false },
            { caption: i18n("M20740", "Randevu Tarihi"), dataField: 'AppointmentDate', fixed: true, width: '20%', format: 'dd/MM/yyyy', dataType: 'date', allowSorting: false, allowEditing: true}
        ];
    }

    onCreateVaccineCalendar(): void {//detaylı oluştur
        let that = this;
        for (let vaccine of this.selectedVaccines) {
            for (let period of vaccine.VaccinePeriodList) {
                let vaccineObj = new VaccineDetails();
                vaccineObj.VaccineName = vaccine.VaccineName;
                vaccineObj.PeriodName = period.PeriodName;
                vaccineObj.PeriodRange = period.Period;
                vaccineObj.PeriodUnit = period.PeriodUnit;
                vaccineObj.AppointmentDate = period.AppointmentDate;
                vaccineObj.SKRSAsiKodu = new SKRSAsiKodu();
                vaccineObj.SKRSAsiKodu = vaccine.AsiKoduSKRS;
                vaccineObj.CurrentStateDefID = VaccineDetails.VaccineDetailsStates.New;
                //vaccineObj.ApplicationDate = new Date();
                //vaccineObj.Notes = "";

                this.vaccineFollowUpFormViewModel._VaccineFollowUp.VaccineDetails.push(vaccineObj);
            }
        }

        this.onSaveVaccineCalendar();

        this.showVaccinedefinitionsPopup = false;
    }
    onSelectionChangedVaccineList(event: any): void {
        this.selectedVaccines.Clear();
        for (let i = 0; i < event.selectedRowKeys.length; i++)
            this.selectedVaccines.push(event.selectedRowKeys[i]);
    }

    GenerateVaccineListColumns() {
        let that = this;
        this.VaccineListColumns = [
            { caption: i18n("M11196", "Aşı Adı"), dataField: 'VaccineName', fixed: true, width: '20%', allowSorting: false, allowEditing: false, groupIndex: 0 },
            { caption: i18n("M20309", "Periyod Adı"), dataField: 'PeriodName', fixed: true, width: '20%', allowSorting: false, allowEditing: false },
            { caption: i18n("M20314", "Periyod Süresi"), dataField: 'PeriodRange', fixed: true, width: '20%', allowSorting: false, allowEditing: false },
            { caption: 'Birim', dataField: 'PeriodUnit', fixed: true, width: '20%', lookup: { dataSource: that.periodUnitArray, valueExpr: 'Value', displayExpr: 'Name' }, allowSorting: false, allowEditing: false },
            { caption: i18n("M20740", "Randevu Tarihi"), dataField: 'AppointmentDate', fixed: true, width: '20%', format: 'dd/MM/yyyy', dataType: 'date', allowSorting: false, allowEditing: true}
            //{ caption: 'Uygulama Tarihi', dataField: 'ApplicationDate', fixed: true, width: '20%', format: 'dd/MM/yyyy', dataType: 'date', allowSorting: false,allowEditing: false }
            //{ caption: 'Not', dataField: 'Notes', fixed: true, width: '10%', allowSorting: false,allowEditing: true }
            //{ caption: 'Detay',width: 75, allowSorting: false, cellTemplate: "linkCellTemplateDetail"}
        ];
    }

    onStartDateChanged(event): void {
        let that = this;
        let apiUrlForCalculateAppointmentDate: string = '/api/VaccineFollowUpService/CalculateAppointmentDate?StartDate=' + event.newData.StartDate + '&ObjectID=' + event.key.ObjectID;

        that.httpService.get<any>(apiUrlForCalculateAppointmentDate)
            .then(response => {
                for (let vaccine of this.vaccineDefinitionsResult) {
                    if (vaccine.ObjectID == event.key.ObjectID)
                    {
                        vaccine.VaccinePeriodList = response;
                    }
                }

            })
            .catch(error => {
                console.log(error);
            });
    }

    LoadVaccineFollowupFromPatientID(): void{
       // this.vaccineFollowUpFormViewModel._VaccineFollowUp.Episode.Patient
        let that = this;

        let apiUrlForLoadVaccineFollowup: string = '/api/VaccineFollowUpService/LoadVaccineFollowupFromPatientID';

        that.httpService.post<any>(apiUrlForLoadVaccineFollowup, this.vaccineFollowUpFormViewModel._VaccineFollowUp)
            .then(response => {

                that.vaccineFollowUpFormViewModel = response as VaccineFollowUpFormViewModel;
                that._TTObject = response._VaccineFollowUp;
                if (this.vaccineFollowUpFormViewModel == null)
                    this.vaccineFollowUpFormViewModel = new VaccineFollowUpFormViewModel();
                if (this.vaccineFollowUpFormViewModel._VaccineFollowUp == null)
                    this.vaccineFollowUpFormViewModel._VaccineFollowUp = new VaccineFollowUp();
                that.vaccineFollowUpFormViewModel._VaccineFollowUp.VaccineDetails = response.VaccineDetailsGridList;
                that.vaccineFollowUpFormViewModel.PatientID = response.PatientID;

            })
            .catch(error => {
                console.log(error);
            });
    }

    onSaveVaccineCalendar(): void {
        let that = this;


        //let confirmResult: ConfirmObj = this.confirmSaveVaccineDetails();
        //if (confirmResult.Result == false) {
        //    this.messageService.showError(confirmResult.Message);
        //    return;
        //}


        let apiUrl: string = '/api/VaccineFollowUpService/SaveVaccineFollowUpForm'; //?viewModel=' + this.medicalInformationFormViewModel;
        that.httpService.post<any>(apiUrl, this.vaccineFollowUpFormViewModel)
            .then(response => {
                //Grid refresh edilmeli
                that.LoadVaccineFollowupFromPatientID();
                this.vaccineDetailsGrid.instance.refresh();
                //this.messageService.showInfo(i18n("M16831", "İşlem Başarılı."));
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }

    onAddNewVaccine(): void {


        let that = this;
        let apiUrlForVaccineCalendar: string = '/api/VaccineFollowUpService/PrepareVaccineCalendar?PatientID=' + this.vaccineFollowUpFormViewModel.PatientID + '&fromPrepareCalendar=false';

        that.httpService.get<any>(apiUrlForVaccineCalendar)
            .then(response => {
                this.vaccineDefinitionsResult = response;
                this.showVaccinedefinitionsPopup = true;
            })
            .catch(error => {
                console.log(error);
            });


    }

    onRowPreparedVaccineList(row: any): void {
        if (row.rowElement.firstItem() !== undefined && row.rowType !== 'header' && row.rowType !== 'group' && row.rowElement.firstItem().length === 1) {

            if (row.data.CurrentStateDefID == VaccineDetails.VaccineDetailsStates.Canceled)
            {
                row.rowElement.firstItem().style.backgroundColor = '#e06b6b';
                row.rowElement.firstItem().style.color = 'black';
            }
            else
                row.rowElement.firstItem().style.backgroundColor = '#FFFFFF';


        }
    }

    onSelectVaccine(event: any): void {

        //aşı yeni ise doktor ve hemşire set et
        let that = this;




        if (event != null && event.selectedRowsData != null && event.selectedRowsData.length > 0) {
            this.VaccineRow = event.selectedRowsData[0] as VaccineDetails;

            if (event.selectedRowsData[0].CurrentStateDefID == VaccineDetails.VaccineDetailsStates.New) {

                let apiUrl: string = '/api/VaccineFollowUpService/GetUserInfo';
                that.httpService.get<LoginUserInfo>(apiUrl)
                    .then(response => {
                        this.VaccineRow = event.selectedRowsData[0] as VaccineDetails;
                        this.IsVaccineDetailReadOnly = false;
                        if (response.IsDoctor)
                        {
                            this.VaccineRow.ResponsibleDoctor = response.UserInfo;
                        }

                        if (response.IsNurse) {
                            this.VaccineRow.ResponsibleNurse = response.UserInfo;
                        }
                    })
                    .catch(error => {
                        this.messageService.showError(error);

                    });

            }






        }
    }

    confirmSaveVaccineDetails(): ConfirmObj {
        let result: ConfirmObj = new ConfirmObj();

        if (this.VaccineRow.SKRSASIISLEMTURU == null || this.VaccineRow.SKRSASIISLEMTURU == undefined) {
            result.Result = false;
            result.Message = i18n("M11204", "Aşı İşlem Türünü Seçiniz.");
            return result;
        }

        if ( this.VaccineRow.SKRSASIISLEMTURU.KODU == "1" && (this.VaccineRow.ResponsibleDoctor == null || this.VaccineRow.ResponsibleDoctor == undefined)) {
            result.Result = false;
            result.Message = i18n("M22150", "Sorumlu Doktoru Seçiniz.");
            return result;
        }

        if ( this.VaccineRow.SKRSASIISLEMTURU.KODU == "1" && (this.VaccineRow.ResponsibleNurse == null || this.VaccineRow.ResponsibleNurse == undefined)) {
            result.Result = false;
            result.Message = i18n("M22152", "Sorumlu Hemşireyi Seçiniz.");
            return result;
        }

        if (this.VaccineRow.SKRSKurumlar == null || this.VaccineRow.SKRSKurumlar == undefined) {
            result.Result = false;
            result.Message = "İzlemin Yapıldığı Yeri Seçiniz.";
            return result;
        }

        if (this.VaccineRow.SKRSAsiOzelDurumNedeni == null || this.VaccineRow.SKRSAsiOzelDurumNedeni == undefined) {
            result.Result = false;
            result.Message = "Özel Durum Nedenini Seçiniz.";
            return result;
        }

        if (this.VaccineRow.BilgiAlinanKisiAdiSoyadi == null || this.VaccineRow.BilgiAlinanKisiAdiSoyadi == undefined) {
            result.Result = false;
            result.Message = "Bilgi Alınan Kişi Adı Soyadını Giriniz.";
            return result;
        }

        if (this.VaccineRow.BilgiAlinanKisiTel == null || this.VaccineRow.BilgiAlinanKisiTel == undefined) {
            result.Result = false;
            result.Message = "Bilgi Alınan Kişinin Telefon Numarasını Giriniz.";
            return result;
        }

        if (this.VaccineRow.SKRSAsiKodu == null || this.VaccineRow.SKRSAsiKodu == undefined) {
            result.Result = false;
            result.Message = i18n("M11210", "Aşı Seçiniz.");
            return result;
        }

        if (this.VaccineRow.SKRSAsininDozu == null || this.VaccineRow.SKRSAsininDozu == undefined) {
            result.Result = false;
            result.Message = i18n("M11226", "Aşının Dozunu Seçiniz.");
            return result;
        }

        if (this.VaccineRow.SKRSAsiUygulamaYeri == null || this.VaccineRow.SKRSAsiUygulamaYeri == undefined) {
            result.Result = false;
            result.Message = i18n("M23769", "Uygulama Yerini Seçiniz.");
            return result;
        }

        if (this.VaccineRow.SKRSAsininUygulamaSekli == null || this.VaccineRow.SKRSAsininUygulamaSekli == undefined) {
            result.Result = false;
            result.Message = i18n("M23761", "Uygulama Şeklini Seçiniz.");
            return result;
        }

        return result;
    }

    //CancelVaccineDetail() {
    //    let that = this;
    //    //tamamlanmış kontrolü
    //    if (this.VaccineRow.CurrentStateDefID == VaccineDetails.VaccineDetailsStates.Completed) {
    //        this.messageService.showError(i18n("M23795", "Uygulanmış Aşıları İptal Edemezsiniz."));
    //        return;

    //    } else if (this.VaccineRow.ObjectID == Guid.empty())
    //    {
    //        this.messageService.showError("Kaydedilmemiş Aşıyı İptal Edemezsiniz.");
    //        return;
    //    }
    //    else if (this.VaccineRow.CurrentStateDefID == VaccineDetails.VaccineDetailsStates.New) {
   
    //        let apiUrl: string = '/api/VaccineFollowUpService/CancelVaccine';
    //        that.httpService.post<any>(apiUrl, this.VaccineRow)
    //            .then(response => {
    //                this.messageService.showInfo(i18n("M16831", "İşlem Başarılı."));
    //                this.VaccineRow.CurrentStateDefID = VaccineDetails.VaccineDetailsStates.Canceled;
    //                that.LoadVaccineFollowupFromPatientID();
    //            })
    //            .catch(error => {
    //                this.messageService.showError(error);

    //            });
    //    }
    //}

    refreshDetails() {
        let that = this;
        this.LoadVaccineFollowupFromPatientID();

    }

    onRowRemoving(e) {
        let that = this;
        if (e != null && e.data != null) {
            if (e.data.CurrentStateDefID == VaccineDetails.VaccineDetailsStates.Completed) {
                ServiceLocator.MessageService.showError("Uygulanmış Aşıyı Silemezsiniz.");
                return false;
            } else if (e.data.CurrentStateDefID == VaccineDetails.VaccineDetailsStates.Canceled) {
                ServiceLocator.MessageService.showError("İptal Edilmiş Aşıyı Silemezsiniz.");
                return false;

            } else {
                let apiUrl: string = '/api/VaccineFollowUpService/CancelVaccine';
                that.httpService.post<any>(apiUrl, e.data)
                    .then(response => {
                        this.messageService.showInfo(i18n("M16831", "İşlem Başarılı."));
                        this.refreshDetails();
                        this.VaccineRow = new VaccineDetails();
                    })
                    .catch(error => {
                        this.messageService.showError(error);

                    });
                this.refreshDetails();
            }

        }
        return false;
    }

    onOpenVaccineReport() {

        let reportData: DynamicReportParameters = {

            Code: 'ASITAKVIMRAPORU',
            ReportParams: { PatientID: this.vaccineFollowUpFormViewModel.PatientID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "AŞI TAKVİMİ"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

}



