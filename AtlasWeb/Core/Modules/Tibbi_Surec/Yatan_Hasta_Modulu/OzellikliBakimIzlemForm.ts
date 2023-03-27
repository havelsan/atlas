//$4AB27AFE
import { Component, ViewChild, OnInit, ApplicationRef, Input, Output, EventEmitter } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ShortInpatientReasonFormViewModel } from './ShortInpatientReasonFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';
import { OzellikliBakimIzlemFormViewModel, ProgressMedicineParameter, ProgressMedicineValues, OzellikliBakimIzlemParameterModel } from './OzellikliBakimIzlemFormViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'OzellikliBakimIzlemForm',
    templateUrl: './OzellikliBakimIzlemForm.html',
    providers: [MessageService]
})
export class OzellikliBakimIzlemForm extends TTVisual.TTForm implements OnInit {

    public ozellikliBakimIzlemFormViewModel: OzellikliBakimIzlemFormViewModel = new OzellikliBakimIzlemFormViewModel();
    public showLoadPanel: boolean = false;
    public LoadPanelMessage: string = "";
    public isViewModelLoaded: boolean = false;
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super();
        this.initViewModel();
    }

    private _ozellikliIzlemObjectID: Guid;
    @Input() set ozellikliIzlemObjectID(value: Guid) {
        if (value != null)
            this._ozellikliIzlemObjectID = value;
        this.LoadOzellikliBakimIzlemForm();


    }
    get ozellikliIzlemObjectID(): Guid {
        return this._ozellikliIzlemObjectID;
    }

    private _ozellikliIzlemIdContainer: OzellikliIzlemIdContainer;
    @Input() set ozellikliIzlemIdContainer(value: OzellikliIzlemIdContainer) {
        if (value != null) {
            if (value.ozellikliIzlemObjectID != null)
                this._ozellikliIzlemObjectID = value.ozellikliIzlemObjectID;
            if(value.episodeActionId != null)
                this._episodeActionId = value.episodeActionId;
        }

        this.LoadOzellikliBakimIzlemForm();


    }
    get ozellikliIzlemIdContainer(): OzellikliIzlemIdContainer {
        return this._ozellikliIzlemIdContainer;
    }

    private _episodeActionId: Guid;
    @Input() set episodeActionId(value: Guid) {
        if (value != null)
            this._episodeActionId = value;
        this.LoadOzellikliBakimIzlemForm();

    }
    get episodeActionId(): Guid {
        return this._episodeActionId;
    }

    @Output() SaveCompleteEvent: EventEmitter<boolean> = new EventEmitter<boolean>();

    // ***** Method declarations start *****

    protected async PreScript(): Promise<void> {

    }

    // *****Method declarations end *****

    public initViewModel(): void {

    }

    protected loadViewModel() {

    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public AddOrUpdateOzellikliIzlemForm() {
        let that = this;
        if (this.checkAllFieldReqs()) {

            this.loadPanelOperation(true, "İzlem Kaydediliyor Lütfen Bekleyiniz");
            let fullApiUrl: string = "/api/OzellikliBakimIzlemFormService/SaveOzellikliIzlemFormViewModel";
            this.httpService.post<any>(fullApiUrl, that.ozellikliBakimIzlemFormViewModel)
                .then(response => {
                    that.ozellikliBakimIzlemFormViewModel = response as OzellikliBakimIzlemFormViewModel;
                    that.ozellikliBakimIzlemFormViewModel.InpatientPhysicianAppId = this.episodeActionId;
                    this.loadPanelOperation(false, "");
                    that.SaveCompleteEvent.emit(true);
                    that.LoadOzellikliBakimIzlemForm();
                })
                .catch(error => {
                    this.loadPanelOperation(false, "");
                    console.log(error);
                });
            this.loadPanelOperation(false, "");
        }

    }

    public async LoadOzellikliBakimIzlemForm() {
        let that = this;
        let input: OzellikliBakimIzlemParameterModel = new OzellikliBakimIzlemParameterModel();
        let fullApiUrl: string = "/api/OzellikliBakimIzlemFormService/GetOzellikliIzlemFormViewModel";
        if (that.ozellikliIzlemObjectID != null)
            input.id = that.ozellikliIzlemObjectID;
        if (that.episodeActionId != null)
            input.physicianAppId = that.episodeActionId;
        this.httpService.post<any>(fullApiUrl, input)
            .then(response => {
                that.ozellikliBakimIzlemFormViewModel = response as OzellikliBakimIzlemFormViewModel;
                that.ozellikliBakimIzlemFormViewModel.InpatientPhysicianAppId = this.episodeActionId;
            })
            .catch(error => {
                console.log(error);
            });
    }

    public async getMedicineUsages(event) {
        let that = this;
        if (event.event != null && event.value != null) {
            let input: ProgressMedicineParameter = new ProgressMedicineParameter();
            input.physicianappId = that.episodeActionId;
            input.progressDate = event.value;
            let fullApiUrl: string = "/api/OzellikliBakimIzlemFormService/GetProgressMedicineValues";
            this.httpService.post<ProgressMedicineValues>(fullApiUrl, input)
                .then(response => {
                    if (response != null) {
                        that.ozellikliBakimIzlemFormViewModel.Azitromisin = response.Azitromisin;
                        that.ozellikliBakimIzlemFormViewModel.FavipavirAvigan = response.FavipavirAvigan;
                        that.ozellikliBakimIzlemFormViewModel.Hydroxychloroquine = response.Hydroxychloroquine;
                        that.ozellikliBakimIzlemFormViewModel.HighDoseCvitamin = response.HighDoseCvitamin;
                        that.ozellikliBakimIzlemFormViewModel.Kaletra = response.Kaletra;
                        that.ozellikliBakimIzlemFormViewModel.Oseltamivir = response.Oseltamivir;
                    }
                })
                .catch(error => {
                    console.log(error);
                });

        }
    }

    public checkAllFieldReqs(): boolean {
        if (this.ozellikliBakimIzlemFormViewModel.Description == null || String.isNullOrEmpty(this.ozellikliBakimIzlemFormViewModel.Description.toString())) {
            ServiceLocator.MessageService.showError("Izlem Notu boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.ProgressDate == null) {
            ServiceLocator.MessageService.showError("İzlem Tarihi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.PaoFioRatio == null) {
            ServiceLocator.MessageService.showError("PAO2-FIO2 Oranı bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.PaoFioRatio != null && (this.ozellikliBakimIzlemFormViewModel.PaoFioRatio.toString().indexOf(".") != -1 || this.ozellikliBakimIzlemFormViewModel.PaoFioRatio.toString().indexOf(",") != -1)) {
            ServiceLocator.MessageService.showError("PAO2-FIO2 Oranı bilgisi içerisinde nokta veya virgül karakteri bulunamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.GeneralStatus == Guid.Empty) {
            ServiceLocator.MessageService.showError("Genel Durum bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.IsIntensiveCare == Guid.Empty) {
            ServiceLocator.MessageService.showError("Hasta Yoğun Bakımda mı bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.HasClinicalFinding == Guid.Empty) {
            ServiceLocator.MessageService.showError("Klinik Bulgu Var mı bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.IsIsolatedInpatient == Guid.Empty) {
            ServiceLocator.MessageService.showError("İzolasyon Amaçlı Yatış mı bilgisi boş olamaz");
            return false;
        }
        if (this.ozellikliBakimIzlemFormViewModel.NonCovidInpatient == Guid.Empty) {
            ServiceLocator.MessageService.showError("Covid Dışı Yatış Yatış mı bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.HasCT == Guid.Empty) {
            ServiceLocator.MessageService.showError("BT Çekildi mi bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.HasPneumonia == Guid.Empty) {
            ServiceLocator.MessageService.showError("Pnömoni Var mı bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.CTResult == Guid.Empty) {
            ServiceLocator.MessageService.showError("BT Sonucu bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.HasIntubation == Guid.Empty) {
            ServiceLocator.MessageService.showError("Entübasyon Var mı bilgisi boş olamaz");
            return false;
        }


        if (this.ozellikliBakimIzlemFormViewModel.HighDoseCvitamin == Guid.Empty) {
            ServiceLocator.MessageService.showError("Yüksek Doz C Vitamini bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.Oseltamivir == Guid.Empty) {
            ServiceLocator.MessageService.showError("Oseltamivir 75Gr Taniflu bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.Hydroxychloroquine == Guid.Empty) {
            ServiceLocator.MessageService.showError("Hidroksiklorokin bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.Azitromisin == Guid.Empty) {
            ServiceLocator.MessageService.showError("Azitromisin bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.Kaletra == Guid.Empty) {
            ServiceLocator.MessageService.showError("Kaletra bilgisi boş olamaz");
            return false;
        }

        if (this.ozellikliBakimIzlemFormViewModel.FavipavirAvigan == Guid.Empty) {
            ServiceLocator.MessageService.showError("Favipavir Avigan bilgisi boş olamaz");
            return false;
        }

        return true;
    }

    async ngOnInit() {
        this.ozellikliBakimIzlemFormViewModel = new OzellikliBakimIzlemFormViewModel();
    }

    public onDescriptionChanged(event): void {

        if (event != null) {
            this.ozellikliBakimIzlemFormViewModel.Description = event;
        }
    }





    protected redirectProperties(): void {
    }

    public initFormControls(): void {


    }


}

export class OzellikliIzlemIdContainer {
    public ozellikliIzlemObjectID: Guid;
    public episodeActionId: Guid;
}
