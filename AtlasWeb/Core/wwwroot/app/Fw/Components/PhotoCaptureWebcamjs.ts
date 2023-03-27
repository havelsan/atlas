import { Component, OnInit, AfterViewInit, Input, Output, EventEmitter, ViewChild, ChangeDetectorRef } from '@angular/core';
import * as Webcam from 'webcam';
import { MessageService } from 'Fw/Services/MessageService';
import { ServiceLocator } from "Fw/Services/ServiceLocator";


@Component({
    selector: "photo-capture-webcamjs",
    templateUrl: './PhotoCaptureWebcamjs.html',
    providers: [MessageService]
})
export class PhotoCaptureWebcamjsPanel implements OnInit, AfterViewInit {

    public showCurrentImage = true;
    public showStartCaptureButton = true;
    public showProcessButtons = false;
    public showCapturePhotoButton = false;
    public originalImg: string;
    public photoCaptureClicked = false;

    private _image: string;
    private _height: number = 100;
    private _scaleType: string = "px";
    private _width: number = 80;
    private _closeButton: boolean =false;

    @Output() OnPhotoCaptured: EventEmitter<any> = new EventEmitter<any>();
    public uploadClicked: boolean = false;
    public showUploadButton: boolean = true;

    @Input() set CloseButtons(propVal: boolean) {
        if(propVal != null)
            this._closeButton = propVal;
    }

    @Input() set Height(propVal: number) {
        this._height = propVal;
    }

    @Input() set Width(propVal: number) {
        this._width = propVal;
    }

    @Input() set ScaleType(propVal: string) {
        if(propVal != null)
            this._scaleType = propVal;
        else
            this._scaleType ="px";
    }

    @Input() set Image(propVal: string) {
        let base64Img: string = 'data:image/jpeg;base64,';

        if (!String.isNullOrEmpty(propVal)) {
            this._image = 'data:image/jpeg;base64,' + propVal;
            if (this.originalImg == null && (!this.photoCaptureClicked && !this.uploadClicked)) {
                this.originalImg = base64Img + propVal;
            }
        }
        else {
            this._image = "../../Content/PatientAdmission/avatar_unknown.png";
            this.showCurrentImage = true;
            this.showProcessButtons = false;
            this.showCapturePhotoButton = false;
            this.showStartCaptureButton = true;
            this.showUploadButton = true;
            this.originalImg = null;
            this.setImgWidth();
        }
    }

    @ViewChild('photoview') photoView;
    @ViewChild('photo') photo;
    @ViewChild('image') image;
    @ViewChild('capturedphoto') capturedPhoto;
    @ViewChild('fileupload') fileUpload;
    ngOnInit(): void {

    }

    ngAfterViewInit(): void {
        this.photo.nativeElement.style.height = this._height + this._scaleType;
        this.photo.nativeElement.style.width = this._width + this._scaleType;
        this.photo.nativeElement.style.display = 'block';
        this.photo.nativeElement.style.position = 'relative';

        this.setImgWidth();

        if (String.isNullOrEmpty(this._image))
            this.image.nativeElement.src = "../../Content/PatientAdmission/avatar_unknown.png";
        else
            this.image.nativeElement.src = this._image;

    }

    constructor(private changeDetectorRef: ChangeDetectorRef) {
        
    }

    setImgWidth() {
        if (this.image != null) {
            this.image.nativeElement.style.height = this._height + this._scaleType;;
            this.image.nativeElement.style.width = this._width + this._scaleType;;
        }
    }

    startPhotoCapture() {
        Webcam.set({
            width: this._width,
            height: this._height,
            image_format: 'jpeg',
            jpeg_quality: 90
        });
        this.showCurrentImage = false;
        this.showStartCaptureButton = false;
        this.showProcessButtons = true;
        this.showCapturePhotoButton = true;
        this.showUploadButton = false;
        Webcam.attach(this.photoView.nativeElement);
    }

    capturePhoto() {
        Webcam.snap(data => {
            Webcam.reset();
            this.showCurrentImage = true;
            this.showProcessButtons = true;
            this.showStartCaptureButton = false;
            this.showUploadButton = false;
            this.showCapturePhotoButton = false;
            this._image = data;
            let base64imgstr = data.substring(data.indexOf(',') + 1, data.length);
            this.OnPhotoCaptured.emit(base64imgstr);
            this.photoCaptureClicked = true;
        });
    }

    close() {
        this.showCurrentImage = true;
        this.showStartCaptureButton = true;
        this.showUploadButton = true;
        this.showProcessButtons = false;
        this.showCapturePhotoButton = false;
        if (String.isNullOrEmpty(this.originalImg))
            this._image = "../../Content/PatientAdmission/avatar_unknown.png";
        else
            this._image = this.originalImg;
        Webcam.reset();
        this.fileUpload.nativeElement.value = "";
        this.uploadClicked = false;
        this.photoCaptureClicked = false;

        this.changeDetectorRef.detectChanges();
        this.setImgWidth();
    }

    uploadPhoto() {

        //debugger;
        this.fileUpload.nativeElement.click();
    }

    public fileChangeEvent(fileInput: any) {
        if (fileInput.target.files && fileInput.target.files[0]) {
            if (fileInput.target.files[0].type != "image/jpeg") {                
                ServiceLocator.MessageService.showError("Sadece .jpg ve .jpeg uzantılı görüntü yükleyebilirsiniz.");
                return;
            }

            var reader = new FileReader();

            reader.onload = (e: any) => {
                this.image.nativeElement.src = e.target.result;

                let data = e.target.result;

                this.showProcessButtons = true;
                let base64imgstr = data.substring(data.indexOf(',') + 1, data.length);
                this.uploadClicked = true;
                this.showStartCaptureButton = false;
                this.showUploadButton = false;
                this.OnPhotoCaptured.emit(base64imgstr);

            }

            reader.readAsDataURL(fileInput.target.files[0]);
        }
    }


}
