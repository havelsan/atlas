//$960276AA
import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { LaboratoryWorkListItemMasterModel, LaboratoryWorkListItemDetailModel, LaboratoryWorkListSubItemDetailModel  } from "./LaboratoryWorkListFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SystemApiService } from 'Fw/Services/SystemApiService';

import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { IBarcodePrinterProvider } from 'app/Barcode/Services/IBarcodePrinterProvider';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { barcodeProviderFactory } from 'app/Barcode/Services/BarcodeProviderFactory';
import { LaboratoryBarcodeInfo } from 'app/Barcode/Models/LaboratoryBarcodeInfo';
import { CommonService } from 'ObjectClassService/CommonService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';


@Component({
    selector: 'laboratory-main-procedure-flows-form',
    templateUrl: './LaboratoryMainProcedureFlowsForm.html',
    providers: [MessageService,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }
]
})
export class LaboratoryMainProcedureFlowsForm implements OnInit, OnDestroy {

    txtSpecimenNo: TTVisual.ITTTextBox;
    ObjectID: TTVisual.ITTTextBoxColumn;
    showPanelTestResultPopup: boolean = false;
    LaboratorySubProcedureList: Array<LaboratoryWorkListSubItemDetailModel>;
    EpisodeID: string;
    PatientTCNo: string;
    LabRequestObjectID: string;
    selectedProcedures: Array<any> = [];
    public ViewModel: LaboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel();

