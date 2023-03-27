//$964DD946
import { Component, ViewChild, OnInit, NgZone, QueryList, ViewChildren } from '@angular/core';
import { PhysiotherapyOrderRequestFormViewModel, PhysiotherapyOrderComponentInfoViewModel, PhysiotherapyOrderInfo } from './PhysiotherapyOrderRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PhysiotherapyOrder, Common } from 'NebulaClient/Model/AtlasClientModel';
import { FTRVucutBolgesi } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyReports } from 'NebulaClient/Model/AtlasClientModel';
import { ResTreatmentDiagnosisUnit } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { PhysiotherapyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { DxTextBoxComponent, DxAccordionComponent, DxSelectBoxComponent } from 'devextreme-angular';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { ModalStateService } from "Fw/Models/ModalInfo";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
//Raporlar için
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { UserTemplateModel } from '../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import List from 'app/NebulaClient/System/Collections/List';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'PhysiotherapyOrderRequestForm',
    templateUrl: './PhysiotherapyOrderRequestForm.html',
    providers: [MessageService]
})
export class PhysiotherapyOrderRequestForm extends TTVisual.TTForm implements OnInit {
    txtProcedureName: TTVisual.ITTTextBox;

    ApplicationArea: TTVisual.ITTTextBox;
    DiagnosisGroupPhysiotherapyReports: TTVisual.ITTTextBox;
    Dose: TTVisual.ITTTextBox;
    Duration: TTVisual.ITTTextBox;
    FTRApplicationAreaDef: TTVisual.ITTObjectListBox;
    FTRApplicationAreaDefPhysiotherapyReports: TTVisual.ITTObjectListBox;
    labelApplicationArea: TTVisual.ITTLabel;
    labelDiagnosisGroupPhysiotherapyReports: TTVisual.ITTLabel;
    labelDose: TTVisual.ITTLabel;
    labelDuration: TTVisual.ITTLabel;
    labelFTRApplicationAreaDef: TTVisual.ITTLabel;
    labelFTRApplicationAreaDefPhysiotherapyReports: TTVisual.ITTLabel;
    labelPackageProcedureInfoPhysiotherapyReports: TTVisual.ITTLabel;
    labelProcedureObject: TTVisual.ITTLabel;
    labelReportDatePhysiotherapyReports: TTVisual.ITTLabel;
    labelReportEndDatePhysiotherapyReports: TTVisual.ITTLabel;
    labelReportInfoPhysiotherapyReports: TTVisual.ITTLabel;
    labelReportNoPhysiotherapyReports: TTVisual.ITTLabel;
    labelReportStartDatePhysiotherapyReports: TTVisual.ITTLabel;
    labelReportTimePhysiotherapyReports: TTVisual.ITTLabel;
    labelSessionCount: TTVisual.ITTLabel;
    labelTreatmentDiagnosisUnit: TTVisual.ITTLabel;
    labelTreatmentProcessTypePhysiotherapyReports: TTVisual.ITTLabel;
    labelTreatmentProperties: TTVisual.ITTLabel;
    labelTreatmentTypePhysiotherapyReports: TTVisual.ITTLabel;
    PackageProcedureInfoPhysiotherapyReports: TTVisual.ITTTextBox;
    ProcedureObject: TTVisual.ITTObjectListBox;
    ReportDatePhysiotherapyReports: TTVisual.ITTDateTimePicker;
    ReportEndDatePhysiotherapyReports: TTVisual.ITTDateTimePicker;
    ReportInfoPhysiotherapyReports: TTVisual.ITTTextBox;
    ReportNoPhysiotherapyReports: TTVisual.ITTTextBox;
    ReportStartDatePhysiotherapyReports: TTVisual.ITTDateTimePicker;
    ReportTimePhysiotherapyReports: TTVisual.ITTTextBox;
    ReportType: TTVisual.ITTCheckBox;
    SessionCount: TTVisual.ITTTextBox;
    TreatmentDiagnosisUnit: TTVisual.ITTObjectListBox;
    TreatmentProcessTypePhysiotherapyReports: TTVisual.ITTTextBox;
    TreatmentProperties: TTVisual.ITTTextBox;
    TreatmentTypePhysiotherapyReports: TTVisual.ITTEnumComboBox;
    ttpanel1: TTVisual.ITTPanel;

    radioGroupItems = [
        { text: "Var", value: true },
        { text: "Yok", value: false }

    ];

    @ViewChild('TemplateCombo') TemplateCombo: DxSelectBoxComponent;



