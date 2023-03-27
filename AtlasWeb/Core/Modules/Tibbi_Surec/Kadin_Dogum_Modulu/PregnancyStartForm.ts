//$8AF7C3C1
import { Component, OnInit, EventEmitter, Output, NgZone, Input } from '@angular/core';
import { PregnancyStartFormViewModel } from './PregnancyStartFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { GestationalAgeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Pregnancy } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyNotification } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { GebelikBildirim } from '../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel';

@Component({
    selector: 'PregnancyStartForm',
    templateUrl: './PregnancyStartForm.html',
    providers: [MessageService]
})
export class PregnancyStartForm extends TTVisual.TTForm implements OnInit {
    BlastocystTransferDate: TTVisual.ITTDateTimePicker;
    EggCollectionDate: TTVisual.ITTDateTimePicker;
    EmbryoTransferDate: TTVisual.ITTDateTimePicker;
    EstimatedBirthDate: TTVisual.ITTDateTimePicker;
    labelBlastocystTransferDate: TTVisual.ITTLabel;
    labelEggCollectionDate: TTVisual.ITTLabel;
    labelEmbryoTransferDate: TTVisual.ITTLabel;
    labelEstimatedBirthDate: TTVisual.ITTLabel;
    labelLastMenstrualPeriod: TTVisual.ITTLabel;
    labelMeasuredPregnancyDate: TTVisual.ITTLabel;
    labelMeasuredPregnancyDay: TTVisual.ITTLabel;
    labelMeasuredPregnancyWeek: TTVisual.ITTLabel;
    labelPregnancyInformation: TTVisual.ITTLabel;
    labelPregnancyType: TTVisual.ITTLabel;
    labelRiskOfGestationalAge: TTVisual.ITTLabel;
    LastMenstrualPeriod: TTVisual.ITTDateTimePicker;
    MeasuredPregnancyDate: TTVisual.ITTDateTimePicker;
    MeasuredPregnancyDay: TTVisual.ITTTextBox;
    MeasuredPregnancyWeek: TTVisual.ITTTextBox;
    NotificationPregnancyNotification: TTVisual.ITTListBoxColumn;
    PregnancyInformation: TTVisual.ITTTextBox;
    PregnancyNotification: TTVisual.ITTGrid;
    PregnancyType: TTVisual.ITTEnumComboBox;
    public Days: number;
    public Months: number;
    public Weeks: number;
    public Years: number;
    public showGebelikBildirim :boolean = false;
    RiskOfGestationalAge: TTVisual.ITTEnumComboBox;
    ttlabel1: TTVisual.ITTLabel;
    public PregnancyNotificationColumns = [];
    public pregnancyStartFormViewModel: PregnancyStartFormViewModel = new PregnancyStartFormViewModel();
    public get _Pregnancy(): Pregnancy {
        return this._TTObject as Pregnancy;
    }
    private PregnancyStartForm_DocumentUrl: string = '/api/PregnancyService/PregnancyStartForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super('PREGNANCY', 'PregnancyStartForm');
        this._DocumentServiceUrl = this.PregnancyStartForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    @Output() sendViewModelToParent: EventEmitter<PregnancyStartFormViewModel> = new EventEmitter<PregnancyStartFormViewModel>();

    private _gebelikBildirim: Array<GebelikBildirim>;
    @Input() set GebelikBildirim(value: Array<GebelikBildirim>) {
        if(value != null && value.length > 0)
        {
            this._gebelikBildirim = value;
            this.showGebelikBildirim = true;
        }

    }
    get GebelikBildirim(): Array<GebelikBildirim> {
        return this._gebelikBildirim;
    }

    // ***** Method declarations start *****

