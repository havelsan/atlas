//$DCA6A5B5
import { Component, OnInit, ApplicationRef, Input, Renderer2 } from '@angular/core';
import { Http } from "@angular/http";
import { ConsultationRequestViewModel } from "./ConsultationRequestViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { ActionTypeEnum, Episode, SubEpisode, SexEnum } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { PhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';
import { ResPoliclinic } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionHelper } from "app/Helper/EpisodeActionHelper";
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection, SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ConsReqOldConsultationInfo } from "./ConsultationRequestViewModel";
import { ConsReqConsultationDiagnosis } from "./ConsultationRequestViewModel";
import { IModalService } from "Fw/Services/IModalService";
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { CommonService } from "ObjectClassService/CommonService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { ResSectionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PatientInterviewForm, ConsultationFromExternalHospital, ExternalHospitalDefinition, DentalExamination, PoliclinicTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { AsyncSubject } from "rxjs";
import { InputModelForQueries } from '../Kayit_Kabul_Modulu/PatientAdmissionFormViewModel';
import { ShowBoxTypeEnum } from '../../../wwwroot/app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';


@Component({
    selector: 'ConsultationRequestForm',
    templateUrl: './ConsultationRequestForm.html',
    providers: [MessageService, EpisodeActionHelper]
})
export class ConsultationRequestForm extends TTVisual.TTForm implements OnInit {
    ConsultationRequestedResource: TTVisual.ITTObjectListBox;
    ConsultationRequestedUser: TTVisual.ITTObjectListBox;
    ExternalRequestedHospital: TTVisual.ITTObjectListBox;
    ExternalRequestedSpeciality: TTVisual.ITTObjectListBox;
    chkConsultationEmergency: TTVisual.ITTCheckBox;
    chkConsultationInPatientBed: TTVisual.ITTCheckBox;
    chkConsultationFromExternalHospital: TTVisual.ITTCheckBox;
    ConsultationRequestDescription: TTVisual.ITTRichTextBoxControl;
    btnConsultationRequest: TTVisual.ITTButton;
    ConsultationListView: TTVisual.ITTListView;
    pConsultationRequestDesc: TTVisual.ITTRichTextBoxControl;
    pConsultationResult: TTVisual.ITTRichTextBoxControl;
    pConsultationReasonOfCancel: TTVisual.ITTRichTextBoxControl;
    pObjectId: Guid;
    consReportDefName: string = "";
    consGridFilter: string = "";
    userListControl: boolean = false;
    resourceListControl: boolean = false;

    private ConsultationRequestForm_DocumentUrl: string = '/api/ConsultationRequestService/';
    private _objectContext: TTObjectContext;
    public get _ObjectContext(): TTObjectContext {
        return this._objectContext as TTObjectContext;
    }


    @Input() set ObjectContext(value: TTObjectContext) {
        this._objectContext = value;
    }


    public get _EpisodeAction(): EpisodeAction {
        return this._episodeAction as EpisodeAction;
    }

    private _episodeAction: EpisodeAction;
    @Input() set EpisodeAction(value: EpisodeAction) {
        this._episodeAction = value;
        if (this._episodeAction.IsNew != undefined)
            this.loadViewModel();
    }

    private _GridList: Array<any>;
    @Input() set GridList(value: Array<any>) {
        this._GridList = value;
    }
    get GridList(): Array<any> {
        return this._GridList;
    }

    private _isReadOnly: boolean = false;
    @Input() set IsReadOnly(value: boolean) {
        this._isReadOnly = value;
    }
    get IsReadOnly(): boolean {
        return this._isReadOnly;
    }

    public ViewModel: ConsultationRequestViewModel = new ConsultationRequestViewModel();
    public consultationICDList: Array<ConsReqConsultationDiagnosis> = new Array<ConsReqConsultationDiagnosis>();
    public isExternalConsultation: boolean = false;

    constructor(private services: ServiceContainer, private http: Http, protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService,
        private objectContextService: ObjectContextService, private detector: ApplicationRef, protected episodeActionHelper: EpisodeActionHelper, private reportService: AtlasReportService, private renderer: Renderer2) {
        super('', '');
        this._DocumentServiceUrl = this.ConsultationRequestForm_DocumentUrl;
        this.initFormControls();
    }

    protected loadViewModel() {
        this.ViewModel._EpisodeAction = this._episodeAction;
        if (this.ViewModel._EpisodeAction.IsNew != undefined) {
            let apiUrl: string = '/api/ConsultationRequestService/FillConsultationHistory';
            //let body = JSON.stringify(this.ViewModel)
            this.httpService.post<ConsultationRequestViewModel>(apiUrl, this.ViewModel, ConsultationRequestViewModel).then(
                x => {
                    this.ViewModel = x as ConsultationRequestViewModel;
                    this.chkConsultationInPatientBed.Visible = this.ViewModel.InPatientBedVisible;
                    this.LoadConsultationHistory();
                }

            );
        }

    }

