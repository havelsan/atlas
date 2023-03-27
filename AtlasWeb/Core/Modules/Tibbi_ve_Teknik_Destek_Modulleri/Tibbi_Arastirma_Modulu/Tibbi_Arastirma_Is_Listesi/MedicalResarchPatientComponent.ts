import { Component, Output, EventEmitter } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { MessageService } from 'Fw/Services/MessageService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { IModalService } from 'app/Fw/Services/IModalService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { MRProcedurGridDTO, MRCreateProcedurGridGridListDTO, MRProcedureGridsDTO, MedicalResarchProcedurInputDTO } from './MedicalResarchPatientAdViewModel';
import { ProcedureDefinition, EpisodeAction, Episode } from 'app/NebulaClient/Model/AtlasClientModel';
import { RepeatedProceduresQueryInputDVO, EpisodeActionRequestedProcedureInfo, vmRequestedProcedureInfo, EpisodeActionFireRequestedProceduresResultInfo } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';

@Component({
    selector: 'MedicalResarchPatientComponent',
    templateUrl: './MedicalResarchPatientComponent.html',
    providers: [MessageService, SystemApiService]
})
export class MedicalResarchPatientComponent implements IModal {

    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "Lütfen Bekleyiniz..";

    public MedicalResarchEpisodeObjectID: Guid;
    public MRProcedurGridList: Array<MRProcedurGridDTO> = new Array<MRProcedurGridDTO>();
    constructor(private modalStateService: ModalStateService, private objectContextService: ObjectContextService, private http: NeHttpService, protected modalService: IModalService, protected systemApiService: SystemApiService) {

    }

    MRProcedurGridColumns = [
        {
            caption: 'Kodu',
            dataField: 'Code',
        },
        {
            caption: 'İşlem',
            dataField: 'procedureName',
        },
        {
            caption: 'Ücreti',
            dataField: 'Price',
        },
    ];

    MRCreateProcedurGridColumns = [
        {
            caption: 'İstem Tarihi',
            dataField: 'RequestDate'
        },
        {
            caption: 'İşlem Codu',
            dataField: 'Code'
        },
        {
            caption: 'İşlem Adı',
            dataField: 'Name'
        },
        {
            caption: 'Adet',
            dataField: 'Amount'
        },
        {
            caption: 'İşlem Durumu',
            dataField: 'Status'
        },
        {
            caption: 'Sonuc Değeri',
            dataField: 'ResaultValue'
        },
        {
            caption: 'Sonuc',
            dataField: 'Resault'
        },
        {
            caption: 'Birim Fiyat',
            dataField: 'Price'
        }
    ];


    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    @Output() public ActionExecuted: EventEmitter<any> = new EventEmitter<any>();
    public cancelClick(): void {
        if (this._modalInfo != null) {
            this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
        } else {
            this.ActionExecuted.emit({ Cancelled: true });
        }
    }

    public okClick(): void {
    }

    public async setInputParam(value: any) {
        this.MedicalResarchEpisodeObjectID = value;
        await this.createFormLoad();
    }

    async createFormLoad() {
        this.loadingVisible = true;
        let fullApiUrl: string = 'api/MedicalResarchPatientAdService/getMRProcedurGridList?MedicalResarchEpisodeObjectID=' + this.MedicalResarchEpisodeObjectID;
        await this.http.get(fullApiUrl)
            .then((res) => {
                let result: MRProcedureGridsDTO = res as MRProcedureGridsDTO;
                this.MRProcedurGridList = result.mRProcedurGridDTOs as Array<MRProcedurGridDTO>;
                this.MRCreateProcedurGridGridList = result.mRCreateProcedurGridGridListDTOs as Array<MRCreateProcedurGridGridListDTO>;
                this.loadingVisible = false;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
                this.loadingVisible = false;
            });
    }


