//$2E87B09A
import { Injectable, EventEmitter } from '@angular/core';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Subject } from 'rxjs';
import { Observable } from 'rxjs';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { vmRequestedProcedure, ProcedureReqInfoInputDVO, AdditionalAppInfoInputDVO, vmProcedureRequestDetailDefinition} from "./ProcedureRequestViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'Fw/Services/MessageService';
import { ReplaySubject } from 'rxjs';
import { BaseAdditionalInfoFormViewModel } from "./BaseAdditionalInfoFormViewModel";
import { SKRSTekrarTetkikIstemGerekcesi } from '../../../wwwroot/app/NebulaClient/Model/AtlasClientModel';


@Injectable()
export class ProcedureRequestSharedService {
    public ProcedureRequestFormDetailIDParam: Guid = new Guid();
    public ProcedureRequestFormDetailParam: vmRequestedProcedure = new vmRequestedProcedure();
    public DeletedProcedureRequestFormDetailIDParam: Guid = new Guid();
    public SelectedPackageProceduresFormDetailIDParam: Array<Guid> = new Array<Guid>();
    public EmergencyCheckRequestedProceduresParam: boolean;
    public RequestDateParam: Date;
    public ProcedureByUserParam: string;
    public disableRequestFormParam: boolean;
    public refreshMostUsedRequestFormParam: boolean;
    public plannedRequestCarrierClassParam: PlannedRequestCarrierClass;
    public onProcedureRequestFormLoaded: EventEmitter<any> = new EventEmitter<any>();
    

    // ReplaySubject Tipindekilere , herhangi bir  Service subscribe olmadan önce deger set edildi ise subscripe olduğu anda eski değerlerini de alır . Her zaman son set edileni alması için 1 parametresi verildi
    //Subject Tipindekilere , herhangi bir  Service subscribe olmadan önce deger set edildi , Sunscribe olan servis o eski değerleri alamaz
    private _procedureRequestFormDetailID = new ReplaySubject<Guid>();
    private _procedureRequestFormDetail = new Subject<vmRequestedProcedure>();
    public _deletedProcedureRequestFormDetailID = new ReplaySubject<Guid>();
    private _selectedPackageProceduresFormDetailIDs = new Subject<Array<Guid>>();
    private _emergencyCheckRequestedProcedures = new ReplaySubject<boolean>();
    private _requestDate = new ReplaySubject<Date>(1);
    private _procedureByUser = new Subject<string>();
    private _disableRequestForm = new ReplaySubject<boolean>(1);
    private _refreshMostUsedRequestForm = new ReplaySubject<boolean>(1);
    public _plannedRequestCarrierClass = new Subject<PlannedRequestCarrierClass>();


    public ProcedureRequestFormDetailID: Observable<Guid> = this._procedureRequestFormDetailID.asObservable();
    public ProcedureRequestFormDetail: Observable<vmRequestedProcedure> = this._procedureRequestFormDetail.asObservable();
    public DeletedProcedureRequestFormDetailID: Observable<Guid> = this._deletedProcedureRequestFormDetailID.asObservable();
    public SelectedPackageProceduresFormDetailIDs: Observable<Array<Guid>> = this._selectedPackageProceduresFormDetailIDs.asObservable();
    public EmergencyCheckRequestedProcedures: Observable<boolean> = this._emergencyCheckRequestedProcedures.asObservable();
    public RequestDate: Observable<Date> = this._requestDate.asObservable();
    public ProcedureByUser: Observable<string> = this._procedureByUser.asObservable();
    public DisableRequestForm: Observable<boolean> = this._disableRequestForm.asObservable();
    public RefreshMostUsedRequestForm: Observable<Boolean> = this._refreshMostUsedRequestForm.asObservable();
    public plannedRequestCarrierClass: Observable<PlannedRequestCarrierClass> = this._plannedRequestCarrierClass.asObservable();

    constructor(private httpService: NeHttpService, protected messageService: MessageService ) {

    }


