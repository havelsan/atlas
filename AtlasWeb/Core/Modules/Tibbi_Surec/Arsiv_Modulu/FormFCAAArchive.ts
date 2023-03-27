//$ED65669E
import { Component, OnInit, NgZone } from '@angular/core';
import { FormFCAAArchiveViewModel } from './FormFCAAArchiveViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { FileCreationAndAnalysis } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientFolder } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ResBuilding } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { IModal, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
@Component({
    selector: 'FormFCAAArchive',
    templateUrl: './FormFCAAArchive.html',
    providers: [MessageService]
})
export class FormFCAAArchive extends EpisodeActionForm implements OnInit, IModal {
    chkAdliVaka: TTVisual.ITTCheckBox;
    chkHMHastaYakini: TTVisual.ITTCheckBox;
    EpisodeFolderID: TTVisual.ITTTextBox;
    EpisodeID: TTVisual.ITTTextBoxColumn;
    File: TTVisual.ITTListBoxColumn;
    FolderContents: TTVisual.ITTGrid;
    FolderContentStatus: TTVisual.ITTCheckBoxColumn;
    FolderInformation: TTVisual.ITTTextBox;
    GridEpisodeFolderID: TTVisual.ITTTextBoxColumn;
    InArchive: TTVisual.ITTCheckBox;
    InInCompleteArea: TTVisual.ITTCheckBox;
    labelEpisodeFolderID: TTVisual.ITTLabel;
    labelFile: TTVisual.ITTLabel;
    labelFileContent: TTVisual.ITTLabel;
    labelFolderInformation: TTVisual.ITTLabel;
    labelPatientEpisodeDetails: TTVisual.ITTLabel;
    labelPatientFolderID: TTVisual.ITTLabel;
    LabelRequestDate: TTVisual.ITTLabel;
    labelRow: TTVisual.ITTLabel;
    labelShelf: TTVisual.ITTLabel;
    lblBuilding: TTVisual.ITTLabel;
    listBoxBuilding: TTVisual.ITTObjectListBox;
    OpeningDate: TTVisual.ITTDateTimePickerColumn;
    PatientEpisodeDetails: TTVisual.ITTGrid;
    PatientFolderID: TTVisual.ITTTextBox;
    ReasonForAdmission: TTVisual.ITTListBoxColumn;
    RequestDate: TTVisual.ITTDateTimePicker;
    Row: TTVisual.ITTTextBox;
    Shelf: TTVisual.ITTTextBox;
    ttcheckbox10: TTVisual.ITTCheckBox;
    ttcheckbox11: TTVisual.ITTCheckBox;
    ttcheckbox12: TTVisual.ITTCheckBox;
    ttcheckbox13: TTVisual.ITTCheckBox;
    ttcheckbox14: TTVisual.ITTCheckBox;
    ttcheckbox15: TTVisual.ITTCheckBox;
    ttcheckbox16: TTVisual.ITTCheckBox;
    ttcheckbox17: TTVisual.ITTCheckBox;
    ttcheckbox18: TTVisual.ITTCheckBox;
    ttcheckbox19: TTVisual.ITTCheckBox;
    ttcheckbox2: TTVisual.ITTCheckBox;
    ttcheckbox20: TTVisual.ITTCheckBox;
    ttcheckbox3: TTVisual.ITTCheckBox;
    ttcheckbox4: TTVisual.ITTCheckBox;
    ttcheckbox5: TTVisual.ITTCheckBox;
    ttcheckbox6: TTVisual.ITTCheckBox;
    ttcheckbox7: TTVisual.ITTCheckBox;
    ttcheckbox8: TTVisual.ITTCheckBox;
    ttcheckbox9: TTVisual.ITTCheckBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttgroupbox3: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    tttextbox3: TTVisual.ITTTextBox;
    tttextboxOnlyYear: TTVisual.ITTTextBox;
    txtRoom: TTVisual.ITTTextBox;
    VolumeNo: TTVisual.ITTTextBoxColumn;
    labelResArchiveRoom: TTVisual.ITTLabel;
    ResArchiveRoom: TTVisual.ITTObjectListBox;
    labelResCabinet: TTVisual.ITTLabel;
    ResCabinet: TTVisual.ITTObjectListBox;
    labelResShelf: TTVisual.ITTLabel;
    ResShelf: TTVisual.ITTObjectListBox;


