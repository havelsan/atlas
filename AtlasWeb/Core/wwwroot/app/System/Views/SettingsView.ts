//$4850B003
import { Component, OnInit } from '@angular/core';
import { ThemeService } from 'app/Fw/Services/ThemeService';
import { StockMenuItem } from 'app/Logistic/Models/LogisticMainViewModel';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'hvl-settings-view',
    templateUrl: './SettingsView.html',
})


export class SettingsView implements OnInit {

    themes: Array<any>;
    StockMenuTypes: Array<StockMenuItem>;


    initTheme: string;
    initMenuType: number;
    constructor(
        private themeService: ThemeService,
        private httpService: NeHttpService
    ) {

        this.themes = this.themeService.getThemes();
    }

    themeChanged(data) {

        let item = data.value;
        this.themeService.setTheme(item);

        localStorage.setItem('selectedTheme', item);
    }


    ngOnInit() {
        this.StockMenuTypes = new Array<StockMenuItem>();
        let item: StockMenuItem = new StockMenuItem();
        item.Name = 'Yeni Ekran';
        item.Value = 1;
        this.StockMenuTypes.push(item);
        let item1: StockMenuItem = new StockMenuItem();
        item1.Name = 'Klasik Ekran';
        item1.Value = 2;
        this.StockMenuTypes.push(item1);

        let selectedTheme = localStorage.getItem('selectedTheme');
        if (selectedTheme == null) {
            selectedTheme = 'Default';
        }
        this.getUserOptionForStockMenu().then(res =>
            this.initMenuType = res
        );
        this.initTheme = selectedTheme;

    }

    menuTypeChanged(data) {
        if (data.previousValue != null)
            this.saveUserOptionForStockMenu(data.value);
    }

    async getUserOptionForStockMenu(): Promise<number> {

        try {
            let apiUrl: string = 'api/MainView/GetUserOptionStockMenuValue';
            let result = await this.httpService.post<number>(apiUrl, null);
            if (result != null) {
                if (result != null)
                    return result;
                else
                    return 2;
            }
            else
                return 2;
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            return 2;
        }
    }

    async saveUserOptionForStockMenu(data) {

        try {
            let apiUrl: string = 'api/MainView/SaveUserOptionStockMenuValue?userOptionValue=' + data.toString();
            let result = await this.httpService.post(apiUrl,null);
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

}