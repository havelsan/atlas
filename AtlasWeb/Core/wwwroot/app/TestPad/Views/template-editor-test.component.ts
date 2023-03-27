//$0AF4BA87
import { Component, ViewChild } from '@angular/core';
import { AtlasRichTextBox } from "Fw/Components/AtlasRichTextBox";

@Component({
    selector: 'template-editor-test-component',
    template: `

    <br>
    <button (click)="displayContent()">Display Content</button>
<h2>Template Editor Quill</h2>
<hvl-richtextbox #richbox [Theme]="'snow'"  [(value)]="EditorContent" [ReadOnly] ="false"></hvl-richtextbox>
<hr/>
{{ EditorContent | json}}
{{ RichContent }}
    `
})
export class TemplateEditorTestComponent {
    private _templateGroupName: string;
    private _editorContent: string;
    private _newContent: string;
    public HtmlContent: string = `<p>deneme</p>`;
    private editorReadOnly: boolean = false;
    private _editorVisibility: boolean = true;
    public RichContent: string;
    @ViewChild('richbox') rtbInstance: AtlasRichTextBox;

    constructor() {
    }

    public get TemplateGroupName(): string {
        return this._templateGroupName;
    }
    public set TemplateGroupName(value: string) {
        this._templateGroupName = value;
    }
    public get EditorContent(): string {
        return this._editorContent;
    }
    public set EditorContent(value: string) {
        this._editorContent = value;
    }
    public onChange(value: string): void {
        this._newContent = value;
    }

    setEditorReadOnly() {
        this.editorReadOnly = !this.editorReadOnly;
    }

    toggleVisible() {
        this._editorVisibility = !this._editorVisibility;
    }

    newLineTest() {
        this.HtmlContent = i18n("M12069", "bu bir denemedir\r\nAlttaki satır");
    }

    displayContent() {
        this.RichContent = this.rtbInstance.value;
    }
}
