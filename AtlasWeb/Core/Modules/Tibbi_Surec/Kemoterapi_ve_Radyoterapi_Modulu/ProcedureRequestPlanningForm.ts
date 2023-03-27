import { Component, Input, OnDestroy, OnInit, Output, EventEmitter, ViewChild } from "@angular/core";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "app/Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import { DynamicSidebarMenuItem } from "app/SidebarMenu/Models/DynamicSidebarMenuItem";
import { ISidebarMenuService } from "app/Fw/Services/ISidebarMenuService";
import { SystemParameterService } from "app/NebulaClient/Services/ObjectService/SystemParameterService";
import { UsernamePwdInput, UsernamePwdBox } from "app/NebulaClient/Visual/UsernamePwdBox";
import { DialogResult } from "app/NebulaClient/Utils/Enums/DialogResult";
import { ModalActionResult } from "app/Fw/Models/ModalInfo";
import { UsernamePwdFormViewModel } from "app/Fw/Components/UsernamePwdFormComponent";
import List from "app/NebulaClient/System/Collections/List";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { PlannedProcedureRequest, ResUser, ProcedureRequestFormDetailDefinition, ProcedureDefinition } from "app/NebulaClient/Model/AtlasClientModel";
import { UserTemplateModel } from "../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { DxDataGridComponent, DxSelectBoxComponent } from "devextreme-angular";
import { MessageIconEnum } from "app/NebulaClient/Utils/Enums/MessageIconEnum";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ShowBoxTypeEnum } from "app/NebulaClient/Utils/Enums/ShowBoxTypeEnum";

@Component({
    selector: "ProcedureRequestPlanningForm",
    templateUrl: './ProcedureRequestPlanningForm.html',
})
export class ProcedureRequestPlanningForm {
    public selectedUserTemplate;
    public selectedFormUnit;
    public selectedFormCategory;
    public GivingReasonItems;
    public selectedGivingReason;
    public enableMedulaPasswordEntrance: boolean = false;
    public ReportList: List<any> = new List<any>();
    public PatientReportsColumns = [];
    public showSelectedReportDetailPopUp = false;
    public reportDetail = "";
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public showOldPlannedProceduresDetail: boolean = false;
    public userTemplateName: string = "";
    public lastSelectedOldPlannedRequest: OldPlannedRequest = new OldPlannedRequest();
    public PlanningTypes = [
        {
            id: "0",
            name: "Kür Tamamlandığında"
        },
        {
            id: "1",
            name: "Tedavi Tamamlandığında"
        }
    ];
    public SelectedFormDetailGridColumns =
        [
            {
                caption: 'Sut Kodu',
                dataField: 'ProcedureDefinition.Code',
                width: "auto",
                allowEditing: false

            },
            {
                caption: 'İstem',
                dataField: 'ProcedureDefinition.Name',
                width: "auto",
                allowEditing: false
            }, {
                caption: i18n("M27286", "Sil"),
                name: 'RowDelete',
                width: '50',
                cellTemplate: 'deleteCellTemplate'
            }
        ];

    public OldPlannedRequestColumns =
        [
            {
                caption: 'Planlayan',
                dataField: 'PlannedBy',
                width: "auto",
                allowEditing: false

            },
            {
                caption: 'Planlama Tarihi',
                dataField: 'PlannedDate',
                dataType: 'date',
                format: 'dd.MM.yyyy HH:mm',
                width: "auto",
                allowEditing: false
            },
            {
                caption: 'Planlanan Tarih',
                dataField: 'WhenWillApply',
                width: "auto",
                allowEditing: false
            },
            {
                caption: 'Durumu',
                dataField: 'IsApplied',
                width: "auto",
                allowEditing: false
            },
            {
                caption: "Hizmetler",
                name: 'RowInfo',
                width: '50',
                cellTemplate: 'InfoCellTemplate'
            }
        ];

    public PlannedDetailDefinitionColumns =
        [
            {
                caption: 'Planlanan Tetkik',
                dataField: 'ProcedureDefinition.Name',
                width: "auto",
                allowEditing: false

            }
        ];
    public viewModel: ProcedureRequestPlanningFormViewModel = new ProcedureRequestPlanningFormViewModel();
    constructor(private httpService: NeHttpService,
        protected messageService: MessageService,
        private sideBarMenuService: ISidebarMenuService
    ) {
    }
    @Output() ProcessCompleted: EventEmitter<boolean> = new EventEmitter<boolean>();


