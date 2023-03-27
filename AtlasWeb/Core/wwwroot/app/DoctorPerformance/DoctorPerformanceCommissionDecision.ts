//$B031EBC6
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { LookupColumn, DoctorPerformanceCommissionDecisionViewModel, DoctorPerformanceDecisionModel, RelatedUserModel, DPCommissionMember } from './DoctorPerformanceViewModel';
import { DoctorPerformanceTerm } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Guid } from '../NebulaClient/Mscorlib/Guid';
import { DoctorPerformance } from './DoctorPerformance';

@Component({
    selector: "dp-commission-operation",
    templateUrl: './DoctorPerformanceCommissionDecision.html'
})
export class DoctorPerformanceCommissionDecision implements OnInit {
    public doctorPerformanceCommissionDecisionViewModel: DoctorPerformanceCommissionDecisionViewModel ;
    public dpcStatesArray: Array<LookupColumn> = new Array<LookupColumn>();
    DPDecisionColumns = [];
    DPDecisionMemberColumns = [];
    public DPACommisionMemberDutyEnum: Array<any> = [{ Id: 0, Name: "Başkan" }, { Id: 1, Name: "Üye" } ];

    constructor(protected http: NeHttpService) {
        this.doctorPerformanceCommissionDecisionViewModel = new DoctorPerformanceCommissionDecisionViewModel();
    }

    ngOnInit() {
        this.dpcStatesArray.push(new LookupColumn("2ad88966-9340-40fa-a452-e251e3d6a00c", "Yeni", "New"));
        this.dpcStatesArray.push(new LookupColumn("e467b6cb-d0f3-4dfa-96f6-3b43d5b7eb52", "Onaylı", "Approval"));
        this.dpcStatesArray.push(new LookupColumn("424eeb49-742c-4c5a-ac1e-f6795aa90a64", "İptal", "Cancel"));

        this.http.get<Array<RelatedUserModel>>("api/DoctorPerformanceApi/GetAllUserList").then(result => {
            this.doctorPerformanceCommissionDecisionViewModel.Users = result;
            
            this.generateDecisionColumns();
            this.loadDecissionlist();
        }).catch(error => {
            this.errorHandlerForDPTermOperation(error);
        });
    }

    loadDecissionlist() {
        this.http.get<Array<DoctorPerformanceDecisionModel>>("api/DoctorPerformanceApi/GetAllDoctorPerformanceCommissionDecission").then(result => {
            this.doctorPerformanceCommissionDecisionViewModel.DecisionList = result;
            this.calculateDisabilty();
        }).catch(error => {
            this.errorHandlerForDPTermOperation(error);
        });
    }
    onClickNew(): void {
        this.doctorPerformanceCommissionDecisionViewModel.SelectedDecision = new DoctorPerformanceDecisionModel();
        this.calculateDisabilty();
    }

    public onDecissionChanged(event): void {
        if (event != null) {
            if (this.doctorPerformanceCommissionDecisionViewModel.SelectedDecision != null && this.doctorPerformanceCommissionDecisionViewModel.SelectedDecision.Text != event) {
                this.doctorPerformanceCommissionDecisionViewModel.SelectedDecision.Text = event;
            }
        }
    }

    onClickSave(): void {
        let apiUrlForTaniKayit: string = '/api/DoctorPerformanceApi/SaveNewDPCommissionDecision';

        this.http.post<Guid>(apiUrlForTaniKayit, this.doctorPerformanceCommissionDecisionViewModel.SelectedDecision).then(response => {
            ServiceLocator.MessageService.showSuccess("Komisyon kararı başarılı bir şekilde kayıt edildi.");
            this.doctorPerformanceCommissionDecisionViewModel.SelectedDecision.ObjectID = response;
            this.loadDecissionlist();
        }).catch(error => {
            this.errorHandlerForDPTermOperation(error);
            this.loadDecissionlist();
        });
    }

    onClickApprove(): void {
        let apiUrlForTaniKayit: string = '/api/DoctorPerformanceApi/ApproveDPCommissionDecision';

        this.http.post<boolean>(apiUrlForTaniKayit, this.doctorPerformanceCommissionDecisionViewModel.SelectedDecision).then(response => {
            if (response) {
                ServiceLocator.MessageService.showSuccess("Komisyon kararı başarılı bir şekilde onaylandı.");
                this.onClickNew();
            }
            this.loadDecissionlist();
        }).catch(error => {
            this.errorHandlerForDPTermOperation(error);
            this.loadDecissionlist();
        });
    }
    public saveVisible: boolean;
    public approveVisible: boolean;
    calculateDisabilty(): void {
        let currentState = this.doctorPerformanceCommissionDecisionViewModel.SelectedDecision.CurrentState;
        this.saveVisible = true;
        this.approveVisible = true;

        if (currentState == "2ad88966-9340-40fa-a452-e251e3d6a00c")//Yeni
        {
            this.saveVisible = true;
            this.approveVisible = true;
        }
        else if (currentState == "e467b6cb-d0f3-4dfa-96f6-3b43d5b7eb52")//Onaylı
        {
            this.saveVisible = false;
            this.approveVisible = false;
        }
        else if (currentState == "424eeb49-742c-4c5a-ac1e-f6795aa90a64")//iptal
        {
            this.saveVisible = false;
            this.approveVisible = false;
        }
        else {
            this.saveVisible = true;
            this.approveVisible = false;
        }
    }

    onRowClickDecisionist(event: any) {
        if (event.data.ObjectID != this.doctorPerformanceCommissionDecisionViewModel.SelectedDecision.ObjectID) {
            this.doctorPerformanceCommissionDecisionViewModel.SelectedDecision = event.data;
            this.calculateDisabilty();
        }
    }
    generateDecisionColumns(): void {
        let that = this;
        this.DPDecisionColumns = [
            {
                caption: 'Adı',
                dataField: 'Name',
                dataType: 'string' 
            },
            {
                caption: 'Tarih',
                dataField: 'Date',
                dataType: 'date' 
            },
            {
                caption: 'Durum',
                dataField: 'CurrentState',
                dataType: 'string',
                lookup: { dataSource: that.dpcStatesArray, valueExpr: 'ObjectID', displayExpr: 'Name' } 
            }];

        this.DPDecisionMemberColumns = [
            {
                caption: 'Görev',
                dataField: 'Duty',
                lookup: { dataSource: that.DPACommisionMemberDutyEnum, valueExpr: 'Id', displayExpr: 'Name' }
            },
            {
                caption: 'Üye',
                dataField: 'ObjectID',
                lookup: { dataSource: that.doctorPerformanceCommissionDecisionViewModel.Users, valueExpr: 'ObjectID', displayExpr: 'Name' }
            }];
    }
     

    EditingConfig: any = {
        mode: 'row',
        allowUpdating: true,
        allowAdding: true,
        allowDeleting: false,
        texts: {
            deleteRow: 'Sil',
            addRow: 'Yeni Üye Ekle',
            editRow: 'Güncelle',
            confirmDeleteMessage: 'Komisyon üyesi silinecek. Emin misiniz?'
        }
    };

    
    errorHandlerForDPTermOperation(message: string): void {
        //this.loadPanelOperation(false, '');
        ServiceLocator.MessageService.showError(message);
        console.log(message);
    }

     

      
}