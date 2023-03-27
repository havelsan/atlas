import { Component, OnInit } from '@angular/core';
import { EvdeSaglikHizmetEmirleriViewModel } from './EvdeSaglikBasvuruKaydetFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EvdeSaglikHizmetleri } from 'NebulaClient/Model/AtlasClientModel';
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';


@Component({
    selector: 'EvdeSaglikHizmetEmirleriViewModel',
    templateUrl: './EvdeSaglikHizmetEmirleriForm.html',
    providers: [MessageService]
})
export class EvdeSaglikHizmetEmirleriForm extends TTVisual.TTForm implements OnInit, IModal {
    public doctorArray: Array<any> = [];
    public ResponsibleDoctorCache: any;

    public evdeSaglikHizmetEmirleriViewModel: EvdeSaglikHizmetEmirleriViewModel = new EvdeSaglikHizmetEmirleriViewModel();
    public get _EvdeSaglikHizmetleri(): EvdeSaglikHizmetleri {
        return this._TTObject as EvdeSaglikHizmetleri;
    }
    private EvdeSaglikHizmetEmirleriForm_DocumentUrl: string = '/api/EvdeSaglikHizmetleriService/EvdeSaglikHizmetEmirleriForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('EVDESAGLIKHIZMETLERI', 'EvdeSaglikHizmetEmirleriForm');
        this._DocumentServiceUrl = this.EvdeSaglikHizmetEmirleriForm_DocumentUrl;
    }
    ngOnInit(): void {
        let that = this;
        let promiseArray: Array<Promise<any>> = new Array<any>();
        promiseArray.push(this.ResponsibleDoctor());
        Promise.all(promiseArray).then((sonuc: Array<any>) => {
            that.doctorArray = sonuc[0];
            this.load();
        }).catch(error => {
            this.messageService.showError(error);
        });
    }

    public setInputParam(value: any) {
    }
    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public async ResponsibleDoctor(): Promise<any> {
        if (!this.ResponsibleDoctorCache) {
            this.ResponsibleDoctorCache = await this.httpService.get("api/EvdeSaglikHizmetleriService/GetResponsibleDoctors");
            return this.ResponsibleDoctorCache;
        }
        else {
            return this.ResponsibleDoctorCache;
        }
    }

    getHomeCarePatientOrders(): void {
        let that = this;
        let apiUrl: string = '/api/EvdeSaglikHizmetleriService/GetHomeCarePatientOrders?DoctorID=' + this.evdeSaglikHizmetEmirleriViewModel.ResponsibleDoctor + '&Date=' + this.evdeSaglikHizmetEmirleriViewModel.Date.toString();
        that.httpService.get<any>(apiUrl)
            .then(response => {
                //Rapor açılacak
            })
            .catch(error => {
                this.messageService.showError(error);
            });
    }
}