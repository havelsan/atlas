//$94DD3DF2
import { Component, OnInit, NgZone, ViewChild } from '@angular/core';
import { RegularObstetricNewFormViewModel, BabyInfo } from './RegularObstetricNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode, EpisodeAction, InPatientPhysicianApplication, PregnantInformation, IndicationReason, ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { RegularObstetric } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Pregnancy } from 'NebulaClient/Model/AtlasClientModel';
import { RegularObstetricPersonel } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumunGerceklestigiYer } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGebelikAraligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGebelikSonucu } from 'NebulaClient/Model/AtlasClientModel';
import { SubActionProcedure, BabyObstetricInformation, BirthReportBabyStatus } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';


import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { BabyInformationFormViewModel } from './BabyInformationFormViewModel';
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ComposeComponent } from '../../../wwwroot/app/Fw/Components/ComposeComponent';
import { DynamicComponentInfo } from '../../../wwwroot/app/Fw/Models/DynamicComponentInfo';
import { BabyMotherMatchBarcodeInfo } from 'app/Barcode/Models/InpatientWristBarcodeInfo';

@Component({
    selector: 'RegularObstetricNewForm',
    templateUrl: './RegularObstetricNewForm.html',
    providers: [MessageService, SystemApiService]
})
export class RegularObstetricNewForm extends EpisodeActionForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    ApprovalFormGiven: TTVisual.ITTCheckBox;
    AyniFarkliKesi: TTVisual.ITTListDefComboBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    BirthLocationPregnancy: TTVisual.ITTObjectListBox;
    BirthResult: TTVisual.ITTObjectListBox;
    BirthTerminationDatePregnancy: TTVisual.ITTDateTimePicker;
    CokluOzelDurum: TTVisual.ITTButtonColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    EstimatedBirthDatePregnancy: TTVisual.ITTDateTimePicker;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridManipulations: TTVisual.ITTGrid;
    GridPersonnel: TTVisual.ITTGrid;
    GridTreatmentMaterials: TTVisual.ITTGrid;
    Kdv: TTVisual.ITTTextBoxColumn;
    KodsuzMalzemeFiyati: TTVisual.ITTTextBoxColumn;
    labelBirthLocationPregnancy: TTVisual.ITTLabel;
    labelBirthResult: TTVisual.ITTLabel;
    labelBirthTerminationDatePregnancy: TTVisual.ITTLabel;
    labelEstimatedBirthDatePregnancy: TTVisual.ITTLabel;
    labelLastMenstrualPeriodPregnancy: TTVisual.ITTLabel;
    labelMotherAge: TTVisual.ITTLabel;
    labelPregnancyRange: TTVisual.ITTLabel;
    labelPregnancyRiskInfo: TTVisual.ITTLabel;
    labelProcessTime: TTVisual.ITTLabel;
    labelWhichPregnancy: TTVisual.ITTLabel;
    LastMenstrualPeriodPregnancy: TTVisual.ITTDateTimePicker;
    MalzemeBrans: TTVisual.ITTTextBoxColumn;
    MalzemeSatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    MalzemeTuru: TTVisual.ITTListDefComboBoxColumn;
    ManipulationTab: TTVisual.ITTTabPage;
    Material: TTVisual.ITTListBoxColumn;
    MaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    MotherAge: TTVisual.ITTTextBox;
    Notes: TTVisual.ITTTextBoxColumn;
    OzelDurum: TTVisual.ITTListDefComboBoxColumn;
    Personnel: TTVisual.ITTListBoxColumn;
    PersonnelWork: TTVisual.TTTextBoxColumn;
    PersonnelTab: TTVisual.ITTTabPage;
    PregnancyRange: TTVisual.ITTObjectListBox;
    PregnancyRiskInfo: TTVisual.ITTTextBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    RaporTakipNo: TTVisual.ITTTextBoxColumn;
    RegularObstetricActionDate: TTVisual.ITTDateTimePickerColumn;
    RegularObstetricDoctor: TTVisual.ITTListBoxColumn;
    StockOutAmount: TTVisual.ITTTextBoxColumn;
    TabSubaction: TTVisual.ITTTabControl;
    TreatmentMaterial: TTVisual.ITTTabPage;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttrichtextboxcontrol1: TTVisual.ITTRichTextBoxControl;
    UBBCODE: TTVisual.ITTTextBoxColumn;
    UnitType: TTVisual.ITTTextBoxColumn;
    UseAmount: TTVisual.ITTTextBoxColumn;
    WhichPregnancy: TTVisual.ITTTextBox;
    IndicationsIndicationReason: TTVisual.ITTListBoxColumn;
    IndicationReasons: TTVisual.ITTGrid;
    MasterResource: TTVisual.ITTObjectListBox;

    public IndicationReasonsColumns = [];
    public GridEpisodeDiagnosisColumns = [];
    public GridManipulationsColumns = [];
    public GridPersonnelColumns = [];
    public GridTreatmentMaterialsColumns = [];
    public regularObstetricNewFormViewModel: RegularObstetricNewFormViewModel = new RegularObstetricNewFormViewModel();
    public get _RegularObstetric(): RegularObstetric {
        return this._TTObject as RegularObstetric;
    }
    private RegularObstetricNewForm_DocumentUrl: string = '/api/RegularObstetricService/RegularObstetricNewForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone, protected systemApiService: SystemApiService, protected objectContextService: ObjectContextService, private barcodePrintService: IBarcodePrintService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.RegularObstetricNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    isDiagnose: boolean = true;
    isHizmetTetkik: boolean = false;
    isMlzSarf: boolean = false;
    isPersonel: boolean = false;

    private _InpatientEpisodeAction: InPatientPhysicianApplication = new InPatientPhysicianApplication();
    selectTab(e) {
        let selectedItem: string = e.addedItems[0].title;
        if (selectedItem == "Tanılar") {
            this.isDiagnose = true;
        }
        if (selectedItem == i18n("M15930", "Hizmet ve Tetkik")) {
            if (typeof this.regularObstetricNewFormViewModel._RegularObstetric.MasterAction === "string") {

                let fullApiUrl: string = 'api/RegularObstetricService/getEpisodeActionById?objectId=' + this.regularObstetricNewFormViewModel._RegularObstetric.MasterAction;
                this.httpService.get<InPatientPhysicianApplication>(fullApiUrl).then((response) => {
                    this._InpatientEpisodeAction = response as InPatientPhysicianApplication;
                    this.isHizmetTetkik = true;
                }).catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });

                //this.getEpisodeActionById(this.regularObstetricNewFormViewModel._RegularObstetric.MasterAction).then((ea: EpisodeAction) => {
                //    this._InpatientEpisodeAction = ea;
                //    this.isHizmetTetkik = true;
                //});
            } else {
                this._InpatientEpisodeAction = this.regularObstetricNewFormViewModel._RegularObstetric.MasterAction as InPatientPhysicianApplication;
                this.isHizmetTetkik = true;
            }
        }
        if (selectedItem == "İşlemde Görev Alan Personel") {
            this.isPersonel = true;
        }
        if (selectedItem == i18n("M19108", "Mlz.Sarf")) {
            this.isMlzSarf = true;
        }
    }

    public getEpisodeActionById(id: any): Promise<EpisodeAction> {
        let ea;
        let fullApiUrl: string = 'api/RequestedProceduresService/getEpisodeActionById?objectId=' + id;
        this.httpService.get<EpisodeAction>(fullApiUrl).then((response) => {
            ea = response;
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
        return ea;
    }

    IsBabyFormOpened: boolean = false;
    async selectBabyInfo(value: any): Promise<void> {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            let _data: BabyInfo = value.data as BabyInfo;
            if (_data._babyInformationFormViewModel._BabyObstetricInformation != null && _data._babyInformationFormViewModel._BabyObstetricInformation.IsNew == true) {
                TTVisual.InfoBox.Alert("Kaydedilmemiş Bebek Bilgisi! Değişiklik yapmak için önce Kaydet butonuna tıklamalısınız!");
            } else {
                this.IsBabyFormOpened = true;
                let _inputParam = {};
                _inputParam['isSelectBabyInfo'] = true;

                this.openDynamicComponent(_data.objectDefName, _data.objectId, _inputParam);
            }
        }
    }

    public async PrintBabyMotherBarcode(data: any) {
        if (data !== null && data.row !== null && data.row.data !== null) {
            let selectedBabyInfoObjectId = data.row.data.objectId;
            if (data.row.data._babyInformationFormViewModel != null) {
                if (data.row.data._babyInformationFormViewModel._BabyObstetricInformation.IsNew == true) {
                    TTVisual.InfoBox.Alert("Barkodu formu kaydettikten sonra yazdırabilirsiniz!");
                } else {
                    let that = this;
                    that.httpService.get<BabyMotherMatchBarcodeInfo>("/api/RegularObstetricService/GetBabyMotherMatchBarcodeInfo?babyObstetricInformation=" + selectedBabyInfoObjectId.toString() + "&motherSubepisode=" + that.regularObstetricNewFormViewModel._RegularObstetric.SubEpisode.toString())
                        .then(response => {
                            that.barcodePrintService.printAllBarcode(response, "generateBabyMotherMatchBarcode", "PrintBabyMotherBarcode");
                        })
                        .catch(error => {
                            that.messageService.showError(error);

                        });
                }
            } else {
                let that = this;
                that.httpService.get<BabyMotherMatchBarcodeInfo>("/api/RegularObstetricService/GetBabyMotherMatchBarcodeInfo?babyObstetricInformation=" + selectedBabyInfoObjectId.toString() + "&motherSubepisode=" + that.regularObstetricNewFormViewModel._RegularObstetric.SubEpisode.toString())
                    .then(response => {
                        that.barcodePrintService.printAllBarcode(response, "generateBabyMotherMatchBarcode", "PrintBabyMotherBarcode");
                    })
                    .catch(error => {
                        that.messageService.showError(error);

                    });
            }
        }
    }

    public async openEDogumReport(data: any) {
        if (data !== null && data.row !== null && data.row.data !== null) {
            let selectedBabyInfoObjectId = data.row.data.objectId;
            if (data.row.data._babyInformationFormViewModel != null) {
                if (data.row.data._babyInformationFormViewModel._BabyObstetricInformation.IsNew == true) {
                    TTVisual.InfoBox.Alert("Doğum bildirimini formu kaydettikten sonra yapabilirsiniz!");
                } else {
                    let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M21498", "Doğum Sonlandırma!"), i18n("M22719", "Formu kaydetmediğiniz için yaptığınız değişiklikler e-Doğum ekranına yüklenmeyecektir! \r\n\r\n Yine de devam etmek istiyor musunuz?"));
                    if (messageResult === "E") {
                        this.openEDogumReportFromServer(selectedBabyInfoObjectId);
                    }
                }

            } else {
                this.openEDogumReportFromServer(selectedBabyInfoObjectId);
            }
        }
    }

    public openEDogumReportFromServer(objectId: string) {
        let fullApiUrl: string = 'api/RegularObstetricService/OpenEDogumReport?babyObstetricInformation=' + objectId;
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public BabyInfoColumns = [
        {
            caption: i18n("", "Bebek Bilgileri"),
            dataField: "summary",
            dataType: 'string',
            minWidth: 500,
            height: '15vh',
            allowSorting: true
        },
        {
            name: "ReportColumn",
            width: 160,
            cellTemplate: "ReportButtonCellTemplate",
        },
        {
            name: "AdmissionColumn",
            width: 110,
            cellTemplate: "AdmissionButtonCellTemplate",
        },
        {
            name: "DeleteColumn",
            width: 80,
            cellTemplate: "DeleteButtonCellTemplate",
        },
        {
            name: "BarcodeColumn",
            width: 120,
            cellTemplate: "BarcodeButtonCellTemplate",
        }
    ];

    isDynamicComponentOpened: boolean = false;
    public BabyComponentInfo: DynamicComponentInfo = new DynamicComponentInfo();
    openDynamicComponent(objectDefName: any, objectID?: any, inputparam?: any) {
        this.isDynamicComponentOpened = false;


        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        if (objectID != null) {
            compInfo.objectID = objectID;
        } else {
            compInfo.objectID = null;
        }
        compInfo.ComponentName = 'BabyInformationForm';
        compInfo.ModuleName = 'NormalDogumModule';
        compInfo.ModulePath = 'Modules/Tibbi_Surec/Normal_Dogum_Modulu/NormalDogumModule';
        compInfo.InputParam = new DynamicComponentInputParam(inputparam, this.getActiveIDsModel());
        //compInfo.CloseWithStateTransition = true;
        //compInfo.DestroyComponentOnSave = true;
        //compInfo.RefreshComponent = true;

        this.BabyComponentInfo = compInfo;


        //if (objectID != null) {
        //    this.systemApiService.open(objectID, objectDefName, '4a0db5f5-7f8b-4497-9376-0bd6cf01f0b4', new DynamicComponentInputParam(inputparam, this.getActiveIDsModel())).then(x => {
        //    });
        //} else {
        //    this.systemApiService.new(objectDefName, null, '4a0db5f5-7f8b-4497-9376-0bd6cf01f0b4', new DynamicComponentInputParam(inputparam, this.getActiveIDsModel())).then(c => {
        //    });
        //}
        this.isDynamicComponentOpened = true;

    }

    isBabyInfoChanged: boolean = false; //bebek bilgilerinde değişiklik var mı?
    public async BabyInfoActionExecuted(value: any) {
        if (value != null && value.Cancelled == true) {
            this.IsBabyFormOpened = false;
        } else {

            let _data: BabyInformationFormViewModel = value as BabyInformationFormViewModel;

            let _babyInfo = this.regularObstetricNewFormViewModel.BabyInfoList.find(c => c.objectId == _data._BabyObstetricInformation.ObjectID);
            let _summary: string = "Bebek Bilgisi";

            if (_babyInfo == null) {
                let _baby: BabyInfo = new BabyInfo();
                _baby.objectId = _data._BabyObstetricInformation.ObjectID;
                _baby.objectDefName = "BABYOBSTETRICINFORMATION";
                _baby._babyInformationFormViewModel = _data;

                let _motherPatient: any = this.regularObstetricNewFormViewModel._RegularObstetric.Patient;
                if ((typeof _motherPatient) === 'string') {
                    _motherPatient = await this.objectContextService.getObjectWithDefName<Patient>(new Guid(_motherPatient as string), 'Patient') as Patient;
                }


                if (_data._BabyObstetricInformation.BabyStatus == BirthReportBabyStatus.Alive) {
                    _summary = "Yaşayan ;  " //Yaşam Durumu
                        + (_data._BabyObstetricInformation.Name != null ? _data._BabyObstetricInformation.Name : _data._BabyObstetricInformation.Patient.Name) + " " + _data._BabyObstetricInformation.Surname
                        + " Anne Adı:" +
                        ((_motherPatient != null && _motherPatient.Name != null) ? _motherPatient.Name : "") //Anne Adı
                        + " " +
                        ((_motherPatient != null && _motherPatient.Surname != null) ? _motherPatient.Surname : "") //Anne Soyadı
                        + " Doğum Tarihi:" +
                        (_data._BabyObstetricInformation.BirthDateTime != null ? _data._BabyObstetricInformation.BirthDateTime.toString() : "") //Doğum Tarihi
                        + " Kilo:" +
                        (_data._BabyObstetricInformation.Weigth != null ? _data._BabyObstetricInformation.Weigth.toString() : ""); //Kilo
                } else if (_data._BabyObstetricInformation.BabyStatus == BirthReportBabyStatus.Dead) {
                    _summary = "Ölü bebek;  " //Yaşam Durumu
                        + " Anne Adı:" +
                        ((_motherPatient != null && _motherPatient.Name != null) ? _motherPatient.Name : "") //Anne Adı
                        + " " +
                        ((_motherPatient != null && _motherPatient.Surname != null) ? _motherPatient.Surname : "") //Anne Soyadı
                        + " Ölüm Tarihi:" +
                        (_data._BabyObstetricInformation.DatetimeOfDeath != null ? _data._BabyObstetricInformation.DatetimeOfDeath.toString() : "") //Ölüm Tarihi
                        + " Ölüm Sebebi:" +
                        (_data._BabyObstetricInformation.CauseOfDeath != null ? _data._BabyObstetricInformation.CauseOfDeath.ADI : ""); //Ölüm Sebebi
                }
                _baby.summary = _summary;

                this.regularObstetricNewFormViewModel.BabyInfoList.unshift(_baby);
            } else {
                _babyInfo._babyInformationFormViewModel = _data;


                let _motherPatient: any = this.regularObstetricNewFormViewModel._RegularObstetric.Patient;
                if ((typeof _motherPatient) === 'string') {
                    _motherPatient = await this.objectContextService.getObjectWithDefName<Patient>(new Guid(_motherPatient as string), 'Patient') as Patient;
                }

                if (_data._BabyObstetricInformation.BabyStatus == BirthReportBabyStatus.Alive) {
                    _summary = "Yaşayan ;  " //Yaşam Durumu
                        + (_data._BabyObstetricInformation.Name != null ? _data._BabyObstetricInformation.Name : _data._BabyObstetricInformation.Patient.Name) + " " + _data._BabyObstetricInformation.Surname
                        + " Anne Adı:" +
                        ((_motherPatient != null && _motherPatient.Name != null) ? _motherPatient.Name : "") //Anne Adı
                        + " " +
                        ((_motherPatient != null && _motherPatient.Surname != null) ? _motherPatient.Surname : "") //Anne Soyadı
                        + " Doğum Tarihi:" +
                        (_data._BabyObstetricInformation.BirthDateTime != null ? _data._BabyObstetricInformation.BirthDateTime.toString() : "") //Doğum Tarihi
                        + " Kilo:" +
                        (_data._BabyObstetricInformation.Weigth != null ? _data._BabyObstetricInformation.Weigth.toString() : ""); //Kilo
                } else if (_data._BabyObstetricInformation.BabyStatus == BirthReportBabyStatus.Dead) {
                    _summary = "Ölü bebek;  " //Yaşam Durumu
                        + " Anne Adı:" +
                        ((_motherPatient != null && _motherPatient.Name != null) ? _motherPatient.Name : "") //Anne Adı
                        + " " +
                        ((_motherPatient != null && _motherPatient.Surname != null) ? _motherPatient.Surname : "") //Anne Soyadı
                        + " Ölüm Tarihi:" +
                        (_data._BabyObstetricInformation.DatetimeOfDeath != null ? _data._BabyObstetricInformation.DatetimeOfDeath.toString() : "") //Ölüm Tarihi
                        + " Ölüm Sebebi:" +
                        (_data._BabyObstetricInformation.CauseOfDeath != null ? _data._BabyObstetricInformation.CauseOfDeath.ADI : ""); //Ölüm Sebebi
                }

                _babyInfo.summary = _summary;
            }

            this.IsBabyFormOpened = false;
            this.isBabyInfoChanged = true;
        }
    }
    public btnAddBabyInfo() {
        this.IsBabyFormOpened = true;
        this.openDynamicComponent("BABYOBSTETRICINFORMATION", null, this.regularObstetricNewFormViewModel._RegularObstetric);
    }

    protected async save() {
        if (this.IsBabyFormOpened == true) {
            TTVisual.InfoBox.Alert("İşleme devam edebilmek için bebek bilgisini kayıt etmelisiniz!");
            return;
        }
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M21498", "Doğum Sonlandırma!"), i18n("M22719", "Doğum işlemleriniz devam etmektedir! \r\n\r\n Doğum işlemlerini sonlandırmak istiyor musunuz?"));
        if (messageResult === "E") {
            this.regularObstetricNewFormViewModel.IsPregnancyEnded = true; //Doğum İşlemini sonlandır.
        } else {
            this.regularObstetricNewFormViewModel.IsPregnancyEnded = false;
        }
        await super.save();
    }

    private async GridManipulations_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        let a = 1;
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        if (transDef !== null) {
            if (transDef.ToStateDefID === RegularObstetric.RegularObstetricStates.ObstetricProcedures) {
                this._RegularObstetric.IsPatientApprovalFormGiven = await this.GetIfPatientApprovalFormIsGiven(this._RegularObstetric.IsPatientApprovalFormGiven);
            }
        }
    }
    protected async PreScript(): Promise<void> {
        //c# tarafında yapılacak
        //////if (this._RegularObstetric.Episode.Patient.Sex.ADI === 'ERKEK')
        //////    throw new TTException('Bu işlemi erkek hastalara başlatamazsınız.');
        super.PreScript();
        ////let sp: ManipulationProcedure = new ManipulationProcedure(this._RegularObstetric.ObjectContext);
        ////let regularObstetricGUID: Guid = new Guid((await SystemParameterService.GetParameterValue('RegularObstetricProcedure', '8de3b1a7-5779-4646-b882-0ee24fc407a4')).trim());
        ////sp.ProcedureObject = <ProcedureDefinition>this._RegularObstetric.ObjectContext.GetObject(regularObstetricGUID, typeof ProcedureDefinition);
        //////this.SetProcedureDoctorAsCurrentResource();
        ////sp.ProcedureDepartment = <ResSection>this._RegularObstetric.MasterResource;
        ////this._RegularObstetric.RegularObstetricProcedures.push(sp);
    }


    private async GetEstimatedBirthDate(lastMenstrualPeriod: Date): Promise<Date> {
        let estimatedBirthDate: Date = lastMenstrualPeriod.AddDays(280); //Gebelik Süreci tahmini doğum tarihi => yaklaşık 40 hafta = 280 gün
        return estimatedBirthDate;
    }

    showPatientAdmissionPopup: boolean = false;
    private _patient: Patient;
    public async admissionForBaby(data: any) {
        if (data !== null && data.row !== null && data.row.data !== null) {

            let selectedBabyInfo: BabyInfo = data.row.data as BabyInfo;
            //var selectedBabyInfo = data.row.data;
            if (data.row.data._babyInformationFormViewModel != null) {
                if (data.row.data._babyInformationFormViewModel._BabyObstetricInformation.IsNew == true) {
                    TTVisual.InfoBox.Alert("Bebek kabulünü formu kaydettikten sonra yapabilirsiniz!");
                } else {
                    if (this.isBabyInfoChanged == true) {
                        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M21498", "Yenidoğan Kabulü!"), i18n("M22719", "Devam etmeniz durumunda yaptığınız değişiklikler kaydedilmeyecektir! \r\n\r\n Değişiklikleri kaydetmeden devam etmek istiyor musunuz?"));
                        if (messageResult === "E") {
                            this._patient = data.row.data._babyInformationFormViewModel._BabyObstetricInformation.Patient;

                            let _inputParam = {};
                            _inputParam['Patient'] = this._patient;
                            _inputParam['MinimizeForm'] = true;
                            _inputParam['IsNewbornRequired'] = true;

                            this.openAdmissionDynamicComponent(selectedBabyInfo.objectDefName, selectedBabyInfo.objectId, null, _inputParam);
                            //this.showPatientAdmissionPopup = true;
                            //this.openEDogumReportFromServer(selectedBabyInfoObjectId);
                        }
                    } else {
                        //var baby = await this.objectContextService.getObject<BabyObstetricInformation>(selectedBabyInfo.objectId, '21ed357e-33bf-4a60-b10b-7902ea386869') as BabyObstetricInformation;
                        //this._patient


                        this.objectContextService.getObject<BabyObstetricInformation>(selectedBabyInfo.objectId, new Guid('21ed357e-33bf-4a60-b10b-7902ea386869')).then(result => {

                            let _inputParam = {};
                            _inputParam['Patient'] = result.Patient;
                            _inputParam['MinimizeForm'] = true;
                            _inputParam['IsNewbornRequired'] = true;

                            this.openAdmissionDynamicComponent(selectedBabyInfo.objectDefName, selectedBabyInfo.objectId, null, _inputParam);

                        });

                        //this.showPatientAdmissionPopup = true;

                        //this._patient = data.row.data._babyInformationFormViewModel._BabyObstetricInformation.Patient;
                        //this.openEDogumReportFromServer(selectedBabyInfoObjectId);
                    }
                }

            } else {

                this.objectContextService.getObject<BabyObstetricInformation>(selectedBabyInfo.objectId, new Guid('21ed357e-33bf-4a60-b10b-7902ea386869')).then(result => {

                    let _inputParam = {};
                    _inputParam['Patient'] = result.Patient;
                    _inputParam['MinimizeForm'] = true;
                    _inputParam['IsNewbornRequired'] = true;

                    this.openAdmissionDynamicComponent('PATIENTADMISSION', null, 'ae86a7f9-497c-4945-8198-108dc56abbb0', _inputParam);

                });
                //this.openEDogumReportFromServer(selectedBabyInfoObjectId);
            }
        }
    }


    openAdmissionDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        this.isDynamicComponentOpened = false;
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, new DynamicComponentInputParam(inputparam, this.getActiveIDsModel())).then(x => {
            });
        } else {
            this.systemApiService.new(objectDefName, null, formDefId, new DynamicComponentInputParam(inputparam, this.getActiveIDsModel())).then(c => {
            });
        }
        this.showPatientAdmissionPopup = true;
    }

    public async deleteBabyObject(data: any) {
        if (data !== null && data.row !== null && data.row.data !== null) {

            let selectedBabyInfo: BabyInfo = data.row.data as BabyInfo;

            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "Bebek Silme", "Seçtiğiniz bebek bilgisi silinecektir!. \r\n\r\n Devam etmek istiyor musunuz?");
            if (messageResult === "E") {
                let that = this;
                if (selectedBabyInfo._babyInformationFormViewModel._BabyObstetricInformation != null && selectedBabyInfo._babyInformationFormViewModel._BabyObstetricInformation.IsNew == true) {
                    this.messageService.showSuccess("Seçilen Bebek Bilgisi Başarılı Bir Şekilde Silindi");
                    let fgfgh = this.regularObstetricNewFormViewModel.BabyInfoList.find(x => x.objectId != selectedBabyInfo.objectId);
                    this.regularObstetricNewFormViewModel.BabyInfoList = new Array<BabyInfo>();
                    if (fgfgh != null) {
                        this.regularObstetricNewFormViewModel.BabyInfoList.push(fgfgh);
                    }
                    this.IsBabyFormOpened = false;
                    this.BabyComponentInfo = new DynamicComponentInfo();
                    return true;
                } else {

                    that.httpService.get<any>("api/RegularObstetricService/DeleteBabyObject?BabyObjectID=" + selectedBabyInfo.objectId + "&BabyObjectDefName=" + selectedBabyInfo.objectDefName)
                        .then(response => {
                            this.messageService.showSuccess("Seçilen Bebek Bilgisi Başarılı Bir Şekilde Silindi");
                            let fgfgh = this.regularObstetricNewFormViewModel.BabyInfoList.find(x => x.objectId != response);
                            this.regularObstetricNewFormViewModel.BabyInfoList = new Array<BabyInfo>();
                            if (fgfgh != null) {
                                this.regularObstetricNewFormViewModel.BabyInfoList.push(fgfgh);
                            }
                            this.IsBabyFormOpened = false;
                            this.BabyComponentInfo = new DynamicComponentInfo();
                            return true;
                        })
                        .catch(error => {
                            this.messageService.showError(error);
                            return false;
                        });
                }
            }
        }
    }

    public componentCreated(e: any) {

    }


    @ViewChild('dynamicComponent') dynamicComponent: ComposeComponent;
    public BabyDynamicComponentClosed(e: any) {
        this.IsBabyFormOpened = false;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new RegularObstetric();
        this.regularObstetricNewFormViewModel = new RegularObstetricNewFormViewModel();
        this._ViewModel = this.regularObstetricNewFormViewModel;
        this.regularObstetricNewFormViewModel._RegularObstetric = this._TTObject as RegularObstetric;
        this.regularObstetricNewFormViewModel._RegularObstetric.Episode = new Episode();
        this.regularObstetricNewFormViewModel._RegularObstetric.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.regularObstetricNewFormViewModel._RegularObstetric.Pregnancy = new Pregnancy();
        this.regularObstetricNewFormViewModel._RegularObstetric.Pregnancy.BirthLocation = new SKRSDogumunGerceklestigiYer();
        this.regularObstetricNewFormViewModel._RegularObstetric.PregnancyRange = new SKRSGebelikAraligi();
        this.regularObstetricNewFormViewModel._RegularObstetric.BirthResult = new SKRSGebelikSonucu();
        this.regularObstetricNewFormViewModel._RegularObstetric.SubactionProcedures = new Array<SubActionProcedure>();
        this.regularObstetricNewFormViewModel._RegularObstetric.RegularObstetricPersonel = new Array<RegularObstetricPersonel>();
        this.regularObstetricNewFormViewModel._RegularObstetric.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
        this.regularObstetricNewFormViewModel._RegularObstetric.PregnantInformation = new PregnantInformation();
        this.regularObstetricNewFormViewModel._RegularObstetric.Pregnancy.IndicationReasons = new Array<IndicationReason>();
        this.regularObstetricNewFormViewModel._RegularObstetric.IndicationReasons = new Array<IndicationReason>();
        this.regularObstetricNewFormViewModel._RegularObstetric.MasterResource = new ResSection();
    }

    protected loadViewModel() {
        let that = this;
        that.regularObstetricNewFormViewModel = this._ViewModel as RegularObstetricNewFormViewModel;
        that._TTObject = this.regularObstetricNewFormViewModel._RegularObstetric;
        if (this.regularObstetricNewFormViewModel == null)
            this.regularObstetricNewFormViewModel = new RegularObstetricNewFormViewModel();
        if (this.regularObstetricNewFormViewModel._RegularObstetric == null)
            this.regularObstetricNewFormViewModel._RegularObstetric = new RegularObstetric();
        let episodeObjectID = that.regularObstetricNewFormViewModel._RegularObstetric["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.regularObstetricNewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.regularObstetricNewFormViewModel._RegularObstetric.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.regularObstetricNewFormViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.regularObstetricNewFormViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                        let diagnose = that.regularObstetricNewFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                        let responsibleUser = that.regularObstetricNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let pregnancyObjectID = that.regularObstetricNewFormViewModel._RegularObstetric["Pregnancy"];
        if (pregnancyObjectID != null && (typeof pregnancyObjectID === "string")) {
            let pregnancy = that.regularObstetricNewFormViewModel.Pregnancys.find(o => o.ObjectID.toString() === pregnancyObjectID.toString());
            if (pregnancy) {
                that.regularObstetricNewFormViewModel._RegularObstetric.Pregnancy = pregnancy;
            }
            if (pregnancy != null) {
                let birthLocationObjectID = pregnancy["BirthLocation"];
                if (birthLocationObjectID != null && (typeof birthLocationObjectID === "string")) {
                    let birthLocation = that.regularObstetricNewFormViewModel.SKRSDogumunGerceklestigiYers.find(o => o.ObjectID.toString() === birthLocationObjectID.toString());
                    if (birthLocation) {
                        pregnancy.BirthLocation = birthLocation;
                    }
                }
            }
        }

        let masterResourceObjectID = that.regularObstetricNewFormViewModel._RegularObstetric["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
            let masterResource = that.regularObstetricNewFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.regularObstetricNewFormViewModel._RegularObstetric.MasterResource = masterResource;
            }
        }

        let pregnancyRangeObjectID = that.regularObstetricNewFormViewModel._RegularObstetric["PregnancyRange"];
        if (pregnancyRangeObjectID != null && (typeof pregnancyRangeObjectID === "string")) {
            let pregnancyRange = that.regularObstetricNewFormViewModel.SKRSGebelikAraligis.find(o => o.ObjectID.toString() === pregnancyRangeObjectID.toString());
            if (pregnancyRange) {
                that.regularObstetricNewFormViewModel._RegularObstetric.PregnancyRange = pregnancyRange;
            }
        }
        let birthResultObjectID = that.regularObstetricNewFormViewModel._RegularObstetric["BirthResult"];
        if (birthResultObjectID != null && (typeof birthResultObjectID === "string")) {
            let birthResult = that.regularObstetricNewFormViewModel.SKRSGebelikSonucus.find(o => o.ObjectID.toString() === birthResultObjectID.toString());
            if (birthResult) {
                that.regularObstetricNewFormViewModel._RegularObstetric.BirthResult = birthResult;
            }
        }
        that.regularObstetricNewFormViewModel._RegularObstetric.SubactionProcedures = that.regularObstetricNewFormViewModel.GridManipulationsGridList;
        for (let detailItem of that.regularObstetricNewFormViewModel.GridManipulationsGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === "string")) {
                let procedureObject = that.regularObstetricNewFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === "string")) {
                let procedureDoctor = that.regularObstetricNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        that.regularObstetricNewFormViewModel._RegularObstetric.RegularObstetricPersonel = that.regularObstetricNewFormViewModel.GridPersonnelGridList;
        for (let detailItem of that.regularObstetricNewFormViewModel.GridPersonnelGridList) {
            let personelObjectID = detailItem["Personel"];
            if (personelObjectID != null && (typeof personelObjectID === "string")) {
                let personel = that.regularObstetricNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === personelObjectID.toString());
                if (personel) {
                    detailItem.Personel = personel;
                }
            }
        }
        that.regularObstetricNewFormViewModel._RegularObstetric.TreatmentMaterials = that.regularObstetricNewFormViewModel.GridTreatmentMaterialsGridList;
        for (let detailItem of that.regularObstetricNewFormViewModel.GridTreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.regularObstetricNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let malzemeTuruObjectID = detailItem["MalzemeTuru"];
            if (malzemeTuruObjectID != null && (typeof malzemeTuruObjectID === "string")) {
                let malzemeTuru = that.regularObstetricNewFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
                if (malzemeTuru) {
                    detailItem.MalzemeTuru = malzemeTuru;
                }
            }
        }

        that.regularObstetricNewFormViewModel._RegularObstetric.IndicationReasons = that.regularObstetricNewFormViewModel.IndicationReasonsGridList;
        for (let detailItem of that.regularObstetricNewFormViewModel.IndicationReasonsGridList) {
            let indicationReasonObjectID = detailItem["Indications"];
            if (indicationReasonObjectID != null && (typeof indicationReasonObjectID === "string")) {
                let indicationReason = that.regularObstetricNewFormViewModel.SKRSEndikasyonNedenleri.find(o => o.ObjectID.toString() === indicationReasonObjectID.toString());
                if (indicationReason) {
                    detailItem.Indications = indicationReason;
                }
            }

        }


    }

    async ngOnInit() {
        await this.load();
    }

    public onMasterResourceChanged(event): void {
        if (this._RegularObstetric != null && this._RegularObstetric.MasterResource != event) {
            this._RegularObstetric.MasterResource = event;
        }
    }

    public onActionDateChanged(event): void {
        if (this._RegularObstetric != null && this._RegularObstetric.ActionDate != event) {
            this._RegularObstetric.ActionDate = event;
        }
    }

    public onApprovalFormGivenChanged(event): void {
        if (this._RegularObstetric != null && this._RegularObstetric.IsPatientApprovalFormGiven != event) {
            this._RegularObstetric.IsPatientApprovalFormGiven = event;
        }
    }

    public onBirthLocationPregnancyChanged(event): void {
        if (this._RegularObstetric != null &&
            this._RegularObstetric.Pregnancy != null && this._RegularObstetric.Pregnancy.BirthLocation != event) {
            this._RegularObstetric.Pregnancy.BirthLocation = event;
        }
    }

    public onBirthResultChanged(event): void {
        if (this._RegularObstetric != null && this._RegularObstetric.BirthResult != event) {
            this._RegularObstetric.BirthResult = event;
        }
    }

    public onBirthTerminationDatePregnancyChanged(event): void {
        if (this._RegularObstetric != null &&
            this._RegularObstetric.Pregnancy != null && this._RegularObstetric.Pregnancy.BirthTerminationDate != event) {
            this._RegularObstetric.Pregnancy.BirthTerminationDate = event;
        }
    }

    public onEstimatedBirthDatePregnancyChanged(event): void {
        if (this._RegularObstetric != null &&
            this._RegularObstetric.Pregnancy != null && this._RegularObstetric.Pregnancy.EstimatedBirthDate != event) {
            this._RegularObstetric.Pregnancy.EstimatedBirthDate = event;
        }
    }

    public onLastMenstrualPeriodPregnancyChanged(event): void {
        if (this._RegularObstetric != null &&
            this._RegularObstetric.Pregnancy != null && this._RegularObstetric.Pregnancy.LastMenstrualPeriod != event) {
            this._RegularObstetric.Pregnancy.LastMenstrualPeriod = event;
        }
        this.GetEstimatedBirthDate(event).then(c => {
            this._RegularObstetric.Pregnancy.EstimatedBirthDate = c;
        });
    }

    public onMotherAgeChanged(event): void {
        if (this._RegularObstetric != null && this._RegularObstetric.MotherAge != event) {
            this._RegularObstetric.MotherAge = event;
        }
    }

    public onPregnancyRangeChanged(event): void {
        if (this._RegularObstetric != null && this._RegularObstetric.PregnancyRange != event) {
            this._RegularObstetric.PregnancyRange = event;
        }
    }

    public onPregnancyRiskInfoChanged(event): void {
        if (this._RegularObstetric != null && this._RegularObstetric.PregnancyRiskInfo != event) {
            this._RegularObstetric.PregnancyRiskInfo = event;
        }
    }

    public onttrichtextboxcontrol1Changed(event): void {
        if (this._RegularObstetric != null && this._RegularObstetric.Note != event) {
            this._RegularObstetric.Note = event;
        }
    }

    public onWhichPregnancyChanged(event): void {
        if (this._RegularObstetric != null && this._RegularObstetric.WhichPregnancy != event) {
            this._RegularObstetric.WhichPregnancy = event;
        }
    }

    public onAbortionsNumberChanges(event): void {
        if (this.regularObstetricNewFormViewModel.PregnantInfo.Abortions != event.value) {
            this.regularObstetricNewFormViewModel.PregnantInfo.Abortions = event.value;
        }
    }
    public onDCChanges(event): void {
        if (this.regularObstetricNewFormViewModel.PregnantInfo.DC != event.value) {
            this.regularObstetricNewFormViewModel.PregnantInfo.DC = event.value;
        }
    }
    public onParityChanges(event): void {
        if (this.regularObstetricNewFormViewModel.PregnantInfo.Parity != event.value) {
            this.regularObstetricNewFormViewModel.PregnantInfo.Parity = event.value;
        }
    }
    public onPregnancyNumberChanges(event): void {
        if (this.regularObstetricNewFormViewModel.PregnantInfo.PregnancyNumber != event.value) {
            this.regularObstetricNewFormViewModel.PregnantInfo.PregnancyNumber = event.value;
            this.regularObstetricNewFormViewModel._RegularObstetric.WhichPregnancy = this.regularObstetricNewFormViewModel.PregnantInfo.PregnancyNumber;
        }
    }
    public onUIEXChanges(event): void {
        if (this.regularObstetricNewFormViewModel.PregnantInfo.UIEX != event.value) {
            this.regularObstetricNewFormViewModel.PregnantInfo.UIEX = event.value;
        }
    }
    public onNewbornsNumberChanges(event): void {
        if (this.regularObstetricNewFormViewModel.NumberofNewborns != event.value) {
            this.regularObstetricNewFormViewModel.NumberofNewborns = event.value;
        }
    }
    public onStillbornNumberChanges(event): void {
        if (this.regularObstetricNewFormViewModel.NumberOfStillbornBabies != event.value) {
            this.regularObstetricNewFormViewModel.NumberOfStillbornBabies = event.value;
        }
    }

    public onLivingChildrenChanges(event): void {
        if (this.regularObstetricNewFormViewModel.PregnantInfo.NumberOfLivingChildren != event.value) {
            this.regularObstetricNewFormViewModel.PregnantInfo.NumberOfLivingChildren = event.value;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.ApprovalFormGiven, "Value", this.__ttObject, "IsPatientApprovalFormGiven");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "Note");
        redirectProperty(this.MotherAge, "Text", this.__ttObject, "MotherAge");
        redirectProperty(this.PregnancyRiskInfo, "Text", this.__ttObject, "PregnancyRiskInfo");
        redirectProperty(this.LastMenstrualPeriodPregnancy, "Value", this.__ttObject, "Pregnancy.LastMenstrualPeriod");
        redirectProperty(this.EstimatedBirthDatePregnancy, "Value", this.__ttObject, "Pregnancy.EstimatedBirthDate");
        redirectProperty(this.BirthTerminationDatePregnancy, "Value", this.__ttObject, "Pregnancy.BirthTerminationDate");
        redirectProperty(this.WhichPregnancy, "Text", this.__ttObject, "WhichPregnancy");
    }

    public initFormControls(): void {

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "SurgreyDepartmentListDefinition";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 18;

        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.DisplayText = "Ek Bilgi";
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 12;

        this.labelProcessTime = new TTVisual.TTLabel();
        this.labelProcessTime.Text = "İşlem Tarihi";
        this.labelProcessTime.BackColor = "#DCDCDC";
        this.labelProcessTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcessTime.ForeColor = "#000000";
        this.labelProcessTime.Name = "labelProcessTime";
        this.labelProcessTime.TabIndex = 11;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.BackColor = "#DCDCDC";
        this.GridEpisodeDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.Text = "Tanı";
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 6;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = "Özgeçmişe Ekle";
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 90;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisListDefinition";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = "Vaka Tanıları";
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 270;

        this.EpisodeDiagnosisType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnosisType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnosisType.DataMember = "DiagnosisType";
        this.EpisodeDiagnosisType.DisplayIndex = 2;
        this.EpisodeDiagnosisType.HeaderText = "Tanı Tipi";
        this.EpisodeDiagnosisType.Name = "EpisodeDiagnosisType";
        this.EpisodeDiagnosisType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = "Ana Tanı";
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 75;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = "Tanıyı Koyan";
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = "Tanı Giriş Tarihi";
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = "Giriş Yapılan İşlem";
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = "Anne Bilgileri";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 13;

        this.labelBirthLocationPregnancy = new TTVisual.TTLabel();
        this.labelBirthLocationPregnancy.Text = "Doğumun Gerçekleştiği Yer";
        this.labelBirthLocationPregnancy.Name = "labelBirthLocationPregnancy";
        this.labelBirthLocationPregnancy.TabIndex = 17;

        this.BirthLocationPregnancy = new TTVisual.TTObjectListBox();
        this.BirthLocationPregnancy.ListDefName = "";
        this.BirthLocationPregnancy.Name = "BirthLocationPregnancy";
        this.BirthLocationPregnancy.TabIndex = 16;

        this.labelBirthTerminationDatePregnancy = new TTVisual.TTLabel();
        this.labelBirthTerminationDatePregnancy.Text = "Doğum Sonlanma Tarihi";
        this.labelBirthTerminationDatePregnancy.Name = "labelBirthTerminationDatePregnancy";
        this.labelBirthTerminationDatePregnancy.TabIndex = 15;

        this.BirthTerminationDatePregnancy = new TTVisual.TTDateTimePicker();
        this.BirthTerminationDatePregnancy.Format = DateTimePickerFormat.Long;
        this.BirthTerminationDatePregnancy.Name = "BirthTerminationDatePregnancy";
        this.BirthTerminationDatePregnancy.TabIndex = 14;

        this.labelLastMenstrualPeriodPregnancy = new TTVisual.TTLabel();
        this.labelLastMenstrualPeriodPregnancy.Text = "Son Adet Tarihi";
        this.labelLastMenstrualPeriodPregnancy.Name = "labelLastMenstrualPeriodPregnancy";
        this.labelLastMenstrualPeriodPregnancy.TabIndex = 13;

        this.LastMenstrualPeriodPregnancy = new TTVisual.TTDateTimePicker();
        this.LastMenstrualPeriodPregnancy.Format = DateTimePickerFormat.Long;
        this.LastMenstrualPeriodPregnancy.Name = "LastMenstrualPeriodPregnancy";
        this.LastMenstrualPeriodPregnancy.TabIndex = 12;

        this.labelEstimatedBirthDatePregnancy = new TTVisual.TTLabel();
        this.labelEstimatedBirthDatePregnancy.Text = "Tahmini Doğum Tarihi";
        this.labelEstimatedBirthDatePregnancy.Name = "labelEstimatedBirthDatePregnancy";
        this.labelEstimatedBirthDatePregnancy.TabIndex = 11;

        this.EstimatedBirthDatePregnancy = new TTVisual.TTDateTimePicker();
        this.EstimatedBirthDatePregnancy.Format = DateTimePickerFormat.Long;
        this.EstimatedBirthDatePregnancy.Name = "EstimatedBirthDatePregnancy";
        this.EstimatedBirthDatePregnancy.TabIndex = 10;

        this.labelPregnancyRange = new TTVisual.TTLabel();
        this.labelPregnancyRange.Text = "Gebelik Aralığı";
        this.labelPregnancyRange.Name = "labelPregnancyRange";
        this.labelPregnancyRange.TabIndex = 9;

        this.PregnancyRange = new TTVisual.TTObjectListBox();
        this.PregnancyRange.ListDefName = "SKRSGebelikAraligiList";
        this.PregnancyRange.Name = "PregnancyRange";
        this.PregnancyRange.TabIndex = 8;

        this.labelBirthResult = new TTVisual.TTLabel();
        this.labelBirthResult.Text = "Gebelik Sonucu";
        this.labelBirthResult.Name = "labelBirthResult";
        this.labelBirthResult.TabIndex = 7;

        this.BirthResult = new TTVisual.TTObjectListBox();
        this.BirthResult.Required = true;
        this.BirthResult.ListDefName = "SKRSGebelikSonucuList";
        this.BirthResult.BackColor = "#FFE3C6";
        this.BirthResult.Name = "BirthResult";
        this.BirthResult.TabIndex = 6;

        this.labelWhichPregnancy = new TTVisual.TTLabel();
        this.labelWhichPregnancy.Text = "Kaçıncı Gebelik";
        this.labelWhichPregnancy.Name = "labelWhichPregnancy";
        this.labelWhichPregnancy.TabIndex = 5;

        this.WhichPregnancy = new TTVisual.TTTextBox();
        this.WhichPregnancy.Required = true;
        this.WhichPregnancy.BackColor = "#FFE3C6";
        this.WhichPregnancy.Name = "WhichPregnancy";
        this.WhichPregnancy.TabIndex = 4;

        this.labelPregnancyRiskInfo = new TTVisual.TTLabel();
        this.labelPregnancyRiskInfo.Text = "Annenin Gebelikte Geçirdiği Sağlık Riskleri";
        this.labelPregnancyRiskInfo.Name = "labelPregnancyRiskInfo";
        this.labelPregnancyRiskInfo.TabIndex = 3;

        this.PregnancyRiskInfo = new TTVisual.TTTextBox();
        this.PregnancyRiskInfo.Name = "PregnancyRiskInfo";
        this.PregnancyRiskInfo.TabIndex = 2;

        this.labelMotherAge = new TTVisual.TTLabel();
        this.labelMotherAge.Text = "Anne Yaşı";
        this.labelMotherAge.Name = "labelMotherAge";
        this.labelMotherAge.TabIndex = 1;

        this.MotherAge = new TTVisual.TTTextBox();
        this.MotherAge.Name = "MotherAge";
        this.MotherAge.TabIndex = 0;

        this.TabSubaction = new TTVisual.TTTabControl();
        this.TabSubaction.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TabSubaction.Name = "TabSubaction";
        this.TabSubaction.TabIndex = 7;

        this.ManipulationTab = new TTVisual.TTTabPage();
        this.ManipulationTab.DisplayIndex = 0;
        this.ManipulationTab.BackColor = "#FFFFFF";
        this.ManipulationTab.TabIndex = 0;
        this.ManipulationTab.Text = "Tıbbi/Cerrahi Uygulama";
        this.ManipulationTab.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ManipulationTab.Name = "ManipulationTab";

        this.GridManipulations = new TTVisual.TTGrid();
        this.GridManipulations.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridManipulations.Name = "GridManipulations";
        this.GridManipulations.TabIndex = 0;

        this.RegularObstetricActionDate = new TTVisual.TTDateTimePickerColumn();
        this.RegularObstetricActionDate.Format = DateTimePickerFormat.Custom;
        this.RegularObstetricActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.RegularObstetricActionDate.DataMember = "ActionDate";
        this.RegularObstetricActionDate.DisplayIndex = 0;
        this.RegularObstetricActionDate.HeaderText = "Tarih/Saat";
        this.RegularObstetricActionDate.Name = "RegularObstetricActionDate";
        this.RegularObstetricActionDate.Width = 180;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = "SurgeryListDefinition";
        this.ProcedureObject.DataMember = "ProcedureObject";
        this.ProcedureObject.DisplayIndex = 1;
        this.ProcedureObject.HeaderText = "Tıbbi/Cerrahi Uygulama";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.Width = 340;

        this.RegularObstetricDoctor = new TTVisual.TTListBoxColumn();
        this.RegularObstetricDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.RegularObstetricDoctor.DataMember = "ProcedureDoctor";
        this.RegularObstetricDoctor.DisplayIndex = 2;
        this.RegularObstetricDoctor.HeaderText = "İşlemi Yapması Öngörülen Tabip";
        this.RegularObstetricDoctor.Name = "RegularObstetricDoctor";
        this.RegularObstetricDoctor.Width = 300;

        this.RaporTakipNo = new TTVisual.TTTextBoxColumn();
        this.RaporTakipNo.DisplayIndex = 3;
        this.RaporTakipNo.HeaderText = "Rapor Takip No";
        this.RaporTakipNo.Name = "RaporTakipNo";
        this.RaporTakipNo.Width = 100;

        this.OzelDurum = new TTVisual.TTListDefComboBoxColumn();
        this.OzelDurum.ListDefName = "OzelDurumListDefinition";
        this.OzelDurum.DisplayIndex = 4;
        this.OzelDurum.HeaderText = "Özel Durum";
        this.OzelDurum.Name = "OzelDurum";
        this.OzelDurum.Width = 100;

        this.AyniFarkliKesi = new TTVisual.TTListDefComboBoxColumn();
        this.AyniFarkliKesi.ListDefName = "AyniFarkliKesiListDefinition";
        this.AyniFarkliKesi.DisplayIndex = 5;
        this.AyniFarkliKesi.HeaderText = "Aynı Farklı Kesi";
        this.AyniFarkliKesi.Name = "AyniFarkliKesi";
        this.AyniFarkliKesi.Width = 100;

        this.CokluOzelDurum = new TTVisual.TTButtonColumn();
        this.CokluOzelDurum.DisplayIndex = 6;
        this.CokluOzelDurum.HeaderText = "Çoklu Özel Durum";
        this.CokluOzelDurum.Name = "CokluOzelDurum";
        this.CokluOzelDurum.Width = 100;

        this.PersonnelTab = new TTVisual.TTTabPage();
        this.PersonnelTab.DisplayIndex = 1;
        this.PersonnelTab.BackColor = "#FFFFFF";
        this.PersonnelTab.TabIndex = 1;
        this.PersonnelTab.Text = "İşlemde Görev Alan Personel";
        this.PersonnelTab.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PersonnelTab.Name = "PersonnelTab";

        this.GridPersonnel = new TTVisual.TTGrid();
        this.GridPersonnel.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridPersonnel.Name = "GridPersonnel";
        this.GridPersonnel.TabIndex = 0;

        this.Personnel = new TTVisual.TTListBoxColumn();
        this.Personnel.ListDefName = "UserListDefinition";
        this.Personnel.DataMember = "Personel";
        this.Personnel.DisplayIndex = 0;
        this.Personnel.HeaderText = "Personel";
        this.Personnel.Name = "Personnel";
        this.Personnel.Width = 820;
        this.Personnel.AutoCompleteDialogHeight = '60%';


        this.PersonnelWork = new TTVisual.TTTextBoxColumn();
        this.PersonnelWork.DataMember = "Personel.Work";
        this.PersonnelWork.DisplayIndex = 1;
        this.PersonnelWork.HeaderText = "Görevi";
        this.PersonnelWork.Name = "PersonnelWork";
        this.PersonnelWork.Width = 820;
        this.PersonnelWork.ReadOnly = true;

        this.TreatmentMaterial = new TTVisual.TTTabPage();
        this.TreatmentMaterial.DisplayIndex = 2;
        this.TreatmentMaterial.BackColor = "#FFFFFF";
        this.TreatmentMaterial.TabIndex = 0;
        this.TreatmentMaterial.Text = "Sarf Giriş";
        this.TreatmentMaterial.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TreatmentMaterial.Name = "TreatmentMaterial";

        this.GridTreatmentMaterials = new TTVisual.TTGrid();
        this.GridTreatmentMaterials.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridTreatmentMaterials.Name = "GridTreatmentMaterials";
        this.GridTreatmentMaterials.TabIndex = 0;

        this.MaterialActionDate = new TTVisual.TTDateTimePickerColumn();
        this.MaterialActionDate.Format = DateTimePickerFormat.Custom;
        this.MaterialActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.MaterialActionDate.DataMember = "ActionDate";
        this.MaterialActionDate.DisplayIndex = 0;
        this.MaterialActionDate.HeaderText = "Tarih/Saat";
        this.MaterialActionDate.Name = "MaterialActionDate";
        this.MaterialActionDate.Width = 180;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = "Malzeme";
        this.Material.Name = "Material";
        this.Material.Width = 340;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkodu";
        this.Barcode.Name = "Barcode";
        this.Barcode.Width = 100;

        this.UseAmount = new TTVisual.TTTextBoxColumn();
        this.UseAmount.DataMember = "UseAmount";
        this.UseAmount.DisplayIndex = 3;
        this.UseAmount.HeaderText = "Kullanılan Miktar";
        this.UseAmount.Name = "UseAmount";
        this.UseAmount.Width = 100;

        this.UnitType = new TTVisual.TTTextBoxColumn();
        this.UnitType.DisplayIndex = 4;
        this.UnitType.HeaderText = "Birimi";
        this.UnitType.Name = "UnitType";
        this.UnitType.ReadOnly = true;
        this.UnitType.Width = 100;

        this.StockOutAmount = new TTVisual.TTTextBoxColumn();
        this.StockOutAmount.DataMember = "Amount";
        this.StockOutAmount.DisplayIndex = 5;
        this.StockOutAmount.HeaderText = "Stoktan Düşecek Miktar";
        this.StockOutAmount.Name = "StockOutAmount";
        this.StockOutAmount.Visible = false;
        this.StockOutAmount.Width = 150;

        this.UBBCODE = new TTVisual.TTTextBoxColumn();
        this.UBBCODE.DataMember = "UBBCode";
        this.UBBCODE.DisplayIndex = 6;
        this.UBBCODE.HeaderText = "UBB Kodu";
        this.UBBCODE.Name = "UBBCODE";
        this.UBBCODE.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DisplayIndex = 7;
        this.DistributionType.HeaderText = "Takdim Şekli";
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Visible = false;
        this.DistributionType.Width = 100;

        this.Notes = new TTVisual.TTTextBoxColumn();
        this.Notes.DataMember = "Note";
        this.Notes.DisplayIndex = 8;
        this.Notes.HeaderText = "Notlar";
        this.Notes.Name = "Notes";
        this.Notes.Width = 245;

        this.KodsuzMalzemeFiyati = new TTVisual.TTTextBoxColumn();
        this.KodsuzMalzemeFiyati.DataMember = "KodsuzMalzemeFiyati";
        this.KodsuzMalzemeFiyati.DisplayIndex = 9;
        this.KodsuzMalzemeFiyati.HeaderText = "Kodsuz Malzeme Fiyatı";
        this.KodsuzMalzemeFiyati.Name = "KodsuzMalzemeFiyati";
        this.KodsuzMalzemeFiyati.Width = 100;

        this.MalzemeTuru = new TTVisual.TTListDefComboBoxColumn();
        this.MalzemeTuru.ListDefName = "MalzemeTuruListDefinition";
        this.MalzemeTuru.DataMember = "MalzemeTuru";
        this.MalzemeTuru.DisplayIndex = 10;
        this.MalzemeTuru.HeaderText = "Malzeme Türü";
        this.MalzemeTuru.Name = "MalzemeTuru";
        this.MalzemeTuru.Width = 100;

        this.Kdv = new TTVisual.TTTextBoxColumn();
        this.Kdv.DataMember = "Kdv";
        this.Kdv.DisplayIndex = 11;
        this.Kdv.HeaderText = "Kdv";
        this.Kdv.Name = "Kdv";
        this.Kdv.Width = 100;

        this.MalzemeBrans = new TTVisual.TTTextBoxColumn();
        this.MalzemeBrans.DataMember = "MalzemeBrans";
        this.MalzemeBrans.DisplayIndex = 12;
        this.MalzemeBrans.HeaderText = "Malzeme Branş";
        this.MalzemeBrans.Name = "MalzemeBrans";
        this.MalzemeBrans.Width = 100;

        this.MalzemeSatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.MalzemeSatinAlisTarihi.DataMember = "MalzemeSatinAlisTarihi";
        this.MalzemeSatinAlisTarihi.DisplayIndex = 13;
        this.MalzemeSatinAlisTarihi.HeaderText = "Malzeme Satın Alınma Tarihi";
        this.MalzemeSatinAlisTarihi.Name = "MalzemeSatinAlisTarihi";
        this.MalzemeSatinAlisTarihi.Width = 100;

        this.ApprovalFormGiven = new TTVisual.TTCheckBox();
        this.ApprovalFormGiven.Value = false;
        this.ApprovalFormGiven.Text = "Aydınlatılmış Onam Formu";
        this.ApprovalFormGiven.Title = "Aydınlatılmış Onam Formu";
        this.ApprovalFormGiven.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ApprovalFormGiven.Name = "ApprovalFormGiven";
        this.ApprovalFormGiven.TabIndex = 2;

        this.IndicationReasons = new TTVisual.TTGrid();
        this.IndicationReasons.Name = "IndicationReasons";
        this.IndicationReasons.TabIndex = 20
        this.IndicationReasons.Height = "145px";
        this.IndicationReasons.ShowFilterCombo = true;
        this.IndicationReasons.Filter = { ListDefName: "SKRSEndikasyonNedenleriList" };
        this.IndicationReasons.FilterColumnName = "IndicationsIndicationReason";
        this.IndicationReasons.FilterLabel = i18n("M23785", "Endikasyon Nedenleri");
        this.IndicationReasons.AllowUserToAddRows = false;
        this.IndicationReasons.DeleteButtonWidth = "5%";
        this.IndicationReasons.AllowUserToDeleteRows = true;
        this.IndicationReasons.IsFilterLabelSingleLine = true;

        this.IndicationsIndicationReason = new TTVisual.TTListBoxColumn();
        this.IndicationsIndicationReason.ListDefName = "SKRSEndikasyonNedenleriList";
        this.IndicationsIndicationReason.DataMember = "Indications";
        this.IndicationsIndicationReason.DisplayIndex = 0;
        this.IndicationsIndicationReason.HeaderText = i18n("M13717", "Endikasyon Nedenleri");
        this.IndicationsIndicationReason.Name = "IndicationsIndicationReason";
        this.IndicationsIndicationReason.Width = 300;


        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.GridManipulationsColumns = [this.RegularObstetricActionDate, this.ProcedureObject, this.RegularObstetricDoctor, this.RaporTakipNo, this.OzelDurum, this.AyniFarkliKesi, this.CokluOzelDurum];
        this.GridPersonnelColumns = [this.Personnel, this.PersonnelWork];
        this.GridTreatmentMaterialsColumns = [this.MaterialActionDate, this.Material, this.Barcode, this.UseAmount, this.UnitType, this.StockOutAmount, this.UBBCODE, this.DistributionType, this.Notes, this.KodsuzMalzemeFiyati, this.MalzemeTuru, this.Kdv, this.MalzemeBrans, this.MalzemeSatinAlisTarihi];
        this.ttgroupbox1.Controls = [this.MasterResource, this.labelBirthLocationPregnancy, this.BirthLocationPregnancy, this.labelBirthTerminationDatePregnancy, this.BirthTerminationDatePregnancy, this.labelLastMenstrualPeriodPregnancy, this.LastMenstrualPeriodPregnancy, this.labelEstimatedBirthDatePregnancy, this.EstimatedBirthDatePregnancy, this.labelPregnancyRange, this.PregnancyRange, this.labelBirthResult, this.BirthResult, this.labelWhichPregnancy, this.WhichPregnancy, this.labelPregnancyRiskInfo, this.PregnancyRiskInfo, this.labelMotherAge, this.MotherAge];
        this.TabSubaction.Controls = [this.ManipulationTab, this.PersonnelTab, this.TreatmentMaterial];
        this.ManipulationTab.Controls = [this.GridManipulations];
        this.PersonnelTab.Controls = [this.GridPersonnel];
        this.TreatmentMaterial.Controls = [this.GridTreatmentMaterials];
        this.IndicationReasonsColumns = [this.IndicationsIndicationReason];
        this.Controls = [this.ttrichtextboxcontrol1, this.MasterResource, this.IndicationReasons, this.IndicationsIndicationReason, this.labelProcessTime, this.ActionDate, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.ttgroupbox1, this.labelBirthLocationPregnancy, this.BirthLocationPregnancy, this.labelBirthTerminationDatePregnancy, this.BirthTerminationDatePregnancy, this.labelLastMenstrualPeriodPregnancy, this.LastMenstrualPeriodPregnancy, this.labelEstimatedBirthDatePregnancy, this.EstimatedBirthDatePregnancy, this.labelPregnancyRange, this.PregnancyRange, this.labelBirthResult, this.BirthResult, this.labelWhichPregnancy, this.WhichPregnancy, this.labelPregnancyRiskInfo, this.PregnancyRiskInfo, this.labelMotherAge, this.MotherAge, this.TabSubaction, this.ManipulationTab, this.GridManipulations, this.RegularObstetricActionDate, this.ProcedureObject, this.RegularObstetricDoctor, this.RaporTakipNo, this.OzelDurum, this.AyniFarkliKesi, this.CokluOzelDurum, this.PersonnelTab, this.GridPersonnel, this.Personnel, this.TreatmentMaterial, this.GridTreatmentMaterials, this.MaterialActionDate, this.Material, this.Barcode, this.UseAmount, this.UnitType, this.StockOutAmount, this.UBBCODE, this.DistributionType, this.Notes, this.KodsuzMalzemeFiyati, this.MalzemeTuru, this.Kdv, this.MalzemeBrans, this.MalzemeSatinAlisTarihi, this.ApprovalFormGiven];

    }


}
