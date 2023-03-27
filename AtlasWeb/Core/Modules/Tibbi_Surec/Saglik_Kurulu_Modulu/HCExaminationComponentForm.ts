//$2249D86F
import { Component, Input, EventEmitter, Output, ComponentRef, ViewChild } from '@angular/core';
import { HCExaminationComponentFormViewModel } from './HCExaminationComponentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { HCExaminationComponent, CozgerSpecReqLevel, CozgerSpecReqArea, HCExaminationDisabledRatio } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { DynamicComponentInfoDVO } from 'app/Logistic/Models/LogisticDashboardViewModel';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { BaseHCExaminationDynamicObjectForm } from 'Modules/Tibbi_Surec/Saglik_Kurulu_Modulu/BaseHCExaminationDynamicObjectForm';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';

@Component({
    selector: 'HCExaminationComponentForm',
    templateUrl: './HCExaminationComponentForm.html',
    providers: [MessageService]
})
export class HCExaminationComponentForm extends TTVisual.TTForm {
    /*Çözger */
    CozgerSpecReqAreaList: TTVisual.ITTObjectListBox;
    CozgerSpecReqLevelList: TTVisual.ITTObjectListBox;

    /*Çözger */
    DisabledRatio: TTVisual.ITTTextBox;
    Height: TTVisual.ITTTextBox;
    IsHealthy: TTVisual.ITTCheckBox;
    labelDisabledRatio: string;
    labelHeight: TTVisual.ITTLabel;
    labelNumberOfProcess: TTVisual.ITTLabel;
    labelOfferOfDecision: TTVisual.ITTLabel;
    labelReasonForExamination: TTVisual.ITTLabel;
    labelReport: TTVisual.ITTLabel;
    labelReportDate: TTVisual.ITTLabel;
    labelWeight: TTVisual.ITTLabel;
    NumberOfProcess: TTVisual.ITTTextBox;
    OfferOfDecision: TTVisual.ITTTextBox;
    ReasonForExamination: TTVisual.ITTObjectListBox;
    ReportDate: TTVisual.ITTDateTimePicker;
    ttCLINICALINFO: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttLABORATORYINFO: TTVisual.ITTTextBox;
    ttRADIOLOGICALINFO: TTVisual.ITTTextBox;
    ttrichtextboxcontrol1: TTVisual.ITTRichTextBoxControl;
    ttTREATMENTINFO: TTVisual.ITTTextBox;
    Weight: TTVisual.ITTTextBox;

    @Output() SendDisabledRatios: EventEmitter<Array<HCExaminationDisabledRatio>> = new EventEmitter<Array<HCExaminationDisabledRatio>>();
    @ViewChild('disabledRatioGrid') disabledRatioGrid: DxDataGridComponent;

    /*Engel Oranı PopUp*/
    public enteredDisabledRatio: number = 0;
    public disabledRatiosPopUpVisible: boolean = false;

    public disabledRatiosGridColumns = [
        {
            caption: 'Engel Oranı',
            dataField: 'DisabledRatio',
            allowEditing: true
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: '50',
            cellTemplate: 'deleteCellTemplate'
        }
    ]
    /*Engel Oranı PopUp */
    public hCExaminationComponentFormViewModel: HCExaminationComponentFormViewModel = new HCExaminationComponentFormViewModel();
    public componentBaseHCEInfoObject: DynamicComponentInfo;
    private _isFormReadOnly: boolean = false;
    @Input() set hcExaminationComponent(value: HCExaminationComponent) {

        this._TTObject = value;
        if (value != undefined) {
            this.ObjectID = value.ObjectID;
            this.hCExaminationComponentFormViewModel = new HCExaminationComponentFormViewModel();
            this._ViewModel = this.hCExaminationComponentFormViewModel;
            this.hCExaminationComponentFormViewModel._HCExaminationComponent = this._TTObject as HCExaminationComponent;
            if (this.hCExaminationComponentFormViewModel._HCExaminationComponent != null && this.hCExaminationComponentFormViewModel._HCExaminationComponent.ObjectID != null) {
                this.loadListDefinitions();

            }
            if(this.hCExaminationComponentFormViewModel.IsCozger == true){
                this.CozgerSpecReqAreaList.ListFilterExpression = this.hCExaminationComponentFormViewModel.CozgerListFilterExpression;
                this.sendIsCozger.emit(true);
            }else{
                this.sendIsCozger.emit(false);
            }
            
            this.orderRatioList();
            this.SendDisabledRatios.emit(this.hCExaminationComponentFormViewModel.HCExaminationDisabledRatios);
        }
    }
    public get _HCExaminationComponent(): HCExaminationComponent {
        return this._TTObject as HCExaminationComponent;
    }

