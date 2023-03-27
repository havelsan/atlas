//$0395BDC4
import { Component, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ResUserDefinitionFormViewModel, RoleDefinitionList, UserResourceInfo } from './ResUserDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ResUser, UserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Person } from 'NebulaClient/Model/AtlasClientModel';
import { ResourceSpecialityGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserUsableStore } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { UserResource } from 'NebulaClient/Model/AtlasClientModel';

import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { Exception } from '../../../wwwroot/app/NebulaClient/Mscorlib/Exception';
import { EntityStateEnum } from '../../../wwwroot/app/NebulaClient/Utils/Enums/EntityStateEnum';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { foreColor } from 'devexpress-dashboard/model/index.metadata';
import { forEach } from '../../../wwwroot/app/NebulaClient/System/Collections/Array/Utility';

@Component({
    selector: 'ResUserDefinitionForm',
    templateUrl: 'ResUserDefinitionForm.html',
    providers: [MessageService]
})
export class ResUserDefinitionForm extends TTVisual.TTForm implements OnInit {
    Active: TTVisual.ITTCheckBox;
    chkTakesPerformanceScore: TTVisual.ITTCheckBox;
    chkIsClinician: TTVisual.ITTCheckBox;
    EMail: TTVisual.ITTTextBox;
    labelEMail: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelPhoneNumber: TTVisual.ITTLabel;
    labelResourceSpecialities: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelSurname: TTVisual.ITTLabel;
    labelTitle: TTVisual.ITTLabel;
    labelUniqueRefNo: TTVisual.ITTLabel;
    labelUserType: TTVisual.ITTLabel;
    labelWork: TTVisual.ITTLabel;
    labelWorkPlace: TTVisual.ITTLabel;
    lblUserName: TTVisual.ITTLabel;
    MainSpeciality: TTVisual.ITTCheckBoxColumn;
    Name: TTVisual.ITTTextBox;
    PhoneNumber: TTVisual.ITTTextBox;
    ResourceSpecialities: TTVisual.ITTGrid;
    ResUserUsableStores: TTVisual.ITTGrid;
    SecMasterDepartment: TTVisual.ITTListBoxColumn;
    Speciality: TTVisual.ITTListBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    StoreResUserUsableStore: TTVisual.ITTListBoxColumn;
    Surname: TTVisual.ITTTextBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    Work: TTVisual.ITTTextBox;
    txtUserName: TTVisual.ITTTextBox;
    UniqueRefNo: TTVisual.ITTTextBox;
    UserResources: TTVisual.ITTGrid;
    UserTitle: TTVisual.ITTEnumComboBox;
    UserType: TTVisual.ITTEnumComboBox;
    WorkPlace: TTVisual.ITTTextBox;
    public ResourceSpecialitiesColumns = [];
    public ResUserUsableStoresColumns = [];
    public UserResourcesColumns = [];
    public resUserDefinitionFormViewModel: ResUserDefinitionFormViewModel = new ResUserDefinitionFormViewModel();
    public get _ResUser(): ResUser {
        return this._TTObject as ResUser;
    }
    private ResUserDefinitionForm_DocumentUrl: string = '/api/ResUserService/ResUserDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('RESUSER', 'ResUserDefinitionForm');
        this._DocumentServiceUrl = this.ResUserDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