    async procedureRequestOnChange(detailId: Guid, episodeActionObjectID: Guid, isChecked: boolean, isEmergency: boolean, requestDate: Date, procedureByUser: string, baseAdditionalInfoFormViewModels: Array<BaseAdditionalInfoFormViewModel>, boundedProcedureRequestDetails: Array<vmProcedureRequestDetailDefinition>, reasonForRepetition:SKRSTekrarTetkikIstemGerekcesi, isAdditionalApplication: boolean = null)  {
        let that = this;
        if (isChecked) {
            let inputDVO = new ProcedureReqInfoInputDVO();
            if (episodeActionObjectID != null)
                inputDVO.EpisodeActionObjectId = episodeActionObjectID.toString();
            inputDVO.CheckedFormDetailObjectId = detailId.toString();
            if (!String.isNullOrEmpty(procedureByUser))
                inputDVO.ProcedureByUserId = procedureByUser;

            inputDVO.IsAdditionalApplication = isAdditionalApplication;

            let apiUrl: string = 'api/ProcedureRequestService/GetRequestFormDetailProcedureRequestInfo';  //?CheckedFormDetailObjectId=' + detailId.toString() + "&EpisodeActionObjectId=" + episodeActionObjectID.toString();
            await this.httpService.post<vmRequestedProcedure>(apiUrl, inputDVO, vmRequestedProcedure).then(result => {

                let vmRequest: vmRequestedProcedure = new vmRequestedProcedure();
                vmRequest.Id = result.Id;
                vmRequest.ProcedureCode = result.ProcedureCode;
                vmRequest.ProcedureName = result.ProcedureName;
                vmRequest.ProcedureObjectId = result.ProcedureObjectId;
                vmRequest.ProcedureObjectDefId = result.ProcedureObjectDefId;
                vmRequest.ProcedureType = result.ProcedureType;
                vmRequest.RequestDate = result.RequestDate;
                vmRequest.RequestedByResUser = result.RequestedByResUser;
                vmRequest.RequestedById = result.RequestedById;
                vmRequest.MasterResource = result.MasterResource;
                vmRequest.MasterResourceObjectId = result.MasterResourceObjectId;
                vmRequest.Amount = result.Amount;
                vmRequest.UnitPrice = result.UnitPrice;
                vmRequest.isAdditionalApplication = result.isAdditionalApplication;
                vmRequest.isEmergency = isEmergency;
                vmRequest.hasProcedureInstruction = result.hasProcedureInstruction;
                vmRequest.ProcedureInstructions = result.ProcedureInstructions;
                vmRequest.ProcedureInstructionReportName = result.ProcedureInstructionReportName;
                vmRequest.isExternalProcedureRequest = result.isExternalProcedureRequest;
                vmRequest.AlertMessage = result.AlertMessage;
                vmRequest.ProcedureUserId = result.ProcedureUserId;
                vmRequest.ProcedureResUser = result.ProcedureResUser;
                vmRequest.isAddedToMostUsedRequest = true;
                vmRequest.isGroupTest = result.isGroupTest;
                vmRequest.isProcedureReadOnly = true;
                vmRequest.isNew = true;
                vmRequest.BaseAdditionalInfoFormViewModels = baseAdditionalInfoFormViewModels;
                if(vmRequest.BaseAdditionalInfoFormViewModels != null && vmRequest.BaseAdditionalInfoFormViewModels.length != 0 && vmRequest.isAdditionalApplication == true){
                    vmRequest.BaseAdditionalInfoFormViewModels.forEach(baseAdditionalInfoFormViewModel => {
                        vmRequest.RequestDate = baseAdditionalInfoFormViewModel.RequestDate;
                });
                }

                //hizmet icin form acildi, kaydedilmeden vazgec'e tiklandi.
                if(isChecked == true && isAdditionalApplication == true && vmRequest.BaseAdditionalInfoFormViewModels.length == 0){
                    vmRequest.RequestDate = this.RequestDateParam;
                }

                vmRequest.BoundedProcedureRequestDetails = boundedProcedureRequestDetails;
                vmRequest.isPathologyRequired = result.isPathologyRequired;
                vmRequest.isResultNeeded = result.isResultNeeded;
                vmRequest.isSkinPrickTest = result.isSkinPrickTest;
                vmRequest.isRadiologyProcedure = result.isRadiologyProcedure;
                vmRequest.isRISIntegrated = result.isRISIntegrated;
                vmRequest.RightLeftInfoNeeded = result.RightLeftInfoNeeded;
                vmRequest.ReasonForRepetition = reasonForRepetition;
                if (vmRequest.isGroupTest != true) 
{
                    that.ProcedureRequestFormDetailParam = vmRequest;
                    that._procedureRequestFormDetail.next(vmRequest);
                }
            }).catch(err => {
                this.messageService.showError(err);
            });
        }
        else 
{
            that.ProcedureRequestFormDetailIDParam = detailId;
            that._procedureRequestFormDetailID.next(detailId);
        }

    }