    //@Input() set height(value: number) {
    //    if (value != null)
    //        this.hCExaminationComponentFormViewModel.Height = value;
    //}
    @Output() sendHeight: EventEmitter<number> = new EventEmitter<number>();
    @Output() sendIsCozger: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Output() sendWeight: EventEmitter<number> = new EventEmitter<number>();
    @Output() sendBaseHCExaminationDynamicObjectFormViewModel: EventEmitter<ComponentRef<any>> = new EventEmitter<ComponentRef<any>>();

    @Input() set weight(value: number) {
        if (value != null)
            this.hCExaminationComponentFormViewModel.Weight = value;
    }
    get weight(): number {
        return this.hCExaminationComponentFormViewModel.Weight;
    }

    private _baseHCEComponentInfo: DynamicComponentInfoDVO;
    @Input() set baseHCEComponentInfo(value: DynamicComponentInfoDVO) {
        if (value != null)
            this._baseHCEComponentInfo = value;
    }
    get baseHCEComponentInfo(): DynamicComponentInfoDVO {
        return this._baseHCEComponentInfo;
    }

    @Input() set IsFormReadOnly(value: boolean) {
        if (value != null) {
            this._isFormReadOnly = value;
            this.ReadOnly = value;
        }
    }

    get IsFormReadOnly(): boolean {
        return this._isFormReadOnly;
    }

    private HCExaminationComponentForm_DocumentUrl: string = '/api/HCExaminationComponentService/HCExaminationComponentForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('HCEXAMINATIONCOMPONENT', 'HCExaminationComponentForm');
        this._DocumentServiceUrl = this.HCExaminationComponentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    //private _episodeAction: EpisodeAction;
    //@Input() set EpisodeAction(value: EpisodeAction) {
    //    this._episodeAction = value;

    //}
    //get EpisodeAction(): EpisodeAction {
    //    return this._episodeAction;
    //}


    public initViewModel(): void {
        this._TTObject = new HCExaminationComponent();
        this.hCExaminationComponentFormViewModel = new HCExaminationComponentFormViewModel();
        this._ViewModel = this.hCExaminationComponentFormViewModel;
        this.hCExaminationComponentFormViewModel._HCExaminationComponent = this._TTObject as HCExaminationComponent;
        this.hCExaminationComponentFormViewModel._HCExaminationComponent.ReasonForExamination = new ReasonForExaminationDefinition();
        this.hCExaminationComponentFormViewModel._HCExaminationComponent.CozgerSpecReqArea = new CozgerSpecReqArea();
        this.hCExaminationComponentFormViewModel._HCExaminationComponent.CozgerSpecReqLevel = new CozgerSpecReqLevel();

        //let apiUrlForResourceExists: string = '/api/HealthCommitteeService/IsDisabledReport';
        //this.hCExaminationFormViewModel.IsDisabled = <boolean>await this.httpService.get(apiUrlForResourceExists);
    }

    protected loadViewModel() {
        let that = this;

        that.hCExaminationComponentFormViewModel = this._ViewModel as HCExaminationComponentFormViewModel;
        that._TTObject = this.hCExaminationComponentFormViewModel._HCExaminationComponent;
        if (this.hCExaminationComponentFormViewModel == null)
            this.hCExaminationComponentFormViewModel = new HCExaminationComponentFormViewModel();
        if (this.hCExaminationComponentFormViewModel._HCExaminationComponent == null)
            this.hCExaminationComponentFormViewModel._HCExaminationComponent = new HCExaminationComponent();
        if (!this.ReadOnly) {
            this._ViewModel.ReadOnly = this._isFormReadOnly;
            this.ReadOnly = this._isFormReadOnly;
        }

       
    }