    private _episodeActionId: Guid;
    @Input() set episodeActionId(value: Guid) {
        this._episodeActionId = value;
        this.getViewModel();
    }
    get episodeActionId(): Guid {
        return this._episodeActionId;
    }

    private _patientId: Guid;
    @Input() set patientId(value: Guid) {
        this._patientId = value;
    }
    get patientId(): Guid {
        return this._patientId;
    }

    public CreateReport() {
        this.getViewModel();
    }

    select(data) {
        this.showSelectedReportDetailPopUp = true;
        this.reportDetail = data.data.reportXML;
    }

    public onPlanningTypeChanged(event): void {
        if (event.value != null) {
            if (event.value.id == "0") {
                this.viewModel.PlannedProcedureRequest.IsOnCureCount = true;
                this.viewModel.PlannedProcedureRequest.IsOnTreatmentComplete = false;
            } else if (event.value.id == "1") {
                this.viewModel.PlannedProcedureRequest.IsOnCureCount = false;
                this.viewModel.PlannedProcedureRequest.IsOnTreatmentComplete = true;
            }

        }
    }

    async SelectUserTemplate(event: any): Promise<void> {
        if (event.itemData != null) {
            debugger;
            if (this.selectedUserTemplate == null || (this.selectedUserTemplate.ObjectID != event.itemData.ObjectID)) {
                this.selectedUserTemplate = event.itemData;
                const that = this;
                this.loadPanelOperation(true, 'Şablon Yükleniyor, Lütfen Bekleyiniz');
                that.getViewModel(that.selectedUserTemplate.ObjectID.toString());
                this.loadPanelOperation(false, 'Şablon Yükleniyor, Lütfen Bekleyiniz');
                //this.onProcedureDoctorChanged(this._ParticipatnFreeDrugReport.ProcedureDoctor);
            }
        }
    }
    @ViewChild('TemplateCombo') TemplateCombo: DxSelectBoxComponent;

    async btnClearUserTemplate_Click(): Promise<void> {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Şablon Temizlenerek Boş bir Form Açılacaktır. Devam Etmek İstiyor Musunuz? "), 1);
        if (result === "H")
            return;
        this.loadPanelOperation(true, 'Form Açılıyor, Lütfen Bekleyiniz');
        this.getViewModel();
        this.loadPanelOperation(false, '');

        this.TemplateCombo.value = null;
        this.selectedUserTemplate = null;
    }

