//$C4462073
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { ENabizPackagesFormViewModel, NabizSearchCritaria, NabizResult, PackageInfo, DailyBasedNabizResult, SubepisodeBasedNabizResult, PackageDetail, NabizResponse, IslemBanaAitDegilResponse, IslemBanaAitDegilResultModel } from './ENabizPackagesFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

import { IModalService } from "Fw/Services/IModalService";
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';
import { DxPopoverComponent } from 'devextreme-angular';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { Convert } from 'app/NebulaClient/Mscorlib/Convert';
import { DxDataGridComponent, DxAccordionComponent } from 'devextreme-angular';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';

@Component({
    selector: 'ENabizPackagesForm',
    templateUrl: './ENabizPackagesForm.html',
    providers: [MessageService]
})
export class ENabizPackagesForm implements OnInit {
    @ViewChild('nabizpackages') nabizpackagesGrid: DxDataGridComponent;
    @ViewChild('nabizdailypackages') dailynabizpackagesGrid: DxDataGridComponent;
    public eNabizPackagesFormViewModel: ENabizPackagesFormViewModel = new ENabizPackagesFormViewModel();
    public selectedENabizPackages: Array<NabizResult> = new Array<NabizResult>();
    public selectedDailyENabizPackages: Array<DailyBasedNabizResult> = new Array<DailyBasedNabizResult>();

    public _searchType = [

        {
            Name: "Kabul tarihine göre sorgula",
            ObjectID: 0
        },
        {
            Name: "Paket eklenme tarihine göre sorgula",
            ObjectID: 1
        }
    ];

    public popupVisible: boolean = false;
    public _showSubepisodeInfo:boolean = false;
    public _subepisodeInfo: SubepisodeBasedNabizResult;
    public showSGKHizmetSorgulamaPopup = false;
    public SGKHizmetSorgulamaResultDataSource: any;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    _402Result: string = "";
    _402PopUpVisible: boolean = false;
    endDateStart: Date;
    private _SGKTakipNo: string = "";
    private _SGKTakipNoPopUpVisible: boolean = false;
    private _IslemBanaAitDegilVisible: boolean = false;
    private _precriptionInfoVisible: boolean = false;
   // public _PackagesBySubepisode: DataSource;

    public packageStatusArray = [

        {
            Name: "Tümü",
            ObjectID: 5
        },
        {
            Name: "Gönderilecek",
            ObjectID: 0
        },
        {
            Name: "Başarılı",
            ObjectID: 1
        },
        {
            Name: "Başarısız",
            ObjectID: 2
        },
        {
            Name: "Gönderilemedi",
            ObjectID: 3
        },
        {
            Name: "Gönderilmeyecek",
            ObjectID: 4
        }
    ];

   

    @ViewChild(DxPopoverComponent) popOver: DxPopoverComponent;
    @ViewChild('searchAndListAccordion') searchAndListAccordion: DxAccordionComponent; 
    public accordionContainerHeight;
    private ENabizPackagesForm_DocumentUrl: string = '/api/ENabizPackageManagement/TigEpisodeForm';
    constructor(protected httpService: NeHttpService,
        protected modalService: IModalService,
        protected messageService: MessageService,
        private http2: AtlasHttpService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        protected ngZone: NgZone) {
        this.initViewModel();
        this.initFormControls();
        this.loadViewModel();
        //
        this.AddHelpMenu();
    }

    getRecords(): void {
        let tempDate: Date = Convert.ToDateTime(this.eNabizPackagesFormViewModel._NabizSearchCritaria.packageAddingDateEnd);
        let tempendDateStart: Date = Convert.ToDateTime(this.eNabizPackagesFormViewModel._NabizSearchCritaria.packageAddingDateStart);
        tempDate = tempDate.AddDays(-14);

        if (tempDate > tempendDateStart) {
            TTVisual.InfoBox.Alert("Tarihler arasındaki fark 14 günden fazla iken sorgulama yapılamaz.");
        } else if (this.eNabizPackagesFormViewModel._NabizSearchCritaria.NabizPackages == null)
            TTVisual.InfoBox.Alert("Paket türü seçilmeden sorgulama yapılamaz.");
        else {
            let apiUrl: string = '/api/ENabizPackageManagementService/GetENabizPackages';
       

            this.httpService.post<Array<NabizResult>>(apiUrl, this.eNabizPackagesFormViewModel._NabizSearchCritaria).then(response => {
                let result = <Array<NabizResult>>response;

                this.eNabizPackagesFormViewModel._NabizResult = result;
            }).catch(error => {
                console.log(error);
            });
        }
    }