    protected async PreScript() {
        super.PreScript();

    }

    public async loadListDefinitions() {
        let that = this;
        // let apiUrlLoadListDefinitions: string = '/api/HCExaminationComponentService/HCExaminationComponentForm?id=' + this.hCExaminationComponentFormViewModel._HCExaminationComponent.ObjectID;

        //this.http.get(apiUrlLoadListDefinitions)
        //    .toPromise()
        await this.httpService.get<HCExaminationComponentFormViewModel>("/api/HCExaminationComponentService/HCExaminationComponentForm?id=" + this.hCExaminationComponentFormViewModel._HCExaminationComponent.ObjectID)
            .then(response => {
                let result = <HCExaminationComponentFormViewModel>response;
                let reasonForExaminationObjectID = that.hCExaminationComponentFormViewModel._HCExaminationComponent["ReasonForExamination"];
                if (reasonForExaminationObjectID != null) {
                    that.hCExaminationComponentFormViewModel = result;
                    let reasonForExamination = that.hCExaminationComponentFormViewModel.ReasonForExaminationDefinitions.find(o => o.ObjectID.toString() === reasonForExaminationObjectID.toString());
                    that.hCExaminationComponentFormViewModel._HCExaminationComponent.ReasonForExamination = reasonForExamination;
                    if (!that.hCExaminationComponentFormViewModel.IsDisabled) {
                        that.DisabledRatio.Visible = false;
                        that.IsHealthy.Visible = false;
                        that.labelDisabledRatio = "";
                    }
                    else {
                        that.DisabledRatio.Visible = true;
                        that.IsHealthy.Visible = true;
                        that.labelDisabledRatio = i18n("M13731", "Engel Oranı");
                    }
                }
                let cozgerSpecReqAreaObjectID = that.hCExaminationComponentFormViewModel._HCExaminationComponent["CozgerSpecReqArea"];
                if (cozgerSpecReqAreaObjectID != null) {
                    that.hCExaminationComponentFormViewModel = result;
                    let cozgerSpecReqArea = that.hCExaminationComponentFormViewModel.CozgerSpecReqAreas.find(o => o.ObjectID.toString() === cozgerSpecReqAreaObjectID.toString());
                    that.hCExaminationComponentFormViewModel._HCExaminationComponent.CozgerSpecReqArea = cozgerSpecReqArea;
                }
                let cozgerSpecReqLevelObjectID = that.hCExaminationComponentFormViewModel._HCExaminationComponent["CozgerSpecReqLevel"];
                if (cozgerSpecReqLevelObjectID != null) {
                    that.hCExaminationComponentFormViewModel = result;
                    let cozgerSpecReqLevel = that.hCExaminationComponentFormViewModel.CozgerSpecReqLevels.find(o => o.ObjectID.toString() === cozgerSpecReqLevelObjectID.toString());
                    that.hCExaminationComponentFormViewModel._HCExaminationComponent.CozgerSpecReqLevel = cozgerSpecReqLevel;
                }

                if(that.hCExaminationComponentFormViewModel.IsCozger == true){
                    that.CozgerSpecReqAreaList.ListFilterExpression = that.hCExaminationComponentFormViewModel.CozgerListFilterExpression;
                    that.sendIsCozger.emit(true);
                }else{
                    that.sendIsCozger.emit(false);
                }
                that.orderRatioList();
        
                that.SendDisabledRatios.emit(that.hCExaminationComponentFormViewModel.HCExaminationDisabledRatios);
            })
            .catch(error => {
                console.log(error);
            });
    }
    //async ngOnInit() {
    //    await this.load();
    //}

