//$6A4829A2
import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode, DosyaTuru, EpisodeAction, SubEpisode, MaterialDocumentType } from 'NebulaClient/Model/AtlasClientModel';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';

import { EnumItem } from "NebulaClient/Mscorlib/EnumItem";
import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { IModalService } from "Fw/Services/IModalService";
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { UploadedDocument, UploadedDocumentType } from 'NebulaClient/Model/AtlasClientModel';
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DxDataGridComponent } from 'devextreme-angular';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { Headers, RequestOptions, ResponseContentType } from '@angular/http';
import { CommonHelper } from 'app/Helper/CommonHelper';
import { NeResult } from 'app/NebulaClient/Utils/NeResult';
import { OpenLogisticDocumentInputParams } from 'Modules/Merkezi_Yonetim_Sistemi/Eczane_Modulleri/Ilac_Vademecum_Tanimlari_Modulu/DrugDefinitionFormViewModel';


@Component({
    selector: 'LogisticDocumentUploadForm',
    templateUrl: './LogisticDocumentUploadForm.html',
    providers: [MessageService]
})
export class LogisticDocumentUploadForm implements OnInit, OnDestroy, IModal {
    document: UploadedDocument = new UploadedDocument();
    docs: Array<DocumentGridModel> = new Array<DocumentGridModel>();
    totalSize: number = 0;
    SelectedDocumentType: MaterialDocumentType;
    private _modalInfo: ModalInfo;
    public newDocumentTypes: Array<EnumItem> = MaterialDocumentType.Items;
    objectContextService: any;
    subEpisode: SubEpisode = new SubEpisode;


    constructor(private modalStateService: ModalStateService,
        private sideBarMenuService: ISidebarMenuService,
        protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private barcodePrintService: IBarcodePrintService,
        private http: HttpClient, private http2: AtlasHttpService) {


    }


    @ViewChild('DocumentColumns') dataGrid: DxDataGridComponent;


    public GridColumns = [
        {
            'caption': i18n("M13245", "Dosya Adı"),
            dataField: 'FileName',
            allowSorting: true,
        },
        {
            caption: 'Tarih',
            dataField: 'FileUpdateDate',
            dataType: "date",
            format: "shortDateShortTime",
            width: 160,
            allowEditing: false,
        },
        {
            caption: i18n("M13301", "Döküman Tipi"),
            dataField: 'MaterialDocumentType',
            lookup: { dataSource: this.newDocumentTypes, valueExpr: 'ordinal', displayExpr: 'description' },
            allowSorting: true
        }
    ];

    async ngOnInit() {
    }

    async ngAfterViewInit(): Promise<void> {
    }

    refreshDataGrid() {
        this.dataGrid.instance.refresh();
    }

    Upload() {

        for (let doc of this.docs) {
            if (doc.IsNew) {
                let token = sessionStorage.getItem('token');
                const headers = new HttpHeaders()
                    .append('Authorization', `Bearer ${token}`);

                let blb: any = doc.File;
                const blob = new Blob([new Uint8Array(blb)], { type: 'application/octet-binary' });
                const formData = new FormData();
                formData.append('File', blob);
                formData.append('FileName', doc.FileName);
                formData.append('Material', doc.Material);
                formData.append('DocumentType', doc.MaterialDocumentType.Value.toString());
                this.http.post('/api/LogisticDocumentsService/Upload', formData, { headers: headers }).toPromise().then(result => {
                    const neResult = result as NeResult<Object>;
                    if (neResult.IsSuccess == true) {
                        this.messageService.showSuccess(i18n("M21515", "Seçilen dosyalar başarıyla eklenmiştir."));
                    }
                }).catch(error => {
                    console.log(error);
                });
            }

        }
    }

    materialID: Guid;
    public setInputParam(value: any) {
        let inputParam: OpenLogisticDocumentInputParams = value as OpenLogisticDocumentInputParams
        this.materialID = inputParam.MaterialID;
        this.SelectedDocumentType = inputParam.DocumentType;
        this.docs = inputParam.OldDocuments;

    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }


    onChange($event) {
        let that = this;
        const file: File = $event.target.files[0];
        const fileReader: FileReader = new FileReader();
        const fileType = $event.target.parentElement.id;
        if (file.size > 10000000) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13544", "Eklediğiniz dosyaların boyutu 10 Mb'dan fazla olamaz!"), MessageIconEnum.WarningMessage);
            return;
        }
        fileReader.onloadend = (e) => {
            that.document.FileName = file.name,
                that.document.File = fileReader.result;
        };

        fileReader.readAsArrayBuffer(file);
    }

    addDocument() {
        if (this.document.FileName !== undefined) {
            let doc: DocumentGridModel = new DocumentGridModel();
            doc.File = this.document.File;
            doc.FileUpdateDate = new Date(Date.now());
            doc.IsNew = true;
            doc.FileName = this.document.FileName;
            doc.Material = this.materialID;
            doc.MaterialDocumentType = this.SelectedDocumentType;

            this.docs.push(doc);
        } else {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13272", "Dosya seçiniz!"), MessageIconEnum.WarningMessage);
        }
    }

    deleteDocument(data: any) {
        let apiUrl: string = '/api/LogisticDocumentsService/DeleteDocument';
        let params: DeleteDocument_Input = new DeleteDocument_Input();
        if (data.key.IsNew != true) {
            params.documentid = data.key.ObjectID;
            this.httpService.post<void>(apiUrl, params);
        }
        else {
            data.component.deleteRow();
        }

    }



    public sizeSum(fileSize: number) {
        this.totalSize += fileSize;
    }

    public ngOnDestroy(): void {

    }

    selectedDocs: Array<any> = new Array<DocumentGridModel>();
    anySelectedFiles: boolean = false;
    selectionDoc(data) {
        this.anySelectedFiles = true;
        this.selectedDocs = data.selectedRowsData;
    }


    downloadSelectedFiles() {
        for (let doc of this.selectedDocs) {
            let apiUrl: string = '/api/LogisticDownloadService/DownloadFile';
            let input = { id: doc.ObjectID };
            let headers = new Headers();
            headers.set('Content-Type', 'application/json');
            let options = new RequestOptions();
            options.headers = headers;
            options.responseType = ResponseContentType.Blob;

            this.http2.post(apiUrl, JSON.stringify(input), options).toPromise().then(
                (res) => {
                    const blob = new Blob([res.blob()], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });
                    CommonHelper.saveFile(res.blob(), doc.FileName);
                });
        }
        this.anySelectedFiles = true;
    }

}

export class DataInputModel {
    public MaterialID: Guid;
}

export class DataResultModel {
    @Type(() => DocumentGridModel)
    public PatientDocuments: Array<DocumentGridModel>;

    @Type(() => DosyaTuru)
    public DocumentTypes: Array<DosyaTuru>;

    @Type(() => SubEpisode)
    public SubEpisode: SubEpisode;

    @Type(() => DosyaTuru)
    public doc: DosyaTuru;
}

export class DocumentGridModel {
    public File: object;
    public FileName: string;
    public Material: any;
    public FileUpdateDate: Date;
    public IsNew: Boolean;
    public MaterialDocumentType: MaterialDocumentType;
    public ObjectID: Guid;
}

export class DeleteDocument_Input {
    public documentid: Guid;
}
