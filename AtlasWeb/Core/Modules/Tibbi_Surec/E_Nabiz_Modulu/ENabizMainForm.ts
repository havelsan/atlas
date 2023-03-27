//$8F2DAF9F

import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ITabPanel } from 'Fw/Components/HvlTabPanel';
import { ENabizDataSets, EnabizInputObject, DataSetInput } from '../E_Nabiz_Modulu/ENabizViewModel';
import { KronikHastaliklarFormViewModel } from './KronikHastaliklarFormViewModel';
import { MessageService } from 'Fw/Services/MessageService';
import { BulasiciHastaliklarNewFormViewModel } from './BulasiciHastaliklarNewFormViewModel';
import { DiyabetFormViewModel } from './DiyabetFormViewModel';
import { ObeziteIzlemFormViewModel } from './ObeziteIzlemFormViewModel';
import { VeremVeriSetiFormViewModel } from "./VeremVeriSetiFormViewModel";
import { KuduzProfilaksiIzlemFormViewModel } from "./KuduzProfilaksiIzlemFormViewModel";
import { TutunKullanimiVeriSetiFormViewModel } from "./TutunKullanimiVeriSetiFormViewModel";
import { MaddeBagimliligiVeriSetiFormViewModel } from "./MaddeBagimliligiVeriSetiFormViewModel";
import { KuduzProfilaksiTelefon, KuduzProfilaksiUygProfilak, KuduzRiskliTemasPlanProfBi, KuduzRiskliTemasRiskTemTip, TutunKullanimiBagimOldUrun, IntiharGirisimiKrizNedeni, IntiharGirisimiVakaSonucu, KadinaYonelikSiddetSonuc, KadinaYonelikSiddetTuru } from "NebulaClient/Model/AtlasClientModel";
import { KuduzRiskliTemasVeriSetiFormViewModel } from "Modules/Tibbi_Surec/E_Nabiz_Modulu/KuduzRiskliTemasVeriSetiFormViewModel";
import { IntiharIzlemFormViewModel } from "Modules/Tibbi_Surec/E_Nabiz_Modulu/IntiharIzlemFormViewModel";
import { IntiharGirisimiKrizTespitVeriSetiFormViewModel } from "./IntiharGirisimiKrizTespitVeriSetiFormViewModel";
import { KadinaYonelikSiddetVeriSetiFormViewModel } from "./KadinaYonelikSiddetVeriSetiFormViewModel";
import { Guid } from 'NebulaClient/Mscorlib/Guid';


