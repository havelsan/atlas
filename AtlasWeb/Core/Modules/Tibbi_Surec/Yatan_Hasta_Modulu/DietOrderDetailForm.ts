//$C66B8279
import { Component, OnInit, NgZone } from '@angular/core';
import { DietOrderDetailFormViewModel } from './DietOrderDetailFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DietOrderDetail, EpisodeAction, InPatientPhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';
import { SubactionProcedureFlowableForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/SubactionProcedureFlowableForm";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { MealTypes } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TestResultQueryInputDVO } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { InfoBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DietBarcodeInfo } from 'app/Barcode/Models/DietBarcodeInfo';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from "Fw/Services/IModalService";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';

@Component({
    selector: 'DietOrderDetailForm',
    templateUrl: './DietOrderDetailForm.html',
    providers: [MessageService]
})
export class DietOrderDetailForm extends SubactionProcedureFlowableForm implements OnInit {
    BreakfastMealTypes: TTVisual.ITTCheckBox;
    DinnerMealTypes: TTVisual.ITTCheckBox;
    HeigthEpisode: TTVisual.ITTTextBox;
    labelHeigthEpisode: TTVisual.ITTLabel;
    labelProcedure: TTVisual.ITTLabel;
    labelWeightEpisode: TTVisual.ITTLabel;
    labelWorkListDate: TTVisual.ITTLabel;
    LunchMealTypes: TTVisual.ITTCheckBox;
    NightBreakfastMealTypes: TTVisual.ITTCheckBox;
    ProcedureObject: TTVisual.ITTObjectListBox;
    Snack1MealTypes: TTVisual.ITTCheckBox;
    Snack2MealTypes: TTVisual.ITTCheckBox;
    Snack3MealTypes: TTVisual.ITTCheckBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    WeightEpisode: TTVisual.ITTTextBox;
    WorkListDate: TTVisual.ITTDateTimePicker;
    viewResultURL: string = "";

    public dietOrderDetailFormViewModel: DietOrderDetailFormViewModel = new DietOrderDetailFormViewModel();
    public VKI = 0;
    public VKI_Deger = "";
    //TODO: ismail genel olaraj yapılacakmış
    private _tempDietOrderDetail: DietOrderDetail = new DietOrderDetail(); //ilk yüklenen veriyi tutacak değişen veri varmı kontrolü için
    public get _DietOrderDetail(): DietOrderDetail {
        return this._TTObject as DietOrderDetail;
    }
    private DietOrderDetailForm_DocumentUrl: string = '/api/DietOrderDetailService/DietOrderDetailForm';
    constructor(private sideBarMenuService: ISidebarMenuService,
                private barcodePrintService: IBarcodePrintService,
                protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected modalService: IModalService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.DietOrderDetailForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public LaboratoryTestListColumns = [
        {
            caption: i18n("M23259", "Test Adı"),
            dataField: "TestName",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M22109", "Sonuç Tarihi"),
            dataField: "ResultDate",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M21010", "Referans Aralığı"),
            dataField: "Reference",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M22078", "Sonuç"),
            dataField: "Result",
            width: "auto",
            allowSorting: true
        }
    ];

    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DietOrderDetail();
        this.dietOrderDetailFormViewModel = new DietOrderDetailFormViewModel();
        this._ViewModel = this.dietOrderDetailFormViewModel;
        this.dietOrderDetailFormViewModel._DietOrderDetail = this._TTObject as DietOrderDetail;
        this.dietOrderDetailFormViewModel._DietOrderDetail.MealType = new MealTypes();
        this.dietOrderDetailFormViewModel._DietOrderDetail.Episode = new Episode();
        this.dietOrderDetailFormViewModel._DietOrderDetail.Episode.Patient = new Patient();
        this.dietOrderDetailFormViewModel._DietOrderDetail.ProcedureObject = new ProcedureDefinition();
        this.dietOrderDetailFormViewModel._DietOrderDetail.EpisodeAction = new EpisodeAction();
    }

    protected loadViewModel() {
        let that = this;

        that.dietOrderDetailFormViewModel = this._ViewModel as DietOrderDetailFormViewModel;
        that._TTObject = this.dietOrderDetailFormViewModel._DietOrderDetail;
        if (this.dietOrderDetailFormViewModel == null)
            this.dietOrderDetailFormViewModel = new DietOrderDetailFormViewModel();
        if (this.dietOrderDetailFormViewModel._DietOrderDetail == null)
            this.dietOrderDetailFormViewModel._DietOrderDetail = new DietOrderDetail();
        let mealTypeObjectID = that.dietOrderDetailFormViewModel._DietOrderDetail["MealType"];
        if (mealTypeObjectID != null && (typeof mealTypeObjectID === 'string')) {
            let mealType = that.dietOrderDetailFormViewModel.MealTypess.find(o => o.ObjectID.toString() === mealTypeObjectID.toString());
             if (mealType) {
                that.dietOrderDetailFormViewModel._DietOrderDetail.MealType = mealType;
            }
        }
        let episodeObjectID = that.dietOrderDetailFormViewModel._DietOrderDetail["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.dietOrderDetailFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.dietOrderDetailFormViewModel._DietOrderDetail.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.dietOrderDetailFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let procedureObjectObjectID = that.dietOrderDetailFormViewModel._DietOrderDetail["ProcedureObject"];
        if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
            let procedureObject = that.dietOrderDetailFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
             if (procedureObject) {
                that.dietOrderDetailFormViewModel._DietOrderDetail.ProcedureObject = procedureObject;
            }
        }

        //TODO: ismail bunları kaldır
        //if (that._DietOrderDetail.Episode.Patient.Weight == undefined)
        //that._DietOrderDetail.Episode.Patient.Weight = 70;
        //if (that._DietOrderDetail.Episode.Patient.Heigth == undefined)
        //that._DietOrderDetail.Episode.Patient.Heigth = 1.7;
        if (that._DietOrderDetail.Episode.Patient.Weight != undefined && that._DietOrderDetail.Episode.Patient.Heigth != undefined && that._DietOrderDetail.Episode.Patient.Weight != 0 && that._DietOrderDetail.Episode.Patient.Heigth != 0) {
            this.VKI = <any>(that._DietOrderDetail.Episode.Patient.Weight / ((that._DietOrderDetail.Episode.Patient.Heigth / 100) * (that._DietOrderDetail.Episode.Patient.Heigth / 100))).toFixed(2) * 1;
            this.arrangeVKI_Deger();
        }
        //this._tempDietOrderDetail = this.dietOrderDetailFormViewModel._DietOrderDetail;//ilk yüklenen veri
    }


    async ngOnInit()  {
        let that = this;
        await this.load(DietOrderDetailFormViewModel);

        this.AddHelpMenu();
  
    }

    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();

    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        
        let caloriBarcode = new DynamicSidebarMenuItem();
        caloriBarcode.key = 'caloriBarcode';
        caloriBarcode.icon = 'fa fa-print';
        caloriBarcode.label =  "Kalori Miktarı";
        caloriBarcode.componentInstance = this;
        caloriBarcode.clickFunction = this.printCaloriBarcode;
        this.sideBarMenuService.addMenu('Barkod', caloriBarcode);

        // let yemekCikanHastaListesi = new DynamicSidebarMenuItem();
        // yemekCikanHastaListesi.key = 'yemekCikanHastaListesi';
        // yemekCikanHastaListesi.icon = 'fa fa-print';
        // yemekCikanHastaListesi.label = i18n("M30900", "Hasta İzin Formu");
        // yemekCikanHastaListesi.componentInstance = this;
        // yemekCikanHastaListesi.clickFunction = this.printYemekCikanHastaListesi;
        // this.sideBarMenuService.addMenu('ReportMainItem', yemekCikanHastaListesi);
    }

    public RemoveMenuFromHelpMenu(): void {

        this.sideBarMenuService.removeMenu('caloriBarcode');        
        // this.sideBarMenuService.removeMenu('yemekCikanHastaListesi');    
    }

    // printYemekCikanHastaListesi(ID :string) {

    //     let reportData: DynamicReportParameters = {

    //         Code: 'PATIENTDIETLIST',
    //         ReportParams: { ObjectID: ID },
    //         ViewerMode: true
    //     };

    //     return new Promise((resolve, reject) => {

    //         let componentInfo = new DynamicComponentInfo();
    //         componentInfo.ComponentName = 'HvlDynamicReportComponent';
    //         componentInfo.ModuleName = 'DevexpressReportingModule';
    //         componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
    //         componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

    //         let modalInfo: ModalInfo = new ModalInfo();
    //         modalInfo.Title = "YEMEK ÇIKAN HASTA LİSTESİ"

    //         modalInfo.fullScreen = true;

    //         let result = this.modalService.create(componentInfo, modalInfo);
    //         result.then(inner => {
    //             resolve(inner);
    //         }).catch(err => {
    //             reject(err);
    //         });
    //     });

    // }


    public onBreakfastMealTypesChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null &&
                this._DietOrderDetail.MealType != null && this._DietOrderDetail.MealType.Breakfast != event) {
                this._DietOrderDetail.MealType.Breakfast = event;

                this.controlChangedProperty("Breakfast");
            }
        }
    }

    public onDinnerMealTypesChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null &&
                this._DietOrderDetail.MealType != null && this._DietOrderDetail.MealType.Dinner != event) {
                this._DietOrderDetail.MealType.Dinner = event;
            }
        }
    }

    public onHeigthEpisodeChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null &&
                this._DietOrderDetail.Episode != null &&
                this._DietOrderDetail.Episode.Patient != null && this._DietOrderDetail.Episode.Patient.Heigth != event) {
                this._DietOrderDetail.Episode.Patient.Heigth = event;
            }
        }
    }

    public onLunchMealTypesChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null &&
                this._DietOrderDetail.MealType != null && this._DietOrderDetail.MealType.Lunch != event) {
                this._DietOrderDetail.MealType.Lunch = event;
            }
        }
    }

    public onNightBreakfastMealTypesChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null &&
                this._DietOrderDetail.MealType != null && this._DietOrderDetail.MealType.NightBreakfast != event) {
                this._DietOrderDetail.MealType.NightBreakfast = event;
            }
        }
    }

    public onProcedureObjectChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null && this._DietOrderDetail.ProcedureObject != event) {
                this._DietOrderDetail.ProcedureObject = event;
            }
        }
    }

    public onSnack1MealTypesChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null &&
                this._DietOrderDetail.MealType != null && this._DietOrderDetail.MealType.Snack1 != event) {
                this._DietOrderDetail.MealType.Snack1 = event;
            }
        }
    }

    public onSnack2MealTypesChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null &&
                this._DietOrderDetail.MealType != null && this._DietOrderDetail.MealType.Snack2 != event) {
                this._DietOrderDetail.MealType.Snack2 = event;
            }
        }
    }

    public onSnack3MealTypesChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null &&
                this._DietOrderDetail.MealType != null && this._DietOrderDetail.MealType.Snack3 != event) {
                this._DietOrderDetail.MealType.Snack3 = event;
            }
        }
    }

    public onWeightEpisodeChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null &&
                this._DietOrderDetail.Episode != null &&
                this._DietOrderDetail.Episode.Patient != null && this._DietOrderDetail.Episode.Patient.Weight != event) {
                this._DietOrderDetail.Episode.Patient.Weight = event;
            }
        }
    }

    public onWorkListDateChanged(event): void {
        if (event != null) {
            if (this._DietOrderDetail != null && this._DietOrderDetail.WorkListDate != event) {
                this._DietOrderDetail.WorkListDate = event;
            }
        }
    }

    btnShowLISResultViewForAllEpisodes_Click(): void {
        this.viewResultURL = "";
        this.GetViewResultURLForAllEpisodes().then(() => {
            this.openInNewTab(this.viewResultURL);
        });
    }

    public async GetViewResultURLForAllEpisodes(): Promise<void> {

        let that = this;
        let inputDVO = new TestResultQueryInputDVO();


        inputDVO.PatientTCKN = that._DietOrderDetail.Episode.Patient.UniqueRefNo.toString();
        inputDVO.EpisodeID = that._DietOrderDetail.Episode.ID.toString();

        let apiUrl: string = 'api/ProcedureRequestService/GetURLForAllEpisodeTestResults';
        let result = await this.httpService.post<string>(apiUrl, inputDVO);
        this.viewResultURL = result;
    }

    openInNewTab(url) {
        if (url == null) {
            InfoBox.Alert(i18n("M12080", "Bu hizmetin sonucu bulunamadı!"));
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }

    openDrugOrder: boolean = false;
    visible: boolean = false;
    public OpenDrugOrderList(){
        this.openDrugOrder = true;
        this.visible = true;
    }

    
    protected redirectProperties(): void {
        redirectProperty(this.WorkListDate, "Value", this.__ttObject, "WorkListDate");
        redirectProperty(this.HeigthEpisode, "Text", this.__ttObject, "Episode.Patient.Heigth");
        redirectProperty(this.WeightEpisode, "Text", this.__ttObject, "Episode.Patient.Weight");
        redirectProperty(this.BreakfastMealTypes, "Value", this.__ttObject, "MealType.Breakfast");
        redirectProperty(this.DinnerMealTypes, "Value", this.__ttObject, "MealType.Dinner");
        redirectProperty(this.LunchMealTypes, "Value", this.__ttObject, "MealType.Lunch");
        redirectProperty(this.NightBreakfastMealTypes, "Value", this.__ttObject, "MealType.NightBreakfast");
        redirectProperty(this.Snack1MealTypes, "Value", this.__ttObject, "MealType.Snack1");
        redirectProperty(this.Snack2MealTypes, "Value", this.__ttObject, "MealType.Snack2");
        redirectProperty(this.Snack3MealTypes, "Value", this.__ttObject, "MealType.Snack3");
    }

    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M19906", "Öğünler");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 29;

        this.BreakfastMealTypes = new TTVisual.TTCheckBox();
        this.BreakfastMealTypes.Value = false;
        this.BreakfastMealTypes.Title = i18n("M21093", "Sabah");
        this.BreakfastMealTypes.Name = "BreakfastMealTypes";
        this.BreakfastMealTypes.TabIndex = 22;

        this.Snack3MealTypes = new TTVisual.TTCheckBox();
        this.Snack3MealTypes.Value = false;
        this.Snack3MealTypes.Title = "Ara 3";
        this.Snack3MealTypes.Name = "Snack3MealTypes";
        this.Snack3MealTypes.TabIndex = 28;

        this.DinnerMealTypes = new TTVisual.TTCheckBox();
        this.DinnerMealTypes.Value = false;
        this.DinnerMealTypes.Title = i18n("M10643", "Akşam");
        this.DinnerMealTypes.Name = "DinnerMealTypes";
        this.DinnerMealTypes.TabIndex = 23;

        this.Snack2MealTypes = new TTVisual.TTCheckBox();
        this.Snack2MealTypes.Value = false;
        this.Snack2MealTypes.Title = "Ara 2";
        this.Snack2MealTypes.Name = "Snack2MealTypes";
        this.Snack2MealTypes.TabIndex = 27;

        this.LunchMealTypes = new TTVisual.TTCheckBox();
        this.LunchMealTypes.Value = false;
        this.LunchMealTypes.Title = i18n("M19897", "Öğle");
        this.LunchMealTypes.Name = "LunchMealTypes";
        this.LunchMealTypes.TabIndex = 24;

        this.Snack1MealTypes = new TTVisual.TTCheckBox();
        this.Snack1MealTypes.Value = false;
        this.Snack1MealTypes.Title = "Ara 1";
        this.Snack1MealTypes.Name = "Snack1MealTypes";
        this.Snack1MealTypes.TabIndex = 26;

        this.NightBreakfastMealTypes = new TTVisual.TTCheckBox();
        this.NightBreakfastMealTypes.Value = false;
        this.NightBreakfastMealTypes.Title = i18n("M14586", "Gece Kahvaltısı");
        this.NightBreakfastMealTypes.Name = "NightBreakfastMealTypes";
        this.NightBreakfastMealTypes.TabIndex = 25;

        this.labelWeightEpisode = new TTVisual.TTLabel();
        this.labelWeightEpisode.Text = "Kilo";
        this.labelWeightEpisode.Name = "labelWeightEpisode";
        this.labelWeightEpisode.TabIndex = 19;

        this.WeightEpisode = new TTVisual.TTTextBox();
        this.WeightEpisode.BackColor = "#F0F0F0";
        this.WeightEpisode.ReadOnly = true;
        this.WeightEpisode.Name = "WeightEpisode";
        this.WeightEpisode.TabIndex = 18;

        this.HeigthEpisode = new TTVisual.TTTextBox();
        this.HeigthEpisode.BackColor = "#F0F0F0";
        this.HeigthEpisode.ReadOnly = true;
        this.HeigthEpisode.Name = "HeigthEpisode";
        this.HeigthEpisode.TabIndex = 16;

        this.labelHeigthEpisode = new TTVisual.TTLabel();
        this.labelHeigthEpisode.Text = "Boy";
        this.labelHeigthEpisode.Name = "labelHeigthEpisode";
        this.labelHeigthEpisode.TabIndex = 17;

        this.labelWorkListDate = new TTVisual.TTLabel();
        this.labelWorkListDate.Text = i18n("M16771", "İş Listesi Tarihi");
        this.labelWorkListDate.Name = "labelWorkListDate";
        this.labelWorkListDate.TabIndex = 1;

        this.WorkListDate = new TTVisual.TTDateTimePicker();
        this.WorkListDate.BackColor = "#F0F0F0";
        this.WorkListDate.Format = DateTimePickerFormat.Long;
        this.WorkListDate.Enabled = false;
        this.WorkListDate.Name = "WorkListDate";
        this.WorkListDate.TabIndex = 0;

        this.ProcedureObject = new TTVisual.TTObjectListBox();
        this.ProcedureObject.Required = true;
        this.ProcedureObject.ListDefName = "DietDefinitionList";
        this.ProcedureObject.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.TabIndex = 14;

        this.labelProcedure = new TTVisual.TTLabel();
        this.labelProcedure.Text = i18n("M24104", "Verilen Diyet");
        this.labelProcedure.BackColor = "#DCDCDC";
        this.labelProcedure.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedure.ForeColor = "#000000";
        this.labelProcedure.Name = "labelProcedure";
        this.labelProcedure.TabIndex = 15;

        this.ttgroupbox1.Controls = [this.BreakfastMealTypes, this.Snack3MealTypes, this.DinnerMealTypes, this.Snack2MealTypes, this.LunchMealTypes, this.Snack1MealTypes, this.NightBreakfastMealTypes];
        this.Controls = [this.ttgroupbox1, this.BreakfastMealTypes, this.Snack3MealTypes, this.DinnerMealTypes, this.Snack2MealTypes, this.LunchMealTypes, this.Snack1MealTypes, this.NightBreakfastMealTypes, this.labelWeightEpisode, this.WeightEpisode, this.HeigthEpisode, this.labelHeigthEpisode, this.labelWorkListDate, this.WorkListDate, this.ProcedureObject, this.labelProcedure];

    }

    private controlChangedProperty(_val)
    {
        if (this._DietOrderDetail.CurrentStateDefID == DietOrderDetail.DietOrderDetailStates.Execution) {
                this.DropStateButton(DietOrderDetail.DietOrderDetailStates.Execution);
                // this.DropStateButton(DietOrderDetail.DietOrderDetailStates.Completed);
                // this.DropStateButton(DietOrderDetail.DietOrderDetailStates.Approval);
                // this.DropStateButton(DietOrderDetail.DietOrderDetailStates.Cancelled);
        }
    }

    private arrangeVKI_Deger()
    {
        if (this.VKI <= 18.40)
            this.VKI_Deger = i18n("M10061", "0-18.4 : Zayıf");
        else if (this.VKI < 24.9)
            this.VKI_Deger = "18.5 - 24.9 : Normal";
        else if (this.VKI <= 29.9)
            this.VKI_Deger = i18n("M10251", "25.0 - 29.9 : Fazla Kilolu");
        else if (this.VKI <= 34.9)
            this.VKI_Deger = i18n("M10297", "30.0 - 34.9 : Şişman (Obez) - I.Sınıf");
        else if (this.VKI < 44.9)
            this.VKI_Deger = i18n("M10305", "35.0 - 44.9 : Şişman (Obez) - II.Sınıf");
        else if (this.VKI >= 45)
            this.VKI_Deger = i18n("M10329", "40.5 ve üstü : Aşırı Şişman (Aşırı Obez) - III.Sınıf ");
    }

    public async printCaloriBarcode() {

    let that = this;
    that.httpService.get<DietBarcodeInfo>("/api/DietOrderDetailService/GetDietCaloriInfo?PeriodicOrder=" + this._DietOrderDetail.PeriodicOrder + "&ObjectID=" + that._DietOrderDetail.ObjectID)
        .then(response => {
            that.barcodePrintService.printAllBarcode(response, "generateDietCaloriBarcode", "printCaloriBarcode");
        })
        .catch(error => {
            that.messageService.showError(error);

        });
            
        
    }
}
