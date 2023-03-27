// tslint:disable-next-line:no-shadowed-variable
import { ConfigModel } from '../core/interfaces/config';

// tslint:disable-next-line:no-shadowed-variable
export class MenuConfig implements ConfigModel {
    public config: any = {};

    constructor() {

        this.config = {
            header: {
                self: {},
                items: [
                    {
                        title: 'Tıbbi Modüller',
                        root: true,
                        icon: 'fa fa-stethoscope',
                        toggle: 'click',
                        translate: 'MENU.ACTIONS',
                        submenu: {
                            type: 'classic',
                            alignment: 'left',
                            items: [
                                {
                                    title: 'Yeni Hasta Kayıt',
                                    page: 'hasta',
                                    icon: 'fa fa-user-plus',
                                },
                                {
                                    title: 'İş Listesi',
                                    page: 'islistesi',
                                    icon: 'fa fa-newspaper-o',
                                },
                                {
                                    title: 'Yatan Hasta Modülü',
                                    page: 'yatanislistesi',
                                    icon: 'fa fa-bed',
                                },
                                {
                                    title: 'Ameliyat ve Anestezi Modülü',
                                    icon: 'fa fa-heartbeat',
                                    submenu: {
                                        type: 'classic',
                                        alignment: 'right',
                                        bullet: 'line',
                                        items: [
                                            {
                                                title: 'Ameliyat ve Anestezi İş Listesi',
                                                page: 'ameliyatveanestezi/ameliyatveanesteziislistesi',
                                                icon: 'fa fa-list',
                                            },
                                            {
                                                title: 'Güvenli Cerrahi Kontrol İş Listesi',
                                                page: 'ameliyatveanestezi/cerrahikontrolislistesi',
                                                icon: 'fa fa-check-square-o',
                                            }
                                        ]
                                    }
                                },
                                {
                                    title: 'Poliklinik Modülü',
                                    page: 'ayaktanislistesi',
                                    icon: 'fa fa-stethoscope',
                                    condition: 'menuServiceDefinitionModel.ayaktanHastaIsListesi'
                                },
                                {
                                    title: 'F.T.R. İş Listesi',
                                    page: 'fiziktedavi',
                                    icon: 'fa fa-history',
                                    condition: 'menuServiceDefinitionModel.ftrIsListesi'
                                },
                                {
                                    title: 'Kemoterapi Radyoterapi İş Listesi',
                                    page: 'kemoterapiradyoterapi',
                                    icon: 'fa fa-adjust',
                                    condition: 'menuServiceDefinitionModel.chemoRadioIsListesi'
                                },
                                {
                                    title: 'Hemodiyaliz',
                                    icon: 'fa fa-plus-square',
                                    submenu: {
                                        type: 'classic',
                                        alignment: 'right',
                                        bullet: 'line',
                                        items: [
                                            {
                                                title: 'Hemodiyaliz İş Listesi',
                                                page: 'hemodiyaliz',
                                                icon: 'fa fa-list',
                                            },
                                            {
                                                title: 'Hemodiyaliz Randevu İşlemleri',
                                                page: 'hemodiyalizRandevu/hemodiyalizrandevuverme',
                                                icon: 'fa fa-calendar-check-o',
                                            }
                                        ]
                                    }
                                },

                                {
                                    title: 'Ortez Protez İş Listesi',
                                    page: 'ortezProtez',
                                    icon: 'fa fa-wheelchair-alt',
                                    condition: 'menuServiceDefinitionModel.ortezListele',
                                },
                                {
                                    title: 'Sosyal Hizmetler İş Listesi',
                                    page: 'sosyalHizmetIsListesi',
                                    icon: 'fa fa-clipboard',
                                },
                                {
                                    title: 'Laboratuvar',
                                    icon: 'fa fa-thermometer-full',
                                    submenu: {
                                        type: 'classic',
                                        alignment: 'right',
                                        bullet: 'line',
                                        items: [
                                            {
                                                title: 'Numune Alma İş Listesi',
                                                page: 'laboratuvar/numunealma',
                                                icon: 'fa fa-flask',
                                                condition: 'menuServiceDefinitionModel.laboratuvarNumuneAlmaIsListesi'
                                            },
                                            {
                                                title: 'Laboratuvar İş Listesi',
                                                page: 'laboratuvar/islistesi',
                                                icon: 'fa fa-tasks',
                                                condition: 'menuServiceDefinitionModel.laboratuvarProsedurIsListesi'
                                            },
                                            {
                                                title: 'Barkod Ekranı',
                                                page: 'laboratuvar/barkodEkrani',
                                                icon: 'fa fa-barcode',
                                                condition: 'menuServiceDefinitionModel.laboratuvarNumuneAlmaIsListesi'
                                            }
                                        ]
                                    }
                                },
                                {
                                    title: 'Radyoloji  Modülü',
                                    // page: 'radyoloji',
                                    icon: 'fa fa-desktop',
                                    submenu: {
                                        type: 'classic',
                                        alignment: 'right',
                                        bullet: 'line',
                                        items: [
                                            {
                                                title: 'Radyoloji İş Listesi',
                                                page: 'radyoloji',
                                                icon: 'fa fa-desktop',
                                            },
                                            {
                                                title: 'Teletıp Sorgulama Modülü',
                                                page: 'teletip',
                                                icon: 'fas fa-atlas',
                                                condition: 'menuServiceDefinitionModel.teletipListe',
                                            },
                                        ]
                                    }
                                },
                                {
                                    title: 'Nükleer Tıp Modülü',
                                    page: 'nukleertip',
                                    icon: 'fa fa-life-ring',
                                },
                                {
                                    title: 'Hemşirelik Modülü',
                                    page: 'hemsirelikhizmetleri',
                                    icon: 'fa fa-header',
                                },
                                {
                                    title: 'Hemşire Bilgilendirme / Hasta İlaç Doğrulama',
                                    page: 'hastailacdogrulama',
                                    icon: 'fa fa-header',
                                },
                                {
                                    title: 'MHRS Yönetim',
                                    page: 'mhrs/yonetim',
                                    icon: 'fa fa-id-card',
                                },
                                {
                                    title: 'Randevu',
                                    icon: 'fa fa-calendar-check-o',
                                    submenu: {
                                        type: 'classic',
                                        alignment: 'right',
                                        bullet: 'line',
                                        items: [
                                            {
                                                title: 'Randevu Verme',
                                                page: 'randevuveplanlama/randevuverme',
                                                icon: 'fa fa-calendar-check-o'
                                            },
                                            {
                                                title: 'Randevu Planlama',
                                                page: 'randevuveplanlama/randevuplanlama',
                                                icon: 'fa fa-calendar'
                                            },
                                            {
                                                title: 'Randevu Arama',
                                                page: 'randevuveplanlama/randevuarama',
                                                icon: 'fa fa-calendar'
                                            },
                                            {
                                                title: 'Ameliyat Randevusu',
                                                page: 'ameliyat/ameliyatrandevuekrani',
                                                icon: 'fa fa-calendar',
                                                condition: 'menuServiceDefinitionModel.surgeryAppointment'
                                            },
                                            {
                                                title: 'Yatan Hasta Randevusu',
                                                page: 'yatanRandevu/yatanRandevuListesi',
                                                icon: 'fa fa-calendar'
                                            }
                                        ]
                                    }
                                },
                                // {
                                //     title: 'Randevu Verme',
                                //     page: 'randevuveplanlama/randevuverme',
                                //     icon: 'fa fa-calendar-check-o',
                                // },
                                // {
                                //     title: 'Randevu Planlama',
                                //     page: 'randevuveplanlama/randevuplanlama',
                                //     icon: 'fa fa-calendar',
                                // },
                                // {
                                //     title: 'Randevu Arama',
                                //     page: 'randevuveplanlama/randevuarama',
                                //     icon: 'fa fa-calendar',
                                // },
                                {
                                    title: 'Diyet Modülü',
                                    page: 'diyet',
                                    icon: 'fa fa-cutlery',
                                    condition: 'menuServiceDefinitionModel.diyetListe',
                                },
                                {
                                    title: 'Sağlık Kurulu Modülü',
                                    page: 'saglikkurulukabul',
                                    icon: 'fa fa-wheelchair',
                                    condition: 'menuServiceDefinitionModel.saglikKuruluIsListesi',
                                },
                                {
                                    title: 'Hasta Geçmişi',
                                    page: 'hastagecmisiarama',
                                    icon: 'fa fa-history',
                                },
                                {
                                    title: 'Hasta Dosyası',
                                    page: 'hastadosyasi',
                                    icon: 'fa fa-folder',
                                    condition: 'menuServiceDefinitionModel.showPatientFolderShow'
                                },
                                {
                                    title: 'Patoloji Modülü',
                                    page: 'patolojiislistesi',
                                    icon: 'fas fa-notes-medical'
                                    //condition: 'menuServiceDefinitionModel.showPatientFolderShow'
                                },
                                {
                                    title: 'EHU Onay Modülü',
                                    page: 'ehuislistesi',
                                    icon: 'fas fa-pills'
                                },
                            ]
                        }
                    },
                    {
                        title: 'İdari Modüller',
                        root: true,
                        icon: 'fa fa-hospital-o',
                        toggle: 'click',
                        translate: 'MENU.ACTIONS',
                        submenu: {
                            type: 'classic',
                            alignment: 'left',
                            items: [
                                {
                                    title: 'Personel',
                                    page: 'personnelintegration',
                                    icon: 'fa fa-users',
                                },
                                {
                                    title: 'Cihaz Arıza Bildirimi',
                                    page: 'XXXXXXehipintegration',
                                    icon: 'fa fa-cogs',
                                },
                                {
                                    title: 'Malzeme Yönetimi',
                                    page: 'malzemeyonetimi',
                                    icon: 'fa fa-university',
                                    condition: 'menuServiceDefinitionModel.malzemeYonetimi',
                                },
                                {
                                    title: 'Döküman Yönetimi',
                                    page: 'document',
                                    icon: 'fa fa-book',
                                    condition: 'menuServiceDefinitionModel.dokumanYonetimi'
                                },
                                {
                                    title: 'Vademecum Online',
                                    icon: 'fa fa-flask',
                                    customClick: 'openVademecum()',
                                },
                                {
                                    title: 'İstatistik',
                                    icon: 'fa fa-bar-chart',
                                    customClick: 'openStatistics()',
                                },
                                {
                                    title: 'Yeni Doktor Performansları',
                                    page: 'newdoctorperformance',
                                    icon: 'fa fa-pie-chart',
                                },
                                {
                                    title: 'Başhekim Reçete Onay',
                                    icon: 'fa fa-street-view',
                                    customClick: 'openColorPrescriptionForApproval_Bash()',
                                },
                                {
                                    title: 'SMS Modülü',
                                    icon: 'fas fa-envelope-square',
                                    page: 'smsmodulu',
                                    condition: 'menuServiceDefinitionModel.SMSModule'
                                },
                            ],
                        }
                    },
                    {
                        title: 'Finansal Modüller',
                        root: true,
                        icon: 'fa fa-try',
                        toggle: 'click',
                        translate: 'MENU.ACTIONS',
                        condition: 'menuServiceDefinitionModel.faturaAnaMenu',
                        submenu: {
                            type: 'classic',
                            alignment: 'left',
                            items: [
                                {
                                    title: 'Dönem İşlemleri',
                                    page: 'fatura/donem',
                                    icon: 'fa fa-line-chart',
                                    condition: 'menuServiceDefinitionModel.donemIslemleri',
                                },
                                {
                                    title: 'İcmal İşlemleri',
                                    page: 'fatura/icmal',
                                    icon: 'fa fa-tasks',
                                    condition: 'menuServiceDefinitionModel.icmalIslemleri',
                                },
                                {
                                    title: 'Tahsilat İşlemleri',
                                    page: 'fatura/tahsilat',
                                    icon: 'fa fa-tasks',
                                    condition: 'menuServiceDefinitionModel.tahsilatIslemleri',
                                },
                                {
                                    title: 'Vezne İşlemleri',
                                    page: 'vezne',
                                    icon: 'fa fa-money',
                                    condition: 'menuServiceDefinitionModel.venzeIslemleri',
                                },
                                {
                                    title: 'Fatura İşlemleri',
                                    page: 'fatura',
                                    icon: 'fa fa-cogs',
                                    condition: 'menuServiceDefinitionModel.faturaIslemleri',

                                },
                                {
                                    title: 'Finansal İşlemler',
                                    page: 'fatura/all',
                                    icon: 'fas fa-money-bill-wave',
                                    condition: 'menuServiceDefinitionModel.faturaAllinOne',
                                },
                                {
                                    title: 'Raporlar',
                                    page: 'fatura/report',
                                    icon: 'fa fa-file-text-o',
                                    condition: 'menuServiceDefinitionModel.faturaAllinOne',
                                },
                                {
                                    title: 'TİG Modülü',
                                    page: 'tigmodulu',
                                    icon: 'fa fa-tint',
                                },
                                {
                                    title: 'Gelir/Gider İşlemleri',
                                    page: 'gelirgider',
                                    icon: 'fa fa-recycle',
                                },
                            ],
                        }
                    },
                    {
                        title: 'Diğer',
                        root: true,
                        icon: 'fa fa-suitcase',
                        toggle: 'click',
                        translate: 'MENU.ACTIONS',
                        submenu: {
                            type: 'classic',
                            alignment: 'left',
                            items: [
                                {
                                    title: 'Danışma',
                                    page: 'danisma',
                                    icon: 'fa fa-info',
                                },
                                {
                                    title: 'Arşiv İş Listesi',
                                    page: 'arsiv/islistesi',
                                    icon: 'fa fa-archive',
                                },
                                {
                                    title: 'Tıbbi/Tehlikeli Atık',
                                    page: 'tibbiatik',
                                    icon: 'fa fa-recycle',
                                },
                                {
                                    title: 'Mesajlaşma',
                                    page: 'kullanicimesaj/box',
                                    icon: 'fa fa-envelope',
                                },
                                {
                                    title: 'Log Sorgulama',
                                    page: 'log/auditform',
                                    icon: 'fa fa-folder',
                                },
                                {
                                    title: 'Genel Lcd Ekranı',
                                    page: 'hastacagri',
                                    icon: 'fa fa-desktop',
                                },
                                {
                                    title: 'Raporlar',
                                    page: 'raporlar',
                                    icon: 'fa fa-file-text-o',
                                },
                                {
                                    title: 'Sterilizasyon İstek',
                                    page: 'sterilizasyonistek',
                                    icon: 'fa fa-file-text-o',
                                },
                                {
                                    title: 'Sterilizasyon Modülü',
                                    page: 'sterilizasyon',
                                    icon: 'fa fa-file-text-o',
                                },
                                {
                                    title: 'Çamaşırhane ve Temizlik Modülü',
                                    page: 'laundry',
                                    icon: 'fa fa-chrome',
                                    condition: 'menuServiceDefinitionModel.laundryModule',
                                },
                                /* {
                                     title: 'Direktif Zaman Çizelgesi',
                                     page: 'orderzamancizelgesi',
                                     condition: 'menuServiceDefinitionModel.hospitalTimeSchedule',
                                     icon: 'fa fas fa-clock',
                                 },*/
                                {
                                    title: 'Atlas Tanımlama Ekranı',
                                    page: 'kullaniciTanimlari',
                                    icon: 'fa fa-archive',
                                    condition: 'menuServiceDefinitionModel.kullaniciTanimlari',
                                },
                                {
                                    title: 'Nabız Takip Modülü',
                                    page: 'nabiztakip',
                                    icon: 'fas fa-heartbeat',
                                    condition: 'menuServiceDefinitionModel.nabizGoruntule',

                                },
                                {
                                    title: 'Yönetici Reçete Ekranı',
                                    page: 'receteistatistik',
                                    icon: 'fa fa-pencil',
                                    condition: 'menuServiceDefinitionModel.receteIstatistikGoruntule',

                                },
                                {
                                    title: 'Hizmet Tanımları',
                                    page: 'hizmetTanimlari',
                                    icon: 'fas fa-atlas',
                                    condition: 'menuServiceDefinitionModel.hizmetTanimlari',
                                },
                                {
                                    title: 'Tıbbi Araştırma Modülü',
                                    page: 'tibbiArastirma',
                                    icon: 'fas fa-atlas',
                                    condition: 'menuServiceDefinitionModel.medicalResach',
                                },

                                {
                                    title: 'Kiosk İşlemler',
                                    icon: 'fas fa-atlas',
                                    condition: 'menuServiceDefinitionModel.kiosk',
                                    submenu: {
                                        type: 'classic',
                                        alignment: 'right',
                                        bullet: 'line',
                                        items: [
                                            {
                                                title: 'Anket Tanımı ',
                                                page: 'kiosk/surveydefinition',
                                                icon: 'fas fa-atlas',
                                            },
                                            {
                                                title: 'Cihaz Tanımı ',
                                                page: 'kiosk/kioskDevice',
                                                icon: 'fas fa-desktop',
                                            },
                                            {
                                                title: 'Duyuru Tanımı ',
                                                page: 'kiosk/kioskNotification',
                                                icon: 'far fa-comments',
                                            },
                                            {
                                                title: 'Şikayet ve Öneriler ',
                                                page: 'kiosk/kioskComplaintSuggestion',
                                                icon: 'fas fa-comments',
                                            },
                                        ]
                                    }
                                },

                                {
                                    title: 'Dinamik Raporlar',
                                    icon: 'fas fa-atlas',
                                    condition: 'menuServiceDefinitionModel.kullaniciTanimlari',
                                    submenu: {
                                        type: 'classic',
                                        alignment: 'right',
                                        bullet: 'line',
                                        items: [
                                            {
                                                title: 'Rapor Tasarımı',
                                                page: 'dynamicreporting/reporting',
                                                icon: 'fas fa-atlas',
                                            }
                                        ]
                                    }
                                },
                                {
                                    title: 'Dinamik Kontrol Paneli',
                                    icon: 'fas fa-atlas',
                                    condition: 'menuServiceDefinitionModel.kullaniciTanimlari',
                                    submenu: {
                                        type: 'classic',
                                        alignment: 'right',
                                        bullet: 'line',
                                        items: [
                                            {
                                                title: 'Dashboard Tasarımı',
                                                page: 'dynamicreporting/dashboard',
                                                icon: 'fas fa-atlas',
                                            },
                                            {
                                                title: 'Dashboard Veri Kaynağı',
                                                page: 'dynamicreporting/dashboard/edit',
                                                icon: 'fas fa-atlas',
                                            },
                                        ]
                                    }
                                },
                                // {
                                //     title: 'Teletıp Sorgulama Modülü',
                                //     page: 'teletip',
                                //     icon: 'fa fa-file-text-o',
                                // },
                                {
                                    title: 'Dinamik Formlar',
                                    icon: 'fas fa-atlas',
                                    condition: 'menuServiceDefinitionModel.kullaniciTanimlari',
                                    submenu: {
                                        type: 'classic',
                                        alignment: 'right',
                                        bullet: 'line',
                                        items: [
                                            {
                                                title: 'Form Tasarımı',
                                                page: 'dynamicformdesigner/designer',
                                                icon: 'fas fa-atlas',
                                            }
                                        ]
                                    }
                                },
                                {
                                    title: 'Medula Yatak Eşleştirme Ekranı',
                                    page: 'tescilliyatakeslestirme',
                                    icon: 'fa fa-bed',
                                    condition: 'menuServiceDefinitionModel.tescilliYatakEslestirme',

                                },

                                {
                                    title: 'Arşiv Tanımları',
                                    page: 'arsivTanimlari',
                                    icon: 'fas fa-atlas',
                                },
                                {
                                    title: 'Tıbbi Atık Tanımları',
                                    page: 'atikTanimlari',
                                    icon: 'fas fa-atlas',
                                },
                                {
                                    title: 'Hasta Dosyası İçerik Tanımları',
                                    page: 'hastaDosyasiTanimlari',
                                    icon: 'fas fa-atlas',
                                },

                            ],
                        }
                    },


                ]
            },
            aside: {
                self: {},
                items: [],
            }
        };

        let that = this;
        this.config.header.items.forEach(element => {
            if (element.submenu != null)
                that.sortMenuList(element.submenu.items);
            if (element.items == null) {
                element.submenu.items.forEach(element => {
                    if (element.submenu != null) {
                        that.sortMenuList(element.submenu.items);
                    }
                });
            }

        });
    }

    private sortMenuList(items: Array<any>) {
        items.sort((a, b) => {
            if (a.title < b.title) return -1;
            else if (a.title > b.title) return 1;
            else return 0;
        });
    }
}
