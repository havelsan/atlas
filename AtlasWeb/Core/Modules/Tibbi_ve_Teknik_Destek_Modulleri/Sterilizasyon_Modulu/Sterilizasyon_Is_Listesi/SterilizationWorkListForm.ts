//$0D23E1A1
import { Component, ViewChild, Renderer2 } from '@angular/core';
import { SterilizationWorkListViewModel, SterilizationWorkListItemModel, SterilizationWorkListSearchCriteria, StateDef, SterilizationFilterList } from './SterilizationWorkListViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CommonService } from "ObjectClassService/CommonService";
import { SterilizationPackageMethodEnum, IndicatorSelectionEnum, SterilizationEnum, SterilizationHistory } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionWorkListStateItem, StateOutputDVO } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { DxDataGridComponent, DxAccordionComponent } from "devextreme-angular";
import { IActiveEpisodeActionService } from 'Fw/Services/IActiveEpisodeActionService';

@Component({
    selector: 'sterilizasyon-workList-form',
    templateUrl: './SterilizationWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class SterilizationWorkListForm extends BaseComponent<SterilizationWorkListViewModel> {

    public sterilizationWorkListViewModel: SterilizationWorkListViewModel = new SterilizationWorkListViewModel();
    public selectedRowKeysResultList: Array<SterilizationWorkListItemModel> = [];
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public SterilizationWorkListStateItems: Array<StateDef>;
    public PatientTypeList = [];
    public sterilizationWorkListStateItem = [];
    public WorkListColumns = [];
    public NextStateText = ""; //sonraki state bilgisi

    ProcedureDoctor: TTVisual.ITTObjectListBox;

    @ViewChild('ortezProtezWorkListGrid') ortezProtezWorkListGrid: DxDataGridComponent;
    @ViewChild('searchAccordion') searchAccordion: DxAccordionComponent;

    btnListele: TTVisual.ITTButton;
    isComponentOpened: boolean = false;



    constructor(protected httpService: NeHttpService, protected messageService: MessageService, container: ServiceContainer, public systemApiService: SystemApiService, private activeEpisodeActionService: IActiveEpisodeActionService, private renderer: Renderer2) {
        super(container);
        this.initFormControls();

        this.getEnumDataSources();
        this.getModelInfo();

        this.PatientTypeList = [
            {
                TypeName: 'Tümü',
                TypeID: -1
            }, {
                TypeName: 'Ayaktan',
                TypeID: 0
            }, {
                TypeName: 'Yatan',
                TypeID: 1
            }];

        this.sterilizationWorkListStateItem = [
            {
                DisplayText: 'Sterilizasyon İstendi',
                StateDefID: "7ba9fab9-8db1-469e-a4a4-24e17725440f"
            }, {
                DisplayText: 'Ön Hazırlık',
                StateDefID: " 7f13693f-a079-43b1-b99b-b900de8ac66c"
            }, {
                DisplayText: 'Hazırlık',
                StateDefID: "8f3c5cf2-fa0c-43e4-8d9c-1bf8c72e77c6"
            }, {
                DisplayText: 'Cihazda',
                StateDefID: "4535c0d6-df95-4d0b-8bcd-f03a140b37f5"
            }, {
                DisplayText: 'Sterilizasyon Yapılıyor',
                StateDefID: "68966a5d-d46c-4124-89c7-5eddc31df502"
            },  {
                DisplayText: 'Tamamlandı',
                StateDefID: "6bc57913-7bed-46a8-97f8-da2b80d9a682"
            }, ];

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "ResUserListDefinition";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 154;

    }

    ngOnDestroy() {
        //this.activeEpisodeActionService.ActiveEpisodeActionID = Guid.Empty;
    }


    isNextStateTextVisible(): Boolean
    {
        if (this.NextStateText == "")
            return false;
        return true;
    }

    getWorkList() {

        let that = this;
        if (this.sterilizationWorkListViewModel._sterilizationWorkListSearchCriteria.selectedSterilizationWorkListStateItem == null || this.sterilizationWorkListViewModel._sterilizationWorkListSearchCriteria.selectedSterilizationWorkListStateItem.toString() == "00000000-0000-0000-0000-000000000000") {
            ServiceLocator.MessageService.showError("'Durum' Alanı seçilmeden Listeleme yapılamaz");
        }
        else {
            let _SearchCriteria: SterilizationWorkListSearchCriteria = new SterilizationWorkListSearchCriteria();
            this.loadPanelOperation(true, 'İşlemler listeleniyor, lütfen bekleyiniz.');
            that.httpService.post<SterilizationWorkListItemModel []>("api/SterilizationWorkListService/GetSterilizationActionWorkList", that.sterilizationWorkListViewModel._sterilizationWorkListSearchCriteria)
                .then(response => {
                    that.sterilizationWorkListViewModel.sterilizationActionList =  response as SterilizationWorkListItemModel[];

                    if (that.sterilizationWorkListViewModel.sterilizationActionList.length > 0)
                        that.NextStateText = that.sterilizationWorkListViewModel.sterilizationActionList[0].nextStateText;
                    else
                        that.NextStateText = "";
                    // this.searchAccordion.selectedIndex = -1;
                    // this.saveOrtezWorklistFilterUserOption();
                    this.systemApiService.componentInfo = null;
                    this.loadPanelOperation(false, '');
                })
                .catch(error => {
                    this.loadPanelOperation(false, '');
                    this.messageService.showError(error);

                });
        }

        // });
    }

   async getModelInfo() {
        let that = this;

        let currentDate: Date = (await CommonService.RecTime());
        currentDate = plainToClass(Date, currentDate);

        that.httpService.get<SterilizationFilterList>("api/SterilizationWorkListService/GetModelInfo")
            .then(response => {
                that.sterilizationWorkListViewModel._sterilizationFilterList =  response as SterilizationFilterList;

                // that.sterilizationWorkListViewModel._sterilizationWorkListSearchCriteria.sterilizationWorkListStateItem.forEach(element => {
                //     that.sterilizationWorkListViewModel._sterilizationWorkListSearchCriteria.selectedSterilizationWorkListStateItem.push(element);

                // });

                that.sterilizationWorkListViewModel._sterilizationWorkListSearchCriteria.workListStartDate = currentDate;
                that.sterilizationWorkListViewModel._sterilizationWorkListSearchCriteria.workListEndDate = currentDate;
                this.generateColumns();
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }

    getEnumDataSources()
    {
        this.sterilizationWorkListViewModel.gridDataSources.sterilizationPackageMethodEnumItems = SterilizationPackageMethodEnum.Items;
        this.sterilizationWorkListViewModel.gridDataSources.indicatorSelectionEnumItems = IndicatorSelectionEnum.Items;
        this.sterilizationWorkListViewModel.gridDataSources.sterilizasyonSelectionEnumItems = SterilizationEnum.Items;
    }

    generateColumns()
    {
        let that = this;
        that.WorkListColumns = [
            {
                caption: i18n("M17021", "Malzeme adı"),
                dataField: "MaterialName",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: i18n("M17579", "İstek Birimi"),
                dataField: "ResSectionName",
                dataType: 'string',
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: i18n("M16650", "İstek Tarihi"),
                dataField: "RequestDate",
                dataType: "datetime",
                format: "dd/MM/yyyy HH:mm",
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: i18n("M13372", "İşlemin Durumu"),
                dataField: "CurrentState",
                width: "auto",
                allowSorting: true,
                allowEditing: false
            },
            {
                caption: i18n("M13372", "Paketleme Yöntemi"),
                dataField: "PackageMethod",
                width: "auto",
                allowSorting: true,
                lookup: { dataSource: this.sterilizationWorkListViewModel.gridDataSources.sterilizationPackageMethodEnumItems, valueExpr: 'code', displayExpr: 'description' }
            }, {
                caption: i18n("M13372", "İndikatör Yöntemi"),
                dataField: "IndicatorSelection",
                width: "auto",
                allowSorting: true,
                lookup: { dataSource: this.sterilizationWorkListViewModel.gridDataSources.indicatorSelectionEnumItems, valueExpr: 'code', displayExpr: 'description' }
            }, {
                caption: i18n("M13372", "Cihaz"),
                dataField: "ResSterilizationDevice",
                width: "auto",
                allowSorting: true,
                lookup: { dataSource: this.sterilizationWorkListViewModel._sterilizationFilterList.deviceList, valueExpr: 'ObjectID', displayExpr: 'Name' }
            }, {
                caption: i18n("M13372", "Cihaz Döngü No"),
                dataField: "DeviceLoopNo",
                width: "auto",
                allowSorting: true,
                allowEditing: false
            }, {
                caption: i18n("M13372", "Kabul Eden Kullanıcı"),
                dataField: "SterilizationUser",
                width: "auto",
                allowSorting: true,
                lookup: { dataSource: this.sterilizationWorkListViewModel._sterilizationFilterList.sterilizationUserList, valueExpr: 'ObjectID', displayExpr: 'Name' }
            }, {
                caption: i18n("M13372", "Teslim Alan Kullanıcı"),
                dataField: "DeliveredUserAfterUser",
                width: "auto",
                allowSorting: true,
                lookup: { dataSource: this.sterilizationWorkListViewModel._sterilizationFilterList.deliveredUserAfterUserList, valueExpr: 'ObjectID', displayExpr: 'Name' }
            }

        ];
    }

    async clientPreScript() {
        // let a = this.getDietList();
    }

    clientPostScript(state: String): void {
        // throw new Error('Method not implemented.');
    }

    async select(value: any): Promise<void> {

        // var component = value.component,
        //     prevClickTime = component.lastClickTime;
        // component.lastClickTime = new Date();
        // if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
        //     //Double click code
        //     this.loadPanelOperation(true, 'Form hazırlanıyor, lütfen bekleyiniz.');
        //     let _data: SterilizationWorkListItemModel = value.data as SterilizationWorkListItemModel;
        //     this.activeEpisodeActionService.ActiveEpisodeActionID = new Guid(_data.ObjectID);
        //     this.openDynamicComponent("ORTHESISPROSTHESISREQUEST", _data.ObjectID);
        // }

    }

    public initFormControls(): void {

        this.btnListele = new TTVisual.TTButton();
        this.btnListele.Text = i18n("M27337", "Listele");
        this.btnListele.Name = "btnListele";
        this.btnListele.TabIndex = 12;
    }

    public btnSearchClicked(): void {

        let a = this.getWorkList();
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }


    getStateIndex(id: string, outputList: StateOutputDVO): number {
        return outputList.WorkListSearchStateItem.findIndex(o => o.StateDefID === id);
    }

    removeState(_index: number, outputList: StateOutputDVO): EpisodeActionWorkListStateItem[] {
        outputList.WorkListSearchStateItem.splice(_index, 1);

        return outputList.WorkListSearchStateItem;
    }

    onOrtezProtezWorkListStateItems(e: any): void {
        this.sterilizationWorkListViewModel._sterilizationFilterList.sterilizationWorkListStateItem = e.value;
    }

    public onRequesterDoctorChanged(event): void {

        this.sterilizationWorkListViewModel._sterilizationWorkListSearchCriteria.requesterDoctor = event;
    }

    public saveSterilizationHistory() {
        let that = this;
        if (that.selectedRowKeysResultList.length > 0) {
            if (this.sterilizationWorkListViewModel._sterilizationWorkListSearchCriteria.selectedSterilizationWorkListStateItem.toString() == SterilizationHistory.SterilizationHistoryStates.InDevice.toString() &&
                that.selectedRowKeysResultList.find(dr => dr.ResSterilizationDevice == null || dr.ResSterilizationDevice == "") != null) {
                this.messageService.showError("Cihaz seçmeden devam edilemez..");
            }
            else {
                this.loadPanelOperation(true, 'İşlemler kaydediliyor, lütfen bekleyiniz.');
                that.httpService.post<any>("api/SterilizationWorkListService/SaveSterilizationHistory", that.selectedRowKeysResultList)
                    .then(response => {

                        this.loadPanelOperation(false, '');

                        this.getWorkList();
                    })
                    .catch(error => {
                        this.loadPanelOperation(false, '');
                        this.messageService.showError(error);

                    });
            }
        }

    }

    btnPrintRationReportClicked() {
 
    }

    public dynamicComponentClosed(e: any) {
        this.isComponentOpened = false;
        let that = this;
        setTimeout(function () {
            if (that.ortezProtezWorkListGrid != null && that.ortezProtezWorkListGrid.instance != null && that.ortezProtezWorkListGrid.instance["_disposed"] == null)
            {
                that.ortezProtezWorkListGrid.instance.repaint();
            }
        }, 30);
        //that.activeEpisodeActionService.ActiveEpisodeActionID = Guid.Empty;
    }

    public componentCreated(e: any) {
        this.isComponentOpened = true;
        this.loadPanelOperation(false, '');
        let that = this;
        setTimeout(function () {
            that.ortezProtezWorkListGrid.instance.repaint();
        }, 300);
    }

    //Hizmet/tetkik filtrelemesini user option olarak saklamak icin
    async saveOrtezWorklistFilterUserOption(): Promise<void> {
        try {
            //let inputDVO = new UserOptionInputDVO();
            //inputDVO.UserOptionType = UserOptionType.FilterProcedureAndTests;

            //let optionValue = "";
            //if (this.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria.ortezProtezWorkListStateItem != null)
            //    for (var i = 0; i < this.ortezProtezWorkListViewModel._ortezProtezWorkListSearchCriteria.ortezProtezWorkListStateItem.length; i++) {

            //    }

            //inputDVO.OptionValue = optionValue;

            let apiUrl: string = 'api/OrtezProtezWorkListService/SaveUserOption';
            let result = await this.httpService.post(apiUrl, this.sterilizationWorkListViewModel._sterilizationWorkListSearchCriteria);

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }

    }

    public onRowPrepared(e: any): void {
        //e.rowElement.firstItem().css({ 'line-height': '12px' });
        this.renderer.setStyle(e.rowElement.firstItem(), "line-height", "12px");
    }

    public textBoxKeyPress(e: any) {
        let charArray: Array<string> = new Array<string>();
        let _jQueryEvent: string = e.jQueryEvent.key;

        charArray = ['ç', 'Ç', 'ö', 'Ö', 'ş', 'Ş', 'ü', 'Ü', 'Ğ', 'ğ', 'ı', 'İ', '-'];

        if ((_jQueryEvent < 'A' || _jQueryEvent > 'z') && charArray.findIndex(p => p == _jQueryEvent) < 0)
            e.jQueryEvent.preventDefault();
    }

    keyDownForNumericControl(event: any) {

        if (event != null && event.srcElement != null && event.srcElement.value != null && event.srcElement.value.length < 11 && !(new RegExp('[\.,]', 'g')).test(event.key)) {

        }
        else {
            event.preventDefault();
        }
    }

    public OnSelectedSterilizationWorkListStateChanged(e: any)
    {
        this.sterilizationWorkListViewModel.sterilizationActionList = new Array<SterilizationWorkListItemModel>();
        this.NextStateText = "";
    }
}