    //private async BlastocystTransferDate_ValueChanged(): Promise<void> {
    //    this.LastMenstrualPeriodByBlastocystTransferDate(this._Pregnancy.Patient.ActivePregnancy.BlastocystTransferDate).then(c => {
    //        this._Pregnancy.Patient.ActivePregnancy.LastMenstrualPeriod = c;
    //    });
    //}
    private clearScreen(name: string): void {
        if (name != "EggCollectionDate" && this._Pregnancy.EggCollectionDate != null) {
            this._Pregnancy.EggCollectionDate = null;
        }
        if (name != "EmbryoTransferDate" && this._Pregnancy.EmbryoTransferDate != null) {
            this._Pregnancy.EmbryoTransferDate = null;
        }
        if (name != "BlastocystTransferDate" && this._Pregnancy.BlastocystTransferDate != null) {
            this._Pregnancy.BlastocystTransferDate = null;
        }
        if (name != "MeasuredDayWeek" && this._Pregnancy.MeasuredPregnancyDay != null) {
            this._Pregnancy.MeasuredPregnancyDay = null;
        }
        if (name != "MeasuredDayWeek" && this._Pregnancy.MeasuredPregnancyWeek != null) {
            this._Pregnancy.MeasuredPregnancyWeek = null;
        }
    }

    private async LastMenstrualPeriodByBlastocystTransferDate(blastocystTransferDate: Date): Promise<Date> {
        let lastMenstrualPeriod: Date;
        lastMenstrualPeriod = blastocystTransferDate.AddDays(-(19));
        return lastMenstrualPeriod;
    }
    private async LastMenstrualPeriodByEggCollectionDate(eggCollectionDate: Date): Promise<Date> {
        let lastMenstrualPeriod: Date;
        lastMenstrualPeriod = eggCollectionDate.AddDays(-(14));
        return lastMenstrualPeriod;
    }
    private async LastMenstrualPeriodByEmbryoTransferDate(embryoTransferDate: Date): Promise<Date> {
        let lastMenstrualPeriod: Date;
        lastMenstrualPeriod = embryoTransferDate.AddDays(-(16));
        return lastMenstrualPeriod;
    }

