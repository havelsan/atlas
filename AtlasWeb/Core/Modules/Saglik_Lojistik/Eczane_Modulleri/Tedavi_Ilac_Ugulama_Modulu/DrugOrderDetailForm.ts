//$E5208C12
import { Component, OnInit, NgZone } from '@angular/core';
import { DrugOrderDetailFormViewModel } from './DrugOrderDetailFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderDetailService, PatientFullNameInfo_Input, PatientFullNameInfo_Output, GetExecutionUser_Output } from 'ObjectClassService/DrugOrderDetailService';
import { CommonService } from 'ObjectClassService/CommonService';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionService, ValidationPatientAgeAndMaterialAgeBand_Output } from "NebulaClient/Services/ObjectService/DrugOrderIntroductionService";
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { SortByEnum } from 'NebulaClient/Utils/Enums/SortByEnum';

@Component({
    selector: 'DrugOrderDetailForm',
    templateUrl: './DrugOrderDetailForm.html',
    providers: [MessageService]
})
export class DrugOrderDetailForm extends TTVisual.TTForm implements OnInit, IModal {
    ActionDate: TTVisual.ITTDateTimePicker;
    Amount: TTVisual.ITTTextBox;
    ApplicationDate: TTVisual.ITTDateTimePicker;
    DoseAmount: TTVisual.ITTTextBox;
    Frequency: TTVisual.ITTEnumComboBox;
    ID: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelAmount: TTVisual.ITTLabel;
    labelDoseAmount: TTVisual.ITTLabel;
    labelFrequency: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelMaterial: TTVisual.ITTLabel;
    labelSDateTime: TTVisual.ITTLabel;
    labelUsageNote: TTVisual.ITTLabel;
    Material: TTVisual.ITTObjectListBox;
    RestDose: TTVisual.ITTTextBox;
    Stage: TTVisual.ITTTextBox;
    DrugUsageType: TTVisual.ITTEnumComboBox;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    tttextbox1: TTVisual.ITTTextBox;
    UsageNote: TTVisual.ITTTextBox;
    public patientFullName: string;
    public showDrugDone: boolean = false;
    public himssIntegrated: string;
    public IsCompleted: boolean = false;
    public ExecutionFullName: string;
    public ExecutionDate: Date;