    async addProcedureToRequestedProcedureGrid(procedureDefObjectId: Guid, episodeActionObjectID: Guid) {
        try {
            if (procedureDefObjectId != null) {
                let that = this;
                let inputDVO = new AdditionalAppInfoInputDVO();
                inputDVO.EpisodeActionObjectId = episodeActionObjectID.toString();
                inputDVO.ProcedureDefObjectId = procedureDefObjectId.toString();

                let apiUrl: string = 'api/ProcedureRequestService/GetProcedureRequestInfo';
                let result = await this.httpService.post<vmRequestedProcedure>(apiUrl, inputDVO, vmRequestedProcedure);

                let vmRequest: vmRequestedProcedure = new vmRequestedProcedure();
                vmRequest.Id = result.Id;
                vmRequest.ProcedureCode = result.ProcedureCode;
                vmRequest.ProcedureName = result.ProcedureName;

                //useSelectedDataByUser = true iken aşağıdaki 3 parametre RequestedProcedureFormdan seçilen değerler olarak alır
                // vmRequest.RequestDate = that.ViewModel.requestDate;
                vmRequest.RequestedByResUser = result.RequestedByResUser;
                vmRequest.ProcedureUserId = result.RequestedById;
                //
                vmRequest.MasterResource = result.MasterResource;
                vmRequest.Amount = result.Amount;
                vmRequest.UnitPrice = result.UnitPrice;
                vmRequest.isAdditionalApplication = true;

                vmRequest.useSelectedDataByUser = true; // bu parametre true iken ProcedureResUser,ProcedureUserId,RequestDate bilgileri RequestedProcedureFormdan seçilen değerler olarak alır

                that.ProcedureRequestFormDetailParam = vmRequest;
                that._procedureRequestFormDetail.next(vmRequest);

            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }


    addProcedureRequestByList(requestedProcedureList: Array<vmRequestedProcedure>, isEmergency: boolean) 
{
        let that = this;

        for (let requestedProcedure of requestedProcedureList)
        {
            that.ProcedureRequestFormDetailParam = requestedProcedure;
            that._procedureRequestFormDetail.next(requestedProcedure);
        }
    }

    async onRowDeleted(data): Promise<boolean> {
        if (data != null && data.data != null) {
            if (data.data.SubActionProcedureObjectId == null)  // henuz kaydedilmemis tetkik istem.
            {
                if (data.data.Id != null)
                {

                    let reqID: Guid;
                    reqID = data.data.Id;
                    this.DeletedProcedureRequestFormDetailIDParam = reqID;
                    this._deletedProcedureRequestFormDetailID.next(reqID);

                    if (data.data.BoundedProcedureRequestDetails.length > 0 )
                    {
                        // Testin bağımlı olduğu tetkikler de silinecek.
                        for (let boundedProcedureRequestDetail of data.data.BoundedProcedureRequestDetails)
                        {
                            let reqID: Guid;
                            reqID = boundedProcedureRequestDetail.Id;

                            this.ProcedureRequestFormDetailIDParam = reqID;
                            this._procedureRequestFormDetailID.next(reqID);

                            this.DeletedProcedureRequestFormDetailIDParam = reqID;
                            this._deletedProcedureRequestFormDetailID.next(reqID);
                        }
                    }
                    return true;
                }
            }
            else {
                try {
                    let apiUrl: string = 'api/ProcedureRequestService/CancelRequestedProcedure?SubactionProcedureObjectId=' + data.data.SubActionProcedureObjectId.toString();
                    let result = await this.httpService.get<boolean>(apiUrl);
                        if (result == true)
                            return true;
                        else
                            return false;


                }
                catch (ex) {
                    ServiceLocator.MessageService.showError(ex);
                }
                /*            //istem baslatılmıs tetkıkler ıcın silme islemi kontrollu yapılacak. uyarı verılecek
                            let apiUrl: string = 'api/ProcedureRequestService/CancelRequestedProcedure?SubactionProcedureObjectId=' + data.data.SubActionProcedureObjectId.toString();
                            let result = await this.httpService.get<boolean>(apiUrl);
            
                            if (result == true)
                                return true;
                            else {
                                ServiceLocator.MessageService.showError(i18n("M11645", "Başlatılmış işlem silinemez!"));
                                return false;
                            } */
            }
        }
        return false;
    }

    onpackageSelected(data)
    {
        if (data != null) {
            this.SelectedPackageProceduresFormDetailIDParam = data;
            this._selectedPackageProceduresFormDetailIDs.next(data);

        }
    }

    emergencyChecked(isChecked: boolean) {
        this.EmergencyCheckRequestedProceduresParam = isChecked;
        this._emergencyCheckRequestedProcedures.next(isChecked);

    }


    onRequestDateChange(data) {
        if (data != null)
            this.RequestDateParam = data;
        this._requestDate.next(data);

    }

    onProcedureByUserChange(data) {
        if (data != null)
            this.ProcedureByUserParam = data;
        this._procedureByUser.next(data);

    }

    setDisableRequestForm(data) {
        this.disableRequestFormParam = data;
        this._disableRequestForm.next(data);
    }

    refreshMostUsedForm(data) {
        if (data != null) {
            this.refreshMostUsedRequestFormParam = data;
            this._refreshMostUsedRequestForm.next(data);

        }
    }

    setPlannedRequests(data){
        if(data != null){
            this.plannedRequestCarrierClassParam = data;
            this._plannedRequestCarrierClass.next(data);
            this.plannedRequestCarrierClassParam = null;
        }
    }


}


export class PlannedRequestCarrierClass{
    public procedureList: Array<Guid>;
    public requestDate: Date;
}