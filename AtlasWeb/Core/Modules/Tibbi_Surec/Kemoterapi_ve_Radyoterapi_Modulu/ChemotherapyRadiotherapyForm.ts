//$0E6BA561
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ChemotherapyRadiotherapyFormViewModel, AddOrUpdateChemoRadioOrder, UpdateChemoRadioOrderDetail, ChemoRadioOrderDetailItem, GetTemplateCureProtocolItem } from './ChemotherapyRadiotherapyFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ChemotherapyRadiotherapy, ChemoRadioCureProtocol, Store, ProcedureForPlannedRequest } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DxButtonComponent } from 'devextreme-angular';
import { UserTemplateModel } from '../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { ClickFunctionParams, ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ProcedureRequestSharedService, PlannedRequestCarrierClass } from '../Tetkik_Istem_Modulu/ProcedureRequestSharedService';
import List from 'app/NebulaClient/System/Collections/List';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { RequestedProceduresForm } from '../Tetkik_Istem_Modulu/RequestedProceduresForm';
import { ProcedureRequestForm } from '../Tetkik_Istem_Modulu/ProcedureRequestForm';

@Component({
    selector: 'ChemotherapyRadiotherapyForm',
    templateUrl: './ChemotherapyRadiotherapyForm.html',
    providers: [MessageService]
})
export class ChemotherapyRadiotherapyForm extends TTVisual.TTForm implements OnInit {
    CureStartDate: TTVisual.ITTDateTimePicker;
    labelCureStartDate: TTVisual.ITTLabel;
    EtkinMaddeList: TTVisual.ITTObjectListBox;
    ChemotherapyApplyMethod: TTVisual.ITTObjectListBox;
    ChemotherapyApplySubMethod: TTVisual.ITTObjectListBox;
    TreatmentMaterial: TTVisual.ITTObjectListBox;
    ChemotherapyProcedure: TTVisual.ITTObjectListBox;
    RadiotherapyProcedure: TTVisual.ITTObjectListBox;

    RadiotherapyXrayDef: TTVisual.ITTObjectListBox;
    public cureDetailGridColumns = [];
    public cureProtocols = [];
    public showDetailStorePopUp: boolean = false;
    public showAddUserTemplatePopUp: boolean = false;
    public showMaterialPopUp: boolean = false;
    public showProcedurePopUp: boolean = false;
    public popUpSelectedStore: Store;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public IsDetailComplete = false;

    public showProcedurePlanningForm: boolean = false;
    public popUpDescription: string = '';
    public patientVki: string = "";
    public patientVya: string = "";
    public patientVsm: string = "";
    /*Şablon */
    public userTemplateName;
    public templateProtocol: ChemoRadioOrderDetailItem;
    /*Şablon */
    @ViewChild('btnSelectStore') btnSelectStore: DxButtonComponent;
    @ViewChild('requestedProcedureForm') requestedProceduresFormInstance: RequestedProceduresForm;
    @ViewChild('procedureRequestForm') procedureRequestFormInstance: ProcedureRequestForm;

