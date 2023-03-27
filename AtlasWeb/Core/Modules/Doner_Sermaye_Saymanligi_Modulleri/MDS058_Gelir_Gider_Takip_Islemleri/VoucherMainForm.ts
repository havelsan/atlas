//$51CD9FC5
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IntegerParam } from 'app/NebulaClient/Mscorlib/IntegerParam';

@Component({
    selector: 'VoucherMainForm',
    templateUrl: './VoucherMainForm.html',
    providers: [MessageService]
})
export class VoucherMainForm extends TTVisual.TTForm implements OnInit {
    GelirAccountPeriod: TTVisual.ITTObjectListBox;
    GiderAccountPeriod: TTVisual.ITTObjectListBox;
    ToplamYekunAccountPeriod: TTVisual.ITTObjectListBox;
    SelectedGelirAccountPeriod: any;
    SelectedGiderAccountPeriod: any;
    SelectedToplamYekunAccountPeriod: any;
    SelectedMuhasebeAccountPeriod: any;
    SelectedTotalDebtAccountPeriod: any;
    AllYear: boolean = false;
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected reportService: AtlasReportService, ) {
        super('', '');
        this.initFormControls();
        this.GetAccountVoucher();
    }

    public onGelirAccountPeriodChanged(event): void {
        this.SelectedGelirAccountPeriod = event;
    }

    public onGiderAccountPeriodChanged(event): void {
        this.SelectedGiderAccountPeriod = event;
    }

    public onMuhasebeAccountPeriodChanged(event): void {
        this.SelectedMuhasebeAccountPeriod = event;
    }

    public onToplamYekunAccountPeriodChanged(event): void {
        this.SelectedToplamYekunAccountPeriod = event;
    }

    public GelirGiderToplamYekunColumns = [
        {
            'caption': "Ay",
            dataField: 'month',
            cellTemplate: "MonthCellTemplate"
        },
        {
            'caption': "Yıl",
            dataField: 'year',
        },
        {
            'caption': "Toplam Gelir",
            dataField: 'totalNonDept',
            cellTemplate: "totalNonDeptCellTemplate",
            cssClass: "remove-padding"
        },
        {
            'caption': "Toplam Gider",
            dataField: 'totalDept',
            cellTemplate: "totalDeptCellTemplate",
            cssClass: "remove-padding"
        },
        {
            'caption': "Fark",
            dataField: 'totalDifference',
            cellTemplate: "totalDifferenceCellTemplate",
            cssClass: "remove-padding"
        }
    ];

    public MuhasebeGunSureColumns = [
        {
            'caption': "Yıl",
            dataField: 'Year',
        },
        {
            'caption': "Ay",
            dataField: 'Month',
            cellTemplate: "MonthCellTemplate",
        },
        {
            'caption': "Taşınır Ortalama",
            dataField: 'MovableAverage',
            cellTemplate: "MovableAverageCellTemplate",
            cssClass: "remove-padding"
        },
        {
            'caption': "Hizmet Ortalama",
            dataField: 'ProcedureAverage',
            cellTemplate: "ProcedureAverageCellTemplate",
            cssClass: "remove-padding"
        },
        {
            'caption': "Ortalama",
            dataField: 'Average',
            cellTemplate: "AverageCellTemplate",
            cssClass: "remove-padding"
        }
    ];

    public ToplamBorcColumns = [
        {
            'caption': "Yıl",
            dataField: 'Year',
        },
        {
            'caption': "Ay",
            dataField: 'Month',
            cellTemplate: "MonthCellTemplate",
        },
        {
            'caption': "Toplam Borç",
            dataField: 'TotalDebt',
            cellTemplate: "TotalDebtCellTemplate",
            cssClass: "remove-padding"
        }
    ];


    public MonthDt = [
        {
            Name: "Tümü",
            Value: 0
        },
        {
            Name: "Ocak",
            Value: 1
        },
        {
            Name: 'Şubat',
            Value: 2
        },
        {
            Name: 'Mart',
            Value: 3
        },
        {
            Name: 'Nisan',
            Value: 4
        },
        {
            Name: 'Mayıs',
            Value: 5
        },
        {
            Name: 'Haziran',
            Value: 6
        },
        {
            Name: 'Temmuz',
            Value: 7
        },
        {
            Name: 'Ağustos',
            Value: 8
        },
        {
            Name: 'Eylül',
            Value: 9
        },
        {
            Name: 'Ekim',
            Value: 10
        },
        {
            Name: 'Kasım',
            Value: 11
        },
        {
            Name: 'Aralık',
            Value: 12
        }
    ];

    public GelirGiderMonthDt = [
        {
            Name: "Tümü",
            Value: 0
        },
        {
            Name: "Ocak",
            Value: 1
        },
        {
            Name: 'Şubat',
            Value: 2
        },
        {
            Name: 'Mart',
            Value: 3
        },
        {
            Name: 'Nisan',
            Value: 4
        },
        {
            Name: 'Mayıs',
            Value: 5
        },
        {
            Name: 'Haziran',
            Value: 6
        },
        {
            Name: 'Temmuz',
            Value: 7
        },
        {
            Name: 'Ağustos',
            Value: 8
        },
        {
            Name: 'Eylül',
            Value: 9
        },
        {
            Name: 'Ekim',
            Value: 10
        },
        {
            Name: 'Kasım',
            Value: 11
        },
        {
            Name: 'Aralık',
            Value: 12
        }
    ];

    public GelirGiderRaporColumns = [
        {
            'caption': "Ay",
            dataField: 'Month',
            cellTemplate: "MonthCellTemplate",
        },
        {
            'caption': "Yıl",
            dataField: 'Year',
        },

        {
            'caption': "Kodu",
            dataField: 'Code',
        },
        {
            'caption': "Açıklama",
            dataField: 'Description',
        },
        {
            'caption': "Toplam Tutar",
            dataField: 'TotalPrice',
            cellTemplate: "TotalPriceCellTemplate",
            cssClass: "remove-padding"
        }
    ];
    donemvisible: boolean = false;
    gelirgidervisible: boolean = false;
    gelirgiderislemvisible: boolean = false;
    accountTotalDebtVisible: boolean = false;
    gelirgidertoplamyekunvisible: boolean = false;
    gelirraporvisible: boolean = false;
    giderraporvisible: boolean = false;
    muhaseberaporvisible: boolean = false;
    borcraporvisible: boolean = false;
    muhasebegunvisible: boolean = false;

    btnMuhasebelestirmeGunSuresi_Click() {
        this.muhasebegunvisible = true;
        this.muhaseberaporvisible = false;
        this.donemvisible = false;
        this.gelirgidervisible = false;
        this.gelirgiderislemvisible = false;
        this.gelirgidertoplamyekunvisible = false;
        this.gelirraporvisible = false;
        this.giderraporvisible = false;
        this.borcraporvisible = false;
        this.accountTotalDebtVisible = false;
    }

    btnToplamBorc_Click() {
        this.muhasebegunvisible = false;
        this.muhaseberaporvisible = false;
        this.donemvisible = false;
        this.gelirgidervisible = false;
        this.gelirgiderislemvisible = false;
        this.gelirgidertoplamyekunvisible = false;
        this.gelirraporvisible = false;
        this.giderraporvisible = false;
        this.borcraporvisible = false;
        this.accountTotalDebtVisible = true;
    }


    btnDonemTanim_Click() {
        this.donemvisible = true;
        this.gelirgidervisible = false;
        this.gelirgiderislemvisible = false;
        this.gelirgidertoplamyekunvisible = false;
        this.gelirraporvisible = false;
        this.giderraporvisible = false;
        this.muhaseberaporvisible = false;
        this.borcraporvisible = false;
        this.muhasebegunvisible = false;
        this.accountTotalDebtVisible = false;
    }

    btnGelirGiderTanim_Click() {
        this.gelirgidervisible = true;
        this.gelirgiderislemvisible = false;
        this.gelirgidertoplamyekunvisible = false;
        this.gelirraporvisible = false;
        this.giderraporvisible = false;
        this.muhaseberaporvisible = false;
        this.borcraporvisible = false;
        this.donemvisible = false;
        this.muhasebegunvisible = false;
        this.accountTotalDebtVisible = false;
    }

    btnGelirGiderIslem_Click() {
        this.gelirgiderislemvisible = true;
        this.gelirgidervisible = false;
        this.gelirgidertoplamyekunvisible = false;
        this.gelirraporvisible = false;
        this.giderraporvisible = false;
        this.muhaseberaporvisible = false;
        this.borcraporvisible = false;
        this.donemvisible = false;
        this.muhasebegunvisible = false;
        this.accountTotalDebtVisible = false;
    }

    btnGelirGiderToplamYekun_Click() {
        this.gelirgidertoplamyekunvisible = true;
        this.gelirgiderislemvisible = false;
        this.gelirgidervisible = false;
        this.gelirraporvisible = false;
        this.giderraporvisible = false;
        this.muhaseberaporvisible = false;
        this.borcraporvisible = false;
        this.donemvisible = false;
        this.muhasebegunvisible = false;
        this.accountTotalDebtVisible = false;
    }

    btnGelirRapor_Click() {
        this.gelirraporvisible = true;
        this.gelirgidertoplamyekunvisible = false;
        this.gelirgiderislemvisible = false;
        this.gelirgidervisible = false;
        this.giderraporvisible = false;
        this.muhaseberaporvisible = false;
        this.borcraporvisible = false;
        this.donemvisible = false;
        this.muhasebegunvisible = false;
        this.accountTotalDebtVisible = false;
    }

    btnGiderRapor_Click() {
        this.giderraporvisible = true;
        this.gelirraporvisible = false;
        this.gelirgidertoplamyekunvisible = false;
        this.gelirgiderislemvisible = false;
        this.gelirgidervisible = false;
        this.muhaseberaporvisible = false;
        this.borcraporvisible = false;
        this.donemvisible = false;
        this.muhasebegunvisible = false;
        this.accountTotalDebtVisible = false;
    }

    btnMuhasebeRapor_Click() {
        this.muhaseberaporvisible = true;
        this.giderraporvisible = false;
        this.gelirraporvisible = false;
        this.gelirgidertoplamyekunvisible = false;
        this.gelirgiderislemvisible = false;
        this.gelirgidervisible = false;
        this.borcraporvisible = false;
        this.donemvisible = false;
        this.muhasebegunvisible = false;
        this.accountTotalDebtVisible = false;
    }

    btnBorcRapor_Click() {
        this.borcraporvisible = true;
        this.muhaseberaporvisible = false;
        this.giderraporvisible = false;
        this.gelirraporvisible = false;
        this.gelirgidertoplamyekunvisible = false;
        this.gelirgiderislemvisible = false;
        this.gelirgidervisible = false;
        this.donemvisible = false;
        this.muhasebegunvisible = false;
        this.accountTotalDebtVisible = false;
    }

    CreateGelirReport() {
        const MONHT = new IntegerParam(this.SelectedGelirMonth);
        const YEAR = new IntegerParam(this.SelectedGelirAccountPeriod);

        let reportParameters: any = { 'MONTH': MONHT, 'YEAR': YEAR };
        this.reportService.showReport('GelirRaporu', reportParameters);

    }

    CreateGiderReport() {
        const MONHT = new IntegerParam(this.SelectedGiderMonth);
        const YEAR = new IntegerParam(this.SelectedGiderAccountPeriod);

        let reportParameters: any = { 'MONTH': MONHT, 'YEAR': YEAR };
        this.reportService.showReport('GiderRaporu', reportParameters);

    }

    CreateGelirGiderToplamYekunReport() {
        const MONHT = new IntegerParam(this.SelectedToplamYekunMonth);
        const YEAR = new IntegerParam(this.SelectedToplamYekunAccountPeriod);

        let reportParameters: any = { 'MONTH': MONHT, 'YEAR': YEAR };
        this.reportService.showReport('GelirGiderToplamYekunRaporu', reportParameters);
    }

    CreateMuhasebeGunSureReport() {
        const MONHT = new IntegerParam(this.SelectedMuhasebeMonth);
        const YEAR = new IntegerParam(this.SelectedMuhasebeAccountPeriod);

        let reportParameters: any = { 'MONTH': MONHT, 'YEAR': YEAR };
        this.reportService.showReport('MuhasebeGünSüresiRaporu', reportParameters);
    }

    CreateToplamBorcReport() {
        const MONHT = new IntegerParam(this.SelectedTotalDebtMonth);
        const YEAR = new IntegerParam(this.SelectedTotalDebtAccountPeriod);

        let reportParameters: any = { 'MONTH': MONHT, 'YEAR': YEAR };
        this.reportService.showReport('ToplamBorcRaporu', reportParameters);
    }

    AccountPeriodDefinition: Array<any> = new Array<any>();
    GetAccountVoucher() {
        let apiUrl: string = '/api/AccountVoucherService/GetAccountVoucherOnlyYear';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.AccountPeriodDefinition = x;
            });
    }

    SelectedToplamYekunMonth: any;
    GelirGiderToplamYekunList: Array<any> = new Array<any>();
    GetGelirGiderToplamYekun() {
        if (this.SelectedToplamYekunAccountPeriod == null) {
            this.messageService.showError("Lütfen Yıl Giriniz.");
            return;
        }

        let param: GetAccountVoucherDeptParam = new GetAccountVoucherDeptParam();
        param.Year = this.SelectedToplamYekunAccountPeriod;
        param.Month = this.SelectedToplamYekunMonth;
        let apiUrl: string = '/api/AccountVoucherService/GetToplamYekun';
        this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.GelirGiderToplamYekunList = x;
            });
    }
    SelectedGelirMonth: any;
    GelirRaporList: Array<any> = new Array<any>();
    GelirRapor() {
        if (this.SelectedGelirAccountPeriod == null) {
            this.messageService.showError("Lütfen Yıl Giriniz.");
            return;
        }

        let param: GetAccountVoucherDeptParam = new GetAccountVoucherDeptParam();
        param.Year = this.SelectedGelirAccountPeriod;
        param.Month = this.SelectedGelirMonth;
        let apiUrl: string = '/api/AccountVoucherService/GetAccountVoucherDept';
        this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.GelirRaporList = x;
            });
    }
    SelectedGiderMonth: any;
    GiderRaporList: Array<any> = new Array<any>();
    GiderRapor() {
        if (this.SelectedGiderAccountPeriod == null) {
            this.messageService.showError("Lütfen Yıl Giriniz.");
            return;
        }
        let param: GetAccountVoucherDeptParam = new GetAccountVoucherDeptParam();
        param.Year = this.SelectedGiderAccountPeriod;
        param.Month = this.SelectedGiderMonth;
        let apiUrl: string = '/api/AccountVoucherService/GetAccountVoucherIsDept';
        this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.GiderRaporList = x;
            });
    }

    SelectedMuhasebeMonth: any;
    MuhasebeRaporList: Array<any> = new Array<any>();
    MuhasebeRapor() {
        if (this.SelectedMuhasebeAccountPeriod == null) {
            this.messageService.showError("Lütfen Yıl Giriniz.");
            return;
        }
        let param: GetAccountDayTermParam = new GetAccountDayTermParam();
        param.Year = this.SelectedMuhasebeAccountPeriod;
        param.Month = this.SelectedMuhasebeMonth;
        let apiUrl: string = '/api/AccountVoucherService/GetAccountDayTerm';
        this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.MuhasebeRaporList = x;
            });
    }

    SelectedTotalDebtMonth: any;
    BorcRaporList: Array<any> = new Array<any>();
    BorcRapor() {
        if (this.SelectedTotalDebtAccountPeriod == null) {
            this.messageService.showError("Lütfen Yıl Giriniz.");
            return;
        }
        let param: GetAccountDayTermParam = new GetAccountDayTermParam();
        param.Year = this.SelectedTotalDebtAccountPeriod;
        param.Month = this.SelectedTotalDebtMonth;
        let apiUrl: string = '/api/AccountVoucherService/GetAccountTotalDebt';
        this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.BorcRaporList = x;
            });
    }

    async ngOnInit() {

    }

    public initFormControls(): void {


        this.GelirAccountPeriod = new TTVisual.TTObjectListBox();
        this.GelirAccountPeriod.ListDefName = "AccountPeriodList";
        this.GelirAccountPeriod.Name = "GelirAccountPeriod";
        this.GelirAccountPeriod.TabIndex = 3;

        this.GiderAccountPeriod = new TTVisual.TTObjectListBox();
        this.GiderAccountPeriod.ListDefName = "AccountPeriodList";
        this.GiderAccountPeriod.Name = "GiderAccountPeriod";
        this.GiderAccountPeriod.TabIndex = 3;

        this.ToplamYekunAccountPeriod = new TTVisual.TTObjectListBox();
        this.ToplamYekunAccountPeriod.ListDefName = "AccountPeriodList";
        this.ToplamYekunAccountPeriod.Name = "ToplamYekunAccountPeriod";
        this.ToplamYekunAccountPeriod.TabIndex = 3;


        this.Controls = [this.GelirAccountPeriod, this.GiderAccountPeriod, this.ToplamYekunAccountPeriod];

    }
}

export class GetAccountVoucherDeptParam {
    public Month: number;
    public Year: number;
}

export class GetAccountDayTermParam {
    public Month: number;
    public Year: number;
}

