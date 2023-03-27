import { Component, OnChanges, EventEmitter, KeyValueDiffers, ElementRef, OnDestroy, Optional, ViewChild, SimpleChanges, AfterViewInit } from '@angular/core';
import { BaseControl } from './BaseControls/BaseControl';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { DxButtonComponent } from 'devextreme-angular';
import { Subscription } from 'rxjs';

@Component({
    selector: "hvl-button",
    inputs: ['Text', 'ReadOnly', 'Disabled', 'Visible', 'TabIndex', 'BackColor', 'ForeColor', 'Font', 'Enabled', 'width', 'Row', 'Column', 'Tag', 'height'],
    outputs: ['BtnClicked', 'GrdBtnClicked'],
    template: '<dx-button [visible]="Visible" [height]="height"\
    [(text)]="Text" [disabled]="!Enabled" [width]="width"\
    (onClick)="clicked()"></dx-button>',
})
export class HvlButton extends BaseControl implements OnChanges, AfterViewInit, OnDestroy {
    private gridMessageServiceSubscription: Subscription;

    BtnClicked: EventEmitter<any> = new EventEmitter<any>();
    GrdBtnClicked: EventEmitter<any> = new EventEmitter<any>();
    Row: any;
    Column: any;
    constructor(differs: KeyValueDiffers,
        element: ElementRef, @Optional()
        private gridMessageService: DataGridMessageService) {
        super(differs, element);
        this.BtnClicked = new EventEmitter();

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

    ngAfterViewInit() {
        if (this.gridMessageService && this.height == null) {
            this.height = "22px";
        }
        this.element.nativeElement.parentElement.parentElement.style.padding = "0px";
    }

    ngOnChanges(changes: SimpleChanges) {
        super.ngOnChanges(changes);
    }

    clicked() {
        if (!this.ReadOnly) {
            this.BtnClicked.emit();
            if (this.gridMessageService) {
                this.GrdBtnClicked.emit({
                    Row: this.Row,
                    Column: this.Column,
                    Tag: this.Tag
                });
            }
        }
    }

    buildStyles() {
        let str: string = "", strInner = "";
        for (let key in this.Styles) {
            if (key == "font-size" || key == "text-decoration") {
                strInner = strInner.concat(key + ":" + this.Styles[key] + ";");
            }
            else {
                str = str.concat(key + ":" + this.Styles[key] + ";");
            }
        }
        let that = this;
        let query = jQuery(this.element.nativeElement).find('.dx-button-content');
        if (query.length > 0) {
            for (let i = 0; i < query.length; i++) {
                query[i].setAttribute("style", str);
            }
        }
        query = jQuery(this.element.nativeElement).find('.dx-button-text');
        if (query.length > 0) {
            for (let i = 0; i < query.length; i++) {
                query[i].setAttribute("style", strInner);
            }
        }
    }

    ngOnDestroy() {
        if (this.gridMessageServiceSubscription != null) {
            this.gridMessageServiceSubscription.unsubscribe();
            this.gridMessageServiceSubscription = null;
        }
    }
}