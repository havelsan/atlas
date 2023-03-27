//$6A4829A2
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

import { EnumItem } from "NebulaClient/Mscorlib/EnumItem";
import { IModal, ModalInfo } from "Fw/Models/ModalInfo";
import { IModalService } from "Fw/Services/IModalService";
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { CommonHelper } from 'app/Helper/CommonHelper';
import { UploadedDocument, UploadedDocumentType } from 'NebulaClient/Model/AtlasClientModel';
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';

@Component({
    selector: 'PatientDocumentDownloadForm',
    templateUrl: './PatientDocumentDownloadForm.html',
    providers: [MessageService]
})
export class PatientDocumentDownloadForm implements OnInit, OnDestroy, IModal {
    episode: Episode = new Episode();
    patientID: Guid = new Guid();
    private _modalInfo: ModalInfo;
    episodes: Array<any> = new Array<any>();
    docs: Array<UploadedDocument> = new Array<UploadedDocument>();

    constructor(private sideBarMenuService: ISidebarMenuService,
        protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private barcodePrintService: IBarcodePrintService,
        private http: AtlasHttpService) {


    }
    public get documentTypes(): Array<EnumItem> {
        return UploadedDocumentType.Items;
    }

    public DocumentGridColumns = [
        {
            'caption': i18n("M10469", "Açıklama"),
            dataField: 'Aciklama',
            allowSorting: true,
        },
        {
            caption: i18n("M13228", "Doküman Tipi"),
            dataField: i18n("M13227", "Dokumantipi"),
            lookup: { dataSource: this.documentTypes, valueExpr: 'code', displayExpr: 'description' },
        },
        {
            'caption': i18n("M13245", "Dosya Adı"),
            dataField: 'Dosyaadi',
            allowSorting: true
        },
        {
            'caption': i18n("M30605", "Eklenme Tarihi"),
            dataField: 'Eklenmetarihi',
            allowSorting: true,
            dataType: 'date',
            format: 'dd/MM/yyyy',
        },
        {
            'caption': i18n("M30606", "Ekleyen Kullanıcı"),
            dataField: 'Ekleyenkullanici',
            allowSorting: true
        }
    ];
    public EpisodeGridColumns = [

        {
            'caption': i18n("M12048", "Branş"),
            dataField: 'Brans',
            allowSorting: true
        },
        {
            'caption': i18n("M17034", "Kabul Tarihi"),
            dataField: 'Date',
            allowSorting: true,
            dataType: 'date',
            format: 'dd/MM/yyyy',
        },
    ];

    public setInputParam(value: any) {
        this.patientID = value;
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    getPatientDocuments(data) {
        let apiUrlForInvoiceTerms: string = '/api/PatientDocumentsService/GetPatientDocuments';
        let params: GetEpisodeDocuments_Input = new GetEpisodeDocuments_Input();
        params.episodeID = data.key.Episodeid;
        this.httpService.post<any>(apiUrlForInvoiceTerms, params).then(
            x => {
                this.docs = x;
            });
    }

    getPatientEpisodes() {
        let apiUrlForInvoiceTerms: string = '/api/PatientDocumentsService/GetPatientEpisodes';
        let params: GetPatientEpisodes_Input = new GetPatientEpisodes_Input();
        params.patientID = this.patientID;
        this.httpService.post<any>(apiUrlForInvoiceTerms, params).then(
            x => {
                this.episodes = x;
            });
    }

    selectedDocs: Array<any> = new Array<UploadedDocument>();
    selectionDoc(data) {
        this.selectedDocs = data.selectedRowsData;
    }

    deleteDocument(data) {

        let apiUrl: string = '/api/PatientDocumentsService/DeleteDocument';
        let params: DeleteDocument_Input = new DeleteDocument_Input();
        params.documentid = data.key.Documentid;
        this.httpService.post<void>(apiUrl, params);
    }

    downloadSelectedFiles() {
        for (let doc of this.selectedDocs) {
            let apiUrl: string = '/api/DocumentDownloadService/DownloadFile';
            let input = { id: doc.Documentid };
            let headers = new Headers();
            headers.set('Content-Type', 'application/json');
            let options = new RequestOptions();
            options.headers = headers;
            options.responseType = ResponseContentType.Blob;

            this.http.post(apiUrl, JSON.stringify(input), options).toPromise().then(
                (res) => {
                    const blob = new Blob([res.blob()], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });
                    CommonHelper.saveFile(res.blob(), doc.Dosyaadi);
                });
        }
    }



    async ngOnInit() {
        this.getPatientEpisodes();
     //   this.getPatientDocuments();
    }

    public ngOnDestroy(): void {

    }


}

export class GetEpisodeDocuments_Input {
    public episodeID: Guid;
}

export class DeleteDocument_Input {
    public documentid: Guid;
}

export class GetDocumentFile_Input {
    public documentid: Guid;
}

export class GetPatientEpisodes_Input {
    public patientID: Guid;
}



