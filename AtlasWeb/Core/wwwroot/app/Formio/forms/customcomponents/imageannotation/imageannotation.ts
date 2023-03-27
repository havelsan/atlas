import { Component, OnInit, EventEmitter, Input, OnDestroy, ViewChild, Output, AfterViewInit, ElementRef, ChangeDetectorRef } from '@angular/core';
import { FormioCustomComponent } from 'angular-formio';
import ODataStore from 'devextreme/data/odata/store';
import { ODataGridConfig } from 'app/ODataEditor/Models/ODataColumnDto';
import { ODataDynamicGridConfig } from '../../dynamicgrid/dynamic-grid';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { ODataBuilder } from 'app/ODataEditor/Models/ODataObject';

@Component({
    selector: 'image-annotation',
    templateUrl: './imageannotation.html',
    styleUrls: []
})
export class ImageAnnotationComponent implements FormioCustomComponent<any>, OnInit, OnDestroy, AfterViewInit {
    @Input()
    set value(value: string) {

        let data = JSON.parse(value);
        if(!data) {return;}
        if(this.image != data.image){
            this.image = data.image;
        }
        this.canvas.annotate('fill', data.storedElements);
    };
    get value(): string {
        if (this.canvas.data('annotate') == null) {
            return "{}";
        }
        let data = {
            image: this.canvas.data('annotate').selectedImage,
            storedElements: this.canvas.data('annotate').storedElement || []
        };
        return JSON.stringify(data);
    };

    @Output()
    valueChange: EventEmitter<any> = new EventEmitter<any>();

    disabled: boolean;
    formioEvent?: EventEmitter<any>;
    public config: ODataDynamicGridConfig;

    private _color: any;
    @Input()
    set color(value: string) {
        if (value == null || value.length == 0) {
            return;
        }
        this._color = value;
    };
    get color(): string {
        return this._color || 'red';
    };

    private _image: any;
    @Input()
    set image(value: string) {
        if (value == null || value.length == 0) {
            return;
        }
        this._image = value;
        this.loadImage();
    };
    get image(): string {
        return this._image || '/Content/empty.jpg';
    };
    @ViewChild('fileUpload') private fileUpload: any;
    openFile() {
        this.fileUpload.nativeElement.click();
    }
    fileChanged(e: any) {
        var file = e.srcElement.files[0];
        var reader = new FileReader();
        reader.readAsDataURL(file);

        reader.onload = () => {
            let temp = JSON.parse(this.value);
            temp.image = reader.result.toString();
            this.value = JSON.stringify(temp);
        }
    }

    constructor(private httpService: NeHttpService, private changeDetectorRef: ChangeDetectorRef) {
        this.id = Math.random().toString(36).substring(7);
    }

    get canvas(): any {
        return jQuery('#' + this.id);
    }

    private id: string;
    ngOnInit(): void {

    }

    loadImage() {
        this.changeDetectorRef.detectChanges();
        console.log("ON INIT " + this.id);;
        this.ngOnDestroy();
        this.canvas.annotate({
            color: this.color,
            idAttribute: "id",
            bootstrap: true,
            images: [this.image]

        });
        this.canvas.on('mouseup touchend', (event) => {

            this.updateValue(this.value)
        });
    }

    ngAfterViewInit() {
        this.loadImage();
    }

    ngOnDestroy(): void {

        console.log("ON DESTROY " + this.id);;

        if (this.canvas && this.canvas.annotate) {
            try {
                this.canvas.annotate('destroy');
            } catch (e) { }
        }

    }

    updateValue(payload: any) {
        this.value = payload; // Should be updated first
        this.valueChange.emit(payload); // Should be called after this.value update
    }
}
