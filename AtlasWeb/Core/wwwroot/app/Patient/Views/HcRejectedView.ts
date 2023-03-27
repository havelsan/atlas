//$EC375536
import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { HcRejectedModel } from '../Models/HcRejectedModel';
import { ITabPanel } from 'Fw/Components/HvlTabPanel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { map } from 'rxjs/operators'

@Component({
    selector: 'hvl-com-hasta-red',
    inputs: ['Model'],
    template: `<h1>HcRejected</h1>`,
})
export class HcRejectedView extends BaseComponent<HcRejectedModel> {
    //SutGridDataSource: Array<any>;
    SutGridDataSource: any;
    HastaKayitAdi: string;
    TabItems: Array<ITabPanel>;

    sekmeEkle() {
        this.TabItems.push({
            ModulePath: '../app/Patient/PatientModule',
            ComponentPath: '../app/Patient/Views/PatientView',
            RouteData: {},
            Title: this.HastaKayitAdi,
            Active: false
        });
    }


    gridColumns = [{
        dataField: 'Name',
        cellTemplate: 'myCell'
    }

        //{
        //       dataField: "Name",
        //       width: 100,
        //       alignment: 'center',
        //       cellTemplate: function (container, options) {
        //           $('<a/>').addClass('dx-link')
        //               .text('Dosya Aç')
        //               .on('dxclick', function () {
        //                   //Do something with options.data;
        //               })
        //               .appendTo(container);
        //       }
        //   }
    ];



    firsRequest: Boolean = true;
    //private em: EntityManager;

