import { Type } from 'NebulaClient/ClassTransformer';

export class ArchiveDeliveryFormViewModel {
    public SubepisodeID: string;
    @Type(() => FolderContent)
    public FolderContentList: Array<FolderContent>;
    @Type(() => UserObject)
    public DeliverUserList: Array<UserObject>;
    @Type(() => UserObject)
    public RecipientUserList: Array<UserObject>;
    public Description: string;
    @Type(() => Boolean)
    public IsNew: boolean;
    public ObjectID: string;
    public PatientNameSurname: string;
    public ProtocolNo: string;
    public ClinicName: string;
    public RoomNumber: string;
    public BedNumber: string;
    public DoctorName: string;
    public ClinicDate: string;
    public DischargeDate: string;
    public SelectedDelivererUserID: string;
    public SelectedRecipientUserID: string;
}

export class FolderContent {
    @Type(() => Boolean)
    public IsSelected: boolean;
    public ContentName: string;
    public PageNumber: string;
    public ContentDefObjectID: string;
    public ObjectID: string;
}
export class UserObject {
    public ObjectID: string;
    public Name: string;
}