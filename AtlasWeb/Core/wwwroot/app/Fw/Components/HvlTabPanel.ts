import { Component, IterableDiffers} from '@angular/core';

export interface ITabPanel
{
    ModulePath: string;
    ComponentPath: string;
    RouteData: any;
    RouteData2?: any;
    Title: string;
    Active: Boolean;
    Key?:string;
}

@Component({
    selector: 'hvl-tab-panel',
    inputs: ['SelectedTabIndex', 'Tabs', 'Closable'],
    template: '<ul class="nav nav-tabs">\
            <li *ngFor="let tab of Tabs; let i=index" class="nav nav-tabs" [class.active]="tab.Active">\
                <a href="javascript:void(0)" (click)="selectTab(i)" style="padding:5px 15px 5px 15px">\
                    <span>{{tab.Title}}</span>\
                    <span *ngIf="Closable" class="glyphicon glyphicon-remove-circle" (click)="removeTabs(i)"></span>\
                </a>\
            </li>\
        </ul>\
        <div class="tab-content">\
            <div *ngFor="let tabContent of Tabs;trackBy: trackByTabs" class="tab-pane fade in" [class.active]="tabContent.Active">\
                <hvl-tab [TabIndex]="index" [TabData]="tabContent">\
                </hvl-tab>\
            </div>\
        </div>',
})
export class HvlTabPanel
{
    SelectedTabIndex: Number;
    Tabs: ITabPanel[];
    tabDifferences: any;
    Closable: boolean = true;
    constructor(private differs: IterableDiffers) {
        this.tabDifferences = differs.find([]).create(null);
    }

    selectTab(index: number) {
        for (let i = 0; i < this.Tabs.length; i++) {
            this.Tabs[i].Active = false;
        }
        this.Tabs[index].Active = true;
    }

    trackByTabs(index: number, panel: ITabPanel): string
    {
        return panel.Title;
    }

    ngDoCheck() {
        let that = this;
        let tabs: Array<ITabPanel> = new Array<ITabPanel>();
        let differs = this.tabDifferences.diff(this.Tabs);
        if (differs) {
            differs.forEachAddedItem(r => {
                let item = <ITabPanel>r.item;
                if (item.Active)
                    tabs.push(item);
            });
            if (tabs.length > 0) {
                for (let i = 0; i < this.Tabs.length; i++) {
                    this.Tabs[i].Active = false;
                }
            }
            for (let i = 0; i < tabs.length; i++) {
                if (i != tabs.length - 1) {
                    tabs[i].Active = false;
                }
                else {
                    tabs[i].Active = true;
                }
            }
        }
    }

    removeTabs(index: number) {
        this.Tabs.splice(index, 1);
        if (this.Tabs.length != 0) {
            this.Tabs[0].Active = true;
        }
    }
}