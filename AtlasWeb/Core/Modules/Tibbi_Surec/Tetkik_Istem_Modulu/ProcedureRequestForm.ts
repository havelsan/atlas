//$4EC0962F
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Component, OnInit, Input, ViewChild, ViewChildren, QueryList, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { ProcedureRequestViewModel, vmProcedureRequestFormDefinition, vmProcedureRequestCategoryDefinition, vmProcedureRequestDetailDefinition, vmRequestedProcedure, DurationLimitedProceduresQueryParam, TeletipResult_Output, TeletipImaj_Input, TetkikMukerrerOutput, ControlVitaminDResult, TetkikSonucBilgileri } from "./ProcedureRequestViewModel";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ITTButton } from 'NebulaClient/Visual/ControlInterfaces/ITTButton';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DiagnosisGrid, PathologyRequest, PatientExamination } from 'NebulaClient/Model/AtlasClientModel';
import { DxAccordionComponent, DxTextBoxComponent, DxButtonComponent } from "devextreme-angular";
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureRequestSharedService } from "./ProcedureRequestSharedService";
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { Subscription } from 'rxjs';
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { DatePipe } from '@angular/common';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { ActiveIDsModel, ClickFunctionParams } from "app/Fw/Models/ParameterDefinitionModel";
import { ModalActionResult, ModalInfo } from "app/Fw/Models/ModalInfo";
import { DialogResult } from "app/NebulaClient/Utils/Enums/DialogResult";
import { DynamicComponentInfo } from "app/Fw/Models/DynamicComponentInfo";
import { DynamicComponentInputParam } from "app/Fw/Models/DynamicComponentInputParam";
import { EpisodeActionHelper } from "app/Helper/EpisodeActionHelper";
import { IModalService } from "app/Fw/Services/IModalService";
import { ShowBox } from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CommonService } from "ObjectClassService/CommonService";
import { ServiceLocator } from "../../../wwwroot/app/Fw/Services/ServiceLocator";

@Component({
    selector: 'procedure-request-form',
    templateUrl: './ProcedureRequestForm.html',
    providers: [MessageService, DatePipe]

})
export class ProcedureRequestForm extends TTUnboundForm implements OnInit, OnDestroy {
    txtProcedureName: TTVisual.ITTTextBox;
    searchProcedureName: string;
    chkEmergency: TTVisual.ITTCheckBox;
    hiddenProcedureSearch: boolean;
    public ViewModel: ProcedureRequestViewModel = new ProcedureRequestViewModel();
    private _procedureRequestFormResourceIDs: Array<Guid>;
    private _episodeAction: EpisodeAction;

    showPopupRequiredInfoForm: boolean;
    popupTitleRequiredInfoForm: string;
    public RequestedProceduresForRequiredInfoForm: Array<Guid> = new Array<Guid>();
    public ClinicAnemnesis: String;
    patientLastXDaysProcedureDefIDs: Array<string> = new Array<string>();
    requestDate: Date;
    disableRequestForm: boolean;
    testTypesCheckedParam: string = "";
    ignoreMukerrerException: boolean = false;
    showTeletipResult: boolean = false;
    showVitaminDResult: boolean = false;
    showTeletipResultReport: boolean = false;
    showRepeatReasonPopup: boolean = false;
    teletipResultReportInfo: string = "";
    PreviousStudies: Array<TeletipResult_Output> = new Array<TeletipResult_Output>();
    tetkikMukerrerlikResult: ControlVitaminDResult = new ControlVitaminDResult();
    _tetkikSonucBilgileri: Array<TetkikSonucBilgileri> = new Array<TetkikSonucBilgileri>();
    continueWithoutControl : boolean = false;//Acil ve yatan hastalar için sonuç ve rapor görüntüleme zorunluluğu yok
    public showTeletipLoadPanel = false;
    public LoadPanelTipMessage: string = '';
    PatientStatus: number;
    BloodRequestVisible: boolean = true;

    /*Tekrar İstem Gerekçesi*/
    ReasonForRepetitionRequest: TTVisual.ITTObjectListBox;
    /*Tekrar İstem Gerekçesi*/


    public loadedForms: any = {};
    public loadForm(formID: any) {
        this.loadedForms[formID] = true;
    }

