//$5D1412B3
import { Component, OnInit, Input } from '@angular/core';
import { PhysiotherapyPlannedOrdersFormViewModel, PhysiotherapyOrderComponentInfoViewModel } from './PhysiotherapyPlannedOrdersFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PhysiotherapyOrder } from 'NebulaClient/Model/AtlasClientModel';
import { FTRVucutBolgesi } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyReports } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { PackageProcedureDefinition, ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';



@Component({
    selector: 'PhysiotherapyPlannedOrdersForm',
    templateUrl: './PhysiotherapyPlannedOrdersForm.html',
    providers: [MessageService]
})
export class PhysiotherapyPlannedOrdersForm extends TTVisual.TTForm implements OnInit {
    daySelectionActive: TTVisual.ITTCheckBox; //gün seçimi!
    IsMedulaNotWorking: TTVisual.ITTCheckBox; //Medulasız Rapor Sorgulamak için!
    ApplicationArea: TTVisual.ITTTextBox;
    DiagnosisGroupPhysiotherapyReports: TTVisual.ITTTextBox;
    Dose: TTVisual.ITTTextBox;
    DoseDurationInfo: TTVisual.ITTTextBox;
    Duration: TTVisual.ITTTextBox;
    FinishSession: TTVisual.ITTTextBox;
    FTRApplicationAreaDef: TTVisual.ITTObjectListBox;
    FTRApplicationAreaDefPhysiotherapyReports: TTVisual.ITTObjectListBox;
    IncludeFriday: TTVisual.ITTCheckBox;
    IncludeMonday: TTVisual.ITTCheckBox;
    IncludeSaturday: TTVisual.ITTCheckBox;
    IncludeSunday: TTVisual.ITTCheckBox;
    IncludeThursday: TTVisual.ITTCheckBox;
    IncludeTuesday: TTVisual.ITTCheckBox;
    IncludeWednesday: TTVisual.ITTCheckBox;
    IsAdditionalTreatment: TTVisual.ITTCheckBox;
    IsAdditionalProcess: TTVisual.ITTCheckBox;
    IsPaidTreatment: TTVisual.ITTCheckBox;
    labelApplicationArea: TTVisual.ITTLabel;
    labelDiagnosisGroupPhysiotherapyReports: TTVisual.ITTLabel;
    labelDose: TTVisual.ITTLabel;
    labelDoseDurationInfo: TTVisual.ITTLabel;
    labelDuration: TTVisual.ITTLabel;
    labelFinishSession: TTVisual.ITTLabel;
    labelFTRApplicationAreaDef: TTVisual.ITTLabel;
    labelFTRApplicationAreaDefPhysiotherapyReports: TTVisual.ITTLabel;
    labelPackageProcedure: TTVisual.ITTLabel;
    labelPackageProcedureInfoPhysiotherapyReports: TTVisual.ITTLabel;
    labelPhysiotherapyStartDate: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProcedureObject: TTVisual.ITTLabel;
    labelReportDatePhysiotherapyReports: TTVisual.ITTLabel;
    labelReportEndDatePhysiotherapyReports: TTVisual.ITTLabel;
    labelReportInfoPhysiotherapyReports: TTVisual.ITTLabel;
    labelReportNoPhysiotherapyReports: TTVisual.ITTLabel;
    labelReportStartDatePhysiotherapyReports: TTVisual.ITTLabel;
    labelReportTimePhysiotherapyReports: TTVisual.ITTLabel;
    labelSeansGunSayisi: TTVisual.ITTLabel;
    labelStartSession: TTVisual.ITTLabel;
    labelTreatmentDiagnosisUnit: TTVisual.ITTLabel;
    labelTreatmentProcessTypePhysiotherapyReports: TTVisual.ITTLabel;
    labelTreatmentProperties: TTVisual.ITTLabel;
    labelTreatmentTypePhysiotherapyReports: TTVisual.ITTLabel;
    NotePhysiotherapyOrderDetail: TTVisual.ITTRichTextBoxControlColumn;
    PackageProcedure: TTVisual.ITTObjectListBox;
    PackageProcedureInfoPhysiotherapyReports: TTVisual.ITTTextBox;
    PhysiotherapyOrderDetails: TTVisual.ITTGrid;
    PhysiotherapyStartDate: TTVisual.ITTDateTimePicker;
    PhysiotherapyStatePhysiotherapyOrderDetail: TTVisual.ITTEnumComboBoxColumn;
    PlannedDatePhysiotherapyOrderDetail: TTVisual.ITTDateTimePickerColumn;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProcedureObject: TTVisual.ITTObjectListBox;
    raporTakipNoPhysiotherapyOrderDetail: TTVisual.ITTTextBoxColumn;
    ReportDatePhysiotherapyReports: TTVisual.ITTDateTimePicker;
    ReportEndDatePhysiotherapyReports: TTVisual.ITTDateTimePicker;
    ReportInfoPhysiotherapyReports: TTVisual.ITTTextBox;
    ReportNoPhysiotherapyReports: TTVisual.ITTTextBox;
    ReportStartDatePhysiotherapyReports: TTVisual.ITTDateTimePicker;
    ReportTimePhysiotherapyReports: TTVisual.ITTTextBox;
    ReportType: TTVisual.ITTCheckBox;
    SeansGunSayisi: TTVisual.ITTTextBox;
    SessionNumberPhysiotherapyOrderDetail: TTVisual.ITTTextBoxColumn;
    StartSession: TTVisual.ITTTextBox;
    TreatmentDiagnosisUnit: TTVisual.ITTObjectListBox;
    TreatmentProcessTypePhysiotherapyReports: TTVisual.ITTTextBox;
    TreatmentProperties: TTVisual.ITTTextBox;
    TreatmentTypePhysiotherapyReports: TTVisual.ITTEnumComboBox;
    ttpanel1: TTVisual.ITTPanel;
    public PhysiotherapyOrderDetailsColumns = [];
    //public physiotherapyPlannedOrdersFormViewModel: PhysiotherapyPlannedOrdersFormViewModel = new PhysiotherapyPlannedOrdersFormViewModel();
    public get _PhysiotherapyOrder(): PhysiotherapyOrder {
        return this._TTObject as PhysiotherapyOrder;
    }
    private PhysiotherapyPlannedOrdersForm_DocumentUrl: string = '/api/PhysiotherapyOrderService/PhysiotherapyPlannedOrdersForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('PHYSIOTHERAPYORDER', 'PhysiotherapyPlannedOrdersForm');
        this._DocumentServiceUrl = this.PhysiotherapyPlannedOrdersForm_DocumentUrl;
        //this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    maxFinishSession: number = 1000;
    isFinishSessionChanged: boolean = false;

    reportInfo: string = i18n("M20881", "Rapor Yok");

    //load Panel
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }
    // .\load Panel

    private _physiotherapyPlannedOrdersFormViewModel: PhysiotherapyPlannedOrdersFormViewModel;
    @Input() set physiotherapyPlannedOrdersFormViewModel(value: PhysiotherapyPlannedOrdersFormViewModel) {
        this._physiotherapyPlannedOrdersFormViewModel = value;
        this._ViewModel = this.physiotherapyPlannedOrdersFormViewModel;
        this.loadViewModel();
        this.PreScript();
    }
    get physiotherapyPlannedOrdersFormViewModel(): PhysiotherapyPlannedOrdersFormViewModel {
        return this._physiotherapyPlannedOrdersFormViewModel;
    }


    protected async PreScript() {
        super.PreScript();
        if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports != null) {
            this.PhysiotherapyStartDate.Min = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportStartDate;
            this.PhysiotherapyStartDate.Max = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportEndDate;

            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo != null) {
                this.reportInfo = "Rapor No: " + this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo.toString();
            }

            //-------------------//Kullanıcı, rapor kür sayısına göre limitlenmiş seans oluşturmaya zorlanıyor
            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit != null && this._PhysiotherapyOrder.StartSession != null) {
                this.maxFinishSession = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit + this._PhysiotherapyOrder.StartSession - 1; //Max seans sayısı başlangıç ve bitiş seansları arasındaki fark kadar oluşturulabilir
            } else if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit != null) {
                this.maxFinishSession = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit - 1;
            }

            if (this._PhysiotherapyOrder.FinishSession != null && this._PhysiotherapyOrder.FinishSession > this.maxFinishSession) {
                this.messageService.showReponseError(i18n("M20819", "Rapor Kür Sayısından Fazla Seans Oluşturamazsınız!"));
                this.isFinishSessionChanged = true;
                this._PhysiotherapyOrder.FinishSession = this.maxFinishSession;
            }
            //-------------------

            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports == null || this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo == null) {
                this.showTreatmentTypePopup = true; //Raporu yok ise rapor seçmeye zorlanıyor
            }
        }
    }

    public static getComponentInfoViewModel(physiotherapyRequest: Guid): PhysiotherapyOrderComponentInfoViewModel {
        let componentInfoViewModel = new PhysiotherapyOrderComponentInfoViewModel();
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('ee1a78c9-9c9d-4fb5-9a00-e719b53ca848');
        queryParameters.QueryDefID = new Guid('3c5b47bb-9405-4da2-8bea-282e777e0972');
        let parameters = {};
        parameters['PHYSIOTHERAPYREQUEST'] = new GuidParam(physiotherapyRequest);
        queryParameters.Parameters = parameters;
        componentInfoViewModel.physiotherapyOrderQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'PhysiotherapyPlannedOrdersForm';
        componentInfo.ModuleName = "FizyoterapiModule";
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Fizyoterapi_Modulu/FizyoterapiModule';
        componentInfoViewModel.physiotherapyOrderComponentInfo = componentInfo;
        return componentInfoViewModel;
    }

    public static physiotherapyOrderQueryResultLoaded(e: any) {

        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "TREATMENTDIAGNOSISUNIT") {
                column.caption = i18n("M22778", "Tanı Tedavi Ünitesi");
            }
            if (column.dataField === "FTRAPPLICATIONAREADEF") {
                column.caption = i18n("M24191", "Vücut Bölgesi Tanımı");
            }
            if (column.dataField === "TREATMENTROOM") {
                column.caption = i18n("M23003", "Tedavi Odası");
            }
            if (column.dataField === "PROCEDUREOBJECT") {
                column.caption = i18n("M14485", "FTR İşlemi");
            }
            if (column.dataField === "PROCEDUREDOCTOR") {
                column.caption = i18n("M16928", "İşlemi Yapan Doktor");
            }
            if (column.dataField === "APPLICATIONAREA") {
                column.caption = i18n("M24189", "Vücut Bölgesi Açıklama");
            }
            if (column.dataField === "DOSE") {
                column.caption = i18n("M13284", "Doz");
            }
            if (column.dataField === "DURATION") {
                column.caption = 'Süre/dk';
            }
            if (column.dataField === "FINISHSESSION") {
                column.caption = i18n("M11935", "Bitiş Seansı");
            }
            if (column.dataField === "PHYSIOTHERAPYSTARTDATE") {
                column.caption = i18n("M20717", "Randevu Başlangıç Tarihi");
            }
            if (column.dataField === "PROTOCOLNO") {
                column.caption = i18n("M20566", "Protokol No");
            }
            if (column.dataField === "SEANSGUNSAYISI") {
                column.caption = 'RSeans Gün Sayısı';
            }
            if (column.dataField === "STARTSESSION") {
                column.caption = i18n("M11633", "Başlangıç Seansı");
            }
            if (column.dataField === "TREATMENTPROPERTIES") {
                column.caption = i18n("M23004", "Tedavi Özellikleri");
            }
            if (column.dataField === "TREATMENTSTARTDATETIME") {
                column.caption = i18n("M22980", "Tedavi Başlangıç Tarih Saati");
            }
            if (column.dataField === "DESCRIPTIONFORWORKLIST") {
                column.caption = i18n("M10469", "Açıklama");
            }
        }
    }

    //Rapor İşlemleri
    selectedReportItem: PhysiotherapyReports;
    selectedApplicarionArea: FTRVucutBolgesi;
    selectedPackageProcedureDefinition: PackageProcedureDefinition;
    async selectionReportChanged(value: any): Promise<void> {
        if (value) {
            this.selectedReportItem = value.selectedRowsData[0].ReportObj as PhysiotherapyReports;
            this.selectedApplicarionArea = value.selectedRowsData[0].FTRApplicationAreaDef as FTRVucutBolgesi;
            this.selectedPackageProcedureDefinition = value.selectedRowsData[0].PackageProcedureDefinition as PackageProcedureDefinition;
        }
    }
    rowPrepared(row: any) {
    }

    showPhysiotherapyReportPopup: boolean = false;
    showTreatmentTypePopup: boolean = false;
    ShowTreatmentTypeModal() {
        this.loadPanelOperation(true, '');
        this.showTreatmentTypePopup = true;
        this.loadPanelOperation(false, '');
    }
    async CancelTreatmentType() {
        if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports == null) {
            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
            if (messageResult === "E") {
                this.showTreatmentTypePopup = false;
                //this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsPaidTreatment = true;
                //this.IsPaidTreatment.ForeColor = "#ff0000";

                if ((this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports == null || (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports != null && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo == null)) && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsPaidTreatment == false) {
                    this.physiotherapyPlannedOrdersFormViewModel.IsReportExistsAndCalculateDetail = false;
                    TTVisual.InfoBox.Alert(i18n("M20836", "Rapor seçilmeyen işlemler ücretli yapılmadığı sürece planlaması yapılamaz!"), MessageIconEnum.ErrorMessage);
                }
            }
        } else {
            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo == null) {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                if (messageResult === "E") {
                    this.showTreatmentTypePopup = false;
                    //this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsPaidTreatment = true;

                    if ((this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports == null || (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports != null && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo == null)) && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsPaidTreatment == false) {
                        this.physiotherapyPlannedOrdersFormViewModel.IsReportExistsAndCalculateDetail = false;
                        TTVisual.InfoBox.Alert(i18n("M20836", "Rapor seçilmeyen işlemler ücretli yapılmadığı sürece planlaması yapılamaz!"), MessageIconEnum.ErrorMessage);
                    }
                }
            } else {
                this.showTreatmentTypePopup = false;
            }
        }
    }

    public lastTreatmentType;
    SaveTreatmentType() {
        this.loadPanelOperation(true, i18n("M20888", "Raporlar listeleniyor. Lütfen bekleyiniz."));
        if (this.physiotherapyPlannedOrdersFormViewModel.ReportItemList == null || this.lastTreatmentType != this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType) {
            //!!! TODO TODO TODO NİDA
            this.lastTreatmentType = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType;
            if (this.physiotherapyPlannedOrdersFormViewModel.IsSGKPatient == true && this.physiotherapyPlannedOrdersFormViewModel.IsMedulaNotWorking == false) {//SGK hastası ama medula çalışıyor ise
                this.httpService.post<PhysiotherapyPlannedOrdersFormViewModel>("api/PhysiotherapyOrderService/GetReportInfoByTreatmentType?treatmentType", this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType, PhysiotherapyPlannedOrdersFormViewModel).then(response => {
                    let result: PhysiotherapyPlannedOrdersFormViewModel = <PhysiotherapyPlannedOrdersFormViewModel>response;

                    this.physiotherapyPlannedOrdersFormViewModel.ReportItemList = result.ReportItemList;
                    this.physiotherapyPlannedOrdersFormViewModel.Message = result.Message;

                    this.showTreatmentTypePopup = false;
                    this.showPhysiotherapyReportPopup = true;

                    if (this.physiotherapyPlannedOrdersFormViewModel.Message != null && this.physiotherapyPlannedOrdersFormViewModel.Message != "") {
                        TTVisual.InfoBox.Alert(this.physiotherapyPlannedOrdersFormViewModel.Message);
                    }

                    this.loadPanelOperation(false, '');
                }).catch(error => {
                    TTVisual.InfoBox.Alert("Medula Rapor Okuma Hatası!");
                    this.showTreatmentTypePopup = false;
                    this.loadPanelOperation(false, '');
                });
            } else if (this.physiotherapyPlannedOrdersFormViewModel.IsSGKPatient == true && this.physiotherapyPlannedOrdersFormViewModel.IsMedulaNotWorking == true) {//SGK hastası ama medula çalışmıyor ise
                this.httpService.post<PhysiotherapyPlannedOrdersFormViewModel>("api/PhysiotherapyOrderService/GetInstitutionMedulaReportInfoByTreatmentType?treatmentType", this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType, PhysiotherapyPlannedOrdersFormViewModel).then(response => {
                    let result: PhysiotherapyPlannedOrdersFormViewModel = <PhysiotherapyPlannedOrdersFormViewModel>response;

                    this.physiotherapyPlannedOrdersFormViewModel.ReportItemList = result.ReportItemList;
                    this.physiotherapyPlannedOrdersFormViewModel.Message = result.Message;

                    this.showTreatmentTypePopup = false;
                    this.showPhysiotherapyReportPopup = true;

                    if (this.physiotherapyPlannedOrdersFormViewModel.Message != null && this.physiotherapyPlannedOrdersFormViewModel.Message != "") {
                        TTVisual.InfoBox.Alert(this.physiotherapyPlannedOrdersFormViewModel.Message);
                    }

                    this.loadPanelOperation(false, '');
                }).catch(error => {
                    TTVisual.InfoBox.Alert("Medula Rapor Hatası!");
                    this.showTreatmentTypePopup = false;
                    this.loadPanelOperation(false, '');
                });

            } else {//Kurum Hastası -> SGK hastası değil ise
                this.httpService.post<PhysiotherapyPlannedOrdersFormViewModel>("api/PhysiotherapyOrderService/GetInstitutionReportInfoByTreatmentType?treatmentType", this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType, PhysiotherapyPlannedOrdersFormViewModel).then(response => {
                    let result: PhysiotherapyPlannedOrdersFormViewModel = <PhysiotherapyPlannedOrdersFormViewModel>response;

                    this.physiotherapyPlannedOrdersFormViewModel.ReportItemList = result.ReportItemList;
                    this.physiotherapyPlannedOrdersFormViewModel.Message = result.Message;

                    this.showTreatmentTypePopup = false;
                    this.showPhysiotherapyReportPopup = true;

                    if (this.physiotherapyPlannedOrdersFormViewModel.Message != null && this.physiotherapyPlannedOrdersFormViewModel.Message != "") {
                        TTVisual.InfoBox.Alert(this.physiotherapyPlannedOrdersFormViewModel.Message);
                    }

                    this.loadPanelOperation(false, '');
                }).catch(error => {
                    TTVisual.InfoBox.Alert("Kurum Raporu Hatası");
                    this.showTreatmentTypePopup = false;
                    this.loadPanelOperation(false, '');
                });
            }
        } else {
            this.showTreatmentTypePopup = false;
            this.showPhysiotherapyReportPopup = true;

            if (this.physiotherapyPlannedOrdersFormViewModel.Message != null && this.physiotherapyPlannedOrdersFormViewModel.Message != "") {
                TTVisual.InfoBox.Alert(this.physiotherapyPlannedOrdersFormViewModel.Message);
            }

            this.loadPanelOperation(false, '');
        }
    }
    async CancelPhysiotherapyReport() {
        if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports == null) {
            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
            if (messageResult === "E") {
                this.showPhysiotherapyReportPopup = false;
                this.selectedReportItem = null;

                if ((this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports == null || (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports != null && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo == null)) && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsPaidTreatment == false) {
                    this.physiotherapyPlannedOrdersFormViewModel.IsReportExistsAndCalculateDetail = false;
                    TTVisual.InfoBox.Alert(i18n("M20836", "Rapor seçilmeyen işlemler ücretli yapılmadığı sürece planlaması yapılamaz!"), MessageIconEnum.ErrorMessage);
                }
            }
        } else {
            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo == null) {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                if (messageResult === "E") {
                    this.showPhysiotherapyReportPopup = false;
                    this.selectedReportItem = null;

                    if ((this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports == null || (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports != null && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo == null)) && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsPaidTreatment == false) {
                        this.physiotherapyPlannedOrdersFormViewModel.IsReportExistsAndCalculateDetail = false;
                        TTVisual.InfoBox.Alert(i18n("M20836", "Rapor seçilmeyen işlemler ücretli yapılmadığı sürece planlaması yapılamaz!"), MessageIconEnum.ErrorMessage);
                    }
                }
            } else {
                this.showPhysiotherapyReportPopup = false;
                this.selectedReportItem = null;
            }
        }
    }
    async SavePhysiotherapyReportModal() {
        if (this.selectedReportItem != null) {

            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.DiagnosisGroup = this.selectedReportItem.DiagnosisGroup;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.PackageProcedureInfo = this.selectedReportItem.PackageProcedureInfo;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportDate = this.selectedReportItem.ReportDate;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportEndDate = this.selectedReportItem.ReportEndDate;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportInfo = this.selectedReportItem.ReportInfo;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo = this.selectedReportItem.ReportNo;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportStartDate = this.selectedReportItem.ReportStartDate;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportTime = this.selectedReportItem.ReportTime;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportType = this.selectedReportItem.ReportType;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.TreatmentProcessType = this.selectedReportItem.TreatmentProcessType;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType = this.selectedReportItem.TreatmentType;


            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo != null) {
                this.reportInfo = "Rapor No: " + this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo.toString();
            }

            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PackageProcedure = this.selectedPackageProcedureDefinition;
            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PackageProcedure != null) {
                this.PackageProcedure.ReadOnly = true;
            }

            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef = this.selectedApplicarionArea;
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit = this.selectedReportItem.SessionLimit;

            //-------------------//Kullanıcı, rapor kür sayısına göre limitlenmiş seans oluşturmaya zorlanıyor
            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit != null && this._PhysiotherapyOrder.StartSession != null) {
                this.maxFinishSession = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit + this._PhysiotherapyOrder.StartSession - 1; //Max seans sayısı başlangıç ve bitiş seansları arasındaki fark kadar oluşturulabilir
            } else if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit != null) {
                this.maxFinishSession = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit - 1;
            }

            if (this._PhysiotherapyOrder.FinishSession != null && this._PhysiotherapyOrder.FinishSession > this.maxFinishSession) {
                this.messageService.showReponseError(i18n("M20819", "Rapor Kür Sayısından Fazla Seans Oluşturamazsınız!"));
                this.isFinishSessionChanged = true;
                this._PhysiotherapyOrder.FinishSession = this.maxFinishSession;
            }
            //-------------------

            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.FTRApplicationAreaDef == null) {
                this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.FTRApplicationAreaDef = this.selectedApplicarionArea;
            }

            this.showPhysiotherapyReportPopup = false;
            this.selectedReportItem = null;


            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportStartDate != null) {
                this.PhysiotherapyStartDate.Min = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportStartDate;
            }
            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportEndDate != null) {
                this.PhysiotherapyStartDate.Max = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportEndDate;
            }

            this.physiotherapyPlannedOrdersFormViewModel.IsReportExistsAndCalculateDetail = true;

        } else {

            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports == null) {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                if (messageResult === "E") {
                    this.showPhysiotherapyReportPopup = false;
                    this.selectedReportItem = null;
                }
            } else {
                if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo == null) {
                    let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                    if (messageResult === "E") {
                        this.showPhysiotherapyReportPopup = false;
                        this.selectedReportItem = null;
                    }
                } else {
                    this.showPhysiotherapyReportPopup = false;
                    this.selectedReportItem = null;
                }
            }
        }
    }
    // *****Method declarations end *****

    protected loadViewModel() {
        let that = this;
        //that.physiotherapyPlannedOrdersFormViewModel = this._ViewModel as PhysiotherapyPlannedOrdersFormViewModel;
        that._TTObject = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder;
        //if (this.physiotherapyPlannedOrdersFormViewModel == null)
        //    this.physiotherapyPlannedOrdersFormViewModel = new PhysiotherapyPlannedOrdersFormViewModel();
        if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder == null)
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder = new PhysiotherapyOrder();
        let packageProcedureObjectID = that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder["PackageProcedure"];
        if (packageProcedureObjectID != null && (typeof packageProcedureObjectID === "string")) {
            let packageProcedure = that.physiotherapyPlannedOrdersFormViewModel.PackageProcedureDefinitions.find(o => o.ObjectID.toString() === packageProcedureObjectID.toString());
            if (packageProcedure) {
                that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PackageProcedure = packageProcedure;
            }
        }
        let physiotherapyReportsObjectID = that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder["PhysiotherapyReports"];
        if (physiotherapyReportsObjectID != null && (typeof physiotherapyReportsObjectID === "string")) {
            let physiotherapyReports = that.physiotherapyPlannedOrdersFormViewModel.PhysiotherapyReportss.find(o => o.ObjectID.toString() === physiotherapyReportsObjectID.toString());
            if (physiotherapyReports) {
                that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports = physiotherapyReports;
            }
            if (physiotherapyReports != null) {
                let fTRApplicationAreaDefObjectID = physiotherapyReports["FTRApplicationAreaDef"];
                if (fTRApplicationAreaDefObjectID != null && (typeof fTRApplicationAreaDefObjectID === "string")) {
                    let fTRApplicationAreaDef = that.physiotherapyPlannedOrdersFormViewModel.FTRVucutBolgesis.find(o => o.ObjectID.toString() === fTRApplicationAreaDefObjectID.toString());
                    if (fTRApplicationAreaDef) {
                        physiotherapyReports.FTRApplicationAreaDef = fTRApplicationAreaDef;
                    }
                }
            }
        }
        that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyOrderDetails = that.physiotherapyPlannedOrdersFormViewModel.PhysiotherapyOrderDetailsGridList;
        for (let detailItem of that.physiotherapyPlannedOrdersFormViewModel.PhysiotherapyOrderDetailsGridList) {
        }
        let procedureDoctorObjectID = that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
            let procedureDoctor = that.physiotherapyPlannedOrdersFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.ProcedureDoctor = procedureDoctor;
            }
        }
        let procedureObjectObjectID = that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
            let procedureObject = that.physiotherapyPlannedOrdersFormViewModel.PhysiotherapyDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
            if (procedureObject) {
                that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.ProcedureObject = procedureObject;
            }
        }
        let fTRApplicationAreaDefObjectID = that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder["FTRApplicationAreaDef"];
        if (fTRApplicationAreaDefObjectID != null && (typeof fTRApplicationAreaDefObjectID === "string")) {
            let fTRApplicationAreaDef = that.physiotherapyPlannedOrdersFormViewModel.FTRVucutBolgesis.find(o => o.ObjectID.toString() === fTRApplicationAreaDefObjectID.toString());
            if (fTRApplicationAreaDef) {
                that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.FTRApplicationAreaDef = fTRApplicationAreaDef;
            }
        }
        let treatmentDiagnosisUnitObjectID = that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder["TreatmentDiagnosisUnit"];
        if (treatmentDiagnosisUnitObjectID != null && (typeof treatmentDiagnosisUnitObjectID === "string")) {
            let treatmentDiagnosisUnit = that.physiotherapyPlannedOrdersFormViewModel.ResTreatmentDiagnosisUnits.find(o => o.ObjectID.toString() === treatmentDiagnosisUnitObjectID.toString());
            if (treatmentDiagnosisUnit) {
                that.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.TreatmentDiagnosisUnit = treatmentDiagnosisUnit;
            }
        }

        //this.showTreatmentTypePopup = true;
        if (this.physiotherapyPlannedOrdersFormViewModel.IsReadOnlyFields == true) {


            //Son girilen veriler default set ediliyor
            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyStartDate != null) {
                //this.PhysiotherapyStartDate.ReadOnly = true;
            }

            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.SeansGunSayisi != null || this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.SeansGunSayisi != 0) {
                //this.SeansGunSayisi.ReadOnly = true;
                this.daySelectionActive.Value = false;
                this.onDaySelectionActiveChanged(this.daySelectionActive.Value);
                //this.daySelectionActive.ReadOnly = true;

                this.IncludeFriday.ReadOnly = true;
                this.IncludeMonday.ReadOnly = true;
                this.IncludeThursday.ReadOnly = true;
                this.IncludeTuesday.ReadOnly = true;
                this.IncludeWednesday.ReadOnly = true;
            }

            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeSaturday != null) {
                //this.IncludeSaturday.ReadOnly = true;
            }
            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeSunday != null) {
                //this.IncludeSunday.ReadOnly = true;
            }

            if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeFriday != null ||
                this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeMonday != null ||
                this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeThursday != null ||
                this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeTuesday != null ||
                this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeWednesday != null) {
                //this.SeansGunSayisi.ReadOnly = true;
                this.daySelectionActive.Value = true;
                this.onDaySelectionActiveChanged(this.daySelectionActive.Value);
                //this.daySelectionActive.ReadOnly = true;

                this.IncludeFriday.ReadOnly = true;
                this.IncludeMonday.ReadOnly = true;
                this.IncludeThursday.ReadOnly = true;
                this.IncludeTuesday.ReadOnly = true;
                this.IncludeWednesday.ReadOnly = true;
            }
        }


        if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.SeansGunSayisi != null && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.SeansGunSayisi != 0) {
            this.daySelectionActive.Value = false; //Readonly field olmasa bile gün seçimi aktif olmayabilir
        }
        if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeFriday != null ||
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeMonday != null ||
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeThursday != null ||
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeTuesday != null ||
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeWednesday != null) {

            this.daySelectionActive.Value = true; //Readonly field olmasa bile gün seçimi aktif olmayabilir
        }

        if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsAdditionalTreatment == true) {
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyStartDate = this.physiotherapyPlannedOrdersFormViewModel.endDate;
        } else {
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyStartDate = this.physiotherapyPlannedOrdersFormViewModel.startDate;
        }
        if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsPaidTreatment == null) {
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsPaidTreatment = false;
        }

        if (this.physiotherapyPlannedOrdersFormViewModel.IsPaymentObject == true) {
            this.IsPaidTreatment.ReadOnly = true;
        }

        let procedureObjectListTarget = new Array<ProcedureDefinition>();
        if (this.physiotherapyPlannedOrdersFormViewModel.ProcedureObjectList != null) {
            const procedureObjectList = this.physiotherapyPlannedOrdersFormViewModel.ProcedureObjectList;
            for (const sourceProcedureObj of procedureObjectList) {
                const targetProcedureObj = this.physiotherapyPlannedOrdersFormViewModel.ProcedureObjectDataSource.find(p => p.ObjectID.toString() === sourceProcedureObj.ObjectID.toString());
                if (targetProcedureObj) {
                    procedureObjectListTarget.push(targetProcedureObj);
                }
            }

            this.physiotherapyPlannedOrdersFormViewModel.ProcedureObjectList = procedureObjectListTarget;
        }
    }

    async ngOnInit() {
        //await this.load();
    }

    public onApplicationAreaChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.ApplicationArea != event) {
                this._PhysiotherapyOrder.ApplicationArea = event;
            }
        }
    }

    public onDiagnosisGroupPhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.DiagnosisGroup != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.DiagnosisGroup = event;
            }
        }
    }

    public onDoseChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.Dose != event) {
                this._PhysiotherapyOrder.Dose = event;
            }
        }
    }

    public onDoseDurationInfoChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.DoseDurationInfo != event) {
                this._PhysiotherapyOrder.DoseDurationInfo = event;
            }
        }
    }

    public onDurationChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.Duration != event) {
                this._PhysiotherapyOrder.Duration = event;
            }
        }
    }

    public onFinishSessionChanged(event): void {
        //-------------------//Kullanıcı, rapor kür sayısına göre limitlenmiş seans oluşturmaya zorlanıyor
        if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit != null && this._PhysiotherapyOrder.StartSession != null) {
            this.maxFinishSession = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit + this._PhysiotherapyOrder.StartSession - 1; //Max seans sayısı başlangıç ve bitiş seansları arasındaki fark kadar oluşturulabilir
        } else if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit != null) {
            this.maxFinishSession = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit - 1;
        }

        if (this._PhysiotherapyOrder.FinishSession != null && this._PhysiotherapyOrder.FinishSession > this.maxFinishSession) {
            this.messageService.showReponseError(i18n("M20819", "Rapor Kür Sayısından Fazla Seans Oluşturamazsınız!"));
            this.isFinishSessionChanged = true;
            this._PhysiotherapyOrder.FinishSession = this.maxFinishSession;
        }
        //-------------------
        if (this._PhysiotherapyOrder.StartSession != null && this._PhysiotherapyOrder.FinishSession != null) {
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.SessionCount = this._PhysiotherapyOrder.FinishSession - this._PhysiotherapyOrder.StartSession + 1;
        }
    }

    public onFTRApplicationAreaDefChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.FTRApplicationAreaDef != event) {
                this._PhysiotherapyOrder.FTRApplicationAreaDef = event;
            }
        }
    }

    public onFTRApplicationAreaDefPhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef = event;
            }
        }
    }

    public onIncludeFridayChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.IncludeFriday != event) {
                this._PhysiotherapyOrder.IncludeFriday = event;
            }
        }
    }

    public onIncludeMondayChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.IncludeMonday != event) {
                this._PhysiotherapyOrder.IncludeMonday = event;
            }
        }
    }

    public onIncludeSaturdayChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.IncludeSaturday != event) {
                this._PhysiotherapyOrder.IncludeSaturday = event;
            }
        }
    }

    public onIncludeSundayChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.IncludeSunday != event) {
                this._PhysiotherapyOrder.IncludeSunday = event;
            }
        }
    }

    public onIncludeThursdayChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.IncludeThursday != event) {
                this._PhysiotherapyOrder.IncludeThursday = event;
            }
        }
    }

    public onIncludeTuesdayChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.IncludeTuesday != event) {
                this._PhysiotherapyOrder.IncludeTuesday = event;
            }
        }
    }

    public onIncludeWednesdayChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.IncludeWednesday != event) {
                this._PhysiotherapyOrder.IncludeWednesday = event;
            }
        }
    }

    public onIsAdditionalTreatmentChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.IsAdditionalTreatment != event) {
                this._PhysiotherapyOrder.IsAdditionalTreatment = event;
                if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsAdditionalTreatment == true) {
                    this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyStartDate = this.physiotherapyPlannedOrdersFormViewModel.endDate;
                } else {
                    this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyStartDate = this.physiotherapyPlannedOrdersFormViewModel.startDate;
                }
            }
        }
    }

    public onIsPaidTreatmentChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.IsPaidTreatment != event) {
                this._PhysiotherapyOrder.IsPaidTreatment = event;
                if ((this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports == null || (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports != null && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.ReportNo == null)) && this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IsPaidTreatment == false) {
                    this.physiotherapyPlannedOrdersFormViewModel.IsReportExistsAndCalculateDetail = false;
                    TTVisual.InfoBox.Alert(i18n("M20836", "Rapor seçilmeyen işlemler ücretli yapılmadığı sürece planlaması yapılamaz!"), MessageIconEnum.ErrorMessage);
                } else {
                    this.physiotherapyPlannedOrdersFormViewModel.IsReportExistsAndCalculateDetail = true;
                }
            }
        }
    }

    public onIsAdditionalProcessChanged(event): void {
        if (event != null) {
            this.IsAdditionalProcess = event;
            this.physiotherapyPlannedOrdersFormViewModel.IsAdditionalProcess = event;
        }
    }

    public onIsMedulaNotWorkingChanged(event): void {
        if (event != null) {
            this.IsMedulaNotWorking.Value = event;
            this.physiotherapyPlannedOrdersFormViewModel.IsMedulaNotWorking = event;
        }
    }

    public onPackageProcedureChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.PackageProcedure != event) {
                this._PhysiotherapyOrder.PackageProcedure = event;
            }
        }
    }

    public onPackageProcedureInfoPhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.PackageProcedureInfo != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.PackageProcedureInfo = event;
            }
        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.ProcedureDoctor != event) {
                this._PhysiotherapyOrder.ProcedureDoctor = event;
            }
        }
    }

    public onProcedureObjectChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.ProcedureObject != event) {
                this._PhysiotherapyOrder.ProcedureObject = event;
            }
        }
    }

    public onReportDatePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportDate != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportDate = event;
            }
        }
    }

    public onReportEndDatePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportEndDate != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportEndDate = event;
            }
        }
    }

    public onReportInfoPhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportInfo != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportInfo = event;
            }
        }
    }

    public onReportNoPhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportNo != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportNo = event;
            }
        }
    }

    public onReportStartDatePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportStartDate != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportStartDate = event;
            }
        }
    }

    public onReportTimePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportTime != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportTime = event;
            }
        }
    }

    public onReportTypeChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportType != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportType = event;
            }
        }
    }

    public onSeansGunSayisiChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.SeansGunSayisi != event) {
                if (event > 5) {
                    this.messageService.showReponseError(i18n("M21480", "Seans Gün Aralığı 5 İş Gününden Fazla Olamaz!"));
                    this.SeansGunSayisi.Text = this._PhysiotherapyOrder.SeansGunSayisi != null ? this._PhysiotherapyOrder.SeansGunSayisi.toString() : "";
                } else {
                    this._PhysiotherapyOrder.SeansGunSayisi = event;
                }

            }
        }
    }

    public onStartSessionChanged(event): void {

        //-------------------//Kullanıcı, rapor kür sayısına göre limitlenmiş seans oluşturmaya zorlanıyor
        if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit != null && this._PhysiotherapyOrder.StartSession != null) {
            this.maxFinishSession = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit + this._PhysiotherapyOrder.StartSession - 1; //Max seans sayısı başlangıç ve bitiş seansları arasındaki fark kadar oluşturulabilir
        } else if (this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit != null) {
            this.maxFinishSession = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.SessionLimit - 1;
        }

        if (this._PhysiotherapyOrder.FinishSession != null && this._PhysiotherapyOrder.FinishSession > this.maxFinishSession) {
            this.messageService.showReponseError(i18n("M20819", "Rapor Kür Sayısından Fazla Seans Oluşturamazsınız!"));
            this.isFinishSessionChanged = true;
            this._PhysiotherapyOrder.FinishSession = this.maxFinishSession;
        }
        //-------------------
        if (this._PhysiotherapyOrder.StartSession != null && this._PhysiotherapyOrder.FinishSession != null) {
            this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.SessionCount = this._PhysiotherapyOrder.FinishSession - this._PhysiotherapyOrder.StartSession + 1;
        }
    }

    public onTreatmentDiagnosisUnitChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.TreatmentDiagnosisUnit != event) {
                this._PhysiotherapyOrder.TreatmentDiagnosisUnit = event;
            }
        }
    }

    public onTreatmentProcessTypePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.TreatmentProcessType != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.TreatmentProcessType = event;
            }
        }
    }

    public onTreatmentPropertiesChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.TreatmentProperties != event) {
                this._PhysiotherapyOrder.TreatmentProperties = event;
            }
        }
    }

    public onPhysiotherapyStartDateChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.PhysiotherapyStartDate != event) {
                //this._PhysiotherapyOrder.PhysiotherapyStartDate = event.toString();
                this._PhysiotherapyOrder.PhysiotherapyStartDate = event;
            }
        }
    }

    public onTreatmentTypePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType = event;
            }
        }
    }
    public onDaySelectionActiveChanged(event): void {
        if (event != null) {
            //this.physiotherapyPlannedOrdersFormViewModel.daySelectionActive = event;
            if (this.daySelectionActive.Value !== event) {
                this.daySelectionActive.Value = event;

                if (this.daySelectionActive.Value == false) {

                    this.IncludeFriday.ReadOnly = true;
                    this.IncludeMonday.ReadOnly = true;
                    this.IncludeThursday.ReadOnly = true;
                    this.IncludeTuesday.ReadOnly = true;
                    this.IncludeWednesday.ReadOnly = true;

                    this.IncludeFriday.Value = null;
                    this.IncludeMonday.Value = null;
                    this.IncludeThursday.Value = null;
                    this.IncludeTuesday.Value = null;
                    this.IncludeWednesday.Value = null;

                    this.SeansGunSayisi.ReadOnly = false;
                } else {
                    this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.SeansGunSayisi = null;
                    this.SeansGunSayisi.ReadOnly = true;


                    this.IncludeFriday.ReadOnly = false;
                    this.IncludeMonday.ReadOnly = false;
                    this.IncludeThursday.ReadOnly = false;
                    this.IncludeTuesday.ReadOnly = false;
                    this.IncludeWednesday.ReadOnly = false;

                }
            }
            if (this.physiotherapyPlannedOrdersFormViewModel.daySelectionActive !== event) {
                this.physiotherapyPlannedOrdersFormViewModel.daySelectionActive = event;


                if (this.daySelectionActive.Value == false) {

                    this.IncludeFriday.ReadOnly = true;
                    this.IncludeMonday.ReadOnly = true;
                    this.IncludeThursday.ReadOnly = true;
                    this.IncludeTuesday.ReadOnly = true;
                    this.IncludeWednesday.ReadOnly = true;

                    this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeFriday = null;
                    this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeMonday = null;
                    this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeThursday = null;
                    this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeTuesday = null;
                    this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.IncludeWednesday = null;

                    this.SeansGunSayisi.ReadOnly = false;
                } else {
                    this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.SeansGunSayisi = null;
                    this.SeansGunSayisi.ReadOnly = true;


                    this.IncludeFriday.ReadOnly = false;
                    this.IncludeMonday.ReadOnly = false;
                    this.IncludeThursday.ReadOnly = false;
                    this.IncludeTuesday.ReadOnly = false;
                    this.IncludeWednesday.ReadOnly = false;

                }
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.PhysiotherapyStartDate, "Value", this.__ttObject, "PhysiotherapyStartDate");
        redirectProperty(this.TreatmentProperties, "Text", this.__ttObject, "TreatmentProperties");
        redirectProperty(this.Duration, "Text", this.__ttObject, "Duration");
        redirectProperty(this.SeansGunSayisi, "Text", this.__ttObject, "SeansGunSayisi");
        redirectProperty(this.IsAdditionalTreatment, "Value", this.__ttObject, "IsAdditionalTreatment");
        redirectProperty(this.IsAdditionalProcess, "Value", this.__ttObject, "IsAdditionalProcess");
        redirectProperty(this.IsMedulaNotWorking, "Value", this.__ttObject, "IsMedulaNotWorking");
        redirectProperty(this.Dose, "Text", this.__ttObject, "Dose");
        redirectProperty(this.StartSession, "Text", this.__ttObject, "StartSession");
        redirectProperty(this.IsPaidTreatment, "Value", this.__ttObject, "IsPaidTreatment");
        redirectProperty(this.ApplicationArea, "Text", this.__ttObject, "ApplicationArea");
        redirectProperty(this.DoseDurationInfo, "Text", this.__ttObject, "DoseDurationInfo");
        redirectProperty(this.FinishSession, "Text", this.__ttObject, "FinishSession");
        redirectProperty(this.IncludeMonday, "Value", this.__ttObject, "IncludeMonday");
        redirectProperty(this.IncludeTuesday, "Value", this.__ttObject, "IncludeTuesday");
        redirectProperty(this.IncludeWednesday, "Value", this.__ttObject, "IncludeWednesday");
        redirectProperty(this.IncludeThursday, "Value", this.__ttObject, "IncludeThursday");
        redirectProperty(this.IncludeFriday, "Value", this.__ttObject, "IncludeFriday");
        redirectProperty(this.IncludeSaturday, "Value", this.__ttObject, "IncludeSaturday");
        redirectProperty(this.IncludeSunday, "Value", this.__ttObject, "IncludeSunday");
        redirectProperty(this.ReportNoPhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.ReportNo");
        redirectProperty(this.ReportTimePhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.ReportTime");
        redirectProperty(this.ReportType, "Value", this.__ttObject, "PhysiotherapyReports.ReportType");
        redirectProperty(this.TreatmentTypePhysiotherapyReports, "Value", this.__ttObject, "PhysiotherapyReports.TreatmentType");
        redirectProperty(this.DiagnosisGroupPhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.DiagnosisGroup");
        redirectProperty(this.ReportDatePhysiotherapyReports, "Value", this.__ttObject, "PhysiotherapyReports.ReportDate");
        redirectProperty(this.ReportStartDatePhysiotherapyReports, "Value", this.__ttObject, "PhysiotherapyReports.ReportStartDate");
        redirectProperty(this.ReportEndDatePhysiotherapyReports, "Value", this.__ttObject, "PhysiotherapyReports.ReportEndDate");
        redirectProperty(this.ReportInfoPhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.ReportInfo");
        redirectProperty(this.PackageProcedureInfoPhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.PackageProcedureInfo");
        redirectProperty(this.TreatmentProcessTypePhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.TreatmentProcessType");
    }

    public initFormControls(): void {

        this.daySelectionActive = new TTVisual.TTCheckBox();
        this.daySelectionActive.Value = false;
        this.daySelectionActive.Text = i18n("M15001", "Gün Seçimi Yap");
        this.daySelectionActive.Title = i18n("M15001", "Gün Seçimi Yap");
        this.daySelectionActive.Name = 'daySelectionActive';
        this.daySelectionActive.ReadOnly = false;
        this.daySelectionActive.TabIndex = 184;

        this.IsPaidTreatment = new TTVisual.TTCheckBox();
        this.IsPaidTreatment.Value = false;
        this.IsPaidTreatment.Text = i18n("M23898", "Ücretli Tedavi");
        this.IsPaidTreatment.Title = i18n("M23898", "Ücretli Tedavi");
        this.IsPaidTreatment.Name = "IsPaidTreatment";
        this.IsPaidTreatment.TabIndex = 96;

        this.labelPackageProcedure = new TTVisual.TTLabel();
        this.labelPackageProcedure.Text = i18n("M20150", "Paket Hizmet");
        this.labelPackageProcedure.Name = "labelPackageProcedure";
        this.labelPackageProcedure.TabIndex = 95;

        this.PackageProcedure = new TTVisual.TTObjectListBox();
        this.PackageProcedure.Required = true;
        this.PackageProcedure.ListDefName = "FTRPackageProcedureList";
        this.PackageProcedure.Name = "PackageProcedure";
        this.PackageProcedure.TabIndex = 94;

        this.IsAdditionalTreatment = new TTVisual.TTCheckBox();
        this.IsAdditionalTreatment.Value = false;
        this.IsAdditionalTreatment.Text = i18n("M13533", "Ek Tedavi");
        this.IsAdditionalTreatment.Title = i18n("M13533", "Ek Tedavi");
        this.IsAdditionalTreatment.Name = "IsAdditionalTreatment";
        this.IsAdditionalTreatment.TabIndex = 93;

        this.IsAdditionalProcess = new TTVisual.TTCheckBox();
        this.IsAdditionalProcess.Value = false;
        this.IsAdditionalProcess.Text = i18n("M13523", "Ek İşlem");
        this.IsAdditionalProcess.Title = i18n("M13523", "Ek İşlem");
        this.IsAdditionalProcess.Name = "IsAdditionalProcess";
        this.IsAdditionalProcess.TabIndex = 93;

        this.IsMedulaNotWorking = new TTVisual.TTCheckBox();
        this.IsMedulaNotWorking.Value = false;
        this.IsMedulaNotWorking.Text = i18n("M18845", "Medulasız işlem");
        this.IsMedulaNotWorking.Title = i18n("M18845", "Medulasız işlem");
        this.IsMedulaNotWorking.Name = "IsMedulaNotWorking";
        this.IsMedulaNotWorking.TabIndex = 93;

        this.labelTreatmentProperties = new TTVisual.TTLabel();
        this.labelTreatmentProperties.Text = i18n("M10469", "Açıklama");
        this.labelTreatmentProperties.Name = "labelTreatmentProperties";
        this.labelTreatmentProperties.TabIndex = 92;

        this.TreatmentProperties = new TTVisual.TTTextBox();
        //this.TreatmentProperties.Required = true;
        this.TreatmentProperties.BackColor = "#FFE3C6";
        this.TreatmentProperties.Name = "TreatmentProperties";
        this.TreatmentProperties.TabIndex = 91;

        this.DoseDurationInfo = new TTVisual.TTTextBox();
        this.DoseDurationInfo.Name = "DoseDurationInfo";
        this.DoseDurationInfo.TabIndex = 89;

        this.Dose = new TTVisual.TTTextBox();
        this.Dose.Required = true;
        this.Dose.BackColor = "#FFE3C6";
        this.Dose.Name = "Dose";
        this.Dose.TabIndex = 78;

        this.StartSession = new TTVisual.TTTextBox();
        this.StartSession.Required = true;
        this.StartSession.BackColor = "#FFE3C6";
        this.StartSession.Name = "StartSession";
        this.StartSession.TabIndex = 34;

        this.SeansGunSayisi = new TTVisual.TTTextBox();
        this.SeansGunSayisi.Name = "SeansGunSayisi";
        this.SeansGunSayisi.TabIndex = 32;
        this.SeansGunSayisi.ReadOnly = false;

        this.FinishSession = new TTVisual.TTTextBox();
        this.FinishSession.Required = true;
        this.FinishSession.BackColor = "#FFE3C6";
        this.FinishSession.Name = "FinishSession";
        this.FinishSession.TabIndex = 16;

        this.Duration = new TTVisual.TTTextBox();
        this.Duration.Required = true;
        this.Duration.BackColor = "#FFE3C6";
        this.Duration.Name = "Duration";
        this.Duration.TabIndex = 14;

        this.ApplicationArea = new TTVisual.TTTextBox();
        //this.ApplicationArea.Required = true;
        this.ApplicationArea.BackColor = "#FFE3C6";
        this.ApplicationArea.Name = "ApplicationArea";
        this.ApplicationArea.TabIndex = 10;

        this.labelDoseDurationInfo = new TTVisual.TTLabel();
        this.labelDoseDurationInfo.Text = "Süre/Doz Açıklama";
        this.labelDoseDurationInfo.Name = "labelDoseDurationInfo";
        this.labelDoseDurationInfo.TabIndex = 90;

        this.labelPhysiotherapyStartDate = new TTVisual.TTLabel();
        this.labelPhysiotherapyStartDate.Text = i18n("M20717", "Randevu Başlangıç Tarihi");
        this.labelPhysiotherapyStartDate.Name = "labelPhysiotherapyStartDate";
        this.labelPhysiotherapyStartDate.TabIndex = 88;

        this.PhysiotherapyStartDate = new TTVisual.TTDateTimePicker();
        this.PhysiotherapyStartDate.Required = true;
        this.PhysiotherapyStartDate.BackColor = "#F0F0F0";
        //this.PhysiotherapyStartDate.BackColor = "#FFE3C6";
        this.PhysiotherapyStartDate.Format = DateTimePickerFormat.Long;
        this.PhysiotherapyStartDate.Name = "PhysiotherapyStartDate";
        this.PhysiotherapyStartDate.TabIndex = 87;


        this.PhysiotherapyStartDate.CustomFormat = "";
        //this.PhysiotherapyStartDate.Enabled = false;
        this.PhysiotherapyStartDate.ReadOnly = false;
        this.PhysiotherapyStartDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";



        this.ttpanel1 = new TTVisual.TTPanel();
        this.ttpanel1.AutoSize = true;
        this.ttpanel1.Name = "ttpanel1";
        this.ttpanel1.TabIndex = 86;

        this.labelReportNoPhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportNoPhysiotherapyReports.Text = i18n("M20824", "Rapor Numarası");
        this.labelReportNoPhysiotherapyReports.Name = "labelReportNoPhysiotherapyReports";
        this.labelReportNoPhysiotherapyReports.TabIndex = 65;

        this.labelDiagnosisGroupPhysiotherapyReports = new TTVisual.TTLabel();
        this.labelDiagnosisGroupPhysiotherapyReports.Text = i18n("M22755", "Tanı Grubu");
        this.labelDiagnosisGroupPhysiotherapyReports.Name = "labelDiagnosisGroupPhysiotherapyReports";
        this.labelDiagnosisGroupPhysiotherapyReports.TabIndex = 43;

        this.TreatmentTypePhysiotherapyReports = new TTVisual.TTEnumComboBox();
        this.TreatmentTypePhysiotherapyReports.DataTypeName = "TreatmentQueryReportTypeEnum";
        this.TreatmentTypePhysiotherapyReports.Name = "TreatmentTypePhysiotherapyReports";
        this.TreatmentTypePhysiotherapyReports.TabIndex = 54;

        this.labelTreatmentTypePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelTreatmentTypePhysiotherapyReports.Text = i18n("M23037", "Tedavi Türü");
        this.labelTreatmentTypePhysiotherapyReports.Name = "labelTreatmentTypePhysiotherapyReports";
        this.labelTreatmentTypePhysiotherapyReports.TabIndex = 55;

        this.FTRApplicationAreaDefPhysiotherapyReports = new TTVisual.TTObjectListBox();
        this.FTRApplicationAreaDefPhysiotherapyReports.ListDefName = "FTRVucutBolgesiTTObjectListDefinition";
        this.FTRApplicationAreaDefPhysiotherapyReports.Name = "FTRApplicationAreaDefPhysiotherapyReports";
        this.FTRApplicationAreaDefPhysiotherapyReports.TabIndex = 56;

        this.TreatmentProcessTypePhysiotherapyReports = new TTVisual.TTTextBox();
        this.TreatmentProcessTypePhysiotherapyReports.Name = "TreatmentProcessTypePhysiotherapyReports";
        this.TreatmentProcessTypePhysiotherapyReports.TabIndex = 75;

        this.labelFTRApplicationAreaDefPhysiotherapyReports = new TTVisual.TTLabel();
        this.labelFTRApplicationAreaDefPhysiotherapyReports.Text = i18n("M24191", "Vücut Bölgesi Tanımı");
        this.labelFTRApplicationAreaDefPhysiotherapyReports.Name = "labelFTRApplicationAreaDefPhysiotherapyReports";
        this.labelFTRApplicationAreaDefPhysiotherapyReports.TabIndex = 57;

        this.PackageProcedureInfoPhysiotherapyReports = new TTVisual.TTTextBox();
        this.PackageProcedureInfoPhysiotherapyReports.Name = "PackageProcedureInfoPhysiotherapyReports";
        this.PackageProcedureInfoPhysiotherapyReports.TabIndex = 73;

        this.labelReportInfoPhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportInfoPhysiotherapyReports.Text = i18n("M20778", "Rapor Bilgisi");
        this.labelReportInfoPhysiotherapyReports.Name = "labelReportInfoPhysiotherapyReports";
        this.labelReportInfoPhysiotherapyReports.TabIndex = 61;

        this.ReportTimePhysiotherapyReports = new TTVisual.TTTextBox();
        this.ReportTimePhysiotherapyReports.Name = "ReportTimePhysiotherapyReports";
        this.ReportTimePhysiotherapyReports.TabIndex = 68;

        this.ReportEndDatePhysiotherapyReports = new TTVisual.TTDateTimePicker();
        this.ReportEndDatePhysiotherapyReports.Format = DateTimePickerFormat.Long;
        this.ReportEndDatePhysiotherapyReports.Name = "ReportEndDatePhysiotherapyReports";
        this.ReportEndDatePhysiotherapyReports.TabIndex = 62;

        this.ReportNoPhysiotherapyReports = new TTVisual.TTTextBox();
        this.ReportNoPhysiotherapyReports.Name = "ReportNoPhysiotherapyReports";
        this.ReportNoPhysiotherapyReports.TabIndex = 64;

        this.labelReportEndDatePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportEndDatePhysiotherapyReports.Text = i18n("M18791", "Medula Rapor Bitiş Tarihi");
        this.labelReportEndDatePhysiotherapyReports.Name = "labelReportEndDatePhysiotherapyReports";
        this.labelReportEndDatePhysiotherapyReports.TabIndex = 63;

        this.ReportInfoPhysiotherapyReports = new TTVisual.TTTextBox();
        this.ReportInfoPhysiotherapyReports.Name = "ReportInfoPhysiotherapyReports";
        this.ReportInfoPhysiotherapyReports.TabIndex = 60;

        this.ReportStartDatePhysiotherapyReports = new TTVisual.TTDateTimePicker();
        this.ReportStartDatePhysiotherapyReports.Format = DateTimePickerFormat.Long;
        this.ReportStartDatePhysiotherapyReports.Name = "ReportStartDatePhysiotherapyReports";
        this.ReportStartDatePhysiotherapyReports.TabIndex = 66;

        this.DiagnosisGroupPhysiotherapyReports = new TTVisual.TTTextBox();
        this.DiagnosisGroupPhysiotherapyReports.Name = "DiagnosisGroupPhysiotherapyReports";
        this.DiagnosisGroupPhysiotherapyReports.TabIndex = 42;

        this.labelReportStartDatePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportStartDatePhysiotherapyReports.Text = i18n("M18789", "Medula Rapor Başlangıç Tarihi");
        this.labelReportStartDatePhysiotherapyReports.Name = "labelReportStartDatePhysiotherapyReports";
        this.labelReportStartDatePhysiotherapyReports.TabIndex = 67;

        this.labelReportTimePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportTimePhysiotherapyReports.Text = i18n("M20850", "Rapor Süresi");
        this.labelReportTimePhysiotherapyReports.Name = "labelReportTimePhysiotherapyReports";
        this.labelReportTimePhysiotherapyReports.TabIndex = 69;

        this.ReportDatePhysiotherapyReports = new TTVisual.TTDateTimePicker();
        this.ReportDatePhysiotherapyReports.Format = DateTimePickerFormat.Long;
        this.ReportDatePhysiotherapyReports.Name = "ReportDatePhysiotherapyReports";
        this.ReportDatePhysiotherapyReports.TabIndex = 70;

        this.labelReportDatePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportDatePhysiotherapyReports.Text = "Medula Rapor Tarihi";
        this.labelReportDatePhysiotherapyReports.Name = "labelReportDatePhysiotherapyReports";
        this.labelReportDatePhysiotherapyReports.TabIndex = 71;

        this.ReportType = new TTVisual.TTCheckBox();
        this.ReportType.Value = false;
        this.ReportType.Text = i18n("M20870", "Rapor Türü : 1 ise Heyet Raporu, 0 ise Tek Hekim Raporu");
        this.ReportType.Name = "ReportType";
        this.ReportType.TabIndex = 72;

        this.labelPackageProcedureInfoPhysiotherapyReports = new TTVisual.TTLabel();
        this.labelPackageProcedureInfoPhysiotherapyReports.Text = i18n("M20170", "Paket Numarası");
        this.labelPackageProcedureInfoPhysiotherapyReports.Name = "labelPackageProcedureInfoPhysiotherapyReports";
        this.labelPackageProcedureInfoPhysiotherapyReports.TabIndex = 74;

        this.labelTreatmentProcessTypePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelTreatmentProcessTypePhysiotherapyReports.Text = "Tedavi Türü; A:Ayaktan, Y:Yatarak";
        this.labelTreatmentProcessTypePhysiotherapyReports.Name = "labelTreatmentProcessTypePhysiotherapyReports";
        this.labelTreatmentProcessTypePhysiotherapyReports.TabIndex = 76;

        this.labelDose = new TTVisual.TTLabel();
        this.labelDose.Text = i18n("M13284", "Doz");
        this.labelDose.Name = "labelDose";
        this.labelDose.TabIndex = 79;

        this.PhysiotherapyOrderDetails = new TTVisual.TTGrid();
        this.PhysiotherapyOrderDetails.Name = "PhysiotherapyOrderDetails";
        this.PhysiotherapyOrderDetails.TabIndex = 77;

        this.NotePhysiotherapyOrderDetail = new TTVisual.TTRichTextBoxControlColumn();
        this.NotePhysiotherapyOrderDetail.DataMember = "Note";
        this.NotePhysiotherapyOrderDetail.DisplayIndex = 0;
        this.NotePhysiotherapyOrderDetail.HeaderText = i18n("M14433", "Fizyoterapist Notu");
        this.NotePhysiotherapyOrderDetail.Name = "NotePhysiotherapyOrderDetail";
        this.NotePhysiotherapyOrderDetail.Width = 80;

        this.PhysiotherapyStatePhysiotherapyOrderDetail = new TTVisual.TTEnumComboBoxColumn();
        this.PhysiotherapyStatePhysiotherapyOrderDetail.DataMember = "PhysiotherapyState";
        this.PhysiotherapyStatePhysiotherapyOrderDetail.DisplayIndex = 1;
        this.PhysiotherapyStatePhysiotherapyOrderDetail.HeaderText = "Durum";
        this.PhysiotherapyStatePhysiotherapyOrderDetail.Name = "PhysiotherapyStatePhysiotherapyOrderDetail";
        this.PhysiotherapyStatePhysiotherapyOrderDetail.Width = 80;

        this.PlannedDatePhysiotherapyOrderDetail = new TTVisual.TTDateTimePickerColumn();
        this.PlannedDatePhysiotherapyOrderDetail.DataMember = "PlannedDate";
        this.PlannedDatePhysiotherapyOrderDetail.DisplayIndex = 2;
        this.PlannedDatePhysiotherapyOrderDetail.HeaderText = i18n("M20400", "Planlanan Tarih");
        this.PlannedDatePhysiotherapyOrderDetail.Name = "PlannedDatePhysiotherapyOrderDetail";
        this.PlannedDatePhysiotherapyOrderDetail.Width = 180;

        this.raporTakipNoPhysiotherapyOrderDetail = new TTVisual.TTTextBoxColumn();
        this.raporTakipNoPhysiotherapyOrderDetail.DataMember = "raporTakipNo";
        this.raporTakipNoPhysiotherapyOrderDetail.DisplayIndex = 3;
        this.raporTakipNoPhysiotherapyOrderDetail.HeaderText = i18n("M20855", "Rapor Takip No");
        this.raporTakipNoPhysiotherapyOrderDetail.Name = "raporTakipNoPhysiotherapyOrderDetail";
        this.raporTakipNoPhysiotherapyOrderDetail.Width = 80;

        this.SessionNumberPhysiotherapyOrderDetail = new TTVisual.TTTextBoxColumn();
        this.SessionNumberPhysiotherapyOrderDetail.DataMember = "SessionNumber";
        this.SessionNumberPhysiotherapyOrderDetail.DisplayIndex = 4;
        this.SessionNumberPhysiotherapyOrderDetail.HeaderText = i18n("M21487", "Seans Numarası");
        this.SessionNumberPhysiotherapyOrderDetail.Name = "SessionNumberPhysiotherapyOrderDetail";
        this.SessionNumberPhysiotherapyOrderDetail.Width = 80;

        this.labelStartSession = new TTVisual.TTLabel();
        this.labelStartSession.Text = i18n("M11633", "Başlangıç Seansı");
        this.labelStartSession.Name = "labelStartSession";
        this.labelStartSession.TabIndex = 35;

        this.labelSeansGunSayisi = new TTVisual.TTLabel();
        this.labelSeansGunSayisi.Text = i18n("M21481", "Seans Gün Sayısı");
        this.labelSeansGunSayisi.Name = "labelSeansGunSayisi";
        this.labelSeansGunSayisi.TabIndex = 33;

        this.IncludeFriday = new TTVisual.TTCheckBox();
        this.IncludeFriday.Value = false;
        this.IncludeFriday.Text = i18n("M12295", "Cuma");
        this.IncludeFriday.Title = i18n("M12295", "Cuma");
        this.IncludeFriday.Name = "IncludeFriday";
        this.IncludeFriday.TabIndex = 25;

        this.IncludeThursday = new TTVisual.TTCheckBox();
        this.IncludeThursday.Value = false;
        this.IncludeThursday.Text = i18n("M20353", "Perşembe");
        this.IncludeThursday.Title = i18n("M20353", "Perşembe");
        this.IncludeThursday.Name = "IncludeThursday";
        this.IncludeThursday.TabIndex = 23;

        this.IncludeWednesday = new TTVisual.TTCheckBox();
        this.IncludeWednesday.Value = false;
        this.IncludeWednesday.Text = i18n("M12344", "Çarşamba");
        this.IncludeWednesday.Title = i18n("M12344", "Çarşamba");
        this.IncludeWednesday.Name = "IncludeWednesday";
        this.IncludeWednesday.TabIndex = 22;

        this.IncludeMonday = new TTVisual.TTCheckBox();
        this.IncludeMonday.Value = false;
        this.IncludeMonday.Text = i18n("M20286", "Pazartesi");
        this.IncludeMonday.Title = i18n("M20286", "Pazartesi");
        this.IncludeMonday.Name = "IncludeMonday";
        this.IncludeMonday.TabIndex = 21;

        this.IncludeTuesday = new TTVisual.TTCheckBox();
        this.IncludeTuesday.Value = false;
        this.IncludeTuesday.Text = i18n("M21282", "Salı");
        this.IncludeTuesday.Title = i18n("M21282", "Salı");
        this.IncludeTuesday.Name = "IncludeTuesday";
        this.IncludeTuesday.TabIndex = 20;

        this.IncludeSunday = new TTVisual.TTCheckBox();
        this.IncludeSunday.Value = false;
        this.IncludeSunday.Text = i18n("M20284", "Pazar Dahil");
        this.IncludeSunday.Title = i18n("M20284", "Pazar Dahil");
        this.IncludeSunday.Name = "IncludeSunday";
        this.IncludeSunday.TabIndex = 19;

        this.IncludeSaturday = new TTVisual.TTCheckBox();
        this.IncludeSaturday.Value = false;
        this.IncludeSaturday.Text = i18n("M12298", "Cumartesi Dahil");
        this.IncludeSaturday.Title = i18n("M12298", "Cumartesi Dahil");
        this.IncludeSaturday.Name = "IncludeSaturday";
        this.IncludeSaturday.TabIndex = 18;

        this.labelFinishSession = new TTVisual.TTLabel();
        this.labelFinishSession.Text = i18n("M11935", "Bitiş Seansı");
        this.labelFinishSession.Name = "labelFinishSession";
        this.labelFinishSession.TabIndex = 17;

        this.labelDuration = new TTVisual.TTLabel();
        this.labelDuration.Text = "Süre/dk";
        this.labelDuration.Name = "labelDuration";
        this.labelDuration.TabIndex = 15;

        this.labelApplicationArea = new TTVisual.TTLabel();
        this.labelApplicationArea.Text = i18n("M24189", "Vücut Bölgesi Açıklama");
        this.labelApplicationArea.Name = "labelApplicationArea";
        this.labelApplicationArea.TabIndex = 11;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = "Fizyoterapist";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 9;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "PhysiotherapistListDefinition";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 8;

        this.labelProcedureObject = new TTVisual.TTLabel();
        this.labelProcedureObject.Text = i18n("M14486", "FTR İşlemleri");
        this.labelProcedureObject.Name = "labelProcedureObject";
        this.labelProcedureObject.TabIndex = 7;

        this.ProcedureObject = new TTVisual.TTObjectListBox();
        this.ProcedureObject.Required = true;
        this.ProcedureObject.ListDefName = "PhysiotherapyListDefinition";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.TabIndex = 6;

        this.labelFTRApplicationAreaDef = new TTVisual.TTLabel();
        this.labelFTRApplicationAreaDef.Text = i18n("M24187", "Vücut Bölgesi");
        this.labelFTRApplicationAreaDef.Name = "labelFTRApplicationAreaDef";
        this.labelFTRApplicationAreaDef.TabIndex = 3;

        this.FTRApplicationAreaDef = new TTVisual.TTObjectListBox();
        this.FTRApplicationAreaDef.Required = true;
        this.FTRApplicationAreaDef.ListDefName = "FTRVucutBolgesiTTObjectListDefinition";
        this.FTRApplicationAreaDef.Name = "FTRApplicationAreaDef";
        this.FTRApplicationAreaDef.TabIndex = 2;

        this.labelTreatmentDiagnosisUnit = new TTVisual.TTLabel();
        this.labelTreatmentDiagnosisUnit.Text = i18n("M22778", "Tanı Tedavi Ünitesi");
        this.labelTreatmentDiagnosisUnit.Name = "labelTreatmentDiagnosisUnit";
        this.labelTreatmentDiagnosisUnit.TabIndex = 1;

        this.TreatmentDiagnosisUnit = new TTVisual.TTObjectListBox();
        this.TreatmentDiagnosisUnit.Required = true;
        this.TreatmentDiagnosisUnit.ListDefName = "TreatmentDiagnosisUnitListDefinition";
        this.TreatmentDiagnosisUnit.Name = "TreatmentDiagnosisUnit";
        this.TreatmentDiagnosisUnit.TabIndex = 0;

        this.PhysiotherapyOrderDetailsColumns = [this.NotePhysiotherapyOrderDetail, this.PhysiotherapyStatePhysiotherapyOrderDetail, this.PlannedDatePhysiotherapyOrderDetail, this.raporTakipNoPhysiotherapyOrderDetail, this.SessionNumberPhysiotherapyOrderDetail];
        this.ttpanel1.Controls = [this.labelReportNoPhysiotherapyReports, this.labelDiagnosisGroupPhysiotherapyReports, this.TreatmentTypePhysiotherapyReports, this.labelTreatmentTypePhysiotherapyReports, this.FTRApplicationAreaDefPhysiotherapyReports, this.TreatmentProcessTypePhysiotherapyReports, this.labelFTRApplicationAreaDefPhysiotherapyReports, this.PackageProcedureInfoPhysiotherapyReports, this.labelReportInfoPhysiotherapyReports, this.ReportTimePhysiotherapyReports, this.ReportEndDatePhysiotherapyReports, this.ReportNoPhysiotherapyReports, this.labelReportEndDatePhysiotherapyReports, this.ReportInfoPhysiotherapyReports, this.ReportStartDatePhysiotherapyReports, this.DiagnosisGroupPhysiotherapyReports, this.labelReportStartDatePhysiotherapyReports, this.labelReportTimePhysiotherapyReports, this.ReportDatePhysiotherapyReports, this.labelReportDatePhysiotherapyReports, this.ReportType, this.labelPackageProcedureInfoPhysiotherapyReports, this.labelTreatmentProcessTypePhysiotherapyReports];
        this.Controls = [this.IsPaidTreatment, this.labelPackageProcedure, this.PackageProcedure, this.IsAdditionalProcess, this.IsMedulaNotWorking, this.IsAdditionalTreatment, this.labelTreatmentProperties, this.TreatmentProperties, this.DoseDurationInfo, this.Dose, this.StartSession, this.SeansGunSayisi, this.FinishSession, this.Duration, this.ApplicationArea, this.labelDoseDurationInfo, this.labelPhysiotherapyStartDate, this.PhysiotherapyStartDate, this.ttpanel1, this.labelReportNoPhysiotherapyReports, this.labelDiagnosisGroupPhysiotherapyReports, this.TreatmentTypePhysiotherapyReports, this.labelTreatmentTypePhysiotherapyReports, this.FTRApplicationAreaDefPhysiotherapyReports, this.TreatmentProcessTypePhysiotherapyReports, this.labelFTRApplicationAreaDefPhysiotherapyReports, this.PackageProcedureInfoPhysiotherapyReports, this.labelReportInfoPhysiotherapyReports, this.ReportTimePhysiotherapyReports, this.ReportEndDatePhysiotherapyReports, this.ReportNoPhysiotherapyReports, this.labelReportEndDatePhysiotherapyReports, this.ReportInfoPhysiotherapyReports, this.ReportStartDatePhysiotherapyReports, this.DiagnosisGroupPhysiotherapyReports, this.labelReportStartDatePhysiotherapyReports, this.labelReportTimePhysiotherapyReports, this.ReportDatePhysiotherapyReports, this.labelReportDatePhysiotherapyReports, this.ReportType, this.labelPackageProcedureInfoPhysiotherapyReports, this.labelTreatmentProcessTypePhysiotherapyReports, this.labelDose, this.PhysiotherapyOrderDetails, this.NotePhysiotherapyOrderDetail, this.PhysiotherapyStatePhysiotherapyOrderDetail, this.PlannedDatePhysiotherapyOrderDetail, this.raporTakipNoPhysiotherapyOrderDetail, this.SessionNumberPhysiotherapyOrderDetail, this.labelStartSession, this.labelSeansGunSayisi, this.IncludeFriday, this.IncludeThursday, this.IncludeWednesday, this.IncludeMonday, this.IncludeTuesday, this.IncludeSunday, this.IncludeSaturday, this.labelFinishSession, this.labelDuration, this.labelApplicationArea, this.labelProcedureDoctor, this.ProcedureDoctor, this.labelProcedureObject, this.ProcedureObject, this.labelFTRApplicationAreaDef, this.FTRApplicationAreaDef, this.labelTreatmentDiagnosisUnit, this.TreatmentDiagnosisUnit];

    }

}
