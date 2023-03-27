//$4E54A6BC
import { Component, ViewChild, OnDestroy, AfterViewInit, Renderer2 } from '@angular/core';
import { ComposeComponent } from 'Fw/Components/ComposeComponent';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { BaseEpisodeActionWorkListFormViewModel, BaseEpisodeActionWorkListItem, ActiveInfoDVO, FollowingPatientList } from "./BaseEpisodeActionWorkListFormViewModel";
import { DxAccordionComponent, DxDataGridComponent } from "devextreme-angular";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { MessageService } from 'Fw/Services/MessageService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Subscription, Observable } from 'rxjs';
import { SimpleTimer } from 'ng2-simple-timer';
import { IModalService } from 'Fw/Services/IModalService';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfoDVO } from 'Fw/Models/DynamicComponentInfoDVO';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { HealthCommitteeWorkListItem } from './Saglik_Kurulu_Is_Listesi/HealthCommitteeWorkListViewModel';
import { HealthCommittee, SystemParameter, FollowingPatients } from 'app/NebulaClient/Model/AtlasClientModel';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';

@Component({
    selector: "BaseEpisodeActionWorkListForm",
    inputs: ['Model'],
    templateUrl: './BaseEpisodeActionWorkListForm.html',
    providers: [SystemApiService],
})
export class BaseEpisodeActionWorkListForm extends BaseComponent<BaseEpisodeActionWorkListFormViewModel> implements OnDestroy, AfterViewInit {

    public isAutoCallPatient: boolean = false;
    public showTrackingPatients = false;

    constructor(protected container: ServiceContainer, protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, protected activeUserService: IActiveUserService, protected st: SimpleTimer, protected modalService: IModalService, public renderer: Renderer2) {
        super(container);

        this.preparePageProperties();
        this.loadViewModel();
        const that = this;
        this.episodeActionWorkListSubscription = this.httpService.episodeActionWorkListSharedService.EpisodeActionWorkListItem.subscribe(
            EpisodeActionWorkListSharedItemModel => {
                this.openDynamicComponent(EpisodeActionWorkListSharedItemModel.ObjectDefName, EpisodeActionWorkListSharedItemModel.ObjectID, EpisodeActionWorkListSharedItemModel.FormDefID, EpisodeActionWorkListSharedItemModel.InputParam);
            }
        );

        if (this.refreshWorkListAutomatically != false) {
            this.refreshEpisodeActionSubscription = this.httpService.episodeActionWorkListSharedService.RefreshEpisodeActionWorkList.subscribe(
                RefreshEpisodeActionWorkList => {
                    if (RefreshEpisodeActionWorkList) {
                        that.btnSearchClicked();
                    }
                    that.httpService.episodeActionWorkListSharedService.refreshWorklist(false);
                });
        }
        
        this.refreshHCExaminationFormSubscription = this.httpService.episodeActionWorkListSharedService.RefreshHCExaminationForm.subscribe(
            (refreshToken) => {
                // that.refreshHCExaminationForm = refreshToken;
                this.systemApiService.componentInfo=refreshToken;
            }
        );

    }

    public refreshHCExaminationForm: string;

    private episodeActionWorkListSubscription: Subscription;
    private refreshEpisodeActionSubscription: Subscription;
    private refreshHCExaminationFormSubscription: Subscription;

    private selectedRowData: any;

    ngAfterViewInit(): void {
        let that = this;
        that.getWorkListGridColumn();// Kullanıcı Bazlı Kolon Sırası get etmek için
        setTimeout(function () {
            that.accordionContainerHeight = that.setAccordionRowCotainerHeight('100%');
        }, 50);// Kullanıcı Bazlı Kolon Sırası get etmek için
    }

    ngOnDestroy() {
        if (this.episodeActionWorkListSubscription != null) {
            this.episodeActionWorkListSubscription.unsubscribe();
            this.episodeActionWorkListSubscription = null;
        }
        if (this.refreshEpisodeActionSubscription != null) {
            this.refreshEpisodeActionSubscription.unsubscribe();
            this.refreshEpisodeActionSubscription = null;
        }
        if (this.refreshHCExaminationFormSubscription != null) {
            this.refreshHCExaminationFormSubscription.unsubscribe();
            this.refreshHCExaminationFormSubscription = null;
        }
        this.st.delTimer(this.seachTimer);
    }
    clientPreScript(): void {

    }
    clientPostScript(state: String): void {

    }
    // Timera Bağlı Listeleme
    public timerperiod: number = 60;
    public seachTimer: string = "seachTimer";

