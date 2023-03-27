//$1EBFC272
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Component } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { StockAction } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionService } from 'Fw/Services/StockActionService';
import { MedulaYardimciIslemler } from 'NebulaClient/Services/External/MedulaYardimciIslemler';
import { KPSV2 } from 'NebulaClient/Services/External/KPSV2';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ResPoliclinic } from 'NebulaClient/Model/AtlasClientModel';
import { ResPoliclinicRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { UserHelper } from 'app/Helper/UserHelper';
import { MultiSelectForm } from 'NebulaClient/Visual/MultiSelectForm';
import { InfoBox } from 'NebulaClient/Visual/InfoBox';
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ComboListItem } from 'NebulaClient/Visual/ComboListItem';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { RaporIslemleri } from 'NebulaClient/Services/External/RaporIslemleri';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
@Component({
    selector: 'ext-web-method',
    template: `

<dx-resizable
    class="resizable"
    handles="right bottom"
    [minHeight]="100"
    [minWidth]="200"
    [maxHeight]="400"
    [maxWidth]="300"
    [width]="200"
    [height]="100">
    <p><b>Resize this element</b></p>
</dx-resizable>

<h2>dxScrollView</h2>

<dx-scroll-view style="height: 200px;display: block;">
    <div>
 <dx-button text="Simple button" (onClick)="boolValue=!boolValue"></dx-button><br/>

    <dx-check-box text="Lonely checkbox" [(value)]="boolValue"></dx-check-box><br/>

    <dx-switch [(value)]="boolValue"></dx-switch><br/>

    <dx-text-box placeholder="TextBox" [(value)]="text" valueChangeEvent="keyup"></dx-text-box>

    <dx-text-area placeholder="TextArea" [(value)]="text" valueChangeEvent="keyup"></dx-text-area>

    <dx-number-box placeholder="NumberBox" [showSpinButtons]="true" [(value)]="numberValue" [min]="0" [max]="100" ></dx-number-box>

    <dx-progress-bar [(value)]="numberValue"></dx-progress-bar>

    <dx-slider [(value)]="numberValue"></dx-slider>

    <dx-range-slider [start]="15" [end]="75"></dx-range-slider>

    <dx-load-indicator [visible]="true"></dx-load-indicator>

    <dx-autocomplete placeholder="Autocomplete 'item'" [items]="demoItems"></dx-autocomplete>

    <dx-select-box placeholder="SelectBox" [items]="demoItems"></dx-select-box>

    <dx-tag-box placeholder="TagBox" [items]="demoItems"></dx-tag-box>

    <dx-date-box [(value)]="currentDate"></dx-date-box>

    <dx-calendar [(value)]="currentDate"></dx-calendar>

     </div>
</dx-scroll-view>
<dx-button text="Dr. Perf" (onClick)="sendToDoctorPerf()"></dx-button>



`
})
export class ExternalWebMethodComponent {
    public saglikTesisAdi: string;
    text = 'Initial text';
    formData = { email: '', password: '' };

    boolValue: boolean;
    numberValue: number;
    dateValue: Date;
    currentDate: Date;
    demoItems: string[];
    popupVisible = false;
    chartSeriesTypes = ['bar', 'line', 'spline'];
    resources: any[];
    constructor(private httpService: NeHttpService) {

    }

    public async sendToDoctorPerf() {
        this.httpService.get('api/CashOfficePatientApi/sendToDoctorPerf');
    }

    public async saglikTesisiAra(): Promise<void> {
        let girisDvo: MedulaYardimciIslemler.saglikTesisiAraGirisDVO = new MedulaYardimciIslemler.saglikTesisiAraGirisDVO();
        girisDvo.saglikTesisKodu = 11060101;
        girisDvo.tesisAdi = 'XXXXXX';
        girisDvo.tesisIlKodu = '06';
        let siteId: Guid = new Guid('86ca11e8-d65b-48fb-a823-0928bead63d8');
        let result = await MedulaYardimciIslemler.WebMethods.saglikTesisiAraSync(siteId, girisDvo);
        console.log(`${result.sonucKodu}-${result.sonucMesaji}`);
    }

    public async getStockActionsCount(): Promise<void> {

        let startDate: Date = new Date();
        startDate.setMonth(1);
        let endDate: Date = new Date();

        let result: Array<StockAction.GetStockActionsCount_Class> = await StockActionService.GetStockActionsCount(startDate, endDate);

        console.log(result);
    }

    public async getChildReleations(): Promise<void> {
        let objectID: Guid = new Guid('91ff6180-386a-47d0-9bef-6329c2e5a0a9');
        let objectDefID: Guid = new Guid('db14835b-5a0e-421d-9091-eda5fac356e9');
        let policlinic: ResPoliclinic = await ServiceLocator.getObject<ResPoliclinic>(objectID, objectDefID);

        let p1: ResPoliclinic = new ResPoliclinic();
        let p2: ResPoliclinic = Object.assign(p1, policlinic);

        let t1 = typeof policlinic;
        console.log(t1);

        let t2 = typeof p2;
        console.log(t2);

        console.log(policlinic.Name);

        // console.log(x.length);

        let rooms: Array<ResPoliclinicRoom> = await p2.PoliclinicRooms;
        console.log(rooms.length);
    }

    public async getSelectedSecMasterResource() {

        let result: ResSection = await UserHelper.SelectedSecMasterResource;
        console.log(result.Name);
    }