    async setConsultationDoctorListFilter(data: any) {

        
        /*birimi filtreledikten sonra doktoru secince tekrar buraya donup 
        birim filtrelemesi yapmasini kontrol edebilmek icin kontrol set edildi*/
        this.resourceListControl = true; 

        if(this.firstClickControlForUser == false)
        this.firstClickControlForRes = true;

        else
        this.firstClickControlForRes = false;

        if (!data.selectedItem)
        {
   
            this.ViewModel.ResourceValue = null;
           // this.ViewModel.RequestedUser = null;
            this.userListControl = false;
            this.resourceListControl= false;
            this.ConsultationRequestedUser.ListFilterExpression = "1=1";

            if(this.firstClickControlForRes == true)
            {
                let input: InputModelForQueries = new InputModelForQueries();
                input.filter = " AND " + this.ConsultationRequestedUser.ListFilterExpression;
                this.FillDataSourcesForConsultationUsers(input); 
            }

            if(this.firstClickControlForRes)
            {
                this.firstClickControlForRes = false;
                this.firstClickControlForUser = false;
            }

        }
        else {
            this.ViewModel.ResourceValue = data.selectedItem;
            this.ConsultationRequestedUser.ListFilterExpression = "USERRESOURCES(RESOURCE ='" + data.selectedItem.ObjectID.toString() + "').EXISTS";

            if(this.firstClickControlForRes == true)
            {
                let input: InputModelForQueries = new InputModelForQueries();
                input.filter = " AND " + this.ConsultationRequestedUser.ListFilterExpression;
                this.FillDataSourcesForConsultationUsers(input); 
            }

            //let consultationReqResList: Array<ResSection.ConsultationRequestResourceListNql_Class> = await ResSectionService.ConsultationRequestResourceListNql(this.ConsultationRequestedUser.ListFilterExpression);
            //if (consultationReqResList.length == 1) {
            //    //this.ConsultationRequestedResource.SelectedObject =
            //}
        }
    }

    public firstClickControlForUser: boolean = false;
    public firstClickControlForRes: boolean = false;

   async setConsultationResourceListFilter(data: any) {

    if(this.firstClickControlForRes== false)
    {
        this.firstClickControlForUser = true;
    }
    else
    this.firstClickControlForUser =false;

       this.userListControl = true;

       if (data.selectedItem) {
           this.ViewModel.RequestedUser = data.selectedItem;
           let currentDate: Date = (await CommonService.RecTime());

           let a = await CommonService.PersonelIzinKontrol(data.selectedItem.ObjectID, currentDate);
           if (a) {
               this.messageService.showInfo(data.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
               setTimeout(() => {
                   this.ConsultationRequestedUser.SelectedObject = null;
                   this.ViewModel.RequestedUser = null;
               }, 500);

           }
           let input : InputModelForQueries =  new InputModelForQueries();

           this.ConsultationRequestedResource.ListFilterExpression = "RESOURCEUSERS(USER ='" + data.selectedItem.ObjectID.toString() + "').EXISTS";
           if(this.firstClickControlForUser == true)
           {
               this.consGridFilter = " AND "+ this.ConsultationRequestedResource.ListFilterExpression;
               input.filter = this.consGridFilter;
               this.FillDataSourcesForConsultationResource(input);
           }
       }

        let input : InputModelForQueries =  new InputModelForQueries();
        if (!data.selectedItem)
        {
            if(this.firstClickControlForUser == true)
            {
                this.ConsultationRequestedResource.ListFilterExpression = "1=1";
                this.consGridFilter = " AND "+ this.ConsultationRequestedResource.ListFilterExpression;
                input.filter = this.consGridFilter;
                this.userListControl= false;
                this.FillDataSourcesForConsultationResource(input);
            }

            else
            {
                if (this.ViewModel.ResourceValue) {
                    let input: InputModelForQueries = new InputModelForQueries();
                    input.filter = " AND " + "USERRESOURCES(RESOURCE ='" + this.ViewModel.ResourceValue.ObjectID.toString() + "').EXISTS";
                    this.FillDataSourcesForConsultationUsers(input);
                }
            }

            
            if(this.ViewModel.ResourceValue == null)
            {
                this.firstClickControlForRes = false;
                this.firstClickControlForUser = false;
            }

            if(this.firstClickControlForUser)
            {
                this.firstClickControlForRes = false;
                this.firstClickControlForUser = false; 
            }

        }
    }

    public async btnConsultationRequest_Click(): Promise<void> {
        if (this.ConsultationRequestDescription.Rtf == null || this.ConsultationRequestDescription.Rtf.toString() == "") {
            ServiceLocator.MessageService.showError(i18n("M16610", "İstek Açıklaması Girmeden İşleme Devam Edemezsiniz."));
            return;
        }
        if (this.isExternalConsultation) {
            if (!this.ExternalRequestedHospital.SelectedObject) {
                ServiceLocator.MessageService.showError(i18n("M17771", "Konsültasyon İstenen Dış XXXXXXyi seçiniz"));
                return;
            }
            if (!this.ExternalRequestedSpeciality.SelectedObject) {
                ServiceLocator.MessageService.showError(i18n("M17770", "Konsültasyon İstenen Dış XXXXXX Birimini seçiniz"));
                return;
            }

            let externalReqSpec : SpecialityDefinition = this.ExternalRequestedSpeciality.SelectedObject as SpecialityDefinition;
            if (this.ViewModel.PatientSexCode == 1 && externalReqSpec.Code == '3000') {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "Konsültasyon İstek", "Erkek hastaya " + externalReqSpec.Name + " biriminden konsültasyon isteği yapıyorsunuz!\r\nDevam etmek istediğinize emin misiniz?");
                if (messageResult === "E") {
                } else {
                    this.ExternalRequestedSpeciality.SelectedObject = null;
                    ServiceLocator.MessageService.showError("İstekten vazgeçildi.");
                    return;
                }
            }
        }
        else {
           // if (!this.ConsultationRequestedResource.SelectedObject) 
            if (!this.ViewModel.ResourceValue) {
                ServiceLocator.MessageService.showError(i18n("M17767", "Konsültasyon İstenen Birimi seçiniz."));
                return;
            }

            if (this.ViewModel.PatientSexCode == 1 && this.ViewModel.ResourceValue.SexException == SexEnum.Female) {

                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "Konsültasyon İstek", "Erkek hastaya " + this.ViewModel.ResourceValue.Name + " biriminden konsültasyon isteği yapıyorsunuz!\r\nDevam etmek istediğinize emin misiniz?");
                if (messageResult === "E") {
                } else {
                    this.ViewModel.ResourceValue = null;
                    ServiceLocator.MessageService.showError("İstekten vazgeçildi.");
                    return;
                }
            }
        }