    timerId: string;

    subscribeTimer() {

        this.st.unsubscribe(this.timerId);
        this.timerId = this.st.subscribe(this.seachTimer, () => { this.fillList() });

    }
    public fillList() {

    }

    public refreshWorkListAutomatically = true;

    public preparePageProperties() {
        this.refreshWorkListAutomatically = true;
    }

 

    // ***** Ortak Property ve Methodlar start *****
    public ViewModel: BaseEpisodeActionWorkListFormViewModel;

    public loadViewModel() {
    }

    // eğer  kodsal olarak bir satır seçilecekse kullanılır
    selectedRowKeysResultList = new Array<BaseEpisodeActionWorkListItem>();
    //Listeleme için

    // Listeleme sırasında yükleniyor ibaresi için html e  aşağıdaki kod eklenmeli
    //<div><dx-load - panel shadingColor= "rgba(0,0,0,0.4)"[(visible)] = "showLoadPanel"[showIndicator] = "true"[showPane] = "true"[shading] = "true"[closeOnOutsideClick] = "false"[(message)] = "LoadPanelMessage" ></dx-load-panel></div>
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    btnSearchClicked() {
        if (this.ViewModel != null && this.ViewModel.autoRefreshWorkList) {
            if (this.st.getTimer().length == 0) {
                if (this.ViewModel) {
                    if (this.ViewModel.timerPeriod) {
                        this.timerperiod = this.ViewModel.timerPeriod;
                    }

                }
                this.st.newTimer(this.seachTimer, this.timerperiod);
            }
            this.subscribeTimer();
        }
        else
            this.fillList();
    }

    panelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    loadSearchingPanel(): void {
        if (this.searchAndListAccordion == null || this.searchAndListAccordion.selectedIndex == 0) // İş listesi Kapalı ise İşlem Yükleniyor paneli gözüksün kapalı ise gözükmesin
            this.panelOperation(true, 'İşlemler listeleniyor, lütfen bekleyiniz.');
    }

    unloadSearchingPanel(): void {
        if (this.showLoadPanel) {
            if (this.searchAndListAccordion == null || this.searchAndListAccordion.selectedIndex == 0) // İş listesi Kapalı ise İşlem Yükleniyor paneli gözüksün kapalı ise gözükmesin
                this.panelOperation(false, '');
        }
    }

    loadCompComponent(): void {
        this.panelOperation(true, 'İşlem Açılıyor, lütfen bekleyiniz.');
    }

    unloadCompComponent(): void {
        this.panelOperation(false, '');
    }
    // WorkListGrid

    public WorkListColumns = [];
    @ViewChild('WorkListGrid') WorkListGrid: DxDataGridComponent;
    // İşlem görüntüleme için


    public onRowPrepared(row: any): void {
        //row.rowElement.firstItem().css({ 'line-height': '12px' });
        this.renderer.setStyle(row.rowElement.firstItem(), "line-height", "12px");
        if (row.rowType == "data") {
            if (row.data.RowColor != null && row.data.RowColor != "") {
                //row.rowElement.firstItem().css('background-color', row.data.RowColor);
                //   this.renderer.setStyle(row.rowElement.firstItem(), "background-color", row.data.RowColor);
                //this.renderer.setStyle(row.rowElement.firstItem(), "background-color", row.data.RowColor);
            }
        }

        let i = 0;
        for (i = 0; i < row.columns.length; i++) {
            if (row.columns[i].dataField == "MedicalInformation") {
                break;
            }
        }

        if (row.rowElement.firstItem() !== undefined && row.rowType !== 'header' && row.rowType !== 'filter' && row.rowElement.firstItem() !== undefined && row.rowElement.firstItem().cells[i] !== undefined) {

            let data: BaseEpisodeActionWorkListItem = row.data as BaseEpisodeActionWorkListItem;
            let currentValueforDrug = data.isPatientDrugAllergic;
            let currentValueforFood = data.isPatientFoodAllergic;
            let currentValueforOthers = data.isPatientOtherAllergic;
            if (currentValueforDrug || currentValueforFood || currentValueforOthers) {
                row.rowElement.firstItem().cells[i].bgColor = '#e06b6b';
            }
        }

        i = 0;
        for (i = 0; i < row.columns.length; i++) {
            if (row.columns[i].dataField == "PatientCallStatus") {
                break;
            }
        }

        if (row.rowElement.firstItem() !== undefined && row.rowType !== 'header' && row.rowType !== 'filter' && row.rowElement.firstItem() !== undefined && row.rowElement.firstItem().cells[i] !== undefined) {

            let data: BaseEpisodeActionWorkListItem = row.data as BaseEpisodeActionWorkListItem;
            if (data.PatientCallStatus != null && data.PatientCallStatus != "") {
                row.rowElement.firstItem().cells[i].style.color = '#C3263A';
                row.rowElement.firstItem().cells[i].style.fontWeight = 800;
            }
        }
    }

