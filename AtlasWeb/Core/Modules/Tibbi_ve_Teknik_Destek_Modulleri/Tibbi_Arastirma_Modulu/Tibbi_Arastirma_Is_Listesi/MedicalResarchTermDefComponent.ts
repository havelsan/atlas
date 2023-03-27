import { Component, EventEmitter } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { MessageService } from 'Fw/Services/MessageService';
import { MedicalResarchTermDefViewModel, MedicalResarchTermDefDTO } from './MedicalResarchTermDefViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'MedicalResarchTermDefComponent',
    templateUrl: './MedicalResarchTermDefComponent.html',
    providers: [MessageService, SystemApiService]
})
export class MedicalResarchTermDefComponent implements IModal {
    public model: MedicalResarchTermDefDTO = new MedicalResarchTermDefDTO();
    public openTermDef: boolean = false;
    public CloseComponent: EventEmitter<any> = new EventEmitter<any>();
    public medicalResarchTermDefs: Array<MedicalResarchTermDefDTO> = new Array<MedicalResarchTermDefDTO>();

    public loadingVisible:boolean= false;
    public LoadPanelMessage:string= "";

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
        this.getMedicalResarchTermList();
    }

    public async setInputParam(value: Object) {
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
    }

    public newTermClick() {
        this.openTermDef = true;
        this.model = new MedicalResarchTermDefDTO();
    }

    public async saveTermClick() {
        this.loadingVisible = true;
        this.LoadPanelMessage = "Dönem Kaydı Yapılıyor Lütfen Bekleyiniz.";
        let fullApiUrl: string = 'api/MedicalResarchTermDefService/saveMedicalResarchTerm';
        let inputDTO: MedicalResarchTermDefViewModel = new MedicalResarchTermDefViewModel();
        inputDTO = this.model;
        await this.http.post(fullApiUrl, inputDTO)
            .then((res) => {
                let resulst:string = res as string;
                ServiceLocator.MessageService.showInfo(resulst);
                this.loadingVisible = false;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
                this.loadingVisible = false;
            });
    }

    async getMedicalResarchTermList() {
        this.loadingVisible = true;
        this.LoadPanelMessage = "Lütfen Bekleyiniz.";
        let fullApiUrl: string = 'api/MedicalResarchTermDefService/getMedicalResarchTermList';
        await this.http.get<Array<MedicalResarchTermDefDTO>>(fullApiUrl, null)
            .then((res) => {
                this.medicalResarchTermDefs = res as Array<MedicalResarchTermDefDTO>;
                this.loadingVisible = false;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
                this.loadingVisible = false;
            });
    }

    selectionGridEvent(data:any){
        this.openTermDef = true;
        this.model = data.selectedRowsData[0];
    }
}