    private async GetEstimatedBirthDate(lastMenstrualPeriod: Date): Promise<Date> {
        let estimatedBirthDate: Date = lastMenstrualPeriod.AddDays(280); //Gebelik Süreci tahmini doğum tarihi => yaklaşık 40 hafta = 280 gün
        return estimatedBirthDate;
    }
    private async GetGestationalAgeRisk(birthDate: Date): Promise<GestationalAgeEnum> {
        let age: number = Convert.ToInt32(new Date().getFullYear()) - Convert.ToInt32(birthDate.getFullYear());
        if (new Date().getMonth() < birthDate.getMonth()) {
            age = age - 1;
        }
        if (age < 18) {
            return GestationalAgeEnum.TeenagePregnancy;
        }
        else if (age > 35) {
            return GestationalAgeEnum.MidLifePregnancy;
        }
        else {
            return GestationalAgeEnum.NormalPregnancy;
        }
    }
    private LastMenstrualPeriodByMeasuredDate(measuredPregnancyDay: number, measuredPregnancyWeek: number, measuredPregnancyDate: Date): Date {
        //muayene tarihi bugünün tarihi olduğu için hesaba dahil edilmedi
        let lastMenstrualPeriod: Date = new Date();
        let todayDate = new Date();
        let examinationDaysAgo: number = Math.floor((todayDate.getTime() - measuredPregnancyDate.getTime()) / (24 * 60 * 60 * 1000)); //günlemenin kaç gün önce yapıldığı
        let measuredDay: number = Convert.ToInt32(measuredPregnancyDay) + (Convert.ToInt32(measuredPregnancyWeek) * 7); //günleme toplam gün sayısı = günleme günü + (günleme haftası*7)
        lastMenstrualPeriod = todayDate.AddDays(-(examinationDaysAgo)); //measuredPregnancyDate.AddDays(examinationDaysAgo);//günlemenin yapıldığı muayene tarihi hesaplandı
        lastMenstrualPeriod = lastMenstrualPeriod.AddDays(-(measuredDay)); //measuredPregnancyDate.AddDays(-(measuredDay));//günleme toplam gün sayısı kadar geriye gidilerek son adet tarihi hesaplandı
        return lastMenstrualPeriod;
    }
    private async MeasuredPregnancyDay_TextChanged(): Promise<void> {
        if (this._Pregnancy.MeasuredPregnancyDate == null) {
            this._Pregnancy.MeasuredPregnancyDate = new Date(); //Date.Now;
        }
        if (this._Pregnancy.MeasuredPregnancyDay != null && this._Pregnancy.MeasuredPregnancyDay.toString() != "") {
            if (this._Pregnancy.MeasuredPregnancyWeek == null || this._Pregnancy.MeasuredPregnancyWeek.toString() == "") {
                this._Pregnancy.LastMenstrualPeriod = this.LastMenstrualPeriodByMeasuredDate(this._Pregnancy.MeasuredPregnancyDay, 0, this._Pregnancy.MeasuredPregnancyDate);
            }
            else {
                this._Pregnancy.LastMenstrualPeriod = this.LastMenstrualPeriodByMeasuredDate(this._Pregnancy.MeasuredPregnancyDay, this._Pregnancy.MeasuredPregnancyWeek, this._Pregnancy.MeasuredPregnancyDate);
            }
            this.clearScreen("MeasuredDayWeek");
        }
    }
    private async MeasuredPregnancyWeek_TextChanged(): Promise<void> {
        if (this._Pregnancy.MeasuredPregnancyDate == null) {
            this._Pregnancy.MeasuredPregnancyDate = new Date(); //Date.Now;
        }
        if (this._Pregnancy.MeasuredPregnancyWeek != null || this._Pregnancy.MeasuredPregnancyWeek.toString() != "") {
            if (this._Pregnancy.MeasuredPregnancyDay == null || this._Pregnancy.MeasuredPregnancyDay.toString() == "") {
                this._Pregnancy.LastMenstrualPeriod = this.LastMenstrualPeriodByMeasuredDate(0, this._Pregnancy.MeasuredPregnancyWeek, this._Pregnancy.MeasuredPregnancyDate);
            }
            else {
                this._Pregnancy.LastMenstrualPeriod = this.LastMenstrualPeriodByMeasuredDate(this._Pregnancy.MeasuredPregnancyDay, this._Pregnancy.MeasuredPregnancyWeek, this._Pregnancy.MeasuredPregnancyDate);
            }
            this.clearScreen("MeasuredDayWeek");
        }
    }

    protected async PreScript() {
        super.PreScript();
        this.GetGestationalAgeRisk(Convert.ToDateTime(this.pregnancyStartFormViewModel._Patient.BirthDate)).then(c => {
            this._Pregnancy.RiskOfGestationalAge = c;
        });
        //this.pregnancyStartFormViewModel._Pregnancy.MeasuredPregnancyDate = new Date(); //Date.Now;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Pregnancy();
        this.pregnancyStartFormViewModel = new PregnancyStartFormViewModel();
        this._ViewModel = this.pregnancyStartFormViewModel;
        this.pregnancyStartFormViewModel._Pregnancy = this._TTObject as Pregnancy;
        this.pregnancyStartFormViewModel._Pregnancy.PregnancyNotification = new Array<PregnancyNotification>();
    }