        this.RoleSubTypeList = [
            "Tüm Tipler",
            "Kullanıcı",
            "Sistem",
            "Çekirdek"
        ];
        this.RoleSubType = this.RoleSubTypeList[1];
    }


    // ***** Method declarations start *****

    gridRoleDataSource: any;

    RoleSubTypeList: string[];
    RoleSubType: string;

    protected async PreScript(): Promise<void> {
        super.PreScript();
        if (this._ResUser.Person == null) {
            let person: Person = new Person(this._ResUser.ObjectContext);
            this._ResUser.Person = person;
        }
        if (this.resUserDefinitionFormViewModel.TTUserRoleList != null) {
            this.gridRoleDataSource = this.resUserDefinitionFormViewModel.TTUserRoleList;
        }
        this.filteredUserResourceInfoList = this.resUserDefinitionFormViewModel.UserResourceInfoList;
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);
        if (this._ResUser.UserResources.filter(c => c.Resource == null && c.EntityState != EntityStateEnum.Deleted).length > 0) {
            throw new Exception("Birim seçimi yapmadan kayıt edemezsiniz!");
        }
    }

    //Şifre Sıfırlama işlemleri
    public async passwordReset() {
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Vazgeç", "E,V", i18n("M23735", "Uyarı"), "Şifre Sıfırlama", "Kullanıcının şifresi sıfırlanacaktır! \r\n\r\n Devam etmek istiyor musunuz?");
        if (messageResult === "E") {
            await this.httpService.get("api/ResUserService/PasswordReset?Userid=" + this.resUserDefinitionFormViewModel.Userid).then(response => {
                ServiceLocator.MessageService.showSuccess("Şifre Başarılı Şekilde Sıfırlanmıştır.");
            }).catch(error => {
                ServiceLocator.MessageService.showError("Şifre Sıfırlama İşlemi Gerçekleştirilemedi!" + error);
            });
        } else {
            ServiceLocator.MessageService.showInfo(i18n("M14753", "Şifre Sıfırlama İşleminden Vazgeçildi"));
        }
    }

    //Rol tipleri listesi
    public onRoleSubTypeListChanged() {
        if (this.RoleSubType == "Tüm Tipler") {
            if (this.resUserDefinitionFormViewModel.TTAllRoleList != null) {
                this.gridRoleDataSource = this.resUserDefinitionFormViewModel.TTAllRoleList;
                this.resUserDefinitionFormViewModel.selectedRoleValue = new Array<RoleDefinitionList>();
            }
        }

        if (this.RoleSubType == "Kullanıcı") {
            if (this.resUserDefinitionFormViewModel.TTUserRoleList != null) {
                this.gridRoleDataSource = this.resUserDefinitionFormViewModel.TTUserRoleList;
                this.resUserDefinitionFormViewModel.selectedRoleValue = new Array<RoleDefinitionList>();
            }
        }

        if (this.RoleSubType == "Sistem") {
            if (this.resUserDefinitionFormViewModel.TTSystemRoleList != null) {
                this.gridRoleDataSource = this.resUserDefinitionFormViewModel.TTSystemRoleList;
                this.resUserDefinitionFormViewModel.selectedRoleValue = new Array<RoleDefinitionList>();
            }
        }

        if (this.RoleSubType == "Çekirdek") {
            if (this.resUserDefinitionFormViewModel.TTCoreRoleList != null) {
                this.gridRoleDataSource = this.resUserDefinitionFormViewModel.TTCoreRoleList;
                this.resUserDefinitionFormViewModel.selectedRoleValue = new Array<RoleDefinitionList>();
            }
        }
    }

    //Rol ekleme
    public async AddUserRole() {
        if (this.resUserDefinitionFormViewModel.selectedRoleValue == null || this.resUserDefinitionFormViewModel.selectedRoleValue.length == 0) {
            this.messageService.showReponseError(i18n("M16878", "Rol seçilmediği için rol atama işlemine devam edilemedi."));
        } else {

            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Vazgeç", "E,V", i18n("M23735", "Uyarı"), "Rol Atama", "Seçili roller kullanıcıya tanımlanacaktır! \r\n\r\n Devam etmek istiyor musunuz?");
            if (messageResult === "E") {

                await this.httpService.post<any>("api/ResUserService/AddCurrentUserRole", this.resUserDefinitionFormViewModel)
                    .then(response => {
                        let result: ResUserDefinitionFormViewModel = <ResUserDefinitionFormViewModel>response;

                        this.resUserDefinitionFormViewModel.TTAllRoleList = result.TTAllRoleList;
                        this.resUserDefinitionFormViewModel.TTUserRoleList = result.TTUserRoleList;
                        this.resUserDefinitionFormViewModel.TTSystemRoleList = result.TTSystemRoleList;
                        this.resUserDefinitionFormViewModel.TTCoreRoleList = result.TTCoreRoleList;

                        this.onRoleSubTypeListChanged();

                        ServiceLocator.MessageService.showSuccess("Rol Atama İşlemi Başarılı Şekilde Gerçekleştirildi.");
                    }).catch(error => {
                        ServiceLocator.MessageService.showError("Rol Atama İşlemi Gerçekleştirilemedi!" + error);
                    });

            } else {
                ServiceLocator.MessageService.showInfo(i18n("M14753", "Rol Atama İşleminden Vazgeçildi"));
            }
        }
    }


    //region birim yetkileri
    showResSectionPopup: boolean = false;
    //selectedResSectionList: Array<ResSection> = new Array<ResSection>();
    public filteredUserResourceInfoList: Array<UserResourceInfo> = new Array<UserResourceInfo>();

    public btnOpenResSectionPopup() {
        this.showResSectionPopup = true;
    }

    public saveResSection() {
        this.showResSectionPopup = false;
        for (let item of this.resUserDefinitionFormViewModel.ResSectionList) {
            let info: UserResourceInfo = new UserResourceInfo();
            //if (this.resUserDefinitionFormViewModel.ResSectionList == null) {
            //    this.resUserDefinitionFormViewModel.ResSectionList = new Array<ResSection>();
            //}
            info.RessectionName = item.RessectionName;
            info.RessectionDefname = item.RessectionDefname;
            info.RessectionDepartmentName = item.RessectionDepartmentName;
            info.RessectionId = item.RessectionId;
            info.IsNew = true;
            info.IsDeleted = false;
            info.ResSectionItem = item.ResSectionItem;
            this.resUserDefinitionFormViewModel.UserResourceInfoList.push(info);
            //this.resUserDefinitionFormViewModel.ResSectionList.push(item);
        }
        this.resUserDefinitionFormViewModel.ResSectionList = null;
        this.filteredUserResourceInfoList = this.resUserDefinitionFormViewModel.UserResourceInfoList.filter(c => c.IsDeleted != true);
    }

    public cancelResSection() {
        this.showResSectionPopup = false;
        this.resUserDefinitionFormViewModel.ResSectionList = null;
        this.filteredUserResourceInfoList = this.resUserDefinitionFormViewModel.UserResourceInfoList.filter(c => c.IsDeleted != true);
    }

    async UserResourceInfoDelete(data: any) {
        if (data.column.name = "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "Birim Yetkisi Silme", "<b>'" + data.row.key.RessectionName + "'</b>  isimli birim yetkisi silinecektir! \r\n\r\n Devam etmek istiyor musunuz?");
                    if (messageResult === "E") {
                        if (data.row.key.IsNew == true) {
                            const index = this.resUserDefinitionFormViewModel.UserResourceInfoList.indexOf(data.row.key, 0);
                            if (index > -1) {
                                this.resUserDefinitionFormViewModel.UserResourceInfoList.splice(index, 1);
                            }
                            this.filteredUserResourceInfoList = this.resUserDefinitionFormViewModel.UserResourceInfoList.filter(c => c.IsDeleted != true);
                        } else {
                            data.row.key.IsDeleted = true;
                            this.filteredUserResourceInfoList = this.resUserDefinitionFormViewModel.UserResourceInfoList.filter(c => c.IsDeleted != true);
                        }

                    } else {
                        let d = 3;
                    }
                }
            }
        }
    }
    //endregion

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ResUser();
        this.resUserDefinitionFormViewModel = new ResUserDefinitionFormViewModel();
        this._ViewModel = this.resUserDefinitionFormViewModel;
        this.resUserDefinitionFormViewModel._ResUser = this._TTObject as ResUser;
        this.resUserDefinitionFormViewModel._ResUser.Store = new Store();
        this.resUserDefinitionFormViewModel._ResUser.UserResources = new Array<UserResource>();
        this.resUserDefinitionFormViewModel._ResUser.ResUserUsableStores = new Array<ResUserUsableStore>();
        this.resUserDefinitionFormViewModel._ResUser.Person = new Person();
        this.resUserDefinitionFormViewModel._ResUser.ResourceSpecialities = new Array<ResourceSpecialityGrid>();
    }

    protected loadViewModel() {
        let that = this;
        that.resUserDefinitionFormViewModel = this._ViewModel as ResUserDefinitionFormViewModel;
        that._TTObject = this.resUserDefinitionFormViewModel._ResUser;
        if (this.resUserDefinitionFormViewModel == null)
            this.resUserDefinitionFormViewModel = new ResUserDefinitionFormViewModel();
        if (this.resUserDefinitionFormViewModel._ResUser == null)
            this.resUserDefinitionFormViewModel._ResUser = new ResUser();
        let storeObjectID = that.resUserDefinitionFormViewModel._ResUser["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.resUserDefinitionFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.resUserDefinitionFormViewModel._ResUser.Store = store;
            }
        }

        that.resUserDefinitionFormViewModel._ResUser.UserResources = that.resUserDefinitionFormViewModel.UserResourcesGridList;
        for (let detailItem of that.resUserDefinitionFormViewModel.UserResourcesGridList) {
            let resourceObjectID = detailItem["Resource"];
            if (resourceObjectID != null && (typeof resourceObjectID === "string")) {
                let resource = that.resUserDefinitionFormViewModel.ResSections.find(o => o.ObjectID.toString() === resourceObjectID.toString());
                if (resource) {
                    detailItem.Resource = resource;
                }
            }

        }
        that.resUserDefinitionFormViewModel._ResUser.ResUserUsableStores = that.resUserDefinitionFormViewModel.ResUserUsableStoresGridList;
        for (let detailItem of that.resUserDefinitionFormViewModel.ResUserUsableStoresGridList) {
            let storeObjectID = detailItem["Store"];
            if (storeObjectID != null && (typeof storeObjectID === "string")) {
                let store = that.resUserDefinitionFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                if (store) {
                    detailItem.Store = store;
                }
            }

        }
        let personObjectID = that.resUserDefinitionFormViewModel._ResUser["Person"];
        if (personObjectID != null && (typeof personObjectID === "string")) {
            let person = that.resUserDefinitionFormViewModel.Persons.find(o => o.ObjectID.toString() === personObjectID.toString());
            if (person) {
                that.resUserDefinitionFormViewModel._ResUser.Person = person;
            }
        }

        that.resUserDefinitionFormViewModel._ResUser.ResourceSpecialities = that.resUserDefinitionFormViewModel.ResourceSpecialitiesGridList;
        for (let detailItem of that.resUserDefinitionFormViewModel.ResourceSpecialitiesGridList) {
            let specialityObjectID = detailItem["Speciality"];
            if (specialityObjectID != null && (typeof specialityObjectID === "string")) {
                let speciality = that.resUserDefinitionFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === specialityObjectID.toString());
                if (speciality) {
                    detailItem.Speciality = speciality;
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

    public onEMailChanged(event): void {
        if (this._ResUser != null && this._ResUser.EMail != event) {
            this._ResUser.EMail = event;
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

    public onWorkChanged(event): void {
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

    public onWorkPlaceChanged(event): void {
        if (this._ResUser != null && this._ResUser.WorkPlace != event) {
            this._ResUser.WorkPlace = event;
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.UniqueRefNo, "Text", this.__ttObject, "Person.UniqueRefNo");
        redirectProperty(this.Active, "Value", this.__ttObject, "ISACTIVE");
        redirectProperty(this.Name, "Text", this.__ttObject, "Person.Name");
        redirectProperty(this.chkTakesPerformanceScore, "Value", this.__ttObject, "TakesPerformanceScore");
        redirectProperty(this.chkIsClinician, "Value", this.__ttObject, "IsClinician");
        redirectProperty(this.Surname, "Text", this.__ttObject, "Person.Surname");
        redirectProperty(this.PhoneNumber, "Text", this.__ttObject, "PhoneNumber");
        redirectProperty(this.UserType, "Value", this.__ttObject, "UserType");
        redirectProperty(this.EMail, "Text", this.__ttObject, "EMail");
        redirectProperty(this.UserTitle, "Value", this.__ttObject, "Title");
        redirectProperty(this.Work, "Text", this.__ttObject, "Work");
        redirectProperty(this.WorkPlace, "Text", this.__ttObject, "WorkPlace");
    }

    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = "Görev Bilgileri";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 74;

        this.WorkPlace = new TTVisual.TTTextBox();
        this.WorkPlace.Name = "WorkPlace";
        this.WorkPlace.TabIndex = 1;

        this.Work = new TTVisual.TTTextBox();
        this.Work.Name = "Work";
        this.Work.TabIndex = 0;

        this.labelWorkPlace = new TTVisual.TTLabel();
        this.labelWorkPlace.Text = "Görev Yeri";
        this.labelWorkPlace.BackColor = "#DCDCDC";
        this.labelWorkPlace.ForeColor = "#000000";
        this.labelWorkPlace.Name = "labelWorkPlace";
        this.labelWorkPlace.TabIndex = 29;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = "Deposu";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 21;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ListDefName = "SubStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 2;

        this.labelWork = new TTVisual.TTLabel();
        this.labelWork.Text = "Görevi";
        this.labelWork.BackColor = "#DCDCDC";
        this.labelWork.ForeColor = "#000000";
        this.labelWork.Name = "labelWork";
        this.labelWork.TabIndex = 27;

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

        this.labelEMail = new TTVisual.TTLabel();
        this.labelEMail.Text = "E-Posta";
        this.labelEMail.Name = "labelEMail";
        this.labelEMail.TabIndex = 73;

        this.EMail = new TTVisual.TTTextBox();
        this.EMail.Name = "EMail";
        this.EMail.TabIndex = 72;

        this.txtUserName = new TTVisual.TTTextBox();
        this.txtUserName.BackColor = "#F0F0F0";
        this.txtUserName.ReadOnly = true;
        this.txtUserName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.txtUserName.Name = "txtUserName";
        this.txtUserName.TabIndex = 6;

        this.PhoneNumber = new TTVisual.TTTextBox();
        this.PhoneNumber.Name = "PhoneNumber";
        this.PhoneNumber.TabIndex = 22;

        this.Name = new TTVisual.TTTextBox();
        this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Name.Name = "Name";
        this.Name.TabIndex = 3;

        this.Surname = new TTVisual.TTTextBox();
        this.Surname.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Surname.Name = "Surname";
        this.Surname.TabIndex = 4;

        this.UniqueRefNo = new TTVisual.TTTextBox();
        this.UniqueRefNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.UniqueRefNo.Name = "UniqueRefNo";
        this.UniqueRefNo.TabIndex = 0;

        this.lblUserName = new TTVisual.TTLabel();
        this.lblUserName.Text = "Kullanıcı Adı";
        this.lblUserName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblUserName.ForeColor = "#000000";
        this.lblUserName.Name = "lblUserName";
        this.lblUserName.TabIndex = 26;

        this.UserTitle = new TTVisual.TTEnumComboBox();
        this.UserTitle.DataTypeName = "UserTitleEnum";
        this.UserTitle.Name = "UserTitle";
        this.UserTitle.TabIndex = 1;

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

        this.UserType = new TTVisual.TTEnumComboBox();
        this.UserType.DataTypeName = "UserTypeEnum";
        this.UserType.Name = "UserType";
        this.UserType.TabIndex = 1;

        this.Active = new TTVisual.TTCheckBox();
        this.Active.Value = true;
        this.Active.Text = "Aktif";
        this.Active.Title = "Aktif";
        this.Active.Name = "Active";
        this.Active.TabIndex = 30;

        this.labelName = new TTVisual.TTLabel();
        this.labelName.Text = "Ad";
        this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelName.ForeColor = "#000000";
        this.labelName.Name = "labelName";
        this.labelName.TabIndex = 18;

        this.labelSurname = new TTVisual.TTLabel();
        this.labelSurname.Text = "Soyad";
        this.labelSurname.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSurname.ForeColor = "#000000";
        this.labelSurname.Name = "labelSurname";
        this.labelSurname.TabIndex = 12;

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

        this.labelResourceSpecialities = new TTVisual.TTLabel();
        this.labelResourceSpecialities.Text = "Branş";
        this.labelResourceSpecialities.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelResourceSpecialities.ForeColor = "#000000";
        this.labelResourceSpecialities.Name = "labelResourceSpecialities";
        this.labelResourceSpecialities.TabIndex = 20;

        this.UserResourcesColumns = [this.SecMasterDepartment];
        this.ResUserUsableStoresColumns = [this.StoreResUserUsableStore];
        this.ResourceSpecialitiesColumns = [this.MainSpeciality, this.Speciality];
        this.ttgroupbox1.Controls = [this.WorkPlace, this.Work, this.labelWorkPlace, this.labelStore, this.Store, this.labelWork, this.UserResources, this.ResUserUsableStores];
        this.Controls = [this.ttgroupbox1, this.WorkPlace, this.Work, this.labelWorkPlace, this.labelStore, this.Store, this.labelWork, this.UserResources, this.SecMasterDepartment, this.ResUserUsableStores, this.StoreResUserUsableStore, this.labelEMail, this.EMail, this.txtUserName, this.PhoneNumber, this.Name, this.Surname, this.UniqueRefNo, this.lblUserName, this.UserTitle, this.labelTitle, this.labelUserType, this.labelPhoneNumber, this.labelUniqueRefNo, this.UserType, this.Active, this.labelName, this.labelSurname, this.chkTakesPerformanceScore, this.chkIsClinician, this.ResourceSpecialities, this.MainSpeciality, this.Speciality, this.labelResourceSpecialities];

    }


}