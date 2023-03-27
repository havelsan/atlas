//$81E62309
import { Component, ViewChild, OnInit, NgZone, ApplicationRef, Input, ChangeDetectorRef, Output, EventEmitter } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { CreatingEpicrisisFormViewModel, EpicrisisGridResultModel } from './CreatingEpicrisisFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CreatingEpicrisis, EpisodeAction, Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { IModalService } from 'app/Fw/Services/IModalService';
import { CommonHelper } from 'app/Helper/CommonHelper';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { UserTemplateModel } from '../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { DxSelectBoxComponent } from 'devextreme-angular';

@Component({
    selector: 'CreatingEpicrisisForm',
    templateUrl: './CreatingEpicrisisForm.html',
    providers: [MessageService]
})
export class CreatingEpicrisisForm extends EpisodeActionForm implements OnInit {
    @ViewChild('TemplateCombo') TemplateCombo: DxSelectBoxComponent;

    labelReportNo: TTVisual.ITTLabel;
    LabelRequestDate: TTVisual.ITTLabel;
    page1: TTVisual.ITTTabPage;
    page3: TTVisual.ITTTabPage;
    page4: TTVisual.ITTTabPage;
    page5: TTVisual.ITTTabPage;
    complaint: TTVisual.ITTRichTextBoxControl;
    ReportNo: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    procedures: TTVisual.ITTRichTextBoxControl;
    autobiography: TTVisual.ITTRichTextBoxControl;
    symptom: TTVisual.ITTRichTextBoxControl;
    story: TTVisual.ITTRichTextBoxControl;
    physicalExamination: TTVisual.ITTRichTextBoxControl;
    suggestion: TTVisual.ITTRichTextBoxControl;
    tttabcontrol1: TTVisual.ITTTabControl;

    public selectionControl: boolean = false;
    public onayKontrol: boolean = false;

    public showOldEpicrisis: boolean;
    public showEpicrisisGrid: boolean = true;
    public confirmation: boolean = false;


