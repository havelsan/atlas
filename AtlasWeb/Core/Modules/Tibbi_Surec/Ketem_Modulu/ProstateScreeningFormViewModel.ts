//$70D24CB8
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ProstateScreening } from "NebulaClient/Model/AtlasClientModel";
import { AnamnesisInfo } from "NebulaClient/Model/AtlasClientModel";
import { SKRSAlkolKullanimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSSigaraKullanimi } from "NebulaClient/Model/AtlasClientModel";
import { SubEpisode } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { Patient } from "NebulaClient/Model/AtlasClientModel";
import { SKRSMeslekler } from "NebulaClient/Model/AtlasClientModel";

export class ProstateScreeningFormViewModel extends BaseViewModel {
    public _ProstateScreening: ProstateScreening = new ProstateScreening();
    public AnamnesisInfos: Array<AnamnesisInfo> = new Array<AnamnesisInfo>();
    public SKRSAlkolKullanimis: Array<SKRSAlkolKullanimi> = new Array<SKRSAlkolKullanimi>();
    public SKRSSigaraKullanimis: Array<SKRSSigaraKullanimi> = new Array<SKRSSigaraKullanimi>();
    public SubEpisodes: Array<SubEpisode> = new Array<SubEpisode>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public Patients: Array<Patient> = new Array<Patient>();
    public SKRSMesleklers: Array<SKRSMeslekler> = new Array<SKRSMeslekler>();
}
