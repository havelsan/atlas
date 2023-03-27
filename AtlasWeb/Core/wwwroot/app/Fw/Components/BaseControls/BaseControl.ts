//$6D4AFDB4
import {
    Input, EventEmitter, AfterViewInit,
    OnChanges, SimpleChanges, DoCheck, KeyValueDiffers, ElementRef, Directive
} from '@angular/core';
import { Font } from 'NebulaClient/Visual/Font';
import { ValidationConfig } from '../Validation/ValidationConfig';
import { Validation } from '../Validation/Validation';
import { RequiredValidation } from '../Validation/RequiredValidation';
import { LengthValidation } from '../Validation/LengthValidation';

export class ValidationFactory {
    public static GetValidation(data: ValidationConfig): Validation {
        if (data.TypeId.includes("Required")) {
            return new RequiredValidation(data.ErrorMessage);
        }
        else if (data.TypeId.includes("StringLength")) {
            return new LengthValidation(data.ErrorMessage, data.MinimumLength, data.MaximumLength);
        }
    }
}
@Directive()
export class BaseControl implements OnChanges, DoCheck, AfterViewInit {

    private _textValue: any;
    @Input() set Text(propVal: any) {
        this._textValue = propVal;
    }

    get Text(): any {
        return this._textValue;
    }

    ReadOnly: boolean = false;
    Tag: any;
    Margin: String;
    Visible: boolean = true;
    TabIndex: number;
    ShowClearButton: boolean = true;

    BackColor: string;
    ForeColor: string;
    Font: Font;
    Enabled: boolean = true;
    TextChange: EventEmitter<any>;

    height: any;
    width: any;
    Styles: any = {};

    isValid: any = true;
    validationError: any = { message: "" };

    ValidationConfiguration: Array<ValidationConfig>;
    Required: Boolean;
    Name: string;
    fontDifferences: any;

    autoResizeEnabled: boolean;

    constructor(protected differs: KeyValueDiffers, public element: ElementRef) {
        this.TextChange = new EventEmitter<any>();
        this.fontDifferences = differs.find({}).create();
    }

    ngAfterViewInit() {
        this.setAppearence();
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['BackColor']) {
            if (this.BackColor) {
                this.Styles['background-color'] = this.BackColor;
            }
            else {
                delete this.Styles['background-color'];
            }
        }
        if (changes['Enabled']) {
            if (this.Enabled == undefined) {
                this.Enabled = true;
            }
        }
        if (changes['ReadOnly']) {
            if (this.ReadOnly == undefined) {
                this.ReadOnly = false;
            }
        }
        if (changes['ForeColor']) {
            if (this.ForeColor) {
                this.Styles.color = this.ForeColor;
            }
            else {
                delete this.Styles["color"];
            }
        }
        if (changes['Font']) {
            this.changeFont();
        }
        if (changes['Visible'] && this.Visible == undefined) {
            this.Visible = true;
        }
        if (changes['width'] && !this.width) {
            this.width = "100%";
        }
        this.setAppearence();
    }

    ngDoCheck() {
        if (this.Font && typeof this.Font == "object") {
            let fontChanges: any = this.fontDifferences.diff(this.Font);
            if (fontChanges) {
                this.changeFont();
                this.setAppearence();
            }
        }
    }

    protected buildStyles() {
        //setTimeout((function () {
        let str: string = "";
        for (let key in this.Styles) {
            str = str.concat(key + ":" + this.Styles[key] + ";");
        }
        let that = this;
        let query = jQuery(this.element.nativeElement).find('input.dx-texteditor-input,textarea,input[type=text]');
        if (query.length > 0) {
            for (let i = 0; i < query.length; i++) {
                if (this.autoResizeEnabled != true)//autoresize özelliğini kapatıyordu. ö yüzden böyle bir kod eklendi
                    query[i].setAttribute("style", str);
            }
        }
        //}).bind(this), 0);
    }

    setAppearence() {
        if (this.BackColor) {
            this.Styles['background-color'] = this.BackColor;
        }
        else {
            delete this.Styles['background-color'];
        }
        if (this.ForeColor) {
            this.Styles.color = this.ForeColor;
        }
        else {
            delete this.Styles["color"];
        }
        this.buildStyles();
        this.changeFont();
    }

    changeFont() {
        if (this.Font && typeof this.Font == "object") {
            if (this.Font.Bold) {
                this.Styles["font-weight"] = 'bold !important';
            }
            else {
                delete this.Styles["font-weight"];
            }

            if (this.Font.Name) {
                this.Styles["font-family"] = this.Font.Name + " !important";
            }
            else {
                delete this.Styles["font-family"];
            }

            if (this.Font.Italic) {
                this.Styles["font-style"] = "italic" + " !important";
            }
            else {
                delete this.Styles["font-style"];
            }

            if (this.Font.Size) {
                this.Styles["font-size"] = this.Font.Size.toString() + "px" + " !important";
            }
            else {
                delete this.Styles["font-size"];
            }

            if (this.Font.Strikeout) {
                this.Styles["text-decoration"] = "line-through" + " !important";
            }
            else {
                if (this.Font.Underline) {
                    this.Styles["text-decoration"] = "underline" + " !important";
                }
                else {
                    delete this.Styles["text-decoration"];
                }
            }
        }
        else {
            delete this.Styles["font-weight"];
            delete this.Styles["font-family"];
            delete this.Styles["font-size"];
            delete this.Styles["font-style"];
            delete this.Styles["text-decoration"];
        }
    }

    checkValidation() {
        let that = this;
        this.isValid = true;
        let validation: Validation;
        this.validationError.message = "";
        if (this.Required &&
            ((this.Text && this.Text.toString().trim().length == 0) || !this.Text)) {
            this.isValid = false;
            this.validationError = { message: i18n("M12062", "Bu alan zorunludur") };
            return false;
        }

        if (this.ValidationConfiguration && this.ValidationConfiguration.length > 0) {
            for (let i = 0; i < this.ValidationConfiguration.length; i++) {
                let config = this.ValidationConfiguration[i];
                validation = ValidationFactory.GetValidation(config);
                if (!validation.IsValid(that.Text)) {
                    that.isValid = false;
                    that.validationError = { message: validation.ErrorMessage };
                    return false;
                }
            }
        }
        return this.isValid;
    }


    Validate(text) {
        if (this.Required) {
            if (!text || text == '') {
                this.isValid = false;
                this.validationError = { message: i18n("M12062", "Bu alan zorunludur") };
            }
            else {
                this.isValid = true;
            }
        }
        else
            this.isValid = true;
    }

    unListen(eventUnlistenFunc: Function) {
        if (eventUnlistenFunc != null) {
            eventUnlistenFunc();
            eventUnlistenFunc = null;
        }
    }
}