    sendSelectedPackages(): void {
        let completedCheck: boolean = false;
        this.selectedENabizPackages.forEach(element => {
            if (element.PackageStatus == "Gönderim Başarılı") {
                completedCheck = true;
            }
        });
        if (completedCheck) {
            TTVisual.InfoBox.Alert("Gönderimi başarılı olmuş paketleri tekrar gönderemezsiniz");
        } else {
            let apiUrl: string = '/api/ENabizPackageManagementService/SendENabizPackages';

            this.httpService.post(apiUrl, this.selectedENabizPackages).then(response => {
                let result = <Array<NabizResult>>response;
                this.nabizpackagesGrid.instance.refresh();
            }).catch(error => {
                console.log(error);
            });
        }

    }

    public async SendToENabiz(row: NabizResult): Promise<any>  {
      

        let that = this;
        let apiUrl: string = '/api/ENabizPackageManagementService/SendPackageToENabiz';

        this.httpService.post<Array<NabizResponse>>(apiUrl, row).then(result => {

            ServiceLocator.MessageService.showInfo(result[0].SonucKodu + "-" + result[0].SonucMesaji);
            this.getRecords();
           

        })
            .catch(error => {
                this.errorHandlerForNabizForm(error);
            });



    }

    public async SendDailyBasedPackageToENabiz(row: DailyBasedNabizResult): Promise<any> {
        try {

            let apiUrl: string = 'api/ENabizPackageManagementService/SendDailyBasedPackageToENabiz';
            await this.httpService.post(apiUrl, row);
            this.dailynabizpackagesGrid.instance.refresh();

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
  
    AddQueue(): void {

        if (this.selectedENabizPackages.length == 0) {
            TTVisual.InfoBox.Alert("Kuyruğa eklenecek paketleri seçiniz.");
            return;
        }
        let apiUrl: string = '/api/ENabizPackageManagementService/AddQueue';

        this.httpService.post(apiUrl, this.selectedENabizPackages).then(response => {
            let result = <Array<NabizResult>>response;
            this.getRecords();
        }).catch(error => {
            console.log(error);
        });
    }

    sendGunSonu(): void {
        if (this.endDateStart == null) {
            TTVisual.InfoBox.Alert("Tarih Seçmelisiniz.!");
        } else {
            let apiUrl: string = '/api/ENabizPackageManagementService/sendGunSonu';
            let input = { "endDateStart": this.endDateStart };

            this.httpService.post(apiUrl, input).then(response => {
            }).catch(error => {
                console.log(error);
            });
        }
    }

    sendGunSonuOneDate(): void {
        if (this.endDateStart == null) {
            TTVisual.InfoBox.Alert("Tarih Seçmelisiniz.!");
        } else {
            let apiUrl: string = '/api/ENabizPackageManagementService/sendGunSonuOneDate';
            let input = { "endDateStart": this.endDateStart };

            this.httpService.post(apiUrl, input).then(response => {
            }).catch(error => {
                console.log(error);
            });
        }
    }

    SendOneDayToEnabiz(): void {
        this.popupVisible = true;
    }


    send202Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send202Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send204Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send204Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send205Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send205Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send206Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send206Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send207Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send207Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send208Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send208Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send209Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send209Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send210Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send210Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send211Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send211Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send212Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send212Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send216Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send216Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send217Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send217Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send237Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send237Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send218Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send218Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send219Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send219Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send220Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send220Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send221Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send221Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send222Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send222Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send223Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send223Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send224Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send224Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send225Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send225Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send229Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send229Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send230Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send230Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send231Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send231Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send236Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send236Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

  

    send238Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send238Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send239Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send239Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send240Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send240Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send241Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send241Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send247Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send247Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send248Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send248Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send249Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send249Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send250Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send250Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send257Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send257Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send258Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send258Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send260Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send260Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send261Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send261Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send262Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send262Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send501Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send501Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send512Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send512Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send905Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send905Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send268Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send268Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send101Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send101Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send102Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send102Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send108Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send108Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send201Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send201Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send105Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send105Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send302Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send302Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send103Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send103Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send502Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send502Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }
    send200Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send200Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }
    send106Dummy(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send106Dummy';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    SendNabizPackagesWithErrorCode(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/SendNabizPackagesWithErrorCode';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    senSmsdoctor(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/SendSmsDoctor';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    sendGunSonuLoop(): void {
        if (this.endDateStart == null) {
            TTVisual.InfoBox.Alert("Tarih Seçmelisiniz.!");
        } else {
            let apiUrl: string = '/api/ENabizPackageManagementService/sendGunSonuLoop';
            let input = { "endDateStart": this.endDateStart };

            this.httpService.post(apiUrl, input).then(response => {
            }).catch(error => {
                console.log(error);
            });
        }
    }

    onCellHover(e: any) {
        if (e.column != null && e.rowType == "data") {
            if (e.column.dataField == 'Diagnosis') {
                if (e.data.Diagnosis !== "") {
                    this.popOver.target = e.cellElement;
                    this.popOver.contentTemplate = e.data.Diagnosis;
                    this.popOver.visible = true;
                }
            } else if (e.column.dataField == 'Surgeries') {
                if (e.data.Surgeries !== "") {
                    this.popOver.target = e.cellElement;
                    this.popOver.contentTemplate = e.data.Surgeries;
                    this.popOver.visible = true;
                }
            } else {
                this.popOver.visible = false;
            }
        }
        else
            this.popOver.visible = false;
    }




    public ENabizPackagesDataGridColumns =
    [
        {
            caption: i18n("M14905", "Gönderim Tarihi"),
            dataField: 'PackageSendDate',
            width: '165',
            allowEditing: false
        },
        {
            caption: i18n("M17021", "Kabul No"),
            dataField: 'PatientAdmissionNo',
            width: 100,
            allowEditing: false

        },
        {
            caption: 'Hasta Adı-Soyadı',
            dataField: 'PatientName',
            width: 150,
            allowEditing: false
            },
            {
                caption: 'SYS Takip No',
                dataField: 'SYSTakipNo',
                width: 150,
                allowEditing: false
            },
            {
            caption: 'Paket No',
            dataField: 'PackageCode',
            width: 80,
            allowEditing: false

        },
        {
            caption: i18n("M20132", "Paket Adı"),
            dataField: 'PackageName',
            width: 250,
            allowEditing: false
        },
        {
            caption: i18n("M20143", "Paket Durumu"),
            dataField: 'PackageStatus',
            width: 150,
            allowEditing: false
        },
            {
                caption: 'Cevap Kodu',
                dataField: 'ResultCode',
                width: 100,
                allowEditing: false
            },
        {
            caption: 'Cevap',
            dataField: 'ResponseFromENabiz',
            width: "%100",
            allowEditing: false
            },
        {
            "caption": "",
            width: 40,
            allowSorting: false,
            allowEditing: false,
            cellTemplate: "sendCellTemplate"

        }


        ];

    public DailyBasedNabizGridColumns =
        [
            {
                caption: 'Gönderim Tarihi',
                dataField: 'SendDate',
                width: '165',
                allowEditing: false
            },
            {
                caption: 'Durum',
                dataField: 'Status',
                width: 150,
                allowEditing: false

            },
            {
                caption: 'Cevap Kodu',
                dataField: 'ResponseCode',
                width: 100,
                allowEditing: false
            },
            {
                caption: 'Cevap',
                dataField: 'ResponseMessage',
                width: "%100",
                allowEditing: false
            },
            {
                "caption": "",
                width: 40,
                allowSorting: false,
                allowEditing: false,
                cellTemplate: "dailysendCellTemplate"

            }

        ];

        public SubepisodeBasedNabizGridColumns =
        [
            {
                caption: 'Kabul Tarihi',
                dataField: 'OpeningDate',
                width: '165',
                allowEditing: false
            },
            {
                caption: 'Kabul No',
                dataField: 'ProtocolNo',
                width: 150,
                allowEditing: false

            },
            {
                caption: 'Birim',
                dataField: 'Ressection',
                width: 250,
                allowEditing: false
            },
            {
                caption: 'Hasta Adı Soyadı',
                dataField: 'PatientNameSurname',
                width: 250,
                allowEditing: false
            },{
                caption: 'SYSTakipNo',
                dataField: 'SYSTakipNo',
                width: "%100",
                allowEditing: false
            },
                {
                    "caption": "",
                    width: 50,
                    allowSorting: false,
                    allowEditing: false,
                    cellTemplate: "send101Template"

                },
            //    {
            //        "caption": "",
            //        width: 50,
            //        allowSorting: false,
            //        allowEditing: false,
            //        cellTemplate: "send402Template"

            //    },
            //{
            //    "caption": "",
            //    width: 50,
            //    allowSorting: false,
            //    allowEditing: false,
            //    cellTemplate: "sgkSorgulaTemplate"

            //},
            {
                "caption": "",
                width: 50,
                allowSorting: false,
                allowEditing: false,
                cellTemplate: "subepisodeInfoTemplate"

            }

        ];

    public openPopup(): void {
        this.popupVisible = true;
    }

   
    onRowPreparedPackagesList(e: any): void {

        if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' && e.rowType !== 'filter' && e.rowElement.firstItem().length === 1) {
            let PackageStatus = e.data.PackageStatus;

            if (PackageStatus === "Gönderim Başarılı") {
                e.rowElement.firstItem().style.backgroundColor = '#b3ffb3';
                //e.rowElement.firstItem().style.color = '#11583D';
            }
            else if (PackageStatus === "Paket Gönderilemedi") {
                e.rowElement.firstItem().style.backgroundColor = '#ffdd99';
                //e.rowElement.firstItem().style.color = '#11583D';
            }
            else if (PackageStatus === "Gönderim Başarısız") {
                e.rowElement.firstItem().style.backgroundColor = '#ff8080';
                //e.rowElement.firstItem().style.color = '#11583D';
            }

        }
    }

