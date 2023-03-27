//$8E6B2DC5
import { Component, OnInit, ViewChild, Input, OnDestroy } from '@angular/core';
import { CashOfficePatientFormViewModel } from './CashOfficePatientFormViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ITTTextBox } from 'NebulaClient/Visual/ControlInterfaces/ITTTextBox';
import { ITTButton } from 'NebulaClient/Visual/ControlInterfaces/ITTButton';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ITTEnumComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTEnumComboBox';
import { TTEnumComboBox } from 'NebulaClient/Visual/Controls/TTEnumComboBox';
import { ITTDateTimePicker } from 'NebulaClient/Visual/ControlInterfaces/ITTDateTimePicker';
import { ITTListDefComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTListDefComboBox';
import { PatientDebtTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ITTValueListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTValueListBox';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { CashOfficePatientResultModel } from './CashOfficePatientFormViewModel';
import { CashOfficePatientDetailModel } from './CashOfficePatientFormViewModel';
import { PatientOldDebtFormModel } from './CashOfficePatientFormViewModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { CashOfficeWorkListResultModel } from '../CashOfficeWorkList/CashOfficeWorkListFormViewModel';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { AtlasReportService } from '../Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { DxDataGridComponent } from 'devextreme-angular';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { CashOfficeFormsService } from 'app/CashOfficeForms/CashOfficeFormsService';

@Component({
    selector: 'cashOffice-patient-form',
    templateUrl: './CashOfficePatientForm.html',
    providers: [SystemApiService, AtlasReportService]
})

export class CashOfficePatientForm extends BaseComponent<CashOfficePatientResultModel> implements OnInit, OnDestroy {
    public cashOfficePatientFormViewModel: CashOfficePatientFormViewModel;
    public selectedEpisodeObjectID?: Guid;
    public ReceiptButtonVisible: boolean = true;
    public ReceiptBackButtonVisible: boolean = true;
    public AdvanceButtonVisible: boolean = true;
    public AdvanceBackButtonVisible: boolean = true;
    public BondButtonVisible: boolean = true;
    public BondPaymentButtonVisible: boolean = true;
    public showPatientOldDebt: boolean = false;

    public oncbxPaymentTypeChanged(event): void {
        if (event != null) {
            if (this.cashOfficePatientFormViewModel.PatientOldDebtFormModel != null) {
                this.cashOfficePatientFormViewModel.PatientOldDebtFormModel.PaymentType = event;
            }
        }
    }

    public get SelectedEpisodeID(): Guid {
        return this.selectedEpisodeObjectID;
    }
    public set SelectedEpisodeID(val: Guid) {
        if (val != null) {
            this.selectedEpisodeObjectID = val;
        }
    }

    // public _CurrencyTypes: Array<any>;
    // @Input() set CurrencyTypes(val: Array<any>) {
    //     this._CurrencyTypes = val;
    // }
    // get CurrencyTypes(): Array<any> {
    //     return this._CurrencyTypes;
    // }
    //private selectedPatientID: Guid;
    //Hasta arama kriterleri kontroller
    // txtEpisodeNo: ITTTextBox = <ITTTextBox>{
    //     TextAlign: HorizontalAlignment.Left,
    //     InputFormat: InputFormat.AlphaOnly
    // };

    // txtTcNO: ITTTextBox = <ITTTextBox>{
    //     TextAlign: HorizontalAlignment.Left,
    //     InputFormat: InputFormat.AlphaOnly
    // };

    // txtFirstName: ITTTextBox = <ITTTextBox>{
    //     TextAlign: HorizontalAlignment.Left,
    //     InputFormat: InputFormat.AlphaOnly
    // };

    // txtLastName: ITTTextBox = <ITTTextBox>{
    //     TextAlign: HorizontalAlignment.Left,
    //     InputFormat: InputFormat.AlphaOnly
    // };
    ResultGridHeight: number;
    ResultGridHeightStr: any;
    dpApplicationStartDate: ITTDateTimePicker = <ITTDateTimePicker>{
        Format: DateTimePickerFormat.Custom,
        CustomFormat: 'dd/MM/yyyy'
    };

    dpApplicationEndDate: ITTDateTimePicker = <ITTDateTimePicker>{
        Format: DateTimePickerFormat.Custom,
        CustomFormat: 'dd/MM/yyyy'
    };

    lstDefCmbPayer: ITTValueListBox = <ITTValueListBox>{
        ListDefName: 'PayerListDefinition'
    };

    cmbDebtType: ITTEnumComboBox = <ITTEnumComboBox>{
        DataTypeName: 'PatientDebtTypeEnum',
        ShowClearButton: false
    };

    lstDefCmbBuilding: ITTListDefComboBox = <ITTListDefComboBox>{
        ListDefName: 'BuildinglistDefinition'
    };

    btnSearchPatient: ITTButton = <ITTButton>{
        Text: 'Listele',
    };
    //

    //Hasta detay kontrolleri
    txtInfo: ITTTextBox = <ITTTextBox>{
        Font: { Bold: true },
        ReadOnly: true
    };

    //txtInfoFullName: ITTTextBox = <ITTTextBox>{
    //    ReadOnly: true,
    //    InputFormat: InputFormat.AlphaOnly
    //};
    //txtInfoTCNo: ITTTextBox = <ITTTextBox>{
    //    ReadOnly: true,
    //    InputFormat: InputFormat.AlphaOnly
    //};

    //
    public CashOfficeWorkListDataGridColumns =
        [
            {
                caption: 'Tarih',
                dataField: 'Date',
                dataType: 'date',
                format: 'dd/MM/yyyy'
            },
            {
                caption: i18n("M16893", "İşlem Tipi"),
                dataField: 'OperationType'
            },
            {
                caption: 'Durum',
                dataField: 'State'
            },
            {
                caption: i18n("M11745", "Belge No"),
                dataField: 'ReceiptNo'
            },
            {
                caption: i18n("M16866", "İşlem No"),
                dataField: 'Id'
            },
            {
                caption: i18n("M23606", "Tutar"),
                dataField: 'PaymentPrice'
            }
        ];

    public CashOfficePatientDataGridColumns =
        [
            {
                caption: i18n("M22936", "TC Kimlik No"),
                dataField: 'TCNo',
            },
            {
                caption: i18n("M10517", "Adı Soyadı"),
                dataField: 'FullName',
                width: 150,
            },
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: 'EpisodeID',
            },
            {
                caption: 'Kabul Tarihi',
                dataField: 'Date',
                dataType: 'date',
                format: 'dd/MM/yyyy'
            },
            {
                caption: i18n("M23606", "Tutar"),
                dataField: 'TotalDebt',
            }
        ];
    dynamicComponentActionExecuted(e: any) {
        if (e.Cancelled === undefined)
            this.btnSearchPatientClick(true);
        else
            this.systemApiService.componentInfo = null;
    }

    dynamicComponentLoadErrorOccurred(e: any) {
        if (!e.split('-')[0].Contains('SM0177'))
            this.systemApiService.componentInfo = null;
        if (!e.split('-')[0].Contains('SM2829'))
            this.systemApiService.componentInfo = null;
    }

    //State geçişlerindeki hatalar buraya düşer
    dynamicComponentActionFailed(e: any) {
        //this.systemApiService.componentInfo = null;
    }

    constructor(private cashOfficeFormsService: CashOfficeFormsService, container: ServiceContainer, protected http: NeHttpService, public systemApiService: SystemApiService, private reportService: AtlasReportService,
        protected modalService: IModalService) {
        super(container);
        this.cashOfficePatientFormViewModel = new CashOfficePatientFormViewModel();
        this.cashOfficePatientFormViewModel.CashOfficePatientSearchModel.SelectedDebtType = PatientDebtTypeEnum.InDebt;
        this.initFormControls();
        // let pageSidebarWrapperHeight: number = parseInt($('.page-sidebar-wrapper').css('height'));
        // let ageSidebarWrapperMarginTopPlusBottom : number = parseInt($('.page-sidebar-wrapper').css('marginTop'))
        // + parseInt($('.page-sidebar-wrapper').css('marginBottom'))
        // let totalSideBarWrapperHeight = pageSidebarWrapperHeight+ageSidebarWrapperMarginTopPlusBottom;

        // $('html').css("height","calc(100% - "+totalSideBarWrapperHeight+"px)")
        // $('body').css({"height":"100%"});
        // $('div.page-content > div.container-fluid').css({"height": "100%"})
        // $('div.page-content > div.container-fluid').removeClass('container-fluid');
    }

    clientPreScript() {
        //$('#CashOfficePatientForm').closest('div.container-fluid').css({'height':'100%','display':'block'});

        // $(window).resize(x => {
        //     this.ResultGridHeight = parseInt($('#cash-office-patient-grid-container').css('height'));

        //     this.ResultGridHeightStr = { 'height': this.ResultGridHeight + "px" };
        // });
        // $(window).ready(x => {
        //     this.ResultGridHeight = parseInt($('#cash-office-patient-grid-container').css('height'));
        //     this.ResultGridHeightStr = { 'height': this.ResultGridHeight + "px" };
        // });
    }

    clientPostScript(state: String) {

    }

    ngOnInit(): void {
        this.prepareNewCashOfficePatientForm();
        this.cashOfficeFormsService.ngOnInit();
    }

    ngOnDestroy(): void {
        this.cashOfficeFormsService.ngOnDestroy();
    }

    prepareNewCashOfficePatientForm() {
        let url = 'api/CashOfficePatientApi/PrepareNewCashOfficePatientForm';
        this.http.get<CashOfficePatientFormViewModel>(url).then(response => {
            let result: CashOfficePatientFormViewModel = <CashOfficePatientFormViewModel>response;
            let roles = result.Roles;
            this.ReceiptButtonVisible = roles.Receipt;
            this.AdvanceButtonVisible = roles.Advance;
            this.ReceiptBackButtonVisible = roles.ReceiptBack;
            this.AdvanceBackButtonVisible = roles.AdvanceBack;
            this.BondButtonVisible = roles.Bond;
            this.BondPaymentButtonVisible = roles.BondPayment;
        });
    }



    btnSearchPatientClick(triggered: boolean): void {

        if (triggered === false) {
            this.selectedEpisodeObjectID = null;
        }

        //let searchModel = JSON.stringify(this.cashOfficePatientFormViewModel.CashOfficePatientSearchModel);

        let url = 'api/CashOfficePatientApi/GetCashOfficePatientResult';

        this.http.post<Array<CashOfficePatientResultModel>>(url, this.cashOfficePatientFormViewModel.CashOfficePatientSearchModel).then(result => {
            this.cashOfficePatientFormViewModel.CashOfficeWorkListResultModel = new Array<CashOfficeWorkListResultModel>();
            if (result !== null) {
                this.cashOfficePatientFormViewModel.CashOfficePatientResultModel = result;
            } else {
                this.cashOfficePatientFormViewModel.CashOfficePatientResultModel = new Array<CashOfficePatientResultModel>();
                this.selectedEpisodeObjectID = null;
                ServiceLocator.MessageService.showInfo('Aranan kriterlere göre bir kayıt bulunamadı.');
            }
            this.cashOfficePatientFormViewModel.CashOfficePatientDetailModel = new CashOfficePatientDetailModel();
            this.systemApiService.componentInfo = null;
            if (this.selectedEpisodeObjectID !== undefined || this.selectedEpisodeObjectID !== null) {
                this.grdEpisodeSelectionChanged(null);
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
        });
    }
    public grdEpisodeSelectedRow: number;

    grdEpisodeSelectionChanged(event: any): void {
        if (event != null) {
            this.selectedEpisodeObjectID = event.data.ObjectID;
            this.grdEpisodeSelectedRow = event.dataIndex;
        }

        //this.selectedPatientID = event.data.PatientObjectID;
        if (this.selectedEpisodeObjectID !== undefined && this.selectedEpisodeObjectID !== null && this.selectedEpisodeObjectID != Guid.Empty) {
            let url = 'api/CashOfficeWorkListApi/GetCashOfficeWorkListForPatient?episodeObjectId=' + this.selectedEpisodeObjectID + '';
            this.http.get<CashOfficePatientFormViewModel>(url).then(response => {
                let result = <CashOfficePatientFormViewModel>response;
                this.systemApiService.componentInfo = null;
                this.cashOfficePatientFormViewModel.CashOfficeWorkListResultModel = result.CashOfficeWorkListResultModel;
                this.cashOfficePatientFormViewModel.CashOfficePatientDetailModel = result.CashOfficePatientDetailModel;
                if (Math.Round(Number(this.cashOfficePatientFormViewModel.CashOfficePatientDetailModel.RemainingDebt), 2) > 0) {
                    if (this.ReceiptButtonVisible)
                        this.btnNewReceiptClick();
                    else if (this.BondButtonVisible)
                        this.btnBondClick();
                }
            });
        }
    }

    public grdCashOfficeWorkListClick(event: any): void {
        let component = event.component, prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime) < 250) {
            let input: DynamicComponentInputParam = new DynamicComponentInputParam();
            input.activeIDsModel = new ActiveIDsModel(null, this.selectedEpisodeObjectID, null);
            input.data = this.cashOfficeFormsService;
            this.systemApiService.open(event.data.ObjectID, event.data.ObjectDefName, null, input);
        }
    }

    btnNewReceiptClick(): void {
        this.OpenForm('Receipt');
    }
    btnNewAdvanceClick(): void {
        this.OpenForm('Advance');
    }
    btnAdvanceBackClick(): void {
        this.OpenForm('AdvanceBack');
    }
    btnReceiptBackClick(): void {
        this.OpenForm('ReceiptBack');
    }

    btnBondClick(): void {
        this.OpenForm('Bond');
    }

    btnBondPaymentClick(): void {
        this.OpenForm('BondPayment');
    }

    private OpenForm(objectDefName: string) {
        if (this.selectedEpisodeObjectID !== undefined && this.selectedEpisodeObjectID !== null) {
            let input: DynamicComponentInputParam = new DynamicComponentInputParam();
            input.activeIDsModel = new ActiveIDsModel(null, this.selectedEpisodeObjectID, null);
            input.data = this.cashOfficeFormsService;
            this.systemApiService.new(objectDefName, null, null, input);
        } else {
            ServiceLocator.MessageService.showError(i18n("M18391", "Lütfen protokol seçiniz!"));
            return;
        }
    }

    public dateBoxKeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            this.btnSearchPatientClick(false);
            return;
        }
    }

    public enterSearchKeypress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            this.btnSearchPatientClick(false);
            return;
        }
    }

    //Hasta eski borç ödeme (PatientOldDebt)
    cbxPaymentType: ITTEnumComboBox;
    onGrdCashOfficePatientContextPreparing(event: any) {
        let that = this;
        if (event.row !== undefined && event.row !== null) {
            if (event.row.rowType === 'data') {
                event.items = [
                    {
                        text: i18n("M13856", "Eski Borç Öde"),
                        onItemClick: function () {
                            //Birinci ihbarname
                            that.prepareNewPatientOldDebtForm(event.row.data.PatientObjectID);
                        }
                    },
                    {
                        text: i18n("M13855", "Eski Borcu Sil"),
                        onItemClick: function () {
                            //Birinci ihbarname
                            that.removeOldDebt(event.row.data);
                        }
                    }
                ];
            }
        }
    }

    prepareNewPatientOldDebtForm(patientObjectID: Guid) {
        let url = 'api/CashOfficePatientApi/PrepareNewPatientOldDebtForm?patientObjectID=' + patientObjectID;
        this.http.get<PatientOldDebtFormModel>(url).then(result => {
            this.showPatientOldDebt = true;
            this.cashOfficePatientFormViewModel.PatientOldDebtFormModel = result;
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
        });
    }

    async removeOldDebt(oldDebtPatient: any) {
        let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', oldDebtPatient.FullName + i18n("M16579", " isimli hastanın borcu silinecektir. Devam etmek istiyor musunuz?"));
        if (result === "OK") {
            let url = 'api/CashOfficePatientApi/RemoveOldDebt?uniqueRefNo=' + oldDebtPatient.TCNo;

            this.http.get<void>(url).then(x => {
                ServiceLocator.MessageService.showSuccess(i18n("M15446", "Hastanın eski borcu başarılı bir şekilde silinmiştir."));
                this.btnSearchPatientClick(false);
            }).catch(error => {
                ServiceLocator.MessageService.showError(error);
            });
        }
    }

    payOldPatientDebt() {
        let url = 'api/CashOfficePatientApi/PayPatientOldDebt';
        this.http.post<boolean>(url, this.cashOfficePatientFormViewModel.PatientOldDebtFormModel).then(result => {
            if (result) {
                this.btnSearchPatientClick(true);
                let data: DynamicReportParameters = {
                    Code: 'OldDebtReceiptDetailedReport',
                    ReportParams: { PATIENTOBJECTID: this.cashOfficePatientFormViewModel.PatientOldDebtFormModel.PatientObjectID },
                    ViewerMode: true
                };

                return new Promise((resolve, reject) => {

                    let componentInfo = new DynamicComponentInfo();
                    componentInfo.ComponentName = 'HvlDynamicReportComponent';
                    componentInfo.ModuleName = 'DevexpressReportingModule';
                    componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
                    componentInfo.InputParam = new DynamicComponentInputParam(data, null);

                    let modalInfo: ModalInfo = new ModalInfo();
                    modalInfo.Title = "Vezne Eski Borç Makbuzu"

                    modalInfo.fullScreen = true;

                    let result = this.modalService.create(componentInfo, modalInfo);
                    result.then(inner => {
                        resolve(inner);
                    }).catch(err => {
                        reject(err);
                    });
                });
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
        });
    }

    totalPaymentKeyPress(event: KeyboardEvent) {
        if (event.charCode === 44)
            event.preventDefault();
        if (isNaN(parseInt(event.key)) && event.charCode !== 46)
            event.preventDefault();
    }

    initFormControls() {
        this.cbxPaymentType = new TTEnumComboBox();
        this.cbxPaymentType.DataTypeName = "PaymentTypeEnum";
        this.cbxPaymentType.Required = true;
        this.cbxPaymentType.BackColor = "#FFE3C6";
        this.cbxPaymentType.Name = "cbxPaymentType";
        this.cbxPaymentType.IncludeOnly = [0, 1];
        this.cbxPaymentType.TabIndex = 37;
    }
    //Hasta eski borç ödeme (PatientOldDebt)
}
