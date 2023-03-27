//$FC1EC1E1

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { ProceduresRequiredInfoViewModel } from "./ProceduresRequiredInfoViewModel";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { RadiologyTest, RadiologyTestTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { PsychologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { PathologyTestProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { NuclearMedicineTest } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationProcedure } from 'NebulaClient/Model/AtlasClientModel';



@Component({
    selector: 'procedures-required-infoform',
    templateUrl: './ProceduresRequiredInfoForm.html',
    outputs: ['showPopupRequiredInfoForm']
})
export class ProceduresRequiredInfoForm extends TTUnboundForm implements OnInit {

    public proceduresRequiredInfoViewModel: ProceduresRequiredInfoViewModel = new ProceduresRequiredInfoViewModel();
    private _requestedProcedures: Array<Guid>;
    chkCopyDescription: TTVisual.ITTCheckBox;
    showPopupRequiredInfoForm: EventEmitter<boolean> = new EventEmitter<boolean>();


    @Input() set RequestedProcedures(value: Array<Guid>) {
        this._requestedProcedures = value;
        if (this.RequestedProcedures != null)
            this.loadFormByRequestedProcedures();
    }
    get RequestedProcedures(): Array<Guid> {
        return this._requestedProcedures;
    }

    @Input() ClinicAnemnesis: string;

    constructor(protected httpService: NeHttpService, private reportService: AtlasReportService) {
        super("", "");
        this.proceduresRequiredInfoViewModel.copyDescription = true;
    }

    ngOnInit(): void {
        this.initFormControls();
    }
    public initFormControls(): void {

        this.chkCopyDescription = new TTVisual.TTCheckBox();
        this.chkCopyDescription.Text = i18n("M10478", "Açıklama Kopyala");
        this.chkCopyDescription.Title = i18n("M10478", "Açıklama Kopyala");
        this.chkCopyDescription.Name = "chkCopyDescription";
        this.chkCopyDescription.TabIndex = 80;
    }

    copyDescriptionChecked(isChecked: boolean) {
        //if (isChecked)
        //    this.proceduresRequiredInfoViewModel.copyDescription = true;
        //else
        //    this.proceduresRequiredInfoViewModel.copyDescription = false;
    }

    async loadFormByRequestedProcedures() {

        this.proceduresRequiredInfoViewModel.RadiologyTestList = new Array<RadiologyTest>();
        this.proceduresRequiredInfoViewModel.LaboratoryTestList = new Array<LaboratoryProcedure>();
        this.proceduresRequiredInfoViewModel.PsychologyProcedureList = new Array<PsychologyTest>();
        this.proceduresRequiredInfoViewModel.PathologyProcedureList = new Array<PathologyTestProcedure>();
        this.proceduresRequiredInfoViewModel.NuclearMedicineTestList = new Array<NuclearMedicineTest>();
        this.proceduresRequiredInfoViewModel.ManipulationProcedureList = new Array<ManipulationProcedure>();

        this.proceduresRequiredInfoViewModel.copyDescription = false;

        if (this.RequestedProcedures.length > 0) {
            let apiUrlForProcedureRequest: string = 'api/ProceduresRequiredInfoService/GetProceduresRequiredInfoViewModel';
            let result = await this.httpService.post<ProceduresRequiredInfoViewModel>(apiUrlForProcedureRequest, this.RequestedProcedures, ProceduresRequiredInfoViewModel);
            let that = this;
            for (let radTest of result.RadiologyTestList) {
                this.proceduresRequiredInfoViewModel.RadiologyTestList.push(radTest);
            }
            for (let labTest of result.LaboratoryTestList) {
                this.proceduresRequiredInfoViewModel.LaboratoryTestList.push(labTest);
            }
            for (let psyTest of result.PsychologyProcedureList) {
                this.proceduresRequiredInfoViewModel.PsychologyProcedureList.push(psyTest);
            }
            for (let patTest of result.PathologyProcedureList) {
                this.proceduresRequiredInfoViewModel.PathologyProcedureList.push(patTest);
            }
            for (let nuclearTest of result.NuclearMedicineTestList) {
                this.proceduresRequiredInfoViewModel.NuclearMedicineTestList.push(nuclearTest);
            }
            for (let mp of result.ManipulationProcedureList) {
                this.proceduresRequiredInfoViewModel.ManipulationProcedureList.push(mp);
            }

            this.proceduresRequiredInfoViewModel.ProcedureObjectList = result.ProcedureObjectList;
            this.proceduresRequiredInfoViewModel.RadiologyTestTypeDefinitions = result.RadiologyTestTypeDefinitions;
            this.proceduresRequiredInfoViewModel.ClinicAnemnesis = this.ClinicAnemnesis;
        }
    }
    public async btnSave_Click() {
        let isEmptyFields: boolean = false;
        if (this.proceduresRequiredInfoViewModel.PsychologyProcedureList != null) {
            for (let i = 0; i < this.proceduresRequiredInfoViewModel.PsychologyProcedureList.length; i++) {
                if (this.proceduresRequiredInfoViewModel.PsychologyProcedureList[i].ProcedureDoctor == null || this.proceduresRequiredInfoViewModel.PsychologyProcedureList[i].Description == null) {
                    isEmptyFields = true;
                    break;
                }
            }
        }
        if (this.proceduresRequiredInfoViewModel.RadiologyTestList != null) {
            for (let i = 0; i < this.proceduresRequiredInfoViewModel.RadiologyTestList.length; i++) {
                let procedure = this.proceduresRequiredInfoViewModel.ProcedureObjectList.find(o => o.ObjectID.toString() === this.proceduresRequiredInfoViewModel.RadiologyTestList[i].ProcedureObject.toString());
                
                let _testType = this.proceduresRequiredInfoViewModel.RadiologyTestTypeDefinitions.find(o => o.ObjectID.toString() === procedure["TestType"]);
                if (this.proceduresRequiredInfoViewModel.RadiologyTestList[i].GeneralDescription == null || 
                    (this.proceduresRequiredInfoViewModel.RadiologyTestList[i].ContrastType == null && _testType != null && (_testType.Name == "MR" || _testType.Name == "BR"))) {
                    isEmptyFields = true;
                    break;
                }
            }
        }
        if (this.proceduresRequiredInfoViewModel.NuclearMedicineTestList != null) {
            for (let i = 0; i < this.proceduresRequiredInfoViewModel.NuclearMedicineTestList.length; i++) {
                if (this.proceduresRequiredInfoViewModel.NuclearMedicineTestList[i].GeneralDescription == null) {
                    isEmptyFields = true;
                    break;
                }
            }
        }

        if (this.proceduresRequiredInfoViewModel.ManipulationProcedureList != null) {
            for (let i = 0; i < this.proceduresRequiredInfoViewModel.ManipulationProcedureList.length; i++) {
                if (this.proceduresRequiredInfoViewModel.ManipulationProcedureList[i].Description == null) {
                    isEmptyFields = true;
                    break;
                }
            }
        }
        if (isEmptyFields == false) {

            this.showPopupRequiredInfoForm.emit(false);
            let that = this;
            let apiUrl: string = 'api/ProceduresRequiredInfoService/SaveProceduresRequiredInfoViewModel';
            let result = await this.httpService.post<Array<Guid>>(apiUrl, that.proceduresRequiredInfoViewModel);

            if (result.length > 0) {
                for (let eaObjectID of result) {
                    const objectIdParam = new GuidParam(eaObjectID.toString());
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                    this.reportService.showReport('ExternalProcedureRequestReportByEpisodeAction', reportParameters);
                }
            }
        } else {
            TTVisual.InfoBox.Alert(i18n("M18365", "Lütfen Bütün Alanları Doldurunuz.!"));
        }
    }

}