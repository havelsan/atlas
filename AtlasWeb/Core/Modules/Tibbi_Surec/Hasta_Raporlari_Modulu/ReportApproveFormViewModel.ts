import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { ExaminationWorkListItem } from '../Tibbi_Surec_Is_Listeleri/Ayaktan_Hasta_Is_Listesi/ExaminationWorkListViewModel';

export class ReportApproveListItem extends ExaminationWorkListItem {
    public ItemType: string;
    public currentStateText: string;
    public currentStateID: number;
    public secondDoctorName: string;
    public secondDoctorUniqueRefNo: string;
    public secondDoctorApprovalStatus: boolean;
    public thirdDoctorName: string;
    public thirdDoctorUniqueRefNo: string;
    public thirdDoctorApprovalStatus: boolean;
    public disapprovedUsers: string;
    public procedureDoctorUniqueRefNo: string;
}

export class ReportApproveListSearchCriteria {
    public startDate: Date;
    public endDate: Date;
}

export class SendReportApproveModel {
    @Type(() => Guid)
    public reportObjectID: Guid;
    public medulaUsername: string;
    public medulaPassword: string;
    public signContent: string;
    public isSecondDoctorApprove: boolean = false;
    public isThirdDoctorApprove: boolean = false;
}

export class UserPropertiesModel {
    public UniqueRefNo: string;
    public hasRoleToSeeAllButtons: boolean;
}