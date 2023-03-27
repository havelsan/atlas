import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { HastaNakilFormuViewModel, HastaNakilSKRSModel } from './HastaNakilFormuViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IModalService } from 'app/Fw/Services/IModalService';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DynamicComponentInputParam } from '../../../wwwroot/app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { DiagnosisAndProcedureBaseModel } from '../Tibbi_Surec_Is_Listeleri/Yatan_Hasta_Is_Listesi/InPatientWorkListViewModel';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { SKRSDurum } from '../../../wwwroot/app/NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from '../../../wwwroot/app/Fw/Services/ObjectContextService';
import { ServiceLocator } from '../../../wwwroot/app/Fw/Services/ServiceLocator';
import { ShowBoxTypeEnum } from '../../../wwwroot/app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: "HastaNakilFormu",
    templateUrl: './HastaNakilFormu.html',
    providers: [MessageService]

})
export class HastaNakilFormu extends BaseComponent<any> implements OnInit, OnDestroy {
    hastaNakilFormuViewModel: HastaNakilFormuViewModel = new HastaNakilFormuViewModel();
    hastaNakilSKRSModel: HastaNakilSKRSModel = new HastaNakilSKRSModel();
    SolunumIslemiItems: Array<any> = new Array<any>();
     _disableNabizButton:boolean = false;
    constructor(protected httpService: NeHttpService, private http: AtlasHttpService, services: ServiceContainer, protected messageService: MessageService, protected modalService: IModalService, private reportService: AtlasReportService, private objectContextService: ObjectContextService) {
        super(services);
    }
    clientPostScript(state: String) {

    }
    _EpisodeActionID: Guid = Guid.Empty;
    public setInputParam(value: ActiveIDsModel) {
        if (value != null) {
            this._EpisodeActionID = value.episodeActionId;
        }
    }
    clientPreScript() {

    }
    public ngOnDestroy(): void {
    }

    async ngOnInit() {
        this.SolunumIslemiItems = [
            { ADI: 'ENTÜBE', KODU: '1' },
            { ADI: 'NON-INVASIVE', KODU: '2' },
            { ADI: 'SPONTAN', KODU: '3' },

        ]
        await this.loadHastaNakilFormuModel();
        await this.loadHastaNakilSKRSModel();
        this.LoadAllDiagnosisDefinitions();
        this.getKabulEdenKurumDataSource();
        this.getKomutaKontrolMerkeziDataSource();
    }

    async loadHastaNakilFormuModel() {
        let that = this;
        let fullApiUrl: string = "/api/HastaNakilFormuService/LoadHastaNakilFormuModel?EpisodeActionID=" + this._EpisodeActionID.toString();
        await this.httpService.get<HastaNakilFormuViewModel>(fullApiUrl)
            .then(response => {
                that.hastaNakilFormuViewModel = response as HastaNakilFormuViewModel;
                that._DiagnosisList = that.hastaNakilFormuViewModel.SevkTaniList;
                if (that.hastaNakilFormuViewModel.IsNew == true)
                    this._disableNabizButton = true;
                else 
                    this._disableNabizButton = false;
                
            })
            .catch(error => {
                console.log(error);
            });

    }

    loadHastaNakilSKRSModel() {
        let that = this;
        let fullApiUrl: string = "/api/HastaNakilFormuService/LoadHastaNakilSKRSModel?EpisodeActionID=" + this._EpisodeActionID.toString();
        this.httpService.get<HastaNakilSKRSModel>(fullApiUrl)
            .then(response => {
                that.hastaNakilSKRSModel = response as HastaNakilSKRSModel;
            })
            .catch(error => {
                console.log(error);
            });

    }

    private SaveForm() {
        if (this.checkRequiredFields()) {
            let fullApiUrl: string = "/api/HastaNakilFormuService/SaveHastaNakilFormuModel";
            this.httpService.post<any>(fullApiUrl, this.hastaNakilFormuViewModel)
                .then(response => {
                    this.messageService.showSuccess("Rapor Kaydedildi.");

                })
                .catch(error => {
                    console.log(error);
                    ServiceLocator.MessageService.showError(error);
                });
        }
    }