    async AutoCallSelectedPatient(data: any): Promise<any> { }

    async select(value: any): Promise<void> {

        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            this.loadCompComponent();
            let that = this;
            try {

                if (this.dynamicComponent && this.dynamicComponent.isBoundFormModified() === true) {
                    const result = confirm('Değişiklikler kaydedilmemiş. Yine de devam etmek istiyor musunuz?');
                    if (result === false) {
                        if (value.component && value.component.getSelectedRowKeys().length) {
                            value.component.deselectRows(value.component.getSelectedRowKeys());
                            value.component.getSelectedRowKeys().splice(0, value.component.getSelectedRowKeys().length);
                            if (this.selectedRowData) {
                                value.component.selectRows([this.selectedRowData]);
                            }
                        }
                        that.unloadCompComponent();
                        return;
                    }
                }

                this.selectedRowData = value;
                let _data: BaseEpisodeActionWorkListItem = value.data as BaseEpisodeActionWorkListItem;

                if (_data.ObjectDefName == "HEALTHCOMMITTEE" && _data["StateID"] == HealthCommittee.HealthCommitteeStates.Cancelled) {
                    // that.messageService.showError("İptal Edilmiş Sağlık Kurulu Formlarını Görüntüleyemezsiniz");
                    TTVisual.InfoBox.Alert("İptal Bilgisi",_data["ReasonOfCancel"],MessageIconEnum.InformationMessage);
                    that.unloadCompComponent();
                }
                else {
                    this.openDynamicComponent(_data.ObjectDefName, _data.ObjectID, null, _data.CompComponetOpeningInputParam);
                    if(this.isAutoCallPatient)
                        this.AutoCallSelectedPatient(_data);
                }
                
            }
            catch (error) {
                that.messageService.showError(error);
                that.unloadCompComponent();
            }
        }

    }

    canDeactivate(): Observable<boolean> | Promise<boolean> | boolean {

        if (this.dynamicComponent && this.dynamicComponent.isBoundFormModified() === true) {
            const result = confirm('Değişiklikler kaydedilmemiş. Yine de devam etmek istiyor musunuz?');
            if (result === false) {
                return false;
            }
        }
        return true;
    }

    public openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (this.openAsPopup) {
            this.openPopUpDynamicComponent(objectDefName, objectID, formDefId, inputparam).then(result => {
                let modalActionResult = result as ModalActionResult;

                this.popUpDynamicComponentClosed(modalActionResult.Result);

            });
            this.unloadCompComponent();
        }
        else {
            this.openPageDynamicComponent(objectDefName, objectID, formDefId, inputparam);
        }

    }

    // <Popup olarak Açma

    public openAsPopup: boolean = false;
    public openPopUpDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "";
            modalInfo.Width = 1400;
            modalInfo.Height = 1000;

            this.httpService.get<DynamicComponentInfoDVO>('api/SystemApi/GetDynamicComponentInfo?ObjectId=' + objectID + '&ObjectDefName=' + objectDefName + '&FormDefId=' + formDefId).then(dynamicComponentInfoDVO => {
                let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                compInfo.ComponentName = dynamicComponentInfoDVO.ComponentName;
                compInfo.ModuleName = dynamicComponentInfoDVO.ModuleName;
                compInfo.ModulePath = dynamicComponentInfoDVO.ModulePath;
                compInfo.objectID = dynamicComponentInfoDVO.objectID;
                compInfo.InputParam = inputparam;

                let result = this.modalService.create(compInfo, modalInfo);
                result.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            }).catch(err => {
                reject(err);
            });
        });
    }

    public popUpDynamicComponentClosed(dialogResult: DialogResult) { // istenirse override edilebilir
        this.systemApiService.componentInfo = null;
        this.unloadCompComponent();
    }


    // Popup olarak Açma>

    // <Ekranda direk Açma

    @ViewChild('dynamicComponent') dynamicComponent: ComposeComponent;

    public openPageDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {

        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam).catch();
        }
        else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
            });
        }
    }



    closeDynamicComponent() {
        this.systemApiService.componentInfo = null;
    }

    public dynamicComponentCreated(e: any) {
        this.loadSearchingPanel();
        let that = this;
        that.RepaintWorkListGrid();
        that.close_searchAndListAccordion();
    }

    public dynamicComponentClosed(e: any) {
        this.unloadCompComponent();
        let that = this;
        setTimeout(function () {
            if (this.WorkListGrid != null && this.WorkListGrid.instance != null && this.WorkListGrid.instance["_disposed"] == null) {//iş listesini açıp sonra başka iş listesine geçersen  compnenlar dispose olduğu için  _disposed null olmuyor hata veriyor
                this.WorkListGrid.instance.repaint();
            }
        }, 30);
        that.open_searchAndListAccordion();
    }

    public dynamicComponentViewModelLoaded(viewModel: any): void {

        this.unloadCompComponent();
    }
    public dynamicComponentLoadErrorOccurred(viewModel: any): void {

        this.unloadCompComponent();
    }


    public dynamicComponentActionExecuted(e: any) {
        //this.closeDynamicComponent(); // htmlde [SaveAndCloseCommandVisible] = true [CloseWithStateTransition] = true verilerek kapatılması sağlanıyor

        //if (e) {
        //    let clickedSearch = true;
        //    if (e.hasOwnProperty('Cancelled')) {// Vazgeçe Bastıysa
        //        if (e.Cancelled) {
        //            clickedSearch = false;
        //        }
        //    }
        //    if (e.hasOwnProperty('IsSave') && e.hasOwnProperty('SaveAndClose')) {
        //        if (e.IsSave && !e.SaveAndClose ) { // Sadece Kaydete Bastıysa
        //            clickedSearch = false;
        //        }
        //    }

        //    if (clickedSearch) {
        //        this.btnSearchClicked();
        //    }
        //}
    }
    // Ekranda direk Açma>
    public RepaintWorkListGrid() {
        setTimeout(function () {
            if (this.WorkListGrid != null && this.WorkListGrid.instance != null) {
                this.WorkListGrid.instance.repaint();
            }
        }, 30);
    }

    // Kolon kaydetmece

    public PageName: string;


    getWorkListGridColumn() {

        let that = this;
        this.httpService.get<Array<string>>("/api/BaseEpisodeActionWorkListService/GetColumnAndOrder?gridName=workListGrid&pageName=" + this.PageName).then(response => {
            let output = <Array<string>>response;
            if (output) {
                that.GenerateResultListColumns(output);
            }
        }).catch(error => {
            that.messageService.showError("Hata : " + error);
        });
    }


    GenerateResultListColumns(columnNameAndOrder: any) {
        let that = this;
        let foundItem = false;
        let i = columnNameAndOrder.length;
        if (columnNameAndOrder) {
            if (columnNameAndOrder.length > 0) {
                for (let baseItem of this.WorkListColumns) {
                    baseItem.visible = false;
                    for (let item of columnNameAndOrder) {
                        foundItem = false;
                        if (item == baseItem.dataField) {
                            baseItem.visible = true;
                            foundItem = true;
                            baseItem.visibleIndex = columnNameAndOrder.indexOf(item);
                            break;
                        }
                    }
                    if (foundItem == false) {
                        baseItem.visibleIndex = i;
                        i++;
                    }
                }
                //this.RepaintWorkListGrid();
            }
        }
    }

    saveWorkListGridColumn() {
        let visibleSEPSearchResultListColumns = this.WorkListGrid.instance.getVisibleColumns();


        let sgcm = [];
        let oneGrid: any = {};
        let transColumnArray = [];
        for (let item of visibleSEPSearchResultListColumns) {
            transColumnArray.push(item.dataField);
        }
        oneGrid.PageName = this.PageName;
        oneGrid.GridName = "workListGrid";
        oneGrid.ColumnNameList = transColumnArray;
        sgcm.push(oneGrid);


        let apiUrlForUserCustomizationKayit: string = '/api/BaseEpisodeActionWorkListService/SaveUserBasedGridColumnCustomization';

        this.httpService.post(apiUrlForUserCustomizationKayit, sgcm).then(response => {
            this.messageService.showSuccess(i18n("M17905", "Kullanıcı Liste Özelleştirmeleri Kayıt Edildi."));
        }).catch(error => {
            this.messageService.showError(error);
        });
    }

    public onToolbarPreparing(e: any) {
        e.toolbarOptions.items.unshift({
            location: 'after',
            widget: 'dxButton',
            options: {
                hint: i18n("M17704", "Kolonları Kaydet"),
                icon: 'save',
                onClick: this.saveWorkListGridColumn.bind(this)
            }
        });
    }

    public onContextMenuPreparing(e: any) { }

    //

    // ***** Ortak Property ve Methodlar end *****

    // ***** Yukardan accordiyonlu arama  Property ve Methodlar start *****

    //  html'e searchAndListAccordion  akordion eklendi ise
    @ViewChild('searchAndListAccordion') searchAndListAccordion: DxAccordionComponent; // yukardan  ve  arama kriterleri ile listeyi içeren akordion
    //open_searchAndListAccordion() {
    //    if (this.searchAndListAccordion)
    //        this.searchAndListAccordion.selectedIndex = 0;
    //}
    //close_searchAndListAccordion() {
    //    if (this.searchAndListAccordion)
    //        this.searchAndListAccordion.selectedIndex = -1;
    //}

    // ***** Yukardan accordiyonlu  Property ve Methodlar end *****
    onProtocolNoEnterKeyDown(e) {
        this.btnSearchClicked();
    }

    public accordionClick(event: any) {
        // console.log(event);
        let that = this;
        if (that.searchAndListAccordion.selectedIndex == -1) {
            setTimeout(function () {
                that.composeComponentRowContainerVisible = { 'display': 'none' };
                that.accordionContainerHeight = that.setAccordionRowCotainerHeight('100%');
            }, 50);

        }
        else {
            setTimeout(function () {
                that.composeComponentRowContainerVisible = { 'display': 'block' };
                that.accordionContainerHeight = that.setAccordionRowCotainerHeight('5%');
            }, 50);
        }
    }

    public accordionContainerHeight;
    public composeComponentRowContainerVisible = { 'display': 'none' };
    open_searchAndListAccordion() {
        let that = this;
        setTimeout(function () {
            that.accordionContainerHeight = that.setAccordionRowCotainerHeight('100%');
            that.composeComponentRowContainerVisible = { 'display': 'none' };
            if (that.searchAndListAccordion)
                that.searchAndListAccordion.selectedIndex = 0;
        }, 50);
    }
    close_searchAndListAccordion() {
        let that = this;
        setTimeout(function () {
            that.accordionContainerHeight = that.setAccordionRowCotainerHeight('5%');
            that.composeComponentRowContainerVisible = { 'display': 'block' };
            if (that.searchAndListAccordion)
                that.searchAndListAccordion.selectedIndex = -1;
        }, 50);
    }
    // ***** Yukardan accordiyonlu  Property ve Methodlar end *****
    setAccordionRowCotainerHeight(height: string) {
        return {
            'height': height
        }
    }

    public onTrackingHiding()
    {
        this.showTrackingPatients = false;
    }

    public getTrackingPatientList()
    {
            
        let that = this;
        try {

            this.httpService.get<Array<FollowingPatientList>>("/api/BaseEpisodeActionWorkListService/GetTrackingPatientList")
            .then(result => {
                if(result != null && result.length > 0)
                {
                    that.ViewModel.TrackingPatientsList = result;
                    that.showTrackingPatients = true;
                }
                else{
                    that.onTrackingHiding();
                    that.messageService.showInfo("Takip Ettiğiniz Hasta Bulunmamaktadır.");
                }
            })
            .catch(error => {
                that.messageService.showError(error);
            });
            
        }
        catch (error) {
            that.messageService.showError(error);
        }
        

    }

    public stopTrackingPatient(event)
    {
        let that = this;
        try {

            this.httpService.get<boolean>("/api/BaseEpisodeActionWorkListService/StopTrackingPatient?ObjectID="+event.data.ObjectID)
            .then(result => {
                if(result)
                {
                    this.messageService.showSuccess("Hasta Başarılı Bir Şekilde Takip Listenizden Çıkarıldı");
                    this.getTrackingPatientList();
                }
                else
                    this.messageService.showError("Hasta Takip Listenizden Çıkarılırken Bir Hata ile Karşılaşıldı.Lütfen bir süre sonra tekrar deneyin.");
            })
            .catch(error => {
                that.messageService.showError(error);
            });
            
        }
        catch (error) {
            that.messageService.showError(error);
        }
    }
 
}