    protected loadViewModel() {
        let that = this;
        that.pregnancyStartFormViewModel = this._ViewModel as PregnancyStartFormViewModel;
        that._TTObject = this.pregnancyStartFormViewModel._Pregnancy;
        if (this.pregnancyStartFormViewModel == null)
            this.pregnancyStartFormViewModel = new PregnancyStartFormViewModel();
        if (this.pregnancyStartFormViewModel._Pregnancy == null)
            this.pregnancyStartFormViewModel._Pregnancy = new Pregnancy();
        that.pregnancyStartFormViewModel._Pregnancy.PregnancyNotification = that.pregnancyStartFormViewModel.PregnancyNotificationGridList;
        for (let detailItem of that.pregnancyStartFormViewModel.PregnancyNotificationGridList) {
            let notificationObjectID = detailItem["Notification"];
            if (notificationObjectID != null && (typeof notificationObjectID === "string")) {
                let notification = that.pregnancyStartFormViewModel.SKRSGebeBilgilendirmeveDanismanliks.find(o => o.ObjectID.toString() === notificationObjectID.toString());
                 if (notification) {
                    detailItem.Notification = notification;
                }
            }
        }
        //let todayDate = new Date();
        //this.pregnancyStartFormViewModel._Pregnancy.MeasuredPregnancyDate = todayDate;
        this.sendViewModelToParent.emit(that.pregnancyStartFormViewModel);
    }

    async ngOnInit() {
        let that = this;
        await this.load(PregnancyStartFormViewModel);
  
    }