    //@Input() EpisodeAction: EpisodeAction;
    @Input() set EpisodeAction(value: EpisodeAction) {
        this._episodeAction = value;
    }
    get EpisodeAction(): EpisodeAction {
        return this._episodeAction;
    }
    @Input() GridDiagnosisGridList: Array<DiagnosisGrid>;
    @Input() set ProcedureRequestFormResourceIDs(value: Array<Guid>) {
        this._procedureRequestFormResourceIDs = value;
        if (this.ProcedureRequestFormResourceIDs != null)
            this.loadViewModelByResSection();
    }
    get ProcedureRequestFormResourceIDs(): Array<Guid> {
        return this._procedureRequestFormResourceIDs;
    }
    @Input() MostUsedRequestedProcedures: Array<vmProcedureRequestFormDefinition> = new Array<vmProcedureRequestFormDefinition>();

    btnRequest: ITTButton = <ITTButton>{
        Visible: true,
        ReadOnly: false,
        Text: i18n("M16655", "İstek Yap")
    };

    @Input() set RequestDateParam(value: Date) {
        if (value != undefined)
            this.requestDate = value;
    }

    @ViewChild('txtProcedureName') procedureSearchTextBoxInstance: DxTextBoxComponent;
    @ViewChildren('procedureRequestAccordion') procedureRequestAccordionInstance: QueryList<DxAccordionComponent>;
    @ViewChildren('formTabs') formTabs: QueryList<HTMLLIElement>;
    @ViewChild('btnEvet') btnEvet: DxButtonComponent;
    @ViewChild('btnHayir') btnHayir: DxButtonComponent;
    @ViewChild('btnSaveRepetitionReason') btnSaveRepetitionReason: DxButtonComponent;

    public deletedProcedureRequestFormDetailIDSubscribe: Subscription;
    public selectedPackageProceduresFormDetailIDsSubscribe: Subscription;
    public requestDateSubscribe: Subscription;
    public disableRequestFormSubscribe: Subscription;
    public plannedRequestsSubscribe: Subscription;

    constructor(private procedureRequestSharedService: ProcedureRequestSharedService, protected messageService: MessageService, protected episodeActionHelper: EpisodeActionHelper, protected modalService: IModalService, 
        private httpService: NeHttpService, private datePipe: DatePipe, private changeDetectorRef: ChangeDetectorRef) {
        super("", "");

        //this.initSubscribers();
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
    async getPatientStatus() {
        let that = this;
        if(that.EpisodeAction != null && that.EpisodeAction.ObjectID != null)
        {
            let apiUrl: string = 'api/ProcedureRequestService/GetPatientStatus?EpisodeActionObjectID=' + that.EpisodeAction.ObjectID.toString();
            let result = await this.httpService.get<number>(apiUrl);
            this.PatientStatus = result;
            if (this.PatientStatus == 0 && (this.EpisodeAction.constructor.name == "PatientExamination" && (<PatientExamination>this.EpisodeAction).EmergencyIntervention == null))
                this.BloodRequestVisible = false;

            
        }
    }

    initSubscribers() {
        
        if (this.deletedProcedureRequestFormDetailIDSubscribe == null) {
            this.deletedProcedureRequestFormDetailIDSubscribe = this.procedureRequestSharedService.DeletedProcedureRequestFormDetailID.subscribe(
                deletedRequestFormDetailID => {
                    this.removeProcedureRequestCheck(deletedRequestFormDetailID);
                }
            );
        }

        if (this.selectedPackageProceduresFormDetailIDsSubscribe == null) {
            this.selectedPackageProceduresFormDetailIDsSubscribe = this.procedureRequestSharedService.SelectedPackageProceduresFormDetailIDs.subscribe(
                selectedPackageFormDetailIDs => {
                    this.checkSelectedPackageProcedureDetails(selectedPackageFormDetailIDs);
                }
            );
        }

        if (this.requestDateSubscribe == null) {
            this.requestDateSubscribe = this.procedureRequestSharedService.RequestDate.subscribe(
                requestDateInfo => {
                    this.requestDate = requestDateInfo;
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

        if (this.plannedRequestsSubscribe == null) {
            this.plannedRequestsSubscribe = this.procedureRequestSharedService.plannedRequestCarrierClass.subscribe(
                plannedRequestCarrier => {
                    this.requestDate = plannedRequestCarrier.requestDate;
                    this.checkSelectedPackageProcedureDetails(plannedRequestCarrier.procedureList);
                }
            );
        }
    }

    ngOnDestroy() {

        this.procedureRequestSharedService.SelectedPackageProceduresFormDetailIDParam = new Array<Guid>();

        if (this.deletedProcedureRequestFormDetailIDSubscribe != null) {
            this.deletedProcedureRequestFormDetailIDSubscribe.unsubscribe();
            this.deletedProcedureRequestFormDetailIDSubscribe = null;
        }

        if (this.selectedPackageProceduresFormDetailIDsSubscribe != null) {
            this.selectedPackageProceduresFormDetailIDsSubscribe.unsubscribe();
            this.selectedPackageProceduresFormDetailIDsSubscribe = null;
        }

        if (this.requestDateSubscribe != null) {
            this.requestDateSubscribe.unsubscribe();
            this.requestDateSubscribe = null;
        }

        if (this.disableRequestFormSubscribe != null) {
            this.disableRequestFormSubscribe.unsubscribe();
            this.disableRequestFormSubscribe = null;
        }

        if (this.plannedRequestsSubscribe != null) {
            this.plannedRequestsSubscribe.unsubscribe();
            this.plannedRequestsSubscribe = null;
        }
    }


    async checkSelectedPackageProcedureDetails(data: any) {
        let isChecked: boolean;
        //İstem panelinde paket icerisindeki test varsa o isaretlenecek
        for (let req of data) {
            isChecked = false;
            for (let form of this.ViewModel.FormDefinitions) {
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
                            if (detail.Id.toString() === req.toString()) {
                                if (detail.Checked == false) {
                                    detail.Checked = true;
                                    await this.procedureRequestOnChange(detail.Id, true, detail);
                                }
                                isChecked = true;
                                break;
                            }
                        }
                        if (isChecked == true) break;
                    }
                    if (isChecked == true) break;
                }
                if (isChecked == true) break;
            }

            //Sık Kullanılanlar panelinde paket icerisindeki test varsa o isaretlenecek
            if (isChecked == false) {
                for (let form of this.ViewModel.UserMostUsedFormDefinitions) {
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
                                if (detail.Id.toString() === req.toString()) {
                                    if (detail.Checked == false) {
                                        detail.Checked = true;
                                        await this.procedureRequestOnChange(detail.Id, true, detail);
                                    }
                                    isChecked = true;
                                    break;
                                }
                            }
                            if (isChecked == true) break;
                        }
                        if (isChecked == true) break;
                    }
                    if (isChecked == true) break;
                }
            }

