//$4D8B5779
import { Component, OnInit, ViewChild } from '@angular/core';
import {
    InvoiceSEPFormViewModel, InvoiceSEPDiagnoseListModel, InvoiceSEPListModel, InvoiceSEPTransactionListModel,
    TakipDVO, HizmetOkuCevapModel, BasvuruTakipOkuCevapDVO, faturaOkuCevapDTO, doktorAraCevapDVO, DoktorAraGirisDVO, TesisYatakSorguGirisDVO, IlacAraGirisDVO, ilacAraCevapDVO, tesisYatakSorguCevapDVO, LoadInvoiceFormPartitions, InvoiceSEPEpicrisisDetailModel, NewProcedureModel, AddNewProcedureViewModel, InvoiceLogModel, InvoiceBlockingModel,
    HastaYatisOkuCevapDVO, FazlaTakipBilgileriDTO, VefatKayitBilgileriDTO, FazlaTakipDTO, getSutRuleEngineResultCodes_Model, FTRTedaviRaporuOkuDTO, FTRTedaviRaporuOkuDTOList, IlacRaporuOkuDTO, IlacRaporuOkuDTOList, SuitableFTRTransaction, SearchProtocolNoModel, UTSMaterialDTO, UXXXXXXesinlestirmeSorguDTO, UXXXXXXesinlestirmeSorguSonucDTO, DocumentOperationsModel, MedulaTakipDokumanSorguSonucModel, MedulaTakipDokumanSorguModel, MedulaDokumanIslemModel, MedulaTakipDokumanModel, BarcodeSUTMatchModel, ENabizBildirimHizmetModel, InfoModel
} from './InvoiceSEPFormViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { ITTTextBox } from 'NebulaClient/Visual/ControlInterfaces/ITTTextBox';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';
import { PayerTypeEnum, SendToENabizEnum, SurgeryLeftRight } from 'NebulaClient/Model/AtlasClientModel';
import { HorizontalAlignment } from 'NebulaClient/Utils/Enums/HorizontalAlignment';
import { InputFormat } from 'NebulaClient/Utils/Enums/InputFormat';
import { SubEpisodeProtocolService } from 'NebulaClient/Services/ObjectService/SubEpisodeProtocolService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { AccountTransaction } from 'NebulaClient/Model/AtlasClientModel';
import { SEPDiagnosis } from 'NebulaClient/Model/AtlasClientModel';
import { MedulaResult, SEPInvoiceStatusDictionary, listboxObject, ForbiddenSUTOperation } from './InvoiceHelperModel';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { ComboListItem } from 'NebulaClient/Visual/ComboListItem';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ITTObjectListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTObjectListBox';
import { ITTValueListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTValueListBox';
import { AtlasReportService } from '../Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DatePipe } from '@angular/common';
import { DxDataGridComponent, DxAccordionComponent } from 'devextreme-angular';
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicComponentInfoDVO } from 'Fw/Models/DynamicComponentInfoDVO';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { StringParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { InfoBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { TestResultQueryInputDVO } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { InvoiceTabSerivce } from './InvoiceTabSerivce';
import { InvoiceAllInOneTabService } from './InvoiceAllInOneTabService';
import { Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { CommonHelper } from 'app/Helper/CommonHelper';


@Component({
    selector: 'invoice-sep-form',
    templateUrl: './InvoiceSEPForm.html',
    providers: [AtlasReportService, DatePipe, SystemApiService]
})
export class InvoiceSEPForm extends BaseComponent<any> implements OnInit {

    rtfDescription: TTVisual.ITTRichTextBoxControl;

    @ViewChild('transactionGrid') trxGridInstance: DxDataGridComponent;
    @ViewChild('diagnosisGrid') diaGridInstance: DxDataGridComponent;
    @ViewChild('patientSEPListGrid') patientSEPGridInstance: DxDataGridComponent;
    @ViewChild('epicrisisGrid') epicGridInstance: DxDataGridComponent;

    @ViewChild('detailFormAccordion') detailFormAccordionInstance: DxAccordionComponent;


    public accordionTitle: string = "";
    public titleProtocol: string = "";
    public titleDate: string = "";
    public titleStatus: string = "";
    public titleProvision: string = "";
    public titleSection: string = "";
    public titleTedaviTuruKodu: string = "";
    public prevObjectID: Guid = Guid.Empty;
    public nextObjectID: Guid = Guid.Empty;
    public searchTextKabulNo: string = "";

    public invoiceSEPFormViewModel: InvoiceSEPFormViewModel;
    public formOpenPayerType: number;

    public InvoiceTypesSelectedItems: any[] = [];

    public isSGK: boolean;
    public isSGKManuel: boolean;
    public isResmi: boolean;
    public isPayerTypeHospital: boolean;
    public hasProvision: boolean;
    public invoiced: boolean;
    public mainSEPInvoiceStatus: string;

    public tedaviTuruArray: Array<any> = [];
    public provizyonTipiArray: Array<any> = [];
    public tedaviTipiArray: Array<any> = [];
    public takipTipiArray: Array<any> = [];
    public bransArray: Array<any> = [];
    public payerArray: Array<any> = [];
    public protocolArray: Array<any> = [];

    public devredilenKurumArray: Array<any> = [];
    public istisnaiHalArray: Array<any> = [];
    public sigortaliTuruArray: Array<any> = [];
    public doctorArray: Array<any> = [];
    public ozelDurumArray: Array<any> = [];
    public kesiArray: Array<any> = [];
    public triageArray: Array<any> = [];
    public taburcuKoduArray: Array<any> = [];

    public ilacArray: Array<any> = [];
    public Nabiz700StatusArray: Array<any> = [{ Id: 0, Name: "Yeni" }, { Id: 1, Name: "Başarılı" }, { Id: 2, Name: "Hatalı" }];
    InvoiceSEPListColumns = [];
    InvoiceTransactionListColumns = [];

    public selectedTransactions: Array<InvoiceSEPTransactionListModel> = [];
    public selectedTransaction: InvoiceSEPTransactionListModel = new InvoiceSEPTransactionListModel();
    public selectedDiagnosis: Array<InvoiceSEPDiagnoseListModel> = [];
    public selectedUTSMaterials: Array<UTSMaterialDTO> = [];
    public selectedSEPs: Array<InvoiceSEPListModel> = [];
    public selectedEpicrisis: Array<InvoiceSEPEpicrisisDetailModel> = [];
    public inpatientDateCheck: boolean = false;
    public disChargeDateCheck: boolean = false;

    public showProvisionPopup = false;
    public showSGKHizmetSorgulamaPopup = false;
    public showTransactionReadPopup = false;
    public showApplicationNoReadPopup = false;
    public showBagliTakipAlPopup = false;
    public showReadInvoicePopup = false;
    public showTransactionXMLReadPopup = false;
    public showUpdateDescriptionPopup = false;
    public showHistoryPopup = false;
    public showInvoiceBlockingPopup = false;
    public showMedulaInpatientOpPopup = false;
    public showMedulaExtraProvisionPopup = false;
    public showMedulaDoctorSearchPopup = false;
    public showMedulaBedSearchPopup = false;
    public showMedulaTedaviRaporuOkuPopup = false;
    public showMedulaIlacRaporuOkuPopup = false;
    public showMedulaDrugSearchPopup = false;
    public showAfterInvoiceSUTControlPopup = false;
    public showMedulaErrorMessagePopup = false;
    public showUTSUsageCommitmentPopup = false;
    public showExaminationPopup = false;
    public showDocumentOperationsPopup = false;
    public showBarcodeSUTMatchPopup = false;
    public showENabizBildirimSorguPopup = false;
    public showMaterialPurchaseInfoPopup = false;

    public changePayerPopup = false;
    public addPayerPopup = false;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public bagliTakipArray: Array<any> = [];
    public bagliTakipNo: string = '';
    public bagliTakipAlinacakSEPid: any;

    public readProvisionResultArray: Array<TakipDVO> = [];
    public HistoryGridArray: Array<InvoiceLogModel> = [];
    public AfterInvoiceOperationArray: Array<ForbiddenSUTOperation> = [];
    public InvoiceBlockingGridArray: Array<InvoiceBlockingModel> = [];
    public MedulaInpatientInfo: HastaYatisOkuCevapDVO;
    public MedulaExtraProvisionInfo: FazlaTakipBilgileriDTO = new FazlaTakipBilgileriDTO();
    public MedulaVefatKayitInfo: VefatKayitBilgileriDTO = new VefatKayitBilgileriDTO();
    public readApplicationNoResultArray: BasvuruTakipOkuCevapDVO;
    public readInvoiceResultArray: faturaOkuCevapDTO;
    public newInvoiceBlockingDescription: string;
    public DoktorAraCevapDVO: doktorAraCevapDVO;
    public DoktorAraGirisSearchModel: DoktorAraGirisDVO = new DoktorAraGirisDVO();
    public TesisYatakSorguSearchModel: TesisYatakSorguGirisDVO = new TesisYatakSorguGirisDVO();
    public TesisYatakSorguCevapDVO: tesisYatakSorguCevapDVO;
    public IlacAraGirisSearchModel: IlacAraGirisDVO = new IlacAraGirisDVO();
    public IlacAraCevapDVO: ilacAraCevapDVO = new ilacAraCevapDVO();
    public MaterialPurchaseInfoArray: Array<InfoModel> = [];

    public readHizmetResult: HizmetOkuCevapModel;

    public readTransactionXMLResult: string;
    public updateDescription: string;
    public viewLISResultURL: string = "";

    public documentOperationsModel: DocumentOperationsModel;
    public barcodeSUTMatch: BarcodeSUTMatchModel;
    public eNabizBildirimHizmetArray: Array<ENabizBildirimHizmetModel>;

    //public BottomGridHeight: number;

    menuData = [];

    resizeDateVariable: Date;


    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    txtText: ITTTextBox = <ITTTextBox>{
        Visible: true,
        ReadOnly: true,
        CharacterCasing: CharacterCasing.Lower,
        TextAlign: HorizontalAlignment.Left,
        InputFormat: InputFormat.AlphaOnly
    };


    constructor(private datePipe: DatePipe,
        protected http: NeHttpService,
        private medulaDefinition: GetMedulaDefinitionService,
        private invoiceAllInOneCommService: InvoiceAllInOneTabService,
        private invoiceTabService: InvoiceTabSerivce,
        services: ServiceContainer,
        private reportService: AtlasReportService,
        public systemApiService: SystemApiService,
        public modalService: IModalService,
        private http2: AtlasHttpService) {

        super(services);
        this.invoiceSEPFormViewModel = new InvoiceSEPFormViewModel();
        this.showProvisionPopup = false;
        this.showTransactionReadPopup = false;
        this.showApplicationNoReadPopup = false;
        this.showBagliTakipAlPopup = false;
        this.showReadInvoicePopup = false;

        this.rtfDescription = new TTVisual.TTRichTextBoxControl();
        this.rtfDescription.DisplayText = i18n("M18742", "Medula Epikriz Bilgisi");
        this.rtfDescription.TemplateGroupName = i18n("M18742", "Medula Epikriz Bilgisi");
        this.rtfDescription.Iconized = true;
        this.rtfDescription.BackColor = "#FFFFFF";
        this.rtfDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.rtfDescription.Name = "rtfDescription";
        this.rtfDescription.TabIndex = 2;

        this.DoktorAraCevapDVO = new doktorAraCevapDVO();


        // $(window).resize(x => {
        //     this.BottomGridHeight = parseInt($('#invoice-sepform-bottom-grid-container').css('height')) - 65;
        // });
        // $(window).ready(x => {
        //     this.BottomGridHeight = parseInt($('#invoice-sepform-bottom-grid-container').css('height'))- 65;
        // });
    }


    public hizmetlerTabClick(event: any) {
        this.resizeDateVariable = new Date();
    }

    public getTedaviTuruKodu(objectID: Guid): string {
        let tt = this.tedaviTuruArray.find(key => key.ObjectID === objectID);
        if (tt != null && tt != undefined)
            return tt.Code;
        else
            return "";
    }

    InvoiceSEPTransactionList: DataSource;

    ngOnInit(): void {
        let comingObjectID = this.RouteData.ObjectID;
        this.formOpenPayerType = this.RouteData.Type;
        this.invoiceSEPFormViewModel.MainSEP = new Guid(comingObjectID);

        this.showProvisionPopup = false;
        this.showTransactionReadPopup = false;

        let loadPartitions: Array<number> = new Array<number>();

        loadPartitions.push(LoadInvoiceFormPartitions.MainSEP);
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPMaster);
        //loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);
        loadPartitions.push(LoadInvoiceFormPartitions.PatientSEPList);
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis); 		//Epikriz


        this.lifm.id = this.invoiceSEPFormViewModel.MainSEP;
        this.lifm.type = this.formOpenPayerType;
        this.lifm.loadPartitions = loadPartitions;


        let apiUrlForInvoiceTerms: string = '/api/InvoiceApi/InvoiceForm';
        let apiUrlForInvoiceTransactionList: string = '/api/InvoiceApi/GetColumnAndOrder?gridName=TransactionList&pageName=InvoiceSEPForm';



        let that = this;
        //console.log(this.RouteData);
        let promiseArray: Array<Promise<any>> = new Array<any>();
        let localArray: any = [];
        let localTransArray: any = [];
        promiseArray.push(this.medulaDefinition.TedaviTuru());
        promiseArray.push(this.medulaDefinition.ProvizyonTipi());
        promiseArray.push(this.medulaDefinition.TedaviTipi());
        promiseArray.push(this.medulaDefinition.TakipTipi());
        promiseArray.push(this.medulaDefinition.Brans());
        promiseArray.push(this.medulaDefinition.DevredilenKurum());
        promiseArray.push(this.medulaDefinition.IstisnaiHal());
        promiseArray.push(this.medulaDefinition.SigortaliTuru());
        promiseArray.push(this.medulaDefinition.Doctor());
        promiseArray.push(this.medulaDefinition.OzelDurum());
        promiseArray.push(this.medulaDefinition.Kesi());
        promiseArray.push(this.medulaDefinition.Triage());
        promiseArray.push(that.http.post(apiUrlForInvoiceTerms, this.lifm));
        promiseArray.push(that.http.get(apiUrlForInvoiceTransactionList));

        Promise.all(promiseArray).then((sonuc: Array<any>) => {

            that.tedaviTuruArray = sonuc[0];
            that.provizyonTipiArray = sonuc[1];
            that.tedaviTipiArray = sonuc[2];
            that.takipTipiArray = sonuc[3];
            that.bransArray = sonuc[4];
            that.devredilenKurumArray = sonuc[5];
            that.istisnaiHalArray = sonuc[6];
            that.sigortaliTuruArray = sonuc[7];
            that.doctorArray = sonuc[8];
            that.ozelDurumArray = sonuc[9];
            that.kesiArray = sonuc[10];
            that.triageArray = sonuc[11];
            that.GenerateTransactionColumns(sonuc[13]);
            that.GenerateAddNewProcedureColumns();
            that.GenerateSEPListColumns();
            that.invoiceSEPFormViewModel = sonuc[12];
            that.prepareEpicrisisDescription();

            for (let i = 0; i < that.invoiceSEPFormViewModel.InvoiceTypes.length; i++) {
                if (that.invoiceSEPFormViewModel.InvoiceTypes[i].id == that.formOpenPayerType)
                    localArray.push(that.invoiceSEPFormViewModel.InvoiceTypes[i]);
            }
            that.InvoiceTypesSelectedItems = localArray;

            for (let i = 0; i < that.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
                if (that.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID == that.invoiceSEPFormViewModel.MainSEP)
                    that.selectedSEPs.push(that.invoiceSEPFormViewModel.InvoiceSEPList[i]);
            }

            that.showSEPDescriptions();

            //Bu blok Ücretli hastalarda kullanıcı seçtiği işlem satırlarını kaybetmemek ve tekrar seçili olarak getibilmek için yazılmış.
            if (that.formOpenPayerType == PayerTypeEnum.Paid) {
                // for (let i = 0; i < that.invoiceSEPFormViewModel.InvoiceSEPTransactionList.length; i++) {
                //     if (that.invoiceSEPFormViewModel.InvoiceSEPTransactionList[i].CurrentStateDefID == AccountTransaction.AccountTransactionStates.Paid)
                //         localTransArray.push(that.invoiceSEPFormViewModel.InvoiceSEPTransactionList[i]);
                // }
                // that.selectedTransactions = localTransArray;

                for (let i = 0; i < that.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
                    if (that.invoiceSEPFormViewModel.InvoiceSEPList[i].SelectedTransactionList != null && that.invoiceSEPFormViewModel.InvoiceSEPList[i].SelectedTransactionList.length > 0)
                        that.invoiceSEPFormViewModel.InvoiceSEPList[i].SelectedTransactionList.Clear();

                    if (that.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID == this.invoiceSEPFormViewModel.MainSEP) {
                        for (let j = 0; j < that.selectedTransactions.length; j++) {
                            that.invoiceSEPFormViewModel.InvoiceSEPList[i].SelectedTransactionList.push(that.selectedTransactions[j]);
                        }
                    }
                }
            }
            //Bu blok Ücretli hastalarda kullanıcı seçtiği işlem satırlarını kaybetmemek ve tekrar seçili olarak getibilmek için yazılmış.


            that.enableDisableSEPDetail();
            that.enableDisableSEPList();

            //DEVex 17.2.6 sürümüne geçince kullanılacak.
            this.accordionTitle = this.invoiceSEPFormViewModel.InvoiceSEPMaster.NameAndSurname + "  " +
                this.invoiceSEPFormViewModel.InvoiceSEPMaster.UniqueRefNo + "  " +
                this.invoiceSEPFormViewModel.InvoiceSEPMaster.BirthDate + "  " +
                this.invoiceSEPFormViewModel.InvoiceSEPMaster.PayerType.Name + "  " +
                this.invoiceSEPFormViewModel.InvoiceSEPMaster.Payer.Name;


            for (let i = 0; i < that.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
                if (that.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID == that.invoiceSEPFormViewModel.MainSEP) {
                    that.titleProtocol = that.invoiceSEPFormViewModel.InvoiceSEPList[i].KabulNo;
                    that.titleDate = that.datePipe.transform(that.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaProvizyonTarihi, 'dd.MM.yyyy');
                    that.titleStatus = that.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus;
                    that.titleProvision = that.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo;
                    that.titleSection = that.invoiceSEPFormViewModel.InvoiceSEPList[i].SubEpisodeResSection;
                    that.titleTedaviTuruKodu = that.getTedaviTuruKodu(that.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTedaviTuru);

                    if (that.invoiceSEPFormViewModel.InvoiceSEPList.length == 1) {
                        that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID;
                        that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID;
                    }
                    else if (that.invoiceSEPFormViewModel.InvoiceSEPList.length == 2) {
                        if (i == 0) {
                            that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[1].ObjectID;
                            that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[1].ObjectID;
                        }
                        else if (i == 1) {
                            that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[0].ObjectID;
                            that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[0].ObjectID;
                        }
                    }
                    else if (that.invoiceSEPFormViewModel.InvoiceSEPList.length > 2) {
                        if (i == 0) {
                            that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[that.invoiceSEPFormViewModel.InvoiceSEPList.length - 1].ObjectID;
                            that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i + 1].ObjectID;
                        }
                        else if (i == that.invoiceSEPFormViewModel.InvoiceSEPList.length - 1) {
                            that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i - 1].ObjectID;
                            that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[0].ObjectID;
                        }
                        else {
                            that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i - 1].ObjectID;
                            that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i + 1].ObjectID;
                        }
                    }
                }
            }

            that.InvoiceSEPTransactionList = new DataSource({
                store: new CustomStore({
                    //key: "ObjectID",
                    load: async (loadOptions: any) => {
                        //if (Object.prototype.hasOwnProperty.call(loadOptions, 'select') == false) {

                        loadOptions.Params = {
                            LoadInvoiceFormModel: this.lifm,
                        }

                        let res = await this.http.post<any>('/api/InvoiceApi/LoadInvoiceFormGrid', loadOptions);
                        if (that.formOpenPayerType == PayerTypeEnum.Paid) {
                            for (let i = 0; i < res.data.length; i++) {
                                if (res.data[i].CurrentStateDefID == AccountTransaction.AccountTransactionStates.Paid)
                                    localTransArray.push(res.data[i]);
                            }
                            that.selectedTransactions = localTransArray;
                        }
                        return res;
                        //}
                        // else {
                        //     let res = { data: this.InvoiceSEPResultList.items(), totalCount: this.InvoiceSEPResultList.totalCount(), groupCount: this.InvoiceSEPResultList.group.length }
                        //     return res;
                        // }
                    },
                    update: async (key, values) => {
                        // console.log(key);
                        // console.log(values);
                    }
                }),
                paginate: true,
                pageSize: 50
            });

        }).catch(error => {
            that.errorHandlerForInvoiceForm(error);
        });
    }

    ngAfterViewInit(): void {
        this.detailFormAccordionInstance.instance.expandItem(0);
    }

    enterSearchKeyPress(event: any): void {
        if (event.charCode === 13) {

            let takipAlUrl = '/api/InvoiceApi/getSEPObjectIDFromProtocolNo?protocolNo=' + this.searchTextKabulNo;

            let that = this;
            let loadPartitions: Array<number> = new Array<number>();

            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPMaster);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);
            loadPartitions.push(LoadInvoiceFormPartitions.PatientSEPList);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis); 		//Epikriz

            this.http.get<SearchProtocolNoModel>(takipAlUrl).then(response => {
                //that.LoadFromSEP(response, loadPartitions);

                let detailOpenParameters: any = {};
                detailOpenParameters.ObjectID = response.SEPObjectID;
                detailOpenParameters.Type = this.RouteData.Type;

                this.invoiceTabService.tabMessage.next({ Params: detailOpenParameters, Title: response.ProtocolNo + ' ' + response.Name + ' ' + response.Surname });


            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });

            return;
        }
    }
    lifm: any = {};
    async LoadFromSEP(sepID: any, loadPartitions: Array<number>): Promise<void> {
        //this.loadPanelOperation(true, "Veriler yükleniyor, lütfen bekleyiniz.");

        //if (this.selectedTransactions.length > 0)
        //    this.selectedTransactions.Clear();

        //if (this.selectedDiagnosis.length > 0)
        //    this.selectedDiagnosis.Clear();

        //if (this.selectedSEPs.length > 0)
        //    this.selectedSEPs.Clear();

        this.lifm.id = sepID;
        this.lifm.type = this.formOpenPayerType;
        this.lifm.loadPartitions = loadPartitions;

        this.loadPanelOperation(true, "Kabul bilgileri yükleniyor. Lütfen bekleyiniz");
        let apiUrlForInvoiceTerms: string = '/api/InvoiceApi/InvoiceForm';

        try {


            let response = await this.http.post<InvoiceSEPFormViewModel>(apiUrlForInvoiceTerms, this.lifm);

            for (let partition of loadPartitions) {
                if (partition == LoadInvoiceFormPartitions.MainSEP)
                    this.invoiceSEPFormViewModel.MainSEP = response.MainSEP;
                else if (partition == LoadInvoiceFormPartitions.InvoiceSEPMaster)
                    this.invoiceSEPFormViewModel.InvoiceSEPMaster = response.InvoiceSEPMaster;
                else if (partition == LoadInvoiceFormPartitions.InvoiceSEPDetail)
                    this.invoiceSEPFormViewModel.InvoiceSEPDetail = response.InvoiceSEPDetail;
                else if (partition == LoadInvoiceFormPartitions.InvoiceSEPList) {
                    this.invoiceSEPFormViewModel.InvoiceSEPList = response.InvoiceSEPList;

                    for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
                        if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID == sepID) {
                            this.selectedSEPs = [];
                            this.selectedSEPs.push(this.invoiceSEPFormViewModel.InvoiceSEPList[i]);
                            break;
                        }
                    }
                }
                else if (partition == LoadInvoiceFormPartitions.InvoiceSEPTransactionList)
                    this.InvoiceSEPTransactionList.reload();
                //this.invoiceSEPFormViewModel.InvoiceSEPTransactionList = response.InvoiceSEPTransactionList;
                else if (partition == LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList)
                    this.invoiceSEPFormViewModel.InvoiceSEPDiagnoseList = response.InvoiceSEPDiagnoseList;
                else if (partition == LoadInvoiceFormPartitions.PatientSEPList)
                    this.invoiceSEPFormViewModel.PatientSEPList = response.PatientSEPList;
                else if (partition == LoadInvoiceFormPartitions.InvoiceSEPEpicrisis)
                    this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis = response.InvoiceSEPEpicrisis;

                this.invoiceSEPFormViewModel.InvoiceTypes = response.InvoiceTypes;
                let localArray: any = [];
                for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceTypes.length; i++) {
                    if (this.invoiceSEPFormViewModel.InvoiceTypes[i].id == this.formOpenPayerType)
                        localArray.push(this.invoiceSEPFormViewModel.InvoiceTypes[i]);
                }
                this.InvoiceTypesSelectedItems = localArray;


                //DEVex 17.2.6 sürümüne geçince kullanılacak.
                this.accordionTitle = this.invoiceSEPFormViewModel.InvoiceSEPMaster.NameAndSurname + "  " +
                    this.invoiceSEPFormViewModel.InvoiceSEPMaster.UniqueRefNo + "  " +
                    this.invoiceSEPFormViewModel.InvoiceSEPMaster.BirthDate + "  " +
                    this.invoiceSEPFormViewModel.InvoiceSEPMaster.PayerType.Name + "  " +
                    this.invoiceSEPFormViewModel.InvoiceSEPMaster.Payer.Name;

                for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
                    if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID == this.invoiceSEPFormViewModel.MainSEP) {
                        this.titleProtocol = this.invoiceSEPFormViewModel.InvoiceSEPList[i].KabulNo;
                        this.titleDate = this.datePipe.transform(this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaProvizyonTarihi, 'dd.MM.yyyy');
                        this.titleStatus = this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus;
                        this.titleProvision = this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo;
                        this.titleSection = this.invoiceSEPFormViewModel.InvoiceSEPList[i].SubEpisodeResSection;
                        this.titleTedaviTuruKodu = this.getTedaviTuruKodu(this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTedaviTuru);
                        let that = this;
                        if (that.invoiceSEPFormViewModel.InvoiceSEPList.length == 1) {
                            that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID;
                            that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID;
                        }
                        else if (that.invoiceSEPFormViewModel.InvoiceSEPList.length == 2) {
                            if (i == 0) {
                                that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[1].ObjectID;
                                that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[1].ObjectID;
                            }
                            else if (i == 1) {
                                that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[0].ObjectID;
                                that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[0].ObjectID;
                            }
                        }
                        else if (that.invoiceSEPFormViewModel.InvoiceSEPList.length > 2) {
                            if (i == 0) {
                                that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[that.invoiceSEPFormViewModel.InvoiceSEPList.length - 1].ObjectID;
                                that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i + 1].ObjectID;
                            }
                            else if (i == that.invoiceSEPFormViewModel.InvoiceSEPList.length - 1) {
                                that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i - 1].ObjectID;
                                that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[0].ObjectID;
                            }
                            else {
                                that.prevObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i - 1].ObjectID;
                                that.nextObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i + 1].ObjectID;
                            }
                        }
                    }
                }

            }

            this.enableDisableSEPDetail();
            this.loadPanelOperation(false, "");
        } catch (e) {
            this.errorHandlerForInvoiceForm(e);
        }


    }

    enableDisableSEPDetail(): void {


        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            if (this.invoiceSEPFormViewModel.MainSEP === this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID) {

                this.mainSEPInvoiceStatus = this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus;

                if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo !== '' && this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo !== null && this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo !== undefined)
                    this.hasProvision = true;
                else
                    this.hasProvision = false;

                if (this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.Invoiced || this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.InvoiceInconsistent)
                    this.invoiced = true;
                else
                    this.invoiced = false;

                if (this.invoiceSEPFormViewModel.InvoiceSEPMaster.PayerType.Code === '0' && this.formOpenPayerType != PayerTypeEnum.Paid)
                    this.isSGK = true;
                else
                    this.isSGK = false;

                if (this.invoiceSEPFormViewModel.InvoiceSEPMaster.PayerType.Code === '6' && this.formOpenPayerType != PayerTypeEnum.Paid)
                    this.isSGKManuel = true;
                else
                    this.isSGKManuel = false;

                if (this.invoiceSEPFormViewModel.InvoiceSEPMaster.PayerType.Code === '3' && this.formOpenPayerType != PayerTypeEnum.Paid)
                    this.isResmi = true;
                else
                    this.isResmi = false;

                if (this.invoiceSEPFormViewModel.InvoiceSEPMaster.PayerType.Code === '5' && this.formOpenPayerType != PayerTypeEnum.Paid)
                    this.isPayerTypeHospital = true;
                else
                    this.isPayerTypeHospital = false;

                this.GenerateTopMenu();

                break;
            }
        }
        this.inpatientDateCheck = false;
        this.disChargeDateCheck = false;
    }

    enableDisableSEPList(): void {

    }




    taniKayit(st: Array<any>): void {
        //if (st.length > 20) {
        //    ServiceLocator.MessageService.showInfo('En fazla 20 tanı gönderilebilir.');
        //    return;
        //}
        this.loadPanelOperation(true, i18n("M22762", "Tanı kayıt işlemi yapılıyor, lütfen bekleyiniz."));
        let apiUrlForTaniKayit: string = '/api/InvoiceDiagnosisContextMenuApi/taniKayit';

        this.http.post(apiUrlForTaniKayit, st).then(response => {

            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    taniKayitIptal(st: Array<any>): void {
        //if (st.length > 20) {
        //    ServiceLocator.MessageService.showInfo('En fazla 20 tanı gönderilebilir.');
        //    return;
        //}
        this.loadPanelOperation(true, i18n("M22761", "Tanı kayıt iptal işlemi yapılıyor, lütfen bekleyiniz."));
        let model: any = {};

        model.SEPObjectID = this.invoiceSEPFormViewModel.MainSEP;
        model.DiagnoseList = st;

        let apiUrlForTaniKayit: string = '/api/InvoiceDiagnosisContextMenuApi/taniKayitIptal';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }


    taniDurumGuncelle(st: Array<any>, state: boolean): void {
        this.loadPanelOperation(true, i18n("M22743", "Tanı durumu güncelleniyor, lütfen bekleyiniz."));
        let apiUrlForTaniKayit: string = '/api/InvoiceDiagnosisContextMenuApi/taniDurumGuncelle?state=' + state;

        this.http.post(apiUrlForTaniKayit, st).then(response => {

            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }


    hizmetKayit(st: Array<any>): void {
        //if (st.length > 20) {
        //    ServiceLocator.MessageService.showInfo('En fazla 20 hizmet gönderilebilir.');
        //    return;
        //}
        this.loadPanelOperation(true, i18n("M15888", "Hizmet kayıt işlemi yapılıyor, lütfen bekleyiniz."));
        let apiUrlForTransactionHizmetKayit: string = '/api/InvoiceTransactionContextMenuApi/hizmetKayit';

        this.http.post(apiUrlForTransactionHizmetKayit, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
            this.errorHandlerForInvoiceForm(error);
        });
    }

    hizmetKayitIptal(st: Array<any>): void {
        //if (st.length > 20) {
        //    ServiceLocator.MessageService.showInfo('En fazla 20 hizmet gönderilebilir.');
        //    return;
        //}
        let Ishkim: any = {};

        Ishkim.SEPObjectID = this.invoiceSEPFormViewModel.MainSEP;
        Ishkim.TransactionList = st;
        this.loadPanelOperation(true, i18n("M15887", "Hizmet kayıt iptal işlemi yapılıyor, lütfen bekleyiniz."));
        let apiUrlForTransactionHizmetKayit: string = '/api/InvoiceTransactionContextMenuApi/hizmetKayitIptal';

        this.http.post(apiUrlForTransactionHizmetKayit, Ishkim).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);

        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    takipBazliHizmetKayitOku(): void {

        let provisionNo: string = '';
        this.hizmetKayitOku(null, this.invoiceSEPFormViewModel.MainSEP);

    }

    public showAddDiagnosisPopup = false;
    public GridDiagnosisGridList: Array<DiagnosisGrid>;

    onClickShowAddDiagnosis(): void {
        this.GridDiagnosisGridList = new Array<DiagnosisGrid>();
        this.showAddDiagnosisPopup = true;
    }

    onClickAddDiagnosis(): void {

        let apiUrlForAddDiagnosis: string = '/api/InvoiceDiagnosisContextMenuApi/addDiagnosis?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.loadPanelOperation(true, i18n("M15839", "Hizmet durumu güncelleme işlemi yapılıyor, lütfen bekleyiniz."));

        let tempDiaList: Array<InvoiceSEPDiagnoseListModel> = new Array<InvoiceSEPDiagnoseListModel>();
        for (let dg of this.GridDiagnosisGridList) {
            let tempDia: InvoiceSEPDiagnoseListModel = new InvoiceSEPDiagnoseListModel();
            tempDia.Diagnose = dg.Diagnose;
            if (dg.DiagnosisType != null)
                tempDia.DiagnosisType = dg.DiagnosisType.toString();
            tempDia.IsMainDiagnose = dg.IsMainDiagnose;
            tempDiaList.push(tempDia);
        }


        this.http.post(apiUrlForAddDiagnosis, tempDiaList).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
            this.showAddDiagnosisPopup = false;
        }).catch(error => {
            this.showAddDiagnosisPopup = false;
            this.errorHandlerForInvoiceForm(error);
        });
    }

    hizmetKayitOku(st: Array<any>, sepObjectID: Guid): void {

        let apiUrlForTransactionHizmetKayitOku: string = '/api/InvoiceTransactionContextMenuApi/hizmetKayitOku?sepObjectID=' + sepObjectID;
        this.loadPanelOperation(true, i18n("M15890", "Hizmet kayıt oku işlemi yapılıyor, lütfen bekleyiniz."));
        this.http.post<HizmetOkuCevapModel>(apiUrlForTransactionHizmetKayitOku, st).
            then(response => {
                this.loadPanelOperation(false, '');
                this.showTransactionReadPopup = true;
                this.readHizmetResult = response;
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }




    hizmetDurumGuncelle(st: Array<any>, state: boolean): void {

        let apiUrlForTransactionHizmetKayit: string = '/api/InvoiceTransactionContextMenuApi/hizmetDurumGuncelle?state=' + state;
        this.loadPanelOperation(true, i18n("M15839", "Hizmet durumu güncelleme işlemi yapılıyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForTransactionHizmetKayit, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    hizmetDahillikGuncelle(st: Array<any>, state: boolean): void {

        let apiUrlForTransactionHizmetKayit: string = '/api/InvoiceTransactionContextMenuApi/hizmetDahillikGuncelle?state=' + state;
        this.loadPanelOperation(true, i18n("M15833", "Hizmet dahillik güncelleme işlemi yapılıyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForTransactionHizmetKayit, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    async updateSEPDischargeTypeFromTopMenu(): Promise<void> {
        let that = this;
        let taburcuKoduList: Array<ComboListItem> = [];
        this.taburcuKoduArray = await this.medulaDefinition.TaburcuKodu();

        for (let i = 0; i < this.taburcuKoduArray.length; i++) {
            taburcuKoduList.push(new ComboListItem(this.taburcuKoduArray[i].ObjectID, this.taburcuKoduArray[i].Name));
        }

        let tk: ComboListItem = await InputForm.GetValueListItem("Taburcu Kodu Seçiniz.", taburcuKoduList);

        if (tk.DataValue !== '' && tk.DataValue !== null && tk.DataValue !== undefined)
            this.updateSEPDischargeType(that.invoiceSEPFormViewModel.MainSEP, tk.DataValue.toString());
    }


    public updateSEPDischargeType(sepID: Guid, _tk: string): void {

        let usd: any = {};
        usd.sepObjectID = sepID;
        usd.taburcuKodu = _tk;

        let apiUrlForUpdateDate: string = '/api/InvoiceTopMenuApi/updateSEPDischargeType';

        this.loadPanelOperation(true, i18n("M15921", "Taburcu kodu güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateDate, usd).then(response => {
            if (response)
                ServiceLocator.MessageService.showSuccess("Taburcu kodu başarı ile güncellendi.");

            this.loadPanelOperation(false, "");
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });

    }


    async mustehaklikSorgusuFromTopMenu(): Promise<void> {
        let a: any = await InputForm.GetDateTime(i18n("M19360", "Müstehaklığın Sorgulanacağı Tarihi Giriniz."));
        this.mustehaklikSorgusu(this.datePipe.transform(a, 'dd.MM.yyyy'));
    }



    public mustehaklikTarihi: any;

    mustehaklikSorgusuFromChangePayerForm(): void {
        this.mustehaklikSorgusu(this.datePipe.transform(this.mustehaklikTarihi, 'dd.MM.yyyy'));
    }

    mustehaklikSorgusu(date: string): void {

        let takipAlUrl = '/api/InvoiceTopMenuApi/mustehaklikSorgusu?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP + '&date=' + date;

        this.loadPanelOperation(true, i18n("M19363", "Müstehaklık sorgusu yapılıyor, lütfen bekleyiniz."));
        let that = this;
        this.http.get<MedulaResult>(takipAlUrl).then(response => {
            this.loadPanelOperation(false, '');
            if (response.Succes)
                ServiceLocator.MessageService.showSuccess(response.SonucMesaji);
            else
                ServiceLocator.MessageService.showError(response.SonucMesaji);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });

    }

    async tarihGuncelleFromContextMenu(st: Array<any>): Promise<void> {

        let a: any = await InputForm.GetDateTime(i18n("M22840", "Tarih Seçiniz."));

        this.tarihGuncelle(st, this.datePipe.transform(a, 'dd.MM.yyyy'));
    }

    tarihGuncelle(st: Array<any>, date: string): void {

        let apiUrlForUpdateDate: string = '/api/InvoiceTransactionContextMenuApi/tarihGuncelle?date=' + date;

        this.loadPanelOperation(true, i18n("M15921", "Hizmet Tarihi güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateDate, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    fiyatGuncelle(st: Array<any>, price: string): void {

        let apiUrlForUpdateDate: string = '/api/InvoiceTransactionContextMenuApi/fiyatGuncelle?price=' + price;

        this.loadPanelOperation(true, i18n("M15832", "Hizmet birim fiyatı güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateDate, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    hizmetRaporNoGuncelle(st: Array<any>, reportNo: string): void {

        let apiUrlForUpdateReportNo: string = '/api/InvoiceTransactionContextMenuApi/medulaRaporNoGuncelle?raporNo=' + reportNo;

        this.loadPanelOperation(true, i18n("M15903", "Hizmet rapor numarası güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateReportNo, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    medulaAccessionNoGuncelle(st: Array<any>, accessionNo: string): void {

        let apiUrlForUpdateAccessionNo: string = '/api/InvoiceTransactionContextMenuApi/medulaAccessionNoGuncelle?accessionNo=' + accessionNo;

        this.loadPanelOperation(true, i18n("M15903", "Accession No güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateAccessionNo, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    medulaBayiNoGuncelle(st: Array<any>, bayiNo: string): void {

        let apiUrlForUpdateBayiNo: string = '/api/InvoiceTransactionContextMenuApi/medulaBayiNoGuncelle?bayiNo=' + bayiNo;

        this.loadPanelOperation(true, i18n("M15903", "Bayi No güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateBayiNo, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    medulaYatakNoGuncelle(st: Array<any>, yatakNo: string): void {

        let apiUrlForUpdateReportNo: string = '/api/InvoiceTransactionContextMenuApi/medulaYatakNoGuncelle?yatakNo=' + yatakNo;

        this.loadPanelOperation(true, i18n("M15931", "Hizmet yatak numarası güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateReportNo, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    async hizmetRaporNoGuncelleFromContextMenu(st: Array<any>): Promise<void> {
        let reportNo: string = await InputForm.GetText(i18n("M20825", "Rapor Numarası Giriniz."));

        if (reportNo !== '' && reportNo !== null && reportNo !== undefined)
            this.hizmetRaporNoGuncelle(st, reportNo);
    }

    async accessionNoGuncelleFromContextMenu(st: Array<any>): Promise<void> {
        let accessionNo: string = await InputForm.GetText(i18n("M20825", "Accession No Giriniz."));

        if (accessionNo !== '' && accessionNo !== null && accessionNo !== undefined)
            this.medulaAccessionNoGuncelle(st, accessionNo);
    }

    async bayiNoGuncelleFromContextMenu(st: Array<any>): Promise<void> {
        let bayiNo: string = await InputForm.GetText(i18n("M20825", "Bayi No Giriniz."));

        if (bayiNo !== '' && bayiNo !== null && bayiNo !== undefined)
            this.medulaBayiNoGuncelle(st, bayiNo);
    }

    async hizmetMedulaYatakNoGuncelleFromContextMenu(st: Array<any>): Promise<void> {
        let yatakNo: string = await InputForm.GetText(i18n("M18831", "Medula Yatak Numarası Giriniz."));

        if (yatakNo !== '' && yatakNo !== null && yatakNo !== undefined)
            this.medulaYatakNoGuncelle(st, yatakNo);
    }

    async doktorGuncelleFromContextMenu(st: Array<any>): Promise<void> {

        let doctorsList: Array<ComboListItem> = [];

        for (let i = 0; i < this.doctorArray.length; i++) {
            doctorsList.push(new ComboListItem(this.doctorArray[i].ObjectID, this.doctorArray[i].Name));
        }

        let doctor: ComboListItem = await InputForm.GetValueListItem(i18n("M13201", "Doktor Seçiniz."), doctorsList);

        if (doctor.DataValue !== '' && doctor.DataValue !== null && doctor.DataValue !== undefined)
            this.doktorGuncelle(st, doctor.DataValue.toString());


    }

    doktorGuncelle(st: Array<any>, doctor: string): void {

        let apiUrlForUpdateDate: string = '/api/InvoiceTransactionContextMenuApi/doktorGuncelle?doctor=' + doctor;

        this.loadPanelOperation(true, i18n("M15838", "Hizmet doktor bilgisi güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateDate, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }
    /*AAE*/
    async satinAlmaTarihiGuncelleFromContextMenu(st: Array<any>): Promise<void> {

        let a: any = await InputForm.GetDateTime(i18n("M21337", "Satın Alma Tarihi Giriniz."));
        if (a != null)
            this.satinAlmaTarihiGuncelle(st, this.datePipe.transform(a, 'dd.MM.yyyy'));
    }

    satinAlmaTarihiGuncelle(st: Array<any>, date: string): void {

        let apiUrlForUpdateDate: string = '/api/InvoiceTransactionContextMenuApi/satinAlmaTarihiGuncelle?date=' + date;

        this.loadPanelOperation(true, i18n("M21338", "Satın Alma Tarihi güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateDate, st).then(response => {
            this.loadPanelOperation(false, '');
            //let loadPartitions: Array<number> = new Array<number>();
            //loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            //loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            //loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
            //this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);

        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    async barkodGuncelleFromContextMenu(st: Array<any>): Promise<void> {


        let barkod: string = await InputForm.GetText(i18n("M11529", "Barkod Bilgisi Giriniz."));

        if (barkod !== '' && barkod !== null && barkod !== undefined)
            this.barkodGuncelle(st, barkod);
    }

    barkodGuncelle(st: Array<any>, barkod: string): void {

        let apiUrlForUpdateDate: string = '/api/InvoiceTransactionContextMenuApi/barkodGuncelle?barkod=' + barkod;

        this.loadPanelOperation(true, i18n("M11530", "Barkod bilgisi güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateDate, st).then(response => {
            this.loadPanelOperation(false, '');
            //let loadPartitions: Array<number> = new Array<number>();
            //loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            //loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            //loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
            //this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);

        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    async medulaAciklamaGuncelleFromContextMenu(st: Array<any>): Promise<void> {

        if (st.length != 1) {
            ServiceLocator.MessageService.showError(i18n("M10473", "Açıklama bilgisi tek seferde sadece 1 adet hizmet satırı için girilebilir."));
            return;
        }

        this.selectedTransaction = st[0];
        let apiUrlForUpdateDate: string = '/api/InvoiceTransactionContextMenuApi/getMedulaAciklama?acctrx=' + st[0].ObjectID;

        this.loadPanelOperation(true, i18n("M10471", "Açıklama bilgisi getiriliyor, lütfen bekleyiniz."));

        this.http.get<string>(apiUrlForUpdateDate).then(response => {
            this.loadPanelOperation(false, '');
            this.updateDescription = response;
            this.showUpdateDescriptionPopup = true;
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    async firmaTanimlayiciNumarasiGuncelleFromContextMenu(st: Array<any>): Promise<void> {


        let barkod: string = await InputForm.GetText(i18n("M14321", "Firma Tanımlayıcı Numarası Giriniz."));

        if (barkod !== '' && barkod !== null && barkod !== undefined)
            this.firmaTanimlayiciNumarasiGuncelle(st, barkod);
    }

    firmaTanimlayiciNumarasiGuncelle(st: Array<any>, barkod: string): void {

        let apiUrlForUpdateDate: string = '/api/InvoiceTransactionContextMenuApi/firmaTanimlayiciNumarasiGuncelle?fTNo=' + barkod;

        this.loadPanelOperation(true, i18n("M14323", "Firma tanımlayıcı numarası güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateDate, st).then(response => {
            this.loadPanelOperation(false, '');
            //let loadPartitions: Array<number> = new Array<number>();
            //loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            //loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            //loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
            //this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);

        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }
    /*AAE*/

    async altVakaGuncelleFromContextMenu(st: Array<any>): Promise<void> {

        let altVakaListesi: Array<ComboListItem> = [];

        let apiUrlForgetRule: string = '/api/InvoiceTransactionContextMenuApi/getSEPListFromUniqueRefNo?UniqueRefNo=' + this.invoiceSEPFormViewModel.InvoiceSEPMaster.UniqueRefNo;

        let x = await this.http.get<Array<ComboListItem>>(apiUrlForgetRule);

        for (let item of x) {
            altVakaListesi.push(new ComboListItem(item.DataValue, item.DisplayText));
        }



        let altVaka: ComboListItem = await InputForm.GetValueListItem(i18n("M10762", "Alt Vaka Seçiniz."), altVakaListesi);

        if (altVaka.DataValue !== '' && altVaka.DataValue !== null && altVaka.DataValue !== undefined)
            this.altVakaGuncelle(st, altVaka.DataValue);
    }

    altVakaGuncelle(st: Array<any>, altVaka: any): void {

        let apiUrlForUpdateAltVaka: string = '/api/InvoiceTransactionContextMenuApi/altVakaGuncelle?altVaka=' + altVaka;

        this.loadPanelOperation(true, i18n("M10759", "Alt vaka güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateAltVaka, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }
    async ozelDurumGuncelleFromContextMenu(st: Array<any>): Promise<void> {

        let ozelDurumlar: Array<ComboListItem> = [];

        for (let i = 0; i < this.ozelDurumArray.length; i++) {
            ozelDurumlar.push(new ComboListItem(this.ozelDurumArray[i].ObjectID, this.ozelDurumArray[i].Name));
        }

        let ozelDurum: ComboListItem = await InputForm.GetValueListItem(i18n("M20087", "Özel Durum Seçiniz."), ozelDurumlar);

        if (ozelDurum.DataValue !== '' && ozelDurum.DataValue !== null && ozelDurum.DataValue !== undefined)
            this.ozelDurumGuncelle(st, ozelDurum.DataValue);
    }

    ozelDurumGuncelle(st: Array<any>, ozelDurum: any): void {

        let apiUrlForUpdateOzelDurum: string = '/api/InvoiceTransactionContextMenuApi/ozelDurumGuncelle?ozelDurum=' + ozelDurum;

        this.loadPanelOperation(true, i18n("M20084", "Özel Durum güncelleniyor, lütfen bekleyiniz."));

        this.http.post(apiUrlForUpdateOzelDurum, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler


            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    async kesiGuncelleFromContextMenu(st: Array<any>): Promise<void> {

        let kesiList: Array<ComboListItem> = [];

        for (let i = 0; i < this.kesiArray.length; i++) {
            kesiList.push(new ComboListItem(this.kesiArray[i].ObjectID, this.kesiArray[i].Name));
        }

        let kesi: ComboListItem = await InputForm.GetValueListItem('Kesi Seçiniz.', kesiList);

        if (kesi.DataValue !== '' && kesi.DataValue !== null && kesi.DataValue !== undefined)
            this.kesiGuncelle(st, kesi.DataValue);
    }

    kesiGuncelle(st: Array<any>, kesi: any): void {

        let apiUrlForUpdateKesi: string = '/api/InvoiceTransactionContextMenuApi/kesiGuncelle?kesi=' + kesi;

        this.loadPanelOperation(true, 'Kesi bilgisi güncelleniyor, lütfen bekleyiniz.');

        this.http.post(apiUrlForUpdateKesi, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    sagSolGuncelle(st: Array<any>, sagSolEnum: number): void {

        let apiUrlForUpdateSasgSol: string = '/api/InvoiceTransactionContextMenuApi/sagSolGuncelle?sagSolEnum=' + sagSolEnum;

        this.loadPanelOperation(true, 'Kesi bilgisi güncelleniyor, lütfen bekleyiniz.');

        this.http.post(apiUrlForUpdateSasgSol, st).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    hizmetXMLOkuFromContextMenu(st: Array<any>): void {
        let apiUrlForhizmetXMLOku: string = '/api/InvoiceTransactionContextMenuApi/hizmetXMLOku';
        this.loadPanelOperation(true, i18n("M24218", "XML Oku işlemi yapılıyor, lütfen bekleyiniz."));
        this.http.post<string>(apiUrlForhizmetXMLOku, st).
            then(response => {
                this.loadPanelOperation(false, '');
                this.showTransactionXMLReadPopup = true;
                this.readTransactionXMLResult = response;
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    malzemeSatinalmaBilgileriFromContextMenu(actTrx: any) {
        let apiUrlMaterial: string = '/api/InvoiceTransactionContextMenuApi/malzemeSatinalmaBilgileri?trxObjectID=' + actTrx;
        this.http.get<Array<InfoModel>>(apiUrlMaterial)
            .then(result => {
                this.MaterialPurchaseInfoArray = result;
                this.showMaterialPurchaseInfoPopup = true;
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    onRowValidatingSEPList(event: any): void {
        //TODD: AAE burada eğer varsa validation yapılacak.
    }

    takipAlFromTopMenu(): void {
        this.takipAl(this.invoiceSEPFormViewModel.MainSEP, '');
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    errorHandlerForInvoiceForm(message: string): void {
        this.loadPanelOperation(false, '');
        ServiceLocator.MessageService.showError(message);
        console.log(message);
    }

    takipAl(sepID: any, bagliTakipNo: string): void {
        this.loadPanelOperation(true, i18n("M22635", "Takip alınıyor, lütfen bekleyiniz."));

        let that = this;
        let takipAlUrl = '';
        if (bagliTakipNo === '')
            takipAlUrl = '/api/InvoiceTopMenuApi/takipAl?sepObjectID=' + sepID;
        else
            takipAlUrl = '/api/InvoiceTopMenuApi/takipAl?sepObjectID=' + sepID + '&bagliTakipNo=' + bagliTakipNo;

        this.http.get<MedulaResult>(takipAlUrl)
            .then(result => {
                this.loadPanelOperation(false, '');
                if (result.Succes) {
                    let loadPartitions: Array<number> = new Array<number>();

                    loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi

                    that.LoadFromSEP(sepID, loadPartitions).then(x => {
                        ServiceLocator.MessageService.showSuccess(result.SonucKodu + ' - ' + result.SonucMesaji);
                    });

                }
                else {
                    that.invoiceSEPFormViewModel.InvoiceSEPDetail.MedulaSonucMesaji = '[' + result.SonucKodu + '] ' + result.SonucMesaji;
                    ServiceLocator.MessageService.showError(result.SonucKodu + ' - ' + result.SonucMesaji);
                }
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    topluTakipAlFromTopMenu(): void {
        this.loadPanelOperation(true, 'Toplu takip alınıyor, lütfen bekleyiniz.');
        let sepID = this.invoiceSEPFormViewModel.MainSEP;
        let that = this;

        let takipAlUrl = '/api/InvoiceTopMenuApi/topluTakipAl?sepObjectID=' + sepID;

        this.http.get<MedulaResult>(takipAlUrl)
            .then(result => {
                this.loadPanelOperation(false, '');
                if (result.Succes) {
                    let loadPartitions: Array<number> = new Array<number>();

                    loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi

                    that.LoadFromSEP(sepID, loadPartitions).then(x => {
                        ServiceLocator.MessageService.showSuccess(result.SonucKodu + ' - ' + result.SonucMesaji);
                    });

                }
                else {
                    that.invoiceSEPFormViewModel.InvoiceSEPDetail.MedulaSonucMesaji = '[' + result.SonucKodu + '] ' + result.SonucMesaji;
                    ServiceLocator.MessageService.showError(result.SonucKodu + ' - ' + result.SonucMesaji);
                }
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    takipSilFromTopMenu(): void {
        this.takipSilConfirm(this.invoiceSEPFormViewModel.MainSEP);
    }

    takipSilConfirm(sepID: any): void {

        this.loadPanelOperation(true, i18n("M22669", "Takip siliniyor, lütfen bekleyiniz."));
        let that = this;
        let takipSilUrl = '/api/InvoiceTopMenuApi/takipSilConfirm?sepObjectID=' + sepID;
        this.http.get<MedulaResult>(takipSilUrl)
            .then(result => {

                if (result.Succes) {
                    if (result.SonucMesaji == "")
                        that.takipSil(sepID);
                    else if (result.SonucMesaji != "" && result.SonucKodu == "Confirm") {
                        ShowBox.Show(ShowBoxTypeEnum.Message, "&Takibi Sil,&Vazgeç", "T,V", i18n("M23735", "Uyarı"), i18n("M22670", "Takip Silme Onayı"), result.SonucMesaji).then(result1 => {

                            if (result1 === 'T')
                                that.takipSil(sepID);
                            else {
                                this.loadPanelOperation(false, '');
                                return;
                            }
                        });
                    }
                }
                else {
                    this.loadPanelOperation(false, '');
                    ServiceLocator.MessageService.showError(result.SonucMesaji);
                }
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    takipSil(sepID: any): void {
        this.loadPanelOperation(true, i18n("M22669", "Takip siliniyor, lütfen bekleyiniz."));
        let that = this;
        let takipSilUrl = '/api/InvoiceTopMenuApi/takipSil?sepObjectID=' + sepID;
        this.http.get<MedulaResult>(takipSilUrl)
            .then(result => {
                this.loadPanelOperation(false, '');
                if (result.Succes) {
                    let loadPartitions: Array<number> = new Array<number>();

                    loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler

                    that.LoadFromSEP(sepID, loadPartitions).then(x => {
                        ServiceLocator.MessageService.showSuccess(result.SonucKodu + ' - ' + result.SonucMesaji);
                    });
                }
                else {
                    that.invoiceSEPFormViewModel.InvoiceSEPDetail.MedulaSonucMesaji = '[' + result.SonucKodu + '] ' + result.SonucMesaji;
                    ServiceLocator.MessageService.showError(result.SonucKodu + ' - ' + result.SonucMesaji);
                }

            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    topluTakipSilFromTopMenu(): void {
        let sepID = this.invoiceSEPFormViewModel.MainSEP;

        this.loadPanelOperation(true, 'Tüm takipler siliniyor, lütfen bekleyiniz.');
        let that = this;
        let takipSilUrl = '/api/InvoiceTopMenuApi/topluTakipSil?sepObjectID=' + sepID;
        this.http.get<MedulaResult>(takipSilUrl)
            .then(result => {
                this.loadPanelOperation(false, '');
                if (result.Succes) {
                    let loadPartitions: Array<number> = new Array<number>();

                    loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler

                    that.LoadFromSEP(sepID, loadPartitions).then(x => {
                        ServiceLocator.MessageService.showSuccess(result.SonucKodu + ' - ' + result.SonucMesaji);
                    });
                }
                else {
                    that.invoiceSEPFormViewModel.InvoiceSEPDetail.MedulaSonucMesaji = '[' + result.SonucKodu + '] ' + result.SonucMesaji;
                    ServiceLocator.MessageService.showError(result.SonucKodu + ' - ' + result.SonucMesaji);
                }

            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    takipBazliHizmetKayit(sepIDs: Array<any>): void {
        if (sepIDs.length > 0) {
            this.loadPanelOperation(true, i18n("M15892", "Hizmet kayıt yapılıyor, lütfen bekleyiniz."));
            let that = this;
            let tom: any = {};
            tom.sepObjectIDs = sepIDs;

            let takipAlUrl = '/api/InvoiceTopMenuApi/takipBazliHizmetKayit';
            this.http.post<Array<MedulaResult>>(takipAlUrl, tom)
                .then(response => {
                    this.loadPanelOperation(false, '');
                    for (let i = 0; i < response.length; i++) {
                        if (!response[i].SonucKodu.Equals('0000'))
                            ServiceLocator.MessageService.showError('[' + response[i].SonucKodu + '] ' + response[i].SonucMesaji);
                    }

                    let loadPartitions: Array<number> = new Array<number>();

                    loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler

                    this.LoadFromSEP(sepIDs[0], loadPartitions);
                })
                .catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }
    }

    takipBazliHizmetKayitFromTopMenu(): void {

        let tempSelectedSEPs: Array<any> = [];

        if (this.selectedSEPs.length > 0) {
            for (let i = 0; i < this.selectedSEPs.length; i++) {
                if (this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.Invoiced &&
                    this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.InvoiceInconsistent &&
                    this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.ProvisionNoNotExists)
                    tempSelectedSEPs.push(this.selectedSEPs[i].ObjectID);
            }
        }
        else {
            tempSelectedSEPs.push(this.invoiceSEPFormViewModel.MainSEP);
        }

        this.takipBazliHizmetKayit(tempSelectedSEPs);
    }

    sendToENabiz700FromTopMenu(): void {
        let tempSelectedSEPs: Array<any> = [];

        if (this.selectedSEPs.length > 0) {
            for (let i = 0; i < this.selectedSEPs.length; i++) {
                if (this.selectedSEPs[i].InvoiceStatus != SEPInvoiceStatusDictionary.Invoiced &&
                    this.selectedSEPs[i].InvoiceStatus != SEPInvoiceStatusDictionary.InvoiceInconsistent &&
                    this.selectedSEPs[i].InvoiceStatus != SEPInvoiceStatusDictionary.ProvisionNoNotExists)
                    tempSelectedSEPs.push(this.selectedSEPs[i].ObjectID);
            }
        }
        else {
            tempSelectedSEPs.push(this.invoiceSEPFormViewModel.MainSEP);
        }
        this.sendToENabiz700(tempSelectedSEPs, null);
    }

    sendToENabiz700(sepIDs: Array<any>, accTrxIDs: Array<any>): void {

        let sten: any = [];
        if (accTrxIDs != null) {
            let tempItem: any = {};
            tempItem.accTrxList = accTrxIDs;
            tempItem.sepObjectID = sepIDs[0];
            sten.push(tempItem);
        }
        else {
            for (let i = 0; i < sepIDs.length; i++) {
                let element = sepIDs[i];
                let tempItem: any = {};
                tempItem.sepObjectID = element;
                tempItem.accTrxList = [];
                sten.push(tempItem);
            }
        }
        let sendToENabiz700Url = '/api/InvoiceTopMenuApi/sendToENabiz700';
        this.loadPanelOperation(true, "Nabız a veriler gönderiliyor lütfen bekleyiniz.");
        this.http.post(sendToENabiz700Url, sten)
            .then(response => {
                let loadPartitions: Array<number> = new Array<number>();
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler

                this.LoadFromSEP(sepIDs[0], loadPartitions);
                this.loadPanelOperation(false, "");
                ServiceLocator.MessageService.showSuccess("Detaylar nabıza gönderildi.");
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    basvuruBazliHizmetKayit(): void {

        let tempSelectedSEPs: Array<any> = [];

        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.Invoiced &&
                this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.InvoiceInconsistent &&
                this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.ProvisionNoNotExists)
                tempSelectedSEPs.push(this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID);
        }

        this.takipBazliHizmetKayit(tempSelectedSEPs);
    }


    takipBazliHizmetKayitIptal(sepIDs: Array<any>): void {
        if (sepIDs.length > 0) {
            this.loadPanelOperation(true, i18n("M15886", "Hizmet kayıt iptal ediliyor, lütfen bekleyiniz."));
            let that = this;
            let tom: any = {};
            tom.sepObjectIDs = sepIDs;

            let takipAlUrl = '/api/InvoiceTopMenuApi/takipBazliHizmetKayitIptal';
            this.http.post(takipAlUrl, tom)
                .then(response => {
                    let loadPartitions: Array<number> = new Array<number>();

                    loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler

                    this.LoadFromSEP(sepIDs[0], loadPartitions);
                })
                .catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }

    }

    takipBazliHizmetKayitIptalFromTopMenu(): void {
        let tempSelectedSEPs: Array<any> = [];

        if (this.selectedSEPs.length > 0) {
            for (let i = 0; i < this.selectedSEPs.length; i++) {
                if (this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.Invoiced &&
                    this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.InvoiceInconsistent &&
                    this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.ProvisionNoNotExists)
                    tempSelectedSEPs.push(this.selectedSEPs[i].ObjectID);
            }
        }
        else {
            tempSelectedSEPs.push(this.invoiceSEPFormViewModel.MainSEP);
        }

        this.takipBazliHizmetKayitIptal(tempSelectedSEPs);
    }

    basvuruBazliHizmetKayitIptal(): void {
        let tempSelectedSEPs: Array<any> = [];

        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.Invoiced &&
                this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.InvoiceInconsistent &&
                this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.ProvisionNoNotExists)
                tempSelectedSEPs.push(this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID);
        }

        this.takipBazliHizmetKayitIptal(tempSelectedSEPs);

    }


    bagliTakipAlFromTopMenu(): void {
        this.bagliTakipAl(this.invoiceSEPFormViewModel.MainSEP);
    }

    bagliTakipAl(sepID: any): void {

        this.bagliTakipNo = '';
        this.bagliTakipArray.Clear();

        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo !== '' && this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo != null && this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo !== undefined) {
                let tempBagliObject: any = {};
                tempBagliObject.ObjectID = this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo;
                tempBagliObject.Name = this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo;

                this.bagliTakipArray.push(tempBagliObject);
            }
        }
        this.bagliTakipAlinacakSEPid = sepID;
        this.showBagliTakipAlPopup = true;


    }

    onClickBagliTakipAl(): void {
        if (this.bagliTakipNo !== '')
            this.takipAl(this.bagliTakipAlinacakSEPid, this.bagliTakipNo);

        this.showBagliTakipAlPopup = false;
    }

    bagliTakipBilgisiKoparFromTopMenu(): void {
        this.bagliTakipBilgisiKopar(this.invoiceSEPFormViewModel.MainSEP);
    }

    bagliTakipBilgisiKopar(sepID: any): void {
        this.loadPanelOperation(true, i18n("M16555", "Bağlı takip bilgisi koparma işlemi gerçekleştiriliyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/bagliTakipBilgisiKopar?sepObjectID=' + sepID;

        this.http.get(apiUrlForgetRule)
            .then(result => {
                this.loadPanelOperation(false, '');

                let loadPartitions: Array<number> = new Array<number>();
                loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);	//Üst SEP bilgisi
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                this.LoadFromSEP(sepID, loadPartitions);

                ServiceLocator.MessageService.showSuccess("Bağlı takip bilgisi koparıldı.");
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    onClickSaveTransactionDescriptionValue(): void {

        if (this.selectedTransaction == null || this.selectedTransaction == undefined) {
            ServiceLocator.MessageService.showError(i18n("M21550", "Seçili hizmet bilgisi bulunamadı."));
            return;
        }
        let smam: any = {};
        smam.Description = this.updateDescription;
        smam.accTrxObjectID = this.selectedTransaction.ObjectID;

        this.loadPanelOperation(true, i18n("M18731", "Medula açıklama bilgisi kayıt ediliyor, lütfen bekleyiniz."));
        let apiUrlForTransactionHizmetKayit: string = '/api/InvoiceTransactionContextMenuApi/saveMedulaAciklama';

        this.http.post(apiUrlForTransactionHizmetKayit, smam).then(response => {
            this.loadPanelOperation(false, '');
            this.showUpdateDescriptionPopup = false;
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });

    }

    cancelSEP(sepID: any): void {

        this.loadPanelOperation(true, i18n("M16555", "İptal işlemi gerçekleştiriliyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/cancelSEP?sepObjectID=' + sepID;

        this.http.get<string>(apiUrlForgetRule)
            .then(result => {
                this.loadPanelOperation(false, '');

                let loadPartitions: Array<number> = new Array<number>();

                loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPMaster);		//Hasta bilgileri
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
                loadPartitions.push(LoadInvoiceFormPartitions.PatientSEPList); 		//Hasta geçmişi
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis); 		//Hasta geçmişi

                this.LoadFromSEP(result, loadPartitions);

            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });

    }

    copySEP(sepID: any): void {

        this.loadPanelOperation(true, i18n("M21387", "Satır kopyalanıyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/copySEP?sepObjectID=' + sepID;

        this.http.get<string>(apiUrlForgetRule)
            .then(result => {
                this.loadPanelOperation(false, '');

                let loadPartitions: Array<number> = new Array<number>();

                loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPMaster);		//Hasta bilgileri
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
                loadPartitions.push(LoadInvoiceFormPartitions.PatientSEPList); 		//Hasta geçmişi
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis); 		//Epikriz
                this.LoadFromSEP(result, loadPartitions);

            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });

    }

    turnBetweenPayerAndPatient(st: Array<any>, turnType: boolean): void {


        let tbpap: any = {};

        tbpap.TurnType = turnType;
        tbpap.TransactionList = st;
        this.loadPanelOperation(true, i18n("M15900", "Hizmet pay değiştirme işlemi yapılıyor, lütfen bekleyiniz."));
        let apiUrlForTransactionHizmetKayit: string = '/api/InvoiceTransactionContextMenuApi/turnBetweenPayerAndPatient';

        this.http.post(apiUrlForTransactionHizmetKayit, tbpap).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPMaster);		//Hasta bilgileri
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.PatientSEPList); 		//Hasta geçmişi
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis); 		//Epikriz

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);

        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });

    }

    copySEPWithTransaction(st: Array<any>): void {

        this.loadPanelOperation(true, i18n("M21387", "Satır kopyalanıyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/copySEP?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;

        this.http.get<string>(apiUrlForgetRule)
            .then(result => {
                if (result !== '' && result !== null && result !== undefined)
                    this.altVakaGuncelle(st, result);

                this.loadPanelOperation(false, '');
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });

    }

    SGKHizmetSorgulamaResultColumns = [
        { caption: 'durum', dataField: 'durum', fixed: true, width: '100' },
        { caption: 'SYS Takip No', dataField: 'sysTakipNo', fixed: true, width: '150' },
        { caption: 'İşlem Ref. No.', dataField: 'islemReferansNo', fixed: true, width: '110' },
        { caption: 'İşlem Kodu', dataField: 'islemKodu', fixed: true, width: '100' },
        { caption: 'İşlem Tar.', dataField: 'islemTarihi', fixed: true, width: '100' },
        { caption: 'Takip No', dataField: 'sgkTakipNo', fixed: true, width: '80' },
        { caption: 'Turu', dataField: 'islemTuru', dataType: 'string', width: '80' },
        { caption: 'Ref.No', dataField: 'sgkHizmetReferansNo', width: '80' },
        { caption: 'Oluşturulma T.', dataField: 'olusturulmaZamani', dataType: 'date', format: 'dd/MM/yyyy HH:mm:ss', width: '150' },
        { caption: 'Güncelleme T.', dataField: 'guncellenmeZamani', dataType: 'date', format: 'dd/MM/yyyy HH:mm:ss', width: '150' },
        { caption: 'SGK Gönderim T.', dataField: 'sgkGonderimZamani', dataType: 'date', format: 'dd/MM/yyyy HH:mm:ss', width: '150' },
        { caption: 'SGK Sonuç Msj', dataField: 'sgkSonucMesaji', width: '200' },
        { caption: 'SGK Sonuç Kodu', dataField: 'sgkSonucKodu', dataType: 'string', width: '200' },
        { caption: 'Silindi', dataField: 'silindi', dataType: 'bool', width: '200' },
        { caption: 'Hash ID', dataField: 'hashID', width: '80' }
    ];

    public SGKHizmetSorgulamaResultDataSource: any;
    SGKHizmetSorgulama(st: Array<any>): void {
        let shsm: any = {};
        shsm.TransactionList = st;
        this.loadPanelOperation(true, "Nabızdan SGK hizmetleri sorgulanıyor, lütfen bekleyiniz.");
        let apiUrlForTransactionHizmetKayit: string = '/api/InvoiceTransactionContextMenuApi/SGKHizmetSorgulama';

        this.http.post(apiUrlForTransactionHizmetKayit, shsm).then(result => {
            this.showSGKHizmetSorgulamaPopup = true;
            this.SGKHizmetSorgulamaResultDataSource = result;
            this.loadPanelOperation(false, '');
        })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    NabizGonder700(st: Array<any>): void {
        let tempSelectedSEPs: Array<any> = [];
        tempSelectedSEPs.push(this.invoiceSEPFormViewModel.MainSEP);
        let tempSelectedTRXs: Array<any> = [];
        for (let index = 0; index < st.length; index++) {
            const element = st[index];
            tempSelectedTRXs.push(element.ObjectID);
        }
        this.sendToENabiz700(tempSelectedSEPs, tempSelectedTRXs);
    }

    NabizGonder(st: Array<any>): void {
        let apiUrlForNabizGonder: string = '/api/InvoiceTransactionContextMenuApi/NabizGonder';
        this.loadPanelOperation(true, "Nabıza hizmetler gönderiliyor, lütfen bekleyiniz.");
        this.http.post<boolean>(apiUrlForNabizGonder, st).
            then(response => {
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showSuccess("Detaylar nabıza gönderildi.");
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    NabizSil(st: Array<any>): void {
        let apiUrlForNabizGonder: string = '/api/InvoiceTransactionContextMenuApi/NabizSil';
        this.loadPanelOperation(true, "Nabızdan hizmetler siliniyor, lütfen bekleyiniz.");
        this.http.post<boolean>(apiUrlForNabizGonder, st).
            then(response => {
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showSuccess("Detaylar nabızdan silindi.");
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    NabizYatakDuzenle(st: Array<any>): void {
        let apiUrlForNabizYatakDuzenle: string = '/api/InvoiceTransactionContextMenuApi/NabizYatakDuzenle';
        this.loadPanelOperation(true, "Nabıza için yatak hizmetleri düzenleniyor, lütfen bekleyiniz.");
        this.http.post<boolean>(apiUrlForNabizYatakDuzenle, st).
            then(response => {
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showSuccess("Yatak hizmetleri düzenlendi.");
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    basvuruBazliTakipOku(): void {
        let sepID: Array<any> = [];
        sepID.Clear();

        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo !== '' && this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo != null && this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTakipNo !== undefined) {
                sepID.push(this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID);
            }
        }

        this.takipOku(sepID);
    }


    takipOkuFromTopMenu(): void {
        let sepID: Array<any> = [];
        sepID.Clear();
        sepID.push(this.invoiceSEPFormViewModel.MainSEP);
        this.takipOku(sepID);
    }

    takipOku(sepIDs: Array<any>): void {
        this.loadPanelOperation(true, i18n("M22666", "Takip okunuyor, lütfen bekleyiniz."));
        let tom: any = {};
        tom.sepObjectIDs = sepIDs;

        let apiUrlTakipOku: string = '/api/InvoiceTopMenuApi/takipOku';

        if (sepIDs.length > 0) {
            this.http.post<Array<TakipDVO>>(apiUrlTakipOku, tom)
                .then(result => {
                    this.loadPanelOperation(false, '');
                    this.showProvisionPopup = true;
                    this.readProvisionResultArray = this.changeCodeToNameOnProvisionResult(result);


                })
                .catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }
    }

    changeCodeToNameOnProvisionResult(oldResult: Array<TakipDVO>): Array<TakipDVO> {
        for (let i = 0; i < oldResult.length; i++) {
            oldResult[i].tedaviTuru = this.findFromArray(this.tedaviTuruArray, oldResult[i].tedaviTuru);
            oldResult[i].tedaviTipi = this.findFromArray(this.tedaviTipiArray, oldResult[i].tedaviTipi);
            oldResult[i].takipTipi = this.findFromArray(this.takipTipiArray, oldResult[i].takipTipi);
            oldResult[i].provizyonTipi = this.findFromArray(this.provizyonTipiArray, oldResult[i].provizyonTipi);
            oldResult[i].hastaBilgileri.devredilenKurum = this.findFromArray(this.devredilenKurumArray, oldResult[i].hastaBilgileri.devredilenKurum);
            oldResult[i].bransKodu = this.findFromArray(this.bransArray, oldResult[i].bransKodu);
            oldResult[i].istisnaiHal = this.findFromArray(this.istisnaiHalArray, oldResult[i].istisnaiHal);
            oldResult[i].hastaBilgileri.sigortaliTuru = this.findFromArray(this.sigortaliTuruArray, oldResult[i].hastaBilgileri.sigortaliTuru);
            oldResult[i].hastaBilgileri.cinsiyet = oldResult[i].hastaBilgileri.cinsiyet === 'E' ? i18n("M13837", "Erkek") : i18n("M17061", "Kadın");
            oldResult[i].hastaBilgileri.katilimPayindanMuaf = oldResult[i].hastaBilgileri.katilimPayindanMuaf === 'E' ? i18n("M14018", "Evet") : i18n("M15570", "Hayır");
            oldResult[i].sevkDurumu = oldResult[i].sevkDurumu === 'E' ? i18n("M14018", "Evet") : i18n("M15570", "Hayır");
            oldResult[i].takipDurumu = oldResult[i].takipDurumu === '0' ? i18n("M19861", "Ödeme sorgusu yapılmamış") : oldResult[i].takipDurumu === '1' ? i18n("M19862", "Ödeme sorgusu yapılmış") : i18n("M14250", "Faturalanmış");
        }

        return oldResult;
    }

    findFromArray(arr: Array<any>, key: any): string {
        let temp = arr.find(t => t.Code === key);
        if (temp != null && temp !== undefined)
            return temp.Name.substring(0, 30); //32 Karakterden sonrası alt satıra geçiriyor.
        else
            return '';
    }

    getRuleFromTopMenu(): void {
        this.getRule(this.invoiceSEPFormViewModel.MainSEP);
    }
    getRule(sepID: any): void {
        this.loadPanelOperation(true, i18n("M23805", "Uygun kural getiriliyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/getRule?sepObjectID=' + sepID;

        this.http.get<string>(apiUrlForgetRule)
            .then(result => {
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showSuccess(result);
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });

    }

    EditingConfig: any = {
        allowDeleting: true,
        allowUpdating: true,
        mode: 'cell',
        texts: {
            deleteRow: 'Sil',
            //editRow: 'Güncelle',
            //cancelRowChanges: 'İptal',
            //saveRowChanges: 'Kaydet',
            //confirmDeleteTitle: 'Uyarı',
            confirmDeleteMessage: i18n("M13570", "Eklenmeye çalışılan hizmet silinecek. Emin misiniz?")
        }
    };

    cmbAllProcedure: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'ProcedureListDefinition'
    };

    lstDefSpeciality: ITTValueListBox = <ITTValueListBox>{
        ListDefName: 'SpecialityDefinitionList'
    };



    public showAddNewProcedurePopup = false;
    public tempAddNewProcedureGridArray: Array<NewProcedureModel> = new Array<NewProcedureModel>();

    addProcedureFromTopMenu(): void {
        this.addProcedure(this.invoiceSEPFormViewModel.MainSEP);
    }

    addProcedure(sepID: any): void {
        this.tempAddNewProcedureGridArray = new Array<NewProcedureModel>();
        this.invoiceSEPFormViewModel.AddNewProcedure = new AddNewProcedureViewModel();

        this.invoiceSEPFormViewModel.AddNewProcedure.WeekendsIncluded = true;
        this.invoiceSEPFormViewModel.AddNewProcedure.SEPObjectID = sepID;
        for (let itemSEP of this.invoiceSEPFormViewModel.InvoiceSEPList) {
            if (itemSEP.ObjectID == sepID) {
                let ayaktanObj = this.tedaviTuruArray.filter(x => x.Name == i18n("M10407", "A Ayakta Tedavi"));
                let gunubirlikObj = this.tedaviTuruArray.filter(x => x.Name == i18n("M14504", "G Günübirlik Tedavi"));

                if (itemSEP.MedulaTedaviTuru == ayaktanObj[0].ObjectID || itemSEP.MedulaTedaviTuru == gunubirlikObj[0].ObjectID) {
                    this.invoiceSEPFormViewModel.AddNewProcedure.TransactionDate = Convert.ToDateTime(itemSEP.MedulaProvizyonTarihi);
                    this.invoiceSEPFormViewModel.AddNewProcedure.TransactionLastDate = Convert.ToDateTime(itemSEP.MedulaProvizyonTarihi);
                }
            }
        }

        this.loadPanelOperation(true, i18n("M15841", "Hizmet ekleme için uygun veriler hazırlanıyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/getDoctorObjectIDFromSEP?sepObjectID=' + sepID;

        this.http.get<Guid>(apiUrlForgetRule)
            .then(result => {
                this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID = new listboxObject();
                this.invoiceSEPFormViewModel.AddNewProcedure.Doctor = result;
                this.loadPanelOperation(false, '');
                this.showAddNewProcedurePopup = true;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(i18n("M13164", "Doktor bilgisi bulunamadı"));
                this.showAddNewProcedurePopup = true;
            });
    }

    onClickAddNewProcedure(): void {
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/addNewProcedureToSEP';
        this.loadPanelOperation(true, 'Hizmet/Hizmetler ekleniyor, lütfen bekleyiniz.');
        let anp: any = {};
        anp.SEPObjectID = this.invoiceSEPFormViewModel.AddNewProcedure.SEPObjectID;
        anp.NewProcedures = this.tempAddNewProcedureGridArray;
        this.showAddNewProcedurePopup = false;
        this.http.post<Array<MedulaResult>>(apiUrlForgetRule, anp)
            .then(response => {
                this.loadPanelOperation(false, '');
                let loadPartitions: Array<number> = new Array<number>();

                loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler

                this.LoadFromSEP(this.invoiceSEPFormViewModel.AddNewProcedure.SEPObjectID, loadPartitions);

                ServiceLocator.MessageService.showSuccess(i18n("M14791", "Girilen Hizmet/Hizmetler Eklendi."));
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    //twoWay

    AddNewProcedureSelected(event: any): void {
        if (event != null) {
            if (this.invoiceSEPFormViewModel.AddNewProcedure != null &&
                this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID != event) {
                this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID = event;
            }
        }
        else
            this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID = null;


    }

    AddNewProcedureClicked(): void {

        if (this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID == undefined
            || this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID == null
            || this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID.ObjectID == ""
            || this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID.ObjectID == undefined
            || this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID.ObjectID == Guid.Empty.toString()) {
            ServiceLocator.MessageService.showError(i18n("M13555", "Eklenecek hizmet seçiniz."));
            return;
        }

        let tempDate = this.invoiceSEPFormViewModel.AddNewProcedure.TransactionDate;
        do {
            if (((tempDate.getDay() == 6 || tempDate.getDay() == 0) && this.invoiceSEPFormViewModel.AddNewProcedure.WeekendsIncluded) || (!(tempDate.getDay() == 6 || tempDate.getDay() == 0))) {
                let tempObj: NewProcedureModel = new NewProcedureModel();
                tempObj.Amount = this.invoiceSEPFormViewModel.AddNewProcedure.Amount;
                tempObj.Code = this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID.Code;
                tempObj.Doctor = this.invoiceSEPFormViewModel.AddNewProcedure.Doctor;
                tempObj.Name = this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID.Name;
                tempObj.ProcedureObjectID.ObjectID = this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID.ObjectID;
                tempObj.TransactionDate = tempDate;

                this.tempAddNewProcedureGridArray.push(tempObj);
            }
            if (tempDate)
                tempDate = tempDate.AddDays(1);

        }
        while (tempDate && tempDate <= this.invoiceSEPFormViewModel.AddNewProcedure.TransactionLastDate);
        window.setTimeout(t => {
            if (this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID === null)
                this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID = undefined;
            else
                this.invoiceSEPFormViewModel.AddNewProcedure.ProcedureObjectID = null;
        }, 0);
    }

    getlastRuleFromTopMenu(): void {
        this.getLastRule(this.invoiceSEPFormViewModel.MainSEP);
    }

    getLastRule(sepID: any): void {
        this.loadPanelOperation(true, i18n("M22042", "Son çalışmış kural getiriliyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/getLastRule?sepObjectID=' + sepID;

        this.http.get<string>(apiUrlForgetRule)
            .then(result => {
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showSuccess(result);
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    fixBasedOnTakipFromTopMenu(): void {
        this.fixBasedOnTakip(this.invoiceSEPFormViewModel.MainSEP);
    }

    fixBasedOnTakip(sepID: any): void {
        this.loadPanelOperation(true, i18n("M13408", "Düzenleme işlemi yapılıyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/fixBasedOnTakip?sepObjectID=' + sepID;

        this.http.get<boolean>(apiUrlForgetRule)
            .then(result => {
                this.loadPanelOperation(false, '');
                if (result) {
                    let loadPartitions: Array<number> = new Array<number>();

                    loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler

                    this.LoadFromSEP(sepID, loadPartitions);
                    ServiceLocator.MessageService.showSuccess(i18n("M13406", "Düzenleme işlemi başarı ile tamamlandı."));
                }
                else
                    ServiceLocator.MessageService.showError(i18n("M13407", "Düzenleme işlemi yapılamadı."));
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }
    faturaDuzeltFromTopMenu(): void {
        let tempSelectedSEPs: Array<any> = [];

        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            tempSelectedSEPs.push(this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID);
        }

        this.faturaDuzelt(tempSelectedSEPs);
    }

    faturaDuzelt(sepIDs: Array<any>): void {
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/faturaDuzelt';
        this.loadPanelOperation(true, i18n("M13408", "Düzenleme işlemi yapılıyor, lütfen bekleyiniz."));
        let fkm: any = {};
        fkm.sepObjectIDs = sepIDs;

        if (sepIDs.length > 0) {
            this.http.post<Array<MedulaResult>>(apiUrlForgetRule, fkm)
                .then(response => {
                    this.loadPanelOperation(false, '');
                    //this.faturalamaMethodlariThenBy(response, sepIDs[0]);
                    let loadPartitions: Array<number> = new Array<number>();
                    loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//SEP Detayları
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
                    loadPartitions.push(LoadInvoiceFormPartitions.PatientSEPList);	//Hasta geçmişi
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis); 		//Epikriz
                    this.LoadFromSEP(sepIDs[0], loadPartitions);
                })
                .catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }
    }

    faturaKayitFromTopMenu(): void {
        let tempSelectedSEPs: Array<any> = [];

        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            if ((this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.Invoiced &&
                this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.InvoiceInconsistent
            ) ||
                !this.isSGK)
                tempSelectedSEPs.push(this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID);
        }

        this.faturaKayit(tempSelectedSEPs, 13); //InvoiceOperationTypeEnum -> Faturalandir:13
    }

    faturaKayitSecerekFromTopMenu(): void {
        let tempSelectedSEPs: Array<any> = [];

        for (let i = 0; i < this.selectedSEPs.length; i++) {
            if ((this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.Invoiced &&
                this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.InvoiceInconsistent)
                ||
                !this.isSGK)
                tempSelectedSEPs.push(this.selectedSEPs[i].ObjectID);
        }
        this.faturaKayit(tempSelectedSEPs, 46); //InvoiceOperationTypeEnum -> Faturalandir:46
    }

    faturalamaMethodlariThenBy(response: Array<MedulaResult>, sepID: any): void {
        let found: boolean = true;
        this.loadPanelOperation(false, '');
        if (response.length > 5)
            ServiceLocator.MessageService.showError("Fatura kayit methodunda hatalar alındı. Lütfen hizmet detaylarını inceleyeniz.");
        else {
            for (let i = 0; i < response.length; i++) {
                if (!response[i].SonucKodu.Equals('0000')) {
                    found = false;
                    ServiceLocator.MessageService.showError(response[i].TakipNo + ' -  [' + response[i].SonucKodu + '] ' + response[i].SonucMesaji);
                }
            }
        }
        let loadPartitions: Array<number> = new Array<number>();

        if (response.length > 0 && response[0].SEPObjectID && response[0].SEPObjectID != "0000000-0000-0000-0000-00000000000000") {
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//SEP Detayları
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
            loadPartitions.push(LoadInvoiceFormPartitions.PatientSEPList);	//Hasta geçmişi
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis); 		//Epikriz
            this.LoadFromSEP(response[0].SEPObjectID, loadPartitions);
        }
        else {
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//SEP Detayları
            loadPartitions.push(LoadInvoiceFormPartitions.PatientSEPList);	//Hasta geçmişi
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis); 		//Epikriz
            this.LoadFromSEP(sepID, loadPartitions);
        }

        if (found)
            ServiceLocator.MessageService.showSuccess('[' + response[0].SonucKodu + '] ' + response[0].SonucMesaji);
    }

    async faturaKayit(sepIDs: Array<any>, type: number): Promise<void> {

        if (this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceDate == null) {
            ServiceLocator.MessageService.showInfo(i18n("M10036", "\'Faturalama\' için ilk önce tarih seçiniz."));
            return;
        }
        this.loadPanelOperation(true, i18n("M14175", "Fatura kayıt işlemi yapılıyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/faturaKayit';
        let fkm: any = {};
        let foundInvoiceInclusion: boolean = false;
        let SEPBasedFoundInvoiceInclusion: boolean = false;
        let tempInvoiceTransactionArray: Array<Guid> = new Array<Guid>();
        let tempInvoiceSEPArray: Array<Guid> = new Array<Guid>();

        fkm.sepObjectIDs = sepIDs;
        fkm.invoiceDate = this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceDate;
        fkm.invoiceDescription = this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceDescription;
        fkm.type = type;
        fkm.invoiceType = this.formOpenPayerType;
        //RESMI kurum SEP'leri için çalışacak blok
        if (this.formOpenPayerType != PayerTypeEnum.Paid && !this.isSGK && this.mainSEPInvoiceStatus !== SEPInvoiceStatusDictionary.InsideInvoiceCollection) // 0:SGK tipinde olmayan kurumlarda icmal seçilmiş olması gerekli.
        {
            let response = await this.medulaDefinition.GetInvoiceCollection();

            if (response != null && response.DataValue !== undefined) {
                fkm.invoiceCollection = response.DataValue;
            }
            else {
                let a = await this.icmalSec(true);

                let res = await this.medulaDefinition.GetInvoiceCollection();

                if (res != null && res.DataValue !== undefined) {
                    fkm.invoiceCollection = res.DataValue;
                }
                else {
                    this.loadPanelOperation(false, '');
                    ServiceLocator.MessageService.showError(i18n("M21568", "Seçim Yapmadınız."));
                    return;
                }

            }
        }//Ücretli hasta olarak ekran açıldığında çalışacak blok.
        else if (this.formOpenPayerType == PayerTypeEnum.Paid) {
            for (let itemKeySEP of this.invoiceSEPFormViewModel.InvoiceSEPList) {
                SEPBasedFoundInvoiceInclusion = false;
                for (let itemKeySelectedTransaction of itemKeySEP.SelectedTransactionList) {
                    if ((!foundInvoiceInclusion || !SEPBasedFoundInvoiceInclusion) && itemKeySelectedTransaction.InvoiceInclusion && itemKeySelectedTransaction.CurrentStateDefID == AccountTransaction.AccountTransactionStates.Paid) {
                        foundInvoiceInclusion = true;
                        SEPBasedFoundInvoiceInclusion = true;
                    }

                    if (itemKeySelectedTransaction.CurrentStateDefID == AccountTransaction.AccountTransactionStates.New) {
                        this.loadPanelOperation(false, '');
                        ServiceLocator.MessageService.showError(i18n("M21553", "Seçili işlemler arasında Yeni durumunda işlem bulundu. Hasta faturası kesebilmek için hizmetin ücretinin tamamı ödenmiş olmalı."));
                        return;
                    }
                    tempInvoiceTransactionArray.push(itemKeySelectedTransaction.ObjectID);
                }

                if (SEPBasedFoundInvoiceInclusion)
                    tempInvoiceSEPArray.push(itemKeySEP.ObjectID);
            }
            fkm.sepObjectIDs = tempInvoiceSEPArray;
            fkm.transactionlist = tempInvoiceTransactionArray;
        }

        if (!foundInvoiceInclusion && this.formOpenPayerType == PayerTypeEnum.Paid) {
            this.loadPanelOperation(false, '');
            ServiceLocator.MessageService.showError(i18n("M21556", "Seçili işlemlerden hiç biri faturaya dahil işlemlerden değil. Hasta faturası kesebilmek için en az bir tane işlem faturaya dahil ve ücretinin ödenmiş olması gerekmektedir."));
            return;
        }

        if (this.formOpenPayerType != PayerTypeEnum.Paid && !this.isSGK && (fkm.invoiceCollection == undefined || fkm.invoiceCollection == null)
            && this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceCollection != null && this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceCollection != undefined
            && this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceCollection.ObjectID != null && this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceCollection.ObjectID != undefined) {
            fkm.invoiceCollection = this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceCollection.ObjectID;
        }

        if (sepIDs.length > 0) {
            this.http.post<Array<MedulaResult>>(apiUrlForgetRule, fkm)
                .then(response => {
                    if (response != null && response != undefined && response.length > 0 && response[0].SonucKodu == "1108")//Birlikte faturalanamaz hatası
                        this.faturaSonrasiSUTKurallari(sepIDs, type, response[0].SonucMesaji, 1);
                    else
                        this.faturalamaMethodlariThenBy(response, sepIDs[0]);

                    let parameters: any = {};
                    parameters.invoiceSEPFormViewModel = this.invoiceSEPFormViewModel;
                    this.invoiceAllInOneCommService.invoiceSepFormComm.next({ Params: parameters });
                })
                .catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }
    }
    public firstButtonText: string;
    public secondButtonText: string;
    private localSepIDs: Array<any>;
    private localType: number;
    private localCallType: number;

    faturaSonrasiSUTKurallari(sepIDs: Array<any>, type: number, message: string, callType: number): void {
        let splittedMessage: string[] = message.split(' ');
        let ttpam: any = {};

        ttpam.sepObjectIDs = sepIDs;
        ttpam.firstSUTCode = splittedMessage[7];
        ttpam.secondSUTCode = splittedMessage[14]

        let apiUrlGetDetail: string = '/api/InvoiceTopMenuApi/getTransactionTotalAmountAndPrice';
        this.loadPanelOperation(true, 'Yasaklı işlemler getiriliyor, lütfen bekleyiniz.');
        this.http.post<Array<ForbiddenSUTOperation>>(apiUrlGetDetail, ttpam)
            .then(response => {
                this.loadPanelOperation(false, "");
                if (response.length > 1) {
                    if (response.length > 1) {
                        this.localSepIDs = sepIDs;
                        this.localType = type;
                        this.localCallType = callType;
                        this.firstButtonText = response[0].sutName;
                        this.secondButtonText = response[1].sutName;
                        this.AfterInvoiceOperationArray = response;
                        this.showAfterInvoiceSUTControlPopup = true;
                    }
                }
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });

    }

    onClickAfterInvoiceSUTControl(choose: ForbiddenSUTOperation): void {
        let that = this;
        this.showAfterInvoiceSUTControlPopup = false;
        let hhiscm: any = {};

        hhiscm.sepObjectIDs = this.localSepIDs;
        hhiscm.SUTCode = choose.sutCode;
        let apiUrlGetDetail: string = '/api/InvoiceTopMenuApi/hizmetKayitIptalWithSEPAndSutCode';
        this.loadPanelOperation(true, 'Hizmet kayıtlar siliniyor, lütfen bekleyiniz.');
        this.http.post<boolean>(apiUrlGetDetail, hhiscm)
            .then(response => {
                that.loadPanelOperation(false, "");
                if (response) {
                    if (that.localCallType == 1) {
                        that.faturaKayit(that.localSepIDs, that.localType);
                    }
                    else if (that.localCallType == 2) {
                        that.faturaTutarOku(that.localSepIDs);
                    }
                }
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });

    }

    faturaIptal(): void {

        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/faturaIptal?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.loadPanelOperation(true, i18n("M14168", "Fatura iptal işlemi yapılıyor, lütfen bekleyiniz."));
        this.http.get<Array<MedulaResult>>(apiUrlForgetRule)
            .then(response => {
                this.faturalamaMethodlariThenBy(response, this.invoiceSEPFormViewModel.MainSEP);
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    faturaOku(): void {

        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/faturaOku?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.loadPanelOperation(true, 'Fatura okuma işlemi yapılıyor, lütfen bekleyiniz.');
        this.http.get<faturaOkuCevapDTO>(apiUrlForgetRule)
            .then(result => {
                let loadPartitions: Array<number> = new Array<number>();
                loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi

                this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
                this.readInvoiceResultArray = result;

                if (result.succes)
                    this.showReadInvoicePopup = true;
                else
                    ServiceLocator.MessageService.showError('[' + result.sonucKoduField + '] ' + result.sonucMesajiField);
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });

    }

    faturaTutarOkuFromTopMenu(): void {
        let tempSelectedSEPs: Array<any> = [];

        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.Invoiced &&
                this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.InvoiceInconsistent &&
                this.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus !== SEPInvoiceStatusDictionary.ProvisionNoNotExists)
                tempSelectedSEPs.push(this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID);
        }
        this.faturaTutarOku(tempSelectedSEPs);
    }

    faturaTutarOkuSecerekFromTopMenu(): void {
        let tempSelectedSEPs: Array<any> = [];

        for (let i = 0; i < this.selectedSEPs.length; i++) {
            if (this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.Invoiced &&
                this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.InvoiceInconsistent &&
                this.selectedSEPs[i].InvoiceStatus !== SEPInvoiceStatusDictionary.ProvisionNoNotExists)
                tempSelectedSEPs.push(this.selectedSEPs[i].ObjectID);
        }
        this.faturaTutarOku(tempSelectedSEPs);
    }

    faturaTutarOku(sepIDs: Array<any>): void {
        if (this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceDate == null) {
            ServiceLocator.MessageService.showInfo(i18n("M10035", "\'Fatura Tutar Okuma\' için ilk önce tarih seçiniz."));
            return;
        }
        this.loadPanelOperation(true, i18n("M14218", "Fatura tutar okuma işlemi yapılıyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/faturaTutarOku';
        let fkm: any = {};

        fkm.sepObjectIDs = sepIDs;
        fkm.invoiceDate = this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceDate;
        fkm.invoiceDescription = this.invoiceSEPFormViewModel.InvoiceSEPDetail.InvoiceDescription;

        let tempType: number;
        tempType = -1;
        if (sepIDs.length > 0) {
            this.http.post<Array<MedulaResult>>(apiUrlForgetRule, fkm)
                .then(response => {
                    if (response != null && response != undefined && response.length > 0 && response[0].SonucKodu == "1108")//Birlikte faturalanamaz hatası
                        this.faturaSonrasiSUTKurallari(sepIDs, tempType, response[0].SonucMesaji, 2);
                    else
                        this.faturalamaMethodlariThenBy(response, sepIDs[0]);
                })
                .catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }
    }

    getTransactionHistory(actTrx: any) {
        let apiUrlHistory: string = '/api/InvoiceTransactionContextMenuApi/getTransactionHistory?trxObjectID=' + actTrx;
        this.http.get<Array<InvoiceLogModel>>(apiUrlHistory)
            .then(result => {
                this.HistoryGridArray = result;
                this.showHistoryPopup = true;
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    btnHistoryClicked(): void {

        let apiUrlHistory: string = '/api/InvoiceTopMenuApi/getSEPHistory?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.http.get<Array<InvoiceLogModel>>(apiUrlHistory)
            .then(result => {
                this.HistoryGridArray = result;
                this.showHistoryPopup = true;
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    btnInvoiceBlockingClicked(): void {

        let apiUrlHistory: string = '/api/InvoiceTopMenuApi/getSEPInvoiceBlocking?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.http.get<Array<InvoiceBlockingModel>>(apiUrlHistory)
            .then(result => {
                this.newInvoiceBlockingDescription = "";
                this.InvoiceBlockingGridArray = result;
                this.showInvoiceBlockingPopup = true;
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });

    }

    onClickSaveNewInvoiceBlocking(): void {

        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/saveNewInvoiceBlocking';
        let ibsm: any = {};

        ibsm.sepObjectID = this.invoiceSEPFormViewModel.MainSEP;
        ibsm.invoiceBlockingDescription = this.newInvoiceBlockingDescription;


        if (ibsm.sepObjectID != null && ibsm.sepObjectID != undefined && ibsm.sepObjectID != Guid.Empty) {
            this.http.post(apiUrlForgetRule, ibsm)
                .then(response => {
                    ServiceLocator.MessageService.showSuccess(i18n("M14147", "Fatura Engeli Başarı ile Kayıt Edildi."));

                    this.btnInvoiceBlockingClicked();
                })
                .catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }

    }

    onClickPassInvoiceBlocking(row: any): void {

        if (row.data.UnblockDescription == null || row.data.UnblockDescription == "") {
            ServiceLocator.MessageService.showError(i18n("M13735", "Engeli kaldırmak için açıklama alanı doldurulmalı."));
            return;
        }

        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/passInvoiceBlocking';
        let ibsm: any = {};

        ibsm.ibObjectID = row.data.ObjectID;
        ibsm.passInvoiceBlockingDescription = row.data.UnblockDescription;

        if (ibsm.ibObjectID != null && ibsm.ibObjectID != undefined && ibsm.ibObjectID != Guid.Empty) {
            this.http.post(apiUrlForgetRule, ibsm)
                .then(response => {
                    ServiceLocator.MessageService.showSuccess(i18n("M14146", "Fatura Engeli Başarı ile Kaldırıldı"));

                    this.btnInvoiceBlockingClicked();
                })
                .catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }

    }

    btnRefreshClicked(): void {
        let loadPartitions: Array<number> = new Array<number>();

        loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPMaster);		//Hasta bilgileri
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
        loadPartitions.push(LoadInvoiceFormPartitions.PatientSEPList); 		//Hasta geçmişi
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis); 		//Epikriz
        this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
    }

    btnClearTransactionGridFilter(): void {
        this.trxGridInstance.instance.clearFilter();
        //this.inpatientDateCheck = false;
        //this.disChargeDateCheck = false;
        this.inOutpatientDateCheckValueChanged();
    }

    public expanded = true;

    collapseAllClick(e) {
        this.expanded = !this.expanded;
    }

    loadFromToolbar(objectID: Guid): void {

        let loadPartitions: Array<number> = new Array<number>();

        loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPMaster);		//Hasta bilgileri
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler
        loadPartitions.push(LoadInvoiceFormPartitions.PatientSEPList); 		//Hasta geçmişi
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis); 		//Epikriz
        this.LoadFromSEP(objectID, loadPartitions).then(response => {
            this.loadPanelOperation(false, "");
        })
            .catch(error => {
                this.loadPanelOperation(false, "");
            });
    }
    public loadFromToolbarPrev(): void {
        this.loadFromToolbar(this.prevObjectID);
    }

    public loadFromToolbarNext(): void {
        this.loadFromToolbar(this.nextObjectID);
    }

    public dontSendCheck = false;
    public showMedulaDontSendTransactions(check: any): void {
        if (check.value) {
            this.lifm.Statetext = 'Medulaya Gönderilmeyecek';
        }
        else {
            this.lifm.Statetext = '';
        }

        this.InvoiceSEPTransactionList.reload();
    }
    public showNabiz700Hatali(check: any): void {
        if (check.value) {
            this.lifm.Nabiz700Status = 2;
        }
        else {
            this.lifm.Nabiz700Status = null;
        }

        this.InvoiceSEPTransactionList.reload();
    }
    //public showInvoiceBlocking(check: any): void {
    //    if (check.value) {
    //        this.lifm.BlockingStatus = true;
    //    }
    //    else {
    //        this.lifm.BlockingStatus = null;
    //    }

    //    this.InvoiceSEPTransactionList.reload();
    //}
    onToolbarPreparingTransactionList(event: any): void {
        let that = this;
        event.toolbarOptions.items.unshift(
            //{
            //    location: 'after',
            //    widget: 'dxCheckBox',
            //    options: {
            //        width: 136,
            //        text: 'Fatura Engeli',
            //        onValueChanged: that.showInvoiceBlocking.bind(this)
            //    }
            //},
            {
                location: 'after',
                widget: 'dxCheckBox',
                options: {
                    width: 136,
                    text: 'Nabız Hatalı',
                    onValueChanged: that.showNabiz700Hatali.bind(this)
                }
            },
            {
                location: 'after',
                widget: 'dxCheckBox',
                options: {
                    width: 150,
                    text: 'Gönderilmeyecek Hariç',
                    onValueChanged: that.showMedulaDontSendTransactions.bind(this)
                }
            },
            {
                location: 'after',
                widget: 'dxButton',
                options: {
                    width: 30,
                    icon: 'fa fa-caret-square-o-up',
                    type: 'btn btn-default',
                    onClick: that.loadFromToolbarPrev.bind(that)
                }
            }, {
                location: 'after',
                widget: 'dxButton',
                options: {
                    width: 30,
                    icon: 'fa fa-caret-square-o-down',
                    type: 'btn btn-default',
                    onClick: that.loadFromToolbarNext.bind(that)
                }
            }, {
                location: 'after',
                widget: 'dxButton',
                options: {
                    width: 150,
                    icon: 'fa fa-object-group',
                    text: ' Grupları Aç/Kapat',
                    type: 'btn btn-default',
                    onClick: that.collapseAllClick.bind(that)
                }
            }, {
                location: 'after',
                widget: 'dxButton',
                options: {
                    icon: 'refresh',
                    text: 'Filtreyi Temizle',
                    type: 'btn btn-default',
                    onClick: that.btnClearTransactionGridFilter.bind(that)
                }
            });
    }

    onAccordionItemTitleClickDetailForm(event: any): void {
        //console.log(event);
        window.setTimeout(t => {
            this.resizeDateVariable = new Date();
            this.trxGridInstance.instance.refresh();
            this.diaGridInstance.instance.refresh();
            this.patientSEPGridInstance.instance.refresh();
            this.epicGridInstance.instance.refresh();
        }, 350);

    }


    btnOpenMedulaLink(): void {

        for (let j = 0; j < this.invoiceSEPFormViewModel.InvoiceSEPList.length; j++) {
            if (this.invoiceSEPFormViewModel.MainSEP == this.invoiceSEPFormViewModel.InvoiceSEPList[j].ObjectID) {
                let win = window.open("http://xxxxxx.com/viewer/Hizmet/Viewer?AID=" + this.invoiceSEPFormViewModel.InvoiceSEPList[j].Id, "_blank");
                win.focus();
                break;
            }
        }
    }

    basvuruOku(): void {

        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/basvuruOku?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.loadPanelOperation(true, 'Başvuru altındaki takipler okunuyor, lütfen bekleyiniz.');
        this.http.get<BasvuruTakipOkuCevapDVO>(apiUrlForgetRule)
            .then(result => {
                this.loadPanelOperation(false, '');
                if (result.sonucKodu === '0000') {

                    for (let i = 0; i < result.basvuruTakip.length; i++) {
                        result.basvuruTakip[i].takipFaturaDurumu = result.basvuruTakip[i].takipFaturaDurumu === '0' ? i18n("M19861", "Ödeme sorgusu yapılmamış") : result.basvuruTakip[i].takipFaturaDurumu === '1' ? i18n("M19862", "Ödeme sorgusu yapılmış") : i18n("M14250", "Faturalanmış");
                    }

                    this.showApplicationNoReadPopup = true;
                    this.readApplicationNoResultArray = result;
                }
                else
                    ServiceLocator.MessageService.showError('[' + result.sonucKodu + '] ' + result.sonucMesaji);
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    async icmaleEkle(): Promise<void> {
        let invoiceCollectionID: any;
        let that = this;
        let response = await this.medulaDefinition.GetInvoiceCollection();

        if (response != null && response.DataValue !== undefined) {
            that.icmaleEkleWebCall(response.DataValue);
        }
        else {
            let a = await that.icmalSec(true);

            that.medulaDefinition.GetInvoiceCollection().then(res => {
                if (res != null && res.DataValue !== undefined) {
                    that.icmaleEkleWebCall(res.DataValue);
                }
                else {
                    ServiceLocator.MessageService.showError(i18n("M21568", "Seçim Yapmadınız."));
                }
            });
        }
    }

    icmaleEkleWebCall(invoiceCollectionID: any): void {
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/icmaleEkle?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP + '&invoiceCollectionID=' + invoiceCollectionID;
        this.loadPanelOperation(true, i18n("M21551", "Seçili icmale ekleme işlemi yapılıyor, lütfen bekleyiniz."));
        this.http.get<MedulaResult>(apiUrlForgetRule)
            .then(response => {
                let loadPartitions: Array<number> = new Array<number>();

                loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

                this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
                ServiceLocator.MessageService.showSuccess(i18n("M16154", "İcmale ekleme işlemi başarı ile tamamlandı."));
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    icmaldenCikar(): void {
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/icmaldenCikar?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.loadPanelOperation(true, i18n("M16151", "İcmalden çıkarma işlemi yapılıyor, lütfen bekleyiniz."));
        this.http.get<MedulaResult>(apiUrlForgetRule)
            .then(response => {
                let loadPartitions: Array<number> = new Array<number>();

                loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Üst SEP bilgisi
                loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler

                this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
                ServiceLocator.MessageService.showSuccess(i18n("M16150", "İcmalden çıkarma işlemi başarı ile tamamlandı."));
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    async icmalSec(type: boolean): Promise<ComboListItem> {

        let aktifIcmal: any;
        let array: Array<ComboListItem> = new Array<ComboListItem>();

        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/uygunIcmalleriGetir?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.loadPanelOperation(true, i18n("M21510", "Seçilebilecek icmaller ekrana getiriliyor, lütfen bekleyiniz."));

        let x = await this.http.get<Array<ComboListItem>>(apiUrlForgetRule);

        for (let item of x) {
            array.push(new ComboListItem(item.DataValue, item.DisplayText));
        }

        this.loadPanelOperation(false, '');

        let selection = await InputForm.GetValueListItem('Icmal Seçim', array);
        if (type !== false) {
            if (selection.DataValue === undefined || selection.DataValue == null)
                this.medulaDefinition.SetInvoiceCollection(null);
            else
                this.medulaDefinition.SetInvoiceCollection(selection);
            this.GenerateTopMenu();
        }

        return selection;
    }




    icmalSecimiTemizle(): void {
        this.medulaDefinition.SetInvoiceCollection(null);
        this.GenerateTopMenu();

    }



    async icmalSecerekEkle(): Promise<void> {
        let a = await this.icmalSec(false);
        this.icmaleEkleWebCall(a.DataValue);
    }

    fixBasedOnBasvuru(): void {

        let sepObjectIDs: Array<Guid> = new Array<Guid>();
        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            sepObjectIDs.push(this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID);
        }

        this.loadPanelOperation(true, i18n("M13408", "Düzenleme işlemi yapılıyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/fixBasedOnBasvuru';

        this.http.post<boolean>(apiUrlForgetRule, sepObjectIDs)
            .then(result => {
                this.loadPanelOperation(false, '');
                if (result) {
                    let loadPartitions: Array<number> = new Array<number>();

                    loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);	//Tanılar
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Hizmetler

                    this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
                    ServiceLocator.MessageService.showSuccess(i18n("M13406", "Düzenleme işlemi başarı ile tamamlandı."));
                }
                else
                    ServiceLocator.MessageService.showError(i18n("M13407", "Düzenleme işlemi tamamlanamadı."));
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
        //alert(i18n("M24289", "Yapım Aşamasında."));
    }

    tutarUyustur(): void {
        alert(i18n("M24289", "Yapım Aşamasında."));
    }

    onContextMenuPreparingSEPList(e: any): void {
        let that = this;
        let menuItemHasProvision = false;
        let menuItemStatus: string;


        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data') {

                if (e.row.data.MedulaTakipNo !== '' && e.row.data.MedulaTakipNo !== null && e.row.data.MedulaTakipNo !== undefined)
                    menuItemHasProvision = true;
                else
                    menuItemHasProvision = false;

                menuItemStatus = e.row.data.InvoiceStatus;

                e.items = [{
                    text: i18n("M22634", "Takip Al"),
                    disabled: (menuItemHasProvision || !this.isSGK) || this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {

                        that.takipAl(e.row.data.ObjectID, '');
                    }
                },
                {
                    text: i18n("M22668", "Takip Sil"),
                    disabled: (!menuItemHasProvision || menuItemStatus === SEPInvoiceStatusDictionary.Invoiced || menuItemStatus === SEPInvoiceStatusDictionary.InvoiceInconsistent) || this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {

                        that.takipSilConfirm(e.row.data.ObjectID);
                    }
                },
                {
                    text: i18n("M22663", "Takip Oku"),
                    disabled: (!menuItemHasProvision) || this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {
                        let sepID: Array<any> = [];
                        sepID.Clear();
                        sepID.push(e.row.data.ObjectID);
                        that.takipOku(sepID);
                    }
                }
                    ,
                {
                    text: 'Bağlı Takip Al',
                    disabled: (menuItemHasProvision || !this.isSGK) || this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {
                        that.bagliTakipAl(e.row.data.ObjectID);
                    },
                    items: [
                        {
                            text: 'Bağlı Takip Bilgisi Kopar',
                            disabled: (menuItemHasProvision || !this.isSGK) || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.bagliTakipBilgisiKopar(e.row.data.ObjectID);
                            }
                        }
                    ]
                },
                {
                    text: 'Satır Kopyala',
                    //disabled: (menuItemHasProvision || !this.isSGK) || this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {
                        that.copySEP(e.row.data.ObjectID);
                    }
                },
                {
                    text: 'Satırı İptal Et',
                    //disabled: (menuItemHasProvision || !this.isSGK) || this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {
                        that.cancelSEP(e.row.data.ObjectID);
                    }
                },
                {
                    text: 'Muayene/Yatış İşlemi Aç',
                    onItemClick: function () {
                        that.openPopUpDynamicComponent(e.row.data.ObjectID, null, null);
                    }
                }
                ];
            }
        }
    }

    public async openPopUpDynamicComponent(sepObjectID: Guid, inputparam: any, formDefId: any): Promise<ModalActionResult> {
        //this.systemApiService.open(objectID, objectDefName, formDefId, inputparam).catch();
        //this.showExaminationPopup = true;

        let res = await this.http.get<any>('api/InvoiceApi/GetRelatedEpisodeActionOfSubEpisode?sepObjectID=' + sepObjectID);
        if (res != null) {
            let that = this;
            return new Promise((resolve, reject) => {
                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = "";
                // modalInfo.Width = 1400;
                // modalInfo.Height = 1000;
                modalInfo.fullScreen = true;
                this.http.get<DynamicComponentInfoDVO>('api/SystemApi/GetDynamicComponentInfo?ObjectId=' + res.EAObjectID + '&ObjectDefName=' + res.ObjectDefName + '&FormDefId=' + formDefId).then(dynamicComponentInfoDVO => {
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
        else
            ServiceLocator.MessageService.showError('Uygun işlem bulunamadı!');
    }


    public popUpDynamicComponentClosed(dialogResult: DialogResult) { // istenirse override edilebilir
        this.systemApiService.componentInfo = null;
    }

    onContextMenuPreparingPatientSEPList(e: any): void {
        let that = this;
        if (e.row !== undefined && e.row !== null) {

            if (e.row.rowType === 'data') {
                e.items = [{
                    text: i18n("M24733", "Yükle"),
                    onItemClick: function () {
                        that.loadFromPatientSEPList(e.row.data.ObjectID, e.row.data.PayetTypeEnum);
                    }
                }];
            }
        }
    }

    loadFromPatientSEPList(sepObjectID: any, fot: any): void {
        this.formOpenPayerType = fot;

        this.RouteData.ObjectID = sepObjectID;
        this.RouteData.Type = this.formOpenPayerType;

        this.ngOnInit();
    }

    onContextMenuPreparingDiagnosisList(e: any): void {
        let that = this;
        if (e.row !== undefined && e.row !== null) {

            if (that.selectedDiagnosis.length === 0)//Hiç seçili yoksa sağ klik yaptığımız satırı işleme alsın diye eklendi.
                that.selectedDiagnosis.push(e.row.data);

            if (e.row.rowType === 'data') {
                e.items = [{
                    text: i18n("M22759", "Tanı Kayıt"),
                    disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid || !this.isSGK,
                    onItemClick: function () {
                        that.taniKayit(that.selectedDiagnosis);

                    }
                },
                {
                    text: i18n("M22760", "Tanı Kayıt İptal"),
                    disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid || !this.isSGK,
                    onItemClick: function () {
                        that.taniKayitIptal(that.selectedDiagnosis);
                    }
                },
                {
                    text: i18n("M14874", "Gönderilecek"),
                    disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid || !(this.isSGK || this.isSGKManuel || this.isResmi),
                    onItemClick: function () {
                        that.taniDurumGuncelle(that.selectedDiagnosis, true);
                    }
                },
                {

                    text: i18n("M14901", "Gönderilmeyecek"),
                    disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid || !(this.isSGK || this.isSGKManuel || this.isResmi),
                    onItemClick: function () {
                        that.taniDurumGuncelle(that.selectedDiagnosis, false);
                    }
                }];
            }
        }
    }

    onContextMenuPreparingTransactionList(e: any): void {
        let that = this;
        let tempST: Array<any> = [];
        if (e.row !== undefined && e.row !== null) {

            if (that.selectedTransactions.length === 0)//Hiç seçili yoksa sağ klik yaptığımız satırı işleme alsın diye eklendi.
                tempST.push(e.row.data);
            else
                tempST = that.selectedTransactions;

            if (e.row.rowType === 'data') {
                e.items = [{
                    text: 'Hizmet Kayıt',
                    disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid || !this.isSGK,
                    onItemClick: function () {
                        that.hizmetKayit(tempST);

                    }
                },
                {
                    text: i18n("M15884", "Hizmet Kayıt İptal"),
                    disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid || !this.isSGK,
                    onItemClick: function () {
                        that.hizmetKayitIptal(tempST);
                    }
                },
                {
                    text: i18n("M15889", "Hizmet Kayıt Oku"),
                    disabled: !this.isSGK || this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {
                        that.hizmetKayitOku(tempST, null);
                    }
                },
                {
                    text: i18n("M14874", "Gönderilecek"),
                    disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid || !(this.isSGK || this.isSGKManuel || this.isResmi || this.isPayerTypeHospital),
                    onItemClick: function () {
                        that.hizmetDurumGuncelle(tempST, true);
                    }
                },
                {
                    text: i18n("M14901", "Gönderilmeyecek"),
                    disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid || !(this.isSGK || this.isSGKManuel || this.isResmi || this.isPayerTypeHospital),
                    onItemClick: function () {
                        that.hizmetDurumGuncelle(tempST, false);
                    }
                },
                {

                    text: i18n("M14271", "Faturaya Dahil"),
                    disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {
                        that.hizmetDahillikGuncelle(tempST, true);
                    }
                },
                {

                    text: i18n("M14162", "Fatura Harici"),
                    disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {
                        that.hizmetDahillikGuncelle(tempST, false);
                    }
                },
                {
                    text: 'XML Oku',
                    disabled: this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {
                        that.hizmetXMLOkuFromContextMenu(tempST);
                    }
                },
                {
                    text: i18n("M17394", "Kayıt Geçmişi"),
                    //disabled: this.formOpenPayerType == PayerTypeEnum.Paid,
                    onItemClick: function () {
                        that.getTransactionHistory(e.row.data.ObjectID);
                    }
                },
                {
                    text: 'Yeni Takibe Taşı',
                    onItemClick: function () {
                        that.copySEPWithTransaction(tempST);
                    }
                },
                {
                    text: 'İlaç Ara',
                    onItemClick: function () {
                        if (e.row.data.Basetype != "İLAÇ" && e.row.data.Description != null && e.row.data.ExternalCode != null)
                            that.SearchDrug(e.row.data.Description.toString(), e.row.data.ExternalCode.toString());
                        else
                            that.SearchDrug("", "");
                    }
                },
                {
                    text: 'Malzeme Bilgileri',
                    onItemClick: function () {
                        that.malzemeSatinalmaBilgileriFromContextMenu(e.row.data.ObjectID);
                    }
                },
                {
                    text: 'Nabız Sorgula(700)',
                    onItemClick: function () {
                        that.SGKHizmetSorgulama(tempST);
                    }
                },
                {
                    text: 'Nabız Gönder(700)',
                    onItemClick: function () {
                        that.NabizGonder700(tempST);
                    }
                },
                {
                    text: 'Nabız Gönder(102)',
                    onItemClick: function () {
                        that.NabizGonder(tempST);
                    }
                },
                {
                    text: 'Nabız Sil(102)',
                    onItemClick: function () {
                        that.NabizSil(tempST);
                    }
                },
                //{
                //    text: 'Nabız Yatak Düzenle', 
                //    onItemClick: function () {
                //        that.NabizYatakDuzenle(tempST);
                //    }
                //},
                {
                    text: 'Çevir',
                    items: [
                        {
                            text: 'Kurum Payına (SUT)',
                            onItemClick: function () {
                                that.turnBetweenPayerAndPatient(tempST, false);
                            }
                        },
                        {
                            text: 'Hasta Payına',
                            onItemClick: function () {
                                that.turnBetweenPayerAndPatient(tempST, true);
                            }
                        }
                    ]
                },
                {
                    text: i18n("M12539", "Değiştir"),
                    items: [
                        {

                            text: 'Tarih',
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.tarihGuncelleFromContextMenu(tempST);
                            }
                        }, {

                            text: 'Doktor',
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.doktorGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: i18n("M20080", "Özel Durum"),
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.ozelDurumGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: i18n("M10756", "Alt Vaka"),
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.altVakaGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: i18n("M21336", "Satın Alma Tarihi"),
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.satinAlmaTarihiGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: 'Barkod',
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.barkodGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: i18n("M14320", "Firma Tanımlayıcı Numarası"),
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.firmaTanimlayiciNumarasiGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: 'Bayi No',
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.bayiNoGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: i18n("M18730", "Medula Açıklama"),
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.medulaAciklamaGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: i18n("M20821", "Rapor No"),
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.hizmetRaporNoGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: i18n("M18830", "Medula Yatak Kodu"),
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.hizmetMedulaYatakNoGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: 'Kesi',
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.kesiGuncelleFromContextMenu(tempST);
                            }
                        },
                        {
                            text: 'Accession No',
                            disabled: this.invoiced || this.formOpenPayerType == PayerTypeEnum.Paid,
                            onItemClick: function () {
                                that.accessionNoGuncelleFromContextMenu(tempST);
                            }
                        }
                    ]
                }
                ];
            }
        }
    }
    inOutpatientDateCheckValueChanged(): void {
        this.lifm.InPatientDate = null;
        this.lifm.DischargeDate = null;
        if (this.inpatientDateCheck || this.disChargeDateCheck) {
            if (this.inpatientDateCheck && !this.disChargeDateCheck && this.invoiceSEPFormViewModel.InvoiceSEPDetail.InPatientDate != undefined && this.invoiceSEPFormViewModel.InvoiceSEPDetail.InPatientDate != null)
                this.lifm.InPatientDate = this.invoiceSEPFormViewModel.InvoiceSEPDetail.InPatientDate;
            //this.trxGrid.instance.filter(x => this.datePipe.transform(x.TransactionDate, 'dd.MM.yyyy') == this.datePipe.transform(this.invoiceSEPFormViewModel.InvoiceSEPDetail.InPatientDate, 'dd.MM.yyyy'));
            else if (!this.inpatientDateCheck && this.disChargeDateCheck && this.invoiceSEPFormViewModel.InvoiceSEPDetail.DischargeDate != undefined && this.invoiceSEPFormViewModel.InvoiceSEPDetail.DischargeDate != null)
                this.lifm.DischargeDate = this.invoiceSEPFormViewModel.InvoiceSEPDetail.DischargeDate;
            //this.trxGrid.instance.filter(x => this.datePipe.transform(x.TransactionDate, 'dd.MM.yyyy') == this.datePipe.transform(this.invoiceSEPFormViewModel.InvoiceSEPDetail.DischargeDate, 'dd.MM.yyyy'));
            else if (this.inpatientDateCheck && this.disChargeDateCheck && ((this.invoiceSEPFormViewModel.InvoiceSEPDetail.InPatientDate != undefined && this.invoiceSEPFormViewModel.InvoiceSEPDetail.InPatientDate != null) || (this.invoiceSEPFormViewModel.InvoiceSEPDetail.DischargeDate != undefined && this.invoiceSEPFormViewModel.InvoiceSEPDetail.DischargeDate != null))) {
                this.lifm.InPatientDate = this.invoiceSEPFormViewModel.InvoiceSEPDetail.InPatientDate;
                this.lifm.DischargeDate = this.invoiceSEPFormViewModel.InvoiceSEPDetail.DischargeDate;
            }
            //this.trxGrid.instance.filter(x => this.datePipe.transform(x.TransactionDate, 'dd.MM.yyyy') == this.datePipe.transform(this.invoiceSEPFormViewModel.InvoiceSEPDetail.DischargeDate, 'dd.MM.yyyy') || this.datePipe.transform(x.TransactionDate, 'dd.MM.yyyy') == this.datePipe.transform(this.invoiceSEPFormViewModel.InvoiceSEPDetail.InPatientDate, 'dd.MM.yyyy'));
        }

        this.InvoiceSEPTransactionList.reload();
    }

    onRowPreparedSEPList(e: any): void {
        let i = 0;
        for (i = 0; i < e.columns.length; i++) {
            if (e.columns[i].dataField == "InvoiceStatus") {
                break;
            }
        }
        let blockIndex = 0;
        for (blockIndex = 0; i < e.columns.length; blockIndex++) {
            if (e.columns[blockIndex].dataField == "BlockState") {
                break;
            }
        }

        if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' && e.rowElement.firstItem() !== undefined) {
            let InvoiceStatus = e.data.InvoiceStatus;
            let blockState = e.data.BlockState;
            if (InvoiceStatus === SEPInvoiceStatusDictionary.Invoiced || InvoiceStatus === SEPInvoiceStatusDictionary.InvoiceInconsistent) {
                e.rowElement.firstItem().cells[i].bgColor = '#79cdcd';
                //e.rowElement.firstItem().style.color = '#11583D';
            }
            else if (InvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryCompleted) {
                e.rowElement.firstItem().cells[i].bgColor = '#009acd';
                //e.rowElement.firstItem().style.color = '#11583D';
            }
            else if (InvoiceStatus === SEPInvoiceStatusDictionary.InvoiceEntryWithError ||
                InvoiceStatus === SEPInvoiceStatusDictionary.InvoiceReadWithError ||
                InvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryWithError) {
                e.rowElement.firstItem().cells[i].bgColor = '#C78F8A';
                //e.rowElement.firstItem().style.color = '#380400';
            }

            if (blockState)
                e.rowElement.firstItem().cells[blockIndex].bgColor = '#C78F8A';
            else
                e.rowElement.firstItem().cells[blockIndex].bgColor = '#009acd';
        }
    }

    onRowPreparedDiagnosisList(e: any): void {
        let i = 0;
        for (i = 0; i < e.columns.length; i++) {
            if (e.columns[i].dataField == "CurrentState") {
                break;
            }
        }

        if (e.rowElement.firstItem() != undefined && e.rowType != 'header' && e.rowType != 'filter' && e.rowElement.firstItem() !== undefined) {
            let data: InvoiceSEPDiagnoseListModel = e.data as InvoiceSEPDiagnoseListModel;
            let currentStateDefID = data.CurrentStateDefID;
            if (currentStateDefID == SEPDiagnosis.SEPDiagnosisStates.MedulaEntryUnsuccessful) {
                e.rowElement.firstItem().cells[i].bgColor = '#C78F8A';
                //e.rowElement.firstItem().style.color = '#380400';
            }
            else if (currentStateDefID == SEPDiagnosis.SEPDiagnosisStates.MedulaEntrySuccessful) {
                e.rowElement.firstItem().cells[i].bgColor = '#009acd';
                //e.rowElement.firstItem().style.color = '#000000';
            }
            else if (currentStateDefID == SEPDiagnosis.SEPDiagnosisStates.MedulaDontSend) {
                e.rowElement.firstItem().cells[i].bgColor = '#7f7f7f';
                //e.rowElement.firstItem().style.color = '#424241';
            }
        }
    }

    onRowPreparedTransactionList(e: any): void {
        let i = 0;
        for (i = 0; i < e.columns.length; i++) {
            if (e.columns[i].dataField == "Statetext") {
                break;
            }
        }
        let diffIndex = 0;
        for (diffIndex = 0; diffIndex < e.columns.length; diffIndex++) {
            if (e.columns[diffIndex].dataField == "Diffprice") {
                break;
            }
        }
        let blockIndex = 0;
        for (blockIndex = 0; blockIndex < e.columns.length; blockIndex++) {
            if (e.columns[blockIndex].dataField == "Blocking") {
                break;
            }
        }
        let Index700 = 0;
        for (Index700 = 0; Index700 < e.columns.length; Index700++) {
            if (e.columns[Index700].dataField == "Nabiz700Status") {
                break;
            }
        }


        if (e.rowElement.firstItem() != undefined && e.rowType != 'header' && e.rowType != 'filter' && e.rowType != 'totalFooter') {
            let data: InvoiceSEPTransactionListModel = e.data as InvoiceSEPTransactionListModel;
            let currentState = data.CurrentStateDefID;
            let invoiceInclusion = data.InvoiceInclusion;
            let diffPrice = data.Diffprice;
            let blocking = data.Blocking;
            let nabizStatus = data.Nabiz700Status;
            if (e.rowElement.firstItem().cells[i] != null && e.rowElement.firstItem().cells[i] != undefined) {
                if (currentState == AccountTransaction.AccountTransactionStates.MedulaEntryUnsuccessful) {
                    e.rowElement.firstItem().cells[i].bgColor = '#C78F8A';
                    //e.rowElement.firstItem().style.color = '#380400';
                }
                else if (invoiceInclusion && (currentState == AccountTransaction.AccountTransactionStates.Invoiced || currentState == AccountTransaction.AccountTransactionStates.MedulaEntrySuccessful)) {
                    e.rowElement.firstItem().cells[i].bgColor = '#009acd';
                    //e.rowElement.firstItem().style.color = '#000000';
                }
                else if (!invoiceInclusion && (currentState == AccountTransaction.AccountTransactionStates.Invoiced || currentState == AccountTransaction.AccountTransactionStates.MedulaEntrySuccessful)) {
                    e.rowElement.firstItem().cells[i].bgColor = '#79cdcd';
                    //e.rowElement.firstItem().style.color = '#000000';
                }
                else if (currentState == AccountTransaction.AccountTransactionStates.MedulaDontSend) {
                    e.rowElement.firstItem().cells[i].bgColor = '#7f7f7f';
                    //e.rowElement.firstItem().style.color = '#424241';
                }
            }

            if (diffPrice != null && diffPrice != undefined) {
                if (e.rowElement.firstItem().cells[diffIndex] != null && e.rowElement.firstItem().cells[diffIndex] != undefined) {
                    if (Math.Round(diffPrice, 2) > 0) {
                        e.rowElement.firstItem().cells[diffIndex].bgColor = '#5CB85C';
                        e.rowElement.firstItem().cells[diffIndex].innerHTML = "<i class='fa fa-arrow-up' aria-hidden='true' > </i> " + e.rowElement.firstItem().cells[diffIndex].innerText;
                    }
                    else if (Math.Round(diffPrice, 2) < 0) {
                        e.rowElement.firstItem().cells[diffIndex].bgColor = '#C78F8A';
                        e.rowElement.firstItem().cells[diffIndex].innerHTML = "<i class='fa fa-arrow-down' aria-hidden='true' > </i> " + e.rowElement.firstItem().cells[diffIndex].innerText;
                    }
                }
            }

            if (e.rowElement.firstItem().cells[blockIndex] != null && e.rowElement.firstItem().cells[blockIndex] != undefined) {
                if (blocking) {
                    e.rowElement.firstItem().cells[blockIndex].bgColor = '#C78F8A';
                }
            }

            if (e.rowElement.firstItem().cells[Index700] != null && e.rowElement.firstItem().cells[Index700] != undefined) {
                if (nabizStatus == SendToENabizEnum.Successful) {
                    e.rowElement.firstItem().cells[Index700].bgColor = '#009acd';
                }
                else if (nabizStatus == SendToENabizEnum.UnSuccessful) {
                    e.rowElement.firstItem().cells[Index700].bgColor = '#C78F8A';
                }
            }

        }
    }

    onEditingStartSEPList(e: any): void {

        if (e.data.InvoiceStatus === SEPInvoiceStatusDictionary.Invoiced || e.data.InvoiceStatus === SEPInvoiceStatusDictionary.InvoiceInconsistent)
            e.cancel = true;
        else
            e.cancel = false;

        if (e.column.dataField === 'MedulaProvizyonTarihi' || e.column.dataField === 'MedulaTedaviTuru' || e.column.dataField === 'MedulaTakipTipi') {
            if (e.data.InvoiceStatus === SEPInvoiceStatusDictionary.ProvisionNoNotExists)
                e.cancel = false;
            else
                e.cancel = true;
        }
    }



    onEditingStartTransactionList(e: any): void {
        let that = this;
        for (let i = 0; i < that.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            if (that.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID == that.invoiceSEPFormViewModel.MainSEP) {
                if (that.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus === SEPInvoiceStatusDictionary.Invoiced || that.invoiceSEPFormViewModel.InvoiceSEPList[i].InvoiceStatus === SEPInvoiceStatusDictionary.InvoiceInconsistent) {
                    e.cancel = true;
                    return;
                }
            }
        }

        if ((e.column.dataField === 'MedulaReportNo' || e.column.dataField === 'MedulaBedNo' || e.column.dataField === 'TransactionDate'
            || e.column.dataField === 'AyniFarkliKesi' || e.column.dataField === 'OzelDurum' || e.column.dataField === 'Doctor'
            || e.column.dataField === 'Unitprice' || e.column.dataField === 'Position') &&
            (e.data.CurrentStateDefID === AccountTransaction.AccountTransactionStates.MedulaEntrySuccessful ||
                e.data.CurrentStateDefID === AccountTransaction.AccountTransactionStates.Paid ||
                e.data.CurrentStateDefID === AccountTransaction.AccountTransactionStates.Invoiced))
            e.cancel = true;
        else
            e.cancel = false;

        if (e.column.dataField == "InvoiceInclusion" &&
            (e.data.CurrentStateDefID == AccountTransaction.AccountTransactionStates.MedulaDontSend || e.data.CurrentStateDefID == AccountTransaction.AccountTransactionStates.Paid ||
                e.data.CurrentStateDefID == AccountTransaction.AccountTransactionStates.Invoiced || this.formOpenPayerType == PayerTypeEnum.Paid))
            e.cancel = true;
        else
            e.cancel = false;

    }

    onRowUpdatingSEPList(event: any): void {

        let tempObj: InvoiceSEPListModel = new InvoiceSEPListModel();

        tempObj.ObjectID = event.key.ObjectID;

        if (event.newData.MedulaTedaviTuru != null && event.newData.MedulaTedaviTuru !== undefined)
            tempObj.MedulaTedaviTuru = event.newData.MedulaTedaviTuru;

        if (event.newData.MedulaProvizyonTipi != null && event.newData.MedulaProvizyonTipi !== undefined)
            tempObj.MedulaProvizyonTipi = event.newData.MedulaProvizyonTipi;

        if (event.newData.MedulaTedaviTipi != null && event.newData.MedulaTedaviTipi !== undefined)
            tempObj.MedulaTedaviTipi = event.newData.MedulaTedaviTipi;

        if (event.newData.MedulaTakipTipi != null && event.newData.MedulaTakipTipi !== undefined)
            tempObj.MedulaTakipTipi = event.newData.MedulaTakipTipi;

        if (event.newData.Investigation != null && event.newData.Investigation !== undefined)
            tempObj.Investigation = event.newData.Investigation;

        if (event.newData.Checked != null && event.newData.Checked !== undefined)
            tempObj.Checked = event.newData.Checked;


        if (event.newData.MedulaProvizyonTarihi != null && event.newData.MedulaProvizyonTarihi !== undefined)
            tempObj.MedulaProvizyonTarihi = event.newData.MedulaProvizyonTarihi;
        else
            tempObj.MedulaProvizyonTarihi = event.oldData.MedulaProvizyonTarihi;

        let apiUrlForInvoiceSEPForm: string = '/api/InvoiceApi/UpdateInvoiceSEPList';
        let loadPartitions: Array<number> = new Array<number>();
        loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);		//Transaction lar
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Transaction lar
        this.http.post<boolean>(apiUrlForInvoiceSEPForm, tempObj).then(result => {
            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        }).catch(error => {
            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);

            this.errorHandlerForInvoiceForm(error);
        });
    }

    onRowUpdatingTransactionList(event: any): void {
        if (event.newData.TransactionDate != null && event.newData.TransactionDate !== undefined) {
            let tempST: Array<any> = [];
            tempST.push(event.key);
            this.tarihGuncelle(tempST, event.newData.TransactionDate);
        }
        if (event.newData.OzelDurum != null && event.newData.OzelDurum !== undefined) {
            let tempST: Array<any> = [];
            tempST.push(event.key);
            this.ozelDurumGuncelle(tempST, event.newData.OzelDurum);
        }
        if (event.newData.InvoiceInclusion != null && event.newData.InvoiceInclusion !== undefined) {
            let tempST: Array<any> = [];
            tempST.push(event.key);
            this.hizmetDahillikGuncelle(tempST, event.newData.InvoiceInclusion);
        }
        if (event.newData.Doctor != null && event.newData.Doctor !== undefined) {
            let tempST: Array<any> = [];
            tempST.push(event.key);
            this.doktorGuncelle(tempST, event.newData.Doctor);
        }
        if (event.newData.Unitprice != null && event.newData.Unitprice !== undefined) {
            let tempST: Array<any> = [];
            tempST.push(event.key);
            this.fiyatGuncelle(tempST, event.newData.Unitprice);
        }
        if (event.newData.MedulaReportNo != null && event.newData.MedulaReportNo !== undefined) {
            let tempST: Array<any> = [];
            tempST.push(event.key);
            this.hizmetRaporNoGuncelle(tempST, event.newData.MedulaReportNo);
        }
        if (event.newData.MedulaBedNo != null && event.newData.MedulaBedNo !== undefined) {
            let tempST: Array<any> = [];
            tempST.push(event.key);
            this.medulaYatakNoGuncelle(tempST, event.newData.MedulaBedNo);
        }
        if (event.newData.AyniFarkliKesi != null && event.newData.AyniFarkliKesi !== undefined) {
            let tempST: Array<any> = [];
            tempST.push(event.key);
            this.kesiGuncelle(tempST, event.newData.AyniFarkliKesi);
        }
        if (event.newData.Position != null && event.newData.Position !== undefined) {
            let tempST: Array<any> = [];
            tempST.push(event.key);
            this.sagSolGuncelle(tempST, event.newData.Position);
        }
    }

    onSelectionChangedEpicrisisDetailList(event: any): void {
    }

    //onSelectionChangedDiagnosisGrid(event: any): void {
    //    //this.selectedDiagnosis.Clear();
    //    //for (var i = 0; i < event.selectedRowKeys.length; i++)
    //    //    this.selectedDiagnosis.push(event.selectedRowKeys[i])
    //}

    onSelectionChangedTransactionList(event: any): void {
        //Bu blok Ücretli hastalarda kullanıcı seçtiği işlem satırlarını kaybetmemek ve tekrar seçili olarak getibilmek için yazılmış.
        if (this.formOpenPayerType == PayerTypeEnum.Paid) {
            for (let j = 0; j < this.invoiceSEPFormViewModel.InvoiceSEPList.length; j++) {
                if (this.invoiceSEPFormViewModel.MainSEP == this.invoiceSEPFormViewModel.InvoiceSEPList[j].ObjectID) {
                    if (this.invoiceSEPFormViewModel.InvoiceSEPList[j].SelectedTransactionList != null && this.invoiceSEPFormViewModel.InvoiceSEPList[j].SelectedTransactionList.length > 0)
                        this.invoiceSEPFormViewModel.InvoiceSEPList[j].SelectedTransactionList.Clear();
                    for (let i = 0; i < event.selectedRowKeys.length; i++)
                        this.invoiceSEPFormViewModel.InvoiceSEPList[j].SelectedTransactionList.push(event.selectedRowKeys[i]);

                    this.invoiceSEPFormViewModel.InvoiceSEPList[j].UserChangedSelection = true;
                }
            }
        }
        //Bu blok Ücretli hastalarda kullanıcı seçtiği işlem satırlarını kaybetmemek ve tekrar seçili olarak getibilmek için yazılmış.
    }

    onRowClickSEPList(event: any): void {
        if (event.data.ObjectID != this.invoiceSEPFormViewModel.MainSEP) {
            let localTransArray: any = [];

            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDiagnoseList);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPMaster);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis);


            this.LoadFromSEP(event.data.ObjectID, loadPartitions).then(result => {

                //Bu blok Ücretli hastalarda kullanıcı seçtiği işlem satırlarını kaybetmemek ve tekrar seçili olarak getibilmek için yazılmış.
                if (this.formOpenPayerType == PayerTypeEnum.Paid) {
                    for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
                        if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID == this.invoiceSEPFormViewModel.MainSEP) {
                            if (!this.invoiceSEPFormViewModel.InvoiceSEPList[i].UserChangedSelection) {
                                for (let j = 0; j < this.invoiceSEPFormViewModel.InvoiceSEPTransactionList.length; j++) {
                                    if (this.invoiceSEPFormViewModel.InvoiceSEPTransactionList[j].CurrentStateDefID == AccountTransaction.AccountTransactionStates.Paid)
                                        localTransArray.push(this.invoiceSEPFormViewModel.InvoiceSEPTransactionList[j]);
                                }
                                this.selectedTransactions = localTransArray;
                                this.invoiceSEPFormViewModel.InvoiceSEPList[i].SelectedTransactionList = new Array<InvoiceSEPTransactionListModel>();

                                for (let j = 0; j < this.selectedTransactions.length; j++) {
                                    this.invoiceSEPFormViewModel.InvoiceSEPList[i].SelectedTransactionList.push(this.selectedTransactions[j]);
                                }
                            }
                            else if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].SelectedTransactionList.length > 0) {
                                for (let j = 0; j < this.invoiceSEPFormViewModel.InvoiceSEPList[i].SelectedTransactionList.length; j++) {
                                    localTransArray.push(this.invoiceSEPFormViewModel.InvoiceSEPList[i].SelectedTransactionList[j]);
                                }
                                this.selectedTransactions = localTransArray;
                            }
                        }
                    }
                }
                //Bu blok Ücretli hastalarda kullanıcı seçtiği işlem satırlarını kaybetmemek ve tekrar seçili olarak getibilmek için yazılmış.
            });
        }
    }

    onRowClickPatientSEPList(event: any): void {
        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            this.loadFromPatientSEPList(event.data.ObjectID, event.data.PayetTypeEnum);
        }
    }

    public showMedulaErrorPopupMessage: string;
    onRowClickTransactionList(event: any): void {
        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            if (event.data.MedulaResultMessage != null && event.data.MedulaResultMessage != "" && event.data.CurrentStateDefID == AccountTransaction.AccountTransactionStates.MedulaEntryUnsuccessful) {
                this.showMedulaErrorMessagePopup = true;
                this.showMedulaErrorPopupMessage = "[" + event.data.MedulaResultCode + "] - " + event.data.MedulaResultMessage;
            }
            //TTVisual.InfoBox.Alert( );
        }
    }

    onFocusInMedulaSonucMesaji(event: any): void {
        this.showMedulaErrorMessagePopup = true;
        this.showMedulaErrorPopupMessage = this.invoiceSEPFormViewModel.InvoiceSEPDetail.MedulaSonucMesaji;
    }

    gridRowCount(data: any) {
        return data.value + " Adet Hizmet/Malzeme";
    }

    onItemClickTopMenu(event: any): void {
        if (event.itemData.fnName !== undefined)
            this[event.itemData.fnName]();
    }

    onValueChangedBagliTakipPopup(e: any): void {
        this.bagliTakipNo = e.value;
    }

    onItemClickInvoiceTypes(e: any): void {
        this.formOpenPayerType = e.itemData.id;

        this.RouteData.ObjectID = this.invoiceSEPFormViewModel.MainSEP;
        this.RouteData.Type = this.formOpenPayerType;

        this.ngOnInit();
    }



    GenerateSEPListColumns() {
        let that = this;
        this.InvoiceSEPListColumns = [
            {
                caption: 'ID',
                dataField: 'Id',
                allowEditing: false,
                width: '3%'
            }, {
                caption: i18n("M17021", "Kabul No"),
                dataField: 'KabulNo',
                allowEditing: false,
                width: '5%'
            },
            {
                caption: i18n("M20585", "Provizyon Tar."),
                dataField: 'MedulaProvizyonTarihi',
                dataType: 'date',
                format: 'dd/MM/yyyy',
                width: '7%'
            },
            {
                caption: 'Durum',
                dataField: 'InvoiceStatus',
                allowEditing: false,
                dataType: 'string',
                width: '12%'
            },
            {
                caption: i18n("M22659", "Takip No"),
                dataField: 'MedulaTakipNo',
                allowEditing: false,
                dataType: 'string',
                width: '5%'
            },
            {
                caption: 'Bağlı Takip No',
                dataField: 'MedulaBagliTakipNo',
                allowEditing: false,
                width: '5%'
            },

            {
                caption: 'Birim',
                dataField: 'SubEpisodeResSection',
                allowEditing: false,
                width: '14%'
            },
            {
                caption: i18n("M15593", "HBYS Tutar"),
                dataField: 'HBYSPrice',
                allowEditing: false,
                width: '5%'
            },
            {
                caption: i18n("M14214", "Fatura Tutar"),
                dataField: 'InvoicePrice',
                allowEditing: false,
                width: '5%'
            },
            {
                caption: i18n("M23037", "Tedavi Türü"),
                dataField: 'MedulaTedaviTuru',
                lookup: { dataSource: that.tedaviTuruArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                width: '8%'
            },
            {
                caption: i18n("M20587", "Provizyon Tipi"),
                dataField: 'MedulaProvizyonTipi',
                lookup: { dataSource: that.provizyonTipiArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                width: '9%'
            },
            {
                caption: i18n("M23033", "Tedavi Tipi"),
                dataField: 'MedulaTedaviTipi',
                lookup: { dataSource: that.tedaviTipiArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                width: '9%'
            },
            {
                caption: i18n("M22673", "Takip Tipi"),
                dataField: 'MedulaTakipTipi',
                lookup: { dataSource: that.takipTipiArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                width: '9%'
            },
            {
                caption: "İ",
                dataField: 'Investigation',
                dataType: 'boolean',
                width: '2%'
            },
            {
                caption: "K",
                dataField: 'Checked',
                dataType: 'boolean',
                width: '2%'
            },
            {
                caption: "E",
                dataField: 'BlockState',
                dataType: 'boolean',
                width: '2%'
            }];

    }

    public AddNewProcedureGridColumns = [];
    GenerateAddNewProcedureColumns(): void {
        let that = this;
        this.AddNewProcedureGridColumns = [
            {
                caption: 'Kod',
                dataField: 'Code',
                allowEditing: false,
                width: '11%'
            }, {
                caption: 'Ad',
                dataField: 'Name',
                allowEditing: false,
                width: '48%'
            }, {
                caption: i18n("M10505", "Adet"),
                dataField: 'Amount',
                width: '7%'
            }, {
                caption: 'Tarih',
                dataField: 'TransactionDate',
                dataType: 'date',
                format: 'dd/MM/yyyy',
                width: '10%'
            }, {
                caption: 'Doktor',
                dataField: 'Doctor',
                lookup: { dataSource: that.doctorArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                width: '24%'
            }
        ];
    }

    public HistoryGridColumns = [
        {
            caption: 'Mesaj',
            dataField: 'Message',
            width: '50%'
        }, {
            caption: i18n("M16818", "İşlem"),
            dataField: 'Operation',
            width: '20%'
        }, {
            caption: i18n("M17893", "Kullanıcı"),
            dataField: 'UserName',
            width: '15%'
        }, {
            caption: 'Tarih',
            dataField: 'Date',
            width: '10%'
        }
    ];

    public MaterialPurchaseInfoGridColumns = [
        {
            caption: 'Başlık',
            dataField: 'Header',
            width: '25%'
        }, 
        {
            caption: 'Değer',
            dataField: 'Value',
            width: '75%'
        }
    ];

    public AfterInvoiceOperationGridColumns = [
        {
            caption: i18n("M22393", "Sut Kodu"),
            dataField: 'sutCode',
            width: '15%'
        }, {
            caption: 'Sut Adı',
            dataField: 'sutName',
            width: '35%'
        }, {
            caption: i18n("M19030", "Miktar"),
            dataField: 'totalAmount',
            width: '10%'
        }, {
            caption: i18n("M23606", "Tutar"),
            dataField: 'totalPrice',
            width: '20%'
        }
    ];


    public MedulaExtraProvisionInfoColumns = [
        {
            caption: 'Başvuru No',
            allowEditing: false,
            dataField: 'hastaBasvuruNo',
            width: '10%'
        },
        {
            caption: i18n("M22659", "Takip No"),
            allowEditing: false,
            dataField: 'takipNo',
            width: '10%'
        },
        {
            caption: 'Tarih',
            allowEditing: false,
            dataField: 'takipTarihi',
            width: '15%'
        },
        {
            caption: i18n("M12048", "Branş"),
            allowEditing: false,
            dataField: 'bransKodu',
            width: '40%'
        },
        {
            caption: i18n("M23037", "Tedavi Türü"),
            allowEditing: false,
            dataField: 'tedaviTuru',
            width: '20%'
        },
        {
            caption: 'HBYS ID',
            allowEditing: false,
            dataField: 'ID',
            width: '10%'
        },
        {
            caption: i18n("M22274", "Statü"),
            allowEditing: false,
            dataField: 'durum',
            width: '10%'
        },
        {
            cellTemplate: 'buttonDeleteProvisionCellTemplate',
            width: '10%'
        }
    ];

    public MedulaInpatientFirstAndLastDateColumns = [
        {
            caption: i18n("M24448", "Yatış Tarihi"),
            allowEditing: false,
            dataField: 'baslangicTarihi',
            width: '30%'
        }, {
            caption: i18n("M12379", "Çıkış Tarihi"),
            allowEditing: false,
            dataField: 'bitisTarihi',
            width: '30%'
        }, {
            caption: i18n("M14131", "Fatura Durumu"),
            allowEditing: false,
            dataField: 'durum',
            width: '30%'
        }, {
            caption: i18n("M24444", "Yatış Sil"),
            width: '10%',
            allowEditing: false,
            cellTemplate: 'buttonDeleteInpatientCellTemplate',
            allowSorting: false
        }

    ];

    public InvoiceBlockingGridColumns = [
        {
            caption: i18n("M19116", "Modül"),
            allowEditing: false,
            dataField: 'ModuleName',
            width: '10%'
        },
        {
            caption: i18n("M13738", "Engelleyen Kul."),
            allowEditing: false,
            dataField: 'BlockUserName',
            width: '15%'
        },
        {
            caption: 'Engel Tar.',
            allowEditing: false,
            dataField: 'BlockDate',
            width: '7%'
        },
        {
            caption: i18n("M13725", "Engel Açıklaması"),
            allowEditing: false,
            dataField: 'BlockDescription',
            width: '20%'
        },
        {
            caption: i18n("M13732", "Engeli Kal.Kul."),
            allowEditing: false,
            dataField: 'UnblockUserName',
            width: '15%'
        },
        {
            caption: i18n("M13733", "Engeli Kal.Tar."),
            allowEditing: false,
            dataField: 'UnblockDate',
            width: '7%'
        },
        {
            caption: i18n("M13729", "Engel Kal. Açıklaması"),
            allowEditing: true,
            dataField: 'UnblockDescription',
            width: '20%'
        },
        {
            caption: i18n("M16818", "İşlem"),
            allowEditing: false,
            cellTemplate: 'buttonPassTemplate',
            width: '7%'
        }
    ];

    public PatientSEPListColumns =
        [
            {
                caption: 'No',
                dataField: 'Id',
                width: '4%'
            },

            {
                caption: i18n("M17021", "Kabul No"),
                dataField: 'HospitalProtocolNo',
                width: '4%'
            },
            {
                caption: 'Başvuru No',
                dataField: 'MedulaBasvuruNo',
                width: '5%'
            },
            {
                caption: i18n("M22659", "Takip No"),
                dataField: 'MedulaTakipNo',
                width: '5%'
            },
            {
                caption: 'Bağlı Takip No',
                dataField: 'Medulatakipno1',
                width: '5%'
            },
            {
                caption: 'Tarih',
                dataField: 'Date',
                dataType: 'date',
                format: 'dd.MM.yyyy',
                width: '5%'
            },
            {
                caption: i18n("M12048", "Branş"),
                dataField: 'Specialityname',
                width: '12%'
            }, {
                caption: 'Birim',
                dataField: 'SubEpisodeResSection',
                width: '12%'
            },
            {
                caption: 'Durum',
                dataField: 'Status',
                width: '10%'
            },
            {
                caption: i18n("M23037", "Tedavi Türü"),
                dataField: 'Tedavituru',
                width: '10%'
            },
            {
                caption: i18n("M18009", "Kurum"),
                dataField: 'Payername',
                width: '13%'
            },
            {
                caption: 'Fat.No',
                dataField: 'InvoiceNo',
                width: '5%'
            },
            {
                caption: 'Fat.Tar.',
                dataField: 'InvoiceDate',
                dataType: 'date',
                format: 'dd.MM.yyyy',
                width: '5%'
            },
            {
                caption: i18n("M14098", "Fat.Tutar"),
                dataField: 'MedulaFaturaTutari',
                width: '5%'
            }
        ];

    TransactionInvoiceReadColumns = [
        { caption: 'SıraNo', dataField: 'islemSiraNoField', width: '15%' },
        { caption: i18n("M23606", "Tutar"), dataField: 'islemTutariField', width: '10%' },
        { caption: 'Tarih', dataField: 'islemTarihiField', width: '15%' },
        { caption: 'Kodu', dataField: 'islemKoduField', width: '15%' },
        { caption: i18n("M10514", "Adı"), dataField: 'islemAdiField', width: '45%' }
    ];

    TransactionReadColumns = [
        { caption: 'TİP', dataField: 'type', fixed: true, width: '120' },
        { caption: 'İ.Sıra No', dataField: 'islemSiraNo', fixed: true, width: '110' },
        { caption: i18n("M15817", "Hiz.Sun.RefNo"), dataField: 'hizmetSunucuRefNo', fixed: true, width: '110' },
        { caption: 'İşlem T.', dataField: 'islemTarihi', fixed: true, width: '80' },
        { caption: 'Kod', dataField: 'sutKodu', fixed: true, width: '80' },
        { caption: i18n("M10505", "Adet"), dataField: 'adet', fixed: true, width: '60' },
        { caption: i18n("M12048", "Branş"), dataField: 'bransKodu', fixed: true, width: '100' },
        { caption: i18n("M13346", "Dr.Tescil"), dataField: 'drTescilNo', fixed: true, width: '100' },
        { caption: i18n("M10469", "Açıklama"), dataField: 'aciklama', fixed: true, width: '150' },
        { caption: 'Kesi', dataField: 'ayniFarkliKesi', width: '50' },
        { caption: 'Euroscore', dataField: 'Euroscore', width: '100' },
        { caption: i18n("M19840", "Ö.Durum"), dataField: 'ozelDurum', width: '100' },
        { caption: 'Sağ/Sol', dataField: 'sagSol', width: '90' },
        { caption: i18n("M20854", "Rapor Takip"), dataField: 'raporTakipNo', width: '90' },
        { caption: 'Ref.Gün.S', dataField: 'refakatciGunSayisi', width: '100' },
        { caption: 'Yatak K.', dataField: 'yatakKodu', width: '80' },
        { caption: i18n("M24424", "Yatış Baş.T."), dataField: 'yatisBaslangicTarihi', width: '90' },
        { caption: i18n("M24426", "Yatış Bit.T."), dataField: 'yatisBitisTarihi', width: '90' },
        { caption: 'Birim', dataField: 'birim', width: '70' },
        { caption: i18n("M22078", "Sonuç"), dataField: 'sonuc', width: '70' },
        { caption: i18n("M16375", "İlaç Tür"), dataField: 'ilacTuru', width: '80' },
        { caption: i18n("M20126", "P.Hariç"), dataField: 'paketHaric', width: '80' },
        { caption: 'İ.Tutar', dataField: 'tutar', width: '80', alignment: 'right' },
        { caption: i18n("M13238", "Donör Id"), dataField: 'donorId', width: '80' },
        { caption: 'Firma T.No', dataField: 'firmaTanimlayiciNo', width: '100' },
        { caption: 'İhale K.T.', dataField: 'ihaleKesinlesmeTarihi', width: '90' },
        { caption: 'İkNoAlimNo', dataField: 'ikNoAlimNo', width: '80' },
        { caption: i18n("M17368", "Katkı Payı"), dataField: 'katkiPayi', width: '80' },
        { caption: 'KDV', dataField: 'kdv', width: '80' },
        { caption: i18n("M18550", "Malzeme Adı"), dataField: 'kodsuzMalzemeAdi', width: '150' },
        { caption: i18n("M18571", "Malzeme Fiyat"), dataField: 'kodsuzMalzemeFiyati', width: '120', alignment: 'right' },
        { caption: i18n("M18587", "Malzeme Kodu"), dataField: 'malzemeKodu', width: '150' },
        { caption: 'M.Satın Al.T.', dataField: 'malzemeSatinAlisTarihi', width: '150' },
        { caption: i18n("M18614", "Malzeme Türü"), dataField: 'malzemeTuru', width: '120' },

        { caption: i18n("M16576", "İsbt Bileşen No"), dataField: 'isbtBilesenNo', width: '130' },
        { caption: 'İsbt Ünite No', dataField: 'isbtUniteNo', width: '120' },

        { caption: 'Anomali', dataField: 'anomali', width: '100' },
        { caption: i18n("M12944", "Diş Taahhüt No"), dataField: 'disTaahhutNo', width: '120' },

        { caption: i18n("M21126", "Sağ Alt Çene"), dataField: 'sagAltCene', width: '110' },
        { caption: 'Sağ A.Çene An.', dataField: 'sagAltCeneAnomaliDis', width: '120' },
        { caption: i18n("M21144", "Sağ Süt A.Ç."), dataField: 'sagSutAltCene', width: '100' },
        { caption: i18n("M21145", "Sağ Süt Üst Ç."), dataField: 'sagSutUstCene', width: '120' },
        { caption: i18n("M21151", "Sağ Üst Ç."), dataField: 'sagUstCene', width: '100' },
        { caption: 'Sağ Ü.Çene An.', dataField: 'sagUstCeneAnomaliDis', width: '120' },

        { caption: i18n("M22002", "Sol Alt Çene"), dataField: 'solAltCene', width: '100' },
        { caption: 'Sol A.Çene An.', dataField: 'solAltCeneAnomaliDis', width: '120' },
        { caption: i18n("M22015", "Sol Süt A.Ç."), dataField: 'solSutAltCene', width: '100' },
        { caption: i18n("M22016", "Sol Süt Üst Ç."), dataField: 'solSutUstCene', width: '100' },
        { caption: i18n("M22020", "Sol Üst Ç."), dataField: 'solUstCene', width: '100' },
        { caption: 'Sol Ü.Çene An.', dataField: 'solUstCeneAnomaliDis', width: '120' }
    ];

    InvoiceDiagnoseListColumns = [
        {
            caption: 'Referans No',
            dataField: 'Id'
        },
        {
            caption: 'Kod',
            dataField: 'Diagnose.Code'
        },
        {
            caption: i18n("M22736", "Tanı"),
            dataField: 'Diagnose.Name'
        },
        {
            caption: i18n("M10926", "Ana Tanı"),
            dataField: 'IsMainDiagnose'
        },
        {
            caption: i18n("M22781", "Tanı Tipi"),
            dataField: 'DiagnosisType'
        },
        {
            caption: 'Durum',
            dataField: 'CurrentState'
        },
        {
            caption: i18n("M18768", "Medula İşlem No"),
            dataField: 'MedulaProcessNo'
        },
        {
            caption: i18n("M22099", "Sonuç Kodu"),
            dataField: 'MedulaResultCode'
        },
        {
            caption: i18n("M22103", "Sonuç Mesajı"),
            dataField: 'MedulaResultMessage'
        },
        {
            caption: i18n("M20080", "Özel Durum"),
            dataField: 'OzelDurum'
        }
    ];

    DoctorListColumns =
        [
            {
                caption: i18n("M10514", "Adı"),
                dataField: 'drAdi'
            },
            {
                caption: i18n("M22205", "Soyadı"),
                dataField: 'drSoyadi'
            },
            {
                caption: i18n("M12860", "Diploma No"),
                dataField: 'drDiplomaNo'
            },
            {
                caption: 'Tescil No',
                dataField: 'drTescilNo'
            }
        ];

    BedListColumns =
        [
            {
                caption: i18n("M24363", "Yatak Kodu"),
                dataField: 'yatakKodu'
            },
            {
                caption: i18n("M23679", "Türü"),
                dataField: i18n("M10041", "_turu")
            },
            {
                caption: i18n("M23204", "Tescil Türü"),
                dataField: 'tescilTuru'
            },
            {
                caption: i18n("M21692", "Seviye"),
                dataField: i18n("M21692", "Seviye")
            },
            {
                caption: i18n("M14596", "Geçerlikik Başlangıç T."),
                dataField: 'gecerlilikBaslangicTarihi'
            },
            {
                caption: i18n("M14597", "Geçerlikik Bitiş T."),
                dataField: 'gecerlilikBitisTarihi'
            }
        ];

    DrugListColumns = [
        {
            caption: 'Kullanım Birimi',
            dataField: 'kullanimBirimi'
        },
        {
            caption: 'Barkod',
            dataField: 'barkod'
        },
        {
            caption: i18n("M16294", "İlaç Adı"),
            dataField: 'ilacAdi'
        },
        {
            caption: 'Ecz. Aktif/Pasif',
            dataField: 'eczAktifPasif'
        },
        {
            caption: 'Hasta Aktif/Pasif',
            dataField: 'hasAktifPasif'
        },
        {
            caption: i18n("M11294", "Ayaktan Ödeme"),
            dataField: i18n("M11301", "ayaktanOdenme")
        },
        {
            caption: i18n("M24409", "Yatan Ödeme"),
            dataField: 'yatanOdenme'
        },
    ];

    GenerateTransactionColumns(columnNameAndOrder: Array<string>) {
        let that = this;
        this.InvoiceTransactionListColumns = [
            {
                caption: i18n("M16895", "İşlem Türü"),
                dataField: 'Medulatype',
                allowEditing: false,
                dataType: 'string',
                visible: false,
                width: '120'
            },
            {
                caption: 'Ref. No',
                dataField: 'Id',
                allowEditing: false,
                dataType: 'number',
                visible: false,
                width: '100'
            },
            {
                caption: 'Durum',
                dataField: 'Statetext',
                allowEditing: false,
                dataType: 'string',
                visible: false,
                width: '130'
            },
            {
                caption: i18n("M16838", "İşlem Durumu"),
                dataField: 'ProcedureState',
                allowEditing: false,
                dataType: 'string',
                visible: false,
                width: '120'
            },
            {
                caption: 'SUT Tipi',
                dataField: 'Suttype',
                allowEditing: false,
                dataType: 'string',
                visible: false,
                width: '80'
            },
            {
                caption: 'Tarih',
                dataField: 'TransactionDate',
                dataType: 'date',
                format: 'dd/MM/yyyy',
                allowHeaderFiltering: false,
                visible: false,
                width: '100'
            },
            {
                caption: 'Kod',
                dataField: 'ExternalCode',
                allowEditing: false,
                dataType: 'string',
                visible: false,
                width: '70'
            },
            {
                caption: i18n("M10514", "Adı"),
                dataField: 'Description',
                allowEditing: false,
                dataType: 'string',
                visible: false,
                width: '240'
            },
            {
                caption: 'Dahil',
                dataField: 'InvoiceInclusion',
                dataType: 'boolean',
                //showEditorAlways: true,
                visible: false,
                width: '70'
            },
            {
                caption: i18n("M11845", "Bir.Fiyat"),
                dataField: 'Unitprice',
                visible: false,
                dataType: 'number',
                width: '80'
            },
            {
                caption: i18n("M10505", "Adet"),
                dataField: 'Amount',
                allowEditing: false,
                dataType: 'number',
                visible: false,
                width: '40'
            },
            {
                caption: i18n("M15591", "HBYS Fiyat"),
                dataField: 'Totalprice',
                allowEditing: false,
                dataType: 'number',
                visible: false,
                width: '100'
            },
            {
                caption: 'M.Fiyatı',
                dataField: 'MedulaPrice',
                allowEditing: false,
                dataType: 'number',
                visible: false,
                width: '80'
            },
            {
                caption: 'Randevu Tar.',
                dataField: 'AppDate',
                allowEditing: false,
                visible: false,
                dataType: 'string',
                allowFiltering: false,
                allowSearch: false,
                allowSorting: false,
                allowHeaderFiltering: false,
                width: '80'
            },
            {
                caption: 'Fark',
                dataField: 'Diffprice',
                allowEditing: false,
                dataType: 'number',
                visible: false,
                width: '80'
            },
            {
                caption: 'Engel',
                dataField: 'Blocking',
                dataType: 'boolean',
                allowEditing: false,
                //showEditorAlways: true,
                visible: false,
                width: '70'
            },
            {
                caption: i18n("M19887", "Ödenen Tutar"),
                dataField: 'Totalpayment',
                allowEditing: false,
                dataType: 'number',
                visible: false,
                width: '80'
            }, {
                caption: 'Doktor',
                dataField: 'Doctor',
                lookup: { dataSource: that.doctorArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                visible: false,
                dataType: 'string',
                width: '120'
            },

            {
                caption: i18n("M20853", "Rapor T.No"),
                dataField: 'MedulaReportNo',
                allowEditing: true,
                dataType: 'string',
                visible: false,
                width: '100'
            },
            {
                caption: i18n("M24365", "Yatak No"),
                dataField: 'MedulaBedNo',
                allowEditing: true,
                dataType: 'string',
                visible: false,
                width: '120'
            },
            {
                caption: i18n("M22098", "Sonuç Kod"),
                dataField: 'MedulaResultCode',
                allowEditing: false,
                dataType: 'string',
                visible: false,
                width: '100'
            },
            {
                caption: i18n("M22102", "Sonuç Mes."),
                dataField: 'MedulaResultMessage',
                allowEditing: false,
                dataType: 'string',
                visible: false,
                width: '150'
            },
            {
                caption: i18n("M20078", "Özel D."),
                dataField: 'OzelDurum',
                lookup: { dataSource: that.ozelDurumArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                visible: false,
                dataType: 'string',
                width: '150'
            },
            {
                caption: 'Kesi',
                dataField: 'AyniFarkliKesi',
                lookup: { dataSource: that.kesiArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                visible: false,
                dataType: 'string',
                width: '150'
            },
            {
                caption: 'M.İşlem No',
                dataField: 'MedulaProcessNo',
                visible: false,
                allowEditing: false,
                dataType: 'number',
                width: '120'
            },
            {
                caption: 'ÜTS Kul.Kesin.',
                dataField: 'UTSUsageCommitment',
                dataType: 'boolean',
                visible: false,
                allowEditing: false,
                width: '120'
            },
            {
                caption: "Nabız Durum",
                dataField: 'Nabiz700Status',
                lookup: { dataSource: that.Nabiz700StatusArray, valueExpr: 'Id', displayExpr: 'Name' },
                allowEditing: false,
                dataType: 'number',
                visible: false,
                width: '100'
            },
            {
                caption: "Nabız S. Kod",
                dataField: 'NabizResultCode',
                allowEditing: false,
                dataType: 'string',
                visible: false,
                width: '100'
            },
            {
                caption: "Nabız S. Mes.",
                dataField: 'NabizResultMessage',
                allowEditing: false,
                dataType: 'string',
                visible: false,
                width: '150'
            },
            {
                caption: "Amel.G.",
                dataField: 'SurgerySutGroup',
                allowEditing: false,
                allowHeaderFiltering: false,
                allowFiltering: false,
                allowSearch: false,
                allowSorting: false,
                dataType: 'string',
                visible: false,
                width: '50'
            },
            {
                caption: "Sağ/Sol",
                dataField: 'Position',
                lookup: { dataSource: SurgeryLeftRight.Items, valueExpr: 'ordinal', displayExpr: 'description' },
                allowEditing: true,
                allowHeaderFiltering: false,
                allowFiltering: false,
                allowSearch: false,
                allowSorting: false,
                dataType: 'string',
                visible: false,
                width: '100'
            }
        ];

        let i = 0;
        if (columnNameAndOrder.length > 0) {
            for (let item of columnNameAndOrder) {
                for (let baseItem of this.InvoiceTransactionListColumns) {
                    if (item == baseItem.dataField) {
                        baseItem.visible = true;
                        baseItem.visibleIndex = i;
                        if (i == 0) {
                            baseItem.sortOrder = 'desc';
                            baseItem.sortIndex = 0;
                        }
                        i++;
                    }
                }
            }

        }
        else {
            for (let baseItem of this.InvoiceTransactionListColumns) {
                baseItem.visible = true;
                baseItem.visibleIndex = i;
                if (i == 0) {
                    baseItem.sortOrder = 'desc';
                    baseItem.sortIndex = 0;
                }
                i++;
            }
        }

    }

    customizeMoney(data) {
        return Math.Round(data.value, 2);
    }

    public visibleTransactionColumnList: any;
    onContentReadyTransactionList(e: any): void {
        this.visibleTransactionColumnList = e.component.getVisibleColumns();
        //this.trxGrid.instance.updateDimensions();
    }

    deleteUserCustomization(): void {
        let apiUrlForInvoiceTransactionList: string = '/api/InvoiceApi/DeleteUserCustomization?gridName=TransactionList&pageName=InvoiceSEPForm';
        this.http.get(apiUrlForInvoiceTransactionList).then(response => {
            ServiceLocator.MessageService.showSuccess(i18n("M17906", "Kullanıcı Liste Özelleştirmeleri Temizlendi."));
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    showSEPDescriptions(): void {
        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
            if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].Description != null && this.invoiceSEPFormViewModel.InvoiceSEPList[i].Description != "" && this.invoiceSEPFormViewModel.InvoiceSEPList[i].Description != undefined)
                ServiceLocator.MessageService.showError(this.invoiceSEPFormViewModel.InvoiceSEPList[i].Description);

        }
    }

    async addWatchList(): Promise<void> {

        let awl: any = {};
        awl.objectIDList = new Array<any>();
        awl.objectIDList.push(this.invoiceSEPFormViewModel.MainSEP);

        awl.resUserObjectID = null;


        if (awl.objectIDList.length > 0) {

            let takipBazliHizmetKayitUrl = '/api/CollectiveInvoiceOpTopMenuApi/AddWatchList';
            this.http.post<Guid>(takipBazliHizmetKayitUrl, awl).then(response => {
                ServiceLocator.MessageService.showSuccess("Başvuru izlem listeme eklendi.");
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
        }

        return;


    }

    removeWatchList(): void {
        let awl: any = {};
        awl.objectIDList = new Array<any>();
        awl.objectIDList.push(this.invoiceSEPFormViewModel.MainSEP);

        awl.resUserObjectID = null;


        if (awl.objectIDList.length > 0) {

            let takipBazliHizmetKayitUrl = '/api/CollectiveInvoiceOpTopMenuApi/RemoveWatchList';
            this.http.post<Guid>(takipBazliHizmetKayitUrl, awl).then(response => {
                ServiceLocator.MessageService.showSuccess("Başvuru izlem listesinden çıkarıldı.");
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
        }

        return;
    }


    async clearSEPDescription(): Promise<void> {
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/clearSEPDescription';
        let ibsm: any = {};

        ibsm.sepObjectID = this.invoiceSEPFormViewModel.MainSEP;

        if (ibsm.sepObjectID != null && ibsm.sepObjectID != undefined && ibsm.sepObjectID != Guid.Empty) {
            this.http.post(apiUrlForgetRule, ibsm)
                .then(response => {
                    ServiceLocator.MessageService.showSuccess(i18n("M14101", "Fatura Açıklamaları Başarı İle Temizlendi."));

                    let loadPartitions: Array<number> = new Array<number>();
                    loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                    loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);	//SEP ler

                    this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);

                })
                .catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }
    }

    async saveSEPDescription(): Promise<void> {
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/saveNewInvoiceDescription';
        let ibsm: any = {};

        ibsm.sepObjectID = this.invoiceSEPFormViewModel.MainSEP;

        let description: string = await InputForm.GetText(i18n("M14107", "Fatura Açıklaması Giriniz."), '', false, true);

        if (description !== '' && description !== null && description !== undefined) {
            if (description.length > 0) {
                ibsm.invoiceBlockingDescription = description;

                if (ibsm.sepObjectID != null && ibsm.sepObjectID != undefined && ibsm.sepObjectID != Guid.Empty) {
                    this.http.post(apiUrlForgetRule, ibsm)
                        .then(response => {
                            ServiceLocator.MessageService.showSuccess(i18n("M14105", "Fatura Açıklaması Başarı ile Kayıt Edildi."));

                            let loadPartitions: Array<number> = new Array<number>();
                            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);	//SEP ler

                            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);

                        })
                        .catch(error => {
                            this.errorHandlerForInvoiceForm(error);
                        });
                }
            }
        }
    }

    deleteYatisCikisKayit(row: any): void {

        let yckm: any = {};

        yckm.sepObjectID = this.invoiceSEPFormViewModel.MainSEP;
        yckm.ClinicDischargeDate = row.data.bitisTarihi;



        this.loadPanelOperation(true, i18n("M18841", "Meduladan yatış çıkış bilgisi iptal ediliyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/YatisCikisKayitIptal';

        this.http.post<string>(apiUrlForgetRule, yckm)
            .then(result => {
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showInfo(result);
                this.medulaInpatientOperation();
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
    }

    public newYatisCikisTarihi: any;

    saveNewYatisCikis(): void {

        let yatanObj = this.tedaviTuruArray.filter(x => x.Name == i18n("M24229", "Y Yatarak Tedavi"));

        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {

            if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID == this.invoiceSEPFormViewModel.MainSEP) {
                if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTedaviTuru != yatanObj[0].ObjectID) {
                    ServiceLocator.MessageService.showError("Tedavi Türü 'Y Yatarak Tedavi' haricinde olan takip satırları için yatış çıkış bilgisi sorgulanamaz.");
                    return;
                }
            }
        }

        let yckm: any = {};

        yckm.sepObjectID = this.invoiceSEPFormViewModel.MainSEP;
        yckm.ClinicDischargeDate = this.MedulaInpatientInfo.ClinicDischargeDate;



        this.loadPanelOperation(true, i18n("M18857", "Medulaya yatış çıkış bilgisi kayıt ediliyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/YatisCikisKayit';

        this.http.post<string>(apiUrlForgetRule, yckm)
            .then(result => {
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showInfo(result);
                this.medulaInpatientOperation();
            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });



    }

    medulaInpatientOperation(): void {

        let yatanObj = this.tedaviTuruArray.filter(x => x.Name == i18n("M24229", "Y Yatarak Tedavi"));

        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {

            if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].ObjectID == this.invoiceSEPFormViewModel.MainSEP) {
                if (this.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaTedaviTuru != yatanObj[0].ObjectID) {
                    ServiceLocator.MessageService.showError("Tedavi Türü 'Y Yatarak Tedavi' haricinde olan takip satırları için yatış çıkış bilgisi sorgulanamaz.");
                    return;
                }
            }
        }


        this.loadPanelOperation(true, i18n("M18840", "Meduladan yatış bilgisi okunuyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/HastaYatisOku?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;

        this.http.get<HastaYatisOkuCevapDVO>(apiUrlForgetRule)
            .then(result => {
                this.loadPanelOperation(false, '');

                this.MedulaInpatientInfo = result;

                this.showMedulaInpatientOpPopup = true;

            })
            .catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });



    }

    medulaReadExtraProvision(): void {

        this.MedulaExtraProvisionInfo.sonTarih = new Date();
        this.MedulaExtraProvisionInfo.ilkTarih = (new Date()).AddDays(-30);
        if (this.invoiceSEPFormViewModel.InvoiceSEPMaster.UniqueRefNo != null)
            this.MedulaExtraProvisionInfo.tc = this.invoiceSEPFormViewModel.InvoiceSEPMaster.UniqueRefNo.toString();
        else {
            ServiceLocator.MessageService.showError(i18n("M20573", "Provizyon alınabilir TC alanı boş geçilemez!"));
        }

        this.ReadExtraProvision();
    }
    deleteMedulaExtraProvision(row: any): void {
        if (row.data.ID == "0" || (row.data.ID != "0" && row.data.durum == i18n("M16526", "İptal"))) {


            this.loadPanelOperation(true, i18n("M18837", "Meduladan takip bilgileri siliniyor, lütfen bekleyiniz."));
            let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/FazlaTakipSil';

            let model: any = {};

            model.takipNo = row.data.takipNo;

            this.http.post<string>(apiUrlForgetRule, model)
                .then(result => {
                    this.ReadExtraProvision();
                    ServiceLocator.MessageService.showInfo(result);
                })
                .catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }
        else {
            ServiceLocator.MessageService.showError("HBYS ile ilişkilendirilmiş takipler fatura kartı üzerinden silinebilir.");
            return;
        }
    }

    ReadExtraProvision(): void {
        this.loadPanelOperation(true, i18n("M18836", "Meduladan takip bilgileri okunuyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/FazlaTakipOku?tc=' + this.MedulaExtraProvisionInfo.tc + '&ilkTarih=' + this.datePipe.transform(this.MedulaExtraProvisionInfo.ilkTarih, 'dd.MM.yyyy') + '&sonTarih=' + this.datePipe.transform(this.MedulaExtraProvisionInfo.sonTarih, 'dd.MM.yyyy');
        this.http.get<Array<FazlaTakipDTO>>(apiUrlForgetRule)
            .then(result => {
                this.MedulaExtraProvisionInfo.takipListesi = result;
                this.showMedulaExtraProvisionPopup = true;
                this.loadPanelOperation(false, '');
            })
            .catch(error => {
                this.showMedulaExtraProvisionPopup = true;
                this.errorHandlerForInvoiceForm(error);
            });

    }


    SearchDoctor(): void {
        this.showMedulaDoctorSearchPopup = true;
        this.loadPanelOperation(true, i18n("M18832", "Meduladan doktor bilgileri okunuyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/DoktorAra';

        this.http.post<doktorAraCevapDVO>(apiUrl, this.DoktorAraGirisSearchModel).then(x => {
            if (x != null) {
                this.DoktorAraCevapDVO = x;
                if (!String.isNullOrEmpty(this.DoktorAraCevapDVO.sonucMesaji) && this.DoktorAraCevapDVO.sonucKodu != "0000")
                    ServiceLocator.MessageService.showError(this.DoktorAraCevapDVO.sonucMesaji);
            }
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.loadPanelOperation(false, '');
        });

    }

    SearchBeds() {

        this.loadPanelOperation(true, i18n("M18839", "Meduladan yatak bilgileri okunuyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/TesisYatakSorgu';

        this.http.post<tesisYatakSorguCevapDVO>(apiUrl, this.TesisYatakSorguSearchModel).then(x => {
            if (x != null) {
                this.TesisYatakSorguCevapDVO = x;
                this.showMedulaBedSearchPopup = true;
                //if (!String.isNullOrEmpty(this.TesisYatakSorguCevapDVO.sonucMesaji) && this.TesisYatakSorguCevapDVO.sonucKodu != "0000")
                //    ServiceLocator.MessageService.showError(this.TesisYatakSorguCevapDVO.sonucMesaji);
            }
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.showMedulaBedSearchPopup = true;
            this.loadPanelOperation(false, '');
        });
    }

    public tedaviRaporuOkuTC: any;
    public ilacRaporuOkuTC: any;
    public MedulaTedaviRaporuFTROkuArray: Array<FTRTedaviRaporuOkuDTO>;
    public MedulaIlacRaporuOkuArray: Array<IlacRaporuOkuDTO>;
    public MedulaTedaviRaporuFTROkuSelected: FTRTedaviRaporuOkuDTO;
    public SuitableFTRTransactionDS: Array<SuitableFTRTransaction>;
    public selectedFTRTransactions: Array<SuitableFTRTransaction>;
    public UTSMaterialArray: Array<UTSMaterialDTO>;
    public UXXXXXXesinlestirmeSorguArray: Array<UXXXXXXesinlestirmeSorguDTO>;
    public MedulaTedaviRaporuFTROkuResultMessage: any;
    public MedulaIlacRaporuOkuResultMessage: any;
    public MedulaTedaviRaporuFTROkuResultNameSurname: any;
    public MedulaIlacRaporuOkuResultNameSurname: any;
    public MedulaUXXXXXXesinlestirmeSorguResultMessage: any;

    public medulaFTRRaporOku(): void {

        this.MedulaTedaviRaporuFTROkuSelected = new FTRTedaviRaporuOkuDTO();
        this.MedulaTedaviRaporuFTROkuArray = new Array<FTRTedaviRaporuOkuDTO>();
        this.MedulaTedaviRaporuFTROkuResultMessage = "";
        this.loadPanelOperation(true, i18n("M18838", "Meduladan tedavi raporları(FTR) bilgileri okunuyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/TedaviRaporuOkuFTR?TC=' + this.tedaviRaporuOkuTC;
        let that = this;
        this.http.get<FTRTedaviRaporuOkuDTOList>(apiUrl).then(x => {
            x.raporList.forEach(rapor => {
                rapor.butKodu = that.getGroupFromButCode(rapor.butKodu);
            });
            this.MedulaTedaviRaporuFTROkuArray = x.raporList;
            this.MedulaTedaviRaporuFTROkuResultMessage = x.totalMessage;
            this.MedulaTedaviRaporuFTROkuResultNameSurname = x.nameSurname;
            this.loadPanelOperation(false, '');
            this.showMedulaTedaviRaporuOkuPopup = true;
        });
    }

    public getGroupFromButCode(butCode: string): string {
        if (butCode.Equals("P915033"))
            return "A Grubu (" + butCode + ")";
        else if (butCode.Equals("P915032"))
            return "B Grubu (" + butCode + ")";
        else if (butCode.Equals("P915031"))
            return "C Grubu (" + butCode + ")";
        else if (butCode.Equals("P915030"))
            return "D Grubu (" + butCode + ")";
        else
            return "Tanımsız (" + butCode + ")";
    }

    onRowClickMedulaTedaviRaporuFTROku(event: any): void {
        this.MedulaTedaviRaporuFTROkuSelected = event.data;
        this.MedulaTedaviRaporuFTROkuTransactions(event.data.raporTakipNo);
    }
    MedulaTedaviRaporuFTROkuTransactions(raporTakipNo: string): void {
        this.loadPanelOperation(true, 'Rapor ile ilişkili hizmetler getiriliyor, lütfen bekleyiniz.');
        let apiUrl: string = '/api/InvoiceTopMenuApi/TedaviRaporuOkuGetTransactions?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP + '&raporTakipNo=' + raporTakipNo + '&TC=' + this.tedaviRaporuOkuTC;
        let that = this;
        this.http.get<Array<SuitableFTRTransaction>>(apiUrl).then(x => {
            this.selectedFTRTransactions = new Array<SuitableFTRTransaction>();
            this.SuitableFTRTransactionDS = x;
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.SuitableFTRTransactionDS = new Array<SuitableFTRTransaction>();
            this.loadPanelOperation(false, '');
        });
    }

    async btnChangeMedulaReportNoByPopup(): Promise<void> {

        let tempST: Array<any> = [];

        for (let i = 0; i < this.selectedFTRTransactions.length; i++) {

            let tempItem: InvoiceSEPTransactionListModel = new InvoiceSEPTransactionListModel();
            tempItem.ObjectID = this.selectedFTRTransactions[i].accTrxObjectID;
            tempItem.CurrentStateDefID = this.selectedFTRTransactions[i].CurrentStateDefID;
            tempItem.TransactionDate = this.selectedFTRTransactions[i].TransactionDate;
            tempItem.ExternalCode = this.selectedFTRTransactions[i].ExternalCode;
            tempItem.Id = this.selectedFTRTransactions[i].Id;
            tempST.push(tempItem);
        }

        let a = await this.hizmetRaporNoGuncelle(tempST, this.MedulaTedaviRaporuFTROkuSelected.raporTakipNo);
        this.MedulaTedaviRaporuFTROkuTransactions(this.MedulaTedaviRaporuFTROkuSelected.raporTakipNo);
    }

    public medulaFTRRaporOkuFromTopMenu(): void {
        this.tedaviRaporuOkuTC = this.invoiceSEPFormViewModel.InvoiceSEPMaster.UniqueRefNo;
        this.medulaFTRRaporOku();
    }
    public medulaIlacRaporOkuFromTopMenu(): void {
        this.ilacRaporuOkuTC = this.invoiceSEPFormViewModel.InvoiceSEPMaster.UniqueRefNo;
        this.medulaIlacRaporOku();
    }
    public medulaIlacRaporOku(): void {
        this.loadPanelOperation(true, i18n("M18838", "Meduladan ilaç raporları bilgileri okunuyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/IlacRaporOkuFromTC?TC=' + this.ilacRaporuOkuTC;
        let that = this;
        this.http.get<IlacRaporuOkuDTOList>(apiUrl).then(x => {
            this.MedulaIlacRaporuOkuArray = x.raporList;
            this.MedulaIlacRaporuOkuResultMessage = x.totalMessage;
            this.MedulaIlacRaporuOkuResultNameSurname = x.nameSurname;
            this.loadPanelOperation(false, '');
            this.showMedulaIlacRaporuOkuPopup = true;
        }).catch(error => {
            this.loadPanelOperation(false, '');
        });
    }

    public medulaUXXXXXXullanimKesinlestirmeFromTopMenu(): void {
        this.loadPanelOperation(true, i18n("M18838", "ÜTS Kullanım Kesinleştirme ekranı açılıyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/GetUTSMaterials?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.http.get<Array<UTSMaterialDTO>>(apiUrl).then(result => {
            this.UTSMaterialArray = new Array<UTSMaterialDTO>();
            this.UTSMaterialArray = result;
            this.loadPanelOperation(false, '');
            this.showUTSUsageCommitmentPopup = true;
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    public medulaUXXXXXXullanimKesinlestirmeSorgu(): void {
        this.loadPanelOperation(true, i18n("M18838", "ÜTS Kullanım Kesinleştirme sorgulanıyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/UXXXXXXullanimKesinlestirmeSorgu?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.http.get<UXXXXXXesinlestirmeSorguSonucDTO>(apiUrl).then(result => {
            this.UXXXXXXesinlestirmeSorguArray = result.detailList;
            this.MedulaUXXXXXXesinlestirmeSorguResultMessage = result.message;
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    public medulaUXXXXXXullanimKesinlestirme(): void {
        let that = this;
        if (that.selectedUTSMaterials.length === 0)
            ServiceLocator.MessageService.showError("Malzeme seçiniz.");
        else {
            this.loadPanelOperation(true, i18n("M18838", "ÜTS Kullanım Kesinleştirme yapılıyor, lütfen bekleyiniz."));
            let apiUrl: string = '/api/InvoiceTopMenuApi/UXXXXXXullanimKesinlestirme';
            this.http.post<MedulaResult>(apiUrl, that.selectedUTSMaterials).then(result => {
                this.loadPanelOperation(false, '');
                if (result.Succes)
                    ServiceLocator.MessageService.showSuccess(result.SonucKodu + ' ' + result.SonucMesaji);
                else
                    ServiceLocator.MessageService.showError(result.SonucKodu + ' ' + result.SonucMesaji);

                that.medulaUXXXXXXullanimKesinlestirmeFromTopMenu(); // Malzeme gridi güncellenir
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
        }
    }

    public medulaUXXXXXXullanimKesinlestirmeIptal(): void {
        let that = this;
        if (that.selectedUTSMaterials.length === 0)
            ServiceLocator.MessageService.showError("Malzeme seçiniz.");
        else {
            this.loadPanelOperation(true, i18n("M18838", "ÜTS Kullanım Kesinleştirme iptal ediliyor, lütfen bekleyiniz."));
            let apiUrl: string = '/api/InvoiceTopMenuApi/UXXXXXXullanimKesinlestirmeIptal';
            this.http.post<Array<MedulaResult>>(apiUrl, that.selectedUTSMaterials).then(result => {
                this.loadPanelOperation(false, '');
                let allSuccessful: boolean = true;
                for (let i = 0; i < result.length; i++) {
                    if (!result[i].Succes) {
                        allSuccessful = false;
                        ServiceLocator.MessageService.showError(result[i].SonucKodu + ' ' + result[i].SonucMesaji);
                    }
                }
                if (allSuccessful)
                    ServiceLocator.MessageService.showSuccess(result[0].SonucKodu + ' ' + result[0].SonucMesaji);

                that.medulaUXXXXXXullanimKesinlestirmeFromTopMenu(); // Malzeme gridi güncellenir
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
        }
    }

    public medulaDokumanIslemleriFromTopMenu(isShowPopup: boolean = true): void {
        this.loadPanelOperation(true, i18n("M18838", "Döküman İşlemleri ekranı açılıyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/GetUploadedDocuments?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;

        if (isShowPopup) {
            this.documentOperationsModel = new DocumentOperationsModel();
        }

        this.http.get<MedulaDokumanIslemModel>(apiUrl).then(result => {
            this.documentOperationsModel.takipNo = result.header.takipNo;
            this.documentOperationsModel.uploadedDocumentArray = result.documentArray;

            this.loadPanelOperation(false, '');
            this.showDocumentOperationsPopup = true;
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });

        this.loadPanelOperation(false, '');
        this.showDocumentOperationsPopup = true;
    }

    public medulaTakipDokumanListesiSorgu(): void {
        this.loadPanelOperation(true, i18n("M18838", "Medula Takip Döküman Listesi sorgulanıyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/MedulaTakipDokumanListesiSorgu';

        let request: MedulaTakipDokumanSorguModel = new MedulaTakipDokumanSorguModel();
        request.header.evrakId = this.documentOperationsModel.evrakId;
        request.header.sepObjectID = this.invoiceSEPFormViewModel.MainSEP;

        this.http.post<MedulaTakipDokumanSorguSonucModel>(apiUrl, request).then(result => {
            this.documentOperationsModel.medulaTakipDokumanArray = result.medulaDocumentArray;
            this.documentOperationsModel.medulaTakipDokumanListesiSorguResultMessage = result.message;
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    public medulaDokumanKaydet(): void {
        let that = this;
        if (that.documentOperationsModel.selectedUploadedDocumentArray.length === 0)
            ServiceLocator.MessageService.showError("Döküman seçiniz.");
        else {
            this.loadPanelOperation(true, i18n("M18838", "Dökümanlar kaydediliyor, lütfen bekleyiniz."));
            let apiUrl: string = '/api/InvoiceTopMenuApi/MedulaDokumanKaydet';

            let request: MedulaDokumanIslemModel = new MedulaDokumanIslemModel();
            request.header.evrakId = this.documentOperationsModel.evrakId;
            request.header.sepObjectID = this.invoiceSEPFormViewModel.MainSEP;
            request.documentArray = that.documentOperationsModel.selectedUploadedDocumentArray;

            this.http.post<Array<MedulaResult>>(apiUrl, request).then(result => {
                this.loadPanelOperation(false, '');
                let allSuccessful: boolean = true;
                for (let i = 0; i < result.length; i++) {
                    if (!result[i].Succes) {
                        allSuccessful = false;
                        ServiceLocator.MessageService.showError(result[i].SonucKodu + ' ' + result[i].SonucMesaji);
                    }
                }
                if (allSuccessful)
                    ServiceLocator.MessageService.showSuccess(result[0].SonucKodu + ' ' + result[0].SonucMesaji);

                that.medulaDokumanIslemleriFromTopMenu(false); // Eklenmiş Dökümanlar gridi güncellenir
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
        }
    }

    public medulaDokumanSil(): void {
        let that = this;
        if (that.documentOperationsModel.selectedUploadedDocumentArray.length === 0)
            ServiceLocator.MessageService.showError("Döküman seçiniz.");
        else {
            this.loadPanelOperation(true, i18n("M18838", "Dökümanlar siliniyor, lütfen bekleyiniz."));
            let apiUrl: string = '/api/InvoiceTopMenuApi/MedulaDokumanSil';

            let request: MedulaDokumanIslemModel = new MedulaDokumanIslemModel();
            request.header.evrakId = this.documentOperationsModel.evrakId;
            request.header.sepObjectID = this.invoiceSEPFormViewModel.MainSEP;
            request.documentArray = that.documentOperationsModel.selectedUploadedDocumentArray;

            this.http.post<Array<MedulaResult>>(apiUrl, request).then(result => {
                this.loadPanelOperation(false, '');
                let allSuccessful: boolean = true;
                for (let i = 0; i < result.length; i++) {
                    if (!result[i].Succes) {
                        allSuccessful = false;
                        ServiceLocator.MessageService.showError(result[i].SonucKodu + ' ' + result[i].SonucMesaji);
                    }
                }
                if (allSuccessful)
                    ServiceLocator.MessageService.showSuccess(result[0].SonucKodu + ' ' + result[0].SonucMesaji);

                that.medulaDokumanIslemleriFromTopMenu(false); // Eklenmiş Dökümanlar gridi güncellenir
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
        }
    }

    public dokumanIndir(): void {
        let that = this;
        if (that.documentOperationsModel.selectedUploadedDocumentArray.length === 0)
            ServiceLocator.MessageService.showError("Döküman seçiniz.");
        else {
            for (let doc of that.documentOperationsModel.selectedUploadedDocumentArray) {
                let apiUrl: string = '/api/DocumentDownloadService/DownloadFile';
                let input = { id: doc.objectID };
                let headers = new Headers();
                headers.set('Content-Type', 'application/json');
                let options = new RequestOptions();
                options.headers = headers;
                options.responseType = ResponseContentType.Blob;

                this.http2.post(apiUrl, JSON.stringify(input), options).toPromise().then(
                    (res) => {
                        const blob = new Blob([res.blob()], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });
                        CommonHelper.saveFile(res.blob(), doc.dosyaAdi);
                    });
            }
        }
    }

    public medulaBarcodeSUTMatchFromTopMenu(): void {
        this.barcodeSUTMatch = new BarcodeSUTMatchModel();
        this.showBarcodeSUTMatchPopup = true;
    }

    public medulaBarcodeSUTMatchQuery(): void {
        this.loadPanelOperation(true, i18n("M18838", "Medula Barkod SUT Eşleşme sorgulanıyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/MedulaBarcodeSUTMatchQuery';

        this.http.post<BarcodeSUTMatchModel>(apiUrl, this.barcodeSUTMatch.queryInput).then(result => {
            this.barcodeSUTMatch.medulaBarcodeSUTMatchArray = result.medulaBarcodeSUTMatchArray;
            this.barcodeSUTMatch.resultMessage = result.resultMessage;
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    public medulaENabizBildirimSorguFromTopMenu(): void {
        this.loadPanelOperation(true, i18n("M18838", "E-Nabız Bildirim Sorgulama ekranı açılıyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/GetENabizNotification?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;
        this.http.get<Array<ENabizBildirimHizmetModel>>(apiUrl).then(result => {
            this.eNabizBildirimHizmetArray = result;
            this.loadPanelOperation(false, '');
            this.showENabizBildirimSorguPopup = true;
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }
    public showMedulaVefatKayitPopup: boolean = false;
    public kisiVefatKayitFromTopMenu(): void {

        this.MedulaVefatKayitInfo.tc = this.invoiceSEPFormViewModel.InvoiceSEPMaster.UniqueRefNo.toString();
        this.showMedulaVefatKayitPopup = true;
    }

    VefatKayit(): void {
        this.loadPanelOperation(true, i18n("M18833", "Medulaya vefat bilgisi kayıt ediliyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/VefatKayit';
        this.http.post<VefatKayitBilgileriDTO>(apiUrl, this.MedulaVefatKayitInfo).then(x => {
            this.MedulaVefatKayitInfo = x;
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    public SuitableFTRTransactionColumns = [
        {
            caption: 'Ref. No',
            dataField: 'Id',
            allowEditing: false,
            width: '65'
        },
        {
            caption: 'Takip No',
            dataField: 'MedulaProvisionNo',
            allowEditing: false,
            width: '130',
            groupIndex: 0
        }, {
            caption: 'Takip Tar.',
            dataField: 'MedulaProvisionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: '100'
        },
        {
            caption: 'İşlem Durumu',
            dataField: 'CurrentState',
            allowEditing: false,
            width: '140'
        }, {
            caption: 'İşlem Tarih',
            dataField: 'TransactionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: '100'
        }, {
            caption: 'Kod',
            dataField: 'ExternalCode',
            allowEditing: false,
            width: '70'
        },
        {
            caption: 'Adı',
            dataField: 'Description',
            allowEditing: false,
            width: '240'
        },
        {
            caption: 'Rapor T.No',
            dataField: 'MedulaReportNo',
            allowEditing: false,
            width: '100'
        }
    ];
    public MedulaTedaviRaporuOkuColumns =
        [
            {
                caption: 'R.Takip No',
                dataField: 'raporTakipNo',
                width: '10%'
            },
            {
                caption: i18n("M11635", "Başlangıç T."),
                dataField: 'raporBaslangicTarihi',
                width: '10%'
            },
            {
                caption: i18n("M11937", "Bitiş T."),
                dataField: 'raporBitisTarihi',
                width: '10%'
            },

            {
                caption: i18n("M14980", "Grubu"),
                dataField: 'butKodu',
                width: '16%'
            }, {
                caption: i18n("M24187", "Vücut Bölgesi"),
                dataField: 'vucutBolgesi',
                width: '20%'
            },
            {
                caption: i18n("M21478", "Seans Gün"),
                dataField: 'seansGun',
                width: '10%'
            },
            {
                caption: i18n("M21488", "Seans Sayı"),
                dataField: 'seansSayi',
                width: '10%'
            },
            {
                caption: i18n("M23037", "Tedavi Türü"),
                dataField: 'tedaviTuru',
                width: '14%'
            }
        ];

    public MedulaIlacRaporuOkuColumns =
        [
            {
                caption: 'Rapor Takip No',
                dataField: 'raporTakipNo',
                width: '20%',
                groupIndex: 0,
                sortOrder: 'desc',
                sortIndex: 0
            },
            {
                caption: "Başlangıç T.",
                dataField: 'basTarihi',
                width: '20%'
            },
            {
                caption: "Bitiş T.",
                dataField: 'bitTarihi',
                width: '20%'
            },
            {
                caption: "Etkin M.",
                dataField: 'ilacEtkinMadde',
                width: '20%'
            }, {
                caption: "Tesis Kodu",
                dataField: 'saglikTesisKodu',
                width: '20%'
            }
        ];

    public UTSMaterialColumns =
        [
            {
                caption: 'Referans No',
                dataField: 'id',
                width: '10%',
            },
            {
                caption: "Tarih",
                dataField: 'transactionDate',
                width: '10%'
            },
            {
                caption: "Adı",
                dataField: 'description',
                width: '40%'
            },
            {
                caption: "Kesinleştirme",
                dataField: 'utsUsageCommitment',
                width: '10%'
            },
            {
                caption: "Sonuç Kodu",
                dataField: 'resultCode',
                width: '10%'
            },
            {
                caption: "Sonuç Mesajı",
                dataField: 'resultMessage',
                width: '20%'
            }
        ];

    public UXXXXXXesinlestirmeSorguColumns =
        [
            {
                caption: 'Kullanım Bildirim No',
                dataField: 'kullanimBildirimID',
                width: '30%',
            },
            {
                caption: "Tesis Kodu",
                dataField: 'saglikTesisKodu',
                width: '10%'
            },
            {
                caption: "TC Kimlik No",
                dataField: 'tcKimlikNo',
                width: '10%'
            },
            {
                caption: "Seri No",
                dataField: 'seriNo',
                width: '10%'
            },
            {
                caption: 'Lot No',
                dataField: 'lotNo',
                width: '10%',
            },
            {
                caption: "Hiz.Sun.Ref.No",
                dataField: 'hizmetSunucuReferansNo',
                width: '10%'
            },
            {
                caption: "Takip No",
                dataField: 'takipNo',
                width: '10%'
            },
            {
                caption: "Durum",
                dataField: 'durum',
                width: '10%'
            }
        ];

    public UploadedDocumentColumns =
        [
            {
                caption: "Kayıt Ref. No",
                dataField: 'kayitReferansNo',
                width: '10%'
            },
            {
                caption: "Evrak No",
                dataField: 'evrakId',
                width: '10%'
            },
            {
                caption: "Takip No",
                dataField: 'takipNo',
                width: '10%'
            },
            {
                caption: 'Dosya Kabul No',
                dataField: 'protocolNo',
                width: '15%',
            },
            {
                caption: "Dosya Türü",
                dataField: 'dosyaTuru',
                width: '15%'
            },
            {
                caption: "Dosya Adı",
                dataField: 'dosyaAdi',
                width: '25%'
            },
            {
                caption: "Açıklama",
                dataField: 'explanation',
                width: '15%'
            }
        ];

    public MedulaTakipDokumanColumns =
        [
            {
                caption: "Evrak No",
                dataField: 'evrakId',
                width: '10%'
            },
            {
                caption: "Takip No",
                dataField: 'takipNo',
                width: '10%'
            },
            {
                caption: "Kayıt Ref. No",
                dataField: 'kayitReferansNo',
                width: '10%'
            },
            {
                caption: 'İşlem Sıra No',
                dataField: 'islemSiraNo',
                width: '10%',
            },
            {
                caption: "Dosya Türü",
                dataField: 'dosyaTuru',
                width: '20%'
            },
            {
                caption: "Dosya Adı",
                dataField: 'dosyaAdi',
                width: '40%'
            }
        ];

    public MedulaBarcodeSUTMatchColumns =
        [
            {
                caption: "Barkod",
                dataField: 'barkod',
                width: '20%'
            },
            {
                caption: "Firma Tanımlayıcı No",
                dataField: 'firmaTanimlayiciNo',
                width: '20%'
            },
            {
                caption: "SUT Kodu",
                dataField: 'sutKodu',
                width: '20%'
            },
            {
                caption: 'Başlangıç Tarihi',
                dataField: 'baslangicTarihi',
                width: '20%',
            },
            {
                caption: "Bitiş Tarihi",
                dataField: 'bitisTarihi',
                width: '20%'
            }
        ];

    public ENabizBildirimColumns =
        [
            {
                caption: "Hizmet Sunucu Ref. No",
                dataField: 'hizmetSunucuRefNo',
                width: '33%'
            },
            {
                caption: "İşlem Kodu",
                dataField: 'islemKodu',
                width: '34%'
            },
            {
                caption: "İşlem Tarihi",
                dataField: 'islemTarihi',
                width: '33%'
            }
        ];

    SearchDrug(drugName: string, barcode: string): void {
        if (!String.isNullOrEmpty(drugName) || !String.isNullOrEmpty(barcode)) {
            this.IlacAraGirisSearchModel.ilacAdi = drugName;
            this.IlacAraGirisSearchModel.barkod = barcode;
        }
        // else {
        //     this.IlacAraGirisSearchModel.ilacAdi = "";
        //     this.IlacAraGirisSearchModel.barkod = "";
        // }
        this.showMedulaDrugSearchPopup = true;
        this.loadPanelOperation(true, i18n("M18833", "Meduladan ilaç bilgileri okunuyor, lütfen bekleyiniz."));
        let apiUrl: string = '/api/InvoiceTopMenuApi/IlacAra';
        this.http.post<ilacAraCevapDVO>(apiUrl, this.IlacAraGirisSearchModel).then(x => {
            if (x != null) {
                this.IlacAraCevapDVO = x;
                this.IlacAraCevapDVO.ilaclar.forEach(element => {
                    if (element.eczAktifPasif == 'A')
                        element.eczAktifPasif = 'Aktif';
                    else
                        element.eczAktifPasif = 'Pasif';

                    if (element.hasAktifPasif == 'A')
                        element.hasAktifPasif = 'Aktif';
                    else
                        element.hasAktifPasif = 'Pasif';

                    switch (element.ayaktanOdenme) {
                        case '1':
                            element.ayaktanOdenme = i18n("M19889", "Ödenir");
                            break;
                        case '2':
                            element.ayaktanOdenme = i18n("M20885", "Raporla Ödenir");
                            break;
                        case '3':
                            element.ayaktanOdenme = i18n("M19891", "Ödenmez");
                            break;
                        default:
                            break;
                    }

                });

                if (!String.isNullOrEmpty(this.IlacAraCevapDVO.sonucMesaji) && this.IlacAraCevapDVO.sonucKodu != "0000")
                    ServiceLocator.MessageService.showError(this.IlacAraCevapDVO.sonucMesaji);
            }
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.loadPanelOperation(false, '');
        });
    }

    public selectedSubepisodes: Array<any>;
    saveAddNewPayer(): void {

        let sanp: any = {};
        if (this.selectedSubepisodes == undefined || this.selectedSubepisodes.length == 0) {
            ServiceLocator.MessageService.showError(i18n("M24570", "Yeni kurum eklenecek en az bir tane vaka seçilmiş olmalıdır."));
            return;
        }
        else if (this.addNewPayer == null || this.addNewPayer == undefined) {
            ServiceLocator.MessageService.showError(i18n("M13559", "Eklenecek yeni kurum seçilmiş olmalı."));
            return;
        }
        else if (this.addNewProtocol == null || this.addNewProtocol == undefined) {
            ServiceLocator.MessageService.showError(i18n("M13560", "Eklenecek yeni kuruma ait bir anlaşma seçilmiş olmalı."));
            return;
        }
        sanp.Subepisodes = new Array<any>();
        for (let i = 0; i < this.selectedSubepisodes.length; i++) {
            sanp.Subepisodes.push(this.selectedSubepisodes[i].SubEpisodeObjectID);
        }

        sanp.Payer = this.addNewPayer;
        sanp.Protocol = this.addNewProtocol;

        let newFormOpenType: any;
        for (let item of this.payerArray) {
            if (item.ObjectID == this.addNewPayer)
                newFormOpenType = item.Code;
        }

        let apiUrlForUserCustomizationKayit: string = '/api/InvoiceTopMenuApi/AddNewPayer';

        this.http.post<Guid>(apiUrlForUserCustomizationKayit, sanp).then(response => {
            this.addPayerPopup = false;

            this.formOpenPayerType = newFormOpenType;
            this.RouteData.Type = newFormOpenType;
            this.RouteData.ObjectID = response;

            this.ngOnInit();

            ServiceLocator.MessageService.showSuccess(i18n("M18048", "Kurum ekleme işlemi başarı ile sonuçlandı."));
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });


    }

    public addNewPayer: Guid;
    public addNewProtocol: Guid;
    public subEpisodeArrayForAddPayer: Array<any>;
    public subEpisodeArrayForAddPayerColumns = [
        {
            caption: 'Birim',
            dataField: 'SubEpisodeResSection',
            width: '70%',
            allowSorting: false
        },
        {
            caption: 'Tarih',
            dataField: 'Date',
            format: 'dd/MM/yyyy',
            width: '30%',
            allowSorting: false
        }
    ];


    testButton(): void {
        console.log(this.trxGridInstance.instance);
    }

    showInvoiceReport(): void {
        const objectIdParam = new GuidParam(this.invoiceSEPFormViewModel.InvoiceSEPDetail.PayerInvoiceDocumentObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('PayerInvoiceReport2', reportParameters);
    }

    showMedulaInvoiceProceduresReport(): void {
        const objectIdParam = new GuidParam(this.invoiceSEPFormViewModel.InvoiceSEPDetail.PayerInvoiceDocumentObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('MedulaInvoiceProceduresReport', reportParameters);
    }

    showEpicrisisReport(): void {
        let url = 'api/InvoiceTopMenuApi/GetEpisodeActionObjectIDForSEP?sepObjectID=' + this.invoiceSEPFormViewModel.InvoiceSEPDetail.ObjectID;
        this.http.get<Guid>(url).then(response => {
            if (response != Guid.Empty) {
                const objectIdParam = new StringParam(response.toString());
                const doctorParam = new StringParam(Guid.Empty.toString());
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'Doctor': doctorParam };
                this.reportService.showReport('EpicrisisReportForPatient', reportParameters);
            }
            else
                ServiceLocator.MessageService.showError("Epikriz raporu için gerekli işlem bilgisine ulaşılamadı.");
        });
    }

    showLISResult(): void {
        this.viewLISResultURL = "";
        this.GetViewResultURLForPatient().then(() => {
            this.openInNewTab(this.viewLISResultURL);
        });
    }

    public async GetViewResultURLForPatient(): Promise<void> {
        let inputDVO = new TestResultQueryInputDVO();

        if (this.invoiceSEPFormViewModel.InvoiceSEPMaster.UniqueRefNo != null)
            inputDVO.PatientTCKN = this.invoiceSEPFormViewModel.InvoiceSEPMaster.UniqueRefNo.toString();
        else
            inputDVO.PatientTCKN = "10000000000";
        //inputDVO.EpisodeID = this.EpisodeAction.Episode.ID.toString();

        let apiUrl: string = 'api/ProcedureRequestService/GetURLForAllEpisodeTestResults';
        let result = await this.http.post<string>(apiUrl, inputDVO);
        this.viewLISResultURL = result;
    }

    openInNewTab(url) {
        if (url == null) {
            InfoBox.Alert(i18n("M12080", "Laboratuvar sonucu bulunamadı!"));
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }

    addPayer(): void {
        let that = this;

        that.subEpisodeArrayForAddPayer = new Array<any>();
        this.http.get<Array<any>>("api/InvoiceDefinitionApi/GetPayer").then(result => {


            for (let i = 0; i < that.invoiceSEPFormViewModel.InvoiceSEPList.length; i++) {
                let singleSubEpisode: any = {};
                let found = false;
                for (let j = 0; j < this.subEpisodeArrayForAddPayer.length; j++) {
                    if (that.subEpisodeArrayForAddPayer[j].SubEpisodeObjectID == that.invoiceSEPFormViewModel.InvoiceSEPList[i].SubEpisodeObjectID)
                        found = true;
                }
                if (!found) {
                    singleSubEpisode.SubEpisodeObjectID = that.invoiceSEPFormViewModel.InvoiceSEPList[i].SubEpisodeObjectID;
                    singleSubEpisode.SubEpisodeResSection = that.invoiceSEPFormViewModel.InvoiceSEPList[i].SubEpisodeResSection;
                    singleSubEpisode.Date = that.invoiceSEPFormViewModel.InvoiceSEPList[i].MedulaProvizyonTarihi;
                    that.subEpisodeArrayForAddPayer.push(singleSubEpisode);
                }
            }

            this.addPayerPopup = true;
            this.payerArray = result;
            this.protocolArray = null;
            this.addNewPayer = null;
            this.addNewProtocol = null;

        });
    }


    public newPayer: Guid;
    public newProtocol: Guid;

    changePayer(): void {
        this.http.get<Array<any>>("api/InvoiceDefinitionApi/GetPayer").then(result => {
            this.changePayerPopup = true;
            this.payerArray = result;
            this.protocolArray = null;
            this.newPayer = new Guid;
            this.newProtocol = new Guid;
        });
    }

    changePayerSelectboxChanged(e: any): void {
        this.http.get<Array<any>>("api/InvoiceDefinitionApi/GetProtocol?payerObjectID=" + e.value).then(result => {
            this.protocolArray = result;
        });
    }

    saveNewPayer(): void {

        let cp: any = {};

        cp.newPayer = this.newPayer;
        cp.newProtocol = this.newProtocol;
        cp.sepObjectID = this.invoiceSEPFormViewModel.MainSEP;
        let newFormOpenType: any;
        for (let item of this.payerArray) {
            if (item.ObjectID == this.newPayer)
                newFormOpenType = item.Code;
        }

        let apiUrlForUserCustomizationKayit: string = '/api/InvoiceTopMenuApi/SaveNewPayer';

        this.http.post<Guid>(apiUrlForUserCustomizationKayit, cp).then(response => {
            this.changePayerPopup = false;

            this.formOpenPayerType = newFormOpenType;
            this.RouteData.Type = newFormOpenType;
            this.RouteData.ObjectID = response;

            this.ngOnInit();

            ServiceLocator.MessageService.showSuccess(i18n("M18041", "Kurum değiştirme işlemi başarı ile sonuçlandı."));
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }
    closeSearchDoctorPopup() {
        this.showMedulaDoctorSearchPopup = false;
        this.DoktorAraCevapDVO = new doktorAraCevapDVO();
    }

    closeSearchBedPopup() {
        this.showMedulaBedSearchPopup = false;
        this.TesisYatakSorguCevapDVO = new tesisYatakSorguCevapDVO();
    }

    closeSearchDrugPopup() {
        this.showMedulaDrugSearchPopup = false;
        this.IlacAraCevapDVO = new ilacAraCevapDVO();
    }

    saveUserCustomization(): void {
        let sgcm = [];
        let oneGrid: any = {};
        let transColumnArray = [];
        for (let item of this.visibleTransactionColumnList) {
            transColumnArray.push(item.dataField);
        }
        oneGrid.PageName = "InvoiceSEPForm";
        oneGrid.GridName = "TransactionList";
        oneGrid.ColumnNameList = transColumnArray;
        sgcm.push(oneGrid);


        let apiUrlForUserCustomizationKayit: string = '/api/InvoiceApi/SaveUserBasedGridColumnCustomization';

        this.http.post(apiUrlForUserCustomizationKayit, sgcm).then(response => {
            ServiceLocator.MessageService.showSuccess(i18n("M17905", "Kullanıcı Liste Özelleştirmeleri Kayıt Edildi."));
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    onValueChangedDischargeDate(event: any): void {
        if (event.event != undefined) {
            let model: any = {};

            model.SEPObjectID = this.invoiceSEPFormViewModel.MainSEP;
            model.NewDischargeDate = this.invoiceSEPFormViewModel.InvoiceSEPDetail.DischargeDate;

            let apiUrlForTaniKayit: string = '/api/InvoiceApi/ChangeDischargeDate';

            this.http.post(apiUrlForTaniKayit, model).then(response => {
                ServiceLocator.MessageService.showSuccess("Yatış çıkış tarihi başarı ile değiştirildi.");
            }).catch(error => {
                this.errorHandlerForInvoiceForm(error);
            });
        }
    }

    detailFormSelectboxChanged(e: any, n: any): void {

        if (e.previousValue !== undefined || e.previousValue === null) {

            SubEpisodeProtocolService.UpdateInvoiceSEPDetail(this.invoiceSEPFormViewModel.MainSEP, e.value, n).then
                (result => {
                    if (n == 5) {//Triaj update
                        let loadPartitions: Array<number> = new Array<number>();
                        loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
                        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);	//Transaction

                        this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
                    }
                }).catch(error => {
                    this.errorHandlerForInvoiceForm(error);
                });
        }
    }
    onRtfDescriptionChanged(event: any): void {
        if (event != null) {
            if (this.invoiceSEPFormViewModel != null &&
                this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis != null &&
                this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.Description != event) {

                this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.Description = event;
            }
        }

        //this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.Description = event;

    }
    onClickFirst2000SEPEpicrisis(): void {
        //HTML Tag lerinden kurtulmak için böyle bir yol bulundu.

        let div = document.createElement("div");
        div.innerHTML = this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.Description;
        let text = div.textContent || div.innerText || "";

        if (text.length > 2000) {
            let first2000 = text.substring(0, 2000);
            let leftBehind = text.substring(2000);
            first2000 = "<p><strong>" + first2000 + "</strong></p>";
            let allText = first2000 + leftBehind;
            this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.Description = allText;
        }
        else {
            this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.Description = "<p><strong>" + text + "</strong></p>";
        }

    }

    public EpicrisisDetailListColumns =
        [
            {
                caption: 'Dahil',
                dataField: 'Included',
                width: '3%',
                dataType: 'boolean',
                showEditorAlways: true,
                allowSorting: false
            },
            {
                caption: 'Sıra',
                dataField: 'Order',
                width: '6%',
                allowEditing: false,
                cellTemplate: 'buttonCellTemplate',
                allowSorting: false
            },
            {
                caption: i18n("M23460", "Tip"),
                dataField: 'Type',
                width: '10%',
                allowSorting: false
            },
            {
                caption: i18n("M12524", "Değer"),
                dataField: 'Text',
                width: '81%',
                allowSorting: false
            }
        ];

    onRowUpdatedEpicrisisDetailList(e: any): void {
        if (e.data.Included != undefined || e.data.Text != undefined || e.data.Type != undefined) {
            this.prepareEpicrisisDescription();
        }
    }



    prepareEpicrisisDescription(): void {

        let tempDesc: string = "";
        for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail.length; i++) {
            if (this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i].Included) {
                tempDesc += this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i].Type + " " + this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i].Text + "<br>";
            }
        }

        this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.Description = tempDesc;
    }
    onClickSaveSEPEpicrisis(): void {

        let model: any = {};

        model.SEPObjectID = this.invoiceSEPFormViewModel.MainSEP;
        model.Description = this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.Description;

        let apiUrlForTaniKayit: string = '/api/InvoiceApi/SaveSEPEpicrisis';

        this.http.post(apiUrlForTaniKayit, model).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis);	//Tanılar

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
            ServiceLocator.MessageService.showSuccess(i18n("M19646", "Oluşturulan medula epikriz bilgisi başarı ile kayıt edildi."));
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });

    }

    onClickClearSEPEpicrisis(): void {
        let apiUrlForTaniKayit: string = '/api/InvoiceApi/DeleteSEPEpicrisis?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;

        this.http.get(apiUrlForTaniKayit).then(response => {
            let loadPartitions: Array<number> = new Array<number>();
            loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
            loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPEpicrisis);	//Tanılar

            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
            ServiceLocator.MessageService.showSuccess(i18n("M13885", "Eski veriler başarı ile temizlendi."));
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
        });
    }

    onClickMoveUpDown(value: any, type: any): void {
        //type : 0 up 1 down
        let tempArray = [];
        if (type)//DOWN
        {
            for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail.length; i++) {
                if (this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i].Order == value.data.Order) {

                    if (this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i + 1] != undefined) {
                        tempArray.push(this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i + 1]);
                        tempArray.push(this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i]);
                        i++;
                    }
                    else {
                        tempArray.push(this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i]);
                    }

                }
                else {
                    tempArray.push(this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i]);
                }
            }

        }
        else //UP
        {
            for (let i = 0; i < this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail.length; i++) {
                if (this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i + 1] != undefined && this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i + 1].Order == value.data.Order) {
                    tempArray.push(this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i + 1]);
                    tempArray.push(this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i]);
                    i++;
                }
                else {
                    tempArray.push(this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail[i]);
                }
            }
        }

        this.invoiceSEPFormViewModel.InvoiceSEPEpicrisis.EpicrisisDetail = tempArray;
        this.prepareEpicrisisDescription();
    }

    public changeTrxStateLookUp = [
        {
            "ID": 0,
            'Name': ''
        }
        ,
        {
            'ID': 1,
            'Name': 'Gönderme'
        }
    ];
    public SUTRuleEngineResultColumns = [
        {
            caption: 'Kodu',
            dataField: 'ExternalCode',
            width: 'auto',
            allowEditing: false,
            groupIndex: '1'
        }, {
            caption: 'Adı',
            dataField: 'Description',
            width: 'auto',
            allowEditing: false,
            allowGrouping: false
        }, {
            caption: 'Kural',
            dataField: 'RuleName',
            width: 'auto',
            allowEditing: false,
            groupIndex: '0'
        }, {
            caption: 'Hata Mesajı',
            dataField: 'Message',
            width: 'auto',
            allowEditing: false,
            allowGrouping: false
        }, {
            caption: i18n("M23606", "Tutar"),
            dataField: 'Price',
            width: 'auto',
            allowEditing: false,
            allowGrouping: false
        },
        {
            caption: 'Seçim',
            dataField: 'Choice',
            lookup: { dataSource: this.changeTrxStateLookUp, valueExpr: 'ID', displayExpr: 'Name' },
            //cellTemplate: "choiceCellTemplate",
            allowEditing: true,
            width: 'auto',
            allowGrouping: false
        }
    ];
    public SUTRuleEngineResult: Array<getSutRuleEngineResultCodes_Model> = new Array<getSutRuleEngineResultCodes_Model>();
    public showSUTRuleEngineResultPopup: boolean = false;
    execSutRuleEngine(): void {
        this.loadPanelOperation(true, 'SUT Kuralları çalıştırılıyor, lütfen bekleyiniz');
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/getSutRuleEngineResultCodes?sepObjectID=' + this.invoiceSEPFormViewModel.MainSEP;

        this.http.get<Array<getSutRuleEngineResultCodes_Model>>(apiUrlForgetRule)
            .then(result => {
                this.loadPanelOperation(false, '');
                this.SUTRuleEngineResult = result;
                this.approveChoice = false;
                if (result.length > 0)
                    this.showSUTRuleEngineResultPopup = true;
                else
                    ServiceLocator.MessageService.showSuccess('Kabuller SUT kuralları ile uyumlu.');
            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                ServiceLocator.MessageService.showError(error);
            });
    }

    onRowUpdatingSUTRuleEngineResult(event: any): void {
        if (event.newData.Choice != null && event.newData.Choice != undefined) {
            if (event.key.RuleName == "Yasaklı Hizmet Kuralı" || event.key.RuleName == "Cinsiyet Kuralı"
                || event.key.RuleName == "Yaş Sınırı Kuralı" || event.key.RuleName == "Zorunlu Branş Kuralı") {
                let code = event.key.ExternalCode;
                let ruleName = event.key.RuleName;

                for (let item of this.SUTRuleEngineResult) {
                    if (item.ExternalCode == code && item.RuleName == ruleName) {
                        item.Choice = event.newData.Choice;
                    }
                }
            }
        }
    }

    public approveChoice: boolean;

    onClickSUTRuleEngineResult(): void {
        if (!this.approveChoice) {
            ServiceLocator.MessageService.showError("Lütfen seçimlerinizi onaylayınız.");
            return;
        }
        this.loadPanelOperation(true, 'SUT Kuralları çalıştırılıyor, lütfen bekleyiniz');
        let apiUrlForInvoiceSEPForm: string = '/api/InvoiceTopMenuApi/execSutRuleEngineResultCodes';
        let loadPartitions: Array<number> = new Array<number>();
        loadPartitions.push(LoadInvoiceFormPartitions.MainSEP); 			//Ana id
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPList);		//SEP ler
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPTransactionList);		//Transaction lar
        loadPartitions.push(LoadInvoiceFormPartitions.InvoiceSEPDetail);		//Transaction lar
        this.http.post<boolean>(apiUrlForInvoiceSEPForm, this.SUTRuleEngineResult).then(result => {
            this.loadPanelOperation(false, '');
            this.showSUTRuleEngineResultPopup = false;
            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
            ServiceLocator.MessageService.showSuccess('SUT Kuralları ile ilgili seçiminiz başarı ile uygulandı.');
        }).catch(error => {
            this.errorHandlerForInvoiceForm(error);
            this.LoadFromSEP(this.invoiceSEPFormViewModel.MainSEP, loadPartitions);
        });
    }
    public NotifyInvoiced() {
        let parameters: any = {};
        parameters.invoiceSEPFormViewModel = this.invoiceSEPFormViewModel;
        this.invoiceAllInOneCommService.invoiceSepFormComm.next({ Params: parameters });
    }

    async GenerateTopMenu() {

        let icmalSecItem = '';

        let x = await this.medulaDefinition.GetInvoiceCollection();

        if (x != null)
            icmalSecItem = i18n("M16139", "İcmal Seç <b>[") + x.DisplayText + ']</b>';
        else
            icmalSecItem = 'İcmal Seç';

        this.menuData = [
            {
                id: 'provisionOperations',
                name: i18n("M22633", "Takip"),
                disabled: this.formOpenPayerType == PayerTypeEnum.Paid,
                items: [
                    {
                        id: 'takipAl',
                        name: i18n("M22634", "Takip Al"),
                        disabled: (this.hasProvision || !this.isSGK),
                        fnName: 'takipAlFromTopMenu',
                        items: [
                            {
                                id: 'bagliTakipAlFromTopMenu',
                                disabled: this.hasProvision,
                                name: 'Bağlı Takip Al',
                                fnName: 'bagliTakipAlFromTopMenu',
                                items: [
                                    {
                                        id: 'bagliTakipBilgisiKoparFromTopMenu',
                                        disabled: (this.hasProvision || !this.isSGK),
                                        name: 'Bağlı Takip Bilgisi Kopar',
                                        fnName: 'bagliTakipBilgisiKoparFromTopMenu'
                                    }
                                ]
                            },
                            {
                                id: 'topluTakipAlFromTopMenu',
                                disabled: this.hasProvision,
                                name: 'Takip Al (Başvuru)',
                                fnName: 'topluTakipAlFromTopMenu'
                            }
                        ]
                    },
                    {
                        id: 'takipSil',
                        name: i18n("M22668", "Takip Sil"),
                        disabled: !(this.hasProvision && !this.invoiced),
                        fnName: 'takipSilFromTopMenu',
                        items: [
                            {
                                id: 'topluTakipSilFromTopMenu',
                                name: 'Takip Sil (Başvuru)',
                                disabled: !this.hasProvision,
                                fnName: 'topluTakipSilFromTopMenu'
                            }
                        ]
                    },
                    {
                        id: 'takipOku',
                        name: i18n("M22663", "Takip Oku"),
                        disabled: !this.hasProvision,
                        fnName: 'takipOkuFromTopMenu',
                        items: [
                            {
                                id: 'basvuruBazliTakipOku',
                                name: i18n("M22664", "Takip Oku (Başvuru)"),
                                disabled: !this.hasProvision,
                                fnName: 'basvuruBazliTakipOku'
                            }
                        ]
                    },
                    {
                        id: 'basvuruOku',
                        disabled: !this.hasProvision,
                        name: 'Başvuru Oku',
                        fnName: 'basvuruOku'
                    },
                    {
                        id: 'mustehaklikSorgusuFromTopMenu',
                        name: i18n("M19362", "Müstehaklık Sorgusu"),
                        fnName: 'mustehaklikSorgusuFromTopMenu'
                    },
                    {
                        id: 'sendToENabiz700FromTopMenu',
                        disabled: !this.hasProvision,
                        name: 'Nabız Gönder(700)',
                        fnName: 'sendToENabiz700FromTopMenu'
                    },
                    {
                        id: 'updateSEPDischargeTypeFromTopMenu',
                        disabled: this.invoiced,
                        name: 'Taburcu Kodu Güncelle',
                        fnName: 'updateSEPDischargeTypeFromTopMenu'
                    }

                ]
            },
            {
                id: 'transactionOperations',
                name: i18n("M15818", "Hizmet"),
                disabled: this.invoiced,
                items: [
                    {
                        id: 'takipBazliHizmetKayit',
                        name: 'Hizmet Kayıt',
                        disabled: (!(this.hasProvision && !this.invoiced) || (this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryCompleted || this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.InvoiceEntryWithError)) || !this.isSGK,
                        fnName: 'takipBazliHizmetKayitFromTopMenu',
                        items: [
                            {
                                id: 'basvuruBazliHizmetKayit',
                                name: i18n("M15882", "Hizmet Kayıt (Başvuru)"),
                                disabled: !(this.hasProvision && !this.invoiced),
                                fnName: 'basvuruBazliHizmetKayit'
                            }
                        ]
                    },
                    {
                        id: 'takipBazliHizmetKayitIptal',
                        name: i18n("M15884", "Hizmet Kayıt İptal"),
                        disabled: (!(this.hasProvision && !this.invoiced) || !this.isSGK),
                        fnName: 'takipBazliHizmetKayitIptalFromTopMenu',
                        items: [
                            {
                                id: 'basvuruBazliHizmetKayitIptal',
                                name: i18n("M15885", "Hizmet Kayıt İptal (Başvuru)"),
                                disabled: !(this.hasProvision && !this.invoiced),
                                fnName: 'basvuruBazliHizmetKayitIptal'
                            }
                        ]
                    },
                    {
                        id: 'takipBazliHizmetKayitOku',
                        name: i18n("M15889", "Hizmet Kayıt Oku"),
                        disabled: (!this.hasProvision || !this.isSGK),
                        fnName: 'takipBazliHizmetKayitOku'
                    },

                    {
                        id: 'fixBasedOnTakip',
                        name: i18n("M17995", "Kural Çalıştır"),
                        disabled: this.invoiced,
                        fnName: 'fixBasedOnTakipFromTopMenu',
                        items: [
                            {
                                id: 'fixBasedOnBasvuru',
                                name: 'Kural Çalıştır (Başvuru)',
                                disabled: this.invoiced,
                                fnName: 'fixBasedOnBasvuru'
                            }
                        ]
                    },
                    {
                        id: 'getRule',
                        name: i18n("M23806", "Uygun Kuralı Getir"),
                        fnName: 'getRuleFromTopMenu',
                        items: [
                            {
                                id: 'getLastRule',
                                name: i18n("M22043", "Son Çalışmış Kuralı Getir"),
                                fnName: 'getlastRuleFromTopMenu'
                            }
                        ]
                    },
                    {
                        id: 'addOperation',
                        name: i18n("M15840", "Hizmet Ekle"),
                        fnName: 'addProcedureFromTopMenu',
                    },
                    {
                        id: 'execSutRuleEngine',
                        name: 'SUT Kurallarını Çalıştır',
                        fnName: 'execSutRuleEngine'
                    }
                ]
            },
            {
                id: 'invoiceOperations',
                name: 'Fatura',
                items: [
                    {
                        id: 'faturaKayit',
                        name: 'Fatura Kayıt',
                        disabled: (
                            (
                                !this.hasProvision || (this.hasProvision && this.invoiced)
                                || (this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryNotCompleted
                                    || this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryWithError)
                            ) && this.isSGK
                        )
                            || (
                                (!this.isSGK || this.formOpenPayerType == PayerTypeEnum.Paid)
                                && this.invoiced
                            ),
                        fnName: 'faturaKayitFromTopMenu'
                    },
                    {
                        id: 'faturaKayitSecerek',
                        name: i18n("M21508", "Seçerek Fatura Kayıt"),
                        disabled: (
                            (
                                !this.hasProvision || (this.hasProvision && this.invoiced)
                                || (this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryNotCompleted
                                    || this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryWithError)
                            ) && this.isSGK
                        )
                            || (
                                (!this.isSGK || this.formOpenPayerType == PayerTypeEnum.Paid)
                                && this.invoiced
                            ),
                        fnName: 'faturaKayitSecerekFromTopMenu'
                    },
                    {
                        id: 'faturaIptal',
                        name: 'Fatura İptal',
                        disabled: !this.invoiced,
                        fnName: 'faturaIptal'
                    },
                    {
                        id: 'faturaOku',
                        name: 'Fatura Oku',
                        disabled: !this.invoiced || !this.isSGK,
                        fnName: 'faturaOku'
                    },
                    {
                        id: 'faturaTutarOku',
                        name: i18n("M14215", "Fatura Tutar Oku"),
                        disabled: (!this.hasProvision || (this.hasProvision && this.invoiced) || (this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryNotCompleted || this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryWithError)) || !this.isSGK,
                        fnName: 'faturaTutarOkuFromTopMenu'
                    },
                    {
                        id: 'faturaTutarOkuSecerek',
                        name: i18n("M21509", "Seçerek Fatura Tutar Oku"),
                        disabled: (!this.hasProvision || (this.hasProvision && this.invoiced) || (this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryNotCompleted || this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.ProcedureEntryWithError)) || !this.isSGK,
                        fnName: 'faturaTutarOkuSecerekFromTopMenu'
                    },
                    {
                        id: 'tutarUyustur',
                        name: i18n("M23611", "Tutar Uyuştur"),
                        disabled: !this.invoiced || !this.isSGK,
                        fnName: 'tutarUyustur'
                    },
                    {
                        id: 'faturaDuzeltFromTopMenu',
                        name: i18n("M14132", "Fatura Düzeltme"),
                        disabled: !this.isSGK,
                        fnName: 'faturaDuzeltFromTopMenu'
                    }
                ]
            },
            {
                id: 'InvoiceCollectionOperations',
                name: i18n("M16121", "İcmal"),
                disabled: false, //((this.isSGK) || (this.formOpenPayerType == PayerTypeEnum.Paid)),//SGK veya ücretli faturası ise kapalı gelecek.
                items: [
                    {
                        id: 'icmaleEkle',
                        disabled: (this.invoiced || (this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.InsideInvoiceCollection)),
                        name: i18n("M16152", "İcmale Ekle"),
                        fnName: 'icmaleEkle'
                    },
                    {
                        id: 'icmaldenCikar',
                        disabled: (this.invoiced || !(this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.InsideInvoiceCollection)),
                        name: i18n("M16147", "İcmalden Çıkar"),
                        fnName: 'icmaldenCikar'
                    },
                    {
                        id: 'icmalSec',
                        name: icmalSecItem,
                        fnName: 'icmalSec',
                        items: [
                            {
                                id: 'icmalSecimiTemizle',
                                name: i18n("M21570", "Seçimi Temizle"),
                                fnName: 'icmalSecimiTemizle'
                            }
                        ]
                    },
                    {
                        id: 'icmalSecerekEkle',
                        disabled: (this.invoiced || (this.mainSEPInvoiceStatus === SEPInvoiceStatusDictionary.InsideInvoiceCollection)),
                        name: i18n("M16140", "İcmal Seçerek Ekle"),
                        fnName: 'icmalSecerekEkle'
                    }
                ]
            },
            {
                id: 'OtherMedulaOperation',
                name: i18n("M12830", "Diğer Medula İşlemleri"),
                items: [
                    {
                        id: 'medulaInpatientOperation',
                        name: i18n("M24452", "Yatış-Çıkış İşlemleri"),
                        fnName: 'medulaInpatientOperation'
                    },
                    {
                        id: 'medulaReadExtraProvision',
                        name: i18n("M14279", "Fazla Takipleri Oku"),
                        fnName: 'medulaReadExtraProvision'
                    },
                    {
                        id: 'medulaSearchDoctor',
                        name: 'Doktor Ara',
                        fnName: 'SearchDoctor'
                    },
                    {
                        id: 'medulaSearchDrug',
                        name: 'İlaç Ara',
                        fnName: 'SearchDrug'
                    },
                    {
                        id: 'medulaSearchBeds',
                        name: i18n("M23215", "Tesis Yatak Sorgulama"),
                        fnName: 'SearchBeds'
                    },
                    {
                        id: 'medulaFTRRaporOkuFromTopMenu',
                        name: i18n("M23020", "Tedavi Raporu Oku(FTR)"),
                        fnName: 'medulaFTRRaporOkuFromTopMenu'
                    },
                    {
                        id: 'medulaIlacRaporOkuFromTopMenu',
                        name: "İlaç Raporu Oku",
                        fnName: 'medulaIlacRaporOkuFromTopMenu'
                    },
                    {
                        id: 'medulaUXXXXXXullanimKesinlestirmeFromTopMenu',
                        name: "ÜTS Kullanım Kesinleştirme",
                        fnName: 'medulaUXXXXXXullanimKesinlestirmeFromTopMenu'
                    },
                    {
                        id: 'medulaDokumanIslemleriFromTopMenu',
                        name: "Döküman İşlemleri",
                        fnName: 'medulaDokumanIslemleriFromTopMenu'
                    },
                    {
                        id: 'medulaBarcodeSUTMatchFromTopMenu',
                        name: "Barkod SUT Eşleşme",
                        fnName: 'medulaBarcodeSUTMatchFromTopMenu'
                    },
                    {
                        id: 'medulaENabizBildirimSorguFromTopMenu',
                        name: "E-Nabız Bildirim Sorgula",
                        fnName: 'medulaENabizBildirimSorguFromTopMenu'
                    },
                    {
                        id: 'kisiVefatKayitFromTopMenu',
                        name: "Kişi Vefat Kayıt",
                        fnName: 'kisiVefatKayitFromTopMenu'
                    }
                ]
            }
            ,
            {
                id: 'UserCustomization',
                name: i18n("M12827", "Diğer Kullanıcı İşlemleri"),
                items: [
                    {
                        id: 'saveUserCustomization',
                        name: i18n("M20111", "Özelleştirmeyi Kaydet"),
                        fnName: 'saveUserCustomization'
                    },
                    {
                        id: 'deleteUserCustomization',
                        name: i18n("M24048", "Varsayılan Ayarlar"),
                        fnName: 'deleteUserCustomization'
                    },
                    {
                        id: 'showSEPDescriptions',
                        name: i18n("M14103", "Fatura Açıklamalarını Göster"),
                        fnName: 'showSEPDescriptions'
                    },
                    {
                        id: 'saveSEPDescription',
                        name: i18n("M14108", "Fatura Açıklaması Kaydet"),
                        fnName: 'saveSEPDescription'
                    },
                    {
                        id: 'clearSEPDescription',
                        name: i18n("M14102", "Fatura Açıklamaları Temizle"),
                        fnName: 'clearSEPDescription'
                    },
                    {
                        id: 'addWatchList',
                        name: i18n("M16978", "İzlem Listeme Ekle"),
                        fnName: 'addWatchList'
                    },
                    {
                        id: 'removeWatchList',
                        name: i18n("M16977", "İzlem Listemden Çıkar"),
                        fnName: 'removeWatchList'
                    }

                ]
            }
            ,
            {
                id: 'PayerOperation',
                name: i18n("M18113", "Kurumsal İşlemler"),
                items: [
                    {
                        id: 'changePayer',
                        name: i18n("M18039", "Kurum Değiştir"),
                        fnName: 'changePayer',
                        disabled: this.invoiced,
                    },
                    {
                        id: 'addPayer',
                        name: i18n("M18047", "Kurum Ekle"),
                        disabled: this.invoiced,
                        fnName: 'addPayer'
                    }
                ]
            },
            {
                id: 'PayerOperation',
                name: i18n("M20887", "Raporlar"),
                items: [
                    {
                        id: 'showInvoiceReport',
                        name: i18n("M14189", "Fatura Raporu"),
                        fnName: 'showInvoiceReport',
                        disabled: !this.invoiced
                    },
                    {
                        id: 'showMedulaInvoiceProceduresReport',
                        name: i18n("M14191", "Medula Fatura Hizmet Dökümü"),
                        fnName: 'showMedulaInvoiceProceduresReport',
                        disabled: !this.invoiced || !this.isSGK
                    },
                    {
                        id: 'showEpicrisisReport',
                        name: i18n("M14192", "Epikriz Raporu"),
                        fnName: 'showEpicrisisReport',
                    },
                    {
                        id: 'showLISResult',
                        name: i18n("M14192", "Laboratuvar Sonuçları"),
                        fnName: 'showLISResult',
                    }
                    //{
                    //    id: 'testButton',
                    //    name: 'Test',
                    //    fnName: 'testButton',
                    //    disabled: false
                    //}
                ]
            }
        ];
    }



}