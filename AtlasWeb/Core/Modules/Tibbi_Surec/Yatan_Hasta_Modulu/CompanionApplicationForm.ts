//$3B0BA17E
import { Component, OnInit, NgZone } from '@angular/core';
import { CompanionApplicationFormViewModel, CompanionApplicationComponentInfoViewModel } from './CompanionApplicationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CompanionApplication } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { DietDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';

@Component({
    selector: 'CompanionApplicationForm',
    templateUrl: './CompanionApplicationForm.html',
    providers: [MessageService]
})
export class CompanionApplicationForm extends EpisodeActionForm implements OnInit {
    CompanionBirthDate: TTVisual.ITTDateTimePicker;
    CompanionName: TTVisual.ITTTextBox;
    CompanionSex: TTVisual.ITTObjectListBox;
    EndDate: TTVisual.ITTDateTimePicker;
    DietDefinition: TTVisual.ITTObjectListBox;
    labelDietDefinition: TTVisual.ITTLabel;
    labelCompanionAddress: TTVisual.ITTLabel;
    labelCompanionBirthDate: TTVisual.ITTLabel;
    labelCompanionName: TTVisual.ITTLabel;
    labelCompanionSex: TTVisual.ITTLabel;
    labelEndDate: TTVisual.ITTLabel;
    labelMedicalReasonForCompanion: TTVisual.ITTLabel;
    labelRelationship: TTVisual.ITTLabel;
    labelRequestDate: TTVisual.ITTLabel;
    labelStayingDateCount: TTVisual.ITTLabel;
    labelUniqueRefNo: TTVisual.ITTLabel;
    MedicalReasonForCompanion: TTVisual.ITTTextBox;
    Relationship: TTVisual.ITTEnumComboBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    StayingDateCount: TTVisual.ITTTextBox;
    ttpanel1: TTVisual.ITTPanel;
    tttextbox7: TTVisual.ITTTextBox;
    UniqueRefNo: TTVisual.ITTTextBox;
    PassportNo: TTVisual.ITTTextBox;
    labelPassportNo: TTVisual.ITTLabel;
    public companionApplicationFormViewModel: CompanionApplicationFormViewModel = new CompanionApplicationFormViewModel();
    public get _CompanionApplication(): CompanionApplication {
        return this._TTObject as CompanionApplication;
    }
    private CompanionApplicationForm_DocumentUrl: string = '/api/CompanionApplicationService/CompanionApplicationForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.CompanionApplicationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    myLoadedViewModel: string;

