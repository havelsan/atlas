//$691A6857
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { InvoiceAccountancyFormViewModel, TermInformationModel, SEPInformationModel, MIFModel, MIFPayer, MIFInfo } from './InvoiceAccountancyFormViewModel';
import { ITTListDefComboBox, ShowBox, ITTEnumComboBox } from 'app/NebulaClient/Visual/TTVisualControlInterfaces';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { listboxObject, MedulaResult } from './InvoiceHelperModel';
import { InvoiceTerm } from 'app/NebulaClient/Model/AtlasClientModel';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { IModalService } from 'app/Fw/Services/IModalService';

@Component({
    selector: "invoice-accountancy-form",
    templateUrl: './InvoiceAccountancyForm.html',
    providers: [SystemApiService]
})

export class InvoiceAccountancyForm implements OnInit {

    public invoiceAccountancyFormViewModel: InvoiceAccountancyFormViewModel;
    public MIFModel: MIFModel;
    public isPrepareNewMIF: boolean;
    public MIFTermArray: listboxObject[];
    public MIFArrayOriginal: MIFInfo[];
    public MIFArray: MIFInfo[];

    public SEPInformationColumns = [
        {
            "caption": "Durum",
            dataField: "Durum",
            width: '25%'
        },
        {
            "caption": "Kabul No",
            dataField: "KabulNo",
            width: '9%'
        },
        {
            "caption": "Takip No",
            dataField: "TakipNo",
            width: '9%'
        },
        {
            "caption": "Grup Türü",
            dataField: "GrupTuru",
            width: '9%'
        },
        {
            "caption": "Grup Adı",
            dataField: "GrupAdi",
            width: '15%'
        },
        {
            "caption": "Medula Tutarı",
            dataField: "MedulaTutar",
            dataType: "number",
            width: '11%'
        },
        {
            "caption": "HBYS T. (Takip)",
            dataField: "HBYSSEPTutar",
            width: '11%'
        },
        {
            "caption": "HBYS T. (Hizmet)",
            dataField: "HBYSAccTrxTutar",
            width: '11%'
        }
    ];

