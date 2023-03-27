//$2ABB16F9
import { Component, ViewChild, OnInit, AfterViewInit, OnDestroy, NgZone, Renderer2, Input } from '@angular/core';
import { PatientAdmissionFormViewModel, HCRequestReasonDetail, MedulaResult, TakipDVO, FazlaTakipBilgileriDTO, FazlaTakipDTO, SearchWithPatientIDResult, PersonnelTakeOff_Input, PatientAdmissionListModel, InputModelForQueries, EpicrisisReport_Class, MergeEmergencyClass, YurtDisiYardimHakki, HastaTemasDurumuResultModel, SevkTalepNoSonuc, SevkTalepNoSonucDetay, FilterDoctorModel } from "./PatientAdmissionFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { Util } from "Fw/Components/Util";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/ActionForm";
import { AdmissionAppointment, CloseToNewOldEpisodes, AdmissionTypeEnum, ResSection, EngelliRaporuMuracaatTipiEnum, EngelliRaporuMuracaatNedeniEnum, EDisabledReport, EStatusNotRepCommitteeObj } from 'NebulaClient/Model/AtlasClientModel';
import { AdmissionStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { CommonService } from "ObjectClassService/CommonService";
import { Convert } from "NebulaClient/Mscorlib/Convert";
import { DispatchTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DatePipe } from '@angular/common';
import { SubEpisodeProtocol } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisodeProtocolService } from "ObjectClassService/SubEpisodeProtocolService";
import { GetMedulaDefinitionService } from 'app/Invoice/GetMedulaDefinitionService';
import { Exception } from "NebulaClient/Mscorlib/Exception";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { HCRequestReason } from 'NebulaClient/Model/AtlasClientModel';
import { ITTObject } from "NebulaClient/StorageManager/InstanceManagement/ITTObject";
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { PatientAdmissionResourcesToBeReferred } from 'NebulaClient/Model/AtlasClientModel';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { PatientIdentityAndAddress } from 'NebulaClient/Model/AtlasClientModel';
import { PatientService } from "ObjectClassService/PatientService";
import { ResDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { ResPoliclinic } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { SKRSIlceKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKoyKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMahalleKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSUlkeKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAdliVakaGelisSekli } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYabanciHastaTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKanGrubu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumSirasi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSTRIAJKODU } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMedeniHali } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOzurlulukDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { StateStatusEnum } from "NebulaClient/Utils/Enums/StateStatusEnum";
import { ApplicationReasonEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PatientClassTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TownDefinitions } from 'NebulaClient/Model/AtlasClientModel';
import { TTException } from "NebulaClient/Utils/Exceptions/TTException";
import { TTObject } from "NebulaClient/StorageManager/InstanceManagement/TTObject";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { TTObjectDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectDef";
import { TTObjectStateDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateDef";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { ExternalHospitalDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { IstisnaiHal } from 'NebulaClient/Model/AtlasClientModel';
import { PayerDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PriorityStatusDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProtocolDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ProvizyonTipi } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SigortaliTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAdresTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBucakKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCSBMTipi } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { InputFormat } from "NebulaClient/Utils/Enums/InputFormat";
import { CharacterCasing } from "NebulaClient/Utils/Enums/CharacterCasing";
import { PatientAdmissionSearchForm } from "./PatientAdmissionSearch/PatientAdmissionSearchForm";
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ObjectContextService } from "Fw/Services/ObjectContextService";


import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { RequirementResultCode } from "Fw/Requirements/RequirementResultCode";
import { RequirementExecutor } from "Fw/Requirements/RequirementExecutor";
import { PatientAdmissionRequirements } from "./Requirements/PatientAdmissionRequirements";
import { PatientAddressRequirements } from "./Requirements/PatientAddressRequirements";
import { PatientInfoRequirements } from "./Requirements/PatientInfoRequirements";

import { PatientBarcodeInfo, PatientArchieveBarcodeInfo } from 'app/Barcode/Models/PatientBarcodeInfo';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';

import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { IActiveEpisodeActionService } from 'Fw/Services/IActiveEpisodeActionService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';

import { HvlCheckBox } from 'Fw/Components/HvlCheckBox';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { PatientCompareFormViewModel } from './PatientCompareFormViewModel';
import { DateParam } from 'app/NebulaClient/Mscorlib/DateParam';
import { StringParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { GiveAppointmentModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { DxDataGridComponent, DxButtonComponent, DxSelectBoxComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { GetHCRequestReasonDetailsResponse } from './PatientAdmissionFormViewModel';
import { InfoBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { forEach } from 'app/NebulaClient/System/Collections/Enumeration/Enumerator';
import { ShortHcInfo } from '../Tibbi_Surec_Evrensel_Modulu/EpisodeActionFormViewModel';
import DataSource from 'devextreme/data/data_source';
import ArrayStore from 'devextreme/data/array_store';
import CustomStore from 'devextreme/data/custom_store';
import DateTime from '../../../wwwroot/app/NebulaClient/System/Time/DateTime';

@Component({
    selector: 'PatientAdmissionForm',
    templateUrl: './PatientAdmissionForm.html',
    providers: [MessageService, DatePipe, GetMedulaDefinitionService,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }
    ]
})

export class PatientAdmissionForm extends ActionForm implements OnInit, AfterViewInit, OnDestroy {


    patientPatientAdmission: any;
    AcilTriaj: TTVisual.TTListDefComboBox;
    MergeTriaj: TTVisual.TTListDefComboBox;
    ActionDate: TTVisual.ITTDateTimePicker;
    MedulaVakaTarihi: TTVisual.ITTDateTimePicker;
    AdmissionType: TTVisual.ITTListDefComboBox;
    AllPatientAdmissions: boolean;
    AnlasmaliKurum: TTVisual.ITTObjectListBox;
    IsNewBorn: TTVisual.ITTCheckBox;
    BDYearOnly: TTVisual.ITTCheckBox;
    BirthDate: TTVisual.ITTDateTimePicker;
    BloodGroup: TTVisual.ITTObjectListBox;
    SKRSAdliVaka: TTVisual.ITTObjectListBox;
    SKRSYabanciHasta: TTVisual.ITTObjectListBox;
    Branch: TTVisual.ITTObjectListBox;
    btnClearPatientListPanel: TTVisual.ITTButton;
    btnPatientAdmissionClear: TTVisual.ITTButton;
    btnPatientAdmissionSave: TTVisual.ITTButton;
    btnPatientAdmissionNewSave: TTVisual.ITTButton;
    btnSearchList: TTVisual.ITTButton;
    btnSorgula: TTVisual.ITTButton;
    btnShowPatientDetailInfo: TTVisual.ITTButton;
    Building: TTVisual.ITTObjectListBox;
    CityOfBirth: TTVisual.ITTTextBox;
    CityOfRegistry: TTVisual.ITTObjectListBox;
    Death: TTVisual.ITTCheckBox;
    Donor: TTVisual.ITTCheckBox;
    cbx112: TTVisual.ITTCheckBox;
    DispatchEmergencyCons: TTVisual.ITTCheckBox;
    devredilenKurum: TTVisual.ITTListDefComboBox;
    DispatchedConsultationDef: TTVisual.ITTTextBox;
    DispatchHospital: TTVisual.ITTTabPage;
    DispatchHospitalDoctors: TTVisual.ITTObjectListBox;
    DispatchHospitalList: TTVisual.ITTObjectListBox;
    DispatchHospitalResources: TTVisual.ITTObjectListBox;
    DispatchType: TTVisual.ITTEnumComboBox;
    PatientClassGroup: TTVisual.ITTEnumComboBox;
    ApplicationReason: TTVisual.ITTEnumComboBox;
    EducationStatus: TTVisual.ITTObjectListBox;
    SKRSMaritalStatus: TTVisual.ITTObjectListBox;
    SKRSOzurlulukDurumu: TTVisual.ITTObjectListBox;
    EndDate: Date;
    ExDate: TTVisual.ITTMaskedTextBox;
    ExternalHospital: TTVisual.ITTObjectListBox;
    FatherName: TTVisual.ITTTextBox;
    Nationality: TTVisual.ITTObjectListBox;
    FirstTab: TTVisual.ITTTabPage;
    Foreign: TTVisual.ITTCheckBox;
    ForeignUniqueNo: TTVisual.ITTTextBox;
    Age: TTVisual.ITTTextBox;
    DeathReportNo: TTVisual.ITTTextBox;
    GrpAddressInfo: TTVisual.ITTGroupBox;
    HCModeOfPayment: TTVisual.ITTEnumComboBox;
    HCRequestReason: TTVisual.ITTObjectListBox;
    HealthCommittee: TTVisual.ITTTabPage;
    HomeAddress: TTVisual.ITTTextBox;
    OtherBirthPlace: TTVisual.ITTTextBox;
    labelBirthDate: TTVisual.ITTLabel;
    labelBloodGroup: TTVisual.ITTLabel;
    labelDispatchedConsultationDef: TTVisual.ITTLabel;
    labelExDate: TTVisual.ITTLabel;
    labelExternalHospital: TTVisual.ITTLabel;
    labelFatherName: TTVisual.ITTLabel;
    labelNationality: TTVisual.ITTLabel;
    labelHCModeOfPayment: TTVisual.ITTLabel;
    labelHCRequestReason: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelReasonForExaminationHCRequestReason: TTVisual.ITTLabel;
    labelSex: TTVisual.ITTLabel;
    labelSurname: TTVisual.ITTLabel;
    labelUniqueRefNo: TTVisual.ITTLabel;
    lblAdres: TTVisual.ITTLabel;
    lblb: TTVisual.ITTLabel;
    lblPriorityStatus: TTVisual.ITTLabel;
    medulaTakipNo: TTVisual.ITTTextBox;
    MobilePhone: TTVisual.ITTMaskedTextBox;
    BusinessPhone: TTVisual.ITTMaskedTextBox;
    MotherName: TTVisual.ITTTextBox;
    Name: TTVisual.ITTTextBox;
    PassportNo: TTVisual.ITTTextBox;
    PatientHistoryListView: TTVisual.ITTListView;
    PatientHistoryPanel: TTVisual.ITTPanel;
    PatientListPanel: TTVisual.ITTPanel;
    PatientlistView: TTVisual.ITTListView;
    AppointmentlistView: TTVisual.ITTListView;
    PayerList: TTVisual.ITTObjectListBox;
    plakaNo: TTVisual.ITTTextBox;
    Policlinic: TTVisual.ITTObjectListBox;
    PoliclinicSearchList: TTVisual.ITTObjectListBox;
    PriorityStatus: TTVisual.ITTObjectListBox;
    pPrivacyName: TTVisual.ITTTextBox;
    pPrivacySurname: TTVisual.ITTTextBox;
    pPrivacyReason: TTVisual.ITTTextBox;
    pPrivacy: TTVisual.ITTCheckBox;
    pPrivacyEndDate: TTVisual.ITTDateTimePicker;
    SearchListWithProvision: TTVisual.ITTCheckBox;
    SearchListWithoutProvision: TTVisual.ITTCheckBox;
    DonorUniqueRefNo: TTVisual.ITTTextBox;
    @ViewChild('isNewBorn') isNewBornInstance: HvlCheckBox;
    @ViewChild('hcUnitGrid') hcUnitGrid: DxDataGridComponent;
    @ViewChild('departmentList') departmentList: DxSelectBoxComponent;    
    @ViewChild('leftSideGrid') leftSideGrid: DxDataGridComponent;

    leftSideGridDataSource: DataSource;

    private check: boolean = true;
    private searchString: string = "";
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProcedureDoctorToBeReferredPatientAdmissionResourcesToBeReferred: TTVisual.ITTListBoxColumn;

    public enableUnicrefNo: boolean = true;
    public enableUndefinedPatient: boolean = true;

    protected deleteCONSCRIPTIONPERIOD: boolean = true;
    protected deleteDEMOBILIZATIONTIME: boolean = true;
    protected deleteEMPLOYMENTRECORDID: boolean = true;
    protected deleteFORCESCOMMAND: boolean = true;
    protected deleteHEALTSLIPNUMBER: boolean = true;
    protected deleteMILITARYACCEPTANCETIME: boolean = true;
    protected deleteMILITARYCLASS: boolean = true;
    protected deleteMILITARYNO: boolean = true;
    protected deleteMILITARYOFFICER: boolean = true;
    protected deleteMILITARYUNIT: boolean = true;
    protected deleteRANK: boolean = true;
    protected deleteRELATIONSHIP: boolean = true;
    protected deleteRETIREMENTFUNDID: boolean = true;
    protected deleteSENDERCHAIR: boolean = true;
    protected deleteWARVETERA: boolean = true;
    public changePayerPopup: boolean = false;
    public showRisLisPopup: boolean = false;
    public showAppointmentListPopup: boolean = false;
    public showSevkTalepNoPopUp: boolean = false;
    public payerArray: Array<any> = [];
    public protocolArray: Array<any> = [];
    public bagliTakipArray: Array<any> = [];
    public bagliTakipNo: string = '';
    public bagliTakipAlinacakSEPid: any;
    isChangePassword: boolean = false;
    private saveEventSubscription: any;
    public showPayerTransferWarning = false;

    public tempResourcesToBeReferredPoliclinic: string;
    public tempProcedureDoctorToBeReferred: string;
    public pandemicInfo="";
    
    public DepartmentList;
    public PoliclinicList;
    public DoctorList;

    public showPatientContactStatus: boolean = false;
    public PatientContactStatusDoctorList: Array<FilterDoctorModel> = new Array<FilterDoctorModel>();
    public selectedDoctorForPatientContactStatus: Guid = Guid.Empty;

    public departmentSource = new DataSource({
        store: new ArrayStore({  
            key: "ObjectID" ,
            data: this.DepartmentList
             
        }), 
        searchOperation: 'contains',
        searchExpr: ['Name','NameShadow','NameLower','NameUpper']
    });

    public departmentSearchExp = [
        'Name','NameShadow','NameLower','NameUpper'];

    ProtocolNoSubEpisode: TTVisual.ITTTextBoxColumn;
    provizyonTarihi: TTVisual.ITTDateTimePicker;
    ReasonForExaminationHCRequestReason: TTVisual.ITTObjectListBox;
    RelatedProvision: TTVisual.ITTTextBox;
    ResourcePatientAdmissionResourcesToBeReferred: TTVisual.ITTListBoxColumn;
    ResourcesToBeReferred: TTVisual.ITTGrid;
    SearchPatient: TTVisual.ITTTextBox;
    Sex: TTVisual.ITTObjectListBox;
    StartDate: Date;
    SubEpisodesSubEpisode: TTVisual.ITTGrid;
    Surname: TTVisual.ITTTextBox;
    Tab: TTVisual.ITTTabControl;
    takipAlCevap: TTVisual.ITTTextBox;
    takipAlHataMesaji: TTVisual.ITTTextBox;
    takipTipi: TTVisual.ITTListDefComboBox;
    taniSecimPaneli: TTVisual.ITTGroupBox;
    tedaviTipi: TTVisual.ITTListDefComboBox;
    tedaviTuru: TTVisual.ITTListDefComboBox;
    tetkikIstemPaneli: TTVisual.ITTGroupBox;
    TownOfRegistry: TTVisual.ITTObjectListBox;
    ttgroupbox3: TTVisual.ITTGroupBox;
    ttgroupbox4: TTVisual.ITTGroupBox;
    ttgroupbox5: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    ttlabel19: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel21: TTVisual.ITTLabel;
    ttlabel22: TTVisual.ITTLabel;
    ttlabel23: TTVisual.ITTLabel;
    ttlabel26: TTVisual.ITTLabel;
    ttlabel27: TTVisual.ITTLabel;
    ttlabel28: TTVisual.ITTLabel;
    ttlabel29: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel30: TTVisual.ITTLabel;
    ttlabel31: TTVisual.ITTLabel;
    ttlabel32: TTVisual.ITTLabel;
    ttlabel33: TTVisual.ITTLabel;
    ttlabel34: TTVisual.ITTLabel;
    ttlabel35: TTVisual.ITTLabel;
    ttlabel36: TTVisual.ITTLabel;
    ttlabel37: TTVisual.ITTLabel;
    ttlabel38: TTVisual.ITTLabel;
    ttlabel39: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel40: TTVisual.ITTLabel;
    ttlabel41: TTVisual.ITTLabel;
    ttlabel42: TTVisual.ITTLabel;
    ttlabel43: TTVisual.ITTLabel;
    ttlabel44: TTVisual.ITTLabel;
    ttlabel45: TTVisual.ITTLabel;
    ttlabel46: TTVisual.ITTLabel;
    ttlabel47: TTVisual.ITTLabel;
    ttlabel48: TTVisual.ITTLabel;
    ttlabel49: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel50: TTVisual.ITTLabel;
    ttlabel53: TTVisual.ITTLabel;
    ttlabel54: TTVisual.ITTLabel;
    ttlabel55: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel60: TTVisual.ITTLabel;
    ttlabel61: TTVisual.ITTLabel;
    ttlabel62: TTVisual.ITTLabel;
    ttlabel63: TTVisual.ITTLabel;
    ttlabel66: TTVisual.ITTLabel;
    ttlabel68: TTVisual.ITTLabel;
    ttlabel69: TTVisual.ITTLabel;
    ttlabel70: TTVisual.ITTLabel;
    ttlabel71: TTVisual.ITTLabel;
    ttlabel72: TTVisual.ITTLabel;
    ttlabel73: TTVisual.ITTLabel;
    ttlabel74: TTVisual.ITTLabel;
    ttlabel75: TTVisual.ITTLabel;
    ttlabel77: TTVisual.ITTLabel;
    ttlabel78: TTVisual.ITTLabel;
    ttlabel79: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel80: TTVisual.ITTLabel;
    ttlabel81: TTVisual.ITTLabel;
    ttlabel85: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    MedulaIstisnaiHalComboBox: TTVisual.ITTListDefComboBox;
    ttmaskedtextbox2: TTVisual.ITTMaskedTextBox;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;

    SigortaliTuru: TTVisual.ITTObjectListBox;
    ttobjectlistbox3: TTVisual.ITTObjectListBox;
    ttobjectlistbox4: TTVisual.ITTObjectListBox;
    ttobjectlistbox5: TTVisual.ITTObjectListBox;
    ttobjectlistbox6: TTVisual.ITTObjectListBox;
    ttobjectlistbox7: TTVisual.ITTObjectListBox;
    BirthOrder: TTVisual.ITTObjectListBox;
    ttpanel1: TTVisual.ITTPanel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttextbox10: TTVisual.ITTTextBox;
    tttextbox11: TTVisual.ITTTextBox;
    ImportantPAInfo: TTVisual.ITTTextBox;
    txtMotherUniqueRefNo: TTVisual.ITTTextBox;
    ImportantPatientInfo: TTVisual.ITTTextBox;
    tttextbox13: TTVisual.ITTTextBox;
    tttextbox14: TTVisual.ITTTextBox;
    tttextbox15: TTVisual.ITTTextBox;
    tttextbox17: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox21: TTVisual.ITTTextBox;
    tttextbox22: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextbox6: TTVisual.ITTTextBox;
    tttextbox8: TTVisual.ITTTextBox;
    tttextbox9: TTVisual.ITTTextBox;
    txtEpisode: TTVisual.ITTTextBox;
    txtParcel: TTVisual.ITTTextBox;
    txtYUPASSID: TTVisual.ITTTextBox;
    txtYUPASSNO: TTVisual.ITTTextBox;
    UnIdentified: TTVisual.ITTCheckBox;
    UniqueRefNo: TTVisual.ITTTextBox;
    BeneficiaryUniqueRefNo: TTVisual.ITTTextBox;
    PatientNumber: TTVisual.ITTTextBox;
    BusinessAddress: TTVisual.ITTTextBox;
    BeneficiaryName: TTVisual.ITTTextBox;
    RelativeFullName: TTVisual.ITTTextBox;
    RelativeHomeAddress: TTVisual.ITTTextBox;
    RelativeMobilePhone: TTVisual.ITTMaskedTextBox;
    WorkPhone: TTVisual.ITTTextBox;
    YabanciSehir: TTVisual.ITTTextBox;
    YabanciUlke: TTVisual.ITTTextBox;
    yesilKartSevkEdenTesisKodu: TTVisual.ITTTextBox;
    YupasNo: TTVisual.ITTTextBox;
    Emergency112RefNoTextbox: TTVisual.ITTTextBox;
    Occupation: TTVisual.ITTObjectListBox;
    @ViewChild(PatientAdmissionSearchForm) patientSearchAuto: PatientAdmissionSearchForm;
    public ResourcesToBeReferredColumns = [];
    public SubEpisodesSubEpisodeColumns = [];
    public patientAdmissionFormViewModel: PatientAdmissionFormViewModel = new PatientAdmissionFormViewModel();

    @ViewChild('searchForm') searchFormInstance: PatientAdmissionSearchForm;

    /*Engelli Raporu*/
    DisabledReportApplicationExplanation: TTVisual.ITTTextBox;
    DisabledReportApplicationReason: TTVisual.ITTEnumComboBox;  //Müracaat Nedeni
    DisabledReportApplicationType: TTVisual.ITTEnumComboBox;  //Müracaat Tipi ( Engelli Raporu )
    DisabledReportCorporateApplicationType: TTVisual.ITTEnumComboBox; //Kurumsal Müracaat Türü  
    DisabledReportPersonalApplicationType: TTVisual.ITTEnumComboBox; //Kişisel Müracaat Tipi
    DisabledReportTerrorAccidentInjuryAppReason: TTVisual.ITTEnumComboBox; // Terör - Kaza Yaralanma Müracaat Nedeni
    DisabledReportTerrorAccidentInjuryAppType: TTVisual.ITTEnumComboBox; //Terör Kaza - Yaralanma Müracaat Tipi
    public selectedReportIsDisabled: boolean = false;
    /*Engelli Raporu*/
    /*Çalışabilir Kağıdı */
    public ShowWorkablePaperPopUp: boolean = false;
    public LeaveDateForWorkablePaper: Date = new Date();
    public WorkDateForWorkablePaper: Date = new Date();

    /*Çalışabilir Kağıdı */
    /* E-Durum Bildirir Kurul Entegrasyonu*/
    EStatusNotRepCommitteeApplicationType: TTVisual.ITTEnumComboBox;  //Müracaat Tipi ( E-Durum Bildirir Kurul )

    /*E-Durum Bildirir Kurul Entegrasyonu*/

    public tedaviTuruArray: Array<any> = [];
    public provizyonTipiArray: Array<any> = [];
    public tedaviTipiArray: Array<any> = [];
    public takipTipiArray: Array<any> = [];
    public bransArray: Array<any> = [];

    public devredilenKurumArray: Array<any> = [];
    public istisnaiHalArray: Array<any> = [];
    public sigortaliTuruArray: Array<any> = [];
    public ozelDurumArray: Array<any> = [];
    public kesiArray: Array<any> = [];

    public ilacArray: Array<any> = [];
    public readProvisionResultArray: Array<TakipDVO> = [];

    public controls = [];
    public PatientInfoUIComponents = [];
    private PatientAdmissionUICompoents: Map<string, any>;
    public formOpenPayerType: number;

    public globalPatientAdmissionObjectID: any;
    public loadEmergenyDepartmentsOnly: Boolean = false;
    public HCPoliclinicList = Array<ResPoliclinic>();
    public ResultSetList = null;
    public globalSepCount: any;
    public globalUniqueRefNo: number;
    public globalLastDepartment: ResDepartment;
    public globalLastPoliclinic: ResPoliclinic;
    public globalLastProcedureDoctor: ResUser;
    public FilterPoliclinicId: ResPoliclinic;

    buildingObjectID: Guid;
    loadingVisible: boolean = false;
    panelMessage: string = "Kaydediliyor...";
    public showPopupCompareForm: boolean = false;
    public showProcedurePopup: boolean = false;
    public showProcedurePopupBtn: boolean = false;
    public showBagliTakipAlPopup = false;
    public showProvisionPopup = false;
    public showMedulaExtraProvisionPopup = false;
    public babyMotherName: string = "";
    public _patientNumber: string = "";
    public _protocolNo: string = "";
    public MedulaExtraProvisionInfo: FazlaTakipBilgileriDTO = new FazlaTakipBilgileriDTO();
    public stringPatientAge: string = "";

    /**EPİKRİZ BEG�N */
    public PatientOldInpatients: Array<EpicrisisReport_Class> = new Array<EpicrisisReport_Class>();
    public EpicrisisDoctorList: Array<ResUser> = new Array<ResUser>();
    public ReportSelectedDoctor: ResUser = new ResUser();
    public selectedOldInpatient: Guid = new Guid();
    public epicrisisReportVisible = false;
    /**EP�KR�Z END */

    /** ACİL BİRLEŞTİRME EKRANI BEGİN */
    public emergencyPolList: Array<ResPoliclinic> = new Array<ResPoliclinic>();
    public emergencyDoctorList: Array<ResUser> = new Array<ResUser>();
    public ShowEmergencyMerge: boolean = false;
    /** ACİL BİRLEŞTİRME EKRANI END */

    /** ACİL TRİAJ EKRANI BEGİN */
    public triageList: Array<ShortHcInfo> = new Array<ShortHcInfo>();
    public ShowEmergencyTriage: boolean = false;
    public _selectedTriageInfo = null;
    /** ACİL TRİAJ EKRANI END */

    /** ACİL MUAYENE BARKOD SEÇİM EKRANI BEGİN */
    public barcodeList: Array<string> = new Array<string>();
    public ShowEmergencyBarcode: boolean = false;
    public _selectedBarcodeInfo : string = null;
    /** ACİL MUAYENE BARKOD SEÇİM END */

    public showYupasBelgeListesi = false;
    public yupasBelgeListesi: Array<YurtDisiYardimHakki> = new Array<YurtDisiYardimHakki>();
    public _selectedYupasBelge: number;
    @ViewChild('btnEvet') btnEvet: DxButtonComponent;
    @ViewChild('btnHayir') btnHayir: DxButtonComponent;

    public bransDisabled = false;//Alınan kabullerin bransı değiştirilemeyecek.(En azından şimdilik)
    public canPrintHCBarkod = true;//Sadece ilk kabul alınırken hepsini bassın veya yardımcı menuden gelirken bassın

    requirementExecutor: RequirementExecutor = new RequirementExecutor();
    requirementsResultCode: RequirementResultCode = new RequirementResultCode();

    public _historyPatientAdmission: Array<SubEpisodeProtocol.GetPaBySearchPatient_Class> = new Array<SubEpisodeProtocol.GetPaBySearchPatient_Class>();
    public _patientAdmissionList: Array<PatientAdmissionListModel> = new Array<PatientAdmissionListModel>();

    public get _PatientAdmission(): PatientAdmission {
        return this._TTObject as PatientAdmission;
    }
    private PatientAdmissionForm_DocumentUrl: string = '/api/PatientAdmissionService/PatientAdmissionFormPreLoad';
    public _EmptyDocumentUrl: string = '/api/PatientAdmissionService/PatientAdmissionEmptyForm';


    async patientChanged(patient: any) {

        let that = this;
        if (!that.patientAdmissionFormViewModel.Patients) {
            that.patientAdmissionFormViewModel.Patients = new Array<Patient>();
        }
        that.patientAdmissionFormViewModel.Patients[0] = patient;
        // this.patientAdmissionFormViewModel.tempPoliclinic =that.globalLastPoliclinic;
        // this.patientAdmissionFormViewModel.tempProcedureDoctor = that.globalLastProcedureDoctor;
        await this.updateAvatarPhoto(patient);
        await this.LoadPatientAdmission(that.patientAdmissionFormViewModel.Patients[0], false);
        await this.updateRequiredColors();

        if (patient != null && patient.UniqueRefNo != null) {
            this.enableUndefinedPatient = false;
            this.globalUniqueRefNo = patient.UniqueRefNo;
        }

    }

    private updateAvatarPhoto(Patient: any): void {

        if (Patient != null) {

            if (this.isIncludeValue(Patient.UniqueRefNo) == true) {
                this.imageSource = "../../Content/PatientAdmission/" + Patient.UniqueRefNo + ".jpg";
            }
            else if (Patient.Sex != null) {
                if (Patient.Sex.ADI === "ERKEK")
                    this.imageSource = "../../Content/PatientAdmission/avatar_men.png";
                else
                    this.imageSource = "../../Content/PatientAdmission/avatar_women.png";
            }
            else {
                this.imageSource = "../../Content/PatientAdmission/avatar_unknown.png";
            }
        }
        else {
            this.imageSource = "../../Content/PatientAdmission/avatar_unknown.png";
        }

    }
    patientAdmissionChanged(patientAdmission: PatientAdmission) {
        let that = this;
        that.patientAdmissionFormViewModel._PatientAdmission = patientAdmission;

    }

    openMernisInfoCompare() {
        if (this.patientAdmissionFormViewModel.CheckMernisRole == true) {
            //if (this.patientAdmissionFormViewModel.MernisPatientModel == null) {
            //    ServiceLocator.MessageService.showInfo("Mernis sunucusundan veri gelmediği için bu ekranı kullanamazsınız...");
            //    return;
            //}
            this.showPopupCompareForm = true;

        }
        else {
            ServiceLocator.MessageService.showInfo(i18n("M12085", "Bu işlemi yapmak için yetkiniz bulunmamaktadır."));
        }
    }

    constructor(private sideBarMenuService: ISidebarMenuService, private datePipe: DatePipe
        , protected httpService: NeHttpService, private barcodePrintService: IBarcodePrintService
        , protected messageService: MessageService, protected modalService: IModalService
        , private medulaDefinition: GetMedulaDefinitionService
        , protected helpMenuService: HelpMenuService
        , private objectContextService: ObjectContextService
        , private activeEpisodeActionService: IActiveEpisodeActionService
        , protected reportService: AtlasReportService
        , protected ngZone: NgZone
        , private renderer: Renderer2) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = '/api/PatientAdmissionService/PatientAdmissionForm';
        this.initViewModel();
        this.initFormControls();
        this.AllPatientAdmissions = true;
        this.EndDate = new Date();
        this.EndDate = Convert.ToDateTime(Convert.ToDateTime(this.EndDate).ToShortDateString() + " 23:59:59");
        this.StartDate = new Date();
        this.StartDate = Convert.ToDateTime(Convert.ToDateTime(this.StartDate).ToShortDateString() + " 00:00:00");
        this._patientNumber = "";
        this._protocolNo = "";

    }
    private updateHomeAddress(address: PatientIdentityAndAddress): void {

        let result: string = "";
        if (address != null && address != undefined) {

            if (address.SKRSMahalleKodlari != null && address.SKRSMahalleKodlari != undefined) {
                result += " " + address.SKRSMahalleKodlari.ADI;
            }

            if (address.BuildingBlockName != null && address.BuildingBlockName != undefined) {
                result += " " + address.BuildingBlockName;
            }
            if (address.DisKapi != null && address.DisKapi != undefined) {
                result += " BLOK NO:" + address.DisKapi;
            }
            if (address.IcKapi != null && address.IcKapi != undefined) {
                result += " İÇ KAPI NO:" + address.IcKapi;
            }
            if (address.HomePostcode != null && address.HomePostcode != undefined) {
                result += " " + address.HomePostcode;
            }
            if (address.HomePhone != null && address.HomePhone != undefined) {
                result += " " + address.HomePhone;
            }

            if (address.SKRSKoyKodlari != null && address.SKRSKoyKodlari != undefined) {
                result += " " + address.SKRSKoyKodlari.ADI;
            }

            if (address.SKRSIlceKodlari != null && address.SKRSIlceKodlari != undefined) {
                result += " " + address.SKRSIlceKodlari.ADI;
            }

            if (address.SKRSILKodlari != null && address.SKRSILKodlari != undefined) {
                result += " /" + address.SKRSILKodlari.ADI;
            }

        }
        this._PatientAdmission.PA_Address.HomeAddress = result;
    }

    public patientAddress(): any {


        let componentInfo = new DynamicComponentInfo();
        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Width = 800;
        modalInfo.Height = 500;
        modalInfo.Title = i18n("M15138", "Hasta Adresi");

        componentInfo.ComponentName = "PatientAddressComponent";
        componentInfo.ModuleName = "CoreModule";
        componentInfo.ModulePath = "/app/Fw/CoreModule";
        componentInfo.InputParam = new DynamicComponentInputParam("", null);

        if (this._PatientAdmission != null) {
            if (this._PatientAdmission.PA_Address != null) {

                componentInfo.InputParam = this._PatientAdmission.PA_Address;
                let patientName: string = "";
                if (this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.FullName != undefined) {
                    patientName = this._PatientAdmission.Episode.Patient.FullName + " ";
                }
                modalInfo.Title = patientName + i18n("M10545", "Adres Bilgileri");
            }
        }
        let that = this;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                let modalActionResult: any = res.Param;
                if (modalActionResult != undefined && modalActionResult == 1) {
                    if (that._PatientAdmission != null)
                        if (that._PatientAdmission.PA_Address != null) {
                            that._PatientAdmission.PA_Address = modalActionResult;
                            that.updateHomeAddress(that._PatientAdmission.PA_Address);
                        }
                }
            })
                .catch(err => {
                    reject(err);
                });
        });

        return promise;
    }

    public isNationalityTR(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.Episode == null)
            return 0;
        if (this._PatientAdmission.Episode.Patient == null)
            return 0;
        if (this._PatientAdmission.Episode.Patient.Nationality == null)
            return 1;
        if (this._PatientAdmission.Episode.Patient.Nationality.Kodu.Equals("TR") == true)
            return 1;

        return 0;
    }

    public isNationalityNotTR(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.Episode == null)
            return 0;
        if (this._PatientAdmission.Episode.Patient == null)
            return 0;
        if (this._PatientAdmission.Episode.Patient.Nationality == null)
            return 0;
        if (this._PatientAdmission.Episode.Patient.Nationality.Kodu.Equals("TR") == false)
            return 1;

        return 0;
    }

    public isExceptionalState(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.AdmissionType == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu.Equals("S") == true)
            return 1;

        return 0;
    }

    public isMedulaVakaTarihi(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.AdmissionType == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu.Equals("I") == true)
            return 1;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu.Equals("T") == true)
            return 1;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu.Equals("V") == true)
            return 1;
        return 0;
    }

    public isSKRSAdliVaka(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.AdmissionType == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu.Equals("V") == true)
            return 1;

        return 0;
    }
    public isTriageCode(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.AdmissionType == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu == null)
            return 0;
        // if (this._PatientAdmission.AdmissionType.provizyonTipiKodu.Equals("A") == true && this.patientAdmissionFormViewModel.HasTriageArea == true)
        //     return 1;
        if (this._PatientAdmission.Department == null)
            return 0;
        if (this._PatientAdmission.Department.IsEmergencyDepartment == true && this.patientAdmissionFormViewModel.HasTriageArea == true)
            return 1;

        return 0;
    }

    public is112Emergency(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.AdmissionType == null)
            return 0;
        if (this._PatientAdmission.Department == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu == null)
            return 0;
        // if (this._PatientAdmission.AdmissionType.provizyonTipiKodu.Equals("A") == true)
        //     return 1;
        if (this._PatientAdmission.Department.IsEmergencyDepartment == true)
            return 1;

        return 0;
    }

    public isKurumSevk(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.AdmissionType == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu.Equals("K") == true)
            return 1;            

        return 0;
    }

    public isTrafficAccident(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.AdmissionType == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu == null)
            return 0;
        if (this._PatientAdmission.AdmissionType.provizyonTipiKodu.Equals("T") == true)
            return 1;

        return 0;
    }
    public isRehabilitationApplication(): Number {
        if (this.patientAdmissionFormViewModel == null)
            return 0;
        if (this.patientAdmissionFormViewModel.RehabilitationApplication == null)
            return 0;
        if (this.patientAdmissionFormViewModel.RehabilitationApplication == false)
            return 0;
        if (this.patientAdmissionFormViewModel.RehabilitationApplication == true)
            return 1;

        return 0;
    }
    public isForeign(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.Episode.Patient == null)
            return 0;
        if (this._PatientAdmission.Episode.Patient.Foreign == null)
            return 0;
        if (this._PatientAdmission.Episode.Patient.Foreign == true)
            return 1;
        return 0;
    }

    public hasBuilding(): Number {
        if (this.patientAdmissionFormViewModel == null)
            return 0;
        if (this.patientAdmissionFormViewModel.HasBuilding == null)
            return 0;
        if (this.patientAdmissionFormViewModel.HasBuilding == false)
            return 0;
        if (this.patientAdmissionFormViewModel.HasBuilding == true)
            return 1;
        return 0;
    }


    public hasGizliHastaKabulRole(): Number {
        if (this.patientAdmissionFormViewModel == null)
            return 0;
        if (this.patientAdmissionFormViewModel.GizliHastaKabulRole == null)
            return 0;
        if (this.patientAdmissionFormViewModel.GizliHastaKabulRole == false)
            return 0;
        if (this.patientAdmissionFormViewModel.GizliHastaKabulRole == true)
            return 1;

        return 0;
    }

    public isPrivacy(): Number {
        if (this._PatientAdmission.Episode.Patient != null) {
            if (this._PatientAdmission.Episode.Patient.Privacy == true) {
                this.pPrivacyName.ReadOnly = false;
                this.pPrivacySurname.ReadOnly = false;
                this.pPrivacyReason.ReadOnly = false;
                this.pPrivacyEndDate.ReadOnly = false;
                this.pPrivacyEndDate.Enabled = true;
            }
            else {
                this.pPrivacyName.ReadOnly = true;
                this.pPrivacySurname.ReadOnly = true;
                this.pPrivacyReason.ReadOnly = true;
                this.pPrivacyEndDate.ReadOnly = true;
                this.pPrivacyEndDate.Enabled = false;

                this.patientAdmissionFormViewModel.tempPrivacyName = null;
                this.patientAdmissionFormViewModel.tempPrivacySurname = null;
                this._PatientAdmission.Episode.Patient.PrivacyReason = null;
                this._PatientAdmission.Episode.Patient.PrivacyEndDate = null;
            }
        }
        return 1;
    }

    public hasDispatchEmergencyCons(): Number {
        if (this._PatientAdmission == null)
            return 0;
        if (this._PatientAdmission.DispatchType == null)
            return 0;
        if (this._PatientAdmission.DispatchType == DispatchTypeEnum.DispatchedProcedure)
            return 0;
        if (this._PatientAdmission.DispatchType == DispatchTypeEnum.Consultation)
            return 1;

        return 0;
    }

    public shortCut_() {
        TTVisual.InfoBox.Alert(i18n("M17533", "Kısa Yol Davranışları 18 Ocakta Tamamlanacaktır..."));
    }

    public async PatientHistoryListView_Click(val: any): Promise<void> {

        this.loadingVisible = true;
        this.panelMessage = "Kayıt yükleniyor..."

        if (val.currentSelectedRowKeys.length > 0 && val.currentSelectedRowKeys[0].Fromse == 1) {
            val.component.deselectRows(val.currentSelectedRowKeys[0]);
        }
        else if (val.currentSelectedRowKeys.length > 0 && val.currentSelectedRowKeys[0].Fromse != 1) {
            let data = val.currentSelectedRowKeys[0].ObjectID;
            this.ObjectID = new Guid(data);

            await this.load(PatientAdmissionFormViewModel, this.PatientAdmissionForm_DocumentUrl);
            await this.MedulaErrorValidator();
            await this.SetTriageColor(this.patientAdmissionFormViewModel._PatientAdmission.Triage);
            await this.SetAdmissionPropertiesEnabled();

            this.patientAdmissionFormViewModel.SEPCount = this.globalSepCount;

            if (this.patientAdmissionFormViewModel._PatientAdmission.ImportantPAInfo !== undefined && this.patientAdmissionFormViewModel._PatientAdmission.ImportantPAInfo != "")
                TTVisual.InfoBox.Alert(this.patientAdmissionFormViewModel._PatientAdmission.ImportantPAInfo.toString());
        }
        this.AddHelpMenu();

        this.loadingVisible = false;
    }
    public async MedulaErrorValidator(): Promise<void> {

        if (this.patientAdmissionFormViewModel.SubEpisodeProtocol != null && this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaSonucKodu != null &&
            this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaSonucKodu != "0000" && this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaSonucMesaji != null)
            this.medulaTakipNo.BackColor = "#fdcdcd";
        else
            this.medulaTakipNo.BackColor = "#F0F0F0";
    }

    public PatientAdmissionColumns =
        [
            {
                caption: i18n("M10498", "Ad Soyad"),
                dataField: 'Date'
            },
            {
                caption: i18n("M17021", "Kabul No"),
                dataField: 'OperationType'
            },
            {
                caption: 'Tarih',
                dataField: 'Date'
            },
            {
                caption: 'Birim',
                dataField: 'ReceiptNo'
            }
        ];

    // ***** Method declarations start *****

    // BEGIN Minimize Kabul Alma Formu

    minimizeForm: boolean = false;
    @Input() set MinimizeForm(value: boolean) {
        this.minimizeForm = value;
    }

    private _patient: Patient;
    @Input() set Patient(value: Patient) {
        this._patient = value;
        if (this._patient) {
            this.patientChanged(this.patient);
        }
    }
    get patient(): Patient {
        return this._patient;
    }

    isNewbornRequired: boolean = false;
    public setInputParam(value: any) {
        if (value != null && value['MinimizeForm'] != null) {
            this.minimizeForm = value['MinimizeForm'];
        }

        if (value != null && value['IsNewbornRequired'] != null) {
            this.isNewbornRequired = value['IsNewbornRequired'];
        }

        if (value != null && value['Patient'] != null) {
            if (typeof value['Patient'] == "string") {
                this.objectContextService.getObject<Patient>(new Guid(value['Patient']), new Guid('54d381eb-0ea3-4021-a400-4c1dda89ab37')).then(result => {
                    this._patient = result as Patient;

                    if (this._patient) {
                        this.patientChanged(this.patient);
                    }
                });
            } else {
                this._patient = value['Patient'];

                if (this._patient) {
                    this.patientChanged(this.patient);
                }
            }
        }
    }
    // END Minimize Kabul Alma Formu


    private async ArrangeWarVeteraCardNo(): Promise<void> {

    }
    private async AskAndFireNewPatientAdmission(patient: Patient): Promise<PatientAdmission> {
        return PatientAdmissionForm.FireNewPatientAdmission(patient, null, null, this._PatientAdmission.Episode.Patient.MyAdmissionAppointment);
    }
    public async BaseHomeCountry_SelectedObjectChanged(): Promise<void> {

    }



    public async btnClearPatientListPanel_Click(): Promise<void> {

        this.StartDate = new Date();
        this.StartDate = Convert.ToDateTime(Convert.ToDateTime(this.StartDate).ToShortDateString() + " 00:00:00");

        this.EndDate = new Date();
        this.EndDate = Convert.ToDateTime(Convert.ToDateTime(this.EndDate).ToShortDateString() + " 23:59:59");

        this.FilterPoliclinicId = null;

        this.SearchList_Click();
    }
    public async btnDetailedSearch_Click()//Detaylı Arama: Promise<void>
    {

    }
    public async btnProcedureSave_Click() {

    }
    public async CheckIsDiagnosisExists(DiagnosisGridList: DiagnosisGrid[]) {
        if (DiagnosisGridList) {
            if (DiagnosisGridList.filter(dr => dr.RemoveSubEpisodeRelation != true).length < 1) {
                throw new TTException(await SystemMessageService.GetMessage(635));
            }
        } else {
            throw new TTException(await SystemMessageService.GetMessage(635));
        }
    }

    public PayerTransferWarningOkClick() {
        this.showPayerTransferWarning = false;
    }

    public async btnPatientAdmissionSave_Click()//Arşiv + Kabul Kaydı: Promise<void>
    {
        let patientInfoRequirements: PatientInfoRequirements = new PatientInfoRequirements(this._PatientAdmission.Episode.Patient, this.patientAdmissionFormViewModel.tempName, this.patientAdmissionFormViewModel.tempSurname, this.PatientAdmissionUICompoents);

        let patientAdmissionRequirements: PatientAdmissionRequirements = new PatientAdmissionRequirements(this._PatientAdmission, this.patientAdmissionFormViewModel, this.patientAdmissionFormViewModel.tempUniqueRefNo, this.PatientAdmissionUICompoents);

        this.requirementExecutor.addRequirement(patientInfoRequirements);
        this.requirementExecutor.addRequirement(patientAdmissionRequirements);

        if (this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.UnIdentified != true && this.pPrivacy.Value != true && this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.Death != true) {
            let patientAddressRequirements: PatientAddressRequirements = new PatientAddressRequirements(this.patientAdmissionFormViewModel, this.PatientAdmissionUICompoents);
            this.requirementExecutor.addRequirement(patientAddressRequirements);
        }

        this.requirementsResultCode = this.requirementExecutor.Execute();
        this.requirementExecutor.clearAllRequirements();

        if (this.requirementsResultCode.resultCode > 0) {

            ServiceLocator.MessageService.showError(this.requirementsResultCode.resultMessage);
        }
        else if (this.requirementsResultCode.resultCode == 0) {

            try {

                if (this.isNewbornRequired && this._PatientAdmission.IsNewBorn != true)
                    throw new TTException("Lütfen kayıt işlemini tamamlamadan önce yenidoğan alanını işaretleyip anne-bebek eşleştimesini yaptığınızdan emin olunuz.");

                this.loadingVisible = true;
                this.globalPatientAdmissionObjectID = this.patientAdmissionFormViewModel._PatientAdmission.ObjectID;

                this.SetPatientDetailedInfo();

                if (this.patientAdmissionFormViewModel.HistoryPatientAdmission != null)
                    this.patientAdmissionFormViewModel.HistoryPatientAdmission.Clear();

                if (this.patientAdmissionFormViewModel.getLastSelectedDoctorandPoliclinic) {
                    this.globalLastPoliclinic = this.patientAdmissionFormViewModel.tempPoliclinic;
                    this.globalLastProcedureDoctor = this.patientAdmissionFormViewModel.tempProcedureDoctor;
                }

                if (this.patientAdmissionFormViewModel.activeTab == 3 && this.patientAdmissionFormViewModel.ControlPreviousHcExam && this.patientAdmissionFormViewModel._PatientAdmission.IsNew) {
                    let fullApiUrl = '/api/PatientAdmissionService/HasSameReceptionForSameReason/?Reason=' + this.patientAdmissionFormViewModel._PatientAdmission.HCRequestReason.ObjectID + '&PatientID=' + this._PatientAdmission.Episode.Patient.ObjectID;
                    let hasAdmission = await this.httpService.get<any>(fullApiUrl); // await this.hasSameReceptionForSameReason()

                    if (hasAdmission)
                        throw new TTException(this.patientAdmissionFormViewModel.HCControlDayLimit + " içinde aynı rapor nedeni ile alınmış bir kabul mevcut olduğu için tekrar kabul alamazsınız.");

                    fullApiUrl = '/api/PatientAdmissionService/ControlHCAutoProcedures/?Reason=' + this.patientAdmissionFormViewModel._PatientAdmission.HCRequestReason.ReasonForExamination.ObjectID;
                    let ProcedureNames = await this.httpService.get<any>(fullApiUrl);

                    if (ProcedureNames != "") {
                        let result: string = await ShowBox.Show(1, '&Evet,&Hayır', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", ProcedureNames + " isimli tetkik / Tahlillerin otomatik olarak sisteme eklenmesini ister misiniz?. ", 1,true);
                        // throw new TTException("AHOYYY");

                        this.patientAdmissionFormViewModel.AddProcedureToHC = false;
                        if (result === "OK") {
                            this.patientAdmissionFormViewModel.AddProcedureToHC = true;
                        }

                    }
                }

                try {
                    this._ViewModel.AppointmentList = new Array<any>();
                    this.AppointmentlistView.Items = new Array<any>();
                    await this.ClientSidePostScript(null);
                    await this.PostScript(null);
                    let injector = ServiceLocator.Injector;
                    let messageService: MessageService = injector.get(MessageService);
                    let httpService: NeHttpService = ServiceLocator.NeHttpService;
                    this.ResultSetList = await httpService.post(this._DocumentServiceUrl, this._ViewModel, PatientAdmissionFormViewModel);
                    this.globalPatientAdmissionObjectID = this.ResultSetList.ObjectID;
                    if (this.ResultSetList.MedulaErrorMessage == "ProvisionError") {
                        let message: string;
                        message = "Hastaya provizyon alınamamıştır.\n Medula hata : " + this.ResultSetList.Message;
                        this.loadingVisible = false;
                        await this.getMessage(message);
                    }
                    else {

                        if (this.ResultSetList.medulaTransferredPayerWarningDTO != null && !String.isNullOrEmpty(this.ResultSetList.medulaTransferredPayerWarningDTO.DevredilenKurumAdi)) {
                            this.showPayerTransferWarning = true;
                        }

                        await this.AfterContextSavedScript(null);

                        await this.loadPAByID(new Guid(this.globalPatientAdmissionObjectID));
                        await this.LoadPatientAdmissionHistory(this.patientAdmissionFormViewModel.HistoryPatientAdmission, false);

                        if (this.patientAdmissionFormViewModel._PatientAdmission.AdmissionStatus != AdmissionStatusEnum.HizmetProtokol)
                            this.showSaveSuccessMessage();

                        this.printBarcode();

                        this.loadingVisible = false;
                        await this.MedulaErrorValidator();

                        this.ControlHastaTemasDurumu();

                        this.SearchList_Click();
                        //this.patientAdmissionFormViewModel.SEPCount = this.globalSepCount;
                    }
                }
                catch (err) {
                    this.loadingVisible = false;
                    console.log(err);
                    ServiceLocator.MessageService.showError(err);
                }
                let a = 0;
            }
            catch (ex) {
                this.loadingVisible = false;
                ServiceLocator.MessageService.showError(ex);
            }
        }

    }
    public async AfterSavefunctions() {
        await this.AfterContextSavedScript(null);
        await this.loadPAByID(new Guid(this.globalPatientAdmissionObjectID));
        await this.LoadPatientAdmissionHistory(this.patientAdmissionFormViewModel.HistoryPatientAdmission, false);

        this.ControlHastaTemasDurumu();

        this.loadingVisible = false;
        await this.MedulaErrorValidator();
        this.AddHelpMenu();
    }

    public async hasSameReceptionForSameReason() {
    }

    public async getMessage(message: string) {
        let buttonText: string = "&Provizyonsuz Devam Et,&Kabul Sil,&Ücretli Kabul Al";
        let buttonResult: string = "T,V,H";
        if (message.indexOf("1108") > 0) {
            buttonText = "&Provizyonsuz Devam Et,&Ücretli Kabul Al, &Prim Borçlu Kabul Al";
            buttonResult = "T,H,P";
        }
        let result: string = "";
        if (message.indexOf("1108") > 0)
            result = await ShowBox.FourShow(ShowBoxTypeEnum.Message, buttonText, buttonResult, i18n("M23735", "Uyarı"), i18n("M20577", "Provizyon Hata"), message, 1);
        else
            result = await ShowBox.TreeShow(ShowBoxTypeEnum.Message, buttonText, buttonResult, i18n("M23735", "Uyarı"), i18n("M20577", "Provizyon Hata"), message, 1);

        if (result === "H") {
            await this.AfterSavefunctions();
            this.patientAdmissionFormViewModel.GetProvisionFromMedula = false;

            if (this.isNationalityNotTR() == 1) {
                if (this.patientAdmissionFormViewModel.HealthTourismPayerDefinition != null)
                    this.patientAdmissionFormViewModel.tempPayer = this.patientAdmissionFormViewModel.HealthTourismPayerDefinition;
            }
            else {
                if (this.patientAdmissionFormViewModel.PaidPayerDefinition != null)
                    this.patientAdmissionFormViewModel.tempPayer = this.patientAdmissionFormViewModel.PaidPayerDefinition;
            }

            await this.btnPatientAdmissionSave_Click();
            this.showSaveSuccessMessage();
        }
        else if (result === "T") {
            await this.AfterSavefunctions();
            this.showSaveSuccessMessage();
            await this.SearchList_Click();
        }
        else if (result === "V") {
            await this.AfterSavefunctions();
            await this.onClickShowDeletePatientAdmission();
            await this.SearchList_Click();
            this.showSaveSuccessMessage();
        }
        else if (result === "P") {
            await this.AfterSavefunctions();
            this.patientAdmissionFormViewModel._PatientAdmission.AdmissionType = this.provizyonTipiArray.find(x => x.Code == 'S');
            //this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaProvizyonTipi = this.provizyonTipiArray.find(x => x.provizyonTipiKodu == 'S');
            this.patientAdmissionFormViewModel._PatientAdmission.MedulaIstisnaiHal = this.istisnaiHalArray.find(x => x.Code == '9');
            //this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaIstisnaiHal = this.istisnaiHalArray.find(x => x.Kodu == '9');
            this.btnPatientAdmissionSave_Click();
        }

        this.printBarcode();

        this.AddHelpMenu();

        if(result != "V" && this.patientAdmissionFormViewModel.activeTab == 1)
        {
            if (this.patientAdmissionFormViewModel.PrintMedulaCodeReport)
                this.printMedulaProvisionReport(this._PatientAdmission.ObjectID);
        }
    }

    /*onShown() {
        setTimeout(() => {
            this.loadingVisible = false;
        }, 3000);
    }*/

    public async btnPatientAdmissionNewSave_Click()//Yeni Kabul
    {
        if (this.patientAdmissionFormViewModel.Patients.length > 0) {
            let patient = this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient;
            this.globalPatientAdmissionObjectID = null;
            this.PatientHistoryListView.Items = new Array<any>();
            this._historyPatientAdmission = new Array<SubEpisodeProtocol.GetPaBySearchPatient_Class>();
            this.PatientlistView.Items = new Array<any>();
            this._patientAdmissionList = new Array<PatientAdmissionListModel>();
            this.AppointmentlistView.Items = new Array<any>();

            await this.initViewModel();

            await this.onInitialize();

            await this.patientChanged(patient);

            this.patientAdmissionFormViewModel.SEPCount = this.globalSepCount;
        }
        else {
            this.btnPatientAdmissionClear_Click();
        }
    }
    public async btnPatientAdmissionClear_Click() {
        this.globalPatientAdmissionObjectID = null;
        this.PatientHistoryListView.Items = new Array<any>();
        this._historyPatientAdmission = new Array<SubEpisodeProtocol.GetPaBySearchPatient_Class>();
        this.PatientlistView.Items = new Array<any>();
        this._patientAdmissionList = new Array<PatientAdmissionListModel>();
        this.AppointmentlistView.Items = new Array<any>();
        this.enableUndefinedPatient = true;

        await this.initViewModel();
        await this.patientSearchAuto.Clear();
        await this.onInitialize();

        //  this.PatientlistView.SelectedItems = null;
    }

    public async SearchList_Click(): Promise<void> {

    /*    if (this.patientAdmissionFormViewModel.IsSuperUser == true) {
            if (this.SearchListWithoutProvision.Value == true) {
                this.patientPatientAdmission = (await SubEpisodeProtocolService.GetPAInfoByDateWithoutProvision(this.StartDate, this.EndDate));
            }
            else if (this.SearchListWithProvision.Value == true) {
                this.patientPatientAdmission = (await SubEpisodeProtocolService.GetPAInfoByDateWithProvision(this.StartDate, this.EndDate));
            }
            else
                this.patientPatientAdmission = (await SubEpisodeProtocolService.GetAllPatientInfoByDateWithoutUser(this.StartDate, this.EndDate));
        }
        else {
            if (this.SearchListWithoutProvision.Value == true) {
                this.patientPatientAdmission = (await SubEpisodeProtocolService.GetPAInfoByDateWithoutProvision(this.StartDate, this.EndDate));
            }
            else if (this.SearchListWithProvision.Value == true) {
                this.patientPatientAdmission = (await SubEpisodeProtocolService.GetPAInfoByDateWithProvision(this.StartDate, this.EndDate));
            }
            else
                this.patientPatientAdmission = (await SubEpisodeProtocolService.GetAllPatientInfoByDate(this.StartDate, this.EndDate));
        }*/
        // if (this.patientPatientAdmission.length > 0 && this.FilterPoliclinicId != null) {
        //     let filterPol = this.patientAdmissionFormViewModel.PoliclinicListForFilter.find(o => o.ObjectID.toString() === this.FilterPoliclinicId.toString());

        //     if (filterPol != null)
        //         this.patientPatientAdmission = this.patientPatientAdmission.filter(dr => dr.Policlinic == filterPol.Name);
        // }

        // this.LoadPatientListView(this.patientPatientAdmission);
        await this.leftSideGridDataSource.reload();
    }

    public onSearchListWithoutProvision(event): void {
        if (event)
            this.SearchListWithProvision.Value = false;
    }

    public onSearchListWithProvision(event): void {
        if (event)
            this.SearchListWithoutProvision.Value = false;
    }

    public async btnSorgula_Click(): Promise<void> {

        this.initViewModel();

        if (!String.isNullOrEmpty(this.SearchPatient.Text)) {
            this.LoadPatientAdmissionHistory(this.patientAdmissionFormViewModel.HistoryPatientAdmission, true);
            this.AddHelpMenu();
        }
    }

    public async LoadPatientAdmission(patient: Patient, fromVerifiedKPSBtn: Boolean) {

        try {
            let that = this;
            this.initViewModel();
            if (patient != null) {

                let apiUrl = '/api/PatientAdmissionService/PatientAdmissionFormLoad';

                // if (fromVerifiedKPSBtn) {
                //     apiUrl = '/api/PatientAdmissionService/PatientAdmissionFormLoadFromKPSButton';
                //     that.loadingVisible = true;
                //     that.panelMessage = "Mernis Bilgileri Sorgulanıyor.";
                // }
                let result = await this.httpService.post(apiUrl, patient, PatientAdmissionFormViewModel);
                // that.loadingVisible = false;
                // that.panelMessage = "Kaydediliyor...";
                this._ViewModel = result;

                if (that._ViewModel.returnMessage != "") {
                    this.loadEmergenyDepartmentsOnly = true;
                }
                else {
                    this.loadEmergenyDepartmentsOnly = false;
                }

                await this.SetAdmissionPropertiesEnabled();

                if (that._ViewModel.AppointmentList != null) {
                    if (that._ViewModel.AppointmentList.length == 1) {
                        let message: string;
                        message = i18n("M15435", "Hastanın bugüne ait \'" + this._ViewModel.AppointmentListInfo[0].Masterresourcename + " Polikliniğine, "
                            + this._ViewModel.AppointmentListInfo[0].DoctorName + " doktoruna saat "
                            + this._ViewModel.AppointmentListInfo[0].AppTime + "\' randevusu bulunmuştur. Bu randevuyu görüntülemek ister misiniz?");
                        let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", message, 1);
                        if (result === "OK") {
                            let id = that._ViewModel.AppointmentList[0].Patient;
                            // let uniqueRefNo = patient.UniqueRefNo;
                            let appointmentID = that._ViewModel.AppointmentList[0].ObjectID;
                            let fullApiUrl = '/api/PatientAdmissionService/PatientAdmissionFormAppointmentLoad/?id=' + patient.ObjectID + '&uniqueRefNo=' + patient.UniqueRefNo + '&appointmentID=' + appointmentID;
                            let res = await this.httpService.get<PatientAdmissionFormViewModel>(fullApiUrl, PatientAdmissionFormViewModel);
                            that._ViewModel = res;

                            this.Building.Enabled = false;
                            this.Branch.Enabled = false;
                            this.Policlinic.Enabled = false;
                            this.ProcedureDoctor.Enabled = false;

                        }
                        await this.LoadPatientAdmissionModel(that._ViewModel);
                    }
                    else if (this._ViewModel.AppointmentList.length > 1) {
                        let message: string;
                        message = i18n("M15434", "Hastanın bugüne ait randevuları bulunmuştur.randevuları görüntülemek ister misiniz?");
                        let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), message, 1);
                        if (result === "OK") {
                            this.showAppointmentListPopup = true;
                            this.LoadAppointmentlistView(this._ViewModel.AppointmentListInfo);

                            this.Building.Enabled = false;
                            this.Branch.Enabled = false;
                            this.Policlinic.Enabled = false;
                            this.ProcedureDoctor.Enabled = false;
                        }
                        else {
                            await this.LoadPatientAdmissionModel(this._ViewModel);
                        }
                    }
                    else {
                        await this.LoadPatientAdmissionModel(this._ViewModel);
                    }
                }
                else {
                    await this.LoadPatientAdmissionModel(this._ViewModel);
                }

            }
        }
        catch (err) {
            this.loadingVisible = false;
            this.panelMessage = "Kaydediliyor...";
            console.error(err);
            ServiceLocator.MessageService.showError(err);
        }
    }
    private async LoadPatientAdmissionModel(viewModel: any): Promise<void> {
        this.LoadPatientAdmissionHistory(viewModel.HistoryPatientAdmission, true);
        this.loadViewModel();
        this.AddHelpMenu();
        await this.SetTriageColor(this.patientAdmissionFormViewModel._PatientAdmission.Triage);

        if (this.buildingObjectID != null) {

            let building = this.patientAdmissionFormViewModel.ResBuildings.find(o => o.ObjectID.toString() === this.buildingObjectID.toString());
            if (building != null) {
                if (this.loadEmergenyDepartmentsOnly) {
                    this.Branch.ListFilterExpression = " THIS.BUILDING= '" + building.ObjectID.toString() + "' AND IsEmergencyDepartment=1";
                    this.Policlinic.Enabled = false;
                    this.ProcedureDoctor.Enabled = false;
                }
                else {
                    this.Branch.ListFilterExpression = " THIS.BUILDING= '" + building.ObjectID.toString() + "'";
                }
            }
            else {
                this.Branch.ListFilterExpression = " ";
            }

            let input: InputModelForQueries = new InputModelForQueries();
            input.filter = " AND this.ISACTIVE = 1";
            if (this.Branch.ListFilterExpression !== " ")
                input.filter += " AND " + this.Branch.ListFilterExpression;

            // if(this.patientAdmissionFormViewModel.getRelatedResourceParam)
            //     input.filter += " AND THIS.OBJECTID IN("+this.patientAdmissionFormViewModel.relatedBransList+")";

            //  this.FillDataSources(input);
            this.FillDataSource(input, 1);

            //this.FillDataSource(input, this.departmentApi, this.DepartmentList);

            if (this.loadEmergenyDepartmentsOnly) {
                ServiceLocator.MessageService.showError(viewModel.returnMessage + i18n("M10037", "\nBorcu bulunan hastalara sadece 'Acil kabulü' yapılabilir."));

                let inputKlinik: InputModelForQueries = new InputModelForQueries();
                inputKlinik.filter = " AND this.Department.IsEmergencyDepartment = 1";
                this.FillDataSource(inputKlinik, 2);

                this.ProcedureDoctor.ListFilterExpression = " UserResources.Policlinic.Department.IsEmergencyDepartment = 1";
                let inputDoctor: InputModelForQueries = new InputModelForQueries();
                inputDoctor.filter = " AND this.ISACTIVE = 1" + " AND " + this.ProcedureDoctor.ListFilterExpression;
                this.FillDataSource(inputDoctor, 3);

            }

            if (viewModel.showPayerAlert)
                ServiceLocator.MessageService.showError(i18n("M15466", "Hastanın Kurum ve Çalışma Durumu bilgilerini kontrol ediniz."));

            if (this.patientAdmissionFormViewModel._PatientAdmission.IsNew && this.patientAdmissionFormViewModel.getLastSelectedDoctorandPoliclinic
                && (this.patientAdmissionFormViewModel.AppointmentList == null || this.patientAdmissionFormViewModel.AppointmentList.length == 0)) {
                this.patientAdmissionFormViewModel.tempPoliclinic = this.globalLastPoliclinic;
                this.patientAdmissionFormViewModel.tempProcedureDoctor = this.globalLastProcedureDoctor;
            }


        }
    }

    private async ChangeResource(): Promise<void> {

    }
    private async CloneObjectBasedOnInitialObject(): Promise<void> {
        if (this._PatientAdmission.AdmissionAppointment !== null) {
            let savePointGuid: Guid = this._PatientAdmission.ObjectContext.BeginSavePoint();
        }
    }

    private async HCRequestReason_SelectedObjectChanged(): Promise<void> {
        //   this._PatientAdmission.ResourcesToBeReferred.Clear();
        this.patientAdmissionFormViewModel.ResourcesToBeReferredList.Clear();
        if (this._PatientAdmission.HCRequestReason != null) {
            let apiUrlForReasonForExamination: string = '/api/PatientAdmissionService/GetHCRequestReasonDetails?requestReasonObjectID=' + this._PatientAdmission.HCRequestReason.ObjectID;
            let response = <GetHCRequestReasonDetailsResponse>await this.httpService.get(apiUrlForReasonForExamination, GetHCRequestReasonDetailsResponse);
            this.patientAdmissionFormViewModel.HCRequestReasonDetail = response.requestReasonDetail;

            //if (result.IsSuccess == false)
            //    ServiceLocator.MessageService.showError(result.Message);
            //else {
            //    this.patientAdmissionFormViewModel.HCRequestReasonDetail =  result.Result;
            if (this.patientAdmissionFormViewModel.HCRequestReasonDetail != null && this.patientAdmissionFormViewModel.HCRequestReasonDetail.ReasonForExaminationDefinition != null) {
                this.patientAdmissionFormViewModel._PatientAdmission.HCRequestReason.ReasonForExamination = this.patientAdmissionFormViewModel.HCRequestReasonDetail.ReasonForExaminationDefinition;
                if (this.patientAdmissionFormViewModel.HCRequestReasonDetail.HospitalsUnits != null && this.patientAdmissionFormViewModel.HCRequestReasonDetail.HospitalsUnits.length > 0) {
                    for (let hospitalsUnitsDef of this.patientAdmissionFormViewModel.HCRequestReasonDetail.HospitalsUnits) {
                        let patientAdmissionResourcesToBeReferred: PatientAdmissionResourcesToBeReferred = new PatientAdmissionResourcesToBeReferred(this._PatientAdmission.ObjectContext);
                        patientAdmissionResourcesToBeReferred.ProcedureDoctorToBeReferred = hospitalsUnitsDef.ProcedureDoctor;
                        patientAdmissionResourcesToBeReferred.Resource = hospitalsUnitsDef.Policlinic;
                        //todo bg
                        patientAdmissionResourcesToBeReferred.Speciality = hospitalsUnitsDef.Speciality;
                        patientAdmissionResourcesToBeReferred.AdmissionQueueNumber = hospitalsUnitsDef.AdmissionQueueNumber;
                        this.patientAdmissionFormViewModel.ResourcesToBeReferredList.push(patientAdmissionResourcesToBeReferred);
                        //this.patientAdmissionFormViewModel._PatientAdmission.ResourcesToBeReferred.push(patientAdmissionResourcesToBeReferred);
                    }
                }
            }

            if (response.reportTypeDefinition.IsDisabled == true) {
                this.selectedReportIsDisabled = true;
                this.patientAdmissionFormViewModel.EDisabledReports.Clear();
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport = new EDisabledReport();
                this.patientAdmissionFormViewModel.EStatusNotRepCommitteeObjs.Clear();
                this.patientAdmissionFormViewModel._PatientAdmission.EStatusNotRepCommitteeObj = null;
                this.patientAdmissionFormViewModel.EDisabledReports.unshift(this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport);
            } else {
                this.patientAdmissionFormViewModel.EStatusNotRepCommitteeObjs.Clear();
                this.patientAdmissionFormViewModel._PatientAdmission.EStatusNotRepCommitteeObj = new EStatusNotRepCommitteeObj();
                this.patientAdmissionFormViewModel.EDisabledReports.Clear();
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport = null;
                this.patientAdmissionFormViewModel.EStatusNotRepCommitteeObjs.unshift(this.patientAdmissionFormViewModel._PatientAdmission.EStatusNotRepCommitteeObj);

                this.selectedReportIsDisabled = false;
            }
            //}
        }
    }

    protected async loadPAByID(objectID: Guid) {
        try {

            this.initViewModel();

            let fullApiUrl: string = "";

            if (objectID != null) {
                fullApiUrl = this.PatientAdmissionForm_DocumentUrl + '/?id=' + objectID + '&loadAdmissions=true';
            }
            else {
                fullApiUrl = `${this.PatientAdmissionForm_DocumentUrl}/${Guid.Empty}`;
            }

            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<PatientAdmissionFormViewModel>(fullApiUrl, PatientAdmissionFormViewModel);
            this._ViewModel = response;

            if (this._ViewModel.returnMessage != "")
                TTVisual.InfoBox.Alert(this._ViewModel.returnMessage);
            //ServiceLocator.MessageService.showError(this._ViewModel.returnMessage);

            this.loadViewModel();

            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
            await this.SetAdmissionPropertiesEnabled();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    public async PatientlistView_Click(val: any): Promise<void> {

        this.loadingVisible = true;
        this.panelMessage = "Kayıt yükleniyor..."

        // if (val.currentSelectedRowKeys.length > 0 && val.currentSelectedRowKeys[0].Fromse == 1) {
        //     val.component.deselectRows(val.currentSelectedRowKeys[0]);
        // }
        // else if (val.currentSelectedRowKeys.length > 0 && val.currentSelectedRowKeys[0].Fromse != 1) {
            let data = val.currentSelectedRowKeys[0];
            this.ObjectID = new Guid(data);
            this.patientSearchAuto.Clear();
            await this.loadPAByID(new Guid(data));
            await this.LoadPatientAdmissionHistory(this.patientAdmissionFormViewModel.HistoryPatientAdmission, true);
            await this.MedulaErrorValidator();
            await this.patientSearchAuto.Clear();
            await this.SetTriageColor(this.patientAdmissionFormViewModel._PatientAdmission.Triage);
            await this.SetAdmissionPropertiesEnabled();

            this.patientAdmissionFormViewModel.SEPCount = this.globalSepCount;
        // }
        this.AddHelpMenu();

        this.loadingVisible = false;
    }

    private async SetAdmissionPropertiesEnabled(): Promise<void> {
        this.Building.Enabled = true;
        this.Branch.Enabled = true;
        this.Policlinic.Enabled = true;
        this.ProcedureDoctor.Enabled = true;
    }


    private async provizyonTipi_SelectedIndexChanged(): Promise<void> {
        if (this.AdmissionType.SelectedItem !== null && this.AdmissionType.SelectedItem.Value !== null && this.AdmissionType.SelectedItem.Value.Equals("T")) {
            this.plakaNo.Required = true;
        }
        else this.plakaNo.Required = false;
    }


    public onEducationStatusChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.EducationStatus != event) {
            this._PatientAdmission.Episode.Patient.EducationStatus = event;
        }

    }

    public onSKRSMaritalStatusChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.SKRSMaritalStatus != event) {
            this._PatientAdmission.Episode.Patient.SKRSMaritalStatus = event;
        }

    }

    public onSKRSOzurlulukDurumuChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.SKRSOzurlulukDurumu != event) {
            this._PatientAdmission.Episode.Patient.SKRSOzurlulukDurumu = event;
        }

    }

    public onOccupationChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.Occupation != event) {
            this._PatientAdmission.Episode.Patient.Occupation = event;
        }

    }
    public onEMailChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.EMail != event) {
            this._PatientAdmission.Episode.Patient.EMail = event;
        }
    }

    private async onSpecialStatusChanged(): Promise<void> {

    }

    private async SendFiredLaboratoryActions(): Promise<void> {
        for (let ea of this._PatientAdmission.FiredEpisodeActions) {
            if (ea instanceof LaboratoryRequest) {
                //  Cursor current = Cursor.Current;
                // Cursor.Current = Cursors.WaitCursor;
                try {
                    let labRequest: LaboratoryRequest = ea as LaboratoryRequest;
                    if (labRequest !== null && (labRequest.ID.Value !== undefined)) {
                        let sysparam: string = (await SystemParameterService.GetParameterValue("LABINTEGRATED", null));
                        if (sysparam === "TRUE") {
                            if (labRequest.IsRequestSent !== true) {
                                /*   let messageID: Guid = (await LaboratoryRequestService.SendToLabASync(labRequest)); //Entegrasyon için.
                                   let context: TTObjectContext = new TTObjectContext(false);
                                   let request: LaboratoryRequest = <LaboratoryRequest>context.GetObject(labRequest.ObjectID, "LaboratoryRequest");
                                   request.MessageID = messageID.toString();
                                   request.IsRequestSent = true;
                                   context.Save();*/
                            }
                        }
                    }
                }
                catch (ex) {
                    throw ex;
                }
                finally {

                }
            }
        }
    }
    private async tedaviTipi_SelectedIndexChanged(): Promise<void> {
        let tedaviTipiList: Array<string> = new Array<string>();
        tedaviTipiList.push("13");
        tedaviTipiList.push("20");
        tedaviTipiList.push("9");
        let disBransKodlari: Array<string> = new Array<string>();
        disBransKodlari.push("5100");
        disBransKodlari.push("5150");
        disBransKodlari.push("5700");
        disBransKodlari.push("5400");
        disBransKodlari.push("5300");
        disBransKodlari.push("5500");
        disBransKodlari.push("5600");
        disBransKodlari.push("5200");
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
    }

    protected async ControlHastaTemasDurumu()
    {
        if ((this._PatientAdmission.Department == null || this._PatientAdmission.Department.IsEmergencyDepartment != true) && this.patientAdmissionFormViewModel.activeTab == 1)
        {         
            try{
                if(this._PatientAdmission.Episode != null && this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.UniqueRefNo != null)
                {
                let _temp = null;
                let fullApiUrl = '/api/PatientAdmissionService/GetHastaTemasDurumu/?doctorObjectID=' + this._PatientAdmission.ProcedureDoctor + '&patientObjectID=' + this._PatientAdmission.Episode.Patient.ObjectID;
                let res = await this.httpService.get<HastaTemasDurumuResultModel>(fullApiUrl,HastaTemasDurumuResultModel);
                if(res != null)
                {
                    if(res.isResponseSuccess && res.responseMessage != "")
                        TTVisual.InfoBox.Alert(res.responseMessage);
                        // _temp = await  ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL',"Temas Riskli Hasta", "Temas Riskli Hasta1", res.responseMessage, 1);
                        
                }
            }
            }
            catch(error)
            {
                ServiceLocator.MessageService.showError("Temas Durmu Sorgulanırken bir hata ile karşılaşıldı " + error);
            }   

        }
    }
    protected async CheckPayerAndProtocol(): Promise<void> {

    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {

        if (this.patientAdmissionFormViewModel.activeTab == 3)//sağlık kurulu
        {
            if ((this.patientAdmissionFormViewModel._PatientAdmission.ResourcesToBeReferred == null
                || this.patientAdmissionFormViewModel._PatientAdmission.ResourcesToBeReferred.length == 0)) {
                throw new TTException("Muayene edecek sağlık kurulu listesi boş olamaz");
            }
            else if (this.patientAdmissionFormViewModel._PatientAdmission.ResourcesToBeReferred.find(x => x.ProcedureDoctorToBeReferred == null) != null)
                throw new TTException("Muayene edecek doktor bilgisi olmayan kayıtlar bulunmuştur.");
            else if (this.patientAdmissionFormViewModel._PatientAdmission.ResourcesToBeReferred.find(x => x.Resource == null) != null)
                throw new TTException("Muayene edecek birim bilgisi olmayan kayıtlar bulunmuştur.");

            if (this._PatientAdmission.HCModeOfPayment == null)
                throw new TTException("Ödeme türü alanı boş olamaz.");

        }
        if(this.patientAdmissionFormViewModel.activeTab == 1 && this.patientAdmissionFormViewModel.AcilDoktorSecimiZorla)
        {
            if(this.patientAdmissionFormViewModel.tempProcedureDoctor == null && this._PatientAdmission.Department.IsEmergencyDepartment == true)
            {
                throw new TTException("Acil Branşı için doktor seçimi zorunludur. Lütfen doktor seçimi yapınız..");
            }
        }

        if (this._PatientAdmission.Episode.Patient.YUPASSNO != null) {
            try {
                let apiUrl = '/api/PatientAdmissionService/GetYupasBelgeList/?ResourceID=' + this._PatientAdmission.Episode.Patient.YUPASSNO.toString();

                let result = await this.httpService.get<Array<YurtDisiYardimHakki>>(apiUrl);

                if (result != null) {
                    if (result.length == 1 && result[0].YardimHakID != null)
                        this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaYupassNo = result[0].YardimHakID;
                    else {
                        this.yupasBelgeListesi = result;
                        this.showYupasBelgeListesi = true;
                        let a = await this.subscribeYupasPopupButton();
                        this.showYupasBelgeListesi = false;
                        if (a == 1) {
                            if (this._selectedYupasBelge == null)
                                throw new TTException("Belge Seçmeden Devam Edemezsiniz.");

                            this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaYupassNo = this._selectedYupasBelge;
                            this._selectedYupasBelge = null;
                        }
                        else
                            throw new TTException("İşlemden vazgeçildi.");

                    }
                }

            } catch (e) {
                ServiceLocator.MessageService.showError("Yupas Belgeleri Listelenirken bir hata ile karşılaşıldı " + (<Error>e).message);
            }

        }
        // throw new TTException("ismailadasd.");
        super.ClientSidePostScript(transDef);
    }
    protected async OnUpdateError(ex: Exception): Promise<void> {
        //   this._PatientAdmission.ResourcesToBeReferred.DeleteChildren();
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
    }
    public showimportantPatientInfo = false;

    protected async PreScript() {
        super.PreScript();

    }
    public async CheckIfPatientExists(): Promise<void> {
        this.SetSearchString();
        let filter: string = " Where " + this.GetFilterExpressionOfPatientSearch(); // Where ?imdilik konuldu Coredaki problem geçene kadar
        let patientList: Array<Patient.GetPatientByInjection_Class> = (await PatientService.GetPatientByInjection());
        let count: number = 1;
        if ((<ITTObject>this._PatientAdmission.Episode.Patient).IsNew) {
            count = 0;
        }
        if (patientList.length > count) {
            if (this.ForeignUniqueNo.Text.Length > 0) {
                let hataParamList: string[] = [this.ForeignUniqueNo.Text];
                let message: string = (await SystemMessageService.GetMessageV3(102, hataParamList));
                throw new TTException(message);
            }
            else if (this.UniqueRefNo.Text.Length > 0) {
                let hataParamList: string[] = [this.UniqueRefNo.Text];
                let message: string = (await SystemMessageService.GetMessageV3(103, hataParamList));
                throw new TTException(message);
            }
            else {
                if (this.UnIdentified.Value !== true) {
                    let message: string = (await SystemMessageService.GetMessage(104));
                    throw new TTException(message);
                }
            }
        }
    }
    public CheckMernisNumber() {
        let uniqueRefNo: string = this._PatientAdmission.Episode.Patient.UniqueRefNo.toString();
        if (uniqueRefNo.substring(0, 2) === "99" || uniqueRefNo.substring(0, 2) === "98")
            return true;
        while (uniqueRefNo.length < 11)
            uniqueRefNo = "0" + uniqueRefNo;
        let retVal: boolean = false;
        let checkSum: number = Convert.ToInt32(uniqueRefNo.substring(9, 2));
        let oddDigSum: number = Convert.ToInt32(uniqueRefNo.substring(8, 1)) + Convert.ToInt32(uniqueRefNo.substring(6, 1)) + Convert.ToInt32(uniqueRefNo.substring(4, 1)) + Convert.ToInt32(uniqueRefNo.substring(2, 1)) + Convert.ToInt32(uniqueRefNo.substring(0, 1));
        let oddDigSum_temp: number = oddDigSum;
        let evenDigSum: number = Convert.ToInt32(uniqueRefNo.substring(7, 1)) + Convert.ToInt32(uniqueRefNo.substring(5, 1)) + Convert.ToInt32(uniqueRefNo.substring(3, 1)) + Convert.ToInt32(uniqueRefNo.substring(1, 1));
        let total: number = oddDigSum * 3 + evenDigSum;
        let addTo1: number = (10 - (total % 10)) % 10;
        oddDigSum = addTo1 + evenDigSum;
        evenDigSum = oddDigSum_temp;
        total = oddDigSum * 3 + evenDigSum;
        let addTo2: number = (10 - (total % 10)) % 10;
        total = addTo1 * 10 + addTo2;
        if (total === checkSum)
            retVal = true;
        return retVal;
    }


    public async FiredActionStatus(ob: TTObject): Promise<string> {
        if (ob.CurrentStateDef !== null) {
            if (ob.IsCancelled) {
                return i18n("M16535", "İptal Edildi");
            }
            else if (ob.CurrentStateDef.IsEntry === true) {
                return i18n("M24515", "Yeni");
            }
            else if (ob.CurrentStateDef.Status === StateStatusEnum.Uncompleted) {
                return i18n("M12685", "Devam Ediyor");
            }
            else if (ob.CurrentStateDef.Status === StateStatusEnum.CompletedSuccessfully) {
                return i18n("M22710", "Tamamlandı");
            }
            else if (ob.CurrentStateDef.Status === StateStatusEnum.CompletedUnsuccessfully) {
                return i18n("M11604", "Başarısız Tamamlandı");
            }
            return "";
        }
        else {
            return "";
        }
    }

    public async GetBirthDate(): Promise<Date> {
        if (this.BDYearOnly.Value === true)
            return Convert.ToDateTime("01/01/" + this.BirthDate.Text);
        else return Convert.ToDateTime(this.BirthDate.Text);
    }
    public async GetFilterExpressionOfPatientSearch(): Promise<string> {
        let filterExpression: string = null;
        let opr: string = null;
        let injection: string = null;
        let criteriaEntered: boolean = false;
        let objectContext: TTObjectContext = new TTObjectContext(true);
        //TC Kimlik No
        if (this.UniqueRefNo.Text.Length > 0) {
            criteriaEntered = true;
            if (filterExpression !== null) {
                filterExpression += " AND ";
            }
            filterExpression += "(UNIQUEREFNO = " + this.UniqueRefNo.Text.toString() + " )";
            return filterExpression;
        }
        //Kimlik/Sigorta No (Yabancı Hastalar)
        if (this.ForeignUniqueNo.Text.Length > 0) {
            criteriaEntered = true;
            if (filterExpression !== null) {
                filterExpression += " AND ";
            }
            filterExpression += "(FOREIGNUNIQUEREFNO = " + this.ForeignUniqueNo.Text.toString() + " )";
            return filterExpression;
        }
        //UnIdentified
        if (this.UnIdentified.Value !== null) {
            criteriaEntered = true;
            if (this.UnIdentified.Value) {
                filterExpression = "(1=0)"; //Acilde kimliği bilinmeyen hasta kabul edilmek istendiğinde yavaşlığa sebep olduğu için 1=0 döndürüldü.
                return filterExpression;
            }
        }
        this.Name.Text = this.Name.Text.trim();
        this.Surname.Text = this.Surname.Text.trim();
        if (this.Name.Text.Length > 0 && this.Surname.Text.Length > 0) {
            let MatchedIDs: Array<Guid> = new Array<Guid>();
            let NameTokens: Array<any> = new Array<any>();
            /*NameTokens = Common.Tokenize(searchString, true);

            if (NameTokens.Count > 1)
            {
                for (int i = 0; i <= NameTokens.Count - 1; i++)
                {
                    string s = NameTokens[i].ToString();

                    if (i > 0)
                    {
                        injection += " OR (";
                        if (s.IndexOf('%') != -1 && (TTObjectClasses.SystemParameter.GetParameterValue("PatientSearchWithAmpersand", "False").ToUpper() == "TRUE"))
                            opr = "LIKE";
                        else
                            opr = "=";
                        injection += "TOKEN " + opr + " '" + s + "' ";
                        if (i == NameTokens.Count - 1)
                            injection += "AND TOKENTYPE = 1)";
                        else
                            injection += "AND TOKENTYPE = 0)";
                    }
                    else
                    {
                        injection += " AND ((";
                        if (s.IndexOf('%') != -1)
                            opr = "LIKE";
                        else
                            opr = "=";
                        injection += "TOKEN " + opr + " '" + s + "' ";
                        injection += "AND TOKENTYPE = 0)";
                    }
                }
                injection += ") GROUP BY PATIENT HAVING Count(*) >= " + NameTokens.Count.ToString();

                if (injection != null)
                {
                    BindingList<PatientToken.GetPatientByInjection_Class> tokenList = PatientToken.GetPatientByInjection(injection);
                    foreach (PatientToken.GetPatientByInjection_Class t in tokenList)
                    {
                        MatchedIDs.Add(t.Patient.Value);
                    }
                    if (MatchedIDs.Count > 0)
                    {
                        filterExpression = CreateFilterExpressionOfGuidList(filterExpression, MatchedIDs);
                    }
                }
            }*/
            let a = 1;
        }
        if (filterExpression !== null) {
            //Baba Adı
            if (this.FatherName.Text.Length > 0) {
                criteriaEntered = true;
                if (filterExpression !== null) {
                    filterExpression += " AND ";
                }
                if (this.FatherName.Text.toString().indexOf('%') !== -1)
                    filterExpression += "(FATHERNAME LIKE '" + this.FatherName.Text + "%')";
                else filterExpression += "(FATHERNAME = '" + this.FatherName.Text + "')";
            }
            if (this.BirthDate.Text !== null && this.BirthDate.Text.toString().trim() !== ".  ." && this.BirthDate.Text.toString().trim() !== "") {
                criteriaEntered = true;
                let firstDate: string = "01.01." + (Convert.ToDateTime(await this.GetBirthDate()).Date).format("yyyy") + " 00:00:00";
                let lastDate: string = "31.12." + (Convert.ToDateTime(await this.GetBirthDate()).Date).format("yyyy") + " 23:59:59";
                let filter: string = "(BIRTHDATE >= TODATE('" + (Convert.ToDateTime(firstDate).Date).format("yyyy-MM-dd HH:mm") + "') AND";
                filter += " BIRTHDATE <= TODATE('" + (Convert.ToDateTime(lastDate).Date).format("yyyy-MM-dd HH:mm") + "'))";
                if (filterExpression === null)
                    filterExpression = "(" + filter + ")";
                else filterExpression += " AND (" + filter + ")";
            }
            //İl
            //if (this.CityOfBirth.SelectedObjectID !== null) {
            //    criteriaEntered = true;
            //    let filter: string = "(CITYOFBIRTH = '" + this.CityOfBirth.SelectedObjectID.toString() + "')";
            //    if (filterExpression === null)
            //        filterExpression = "(" + filter + ")";
            //    else filterExpression += " AND (" + filter + ")";
            //}
            if (this.Nationality.SelectedObjectID !== null) {
                criteriaEntered = true;
                let filter: string = "(NATIONALITY = '" + this.Nationality.SelectedObjectID.toString() + "')";
                if (filterExpression === null)
                    filterExpression = "(" + filter + ")";
                else filterExpression += " AND (" + filter + ")";
            }
        }
        if (filterExpression === null)
            filterExpression = "1=0";
        return filterExpression;
    }
    public async GetMedulaFilterOfReasonForAdmission(): Promise<string> {
        let MedulaString: string = "";
        if (this._PatientAdmission.PatientMedulaHastaKabul !== null) {
            if (this._PatientAdmission.PatientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO !== null) {
                if (this._PatientAdmission.PatientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.provizyonTipi !== null) {
                    //N : Normal
                    //I : İş kazası
                    //A : Acil
                    //T : Trafik kazası
                    //V : Adli Vaka
                    //M : Meslek hastalığı
                    switch (this._PatientAdmission.PatientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.provizyonTipi) {
                        case "A":
                            MedulaString += (MedulaString === "" ? "" : ",") + "11"; //Acil
                            break;
                        case "V":
                            MedulaString += (MedulaString === "" ? "" : ",") + "12,16,15"; //12 Alkol - Darp Muayenesi -16 Adli Gözetim- 15 Tutuklu
                            break;
                    }
                }
                if (this._PatientAdmission.PatientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.provizyonTipi !== null) {
                    //0, "Normal Sorgu"
                    //1, "Diyaliz"
                    //2, "Fiziksel tedavi ve rehabilitasyon"
                    //4, "Kemik iliği"
                    //5, "Kök hücre nakli"
                    //6, "Ekstrakorporeal fotoferez tedavisi"
                    //7, "Hiperbarik oksijen tedavisi"
                    //8, "ESWL"
                    //9, "Ağız Protez tedavisi"
                    //10, "Ketem"
                    //11, "Tüp Bebek 1"
                    //12, "Tüp Bebek 2"
                    //13, "Diş Tedavisi"
                    //14, ?Onkolojik Tedavi?
                    //15, ?Plazmaferez Tedavisi?
                    //16, ?ESWT?
                    //donorTCKimlikNo Donörün TC Kimlik
                    //Numarası
                    //String 11 Hayır Alınmak istenen takip
                    switch (this._PatientAdmission.PatientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.tedaviTipi) {
                        //Aşağıdaki tiplerde mutlaka muayen yapılıyor olmalıl
                        case "1": //1, "Diyaliz"
                        case "2": //2, "Fiziksel tedavi ve rehabilitasyon"
                        case "7": //7, "Hiperbarik oksijen tedavisi"
                        case "8": //8, "ESWL"
                        case "9": //9, "Ağız Protez tedavisi"
                            MedulaString += (MedulaString === "" ? "" : ",") + "0"; //Normal Muayene
                            break;
                    }
                }
            }
        }
        return MedulaString;
    }

    public async LoadAppointmentInfo(): Promise<void> {

    }

    //SANIRIM İHTİYAÇ Kalmadı kontrol edip komple silebiliriz
    public async LoadPatientListView(patientList: Array<any>): Promise<void> {

        try {
            let itemList = new Array<any>();
            for (let patient of patientList) {

                let p = new PatientAdmissionListModel();

                p.SepObjectID = patient.SepObjectID;
                p.Patientid = patient.Patientid;
                p.Paid = patient.Paid;
                p.ProvisionType = (patient.Payer == "SGK" && patient.MedulaTakipNo == null) ? "-1" : "";
                p.Fullname = patient.Fullname.toString();
                p.Patientadmissionnumber = (patient.Patientadmissionnumber !== null ? patient.Patientadmissionnumber : "-");
                p.ActionDate = patient.ActionDate;
                p.Policlinic = patient.Policlinic;
                p.MedulaTakipNo = patient.MedulaTakipNo;
                p.AdmissionType = patient.Admissiontype;
                p.UniqueRefNo = patient.UniqueRefNo;
                p.Forensiccasetype = patient.Forensiccasetype;
                p.Triage = patient.Triage;
                itemList.push(p);
            }
            this.PatientlistView.Items = itemList;
            this._patientAdmissionList = itemList;

            if (this.patientAdmissionFormViewModel.GetTotalSepCount == true) {
                let totalCount = (await SubEpisodeProtocolService.GetSepCountByDate(this.StartDate, this.EndDate));
                this.patientAdmissionFormViewModel.SEPCount = itemList.length.toString() + " / " + totalCount.toString();
            }
            else
                this.patientAdmissionFormViewModel.SEPCount = itemList.length.toString();

            this.globalSepCount = this.patientAdmissionFormViewModel.SEPCount;
        } catch (e) {
            ServiceLocator.MessageService.showError((<Error>e).message);

        }
    }

    public PatientlistViewRowPrepared(row) {
        if (row.rowType == "data") {

            let rowValue = (row.data.Payer == "SGK" && row.data.MedulaTakipNo == null) ? "-1" : "";
            if (rowValue == "-1") {
                // row.rowElement.firstItem().css('background-color', 'silver');
                this.renderer.setStyle(row.rowElement.firstItem(), 'background-color', 'silver');
            }
            else {
                if (row.rowIndex % 2 == 0)
                    this.renderer.setStyle(row.rowElement.firstItem(), 'background-color', '#fff');
                else
                    this.renderer.setStyle(row.rowElement.firstItem(), 'background-color', '#f8f8f8');
            }
        }
    }

    public PatientHistoryListViewRowPrepared(row) {
        if (row.rowType == "data") {

            let rowValue = row.data.Admissiontypecode.toString();

            if (rowValue == "V" || rowValue == "I" || rowValue == "T") {
                //row.rowElement.firstItem().css('background-color', '#ffbebe');
                this.renderer.setStyle(row.rowElement.firstItem(), 'background-color', '#ffbebe');
            }
            else {
                if (row.rowIndex % 2 == 0)
                    this.renderer.setStyle(row.rowElement.firstItem(), 'background-color', '#fff');
                else
                    this.renderer.setStyle(row.rowElement.firstItem(), 'background-color', '#f8f8f8');
            }

            if (row.data.rowFromSE == true)
                this.renderer.setStyle(row.rowElement.firstItem(), 'readOnly', 'true');
            else
                this.renderer.setStyle(row.rowElement.firstItem(), 'readOnly', 'false');
            // let rowDisabled = row.data.rowFromSE;


        }
    }

    public LoadPatientAdmissionHistory(historyPatientAdmission: Array<any>, canShowMessage: boolean): void {

        let PatientAdmissionNumber = 1;
        try {
            let itemList = new Array<any>();
            let alertMessage: string = "";
            let admissionTypeStr: string = "";

            for (let paHistory of historyPatientAdmission) {

                let p = new SubEpisodeProtocol.GetPaBySearchPatient_Class();

                p.ObjectID = paHistory.ObjectID;
                p.Admissiontypecode = (paHistory.Admissiontypecode == null) ? "-1" : paHistory.Admissiontypecode;
                p.Fromse = (paHistory.Fromse == "1") ? true : false;
                p.ProtocolNo = (paHistory.ProtocolNo !== null ? paHistory.ProtocolNo : PatientAdmissionNumber);
                p.Admissiontype = (paHistory.Admissiontype == null) ? "Normal" : paHistory.Admissiontype;
                p.Admissionstatus = (paHistory.Admissionstatus == null) ? "Muayene" : paHistory.Admissionstatus;
                p.Pastatus = (paHistory.Pastatus != null ? paHistory.Pastatus : "");
                p.Openingdate = (paHistory.Openingdate.toString("dd/mm/YYYY"));
                p.Policlinicname = (paHistory.Policlinicname !== null ? paHistory.Policlinicname : "GENEL");
                p.Doctorname = (paHistory.Doctorname !== null ? paHistory.Doctorname : "....");
                p.Payername = (paHistory.Payername !== null ? paHistory.Payername : "SGK");
                p.Provisionno = (paHistory.Provisionno != null ? paHistory.Provisionno : "");
                p.Username = (paHistory.Username !== null ? paHistory.Username : "");

                itemList.push(p);

                ++PatientAdmissionNumber;
                if (p.Admissiontypecode == "V" || p.Admissiontypecode == "I" || p.Admissiontypecode == "T") {
                    if (p.Admissiontypecode == "T") admissionTypeStr = "'TRAFİK KAZASI'";
                    else if (p.Admissiontypecode == "V") admissionTypeStr = "'ADLİ VAKA'";
                    else if (p.Admissiontypecode == "I") admissionTypeStr = "'İŞ KAZASI'";

                    alertMessage += paHistory.Openingdate.toString("dd.MM.yyyy") + i18n("M22849", " tarihine ait, geliş sebebi ") + admissionTypeStr + i18n("M19630", " olan kabulü bulunmaktadır.\n");
                }
            }


            this.PatientHistoryListView.Items = itemList;
            this._historyPatientAdmission = itemList;

            if (alertMessage != "" && canShowMessage == true)
                ServiceLocator.MessageService.showInfo(i18n("M15426", "Hastanın ") + alertMessage.toString());


        } catch (e) {
            ServiceLocator.MessageService.showError((<Error>e).message);
        }
    }

    public async PrintOutPatientEtiquetteReport(): Promise<void> {
        try {
        }
        catch (ex) {
            return;
        }

    }


    public SetPatientDetailedInfo() {

        if (this._PatientAdmission.Episode.Patient.UnIdentified === true || this._PatientAdmission.Episode.Patient.Foreign === true)
            this._PatientAdmission.Episode.Patient.IsTrusted = true;
        this.Death.Value = this._PatientAdmission.Episode.Patient.Death;

    }
    public async SetSearchString(): Promise<void> {
        this.searchString = "";
        if (this.UniqueRefNo.Text.Length > 0) {
            this.searchString = this.UniqueRefNo.Text.toString();
        }
        else if (this.ForeignUniqueNo.Text.Length > 0) {
            this.searchString = this.ForeignUniqueNo.Text.toString();
        }
        else {
            if (this.Name.Text.Length > 0)
                this.searchString += this.Name.Text.toString() + " ";
            if (this.Surname.Text.Length > 0)
                this.searchString += this.Surname.Text.toString();
        }
    }
    public async ShowOrHideMedulaTabByPatientPayerAndReasonForAdmission(): Promise<void> {

    }
    public static async FireNewPatientAdmission(patient: Patient, PatientAdmissionObjectDef: TTObjectDef, episode: Episode, admissionAppointment: AdmissionAppointment): Promise<PatientAdmission> {
        let savePointGuid: Guid = patient.ObjectContext.BeginSavePoint();
        try {
            let firedAction: PatientAdmission = null;
            firedAction = <PatientAdmission>patient.ObjectContext.CreateObject("PatientAdmission");
            let states: Array<TTObjectStateDef> = <Array<TTObjectStateDef>>(<ITTObject>firedAction).GetNextStateDefs();
            if (states.length > 0) {
                firedAction.CurrentStateDef = <TTObjectStateDef>states[0];
            }
            firedAction.ActionDate = (await CommonService.RecTime());
            if (episode !== null) {
                //bool isPatientGroupChange = (firedAction.PatientGroup != episode.PatientAdmission.Episode.PatientGroup);
                firedAction.Episode = episode;

            }
            // firedAction.Patient = patient;
            if (admissionAppointment === null && episode === null) {
                firedAction.AdmissionAppointment = patient.MyAdmissionAppointment; //??????? Kafa Randevusu için yeterli mi?
            }
            else if (admissionAppointment !== null) {
                firedAction.AdmissionAppointment = admissionAppointment;
            }
            return firedAction;
        }
        catch (ex) {
            if (patient.ObjectContext.HasSavePoint(savePointGuid))
                patient.ObjectContext.RollbackSavePoint(savePointGuid);
            throw ex;
        }

    }

    // *****Method declarations end *****

    public initViewModel() {
        this._TTObject = new PatientAdmission();
        this.patientAdmissionFormViewModel = new PatientAdmissionFormViewModel();
        this._ViewModel = this.patientAdmissionFormViewModel;
        this.patientAdmissionFormViewModel._PatientAdmission = this._TTObject as PatientAdmission;
        this.patientAdmissionFormViewModel._PatientAdmission.MedulaSigortaliTuru = new SigortaliTuru();
        this.patientAdmissionFormViewModel._PatientAdmission.Protocol = new ProtocolDefinition();
        this.patientAdmissionFormViewModel.tempPayer = new PayerDefinition();
        this.patientAdmissionFormViewModel.tempDispatchPayer = new PayerDefinition();
        this.patientAdmissionFormViewModel._PatientAdmission.Triage = new SKRSTRIAJKODU();

        this.patientAdmissionFormViewModel._PatientAdmission.Episode = new Episode();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient = new Patient();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.EducationStatus = new SKRSOgrenimDurumu();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.Occupation = new SKRSMeslekler();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.TownOfRegistry = new TownDefinitions();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.CityOfRegistry = new SKRSILKodlari();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.Nationality = new SKRSUlkeKodlari();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.BirthOrder = new SKRSDogumSirasi();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.Mother = new Patient();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.Sex = new SKRSCinsiyet();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.BloodGroupType = new SKRSKanGrubu();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.SKRSMaritalStatus = new SKRSMedeniHali();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.SKRSOzurlulukDurumu = new SKRSOzurlulukDurumu();
        this.patientAdmissionFormViewModel._PatientAdmission.SKRSAdliVaka = new SKRSAdliVakaGelisSekli();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.SKRSYabanciHasta = new SKRSYabanciHastaTuru();
        this.patientAdmissionFormViewModel._PatientAdmission.PA_Address = new PatientIdentityAndAddress();
        this.patientAdmissionFormViewModel._PatientAdmission.PA_Address.SKRSMahalleKodlari = new SKRSMahalleKodlari();
        this.patientAdmissionFormViewModel._PatientAdmission.PA_Address.SKRSKoyKodlari = new SKRSKoyKodlari();
        this.patientAdmissionFormViewModel._PatientAdmission.PA_Address.SKRSCsbmKodu = new SKRSCSBMTipi();
        this.patientAdmissionFormViewModel._PatientAdmission.PA_Address.SKRSBucakKodu = new SKRSBucakKodlari();
        this.patientAdmissionFormViewModel._PatientAdmission.ExternalHospital = new ExternalHospitalDefinition();
        this.patientAdmissionFormViewModel._PatientAdmission.PA_Address.SKRSIlceKodlari = new SKRSIlceKodlari();
        this.patientAdmissionFormViewModel._PatientAdmission.PA_Address.SKRSILKodlari = new SKRSILKodlari();
        this.patientAdmissionFormViewModel._PatientAdmission.PA_Address.SKRSAdresTipi = new SKRSAdresTipi();
        this.stringPatientAge = null;
        this.patientAdmissionFormViewModel.SubEpisodeProtocol = new SubEpisodeProtocol();

        this.initPaViewModel();

    }
    public initPaViewModel() {
        this.patientAdmissionFormViewModel._PatientAdmission.Episode = new Episode();
        this.patientAdmissionFormViewModel._PatientAdmission.Episode.SubEpisodes = new Array<SubEpisode>();
        this.patientAdmissionFormViewModel._PatientAdmission.Department = new ResDepartment();

        this.patientAdmissionFormViewModel.tempDispatchPoliclinic = new ResPoliclinic();
        this.patientAdmissionFormViewModel.tempDispatchProcedureDoctor = new ResUser();
        this.patientAdmissionFormViewModel.tempPoliclinic = new ResPoliclinic();
        this.patientAdmissionFormViewModel.tempProcedureDoctor = new ResUser();

        this.patientAdmissionFormViewModel._PatientAdmission.PriorityStatus = new PriorityStatusDefinition();
        this.patientAdmissionFormViewModel._PatientAdmission.ResourcesToBeReferred = new Array<PatientAdmissionResourcesToBeReferred>();
        this.patientAdmissionFormViewModel.ResourcesToBeReferredList = new Array<PatientAdmissionResourcesToBeReferred>();
        this.patientAdmissionFormViewModel._PatientAdmission.HCRequestReason = new HCRequestReason();
        this.patientAdmissionFormViewModel._PatientAdmission.HCRequestReason.ReasonForExamination = new ReasonForExaminationDefinition();
        this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaIstisnaiHal = new IstisnaiHal();
        this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaProvizyonTipi = new ProvizyonTipi();

    }
    protected async ClearListFilterExpressions() {


        this.Policlinic.ListFilterExpression = "";
        let inputKlinik: InputModelForQueries = new InputModelForQueries();
        inputKlinik.filter = this.Policlinic.ListFilterExpression;
        // this.FillDataSourcesForPoliclinic(inputKlinik);
        this.FillDataSource(inputKlinik, 2);
        this.Branch.ListFilterExpression = "";
        let inputBranch: InputModelForQueries = new InputModelForQueries();
        inputBranch.filter = " AND this.ISACTIVE = 1";
        //   this.FillDataSources(inputBranch);
        this.FillDataSource(inputBranch, 1);
        //  this.FillDataSource(inputBranch, this.departmentApi, this.DepartmentList);
        this.ProcedureDoctor.ListFilterExpression = "";
        let inputDoctor: InputModelForQueries = new InputModelForQueries();
        inputDoctor.filter = " AND this.ISACTIVE = 1";
        //this.FillDataSourcesForDoctor(inputDoctor);
        this.FillDataSource(inputDoctor, 3);



    }
    public imageSource: any;



    protected async loadViewModel() {

        let that = this;

        that.patientAdmissionFormViewModel = this._ViewModel as PatientAdmissionFormViewModel;
        that._TTObject = this.patientAdmissionFormViewModel._PatientAdmission;
        if (this.patientAdmissionFormViewModel == null)
            this.patientAdmissionFormViewModel = new PatientAdmissionFormViewModel();
        if (this.patientAdmissionFormViewModel._PatientAdmission == null)
            this.patientAdmissionFormViewModel._PatientAdmission = new PatientAdmission();

        await that.ClearListFilterExpressions(); // TODO Murat and Belgin 

        // that.FilterPoliclinicId = null;

        let episodeObjectID = that.patientAdmissionFormViewModel._PatientAdmission["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.patientAdmissionFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.patientAdmissionFormViewModel._PatientAdmission.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.patientAdmissionFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                    if (patient != null) {
                        let nationalityObjectID = patient["Nationality"];
                        if (nationalityObjectID != null && (typeof nationalityObjectID === 'string')) {
                            let nationality = that.patientAdmissionFormViewModel.SKRSUlkeKodlaris.find(o => o.ObjectID.toString() === nationalityObjectID.toString());
                            if (nationality) {
                                patient.Nationality = nationality;
                            }
                        }
                    }
                    if (patient != null) {
                        let educationStatusObjectID = patient["EducationStatus"];
                        if (educationStatusObjectID != null && (typeof educationStatusObjectID === 'string')) {
                            let educationStatus = that.patientAdmissionFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
                            if (educationStatus) {
                                patient.EducationStatus = educationStatus;
                            }
                        }
                    }
                    if (patient != null) {
                        let bloodGroupTypeObjectID = patient["BloodGroupType"];
                        if (bloodGroupTypeObjectID != null && (typeof bloodGroupTypeObjectID === "string")) {
                            let kanGrubu = that.patientAdmissionFormViewModel.SKRSKanGrubus.find(o => o.ObjectID.toString() === bloodGroupTypeObjectID.toString());
                            if (kanGrubu) {
                                patient.BloodGroupType = kanGrubu;
                            }
                        }
                    }
                    if (patient != null) {
                        let occupationObjectID = patient["Occupation"];
                        if (occupationObjectID != null && (typeof occupationObjectID === 'string')) {
                            let occupation = that.patientAdmissionFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === occupationObjectID.toString());
                            if (occupation) {
                                patient.Occupation = occupation;
                            }
                        }
                    }
                    if (patient != null) {
                        let sexObjectID = patient["Sex"];
                        if (sexObjectID != null && (typeof sexObjectID === 'string')) {
                            let sex = that.patientAdmissionFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === sexObjectID.toString());
                            if (sex) {
                                patient.Sex = sex;
                            }
                        }
                    }
                    if (patient != null) {
                        let townOfRegistryObjectID = patient["TownOfRegistry"];
                        if (townOfRegistryObjectID != null && (typeof townOfRegistryObjectID === 'string')) {
                            let townOfRegistry = that.patientAdmissionFormViewModel.TownDefinitionss.find(o => o.ObjectID.toString() === townOfRegistryObjectID.toString());
                            if (townOfRegistry) {
                                patient.TownOfRegistry = townOfRegistry;
                            }
                        }
                    }
                    if (patient != null) {
                        let cityOfRegistryObjectID = patient["CityOfRegistry"];
                        if (cityOfRegistryObjectID != null && (typeof cityOfRegistryObjectID === 'string')) {
                            let cityOfRegistry = that.patientAdmissionFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === cityOfRegistryObjectID.toString());
                            if (cityOfRegistry) {
                                patient.CityOfRegistry = cityOfRegistry;
                            }
                        }
                    }
                    if (patient != null) {
                        let motherObjectID = patient["Mother"];
                        if (motherObjectID != null && (typeof motherObjectID === 'string')) {
                            let mother = that.patientAdmissionFormViewModel.Patients.find(o => o.ObjectID.toString() === motherObjectID.toString());
                            if (mother) {
                                patient.Mother = mother;
                            }
                        }
                    }
                    if (patient != null) {
                        let birthOrderObjectID = patient["BirthOrder"];
                        if (birthOrderObjectID != null && (typeof birthOrderObjectID === 'string')) {
                            let birthOrder = that.patientAdmissionFormViewModel.SKRSDogumSirasis.find(o => o.ObjectID.toString() === birthOrderObjectID.toString());
                            if (birthOrder) {
                                patient.BirthOrder = birthOrder;
                            }
                        }
                    }
                    if (patient != null) {
                        let sKRSYabanciHastaObjectID = patient["SKRSYabanciHasta"];
                        if (sKRSYabanciHastaObjectID != null && (typeof sKRSYabanciHastaObjectID === 'string')) {
                            let sKRSYabanciHasta = that.patientAdmissionFormViewModel.SKRSYabanciHastaTurus.find(o => o.ObjectID.toString() === sKRSYabanciHastaObjectID.toString());
                            if (sKRSYabanciHasta) {
                                patient.SKRSYabanciHasta = sKRSYabanciHasta;
                            }
                        }
                    }
                    if (patient != null) {
                        let sKRSMedeniHaliObjectID = patient["SKRSMaritalStatus"];
                        if (sKRSMedeniHaliObjectID != null && (typeof sKRSMedeniHaliObjectID === 'string')) {
                            let sKRSMedeniHali = that.patientAdmissionFormViewModel.SKRSMaritalStatuss.find(o => o.ObjectID.toString() === sKRSMedeniHaliObjectID.toString());
                            if (sKRSMedeniHali) {
                                patient.SKRSMaritalStatus = sKRSMedeniHali;
                            }
                        }
                    }
                    if (patient != null) {
                        let sKRSOzurlulukDurumuObjectID = patient["SKRSOzurlulukDurumu"];
                        if (sKRSOzurlulukDurumuObjectID != null && (typeof sKRSOzurlulukDurumuObjectID === 'string')) {
                            let sKRSOzurlulukDurumu = that.patientAdmissionFormViewModel.SKRSOzurlulukDurumus.find(o => o.ObjectID.toString() === sKRSOzurlulukDurumuObjectID.toString());
                            if (sKRSOzurlulukDurumu) {
                                patient.SKRSOzurlulukDurumu = sKRSOzurlulukDurumu;
                            }
                        }
                    }

                    if (patient != null) {
                        if (this._PatientAdmission.Episode.Patient.BirthDate != null) {
                            this.BirthDate.BackColor = "white";
                            const today = new Date();
                            let patientAge = today.getFullYear() - (this._PatientAdmission.Episode.Patient.BirthDate).getFullYear();
                            this.stringPatientAge = patientAge.toString();
                        }
                    }

                }


            }
        }
        let pA_AddressObjectID = that.patientAdmissionFormViewModel._PatientAdmission["PA_Address"];
        if (pA_AddressObjectID != null && (typeof pA_AddressObjectID === 'string')) {
            let pA_Address = that.patientAdmissionFormViewModel.PatientIdentityAndAddresss.find(o => o.ObjectID.toString() === pA_AddressObjectID.toString());
            if (pA_Address) {
                that.patientAdmissionFormViewModel._PatientAdmission.PA_Address = pA_Address;
            }
            if (pA_Address != null) {
                let sKRSMahalleKodlariObjectID = pA_Address["SKRSMahalleKodlari"];
                if (sKRSMahalleKodlariObjectID != null && (typeof sKRSMahalleKodlariObjectID === 'string')) {
                    let sKRSMahalleKodlari = that.patientAdmissionFormViewModel.SKRSMahalleKodlaris.find(o => o.ObjectID.toString() === sKRSMahalleKodlariObjectID.toString());
                    if (sKRSMahalleKodlari) {
                        pA_Address.SKRSMahalleKodlari = sKRSMahalleKodlari;
                    }
                }
            }
            if (pA_Address != null) {
                let sKRSKoyKodlariObjectID = pA_Address["SKRSKoyKodlari"];
                if (sKRSKoyKodlariObjectID != null && (typeof sKRSKoyKodlariObjectID === 'string')) {
                    let sKRSKoyKodlari = that.patientAdmissionFormViewModel.SKRSKoyKodlaris.find(o => o.ObjectID.toString() === sKRSKoyKodlariObjectID.toString());
                    if (sKRSKoyKodlari) {
                        pA_Address.SKRSKoyKodlari = sKRSKoyKodlari;
                    }
                }
            }
            if (pA_Address != null) {
                let sKRSCsbmKoduObjectID = pA_Address["SKRSCsbmKodu"];
                if (sKRSCsbmKoduObjectID != null && (typeof sKRSCsbmKoduObjectID === 'string')) {
                    let sKRSCsbmKodu = that.patientAdmissionFormViewModel.SKRSCSBMTipis.find(o => o.ObjectID.toString() === sKRSCsbmKoduObjectID.toString());
                    if (sKRSCsbmKodu) {
                        pA_Address.SKRSCsbmKodu = sKRSCsbmKodu;
                    }
                }
            }
            if (pA_Address != null) {
                let sKRSBucakKoduObjectID = pA_Address["SKRSBucakKodu"];
                if (sKRSBucakKoduObjectID != null && (typeof sKRSBucakKoduObjectID === 'string')) {
                    let sKRSBucakKodu = that.patientAdmissionFormViewModel.SKRSBucakKodlaris.find(o => o.ObjectID.toString() === sKRSBucakKoduObjectID.toString());
                    if (sKRSBucakKodu) {
                        pA_Address.SKRSBucakKodu = sKRSBucakKodu;
                    }
                }
            }
            if (pA_Address != null) {
                let sKRSIlceKodlariObjectID = pA_Address["SKRSIlceKodlari"];
                if (sKRSIlceKodlariObjectID != null && (typeof sKRSIlceKodlariObjectID === 'string')) {
                    let sKRSIlceKodlari = that.patientAdmissionFormViewModel.SKRSIlceKodlaris.find(o => o.ObjectID.toString() === sKRSIlceKodlariObjectID.toString());
                    if (sKRSIlceKodlari) {
                        pA_Address.SKRSIlceKodlari = sKRSIlceKodlari;
                    }
                }
            }
            if (pA_Address != null) {
                let sKRSILKodlariObjectID = pA_Address["SKRSILKodlari"];
                if (sKRSILKodlariObjectID != null && (typeof sKRSILKodlariObjectID === 'string')) {
                    let sKRSILKodlari = that.patientAdmissionFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === sKRSILKodlariObjectID.toString());
                    if (sKRSILKodlari) {
                        pA_Address.SKRSILKodlari = sKRSILKodlari;
                    }
                }
            }
            if (pA_Address != null) {
                let sKRSAdresTipiObjectID = pA_Address["SKRSAdresTipi"];
                if (sKRSAdresTipiObjectID != null && (typeof sKRSAdresTipiObjectID === 'string')) {
                    let sKRSAdresTipi = that.patientAdmissionFormViewModel.SKRSAdresTipis.find(o => o.ObjectID.toString() === sKRSAdresTipiObjectID.toString());
                    if (sKRSAdresTipi) {
                        pA_Address.SKRSAdresTipi = sKRSAdresTipi;
                    }
                }
            }
        }


        let protocolObjectID = that.patientAdmissionFormViewModel._PatientAdmission["Protocol"];
        if (protocolObjectID != null && (typeof protocolObjectID === 'string')) {
            let protocol = that.patientAdmissionFormViewModel.ProtocolDefinitions.find(o => o.ObjectID.toString() === protocolObjectID.toString());
            if (protocol) {
                that.patientAdmissionFormViewModel._PatientAdmission.Protocol = protocol;
            }
        }
        let payerTempObjectID = that.patientAdmissionFormViewModel.tempPayer;
        if (payerTempObjectID != null && (typeof payerTempObjectID === 'string')) {
            let payer = that.patientAdmissionFormViewModel.PayerDefinitions.find(o => o.ObjectID.toString() === payerTempObjectID.toString());

            if (payer) {

                that.patientAdmissionFormViewModel.tempPayer = payer;

            }
        }
        let policlinicObjectID = that.patientAdmissionFormViewModel.tempPoliclinic;
        if (policlinicObjectID != null && (typeof policlinicObjectID === 'string')) {
            let policlinic = that.patientAdmissionFormViewModel.ResPoliclinics.find(o => o.ObjectID.toString() === policlinicObjectID.toString());
            if (policlinic) {
                that.patientAdmissionFormViewModel.tempPoliclinic = policlinic;
            }
        }

        let eDisabledReportObjectID = that.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport;
        if (eDisabledReportObjectID != null && (typeof eDisabledReportObjectID === 'string')) {
            let eDisabledReport = that.patientAdmissionFormViewModel.EDisabledReports.find(o => o.ObjectID.toString() === eDisabledReportObjectID.toString());
            if (eDisabledReport) {
                that.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport = eDisabledReport;
                that.selectedReportIsDisabled = true;
            }
        }
        let eStatusNotRepComReportObjectID = that.patientAdmissionFormViewModel._PatientAdmission.EStatusNotRepCommitteeObj;
        if (eStatusNotRepComReportObjectID != null && (typeof eStatusNotRepComReportObjectID === 'string')) {
            let eStatusNotReportCom = that.patientAdmissionFormViewModel.EStatusNotRepCommitteeObjs.find(o => o.ObjectID.toString() === eStatusNotRepComReportObjectID.toString());
            if (eStatusNotReportCom) {
                that.patientAdmissionFormViewModel._PatientAdmission.EStatusNotRepCommitteeObj = eStatusNotReportCom;
                that.selectedReportIsDisabled = false;
            }
        }
        let procedureDoctorObjectID = that.patientAdmissionFormViewModel.tempProcedureDoctor;
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.patientAdmissionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.patientAdmissionFormViewModel.tempProcedureDoctor = procedureDoctor;
            }
        }

        if (that.patientAdmissionFormViewModel._PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisaridanGelenKonsultasyon || that.patientAdmissionFormViewModel._PatientAdmission.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol) {
            let dispatchPayerTempObjectID = that.patientAdmissionFormViewModel.tempDispatchPayer;
            if (dispatchPayerTempObjectID != null && (typeof dispatchPayerTempObjectID === 'string')) {
                let payer = that.patientAdmissionFormViewModel.PayerDefinitions.find(o => o.ObjectID.toString() === dispatchPayerTempObjectID.toString());

                if (payer) {

                    that.patientAdmissionFormViewModel.tempDispatchPayer = payer;

                }
            }

            let dispatchPoliclinicObjectID = that.patientAdmissionFormViewModel.tempDispatchPoliclinic;
            if (dispatchPoliclinicObjectID != null && (typeof dispatchPoliclinicObjectID === 'string')) {
                let dispatchPoliclinic = that.patientAdmissionFormViewModel.ResPoliclinics.find(o => o.ObjectID.toString() === dispatchPoliclinicObjectID.toString());
                if (dispatchPoliclinic) {
                    that.patientAdmissionFormViewModel.tempDispatchPoliclinic = dispatchPoliclinic;
                }
            }

            let dispatchProcedureDoctorObjectID = that.patientAdmissionFormViewModel.tempDispatchProcedureDoctor;
            if (dispatchProcedureDoctorObjectID != null && (typeof dispatchProcedureDoctorObjectID === 'string')) {
                let dispatchProcedureDoctor = that.patientAdmissionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === dispatchProcedureDoctorObjectID.toString());
                if (dispatchProcedureDoctor) {
                    that.patientAdmissionFormViewModel.tempDispatchProcedureDoctor = dispatchProcedureDoctor;
                }
            }
        }

        let medulaSigortaliTuruObjectID = that.patientAdmissionFormViewModel._PatientAdmission["MedulaSigortaliTuru"];
        if (medulaSigortaliTuruObjectID != null && (typeof medulaSigortaliTuruObjectID === 'string')) {
            let medulaSigortaliTuru = that.patientAdmissionFormViewModel.SigortaliTurus.find(o => o.ObjectID.toString() === medulaSigortaliTuruObjectID.toString());
            if (medulaSigortaliTuru) {
                that.patientAdmissionFormViewModel._PatientAdmission.MedulaSigortaliTuru = medulaSigortaliTuru;
            }
        }

        let externalHospitalObjectID = that.patientAdmissionFormViewModel._PatientAdmission["ExternalHospital"];
        if (externalHospitalObjectID != null && (typeof externalHospitalObjectID === "string")) {
            let externalHospital = that.patientAdmissionFormViewModel.ExternalHospitalDefinitions.find(o => o.ObjectID.toString() === externalHospitalObjectID.toString());
            if (externalHospital) {
                that.patientAdmissionFormViewModel._PatientAdmission.ExternalHospital = externalHospital;
            }
        }

        let medulaIstisnaiHalObjectID = that.patientAdmissionFormViewModel._PatientAdmission["MedulaIstisnaiHal"];
        if (medulaIstisnaiHalObjectID != null && (typeof medulaIstisnaiHalObjectID === 'string')) {
            let medulaIstisnaiHal = that.patientAdmissionFormViewModel.IstisnaiHals.find(o => o.ObjectID.toString() === medulaIstisnaiHalObjectID.toString());
            if (medulaIstisnaiHal) {
                that.patientAdmissionFormViewModel._PatientAdmission.MedulaIstisnaiHal = medulaIstisnaiHal;
            }
        }

        let triageObjectID = that.patientAdmissionFormViewModel._PatientAdmission["Triage"];
        if (triageObjectID != null && (typeof triageObjectID === 'string')) {
            let triage = that.patientAdmissionFormViewModel.SKRSTRIAJKODUs.find(o => o.ObjectID.toString() === triageObjectID.toString());
            if (triage) {
                that.patientAdmissionFormViewModel._PatientAdmission.Triage = triage;
            }
        }
        let admissionTypeObjectID = that.patientAdmissionFormViewModel._PatientAdmission["AdmissionType"];
        if (admissionTypeObjectID != null && (typeof admissionTypeObjectID === 'string')) {
            let admissionType = that.patientAdmissionFormViewModel.ProvizyonTipis.find(o => o.ObjectID.toString() === admissionTypeObjectID.toString());
            if (admissionType) {
                that.patientAdmissionFormViewModel._PatientAdmission.AdmissionType = admissionType;
            }
        }

        let priorityStatusObjectID = that.patientAdmissionFormViewModel._PatientAdmission["PriorityStatus"];
        if (priorityStatusObjectID != null && (typeof priorityStatusObjectID === 'string')) {
            let priorityStatus = that.patientAdmissionFormViewModel.PriorityStatusDefinitions.find(o => o.ObjectID.toString() === priorityStatusObjectID.toString());
            if (priorityStatus) {
                that.patientAdmissionFormViewModel._PatientAdmission.PriorityStatus = priorityStatus;
            }
        }
        let departmentObjectID = that.patientAdmissionFormViewModel._PatientAdmission["Department"];
        if (departmentObjectID != null && (typeof departmentObjectID === 'string')) {
            let department = that.patientAdmissionFormViewModel.ResDepartments.find(o => o.ObjectID.toString() === departmentObjectID.toString());
            if (department) {
                that.patientAdmissionFormViewModel._PatientAdmission.Department = department;
            }
        }
        let buildingObjectID = that.patientAdmissionFormViewModel._PatientAdmission["Building"];
        if (buildingObjectID != null && (typeof buildingObjectID === 'string')) {
            let building = that.patientAdmissionFormViewModel.ResBuildings.find(o => o.ObjectID.toString() === buildingObjectID.toString());
            if (building) {
                that.patientAdmissionFormViewModel._PatientAdmission.Building = building;
            }
            this.buildingObjectID = that.patientAdmissionFormViewModel._PatientAdmission.Building.ObjectID;
        }

        let sKRSAdliVakaObjectID = that.patientAdmissionFormViewModel._PatientAdmission["SKRSAdliVaka"];
        if (sKRSAdliVakaObjectID != null && (typeof sKRSAdliVakaObjectID === 'string')) {
            let sKRSAdliVaka = that.patientAdmissionFormViewModel.SKRSAdliVakaGelisSeklis.find(o => o.ObjectID.toString() === sKRSAdliVakaObjectID.toString());
            if (sKRSAdliVaka) {
                that.patientAdmissionFormViewModel._PatientAdmission.SKRSAdliVaka = sKRSAdliVaka;
            }
        }

        if (that.patientAdmissionFormViewModel.ResourcesToBeReferredGridList) {
            that.patientAdmissionFormViewModel._PatientAdmission.ResourcesToBeReferred = that.patientAdmissionFormViewModel.ResourcesToBeReferredGridList;
            that.patientAdmissionFormViewModel.ResourcesToBeReferredList = that.patientAdmissionFormViewModel.ResourcesToBeReferredGridList;
            for (let detailItem of that.patientAdmissionFormViewModel.ResourcesToBeReferredGridList) {
                let procedureDoctorToBeReferredObjectID = detailItem["ProcedureDoctorToBeReferred"];
                if (procedureDoctorToBeReferredObjectID != null && (typeof procedureDoctorToBeReferredObjectID === 'string')) {
                    let procedureDoctorToBeReferred = that.patientAdmissionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorToBeReferredObjectID.toString());
                    if (procedureDoctorToBeReferred) {
                        detailItem.ProcedureDoctorToBeReferred = procedureDoctorToBeReferred;
                    }
                }
                let resourceObjectID = detailItem["Resource"];
                if (resourceObjectID != null && (typeof resourceObjectID === 'string')) {
                    let resource = that.patientAdmissionFormViewModel.ResSections.find(o => o.ObjectID.toString() === resourceObjectID.toString());
                    if (resource) {
                        detailItem.Resource = resource;
                    }
                }
            }
        }
        let hCRequestReasonObjectID = that.patientAdmissionFormViewModel._PatientAdmission["HCRequestReason"];
        if (hCRequestReasonObjectID != null && (typeof hCRequestReasonObjectID === 'string')) {
            let hCRequestReason = that.patientAdmissionFormViewModel.HCRequestReasons.find(o => o.ObjectID.toString() === hCRequestReasonObjectID.toString());
            if (hCRequestReason) {
                that.patientAdmissionFormViewModel._PatientAdmission.HCRequestReason = hCRequestReason;
            }
            if (hCRequestReason != null) {
                let reasonForExaminationObjectID = hCRequestReason["ReasonForExamination"];
                if (reasonForExaminationObjectID != null && (typeof reasonForExaminationObjectID === 'string')) {
                    let reasonForExamination = that.patientAdmissionFormViewModel.ReasonForExaminationDefinitions.find(o => o.ObjectID.toString() === reasonForExaminationObjectID.toString());
                    if (reasonForExamination) {
                        hCRequestReason.ReasonForExamination = reasonForExamination;
                    }
                }
            }
        }
        let Patient = null;
        if (this._PatientAdmission != null && this._PatientAdmission.Episode != null)
            Patient = this._PatientAdmission.Episode.Patient;
        if (this._PatientAdmission.DispatchType == DispatchTypeEnum.DispatchedProcedure)
            this.showProcedurePopupBtn = true;
        else
            this.showProcedurePopupBtn = false;

        this.updateAvatarPhoto(Patient);
        this.updateRequiredColors();
        this.updatePatientInfoUIComponents(Patient);
        //   this.SetYupassNoProperty();

        if (this._PatientAdmission.ApplicationReason == null)
            this._PatientAdmission.ApplicationReason = ApplicationReasonEnum.Diger;
        if (this._PatientAdmission.PatientClassGroup == null)
            this._PatientAdmission.PatientClassGroup = PatientClassTypeEnum.Sivil;

        if (this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.ImportantPatientInfo !== undefined) {
            if (this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.ImportantPatientInfo != null && this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.ImportantPatientInfo != "") {
                this.showimportantPatientInfo = true;
            }
        }
        if (this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.Mother !== undefined)
            this.babyMotherName = this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.MotherName + ' ' + this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.Surname;
        else
            this.babyMotherName = "";

        if (this.patientAdmissionFormViewModel.openKPSLoginInfo)
            this.isChangePassword = true;

        if (!this.patientAdmissionFormViewModel._PatientAdmission.IsNew)//alınmış kabullerin branşı değiştirilemeyecek
        {
            this.bransDisabled = true;
            this.canPrintHCBarkod = false;
        }
        else
        {
            this.bransDisabled = false;
            this.canPrintHCBarkod = true;
        }
        // this.externalDoctorsGrid2.instance.repaint();
        // this.externalDoctorsGrid2.instance.refresh();
        // let _temp = this.FilterPoliclinicId;
        // this.FilterPoliclinicId = null;
        // this.FilterPoliclinicId = _temp;

        if (this.isNewbornRequired == true) {
            this._PatientAdmission.IsNewBorn = true;
            this.IsNewBorn.ReadOnly = true;
        }

        if (this.patientAdmissionFormViewModel.IsPandemicPatient) {
            // TTVisual.InfoBox.Alert("Bu Hastada Covid-19 şüphesi mevcuttur. Gerekli tedbirleri alınız");
            this.pandemicInfo =" Bu Hasta da Covid-19 şüphesi mevcuttur. Lütfen Gerekli tedbirleri alınız";
        }

        

    }

    public SetYupassNoProperty() {
        if (this.patientAdmissionFormViewModel.tempPayer != null && this.patientAdmissionFormViewModel.tempPayer.Code != null && this.patientAdmissionFormViewModel.tempPayer.Code == 99)//yurtdışı sigorta için yupassno alanı aktif edilir
        {
            this.ForeignUniqueNo.ReadOnly = false;
        }
        else {
            this._PatientAdmission.Episode.Patient.YUPASSNO = null;
            this.ForeignUniqueNo.ReadOnly = true;
        }
    }

    public async saveDispatch(event) {
        this.showProcedurePopup = false;

        //refresh History panel
        await this.btnPatientAdmissionNewSave_Click();
    }

    protected async loadEmptyForm() {

        try {

            let fullApiUrl: string = "";

            fullApiUrl = `${this._EmptyDocumentUrl}`;


            let httpService: NeHttpService = ServiceLocator.NeHttpService;

            let response = await httpService.get<PatientAdmissionFormViewModel>(fullApiUrl, PatientAdmissionFormViewModel);
            this._ViewModel = response;
            this.loadViewModel();


            this.redirectProperties();
            await this.ClientSidePreScript();
            await this.PreScript();
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            this.loadErrorOccurred(err);
        }
    }

    private async onInitialize() {
        await this.loadEmptyForm();
        await this.SearchList_Click();
    }

    public async getProcedureDoctorToBeReferred(PoliclinicID: String): Promise<any> {

        let fullApiUrl = '/api/PatientAdmissionService/GetProcedureDoctorToBeReferred?PoliclinicID=' + PoliclinicID;
        return await this.httpService.get<ResUser>(fullApiUrl);
    }

    ngAfterViewInit() {
        let that = this;
       
        let promiseArray: Array<Promise<any>> = new Array<any>();

        promiseArray.push(this.medulaDefinition.TedaviTuru());
        promiseArray.push(this.medulaDefinition.ProvizyonTipi());
        promiseArray.push(this.medulaDefinition.TedaviTipi());
        promiseArray.push(this.medulaDefinition.TakipTipi());
        promiseArray.push(this.medulaDefinition.Brans());
        promiseArray.push(this.medulaDefinition.DevredilenKurum());
        promiseArray.push(this.medulaDefinition.IstisnaiHal());
        promiseArray.push(this.medulaDefinition.SigortaliTuru());


        Promise.all(promiseArray).then((sonuc: Array<any>) => {

            that.tedaviTuruArray = sonuc[0];
            that.provizyonTipiArray = sonuc[1];
            that.tedaviTipiArray = sonuc[2];
            that.takipTipiArray = sonuc[3];
            that.bransArray = sonuc[4];
            that.devredilenKurumArray = sonuc[5];
            that.istisnaiHalArray = sonuc[6];
            that.sigortaliTuruArray = sonuc[7];

        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
            this.loadErrorOccurred(error);
        });
      
    }

    async ngOnInit() {
        let that = this;

        await that.loadEmptyForm();
           
        let NqlName = "";

        this.leftSideGridDataSource = new DataSource({
            store: new CustomStore({
                key: "Paid",

                load: async (loadOptions: any) => {
                    if (that.patientAdmissionFormViewModel.IsSuperUser == true) {
                        if (that.SearchListWithoutProvision.Value == true) {
                            // this.patientPatientAdmission = (await SubEpisodeProtocolService.GetPAInfoByDateWithoutProvision(this.StartDate, this.EndDate));
                            NqlName="GetPAInfoByDateWithoutProvision";
                        }
                        else if (that.SearchListWithProvision.Value == true) {
                            // this.patientPatientAdmission = (await SubEpisodeProtocolService.GetPAInfoByDateWithProvision(this.StartDate, this.EndDate));
                            NqlName="GetPAInfoByDateWithProvision";
                        }
                        else
                        {
                            // this.patientPatientAdmission = (await SubEpisodeProtocolService.GetAllPatientInfoByDateWithoutUser(this.StartDate, this.EndDate));
                            NqlName="GetAllPatientInfoByDateWithoutUser";
                        }
                    }
                    else {
                        if (that.SearchListWithoutProvision.Value == true) {
                            // this.patientPatientAdmission = (await SubEpisodeProtocolService.GetPAInfoByDateWithoutProvision(this.StartDate, this.EndDate));
                            NqlName="GetPAInfoByDateWithoutProvision";
                        }
                        else if (that.SearchListWithProvision.Value == true) {
                            // this.patientPatientAdmission = (await SubEpisodeProtocolService.GetPAInfoByDateWithProvision(this.StartDate, this.EndDate));
                            NqlName="GetPAInfoByDateWithProvision";
                        }
                        else
                        {
                            NqlName="GetAllPatientInfoByDate";
                        }
                            // this.patientPatientAdmission = (await SubEpisodeProtocolService.GetAllPatientInfoByDate(this.StartDate, this.EndDate));
                    }

                    let filterPol:ResPoliclinic;

                    if (that.FilterPoliclinicId != null) {
                        filterPol = that.patientAdmissionFormViewModel.PoliclinicListForFilter.find(o => o.ObjectID.toString() === that.FilterPoliclinicId.toString());
                    }

                    loadOptions.Params = {
                        StartDate: that.StartDate,
                        EndDate: that.EndDate,
                        NqlName: NqlName,
                        Policlinic: filterPol != null ? filterPol.Name : ''
                    }

                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 50;
                    }

                    var result = await this.httpService.post<any>("/api/PatientAdmissionService/getPaList", loadOptions);
                    //    return this.LoadPatientListView(yy.data);
                    // this.LoadPatientListView(yy.data);
                    let paCount = 0;
                    
                    if(result.totalCount > 0)
                        paCount = result.totalCount;
                    else if (result.totalCount == 0 && that.leftSideGridDataSource.totalCount() > 0 )//sayfa değişince nedense 0 geliyor
                        paCount = that.leftSideGridDataSource.totalCount();

                    if (that.patientAdmissionFormViewModel.GetTotalSepCount == true) {
                        let totalCount = (await SubEpisodeProtocolService.GetSepCountByDate(that.StartDate, that.EndDate));
                        that.patientAdmissionFormViewModel.SEPCount = paCount.toString() + " / " + totalCount.toString();
                    }
                    else
                        that.patientAdmissionFormViewModel.SEPCount = paCount.toString();
            
                    that.globalSepCount = that.patientAdmissionFormViewModel.SEPCount;
                    return result;

                },
            }),
            paginate: true,
            pageSize: 50
        });
        // this.SearchList_Click();
    }

    SubmitPatientViewModel(p: PatientCompareFormViewModel) {
        this._PatientAdmission.Episode.Patient = p._Patient;
        // this._PatientAdmission.PA_Address.HomeAddress = p.HomeAddress;
        this.patientAdmissionFormViewModel.tempHomeAddress = p._KPSInfo.HomeAddress;
        // this._PatientAdmission.PA_Address.HomeAddress = p._KPSInfo.HomeAddress;        
        this.patientAdmissionFormViewModel.tempName = p._Patient.Name;
        this.patientAdmissionFormViewModel.tempSurname = p._Patient.Surname;
        this.patientAdmissionFormViewModel.tempUniqueRefNo = p._Patient.UniqueRefNo;
    }

    public async onAcilTriajChanged(event) {

        if (this._PatientAdmission != null && this._PatientAdmission.Triage != event) {
            this._PatientAdmission.Triage = event;

            if (event == null)
                event = new SKRSTRIAJKODU();
        }
        await this.SetTriageColor(event);
    }

    public async SetTriageColor(event) {
        if (event != null) {
            if (event.KODU == "1") {
                this.AcilTriaj.BackColor = "#84e684";
                this.AcilTriaj.ForeColor = "#000000";
            }
            else if (event.KODU == "2") {
                this.AcilTriaj.BackColor = "#f1f10b";
                this.AcilTriaj.ForeColor = "#000000";
            }
            else if (event.KODU == "3") {
                this.AcilTriaj.BackColor = "#ff5d5d";
                this.AcilTriaj.ForeColor = "#000000";
            }
            else if (event.KODU == "4") {
                this.AcilTriaj.BackColor = "#423939";
                this.AcilTriaj.ForeColor = "#ffffff";
            }
            else {
                this.AcilTriaj.BackColor = "#ffffff";
                this.AcilTriaj.ForeColor = "#000000";
            }
        }
        else {
            this.AcilTriaj.BackColor = "#ffffff";
            this.AcilTriaj.ForeColor = "#000000";
        }
    }

    public getParamsForDocumentUpload(): ClickFunctionParams {
        if (this.patientAdmissionFormViewModel.episodeAction == null) {
            ServiceLocator.MessageService.showError("Hasta kabulü seçilmeden doküman eklenemez");
            return;
        }

        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this.patientAdmissionFormViewModel.episodeAction.ObjectID, this.patientAdmissionFormViewModel._PatientAdmission.Episode.ObjectID, this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.ObjectID));
        return clickFunctionParams;
    }

    public getClickFunctionParams(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this.patientAdmissionFormViewModel.episodeAction.ObjectID, this.patientAdmissionFormViewModel._PatientAdmission.Episode.ObjectID, this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.ObjectID));
        return clickFunctionParams;
    }

    public getShowAppointmentParams(): ClickFunctionParams {
        let model: ClickFunctionParams = new ClickFunctionParams(this, new GiveAppointmentModel(null, this._PatientAdmission));
        return model;
    }

    private AddHelpMenu() {

        this.RemoveMenuFromHelpMenu();

        let takipAl = new DynamicSidebarMenuItem();
        takipAl.key = 'takipal';
        takipAl.label = i18n("M22634", "Takip Al");
        takipAl.icon = 'ai ai-takip-al';
        takipAl.componentInstance = this;
        takipAl.clickFunction = this.takipAl;
        this.sideBarMenuService.addMenu('YardimciMenu', takipAl);

        let bagliTakipAl = new DynamicSidebarMenuItem();
        bagliTakipAl.key = 'bagliTakipAl';
        bagliTakipAl.icon = 'ai ai-bagli-takip-al';
        bagliTakipAl.label = i18n("Get Linked Follow-up", 'Bağlı Takip Al');
        bagliTakipAl.componentInstance = this;
        bagliTakipAl.clickFunction = this.bagliTakipAl;
        this.sideBarMenuService.addMenu('YardimciMenu', bagliTakipAl);

        let takipsil = new DynamicSidebarMenuItem();
        takipsil.key = i18n("M22683", "takipsil");
        takipsil.label = i18n("M22668", "Takip Sil");
        takipsil.icon = 'ai ai-takip-sil';
        takipsil.componentInstance = this;
        takipsil.clickFunction = this.takipSil;
        this.sideBarMenuService.addMenu('YardimciMenu', takipsil);

        let takipOku = new DynamicSidebarMenuItem();
        takipOku.key = 'takipOku';
        takipOku.icon = 'ai ai-takip-oku';
        takipOku.label = i18n("M22663", "Takip Oku");
        takipOku.componentInstance = this;
        takipOku.clickFunction = this.takipOku;
        this.sideBarMenuService.addMenu('YardimciMenu', takipOku);

        let fazlaTakipOku = new DynamicSidebarMenuItem();
        fazlaTakipOku.key = 'fazlaTakipOku';
        fazlaTakipOku.label = i18n("M14279", "Fazla Takipleri Oku");
        fazlaTakipOku.icon = 'ai ai-fazla-takip-oku';
        fazlaTakipOku.componentInstance = this;
        fazlaTakipOku.clickFunction = this.fazlaTakipOku;
        this.sideBarMenuService.addMenu('YardimciMenu', fazlaTakipOku);

        let printBarcode = new DynamicSidebarMenuItem();
        printBarcode.key = 'printBarcode';
        printBarcode.label = i18n("M30704", 'Barkod Bas');
        printBarcode.icon = 'ai ai-barkod-bas';
        printBarcode.componentInstance = this;
        printBarcode.clickFunction = this.printBarcodeFromHelpMenu;
        this.sideBarMenuService.addMenu('Barkod', printBarcode);


        let labResult = new DynamicSidebarMenuItem();
        labResult.key = 'labResult';
        labResult.label = 'Laboratuar Sonuç Raporu';
        labResult.icon = 'ai ai-barkod-bas';
        labResult.componentInstance = this;
        labResult.clickFunction = this.LabResult;
        this.sideBarMenuService.addMenu('YardimciMenu', labResult);

        let radResult = new DynamicSidebarMenuItem();
        radResult.key = 'radResult';
        radResult.label = 'Radyoloji Sonuç Raporu';
        radResult.icon = 'ai ai-barkod-bas';
        radResult.componentInstance = this;
        radResult.clickFunction = this.RadResult;
        this.sideBarMenuService.addMenu('YardimciMenu', radResult);

        let printResultBarcode = new DynamicSidebarMenuItem();
        printResultBarcode.key = 'printResultBarcode';
        printResultBarcode.label = i18n("M30804", 'Sonuç Barkodu Bas');
        printResultBarcode.icon = 'ai ai-sonuc-barkodu';
        printResultBarcode.componentInstance = this;
        printResultBarcode.clickFunction = this.printResultBarcode;
        this.sideBarMenuService.addMenu('Barkod', printResultBarcode);

        let changePayer = new DynamicSidebarMenuItem();
        changePayer.key = 'changePayer';
        changePayer.label = i18n("M18039", "Kurum Değiştir");
        changePayer.icon = 'ai ai-kurum-degistir';
        changePayer.componentInstance = this;
        changePayer.clickFunction = this.changePayer;
        this.sideBarMenuService.addMenu('YardimciMenu', changePayer);

        let openMernisInfoCompare = new DynamicSidebarMenuItem();
        openMernisInfoCompare.key = 'openMernisInfoCompare';
        openMernisInfoCompare.label = i18n("M17851", "KPS Karşılaştır");
        openMernisInfoCompare.icon = 'fa fa-balance-scale';
        openMernisInfoCompare.componentInstance = this;
        openMernisInfoCompare.clickFunction = this.openMernisInfoCompare;
        this.sideBarMenuService.addMenu('YardimciMenu', openMernisInfoCompare);

        let onClickShowMatchBabyMother = new DynamicSidebarMenuItem();
        onClickShowMatchBabyMother.key = 'onClickShowMatchBabyMother';
        onClickShowMatchBabyMother.label = i18n("M11043", "Anne Eşleştir");
        onClickShowMatchBabyMother.icon = 'ai ai-anne-eslestir';
        onClickShowMatchBabyMother.componentInstance = this;
        onClickShowMatchBabyMother.clickFunction = this.onClickShowMatchBabyMother;
        this.sideBarMenuService.addMenu('YardimciMenu', onClickShowMatchBabyMother);

        let btnEvdeSaglikSorgulaSil_Clicked = new DynamicSidebarMenuItem();
        btnEvdeSaglikSorgulaSil_Clicked.key = 'btnEvdeSaglikSorgulaSil_Clicked';
        btnEvdeSaglikSorgulaSil_Clicked.label = i18n("M14011", "Evde Sağlık Sorgula/Sil");
        btnEvdeSaglikSorgulaSil_Clicked.icon = 'ai ai-evde-saglik';
        btnEvdeSaglikSorgulaSil_Clicked.componentInstance = this;
        btnEvdeSaglikSorgulaSil_Clicked.clickFunction = this.btnEvdeSaglikSorgulaSil_Clicked;
        this.sideBarMenuService.addMenu('YardimciMenu', btnEvdeSaglikSorgulaSil_Clicked);

        let onClickShowDeletePatientAdmission = new DynamicSidebarMenuItem();
        onClickShowDeletePatientAdmission.key = 'onClickShowDeletePatientAdmission';
        onClickShowDeletePatientAdmission.label = i18n("M17030", "Kabul Sil");
        onClickShowDeletePatientAdmission.icon = 'ai ai-kabul-sil';
        onClickShowDeletePatientAdmission.componentInstance = this;
        onClickShowDeletePatientAdmission.clickFunction = this.onClickShowDeletePatientAdmission;
        this.sideBarMenuService.addMenu('YardimciMenu', onClickShowDeletePatientAdmission);

        let mergePatient_Click = new DynamicSidebarMenuItem();
        mergePatient_Click.key = 'mergePatient_Click';
        mergePatient_Click.label = i18n("M13251", "Dosya Birleştir");
        mergePatient_Click.icon = 'ai ai-dosya-birlestir';
        mergePatient_Click.componentInstance = this;
        mergePatient_Click.clickFunction = this.mergePatient_Click;
        this.sideBarMenuService.addMenu('YardimciMenu', mergePatient_Click);

        let btnEvdeSaglikHizmetleri_Clicked = new DynamicSidebarMenuItem();
        btnEvdeSaglikHizmetleri_Clicked.key = 'btnEvdeSaglikHizmetleri_Clicked';
        btnEvdeSaglikHizmetleri_Clicked.icon = 'ai ai-evde-saglik';
        btnEvdeSaglikHizmetleri_Clicked.label = i18n("M14009", "Evde Sağlık Kaydet");
        btnEvdeSaglikHizmetleri_Clicked.componentInstance = this;
        btnEvdeSaglikHizmetleri_Clicked.clickFunction = this.btnEvdeSaglikHizmetleri_Clicked;
        this.sideBarMenuService.addMenu('YardimciMenu', btnEvdeSaglikHizmetleri_Clicked);

        let btnEvdeSaglikHizmetEmirlerim_Clicked = new DynamicSidebarMenuItem();
        btnEvdeSaglikHizmetEmirlerim_Clicked.key = 'btnEvdeSaglikHizmetEmirlerim_Clicked';
        btnEvdeSaglikHizmetEmirlerim_Clicked.icon = 'ai ai-evde-saglik';
        btnEvdeSaglikHizmetEmirlerim_Clicked.label = i18n("M13994", "Evde Sağlık Hizmet Emirleri");
        btnEvdeSaglikHizmetEmirlerim_Clicked.componentInstance = this;
        btnEvdeSaglikHizmetEmirlerim_Clicked.clickFunction = this.btnEvdeSaglikHizmetEmirlerim_Clicked;
        this.sideBarMenuService.addMenu('YardimciMenu', btnEvdeSaglikHizmetEmirlerim_Clicked);

        let Patient_Click = new DynamicSidebarMenuItem();
        Patient_Click.key = 'Patient_Click';
        Patient_Click.label = i18n("M11099", "Arşiv Kartı");
        Patient_Click.icon = 'ai ai-arsiv-karti';
        Patient_Click.componentInstance = this;
        Patient_Click.clickFunction = this.Patient_Click;
        this.sideBarMenuService.addMenu('YardimciMenu', Patient_Click);

        //let DispatchAdmission_Click = new DynamicSidebarMenuItem();
        //DispatchAdmission_Click.key = 'DispatchAdmission_Click';
        //DispatchAdmission_Click.label = 'Hizmet Protokol';
        //DispatchAdmission_Click.componentInstance = this;
        //DispatchAdmission_Click.clickFunction = this.DispatchAdmission_Click;
        //this.sideBarMenuService.addMenu('YardimciMenu', DispatchAdmission_Click);

        let onClickOpenIncidentDisasterInfo = new DynamicSidebarMenuItem();
        onClickOpenIncidentDisasterInfo.key = 'onClickOpenIncidentDisasterInfo';
        onClickOpenIncidentDisasterInfo.icon = 'ai ai-olay-afet';
        onClickOpenIncidentDisasterInfo.label = i18n("M19634", "Olay Afet Bilgisi");
        onClickOpenIncidentDisasterInfo.componentInstance = this;
        onClickOpenIncidentDisasterInfo.clickFunction = this.openIncidentDisasterInfo;

        this.sideBarMenuService.addMenu('YardimciMenu', onClickOpenIncidentDisasterInfo);


        let patientDocumentUpload = new DynamicSidebarMenuItem();
        patientDocumentUpload.key = 'patientDocumentUpload';
        patientDocumentUpload.icon = 'ai ai-hasta-dokuman-ekle';
        patientDocumentUpload.label = i18n("M15178", "Hasta Dokümanı Ekle");
        patientDocumentUpload.componentInstance = this.helpMenuService;
        patientDocumentUpload.clickFunction = this.helpMenuService.patientDocumentUpload;
        patientDocumentUpload.parameterFunctionInstance = this;
        patientDocumentUpload.getParamsFunction = this.getParamsForDocumentUpload;
        patientDocumentUpload.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', patientDocumentUpload);

        if (this.patientAdmissionFormViewModel.hasDoctorKotaRole) {
            let docorQuota = new DynamicSidebarMenuItem();
            docorQuota.key = 'docorQuota';
            docorQuota.label = i18n("M15178", "Doktor Kota");
            docorQuota.icon = 'ai ai-doktor-kota';
            docorQuota.componentInstance = this.helpMenuService;
            docorQuota.clickFunction = this.helpMenuService.openDoctorQuota;
            this.sideBarMenuService.addMenu('YardimciMenu', docorQuota);
        }

        let VerifiedKPS = new DynamicSidebarMenuItem();
        VerifiedKPS.key = 'VerifiedKPS';
        VerifiedKPS.label = i18n("M15178", "Mernis Doğrula");
        VerifiedKPS.icon = 'ai ai-greencheckmark';
        VerifiedKPS.componentInstance = this;
        VerifiedKPS.clickFunction = this.verifiedKPSInfo;
        this.sideBarMenuService.addMenu('YardimciMenu', VerifiedKPS);

        ///BEGIN RAPORLAR

        let onMedulaReports = new DynamicSidebarMenuItem();
        onMedulaReports.key = 'onMedulaReports';
        onMedulaReports.icon = 'fa fa-file-text-o';
        onMedulaReports.label = i18n("M18801", "Medula Raporları");
        onMedulaReports.componentInstance = this;
        onMedulaReports.clickFunction = this.onMedulaReports;
        this.sideBarMenuService.addMenu('ReportMainItem', onMedulaReports);

        let medulaResultReport = new DynamicSidebarMenuItem();
        medulaResultReport.key = 'medulaResultReport';
        medulaResultReport.icon = 'fa fa-file-text-o';
        medulaResultReport.label = "Medula Sonuc Kodu Raporu";
        medulaResultReport.componentInstance = this;
        medulaResultReport.clickFunction = this.openMedulaProvisionReport;
        this.sideBarMenuService.addMenu('ReportMainItem', medulaResultReport);

        let EK8Report = new DynamicSidebarMenuItem();
        EK8Report.key = 'EK8Report';
        EK8Report.icon = 'ai ai-EK8';
        EK8Report.label = "EK-8 Formu";
        EK8Report.componentInstance = this;
        EK8Report.clickFunction = this.openEK8Report;
        this.sideBarMenuService.addMenu('ReportMainItem', EK8Report);

        let onMHRSAppointmentsReport = new DynamicSidebarMenuItem();
        onMHRSAppointmentsReport.key = 'onMHRSAppointmentsReport';
        onMHRSAppointmentsReport.icon = 'fa fa-file-text-o';
        onMHRSAppointmentsReport.label = "MHRS Randevu Listesi";
        onMHRSAppointmentsReport.componentInstance = this;
        onMHRSAppointmentsReport.clickFunction = this.onMHRSAppointmentsReport;
        this.sideBarMenuService.addMenu('ReportMainItem', onMHRSAppointmentsReport);

        let PatientListReport = new DynamicSidebarMenuItem();
        PatientListReport.key = 'PatientListReport';
        PatientListReport.icon = 'fa fa-file-text-o';
        PatientListReport.label = "Geliş Sebebine Göre Hasta Listesi";
        PatientListReport.componentInstance = this;
        PatientListReport.clickFunction = this.openPatientListReportPopup;
        this.sideBarMenuService.addMenu('ReportMainItem', PatientListReport);


        let onMHRSAppointmentTimeIsPastReport = new DynamicSidebarMenuItem();
        onMHRSAppointmentTimeIsPastReport.key = 'onMHRSAppointmentTimeIsPastReport';
        onMHRSAppointmentTimeIsPastReport.icon = 'fa fa-file-text-o';
        onMHRSAppointmentTimeIsPastReport.label = "MHRS Randevu Saati Geçmiş Randevular Listesi";
        onMHRSAppointmentTimeIsPastReport.componentInstance = this;
        onMHRSAppointmentTimeIsPastReport.clickFunction = this.onMHRSAppointmentTimeIsPastReport;
        this.sideBarMenuService.addMenu('ReportMainItem', onMHRSAppointmentTimeIsPastReport);

        let masrafIadeFormu = new DynamicSidebarMenuItem();
        masrafIadeFormu.key = 'MasrafIadeFormu';
        masrafIadeFormu.icon = 'fas fa-lira-sign';
        masrafIadeFormu.label = "Masraf İade Formu";
        masrafIadeFormu.componentInstance = this;
        masrafIadeFormu.clickFunction = this.masrafIadeRaporu;
        this.sideBarMenuService.addMenu('ReportMainItem', masrafIadeFormu);

        if (this.patientAdmissionFormViewModel.canGetEpicrisisReport) {
            let printEpicrisisForm = new DynamicSidebarMenuItem();
            printEpicrisisForm.key = 'epicrisisForm';
            printEpicrisisForm.icon = 'fa fa-file-text-o';
            printEpicrisisForm.label = 'Epikriz Formu';
            printEpicrisisForm.componentInstance = this;
            printEpicrisisForm.clickFunction = this.openEpicrisisReport;
            this.sideBarMenuService.addMenu('ReportMainItem', printEpicrisisForm);
        }

        ///END RAPORLAR

        if (this.patientAdmissionFormViewModel.hasGiveAppointmentRole) {
            let giveAppointment = new DynamicSidebarMenuItem();
            giveAppointment.key = 'giveAppointment';
            giveAppointment.label = i18n("M20749", "Randevu Ver");
            giveAppointment.icon = 'fa fa-calendar-check-o';
            giveAppointment.componentInstance = this.helpMenuService;
            giveAppointment.clickFunction = this.helpMenuService.showAppointmentForm;
            giveAppointment.getParamsFunction = this.getShowAppointmentParams;
            giveAppointment.parameterFunctionInstance = this;
            giveAppointment.ParentInstance = this;
            //giveAppointment.functionParams = model;
            this.sideBarMenuService.addMenu('YardimciMenu', giveAppointment);
        }

        let mergeEmergencyIntervention = new DynamicSidebarMenuItem();
        mergeEmergencyIntervention.key = 'mergeEmergencyIntervention';
        mergeEmergencyIntervention.label = 'Acil Kabul Birleştir';
        mergeEmergencyIntervention.icon = 'fa fa-calendar-check-o';
        mergeEmergencyIntervention.componentInstance = this;
        mergeEmergencyIntervention.clickFunction = this.getEmergencyPolList;
        // mergeEmergencyIntervention.getParamsFunction = this.getShowAppointmentParams;
        // mergeEmergencyIntervention.parameterFunctionInstance = this;
        mergeEmergencyIntervention.ParentInstance = this;
        //giveAppointment.functionParams = model;
        this.sideBarMenuService.addMenu('YardimciMenu', mergeEmergencyIntervention);

        let openEmergencyIntervention = new DynamicSidebarMenuItem();
        openEmergencyIntervention.key = 'openEmergencyIntervention';
        openEmergencyIntervention.icon = 'fas fa-user-md';
        openEmergencyIntervention.label = i18n("M14009", "Triaj Ekranını Aç");
        openEmergencyIntervention.componentInstance = this;
        openEmergencyIntervention.clickFunction = this.getEmergencyInterventionList;
        this.sideBarMenuService.addMenu('YardimciMenu', openEmergencyIntervention);

        let openWorkablePaperPopUp = new DynamicSidebarMenuItem();
        openWorkablePaperPopUp.key = 'openWorkablePaperPopUp';
        openWorkablePaperPopUp.icon = 'fa fa-file-text-o';
        openWorkablePaperPopUp.label = i18n("M14009", "İşbaşı Çalışabilir Kağıdı");
        openWorkablePaperPopUp.componentInstance = this;
        openWorkablePaperPopUp.clickFunction = this.showWorkableReportPopUp;
        this.sideBarMenuService.addMenu('ReportMainItem', openWorkablePaperPopUp);

        let patientArchieveBarcode = new DynamicSidebarMenuItem();
        patientArchieveBarcode.key = 'patientArchieveBarcode';
        patientArchieveBarcode.icon = 'ai ai-barkod-bas';
        patientArchieveBarcode.label = "Arşiv Barkodu";
        patientArchieveBarcode.componentInstance = this;
        patientArchieveBarcode.clickFunction = this.printPatientArchieveBarcode;
        this.sideBarMenuService.addMenu('Barkod', patientArchieveBarcode);

        let sevkNoSorgula = new DynamicSidebarMenuItem();
        sevkNoSorgula.key = 'sevkNoSorgula';
        sevkNoSorgula.label = 'Kurum Sevk Talep Numarası';
        sevkNoSorgula.icon = 'fas fa-search';
        sevkNoSorgula.componentInstance = this;
        sevkNoSorgula.clickFunction = this.SevkNoSorgula;
        this.sideBarMenuService.addMenu('YardimciMenu', sevkNoSorgula);

        let hastaTemasDurumu = new DynamicSidebarMenuItem();
        hastaTemasDurumu.key = 'hastaTemasDurumu';
        hastaTemasDurumu.icon = 'ai ai-virus';
        hastaTemasDurumu.label = "Hasta Temas Durumu";
        hastaTemasDurumu.componentInstance = this;
        hastaTemasDurumu.clickFunction = this.CheckPatientContactStatus;
        this.sideBarMenuService.addMenu('YardimciMenu', hastaTemasDurumu);

    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('sevkNoSorgula');
        this.sideBarMenuService.removeMenu('radResult');
        this.sideBarMenuService.removeMenu('labResult');
        this.sideBarMenuService.removeMenu('giveAppointment');
        this.sideBarMenuService.removeMenu('takipal');
        this.sideBarMenuService.removeMenu('bagliTakipAl');
        this.sideBarMenuService.removeMenu(i18n("M22683", "takipsil"));
        this.sideBarMenuService.removeMenu('takipOku');
        this.sideBarMenuService.removeMenu('fazlaTakipOku');
        //  this.sideBarMenuService.removeMenu('lisResult');
        this.sideBarMenuService.removeMenu('printBarcode');
        this.sideBarMenuService.removeMenu('printResultBarcode');
        this.sideBarMenuService.removeMenu('changePayer');
        this.sideBarMenuService.removeMenu('openMernisInfoCompare');
        this.sideBarMenuService.removeMenu('onClickShowMatchBabyMother');
        this.sideBarMenuService.removeMenu('btnEvdeSaglikSorgulaSil_Clicked');
        this.sideBarMenuService.removeMenu('onClickShowDeletePatientAdmission');
        this.sideBarMenuService.removeMenu('mergePatient_Click');
        this.sideBarMenuService.removeMenu('onMedulaReports');
        this.sideBarMenuService.removeMenu('medulaResultReport');        
        this.sideBarMenuService.removeMenu('onMHRSAppointmentsReport');
        this.sideBarMenuService.removeMenu('PatientListReport');
        this.sideBarMenuService.removeMenu('onMHRSAppointmentTimeIsPastReport');
        this.sideBarMenuService.removeMenu('btnEvdeSaglikHizmetleri_Clicked');
        this.sideBarMenuService.removeMenu('btnEvdeSaglikHizmetEmirlerim_Clicked');
        this.sideBarMenuService.removeMenu('Patient_Click');
        this.sideBarMenuService.removeMenu('patientDocumentUpload');
        //this.sideBarMenuService.removeMenu('DispatchAdmission_Click');
        this.sideBarMenuService.removeMenu('onClickOpenIncidentDisasterInfo');
        this.sideBarMenuService.removeMenu('docorQuota');
        this.sideBarMenuService.removeMenu('EK8Report');
        this.sideBarMenuService.removeMenu('VerifiedKPS');
        this.sideBarMenuService.removeMenu('epicrisisForm');
        this.sideBarMenuService.removeMenu('mergeEmergencyIntervention');
        this.sideBarMenuService.removeMenu('MasrafIadeFormu');
        this.sideBarMenuService.removeMenu('openEmergencyIntervention');
        this.sideBarMenuService.removeMenu('openWorkablePaperPopUp');
        this.sideBarMenuService.removeMenu('hastaTemasDurumu');

    }

    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();

        if (this.saveEventSubscription != null) {
            this.saveEventSubscription.unsubscribe();
        }
    }

    public onMedulaVakaTarihiChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.MedulaVakaTarihi != event) {
            this._PatientAdmission.MedulaVakaTarihi = event;
        }

    }
    public onActionDateChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.ActionDate != event) {
            this._PatientAdmission.ActionDate = event;
        }

    }
    public ontxtMotherUniqueRefNoChanged(event): void {
        if (event != null) {
            if (this._PatientAdmission != null &&
                this._PatientAdmission.Episode != null &&
                this._PatientAdmission.Episode.Patient != null &&
                this._PatientAdmission.Episode.Patient.Mother != null && this._PatientAdmission.Episode.Patient.Mother.UniqueRefNo != event) {
                this._PatientAdmission.Episode.Patient.Mother.UniqueRefNo = event;
            }
        }
    }
    public onAdmissionTypeChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.AdmissionType != event) {
            this._PatientAdmission.AdmissionType = event;
        }

    }
    public onSKRSAdliVakaChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.SKRSAdliVaka != event) {
            this._PatientAdmission.SKRSAdliVaka = event;
        }

    }
    public onSKRSYabanciHastaChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.SKRSYabanciHasta != event) {
            this._PatientAdmission.Episode.Patient.SKRSYabanciHasta = event;
        }

    }
    public onAnlasmaliKurumChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.Protocol != event) {
            this._PatientAdmission.Protocol = event;
        }

    }

    public onBDYearOnlyChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.BDYearOnly != event) {
            this._PatientAdmission.Episode.Patient.BDYearOnly = event;
        }

    }

    public daysinMonthfromInput(year: number, month: number): number {
        return (new Date(year, month - 1, 1)).daysinMonth();
    }

    public DateDiff(Date1: Date, Date2: Date): number {
        if (Date1 < Date2) {
            let tempDate: Date = Date1;
            Date1 = Date2;
            Date2 = tempDate;
        }
        let _years: number = <number>(Date1.Year - Date2.Year);
        let _months: number = <number>(Date1.Month - Date2.Month);
        let _days: number = <number>(Date1.Day - Date2.Day);
        let _date1Year: number = Date1.Year;
        let _date1Month: number = Date1.Month;
        while (_days < 0) {
            _months--;
            _days += this.daysinMonthfromInput(_date1Year, _date1Month);
            _date1Month--;
            if (_date1Month < 1) {
                _date1Month = 12;
                _date1Year--;
            }
        }
        while (_months < 0) {
            _years--;
            _months += 12;
        }

        let ts: Date; //= Date1.Subtract(Date2);
        return <number>ts.TotalDays;

    }

    public onBirthDateChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.BirthDate != event) {
            this._PatientAdmission.Episode.Patient.BirthDate = event;
            if (event != null) {
                this.BirthDate.BackColor = "white";
                const today = new Date();
                let patientAge = today.getFullYear() - (this._PatientAdmission.Episode.Patient.BirthDate).getFullYear();
                this.stringPatientAge = patientAge.toString();
            }
        }

    }
    public onAgeChanged(event): void {
        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.Age != event) {
            this._PatientAdmission.Episode.Patient.Age = event;
        }
    }

    public onBloodGroupChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.BloodGroupType != event) {
            this._PatientAdmission.Episode.Patient.BloodGroupType = event;
        }

    }


    public onOtherBirthPlaceChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.OtherBirthPlace != event) {
            this._PatientAdmission.Episode.Patient.OtherBirthPlace = event;
            if (event != null)
                this.OtherBirthPlace.BackColor = "white";
        }

    }

    public onCityOfBirthChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.BirthPlace != event) {
            this._PatientAdmission.Episode.Patient.BirthPlace = event;
            if (event != null)
                this.CityOfBirth.BackColor = "white";

        }

    }

    public onCityOfRegistryChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.CityOfRegistry != event) {
            this._PatientAdmission.Episode.Patient.CityOfRegistry = event;
        }

    }

    public onMedulaSonucMesajiChanged(event): void {


    }

    public onDispatchedConsultationDefChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.DispatchedConsultationDef != event) {
            this._PatientAdmission.DispatchedConsultationDef = event;
        }

    }
    public onDispatchEmergencyConsChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.DispatchEmergencyCons != event) {
            this._PatientAdmission.DispatchEmergencyCons = event;
        }

    }
    public onDispatchHospitalDoctorsChanged(event): void {

        if (this.patientAdmissionFormViewModel.tempDispatchProcedureDoctor != event) {
            this.patientAdmissionFormViewModel.tempDispatchProcedureDoctor = event;
        }
        if (this.patientAdmissionFormViewModel.tempPoliclinic == null)
            this.triggerLoadParentsComboBoxByProcedureDoctor(event, true);
    }

    public onDispatchHospitalListChanged(event): void {

        if (this.patientAdmissionFormViewModel.tempDispatchPayer != event) {
            this.patientAdmissionFormViewModel.tempDispatchPayer = event;
        }

    }

    public onDispatchHospitalResourcesChanged(event): void {

        if (this.patientAdmissionFormViewModel.tempDispatchPoliclinic != event) {
            this.patientAdmissionFormViewModel.tempDispatchPoliclinic = event;
        }
        this.triggerLoadParentsComboBoxByPoliclinic(event, true);
        this.triggerLoadChildComboBoxByPoliclinic(event, true);
    }

    public onDispatchTypeChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.DispatchType != event) {
            this._PatientAdmission.DispatchType = event;
            if (this._PatientAdmission.DispatchType == DispatchTypeEnum.DispatchedProcedure)//Sevkli tetkik türü seçilmiş ise tahlil-tanı ekranı açılır
            {
                this.showProcedurePopupBtn = true;
                this._PatientAdmission.DispatchEmergencyCons = null;
                this._PatientAdmission.DispatchedConsultationDef = null;

            }
            else {
                this.showProcedurePopupBtn = false;
            }
        }
    }
    getActivePassive(tabnumber: number): string {
        if (this.patientAdmissionFormViewModel.activeTab !== 0) {
            if (this.patientAdmissionFormViewModel.activeTab === tabnumber)
                return 'active';
            else
                return '';
        } else
            return 'active';

    }

    getActivePassivePane(tabnumber: number): string {
        if (this.patientAdmissionFormViewModel.activeTab !== 0) {
            if (this.patientAdmissionFormViewModel.activeTab === tabnumber)
                return 'tab-pane fade in active';
            else
                return 'tab-pane fade';
        } else
            return 'tab-pane fade';
    }

    clickMainScreen() {
        this.patientAdmissionFormViewModel.activeTab = 1;

    }
    clickDispatchingAdmission() {
        this.patientAdmissionFormViewModel.activeTab = 2;
    }
    clickBoardOfHealth() {
        this.patientAdmissionFormViewModel.activeTab = 3;
    }
    public canShowMainScreen(): boolean {
        if (this.patientAdmissionFormViewModel._PatientAdmission.IsNew != false)
            return this.patientAdmissionFormViewModel.MainTabActive;
        else
            return (this.patientAdmissionFormViewModel.MainTabActive && this.patientAdmissionFormViewModel.activeTab == 1)
    }

    public canShowDispatchingAdmission(): boolean {
        if (this.patientAdmissionFormViewModel._PatientAdmission.IsNew != false)
            return this.patientAdmissionFormViewModel.DispatchTabActive;
        else
            return (this.patientAdmissionFormViewModel.MainTabActive && this.patientAdmissionFormViewModel.activeTab == 2)
    }

    public canShowBoardOfHealth(): boolean {
        if (this.patientAdmissionFormViewModel._PatientAdmission.IsNew != false)
            return this.patientAdmissionFormViewModel.HealthCommissionTabActive;
        else
            return (this.patientAdmissionFormViewModel.MainTabActive && this.patientAdmissionFormViewModel.activeTab == 3)
    }
    async btnProcedureRequest_Click() {
        //Tetkik&tahlil girişi yapılabilmesi için
        //Viewmodelin içerisinde fired edilmiş DispatchExamination objesi yok ise serverda yaratılıp,kaydedilip,client a geri dönmeli
        //bunun için Pa kaydedilmeli
        if (this.patientAdmissionFormViewModel.tempUniqueRefNo == null) {
            ServiceLocator.MessageService.showError(i18n("M134", "Hasta bilgisini giriniz."));
        }
        else if (this.patientAdmissionFormViewModel.tempDispatchPayer == null) {
            ServiceLocator.MessageService.showError(i18n("M134", "XXXXXX bilgisini giriniz."));
        }
        else {


            this.btnPatientAdmissionSave_Click().then(
                x => {
                    let a = x;
                    this.getDispatchExamination();
                }
            ).catch(error => {
                this.messageService.showError(error);

            });


        }

    }
    async getDispatchExamination() {
        if (this.patientAdmissionFormViewModel.StarterEpisodeAction == null) {
            ServiceLocator.MessageService.showError(i18n("M134", "Başlatılmış Sevk nesnesi bulunamadı.Bilgi işlemi arayınız."));
        }
        else {
            this.showProcedurePopup = true;
        }
    }

    public onExDateChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.ExDate != event) {
            this._PatientAdmission.Episode.Patient.ExDate = event;
            if (event == null)
                this.ExDate.BackColor = "white";
        }

    }

    public onExternalHospitalChanged(event): void {
        if (this._PatientAdmission != null && this._PatientAdmission.ExternalHospital != event) {
            this._PatientAdmission.ExternalHospital = event;
        }
    }

    public onDeathReportNoChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.DeathReportNo != event) {
            this._PatientAdmission.Episode.Patient.DeathReportNo = event;
            if (event == null)
                this.DeathReportNo.BackColor = "white";
        }

    }

    public onAliveChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.Death != event) {
            this._PatientAdmission.Episode.Patient.Death = event;

            if (event == true) {
                this._PatientAdmission.IsNewBorn = false;
                this.DeathReportNo.ReadOnly = false;
                this._PatientAdmission.Building = null;
                this._PatientAdmission.Department = null;
                this.patientAdmissionFormViewModel.tempPoliclinic = null;
                this.patientAdmissionFormViewModel.tempProcedureDoctor = null;

                if (this._PatientAdmission.Episode.Patient.DeathReportNo == null) {
                    TTVisual.InfoBox.Alert(i18n("M19924", "Ölüm belge numarası girilmemiş kişiler,Ölüm belgesi yazılması için Acil Birimine yönlendirilirler."));
                }
            }
            else {
                this.DeathReportNo.ReadOnly = true;
                this._PatientAdmission.Episode.Patient.DeathReportNo = null;
                this._PatientAdmission.Episode.Patient.ExDate = null;
            }
        }
    }

    public async onIsNewBornChanged(event) {

        if (this._PatientAdmission != null && this._PatientAdmission.IsNewBorn != event) {

            if (event == true) {
                if (this.patientAdmissionFormViewModel._PatientAdmission.Episode != null && this._PatientAdmission.Episode.Patient != null) {
                    if (this._PatientAdmission.Episode.Patient.Age > 31)//30 günlükten büyük ise yeni doğan olmaz
                    {
                        this.patientAdmissionFormViewModel._PatientAdmission.IsNewBorn = false;
                        this.isNewBornInstance.UnChecked = true;
                        this.isNewBornInstance.Checked = false;
                        await ServiceLocator.MessageService.showError("30 günden büyük bebeklere yeni doğan kaydı yapılamaz.");
                    }
                    else {
                        this.showMatchBabyMotherPopup = true;
                        this._PatientAdmission.Episode.Patient.Death = false;
                        this._PatientAdmission.Episode.Patient.DeathReportNo = null;
                        this._PatientAdmission.Episode.Patient.ExDate = null;
                        this._PatientAdmission.Episode.Patient.UnIdentified = false;
                        this.enableUndefinedPatient = false;
                        this._PatientAdmission.IsNewBorn = event;
                    }
                }
            }
            else {
                this._PatientAdmission.IsNewBorn = event;

                if (this._PatientAdmission.Episode.Patient.UniqueRefNo == null)
                    this.enableUndefinedPatient = true;

                if (this._PatientAdmission.Episode.Patient != null) {
                    let that = this;
                    that.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.Mother = null;
                    this.babyMotherName = "";
                }
            }
        }
    }

    public async onDonorChanged(event) {

        if (this._PatientAdmission != null && this._PatientAdmission.Donor != event) {
            this._PatientAdmission.Donor = event;
        }
    }

    public onFatherNameChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.FatherName != event) {
            this._PatientAdmission.Episode.Patient.FatherName = event;
            if (event != null)
                this.FatherName.BackColor = "white";
        }

    }

    public onNationalityChanged(event): void {
        if (event != null) {
            if (this._PatientAdmission != null &&
                this._PatientAdmission.Episode != null &&
                this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.Nationality != event) {

                if (event != null && this.Nationality != null) {
                    this.Nationality.BackColor = "white";

                    //uyruk türkten yabancıya geçerse
                    if (this._PatientAdmission.Episode.Patient.Nationality != null && this._PatientAdmission.Episode.Patient.Nationality.Kodu == "TR" && event.Kodu != 'TR' && this._PatientAdmission.Episode.Patient.BirthPlace != null)
                        this._PatientAdmission.Episode.Patient.OtherBirthPlace = this._PatientAdmission.Episode.Patient.BirthPlace;
                    else if (this._PatientAdmission.Episode.Patient.Nationality != null && this._PatientAdmission.Episode.Patient.Nationality.Kodu != "TR" && event.Kodu == 'TR' && this._PatientAdmission.Episode.Patient.OtherBirthPlace != null)
                        this._PatientAdmission.Episode.Patient.BirthPlace = this._PatientAdmission.Episode.Patient.OtherBirthPlace;
                }

                this._PatientAdmission.Episode.Patient.Nationality = event;
                // this._PatientAdmission.Episode.Patient.BirthPlace=null;
                // this._PatientAdmission.Episode.Patient.OtherBirthPlace=null;
            }
        }
    }

    public onForeignChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.Foreign != event) {
            this._PatientAdmission.Episode.Patient.Foreign = event;
        }

    }

    public onForeignUniqueNoChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.YUPASSNO != event) {
            this._PatientAdmission.Episode.Patient.YUPASSNO = event;
        }

    }
    public onImportantPatientInfoChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.ImportantPatientInfo != event) {
            this._PatientAdmission.Episode.Patient.ImportantPatientInfo = event;
        }

    }

    public onHCModeOfPaymentChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.HCModeOfPayment != event) {
            this._PatientAdmission.HCModeOfPayment = event;
        }

    }

    public onHCRequestReasonChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.HCRequestReason != event) {
            this._PatientAdmission.HCRequestReason = event;
        }

        this.HCRequestReason_SelectedObjectChanged();
    }

    public onHomeAddressChanged(event): void {

        if (this.patientAdmissionFormViewModel.tempHomeAddress != event) {
            this.patientAdmissionFormViewModel.tempHomeAddress = event;
            if (event != null)
                this.HomeAddress.BackColor = "white";
        }

    }


    public onMobilePhoneChanged(event): void {

        if (this.patientAdmissionFormViewModel.tempMobilePhone != event) {
            this.patientAdmissionFormViewModel.tempMobilePhone = event;
            if (event != null)
                this.MobilePhone.BackColor = "white";
        }

    }

    showWorkableReportPopUp() {
        this.ShowWorkablePaperPopUp = true;
    }

    public createWorkableReport() {
        this.helpMenuService.printIsBasiCalisirKagidiReport(this.patientAdmissionFormViewModel.subEpisode.ObjectID, this.WorkDateForWorkablePaper, this.LeaveDateForWorkablePaper, this.getClickFunctionParams());
    }

    public onMotherNameChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.MotherName != event) {
            this._PatientAdmission.Episode.Patient.MotherName = event;
            if (event != null)
                this.MotherName.BackColor = "white";
        }

    }

    public onNameChanged(event): void {

        if (this.patientAdmissionFormViewModel.tempName != event) {
            this.patientAdmissionFormViewModel.tempName = Util.turkishToUpper(event.value);
            if (event != null)
                this.Name.BackColor = "white";
        }

    }

    public onPassportNoChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.PassportNo != event) {
            this._PatientAdmission.Episode.Patient.PassportNo = event;
        }

    }

    public onPayerListChanged(event): void {

        if (this._PatientAdmission != null && this.patientAdmissionFormViewModel.tempPayer != event) {
            this.patientAdmissionFormViewModel.tempPayer = event;

            if (event != null && event.Name.includes("3713/21"))
                this.patientAdmissionFormViewModel._PatientAdmission.AdmissionType = this.patientAdmissionFormViewModel.ProvizyonType3713;
        }

    }

    public onPriorityStatusChanged(event): void {
        if (event == null) {
            this._PatientAdmission.PriorityStatus = null;
        }
        else if (this._PatientAdmission != null && this._PatientAdmission.PriorityStatus != event) {
            this._PatientAdmission.PriorityStatus = event;
        }
    }

    public onPriorityStatusCleared(event): void {
        this.onPriorityStatusChanged(null);
    }

    public onEmergency112RefNoChanged(event): void {
        if (event != null) {
            if (this._PatientAdmission != null && this._PatientAdmission.Emergency112RefNo != event) {
                this._PatientAdmission.Emergency112RefNo = event;
            }
            this.Emergency112RefNoTextbox.BackColor = "white";
        }
    }
    public onSevkli112Changed(event): void {
        if (event != null) {
            if (this._PatientAdmission != null && this._PatientAdmission.Sevkli112 != event) {
                this._PatientAdmission.Sevkli112 = event;
            }

            if (event) {
                this.Emergency112RefNoTextbox.ReadOnly = false;
                this.ExternalHospital.ReadOnly = false;
            }
            else {
                this.Emergency112RefNoTextbox.ReadOnly = true;
                this.ExternalHospital.ReadOnly = true;
                this._PatientAdmission.Emergency112RefNo = null;
                this._PatientAdmission.ExternalHospital = null;
            }
        }
    }
    ///////
    /////////

    public onBuildingChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.Building != event) {
            this._PatientAdmission.Building = event;
        }
        this.triggerLoadChildComboBoxByBuilding(event);
    }


    private async triggerLoadChildComboBoxByBuilding(building) {

        if (building != null) {
            if (this.loadEmergenyDepartmentsOnly) {
                this.Branch.ListFilterExpression = " THIS.BUILDING= '" + building.ObjectID.toString() + "' AND IsEmergencyDepartment=1";
                this.Policlinic.Enabled = false;
                this.ProcedureDoctor.Enabled = false;
            }
            else {
                this.Branch.ListFilterExpression = " THIS.BUILDING= '" + building.ObjectID.toString() + "'";
            }
        }
        else {
            this.Branch.ListFilterExpression = " ";
        }

        let input: InputModelForQueries = new InputModelForQueries();
        input.filter = " AND this.ISACTIVE = 1";
        if (input.filter !== " ")
            input.filter += " AND " + this.Branch.ListFilterExpression;
        this.FillDataSource(input, 1);

        this._PatientAdmission.Department = null;
        this.patientAdmissionFormViewModel.tempPoliclinic = null;
        this.patientAdmissionFormViewModel.tempProcedureDoctor = null;

    }


    public async onBranchChanged(event): Promise<void> {
        if (this._PatientAdmission != null && this._PatientAdmission.Department != event.selectedItem) {
            this._PatientAdmission.Department = event.selectedItem;

            if (event.selectedItem == null && this._PatientAdmission.Building != null) {
                if (this.loadEmergenyDepartmentsOnly) {
                    this.Branch.ListFilterExpression = " THIS.BUILDING= '" + this._PatientAdmission.Building.ObjectID.toString() + "' AND IsEmergencyDepartment=1";
                    let input: InputModelForQueries = new InputModelForQueries();
                    input.filter = " AND this.ISACTIVE = 1";
                    input.filter += " AND " + this.Branch.ListFilterExpression;
                    this.FillDataSource(input, 1);

                }
                else {
                    this.Branch.ListFilterExpression = " THIS.BUILDING= '" + this._PatientAdmission.Building.ObjectID.toString() + "'";
                    let input: InputModelForQueries = new InputModelForQueries();
                    input.filter = " AND this.ISACTIVE = 1";
                    input.filter += " AND " + this.Branch.ListFilterExpression;
                    this.FillDataSource(input, 1);

                }
            } else if (this._PatientAdmission.Building == null) {
                this.Branch.ListFilterExpression = "";
                let input: InputModelForQueries = new InputModelForQueries();
                input.filter = " AND this.ISACTIVE = 1";
                //await this.FillDataSources(input);
                this.FillDataSource(input, 1);

            }
        }
        this.triggerLoadChildComboBoxByBranch(event.selectedItem);
        this.setAdmissionTypeWithBranch(event.selectedItem);
    }

    private async triggerLoadChildComboBoxByBranch(branch) {

        if (branch != null) {

            let input: InputModelForQueries = new InputModelForQueries();
            this.Policlinic.ListFilterExpression = " THIS.DEPARTMENT= '" + branch.ObjectID.toString() + "'";
            input.filter = " AND " + this.Policlinic.ListFilterExpression;
            this.FillDataSource(input, 2);


            this.ProcedureDoctor.ListFilterExpression = " UserResources.Policlinic.Department = '" + branch.ObjectID.toString() + "'";
            let inputDoctor: InputModelForQueries = new InputModelForQueries();
            inputDoctor.filter = " AND this.ISACTIVE = 1" + " AND " + this.ProcedureDoctor.ListFilterExpression;
            // await this.FillDataSourcesForDoctor(inputDoctor);
            this.FillDataSource(inputDoctor, 3);

        }

        else if (this.isBranchLoadedByProcedureDoctor == false) {

            this.Policlinic.ListFilterExpression = "";
            this.ProcedureDoctor.ListFilterExpression = "";

            let inputKlinik: InputModelForQueries = new InputModelForQueries();
            inputKlinik.filter = this.Policlinic.ListFilterExpression;
            this.FillDataSource(inputKlinik, 2);


            let inputDoctor: InputModelForQueries = new InputModelForQueries();
            inputDoctor.filter = " AND this.ISACTIVE = 1";
            this.FillDataSource(inputDoctor, 3);

            this.patientAdmissionFormViewModel.tempPoliclinic = null;
            this.patientAdmissionFormViewModel.tempProcedureDoctor = null;
        }


    }

    private setAdmissionTypeWithBranch(branch: any) {

        if (this.patientAdmissionFormViewModel.EmergencyProvisionType.ObjectID != null && this.patientAdmissionFormViewModel.NormalProvisionType.ObjectID != null && branch != null) {
            if ((this.patientAdmissionFormViewModel._PatientAdmission.AdmissionType.ObjectID == this.patientAdmissionFormViewModel.EmergencyProvisionType.ObjectID
                || this.patientAdmissionFormViewModel._PatientAdmission.AdmissionType.ObjectID == this.patientAdmissionFormViewModel.NormalProvisionType.ObjectID
                || this.patientAdmissionFormViewModel._PatientAdmission.AdmissionType == null)) {
                if (branch.IsEmergencyDepartment) {
                    this.patientAdmissionFormViewModel._PatientAdmission.AdmissionType = this.patientAdmissionFormViewModel.EmergencyProvisionType;
                    if (this.loadEmergenyDepartmentsOnly)
                        this.Policlinic.Enabled = true;
                }
                else {
                    this.patientAdmissionFormViewModel._PatientAdmission.AdmissionType = this.patientAdmissionFormViewModel.NormalProvisionType;
                }
            }
        }
    }

    public async onPoliclinicChanged(event) {
        if (this.patientAdmissionFormViewModel.tempPoliclinic != event.selectedItem) {
            this.patientAdmissionFormViewModel.tempPoliclinic = event.selectedItem;
        }

        if (!(this.patientAdmissionFormViewModel.tempPoliclinic == null && this._PatientAdmission.Department != null)) {
            this.triggerLoadParentsComboBoxByPoliclinic(event.selectedItem, false);
        }
        this.triggerLoadChildComboBoxByPoliclinic(event.selectedItem, false);

        if (this.patientAdmissionFormViewModel.tempPoliclinic == null && this._PatientAdmission.Department != null) {
            this.ProcedureDoctor.ListFilterExpression = " UserResources.Policlinic.Department = '" + this._PatientAdmission.Department.ObjectID.toString() + "'";
            let inputDoctor: InputModelForQueries = new InputModelForQueries();
            inputDoctor.filter = " AND this.ISACTIVE = 1" + " AND " + this.ProcedureDoctor.ListFilterExpression;
            this.FillDataSource(inputDoctor, 3);
        }

    }

    public async onFilterPoliclinicChanged(event) {
        if (event != null && event.selectedItem != null && this.FilterPoliclinicId != event.selectedItem) {
            this.FilterPoliclinicId = event.selectedItem;
        }
    }

    private async triggerLoadChildComboBoxByPoliclinic(Policlinic, dispatch: boolean) {

        if (Policlinic != null) {
            if (this.loadEmergenyDepartmentsOnly)
                this.ProcedureDoctor.Enabled = true;

            if (dispatch == false) {
                this.ProcedureDoctor.ListFilterExpression = " USERRESOURCES.RESOURCE = '" + Policlinic.ObjectID.toString() + "'";

                let inputDoctor: InputModelForQueries = new InputModelForQueries();
                inputDoctor.filter = " AND this.ISACTIVE = 1" + " AND" + this.ProcedureDoctor.ListFilterExpression;
                this.FillDataSource(inputDoctor, 3);

            }
            else
                this.DispatchHospitalDoctors.ListFilterExpression = " USERRESOURCES.RESOURCE = '" + Policlinic.ObjectID.toString() + "'";
        }
        else if (this.isPolyclinicLoadedByProcedureDoctor == false) {

            this.ProcedureDoctor.ListFilterExpression = "";

            let inputDoctor: InputModelForQueries = new InputModelForQueries();
            inputDoctor.filter = " AND this.ISACTIVE = 1";
            this.FillDataSource(inputDoctor, 3);


            this.patientAdmissionFormViewModel.tempProcedureDoctor = null;
            this.DispatchHospitalDoctors.ListFilterExpression = "";
        }
    }

    private async triggerLoadParentsComboBoxByPoliclinic(Policlinic, dispatch: boolean) {

        if (Policlinic != null) {
            try {

                let that = this;
                let body = JSON.stringify(Policlinic);
                let apiUrlForPASearchUrl: string = '/api/PatientAdmissionService/BranchByPolyclinic';
                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                let result = await httpService.post(apiUrlForPASearchUrl, Policlinic, ResPoliclinic);

                if (result != null) {

                    let branch = result["BranchObject"];
                    if (branch == null || branch == undefined) {

                    }
                    else if (this._PatientAdmission.Department == null || this._PatientAdmission.Department.ObjectID != branch.ObjectID) {
                        this._PatientAdmission.Department = branch;
                        if (branch.IsEmergencyDepartment)
                            this.patientAdmissionFormViewModel._PatientAdmission.AdmissionType = this.patientAdmissionFormViewModel.EmergencyProvisionType;
                        // else
                        //     this.patientAdmissionFormViewModel._PatientAdmission.AdmissionType = this.patientAdmissionFormViewModel.NormalProvisionType;

                        if (dispatch == false) {
                            this.Policlinic.ListFilterExpression = " THIS.DEPARTMENT= '" + branch.ObjectID.toString() + "'";
                            if (this.patientAdmissionFormViewModel.tempPoliclinic === null) {
                                let input: InputModelForQueries = new InputModelForQueries();
                                input.filter = " AND " + this.Policlinic.ListFilterExpression;
                                this.FillDataSource(input, 2);

                            }
                        }
                        else
                            this.DispatchHospitalResources.ListFilterExpression = " THIS.DEPARTMENT= '" + branch.ObjectID.toString() + "'";
                    }
                }
            }
            catch (ex) {
                TTVisual.InfoBox.Show(ex);
            }
        }
        else {
            this.Branch.ListFilterExpression = "";
            if (this.patientAdmissionFormViewModel._PatientAdmission.Department === null) {
                let input: InputModelForQueries = new InputModelForQueries();
                input.filter = " AND this.ISACTIVE = 1";
                this.FillDataSource(input, 1);


            }

            this._PatientAdmission.Department = null;

            this.Policlinic.ListFilterExpression = "";
            let inputKlinik: InputModelForQueries = new InputModelForQueries();
            inputKlinik.filter = this.Policlinic.ListFilterExpression;
            this.FillDataSource(inputKlinik, 2);
            this.DispatchHospitalResources.ListFilterExpression = "";
        }
    }


    public async onProcedureDoctorChanged(event) {

        if (this.patientAdmissionFormViewModel.tempProcedureDoctor != event.selectedItem) {
            this.patientAdmissionFormViewModel.tempProcedureDoctor = event.selectedItem;
        }
        if (this.patientAdmissionFormViewModel.tempProcedureDoctor != null) {
            let a = await CommonService.PersonelIzinKontrol(this.patientAdmissionFormViewModel.tempProcedureDoctor.ObjectID, this._PatientAdmission.ActionDate);
            if (a) {
                this.messageService.showInfo(this.patientAdmissionFormViewModel.tempProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                setTimeout(() => {
                    this.patientAdmissionFormViewModel.tempProcedureDoctor = null;
                }, 500);

            }
            else {
                if (this.patientAdmissionFormViewModel.tempPoliclinic == null) {
                    if (this.patientAdmissionFormViewModel._PatientAdmission.Department != null && this.patientAdmissionFormViewModel.tempProcedureDoctor != null) {
                        let input: InputModelForQueries = new InputModelForQueries();
                        this.Policlinic.ListFilterExpression = " THIS.DEPARTMENT= '" + this.patientAdmissionFormViewModel._PatientAdmission.Department.ObjectID.toString() + "'" + " AND THIS.RESOURCEUSERS.USER.OBJECTID = '" + this.patientAdmissionFormViewModel.tempProcedureDoctor.ObjectID.toString() + "'";
                        input.filter = " AND " + this.Policlinic.ListFilterExpression;
                        this.FillDataSource(input, 2);
                    }

                    else {
                        this.triggerLoadParentsComboBoxByProcedureDoctor(event.selectedItem, false);
                    }
                }

            }
            // alert(a);
            console.log(a);
        }

        else if (this.patientAdmissionFormViewModel.tempProcedureDoctor == null && this.patientAdmissionFormViewModel._PatientAdmission.Department != null) {
            let input: InputModelForQueries = new InputModelForQueries();
            this.Policlinic.ListFilterExpression = " THIS.DEPARTMENT= '" + this.patientAdmissionFormViewModel._PatientAdmission.Department.ObjectID.toString() + "'";
            input.filter = " AND " + this.Policlinic.ListFilterExpression;
            this.FillDataSource(input, 2);
        }




        //  this.GetCounterByUser();
    }


    private async triggerLoadParentsComboBoxByProcedureDoctor(doctor, dispatch: boolean) {

        if (doctor != null) {
            try {

                let that = this;
                let body = JSON.stringify(doctor);
                let apiUrlForPASearchUrl: string = '/api/PatientAdmissionService/PolyclinicAndBranchByProcedureDoctor';
                let httpService: NeHttpService = ServiceLocator.NeHttpService;
                let result = await httpService.post(apiUrlForPASearchUrl, doctor, ResUser);

                this.loadBranchAndPoliclinic(result, dispatch);
            }
            catch (ex) {
                TTVisual.InfoBox.Show(ex);
            }
        }
        else {
            if (this.isBranchLoadedByProcedureDoctor == true) {
                this.isBranchLoadedByProcedureDoctor = false;
                if (this.patientAdmissionFormViewModel.tempPoliclinic == null) {
                    this.Branch.ListFilterExpression = "";
                    let input: InputModelForQueries = new InputModelForQueries();
                    input.filter = " AND this.ISACTIVE = 1";
                    this.FillDataSource(input, 1);

                }
            }
            if (this.isPolyclinicLoadedByProcedureDoctor == true) {

                if (this.patientAdmissionFormViewModel.tempPoliclinic != null) {
                    this.ProcedureDoctor.ListFilterExpression = " USERRESOURCES.RESOURCE = '" + this.patientAdmissionFormViewModel.tempPoliclinic.ObjectID.toString() + "'";
                    let inputDoctor: InputModelForQueries = new InputModelForQueries();
                    inputDoctor.filter = " AND this.ISACTIVE = 1" + " AND " + this.ProcedureDoctor.ListFilterExpression;
                    this.FillDataSource(inputDoctor, 3);

                }

                else {
                    this.ProcedureDoctor.ListFilterExpression = "";
                    let inputDoctor: InputModelForQueries = new InputModelForQueries();
                    inputDoctor.filter = " AND this.ISACTIVE = 1";
                    this.FillDataSource(inputDoctor, 3);

                    if (dispatch == false) {
                        this.Policlinic.ListFilterExpression = "";
                        let input: InputModelForQueries = new InputModelForQueries();
                        input.filter = this.Policlinic.ListFilterExpression;
                        this.FillDataSource(input, 2);

                    }
                    else
                        this.DispatchHospitalResources.ListFilterExpression = "";
                }
                this.isPolyclinicLoadedByProcedureDoctor = false;

            }
        }
    }

    isBranchLoadedByProcedureDoctor: boolean = false;
    isPolyclinicLoadedByProcedureDoctor: boolean = false;

    public async loadBranchAndPoliclinic(result: any, dispatch: boolean) {

        let branchObjectIds = "";
        let polyclinicObjectIDs = "";

        for (let PolyclinicDoctorBranchGroupModel of result) {

            let branch = PolyclinicDoctorBranchGroupModel["BranchObject"];
            if (branch == null || branch == undefined) {

            }
            else if (this._PatientAdmission.Department == null || this._PatientAdmission.Department.ObjectID != branch.ObjectID) {

                if (result.length == 1) {
                    this._PatientAdmission.Department = branch;
                    this.isBranchLoadedByProcedureDoctor = true;
                }
                if (branchObjectIds != "")
                    branchObjectIds += "','";

                branchObjectIds += branch.ObjectID;

            }


            let polyclinic = PolyclinicDoctorBranchGroupModel["PolyclinicObject"];
            if (polyclinic == null || polyclinic == undefined) {

            }
            else if (this.patientAdmissionFormViewModel.tempPoliclinic == null || this.patientAdmissionFormViewModel.tempPoliclinic.ObjectID != polyclinic.ObjectID) {
                if (result.length == 1) {
                    this.patientAdmissionFormViewModel.tempPoliclinic = polyclinic;
                    this.isPolyclinicLoadedByProcedureDoctor = true;
                }
                if (polyclinicObjectIDs != "")
                    polyclinicObjectIDs += "','";


                polyclinicObjectIDs += polyclinic.ObjectID;

            }

        }
        if (dispatch == false) {
            this.Policlinic.ListFilterExpression = " THIS.OBJECTID IN ('" + polyclinicObjectIDs.toString() + "')";
            let input: InputModelForQueries = new InputModelForQueries();
            input.filter = " AND " + this.Policlinic.ListFilterExpression;
            this.FillDataSource(input, 2);


            if (this.patientAdmissionFormViewModel.tempProcedureDoctor === null) {
                this.ProcedureDoctor.ListFilterExpression = " USERRESOURCES.RESOURCE IN ('" + polyclinicObjectIDs.toString() + "')";
                let inputDoctor: InputModelForQueries = new InputModelForQueries();
                inputDoctor.filter = " AND this.ISACTIVE = 1" + " AND " + this.ProcedureDoctor.ListFilterExpression;
                this.FillDataSource(inputDoctor, 3);

            }
        }
        else {
            this.DispatchHospitalResources.ListFilterExpression = " THIS.OBJECTID IN ('" + polyclinicObjectIDs.toString() + "')";
            this.DispatchHospitalDoctors.ListFilterExpression = " USERRESOURCES.RESOURCE IN ('" + polyclinicObjectIDs.toString() + "')";
        }
        this.Branch.ListFilterExpression = " THIS.OBJECTID IN ('" + branchObjectIds.toString() + "')";
        let input: InputModelForQueries = new InputModelForQueries();
        input.filter = " AND this.ISACTIVE = 1";
        if (this.Branch.ListFilterExpression !== "")
            input.filter += " AND " + this.Branch.ListFilterExpression;

        this.FillDataSource(input, 1);


    }



    ///////
    /////////


    public onReasonForExaminationHCRequestReasonChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.HCRequestReason != null && this._PatientAdmission.HCRequestReason.ReasonForExamination != event) {
            this._PatientAdmission.HCRequestReason.ReasonForExamination = event;
        }

    }

    public onRelatedProvisionChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.RelatedProvision != event) {
            this._PatientAdmission.RelatedProvision = event;
        }

    }

    public onSexChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.Sex != event) {
            if (event == null)
                event = new SKRSCinsiyet();
            else
                this.Sex.BackColor = "White";

            this._PatientAdmission.Episode.Patient.Sex = event;
            this.updateAvatarPhoto(this._PatientAdmission.Episode.Patient);

        }

    }

    public onSurnameChanged(event): void {

        if (this.patientAdmissionFormViewModel.tempSurname != event) {
            this.patientAdmissionFormViewModel.tempSurname = Util.turkishToUpper(event.value);
            if (event != null)
                this.Surname.BackColor = "white";
        }

    }

    public ontakipAlCevapChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.takipAlCevap != event) {
            this._PatientAdmission.takipAlCevap = event;
        }

    }

    public ontakipAlHataMesajiChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.takipAlHataMesaji != event) {
            this._PatientAdmission.takipAlHataMesaji = event;
        }

    }


    public onTownOfRegistryChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.TownOfRegistry != event) {
            this._PatientAdmission.Episode.Patient.TownOfRegistry = event;
        }

    }


    public onttmaskedtextbox2Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.BuildingSquare != event) {
            this._PatientAdmission.PA_Address.BuildingSquare = event;
        }

    }

    public onttobjectlistbox1Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.SKRSMahalleKodlari != event) {
            this._PatientAdmission.PA_Address.SKRSMahalleKodlari = event;
        }

    }


    public onttobjectlistbox3Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.SKRSKoyKodlari != event) {
            this._PatientAdmission.PA_Address.SKRSKoyKodlari = event;
        }

    }

    public onttobjectlistbox4Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.SKRSCsbmKodu != event) {
            this._PatientAdmission.PA_Address.SKRSCsbmKodu = event;
        }

    }

    public onttobjectlistbox5Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.SKRSBucakKodu != event) {
            this._PatientAdmission.PA_Address.SKRSBucakKodu = event;
        }

    }

    public onttobjectlistbox6Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.SKRSIlceKodlari != event) {
            this._PatientAdmission.PA_Address.SKRSIlceKodlari = event;
        }

    }

    public onttobjectlistbox7Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.SKRSILKodlari != event) {
            this._PatientAdmission.PA_Address.SKRSILKodlari = event;
        }

    }
    public onBirthOrderChanged(event): void {
        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.BirthOrder != event) {
            this._PatientAdmission.Episode.Patient.BirthOrder = event;
        }
    }

    public ontttextbox10Changed(event): void {
        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.EMail != event) {
            this._PatientAdmission.Episode.Patient.EMail = event;
        }

    }

    public ontttextbox11Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.BuildingCode != event) {
            this._PatientAdmission.PA_Address.BuildingCode = event;
        }

    }

    public onImportantPAInfoChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.ImportantPAInfo != event) {
            this._PatientAdmission.ImportantPAInfo = event;
        }

    }

    public ontttextbox13Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.BuildingNo != event) {
            this._PatientAdmission.PA_Address.BuildingNo = event;
        }

    }

    public ontttextbox14Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.BuildingSheet != event) {
            this._PatientAdmission.PA_Address.BuildingSheet = event;
        }

    }

    public ontttextbox15Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.BuildingParcel != event) {
            this._PatientAdmission.PA_Address.BuildingParcel = event;
        }

    }

    public ontttextbox17Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.ForeignAddress != event) {
            this._PatientAdmission.PA_Address.ForeignAddress = event;
        }

    }

    public ontttextbox21Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.DisKapi != event) {
            this._PatientAdmission.PA_Address.DisKapi = event;
        }

    }

    public ontttextbox22Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.IcKapi != event) {
            this._PatientAdmission.PA_Address.IcKapi = event;
        }

    }

    public ontttextbox2Changed(event): void {

        if (this.patientAdmissionFormViewModel != null &&
            this.patientAdmissionFormViewModel.SubEpisodeProtocol != null && this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaYupassNo != event) {
            this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaYupassNo = event;
        }

    }

    public ontttextbox3Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.HomePhone != event) {
            this._PatientAdmission.PA_Address.HomePhone = event;
        }

    }

    public ontttextbox6Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.AddressNo != event) {
            this._PatientAdmission.PA_Address.AddressNo = event;
        }

    }

    public ontttextbox8Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.SKRSAdresTipi != event) {
            this._PatientAdmission.PA_Address.SKRSAdresTipi = event;
        }

    }

    public ontttextbox9Changed(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.BuildingBlockName != event) {
            this._PatientAdmission.PA_Address.BuildingBlockName = event;
        }

    }

    public ontxtEpisodeChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode != null && this._PatientAdmission.Episode.Weight != event) {
            this._PatientAdmission.Episode.Weight = event;
        }

    }

    public ontxtParcelChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.SiteName != event) {
            this._PatientAdmission.PA_Address.SiteName = event;
        }

    }

    public ontxtYUPASSIDChanged(event): void {

        //    if (event != null) {
        //        if (this._PatientAdmission != null &&
        //            this.patientAdmissionFormViewModel.SubEpisodeProtocol != null && this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaYupassNo != event) {
        //            this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaYupassNo = event;
        //        }
        //}
    }
    public onDonorUniqueRefNoChanged(event): void {
        if (event != null) {
            if (this._PatientAdmission != null &&
                this._PatientAdmission.Episode != null &&
                this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.DonorUniqueRefNo != event) {
                this._PatientAdmission.Episode.Patient.DonorUniqueRefNo = event;
            }
        }
    }
    public onpPrivacyChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.Episode != null && this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.Privacy != event) {
            this._PatientAdmission.Episode.Patient.Privacy = event;
        }

        if (event) {
            this.pPrivacyName.ReadOnly = false;
            this.pPrivacySurname.ReadOnly = false;
            this.pPrivacyReason.ReadOnly = false;
            this.pPrivacyEndDate.ReadOnly = false;
            this.pPrivacyEndDate.Enabled = true;

            if(this.patientAdmissionFormViewModel.tempPrivacyName == null && this.patientAdmissionFormViewModel.tempName != null)
            {
                this.patientAdmissionFormViewModel.tempPrivacyName = this.patientAdmissionFormViewModel.tempName.substr(0,2) + this.makeRamdomID(this.patientAdmissionFormViewModel.tempName.length - 2);
            }

            if(this.patientAdmissionFormViewModel.tempPrivacySurname == null && this.patientAdmissionFormViewModel.tempSurname != null)
            {
                this.patientAdmissionFormViewModel.tempPrivacySurname = this.patientAdmissionFormViewModel.tempSurname.substr(0,2) + this.makeRamdomID(this.patientAdmissionFormViewModel.tempSurname.length - 2);
            }
        }
        else {
            this.pPrivacyName.ReadOnly = true;
            this.pPrivacySurname.ReadOnly = true;
            this.pPrivacyReason.ReadOnly = true;
            this.pPrivacyEndDate.ReadOnly = true;
            this.pPrivacyEndDate.Enabled = false;

            this.patientAdmissionFormViewModel.tempPrivacyName = null;
            this.patientAdmissionFormViewModel.tempPrivacySurname = null;
            this._PatientAdmission.Episode.Patient.PrivacyReason = null;
            this._PatientAdmission.Episode.Patient.PrivacyEndDate = null;
        }
    }
    public onpPrivacyNameChanged(event): void {

        if (this.patientAdmissionFormViewModel.tempPrivacyName != event) {
            this.patientAdmissionFormViewModel.tempPrivacyName = event; //Util.turkishToUpper(event);
        }

    }
    public onpPrivacySurnameChanged(event): void {

        if (this.patientAdmissionFormViewModel.tempPrivacySurname != event) {
            this.patientAdmissionFormViewModel.tempPrivacySurname = event; //Util.turkishToUpper(event);
        }

    }

    public onpPrivacyReasonChanged(event): void {

        if (this._PatientAdmission != null && this._PatientAdmission.Episode != null && this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.PrivacyReason != event) {
            this._PatientAdmission.Episode.Patient.PrivacyReason = event;
        }

    }

    public onpPrivacyEndDateChanged(event): void {
        if (this._PatientAdmission != null && this._PatientAdmission.Episode != null && this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.PrivacyEndDate != event)
            this._PatientAdmission.Episode.Patient.PrivacyEndDate = event;

    }

    public ontxtYUPASSNOChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.YUPASSNO != event) {
            this._PatientAdmission.Episode.Patient.YUPASSNO = event;
        }

    }

    public onUnIdentifiedChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.UnIdentified != event) {

            // this.enableUnicrefNo = (!event)
            if (this.patientAdmissionFormViewModel._PatientAdmission.IsNewBorn && event) {
                ServiceLocator.MessageService.showError("'Yenidoğan' seçilmiş hastalarda 'kimlik bilinmiyor' seçilemez.");
                // this._PatientAdmission.Episode.Patient.UnIdentified = false;
            }
            else {
                this._PatientAdmission.Episode.Patient.UnIdentified = event;
            }
        }


    }

    public onUniqueRefNoChanged(event): void {

        if (this.patientAdmissionFormViewModel.tempUniqueRefNo != event.value) {
            this.patientAdmissionFormViewModel.tempUniqueRefNo = event.value;
        }

        if (event == null || event.value == null || event.value == "") {
            this.enableUndefinedPatient = true;
        }
        else {
            this.enableUndefinedPatient = false;
            if (this._PatientAdmission.Episode.Patient != null)
                this._PatientAdmission.Episode.Patient.UnIdentified = false;
        }

    }
    public onPatientNumberChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.ID != event.value) {
            this._PatientAdmission.Episode.Patient.ID = event.value;
        }

    }

    public onRelativeFullNameChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.RelativeFullName != event) {
            this._PatientAdmission.PA_Address.RelativeFullName = event;
        }

    }

    public onRelativeHomeAddressChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.RelativeHomeAddress != event) {
            this._PatientAdmission.PA_Address.RelativeHomeAddress = event;
        }

    }

    public onRelativeMobilePhoneChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.RelativeMobilePhone != event) {
            this._PatientAdmission.PA_Address.RelativeMobilePhone = event;
        }

    }

    public onBusinessAddressChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.BusinessAddress != event) {
            this._PatientAdmission.PA_Address.BusinessAddress = event;
        }

    }

    public onBusinessPhoneChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.BusinessPhone != event) {
            this._PatientAdmission.PA_Address.BusinessPhone = event;
        }

    }

    public onYabanciSehirChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.ForeignCity != event) {
            this._PatientAdmission.PA_Address.ForeignCity = event;
        }

    }

    public onYabanciUlkeChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.PA_Address != null && this._PatientAdmission.PA_Address.ForeignCountry != event) {
            this._PatientAdmission.PA_Address.ForeignCountry = event;
        }

    }

    /*    public onyesilKartSevkEdenTesisKoduChanged(event): void {

            if (this._PatientAdmission != null &&
                this._PatientAdmission.MedulaProvision != null && this._PatientAdmission.MedulaProvision.GreenCardSendingFacilityCode != event) {
                this._PatientAdmission.MedulaProvision.GreenCardSendingFacilityCode = event;
            }

        }*/

    public onApplicationReasonChanged(event): void {
        if (event != null) {
            if (this._PatientAdmission != null &&
                this._PatientAdmission.ApplicationReason != null && this._PatientAdmission.ApplicationReason != event) {
                this._PatientAdmission.ApplicationReason = event;
            }
        }
    }

    /*Engelli Raporu*/
    public onDisabledReportApplicationExplanationChanged(event): void {
        if (event != null) {
            if (this.patientAdmissionFormViewModel != null &&
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport != null && this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.ApplicationExplanation != event) {
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.ApplicationExplanation = event;
            }
        }
    }

    public onDisabledReportApplicationReasonChanged(event): void {
        if (event != null) {
            if (this.patientAdmissionFormViewModel != null &&
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport != null && this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.ApplicationReason != event) {
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.ApplicationReason = event;
            }
        }
    }

    public onDisabledReportApplicationTypeChanged(event): void {
        if (event != null) {
            if (this.patientAdmissionFormViewModel != null &&
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport != null && this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.ApplicationType != event) {
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.ApplicationType = event;
            }
        }
    }

    public onDisabledReportCorporateApplicationTypeChanged(event): void {
        if (event != null) {
            if (this.patientAdmissionFormViewModel != null &&
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport != null && this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.CorporateApplicationType != event) {
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.CorporateApplicationType = event;
            }
        }
    }

    public onDisabledReportPersonalApplicationTypeChanged(event): void {
        if (event != null) {
            if (this.patientAdmissionFormViewModel != null &&
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport != null && this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.PersonalApplicationType != event) {
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.PersonalApplicationType = event;
            }
        }
    }

    public onDisabledReportTerrorAccidentInjuryAppReasonChanged(event): void {
        if (event != null) {
            if (this.patientAdmissionFormViewModel != null &&
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport != null && this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.TerrorAccidentInjuryAppReason != event) {
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.TerrorAccidentInjuryAppReason = event;
            }
        }
    }

    public onDisabledReportTerrorAccidentInjuryAppTypeChanged(event): void {
        if (event != null) {
            if (this.patientAdmissionFormViewModel != null &&
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport != null && this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.TerrorAccidentInjuryAppType != event) {
                this.patientAdmissionFormViewModel._PatientAdmission.EDisabledReport.TerrorAccidentInjuryAppType = event;
            }
        }
    }




    /*Engelli Raporu*/

    /*E-Durum Bildirir Kurul Entegrasyonu*/
    public onEStatusNotRepComApplicationTypeChanged(event): void {
        if (event != null) {
            if (this.patientAdmissionFormViewModel != null &&
                this.patientAdmissionFormViewModel._PatientAdmission.EStatusNotRepCommitteeObj != null && this.patientAdmissionFormViewModel._PatientAdmission.EStatusNotRepCommitteeObj.ApplicationType != event) {
                this.patientAdmissionFormViewModel._PatientAdmission.EStatusNotRepCommitteeObj.ApplicationType = event;
            }
        }
    }
    /*E-Durum Bildirir Kurul Entegrasyonu*/


    public onPatientClassGroupChanged(event): void {
        if (event != null) {
            if (this._PatientAdmission != null &&
                this._PatientAdmission.PatientClassGroup != null && this._PatientAdmission.PatientClassGroup != event) {
                this._PatientAdmission.PatientClassGroup = event;
            }
        }
    }
    public onYupasNoChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.ForeignUniqueRefNo != event) {
            this._PatientAdmission.Episode.Patient.ForeignUniqueRefNo = event;
        }

    }
    public onBeneficiaryNameChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.BeneficiaryName != event) {
            this._PatientAdmission.BeneficiaryName = event;
        }

    }

    public onBeneficiaryUniqueRefNoChanged(event): void {

        if (this._PatientAdmission != null &&
            this._PatientAdmission.BeneficiaryUniqueRefNo != event) {
            this._PatientAdmission.BeneficiaryUniqueRefNo = event;
        }

    }
    protected redirectProperties(): void {
        redirectProperty(this.Name, "Text", this.__ttObject, "Episode.Patient.Name");
        redirectProperty(this.UniqueRefNo, "Text", this.__ttObject, "Episode.Patient.UniqueRefNo");
        redirectProperty(this.PatientNumber, "Text", this.__ttObject, "Episode.Patient.ID");
        redirectProperty(this.BirthDate, "Value", this.__ttObject, "Episode.Patient.BirthDate");
        redirectProperty(this.BDYearOnly, "Value", this.__ttObject, "Episode.Patient.BDYearOnly");
        redirectProperty(this.HomeAddress, "Text", this.__ttObject, "PA_Address.HomeAddress");
        redirectProperty(this.MobilePhone, "Text", this.__ttObject, "PA_Address.MobilePhone");
        redirectProperty(this.OtherBirthPlace, "Text", this.__ttObject, "Episode.Patient.OtherBirthPlace");
        redirectProperty(this.Surname, "Text", this.__ttObject, "Episode.Patient.Surname");
        redirectProperty(this.Sex, "Value", this.__ttObject, "Episode.Patient.Sex");
        redirectProperty(this.BirthOrder, "Value", this.__ttObject, "Episode.Patient.BirthOrder");
        redirectProperty(this.UnIdentified, "Value", this.__ttObject, "Episode.Patient.UnIdentified");
        redirectProperty(this.Foreign, "Value", this.__ttObject, "Episode.Patient.Foreign");
        redirectProperty(this.FatherName, "Text", this.__ttObject, "Episode.Patient.FatherName");
        redirectProperty(this.Nationality, "Text", this.__ttObject, "Episode.Patient.Nationality");
        redirectProperty(this.ImportantPAInfo, "Text", this.__ttObject, "ImportantPAInfo");
        redirectProperty(this.ImportantPatientInfo, "Text", this.__ttObject, "ImportantPatientInfo");
        redirectProperty(this.ForeignUniqueNo, "Text", this.__ttObject, "Episode.Patient.ForeignUniqueNo");
        redirectProperty(this.Age, "Text", this.__ttObject, "Episode.Patient.Age");
        redirectProperty(this.DeathReportNo, "Text", this.__ttObject, "Episode.Patient.DeathReportNo");
        redirectProperty(this.PassportNo, "Text", this.__ttObject, "Episode.Patient.PassportNo");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "MedulaProvision.YUPASSID");
        redirectProperty(this.MotherName, "Text", this.__ttObject, "Episode.Patient.MotherName");
        redirectProperty(this.YupasNo, "Text", this.__ttObject, "Episode.Patient.ForeignUniqueRefNo");
        redirectProperty(this.BloodGroup, "Value", this.__ttObject, "Episode.Patient.BloodGroupType");
        redirectProperty(this.SKRSAdliVaka, "Value", this.__ttObject, "SKRSAdliVaka");
        redirectProperty(this.SKRSYabanciHasta, "Value", this.__ttObject, "SKRSYabanciHasta");
        redirectProperty(this.ExDate, "Text", this.__ttObject, "Episode.Patient.ExDate");
        redirectProperty(this.pPrivacy, "Value", this.__ttObject, "Episode.Patient.Privacy");
        redirectProperty(this.pPrivacyName, "Text", this.__ttObject, "Episode.Patient.PrivacyName");
        redirectProperty(this.pPrivacySurname, "Text", this.__ttObject, "Episode.Patient.PrivacySurname");
        redirectProperty(this.pPrivacyReason, "Text", this.__ttObject, "Episode.Patient.PrivacyReason");
        redirectProperty(this.pPrivacyEndDate, "Value", this.__ttObject, "Episode.Patient.PrivacyEndDate");
        redirectProperty(this.tttextbox6, "Text", this.__ttObject, "PA_Address.AddressNo");
        redirectProperty(this.tttextbox13, "Text", this.__ttObject, "PA_Address.BuildingNo");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "PA_Address.HomePhone");
        redirectProperty(this.txtEpisode, "Text", this.__ttObject, "Episode.Weight");
        redirectProperty(this.tttextbox8, "Text", this.__ttObject, "PA_Address.SKRSAdresTipi");
        redirectProperty(this.tttextbox14, "Text", this.__ttObject, "PA_Address.BuildingSheet");
        redirectProperty(this.tttextbox21, "Text", this.__ttObject, "PA_Address.DisKapi");
        redirectProperty(this.WorkPhone, "Text", this.__ttObject, "PA_Address.BusinessPhone");
        redirectProperty(this.ttmaskedtextbox2, "Text", this.__ttObject, "PA_Address.BuildingSquare");
        redirectProperty(this.tttextbox15, "Text", this.__ttObject, "PA_Address.BuildingParcel");
        redirectProperty(this.tttextbox22, "Text", this.__ttObject, "PA_Address.IcKapi");
        redirectProperty(this.tttextbox17, "Text", this.__ttObject, "PA_Address.ForeignAddress");
        redirectProperty(this.RelativeFullName, "Text", this.__ttObject, "PA_Address.RelativeFullName");
        redirectProperty(this.RelativeHomeAddress, "Text", this.__ttObject, "PA_Address.RelativeHomeAddress");
        redirectProperty(this.RelativeMobilePhone, "Text", this.__ttObject, "PA_Address.RelativeMobilePhone");
        redirectProperty(this.BusinessAddress, "Text", this.__ttObject, "PA_Address.BusinessAddress");
        redirectProperty(this.tttextbox9, "Text", this.__ttObject, "PA_Address.BuildingBlockName");
        redirectProperty(this.txtParcel, "Text", this.__ttObject, "PA_Address.SiteName");
        redirectProperty(this.YabanciSehir, "Text", this.__ttObject, "PA_Address.ForeignCity");
        redirectProperty(this.tttextbox11, "Text", this.__ttObject, "PA_Address.BuildingCode");
        redirectProperty(this.YabanciUlke, "Text", this.__ttObject, "PA_Address.ForeignCountry");
        redirectProperty(this.tttextbox10, "Text", this.__ttObject, "Episode.Patient.EMail");
        redirectProperty(this.provizyonTarihi, "Value", this.__ttObject, "SubEpisodeProtocol.MedulaProvizyonTarihi");
        redirectProperty(this.SigortaliTuru, "SelectedObject", this.__ttObject, "MedulaSigortaliTuru");
        redirectProperty(this.takipAlCevap, "Text", this.__ttObject, "takipAlCevap");
        redirectProperty(this.medulaTakipNo, "Text", this.__ttObject, "SubEpisodeProtocol.MedulaTakipNo");
        redirectProperty(this.MedulaIstisnaiHalComboBox, "SelectedObject", this.__ttObject, "MedulaIstisnaiHal");
        redirectProperty(this.takipAlHataMesaji, "Text", this.__ttObject, "takipAlHataMesaji");
        redirectProperty(this.txtYUPASSNO, "Text", this.__ttObject, "Episode.Patient.YUPASSNO");
        redirectProperty(this.txtYUPASSID, "Text", this.__ttObject, "SubEpisodeProtocol.MedulaYupassNo");
        redirectProperty(this.plakaNo, "Text", this.__ttObject, "SubEpisodeProtocol.MedulaPlakaNo");
        redirectProperty(this.RelatedProvision, "Text", this.__ttObject, "RelatedProvision");
        redirectProperty(this.yesilKartSevkEdenTesisKodu, "Text", this.__ttObject, "MedulaProvision.GreenCardSendingFacilityCode");
        redirectProperty(this.AdmissionType, "SelectedObject", this.__ttObject, "AdmissionType");
        redirectProperty(this.AcilTriaj, "SelectedObject", this.__ttObject, "Triage");
        redirectProperty(this.IsNewBorn, "Value", this.__ttObject, "IsNewBorn");
        redirectProperty(this.txtMotherUniqueRefNo, "Text", this.__ttObject, "Episode.Patient.Mother.UniqueRefNo");
        //redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.DispatchType, "Value", this.__ttObject, "DispatchType");
        redirectProperty(this.ApplicationReason, "Value", this.__ttObject, "ApplicationReason");
        redirectProperty(this.PatientClassGroup, "Value", this.__ttObject, "PatientClassGroup");
        redirectProperty(this.DispatchedConsultationDef, "Text", this.__ttObject, "DispatchedConsultationDef");
        redirectProperty(this.DispatchEmergencyCons, "Value", this.__ttObject, "DispatchEmergencyCons");
        redirectProperty(this.HCModeOfPayment, "Value", this.__ttObject, "HCModeOfPayment");
        redirectProperty(this.cbx112, "Value", this.__ttObject, "Sevkli112");
        redirectProperty(this.Emergency112RefNoTextbox, "Text", this.__ttObject, "Emergency112RefNo");
        redirectProperty(this.BeneficiaryUniqueRefNo, "Text", this.__ttObject, "BeneficiaryUniqueRefNo");
        redirectProperty(this.BeneficiaryName, "Text", this.__ttObject, "BeneficiaryName");
        redirectProperty(this.DonorUniqueRefNo, "Text", this.__ttObject, "Episode.Patient.DonorUniqueRefNo");
        redirectProperty(this.ExternalHospital, "Text", this.__ttObject, "ExternalHospital");
        redirectProperty(this.Donor, "Text", this.__ttObject, "Donor");
    }

    keyDown(event: any) {
        if (!(new RegExp('[^0-9]', 'g')).test(event.key)) {
            event.preventDefault(); return false;
        }
        else {
            return true;
        }
    }

    keyDownForNumericControl(event: any) {

        if (event != null && event.srcElement != null && event.srcElement.value != null && event.srcElement.value.length < 11 && !(new RegExp('[\.,]', 'g')).test(event.key)) {

        }
        else {
            event.preventDefault();
        }
    }


    public initFormControls(): void {
        this.PatientListPanel = new TTVisual.TTPanel();
        this.PatientListPanel.AutoSize = true;
        this.PatientListPanel.Name = "PatientListPanel";
        this.PatientListPanel.TabIndex = 158;

        this.btnSearchList = new TTVisual.TTButton();
        this.btnSearchList.Text = "Listele";
        this.btnSearchList.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.btnSearchList.Name = "btnSearchList";
        this.btnSearchList.TabIndex = 5;

        this.btnClearPatientListPanel = new TTVisual.TTButton();
        this.btnClearPatientListPanel.Text = i18n("M23181", "Temizle");
        this.btnClearPatientListPanel.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.btnClearPatientListPanel.Name = "btnClearPatientListPanel";
        this.btnClearPatientListPanel.TabIndex = 6;


        //this.PoliclinicSearchList = new TTVisual.TTObjectListBox();
        //this.PoliclinicSearchList.LinkedRelationPath = "RESOURCESPECIALITIES.SPECIALITY";
        //this.PoliclinicSearchList.ListDefName = "PoliclinicAndEmergencyListDefinition";
        //this.PoliclinicSearchList.Name = "PoliclinicSearchList";
        //this.PoliclinicSearchList.TabIndex = 3;

        this.EducationStatus = new TTVisual.TTObjectListBox();
        this.EducationStatus.ListDefName = "SKRSOgrenimDurumuList";
        this.EducationStatus.Name = "EducationStatus";
        this.EducationStatus.TabIndex = 170;
        this.EducationStatus.AutoCompleteDialogWidth = "40%";

        this.SKRSMaritalStatus = new TTVisual.TTObjectListBox();
        this.SKRSMaritalStatus.ListDefName = "SKRSMedeniHaliList";
        this.SKRSMaritalStatus.Name = "SKRSMaritalStatus";
        this.SKRSMaritalStatus.TabIndex = 170;

        this.SKRSOzurlulukDurumu = new TTVisual.TTObjectListBox();
        this.SKRSOzurlulukDurumu.ListDefName = "SKRSOzurlulukDurumuList";
        this.SKRSOzurlulukDurumu.Name = "SKRSOzurlulukDurumu";


        this.Occupation = new TTVisual.TTObjectListBox();
        this.Occupation.ListDefName = "SKRSMesleklerList";
        this.Occupation.Name = "Occupation";
        this.Occupation.TabIndex = 169;
        this.Occupation.AutoCompleteDialogWidth = "40%";


        this.AppointmentlistView = <TTVisual.TTListView>{
            Visible: true,
            ReadOnly: false,
            BackColor: "black",
            ForeColor: "yellow",
            EnablePaging: false,
            RowDisablePath: 'Disable',
            PageSize: 100000,
            Font: {
                Bold: false,
                Italic: false,
                Name: "Impact",
                Size: 11,
                Strikeout: false,
                Underline: false
            },
            Columns: [
                { Text: "Tarih", DataType: 'date', Format: 'yyyy-MM-dd HH:mm' },
                { Text: "Birim" },
                { Text: "Doktor" },
                { Text: i18n("M19485", "Notlar") }
            ]
        };
        this.AppointmentlistView.Name = "AppointmentlistView";
        this.AppointmentlistView.TabIndex = 0;
        this.AppointmentlistView.MultiSelect = false;
        this.AppointmentlistView.ShowFilterRow = false;

        this.PatientlistView = <TTVisual.TTListView>{
            Visible: true,
            ReadOnly: false,
            BackColor: "black",
            ForeColor: "yellow",
            EnablePaging: false,
            RowDisablePath: 'Disable',
            PageSize: 100000,
            Font: {
                Bold: false,
                Italic: false,
                Name: "Impact",
                Size: 11,
                Strikeout: false,
                Underline: false
            },
            Columns: [
                { Text: i18n("M10498", "Ad Soyad") },
                { Text: i18n("M17021", "Kabul No") },
                { Text: "Tarih", DataType: 'date', Format: 'dd/MM/yyyy' },
                { Text: "Birim" }
            ]
        };
        this.PatientlistView.Name = "PatientlistView";
        this.PatientlistView.TabIndex = 0;
        this.PatientlistView.MultiSelect = false;
        this.PatientlistView.ShowFilterRow = true;
        this.PatientlistView.Height = '100%';

        this.PatientHistoryPanel = new TTVisual.TTPanel();
        this.PatientHistoryPanel.AutoSize = true;
        this.PatientHistoryPanel.Name = "PatientHistoryPanel";
        this.PatientHistoryPanel.TabIndex = 157;



        this.PatientHistoryListView = <TTVisual.TTListView>{
            Visible: true,
            Height: '90%',
            ReadOnly: false,
            BackColor: "black",
            ForeColor: "yellow",
            RowDisablePath: 'Disable',
            Font: {
                Bold: false,
                Italic: false,
                Name: "Impact",
                Size: 11,
                Strikeout: false,
                Underline: false
            },
            Columns: [
                { Text: i18n("M17021", "Kabul No") },
                { Text: i18n("M14664", "Geliş Sebebi") },
                { Text: i18n("M17037", "Kabul Tipi") },
                { Text: i18n("M17017", "Kabul Durumu") },
                { Text: i18n("M17034", "Tarih"), DataType: 'date', Format: 'dd/MM/yyyy' },
                { Text: i18n("M20431", "Poliklinik") },
                { Text: i18n("M27330", "Doktor") },
                { Text: i18n("M18009", "Kurum") },
                { Text: i18n("M18821", "Provizyon No") },
                { Text: i18n("M17009", "Kabul Alan Kullanıcı") }
            ]
        };
        this.PatientHistoryListView.Name = "PatientHistoryListView";
        this.PatientHistoryListView.TabIndex = 0;
        this.PatientHistoryListView.Height = '90%';
        this.PatientHistoryListView.MultiSelect = false;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 156;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 2;
        this.tttabpage1.Text = i18n("M12581", "Demografik Bilgiler");
        this.tttabpage1.Name = "tttabpage1";

        this.ttgroupbox3 = new TTVisual.TTGroupBox();
        this.ttgroupbox3.Name = "ttgroupbox3";
        this.ttgroupbox3.TabIndex = 53;

        this.BirthDate = new TTVisual.TTDateTimePicker();
        this.BirthDate.Format = DateTimePickerFormat.Short;
        this.BirthDate.Name = "BirthDate";
        this.BirthDate.TabIndex = 165;
        //this.BirthDate.CustomFormat = "dd/MM/yyyy";

        this.Death = new TTVisual.TTCheckBox();
        this.Death.Value = false;
        this.Death.Name = "Death";
        this.Death.TabIndex = 164;

        this.Donor = new TTVisual.TTCheckBox();
        this.Donor.Value = false;
        this.Donor.Name = "Donor";
        this.Donor.TabIndex = 164;

        this.ttgroupbox4 = new TTVisual.TTGroupBox();
        this.ttgroupbox4.Text = i18n("M17600", "Kişisel Bilgiler");
        this.ttgroupbox4.Name = "ttgroupbox4";
        this.ttgroupbox4.TabIndex = 54;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 46;

        this.ttlabel54 = new TTVisual.TTLabel();
        this.ttlabel54.Text = "YUPASS Takip";
        this.ttlabel54.Name = "ttlabel54";
        this.ttlabel54.TabIndex = 45;

        this.ttlabel60 = new TTVisual.TTLabel();
        this.ttlabel60.Text = i18n("M10483", "Açıklamalar");
        this.ttlabel60.Name = "ttlabel60";
        this.ttlabel60.TabIndex = 32;

        this.ImportantPAInfo = new TTVisual.TTTextBox();
        this.ImportantPAInfo.Multiline = true;
        this.ImportantPAInfo.Name = "ImportantPAInfo";
        this.ImportantPAInfo.TabIndex = 33;

        this.ImportantPatientInfo = new TTVisual.TTTextBox();
        this.ImportantPatientInfo.Multiline = true;
        this.ImportantPatientInfo.Name = "ImportantPatientInfo";

        this.ForeignUniqueNo = new TTVisual.TTTextBox();
        this.ForeignUniqueNo.BackColor = "#F0F0F0";
        this.ForeignUniqueNo.ReadOnly = false;
        this.ForeignUniqueNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ForeignUniqueNo.Name = "ForeignUniqueNo";
        this.ForeignUniqueNo.TabIndex = 3;


        this.Age = new TTVisual.TTTextBox();
        //this.Age.BackColor = "#F0F0F0";
        this.Age.ReadOnly = true;
        this.Age.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Age.Name = "Age";

        this.DeathReportNo = new TTVisual.TTTextBox();
        this.DeathReportNo.BackColor = "#F0F0F0";
        this.DeathReportNo.ReadOnly = true;
        this.DeathReportNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DeathReportNo.Name = "DeathReportNo";

        this.PassportNo = new TTVisual.TTTextBox();
        this.PassportNo.Name = "PassportNo";
        this.PassportNo.TabIndex = 44;

        this.ttlabel62 = new TTVisual.TTLabel();
        this.ttlabel62.Text = "YUPASS No";
        this.ttlabel62.Name = "ttlabel62";
        this.ttlabel62.TabIndex = 41;

        this.ttlabel66 = new TTVisual.TTLabel();
        this.ttlabel66.Text = i18n("M20214", "Pasaport No");
        this.ttlabel66.Name = "ttlabel66";
        this.ttlabel66.TabIndex = 43;

        this.BloodGroup = new TTVisual.TTObjectListBox();
        this.BloodGroup.ListDefName = "SKRSKanGrubuList";
        this.BloodGroup.Name = "BloodGroupType";
        this.BloodGroup.TabIndex = 22;

        this.SKRSAdliVaka = new TTVisual.TTObjectListBox();
        this.SKRSAdliVaka.ListDefName = "SKRSAdliVakaGelisSekliList";
        this.SKRSAdliVaka.Name = "SKRSAdliVaka";
        this.SKRSAdliVaka.TabIndex = 22;

        this.SKRSYabanciHasta = new TTVisual.TTObjectListBox();
        this.SKRSYabanciHasta.ListDefName = "SKRSYabanciHastaTuruList";
        this.SKRSYabanciHasta.Name = "SKRSYabanciHasta";
        this.SKRSYabanciHasta.TabIndex = 22;


        this.ttlabel85 = new TTVisual.TTLabel();
        this.ttlabel85.Text = i18n("M14818", "Gizlilik sebebi");
        this.ttlabel85.Name = "ttlabel85";
        this.ttlabel85.TabIndex = 61;

        this.ttlabel16 = new TTVisual.TTLabel();
        this.ttlabel16.Text = i18n("M21070", "Rumuz Soyad");
        this.ttlabel16.Name = "ttlabel16";
        this.ttlabel16.TabIndex = 60;

        this.ExDate = new TTVisual.TTMaskedTextBox();
        this.ExDate.Mask = "00/00/0000 ";
        this.ExDate.ReadOnly = false;
        this.ExDate.Text = "  .  .     ";
        this.ExDate.BackColor = "#F0F0F0";
        this.ExDate.Name = "ExDate";
        this.ExDate.TabIndex = 14;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M21068", "Rumuz Ad");
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 59;

        this.labelExDate = new TTVisual.TTLabel();
        this.labelExDate.Text = i18n("M19944", "Ölüm Tarihi");
        this.labelExDate.BackColor = "#DCDCDC";
        this.labelExDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelExDate.ForeColor = "#000000";
        this.labelExDate.Name = "labelExDate";
        this.labelExDate.TabIndex = 22;

        this.TownOfRegistry = new TTVisual.TTObjectListBox();
        this.TownOfRegistry.LinkedControlName = "CityOfRegistry";
        this.TownOfRegistry.ListDefName = "TownListDefinition";
        this.TownOfRegistry.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TownOfRegistry.Name = "TownOfRegistry";
        this.TownOfRegistry.TabIndex = 21;
        this.TownOfRegistry.AutoCompleteDialogWidth = "40%";

        this.ttlabel61 = new TTVisual.TTLabel();
        this.ttlabel61.Text = i18n("M17426", "Kayıtlı Olduğu İlçe");
        this.ttlabel61.BackColor = "#DCDCDC";
        this.ttlabel61.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel61.ForeColor = "#000000";
        this.ttlabel61.Name = "ttlabel61";
        this.ttlabel61.TabIndex = 35;

        this.HomeAddress = new TTVisual.TTTextBox();
        this.HomeAddress.Multiline = false;
        this.HomeAddress.Name = "HomeAddress";
        this.HomeAddress.TabIndex = 52;

        this.OtherBirthPlace = new TTVisual.TTTextBox();
        this.OtherBirthPlace.Multiline = false;
        this.OtherBirthPlace.Name = "OtherBirthPlace";
        this.OtherBirthPlace.CharacterCasing = CharacterCasing.Upper;
        this.OtherBirthPlace.TabIndex = 552;

        this.CityOfRegistry = new TTVisual.TTObjectListBox();
        this.CityOfRegistry.ListDefName = "CityListDefinition";
        this.CityOfRegistry.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CityOfRegistry.Name = "CityOfRegistry";
        this.CityOfRegistry.TabIndex = 18;
        this.CityOfRegistry.AutoCompleteDialogWidth = "40%";

        this.ttlabel63 = new TTVisual.TTLabel();
        this.ttlabel63.Text = i18n("M17432", "Kayıtlı Olduğu Yer İl");
        this.ttlabel63.BackColor = "#DCDCDC";
        this.ttlabel63.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel63.ForeColor = "#000000";
        this.ttlabel63.Name = "ttlabel63";
        this.ttlabel63.TabIndex = 33;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M18009", "Kurum");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 0;

        this.labelName = new TTVisual.TTLabel();
        this.labelName.Text = "Ad";
        this.labelName.BackColor = "#DCDCDC";
        this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelName.ForeColor = "#000000";
        this.labelName.Name = "labelName";
        this.labelName.TabIndex = 18;

        this.lblAdres = new TTVisual.TTLabel();
        this.lblAdres.Text = "Adres";
        this.lblAdres.Name = "lblAdres";
        this.lblAdres.TabIndex = 51;




        this.BDYearOnly = new TTVisual.TTCheckBox();
        this.BDYearOnly.Value = false;
        this.BDYearOnly.Text = i18n("M24661", "Yıl");
        this.BDYearOnly.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BDYearOnly.Name = "BDYearOnly";
        this.BDYearOnly.TabIndex = 16;
        this.BDYearOnly.Visible = false;

        this.YupasNo = new TTVisual.TTTextBox();
        this.YupasNo.Name = "YupasNo";
        this.YupasNo.TabIndex = 2;

        //this.CityOfBirth = new TTVisual.TTObjectListBox();
        //this.CityOfBirth.LinkedControlName = "CountryOfBirth";
        //this.CityOfBirth.ListDefName = "SKRSILKodlariList";
        //this.CityOfBirth.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.CityOfBirth.Name = "CityOfBirth";
        //this.CityOfBirth.TabIndex = 17;
        //this.CityOfBirth.AutoCompleteDialogWidth = "40%";

        this.ttlabel28 = new TTVisual.TTLabel();
        this.ttlabel28.Text = i18n("M11037", "Anne Adı");
        this.ttlabel28.Name = "ttlabel28";
        this.ttlabel28.TabIndex = 49;

        this.labelFatherName = new TTVisual.TTLabel();
        this.labelFatherName.Text = i18n("M11390", "Baba Adı");
        this.labelFatherName.BackColor = "#DCDCDC";
        this.labelFatherName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelFatherName.ForeColor = "#000000";
        this.labelFatherName.Name = "labelFatherName";
        this.labelFatherName.TabIndex = 16;


        this.AnlasmaliKurum = new TTVisual.TTObjectListBox();
        this.AnlasmaliKurum.ListDefName = "ProtocolListDefinition";
        this.AnlasmaliKurum.Name = "AnlasmaliKurum";
        this.AnlasmaliKurum.TabIndex = 48;
        this.AnlasmaliKurum.AutoCompleteDialogWidth = "40%";

        this.ttlabel26 = new TTVisual.TTLabel();
        this.ttlabel26.Text = i18n("M13139", "Doğum Yeri");
        this.ttlabel26.BackColor = "#DCDCDC";
        this.ttlabel26.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel26.ForeColor = "#000000";
        this.ttlabel26.Name = "ttlabel26";
        this.ttlabel26.TabIndex = 33;

        this.ttlabel27 = new TTVisual.TTLabel();
        this.ttlabel27.Text = i18n("M11023", "Anlaşma");
        this.ttlabel27.Name = "ttlabel27";
        this.ttlabel27.TabIndex = 47;

        this.labelSurname = new TTVisual.TTLabel();
        this.labelSurname.Text = i18n("M22202", "Soyad");
        this.labelSurname.BackColor = "#DCDCDC";
        this.labelSurname.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSurname.ForeColor = "#000000";
        this.labelSurname.Name = "labelSurname";
        this.labelSurname.TabIndex = 12;

        this.ttlabel29 = new TTVisual.TTLabel();
        this.ttlabel29.Text = "Kimlik/Sigorta No(Yb)";
        this.ttlabel29.BackColor = "#DCDCDC";
        this.ttlabel29.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel29.ForeColor = "#000000";
        this.ttlabel29.Name = "ttlabel29";
        this.ttlabel29.TabIndex = 37;

        this.labelBirthDate = new TTVisual.TTLabel();
        this.labelBirthDate.Text = i18n("M13132", "Doğum Tarihi");
        this.labelBirthDate.BackColor = "#DCDCDC";
        this.labelBirthDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelBirthDate.ForeColor = "#000000";
        this.labelBirthDate.Name = "labelBirthDate";
        this.labelBirthDate.TabIndex = 22;

        this.Sex = new TTVisual.TTObjectListBox();
        this.Sex.ListDefName = "SKRSCinsiyetList";
        this.Sex.Name = "Sex";
        this.Sex.TabIndex = 166;
        this.Sex.AutoCompleteDialogWidth = "40%";

        this.labelSex = new TTVisual.TTLabel();
        this.labelSex.Text = i18n("M12265", "Cinsiyet");
        this.labelSex.BackColor = "#DCDCDC";
        this.labelSex.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSex.ForeColor = "#000000";
        this.labelSex.Name = "labelSex";
        this.labelSex.TabIndex = 10;

        this.ttlabel33 = new TTVisual.TTLabel();
        this.ttlabel33.Text = i18n("M12323", "Çalışma Durumu");
        this.ttlabel33.Name = "ttlabel33";
        this.ttlabel33.TabIndex = 3;

        this.PayerList = new TTVisual.TTObjectListBox();
        this.PayerList.ListDefName = "PayerListDefinition";
        this.PayerList.Name = "PayerList";
        this.PayerList.TabIndex = 4;
        this.PayerList.AutoCompleteDialogWidth = "40%";

        this.UnIdentified = new TTVisual.TTCheckBox();
        this.UnIdentified.Value = false;
        this.UnIdentified.Title = i18n("M17577", "Kimlik Bilinmiyor");
        this.UnIdentified.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.UnIdentified.Name = "UnIdentified";
        this.UnIdentified.TabIndex = 12;

        this.Foreign = new TTVisual.TTCheckBox();
        this.Foreign.Value = false;
        this.Foreign.Text = i18n("M24233", "Yabancı");
        this.Foreign.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Foreign.Name = "Foreign";
        this.Foreign.TabIndex = 9;

        this.SearchListWithProvision = new TTVisual.TTCheckBox();
        this.SearchListWithProvision.Value = false;
        this.SearchListWithProvision.Text = i18n("M24233", "Yabancı");
        this.SearchListWithProvision.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SearchListWithProvision.Name = "SearchListWithProvision";
        this.SearchListWithProvision.TabIndex = 9;

        this.SearchListWithoutProvision = new TTVisual.TTCheckBox();
        this.SearchListWithoutProvision.Value = false;
        this.SearchListWithoutProvision.Title = i18n("M24233", "Provizyonsuz Hastalar");
        this.SearchListWithoutProvision.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SearchListWithoutProvision.Name = "SearchListWithoutProvision";
        this.SearchListWithoutProvision.TabIndex = 9;

        this.labelUniqueRefNo = new TTVisual.TTLabel();
        this.labelUniqueRefNo.Text = i18n("M22513", "T.C. Kimlik No");
        this.labelUniqueRefNo.BackColor = "#DCDCDC";
        this.labelUniqueRefNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelUniqueRefNo.ForeColor = "#000000";
        this.labelUniqueRefNo.Name = "labelUniqueRefNo";
        this.labelUniqueRefNo.TabIndex = 20;

        this.UniqueRefNo = new TTVisual.TTTextBox();
        this.UniqueRefNo.InputFormat = InputFormat.AlphaOnly;
        this.UniqueRefNo.CharacterCasing = CharacterCasing.Upper;
        this.UniqueRefNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.UniqueRefNo.Name = "UniqueRefNo";
        this.UniqueRefNo.TabIndex = 0;

        this.BeneficiaryUniqueRefNo = new TTVisual.TTTextBox();
        this.BeneficiaryUniqueRefNo.InputFormat = InputFormat.AlphaOnly;
        this.BeneficiaryUniqueRefNo.CharacterCasing = CharacterCasing.Upper;
        this.BeneficiaryUniqueRefNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BeneficiaryUniqueRefNo.Name = "BeneficiaryUniqueRefNo";

        this.PatientNumber = new TTVisual.TTTextBox();
        this.PatientNumber.InputFormat = InputFormat.AlphaOnly;
        this.PatientNumber.CharacterCasing = CharacterCasing.Upper;
        this.PatientNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientNumber.Name = "PatientNumber";
        this.PatientNumber.TabIndex = 90;

        this.WorkPhone = new TTVisual.TTTextBox();
        this.WorkPhone.Name = "WorkPhone";
        this.WorkPhone.TabIndex = 75;

        this.BusinessPhone = new TTVisual.TTMaskedTextBox();
        this.BusinessPhone.Mask = "999 9999999";
        this.BusinessPhone.Name = "BusinessPhone";
        this.BusinessPhone.TabIndex = 7;

        this.MobilePhone = new TTVisual.TTMaskedTextBox();
        this.MobilePhone.Mask = "000 0000000";
        this.MobilePhone.Name = "MobilePhone";
        this.MobilePhone.TabIndex = 7;

        this.CityOfBirth = new TTVisual.TTTextBox();
        this.CityOfBirth.InputFormat = InputFormat.Normal;
        this.CityOfBirth.IsNonNumeric = true;
        this.CityOfBirth.CharacterCasing = CharacterCasing.Upper;
        this.CityOfBirth.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CityOfBirth.Name = "CityOfBirth";
        this.CityOfBirth.TabIndex = 17;

        this.FatherName = new TTVisual.TTTextBox();
        this.FatherName.InputFormat = InputFormat.AlphaOnly;
        this.FatherName.IsNonNumeric = true;
        this.FatherName.CharacterCasing = CharacterCasing.Upper;
        this.FatherName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FatherName.Name = "FatherName";
        this.FatherName.TabIndex = 7;


        this.MotherName = new TTVisual.TTTextBox();
        this.MotherName.IsNonNumeric = true;
        this.MotherName.InputFormat = InputFormat.AlphaOnly;
        this.MotherName.Name = "MotherName";
        this.MotherName.CharacterCasing = CharacterCasing.Upper;
        this.MotherName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MotherName.TabIndex = 50;
        //this.MotherName.Required = true;


        this.Nationality = new TTVisual.TTObjectListBox();
        this.Nationality.ListDefName = "SKRSUlkeKodlariList";
        this.Nationality.Name = "Nationality";
        this.Nationality.TabIndex = 60;
        this.Nationality.AutoCompleteDialogWidth = "40%";

        this.ttlabel35 = new TTVisual.TTLabel();
        this.ttlabel35.Text = i18n("M12198", "Cep Telefonu");
        this.ttlabel35.Name = "ttlabel35";
        this.ttlabel35.TabIndex = 2;

        this.Name = new TTVisual.TTTextBox();
        this.Name.InputFormat = InputFormat.AlphaOnly;
        this.Name.CharacterCasing = CharacterCasing.Upper;
        this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Name.Name = "Name";
        this.Name.TabIndex = 4;

        this.Surname = new TTVisual.TTTextBox();
        this.Surname.InputFormat = InputFormat.AlphaOnly;
        this.Surname.CharacterCasing = CharacterCasing.Upper;
        this.Surname.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Surname.Name = "Surname";
        this.Surname.TabIndex = 5;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = i18n("M17575", "Kimlik / Adres Bilgileri");
        this.tttabpage2.Name = "tttabpage2";

        this.GrpAddressInfo = new TTVisual.TTGroupBox();
        this.GrpAddressInfo.Text = i18n("M16411", "İletişim Bilgileri");
        this.GrpAddressInfo.Name = "GrpAddressInfo";
        this.GrpAddressInfo.TabIndex = 35;

        this.SubEpisodesSubEpisode = new TTVisual.TTGrid();
        this.SubEpisodesSubEpisode.Name = "SubEpisodesSubEpisode";
        this.SubEpisodesSubEpisode.TabIndex = 78;

        this.ProtocolNoSubEpisode = new TTVisual.TTTextBoxColumn();
        this.ProtocolNoSubEpisode.DataMember = "ProtocolNo";
        this.ProtocolNoSubEpisode.DisplayIndex = 0;
        this.ProtocolNoSubEpisode.HeaderText = "ProtokolNo";
        this.ProtocolNoSubEpisode.Name = "ProtocolNoSubEpisode";
        this.ProtocolNoSubEpisode.Width = 80;

        this.txtEpisode = new TTVisual.TTTextBox();
        this.txtEpisode.Name = "txtEpisode";
        this.txtEpisode.TabIndex = 77;

        this.BusinessAddress = new TTVisual.TTTextBox();
        this.BusinessAddress.Multiline = true;
        this.BusinessAddress.Name = "BusinessAddress";
        this.BusinessAddress.TabIndex = 76;

        this.BeneficiaryName = new TTVisual.TTTextBox();
        this.BeneficiaryName.Multiline = false;
        this.BeneficiaryName.Name = "BeneficiaryName";
        this.BeneficiaryName.TabIndex = 76;

        this.RelativeFullName = new TTVisual.TTTextBox();
        this.RelativeFullName.Name = "RelativeFullName";
        this.RelativeFullName.TabIndex = 176;

        this.RelativeHomeAddress = new TTVisual.TTTextBox();
        this.RelativeHomeAddress.Multiline = true;
        this.RelativeHomeAddress.Name = "RelativeHomeAddress";
        this.RelativeHomeAddress.TabIndex = 177;

        this.RelativeMobilePhone = new TTVisual.TTMaskedTextBox();
        this.RelativeMobilePhone.Mask = "999 9999999";
        this.RelativeMobilePhone.Name = "RelativeMobilePhone";
        this.RelativeMobilePhone.TabIndex = 7;

        this.YabanciUlke = new TTVisual.TTTextBox();
        this.YabanciUlke.Name = "YabanciUlke";
        this.YabanciUlke.TabIndex = 74;

        this.YabanciSehir = new TTVisual.TTTextBox();
        this.YabanciSehir.Name = "YabanciSehir";
        this.YabanciSehir.CharacterCasing = CharacterCasing.Upper;
        this.YabanciSehir.TabIndex = 73;



        this.ttlabel50 = new TTVisual.TTLabel();
        this.ttlabel50.Text = i18n("M13985", "Ev Telefon");
        this.ttlabel50.Name = "ttlabel50";
        this.ttlabel50.TabIndex = 72;

        this.ttlabel49 = new TTVisual.TTLabel();
        this.ttlabel49.Text = i18n("M24239", "Yabancı Ülke");
        this.ttlabel49.Name = "ttlabel49";
        this.ttlabel49.TabIndex = 70;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 9;

        this.ttlabel48 = new TTVisual.TTLabel();
        this.ttlabel48.Text = i18n("M24238", "Yabancı Şehir");
        this.ttlabel48.Name = "ttlabel48";
        this.ttlabel48.TabIndex = 68;

        this.tttextbox17 = new TTVisual.TTTextBox();
        this.tttextbox17.Name = "tttextbox17";
        this.tttextbox17.TabIndex = 67;

        this.ttlabel47 = new TTVisual.TTLabel();
        this.ttlabel47.Text = i18n("M24234", "Yabancı Adres");
        this.ttlabel47.Name = "ttlabel47";
        this.ttlabel47.TabIndex = 66;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "SKRSMahalleKodlariList";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 65;

        this.ttlabel46 = new TTVisual.TTLabel();
        this.ttlabel46.Text = i18n("M18436", "Mahalle");
        this.ttlabel46.Name = "ttlabel46";
        this.ttlabel46.TabIndex = 64;

        this.SigortaliTuru = new TTVisual.TTObjectListBox();
        this.SigortaliTuru.ListDefName = "SigortaliTuruListDefinition";
        this.SigortaliTuru.Name = "SigortaliTuru";
        this.SigortaliTuru.TabIndex = 34;

        this.ttobjectlistbox3 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox3.ListDefName = "SKRSKoyKodlariList";
        this.ttobjectlistbox3.Name = "ttobjectlistbox3";
        this.ttobjectlistbox3.TabIndex = 63;

        this.ttlabel45 = new TTVisual.TTLabel();
        this.ttlabel45.Text = i18n("M17848", "Köy");
        this.ttlabel45.Name = "ttlabel45";
        this.ttlabel45.TabIndex = 62;

        this.ttobjectlistbox4 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox4.ListDefName = "SKRSCSBMTipiList";
        this.ttobjectlistbox4.Name = "ttobjectlistbox4";
        this.ttobjectlistbox4.TabIndex = 61;

        this.ttobjectlistbox5 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox5.ListDefName = "SKRSBucakKodlariList";
        this.ttobjectlistbox5.Name = "ttobjectlistbox5";
        this.ttobjectlistbox5.TabIndex = 60;

        this.ttobjectlistbox6 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox6.ListDefName = "TownListDefinition";
        this.ttobjectlistbox6.Name = "ttobjectlistbox6";
        this.ttobjectlistbox6.TabIndex = 59;

        this.ttlabel44 = new TTVisual.TTLabel();
        this.ttlabel44.Text = i18n("M16396", "İlçe");
        this.ttlabel44.Name = "ttlabel44";
        this.ttlabel44.TabIndex = 58;

        this.ttobjectlistbox7 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox7.ListDefName = "CityListDefinition";
        this.ttobjectlistbox7.Name = "ttobjectlistbox7";
        this.ttobjectlistbox7.TabIndex = 57;

        this.BirthOrder = new TTVisual.TTObjectListBox();
        this.BirthOrder.ListDefName = "SKRSDogumSirasiList";
        this.BirthOrder.Name = "BirthOrder";
        this.BirthOrder.TabIndex = 169;

        this.ttlabel43 = new TTVisual.TTLabel();
        this.ttlabel43.Text = i18n("M16269", "İl");
        this.ttlabel43.Name = "ttlabel43";
        this.ttlabel43.TabIndex = 56;

        this.tttextbox22 = new TTVisual.TTTextBox();
        this.tttextbox22.Name = "tttextbox22";
        this.tttextbox22.TabIndex = 55;

        this.ttlabel42 = new TTVisual.TTLabel();
        this.ttlabel42.Text = i18n("M16163", "İç Kapı No");
        this.ttlabel42.Name = "ttlabel42";
        this.ttlabel42.TabIndex = 54;

        this.tttextbox21 = new TTVisual.TTTextBox();
        this.tttextbox21.Name = "tttextbox21";
        this.tttextbox21.TabIndex = 53;

        this.ttlabel41 = new TTVisual.TTLabel();
        this.ttlabel41.Text = i18n("M12746", "Dış Kapı No");
        this.ttlabel41.Name = "ttlabel41";
        this.ttlabel41.TabIndex = 52;

        this.ttlabel40 = new TTVisual.TTLabel();
        this.ttlabel40.Text = i18n("M12293", "CSBM Kodu/Adı");
        this.ttlabel40.Name = "ttlabel40";
        this.ttlabel40.TabIndex = 49;

        this.ttlabel39 = new TTVisual.TTLabel();
        this.ttlabel39.Text = i18n("M12099", "Bucak Kodu/Adı");
        this.ttlabel39.Name = "ttlabel39";
        this.ttlabel39.TabIndex = 46;

        this.txtParcel = new TTVisual.TTTextBox();
        this.txtParcel.Name = "txtParcel";
        this.txtParcel.TabIndex = 45;

        this.ttlabel38 = new TTVisual.TTLabel();
        this.ttlabel38.Text = i18n("M11820", "Bina Site Adı");
        this.ttlabel38.Name = "ttlabel38";
        this.ttlabel38.TabIndex = 44;

        this.tttextbox15 = new TTVisual.TTTextBox();
        this.tttextbox15.Name = "tttextbox15";
        this.tttextbox15.TabIndex = 43;

        this.ttlabel37 = new TTVisual.TTLabel();
        this.ttlabel37.Text = i18n("M11819", "Bina Parsel");
        this.ttlabel37.Name = "ttlabel37";
        this.ttlabel37.TabIndex = 42;

        this.tttextbox14 = new TTVisual.TTTextBox();
        this.tttextbox14.Name = "tttextbox14";
        this.tttextbox14.TabIndex = 41;

        this.ttlabel36 = new TTVisual.TTLabel();
        this.ttlabel36.Text = i18n("M11818", "Bina Pafta");
        this.ttlabel36.Name = "ttlabel36";
        this.ttlabel36.TabIndex = 40;

        this.tttextbox13 = new TTVisual.TTTextBox();
        this.tttextbox13.Name = "tttextbox13";
        this.tttextbox13.TabIndex = 39;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M11816", "Bina No");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 38;

        this.tttextbox11 = new TTVisual.TTTextBox();
        this.tttextbox11.Name = "tttextbox11";
        this.tttextbox11.TabIndex = 37;

        this.ttlabel34 = new TTVisual.TTLabel();
        this.ttlabel34.Text = i18n("M11814", "Bina Kodu");
        this.ttlabel34.Name = "ttlabel34";
        this.ttlabel34.TabIndex = 36;

        this.tttextbox9 = new TTVisual.TTTextBox();
        this.tttextbox9.Name = "tttextbox9";
        this.tttextbox9.TabIndex = 35;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M11813", "Bina Blok Adı");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 34;

        this.ttmaskedtextbox2 = new TTVisual.TTMaskedTextBox();
        this.ttmaskedtextbox2.Name = "ttmaskedtextbox2";
        this.ttmaskedtextbox2.TabIndex = 33;

        this.ttlabel32 = new TTVisual.TTLabel();
        this.ttlabel32.Text = "Bina Ada";
        this.ttlabel32.Name = "ttlabel32";
        this.ttlabel32.TabIndex = 32;

        this.tttextbox8 = new TTVisual.TTTextBox();
        this.tttextbox8.Name = "tttextbox8";
        this.tttextbox8.TabIndex = 31;

        this.ttlabel21 = new TTVisual.TTLabel();
        this.ttlabel21.Text = i18n("M10552", "Adres Tipi");
        this.ttlabel21.Name = "ttlabel21";
        this.ttlabel21.TabIndex = 30;

        this.tttextbox6 = new TTVisual.TTTextBox();
        this.tttextbox6.Name = "tttextbox6";
        this.tttextbox6.TabIndex = 29;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M10549", "Adres No");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 28;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M16779", "İş Telefonu");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 10;

        this.ttlabel23 = new TTVisual.TTLabel();
        this.ttlabel23.Text = i18n("M16741", "İş Adresi");
        this.ttlabel23.Name = "ttlabel23";
        this.ttlabel23.TabIndex = 26;

        this.ttlabel22 = new TTVisual.TTLabel();
        this.ttlabel22.Text = i18n("M13804", "E-Posta");
        this.ttlabel22.Name = "ttlabel22";
        this.ttlabel22.TabIndex = 24;

        this.tttextbox10 = new TTVisual.TTTextBox();
        this.tttextbox10.Name = "tttextbox10";
        this.tttextbox10.TabIndex = 25;

        this.Tab = new TTVisual.TTTabControl();
        this.Tab.Name = "Tab";
        this.Tab.TabIndex = 133;

        this.FirstTab = new TTVisual.TTTabPage();
        this.FirstTab.DisplayIndex = 0;
        this.FirstTab.TabIndex = 6;
        this.FirstTab.Text = "Ana Ekran";
        this.FirstTab.Name = "FirstTab";

        this.AdmissionType = new TTVisual.TTListDefComboBox();
        this.AdmissionType.ListDefName = "ProvizyonTipiListDefinition";
        this.AdmissionType.Required = true;
        //this.AdmissionType.BackColor = "#FFE3C6";
        this.AdmissionType.Name = "AdmissionType";
        this.AdmissionType.TabIndex = 167;

        this.txtMotherUniqueRefNo = new TTVisual.TTTextBox();
        this.txtMotherUniqueRefNo.Name = "txtMotherUniqueRefNo";
        this.txtMotherUniqueRefNo.TabIndex = 168;

        this.IsNewBorn = new TTVisual.TTCheckBox();
        this.IsNewBorn.Value = false;
        this.IsNewBorn.Text = i18n("M24621", "Yenidoğan");
        this.IsNewBorn.Name = "IsNewBorn";
        this.IsNewBorn.TabIndex = 166;

        this.ttgroupbox5 = new TTVisual.TTGroupBox();
        this.ttgroupbox5.Text = i18n("M18736", "Medula Bilgileri");
        this.ttgroupbox5.Name = "ttgroupbox5";
        this.ttgroupbox5.TabIndex = 134;

        this.labelExternalHospital = new TTVisual.TTLabel();
        this.labelExternalHospital.Text = "Geldiği XXXXXX";
        this.labelExternalHospital.Name = "labelExternalHospital";
        this.labelExternalHospital.TabIndex = 57;

        this.ExternalHospital = new TTVisual.TTObjectListBox();
        this.ExternalHospital.ListDefName = "ExternalHospitalListDefinition";
        this.ExternalHospital.Name = "ExternalHospital";
        this.ExternalHospital.TabIndex = 56;
        this.ExternalHospital.ReadOnly = true;

        this.ttlabel55 = new TTVisual.TTLabel();
        this.ttlabel55.Text = i18n("M12048", "Branş");
        this.ttlabel55.Name = "ttlabel55";
        this.ttlabel55.TabIndex = 49;
        this.ttlabel55.Visible = false;

        this.ttlabel53 = new TTVisual.TTLabel();
        this.ttlabel53.Text = i18n("M22673", "Takip Tipi");
        this.ttlabel53.Name = "ttlabel53";
        this.ttlabel53.TabIndex = 48;

        this.ttlabel31 = new TTVisual.TTLabel();
        this.ttlabel31.Text = i18n("M23037", "Tedavi Türü");
        this.ttlabel31.Name = "ttlabel31";
        this.ttlabel31.TabIndex = 47;

        this.ttlabel30 = new TTVisual.TTLabel();
        this.ttlabel30.Text = i18n("M20586", "Provizyon Tarihi");
        this.ttlabel30.Name = "ttlabel30";
        this.ttlabel30.TabIndex = 46;

        this.provizyonTarihi = new TTVisual.TTDateTimePicker();
        this.provizyonTarihi.Required = true;
        this.provizyonTarihi.BackColor = "#FFE3C6";
        this.provizyonTarihi.Format = DateTimePickerFormat.Short;
        this.provizyonTarihi.Name = "provizyonTarihi";
        this.provizyonTarihi.TabIndex = 35;

        this.RelatedProvision = new TTVisual.TTTextBox();
        this.RelatedProvision.Name = "RelatedProvision";
        this.RelatedProvision.TabIndex = 41;

        this.txtYUPASSID = new TTVisual.TTTextBox();
        this.txtYUPASSID.BackColor = "#F0F0F0";
        this.txtYUPASSID.ReadOnly = true;
        this.txtYUPASSID.Name = "txtYUPASSID";
        this.txtYUPASSID.TabIndex = 45;

        this.ttlabel77 = new TTVisual.TTLabel();
        this.ttlabel77.Text = "Bağlı Takip";
        this.ttlabel77.Name = "ttlabel77";
        this.ttlabel77.TabIndex = 40;

        this.ttlabel75 = new TTVisual.TTLabel();
        this.ttlabel75.Text = "Hastanın Devredilen Kurumu";
        this.ttlabel75.Name = "ttlabel75";
        this.ttlabel75.TabIndex = 3;

        this.ttlabel78 = new TTVisual.TTLabel();
        this.ttlabel78.Text = i18n("M18821", "Medula Takip No");
        this.ttlabel78.Name = "ttlabel78";
        this.ttlabel78.TabIndex = 37;

        this.txtYUPASSNO = new TTVisual.TTTextBox();
        this.txtYUPASSNO.BackColor = "#F0F0F0";
        this.txtYUPASSNO.ReadOnly = true;
        this.txtYUPASSNO.Name = "txtYUPASSNO";
        this.txtYUPASSNO.TabIndex = 44;

        this.medulaTakipNo = new TTVisual.TTTextBox();
        this.medulaTakipNo.BackColor = "#F0F0F0";
        this.medulaTakipNo.ReadOnly = true;
        this.medulaTakipNo.Name = "medulaTakipNo";
        this.medulaTakipNo.TabIndex = 36;

        this.takipTipi = new TTVisual.TTListDefComboBox();
        this.takipTipi.ListDefName = "TakipTipiListDefinition";
        this.takipTipi.Required = true;
        this.takipTipi.BackColor = "#FFE3C6";
        this.takipTipi.Name = "takipTipi";
        this.takipTipi.TabIndex = 5;

        this.ttlabel79 = new TTVisual.TTLabel();
        this.ttlabel79.Text = i18n("M20366", "Plaka No");
        this.ttlabel79.Name = "ttlabel79";
        this.ttlabel79.TabIndex = 30;

        this.ttlabel69 = new TTVisual.TTLabel();
        this.ttlabel69.Text = "YUPASS Takip";
        this.ttlabel69.Name = "ttlabel69";
        this.ttlabel69.TabIndex = 43;

        this.plakaNo = new TTVisual.TTTextBox();
        this.plakaNo.Name = "plakaNo";
        this.plakaNo.TabIndex = 29;

        this.ttlabel74 = new TTVisual.TTLabel();
        this.ttlabel74.Text = i18n("M23033", "Tedavi Tipi");
        this.ttlabel74.Name = "ttlabel74";
        this.ttlabel74.TabIndex = 21;

        this.takipAlHataMesaji = new TTVisual.TTTextBox();
        this.takipAlHataMesaji.Multiline = true;
        this.takipAlHataMesaji.BackColor = "#F0F0F0";
        this.takipAlHataMesaji.ReadOnly = true;
        this.takipAlHataMesaji.Name = "takipAlHataMesaji";
        this.takipAlHataMesaji.TabIndex = 28;

        this.ttlabel70 = new TTVisual.TTLabel();
        this.ttlabel70.Text = "YUPASS No";
        this.ttlabel70.Name = "ttlabel70";
        this.ttlabel70.TabIndex = 42;

        this.ttlabel80 = new TTVisual.TTLabel();
        this.ttlabel80.Text = i18n("M15545", "Hata Mesajı");
        this.ttlabel80.Name = "ttlabel80";
        this.ttlabel80.TabIndex = 27;

        this.devredilenKurum = new TTVisual.TTListDefComboBox();
        this.devredilenKurum.ListDefName = "DevredilenKurumListDefinition";
        this.devredilenKurum.Required = true;
        this.devredilenKurum.BackColor = "#FFE3C6";
        this.devredilenKurum.Name = "devredilenKurum";
        this.devredilenKurum.TabIndex = 7;

        this.takipAlCevap = new TTVisual.TTTextBox();
        this.takipAlCevap.BackColor = "#F0F0F0";
        this.takipAlCevap.ReadOnly = true;
        this.takipAlCevap.Name = "takipAlCevap";
        this.takipAlCevap.TabIndex = 26;

        this.MedulaIstisnaiHalComboBox = new TTVisual.TTListDefComboBox();
        this.MedulaIstisnaiHalComboBox.ListDefName = "IstisnaiHalListDef";
        this.MedulaIstisnaiHalComboBox.Name = "ttlistdefcombobox1";
        this.MedulaIstisnaiHalComboBox.TabIndex = 1;

        this.ttlabel81 = new TTVisual.TTLabel();
        this.ttlabel81.Text = i18n("M18816", "Medula Takip Alma Sonuç");
        this.ttlabel81.Name = "ttlabel81";
        this.ttlabel81.TabIndex = 25;

        this.tedaviTipi = new TTVisual.TTListDefComboBox();
        this.tedaviTipi.ListDefName = "TedaviTipiListDefinition";
        this.tedaviTipi.Required = true;
        this.tedaviTipi.BackColor = "#FFE3C6";
        this.tedaviTipi.Name = "tedaviTipi";
        this.tedaviTipi.TabIndex = 4;

        this.ttlabel71 = new TTVisual.TTLabel();
        this.ttlabel71.Text = i18n("M16736", "İstisnai Hal");
        this.ttlabel71.Name = "ttlabel71";
        this.ttlabel71.TabIndex = 11;

        //this.provizyonTipi = new TTVisual.TTListDefComboBox();
        //this.provizyonTipi.ListDefName = "ProvizyonTipiListDefinition";
        //this.provizyonTipi.Required = true;
        //this.provizyonTipi.BackColor = "#FFE3C6";
        //this.provizyonTipi.Name = "provizyonTipi";
        //this.provizyonTipi.TabIndex = 1;

        this.ttlabel73 = new TTVisual.TTLabel();
        this.ttlabel73.Text = i18n("M20591", "Provizyonun Tipi");
        this.ttlabel73.Name = "ttlabel73";
        this.ttlabel73.TabIndex = 11;

        this.ttlabel72 = new TTVisual.TTLabel();
        this.ttlabel72.Text = i18n("M24634", "Yeşil Kart Sevk Eden Tesis Kodu");
        this.ttlabel72.Name = "ttlabel72";
        this.ttlabel72.TabIndex = 32;
        this.ttlabel72.Visible = false;

        this.tedaviTuru = new TTVisual.TTListDefComboBox();
        this.tedaviTuru.ListDefName = "TedaviTuruListDefinition";
        this.tedaviTuru.Required = true;
        this.tedaviTuru.BackColor = "#FFE3C6";
        this.tedaviTuru.Name = "tedaviTuru";
        this.tedaviTuru.TabIndex = 2;

        this.yesilKartSevkEdenTesisKodu = new TTVisual.TTTextBox();
        this.yesilKartSevkEdenTesisKodu.Name = "yesilKartSevkEdenTesisKodu";
        this.yesilKartSevkEdenTesisKodu.TabIndex = 31;
        this.yesilKartSevkEdenTesisKodu.Visible = false;

        this.AcilTriaj = new TTVisual.TTListDefComboBox();
        this.AcilTriaj.ListDefName = "SKRSTRIAJKODUList";
        this.AcilTriaj.Name = "AcilTriaj";
        this.AcilTriaj.TabIndex = 166;

        this.MergeTriaj = new TTVisual.TTListDefComboBox();
        this.MergeTriaj.ListDefName = "SKRSTRIAJKODUList";
        this.MergeTriaj.Name = "MergeTriaj";
        this.MergeTriaj.TabIndex = 166;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M10454", "Acil Triaj Durumu");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 162;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        //this.ActionDate.CustomFormat = "";
        this.ActionDate.Format = DateTimePickerFormat.Short;
        //this.ActionDate.Enabled = true;
        this.ActionDate.ReadOnly = true;
        this.ActionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 5;

        this.MedulaVakaTarihi = new TTVisual.TTDateTimePicker();
        this.MedulaVakaTarihi.BackColor = "#F0F0F0";
        this.MedulaVakaTarihi.Format = DateTimePickerFormat.Short;
        this.MedulaVakaTarihi.ReadOnly = false;
        this.MedulaVakaTarihi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MedulaVakaTarihi.Name = "MedulaVakaTarihi";

        this.Policlinic = new TTVisual.TTObjectListBox();
        this.Policlinic.LinkedControlName = "Branch";
        this.Policlinic.LinkedRelationPath = "";
        this.Policlinic.ListDefName = "PoliclinicsListDefinition";
        this.Policlinic.Name = "Policlinic";
        this.Policlinic.TabIndex = 161;

        this.ttlabel19 = new TTVisual.TTLabel();
        this.ttlabel19.Text = i18n("M20431", "Poliklinik");
        this.ttlabel19.Name = "ttlabel19";
        this.ttlabel19.TabIndex = 160;

        this.PriorityStatus = new TTVisual.TTObjectListBox();
        this.PriorityStatus.ListDefName = "PriorityStatusListDef";
        this.PriorityStatus.Name = "PriorityStatus";
        this.PriorityStatus.TabIndex = 159;

        this.lblPriorityStatus = new TTVisual.TTLabel();
        this.lblPriorityStatus.Text = i18n("M20014", "Öncelik Durumu");
        this.lblPriorityStatus.Name = "lblPriorityStatus";
        this.lblPriorityStatus.TabIndex = 158;

        this.ttlabel18 = new TTVisual.TTLabel();
        this.ttlabel18.Text = i18n("M14664", "Geliş Sebebi");
        this.ttlabel18.Name = "ttlabel18";
        this.ttlabel18.TabIndex = 156;

        this.lblb = new TTVisual.TTLabel();
        this.lblb.Text = "Bina";
        this.lblb.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblb.Name = "lblb";
        this.lblb.TabIndex = 149;

        this.Branch = new TTVisual.TTObjectListBox();
        this.Branch.ListDefName = "DepartmentListDefinition";
        this.Branch.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Branch.Name = "Branch";
        this.Branch.TabIndex = 153;

        this.Building = new TTVisual.TTObjectListBox();
        this.Building.ListDefName = "BuildinglistDefinition";
        this.Building.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Building.Name = "Building";
        this.Building.TabIndex = 152;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = i18n("M12048", "Branş");
        this.ttlabel14.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 150;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.LinkedControlName = "Policlinic";
        this.ProcedureDoctor.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinitionForPA";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 154;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = "Doktor";
        this.ttlabel15.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 151;

        this.DispatchHospital = new TTVisual.TTTabPage();
        this.DispatchHospital.DisplayIndex = 1;
        this.DispatchHospital.TabIndex = 4;
        this.DispatchHospital.Text = i18n("M21756", "Sevkli Tetkik Kabulü");
        this.DispatchHospital.Name = "DispatchHospital";

        this.labelDispatchedConsultationDef = new TTVisual.TTLabel();
        this.labelDispatchedConsultationDef.Text = i18n("M21754", "Sevkli Konsültasyon Açıklaması");
        this.labelDispatchedConsultationDef.Name = "labelDispatchedConsultationDef";
        this.labelDispatchedConsultationDef.TabIndex = 11;
        this.labelDispatchedConsultationDef.Visible = true;

        this.DispatchedConsultationDef = new TTVisual.TTTextBox();
        this.DispatchedConsultationDef.Multiline = true;
        this.DispatchedConsultationDef.Name = "DispatchedConsultationDef";
        this.DispatchedConsultationDef.TabIndex = 10;
        this.DispatchedConsultationDef.Visible = true;

        this.taniSecimPaneli = new TTVisual.TTGroupBox();
        this.taniSecimPaneli.Text = i18n("M22767", "Tanı Seçimi");
        this.taniSecimPaneli.Name = "taniSecimPaneli";
        this.taniSecimPaneli.TabIndex = 9;
        this.taniSecimPaneli.Visible = false;

        this.tetkikIstemPaneli = new TTVisual.TTGroupBox();
        this.tetkikIstemPaneli.Text = i18n("M16879", "İşlem Seçimi");
        this.tetkikIstemPaneli.Name = "tetkikIstemPaneli";
        this.tetkikIstemPaneli.TabIndex = 8;
        this.tetkikIstemPaneli.Visible = false;

        this.DispatchType = new TTVisual.TTEnumComboBox();
        this.DispatchType.DataTypeName = "DispatchTypeEnum";
        this.DispatchType.Name = "DispatchType";
        this.DispatchType.TabIndex = 7;

        this.DispatchHospitalDoctors = new TTVisual.TTObjectListBox();
        this.DispatchHospitalDoctors.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.DispatchHospitalDoctors.ListDefName = "SpecialistDoctorListDefinitionForPA";
        this.DispatchHospitalDoctors.Name = "DispatchHospitalDoctors";
        this.DispatchHospitalDoctors.TabIndex = 6;

        this.DispatchHospitalResources = new TTVisual.TTObjectListBox();
        this.DispatchHospitalResources.ListDefName = "PoliclinicsListDefinition";
        this.DispatchHospitalResources.Name = "DispatchHospitalResources";
        this.DispatchHospitalResources.TabIndex = 5;

        this.DispatchHospitalList = new TTVisual.TTObjectListBox();
        this.DispatchHospitalList.ListFilterExpression = "TYPE.PAYERTYPE = 5";
        this.DispatchHospitalList.ListDefName = "PayerListDefinition";
        this.DispatchHospitalList.Name = "DispatchHospitalList";
        this.DispatchHospitalList.TabIndex = 4;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M21738", "Sevk Türü");
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 3;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "Doktor";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 2;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "Birim";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 1;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "XXXXXX";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 0;

        this.HealthCommittee = new TTVisual.TTTabPage();
        this.HealthCommittee.DisplayIndex = 2;
        this.HealthCommittee.TabIndex = 5;
        this.HealthCommittee.Text = i18n("M21172", "Sağlık Kurulu");
        this.HealthCommittee.Name = "HealthCommittee";

        this.ResourcesToBeReferred = new TTVisual.TTGrid();
        this.ResourcesToBeReferred.Name = "ResourcesToBeReferred";
        this.ResourcesToBeReferred.TabIndex = 14;
        this.ResourcesToBeReferred.Height = 200;
        this.ResourcesToBeReferred.DeleteButtonWidth = 50;

        this.ProcedureDoctorToBeReferredPatientAdmissionResourcesToBeReferred = new TTVisual.TTListBoxColumn();
        this.ProcedureDoctorToBeReferredPatientAdmissionResourcesToBeReferred.ListDefName = "SpecialistDoctorListDefinitionForPA";
        this.ProcedureDoctorToBeReferredPatientAdmissionResourcesToBeReferred.DataMember = "ProcedureDoctorToBeReferred";
        this.ProcedureDoctorToBeReferredPatientAdmissionResourcesToBeReferred.DisplayIndex = 1;
        this.ProcedureDoctorToBeReferredPatientAdmissionResourcesToBeReferred.HeaderText = "Doktor";
        this.ProcedureDoctorToBeReferredPatientAdmissionResourcesToBeReferred.Name = "ProcedureDoctorToBeReferredPatientAdmissionResourcesToBeReferred";
        this.ProcedureDoctorToBeReferredPatientAdmissionResourcesToBeReferred.Width = 300;

        this.ResourcePatientAdmissionResourcesToBeReferred = new TTVisual.TTListBoxColumn();
        this.ResourcePatientAdmissionResourcesToBeReferred.ListDefName = "PoliclinicAndEmergencyListDefinition";
        this.ResourcePatientAdmissionResourcesToBeReferred.DataMember = "Resource";
        this.ResourcePatientAdmissionResourcesToBeReferred.DisplayIndex = 0;
        this.ResourcePatientAdmissionResourcesToBeReferred.HeaderText = i18n("M11879", "Birimler");
        this.ResourcePatientAdmissionResourcesToBeReferred.Name = "ResourcePatientAdmissionResourcesToBeReferred";
        this.ResourcePatientAdmissionResourcesToBeReferred.Width = 300;

        this.labelHCModeOfPayment = new TTVisual.TTLabel();
        this.labelHCModeOfPayment.Text = i18n("M19869", "Ödeme Türü");
        this.labelHCModeOfPayment.Name = "labelHCModeOfPayment";
        this.labelHCModeOfPayment.TabIndex = 13;

        this.DonorUniqueRefNo = new TTVisual.TTTextBox();
        this.DonorUniqueRefNo.Name = "DonorUniqueRefNo";
        this.DonorUniqueRefNo.TabIndex = 184;
        this.DonorUniqueRefNo.InputFormat = InputFormat.AlphaOnly;
        this.DonorUniqueRefNo.CharacterCasing = CharacterCasing.Upper;
        this.DonorUniqueRefNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";

        this.HCModeOfPayment = new TTVisual.TTEnumComboBox();
        this.HCModeOfPayment.DataTypeName = "WhoPaysEnum";
        this.HCModeOfPayment.Name = "HCModeOfPayment";
        this.HCModeOfPayment.TabIndex = 12;

        this.labelReasonForExaminationHCRequestReason = new TTVisual.TTLabel();
        this.labelReasonForExaminationHCRequestReason.Text = i18n("M20869", "Rapor Türü");
        this.labelReasonForExaminationHCRequestReason.Name = "labelReasonForExaminationHCRequestReason";
        this.labelReasonForExaminationHCRequestReason.TabIndex = 10;

        this.ReasonForExaminationHCRequestReason = new TTVisual.TTObjectListBox();
        this.ReasonForExaminationHCRequestReason.ListDefName = "HealthCommitteeExaminationReasonListDefinition";
        this.ReasonForExaminationHCRequestReason.Name = "ReasonForExaminationHCRequestReason";
        this.ReasonForExaminationHCRequestReason.TabIndex = 9;
        this.ReasonForExaminationHCRequestReason.Enabled = false;
        this.ReasonForExaminationHCRequestReason.AutoCompleteDialogWidth = "40%";

        this.labelHCRequestReason = new TTVisual.TTLabel();
        this.labelHCRequestReason.Text = i18n("M16646", "İstek Sebebi");
        this.labelHCRequestReason.Name = "labelHCRequestReason";
        this.labelHCRequestReason.TabIndex = 8;

        this.HCRequestReason = new TTVisual.TTObjectListBox();
        this.HCRequestReason.ListDefName = "HCRequestReasonListDefinition";
        this.HCRequestReason.Name = "HCRequestReason";
        this.HCRequestReason.TabIndex = 7;
        this.HCRequestReason.AutoCompleteDialogWidth = "40%";
        this.HCRequestReason.ListFilterExpression = "ISACTIVE IS NULL";

        this.ttpanel1 = new TTVisual.TTPanel();
        this.ttpanel1.AutoSize = true;
        this.ttpanel1.Name = "ttpanel1";
        this.ttpanel1.TabIndex = 45;

        this.btnPatientAdmissionSave = new TTVisual.TTButton();
        this.btnPatientAdmissionSave.Text = i18n("M17386", "Kaydet");
        this.btnPatientAdmissionSave.Name = "btnPatientAdmissionSave";
        this.btnPatientAdmissionSave.TabIndex = 4;

        this.btnPatientAdmissionNewSave = new TTVisual.TTButton();
        this.btnPatientAdmissionNewSave.Text = i18n("M24564", "Yeni Kabul Oluştur");
        this.btnPatientAdmissionNewSave.Name = "btnPatientAdmissionNewSave";
        this.btnPatientAdmissionNewSave.TabIndex = 4;

        this.btnPatientAdmissionClear = new TTVisual.TTButton();
        this.btnPatientAdmissionClear.Text = i18n("M23181", "Temizle");
        this.btnPatientAdmissionClear.Name = "btnPatientAdmissionClear";
        this.btnPatientAdmissionClear.TabIndex = 4;

        this.btnSorgula = new TTVisual.TTButton();
        this.btnSorgula.Text = i18n("M22125", "Sorgula");
        this.btnSorgula.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.btnSorgula.Name = "btnSorgula";
        this.btnSorgula.TabIndex = 2;

        this.btnShowPatientDetailInfo = new TTVisual.TTButton();
        this.btnShowPatientDetailInfo.Text = i18n("M12675", "Detaylı Hasta Bilgilerini Göster");
        this.btnShowPatientDetailInfo.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.btnShowPatientDetailInfo.Name = "ShowPatientDetailInfo";
        this.btnShowPatientDetailInfo.TabIndex = 111;

        this.ttlabel68 = new TTVisual.TTLabel();
        this.ttlabel68.Text = i18n("M15160", "Hasta Bilgisi ");
        this.ttlabel68.Name = "ttlabel68";
        this.ttlabel68.TabIndex = 1;

        this.SearchPatient = new TTVisual.TTTextBox();
        this.SearchPatient.Name = "SearchPatient";
        this.SearchPatient.TabIndex = 0;

        this.Emergency112RefNoTextbox = new TTVisual.TTTextBox();
        this.Emergency112RefNoTextbox.Name = "txt112ProtocolNo";
        this.Emergency112RefNoTextbox.TabIndex = 51;
        this.Emergency112RefNoTextbox.ReadOnly = true;

        this.cbx112 = new TTVisual.TTCheckBox();
        this.cbx112.Value = false;
        this.cbx112.Text = i18n("M10132", "112 Sağlık Hizmetleri");
        this.cbx112.Name = "cbx112";
        this.cbx112.TabIndex = 50;

        this.DispatchEmergencyCons = new TTVisual.TTCheckBox();
        this.DispatchEmergencyCons.Value = false;
        this.DispatchEmergencyCons.Text = i18n("M10436", "Acil Konsültasyon");
        this.DispatchEmergencyCons.Name = "DispatchEmergencyCons";

        this.pPrivacyName = new TTVisual.TTTextBox();
        this.pPrivacyName.Multiline = false;
        this.pPrivacyName.Name = "PrivacyName";
        this.pPrivacyName.ReadOnly = true;
        this.pPrivacyName.CharacterCasing = CharacterCasing.Upper;

        this.pPrivacySurname = new TTVisual.TTTextBox();
        this.pPrivacySurname.Multiline = false;
        this.pPrivacySurname.Name = "PrivacySurname";
        this.pPrivacySurname.ReadOnly = true;
        this.pPrivacySurname.CharacterCasing = CharacterCasing.Upper;

        this.pPrivacyReason = new TTVisual.TTTextBox();
        this.pPrivacyReason.Multiline = false;
        this.pPrivacyReason.Name = "PrivacyReason";
        this.pPrivacyReason.ReadOnly = true;

        this.pPrivacy = new TTVisual.TTCheckBox();
        this.pPrivacy.Value = false;
        this.pPrivacy.Text = i18n("M14814", "Gizli Hasta");
        this.pPrivacy.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.pPrivacy.Name = "Privacy";

        this.pPrivacyEndDate = new TTVisual.TTDateTimePicker();
        this.pPrivacyEndDate.Format = DateTimePickerFormat.Short;
        this.pPrivacyEndDate.Name = "PrivacyEndDate";
        this.pPrivacyEndDate.TabIndex = 165;

        this.ApplicationReason = new TTVisual.TTEnumComboBox();
        this.ApplicationReason.DataTypeName = "ApplicationReasonEnum";
        this.ApplicationReason.Name = "ApplicationReason";
        this.ApplicationReason.TabIndex = 666;

        /*Engelli Raporu */

        this.DisabledReportApplicationExplanation = new TTVisual.TTTextBox();
        this.DisabledReportApplicationExplanation.IsNonNumeric = true;
        this.DisabledReportApplicationExplanation.Name = "DisabledReportApplicationExplanation";
        this.DisabledReportApplicationExplanation.CharacterCasing = CharacterCasing.Upper;
        this.DisabledReportApplicationExplanation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DisabledReportApplicationExplanation.TabIndex = 50;

        this.DisabledReportApplicationReason = new TTVisual.TTEnumComboBox();
        this.DisabledReportApplicationReason.DataTypeName = "EngelliRaporuMuracaatNedeniEnum";
        this.DisabledReportApplicationReason.Name = "DisabledReportApplicationReason";
        this.DisabledReportApplicationReason.TabIndex = 666;

        this.DisabledReportApplicationType = new TTVisual.TTEnumComboBox();
        this.DisabledReportApplicationType.DataTypeName = "EngelliRaporuMuracaatTipiEnum";
        this.DisabledReportApplicationType.Name = "DisabledReportApplicationType";
        this.DisabledReportApplicationType.TabIndex = 666;

        this.DisabledReportPersonalApplicationType = new TTVisual.TTEnumComboBox();
        this.DisabledReportPersonalApplicationType.DataTypeName = "EngelliRaporuKisiselMuracaatTuruEnum";
        this.DisabledReportPersonalApplicationType.Name = "DisabledReportPersonalApplicationType";
        this.DisabledReportPersonalApplicationType.TabIndex = 666;

        this.DisabledReportCorporateApplicationType = new TTVisual.TTEnumComboBox();
        this.DisabledReportCorporateApplicationType.DataTypeName = "EngelliRaporuKurumsalMuracaatTuruEnum";
        this.DisabledReportCorporateApplicationType.Name = "DisabledReportCorporateApplicationType";
        this.DisabledReportCorporateApplicationType.TabIndex = 666;

        this.DisabledReportTerrorAccidentInjuryAppReason = new TTVisual.TTEnumComboBox();
        this.DisabledReportTerrorAccidentInjuryAppReason.DataTypeName = "EngelliRaporuTerorKazaMuracaatNedeniEnum";
        this.DisabledReportTerrorAccidentInjuryAppReason.Name = "DisabledReportTerrorAccidentInjuryAppReason";
        this.DisabledReportTerrorAccidentInjuryAppReason.TabIndex = 666;

        this.DisabledReportTerrorAccidentInjuryAppType = new TTVisual.TTEnumComboBox();
        this.DisabledReportTerrorAccidentInjuryAppType.DataTypeName = "EngelliRaporuTerorKazaMuracaatTipiEnum";
        this.DisabledReportTerrorAccidentInjuryAppType.Name = "DisabledReportTerrorAccidentInjuryAppType";
        this.DisabledReportTerrorAccidentInjuryAppType.TabIndex = 666;

        /*Engelli Raporu */

        /*E-Durum Bildirir Kurul Entegrasyonu*/
        this.EStatusNotRepCommitteeApplicationType = new TTVisual.TTEnumComboBox();
        this.EStatusNotRepCommitteeApplicationType.DataTypeName = "EDurumBildirirKurulAppType";
        this.EStatusNotRepCommitteeApplicationType.Name = "EStatusNotRepCommitteeApplicationType";
        this.EStatusNotRepCommitteeApplicationType.TabIndex = 666;
        /*E-Durum Bildirir Kurul Entegrasyonu*/

        this.PatientClassGroup = new TTVisual.TTEnumComboBox();
        this.PatientClassGroup.DataTypeName = "PatientClassTypeEnum";
        this.PatientClassGroup.Name = "PatientClassGroup";
        this.PatientClassGroup.TabIndex = 666;

        this.SubEpisodesSubEpisodeColumns = [this.ProtocolNoSubEpisode];
        this.ResourcesToBeReferredColumns = [this.ResourcePatientAdmissionResourcesToBeReferred, this.ProcedureDoctorToBeReferredPatientAdmissionResourcesToBeReferred];

        this.controls = [this.MotherName, this.FatherName, this.BirthDate, this.CityOfBirth, this.Sex, this.Nationality, this.Name, this.Surname, this.ExDate, this.PayerList, this.UniqueRefNo, this.DonorUniqueRefNo,
        this.PassportNo, this.AdmissionType, this.SigortaliTuru, this.plakaNo, this.MedulaIstisnaiHalComboBox, this.Emergency112RefNoTextbox, this.labelExternalHospital, this.ExternalHospital, this.HomeAddress, this.MobilePhone, this.OtherBirthPlace,
        this.ImportantPatientInfo];


        this.PatientAdmissionUICompoents = new Map<string, any>();
        this.loadUIComponentsToMap();

        this.PatientInfoUIComponents = [this.MotherName, this.FatherName, this.BirthDate, this.CityOfBirth, this.Sex, this.Nationality, this.Name, this.Surname, this.UniqueRefNo,
        this.PassportNo, this.OtherBirthPlace, this.SKRSMaritalStatus, this.ImportantPatientInfo];

    }

    private updatePatientInfoUIComponents(patient: Patient): void {
        this.PatientInfoUIComponents.forEach(element => {
            if (this.patientAdmissionFormViewModel.ModifyPatientInfoRole == true) {
                element.Enabled = true;
                this.enableUnicrefNo = true;
            }
            else if (patient != null && patient.IsTrusted == true) {
                element.Enabled = false;
                this.enableUnicrefNo = false;
            }
            else {
                element.Enabled = (patient != null && (<ITTObject>this._PatientAdmission.Episode.Patient).IsNew);
                this.enableUnicrefNo = element.Enabled;
            }
        });
    }

    private loadUIComponentsToMap() {
        this.controls.forEach(element => {
            this.PatientAdmissionUICompoents.set(element.Name.toString(), element);
        });
    }

    private updateRequiredColors() {
        this.controls.forEach(element => {
            this.PatientAdmissionUICompoents.set(element.Name.toString(), element
            );
            element.BackColor = "white";
        });
    }

    private ForShortcutPanel = 0;
    btnCollapseForShortcutPanel() {

        if (this.ForShortcutPanel == 1) {
            this.ForShortcutPanel = 0;
        } else
            this.ForShortcutPanel = 1;

    }


    private patientInfoCollapseAttr = 0;
    btnCollapse() {

        if (this.patientInfoCollapseAttr == 1) {
            this.patientInfoCollapseAttr = 0;
        } else
            this.patientInfoCollapseAttr = 1;

    }



    public onttlistdefcombobox1Changed(event): void {

        if (this.patientAdmissionFormViewModel != null && this.patientAdmissionFormViewModel._PatientAdmission.MedulaIstisnaiHal != event) {
            this.patientAdmissionFormViewModel._PatientAdmission.MedulaIstisnaiHal = event;
            if (event != null)
                this.MedulaIstisnaiHalComboBox.BackColor = "white";
        }

    }

    public onSigortaliTuruChanged(event): void {

        if (this._PatientAdmission.MedulaSigortaliTuru != event) {
            this._PatientAdmission.MedulaSigortaliTuru = event;
        }

    }
    public onplakaNoChanged(event): void {

        if (this.patientAdmissionFormViewModel != null && this.patientAdmissionFormViewModel.SubEpisodeProtocol != null
            && this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaPlakaNo != event) {
            this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaPlakaNo = event;
        }

    }

    public onprovizyonTarihiChanged(event): void {

        if (this.patientAdmissionFormViewModel != null && this.patientAdmissionFormViewModel.SubEpisodeProtocol != null
            && this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaProvizyonTarihi != event) {
            this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaProvizyonTarihi = event;
        }

    }

    public onprovizyonTipiChanged(event): void {

        if (this.patientAdmissionFormViewModel != null && this.patientAdmissionFormViewModel.SubEpisodeProtocol != null
            && this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaProvizyonTipi != event) {
            this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaProvizyonTipi = event;
        }

    }

    private patientAdmissionGeneralError: number = 0;


    public admissionNoComponentDivProperties(): string {
        if (this.patientInfoCollapseAttr == 1) {
            if (this.patientAdmissionGeneralError == 1)
                return "col-md-3 col-sm-3";
            return "col-md-4 col-sm-4";
        }
        else if (this.patientAdmissionGeneralError == 1)
            return "col-md-3 col-sm-3";
        return "col-md-5 col-sm-5";

    }


    private detailSearchIconClassCollapse = 0;

    public detailSearchCollapse_Click(): void {
        this.showPopupDetailsSearch = (!this.showPopupDetailsSearch);
        if (this.detailSearchIconClassCollapse == 0)
            this.detailSearchIconClassCollapse = 1;
        else
            this.detailSearchIconClassCollapse = 0;
    }

    public mergePatient_Click(): void {
        this.showPopupMergePatient = (!this.showPopupMergePatient);

    }

    public showMedulaerrorsPopup = false;
    public medulaTakipNoError_Click(): void {
        if (this.patientAdmissionFormViewModel.SubEpisodeProtocol != null &&
            this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo == null && this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaSonucMesaji != null) {
            this.showMedulaerrorsPopup = true;
            //ServiceLocator.MessageService.showInfo(this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaSonucMesaji);
        }
    }

    public onmedulaTakipNoChanged(event): void {

        if (this.patientAdmissionFormViewModel != null && this.patientAdmissionFormViewModel.SubEpisodeProtocol != null
            && this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo != event) {
            this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo = event;
        }

    }

    public patientAdmissionGeneralErrorBtn_Click(): void {
        ServiceLocator.MessageService.showInfo(i18n("M11754", "Belirlenen hata ile kullanıcıyı uyardım."));
    }

    showPopupDetailsSearch: boolean = false;
    showPopupMergePatient: boolean = false;

    IncludedPhotoList: Array<string> = ["10000000000"];

    private isIncludeValue(searchingValue: Number) {

        let compareValue: string = searchingValue + "";
        for (let value of this.IncludedPhotoList) {
            if (value == compareValue)
                return true;
        }
        return false;
    }

    private btnEvdeSaglikHizmetleri_Clicked(): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "EvdeSaglikBasvuruKaydetForm";
            componentInfo.ModuleName = "EvdeSaglikHizmetleriModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Evde_Saglik_Hizmetleri_Modulu/EvdeSaglikHizmetleriModule";
            componentInfo.InputParam = new DynamicComponentInputParam(true, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M13999", "Evde Sağlık Hizmetleri Başvuru Kaydetme Formu");
            modalInfo.Width = 800;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private btnEvdeSaglikSorgulaSil_Clicked(): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "EvdeSaglikBasvuruSorgulaSilForm";
            componentInfo.ModuleName = "EvdeSaglikHizmetleriModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Evde_Saglik_Hizmetleri_Modulu/EvdeSaglikHizmetleriModule";
            componentInfo.InputParam = new DynamicComponentInputParam("", null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M14002", "Evde Sağlık Hizmetleri Sorgula/Sil");
            modalInfo.Width = 800;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private btnEvdeSaglikHizmetEmirlerim_Clicked(): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "EvdeSaglikHizmetEmirleriForm";
            componentInfo.ModuleName = "EvdeSaglikHizmetleriModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Evde_Saglik_Hizmetleri_Modulu/EvdeSaglikHizmetleriModule";
            componentInfo.InputParam = new DynamicComponentInputParam("", null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M13994", "Evde Sağlık Hizmet Emirleri");
            modalInfo.Width = 400;
            modalInfo.Height = 200;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    ///////////////////////////////////////////ÇOKLU RANDEVU SEÇİMİ/////////////////////////////////////
    public LoadAppointmentlistView(appointmentListInfo: Array<any>) {

        try {
            let itemList = new Array<any>();
            for (let appointment of appointmentListInfo) {

                let p = {
                    AppointmentID: appointment.ObjectID,
                    SubItems:
                        [
                            { Text: this.datePipe.transform(appointment.AppDate, 'dd/MM/yyyy') + " " + appointment.AppTime },
                            { Text: appointment.Masterresourcename },
                            { Text: appointment.DoctorName },
                            { Text: appointment.Notes }
                        ]
                };

                itemList.push(p);
            }
            this.AppointmentlistView.Items = itemList;
        } catch (e) {
            ServiceLocator.MessageService.showError((<Error>e).message);

        }
    }
    public AppointmentlistViewRowPrepared(row) {
    }
    public AppointmentID: any;

    public async AppointmentlistView_Click(val: any): Promise<void> {
        if (val != null) {
            this.showAppointmentListPopup = false;
            let data = val.AppointmentID.toString();
            this.AppointmentID = new Guid(data);

            let fullApiUrl = '/api/PatientAdmissionService/PatientAdmissionFormAppointmentLoad/?id=' + Guid.Empty + '&uniqueRefNo=' + this.globalUniqueRefNo + '&appointmentID=' + this.AppointmentID;
            let res = await this.httpService.get<PatientAdmissionFormViewModel>(fullApiUrl, PatientAdmissionFormViewModel);
            this._ViewModel = res;
            await this.LoadPatientAdmissionModel(this._ViewModel);
        }
    }

    ////////////////////////////////////////////YARDIMCI ARAÇLAR////////////////////////////////////////
    public showMatchBabyMotherPopup = false;
    public showMedulaReportsPopup = false;
    public showDeletePatientAdmissionPopup = false;

    /*MATCH BABY & MOTHER*/
    onClickShowMatchBabyMother(): void {
        this.showMatchBabyMotherPopup = true;
    }

    onClickMatchBabyMother() {

        if (this._PatientAdmission.IsNewBorn === false)
            ServiceLocator.MessageService.showError(i18n("M30205", "Yeni doğan olmayan hastalarda 'Anne seçimi' yapılamaz."));

        if (this._PatientAdmission.Episode.Patient.BirthOrder == null) {
            ServiceLocator.MessageService.showError(i18n("M13124", "Doğum sırası' bilgisi boş bırakılamaz."));
        }
        else if (this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.Mother == null) {
            ServiceLocator.MessageService.showError(i18n("M11041", "'Anne' bilgisi boş bırakılamaz."));
        }
        else
            this.showMatchBabyMotherPopup = false;

        this.searchFormInstance.Clear();
    }

    patientMotherChanged(motherPatient: any) {
        if (motherPatient == null)
            ServiceLocator.MessageService.showError(i18n("M11041", "'Anne' bilgisi boş bırakılamaz."));

        if (this._PatientAdmission.Episode.Patient != null) {
            let that = this;
            that.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.Mother = motherPatient;
            this.babyMotherName = motherPatient.Name + ' ' + motherPatient.Surname;
        }
    }

    public async verifiedKPSInfo() {

        if (this.patientAdmissionFormViewModel.VerifiedKpsWithoutApprove == false)
            this.openMernisInfoCompare();
        else if (this.patientAdmissionFormViewModel.CheckMernisRole == true) {
            if (this.patientAdmissionFormViewModel != null && this.patientAdmissionFormViewModel.Patients[0] != undefined && this.patientAdmissionFormViewModel.Patients[0].UniqueRefNo != null) {
                if (this.patientAdmissionFormViewModel.Patients[0].IsNew) {
                    ServiceLocator.MessageService.showInfo(i18n("M12085", "Kaydedilmemiş arşiv kayıtları için bu işlemi yapamazsınız."));
                }
                else if (this.patientAdmissionFormViewModel._PatientAdmission != null && this.patientAdmissionFormViewModel._PatientAdmission.IsNew) {
                    this.patientAdmissionFormViewModel.fromVerifiedKPSBtn = true;

                    try {
                        let apiUrl = '/api/PatientAdmissionService/PatientAdmissionFormLoadFromKPSButton';
                        this.loadingVisible = true;
                        this.panelMessage = "Mernis Bilgileri Sorgulanıyor.";

                        let result = await this.httpService.post(apiUrl, this.patientAdmissionFormViewModel.Patients[0], Patient);

                        if (result != undefined) {
                            await this.LoadPatientAdmission(result, true);
                            ServiceLocator.MessageService.showSuccess("Mernisten bilgiler başarı ile çekildi.");
                        }

                        this.loadingVisible = false;
                        this.panelMessage = "Kaydediliyor...";
                    }
                    catch (err) {
                        this.loadingVisible = false;
                        this.panelMessage = "Kaydediliyor...";
                        console.error(err);
                        ServiceLocator.MessageService.showError(err);
                    }


                }
                else
                    ServiceLocator.MessageService.showInfo(i18n("M12085", "Mernis Doğrulama için lütfen sadece arşiv bilgisini yükleyiniz."));
            }

        }
        else {
            ServiceLocator.MessageService.showInfo(i18n("M12085", "Bu işlemi yapmak için yetkiniz bulunmamaktadır."));
        }
    }

    /*READ  MEDULA REPORTS*/
    onMedulaReports(): void {
        this.showMedulaReportsPopup = true;
    }

    openEK8Report(): void {

        if (this._PatientAdmission != null) {
            let that = this;

            const objectIdParam = new GuidParam(that._PatientAdmission.ObjectID);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('EK8Report', reportParameters);
        }
    }

    masrafIadeRaporu(): Promise<ModalActionResult> {


        let data: DynamicReportParameters = {
            Code: 'MasrafIadeFormu',
            ReportParams: { PAOBJECTID: this._PatientAdmission.ObjectID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Masraf İade Formu"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    public printMedulaTransferredPayerReport() {

        let data: DynamicReportParameters = {
            Code: 'MedulaTransferredPayerReport',
            ReportParams: { PAOBJECTID: this._PatientAdmission.ObjectID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Kurum Bilgisi Güncelleme Raporu"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public onMHRSAppointmentsReport(event) {

        let reportParameters: any = {};
        this.reportService.showReportModal('MHRSAppointmentsReport', reportParameters);
    }

    public onMHRSAppointmentTimeIsPastReport(event) {
        let reportParameters: any = {};
        this.reportService.showReportModal('MHRSAppointmentTimeIsPastReport', reportParameters);
    }

    ReportStartDate: Date;
    ReportEndDate: Date;

    public PatientListReport(event) {
        const startDateParam = new DateParam(this.ReportStartDate);
        const endDateParam = new DateParam(this.ReportEndDate);
        let reportParameters: any = { 'STARTDATE': startDateParam, 'ENDDATE': endDateParam };
        this.reportService.showReport('GetPatientListReport', reportParameters);
    }

    showReportsVisible: Boolean = false;

    openPatientListReportPopup() {
        this.showReportsVisible = true;
    }


    /*DELETE PATIENTADMISSION*/
    async onClickShowDeletePatientAdmission() {
        if (this._PatientAdmission.ObjectID == null)
            TTVisual.InfoBox.Alert(i18n("M21880", "Silmek istediğiniz kabulü yükleyiniz."));
        else if (this._PatientAdmission != null) {
            try {
                this.loadingVisible = true;
                this.panelMessage = "Kabule Ait Bilgiler Siliniyor.";
                await this.httpService.post('/api/PatientAdmissionService/DeletePatientAdmission', this.patientAdmissionFormViewModel._PatientAdmission, PatientAdmission);
                ServiceLocator.MessageService.showInfo(i18n("M17014", "Kabul başarı ile silindi."));

                //await this.btnPatientAdmissionClear_Click();
                await this.btnPatientAdmissionNewSave_Click();
                this.loadingVisible = false;
                this.panelMessage = "Kaydediliyor...";
            }
            catch (err) {
                ServiceLocator.MessageService.showError(err);
                this.loadingVisible = false;
                this.panelMessage = "Kaydediliyor...";
            }
        }
    }
    onClickDeletePatientAdmission() {
        try {
            if (this._PatientAdmission != null) {
                let result = this.httpService.post('/api/PatientAdmissionService/DeletePatientAdmission', this._PatientAdmission, PatientAdmission);
                ServiceLocator.MessageService.showInfo(i18n("M17014", "Kabul başarı ile silindi."));
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            //   TTVisual.InfoBox.Alert("Hata");
        }
    }
    async deletePatientAdmissionChanged(deletedPatientAdmission: any) {
        let that = this;
        that.patientAdmissionFormViewModel._PatientAdmission = deletedPatientAdmission;
    }

    private async updatePatientAdmissionAfterTakipOperations() {

        await this.loadPAByID(new Guid(this.patientAdmissionFormViewModel._PatientAdmission.ObjectID));
        await this.LoadPatientAdmissionHistory(this.patientAdmissionFormViewModel.HistoryPatientAdmission, false);
        await this.MedulaErrorValidator();
    }


    async takipSil() {
        try {
            if (this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo != null) {
                let takipSilUrl = '/api/InvoiceTopMenuApi/takipSil?sepObjectID=' + this.patientAdmissionFormViewModel.SubEpisodeProtocol.ObjectID;
                this.httpService.get<MedulaResult>(takipSilUrl, MedulaResult)
                    .then(result => {
                        ServiceLocator.MessageService.showInfo(result.SonucKodu + ' - ' + result.SonucMesaji);
                        this.updatePatientAdmissionAfterTakipOperations();

                    })
                    .catch(error => {
                        ServiceLocator.MessageService.showError(error);
                    });
            }

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err.message);
            //   TTVisual.InfoBox.Alert("Hata");
        }
    }
    async fazlaTakipOku() {
        this.MedulaExtraProvisionInfo.sonTarih = new Date();
        this.MedulaExtraProvisionInfo.ilkTarih = (new Date()).AddDays(-30);
        if (this._PatientAdmission.Episode.Patient.UniqueRefNo != null)
            this.MedulaExtraProvisionInfo.tc = this._PatientAdmission.Episode.Patient.UniqueRefNo.toString();
        else {
            ServiceLocator.MessageService.showError(i18n("M20573", "Provizyon alınabilir TC alanı boş geçilemez!"));
        }

        this.ReadExtraProvision();
    }

    ReadExtraProvision(): void {
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/FazlaTakipOku?tc=' + this.MedulaExtraProvisionInfo.tc + '&ilkTarih=' + this.datePipe.transform(this.MedulaExtraProvisionInfo.ilkTarih, 'dd.MM.yyyy') + '&sonTarih=' + this.datePipe.transform(this.MedulaExtraProvisionInfo.sonTarih, 'dd.MM.yyyy');
        this.httpService.get<Array<FazlaTakipDTO>>(apiUrlForgetRule)
            .then(result => {
                this.MedulaExtraProvisionInfo.takipListesi = result;
                this.showMedulaExtraProvisionPopup = true;

            })
            .catch(error => {
                this.showMedulaExtraProvisionPopup = true;
                ServiceLocator.MessageService.showError(error);
            });

    }

 

    deleteMedulaExtraProvision(row: any): void {
        if (row.data.ID == "0" || (row.data.ID != "0" && row.data.durum == i18n("M16526", "İptal"))) {
            let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/FazlaTakipSil';

            let model: any = {};

            model.takipNo = row.data.takipNo;

            this.httpService.post<string>(apiUrlForgetRule, model)
                .then(result => {
                    this.ReadExtraProvision();
                    ServiceLocator.MessageService.showInfo(result);
                })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                });
        }
        else {
            ServiceLocator.MessageService.showError("HBYS ile ilişkilendirilmiş takipler fatura kartı üzerinden silinebilir.");
            return;
        }
    }
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
    async takipOku() {
        let that = this;
        if (this._PatientAdmission.ObjectID == null)
            ServiceLocator.MessageService.showError(i18n("M22636", "Takip almak istediğiniz kabulü yükleyiniz."));

        if (this.patientAdmissionFormViewModel.SubEpisodeProtocol.ObjectID == null)
            ServiceLocator.MessageService.showError(i18n("M30206", "Okunacak takip bilgisi bulunamamıştır."));

        let apiUrlTakipOku: string = '/api/InvoiceTopMenuApi/takipOku';
        let sepIDs: Array<any> = [];
        sepIDs.push(this.patientAdmissionFormViewModel.SubEpisodeProtocol.ObjectID);
        let tom: any = {};
        tom.sepObjectIDs = sepIDs;


        this.httpService.post<Array<TakipDVO>>(apiUrlTakipOku, tom)
            .then(result => {
                this.updatePatientAdmissionAfterTakipOperations();
                this.showProvisionPopup = true;
                this.readProvisionResultArray = this.changeCodeToNameOnProvisionResult(result);


            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
            });

    }
    changeCodeToNameOnProvisionResult(oldResult: Array<TakipDVO>): Array<TakipDVO> {

        for (let i = 0; i < oldResult.length; i++) {
            oldResult[i].tedaviTuru = this.findFromArray(this.tedaviTuruArray, oldResult[i].tedaviTuru);
            oldResult[i].tedaviTipi = this.findFromArray(this.tedaviTipiArray, oldResult[i].tedaviTipi);
            oldResult[i].takipTipi = this.findFromArray(this.takipTipiArray, oldResult[i].takipTipi);
            oldResult[i].provizyonTipi = this.findFromArray(this.provizyonTipiArray, oldResult[i].provizyonTipi);
            oldResult[i].bransKodu = this.findFromArray(this.bransArray, oldResult[i].bransKodu);
            oldResult[i].istisnaiHal = this.findFromArray(this.istisnaiHalArray, oldResult[i].istisnaiHal);

            oldResult[i].hastaBilgileri.devredilenKurum = this.findFromArray(this.devredilenKurumArray, oldResult[i].hastaBilgileri.devredilenKurum);
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

    async takipAl() {
        try {
            let that = this;
            if (this._PatientAdmission.ObjectID == null)
                ServiceLocator.MessageService.showError(i18n("M22636", "Takip almak istediğiniz kabulü yükleyiniz."));

            if (this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo != null)
                ServiceLocator.MessageService.showError(i18n("M15511", "Hastaya alınmış takip numarası mevcuttur,önce takip siliniz."));


            if (this._PatientAdmission.Episode.Patient.YUPASSNO != null) {
                try {
                    let apiUrl = '/api/PatientAdmissionService/GetYupasBelgeList/?ResourceID=' + this._PatientAdmission.Episode.Patient.YUPASSNO.toString();

                    let result = await this.httpService.get<Array<YurtDisiYardimHakki>>(apiUrl);

                    if (result != null) {
                        if (result.length == 1 && result[0].YardimHakID != null)
                            this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaYupassNo = result[0].YardimHakID;
                        else {
                            this.yupasBelgeListesi = result;
                            this.showYupasBelgeListesi = true;
                            let a = await this.subscribeYupasPopupButton();
                            this.showYupasBelgeListesi = false;
                            if (a == 1) {
                                if (this._selectedYupasBelge == null)
                                    throw new TTException("Belge Seçmeden Devam Edemezsiniz.");

                                this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaYupassNo = this._selectedYupasBelge;
                                this._selectedYupasBelge = null;
                            }
                            else
                                throw new TTException("İşlemden vazgeçildi.");

                        }
                    }
                } catch (e) {
                    ServiceLocator.MessageService.showError("Yupas Belgeleri Listelenirken bir hata ile karşılaşıldı " + (<Error>e).message);
                }
            }

            let takipAlUrl = '';
            if (this.bagliTakipNo === '')
                takipAlUrl = '/api/InvoiceTopMenuApi/takipAl?sepObjectID=' + this.patientAdmissionFormViewModel.SubEpisodeProtocol.ObjectID;
            else
                takipAlUrl = '/api/InvoiceTopMenuApi/takipAl?sepObjectID=' + this.patientAdmissionFormViewModel.SubEpisodeProtocol.ObjectID + '&bagliTakipNo=' + this.bagliTakipNo;

            //var takipAlUrl = '/api/InvoiceTopMenuApi/takipAl?sepObjectID=' + this.patientAdmissionFormViewModel.SubEpisodeProtocol.ObjectID;
            this.httpService.get<MedulaResult>(takipAlUrl, MedulaResult)
                .then(result => {
                    ServiceLocator.MessageService.showInfo(result.SonucKodu + ' - ' + result.SonucMesaji);
                    this.updatePatientAdmissionAfterTakipOperations();
                })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                });

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err.message);
            //   TTVisual.InfoBox.Alert("Hata");
        }
    }

    async bagliTakipAl() {

        if (this._PatientAdmission.ObjectID == null)
            ServiceLocator.MessageService.showError(i18n("M30207", "Bağlı takip almak istediğiniz kabulü yükleyiniz."));

        this.bagliTakipNo = '';
        this.bagliTakipAlinacakSEPid = this.patientAdmissionFormViewModel.SubEpisodeProtocol.ObjectID;

        if (this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo != null) {
            ServiceLocator.MessageService.showError(i18n("M15511", "Hastaya alınmış takip numarası mevcuttur,önce takip siliniz."));
            this.showBagliTakipAlPopup = false;
        }
        else
            this.showBagliTakipAlPopup = true;


    }

    async onClickBagliTakipAl() {
        if (this.bagliTakipNo !== '')
            await this.takipAl();

        this.showBagliTakipAlPopup = false;
    }

    onValueChangedBagliTakipPopup(e: any): void {
        this.bagliTakipNo = e.value;
    }


    public async RadResult() {
        let param: LISPARAM = new LISPARAM();
        param.UniqueRefNo = this._PatientAdmission.Episode.Patient.UniqueRefNo.toString();
        let ep: any = this.patientAdmissionFormViewModel
        param.SubEpisodes = ep.SubEpisode;
        let apiUrl: string = 'api/PatientAdmissionService/GetReportForPacs'
        let result = await this.httpService.post<string>(apiUrl, param);
        if (result == null) {
            InfoBox.Alert(i18n("M12080", "Bu Vakaya Ait Radyoloji Sonucu Bulunamadı!"));
            return;
        }
        for (var i = 0; i < result.length; i++) {
            const objectIdParam = new GuidParam(result[i].toString());
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('RadiologyTestResultReport', reportParameters);
        }

    }



    public async LabResult() {
        let param: LISPARAM = new LISPARAM();
        param.UniqueRefNo = this._PatientAdmission.Episode.Patient.UniqueRefNo.toString();
        let ep: any = this.patientAdmissionFormViewModel
        param.SubEpisodes = ep.SubEpisode;
        let apiUrl: string = 'api/PatientAdmissionService/GetReportURLFromLIS'
        let result = await this.httpService.post<string>(apiUrl, param);
        this.openInNewTab(result);
    }

    openInNewTab(url) {
        if (url == null) {
            InfoBox.Alert(i18n("M12080", "Bu Vakaya Ait lab Sonucu Bulunamadı!"));
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }

    public printBarcodeFromHelpMenu()
    {
        
        if (this._PatientAdmission != null && this._PatientAdmission.Department != null && this._PatientAdmission.Department.IsEmergencyDepartment == true)
            this.getEmergencyExamBarcodeList();
        else
        {
            this.canPrintHCBarkod = true;
            this.printBarcode();
        }
       
    }

    public getEmergencyExamBarcodeList()
    {
        let that = this;
        this.httpService.get<Array<string>>("api/PatientAdmissionService/GetEmergencyExamBarcodeList?PatientAdmission="+ that._PatientAdmission.ObjectID)
            .then(result => {
                this.barcodeList = result as Array<string>;

                if(this.barcodeList != null && this.barcodeList.length > 1)
                    this.ShowEmergencyBarcode = true;
                else
                    this.printBarcode();

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public onEmergencyBarcodeHiding()
    {
        this.barcodeList == null;
        this.ShowEmergencyBarcode = false;
        this._selectedBarcodeInfo = null;        
    }

    public printEmergencyBarcore()
    {
        this.printBarcode(this._selectedBarcodeInfo);

    }

    public async printBarcode(emergencyBarcodeDate? : string) {
        if (this._PatientAdmission.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu) {
            if(this.canPrintHCBarkod) // sadece ilk kaydette otomatik bassın
            {
                this.printHCBarcode(true, "", "");
                this.canPrintHCBarkod = false;
            }
        }
        else if (this._PatientAdmission.Episode.Patient.Death != true && this._PatientAdmission.AdmissionStatus != AdmissionStatusEnum.DisaridanGelenKonsultasyon && this._PatientAdmission.AdmissionStatus != AdmissionStatusEnum.HizmetProtokol) {
            let info: PatientBarcodeInfo = new PatientBarcodeInfo();
            let stringdate = this._PatientAdmission.Episode.Patient.BirthDate;

            if (stringdate == undefined)
                info.BirthDate = "";
            else if (this._PatientAdmission.Episode.Patient.Privacy)
            {
                info.BirthDate = "xx/xx/xxxx";
            }
            else if (this._PatientAdmission.Episode.Patient.BirthDate instanceof Date) {
                info.BirthDate = this._PatientAdmission.Episode.Patient.BirthDate.ToShortDateStringddmmyyyy();
            }
            else {
                info.Age = ""; //this._PatientAdmission.Episode.Patient.Age.toString();
                let date = stringdate.toString().split('T');
                info.BirthDate = this.datePipe.transform(new Date(date[0]), 'dd.MM.yyyy');
            }

            info.DNo = this._PatientAdmission.DocumentNumber;
            if (this.patientAdmissionFormViewModel.tempProcedureDoctor != undefined)
                info.DoctorName = this.patientAdmissionFormViewModel.tempProcedureDoctor.Name;
            if (this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.UnIdentified != true)
                info.Gender = this._PatientAdmission.Episode.Patient.Sex.ADI;

            if (this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo != undefined) {
                info.GSSNo = this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo;
                info.TAKIPNO = this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo;
            }
            //TODO
            info.IslemNo = this.patientAdmissionFormViewModel.SEProtocolNo;//(this._protocolNo == null || this._protocolNo == "") ? this._PatientAdmission.Episode;
            info.HospitalName = this.patientAdmissionFormViewModel.HospitalName;
            info.DNo = this._PatientAdmission.Episode.Patient.ID.toString();
            info.Kurum = this.patientAdmissionFormViewModel.tempPayer.Name;
            if (this._PatientAdmission.Episode.Patient.UniqueRefNo != null)
                info.PatientIdentifier = this._PatientAdmission.Episode.Patient.UniqueRefNo.toString();
            else if (this._PatientAdmission.Episode.Patient.PassportNo != null)
                info.PatientIdentifier = this._PatientAdmission.Episode.Patient.PassportNo.toString();

            info.PatientName = this._PatientAdmission.Episode.Patient.Name + " " + this._PatientAdmission.Episode.Patient.Surname;

            info.BirthPlace = this._PatientAdmission.Episode.Patient.BirthPlace != null ? this._PatientAdmission.Episode.Patient.BirthPlace :
                this._PatientAdmission.Episode.Patient.OtherBirthPlace != null ? this._PatientAdmission.Episode.Patient.OtherBirthPlace : "-";

            if (this.patientAdmissionFormViewModel.tempPoliclinic !== null && this.patientAdmissionFormViewModel.tempPoliclinic != undefined)
                info.PoliclinicName = this.patientAdmissionFormViewModel.tempPoliclinic.Name;

            //PURSAKLAR randevulu hastada saat yazsın diğerlerinde tarih yazsın
            if (this._PatientAdmission.AdmissionAppointment == null) {
                info.SiraNo = this._PatientAdmission.AdmissionQueueNumber != undefined ? this._PatientAdmission.AdmissionQueueNumber.toString() : "";
            }
            else
                info.StartDate = this.datePipe.transform(this.patientAdmissionFormViewModel._PatientAdmission.ActionDate, 'HH:mm');
            // if (this.patientAdmissionFormViewModel.AppointmentList != null && this.patientAdmissionFormViewModel.AppointmentList.length > 0)

            // else
            //     info.StartDate = "";
            info.KabulTarihi = emergencyBarcodeDate == null ? this.datePipe.transform(this._PatientAdmission.CreationDate, 'dd.MM.yyyy HH:mm') : emergencyBarcodeDate;
            info.StartDateWithDateandHour = this.datePipe.transform(this._PatientAdmission.CreationDate, 'dd.MM.yyyy HH:mm');
            info.SureAralik = "30";

            let apiUrl = '/api/PatientAdmissionService/ExpectedExaminationTime/?paID=' + this.patientAdmissionFormViewModel._PatientAdmission.ObjectID;

            await this.httpService.get<string>(apiUrl).then(result => {
                info.RandevuSaati = result;
            }).catch(error => {
                ServiceLocator.MessageService.showError(error);
            });
            //info.RandevuSaati = i18n("M10293", "30 dk");
            if (this.patientAdmissionFormViewModel.NewPatientBarcode)
                this.barcodePrintService.printAllBarcode(info, "generateGazilerPatientBarcode", "printPatientBarcode"); //gaziler kabul barkodu
            else
                this.barcodePrintService.printAllBarcode(info, "generatePatientBarcode", "printPatientBarcode");

           
        }
    }


    public async printHCBarcode(printAllUnit: boolean, policlinic: string, doctor: string) {
        let _tempList: Array<PatientAdmissionResourcesToBeReferred> = new Array<PatientAdmissionResourcesToBeReferred>();

        if (printAllUnit)
            _tempList = this.patientAdmissionFormViewModel.ResourcesToBeReferredList.slice(0);
        else {
            _tempList.push(this.patientAdmissionFormViewModel.ResourcesToBeReferredList.find(o => o.ProcedureDoctorToBeReferred.ObjectID.toString() === doctor
                && o.Resource.ObjectID.toString() === policlinic));
        }

        for (var i = 0; i < _tempList.length; i++) {
            let info: PatientBarcodeInfo = new PatientBarcodeInfo();
            let stringdate = this._PatientAdmission.Episode.Patient.BirthDate;

            if (stringdate == undefined)
                info.BirthDate = "";
            else if (this._PatientAdmission.Episode.Patient.BirthDate instanceof Date) {
                info.BirthDate = this._PatientAdmission.Episode.Patient.BirthDate.ToShortDateStringddmmyyyy();
            }
            else {
                info.Age = ""; //this._PatientAdmission.Episode.Patient.Age.toString();
                let date = stringdate.toString().split('T');
                info.BirthDate = this.datePipe.transform(new Date(date[0]), 'dd.MM.yyyy');
            }

            info.DNo = this._PatientAdmission.DocumentNumber;

            if (this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.UnIdentified != true)
                info.Gender = this._PatientAdmission.Episode.Patient.Sex.ADI;

            if (this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo != undefined) {
                info.GSSNo = this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo;
                info.TAKIPNO = this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo;
            }
            //TODO 
            info.IslemNo = this.patientAdmissionFormViewModel.SEProtocolNo;
            info.HospitalName = this.patientAdmissionFormViewModel.HospitalName;
            info.DNo = this._PatientAdmission.Episode.Patient.ID.toString();
            info.Kurum = this.patientAdmissionFormViewModel.tempPayer.Name;
            if (this._PatientAdmission.Episode.Patient.UniqueRefNo != null)
                info.PatientIdentifier = this._PatientAdmission.Episode.Patient.UniqueRefNo.toString();
            else if (this._PatientAdmission.Episode.Patient.PassportNo != null)
                info.PatientIdentifier = this._PatientAdmission.Episode.Patient.PassportNo.toString();

            info.PatientName = this._PatientAdmission.Episode.Patient.Name + " " + this._PatientAdmission.Episode.Patient.Surname;

            info.BirthPlace = this._PatientAdmission.Episode.Patient.BirthPlace != null ? this._PatientAdmission.Episode.Patient.BirthPlace :
                this._PatientAdmission.Episode.Patient.OtherBirthPlace != null ? this._PatientAdmission.Episode.Patient.OtherBirthPlace : "-";

            info.PoliclinicName = _tempList[i].Resource.Name;
            info.DoctorName = _tempList[i].ProcedureDoctorToBeReferred.Name;

            let apiUrl = '/api/PatientAdmissionService/ExpectedExaminationTime/?paID=' + this.patientAdmissionFormViewModel._PatientAdmission.ObjectID;

            await this.httpService.get<string>(apiUrl).then(result => {
                info.RandevuSaati = result;
            }).catch(error => {
                ServiceLocator.MessageService.showError(error);
            });

            if (_tempList[i].AdmissionQueueNumber != null || _tempList[i].AdmissionQueueNumber != undefined)
                info.SiraNo = _tempList[i].AdmissionQueueNumber;
            else if (this._PatientAdmission.AdmissionAppointment == null)
                info.SiraNo = this._PatientAdmission.AdmissionQueueNumber != undefined ? this._PatientAdmission.AdmissionQueueNumber.toString() : "";
            else
                info.StartDate = this.datePipe.transform(this.patientAdmissionFormViewModel._PatientAdmission.ActionDate, 'HH:mm');
            // else
            //     info.StartDate = "";
            info.KabulTarihi = this.datePipe.transform(this._PatientAdmission.CreationDate, 'dd.MM.yyyy HH:mm');
            info.StartDateWithDateandHour = this.datePipe.transform(this._PatientAdmission.CreationDate, 'dd.MM.yyyy HH:mm');
            info.SureAralik = "30";
            //info.RandevuSaati = i18n("M10293", "30 dk");
            this.barcodePrintService.printAllBarcode(info, "generatePatientBarcode", "printPatientBarcode");

        }
    }

    public async continuePrintResultBarcode() {
        let fullApiUrl = '/api/PatientAdmissionService/PrintResultBarcode/?id=' + this.patientAdmissionFormViewModel._PatientAdmission.ObjectID;
        //let orderNo = await this.httpService.get<any>(fullApiUrl);

        let that = this;

        that.httpService.get<string>(fullApiUrl).then(response => {

            if (response.Value) {
                if (that._PatientAdmission.Episode.Patient.Death != true) {
                    let info: PatientBarcodeInfo = new PatientBarcodeInfo();
                    info.Age = ""; //this._PatientAdmission.Episode.Patient.Age.toString();
                    info.BirthDate = that.datePipe.transform(that._PatientAdmission.Episode.Patient.BirthDate, 'dd.MM.yyyy');
                    info.DNo = that._PatientAdmission.DocumentNumber;
                    if (that.patientAdmissionFormViewModel.tempProcedureDoctor !== null && that.patientAdmissionFormViewModel.tempProcedureDoctor != undefined)
                        info.DoctorName = this.patientAdmissionFormViewModel.tempProcedureDoctor.Name;
                    if (that.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.UnIdentified != true)
                        info.Gender = that._PatientAdmission.Episode.Patient.Sex.ADI;

                    if (that.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo != undefined) {
                        info.GSSNo = that.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo;
                        info.TAKIPNO = that.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaTakipNo;
                    }
                    //TODO
                    info.IslemNo = that.patientAdmissionFormViewModel.SEProtocolNo;
                    info.HospitalName = that.patientAdmissionFormViewModel.HospitalName;
                    info.DNo = that._PatientAdmission.Episode.Patient.ID.toString();
                    info.Kurum = that.patientAdmissionFormViewModel.tempPayer.Name;
                    if (that._PatientAdmission.Episode.Patient.UniqueRefNo != null)
                        info.PatientIdentifier = that._PatientAdmission.Episode.Patient.UniqueRefNo.toString();
                    else if (that._PatientAdmission.Episode.Patient.PassportNo != null)
                        info.PatientIdentifier = that._PatientAdmission.Episode.Patient.PassportNo.toString();

                    info.BirthPlace = that._PatientAdmission.Episode.Patient.BirthPlace != null ? that._PatientAdmission.Episode.Patient.BirthPlace :
                        that._PatientAdmission.Episode.Patient.OtherBirthPlace != null ? that._PatientAdmission.Episode.Patient.OtherBirthPlace : "-";

                    info.PatientName = that._PatientAdmission.Episode.Patient.Name + " " + that._PatientAdmission.Episode.Patient.Surname;
                    if (that.patientAdmissionFormViewModel.tempPoliclinic !== null && that.patientAdmissionFormViewModel.tempPoliclinic != undefined)
                        info.PoliclinicName = that.patientAdmissionFormViewModel.tempPoliclinic.Name;
                    info.SiraNo = response.Value.toString();
                    // if (this.patientAdmissionFormViewModel.AppointmentList != null && this.patientAdmissionFormViewModel.AppointmentList.length > 0)
                    info.StartDate = "";//that.datePipe.transform(that.patientAdmissionFormViewModel._PatientAdmission.ActionDate, 'HH:mm');
                    // else
                    //     info.StartDate = this.datePipe.transform(new Date(), 'HH:mm');

                    info.SureAralik = "30";
                    info.RandevuSaati = i18n("M10293", "30 dk");
                    this.barcodePrintService.printAllBarcode(info, "generatePatientBarcode", "printPatientBarcode");
                }
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
            console.log(error);
        });

    }
    public async printResultBarcode() {
        let that = this;
        if (this.patientAdmissionFormViewModel._PatientAdmission.ID == -1)
            ServiceLocator.MessageService.showError(i18n("M17040", "Kabulü görüntüleyiniz."));
        else {

            let url = '/api/PatientAdmissionService/CheckUnfinishedLaboratoryProcedures/?id=' + this.patientAdmissionFormViewModel._PatientAdmission.ObjectID; //Sonuç true dönüyorsa sonuçlanmamış test vardır.

            await that.httpService.get<boolean>(url)
                .then(async response => {

                    if (response != null) {

                        if (response == true) {
                            let message: string = "Hastanın Sonuçlanmamış Laboratuvar Tetkikleri Bulunmaktadır. Devam Etmek İstiyor Musunuz?";
                            let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", message, 1);
                            if (result === "OK") {
                                this.continuePrintResultBarcode();
                            }
                        } else {
                            this.continuePrintResultBarcode();
                        }
                    }
                })
                .catch(error => {
                    this._protocolNo = "";
                    console.log(error);
                });







        }
    }

    public printSingleHCBarcode(event) {
        if (event.row != null) {

            if (event.row.data != null) {

                this.printHCBarcode(false, event.row.data.Resource.ObjectID.toString(), event.row.data.ProcedureDoctorToBeReferred.ObjectID.toString());
            }
        }
    }

    private DispatchAdmission_Click(): Promise<ModalActionResult> {
        if (this.patientAdmissionFormViewModel._PatientAdmission.ID == -1)
            ServiceLocator.MessageService.showError(i18n("M17040", "Kabulü görüntüleyiniz."));
        else if (this._PatientAdmission.DispatchType != DispatchTypeEnum.DispatchedProcedure)
            ServiceLocator.MessageService.showError(i18n("M15902", "Hizmet protokol kabulü olmayan hastalarda ekran görüntülenemez."));
        else {
            return new Promise((resolve, reject) => {
                this.activeEpisodeActionService.ActiveEpisodeActionID = this.patientAdmissionFormViewModel.StarterEpisodeAction;
                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = "DispatchAdmissionForm";
                componentInfo.ModuleName = "KayitKabulModule";
                componentInfo.ModulePath = "/Modules/Tibbi_Surec/Kayit_Kabul_Modulu/KayitKabulModule";
                componentInfo.InputParam = new DynamicComponentInputParam(this.patientAdmissionFormViewModel.StarterEpisodeAction, null);

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = i18n("M21756", "HİZMET PROTOKOL");
                modalInfo.Width = 820;
                modalInfo.Height = 600;


                let result = this.modalService.create(componentInfo, modalInfo);
                result.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        }
    }

    private Patient_Click(): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "NewPatientForm";
            componentInfo.ModuleName = "KayitKabulModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Kayit_Kabul_Modulu/KayitKabulModule";
            componentInfo.InputParam = new DynamicComponentInputParam(this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M11099", "ARŞİV KARTI");
            modalInfo.Width = 820;
            modalInfo.Height = 600;


            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                let patient: Patient = inner.Param as Patient;
                if (this.patientAdmissionFormViewModel._PatientAdmission.Episode.Patient.ObjectID == patient.ObjectID)//arşiv kartındaki hasta ile hasta kabuldeki aynı hasta ise refreshle
                {
                    this.globalPatientAdmissionObjectID = null;
                    this.PatientHistoryListView.Items = new Array<any>();
                    this._historyPatientAdmission = new Array<SubEpisodeProtocol.GetPaBySearchPatient_Class>();
                    this.PatientlistView.Items = new Array<any>();
                    this.AppointmentlistView.Items = new Array<any>();

                    this.initViewModel();

                    this.onInitialize();

                    this.patientChanged(patient);

                    // this.patientAdmissionFormViewModel.SEPCount = this.globalSepCount;
                }

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public isCameraShowing = false;
    onCapturePhotoChanged(event): void {
        this.imageSource = event;
        this.isCameraShowing = false;
    }


    photoCaptured(data) {
        this.patientAdmissionFormViewModel.PhotoString = data;
    }

    public onCameraShowingStarted() {
        this.isCameraShowing = true;
    }

    public onClickPrintMedulaErrorMessage() {
        let printMessage = null;
        if (this.patientAdmissionFormViewModel.SubEpisodeProtocol != null)
            printMessage = this.patientAdmissionFormViewModel.SubEpisodeProtocol.MedulaSonucMesaji;

        if (printMessage != null)
            this.printToCart("medulaErrorMessageToPrint");

    }

    public printToCart(printSectionId: string) {
        let popupWinindow;
        let innerContents = document.getElementById(printSectionId).innerHTML;
        popupWinindow = window.open('', '_blank', 'width=600,height=700,scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no');
        popupWinindow.document.open();
        popupWinindow.document.write('<html><head><link rel="stylesheet" type="text/css" href="style.css" /></head><body onload="window.print()">' + innerContents + '</html>');
        popupWinindow.document.close();
    }

    //<Olay Afet Bilgisi
    public openIncidentDisasterInfo(): Promise<ModalActionResult> {
        this.activeEpisodeActionService.ActiveEpisodeActionID = this.patientAdmissionFormViewModel.StarterEpisodeAction;
        //let episode = this._PatientAdmission.Episode;
        //if (episode != null) {
        //if (this._PatientAdmission != null) {
        return new Promise((resolve, reject) => {


            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'OlayAfetBilgisiForm';
            componentInfo.ModuleName = "ENabizModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule';
            componentInfo.InputParam = new DynamicComponentInputParam("", new ActiveIDsModel(this.patientAdmissionFormViewModel.StarterEpisodeAction, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M19634", "Olay Afet Bilgisi");
            modalInfo.Width = 900;
            modalInfo.Height = 450;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
        //}
        //} else {
        //    this.messageService.showError('Olay/Afet Bilgisi ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir');
        //}
    }
    //Olay Afet Bilgisi>

    lisResult(): void {
        /*  if (url == null) {
              InfoBox.Alert("Bu hizmetin sonucu bulunamadı!");
          } else {
              let win = window.open(url, '_blank');
              win.focus();
          }*/
    }


    public newPayer: Guid;
    public newProtocol: Guid;

    changePayer(): void {
        if (this.patientAdmissionFormViewModel._PatientAdmission.ID == -1)
            ServiceLocator.MessageService.showError(i18n("M18114", "Kurumunu değiştirmek istediğiniz kabulü görüntüleyiniz."));
        else {
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            this.httpService.get<Array<any>>("api/InvoiceDefinitionApi/GetPayer").then(result => {
                this.changePayerPopup = true;
                this.payerArray = result;
                this.protocolArray = new Array<any>();
                this.newPayer = new Guid;
                this.newProtocol = new Guid;
            });
        }
    }

    changePayerSelectboxChanged(e: any): void {
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        this.httpService.get<Array<any>>("api/InvoiceDefinitionApi/GetProtocol?payerObjectID=" + e.value).then(result => {
            this.protocolArray = result;
        });
    }

    public async saveNewPayer() {

        let cp: any = {};

        cp.newPayer = this.newPayer;
        cp.newProtocol = this.newProtocol;
        cp.sepObjectID = this.patientAdmissionFormViewModel.SubEpisodeProtocol.ObjectID;
        let newFormOpenType: any;
        for (let item of this.payerArray) {
            if (item.ObjectID == this.newPayer)
                newFormOpenType = item.Code;
        }

        let apiUrlForUserCustomizationKayit: string = '/api/InvoiceTopMenuApi/SaveNewPayer';
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        this.httpService.post<Guid>(apiUrlForUserCustomizationKayit, cp).then(response => {
            this.changePayerPopup = false;

            this.formOpenPayerType = newFormOpenType;
            this.updatePatientAdmissionAfterNewPayer();

            ServiceLocator.MessageService.showSuccess(i18n("M18041", "Kurum değiştirme işlemi başarı ile sonuçlandı."));
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
            console.log(error);
        });

    }

    private async updatePatientAdmissionAfterNewPayer() {
        await this.loadPAByID(new Guid(this.patientAdmissionFormViewModel._PatientAdmission.ObjectID));
        await this.LoadPatientAdmissionHistory(this.patientAdmissionFormViewModel.HistoryPatientAdmission, false);
    }

    public mustehaklikTarihi: any;

    mustehaklikSorgusuFromChangePayerForm(): void {
        if(this.mustehaklikTarihi == null)
            ServiceLocator.MessageService.showError("Tarih Seçimi yapmadan Sorgulama yapamazsınız");
        else
            this.mustehaklikSorgusu(this.mustehaklikTarihi.toLocaleDateString());
    }

    mustehaklikSorgusu(date: string): void {

        let takipAlUrl = '/api/InvoiceTopMenuApi/mustehaklikSorgusu?sepObjectID=' + this.patientAdmissionFormViewModel.SubEpisodeProtocol.ObjectID + '&date=' + date;

        let that = this;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        this.httpService.get<MedulaResult>(takipAlUrl).then(response => {

            if (response.Succes)
                ServiceLocator.MessageService.showSuccess(response.SonucMesaji);
            else
                ServiceLocator.MessageService.showError(response.SonucMesaji);
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
            console.log(error);
        });

    }

    public async TopluTakipAl() {

        if (this.StartDate == null) {
            ServiceLocator.MessageService.showError(i18n("M30202", "Tarih bilgisi boş bırakılamaz."));
        }
        else if (this.EndDate == null) {
            ServiceLocator.MessageService.showError(i18n("M30202", "Tarih bilgisi boş bırakılamaz."));
        }
        else {
            this.messageService.showInfo(i18n("M30203", "Toplu takip alınıyor,lütfen bekleyiniz."));
            let fullApiUrl: string = "";
            fullApiUrl = '/api/PatientAdmissionService/TopluTakipAl' + '/?startdate=' + this.StartDate.toLocaleDateString() + '&enddate=' + this.EndDate.toLocaleDateString();
            this.httpService.get<PatientAdmissionFormViewModel>(fullApiUrl, PatientAdmissionFormViewModel)
                .then(result => {

                    ServiceLocator.MessageService.showInfo(i18n("M30204", "İşlem gerçekleştirildi."));
                })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                });

            await this.SearchList_Click();
        }


    }

    public PA_ChangePasswordClosing() {
        this.isChangePassword = false;
    }

    public PasswordChanged() {
        this.isChangePassword = false;
    }

    public async onProtocolNoKeyDown(e): Promise<void> {
        let keyCode: any = e.event.keyCode;

        if (keyCode == 13 && this._protocolNo != "") { // Enter 
            let that = this;
            let apiUrl = '/api/PatientAdmissionService/SearchWithProtocolNo/?SearchText=' + this._protocolNo;

            await that.httpService.get<string>(apiUrl)
                .then(response => {
                    this._protocolNo = "";
                    if (response != null && response != "") {

                        this.loadSearchedPatientAdmission(response);
                        this.AddHelpMenu();
                    } else
                        ServiceLocator.MessageService.showInfo("Aradığınız kabul numarası bulunamadı.");
                })
                .catch(error => {
                    this._protocolNo = "";
                    console.log(error);
                });
        }
    }



    async loadSearchedPatientAdmission(patientAdmissionObjectID) {
        this.ObjectID = new Guid(patientAdmissionObjectID);
        this.patientSearchAuto.Clear();
        await this.loadPAByID(new Guid(patientAdmissionObjectID));
        await this.LoadPatientAdmissionHistory(this.patientAdmissionFormViewModel.HistoryPatientAdmission, true);
        await this.MedulaErrorValidator();
        await this.patientSearchAuto.Clear();
        await this.SetTriageColor(this.patientAdmissionFormViewModel._PatientAdmission.Triage);
        await this.SetAdmissionPropertiesEnabled();

        this.patientAdmissionFormViewModel.SEPCount = this.globalSepCount;

    }

    public async onPatientNumberKeyDown(e): Promise<void> {
        let keyCode: any = e.event.keyCode;

        if (keyCode == 13 && this._patientNumber != "") { // Enter 
            let that = this;
            let apiUrl = '/api/PatientAdmissionService/SearchWithPatientID/?SearchText=' + this._patientNumber;

            await that.httpService.get<SearchWithPatientIDResult>(apiUrl, SearchWithPatientIDResult)
                .then(response => {

                    if (response.Patient != null && response.Patient.length > 0) {
                        this.patientChanged(response.Patient[0]);
                        this._patientNumber = "";
                    } else {
                        ServiceLocator.MessageService.showInfo("Aradığınız arşiv numarasına ait hasta bulunamadı.");
                        this._patientNumber = "";
                    }

                })
                .catch(error => {
                    this._patientNumber = "";
                    console.log(error);
                });

        }
    }

    onProtocolNoChanged(data) {
        if (data.value != null)
            this._protocolNo = data.value;
        else
            this._protocolNo = "";
    }

    onPatientIDChanged(data) {
        if (data.value != null)
            this._patientNumber = data.value;
        else
            this._patientNumber = "";
    }

    async FillDataSource(input: InputModelForQueries, sendType: number) {
        try {
            let that = this;
            let body = "";
            let apiUrlForPASearchUrl: string;
            let headers = new Headers({ 'Content-Type': 'application/json' });
            if (sendType === 1) {
                apiUrlForPASearchUrl = '/api/PatientAdmissionService/FillDepartmentList';

                if (this.patientAdmissionFormViewModel.getRelatedResourceParam && !this.patientAdmissionFormViewModel.IsSuperUser)
                    input.filter += " AND THIS.OBJECTID IN(" + this.patientAdmissionFormViewModel.relatedBransList + ")";

                if (this.patientAdmissionFormViewModel._PatientAdmission.IsNew == false) {
                    if (this.patientAdmissionFormViewModel._PatientAdmission.Department != null)
                        input.filter += " OR THIS.OBJECTID= '" + this.patientAdmissionFormViewModel._PatientAdmission.Department + "'";
                }
            }

            else if (sendType === 2) {
                input.filter += " AND this.ISACTIVE = 1";
                apiUrlForPASearchUrl = '/api/PatientAdmissionService/FillPoliclinicList';

                if (this.patientAdmissionFormViewModel.getRelatedResourceParam && !this.patientAdmissionFormViewModel.IsSuperUser)
                    input.filter += " AND THIS.OBJECTID IN(" + this.patientAdmissionFormViewModel.relatedPoliclinicList + ")";

                if (this.patientAdmissionFormViewModel._PatientAdmission.IsNew == false) {
                    if (this.patientAdmissionFormViewModel.tempPoliclinic != null)
                        input.filter += " OR THIS.OBJECTID= '" + this.patientAdmissionFormViewModel.tempPoliclinic.ObjectID + "'";
                }
            }

            else {
                apiUrlForPASearchUrl = '/api/PatientAdmissionService/FillDoctorList';

                if (this.patientAdmissionFormViewModel.getRelatedResourceParam && !this.patientAdmissionFormViewModel.IsSuperUser)
                    input.filter += " AND THIS.OBJECTID IN(" + this.patientAdmissionFormViewModel.relatedPoliclinicDoctorList + ")";

                if (this.patientAdmissionFormViewModel._PatientAdmission.IsNew == false) {
                    if (this.patientAdmissionFormViewModel.tempProcedureDoctor != null)
                        input.filter += " OR THIS.OBJECTID= '" + this.patientAdmissionFormViewModel.tempProcedureDoctor.ObjectID + "'";
                }
            }
            //  let options = new RequestOptions({ headers: headers });
            /*

            let result = await this.httpService.post(apiUrlForPASearchUrl, body);
            this.DoctorList = result;

            */
            await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
                let result = response;
                if (result) {
                    if (sendType === 1) {
                        this.DepartmentList = result;
                        that.departmentSource = new DataSource({
                            store: new ArrayStore({  
                                key: "ObjectID" ,
                                data: that.DepartmentList
                                 
                            }), 
                            searchOperation: 'contains',
                            searchExpr: ['Name','NameShadow','NameLower','NameUpper']
                        });
                    }
                    else if (sendType === 2) {
                        this.PoliclinicList = result;
                    }

                    else {
                        this.DoctorList = result;
                    }
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    /*EP�KR�Z BEG�N*/

    public openEpicrisisReport() {
        let that = this;

        if (that._PatientAdmission == null || that._PatientAdmission.Episode.Patient == null || that._PatientAdmission.Episode.Patient.IsNew == true) {
            that.messageService.showInfo("Epikriz raporu alabilmek için hasta bilgisinin yüklenmesi gereklidir. ");
            return;
        }

        that.httpService.get<Array<EpicrisisReport_Class>>("api/PatientAdmissionService/GetOldInfoForClinic?patientID=" + that._PatientAdmission.Episode.Patient.ObjectID)
            .then(result => {
                that.PatientOldInpatients = result as Array<EpicrisisReport_Class>;
                that.epicrisisReportVisible = true;

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public async EpicirisisMasterResourceChange(): Promise<void> {
        let that = this;

        that.EpicrisisDoctorList.Clear();
        if (that.selectedOldInpatient != null) {

            let masterResource = <EpicrisisReport_Class>that.PatientOldInpatients.find(o => o.ObjectID.toString() === that.selectedOldInpatient.toString());
            let apiUrlForReasonForExamination: string = '/api/PatientAdmissionService/GetDoctorListForEpicrisis?masterResource=' + masterResource.MasterResourceID;

            that.httpService.get<Array<ResUser>>(apiUrlForReasonForExamination)
                .then(result => {
                    that.EpicrisisDoctorList = result as Array<ResUser>;

                })
                .catch(error => {
                    that.messageService.showError(error);
                });

        }
    }

    public printEpicrisisReport() {

        let selectedInpatientPhysicianApplication;
        let selectedDoctorParam;

        if (this.ReportSelectedDoctor != null) {

            selectedDoctorParam = new StringParam(this.ReportSelectedDoctor.toString());
            selectedInpatientPhysicianApplication = new StringParam(this.selectedOldInpatient.toString());

            let reportParameters: any = { 'TTOBJECTID': selectedInpatientPhysicianApplication, 'Doctor': selectedDoctorParam };
            this.reportService.showReport("EpicrisisReportForPatient", reportParameters);

        }
        else {
            this.messageService.showError("Doktor Seçmeden Bu Raporu Yazdıramazsınız");
        }

    }

    /*EP�KR�Z END*/

    public async onResourcesToBeReferredPoliclinic(event: any) {
        let that: this;

        if (event != null && event.selectedItem != null) {
            // this.tempResourcesToBeReferredPoliclinic = event.selectedItem;
            this.patientAdmissionFormViewModel.ProcedureDoctorToBeReferred = await this.getProcedureDoctorToBeReferred(event.selectedItem.ObjectID);
        }
    }

    public async onProcedureDoctorToBeReferred(event: any) {
        // let that:this;
        // if(event != null && event.selectedItem != null)
        // {
        //     this.tempProcedureDoctorToBeReferred = event.selectedItem;             
        // }  

    }

    public async btnAddResourcesToBeReferred() {
        if (this.tempProcedureDoctorToBeReferred != null && this.tempResourcesToBeReferredPoliclinic != null) {

            let index = this.patientAdmissionFormViewModel.ResourcesToBeReferredList.findIndex(o => o.ProcedureDoctorToBeReferred.ObjectID.toString() === this.tempProcedureDoctorToBeReferred.toString()
                && o.Resource.ObjectID.toString() === this.tempResourcesToBeReferredPoliclinic.toString());

            if (index > -1) {
                ServiceLocator.MessageService.showInfo("Bu Poliklinik ve Doktor bilgisi daha önce eklendiği için tekrar ekleyemezsiniz.");
                return;
            }

            let patientAdmissionResourcesToBeReferred: PatientAdmissionResourcesToBeReferred = new PatientAdmissionResourcesToBeReferred(this._PatientAdmission.ObjectContext);
            patientAdmissionResourcesToBeReferred.ProcedureDoctorToBeReferred = this.patientAdmissionFormViewModel.ProcedureDoctorToBeReferred.find(x => x.ObjectID.toString() == this.tempProcedureDoctorToBeReferred);
            let _ttPol = this.patientAdmissionFormViewModel.ResourcesToBeReferredPoliclinic.find(x => x.ObjectID.toString() == this.tempResourcesToBeReferredPoliclinic);
            patientAdmissionResourcesToBeReferred.Resource = _ttPol;
            //todo bg
            // patientAdmissionResourcesToBeReferred.Speciality = this.PoliclinicList.find( x => x.Department.ObjectID == _ttPol.ObjectID);
            this.patientAdmissionFormViewModel.ResourcesToBeReferredList.push(patientAdmissionResourcesToBeReferred);

            this.tempProcedureDoctorToBeReferred = null;
            this.tempResourcesToBeReferredPoliclinic = null;

        }
        else
            ServiceLocator.MessageService.showInfo("Poliklinik ve Doktor alanlarını birlikte seçmelisiniz.");

    }

    public onHcUnitRemoving(event) {
        if (event.row != null) {

            if (event.row.data != null) {
                if (event.row.data.IsNew != false) {//Combo değiştiğinde gelen veriler de yeni ama Isnew undefined geliyor

                    let index = this.patientAdmissionFormViewModel.ResourcesToBeReferredList.findIndex(o => o.ProcedureDoctorToBeReferred.ObjectID.toString() === event.row.data.ProcedureDoctorToBeReferred.ObjectID.toString()
                        && o.Resource.ObjectID.toString() === event.row.data.Resource.ObjectID.toString());

                    if (index > -1)
                        this.patientAdmissionFormViewModel.ResourcesToBeReferredList.splice(index, 1);

                    this.hcUnitGrid.instance.deleteRow(event.rowIndex);
                }
                else {
                    event.data.EntityState = EntityStateEnum.Deleted;
                    this.hcUnitGrid.instance.filter(['EntityState', '<>', 1]);
                    this.hcUnitGrid.instance.refresh();
                }
            }
        }
    }

    /** ACİL BİRLEŞTİRME EKRANI BEGİN */
    public getEmergencyPolList() {
        let that = this;
        this.httpService.get<Array<ResPoliclinic>>("api/PatientAdmissionService/GetEmergencyPolList")
            .then(result => {
                this.emergencyPolList = result as Array<ResPoliclinic>;
                this.ShowEmergencyMerge = true;

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public getEmergencyDocList(e: any) {
        let that = this;

        this.httpService.get<Array<ResUser>>("api/PatientAdmissionService/GetEmergencyDocList?ResourceID=" + e.value)
            .then(result => {
                this.emergencyDoctorList = result as Array<ResUser>;

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public onEmergencyMergeHiding() {
        this.ShowEmergencyMerge = false;

        this._selectedEmergencyPol = null;
        this._selectedEmergencyDoc = null;
        this._selectedEmergencyTriage = new SKRSTRIAJKODU();

    }

    public _selectedEmergencyPol: string = null;
    public _selectedEmergencyDoc: string = null;
    public _selectedEmergencyTriage: SKRSTRIAJKODU = null;

    public async onMergeTriajChanged(event) {

        this._selectedEmergencyTriage = event;

    }

    public async mergeEmergencyIntervention() {
        let that = this;

        if (this._selectedEmergencyPol == null || this._selectedEmergencyDoc == null || this._selectedEmergencyTriage == null)
            that.messageService.showError("Lütfen tüm alanları doldurunuz.");

        let mergeEmergencyClass: MergeEmergencyClass = new MergeEmergencyClass();
        mergeEmergencyClass.patient = that._PatientAdmission.Episode.Patient;
        mergeEmergencyClass.emergencyDoctor = this._selectedEmergencyDoc;
        mergeEmergencyClass.emergencyPoliclinic = this._selectedEmergencyPol;
        mergeEmergencyClass.emergencyTriage = this._selectedEmergencyTriage;


        let apiUrl = '/api/PatientAdmissionService/MergeEmergencyIntervention';
        that.loadingVisible = true;
        that.panelMessage = "Hasta ve Kabul Bilgileri Sorgulanıyor.";

        try {
            let result = await this.httpService.post(apiUrl, mergeEmergencyClass);
            that.loadingVisible = false;
            that.panelMessage = "Kaydediliyor...";

            this._selectedEmergencyPol = null;
            this._selectedEmergencyDoc = null;
            this._selectedEmergencyTriage = new SKRSTRIAJKODU();

            this.ShowEmergencyMerge = false;
            ServiceLocator.MessageService.showSuccess("Kabul Birleştirme İşlemi Başarılı Bir Şekilde Tamamlandı.");
        }
        catch (err) {
            this.loadingVisible = false;
            that.panelMessage = "Kaydediliyor...";
            ServiceLocator.MessageService.showError(err);
        }
    }
    /** ACİL BİRLEŞTİRME EKRANI END */

    async subscribeYupasPopupButton() {

        let that = this;

        return new Promise((resolve, reject) => {
            let btnEvetSub;
            let btnHayirSub;
            window.setTimeout(() => {
                btnEvetSub = that.btnEvet.onClick.subscribe(async t => {

                    btnEvetSub.unsubscribe();
                    btnHayirSub.unsubscribe();
                    resolve(1);

                })

                btnHayirSub = that.btnHayir.onClick.subscribe(t => {
                    btnHayirSub.unsubscribe();
                    btnEvetSub.unsubscribe();
                    resolve(2);

                })
            });


        });
    }
    /*TRİAJ EKRANI AÇMA BEGİN*/

    public getEmergencyInterventionList() {

        if (this.patientAdmissionFormViewModel._PatientAdmission.IsNew) {
            this.messageService.showError("Kaydedilmemiş Kabuller İçin Triaj Ekranı Açılamaz");
            return false;
        }

        let that = this;
        this.httpService.get<Array<ShortHcInfo>>("api/PatientAdmissionService/GetTriageInfoList/?PatientAdmission=" + that.patientAdmissionFormViewModel._PatientAdmission.ObjectID.toString())
            .then(result => {
                this.triageList = result as Array<ShortHcInfo>;

                if (this.triageList != null && this.triageList.length > 0) {
                    if (this.triageList.length == 1)
                        this.OpenEmergencyIntervention(this.triageList[0].ObjectID.toString());
                    else
                        this.ShowEmergencyTriage = true;
                }

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }
    private OpenEmergencyIntervention(PaID: string): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "EmergencyTriageForm";
            componentInfo.ModuleName = "AcilModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Acil_Modulu/AcilModule";
            componentInfo.InputParam = new DynamicComponentInputParam("", null);

            if (PaID != null)
                componentInfo.objectID = PaID;
            else
                componentInfo.objectID = this._selectedTriageInfo;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M13999", "Triaj Kaydetme Formu");
            modalInfo.fullScreen = true;
            // modalInfo.Width = 800;
            modalInfo.Height = 150;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    /*TRİAJ EKRANI AÇMA END */

    onContextMenuPreparing(e: any): void {
        let that = this;
        let menuItemHasProvision = false;
        let menuItemStatus: string;


        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data' && e.row.data.Admissionstatus != "Yatış") {
                e.items = [{
                    text: i18n("M15531", "Provizyon Alamama Nedeni"),
                    disabled: false,
                    onItemClick: function () {
                        that.printMedulaProvisionReport(e.row.data.ObjectID);
                        console.log(e.row.data);

                    }
                }
                ];
            }
        }
    }

    public async openMedulaProvisionReport()
    {
        this.printMedulaProvisionReport(this._PatientAdmission.ObjectID);
    }

    public async printMedulaProvisionReport(objectID:Guid)
    {

        let reportData: DynamicReportParameters = {

            Code: 'MedulaResultReport',
            ReportParams: { PAOBJECTID: objectID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Medula Sonuç Kodu Raporu"

            modalInfo.fullScreen = true;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public makeRamdomID(length) {
        var result           = '';
        var characters       = 'ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghjklmnopqrstuvwxyz0123456789';//Ii sorun çıkarabilir
        var charactersLength = characters.length;
        for ( var i = 0; i < length; i++ ) {
           result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        return result;
    }

    printPatientArchieveBarcode() {
        let barcodeInfo: PatientArchieveBarcodeInfo = new PatientArchieveBarcodeInfo();
        barcodeInfo.PatientName = this._PatientAdmission.Episode.Patient.Name + " " + this._PatientAdmission.Episode.Patient.Surname;
        if (this._PatientAdmission.Episode.Patient.UniqueRefNo != null)
            barcodeInfo.PatientTC = this._PatientAdmission.Episode.Patient.UniqueRefNo.toString();
        else
            barcodeInfo.PatientTC = "";
        let date = new Date();
        barcodeInfo.BarcodeDate = date.toLocaleDateString();

        this.helpMenuService.printPatientArchieveBarcode(barcodeInfo);
    }

    private SevkTalepNoSonucDetay: Array<SevkTalepNoSonucDetay> = new Array<SevkTalepNoSonucDetay>();

    public SevkTalepNoColumns =
        [
            {
                caption: "Kurum Sevk TalepNo",
                dataField: 'kurumSevkTalepNo'
            },
            {
                caption: "Sevk Tarihi",
                dataField: 'sevkTarihi'
            },
            {
                caption: 'Sağlık Tesis Kodu',
                dataField: 'saglikTesisKodu'
            },
            {
                caption: 'Hasta Başvuru No',
                dataField: 'hastaBasvuruNo'
            },
            {
                caption: 'Açıklama',
                dataField: 'aciklama'
            }
        ];


    async SevkNoSorgula() {

        let apiUrl: string = '/api/PatientAdmissionService/SevkNoSorgula?PatientID=' + this._PatientAdmission.Episode.Patient.ObjectID.toString();
        this.httpService.get<SevkTalepNoSonuc>(apiUrl)
            .then(result => {
                if (result.sonucKodu != "0000") {
                    ServiceLocator.MessageService.showError(result.sonucMesaji);
                } else {
                    if (result.SevkTalepNoSonucDetay.length > 0) {
                        this.showSevkTalepNoPopUp = true;
                        this.SevkTalepNoSonucDetay = result.SevkTalepNoSonucDetay;
                    }
                }

            })
            .catch(error => {

                ServiceLocator.MessageService.showError(error);
            });

    }

    async CheckPatientContactStatus() {
      

        let that = this;

        this.httpService.get<Array<FilterDoctorModel>>("api/PatientAdmissionService/GetDoctorListForPatientContactStatus")
            .then(result => {
                this.PatientContactStatusDoctorList = result as Array<FilterDoctorModel>;
                this.showPatientContactStatus = true;

            })
            .catch(error => {
                that.messageService.showError(error);
            });

    }

    async ShowPatientContactStatus() {

            try {
                if (this._PatientAdmission.Episode != null && this._PatientAdmission.Episode.Patient != null && this._PatientAdmission.Episode.Patient.UniqueRefNo != null) {
                    let _temp = null;
                    let fullApiUrl = '/api/PatientAdmissionService/GetHastaTemasDurumu/?doctorObjectID=' + this.selectedDoctorForPatientContactStatus + '&patientObjectID=' + this._PatientAdmission.Episode.Patient.ObjectID;
                    let res = await this.httpService.get<HastaTemasDurumuResultModel>(fullApiUrl, HastaTemasDurumuResultModel);
                    if (res != null) {
                        if (res.responseMessage != "")
                            TTVisual.InfoBox.Alert(res.responseMessage);
                        else
                            TTVisual.InfoBox.Alert("Hastanın Temas Riski Bulunmamaktadır.");


                    }
                }
            }
            catch (error) {
                ServiceLocator.MessageService.showError("Temas Durmu Sorgulanırken bir hata ile karşılaşıldı " + error);
            }

       

    }

}


export class LISPARAM {
    public UniqueRefNo: string;
    public SubEpisodes: any = [];
}