    async btnDeleteSelectedUserTemplate_Click(): Promise<void> {
        try {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili Şablon Sistemden Silinecektir!! Devam Etmek İstiyor Musunuz ? "), 1);
            if (result === "H")
                return;
            let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

            savedUserTemplate.ObjectID = this.selectedUserTemplate.ObjectID;
            savedUserTemplate.TAObjectDefID = this.viewModel.PlannedProcedureRequest.ObjectDefID;
            let apiUrl: string = 'api/ProcedureRequestPlanningFormService/SavePlannedProcedureRequestUserTemplate';
            this.loadPanelOperation(true, 'Şablon Siliniyor, Lütfen Bekleyiniz');
            await this.httpService.post<List<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                this.viewModel.userTemplateList = result;
                this.selectedUserTemplate = null;
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

    async btnAddUserTemplate_Click(): Promise<void> {
        try {
            if (!String.isNullOrEmpty(this.userTemplateName)) {
                let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

                savedUserTemplate.Description = this.userTemplateName;
                savedUserTemplate.TAObjectDefID = this.viewModel.PlannedProcedureRequest.ObjectDefID;
                savedUserTemplate.TAObjectID = this.lastSelectedOldPlannedRequest.ObjectId;

                let apiUrl: string = 'api/ProcedureRequestPlanningFormService/SavePlannedProcedureRequestUserTemplate';
                this.loadPanelOperation(true, 'Şablon Kaydediliyor, Lütfen Bekleyiniz');
                await this.httpService.post<List<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                    this.viewModel.userTemplateList = result;
                    this.userTemplateName = "";
                    ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Oluşturuldu");
                });
                this.loadPanelOperation(false, '');
            } else {
                ServiceLocator.MessageService.showError("Şablon ismi girmeden yeni şablon oluşturamazsınız");
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    async ngOnInit() {
        this.viewModel = new ProcedureRequestPlanningFormViewModel();
        this.viewModel.PlannedProcedureRequest = new PlannedProcedureRequest();
        this.viewModel.FormUnitList = new List<ProcedureFormUnit>();
    }

    public async MedulaPasswordSendPanel(request: ERaporSorgulaRequest): Promise<void> {
        let userNamePwdInput = new UsernamePwdInput();
        userNamePwdInput.GetMkysUsernameOnInit = false;
        userNamePwdInput.SessionStoragePwdName = 'MedulaPwd';
        userNamePwdInput.SessionStorageUsername = 'MedulaUsername';
        userNamePwdInput.Title = 'E-Rapor Kaydet';
        userNamePwdInput.GetUserUniqueRefNoOnInit = true;
        userNamePwdInput.doNotOpenSavedScreen = true;
        let userNamePwdResult = await UsernamePwdBox.Show(false, userNamePwdInput);
        if ((<ModalActionResult>userNamePwdResult).Result === DialogResult.OK) {
            let params = <UsernamePwdFormViewModel>(<ModalActionResult>userNamePwdResult).Param;
            request.medulaUsername = params.userName;
            request.medulaPassword = params.password;
        }
    }

    private async getViewModel(templateId: string = null) {
        let requestClass = new ERaporSorgulaRequest();
        requestClass.actionId = this.episodeActionId;
        /*if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel(requestClass);
        }*/
        let apiUrl: string = "";
        let that = this;
        if (String.isNullOrEmpty(templateId))
            apiUrl = '/api/ProcedureRequestPlanningFormService/getViewModel?episodeActionId=' + that.episodeActionId.toString();
        else
            apiUrl = '/api/ProcedureRequestPlanningFormService/getViewModel?episodeActionId=' + that.episodeActionId.toString() + "&templateId=" + templateId;

        this.loadPanelOperation(true, "Raporlar Sorgulanıyor, Lütfen Bekleyin");
        that.httpService.get<ProcedureRequestPlanningFormViewModel>(apiUrl)
            .then(response => {
                that.viewModel = response;
                that.loadViewModel();
            })
            .catch(error => {
                this.messageService.showError(error);
                this.loadPanelOperation(false, "");

            });
        this.loadPanelOperation(false, "");

    }

    loadViewModel(){
        let that = this;
        that.viewModel.FormUnitList.forEach(formUnit => {
            formUnit.FormCategories.forEach(formCategory => {
                formCategory.FormDetailDefinitionList.forEach(formDefinition => {
                    let procedureDefinition = formDefinition["ProcedureDefinition"];
                    if (procedureDefinition != null && (typeof procedureDefinition === 'string')) {
                        let ProcedureObject = that.viewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureDefinition.toString());
                        if (ProcedureObject) {
                            formDefinition.ProcedureDefinition = ProcedureObject;
                        }
                    }
                });
            });
        });
        that.viewModel.OldPlannedRequests.forEach(oldRequest => {
            oldRequest.FormDetailDefinitionList.forEach(formDetailDef => {
                let procedureDefinition = formDetailDef["ProcedureDefinition"];
                if (procedureDefinition != null && (typeof procedureDefinition === 'string')) {
                    let ProcedureObject = that.viewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureDefinition.toString());
                    if (ProcedureObject) {
                        formDetailDef.ProcedureDefinition = ProcedureObject;
                    }
                }
            })
        });
        that.viewModel.FormDetailDefinitions.forEach(formDetailDef => {
            let procedureDefinition = formDetailDef["ProcedureDefinition"];
            if (procedureDefinition != null && (typeof procedureDefinition === 'string')) {
                let ProcedureObject = that.viewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureDefinition.toString());
                if (ProcedureObject) {
                    formDetailDef.ProcedureDefinition = ProcedureObject;
                }
            }
        })
    }



    onUnitSelected(e: any): void {
        if (e.itemData != null) {
            this.selectedFormUnit = e.itemData;
        }
    }

    onCategorySelected(e: any): void {
        if (e.itemData != null) {
            this.selectedFormCategory = e.itemData;
        }
    }

