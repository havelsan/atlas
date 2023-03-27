//$FCC32924

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Component, OnInit, ViewChild, Input, EventEmitter } from '@angular/core';
import { DispatchExaminationFormViewModel } from "./DispatchExaminationFormViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { DispatchExamination } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DispatchExaminationAdditionalApplication } from 'NebulaClient/Model/AtlasClientModel';
import { TTException } from "NebulaClient/Utils/Exceptions/TTException";
import { RequestedProceduresForm } from "Modules/Tibbi_Surec/Tetkik_Istem_Modulu/RequestedProceduresForm";
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ProcedureRequestForm } from "Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestForm";
import { guidValidationRules } from "devexpress-dashboard/model/index.internal";

@Component({
    selector: 'DispatchExaminationForm',
    templateUrl: './DispatchExaminationForm.html',
    outputs: ['DispatchExaminationSaveCompletedChanged'],
    providers: [MessageService]
})
export class DispatchExaminationForm extends TTVisual.TTForm implements OnInit {
    public GridAdditionalApplicationsColumns = [];
    public GridDiagnosisColumns = [];
    public dispatchExaminationFormViewModel: DispatchExaminationFormViewModel = new DispatchExaminationFormViewModel();

    public get _DispatchExamination(): DispatchExamination {
        return this._TTObject as DispatchExamination;
    }