@Component({
    selector: "enabiz-form",
    templateUrl: './ENabizMainForm.html',
    outputs: ['OnClosing'],
    providers: [MessageService]

})
export class ENabizMainForm extends BaseComponent<any> implements OnInit, OnDestroy {

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }
    public ngOnDestroy(): void {
    }

    NabizTabItems: Array<ITabPanel> = [];
    ENabizViewModelList: Array<any> = new Array<any>();
    nabizDataSetList: Array<ENabizDataSets> = [];

    @Input() set NabizDataSetList(value: Array<ENabizDataSets>) {
        this.nabizDataSetList = value;

    }
    get NabizDataSetList(): Array<ENabizDataSets> {
        return this.nabizDataSetList;
    }

    private _eNabizViewModels: Array<any>;
    @Input() set ENabizViewModels(value: Array<any>) {
        this._eNabizViewModels = value;

    }
    get ENabizViewModels(): Array<any> {
        return this._eNabizViewModels;
    }

    private _fromHelpMenu: boolean;
    @Input() set FromHelpMenu(value: boolean) {
        this._fromHelpMenu = value;

    }
    get FromHelpMenu(): boolean {
        return this._fromHelpMenu;
    }

    _EpisodeActionID: Guid;

    @Input() set EpisodeActionID(value: Guid) {
        this._EpisodeActionID = value;

    }
    get EpisodeActionID(): Guid {
        return this._EpisodeActionID;
    }

    OnClosing: EventEmitter<Boolean> = new EventEmitter<any>();

    constructor(protected httpService: NeHttpService, services: ServiceContainer, protected messageService: MessageService) {
        super(services);
    }

    async ngOnInit() {
        await this.loadDataSets();
    }


    private loadDataSets(): void {
        let that = this;

        let a = new EnabizInputObject();
        a.ENabizDataSets = this.nabizDataSetList;
        a.EpisodeActionID = this._EpisodeActionID;

        let apiUrl: string = '/api/ENabizService/GetDatasetObjectIDs';

        that.httpService.post(apiUrl, a)
            .then(response => {
                let result = response;
                this.nabizDataSetList = result as ENabizDataSets[];

               
                for (let i = 0; i < this.nabizDataSetList.length; i++) {
                   
                    let inputData = new DataSetInput(); //Enabiz tarafına episodeactionID geçirmek için eklendi.
                    inputData.ObjectID = this.nabizDataSetList[i].ObjectID;
                    inputData.EpisodeActionID = this._EpisodeActionID;
                    inputData.DiagnosisObjectID = this.nabizDataSetList[i].DiagnosisObjectID;
                   
                    if (this.nabizDataSetList[i].PackageID == 236) {

                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/KuduzProfilaksiIzlemForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, 
                            Title: i18n("M30525", "Kuduz Profilaksi İzlem"),
                            Active: true
                        });
                    }
                    if (this.nabizDataSetList[i].PackageID == 237) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/KuduzRiskliTemasVeriSetiForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, 
                            Title: i18n("M30526", "Kuduz Riskli Temas"),
                            Active: true
                        });
                    }
                    if (this.nabizDataSetList[i].PackageID == 239) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/MaddeBagimliligiVeriSetiForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, 
                            Title: i18n("M30527", "Madde Bağımlılığı"),
                            Active: true
                        });
                    }
                    if (this.nabizDataSetList[i].PackageID == 248) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/TutunKullanimiVeriSetiForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, 
                            Title: i18n("M30528", "Tütün Kullanımı"),
                            Active: true
                        });
                    }

                    if (this.nabizDataSetList[i].PackageID == 250) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/VeremVeriSetiForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, 
                            Title: i18n("M30529", "Verem"),
                            Active: true
                        });
                    }

                    if (this.nabizDataSetList[i].PackageID == 235) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/KronikHastaliklarForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData,
                            Title: i18n("M17876", "Kronik Hastalıklar"),
                            Active: true
                        });
                    }

                    if (this.nabizDataSetList[i].PackageID == 219) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/EvdeSaglikIlkIzlemForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData,
                            Title: i18n("M14004", "Evde Sağlık İlk İzlem"),
                            Active: true
                        });
                    }

                    if (this.nabizDataSetList[i].PackageID == 220) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/EvdeSaglikIzlemForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData,
                            Title: i18n("M14006", "Evde Sağlık İzlem"),
                            Active: true
                        });
                    }

                    if (this.nabizDataSetList[i].PackageID == 214) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/BulasiciHastaliklarNewForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, //Tanı için
                            Title: i18n("M12108", "Bulaşıcı Hastalıklar"),
                            Active: true
                        });
                    }

                    if (this.nabizDataSetList[i].PackageID == 215) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/DiyabetForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, 
                            Title: i18n("M12978", "Diyabet"),
                            Active: true
                        });
                    }

                    if (this.nabizDataSetList[i].PackageID == 240) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ObeziteIzlemForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, 
                            Title: i18n("M19592", "Obezite İzlem"),
                            Active: true
                        });
                    }

                    if (this.nabizDataSetList[i].PackageID == 229) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/IntiharIzlemForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, 
                            Title: i18n("M30530", "Intihar Girişimi ve Kriz İzlem"),
                            Active: true
                        });
                    }

                    if (this.nabizDataSetList[i].PackageID == 230) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/IntiharGirisimiKrizTespitVeriSetiForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, 
                            Title: i18n("M30531", "Intihar Girişimi ve Kriz Tespit"),
                            Active: true
                        });
                    }

                    if (this.nabizDataSetList[i].PackageID == 231) {
                        this.NabizTabItems.push({
                            ModulePath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule',
                            ComponentPath: '/Modules/Tibbi_Surec/E_Nabiz_Modulu/KadinaYonelikSiddetVeriSetiForm',
                            RouteData: this.ENabizViewModelList,
                            RouteData2: inputData, 
                            Title: i18n("M30532", "Kadına Yönelik Şiddet"),
                            Active: true
                        });
                    }

                }
            })
            .catch(error => {
                console.log(error);
            });




    }

    onSaveENabiz() {
        for (let i = 0; i < this.ENabizViewModelList.length; i++) {
            //Kronik Hastalıklar
            if (this.ENabizViewModelList[i] instanceof KronikHastaliklarFormViewModel) {
                let confirmResult: ConfirmObject = this.confirmKronikHastaliklar(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }

            //Bulaşıcı Hastalıklar
            if (this.ENabizViewModelList[i] instanceof BulasiciHastaliklarNewFormViewModel) {
                let confirmResult: ConfirmObject = this.confirmBulasiciHastaliklar(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }

            //Diyabet
            if (this.ENabizViewModelList[i] instanceof DiyabetFormViewModel) {
                let confirmResult: ConfirmObject = this.confirmDiyabet(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }

            //Obezite
            if (this.ENabizViewModelList[i] instanceof ObeziteIzlemFormViewModel) {
                let confirmResult: ConfirmObject = this.confirmObezite(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }

            //Verem
            if (this.ENabizViewModelList[i] instanceof VeremVeriSetiFormViewModel) {
                let confirmResult: ConfirmObject = this.confirmVerem(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }

            //Kuduz Profilaksi
            if (this.ENabizViewModelList[i] instanceof KuduzProfilaksiIzlemFormViewModel) {
                let confirmResult: ConfirmObject = this.confirmKuduzProfilaksi(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }
            //Kuduz Riskli Temas
            if (this.ENabizViewModelList[i] instanceof KuduzRiskliTemasVeriSetiFormViewModel) {
                let confirmResult: ConfirmObject = this.confirmKKuduzRiskliTemas(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }

            //Tütün Kullanımı
            if (this.ENabizViewModelList[i] instanceof TutunKullanimiVeriSetiFormViewModel) {
               let confirmResult: ConfirmObject = this.confirmTutunKullanimi(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }
            //Madde Bağımlılığı
            if (this.ENabizViewModelList[i] instanceof MaddeBagimliligiVeriSetiFormViewModel) {
                let confirmResult: ConfirmObject = this.confirmMaddeBagimliligi(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }

            //Intihar Girisimi ve Kriz Izlem
            if (this.ENabizViewModelList[i] instanceof IntiharIzlemFormViewModel) {
                //let confirmResult: ConfirmObject = this.confirmTutunKullanimi(this.ENabizViewModelList[i]);
                //if (confirmResult.Result == false) {
                //    this.messageService.showError(confirmResult.Message);
                //    return;
                //}

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }

            //Intihar Girişimi Kriz Tespit Veri Seti
            if (this.ENabizViewModelList[i] instanceof IntiharGirisimiKrizTespitVeriSetiFormViewModel) {
                let confirmResult: ConfirmObject = this.confirmIntiharGirisimiKrizTespit(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }

            //Kadına Yönelik Şiddet Veri Seti
            if (this.ENabizViewModelList[i] instanceof KadinaYonelikSiddetVeriSetiFormViewModel) {
                let confirmResult: ConfirmObject = this.confirmKadinaYonelikSiddet(this.ENabizViewModelList[i]);
                if (confirmResult.Result == false) {
                    this.messageService.showError(confirmResult.Message);
                    return;
                }

                this._eNabizViewModels.push(this.ENabizViewModelList[i]);
            }

        }

        if (this._fromHelpMenu == true) {//Yardımcı menuden gelindiyse kendi kaydedecek
            let that = this;
            let apiUrl: string = '/api/ENabizService/SaveDataSets';

            that.httpService.post(apiUrl, this._eNabizViewModels)
                .then(response => {
                    let result = response;
                    this.OnClosing.emit();

                })
                .catch(error => {
                    console.log(error);
                });

        } else
            this.OnClosing.emit(true); //Arkadaki işlemin kaydedi kaydedecek

    }

    onCancelENabiz() //Ekran Tanı ile açıldıysa ve nabız ekranından iptale basıldıysa tanı hastaya eklenmiyor, muayene kaydedilirken açıldığında iptale basılırsa kaydet engellenecek.
    {
        this.OnClosing.emit(false);
    }


    confirmKronikHastaliklar(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();

        let viewModel = nabizModel as KronikHastaliklarFormViewModel;
        if (viewModel._KronikHastaliklarVeriSeti.IlkTaniTarihi == null || viewModel._KronikHastaliklarVeriSeti.IlkTaniTarihi == undefined) {
            result.Result = false;
            result.Message = i18n("M17878", "Kronik Hastalıklar: İlk Tanı Tarihini Giriniz.");
            return result;

        }

        return result;
    }

    confirmMaddeBagimliligi(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();

        let viewModel = nabizModel as MaddeBagimliligiVeriSetiFormViewModel;
        if (viewModel._MaddeBagimliligiVeriSeti.SKRSAlkolKullanimi == null || viewModel._MaddeBagimliligiVeriSeti.SKRSAlkolKullanimi == undefined) {
            result.Result = false;
            result.Message = "Madde Bağımlılığı: Alkol Kullanımı Seçiniz.";
            return result;
        }

        if (viewModel._MaddeBagimliligiVeriSeti.SKRSGonderenBirim == null || viewModel._MaddeBagimliligiVeriSeti.SKRSGonderenBirim == undefined) {
            result.Result = false;
            result.Message = "Madde Bağımlılığı: Gönderen Birim Seçiniz.";
            return result;
        }

        if (viewModel._MaddeBagimliligiVeriSeti.SKRSIsDurumu == null || viewModel._MaddeBagimliligiVeriSeti.SKRSIsDurumu == undefined) {
            result.Result = false;
            result.Message = "Madde Bağımlılığı: İş Durumu Seçiniz.";
            return result;
        }

        if (viewModel._MaddeBagimliligiVeriSeti.SKRSKullanilanMadde == null || viewModel._MaddeBagimliligiVeriSeti.SKRSKullanilanMadde == undefined) {
            result.Result = false;
            result.Message = "Madde Bağımlılığı: Kullanılan Esas Madde Seçiniz.";
            return result;
        }

        if (viewModel._MaddeBagimliligiVeriSeti.SKRSOgrenimDurumu == null || viewModel._MaddeBagimliligiVeriSeti.SKRSOgrenimDurumu == undefined) {
            result.Result = false;
            result.Message = "Madde Bağımlılığı: Öğrenim Durumu Seçiniz.";
            return result;
        }

        if (viewModel._MaddeBagimliligiVeriSeti.SKRSSigaraKullanimi == null || viewModel._MaddeBagimliligiVeriSeti.SKRSSigaraKullanimi == undefined) {
            result.Result = false;
            result.Message = "Madde Bağımlılığı: Sigara Kullanımı Seçiniz.";
            return result;
        }

        if (viewModel._MaddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi == null || viewModel._MaddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi == undefined) {
            result.Result = false;
            result.Message = "Madde Bağımlılığı: Tedavi Merkez Tipi Seçiniz.";
            return result;
        }

        if (viewModel._MaddeBagimliligiVeriSeti.SKRSYasadigiBolge == null || viewModel._MaddeBagimliligiVeriSeti.SKRSYasadigiBolge == undefined) {
            result.Result = false;
            result.Message = "Madde Bağımlılığı: Yaşadığı Bölge Seçiniz.";
            return result;
        }

        if (viewModel._MaddeBagimliligiVeriSeti.SKRSYasamBicimi == null || viewModel._MaddeBagimliligiVeriSeti.SKRSYasamBicimi == undefined) {
            result.Result = false;
            result.Message = "Madde Bağımlılığı: Yaşam Biçimi Seçiniz.";
            return result;
        }

        if (viewModel._MaddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi == null || viewModel._MaddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi == undefined) {
            result.Result = false;
            result.Message = "Madde Bağımlılığı: Enjeksiyon ile Madde Kullanımı Seçiniz.";
            return result;
        }
        return result;
    }

    confirmTutunKullanimi(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();

        let viewModel = nabizModel as TutunKullanimiVeriSetiFormViewModel;
        if (viewModel._TutunKullanimiVeriSeti.TutunKullanimiBagimOldUrun.length < 1) {
            result.Result = false;
            result.Message = "Tütün Kullanımı: En Az 1 Adet Bağımlı Olduğu Ürün Bilgisi Seçiniz.";
            return result;
        } else {
            viewModel._TutunKullanimiVeriSeti.TutunKullanimiBagimOldUrun.forEach(element => {
                let temp = element as TutunKullanimiBagimOldUrun;
                if (temp.SKRSBagimliOlduguUrun == null || temp.SKRSBagimliOlduguUrun == undefined ) {
                    result.Result = false;
                    result.Message = "Tütün Kullanımı: Bağımlı Olduğu Ürün Bilgisini Düzeltiniz.";
                    return result;
                }
            });
        }

        return result;
    }

    confirmKadinaYonelikSiddet(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();

        let viewModel = nabizModel as KadinaYonelikSiddetVeriSetiFormViewModel;
        if (viewModel._KadinaYonelikSiddetVeriSet.KadinaYonelikSiddetSonuc.length < 1) {
            result.Result = false;
            result.Message = "Kadına Yönelik Şiddet: En Az 1 Adet Yönlendirme ve Değerlendirme Bilgisi Seçiniz.";
            return result;
        } else {
            viewModel._KadinaYonelikSiddetVeriSet.KadinaYonelikSiddetSonuc.forEach(element => {
                let temp = element as KadinaYonelikSiddetSonuc;
                if (temp.SKRSYonlendirmeDegerlendirme == null || temp.SKRSYonlendirmeDegerlendirme == undefined ) {
                    result.Result = false;
                    result.Message = "Kadına Yönelik Şiddet: Yönlendirme ve Değerlendirme Bilgisini Düzeltiniz.";
                    return result;
                }
            });
        }
        if (viewModel._KadinaYonelikSiddetVeriSet.KadinaYonelikSiddetTuru.length < 1) {
            result.Result = false;
            result.Message = "Kadına Yönelik Şiddet: En Az 1 Adet Şiddet Türü Bilgisi Seçiniz.";
            return result;
        } else {
            viewModel._KadinaYonelikSiddetVeriSet.KadinaYonelikSiddetTuru.forEach(element => {
                let temp = element as KadinaYonelikSiddetTuru;
                if (temp.SKRSSiddetTuru == null || temp.SKRSSiddetTuru == undefined ) {
                    result.Result = false;
                    result.Message = "Kadına Yönelik Şiddet: Şiddet Türü Bilgisini Düzeltiniz.";
                    return result;
                }
            });
        }

        return result;
    }

    confirmIntiharGirisimiKrizTespit(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();

        let viewModel = nabizModel as IntiharGirisimiKrizTespitVeriSetiFormViewModel;
        if (viewModel._IntiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka == null || viewModel._IntiharGirisimKrizVeriSeti.SKRSAilesindePsikiyatrikVaka == undefined) {
            result.Result = false;
            result.Message = "İntihar Girişimi ve Kriz Tespit: Ailesinde Psikiyatrik Vaka Seçiniz.";
            return result;
        }

        if (viewModel._IntiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru == null || viewModel._IntiharGirisimKrizVeriSeti.SKRSIntiharKrizVakaTuru == undefined) {
            result.Result = false;
            result.Message = "İntihar Girişimi ve Kriz Tespit: İntihar Kriz Vaka Türü Seçiniz.";
            return result;
        }


        if (viewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiKrizNedeni.length < 1) {
            result.Result = false;
            result.Message = "İntihar Girişimi ve Kriz Tespit: En Az 1 Adet İntihar Girişim Nedeni Seçiniz.";
            return result;
        } else {
            viewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiKrizNedeni.forEach(element => {
                let temp = element as IntiharGirisimiKrizNedeni;
                if (temp.SKRSIntiharGirisimKrizNeden == null || temp.SKRSIntiharGirisimKrizNeden == undefined ) {
                    result.Result = false;
                    result.Message = "İntihar Girişimi ve Kriz Tespit: İntihar Girişim Nedeni Bilgisini Düzeltiniz.";
                    return result;
                }
            });
        }
        if (viewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiVakaSonucu.length < 1) {
            result.Result = false;
            result.Message = "İntihar Girişimi ve Kriz Tespit: En Az 1 Adet Vaka Sonucu Seçiniz.";
            return result;
        } else {
            viewModel._IntiharGirisimKrizVeriSeti.IntiharGirisimiVakaSonucu.forEach(element => {
                let temp = element as IntiharGirisimiVakaSonucu;
                if (temp.SKRSIntiharKrizVakaSonucu == null || temp.SKRSIntiharKrizVakaSonucu == undefined ) {
                    result.Result = false;
                    result.Message = "İntihar Girişimi ve Kriz Tespit: Vaka Sonucu Bilgisini Düzeltiniz.";
                    return result;
                }
            });
        }

        return result;
    }



    confirmKKuduzRiskliTemas(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();

        let viewModel = nabizModel as KuduzRiskliTemasVeriSetiFormViewModel;
        if (viewModel._KuduzRiskliTemasVeriSeti.SKRSKategorizasyon == null || viewModel._KuduzRiskliTemasVeriSeti.SKRSKategorizasyon == undefined) {
            result.Result = false;
            result.Message = "Kuduz Riskli Temas: Kategorizasyon Seçiniz.";
            return result;
        }

        if (viewModel._KuduzRiskliTemasVeriSeti.SKRSKuduzRiskliTemasDegDurumu == null || viewModel._KuduzRiskliTemasVeriSeti.SKRSKuduzRiskliTemasDegDurumu == undefined) {
            result.Result = false;
            result.Message = "Kuduz Riskli Temas: Riskli Temas Değerlendirme Durumu Seçiniz.";
            return result;
        }

        if (viewModel._KuduzRiskliTemasVeriSeti.RiskliTemasTarihi == null || viewModel._KuduzRiskliTemasVeriSeti.RiskliTemasTarihi == undefined) {
            result.Result = false;
            result.Message = "Kuduz Riskli Temas: Riskli Temas Tarihini Seçiniz.";
            return result;
        }

        if (viewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasAdres.length < 1) {
            result.Result = false;
            result.Message = "Kuduz Riskli Temas: Adres Bilgisi Giriniz.";
            return result;
        }
        if (viewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasPlanProfBi.length < 1) {
            result.Result = false;
            result.Message = "Kuduz Riskli Temas: En Az 1 Adet Planlanan Profilaksi Bilgisi Seçiniz.";
            return result;
        } else {
            viewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasPlanProfBi.forEach(element => {
                let temp = element as KuduzRiskliTemasPlanProfBi;
                if (temp.SKRSKisiyePlanKuduzProfilaksi == null || temp.SKRSKisiyePlanKuduzProfilaksi == undefined ) {
                    result.Result = false;
                    result.Message = "Kuduz Riskli Temas: Planlanan Profilaksi Bilgisini Düzeltiniz.";
                    return result;
                }
            });
        }
        if (viewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip.length < 1) {
            result.Result = false;
            result.Message = "Kuduz Riskli Temas: En Az 1 Adet Riskli Temas Tipi Bilgisi Seçiniz.";
            return result;
        } else {
            viewModel._KuduzRiskliTemasVeriSeti.KuduzRiskliTemasRiskTemTip.forEach(element => {
                let temp = element as KuduzRiskliTemasRiskTemTip;
                if (temp.SKRSRiskliTemasTipi == null || temp.SKRSRiskliTemasTipi == undefined ) {
                    result.Result = false;
                    result.Message = "Kuduz Riskli Temas: Riskli Temas Tipi Bilgisini Düzeltiniz.";
                    return result;
                }
            });
        }

        return result;
    }

    confirmKuduzProfilaksi(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();

        let viewModel = nabizModel as KuduzProfilaksiIzlemFormViewModel;
        if (viewModel._KuduzProfilaksiVeriSeti.SKRSKuduzProfilaksiTamamlanma == null || viewModel._KuduzProfilaksiVeriSeti.SKRSKuduzProfilaksiTamamlanma == undefined) {
            result.Result = false;
            result.Message = "Kuduz Profilaksi: Sonlandırma Durumu Seçiniz.";
            return result;
        }
        

        if (viewModel._KuduzProfilaksiVeriSeti.KuduzProfilaksiUygProfilak.length < 1) {
            result.Result = false;
            result.Message = "Kuduz Profilaksi: Uygulanan Kuduz Profilaksisi Seçiniz.";
            return result;
        } else {
            viewModel._KuduzProfilaksiVeriSeti.KuduzProfilaksiUygProfilak.forEach(element => {
                let temp = element as KuduzProfilaksiUygProfilak;
                if (temp.SKRSUygulananKuduzProfilaksi == null || temp.SKRSUygulananKuduzProfilaksi == undefined ) {
                    result.Result = false;
                    result.Message = "Kuduz Profilaksi: Uygulanan Kuduz Profilaksisi Bilgisini Düzeltiniz.";
                    return result;
                }
            });

        }

        return result;
    }

    confirmBulasiciHastaliklar(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();
        let viewModel = nabizModel as BulasiciHastaliklarNewFormViewModel;

        if (viewModel._BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi == null || viewModel._BulasiciHastalikVeriSeti.BelirtilerinBaslamaTarihi == undefined) {
            result.Result = false;
            result.Message = i18n("M12109", "Bulaşıcı Hastalıklar: Belirtilerin Başlama Tarihini Giriniz.");
            return result;
        }

        if (viewModel._BulasiciHastalikVeriSeti.SKRSVakaTipi == null || viewModel._BulasiciHastalikVeriSeti.SKRSVakaTipi == undefined) {
            result.Result = false;
            result.Message = i18n("M12120", "Bulaşıcı Hastalıklar: Vaka Tipini Seçiniz.");
            return result;
        }

        if (viewModel._BulasiciHastalikVeriSeti.VakaDurum == null || viewModel._BulasiciHastalikVeriSeti.SKRSVakaTipi == undefined){
            result.Result = false;
            result.Message = i18n("M30545", "Bulaşıcı Hastalıklar: Vaka Durumunu Seçiniz.");
            return result;
        }
        /*if (viewModel._BulasiciHastalikVeriSeti.SKRSICD == null || viewModel._BulasiciHastalikVeriSeti.SKRSICD == undefined) {
            result.Result = false;
            result.Message = "Bulaşıcı Hastalıklar: Tanı Seçiniz.";
            return result;
        }
*/
        if (viewModel._BulasiciHastalikVeriSeti.ResponsibleDoctor == null || viewModel._BulasiciHastalikVeriSeti.ResponsibleDoctor == undefined) {
            result.Result = false;
            result.Message = i18n("M12118", "Bulaşıcı Hastalıklar: Sorumlu Doktoru Seçiniz.");
            return result;
        }

        //Nabızda alanların zorunluluğu kaldırıldığı için kapatıldı.
        /*if (viewModel._BulasiciHastalikVeriSeti.Beyan_Il == null || viewModel._BulasiciHastalikVeriSeti.Beyan_Il == undefined) {
            result.Result = false;
            result.Message = i18n("M12114", "Bulaşıcı Hastalıklar: Beyan Adresi İl Bilgisini Seçiniz.");
            return result;
        }

        if (viewModel._BulasiciHastalikVeriSeti.Beyan_Ilce == null || viewModel._BulasiciHastalikVeriSeti.Beyan_Ilce == undefined) {
            result.Result = false;
            result.Message = i18n("M12115", "Bulaşıcı Hastalıklar: Beyan Adresi İlçe Bilgisini Seçiniz.");
            return result;
        }

        if (viewModel._BulasiciHastalikVeriSeti.Beyan_Bucak == null || viewModel._BulasiciHastalikVeriSeti.Beyan_Bucak == undefined) {
            result.Result = false;
            result.Message = i18n("M12110", "Bulaşıcı Hastalıklar: Beyan Adresi Bucak Bilgisini Seçiniz.");
            return result;
        }

        if (viewModel._BulasiciHastalikVeriSeti.Beyan_Koy == null || viewModel._BulasiciHastalikVeriSeti.Beyan_Koy == undefined) {
            result.Result = false;
            result.Message = i18n("M12116", "Bulaşıcı Hastalıklar: Beyan Adresi Köy Bilgisini Seçiniz.");
            return result;
        }

        if (viewModel._BulasiciHastalikVeriSeti.Beyan_Mahalle == null || viewModel._BulasiciHastalikVeriSeti.Beyan_Mahalle == undefined) {
            result.Result = false;
            result.Message = i18n("M12117", "Bulaşıcı Hastalıklar: Beyan Adresi Mahalle Bilgisini Seçiniz.");
            return result;
        }

        if (viewModel._BulasiciHastalikVeriSeti.Beyan_CSBM == null || viewModel._BulasiciHastalikVeriSeti.Beyan_CSBM == undefined) {
            result.Result = false;
            result.Message = i18n("M12111", "Bulaşıcı Hastalıklar: Beyan Adresi CSBM Tipini Seçiniz.");
            return result;
        }

        if (viewModel._BulasiciHastalikVeriSeti.DisKapiNoBeyan == null || viewModel._BulasiciHastalikVeriSeti.DisKapiNoBeyan == undefined) {
            result.Result = false;
            result.Message = i18n("M12112", "Bulaşıcı Hastalıklar: Beyan Adresi Dış Kapı No Giriniz.");
            return result;
        }

        if (viewModel._BulasiciHastalikVeriSeti.IcKapiNoBeyan == null || viewModel._BulasiciHastalikVeriSeti.IcKapiNoBeyan == undefined) {
            result.Result = false;
            result.Message = i18n("M12113", "Bulaşıcı Hastalıklar: Beyan Adresi İç Kapı No Giriniz.");
            return result;
        }*/

        return result;
    }

    confirmDiyabet(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();
        let viewModel = nabizModel as DiyabetFormViewModel;

        if (viewModel._DiyabetVeriSeti.IlkTaniTarihi == null || viewModel._DiyabetVeriSeti.IlkTaniTarihi == undefined) {
            result.Result = false;
            result.Message = i18n("M12989", "Diyabet: İlk Tanı Tarihini Giriniz.");
            return result;
        }

        if (viewModel._DiyabetVeriSeti.Boy == null || viewModel._DiyabetVeriSeti.Boy == undefined) {
            result.Result = false;
            result.Message = i18n("M12987", "Diyabet: Boy Bilgisini Giriniz.");
            return result;
        }

        if (viewModel._DiyabetVeriSeti.Kilo == null || viewModel._DiyabetVeriSeti.Kilo == undefined) {
            result.Result = false;
            result.Message = i18n("M12990", "Diyabet: Kilo Bilgisini Giriniz.");
            return result;
        }

        if (viewModel._DiyabetVeriSeti.DiyabetKompBilgisi == null || viewModel._DiyabetVeriSeti.DiyabetKompBilgisi == undefined || viewModel._DiyabetVeriSeti.DiyabetKompBilgisi.length == 0) {
            result.Result = false;
            result.Message = i18n("M12988", "Diyabet: Diyabet Komplikasyonlarını Seçiniz.");
            return result;
        }

        return result;
    }

    confirmObezite(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();
        let viewModel = nabizModel as ObeziteIzlemFormViewModel;

        if (viewModel._ObeziteIzlemVeriSeti.DiyetTibbiBeslenmeTedavisi == null || viewModel._ObeziteIzlemVeriSeti.DiyetTibbiBeslenmeTedavisi == undefined) {
            result.Result = false;
            result.Message = i18n("M19593", "Obezite: Diyet Tıbbi Beslenme Tedavisini Seçiniz.");
            return result;
        }

        if (viewModel._ObeziteIzlemVeriSeti.IlkTaniTarihi == null || viewModel._ObeziteIzlemVeriSeti.IlkTaniTarihi == undefined) {
            result.Result = false;
            result.Message = i18n("M19596", "Obezite: İlk Tanı Tarihini Giriniz.");
            return result;
        }

        if (viewModel._ObeziteIzlemVeriSeti.SKRSObeziteIlacTedavisi == null || viewModel._ObeziteIzlemVeriSeti.SKRSObeziteIlacTedavisi == undefined) {
            result.Result = false;
            result.Message = i18n("M19595", "Obezite: İlaç Tedavisini Seçiniz.");
            return result;
        }

        if (viewModel._ObeziteIzlemVeriSeti.SKRSPsikolojikTedavi == null || viewModel._ObeziteIzlemVeriSeti.SKRSPsikolojikTedavi == undefined) {
            result.Result = false;
            result.Message = i18n("M19597", "Obezite: Psikolojik Tedavi Bilgisini Seçiniz.");
            return result;
        }

        if (viewModel._ObeziteIzlemVeriSeti.ObeziteEgzersiz == null || viewModel._ObeziteIzlemVeriSeti.ObeziteEgzersiz == undefined) {
            result.Result = false;
            result.Message = i18n("M19594", "Obezite: Egzersiz Bilgisini Seçiniz.");
            return result;
        }

        return result;
    }

    confirmVerem(nabizModel: any): ConfirmObject {
        let result: ConfirmObject = new ConfirmObject();
        let viewModel = nabizModel as VeremVeriSetiFormViewModel;

        if (viewModel._VeremVeriSeti.SKRSVeremHastasiTedaviYontemi == null || viewModel._VeremVeriSeti.SKRSVeremHastasiTedaviYontemi == undefined) {
            result.Result = false;
            result.Message = "Verem: Verem Hastası Tedavi Yöntemini Seçiniz.";
            return result;
        }

        if (viewModel._VeremVeriSeti.VeremIlacBilgisi.length > 0) {
            viewModel._VeremVeriSeti.VeremIlacBilgisi.forEach(element => {
                if (element.SKRSIlacAdiVerem == null || element.SKRSIlacDirenciVerem == null) {
                    result.Result = false;
                    result.Message = "Verem: Verem Hastası Verem İlaç Bilgisinde Boş alan bırakmayınız.";
                    return result;
                }
            });
        }

        return result;
    }

}

export class ConfirmObject {
    public Result: boolean = true;
    public Message: string = "";
}