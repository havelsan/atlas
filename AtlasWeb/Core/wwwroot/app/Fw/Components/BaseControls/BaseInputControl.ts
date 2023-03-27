import {
    OnChanges, SimpleChanges, KeyValueDiffers, ElementRef
} from '@angular/core';
import { BaseControl } from './BaseControl';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';
import {  HorizontalAlignment } from 'NebulaClient/Utils/Enums/HorizontalAlignment';
import {  InputFormat } from 'NebulaClient/Utils/Enums/InputFormat';
import { Util } from '../Util';



//extends ValidationComponent
export class BaseInputControl extends BaseControl implements OnChanges {

    MultiLine: boolean = false;
    CharacterCasing: CharacterCasing;
    InputFormat: InputFormat;
    InputTurkishCharacter: boolean;
    TextAlign: HorizontalAlignment;
    IsNonNumeric: Boolean;

    alphaRegEx: RegExp = new RegExp('^([a-zA-Z0-9]|[^\x00-\x7F])+$', 'g');
    turkishRegEx: RegExp = new RegExp('[^\x00-\x7F]', 'g');
    //nonNumericRegEx: RegExp = new RegExp('[^0-9.]', 'g');

    constructor(differs: KeyValueDiffers, element: ElementRef) {
        super(differs, element);
    }

    changed(text: string) {
        this.Validate(text);
        this.changeCasing();
        this.TextChange.emit(text);
    }

    onKey(event: any) {
        if (event.keyCode >= 8 && event.keyCode <= 46) {
            return true;
        }
        let key: string = event.key;
        //this.changeCasing();
        if (!this.latinOnly(key)) {
            event.preventDefault();
            return false;
        }
        if (!this.alphaNumericOnly(key)) {
            event.preventDefault();
            return false;
        }
        if (!this.nonNumericOnly(key)) {
            event.preventDefault();
            return false;
        }
    }

    changeCasing() {
        let casing: CharacterCasing = <number>this.CharacterCasing || CharacterCasing.Normal;
        window.setTimeout(() => {
            if (casing == CharacterCasing.Upper) {

                this.Text = Util.turkishToUpper(this.Text);
            }
            else if (casing == CharacterCasing.Lower) {
                this.Text = Util.turkishToLower(this.Text);
            }
        }, 0);
    }

    alphaNumericOnly(key: string): Boolean {
        if (this.InputFormat && <number>this.InputFormat == InputFormat.AlphaOnly) {
            return (new RegExp('^([a-zA-Z0-9]|[^\x00-\x7F])+$')).test(key);
        }
        return true;
    }

    nonNumericOnly(key: string): Boolean {
        if (this.IsNonNumeric) {
            return (new RegExp('[^0-9]', 'g')).test(key);
        }
        return true;
    }

    latinOnly(key: string): Boolean {
        let allowTurkish: boolean;
        if (this.InputTurkishCharacter == undefined) {
            allowTurkish = true;
        }
        else {
            allowTurkish = this.InputTurkishCharacter;
        }
        if (!allowTurkish) {
            //return !/[\u0250-\ue007]/g.test(key);
            return !(new RegExp('[^\x00-\x7F]')).test(key);
        }
        return true;
    }

    ngOnChanges(changes: SimpleChanges) {
        if (this.Text && this.Text.length > 0) {
            if (changes["CharacterCasing"]) {
                this.onCasingChanged();
                //this.changed();
            }
            if (changes["TextAlign"]) {
                if (this.TextAlign) {
                    if (<number>this.TextAlign == HorizontalAlignment.Left) {
                        this.Styles['text-align'] = 'left';
                    }
                    if (<number>this.TextAlign == HorizontalAlignment.Center) {
                        this.Styles['text-align'] = 'center';
                    }
                    if (<number>this.TextAlign == HorizontalAlignment.Right) {
                        this.Styles['text-align'] = 'right';
                    }
                }
                else {
                    delete this.Styles["text-align"];
                }

            }
            if (changes["InputFormat"]) {
                this.onInputFormatChanged();
            }
            if (changes["InputTurkishCharacter"]) {
                this.onInputTurkishCharacterChanged();
            }
        }
        if (changes['MultiLine']) {
            if (typeof this.MultiLine == "string") {
                if (<string>this.MultiLine == "false") {
                    this.MultiLine = false;
                }
                else if (<string>this.MultiLine == "true"){
                    this.MultiLine = true;
                }
            }
            let that = this;
            window.setTimeout(() => {
                that.buildStyles();
            }, 0);
        }
        super.ngOnChanges(changes);
    }

    onCasingChanged() {
        if (this.CharacterCasing == CharacterCasing.Lower) {
            this.Text = this.Text.toLocaleLowerCase();
            //this.Text = Util.turkishToLower(this.Text);
        }
        else if (this.CharacterCasing == CharacterCasing.Upper) {
            this.Text = this.Text.toLocaleUpperCase();
            //this.Text = Util.turkishToUpper(this.Text);
        }
        this.changed(this.Text);
    }

    onInputTurkishCharacterChanged() {
		let allowTurkish: boolean;
        if (this.InputTurkishCharacter == undefined) {
            allowTurkish = true;
        }
        else {
            allowTurkish = this.InputTurkishCharacter;
        }
        if (!allowTurkish) {
            let str: string = this.Text;
            let matches: RegExpMatchArray = this.Text.match(this.turkishRegEx);
            if (matches && matches.length > 0) {
                for (let i = 0; i < matches.length; i++) {
                    str = str.replace(matches[i], '');
                }
                this.Text = str;
                this.changed(this.Text);
            }
        }
    }

    onInputFormatChanged() {
        let str: string = this.Text;
        if (<number>this.InputFormat == InputFormat.AlphaOnly) {
            this.Text = str.replace(/[^0-9a-zA-Z]/g, '');
            this.changed(this.Text);
        }
    }

}