    // ***** Method declarations start *****


    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
            if (this._CompanionApplication.RequestDate === null)
                throw new Exception(i18n("M17127", "Kalma Başlangıç Tarihi boş olamaz!"));
            //if (this._CompanionApplication.Episode.QuarantineInPatientDate.Value > this._CompanionApplication.RequestDate.Value)
            //    throw new Exception("Kalma Başlangıç Tarihi, hasta yatış tarihinden önce olamaz!");
            //if (this._CompanionApplication.RequestDate.Value >= this._CompanionApplication.EndDate.Value)
            //    throw new Exception("Kalma Bitiş Tarihi, Kalma Başlangıç Tarihi Tarihinden büyük olmalıdır!");
    }
    protected async PreScript() {
        super.PreScript();
        this.DropStateButton(CompanionApplication.CompanionApplicationStates.ExCompanion);
        if (this.companionApplicationFormViewModel._CompanionApplication.CompanionName == null)// Yeni Objeler İptal edilemez. Yeni olduğunu Nameden anlarız
            this.DropStateButton(CompanionApplication.CompanionApplicationStates.Cancelled);

        /*if (this._CompanionApplication.EndDate != null) {
            this.RequestDate.Max = this._CompanionApplication.EndDate;
        }*/
        if (this._CompanionApplication.RequestDate != null) {
            this.EndDate.Min = this._CompanionApplication.RequestDate;
        }

    }

    protected async save(): Promise<void> {
        let myFinalViewModel = JSON.stringify(this.companionApplicationFormViewModel);
        if (myFinalViewModel != this.myLoadedViewModel) // nesne ilk yüklendiği halinden değişti ise save olşsun yoksa olmasın
            super.save();
    }

    public static getComponentInfoViewModel(masterActionId: Guid): CompanionApplicationComponentInfoViewModel {
        let componentInfoViewModel = new CompanionApplicationComponentInfoViewModel();
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('efd14cbb-fcf0-43b0-9750-ee202a104907');
        queryParameters.QueryDefID = new Guid('014fcf5f-7d68-47fb-b644-6dbf4ef8177b'); //CompanionApplicationFormListByMasterAction
        let parameters = {};
        parameters['MASTERACTION'] = new GuidParam(masterActionId);
        queryParameters.Parameters = parameters;
        componentInfoViewModel.companionQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'CompanionApplicationForm';
        componentInfo.ModuleName = 'YatanHastaModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Yatan_Hasta_Modulu/YatanHastaModule';
        componentInfo.InputParam = new DynamicComponentInputParam(null,new ActiveIDsModel(masterActionId,null,null));
        componentInfoViewModel.companionComponentInfo = componentInfo;
        
        return componentInfoViewModel;
    }



    public static queryResultLoaded(e: any) {

        //let gridColumnsHeaders = {};
        //gridColumnsHeaders["COMPANIONNAME"] = 'Refakatçi adı'

        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "UNIQUEREFNO") {
                column.caption = 'Tc Kimlik Numarası';
            }
            if (column.dataField === "PASSPORTNO") {
                column.caption = i18n("M20214", "Pasaport No");
            }
            if (column.dataField === "COMPANIONNAME") {
                column.caption = i18n("M10514", "Adı");
            }
            if (column.dataField === "COMPANIONSEX") {
                column.caption = 'Cinsiyeti';
            }
            if (column.dataField === "REQUESTDATE") {
                column.caption = i18n("M17130", "Kalmaya Başladığı Tarihi");
            }
            if (column.dataField === "STAYINGDATECOUNT") {
                column.caption = i18n("M17090", "Kaldığı Gün Sayısı");
            }
            if (column.dataField === "DURUMU") {
                column.caption = i18n("M13372", "Durumu");
            }

        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new CompanionApplication();
        this.companionApplicationFormViewModel = new CompanionApplicationFormViewModel();
        this._ViewModel = this.companionApplicationFormViewModel;
        this.companionApplicationFormViewModel._CompanionApplication = this._TTObject as CompanionApplication;
        this.companionApplicationFormViewModel._CompanionApplication.CompanionSex = new SKRSCinsiyet();
        this.companionApplicationFormViewModel._CompanionApplication.DietDefinition = new DietDefinition();
    }

    protected loadViewModel() {
        let that = this;


        that.companionApplicationFormViewModel = this._ViewModel as CompanionApplicationFormViewModel;
        that._TTObject = this.companionApplicationFormViewModel._CompanionApplication;
        if (this.companionApplicationFormViewModel == null)
            this.companionApplicationFormViewModel = new CompanionApplicationFormViewModel();
        if (this.companionApplicationFormViewModel._CompanionApplication == null)
            this.companionApplicationFormViewModel._CompanionApplication = new CompanionApplication();
        let companionSexObjectID = that.companionApplicationFormViewModel._CompanionApplication["CompanionSex"];
        if (companionSexObjectID != null && (typeof companionSexObjectID === 'string')) {
            let companionSex = that.companionApplicationFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === companionSexObjectID.toString());
             if (companionSex) {
                that.companionApplicationFormViewModel._CompanionApplication.CompanionSex = companionSex;
            }
        }
        let dietDefinitionObjectID = that.companionApplicationFormViewModel._CompanionApplication["DietDefinition"];
        if (dietDefinitionObjectID != null && (typeof dietDefinitionObjectID === 'string')) {
            let dietDefinition = that.companionApplicationFormViewModel.DietDefinitions.find(o => o.ObjectID.toString() === dietDefinitionObjectID.toString());
             if (dietDefinition) {
                that.companionApplicationFormViewModel._CompanionApplication.DietDefinition = dietDefinition;
            }
        }
        this.myLoadedViewModel = JSON.stringify(that.companionApplicationFormViewModel);
        this.RequestDate.Min = this.companionApplicationFormViewModel.minCompanionDate;
        this.RequestDate.Max = new Date();
    }





    CheckMernis_Click() {
        let params: CompanionApplicationFormViewModel = new CompanionApplicationFormViewModel();
        params._CompanionApplication.UniqueRefNo = this._CompanionApplication.UniqueRefNo;
        let apiUrl: string = '/api/CompanionApplicationService/CheckMernisNumber';
        this.httpService.post<CompanionApplicationFormViewModel>(apiUrl, params).then(
            x => {
                this._CompanionApplication.CompanionName = x._CompanionApplication.CompanionName;
                this._CompanionApplication.CompanionBirthDate = x._CompanionApplication.CompanionBirthDate;
                this._CompanionApplication.CompanionAddress = x._CompanionApplication.CompanionAddress;
                this._CompanionApplication.CompanionSex = x._CompanionApplication.CompanionSex;
            }
        );
    }


    async ngOnInit()  {
        let that = this;
        await this.load(CompanionApplicationFormViewModel);
        
    }



    public onCompanionBirthDateChanged(event): void {
        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.CompanionBirthDate != event) {
                this._CompanionApplication.CompanionBirthDate = event;
            }
        }
    }

    public onCompanionNameChanged(event): void {
        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.CompanionName != event) {
                this._CompanionApplication.CompanionName = event;
            }
        }
    }

    public onCompanionSexChanged(event): void {
        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.CompanionSex != event) {
                this._CompanionApplication.CompanionSex = event;
            }
        }
    }

    public onDietDefinitionChanged(event): void {
        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.DietDefinition != event) {
                this._CompanionApplication.DietDefinition = event;
            }
        }
    }

    //public onEndDateChanged(event): void {
    //    if (event != null) {
    //        if (this._CompanionApplication != null && this._CompanionApplication.EndDate != event) {
    //            this._CompanionApplication.EndDate = event;
    //            if (this._CompanionApplication.RequestDate != null && this._CompanionApplication.EndDate != null) {
    //                this._CompanionApplication.StayingDateCount  = DateUtil.totalDays(this._CompanionApplication.RequestDate, this._CompanionApplication.EndDate);
    //            }
    //        }
    //    }
    //}

    //public onRequestDateChanged(event): void {
    //    if (event != null) {
    //        if (this._CompanionApplication != null && this._CompanionApplication.RequestDate != event) {
    //            this._CompanionApplication.RequestDate = event;
    //            if (this._CompanionApplication.RequestDate != null && this._CompanionApplication.EndDate != null) {
    //                this._CompanionApplication.StayingDateCount = DateUtil.totalDays(this._CompanionApplication.RequestDate, this._CompanionApplication.EndDate);
    //            }
    //        }
    //    }
    //}

    public onEndDateChanged(event): void {
        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.EndDate != event) {
                let StayingCount: number = null;
                if (event != null) {
                    if (this._CompanionApplication.RequestDate != null ) {
                        StayingCount = DateUtil.totalDays(this._CompanionApplication.RequestDate, event);
                    }
                    this.RequestDate.Max = event;
                }
                if (StayingCount == null || StayingCount > -1)
                {
                    this._CompanionApplication.EndDate = event;
                    this._CompanionApplication.StayingDateCount = StayingCount;
                }
                else
                {
                    this.messageService.showError(i18n("M17129", "Kalma Bitiş Tarihi, Kalma Başlangıç Tarihi Tarihinden büyük olmalıdır"));
                }
            }
        }
    }

    public onRequestDateChanged(event): void {

        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.RequestDate != event) {
                let StayingCount: number = null;
                if (event != null) {
                    if (this._CompanionApplication.EndDate != null) {
                        StayingCount = DateUtil.totalDays(event, this._CompanionApplication.EndDate);
                    }
                    this.EndDate.Min = event;
                }
                if (StayingCount == null || StayingCount > -1) {
                    this._CompanionApplication.RequestDate = event;
                    this._CompanionApplication.StayingDateCount = StayingCount;
                }
                else {
                    this._CompanionApplication.RequestDate = this._CompanionApplication.RequestDate;
                    this.messageService.showError(i18n("M17125", "Kalma Başlangıç  Tarihi, Kalma Bitiş Tarihi Tarihinden küçük olmalıdır"));
                }
            }
        }
    }


    public onMedicalReasonForCompanionChanged(event): void {
        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.MedicalReasonForCompanion != event) {
                this._CompanionApplication.MedicalReasonForCompanion = event;
            }
        }
    }

    public onRelationshipChanged(event): void {
        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.Relationship != event) {
                this._CompanionApplication.Relationship = event;
            }
        }
    }



    public onStayingDateCountChanged(event): void {
        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.StayingDateCount != event) {
                this._CompanionApplication.StayingDateCount = event;
                if (this._CompanionApplication.RequestDate != null)
                    this._CompanionApplication.EndDate = this._CompanionApplication.RequestDate.AddDays(parseInt(event));
            }
        }
    }

    public ontttextbox7Changed(event): void {
        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.CompanionAddress != event) {
                this._CompanionApplication.CompanionAddress = event;
            }
        }
    }

    public onUniqueRefNoChanged(event): void {
        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.UniqueRefNo != event) {
                this._CompanionApplication.UniqueRefNo = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.UniqueRefNo, "Text", this.__ttObject, "UniqueRefNo");
        redirectProperty(this.Relationship, "Value", this.__ttObject, "Relationship");
        redirectProperty(this.CompanionName, "Text", this.__ttObject, "CompanionName");
        redirectProperty(this.CompanionBirthDate, "Value", this.__ttObject, "CompanionBirthDate");
        redirectProperty(this.tttextbox7, "Text", this.__ttObject, "CompanionAddress");
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.EndDate, "Value", this.__ttObject, "EndDate");
        redirectProperty(this.StayingDateCount, "Text", this.__ttObject, "StayingDateCount");
        redirectProperty(this.MedicalReasonForCompanion, "Text", this.__ttObject, "MedicalReasonForCompanion");
    }

    public initFormControls(): void {
        this.labelPassportNo = new TTVisual.TTLabel();
        this.labelPassportNo.Text = i18n("M20214", "Pasaport No");
        this.labelPassportNo.Name = "labelPassportNo";
        this.labelPassportNo.TabIndex = 56;

        this.PassportNo = new TTVisual.TTTextBox();
        this.PassportNo.Name = "PassportNo";
        this.PassportNo.TabIndex = 55;

        this.ttpanel1 = new TTVisual.TTPanel();
        this.ttpanel1.AutoSize = true;
        this.ttpanel1.Name = "ttpanel1";
        this.ttpanel1.TabIndex = 23;

        this.labelUniqueRefNo = new TTVisual.TTLabel();
        this.labelUniqueRefNo.Text = i18n("M22513", "T.C. Kimlik No");
        this.labelUniqueRefNo.Name = "labelUniqueRefNo";
        this.labelUniqueRefNo.TabIndex = 21;

        this.CompanionSex = new TTVisual.TTObjectListBox();
        this.CompanionSex.ListDefName = "SKRSCinsiyetList";
        this.CompanionSex.Name = "CompanionSex";
        this.CompanionSex.TabIndex = 22;

        this.labelCompanionAddress = new TTVisual.TTLabel();
        this.labelCompanionAddress.Text = i18n("M20991", "Refakatçi Adresi");
        this.labelCompanionAddress.Name = "labelCompanionAddress";
        this.labelCompanionAddress.TabIndex = 1;

        this.CompanionBirthDate = new TTVisual.TTDateTimePicker();
        this.CompanionBirthDate.Format = DateTimePickerFormat.Short;
        this.CompanionBirthDate.Name = "CompanionBirthDate";
        this.CompanionBirthDate.TabIndex = 4;

        this.UniqueRefNo = new TTVisual.TTTextBox();
        this.UniqueRefNo.Name = "UniqueRefNo";
        this.UniqueRefNo.TabIndex = 20;

        this.labelCompanionBirthDate = new TTVisual.TTLabel();
        this.labelCompanionBirthDate.Text = i18n("M20995", "Refakatçi Doğum Tarihi");
        this.labelCompanionBirthDate.Name = "labelCompanionBirthDate";
        this.labelCompanionBirthDate.TabIndex = 3;

        this.labelCompanionName = new TTVisual.TTLabel();
        this.labelCompanionName.Text = i18n("M20989", "Refakatçi Adı");
        this.labelCompanionName.Name = "labelCompanionName";
        this.labelCompanionName.TabIndex = 5;

        this.labelCompanionSex = new TTVisual.TTLabel();
        this.labelCompanionSex.Text = i18n("M20993", "Refakatçi Cinsiyeti");
        this.labelCompanionSex.Name = "labelCompanionSex";
        this.labelCompanionSex.TabIndex = 7;

        this.CompanionName = new TTVisual.TTTextBox();
        this.CompanionName.Name = "CompanionName";
        this.CompanionName.TabIndex = 3;

        this.Relationship = new TTVisual.TTEnumComboBox();
        this.Relationship.DataTypeName = "RelationshipType";
        this.Relationship.Name = "Relationship";
        this.Relationship.TabIndex = 18;

        this.tttextbox7 = new TTVisual.TTTextBox();
        this.tttextbox7.Multiline = true;
        this.tttextbox7.Name = "tttextbox7";
        this.tttextbox7.TabIndex = 6;
        this.tttextbox7.Height = "66px";

        this.labelRelationship = new TTVisual.TTLabel();
        this.labelRelationship.Text = i18n("M24253", "Yakınlık Derecesi");
        this.labelRelationship.Name = "labelRelationship";
        this.labelRelationship.TabIndex = 19;

        this.MedicalReasonForCompanion = new TTVisual.TTTextBox();
        this.MedicalReasonForCompanion.Name = "MedicalReasonForCompanion";
        this.MedicalReasonForCompanion.TabIndex = 8;

        this.StayingDateCount = new TTVisual.TTTextBox();
        this.StayingDateCount.BackColor = "#F0F0F0";
        this.StayingDateCount.ReadOnly = true;
        this.StayingDateCount.Name = "StayingDateCount";
        this.StayingDateCount.TabIndex = 2;

        this.labelMedicalReasonForCompanion = new TTVisual.TTLabel();
        this.labelMedicalReasonForCompanion.Text = i18n("M21005", "Refakatçinin Kalmasına Gerek Görülen Sebeb");
        this.labelMedicalReasonForCompanion.Name = "labelMedicalReasonForCompanion";
        this.labelMedicalReasonForCompanion.TabIndex = 17;

        this.labelRequestDate = new TTVisual.TTLabel();
        this.labelRequestDate.Text = i18n("M17126", " Kalma Başlangıç Tarihi");
        this.labelRequestDate.Name = "labelRequestDate";
        this.labelRequestDate.TabIndex = 14;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.Format = DateTimePickerFormat.Short;
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 0;


        this.labelStayingDateCount = new TTVisual.TTLabel();
        this.labelStayingDateCount.Text = i18n("M17079", "Kalacağı Gün Sayısı");
        this.labelStayingDateCount.Name = "labelStayingDateCount";
        this.labelStayingDateCount.TabIndex = 9;

        this.labelEndDate = new TTVisual.TTLabel();
        this.labelEndDate.Text = i18n("M17128", "Kalma Bitiş Tarihi");
        this.labelEndDate.Name = "labelEndDate";
        this.labelEndDate.TabIndex = 14;

        this.EndDate = new TTVisual.TTDateTimePicker();
        this.EndDate.Format = DateTimePickerFormat.Short;
        this.EndDate.Name = "EndDate";
        this.EndDate.TabIndex = 1;


        this.labelDietDefinition = new TTVisual.TTLabel();
        this.labelDietDefinition.Text = i18n("M13054", "Diyet Türü");
        this.labelDietDefinition.Name = "labelDietDefinition";
        this.labelDietDefinition.TabIndex = 54;

        this.DietDefinition = new TTVisual.TTObjectListBox();
        this.DietDefinition.ListDefName = "DietListDefinition";
        this.DietDefinition.Name = "DietDefinition";
        this.DietDefinition.TabIndex = 53;
        this.DietDefinition.AutoCompleteDialogWidth = "25%"

        this.ttpanel1.Controls = [this.labelUniqueRefNo, this.CompanionSex, this.labelCompanionAddress, this.CompanionBirthDate, this.UniqueRefNo, this.labelCompanionBirthDate, this.labelCompanionName, this.labelCompanionSex, this.CompanionName, this.Relationship, this.tttextbox7, this.labelRelationship];
        this.Controls = [this.labelPassportNo, this.PassportNo, this.ttpanel1, this.labelUniqueRefNo, this.CompanionSex, this.labelCompanionAddress, this.CompanionBirthDate, this.UniqueRefNo, this.labelCompanionBirthDate, this.labelCompanionName, this.labelCompanionSex, this.CompanionName, this.Relationship, this.tttextbox7, this.labelRelationship, this.MedicalReasonForCompanion, this.StayingDateCount, this.labelMedicalReasonForCompanion, this.labelRequestDate, this.RequestDate, this.labelStayingDateCount, this.labelEndDate, this.EndDate, this.labelDietDefinition, this.DietDefinition];

    }

    public onPassportNoChanged(event): void {


        if (event != null) {
            if (this._CompanionApplication != null && this._CompanionApplication.PassportNo != event) {
                this._CompanionApplication.PassportNo = event;


            }
        }
    }
}
