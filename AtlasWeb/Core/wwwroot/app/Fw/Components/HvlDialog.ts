import {Component, SimpleChanges, OnChanges, KeyValueDiffers,  ElementRef, EventEmitter} from '@angular/core';
import { trigger, state, style, animate, transition,keyframes } from '@angular/animations';
import { BaseControl } from './BaseControls/BaseControl';

@Component({
    selector: 'hvl-dialog',
    outputs: ['onExpanded', 'onCollapsed', 'onBlur'],
    inputs: ['width', 'height', 'left', 'top', 'enableAnimation', 'opened', 'animationType'],
    template: `<div style="position:fixed;z-index:1000;" [style.visibility]="contentVisibility" [style.left]="left" [style.top]="top" [style.height]="height" [style.width]="width" onblur = "onBlur">
        <div [@animationStatus]="animate" (@animationStatus.start)="animationStarted($event)" (@animationStatus.done)="animationCompleted($event)" style="width:100%;height:100%;overflow:hidden" >
            <ng-content></ng-content>
        </div>
    </div>`,
    animations: [trigger('animationStatus', [
        state("Opaque", style({ opacity: "1" })),
        state("Transparent", style({ opacity: "0" })),
        state("VerticalDownCollapsedAnimated", style({ height: "0%" })),
        state("VerticalDownExpandedAnimated", style({ height: "100%" })),
        state("VerticalDownCollapsed", style({ height: "0%" })),
        state("VerticalDownExpanded", style({ height: "100%" })),
        transition('VerticalDownCollapsedAnimated=>VerticalDownExpandedAnimated', animate('200ms ease-in', keyframes([
            style({ height: "0%", offset: 0 }), style({ height: "105%", offset: 0.8 }), style({ height: "100%", offset: 1 })
        ]))),
        transition('VerticalDownExpandedAnimated=>VerticalDownCollapsedAnimated', animate('200ms ease-in', keyframes([
            style({ height: "100%", offset: 0 }), style({ height: "105%", offset: 0.2 }), style({ height: "0%", offset: 1 })
        ]))),
        transition('VerticalDownCollapsed=>VerticalDownExpanded', animate('0ms')),
        transition('VerticalDownExpanded=>VerticalDownCollapsed', animate('0ms')),
        transition('Transparent=>Opaque', animate('250ms')),
        transition('Opaque=>Transparent', animate('250ms'))
    ])]
})
export class HvlDialog extends BaseControl implements OnChanges/*, AfterContentInit*/ {
    contentVisibility: String = 'hidden';
    enableAnimation: Boolean;
    left: any;
    top: any;
    animate: String;
    opened: Boolean;
    animationType: String = "Expand";
    onExpanded: EventEmitter<any> = new EventEmitter<any>();
    onCollapsed: EventEmitter<any> = new EventEmitter<any>();
    onBlur: EventEmitter<any> = new EventEmitter<any>();
    constructor(element: ElementRef, differs: KeyValueDiffers) {
        super(differs, element);
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['enableAnimation'] && this.enableAnimation == undefined) {
            this.enableAnimation = true;
        }
        if (changes['width']) {
            if (this.width == undefined)
                this.width = "10%";
            else {
                if (!this.width.toString().endsWith('px') && !this.width.toString().endsWith('%')) {
                    this.width = this.width + "px";
                }
            }
        }
        if (changes['height']) {
            if (this.height == undefined) {
                this.height = "10%";
            }
            else {
                if (!this.height.toString().endsWith('px') && !this.height.toString().endsWith('%')) {
                    this.height = this.height + "px";
                }
            }
        }
        if (changes['left']) {
            if (this.left == undefined) {
                this.left = "45%";
            }
            else {
                if (!this.left.toString().endsWith('px') && !this.left.toString().endsWith('%')) {
                    this.left = this.left + "px";
                }
            }
        }
        if (changes['top']) {
            if (this.top == undefined) {
                this.top = "45%";
            }
            else {
                if (!this.top.toString().endsWith('px') && !this.top.toString().endsWith('%')) {
                    this.top = this.top + "px";
                }
            }
        }
        if (changes['animationType'] && !this.animationType) {
            this.animationType = "Expand";
        }
        if (changes['opened']) {
            this.toggle();
        }
        super.ngOnChanges(changes);
    }

    animationStarted(data: any) {
        if (this.opened)
            this.contentVisibility = "visible";
    }

    animationCompleted(data: any) {
        if (this.opened) {
            this.onExpanded.emit(this);
        }
        else {
            this.onCollapsed.emit(this);
            this.contentVisibility = "hidden";
        }
    }

    toggle() {
        if (this.opened == undefined) {
            if (this.animationType == 'Expand') {
                this.animate = this.enableAnimation ? "VerticalDownCollapsedAnimated" : "VerticalDownCollapsed";
            }
            else {
                this.animate = "Transparent";
            }
            return;
        }

        if (this.opened) {
            if (this.animationType == 'Expand') {
                if (this.enableAnimation) {
                    this.animate = "VerticalDownExpandedAnimated";
                }
                else {
                    this.animate = "VerticalDownExpanded";
                }
            }
            else {
                this.animate = "Opaque";
            }
        }
        else {
            if (this.animationType == 'Expand') {
                if (this.enableAnimation) {
                    this.animate = "VerticalDownCollapsedAnimated";
                }
                else {
                    this.animate = "VerticalDownCollapsed";
                }
            }
            else {
                this.animate = "Transparent";
            }
        }
    }
}