    public checkRequiredFields(): boolean {
        if (this.hastaNakilFormuViewModel.TalepEdildigiZaman == null) {
            TTVisual.InfoBox.Alert("Naklin Talep Edildiği Zaman alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.NakilTalepEdenKlinik == Guid.Empty || this.hastaNakilFormuViewModel.NakilTalepEdenKlinik == null) {
            TTVisual.InfoBox.Alert("Nakli Talep Eden Klinik alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.NakilEdilmekIstenilenKlinik == Guid.Empty || this.hastaNakilFormuViewModel.NakilEdilmekIstenilenKlinik == null) {
            TTVisual.InfoBox.Alert("Nakil Edilmek İstenen Klinik alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.HastaninBulunduguKlinik == Guid.Empty || this.hastaNakilFormuViewModel.HastaninBulunduguKlinik == null) {
            TTVisual.InfoBox.Alert("Hastanın Bulunduğu Klinik alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.KomutaKontrolMerkezi == Guid.Empty || this.hastaNakilFormuViewModel.KomutaKontrolMerkezi == null) {
            TTVisual.InfoBox.Alert("Nakli Gerçekleştirmesi İstenen Komuta Kontrol Merkezi alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.NakilGerceklestirmeYolu == Guid.Empty || this.hastaNakilFormuViewModel.NakilGerceklestirmeYolu == null) {
            TTVisual.InfoBox.Alert("Nakil Gerçekleştirme Yolu alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.SevkNedeni == Guid.Empty || this.hastaNakilFormuViewModel.SevkNedeni == null) {
            TTVisual.InfoBox.Alert("Sevk Nedeni alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.NakilTipi == Guid.Empty || this.hastaNakilFormuViewModel.NakilTipi == null) {
            TTVisual.InfoBox.Alert("Hasta Nakil Tipi alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.DoktorIhtiyaci == Guid.Empty || this.hastaNakilFormuViewModel.DoktorIhtiyaci == null) {
            TTVisual.InfoBox.Alert("Doktor İhtiyacı alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.TeyitliVakaMi == Guid.Empty || this.hastaNakilFormuViewModel.TeyitliVakaMi == null) {
            TTVisual.InfoBox.Alert("Teyitli Vaka Mı? alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.SevkTaniList.length == 0) {
            TTVisual.InfoBox.Alert("Sevke Esas Tanı alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.SistolikKanBasinci == null) {
            TTVisual.InfoBox.Alert("Sistolik Kan Basıncı alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.DiastolikKanBasinci == null) {
            TTVisual.InfoBox.Alert("Diastolik Kan Basıncı alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.Solunum == null) {
            TTVisual.InfoBox.Alert("Solunum alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.SolunumIslemi == null) {
            TTVisual.InfoBox.Alert("Solunum İşlemi alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.GlaskowKomaSkalasi == null) {
            TTVisual.InfoBox.Alert("Glaskow Koma Skalası alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.Gozler == null) {
            TTVisual.InfoBox.Alert("Gözler alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.Triaj == Guid.Empty || this.hastaNakilFormuViewModel.Triaj == null) {
            TTVisual.InfoBox.Alert("Triaj alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.Ates == null) {
            TTVisual.InfoBox.Alert("Ateş alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.NabizSayisi == null) {
            TTVisual.InfoBox.Alert("Nabız Sayısı alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.Bilinc == null) {
            TTVisual.InfoBox.Alert("Bilinç alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.Sozel == null) {
            TTVisual.InfoBox.Alert("Sözel alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.Motor == null) {
            TTVisual.InfoBox.Alert("Motor alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.VitalBulgular == null) {
            TTVisual.InfoBox.Alert("Vital Bulgular alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.EpikrizeEkAciklama == null) {
            TTVisual.InfoBox.Alert("Epikrize Ek Açıklama alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.HekimAdi == null) {
            TTVisual.InfoBox.Alert("Sevk Eden Hekim Adı alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.HekimSoyadi == null) {
            TTVisual.InfoBox.Alert("Sevk Eden Hekim Soyadı alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.HekimTel == null) {
            TTVisual.InfoBox.Alert("Sevk Eden Hekim Cep Telefon Numarası alanı boş geçilemez!");
            return false;
        }
        if (this.hastaNakilFormuViewModel.HekimTC == null) {
            TTVisual.InfoBox.Alert("Sevk Eden Hekim Kimlik Numarası alanı boş geçilemez!");
            return false;
        }

        return true;
    }

    _DiagnosisList: Array<DiagnosisAndProcedureBaseModel> = new Array<DiagnosisAndProcedureBaseModel>();
    public DiagnosisArray: any;

    DiagnosisColumns = [
        { caption: 'Tanı Kodu', dataField: 'Code', fixed: true, width: '50' },
        { caption: 'Tanı Adı', dataField: 'Name', fixed: true, width: 'auto' },
        { caption: "Sil", name: "RowDelete", fixed: true, width: '20', cellTemplate: "deleteCellTemplate", }

    ]
    async diagnosisGridDeleteClicked(data: any) {
        let that = this;
        if (data.column.name = "RowDelete") {
            if (data.row != null && data.row.data != null) {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "Tanı Silme", "<b>'" + data.row.data.Code + "'</b>  kodlu tanı silinecektir! \r\n\r\n Devam etmek istiyor musunuz?");
                if (messageResult === "E") {
                    this._DiagnosisList.splice(data.rowIndex, 1);
                }
            }
        }
    }

    public async LoadAllDiagnosisDefinitions() {
        let filterString: string = 'ISLEAF=1';


        this.DiagnosisArray = new DataSource({
            store: new CustomStore({
                key: "Code",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'DiagnosisListDefinition',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    if (String.isNullOrEmpty(loadOptions.searchValue)) {
                        return null;
                    } else {
                        return this.httpService.post<any>("/api/DefinitionQuery/DevExtremePagingQueryForDefList", loadOptions);
                    }
                },
                byKey: (key: any) => {
                    let loadOptions: any = new Object();
                    loadOptions.Params = {
                        searchText: key,
                        definitionName: 'DiagnosisListDefinition',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    if (String.isNullOrEmpty(loadOptions.searchValue)) {
                        return null;
                    } else {
                        return this.httpService.post<any>("/api/DefinitionQuery/DevExtremePagingQueryForDefList", loadOptions);
                    }
                }
            }),
            paginate: true,
            pageSize: 10
        });
    }
    public async diagnosisSelection_ValueChanged(data: any) {
        let that = this;
        if (data != null) { //data.objectID
            let diagnosis: DiagnosisAndProcedureBaseModel = new DiagnosisAndProcedureBaseModel();
            diagnosis.ObjectID = data.ObjectID;
            diagnosis.Code = data.Code;
            diagnosis.Name = data.Name;
            this._DiagnosisList.push(diagnosis);
            this.hastaNakilFormuViewModel.SevkTaniList = this._DiagnosisList;
        }
    }

    kabulEdenKurumDataSource: any;
    public kabulEdenKurumListFilter: string = "";
    getKabulEdenKurumDataSource() {
        let filterString: string = 'AKTIF=1';

        this.kabulEdenKurumDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'SKRSKurumlarList',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return await this.httpService.post<any>("/api/HastaNakilFormuService/GetKurumlarListDefinition", loadOptions);
                },
                byKey: async (key: any) => {
                    return await this.httpService.post<any>("/api/HastaNakilFormuService/GetKurumlarListDefinition?key=" + key, null);
                }
            }),
            paginate: true,
            pageSize: 10
        });
    }

    komutaKontrolMerkeziDataSource: any;
    public komutaKontrolMerkeziListFilter: string = "";
    getKomutaKontrolMerkeziDataSource() {
        let filterString: string = 'AKTIF=1';

        this.komutaKontrolMerkeziDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'SKRSKurumlarList',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return await this.httpService.post<any>("/api/HastaNakilFormuService/GetKurumlarListDefinition", loadOptions);
                },
                byKey: async (key: any) => {
                    return await this.httpService.post<any>("/api/HastaNakilFormuService/GetKurumlarListDefinition?key=" + key, null);
                }
            }),
            paginate: true,
            pageSize: 10
        });
    }


    public onVitalBulgularChanged(event): void {
        if (event != null) {
            this.hastaNakilFormuViewModel.VitalBulgular = event;
        }
    }
    public onPatolojikMuayeneBilgileriChanged(event): void {
        if (event != null) {
            this.hastaNakilFormuViewModel.PatolojikMuayeneBilgileri = event;
        }
    }
    public onNakilSirasindaIstenilenMedikalIslemlerChanged(event): void {
        if (event != null) {
            this.hastaNakilFormuViewModel.NakilSirasindaIstenilenMedikalIslemler = event;
        }
    }
    public onTetkikBilgileriChanged(event): void {
        if (event != null) {
            this.hastaNakilFormuViewModel.TetkikBilgileri = event;
        }
    }
    public onYapilanMedikalIslemlerChanged(event): void {
        if (event != null) {
            this.hastaNakilFormuViewModel.YapilanMedikalIslemler = event;
        }
    }
    public onYapilmasiIstenilenMedikalIslemlerChanged(event): void {
        if (event != null) {
            this.hastaNakilFormuViewModel.YapilmasiIstenilenMedikalIslemler = event;
        }
    }
    public onNakilSirasindakiGereksinimlerChanged(event): void {
        if (event != null) {
            this.hastaNakilFormuViewModel.NakilSirasindakiGereksinimler = event;
        }
    }

    public onSevkNedeniAciklamaChanged(event): void {
        if (event != null) {
            this.hastaNakilFormuViewModel.SevkNedeniAciklama = event;
        }
    }

    public onHastaYakiniAdresChanged(event): void {
        if (event != null) {
            this.hastaNakilFormuViewModel.HastaYakiniAdres = event;
        }
    }

    public onEpikrizeEkAciklamaChanged(event): void {
        if (event != null) {
            this.hastaNakilFormuViewModel.EpikrizeEkAciklama = event;
        }
    }
    public doktorValue: any;
    public onDoctorSelectionChanged(data) {
        if (data != null && data.selectedItem != null) {
            this.hastaNakilFormuViewModel.HekimAdi = data.selectedItem.Name;
            this.hastaNakilFormuViewModel.HekimSoyadi = data.selectedItem.Surname;
            this.hastaNakilFormuViewModel.HekimTel = data.selectedItem.Phone;
            this.hastaNakilFormuViewModel.HekimTC = data.selectedItem.UniqueRefNo;
            this.doktorValue = null;
        }
    }

    PrepareReport() {

        let that = this;
        let reportData: DynamicReportParameters = {

            Code: 'HASTANAKILFORMU',
            ReportParams: { ObjectID: this.hastaNakilFormuViewModel.ObjectID },
            ViewerMode: true

        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "HASTA NAKİL FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    async SendToEnabiz() {
        
        let fullApiUrl: string = "/api/HastaNakilFormuService/SendFormToEnabiz?ObjectID=" + this.hastaNakilFormuViewModel.ObjectID.toString();
        await this.httpService.get<string>(fullApiUrl)
            .then(response => {
              
                if (response != "") {
                    ServiceLocator.MessageService.showInfo(response);
                    this.hastaNakilFormuViewModel._NabizDurumu = response;
                }

            })
            .catch(error => {
                console.log(error);
                ServiceLocator.MessageService.showError(error);
            });
    }
}

