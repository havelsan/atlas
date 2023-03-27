//$16A1DC9F
import { CashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { UserOptionGroupType } from 'NebulaClient/Model/AtlasClientModel';
import { UserOptionType } from 'NebulaClient/Model/AtlasClientModel';
import { UserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

export class ResUserService {
    public static async GetUserOptionTypes(userOptionGroupType: UserOptionGroupType): Promise<Array<UserOptionType>> {
        let url: string = "/api/ResUserService/GetUserOptionTypes";
        let input = { "userOptionGroupType": userOptionGroupType };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<UserOptionType>>(url, input);
        return result;
    }
    public static async SelectCurrentUserCashOffice(cashOfficeType: CashOfficeTypeEnum, currentUser: ResUser): Promise<CashOfficeDefinition> {
        let url: string = "/api/ResUserService/SelectCurrentUserCashOffice";
        let input = { "cashOfficeType": cashOfficeType, "currentUser": currentUser };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<CashOfficeDefinition>(url, input);
        return result;
    }
    public static async GetAnaUzmanlikBrans(user: ResUser, type: string): Promise<string> {
        let url: string = "/api/ResUserService/GetAnaUzmanlikBrans";
        let input = { "user": user, "type": type };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }
    public static async HasRole(resUser: ResUser, roleID: Guid): Promise<boolean> {
        let url: string = "/api/ResUserService/HasRole";
        let input = { "resUser": resUser, "roleID": roleID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<boolean>(url, input);
        return result;
    }
    public static async GetByUserResourceAndUserType(USERTYPE: UserTypeEnum, USERRESOURCE: string): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetByUserResourceAndUserType";
        let input = { "USERTYPE": USERTYPE, "USERRESOURCE": USERRESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async OLAP_GetResDoctor(): Promise<Array<ResUser.OLAP_GetResDoctor_Class>> {
        let url: string = "/api/ResUserService/OLAP_GetResDoctor";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.OLAP_GetResDoctor_Class>>(url, input);
        return result;
    }
    public static async GetResUserByObjectID(TTOBJECTID: string): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetResUserByObjectID";
        let input = { "TTOBJECTID": TTOBJECTID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async ClinicDoctorListNQL(injectionSQL: string): Promise<Array<ResUser.ClinicDoctorListNQL_Class>> {
        let url: string = "/api/ResUserService/ClinicDoctorListNQL";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.ClinicDoctorListNQL_Class>>(url, input);
        return result;
    }
    public static async GetResUserByID(USERID: string): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetResUserByID";
        let input = { "USERID": USERID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async GetResUserByExternalID(EXTERNALID: string): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetResUserByExternalID";
        let input = { "EXTERNALID": EXTERNALID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async GetAllUser(injectionSQL: string): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetAllUser";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async OLAP_GetDoctorCount(): Promise<Array<ResUser.OLAP_GetDoctorCount_Class>> {
        let url: string = "/api/ResUserService/OLAP_GetDoctorCount";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.OLAP_GetDoctorCount_Class>>(url, input);
        return result;
    }
    public static async GetUserByID(USERID: string): Promise<Array<ResUser.GetUserByID_Class>> {
        let url: string = "/api/ResUserService/GetUserByID";
        let input = { "USERID": USERID };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.GetUserByID_Class>>(url, input);
        return result;
    }
    public static async OLAP_GetNurseCount(): Promise<Array<ResUser.OLAP_GetNurseCount_Class>> {
        let url: string = "/api/ResUserService/OLAP_GetNurseCount";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.OLAP_GetNurseCount_Class>>(url, input);
        return result;
    }
    public static async GetUserInfoNQL(USER: string): Promise<Array<ResUser.GetUserInfoNQL_Class>> {
        let url: string = "/api/ResUserService/GetUserInfoNQL";
        let input = { "USER": USER };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.GetUserInfoNQL_Class>>(url, input);
        return result;
    }
    public static async GetResUser(injectionSQL: string): Promise<Array<ResUser.GetResUser_Class>> {
        let url: string = "/api/ResUserService/GetResUser";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.GetResUser_Class>>(url, input);
        return result;
    }
    public static async GetByUserResourceAndUserTypes(USERRESOURCE: string, USERTYPE: Array<UserTypeEnum>): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetByUserResourceAndUserTypes";
        let input = { "USERRESOURCE": USERRESOURCE, "USERTYPE": USERTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async GetResUserByUserType(USERTYPE: UserTypeEnum): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetResUserByUserType";
        let input = { "USERTYPE": USERTYPE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async DoctorListNQL(injectionSQL: string): Promise<Array<ResUser.DoctorListNQL_Class>> {
        let url: string = "/api/ResUserService/DoctorListNQL";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.DoctorListNQL_Class>>(url, input);
        return result;
    }
    public static async GetResUserByUniqeRefNo(UNIQUEREFNO: string): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetResUserByUniqeRefNo";
        let input = { "UNIQUEREFNO": UNIQUEREFNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async GetResUserByUserTypeAndResource(USERTYPE: UserTypeEnum, RESOURCE: Guid): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetResUserByUserTypeAndResource";
        let input = { "USERTYPE": USERTYPE, "RESOURCE": RESOURCE };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async GetActiveResUserByUniqeRefNo(UNIQUEREFNO: string): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetActiveResUserByUniqeRefNo";
        let input = { "UNIQUEREFNO": UNIQUEREFNO };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async DoctorListObjectNQL(injectionSQL: string): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/DoctorListObjectNQL";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async GetAllUserReportNQL(injectionSQL: string): Promise<Array<ResUser.GetAllUserReportNQL_Class>> {
        let url: string = "/api/ResUserService/GetAllUserReportNQL";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.GetAllUserReportNQL_Class>>(url, input);
        return result;
    }
    public static async GetResUserByName(NAME: string, injectionSQL: string): Promise<Array<ResUser>> {
        let url: string = "/api/ResUserService/GetResUserByName";
        let input = { "NAME": NAME, "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser>>(url, input);
        return result;
    }
    public static async GetConsultationUserNQL(injectionSQL: string): Promise<Array<ResUser.GetConsultationUserNQL_Class>> {
        let url: string = "/api/ResUserService/GetConsultationUserNQL";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.GetConsultationUserNQL_Class>>(url, input);
        return result;
    }
    public static async VEM_PERSONEL(): Promise<Array<ResUser.VEM_PERSONEL_Class>> {
        let url: string = "/api/ResUserService/VEM_PERSONEL";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.VEM_PERSONEL_Class>>(url, input);
        return result;
    }
    public static async GetdoctorsForMHRS(): Promise<Array<ResUser.GetdoctorsForMHRS_Class>> {
        let url: string = "/api/ResUserService/GetdoctorsForMHRS";
        let input = {};
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.GetdoctorsForMHRS_Class>>(url, input);
        return result;
    }
    public static async SpecialistDoctorListNQL(injectionSQL: string): Promise<Array<ResUser.SpecialistDoctorListNQL_Class>> {
        let url: string = "/api/ResUserService/SpecialistDoctorListNQL";
        let input = { "injectionSQL": injectionSQL };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<ResUser.SpecialistDoctorListNQL_Class>>(url, input);
        return result;
    }
}