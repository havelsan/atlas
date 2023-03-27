import { Component, OnInit, ViewChild, Output, EventEmitter, Input } from '@angular/core';



import { environment } from 'app/environments/environment';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';


@Component({
    selector: 'filetobase64',
    templateUrl: 'filetobase64.html',
    styleUrls: []
})
export class FileToBase64 {
    @Output() onClose = new EventEmitter<any>();
    constructor(private httpService: NeHttpService
    ) {

    }
    base64Image: string;
    uploadImage() {
        let attribute = "[name='data[customOptions.image]']"
        jQuery(attribute).val(this.base64Image);
        this.triggerChangeEvent(attribute);
        this.onClose.emit();

    }
    fileChanged(e: any) {
        var file = e.srcElement.files[0];
        var reader = new FileReader();
        reader.readAsDataURL(file);

        reader.onload = () => {
            this.base64Image = reader.result.toString();
        }
    }
    triggerChangeEvent(str) {
        let urlField = jQuery(str);
        if (urlField.length > 0) {
            urlField[0].dispatchEvent(new Event('input', {
                bubbles: true,
                cancelable: true
            }));
        }
    }

}

