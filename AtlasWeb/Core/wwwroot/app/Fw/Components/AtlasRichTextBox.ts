import {
    AfterViewInit, Component, ElementRef, EventEmitter, forwardRef,
    Input, OnChanges, Output, SimpleChanges, ViewEncapsulation,
    ViewChild, NgZone, Renderer2, OnDestroy, SecurityContext
} from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { NG_VALUE_ACCESSOR, NG_VALIDATORS, ControlValueAccessor, Validator } from '@angular/forms';

import * as screenfull from 'screenfull';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { IEditorTemplateService } from '../../EditorTemplate/Services/IEditorTemplateService';
import { AtlasEditorTemplateService } from '../../EditorTemplate/Services/AtlasEditorTemplateService';
import { NeHttpService } from '../Services/NeHttpService';
import { MessageService } from '../Services/MessageService';

@Component({
    selector: 'hvl-richtextbox2',
    template: `<div class="fullscreen" #editorcontainer [style.height]="Height" [style.border]="ControlBorder" style="background-color: white;">
    <div #editorelem quill-editor-element>
        <ng-content select="[quill-editor-toolbar]"></ng-content>
    </div>
</div>
`,
    providers: [
        { provide: IEditorTemplateService, useClass: AtlasEditorTemplateService },
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => AtlasRichTextBox),
            multi: true
        }, {
            provide: NG_VALIDATORS,
            useExisting: forwardRef(() => AtlasRichTextBox),
            multi: true
        }
    ],
    encapsulation: ViewEncapsulation.None
})
export class AtlasRichTextBox implements AfterViewInit, ControlValueAccessor, OnChanges, Validator, OnDestroy {

