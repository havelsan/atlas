import { Component, ElementRef, OnChanges, SimpleChanges, AfterViewInit, EventEmitter } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
    selector: "photo-capture",
    inputs: ['CaptureActionDisable',
        'CaptureActionText', 'isPhotoCaptured'],
    outputs: ['CapturedPhotoChange', 'CameraShowingStarted'],
    template: '\
        <div style="text-align:center;"> \
              <div *ngIf="isCamActive==true" style="position:relative;display:block;height:100%;width:100%;">\
                     <video [src]="sourceVideo" style= "max-width:100px; max-height:120px;">\
                     <canvas visible="false" id="photoCanvas" style= "max-width:100px; max-height:120px; border:1px solid #fff00;" > </canvas>\
                     </video> \
                     <div class="btn" (click)="capturePhoto()" style="border:0px; box-shadow:none; text-align:center; position:absolute;bottom:0px;right:0px;"><i class="fa fa-camera-retro" style="color:#00ACF1;"></i></div>\
              </div> \
              <div *ngIf="isCamActive==false">\
                     <dx-button text="" rtlEnabled="true" class="tabHeaderButton dx-button-active dx-button-semioval dx-button-main" icon="photo" (onClick) = "showCam()"> </dx-button>\
              </div>\
        </div>',
})
export class PhotoCapture  implements OnChanges, AfterViewInit {

    public sourceVideo: any;
    public sourceImage: any;
     public isCamActive: boolean;

    CapturedPhotoChange: EventEmitter<any>;
    CameraShowingStarted: EventEmitter<any>;

    constructor( private sanitizer: DomSanitizer, private element: ElementRef) {
        this.CameraShowingStarted = new EventEmitter<any>();
        this.CapturedPhotoChange = new EventEmitter<any>();
        this.isCamActive = true;
    }

    ngOnChanges(changes: SimpleChanges) {

    }

    capturePhoto(): void {

        try {
            const video = <any>document.getElementsByTagName('video')[0];
            const canvas = <any>document.getElementsByTagName('canvas')[0];

            if (video) {

                canvas.width = video.videoWidth;
                canvas.height = video.videoHeight;
                canvas.getContext('2d').drawImage(video, 0, 0);

                this.sourceImage = canvas.toDataURL('image/png');
                //this.isCamActive = false;
                this.CapturedPhotoChange.emit(this.sourceImage);
            }
        } catch (ex) {
            throw ex;
        }
    }

    private showCam(): void {
        // 1. Casting necessary because TypeScript doesn't
        // know object Type 'navigator';
        this.CameraShowingStarted.emit(null);
        this.isCamActive = true;
        let nav = <any>navigator;

        // 2. Adjust for all browsers
        nav.getUserMedia = nav.getUserMedia || nav.mozGetUserMedia || nav.webkitGetUserMedia;

        // 3. Trigger lifecycle tick (ugly, but works - see (better) Promise example below)
        //setTimeout(() => { }, 100);

        // 4. Get stream from webcam
        nav.getUserMedia(
            { video: true },
            (stream) => {
                let webcamUrl = URL.createObjectURL(stream);

                // 4a. Tell Angular the stream comes from a trusted source
                this.sourceVideo = this.sanitizer.bypassSecurityTrustUrl(webcamUrl);


                // 4b. Start video element to stream automatically from webcam.
                this.element.nativeElement.querySelector('video').autoplay = true;
            },
            (err) => console.log(err));


        // OR: other method, see http://xxxxxx.com/questions/32645724/angular2-cant-set-video-src-from-navigator-getusermedia for credits
        let promise = new Promise<string>((resolve, reject) => {
            nav.getUserMedia({ video: true }, (stream) => {
                resolve(stream);
            }, (err) => reject(err));
        }).then((stream) => {
            let webcamUrl = URL.createObjectURL(stream);
            this.sourceVideo = this.sanitizer.bypassSecurityTrustResourceUrl(webcamUrl);
            // for example: type logic here to send stream to your  server and (re)distribute to
            // other connected clients.
        }).catch((error) => {
            console.log(error);
        });
    }

    ngDoCheck() {

    }

    ngAfterViewInit() {
        this.showCam();
    }
}