//$ACCC6A88
import { Component, ViewChild, OnInit, OnDestroy, AfterViewInit, Input, HostListener } from '@angular/core';
import { LaboratoryWorkListItemMasterModel, ProcedureInfoInputDVO, TubeInformation, QueryInputDVOByEpisode, LaboratoryWorkListStateItem, ProcedureInfoOutputDVO } from "./LaboratoryWorkListFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { IBarcodePrinterProvider } from 'app/Barcode/Services/IBarcodePrinterProvider';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { barcodeProviderFactory } from 'app/Barcode/Services/BarcodeProviderFactory';
import { LaboratoryBarcodeInfo } from 'app/Barcode/Models/LaboratoryBarcodeInfo';
import { CommonService } from 'ObjectClassService/CommonService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { DatePipe } from '@angular/common';
import { DxTextBoxComponent } from "devextreme-angular";
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { SubActionProcedure } from 'NebulaClient/Model/AtlasClientModel';

@Component({
    selector: 'laboratory-request-sample-acception-form',
    templateUrl: './LaboratoryRequestSampleAcceptionForm.html',
    providers: [MessageService, DatePipe,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }
    ]
})
export class LaboratoryRequestSampleAcceptionForm implements OnInit, OnDestroy, AfterViewInit {


    @ViewChild('scrollPanel') ScrollPanel: HTMLElement;
    GridLabProcedures: TTVisual.ITTGrid;
    public GridLabProceduresColumns = [];

    EpisodeID: string;
    PatientTCNo: string;
    LabRequestObjectID: string;
    selectedLabStates: Array<string>;
    clearDemographicInfo: boolean = false;
    hideButtons: boolean = true;
    selectButtonName: string;
    showPrintBarcodeButton = false;

    //queryParameter
    StartDate: Date;
    EndDate: Date;
    StateType: string;
    PatientStatus: string;
    SelectedWorkListStateItems: Array<LaboratoryWorkListStateItem>;

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    public ViewModel: LaboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();
    private _laboratoryWorkListItemMasterModel: LaboratoryWorkListItemMasterModel;
    @Input() set LaboratoryWorkListItemMasterModel(value: LaboratoryWorkListItemMasterModel) {
        this._laboratoryWorkListItemMasterModel = value;
        if (this.LaboratoryWorkListItemMasterModel != null) {
            this.ViewModel = this.LaboratoryWorkListItemMasterModel;
            this.LabRequestObjectID = this.LaboratoryWorkListItemMasterModel.LabRequestObjectID;
            this.EpisodeID = this.LaboratoryWorkListItemMasterModel.EpisodeID;
            this.PatientTCNo = this.LaboratoryWorkListItemMasterModel.PatientTCNo;
            this.selectedLabStates = this.LaboratoryWorkListItemMasterModel.SelectedLaboratoryStateItems;
            this.clearDemographicInfo = false;
            this.hideButtons = false;
            this.selectButtonName = "Tümünü Seç";
            this.showPrintBarcodeButton = false;

            //Istek Kabul sorgulaması yapıldıgında testlerın hepsının Sec ısaretlı gelmesı ıcın
            //Numune Alma ekranında da testlerın hepsının Sec ısretlı gelmesı ıstendı, barkod okuyucu ıle okutmak ıstemıyorlar, 24.08.2017

            //if (this.showSampleAcceptButtons() == true)
            //this.checkAllItemAsSelected();
        }
        else {
            this.ViewModel = null;
            this.LabRequestObjectID = "";
        }
    }
    get LaboratoryWorkListItemMasterModel(): LaboratoryWorkListItemMasterModel {
        return this._laboratoryWorkListItemMasterModel;
    }

    private _queryParameter: QueryInputDVOByEpisode;
    @Input() set QueryParameter(value: QueryInputDVOByEpisode) {
        this._queryParameter = value;
        if (this.QueryParameter != null) {
            this.EpisodeID = this.QueryParameter.EpisodeID.toString();
            this.StartDate = this.QueryParameter.StartDate;
            this.EndDate = this.QueryParameter.EndDate;
            this.PatientStatus = this.QueryParameter.PatientStatus;
            this.SelectedWorkListStateItems = this.QueryParameter.SelectedWorkListStateItems;
            this.SampleTakenLaboratoryProcedureList = new Array<LaboratoryProcedure>();
            this.labProcObjectIDList = new Array<string>();
        }
    }
    get QueryParameter(): QueryInputDVOByEpisode {
        return this._queryParameter;
    }

