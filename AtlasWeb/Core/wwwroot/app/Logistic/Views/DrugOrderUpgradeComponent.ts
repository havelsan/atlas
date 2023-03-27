import { Component, ViewChild } from '@angular/core';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DrugOrderDetail, HospitalTimeSchedule, DrugOrderStatusEnum, RefactoredFrequencyEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent } from 'devextreme-angular';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { NeSerializer } from 'NebulaClient/ClassTransformer/NeSerializer';
import { UpgradeDrugOrderDVO, DrugOrderIntroductionGridViewModel, DrugOrderTimceSchedule } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { DrugOrderIntroductionService } from 'app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';


@Component({
    selector: 'drugorderupgrade-component',
    template: `
    <div class="row" style="text-align:center">
    <p style="color:red">{{drugName}}</p>
</div>
<div class="row">
    <div class="col-sm-2" style="padding:1">
        <label>Doz Aralığı</label>
        <dx-select-box [dataSource]="timeScheduleDataSource" displayExpr="Name" valueExpr="ObjectID" [disabled]="true"
                       [value]="oldDrugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID"></dx-select-box>
    </div>
    <div class="col-sm-2" style="padding:1">
        <label>Doz Miktarı</label>
        <dx-number-box [value]="oldDrugOrderIntroductionGridViewModel.DoseAmount"
                       [disabled]="true"></dx-number-box>
    </div>
    <div class="col-sm-2" style="padding:1">
        <br />
        <dx-check-box [value]="oldDrugOrderIntroductionGridViewModel.IsCV"
                      [width]="80" [disabled]="true"
                      text="CV"></dx-check-box>
    </div>
    <div class="col-sm-6" style="padding:1">
        <label>Açıklama</label>
        <dx-text-box [value]="oldDrugOrderIntroductionGridViewModel.UsageNote" [disabled]="true">
        </dx-text-box>
    </div>
</div>
<br />
<div class="row">
    <div class="col-sm-2" style="padding:1">
        <label>Doz Aralığı</label>
        <dx-select-box [dataSource]="timeScheduleDataSource" displayExpr="Name" valueExpr="ObjectID"
                       [(value)]="upgradeDrugOrderDVO.newHospitalTimeSchedule" (onValueChanged)="onTimeScheduleChanged($event)"></dx-select-box>
    </div>
    <div class="col-sm-2" style="padding:1">
        <label>Doz Miktarı</label>
        <dx-number-box [(value)]="upgradeDrugOrderDVO.newDoseAmount" (onValueChanged)="onDoseAmountChanged($event)"></dx-number-box>
    </div>
    <div class="col-sm-2" style="padding:1">
        <br />
        <dx-check-box [value]="upgradeDrugOrderDVO.newIsCV"
                      [width]="80" (onValueChanged)="isCVChecked($event)"
                      text="CV"></dx-check-box>
    </div>
    <div class="col-sm-6" style="padding:1">
        <label>Açıklama</label>
        <dx-text-box [(value)]="upgradeDrugOrderDVO.newUsageNote" (onValueChanged)="onUsageNoteChanged($event)">
        </dx-text-box>
    </div>
</div>
<br />
<div class="row">
    <div class="col-xs-12">
        <dx-data-grid #drugOrderDetailGrid [height]="250" [dataSource]="oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule" [columns]="DrugOrderDetailGridColumns"
                      (onRowUpdating)="onRowUpdating($event)">
            <dxo-paging [pageSize]="100" id="A31078"></dxo-paging>
            <dxo-editing mode="cell" [allowUpdating]="true" [allowAdding]="false">
            </dxo-editing>
        </dx-data-grid>
        <br />
        <div style="float: left">
            <dx-button type="default" text="Güncelle" style="width:80px" (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button type="danger" text="Vazgeç" style="width:80px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
 `
})
export class DrugOrderUpgradeComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    public drugName: string;
    public upgradeDrugOrderDVO: UpgradeDrugOrderDVO;
    public oldDrugOrderIntroductionGridViewModel: DrugOrderIntroductionGridViewModel;
    public timeScheduleDataSource: Array<HospitalTimeSchedule>;
    public drugOrderDetails: Array<DrugOrderDetail>;
    public originalDrugOrderTimceSchedule: Array<DrugOrderTimceSchedule> = new Array<DrugOrderTimceSchedule>();
    public originalHospitalTimceScheduleID: Guid;
    public originalDoseAmount: number;
    public orginalUsageNote: string;
    @ViewChild('drugOrderDetailGrid') drugOrderDetailGrid: DxDataGridComponent;
    public moveSchedule = false;
    public DrugOrderDetailGridColumns = [
        {
            caption: 'T',
            dataField: 'DetailNo',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Tarih',
            dataField: 'Time',
            dataType: "date",
            format: "shortDateShortTime"
        },
        {
            caption: 'Saat',
            dataField: 'Time',
            dataType: "date",
            format: "shortTime",
            editorOptions: { type: "time" }
        },
        {
            caption: 'Doz Miktarı',
            dataField: 'DoseAmount',
            dataType: "number",
            allowEditing: false,
            width: 'auto'
        }
    ];

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    public onRowUpdating(event: any) {
        if (event.oldData.Time != null && this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.filter(x => x.DetailNo > event.oldData.DetailNo).length > 0) {
            if (event.newData.Time < new Date(Date.now())) {
                //TODO error
                event.newData.Time = event.key.Time;
                ServiceLocator.MessageService.showError("Eski tarihli order veremezsiniz!");
            } else if (this.drugOrderDetails.find(x => x.DetailNo === event.oldData.DetailNo) == null) {
                event.newData.Time = event.key.Time;
                ServiceLocator.MessageService.showError("Bu planlamanın tarihini değiştiremezsiniz!");
            }
            else {
                this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.find(x => x.DetailNo === event.oldData.DetailNo).UpgradeDetail = true;
                if (this.moveSchedule) {
                    let diff = +(new Date(event.newData.OrderPlannedDate)) - +(new Date(event.key.OrderPlannedDate));
                    this.drugOrderDetails.filter(x => x.DetailNo > event.oldData.DetailNo).forEach(element => {
                        element.OrderPlannedDate = new Date(element.OrderPlannedDate.toString()).AddMinutes(diff / 1000 / 60);
                    });
                }
            }
        }
    }
    public onDoseAmountChanged(event: any) {
        if (event.value != null) {
            if (event.value > this.oldDrugOrderIntroductionGridViewModel.DoseAmount) {
                for (let detail of this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule) {
                    if (this.drugOrderDetails.find(x => x.DetailNo === detail.DetailNo) != null) {
                        detail.UpgradeDetail = true;
                    }
                }
                for (let updateDetail of this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule) {
                    if (updateDetail.UpgradeDetail === true) {
                        updateDetail.DoseAmount = event.value;
                    }
                }
                this.oldDrugOrderIntroductionGridViewModel.DoseAmount = event.value;
            } else {
                if (event.value !== this.oldDrugOrderIntroductionGridViewModel.DoseAmount) {
                    this.upgradeDrugOrderDVO.newDoseAmount = null;
                    TTVisual.InfoBox.Alert('Daha düşük bir doz miktarı seçemezsiniz!.');
                }
            }
        }
    }
    public onUsageNoteChanged(event: any) {
        if (event.value != null) {
            if (event.value != this.oldDrugOrderIntroductionGridViewModel.UsageNote) {
                this.oldDrugOrderIntroductionGridViewModel.UsageNote= event.value;
            }
        }

    }


    public isCVChecked(value) {
        if (value.value != null) {
            if (value.value != this.oldDrugOrderIntroductionGridViewModel.IsCV) {
                this.oldDrugOrderIntroductionGridViewModel.IsCV = value.value;
            }
        }
    }

    public onTimeScheduleChanged(event: any) {
        if (event.value != null) {
            if (event.previousValue != null) {
                this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule = new Array<DrugOrderTimceSchedule>();
                for (let orginal of this.originalDrugOrderTimceSchedule) {
                    this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.push(orginal);
                }
            }
            //this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule = this.originalDrugOrderTimceSchedule;
            let selectedHTS: HospitalTimeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID.toString() === event.value.toString());
            let oldHTS: HospitalTimeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID.toString() === this.oldDrugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID.toString());
            if (<number>oldHTS.Frequency < <number>selectedHTS.Frequency) {
                let newDrugOrderIntroduction: DrugOrderIntroductionGridViewModel = new DrugOrderIntroductionGridViewModel();
                newDrugOrderIntroduction.Material = this.oldDrugOrderIntroductionGridViewModel.Material;
                newDrugOrderIntroduction.PlannedStartTime = this.oldDrugOrderIntroductionGridViewModel.PlannedStartTime;
                newDrugOrderIntroduction.HospitalTimeSchedule = selectedHTS;
                newDrugOrderIntroduction.HospitalTimeScheduleObjectID = selectedHTS.ObjectID;
                newDrugOrderIntroduction.Day = this.oldDrugOrderIntroductionGridViewModel.Day;
                newDrugOrderIntroduction.ID = this.oldDrugOrderIntroductionGridViewModel.ID;
                if (this.upgradeDrugOrderDVO.newDoseAmount != null) {
                    newDrugOrderIntroduction.DoseAmount = this.upgradeDrugOrderDVO.newDoseAmount;
                } else {
                    newDrugOrderIntroduction.DoseAmount = this.oldDrugOrderIntroductionGridViewModel.DoseAmount;
                }
                this.CreateDrugOrderIntroductionTimeModel(newDrugOrderIntroduction);
                console.log(newDrugOrderIntroduction);
                for (let det of newDrugOrderIntroduction.DrugOrderIntroDuctionTimeSchedule) {
                    if (this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.find(x => x.DetailNo === det.DetailNo) == null) {
                        det.UpgradeDetail = true;
                        this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.push(det);
                    }
                }
                this.oldDrugOrderIntroductionGridViewModel.HospitalTimeSchedule = selectedHTS;
                this.oldDrugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID = selectedHTS.ObjectID;
            } else {
                if (<number>oldHTS.Frequency !== <number>selectedHTS.Frequency) {
                    event.cancel = true;
                    this.upgradeDrugOrderDVO.newHospitalTimeSchedule = null;
                    TTVisual.InfoBox.Alert('Daha düşük bir doz aralığı seçemezsiniz!.');
                }
            }
        }
    }
    public async CreateDrugOrderIntroductionTimeModel(drugOrderIntroductionGridViewModel: DrugOrderIntroductionGridViewModel) {
        let detailTime: Date = null;
        let detailTTimeSchedule: Array<DrugOrderTimceSchedule> = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule;
        drugOrderIntroductionGridViewModel.HospitalTimeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID === drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID);

        if (drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.length > 0) {
            drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule = new Array<DrugOrderTimceSchedule>();
        }

        if (drugOrderIntroductionGridViewModel.HospitalTimeSchedule != null && detailTime == null)
            detailTime = this.FindFirstDetailTime(drugOrderIntroductionGridViewModel.HospitalTimeSchedule, drugOrderIntroductionGridViewModel.PlannedStartTime);

        let hospitalTimeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID === drugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID);

        if (detailTime != null) {
            if (drugOrderIntroductionGridViewModel.Status === DrugOrderStatusEnum.New)
                drugOrderIntroductionGridViewModel.PlannedStartTime = new Date(detailTime.toString());
            let detailTimePeriod = this.GetDetailTimePeriod(hospitalTimeSchedule.Frequency);
            let detailCount = this.GetDetailCount(drugOrderIntroductionGridViewModel);
            for (let index = 0; index < detailCount; index++) {
                //TODO: Sunucuda yapılacak ya da component'e Input olarak verilecek.
                let drugOrderTimceSchedule: DrugOrderTimceSchedule = new DrugOrderTimceSchedule();
                drugOrderTimceSchedule.DetailNo = index + 1;
                //detailTime Direkt olarak set edildiği zaman
                drugOrderTimceSchedule.Time = new Date(detailTime.toString());
                drugOrderTimceSchedule.UsageNote = drugOrderIntroductionGridViewModel.UsageNote;
                drugOrderTimceSchedule.DoseAmount = drugOrderIntroductionGridViewModel.DoseAmount;
                drugOrderTimceSchedule.MasterID = drugOrderIntroductionGridViewModel.ID;
                drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.push(drugOrderTimceSchedule);
                detailTime = detailTime.AddHours(detailTimePeriod);
            }
            if (detailCount === detailTTimeSchedule.length) {
                for (let index = 0; index < detailCount; index++) {
                    if (detailTTimeSchedule[index].UsageNote != null)
                        drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule[index].UsageNote = detailTTimeSchedule[index].UsageNote;
                }
            }
            if (drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule.length > 0)
                drugOrderIntroductionGridViewModel.PlannedEndTime = drugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule[detailCount - 1].Time;
        }
    }

    public FindFirstDetailTime(timeSchedule: HospitalTimeSchedule, plannedStartTime: Date): Date {

        let detailTime: Date = null;
        //drugOrderIntroductionGridViewModel.DrugOrderIntroductionDetail.HospitalTimeSchedule = this.timeScheduleDataSource.find(x => x.ObjectID == drugOrderIntroductionGridViewModel.DrugOrderIntroductionDetail.HospitalTimeScheduleObjectID);
        let hospitalTimeSchedule = timeSchedule;

        if (hospitalTimeSchedule.HospitalTimeScheduleDetails.length === 0) {
            let today = new Date(Date.now());
            detailTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(), today.AddHours(1).getHours(), 0, 0);
        }

        for (let index = 0; index < hospitalTimeSchedule.HospitalTimeScheduleDetails.length; index++) {
            let element = hospitalTimeSchedule.HospitalTimeScheduleDetails[index];

            let today = new Date(Date.now());

            //Order'ın verilmek istendiği tarih.
            let plannedStartDate;
            plannedStartDate = plannedStartTime;

            let tempPlannedStartDate = new Date(plannedStartDate.getFullYear(), plannedStartDate.getMonth(), plannedStartDate.getDate(), 0, 0, 0);

            //Tanımlı order saatlerinden oluşturulan geçici tarih.(Verilen order ile karşılaştırma yapabilmek için)
            let tempX1 = new Date(today.getFullYear(), today.getMonth(), today.getDate(), element.Time.getHours(), element.Time.getMinutes());
            //Order'ın verildiği şimdiki saat. (Tanımlı order saatleri ile karşılaştırmak için)
            let tempX2 = new Date(today.getFullYear(), today.getMonth(), today.getDate(), new Date(Date.now()).getHours(), new Date(Date.now()).getMinutes());

            if (tempPlannedStartDate > tempX1) {
                today = new Date(Date.now());
                detailTime = new Date(plannedStartDate.getFullYear(), plannedStartDate.getMonth(), plannedStartDate.getDate(), element.Time.getHours(), element.Time.getMinutes());
                break;
            }
            else if (tempX1 > tempX2) {
                //Order saati geçmemiş ise tanımlı saat ile aynı güne atanır.
                today = new Date(Date.now());
                detailTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(), element.Time.getHours(), element.Time.getMinutes());
                break;
            }

            //Son zaman dilimi detayına kadar uygun saat bulunamadı koşulu. (Tanımlı zaman dilimleri order saatini geçmiş.)
            if (index === hospitalTimeSchedule.HospitalTimeScheduleDetails.length - 1 && (detailTime == null)) {
                //Order saati geçmişse ertesi günün ilk tanımlanan saatine atanır.
                today = new Date(Date.now());
                let hospitalTimeScheduleDetail = hospitalTimeSchedule.HospitalTimeScheduleDetails.find(x => x.TimeNumber === 1).Time;
                detailTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(), hospitalTimeScheduleDetail.getHours(), hospitalTimeScheduleDetail.getMinutes()).AddDays(1);

            }
        }
        return detailTime;
    }

    public GetDetailCount(drugOrderIntroductionDetail: DrugOrderIntroductionGridViewModel): number {
        return drugOrderIntroductionDetail.Day * <number>drugOrderIntroductionDetail.HospitalTimeSchedule.Frequency;
    }

    public GetDetailTimePeriod(refactoredFrequency: RefactoredFrequencyEnum): number {
        return 24 / <number>refactoredFrequency;
    }

    public async setInputParam(value: UpgradeDrugOrderDVO) {
        let cloneArray = JSON.parse(NeSerializer.stringify(value.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule));
        let typedCloneArray = plainToClass(DrugOrderTimceSchedule, cloneArray) as Array<DrugOrderTimceSchedule>;

        this.timeScheduleDataSource = value.timeScheduleDataSource;
        this.originalDrugOrderTimceSchedule = typedCloneArray;
        this.originalHospitalTimceScheduleID = value.oldDrugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID;
        this.originalDoseAmount = value.oldDrugOrderIntroductionGridViewModel.DoseAmount;
        this.orginalUsageNote = value.oldDrugOrderIntroductionGridViewModel.UsageNote;
        this.drugOrderDetails = value.drugOrderDetails as Array<DrugOrderDetail>;
        this.upgradeDrugOrderDVO = value as UpgradeDrugOrderDVO;
        this.oldDrugOrderIntroductionGridViewModel = value.oldDrugOrderIntroductionGridViewModel;
        this.drugName = value.oldDrugOrderIntroductionGridViewModel.Material.name;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule = this.originalDrugOrderTimceSchedule;
        this.oldDrugOrderIntroductionGridViewModel.HospitalTimeScheduleObjectID = this.originalHospitalTimceScheduleID;
        this.oldDrugOrderIntroductionGridViewModel.DoseAmount = this.originalDoseAmount;
        this.oldDrugOrderIntroductionGridViewModel.UsageNote = this.orginalUsageNote;
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, this.originalDrugOrderTimceSchedule);
    }

    public okClick(): void {
        this.drugOrderDetailGrid.instance.closeEditCell();
        this.drugOrderDetailGrid.instance.saveEditData();
        DrugOrderIntroductionService.UpgradeDrugOrder(this.oldDrugOrderIntroductionGridViewModel).then(result => {
            if (result.result) {
                this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.oldDrugOrderIntroductionGridViewModel);
                ServiceLocator.MessageService.showSuccess('Güncelleme başarılı.');
            } else {
                this.oldDrugOrderIntroductionGridViewModel.DrugOrderIntroDuctionTimeSchedule = this.originalDrugOrderTimceSchedule;
                ServiceLocator.MessageService.showError('Güncelleme yapılırken bir hata oluştu!' + result.errorMessage);
            }
        });
    }
}