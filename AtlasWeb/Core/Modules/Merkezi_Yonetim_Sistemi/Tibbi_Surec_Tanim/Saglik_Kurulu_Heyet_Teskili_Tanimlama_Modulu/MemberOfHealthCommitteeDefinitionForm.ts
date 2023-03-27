//$582CE7F1
import { Component, ViewChild, OnInit, ApplicationRef  } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { MemberOfHealthCommitteeDefinitionFormViewModel } from './MemberOfHealthCommitteeDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Common } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { HealthCommitteMemberGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ITTObject } from 'NebulaClient/StorageManager/InstanceManagement/ITTObject';
import { MemberOfHealthCommitteeDefinition } from 'NebulaClient/Model/AtlasClientModel';
// import { MemberOfHealthCommitteeDefinitionService } from "ObjectClassService/MemberOfHealthCommitteeDefinitionService";
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { DxDataGridComponent } from 'devextreme-angular';

@Component({
    selector: 'MemberOfHealthCommitteeDefinitionForm',
    templateUrl: './MemberOfHealthCommitteeDefinitionForm.html',
    providers: [MessageService]
})
export class MemberOfHealthCommitteeDefinitionForm extends TTVisual.TTForm implements OnInit {
    CommitteeName: TTVisual.ITTTextBox;
    datagridviewcolumn1: TTVisual.ITTListBoxColumn;
    Doctor: TTVisual.ITTListBoxColumn;
    GroupNo: TTVisual.ITTTextBox;
    labelCommitteeName: TTVisual.ITTLabel;
    labelGroupNo: TTVisual.ITTLabel;
    labelMasterOfHealthCommittee: TTVisual.ITTLabel;
    MasterOfHealthCommittee: TTVisual.ITTObjectListBox;
    MasterOfHealthCommittee2: TTVisual.ITTObjectListBox;
    Members: TTVisual.ITTGrid;
    OrderNo: TTVisual.ITTTextBoxColumn;
    TempBox: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    Work: TTVisual.ITTTextBoxColumn;
    public tempResourcesToBeReferredPoliclinic: string;
    public tempProcedureDoctorToBeReferred: string;
    public MemberList: Array<HealthCommitteMemberGrid> = new Array<HealthCommitteMemberGrid>();
    public MembersColumns = [];
    public memberOfHealthCommitteeDefinitionFormViewModel: MemberOfHealthCommitteeDefinitionFormViewModel = new MemberOfHealthCommitteeDefinitionFormViewModel();
    @ViewChild('memberDoctorsGrid') memberDoctorsGrid: DxDataGridComponent;
    public get _MemberOfHealthCommitteeDefinition(): MemberOfHealthCommitteeDefinition {
        return this._TTObject as MemberOfHealthCommitteeDefinition;
    }
    private MemberOfHealthCommitteeDefinitionForm_DocumentUrl: string = '/api/MemberOfHealthCommitteeDefinitionService/MemberOfHealthCommitteeDefinitionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('MEMBEROFHEALTHCOMMITTEEDEFINITION', 'MemberOfHealthCommitteeDefinitionForm');
        this._DocumentServiceUrl = this.MemberOfHealthCommitteeDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async Members_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
      /*  if (rowIndex > -1 && columnIndex > -1 && columnIndex === 1) {
            let pDoctor: ResUser = <ResUser>this._MemberOfHealthCommitteeDefinition.ObjectContext.GetObject((<Guid>this.Members.CurrentCell.Value), typeof ResUser);
            let pForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let sect of pDoctor.SelectedResources) {
                if (!pForm.IsItemExists(sect.ObjectID.toString()))
                    pForm.AddMSItem(sect.Name, sect.ObjectID.toString(), sect);
            }
            let sKey: string = pForm.GetMSItem(this, 'Bölüm seçiniz', true);
            if (!String.isNullOrEmpty(sKey))
                this.Members.Rows[rowIndex].Cells[2].Value = (<ResSection>pForm.MSSelectedItemObject).ObjectID;
            else this.Members.Rows[rowIndex].Cells[2].Value = null;
            this.Members.Rows[rowIndex].Cells[0].Value = this._MemberOfHealthCommitteeDefinition.Members.length;
        }*/
    }
    private async Members_UserDeletedRow(): Promise<void> {
        let rowIndex: number = 0;
        while (rowIndex < this.Members.Rows.length) {
            this.Members.Rows[rowIndex].Cells[0].Value = rowIndex + 1;
            rowIndex++;
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {

    }
    protected async PreScript(): Promise<void> {
        let isEditable: boolean = true;
        if (this._MemberOfHealthCommitteeDefinition.IsNew)
            this.GroupNo.ReadOnly = false;
        else
            this.GroupNo.ReadOnly = true;
        // this.Text = 'Sağlık Kurulu Heyet Teşkili Tanımları';
     /*   if (this._MemberOfHealthCommitteeDefinition.GroupNo.Value !== null)
            this.TempBox.Visible = false;
        let isEditable: boolean = true;
        if ((<ITTObject>this._MemberOfHealthCommitteeDefinition).IsNew) {
            let memberDefs: Array<MemberOfHealthCommitteeDefinition> = <Array<MemberOfHealthCommitteeDefinition>>(await MemberOfHealthCommitteeDefinitionService.GetMemberDefinitions(this._MemberOfHealthCommitteeDefinition.ObjectContext));
            for (let memberDef of memberDefs) {
                if (memberDef.ObjectID !== this._MemberOfHealthCommitteeDefinition.ObjectID) {
                    this._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee = memberDef.MasterOfHealthCommittee;
                    this._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee2 = memberDef.MasterOfHealthCommittee2;
                    for (let member of memberDef.Members) {
                        let newMember: HealthCommitteMemberGrid = new HealthCommitteMemberGrid(this._MemberOfHealthCommitteeDefinition.ObjectContext);
                        newMember.OrderNo = member.OrderNo;
                        newMember.Doctor = member.Doctor;
                        newMember.Unit = member.Unit;
                        this._MemberOfHealthCommitteeDefinition.Members.push(newMember);
                    }
                    break;
                }
            }
        }
        else {
            if (!Common.CurrentUser.IsSuperUser) {

            }
        }
        if (!isEditable) {
            this.MasterOfHealthCommittee.ReadOnly = true;
            this.MasterOfHealthCommittee2.ReadOnly = true;
            this.Members.ReadOnly = true;
        }
        else {
            this.MasterOfHealthCommittee.ReadOnly = false;
            this.MasterOfHealthCommittee2.ReadOnly = false;
            this.Members.ReadOnly = false;
        }
        if (this.Members.CurrentCell !== null)
            this.Members.Sort(0);*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MemberOfHealthCommitteeDefinition();
        this.memberOfHealthCommitteeDefinitionFormViewModel = new MemberOfHealthCommitteeDefinitionFormViewModel();
        this._ViewModel = this.memberOfHealthCommitteeDefinitionFormViewModel;
        this.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition = this._TTObject as MemberOfHealthCommitteeDefinition;
        this.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition.Members = new Array<HealthCommitteMemberGrid>();
        this.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee = new ResUser();
        this.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee2 = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.memberOfHealthCommitteeDefinitionFormViewModel = this._ViewModel as MemberOfHealthCommitteeDefinitionFormViewModel;
        that._TTObject = this.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition;
        if (this.memberOfHealthCommitteeDefinitionFormViewModel == null)
            this.memberOfHealthCommitteeDefinitionFormViewModel = new MemberOfHealthCommitteeDefinitionFormViewModel();
        if (this.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition == null)
            this.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition = new MemberOfHealthCommitteeDefinition();
        that.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition.Members = that.memberOfHealthCommitteeDefinitionFormViewModel.MembersGridList;
        for (let detailItem of that.memberOfHealthCommitteeDefinitionFormViewModel.MembersGridList) {
            let doctorObjectID = detailItem["Doctor"];
            if (doctorObjectID != null && (typeof doctorObjectID === "string")) {
                let doctor = that.memberOfHealthCommitteeDefinitionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === doctorObjectID.toString());
                if (doctor) {
                    detailItem.Doctor = doctor;
                }
            }

            let unitObjectID = detailItem["Unit"];
            if (unitObjectID != null && (typeof unitObjectID === "string")) {
                let unit = that.memberOfHealthCommitteeDefinitionFormViewModel.ResSections.find(o => o.ObjectID.toString() === unitObjectID.toString());
                if (unit) {
                    detailItem.Unit = unit;
                }
            }

        }

        let masterOfHealthCommitteeObjectID = that.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition["MasterOfHealthCommittee"];
        if (masterOfHealthCommitteeObjectID != null && (typeof masterOfHealthCommitteeObjectID === "string")) {
            let masterOfHealthCommittee = that.memberOfHealthCommitteeDefinitionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === masterOfHealthCommitteeObjectID.toString());
            if (masterOfHealthCommittee) {
                that.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee = masterOfHealthCommittee;
            }
        }


        let masterOfHealthCommittee2ObjectID = that.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition["MasterOfHealthCommittee2"];
        if (masterOfHealthCommittee2ObjectID != null && (typeof masterOfHealthCommittee2ObjectID === "string")) {
            let masterOfHealthCommittee2 = that.memberOfHealthCommitteeDefinitionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === masterOfHealthCommittee2ObjectID.toString());
            if (masterOfHealthCommittee2) {
                that.memberOfHealthCommitteeDefinitionFormViewModel._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee2 = masterOfHealthCommittee2;
            }
        }



    }

async ngOnInit() {
    await this.load();
}

public onCommitteeNameChanged(event): void {
    if(this._MemberOfHealthCommitteeDefinition != null && this._MemberOfHealthCommitteeDefinition.CommitteeName != event) { 
    this._MemberOfHealthCommitteeDefinition.CommitteeName = event;
}
}

public onGroupNoChanged(event): void {
    if(this._MemberOfHealthCommitteeDefinition != null && this._MemberOfHealthCommitteeDefinition.GroupNo != event) { 
    this._MemberOfHealthCommitteeDefinition.GroupNo = event;
}
}

public onMasterOfHealthCommittee2Changed(event): void {
    if(this._MemberOfHealthCommitteeDefinition != null && this._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee2 != event) { 
    this._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee2 = event;
}
}

public onMasterOfHealthCommitteeChanged(event): void {
    if(this._MemberOfHealthCommitteeDefinition != null && this._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee != event) { 
    this._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee = event;
}
}

public async onProcedureDoctorToBeReferred(event: any) {
    let that: this;   

    if (event != null && event.selectedItem != null) {
        // this.tempResourcesToBeReferredPoliclinic = event.selectedItem;
        this.memberOfHealthCommitteeDefinitionFormViewModel.ResSectionList = await this.getResSectionList(event.selectedItem.ObjectID);
    }
}

public async getResSectionList(DoctorID: String): Promise<any> {

    let fullApiUrl = '/api/MemberOfHealthCommitteeDefinitionService/GetResSectionsByDoctor?DoctorID=' + DoctorID;
    return await this.httpService.get<ResUser>(fullApiUrl);
}

public async btnAddMembers() {
    if (this.tempProcedureDoctorToBeReferred != null && this.tempResourcesToBeReferredPoliclinic != null) {
        
        if(this._MemberOfHealthCommitteeDefinition.Members == null)
            this._MemberOfHealthCommitteeDefinition.Members = new Array<HealthCommitteMemberGrid>();

        let patientAdmissionResourcesToBeReferred: HealthCommitteMemberGrid = new HealthCommitteMemberGrid(this._MemberOfHealthCommitteeDefinition.ObjectContext);
        
        let _ttDoc = this.memberOfHealthCommitteeDefinitionFormViewModel.DoctorList.find(x => x.ObjectID.toString() == this.tempProcedureDoctorToBeReferred);
        patientAdmissionResourcesToBeReferred.Doctor = <ResUser>_ttDoc;

        let _ttPol = this.memberOfHealthCommitteeDefinitionFormViewModel.ResSectionList.find(x => x.ObjectID.toString() == this.tempResourcesToBeReferredPoliclinic);
        patientAdmissionResourcesToBeReferred.Unit = _ttPol;

        patientAdmissionResourcesToBeReferred.IsNew = true;
        patientAdmissionResourcesToBeReferred.OrderNo = this._MemberOfHealthCommitteeDefinition.Members.length + 1;              

        this.MemberList.push(patientAdmissionResourcesToBeReferred);
        this._MemberOfHealthCommitteeDefinition.Members.push(patientAdmissionResourcesToBeReferred);

        this.tempProcedureDoctorToBeReferred = null;
        this.tempResourcesToBeReferredPoliclinic = null;

    }
    else
        ServiceLocator.MessageService.showInfo("Bölüm ve Doktor alanlarını birlikte seçmelisiniz.");

}

public onInpMemberDoctorRemoving(event) {
    if (event.row != null) {

        // if (event.row.data != null) {
        //     let index = this._MemberOfHealthCommitteeDefinition.Members.findIndex(o => o.Doctor.ObjectID.toString() === event.row.data.Doctor.ObjectID.toString()
        //         && o.Unit.ObjectID.toString() === event.row.data.Unit.ObjectID.toString());

        //     if (index > -1)
        //         this.MemberList.splice(index, 1);
        //         this.memberOfHealthCommitteeDefinitionFormViewModel.MembersGridList.splice(index,1);

        // }

        if (event.row.data.IsNew != false) {

            let index = this._MemberOfHealthCommitteeDefinition.Members.findIndex(o => o.Doctor.ObjectID.toString() === event.row.data.Doctor.ObjectID.toString()
                && o.Unit.ObjectID.toString() === event.row.data.Unit.ObjectID.toString());

            if (index > -1) {
                this.MemberList.splice(index, 1);
                this.memberOfHealthCommitteeDefinitionFormViewModel.MembersGridList.splice(index,1);
            }

            this.memberDoctorsGrid.instance.deleteRow(event.rowIndex);
        }
        else {
            event.data.EntityState = EntityStateEnum.Deleted;
            this.memberDoctorsGrid.instance.filter(['EntityState', '<>', 1]);
            this.memberDoctorsGrid.instance.refresh();
        }

        let _index = 0;
        this.memberOfHealthCommitteeDefinitionFormViewModel.MembersGridList.forEach(member =>{
            if(member.EntityState != 1 )
            {
                _index = _index + 1;
                member.OrderNo = _index;
                // let mm = this._MemberOfHealthCommitteeDefinition.Members.find(o => o.ObjectID == member.ObjectID);
                // mm.OrderNo =_index;
            }
        });
    }
}

Members_CellValueChangedEmitted(data:any){
    if (data && this.Members_CellValueChanged && data.Row && data.Column) {
        this.Members.CurrentCell =
            {
                OwningRow: data.Row,
                OwningColumn: data.Column
            };
        this.Members_CellValueChanged(data.RowIndex, data.ColIndex);
    }
}

protected redirectProperties() : void {
    redirectProperty(this.GroupNo, "Text", this.__ttObject, "GroupNo");
    redirectProperty(this.CommitteeName, "Text", this.__ttObject, "CommitteeName");
}

public initFormControls() : void {
    this.labelCommitteeName = new TTVisual.TTLabel();
    this.labelCommitteeName.Text = "Heyet Adı";
    this.labelCommitteeName.Name = "labelCommitteeName";
    this.labelCommitteeName.TabIndex = 10;

    this.CommitteeName = new TTVisual.TTTextBox();
    this.CommitteeName.Name = "CommitteeName";
    this.CommitteeName.TabIndex = 9;

    this.TempBox = new TTVisual.TTTextBox();
    this.TempBox.Text = "#";
    this.TempBox.BackColor = "#F0F0F0";
    this.TempBox.ReadOnly = true;
    this.TempBox.Name = "TempBox";
    this.TempBox.TabIndex = 8;

    this.GroupNo = new TTVisual.TTTextBox();
    this.GroupNo.BackColor = "#F0F0F0";
    // this.GroupNo.ReadOnly = true;
    this.GroupNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.GroupNo.Name = "GroupNo";
    this.GroupNo.TabIndex = 2;

    this.Members = new TTVisual.TTGrid();
    this.Members.BackColor = "#DCDCDC";
    this.Members.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.Members.Name = "Members";
    this.Members.TabIndex = 4;

    this.OrderNo = new TTVisual.TTTextBoxColumn();
    this.OrderNo.DataMember = "OrderNo";
    this.OrderNo.DisplayIndex = 0;
    this.OrderNo.HeaderText = "Sıra No";
    this.OrderNo.Name = "OrderNo";
    this.OrderNo.ReadOnly = true;
    this.OrderNo.Width = 65;

    this.Doctor = new TTVisual.TTListBoxColumn();
    this.Doctor.ListDefName = "DoctorAndTechnicianList";
    this.Doctor.DataMember = "Doctor";
    this.Doctor.Required = true;
    this.Doctor.DisplayIndex = 1;
    this.Doctor.HeaderText = "Tabip";
    this.Doctor.Name = "Doctor";
    this.Doctor.Width = 200;

    this.datagridviewcolumn1 = new TTVisual.TTListBoxColumn();
    this.datagridviewcolumn1.ListDefName = "ResourceListDefinition";
    this.datagridviewcolumn1.DataMember = "Unit";
    this.datagridviewcolumn1.DisplayIndex = 2;
    this.datagridviewcolumn1.HeaderText = "Bölümü";
    this.datagridviewcolumn1.Name = "datagridviewcolumn1";
    this.datagridviewcolumn1.Width = 200;

    this.Work = new TTVisual.TTTextBoxColumn();
    this.Work.DataMember = "Work";
    this.Work.DisplayIndex = 3;
    this.Work.HeaderText = "Görevi";
    this.Work.Name = "Work";
    this.Work.Width = 200;

    this.labelMasterOfHealthCommittee = new TTVisual.TTLabel();
    this.labelMasterOfHealthCommittee.Text = "Baştabip / Baştabip Yardımcısı";
    this.labelMasterOfHealthCommittee.BackColor = "#DCDCDC";
    this.labelMasterOfHealthCommittee.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelMasterOfHealthCommittee.ForeColor = "#000000";
    this.labelMasterOfHealthCommittee.Name = "labelMasterOfHealthCommittee";
    this.labelMasterOfHealthCommittee.TabIndex = 5;

    this.ttlabel1 = new TTVisual.TTLabel();
    this.ttlabel1.Text = "Üyeler";
    this.ttlabel1.BackColor = "#F0F0F0";
    this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=9, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel1.ForeColor = "#000000";
    this.ttlabel1.Name = "ttlabel1";
    this.ttlabel1.TabIndex = 6;

    this.labelGroupNo = new TTVisual.TTLabel();
    this.labelGroupNo.Text = "Grup No";
    this.labelGroupNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.labelGroupNo.Name = "labelGroupNo";
    this.labelGroupNo.TabIndex = 3;

    this.MasterOfHealthCommittee = new TTVisual.TTObjectListBox();
    this.MasterOfHealthCommittee.Required = true;
    this.MasterOfHealthCommittee.ListDefName = "DoctorListDefinition";
    this.MasterOfHealthCommittee.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.MasterOfHealthCommittee.Name = "MasterOfHealthCommittee";
    this.MasterOfHealthCommittee.TabIndex = 3;

    this.ttlabel2 = new TTVisual.TTLabel();
    this.ttlabel2.Text = "Sağlık Kurulu Başkanı";
    this.ttlabel2.BackColor = "#DCDCDC";
    this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.ttlabel2.ForeColor = "#000000";
    this.ttlabel2.Name = "ttlabel2";
    this.ttlabel2.TabIndex = 5;

    this.MasterOfHealthCommittee2 = new TTVisual.TTObjectListBox();
    this.MasterOfHealthCommittee2.Required = true;
    this.MasterOfHealthCommittee2.ListDefName = "DoctorListDefinition";
    this.MasterOfHealthCommittee2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
    this.MasterOfHealthCommittee2.Name = "MasterOfHealthCommittee2";
    this.MasterOfHealthCommittee2.TabIndex = 3;

    this.MembersColumns = [this.OrderNo, this.Doctor, this.datagridviewcolumn1, this.Work];
    this.Controls = [this.labelCommitteeName, this.CommitteeName, this.TempBox, this.GroupNo, this.Members, this.OrderNo, this.Doctor, this.datagridviewcolumn1, this.Work, this.labelMasterOfHealthCommittee, this.ttlabel1, this.labelGroupNo, this.MasterOfHealthCommittee, this.ttlabel2, this.MasterOfHealthCommittee2];

}


}
