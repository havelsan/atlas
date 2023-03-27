
import {
    AfterViewInit, Component, ElementRef, EventEmitter, forwardRef,
    Input, Output,
    ViewChild, NgZone, Renderer2, OnDestroy, OnInit, HostListener
} from '@angular/core';

import { NG_VALUE_ACCESSOR, NG_VALIDATORS, ControlValueAccessor, Validator } from '@angular/forms';

import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { IEditorTemplateService } from '../../EditorTemplate/Services/IEditorTemplateService';
import { AtlasEditorTemplateService } from '../../EditorTemplate/Services/AtlasEditorTemplateService';
import { NeHttpService } from '../Services/NeHttpService';
import { MessageService } from '../Services/MessageService';


declare var $: any;
@Component({
    selector: 'hvl-richtextbox',
    templateUrl: './SummerNoteEditor.html',

    providers: [
        { provide: IEditorTemplateService, useClass: AtlasEditorTemplateService },
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => SummerNoteEditor),
            multi: true
        }, {
            provide: NG_VALIDATORS,
            useExisting: forwardRef(() => SummerNoteEditor),
            multi: true
        }
    ],
})
export class SummerNoteEditor implements OnInit, AfterViewInit, ControlValueAccessor, Validator, OnDestroy {

    private editor: any;
    @ViewChild('editorElement') editorElement: any;

    selectTemplateButton = (context) => {
        let ui = $.summernote.ui;

        let button = ui.button({
            contents: '<i class="fa fa-star"/>',
            tooltip: 'Şablon Seç',
            click: () => {
                this.showTemplateList();
            }
        });

        return button.render();
    }

    makeTemplateButton = (context) => {
        let ui = $.summernote.ui;

        // create button
        let button = ui.button({
            contents: '<i class="fa fa-plus"/>',
            tooltip: 'Şablon Oluştur',
            click: () => {

                this.makeTemplate();
            }
        });

        return button.render();
    }

    updateTemplateButton = (context) => {
        let ui = $.summernote.ui;

        // create button
        let button = ui.button({
            contents: '<i class="fa fa-pencil-square-o"/>',
            tooltip: 'Şablon Güncelle',
            click: () => {

                this.updateTemplate();
            }
        });

        return button.render();
    }
    public editorOptions: any = {
        lang: 'tr-TR',
        placeholder: '',
        tabsize: 2,
        toolbar: [
            ['style', ['bold', 'italic', 'underline', 'clear']],
            ['font', []],
            ['fontsize', ['fontname', 'fontsize', 'color']],
            ['para', ['style0', 'ul', 'ol', 'paragraph', 'height']],
            ['insert', ['table']],
            ['misc', ['codeview', 'undo', 'redo', 'fullscreen']],
            ['mybutton', ['selectTemplate', 'makeTemplate', 'updateTemplate']],
        ],
        buttons: {
            selectTemplate: this.selectTemplateButton,
            makeTemplate: this.makeTemplateButton,
            updateTemplate: this.updateTemplateButton,
        },
        fontNames: ['Helvetica', 'Arial', 'Arial Black', 'Comic Sans MS', 'Courier New', 'Roboto', 'Times'],
        callbacks: {
            onFocus: () => {
                if (this.AutoHide) {
                    this.showToolbar();
                }
            },
            onChange: (html, $editable) => {

                this.updateValue(html);
                this.onModelChange(html);

                this.onContentChanged.emit({
                    editor: this.editor,
                    html: html
                });

            }
        }
    };

    ngOnInit() {
    }

    private hideToolbar() {
        $(this.editor).parent().find('.note-toolbar-wrapper').hide();
        $(this.editor).parent().find('.note-toolbar').hide();
    }

    private showToolbar() {
        $(this.editor).parent().find('.note-toolbar-wrapper').show();
        $(this.editor).parent().find('.note-toolbar-wrapper').css('height', 'unset');
        $(this.editor).parent().find('.note-toolbar').show();
    }

