import { Component, OnInit, ViewChild, Input, Renderer2 } from '@angular/core';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import {
    DynamicComponentInfoDVO
} from 'app/Logistic/Models/LogisticMainViewModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from "app/NebulaClient/Visual/TTUnboundForm";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { Headers, RequestOptions } from '@angular/http';
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { TransactionTypeEnum, ResUser, ResClinic, ActiveIngredientDefinition } from "app/NebulaClient/Model/AtlasClientModel";
import { DxAccordionComponent } from "devextreme-angular";
import { DynamicComponentInfo } from "app/Fw/Models/DynamicComponentInfo";
import { IModalService } from "app/Fw/Services/IModalService";
import { FavoriteDrugReportFormViewModel, FavoriteDrug_Output } from './FavoriteDrugReportFormViewModel';

@Component({
    selector: "FavoriteDrugReportForm",
    templateUrl: './FavoriteDrugReportForm.html',
    providers: [SystemApiService, MessageService]
})

export class FavoriteDrugReportForm extends TTUnboundForm implements OnInit {
    public FavoriteDrugReportFormViewModel: FavoriteDrugReportFormViewModel;
    public visibility: boolean = false;
    public showLoadPanel = false;
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';
    public favoriteDrugList: Array<FavoriteDrug_Output> = new Array<FavoriteDrug_Output>();
    public TotalNumberOfRows: number;

    public FavoriteDrugGridColumns = [
        {
            'caption': "Doktor Adı Soyadı",
            dataField: 'DoctorName',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "İlaç",
            dataField: 'DrugName',
            dataType: 'string',
            allowSorting: true,
        },
        {
            'caption': "Miktar",
            dataField: 'Amount',
            dataType: 'number',
            allowSorting: true
        },

    ];
    
    constructor(protected httpService: NeHttpService, private modalService: IModalService, protected messageService: MessageService, public systemApiService: SystemApiService, private renderer: Renderer2) {
        super('FavoriteDrugReport','FavoriteDrugReportForm');
        this.initViewModel();
    }

    public initViewModel(): void {
        this.FavoriteDrugReportFormViewModel = new FavoriteDrugReportFormViewModel();
    }

    async ngOnInit() {
        this.FillDataSources();
    }

    DoctorList: Array<ResUser.ClinicDoctorListNQL_Class>;
    async FillDataSources() {
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DrugReturnReportService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.DoctorList = result.DoctorList;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public onDoctorSelectionChanged(data) {
        if (data.addedItems.length > 0) {
            this.FavoriteDrugReportFormViewModel.SelectedDoctorList.push(data.addedItems[0].ObjectID);
        }
        else if (data.removedItems.length > 0) {
            this.FavoriteDrugReportFormViewModel.SelectedDoctorList.splice(this.FavoriteDrugReportFormViewModel.SelectedDoctorList.findIndex(x => x.Equals(data.removedItems[0].ObjectID)), 1);
        }
    }

    public async GetDrugReturnActionList() {
        this.showLoadPanel = true;
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/FavoriteDrugReportService/GetFavoriteDrugs';
            let body = { 'viewModel': this.FavoriteDrugReportFormViewModel};
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<Array<FavoriteDrug_Output>>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.favoriteDrugList = result;
                    
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
            this.TotalNumberOfRows = this.favoriteDrugList.length;
        }
        catch (ex) {

        }
        finally {
            this.showLoadPanel = false;
        }
    }
}
