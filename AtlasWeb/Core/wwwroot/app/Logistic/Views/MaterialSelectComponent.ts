//$B0F54848
import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialSelectViewModel, MaterialTreeItem, MaterialListInputDVO, MaterialItem, MaterialSelectInputDVO, SumAmountMaterialItem, MaterialMaxValue } from '../Models/MaterialSelectViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DxDataGridComponent } from 'devextreme-angular';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DatePipe } from '@angular/common';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { Convert } from 'app/NebulaClient/Mscorlib/Convert';
import { AtlasObjectCloner } from 'app/NebulaClient/ClassTransformer/AtlasObjectCloner';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
@Component({
    selector: 'material-select-component',
    providers: [DatePipe],
    template: `
 <div class="container-fluid">
    <div class="row">
        <div style="float:left; width:30%; padding-top: 20px;">
            <dx-text-box #textBox
                         placeholder="Malzeme Grubu Ara"
                         [width]="300"
                         mode="search"
                         valueChangeEvent="keyup"
                         value="">
            </dx-text-box>
            <br />
            <dx-tree-view id="simple-treeview"
                          [items]="materialTree"
                          [width]="300"
                          [height]="300"
                          [searchValue]="textBox.value"
                          (onItemClick)="selectItem($event)">
            </dx-tree-view>
        </div>

        <div style="float:right; width:69%; padding-top: 20px;">
            <div class="row">
                <div *ngIf="!DateBetween" class="col-sm-2" >
                    <label class="control-label">Sarf Tarihi :</label>
                    <dx-date-box [max]="SelectedTransactionDateMax" [min]="SelectedTransactionDateMin" [(value)]="TransactionDate" [readOnly]="false">
                    </dx-date-box>
                </div>
                <div *ngIf="UseDateBetween" class="col-sm-2">
                    <dx-check-box [(value)]="DateBetween"
                                  [width]="100"
                                  text="İki tarih arası"></dx-check-box>
                </div>
                <div *ngIf="DateBetween" class="col-sm-2">
                    <label class="control-label">Başlangıç Tarihi :</label>
                    <dx-date-box [max]="SelectedTransactionDateMax" [min]="SelectedTransactionDateMin" [(value)]="SelectedTransactionDateMin" [readOnly]="false">
                    </dx-date-box>
                </div>
                <div *ngIf="DateBetween" class="col-sm-2">
                    <label class="control-label">Bitiş Tarihi :</label>
                    <dx-date-box [max]="SelectedTransactionDateMax" [min]="SelectedTransactionDateMin" [(value)]="SelectedTransactionDateMax" [readOnly]="false">
                    </dx-date-box>
                </div>
            </div>
            <dx-data-grid [columns]="MaterialListColumns"
                          [dataSource]="materialList"
                          [filterRow]="{visible: true}"
                          (onRowClick)="select($event)"
                          [selection]="{mode: 'single',allowSelectAll: false}"
                          style="height: 300px;float:left">
            </dx-data-grid>
        </div>
    </div>
    <div class="row">
        <dx-data-grid #gridSelectedMaterials
                      [columns]="SelectedMaterialListColumns"
                      [dataSource]="selectedMaterialList"
                      [filterRow]="{visible: true}"
                      (onEditorPreparing)="editorPreparing($event)"
                      style="height : 300px">
            <dxo-editing mode="cell"
                         editEnabled="true"
                         [allowUpdating]="true"
                         [allowAdding]="false"
                         [allowDeleting]="true">
            </dxo-editing>
        </dx-data-grid>
    </div>
    <br />
    <div class="row">
        <div style="float: left">
            <dx-button type="btn btn-default" text="Ekle" style="width:80px" (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button type="btn btn-default" text="Vazgec" style="width:80px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
 `
})
export class MaterialSelectComponent implements IModal {
    materialTree: MaterialTreeItem[];
    currentItem: MaterialTreeItem;
    private _modalInfo: ModalInfo;
    private viewModel: MaterialSelectViewModel;
    private store: any;
    private IncludeDrugDefinition: boolean;
    materialList: Array<MaterialItem>;
    public SelectedTransactionDate: Date = new Date();
    public TransactionDate: Date = new Date();
    public SelectedTransactionDateMax: string;
    public SelectedTransactionDateMin: string;
    public selectedMaterialList: Array<MaterialItem> = new Array<MaterialItem>();
    public sumAmountMaterialList: Array<SumAmountMaterialItem> = new Array<SumAmountMaterialItem>();
    public DateBetween: boolean = false;
    public UseDateBetween: boolean = false;
    @ViewChild('gridSelectedMaterials') dataGrid: DxDataGridComponent;
    public maxInhelds: Array<MaterialMaxValue> = new Array<MaterialMaxValue>();
    public MaterialListColumns = [
        {
            'caption': 'Barkod',
            dataField: 'Barcode',
            width: 150,
            allowSorting: true
        },
        {
            'caption': i18n("M18545", "Malzeme"),
            dataField: 'MaterialName',
            width: 350,
            allowSorting: true
        },
        {
            'caption': i18n("M12449", "Dağıtım Şekli"),
            dataField: 'DistributionType',
            width: 100,
            allowSorting: true
        },
        {
            'caption': i18n("M18957", "Mevcut"),
            dataField: 'Inheld',
            width: 70,
            allowSorting: true
        }
    ];