    public isFullScreen(): boolean {
        return $('.note-editor').filter('.fullscreen').length > 0;
    }

    @HostListener('document:click', ['$event.target'])
    onClick(targetElement) {
        const clickedInside = this.editor.parent()[0].contains(targetElement);
        if (!clickedInside) {
            if (this.AutoHide && this.isFullScreen() == false) {
                this.hideToolbar();
            }
        } else {
            if (this.AutoHide && this.isFullScreen() == false) {
                this.showToolbar();
            }
        }
    }

    constructor(private elementRef: ElementRef
        , zone: NgZone
        , private renderer: Renderer2
        , private http: NeHttpService
        , private messageService: MessageService
        , private templateService: IEditorTemplateService) {
        this.zone = zone;

        if (this.Height != null) {
            this.editorOptions.height = this.Height;
        } else {
            this.Height = "100px";
            this.editorOptions.height = this.Height;
        }
        if (this.Width != null) {
            this.editorOptions.width = this.Width;
        }
    }

    content: any;
    private _editorVisible = true;
    private _templateGroupName: string;
    _value: string = '';

    @Input() FixedUI: boolean = true;
    @Input() config: any;
    @Input() debounce: any;
    @Input()
    set Height(value: string) {
        this.editorOptions.height = value;
    }
    get Height(): string {
        return this.editorOptions.height;
    }
    @Input() Width: any = '100%';
    @Input() Theme: string = 'bubble';
    @Input() ControlBorder = "1px solid #bebecc";
    @Input() AutoHide: boolean = true;

    get value(): any { return this._value; }
    @Input() set value(v) {
        if (v !== this._value) {
            this._value = v;
            this.onChange(v);
        }
    }
    onChange(_: any) { }
    @Input() set Visible(value: boolean) {
        this._editorVisible = value;
    }
    get Visible(): boolean {
        return this._editorVisible;
    }

    @Input() set Rtf(value: string) {
        this.value = value;
    }
    get Rtf(): string {
        return this._value;
    }

    @Input()
    set TemplateGroupName(value: string) {
        this._templateGroupName = value;
    }
    get TemplateGroupName(): string {
        return this._templateGroupName;
    }

    private _readOnly: boolean;
    @Input() set ReadOnly(value: boolean) {

        this._readOnly = value;
        if(this.editorElement){
            this.editor = $(this.editorElement.nativeElement);
            if (this.editor && value == true) {
                this.editor.summernote('disable');
            }
        }
    }
    get ReadOnly(): boolean {
        return this._readOnly;
    }

    @Input() set DisableResize(value: boolean) {
        this.editorOptions.disableResizeEditor = value;
    }
    get DisableResize(): boolean {
        return this.editorOptions.disableResizeEditor
    }


    @Input() theme: string;
    @Input() modules: Object;
    //@Input() ReadOnly: boolean = false;
    @Input() placeholder: string;
    @Input() maxLength: number;
    @Input() minLength: number;
    @Input() required: boolean;
    @Input() formats: string[];
    @Input() bounds: HTMLElement | string;

    @Output() change = new EventEmitter();
    @Output() ready = new EventEmitter();
    @Output() blur = new EventEmitter();
    @Output() focus = new EventEmitter();
    @Output() onEditorCreated: EventEmitter<any> = new EventEmitter();
    @Output() onContentChanged: EventEmitter<any> = new EventEmitter();
    @Output() onSelectionChanged: EventEmitter<any> = new EventEmitter();

    onModelChange: Function = () => { };
    onModelTouched: Function = () => { };
    private zone: NgZone;
    onTouched() { }

    ngAfterViewInit() {
        this.editor = $(this.editorElement.nativeElement);
        this.onEditorCreated.emit(this.editorElement);

        if (this.AutoHide) {
            this.hideToolbar();
        }

        if (this.editor && this.ReadOnly == true) {
            this.editor.summernote('disable');
        }

        if (this._value != "") {
            this.writeValue(this._value);
        }
    }

