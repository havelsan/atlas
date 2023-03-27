import { listboxObject } from "app/Invoice/InvoiceHelperModel";
import { EnumItem } from "app/NebulaClient/Mscorlib/EnumItem";
import { IEnumList } from "app/NebulaClient/Mscorlib/IEnumList";
import { ClassType } from "app/NebulaClient/ClassTransformer";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { City, SpecialityDefinition } from "app/NebulaClient/Model/AtlasClientModel";


export class SMSFormViewModel {
    public SKRSIlDataSource: Array<any> = new Array<any>();
    public ProvizyonTipiDataSource: Array<any> = new Array<any>();
    public IstisnaiHalDataSource: Array<any> = new Array<any>();
    public TedaviTuruDataSource: Array<any> = new Array<any>();
    public SpecialityDefDataSource: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
}

//#region SMS Personel Modeli
export class SMSPersonnelSearchModel {
    public FirstName: string;
    public SurName: string;
    public WorkStatus?: number = null;
    public Gender?: number = null;
    public BirthDate?: Date = null;
    public Title?: number = null;
    public HasPhoneNumber?: boolean = true;
    public SelectedOccupations?: Array<number> = new Array<number>();
    public SelectedCitiesObjectIDs: Array<Guid> = new Array<Guid>();
    public SelectedResourcesObjectIDs: Array<Guid> = new Array<Guid>();
    public SelectedSpecialityObjectIDs: Array<Guid> = new Array<Guid>();
}

export class SMSPersonnelFormViewModel {
    public PersonnelSearcModel: SMSPersonnelSearchModel = new SMSPersonnelSearchModel();
    public GridViewModel: Array<SMSPersonnelGridViewModel> = new Array<SMSPersonnelGridViewModel>();
    public SMSText: string;
}

export class SMSPersonnelGridViewModel {
    public ObjectID: Guid;
    public Name: string;
    public SurName: string;
    public Phone: string;
    //Çalışma Durumu
    public WorkStatus: string;
    //ResUser daki Work alanı (Görevi)
    public Position: string;
}
//#endregion


//#region Hasta SMS Modeli
export class SMSPatientSearchModel {
    public FirstName: string;
    public SurName: string;
    public Gender?: number = null;
    public BirthDate?: Date = null;
    public HasPhoneNumber?: boolean = true;
    //Doğum yeri şehir
    public SelectedCityOfBirthPlace?: Guid;
    // Doğum yeri İlçesi
    public SelectedCountyOfBirthPlace?: Guid;
    //Adres İl
    public SelectedCityOfAddress?: Guid;
    //Adres İlçe
    public SelectedCountyOfAddress?: Guid;
    //Uyruk
    public Nationality?: Guid;
    //Kurum
    public SelectedPayers: Array<Guid>;
    //Geliş sebebi
    public SelectedProvizyonTipi: Array<Guid>;
    //İstisnai Hal
    public SelectedIstisnaiHal: Array<Guid>;
    //Tanı
    public SelectedDiagnosis: Array<Guid>;
    //Tedavi Türü
    public SelectedTreatment: Guid;
    //Kabul tarihi başlangıç
    public AdmissionStartDate?: Date;
    //Kabul tarihi bitiş
    public AdmissionEndDate?: Date;
    //Yatış tarihi başlangıç
    public InPatientStartDate?: Date;
    //Yatış tarihi başlangıç
    public InPatientEndDate?: Date;
    //Kabul Doktoru
    public SelectedAdmissionDoctor: Array<Guid>;
    //Kabul Branşı
    public SelectedSpecialities: Array<any>;
    //Kabul Birimi
    public SelectedPoliclinics: Array<any>;

    public SetNullAdmissionStartDateRelatedCriterias() {
        this.SelectedPayers = new Array<Guid>();
        this.SelectedProvizyonTipi = new Array<Guid>();
        this.SelectedIstisnaiHal = new Array<Guid>();
        this.SelectedDiagnosis = new Array<Guid>();
        this.SelectedTreatment = null;
        this.AdmissionEndDate = null;
        this.SelectedAdmissionDoctor = new Array<any>();
        this.SelectedSpecialities = new Array<any>();
        this.SelectedPoliclinics = new Array<any>();
    }
}

//#region SMS Log Sorgulama
export class SMSLogSearchModel {
    public StartDate?: Date;
    public EndDate?: Date;
    public PhoneNumber: string;
    public Status?: boolean;
    public MessageText: string;
    public SMSType:number;
}

//#endregion

export class SMSPatientFormViewModel {
    public PatientSearchModel: SMSPatientSearchModel = new SMSPatientSearchModel();
    public GridViewModel: Array<SMSPatientGridViewModel> = new Array<SMSPatientGridViewModel>();
    public SMSText: string;
}

export class SMSPatientGridViewModel {
    public ObjectID: Guid;
    public Name: string;
    public SurName: string;
    public Phone: string;
    public UniqueRefNo: string;
}
//#endregion  Hasta SMS Modeli

export class SendPersonnelSMSModel {
    public SMSModel: Array<SMSPersonnelGridViewModel> = new Array<SMSPersonnelGridViewModel>();
    public SMSText: string;
    public SMSType: number;
}

export class SendPatientSMSModel {
    public SMSModel: Array<SMSPatientGridViewModel> = new Array<SMSPatientGridViewModel>();
    public SMSText: string;
    public SMSType: number;
}

export enum WorkStatusEnum {
    NotWorking = 0,
    Working = 1
}

export namespace WorkStatusEnum {
    export const _NotWorking = new EnumItem(WorkStatusEnum.NotWorking, 'Çalışmıyor', i18n('M13837', 'Çalışmıyor'), <number>WorkStatusEnum.NotWorking);
    export const _Working = new EnumItem(WorkStatusEnum.Working, 'Çalışıyor', i18n('M17061', 'Çalışıyor'), <number>WorkStatusEnum.Working);
    export const Items: Array<EnumItem> = [_NotWorking, _Working];

    @ClassType()
    export class WorkStatusEnumList implements IEnumList {
        get Items(): Array<EnumItem> {
            return WorkStatusEnum.Items;
        }
    }
}