    public ProcedureListColumns = [
        {
            "caption": i18n("M30802", "Kategori Adı"),
            dataField: "ProcedureRequestFormCategoryName",
            width: 80,
            allowSorting: true,
            groupIndex: "0"
        },
        {
            "caption": i18n("M21507", "Seç"),
            dataField: "isSelected",
            width: 40,
            allowSorting: true,
            cellTemplate: "checkBoxTemplate"
        },
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "TestCode",
            width: 80,
            allowSorting: true,
            cellTemplate: "ExternalRequestCellTemplate"
        },
        {
            "caption": i18n("M16821", "İşlem Adı"),
            dataField: "LaboratoryTestName",
            width: 300,
            allowSorting: true,
            cellTemplate: "TestPriorityCellTemplate"
        },
        {
            "caption": i18n("M16694", "İstem Tarihi"),
            dataField: "RequestDate",
            width: 120,
            allowSorting: true
        },
        {
            "caption": i18n("M30803", "İşlem Durumu"),
            dataField: "StateName",
            width: 120,
            allowSorting: true
        },
        {
            "caption": i18n("M27321", "Barkod"),
            dataField: "BarcodeID",
            width: 110,
            allowSorting: true,
            cellTemplate: "BarcodeCellTemplate"
        },
        {
            "caption": i18n("M19543", "Numune No"),
            dataField: "SpecimenID",
            width: 110,
            allowSorting: true
        },
        {
            "caption": i18n("M16721", "İsteyen Doktor"),
            dataField: "RequestedByUser",
            width: 150,
            allowSorting: true
        },
        {
            "caption": i18n("M16697", "İstem Yapan Bölüm"),
            dataField: "FromResourceName",
            width: 200,
            allowSorting: true
        },
        {
            "caption": i18n("M27395", "LOINC Kodu"),
            dataField: "TestLoincCode",
            width: 80,
            allowSorting: true

        }
    ];

    public BarcodeSampleTakenColumns = [
        {
            "caption": i18n("M27321", "Barkod"),
            dataField: "BarcodeId",
            width: 80,
            allowSorting: true,
        },
        {
            "caption": i18n("M19540", "Numune Alma Tarihi"),
            dataField: "SampleDate",
            width: 80,
            allowSorting: true,
        },
        {
            "caption": i18n("M19553", "Numuneyi Alan"),
            dataField: "SampleUser",
            width: 120,
            allowSorting: true
        },
        {
            "caption": i18n("M18165", "Laboratuar"),
            dataField: "MasterResource",
            width: 200,
            allowSorting: true
        }
    ];

    //IsSelected: TTVisual.ITTCheckBoxColumn;
    //IsExternalProcedureRequest: TTVisual.ITTCheckBoxColumn;
    //TestCode: TTVisual.ITTTextBoxColumn;
    //TestLOINCCode: TTVisual.ITTTextBoxColumn;
    //LaboratoryTestName: TTVisual.ITTTextBoxColumn;
    //RequestDate: TTVisual.ITTTextBoxColumn;
    //FromResourceName: TTVisual.ITTTextBoxColumn;
    //RequestedByUser: TTVisual.ITTTextBoxColumn;
    //StateName: TTVisual.ITTTextBoxColumn;
    //TubeInfo: TTVisual.ITTTextBoxColumn;
    //BarcodeID: TTVisual.ITTTextBoxColumn;
    //SpecimenID: TTVisual.ITTTextBoxColumn;


    public TubeInfoColumns = [];
    IsTubeSelected: TTVisual.ITTCheckBoxColumn;
    ContainerID: TTVisual.ITTTextBoxColumn;  //BarcodeID
    SpecialHandlingCode: TTVisual.ITTTextBoxColumn;  //Barkod acıklamalrı
    OtherEnvFactor: TTVisual.ITTTextBoxColumn;  //Barkod Tipi

    txtBarcodeNo: TTVisual.ITTTextBox;
    @ViewChild('BarcodeText') BarcodeText: DxTextBoxComponent;
    public BarcodeValue: string = "";
    private LaboratoryRequestSampleAcceptionForm_DocumentUrl: string = '/api/LaboratoryWorkListService/LaboratoryRequestSampleAcceptionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private barcodePrintService: IBarcodePrintService, private reportService: AtlasReportService, private datePipe: DatePipe, private objectContextService: ObjectContextService) {
        this.initFormControls();

    }

    public initViewModel(): void {

    }
    public loadViewModel() {

    }

    @HostListener('window:resize', ['$event'])
    resize(event: Event) {
        if (this.ScrollPanel) {
            let rect: ClientRect = this.ScrollPanel['nativeElement'].getBoundingClientRect();
            let top = rect.top;

            let viewPortHeight: number = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
            this.ScrollPanel['nativeElement'].style.height = (viewPortHeight - (top + 190)).toString() + "px";
        }
    }

    ngOnInit(): void {

    }

    ngAfterViewInit(): void {
        this.resize(undefined);
        this.hideButtons = true;
        this.BarcodeText.instance.focus();
    }
    ngOnDestroy() {

    }


    onBarcodeChanged(event) {
        let that = this;
        if (event.charCode === 13) {
            if (this.BarcodeValue != "") {
                for (let lp of this.ViewModel.LaboratoryProcedureList) {
                    if (lp.BarcodeID == this.BarcodeValue) {
                        lp.isSelected = true;
                    }
                }
                this.btnSampleLaboratoryAcceptClick();
                this.BarcodeValue = "";
            }
        }
    }

    SelectDeSelectAll() {

        let allSelected: boolean = true;

        if (this.selectButtonName == "Tümünü Kaldır")
        {
            for (let lp of this.ViewModel.LaboratoryProcedureList) {
                lp.isSelected = false;
            }
        }

        if (this.selectButtonName == "Tümünü Seç") {
            for (let lp of this.ViewModel.LaboratoryProcedureList) {
                lp.isSelected = true;
            }
        }

        if (this.selectButtonName == "Tümünü Kaldır")
            this.selectButtonName = "Tümünü Seç";
        else if (this.selectButtonName == "Tümünü Seç")
            this.selectButtonName = "Tümünü Kaldır";
    }

    SelectAll() {
        for (let lp of this.ViewModel.LaboratoryProcedureList) {
            lp.isSelected = true;
        }
    }

    DeSelectAll() {
        for (let lp of this.ViewModel.LaboratoryProcedureList) {
            lp.isSelected = false;
        }
    }

    public initFormControls(): void {

        //ProcedureListColumns alanları
        //this.IsSelected = new TTVisual.TTCheckBoxColumn();
        //this.IsSelected.DataMember = "isSelected";
        //this.IsSelected.DisplayIndex = 3;
        //this.IsSelected.HeaderText = "Seç";
        //this.IsSelected.Name = "IsSelected";
        //this.IsSelected.Width = 40;

        //this.IsExternalProcedureRequest = new TTVisual.TTCheckBoxColumn();
        //this.IsExternalProcedureRequest.DataMember = "isExternalProcedureRequest";
        //this.IsExternalProcedureRequest.DisplayIndex = 3;
        //this.IsExternalProcedureRequest.HeaderText = "Dış İstem";
        //this.IsExternalProcedureRequest.Name = "isExternalProcedureRequest";
        //this.IsExternalProcedureRequest.ReadOnly = true;
        //this.IsExternalProcedureRequest.Width = 80;
        //this.IsExternalProcedureRequest.BackColor = "#FF0000";


        //this.TestCode = new TTVisual.TTTextBoxColumn();
        //this.TestCode.DataMember = "TestCode";
        //this.TestCode.DisplayIndex = 1;
        //this.TestCode.HeaderText = "İşlem Kodu";
        //this.TestCode.Name = "TestCode";
        //this.TestCode.ReadOnly = true;
        //this.TestCode.Width = 80;


        //this.LaboratoryTestName = new TTVisual.TTTextBoxColumn();
        //this.LaboratoryTestName.DataMember = "LaboratoryTestName";
        //this.LaboratoryTestName.DisplayIndex = 1;
        //this.LaboratoryTestName.HeaderText = "İşlem Adı";
        //this.LaboratoryTestName.Name = "LaboratoryTestName";
        //this.LaboratoryTestName.ReadOnly = true;
        //this.LaboratoryTestName.Width = 300;

        //this.RequestDate = new TTVisual.TTTextBoxColumn();
        //this.RequestDate.DataMember = "RequestDate";
        //this.RequestDate.DisplayIndex = 1;
        //this.RequestDate.HeaderText = "İstem Tarihi";
        //this.RequestDate.Name = "RequestDate";
        //this.RequestDate.ReadOnly = true;
        //this.RequestDate.Width = 120;

        //this.FromResourceName = new TTVisual.TTTextBoxColumn();
        //this.FromResourceName.DataMember = "FromResourceName";
        //this.FromResourceName.DisplayIndex = 1;
        //this.FromResourceName.HeaderText = "İstem Yapan Bölüm";
        //this.FromResourceName.Name = "FromResourceName";
        //this.FromResourceName.ReadOnly = true;
        //this.FromResourceName.Width = 200;

        //this.RequestedByUser = new TTVisual.TTTextBoxColumn();
        //this.RequestedByUser.DataMember = "RequestedByUser";
        //this.RequestedByUser.DisplayIndex = 1;
        //this.RequestedByUser.HeaderText = "İsteyen Doktor";
        //this.RequestedByUser.Name = "RequestedByUser";
        //this.RequestedByUser.ReadOnly = true;
        //this.RequestedByUser.Width = 150;

        //this.StateName = new TTVisual.TTTextBoxColumn();
        //this.StateName.DataMember = "StateName";
        //this.StateName.DisplayIndex = 1;
        //this.StateName.HeaderText = "İşlem Durumu";
        //this.StateName.Name = "StateName";
        //this.StateName.ReadOnly = true;
        //this.StateName.Width = 120;

        //this.BarcodeID = new TTVisual.TTTextBoxColumn();
        //this.BarcodeID.DataMember = "BarcodeID";
        //this.BarcodeID.DisplayIndex = 1;
        //this.BarcodeID.HeaderText = "Barkod";
        //this.BarcodeID.Name = "BarcodeID";
        //this.BarcodeID.ReadOnly = true;
        //this.BarcodeID.Width = 110;

        //this.SpecimenID = new TTVisual.TTTextBoxColumn();
        //this.SpecimenID.DataMember = "SpecimenID";
        //this.SpecimenID.DisplayIndex = 1;
        //this.SpecimenID.HeaderText = "Numune No";
        //this.SpecimenID.Name = "SpecimenID";
        //this.SpecimenID.ReadOnly = true;
        //this.SpecimenID.Width = 110;

        //this.TestLOINCCode = new TTVisual.TTTextBoxColumn();
        //this.TestLOINCCode.DataMember = "TestLoincCode";
        //this.TestLOINCCode.DisplayIndex = 1;
        //this.TestLOINCCode.HeaderText = "LOINC Kodu";
        //this.TestLOINCCode.Name = "TestLOINCCode";
        //this.TestLOINCCode.ReadOnly = true;
        //this.TestLOINCCode.Width = 80;

        //this.ProcedureListColumns = [this.IsSelected, this.IsExternalProcedureRequest, this.TestCode, this.LaboratoryTestName, this.RequestDate, this.FromResourceName, this.RequestedByUser, this.StateName, this.BarcodeID, this.SpecimenID, this.TestLOINCCode];


        //TubeInfoColumns

        this.IsTubeSelected = new TTVisual.TTCheckBoxColumn();
        this.IsTubeSelected.DataMember = "";
        this.IsTubeSelected.DisplayIndex = 3;
        this.IsTubeSelected.HeaderText = i18n("M21507", "Seç");
        this.IsTubeSelected.Name = "IsSelected";
        this.IsTubeSelected.Width = 60;


        this.ContainerID = new TTVisual.TTTextBoxColumn();
        this.ContainerID.DataMember = "ContainerID";
        this.ContainerID.DisplayIndex = 1;
        this.ContainerID.HeaderText = i18n("M11536", "Barkod Numarası");
        this.ContainerID.Name = "ContainerID";
        this.ContainerID.ReadOnly = true;
        this.ContainerID.Width = 150;

        this.SpecialHandlingCode = new TTVisual.TTTextBoxColumn();
        this.SpecialHandlingCode.DataMember = "SpecialHandlingCode";
        this.SpecialHandlingCode.DisplayIndex = 1;
        this.SpecialHandlingCode.HeaderText = i18n("M11527", "Barkod Acıklamaları");
        this.SpecialHandlingCode.Name = "SpecialHandlingCode";
        this.SpecialHandlingCode.ReadOnly = true;
        this.SpecialHandlingCode.Width = 350;

        this.OtherEnvFactor = new TTVisual.TTTextBoxColumn();
        this.OtherEnvFactor.DataMember = "OtherEnvFactor";
        this.OtherEnvFactor.DisplayIndex = 1;
        this.OtherEnvFactor.HeaderText = i18n("M11541", "Barkod Tipi");
        this.OtherEnvFactor.Name = "OtherEnvFactor";
        this.OtherEnvFactor.ReadOnly = true;
        this.OtherEnvFactor.Width = 150;

        this.TubeInfoColumns = [this.IsTubeSelected, this.ContainerID, this.SpecialHandlingCode, this.OtherEnvFactor];


        this.txtBarcodeNo = new TTVisual.TTTextBox();
        this.txtBarcodeNo.Name = "txtBarcodeNo";
        this.txtBarcodeNo.Text = "";

    }
  
    public async btnSampleTakingClick() {

        this.loadRequestAcceptingPanelOperation(true, 'İstekler LIS tarafına kaydediliyor, lütfen bekleyiniz.');

        try {
            let inputDVO = new ProcedureInfoInputDVO();
            inputDVO.EpisodeID = this.ViewModel.EpisodeID;
            this.ViewModel.TubeInformationList = Array<TubeInformation>();

            let labProcObjectIDList: Array<string> = new Array<string>();
            for (let vmLabProc of this.ViewModel.LaboratoryProcedureList) {
                if (vmLabProc.isSelected == true) {
                    if (vmLabProc.BarcodeID != null && vmLabProc.BarcodeID.toString() == "" && vmLabProc.StateDefID == "5eaf4c46-c99e-491c-a880-37d07484437e") //Sec ısaretlı ve Istek Kabul asamasında ve barocode u bos ıse
                    {
                        labProcObjectIDList.push(vmLabProc.ObjectID.toString());
                    }
                }
            }

            if (labProcObjectIDList.length > 0) {
                inputDVO.LabProcedures = labProcObjectIDList;

                let that = this;
                let fullApiUrl: string = "api/LaboratoryWorkListService/SampleAcceptToSampleTakingGroupByPatient";
                let result = await this.httpService.post<any>(fullApiUrl, inputDVO, ProcedureInfoOutputDVO) as Array<ProcedureInfoOutputDVO>;

                if (result != null) {
                    for (let resultInfo of result) {
                        for (let testCode of resultInfo.LabProcedures) {
                            for (let lp of this.ViewModel.LaboratoryProcedureList) {
                                if (lp.ObjectID.toString() == testCode.PlacerOrderNumber) {
                                    lp.BarcodeID = testCode.PlacerGroupNumber;
                                    lp.SpecimenID = resultInfo.SpecimenID;
                                    break;
                                }
                            }
                        }

                        for (let tubeInfo of resultInfo.TubeInformations) {
                            let vmTubeInfo: TubeInformation = new TubeInformation();
                            vmTubeInfo.FromResourceName = tubeInfo.FromResourceName;
                            vmTubeInfo.SpecimenID = tubeInfo.SpecimenID;
                            vmTubeInfo.ContainerID = tubeInfo.ContainerID;
                            vmTubeInfo.SpecialHandlingCode = tubeInfo.SpecialHandlingCode;
                            vmTubeInfo.OtherEnvFactor = tubeInfo.OtherEnvFactor;
                            vmTubeInfo.RequestAcceptionDate = tubeInfo.RequestAcceptionDate;

                            this.ViewModel.TubeInformationList.push(vmTubeInfo);

                        }

                    }
                    if (this.ViewModel.TubeInformationList.length > 0)
                        this.showPrintBarcodeButton = true;
                }
            }
            this.loadRequestAcceptingPanelOperation(false, '');
        }
        catch (err) {
            this.loadRequestAcceptingPanelOperation(false, '');
            ServiceLocator.MessageService.showError(err);
        }


    }

    public async btnPrintBarcodeClick() {
        try {
            let idrarAciklama: string = (await SystemParameterService.GetParameterValue('XXXXXXIDRARACIKLAMA', i18n("M10248", "24h ve Spot idrar")));
            for (let vmTubeInfo of this.ViewModel.TubeInformationList) {
                let idrarBarcode: boolean = false;
                let info: LaboratoryBarcodeInfo = new LaboratoryBarcodeInfo();
                info.PatientFullName = this.ViewModel.PatientNameSurname;
                info.PatientTCNo = this.ViewModel.PatientTCNo;
                info.BirthDate = this.ViewModel.PatientBirthDate;
                if (this.ViewModel.isEmergency == true)
                    info.Emergency = "ACİL";
                else
                    info.Emergency = "";

                let fromResInfoArray: Array<string>;
                fromResInfoArray = vmTubeInfo.FromResourceName.split("|");
                info.FromResourceQRef = fromResInfoArray[0];
                info.FromResourceName = fromResInfoArray[1];

                let recDate: Date = (await CommonService.RecTime());
                recDate = plainToClass(Date, recDate);
                info.PrintDate = this.datePipe.transform(recDate, 'dd.MM.yyyy HH:mm');
                info.BarcodeCode = vmTubeInfo.ContainerID;

                let tubeName: string = "";
                let tubeInfoArray: Array<string> = vmTubeInfo.SpecialHandlingCode.split('&');
                if (tubeInfoArray != null) {
                    if (tubeInfoArray.length > 0) {
                        if (tubeInfoArray[2] != null) {
                            //TODO: Kod donmelı XXXXXX ya sorulacak
                            //24h ve Spot idrar tup bilgisinde farkli barcode basiliyor.
                            if (tubeInfoArray[2] == idrarAciklama)
                                idrarBarcode = true;

                            tubeName = tubeName + tubeInfoArray[2];
                            if (tubeInfoArray[4] != null)
                                tubeName = tubeName + ' ' + tubeInfoArray[4];
                        }
                    }
                }
                info.TubeName = tubeName;

                if (idrarBarcode == true)
                    this.barcodePrintService.printAllBarcode(info, "generatePeeLaboratoryBarcode", "printPeeLaboratoryBarcode");
                else
                    this.barcodePrintService.printAllBarcode(info, "generateLaboratoryBarcode", "printLaboratoryBarcode");


            }

            let printResultBarcode: string = (await SystemParameterService.GetParameterValue('PRINTLABRESULTBARCODEAUTOMATICALLY', "FALSE"));
            if (printResultBarcode == "TRUE")
               await this.printResultBarcode();

            let specimenID: any;
            if (this.ViewModel.TubeInformationList.length > 0) {
                let that = this;
                let fullApiUrl: string = "api/LaboratoryWorkListService/UpdateBarcodeDateForSpecimen";
                let result = await this.httpService.post(fullApiUrl, this.ViewModel.TubeInformationList);

                if (specimenID == null)
                    specimenID = this.ViewModel.TubeInformationList[0].SpecimenID;
            }

            if (specimenID != null)
            {
                let that = this;
                let fullApiUrl: string = "api/LaboratoryWorkListService/UpdateSampleDateAsBarcodeDate?specimenID=" + specimenID.toString();
                let result = await this.httpService.get(fullApiUrl);
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    async printResultBarcode() {
        //Sonuc Acıklanma barkodu basılıyor basladı
        let tubeResultDuration: number = 0;
        let tempResultDuration: number;
        let specimenId: string;
        let requestAcceptionDate: Date;
        let requestAcceptionDateStr: string;
        let i: number = 1;

        for (let vmTubeInfo of this.ViewModel.TubeInformationList)
        {
            let tubeInfoArray: Array<string> = vmTubeInfo.SpecialHandlingCode.split('&');
            if (tubeInfoArray != null)
            {
                if (tubeInfoArray.length > 0)
                {
                    specimenId = vmTubeInfo.SpecimenID;
                    if (tubeInfoArray[8] != null && tubeInfoArray[8] != "") {
                        tempResultDuration = <number>Convert.ToDouble(tubeInfoArray[8]);
                        if (i == 1) {
                            
                            if (vmTubeInfo.RequestAcceptionDate != null && vmTubeInfo.RequestAcceptionDate != "")
                            {
                                let datePart1 = vmTubeInfo.RequestAcceptionDate.split(' ')[0];
                                let datePart2 = vmTubeInfo.RequestAcceptionDate.split(' ')[1];
                                requestAcceptionDateStr = datePart1.split('-')[2] + '-' + datePart1.split('-')[1] + '-' + datePart1.split('-')[0] + ' ' + datePart2; // ("yyyy-MM-dd HH:mm");
                                requestAcceptionDate = new Date(requestAcceptionDateStr);

                                tubeResultDuration = <number>Convert.ToDouble(tubeInfoArray[8]);
                                tempResultDuration = <number>Convert.ToDouble(tubeInfoArray[8]);
                            }
                        }
                        else {
                            if (tempResultDuration > tubeResultDuration)
                                tubeResultDuration = tempResultDuration;
                        }
                    }
                }
            }
            i = i + 1;
        }
        //Sonuc Barkod basma hazırlanıyor

        let resultInfo: LaboratoryBarcodeInfo = new LaboratoryBarcodeInfo();
        resultInfo.PatientFullName = this.ViewModel.PatientNameSurname;
        resultInfo.PatientTCNo = this.ViewModel.PatientTCNo;
        resultInfo.BirthDate = this.ViewModel.PatientBirthDate;
        resultInfo.BarcodeCode = specimenId;

        if (tubeResultDuration != 0) {
            //AddHours methodu yoktu asagıdakı satır yazıldı
            let resultDate: Date = new Date(requestAcceptionDate.getTime() + (tubeResultDuration / 60) * 1000 * 60 * 60);
            let resultDay = resultDate.getDay();
            let resultTime = resultDate.getHours();


            //Sonuclanma zamanı Cuma 17:00 dan sonraya gelıyorsa takıp eden Pzt. gunu saat 09:00 a set edılecek.
            //Haftasonu gune denk gelıyorsa o zaman da Pzt. gunu saat 09:00 a set edılecek.
            if (resultDay == 5 && resultTime >= 17)
            {
                resultDate = resultDate.AddDays(3);
                resultDate.setHours(9, 0);
            }
            else if (resultDay == 6)
            {
                resultDate = resultDate.AddDays(2);
                resultDate.setHours(9, 0);
            }
            else if (resultDay == 0)
            {
                resultDate = resultDate.AddDays(1);
                resultDate.setHours(9, 0);
            }
            resultInfo.TubeName = this.datePipe.transform(resultDate, 'dd.MM.yyyy HH:mm');
        }

        this.barcodePrintService.printAllBarcode(resultInfo, "generateLaboratoryBarcode", "printLaboratoryBarcode");

        //Sonuc Acıklanma barkodu basılıyor bitti
    }

    async btnPrintUniqueBarcodeCode_Click(data, row) {
        let idrarAciklama: string = (await SystemParameterService.GetParameterValue('XXXXXXIDRARACIKLAMA', i18n("M10248", "24h ve Spot idrar")));
        for (let vmTubeInfo of this.ViewModel.TubeInformationList) {

            if (row.data.BarcodeID.toString() == vmTubeInfo.ContainerID.toString()) {
                let idrarBarcode: boolean = false;
                let info: LaboratoryBarcodeInfo = new LaboratoryBarcodeInfo();
                info.PatientFullName = this.ViewModel.PatientNameSurname;
                info.PatientTCNo = this.ViewModel.PatientTCNo;
                info.BirthDate = this.ViewModel.PatientBirthDate;
                if (this.ViewModel.isEmergency == true)
                    info.Emergency = "ACİL";
                else
                    info.Emergency = "";

                let fromResInfoArray: Array<string>;
                fromResInfoArray = vmTubeInfo.FromResourceName.split("|");
                info.FromResourceQRef = fromResInfoArray[0];
                info.FromResourceName = fromResInfoArray[1];

                let recDate: Date = (await CommonService.RecTime());
                recDate = plainToClass(Date, recDate);
                info.PrintDate = this.datePipe.transform(recDate, 'dd.MM.yyyy HH:mm');
                info.BarcodeCode = vmTubeInfo.ContainerID;

                let tubeName: string = "";
                let tubeInfoArray: Array<string> = vmTubeInfo.SpecialHandlingCode.split('&');
                if (tubeInfoArray != null)
                    if (tubeInfoArray.length > 0) {
                        if (tubeInfoArray[2] != null) {
                            //TODO: Kod donmelı XXXXXX ya sorulacak
                            //24h ve Spot idrar tup bilgisinde farkli barcode basiliyor.
                            if (tubeInfoArray[2] == idrarAciklama)
                                idrarBarcode = true;

                            tubeName = tubeName + tubeInfoArray[2];
                            if (tubeInfoArray[4] != null)
                                tubeName = tubeName + ' ' + tubeInfoArray[4];
                        }
                    }
                info.TubeName = tubeName;

                if (idrarBarcode == true)
                    this.barcodePrintService.printAllBarcode(info, "generatePeeLaboratoryBarcode", "printPeeLaboratoryBarcode");
                else
                    this.barcodePrintService.printAllBarcode(info, "generateLaboratoryBarcode", "printLaboratoryBarcode");

            }
        }
    }


    async btnPrintTestInstructions_Click(data, row)
    {
          if (row.data.ProcedureInstructionReportName != "" && row.data.ProcedureInstructionReportName != null) {
            let reportName: string = row.data.ProcedureInstructionReportName;
            let reportNameArray: Array<string>;
            reportNameArray = reportName.split("|");

            let subActionProcObjectId: Guid = <any>row.data.ObjectID;
            let subactionProcedure: SubActionProcedure = await this.objectContextService.getObject<SubActionProcedure>(subActionProcObjectId, SubActionProcedure.ObjectDefID);
            for (let repName of reportNameArray) {
                if (repName != null && repName != "")
                {

                    if (repName == "LaboratoryTestPatientInstructionReport") {
                        let testObjectID: string = <any>subactionProcedure['ProcedureObject'];
                        const objectIdParam = new GuidParam(testObjectID);
                        let reportParameters: any = { 'TESTOBJECTID': objectIdParam };
                        this.reportService.showReport(repName, reportParameters);

                    }
                    else
                    {
                        let episodeActionObjectID: string = <any>subactionProcedure['EpisodeAction'];
                        const objectIdParam = new GuidParam(episodeActionObjectID);
                        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                        this.reportService.showReport(repName, reportParameters);
                    }
                }
            }
        }
    }

    public async btnPrintProtocolBarcodeClick() {
        try {
            for (let vmTubeInfo of this.ViewModel.TubeInformationList) {
                let info: LaboratoryBarcodeInfo = new LaboratoryBarcodeInfo();
                info.PatientFullName = this.ViewModel.PatientNameSurname;
                info.PatientTCNo = this.ViewModel.PatientTCNo;
                info.BirthDate = this.ViewModel.PatientBirthDate;

                let fromResInfoArray: Array<string>;
                fromResInfoArray = vmTubeInfo.FromResourceName.split("|");
                info.FromResourceQRef = fromResInfoArray[0];
                info.FromResourceName = fromResInfoArray[1];

                let recDate: Date = (await CommonService.RecTime());
                recDate = plainToClass(Date, recDate);
                info.PrintDate = this.datePipe.transform(recDate, 'dd.MM.yyyy HH:mm');
                info.BarcodeCode = this.ViewModel.PatientID;
                //info.TubeName = vmTubeInfo.SpecialHandlingCode;

                let tubeName: string = "";
                let tubeInfoArray: Array<string> = vmTubeInfo.SpecialHandlingCode.split('&');
                if (tubeInfoArray != null)
                    if (tubeInfoArray.length > 0) {
                        if (tubeInfoArray[2] != null) {
                            tubeName = tubeName + tubeInfoArray[2];
                            if (tubeInfoArray[4] != null)
                                tubeName = tubeName + ' ' + tubeInfoArray[4];
                        }
                    }
                info.TubeName = tubeName;

                this.barcodePrintService.printAllBarcode(info, "generateLaboratoryBarcode", "printLaboratoryBarcode");
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    public async btnProcedureCancelClick() {
        try {
            let inputDVO = new ProcedureInfoInputDVO();
            let labProcObjectIDList: Array<string> = new Array<string>();

            for (let vmLabProc of this.ViewModel.LaboratoryProcedureList) {
                if (vmLabProc.isSelected == true && vmLabProc.StateDefID == "5eaf4c46-c99e-491c-a880-37d07484437e") //Sec ısaretlı ve Istek Kabul asamasında
                {
                    labProcObjectIDList.push(vmLabProc.ObjectID.toString());
                }
            }

            if (labProcObjectIDList.length > 0) {
                inputDVO.LabProcedures = labProcObjectIDList;

                let that = this;
                let fullApiUrl: string = "api/LaboratoryWorkListService/SampleAcceptToCancelled";
                let result = await this.httpService.post(fullApiUrl, inputDVO);
                this.refreshProcedureList();
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }

    }

    public barcodeNoRead(event) {
        let barcodeNo = event.value;
        for (let vmLabProc of this.ViewModel.LaboratoryProcedureList) {
            if (vmLabProc.BarcodeID == barcodeNo) {
                vmLabProc.isSelected = true;

            }
        }
    }
    SampleTakenLaboratoryProcedureList: any;
    labProcObjectIDList: Array<string> = new Array<string>();
    public async btnSampleLaboratoryAcceptClick() {

        this.loadRequestAcceptingPanelOperation(true, 'İstekler Numune Kabul aşamasına geçiriliyor, lütfen bekleyiniz.');
        try {
            let inputDVO = new ProcedureInfoInputDVO();
            inputDVO.LabRequestObjectID = this.ViewModel.LabRequestObjectID;


            if (this.ViewModel != null) {
                for (let vmLabProc of this.ViewModel.LaboratoryProcedureList) {
                    if (vmLabProc.isSelected == true && vmLabProc.StateDefID == "5b6b040c-cea8-4d4f-96d7-f394c9b28f87") //Sec ısaretlı ve Numune Alma asamasında
                    {
                        this.labProcObjectIDList.push(vmLabProc.ObjectID.toString());
                    }
                }

                if (this.labProcObjectIDList.length > 0) {
                    inputDVO.LabProcedures = this.labProcObjectIDList;

                    let that = this;
                    let fullApiUrl: string = "api/LaboratoryWorkListService/SampleTakingToSampleLaboratoryAccept";
                    this.SampleTakenLaboratoryProcedureList = await this.httpService.post(fullApiUrl, inputDVO);
                    this.refreshProcedureList();
                }
            }
            this.loadRequestAcceptingPanelOperation(false, '');
        }
        catch (err) {
            this.loadRequestAcceptingPanelOperation(false, '');
            ServiceLocator.MessageService.showError(err);
        }
    }


    public showSampleAcceptButtons(): boolean {
        //Istek kabul asamasında gorunmesı gereken butonların vısıble olmasını saglar. True ıse gorunur, false ıse  gorunmez.
        if (this.selectedLabStates != null) {
            for (let stateItem of this.selectedLabStates) {
                if (stateItem == "5eaf4c46-c99e-491c-a880-37d07484437e")  //Istek Kabul asaması sorgulanmıs ıse
                {
                    return true;
                }
            }
        }
        return false;
    }

    public showSampleTakingButtons(): boolean {
        //Numune Alma asamasında gorunmesı gereken butonların vısıble olmasını saglar. True ıse gorunur, false ıse  gorunmez.
        if (this.selectedLabStates != null) {
            for (let stateItem of this.selectedLabStates) {
                if (stateItem == "5b6b040c-cea8-4d4f-96d7-f394c9b28f87")  //Numune Alma asaması sorgulanmıs ıse
                {
                    this.showPrintBarcodeButton = true;
                    return true;
                }
            }
        }
        return false;
    }

    public checkAllItemAsSelected(): void {

        for (let lp of this.ViewModel.LaboratoryProcedureList) {
            lp.isSelected = true;
        }
    }

    public async refreshProcedureList() {

        //Is listesindeki listeleme kriterlerine gore  listeyi Episode a  gore tekrar sorgulayip refresh eder.
        try {
            let inputDVO = new QueryInputDVOByEpisode();
            inputDVO.EpisodeID = this.EpisodeID;
            inputDVO.StartDate = this.StartDate;
            inputDVO.EndDate = this.EndDate;
            inputDVO.SelectedWorkListStateItems = this.SelectedWorkListStateItems;
            inputDVO.PatientStatus = this.PatientStatus;

            let that = this;
            let fullApiUrl: string = "api/LaboratoryWorkListService/QueryLaboratoryDetailItemByEpisode";
            let result = await this.httpService.post<LaboratoryWorkListItemMasterModel>(fullApiUrl, inputDVO, LaboratoryWorkListItemMasterModel);

            if (result != null) {
                this.ViewModel = result;
                this.clearDemographicInfo = false;
                this.LabRequestObjectID = result.LabRequestObjectID;
                this.EpisodeID = result.EpisodeID;
                this.PatientTCNo = result.PatientTCNo;
                this.selectedLabStates = result.SelectedLaboratoryStateItems;
                this.txtBarcodeNo.Text = "";
            }
            else {
                this.ViewModel = null;
                this.clearDemographicInfo = true;
                this.LabRequestObjectID = "";
                this.EpisodeID = "";
                this.PatientTCNo = "";
                this.txtBarcodeNo.Text = "";
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    public btnRefreshClick() {
        this.refreshProcedureList();
    }

    async btnPrintExternalProcedureRequestReport_Click(data, row) {

        let labProcEpisodeActionIDList: Array<string> = new Array<string>();
        for (let vmLabProc of this.ViewModel.LaboratoryProcedureList) {
            if (vmLabProc.isExternalProcedureRequest == true) //Dıs Tetkık Istem
            {
                let isExists: Boolean = false;
                for (let eaObjID of labProcEpisodeActionIDList) {
                    if (eaObjID.toString() == vmLabProc.EpisodeActionObjectId.toString()) {
                        isExists = true;
                        break;
                    }

                }
                if (isExists == false)
                    labProcEpisodeActionIDList.push(vmLabProc.EpisodeActionObjectId.toString());
            }
        }

        if (labProcEpisodeActionIDList.length > 0) {
            for (let eaObjectID of labProcEpisodeActionIDList) {

                let episodeActionObjectId: Guid = <any>eaObjectID;
                const objectIdParam = new GuidParam(eaObjectID.toString());
                let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                this.reportService.showReport('ExternalProcedureRequestReportByEpisodeAction', reportParameters);
            }
        }
    }

    loadRequestAcceptingPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

}