    public openDisabledRatioPopUp() {
        this.orderRatioList();
        if (this.disabledRatioGrid != null)
            this.disabledRatioGrid.instance.refresh();
        this.disabledRatiosPopUpVisible = true;

    }

    public addNewDisabledRatio() {
        if (this.enteredDisabledRatio != null) {
            let newDisabledRatio: HCExaminationDisabledRatio = new HCExaminationDisabledRatio();
            newDisabledRatio.HCExaminationComponent = this.hCExaminationComponentFormViewModel._HCExaminationComponent;
            newDisabledRatio.DisabledRatio = this.enteredDisabledRatio.toString();

            this.hCExaminationComponentFormViewModel.HCExaminationDisabledRatios.push(newDisabledRatio);
            this.orderRatioList();
            this.hCExaminationComponentFormViewModel._HCExaminationComponent.DisabledRatio = this.calculateBalthazard();
            this.SendDisabledRatios.emit(this.hCExaminationComponentFormViewModel.HCExaminationDisabledRatios);
            this.enteredDisabledRatio = 0;
        } else {
            ServiceLocator.MessageService.showError("Boş engel oranı eklenemez!");
            return;
        }
    }

    public orderRatioList() {
        this.hCExaminationComponentFormViewModel.HCExaminationDisabledRatios.sort((a, b) => {
            if (+a.DisabledRatio < +b.DisabledRatio)
                return 1;
            if (+a.DisabledRatio > +b.DisabledRatio)
                return -1;
            return 0;
        });
    }

    public calculateBalthazard(): number {
        let disabledRatioList = this.hCExaminationComponentFormViewModel.HCExaminationDisabledRatios.filter(x => x.EntityState != 1);

        if (disabledRatioList.length == 1) {
            return +disabledRatioList[0].DisabledRatio;
        } else if (disabledRatioList.length == 2) {
            let firstRatio = +disabledRatioList[0].DisabledRatio;
            let secondRatio = +disabledRatioList[1].DisabledRatio;
            let balthazardVal = this.getFormulaValue(firstRatio, secondRatio);
            return balthazardVal;
        } else if (disabledRatioList.length > 2) {
            let balthazardVal = this.getFormulaValue(+disabledRatioList[0].DisabledRatio, +disabledRatioList[1].DisabledRatio);
            for (let index = 2; index < disabledRatioList.length; index++) {
                balthazardVal = this.getFormulaValue(balthazardVal, +disabledRatioList[index].DisabledRatio);
            }
            return balthazardVal;
        } else {
            return 0;
        }
    }

    public getFormulaValue(firstRatio: number, secondRatio) {
        return (Math.round(((100 - firstRatio) * secondRatio) / 100)) + firstRatio;

    }

