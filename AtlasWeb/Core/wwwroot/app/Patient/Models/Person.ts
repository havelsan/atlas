import { SexEnum } from "./SexEnum";
import { MaritalStatusEnum } from "./MaritalStatusEnum";
import { TTObject } from "../../Fw/TTObject";

export class Person extends TTObject {
    public OtherBirthPlace: string;
    public IdentificationSeriesNo: string;
    public MotherName: string;
    public FamilyNo: string;
    public Surname: string;
    public Name: string;
    public FatherName: string;
    public VillageOfRegistry: string;
    public IdentificationCardNo: string;
    public Sex: SexEnum;
    public NameIsUpdated: boolean;
    public IdentificationVolumeNo: string;
    public SurnameIsUpdated: boolean;
    public BDYearOnly: boolean;
    public IdentificationCardSerialNo: string;
    public MaritalStatus: MaritalStatusEnum;
    public ForeignUniqueRefNo: number;
    public BirthDate: Date;
    public ExDate: Date;
    public UniqueRefNo: number;
}
