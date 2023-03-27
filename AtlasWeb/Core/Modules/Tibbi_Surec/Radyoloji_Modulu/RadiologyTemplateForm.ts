import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { RadiologyTemplateFormViewModel, RadiologyProcedureInfo, RadiologyTemplateInput, RadiologyDoctorInfo, RadiologyTemplateInfo} from './RadiologyTemplateFormViewModel';

import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { SystemApiService } from 'Fw/Services/SystemApiService';

import { IModalService } from 'Fw/Services/IModalService';

@Component({
    selector: "RadiologyTemplateForm",
    templateUrl: './RadiologyTemplateForm.html',

    providers: [SystemApiService],

})
export class RadiologyTemplateForm extends BaseComponent<any> implements OnInit, IModal, OnDestroy {
    radiologyTemplateFormViewModel: RadiologyTemplateFormViewModel = new RadiologyTemplateFormViewModel();
    radiologyTemplateInput: RadiologyTemplateInput = new RadiologyTemplateInput();
    deleteButtonDisabled = true;
    newButtonDisabled = true;
    //FolderContentColumns = [{
    //    caption: 'Seç',
    //    dataField: 'IsSelected',
    //    dataType: 'boolean',
    //    fixed: true,
    //    width: '80px',
    //    allowEditing: true,
    //    cellTemplate: "ChkTemplate"
    //},
    //{ caption: 'Evrak Adı', dataField: 'ContentName', fixed: true, width: '500', allowEditing: false },
    //{ caption: 'Sayfa Sayısı', dataField: 'PageNumber', fixed: true, width: '100', allowEditing: true }

    //]
    //_episodeActionID: string = "";

    constructor(protected httpService: NeHttpService, private http: AtlasHttpService, services: ServiceContainer, protected messageService: MessageService, protected modalService: IModalService) {
        super(services);
    }

    async ngOnInit() {
        this.radiologyTemplateInput = new RadiologyTemplateInput();
        this.radiologyTemplateInput.SelectedRadiologyProcedures = new Array<RadiologyProcedureInfo>();
        this.radiologyTemplateInput.SelectedRadiologyDoctors = new Array<RadiologyDoctorInfo>();
        await this.loadRadiologyTemplateFormViewModel();

    }


    public setInputParam(value: any) {

       // this._episodeActionID = value.toString();
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    loadRadiologyTemplateFormViewModel() {
        let that = this;
        let fullApiUrl: string = "/api/RadiologyTemplateService/LoadRadiologyTemplateFormViewModel";
        this.httpService.get<RadiologyTemplateFormViewModel>(fullApiUrl)
            .then(response => {
                that.radiologyTemplateFormViewModel = response as RadiologyTemplateFormViewModel;
            })
            .catch(error => {
                console.log(error);
            });

    }

    public ngOnDestroy(): void {
    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    SaveRadiologyTemplate() {
        let that = this;
        if (this.confirmSave()) {
            let fullApiUrl: string = "/api/RadiologyTemplateService/SaveRadiologyTemplateFormViewModel";
            this.httpService.post<Array<RadiologyTemplateInfo>>(fullApiUrl, this.radiologyTemplateInput)
                .then(response => {
                    this.messageService.showSuccess("Şablon Kaydedildi.");
                    this.radiologyTemplateFormViewModel.TemplateList = response as Array<RadiologyTemplateInfo>;
                    //Kayıtlı şablonlar combosu refreshlenir
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }

    
    public onReportChanged(event): void {
 
        if (event!= null) {
            this.radiologyTemplateInput.Report = event;
        }
    }
    public onResultsChanged(event): void {
        if (event != null) {
            this.radiologyTemplateInput.Results = event;
        }
    }
    public onRadiographyTechniqueChanged(event): void {
        if (event != null) {
            this.radiologyTemplateInput.RadiographyTechnique = event;
        }
    }
    public onComparisonInfoChanged(event): void {
        if (event != null) {
            this.radiologyTemplateInput.ComparisonInfo = event;
        }
    }


    onSelectRadiologyProcedure(data) {
        let that = this;
        let flagFound: boolean = false;
        for (let item of that.radiologyTemplateInput.SelectedRadiologyProcedures) {
            if (item.ObjectID == data.value.ObjectID) {
                flagFound = true;
            }
        }
        if (!flagFound)
            that.radiologyTemplateInput.SelectedRadiologyProcedures.push(data.value);

    }
    onSelectRadiologyDoctor(data) {
        let that = this;
        let flagFound: boolean = false;
        for (let item  of that.radiologyTemplateInput.SelectedRadiologyDoctors) {
            if (item.ObjectID == data.value.ObjectID) {
                flagFound = true;
            }
        }
        if (!flagFound)
            that.radiologyTemplateInput.SelectedRadiologyDoctors.push(data.value);
    }

    DeleteRadiologyTemplate() {
        let that = this;
        let fullApiUrl: string = "/api/RadiologyTemplateService/DeleteRadiologyTemplate?TemplateObjectID=" + this.radiologyTemplateInput.ObjectID;
        this.httpService.get<RadiologyTemplateFormViewModel>(fullApiUrl)
            .then(response => {
                this.messageService.showSuccess("Şablon Silindi.");
            })
            .catch(error => {
                console.log(error);
            });
    }

    NewTemplate() {
        let that = this;
        that.radiologyTemplateInput = new RadiologyTemplateInput();
        that.radiologyTemplateInput.IsNew = true;
        that.radiologyTemplateInput.Report = "";
        that.radiologyTemplateInput.Results = "";
        that.radiologyTemplateInput.RadiographyTechnique = "";
        that.radiologyTemplateInput.ComparisonInfo = "";
        that.radiologyTemplateInput.TemplateName = "";
        that.radiologyTemplateInput.SelectedRadiologyProcedures = new Array<RadiologyProcedureInfo>();
        that.radiologyTemplateInput.SelectedRadiologyDoctors = new Array<RadiologyDoctorInfo>();
        this.deleteButtonDisabled = true;
    }

    onSelectRadiologyTemplate(data) {
        let that = this;
        let template: RadiologyTemplateInfo = data.value;


        let fullApiUrl: string = "/api/RadiologyTemplateService/LoadSelectedRadiologyTemplate?TemplateObjectID=" + template.ObjectID;
        this.httpService.get<RadiologyTemplateInput>(fullApiUrl)
            .then(response => {
                that.radiologyTemplateInput = response as RadiologyTemplateInput;
                this.deleteButtonDisabled = false;
            })
            .catch(error => {
                console.log(error);
            });


    }

    confirmSave(): boolean {
        let flag: boolean = true;
        //şablon adı işlem ve doktor zorunlu
        if (this.radiologyTemplateInput.TemplateName == "") {
            this.messageService.showError("Devam Etmek İçin Şablon Adı Giriniz.");
            flag = false;
        } else if (this.radiologyTemplateInput.SelectedRadiologyProcedures.length == 0) {
            this.messageService.showError("Devam Etmek İçin Radyoloji İşlemleri Seçiniz.");
            flag = false;
        }
        else if (this.radiologyTemplateInput.SelectedRadiologyDoctors.length == 0) {
            this.messageService.showError("Devam Etmek İçin İlişkili Doktorları Seçiniz.");
            flag = false;
        }
        return flag;
    }

}