    quillEditor: any;
    emptyArray: any[] = [];
    content: any;
    defaultModules = {
        toolbar: {
            container: [
                ['fullscreen', 'templatelist', 'maketemplate'],
                ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
                [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
                [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
                [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
                [{ 'color': this.emptyArray.slice() }, { 'background': this.emptyArray.slice() }],          // dropdown with defaults from theme
                [{ 'align': this.emptyArray.slice() }]
            ],
            handlers:
            {
                'fullscreen': this.doMaximize.bind(this),
                'templatelist': this.showTemplateList.bind(this),
                'maketemplate': this.makeTemplate.bind(this)
            }
        }
    };


    private _editorVisible = true;
    private _templateGroupName: string;
    _value: string = '';

    @Input() FixedUI: boolean = true;
    @Input() config: any;
    @Input() debounce: any;
    @Input() Height: any = '100px';
    @Input() Width: any = '100%';
    @Input() Theme: string = 'bubble';
    @Input() ControlBorder = "1px solid #bebecc";

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

    @Input() theme: string;
    @Input() modules: Object;
    @Input() ReadOnly: boolean;
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

    @ViewChild('editorelem') editorElement: any;
    @ViewChild('editorcontainer') editorContainer: any;

    private quillEditorSelectionChangeEventHandler: Function;
    private quillEditorTextChangeEventHandler: Function;
    private maximizebuttonClickEventDetach: Function;
    private screenFullChangeStateEvent: Function;


    onModelChange: Function = () => { };
    onModelTouched: Function = () => { };
    private zone: NgZone;

    constructor(private elementRef: ElementRef
        , zone: NgZone
        , private renderer: Renderer2
        , private sanitizer: DomSanitizer
        , private http: NeHttpService
        , private messageService: MessageService
        , private templateService: IEditorTemplateService) {
        this.zone = zone;
    }

    onTouched() { }

    ngAfterViewInit() {
        let that = this;
        const icons = null;//Quill.import('ui/icons');
        if (icons) {
            icons['fullscreen'] = `<i class="fa fa-window-maximize" aria-hidden="true"></i>`;
            icons['templatelist'] = `<i class="fa fa-list-alt" aria-hidden="true"></i>`;
            icons['maketemplate'] = `<i class="fa fa-newspaper-o" aria-hidden="true"></i>`;
        }

        const toolbarElem = this.elementRef.nativeElement.querySelector('[quill-editor-toolbar]');
        let modules = this.modules || this.defaultModules;

        if (toolbarElem) {
            modules['toolbar'] = toolbarElem;
        }

        const editorElement = this.editorElement.nativeElement;

        this.quillEditor = null;
        editorElement.classList.add("col-sm-12");

        if (this.content) {
            this.quillEditor.pasteHTML(this.content);
        }

        if (this.Theme === 'snow') {
            this.ControlBorder = 'none';
        }

        this.onEditorCreated.emit(this.quillEditor);

        // mark model as touched if editor lost focus
        this.quillEditorSelectionChangeEventHandler = this.quillEditor.on('selection-change', (range: any, oldRange: any, source: string) => {
            this.onSelectionChanged.emit({
                editor: this.quillEditor,
                range: range,
                oldRange: oldRange,
                source: source,
                bounds: this.bounds || document.body
            });

            if (!range) {
                this.onModelTouched();
            }
        });

        // update model if text changes
        this.quillEditor.on('text-change', (delta: any, oldDelta: any, source: string) => {
            let html: (string | null) = editorElement.children[0].innerHTML;
            const text = this.quillEditor.getText();

            if (html === '<p><br></p>') {
                html = null;
            }
            this.updateValue(html);
            this.onModelChange(html);

            this.onContentChanged.emit({
                editor: this.quillEditor,
                html: html,
                text: text,
                delta: delta,
                oldDelta: oldDelta,
                source: source
            });
        });

        if (this._value != "") {
            this.writeValue(this._value);
        }

        if (screenfull.enabled) {
            this.screenFullChangeStateEvent = (<any>screenfull).on('change', () => {
                if (screenfull.isFullscreen === false) {
                    this.renderer.setStyle(this.editorContainer.nativeElement, 'height', that.Height);

                } else {
                    this.renderer.setStyle(this.editorContainer.nativeElement, 'height', '100%');
                    this.renderer.setStyle(this.editorContainer.nativeElement, 'width', '100%');
                }
            });
        }
    }

    makeTemplate() {
        let that = this;
        const Uri = '/api/EditorTemplate/SaveEditorTemplate';
        this.templateService.makeEditorTemplate(this.TemplateGroupName).then(result => {
            if (result.Result === DialogResult.OK) {
                const templateInfo: any = result.Param;
                if (templateInfo) {
                    templateInfo.Content = this._value;
                    that.http.post(Uri, templateInfo).then(r => {
                        that.messageService.showInfo(`${templateInfo.GroupName} grubu için ${templateInfo.MenuCaption} şablonu başarılı olarak kaydedildi`);
                    }).catch(error => {
                        that.messageService.showError(error);
                    });
                }
            }
        });
    }

    private insertContentToCurrentLocation(range: any, content: string) {
        const quill = this.quillEditor;
        const sanitizedHtml = this.sanitizer.sanitize(SecurityContext.HTML, content);
        if (range) {
            quill.clipboard.dangerouslyPasteHTML(range.index, sanitizedHtml);
        } else {
            quill.clipboard.dangerouslyPasteHTML(sanitizedHtml);
        }
    }

    showTemplateList() {

        const quill = this.quillEditor;
        let range = quill.getSelection();

        let that = this;
        this.templateService.selectEditorTemplate(this.TemplateGroupName).then(result => {
            if (result.Result === DialogResult.OK) {
                const templateInfo: any = result.Param;
                if (templateInfo) {
                    const template = templateInfo.Template;
                    if (template && template.Content) {
                        that.insertContentToCurrentLocation(range, template.Content);
                    }
                }
            }
        });
    }

    public getLength(): number {
        if (this.quillEditor) {
            return this.quillEditor.getLength();
        }
        return 0;
    }

    public getContents(index: number = 0, length: number): any {
        if (this.quillEditor) {
            return this.quillEditor.getContents(index, length);
        }
        return null;
    }

    public setContents(delta: any): void {
        if (this.quillEditor) {
            this.quillEditor.setContents(delta, 'api');
        }
    }

    public insertContent(index: number, content: string) {
        const quill = this.quillEditor;
        const sanitizedHtml = this.sanitizer.sanitize(SecurityContext.HTML, content);
        if (index) {
            quill.clipboard.dangerouslyPasteHTML(index, sanitizedHtml);
        } else {
            quill.clipboard.dangerouslyPasteHTML(sanitizedHtml);
        }
    }

    doMaximize() {
        if (screenfull.enabled) {
            screenfull.toggle(this.editorContainer.nativeElement);
        }
    }

    ngOnDestroy() {
        if (this.maximizebuttonClickEventDetach) {
            this.maximizebuttonClickEventDetach();
            this.maximizebuttonClickEventDetach = null;
        }
        if (this.quillEditorSelectionChangeEventHandler) {
            this.quillEditor.off('selection-change', this.quillEditorSelectionChangeEventHandler);
            this.quillEditorSelectionChangeEventHandler = null;
        }
        if (this.quillEditorTextChangeEventHandler) {
            this.quillEditor.off('text-change', this.quillEditorTextChangeEventHandler);
            this.quillEditorTextChangeEventHandler = null;
        }
        if (screenfull.enabled) {
            screenfull.off('change', <any>this.screenFullChangeStateEvent);
        }
    }

    updateValue(value: any) {
        this.zone.run(() => {
            this.value = value;

            this.onChange(value);

            this.onTouched();
            this.change.emit(value);
        });
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['ReadOnly'] && this.quillEditor) {
            this.quillEditor.enable(!changes['ReadOnly'].currentValue);
        }
    }

    writeValue(currentValue: any) {
        this.content = currentValue;

        if (this.quillEditor) {
            if (currentValue) {
                this.quillEditor.pasteHTML(currentValue);
                return;
            }
            this.quillEditor.setText('');
        }
    }

    registerOnChange(fn: Function): void {
        this.onModelChange = fn;
    }

    registerOnTouched(fn: Function): void {
        this.onModelTouched = fn;
    }

    validate() {
        if (!this.quillEditor) {
            return null;
        }

        let err: {
            minLengthError?: { given: number, minLength: number };
            maxLengthError?: { given: number, maxLength: number };
            requiredError?: { empty: boolean }
        } = {},
            valid = true;

        const textLength = this.quillEditor.getText().trim().length;

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