    constructor(container: ServiceContainer,
        private http: Http) {
        super(container);
        this.HastaKayitAdi = '';
        let defName = 'ReasonForAdmissionListDefinition';
        let that = this;

        this.TabItems = [{
            ModulePath: '../app/Patient/PatientModule',
            ComponentPath: '../app/Patient/Views/PatientView',
            RouteData: {},
            Title: i18n("M10091", "1. sekme"),
            Active: true
        }, {
            ModulePath: '../app/Patient/PatientModule',
            ComponentPath: '../app/Patient/Views/HcReportView',
            RouteData: {},
            Title: i18n("M10201", "2. sekme"),
            Active: false
        }];

        //this.em=new EntityManager(
        //this.em = new EntityManager("");
        //http.post("api/DefinitionQuery/GridQuery?definitionName=" + defName, {
        //    Skip: 0,
        //    Take: 500
        //}).subscribe((res) => {
        //    result = res.json().Result.data;
        //    //that.SutGridDataSource = res.json().Result.data;
        //    });
        //this.SutGridDataSource = result;

        this.SutGridDataSource = {
            load(loadOptions: any) {
                return http.post('api/DefinitionQuery/GridQuery?definitionName=' + defName, {
                    Skip: loadOptions.skip,
                    Take: loadOptions.take
                }).pipe(map((t, i) => {
                    if (that.firsRequest === true) {
                        that.firsRequest = false;
                        return t.json().Result;
                    } else {
                        return t.json().Result.data;
                    }
                }))
            },
            totalCount(loadOptions: any) {
                return http.post('api/DefinitionQuery/GridCount?definitionName=' + defName, null).pipe(map((t, i) => {
                    return t.json().Result;
                }))
            }
        };
        this.Model = new HcRejectedModel();
        //let service: DataService;
        //service = new DataService({
        //    hasServerMetadata: false,
        //    serviceName: "api/Lookup/EnumList?id=DayOfWeekEnum"
        //});
        //this.em = new EntityManager({
        //    dataService: service
        //});
        //var result1 = this.em.getEntities();
    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

        this.http.post('api/DefinitionQuery/Query?filter=&definitionName=ReasonForAdmissionListDefinition', null).subscribe((res: Response) => {
            this.SutGridDataSource = res.json().Result;
        });

        this.Model.SutGridDataSource = [
            { item: { 'ItemKey': '0ea8cd89-2bfe-42db-ba47-42618a94db6a', 'Name': '1 Normal Muayene', 'check': false } },
            { item: { 'ItemKey': '1b61f8eb-883b-40e1-9258-fce71d3d94d6', 'Name': i18n("M10174", "2 Çifte Tabip Muayenesi"), 'check': true } },
            { item: { 'ItemKey': '3735103b-373c-4c92-830e-f4196e1ab153', 'Name': i18n("M10265", "3 Sağlık Kurulu Muayenesi"), 'check': true } },
            { item: { 'ItemKey': '5e36ad9a-4e99-4c23-9f14-5550bc3a4693', 'Name': i18n("M10313", "4 PeriyodikMuayene"), 'check': true } },
            { item: { 'ItemKey': '51b47716-5c9e-47d5-b11f-1a3d810cb7e7', 'Name': i18n("M10343", "5 Özel Bakım Muayene Raporu"), 'check': false } },
            { item: { 'ItemKey': '2fffe504-ab76-4260-9767-98fd06608cc6', 'Name': '8 İstirahatli', 'check': true } },
            { item: { 'ItemKey': 'daf9bcf6-c9b6-4cc6-93c5-93ea31333788', 'Name': i18n("M10399", "9 S.M.K -İstirahat Sonu"), 'check': true } },
            { item: { 'ItemKey': '654d60f8-9ac6-427e-a8a5-871f9c8a2c65', 'Name': i18n("M10113", "10 Hava Değişimi"), 'check': false } },
            { item: { 'ItemKey': 'c93b3790-7514-4117-95c5-5a916e1f4ecf', 'Name': i18n("M10120", "11 S.M.K -Hava Değişimi Sonu"), 'check': false } },
            { item: { 'ItemKey': 'cc853731-0162-42ba-aade-144431c89ce7', 'Name': i18n("M10139", "12 İzinli"), 'check': true } },
            { item: { 'ItemKey': 'bc9c70c1-3b0b-4a7b-84d3-556fc10b5fcd', 'Name': i18n("M10145", "13 Acil"), 'check': true } },
            { item: { 'ItemKey': '40f9fcb6-f423-4b52-ada6-d4790dc1ecbf', 'Name': i18n("M10149", "14 Alkol - Darp Muayenesi"), 'check': true } },
            { item: { 'ItemKey': '36775c04-db02-43d2-9dc5-07354a8a4b99', 'Name': i18n("M10153", "15 Bakımevi"), 'check': false } },
            { item: { 'ItemKey': 'a28ae253-9ded-4766-870e-17ef787b663f', 'Name': i18n("M10158", "16 Portör Muayenesi"), 'check': true } },
            { item: { 'ItemKey': '8bf39dcb-20d7-4d43-8a2a-569c7c57bc01', 'Name': i18n("M10161", "17 Tutuklu"), 'check': true } },
            { item: { 'ItemKey': '7e972c3b-5580-4d70-ba6f-5de6cff8825c', 'Name': i18n("M10164", "18 Adli Gözetim"), 'check': true } },
            { item: { 'ItemKey': '94085174-1bec-47d8-a6c5-560125acdb00', 'Name': i18n("M10169", "19 Ölü - Duhul"), 'check': false } },
            { item: { 'ItemKey': '81fad229-740c-4f14-876d-5fb4a4750c51', 'Name': i18n("M10225", "20 Geçici Sağlık Kurulu Muayenesi"), 'check': true } },
            { item: { 'ItemKey': '31d060c9-edc1-4642-b3aa-b0a6ded727a7', 'Name': i18n("M10231", "22 Tetkik"), 'check': false } },
            { item: { 'ItemKey': '2a0e462b-d50a-44db-8b5e-e3f133190106', 'Name': i18n("M10242", "23 Adli Gözetim-Dosya İnceleme"), 'check': true } },
            { item: { 'ItemKey': '5653f5bb-ca8b-4293-9138-8ebfdb8e9364', 'Name': i18n("M10246", "24 Materyal Kabul"), 'check': true } },
            { item: { 'ItemKey': 'bc0bca53-fde2-4a95-b918-5048c68b8062', 'Name': i18n("M10250", "25 Yeni Doğan"), 'check': true } },
            { item: { 'ItemKey': '1183c071-416e-4aad-9455-feb1fac3599a', 'Name': i18n("M10249", "25 Adli Tıp Kabul"), 'check': false } },
            { item: { 'ItemKey': '0ed0d75b-d3b5-4529-bac3-ccccfcda6953', 'Name': i18n("M10255", "26 Adli Tıp Kabul"), 'check': true } },
            { item: { 'ItemKey': '0cdb0ddf-b75d-4b99-8bda-bf2e7b369f11', 'Name': i18n("M10257", "27 Günübirlik"), 'check': false } },
            { item: { 'ItemKey': '8248492f-5e48-4ae6-ad31-d0b0d7efea1b', 'Name': i18n("M10334", "44 Dış XXXXXX Rapor Onay"), 'check': true } },
            { item: { 'ItemKey': '7b8ca790-b0b1-4834-b4f7-d8a222800489', 'Name': i18n("M10385", "75 Ölü Doğan"), 'check': true } },
            {
                item: {
                    'ItemKey': 'a4f1565e-0857-46e5-99d6-e4430c0fe102', 'Name': i18n("M10116", "100 Diğer XXXXXXlerden Sağlık Kurulu Muayenesi İstek Kabulü"),
                    'check': true
                }
            }];
    }

    btnclk() {
        alert('clk');
    }

    XXXXXXChanged(Id: any) {
    }

}