//$C3430EB6
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BreastScreening } from "NebulaClient/Model/AtlasClientModel";
import { SubEpisode } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { Patient } from "NebulaClient/Model/AtlasClientModel";
import { SKRSMeslekler } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOgrenimDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSMedeniHali } from "NebulaClient/Model/AtlasClientModel";
import { SigortaliTuru } from "NebulaClient/Model/AtlasClientModel";
import { AnamnesisInfo } from "NebulaClient/Model/AtlasClientModel";
import { SKRSAlkolKullanimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSMaddeKullanimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSSigaraKullanimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKullanilanAilePlanlamasiAPYontemi } from "NebulaClient/Model/AtlasClientModel";

export class BreastScreeningFormViewModel extends BaseViewModel {
    public _BreastScreening: BreastScreening = new BreastScreening();
    public SubEpisodes: Array<SubEpisode> = new Array<SubEpisode>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public Patients: Array<Patient> = new Array<Patient>();
    public SKRSMesleklers: Array<SKRSMeslekler> = new Array<SKRSMeslekler>();
    public SKRSOgrenimDurumus: Array<SKRSOgrenimDurumu> = new Array<SKRSOgrenimDurumu>();
    public SKRSMedeniHalis: Array<SKRSMedeniHali> = new Array<SKRSMedeniHali>();
    public SigortaliTurus: Array<SigortaliTuru> = new Array<SigortaliTuru>();
    public AnamnesisInfos: Array<AnamnesisInfo> = new Array<AnamnesisInfo>();
    public SKRSAlkolKullanimis: Array<SKRSAlkolKullanimi> = new Array<SKRSAlkolKullanimi>();
    public SKRSMaddeKullanimis: Array<SKRSMaddeKullanimi> = new Array<SKRSMaddeKullanimi>();
    public SKRSSigaraKullanimis: Array<SKRSSigaraKullanimi> = new Array<SKRSSigaraKullanimi>();
    public SKRSKullanilanAilePlanlamasiAPYontemis: Array<SKRSKullanilanAilePlanlamasiAPYontemi> = new Array<SKRSKullanilanAilePlanlamasiAPYontemi>();
}