    public physiotherapyOrderRequestFormViewModel: PhysiotherapyOrderRequestFormViewModel = new PhysiotherapyOrderRequestFormViewModel();
    public get _PhysiotherapyOrder(): PhysiotherapyOrder {
        return this._TTObject as PhysiotherapyOrder;
    }
    private PhysiotherapyOrderRequestForm_DocumentUrl: string = '/api/PhysiotherapyOrderService/PhysiotherapyOrderRequestForm';
    constructor(protected httpService: NeHttpService,
        protected objectContextService: ObjectContextService,
        private modalStateService: ModalStateService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super('PHYSIOTHERAPYORDER', 'PhysiotherapyOrderRequestForm');
        this._DocumentServiceUrl = this.PhysiotherapyOrderRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    minPhysiotherapyRequestDate: Date;
    patientSex: string;
    protected async PreScript() {
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyRequest = this._prObj;

        super.PreScript();

        let urlString: string = '/api/PhysiotherapyOrderService/GetPhysiotherapyOrderList?ObjectID=' + this._prObj.ObjectID;
        this.httpService.get<any>(urlString)
            .then(response => {
                this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList = response.Item1;
                this.physiotherapyOrderRequestFormViewModel.MedicalInfo = response.Item2;
                this.physiotherapyOrderRequestFormViewModel._physiotherapyRequestDate = response.Item3;
                this.minPhysiotherapyRequestDate = response.Item4;
                this.physiotherapyOrderRequestFormViewModel.Pregnancy = response.Item5.Pregnancy;
                this.physiotherapyOrderRequestFormViewModel.MetalImplant = response.Item5.MetalImplant;
                this.physiotherapyOrderRequestFormViewModel.MetalImplantDescription = response.Item5.MetalImplantDescription;
                this.patientSex = response.Item5.Sex;
                this.physiotherapyOrderRequestFormViewModel.userTemplateList = response.Item6;
            })
            .catch(error => {
                console.log(error);
            });

    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {

        super.PostScript(transDef);
    }


    public selectedUserTemplate;
    public userTemplateName;
    public async saveForm(saveInfo: FormSaveInfo) {
        if (this.required == true) {
            if (this.physiotherapyOrderRequestFormViewModel.MetalImplant == null) {
                this.messageService.showError("Metal implant bilgisi girilmeden istek kaydedilemez");
                return;
            }
            if (this.patientSex == "KADIN" && this.physiotherapyOrderRequestFormViewModel.Pregnancy == null) {
                this.messageService.showError("Gebelik bilgisi girilmeden istek kaydedilemez");
                return;
            }
            if (this.physiotherapyOrderRequestFormViewModel.MetalImplant == true && this.physiotherapyOrderRequestFormViewModel.MetalImplantDescription == null) {
                this.messageService.showError("Metal implant açıklaması girilmeden istek kaydedilemez");
                return;
            }
        }
        if(this.physiotherapyOrderRequestFormViewModel.createTemplate == true && (this.userTemplateName == null))
        {
            ServiceLocator.MessageService.showError("Şablon adı boş bırakılamaz");
            return;
        }
        else if(this.physiotherapyOrderRequestFormViewModel.createTemplate == true && (this.userTemplateName != null)){
                this.physiotherapyOrderRequestFormViewModel.savedUserTemplate = new UserTemplateModel();
                this.physiotherapyOrderRequestFormViewModel.savedUserTemplate.Description = this.userTemplateName;
                this.physiotherapyOrderRequestFormViewModel.savedUserTemplate.TAObjectDefID = this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyRequest.ObjectDefID;
                this.physiotherapyOrderRequestFormViewModel.savedUserTemplate.TAObjectID = this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyRequest.ObjectID;
        }
        await super.save(saveInfo);
    }

    async btnClearUserTemplate_Click(): Promise<void> {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçtiğiniz şablon kaldırılacaktır. Devam etmek istiyor musunuz? "), 1);
        if (result === "H")
            return;
        
        this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList=this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList.filter(item => item.isTemplateOrder != true);

        this.TemplateCombo.value = null;
        this.selectedUserTemplate = null;
        this.physiotherapyOrderRequestFormViewModel.selectedUserTemplate = null;
    }

    async btnDeleteSelectedUserTemplate_Click(): Promise<void> {
        try {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili şablon sistemden silinecektir. Devam etmek istiyor musunuz?"), 1);
            if (result === "H")
                return;
            let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

            savedUserTemplate.ObjectID = this.physiotherapyOrderRequestFormViewModel.selectedUserTemplate.ObjectID;
            savedUserTemplate.TAObjectDefID = this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyRequest.ObjectDefID;
            let apiUrl: string = 'api/PhysiotherapyOrderService/DeletePhysiotherapyRequestUserTemplate';
            await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                this.physiotherapyOrderRequestFormViewModel.userTemplateList = result;
                this.physiotherapyOrderRequestFormViewModel.selectedUserTemplate = null;
                this.userTemplateName = "";
                ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Silindi");
            });

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }
    
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

        this.printPhysiotherapyRequestReport();
        this.modalStateService.callActionExecuted(DialogResult.OK, this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyRequest.ObjectID, this.txtVal, true, false);
    }