        //if (!this.ConsultationRequestedUser.SelectedObject) {
        //    ServiceLocator.MessageService.showError("Konsültasyon İstenen Kişiyi seçiniz.");
        //    return;
        //}
        this.CreateNewConsultationRequest();
        //this.GridList = this.ConsultationListView.Items;
    }
    showPopup: boolean = false;
    public async ConsultationListView_Click(val: any): Promise<void> {
        this.showPopup = true;
        if (val.ConsultationReportDefName)
            this.consReportDefName = val.ConsultationReportDefName;
        else
            this.consReportDefName = "";
        if (val.ObjectId)
            this.pObjectId = <Guid>val.ObjectId;
        if (val.RequestDesc)
            this.pConsultationRequestDesc.Rtf = val.RequestDesc.toString();
        else
            this.pConsultationRequestDesc.Rtf = "";
        if (val.ConsultationResult)
            this.pConsultationResult.Rtf = val.ConsultationResult.toString();
        else
            this.pConsultationResult.Rtf = "";

        if (val.ConsultationReasonOfCancel) {
            this.pConsultationReasonOfCancel.Rtf = val.ConsultationReasonOfCancel.toString();
            this.pConsultationReasonOfCancel.Visible = true;
        }
        else {
            this.pConsultationReasonOfCancel.Rtf = "";
            this.pConsultationReasonOfCancel.Visible = false;
        }

        if (val.ConsultationDiagnosisList == null)
            this.consultationICDList = new Array<ConsReqConsultationDiagnosis>();
        else {
            this.consultationICDList = new Array<ConsReqConsultationDiagnosis>();
            for (let consDiagnose of val.ConsultationDiagnosisList) {
                let consICD: ConsReqConsultationDiagnosis = new ConsReqConsultationDiagnosis();
                consICD.consultationDiagnose = consDiagnose.consultationDiagnose;
                consICD.consultationFreeDiagnose = consDiagnose.consultationFreeDiagnose;
                this.consultationICDList.push(consICD);
            }
        }
    }

    public okClick(): void {
        this.pConsultationRequestDesc.Rtf = "";
        this.pConsultationResult.Rtf = "";
        this.pConsultationReasonOfCancel.Rtf = "";
        this.consReportDefName = "";
        this.pObjectId = null;
        this.showPopup = false;
    }

    private async printClick() {
        if (String.isNullOrEmpty(this.consReportDefName))
            return;
        try {
            const objectIdParam = new GuidParam(this.pObjectId);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport(this.consReportDefName, reportParameters);
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }

    }

    consultationListViewRowPrepared(row: any) {
        if (row.rowType == "data") {
            if (row.data.ConsultationStateStatus != null && row.data.ConsultationStateStatus != 0) {
                if (row.data.ConsultationStateStatus == 1) {
                    //row.rowElement.firstItem().css('background-color', '#c3f4e5');
                    this.renderer.setStyle(row.rowElement.firstItem(), "background-color", "#c3f4e5");
                }
                else {
                    //row.rowElement.firstItem().css('background-color', '#f4c3c3');
                    this.renderer.setStyle(row.rowElement.firstItem(), "background-color", "#f4c3c3");
                }
            }

        }
    }

    async consultationListViewRowRemoving(row: any) {
        let jqDeferred = new AsyncSubject();
        row.cancel = jqDeferred;
        if (row.data) {
            if (row.data.ConsultationState && (row.data.ConsultationState.valueOf() == Consultation.ConsultationStates.RequestAcception.valueOf()
                || row.data.ConsultationState.valueOf() == ConsultationFromExternalHospital.ConsultationFromExternalHospitalStates.Completed.valueOf()
                || row.data.ConsultationState.valueOf() == PatientInterviewForm.PatientInterviewFormStates.Procedure.valueOf()
                || row.data.ConsultationState.valueOf() == DentalExamination.DentalExaminationStates.Examination.valueOf())) {
                let that = this;
                this.httpService.get<boolean>(this._DocumentServiceUrl + "cancelConsultationRequest?consultationObjectID=" + row.data.ObjectId)
                    .then(response => {
                        let result: boolean = response as boolean;
                        jqDeferred.next(false);
                        jqDeferred.complete();
                        this.GridList.splice(this.GridList.indexOf(row.data), 1);
                        this.ConsultationListView.Items.splice(this.ConsultationListView.Items.indexOf(row.data), 1);
                        ServiceLocator.MessageService.showInfo(i18n("M17774", "Konsültasyon işlemi silindi."));
                    })
                    .catch(error => {
                        ServiceLocator.MessageService.showError(error);
                    });
            }
            else {
                if (row.data.ConsultationState)
                    ServiceLocator.MessageService.showError(row.data.ConsultationStateDisplayText + i18n("M11195", " aşamasındaki konsültasyonlar silinemez."));
                else {
                    ServiceLocator.MessageService.showError("Kaydedilmemiş konsültasyon silinemez.");
                }
                jqDeferred.next(true);
                jqDeferred.complete();
            }
        }

    }

    async chkConsultationFromExternalHospitalChanged(event: any) {
        if (this.chkConsultationFromExternalHospital.Value) {
            this.isExternalConsultation = true;
        }
        else {
            this.isExternalConsultation = false;
        }
        this.ConsultationRequestedResource.SelectedObject = null;
        this.ViewModel.ResourceValue = null;
        this.resourceListControl = false;
        this.ConsultationRequestedUser.SelectedObject = null;
        this.ViewModel.RequestedUser = null;
        this.ConsultationRequestedResource.ListFilterExpression = null;
        let input: InputModelForQueries = new InputModelForQueries();
        input.filter = this.ConsultationRequestedResource.ListFilterExpression;
        this.FillDataSourcesForConsultationResource(input);
        this.ConsultationRequestedUser.ListFilterExpression = null;
        let inputUsers: InputModelForQueries = new InputModelForQueries();
        inputUsers.filter = this.ConsultationRequestedUser.ListFilterExpression;
        this.userListControl = false;
        this.FillDataSourcesForConsultationUsers(inputUsers);
        this.ExternalRequestedHospital.SelectedObject = null;
        this.ExternalRequestedSpeciality.SelectedObject = null;
        this.chkConsultationEmergency.Value = false;
        this.chkConsultationInPatientBed.Value = false;
    }

    public LoadConsultationHistory(): void {

        let historyConsultation: Array<ConsReqOldConsultationInfo> = this.ViewModel.ConsultationsHistory;
        let itemList = new Array<any>();
        for (let cons of historyConsultation) {
            let p: any = {};

            p.ObjectId = cons.consultationObjectID,
                p.RequestDesc = cons.consultationRequestDescription,
                p.ConsultationResult = cons.consultationResult,
                p.ConsultationReasonOfCancel = cons.consultationReasonOfCancel,
                p.ConsultationDiagnosisList = cons.consultationDiagnosis,
                p.ConsultationStateStatus = cons.consultationStateStatus,
                p.ConsultationState = cons.consultationState,
                p.ConsultationObjectDefName = cons.consObjectDefName;
            p.ConsultationReportDefName = cons.consReportDefName;
            p.ConsultationStateDisplayText = cons.consultationStateDisplayText;

            p.SubItems =
                [
                    { Text: cons.consultationRequestDate },
                    { Text: cons.consultationRequesterDoctor },
                    { Text: cons.consultationMasterResource },
                    { Text: cons.consultationRequestedResource },
                    { Text: cons.consultationProcessDate },
                    { Text: cons.consultationProcessEndDate },
                    { Text: cons.consultationStateDisplayText }
                ];

            itemList.push(p);
        }

        this.ConsultationListView.Items = itemList;

    }

    public ConsultationList;
    async FillDataSourcesForConsultationResource(input: InputModelForQueries) {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/ConsultationRequestService/FillConsultationResourceList';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
          //  let options = new RequestOptions({ headers: headers });
            /*

            let result = await this.httpService.post(apiUrlForPASearchUrl, body);
            this.DoctorList = result;

            */
            await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
                let result = response;
                if (result) {
                    this.ConsultationList = result;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public ConsultationUserList;
    async FillDataSourcesForConsultationUsers(input: InputModelForQueries) {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/ConsultationRequestService/FillConsultationUserList';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
          //  let options = new RequestOptions({ headers: headers });
            /*

            let result = await this.httpService.post(apiUrlForPASearchUrl, body);
            this.DoctorList = result;

            */
            await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
                let result = response;
                if (result) {
                    this.ConsultationUserList = result;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public async CreateNewConsultationRequest(): Promise<void> {

        let that = this;
        let targetType = null;
        let requestedResource: ResSection = <ResSection> this.ViewModel.ResourceValue; //this.ConsultationRequestedResource.SelectedObject;
        let actionTypeEnum = ActionTypeEnum.Consultation;
        targetType = Consultation;
        if (this.isExternalConsultation) {
            actionTypeEnum = ActionTypeEnum.ConsultationFromExternalHospital;
            targetType = ConsultationFromExternalHospital;
        }
        else {
            if (requestedResource.ResSectionType === ResSectionTypeEnum.SosyalHizmetBirimi) {
                actionTypeEnum = ActionTypeEnum.PatientInterviewForm;
                targetType = PatientInterviewForm;
            }
            else if (requestedResource instanceof ResPoliclinic && (<ResPoliclinic>requestedResource).PoliclinicType === PoliclinicTypeEnum.DentalPoliclinic) {
                actionTypeEnum = ActionTypeEnum.DentalExamination;
                targetType = DentalExamination;
            }

        }

        this.httpService.get<any>(this._DocumentServiceUrl + "CreateNewConsultationRequest?actionTypeEnum=" + actionTypeEnum + "&episodeActionId=" + this._episodeAction.ObjectID, targetType)
            .then(result => {

                let episodeAction = null;
                if (actionTypeEnum == ActionTypeEnum.ConsultationFromExternalHospital) {
                    episodeAction = result as ConsultationFromExternalHospital;
                    episodeAction.MasterResource = <ResSection>that._episodeAction.MasterResource;
                    episodeAction.ProcedureDoctor = <ResUser>that._episodeAction.ProcedureDoctor;
                    episodeAction.RequestedExternalHospital = <ExternalHospitalDefinition>that.ExternalRequestedHospital.SelectedObject;
                    episodeAction.RequestedExternalSpeciality = <SpecialityDefinition>that.ExternalRequestedSpeciality.SelectedObject;
                    episodeAction.RequestDescription = that.ConsultationRequestDescription.Rtf;

                    if (that._episodeAction instanceof PhysicianApplication) {
                        episodeAction.Complaint = that._episodeAction.Complaint;
                        episodeAction.PatientHistory = that._episodeAction.PatientHistory;
                        episodeAction.PatientFamilyHistory = that._episodeAction.PatientFamilyHistory;
                        episodeAction.PatientStory = that._episodeAction.PatientStory;
                        episodeAction.PhysicalExamination = that._episodeAction.PhysicalExamination;
                    }
                }
                else if (actionTypeEnum == ActionTypeEnum.PatientInterviewForm) {
                    episodeAction = result as PatientInterviewForm;
                    episodeAction.MasterResource = requestedResource;
                    episodeAction.ProcedureByUser = <ResUser>that.ViewModel.RequestedUser; //that.ConsultationRequestedUser.SelectedObject;
                    episodeAction.MeetingReason = that.ConsultationRequestDescription.Rtf.toString();
                    episodeAction.RequestedBy = <ResUser>that._episodeAction.ProcedureDoctor;
                }
                else if (actionTypeEnum == ActionTypeEnum.DentalExamination) {
                    episodeAction = result as DentalExamination;
                    episodeAction.MasterResource = requestedResource;
                    episodeAction.ProcedureDoctor = <ResUser>that.ViewModel.RequestedUser;//that.ConsultationRequestedUser.SelectedObject;
                    episodeAction.ProcessTime = episodeAction.RequestDate;
                    episodeAction.MasterPhysicianApplication = that._episodeAction;
                    episodeAction.RequesterDoctor = <ResUser>that._episodeAction.ProcedureDoctor;
                    episodeAction.CurrentStateDefID = DentalExamination.DentalExaminationStates.Examination;
                    episodeAction.IsConsultation = true;
                    episodeAction.RequestDescription = that.ConsultationRequestDescription.Rtf;
                    if (that._episodeAction instanceof PhysicianApplication) {
                        episodeAction.Complaint = that._episodeAction.Complaint;
                        episodeAction.PatientHistory = that._episodeAction.PatientHistory;
                        episodeAction.PatientFamilyHistory = that._episodeAction.PatientFamilyHistory;
                        episodeAction.PatientStory = that._episodeAction.PatientStory;
                        episodeAction.PhysicalExamination = that._episodeAction.PhysicalExamination;
                    }

                }
                else {
                    episodeAction = result as Consultation;
                    episodeAction.MasterResource = requestedResource;
                    episodeAction.ProcedureDoctor = <ResUser>that.ViewModel.RequestedUser;//that.ConsultationRequestedUser.SelectedObject;
                    episodeAction.RequesterDoctor = <ResUser>that._episodeAction.ProcedureDoctor;
                    episodeAction.InPatientBed = that.chkConsultationInPatientBed.Value;
                    episodeAction.RequestDescription = that.ConsultationRequestDescription.Rtf;
                    if (that._episodeAction instanceof PhysicianApplication) {
                        episodeAction.Complaint = that._episodeAction.Complaint;
                        episodeAction.PatientHistory = that._episodeAction.PatientHistory;
                        episodeAction.PatientFamilyHistory = that._episodeAction.PatientFamilyHistory;
                        episodeAction.PatientStory = that._episodeAction.PatientStory;
                        episodeAction.PhysicalExamination = that._episodeAction.PhysicalExamination;
                    }
                }

                episodeAction.MasterAction = <EpisodeAction>that._episodeAction;
                episodeAction.FromResource = <ResSection>that._episodeAction.MasterResource;
                episodeAction.Episode = <Episode>that._episodeAction.Episode;
                episodeAction.SubEpisode = <SubEpisode>that._episodeAction.SubEpisode;
                episodeAction.Cancelled = false;
                episodeAction.Active = true;
                episodeAction.Emergency = that.chkConsultationEmergency.Value;

                that.GridList.push(episodeAction);
                that.AddItemToConsultationListView(episodeAction);

                // instanceof çalışmadığı için burası kapatılıp iflerin içine taşındı
                //episodeAction.MasterAction = that._episodeAction;
                //episodeAction.FromResource = <ResSection>that._episodeAction.MasterResource;
                //episodeAction.Episode = that._episodeAction.Episode;
                //episodeAction.SubEpisode = that._episodeAction.SubEpisode;
                //episodeAction.Cancelled = false;
                //episodeAction.Active = true;

                //episodeAction.Emergency = that.chkConsultationEmergency.Value;
                //if (that._episodeAction instanceof PhysicianApplication) {
                //    episodeAction.Complaint = that._episodeAction.Complaint;
                //    episodeAction.PatientHistory = that._episodeAction.PatientHistory;
                //    episodeAction.PatientFamilyHistory = that._episodeAction.PatientFamilyHistory;
                //    episodeAction.PatientStory = that._episodeAction.PatientStory;
                //    episodeAction.PhysicalExamination = that._episodeAction.PhysicalExamination;
                //}
                //that.GridList.push(episodeAction);
                //that.AddItemToConsultationListView(episodeAction, actionTypeEnum);

                that.ConsultationRequestedResource.SelectedObject = null;
                this.ViewModel.ResourceValue = null;
                that.ConsultationRequestedUser.SelectedObject = null;
                this.ViewModel.RequestedUser = null;
                this.userListControl= false;
                this.resourceListControl = false;
                that.ConsultationRequestedResource.ListFilterExpression = null;
                that.ConsultationRequestedUser.ListFilterExpression = null;
                that.ExternalRequestedHospital.SelectedObject = null;
                that.ExternalRequestedSpeciality.SelectedObject = null;
                that.chkConsultationEmergency.Value = false;
                that.chkConsultationInPatientBed.Value = false;
                //that.chkConsultationFromExternalHospital.Value = false;
                that.ConsultationRequestDescription.Rtf = "";

            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
            });



        //let context: TTObjectContext = new TTObjectContext(false);

        //if (this.isExternalConsultation) {
        //    let externalConsultation: ConsultationFromExternalHospital = new ConsultationFromExternalHospital(context);
        //    externalConsultation.ActionDate = await CommonService.RecTime();
        //    externalConsultation.RequestDate = await CommonService.RecTime();
        //    externalConsultation.MasterAction = this._episodeAction;
        //    externalConsultation.Episode = this._episodeAction.Episode;
        //    externalConsultation.MasterResource = <ResSection>this._episodeAction.MasterResource;
        //    externalConsultation.FromResource = <ResSection>this._episodeAction.MasterResource;
        //    externalConsultation.ProcedureDoctor = <ResUser>this._episodeAction.ProcedureDoctor;
        //    //externalConsultation.RequesterDoctor = <ResUser>this._episodeAction.ProcedureDoctor;
        //    //consultation.ProcedureSpeciality = this._episodeAction.ProcedureSpeciality;
        //    externalConsultation.SubEpisode = this._episodeAction.SubEpisode;
        //    //externalConsultation.InPatientBed = this.chkConsultationInPatientBed.Value;
        //    externalConsultation.Emergency = this.chkConsultationEmergency.Value;
        //    externalConsultation.RequestedExternalHospital = <ExternalHospitalDefinition>this.ExternalRequestedHospital.SelectedObject;
        //    externalConsultation.RequestedExternalSpeciality = <SpecialityDefinition>this.ExternalRequestedSpeciality.SelectedObject;
        //    if (this._episodeAction instanceof PhysicianApplication) {
        //        externalConsultation.Complaint = this._episodeAction.Complaint;
        //        externalConsultation.PatientHistory = this._episodeAction.PatientHistory;
        //        externalConsultation.PatientFamilyHistory = this._episodeAction.PatientFamilyHistory;
        //        externalConsultation.PatientStory = this._episodeAction.PatientStory;
        //        externalConsultation.PhysicalExamination = this._episodeAction.PhysicalExamination;
        //    }
        //    externalConsultation.RequestDescription = this.ConsultationRequestDescription.Rtf;
        //    externalConsultation.Cancelled = false;
        //    externalConsultation.Active = true;
        //    this.GridList.push(externalConsultation);
        //    this.AddItemToConsultationListView(externalConsultation);
        //}
        //else {

        //    let requestedResource: ResSection = <ResSection>this.ConsultationRequestedResource.SelectedObject;

        //    if (requestedResource.ResSectionType === ResSectionTypeEnum.SosyalHizmetBirimi) {
        //        let patientInterviewForm: PatientInterviewForm = new PatientInterviewForm(context);
        //        patientInterviewForm.ActionDate = await CommonService.RecTime();
        //        patientInterviewForm.RequestDate = await CommonService.RecTime();
        //        patientInterviewForm.MasterAction = this._episodeAction;
        //        patientInterviewForm.Episode = this._episodeAction.Episode;
        //        patientInterviewForm.MasterResource = requestedResource;
        //        patientInterviewForm.FromResource = <ResSection>this._episodeAction.MasterResource;
        //        patientInterviewForm.ProcedureByUser = <ResUser>this.ConsultationRequestedUser.SelectedObject;
        //        patientInterviewForm.SubEpisode = this._episodeAction.SubEpisode;
        //        patientInterviewForm.Emergency = this.chkConsultationEmergency.Value;
        //        patientInterviewForm.MeetingReason = this.ConsultationRequestDescription.Rtf.toString();
        //        patientInterviewForm.Cancelled = false;
        //        patientInterviewForm.Active = true;
        //        this.GridList.push(patientInterviewForm);
        //        this.AddItemToConsultationListView(patientInterviewForm);
        //    }
        //    else if (requestedResource instanceof ResPoliclinic && (<ResPoliclinic>requestedResource).PoliclinicType === PoliclinicTypeEnum.DentalPoliclinic) {
        //        let dentalConsultation: DentalExamination = new DentalExamination(context);
        //        dentalConsultation.ActionDate = await CommonService.RecTime();
        //        dentalConsultation.ProcessTime = await CommonService.RecTime();
        //        dentalConsultation.RequestDate = await CommonService.RecTime();
        //        dentalConsultation.MasterAction = this._episodeAction;
        //        dentalConsultation.MasterPhysicianApplication = this._episodeAction;
        //        dentalConsultation.Episode = this._episodeAction.Episode;
        //        dentalConsultation.MasterResource = requestedResource;
        //        dentalConsultation.FromResource = <ResSection>this._episodeAction.MasterResource;
        //        dentalConsultation.ProcedureDoctor = <ResUser>this.ConsultationRequestedUser.SelectedObject;
        //        dentalConsultation.RequesterDoctor = <ResUser>this._episodeAction.ProcedureDoctor;
        //        dentalConsultation.SubEpisode = this._episodeAction.SubEpisode;
        //        dentalConsultation.Emergency = this.chkConsultationEmergency.Value;
        //        dentalConsultation.CurrentStateDefID = DentalExamination.DentalExaminationStates.Examination;
        //        dentalConsultation.IsConsultation = true;
        //        if (this._episodeAction instanceof PhysicianApplication) {
        //            dentalConsultation.Complaint = this._episodeAction.Complaint;
        //            dentalConsultation.PatientHistory = this._episodeAction.PatientHistory;
        //            dentalConsultation.PatientFamilyHistory = this._episodeAction.PatientFamilyHistory;
        //            dentalConsultation.PatientStory = this._episodeAction.PatientStory;
        //            dentalConsultation.PhysicalExamination = this._episodeAction.PhysicalExamination;
        //        }
        //        dentalConsultation.RequestDescription = this.ConsultationRequestDescription.Rtf;
        //        dentalConsultation.Cancelled = false;
        //        dentalConsultation.Active = true;
        //        this.GridList.push(dentalConsultation);
        //        this.AddItemToConsultationListView(dentalConsultation);
        //    }
        //    else {
        //        let consultation: Consultation = new Consultation(context);
        //        consultation.ActionDate = await CommonService.RecTime();
        //        consultation.RequestDate = await CommonService.RecTime();
        //        consultation.MasterAction = this._episodeAction;
        //        consultation.Episode = this._episodeAction.Episode;
        //        consultation.MasterResource = requestedResource;
        //        consultation.FromResource = <ResSection>this._episodeAction.MasterResource;
        //        consultation.ProcedureDoctor = <ResUser>this.ConsultationRequestedUser.SelectedObject;
        //        consultation.RequesterDoctor = <ResUser>this._episodeAction.ProcedureDoctor;
        //        //consultation.ProcedureSpeciality = this._episodeAction.ProcedureSpeciality;
        //        consultation.SubEpisode = this._episodeAction.SubEpisode;
        //        consultation.InPatientBed = this.chkConsultationInPatientBed.Value;
        //        consultation.Emergency = this.chkConsultationEmergency.Value;
        //        if (this._episodeAction instanceof PhysicianApplication) {
        //            consultation.Complaint = this._episodeAction.Complaint;
        //            consultation.PatientHistory = this._episodeAction.PatientHistory;
        //            consultation.PatientFamilyHistory = this._episodeAction.PatientFamilyHistory;
        //            consultation.PatientStory = this._episodeAction.PatientStory;
        //            consultation.PhysicalExamination = this._episodeAction.PhysicalExamination;
        //        }
        //        consultation.RequestDescription = this.ConsultationRequestDescription.Rtf;
        //        consultation.Cancelled = false;
        //        consultation.Active = true;
        //        this.GridList.push(consultation);
        //        this.AddItemToConsultationListView(consultation);
        //    }
        //}
        //this.ConsultationRequestedResource.SelectedObject = null;
        //this.ConsultationRequestedUser.SelectedObject = null;
        //this.ConsultationRequestedResource.ListFilterExpression = null;
        //this.ConsultationRequestedUser.ListFilterExpression = null;
        //this.ExternalRequestedHospital.SelectedObject = null;
        //this.ExternalRequestedSpeciality.SelectedObject = null;
        //this.chkConsultationEmergency.Value = false;
        //this.chkConsultationInPatientBed.Value = false;
        //this.chkConsultationFromExternalHospital.Value = false;
        //this.ConsultationRequestDescription.Rtf = ""

    }

    public AddItemToConsultationListView(cons: any): void {
        let itemList = new Array<any>();
        itemList = this.ConsultationListView.Items;
        let p: any = {};

        if (cons instanceof Consultation) {
            p.ObjectId = cons.ObjectID,
                p.RequestDesc = cons.RequestDescription,
                p.ConsultationResult = null,
                p.ConsultationReasonOFCancel = null,
                p.ConsultationDiagnosisList = null,
                p.ConsultationStateStatus = 0,
                p.SubItems =
                [
                    { Text: cons.RequestDate },
                    { Text: (cons.RequesterDoctor ? cons.RequesterDoctor.Name : "") },
                    { Text: (cons.MasterResource ? cons.MasterResource.Name : "") },
                    { Text: (cons.ProcedureDoctor ? cons.ProcedureDoctor.Name : "") },
                    { Text: (cons.ProcessEndDate) },
                    { Text: i18n("M16626", "İstek Kabulü") }
                ];
        }
        if (cons instanceof PatientInterviewForm) {
            let patientInterviewForm: PatientInterviewForm = <PatientInterviewForm>cons;
            p.ObjectId = patientInterviewForm.ObjectID,
                p.RequestDesc = patientInterviewForm.MeetingReason,
                p.ConsultationResult = null,
                p.ConsultationReasonOFCancel = null,
                p.ConsultationDiagnosisList = null,
                p.ConsultationStateStatus = 0,
                p.SubItems =
                [
                    { Text: patientInterviewForm.RequestDate },
                    { Text: "" },
                    { Text: (patientInterviewForm.MasterResource ? patientInterviewForm.MasterResource.Name : "") },
                    { Text: (patientInterviewForm.ProcedureByUser ? patientInterviewForm.ProcedureByUser.Name : "") },
                    { Text: "" },
                    { Text: i18n("M16626", "İstek Kabulü") }
                ];
        }
        else if (cons instanceof ConsultationFromExternalHospital) {
            let consultationFromExternalHospital: ConsultationFromExternalHospital = <ConsultationFromExternalHospital>cons;
            p.ObjectId = cons.ObjectID,
                p.RequestDesc = cons.RequestDescription,
                p.ConsultationResult = null,
                p.ConsultationReasonOFCancel = null,
                p.ConsultationDiagnosisList = null,
                p.ConsultationStateStatus = 1,
                p.SubItems =
                [
                    { Text: consultationFromExternalHospital.RequestDate },
                    { Text: (consultationFromExternalHospital.ProcedureDoctor ? consultationFromExternalHospital.ProcedureDoctor.Name : "") },
                    { Text: (consultationFromExternalHospital.RequestedExternalHospital ? consultationFromExternalHospital.RequestedExternalHospital.Name : "") },
                    { Text: (consultationFromExternalHospital.RequestedExternalSpeciality ? consultationFromExternalHospital.RequestedExternalSpeciality.Name : "") },
                    { Text: (consultationFromExternalHospital.ProcessEndDate) },
                    { Text: i18n("M16686", "İstek Yapıldı") }
                ];
        }
        if (cons instanceof DentalExamination) {
            let dentalExamination: DentalExamination = <DentalExamination>cons;
            p.ObjectId = cons.ObjectID,
                p.RequestDesc = cons.RequestDescription,
                p.ConsultationResult = null,
                p.ConsultationReasonOFCancel = null,
                p.ConsultationDiagnosisList = null,
                p.ConsultationStateStatus = 1,
                p.SubItems =
                [
                    { Text: dentalExamination.RequestDate },
                    { Text: (dentalExamination.RequesterDoctor ? dentalExamination.RequesterDoctor.Name : "") },
                    { Text: (dentalExamination.MasterResource ? dentalExamination.MasterResource.Name : "") },
                    { Text: (dentalExamination.ProcedureDoctor ? dentalExamination.ProcedureDoctor.Name : "") },
                    { Text: (dentalExamination.ProcessEndDate) },
                    { Text: i18n("M16686", "İstek Yapıldı") }
                ];
        }

        itemList.push(p);
        this.ConsultationListView.Items = itemList;
    }



    async ngOnInit() {
        let input: InputModelForQueries = new InputModelForQueries();
        input.filter = null;
        this.FillDataSourcesForConsultationResource(input);
        this.FillDataSourcesForConsultationUsers(input);

    }



    public initFormControls(): void {

        this.ConsultationRequestedResource = new TTVisual.TTObjectListBox();
        this.ConsultationRequestedResource.ListDefName = "ConsultationRequestResourceList";
        this.ConsultationRequestedResource.Name = "ConsultationRequestedResource";
        this.ConsultationRequestedResource.TabIndex = 5;

        this.ConsultationRequestedUser = new TTVisual.TTObjectListBox();
        this.ConsultationRequestedUser.ListDefName = "ConsultationRequesterUserList";
        this.ConsultationRequestedUser.Name = "ConsultationRequestedUser";
        this.ConsultationRequestedUser.TabIndex = 7;

        this.ExternalRequestedHospital = new TTVisual.TTObjectListBox();
        this.ExternalRequestedHospital.ListDefName = "ExternalHospitalListDefinition";
        this.ExternalRequestedHospital.Name = "ExternalRequestedHospital";
        this.ExternalRequestedHospital.TabIndex = 5;

        this.ExternalRequestedSpeciality = new TTVisual.TTObjectListBox();
        this.ExternalRequestedSpeciality.ListDefName = "SpecialityListDefinition";
        this.ExternalRequestedSpeciality.Name = "ExternalRequestedSpeciality";
        this.ExternalRequestedSpeciality.TabIndex = 7;

        this.chkConsultationEmergency = new TTVisual.TTCheckBox();
        this.chkConsultationEmergency.Value = false;
        this.chkConsultationEmergency.Title = i18n("M27300", "Acil");
        this.chkConsultationEmergency.Name = "chkConsultationEmergency";
        this.chkConsultationEmergency.TabIndex = 10;

        this.chkConsultationInPatientBed = new TTVisual.TTCheckBox();
        this.chkConsultationInPatientBed.Value = false;
        this.chkConsultationInPatientBed.Title = i18n("M27406", "Yatağında");
        this.chkConsultationInPatientBed.Name = "chkConsultationInPatientBed";
        this.chkConsultationInPatientBed.TabIndex = 11;
        this.chkConsultationInPatientBed.ForeColor = "#f00800";

        this.chkConsultationFromExternalHospital = new TTVisual.TTCheckBox();
        this.chkConsultationFromExternalHospital.Value = false;
        this.chkConsultationFromExternalHospital.Title = i18n("M12748", "Dış Konsültasyon");
        this.chkConsultationFromExternalHospital.Name = "chkConsultationFromExternalHospital";
        this.chkConsultationFromExternalHospital.TabIndex = 11;
        this.chkConsultationFromExternalHospital.ForeColor = "#f00800";

        this.ConsultationRequestDescription = new TTVisual.TTRichTextBoxControl();
        this.ConsultationRequestDescription.DisplayText = i18n("M17760", "Konsültasyon İstem Sebebi");
        this.ConsultationRequestDescription.Iconized = true;
        this.ConsultationRequestDescription.Name = "ConsultationRequestDescription";
        this.ConsultationRequestDescription.TabIndex = 9;
        this.ConsultationRequestDescription.Rtf = "";

        this.btnConsultationRequest = new TTVisual.TTButton();
        this.btnConsultationRequest.Text = i18n("M16655", "İstek Yap");
        this.btnConsultationRequest.Name = "btnConsultationRequest";
        this.btnConsultationRequest.TabIndex = 12;

        this.ConsultationListView = <TTVisual.TTListView>{
            Visible: true,
            ReadOnly: this.IsReadOnly == true ? true : false,
            BackColor: "black",
            ForeColor: "yellow",
            Font: {
                Bold: false,
                Italic: false,
                Name: "Impact",
                Size: 11,
                Strikeout: false,
                Underline: false
            },
            AllowUserToDeleteRows: this.IsReadOnly == true ? false : true,
            Columns: [
                { Text: i18n("M16650", "İstek Tarihi"), DataType: 'date', Format: 'dd.MM.yyyy HH:mm'},
                { Text: i18n("M16656", "İstek Yapan") },
                { Text: i18n("M16685", "İstek Yapılan Yer") },
                { Text: i18n("M16683", "İstek Yapılan Kişi/Branş") },
                { Text: i18n("M11939", "Başlama Tarihi"), DataType: 'date', Format: 'dd.MM.yyyy HH:mm' },
                { Text: i18n("M11939", "Bitiş Tarihi"), DataType: 'date', Format: 'dd.MM.yyyy HH:mm' },
                //{ Text: "Sonuç" },
                { Text: i18n("M27303", "Durum") }
            ]
        };
        this.ConsultationListView.Name = "ConsultationListView";
        this.ConsultationListView.TabIndex = 0;
        this.ConsultationListView.MultiSelect = false;
        this.ConsultationListView.AllowUserToDeleteRows = true;

        this.pConsultationRequestDesc = new TTVisual.TTRichTextBoxControl();
        this.pConsultationRequestDesc.DisplayText = "";
        this.pConsultationRequestDesc.Iconized = true;
        this.pConsultationRequestDesc.Name = "pConsultationRequestDesc";
        this.pConsultationRequestDesc.TabIndex = 9;

        this.pConsultationResult = new TTVisual.TTRichTextBoxControl();
        this.pConsultationResult.DisplayText = "";
        this.pConsultationResult.Iconized = true;
        this.pConsultationResult.Name = "pConsultationResult";
        this.pConsultationResult.TabIndex = 9;

        this.pConsultationReasonOfCancel = new TTVisual.TTRichTextBoxControl();
        this.pConsultationReasonOfCancel.DisplayText = "";
        this.pConsultationReasonOfCancel.Iconized = true;
        this.pConsultationReasonOfCancel.Name = "pConsultationReasonOfCancel";
        this.pConsultationReasonOfCancel.TabIndex = 9;
        this.pConsultationReasonOfCancel.Visible = false;

    }

}