            //Istem panelınde ve sık kullanılanlarda bulamıyorsa dırekt RequestedProcedures a eklenıyor.
            if (isChecked == false) {
                this.procedureRequestOnChange(req, true);
            }
        }
    }

    public initFormControls(): void {
        this.txtProcedureName = new TTVisual.TTTextBox();
        this.txtProcedureName.Name = "txtProcedureName";
        this.txtProcedureName.Text = "";


        this.chkEmergency = new TTVisual.TTCheckBox();
        this.chkEmergency.Value = false;
        this.chkEmergency.Text = i18n("M27300", "Acil");
        this.chkEmergency.Title = i18n("M27300", "Acil");
        this.chkEmergency.Name = "chkEmergency";
        this.chkEmergency.TabIndex = 80;

        this.ReasonForRepetitionRequest = new TTVisual.TTObjectListBox();
        this.ReasonForRepetitionRequest.ListDefName = "SKRSTekrarTetkikIstemGerekcesiList";
        this.ReasonForRepetitionRequest.ReadOnly = true;
        this.ReasonForRepetitionRequest.Name = "ReasonForRepetitionRequest";
        this.ReasonForRepetitionRequest.TabIndex = 19;
        this.ReasonForRepetitionRequest.AutoCompleteDialogHeight = "200px";
    }


    btnCollapseAllAccordions_valueChange() {
        this.procedureRequestAccordionInstance.forEach((dr, index, accordions) => dr.items.forEach((it, i, items) => dr.instance.collapseItem(i)));
    }


    btnExpandAllAccordions_valueChange() {
        this.procedureRequestAccordionInstance.forEach((dr, index, accordions) => dr.items.forEach((it, i, items) => dr.instance.expandItem(i)));
    }

    async getPatientLastNDaysProcedures() {
        if (this.patientLastXDaysProcedureDefIDs.length == 0) {


            let that = this;
            if (that.EpisodeAction != null) {

                let apiUrl: string = 'api/ProcedureRequestService/GetPatientProceduresByLastNDays?EpisodeActionObjectID=' + that.EpisodeAction.ObjectID.toString();
                let result = await this.httpService.get<Array<string>>(apiUrl);

                for (let procDefID of result) {
                    let isFound: boolean = false;
                    for (let form of this.ViewModel.FormDefinitions) {
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
                                    if (detail.ProcedureObjectDefID.toString() == procDefID) {
                                        detail.RequestedLastXDays = true;
                                        isFound = true;
                                        break;
                                    }
                                }
                                if (isFound) break;
                            }
                            if (isFound) break;
                        }
                        if (isFound) break;
                    }
                }
            }
        }
    }


    async cachedPostRequest<T>(url: string, parameters: any) {

        let cacheKey = url + "_" + JSON.stringify(parameters);

        let cacheData = sessionStorage[cacheKey];

        try {
            cacheData = JSON.parse(cacheData) as T;
        }
        catch (e) {

        }

        if (cacheData == null) {

            let result = await this.httpService.post<T>(url, parameters);
            sessionStorage.setItem(cacheKey, JSON.stringify(result));
            return result;
        }

        return cacheData;

    }


    async loadViewModelByResSection() {
        if (this.ProcedureRequestFormResourceIDs.length > 0) {
            if (this.ViewModel.FormDefinitions != null && this.ViewModel.FormDefinitions.length == 0) {
                //let fullApiUrl: string = 'api/ProcedureRequestService/GetProcedureRequestViewModel';
                let fullApiUrl: string = 'api/ProcedureRequestService/GetProcedureRequestViewModel_V2';
                // let result = await this.httpService.post<ProcedureRequestViewModel>(fullApiUrl, this.ProcedureRequestFormResourceIDs, ProcedureRequestViewModel);

                let result = await this.cachedPostRequest(fullApiUrl, this.ProcedureRequestFormResourceIDs);

                if (result.FormDefinitions.length > 0)
                    this.hiddenProcedureSearch = false;
                else
                    this.hiddenProcedureSearch = true;

                this.testTypesCheckedParam = result.TestTypesCheckedParam;
                this.ignoreMukerrerException = result.IgnoreMukerrerException;

                //Hem ıstem panelı hem de sık kullanılanların yuklenmesınde kod tekrarı vardı o duzeltıldı.
                let tempFormDefinitions: Array<vmProcedureRequestFormDefinition> = new Array<vmProcedureRequestFormDefinition>();
                for (let j = 1; j <= 2; j++) {
                    if (j == 1)
                        tempFormDefinitions = result.FormDefinitions;
                    else if (j == 2)
                        tempFormDefinitions = result.UserMostUsedFormDefinitions;


                    for (let form of tempFormDefinitions) {
                        let vmForm: vmProcedureRequestFormDefinition = new vmProcedureRequestFormDefinition();
                        vmForm.Id = form.Id;
                        vmForm.Name = form.Name;


                        for (let category of form.FormCategories) {
                            let vmCategory: vmProcedureRequestCategoryDefinition = new vmProcedureRequestCategoryDefinition();
                            vmCategory.Id = category.Id;
                            vmCategory.Name = category.Name;
                            vmCategory.IsPassiveNow = category.IsPassiveNow;
                            vmCategory.ReasonForPassive = category.ReasonForPassive;

                            let tempFormDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();
                            for (let i = 1; i <= 3; i++) {
                                if (i == 1)
                                    tempFormDetails = category.Grid1FormDetails;
                                else if (i == 2)
                                    tempFormDetails = category.Grid2FormDetails;
                                else if (i == 3)
                                    tempFormDetails = category.Grid3FormDetails;


                                for (let detail of tempFormDetails) {
                                    let vmdetailDef: vmProcedureRequestDetailDefinition = new vmProcedureRequestDetailDefinition();
                                    vmdetailDef.Id = detail.Id;
                                    vmdetailDef.Code = detail.Code;
                                    vmdetailDef.Name = detail.Name;
                                    vmdetailDef.ProcedureObjectDefID = detail.ProcedureObjectDefID;
                                    vmdetailDef.Checked = false;
                                    vmdetailDef.IsActive = detail.IsActive;
                                    vmdetailDef.RequestedLastXDays = false;
                                    if (detail.BoundedProcedureRequestDetails.length > 0) {
                                        for (let boundDetail of detail.BoundedProcedureRequestDetails) {
                                            vmdetailDef.BoundedProcedureRequestDetails.push(boundDetail);
                                        }
                                    }

                                    if (detail.GroupProcedureRequestDetails.length > 0) {
                                        for (let groupTestDetail of detail.GroupProcedureRequestDetails) {
                                            vmdetailDef.GroupProcedureRequestDetails.push(groupTestDetail);
                                        }
                                    }

                                    vmdetailDef.IsWorkingDay = detail.IsWorkingDay;
                                    vmdetailDef.IsPassiveNow = detail.IsPassiveNow;
                                    vmdetailDef.ResObservationUnitId = detail.ResObservationUnitId;
                                    vmdetailDef.IsSexControl = detail.IsSexControl;
                                    vmdetailDef.Sex = detail.Sex;
                                    vmdetailDef.IsDurationControl = detail.IsDurationControl;
                                    vmdetailDef.DurationValue = detail.DurationValue;
                                    vmdetailDef.TestType = detail.TestType;
                                    vmdetailDef.RepetitionQueryNeeded = detail.RepetitionQueryNeeded;

                                    if (i == 1)
                                        vmCategory.Grid1FormDetails.push(vmdetailDef);
                                    else if (i == 2)
                                        vmCategory.Grid2FormDetails.push(vmdetailDef);
                                    else if (i == 3)
                                        vmCategory.Grid3FormDetails.push(vmdetailDef);

                                }
                            }

                            vmForm.FormCategories.push(vmCategory);
                        }

                        if (j == 1)
                            this.ViewModel.FormDefinitions.push(vmForm);
                        else if (j == 2) {
                            this.ViewModel.UserMostUsedFormDefinitions.push(vmForm);
                            this.MostUsedRequestedProcedures.unshift(vmForm);
                        }
                    }
                }

                await this.getPatientLastNDaysProcedures();
                this.procedureRequestSharedService.onProcedureRequestFormLoaded.emit();
            }
        }
        else {
            this.hiddenProcedureSearch = true;
        }

        if (this.ViewModel.FormDefinitions != null && this.ViewModel.FormDefinitions.length > 0) {
            this.loadForm(this.ViewModel.FormDefinitions[0].Id);
        }
    }

    ngAfterViewInit(): void {
        this.initSubscribers();
    }

    ngOnInit(): void {
        this.initFormControls();
        this.getPatientStatus();
    }


    procedureTextSearch(event) {

        let searchedText = event.value;
        if (searchedText != null && searchedText != "") {

            for (let form of this.ViewModel.FormDefinitions) {
                let detailFoundOnFormDef = false;
                for (let category of form.FormCategories) {
                    let detailfound = false;
                    let categoryGridFormDetails: Array<vmProcedureRequestDetailDefinition> = new Array<vmProcedureRequestDetailDefinition>();

                    for (let i = 1; i <= 3; i++) {
                        if (i == 1)
                            categoryGridFormDetails = category.Grid1FormDetails;
                        if (i == 2)
                            categoryGridFormDetails = category.Grid2FormDetails;
                        if (i == 3)
                            categoryGridFormDetails = category.Grid3FormDetails;

                        for (let detail of categoryGridFormDetails) {
                            if (detail.Name.toLocaleUpperCase().includes(searchedText.toLocaleUpperCase(), 0)) {
                                detail.Color = { color: 'red' };
                                detailfound = true;
                                detailFoundOnFormDef = true;
                            }
                            else {
                                detail.Color = { color: 'black' };
                            }

                            if (!detailfound) {
                                if (detail.Code.includes(searchedText.toLocaleUpperCase(), 0)) {
                                    detail.Color = { color: 'red' };
                                    detailfound = true;
                                    detailFoundOnFormDef = true;
                                }
                                else {
                                    detail.Color = { color: 'black' };
                                }
                            }
                        }
                    }

                    if (detailfound) {

                        let accordion = this.procedureRequestAccordionInstance.find((dr, index, accordions) => dr.accessKey.toString() == form.Id.toString());
                        if (accordion != null && accordion != undefined) {
                            let accordionItem = accordion.items.find(
                                dr => dr.title == category.Name
                            );
                            let index = accordion.items.indexOf(accordionItem);
                            accordion.instance.expandItem(index);
                        }
                    }
                }

                let formTab: HTMLLIElement = this.formTabs.find((li, index, tabs) =>
                    li['nativeElement'].getAttribute('name') == form.Id.toString()
                );
                if (formTab) {
                    if (detailFoundOnFormDef) {
                        formTab['nativeElement'].children[0].style.color = 'red';
                    }
                    else {
                        formTab['nativeElement'].children[0].style.removeProperty("color");
                    }
                }
            }
        }


    }

    removeProcedureRequestCheck(detailId: Guid) {
        let isUnChecked: boolean;
        isUnChecked = false;
        for (let form of this.ViewModel.FormDefinitions) {
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

        //Sık Kullanılanlar panelinde paket icerisindeki test varsa onun check ı kaldırılacak
        if (isUnChecked == false) {
            for (let form of this.ViewModel.UserMostUsedFormDefinitions) {
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
    emergencyChecked(isChecked: boolean) {

        this.chkEmergency.Value = isChecked;
        this.procedureRequestSharedService.emergencyChecked(isChecked);

    }

    public lastSelectedDetail: vmRequestedProcedure = null; 
    async procedureRequestOnChange(detailId: Guid, isChecked: boolean, detail: any = null) {

        let noerror = true;
        let dateError = false;
        if (this.requestDate == undefined || this.requestDate == null) {
            noerror = false;
            this.messageService.showError(i18n("M30106", "İstem Tarihi boşsa ya da Klinik taburcu yapıldı ise Tetkik İstemi yapılamaz."));
            if (detail)
                window.setTimeout(() => {
                    detail.Checked = false;
                });
        }

        if (this.disableRequestForm == true) {
            noerror = false;
            this.messageService.showError(i18n("M20011", "Önceki tarihe Tetkik İstemi yapılamaz."));
            if (detail)
                window.setTimeout(() => {
                    detail.Checked = false;
                });
        }

        if (detail != null) {
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

            if ((this.EpisodeAction.constructor.name == "PatientExamination" || this.EpisodeAction.constructor.name == "Consultation") && detail.TestType != "" && isChecked  && noerror &&
                (testTypesCheckedParamList.length == 0 || (testTypesCheckedParamList.length > 0 && testTypesCheckedParamList.find(x => x == detail.TestType) != null))) 
            {
                try {
                    let episodeID = typeof this.EpisodeAction.Episode === "string" ? this.EpisodeAction.Episode :this.EpisodeAction.Episode.ObjectID.toString();
                    let apiUrl: string = 'api/EpisodeActionService/ControlTeletip?EpisodeID=' + episodeID + "&SUTCode=" + detail.Code+"&ProcedureDoctor="+this.EpisodeAction.ProcedureDoctor.ObjectID;
                    this.loadTipPanelOperation(true, 'Geçmiş işlemler kontrol ediliyor, lütfen bekleyiniz.');
                    this.PreviousStudies = await this.httpService.get<Array<TeletipResult_Output>>(apiUrl);

                } catch (err) {
                    this.PreviousStudies=new Array<TeletipResult_Output>();
                    this.messageService.showError(err);

                    //true ise hata aldığı zaman acil dışında işleme devam ettirmez
                    if (this.ignoreMukerrerException && (this.EpisodeAction.constructor.name == "PatientExamination" && (<PatientExamination>this.EpisodeAction).EmergencyIntervention == null) 
                        || this.EpisodeAction.constructor.name == "Consultation") {
                        noerror = false;

                        window.setTimeout(() => {
                            detail.Checked = false;
                        });
                    }

                    this.loadTipPanelOperation(false, '');
                }

                this.loadTipPanelOperation(false, '');

                if (this.PreviousStudies.length > 0)
                {
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
                    else
                    {
                        this.lastSelectedDetail = detail;

                        let durationValue: number = null;
                        let currentDateStr: any = this.datePipe.transform(await CommonService.RecTime(), 'MM.dd.yyyy');
                        let lastPerfomedDateStr: any = this.datePipe.transform(this.PreviousStudies[this.PreviousStudies.length - 1].PerformedDate, 'MM.dd.yyyy');
                        let lastDate: Date = new Date(lastPerfomedDateStr);
                        let currentDate: Date = new Date(currentDateStr);

                        durationValue = detail.DurationValue;
                        if (durationValue != null && durationValue > 0)
                        {
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
                    //
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
            if ((this.PatientStatus == 0 || this.PatientStatus == 3) && isChecked && noerror && detail.RepetitionQueryNeeded == true) //Ayaktan ya da günübirlikse kontrol yapılacak
            {
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
                        
                        message += "\nSut Kodu:" + this.tetkikMukerrerlikResult.VitaminD_Response.sonuc.tetkikSonuc[0].sutKodu + " - " + this.tetkikMukerrerlikResult.VitaminD_Response.sonuc.tetkikSonuc[0].sonucMesaji;
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
            if (this.EpisodeAction != null)
                await this.procedureRequestSharedService.procedureRequestOnChange(detailId, this.EpisodeAction.ObjectID, isChecked, this.chkEmergency.Value, this.requestDate, null, null, detail.BoundedProcedureRequestDetails, detail.ReasonForRepetition);
            else
                await this.procedureRequestSharedService.procedureRequestOnChange(detailId, null, isChecked, this.chkEmergency.Value, this.requestDate, null, null, detail.BoundedProcedureRequestDetails, detail.ReasonForRepetition);
            if (detail != null) {
                if (detail.BoundedProcedureRequestDetails.length > 0) {
                    //Kullanıcıya bagımlı testlerı gosteren uyarı verılıyor
                    //Kullanicıya cok fazla pop-up geldigi icin  bagimli test bilgisi uyarisinin kaldirilmasi istendi, 18/11/2017
                    //if (isChecked == true)
                    //{
                    //    let boundTestDescription: string = "";
                    //    for (let boundDetail of detail.BoundedProcedureRequestDetails) {
                    //        boundTestDescription = boundTestDescription + boundDetail.Code + '-' + boundDetail.Name + '<br/>';
                    //    }

                    //    InfoBox.Alert('Bağımlı tetkikler otomatik olarak seçilecektir.', boundTestDescription, null);
                    //}
                    await this.checkBoundedProceduresRequest(detail.BoundedProcedureRequestDetails, isChecked);
                }

                if (detail.GroupProcedureRequestDetails.length > 0) {
                    await this.addGroupProceduresRequest(detail.GroupProcedureRequestDetails, isChecked);
                }
            }
            if (this.searchProcedureName != "") {
                this.searchProcedureName = "";
                this.procedureSearchTextBoxInstance.instance.focus();

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
                    if(that.continueWithoutControl == false)//görüntüle ve veya rapor butonuna basarsa true oluyor bunlara gerek kalmıyor
                    {
                        if(that.EpisodeAction.constructor.name == "PatientExamination" && (<PatientExamination>that.EpisodeAction).EmergencyIntervention == null )
                            that.continueWithoutControl = false;
                        else if (that.EpisodeAction.constructor.name == "PatientExamination" && (<PatientExamination>that.EpisodeAction).EmergencyIntervention != null)  
                            that.continueWithoutControl = true; 
                        else if (that.EpisodeAction.constructor.name == "Consultation")
                            that.continueWithoutControl = false; 
                        else
                            that.continueWithoutControl = true;  
                    }
                        
                    if(that.continueWithoutControl == false)
                    {   let message =" Görüntü ya da Raporu açmadan bu işlemi ekleyemezsiniz. İşlemi eklemeden Devam Etmek İstiyor musunuz?"
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
        for (let reqDetail of procedureRequestDetailList) {
            isCheckOrUnCheckDone = false;
            for (let form of this.ViewModel.FormDefinitions) {
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
                            if (detail.Id.toString() === reqDetail.Id.toString()) {
                                if (detail.Checked != isChecked) {
                                    detail.Checked = isChecked;

                                    if (this.EpisodeAction != null)
                                        await this.procedureRequestSharedService.procedureRequestOnChange(reqDetail.Id, this.EpisodeAction.ObjectID, isChecked, this.chkEmergency.Value, this.requestDate, null, null, detail.BoundedProcedureRequestDetails, null);
                                    else
                                        await this.procedureRequestSharedService.procedureRequestOnChange(reqDetail.Id, null, isChecked, this.chkEmergency.Value, this.requestDate, null, null, detail.BoundedProcedureRequestDetails, null);

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

    onContextMenuPreparing(e: any): void {
        let that = this;
        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data') {
                e.items = [{
                    text: "Sık Kullanılanlara Ekle",
                    disabled: false,
                    onItemClick: function () {

                        that.AddMostUsed(e.row.data);
                    }
                }
                ];
            }
        }
    }

    cclick(event)
    {
        if(event != null)
        {
            if(event.itemData != null && event.itemData.text != null && event.itemData.text != '')// passive bilgisini buna atabildim
            {
                this.messageService.showInfo(event.itemData.text +" sebebi ile bu paneldeki tetkik/tahliller şu anda çalışılamamaktadır");
            }
        }
    }

    async AddMostUsed(data) {
        let param: AddMostUsedProcedureRequestFormParam = new AddMostUsedProcedureRequestFormParam();
        param.ProcedureObjectID = data.ProcedureObjectDefID;
        param.ObservationUnit = data.ResObservationUnitId;
        let apiUrl: string = '/api/ProcedureRequestService/AddMostUsedProcedureRequestForm';
        await this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.messageService.showInfo(i18n("M30813", "Hizmet/Tetkik, Sık Kullanılanlar Paneline eklendi."));
                this.procedureRequestSharedService.refreshMostUsedForm(true);
            }
        ).catch(error => {
            this.messageService.showError(error);
        });

    }

    public columns = [
        {
            //caption: "Tanı Adı",
            name: "column",
            //dataField: "Diagnose.GeneratedDisplayExpression",
            cellTemplate: "columnCellTemplate"
        },
        {
            dataField: "Code",
            cellTemplate: "columnCellTemplate",
            width: 0
        },
    ];


    procedureRequestOnChange2(detailId: Guid, isChecked: boolean) {

    }


    CloseRequestInfoForm(data: any) {
        this.showPopupRequiredInfoForm = data;
    }


    private async cmdImage_Click(): Promise<void> {
        let that = this;
        let fullApiUrl: string = "api/ProcedureRequestService/GetBloodRequestURL?EpisodeActionObjectID=" + that.EpisodeAction.ObjectID.toString();
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                if (result == null) {
                    InfoBox.Alert(i18n("M16463", "İmaj gösterme linki bulunamadı!"));
                }
                else {
                    let win = window.open(result, '_blank');
                    win.focus();
                }
            })
            .catch(error => {
                console.log(error);
            });

    }

    private openPathologyRequest() {
        let that= this;
        let episode = that.EpisodeAction.Episode.ObjectID;
        if (episode != null) {
            this.episodeActionHelper.getNewEpisodeAction(PathologyRequest.ObjectDefID, episode, PathologyRequest.PathologyRequestStates.Request).then(result => {

                let pathologyRequest: PathologyRequest = result as PathologyRequest;

                this.showPathologyRequest(pathologyRequest).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = result.Param as PathologyRequest;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        } else {
            this.messageService.showError('Patoloji isteği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir');
        }
    }

    private showPathologyRequest(data: PathologyRequest): Promise<ModalActionResult> {
        let that= this;
        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = new ActiveIDsModel(that.EpisodeAction.ObjectID,null,null);
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PathologyRequestForm';
            componentInfo.ModuleName = 'PatolojiModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Patoloji_Modulu/PatolojiModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
         
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20230", "Patoloji İstek");
            modalInfo.Width = 1300;
            modalInfo.Height = 750;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private async cmdBloodRequestAsk_Click(): Promise<void> {

        let that = this;
        let apiUrl: string = 'api/ProcedureRequestService/GetBloodProductProcedureInfo';  //?EpisodeActionObjectID=' + that.EpisodeAction.ObjectID.toString();
        let result = await this.httpService.post<any>(apiUrl, that.EpisodeAction.ObjectID.toString(), vmRequestedProcedure) as Array<vmRequestedProcedure>;

        this.procedureRequestSharedService.addProcedureRequestByList(result, this.chkEmergency.Value);
    }

    disableRequestForms(data: boolean) {
        this.disableRequestForm = data;
    }

   async ControlExternalPatientProcedure()
    {
        this.loadTipPanelOperation(true, 'Otomatik atılacak işlemler kontrol ediliyor, lütfen bekleyiniz.');
        let episodeID = typeof this.EpisodeAction.Episode === "string" ? this.EpisodeAction.Episode :this.EpisodeAction.Episode.ObjectID.toString();
        let apiUrl: string = '/api/DispatchExaminationService/ControlExternalPatient?EpisodeID=' + episodeID;            

        let  returnList = await this.httpService.get<Array<Guid>>(apiUrl);
        this.checkSelectedPackageProcedureDetails(returnList);
        this.loadTipPanelOperation(false,'');
    }


}

export class AddMostUsedProcedureRequestFormParam {
    public ProcedureObjectID: Guid;
    public ObservationUnit: Guid;
}