    public onBlastocystTransferDateChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.BlastocystTransferDate != event) {
                this._Pregnancy.BlastocystTransferDate = event;
                this.LastMenstrualPeriodByBlastocystTransferDate(event).then(c => {
                    this._Pregnancy.LastMenstrualPeriod = c;
                });
                this.clearScreen("BlastocystTransferDate");
            }
        }
    }

    public onEggCollectionDateChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.EggCollectionDate != event) {
                this._Pregnancy.EggCollectionDate = event;
                this.LastMenstrualPeriodByEggCollectionDate(event).then(c => {
                    this._Pregnancy.LastMenstrualPeriod = c;
                });
                this.clearScreen("EggCollectionDate");
            }
        }
    }

    public onEmbryoTransferDateChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.EmbryoTransferDate != event) {
                this._Pregnancy.EmbryoTransferDate = event;
                this.LastMenstrualPeriodByEmbryoTransferDate(event).then(c => {
                    this._Pregnancy.LastMenstrualPeriod = c;
                });
                this.clearScreen("EmbryoTransferDate");
            }
        }
    }

    public onEstimatedBirthDateChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.EstimatedBirthDate != event) {
                this._Pregnancy.EstimatedBirthDate = event;
            }
        }
    }

    public onLastMenstrualPeriodChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.LastMenstrualPeriod != event) {
                this._Pregnancy.LastMenstrualPeriod = event;
            }
            this.GetEstimatedBirthDate(event).then(c => {
                this._Pregnancy.EstimatedBirthDate = c;
            });
        }
    }

    public onMeasuredPregnancyDateChanged(event): void {
        if (event != null) {//Günleme Tarihi readonly olarak şimdiki tarih
            if (this._Pregnancy != null && this._Pregnancy.MeasuredPregnancyDate != event) {
                this._Pregnancy.MeasuredPregnancyDate = event;
                if (this._Pregnancy.MeasuredPregnancyDay != null) {
                    if (this._Pregnancy.MeasuredPregnancyWeek != null) {
                        this._Pregnancy.LastMenstrualPeriod = this.LastMenstrualPeriodByMeasuredDate(this._Pregnancy.MeasuredPregnancyDay, this._Pregnancy.MeasuredPregnancyWeek, this._Pregnancy.MeasuredPregnancyDate);
                    }
                    else {
                        this._Pregnancy.LastMenstrualPeriod = this.LastMenstrualPeriodByMeasuredDate(this._Pregnancy.MeasuredPregnancyDay, 0, this._Pregnancy.MeasuredPregnancyDate);
                    }
                }
                else {
                    if (this._Pregnancy.MeasuredPregnancyWeek != null) {
                        this._Pregnancy.LastMenstrualPeriod = this.LastMenstrualPeriodByMeasuredDate(0, this._Pregnancy.MeasuredPregnancyWeek, this._Pregnancy.MeasuredPregnancyDate);
                    }
                    else {
                        this._Pregnancy.LastMenstrualPeriod = this.LastMenstrualPeriodByMeasuredDate(0, 0, this._Pregnancy.MeasuredPregnancyDate);
                    }
                }
                this.clearScreen("MeasuredDayWeek");
            }
        }
    }

    public onMeasuredPregnancyDayChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.MeasuredPregnancyDay != event) {
                this._Pregnancy.MeasuredPregnancyDay = event;
            }
        }
        this.MeasuredPregnancyDay_TextChanged();
    }

    public onMeasuredPregnancyWeekChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.MeasuredPregnancyWeek != event) {
                this._Pregnancy.MeasuredPregnancyWeek = event;
            }
        }
        this.MeasuredPregnancyWeek_TextChanged();
    }

    public onPregnancyInformationChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.PregnancyInformation != event) {
                this._Pregnancy.PregnancyInformation = event;
            }
        }
    }

    public onPregnancyTypeChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.PregnancyType != event) {
                this._Pregnancy.PregnancyType = event;
            }
        }
    }

    public onRiskOfGestationalAgeChanged(event): void {
        if (event != null) {
            if (this._Pregnancy != null && this._Pregnancy.RiskOfGestationalAge != event) {
                this._Pregnancy.RiskOfGestationalAge = event;
            }
        }
    }

    public setLastMenstrualDate(value: any)
    {
        let component = value.component,
        prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        let _data = value.data as GebelikBildirim;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            
            let that = this;
            try {
                if(_data.sonadettarihi != null)
                {
                    this._Pregnancy.LastMenstrualPeriod = new Date(_data.sonadettarihi).AddHours(-3);
                    this.showGebelikBildirim =false;
                }
            }
            catch (error) {
                that.messageService.showError(error);
            }
        }
    }

    public onGebelikBildirimHiding()
    {
        this.showGebelikBildirim =false;
    }

    protected redirectProperties(): void {
        redirectProperty(this.LastMenstrualPeriod, "Value", this.__ttObject, "LastMenstrualPeriod");
        redirectProperty(this.EggCollectionDate, "Value", this.__ttObject, "EggCollectionDate");
        redirectProperty(this.EmbryoTransferDate, "Value", this.__ttObject, "EmbryoTransferDate");
        redirectProperty(this.BlastocystTransferDate, "Value", this.__ttObject, "BlastocystTransferDate");
        redirectProperty(this.MeasuredPregnancyDate, "Value", this.__ttObject, "MeasuredPregnancyDate");
        redirectProperty(this.MeasuredPregnancyWeek, "Text", this.__ttObject, "MeasuredPregnancyWeek");
        redirectProperty(this.MeasuredPregnancyDay, "Text", this.__ttObject, "MeasuredPregnancyDay");
        redirectProperty(this.PregnancyType, "Value", this.__ttObject, "PregnancyType");
        redirectProperty(this.RiskOfGestationalAge, "Value", this.__ttObject, "RiskOfGestationalAge");
        redirectProperty(this.PregnancyInformation, "Text", this.__ttObject, "PregnancyInformation");
        redirectProperty(this.EstimatedBirthDate, "Value", this.__ttObject, "EstimatedBirthDate");
    }

    public initFormControls(): void {
        this.labelRiskOfGestationalAge = new TTVisual.TTLabel();
        this.labelRiskOfGestationalAge.Text = i18n("M14580", "Gebelik Yaş Riski");
        this.labelRiskOfGestationalAge.Name = "labelRiskOfGestationalAge";
        this.labelRiskOfGestationalAge.TabIndex = 61;

        this.RiskOfGestationalAge = new TTVisual.TTEnumComboBox();
        this.RiskOfGestationalAge.DataTypeName = "GestationalAgeEnum";
        this.RiskOfGestationalAge.Name = "RiskOfGestationalAge";
        this.RiskOfGestationalAge.TabIndex = 60;

        this.labelPregnancyType = new TTVisual.TTLabel();
        this.labelPregnancyType.Text = i18n("M14579", "Gebelik Tipi");
        this.labelPregnancyType.Name = "labelPregnancyType";
        this.labelPregnancyType.TabIndex = 59;

        this.PregnancyType = new TTVisual.TTEnumComboBox();
        this.PregnancyType.DataTypeName = "PregnancyTypeEnum";
        this.PregnancyType.Name = "PregnancyType";
        this.PregnancyType.TabIndex = 58;

        this.labelPregnancyInformation = new TTVisual.TTLabel();
        this.labelPregnancyInformation.Text = i18n("M14566", "Gebelik Notu");
        this.labelPregnancyInformation.Name = "labelPregnancyInformation";
        this.labelPregnancyInformation.TabIndex = 53;

        this.PregnancyInformation = new TTVisual.TTTextBox();
        this.PregnancyInformation.Name = "PregnancyInformation";
        this.PregnancyInformation.TabIndex = 52;

        this.MeasuredPregnancyWeek = new TTVisual.TTTextBox();
        this.MeasuredPregnancyWeek.Name = "MeasuredPregnancyWeek";
        this.MeasuredPregnancyWeek.TabIndex = 48;

        this.MeasuredPregnancyDay = new TTVisual.TTTextBox();
        this.MeasuredPregnancyDay.Name = "MeasuredPregnancyDay";
        this.MeasuredPregnancyDay.TabIndex = 46;

        this.labelMeasuredPregnancyWeek = new TTVisual.TTLabel();
        this.labelMeasuredPregnancyWeek.Text = i18n("M15022", "Günleme Haftası");
        this.labelMeasuredPregnancyWeek.Name = "labelMeasuredPregnancyWeek";
        this.labelMeasuredPregnancyWeek.TabIndex = 49;

        this.labelMeasuredPregnancyDay = new TTVisual.TTLabel();
        this.labelMeasuredPregnancyDay.Text = i18n("M15021", "Günleme Günü");
        this.labelMeasuredPregnancyDay.Name = "labelMeasuredPregnancyDay";
        this.labelMeasuredPregnancyDay.TabIndex = 47;

        this.labelMeasuredPregnancyDate = new TTVisual.TTLabel();
        this.labelMeasuredPregnancyDate.Text = i18n("M15023", "Günleme Tarihi");
        this.labelMeasuredPregnancyDate.Name = "labelMeasuredPregnancyDate";
        this.labelMeasuredPregnancyDate.TabIndex = 45;

        this.MeasuredPregnancyDate = new TTVisual.TTDateTimePicker();
        this.MeasuredPregnancyDate.Format = DateTimePickerFormat.Long;
        this.MeasuredPregnancyDate.Name = "MeasuredPregnancyDate";
        //this.MeasuredPregnancyDate.ReadOnly = true;
        this.MeasuredPregnancyDate.TabIndex = 44;

        this.labelLastMenstrualPeriod = new TTVisual.TTLabel();
        this.labelLastMenstrualPeriod.Text = i18n("M22037", "Son Adet Tarihi");
        this.labelLastMenstrualPeriod.Name = "labelLastMenstrualPeriod";
        this.labelLastMenstrualPeriod.TabIndex = 43;

        this.LastMenstrualPeriod = new TTVisual.TTDateTimePicker();
        this.LastMenstrualPeriod.Format = DateTimePickerFormat.Long;
        this.LastMenstrualPeriod.Name = "LastMenstrualPeriod";
        this.LastMenstrualPeriod.TabIndex = 42;

        this.labelEstimatedBirthDate = new TTVisual.TTLabel();
        this.labelEstimatedBirthDate.Text = i18n("M22597", "Tahmini Doğum Tarihi");
        this.labelEstimatedBirthDate.Name = "labelEstimatedBirthDate";
        this.labelEstimatedBirthDate.TabIndex = 41;

        this.EstimatedBirthDate = new TTVisual.TTDateTimePicker();
        this.EstimatedBirthDate.Format = DateTimePickerFormat.Long;
        this.EstimatedBirthDate.Name = "EstimatedBirthDate";
        this.EstimatedBirthDate.TabIndex = 40;

        this.labelEmbryoTransferDate = new TTVisual.TTLabel();
        this.labelEmbryoTransferDate.Text = i18n("M13638", "Embriyo Transfer Tarihi");
        this.labelEmbryoTransferDate.Name = "labelEmbryoTransferDate";
        this.labelEmbryoTransferDate.TabIndex = 39;

        this.EmbryoTransferDate = new TTVisual.TTDateTimePicker();
        this.EmbryoTransferDate.Format = DateTimePickerFormat.Long;
        this.EmbryoTransferDate.Name = "EmbryoTransferDate";
        this.EmbryoTransferDate.TabIndex = 38;

        this.labelEggCollectionDate = new TTVisual.TTLabel();
        this.labelEggCollectionDate.Text = i18n("M24721", "Yumurta Toplama Tarihi");
        this.labelEggCollectionDate.Name = "labelEggCollectionDate";
        this.labelEggCollectionDate.TabIndex = 37;

        this.EggCollectionDate = new TTVisual.TTDateTimePicker();
        this.EggCollectionDate.Format = DateTimePickerFormat.Long;
        this.EggCollectionDate.Name = "EggCollectionDate";
        this.EggCollectionDate.TabIndex = 36;

        this.labelBlastocystTransferDate = new TTVisual.TTLabel();
        this.labelBlastocystTransferDate.Text = i18n("M11957", "Blastokist Transfer Tarihi");
        this.labelBlastocystTransferDate.Name = "labelBlastocystTransferDate";
        this.labelBlastocystTransferDate.TabIndex = 35;

        this.BlastocystTransferDate = new TTVisual.TTDateTimePicker();
        this.BlastocystTransferDate.Format = DateTimePickerFormat.Long;
        this.BlastocystTransferDate.Name = "BlastocystTransferDate";
        this.BlastocystTransferDate.TabIndex = 34;

        this.PregnancyNotification = new TTVisual.TTGrid();
        this.PregnancyNotification.Name = "PregnancyNotification";
        this.PregnancyNotification.TabIndex = 5;

        this.NotificationPregnancyNotification = new TTVisual.TTListBoxColumn();
        this.NotificationPregnancyNotification.ListDefName = "SKRSGebeBilgilendirmeveDanismanlikList";
        this.NotificationPregnancyNotification.DataMember = "Notification";
        this.NotificationPregnancyNotification.DisplayIndex = 0;
        this.NotificationPregnancyNotification.HeaderText = i18n("M11794", "Bilgilendirme");
        this.NotificationPregnancyNotification.Name = "NotificationPregnancyNotification";
        this.NotificationPregnancyNotification.Width = 300;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M14541", "Gebe Bilgilendirme ve Danışmanlık");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 5;

        this.PregnancyNotificationColumns = [this.NotificationPregnancyNotification];
        this.Controls = [this.labelRiskOfGestationalAge, this.RiskOfGestationalAge, this.labelPregnancyType, this.PregnancyType, this.labelPregnancyInformation, this.PregnancyInformation, this.MeasuredPregnancyWeek, this.MeasuredPregnancyDay, this.labelMeasuredPregnancyWeek, this.labelMeasuredPregnancyDay, this.labelMeasuredPregnancyDate, this.MeasuredPregnancyDate, this.labelLastMenstrualPeriod, this.LastMenstrualPeriod, this.labelEstimatedBirthDate, this.EstimatedBirthDate, this.labelEmbryoTransferDate, this.EmbryoTransferDate, this.labelEggCollectionDate, this.EggCollectionDate, this.labelBlastocystTransferDate, this.BlastocystTransferDate, this.PregnancyNotification, this.NotificationPregnancyNotification, this.ttlabel1];

    }


}
