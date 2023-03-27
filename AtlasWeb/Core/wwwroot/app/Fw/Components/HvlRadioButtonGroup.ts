import {
    SimpleChanges, Component, ElementRef, KeyValueDiffers, OnChanges, OnDestroy, EventEmitter, AfterViewInit, Optional, Input
} from '@angular/core';
import { BaseSelectBox } from './BaseControls/BaseSelectBox';
import { Util } from './Util';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { Subscription } from 'rxjs';

@Component({
    selector: 'hvl-radio-button-group',
    inputs: ['Visible', 'Enabled', 'ReadOnly', 'Items', 'Value', 'DisplayPath', 'SelectedValuePath', 'Margin', 'IsHorizontal'],
    outputs: ['ValueChange', 'Click'],
    template: '<div *ngIf="Visible">\
                    <div *ngIf="IsHorizontal">\
                        <div *ngFor="let item of Items" (click)="Select(GetProperty(SelectedValuePath,item))" class="RadioBtnStyle">\
                            <div class="pull-left margin-left-5">\
                                <img src="Content/images/radio_button_off_grey_24x24.png" *ngIf="GetProperty(SelectedValuePath,item)!=Value" />\
                                <img src="Content/images/radio_button_on_grey_24x24.png" *ngIf="GetProperty(SelectedValuePath,item)==Value" />\
                            </div>\
                            <div align="left" class="pull-left">\
                                {{GetProperty(DisplayPath,item)}}\
                            </div>\
                        </div>\
                    </div>\
                    <div *ngIf="!IsHorizontal">\
                        <div *ngFor="let item of Items" (click)="Select(GetProperty(SelectedValuePath,item))" class="RadioBtnStyle">\
                            <div class="pull-left margin-left-5">\
                                <img src="Content/images/radio_button_off_grey_24x24.png" *ngIf="GetProperty(SelectedValuePath,item)!=Value" />\
                                <img src="Content/images/radio_button_on_grey_24x24.png" *ngIf="GetProperty(SelectedValuePath,item)==Value" />\
                            </div>\
                            <div align="left" class="pull-left">\
                                {{GetProperty(DisplayPath,item)}}\
                            </div><br/>\
                        </div>\
                    </div>\
                </div>'
})
export class HvlRadioButtonGroup extends BaseSelectBox implements OnChanges, AfterViewInit, OnDestroy {
    IsHorizontal: Boolean;
    private gridMessageServiceSubscription: Subscription;
    Click: EventEmitter<any> = new EventEmitter<any>();
    constructor(differs: KeyValueDiffers,
        element: ElementRef, @Optional()
        private gridMessageService: DataGridMessageService) {
        super(differs, element);

        if (this.gridMessageService) {
            let that = this;
            this.gridMessageServiceSubscription = this.gridMessageService.OnMessage.subscribe(t => {
                if (t.name == that.Name) {
                    if (t.messageName.startsWith("Font.")) {
                        let fontProperty = t.messageName.substr(t.messageName.indexOf('.') + 1);
                        this.Font[fontProperty] = t.content;
                    }
                    else
                        that[t.messageName] = t.content;
                    this.setAppearence();
                }
            });
        }
    }

    public ngOnChanges(changes: SimpleChanges) {
        if (this.IsHorizontal == undefined) {
            this.IsHorizontal = true;
        }
        if (changes['Visible'] && this.Visible == undefined) {
            this.Visible = true;
        }
        super.ngOnChanges(changes);
    }

    public ngAfterViewInit() {
        if (this.gridMessageService) {
            this.element.nativeElement.parentElement.parentElement.style.paddingTop = "5px";
            this.element.nativeElement.parentElement.parentElement.style.paddingBottom = "0px";
            this.height = "22px";
        }
    }

    GetProperty(exp: string, data: any) {
        return exp ? Util.ResolveProperty(exp, data) : undefined;
    }

    Get(exp: string, data: any) {
        let val = this.GetProperty(exp, data);
        return this.Value == val;
    }

    Select(val: any) {
        if ( this.ReadOnly)
            return;
        if (this.Enabled) {
            this.Value = val;
            this.ValueChange.emit(val);
        }else
            this.Click.emit(val);
    }

    ngOnDestroy() {
        if (this.gridMessageServiceSubscription != null) {
            this.gridMessageServiceSubscription.unsubscribe();
            this.gridMessageServiceSubscription = null;
        }
    }
}

@Component({
    selector: 'hvl-button-radio-group',
    inputs: ['Visible', 'Enabled', 'Items', 'Value', 'DisplayPath', 'SelectedValuePath', 'Margin', 'LastSpanCount', 'FirstSpanCount', 'SelectedObject'],
    outputs: ['ValueChange', 'SelectedObjectChange'],
    template: '<div *ngIf="Visible" class="btn-group btn-group-justified" data-toggle="buttons">\
                    <span class="btn" *ngIf="VisibleFirstSpan"></span>\
                    <span class="btn" *ngFor="let n of FirstSpanCount"></span>\
                    <label class="btn btn-primary " [class.active]="GetProperty(SelectedValuePath,item)==Value" *ngFor="let item of Items" (click)="Select(GetProperty(SelectedValuePath,item));SelectedObject=item;SelectedObjectChange.emit(item)" >\
                        <input type="radio" name="options" autocomplete="off"  >\
                        {{GetProperty(DisplayPath,item)}}\
                    </label>\
                    <span class="btn" *ngIf="VisibleLastSpan"></span>\
                    <span class="btn" *ngFor="let n of LastSpanCount" i18n="@@M30902">Veri yok</span>\
                </div>'
})
export class HvlButtonRadioGroup extends HvlRadioButtonGroup implements OnChanges {

