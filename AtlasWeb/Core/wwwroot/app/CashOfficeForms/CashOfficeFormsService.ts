import { Injectable, OnDestroy, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DailyRateDefinitionsDTO } from 'Modules/Doner_Sermaye_Saymanligi_Modulleri/MDS014_Hizmet_Karsiligi_Makbuz_Kesimi/ReceiptFormViewModel';
import { CurrencyTypeDefinition } from 'app/NebulaClient/Model/AtlasClientModel';

@Injectable()
export class CashOfficeFormsService implements OnInit, OnDestroy {

    constructor(private http: NeHttpService) {

    }

    public CurrencyTypes: Array<any> = null;

    public GetCurrencyTypes() {
        if (this.CurrencyTypes == null)
            this.http.get<any>('api/CashOfficeFormViewApi/InitCashOfficeForm').then(res => {
                this.CurrencyTypes = res.CurrencyTypes;
            });
    }

    public async GetCurrecnyValue(qref: string): Promise<DailyRateDefinitionsDTO> {
        return new Promise<DailyRateDefinitionsDTO>((resolve, reject) => {
            let that = this;
            this.http.get<DailyRateDefinitionsDTO>('api/CashOfficeFormViewApi/GetCurrencyValue?qref=' + qref).then(result => {
                resolve(result);
            }).catch(error => {
                reject(error);
            });
        });
    }

    public ChangeMoneyPaid(value: any, convertedTotalPayment: number, currencyType: CurrencyTypeDefinition) {
        if (currencyType != null) {
            if (currencyType.Qref != 'TL')
                value.MoneyPaid = null;
            else
                value.MoneyPaid = convertedTotalPayment;
        }
    }

    public CalculateRemainderOfMoney(moneyPaid: number, currecnyRate: number, totalPayment: number, advanceTotal: number): number {
        if (moneyPaid != null && moneyPaid > 0) {
            if (advanceTotal == 0)
                return Math.Round((moneyPaid * currecnyRate) - totalPayment, 2);
            else if (moneyPaid * currecnyRate <= advanceTotal)
                return Math.Round((advanceTotal) - totalPayment, 2);
            else
                return Math.Round((moneyPaid * currecnyRate) - totalPayment, 2);
        }
        else
            return null;
    }

    ngOnInit(): void {
        this.GetCurrencyTypes();
    }

    ngOnDestroy(): void {
        this.CurrencyTypes = null;
    }
}