    private _laboratoryWorkListItemMasterModel: LaboratoryWorkListItemMasterModel;
    @Input() set LaboratoryWorkListItemMasterModel(value: LaboratoryWorkListItemMasterModel) {
        this._laboratoryWorkListItemMasterModel = value;
        if (this.LaboratoryWorkListItemMasterModel != null)
        {
            this.ViewModel = this.LaboratoryWorkListItemMasterModel;
            this.LabRequestObjectID = this.LaboratoryWorkListItemMasterModel.LabRequestObjectID;
            this.EpisodeID = this.LaboratoryWorkListItemMasterModel.EpisodeID;
            this.PatientTCNo = this.LaboratoryWorkListItemMasterModel.PatientTCNo;
        }
    }
    get LaboratoryWorkListItemMasterModel(): LaboratoryWorkListItemMasterModel {
        return this._laboratoryWorkListItemMasterModel;
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
            width: 160,
            allowSorting: true,
            cellTemplate: "TestPriorityCellTemplate"
        },
        {
            "caption": i18n("M16694", "İstem Tarihi"),
            dataField: "RequestDate",
            width: 140,
            allowSorting: true
            //cellTemplate: "amountTemplate"
        },
        {
            "caption": i18n("M16697", "İstem Yapan Bölüm"),
            dataField: "FromResourceName",
            width: 180,
            allowSorting: true
        },
        {
            "caption": i18n("M16721", "İsteyen Doktor"),
            dataField: "RequestedByUser",
            width: 140,
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
            width: 90,
            allowSorting: true
        },
        {
            "caption": i18n("M22109", "Sonuç Tarihi"),
            dataField: "ResultDate",
            width: 130,
            allowSorting: true,
            //readonly: false,
            //cellTemplate: "resultDateTemplate"
        },
        {
            "caption": i18n("M22078", "Sonuç"),
            dataField: "Result",
            width: 80,
            allowSorting: true,
            //readonly: false,
            cellTemplate: "resultTemplate"

        },
        {
            "caption": i18n("M27304", "Birim"),
            dataField: "Unit",
            width: 50,
            allowSorting: true,
            //readonly: false,
            //cellTemplate: "unitTemplate"
        },
        {
            "caption": i18n("M21010", "Referans Aralığı"),
            dataField: "Reference",
            width: 100,
            allowSorting: true,
            //readonly: false,
            //cellTemplate: "referenceTemplate"
        },
        {
            "caption": i18n("M19687", "Onay Tarihi"),
            dataField: "ApproveDate",
            width: 130,
            allowSorting: true,
            //readonly: false,
            //cellTemplate: "resultDateTemplate"
        },
        {
            "caption": i18n("M27631", "Barkod Basma Tarihi"),
            dataField: "BarcodePrintDate",
            width: 130,
            allowSorting: true,
            //readonly: false,
            //cellTemplate: "resultDateTemplate"
        },
        {
            "caption": i18n("M19540", "Numune Alma Tarihi"),
            dataField: "SampleDate",
            width: 130,
            allowSorting: true,
            //readonly: false,
            //cellTemplate: "resultDateTemplate"
        },
        {
            "caption": i18n("M27395", "LOINC Kodu"),
            dataField: "TestLoincCode",
            width: 80,
            allowSorting: true
        }
    ];

    public PanelTestProcedureColumns = [
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "TestCode",
            width: 80,
            allowSorting: true
        },
        {
            "caption": i18n("M16821", "İşlem Adı"),
            dataField: "LaboratoryTestName",
            width: 100,
            allowSorting: true
        },
        {
            "caption": "Barkod",
            dataField: "BarcodeID",
            width: 110,
            allowSorting: true
        },
        {
            "caption": i18n("M19543", "Numune No"),
            dataField: "SpecimenID",
            width: 110,
            allowSorting: true
        },
        {
            "caption": i18n("M22078", "Sonuç"),
            dataField: "Result",
            width: 60,
            allowSorting: true
            //cellTemplate: "resultTemplate"

        },
        {
            "caption": i18n("M22078", "Sonuç Açıklaması"),
            dataField: "ResultDescription",
            width: 'auto',
            allowSorting: true
            //cellTemplate: "resultTemplate"

        },
        {
            "caption": "Birim",
            dataField: "Unit",
            width: 60,
            allowSorting: true
            //readonly: false,
            //cellTemplate: "unitTemplate"
        },
        {
            "caption": i18n("M21010", "Referans Aralığı"),
            dataField: "Reference",
            width: 100,
            allowSorting: true
            //readonly: false,
            //cellTemplate: "referenceTemplate"

        }

    ];

    public btnPrintBarcodeDisabled: boolean = true;

    private LaboratoryRequestSampleAcceptionForm_DocumentUrl: string = '/api/LaboratoryWorkListService/LaboratoryMainProcedureFlowsForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, protected helpMenuService: HelpMenuService, private sideBarMenuService: ISidebarMenuService, private barcodePrintService: IBarcodePrintService, private reportService: AtlasReportService) {
        this.initFormControls();
    }

    public initViewModel(): void {

    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let tetkikbilgigetir = new DynamicSidebarMenuItem();
        tetkikbilgigetir.key = 'tetkikbilgigetir';
        tetkikbilgigetir.icon = 'fa fa fa-pencil-square-o';
        tetkikbilgigetir.label = 'LIS/Tetkik Bilgi Güncelle';
        tetkikbilgigetir.componentInstance = this.helpMenuService;
        tetkikbilgigetir.clickFunction = this.helpMenuService.getLISTestDefinitions;
        this.sideBarMenuService.addMenu('YardimciMenu', tetkikbilgigetir);
    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('tetkikbilgigetir');
    }

    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();

    }

   public async openPanelTestResultView(row) {

        this.showPanelTestResultPopup = true;
        this.LaboratorySubProcedureList = new Array<LaboratoryWorkListSubItemDetailModel>();

        let that = this;
        let labProc: LaboratoryWorkListItemDetailModel = row.data;
        let fullApiUrl: string = "api/LaboratoryWorkListService/GetPanelSubTestsInfo?LaboratoryProcedureObjectID=" + labProc.ObjectID.toString();
        let result = await this.httpService.get<any>(fullApiUrl, LaboratoryWorkListSubItemDetailModel) as Array<LaboratoryWorkListSubItemDetailModel>;
        if (result != null)
            this.LaboratorySubProcedureList = result;
    }

    public resultDescPopup: boolean = false;
    public resultDescValue: string = "";
    public openResultDescription(row){
        this.resultDescPopup = true;
        this.resultDescValue = row.data.ResultDescription;
    }

    ngOnInit(): void {
        this.initFormControls();
        this.AddHelpMenu();
    }

    public initFormControls(): void {

        this.txtSpecimenNo = new TTVisual.TTTextBox();
        this.txtSpecimenNo.Name = "txtSpecimenNo";
        this.txtSpecimenNo.Text = "";


    }


    public async specimenNoRead(event) {
        //let specimenNo = event.value;
        //let inputDVO = new ProcedureInfoInputDVO();
        //let labProcObjectIDList: Array<string> = new Array<string>();

        //for (let vmLabProc of this.ViewModel.LaboratoryProcedureList) {
        //    if (vmLabProc.isSelected == true) //Sec ısaretlı ve Numune Alma asamasında
        //    {
        //        labProcObjectIDList.push(vmLabProc.ObjectID.toString());
        //    }
        //}

        //    inputDVO.LabProcedures = labProcObjectIDList;
        //    inputDVO.EpisodeID = this.ViewModel.EpisodeID;
        //    inputDVO.SpecimenID = specimenNo;  //test ıcın specimenID bılgısı gonderılıyor

        //    let that = this;
        //    let fullApiUrl: string = "api/LaboratoryWorkListService/AskResultsFromLISBySpecimenID";
        //    let result = await this.httpService.post(fullApiUrl, inputDVO);
    }

    public async testDefinitionRead(event) {

        let that = this;
        let fullApiUrl: string = "api/LaboratoryWorkListService/ReadTestDefinitionInfoFromLIS";
        let result = await this.httpService.get(fullApiUrl);
    }

    onResultDateChanged(data, row) {
        if (row != null && row.data != null) {
            if (data.value != null)
                row.data.ResultDate = data.value;
        }
    }

    onResultChanged(data, row) {
        if (row != null && row.data != null) {
            if (data.value != null)
                row.data.Result = data.value;
        }
    }

    onUnitChanged(data, row) {
        if (row != null && row.data != null) {
            if (data.value != null)
                row.data.Unit = data.value;
        }
    }

    onReferenceChanged(data, row) {
        if (row != null && row.data != null) {
            if (data.value != null)
                row.data.Reference = data.value;
        }
    }

    focusLost(text: any, data: any) {
        if (!text || text == '') {
            let index: number;
            for (index = 0; index < this.selectedProcedures.length; index++) {
                if (this.selectedProcedures[index].ObjectID == data.ObjectID) {
                        this.selectedProcedures.splice(index, 1);
                        data.Selected = false;
                        break;
                }
            }
        }
        else {
            data.Selected = true;
            this.selectedProcedures.push(data);
        }
    }

    isResultFieldsDisable(data: any): boolean
    {
        //if (data.isPanelTest)
        //    return true;
        //else
        //{
            if (data.StateDefID == '481dd196-b418-4114-b4f7-becd7e7703c4') //Laboratuvarda asamasında ıse edıtable olacak
                return false;
            if (data.StateDefID == 'a52a30e0-6ac7-4224-aa58-a994397c22f6' || data.StateDefID == '4ec1ba21-422f-4b75-9769-cf46961171eb' || data.StateDefID == 'fc30e081-5b67-4564-99fd-17f75e57a1b2' || data.StateDefID == '71d49852-7f5d-440e-af57-7e70522fb867') //sonuclandi, red, iptal ve onay asamalarinda disable oalcak'
                return true;
        //}

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

                let fromResInfoArray: Array<string>;
                fromResInfoArray = vmTubeInfo.FromResourceName.split("|");
                info.FromResourceQRef = fromResInfoArray[0];
                info.FromResourceName = fromResInfoArray[1];

                let recDate: Date = (await CommonService.RecTime());
                recDate = plainToClass(Date, recDate);
                info.PrintDate = recDate.toLocaleDateString() + " " + recDate.toLocaleTimeString();
                info.BarcodeCode = vmTubeInfo.ContainerID;

                let tubeName: string = "";
                let tubeInfoArray: Array<string> = vmTubeInfo.SpecialHandlingCode.split('&');
                if (tubeInfoArray != null)
                    if (tubeInfoArray.length > 0) {
                        if (tubeInfoArray[2] != null)
                        {
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
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    async btnPrintUniqueBarcodeCode_Click(data, row)
{
        let idrarAciklama: string = (await SystemParameterService.GetParameterValue('XXXXXXIDRARACIKLAMA', i18n("M10248", "24h ve Spot idrar")));
        for (let vmTubeInfo of this.ViewModel.TubeInformationList)
        {

            if (row.data.BarcodeID.toString() == vmTubeInfo.ContainerID.toString()) {
                let idrarBarcode: boolean = false;
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
                info.PrintDate = recDate.toLocaleDateString() + " " + recDate.toLocaleTimeString();
                info.BarcodeCode = vmTubeInfo.ContainerID;

                let tubeName: string = "";
                let tubeInfoArray: Array<string> = vmTubeInfo.SpecialHandlingCode.split('&');
                if (tubeInfoArray != null)
                    if (tubeInfoArray.length > 0) {
                        if (tubeInfoArray[2] != null)
                        {
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


    public async btnGetReadyResultsFromLISClick() {

        let that = this;
        let fullApiUrl: string = "api/LaboratoryWorkListService/GetReadyResultsFromLIS";
        let result = await this.httpService.get(fullApiUrl);

    }

    public async btnPrintResultReportClick()
    {
        let that = this;

        //Gecıs surecındekı ısleyıs sorunundan dolayı hepsının Sonuclandı olması kontrolu kaldırıldı. 12/09/2017
        //let allResulted: boolean = true;
        //for (let vmLabProc of that.ViewModel.LaboratoryProcedureList)
        //{
        //    if (vmLabProc.StateDefID.toString() != 'a52a30e0-6ac7-4224-aa58-a994397c22f6') {
        //        allResulted = false
        //        break;
        //    }
        //}

        //if (allResulted == true)
        //{

            let specimenIDList: Array<string> = new Array<string>();
            for (let vmTubeInfo of that.ViewModel.TubeInformationList) {
                let isFound: boolean = false;
                for (let specimenID of specimenIDList) {
                    if (specimenID.toString() == vmTubeInfo.SpecimenID.toString()) {
                        isFound = true;
                        break;
                    }
                }

                if (isFound == false)
                    specimenIDList.push(vmTubeInfo.SpecimenID.toString());

            }

            if (specimenIDList.length > 0) {
                for (let specimenID of specimenIDList) {
                    let fullApiUrl: string = "api/ProcedureRequestService/";

                    await this.httpService.get<string>(fullApiUrl + "GetReportURLFromLISBySpecimenID?specimenID=" + specimenID.toString() + "&patientTCNo=" + that.ViewModel.PatientTCNo.toString())
                        .then(result => {
                            if (result != null) {
                                let win = window.open(result, '_blank');
                                win.focus();
                            }
                        })
                        .catch(error => {
                            console.log(error);
                        });
                }
            }
        //}
        //else
        //    InfoBox.Alert("Hastanın tüm testleri Sonuçlandı aşamasına geçmediğinden rapor alınamamaktadır!");

    }
    async btnPrintExternalProcedureRequestReport_Click()
    {

        let isExternalProcedureExists: Boolean = false;
        for (let vmLabProc of this.ViewModel.LaboratoryProcedureList) {
            if (vmLabProc.isExternalProcedureRequest == true) //Dıs Tetkık Istem
            {
                isExternalProcedureExists = true;
                break;
            }
        }

        if (isExternalProcedureExists == false)
            InfoBox.Alert(i18n("M23343", "Tetkiklerin içinde Dış İstem tetkik bulunmamaktadır."));
        else {
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
    }

    public async UndoLastTransition_SelectedLaboratoryProcedure()
    {
        for (let lp of this.ViewModel.LaboratoryProcedureList)
        {
            if (lp.isSelected == true && lp.ObjectID != null)
            {
                if (lp.StateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.Cancelled.toString() ) //Cancelled state
                    ServiceLocator.MessageService.showError(i18n("M25311", "Bu işlem geri alınamaz."));
                else
                {

                    let message: string = lp.RequestDate + i18n("M22853", " tarihli ") + lp.LaboratoryTestName.toString() + i18n("M16911", " işlemi ");
                    let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'İşlem Geri Alma',
                        message + i18n("M14750", "geri alınacaktır.Devam etmek istediğinize emin misiniz? "));
                    if (result === 'V') {
                        ServiceLocator.MessageService.showSuccess(i18n("M14753", "Geri Alma İşleminden Vazgeçildi"));
                    }
                    else {
                        let that = this;
                        let _DocumentServiceUrl: string = "/api/LaboratoryWorkListService/UndoLastTransitionLabProcedureByObjectId?ObjectId=" + lp.ObjectID.toString();
                        this.httpService.get(_DocumentServiceUrl)
                            .then(result => {
                                ServiceLocator.MessageService.showSuccess(message + i18n("M14752", "geri alınmıştır"));
                            }).catch(err => {
                                ServiceLocator.MessageService.showError(message + i18n("M14751", "geri alınamamıştır.") + err);
                            });
                    }
                }
            }
        }

    }
    public async Cancel_SelectedLaboratoryProcedure()
    {
        for (let lp of this.ViewModel.LaboratoryProcedureList) {
            if (lp.isSelected == true && lp.ObjectID != null)
            {
                if (lp.StateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.SampleAccept.toString() || lp.StateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.SampleTaking.toString() || lp.StateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.SampleLaboratoryAccept.toString())
                {
                    let message: string = lp.RequestDate + i18n("M22853", " tarihli ") + lp.LaboratoryTestName.toString() + i18n("M16911", " işlemi ");
                    let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M16855", "İşlem İptali"),
                        message + "iptal edilecektir.Devam etmek istediğinize emin misiniz? ");
                    if (result === 'V') {
                        ServiceLocator.MessageService.showSuccess(i18n("M16556", "İptal İşleminden Vazgeçildi"));
                    }
                    else {
                        let that = this;
                        let _DocumentServiceUrl: string = "/api/LaboratoryWorkListService/CancelLabProcedureByObjectId?ObjectId=" + lp.ObjectID.toString();
                        this.httpService.get(_DocumentServiceUrl)
                            .then(result => {
                                ServiceLocator.MessageService.showSuccess(message + "iptal edilmiştir.");
                            }).catch(err => {
                                ServiceLocator.MessageService.showError(message + i18n("M16539", "iptal edilememiştir.") + err);
                            });


                    }
                }
                else
                {
                    ServiceLocator.MessageService.showSuccess("İstek Kabul/Numune Alma/Numune Kabul aşaması dışındaki işlemler LIS tarafından iptal edilmelidir. İşlem buradan iptal edilemez.");
                }

            }
        }

    }
}