//$8807C79B
import { Component,  OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ResUserFormViewModel } from './ResUserFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CommonService } from "ObjectClassService/CommonService";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { ForcesCommand } from 'NebulaClient/Model/AtlasClientModel';
import { Person } from 'NebulaClient/Model/AtlasClientModel';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { ResourceSpecialityGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { UserResource } from 'NebulaClient/Model/AtlasClientModel';
import { UserStatusEnum } from 'NebulaClient/Utils/Enums/UserStatusEnum';
import { UserTitleEnum } from 'NebulaClient/Model/AtlasClientModel';
import { UserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MilitaryClassDefinitions } from 'NebulaClient/Model/AtlasClientModel';
import { PatientGroupDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { RankDefinitions } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserPatientGroupMatch } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserUsableStore } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSUlkeKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { TownDefinitions } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'ResUserForm',
    templateUrl: './ResUserForm.html',
    providers: [MessageService]
})
export class ResUserForm extends TTVisual.TTForm implements OnInit {
    Active: TTVisual.ITTCheckBox;
    BirthDate: TTVisual.ITTDateTimePicker;
    BirthPlacePerson: TTVisual.ITTTextBox;
    chkTakesPerformanceScore: TTVisual.ITTCheckBox;
    chkIsClinician: TTVisual.ITTCheckBox;
    CityOfRegistry: TTVisual.ITTObjectListBox;
    CountryOfBirth: TTVisual.ITTObjectListBox;
    DateOfJoin: TTVisual.ITTDateTimePicker;
    DateOfLeave: TTVisual.ITTDateTimePicker;
    DiplomaNo: TTVisual.ITTTextBox;
    EmploymentRecordID: TTVisual.ITTTextBox;
    ErecetePassword: TTVisual.ITTTextBox;
    FatherName: TTVisual.ITTTextBox;
    IsAssignableResUserPatientGroupMatch: TTVisual.ITTCheckBoxColumn;
    KPSPassword: TTVisual.ITTTextBox;
    KPSUserName: TTVisual.ITTTextBox;
    labelBirthDate: TTVisual.ITTLabel;
    labelBirthPlacePerson: TTVisual.ITTLabel;
    labelDateOfJoin: TTVisual.ITTLabel;
    labelDateOfLeave: TTVisual.ITTLabel;
    labelDiplomaNo: TTVisual.ITTLabel;
    labelEmploymentRecordID: TTVisual.ITTLabel;
    labelErecetePassword: TTVisual.ITTLabel;
    labelFatherName: TTVisual.ITTLabel;
    labelKPSPassword: TTVisual.ITTLabel;
    labelKPSUserName: TTVisual.ITTLabel;
    labelMkysPassword: TTVisual.ITTLabel;
    labelMkysUserName: TTVisual.ITTLabel;
    labelMotherName: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelPhoneNumber: TTVisual.ITTLabel;
    labelPreDischargeLimit: TTVisual.ITTLabel;
    labelSex: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelSurname: TTVisual.ITTLabel;
    labelTitle: TTVisual.ITTLabel;
    labelUniqueRefNo: TTVisual.ITTLabel;
    labelUserType: TTVisual.ITTLabel;
    labelVillageOfRegistry: TTVisual.ITTLabel;
    labelWork: TTVisual.ITTLabel;
    labelWorkPlace: TTVisual.ITTLabel;
    lblResUserPatientGroupMatch: TTVisual.ITTLabel;
    lblUserName: TTVisual.ITTLabel;
    MainSpeciality: TTVisual.ITTCheckBoxColumn;
    MkysPassword: TTVisual.ITTTextBox;
    MkysUserName: TTVisual.ITTTextBox;
    MotherName: TTVisual.ITTTextBox;
    Name: TTVisual.ITTTextBox;
    PatientGroupResUserPatientGroupMatch: TTVisual.ITTListBoxColumn;
    PatientInfo: TTVisual.ITTTabPage;
    PhoneNumber: TTVisual.ITTTextBox;
    PreDischargeLimit: TTVisual.ITTTextBox;
    ResourceSpecialities: TTVisual.ITTGrid;
    ResUserPatientGroupMatches: TTVisual.ITTGrid;
    ResUserPatientGroupTab: TTVisual.ITTTabPage;
    ResUserUsableStores: TTVisual.ITTGrid;
    SecMasterDepartment: TTVisual.ITTListBoxColumn;
    SentToMHRS: TTVisual.ITTCheckBox;
    SexPerson: TTVisual.ITTObjectListBox;
    Speciality: TTVisual.ITTListBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    StoreResUserUsableStore: TTVisual.ITTListBoxColumn;
    Surname: TTVisual.ITTTextBox;
    TescilNo: TTVisual.ITTTextBox;
    TownOfBirth: TTVisual.ITTObjectListBox;
    TownOfRegistryPerson: TTVisual.ITTObjectListBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    txtUserName: TTVisual.ITTTextBox;
    UniqueRefNo: TTVisual.ITTTextBox;
    UserInfo: TTVisual.ITTTabPage;
    UserResources: TTVisual.ITTGrid;
    UserTitle: TTVisual.ITTEnumComboBox;
    UserType: TTVisual.ITTEnumComboBox;
    UsesESignature: TTVisual.ITTCheckBox;
    VillageOfRegistry: TTVisual.ITTTextBox;
    WorkPlace: TTVisual.ITTTextBox;
    public ResourceSpecialitiesColumns = [];
    public ResUserPatientGroupMatchesColumns = [];
    public ResUserUsableStoresColumns = [];
    public UserResourcesColumns = [];
    public resUserFormViewModel: ResUserFormViewModel = new ResUserFormViewModel();
    public get _ResUser(): ResUser {
        return this._TTObject as ResUser;
    }
    private ResUserForm_DocumentUrl: string = '/api/ResUserService/ResUserForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('RESUSER', 'ResUserForm');
        this._DocumentServiceUrl = this.ResUserForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async ResourceSpecialities_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        if (rowIndex < this.ResourceSpecialities.Rows.length && rowIndex > -1) {
            if (columnIndex === 0 && (<boolean>this.ResourceSpecialities.CurrentCell.Value === true)) {
                for (let i: number = 0; i < this.ResourceSpecialities.Rows.length; i++) {
                    if (i !== rowIndex) {
                        this.ResourceSpecialities.Rows[i].Cells[0].Value = false;
                    }
                }
            }
        }
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        //SITEID ye gore PACS a gonderim yapilmis, o kod kaldirildi. PACS entegrasyonu olup olmadigi bilgisi sistem parametresi ile tutulup gonderim yapilabilir. 
        //this._ResUser.SendUserToPACS();
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        this._ResUser.Person.Name = this._ResUser.Person.Name.trim();
        this._ResUser.Person.Surname = this._ResUser.Person.Surname.trim();
        this._ResUser.Name = this._ResUser.Person.Name + ' ' + this._ResUser.Person.Surname;
        if (this._ResUser.ResourceSpecialities.length === 1) {
            this._ResUser.ResourceSpecialities[0].MainSpeciality = true;
        }
        else if (this._ResUser.ResourceSpecialities.length > 1) {
            let main: number = 0;
            for (let resSepeciality of this._ResUser.ResourceSpecialities) {
                if (resSepeciality.MainSpeciality === true) {
                    main++;
                }
            }
            if (main === 0) {
                throw new Exception((await SystemMessageService.GetMessage(653)));
            }
            else if (main > 1) {
                throw new Exception((await SystemMessageService.GetMessage(654)));
            }
        }
        this.SetTakesPerformanceScore();
    }
    protected async PreScript(): Promise<void> {
        super.PreScript();
        if (this._ResUser.Person == null) {
            let person: Person = new Person(this._ResUser.ObjectContext);
            this._ResUser.Person = person;
        }

        //if ((TTObjectClasses.SystemParameter.GetParameterValue("WORKWITHPERSONNELINFOSYSTEM", "FALSE")) == "TRUE") {
        //    this.UserTitle.ReadOnly = true;
        //    this.BirthDate.ReadOnly = true;
        //    this.CountryOfBirth.ReadOnly = true;
        //    //  this.CityOfBith.ReadOnly = true;
        //    // this.TownOfBirth.ReadOnly = true;
        //    // this.Sex.ReadOnly = true;
        //    this.CityOfRegistry.ReadOnly = true;
        //    this.TownOfRegistryPerson.ReadOnly = true;
        //    this.VillageOfRegistry.ReadOnly = true;
        //    this.DateOfJoin.ReadOnly = true;
        //    this.DateOfLeave.ReadOnly = true;
        //    this.EmploymentRecordID.ReadOnly = true;
        //    this.DiplomaNo.ReadOnly = true;
        //}
        //else {
        //    this.UserTitle.ReadOnly = false;
        //    this.BirthDate.ReadOnly = false;
        //    this.CountryOfBirth.ReadOnly = false;
        //    //this.CityOfBith.ReadOnly = false;
        //    //this.TownOfBirth.ReadOnly = false;
        //    //this.Sex.ReadOnly = false;
        //    this.CityOfRegistry.ReadOnly = false;
        //    this.TownOfRegistryPerson.ReadOnly = false;
        //    this.VillageOfRegistry.ReadOnly = false;
        //    this.DateOfJoin.ReadOnly = false;
        //    this.DateOfLeave.ReadOnly = false;
        //    this.EmploymentRecordID.ReadOnly = false;
        //    this.DiplomaNo.ReadOnly = false;
        //}

    }
    public async SetTakesPerformanceScore(): Promise<void> {
        this._ResUser.TakesPerformanceScore = false;
        if (this._ResUser.UserType !== null && this._ResUser.Title !== null) {
            if (this._ResUser.UserType === UserTypeEnum.Doctor || this._ResUser.UserType === UserTypeEnum.Dentist) {
                if (this._ResUser.Title !== UserTitleEnum.UzmanOgr && this._ResUser.Title !== UserTitleEnum.DoktoraOgr && this._ResUser.Title !== UserTitleEnum.YanDalUzmanOgr && this._ResUser.Title !== UserTitleEnum.YLisansUzmanOgr && this._ResUser.Title !== UserTitleEnum.Unused && this._ResUser.Title !== UserTitleEnum.UzmanEcz) {
                    this._ResUser.TakesPerformanceScore = true;
                }
            }
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ResUser();
        this.resUserFormViewModel = new ResUserFormViewModel();
        this._ViewModel = this.resUserFormViewModel;
        this.resUserFormViewModel._ResUser = this._TTObject as ResUser;
        this.resUserFormViewModel._ResUser.Person = new Person();
        this.resUserFormViewModel._ResUser.Person.TownOfRegistry = new TownDefinitions();
        this.resUserFormViewModel._ResUser.Person.Sex = new SKRSCinsiyet();
        this.resUserFormViewModel._ResUser.Person.TownOfBirth = new TownDefinitions();
        this.resUserFormViewModel._ResUser.Person.CountryOfBirth = new SKRSUlkeKodlari();
        this.resUserFormViewModel._ResUser.Person.CityOfRegistry = new SKRSILKodlari();
        this.resUserFormViewModel._ResUser.ForcesCommand = new ForcesCommand();
        this.resUserFormViewModel._ResUser.ResourceSpecialities = new Array<ResourceSpecialityGrid>();
        this.resUserFormViewModel._ResUser.Rank = new RankDefinitions();
        this.resUserFormViewModel._ResUser.MilitaryClass = new MilitaryClassDefinitions();
        this.resUserFormViewModel._ResUser.ResUserUsableStores = new Array<ResUserUsableStore>();
        this.resUserFormViewModel._ResUser.Store = new Store();
        this.resUserFormViewModel._ResUser.UserResources = new Array<UserResource>();
        this.resUserFormViewModel._ResUser.ResUserPatientGroupMatches = new Array<ResUserPatientGroupMatch>();
    }

    protected loadViewModel() {
        let that = this;
        that.resUserFormViewModel = this._ViewModel as ResUserFormViewModel;
        that._TTObject = this.resUserFormViewModel._ResUser;
        if (this.resUserFormViewModel == null)
            this.resUserFormViewModel = new ResUserFormViewModel();
        if (this.resUserFormViewModel._ResUser == null)
            this.resUserFormViewModel._ResUser = new ResUser();
        let personObjectID = that.resUserFormViewModel._ResUser["Person"];
        if (personObjectID != null && (typeof personObjectID === "string")) {
            if (that.resUserFormViewModel.Persons != null) {
                let person = that.resUserFormViewModel.Persons.find(o => o.ObjectID.toString() === personObjectID.toString());
                if (person) {
                    that.resUserFormViewModel._ResUser.Person = person;
                }

                if (person != null) {
                    let townOfRegistryObjectID = person["TownOfRegistry"];
                    if (townOfRegistryObjectID != null && (typeof townOfRegistryObjectID === "string")) {
                        let townOfRegistry = that.resUserFormViewModel.TownDefinitionss.find(o => o.ObjectID.toString() === townOfRegistryObjectID.toString());
                        if (townOfRegistry) {
                            person.TownOfRegistry = townOfRegistry;
                        }
                    }

                }

                if (person != null) {
                    let sexObjectID = person["Sex"];
                    if (sexObjectID != null && (typeof sexObjectID === "string")) {
                        let sex = that.resUserFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === sexObjectID.toString());
                        if (sex) {
                            person.Sex = sex;
                        }
                    }

                }

                if (person != null) {
                    let townOfBirthObjectID = person["TownOfBirth"];
                    if (townOfBirthObjectID != null && (typeof townOfBirthObjectID === "string")) {
                        let townOfBirth = that.resUserFormViewModel.TownDefinitionss.find(o => o.ObjectID.toString() === townOfBirthObjectID.toString());
                        if (townOfBirth) {
                            person.TownOfBirth = townOfBirth;
                        }
                    }

                }

                if (person != null) {
                    let countryOfBirthObjectID = person["CountryOfBirth"];
                    if (countryOfBirthObjectID != null && (typeof countryOfBirthObjectID === "string")) {
                        let countryOfBirth = that.resUserFormViewModel.SKRSUlkeKodlaris.find(o => o.ObjectID.toString() === countryOfBirthObjectID.toString());
                        if (countryOfBirth) {
                            person.CountryOfBirth = countryOfBirth;
                        }
                    }

                }

                if (person != null) {
                    let cityOfRegistryObjectID = person["CityOfRegistry"];
                    if (cityOfRegistryObjectID != null && (typeof cityOfRegistryObjectID === "string")) {
                        let cityOfRegistry = that.resUserFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === cityOfRegistryObjectID.toString());
                        if (cityOfRegistry) {
                            person.CityOfRegistry = cityOfRegistry;
                        }
                    }

                }
            }

        }


        that.resUserFormViewModel._ResUser.ResourceSpecialities = that.resUserFormViewModel.ResourceSpecialitiesGridList;
        for (let detailItem of that.resUserFormViewModel.ResourceSpecialitiesGridList) {
            let specialityObjectID = detailItem["Speciality"];
            if (specialityObjectID != null && (typeof specialityObjectID === "string")) {
                let speciality = that.resUserFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityObjectID.toString());
                if (speciality) {
                    detailItem.Speciality = speciality;
                }
            }

        }


        that.resUserFormViewModel._ResUser.ResUserUsableStores = that.resUserFormViewModel.ResUserUsableStoresGridList;
        for (let detailItem of that.resUserFormViewModel.ResUserUsableStoresGridList) {
            let storeObjectID = detailItem["Store"];
            if (storeObjectID != null && (typeof storeObjectID === "string")) {
                let store = that.resUserFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                if (store) {
                    detailItem.Store = store;
                }
            }

        }

        let storeObjectID = that.resUserFormViewModel._ResUser["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.resUserFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.resUserFormViewModel._ResUser.Store = store;
            }
        }


        that.resUserFormViewModel._ResUser.UserResources = that.resUserFormViewModel.UserResourcesGridList;
        for (let detailItem of that.resUserFormViewModel.UserResourcesGridList) {
            let resourceObjectID = detailItem["Resource"];
            if (resourceObjectID != null && (typeof resourceObjectID === "string")) {
                let resource = that.resUserFormViewModel.ResSections.find(o => o.ObjectID.toString() === resourceObjectID.toString());
                if (resource) {
                    detailItem.Resource = resource;
                }
            }

        }

        that.resUserFormViewModel._ResUser.ResUserPatientGroupMatches = that.resUserFormViewModel.ResUserPatientGroupMatchesGridList;
        for (let detailItem of that.resUserFormViewModel.ResUserPatientGroupMatchesGridList) {
            let patientGroupObjectID = detailItem["PatientGroup"];
            if (patientGroupObjectID != null && (typeof patientGroupObjectID === "string")) {
                let patientGroup = that.resUserFormViewModel.PatientGroupDefinitions.find(o => o.ObjectID.toString() === patientGroupObjectID.toString());
                if (patientGroup) {
                    detailItem.PatientGroup = patientGroup;
                }
            }

        }


    }

    async ngOnInit() {
        await this.load();
    }

    public onActiveChanged(event): void {
        if (this._ResUser != null && this._ResUser.IsActive != event) {
            this._ResUser.IsActive = event;
        }
    }

    public onBirthDateChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.BirthDate != event) {
            this._ResUser.Person.BirthDate = event;
        }
    }

    public onBirthPlacePersonChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.BirthPlace != event) {
            this._ResUser.Person.BirthPlace = event;
        }
    }

    public onchkTakesPerformanceScoreChanged(event): void {
        if (this._ResUser != null && this._ResUser.TakesPerformanceScore != event) {
            this._ResUser.TakesPerformanceScore = event;
        }
    }

    public onchkIsClinicianChanged(event): void {
        if (this._ResUser != null && this._ResUser.IsClinician != event) {
            this._ResUser.IsClinician = event;
        }
    }

    public onCityOfRegistryChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.CityOfRegistry != event) {
            this._ResUser.Person.CityOfRegistry = event;
        }
    }

    public onCountryOfBirthChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.CountryOfBirth != event) {
            this._ResUser.Person.CountryOfBirth = event;
        }
    }

    public onDateOfJoinChanged(event): void {
        if (this._ResUser != null && this._ResUser.DateOfJoin != event) {
            this._ResUser.DateOfJoin = event;
        }
    }

    public onDateOfLeaveChanged(event): void {
        if (this._ResUser != null && this._ResUser.DateOfLeave != event) {
            this._ResUser.DateOfLeave = event;
        }
    }

    public onDiplomaNoChanged(event): void {
        if (this._ResUser != null && this._ResUser.DiplomaNo != event) {
            this._ResUser.DiplomaNo = event;
        }
    }

    public onEmploymentRecordIDChanged(event): void {
        if (this._ResUser != null && this._ResUser.EmploymentRecordID != event) {
            this._ResUser.EmploymentRecordID = event;
        }
    }

    public onErecetePasswordChanged(event): void {
        if (this._ResUser != null && this._ResUser.ErecetePassword != event) {
            this._ResUser.ErecetePassword = event;
        }
    }

    public onFatherNameChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.FatherName != event) {
            this._ResUser.Person.FatherName = event;
        }
    }

    public onKPSPasswordChanged(event): void {
        if (this._ResUser != null && this._ResUser.KPSPassword != event) {
            this._ResUser.KPSPassword = event;
        }
    }

    public onKPSUserNameChanged(event): void {
        if (this._ResUser != null && this._ResUser.KPSUserName != event) {
            this._ResUser.KPSUserName = event;
        }
    }

    public onMkysPasswordChanged(event): void {
        if (this._ResUser != null && this._ResUser.MkysPassword != event) {
            this._ResUser.MkysPassword = event;
        }
    }

    public onMkysUserNameChanged(event): void {
        if (this._ResUser != null && this._ResUser.MkysUserName != event) {
            this._ResUser.MkysUserName = event;
        }
    }

    public onMotherNameChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.MotherName != event) {
            this._ResUser.Person.MotherName = event;
        }
    }

    public onNameChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.Name != event) {
            this._ResUser.Person.Name = event;
        }
    }

    public onPhoneNumberChanged(event): void {
        if (this._ResUser != null && this._ResUser.PhoneNumber != event) {
            this._ResUser.PhoneNumber = event;
        }
    }

    public onPreDischargeLimitChanged(event): void {
        if (this._ResUser != null && this._ResUser.PreDischargeLimit != event) {
            this._ResUser.PreDischargeLimit = event;
        }
    }

    public onSentToMHRSChanged(event): void {
        if (this._ResUser != null && this._ResUser.SentToMHRS != event) {
            this._ResUser.SentToMHRS = event;
        }
    }

    public onSexPersonChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.Sex != event) {
            this._ResUser.Person.Sex = event;
        }
    }

    public onStoreChanged(event): void {
        if (this._ResUser != null && this._ResUser.Store != event) {
            this._ResUser.Store = event;
        }
    }

    public onSurnameChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.Surname != event) {
            this._ResUser.Person.Surname = event;
        }
    }

    public onTescilNoChanged(event): void {
        if (this._ResUser != null && this._ResUser.DiplomaRegisterNo != event) {
            this._ResUser.DiplomaRegisterNo = event;
        }
    }

    public onTownOfBirthChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.TownOfBirth != event) {
            this._ResUser.Person.TownOfBirth = event;
        }
    }

    public onTownOfRegistryPersonChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.TownOfRegistry != event) {
            this._ResUser.Person.TownOfRegistry = event;
        }
    }

    public ontttextbox1Changed(event): void {
        if (this._ResUser != null && this._ResUser.SpecialityRegistryNo != event) {
            this._ResUser.SpecialityRegistryNo = event;
        }
    }

    public ontttextbox3Changed(event): void {
        if (this._ResUser != null && this._ResUser.Work != event) {
            this._ResUser.Work = event;
        }
    }

    public onUniqueRefNoChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.UniqueRefNo != event) {
            this._ResUser.Person.UniqueRefNo = event;
        }
    }

    public onUserTitleChanged(event): void {
        if (this._ResUser != null && this._ResUser.Title != event) {
            this._ResUser.Title = event;
        }
    }

    public onUserTypeChanged(event): void {
        if (this._ResUser != null && this._ResUser.UserType != event) {
            this._ResUser.UserType = event;
        }
    }

    public onUsesESignatureChanged(event): void {
        if (this._ResUser != null && this._ResUser.UsesESignature != event) {
            this._ResUser.UsesESignature = event;
        }
    }

    public onVillageOfRegistryChanged(event): void {
        if (this._ResUser != null &&
            this._ResUser.Person != null && this._ResUser.Person.VillageOfRegistry != event) {
            this._ResUser.Person.VillageOfRegistry = event;
        }
    }

    public onWorkPlaceChanged(event): void {
        if (this._ResUser != null && this._ResUser.WorkPlace != event) {
            this._ResUser.WorkPlace = event;
        }
    }



    ResourceSpecialities_CellValueChangedEmitted(data: any) {
        if (data && this.ResourceSpecialities_CellValueChanged && data.Row && data.Column) {
            this.ResourceSpecialities.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };
            this.ResourceSpecialities_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.UniqueRefNo, "Text", this.__ttObject, "Person.UniqueRefNo");
        redirectProperty(this.UserType, "Value", this.__ttObject, "UserType");
        redirectProperty(this.UserTitle, "Value", this.__ttObject, "Title");
        redirectProperty(this.Active, "Value", this.__ttObject, "ISACTIVE");
        redirectProperty(this.UsesESignature, "Value", this.__ttObject, "UsesESignature");
        redirectProperty(this.Name, "Text", this.__ttObject, "Person.Name");
        redirectProperty(this.Surname, "Text", this.__ttObject, "Person.Surname");
        redirectProperty(this.FatherName, "Text", this.__ttObject, "Person.FatherName");
        redirectProperty(this.MotherName, "Text", this.__ttObject, "Person.MotherName");
        redirectProperty(this.chkTakesPerformanceScore, "Value", this.__ttObject, "TakesPerformanceScore");
        redirectProperty(this.chkIsClinician, "Value", this.__ttObject, "IsClinician");
        redirectProperty(this.BirthDate, "Value", this.__ttObject, "Person.BirthDate");
        redirectProperty(this.BirthPlacePerson, "Text", this.__ttObject, "Person.BirthPlace");
        redirectProperty(this.PreDischargeLimit, "Text", this.__ttObject, "PreDischargeLimit");
        redirectProperty(this.VillageOfRegistry, "Text", this.__ttObject, "Person.VillageOfRegistry");
        redirectProperty(this.DateOfJoin, "Value", this.__ttObject, "DateOfJoin");
        redirectProperty(this.DateOfLeave, "Value", this.__ttObject, "DateOfLeave");
        redirectProperty(this.PhoneNumber, "Text", this.__ttObject, "PhoneNumber");
        redirectProperty(this.DiplomaNo, "Text", this.__ttObject, "DiplomaNo");
        redirectProperty(this.TescilNo, "Text", this.__ttObject, "DiplomaRegisterNo");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "SpecialityRegistryNo");
        redirectProperty(this.EmploymentRecordID, "Text", this.__ttObject, "EmploymentRecordID");
        redirectProperty(this.ErecetePassword, "Text", this.__ttObject, "ErecetePassword");
        redirectProperty(this.SentToMHRS, "Value", this.__ttObject, "SentToMHRS");
        redirectProperty(this.MkysUserName, "Text", this.__ttObject, "MkysUserName");
        redirectProperty(this.MkysPassword, "Text", this.__ttObject, "MkysPassword");
        redirectProperty(this.KPSUserName, "Text", this.__ttObject, "KPSUserName");
        redirectProperty(this.KPSPassword, "Text", this.__ttObject, "KPSPassword");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "Work");
        redirectProperty(this.WorkPlace, "Text", this.__ttObject, "WorkPlace");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 56;

        this.PatientInfo = new TTVisual.TTTabPage();
        this.PatientInfo.DisplayIndex = 0;
        this.PatientInfo.BackColor = "#FFFFFF";
        this.PatientInfo.TabIndex = 0;
        this.PatientInfo.Text = "Kullanıcı Bilgileri";
        this.PatientInfo.Name = "PatientInfo";

        this.labelKPSPassword = new TTVisual.TTLabel();
        this.labelKPSPassword.Text = "KPS Şifre";
        this.labelKPSPassword.Name = "labelKPSPassword";
        this.labelKPSPassword.TabIndex = 71;

        this.KPSPassword = new TTVisual.TTTextBox();
        this.KPSPassword.Name = "KPSPassword";
        this.KPSPassword.TabIndex = 70;

        this.labelKPSUserName = new TTVisual.TTLabel();
        this.labelKPSUserName.Text = "KPS Kullanıcı Adı";
        this.labelKPSUserName.Name = "labelKPSUserName";
        this.labelKPSUserName.TabIndex = 69;

        this.KPSUserName = new TTVisual.TTTextBox();
        this.KPSUserName.Name = "KPSUserName";
        this.KPSUserName.TabIndex = 68;

        this.TownOfRegistryPerson = new TTVisual.TTObjectListBox();
        this.TownOfRegistryPerson.ListDefName = "TownListDefinition";
        this.TownOfRegistryPerson.Name = "TownOfRegistryPerson";
        this.TownOfRegistryPerson.TabIndex = 62;

        this.SexPerson = new TTVisual.TTObjectListBox();
        this.SexPerson.ListDefName = "SKRSCinsiyetList";
        this.SexPerson.Name = "SexPerson";
        this.SexPerson.TabIndex = 60;

        this.labelBirthPlacePerson = new TTVisual.TTLabel();
        this.labelBirthPlacePerson.Text = "Doğum Yeri(Diğer)";
        this.labelBirthPlacePerson.Name = "labelBirthPlacePerson";
        this.labelBirthPlacePerson.TabIndex = 59;

        this.BirthPlacePerson = new TTVisual.TTTextBox();
        this.BirthPlacePerson.Name = "BirthPlacePerson";
        this.BirthPlacePerson.TabIndex = 58;

        this.labelPreDischargeLimit = new TTVisual.TTLabel();
        this.labelPreDischargeLimit.Text = "Ön Taburcu Limiti";
        this.labelPreDischargeLimit.Name = "labelPreDischargeLimit";
        this.labelPreDischargeLimit.TabIndex = 57;

        this.PreDischargeLimit = new TTVisual.TTTextBox();
        this.PreDischargeLimit.Name = "PreDischargeLimit";
        this.PreDischargeLimit.TabIndex = 56;

        this.labelMkysUserName = new TTVisual.TTLabel();
        this.labelMkysUserName.Text = "MKYS Kullanıcı Adı";
        this.labelMkysUserName.Name = "labelMkysUserName";
        this.labelMkysUserName.TabIndex = 55;

        this.MkysUserName = new TTVisual.TTTextBox();
        this.MkysUserName.Name = "MkysUserName";
        this.MkysUserName.TabIndex = 54;

        this.labelMkysPassword = new TTVisual.TTLabel();
        this.labelMkysPassword.Text = "MKYS Şifre";
        this.labelMkysPassword.Name = "labelMkysPassword";
        this.labelMkysPassword.TabIndex = 53;

        this.MkysPassword = new TTVisual.TTTextBox();
        //this.MkysPassword.PasswordChar = *;
        this.MkysPassword.Name = "MkysPassword";
        this.MkysPassword.TabIndex = 52;

        this.chkTakesPerformanceScore = new TTVisual.TTCheckBox();
        this.chkTakesPerformanceScore.Value = false;
        this.chkTakesPerformanceScore.Text = "Performans Puanı Alır";
        this.chkTakesPerformanceScore.Title = "Performans Puanı Alır";
        this.chkTakesPerformanceScore.Enabled = false;
        this.chkTakesPerformanceScore.Name = "chkTakesPerformanceScore";
        this.chkTakesPerformanceScore.TabIndex = 51;

        this.chkIsClinician = new TTVisual.TTCheckBox();
        this.chkIsClinician.Value = false;
        this.chkIsClinician.Text = "Klinisyen Hekim";
        this.chkIsClinician.Title = "Klinisyen Hekim";
        this.chkIsClinician.Enabled = true;
        this.chkIsClinician.ThreeState = false;
        this.chkIsClinician.Name = "chkIsClinician";
        this.chkIsClinician.TabIndex = 51;

        this.UsesESignature = new TTVisual.TTCheckBox();
        this.UsesESignature.Value = false;
        this.UsesESignature.Text = "Elektronik İmza Kullanır";
        this.UsesESignature.Title = "Elektronik İmza Kullanır";
        this.UsesESignature.Name = "UsesESignature";
        this.UsesESignature.TabIndex = 50;

        this.SentToMHRS = new TTVisual.TTCheckBox();
        this.SentToMHRS.Value = false;
        this.SentToMHRS.Text = "MHRS'ye Bildir";
        this.SentToMHRS.Title = "MHRS'ye Bildir";
        this.SentToMHRS.Name = "SentToMHRS";
        this.SentToMHRS.TabIndex = 49;

        this.labelErecetePassword = new TTVisual.TTLabel();
        this.labelErecetePassword.Text = "E Reçete Şifresi";
        this.labelErecetePassword.Name = "labelErecetePassword";
        this.labelErecetePassword.TabIndex = 48;

        this.ErecetePassword = new TTVisual.TTTextBox();
        //this.ErecetePassword.PasswordChar = *;
        this.ErecetePassword.Name = "ErecetePassword";
        this.ErecetePassword.TabIndex = 47;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "Kuvvet";
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 46;

        this.FatherName = new TTVisual.TTTextBox();
        this.FatherName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FatherName.Name = "FatherName";
        this.FatherName.TabIndex = 5;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 20;

        this.TescilNo = new TTVisual.TTTextBox();
        this.TescilNo.Name = "TescilNo";
        this.TescilNo.TabIndex = 20;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "Uzmanlık Tescil No";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 14;

        this.lblUserName = new TTVisual.TTLabel();
        this.lblUserName.Text = "Kullanıcı Adı";
        this.lblUserName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblUserName.ForeColor = "#000000";
        this.lblUserName.Name = "lblUserName";
        this.lblUserName.TabIndex = 26;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Diploma Tescil No";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 14;

        this.txtUserName = new TTVisual.TTTextBox();
        this.txtUserName.BackColor = "#F0F0F0";
        this.txtUserName.ReadOnly = true;
        this.txtUserName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.txtUserName.Name = "txtUserName";
        this.txtUserName.TabIndex = 6;

        this.UserTitle = new TTVisual.TTEnumComboBox();
        this.UserTitle.DataTypeName = "UserTitleEnum";
        this.UserTitle.Name = "UserTitle";
        this.UserTitle.TabIndex = 1;

        this.ResourceSpecialities = new TTVisual.TTGrid();
        this.ResourceSpecialities.BackColor = "#DCDCDC";
        this.ResourceSpecialities.Name = "ResourceSpecialities";
        this.ResourceSpecialities.TabIndex = 23;

        this.MainSpeciality = new TTVisual.TTCheckBoxColumn();
        this.MainSpeciality.DataMember = "MainSpeciality";
        this.MainSpeciality.DisplayIndex = 0;
        this.MainSpeciality.HeaderText = "Ana Uzmanlık Dalı";
        this.MainSpeciality.Name = "MainSpeciality";
        this.MainSpeciality.Width = 100;

        this.Speciality = new TTVisual.TTListBoxColumn();
        this.Speciality.ListDefName = "SpecialityListDefinition";
        this.Speciality.DataMember = "Speciality";
        this.Speciality.DisplayIndex = 1;
        this.Speciality.HeaderText = "Uzmanlık Dalları";
        this.Speciality.Name = "Speciality";
        this.Speciality.Width = 380;

        this.labelEmploymentRecordID = new TTVisual.TTLabel();
        this.labelEmploymentRecordID.Text = "Sicil No";
        this.labelEmploymentRecordID.ForeColor = "#000000";
        this.labelEmploymentRecordID.Name = "labelEmploymentRecordID";
        this.labelEmploymentRecordID.TabIndex = 16;

        this.labelDateOfJoin = new TTVisual.TTLabel();
        this.labelDateOfJoin.Text = "Giriş Tarihi";
        this.labelDateOfJoin.ForeColor = "#000000";
        this.labelDateOfJoin.Name = "labelDateOfJoin";
        this.labelDateOfJoin.TabIndex = 8;

        this.labelTitle = new TTVisual.TTLabel();
        this.labelTitle.Text = "Ünvan";
        this.labelTitle.ForeColor = "#000000";
        this.labelTitle.Name = "labelTitle";
        this.labelTitle.TabIndex = 23;

        this.labelUserType = new TTVisual.TTLabel();
        this.labelUserType.Text = "Mesleği";
        this.labelUserType.ForeColor = "#000000";
        this.labelUserType.Name = "labelUserType";
        this.labelUserType.TabIndex = 25;

        this.EmploymentRecordID = new TTVisual.TTTextBox();
        this.EmploymentRecordID.Name = "EmploymentRecordID";
        this.EmploymentRecordID.TabIndex = 21;

        this.labelDateOfLeave = new TTVisual.TTLabel();
        this.labelDateOfLeave.Text = "Ayrılış Tarihi";
        this.labelDateOfLeave.ForeColor = "#000000";
        this.labelDateOfLeave.Name = "labelDateOfLeave";
        this.labelDateOfLeave.TabIndex = 10;

        this.labelPhoneNumber = new TTVisual.TTLabel();
        this.labelPhoneNumber.Text = "Telefon No";
        this.labelPhoneNumber.ForeColor = "#000000";
        this.labelPhoneNumber.Name = "labelPhoneNumber";
        this.labelPhoneNumber.TabIndex = 20;

        this.labelUniqueRefNo = new TTVisual.TTLabel();
        this.labelUniqueRefNo.Text = "T.C. Kimlik No";
        this.labelUniqueRefNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelUniqueRefNo.ForeColor = "#000000";
        this.labelUniqueRefNo.Name = "labelUniqueRefNo";
        this.labelUniqueRefNo.TabIndex = 20;

        this.DiplomaNo = new TTVisual.TTTextBox();
        this.DiplomaNo.Name = "DiplomaNo";
        this.DiplomaNo.TabIndex = 20;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Rütbe";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 28;

        this.labelDiplomaNo = new TTVisual.TTLabel();
        this.labelDiplomaNo.Text = "Diploma No";
        this.labelDiplomaNo.ForeColor = "#000000";
        this.labelDiplomaNo.Name = "labelDiplomaNo";
        this.labelDiplomaNo.TabIndex = 14;

        this.PhoneNumber = new TTVisual.TTTextBox();
        this.PhoneNumber.Name = "PhoneNumber";
        this.PhoneNumber.TabIndex = 22;

        this.labelSex = new TTVisual.TTLabel();
        this.labelSex.Text = "Cinsiyet";
        this.labelSex.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSex.ForeColor = "#000000";
        this.labelSex.Name = "labelSex";
        this.labelSex.TabIndex = 10;

        this.DateOfLeave = new TTVisual.TTDateTimePicker();
        this.DateOfLeave.Format = DateTimePickerFormat.Short;
        this.DateOfLeave.Name = "DateOfLeave";
        this.DateOfLeave.TabIndex = 17;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Doğum İlçesi";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 35;

        this.labelVillageOfRegistry = new TTVisual.TTLabel();
        this.labelVillageOfRegistry.Text = "Kayıtlı Olduğu Mahalle/Köy";
        this.labelVillageOfRegistry.ForeColor = "#000000";
        this.labelVillageOfRegistry.Name = "labelVillageOfRegistry";
        this.labelVillageOfRegistry.TabIndex = 44;

        this.UserType = new TTVisual.TTEnumComboBox();
        this.UserType.DataTypeName = "UserTypeEnum";
        this.UserType.Name = "UserType";
        this.UserType.TabIndex = 1;

        this.DateOfJoin = new TTVisual.TTDateTimePicker();
        this.DateOfJoin.Format = DateTimePickerFormat.Short;
        this.DateOfJoin.Name = "DateOfJoin";
        this.DateOfJoin.TabIndex = 16;

        this.TownOfBirth = new TTVisual.TTObjectListBox();
        this.TownOfBirth.ListDefName = "TownListDefinition";
        this.TownOfBirth.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TownOfBirth.Name = "TownOfBirth";
        this.TownOfBirth.TabIndex = 10;

        this.VillageOfRegistry = new TTVisual.TTTextBox();
        this.VillageOfRegistry.Name = "VillageOfRegistry";
        this.VillageOfRegistry.TabIndex = 14;

        this.Active = new TTVisual.TTCheckBox();
        this.Active.Value = true;
        this.Active.Text = "Aktif";
        this.Active.Title = "Aktif";
        this.Active.Name = "Active";
        this.Active.TabIndex = 30;

        this.CountryOfBirth = new TTVisual.TTObjectListBox();
        this.CountryOfBirth.ListDefName = "CountryListDefinition";
        this.CountryOfBirth.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CountryOfBirth.Name = "CountryOfBirth";
        this.CountryOfBirth.TabIndex = 8;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = "Ülke";
        this.ttlabel13.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel13.ForeColor = "#000000";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 29;

        this.Name = new TTVisual.TTTextBox();
        this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Name.Name = "Name";
        this.Name.TabIndex = 3;

        this.labelName = new TTVisual.TTLabel();
        this.labelName.Text = "Ad";
        this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelName.ForeColor = "#000000";
        this.labelName.Name = "labelName";
        this.labelName.TabIndex = 18;

        this.Surname = new TTVisual.TTTextBox();
        this.Surname.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Surname.Name = "Surname";
        this.Surname.TabIndex = 4;

        this.labelBirthDate = new TTVisual.TTLabel();
        this.labelBirthDate.Text = "Doğum Tarihi";
        this.labelBirthDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelBirthDate.ForeColor = "#000000";
        this.labelBirthDate.Name = "labelBirthDate";
        this.labelBirthDate.TabIndex = 22;

        this.BirthDate = new TTVisual.TTDateTimePicker();
        this.BirthDate.CustomFormat = "";
        this.BirthDate.Format = DateTimePickerFormat.Long;
        this.BirthDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BirthDate.Name = "BirthDate";
        this.BirthDate.TabIndex = 7;

        //this.BirthDate = new TTVisual.TTDateTimePicker();
        ////this.BirthDate.Required = true;
        //this.BirthDate.BackColor = "#FFE3C6";
        //this.BirthDate.Format = DateTimePickerFormat.Long;
        //this.BirthDate.Name = "BirthDate";

        this.labelSurname = new TTVisual.TTLabel();
        this.labelSurname.Text = "Soyad";
        this.labelSurname.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSurname.ForeColor = "#000000";
        this.labelSurname.Name = "labelSurname";
        this.labelSurname.TabIndex = 12;

        this.UniqueRefNo = new TTVisual.TTTextBox();
        this.UniqueRefNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.UniqueRefNo.Name = "UniqueRefNo";
        this.UniqueRefNo.TabIndex = 0;

        this.CityOfRegistry = new TTVisual.TTObjectListBox();
        this.CityOfRegistry.ListDefName = "SKRSILKodlariList";
        this.CityOfRegistry.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CityOfRegistry.Name = "CityOfRegistry";
        this.CityOfRegistry.TabIndex = 12;

        this.labelFatherName = new TTVisual.TTLabel();
        this.labelFatherName.Text = "Baba Adı";
        this.labelFatherName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelFatherName.ForeColor = "#000000";
        this.labelFatherName.Name = "labelFatherName";
        this.labelFatherName.TabIndex = 16;

        this.labelMotherName = new TTVisual.TTLabel();
        this.labelMotherName.Text = "Anne Adı";
        this.labelMotherName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMotherName.ForeColor = "#000000";
        this.labelMotherName.Name = "labelMotherName";
        this.labelMotherName.TabIndex = 26;

        this.MotherName = new TTVisual.TTTextBox();
        this.MotherName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MotherName.Name = "MotherName";
        this.MotherName.TabIndex = 6;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Kayıtlı Olduğu  İl";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 33;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Kayıtlı Olduğu İlçe";
        this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 35;

        this.UserInfo = new TTVisual.TTTabPage();
        this.UserInfo.DisplayIndex = 1;
        this.UserInfo.TabIndex = 1;
        this.UserInfo.Text = "Görev Bilgileri";
        this.UserInfo.Name = "UserInfo";

        this.ResUserUsableStores = new TTVisual.TTGrid();
        this.ResUserUsableStores.Name = "ResUserUsableStores";
        this.ResUserUsableStores.TabIndex = 30;

        this.StoreResUserUsableStore = new TTVisual.TTListBoxColumn();
        this.StoreResUserUsableStore.ListDefName = "SubStoreList";
        this.StoreResUserUsableStore.DataMember = "Store";
        this.StoreResUserUsableStore.DisplayIndex = 0;
        this.StoreResUserUsableStore.HeaderText = "Kullanabileceği Depolar";
        this.StoreResUserUsableStore.Name = "StoreResUserUsableStore";
        this.StoreResUserUsableStore.Width = 600;

        this.labelWork = new TTVisual.TTLabel();
        this.labelWork.Text = "Görevi";
        this.labelWork.BackColor = "#DCDCDC";
        this.labelWork.ForeColor = "#000000";
        this.labelWork.Name = "labelWork";
        this.labelWork.TabIndex = 27;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ListDefName = "SubStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 2;

        this.UserResources = new TTVisual.TTGrid();
        this.UserResources.BackColor = "#DCDCDC";
        this.UserResources.Text = "Mesleği";
        this.UserResources.Name = "UserResources";
        this.UserResources.TabIndex = 3;

        this.SecMasterDepartment = new TTVisual.TTListBoxColumn();
        this.SecMasterDepartment.AllowMultiSelect = true;
        this.SecMasterDepartment.ListDefName = "ResourceListDefinition";
        this.SecMasterDepartment.DataMember = "Resource";
        this.SecMasterDepartment.DisplayIndex = 0;
        this.SecMasterDepartment.HeaderText = "Bağlı Olduğu Birimler";
        this.SecMasterDepartment.Name = "SecMasterDepartment";
        this.SecMasterDepartment.Width = 690;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = "Deposu";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 21;

        this.labelWorkPlace = new TTVisual.TTLabel();
        this.labelWorkPlace.Text = "Görev Yeri";
        this.labelWorkPlace.BackColor = "#DCDCDC";
        this.labelWorkPlace.ForeColor = "#000000";
        this.labelWorkPlace.Name = "labelWorkPlace";
        this.labelWorkPlace.TabIndex = 29;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 0;

        this.WorkPlace = new TTVisual.TTTextBox();
        this.WorkPlace.Name = "WorkPlace";
        this.WorkPlace.TabIndex = 1;

        this.ResUserPatientGroupTab = new TTVisual.TTTabPage();
        this.ResUserPatientGroupTab.DisplayIndex = 2;
        this.ResUserPatientGroupTab.TabIndex = 2;
        this.ResUserPatientGroupTab.Text = "Hasta Grupları";
        this.ResUserPatientGroupTab.Name = "ResUserPatientGroupTab";

        this.lblResUserPatientGroupMatch = new TTVisual.TTLabel();
        this.lblResUserPatientGroupMatch.Text = "Doktorun Atanabildiği Hasta Grupları";
        this.lblResUserPatientGroupMatch.Name = "lblResUserPatientGroupMatch";
        this.lblResUserPatientGroupMatch.TabIndex = 1;

        this.ResUserPatientGroupMatches = new TTVisual.TTGrid();
        this.ResUserPatientGroupMatches.Name = "ResUserPatientGroupMatches";
        this.ResUserPatientGroupMatches.TabIndex = 0;

        this.PatientGroupResUserPatientGroupMatch = new TTVisual.TTListBoxColumn();
        this.PatientGroupResUserPatientGroupMatch.ListDefName = "PatientGroupList";
        this.PatientGroupResUserPatientGroupMatch.DataMember = "PatientGroup";
        this.PatientGroupResUserPatientGroupMatch.DisplayIndex = 0;
        this.PatientGroupResUserPatientGroupMatch.HeaderText = "Hasta Grubu";
        this.PatientGroupResUserPatientGroupMatch.Name = "PatientGroupResUserPatientGroupMatch";
        this.PatientGroupResUserPatientGroupMatch.Width = 300;

        this.IsAssignableResUserPatientGroupMatch = new TTVisual.TTCheckBoxColumn();
        this.IsAssignableResUserPatientGroupMatch.DataMember = "IsAssignable";
        this.IsAssignableResUserPatientGroupMatch.DisplayIndex = 1;
        this.IsAssignableResUserPatientGroupMatch.HeaderText = "Atanır\Atanmaz";
        this.IsAssignableResUserPatientGroupMatch.Name = "IsAssignableResUserPatientGroupMatch";
        this.IsAssignableResUserPatientGroupMatch.Width = 90;

        this.ResourceSpecialitiesColumns = [this.MainSpeciality, this.Speciality];
        this.ResUserUsableStoresColumns = [this.StoreResUserUsableStore];
        this.UserResourcesColumns = [this.SecMasterDepartment];
        this.ResUserPatientGroupMatchesColumns = [this.PatientGroupResUserPatientGroupMatch, this.IsAssignableResUserPatientGroupMatch];
        this.tttabcontrol1.Controls = [this.PatientInfo, this.UserInfo, this.ResUserPatientGroupTab];
        this.PatientInfo.Controls = [this.labelKPSPassword, this.KPSPassword, this.labelKPSUserName, this.KPSUserName, this.TownOfRegistryPerson, this.SexPerson, this.labelBirthPlacePerson, this.BirthPlacePerson, this.labelPreDischargeLimit, this.PreDischargeLimit, this.labelMkysUserName, this.MkysUserName, this.labelMkysPassword, this.MkysPassword, this.chkTakesPerformanceScore, this.chkIsClinician, this.UsesESignature, this.SentToMHRS, this.labelErecetePassword, this.ErecetePassword, this.ttlabel8, this.FatherName, this.tttextbox1, this.TescilNo, this.ttlabel7, this.lblUserName, this.ttlabel2, this.txtUserName, this.UserTitle, this.ResourceSpecialities, this.labelEmploymentRecordID, this.labelDateOfJoin, this.labelTitle, this.labelUserType, this.EmploymentRecordID, this.labelDateOfLeave, this.labelPhoneNumber, this.labelUniqueRefNo, this.DiplomaNo, this.ttlabel1, this.labelDiplomaNo, this.PhoneNumber, this.labelSex, this.DateOfLeave, this.ttlabel4, this.labelVillageOfRegistry, this.UserType, this.DateOfJoin, this.TownOfBirth, this.VillageOfRegistry, this.Active, this.CountryOfBirth, this.ttlabel13, this.Name, this.labelName, this.Surname, this.labelBirthDate, this.BirthDate, this.labelSurname, this.UniqueRefNo, this.CityOfRegistry, this.labelFatherName, this.labelMotherName, this.MotherName, this.ttlabel3, this.ttlabel6];
        this.UserInfo.Controls = [this.ResUserUsableStores, this.labelWork, this.Store, this.UserResources, this.labelStore, this.labelWorkPlace, this.tttextbox3, this.WorkPlace];
        this.ResUserPatientGroupTab.Controls = [this.lblResUserPatientGroupMatch, this.ResUserPatientGroupMatches];
        this.Controls = [this.tttabcontrol1, this.PatientInfo, this.labelKPSPassword, this.KPSPassword, this.labelKPSUserName, this.KPSUserName, this.TownOfRegistryPerson, this.SexPerson, this.labelBirthPlacePerson, this.BirthPlacePerson, this.labelPreDischargeLimit, this.PreDischargeLimit, this.labelMkysUserName, this.MkysUserName, this.labelMkysPassword, this.MkysPassword, this.chkTakesPerformanceScore, this.chkIsClinician, this.UsesESignature, this.SentToMHRS, this.labelErecetePassword, this.ErecetePassword, this.ttlabel8, this.FatherName, this.tttextbox1, this.TescilNo, this.ttlabel7, this.lblUserName, this.ttlabel2, this.txtUserName, this.UserTitle, this.ResourceSpecialities, this.MainSpeciality, this.Speciality, this.labelEmploymentRecordID, this.labelDateOfJoin, this.labelTitle, this.labelUserType, this.EmploymentRecordID, this.labelDateOfLeave, this.labelPhoneNumber, this.labelUniqueRefNo, this.DiplomaNo, this.ttlabel1, this.labelDiplomaNo, this.PhoneNumber, this.labelSex, this.DateOfLeave, this.ttlabel4, this.labelVillageOfRegistry, this.UserType, this.DateOfJoin, this.TownOfBirth, this.VillageOfRegistry, this.Active, this.CountryOfBirth, this.ttlabel13, this.Name, this.labelName, this.Surname, this.labelBirthDate, this.BirthDate, this.labelSurname, this.UniqueRefNo, this.CityOfRegistry, this.labelFatherName, this.labelMotherName, this.MotherName, this.ttlabel3, this.ttlabel6, this.UserInfo, this.ResUserUsableStores, this.StoreResUserUsableStore, this.labelWork, this.Store, this.UserResources, this.SecMasterDepartment, this.labelStore, this.labelWorkPlace, this.tttextbox3, this.WorkPlace, this.ResUserPatientGroupTab, this.lblResUserPatientGroupMatch, this.ResUserPatientGroupMatches, this.PatientGroupResUserPatientGroupMatch, this.IsAssignableResUserPatientGroupMatch];

    }


}