    public chemotherapyRadiotherapyFormViewModel: ChemotherapyRadiotherapyFormViewModel = new ChemotherapyRadiotherapyFormViewModel();
    public get _ChemotherapyRadiotherapy(): ChemotherapyRadiotherapy {
        return this._TTObject as ChemotherapyRadiotherapy;
    }
    private ChemotherapyRadiotherapyForm_DocumentUrl: string = '/api/ChemotherapyRadiotherapyService/ChemotherapyRadiotherapyForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private sideBarMenuService: ISidebarMenuService, protected helpMenuService: HelpMenuService, private procedureRequestSharedService: ProcedureRequestSharedService, ) {
        super('CHEMOTHERAPYRADIOTHERAPY', 'ChemotherapyRadiotherapyForm');
        this._DocumentServiceUrl = this.ChemotherapyRadiotherapyForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.cureProtocols = [
            {
                id: "0",
                name: "Kemoterapi"
            },
            {
                id: "1",
                name: "Radyoterapi"
            }
        ];
        this.cureDetailGridColumns = [
            {
                caption: 'Tarih',
                dataField: 'AppliedDate',
                dataType: 'date',
                format: 'dd/MM/yyyy HH:mm',
                allowEditing: false,
                width: 110
            },
            {
                caption: 'Etken Madde',
                dataField: 'EtkenMadde',
                dataType: 'string',
                width: 150
            },
            {
                caption: 'İlaç',
                dataField: 'Cure',
                allowEditing: false,
                width: 280
            },
            {
                caption: 'Çözücü',
                dataField: 'CureSolvent',
                allowEditing: false,
                width: 280
            },
            {
                caption: 'İlaç Dozu',
                dataField: 'DrugDose',
                allowEditing: false,
                width: 75
            },
            {
                caption: 'Çözücü Dozu',
                dataField: 'SolventDose',
                allowEditing: false,
                width: 100
            },
            {
                caption: 'Uygulama Şekli',
                dataField: 'ApplyType',
                allowEditing: false,
                width: 200
            },
            {
                caption: 'Deposu',
                dataField: 'Store',
                allowEditing: false,
                width: 200
            },
            {
                caption: 'Açıklama',
                dataField: 'Description',
                allowEditing: false,
                width: 250
            },
            {
                caption: 'İşlemler',
                dataField: 'currentState',
                cellTemplate: 'buttonCellTemplate',
                allowEditing: false,
                width: 110
            },
            {
                caption: 'Şablon Oluştur',
                dataField: 'currentState',
                cellTemplate: 'templateButtonCellTemplate',
                allowEditing: false,
                width: 100
            }
        ];
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChemotherapyRadiotherapy();
        this.chemotherapyRadiotherapyFormViewModel = new ChemotherapyRadiotherapyFormViewModel();
        this._ViewModel = this.chemotherapyRadiotherapyFormViewModel;
        this.chemotherapyRadiotherapyFormViewModel._ChemotherapyRadiotherapy = this._TTObject as ChemotherapyRadiotherapy;
    }

    protected async loadViewModel() {
        let that = this;
        that.chemotherapyRadiotherapyFormViewModel = this._ViewModel as ChemotherapyRadiotherapyFormViewModel;
        that._TTObject = this.chemotherapyRadiotherapyFormViewModel._ChemotherapyRadiotherapy;
        if (this.chemotherapyRadiotherapyFormViewModel == null)
            this.chemotherapyRadiotherapyFormViewModel = new ChemotherapyRadiotherapyFormViewModel();
        if (this.chemotherapyRadiotherapyFormViewModel._ChemotherapyRadiotherapy == null)
            this.chemotherapyRadiotherapyFormViewModel._ChemotherapyRadiotherapy = new ChemotherapyRadiotherapy();
        if (this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol == null)
            this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol = new ChemoRadioCureProtocol();
        that.chemotherapyRadiotherapyFormViewModel._ChemotherapyRadiotherapy.Episode = that.chemotherapyRadiotherapyFormViewModel.EpisodeObject;
        that.chemotherapyRadiotherapyFormViewModel._ChemotherapyRadiotherapy.Episode.Patient = that.chemotherapyRadiotherapyFormViewModel.PatientObject;

        for (let detailItem of that.chemotherapyRadiotherapyFormViewModel.TreatmentMaterialGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.chemotherapyRadiotherapyFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.chemotherapyRadiotherapyFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.chemotherapyRadiotherapyFormViewModel.DistributionTypeDefinitions.find(o =>
                                    o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }

        }


        this.calculatePatientBodyValues();
        if (that.chemotherapyRadiotherapyFormViewModel.PlannedProcedureRequests.length > 0) {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "", i18n("M21560", "Hastaya tanımlanmış istem planlaması bulunmaktadır. Bunları uygulamak ister misiniz? "), 1);
            if (result === "H")
                return;
            else {
                that.procedureList = new Array<Guid>();
                for (let formDetailDef of that.chemotherapyRadiotherapyFormViewModel.ProcedureForPlannedRequests) {
                    for (let oldRequest of that.chemotherapyRadiotherapyFormViewModel.PlannedProcedureRequests) {
                        if (formDetailDef.PlannedProcedureRequest.toString() == oldRequest.ObjectID.toString()) {
                            if (oldRequest.ProcedureForPlannedRequest == null) {
                                oldRequest.ProcedureForPlannedRequest = new Array<ProcedureForPlannedRequest>();
                            }
                            oldRequest.ProcedureForPlannedRequest.push(formDetailDef);
                        }
                    }
                }

                for (let oldRequest of that.chemotherapyRadiotherapyFormViewModel.PlannedProcedureRequests) {
                oldRequest.PlanApplyDate = new Date();
                    for (let formDetailDef of oldRequest.ProcedureForPlannedRequest) {
                        let procedureDetailDefinition = formDetailDef["ProcedureDetailDefinition"];
                        if (procedureDetailDefinition != null && (typeof procedureDetailDefinition === 'string')) {
                            if (that.procedureList.indexOf(new Guid(procedureDetailDefinition)) == -1) {
                                that.procedureList.push(new Guid(procedureDetailDefinition));
                            }
                            let ProcedureDetailObject = that.chemotherapyRadiotherapyFormViewModel.ProcedureRequestFormDetailDefinitions.find(o => o.ObjectID.toString() === procedureDetailDefinition.toString());
                            if (ProcedureDetailObject) {
                                formDetailDef.ProcedureDetailDefinition = ProcedureDetailObject;
                            }
                        }
                    }
                };
                this.loadPanelOperation(true,"Yükleniyor");
                while(!this.procReqLoaded){};
                this.loadPanelOperation(false,"");
                if(this.procReqLoaded == true){
                    this.loadViewModelCallback();
                }
               
                // that.showProcedurePopUp = true;
                // let plannedRequestCarrierClass: PlannedRequestCarrierClass = new PlannedRequestCarrierClass();
                // plannedRequestCarrierClass.requestDate = new Date();
                // plannedRequestCarrierClass.procedureList = this.procedureList;
                // this.procedureRequestSharedService.setPlannedRequests(plannedRequestCarrierClass);
            }
        }


    }
    procedureList: Array<Guid>;

    loadViewModelCallback() {
        this.showProcedurePopUp = true;
        let plannedRequestCarrierClass: PlannedRequestCarrierClass = new PlannedRequestCarrierClass();
        plannedRequestCarrierClass.requestDate = new Date();
        plannedRequestCarrierClass.procedureList = this.procedureList;
        this.procedureRequestSharedService.setPlannedRequests(plannedRequestCarrierClass);
    }
    public subscription: any;
    public procReqLoaded: boolean = false;
    async ngOnInit() {
        this.subscription = this.procedureRequestSharedService.onProcedureRequestFormLoaded.subscribe(p => {
            debugger
            this.procReqLoaded = true;            
            this.subscription.unsubscribe();
        });
        await this.load();
    }

    public onCureStartDateChanged(event): void {
        if (this._ChemotherapyRadiotherapy != null && this._ChemotherapyRadiotherapy.CureStartDate != event) {
            this._ChemotherapyRadiotherapy.CureStartDate = event;
        }
    }

    public onEtkinMaddeChanged(event): void {
        if (event != null) {
            if (this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol != null && this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.EtkinMadde != event) {
                this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.EtkinMadde = event;
            }
        }
    }

    public onpatientHeightChanged(event: any) {
        this.calculatePatientBodyValues();
    }

    public onpatientWeightChanged(event: any) {
        this.calculatePatientBodyValues();
    }

    public closeProcedurePlanningFormPopUp(event: boolean = null) {
        this.showProcedurePlanningForm = false;
    }

    public calculatePatientBodyValues() {
        if (this.chemotherapyRadiotherapyFormViewModel.patientHeight != null && this.chemotherapyRadiotherapyFormViewModel.patientWeight != null) {
            let height = this.chemotherapyRadiotherapyFormViewModel.patientHeight;      //cm
            let weight = this.chemotherapyRadiotherapyFormViewModel.patientWeight;      //kg
            let VyaVal = 0.00718 * (height ** (0.725)) * (weight ** (0.425));
            let VsmVal = 2.447 + (0.3362 * weight) + (0.1074 * height) - (0.09516 * this.chemotherapyRadiotherapyFormViewModel.patientAge);
            this.patientVki = Number((weight / ((height / 100) ** 2)).toFixed(2)).toString();
            this.patientVya = Number(VyaVal.toString()).toFixed(2).toString();
            this.patientVsm = Number(VsmVal.toString()).toFixed(2).toString();
        }
    }

    public async completeProtocolDetail(event) {
        this.IsDetailComplete = true;
        let updateClass = new UpdateChemoRadioOrderDetail();
        updateClass.ObjectID = event.data.ObjectID;
        updateClass.isCompleted = true;
        if (event.data.isRadiotherapy == false) {
            if (String.isNullOrEmpty(event.data.Store)) {
                this.showDetailStorePopUp = true;
                let selectVal = await this.subscribeSelectStoreButton();
                if (selectVal == 1) {
                    updateClass.store = this.popUpSelectedStore;
                    updateClass.description = this.popUpDescription;
                }
            }
        }

        let fullApiUrl: string = 'api/ChemotherapyRadiotherapyService/UpdateChemoRadioOrderDetail';
        this.httpService.post(fullApiUrl, updateClass).then((res: boolean) => {
            if (res == true) {
                this.messageService.showInfo("İşlem Başarıyla Tamamlandı");
                this.load();
            } else {
                this.messageService.showError("Bir hata ile karşılaşıldı");
            }
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });

    }
    public async stopProtocolDetail(event) {
        this.IsDetailComplete = false;
        let updateClass = new UpdateChemoRadioOrderDetail();
        updateClass.ObjectID = event.data.ObjectID;
        updateClass.isAborted = true;
        let selectVal = await this.subscribeSelectStoreButton();
        if (selectVal == 1) {
            updateClass.description = this.popUpDescription;
        }

        let fullApiUrl: string = 'api/ChemotherapyRadiotherapyService/UpdateChemoRadioOrderDetail';
        this.httpService.post(fullApiUrl, updateClass).then((res: boolean) => {
            if (res == true) {
                this.messageService.showInfo("İşlem Başarıyla Tamamlandı");
                this.load();
            } else {
                this.messageService.showError("Bir hata ile karşılaşıldı");
            }
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }
    public async cancelProtocolDetail(event) {
        this.IsDetailComplete = false;

        let updateClass = new UpdateChemoRadioOrderDetail();
        updateClass.ObjectID = event.data.ObjectID;
        updateClass.isCancelled = true;
        let selectVal = await this.subscribeSelectStoreButton();

        if (selectVal == 1) {
            updateClass.description = this.popUpDescription;
        }
        let fullApiUrl: string = 'api/ChemotherapyRadiotherapyService/UpdateChemoRadioOrderDetail';
        this.httpService.post(fullApiUrl, updateClass).then((res: boolean) => {
            if (res == true) {
                this.messageService.showInfo("İşlem Başarıyla Tamamlandı");
                this.load();
            } else {
                this.messageService.showError("Bir hata ile karşılaşıldı");
            }
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public async undoProtocolDetail(event) {
        this.IsDetailComplete = false;
        let updateClass = new UpdateChemoRadioOrderDetail();
        updateClass.ObjectID = event.data.ObjectID;
        let selectVal = await this.subscribeSelectStoreButton();

        if (selectVal == 1) {
            updateClass.description = this.popUpDescription;
        }
        updateClass.isUndo = true;


        let fullApiUrl: string = 'api/ChemotherapyRadiotherapyService/UpdateChemoRadioOrderDetail';
        this.httpService.post(fullApiUrl, updateClass).then((res: boolean) => {
            if (res == true) {
                this.messageService.showInfo("İşlem Başarıyla Tamamlandı");
                this.load();
            } else {
                this.messageService.showError("Bir hata ile karşılaşıldı");
            }
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public onRowPrepared(element: any) {
        let j = 0;
        for (j = 0; j < element.columns.length; j++) {
            if (element.columns[j].dataField == "AppliedDate") {
                break;
            }
        }


        let data: ChemoRadioOrderDetailItem = element.data as ChemoRadioOrderDetailItem;
        if (element.rowElement.firstItem() !== undefined && element.rowType !== 'header' &&
            element.rowType !== 'filter' && element.rowElement.firstItem() !== undefined &&
            element.rowElement.firstItem().cells[j] !== undefined) {
            if (data != null) {
                if (data.isAborted == true) {
                    element.rowElement.firstItem().cells[j].bgColor = '#EABA71';
                } else if (data.isCompleted == true) {
                    element.rowElement.firstItem().cells[j].bgColor = '#5CB85C';
                }
            }
        }
    }


    public onChemotherapyApplyMethodChanged(event): void {
        if (event != null) {
            if (this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol != null && this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.ChemotherapyApplyMethod != event) {
                this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.ChemotherapyApplyMethod = event;
                this.ChemotherapyApplySubMethod.ListFilterExpression = " CHEMOTHERAPYAPPLYMETHOD='" + this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.ChemotherapyApplyMethod.ObjectID.toString() + "'";
            }
        }
        else {
            this.ChemotherapyApplySubMethod.ListFilterExpression = "";
        }
    }

    public onChemotherapyApplySubMethodChanged(event): void {
        if (event != null) {
            if (this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol != null
                && this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.ChemotherapyApplyMethod != null
                && this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.ChemotherapyApplySubMethod != event) {
                this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.ChemotherapyApplySubMethod = event;
            }
        }
    }

    public onChemoRadioTypeValueChanged(event): void {
        if (event.value != null) {
            if (this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol != null) {
                this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.IsRadiotherapyCure = false;
                this.chemotherapyRadiotherapyFormViewModel.chemoRadioProcedure = null
            }
            if (event.value.id == "1") {
                this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.IsRadiotherapyCure = true;
            }

        }
    }

    protected async PreScript() {
        super.PreScript();
        this.AddHelpMenu();
    }
    public ngOnDestroy() {
        this.RemoveMenuFromHelpMenu();

    }
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let planProcedure = new DynamicSidebarMenuItem();
        planProcedure.key = 'planProcedure';
        planProcedure.icon = 'fa fa-plus';
        planProcedure.label = 'İstem Planlama Ekranı';
        planProcedure.componentInstance = this;
        planProcedure.clickFunction = this.showPlannedProcedureRequestForm;
        planProcedure.parameterFunctionInstance = this;
        planProcedure.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', planProcedure);

        let addProcedure = new DynamicSidebarMenuItem();
        addProcedure.key = 'addProcedure';
        addProcedure.icon = 'fa fa-plus';
        addProcedure.label = 'Hizmet Ekle';
        addProcedure.componentInstance = this;
        addProcedure.clickFunction = this.showProcedureForm;
        addProcedure.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        addProcedure.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', addProcedure);

        let addMaterial = new DynamicSidebarMenuItem();
        addMaterial.key = 'addMaterial';
        addMaterial.icon = 'fa fa-plus';
        addMaterial.label = 'Malzeme Ekle';
        addMaterial.componentInstance = this;
        addMaterial.clickFunction = this.showMaterialForm;
        addMaterial.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        addMaterial.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', addMaterial);

        let radiologyHistory = new DynamicSidebarMenuItem();
        radiologyHistory.key = 'radiologyHistory';
        radiologyHistory.icon = 'glyphicon glyphicon-cd';
        radiologyHistory.label = 'Radyoloji Sonuçları';
        radiologyHistory.componentInstance = this.helpMenuService;
        radiologyHistory.clickFunction = this.helpMenuService.openRadiologyHistory;
        radiologyHistory.parameterFunctionInstance = this;
        radiologyHistory.getParamsFunction = this.getClickFunctionParamsForChemotherapy;
        radiologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', radiologyHistory);

        let pathologyHistory = new DynamicSidebarMenuItem();
        pathologyHistory.key = 'pathologyHistory';
        pathologyHistory.icon = 'fas fa-notes-medical';
        pathologyHistory.label = 'Patoloji Sonuçları';
        pathologyHistory.componentInstance = this.helpMenuService;
        pathologyHistory.clickFunction = this.helpMenuService.openPathologyHistory;
        pathologyHistory.parameterFunctionInstance = this;
        pathologyHistory.getParamsFunction = this.getClickFunctionParamsForChemotherapy;
        pathologyHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', pathologyHistory);

        let testHistory = new DynamicSidebarMenuItem();
        testHistory.key = 'testHistory';
        testHistory.icon = 'fa fa-flask';
        testHistory.label = 'Laboratuvar Sonuçları';
        testHistory.componentInstance = this.helpMenuService;
        testHistory.clickFunction = this.helpMenuService.openTestHistory;
        testHistory.parameterFunctionInstance = this;
        testHistory.getParamsFunction = this.getClickFunctionParamsForChemotherapy;
        testHistory.ParentInstance = this;
        this.sideBarMenuService.addMenu('TahlilTetkikSonuc', testHistory);

    }

    public getClickFunctionParamsForChemotherapy(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this.chemotherapyRadiotherapyFormViewModel._EpisodeActionID, this.chemotherapyRadiotherapyFormViewModel._EpisodeID, this.chemotherapyRadiotherapyFormViewModel._PatientID));
        return clickFunctionParams;
    }

    public showMaterialForm() {
        this.showMaterialPopUp = true;
    }
    public showProcedureForm() {
        this.showProcedurePopUp = true;
    }

    public showPlannedProcedureRequestForm() {
        this.showProcedurePlanningForm = true;
    }

    public RemoveMenuFromHelpMenu() {
        this.sideBarMenuService.removeMenu('addMaterial');
        this.sideBarMenuService.removeMenu('addProcedure');
        this.sideBarMenuService.removeMenu('planProcedure');

    }

    public async treatmentMaterialSelected(event) {
        if (event != null) {
            if (this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol != null && this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.Material != event) {
                this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.Material = event;
            }
        }
    }

    public async radiotherapyXrayTypeSelected(event) {
        if (event != null) {
            if (this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol != null && this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.RadiotherapyXRayTypeDef != event) {
                this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.RadiotherapyXRayTypeDef = event;
            }
        }
    }

    public async radiotherapyProcedureSelected(event) {
        if (event != null) {
            if (this.chemotherapyRadiotherapyFormViewModel != null && this.chemotherapyRadiotherapyFormViewModel.chemoRadioProcedure != event) {
                this.chemotherapyRadiotherapyFormViewModel.chemoRadioProcedure = event;
            }
        }
    }

    public async chemotherapyProcedureSelected(event) {
        if (event != null) {
            if (this.chemotherapyRadiotherapyFormViewModel != null && this.chemotherapyRadiotherapyFormViewModel.chemoRadioProcedure != event) {
                this.chemotherapyRadiotherapyFormViewModel.chemoRadioProcedure = event;
            }
        }
    }

    public async solventSelected(event) {
        if (event != null) {
            if (this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol != null && this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.Solvent != event) {
                this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.Solvent = event;
            }
        }
    }

    public onttrichtextboxAciklamaChanged(event): void {
        if (event != null) {
            if (this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol != null && this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.CureDescription != event) {
                this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.CureDescription = event;
            }
        }
    }

    public async AddChemoRadioOrder() {
        let chemoRadioOrderModel = new AddOrUpdateChemoRadioOrder();
        let cureProtocolItem = this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol;
        if (cureProtocolItem.IsRadiotherapyCure == true) {
            if (cureProtocolItem.RadiotherapyXRayTypeDef == null) {
                ServiceLocator.MessageService.showError("Işın Tipi seçmeden protokol ekleyemezsiniz!");
                return;
            }
        } else {
            if (cureProtocolItem.EtkinMadde == null && cureProtocolItem.Material == null) {
                ServiceLocator.MessageService.showError("Etkin Madde veya İlaç seçmeden protokol ekleyemezsiniz!");
                return;
            }
            if (cureProtocolItem.Solvent == null) {
                ServiceLocator.MessageService.showError("Çözücü seçmeden protokol ekleyemezsiniz!");
                return;
            }
            if (cureProtocolItem.DrugDose == null) {
                ServiceLocator.MessageService.showError("İlaç Dozu girmeden protokol ekleyemezsiniz!");
                return;
            }
            if (cureProtocolItem.SolventDose == null) {
                ServiceLocator.MessageService.showError("Çözücü Dozu girmeden protokol ekleyemezsiniz!");
                return;
            }
            if (cureProtocolItem.ChemotherapyApplyMethod == null) {
                ServiceLocator.MessageService.showError("Uygulama şekli seçmeden protokol ekleyemezsiniz!");
                return;
            }
            if (cureProtocolItem.ChemotherapyApplySubMethod == null) {
                ServiceLocator.MessageService.showError("Alt Uygulama Şekli seçmeden protokol ekleyemezsiniz!");
                return;
            }
        }

        if (cureProtocolItem.CureCount == null) {
            ServiceLocator.MessageService.showError("Kür Sayısı girmeden protokol ekleyemezsiniz!");
            return;
        }
        if (cureProtocolItem.PreCureMinute == null) {
            ServiceLocator.MessageService.showError("Tedavi öncesi süre girmeden protokol ekleyemezsiniz!");
            return;
        }
        if (cureProtocolItem.CureTime == null) {
            ServiceLocator.MessageService.showError("Tedavi Süresi girmeden protokol ekleyemezsiniz!");
            return;
        }
        if (cureProtocolItem.AfterCureTime == null) {
            ServiceLocator.MessageService.showError("Tedavi Sonrası Süre girmeden protokol ekleyemezsiniz!");
            return;
        }
        if (this.chemotherapyRadiotherapyFormViewModel.chemoRadioProcedure == null) {
            ServiceLocator.MessageService.showError("Hizmet seçmeden protokol ekleyemezsiniz!");
            return;
        }
        chemoRadioOrderModel.chemoRadioCureProtocol = this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol;
        chemoRadioOrderModel.store = this.chemotherapyRadiotherapyFormViewModel.selectedStore;
        chemoRadioOrderModel.procedureObject = this.chemotherapyRadiotherapyFormViewModel.chemoRadioProcedure;
        let fullApiUrl: string = 'api/ChemotherapyRadiotherapyService/AddOrUpdateChemoRadioOrder';
        this.httpService.post(fullApiUrl, chemoRadioOrderModel).then((res: boolean) => {
            if (res == true) {
                this.messageService.showInfo("Protokol Başarıyla Oluşturuldu.");
                this.load();
            } else {
                this.messageService.showError("Protokol Oluşturulurken bir hata ile karşılaşıldı");
            }
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });

    }
    async saveFormData(event: FormSaveInfo) {
        if (this.chemotherapyRadiotherapyFormViewModel.patientHeight != null && +this.chemotherapyRadiotherapyFormViewModel.patientHeight < 0) {
            this.messageService.showError("Hasta boyu sıfırdan küçük olamaz.");
            return;
        }
        if (this.chemotherapyRadiotherapyFormViewModel.patientWeight != null && +this.chemotherapyRadiotherapyFormViewModel.patientWeight < 0) {
            this.messageService.showError("Hasta kilosu sıfırdan küçük olamaz.");
            return;
        }
        let returnValue: number;
        returnValue = await this.requestedProceduresFormInstance.fireRequestedProceduresActions(this.chemotherapyRadiotherapyFormViewModel._ChemotherapyRadiotherapy);
        if (returnValue != null)
            await this.save(event);
    }

    async subscribeSelectStoreButton() {

        let that = this;
        this.showDetailStorePopUp = true;

        return new Promise((resolve, reject) => {
            let btnSaveRepetition;
            let btnHayirSub;
            window.setTimeout(() => {
                btnSaveRepetition = that.btnSelectStore.onClick.subscribe(async t => {
                    if (this.IsDetailComplete) {
                        if (this.popUpSelectedStore != null) {
                            this.showDetailStorePopUp = false;
                            resolve(1);
                        }
                        else {
                            ServiceLocator.MessageService.showError("Tekrar İstem Gerekçesi seçmeden devam edemezsiniz.!");
                        }
                    } else {
                        if (!String.isNullOrEmpty(this.popUpDescription)) {
                            this.showDetailStorePopUp = false;
                            resolve(1);
                        }
                        else {
                            ServiceLocator.MessageService.showError("Durdurma/İptal Açıklaması girmeden devam edemezsiniz.!");
                        }
                    }


                })
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

    public createUserProtocolTemplate(event) {
        this.templateProtocol = event.data as ChemoRadioOrderDetailItem;
        this.showAddUserTemplatePopUp = true;

    }

    async AddUserTemplate(): Promise<void> {
        try {
            if (this.userTemplateName != null || (this.userTemplateName != null && !this.userTemplateName.toString().isNullOrEmpty())) {
                let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

                savedUserTemplate.Description = this.userTemplateName;
                savedUserTemplate.TAObjectDefID = this.templateProtocol.OrderObject.ObjectDefID;
                savedUserTemplate.TAObjectID = this.templateProtocol.OrderObject.ObjectID;

                let apiUrl: string = 'api/ChemotherapyRadiotherapyService/SaveProtocolUserTemplate';
                this.loadPanelOperation(true, 'Şablon Kaydediliyor, Lütfen Bekleyiniz');
                await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                    this.chemotherapyRadiotherapyFormViewModel.userTemplateList = result;
                    this.templateProtocol = null;
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
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }

    async SelectUserTemplate(event: any): Promise<void> {
        if (event.itemData != null) {

            if (event.itemData.ObjectID != null) {
                this.loadPanelOperation(true, 'Şablon Yükleniyor, Lütfen Bekleyiniz');

                let apiUrl: string = 'api/ChemotherapyRadiotherapyService/GetProtocolItemByTemplate?templateId=' + event.itemData.ObjectID.toString();
                await this.httpService.get<GetTemplateCureProtocolItem>(apiUrl).then(result => {
                    let templateCureProtocol = result as GetTemplateCureProtocolItem;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.AfterCureTime = templateCureProtocol.cureProtocol.AfterCureTime;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.CureCount = templateCureProtocol.cureProtocol.CureCount;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.CureDescription = templateCureProtocol.cureProtocol.CureDescription;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.CureTime = templateCureProtocol.cureProtocol.CureTime;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.DrugDose = templateCureProtocol.cureProtocol.DrugDose;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.IsRadiotherapyCure = templateCureProtocol.cureProtocol.IsRadiotherapyCure;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.PreCureMinute = templateCureProtocol.cureProtocol.PreCureMinute;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.RepetitiveDayCount = templateCureProtocol.cureProtocol.RepetitiveDayCount;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.SolventDose = templateCureProtocol.cureProtocol.SolventDose;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.Material = templateCureProtocol.Material;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.EtkinMadde = templateCureProtocol.EtkinMadde;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.ChemotherapyApplyMethod = templateCureProtocol.ApplyMethod;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.ChemotherapyApplySubMethod = templateCureProtocol.ApplySubMethod;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.RadiotherapyXRayTypeDef = templateCureProtocol.RadiotherapyXRayTypeDef;
                    this.chemotherapyRadiotherapyFormViewModel.lastSelectedCureProtocol.Solvent = templateCureProtocol.Solvent;
                    ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Yüklendi");
                });

                this.loadPanelOperation(false, '');
                //this.onProcedureDoctorChanged(this.participationFreeDrugReportNewFormViewModel._ParticipatnFreeDrugReport.ProcedureDoctor);
            }
        }

    }

    public selectStoreChange() {
        //this.setTreatmentMaterialFilterExpression(this.chemotherapyRadiotherapyFormViewModel.selectedStore);
    }

    async setTreatmentMaterialFilterExpression(store: Store) {
        let filterString: string = '""';
        if (store) {
            // set edilen depoya göre Malzeme listesinin filtrelenmesi            
            filterString = 'THIS.OBJECTDEFNAME IN (\'CONSUMABLEMATERIALDEFINITION\',\'DRUGDEFINITION\') ';
            //if (!((await SystemParameterService.GetParameterValue("WORKWITHOUTSTOCK", "FALSE")) === "TRUE")) {

            filterString = filterString + ' AND STOCKS.INHELD>0';

            //}
            this.TreatmentMaterial.ListFilterExpression = filterString;
        } else {

        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.CureStartDate, "Value", this.__ttObject, "CureStartDate");
    }

    public initFormControls(): void {
        this.labelCureStartDate = new TTVisual.TTLabel();
        this.labelCureStartDate.Text = "Tedavi Başlangıç Tarihi";
        this.labelCureStartDate.Name = "labelCureStartDate";
        this.labelCureStartDate.TabIndex = 1;

        this.CureStartDate = new TTVisual.TTDateTimePicker();
        this.CureStartDate.Format = DateTimePickerFormat.Long;
        this.CureStartDate.Name = "CureStartDate";
        this.CureStartDate.TabIndex = 0;

        this.EtkinMaddeList = new TTVisual.TTObjectListBox();
        this.EtkinMaddeList.ListDefName = "EtkinMaddeListDefinition";
        this.EtkinMaddeList.Name = "EtkinMAddeList";
        this.EtkinMaddeList.AutoCompleteDialogWidth = "500px";

        this.ChemotherapyApplyMethod = new TTVisual.TTObjectListBox();
        this.ChemotherapyApplyMethod.ListDefName = "ChemotherapyApplyMethodListDef";
        this.ChemotherapyApplyMethod.Name = "ChemotherapyApplyMethod";
        this.ChemotherapyApplyMethod.TabIndex = 30;

        this.ChemotherapyApplySubMethod = new TTVisual.TTObjectListBox();
        this.ChemotherapyApplySubMethod.ListDefName = "ChemotherapyApplySubMethodListDef";
        this.ChemotherapyApplySubMethod.Name = "ChemotherapyApplySubMethod";
        this.ChemotherapyApplySubMethod.TabIndex = 30;

        this.TreatmentMaterial = new TTVisual.TTObjectListBox();
        this.TreatmentMaterial.ListDefName = 'DrugList';
        this.TreatmentMaterial.Name = 'TreatmentMaterial';
        this.TreatmentMaterial.AutoCompleteDialogHeight = '150';
        this.TreatmentMaterial.AutoCompleteDialogWidth = '50%';

        this.RadiotherapyXrayDef = new TTVisual.TTObjectListBox();
        this.RadiotherapyXrayDef.ListDefName = 'RadiotherapyXrayTypeListDef';
        this.RadiotherapyXrayDef.Name = 'RadiotherapyXrayDef';
        this.RadiotherapyXrayDef.AutoCompleteDialogHeight = '150';
        this.RadiotherapyXrayDef.AutoCompleteDialogWidth = '50%';

        this.ChemotherapyProcedure = new TTVisual.TTObjectListBox();
        this.ChemotherapyProcedure.ListDefName = 'ProcedureListDefinition';
        this.ChemotherapyProcedure.Name = 'ChemotherapyProcedure';
        this.ChemotherapyProcedure.AutoCompleteDialogHeight = '150';
        this.ChemotherapyProcedure.AutoCompleteDialogWidth = '50%';
        this.ChemotherapyProcedure.ListFilterExpression = "CODE IN ('704691','704692','704693')";

        this.RadiotherapyProcedure = new TTVisual.TTObjectListBox();
        this.RadiotherapyProcedure.ListDefName = 'ProcedureListDefinition';
        this.RadiotherapyProcedure.Name = 'ChemoRadioProcedure';
        this.RadiotherapyProcedure.AutoCompleteDialogHeight = '150';
        this.RadiotherapyProcedure.AutoCompleteDialogWidth = '50%';
        this.RadiotherapyProcedure.ListFilterExpression = "CODE IN ('800330','800340','800350','800360','800370','800380','800390','800400','800410','800420','800430','800440','800450','800460','800470','800480','800490','800500','800510','800520','800530','800540','800550','800560','800570','800580','800590','800600','800610','800615','800616')";

        this.Controls = [this.labelCureStartDate, this.ChemotherapyApplyMethod, this.ChemotherapyApplySubMethod, this.CureStartDate, this.EtkinMaddeList];

    }


}
