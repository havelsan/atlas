//$C0EA48B6
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { IWebMethodCallback } from "NebulaClient/Utils/IWebMethodCallback";
import { HastaKabulIslemleri } from "NebulaClient/Services/External/HastaKabulIslemleri";
import { HizmetKayitIslemleri } from "NebulaClient/Services/External/HizmetKayitIslemleri";
import { FaturaKayitIslemleri } from "NebulaClient/Services/External/FaturaKayitIslemleri";

export namespace XXXXXXMedulaServices {
    export class AsyncBase {
        public MessageObjectID: string;
        public MedulaProvisionObjectID: string;
    }

    export class BasvuruTakipOkuParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _basvuruTakipOkuDVO: HastaKabulIslemleri.basvuruTakipOkuDVO;
    }

    export class HastaKabulParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _provizyonGirisDVO: HastaKabulIslemleri.provizyonGirisDVO;
    }

    export class HastaKabulIptalParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _takipSilGirisDVO: HastaKabulIslemleri.takipSilGirisDVO;
    }

    export class HastaKabulOkuParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _takipOkuGirisDVO: HastaKabulIslemleri.takipOkuGirisDVO;
        public _createdBy: string;
    }

    export class UpdateProvizyonTipiParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _provizyonDegistirGirisDVO: HastaKabulIslemleri.provizyonDegistirGirisDVO;
    }

    export class UpdateTakipTipiParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _takipTipiDegistirGirisDVO: HastaKabulIslemleri.takipTipiDegistirGirisDVO;
    }

    export class UpdateTedaviTuruParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _tedaviTuruDegistirGirisDVO: HastaKabulIslemleri.tedaviTuruDegistirGirisDVO;
    }

    export class HizmetKayitParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _hizmetKayitGirisDVO: HizmetKayitIslemleri.hizmetKayitGirisDVO;
        public _accountTransactionIDs: Array<string>;
        public _subEpisodeObjectID: string;
    }

    export class HizmetKayitOkuParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _hizmetOkuGirisDVO: HizmetKayitIslemleri.hizmetOkuGirisDVO;
        public _accountTransactionIDs: Array<string>;
    }

    export class HizmetIptalParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _hizmetIptalGirisDVO: HizmetKayitIslemleri.hizmetIptalGirisDVO;
        public _accountTransactionIDs: Array<string>;
        public _isAccountTransactionList: boolean = true;
    }

    export class FaturaTutarOkuParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _faturaGirisDVO: FaturaKayitIslemleri.faturaGirisDVO;
        public _medulaProvisionObjectIDs: Array<string>;
    }

    export class FaturaGirisParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _faturaGirisDVO: FaturaKayitIslemleri.faturaGirisDVO;
        public _medulaProvisionObjectIDs: Array<string>;
    }

    export class FaturaKaydiIptalParam extends AsyncBase implements IWebMethodCallback {
        public ObjectContext: TTObjectContext;
        public _faturaIptalGirisDVO: FaturaKayitIslemleri.faturaIptalGirisDVO;
    }

    export class WebMethods {

    }
}
