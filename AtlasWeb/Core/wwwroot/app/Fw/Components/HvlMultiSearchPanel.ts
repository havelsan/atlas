import {
    ChangeDetectorRef,
    Component, OnChanges, EventEmitter, KeyValueDiffers, ElementRef, ViewChildren, SimpleChanges, QueryList, AfterViewInit, DoCheck,
} from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { BaseControl } from './BaseControls/BaseControl';
import { DxListComponent, DxTextBoxComponent } from 'devextreme-angular';
import { TTMultiSearchPanelDataLoadOptions, TTMultiSearchPanelConfig } from 'NebulaClient/Visual/Controls/TTMultiSearchPanel';
import { Util } from './Util';
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';

declare var jQuery: any;
// (@state.start)="completed(cfg)"
@Component({
    selector: "hvl-multisearch-panel",
    inputs: ['ReadOnly', 'Disabled', 'Visible', 'TabIndex', 'BackColor', 'ForeColor', 'Font', 'Enabled', 'width', 'Tag', 'height', 'EnableAnimation', 'Config', 'ProgressiveSearch', 'DataSources'],
    outputs: ['SelectionChanged'],
    template: '<div class="container-fluid" style="margin:5px">\
                    <div class="row" >\
                        <div *ngFor="let cfg of Config; let i = index" [ngClass]="cfg.ColumnSize" style="height:100% !important" [@state]="i!=0?AnimationData[cfg.PanelName].State:\'Expanded\'" (@state.done)="done(i)">\
                            <div style="width:100%; height:100%">\
                                <div class="container-fluid" [style.display]="getDisplay(cfg)" style="border:solid 1px lightgray;padding:10px" >\
                                    <div class="row">\
                                        <div class="col-xs-4">\
                                            <label>{{cfg.FilterLabel}}</label>\
                                        </div>\
                                        <div class="col-xs-8" >\
                                            <dx-text-box [disabled]="Disabled" [ngClass]="[\'form-control\']" [(value)]="cfg.Filter" showClearButton="true" (onValueChanged)="filterChanged(i)" (onKeyUp)="keyUp(i,$event)" valueChangeEvent="keyup"></dx-text-box>\
                                        </div>\
                                    </div>\
                                    <div class="row" style="margin-top:5px">\
                                        <div class="col-xs-12">\
                                            <dx-list width= "100%" (onItemClick)="changed(i,$event)" (onContentReady)="contentReady(i)" [height]="height" [disabled]="Disabled" noDataText="Kriterlerinize Göre Veri Bulunamadı" pageLoadMode="scrollBottom" [selectionMode]="cfg.selectionMode" [(selectedItems)]="cfg.SelectedObjects" indicateLoading="false"  [dataSource]="DataSources[i] | ArrayFilterPipe:cfg.DisplayMemberPath:cfg.Filter">\
                                                <div *dxTemplate=\'let cellData of "item"\' style="text-align:left">\
                                                    <div [innerHtml]="GetTemplateData(cfg,cellData)" [title]="GetTemplateData(cfg,cellData)"></div>\
                                                </div>\
                                            </dx-list>\
                                        </div>\
                                    </div>\
                                </div>\
                            </div>\
                        </div>\
                    </div>\
            </div>',
    animations: [
        trigger('state', [
            state("Collapsed", style({ width: "0%" })),
            state("Expanded", style({})),
            transition('Collapsed=>Expanded', animate('500ms ease-in')),
            transition('Expanded=>Collapsed', animate('500ms ease-in'))
        ])
    ]
})//(onItemClick)="changed(i)"
export class HvlMultiSearchPanel extends BaseControl implements OnChanges, AfterViewInit, DoCheck {
    @ViewChildren(DxListComponent) Lists: QueryList<DxListComponent>;
    @ViewChildren(DxTextBoxComponent) TextBoxes: QueryList<DxTextBoxComponent>;