    public async showModal(): Promise<void> {

        let multiSelectForm: MultiSelectForm = new MultiSelectForm();
        multiSelectForm.AddMSItem(i18n("M23417", "Tıbbi Sarf"), i18n("M23417", "Tıbbi Sarf"), 1);
        multiSelectForm.AddMSItem(i18n("M16287", "İlaç"), i18n("M16287", "İlaç"), 2);
        multiSelectForm.AddMSItem(i18n("M23359", "Tıbbi Cihaz"), i18n("M23359", "Tıbbi Cihaz"), 3);
        multiSelectForm.AddMSItem(i18n("M12780", "Diğer"), i18n("M12780", "Diğer"), 4);
        let mkey: string = await multiSelectForm.GetMSItem(this, i18n("M14806", "Giriş Yapılacak Malzeme Grubunu Seçiniz"), true);
        alert(mkey);
        console.log(mkey);
        console.log(multiSelectForm.MSSelectedItemObject);

    }

    public async showModalmulti(): Promise<void> {

        let multiSelectForm: MultiSelectForm = new MultiSelectForm();
        multiSelectForm.AddMSItem(i18n("M23417", "Tıbbi Sarf"), i18n("M23417", "Tıbbi Sarf"), 1);
        multiSelectForm.AddMSItem(i18n("M16287", "İlaç"), i18n("M16287", "İlaç"), 2);
        multiSelectForm.AddMSItem(i18n("M23359", "Tıbbi Cihaz"), i18n("M23359", "Tıbbi Cihaz"), 3);
        multiSelectForm.AddMSItem(i18n("M12780", "Diğer"), i18n("M12780", "Diğer"), 4);
        let mkey: string = await multiSelectForm.GetMSItem(this, i18n("M14806", "Giriş Yapılacak Malzeme Grubunu Seçiniz"), true, false, true);
        alert(mkey);
        console.log(mkey);
        console.log(multiSelectForm.MSSelectedItemObjects);
        console.log(multiSelectForm.MSSelectedItems);

    }

    public async showInfoBox(): Promise< void> {
        let result2: string = await InfoBox.CustomShow(i18n("M23735", "Uyarı"), "asdasdasd");
        if (result2 === 'OK') {
            alert(result2);
        }
    }

    public async showBox(): Promise<void> {

        let result2: string = await ShowBox.CustomShow(null, "&Tamam,&Vazgeç", "T,V", i18n("M23735", "Uyarı"), i18n("M20964", "Reçete Türü"), i18n("M24406", "Yatan Hasta Reçetesine Çıkacak ilaçların Reçete Türü : \r\n") + "message" + "\r\n" + i18n("M12687", "Devam Etmek İstiyor Musunuz?"), 1);
        if (result2 === 'V') {
            alert(result2);
        }

    }

    public async treeshowBox(): Promise<void> {
        let result: string = await ShowBox.TreeShow(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç,&Ücretli Kapul Et", "T,V,H", i18n("M23735", "Uyarı"), i18n("M20964", "Reçete Türü"), i18n("M24406", "Yatan Hasta Reçetesine Çıkacak ilaçların Reçete Türü : \r\n") + "message" + "\r\n" + i18n("M12687", "Devam Etmek İstiyor Musunuz?"), 1);
        if (result === 'V') {
            alert(result);
        }
        if (result === 'T') {
            alert(result);
        }
        if (result === 'H') {
            alert(result);
        }
    }

    public async inputFormtxt(): Promise<void> {
        let retAmount: string = await InputForm.GetText(i18n("M16714", "İstenen Miktarı Giriniz."));
        console.log(retAmount);
    }

    public async inputFormtxtmulti(): Promise<void> {
        let retAmount: string = await InputForm.GetText(i18n("M16714", "İstenen Miktarı Giriniz."), 'false', true, true);
        console.log(retAmount);
    }

    public async inputFormdate(): Promise<void> {
        let a: any = await InputForm.GetDateTime(i18n("M22840", "Tarih Seçiniz."));
        console.log(a);
    }

    public async inputFormvalue(): Promise<void> {
        let list: Array<ComboListItem> = new Array<ComboListItem>();
        list.push(new ComboListItem('1', 'adı'));
        list.push(new ComboListItem('2', 'soyadı'));
        list.push(new ComboListItem('3', i18n("M10689", "alet")));
        let a: any = await InputForm.GetValueListItem(i18n("M18275", "Listeden seçiniz."), list);
        console.log(a);
    }

    public testNumberValue() {
        let x = 9;
        let y = x.Value;
        console.log(`Orjinal değer: ${x}: Value getter değeri: ${y}`);
    }

    public bilesikKisiSorgula() {
        let siteId: Guid = new Guid('86ca11e8-d65b-48fb-a823-0928bead63d8');
        KPSV2.WebMethods.BilesikKisiSorgulaSync(siteId, 10000000000).then(r => {
            console.log(r);
        }).catch(err => {
            console.log(err);
        });
    }

    public medulaRaporIslemleri() {
        let SiteLocalHost: Guid = new Guid('0d3b4711-e09b-4f3c-b471-50350c4ee2fe');
        let raporOku: RaporIslemleri.raporOkuTCKimlikNodanDVO = new RaporIslemleri.raporOkuTCKimlikNodanDVO();
        raporOku.raporTuru = '1';
        raporOku.tckimlikNo = '10000000000';
        raporOku.saglikTesisKodu = 11068891;
        RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(SiteLocalHost, raporOku).then(result => {
            console.log(result);
        }).catch(err => {
            console.log(err);
        });

    }

}