    public creatingEpicrisisFormViewModel: CreatingEpicrisisFormViewModel = new CreatingEpicrisisFormViewModel();
    public get _CreatingEpicrisis(): CreatingEpicrisis {
        return this._TTObject as CreatingEpicrisis;
    }
    private CreatingEpicrisisForm_DocumentUrl: string = '/api/CreatingEpicrisisService/CreatingEpicrisisForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private changeDetectorRef: ChangeDetectorRef, protected ngZone: NgZone, protected modalService: IModalService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.CreatingEpicrisisForm_DocumentUrl;
        // let response = httpService.post<CreatingEpicrisisFormViewModel>(fullApiUrl,this.reportActiveIDsModel, ParticipationFreeDrugReportNewFormViewModel);
        this.initViewModel();
        this.initFormControls();
    }

    // *****Method declarations end *****

    private _actionObject: EpisodeAction;
    deleteControl: boolean;
    @Input() set ActionObject(value: EpisodeAction) {
        this._actionObject = value;
        //if (this.EpisodeAction != null && this.EpisodeAction.ObjectID != null)
        //this.loadViewModel();
    }
    get ActionObject(): EpisodeAction {
        return this._actionObject;
    }

    @Input() set EpicrisisForm(value: Guid) {
        this.ObjectID = value;
        this.showEpicrisisGrid = false;
    }


    private _reportActiveIDsModel: ActiveIDsModel;
    @Input() set ReportActiveIDsModel(value: ActiveIDsModel) {
        this._reportActiveIDsModel = value;
        this.ActiveIDsModel = value
    }
    get reportActiveIDsModel(): ActiveIDsModel {
        return this._reportActiveIDsModel;
    }

    @Output() complaintOldContextChange = new EventEmitter();
    public copyOldComponentContext(data: any, context: string) {
        if (data != null) {
            let emitObject = {
                data: data,
                properyName: context
            };
            this.complaintOldContextChange.emit(emitObject);
        }
        TTVisual.InfoBox.Alert("Kopyalandı!");
    }


    public getComplaint(event) {
        if (event.properyName == "complaint") {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.COMPLAINTANDSTORY += "<br />" + event.data;
        }
        else if (event.properyName == "story") {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.STORY += "<br />" + event.data;
        }
        else if (event.properyName == "symptom") {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.SYMPTOM += "<br />" + event.data;
        }
        else if (event.properyName == "physicalExamination") {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.PHYSICALEXAMINATION += "<br />" + event.data;
        }
        else if (event.properyName == "autobiyography") {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.AUTOBIOGRAPHY += "<br />" + event.data;
        }
        else if (event.properyName == "procedure") {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.PROCEDURE += "<br />" + event.data;
        }
        else if (event.properyName == "suggestion") {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.Suggestion += "<br />" + event.data;
        }        
    }

    @Output() SendPopupInfo: EventEmitter<boolean> = new EventEmitter<boolean>();


    public initViewModel(): void {
        this._TTObject = new CreatingEpicrisis();
        this.creatingEpicrisisFormViewModel = new CreatingEpicrisisFormViewModel();
        this._ViewModel = this.creatingEpicrisisFormViewModel;
        this.creatingEpicrisisFormViewModel._CreatingEpicrisis = this._TTObject as CreatingEpicrisis;
        this.creatingEpicrisisFormViewModel._CreatingEpicrisis.Episode = new Episode();
    }

    protected loadViewModel() {
        let that = this;
        that.creatingEpicrisisFormViewModel = this._ViewModel as CreatingEpicrisisFormViewModel;
        that._TTObject = this.creatingEpicrisisFormViewModel._CreatingEpicrisis;
        if (this.creatingEpicrisisFormViewModel == null)
            this.creatingEpicrisisFormViewModel = new CreatingEpicrisisFormViewModel();
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis == null)
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis = new CreatingEpicrisis();

        //  this.creatingEpicrisisFormViewModel._CreatingEpicrisis.MasterResource = this.creatingEpicrisisFormViewModel.Clinic;
        //  this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ProcedureDoctor = this.creatingEpicrisisFormViewModel.Doctor;

        that.GetAllReportList();

        //this.creatingEpicrisisFormViewModel._EpisodeAction = this._episodeAction;
        //this.creatingEpicrisisFormViewModel._CreatingEpicrisis.SubEpisode = this._episodeAction.SubEpisode;
        /*if(this.creatingEpicrisisFormViewModel._EpisodeAction.IsNew != undefined)
        {
            let apiUrl: string = '/api/CreatingEpicrisisService/FillEpicrisis';
            this.httpService.post<CreatingEpicrisisFormViewModel>(apiUrl, this.creatingEpicrisisFormViewModel).then(
                 result => {
                     this.creatingEpicrisisFormViewModel = result;
                 }
            );
        }*/

        /* let episodeObjectID = that.creatingEpicrisisFormViewModel._CreatingEpicrisis["Episode"];
         if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
             let episode = that.creatingEpicrisisFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                 that.creatingEpicrisisFormViewModel._CreatingEpicrisis.Episode = episode;
             }
         }*/

         if(this.creatingEpicrisisFormViewModel.DoctorAuthority == false){
             this.ChangeReadProperty(true);
         }

    }

   public ChangeReadProperty(value: boolean){
    this.procedures.ReadOnly = value;
    this.suggestion.ReadOnly = value;
    this.symptom.ReadOnly = value;
    this.physicalExamination.ReadOnly = value;
    this.autobiography.ReadOnly = value;
    this.story.ReadOnly = value;
    this.complaint.ReadOnly = value;
   }

    async ngOnInit() {
        await this.load(CreatingEpicrisisFormViewModel);
        //   await this.load(CreatingEpicrisisFormViewModel);
    }


    ngAfterViewInit() {
        let that = this;
    }


    public EpicrisisList;
    async GetAllReportList() {

        let that = this;
        let apiUrlForPASearchUrl: string;
        let input: string = this._CreatingEpicrisis.Episode.toString();
        apiUrlForPASearchUrl = '/api/CreatingEpicrisisService/GetPatientAllEpicrisisReports';

        let body = "";
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        try {
            let apiUrl: string = '/api/CreatingEpicrisisService/GetPatientAllEpicrisisReport?episodeInput=' + this._CreatingEpicrisis.Episode.toString();
            let result = await this.httpService.get<Array<EpicrisisGridResultModel>>(apiUrl);
            if (result) {
                this.EpicrisisList = result;
            }
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

    }



    public onComplaintChanged(event): void {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.COMPLAINTANDSTORY != event) {
            this._CreatingEpicrisis.COMPLAINTANDSTORY = event;
        }
    }

    public onStoryChanged(event): void {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.STORY != event) {
            this._CreatingEpicrisis.STORY = event;
        }
    }
    public onReportNoChanged(event): void {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ReportNo != event) {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ReportNo = event;
        }
    }

    public onRequestDateChanged(event): void {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.RequestDate != event) {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.RequestDate = event;
        }
    }

    public onProceduresChanged(event): void {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.PROCEDURE != event) {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.PROCEDURE = event;

        }
    }

    public onSymptomChanged(event): void {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.SYMPTOM != event) {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.SYMPTOM = event;

        }
    }

    public onAutobiographyChanged(event): void {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.AUTOBIOGRAPHY != event) {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.AUTOBIOGRAPHY = event;
        }
    }

    public onPhysicalExaminationChanged(event): void {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.PHYSICALEXAMINATION != event) {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.PHYSICALEXAMINATION = event;
        }
    }

    public onSuggestionChanged(event): void {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.Suggestion != event) {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.Suggestion = event;

        }
    }

    public onDoctorChange(event) {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ProcedureDoctor != event.selectedItem) {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ProcedureDoctor = event.selectedItem;
        }
    }

    public onSectionChange(event) {
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis != null && this.creatingEpicrisisFormViewModel._CreatingEpicrisis.MasterResource != event.selectedItem) {
            this.creatingEpicrisisFormViewModel._CreatingEpicrisis.MasterResource = event.selectedItem;
        }

        let input: string = "";
        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis.MasterResource != undefined)
            input = " AND this.ISACTIVE = 1" + " AND" + " USERRESOURCES(RESOURCE = '" + this.creatingEpicrisisFormViewModel._CreatingEpicrisis.MasterResource.ObjectID.toString() + "').EXISTS";
        this.FillDataSource(input);

    }

    public async onReportConfirmation() {

        if ((this.creatingEpicrisisFormViewModel._CreatingEpicrisis.CurrentStateDefID.valueOf() == CreatingEpicrisis.CreatingEpicrisisStates.PreApproval.id || this.creatingEpicrisisFormViewModel._CreatingEpicrisis.CurrentStateDefID.valueOf() == CreatingEpicrisis.CreatingEpicrisisStates.ReportEntry.id) && this.creatingEpicrisisFormViewModel.DoctorAuthority == true) {
            if(this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ProcedureDoctor == null)
            {
                ServiceLocator.MessageService.showError("'Doktor' alanı boş geçilemez");
                return;
            }
            else if(this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ProcedureDoctor == null)
            {
                ServiceLocator.MessageService.showError("'Birim' alanı boş geçilemez");
                return;
            }
            else{
                this.creatingEpicrisisFormViewModel.isReportConfirmByDoctor = true;
                await this.save();
                ServiceLocator.MessageService.showSuccess(i18n("M16830", "Epikriz Raporu onaylandı."));
            }


        }

        else if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis.CurrentStateDefID.valueOf() == CreatingEpicrisis.CreatingEpicrisisStates.ReportEntry.id && this.creatingEpicrisisFormViewModel.DoctorAuthority == false) {
            if(this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ProcedureDoctor == null)
            {
                ServiceLocator.MessageService.showError("'Doktor' alanı boş geçilemez");
                return;
            }
            else if(this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ProcedureDoctor == null)
            {
                ServiceLocator.MessageService.showError("'Birim' alanı boş geçilemez");
                return;
            }
            else{
                this.creatingEpicrisisFormViewModel.isReportConfirmByOthers = true;
                this.creatingEpicrisisFormViewModel.WaitConfirmation = true;
                await this.save();
                ServiceLocator.MessageService.showSuccess(i18n("M16830", "Epikriz Raporu onaya gönderildi."));
            }
        }
    }

    public async onReportRemoveConfirmation() {
        if (this.creatingEpicrisisFormViewModel.DoctorAuthority == true) {
            this.creatingEpicrisisFormViewModel.isRemoveConfirmation = true; //Onaylanip onayin tekrar kaldirildigini kontrol etmek icin
            this.creatingEpicrisisFormViewModel.isReportConfirmByDoctor = false; //Doktorun onayinin kalktigini kontrol etmek icin.
       //     this.SendPopupInfo.emit(false); //visible false olsun

            let apiUrlForPASearchUrl: string;
            apiUrlForPASearchUrl = '/api/CreatingEpicrisisService/ChangeEpicrisisState?id=' + this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ObjectID.toString();
            await this.httpService.get<any>(apiUrlForPASearchUrl).then(response => {
                let result = response;
                if (result) {
                    ServiceLocator.MessageService.showSuccess(i18n("M16830", "Rapor Onayı Kaldırıldı."));
                    this.load();
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
            
        }
    }


    public onSetPopupVisible(event : any) : void {
        this.showOldEpicrisis = event;
    }


    public DoctorList;
    async FillDataSource(input: string) {
        try {
            let that = this;
            let body = "";
            let apiUrlForPASearchUrl: string;
            let headers = new Headers({ 'Content-Type': 'application/json' });
            apiUrlForPASearchUrl = '/api/CreatingEpicrisisService/FillDoctorList?input=' + input;
            await this.httpService.get<any>(apiUrlForPASearchUrl).then(response => {
                let result = response;
                if (result) {
                    this.creatingEpicrisisFormViewModel.DoctorList = result;

                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }


    public async onPrintEpicrisisReport() {
        this.ObjectID = this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ObjectID;
        await this.load();
        let data: ClickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ObjectID, new Guid(this.creatingEpicrisisFormViewModel._CreatingEpicrisis.Episode.toString()), null));
        await this.printEpicrisisReport(this.creatingEpicrisisFormViewModel._CreatingEpicrisis, data);

    }

    public async printEpicrisisReport(data: CreatingEpicrisis, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {
        if (!data.IsNew) {

            if (data.CurrentStateDefID != CreatingEpicrisis.CreatingEpicrisisStates.Completed) {
                this.messageService.showError('Onaylanmamış Epikriz Raporunu Yazdıramazsınız.');
                return;
            }

            let reportData: DynamicReportParameters = {

                Code: 'EPIKRIZRAPORU',
                ReportParams: { EpicrisisObjectID: data.ObjectID.toString() },
                ViewerMode: true
            };

            return new Promise((resolve, reject) => {

                let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'HvlDynamicReportComponent';
                componentInfo.ModuleName = 'DevexpressReportingModule';
                componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
                componentInfo.InputParam = new DynamicComponentInputParam(reportData, activeIDsModel);

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = "EPİKRİZ RAPORU"

                modalInfo.fullScreen = true;

                let result = this.modalService.create(componentInfo, modalInfo);
                result.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        } else {
            this.messageService.showError('Hastanın Epikriz Raporu bulunmamaktadır.');
        }


    }

    public oldEpicrisisFormID;
    public async selectionChangedHandlerOnReport(event) {
        try {
            this.oldEpicrisisFormID = event.data.ObjectID;
            this.showOldEpicrisis = true;
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

        this.changeDetectorRef.detectChanges();
    }

    public popUpClosed(e: any) {
        this.showOldEpicrisis = false;
        this.showEpicrisisGrid = true;
    }


    public async openNewEpicrisis() {

        this.selectionControl = true;
        await this.LoadEmptyForm();
    }

    async LoadEmptyForm() {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";
            fullApiUrl = '/api/CreatingEpicrisisService/CreatingEpicrisisFormLoad';
            let formLoadInput = { Id: Guid.Empty, Model: this.ActiveIDsModel };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.post<CreatingEpicrisisFormViewModel>(fullApiUrl, formLoadInput, CreatingEpicrisisFormViewModel);

            this._ViewModel = response;

            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    public selectedUserTemplate;
    public userTemplateName;
    async btnAddUserTemplate_Click(): Promise<void> {
        try {
            if (this.userTemplateName != null || (this.userTemplateName != null && !this.userTemplateName.toString().isNullOrEmpty())) {
                let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

                savedUserTemplate.Description = this.userTemplateName;
                savedUserTemplate.TAObjectDefID = this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ObjectDefID;
                savedUserTemplate.TAObjectID = this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ObjectID;

                let apiUrl: string = 'api/CreatingEpicrisisService/SaveEpicrisisReportUserTemplate';
                await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                    this.creatingEpicrisisFormViewModel.userTemplateList = result;
                    this.creatingEpicrisisFormViewModel.selectedUserTemplate = null;
                    this.userTemplateName = "";
                    ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Oluşturuldu");
                });
            } else {
                ServiceLocator.MessageService.showError("Şablon ismi girmeden yeni şablon oluşturamazsınız");
            }


        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    
    async SelectUserTemplate(event: any): Promise<void> {
        if (event.itemData != null) {

            if (this.creatingEpicrisisFormViewModel.selectedUserTemplate == null || (this.creatingEpicrisisFormViewModel.selectedUserTemplate.ObjectID != event.itemData.ObjectID)) {
                this.creatingEpicrisisFormViewModel.selectedUserTemplate = event.itemData;
                const that = this;
                this.loadPanelOperation(true, 'Şablon Yükleniyor, Lütfen Bekleyiniz');
                that.loadReportByTemplate();
                this.loadPanelOperation(false, 'Şablon Yükleniyor, Lütfen Bekleyiniz');
                //this.onProcedureDoctorChanged(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ProcedureDoctor);
            }
        }

    }

    async btnDeleteSelectedUserTemplate_Click(): Promise<void> {
        try {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili Şablon Sistemden Silinecektir. Devam Etmek İstiyor Musunuz? "), 1);
            if (result === "H")
                return;
            let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

            savedUserTemplate.ObjectID = this.creatingEpicrisisFormViewModel.selectedUserTemplate.ObjectID;
            savedUserTemplate.TAObjectDefID = this.creatingEpicrisisFormViewModel._CreatingEpicrisis.ObjectDefID;
            let apiUrl: string = 'api/CreatingEpicrisisService/SaveEpicrisisReportUserTemplate';
            this.loadPanelOperation(true, 'Şablon Siliniyor, Lütfen Bekleyiniz');
            await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                this.creatingEpicrisisFormViewModel.userTemplateList = result;
                this.creatingEpicrisisFormViewModel.selectedUserTemplate = null;
                this.userTemplateName = "";
                ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Silindi");
            });
            this.loadPanelOperation(false, '');

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    async btnClearUserTemplate_Click(): Promise<void> {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Şablon Temizlenerek Boş bir Form Açılacaktır. Devam Etmek İstiyor Musunuz? "), 1);
        if (result === "H")
            return;
        this.loadPanelOperation(true, 'Form Açılıyor, Lütfen Bekleyiniz');

        if (this.creatingEpicrisisFormViewModel._CreatingEpicrisis.IsNew) {
            this.LoadEmptyForm();
        } else {
            this.loadReportByID(this._CreatingEpicrisis.ObjectID);
        }
        this.loadPanelOperation(false, '');

        this.TemplateCombo.value = null;
        this.selectedUserTemplate = null;
        this.creatingEpicrisisFormViewModel.selectedUserTemplate = null;
    }

    private EpicrisisReportNewFormPre_DocumentUrl: string = '/api/CreatingEpicrisisService/EpicrisisReportFormPre';
    protected async loadReportByID(objectID: Guid) {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";

            if (objectID != null) {
                fullApiUrl = this.EpicrisisReportNewFormPre_DocumentUrl + '/?id=' + objectID;
            }
            else {
                fullApiUrl = `${this.EpicrisisReportNewFormPre_DocumentUrl}/${Guid.Empty}`;
            }

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<CreatingEpicrisisFormViewModel>(fullApiUrl, CreatingEpicrisisFormViewModel);
            this._ViewModel = response;


            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
            if (this.TemplateCombo != null)
                this.TemplateCombo.value = null;
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    protected async loadReportByTemplate() {
        try {


            let fullApiUrl: string = "";


            fullApiUrl = "/api/CreatingEpicrisisService/EpicrisisReportFormTemplate";

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.post<CreatingEpicrisisFormViewModel>(fullApiUrl, this.creatingEpicrisisFormViewModel, CreatingEpicrisisFormViewModel);
            this.initViewModel();
            this.initFormControls();
            //this.selectedUserTemplate = null;
            this._ViewModel = response;


            this.loadViewModel();

            await this.ClientSidePreScript();
            await this.PreScript();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.ReportNo, "Text", this.__ttObject, "ReportNo");
        redirectProperty(this.complaint, "Rtf", this.__ttObject, "COMPLAINT");
        redirectProperty(this.story, "Rtf", this.__ttObject, "STORY");
        redirectProperty(this.symptom, "Rtf", this.__ttObject, "SYMPTOM");
        redirectProperty(this.autobiography, "Rtf", this.__ttObject, "AUTOBIOGRAPHY");
        redirectProperty(this.physicalExamination, "Rtf", this.__ttObject, "PHYSICALEXAMINATION");
        redirectProperty(this.suggestion, "Rtf", this.__ttObject, "Suggestion");
        redirectProperty(this.procedures, "Rtf", this.__ttObject, "PROCEDURE");
    }

    public initFormControls(): void {

        this.complaint = new TTVisual.TTRichTextBoxControl();
        this.complaint.DisplayText = "Şikayeti";
        this.complaint.TemplateGroupName = "Epikiriz Yakınmalar ve Öykü";
        this.complaint.BackColor = "#FFFFFF";
        this.complaint.Name = "complaint";
        this.complaint.TabIndex = 38;

        this.story = new TTVisual.TTRichTextBoxControl();
        this.story.DisplayText = "Hikayesi";
        this.story.TemplateGroupName = "Epikiriz Yakınmalar ve Öykü";
        this.story.BackColor = "#FFFFFF";
        this.story.Name = "story";
        this.story.TabIndex = 38;

        this.autobiography = new TTVisual.TTRichTextBoxControl();
        this.autobiography.DisplayText = "Öz Geçmiş";
        this.autobiography.TemplateGroupName = "Epikiriz Öz Geçmiş";
        this.autobiography.BackColor = "#FFFFFF";
        this.autobiography.Name = "autobiography";
        this.autobiography.TabIndex = 38;

        this.physicalExamination = new TTVisual.TTRichTextBoxControl();
        this.physicalExamination.DisplayText = "Fizik Muayene";
        this.physicalExamination.TemplateGroupName = "Epikiriz Fizik Muayene";
        this.physicalExamination.BackColor = "#FFFFFF";
        this.physicalExamination.Name = "physicalExamination";
        this.physicalExamination.TabIndex = 38;

        this.symptom = new TTVisual.TTRichTextBoxControl();
        this.symptom.DisplayText = "Bulguları";
        this.symptom.TemplateGroupName = "Epikiriz Fizik Muayene";
        this.symptom.BackColor = "#FFFFFF";
        this.symptom.Name = "symptom";
        this.symptom.TabIndex = 38;


        this.suggestion = new TTVisual.TTRichTextBoxControl();
        this.suggestion.DisplayText = "Öneriler";
        this.suggestion.TemplateGroupName = "Epikiriz Öneriler";
        this.suggestion.BackColor = "#FFFFFF";
        this.suggestion.Name = "suggestion";
        this.suggestion.TabIndex = 38;

        this.procedures = new TTVisual.TTRichTextBoxControl();
        this.procedures.DisplayText = "İşlemler";
        this.procedures.TemplateGroupName = "Epikiriz İşlemler";
        this.procedures.BackColor = "#FFFFFF";
        this.procedures.Name = "procedures";
        this.procedures.TabIndex = 38;

        this.ReportNo = new TTVisual.TTTextBox();
        this.ReportNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReportNo.Name = "ReportNo";
        this.ReportNo.TabIndex = 0;

        this.LabelRequestDate = new TTVisual.TTLabel();
        this.LabelRequestDate.Text = "İstek Tarihi";
        this.LabelRequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelRequestDate.ForeColor = "#000000";
        this.LabelRequestDate.Name = "LabelRequestDate";
        this.LabelRequestDate.TabIndex = 36;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 1;


        this.Controls = [this.tttabcontrol1, this.complaint, this.symptom, this.story, this.autobiography, this.physicalExamination, this.suggestion, this.page5, this.procedures, this.ReportNo, this.LabelRequestDate, this.RequestDate, this.labelReportNo];

    }


}
