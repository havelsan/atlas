//$6A4829A2
import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode, DosyaTuru, EpisodeAction, SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
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
import { DeleteDocument_Input } from './LogisticDocumentUploadForm';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';


@Component({
    selector: 'LogisticPatientDocumentUploadForm',
    templateUrl: './LogisticPatientDocumentUploadForm.html',
    providers: [MessageService]
})
export class LogisticPatientDocumentUploadForm implements OnInit, OnDestroy, IModal {
    document: UploadedDocument = new UploadedDocument();
    docs: Array<DocumentGridModel> = new Array<DocumentGridModel>();
    totalSize: number = 0;
    Description: string;
    SelectedDocumentType: UploadedDocumentType;
    private _modalInfo: ModalInfo;
    public newDocumentTypes: Array<DosyaTuru> = new Array<DosyaTuru>();
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
            'caption': i18n("M10469", "Açıklama"),
            dataField: 'Explanation',
            allowSorting: true
        },
        {
            caption: i18n("M13301", "Döküman Tipi"),
            // cellTemplate: 'newDocumentTypes',
            //      width: 200,
            dataField: 'DocumentTypeName',
            allowSorting: true
        },
        {
            'caption': i18n("M10467", "Kabul No"),
            dataField: 'SubEpisode.ProtocolNo',
            allowSorting: true
        }
    ];

    public get documentTypes(): Array<EnumItem> {
        return UploadedDocumentType.Items;
    }

    async ngOnInit() {
    }

    async ngAfterViewInit(): Promise<void> {
        //await this.getActiveIDs(this.document.Episode);
        await this.FillDataSources();
    }

    refreshDataGrid() {
        this.dataGrid.instance.refresh();
    }

    documentType: any;
    DocumentTypeChanged(data) {
        this.documentType = data.selectedItem.code;
    }

    newDocType: DosyaTuru = new DosyaTuru();
    public onDocumentTypeChanged(data) {
        this.newDocType = data.selectedItem as DosyaTuru;
    }


    protected getEpisodeObjectId(episode: any): string {

        if (episode != null) {
            if (typeof episode === "string") {
                return episode;
            }
            else {
                return episode.episodeId;
            }
        }
        return null;
    }

    episodeActionID: string;
    episodeID: string;
    patientID: string;
    protected getActiveIDs(episode: any) {
        if (episode.episodeActionId != null)
            this.episodeActionID = episode.episodeActionId;
        if (episode.episodeId != null)
            this.episodeID = episode.episodeId;
        if (episode.patientId != null)
            this.patientID = episode.patientId;
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

                formData.append('EpisodeID', this.getEpisodeObjectId(this.episodeID));
                formData.append('File', blob);
                formData.append('FileName', doc.FileName);
                formData.append('Explanation', doc.Explanation);
                //formData.append('DocumentType', this.documentType.toString());
                formData.append('DocumentTypeID', doc.DocumentTypeID.toString());
                formData.append('EpisodeActionID', this.episodeActionID);
                formData.append('SubEpisodeID', doc.SubEpisode.ObjectID.toString());

                this.http.post('/api/PatientDocumentsService/Upload', formData, { headers: headers }).toPromise().then(result => {
                    const neResult = result as NeResult<Object>;
                    if (neResult.IsSuccess == true) {
                        this.messageService.showSuccess(i18n("M21515", "Seçilen dosyalar başarıyla eklenmiştir."));
                    }
                }).catch(error => {
                    console.log(error);
                });
            }

        }
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, null);
    }

    public setInputParam(value: LogisticDocumentUploadFormInput) {
        this.episodeID = value.episodeID;
        this.episodeActionID = value.episodeActionID;
        this.patientID = value.patientID;
        this.document.Episode = value.episode;
       // this.newDocType = this.newDocumentTypes.find(x => x.dosyaTuruKodu === 1000);
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
        if (this.newDocType !== undefined && this.Description !== undefined && this.document.FileName !== undefined) {
            let doc: DocumentGridModel = new DocumentGridModel();
            doc.File = this.document.File;
            doc.FileName = this.document.FileName;
            doc.IsNew = true;
            doc.DocumentTypeName = this.newDocType.dosyaTuruAdi;
            doc.DocumentTypeID = this.newDocType.ObjectID;
            //doc.DocumentType = this.documentType;
            doc.Explanation = this.Description;
            doc.ProtocolNo = this.subEpisode.ProtocolNo;
            doc.SubEpisode = this.subEpisode;

            this.docs.push(doc);
        }
        else if (this.newDocType == null)
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M18372", "Lütfen geçerli bir doküman tipi seçiniz!"), MessageIconEnum.WarningMessage);
        else if (this.Description == null) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M18360", "Lütfen açıklama giriniz!"), MessageIconEnum.WarningMessage);
        } else {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13272", "Dosya seçiniz!"), MessageIconEnum.WarningMessage);
        }
    }

    deleteDocument(data: any) {
        //this.docs.splice(this.docs.indexOf(data), 1);

        let apiUrl: string = '/api/PatientDocumentsService/DeleteDocument';
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

    async FillDataSources() {
        try {
            let body = "";
            let apiUrlForPASearchUrl: string;
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let input: DataInputModel = new DataInputModel();

            input.EpisodeID = this.episodeID;
            input.EpisodeActionID = this.episodeActionID;
            input.PatientID = this.patientID;

            apiUrlForPASearchUrl = '/api/PatientDocumentsService/LoadDataSources';

            await this.httpService.post<DataResultModel>(apiUrlForPASearchUrl, input).then(response => {
                let result = response;
                if (result) {
                    this.newDocumentTypes = result.DocumentTypes;
                    this.newDocType = this.newDocumentTypes.find(x => x.dosyaTuruKodu === 1000);
                    for( let doc of result.PatientDocuments){
                        if(doc.DocumentTypeID === this.newDocType.ObjectID){
                            this.docs.push(doc);
                        }
                    }
                    //this.docs = result.PatientDocuments;
                    this.subEpisode = result.SubEpisode;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    selectedDocs: Array<any> = new Array<DocumentGridModel>();
    anySelectedFiles: boolean = false;
    selectionDoc(data) {
        this.anySelectedFiles = true;
        this.selectedDocs = data.selectedRowsData;
    }


    downloadSelectedFiles() {
        for (let doc of this.selectedDocs) {
            let apiUrl: string = '/api/DocumentDownloadService/DownloadFile';
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
    public EpisodeID: string;
    public EpisodeActionID: string;
    public PatientID: string;
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
    public ObjectID: Guid;
    public FileName: string;
    public Explanation: string;
    public DocumentTypeName: string;
    public DocumentTypeID: Guid;
    public IsNew: boolean;
    public ProtocolNo: string;
    public File: object;
    public SubEpisode: SubEpisode;
}
export class LogisticDocumentUploadFormInput {
    public episodeActionID: string;
    public episodeID: string;
    public patientID: string;
    public episode: Episode;
}