    onRowPreparedDailyBasedNabizList(e: any): void {

    }

  

    userSearchModelLoaded(value) {
        if (value != null)
            this.eNabizPackagesFormViewModel._NabizSearchCritaria = JSON.parse(value);
        else
            this.eNabizPackagesFormViewModel._NabizSearchCritaria = new NabizSearchCritaria();
    }
    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this.eNabizPackagesFormViewModel = new ENabizPackagesFormViewModel();
        this.eNabizPackagesFormViewModel._NabizSearchCritaria.NabizPackages = new Array<PackageInfo>();
        this._PackagesBySubepisode = new Array<PackageDetail>();
    }

    protected loadViewModel() {
        let that = this;
        let fullApiUrl: string = "/api/ENabizPackageManagementService/LoadENabizPackagesFormViewModel";
        this.httpService.get<ENabizPackagesFormViewModel>(fullApiUrl)
            .then(response => {
                that.eNabizPackagesFormViewModel =  response as ENabizPackagesFormViewModel;
                          
            })
            .catch(error => {
                console.log(error);
            });

    }

    async ngOnInit() {
        
    }

    public ngOnDestroy(): void {

    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {

    }
    public accordionClick(event: any) {
 
        let that = this;
        if (that.searchAndListAccordion.selectedIndex == -1) {
            setTimeout(function () {
               
                that.accordionContainerHeight = that.setAccordionRowCotainerHeight('5%');
            }, 50);
        }
        else {
            setTimeout(function () {
               
                that.accordionContainerHeight = that.setAccordionRowCotainerHeight('100%');
            }, 50);
        }
    }

    setAccordionRowCotainerHeight(height: string) {
        return {
            'height': height
        }
    }

    guSonuListele(): void {
        let tempDate: Date = Convert.ToDateTime(this.eNabizPackagesFormViewModel._DailyBasedNabizSearchCritaria.EndDate);
        let tempendDateStart: Date = Convert.ToDateTime(this.eNabizPackagesFormViewModel._DailyBasedNabizSearchCritaria.StartDate);
        tempDate = tempDate.AddDays(-14);

        if (tempDate > tempendDateStart) {
            TTVisual.InfoBox.Alert("Tarihler arasındaki fark 14 günden fazla iken sorgulama yapılamaz.");
        } 
        else {
            let apiUrl: string = '/api/ENabizPackageManagementService/GetDailyBasedENabizPackages';
            this.httpService.post<Array<DailyBasedNabizResult>>(apiUrl, this.eNabizPackagesFormViewModel._DailyBasedNabizSearchCritaria).then(response => {
                let result = <Array<DailyBasedNabizResult>>response;

                this.eNabizPackagesFormViewModel._DailyBasedNabizResult = result;
            }).catch(error => {
                console.log(error);
            });
        }
    }

  

    public _subepisodedateReadOnly: boolean = false;
    onSearchTypeChanged(e) {
        if (e.value == 1) {
            this._subepisodedateReadOnly = true;
            this.eNabizPackagesFormViewModel._NabizSearchCritaria.SearchType = 1; //paket eklenme tarihi
        } else {
            this._subepisodedateReadOnly = false;
            this.eNabizPackagesFormViewModel._NabizSearchCritaria.SearchType = 0; //kabul tarihi
        }

        
    
    }

    onProtocolNoKeyDown(e) {
        let keyCode: any = e.event.keyCode;
        if (keyCode == 13) { // Enter karekteri
            //this.btnSearchClicked();
        }
    }

    onPatientSelected(patient: any) {
        //if (patient) {
        //    this.examinationWorkListViewModel._SearchCriteria.PatientObjectID = patient.ObjectID;
        //    this.btnSearchClicked();
        //}
        //else
        //    this.examinationWorkListViewModel._SearchCriteria.PatientObjectID = "";
    }

    public async ShowSubepisodeInfo(row: SubepisodeBasedNabizResult): Promise<any> {
        let that = this;
        this._subepisodeInfo = row;
        this._showSubepisodeInfo= true;
        //Seçilen subepisodedaki tüm nabız paketleri listelenmeli
        //this._PackagesBySubepisode = new Array<PackageDetail>();

        //this._PackagesBySubepisode = new DataSource({
        //    store: new CustomStore({
        //        key: "ObjectID",

        //        load: async (loadOptions: any) => {
        //            loadOptions.Params = {
        //                searchType: that.searchType,
        //                definitionName: 'GetProcedureDefinitionListDefinition'
        //            }

        //            if (loadOptions.take == null || loadOptions.take == 0) {
        //                loadOptions.take = 50;
        //            }

        //            return await this.httpService.post<any>("/api/ProcedureDefinitionService/GetProcedureDefinitionList", loadOptions);

        //        },
        //    }),
        //    paginate: true,
        //    pageSize: 50
        //});

    
        this.getsubepisodepackagedetails(row.ObjectID.toString());



 
    }

    async getsubepisodepackagedetails(subepisodeObjectid: string) : Promise<any> {
        let apiUrl: string = '/api/ENabizPackageManagementService/GetSubepisodePackageDetails/?subepisodeObjectID=' + subepisodeObjectid;

        let res = await this.httpService.get<Array<PackageDetail>>(apiUrl);
        this._PackagesBySubepisode = res;
    }

   
    onProtocolNoOrSYSTakipNoKeyDownSubepisode(e) {
      
            this.getSubepisodes();
      
    }


    onPatientSelectedSubepisode(patient: any) {
        if (patient) {
            this.eNabizPackagesFormViewModel._SubepisodeBasedNabizSearchCritaria.PatientObjectID = patient.ObjectID;
            this.getSubepisodes();
        }
        else
            this.eNabizPackagesFormViewModel._SubepisodeBasedNabizSearchCritaria.PatientObjectID = "";
    }

    getSubepisodes(): void {
        
        let apiUrl: string = '/api/ENabizPackageManagementService/GetSubepisodes';
        this.httpService.post<Array<SubepisodeBasedNabizResult>>(apiUrl, this.eNabizPackagesFormViewModel._SubepisodeBasedNabizSearchCritaria).then(response => {
            let result = <Array<SubepisodeBasedNabizResult>>response;

            this.eNabizPackagesFormViewModel._SubepisodeBasedNabizResult = result;
        }).catch(error => {
            console.log(error);
        });
    
    }
    public async SGKSorgula_SYSTakipNo(row: SubepisodeBasedNabizResult):Promise<any>{ //Sadece sysüzerinden sorgulama
        let shsm: any = {};
        shsm.sysTakipNo = row.SYSTakipNo;
        this.loadPanelOperation(true, "E-Nabız'dan SGK hizmetleri sorgulanıyor, lütfen bekleyiniz.");
        let apiUrl: string = '/api/ENabizPackageManagementService/SGKHizmetSorgulama';

        this.httpService.post(apiUrl, shsm).then(result => {
            this.showSGKHizmetSorgulamaPopup = true;
            this.SGKHizmetSorgulamaResultDataSource = result;
            this.loadPanelOperation(false, '');
        })
            .catch(error => {
                this.errorHandlerForNabizForm(error);
            });
    }

    public async GetPrescriptionInfo(row: SubepisodeBasedNabizResult) {

        this.loadPanelOperation(true, "E-Nabız'dan Reçete Bilgileri  Sorgulanıyor, Lütfen Bekleyiniz.");


        let fullApiUrl: string = "/api/ENabizPackageManagementService/GetPrescriptionInfo?SYSTakipNo=" + row.SYSTakipNo;

        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                //that.eNabizPackagesFormViewModel = response as ENabizPackagesFormViewModel;
                this.loadPanelOperation(false, '');
            })
            .catch(error => {
                this.errorHandlerForNabizForm(error);
            });
    }


    public async DeleteSysAndSend101(row: SubepisodeBasedNabizResult): Promise<any>{
        let that = this;
    
        let apiUrl: string = '/api/ENabizPackageManagementService/DeleteSysAndSend101';

        this.httpService.post<string>(apiUrl, row).then(result => {

            ServiceLocator.MessageService.showInfo(result);

            this.loadPanelOperation(false, '');
            this.getSubepisodes();

        })
            .catch(error => {
                this.errorHandlerForNabizForm(error);
            });
    }
    
    errorHandlerForNabizForm(message: string): void {
        this.loadPanelOperation(false, '');
        ServiceLocator.MessageService.showError(message);
        console.log(message);
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }
    SGKHizmetSorgulamaResultColumns = [
        { caption: 'durum', dataField: 'durum', fixed: true, width: '100' },
        { caption: 'SYS Takip No', dataField: 'sysTakipNo', fixed: true, width: '150' },
        { caption: 'İşlem Ref. No.', dataField: 'islemReferansNo', fixed: true, width: '110' },
        { caption: 'İşlem Kodu', dataField: 'islemKodu', fixed: true, width: '100' },
        { caption: 'İşlem Tar.', dataField: 'islemTarihi', fixed: true, width: '100' },
        { caption: 'SGK Takip No', dataField: 'sgkTakipNo', fixed: true, width: '80' },
        { caption: 'Turu', dataField: 'islemTuru', dataType: 'string', width: '80' },
        { caption: 'SGK Ref.No', dataField: 'sgkHizmetReferansNo', width: '80' },
        { caption: 'Oluşturulma T.', dataField: 'olusturulmaZamani', dataType: 'date', format: 'dd/MM/yyyy HH:mm:ss', width: '150' },
        { caption: 'Güncelleme T.', dataField: 'guncellenmeZamani', dataType: 'date', format: 'dd/MM/yyyy HH:mm:ss', width: '150' },
        { caption: 'SGK Gönderim T.', dataField: 'sgkGonderimZamani', dataType: 'date', format: 'dd/MM/yyyy HH:mm:ss', width: '150' },
        { caption: 'SGK Sonuç Msj', dataField: 'sgkSonucMesaji', width: '200' },
        { caption: 'SGK Sonuç Kodu', dataField: 'sgkSonucKodu', dataType: 'string', width: '200' },
        { caption: 'Silindi', dataField: 'silindi', dataType: 'bool', width: '200' },
        { caption: 'Hash ID', dataField: 'hashID', width: '80' }
    ];

    customizeCountText(data) {
        return "Kayıt Sayısı:" + data.value;
    }

    public _PackagesBySubepisode: Array<PackageDetail> = new Array<PackageDetail>();
    PackagesColumns = [
        { caption: 'Paket Kodu', dataField: 'PackageCode',fixed: true, width: '80' },
        { caption: 'Paket Adı', dataField: 'PackageName', fixed: true,width: '220' },
        { caption: 'Durum', dataField: 'StatusName', fixed: true,width: '90' },
        { caption: 'Eklenme Zamanı', dataField: 'RecordDate', width: '110' },
        { caption: 'Cevap Kodu', dataField: 'ResponseCode', width: '80' },
        { caption: 'Cevap Mesajı', dataField: 'ResponseMessage', width: '250' },
        { caption: 'Gönderim Zamanı', dataField: 'SendDate', width: '110' },
        { caption: 'İşlem/Malzeme/İlaç Adı', dataField: 'ProcedureDetail', width: '200' },
        {"caption": "", width: 40,allowSorting: false,allowEditing: false, cellTemplate: "sendNabizTemplate"}


    ]

    SendNabizPackage(data:PackageDetail)
    {
        let that = this;
        let apiUrl: string = '/api/ENabizPackageManagementService/SendNabizPackage';

        this.httpService.post<Array<NabizResponse>>(apiUrl, data).then(result => {

            ServiceLocator.MessageService.showInfo(result[0].SonucKodu + "-" + result[0].SonucMesaji);
               
            this.loadPanelOperation(false, '');

            this.getsubepisodepackagedetails(data.SubepisodeObjectID);

        })
            .catch(error => {
                this.errorHandlerForNabizForm(error);
            });
    }

    public async Send101(row: SubepisodeBasedNabizResult): Promise<any> {
        let that = this;
        let apiUrl: string = '/api/ENabizPackageManagementService/Send101FromSubepisode';

        this.httpService.post<Array<NabizResponse>>(apiUrl, row).then(result => {

            ServiceLocator.MessageService.showInfo(result[0].SonucKodu + "-" + result[0].SonucMesaji);

            this.loadPanelOperation(false, '');
            this.getSubepisodes();
        })
            .catch(error => {
                this.errorHandlerForNabizForm(error);
            });
    }

 
    public async Send402(row: SubepisodeBasedNabizResult): Promise<any> {
        let that = this;
        if (row.SYSTakipNo == "") {
            ServiceLocator.MessageService.showError("SYS Takip Numarası olmayan hastalara sorgulama yapamazsınız.");

            return;
        }
        let apiUrl: string = '/api/ENabizPackageManagementService/Send402';

        this.httpService.post<string>(apiUrl, row).then(result => {

            this._402PopUpVisible = true;
            this._402Result = result;
            //ServiceLocator.MessageService.showInfo(result[0].SonucKodu + "-" + result[0].SonucMesaji);

            //this.loadPanelOperation(false, '');
             
            
        })
            .catch(error => {
                this.errorHandlerForNabizForm(error);
            });
    }

    SubepisodeInfoHidden() {
        this._PackagesBySubepisode = new Array<PackageDetail>();
    }

    SendPackagesWithErrors() {
        let that = this;
        this.loadPanelOperation(true, "Hatalı ve Sıradaki Paketler E-Nabız'a Gönderiliyor, Lütfen Bekleyiniz.");
        let apiUrl: string = '/api/ENabizPackageManagementService/SendPackagesWithErrors';

        this.httpService.post<Array<NabizResponse>>(apiUrl, this._PackagesBySubepisode ).then(result => {

            //ServiceLocator.MessageService.showInfo(result[0].SonucKodu + "-" + result[0].SonucMesaji);

            this.loadPanelOperation(false, '');

            this.getsubepisodepackagedetails(this._PackagesBySubepisode[0].SubepisodeObjectID);

        })
            .catch(error => {
                this.errorHandlerForNabizForm(error);
            });
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let sgkHizmetSorgulamaBySGKTakipNo = new DynamicSidebarMenuItem();
        sgkHizmetSorgulamaBySGKTakipNo.key = 'sgkHizmetSorgulamaBySGKTakipNo';
        sgkHizmetSorgulamaBySGKTakipNo.componentInstance = this;
        sgkHizmetSorgulamaBySGKTakipNo.label = 'SGK Takip No İle Hizmet Sorgulama';
        sgkHizmetSorgulamaBySGKTakipNo.icon = 'fa fa-paper-plane-o';
        sgkHizmetSorgulamaBySGKTakipNo.clickFunction = this.SGKSorgula_SGKTakipNo;
        this.sideBarMenuService.addMenu('YardimciMenu', sgkHizmetSorgulamaBySGKTakipNo);

        let sendPathology = new DynamicSidebarMenuItem();
        sendPathology.key = 'sendPathology';
        sendPathology.componentInstance = this;
        sendPathology.label = 'Sıradaki Patolojileri Gönder';
        sendPathology.icon = 'fa fa-paper-plane-o';
        sendPathology.clickFunction = this.send201Dummy;
        this.sideBarMenuService.addMenu('YardimciMenu', sendPathology);


        let islemSorgulama = new DynamicSidebarMenuItem();
        islemSorgulama.key = 'islemSorgulama';
        islemSorgulama.componentInstance = this;
        islemSorgulama.label = 'Bu İşlem Bana Ait Değil Sorgulama';
        islemSorgulama.icon = 'fa fa-paper-plane-o';
        islemSorgulama.clickFunction = this.IslemSorgula;
        this.sideBarMenuService.addMenu('YardimciMenu', islemSorgulama);


        let receteBilgileri = new DynamicSidebarMenuItem();
        receteBilgileri.key = 'receteBilgileri';
        receteBilgileri.componentInstance = this;
        receteBilgileri.label = 'Reçete Bilgileri Sorgulama';
        receteBilgileri.icon = 'fa fa-paper-plane-o';
        receteBilgileri.clickFunction = this.getPrescriptionInfo;
        this.sideBarMenuService.addMenu('YardimciMenu', receteBilgileri);
    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('sgkHizmetSorgulamaBySGKTakipNo');
        this.sideBarMenuService.removeMenu('sendPathology');
        this.sideBarMenuService.removeMenu('islemSorgulama');
        this.sideBarMenuService.removeMenu('receteBilgileri');
    }

    private SGKSorgula_SGKTakipNo() {
        this._SGKTakipNoPopUpVisible = true;
    }
    private _IslemBanaAitDegilDate: Date = new Date();

    private IslemSorgula() {
        this._IslemBanaAitDegilVisible = true;
    }

   

     
    public IslemBanaAitDegilColumns =
        [
            {
                caption: "Sys Takip No",
                dataField: 'sysTakipNo',
                width: '150',
                allowEditing: false
            }, {
                caption: "İşlem Kodu",
                dataField: 'islemKodu',
                width: '100',
                allowEditing: false
            }, {
                caption: "İşlem Adı",
                dataField: 'islemAdi',
                width: '200',
                allowEditing: false
            }, {
                caption: "XXXXXX Adı",
                dataField: 'XXXXXX',
                width: '200',
                allowEditing: false
            }];

    IslemBanaAitDegilDataSource: Array<IslemBanaAitDegilResultModel> = new Array<IslemBanaAitDegilResultModel>();

    IslemBanaAitDegilListele() {
        let that = this;
        this.loadPanelOperation(true, "E-Nabız'dan sorgulanıyor, lütfen bekleyiniz.");
        let input: any = {};
        input.SelectedDate = this._IslemBanaAitDegilDate;
        let fullApiUrl: string = "/api/ENabizPackageManagementService/IslemBanaAitDegilListele";
        this.httpService.post<IslemBanaAitDegilResponse>(fullApiUrl, input)
            .then(response => {
                //that.eNabizPackagesFormViewModel = response as ENabizPackagesFormViewModel;
                this.loadPanelOperation(false, '');
                if (response.sonuc.length > 0) {
                    this.IslemBanaAitDegilDataSource = response.sonuc;
                } else {
                    TTVisual.InfoBox.Alert("Seçilen gün için kayıt bulunmamaktadır.");
                }


            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                console.log(error);
            });
    }

    private onSGKSorgula_SGKTakipNo() {//Servis SGK Takip numarası ile sorgulandığında ilgili takip numarasına ait tüm kayıtları döner
        let shsm: any = {};
        shsm.SGKTakipNo = this._SGKTakipNo;
        this.loadPanelOperation(true, "E-Nabız'dan SGK hizmetleri sorgulanıyor, lütfen bekleyiniz.");
        let apiUrl: string = '/api/ENabizPackageManagementService/SGKHizmetSorgulamaBySGKTakipNo';

        this.httpService.post(apiUrl, shsm).then(result => {
            this.showSGKHizmetSorgulamaPopup = true;
            this.SGKHizmetSorgulamaResultDataSource = result;
            this.loadPanelOperation(false, '');
        })
            .catch(error => {
                this.errorHandlerForNabizForm(error);
            });
    }

    SendSelectedPackages(): void {

        if (this.selectedENabizPackages.length == 0) {
            TTVisual.InfoBox.Alert("Gönderilecek paketleri seçiniz.");
            return;
        }
        this.loadPanelOperation(true, "Seçilen Paketler E-Nabız'a Gönderiliyor, Lütfen Bekleyiniz.");
        let apiUrl: string = '/api/ENabizPackageManagementService/SendSelectedPackages';

        this.httpService.post(apiUrl, this.selectedENabizPackages).then(response => {
           
            this.getRecords();
            this.loadPanelOperation(false, '');
        }).catch(error => {
            console.log(error);
        });
    }

    onContextMenuPreparingSubepisodeList(e: any) {
        let that = this;
        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data') {
                e.items = [{
                    text: "Sys Takip No Sorgulama",
                    onItemClick: function () {

                        that.Send402(e.row.data);
                    }
                }, {
                        text: "SGK Sorgula(700)",
                        onItemClick: function () {

                            that.SGKSorgula_SYSTakipNo(e.row.data);
                        }
                    },{
                        text: "Yeni Sys Takip No Al",
                        onItemClick: function () {

                            that.DeleteSysAndSend101(e.row.data);
                        }
                    }, {
                        text: "Reçete Bilgisi Sorgula",
                        onItemClick: function () {

                            that.GetPrescriptionInfo(e.row.data);
                        }
                    }]
            }
        }
    }

    sendPursaklarGuSonu(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/sendGunSonuPursaklar';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    sendOlayAfet(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/sendOlayAfet';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }
    send262(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send262';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }

    send301(): void {
        let apiUrl: string = '/api/ENabizPackageManagementService/send301';
        this.httpService.post(apiUrl, "").then(response => {
        }).catch(error => {
            console.log(error);
        });
    }


    private _prescriptionDate: Date = new Date();


    private _pageNumber: number = 1;
    private getPrescriptionInfo() {
        this._precriptionInfoVisible = true;
    }

    GetReceteBilgileriTarih() {
        let that = this;
        this.loadPanelOperation(true, "E-Nabız'dan Sorgulanıyor, Lütfen Bekleyiniz.");
        let input: any = {};
        input.StartDate = this._prescriptionDate;
        input.PageNumber = this._pageNumber;
        let fullApiUrl: string = "/api/ENabizPackageManagementService/GetReceteBilgileriTarih";
        this.httpService.post<any>(fullApiUrl, input)
            .then(response => {

                //this.loadPanelOperation(false, '');
                //if (response.sonuc.length > 0) {
                //    this.IslemBanaAitDegilDataSource = response.sonuc;
                //} else {
                //    TTVisual.InfoBox.Alert("Seçilen gün için kayıt bulunmamaktadır.");
                //}


            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                console.log(error);
            });
    }
}


