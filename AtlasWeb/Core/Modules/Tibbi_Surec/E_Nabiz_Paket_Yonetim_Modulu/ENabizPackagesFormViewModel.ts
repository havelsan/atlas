//$08330762

import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { SendToENabizEnum } from "app/NebulaClient/Model/AtlasClientModel";
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
export class ENabizPackagesFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.ENabizPackagesFormViewModel, Core';
    @Type(() => NabizSearchCritaria)
    public _NabizSearchCritaria: NabizSearchCritaria = new NabizSearchCritaria();
    @Type(() => NabizResult)
    public _NabizResult: Array<NabizResult> = new Array<NabizResult>();
    @Type(() => PackageInfo)
    NabizPackageList: Array<PackageInfo> = new Array<PackageInfo>(); //dx-tag-box i�in

    //G�n Sonu
    @Type(() => DailyBasedNabizSearchCritaria)
    public _DailyBasedNabizSearchCritaria: DailyBasedNabizSearchCritaria = new DailyBasedNabizSearchCritaria();
    @Type(() => DailyBasedNabizResult)
    public _DailyBasedNabizResult: Array<DailyBasedNabizResult> = new Array<DailyBasedNabizResult>();

    //Kabul-Hasta Bazl�
    @Type(() => SubepisodeBasedNabizSearchCritaria)
    public _SubepisodeBasedNabizSearchCritaria: SubepisodeBasedNabizSearchCritaria = new SubepisodeBasedNabizSearchCritaria();
    @Type(() => SubepisodeBasedNabizResult)
    public _SubepisodeBasedNabizResult: Array<SubepisodeBasedNabizResult> = new Array<SubepisodeBasedNabizResult>();

   
}

export class NabizSearchCritaria {
    @Type(() => PackageInfo)
    public NabizPackages: Array<PackageInfo>;
    @Type(() => Date)
    public packageAddingDateStart: Date;
    @Type(() => Date)
    public packageAddingDateEnd: Date;
    @Type(() => Number)
    public packageStatus: number;
    @Type(() => Date)
    public SubepisodeOpeningDateStart: Date;
    @Type(() => Date)
    public SubepisodeOpeningDateEnd: Date;
    public ProtocolNo: string;
    @Type(() => Number)
    public SearchType: number;

    public PatientObjectID: Guid;
    public ResponseCode: string;

    //@Type(() => Date)
    //public packageSendDateStart: Date;
    //@Type(() => Date)
    //public packageSendDateEnd: Date;
}

export class DailyBasedNabizSearchCritaria {
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
}

export class SubepisodeBasedNabizSearchCritaria {
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public PatientObjectID: string;
    public ProtocolNo: string;
    @Type(() => Boolean)
    public HasSYSNo: boolean;
    public SYSTakipNo: string;
}

export class DailyBasedNabizResult {
    public ObjectID: Guid;
    public ResponseCode: string;
    public ResponseMessage: string;
    public SendDate: string;
    public Status: string;
}

export class SubepisodeBasedNabizResult {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Ressection: string;
    public OpeningDate: string;
    public ProtocolNo: string;
    public PatientNameSurname: string;
    public  SYSTakipNo:string;
   
}

export class NabizResult {

    @Type(() => Number)
    public PackageCode: number;
    public PackageName: string;


    @Type(() => Guid)
    public SendToENabizObjectID: Guid = null;
    @Type(() => Guid)
    public SendToENabizInternalObjectID: Guid = null;
    public SendToENabizInternalObjectDef: string;
    public PackageStatus: string;
    public ResponseFromENabiz: string = null;
    public PatientName: string;
    public PatientAdmissionNo: string;
    public PackageSendDate: string;
    public SYSTakipNo: string;
    public ResultCode: string;

}

export class PackageInfo {
    @Type(() => Number)
    public Code: number;
    public PackageName: string;
}

export class PackageDetail {
    @Type(() => Guid)
    public SendToEnabizObjectID: Guid;
    @Type(() => Guid)
    public InternalObjectID: Guid;
    public InternalObjectDefName: string;
    @Type(() => Number)
    public PackageCode: number;
    public PackageName: string;
    public StatusName: string;
    @Type(() => Number)
    public Status: number;
    public RecordDate: string;
 
    public SubepisodeObjectID: string;
    public ResponseObjectID: string;
    public ResponseCode: string;
    public ResponseMessage: string;
    public SendDate: string;
    public ProcedureDetail: string;
}

export class NabizResponse {
    public SYSTakipNo: string;
    public SonucKodu: string;
    public SonucMesaji: string;
    constructor() {
        this.SYSTakipNo = "";
        this.SonucKodu = "";
        this.SonucMesaji = "";
    }
}

export class IslemBanaAitDegilResponse {
    @Type(() => Number)
    public durum: number;
    @Type(() => IslemBanaAitDegilResultModel)
    public sonuc: Array<IslemBanaAitDegilResultModel> = new Array<IslemBanaAitDegilResultModel>();
    public mesaj: string;
}
export class IslemBanaAitDegilResultModel {
    public sysTakipNo: string;
    public islemAdi: string;
    public islemKodu: string;
    public XXXXXX: string;
}
