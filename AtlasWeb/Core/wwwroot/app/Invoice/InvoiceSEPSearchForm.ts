//$2389F39E
import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { InvoiceSEPSearchFormModel, InvoiceSEPSearchCriteria } from "./InvoiceSEPSearchFormViewModel";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ITTListDefComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTListDefComboBox';
import { ITTValueListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTValueListBox';
import { ITTEnumComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTEnumComboBox';
import { ITTDateTimePicker } from 'NebulaClient/Visual/ControlInterfaces/ITTDateTimePicker';
import { ITTTextBox } from 'NebulaClient/Visual/ControlInterfaces/ITTTextBox';
import { ITTMaskedTextBox } from 'NebulaClient/Visual/ControlInterfaces/ITTMaskedTextBox';
import { ITTButton } from 'NebulaClient/Visual/ControlInterfaces/ITTButton';
import { ITTCheckBox } from 'NebulaClient/Visual/ControlInterfaces/ITTCheckBox';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';
import { HorizontalAlignment } from 'NebulaClient/Utils/Enums/HorizontalAlignment';
import { InputFormat } from 'NebulaClient/Utils/Enums/InputFormat';
import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { DxAccordionComponent } from "devextreme-angular";
import { ITabPanel } from 'Fw/Components/HvlTabPanel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { InvoiceSEPSearchResultForm } from './InvoiceSEPSearchResultForm';
import { listboxObject } from './InvoiceHelperModel';
import { SUTHizmetEKEnum, MedulaSUTGroupEnum } from '../NebulaClient/Model/AtlasClientModel';
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';

@Component({
    selector: "invoice-sep-search-form",
    templateUrl: './InvoiceSEPSearchForm.html',
})
export class InvoiceSEPSearchForm extends BaseComponent<any> implements AfterViewInit {
    @ViewChild('searchAccordion') accordion: DxAccordionComponent;


    public ResourceDataSource: DataSource;
    public PayerDataSource: DataSource;
    public DoctorDataSource: DataSource;
    public BranchDataSource: DataSource;
    public invoiceSEPSearchFormModel: InvoiceSEPSearchFormModel;

    public searchResultHeight: number;

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    @ViewChild('invoiceSEPSearchResultForm') resultForm: InvoiceSEPSearchResultForm;

    cmbState: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: "VarYokGarantiEnum"
    };
    cmbInPatientStatus: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: "InpatientStatusEnum"
    };
    cmbInvoiceSEPWatchTypeEnum: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: "InvoiceSEPWatchTypeEnum"
    };
    cmbPayerTypeEnum: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        Required: true,
        DataTypeName: "PayerTypeEnum"
    };
    cmbAdmissionStatusEnum: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: "AdmissionStatusEnum"
    };
    cmbMedulaSubepisodeStatusEnum: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: "MedulaSubEpisodeStatusEnum"
    };
    cmbTedaviTuru: ITTListDefComboBox = <ITTListDefComboBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'TedaviTuruListDefinition'
    };
    cmbTerm: ITTListDefComboBox = <ITTListDefComboBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'InvoiceTermList'
    };
    cmbPayerType: ITTValueListBox = <ITTValueListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'PayerTypeListDefinition',
        AutoCompleteDialogWidth: '30%'
    };
 
    cmbBuilding: ITTValueListBox = <ITTValueListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'BuildinglistDefinition',
        AutoCompleteDialogWidth: '30%'
    };
    
    cmbDiagnos: ITTValueListBox = <ITTValueListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'DiagnosisListDefinition',
        AutoCompleteDialogWidth: '30%'
    };
    cmbProcedure: ITTValueListBox = <ITTValueListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'ProcedureListDefinition',
        AutoCompleteDialogWidth: '30%'
    };
    cmbMaterial: ITTValueListBox = <ITTValueListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'MaterialListDefinition',
        AutoCompleteDialogWidth: '30%'
    };
    dtDate: ITTDateTimePicker = <ITTDateTimePicker>{
        Visible: true,
        ReadOnly: false,
        CustomFormat: 'dd/MM/yyyy'
    };
    txtMaskedPrice: ITTMaskedTextBox = <ITTMaskedTextBox>{
        Visible: true,
        ReadOnly: false,
        Mask: "00000000",
        TextAlign: HorizontalAlignment.Left
    };
    txtText: ITTTextBox = <ITTTextBox>{
        Visible: true,
        ReadOnly: false,
        CharacterCasing: CharacterCasing.Lower,
        TextAlign: HorizontalAlignment.Left,
        InputFormat: InputFormat.AlphaOnly
    };
    btnList: ITTButton = <ITTButton>{
        Visible: true,
        ReadOnly: false,
        Text: "Listele"
    };
    chkTedaviTuruSadeceAyaktan: ITTCheckBox = <ITTCheckBox>{
        Checked: false,
        Visible: true
    };
    chkOnlyStatus: ITTCheckBox = <ITTCheckBox>{
        Checked: false,
        Visible: true
    };
    cmbEvetHayirDurumEnum: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: "EvetHayirDurumEnum"
    };
    //cmbSexEnum: ITTEnumComboBox = <ITTEnumComboBox>{
    //    Visible: true,
    //    ReadOnly: false,
    //    DataTypeName: "SexEnum"
    //};
    cmbSex: ITTValueListBox = <ITTValueListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'SKRSCinsiyetList',
        AutoCompleteDialogWidth: '30%'
    };

    public lastXDaysForInvoiceArray = [
        {
            Name: "5",
            ObjectID: 5
        },
        {
            Name: "10",
            ObjectID: 10
        }, {
            Name: "15",
            ObjectID: 15
        },
        {
            Name: "30",
            ObjectID: 30
        },
        {
            Name: "45",
            ObjectID: 45
        },
        {
            Name: "60",
            ObjectID: 60
        }
    ];

    public MedulaSubEpisodeStatusArray = [
        {
            Name: "Takip No Alınmamış",
            ObjectID: 0
        },
        {
            Name: "Hizmet Kaydı Tamamlanmamış",
            ObjectID: 2
        }, {
            Name: "Hizmet Kaydı Hatalı",
            ObjectID: 3
        },
        {
            Name: "Hizmet Kaydı Tamamlanmış",
            ObjectID: 4
        },
        {
            Name: "Fatura Kaydı Hatalı",
            ObjectID: 6
        },
        {
            Name: "Fatura Kaydedildi",
            ObjectID: 7
        },
        {
            Name: "Fatura Tutar Okundu",
            ObjectID: 9
        },
        {
            Name: "Fatura Tutar Okuma Hatalı",
            ObjectID: 10
        },
        {
            Name: "İcmal İçerisinde",
            ObjectID: 11
        },
        {
            Name: "Fatura Tutarı Uyuşmayan",
            ObjectID: 12
        }
    ];

    ResultTabItems: Array<ITabPanel> = [];
    searchResult: string[];
    tabOpenType: string[];
    termDisable: boolean = false;
    searchCount: number = 0;
    invoiced: boolean = false;
    public tedaviTuruArray: Array<any> = [];
    public procedureStateDefArray: Array<any> = [];
    public invoiceControlNQLDefArray: Array<any> = [];
    public SUTAppendixEnumArray: Array<any> = [];
    public PayerArray: Array<any> = [];
    public BranchArray: Array<any> = [];
    public SectionArray: Array<any> = [];
    public DoctorArray: Array<any> = []; 
    public HizmetGrupEnumArray: Array<any> = [];
    public tedaviTipiArray: Array<any> = [];
    public takipTipiArray: Array<any> = [];
    public provizyonTipiArray: Array<any> = [];
    public devredilenKurumArray: Array<any> = [];
    public istisnaiHalArray: Array<any> = [];
    public triajArray: Array<any> = [];
    public invoiceUserArray: Array<any> = [];
    public taburcuTipiArray: Array<any> = [];
    public Nabiz700StatusArray: Array<any> = [{ Id: 0, Name: "Yeni" }, { Id: 1, Name: "Başarılı" }, { Id: 2, Name: "Hatalı" }];
    constructor(protected http: NeHttpService, services: ServiceContainer, private medulaService: GetMedulaDefinitionService) {

        super(services);
        this.invoiceSEPSearchFormModel = new InvoiceSEPSearchFormModel();

        //this.cmbPayerType.Enabled = false;
        //this.cmbPayer.Enabled = false;
        this.cmbTerm.Enabled = false;
        this.invoiced = false;
        this.searchResultHeight = 600;

        this.searchResult = [
            "Takip",
            "Basvuru"
        ];
        this.tabOpenType = [
            i18n("M24515", "Yeni"),
            i18n("M11339", "Aynı")
        ];
        let that = this;
        medulaService.TedaviTuru().then(tt => {
            that.tedaviTuruArray = tt;
            let tempTT: listboxObject = new listboxObject();
            tempTT.Code = "";
            tempTT.Name = "A+G Ayakta+Günübirlik";
            tempTT.ObjectID = Guid.Empty.toString();
            that.tedaviTuruArray.push(tempTT);
        });
        medulaService.TedaviTipi().then(tt => {
            that.tedaviTipiArray = tt;
        });
        medulaService.TakipTipi().then(tt => {
            that.takipTipiArray = tt;
        });
        medulaService.ProvizyonTipi().then(tt => {
            that.provizyonTipiArray = tt;
        });
        medulaService.DevredilenKurum().then(tt => {
            that.devredilenKurumArray = tt;
        });
        medulaService.IstisnaiHal().then(tt => {
            that.istisnaiHalArray = tt;
        });
        medulaService.Triage().then(tt => {
            that.triajArray = tt;
        });
        medulaService.InvoiceUsers().then(tt => {
            that.invoiceUserArray = tt;
        });
        medulaService.procedureStateDef().then(ps => {
            that.procedureStateDefArray = ps;
        });
        medulaService.invoiceControlNQLDef().then(icn => {
            that.invoiceControlNQLDefArray = icn;
        });
        medulaService.TaburcuTipi().then(tt => {
            that.taburcuTipiArray = tt;
        });
        //medulaService.Payer().then(pa => {
        //    that.PayerArray = pa;
        //});
        //medulaService.Brans().then(b => {
        //    that.BranchArray = b;
        //});
        //medulaService.Doctor().then(d => {
        //    that.DoctorArray = d;
        //});
        //medulaService.Section().then(s => {
        //    that.SectionArray = s;
        //});

        this.BranchDataSource = new DataSource({
            store: new CustomStore({
                key: 'ObjectID',
                byKey: (key: any) => {
                    console.log(key);
                    return null;
                },
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'SpecialityListDefinition',
                    };
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 20;
                    }
                    let data = await this.http.post<any>("/api/SMSFormApi/GetListDefinition", loadOptions);
                    let that = this;

                    if (loadOptions.filter != null && loadOptions.filter.length > 0) {

                        that.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.branch = data.map(x => x.ObjectID)
                        //that.viewModel.PersonnelSearcModel.SelectedCitiesObjectIDs = selectedData;
                    }

                    return data;
                }
            }),
            paginate: true,
            pageSize: 20
        });

        this.DoctorDataSource = new DataSource({
            store: new CustomStore({
                key: 'ObjectID',
                byKey: (key: any) => {
                    console.log(key);
                    return null;
                },
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'DoctorListDefinition',
                    };
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 20;
                    }
                    let data = await this.http.post<any>("/api/SMSFormApi/GetListDefinition", loadOptions);
                    let that = this;

                    if (loadOptions.filter != null && loadOptions.filter.length > 0) {

                        that.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.doctor = data.map(x => x.ObjectID)
                        //that.viewModel.PersonnelSearcModel.SelectedCitiesObjectIDs = selectedData;
                    }

                    return data;
                }
            }),
            paginate: true,
            pageSize: 20
        });

        this.PayerDataSource = new DataSource({
            store: new CustomStore({
                key: 'ObjectID',
                byKey: (key: any) => {
                    console.log(key);
                    return null;
                },
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'PayerListDefinition',
                    };
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 20;
                    }
                    let data = await this.http.post<any>("/api/SMSFormApi/GetListDefinition", loadOptions);
                    let that = this;

                    if (loadOptions.filter != null && loadOptions.filter.length > 0) {

                        that.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.payer = data.map(x => x.ObjectID)
                        //that.viewModel.PersonnelSearcModel.SelectedCitiesObjectIDs = selectedData;
                    }

                    return data;
                }
            }),
            paginate: true,
            pageSize: 20
        });


        this.ResourceDataSource = new DataSource({
            store: new CustomStore({
                key: 'ObjectId',
                byKey: (key: any) => {
                    console.log(key);
                    return null;
                },
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'ResourceList',
                        ResourceTypes: [
                            'ResPoliclinic'
                            , 'ResClinic'
                            , 'ResDepartment'
                        ],
                    };
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 20;
                    }
                    let data = await this.http.post<any>("/api/SMSFormApi/GetResources", loadOptions);
                    let that = this;

                    if (loadOptions.filter != null && loadOptions.filter.length > 0) {

                        that.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.section = data.map(x => x.ObjectId)
                        //that.viewModel.PersonnelSearcModel.SelectedCitiesObjectIDs = selectedData;
                    }

                    return data;
                }
            }),
            paginate: true,
            pageSize: 20
        });


        that.SUTAppendixEnumArray = SUTHizmetEKEnum.Items;
        that.HizmetGrupEnumArray = MedulaSUTGroupEnum.Items;
        //console.log("constructor"); 
    }

    ngAfterViewInit(): void {
        //console.log("ngAfterViewInit");
        this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.searchResultType = "Takip";
    }

    async btnSearchClicked(isTextSearch: boolean): Promise<void> {

        if (!isTextSearch)//Eğer arama butondan yapılmış ise
        {
            if (this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType == null || this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.InvoiceSearchType == undefined) {
                ServiceLocator.MessageService.showError(i18n("M18364", "Lütfen arama türü seçiniz."));
                return;
            }
        }
        this.searchCount++;
        if (isTextSearch) {
            if (!this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.patientName && !this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.patientSurname &&
                !this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.patientUniqueRefNo && !this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.episodeProtocolNo &&
                !this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.basvuruNo && !this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.takipNo &&
                !this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.inPatientAdmissionNo && !this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.patientAdmissionNo) {
                ServiceLocator.MessageService.showError(i18n("M15159", "Hasta bilgileri ile arama yapılırken en az bir alan dolu olmalıdır."));
                return;
            }
        }

        this.searchResultHeight = 905;



        let dateTimeNow = new Date();
        let resultTitle = (this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.searchResultType == "Takip" ? "T " : "B ") + this.addZero(dateTimeNow.getHours()) + ':' + this.addZero(dateTimeNow.getMinutes()) + ':' + this.addZero(dateTimeNow.getSeconds());

        let tempObject = new InvoiceSEPSearchCriteria();
        let tempCriteria = Object.assign(tempObject, this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria);

        if (this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.tabOpenType == i18n("M24515", "Yeni")) {
            if (this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.searchResultType == "Takip") {

                this.ResultTabItems.push({
                    ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
                    ComponentPath: 'wwwroot/app/Invoice/InvoiceSEPSearchResultForm',
                    RouteData: tempCriteria,
                    Title: resultTitle,
                    Active: true
                });
            }
            else {

                this.ResultTabItems.push({
                    ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
                    ComponentPath: 'wwwroot/app/Invoice/InvoiceEpisodeSearchResultForm',
                    RouteData: tempCriteria,
                    Title: resultTitle,
                    Active: true
                });
            }
        }
        else {
            let i = 0;
            for (let item of this.ResultTabItems) {
                if (item.Active) {
                    break;
                }
                i++;
            }

            if (this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.searchResultType == "Takip") {

                this.ResultTabItems.splice(i, 1,
                    {
                        ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
                        ComponentPath: 'wwwroot/app/Invoice/InvoiceSEPSearchResultForm',
                        RouteData: tempCriteria,
                        Title: resultTitle,
                        Active: true
                    }
                );
            }
            else {
                this.ResultTabItems.splice(i, 1,
                    {
                        ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
                        ComponentPath: 'wwwroot/app/Invoice/InvoiceEpisodeSearchResultForm',
                        RouteData: tempCriteria,
                        Title: resultTitle,
                        Active: true
                    }
                );
            }
        }
    }

    addZero(i): string {
        if (i < 10) {
            i = "0" + i;
        }
        return i;
    }

    SearchCriteriaStatusEnumChanged(event: any): void {
        if (event.value instanceof Array && event.value.indexOf(7) == -1 && event.value.indexOf(11) == -1 && event.value.indexOf(12) == -1) {
            this.invoiced = false;
            this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.invoiceEndDate = null;
            this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.invoiceStartDate = null;
            this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.firstInvoicePrice = null;
            this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.lastInvoicePrice = null;
            this.cmbTerm.Enabled = false;
            this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.term = null;
        }
        else
            this.invoiced = true;
        this.cmbTerm.Enabled = true;
    }

    PayerTypeEnumValueChanged(event: any): void {
        //if (event == 0) {
        //    this.cmbPayerType.Enabled = false;
        //    this.cmbPayer.Enabled = false;
        //    this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.payer = null;
        //    this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.payerType = null;
        //}
        //else {
        //    this.cmbPayerType.Enabled = true;
        //    this.cmbPayer.Enabled = true;
        //}
        //this.cmbPayer.ListFilterExpression = "TYPE.PAYERTYPE = " + event;

        // if (event == 3)
        //     this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.searchResultType =  "Basvuru";
        // else
        //     this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria.searchResultType =   "Takip";
    }

    ProvizyonTipiComboboxValueChanged(event: any): void {
        //if (event == 0) {
        //    this.cmbPayerType.Enabled = false;
        //    this.cmbPayer.Enabled = false;
        //}
        //else {
        //    this.cmbPayerType.Enabled = true;
        //    this.cmbPayer.Enabled = true;
        //}
    }

    userSearchModelLoaded(event) {
        if (event != null)
            this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria = JSON.parse(event);
        else
            this.invoiceSEPSearchFormModel.InvoiceSEPSearchCriteria = new InvoiceSEPSearchCriteria();
    }

    searchTabHeight;
    onAccordionItemClick(event: any) {
        if (event.element.firstItem().firstChild.firstElementChild.classList.contains("dx-accordion-item-opened")) {
            this.searchTabHeight = 50;
            //this.medulaService.childLoaded.next(true);
        }
        else {
            this.searchTabHeight = 96;
            //this.medulaService.childLoaded.next(false);
        }
    }

    enterSearchKeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            this.btnSearchClicked(true);
            return;
        }
    }

    height: any = 70;
}