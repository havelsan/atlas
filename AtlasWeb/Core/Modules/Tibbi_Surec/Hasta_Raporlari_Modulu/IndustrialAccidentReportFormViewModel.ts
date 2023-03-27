
import { Type } from 'NebulaClient/ClassTransformer';

export class IndustrialAccidentReportFormViewModel {

    public IsYeriNo: string;
    public Unite: string;
    public IsYeriAdres: string;
    public IsYeriUnvan: string;
    public IsYeriIl: string;
    public AdiSoyadi: string;
    public TCKimlikNo: string;
    public Gorevi: string;
    public Tel: string;
    public YaraninTuru: string;
    @Type(() => Date)
    public DogumTarihi: Date;
    public Uyruk: string;
    public YaraninVucuttakiYeri: string;
    public Arac: string;
    @Type(() => Date)
    public BildirimTarihi: Date;
    public CalisilanOrtam: string;
    public SaptanmaSekli: string;
    public MeslekHastaligiEtkeni: string;
    @Type(() => Date)
    public TaniTarihi: Date;
    public MeslekHastaligiEtkenSuresi: string;
    public IsGoremezlikSeviyesi: string;
    @Type(() => Date)
    public BildirimTarihi2: Date;
    public SubepisodeID: string;
    @Type(() => Boolean)
    public IsNew: boolean;
    public ObjectID: string;
}

