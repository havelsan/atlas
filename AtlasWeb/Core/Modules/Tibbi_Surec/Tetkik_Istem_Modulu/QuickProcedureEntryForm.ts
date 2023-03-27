import { Component, Input, Output, EventEmitter } from '@angular/core';
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

import { ITTObjectListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTObjectListBox';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { vmRequestedProcedure, QuickProcedureEntryViewModel } from "./ProcedureRequestViewModel";
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { UserTitleEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ReportItem, PhysiotherapyPlannedOrdersFormViewModel } from '../Fizyoterapi_Modulu/PhysiotherapyPlannedOrdersFormViewModel';
import { TreatmentQueryReportTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyReports } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { CommonService } from 'ObjectClassService/CommonService';
import { DatePipe } from '@angular/common';
import { ReportTypeWithEpisodeId } from '../Fizyoterapi_Modulu/PhysiotherapyOrderPlanningFormViewModel';


@Component({
    selector: 'QuickProcedureEntryForm',
    templateUrl: './QuickProcedureEntryForm.html',
    providers: [MessageService]
})

export class QuickProcedureEntryForm {

    //HIZLI ISLEM ekleme degiskenleri

    private _isSGKPatient: Boolean;
    @Input() set IsSGKPatient(value: Boolean) {
        this._isSGKPatient = value;
    }
    get IsSGKPatient(): Boolean {
        return this._isSGKPatient;
    }


    private _patientObjectID: String;
    @Input() set PatientObjectID(value: String) {
        this._patientObjectID = value;
    }
    get PatientObjectID(): String {
        return this._patientObjectID;
    }

    private _episodeObjectID: Guid;
    @Input() set EpisodeObjectID(value: Guid) {
        this._episodeObjectID = value;
    }
    get EpisodeObjectID(): Guid {
        return this._episodeObjectID;
    }

    private _subEpisodeOpeningDate: Date;
    @Input() set SubEpisodeOpeningDate(value: Date) {
        this._subEpisodeOpeningDate = value;
    }
    get SubEpisodeOpeningDate(): Date {
        return this._subEpisodeOpeningDate;
    }

    private _subEpisodeClosingDate: Date;
    @Input() set SubEpisodeClosingDate(value: Date) {
        if (value == null || value == undefined) {

            let RecTime: Date;
            (CommonService.RecTime()).then(response => {
                RecTime = response;
                this._subEpisodeClosingDate = RecTime;
            });
        }
        else
            this._subEpisodeClosingDate = value;
    }
    get SubEpisodeClosingDate(): Date {
        return this._subEpisodeClosingDate;
    }

    @Output() AddedQuickProcedures: EventEmitter<Array<vmRequestedProcedure>> = new EventEmitter<Array<vmRequestedProcedure>>();
    @Output() ClosePopup: EventEmitter<boolean> = new EventEmitter<boolean>();

    StartDate: Date;
    EndDate: Date;
    QuickProcedureDoctorList: TTVisual.ITTObjectListBox;
    QuickProcedureAmount: number;
    cmbAllProcedure: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'ProcedureListDefinitionForFastAdding'
    };
    chkMedulaNotWorking: TTVisual.ITTCheckBox;

    QuickProcedureSelectedProcedureObject: any;
    QuickProcedureSelectedDoctorValue: any;

    public tempQuickProcedureGridArray: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
    public ReportItemList: Array<ReportItem> = new Array<ReportItem>();
    IsMedulaNotWorking: boolean = false;
    TreatmentType: TreatmentQueryReportTypeEnum = TreatmentQueryReportTypeEnum.FTR;
    Message: string;
    showPhysiotherapyReportPopup: boolean = false;
    showTreatmentTypePopup: boolean = false;

    public QuickProcedureListColumns = [
        {
            "caption": i18n("M16694", "İstem Tarihi"),
            dataField: "RequestDate",
            width: 100,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "ProcedureCode",
            width: 80,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M16821", "İşlem Adı"),
            dataField: "ProcedureName",
            width: 250,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M10505", "Adet"),
            dataField: "Amount",
            width: 50,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M16695", "İstem Uygulayan"),
            dataField: "ProcedureResUser",
            width: 150,
            allowSorting: true
        },
        {
            "caption": i18n("M16695", "Medula Rapor No"),
            dataField: "MedulaReportNo",
            width: 100,
            allowSorting: true
        }
    ];



    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private datePipe: DatePipe) {
        this.initFormControls();
        this.loadViewModel();
    }


    //ngOnInit(): void {
    //    this.initFormControls();
    //}

    public initFormControls(): void {

        //HIZLI ISLEM controlleri
        this.QuickProcedureDoctorList = new TTVisual.TTObjectListBox();
        this.QuickProcedureDoctorList.ListDefName = "DoctorListDefinition";
        this.QuickProcedureDoctorList.Name = "QuickProcedureDoctorList";

        this.chkMedulaNotWorking = new TTVisual.TTCheckBox();
        this.chkMedulaNotWorking.Title = i18n("M23295", "MEDULA Bağlantı Sorunu Var");
        this.chkMedulaNotWorking.Name = "chkMedulaNotWorking";
        this.chkMedulaNotWorking.Value = false;
        this.chkMedulaNotWorking.TabIndex = 80;
    }

    async AddQuickProcedureClicked() {

        if (this.StartDate == null)
            TTVisual.InfoBox.Alert(i18n("M16700", "Başlangıç tarihi girilmesi zorunludur!"));
        else if (this.EndDate == null)
            TTVisual.InfoBox.Alert(i18n("M16700", "Bitiş tarihi girilmesi zorunludur!"));
        else if (this.QuickProcedureSelectedDoctorValue == null)
            TTVisual.InfoBox.Alert(i18n("M16700", "İstemi Uygulayan Doktor bilgisi girilmesi zorunludur!"));
        else if (this.QuickProcedureAmount == null)
            TTVisual.InfoBox.Alert(i18n("M16700", "Adet bilgisi girilmesi zorunludur!"));
        else if (this.QuickProcedureSelectedProcedureObject == null)
            TTVisual.InfoBox.Alert(i18n("M16700", "Hizmet bilgisi girilmesi zorunludur!"));
        else {


            //Listeye eklenen hizmetlerin ayni gün mukerrer kontrolu yapiliyor.
            let startDate: string = this.datePipe.transform(this.StartDate, 'dd.MM.yyyy');
            let endDate: string = this.datePipe.transform(this.EndDate, 'dd.MM.yyyy');

            let resultList = await this.httpService.get<Array<Date>>('api/ProcedureRequestService/GetProcedureCountByDateTimeIntervalByPatient?PatientObjectID=' + this.PatientObjectID + '&ProcedureObjectID=' + this.QuickProcedureSelectedProcedureObject.ObjectID.toString() + '&StartDate=' + startDate + '&EndDate=' + endDate);

            let alertMsg: string = "";
            for (let dateStr of resultList) {
                alertMsg = alertMsg + this.datePipe.transform(dateStr, "dd.MM.yyyy") + '<br />';
            }

            if (alertMsg != "") {
                alertMsg = "Aşağıda belirtilen tarihlerde hizmet girişi bulunmaktadır. Bu tarihlere tekrar hizmet girişi yapılmayacaktır. <br />" + alertMsg;
                TTVisual.InfoBox.Alert(i18n("M30815", alertMsg), null, null, 400, 400);
            }

            let tempDate = this.StartDate;
            do {
                //Versiyon1 hafta sonuna giris yapilmasin
                if (!(tempDate.getDay() == 6 || tempDate.getDay() == 0)) {

                    let addProcedure: boolean = true;
                    for (let i = 0; i < resultList.length; i++) {
                        if (this.datePipe.transform(resultList[i], "dd.MM.yyyy") == this.datePipe.transform(tempDate, "dd.MM.yyyy")) {
                            addProcedure = false;
                            break;
                        }
                    }
                    if (addProcedure == true) {
                        let tempObj: vmRequestedProcedure = new vmRequestedProcedure();
                        tempObj.Id = this.QuickProcedureSelectedProcedureObject.ObjectID;
                        tempObj.ProcedureCode = this.QuickProcedureSelectedProcedureObject.Code;
                        tempObj.ProcedureName = this.QuickProcedureSelectedProcedureObject.Name;
                        tempObj.RequestDate = tempDate;
                        tempObj.RequestedByResUser = (<ResUser>this.QuickProcedureSelectedDoctorValue).Name.toString();
                        tempObj.RequestedById = this.QuickProcedureSelectedDoctorValue.ObjectID;
                        tempObj.ProcedureObjectId = this.QuickProcedureSelectedProcedureObject.ObjectID;

                        tempObj.ProcedureResUser = (<ResUser>this.QuickProcedureSelectedDoctorValue).Name.toString();
                        tempObj.ProcedureUserId = (<ResUser>this.QuickProcedureSelectedDoctorValue).ObjectID;

                        tempObj.Amount = this.QuickProcedureAmount;
                        tempObj.isAdditionalApplication = true;
                        tempObj.isProcedureReadOnly = false;
                        tempObj.isNew = true;
                        //RaporNo ve VucutBolgesı bılgılerı set edılıyor
                        if (this.selectedReportNo != null)
                            tempObj.MedulaReportNo = this.selectedReportNo;
                        if (this.selectedApplicarionArea != null)
                            tempObj.ReportApplicationArea = this.selectedApplicarionArea;


                        this.tempQuickProcedureGridArray.push(tempObj);
                    }
                }
                if (tempDate)
                    tempDate = tempDate.AddDays(1);

            }
            while (tempDate && tempDate <= this.EndDate);
            window.setTimeout(t => {
            }, 0);

            console.log(event);
        }

    }

    onClickAddNewProcedure() {
        this.AddedQuickProcedures.emit(this.tempQuickProcedureGridArray);
        TTVisual.InfoBox.Alert(i18n("M16700", "İşlemler, Hizmet ve Tetkik tabına eklendi."));

        this.StartDate = null;
        this.EndDate = null;
        this.QuickProcedureSelectedDoctorValue = null;
        this.QuickProcedureAmount = null;
        this.QuickProcedureSelectedProcedureObject = null;
        this.tempQuickProcedureGridArray = new Array<vmRequestedProcedure>();
        this.ReportItemList = new Array<ReportItem>();
        this.chkMedulaNotWorking.Value = false;

    }

    onClickClosePopup() {
        this.ClosePopup.emit(true);

        this.StartDate = null;
        this.EndDate = null;
        this.QuickProcedureSelectedDoctorValue = null;
        this.QuickProcedureAmount = null;
        this.QuickProcedureSelectedProcedureObject = null;
        this.tempQuickProcedureGridArray = new Array<vmRequestedProcedure>();
        this.ReportItemList = new Array<ReportItem>();

    }

    QuickProcedureSelectedDoctorValueChanged(data: any) {

        if (data != null) {

            if ((data.Title === UserTitleEnum.UzmanOgr) ||
                (data.Title === UserTitleEnum.DoktoraOgr) ||
                (data.Title === UserTitleEnum.YanDalUzmanOgr) ||
                (data.Title === UserTitleEnum.YLisansUzmanOgr) ||
                (data.Title === null)) {
                TTVisual.InfoBox.Alert(i18n("M16700", "İstemi Uygulayan Doktor Alanı için Uzman Hekim Seçmeniz Gerekmektedir!"));
                this.QuickProcedureSelectedDoctorValue = null;
            }
            else {
                this.QuickProcedureSelectedDoctorValue = data;
            }
        }
        else
            this.QuickProcedureSelectedDoctorValue = null;

    }


    QuickProcedureSelectedProcedureValueChanged(data: any) {
        if (data != null) {

            if (data.ReportSelectionRequired == true) {
                this.onClickGetReports();
                this.showPhysiotherapyReportPopup = true;
            }
        }
    }

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



    onClickGetReports() {
        this.IsMedulaNotWorking = this.chkMedulaNotWorking.Value;
        this.loadPanelOperation(true, i18n("M20888", "Raporlar listeleniyor. Lütfen bekleyiniz."));
        if (this.ReportItemList.length == 0) // || this.lastTreatmentType != this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType)
        {
            let _reportTypeWithEpisodeId: ReportTypeWithEpisodeId = new ReportTypeWithEpisodeId();
            _reportTypeWithEpisodeId.treatmentType = this.TreatmentType;
            _reportTypeWithEpisodeId.activeEpisodeObjectID = this.EpisodeObjectID;


            //!!! TODO TODO TODO NİDA
            //this.lastTreatmentType = this.physiotherapyPlannedOrdersFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType;
            if (this.IsSGKPatient == true && this.IsMedulaNotWorking == false) {
                this.httpService.post<PhysiotherapyPlannedOrdersFormViewModel>("api/PhysiotherapyOrderService/GetReportInfoByTreatmentType?treatmentType", _reportTypeWithEpisodeId, PhysiotherapyPlannedOrdersFormViewModel).then(response => {
                    let result: PhysiotherapyPlannedOrdersFormViewModel = <PhysiotherapyPlannedOrdersFormViewModel>response;

                    this.ReportItemList = result.ReportItemList;
                    this.Message = result.Message;

                    this.showTreatmentTypePopup = false;
                    this.showPhysiotherapyReportPopup = true;

                    if (this.Message != null && this.Message != "") {
                        TTVisual.InfoBox.Alert(this.Message);
                    }

                    this.loadPanelOperation(false, '');
                });
            } else if (this.IsSGKPatient == true && this.IsMedulaNotWorking == true) {
                this.httpService.post<PhysiotherapyPlannedOrdersFormViewModel>("api/PhysiotherapyOrderService/GetInstitutionMedulaReportInfoByTreatmentType?treatmentType", _reportTypeWithEpisodeId, PhysiotherapyPlannedOrdersFormViewModel).then(response => {
                    let result: PhysiotherapyPlannedOrdersFormViewModel = <PhysiotherapyPlannedOrdersFormViewModel>response;

                    this.ReportItemList = result.ReportItemList;
                    this.Message = result.Message;

                    this.showTreatmentTypePopup = false;
                    this.showPhysiotherapyReportPopup = true;

                    if (this.Message != null && this.Message != "") {
                        TTVisual.InfoBox.Alert(this.Message);
                    }

                    this.loadPanelOperation(false, '');
                });

            } else {
                this.httpService.post<PhysiotherapyPlannedOrdersFormViewModel>("api/PhysiotherapyOrderService/GetInstitutionReportInfoByTreatmentType?treatmentType", _reportTypeWithEpisodeId, PhysiotherapyPlannedOrdersFormViewModel).then(response => {
                    let result: PhysiotherapyPlannedOrdersFormViewModel = <PhysiotherapyPlannedOrdersFormViewModel>response;

                    this.ReportItemList = result.ReportItemList;
                    this.Message = result.Message;

                    this.showTreatmentTypePopup = false;
                    this.showPhysiotherapyReportPopup = true;

                    if (this.Message != null && this.Message != "") {
                        TTVisual.InfoBox.Alert(this.Message);
                    }

                    this.loadPanelOperation(false, '');
                });
            }
        } else {
            this.showTreatmentTypePopup = false;
            this.showPhysiotherapyReportPopup = true;

            if (this.Message != null && this.Message != "") {
                TTVisual.InfoBox.Alert(this.Message);
            }

            this.loadPanelOperation(false, '');
        }
    }


    //Rapor İşlemleri
    selectedReportItem: PhysiotherapyReports;
    selectedApplicarionArea: Guid;
    selectedReportNo: string;

    async selectionReportChanged(value: any): Promise<void> {
        if (value) {
            this.selectedReportItem = value.selectedRowsData[0].ReportObj as PhysiotherapyReports;
            this.selectedReportNo = value.selectedRowsData[0].ReportNo.toString();
            this.selectedApplicarionArea = value.selectedRowsData[0].FTRApplicationAreaDef.ObjectID;
        }
    }

    async CancelPhysiotherapyReport() {
        if (this.selectedReportItem == null) {
            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
            if (messageResult === "E") {
                this.showPhysiotherapyReportPopup = false;
                this.selectedReportItem = null;
            }
        }
    }

    async SavePhysiotherapyReportModal() {
        if (this.selectedReportItem != null) {

            //Secılen raporun raporNo ve vucutBolgesı bılgılerı requestedprocedures dekı baseaddıtıonalapplıcatıon da ılgılı alanlara set edılecek.

            //if (this.selectedReportItem.ReportNo != null) {
            //    this.selectedReportNo = this.selectedReportItem.ReportNo.toString();
            //}


            //if (this.selectedReportItem.FTRApplicationAreaDef != null) {
            //    this.selectedApplicarionArea = this.selectedReportItem.FTRApplicationAreaDef;
            //}

            this.showPhysiotherapyReportPopup = false;
            this.selectedReportItem = null;

        }
        else {

            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
            if (messageResult === "E") {
                this.showPhysiotherapyReportPopup = false;
                this.selectedReportItem = null;
            }
        }
    }

    _ProcedureDoctor: ResUser;
    async loadViewModel() {

        let result = await this.httpService.get<QuickProcedureEntryViewModel>('api/ProcedureRequestService/LoadQuickProcedureEntryForm');
        if (result.ProcedureDoctor != null) {
            this.QuickProcedureSelectedDoctorValue = result.ProcedureDoctor; 
        }

    }

}