    cmbTerm: ITTListDefComboBox = <ITTListDefComboBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'InvoiceTermList',
        ShowClearButton: true
    };

    cmbMIFType: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        Required: true,
        ShowClearButton: true,
        DataTypeName: "MIFTypeEnum"
    };

    constructor(protected http: NeHttpService, public systemApiService: SystemApiService, protected modalService: IModalService) {
        this.invoiceAccountancyFormViewModel = new InvoiceAccountancyFormViewModel();
        this.MIFModel = new MIFModel();
        this.isPrepareNewMIF = false;
        this.MIFTermArray = new Array<listboxObject>();
        this.MIFArrayOriginal = new Array<MIFInfo>();
        this.MIFArray = new Array<MIFInfo>();
    }

    async ngOnInit(): Promise<void> {
        this.GetMIFInvoiceTerms()
        this.GetMIFs();
    }

    // Medula Tutar Onaylama Metodları
    onCmbTermChanged(e: any) {
        if (e !== null) {
            this.GetTermInfo(e);
        }
        else {
            this.invoiceAccountancyFormViewModel.TermInformation.GSSDocumentNo = null;
            this.invoiceAccountancyFormViewModel.TermInformation.TempProtDocumentNo = null;
            this.invoiceAccountancyFormViewModel.TermInformation.Approved = false;
            this.invoiceAccountancyFormViewModel.TermInformation.ApproveUser = null;
            this.invoiceAccountancyFormViewModel.TermInformation.ApproveDate = null;
            this.invoiceAccountancyFormViewModel.TermInformation.MedulaTotal = 0;
            this.invoiceAccountancyFormViewModel.TermInformation.MedulaBKKTotal = 0;
            this.invoiceAccountancyFormViewModel.TermInformation.MedulaNetTotal = 0;
            this.invoiceAccountancyFormViewModel.TermInformation.MedulaGocIdaresiTotal = 0;
            this.invoiceAccountancyFormViewModel.TermInformation.HBYSSEPTotal = 0;
            this.invoiceAccountancyFormViewModel.TermInformation.HBYSAccTrxTotal = 0;
        }

        this.invoiceAccountancyFormViewModel.SEPInformationList.Clear();
    }

    termApprovedCheckValueChanged(e: any) {

        if (this.invoiceAccountancyFormViewModel.TermInformation.Term == null) {
            ServiceLocator.MessageService.showError("Dönem seçiniz.");
            return;
        }

        if (e.value == true && this.invoiceAccountancyFormViewModel.TermInformation.MedulaTotal == 0) {
            ServiceLocator.MessageService.showError("Dönemi onaylayabilmek için Medula Tutarı sıfırdan büyük olmalıdır.");
            return;
        }

        let apiUrl: string = 'api/InvoiceApi/TermApprovedChange?termObjectID=' + this.invoiceAccountancyFormViewModel.TermInformation.Term + '&approved=' + e.value;

        this.loadPanelOperation(true, "Medula Tutar Onayı değiştiriliyor, lütfen bekleyiniz.");
        let that = this;
        this.http.get<TermInformationModel>(apiUrl).then(result => {
            that.invoiceAccountancyFormViewModel.TermInformation.ApproveUser = result.ApproveUser;
            that.invoiceAccountancyFormViewModel.TermInformation.ApproveDate = result.ApproveDate;
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.errorHandler(error);
        });
    }

    SEPInformationRowClick() {
    }

    async GetTermInfo(e: any): Promise<void> {

        let apiUrl: string = 'api/InvoiceApi/GetTermInfoForAccountancy?termObjectID=' + e;

        this.loadPanelOperation(true, "Dönem bilgileri getiriliyor, lütfen bekleyiniz.");
        let that = this;
        this.http.get<TermInformationModel>(apiUrl).then(result => {
            that.invoiceAccountancyFormViewModel.TermInformation = result;
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.errorHandler(error);
        });
    }


    async ReadTermInvoiceInfoFromMedula(): Promise<void> {

        if (this.invoiceAccountancyFormViewModel.TermInformation.Term == null) {
            ServiceLocator.MessageService.showError("Dönem seçiniz.");
            return;
        }

        if (this.invoiceAccountancyFormViewModel.TermInformation.GSSDocumentNo == null &&
            this.invoiceAccountancyFormViewModel.TermInformation.TempProtDocumentNo == null) {
            ServiceLocator.MessageService.showError("Evrak No giriniz.");
            return;
        }

        ShowBox.Show(1, '&Evet,&Hayır', 'E,H', i18n("M23735", "Onay"), '', i18n("M13584", "Seçilen döneme ait takipler Medula'dan sorgulanacak ve kaydedilecektir. Emin misiniz?"), 1).then(result => {
            if (result === "E") {
                let apiUrl: string = 'api/InvoiceApi/ReadTermInvoiceInfoFromMedula';

                this.loadPanelOperation(true, "Medula'dan takip bilgileri getiriliyor, lütfen bekleyiniz.");
                let that = this;
                this.http.post<Array<MedulaResult>>(apiUrl, that.invoiceAccountancyFormViewModel.TermInformation).then(result => {
                    that.GetTermInfo(this.invoiceAccountancyFormViewModel.TermInformation.Term);
                    this.loadPanelOperation(false, '');

                    let allSuccessful: boolean = true;
                    for (let i = 0; i < result.length; i++) {
                        if (!result[i].Succes) {
                            allSuccessful = false;
                            ServiceLocator.MessageService.showError(result[i].SonucKodu + ' - ' + result[i].SonucMesaji);
                        }
                    }
                    if (allSuccessful)
                        ServiceLocator.MessageService.showSuccess("Medula'dan takip bilgileri getirildi.");

                }).catch(error => {
                    this.errorHandler(error);
                });
            }
        });
    }

    async GetIncompatibleSEPs(): Promise<void> {

        if (this.invoiceAccountancyFormViewModel.TermInformation.Term == null) {
            ServiceLocator.MessageService.showError("Dönem seçiniz.");
            return;
        }

        let apiUrl: string = 'api/InvoiceApi/GetIncompatibleSEPsForAccountancy?termObjectID=' + this.invoiceAccountancyFormViewModel.TermInformation.Term;

        this.loadPanelOperation(true, "Uyumsuz takip bilgileri getiriliyor, lütfen bekleyiniz.");
        let that = this;
        this.http.get<Array<SEPInformationModel>>(apiUrl).then(result => {
            that.invoiceAccountancyFormViewModel.SEPInformationList = result;
            this.loadPanelOperation(false, '');
            ServiceLocator.MessageService.showInfo("Uyumsuz takip bilgileri getirildi.");
        }).catch(error => {
            this.errorHandler(error);
        });
    }

    async ArrangeIncompatibleSEPs(): Promise<void> {

        if (this.invoiceAccountancyFormViewModel.TermInformation.Term == null) {
            ServiceLocator.MessageService.showError("Dönem seçiniz.");
            return;
        }

        if (this.invoiceAccountancyFormViewModel.TermInformation.MedulaTotal == 0) {
            ServiceLocator.MessageService.showError("Uyumsuz Takipleri Düzenleyebilmek için Medula Tutarı sıfırdan büyük olmalıdır.");
            return;
        }

        if (this.invoiceAccountancyFormViewModel.TermInformation.Approved == false) {
            ServiceLocator.MessageService.showError("Uyumsuz Takipleri Düzenleyebilmek için önce Medula Tutarını onaylayınız.");
            return;
        }

        if (this.invoiceAccountancyFormViewModel.SEPInformationList == null || this.invoiceAccountancyFormViewModel.SEPInformationList.length == 0) {
            ServiceLocator.MessageService.showError("Uyumsuz Takipleri Düzenleyebilmek için önce listeleyiniz.");
            return;
        }

        ShowBox.Show(1, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), '', i18n("M13584", "Uyumsuz takipler düzenlenecektir. Emin misiniz?"), 1).then(result => {
            if (result === "E") {
                let apiUrl: string = 'api/InvoiceApi/ArrangeIncompatibleSEPsForAccountancy';

                this.loadPanelOperation(true, "Uyumsuz takipler düzenleniyor, lütfen bekleyiniz.");
                let that = this;
                this.http.post<void>(apiUrl, that.invoiceAccountancyFormViewModel.SEPInformationList).then(() => {
                    that.GetTermInfo(this.invoiceAccountancyFormViewModel.TermInformation.Term);
                    that.GetIncompatibleSEPs();
                    this.loadPanelOperation(false, '');
                    ServiceLocator.MessageService.showSuccess("Uyumsuz takipler düzenlendi.");
                }).catch(error => {
                    this.errorHandler(error);
                });
            }
        });
    }

    // Muhasebe İşlem Fişi Metodları
    public async GetMIFInvoiceTerms() {
        this.MIFTermArray = await this.http.get("api/InvoiceApi/GetInvoiceTerms?stateDefID=" + InvoiceTerm.InvoiceTermStates.Closed);
    }

    public async GetMIFs() {
        this.MIFArrayOriginal = await this.http.get("api/InvoiceApi/GetMIFs");
        this.FilterMIF(this.MIFModel.MIFInfo.TermObjectID, this.MIFModel.MIFInfo.MIFType);
    }

    MIFTermChanged(e: any) {
        this.FilterMIF(e.value, this.MIFModel.MIFInfo.MIFType);
    }

    MIFTypeChanged(e: any) {
        this.FilterMIF(this.MIFModel.MIFInfo.TermObjectID, e);
    }

    FilterMIF(term: any, type: any) {
        this.MIFArray = this.MIFArrayOriginal;

        if (term != null && term != undefined) {
            this.MIFArray = this.MIFArray.filter(x => x.TermObjectID == term);
        }

        if (type != null && type != undefined) {
            this.MIFArray = this.MIFArray.filter(x => x.MIFType == type);
        }

        // Seçili MIF, filtrelenmiş MIF lerin içerisinde yoksa MIFPayers boşaltılır
        if (this.MIFModel.MIFInfo.MIFObjectID != null && this.MIFModel.MIFInfo.MIFObjectID != undefined) {
            if (this.MIFArray.filter(x => x.MIFObjectID == this.MIFModel.MIFInfo.MIFObjectID).length == 0) {
                this.MIFModel.MIFPayers.Clear();
            }
        }
    }

    MIFChanged(e: any) {
        if (e.value !== null) {
            this.GetMIFInfo(e.value);
        }
        else {
            //this.MIFModel.MIFInfo.CreateUser = null;
            //this.MIFModel.MIFInfo.CreateDate = null;
            this.MIFModel.MIFPayers.Clear();
        }
        this.isPrepareNewMIF = false;
    }

    async GetMIFInfo(e: any): Promise<void> {

        let apiUrl: string = 'api/InvoiceApi/GetMIFInfo?mifObjectID=' + e;

        this.loadPanelOperation(true, "Muhasebe İşlem Fişi bilgileri getiriliyor, lütfen bekleyiniz.");
        let that = this;
        this.http.get<Array<MIFPayer>>(apiUrl).then(result => {
            that.MIFModel.MIFPayers = result;
            this.loadPanelOperation(false, '');
        }).catch(error => {
            this.errorHandler(error);
        });
    }

    async PrepareNewMIF(): Promise<void> {
        if (this.MIFModel.MIFInfo.TermObjectID == null) {
            ServiceLocator.MessageService.showError("Dönem seçiniz.");
            return;
        }
        if (this.MIFModel.MIFInfo.MIFType == null) {
            ServiceLocator.MessageService.showError("MİF Türünü seçiniz.");
            return;
        }

        let apiUrl: string = 'api/InvoiceApi/PrepareNewMIF';

        this.loadPanelOperation(true, "Muhasebe İşlem Fişi hazırlanıyor, lütfen bekleyiniz.");
        let that = this;
        that.MIFModel.MIFInfo.MIFObjectID = null;
        this.http.post<Array<MIFPayer>>(apiUrl, that.MIFModel.MIFInfo).then(result => {
            that.MIFModel.MIFPayers = result;
            this.isPrepareNewMIF = true;
            this.loadPanelOperation(false, '');
            ServiceLocator.MessageService.showInfo("Muhasebe İşlem Fişi hazırlandı.");
        }).catch(error => {
            this.errorHandler(error);
        });
    }

    async SaveNewMIF(): Promise<void> {
        if (this.MIFModel.MIFInfo.TermObjectID == null) {
            ServiceLocator.MessageService.showError("Dönem seçiniz.");
            return;
        }
        if (this.MIFModel.MIFInfo.MIFType == null) {
            ServiceLocator.MessageService.showError("MİF Türünü seçiniz.");
            return;
        }
        if (this.MIFModel.MIFPayers == null || this.MIFModel.MIFPayers.length == 0) {
            ServiceLocator.MessageService.showError("Kaydedilecek MİF detayı bulunamadı, önce hazırlayınız.");
            return;
        }
        ShowBox.Show(1, '&Evet,&Hayır', 'E,H', i18n("M23735", "Onay"), '', i18n("M13584", "Muhasebe İşlem Fişini kaydetmek istiyor musunuz ?"), 1).then(result => {
            if (result === "E") {
                let apiUrl: string = 'api/InvoiceApi/SaveNewMIF';

                this.loadPanelOperation(true, "Muhasebe İşlem Fişi kaydediliyor, lütfen bekleyiniz.");
                let that = this;
                this.http.post<MIFInfo>(apiUrl, that.MIFModel).then(result => {
                    that.MIFModel.MIFInfo = result;
                    this.GetMIFs();
                    this.isPrepareNewMIF = false;
                    this.loadPanelOperation(false, '');
                    ServiceLocator.MessageService.showSuccess("Muhasebe İşlem Fişi kaydedildi.");
                }).catch(error => {
                    this.errorHandler(error);
                });
            }
        });
    }

    async PrintMIFReport(): Promise<void> {
        this.PrintReport(false);
    }

    async PrintMIFReportByPayer(): Promise<void> {
        this.PrintReport(true);
    }

    PrintReport(byPayer: boolean) {

        if (this.MIFModel.MIFInfo.MIFObjectID == null) {
            ServiceLocator.MessageService.showError("Muhasebe İşlem Fişi seçiniz.");
            return;
        }

        let that = this;

        let data: DynamicReportParameters = {
            Code: 'MIFReport',
            ReportParams: { MIFObjectID: that.MIFModel.MIFInfo.MIFObjectID, byPayer: byPayer },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Muhasebe İşlem Fişi"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    changeClasses(): boolean {
        if (parseInt($('div.container-fluid').css('width')) < 1000)
            return true;
        else
            return false;
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    errorHandler(message: string): void {
        this.loadPanelOperation(false, '');
        ServiceLocator.MessageService.showError(message);
        console.log(message);
    }

}