    private DispatchExaminationForm_DocumentUrl: string = '/api/DispatchExaminationService/DispatchExaminationForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('DISPATCHEXAMINATION', 'DispatchExaminationForm');
        this._DocumentServiceUrl = this.DispatchExaminationForm_DocumentUrl;
        this.initViewModel();
    }

    public DispatchExaminationFormViewModel: DispatchExaminationFormViewModel;
    DispatchExaminationSaveCompletedChanged: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild(RequestedProceduresForm) requestedProceduresForm: RequestedProceduresForm;
    @ViewChild(ProcedureRequestForm) procedureRequestForm: ProcedureRequestForm;

    @Input() set EpisodeAction(value) {
        if (value != undefined) {
            this.ObjectID = value;

           // this.ngOnInit();
        }
    }

    public StoreResourceId() {

    }
    private ValidateViewModelLoadedParameterCount(): number {

        return 0;
    }

    async CompleteProcedureRequestOperations() {
        try {

            this.DispatchExaminationSaveCompletedChanged.emit("");
        }
        catch (ex) {

            TTVisual.InfoBox.Show(ex);

        }
    }

    async btnSave_Clicked() {
        if(this.dispatchExaminationFormViewModel.GridDiagnosisGridList == null || this.dispatchExaminationFormViewModel.GridDiagnosisGridList.length == 0)
        {
            // throw new TTException("Sevk kabulü oluşturmadan önce tanı girişi yapmalısınız!");
            ServiceLocator.MessageService.showInfo("Sevk kabulü oluşturmadan önce tanı girişi yapmalısınız!");
            return null;
        }

        let saveuserOption = await this.requestedProceduresForm.saveProcedureTestFilterUserOption();
        let returnValue: number;
        returnValue = await this.requestedProceduresForm.fireRequestedProceduresActions(this.dispatchExaminationFormViewModel._DispatchExamination);
        if (returnValue === 0) {
            this.dispatchExaminationFormViewModel.createNewProcedure = true;
        }
        else if (returnValue === 2) {
            // throw new TTException(i18n("M22395", "SUT Kural ihlali oldu ve işlemden vazgeçildi!"));
            ServiceLocator.MessageService.showInfo("SUT Kural ihlali oldu ve işlemden vazgeçildi!");
            return null;
        }
        if (returnValue != null)
            await this.DispatchSave();
    }

    async DispatchSave()
    {
        await this.save();

        await this.ngOnInit();

    }

    async btnExit_Clicked()
    {
        if (this.dispatchExaminationFormViewModel.GridDiagnosisGridList.length == 0 || this.dispatchExaminationFormViewModel._DispatchExamination.CurrentStateDefID.valueOf() == DispatchExamination.DispatchExaminationStates.New.id)
        {
            let message: string;
            message = i18n("M15435", "Tanı girişi yapılmayan hastalara kabul oluşturulmaz.Çıkış yapmak istediğinize emin misiniz?");
            let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), message, 1);
            if (result === "OK") {
                await this.DeleteDispatchExamiantion();
                await this.CompleteProcedureRequestOperations();
            }
            else
                return;
        }
        else
        {
            await this.CompleteProcedureRequestOperations();
        }
    }

    async DeleteDispatchExamiantion()
    {
        await this.httpService.post('/api/DispatchExaminationService/DeleteDispatchExamiantion', this.dispatchExaminationFormViewModel._DispatchExamination, DispatchExamination);
        ServiceLocator.MessageService.showInfo(i18n("M17014", "Kabul iptal edildi."));
    }
    async ngOnInit() {
        await this.load();
    }

    public initViewModel(): void {
        this._TTObject = new DispatchExamination();
        this.dispatchExaminationFormViewModel = new DispatchExaminationFormViewModel();
        this._ViewModel = this.dispatchExaminationFormViewModel;
        this.dispatchExaminationFormViewModel._DispatchExamination = this._TTObject as DispatchExamination;
        this.dispatchExaminationFormViewModel._DispatchExamination.Diagnosis = new Array<DiagnosisGrid>();
        this.dispatchExaminationFormViewModel._DispatchExamination.DispatchExaminationAdditionalApplications = new Array<DispatchExaminationAdditionalApplication>();
        this.dispatchExaminationFormViewModel.ProcedureRequestFormResourceIDs = new Array<Guid>();
    }

    protected loadViewModel() {
        let that = this;
        that.dispatchExaminationFormViewModel = this._ViewModel as DispatchExaminationFormViewModel;
        that._TTObject = this.dispatchExaminationFormViewModel._DispatchExamination;
        if (this.dispatchExaminationFormViewModel == null)
            this.dispatchExaminationFormViewModel = new DispatchExaminationFormViewModel();
        if (this.dispatchExaminationFormViewModel._DispatchExamination == null)
            this.dispatchExaminationFormViewModel._DispatchExamination = new DispatchExamination();
        that.dispatchExaminationFormViewModel._DispatchExamination.Diagnosis = that.dispatchExaminationFormViewModel.GridDiagnosisGridList;
        for (let detailItem of that.dispatchExaminationFormViewModel.GridDiagnosisGridList) {
            let diagnoseObjectID = detailItem["Diagnose"];
            if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                let diagnose = that.dispatchExaminationFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                if (diagnose) {
                    detailItem.Diagnose = diagnose;
                }
            }
            let responsibleUserObjectID = detailItem["ResponsibleUser"];
            if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                let responsibleUser = that.dispatchExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                if (responsibleUser) {
                    detailItem.ResponsibleUser = responsibleUser;
                }
            }
        }

        // window.setTimeout(() => {
        //     this.ControlExternalPatient();
        // },3500);
         

        // let aa=new Array<Guid>();
        // aa.push(new Guid('18bd7811-c3ed-43d9-b525-0a3737c9fdf3'))
        // this.procedureRequestForm.checkSelectedPackageProcedureDetails(aa);
    }

    
    // async ControlExternalPatient()
    // {
    //     let episodeID = typeof this.dispatchExaminationFormViewModel._DispatchExamination.Episode === "string" ? this.dispatchExaminationFormViewModel._DispatchExamination.Episode :this.dispatchExaminationFormViewModel._DispatchExamination.Episode.ObjectID.toString();
    //     let apiUrl: string = '/api/DispatchExaminationService/ControlExternalPatient?EpisodeID=' + episodeID;            

    //     let  returnList = await this.httpService.get<Array<Guid>>(apiUrl);
    //     this.procedureRequestForm.checkSelectedPackageProcedureDetails(returnList);
    //     // ServiceLocator.MessageService.showInfo(i18n("M17014", "Kabul iptal edildi."));
    // }
}