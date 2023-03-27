import { Component, Input, OnDestroy, OnInit } from "@angular/core";
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
@Component({
    selector: "eRaporSorgulaComponent",
    templateUrl: './ERaporSorgulaComponent.html',
})
export class ERaporSorgulaComponent {


    public GivingReasonItems;
    public selectedGivingReason;
    public enableMedulaPasswordEntrance: boolean = false;
    public ReportList: List<any> = new List<any>();
    public PatientReportsColumns = [];
    public showSelectedReportDetailPopUp = false;
    public reportDetail = "";
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    constructor(private httpService: NeHttpService,
        protected messageService: MessageService,
        private sideBarMenuService: ISidebarMenuService
    ) {
        this.PatientReportsColumns = [

            {
                'caption': "Rapor Adı",
                dataField: 'reportType',
                allowSorting: true,
                dataType: 'string'
            },
            {
                'caption': "Rapor Takip No",
                dataField: 'raporCevapDVO.raporTakipNo',
                allowSorting: true
            },
            {
                'caption': "Başlangıç Tarihi",
                dataField: 'ReportStartDate',
                allowSorting: true,
                dataType: 'date'
            },
            {
                'caption': "Bitiş Tarihi",
                dataField: 'ReportEndDate',
                allowSorting: true,
                dataType: 'date'
            },
            {
                'caption': "Tesis Bilgisi",
                dataField: 'raporTesis',
                allowSorting: true,
                dataType: 'string'
            },
            {
                'caption': "Rapor Açıklaması",
                dataField: 'reportDescription',
                allowSorting: true,
                dataType: 'string'
            },
            {
                'caption': "Seans Sayisi",
                dataField: 'seansSayisi',
                allowSorting: true,
                dataType: 'string'
            },
            {
                caption: 'Detay',
                dataField: '',
                cellTemplate: 'buttonCellTemplate',
                width: 60
            }
        ];
    }

    public async getParameterValues() {
        let enableMedulaPasswordEntrance: string = (await SystemParameterService.GetParameterValue('MEDULASIFREGIRISEKRANIAKTIF', 'FALSE'));
        if (enableMedulaPasswordEntrance === 'TRUE') {
            this.enableMedulaPasswordEntrance = true;
        }
        else {
            this.enableMedulaPasswordEntrance = false;
        }
    }

    private _episodeActionId: Guid;
    @Input() set episodeActionId(value: Guid) {
        this._episodeActionId = value;
        this.getParameterValues();
        this.createReportWithEpisodeAction();
    }
    get episodeActionId(): Guid {
        return this._episodeActionId;
    }

    private _patientId: Guid;
    @Input() set patientId(value: Guid) {
        this._patientId = value;
        this.getParameterValues();
    }
    get patientId(): Guid {
        return this._patientId;
    }

    public CreateReport() {
        this.createReportWithEpisodeAction();
    }

    select(data) {
        this.showSelectedReportDetailPopUp = true;
        this.reportDetail = data.data.reportXML;
    }



    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
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

    private async createReportWithEpisodeAction() {
        let requestClass = new ERaporSorgulaRequest();
        requestClass.actionId = this.episodeActionId;
        /*if (this.enableMedulaPasswordEntrance) {
            await this.MedulaPasswordSendPanel(requestClass);
        }*/
        let that = this;
        let apiUrl: string = '/api/EReportService/getSGKReportsOnPatient';
        this.loadPanelOperation(true, "Raporlar Sorgulanıyor, Lütfen Bekleyin");
        that.httpService.post<List<any>>(apiUrl, requestClass)
            .then(response => {

                that.ReportList = response;
                if (that.ReportList[0] == undefined) {
                    ServiceLocator.MessageService.showInfo("Hastanın Medula'da Kayıtlı Raporu Bulunamamıştır");
                }
            })
            .catch(error => {
                this.messageService.showError(error);
                this.loadPanelOperation(false, "");

            });
        this.loadPanelOperation(false, "");

    }

}
export class ERaporSorgulaRequest {
    public medulaUsername: string;
    public medulaPassword: string;
    public actionId: Guid;
}