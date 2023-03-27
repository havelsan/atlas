//$0D23E1A1
import { Component, ViewChild } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { NursingWorkListViewModel, InputFor_Get_DrugOrderDetails, DrugOrderDetailOutputItem, InputFor_StateUpdateForSelecetedItem, PatientItem, StatusItem, CostomDrugOrder } from './NursingWorkListViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { CommonService } from 'ObjectClassService/CommonService';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { DxToolbarComponent } from 'devextreme-angular';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { OrderTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import DataSource from 'devextreme/data/data_source';

import { ShowBox } from 'NebulaClient/Visual/ShowBox';
@Component({
    selector: 'nursing-workList-form',
    templateUrl: './NursingWorkListForm.html',
    providers: [SystemApiService, MessageService]
})

export class NursingWorkListForm extends BaseComponent<NursingWorkListViewModel> {
    public tagBoxResources: DataSource;
    public selectedWorkListItems: Array<Resource>;
    public masterResourceGuidList: Array<Guid>;
    public patientList: Array<PatientItem>;
    public statusListForClient: Array<StatusItem>;
    public startDate: Date = new Date();
    public endDate: Date = new Date();
    public inputFor_Get_DrugOrderDetails: InputFor_Get_DrugOrderDetails;
    public drugOrderDetails: Array<DrugOrderDetailOutputItem>;
    public caseOfNeedDrugOrders: Array<CostomDrugOrder>;
    public tempDrugOrderDetails: Array<DrugOrderDetailOutputItem>;
    public filterDrugOrderDetails: Array<DrugOrderDetailOutputItem>;
    public toolbarItems: any[];
    public selectedTempItems: Array<DrugOrderDetailOutputItem>;
    public OrderTypeList: any[];
    public tempStatusListForClient: Array<StatusItem>;
    public justMyPatient: boolean = true;

    public filterExpForPatientList: string;
    public filterExpForStatusListForClient: string;
    public filterExpForListType: number;

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public toolbarCaseOfNeedItems: any[];
    public selectedTempCaseOfNeedItems: Array<CostomDrugOrder>;

    @ViewChild('toolbarItem') _toolbarItem: DxToolbarComponent;

    constructor(protected messageService: MessageService, container: ServiceContainer, private http: NeHttpService, public systemApiService: SystemApiService,
        protected modalService: IModalService, private objectContextService: ObjectContextService) {
        super(container);

        this.selectedWorkListItems = new Array<Resource>();
        this.drugOrderDetails = new Array<any>();
        this.caseOfNeedDrugOrders = new Array<any>();

        this.filterExpForPatientList = 'Seçiniz';
        this.filterExpForStatusListForClient = 'Seçiniz';
        this.filterExpForListType = -1;



        this.toolbarItems = [
            {
                location: 'before',
                widget: 'dxButton',
                locateInMenu: 'auto',
                options: {
                    icon: 'preferences',
                    text: 'GİÇ Oluştur',
                    type: 'success',
                    visible: this.Model.toolOption == true ? true : false,
                    onClick: () => {
                        this.getUsercontrolTool();
                    }
                }
            }, {
                location: 'center',
                locateInMenu: 'never',
                template: () => {
                    return i18n("M10052", "<div class=\'toolbar-label\'><b>HEMŞİRELİK HİZMETLERİ</b></div>");
                }
            },
            {
                location: 'after',
                widget: 'dxButton',
                locateInMenu: 'auto',
                options: {
                    icon: 'fa fa-check-square-o',
                    text: i18n("M23745", "Uygula"),
                    type: 'success',
                    onClick: () => {
                        this.selectedGridItem();
                        this.sendClick();
                    }
                }
            }
        ];

        this.toolbarCaseOfNeedItems = [
            {
                location: 'after',
                widget: 'dxButton',
                locateInMenu: 'auto',
                options: {
                    icon: 'fa fa-check-square-o',
                    text: i18n("M16639", "İstek Oluştur"),
                    type: 'success',
                    onClick: () => {
                        this.controlofPharmcyOpenOrClose();
                    }
                }
            }
        ];



        this.OrderTypeList = [
            {
                TypeName: 'Seçiniz',
                TypeID: -1
            }, {
                TypeName: i18n("M15641", "Hemşire Direktifi"),
                TypeID: 1
            }, {
                TypeName: i18n("M16311", "İlaç Direktifi"),
                TypeID: 0
            }
        ];
    }