    onDetailSelected(e: any): void {
        let isItemWillAdd = true;
        if (e.itemData != null) {
            this.viewModel.FormDetailDefinitions.forEach(item => {
                if (e.itemData.ObjectID.toString() == item.ObjectID.toString()) {
                    isItemWillAdd = false;
                    ServiceLocator.MessageService.showError("Seçilen İstem Daha Önceden Eklenmiştir");
                    return;
                }
            });
            if (isItemWillAdd)
                this.viewModel.FormDetailDefinitions.unshift(e.itemData);
        }
    }

    @ViewChild('selectedProcedureDetailGrid') selectedProcedureDetailGrid: DxDataGridComponent;
    selectedProcedureDetailGrid_CellContentClick(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    this.selectedProcedureDetailGrid.instance.deleteRow(data.rowIndex);
                }
            }
        }
    }

    selectedOldPlanGrid_CellContentClick(data: any) {
        if (data.column.name == "RowInfo") {
            if (data.row != null) {
                if (data.row.key != null) {
                    this.lastSelectedOldPlannedRequest = data.data;
                    this.showOldPlannedProceduresDetail = true;
                }
            }
        }
    }

    saveRequestPlanningForm() {
        let that = this;
        if (that.viewModel.PlannedProcedureRequest.IsOnCureCount == true && (that.viewModel.PlannedProcedureRequest.WhichCure == null || that.viewModel.PlannedProcedureRequest.WhichCure < 1)) {
            ServiceLocator.MessageService.showError("Hangi kür için işlemin oluşturulduğu belirlenmelidir!");
            return;
        }
        if (that.viewModel.FormDetailDefinitions.length < 1) {
            ServiceLocator.MessageService.showError("İstem planlamak için en az bir istem seçilmiş olmalıdır!");
            return;
        }
        that.loadPanelOperation(true, "Raporlar Sorgulanıyor, Lütfen Bekleyin");
        let apiUrl: string = '/api/ProcedureRequestPlanningFormService/savePlanningForm';
        that.httpService.post<boolean>(apiUrl, that.viewModel)
            .then(response => {
                if (response == true) {
                    ServiceLocator.MessageService.showSuccess("Planlama başarıyla oluşturuldu");
                    this.loadPanelOperation(false, "");
                    that.ProcessCompleted.emit(true);
                }
            })
            .catch(error => {
                this.messageService.showError(error);
                this.loadPanelOperation(false, "");

            });


        that.loadPanelOperation(false, "");

    }

}
export class ERaporSorgulaRequest {
    public medulaUsername: string;
    public medulaPassword: string;
    public actionId: Guid;
}

export class ProcedureRequestPlanningFormViewModel {
    @Type(() => PlannedProcedureRequest)
    public PlannedProcedureRequest: PlannedProcedureRequest;
    @Type(() => ResUser)
    public PlannedUser: ResUser;
    @Type(() => UserTemplateModel)
    public userTemplateList: List<UserTemplateModel>;
    @Type(() => ProcedureRequestFormDetailDefinition)
    public FormDetailDefinitions: Array<ProcedureRequestFormDetailDefinition> = new Array<ProcedureRequestFormDetailDefinition>();
    @Type(() => ProcedureFormUnit)
    public FormUnitList: List<ProcedureFormUnit>;
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition>;
    @Type(() => OldPlannedRequest)
    public OldPlannedRequests: List<OldPlannedRequest> = new List<OldPlannedRequest>();

}

export class ProcedureFormUnit {
    @Type(() => Guid)
    public ObjectID: Guid;
    public UnitName: string;
    @Type(() => ProcedureFormCategory)
    public FormCategories: List<ProcedureFormCategory>;
}

export class ProcedureFormCategory {
    @Type(() => Guid)
    public ObjectID: Guid;
    public CategoryName: string;
    @Type(() => ProcedureRequestFormDetailDefinition)
    public FormDetailDefinitionList: List<ProcedureRequestFormDetailDefinition>;
}

export class OldPlannedRequest {
    @Type(() => Guid)
    public ObjectId: Guid;
    public PlannedBy: string;
    public PlannedDate: Date;
    public WhenWillApply: string;
    public IsApplied: string;
    @Type(() => ProcedureRequestFormDetailDefinition)
    public FormDetailDefinitionList: List<ProcedureRequestFormDetailDefinition> = new List<ProcedureRequestFormDetailDefinition>();
    public HasTemplate: boolean;
}
