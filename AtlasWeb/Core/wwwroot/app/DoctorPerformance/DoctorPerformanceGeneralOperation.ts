//$B031EBC6
import { Component, AfterViewInit, ViewChild/*, enableProdMode */} from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import {  DxPivotGridComponent,  DxChartComponent } from 'devextreme-angular';
import { MaleAgeStructure, Service } from './app.service';
import { CurrencyPipe } from '@angular/common';
import { BarChartModel } from './DoctorPerformanceViewModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Guid } from '../NebulaClient/Mscorlib/Guid';

//if (!/localhost/.test(document.location.host)) {
//    enableProdMode();
//}

@Component({
    selector: "dp-general-operation",
    templateUrl: './DoctorPerformanceGeneralOperation.html',
    providers: [Service, CurrencyPipe]
})
export class DoctorPerformanceGeneralOperation implements AfterViewInit {
    @ViewChild('pivotgrid') pivotGrid: DxPivotGridComponent;
    @ViewChild('salesChart') chart: DxChartComponent;
    @ViewChild('bransChart') bransChart: DxChartComponent;
    @ViewChild('doktorChart') doktorChart: DxChartComponent;
    @ViewChild('hizmetChart') hizmetChart: DxChartComponent;


    pivotGridDataSource: any;
    hizmetDataSource: Array<BarChartModel>;
    doktorDataSource: Array<BarChartModel>;
    bransDataSource: Array<BarChartModel>;
    constructor(protected http: NeHttpService, service: Service, private currencyPipe: CurrencyPipe) {
        this.customizeTooltip = this.customizeTooltip.bind(this);
        this.pivotGridDataSource = {
            fields: [{
                caption: "Region",
                width: 120,
                dataField: "region",
                area: "row",
                sortBySummaryField: "Toplam"
            }, {
                caption: "City",
                dataField: "city",
                width: 150,
                area: "row"
            }, {
                dataField: "date",
                dataType: "date",
                area: "column"
            }, {
                groupName: "date",
                groupInterval: "month",
                visible: false
            }, {
                caption: "Toplam",
                dataField: "amount",
                dataType: "number",
                summaryType: "sum",
                area: "data"
            } ],
            store: service.getSales()
        };
    }


    loadHizmetChartDataSource(termID: Guid): void {
        this.http.get<Array<BarChartModel>>("api/DoctorPerformanceApi/getHizmetChartDataSource?TermID=" + termID).then(result => {
            this.hizmetDataSource = result;
        }).catch(error => {
            this.errorHandler(error);
        });
    }

    loadDoctorChartDataSource(termID: Guid): void {
        this.http.get<Array<BarChartModel>>("api/DoctorPerformanceApi/getDoctorChartDataSource?TermID=" + termID).then(result => {
            this.doktorDataSource = result;
        }).catch(error => {
            this.errorHandler(error);
        });
    }

    loadBransChartDataSource(termID: Guid): void {
        this.http.get<Array<BarChartModel>>("api/DoctorPerformanceApi/getBranchChartDataSource?TermID=" + termID).then(result => {
            this.bransDataSource = result;
        }).catch(error => {
            this.errorHandler(error);
        });
    }

    ngAfterViewInit() {
        this.pivotGrid.instance.bindChart(this.chart.instance, {
            dataFieldsDisplayMode: "splitPanes",
            alternateDataFields: false
        });

        window.setTimeout(t => {
            this.bransChart.instance.render();
            this.doktorChart.instance.render();
            this.hizmetChart.instance.render();
        }, 350);
    }
    ngStyleForBarCharts() {
        return {
            'height': '100%'
        };
    }
    btnGetDoctorPerformanceDetailsClick(): void {
        alert("Yapım Aşamasında");
    }
    customizeTooltip(args) {
        const valueText = (args.seriesName.indexOf("Total") != -1) ?
            this.currencyPipe.transform(args.originalValue, "USD", "symbol", "1.0-0") :
            args.originalValue;

        return {
            html: args.seriesName + "<div class='currency'>" + valueText + "</div>"
        };
    }
    customizeTooltip2(arg: any) {
        return {
            text:   arg.valueText
        };
    }
    public selectedTerm;
    termValueChanged(event: any) {
        console.log("Term value changed");
        this.loadHizmetChartDataSource(event);
        this.loadDoctorChartDataSource(event);
        this.loadBransChartDataSource(event);
        console.log(event);
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

}