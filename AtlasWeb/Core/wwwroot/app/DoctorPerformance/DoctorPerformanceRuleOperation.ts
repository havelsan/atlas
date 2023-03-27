//$B031EBC6
import { Component, OnInit, ApplicationRef } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DoctorPerformanceRuleOperationViewModel, DoctorPerformanceRuleOperationDetailViewModel, GILDefinitionDTO, ProcedureModelForRule, SpecialityModelForRule, DiagnosisModelForRule } from './DoctorPerformanceViewModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

@Component({
    selector: "dp-rule-operation",
    templateUrl: './DoctorPerformanceRuleOperation.html'
})
export class DoctorPerformanceRuleOperation implements OnInit {
    ProcedureSelection: TTVisual.ITTObjectListBox;
    DiagnosisSelection: TTVisual.ITTObjectListBox;
    SpecialitySelection: TTVisual.ITTObjectListBox;
    public doctorPerformanceRuleOperationViewModel: DoctorPerformanceRuleOperationViewModel;
    DPRuleMasterColumns = [];
    DPRuleProcedureColumns = [];
    DPRuleSpecialtyColumns = [];
    DPRuleDiagnosisColumns = [];
    DPRuleQueryColumns = [];

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';

        //this.loadPanelOperation(false, "");
        //this.loadPanelOperation(true,  "Mesaj");
    }


    public bannOrMustTypeArray = [
        {
            Name: "Yasaklı",
            ObjectID: 0
        },
        {
            Name: "Zorunlu",
            ObjectID: 1
        }
    ];
    public timeTypeArray = [
        {
            Name: "Aynı Gün",
            ObjectID: 0
        },
        {
            Name: "Farklı Gün",
            ObjectID: 1
        }
    ];
    public ageTypeArray = [
        {
            Name: "<= Küçük Eşit",
            ObjectID: 0
        },
        {
            Name: ">= Büyük Eşit",
            ObjectID: 1
        }
    ];
    public periodScopeArray = [
        {
            Name: "Kabul Bazında",
            ObjectID: 0
        },
        {
            Name: "Hasta Bazında",
            ObjectID: 1
        }
    ];
    public periodTimeTypeArray = [
        {
            Name: "Gün",
            ObjectID: 0
        },
        {
            Name: "Saat",
            ObjectID: 1
        }
    ];
    public sexArray = [
        {
            Name: "Erkek",
            ObjectID: 0
        },
        {
            Name: "Kadın",
            ObjectID: 1
        }
    ];
    public tedaviTuruArray = [
        {
            Name: "Ayaktan",
            ObjectID: 'A'
        },
        {
            Name: "Yatan",
            ObjectID: 'Y'
        },
        {
            Name: "Günübirlik",
            ObjectID: 'G'
        }
    ];
    public kesiArray = [
        {
            Name: "Yapılsın",
            ObjectID: 0
        },
        {
            Name: "Yapılmasın",
            ObjectID: 1
        }
    ];
    public hospitalArray = [
        {
            Name: "1.Basamak",
            ObjectID: 1
        },
        {
            Name: "2.Basamak",
            ObjectID: 2
        },
        {
            Name: "3.Basamak",
            ObjectID: 3
        }
    ];
    public hasRuleArray = [
        {
            Name: "Var",
            ObjectID: true
        },
        {
            Name: "Yok",
            ObjectID: false
        }
    ];

    constructor(protected http: NeHttpService, private detector: ApplicationRef) {
        this.initFormControls();
        this.doctorPerformanceRuleOperationViewModel = new DoctorPerformanceRuleOperationViewModel();

    }

    public initFormControls(): void {
        this.ProcedureSelection = new TTVisual.TTObjectListBox();
        this.ProcedureSelection.ListDefName = "GILListDefinition";
        this.ProcedureSelection.Name = "ProcedureSelection";
        this.ProcedureSelection.AutoCompleteDialogWidth = "40%";

        this.DiagnosisSelection = new TTVisual.TTObjectListBox();
        this.DiagnosisSelection.ListDefName = "DiagnosisListDefinition";
        this.DiagnosisSelection.Name = "DiagnosisSelection";
        this.DiagnosisSelection.AutoCompleteDialogWidth = "40%";

        this.SpecialitySelection = new TTVisual.TTObjectListBox();
        this.SpecialitySelection.ListDefName = "SpecialityListDefinition";
        this.SpecialitySelection.Name = "SpecialitySelection";
        this.SpecialitySelection.AutoCompleteDialogWidth = "40%";
    }
    ngOnInit() {
        this.getGILDefinitions();
        this.generateAllRuleColumns();
    }
    getGILDefinitions(): void {
        this.http.get<Array<GILDefinitionDTO>>("api/DoctorPerformanceApi/getGILDefinitions").then(result => {
            this.doctorPerformanceRuleOperationViewModel.GILDefinitionList = result;
        }).catch(error => {
           this.errorHandlerForDPRuleOperation(error);
        });
    }

    onRowClickGILDefinitionList(event: any): void {
        this.doctorPerformanceRuleOperationViewModel.SelectedItem = event.data;
        this.getRuleDetail(event.data.Code);
    }

    getRuleDetail(code: string): void {
        let that = this;
        this.loadPanelOperation(true, "Kural detayları getiriliyor, lütfen bekleyiniz.");
        this.http.get<DoctorPerformanceRuleOperationDetailViewModel>("api/DoctorPerformanceApi/getDPRule?code=" + code).then(result => {
            that.loadPanelOperation(false, "");
            this.doctorPerformanceRuleOperationViewModel.SelectedRule = result;
        }).catch(error => {
            this.errorHandlerForDPRuleOperation(error);
        });
    }
    selectedProcedureByAdding: any;
    procedureSelection_ValueChanged(data: any): void{
        let that = this;
        if (data != null && data != undefined) {
            let tempProcedure: ProcedureModelForRule = new ProcedureModelForRule();
            tempProcedure.Code = data.Code;
            tempProcedure.Name = data.Name;
            tempProcedure.ObjectID = data.ObjectID;
            tempProcedure.TimeType = 0;
            tempProcedure.BannOrMustType = 0;
            that.doctorPerformanceRuleOperationViewModel.SelectedRule.ProcedureList.push(tempProcedure);

            window.setTimeout(t => {
                if (that.selectedProcedureByAdding === null)
                    that.selectedProcedureByAdding = undefined;
                else
                    that.selectedProcedureByAdding = null;
                that.detector.tick();
            }, 0);
        }
    }

    selectedDiagnosisByAdding: any;
    diagnosisSelection_ValueChanged(data: any): void {
        let that = this;
        if (data != null && data != undefined) {
            let tempDiagnosis: DiagnosisModelForRule = new DiagnosisModelForRule();
            tempDiagnosis.Code = data.Code;
            tempDiagnosis.Name = data.Name;
            tempDiagnosis.ObjectID = data.ObjectID;
            that.doctorPerformanceRuleOperationViewModel.SelectedRule.DiagnosisList.push(tempDiagnosis);

            window.setTimeout(t => {
                if (that.selectedDiagnosisByAdding === null)
                    that.selectedDiagnosisByAdding = undefined;
                else
                    that.selectedDiagnosisByAdding = null;
                that.detector.tick();
            }, 0);
        }
    }

    selectedSpecialityByAdding: any;
    specialitySelection_ValueChanged(data: any): void {
        let that = this;
        if (data != null && data != undefined) {
            let tempSpeciality: SpecialityModelForRule = new SpecialityModelForRule();
            tempSpeciality.Code = data.Code;
            tempSpeciality.Name = data.Name;
            tempSpeciality.ObjectID = data.ObjectID;
            tempSpeciality.BannOrMustType = 0;
            that.doctorPerformanceRuleOperationViewModel.SelectedRule.SpecialityList.push(tempSpeciality);

            window.setTimeout(t => {
                if (that.selectedSpecialityByAdding === null)
                    that.selectedSpecialityByAdding = undefined;
                else
                    that.selectedSpecialityByAdding = null;
                that.detector.tick();
            }, 0);
        }
    }


    btnSaveRuleClicked(): void {
        let that = this;
        let apiUrlForSave: string = "/api/DoctorPerformanceApi/saveDPRule?code=" + this.doctorPerformanceRuleOperationViewModel.SelectedItem.Code;
        this.loadPanelOperation(true,   "Kural detayları kayıt ediliyor, lütfen bekleyiniz.");

        this.http.post<boolean>(apiUrlForSave, this.doctorPerformanceRuleOperationViewModel.SelectedRule).then(response => {

            if (response)
            {
                that.getGILDefinitions();
                that.doctorPerformanceRuleOperationViewModel.SelectedItem.HasRule = true;
                that.loadPanelOperation(false, "");
                ServiceLocator.MessageService.showSuccess("Kural kayıt işlemi başarı ile tamamlandı.");
            }
        }).catch(error => {
            this.errorHandlerForDPRuleOperation(error);
            });

    }

    btnDeleteRuleClicked(): void {
        let that = this;
        let apiUrlForSave: string = "/api/DoctorPerformanceApi/deleteDPRule";
        this.loadPanelOperation(true,   "Kural detayları siliniyor, lütfen bekleyiniz.");

        this.http.post<boolean>(apiUrlForSave, this.doctorPerformanceRuleOperationViewModel.SelectedItem).then(response => {

            if (response)
            {
                that.getGILDefinitions();
                that.doctorPerformanceRuleOperationViewModel.SelectedItem.HasRule = false;
                that.loadPanelOperation(false, "");
                ServiceLocator.MessageService.showSuccess("Kural silme işlemi başarı ile tamamlandı.");
            }
        }).catch(error => {
            this.errorHandlerForDPRuleOperation(error);
            });
    }

    generateAllRuleColumns(): void {
        let that = this;
        this.DPRuleMasterColumns = [
            {
                caption: 'Kodu',
                dataField: 'Code',
                dataType: 'string',
                width: '15%'
            },
            {
                caption: 'Adı',
                dataField: 'Name',
                dataType: 'string',
                width: '75%'
            },
            {
                caption: 'Puan',
                dataField: 'Point',
                dataType: 'string',
                width: '10%'
            },
            {
                caption: 'Kural',
                dataField: 'HasRule',
                lookup: { dataSource: that.hasRuleArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                width: '10%'
            }];

        this.DPRuleProcedureColumns = [
            {
                caption: 'Kodu',
                dataField: 'Code',
                dataType: 'string',
                allowEditing: false
            },
            {
                caption: 'Adı',
                dataField: 'Name',
                dataType: 'string',
                allowEditing: false

            },
            {
                caption: 'Tip',
                dataField: 'BannOrMustType',
                dataType: 'number',
                lookup: { dataSource: that.bannOrMustTypeArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                allowEditing: true
            },
            {
                caption: 'Kapsam',
                dataField: 'TimeType',
                dataType: 'number',
                lookup: { dataSource: that.timeTypeArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                allowEditing: true
            }];

        this.DPRuleSpecialtyColumns = [
            {
                caption: 'Kodu',
                dataField: 'Code',
                dataType: 'string',
                allowEditing: false
            },
            {
                caption: 'Adı',
                dataField: 'Name',
                dataType: 'string',
                allowEditing: false
            },
            {
                caption: 'Tip',
                dataField: 'BannOrMustType',
                dataType: 'number',
                lookup: { dataSource: that.bannOrMustTypeArray, valueExpr: 'ObjectID', displayExpr: 'Name' },
                allowEditing: true
            }];
        this.DPRuleDiagnosisColumns = [
            {
                caption: 'Kodu',
                dataField: 'Code',
                dataType: 'string'

            },
            {
                caption: 'Adı',
                dataField: 'Name',
                dataType: 'string'

            }];
        this.DPRuleQueryColumns = [
            {
                caption: 'Script',
                dataField: 'Script',
                dataType: 'string',
                width: '60%'

            },
            {
                caption: 'Kural Adı',
                dataField: 'RuleName',
                dataType: 'string',
                width: '15%'

            },
            {
                caption: 'Oran',
                dataField: 'PointPercentage',
                dataType: 'number',
                width: '10%'
            },
            {
                caption: 'Sonuç',
                dataField: 'ResultMessage',
                dataType: 'string',
                width: '15%'
            }];
    }

    EditingConfig: any = {
        mode: 'cell',
        allowUpdating: true,
        allowAdding: false,
        allowDeleting: true,
    };
    EditingConfig2: any = {
        mode: 'form',
        allowUpdating: true,
        allowAdding: true,
        allowDeleting: true,
    };

    errorHandlerForDPRuleOperation(message: string): void {
        this.loadPanelOperation(false, '');
        ServiceLocator.MessageService.showError(message);
        console.log(message);
    }
    onRowPreparedGILDefinitionList(e: any): void {
        let i = 0;
        for (i = 0; i < e.columns.length; i++) {
            if (e.columns[i].dataField == "Code") {
                break;
            }
        }

        if (e.rowElement.firstItem() != undefined && e.rowType != 'header' && e.rowType != 'filter')
        {
            let data: GILDefinitionDTO = e.data as GILDefinitionDTO;
            let hasRole = data.HasRule;
            if (e.rowElement.firstItem().cells[i] != null && e.rowElement.firstItem().cells[i] != undefined) {
                if (hasRole)
                {
                    e.rowElement.firstItem().cells[i].bgColor = '#009acd';
                }
            }
        }
    }
}