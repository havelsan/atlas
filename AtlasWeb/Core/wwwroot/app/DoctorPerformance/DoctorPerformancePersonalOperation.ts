//$B031EBC6
import { Component, AfterViewInit/*, enableProdMode*/ } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { LanguageData, CountryInfo, Service } from './app.service';
import { BarChartModel } from './DoctorPerformanceViewModel';
import { Guid } from '../NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

//if (!/localhost/.test(document.location.host)) {
//    enableProdMode();
//}


@Component({
    selector: "dp-personal-operation",
    templateUrl: './DoctorPerformancePersonalOperation.html',
    providers: [Service]
})
export class DoctorPerformancePersonalOperation implements AfterViewInit {

     
    internetLanguages: LanguageData[];
    DailyInfo: Array<BarChartModel>;
    ProcedureInfo: Array<BarChartModel>;
    ProcedureTypeInfo: Array<BarChartModel>;
    TedaviTuruInfo: Array<BarChartModel>;
    constructor(protected http: NeHttpService, service: Service) {
        //this.countriesInfo = service.getCountriesInfo();
        this.internetLanguages = service.getLanguagesData();
    }
    customizeLabel(point) {
        return point.argumentText + ": " + point.valueText ;
    }

    ngAfterViewInit() {

    }
    public selectedTerm;
    termValueChanged(event: any) {
        console.log("Term value changed");
        console.log(event);
        this.loadDailyChartDataSource(event);
        this.loadProcedurePieChartDataSource(event);
        this.loadProcedureTypePieChartDataSource(event);
        this.loadTedaviTuruPieChartDataSource(event);
    }

    errorHandler(message: string): void {
        this.loadPanelOperation(false, '');
        ServiceLocator.MessageService.showError(message);
        console.log(message);
        
    }

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    customizeTooltip2(arg: any) {
        return {
            //text: arg.valueText
            text: arg.point.data.Description + " " + arg.point.data.Value
        };
    }

    customizeTooltipBar(arg: any) {
        return { 
            text:   arg.point.data.Value
        };
    }
    loadDailyChartDataSource(termID: Guid): void {
        this.http.get<Array<BarChartModel>>("api/DoctorPerformanceApi/getDailyChartDataSource?TermID=" + termID).then(result => {
            this.DailyInfo = result;
        }).catch(error => {
            this.errorHandler(error);
        });
    }
    loadProcedurePieChartDataSource(termID: Guid): void {
        this.http.get<Array<BarChartModel>>("api/DoctorPerformanceApi/getProcedurePieChartDataSource?TermID=" + termID).then(result => {
            this.ProcedureInfo = result;
        }).catch(error => {
            this.errorHandler(error);
        });
    }
    loadProcedureTypePieChartDataSource(termID: Guid): void {
        this.http.get<Array<BarChartModel>>("api/DoctorPerformanceApi/getProcedureTypePieChartDataSource?TermID=" + termID).then(result => {
            this.ProcedureTypeInfo = result;
        }).catch(error => {
            this.errorHandler(error);
        });
    }
    loadTedaviTuruPieChartDataSource(termID: Guid): void {
        this.http.get<Array<BarChartModel>>("api/DoctorPerformanceApi/getTedaviTuruPieChartDataSource?TermID=" + termID).then(result => {
            this.TedaviTuruInfo = result;
        }).catch(error => {
            this.errorHandler(error);
        });
    }
}