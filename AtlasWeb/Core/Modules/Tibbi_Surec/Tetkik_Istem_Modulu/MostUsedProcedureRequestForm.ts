//$87F3EDA3
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Component, OnInit, Input, OnDestroy, ChangeDetectorRef, ViewChild} from '@angular/core';
import { vmProcedureRequestFormDefinition, vmProcedureRequestDetailDefinition, vmRequestedProcedure, DurationLimitedProceduresQueryParam, TeletipResult_Output, TeletipImaj_Input, ControlVitaminDResult, TetkikSonucBilgileri } from "./ProcedureRequestViewModel";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ProcedureRequestSharedService } from "./ProcedureRequestSharedService";
import { EpisodeAction, PatientExamination, NeurophysiologicalAssessmentForm, AmputeeAssessmentForm, PostureAnalysisForm } from 'NebulaClient/Model/AtlasClientModel';
import { MessageService } from 'Fw/Services/MessageService';
import { Subscription } from 'rxjs';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { DatePipe } from '@angular/common';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { BaseAdditionalInfoFormViewModel } from './BaseAdditionalInfoFormViewModel';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { IModalService } from "Fw/Services/IModalService";
import { DynamicComponentInputParam } from "../../../wwwroot/app/Fw/Models/DynamicComponentInputParam";
import { ActiveIDsModel } from "../../../wwwroot/app/Fw/Models/ParameterDefinitionModel";
import { DxButtonComponent } from "devextreme-angular";
import { ShowBox } from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { CommonService } from "ObjectClassService/CommonService";
import { ServiceLocator } from "../../../wwwroot/app/Fw/Services/ServiceLocator";
import { NeurophysiologicalAssessmentFormViewModel } from "../Fizyoterapi_Modulu/NeurophysiologicalAssessmentFormViewModel";
import { MuscleTestFormViewModel } from "../Fizyoterapi_Modulu/MuscleTestFormViewModel";
import { AmputeeAssessmentFormViewModel } from "../Fizyoterapi_Modulu/AmputeeAssessmentFormViewModel";
import { IsokineticTestFormViewModel } from "../Fizyoterapi_Modulu/IsokineticTestFormViewModel";
import { BalanceCoordinationTestsFormViewModel } from "../Fizyoterapi_Modulu/BalanceCoordinationTestsFormViewModel";
import { SensoryPerceptionAssessmentFormViewModel } from "../Fizyoterapi_Modulu/SensoryPerceptionAssessmentFormViewModel";
import { RangeOfMotionMeasurementFormViewModel } from "../Fizyoterapi_Modulu/RangeOfMotionMeasurementFormViewModel";
import { ManualDexterityTestsFormViewModel } from "../Fizyoterapi_Modulu/ManualDexterityTestsFormViewModel";
import { ElectrodiagnosticTestsFormViewModel } from "../Fizyoterapi_Modulu/ElectrodiagnosticTestsFormViewModel";
import { DailyActivityTestsFormViewModel } from "../Fizyoterapi_Modulu/DailyActivityTestsFormViewModel";
import { MuscleStrengthMeasuringFormViewModel } from "../Fizyoterapi_Modulu/MuscleStrengthMeasuringFormViewModel";
import { OccupationalAssessmentFormViewModel } from "../Fizyoterapi_Modulu/OccupationalAssessmentFormViewModel";
import { PostureAnalysisFormViewModel } from "../Fizyoterapi_Modulu/PostureAnalysisFormViewModel";
import { ScoliosisAssessmentFormViewModel } from "../Fizyoterapi_Modulu/ScoliosisAssessmentFormViewModel";
import { GaitAnalysisFormViewModel } from "../Fizyoterapi_Modulu/GaitAnalysisFormViewModel";
import { GaitAnalysisComputerBasedFormViewModel } from "../Fizyoterapi_Modulu/GaitAnalysisComputerBasedFormViewModel";

@Component({
    selector: 'mostused-procedure-request-form',
    templateUrl: './MostUsedProcedureRequestForm.html',
    providers: [DatePipe]
})
export class MostUsedProcedureRequestForm extends TTUnboundForm implements OnInit, OnDestroy {
    RequestedProcedures: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
    chkEmergency: TTVisual.ITTCheckBox;
    requestDate: Date;
    disableRequestForm: boolean;
    procedureByUser: string;
    public requestDateSubscribe: Subscription;
    public disableRequestFormSubscribe: Subscription;
    public refreshMostUsedRequestFormSubscribe: Subscription;
    public procedureByUserSubscribe: Subscription;
    public deletedProcedureRequestFormDetailIDSubscribe: Subscription;


    testTypesCheckedParam: string = "";
    ignoreMukerrerException: boolean = false;
    showTeletipResult: boolean = false;
    showTeletipResultReport: boolean = false;
    showRepeatReasonPopup: boolean = false;
    teletipResultReportInfo: string = "";
    PreviousStudies: Array<TeletipResult_Output> = new Array<TeletipResult_Output>();
    private tetkikMukerrerlikResult: ControlVitaminDResult = new ControlVitaminDResult();
    private _tetkikSonucBilgileri: Array<TetkikSonucBilgileri> = new Array<TetkikSonucBilgileri>();
    private showVitaminDResult: boolean = false;
    continueWithoutControl: boolean = false;//Acil ve yatan hastalar için sonuç ve rapor görüntüleme zorunluluğu yok
    public showTeletipLoadPanel = false;
    public LoadPanelTipMessage: string = '';

