//$51CD9FC5
import { Component, OnInit, ViewChild } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SystemApiService } from "Fw/Services/SystemApiService";
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { MainProcedureFormViewModel } from './MainProcedureFormViewModel';
import { ProcedureDefinition, SubProcedureDefinition, MedulaSUTGroupEnum, LaboratoryTestDefinition, ProcedureDefGroupEnum, RequiredDiagnoseProcedure } from 'app/NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinitionList } from 'Modules/Tibbi_Surec/Fizyoterapi_Modulu/PhysiotherapyOrderRequestFormViewModel';
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'MainProcedureForm',
    templateUrl: './MainProcedureForm.html',
    providers: [MessageService, SystemApiService]
})
export class MainProcedureForm extends TTVisual.TTForm implements OnInit {
    public deneme: string = "";
    public componentInfo: DynamicComponentInfo;
    public componenModel: any;
    public mainProcedureFormViewModel: MainProcedureFormViewModel = new MainProcedureFormViewModel();
    public hideDynamicComponent = false;
    public searchType: number;
    public procedureTypeEnabled = true;

    DiagnosisDefinitionRequiredDiagnoseProcedure: TTVisual.ITTListBoxColumn;
    GridRequiredDiagnosis: TTVisual.ITTGrid;
    ttlabel13: TTVisual.ITTLabel;
    public GridRequiredDiagnosisColumns = [];
    //public DiagnosisDefinitions: Array<DiagnosisDefinition>;

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    @ViewChild('subProcedureGrid') subProcedureGrid: DxDataGridComponent;
    @ViewChild('requiredDiagnosisGrid') requiredDiagnosisGrid: DxDataGridComponent;


    @ViewChild('gridProcedureDefinition') gridProcedureDefinition: DxDataGridComponent;
    leftSideGridDataSource: DataSource;
    subProcedureDefGridDataSource: DataSource;
    diagnosisDefinitionsDataSource: DataSource;



    subProcedureGridColumn = [];
    requiredDiagnosisGridColumn = [];

    public procedureDefInfo: any;
    public procedureGridSelectedRowKeys: Array<any> = new Array<any>();
    //SUT tablosundaki fiyat kodu
    //SUT tablosundaki fiyat kodu
    public actualSUTName: string;
    public sutRuleEngineVisible = false;
    public sutPricingUpdateVisible = false;

    constructor(protected httpService: NeHttpService, protected messageService: MessageService,
        protected reportService: AtlasReportService,
        private systemApiService: SystemApiService) {
        super('', '');
        this.initFormControls();
    }

