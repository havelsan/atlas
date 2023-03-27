import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ComboListItem } from 'NebulaClient/Visual/ComboListItem';


@Injectable()
export class GetMedulaDefinitionService {

    tabMessage: Subject<any> = new Subject<any>();
    //childLoaded: Subject<any> = new Subject<any>();

    public TedaviTuruCache: any;
    public invoiceControlNQLDefCache: any;
    public PayerCache: any;
    public procedureStateDefCache: any;
    public ProvizyonTipiCache: any;
    public TedaviTipiCache: any;
    public TakipTipiCache: any;
    public BransCache: any;
    public DevredilenKurumCache: any;
    public TriageCache: any;
    public TaburcuKoduCache: any;
    public IstisnaiHalCache: any;
    public SigortaliTuruCache: any;
    public DoctorCache: any;
    public SectionCache: any;
    public OzelDurumCache: any;
    public KesiCache: any;
    public InvoiceUsersCache: any;
    public InvoiceCollectionCache: any;
    public IlacCache: any;
    public TaburcuTipiCache: any;

    constructor(private http: NeHttpService) {

    }

    public async SetInvoiceCollection(invoiceCollection: ComboListItem) {

        this.InvoiceCollectionCache = invoiceCollection;
    }

    public async GetInvoiceCollection(): Promise<ComboListItem> {

        if (!this.InvoiceCollectionCache)
            return null;
        else
            return this.InvoiceCollectionCache;
    }

    public async TedaviTuru(): Promise<any> {

        if (!this.TedaviTuruCache) {
            this.TedaviTuruCache = await this.http.get("api/InvoiceDefinitionApi/GetTedaviTuru");
            return this.TedaviTuruCache;
        }
        else {
            return this.TedaviTuruCache;
        }
    }

    public async invoiceControlNQLDef(): Promise<any> {

        if (!this.invoiceControlNQLDefCache) {
            this.invoiceControlNQLDefCache = await this.http.get("api/InvoiceDefinitionApi/GetinvoiceControlNQLDef");
            return this.invoiceControlNQLDefCache;
        }
        else {
            return this.invoiceControlNQLDefCache;
        }
    }
    public async Payer(): Promise<any> {

        if (!this.PayerCache) {
            this.PayerCache = await this.http.get("api/InvoiceDefinitionApi/GetPayer");
            return this.PayerCache;
        }
        else {
            return this.PayerCache;
        }
    }
    public async procedureStateDef(): Promise<any> {

        if (!this.procedureStateDefCache) {
            this.procedureStateDefCache = await this.http.get("api/InvoiceDefinitionApi/GetProcedureStateDef");
            return this.procedureStateDefCache;
        }
        else {
            return this.procedureStateDefCache;
        }
    }

    public async ProvizyonTipi(): Promise<any> {

        if (!this.ProvizyonTipiCache) {
            this.ProvizyonTipiCache = await this.http.get("api/InvoiceDefinitionApi/GetProvizyonTipi");
            return this.ProvizyonTipiCache;
        }
        else {
            return this.ProvizyonTipiCache;
        }
    }

    public async TedaviTipi(): Promise<any> {

        if (!this.TedaviTipiCache) {
            this.TedaviTipiCache = await this.http.get("api/InvoiceDefinitionApi/GetTedaviTipi");
            return this.TedaviTipiCache;
        }
        else {
            return this.TedaviTipiCache;
        }
    }

    public async TakipTipi(): Promise<any> {

        if (!this.TakipTipiCache) {
            this.TakipTipiCache = await this.http.get("api/InvoiceDefinitionApi/GetTakipTipi");
            return this.TakipTipiCache;
        }
        else {
            return this.TakipTipiCache;
        }
    }

    public async Brans(): Promise<any> {

        if (!this.BransCache) {
            this.BransCache = await this.http.get("api/InvoiceDefinitionApi/GetBrans");
            return this.BransCache;
        }
        else {
            return this.BransCache;
        }
    }
    public async DevredilenKurum(): Promise<any> {

        if (!this.DevredilenKurumCache) {
            this.DevredilenKurumCache = await this.http.get("api/InvoiceDefinitionApi/GetDevredilenKurum");
            return this.DevredilenKurumCache;
        }
        else {
            return this.DevredilenKurumCache;
        }
    }
    public async Triage(): Promise<any> {

        if (!this.TriageCache) {
            this.TriageCache = await this.http.get("api/InvoiceDefinitionApi/GetTriage");
            return this.TriageCache;
        }
        else {
            return this.TriageCache;
        }
    }
    public async TaburcuKodu(): Promise<any> {

        if (!this.TaburcuKoduCache) {
            this.TaburcuKoduCache = await this.http.get("api/InvoiceDefinitionApi/GetTaburcuKodu");
            return this.TaburcuKoduCache;
        }
        else {
            return this.TaburcuKoduCache;
        }
    }
    public async IstisnaiHal(): Promise<any> {

        if (!this.IstisnaiHalCache) {
            this.IstisnaiHalCache = await this.http.get("api/InvoiceDefinitionApi/GetIstisnaiHal");
            return this.IstisnaiHalCache;
        }
        else {
            return this.IstisnaiHalCache;
        }
    }
    public async SigortaliTuru(): Promise<any> {

        if (!this.SigortaliTuruCache) {
            this.SigortaliTuruCache = await this.http.get("api/InvoiceDefinitionApi/GetSigortaliTuru");
            return this.SigortaliTuruCache;
        }
        else {
            return this.SigortaliTuruCache;
        }
    }
    public async Doctor(): Promise<any> {

        if (!this.DoctorCache) {
            this.DoctorCache = await this.http.get("api/InvoiceDefinitionApi/GetDoctor");
            return this.DoctorCache;
        }
        else {
            return this.DoctorCache;
        }
    }
    public async Section(): Promise<any> {

        if (!this.SectionCache) {
            this.SectionCache = await this.http.get("api/InvoiceDefinitionApi/GetSection");
            return this.SectionCache;
        }
        else {
            return this.SectionCache;
        }
    }
    public async OzelDurum(): Promise<any> {

        if (!this.OzelDurumCache) {
            this.OzelDurumCache = await this.http.get("api/InvoiceDefinitionApi/GetOzelDurum");
            return this.OzelDurumCache;
        }
        else {
            return this.OzelDurumCache;
        }
    }
    public async Kesi(): Promise<any> {

        if (!this.KesiCache) {
            this.KesiCache = await this.http.get("api/InvoiceDefinitionApi/GetKesi");
            return this.KesiCache;
        }
        else {
            return this.KesiCache;
        }
    }
    public async InvoiceUsers(): Promise<any> {

        if (!this.InvoiceUsersCache) {
            this.InvoiceUsersCache = await this.http.get("api/InvoiceDefinitionApi/GetInvoiceUsers");
            return this.InvoiceUsersCache;
        }
        else {
            return this.InvoiceUsersCache;
        }
    }

    public async TaburcuTipi(): Promise<any> {

        if (!this.TaburcuTipiCache) {
            this.TaburcuTipiCache = await this.http.get("api/InvoiceDefinitionApi/GetTaburcuTipi");
            return this.TaburcuTipiCache;
        }
        else {
            return this.TaburcuTipiCache;
        }
    }
}