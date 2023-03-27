//$D5D249BD
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { UserResource } from "NebulaClient/Model/AtlasClientModel";
import { ResUserUsableStore } from "NebulaClient/Model/AtlasClientModel";
import { ResourceSpecialityGrid } from "NebulaClient/Model/AtlasClientModel";
import { Store } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { Person } from "NebulaClient/Model/AtlasClientModel";
import { SpecialityDefinition } from "NebulaClient/Model/AtlasClientModel";

import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { RoleSubTypeEnum } from "app/NebulaClient/Utils/Enums/RoleSubTypeEnum";

export class ResUserDefinitionFormViewModel extends BaseViewModel {

    @Type(() => ResUser)
    public _ResUser: ResUser = new ResUser();

    @Type(() => UserResource)
    public UserResourcesGridList: Array<UserResource> = new Array<UserResource>();
    @Type(() => ResUserUsableStore)
    public ResUserUsableStoresGridList: Array<ResUserUsableStore> = new Array<ResUserUsableStore>();

    @Type(() => ResourceSpecialityGrid)
    public ResourceSpecialitiesGridList: Array<ResourceSpecialityGrid> = new Array<ResourceSpecialityGrid>();

    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();

    @Type(() => Person)
    public Persons: Array<Person> = new Array<Person>();

    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();

    public UserLogonName: string;

    @Type(() => Guid)
    public Userid: Guid;

    @Type(() => RoleDefinitionList)
    public CurrentUserRoleList: Array<RoleDefinitionList>;

    @Type(() => RoleDefinitionList)
    public TTUserRoleList: Array<RoleDefinitionList>;
    @Type(() => RoleDefinitionList)
    public TTSystemRoleList: Array<RoleDefinitionList>;
    @Type(() => RoleDefinitionList)
    public TTCoreRoleList: Array<RoleDefinitionList>;
    @Type(() => RoleDefinitionList)
    public TTAllRoleList: Array<RoleDefinitionList>;

    @Type(() => RoleDefinitionList)
    public selectedRoleValue: Array<RoleDefinitionList>;

    public resUserTakeOffFromWork: string;//Personel izinli ya da �al���yor durumunu belirtmek i�in

    @Type(() => UserResourceInfo)
    public UserResourceInfoList: Array<UserResourceInfo> = new Array<UserResourceInfo>();
    @Type(() => UserResourceInfo)
    public ResSectionDataSource: Array<UserResourceInfo> = new Array<UserResourceInfo>();
    @Type(() => UserResourceInfo)
    public ResSectionList: Array<UserResourceInfo> = new Array<UserResourceInfo>();
}
export class RoleDefinitionList {

    @Type(() => Guid)
    public RoleId: Guid;
    public RoleName: string;
    public RoleSubTypeEnum: RoleSubTypeEnum;
}

export class UserResourceInfo {
    public RessectionName: string;
    public RessectionDefname: string;
    public RessectionDepartmentName: string;
    @Type(() => Guid)
    public RessectionId: Guid;
    @Type(() => Guid)
    public UserResourceId: Guid;
    public IsNew: boolean;
    public IsDeleted: boolean;
    @Type(() => ResSection)
    public ResSectionItem: ResSection;
}