    public SelectedMaterialListColumns = [
        {
            'caption': i18n("M21329", "Sarf Tarihi"),
            dataField: 'TransactionDate',
            width: 150,
            readonly: this.DateBetween
        },
        {
            'caption': 'Barkod',
            dataField: 'Barcode',
            width: 150,
            allowSorting: true,
            readonly: true
        },
        {
            'caption': i18n("M18545", "Malzeme"),
            dataField: 'MaterialName',
            width: 350,
            allowSorting: true,
            readonly: true
        },
        {
            'caption': i18n("M19030", "Miktar"),
            dataField: "CalculatedAmount",
            width: 50,
            allowSorting: true

        },
        {
            'caption': i18n("M12449", "Dağıtım Şekli"),
            dataField: 'DistributionType',
            width: 100,
            allowSorting: true,
            readonly: true
        },
        {
            'caption': i18n("M18577", "Malzeme Grubu"),
            dataField: 'MaterialTreeName',
            width: 300,
            allowSorting: true,
            readonly: true
        }
    ];

    constructor(private modalStateService: ModalStateService, private http: NeHttpService, private datePipe: DatePipe) {
    }

    ngOnInit() {
        SystemParameterService.GetParameterValue('USEDATEBETWEEN', 'FALSE').then(x => {
            if (x === "TRUE") {
                this.UseDateBetween = true;
            } else {
                this.UseDateBetween = false;
            }
        }
        );
        this.getTreeList();
    }
    public setInputParam(value: MaterialSelectInputDVO) {
        this.store = value.store;
        this.IncludeDrugDefinition = value.includeDrugDefinition;
        this.SelectedTransactionDateMax = this.datePipe.transform(value.TransactionDateMax, 'yyyy/MM/dd');
        this.SelectedTransactionDateMin = this.datePipe.transform(value.TransactionDateMin, 'yyyy/MM/dd');
        let today = new Date(Date.now());
        if (value.TransactionDateMax < today) {
            this.TransactionDate = value.TransactionDateMax;
        } else {
            this.TransactionDate = today;
        }

    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    onAmountChanged(data, row) {
        row.data.Amount = data.value;
    }

    public okClick(): void {

        this.sumAmountMaterialList = new Array<SumAmountMaterialItem>();
        for (let selectedItem of this.selectedMaterialList) {
            let sumItem: SumAmountMaterialItem = this.sumAmountMaterialList.find(x => x.ObjectID === selectedItem.ObjectID);
            if (sumItem != null) {
                sumItem.TotalAmount = sumItem.TotalAmount + selectedItem.CalculatedAmount;
            } else {
                let newsumItem: SumAmountMaterialItem = new SumAmountMaterialItem();
                newsumItem.ObjectID = selectedItem.ObjectID;
                newsumItem.Inheld = selectedItem.Inheld;
                newsumItem.TotalAmount = selectedItem.CalculatedAmount;
                newsumItem.MaterialName = selectedItem.MaterialName;
                this.sumAmountMaterialList.push(newsumItem);
            }
        }

        let errorMaterial: string = "";
        for (let item of this.sumAmountMaterialList) {
            if (item.TotalAmount > item.Inheld) {
                errorMaterial = errorMaterial + " " + item.MaterialName + " malzemenin mevcudu yeterli değil. Mevcut :" + item.Inheld;
            }
        }

        if (errorMaterial === "") {
            for (let item of this.selectedMaterialList) {
                item.Amount = item.CalculatedAmount;
            }
            this.dataGrid.instance.closeEditCell();
            this.dataGrid.instance.saveEditData();
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedMaterialList);
        } else {
            TTVisual.InfoBox.Alert(errorMaterial);
        }
    }