    MRCreateProcedurGridGridList: Array<MRCreateProcedurGridGridListDTO> = new Array<MRCreateProcedurGridGridListDTO>();
    selectProcedure(value: any) {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            let input: MRCreateProcedurGridGridListDTO = new MRCreateProcedurGridGridListDTO();
            input.Amount = "1";
            input.Code = value.data.Code;
            input.Name = value.data.procedureName;
            input.Price = value.data.Price;
            input.RequestDate = new Date();
            input.ObjectID = new Guid();
            input.MedicalResarchPatientExObjectID = value.data.MedicalResarchPatientExObjectID;
            input.Resault = "";
            input.ResaultValue = "";
            input.Status = "";
            input.ProcedureObjectID = value.key.procedureObjectID;
            input.MedicalResarchEpisodeObjectID = this.MedicalResarchEpisodeObjectID.toString();
            if (this.MRCreateProcedurGridGridList.filter(x => x.Code == input.Code).length == 0)
                this.MRCreateProcedurGridGridList.push(input);
            else
                ServiceLocator.MessageService.showError("Aynı İşlemi Ekleyemessiniz.")

        }
    }

    async savePatientResarchClick() {
        this.loadingVisible = true;
        let returnValue: number;
        returnValue = await this.fireRequestedProceduresActions();
        if (returnValue === 0) {
            //this.patientExaminationDoctorFormNewViewModel.createNewProcedure = true;
        }
        else if (returnValue === 2) {
            ServiceLocator.MessageService.showError("SUT Kural ihlali oldu ve işlemden vazgeçildi!");
        }

        else if (returnValue === 3) {
            let inputDTOs: Array<MedicalResarchProcedurInputDTO> = new Array<MedicalResarchProcedurInputDTO>();
            for (let item of this.MRCreateProcedurGridGridList) {
                let input: MedicalResarchProcedurInputDTO = new MedicalResarchProcedurInputDTO();
                input.Amount = 1;
                input.episodeActionObjectID = this.MedicalResarchEpisodeObjectID.toString();
                input.procedureDefinitionObjectID = item.ProcedureObjectID.toString();
                input.medicalResarchPatientExObjectID = item.MedicalResarchPatientExObjectID.toString();
                input.MedicalResarchEpisodeObjectID = this.MedicalResarchEpisodeObjectID.toString();
                input.objectID = this.MedicalResarchEpisodeObjectID.toString();
                inputDTOs.push(input);
            }

            let fullApiUrl: string = 'api/MedicalResarchPatientAdService/saveMRProcedurePatient';
            await this.http.post(fullApiUrl, inputDTOs)
                .then(() => {
                    this.loadingVisible = false;
                })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                    this.loadingVisible = false;
                });
        }
        this.loadingVisible = false;

    }
    public RequestedProceduresForRequiredInfoForm: Array<Guid> = new Array<Guid>();
    async fireRequestedProceduresActions(): Promise<number> {
        try {
            let eaReqProcInfo: EpisodeActionRequestedProcedureInfo = new EpisodeActionRequestedProcedureInfo();
            let createNewProcedure: boolean = true;
            let returnValue: number;
            eaReqProcInfo.episodeActionObjectID = this.MedicalResarchEpisodeObjectID;
            eaReqProcInfo.emergency = false;
            if (createNewProcedure) {
                let inputDVO = new RepeatedProceduresQueryInputDVO();
                let _episodeAction: EpisodeAction = await this.objectContextService.getObject<EpisodeAction>(new Guid(this.MedicalResarchEpisodeObjectID.toString()), EpisodeAction.ObjectDefID);
                let _episode: Episode = await this.objectContextService.getObject<Episode>(new Guid(_episodeAction["Episode"].toString()), Episode.ObjectDefID);
                inputDVO.PatientID = _episode["Patient"].toString();
                for (let prObj of this.MRCreateProcedurGridGridList) {
                    inputDVO.RequestedProceduresObjectIDList.push(prObj.ProcedureObjectID.toString());
                }

                let apiUrlForRepeatedProcedure: string = 'api/ProcedureRequestService/CheckRepeatedProceduresByPatient';
                await this.http.post<any>(apiUrlForRepeatedProcedure, inputDVO).then(
                    result => {
                        let repeatedProceduresList = result as Array<ProcedureDefinition>;
                        if (repeatedProceduresList.length > 0) {
                            let msgStr: string = "";
                            for (let procedureDef of repeatedProceduresList) {
                                msgStr = msgStr + procedureDef.Code + "-" + procedureDef.Name + "<br/>";
                            }
                            for (let repeatedProc of repeatedProceduresList) {
                                for (let requestedProc of eaReqProcInfo.procedureRequestFormDetailDefinitions) {
                                    if (repeatedProc.ObjectID.toString() == requestedProc.ProcedureDefinitionObjectID.toString()) {

                                        let index = eaReqProcInfo.procedureRequestFormDetailDefinitions.indexOf(requestedProc, 0); //   this.RequestedProcedures.indexOf(delVmRequestedProcedure, 0);
                                        if (index > -1) {
                                            eaReqProcInfo.procedureRequestFormDetailDefinitions.splice(index, 1);
                                        }
                                    }
                                }
                            }
                        }
                    });


                //this.MRCreateProcedurGridGridList =  this.MRCreateProcedurGridGridList.filter(x=>x.Status != "");

                for (let repeatedProc of this.MRCreateProcedurGridGridList) {
                    let mRequestedProcedureInfo: vmRequestedProcedureInfo = new vmRequestedProcedureInfo();
                    mRequestedProcedureInfo.ProcedureDefinitionObjectID = repeatedProc.ObjectID;

                    let fullApiUrl: string = 'api/MedicalResarchPatientAdService/getProcedureRequestFormDetailDefinitionID?=' + repeatedProc.ProcedureObjectID;
                    await this.http.get(fullApiUrl)
                        .then((res) => {
                            mRequestedProcedureInfo.ProcedureRequestFormDetailDefinitionID = res as Guid;
                        })
                        .catch(error => {
                            ServiceLocator.MessageService.showError(error);
                        });
                        mRequestedProcedureInfo.RequestDate = new Date();

                        eaReqProcInfo.procedureRequestFormDetailDefinitions.push(mRequestedProcedureInfo);
                }

                let apiUrlForSaveProcedureRequest: string = 'api/PatientExaminationService/CreateActionForMyProcedureRequests';
                let result = await this.http.post<EpisodeActionFireRequestedProceduresResultInfo>(apiUrlForSaveProcedureRequest, eaReqProcInfo, EpisodeActionFireRequestedProceduresResultInfo);

                
                returnValue = 3;
            }
            return returnValue;
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
}