    SelectedObjectChange: EventEmitter<any> = new EventEmitter<any>();
    @Input() VisibleLastSpan: boolean;
    @Input() VisibleFirstSpan: boolean;
    constructor(differs: KeyValueDiffers,
        element: ElementRef) {
        super(differs, element, null);
    }

    public ngOnChanges(changes: SimpleChanges) {
        super.ngOnChanges(changes);
    }
}


@Component({
    selector: 'hvl-image-radio-group',
    inputs: ['Visible', 'Enabled', 'Items', 'Value', 'DisplayPath', 'SelectedValuePath', 'Margin'],
    outputs: ['ValueChange'],
    template: '<div *ngIf="Visible" class="btn-group btn-group-justified" data-toggle="buttons">\
                    <span class="btn" *ngIf="VisibleFirstSpan"></span>\
                    <label class="btn btn-default " [class.active]="GetProperty(SelectedValuePath,item)==Value" *ngFor="let item of Items" (click)="Select(GetProperty(SelectedValuePath,item))" >\
                        <input type="radio" name="options" autocomplete="off"  >\
                        <img src="../Content/Ballard/{{item.Key}}.gif" /> \
                    </label>\
                    <span class="btn" *ngIf="VisibleLastSpan"></span>\
                </div>'
})
export class HvlImageRadioGroup extends HvlRadioButtonGroup implements OnChanges {
    @Input() VisibleLastSpan: boolean;
    @Input() VisibleFirstSpan: boolean;
    constructor(differs: KeyValueDiffers,
        element: ElementRef) {
        super(differs, element, null);
    }

    public ngOnChanges(changes: SimpleChanges) {
        super.ngOnChanges;
    }
}

@Component({
    selector: 'hvl-vertical-radio-group',
    inputs: ['Visible', 'Enabled', 'Items', 'Value', 'DisplayPath', 'SelectedValuePath', 'Margin', 'SelectedObject', 'ShowValues'],
    outputs: ['ValueChange', 'SelectedObjectChange'],
    template: '<div *ngIf="Visible" class="btn-group btn-group-vertical btn-block" data-toggle="buttons">\
                    <label class="btn btn-primary " [class.active]="GetProperty(SelectedValuePath,item)==Value" *ngFor="let item of Items" (click)="Select(GetProperty(SelectedValuePath,item));SelectedObject=item;SelectedObjectChange.emit(item)" >\
                        <span class="col-md-6">\
                            <input type="radio" name="options" autocomplete="off"  >\
                            {{GetProperty(DisplayPath,item)}}\
                        </span>\
                        <span class="col-md-6 rightSpanStyle" *ngIf="ShowValues">{{GetProperty(SelectedValuePath,item)}}</span>\
                    </label>\
                </div>'
})
export class HvlVerticalButtonRadioGroup extends HvlRadioButtonGroup implements OnChanges {

    SelectedObjectChange: EventEmitter<any> = new EventEmitter<any>();
    ShowValues: Boolean;
    constructor(differs: KeyValueDiffers,
        element: ElementRef) {
        super(differs, element, null);
    }

    public ngOnChanges(changes: SimpleChanges) {
        if (this.ShowValues == undefined) {
            this.ShowValues = true;
        }
        super.ngOnChanges(changes);
    }
}

@Component({
    selector: 'hvl-button-glaskow-radio-group',
    inputs: ['Visible', 'Enabled', 'Items', 'Value', 'DisplayPath', 'SelectedValuePath', 'Margin', 'LastSpanCount', 'FirstSpanCount', 'SelectedObject'],
    outputs: ['ValueChange', 'SelectedObjectChange'],
    template: '<div *ngIf="Visible && ReadOnlyBtn!=true" class="btn-group btn-group-justified" data-toggle="buttons">\
                    <span class="btn" *ngIf="VisibleFirstSpan"></span>\
                    <span class="btn" *ngFor="let n of FirstSpanCount"></span>\
                    <label class="btn btn-primary" [class.active]="GetProperty(SelectedValuePath,item) == SelectedObject?.ObjectID" *ngFor="let item of Items"  (click)="Select(GetProperty(SelectedValuePath,item));SelectedObject=item;SelectedObjectChange.emit(item)">\
                        <input type="radio" name="options" autocomplete="off">\
                        {{GetProperty(DisplayPath,item)}}\
                    </label>\
                    <span class="btn" *ngIf="VisibleLastSpan"></span>\
                    <span class="btn" *ngFor="let n of LastSpanCount" i18n="@@M30902">Veri yok</span>\
                </div>\
             <div *ngIf="Visible && ReadOnlyBtn==true" class="btn-group btn-group-justified" data-toggle="buttons">\
                    <span class="btn" *ngIf="VisibleFirstSpan"></span>\
                    <span class="btn" *ngFor="let n of FirstSpanCount"></span>\
                    <label disabled class="btn btn-primary" [class.active]="GetProperty(SelectedValuePath,item) == SelectedObject?.ObjectID" *ngFor="let item of Items">\
                        {{GetProperty(DisplayPath,item)}}\
                    </label>\
                    <span class="btn" *ngIf="VisibleLastSpan"></span>\
                    <span class="btn" *ngFor="let n of LastSpanCount" i18n="@@M30902">Veri yok</span>\
                </div>'
})
export class HvlGlaskowButtonRadioGroup extends HvlRadioButtonGroup implements OnChanges {

    SelectedObjectChange: EventEmitter<any> = new EventEmitter<any>();

    @Input() ReadOnlyBtn: boolean = true;
    @Input() VisibleLastSpan: boolean;
    @Input() VisibleFirstSpan: boolean;

    constructor(differs: KeyValueDiffers,
        element: ElementRef) {
        super(differs, element, null);
    }

    public ngOnChanges(changes: SimpleChanges) {
        super.ngOnChanges(changes);
    }
}