    public FolderContentsColumns = [];
    public PatientEpisodeDetailsColumns = [];
    public formFCAAArchiveViewModel: FormFCAAArchiveViewModel = new FormFCAAArchiveViewModel();
    public get _FileCreationAndAnalysis(): FileCreationAndAnalysis {
        return this._TTObject as FileCreationAndAnalysis;
    }
    private FormFCAAArchive_DocumentUrl: string = '/api/FileCreationAndAnalysisService/FormFCAAArchive';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private modalStateService: ModalStateService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.FormFCAAArchive_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }



    // ***** Method declarations start *****

    //private async PatientEpisodeDetails_SelectionChanged(): Promise<void> {
    //    if (this.PatientEpisodeDetails.CurrentCell.RowIndex < this._FileCreationAndAnalysis.Episode.Patient.Episodes.length) {
    //        let selectedEpisode: Episode = this._FileCreationAndAnalysis.Episode.Patient.Episodes[this.PatientEpisodeDetails.CurrentCell.RowIndex];
    //        this._FileCreationAndAnalysis.SelectedEpisode = selectedEpisode;
    //    }
    //}
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        //super.PostScript(transDef);
    }
    protected async PreScript(): Promise<void> {

        super.PreScript();
        //if (this._FileCreationAndAnalysis.Episode.Patient.PatientFolder !== null) {
        //    this.PatientFolderID.Text = this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.PatientFolderID.Value.toString();
        //}
    }

    protected async ClientSidePreScript(): Promise<void> {
        this.DropStateButton(FileCreationAndAnalysis.FileCreationAndAnalysisStates.Request); 
    }



    public setInputParam(value: Object) {
        this._ViewModel = value as FileCreationAndAnalysis;

    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public selectClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, "");
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new FileCreationAndAnalysis();
        this.formFCAAArchiveViewModel = new FormFCAAArchiveViewModel();
        this._ViewModel = this.formFCAAArchiveViewModel;
        this.formFCAAArchiveViewModel._FileCreationAndAnalysis = this._TTObject as FileCreationAndAnalysis;
        this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode = new Episode();
        this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode.Patient = new Patient();
        this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode.Patient.PatientFolder = new PatientFolder();
        this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode.Patient.Episodes = new Array<Episode>();
        this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode.Patient.PatientFolder.Building = new ResBuilding();
    }

    protected loadViewModel() {
        let that = this;

        that.formFCAAArchiveViewModel = this._ViewModel as FormFCAAArchiveViewModel;
        that._TTObject = this.formFCAAArchiveViewModel._FileCreationAndAnalysis;
        if (this.formFCAAArchiveViewModel == null)
            this.formFCAAArchiveViewModel = new FormFCAAArchiveViewModel();
        if (this.formFCAAArchiveViewModel._FileCreationAndAnalysis == null)
            this.formFCAAArchiveViewModel._FileCreationAndAnalysis = new FileCreationAndAnalysis();

        let roomObjectID = that.formFCAAArchiveViewModel._FileCreationAndAnalysis["ResArchiveRoom"];
        if (roomObjectID != null && (typeof roomObjectID === "string")) {
            let room = that.formFCAAArchiveViewModel.ResArchiveRooms.find(o => o.ObjectID.toString() === roomObjectID.toString());
            if (room) {
                that.formFCAAArchiveViewModel._FileCreationAndAnalysis.ResArchiveRoom = room;
            }
        }

            let episodeObjectID = that.formFCAAArchiveViewModel._FileCreationAndAnalysis["Episode"];
            if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
                let episode = that.formFCAAArchiveViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                if (episode) {
                    that.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode = episode;
                }
                if (episode != null) {
                    let patientObjectID = episode["Patient"];
                    if (patientObjectID != null && (typeof patientObjectID === "string")) {
                        let patient = that.formFCAAArchiveViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                        if (patient) {
                            episode.Patient = patient;
                        }


                        if (patient != null) {
                            let patientFolderObjectID = patient["PatientFolder"];
                            if (patientFolderObjectID != null && (typeof patientFolderObjectID === "string")) {
                                let patientFolder = that.formFCAAArchiveViewModel.PatientFolders.find(o => o.ObjectID.toString() === patientFolderObjectID.toString());
                                if (patientFolder) {
                                    patient.PatientFolder = patientFolder;
                                }


                                if (patientFolder != null) {
                                    let buildingObjectID = patientFolder["Building"];
                                    if (buildingObjectID != null && (typeof buildingObjectID === "string")) {
                                        let building = that.formFCAAArchiveViewModel.ResBuildings.find(o => o.ObjectID.toString() === buildingObjectID.toString());
                                        if (building) {
                                            patientFolder.Building = building;
                                        }
                                    }

                                    let cabinetObjectID = patientFolder["ResCabinet"];
                                    if (cabinetObjectID != null && (typeof cabinetObjectID === "string")) {
                                        let cabinet = that.formFCAAArchiveViewModel.ResCabinet.find(o => o.ObjectID.toString() === cabinetObjectID.toString());
                                        if (cabinet) {
                                            patientFolder.ResCabinet = cabinet;
                                        }
                                    }

                                    let shelfObjectID = patientFolder["ResShelf"];
                                    if (shelfObjectID != null && (typeof shelfObjectID === "string")) {
                                        let shelf = that.formFCAAArchiveViewModel.ResShelves.find(o => o.ObjectID.toString() === shelfObjectID.toString());
                                        if (shelf) {
                                            patientFolder.ResShelf = shelf;
                                        }
                                    }

                                }
                            }
                        }

                        // Manule FolderContent StarterEpisodeFolders eşleştirme

                        for (let detailItem of that.formFCAAArchiveViewModel.FolderContentsGridList) {
                            if (that.formFCAAArchiveViewModel.StarterEpisodeFolder) {
                                detailItem.EpisodeFolder = that.formFCAAArchiveViewModel.StarterEpisodeFolder;
                            }
                            let fileObjectID = detailItem["File"];
                            if (fileObjectID != null && (typeof fileObjectID === "string")) {
                                let file = that.formFCAAArchiveViewModel.PatientFolderContentDefinitions.find(o => o.ObjectID.toString() === fileObjectID.toString());
                                if (file) {
                                    detailItem.File = file;
                                }
                            }
                        }


                    }

                }
            }
        }

    public useManuelArchiveNo: boolean;

    async ngOnInit() {
        let that = this;

        let systemParameter: string = (await SystemParameterService.GetParameterValue('MANUELARSIVNUMARASIKULLAN', 'FALSE'));
        if (systemParameter === 'TRUE') {
            this.useManuelArchiveNo = true;
        }
        else {
            this.useManuelArchiveNo = false;
        }

        await this.load(FormFCAAArchiveViewModel);

    }


    public onchkAdliVakaChanged(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.AdliVaka != event) {
                this._FileCreationAndAnalysis.AdliVaka = event;
            }
        }
    }

    //FolderContents_CellValueChangedEmitted(data: any) {
    //    if (data && this.FolderContents_CellValueChanged && data.Row && data.Column) {
    //        this.FolderContents.CurrentCell =
    //            {
    //                OwningRow: data.Row,
    //                OwningColumn: data.Column
    //            };
    //        this.FolderContents_CellValueChanged(data.RowIndex, data.ColIndex);
    //    }
    //}

    //private async FolderContents_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
    //    let count: number = 0;
    //    if (this.FolderContents.CurrentCell.OwningColumn.DataMember === 'FILE') {
    //        if (this.FolderContents.CurrentCell.Value !== null) {
    //            for (let fc of this._FileCreationAndAnalysis.Episode.EpisodeFolder.FolderContents) {
    //                if (this.FolderContents.CurrentCell.RowIndex !== count) {
    //                    if (fc.File.ObjectID.toString() === this.FolderContents.CurrentCell.Value.toString()) {
    //                        //throw new Exception();
    //                       // TTVisual.InfoBox.Show('Cilt İçeriği listesinde mevcut olan ' + fc.File.FileName.toString() + ' belgesini seçtiniz. Listede her belgeden en fazla bir adet bulunabilir. ', MessageIconEnum.ErrorMessage);
    //                    }
    //                }
    //                count++;
    //            }
    //        }
    //    }
    //}

    public onchkHMHastaYakiniChanged(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HMHASTAYAKINI != event) {
                this._FileCreationAndAnalysis.HMHASTAYAKINI = event;
            }
        }
    }

    public onEpisodeFolderIDChanged(event): void {
        if (event != null) {
            if (this.formFCAAArchiveViewModel != null &&
                this.formFCAAArchiveViewModel.StarterEpisodeFolder != null) {
                this.formFCAAArchiveViewModel.StarterEpisodeFolder.EpisodeFolderID = event;
            }
        }
    }

    public onFolderInformationChanged(event): void {
        if (event != null) {
            if (this.formFCAAArchiveViewModel != null &&
                this.formFCAAArchiveViewModel.StarterEpisodeFolder != null) {
                this.formFCAAArchiveViewModel.StarterEpisodeFolder.FolderInformation = event;
            }
        }
    }

    public onInArchiveChanged(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.InArchive != event) {
                this._FileCreationAndAnalysis.InArchive = event;
            }
        }
    }

    public onManuelArchiveNoChanged(event): void {
        if (event != null) {
            if (this.formFCAAArchiveViewModel != null &&
                this.formFCAAArchiveViewModel.StarterEpisodeFolder != null) {
                this.formFCAAArchiveViewModel.StarterEpisodeFolder.ManuelArchiveNo = event;
            }
        }
    }


    public onInInCompleteAreaChanged(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.InIncompleteArea != event) {
                this._FileCreationAndAnalysis.InIncompleteArea = event;
            }
        }
    }

    public onlistBoxBuildingChanged(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null &&
                this._FileCreationAndAnalysis.Episode != null &&
                this._FileCreationAndAnalysis.Episode.Patient != null &&
                this._FileCreationAndAnalysis.Episode.Patient.PatientFolder != null && this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.Building != event) {
                this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.Building = event;
                this.ResArchiveRoom.ListFilterExpression = " THIS.RESBUILDING.OBJECTID = '" + event.ObjectID.toString() + "'";

            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.RequestDate != event) {
                this._FileCreationAndAnalysis.RequestDate = event;
            }
        }
    }

    public onRowChanged(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null &&
                this._FileCreationAndAnalysis.Episode != null &&
                this._FileCreationAndAnalysis.Episode.Patient != null &&
                this._FileCreationAndAnalysis.Episode.Patient.PatientFolder != null && this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.Row != event) {
                this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.Row = event;
            }
        }
    }

    public onShelfChanged(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null &&
                this._FileCreationAndAnalysis.Episode != null &&
                this._FileCreationAndAnalysis.Episode.Patient != null &&
                this._FileCreationAndAnalysis.Episode.Patient.PatientFolder != null && this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.Shelf != event) {
                this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.Shelf = event;
            }
        }
    }

    public onttcheckbox10Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKANESTEZI != event) {
                this._FileCreationAndAnalysis.HKANESTEZI = event;
            }
        }
    }

    public onttcheckbox11Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKONAM != event) {
                this._FileCreationAndAnalysis.HKONAM = event;
            }
        }
    }

    public onttcheckbox12Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKCERTARONFORM != event) {
                this._FileCreationAndAnalysis.HKCERTARONFORM = event;
            }
        }
    }

    public onttcheckbox13Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKTABHASTBIL != event) {
                this._FileCreationAndAnalysis.HKTABHASTBIL = event;
            }
        }
    }

    public onttcheckbox14Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKSAGKURRAP != event) {
                this._FileCreationAndAnalysis.HKSAGKURRAP = event;
            }
        }
    }

    public onttcheckbox15Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKEPIKRIZ != event) {
                this._FileCreationAndAnalysis.HKEPIKRIZ = event;
            }
        }
    }

    public onttcheckbox16Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKHASTTAB != event) {
                this._FileCreationAndAnalysis.HKHASTTAB = event;
            }
        }
    }

    public onttcheckbox17Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKDUSRISOL != event) {
                this._FileCreationAndAnalysis.HKDUSRISOL = event;
            }
        }
    }

    public onttcheckbox18Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKGUCCERKONT != event) {
                this._FileCreationAndAnalysis.HKGUCCERKONT = event;
            }
        }
    }

    public onttcheckbox19Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKDIGER != event) {
                this._FileCreationAndAnalysis.HKDIGER = event;
            }
        }
    }

    public onttcheckbox20Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.SEKHASGIRKAG != event) {
                this._FileCreationAndAnalysis.SEKHASGIRKAG = event;
            }
        }
    }

    public onttcheckbox2Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HMHEMSHIZ != event) {
                this._FileCreationAndAnalysis.HMHEMSHIZ = event;
            }
        }
    }

    public onttcheckbox3Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HMHASTYAKFORM != event) {
                this._FileCreationAndAnalysis.HMHASTYAKFORM = event;
            }
        }
    }

    public onttcheckbox4Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HMHEMSBAKPL != event) {
                this._FileCreationAndAnalysis.HMHEMSBAKPL = event;
            }
        }
    }

    public onttcheckbox5Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HMSIVIZFORM != event) {
                this._FileCreationAndAnalysis.HMSIVIZFORM = event;
            }
        }
    }

    public onttcheckbox6Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HMHEMGOZFORM != event) {
                this._FileCreationAndAnalysis.HMHEMGOZFORM = event;
            }
        }
    }

    public onttcheckbox7Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HMDIGER != event) {
                this._FileCreationAndAnalysis.HMDIGER = event;
            }
        }
    }

    public onttcheckbox8Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKMESANFORM != event) {
                this._FileCreationAndAnalysis.HKMESANFORM = event;
            }
        }
    }

    public onttcheckbox9Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKGUNMUSKAG != event) {
                this._FileCreationAndAnalysis.HKGUNMUSKAG = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HMACIKLAMA != event) {
                this._FileCreationAndAnalysis.HMACIKLAMA = event;
            }
        }
    }

    public ontttextbox2Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.HKACIKLAMA != event) {
                this._FileCreationAndAnalysis.HKACIKLAMA = event;
            }
        }
    }

    public ontttextbox3Changed(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.SEKACIKLAMA != event) {
                this._FileCreationAndAnalysis.SEKACIKLAMA = event;
            }
        }
    }

    public ontttextboxOnlyYearChanged(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.OnlyYear != event) {
                this._FileCreationAndAnalysis.OnlyYear = event;
            }
        }
    }

    public ontxtRoomChanged(event): void {
        if (event != null) {
            if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.Room != event) {
                this._FileCreationAndAnalysis.Room = event;
            }
        }
    }

    public async setStateToTransition(saveInfo: FormSaveInfo) {

        if (this.useManuelArchiveNo == true && this.formFCAAArchiveViewModel.StarterEpisodeFolder.ManuelArchiveNo == null
            && saveInfo.transDef.ToStateDefID.toString().Equals("4d0f9aa5-5ccd-4ad3-bc0c-b36367ed87e3")) {
            ServiceLocator.MessageService.showError("Arşiv Numarası alanı boş olamaz");
            return;
        }
        super.setStateToTransition(saveInfo);
    }

    public onResArchiveRoomChanged(event): void {
        if (this._FileCreationAndAnalysis != null && this._FileCreationAndAnalysis.ResArchiveRoom != event) {
            this._FileCreationAndAnalysis.ResArchiveRoom = event;
            this.ResCabinet.ListFilterExpression = " THIS.RESARCHIVEROOM.OBJECTID = '" + event.ObjectID.toString() + "'";

        }
    }
    public onResCabinetChanged(event): void {
        if (this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode.Patient.PatientFolder != null && this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode.Patient.PatientFolder.ResCabinet != event) {
            this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode.Patient.PatientFolder.ResCabinet = event;
            this.ResShelf.ListFilterExpression = " THIS.RESCABINET.OBJECTID = '" + event.ObjectID.toString() + "'";

        }
    }
    public onResShelfChanged(event): void {
        if (this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode.Patient.PatientFolder != null && this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode.Patient.PatientFolder.ResShelf != event) {
            this.formFCAAArchiveViewModel._FileCreationAndAnalysis.Episode.Patient.PatientFolder.ResShelf = event;
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.Shelf, "Text", this.__ttObject, "Episode.Patient.PatientFolder.Shelf");
        redirectProperty(this.txtRoom, "Text", this.__ttObject, "Room");
        redirectProperty(this.tttextboxOnlyYear, "Text", this.__ttObject, "OnlyYear");
        redirectProperty(this.chkAdliVaka, "Value", this.__ttObject, "AdliVaka");
        redirectProperty(this.InArchive, "Value", this.__ttObject, "InArchive");
        redirectProperty(this.InInCompleteArea, "Value", this.__ttObject, "InIncompleteArea");
        redirectProperty(this.chkHMHastaYakini, "Value", this.__ttObject, "HMHASTAYAKINI");
        redirectProperty(this.ttcheckbox2, "Value", this.__ttObject, "HMHEMSHIZ");
        redirectProperty(this.ttcheckbox4, "Value", this.__ttObject, "HMHEMSBAKPL");
        redirectProperty(this.ttcheckbox5, "Value", this.__ttObject, "HMSIVIZFORM");
        redirectProperty(this.ttcheckbox6, "Value", this.__ttObject, "HMHEMGOZFORM");
        redirectProperty(this.ttcheckbox7, "Value", this.__ttObject, "HMDIGER");
        redirectProperty(this.ttcheckbox3, "Value", this.__ttObject, "HMHASTYAKFORM");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "HMACIKLAMA");
        redirectProperty(this.ttcheckbox8, "Value", this.__ttObject, "HKMESANFORM");
        redirectProperty(this.ttcheckbox9, "Value", this.__ttObject, "HKGUNMUSKAG");
        redirectProperty(this.ttcheckbox10, "Value", this.__ttObject, "HKANESTEZI");
        redirectProperty(this.ttcheckbox11, "Value", this.__ttObject, "HKONAM");
        redirectProperty(this.ttcheckbox12, "Value", this.__ttObject, "HKCERTARONFORM");
        redirectProperty(this.ttcheckbox14, "Value", this.__ttObject, "HKSAGKURRAP");
        redirectProperty(this.ttcheckbox15, "Value", this.__ttObject, "HKEPIKRIZ");
        redirectProperty(this.ttcheckbox16, "Value", this.__ttObject, "HKHASTTAB");
        redirectProperty(this.ttcheckbox17, "Value", this.__ttObject, "HKDUSRISOL");
        redirectProperty(this.ttcheckbox18, "Value", this.__ttObject, "HKGUCCERKONT");
        redirectProperty(this.ttcheckbox19, "Value", this.__ttObject, "HKDIGER");
        redirectProperty(this.ttcheckbox13, "Value", this.__ttObject, "HKTABHASTBIL");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "HKACIKLAMA");
        redirectProperty(this.ttcheckbox20, "Value", this.__ttObject, "SEKHASGIRKAG");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "SEKACIKLAMA");
        redirectProperty(this.Row, "Text", this.__ttObject, "Episode.Patient.PatientFolder.Row");
    }

    public initFormControls(): void {
        this.listBoxBuilding = new TTVisual.TTObjectListBox();
        this.listBoxBuilding.ListDefName = "BuildinglistDefinition";
        this.listBoxBuilding.Name = "listBoxBuilding";
        this.listBoxBuilding.TabIndex = 66;


        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M15649", "Hemşire Kaynaklı");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 65;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M10469", "Açıklama");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 66;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Multiline = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 65;

        this.chkHMHastaYakini = new TTVisual.TTCheckBox();
        this.chkHMHastaYakini.Value = false;
        this.chkHMHastaYakini.Title = i18n("M15329", "Hasta ve Yakınının Bölüm Uyum Eğitimi");
        this.chkHMHastaYakini.Name = "chkHMHastaYakini";
        this.chkHMHastaYakini.TabIndex = 64;

        this.ttcheckbox2 = new TTVisual.TTCheckBox();
        this.ttcheckbox2.Value = false;
        this.ttcheckbox2.Title = i18n("M15687", "Hemşirelik Hizmetleri Eğitim Formu");
        this.ttcheckbox2.Name = "ttcheckbox2";
        this.ttcheckbox2.TabIndex = 64;

        this.ttcheckbox3 = new TTVisual.TTCheckBox();
        this.ttcheckbox3.Value = false;
        this.ttcheckbox3.Title = i18n("M15327", "Hasta ve Hasta Yakını Bilgilendirme Formu");
        this.ttcheckbox3.Name = "ttcheckbox3";
        this.ttcheckbox3.TabIndex = 64;

        this.ttcheckbox4 = new TTVisual.TTCheckBox();
        this.ttcheckbox4.Value = false;
        this.ttcheckbox4.Title = i18n("M15669", "Hemşirelik Bakım Planı");
        this.ttcheckbox4.Name = "ttcheckbox4";
        this.ttcheckbox4.TabIndex = 64;

        this.ttcheckbox5 = new TTVisual.TTCheckBox();
        this.ttcheckbox5.Value = false;
        this.ttcheckbox5.Title = i18n("M21830", "Sıvı İzlem Formu");
        this.ttcheckbox5.Name = "ttcheckbox5";
        this.ttcheckbox5.TabIndex = 64;

        this.ttcheckbox6 = new TTVisual.TTCheckBox();
        this.ttcheckbox6.Value = false;
        this.ttcheckbox6.Title = i18n("M15644", "Hemşire Gözlem Formu");
        this.ttcheckbox6.Name = "ttcheckbox6";
        this.ttcheckbox6.TabIndex = 64;

        this.ttcheckbox7 = new TTVisual.TTCheckBox();
        this.ttcheckbox7.Value = false;
        this.ttcheckbox7.Title = i18n("M12780", "Diğer");
        this.ttcheckbox7.Name = "ttcheckbox7";
        this.ttcheckbox7.TabIndex = 64;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M24661", "Yıl");
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 60;

        this.tttextboxOnlyYear = new TTVisual.TTTextBox();
        this.tttextboxOnlyYear.Name = "tttextboxOnlyYear";
        this.tttextboxOnlyYear.TabIndex = 5;

        this.Shelf = new TTVisual.TTTextBox();
        this.Shelf.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Shelf.Name = "Shelf";
        this.Shelf.TabIndex = 3;

        this.EpisodeFolderID = new TTVisual.TTTextBox();
        this.EpisodeFolderID.BackColor = "#F0F0F0";
        this.EpisodeFolderID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.EpisodeFolderID.Name = "EpisodeFolderID";
        this.EpisodeFolderID.TabIndex = 2;

        this.FolderInformation = new TTVisual.TTTextBox();
        this.FolderInformation.Multiline = true;
        this.FolderInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FolderInformation.Name = "FolderInformation";
        this.FolderInformation.TabIndex = 7;

        this.Row = new TTVisual.TTTextBox();
        this.Row.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Row.Name = "Row";
        this.Row.TabIndex = 4;

        this.PatientFolderID = new TTVisual.TTTextBox();
        this.PatientFolderID.BackColor = "#F0F0F0";
        this.PatientFolderID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientFolderID.Name = "PatientFolderID";
        this.PatientFolderID.TabIndex = 1;
        this.PatientFolderID.ReadOnly = true;

        this.txtRoom = new TTVisual.TTTextBox();
        this.txtRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.txtRoom.Name = "txtRoom";
        this.txtRoom.TabIndex = 4;

        this.LabelRequestDate = new TTVisual.TTLabel();
        this.LabelRequestDate.Text = i18n("M16650", "İstek Tarihi");
        this.LabelRequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelRequestDate.ForeColor = "#000000";
        this.LabelRequestDate.Name = "LabelRequestDate";
        this.LabelRequestDate.TabIndex = 57;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 0;

        this.chkAdliVaka = new TTVisual.TTCheckBox();
        this.chkAdliVaka.Value = false;
        this.chkAdliVaka.Title = i18n("M10541", "Adli Vaka");
        this.chkAdliVaka.Name = "chkAdliVaka";
        this.chkAdliVaka.TabIndex = 62;

        this.labelEpisodeFolderID = new TTVisual.TTLabel();
        this.labelEpisodeFolderID.Text = i18n("M12254", "Cilt Numarası");
        this.labelEpisodeFolderID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelEpisodeFolderID.ForeColor = "#000000";
        this.labelEpisodeFolderID.Name = "labelEpisodeFolderID";
        this.labelEpisodeFolderID.TabIndex = 42;

        this.labelPatientEpisodeDetails = new TTVisual.TTLabel();
        this.labelPatientEpisodeDetails.Text = i18n("M15501", "Hastanın Vakaları");
        this.labelPatientEpisodeDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPatientEpisodeDetails.ForeColor = "#000000";
        this.labelPatientEpisodeDetails.Name = "labelPatientEpisodeDetails";
        this.labelPatientEpisodeDetails.TabIndex = 37;

        this.labelRow = new TTVisual.TTLabel();
        this.labelRow.Text = "Sıra";
        this.labelRow.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRow.ForeColor = "#000000";
        this.labelRow.Name = "labelRow";
        this.labelRow.TabIndex = 56;

        this.labelFolderInformation = new TTVisual.TTLabel();
        this.labelFolderInformation.Text = i18n("M13250", "Dosya Bilgisi");
        this.labelFolderInformation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelFolderInformation.ForeColor = "#000000";
        this.labelFolderInformation.Name = "labelFolderInformation";
        this.labelFolderInformation.TabIndex = 19;

        this.labelPatientFolderID = new TTVisual.TTLabel();
        this.labelPatientFolderID.Text = i18n("M13268", "Dosya Numarası");
        this.labelPatientFolderID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPatientFolderID.ForeColor = "#000000";
        this.labelPatientFolderID.Name = "labelPatientFolderID";
        this.labelPatientFolderID.TabIndex = 52;

        this.FolderContents = new TTVisual.TTGrid();
        this.FolderContents.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FolderContents.Text = i18n("M15219", "Hasta Giriş Kağıdı");
        this.FolderContents.Name = "FolderContents";
        this.FolderContents.TabIndex = 8;
        this.FolderContents.Height = "150px";

        this.GridEpisodeFolderID = new TTVisual.TTTextBoxColumn();
        this.GridEpisodeFolderID.DataMember = "EpisodeFolderID";
        this.GridEpisodeFolderID.DisplayIndex = 0;
        this.GridEpisodeFolderID.HeaderText = i18n("M12254", "Cilt Numarası");
        this.GridEpisodeFolderID.Name = "GridEpisodeFolderID";
        this.GridEpisodeFolderID.ReadOnly = true;
        this.GridEpisodeFolderID.Width = 200;

        this.File = new TTVisual.TTListBoxColumn();
        this.File.ListDefName = "PatientFolderContentListDefinition";
        this.File.DataMember = "File";
        this.File.DisplayIndex = 1;
        this.File.HeaderText = i18n("M12250", "Cilt İçerik");
        this.File.Name = "File";
        this.File.Width = 650;

        this.FolderContentStatus = new TTVisual.TTCheckBoxColumn();
        this.FolderContentStatus.DataMember = "FolderContentStatus";
        this.FolderContentStatus.DisplayIndex = 2;
        this.FolderContentStatus.HeaderText = "Durum";
        this.FolderContentStatus.Name = "FolderContentStatus";
        this.FolderContentStatus.Width = 400;


        this.labelShelf = new TTVisual.TTLabel();
        this.labelShelf.Text = i18n("M20708", "Raf");
        this.labelShelf.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelShelf.ForeColor = "#000000";
        this.labelShelf.Name = "labelShelf";
        this.labelShelf.TabIndex = 53;

        this.labelFileContent = new TTVisual.TTLabel();
        this.labelFileContent.Text = i18n("M13256", "Dosya İçeriği");
        this.labelFileContent.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelFileContent.ForeColor = "#000000";
        this.labelFileContent.Name = "labelFileContent";
        this.labelFileContent.TabIndex = 38;

        this.PatientEpisodeDetails = new TTVisual.TTGrid();
        this.PatientEpisodeDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientEpisodeDetails.Name = "PatientEpisodeDetails";
        this.PatientEpisodeDetails.TabIndex = 6;
        this.PatientEpisodeDetails.Height = "150px";

        this.OpeningDate = new TTVisual.TTDateTimePickerColumn();
        this.OpeningDate.DataMember = "OpeningDate";
        this.OpeningDate.DisplayIndex = 0;
        this.OpeningDate.HeaderText = i18n("M24029", "Vaka Tarihi");
        this.OpeningDate.Name = "OpeningDate";
        this.OpeningDate.ReadOnly = true;
        this.OpeningDate.Width = 350;

        this.EpisodeID = new TTVisual.TTTextBoxColumn();
        this.EpisodeID.DataMember = "ID";
        this.EpisodeID.DisplayIndex = 1;
        this.EpisodeID.HeaderText = i18n("M24015", "Vaka");
        this.EpisodeID.Name = "EpisodeID";
        this.EpisodeID.ReadOnly = true;
        this.EpisodeID.Width = 500;

        this.VolumeNo = new TTVisual.TTTextBoxColumn();
        this.VolumeNo.DataMember = "EpisodeFolder.EpisodeFolderID";
        this.VolumeNo.DisplayIndex = 2;
        this.VolumeNo.HeaderText = i18n("M12252", "Cilt No");
        this.VolumeNo.Name = "VolumeNo";
        this.VolumeNo.ReadOnly = true;
        this.VolumeNo.Width = 400;

        //TODO

        //this.ReasonForAdmission = new TTVisual.TTListBoxColumn();
        //this.ReasonForAdmission.ListDefName = "ReasonForAdmissionListDefinition";
        //this.ReasonForAdmission.DisplayIndex = 3;
        //this.ReasonForAdmission.HeaderText = "Kabul Sebebi";
        //this.ReasonForAdmission.Name = "ReasonForAdmission";
        //this.ReasonForAdmission.ReadOnly = true;
        //this.ReasonForAdmission.Width = 400;

        this.labelFile = new TTVisual.TTLabel();
        this.labelFile.Text = i18n("M13244", "Dosya");
        this.labelFile.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelFile.ForeColor = "#000000";
        this.labelFile.Name = "labelFile";
        this.labelFile.TabIndex = 50;
        this.labelFile.Visible = false;

        this.InArchive = new TTVisual.TTCheckBox();
        this.InArchive.Value = false;
        this.InArchive.Title = i18n("M11105", "Arşivde");
        this.InArchive.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InArchive.Name = "InArchive";
        this.InArchive.TabIndex = 7;
        this.InArchive.Visible = false;

        this.InInCompleteArea = new TTVisual.TTCheckBox();
        this.InInCompleteArea.Value = false;
        this.InInCompleteArea.Title = i18n("M13588", "Eksik Dosyalarda");
        this.InInCompleteArea.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InInCompleteArea.Name = "InInCompleteArea";
        this.InInCompleteArea.TabIndex = 8;
        this.InInCompleteArea.Visible = false;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M19602", "Oda");
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 5;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = i18n("M15623", "Hekim Kaynaklı");
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 65;

        this.ttcheckbox8 = new TTVisual.TTCheckBox();
        this.ttcheckbox8.Value = false;
        this.ttcheckbox8.Title = i18n("M18930", "Meslek Anamnez Formu");
        this.ttcheckbox8.Name = "ttcheckbox8";
        this.ttcheckbox8.TabIndex = 64;

        this.ttcheckbox9 = new TTVisual.TTCheckBox();
        this.ttcheckbox9.Value = false;
        this.ttcheckbox9.Title = i18n("M15042", "Günlük Müşahede ve Müdahele Kağıdı");
        this.ttcheckbox9.Name = "ttcheckbox9";
        this.ttcheckbox9.TabIndex = 64;

        this.ttcheckbox10 = new TTVisual.TTCheckBox();
        this.ttcheckbox10.Value = false;
        this.ttcheckbox10.Title = i18n("M10973", "Anestezi Formları");
        this.ttcheckbox10.Name = "ttcheckbox10";
        this.ttcheckbox10.TabIndex = 64;

        this.ttcheckbox11 = new TTVisual.TTCheckBox();
        this.ttcheckbox11.Value = false;
        this.ttcheckbox11.Title = i18n("M19653", "Onam Formları");
        this.ttcheckbox11.Name = "ttcheckbox11";
        this.ttcheckbox11.TabIndex = 64;

        this.ttcheckbox12 = new TTVisual.TTCheckBox();
        this.ttcheckbox12.Value = false;
        this.ttcheckbox12.Title = i18n("M12208", "Cerrahi Taraf Onam Formu");
        this.ttcheckbox12.Name = "ttcheckbox12";
        this.ttcheckbox12.TabIndex = 64;

        this.ttcheckbox13 = new TTVisual.TTCheckBox();
        this.ttcheckbox13.Value = false;
        this.ttcheckbox13.Title = i18n("M22567", "Taburcu Olan Hastaları Bilgilendirme Formu");
        this.ttcheckbox13.Name = "ttcheckbox13";
        this.ttcheckbox13.TabIndex = 64;

        this.ttcheckbox14 = new TTVisual.TTCheckBox();
        this.ttcheckbox14.Value = false;
        this.ttcheckbox14.Title = i18n("M21237", "Sağlık Kurulu Raporu");
        this.ttcheckbox14.Name = "ttcheckbox14";
        this.ttcheckbox14.TabIndex = 64;

        this.ttcheckbox18 = new TTVisual.TTCheckBox();
        this.ttcheckbox18.Value = false;
        this.ttcheckbox18.Title = i18n("M15049", "Güvenli Cerrahi Kontrol Listesi");
        this.ttcheckbox18.Name = "ttcheckbox18";
        this.ttcheckbox18.TabIndex = 64;

        this.ttcheckbox17 = new TTVisual.TTCheckBox();
        this.ttcheckbox17.Value = false;
        this.ttcheckbox17.Title = "Düşme Riski Ölçeği";
        this.ttcheckbox17.Name = "ttcheckbox17";
        this.ttcheckbox17.TabIndex = 64;

        this.ttcheckbox16 = new TTVisual.TTCheckBox();
        this.ttcheckbox16.Value = false;
        this.ttcheckbox16.Title = "Hasta Tabelası";
        this.ttcheckbox16.Name = "ttcheckbox16";
        this.ttcheckbox16.TabIndex = 64;

        this.ttcheckbox15 = new TTVisual.TTCheckBox();
        this.ttcheckbox15.Value = false;
        this.ttcheckbox15.Title = i18n("M13771", "Epikriz");
        this.ttcheckbox15.Name = "ttcheckbox15";
        this.ttcheckbox15.TabIndex = 64;

        this.ttcheckbox19 = new TTVisual.TTCheckBox();
        this.ttcheckbox19.Value = false;
        this.ttcheckbox19.Title = i18n("M12780", "Diğer");
        this.ttcheckbox19.Name = "ttcheckbox19";
        this.ttcheckbox19.TabIndex = 64;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Multiline = true;
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 65;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M10469", "Açıklama");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 66;

        this.ttgroupbox3 = new TTVisual.TTGroupBox();
        this.ttgroupbox3.Text = i18n("M21589", "Sekreter Kaynaklı");
        this.ttgroupbox3.Name = "ttgroupbox3";
        this.ttgroupbox3.TabIndex = 65;

        this.ttcheckbox20 = new TTVisual.TTCheckBox();
        this.ttcheckbox20.Value = false;
        this.ttcheckbox20.Title = i18n("M15219", "Hasta Giriş Kağıdı");
        this.ttcheckbox20.Name = "ttcheckbox20";
        this.ttcheckbox20.TabIndex = 64;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.Multiline = true;
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 65;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M10469", "Açıklama");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 66;

        this.lblBuilding = new TTVisual.TTLabel();
        this.lblBuilding.Text = "Bina";
        this.lblBuilding.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblBuilding.ForeColor = "#000000";
        this.lblBuilding.Name = "lblBuilding";
        this.lblBuilding.TabIndex = 37;

        this.labelResArchiveRoom = new TTVisual.TTLabel();
        this.labelResArchiveRoom.Text = "Oda";
        this.labelResArchiveRoom.Name = "labelResArchiveRoom";
        this.labelResArchiveRoom.TabIndex = 3;


        this.ResArchiveRoom = new TTVisual.TTObjectListBox();
        this.ResArchiveRoom.ListDefName = "ArchiveRoomListDef";
        this.ResArchiveRoom.Name = "ResArchiveRoom";
        this.ResArchiveRoom.TabIndex = 2;
        this.ResArchiveRoom.ListFilterExpression = "1=0";

        this.labelResCabinet = new TTVisual.TTLabel();
        this.labelResCabinet.Text = "Dolap";
        this.labelResCabinet.Name = "labelResCabinet";
        this.labelResCabinet.TabIndex = 3;

        this.ResCabinet = new TTVisual.TTObjectListBox();
        this.ResCabinet.ListDefName = "CabinetListDefinition";
        this.ResCabinet.Name = "ResCabinet";
        this.ResCabinet.TabIndex = 2;
        this.ResCabinet.ListFilterExpression = "1=0";


        this.labelResShelf = new TTVisual.TTLabel();
        this.labelResShelf.Text = "Dolap";
        this.labelResShelf.Name = "labelResShelf";
        this.labelResShelf.TabIndex = 3;

        this.ResShelf = new TTVisual.TTObjectListBox();
        this.ResShelf.ListDefName = "ShelfListDefinition";
        this.ResShelf.Name = "ResShelf";
        this.ResShelf.TabIndex = 2;
        this.ResShelf.ListFilterExpression = "1=0";


        this.FolderContentsColumns = [this.GridEpisodeFolderID, this.File, this.FolderContentStatus];
        this.PatientEpisodeDetailsColumns = [this.OpeningDate, this.EpisodeID, this.VolumeNo/*, this.ReasonForAdmission*/];
        this.ttgroupbox1.Controls = [this.ttlabel3, this.tttextbox1, this.chkHMHastaYakini, this.ttcheckbox2, this.ttcheckbox3, this.ttcheckbox4, this.ttcheckbox5, this.ttcheckbox6, this.ttcheckbox7];
        this.ttgroupbox2.Controls = [this.ttcheckbox8, this.ttcheckbox9, this.ttcheckbox10, this.ttcheckbox11, this.ttcheckbox12, this.ttcheckbox13, this.ttcheckbox14, this.ttcheckbox18, this.ttcheckbox17, this.ttcheckbox16, this.ttcheckbox15, this.ttcheckbox19, this.tttextbox2, this.ttlabel4];
        this.ttgroupbox3.Controls = [this.ttcheckbox20, this.tttextbox3, this.ttlabel5];
        this.Controls = [this.listBoxBuilding, this.ttgroupbox1, this.ttlabel3, this.tttextbox1, this.chkHMHastaYakini, this.ttcheckbox2, this.ttcheckbox3, this.ttcheckbox4, this.ttcheckbox5, this.ttcheckbox6, this.ttcheckbox7, this.ttlabel1, this.tttextboxOnlyYear, this.Shelf, this.EpisodeFolderID, this.FolderInformation, this.Row, this.PatientFolderID, this.txtRoom, this.LabelRequestDate, this.RequestDate, this.chkAdliVaka, this.labelEpisodeFolderID, this.labelPatientEpisodeDetails, this.labelRow, this.labelFolderInformation, this.labelPatientFolderID, this.FolderContents, this.GridEpisodeFolderID, this.File, this.FolderContentStatus, this.labelShelf, this.labelFileContent, this.PatientEpisodeDetails, this.OpeningDate, this.EpisodeID, this.VolumeNo, this.ReasonForAdmission, this.labelFile, this.InArchive, this.InInCompleteArea, this.ttlabel2, this.ttgroupbox2, this.ttcheckbox8, this.ttcheckbox9, this.ttcheckbox10, this.ttcheckbox11, this.ttcheckbox12, this.ttcheckbox13, this.ttcheckbox14, this.ttcheckbox18, this.ttcheckbox17, this.ttcheckbox16, this.ttcheckbox15, this.ttcheckbox19, this.tttextbox2, this.ttlabel4, this.ttgroupbox3, this.ttcheckbox20, this.tttextbox3, this.ttlabel5, this.lblBuilding, this.labelResArchiveRoom, this.ResArchiveRoom, this.labelResCabinet, this.ResCabinet, this.labelResShelf, this.ResShelf];

    }


}