    public drugOrderDetailFormViewModel: DrugOrderDetailFormViewModel = new DrugOrderDetailFormViewModel();
    public formDefName = 'DrugOrderDetailForm';
    public get _DrugOrderDetail(): DrugOrderDetail {
        return this._TTObject as DrugOrderDetail;
    }
    private DrugOrderDetailForm_DocumentUrl: string = '/api/DrugOrderDetailService/DrugOrderDetailForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private objectContextService: ObjectContextService,
        private modalStateService: ModalStateService,
        protected ngZone: NgZone) {
        super('DRUGORDERDETAIL', 'DrugOrderDetailForm');
        this._DocumentServiceUrl = this.DrugOrderDetailForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        if (value) {
            value.Title = i18n("M15638", "Uygulama");
            value.Width = 800;
            value.Height = 400;
        }
        this._modalInfo = value;
    }

    public setInputParam(value: Object) {
        if (value != null) {
            this.ObjectID = new Guid(value.toString());
        }
    }

    // ***** Method declarations start *****
    public CurrentStateIsComplated: boolean = false;


    public async UndoLastTransition_SelectedDrugOrderDetailAction() {
        let that = this;
        let _DocumentServiceUrl: string = "/api/MainPatientFolderService/UndoLastTransitionDruOrderDetailByObjectId?ObjectId=" + this._DrugOrderDetail.ObjectID.toString();
        this.httpService.get<any>(_DocumentServiceUrl)
            .then(result => {
                this.cancel();
            }).catch(err => {
                ServiceLocator.MessageService.showError(i18n("M16843", "İşlem geri alınamamıştır.") + err);
            });
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        let nowTime: Date = await CommonService.RecTime();
        if (this._DrugOrderDetail.OrderPlannedDate > nowTime && transDef.ToStateDefID != DrugOrderDetail.DrugOrderDetailStates.Cancel) {
            if (this._DrugOrderDetail.OrderPlannedDate.ToShortDateString() !== nowTime.ToShortDateString()) {
                throw new TTException(i18n("M24754", "Zamanı gelmemiş uygulamayı uygulayamazsınız."));
            }
        }
    }

    public IsWarning: boolean = true;
    public WarningMessage: string = "Uyarı : ";
    protected async PreScript() {
        super.PreScript();
        let drugOrderDetail: DrugOrderDetail = this._DrugOrderDetail;
        await this.loadStateButton(drugOrderDetail);

        if (this._DrugOrderDetail != null) {
            let materialObjectID: string = this._DrugOrderDetail.Material.ObjectID.toString();
            let episodeObjectID: string = this._DrugOrderDetail.Episode.ObjectID.toString();


            let AgeValidation: ValidationPatientAgeAndMaterialAgeBand_Output = await DrugOrderIntroductionService.GetValidationPatientAgeAndMaterialAgeBand(episodeObjectID, materialObjectID);
            let MaxAgeValidate: boolean = true;
            let MinAgeValidate: boolean = true;

            if (AgeValidation.MaterialMaxAge != null && AgeValidation.MaterialMaxAge < AgeValidation.PatientAge) {
                MaxAgeValidate = false;
            }
            if (AgeValidation.MaterialMinAge != null && AgeValidation.MaterialMinAge > AgeValidation.PatientAge) {
                MinAgeValidate = false;
            }

            if (MinAgeValidate && MaxAgeValidate) {
                this.IsWarning = false;
                this.WarningMessage = "-";
            }
            else {
                this.IsWarning = true;
                this.WarningMessage = i18n("M24475", "Uygulayacağınız ilaç hastanın yaş aralığı için uygun değildir. Hastanız " + AgeValidation.PatientAge + " yaşında, ilaç için tavsiye edilen yaş aralığı (" + AgeValidation.MaterialMinAge + ")-(" + AgeValidation.MaterialMaxAge + ")");
            }
        }
        // drugOrderDetail.ActionDate = Date.Now;
        // let drugDefinition: DrugDefinition = (<DrugDefinition>drugOrderDetail.Material);
        // let drugType: boolean = (await DrugOrderService.GetDrugUsedType(drugDefinition));
        // let restDose: number = (await DrugOrderTransactionService.GetRestDose(drugOrderDetail.DrugOrder));
        // let dose: number = 0;
        // if (restDose > 0) {
        //     dose = restDose;
        // }
        // else {
        //     /*let patientRestDictionary: Dictionary<Object, number> = (await DrugOrderTransactionService.GetPatientRestDose(drugOrderDetail.Material, drugOrderDetail.Episode));
        //     for (let restDic of patientRestDictionary) {
        //         dose += <number>restDic.Value;
        //     }*/
        // }
        // this.RestDose.Text = dose.toString();
        this.himssIntegrated = (await SystemParameterService.GetParameterValue('HIMSSINTEGRATED', 'TRUE'));
        if (this.himssIntegrated === 'TRUE') {
            let masterResourceID: Guid = <any>this._DrugOrderDetail['MasterResource'];
            let masterResource: ResSection = await this.objectContextService.getObject<ResSection>(masterResourceID, ResSection.ObjectDefID);
            if (masterResource.HimssRequired !== null && masterResource.HimssRequired !== undefined) {
                if (masterResource.HimssRequired == true) {
                    this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Apply);
                }
            }
        }


    }

    protected async setState(transDef: TTObjectStateTransitionDef) {
        await super.setState(transDef);
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._DrugOrderDetail);
    }

    public showLoadPanel = false;
    protected async save() {
        this.showLoadPanel = true;
        await super.save();
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._DrugOrderDetail);
        this.showLoadPanel = false;
    }

    public cancel() {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DrugOrderDetail();
        this.drugOrderDetailFormViewModel = new DrugOrderDetailFormViewModel();
        this._ViewModel = this.drugOrderDetailFormViewModel;
        this.drugOrderDetailFormViewModel._DrugOrderDetail = this._TTObject as DrugOrderDetail;
        this.drugOrderDetailFormViewModel._DrugOrderDetail.Material = new Material();
        this.drugOrderDetailFormViewModel._DrugOrderDetail.Episode = new Episode();
        this.drugOrderDetailFormViewModel._DrugOrderDetail.Episode.Patient = new Patient();

    }

    async loadStateButton(drugOrderDetail: DrugOrderDetail) {

        let drugType: boolean = await DrugOrderDetailService.GetDrugType(drugOrderDetail.Material.ObjectID);
        if (drugType === false)
            this.showDrugDone = true;

        let IsCompletedOutput: GetExecutionUser_Output = await DrugOrderDetailService.GetExecutionUser(drugOrderDetail.ObjectID.toString());
        this.IsCompleted = IsCompletedOutput.IsCompleted;
        this.ExecutionFullName = IsCompletedOutput.FullName;
        this.ExecutionDate = IsCompletedOutput.ExecutionDate;

        this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.PatientDelivery);
        this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.ReturnPharmacy);
        switch (drugOrderDetail.CurrentStateDefID.toString()) {
            case 'cb22e74b-a2be-456f-8680-660d0b21dc24': // plan
                drugOrderDetail.Stage = i18n("M13466", "Eczaneden İstenmedi!");
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Request);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.UseRestDose);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Apply);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Stop);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Supply);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Cancel);
                break;
            case 'da01e671-efb9-4d84-8122-4bae07e08c20': //İstek
                drugOrderDetail.Stage = i18n("M13465", "Eczaneden İstendi Henüz Karşılanmadı!");
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Supply);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Stop);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Planned);
                break;
            case '94c4b7eb-b764-4ca5-add6-76e2217f7dd4': //Hastanın Üzerinde
                drugOrderDetail.Stage = i18n("M12461", "Daha Önce Karşılanan Doz Kullanılacaktır !!!");
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Planned);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Stop);
                if (!drugType) {
                    this.ttcheckbox1.Visible = true;
                }
                break;
            case 'd4f85132-8d05-4dc7-b9b2-fc04bae622b0': // Karşılandı
                drugOrderDetail.Stage = i18n("M13464", "Eczaneden İstendi Eczane Tarafından Karşılandı!");
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Planned);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Stop);
                if (!drugType) {
                    this.ttcheckbox1.Visible = true;
                }
                break;
            case 'ad54f2c0-8ebe-4fbb-a57a-b7c870fd1fb3': // Eczacılık Bilimlerinden İstendi
                drugOrderDetail.Stage = i18n("M13446", "Eczacılık Bilimlerinden İstendi");
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Supply);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Cancel);
                if (!drugType) {
                    this.ttcheckbox1.Visible = true;
                }
                break;
            case 'f1b24e44-ecb3-4b44-9b23-1d77e9901721': //Durdur
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Supply);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Request);
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Planned);
                break;
            case '14ea4626-5b27-4663-82f9-64968cb4eb63': //Hastaya Teslim
                drugOrderDetail.Stage = i18n("M15127", "Hasta / Hasta Yakınına teslim edildi.");
                break;
            case 'd39a37a6-610e-4143-aca2-691ce5818915': //Uygulandı
                drugOrderDetail.Stage = i18n("M23791", "Uygulandı");
                this.CurrentStateIsComplated = true;
                this.AddStateButton(DrugOrderDetail.DrugOrderDetailStates.Cancel);
                break;
            case 'add6e452-c007-4849-b477-17d30400abe8': //İptal
                this.CurrentStateIsComplated = true;
                drugOrderDetail.Stage = i18n("M23755", "Uygulama İptal Edildi!");
                break;
            case '0586979d-523c-4800-995c-750ac3984606': //Dış Eczane Tarafından Karşılandı
                drugOrderDetail.Stage = i18n("M12723", "Dış Eczane Tarafından Karşılandı");
                this.DropStateButton(DrugOrderDetail.DrugOrderDetailStates.Cancel);
                break;
            default:
                throw new TTException(i18n("M18395", " Lütfen sistem yöneticisine başvurun!!"));
        }
    }

    protected loadViewModel() {
        let that = this;

        that.drugOrderDetailFormViewModel = this._ViewModel as DrugOrderDetailFormViewModel;
        that._TTObject = this.drugOrderDetailFormViewModel._DrugOrderDetail;
        if (this.drugOrderDetailFormViewModel == null)
            this.drugOrderDetailFormViewModel = new DrugOrderDetailFormViewModel();
        if (this.drugOrderDetailFormViewModel._DrugOrderDetail == null)
            this.drugOrderDetailFormViewModel._DrugOrderDetail = new DrugOrderDetail();
        let materialObjectID = that.drugOrderDetailFormViewModel._DrugOrderDetail['Material'];
        if (materialObjectID != null && (typeof materialObjectID === 'string')) {
            let material = that.drugOrderDetailFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
            if (material) {
                that.drugOrderDetailFormViewModel._DrugOrderDetail.Material = material;
            }
        }
        let episodeObjectID = that.drugOrderDetailFormViewModel._DrugOrderDetail['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.drugOrderDetailFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.drugOrderDetailFormViewModel._DrugOrderDetail.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode['Patient'];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.drugOrderDetailFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let url = '/api/DrugOrderDetailService/ControlOfDrugSpecificationDrugOrderDetail?drugObjectID=' + this._DrugOrderDetail.Material.ObjectID;
        this.httpService.get<string>(url).then(message => {
            if (!String.isNullOrEmpty(message))
                TTVisual.InfoBox.Alert(message, MessageIconEnum.ErrorMessage);
        }).catch(error => {
            this.messageService.showError(error);
        });
    }


    async ngOnInit() {
        let that = this;
        await this.load(DrugOrderDetailFormViewModel);
        let input: PatientFullNameInfo_Input = new PatientFullNameInfo_Input();
        input.Episode = this.drugOrderDetailFormViewModel._DrugOrderDetail['Episode'].ObjectID.toString();
        let outputForFullName: PatientFullNameInfo_Output = await DrugOrderDetailService.GetPatientFullNameByEpisode(input);
        this.patientFullName = outputForFullName.FullName;

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null && this._DrugOrderDetail.ActionDate !== event) {
                this._DrugOrderDetail.ActionDate = event;
            }
        }
    }

    public onAmountChanged(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null && this._DrugOrderDetail.Amount !== event) {
                this._DrugOrderDetail.Amount = event;
            }
        }
    }

    public onApplicationDateChanged(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null && this._DrugOrderDetail.OrderPlannedDate !== event) {
                this._DrugOrderDetail.OrderPlannedDate = event;
            }
        }
    }

    public onDoseAmountChanged(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null && this._DrugOrderDetail.DoseAmount !== event) {
                this._DrugOrderDetail.DoseAmount = event;
            }
        }
    }

    public onFrequencyChanged(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null && this._DrugOrderDetail.Frequency !== event) {
                this._DrugOrderDetail.Frequency = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null &&
                this._DrugOrderDetail.Episode != null &&
                this._DrugOrderDetail.Episode.Patient != null && this._DrugOrderDetail.Episode.Patient.PatientIDandFullName !== event) {
                this._DrugOrderDetail.Episode.Patient.PatientIDandFullName = event;
            }
        }
    }

    public onMaterialChanged(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null && this._DrugOrderDetail.Material !== event) {
                this._DrugOrderDetail.Material = event;
            }
        }
    }

    public onStageChanged(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null && this._DrugOrderDetail.Stage !== event) {
                this._DrugOrderDetail.Stage = event;
            }
        }
    }

    public onttcheckbox1Changed(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null && this._DrugOrderDetail.DrugDone !== event) {
                this._DrugOrderDetail.DrugDone = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null && this._DrugOrderDetail.Note !== event) {
                this._DrugOrderDetail.Note = event;
            }
        }
    }

    public onUsageNoteChanged(event): void {
        if (event != null) {
            if (this._DrugOrderDetail != null && this._DrugOrderDetail.UsageNote !== event) {
                this._DrugOrderDetail.UsageNote = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ID, 'Text', this.__ttObject, 'Episode.Patient.PatientIDandFullName');
        redirectProperty(this.ApplicationDate, 'Value', this.__ttObject, 'OrderPlannedDate');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
        redirectProperty(this.Frequency, 'Value', this.__ttObject, 'Frequency');
        redirectProperty(this.DoseAmount, 'Text', this.__ttObject, 'DoseAmount');
        redirectProperty(this.UsageNote, 'Text', this.__ttObject, 'UsageNote');
        redirectProperty(this.Amount, 'Text', this.__ttObject, 'Amount');
        redirectProperty(this.Stage, 'Text', this.__ttObject, 'Stage');
        redirectProperty(this.ttcheckbox1, 'Value', this.__ttObject, 'DrugDone');
        redirectProperty(this.tttextbox1, 'Text', this.__ttObject, 'Note');
        redirectProperty(this.DrugUsageType, 'Value', this.__ttObject, 'DrugUsageType');
    }

    public initFormControls(): void {
        this.labelDoseAmount = new TTVisual.TTLabel();
        this.labelDoseAmount.Text = i18n("M13294", "Doz Miktarı");
        this.labelDoseAmount.BackColor = '#DCDCDC';
        this.labelDoseAmount.ForeColor = '#000000';
        this.labelDoseAmount.Name = 'labelDoseAmount';
        this.labelDoseAmount.TabIndex = 14;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M17082", "Kalan Doz");
        this.ttlabel2.BackColor = '#DCDCDC';
        this.ttlabel2.ForeColor = '#000000';
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 20;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = 'Durum';
        this.ttlabel1.BackColor = '#DCDCDC';
        this.ttlabel1.ForeColor = '#000000';
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 17;

        this.Material = new TTVisual.TTObjectListBox();
        this.Material.ReadOnly = true;
        this.Material.ListDefName = 'DrugList';
        this.Material.Name = 'Material';
        this.Material.TabIndex = 3;

        this.labelFrequency = new TTVisual.TTLabel();
        this.labelFrequency.Text = i18n("M13285", "Doz Aralığı");
        this.labelFrequency.BackColor = '#DCDCDC';
        this.labelFrequency.ForeColor = '#000000';
        this.labelFrequency.Name = 'labelFrequency';
        this.labelFrequency.TabIndex = 13;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = '#F0F0F0';
        this.ID.ReadOnly = true;
        this.ID.Name = 'ID';
        this.ID.TabIndex = 0;

        this.DoseAmount = new TTVisual.TTTextBox();
        this.DoseAmount.BackColor = '#F0F0F0';
        this.DoseAmount.ReadOnly = true;
        this.DoseAmount.Name = 'DoseAmount';
        this.DoseAmount.TabIndex = 5;

        this.UsageNote = new TTVisual.TTTextBox();
        this.UsageNote.BackColor = '#F0F0F0';
        this.UsageNote.ReadOnly = true;
        this.UsageNote.Name = 'UsageNote';
        this.UsageNote.TabIndex = 6;

        this.Stage = new TTVisual.TTTextBox();
        this.Stage.BackColor = '#F0F0F0';
        this.Stage.ReadOnly = true;
        this.Stage.Name = 'Stage';
        this.Stage.TabIndex = 9;

        this.RestDose = new TTVisual.TTTextBox();
        this.RestDose.BackColor = '#F0F0F0';
        this.RestDose.ReadOnly = true;
        this.RestDose.Name = 'RestDose';
        this.RestDose.TabIndex = 7;

        this.Amount = new TTVisual.TTTextBox();
        this.Amount.Name = 'Amount';
        this.Amount.ReadOnly = true;
        this.Amount.TabIndex = 8;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Name = 'tttextbox1';
        this.tttextbox1.TabIndex = 9;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M15133", "Hasta Adı Soyadı");
        this.labelID.BackColor = '#DCDCDC';
        this.labelID.ForeColor = '#000000';
        this.labelID.Name = 'labelID';
        this.labelID.TabIndex = 9;

        this.ApplicationDate = new TTVisual.TTDateTimePicker();
        this.ApplicationDate.BackColor = '#F0F0F0';
        this.ApplicationDate.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.ApplicationDate.Format = DateTimePickerFormat.Long;
        this.ApplicationDate.Name = 'ApplicationDate';
        this.ApplicationDate.TabIndex = 1;

        this.labelMaterial = new TTVisual.TTLabel();
        this.labelMaterial.Text = i18n("M16287", "İlaç");
        this.labelMaterial.BackColor = '#DCDCDC';
        this.labelMaterial.ForeColor = '#000000';
        this.labelMaterial.Name = 'labelMaterial';
        this.labelMaterial.TabIndex = 12;

        this.ttcheckbox1 = new TTVisual.TTCheckBox();
        this.ttcheckbox1.Value = false;
        this.ttcheckbox1.Text = i18n("M16308", "İlaç Bitti");
        this.ttcheckbox1.Name = 'ttcheckbox1';
        this.ttcheckbox1.TabIndex = 10;
        this.ttcheckbox1.Visible = this.showDrugDone;

        this.labelUsageNote = new TTVisual.TTLabel();
        this.labelUsageNote.Text = i18n("M17991", "Kullanma Açıklaması");
        this.labelUsageNote.BackColor = '#DCDCDC';
        this.labelUsageNote.ForeColor = '#000000';
        this.labelUsageNote.Name = 'labelUsageNote';
        this.labelUsageNote.TabIndex = 15;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.BackColor = '#DCDCDC';
        this.labelActionDate.ForeColor = '#000000';
        this.labelActionDate.Name = 'labelActionDate';
        this.labelActionDate.TabIndex = 11;

        this.Frequency = new TTVisual.TTEnumComboBox();
        this.Frequency.DataTypeName = 'FrequencyEnum';
        this.Frequency.BackColor = '#F0F0F0';
        this.Frequency.Enabled = false;
        this.Frequency.Name = 'Frequency';
        this.Frequency.TabIndex = 4;

        this.DrugUsageType = new TTVisual.TTEnumComboBox();
        this.DrugUsageType.DataTypeName = 'DrugUsageTypeEnum';
        this.DrugUsageType.Name = 'DrugUsageType';
        this.DrugUsageType.TabIndex = 50;
        this.DrugUsageType.ReadOnly = true;
        this.DrugUsageType.SortBy = SortByEnum.DisplayText;

        this.labelSDateTime = new TTVisual.TTLabel();
        this.labelSDateTime.Text = i18n("M23759", "Uygulama Saati");
        this.labelSDateTime.BackColor = '#DCDCDC';
        this.labelSDateTime.ForeColor = '#000000';
        this.labelSDateTime.Name = 'labelSDateTime';
        this.labelSDateTime.TabIndex = 10;

        this.labelAmount = new TTVisual.TTLabel();
        this.labelAmount.Text = i18n("M19030", "Miktar");
        this.labelAmount.BackColor = '#DCDCDC';
        this.labelAmount.ForeColor = '#000000';
        this.labelAmount.Name = 'labelAmount';
        this.labelAmount.TabIndex = 16;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = '#F0F0F0';
        this.ActionDate.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 2;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M23756", "Uygulama Notu");
        this.ttlabel3.BackColor = '#DCDCDC';
        this.ttlabel3.ForeColor = '#000000';
        this.ttlabel3.Name = 'ttlabel3';
        this.ttlabel3.TabIndex = 17;

        this.Controls = [this.labelDoseAmount, this.ttlabel2, this.ttlabel1, this.Material, this.labelFrequency, this.ID, this.DoseAmount,
        this.UsageNote, this.Stage, this.RestDose, this.Amount, this.tttextbox1, this.labelID, this.ApplicationDate, this.labelMaterial,
        this.ttcheckbox1, this.labelUsageNote, this.labelActionDate, this.Frequency, this.DrugUsageType, this.labelSDateTime, this.labelAmount, this.ActionDate,
        this.ttlabel3];

    }


}