    //Rapor Yazdırma
    private txtVal: boolean = true;
    public printPhysiotherapyRequestReport() {
        const objectIdParam = new GuidParam(this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('PhysiotherapyRequestReport', reportParameters);
    }

    //Formdan gride aktarma
    public addPhyOrderDetail() {
        if (this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.FTRApplicationAreaDef == null) {
            //Boş olamaz Zorunlu!! işlem de seçili olmalı !!
            TTVisual.InfoBox.Alert("Vücut Bölgesi Zorunlu!");
        } else {
            let count = 0;
            for (let i = 0; i < this.physiotherapyOrderRequestFormViewModel.TreatmentDiagnosisInfoList.length; i++) {
                for (let j = 0; j < this.physiotherapyOrderRequestFormViewModel.TreatmentDiagnosisInfoList[i].ProcedureDefinitionList.length; j++) {
                    if (this.physiotherapyOrderRequestFormViewModel.TreatmentDiagnosisInfoList[i].ProcedureDefinitionList[j].isRequested == true) {
                        let _orderInfo: PhysiotherapyOrderInfo = new PhysiotherapyOrderInfo();
                        _orderInfo.PhysiotherapyOrderObj = new PhysiotherapyOrder();
                        _orderInfo.PhysiotherapyOrderObj.PhysiotherapyRequest = this._prObj;

                        _orderInfo.ApplicationArea = this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.FTRApplicationAreaDef != null ? this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.FTRApplicationAreaDef.ObjectID.toString() : "";
                        _orderInfo.ApplicationAreaInfo = this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder != null ? this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.ApplicationArea : "";
                        _orderInfo.Dose = this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.Dose != null ? this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.Dose : null;
                        _orderInfo.Duration = this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.Duration != null ? this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.Duration.toString() : null;
                        _orderInfo.IsNewOrder = true;
                        _orderInfo.ProcedureObject = this.physiotherapyOrderRequestFormViewModel.TreatmentDiagnosisInfoList[i].ProcedureDefinitionList[j].ProcedureDefinition.ObjectID.toString();
                        _orderInfo.SessionCount = this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.SessionCount != null ? this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.SessionCount.toString() : null;
                        _orderInfo.TreatmentDiagnosisUnit = this.physiotherapyOrderRequestFormViewModel.TreatmentDiagnosisInfoList[i].TreatmentDiagnosisUnit.ObjectID.toString();
                        _orderInfo.TreatmentProperties = this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.TreatmentProperties != null ? this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.TreatmentProperties : "";

                        if (this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList == null) {
                            this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList = new Array<PhysiotherapyOrderInfo>();
                        }
                        this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList.unshift(_orderInfo);
                        this.physiotherapyOrderRequestFormViewModel.TreatmentDiagnosisInfoList[i].ProcedureDefinitionList[j].isRequested = false;
                        count++;
                    }
                }
            }
            if (count == 0) {
                TTVisual.InfoBox.Alert("Lütfen F.T.R. işlemi seçiniz!");
            } else {
                this.EmptyViewModel();
            }
        }
    }

    //Formdan gride aktarım yaptıktan sonra property boşalma işlemleri
    public EmptyViewModel() {

        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.FTRApplicationAreaDef = null;
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.ApplicationArea = null;
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.Dose = null;
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.Duration = null;
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.ProcedureObject = null;
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.SessionCount = null;
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.TreatmentDiagnosisUnit = null;
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.TreatmentProperties = null;
    }

    // Grid row Silme
    async onRowDeleting(value: any): Promise<void> {
        let that = this;
        let urlString: string = '/api/PhysiotherapyOrderService/DeletePhysiotherapyOrder?ObjectID=' + value.data.OrderObjectId + '&ObjectDef=' + value.data.OrderObjectDefId;
        that.httpService.get<any>(urlString)
            .then(response => {
                this.messageService.showSuccess("İşlem Başarılı Bir Şekilde Silindi");
            })
            .catch(error => {
                console.log(error);
            });
    }

    _prObj: PhysiotherapyRequest = new PhysiotherapyRequest;
    public setInputParam(value: any) {
        this._prObj = value;
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyRequest = this._prObj;
    }

    public static getComponentInfoViewModel(physiotherapyRequest: PhysiotherapyRequest): PhysiotherapyOrderComponentInfoViewModel {
        let componentInfoViewModel = new PhysiotherapyOrderComponentInfoViewModel();
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('ee1a78c9-9c9d-4fb5-9a00-e719b53ca848');
        queryParameters.QueryDefID = new Guid('1c084218-9f30-4347-9314-707115df8073');
        let parameters = {};
        parameters['PHYSIOTHERAPYREQUEST'] = new GuidParam(physiotherapyRequest.ObjectID);
        queryParameters.Parameters = parameters;
        componentInfoViewModel.physiotherapyOrderQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'PhysiotherapyOrderRequestForm';
        componentInfo.ModuleName = "FizyoterapiModule";
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Fizyoterapi_Modulu/FizyoterapiModule';
        //TODO: ActiveIDsModel içerisindeki bilgiler kontrol edilecek
        componentInfo.InputParam = new DynamicComponentInputParam(physiotherapyRequest, new ActiveIDsModel(physiotherapyRequest.ObjectID, null, null));
        componentInfoViewModel.physiotherapyOrderComponentInfo = componentInfo;
        return componentInfoViewModel;
    }

    public static physiotherapyOrderQueryResultLoaded(e: any) {

        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "TREATMENTDIAGNOSISUNIT") {
                column.caption = i18n("M23046", "Tedavi Ünitesi");
            }
            if (column.dataField === "PROCEDUREOBJECT") {
                column.caption = i18n("M16951", "İşlemler");
            }
            if (column.dataField === "SESSIONCOUNT") {
                column.caption = i18n("M21489", "Seans Sayısı");
            }
            if (column.dataField === "DURATION") {
                column.caption = 'Süre/dk';
            }
            if (column.dataField === "DOSE") {
                column.caption = i18n("M13284", "Doz");
            }
            if (column.dataField === "FTRAPPLICATIONAREADEF") {
                column.caption = i18n("M24187", "Vücut Bölgesi");
            }
            if (column.dataField === "APPLICATIONAREA") {
                column.caption = i18n("M24189", "Vücut Bölgesi Açıklama");
            }
            if (column.dataField === "TREATMENTPROPERTIES") {
                column.caption = i18n("M10469", "Açıklama");
            }
        }
    }


    async procedureDefinitionOnChange(ProcedureDefinitionId: Guid, treatmentItemId: Guid, isChecked: boolean) {
        //var c = this.physiotherapyOrderRequestFormViewModel.TreatmentDiagnosisInfoList.filter(c => c.TreatmentDiagnosisUnit.ObjectID == treatmentItemId);
        //this.physiotherapyOrderRequestFormViewModel.TreatmentDiagnosisInfoList.filter(c => c.TreatmentDiagnosisUnit.ObjectID == treatmentItemId)[0].ProcedureDefinitionList.filter(x => x.ProcedureDefinition.ObjectID == ProcedureDefinitionId)[0].isRequested = isChecked;
    }

    @ViewChild('txtProcedureName') procedureSearchTextBox: DxTextBoxComponent;
    @ViewChildren('accordion') procedureAccordion: QueryList<DxAccordionComponent>;
    searchProcedureName: string;

    procedureTextSearch(event) {
        this.btnCollapseAllAccordions_valueChange();
        let searchedText = event.value;
        if (searchedText != null && searchedText != "") {

            for (let treatmentDiagnosis of this.physiotherapyOrderRequestFormViewModel.TreatmentDiagnosisInfoList) {
                //let treatmentFound = false;
                let _procedureDefinitionList = treatmentDiagnosis.ProcedureDefinitionList;
                let procedureFound = false;
                for (let procedureDefinition of _procedureDefinitionList) {
                    if (procedureDefinition.ProcedureDefinitionName.toLocaleUpperCase().includes(searchedText.toLocaleUpperCase(), 0)) {
                        procedureDefinition.Color = { color: 'red' };
                        procedureFound = true;
                        //treatmentFound = true;
                    } else {
                        procedureDefinition.Color = { color: 'black' };
                    }

                    if (!procedureFound) {
                        if (procedureDefinition.ProcedureDefinition.Code.includes(searchedText.toLocaleUpperCase(), 0)) {
                            procedureDefinition.Color = { color: 'red' };
                            procedureFound = true;
                            //detailFoundOnFormDef = true;
                        }
                        else {
                            procedureDefinition.Color = { color: 'black' };
                        }
                    }
                }



                if (procedureFound) {

                    let accordion = this.procedureAccordion.find((dr, index, accordions) => dr.hint.toString() == this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.ObjectID.toString());
                    let accordionItem = accordion.items.find(
                        dr => dr.TreatmentDiagnosisUnitName == treatmentDiagnosis.TreatmentDiagnosisUnit.Name
                    );
                    let index = accordion.items.indexOf(accordionItem);
                    accordion.instance.expandItem(index);
                }
            }
        }


    }

    btnCollapseAllAccordions_valueChange() {
        this.procedureAccordion.forEach((dr, index, accordions) => dr.items.forEach((it, i, items) => dr.instance.collapseItem(i)));
    }
    btnExpandAllAccordions_valueChange() {
        this.procedureAccordion.forEach((dr, index, accordions) => dr.items.forEach((it, i, items) => dr.instance.expandItem(i)));
    }

    //*****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PhysiotherapyOrder();
        this.physiotherapyOrderRequestFormViewModel = new PhysiotherapyOrderRequestFormViewModel();
        this._ViewModel = this.physiotherapyOrderRequestFormViewModel;
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder = this._TTObject as PhysiotherapyOrder;
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.ProcedureObject = new PhysiotherapyDefinition();
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.TreatmentDiagnosisUnit = new ResTreatmentDiagnosisUnit();
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.FTRApplicationAreaDef = new FTRVucutBolgesi();
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyReports = new PhysiotherapyReports();
        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef = new FTRVucutBolgesi();
    
    }

    protected loadViewModel() {
        let that = this;

        that.physiotherapyOrderRequestFormViewModel = this._ViewModel as PhysiotherapyOrderRequestFormViewModel;
        that._TTObject = this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder;
        if (this.physiotherapyOrderRequestFormViewModel == null)
            this.physiotherapyOrderRequestFormViewModel = new PhysiotherapyOrderRequestFormViewModel();
        if (this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder == null)
            this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder = new PhysiotherapyOrder();
        let procedureObjectObjectID = that.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
            let procedureObject = that.physiotherapyOrderRequestFormViewModel.PhysiotherapyDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
            if (procedureObject) {
                that.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.ProcedureObject = procedureObject;
            }
        }
        let treatmentDiagnosisUnitObjectID = that.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder["TreatmentDiagnosisUnit"];
        if (treatmentDiagnosisUnitObjectID != null && (typeof treatmentDiagnosisUnitObjectID === "string")) {
            let treatmentDiagnosisUnit = that.physiotherapyOrderRequestFormViewModel.ResTreatmentDiagnosisUnits.find(o => o.ObjectID.toString() === treatmentDiagnosisUnitObjectID.toString());
            if (treatmentDiagnosisUnit) {
                that.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.TreatmentDiagnosisUnit = treatmentDiagnosisUnit;
            }
        }
        let fTRApplicationAreaDefObjectID = that.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder["FTRApplicationAreaDef"];
        if (fTRApplicationAreaDefObjectID != null && (typeof fTRApplicationAreaDefObjectID === "string")) {
            let fTRApplicationAreaDef = that.physiotherapyOrderRequestFormViewModel.FTRVucutBolgesis.find(o => o.ObjectID.toString() === fTRApplicationAreaDefObjectID.toString());
            if (fTRApplicationAreaDef) {
                that.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.FTRApplicationAreaDef = fTRApplicationAreaDef;
            }
        }
        let physiotherapyReportsObjectID = that.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder["PhysiotherapyReports"];
        if (physiotherapyReportsObjectID != null && (typeof physiotherapyReportsObjectID === "string")) {
            let physiotherapyReports = that.physiotherapyOrderRequestFormViewModel.PhysiotherapyReportss.find(o => o.ObjectID.toString() === physiotherapyReportsObjectID.toString());
            if (physiotherapyReports) {
                that.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyReports = physiotherapyReports;
            }
            if (physiotherapyReports != null) {
                let fTRApplicationAreaDefObjectID = physiotherapyReports["FTRApplicationAreaDef"];
                if (fTRApplicationAreaDefObjectID != null && (typeof fTRApplicationAreaDefObjectID === "string")) {
                    let fTRApplicationAreaDef = that.physiotherapyOrderRequestFormViewModel.FTRVucutBolgesis.find(o => o.ObjectID.toString() === fTRApplicationAreaDefObjectID.toString());
                    if (fTRApplicationAreaDef) {
                        physiotherapyReports.FTRApplicationAreaDef = fTRApplicationAreaDef;
                    }
                }
            }
        }

    }

    public required: boolean;
    async ngOnInit() {
        let that = this;

        this.physiotherapyOrderRequestFormViewModel._PhysiotherapyOrder.PhysiotherapyRequest = this._prObj;

        await this.load(PhysiotherapyOrderRequestFormViewModel);

        let requiredField: string = (await SystemParameterService.GetParameterValue('FTRREQUESTMEDICALINFO', 'FALSE'));
        if (requiredField === 'TRUE') {
            this.required = true;
        }
        else {
            this.required = false;
        }

    }


    public onApplicationAreaChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.ApplicationArea != event) {
                this._PhysiotherapyOrder.ApplicationArea = event;
            }
        }
    }

    public onDiagnosisGroupPhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.DiagnosisGroup != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.DiagnosisGroup = event;
            }
        }
    }

    public onDoseChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.Dose != event) {
                this._PhysiotherapyOrder.Dose = event;
            }
        }
    }

    public onDurationChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.Duration != event) {
                this._PhysiotherapyOrder.Duration = event;
            }
        }
    }

    public onFTRApplicationAreaDefChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.FTRApplicationAreaDef != event) {
                this._PhysiotherapyOrder.FTRApplicationAreaDef = event;
            }
        }
    }

    public onFTRApplicationAreaDefPhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.FTRApplicationAreaDef = event;
            }
        }
    }

    public onPackageProcedureInfoPhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.PackageProcedureInfo != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.PackageProcedureInfo = event;
            }
        }
    }

    public onProcedureObjectChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.ProcedureObject != event) {
                this._PhysiotherapyOrder.ProcedureObject = event;
            }
        }
    }

    public onReportDatePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportDate != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportDate = event;
            }
        }
    }

    public onReportEndDatePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportEndDate != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportEndDate = event;
            }
        }
    }

    public onReportInfoPhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportInfo != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportInfo = event;
            }
        }
    }

    public onReportNoPhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportNo != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportNo = event;
            }
        }
    }

    public onReportStartDatePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportStartDate != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportStartDate = event;
            }
        }
    }

    public onReportTimePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportTime != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportTime = event;
            }
        }
    }

    public onReportTypeChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.ReportType != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.ReportType = event;
            }
        }
    }

    public onSessionCountChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.SessionCount != event) {
                this._PhysiotherapyOrder.SessionCount = event;
            }
        }
    }

    public onTreatmentDiagnosisUnitChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.TreatmentDiagnosisUnit != event) {
                this._PhysiotherapyOrder.TreatmentDiagnosisUnit = event;
            }
        }
    }

    public onTreatmentProcessTypePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.TreatmentProcessType != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.TreatmentProcessType = event;
            }
        }
    }

    public onTreatmentPropertiesChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null && this._PhysiotherapyOrder.TreatmentProperties != event) {
                this._PhysiotherapyOrder.TreatmentProperties = event;
            }
        }
    }

    public onTreatmentTypePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyOrder != null &&
                this._PhysiotherapyOrder.PhysiotherapyReports != null && this._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType != event) {
                this._PhysiotherapyOrder.PhysiotherapyReports.TreatmentType = event;
            }
        }
    }


    public onMetalImplantValueChanged(event): void {
        if (event.value != null) {
            if (event.value.value == 1) {
                this.physiotherapyOrderRequestFormViewModel.MetalImplant = true;
            }
            else if (event.value.value == 2) {
                this.physiotherapyOrderRequestFormViewModel.MetalImplant = false;

            }
        }
    }

    public onPregnancyValueChanged(event): void {
        if (event.value != null) {
            if (event.value == 1) {
                this.physiotherapyOrderRequestFormViewModel.Pregnancy = true;
            }
            else if (event.value == 2) {
                this.physiotherapyOrderRequestFormViewModel.Pregnancy = false;

            }
        }
    }



    async SelectUserTemplate(event: any): Promise<void> {
        if (event.itemData != null) {
            this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList = this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList.filter(item => item.isTemplateOrder != true);
            if (this.physiotherapyOrderRequestFormViewModel.selectedUserTemplate == null || (this.physiotherapyOrderRequestFormViewModel.selectedUserTemplate.ObjectID != event.itemData.ObjectID)) {
                this.physiotherapyOrderRequestFormViewModel.selectedUserTemplate = event.itemData;
                const that = this;
                that.loadGridByTemplate();
            }
        }

    }

    protected async loadGridByTemplate() {
        try {

            let fullApiUrl: string = "";
            fullApiUrl = "/api/PhysiotherapyOrderService/PhysiotherapyOrderTemplate";
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let response = await httpService.post<Array<PhysiotherapyOrderInfo>>(fullApiUrl, this.physiotherapyOrderRequestFormViewModel.selectedUserTemplate);
            let orderInfoTemplateList: Array<PhysiotherapyOrderInfo> = response;

            orderInfoTemplateList.forEach(item => {
                let _orderInfo: PhysiotherapyOrderInfo = new PhysiotherapyOrderInfo();
                _orderInfo.PhysiotherapyOrderObj = new PhysiotherapyOrder();
                _orderInfo.PhysiotherapyOrderObj.PhysiotherapyRequest = this._prObj;

                _orderInfo.ApplicationArea = item.ApplicationArea;
                _orderInfo.ApplicationAreaInfo = item.ApplicationAreaInfo;
                _orderInfo.Dose = item.Dose;
                _orderInfo.Duration = item.Duration;
                _orderInfo.IsNewOrder = true;
                _orderInfo.ProcedureObject = item.ProcedureObject;
                _orderInfo.SessionCount = item.SessionCount;
                _orderInfo.TreatmentDiagnosisUnit = item.TreatmentDiagnosisUnit;
                _orderInfo.TreatmentProperties = item.TreatmentProperties;
                _orderInfo.isTemplateOrder = true;

                if (this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList == null) {
                    this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList = new Array<PhysiotherapyOrderInfo>();
                }
                this.physiotherapyOrderRequestFormViewModel.PhysiotherapyOrderList.unshift(_orderInfo);
            })

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }
 
    protected redirectProperties(): void {
        redirectProperty(this.ApplicationArea, "Text", this.__ttObject, "ApplicationArea");
        redirectProperty(this.SessionCount, "Text", this.__ttObject, "SessionCount");
        redirectProperty(this.Duration, "Text", this.__ttObject, "Duration");
        redirectProperty(this.Dose, "Text", this.__ttObject, "Dose");
        redirectProperty(this.TreatmentProperties, "Text", this.__ttObject, "TreatmentProperties");
        redirectProperty(this.ReportNoPhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.ReportNo");
        redirectProperty(this.ReportTimePhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.ReportTime");
        redirectProperty(this.ReportType, "Value", this.__ttObject, "PhysiotherapyReports.ReportType");
        redirectProperty(this.TreatmentTypePhysiotherapyReports, "Value", this.__ttObject, "PhysiotherapyReports.TreatmentType");
        redirectProperty(this.DiagnosisGroupPhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.DiagnosisGroup");
        redirectProperty(this.ReportDatePhysiotherapyReports, "Value", this.__ttObject, "PhysiotherapyReports.ReportDate");
        redirectProperty(this.ReportStartDatePhysiotherapyReports, "Value", this.__ttObject, "PhysiotherapyReports.ReportStartDate");
        redirectProperty(this.ReportEndDatePhysiotherapyReports, "Value", this.__ttObject, "PhysiotherapyReports.ReportEndDate");
        redirectProperty(this.ReportInfoPhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.ReportInfo");
        redirectProperty(this.PackageProcedureInfoPhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.PackageProcedureInfo");
        redirectProperty(this.TreatmentProcessTypePhysiotherapyReports, "Text", this.__ttObject, "PhysiotherapyReports.TreatmentProcessType");
    }

    public initFormControls(): void {
        this.txtProcedureName = new TTVisual.TTTextBox();
        this.txtProcedureName.Name = "txtProcedureName";
        this.txtProcedureName.Text = "";


        this.labelSessionCount = new TTVisual.TTLabel();
        this.labelSessionCount.Text = i18n("M21489", "Seans Sayısı");
        this.labelSessionCount.Name = "labelSessionCount";
        this.labelSessionCount.TabIndex = 94;

        this.SessionCount = new TTVisual.TTTextBox();
        this.SessionCount.Name = "SessionCount";
        this.SessionCount.TabIndex = 93;

        this.ApplicationArea = new TTVisual.TTTextBox();
        this.ApplicationArea.Name = "ApplicationArea";
        this.ApplicationArea.TabIndex = 10;

        this.Duration = new TTVisual.TTTextBox();
        this.Duration.Name = "Duration";
        this.Duration.TabIndex = 14;

        this.Dose = new TTVisual.TTTextBox();
        this.Dose.Name = "Dose";
        this.Dose.TabIndex = 78;

        this.TreatmentProperties = new TTVisual.TTTextBox();
        this.TreatmentProperties.Name = "TreatmentProperties";
        this.TreatmentProperties.TabIndex = 91;

        this.labelProcedureObject = new TTVisual.TTLabel();
        this.labelProcedureObject.Text = i18n("M14486", "FTR İşlemleri");
        this.labelProcedureObject.Name = "labelProcedureObject";
        this.labelProcedureObject.TabIndex = 7;

        this.ProcedureObject = new TTVisual.TTObjectListBox();
        this.ProcedureObject.ListDefName = "PhysiotherapyListDefinition";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.TabIndex = 6;

        this.labelTreatmentDiagnosisUnit = new TTVisual.TTLabel();
        this.labelTreatmentDiagnosisUnit.Text = i18n("M22778", "Tanı Tedavi Ünitesi");
        this.labelTreatmentDiagnosisUnit.Name = "labelTreatmentDiagnosisUnit";
        this.labelTreatmentDiagnosisUnit.TabIndex = 1;

        this.TreatmentDiagnosisUnit = new TTVisual.TTObjectListBox();
        this.TreatmentDiagnosisUnit.ListDefName = "TreatmentDiagnosisUnitListDefinition";
        this.TreatmentDiagnosisUnit.Name = "TreatmentDiagnosisUnit";
        this.TreatmentDiagnosisUnit.TabIndex = 0;

        this.labelFTRApplicationAreaDef = new TTVisual.TTLabel();
        this.labelFTRApplicationAreaDef.Text = i18n("M24187", "Vücut Bölgesi");
        this.labelFTRApplicationAreaDef.Name = "labelFTRApplicationAreaDef";
        this.labelFTRApplicationAreaDef.TabIndex = 3;

        this.FTRApplicationAreaDef = new TTVisual.TTObjectListBox();
        this.FTRApplicationAreaDef.ListDefName = "FTRVucutBolgesiTTObjectListDefinition";
        this.FTRApplicationAreaDef.Name = "FTRApplicationAreaDef";
        this.FTRApplicationAreaDef.TabIndex = 2;

        this.labelApplicationArea = new TTVisual.TTLabel();
        this.labelApplicationArea.Text = i18n("M24189", "Vücut Bölgesi Açıklama");
        this.labelApplicationArea.Name = "labelApplicationArea";
        this.labelApplicationArea.TabIndex = 11;

        this.labelDose = new TTVisual.TTLabel();
        this.labelDose.Text = i18n("M13284", "Doz");
        this.labelDose.Name = "labelDose";
        this.labelDose.TabIndex = 79;

        this.labelDuration = new TTVisual.TTLabel();
        this.labelDuration.Text = "Süre/dk";
        this.labelDuration.Name = "labelDuration";
        this.labelDuration.TabIndex = 15;

        this.labelTreatmentProperties = new TTVisual.TTLabel();
        this.labelTreatmentProperties.Text = i18n("M10469", "Açıklama");
        this.labelTreatmentProperties.Name = "labelTreatmentProperties";
        this.labelTreatmentProperties.TabIndex = 92;

        this.ttpanel1 = new TTVisual.TTPanel();
        this.ttpanel1.AutoSize = true;
        this.ttpanel1.Name = "ttpanel1";
        this.ttpanel1.TabIndex = 86;

        this.labelReportNoPhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportNoPhysiotherapyReports.Text = i18n("M20824", "Rapor Numarası");
        this.labelReportNoPhysiotherapyReports.Name = "labelReportNoPhysiotherapyReports";
        this.labelReportNoPhysiotherapyReports.TabIndex = 65;

        this.labelDiagnosisGroupPhysiotherapyReports = new TTVisual.TTLabel();
        this.labelDiagnosisGroupPhysiotherapyReports.Text = i18n("M22755", "Tanı Grubu");
        this.labelDiagnosisGroupPhysiotherapyReports.Name = "labelDiagnosisGroupPhysiotherapyReports";
        this.labelDiagnosisGroupPhysiotherapyReports.TabIndex = 43;

        this.TreatmentTypePhysiotherapyReports = new TTVisual.TTEnumComboBox();
        this.TreatmentTypePhysiotherapyReports.DataTypeName = "TreatmentQueryReportTypeEnum";
        this.TreatmentTypePhysiotherapyReports.Name = "TreatmentTypePhysiotherapyReports";
        this.TreatmentTypePhysiotherapyReports.TabIndex = 54;

        this.labelTreatmentTypePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelTreatmentTypePhysiotherapyReports.Text = i18n("M23037", "Tedavi Türü");
        this.labelTreatmentTypePhysiotherapyReports.Name = "labelTreatmentTypePhysiotherapyReports";
        this.labelTreatmentTypePhysiotherapyReports.TabIndex = 55;

        this.FTRApplicationAreaDefPhysiotherapyReports = new TTVisual.TTObjectListBox();
        this.FTRApplicationAreaDefPhysiotherapyReports.ListDefName = "FTRVucutBolgesiTTObjectListDefinition";
        this.FTRApplicationAreaDefPhysiotherapyReports.Name = "FTRApplicationAreaDefPhysiotherapyReports";
        this.FTRApplicationAreaDefPhysiotherapyReports.TabIndex = 56;

        this.TreatmentProcessTypePhysiotherapyReports = new TTVisual.TTTextBox();
        this.TreatmentProcessTypePhysiotherapyReports.Name = "TreatmentProcessTypePhysiotherapyReports";
        this.TreatmentProcessTypePhysiotherapyReports.TabIndex = 75;

        this.labelFTRApplicationAreaDefPhysiotherapyReports = new TTVisual.TTLabel();
        this.labelFTRApplicationAreaDefPhysiotherapyReports.Text = i18n("M24191", "Vücut Bölgesi Tanımı");
        this.labelFTRApplicationAreaDefPhysiotherapyReports.Name = "labelFTRApplicationAreaDefPhysiotherapyReports";
        this.labelFTRApplicationAreaDefPhysiotherapyReports.TabIndex = 57;

        this.PackageProcedureInfoPhysiotherapyReports = new TTVisual.TTTextBox();
        this.PackageProcedureInfoPhysiotherapyReports.Name = "PackageProcedureInfoPhysiotherapyReports";
        this.PackageProcedureInfoPhysiotherapyReports.TabIndex = 73;

        this.labelReportInfoPhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportInfoPhysiotherapyReports.Text = i18n("M20778", "Rapor Bilgisi");
        this.labelReportInfoPhysiotherapyReports.Name = "labelReportInfoPhysiotherapyReports";
        this.labelReportInfoPhysiotherapyReports.TabIndex = 61;

        this.ReportTimePhysiotherapyReports = new TTVisual.TTTextBox();
        this.ReportTimePhysiotherapyReports.Name = "ReportTimePhysiotherapyReports";
        this.ReportTimePhysiotherapyReports.TabIndex = 68;

        this.ReportEndDatePhysiotherapyReports = new TTVisual.TTDateTimePicker();
        this.ReportEndDatePhysiotherapyReports.Format = DateTimePickerFormat.Long;
        this.ReportEndDatePhysiotherapyReports.Name = "ReportEndDatePhysiotherapyReports";
        this.ReportEndDatePhysiotherapyReports.TabIndex = 62;

        this.ReportNoPhysiotherapyReports = new TTVisual.TTTextBox();
        this.ReportNoPhysiotherapyReports.Name = "ReportNoPhysiotherapyReports";
        this.ReportNoPhysiotherapyReports.TabIndex = 64;

        this.labelReportEndDatePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportEndDatePhysiotherapyReports.Text = i18n("M18791", "Medula Rapor Bitiş Tarihi");
        this.labelReportEndDatePhysiotherapyReports.Name = "labelReportEndDatePhysiotherapyReports";
        this.labelReportEndDatePhysiotherapyReports.TabIndex = 63;

        this.ReportInfoPhysiotherapyReports = new TTVisual.TTTextBox();
        this.ReportInfoPhysiotherapyReports.Name = "ReportInfoPhysiotherapyReports";
        this.ReportInfoPhysiotherapyReports.TabIndex = 60;

        this.ReportStartDatePhysiotherapyReports = new TTVisual.TTDateTimePicker();
        this.ReportStartDatePhysiotherapyReports.Format = DateTimePickerFormat.Long;
        this.ReportStartDatePhysiotherapyReports.Name = "ReportStartDatePhysiotherapyReports";
        this.ReportStartDatePhysiotherapyReports.TabIndex = 66;

        this.DiagnosisGroupPhysiotherapyReports = new TTVisual.TTTextBox();
        this.DiagnosisGroupPhysiotherapyReports.Name = "DiagnosisGroupPhysiotherapyReports";
        this.DiagnosisGroupPhysiotherapyReports.TabIndex = 42;

        this.labelReportStartDatePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportStartDatePhysiotherapyReports.Text = i18n("M18789", "Medula Rapor Başlangıç Tarihi");
        this.labelReportStartDatePhysiotherapyReports.Name = "labelReportStartDatePhysiotherapyReports";
        this.labelReportStartDatePhysiotherapyReports.TabIndex = 67;

        this.labelReportTimePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportTimePhysiotherapyReports.Text = i18n("M20850", "Rapor Süresi");
        this.labelReportTimePhysiotherapyReports.Name = "labelReportTimePhysiotherapyReports";
        this.labelReportTimePhysiotherapyReports.TabIndex = 69;

        this.ReportDatePhysiotherapyReports = new TTVisual.TTDateTimePicker();
        this.ReportDatePhysiotherapyReports.Format = DateTimePickerFormat.Long;
        this.ReportDatePhysiotherapyReports.Name = "ReportDatePhysiotherapyReports";
        this.ReportDatePhysiotherapyReports.TabIndex = 70;

        this.labelReportDatePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelReportDatePhysiotherapyReports.Text = "Medula Rapor Tarihi";
        this.labelReportDatePhysiotherapyReports.Name = "labelReportDatePhysiotherapyReports";
        this.labelReportDatePhysiotherapyReports.TabIndex = 71;

        this.ReportType = new TTVisual.TTCheckBox();
        this.ReportType.Value = false;
        this.ReportType.Text = i18n("M20870", "Rapor Türü : 1 ise Heyet Raporu, 0 ise Tek Hekim Raporu");
        this.ReportType.Name = "ReportType";
        this.ReportType.TabIndex = 72;

        this.labelPackageProcedureInfoPhysiotherapyReports = new TTVisual.TTLabel();
        this.labelPackageProcedureInfoPhysiotherapyReports.Text = i18n("M20170", "Paket Numarası");
        this.labelPackageProcedureInfoPhysiotherapyReports.Name = "labelPackageProcedureInfoPhysiotherapyReports";
        this.labelPackageProcedureInfoPhysiotherapyReports.TabIndex = 74;

        this.labelTreatmentProcessTypePhysiotherapyReports = new TTVisual.TTLabel();
        this.labelTreatmentProcessTypePhysiotherapyReports.Text = "Tedavi Türü; A:Ayaktan, Y:Yatarak";
        this.labelTreatmentProcessTypePhysiotherapyReports.Name = "labelTreatmentProcessTypePhysiotherapyReports";
        this.labelTreatmentProcessTypePhysiotherapyReports.TabIndex = 76;

        this.ttpanel1.Controls = [this.labelReportNoPhysiotherapyReports, this.labelDiagnosisGroupPhysiotherapyReports, this.TreatmentTypePhysiotherapyReports, this.labelTreatmentTypePhysiotherapyReports, this.FTRApplicationAreaDefPhysiotherapyReports, this.TreatmentProcessTypePhysiotherapyReports, this.labelFTRApplicationAreaDefPhysiotherapyReports, this.PackageProcedureInfoPhysiotherapyReports, this.labelReportInfoPhysiotherapyReports, this.ReportTimePhysiotherapyReports, this.ReportEndDatePhysiotherapyReports, this.ReportNoPhysiotherapyReports, this.labelReportEndDatePhysiotherapyReports, this.ReportInfoPhysiotherapyReports, this.ReportStartDatePhysiotherapyReports, this.DiagnosisGroupPhysiotherapyReports, this.labelReportStartDatePhysiotherapyReports, this.labelReportTimePhysiotherapyReports, this.ReportDatePhysiotherapyReports, this.labelReportDatePhysiotherapyReports, this.ReportType, this.labelPackageProcedureInfoPhysiotherapyReports, this.labelTreatmentProcessTypePhysiotherapyReports];
        this.Controls = [this.labelSessionCount, this.SessionCount, this.ApplicationArea, this.Duration, this.Dose, this.TreatmentProperties, this.labelProcedureObject, this.ProcedureObject, this.labelTreatmentDiagnosisUnit, this.TreatmentDiagnosisUnit, this.labelFTRApplicationAreaDef, this.FTRApplicationAreaDef, this.labelApplicationArea, this.labelDose, this.labelDuration, this.labelTreatmentProperties, this.ttpanel1, this.labelReportNoPhysiotherapyReports, this.labelDiagnosisGroupPhysiotherapyReports, this.TreatmentTypePhysiotherapyReports, this.labelTreatmentTypePhysiotherapyReports, this.FTRApplicationAreaDefPhysiotherapyReports, this.TreatmentProcessTypePhysiotherapyReports, this.labelFTRApplicationAreaDefPhysiotherapyReports, this.PackageProcedureInfoPhysiotherapyReports, this.labelReportInfoPhysiotherapyReports, this.ReportTimePhysiotherapyReports, this.ReportEndDatePhysiotherapyReports, this.ReportNoPhysiotherapyReports, this.labelReportEndDatePhysiotherapyReports, this.ReportInfoPhysiotherapyReports, this.ReportStartDatePhysiotherapyReports, this.DiagnosisGroupPhysiotherapyReports, this.labelReportStartDatePhysiotherapyReports, this.labelReportTimePhysiotherapyReports, this.ReportDatePhysiotherapyReports, this.labelReportDatePhysiotherapyReports, this.ReportType, this.labelPackageProcedureInfoPhysiotherapyReports, this.labelTreatmentProcessTypePhysiotherapyReports];

    }


}
