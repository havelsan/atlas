//$C187D3D5
import { Component, OnInit, NgZone } from '@angular/core';
import { PsychologicExaminationFormViewModel } from './PsychologicExaminationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PsychologicExamination } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologyTest } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'PsychologicExaminationForm',
    templateUrl: './PsychologicExaminationForm.html',
    providers: [MessageService]
})
export class PsychologicExaminationForm extends TTVisual.TTForm implements OnInit {
    ActionDatePsychologyTest: TTVisual.ITTDateTimePickerColumn;
    ProcedureByUser: TTVisual.ITTListBoxColumn;
    ProcedureDoctorPsychologyTest: TTVisual.ITTListBoxColumn;
    ProcedureObjectPsychologyTest: TTVisual.ITTListBoxColumn;
    PsychologyTests: TTVisual.ITTGrid;
    RequestedByUserPsychologyTest: TTVisual.ITTListBoxColumn;
    public PsychologyTestsColumns = [];
    public psychologicExaminationFormViewModel: PsychologicExaminationFormViewModel = new PsychologicExaminationFormViewModel();
    public get _PsychologicExamination(): PsychologicExamination {
        return this._TTObject as PsychologicExamination;
    }
    private PsychologicExaminationForm_DocumentUrl: string = '/api/PsychologicExaminationService/PsychologicExaminationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('PSYCHOLOGICEXAMINATION', 'PsychologicExaminationForm');
        this._DocumentServiceUrl = this.PsychologicExaminationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PsychologicExamination();
        this.psychologicExaminationFormViewModel = new PsychologicExaminationFormViewModel();
        this._ViewModel = this.psychologicExaminationFormViewModel;
        this.psychologicExaminationFormViewModel._PsychologicExamination = this._TTObject as PsychologicExamination;
        this.psychologicExaminationFormViewModel._PsychologicExamination.PsychologyTests = new Array<PsychologyTest>();
    }

    protected loadViewModel() {
        let that = this;

        that.psychologicExaminationFormViewModel = this._ViewModel as PsychologicExaminationFormViewModel;
        that._TTObject = this.psychologicExaminationFormViewModel._PsychologicExamination;
        if (this.psychologicExaminationFormViewModel == null)
            this.psychologicExaminationFormViewModel = new PsychologicExaminationFormViewModel();
        if (this.psychologicExaminationFormViewModel._PsychologicExamination == null)
            this.psychologicExaminationFormViewModel._PsychologicExamination = new PsychologicExamination();
        that.psychologicExaminationFormViewModel._PsychologicExamination.PsychologyTests = that.psychologicExaminationFormViewModel.PsychologyTestsGridList;
        for (let detailItem of that.psychologicExaminationFormViewModel.PsychologyTestsGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.psychologicExaminationFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                 if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.psychologicExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                 if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
            let requestedByUserObjectID = detailItem["RequestedByUser"];
            if (requestedByUserObjectID != null && (typeof requestedByUserObjectID === 'string')) {
                let requestedByUser = that.psychologicExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestedByUserObjectID.toString());
                 if (requestedByUser) {
                    detailItem.RequestedByUser = requestedByUser;
                }
            }
            let procedureByUserObjectID = detailItem["ProcedureByUser"];
            if (procedureByUserObjectID != null && (typeof procedureByUserObjectID === 'string')) {
                let procedureByUser = that.psychologicExaminationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureByUserObjectID.toString());
                 if (procedureByUser) {
                    detailItem.ProcedureByUser = procedureByUser;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(PsychologicExaminationFormViewModel);
  
    }


    public setSpecialityBasedObjectViewModel(e: any) {
        this._ViewModel.psychologyBasedObjectFormViewModel = e;
    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.PsychologyTests = new TTVisual.TTGrid();
        this.PsychologyTests.Name = "PsychologyTests";
        this.PsychologyTests.TabIndex = 0;
        this.PsychologyTests.ReadOnly = true;
        this.PsychologyTests.AllowUserToAddRows = false;
        this.PsychologyTests.AllowUserToDeleteRows = false;

        this.ProcedureObjectPsychologyTest = new TTVisual.TTListBoxColumn();
        this.ProcedureObjectPsychologyTest.DataMember = "ProcedureObject";
        this.ProcedureObjectPsychologyTest.ListDefName = "PsychologyProcedureListDefinition";
        this.ProcedureObjectPsychologyTest.DisplayIndex = 0;
        this.ProcedureObjectPsychologyTest.HeaderText = i18n("M16818", "İşlem");
        this.ProcedureObjectPsychologyTest.Name = "ProcedureObjectPsychologyTest";


        this.ProcedureDoctorPsychologyTest = new TTVisual.TTListBoxColumn();
        this.ProcedureDoctorPsychologyTest.DataMember = "ProcedureDoctor";
        this.ProcedureDoctorPsychologyTest.ListDefName = "ResUserListDefinition";
        this.ProcedureDoctorPsychologyTest.DisplayIndex = 1;
        this.ProcedureDoctorPsychologyTest.HeaderText = i18n("M16928", "İşlemi Yapan Doktor");
        this.ProcedureDoctorPsychologyTest.Name = "ProcedureDoctorPsychologyTest";

        this.RequestedByUserPsychologyTest = new TTVisual.TTListBoxColumn();
        this.RequestedByUserPsychologyTest.DataMember = "RequestedByUser";
        this.RequestedByUserPsychologyTest.ListDefName = "ResUserListDefinition";
        this.RequestedByUserPsychologyTest.DisplayIndex = 2;
        this.RequestedByUserPsychologyTest.HeaderText = i18n("M16914", "İşlemi İsteyen Kullanıcı");
        this.RequestedByUserPsychologyTest.Name = "RequestedByUserPsychologyTest";

        this.ActionDatePsychologyTest = new TTVisual.TTDateTimePickerColumn();
        this.ActionDatePsychologyTest.DataMember = "ActionDate";
        this.ActionDatePsychologyTest.DisplayIndex = 3;
        this.ActionDatePsychologyTest.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.ActionDatePsychologyTest.Name = "ActionDatePsychologyTest";

        this.ProcedureByUser = new TTVisual.TTListBoxColumn();
        this.ProcedureByUser.ListDefName = "PsychologistList";
        this.ProcedureByUser.DataMember = "ProcedureByUser";
        this.ProcedureByUser.DisplayIndex = 4;
        this.ProcedureByUser.HeaderText = i18n("M16920", "İşlemi Uygulayan Kullanıcı");
        this.ProcedureByUser.Name = "ProcedureByUser";

        this.PsychologyTestsColumns = [this.ProcedureObjectPsychologyTest, this.RequestedByUserPsychologyTest, this.ActionDatePsychologyTest];
        this.Controls = [this.PsychologyTests, this.ProcedureObjectPsychologyTest, this.ProcedureDoctorPsychologyTest, this.RequestedByUserPsychologyTest, this.ActionDatePsychologyTest, this.ProcedureByUser];

    }


}
