//$6AB10E95
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { HemodialysisProcedureFormViewModel, HemodialysisOrderDetailInfo } from './HemodialysisProcedureFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { HemodialysisRequest, HemodialysisStateEnum } from 'NebulaClient/Model/AtlasClientModel';

import { DynamicComponentInfo } from '../../../wwwroot/app/Fw/Models/DynamicComponentInfo';
import { SystemApiService } from '../../../wwwroot/app/Fw/Services/SystemApiService';
import { HemodialysisWorkListItem } from '../Tibbi_Surec_Is_Listeleri/Hemodiyaliz_Is_Listesi/HemodialysisWorkListViewModel';
import { ModalActionResult, ModalInfo } from '../../../wwwroot/app/Fw/Models/ModalInfo';
import { DynamicReportParameters } from '../../../wwwroot/app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { IModalService } from '../../../wwwroot/app/Fw/Services/IModalService';

import { DynamicSidebarMenuItem } from '../../../wwwroot/app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { EpisodeActionForm } from '../Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm';
import { ISidebarMenuService } from '../../../wwwroot/app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from '../../../wwwroot/app/Fw/Services/HelpMenuService';
import { ShowBoxTypeEnum } from '../../../wwwroot/app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'HemodialysisProcedureForm',
    templateUrl: './HemodialysisProcedureForm.html',
    providers: [MessageService]
})
export class HemodialysisProcedureForm extends EpisodeActionForm implements OnInit {
    public hemodialysisProcedureFormViewModel: HemodialysisProcedureFormViewModel = new HemodialysisProcedureFormViewModel();
    public get _HemodialysisRequest(): HemodialysisRequest {
        return this._TTObject as HemodialysisRequest;
    }
    private HemodialysisProcedureForm_DocumentUrl: string = '/api/HemodialysisRequestService/HemodialysisProcedureForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone,
        private sideBarMenuService: ISidebarMenuService, protected modalService: IModalService, public systemApiService: SystemApiService,
        protected helpMenuService: HelpMenuService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.HemodialysisProcedureForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public selectedRowKeysResultList: Array<HemodialysisOrderDetailInfo> = [];