    onRowDeletingDisabledRatio(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    if (data.row.key.IsNew) {
                        this.disabledRatioGrid.instance.deleteRow(data.rowIndex);
                    }
                    else {
                        data.key.EntityState = EntityStateEnum.Deleted;
                        this.disabledRatioGrid.instance.filter(['EntityState', '<>', 1]);
                        this.disabledRatioGrid.instance.refresh();
                    }
                }
                this.orderRatioList();
                this.hCExaminationComponentFormViewModel._HCExaminationComponent.DisabledRatio = this.calculateBalthazard();
                this.SendDisabledRatios.emit(this.hCExaminationComponentFormViewModel.HCExaminationDisabledRatios);
            }
        }
    }

    public onHeightChanged(event): void {
        if(event != null){
            let eventVal = +event;
            if (eventVal < 0) {
                ServiceLocator.MessageService.showError("Boy değeri 0 dan küçük olamaz");
                this.hCExaminationComponentFormViewModel.Height = null;
                return;
            }
        }
        
        if (this.hCExaminationComponentFormViewModel != null && this.hCExaminationComponentFormViewModel.Height != event) {
            this.sendHeight.emit(event);
        }

    }
    public onWeightChanged(event): void {
        if(event != null){
            let eventVal = +event;
            if (eventVal < 0) {
                ServiceLocator.MessageService.showError("Kilo değeri 0 dan küçük olamaz");
                this.hCExaminationComponentFormViewModel.Weight = null;
                return;
            } 
        }
        
        if (this.hCExaminationComponentFormViewModel != null && this.hCExaminationComponentFormViewModel.Weight != event) {
            this.sendWeight.emit(event);
        }

    }
    public onDisabledRatioChanged(event): void {
        if (event != null) {
            if (!Number.isInteger(event)) {
                ServiceLocator.MessageService.showError("Bu alana sadece rakam girebilirsiniz!");
                return;
            }
            if (this._HCExaminationComponent != null && this._HCExaminationComponent.DisabledRatio != event) {
                this._HCExaminationComponent.DisabledRatio = event;
            }
        }
    }

    public onIsHealthyChanged(event): void {
        if (event != null) {
            if (this._HCExaminationComponent != null && this._HCExaminationComponent.IsHealthy != event) {
                this._HCExaminationComponent.IsHealthy = event;
            }
        }
    }

    public onNumberOfProcessChanged(event): void {
        if (event != null) {
            if (this._HCExaminationComponent != null && this._HCExaminationComponent.NumberOfProcess != event) {
                this._HCExaminationComponent.NumberOfProcess = event;
            }
        }
    }

    public onOfferOfDecisionChanged(event): void {
        if (event != null) {
            if (this._HCExaminationComponent != null && this._HCExaminationComponent.OfferOfDecision != event) {
                this._HCExaminationComponent.OfferOfDecision = event;
            }
        }
    }

    public onttCLINICALINFOChanged(event): void {
        if (this._HCExaminationComponent != null && this._HCExaminationComponent.ClinicalInfo != event) {
            this._HCExaminationComponent.ClinicalInfo = event;
        }
    }

    public onReasonForExaminationChanged(event): void {
        if (event != null) {
            if (this._HCExaminationComponent != null && this._HCExaminationComponent.ReasonForExamination != event) {
                this._HCExaminationComponent.ReasonForExamination = event;
            }
        }
    }

    public onCozgerSpecReqAreaListChanged(event): void {
        if (event != null) {
            if (this._HCExaminationComponent != null && this._HCExaminationComponent.CozgerSpecReqArea != event) {
                this._HCExaminationComponent.CozgerSpecReqArea = event;
            }
        }
    }

    public onCozgerSpecReqLevelListChanged(event): void {
        if (event != null) {
            if (this._HCExaminationComponent != null && this._HCExaminationComponent.CozgerSpecReqLevel != event) {
                this._HCExaminationComponent.CozgerSpecReqLevel = event;
            }
        }
    }

    public onReportDateChanged(event): void {
        if (event != null) {
            if (this._HCExaminationComponent != null && this._HCExaminationComponent.ReportDate != event) {
                this._HCExaminationComponent.ReportDate = event;
            }
        }
    }

    public onttLABORATORYINFOChanged(event): void {
        if (this._HCExaminationComponent != null && this._HCExaminationComponent.LaboratoryInfo != event) {
            this._HCExaminationComponent.LaboratoryInfo = event;
        }
    }

    public onttRADIOLOGICALINFOChanged(event): void {
        if (this._HCExaminationComponent != null && this._HCExaminationComponent.RadiologicalInfo != event) {
            this._HCExaminationComponent.RadiologicalInfo = event;
        }
    }

    public onttrichtextboxcontrol1Changed(event): void {
        if (this._HCExaminationComponent != null && this._HCExaminationComponent.Report != event) {
            this._HCExaminationComponent.Report = event;
        }
    }

    public onttTREATMENTINFOChanged(event): void {
        if (this._HCExaminationComponent != null && this._HCExaminationComponent.TreatmentInfo != event) {
            this._HCExaminationComponent.TreatmentInfo = event;
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.ReportDate, "Value", this.__ttObject, "ReportDate");
        redirectProperty(this.NumberOfProcess, "Text", this.__ttObject, "NumberOfProcess");
        redirectProperty(this.IsHealthy, "Value", this.__ttObject, "IsHealthy");
        redirectProperty(this.OfferOfDecision, "Text", this.__ttObject, "OfferOfDecision");
        redirectProperty(this.ttTREATMENTINFO, "Text", this.__ttObject, "TreatmentInfo");
        redirectProperty(this.ttCLINICALINFO, "Text", this.__ttObject, "ClinicalInfo");
        redirectProperty(this.ttRADIOLOGICALINFO, "Text", this.__ttObject, "RadiologicalInfo");
        redirectProperty(this.ttLABORATORYINFO, "Text", this.__ttObject, "LaboratoryInfo");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "Report");
        redirectProperty(this.DisabledRatio, "Text", this.__ttObject, "DisabledRatio");
    }

    public initFormControls(): void {
        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 11;

        this.labelReasonForExamination = new TTVisual.TTLabel();
        this.labelReasonForExamination.Text = i18n("M19428", "Ne Maksatla Muayene Edildiği");
        this.labelReasonForExamination.Name = "labelReasonForExamination";
        this.labelReasonForExamination.TabIndex = 18;

        this.ReasonForExamination = new TTVisual.TTObjectListBox();
        this.ReasonForExamination.ReadOnly = true;
        this.ReasonForExamination.ListDefName = "HealthCommitteeExaminationReasonListDefinition";
        this.ReasonForExamination.Name = "ReasonForExamination";
        this.ReasonForExamination.TabIndex = 17;
        this.ReasonForExamination.Enabled = true;

        this.CozgerSpecReqAreaList = new TTVisual.TTObjectListBox();
        this.CozgerSpecReqAreaList.ListDefName = "CozgerSpecReqAreaListDef";
        this.CozgerSpecReqAreaList.Name = "CozgerSpecReqAreaList";
        this.CozgerSpecReqAreaList.TabIndex = 17;
        this.CozgerSpecReqAreaList.Enabled = true;

        this.CozgerSpecReqLevelList = new TTVisual.TTObjectListBox();
        this.CozgerSpecReqLevelList.ListDefName = "CozgerSpecReqLevelListDef";
        this.CozgerSpecReqLevelList.Name = "CozgerSpecReqLevelList";
        this.CozgerSpecReqLevelList.TabIndex = 17;
        this.CozgerSpecReqLevelList.Enabled = true;

        this.labelWeight = new TTVisual.TTLabel();
        this.labelWeight.Text = "Kilo";
        this.labelWeight.Name = "labelWeight";
        this.labelWeight.TabIndex = 16;

        this.Weight = new TTVisual.TTTextBox();
        this.Weight.Name = "Weight";
        this.Weight.TabIndex = 15;

        this.OfferOfDecision = new TTVisual.TTTextBox();
        this.OfferOfDecision.Multiline = true;
        this.OfferOfDecision.Name = "OfferOfDecision";
        this.OfferOfDecision.TabIndex = 9;

        this.NumberOfProcess = new TTVisual.TTTextBox();
        this.NumberOfProcess.Name = "NumberOfProcess";
        this.NumberOfProcess.TabIndex = 7;

        this.Height = new TTVisual.TTTextBox();
        this.Height.Name = "Height";
        this.Height.TabIndex = 4;        

        this.DisabledRatio = new TTVisual.TTTextBox();
        this.DisabledRatio.Name = "DisabledRatio";
        this.DisabledRatio.TabIndex = 0;

        this.ttTREATMENTINFO = new TTVisual.TTTextBox();
        this.ttTREATMENTINFO.Multiline = true;
        this.ttTREATMENTINFO.Name = "ttTREATMENTINFO";
        this.ttTREATMENTINFO.TabIndex = 9;

        this.ttCLINICALINFO = new TTVisual.TTTextBox();
        this.ttCLINICALINFO.Multiline = true;
        this.ttCLINICALINFO.Name = "ttCLINICALINFO";
        this.ttCLINICALINFO.TabIndex = 9;

        this.ttRADIOLOGICALINFO = new TTVisual.TTTextBox();
        this.ttRADIOLOGICALINFO.Multiline = true;
        this.ttRADIOLOGICALINFO.Name = "ttRADIOLOGICALINFO";
        this.ttRADIOLOGICALINFO.TabIndex = 9;

        this.ttLABORATORYINFO = new TTVisual.TTTextBox();
        this.ttLABORATORYINFO.Multiline = true;
        this.ttLABORATORYINFO.Name = "ttLABORATORYINFO";
        this.ttLABORATORYINFO.TabIndex = 9;
        this.labelReportDate = new TTVisual.TTLabel();
        this.labelReportDate.Text = i18n("M20864", "Rapor Tarihi");
        this.labelReportDate.Name = "labelReportDate";
        this.labelReportDate.TabIndex = 14;

        this.ReportDate = new TTVisual.TTDateTimePicker();
        this.ReportDate.Format = DateTimePickerFormat.Long;
        this.ReportDate.Name = "ReportDate";
        this.ReportDate.TabIndex = 13;

        this.labelReport = new TTVisual.TTLabel();
        this.labelReport.Text = "Rapor";
        this.labelReport.Name = "labelReport";
        this.labelReport.TabIndex = 12;

        this.labelOfferOfDecision = new TTVisual.TTLabel();
        this.labelOfferOfDecision.Text = i18n("M17285", "Karar Teklifi");
        this.labelOfferOfDecision.Name = "labelOfferOfDecision";
        this.labelOfferOfDecision.TabIndex = 10;

        this.labelNumberOfProcess = new TTVisual.TTLabel();
        this.labelNumberOfProcess.Text = i18n("M19158", "Muamele Sayısı");
        this.labelNumberOfProcess.Name = "labelNumberOfProcess";
        this.labelNumberOfProcess.TabIndex = 8;

        this.IsHealthy = new TTVisual.TTCheckBox();
        this.IsHealthy.Value = false;
        this.IsHealthy.Title = i18n("M21160", "Sağlam");
        this.IsHealthy.Name = "IsHealthy";
        this.IsHealthy.TabIndex = 6;

        this.labelHeight = new TTVisual.TTLabel();
        this.labelHeight.Text = "Boy";
        this.labelHeight.Name = "labelHeight";
        this.labelHeight.TabIndex = 5;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Tedavi Bilgileri";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 10;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Klinik Bulgular";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 10;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Radyoloji Bulgular";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 10;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Laboratuvar Bulgular";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 10;
        this.Controls = [this.ttrichtextboxcontrol1, this.labelReasonForExamination, this.ReasonForExamination, this.labelWeight, this.Weight, this.OfferOfDecision, this.NumberOfProcess, this.Height, this.DisabledRatio, this.ttTREATMENTINFO, this.ttCLINICALINFO, this.ttRADIOLOGICALINFO, this.ttLABORATORYINFO, this.labelReportDate, this.ReportDate, this.labelReport, this.labelOfferOfDecision, this.labelNumberOfProcess, this.IsHealthy, this.labelHeight, this.ttlabel1, this.ttlabel2, this.ttlabel3, this.ttlabel4];

    }


    /*Begin DİNAMİKL EK ALANLAR*/

    // BaseHCExaminationDynamicObject den oluşan ek alanların gönderdiği View Modeli Yakalar
    public onSubscribeToBaseHCExaminationDynamicObjectViewModel(componentRef: ComponentRef<any>): void {

        let baseHCExaminationDynamicObjectForm = componentRef.instance as BaseHCExaminationDynamicObjectForm;
        let boundedFunc = this.postBaseHCExaminationDynamicObjectFormViewModel.bind(this);
        baseHCExaminationDynamicObjectForm.sendMyViewModel.subscribe(boundedFunc);

    }
    // Yakalanan ViewModeli PetientExaminationa ye paslar
    public postBaseHCExaminationDynamicObjectFormViewModel(e: any) {

        this.sendBaseHCExaminationDynamicObjectFormViewModel.emit(e);
    }
    /*ENd DİNAMİK EK ALANLKAR*/

}