    async ngOnInit() {

        this.sutRuleEngineVisible = ServiceLocator.ActiveUserService.ActiveUser.IsSuperUser;
        this.sutPricingUpdateVisible = ServiceLocator.ActiveUserService.ActiveUser.IsSuperUser;
        this.surgeryControl = false;
        let that = this;

        this.leftSideGridDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",

                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchType: that.searchType,
                        definitionName: 'GetProcedureDefinitionListDefinition'
                    }

                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 50;
                    }

                    return await this.httpService.post<any>("/api/ProcedureDefinitionService/GetProcedureDefinitionList", loadOptions);

                },
            }),
            paginate: true,
            pageSize: 50
        });



        this.mainProcedureFormViewModel._ProcedureDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();



        this.mainProcedureFormViewModel._ProcedureDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>();

        this.subProcedureDefGridDataSource = new DataSource({
            store: new CustomStore({

                byKey: (key: string) => {
                    return this.httpService.post<any>("/api/ProcedureDefinitionService/GetSubProcedureDefinitions?key=" + key, null);
                },
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'GetProcedureDefinitionListDefinition',
                    }

                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 50;
                    }

                    return this.httpService.post<any>("/api/ProcedureDefinitionService/GetSubProcedureDefinitions", loadOptions);

                },
            },



            ),
            paginate: true,
            pageSize: 50
        });


        this.diagnosisDefinitionsDataSource = new DataSource({
            store: new CustomStore({

                byKey: (key: string) => {
                    return this.httpService.post<any>("/api/ProcedureDefinitionService/GetDiagnosisDefinitions?key=" + key, null);
                },
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'GetDiagnosisDefinitionListDefinition',

                    }

                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 50;
                    }

                    return this.httpService.post<any>("/api/ProcedureDefinitionService/GetDiagnosisDefinitions", loadOptions);

                },
            },



            ),
            paginate: true,
            pageSize: 50
        });

        this.GenerateDeathResonColums();

    }

    GenerateDeathResonColums(): void {
        let that = this;
        this.subProcedureGridColumn = [
            {
                caption: "Hizmet",
                //dataField: 'ChildProcedureDefinition.ObjectID',
                fixed: true, width: '75%',
                //allowSorting: false,
                //allowEditing: true,
                cellTemplate: 'subProcedureTemplate',


                //dataSource: that.subProcedureDefGridDataSource, valueExpr: 'ObjectID', displayExpr: 'Name'

            }, {
                caption: "Miktar",
                dataField: 'Amount',
                fixed: true, width: '15%',
                // allowSorting: false,
                // allowEditing: true
            }, {
                caption: "Sil",
                cellTemplate: 'buttonCellTemplate',
                // dataField: 'Amount',
                fixed: true, width: '15%',
                // allowSorting: false,
                // allowEditing: true
            }
        ];

        this.requiredDiagnosisGridColumn = [
            {
                caption: "Zorunlu Tanı",
                //dataField: 'ChildProcedureDefinition.ObjectID',
                fixed: true, width: '75%',
                //allowSorting: false,
                //allowEditing: true,
                cellTemplate: 'requiredDiagnosisTemplate',

            }, {
                caption: "Sil",
                cellTemplate: 'buttonCellTemplate',
                // dataField: 'Amount',
                fixed: true, width: '15%',
                // allowSorting: false,
                // allowEditing: true
            }
        ];
    }


    public surgeryControl: boolean = false;
    public openProcedureForm(objectID, ProcedureTypeID) {
        const that = this;

        let compInfo = new DynamicComponentInfo();
        var inputParam: any;
        this.surgeryControl = false;

        if (ProcedureTypeID == ProcedureDefGroupEnum.tahlilBilgileri) {
            compInfo.ComponentName = 'LaboratoryTestDefinitionNewForm';
            this.hideDynamicComponent = false;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.muayeneBilgisi || ProcedureTypeID == ProcedureDefGroupEnum.konsultasyonBilgileri
            || ProcedureTypeID == ProcedureDefGroupEnum.hastaYatisBilgileri) {
            compInfo.ComponentName = 'ProcedureForm';
            this.hideDynamicComponent = true;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.tetkikveRadyolojiBilgileri) {
            compInfo.ComponentName = 'RadiologyTestDefinitionForm';
            this.hideDynamicComponent = false;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.patolojiBilgileri) {
            compInfo.ComponentName = 'PathologyTestDefinitionForm';
            this.hideDynamicComponent = false;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.nukleerTipbilgileri) {
            compInfo.ComponentName = 'NuclearMedicineTestDefinitionForm';
            this.hideDynamicComponent = false;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.disBilgileri) {
            compInfo.ComponentName = 'DentalTreatmentDefinitionForm';
            this.hideDynamicComponent = false;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.digerIslemBilgileri || ProcedureTypeID == ProcedureDefGroupEnum.ameliyatveGirisimBilgileri) {
            compInfo.ComponentName = 'SurgeryDefinitionForm';
            this.hideDynamicComponent = false;
            // inputParam["ProcedureType"]=ProcedureTypeID;
            this.surgeryControl = true;

        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.ortezProtezBilgisi) {
            compInfo.ComponentName = 'OrtesisProsthesisDefinitionForm';
            this.hideDynamicComponent = false;
            // inputParam["ProcedureType"]=ProcedureTypeID;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.fizikselTipBilgisi) {
            compInfo.ComponentName = 'PhysiotherapyDefinitionForm';
            this.hideDynamicComponent = false;
            // inputParam["ProcedureType"]=ProcedureTypeID;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.estetikveAlternatifBilgisi) {
            compInfo.ComponentName = 'EstheticAlternativeProcedureDefinitionForm';
            this.hideDynamicComponent = true;
            // inputParam["ProcedureType"]=ProcedureTypeID;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.diyalizIslemBilgisi) {
            compInfo.ComponentName = 'DialysisDefinitionForm';
            this.hideDynamicComponent = false;
            // inputParam["ProcedureType"]=ProcedureTypeID;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.disProtezBilgileri) {
            compInfo.ComponentName = 'DentalProsthesisDefinitionForm';
            this.hideDynamicComponent = false;
            // inputParam["ProcedureType"]=ProcedureTypeID;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.kanBilgileri) {
            compInfo.ComponentName = 'BloodBankTestDefinitionForm';
            this.hideDynamicComponent = false;
            // inputParam["ProcedureType"]=ProcedureTypeID;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.vakaBasiBilgileri) {
            compInfo.ComponentName = 'BulletinProcedureDefinitionForm';
            this.hideDynamicComponent = true;
            // inputParam["ProcedureType"]=ProcedureTypeID;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.anestezibilgileri) {
            compInfo.ComponentName = 'AnesthesiaDefinitionForm';
            this.hideDynamicComponent = true;
            // inputParam["ProcedureType"]=ProcedureTypeID;
        }
        else if (ProcedureTypeID == ProcedureDefGroupEnum.paketBilgileri) {
            compInfo.ComponentName = 'PackageProcedureDefinitionForm';
            this.hideDynamicComponent = false;
            // inputParam["ProcedureType"]=ProcedureTypeID;
        }
        else {
            this.messageService.showInfo("Bu hizmet türü için tanım ekranı henüz oluşturulmamış.\n Lütfen manager ekranlarını kullanın");
            return null;
        }
        compInfo.ModuleName = 'HizmetTanimlamaModule';
        compInfo.ModulePath = '/Modules/Merkezi_Yonetim_Sistemi/Tibbi_Surec_Tanim/Hizmet_Tanimlama_Modulu/HizmetTanimlamaModule';
        compInfo.objectID = objectID;
        compInfo.InputParam = ProcedureTypeID;
        this.componentInfo = compInfo;

        //     this.systemApiService.open("ad0eeaaa-f33b-4255-a1e7-ac90b593e63c", "PROCEDUREDEFINITION", "77d576d2-5ef5-4462-a9ea-da15c2c35966", null).then(x => {
        //         alert(x.ComponentName);
        // });
        // this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
        //     //this.selectedEpisodeActionId = c.ParentObjectID.toString();
        // });
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public onNameResourceChanged($event) {
        // console.log("$event");
    }

    public onGridRowClick($event) {

        this.loadProcedure($event.data)
        // this.TTObjectToModel();
    }

    public loadProcedure(data: any) {
        let ProcedureTypeID = data.Proceduretypeid;
        this.procedureDefInfo = data;
        this.openProcedureForm(data.ObjectID, ProcedureTypeID);
    }

    public onInitSubProcedureGridNewRow(event) {
        event.data.ChildProcedureDefinition = new ProcedureDefinition();
    }


    public onInitRequiredDiagnosisGridNewRow(event) {

        event.data.DiagnosisDefinition = new RequiredDiagnoseProcedure();
    }

    public showData: boolean = true;

    public onChildProcedureValueChanged(e, row) {
        console.log(e);
        // row.data.ChildProcedureDefinition=
    }

    public onRowInserting(e) {
        console.log(e);
        // e.data = new SubProcedureDefinition();
        // e.data.ChildProcedureDefinition = new ProcedureDefinition();
        // e.data.ChildProcedureDefinition= e.data.ChildProcedureDefinition.ObjectID;
    }

    public procedurePriceViewModelLoaded(event: any) {
        this.actualSUTName = event.SUTName;
    }

    public TTObjectToModel() {
        this.mainProcedureFormViewModel._ProcedureDefinition = this.componenModel.instance._TTObject;

        if (this.mainProcedureFormViewModel._ProcedureDefinition.SubProcedureDefinitions == undefined)
            this.mainProcedureFormViewModel._ProcedureDefinition.SubProcedureDefinitions = new Array<SubProcedureDefinition>();


        if (this.mainProcedureFormViewModel._ProcedureDefinition.RequiredDiagnoseProcedures == undefined)
            this.mainProcedureFormViewModel._ProcedureDefinition.RequiredDiagnoseProcedures = new Array<RequiredDiagnoseProcedure>();
    }

    public onComponentCreated(e: any): void {
        console.log(e);
        this.componenModel = e;//TTboundForm yapılabilir

        //  if(this.componenModel.instance.ObjectID != undefined)//gridden açıldı ise
        //     this.TTObjectToModel();
    }

    public dynamicComponentLoaded($event) {
        console.log($event);

        if (this.componenModel.instance._TTObject.IsNew == false)//gridden açıldı ise
        {
            this.TTObjectToModel();
            this.procedureTypeEnabled = false;//kaydedilmiş bir hizmetin türü değişmez. Silip veya pasife alıp yeni tanımlanmalı
        }
        else
            this.procedureTypeEnabled = true;
        // this.TTObjectToModel();
    }

    public clearForm() {
        this.procedureTypeEnabled = true;
        this.componenModel = null;
        this.componentInfo = null;
        this.procedureDefInfo = null;
        this.actualSUTName = null;
        this.mainProcedureFormViewModel = new MainProcedureFormViewModel();
    }

    public async saveClick() {

        try {
            if (this.mainProcedureFormViewModel._ProcedureDefinition.ProcedureType == null) {
                this.messageService.showInfo("Hizmet Türü alanı boş bırakılamaz.");
                return null;

            }

            this.loadPanelOperation(true, "İşlemler kaydediliyor, lütfen bekleyiniz.");

            if (this.componenModel.instance._TTObject.constructor.name == "ProcedureDefinition") {
                this.componenModel.instance._TTObject = <ProcedureDefinition>this.mainProcedureFormViewModel._ProcedureDefinition;
                this.componenModel.instance._ViewModel._ProcedureDefinition = <ProcedureDefinition>this.mainProcedureFormViewModel._ProcedureDefinition;
                // this.componenModel.instance._ProcedureDefinition = <ProcedureDefinition>this.mainProcedureFormViewModel._ProcedureDefinition;
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "LaboratoryTestDefinition") {

                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {
                    console.log('item=' + item);
                    console.log('_ProcedureDefinition=' + this.mainProcedureFormViewModel._ProcedureDefinition[item]);
                    console.log('item=' + item);
                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._LaboratoryTestDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
                // console.log(this.mainProcedureFormViewModel._ProcedureDefinition)
                // console.log(this.componenModel.instance._TTObject)

            }
            else if (this.componenModel.instance._TTObject.constructor.name == "RadiologyTestDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._RadiologyTestDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "PathologyTestDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._PathologyTestDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "NuclearMedicineTestDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._NuclearMedicineTestDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "DentalTreatmentDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._DentalTreatmentDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "SurgeryDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._SurgeryDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "OrtesisProsthesisDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._OrtesisProsthesisDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "PhysiotherapyDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._PhysiotherapyDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "EstheticAlternativeProcedureDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._EstheticAlternativeProcedureDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "DialysisDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._DialysisDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "DentalProsthesisDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._DentalProsthesisDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            // this.componenModel.instance._BloodBankTestDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "BloodBankTestDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._BloodBankTestDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "BulletinProcedureDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._BulletinProcedureDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "AnesthesiaDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._AnesthesiaDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else if (this.componenModel.instance._TTObject.constructor.name == "PackageProcedureDefinition") {
                for (let item in this.mainProcedureFormViewModel._ProcedureDefinition) {

                    if (this.mainProcedureFormViewModel._ProcedureDefinition.hasOwnProperty(item) && item != "__type__") {
                        try {
                            this.componenModel.instance._TTObject[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                            this.componenModel.instance._ViewModel._PackageProcedureDefinition[item] = this.mainProcedureFormViewModel._ProcedureDefinition[item];
                        } catch (error) {
                            // console.log(item);
                            // console.log(error);
                        }

                    }
                }
            }
            else {
                this.messageService.showInfo("Bu hizmet türü için tanım ekranı henüz oluşturulmamış.\n Lütfen manager ekranlarını kullanın")
                this.loadPanelOperation(false, '');
                return null;
            }
            await this.componenModel.instance.save();

            await this.leftSideGridDataSource.reload();
            let newData = this.gridProcedureDefinition.instance.getDataSource().items().find(x => x.ObjectID == this.componenModel.instance._TTObject.ObjectID);
            this.gridProcedureDefinition.instance.selectRows([newData.ObjectID], false)
            this.loadProcedure(newData);
            this.loadPanelOperation(false, '');

        } catch (error) {
            this.loadPanelOperation(false, '');
        }

    }

    public initFormControls(): void {
        this.Controls = [];
    }

    public onMedulaProcedureTypeChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.MedulaProcedureType != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.MedulaProcedureType = event;

            // this.searchType = this.mainProcedureFormViewModel._ProcedureDefinition.MedulaProcedureType;
            // this.leftSideGridDataSource.reload();
            // this.searchType=null;
        }

    }

    public onNameChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.Name != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.Name = event;
        }
    }

    public onCodeChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.Code != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.Code = event;
        }
    }

    public onControlDayCountChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ControlDayCount != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ControlDayCount = event;
        }
    }

    public onInpatientDayCountChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.InpatientDayCount != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.InpatientDayCount = event;
        }
    }

    public onDailyDayCountChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.DailyDayCount != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.DailyDayCount = event;
        }
    }

    public onIsActiveChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.IsActive != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.IsActive = event;
        }
    }

    public onChargableChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.Chargable != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.Chargable = event;
        }
    }

    public onQuickEntryAllowedChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.QuickEntryAllowed != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.QuickEntryAllowed = event;
        }
    }

    public onReportSelectionRequiredChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ReportSelectionRequired != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ReportSelectionRequired = event;
        }
    }

    public onIsDescriptionNeededChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.IsDescriptionNeeded != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.IsDescriptionNeeded = event;
        }
    }

    public onParticipationProcedureChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ParticipationProcedure != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ParticipationProcedure = event;
        }
    }

    public onPathologyOperationNeededChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.PathologyOperationNeeded != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.PathologyOperationNeeded = event;
        }
    }

    public onProcedureTypeChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ProcedureType != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ProcedureType = event;

            this.openProcedureForm(null, this.mainProcedureFormViewModel._ProcedureDefinition.ProcedureType.Value);
        }
    }

    public onQualifiedMedicalProcessChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.QualifiedMedicalProcess != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.QualifiedMedicalProcess = event;
        }
    }

    public ontxtSUTCodeChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.SUTCode != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.SUTCode = event;
        }
    }

    public onHUVCodeChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.HUVCode != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.HUVCode = event;
        }
    }

    public ontxtGILCodeChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.GILCode != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.GILCode = event;
        }
    }

    public onSUTAppendixChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.SUTAppendix != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.SUTAppendix = event;
        }
    }

    public onSUTPointChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.SUTPoint != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.SUTPoint = event;
        }
    }

    public onHUVPointChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.HUVPoint != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.HUVPoint = event;
        }
    }

    public ontxtGILPointChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.GILPoint != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.GILPoint = event;
        }
    }

    public onDescriptionChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.Description != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.Description = event;
        }
    }

    public onDoctorListBoxChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.Doctor != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.Doctor = event;
        }
    }

    public onDontBlockInvoiceChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.DontBlockInvoice != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.DontBlockInvoice = event;
        }
    }

    public onEmergencyDayCountChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.EmergencyDayCount != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.EmergencyDayCount = event;
        }
    }

    public onExaminationDayCountChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ExaminationDayCount != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ExaminationDayCount = event;
        }
    }

    public onExternalOperationChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ExternalOperation != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ExternalOperation = event;
        }
    }

    public onForbiddenForControlChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ForbiddenForControl != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ForbiddenForControl = event;
        }
    }

    public onForbiddenForDailyChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ForbiddenForDaily != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ForbiddenForDaily = event;
        }
    }

    public onForbiddenForEmergencyChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ForbiddenForEmergency != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ForbiddenForEmergency = event;
        }
    }

    public onForbiddenForExaminationChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ForbiddenForExamination != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ForbiddenForExamination = event;
        }
    }

    public onForbiddenForInpatientChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ForbiddenForInpatient != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ForbiddenForInpatient = event;
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.ProcedureTree != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.ProcedureTree = event;
        }
    }

    public onGILDefinitionChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.GILDefinition != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.GILDefinition = event;
        }
    }

    public onPackageProcedureChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.PackageProcedure != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.PackageProcedure = event;
        }
    }

    public onIsResultNeededChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.IsResultNeeded != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.IsResultNeeded = event;
        }
    }

    public onIsVisibleChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.IsVisible != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.IsVisible = event;
        }
    }
    public onRightLeftInfoNeededChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.RightLeftInfoNeeded != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.RightLeftInfoNeeded = event;
        }
    }
    public onRepetitionQueryNeededChanged(event): void {
        if (this.mainProcedureFormViewModel._ProcedureDefinition != null && this.mainProcedureFormViewModel._ProcedureDefinition.RepetitionQueryNeeded != event) {
            this.mainProcedureFormViewModel._ProcedureDefinition.RepetitionQueryNeeded = event;
        }
    }


    public onSubProcedureRemoving(event) {
        if (event != null) {

            if (event.data != null) {
                if (event.data.IsNew) {
                    this.subProcedureGrid.instance.deleteRow(event.rowIndex);
                }
                else
                    event.data.EntityState = EntityStateEnum.Deleted;
                this.subProcedureGrid.instance.filter(['EntityState', '<>', 1]);
                this.subProcedureGrid.instance.refresh();
            }
        }
    }

    public onRequiredDiagnosisGridRemoving(event) {
        if (event != null) {

            if (event.data != null) {
                if (event.data.IsNew) {
                    this.requiredDiagnosisGrid.instance.deleteRow(event.rowIndex);
                }
                else
                    event.data.EntityState = EntityStateEnum.Deleted;
                this.requiredDiagnosisGrid.instance.filter(['EntityState', '<>', 1]);
                this.requiredDiagnosisGrid.instance.refresh();
            }
        }
    }

    public displayExprOfRiquiredDiagnosisGrid(row) {
        if (row)
            return row.Code + "-" + row.Name;
        return "";

    }
}