    async select(value: any): Promise<void> {

        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            this.loadPanelOperation(true, 'İşlem Açılıyor, lütfen bekleyiniz.');

            console.log();
            let _data: HemodialysisOrderDetailInfo = value.data as HemodialysisOrderDetailInfo;

            this.openDynamicComponent(value.data.OrderDetailObjectDef, _data.OrderDetailObjectID, null, null);
        }

    }

    public onDetailGridRowPrepared(value: any) {

        let _data: HemodialysisOrderDetailInfo = value.data as HemodialysisOrderDetailInfo;
        if (_data != null && _data.HemodialysisState == HemodialysisStateEnum._Complated.description) {
            value.rowElement.firstItem().style.backgroundColor = '#BAE8BA'; //'#8AD38A';//'#5cb85c';83c983
        }

        if (_data != null && _data.HemodialysisState == HemodialysisStateEnum._Aborted.description) {
            value.rowElement.firstItem().style.backgroundColor = '#FFE992'; //'#F9D543';//'#F1C40F';
        }
    }

    public OrderDetailComponentInfo: DynamicComponentInfo = new DynamicComponentInfo();
    isDynamicComponentOpened: boolean = false;
    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        this.isDynamicComponentOpened = false;

        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        if (objectID != null) {
            compInfo.objectID = objectID;
        } else {
            compInfo.objectID = null;
        }
        compInfo.ComponentName = 'HemodialysisOrderDetailForm';
        compInfo.ModuleName = 'HemodiyalizModule';
        compInfo.ModulePath = 'Modules/Tibbi_Surec/Hemodiyaliz_Modulu/HemodiyalizModule';
        compInfo.CloseWithStateTransition = true;
        compInfo.DestroyComponentOnSave = true;
        compInfo.RefreshComponent = true;

        this.OrderDetailComponentInfo = compInfo;

        this.loadPanelOperation(false, '');
        this.isDynamicComponentOpened = true;
    }

    showAnamnesisInfo: boolean = false;
    public anamnesisInfoButtonClicked() {
        this.showAnamnesisInfo = true;
    }
    public onAnemnesisPopUpDisposing() {
        this.showAnamnesisInfo = false;
    }

    //#region Load Panel işlemleri
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }
    //#endregion


    //#region rapor

    public ShowHemodialysisReport(): Promise<ModalActionResult> {

        let reportData: DynamicReportParameters = {

            Code: 'HEMODIYALIZISLEMRAPOR',
            ReportParams: { RequestObjectID: this._HemodialysisRequest.ObjectID },
            ViewerMode: true,
            DisablePrintButtons: false
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Hemodiyaliz"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //#endregion

    //#region İşlem iptal etme
    public showCancelOrderDetails: boolean = false;
    public openCancelOrderDetailsPopup() {
        if (this.selectedRowKeysResultList.length == 0) {
            this.messageService.showError("İşlem seçmediniz!");
        } else {
            this.showCancelOrderDetails = true;
        }
    }
    public approveAllOrderDetails() {
        if (this.hemodialysisProcedureFormViewModel.cancelAllOrderDetails == true) {//Tüm işlemler iptal edilecek

        } else {//sadece seçili işlemler iptal edilecek
            let that = this;
            that.httpService.post<any>("api/HemodialysisRequestService/CancelSelectedProcedures", this.selectedRowKeysResultList)
                .then(response => {
                    //this.refreshDynamicComponent(response);

                    this.messageService.showSuccess("Seçilen İşlemler Başarılı Bir Şekilde Durduruldu");
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }

        this.showCancelOrderDetails = false;
    }
    public rejectAllOrderDetails() {

        this.showCancelOrderDetails = false;
    }
    //#endregion İşlem iptal etme

    //#region Diyaliz Tedavisine İhtiyaç Kalmadı
    public async closeHemodialysisRequest() {
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "", "Hastanın diyaliz tedavisi sonlandırılacaktır. Aktif seansları, planlamaları iptal edilecektir! \r\n\r\n Devam etmek istiyor musunuz?");
        if (messageResult === "E") {
            let that = this;
            that.httpService.get<any>("api/HemodialysisRequestService/CloseHemodialysisRequest?ObjectID=" + this.hemodialysisProcedureFormViewModel._HemodialysisRequest.ObjectID + "&ObjectDefID=" + this.hemodialysisProcedureFormViewModel._HemodialysisRequest.ObjectDefID)
                .then(response => {
                    //this.refreshDynamicComponent(response);

                    this.messageService.showSuccess("Hemodiyaliz Tedavisi Başarılı Bir Şekilde Tamamlandı.");
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }
    //#endregion Diyaliz Tedavisine İhtiyaç Kalmadı

    //#region Yardımcı işlemler
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let openHemodialysis = new DynamicSidebarMenuItem();
        openHemodialysis.key = 'openHemodialysisInstruction';
        openHemodialysis.icon = 'fa fa-list';
        openHemodialysis.label = "Eğitim Bilgileri";
        openHemodialysis.componentInstance = this.helpMenuService;
        openHemodialysis.clickFunction = this.helpMenuService.openHemodialysisInstruction;
        openHemodialysis.parameterFunctionInstance = this;
        openHemodialysis.getParamsFunction = this.getClickFunctionParams;
        openHemodialysis.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', openHemodialysis);
    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('openHemodialysisInstruction');
    }
    //#endregion Yardımcı işlemler
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HemodialysisRequest();
        this.hemodialysisProcedureFormViewModel = new HemodialysisProcedureFormViewModel();
        this._ViewModel = this.hemodialysisProcedureFormViewModel;
        this.hemodialysisProcedureFormViewModel._HemodialysisRequest = this._TTObject as HemodialysisRequest;
    }

    protected loadViewModel() {
        let that = this;
        that.hemodialysisProcedureFormViewModel = this._ViewModel as HemodialysisProcedureFormViewModel;
        that._TTObject = this.hemodialysisProcedureFormViewModel._HemodialysisRequest;
        if (this.hemodialysisProcedureFormViewModel == null)
            this.hemodialysisProcedureFormViewModel = new HemodialysisProcedureFormViewModel();
        if (this.hemodialysisProcedureFormViewModel._HemodialysisRequest == null)
            this.hemodialysisProcedureFormViewModel._HemodialysisRequest = new HemodialysisRequest();

    }

    async ngOnInit() {
        await this.load();
        this.AddHelpMenu();
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
