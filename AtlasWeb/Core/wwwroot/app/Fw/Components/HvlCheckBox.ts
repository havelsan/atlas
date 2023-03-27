import { Component, EventEmitter, KeyValueDiffers, ElementRef, OnChanges, OnDestroy, SimpleChanges, Optional, AfterViewInit, Input } from '@angular/core';
import { BaseControl } from './BaseControls/BaseControl';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { Subscription } from 'rxjs';

@Component({
    selector: "hvl-checkbox",
    inputs: ['ReadOnly', 'Required', 'Visible', 'TabIndex', 'Value',
        'AllowThreeState', 'BackColor', 'ForeColor', 'Name', 'Font', 'Margin', 'Enabled', 'IsTitleLeft', 'Title', 'ToolTip'],
    outputs: ['ValueChange', 'Click'],
    template: `<table *ngIf="Visible" [style.margin]="Margin" (click)="clicked($event)">
                    <tr>
                    <td valign="top" data-toggle="tooltip" title="{{ToolTip}}"
                    style="font-size: 11px;margin-top: 2px;padding-left: 2px;font-weight: bold;"
                    [style.font-weight]="fontWeight" [style.padding-top]="TitleTopPadding" [style.cursor]="'pointer'" [style.padding-right]="TitleRightPadding"
                    [style.font-family]="TitleFontFamily" [style.font-size]="TitleFontSize" *ngIf="IsTitleLeft">
                        {{Title}}
                    </td>
                        <td style="cursor:pointer;display: block;" valign="top">
                                <span style="color: #3073ac;" *ngIf="UnChecked" class="glyphicon glyphicon-unchecked"></span>
                                <span style="color: #3073ac;" *ngIf="Checked" class="glyphicon glyphicon-ok"></span>
                                <span style="color: #3073ac;" *ngIf="Empty" class="glyphicon glyphicon-stop"></span>
                        </td>
                        <td valign="top" data-toggle="tooltip" title="{{ToolTip}}"
                        style="font-size: 11px;margin-top: 2px;padding-left: 2px;font-weight: bold;"
                        [style.font-weight]="fontWeight" [style.padding-top]="TitleTopPadding" [style.cursor]="'pointer'" [style.padding-left]="TitleLeftPadding" [style.font-family]="TitleFontFamily"
                        [style.font-size]="TitleFontSize" *ngIf="!IsTitleLeft">
                            {{Title}}
                        </td>
                    </tr>
                </table>
                `,
})
export class HvlCheckBox extends BaseControl implements OnChanges, AfterViewInit, OnDestroy {
    AllowThreeState: boolean;
    Value: any;
    ValueChange: EventEmitter<any> = new EventEmitter<any>();
    Click: EventEmitter<any> = new EventEmitter<any>();
    IsTitleLeft: boolean = false;
    Checked: boolean;
    UnChecked: boolean;
    Empty: boolean;
    Title: String;
    ToolTip: String;
    fontWeight: string = 'bold';
    @Input() TitleTopPadding: string = '2px';
    @Input() TitleLeftPadding: string = '5px';
    @Input() TitleRightPadding: string = '5px';
    @Input() TitleFontFamily: string = '\'Open Sans\', sans-serif !important';
    @Input() TitleFontSize: string = '12px !important';
    // @Input() TitleFontWeight: string = 'bold !important';

    @Input() set TitleFontWeight(value: string) {
        if (value != null && value != undefined && value != "")
            this.fontWeight = value;
        else
            this.fontWeight = 'bold';
    }
    private gridMessageServiceSubscription: Subscription;

    constructor(differs: KeyValueDiffers,
        element: ElementRef, @Optional() private gridMessageService: DataGridMessageService) {
        super(differs, element);

        if (gridMessageService) {
            let that = this;
            this.gridMessageServiceSubscription = this.gridMessageService.OnMessage.subscribe(t => {
                if (t.name == that.Name) {
                    if (t.messageName == "ThreeState") {
                        this.AllowThreeState = t.content;
                        that.onStateChanged();
                    }
                    else {
                        that[t.messageName] = t.content;
                        this.setAppearence();
                    }
                }
            });
        }
    }

    clicked(event: any) {
        if (this.ReadOnly || this.Enabled == false) {
            this.Click.emit(event);
            return;
        }
        if (this.AllowThreeState) {
            if (this.Value) {
                this.Value = false;
            }
            else if (this.Value == false) {
                this.Value = null;
            }
            else if (this.Value == null) {
                this.Value = true;
            }
        }
        else {
            if (this.Value) {
                this.Value = false;
            }
            else if (this.Value == false) {
                this.Value = true;
            }
            else if (this.Value == undefined) {
                this.Value = true;
            }
        }
        this.changeState();
        this.ValueChange.emit(this.Value);
    }

    ngAfterViewInit() {
        if (this.gridMessageService) {
            this.element.nativeElement.parentElement.parentElement.style.paddingBottom = "0px";
            this.element.nativeElement.parentElement.parentElement.style.paddingTop = "3px";
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['Value'] && this.Value == undefined) {
            this.Value = false;
        }
        if (changes['AllowThreeState']) {
            if (this.AllowThreeState == undefined) {
                this.AllowThreeState = false;
            }
            this.onStateChanged();
        }
        if (changes['IsTitleLeft'] && this.IsTitleLeft == undefined) {
            this.IsTitleLeft = false;
        }

        if (changes['Value']) {
            this.changeState();
        }
        super.ngOnChanges(changes);
    }

    onStateChanged() {
        if (!this.AllowThreeState &&
            this.Value == null) {
            this.Value = false;
        }
    }

    changeState() {
        if (this.AllowThreeState && this.Value == null) {
            this.Checked = false;
            this.UnChecked = false;
            this.Empty = true;
        }
        else if (<boolean>this.Value) {
            this.Checked = true;
            this.UnChecked = false;
            this.Empty = false;
        }
        else if (<boolean>this.Value == false) {
            this.Checked = false;
            this.UnChecked = true;
            this.Empty = false;
        }
    }

    ngOnDestroy() {
        if (this.gridMessageServiceSubscription != null) {
            this.gridMessageServiceSubscription.unsubscribe();
            this.gridMessageServiceSubscription = null;
        }
    }
}