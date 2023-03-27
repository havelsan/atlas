//$575A18A5
import { Component, OnInit, NgZone } from '@angular/core';
import { EvdeSaglikIzlemFormViewModel } from './EvdeSaglikIzlemFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EvdeSaglikIzlemVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { BirSonrakiHizmetIhtiyaci } from 'NebulaClient/Model/AtlasClientModel';
import { PsikolojikDurum } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAgri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBasiDegerlendirmesi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBeslenme } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSEvdeSaglikHizmetininSonlandirilmasi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSEvdeSaglikHizmetleriHastaNakli } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { VerilenEgitimler } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'EvdeSaglikIzlemForm',
    templateUrl: './EvdeSaglikIzlemForm.html',
    providers: [MessageService]
})
export class EvdeSaglikIzlemForm extends TTVisual.TTForm implements OnInit {
    BirSonrakiHizmetIhtiyaci: TTVisual.ITTGrid;
    labelSKRSAgri: TTVisual.ITTLabel;
    labelSKRSBasiDegerlendirmesi: TTVisual.ITTLabel;
    labelSKRSBeslenme: TTVisual.ITTLabel;
    labelSKRSHastaNakli: TTVisual.ITTLabel;
    labelSKRSHizmetinSonlandirilmasi: TTVisual.ITTLabel;
    labelSKRSIl: TTVisual.ITTLabel;
    PsikolojikDurum: TTVisual.ITTGrid;
    SKRSAgri: TTVisual.ITTObjectListBox;
    SKRSBasiDegerlendirmesi: TTVisual.ITTObjectListBox;
    SKRSBeslenme: TTVisual.ITTObjectListBox;
    SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci: TTVisual.ITTListBoxColumn;
    SKRSHastaNakli: TTVisual.ITTObjectListBox;
    SKRSHizmetinSonlandirilmasi: TTVisual.ITTObjectListBox;
    SKRSIl: TTVisual.ITTObjectListBox;
    SKRSPsikolojikDurumPsikolojikDurum: TTVisual.ITTListBoxColumn;
    SKRSVerilenEgitimlerVerilenEgitimler: TTVisual.ITTListBoxColumn;
    VerilenEgitimler: TTVisual.ITTGrid;
    RouteData2: any;
    public BirSonrakiHizmetIhtiyaciColumns = [];
    public PsikolojikDurumColumns = [];
    public VerilenEgitimlerColumns = [];
    public evdeSaglikIzlemFormViewModel: EvdeSaglikIzlemFormViewModel = new EvdeSaglikIzlemFormViewModel();
    public get _EvdeSaglikIzlemVeriSeti(): EvdeSaglikIzlemVeriSeti {
        return this._TTObject as EvdeSaglikIzlemVeriSeti;
    }
    private EvdeSaglikIzlemForm_DocumentUrl: string = '/api/EvdeSaglikIzlemVeriSetiService/EvdeSaglikIzlemForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('EVDESAGLIKIZLEMVERISETI', 'EvdeSaglikIzlemForm');
        this._DocumentServiceUrl = this.EvdeSaglikIzlemForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EvdeSaglikIzlemVeriSeti();
        this.evdeSaglikIzlemFormViewModel = new EvdeSaglikIzlemFormViewModel();
        this._ViewModel = this.evdeSaglikIzlemFormViewModel;
        this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti = this._TTObject as EvdeSaglikIzlemVeriSeti;
        this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.BirSonrakiHizmetIhtiyaci = new Array<BirSonrakiHizmetIhtiyaci>();
        this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.VerilenEgitimler = new Array<VerilenEgitimler>();
        this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.PsikolojikDurum = new Array<PsikolojikDurum>();
        this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSIl = new SKRSILKodlari();
        this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSHastaNakli = new SKRSEvdeSaglikHizmetleriHastaNakli();
        this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSHizmetinSonlandirilmasi = new SKRSEvdeSaglikHizmetininSonlandirilmasi();
        this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSBeslenme = new SKRSBeslenme();
        this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSBasiDegerlendirmesi = new SKRSBasiDegerlendirmesi();
        this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSAgri = new SKRSAgri();
    }

    protected loadViewModel() {
        let that = this;

        that.evdeSaglikIzlemFormViewModel = this._ViewModel as EvdeSaglikIzlemFormViewModel;
        that._TTObject = this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti;
        if (this.evdeSaglikIzlemFormViewModel == null)
            this.evdeSaglikIzlemFormViewModel = new EvdeSaglikIzlemFormViewModel();
        if (this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti == null)
            this.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti = new EvdeSaglikIzlemVeriSeti();
        that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.BirSonrakiHizmetIhtiyaci = that.evdeSaglikIzlemFormViewModel.BirSonrakiHizmetIhtiyaciGridList;
        for (let detailItem of that.evdeSaglikIzlemFormViewModel.BirSonrakiHizmetIhtiyaciGridList) {
            let sKRSBirSonrakiHizmetIhtiyaciObjectID = detailItem["SKRSBirSonrakiHizmetIhtiyaci"];
            if (sKRSBirSonrakiHizmetIhtiyaciObjectID != null && (typeof sKRSBirSonrakiHizmetIhtiyaciObjectID === 'string')) {
                let sKRSBirSonrakiHizmetIhtiyaci = that.evdeSaglikIzlemFormViewModel.SKRSBirSonrakiHizmetIhtiyacis.find(o => o.ObjectID.toString() === sKRSBirSonrakiHizmetIhtiyaciObjectID.toString());
                 if (sKRSBirSonrakiHizmetIhtiyaci) {
                    detailItem.SKRSBirSonrakiHizmetIhtiyaci = sKRSBirSonrakiHizmetIhtiyaci;
                }
            }
        }
        that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.VerilenEgitimler = that.evdeSaglikIzlemFormViewModel.VerilenEgitimlerGridList;
        for (let detailItem of that.evdeSaglikIzlemFormViewModel.VerilenEgitimlerGridList) {
            let sKRSVerilenEgitimlerObjectID = detailItem["SKRSVerilenEgitimler"];
            if (sKRSVerilenEgitimlerObjectID != null && (typeof sKRSVerilenEgitimlerObjectID === 'string')) {
                let sKRSVerilenEgitimler = that.evdeSaglikIzlemFormViewModel.SKRSVerilenEgitimlers.find(o => o.ObjectID.toString() === sKRSVerilenEgitimlerObjectID.toString());
                 if (sKRSVerilenEgitimler) {
                    detailItem.SKRSVerilenEgitimler = sKRSVerilenEgitimler;
                }
            }
        }
        that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.PsikolojikDurum = that.evdeSaglikIzlemFormViewModel.PsikolojikDurumGridList;
        for (let detailItem of that.evdeSaglikIzlemFormViewModel.PsikolojikDurumGridList) {
            let sKRSPsikolojikDurumObjectID = detailItem["SKRSPsikolojikDurum"];
            if (sKRSPsikolojikDurumObjectID != null && (typeof sKRSPsikolojikDurumObjectID === 'string')) {
                let sKRSPsikolojikDurum = that.evdeSaglikIzlemFormViewModel.SKRSPsikolojikDurumDegerlendirmesis.find(o => o.ObjectID.toString() === sKRSPsikolojikDurumObjectID.toString());
                 if (sKRSPsikolojikDurum) {
                    detailItem.SKRSPsikolojikDurum = sKRSPsikolojikDurum;
                }
            }
        }
        let sKRSIlObjectID = that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti["SKRSIl"];
        if (sKRSIlObjectID != null && (typeof sKRSIlObjectID === 'string')) {
            let sKRSIl = that.evdeSaglikIzlemFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === sKRSIlObjectID.toString());
             if (sKRSIl) {
                that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSIl = sKRSIl;
            }
        }
        let sKRSHastaNakliObjectID = that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti["SKRSHastaNakli"];
        if (sKRSHastaNakliObjectID != null && (typeof sKRSHastaNakliObjectID === 'string')) {
            let sKRSHastaNakli = that.evdeSaglikIzlemFormViewModel.SKRSEvdeSaglikHizmetleriHastaNaklis.find(o => o.ObjectID.toString() === sKRSHastaNakliObjectID.toString());
             if (sKRSHastaNakli) {
                that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSHastaNakli = sKRSHastaNakli;
            }
        }
        let sKRSHizmetinSonlandirilmasiObjectID = that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti["SKRSHizmetinSonlandirilmasi"];
        if (sKRSHizmetinSonlandirilmasiObjectID != null && (typeof sKRSHizmetinSonlandirilmasiObjectID === 'string')) {
            let sKRSHizmetinSonlandirilmasi = that.evdeSaglikIzlemFormViewModel.SKRSEvdeSaglikHizmetininSonlandirilmasis.find(o => o.ObjectID.toString() === sKRSHizmetinSonlandirilmasiObjectID.toString());
             if (sKRSHizmetinSonlandirilmasi) {
                that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSHizmetinSonlandirilmasi = sKRSHizmetinSonlandirilmasi;
            }
        }
        let sKRSBeslenmeObjectID = that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti["SKRSBeslenme"];
        if (sKRSBeslenmeObjectID != null && (typeof sKRSBeslenmeObjectID === 'string')) {
            let sKRSBeslenme = that.evdeSaglikIzlemFormViewModel.SKRSBeslenmes.find(o => o.ObjectID.toString() === sKRSBeslenmeObjectID.toString());
             if (sKRSBeslenme) {
                that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSBeslenme = sKRSBeslenme;
            }
        }
        let sKRSBasiDegerlendirmesiObjectID = that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti["SKRSBasiDegerlendirmesi"];
        if (sKRSBasiDegerlendirmesiObjectID != null && (typeof sKRSBasiDegerlendirmesiObjectID === 'string')) {
            let sKRSBasiDegerlendirmesi = that.evdeSaglikIzlemFormViewModel.SKRSBasiDegerlendirmesis.find(o => o.ObjectID.toString() === sKRSBasiDegerlendirmesiObjectID.toString());
             if (sKRSBasiDegerlendirmesi) {
                that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSBasiDegerlendirmesi = sKRSBasiDegerlendirmesi;
            }
        }
        let sKRSAgriObjectID = that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti["SKRSAgri"];
        if (sKRSAgriObjectID != null && (typeof sKRSAgriObjectID === 'string')) {
            let sKRSAgri = that.evdeSaglikIzlemFormViewModel.SKRSAgris.find(o => o.ObjectID.toString() === sKRSAgriObjectID.toString());
             if (sKRSAgri) {
                that.evdeSaglikIzlemFormViewModel._EvdeSaglikIzlemVeriSeti.SKRSAgri = sKRSAgri;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        if (this.RouteData2 != null){
            this.ObjectID = this.RouteData2.ObjectID;
            this.ActiveIDsModel = new ActiveIDsModel(this.RouteData2.EpisodeActionID, null, null);
       
        }
        await this.load(EvdeSaglikIzlemFormViewModel);
  
    }


    public onSKRSAgriChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIzlemVeriSeti != null && this._EvdeSaglikIzlemVeriSeti.SKRSAgri != event) {
                this._EvdeSaglikIzlemVeriSeti.SKRSAgri = event;
            }
        }
    }

    public onSKRSBasiDegerlendirmesiChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIzlemVeriSeti != null && this._EvdeSaglikIzlemVeriSeti.SKRSBasiDegerlendirmesi != event) {
                this._EvdeSaglikIzlemVeriSeti.SKRSBasiDegerlendirmesi = event;
            }
        }
    }

    public onSKRSBeslenmeChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIzlemVeriSeti != null && this._EvdeSaglikIzlemVeriSeti.SKRSBeslenme != event) {
                this._EvdeSaglikIzlemVeriSeti.SKRSBeslenme = event;
            }
        }
    }

    public onSKRSHastaNakliChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIzlemVeriSeti != null && this._EvdeSaglikIzlemVeriSeti.SKRSHastaNakli != event) {
                this._EvdeSaglikIzlemVeriSeti.SKRSHastaNakli = event;
            }
        }
    }

    public onSKRSHizmetinSonlandirilmasiChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIzlemVeriSeti != null && this._EvdeSaglikIzlemVeriSeti.SKRSHizmetinSonlandirilmasi != event) {
                this._EvdeSaglikIzlemVeriSeti.SKRSHizmetinSonlandirilmasi = event;
            }
        }
    }

    public onSKRSIlChanged(event): void {
        if (event != null) {
            if (this._EvdeSaglikIzlemVeriSeti != null && this._EvdeSaglikIzlemVeriSeti.SKRSIl != event) {
                this._EvdeSaglikIzlemVeriSeti.SKRSIl = event;
            }
        }
    }



    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        //this.BirSonrakiHizmetIhtiyaci = new TTVisual.TTGrid();
        //this.BirSonrakiHizmetIhtiyaci.Name = "BirSonrakiHizmetIhtiyaci";
        //this.BirSonrakiHizmetIhtiyaci.TabIndex = 14;

        this.BirSonrakiHizmetIhtiyaci = new TTVisual.TTGrid();
        this.BirSonrakiHizmetIhtiyaci.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BirSonrakiHizmetIhtiyaci.Name = "BirSonrakiHizmetIhtiyaci";
        this.BirSonrakiHizmetIhtiyaci.TabIndex = 0;
        this.BirSonrakiHizmetIhtiyaci.Height = "150px";
        this.BirSonrakiHizmetIhtiyaci.ShowFilterCombo = true;
        this.BirSonrakiHizmetIhtiyaci.FilterColumnName = "SKRSBirSonrakiHizmetIhtiyaci";
        this.BirSonrakiHizmetIhtiyaci.FilterLabel = i18n("M11843", "Bir Sonraki Hizmet İhtiyacı");
        this.BirSonrakiHizmetIhtiyaci.Filter = { ListDefName: "SKRSBirSonrakiHizmetIhtiyaciList" };
        this.BirSonrakiHizmetIhtiyaci.AllowUserToAddRows = false;
        this.BirSonrakiHizmetIhtiyaci.DeleteButtonWidth = "5%";
        this.BirSonrakiHizmetIhtiyaci.AllowUserToDeleteRows = true;

        this.SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci = new TTVisual.TTListBoxColumn();
        this.SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci.ListDefName = "SKRSBirSonrakiHizmetIhtiyaciList";
        this.SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci.DataMember = "SKRSBirSonrakiHizmetIhtiyaci";
        this.SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci.DisplayIndex = 0;
        this.SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci.HeaderText = i18n("M11843", "Bir Sonraki Hizmet İhtiyacı");
        this.SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci.Name = "SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci";
        this.SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci.Width = "90%";

        //this.VerilenEgitimler = new TTVisual.TTGrid();
        //this.VerilenEgitimler.Name = "VerilenEgitimler";
        //this.VerilenEgitimler.TabIndex = 13;

        this.VerilenEgitimler = new TTVisual.TTGrid();
        this.VerilenEgitimler.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.VerilenEgitimler.Name = "VerilenEgitimler";
        this.VerilenEgitimler.TabIndex = 0;
        this.VerilenEgitimler.Height = "150px";
        this.VerilenEgitimler.ShowFilterCombo = true;
        this.VerilenEgitimler.FilterColumnName = "SKRSVerilenEgitimler";
        this.VerilenEgitimler.FilterLabel = i18n("M24107", "Verilen Eğitimler");
        this.VerilenEgitimler.Filter = { ListDefName: "SKRSVerilenEgitimlerList" };
        this.VerilenEgitimler.AllowUserToAddRows = false;
        this.VerilenEgitimler.DeleteButtonWidth = "5%";
        this.VerilenEgitimler.AllowUserToDeleteRows = true;

        this.SKRSVerilenEgitimlerVerilenEgitimler = new TTVisual.TTListBoxColumn();
        this.SKRSVerilenEgitimlerVerilenEgitimler.ListDefName = "SKRSVerilenEgitimlerList";
        this.SKRSVerilenEgitimlerVerilenEgitimler.DataMember = "SKRSVerilenEgitimler";
        this.SKRSVerilenEgitimlerVerilenEgitimler.DisplayIndex = 0;
        this.SKRSVerilenEgitimlerVerilenEgitimler.HeaderText = i18n("M24107", "Verilen Eğitimler");
        this.SKRSVerilenEgitimlerVerilenEgitimler.Name = "SKRSVerilenEgitimlerVerilenEgitimler";
        this.SKRSVerilenEgitimlerVerilenEgitimler.Width = "90%";

        //this.PsikolojikDurum = new TTVisual.TTGrid();
        //this.PsikolojikDurum.Name = "PsikolojikDurum";
        //this.PsikolojikDurum.TabIndex = 12;

        this.PsikolojikDurum = new TTVisual.TTGrid();
        this.PsikolojikDurum.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PsikolojikDurum.Name = "PsikolojikDurum";
        this.PsikolojikDurum.TabIndex = 0;
        this.PsikolojikDurum.Height = "150px";
        this.PsikolojikDurum.ShowFilterCombo = true;
        this.PsikolojikDurum.FilterColumnName = "SKRSPsikolojikDurum";
        this.PsikolojikDurum.FilterLabel = i18n("M20609", "Psikolojik Durum Değerlendirmesi");
        this.PsikolojikDurum.Filter = { ListDefName: "SKRSPsikolojikDurumDegerlendirmesiList" };
        this.PsikolojikDurum.AllowUserToAddRows = false;
        this.PsikolojikDurum.DeleteButtonWidth = "5%";
        this.PsikolojikDurum.AllowUserToDeleteRows = true;

        this.SKRSPsikolojikDurumPsikolojikDurum = new TTVisual.TTListBoxColumn();
        this.SKRSPsikolojikDurumPsikolojikDurum.ListDefName = "SKRSPsikolojikDurumDegerlendirmesiList";
        this.SKRSPsikolojikDurumPsikolojikDurum.DataMember = "SKRSPsikolojikDurum";
        this.SKRSPsikolojikDurumPsikolojikDurum.DisplayIndex = 0;
        this.SKRSPsikolojikDurumPsikolojikDurum.HeaderText = i18n("M20609", "Psikolojik Durum Değerlendirmesi");
        this.SKRSPsikolojikDurumPsikolojikDurum.Name = "SKRSPsikolojikDurumPsikolojikDurum";
        this.SKRSPsikolojikDurumPsikolojikDurum.Width = "90%";

        this.labelSKRSIl = new TTVisual.TTLabel();
        this.labelSKRSIl.Text = i18n("M15830", "Hizmet Alınacak İl");
        this.labelSKRSIl.Name = "labelSKRSIl";
        this.labelSKRSIl.TabIndex = 11;

        this.SKRSIl = new TTVisual.TTObjectListBox();
        this.SKRSIl.ListDefName = "SKRSILKodlariList";
        this.SKRSIl.Name = "SKRSIl";
        this.SKRSIl.TabIndex = 10;

        this.labelSKRSHastaNakli = new TTVisual.TTLabel();
        this.labelSKRSHastaNakli.Text = i18n("M14000", "Evde Sağlık Hizmetleri Hasta Nakli");
        this.labelSKRSHastaNakli.Name = "labelSKRSHastaNakli";
        this.labelSKRSHastaNakli.TabIndex = 9;

        this.SKRSHastaNakli = new TTVisual.TTObjectListBox();
        this.SKRSHastaNakli.Required = true;
        this.SKRSHastaNakli.ListDefName = "SKRSEvdeSaglikHizmetleriHastaNakliList";
        this.SKRSHastaNakli.Name = "SKRSHastaNakli";
        this.SKRSHastaNakli.TabIndex = 8;

        this.labelSKRSHizmetinSonlandirilmasi = new TTVisual.TTLabel();
        this.labelSKRSHizmetinSonlandirilmasi.Text = i18n("M13997", "Evde Sağlık Hizmetinin Sonlandırılması");
        this.labelSKRSHizmetinSonlandirilmasi.Name = "labelSKRSHizmetinSonlandirilmasi";
        this.labelSKRSHizmetinSonlandirilmasi.TabIndex = 7;

        this.SKRSHizmetinSonlandirilmasi = new TTVisual.TTObjectListBox();
        this.SKRSHizmetinSonlandirilmasi.ListDefName = "SKRSEvdeSaglikHizmetininSonlandirilmasiList";
        this.SKRSHizmetinSonlandirilmasi.Name = "SKRSHizmetinSonlandirilmasi";
        this.SKRSHizmetinSonlandirilmasi.TabIndex = 6;

        this.labelSKRSBeslenme = new TTVisual.TTLabel();
        this.labelSKRSBeslenme.Text = i18n("M11763", "Beslenme");
        this.labelSKRSBeslenme.Name = "labelSKRSBeslenme";
        this.labelSKRSBeslenme.TabIndex = 5;

        this.SKRSBeslenme = new TTVisual.TTObjectListBox();
        this.SKRSBeslenme.ListDefName = "SKRSBeslenmeList";
        this.SKRSBeslenme.Name = "SKRSBeslenme";
        this.SKRSBeslenme.TabIndex = 4;

        this.labelSKRSBasiDegerlendirmesi = new TTVisual.TTLabel();
        this.labelSKRSBasiDegerlendirmesi.Text = "Bası Değerlendirmesi";
        this.labelSKRSBasiDegerlendirmesi.Name = "labelSKRSBasiDegerlendirmesi";
        this.labelSKRSBasiDegerlendirmesi.TabIndex = 3;

        this.SKRSBasiDegerlendirmesi = new TTVisual.TTObjectListBox();
        this.SKRSBasiDegerlendirmesi.Required = true;
        this.SKRSBasiDegerlendirmesi.ListDefName = "SKRSBasiDegerlendirmesiList";
        this.SKRSBasiDegerlendirmesi.Name = "SKRSBasiDegerlendirmesi";
        this.SKRSBasiDegerlendirmesi.TabIndex = 2;

        this.labelSKRSAgri = new TTVisual.TTLabel();
        this.labelSKRSAgri.Text = i18n("M10575", "Ağrı");
        this.labelSKRSAgri.Name = "labelSKRSAgri";
        this.labelSKRSAgri.TabIndex = 1;

        this.SKRSAgri = new TTVisual.TTObjectListBox();
        this.SKRSAgri.Required = true;
        this.SKRSAgri.ListDefName = "SKRSAgriList";
        this.SKRSAgri.Name = "SKRSAgri";
        this.SKRSAgri.TabIndex = 0;

        this.BirSonrakiHizmetIhtiyaciColumns = [this.SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci];
        this.VerilenEgitimlerColumns = [this.SKRSVerilenEgitimlerVerilenEgitimler];
        this.PsikolojikDurumColumns = [this.SKRSPsikolojikDurumPsikolojikDurum];
        this.Controls = [this.BirSonrakiHizmetIhtiyaci, this.SKRSBirSonrakiHizmetIhtiyaciBirSonrakiHizmetIhtiyaci, this.VerilenEgitimler, this.SKRSVerilenEgitimlerVerilenEgitimler, this.PsikolojikDurum, this.SKRSPsikolojikDurumPsikolojikDurum, this.labelSKRSIl, this.SKRSIl, this.labelSKRSHastaNakli, this.SKRSHastaNakli, this.labelSKRSHizmetinSonlandirilmasi, this.SKRSHizmetinSonlandirilmasi, this.labelSKRSBeslenme, this.SKRSBeslenme, this.labelSKRSBasiDegerlendirmesi, this.SKRSBasiDegerlendirmesi, this.labelSKRSAgri, this.SKRSAgri];

    }


}