    /*Tekrar İstem Gerekçesi*/
    ReasonForRepetitionRequest: TTVisual.ITTObjectListBox;
    /*Tekrar İstem Gerekçesi*/

    @ViewChild('btnEvet') btnEvet: DxButtonComponent;
    @ViewChild('btnHayir') btnHayir: DxButtonComponent;
    @ViewChild('btnSaveRepetitionReason') btnSaveRepetitionReason: DxButtonComponent;

    @Input() EpisodeAction: EpisodeAction;

    private _mostUsedRequestedProcedures: Array<vmProcedureRequestFormDefinition> = new Array<vmProcedureRequestFormDefinition>();
    @Input() set MostUsedRequestedProcedures(value: Array<vmProcedureRequestFormDefinition>) {
        this._mostUsedRequestedProcedures = value;
    }
    get MostUsedRequestedProcedures(): Array<vmProcedureRequestFormDefinition> {
        return this._mostUsedRequestedProcedures;
    }

    public columns = [
        {
            name: "column",
            cellTemplate: "columnCellTemplate"
        },
        {
            dataField: "Code",
            width: 0
        },
    ];

    onContextMenuPreparing(e: any): void {
        let that = this;
        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data') {
                e.items = [{
                    text: "Sık Kullanılanlardan Çıkar",
                    disabled: false,
                    onItemClick: function () {

                        that.ExcludeMostUsed(e.row.data);
                    }
                }
                ];
            }
        }
    }

    async ExcludeMostUsed(data) {

        let apiUrl: string = "/api/ProcedureRequestService/ExcludeFromMostUsedProcedureRequestForm?procedureRequestFormDetailID=" + data.Id;
        await this.httpService.get<any>(apiUrl).then(
            x => {
                this.messageService.showInfo(i18n("M30814", "Hizmet/Tetkik, Sık Kullanılanlar Panelinden çıkarıldı."));
                this.loadViewModel();
            }
        ).catch(error => {
            this.messageService.showError(error);
        });

        console.log(data);
    }

    constructor(protected modalService: IModalService, private procedureRequestSharedService: ProcedureRequestSharedService, protected messageService: MessageService,
        private httpService: NeHttpService, private datePipe: DatePipe, private changeDetectorRef: ChangeDetectorRef) {
        super("", "");
    }

    /*Tekrarlı İstem Nedeni */
    public onReasonForRepetitionRequestChanged(event): void {
        if (event != null) {
            if (this.lastSelectedDetail != null && this.lastSelectedDetail.ReasonForRepetition != event) {
                this.lastSelectedDetail.ReasonForRepetition = event;
            }
        }
    }

    public closeRepetitionPopUp() {
    }
    /*Tekrarlı İstem Nedeni */
    public initFormControls(): void {

        this.chkEmergency = new TTVisual.TTCheckBox();
        this.chkEmergency.Value = false;
        this.chkEmergency.Text = "Acil";
        this.chkEmergency.Title = "Acil";
        this.chkEmergency.Name = "chkEmergency";
        this.chkEmergency.TabIndex = 80;

        this.ReasonForRepetitionRequest = new TTVisual.TTObjectListBox();
        this.ReasonForRepetitionRequest.ListDefName = "SKRSTekrarTetkikIstemGerekcesiList";
        this.ReasonForRepetitionRequest.ReadOnly = true;
        this.ReasonForRepetitionRequest.Name = "ReasonForRepetitionRequest";
        this.ReasonForRepetitionRequest.TabIndex = 19;

    }
    Grid1FormDetails: any = new Array<any>();
    Grid2FormDetails: any = new Array<any>();
    Grid3FormDetails: any = new Array<any>();
    async loadViewModel() {
        let fullApiUrl: string = 'api/ProcedureRequestService/GetMostUsedProcedureRequestViewModel';
        await this.httpService.post<any>(fullApiUrl, null).then(
            x => {
                if (x.UserMostUsedFormDefinitions != null && x.UserMostUsedFormDefinitions.length > 0) {
                    if (x.UserMostUsedFormDefinitions[0].FormCategories != null && x.UserMostUsedFormDefinitions[0].FormCategories.length > 0) {
                        this.Grid1FormDetails = x.UserMostUsedFormDefinitions[0].FormCategories[0].Grid1FormDetails;
                        this.Grid2FormDetails = x.UserMostUsedFormDefinitions[0].FormCategories[0].Grid2FormDetails;
                        this.Grid3FormDetails = x.UserMostUsedFormDefinitions[0].FormCategories[0].Grid3FormDetails;
                        this.MostUsedRequestedProcedures = x.UserMostUsedFormDefinitions;
                    }
                }

                this.testTypesCheckedParam = x.TestTypesCheckedParam; 
                this.ignoreMukerrerException = x.IgnoreMukerrerException;

            }
        );
    }

    initSubscribers() {

        if (this.requestDateSubscribe == null) {
            this.requestDateSubscribe = this.procedureRequestSharedService.RequestDate.subscribe(
                requestDateInfo => {
                    this.requestDate = requestDateInfo;
                }
            );
        }

        if (this.procedureByUserSubscribe == null) {
            this.procedureByUserSubscribe = this.procedureRequestSharedService.ProcedureByUser.subscribe(
                procedureByUserInfo => {
                    this.procedureByUser = procedureByUserInfo;
                }
            );
        }

        if (this.disableRequestFormSubscribe == null) {
            this.disableRequestFormSubscribe = this.procedureRequestSharedService.DisableRequestForm.subscribe(
                disableRequestFormSubscribeInfo => {
                    this.disableRequestForm = disableRequestFormSubscribeInfo;
                }
            );
        }

        if (this.refreshMostUsedRequestFormSubscribe == null) {
            this.refreshMostUsedRequestFormSubscribe = this.procedureRequestSharedService.RefreshMostUsedRequestForm.subscribe(
                refreshMostUsedRequestForm => {
                    this.loadViewModel();
                }
            );
        }

        if (this.deletedProcedureRequestFormDetailIDSubscribe == null) {
            this.deletedProcedureRequestFormDetailIDSubscribe = this.procedureRequestSharedService.DeletedProcedureRequestFormDetailID.subscribe(
                deletedRequestFormDetailID => {
                    this.removeProcedureRequestCheck(deletedRequestFormDetailID);
                }
            );
        }
    }

    removeProcedureRequestCheck(detailId: Guid) {
        let isUnChecked: boolean;
        isUnChecked = false;
        
        if (isUnChecked == false) {
            for (let form of this.MostUsedRequestedProcedures) {
                for (let category of form.FormCategories) {
                    let categoryGridFormDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();
                    for (let i = 1; i <= 3; i++) {
                        if (i == 1)
                            categoryGridFormDetails = category.Grid1FormDetails;
                        if (i == 2)
                            categoryGridFormDetails = category.Grid2FormDetails;
                        if (i == 3)
                            categoryGridFormDetails = category.Grid3FormDetails;

                        for (let detail of categoryGridFormDetails) {
                            if (detail.Id.toString() === detailId.toString()) {
                                detail.Checked = false;
                                isUnChecked = true;
                                break;
                            }
                        }
                        if (isUnChecked == true) break;
                    }
                    if (isUnChecked == true) break;
                }
                if (isUnChecked == true) break;
            }
        }
    } 
    

    ngAfterViewInit(): void {
        this.initSubscribers();
        this.loadViewModel();

    }

    ngOnDestroy() {

        if (this.requestDateSubscribe != null) {
            this.requestDateSubscribe.unsubscribe();
            this.requestDateSubscribe = null;
        }

        if (this.procedureByUserSubscribe != null) {
            this.procedureByUserSubscribe.unsubscribe();
            this.procedureByUserSubscribe = null;
        }

        if (this.disableRequestFormSubscribe != null) {
            this.disableRequestFormSubscribe.unsubscribe();
            this.disableRequestFormSubscribe = null;
        }

        if (this.refreshMostUsedRequestFormSubscribe != null) {
            this.refreshMostUsedRequestFormSubscribe.unsubscribe();
            this.refreshMostUsedRequestFormSubscribe = null;
        }

        if (this.deletedProcedureRequestFormDetailIDSubscribe != null) {
            this.deletedProcedureRequestFormDetailIDSubscribe.unsubscribe();
            this.deletedProcedureRequestFormDetailIDSubscribe = null;
        }

    }


    ngOnInit(): void {
        this.initFormControls();

    }
    PatientStatus: number;

    emergencyChecked(isChecked: boolean) {

        this.chkEmergency.Value = isChecked;
        this.procedureRequestSharedService.emergencyChecked(isChecked);
    }

    //procedureRequestOnChange(detailId: Guid, isChecked: boolean)
    //{
    //    this.procedureRequestSharedService.procedureRequestOnChange(detailId, this.EpisodeAction.ObjectID, isChecked, false, this.requestDate);
    //}
    RequestedByResUser: any;
    openPhysiotherapyTestsForm(physiotherapyTestForm: string, vmRequest: vmRequestedProcedure, objectID?: string) {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();

            componentInfo.ComponentName = physiotherapyTestForm;
            componentInfo.ModuleName = "FizyoterapiModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Fizyoterapi_Modulu/FizyoterapiModule';
            this.RequestedByResUser = vmRequest.RequestedByResUser;
            componentInfo.InputParam = this;
            if (objectID != null)
                componentInfo.objectID = objectID;

            let modalInfo: ModalInfo = new ModalInfo();
            //modalInfo.Title = ;
            modalInfo.Width = 700;
            modalInfo.Height = 500;
            modalInfo.IsShowCloseButton = false;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                let baseAdditionalInfoFormViewModel = inner.Param as BaseAdditionalInfoFormViewModel;
                if (baseAdditionalInfoFormViewModel != null && baseAdditionalInfoFormViewModel instanceof BaseViewModel) {
                    if (vmRequest.BaseAdditionalInfoFormViewModels == null) {
                        vmRequest.BaseAdditionalInfoFormViewModels = new Array<BaseAdditionalInfoFormViewModel>();
                    }
                    vmRequest.BaseAdditionalInfoFormViewModels.push(baseAdditionalInfoFormViewModel);

                    if(baseAdditionalInfoFormViewModel instanceof NeurophysiologicalAssessmentFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._NeurophysiologicalAssessmentForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof MuscleTestFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._MuscleTestForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof AmputeeAssessmentFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._AmputeeAssessmentForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof IsokineticTestFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._IsokineticTestForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof BalanceCoordinationTestsFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._BalanceCoordinationTestsForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof SensoryPerceptionAssessmentFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._SensoryPerceptionAssessmentForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof RangeOfMotionMeasurementFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._RangeOfMotionMeasurementForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof ManualDexterityTestsFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._ManualDexterityTestsForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof ElectrodiagnosticTestsFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._ElectrodiagnosticTests.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof DailyActivityTestsFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._DailyActivityTestsForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof MuscleStrengthMeasuringFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._MuscleStrengthMeasuringForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof PostureAnalysisFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._PostureAnalysisForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof ScoliosisAssessmentFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._ScoliosisAssessmentForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof GaitAnalysisFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._GaitAnalysisForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof GaitAnalysisComputerBasedFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._GaitAnalysisComputerBasedForm.CreationDate;
                    }
                    else if(baseAdditionalInfoFormViewModel instanceof OccupationalAssessmentFormViewModel){
                        baseAdditionalInfoFormViewModel.RequestDate = baseAdditionalInfoFormViewModel._OccupationalAssessmentForm.CreationDate;
                    }
                    vmRequest.RequestDate = baseAdditionalInfoFormViewModel.RequestDate;
                }

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public lastSelectedDetail: vmRequestedProcedure = null; 
    async procedureRequestOnChange(detailId: Guid, isChecked: boolean, detail: any = null) {


        let noerror = true;
        if (this.requestDate == undefined || this.requestDate == null) {
            noerror = false;
            this.messageService.showError(i18n("M30106", "İstem Tarihi boşsa ya da Klinik taburcu yapıldı ise Tetkik İstemi yapılamaz."));
            if (detail)
                window.setTimeout(() => {
                    detail.Checked = false;
                });
        }

        if (detail.IsAdditionalApplication == true) {
            if (this.procedureByUser == undefined || this.procedureByUser == null) {
                noerror = false;
                this.messageService.showError(i18n("M30106", "İstemi Uygulayan Doktor alanı boş geçilemez."));
                if (detail)
                    window.setTimeout(() => {
                        detail.Checked = false;
                    });
                return;
            }
            if (isChecked === true) {
                let physiotherapyTestForm: string = "";
                let IsDescriptionNeeded: boolean = false;
                detail.BaseAdditionalInfoFormViewModels = new Array<BaseAdditionalInfoFormViewModel>();

                await this.httpService.get<any>('api/ProcedureRequestService/GetRelatedPhysiotherapyTestForm?ProcedureCode=' + detail.Code).then(async response => {
                    physiotherapyTestForm = response;
                    if (physiotherapyTestForm != "")
                        await this.openPhysiotherapyTestsForm(physiotherapyTestForm, detail, null);
                }).catch(error => {
                    this.messageService.showError(error);
                });

                if (detail.isReportRequired) {
                    this.openAdditionalReportForm(detail, null);
                }

                if (detail.isResultNeeded) {
                    this.openProcedureResultForm(detail, null);
                 
                }

            }

        }


        //Hizmetler için önceki tarihe giriş yapılmasına izin verilir
        if (detail.IsAdditionalApplication != true)
        {
            if (this.disableRequestForm == true) {
                noerror = false;
                this.messageService.showError(i18n("M20011", "Önceki tarihe Tetkik İstemi yapılamaz."));
                if (detail)
                    window.setTimeout(() => {
                        detail.Checked = false;
                    });
            }
        }

        if (detail.IsSexControl == true) {

            let patientSex = this.EpisodeAction.Episode.Patient.Sex;
            if (detail.Sex.ObjectID.toString() != patientSex.toString()) {
                noerror = false;
                this.messageService.showError(i18n("M40001", "Seçilen tetkik sadece " + detail.Sex.ADI + " hastalar için istenebilir."));
                if (detail)
                    window.setTimeout(() => {
                        detail.Checked = false;
                    });
            }
        }

        if (detail.IsDurationControl == true) {

            if (detail.DurationValue > 0) {

                let inputParam: DurationLimitedProceduresQueryParam = new DurationLimitedProceduresQueryParam();
                inputParam.PatientObjectID = this.EpisodeAction.Episode.Patient.ObjectID.toString();
                inputParam.ProcedureObjectID = detail.ProcedureObjectDefID.toString();
                inputParam.Duration = detail.DurationValue;

                let apiUrl: string = 'api/ProcedureRequestService/GetLabTestByPatientByTestByDateExists';
                let resultText = await this.httpService.post<any>(apiUrl, inputParam);
                if (resultText != "") {
                    // let resultText: string = i18n("M40003", "İstediğiniz tetkiğin aşağıdaki tarihte sonucu mevcuttur. <br/><br/>");
                    // for (let test of result) {
                    //     resultText = resultText + i18n("M22109", "Sonuç Tarihi: ") + this.datePipe.transform(test.ResultDate, 'dd.MM.yyyy') + i18n("M26933", " Sonuç: ") + test.Result + " " + test.Unit + "(" + test.Reference + ")" + "<br/>";
                    // }

                    let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M40002", "Tetkik Süre Kontrolü"), resultText + i18n("M12687", "<br/><br/> Devam etmek istiyor musunuz?"));
                    if (messageResult === "H") {
                        noerror = false;
                        if (detail)
                            window.setTimeout(() => {
                                detail.Checked = false;
                            });
                    }
                }
            }
        }

        let testTypesCheckedParamList = [];
        if (this.testTypesCheckedParam != null && this.testTypesCheckedParam != "")
            testTypesCheckedParamList = this.testTypesCheckedParam.split(";")

        if ((this.EpisodeAction.constructor.name == "PatientExamination" || this.EpisodeAction.constructor.name == "Consultation") && detail.TestType != "" && isChecked && noerror &&
            (testTypesCheckedParamList.length == 0 || (testTypesCheckedParamList.length > 0 && testTypesCheckedParamList.find(x => x == detail.TestType) != null))) {
            try {
                let episodeID = typeof this.EpisodeAction.Episode === "string" ? this.EpisodeAction.Episode : this.EpisodeAction.Episode.ObjectID.toString();
                let apiUrl: string = 'api/EpisodeActionService/ControlTeletip?EpisodeID=' + episodeID + "&SUTCode=" + detail.Code + "&ProcedureDoctor=" + this.EpisodeAction.ProcedureDoctor.ObjectID;
                this.loadTipPanelOperation(true, 'Geçmiş işlemler kontrol ediliyor, lütfen bekleyiniz.');
                this.PreviousStudies = await this.httpService.get<Array<TeletipResult_Output>>(apiUrl);

            } catch (err) {
                this.PreviousStudies = new Array<TeletipResult_Output>();
                this.messageService.showError(err);

                //true ise hata aldığı zaman acil dışında işleme devam ettirmez
                if (this.ignoreMukerrerException && (this.EpisodeAction.constructor.name == "PatientExamination" && (<PatientExamination>this.EpisodeAction).EmergencyIntervention == null) || this.EpisodeAction.constructor.name == "Consultation") {
                    noerror = false;

                    window.setTimeout(() => {
                        detail.Checked = false;
                    });
                }

                this.loadTipPanelOperation(false, '');
            }

            this.loadTipPanelOperation(false, '');

            if (this.PreviousStudies.length > 0) {
                this.continueWithoutControl = false;// ilk başta zorlasın
                this.showTeletipResult = true;
                this.changeDetectorRef.detectChanges();
                let a = await this.subscribePopupButton(detail.Code);
                this.showTeletipResult = false;
                if (a == 2) {
                    noerror = false;

                    window.setTimeout(() => {
                        detail.Checked = false;
                    });
                }
                /* Tetkik tekrar istem gerekçesi soruluyor */
                /* Mükerrerlik sorugusu yapıldı ve rapor yada görüntü açarak ilk adımı geçti, son tetkiğin tarihi tetkiğin süre kontrolu yapılıp, tekrar istem gerekçesi soruluyor */
                else {
                    this.lastSelectedDetail = detail;
                    let durationValue: number = null;
                    let currentDateStr: any = this.datePipe.transform(await CommonService.RecTime(), 'MM.dd.yyyy');
                    let lastPerfomedDateStr: any = this.datePipe.transform(this.PreviousStudies[this.PreviousStudies.length - 1].PerformedDate, 'MM.dd.yyyy');
                    let lastDate: Date = new Date(lastPerfomedDateStr);
                    let currentDate: Date = new Date(currentDateStr);

                    durationValue = detail.DurationValue;
                    if (durationValue != null && durationValue > 0) {
                        var diff = Math.abs(currentDate.getTime() - lastDate.getTime());
                        var diffDays = Math.ceil(diff / (1000 * 3600 * 24));

                        if (diffDays < durationValue) {
                            let repeatClosed = await this.subscribeRepetReasonButton();
                            if (repeatClosed != null && repeatClosed == 1) {
                            } else {
                                noerror = false;
                                window.setTimeout(() => {
                                    detail.Checked = false;
                                });
                            }
                        }
                    }
                }
            /* Tetkik tekrar istem gerekçesi soruluyor */

                // else if (a == 1)//tamama bastı
                // {

                //     else
                //     {
                //         this.showTeletipResult = false;
                //     }

                // }
                // alert(a);
            }
        }

        //Tetkik Mükerrerlik Sorgusu
        if (isChecked && noerror && detail.RepetitionQueryNeeded == true) {

            let apiUrl: string = 'api/ProcedureRequestService/GetPatientStatus?EpisodeActionObjectID=' + this.EpisodeAction.ObjectID.toString();
            this.PatientStatus = await this.httpService.get<number>(apiUrl);

            if (this.PatientStatus == 0 || this.PatientStatus == 3) {

                let apiUrlVitaminD: string = 'api/EpisodeActionService/ControlVitaminD?EpisodeActionID=' + this.EpisodeAction.ObjectID.toString() + "&ProcedureObjectDefID=" + detail.ProcedureObjectDefID;
                this.loadTipPanelOperation(true, 'Tetkik Mükerrerlik Sorgusu Yapılıyor, Lütfen Bekleyiniz.');
                this.tetkikMukerrerlikResult = await this.httpService.get<ControlVitaminDResult>(apiUrlVitaminD);
                this.loadTipPanelOperation(false, '');
                if (!this.tetkikMukerrerlikResult.hasPermissionToRequest) {
                    noerror = false;
                    window.setTimeout(() => {
                        detail.Checked = false;
                    });
                }

                if (this.tetkikMukerrerlikResult.VitaminD_Response.sonuc != null) {
                    if (this.tetkikMukerrerlikResult.VitaminD_Response.sonuc.tetkikSonuc.length > 0) {
                        let message: string = "";
                        if (this.tetkikMukerrerlikResult.Alert != "")
                            message = this.tetkikMukerrerlikResult.Alert;
                        else
                            message = "Sut Kodu:" + this.tetkikMukerrerlikResult.VitaminD_Response.sonuc.tetkikSonuc[0].sutKodu + " - " + this.tetkikMukerrerlikResult.VitaminD_Response.sonuc.tetkikSonuc[0].sonucMesaji;
                        InfoBox.Alert(message);
                        if (this.tetkikMukerrerlikResult.VitaminD_Response.sonuc.tetkikSonuc[0].tetkikSonucBilgileri != null) {
                            this._tetkikSonucBilgileri = this.tetkikMukerrerlikResult.VitaminD_Response.sonuc.tetkikSonuc[0].tetkikSonucBilgileri;
                            this.showVitaminDResult = true;
                        }
                    }
                } else {
                    let message: string = "";
                    if (this.tetkikMukerrerlikResult.Alert != "")
                        message = this.tetkikMukerrerlikResult.Alert;
                    message += this.tetkikMukerrerlikResult.VitaminD_Response.mesaj;
                    InfoBox.Alert(message);
                }
            }
        }


        if (noerror) {
            //if (this.requestDate == undefined) // Taburcu olmauş hastalar için boş geliyor
            //    this.requestDate = new Date();
            await this.procedureRequestSharedService.procedureRequestOnChange(detailId, this.EpisodeAction.ObjectID, isChecked, this.chkEmergency.Value, this.requestDate, this.procedureByUser, detail.BaseAdditionalInfoFormViewModels, detail.BoundedProcedureRequestDetails, detail.ReasonForRepetition, detail.IsAdditionalApplication);
            if (detail != null) {
                if (detail.BoundedProcedureRequestDetails.length > 0) {
                    //Kullanıcıya bagımlı testlerı gosteren uyarı verılıyor
                    //Kullanicıya cok fazla pop-up geldigi icin  bagimli test bilgisi uyarisinin kaldirilmasi istendi, 18/11/2017
                    //if (isChecked == true) {
                    //    let boundTestDescription: string = "";
                    //    for (let boundDetail of detail.BoundedProcedureRequestDetails) {
                    //        boundTestDescription = boundTestDescription + boundDetail.Code + '-' + boundDetail.Name + '<br/>';
                    //    }

                    //    InfoBox.Alert('Bağımlı testler otomatik olarak seçilecektir.', boundTestDescription, null);
                    //}

                    await this.checkBoundedProceduresRequest(detail.BoundedProcedureRequestDetails, isChecked);


                }
                if (detail.GroupProcedureRequestDetails.length > 0) {
                    await this.addGroupProceduresRequest(detail.GroupProcedureRequestDetails, isChecked);
                }
            }
        }
    }

    async subscribePopupButton(Code) {

        let that = this;

        return new Promise((resolve, reject) => {
            let btnEvetSub;
            let btnHayirSub;
            window.setTimeout(() => {
                btnEvetSub = that.btnEvet.onClick.subscribe(async t => {
                    if (that.continueWithoutControl == false)//görüntüle ve veya rapor butonuna basarsa true oluyor bunlara gerek kalmıyor
                    {
                        if (that.EpisodeAction.constructor.name == "PatientExamination" && (<PatientExamination>that.EpisodeAction).EmergencyIntervention == null)
                            that.continueWithoutControl = false;
                        else if (that.EpisodeAction.constructor.name == "PatientExamination" && (<PatientExamination>that.EpisodeAction).EmergencyIntervention != null)
                            that.continueWithoutControl = true;
                        else if (that.EpisodeAction.constructor.name == "Consultation")
                            that.continueWithoutControl = false;
                        else
                            that.continueWithoutControl = true;
                    }

                    if (that.continueWithoutControl == false) {
                        let message = " Görüntü ya da Raporu açmadan bu işlemi ekleyemezsiniz. İşlemi eklemeden Devam Etmek İstiyor musunuz?"
                        let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), message, 1);
                        if (result === "OK") {
                            btnEvetSub.unsubscribe();
                            btnHayirSub.unsubscribe();
                            resolve(2);
                        }
                        else
                            return;

                    }
                    else{
                        try {
                            let episodeID = typeof that.EpisodeAction.Episode === "string" ? that.EpisodeAction.Episode :that.EpisodeAction.Episode.ObjectID.toString();
                            let apiUrl: string = 'api/EpisodeActionService/GetPreviousStudiesSearchDetail?EpisodeID=' + episodeID + "&SUTCode=" + Code;
                            this.loadTipPanelOperation(true, 'Açılan görüntüler kontrol ediliyor işlemler kontrol ediliyor, lütfen bekleyiniz.');
                            let openResult = await this.httpService.get<boolean>(apiUrl);

                            if(openResult == false){
                                ServiceLocator.MessageService.showError("Açılan Rapor/Görüntü bilgisi teletıp birimine iletilemedi.\nLütfen rapor/görüntü'yü tekrar açınız.!");                                
                                return;
                            }  
                            else{
                                btnEvetSub.unsubscribe();
                                btnHayirSub.unsubscribe();
                                resolve(1);  
                            }  

                            this.loadTipPanelOperation(false,'');    
                        } catch (err) {
                            this.loadTipPanelOperation(false,'');

                            btnEvetSub.unsubscribe();
                            btnHayirSub.unsubscribe();
                            resolve(1);
                            
                        }
                    }

                })

                btnHayirSub = that.btnHayir.onClick.subscribe(t => {
                    btnHayirSub.unsubscribe();
                    btnEvetSub.unsubscribe();
                    resolve(2);

                })
            });

            //dxpopup.subscribe.onClose (=> {

            //  resolve(1);
            // }
            // })
        });
    }

    async subscribeRepetReasonButton() {

        let that = this;
        this.showRepeatReasonPopup = true;

        return new Promise((resolve, reject) => {
            let btnSaveRepetition;
            let btnHayirSub;
            window.setTimeout(() => {
                btnSaveRepetition = that.btnSaveRepetitionReason.onClick.subscribe(async t => {
                    if (this.lastSelectedDetail.ReasonForRepetition != null) {
                        this.showRepeatReasonPopup = false;
                        resolve(1);
                    }
                    else {
                        ServiceLocator.MessageService.showError("Tekrar İstem Gerekçesi seçmeden devam edemezsiniz.!");
                    }
                })
            });
        });
    }

    public onInpMemberDoctorRemoving(event) {

    }

    public async btnEvet_Click(event) {

    }

    public async btnHayir_Click(event) {

    }

    public async openImaj(event) {
        if (event.row != null) {

            if (event.row.data != null) {
                if (event.row.data.IsStudyExist) {
                    // let apiUrl: string = 'api/EpisodeActionService/OpenTeletipImaj?OrderID='+event.row.data.OrderId;

                    // this.PreviousStudies = await this.httpService.get<any>(apiUrl);
                    let teletipImaj_Input: TeletipImaj_Input = new TeletipImaj_Input();

                    teletipImaj_Input.AccessToken = "";
                    teletipImaj_Input.PatientCitizenId = this.EpisodeAction.Episode.Patient.UniqueRefNo.toString();
                    teletipImaj_Input.AccessionNumber = event.row.data.AccessionNumber;
                    teletipImaj_Input.DoctorCitizenId = "";

                    let apiUrl: string = 'api/EpisodeActionService/OpenTeletipImaj';
                    let result = await this.httpService.post<any>(apiUrl, teletipImaj_Input);

                    let win = window.open(result, '_blank');
                    win.focus();
                }
                else {
                    this.messageService.showInfo("Çekime ait görüntü mevcut değil");
                    return false;
                }
                this.continueWithoutControl = true;
            }
        }
    }

    public async openReport(event) {

        if (event.row != null) {

            if (event.row.data != null) {
                if (event.row.data.IsReportExist) {
                    let apiUrl: string = 'api/EpisodeActionService/OpenTeletipReport?OrderID=' + event.row.data.OrderId+"&PatientCitizenId="+this.EpisodeAction.Episode.Patient.UniqueRefNo.toString();

                    let result = await this.httpService.get<any>(apiUrl);

                    this.showTeletipResultReport = true;
                    this.teletipResultReportInfo = result;
                }
                else {
                    this.messageService.showInfo("Çekime ait rapor mevcut değil");
                    return false;
                }
                this.continueWithoutControl = true;
            }
        }

    }

    loadTipPanelOperation(visible: boolean, message: string): void {
        this.showTeletipLoadPanel = visible;
        if (visible)
            this.LoadPanelTipMessage = message;
        else
            this.LoadPanelTipMessage = '';
    }

    async checkBoundedProceduresRequest(procedureRequestDetailList: Array<vmProcedureRequestDetailDefinition>, isChecked: boolean) {
        let isCheckOrUnCheckDone: boolean;
        for (let boundDetail of procedureRequestDetailList) {
            isCheckOrUnCheckDone = false;
            for (let form of this.MostUsedRequestedProcedures) {

                for (let category of form.FormCategories) {
                    let categoryGridFormDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();
                    for (let i = 1; i <= 3; i++) {
                        if (i == 1)
                            categoryGridFormDetails = category.Grid1FormDetails;
                        if (i == 2)
                            categoryGridFormDetails = category.Grid2FormDetails;
                        if (i == 3)
                            categoryGridFormDetails = category.Grid3FormDetails;

                        for (let detail of categoryGridFormDetails) {
                            if (detail.Id.toString() === boundDetail.Id.toString()) {
                                if (detail.Checked != isChecked) {
                                    detail.Checked = isChecked;

                                    if (this.EpisodeAction != null)
                                        await this.procedureRequestSharedService.procedureRequestOnChange(boundDetail.Id, this.EpisodeAction.ObjectID, isChecked, this.chkEmergency.Value, this.requestDate, null, null, detail.BoundedProcedureRequestDetails, null);
                                    else
                                        await this.procedureRequestSharedService.procedureRequestOnChange(boundDetail.Id, null, isChecked, this.chkEmergency.Value, this.requestDate, null, null, detail.BoundedProcedureRequestDetails, null);

                                    isCheckOrUnCheckDone = true;
                                    break;
                                }
                            }
                        }

                        if (isCheckOrUnCheckDone == true) break;
                    }

                    if (isCheckOrUnCheckDone == true) break;
                }
                if (isCheckOrUnCheckDone == true) break;
            }
        }
    }

    async addGroupProceduresRequest(procedureRequestDetailList: Array<vmProcedureRequestDetailDefinition>, isChecked: boolean) {

        for (let reqDetail of procedureRequestDetailList) {
            if (this.EpisodeAction != null)
                await this.procedureRequestSharedService.procedureRequestOnChange(reqDetail.Id, this.EpisodeAction.ObjectID, isChecked, this.chkEmergency.Value, this.requestDate, null, null, null, null);
            else
                await this.procedureRequestSharedService.procedureRequestOnChange(reqDetail.Id, null, isChecked, this.chkEmergency.Value, this.requestDate, null, null, null, null);

        }
    }


    disableRequestForms(data: boolean) {
        this.disableRequestForm = data;
    }

    openAdditionalReportForm(vmRequest: vmRequestedProcedure, objectID?: string) {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();

            componentInfo.ComponentName = "AdditionalReportForm";
            componentInfo.ModuleName = "ProcedureRequestModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestModule';
            this.RequestedByResUser = vmRequest.RequestedByResUser;
            componentInfo.InputParam = new DynamicComponentInputParam(this, new ActiveIDsModel(null, null, null));
            if (objectID != null)
                componentInfo.objectID = objectID;

            let modalInfo: ModalInfo = new ModalInfo();
            //modalInfo.Title = ;
            modalInfo.Width = 700;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                let baseAdditionalInfoFormViewModel = inner.Param as BaseAdditionalInfoFormViewModel;
                if (baseAdditionalInfoFormViewModel != null && baseAdditionalInfoFormViewModel instanceof BaseViewModel) {
                    if (vmRequest.BaseAdditionalInfoFormViewModels == null) {
                        vmRequest.BaseAdditionalInfoFormViewModels = new Array<BaseAdditionalInfoFormViewModel>();
                    }
                    vmRequest.BaseAdditionalInfoFormViewModels.push(baseAdditionalInfoFormViewModel);
                }

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    openProcedureResultForm(vmRequest: vmRequestedProcedure, objectID?: string) {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();

            componentInfo.ComponentName = "ProcedureResultInfoForm";
            componentInfo.ModuleName = "ProcedureRequestModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestModule';
            this.RequestedByResUser = vmRequest.RequestedByResUser;
            componentInfo.InputParam = new DynamicComponentInputParam(this, new ActiveIDsModel(null, null, null));
            if (objectID != null)
                componentInfo.objectID = objectID;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Sonuç Değeri";
            modalInfo.Width = 500;
            modalInfo.Height = 250;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                let baseAdditionalInfoFormViewModel = inner.Param as BaseAdditionalInfoFormViewModel;
                if (baseAdditionalInfoFormViewModel != null && baseAdditionalInfoFormViewModel instanceof BaseViewModel) {
                    if (vmRequest.BaseAdditionalInfoFormViewModels == null) {
                        vmRequest.BaseAdditionalInfoFormViewModels = new Array<BaseAdditionalInfoFormViewModel>();
                    }
                    vmRequest.BaseAdditionalInfoFormViewModels.push(baseAdditionalInfoFormViewModel);
                }
            

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

}