    EnableAnimation: Boolean;
    ProgressiveSearch: Boolean;
    Config: Array<TTMultiSearchPanelConfig>;
    DataSources: Array<any> = [];
    OpenedPanelList: Array<Boolean>;
    PanelData: any = {};
    AnimationData: any = {};
    SelectionChanged: EventEmitter<TTMultiSearchPanelDataLoadOptions> = new EventEmitter<TTMultiSearchPanelDataLoadOptions>();


    constructor(differs: KeyValueDiffers,
        element: ElementRef, private detector: ChangeDetectorRef) {
        super(differs, element);
    }

    completed(cfg: TTMultiSearchPanelConfig) {
        this.AnimationData[cfg.PanelName].Visible = this.AnimationData[cfg.PanelName].State == "Expanded" ? true : false;
    }

    done(index: number) {
        let that = this;
        window.setTimeout(() => {
            let textBox: DxTextBoxComponent = that.TextBoxes.toArray()[index];
            textBox.instance.focus();
        }, 0);
    }

    getDisplay(cfg: any) {
        if (this.AnimationData[cfg.PanelName].Visible) {
            return 'block';
        }
        else {
            return 'none';
        }
    }

    contentReady(i) {
        let that = this;
        if (this.Config[i].SelectedObjects &&
            this.Config[i].SelectedObjects.length > 0 && this.DataSources && this.DataSources[i]) {
            let dataSource: Array<any> = this.DataSources[i];
            let selected: Array<any> = this.Config[i].SelectedObjects;
            let elementIndex = dataSource.indexOf(selected[0]);
            window.setTimeout(() => {
                that.Lists.toArray()[i].instance.scrollToItem(elementIndex);
            }, 0);
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        let that = this;
        if (changes['DataSources'] && !this.DataSources) {
            this.DataSources = [];
        }
        if (changes['Config'] && this.Config && this.Config.length > 0) {
            let cfg: TTMultiSearchPanelConfig;
            for (let i = 0; i < this.Config.length; i++) {
                cfg = this.Config[i];
                this.AnimationData[cfg.PanelName] = { State: 'Collapsed', Visible: false };

                //let closure = (config: TTMultiSearchPanelConfig) => {
                //let dataSource: any = {};
                //config.SelectedObjects = [];
                //config['ColumnSize'] = 'col-xs-' + config.Size.toString();
                //dataSource.load = (loadOptions) => {
                //    let data: Array<any> = that.PanelData[config.PanelName];
                //    data = !data ? [] : data;
                //    that.ToggleLists(false);
                //    that.AnimationData[config.PanelName].State = data.length == 0 ? 'Collapsed' : 'Expanded';
                //    if (data && config.Filter && config.Filter != '') {
                //        let filtered: Array<any> = [];
                //        for (let i = 0; i < data.length; i++) {
                //            let val = data[i];
                //            let propertyValue: string = Util.ResolveProperty(config.DisplayMemberPath, val);
                //            propertyValue = Util.turkishToLower(propertyValue);
                //            if (propertyValue.startsWith(Util.turkishToLower(config.Filter))) {
                //                filtered.push(val);
                //            }
                //        }
                //        return Promise.resolve(filtered);
                //    }
                //    return Promise.resolve(data);
                //};
                //this.DataSources.push(dataSource);
                //};
                //closure(cfg);
                cfg['ColumnSize'] = 'col-xs-' + cfg.Size.toString();
            }
        }
        super.ngOnChanges(changes);
    }

    ngDoCheck() {
        if (this.DataSources && this.AnimationData && this.Config) {
            for (let i: number = 0; i < this.Config.length; i++) {
                let cfg = this.Config[i];
                if (!this.DataSources[i] || this.DataSources[i].length == 0) {
                    if (this.AnimationData && this.AnimationData[cfg.PanelName] && this.AnimationData[cfg.PanelName].State == 'Expanded')
                        this.AnimationData[cfg.PanelName] = { State: 'Collapsed', Visible: false };
                }
                else {
                    if (this.AnimationData && this.AnimationData[cfg.PanelName] && this.AnimationData[cfg.PanelName].State == 'Collapsed')
                        this.AnimationData[cfg.PanelName] = { State: 'Expanded', Visible: true };
                }
            }
        }
    }

    filterData(data: Array<any>, cfg: TTMultiSearchPanelConfig) {
        if (data && cfg) {
            if (!cfg.Filter) {
                return data;
            }
            else {
                return data.filter((value) => {
                    let propertyValue: string = Util.ResolveProperty(cfg.DisplayMemberPath, value);
                    if (propertyValue) {
                        propertyValue = Util.turkishToLower(propertyValue);
                        return propertyValue.startsWith(Util.turkishToLower(cfg.Filter));
                    }
                });
            }
        }
    }

    filterChanged(index: number) {
        let that = this;
        window.setTimeout(t => {
            let list: DxListComponent = that.Lists.toArray()[index];
            if (list) {
                list.instance.reload();
            }
        }, 0);
    }

    GetTemplateData(config: TTMultiSearchPanelConfig, data: any) {
        let path: String = config.DisplayMemberPath;
        if (path) {
            let result: String = Util.ResolveProperty(path, data);
            if (!config.Filter || config.Filter == '') {
                return result;
            }
            if (result) {
                let lowerResult: String = Util.turkishToLower(result);
                let lowerText: string = Util.turkishToLower(config.Filter);
                if (lowerResult.startsWith(lowerText)) {
                    let index: number = config.Filter.length;
                    return result.substr(0, index) + '<strong>' + result.substr(index) + '</strong>';
                }
                return result;
            }
            return result;
        }
    }

    //ToggleLists(disabled: Boolean) {
    //    if (this.Lists) {
    //        let lists: Array<DxListComponent> = this.Lists.toArray();
    //        this.Lists.forEach((item) => {
    //            item.disabled = disabled
    //        });
    //    }
    //}

    ngAfterViewInit() {
        this.preventArrowKeysBehaviour();
    }

    Refresh() {
        this.Clear();
    }

    Clear() {
        for (let i = 0; i < this.Config.length; i++) {
            this.ClearByIndex(i);
        }
    }

    ClearByIndex(index: number) {
        let listArray: Array<DxListComponent> = this.Lists.toArray();
        this.PanelData[this.Config[index].PanelName] = [];
        listArray[index].instance.reload();
    }

    changed(i: number, data: any) {
        let that = this;
        let previousSelections: any = {};
        let selected_cfg: TTMultiSearchPanelConfig;
        let listArray: Array<DxListComponent> = that.Lists.toArray();
        let loaderOptions: TTMultiSearchPanelDataLoadOptions = new TTMultiSearchPanelDataLoadOptions();

        //Seçilen Data'yı Config'lerin LinkedObject özelliği ile gelen nesnenin LinkedPropertysine set etmece
        selected_cfg = i != undefined ? this.Config[i] : this.Config[0];
        this.setLinkedObjectsProperties(selected_cfg);

        for (let j = 0; j < this.Config.length; j++) {
            let cfg: TTMultiSearchPanelConfig = this.Config[j];

            // RelatedPanel seçimi değiştikçe bağlı panellerin SelectedObjectslerinin  boşaltılması için
            if (cfg.RelatedPanelNameToLoad == selected_cfg.PanelName) {
                cfg.SelectedObjects = new Array<any>();
                this.setLinkedObjectsProperties(cfg);
            }
             previousSelections[cfg.PanelName] = cfg.SelectedObjects && cfg.SelectedObjects.length > 0 ? cfg.SelectedObjects[0] : null;
        }

        //cfg.SelectedObjects.Clear();
        //cfg.SelectedObjects.push(data);
        loaderOptions.PanelName = i != undefined ? selected_cfg.PanelName : undefined;
        loaderOptions.AllSelectedPanelObjects = previousSelections;
        loaderOptions.SelectedObject = selected_cfg.SelectedObjects && selected_cfg.SelectedObjects.length > 0 ? selected_cfg.SelectedObjects : null;





        //if (cfg.selectionMode == "single") {
        //    if (loaderOptions.SelectedObject != null)
        //        cfg.LinkedObject[cfg.LinkedPropertyName.toString()] = loaderOptions.SelectedObject[0];
        //}
        //else if (cfg.selectionMode == "multiple") {

        //    if (loaderOptions.SelectedObject != null) {
        //        let selectedObjectList = loaderOptions.SelectedObject as Array<any>;
        //        if (selectedObjectList.length > cfg.LinkedObject.length)// Seçilen obje daha fazla ise yeni satır eklemek
        //        {
        //            for (let i = cfg.LinkedObject.length; i < selectedObjectList.length; i++) {

        //                let newlinkedObject = new Object();
        //                newlinkedObject['IsNew'] = true;
        //                newlinkedObject[cfg.LinkedPropertyName.toString()] = selectedObjectList[i];
        //                cfg.LinkedObject.push(newlinkedObject);

        //            }

        //        } else if (selectedObjectList.length < cfg.LinkedObject.length) // Seçilen obje daha az  ise  fazla olanların StatusEnum değerleri Deleteda çekilmeli
        //        {
        //            for (let i = selectedObjectList.length; i < cfg.LinkedObject.length; i++) {

        //                cfg.LinkedObject[i]['EntityState'] = EntityStateEnum.Deleted;
        //            }
        //        }

        //        for (let i = 0; i < selectedObjectList.length; i++) { // Seçilen Object değerleri cfg.LinkedObject e eklenir  StatusEnum değerleri düzenlenir çekilmeli
        //            let linkedObject = cfg.LinkedObject[i];
        //            let selectedObject = selectedObjectList[i];
        //            linkedObject[cfg.LinkedPropertyName.toString()] = selectedObject;
        //            if (linkedObject['EntityState'] == EntityStateEnum.Deleted) {
        //                if (linkedObject['IsNew'] == true)
        //                    linkedObject['EntityState'] = EntityStateEnum.Added;
        //                else
        //                    linkedObject['EntityState'] = EntityStateEnum.Modified;
        //            }

        //        }


        //        // Yeni eklenmiş ve Deleted olanları sil
        //        let IndexOfDeletedRow = cfg.LinkedObject.findIndex(dr => dr['IsNew'] == true && dr['EntityState'] == EntityStateEnum.Deleted);
        //        while (IndexOfDeletedRow != -1) {
        //            cfg.LinkedObject.splice(IndexOfDeletedRow, 1);
        //            IndexOfDeletedRow = cfg.LinkedObject.findIndex(dr => dr['IsNew'] == true && dr['EntityState'] == EntityStateEnum.Deleted);
        //        }


        //    }
        //}


        this.SelectionChanged.emit(loaderOptions);
    }

    setLinkedObjectsProperties(cfg: TTMultiSearchPanelConfig) {
        //Seçilen Data'yı Config'lerin LinkedObject özelliği ile gelen nesnenin LinkedPropertysine set etmece

        let selectedObjectList = cfg.SelectedObjects as Array<any>;
        if (cfg.selectionMode == "single") {
            if (selectedObjectList != null && selectedObjectList.length > 0)
                cfg.LinkedObject[cfg.LinkedPropertyName.toString()] = selectedObjectList[0];
            else
                cfg.LinkedObject[cfg.LinkedPropertyName.toString()] = null;
        }
        else if (cfg.selectionMode == "multiple") {

            if (selectedObjectList != null) {
                if (selectedObjectList.length > cfg.LinkedObject.length)// Seçilen obje daha fazla ise yeni satır eklemek
                {
                    for (let i = cfg.LinkedObject.length; i < selectedObjectList.length; i++) {

                        let newlinkedObject = new Object();
                        newlinkedObject['IsNew'] = true;
                        newlinkedObject[cfg.LinkedPropertyName.toString()] = selectedObjectList[i];
                        cfg.LinkedObject.push(newlinkedObject);

                    }

                } else if (selectedObjectList.length < cfg.LinkedObject.length) // Seçilen obje daha az  ise  fazla olanların StatusEnum değerleri Deleteda çekilmeli
                {
                    for (let i = selectedObjectList.length; i < cfg.LinkedObject.length; i++) {

                        cfg.LinkedObject[i]['EntityState'] = EntityStateEnum.Deleted;
                    }
                }

                for (let i = 0; i < selectedObjectList.length; i++) { // Seçilen Object değerleri cfg.LinkedObject e eklenir  StatusEnum değerleri düzenlenir çekilmeli
                    let linkedObject = cfg.LinkedObject[i];
                    let selectedObject = selectedObjectList[i];
                    linkedObject[cfg.LinkedPropertyName.toString()] = selectedObject;
                    if (linkedObject['EntityState'] == EntityStateEnum.Deleted) {
                        if (linkedObject['IsNew'] == true)
                            linkedObject['EntityState'] = EntityStateEnum.Added;
                        else
                            linkedObject['EntityState'] = EntityStateEnum.Modified;
                    }

                }

                // Yeni eklenmiş ve Deleted olanları sil
                let IndexOfDeletedRow = cfg.LinkedObject.findIndex(dr => dr['IsNew'] == true && dr['EntityState'] == EntityStateEnum.Deleted);
                while (IndexOfDeletedRow != -1) {
                    cfg.LinkedObject.splice(IndexOfDeletedRow, 1);
                    IndexOfDeletedRow = cfg.LinkedObject.findIndex(dr => dr['IsNew'] == true && dr['EntityState'] == EntityStateEnum.Deleted);
                }


            }
        }
    }

    setDefaultValues(indexOfConfig: number, linkedObject: any) {
        let cfg: TTMultiSearchPanelConfig  = indexOfConfig != undefined ? this.Config[indexOfConfig] : this.Config[0];
        cfg.LinkedObject = linkedObject;

        if (cfg.selectionMode == "single") {
            cfg.SelectedObjects.push(linkedObject[cfg.LinkedPropertyName.toString()]);

        }
        else if (cfg.selectionMode == "multiple") {
            linkedObject.forEach(dr => {
                cfg.SelectedObjects.push(dr[cfg.LinkedPropertyName.toString()]);
            }
            );
        }
    }


    preventArrowKeysBehaviour() {
        let query = jQuery(this.element.nativeElement).find('input.dx-texteditor-input,input[type=text]');
        query.keydown((event) => {
            if (event.keyCode == 40 || event.keyCode == 38) {
                event.preventDefault();
            }
        });
    }

    keyUp(index: number, data: any) {
        let cfg: TTMultiSearchPanelConfig = this.Config[index];
        let event: JQueryEventObject = data.jQueryEvent;
        this.TextChange.emit(this.Text);
        let text: String = this.Text || '';
        if (event.keyCode == 40) {
            this.selectItemByKeyboard(index, cfg, false);
        }
        else if (event.keyCode == 38) {
            this.selectItemByKeyboard(index, cfg, true);
        }
        else if (event.keyCode == 13 && cfg.SelectedObjects.length > 0) {
            this.changed(index, cfg.SelectedObjects[0]);
            if (index != this.Config.length - 1) {
                this.TextBoxes.toArray()[index + 1].instance.focus();
            }
        }
        event.preventDefault();
    }

    selectItemByKeyboard(listIndex: number, cfg: TTMultiSearchPanelConfig, selectPrevious: Boolean) {
        let index: number;
        let data: Array<any>;
        this.detector.detectChanges();
        let list = this.Lists.toArray()[listIndex];
        data = list.items;
        if (data && data.length > 0) {
            index = data.indexOf(cfg.SelectedObjects[0]);
            if (selectPrevious && index == 0) {
                return;
            }
            else if (!selectPrevious && index == data.length - 1) {
                return;
            }
            if (selectPrevious) {
                index--;
            }
            else {
                index++;
            }
            cfg.SelectedObjects.Clear();
            cfg.SelectedObjects.push(data[index]);
            list.instance.scrollToItem(index);
        }
    }
}