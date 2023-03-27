import { Component, ElementRef } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { TransactionChartInputDTO } from '../Models/LogisticDashboardViewModel';

@Component({
    selector: 'transaction-chart-component',
    template: `
    <div class="container-fluid">
    <div class="row">
        <dx-tab-panel [selectedIndex]="0" [animationEnabled]="true" id="A32151">
            <dxi-item *ngIf="showInChart" class="tabpanel-item" title="Malzeme Girisleri" i18n-title="@@M18576" id="A32152">
                <div class="col-sm-6" id="A32153">
                    <dx-pie-chart id="pie" palette="Ocean" 
                                  [dataSource]="girisInfos" (onPointClick)="selectPieChartInStock($event)"
                                  [size]="{heigth:400,width:400}" i18n-title="@@M12624">
                        <dxo-legend orientation="horizontal" itemTextPosition="left"
                                    horizontalAlignment="right" verticalAlignment="bottom" [columnCount]="4"
                                    id="A32154"></dxo-legend>
                        <dxo-tooltip [enabled]="true" [customizeTooltip]="customizeLabel" id="A32155">
                        </dxo-tooltip>
                        <dxi-series argumentField="Description" valueField="Amount" id="A32156">
                            <dxo-label [visible]="true" position="columns"
                                       [customizeText]="customizeLabel" id="A32157">
                                <dxo-font [size]="16" id="A32158"></dxo-font>
                                <dxo-connector [visible]="true" [width]="0.5" id="A32159">
                                </dxo-connector>
                            </dxo-label>
                        </dxi-series>
                    </dx-pie-chart>
                </div>
                <div class="col-sm-6" id="A32160">
                    <label style="font-size: 20px;font-family: 'Segoe UI Light', 'Helvetica Neue Light', 'Segoe UI', 'Helvetica Neue', 'Trebuchet MS', Verdana;font-weight: 200; fill: #232323;cursor: default; margin-left:12%;margin-top: 5%;"
                           id="girisDetayLabel"></label>
                    <dx-pie-chart id="pie" palette="Ocean" [dataSource]="girisInfosDetail"
                                  [size]="{heigth:400,width:400}">
                        <dxo-legend orientation="horizontal" itemTextPosition="right"
                                    horizontalAlignment="right" verticalAlignment="bottom" [columnCount]="4" 
                                    id="A32161"></dxo-legend>
                        <dxo-tooltip [enabled]="true" [customizeTooltip]="customizeLabel" id="A32162">
                        </dxo-tooltip>
                        <dxi-series argumentField="description" valueField="amount" id="A32163">
                            <dxo-label [visible]="true" position="columns"
                                       [customizeText]="customizeLabel" id="A32164">
                                <dxo-font [size]="16" id="A32165"></dxo-font>
                                <dxo-connector [visible]="true" [width]="0.5" id="A32166">
                                </dxo-connector>
                            </dxo-label>
                        </dxi-series>
                    </dx-pie-chart>
                </div>
            </dxi-item>
            <dxi-item *ngIf="showOutChart" class="tabpanel-item" title="Malzeme Çıkışları" i18n-title="@@M18559" id="A32167">
                <div class="col-sm-6" id="A32168">
                    <dx-pie-chart id="pie" palette="Vintage" 
                                  [dataSource]="cikisInfos" (onPointClick)="selectPieChartOutStock($event)"
                                  [size]="{heigth:400,width:400}" i18n-title="@@M12623">
                        <dxo-legend orientation="horizontal" itemTextPosition="right"
                                    horizontalAlignment="right" verticalAlignment="bottom" [columnCount]="4"
                                    id="A32169"></dxo-legend>
                        <dxo-tooltip [enabled]="true" [customizeTooltip]="customizeLabel" id="A32170">
                        </dxo-tooltip>
                        <dxi-series argumentField="Description" valueField="Amount" id="A32171">
                            <dxo-label [visible]="true" position="columns"
                                       [customizeText]="customizeLabel" id="A32172">
                                <dxo-font [size]="16" id="A32173"></dxo-font>
                                <dxo-connector [visible]="true" [width]="0.5" id="A32174">
                                </dxo-connector>
                            </dxo-label>
                        </dxi-series>
                    </dx-pie-chart>
                </div>
                <div class="col-sm-6" id="A32175">
                    <label style="font-size: 20px;font-family: 'Segoe UI Light', 'Helvetica Neue Light', 'Segoe UI', 'Helvetica Neue', 'Trebuchet MS', Verdana;font-weight: 200; fill: #232323;cursor: default; margin-left:12%;margin-top: 5%;"
                           id="cikisDetayLabel"></label>
                    <dx-pie-chart id="pie" palette="Vintage" [dataSource]="cikisInfosDetail"
                                  [size]="{heigth:400,width:400}">
                        <dxo-legend orientation="horizontal" itemTextPosition="right"
                                    horizontalAlignment="right" verticalAlignment="bottom" [columnCount]="4"
                                    id="A32176"></dxo-legend>
                        <dxo-tooltip [enabled]="true" [customizeTooltip]="customizeLabel" id="A32177">
                        </dxo-tooltip>
                        <dxi-series argumentField="description" valueField="amount" id="A32178">
                            <dxo-label [visible]="true" position="columns"
                                       [customizeText]="customizeLabel" id="A32179">
                                <dxo-font [size]="16" id="A32180"></dxo-font>
                                <dxo-connector [visible]="true" [width]="0.5" id="A32181">
                                </dxo-connector>
                            </dxo-label>
                        </dxi-series>
                    </dx-pie-chart>
                </div>
            </dxi-item>
        </dx-tab-panel>
    </div>
</div>
 `
})
export class TransactionChartComponent implements IModal {
    public inputParam: TransactionChartInputDTO;
    public cikisInfos = new Array<any>();
    public girisInfos = new Array<any>();
    public cikisInfosDetail = new Array<any>();
    public girisInfosDetail = new Array<any>();
    public showInChart: boolean = false;
    public showOutChart: boolean = false;
    private _modalInfo: ModalInfo;

    constructor(private modalStateService: ModalStateService) {
    }

    public setInputParam(value: any) {
        this.inputParam = value as TransactionChartInputDTO;
        if (this.inputParam.StockInList.length > 0){
            this.girisInfos = this.inputParam.StockInList;
            this.showInChart = true;
        }

        if (this.inputParam.StockOutList.length > 0)
        {
            this.cikisInfos = this.inputParam.StockOutList;
            this.showOutChart = true;
        }
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    selectPieChartInStock(data: any) {
        this.girisInfosDetail = data.target.data.stockGirisDetayList;
        let html: HTMLElement = document.getElementById('girisDetayLabel');
        html.textContent = data.target.data.Description;
        
        /*for (let i = 0; (i < this.girisInfos.length); i++) {
            if (data.target.argument === this.girisInfos[i].Description) {
                let selectList = this.girisInfos[i].stockGirisDetayList;
                this.girisInfosDetail = selectList;

            }
        }*/
    }
    selectPieChartOutStock(data: any) {

        this.girisInfosDetail = data.target.data.stockCikisDetayList;
        let html: HTMLElement = document.getElementById('cikisDetayLabel');
        html.textContent = data.target.data.Description;

        /*for (let i = 0; (i < this.cikisInfos.length); i++) {
            if (data.target.argument === this.cikisInfos[i].Description) {
                let selectList = this.cikisInfos[i].stockCikisDetayList;
                this.cikisInfosDetail = selectList;
                let html: HTMLElement = document.getElementById('cikisDetayLabel');
                html.textContent = data.target.argument;
            }
        }*/
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
    }
}