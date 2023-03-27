import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { MessageService } from "Fw/Services/MessageService";

@Component({
    selector: 'atlas-import-definition-component',
    template: `
<div class="row">
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12">
                Lütfen İçe aktarılacak dosyayı seçiniz:
                <input type="file" (change)="onChange($event)">
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                &nbsp;
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                &nbsp;
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2">
            </div>
            <div class="col-lg-5">
                <dx-button type="success" style="width: 100%" text="İçe Alama İşlemi Dosya Gönder" (onClick)="sendFileForImport()"></dx-button>
            </div>
            <div class="col-lg-3">
                <dx-button type="success" style="width: 100%" text="Kapat" (onClick)="closeForm()"></dx-button>
            </div>
            <div class="col-lg-2">
            </div>
        </div>
    </div>
</div>
    `,
})
export class ImportDefinitionComponent implements OnInit {

    private uploadFileName: string;
    private fileContent: any;

    constructor(private http: HttpClient
        , private messageService: MessageService) {

    }

    public ngOnInit(): void {

    }

    public onChange($event): void {

        let that = this;
        const file: File = $event.target.files[0];
        const fileReader: FileReader = new FileReader();
        const fileType = $event.target.parentElement.id;
        fileReader.onloadend = (e) => {
            that.fileContent = fileReader.result;
            that.uploadFileName = file.name;
        };

        fileReader.readAsArrayBuffer(file);
    }

    public sendFileForImport(): void {
        const that = this;
        if (this.fileContent) {
            const token = sessionStorage.getItem('token');
            const headers = new HttpHeaders()
                .append('Authorization', `Bearer ${token}`);

            const blob = new Blob([new Uint8Array(this.fileContent)], { type: 'application/octet-binary' });
            const formData = new FormData();
            formData.append('FileName', this.uploadFileName);
            formData.append('FileContent', blob);

            this.http.post('/api/DefinitionObject/ImportDefinitionObject', formData, { headers: headers }).toPromise().then(r => {
                that.messageService.showInfo('Gönderilen dosya başarılı olarak içeriye aktarıldı');
            }).catch(error => {
                that.messageService.showError(`Dosya içeriye aktarılamadı: ${error}`);
            });
        }
    }

}