    makeTemplate() {
        if (this._value != null && this._value != "") {
            let that = this;
            const Uri = '/api/EditorTemplate/SaveEditorTemplate';
            this.templateService.makeEditorTemplate(this.TemplateGroupName).then(result => {
                if (result.Result === DialogResult.OK) {
                    that.templateInfo = { MenuCaption: result.Param }
                    if (that.templateInfo) {
                        that.templateInfo.Content = this._value;
                        that.templateInfo.GroupName = that.TemplateGroupName;
                        that.http.post(Uri, that.templateInfo).then(r => {
                            that.messageService.showInfo(`${that.templateInfo.GroupName} grubu için ${that.templateInfo.MenuCaption} şablonu başarılı olarak kaydedildi`);
                        }).catch(error => {
                            that.messageService.showError(error);
                        });
                    }
                }
            });
        } else {
            this.showEmptyTemplateError();
        }
    }
    private templateInfo: any = null;
    updateTemplate() {

        if (this._value != null && this._value != "") {
            let that = this;
            const Uri = '/api/EditorTemplate/updateEditorTemplate';
            this.templateService.updateEditorTemplate(this.TemplateGroupName).then(result => {
                if (result.Result === DialogResult.OK) {
                    that.templateInfo = result.Param;
                    if (that.templateInfo) {
                        that.templateInfo.Content = this._value;
                        that.templateInfo.GroupName = that.TemplateGroupName;
                        that.http.post(Uri, that.templateInfo).then(r => {
                            that.messageService.showInfo(`${that.templateInfo.GroupName} grubu için ${that.templateInfo.MenuCaption} şablonu başarılı olarak kaydedildi`);
                        }).catch(error => {
                            that.messageService.showError(error);
                        });
                    }
                }
            });
        } else {
            this.showEmptyTemplateError();
        }
    }
    private showEmptyTemplateError() {
        this.messageService.showError("Şablon içeriği boş olarak kaydedilemez.");
    }
    private insertContentToCurrentLocation(content: string) {

        let oldValue = this.value;

        this.editor.summernote("code", oldValue + "<p>" + content + "</p>");

    }

    showTemplateList() {

        let that = this;
        this.templateService.selectEditorTemplate(this.TemplateGroupName).then(result => {
            if (result.Result === DialogResult.OK) {
                const templateInfo: any = result.Param;
                if (templateInfo && templateInfo.Template) {
                    that.insertContentToCurrentLocation(templateInfo.Template.Content);
                }
            }
        });
    }

    ngOnDestroy() {
        this.editor.summernote('destroy');
    }

    updateValue(value: any) {
        this.zone.run(() => {
            this.content = value;

            this.onChange(value);

            this.onTouched();
            this.change.emit(value);
        });
    }

    writeValue(currentValue: any) {

        if (currentValue !== this.content) {
            this.content = currentValue;
            this.value = currentValue;
        }
    }

    registerOnChange(fn: Function): void {
        this.onModelChange = fn;
    }

    registerOnTouched(fn: Function): void {
        this.onModelTouched = fn;
    }

    validate() {
        if (!this.editor) {
            return null;
        }

        let err: {
            minLengthError?: { given: number, minLength: number };
            maxLengthError?: { given: number, maxLength: number };
            requiredError?: { empty: boolean }
        } = {},
            valid = true;


        const textLength = this.value != null ? this.value.trim().length : 0;

        if (this.minLength && textLength && textLength < this.minLength) {
            err.minLengthError = {
                given: textLength,
                minLength: this.minLength
            };

            valid = false;
        }

        if (this.maxLength && textLength > this.maxLength) {
            err.maxLengthError = {
                given: textLength,
                maxLength: this.maxLength
            };

            valid = false;
        }

        if (this.required && !textLength) {
            err.requiredError = {
                empty: true
            };

            valid = false;
        }

        return valid ? null : err;
    }
}