    async  DailyDrugClick() {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DailyDrugScheduleNewForm';
            componentInfo.ModuleName = 'GunlukIlacCizelgesiModule';
            componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Gunluk_Ilac_Cizelgesi_Modulu/GunlukIlacCizelgesiModule';
            //componentInfo.InputParam = this._NursingApplication;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16335", "İlaç İstek");
            modalInfo.Width = 1200;
            modalInfo.Height = 750;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    filterExp(data: any) {
        /*
        if (data.itemData.ObjectID === Guid.Empty.id) {
            this.filterDrugOrderDetails = this.tempDrugOrderDetails;
        } else {
            this.filterDrugOrderDetails = this.drugOrderDetails.filter(item => item.PatientFullName === data.itemData.PatientFullName);
        }
        this.drugOrderDetails = this.filterDrugOrderDetails;
        */
        if (data.itemData.ObjectID === Guid.Empty.id) {
            this.filterExpForPatientList = 'Seçiniz';
        } else {
            this.filterExpForPatientList = data.itemData.PatientFullName;
        }
    }
    filterStatusExp(data: any) {
        /*
        if (data.itemData.StateID === Guid.Empty.id) {
            this.filterDrugOrderDetails = this.tempDrugOrderDetails;
        } else {
            this.filterDrugOrderDetails = this.drugOrderDetails.filter(item => item.statusName === data.itemData.StatusItemName);
        }
        this.drugOrderDetails = this.filterDrugOrderDetails;
        */
        if (data.itemData.ObjectID === Guid.Empty.id) {
            this.filterExpForStatusListForClient = 'Seçiniz';
        } else {
            this.filterExpForStatusListForClient = data.itemData.StatusItemName;
        }
    }
    filterTypeExp(data: any) {
        this.statusListForClient = this.tempStatusListForClient;

        if (data.itemData.TypeId === -1) {
            this.filterExpForListType = -1;
        } else {
            this.filterExpForListType = data.itemData.TypeID;
            this.statusListForClient = this.statusListForClient.filter(x => x.TypeID === data.itemData.TypeID || x.TypeID === -1);
        }

        this.filterExpForStatusListForClient = 'Seçiniz';

    }

    async clientPreScript() {
        await this.getUserResources();

    }



   async get_caseOfNeeDrugOrder(input: InputFor_Get_DrugOrderDetails){
    let inputDvo = input;
    let that = this;

    let fullApiUrl: string = 'api/NursingWorkListService/Get_caseOfNeeDrugOrder';
        that.http.post(fullApiUrl, inputDvo)
        .then((res: NursingWorkListViewModel) => {
            that.Model = res;
            that.caseOfNeedDrugOrders = that.Model.output_caseOfNeedDrugOrder.caseOfNeedDrugOrders;
        })
        .catch(error => {
            console.log(error);
        });
    }


   async controlofPharmcyOpenOrClose() {
       let that = this;
       let fullApiUrl: string = 'api/NursingWorkListService/controlOfPharmacyOpenned';
       that.http.post(fullApiUrl, null)
           .then((res: NursingWorkListViewModel) => {
               that.Model = res;
               if (that.Model.pharmcyOpen) {
                   this.createByCaseOfNeed(this.selectedTempCaseOfNeedItems);
               }
               else
               {
                   this.awaitCreateDrugOrder();
               }
           })
           .catch(error => {
               console.log(error);
           });
   }

   async awaitCreateDrugOrder() {
       let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", i18n("M13443", "Ecz. Kapalı Genede İste"));
       if (result === "OK") {
           this.createByCaseOfNeed(this.selectedTempCaseOfNeedItems);
       }
   }

   async createByCaseOfNeed(items: Array<CostomDrugOrder>) {
       if (items.length > 0)
       {
           let inputCaseOfNeed = items;
           let that = this;
           let fullApiUrl: string = 'api/NursingWorkListService/Create_CaseOfNeeDrugOrder';
           that.http.post(fullApiUrl, inputCaseOfNeed)
               .then((res: NursingWorkListViewModel) => {
                   that.Model = res;
                   ServiceLocator.MessageService.showInfo(that.Model.ksMaterialNote);
                   that.caseOfNeedDrugOrders = new Array<any>();
               })
               .catch(error => {
                   console.log(error);
               });
       }
   }



    sendClick() {
        this.drugOrderDetails = new Array<any>();
        this.systemApiService.componentInfo = null;
        this.callGetMehodForDrugOrderDets();
    }

   async callGetMehodForDrugOrderDets() {
        this.masterResourceGuidList = new Array<Guid>();
        this.inputFor_Get_DrugOrderDetails = new InputFor_Get_DrugOrderDetails();
        this.inputFor_Get_DrugOrderDetails.start_Time = this.startDate;
        this.inputFor_Get_DrugOrderDetails.end_Time = this.endDate;
        this.inputFor_Get_DrugOrderDetails.typeID = this.filterExpForListType;
        this.inputFor_Get_DrugOrderDetails.justMyPatient = this.justMyPatient;

        for (let item of this.selectedWorkListItems) {
            this.masterResourceGuidList.push(item.ObjectID);
        }
        if (this.masterResourceGuidList != null && this.masterResourceGuidList.length > 0) {
            this.inputFor_Get_DrugOrderDetails.MasterResourcesList = this.masterResourceGuidList;
        }
        else {
            TTVisual.InfoBox.Alert(i18n("M11298", "Listeleme yapabilmek için en az bir tane birim seçmelisiniz."));
            return false;
        }

        await this.get_drugOrderDetails(this.inputFor_Get_DrugOrderDetails);
        await this.get_caseOfNeeDrugOrder(this.inputFor_Get_DrugOrderDetails);

    }


    get_drugOrderDetails(input: InputFor_Get_DrugOrderDetails) {
        let inputDvo = input;
        let that = this;
        let fullApiUrl: string = 'api/NursingWorkListService/Get_DrugOrderDetails';


        that.http.post(fullApiUrl, inputDvo)
            .then((res: NursingWorkListViewModel) => {
                that.Model = res;

                if (that.Model && that.Model.output_drugOrderDetails) {
                    this.drugOrderDetails = that.Model.output_drugOrderDetails.drugOrderDetails;
                    this.tempDrugOrderDetails = that.Model.output_drugOrderDetails.drugOrderDetails;
                    //this.filterDrugOrderDetails = that.Model.output_drugOrderDetails.drugOrderDetails;
                } else {
                    this.drugOrderDetails = new Array<any>();
                }

                if (that.Model && that.Model.patients) {
                    this.patientList = that.Model.patients;
                } else {
                    this.patientList = new Array<PatientItem>();
                }

                if (that.Model && that.Model.statusList) {
                    this.statusListForClient = that.Model.statusList;
                    this.tempStatusListForClient = that.Model.statusList;
                } else {
                    this.statusListForClient = new Array<StatusItem>();
                    this.tempStatusListForClient = new Array<StatusItem>();
                }

                this.filterMyGrid();

            })
            .catch(error => {
                console.log(error);
            });
    }

    filterMyGrid() {

        this.drugOrderDetails = this.tempDrugOrderDetails;

        if (this.filterExpForPatientList === 'Seçiniz') {
            this.drugOrderDetails = this.tempDrugOrderDetails;
        } else {
            this.drugOrderDetails = this.tempDrugOrderDetails.filter(item => item.PatientFullName === this.filterExpForPatientList);
        }

        if (this.filterExpForStatusListForClient !== 'Seçiniz') {
            this.drugOrderDetails = this.drugOrderDetails.filter(item => item.statusName === this.filterExpForStatusListForClient);
        }

        if (this.filterExpForListType !== undefined && this.filterExpForListType !== -1) {
            this.drugOrderDetails = this.drugOrderDetails.filter(item => item.typeId === this.filterExpForListType);
        }
    }

    async getUserResources() {
        let that = this;
        let fullApiUrl = 'api/NursingWorkListService/Get_UserResources';
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        that.http.post(fullApiUrl, options)
            .then((res: NursingWorkListViewModel) => {
                that.Model = res;
                if (that.Model && that.Model.output) {
                    this.tagBoxResources = new DataSource({
                        store: that.Model.output.resources,
                        searchOperation: 'contains',
                        searchExpr: 'name'
                    });
                    that.selectedWorkListItems = that.Model.output.resources;
                    that.startDate = that.Model.output.startDate;
                    that.endDate = that.Model.output.endDate;
                    that.toolbarItems[0].options.visible = that.Model.toolOption;
                    that._toolbarItem.instance.repaint();
                    that.callGetMehodForDrugOrderDets();
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }


    async getUsercontrolTool() {
        let that = this;
        let fullApiUrl = 'api/NursingWorkListService/Get_UsercontrolTool';
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        that.http.post(fullApiUrl, options)
            .then((res: NursingWorkListViewModel) => {
                that.Model = res;
                if (that.Model.toolOption) {
                    this.DailyDrugClick();
                } else {
                    ServiceLocator.MessageService.showError("GİÇ PARAMETRESİ KAPALI");
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }



    clientPostScript(state: String): void {
        // throw new Error('Method not implemented.');
    }

    async select(value: any): Promise<void> {

        let currentDate: Date = (await CommonService.RecTime());
        currentDate = plainToClass(Date, currentDate);

        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            let _data: DrugOrderDetailOutputItem = value.data as DrugOrderDetailOutputItem;
            this.loadPanelOperation(true, i18n("M14461", "Form hazırlanıyor, lütfen bekleyiniz."));
            if (value.data.typeId === OrderTypeEnum.NursingOrder)
                this.openNursingOrderDetailForm(value.data.id, currentDate);
                //this.createNursingOrderDetailForm(value.data.id, currentDate);
                //this.openDynamicComponent('NURSINGORDERDETAIL', _data.id);
            else if (value.data.typeId === OrderTypeEnum.DrugOrder) {
                //this.openDynamicComponent('DRUGORDERDETAIL', _data.id);
                this.createDrugOrderDetailForm(value.data.id);
            }
        }

    }

    //openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
    //    if (objectID != null) {
    //        this.systemApiService.open(objectID, objectDefName, formDefId, inputparam).then(x => {
    //            this.loadPanelOperation(false, '');
    //        });
    //    } else {
    //        this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
    //            this.loadPanelOperation(false, '');
    //        });
    //    }
    //    //    this.setComponentPatientInfo();

    //}

    async selectDrugOrderDetail(data: any) {
        let isMessageShownBefore: boolean = false;
        if (data.currentSelectedRowKeys.length >= 1) {
            if (data.currentSelectedRowKeys != null) {
                for (let i = 0; (i < data.currentSelectedRowKeys.length); i++) {
                    if ((data.currentSelectedRowKeys[i].typeId === OrderTypeEnum.NursingOrder) ||
                        (DrugOrderDetail.DrugOrderDetailStates.UseRestDose.id !== data.currentSelectedRowKeys[i].stateDefID.toString()
                            && DrugOrderDetail.DrugOrderDetailStates.Supply.id !== data.currentSelectedRowKeys[i].stateDefID.toString())) {

                        if (!isMessageShownBefore && data.currentSelectedRowKeys[i].typeId !== OrderTypeEnum.NursingOrder) //üstten tamamını seçtiği zaman mesajı bir kere göstersin ve hemşire direktif değilse
                            this.messageService.showInfo(i18n("M12087", "Bu işlemler ilerletilemez!"));

                        isMessageShownBefore = true;

                        data.component.deselectRows(data.currentSelectedRowKeys[i]);
                    }
                }
            }
        }
    }

    selectedGridItem() {
        if (this.selectedTempItems.length > 0) {
            let inputObj: InputFor_StateUpdateForSelecetedItem = new InputFor_StateUpdateForSelecetedItem();
            inputObj.DrugOrderDetails = new Array<Guid>();

            for (let drugOrderDet of this.selectedTempItems) {
                inputObj.DrugOrderDetails.push(drugOrderDet.id);
            }

            this.stateUpdateForSelecetedItem(inputObj);
            this.selectedTempItems = new Array<DrugOrderDetailOutputItem>();
        }
    }
    stateUpdateForSelecetedItem(input: InputFor_StateUpdateForSelecetedItem) {
        let inputDvo = input;
        let that = this;
        let fullApiUrl: string = 'api/NursingWorkListService/StateUpdateForSelecetedItem';
        that.http.post(fullApiUrl, inputDvo)
            .then((res: NursingWorkListViewModel) => {
                let result = res;
                this.messageService.showInfo(i18n("M16953", "İşlemler Başarılı Şekilde Tamamlandı."));
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    private openNursingOrderDetailForm(_id: string, _scheduleWorkListDate: Date) {
        this.createNursingOrderDetailForm(_id, _scheduleWorkListDate).then(result => {
            let modalActionResult = result as ModalActionResult;
            if (modalActionResult.Result == DialogResult.OK) {
                this.sendClick();
            }
        });

    }

    private createNursingOrderDetailForm(data: string, _scheduleWorkListDate: Date): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'NursingOrderDetailForm';
            componentInfo.ModuleName = 'HemsirelikIslemleriModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/HemsirelikIslemleriModule';
            componentInfo.InputParam = <any>_scheduleWorkListDate;
            componentInfo.objectID = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M15638", "Hemşire Direktif Ekranı");
            modalInfo.Width = 800;
            modalInfo.Height = 350;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private createDrugOrderDetailForm(data: string): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderDetailForm';
            componentInfo.ModuleName = 'TedaviIlacUgulamaModule';
            componentInfo.ModulePath = 'Modules/Saglik_Lojistik/Eczane_Modulleri/Tedavi_Ilac_Ugulama_Modulu/TedaviIlacUgulamaModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M23747", "Uygulama");
            modalInfo.Width = 800;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                this.sendClick();
            }).catch(err => {
                reject(err);

            });

        });
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }


}