    editorPreparing(e: any) {
        if (e.parentType === 'dataRow' && e.dataField !== undefined) {
            if (e.dataField === 'Amount' || e.dataField === 'TransactionDate') {
                e.editorOptions.readOnly = false;
            }
            else {
                e.editorOptions.readOnly = true;
            }
        }

        if (e.dataField === "TransactionDate") {
            e.editorOptions.max = this.SelectedTransactionDateMax;
            e.editorOptions.min = this.SelectedTransactionDateMin;
        }

        if (e.dataField === "CalculatedAmount") {
            if (e.row != null) {
                e.editorOptions.readOnly = false;
                if (this.maxInhelds.length > 0) {
                    e.editorOptions.max = this.maxInhelds.find(x => x.ObjectID == e.row.data.ObjectID).maxInheldValue;
                    e.editorOptions.min = "1";
                }
            }
        }

    }

    getTreeList() {
        if (this.store !== null) {
            let filter: string;
            if (this.IncludeDrugDefinition === true) {
                filter = 'true';
            } else {
                filter = 'false';
            }
            let that = this;
            let param: string;
            if (this.store.ObjectID == undefined)
                param = this.store.toString();
            else
                param = this.store.ObjectID.toString();
            this.http.get<MaterialSelectViewModel>('api/MaterialSelect/GetTreeList?StoreObjectId=' + param +
                '&IncludeDrugDefinition=' + filter).then((res: MaterialSelectViewModel) => {
                    let output = res;
                    that.materialTree = output.Materials;
                });
        }
    }

    selectItem(e) {
        this.currentItem = e.itemData;

        let inputDvo = new MaterialListInputDVO();
        if (typeof this.store == 'string') {
            inputDvo.StoreObjectId = this.store;
        }
        else {
            inputDvo.StoreObjectId = this.store.ObjectID.toString();
        }

        inputDvo.MaterialTreeItem = this.currentItem;
        let fullApiUrl = 'api/MaterialSelect/GetMaterials';
        this.http.post(fullApiUrl, inputDvo)
            .then((res: Array<MaterialItem>) => {
                this.materialList = res;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    select(value: any) {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            let that = this;

            if (this.DateBetween === false) {
                try {
                    if (this.selectedMaterialList.find(x => x.MaterialName == value.data.MaterialName) == null) {
                        let addingMaterialItem: MaterialItem = value.data;
                        let maxInheld = new MaterialMaxValue();
                        maxInheld.ObjectID = addingMaterialItem.ObjectID;
                        maxInheld.maxInheldValue = addingMaterialItem.Inheld;
                        that.maxInhelds.push(maxInheld);
                        if (value.data.IsDivide == true) {
                            let divideCount: number = value.data.DivideUnitAmount / value.data.DivideTotalAmount;
                            addingMaterialItem.Amount = divideCount;
                            addingMaterialItem.CalculatedAmount = value.data.DivideUnitAmount;
                        } else {
                            addingMaterialItem.Amount = 1;
                            addingMaterialItem.CalculatedAmount = 1;
                        }
                        addingMaterialItem.TransactionDate = Convert.ToDateTime(this.TransactionDate);
                        this.selectedMaterialList.push(addingMaterialItem);
                    } else {
                        ServiceLocator.MessageService.showError("Bu malzeme zaten seçilmiş adet bilgisini güncelleyebilirsiniz.");
                    }

                }
                catch (error) {
                }
            } else {
                const oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
                const firstDate = new Date(this.SelectedTransactionDateMax);
                const secondDate = new Date(this.SelectedTransactionDateMin);
                const diffDays = Math.round(Math.abs((firstDate.getTime() - secondDate.getTime()) / oneDay));
                let startDate: Date = Convert.ToDateTime(this.SelectedTransactionDateMin);

                for (let index = 0; index <= diffDays; index++) {
                    let addingMaterialItem: MaterialItem = new MaterialItem();
                    addingMaterialItem = AtlasObjectCloner.clone(value.data);
                    addingMaterialItem.Amount = 1;
                    addingMaterialItem.TransactionDate = startDate;
                    if (this.selectedMaterialList.find(x => x.MaterialName == addingMaterialItem.MaterialName) == null) {
                        this.selectedMaterialList.push(addingMaterialItem);
                    }
                    startDate = startDate.AddDays(1);
                }
            }
        }
    }

    selectMaterial(value: any) {
        let that = this;
        let addingMaterialItem: MaterialItem = value.data;
        let maxInheld = new MaterialMaxValue();
        maxInheld.ObjectID = addingMaterialItem.ObjectID;
        maxInheld.maxInheldValue = addingMaterialItem.Inheld;
        that.maxInhelds.push(maxInheld);
        addingMaterialItem.Amount = 1;
        addingMaterialItem.TransactionDate = this.SelectedTransactionDate;
        if (this.selectedMaterialList.find(x => x.MaterialName == addingMaterialItem.MaterialName) == null) {
            this.selectedMaterialList.push(addingMaterialItem);
        }
        else {
            ServiceLocator.MessageService.showError("Aynı Malzemeyi Seçitiniz..");
        }
    }
}