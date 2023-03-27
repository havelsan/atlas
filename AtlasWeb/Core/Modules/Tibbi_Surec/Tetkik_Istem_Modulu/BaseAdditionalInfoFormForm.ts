//$0F15E8E4
import { Component, OnInit  } from '@angular/core';
import { BaseAdditionalInfoFormViewModel } from './BaseAdditionalInfoFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseAdditionalInfo, PatientExamination, InPatientPhysicianApplication, NursingApplication, Consultation, DentalExamination, EmergencyIntervention, PhysicalConditionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";

import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { Guid } from '../../../wwwroot/app/NebulaClient/Mscorlib/Guid';

@Component({
    selector: 'BaseAdditionalInfoForm',
    templateUrl: './BaseAdditionalInfoFormForm.html',
    providers: [MessageService]
})
export class BaseAdditionalInfoForm extends TTVisual.TTForm implements OnInit, IModal {
    public baseAdditionalInfoFormViewModel: BaseAdditionalInfoFormViewModel = new BaseAdditionalInfoFormViewModel();
    public get _BaseAdditionalInfoForm(): BaseAdditionalInfo {
        return this._TTObject as BaseAdditionalInfo;
    }
    private BaseAdditionalInfoForm_DocumentUrl: string = '/api/BaseAdditionalInfoFormService/BaseAdditionalInfoForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalStateService: ModalStateService) {
        super('BASEADDITIONALINFOFORM', 'BaseAdditionalInfoForm');
        this._DocumentServiceUrl = this.BaseAdditionalInfoForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseAdditionalInfo();
        this.baseAdditionalInfoFormViewModel = new BaseAdditionalInfoFormViewModel();
        this._ViewModel = this.baseAdditionalInfoFormViewModel;
        this.baseAdditionalInfoFormViewModel._BaseAdditionalInfoForm = this._TTObject as BaseAdditionalInfo;
    }

    protected loadViewModel() {
        let that = this;
        that.baseAdditionalInfoFormViewModel = this._ViewModel as BaseAdditionalInfoFormViewModel;
        that._TTObject = this.baseAdditionalInfoFormViewModel._BaseAdditionalInfoForm;
        if (this.baseAdditionalInfoFormViewModel == null)
            this.baseAdditionalInfoFormViewModel = new BaseAdditionalInfoFormViewModel();
        if (this.baseAdditionalInfoFormViewModel._BaseAdditionalInfoForm == null)
            this.baseAdditionalInfoFormViewModel._BaseAdditionalInfoForm = new BaseAdditionalInfo();

    }

    async ngOnInit() {
        await this.load(BaseAdditionalInfoFormViewModel);
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }

    // Popup olarak açıldığında Vievmodelini bunu açılan forma aktarabilmek için;
    protected _modalInfo: ModalInfo;

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


     // Popup olarak açıldığında bunu çan formdan Input alabilmek için ;
    inputParam: any;
    public async setInputParam(value: any) {
        this.inputParam = value;

        this.baseAdditionalInfoFormViewModel.resUserName = value.RequestedByResUser;
        if (this.inputParam._vmObjectID == Guid.Empty || this.inputParam._vmObjectID == undefined) {
            this.baseAdditionalInfoFormViewModel.SubActionProcedureObjectId = this.inputParam._vmObjectID;
        }

        if (value.EpisodeAction instanceof PatientExamination){
            this.baseAdditionalInfoFormViewModel.resDoctorName = value.EpisodeAction.ProcedureDoctor.Name;
            this.baseAdditionalInfoFormViewModel.patientName = value.EpisodeAction.Episode.Patient.Name + ' ' + value.EpisodeAction.Episode.Patient.Surname; 
        }
        else if (value.EpisodeAction instanceof InPatientPhysicianApplication || value.EpisodeAction instanceof NursingApplication){
            this.baseAdditionalInfoFormViewModel.resDoctorName = value.EpisodeAction.InPatientTreatmentClinicApp.ProcedureDoctor.Name;
            this.baseAdditionalInfoFormViewModel.patientName = await this.httpService.get<any>('api/ProcedureRequestService/GetPatientName?ObjectID=' + value.EpisodeAction.Episode.Patient.ObjectID);
        }

        //Hizmet eklerken bakilan tarih / saat duzenlemelerinin (İstem Tarihi date-box'ında bulunan) aynisini yapabilmek icin olusturuldu.
        let DateList: Array<Date> =  await this.httpService.get<any>('api/ProcedureRequestService/GetDateList?ObjectID=' + value.EpisodeAction.ObjectID);
        if(DateList != null && DateList.length > 0){
            this.baseAdditionalInfoFormViewModel.RequestDate = DateList[0];
            this.baseAdditionalInfoFormViewModel.SubEpisodeOpeningDate = DateList[1];
            this.baseAdditionalInfoFormViewModel.SubEpisodeClosingDate = DateList[2];
            this.baseAdditionalInfoFormViewModel.ClosingDate = DateList[3];
        }


    }


    protected async save() {

        //if (this.inputParam._FromResultNeeded == true) {
        //    if (this.inputParam._vmObjectID == Guid.Empty || this.inputParam._vmObjectID == undefined) {
        //        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._ViewModel);
        //    } else {
        //        super.save();
        //    }

        //} else {
            if (this._TTObject.IsNew == true) // ilk kaydetme işlemi Hizmetin  kaydet metodu ile yapılacak
            {
                this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._ViewModel);
            }
            else // Daha sonra Kendi Obje savini Kullanılacak
                super.save();
       // }
    }

    public async cancel()  {
        if (this._TTObject.IsNew == true) {
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._ViewModel);
        }
        else super.cancel();
    }

}
