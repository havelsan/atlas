//$BEFBBD69
import { Component, OnInit, NgZone } from '@angular/core';
import { OutMorgueRequestFormViewModel } from './OutMorgueRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Morgue } from 'NebulaClient/Model/AtlasClientModel';
import { MernisDeathReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { SKRSOlumYeri } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'OutMorgueRequestForm',
    templateUrl: './OutMorgueRequestForm.html',
    providers: [MessageService]
})
export class OutMorgueRequestForm extends EpisodeActionForm implements OnInit {
    AddressOfAdmittedFrom: TTVisual.ITTTextBox;
    BirthPlace: TTVisual.ITTTextBox;
    BirthDate: TTVisual.ITTDateTimePicker;
    CitizenshipNoOfAdmittedFrom: TTVisual.ITTTextBox;
    cmdAutopsy: TTVisual.ITTButton;
    DateOfDeathReport: TTVisual.ITTDateTimePicker;
    DateTimeOfDeath: TTVisual.ITTDateTimePicker;
    DeathBodyAdmittedFrom: TTVisual.ITTTextBox;
    SKRSDeathPlace: TTVisual.ITTObjectListBox;
    DeathReportNo: TTVisual.ITTTextBox;
    labelDateTimeOfDeath: TTVisual.ITTLabel;
    labelDoctorFixed: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelReasonForDeath: TTVisual.ITTLabel;
    labelSenderDoctor: TTVisual.ITTLabel;
    MernisDeathReason: TTVisual.ITTObjectListBox;
    PatientName: TTVisual.ITTTextBox;
    PatientSex: TTVisual.ITTEnumComboBox;
    PhoneNumberOfAdmittedFrom: TTVisual.ITTTextBox;
    ProtocolNo: TTVisual.ITTTextBox;
    SenderDoctor: TTVisual.ITTObjectListBox;
    StatisticalDeathReason: TTVisual.ITTEnumComboBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    ttlabel19: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    TTRichTextBoxUserControl: TTVisual.ITTRichTextBoxControl;
    tttabcontrolMain: TTVisual.ITTTabControl;
    tttabpageMorgue: TTVisual.ITTTabPage;
    tttabpageRreport: TTVisual.ITTTabPage;
    FoundationToFixDeath: TTVisual.ITTTextBox;
    ExternalDoctorFixedUniqueNo: TTVisual.ITTTextBox;
    ExternalDoctorFixed: TTVisual.ITTTextBox;
    ObjectsFromPatient: TTVisual.ITTTextBox;
    public outMorgueRequestFormViewModel: OutMorgueRequestFormViewModel = new OutMorgueRequestFormViewModel();
    public get _Morgue(): Morgue {
        return this._TTObject as Morgue;
    }
    private OutMorgueRequestForm_DocumentUrl: string = '/api/MorgueService/OutMorgueRequestForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.OutMorgueRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

   //private async cmdAutopsy_Click(): Promise<void> {
        //TODO:ShowEdit!
        ////Yeni Patoloji İsteği başlatır
        //PathologyRequest pathology;
        //TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = objectContext.BeginSavePoint();
        //try
        //{
        //    pathology = new PathologyRequest(objectContext,this._EpisodeAction);
        //    pathology.MasterResource = this._Morgue.MasterResource;
        //    TTForm frm = TTForm.GetEditForm(pathology);
        //    if(frm.ShowEdit(this.FindForm(), pathology) == DialogResult.OK)
        //        objectContext.Save();
        //}
        //catch (Exception ex)
        //{
        //    objectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    objectContext.Dispose();
        //}
    //    let a = 1;
    //}
    //private async StatisticalDeathReason_SelectedIndexChanged(): Promise<void> {
     //   if (this._Morgue.StatisticalDeathReason === TTObjectClasses.StatisticalDeathReason.DeadBirth) {
     //       let deadBirth: boolean = false;
       //     for (let ea of this._Morgue.Episode.EpisodeActions) {
         //       if (ea instanceof BirthReport) {
           //         deadBirth = true;
             //       break;
               // }
           // }
            //if (!deadBirth) {
             //   this.StatisticalDeathReason.SelectedItem = null;
              //  TTVisual.InfoBox.Show('Bu ölüm sebebini yanlızca ölü doğan bebekler için seçebilirsiniz.');
            //}
       // }
    //}
    //protected async PreScript(): Promise<void> {
      //  this.DropStateButton(Morgue.MorgueStates.Cancelled);
        //this.PatientName.Text = this._Morgue.FullPatientName;
        //if (this._Morgue.StatisticalDeathReason === TTObjectClasses.StatisticalDeathReason.DeadBirth)
         //   this.StatisticalDeathReason.ReadOnly = true;
    //}

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Morgue();
        this.outMorgueRequestFormViewModel = new OutMorgueRequestFormViewModel();
        this._ViewModel = this.outMorgueRequestFormViewModel;
        this.outMorgueRequestFormViewModel._Morgue = this._TTObject as Morgue;
        this.outMorgueRequestFormViewModel._Morgue.SKRSDeathPlace = new SKRSOlumYeri();
        this.outMorgueRequestFormViewModel._Morgue.Nurse = new ResUser();
        this.outMorgueRequestFormViewModel._Morgue.MernisDeathReasons = new MernisDeathReasonDefinition();
        this.outMorgueRequestFormViewModel._Morgue.Episode = new Episode();
        this.outMorgueRequestFormViewModel._Morgue.Episode.Patient = new Patient();
        this.outMorgueRequestFormViewModel._Morgue.Episode.Patient.Sex = new SKRSCinsiyet();
        //this.outMorgueRequestFormViewModel._Morgue.Episode.Patient.CityOfBirth = new SKRSILKodlari();
        this.outMorgueRequestFormViewModel._Morgue.SenderDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;
        that.outMorgueRequestFormViewModel = this._ViewModel as OutMorgueRequestFormViewModel;
        that._TTObject = this.outMorgueRequestFormViewModel._Morgue;
        if (this.outMorgueRequestFormViewModel == null)
            this.outMorgueRequestFormViewModel = new OutMorgueRequestFormViewModel();
        if (this.outMorgueRequestFormViewModel._Morgue == null)
            this.outMorgueRequestFormViewModel._Morgue = new Morgue();
        let sKRSDeathPlaceObjectID = that.outMorgueRequestFormViewModel._Morgue["SKRSDeathPlace"];
        if (sKRSDeathPlaceObjectID != null && (typeof sKRSDeathPlaceObjectID === "string")) {
            let sKRSDeathPlace = that.outMorgueRequestFormViewModel.SKRSOlumYeris.find(o => o.ObjectID.toString() === sKRSDeathPlaceObjectID.toString());
             if (sKRSDeathPlace) {
                that.outMorgueRequestFormViewModel._Morgue.SKRSDeathPlace = sKRSDeathPlace;
            }
        }let nurseObjectID = that.outMorgueRequestFormViewModel._Morgue["Nurse"];
        if (nurseObjectID != null && (typeof nurseObjectID === "string")) {
            let nurse = that.outMorgueRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === nurseObjectID.toString());
             if (nurse) {
                that.outMorgueRequestFormViewModel._Morgue.Nurse = nurse;
            }
        }
        let mernisDeathReasonsObjectID = that.outMorgueRequestFormViewModel._Morgue["MernisDeathReasons"];
        if (mernisDeathReasonsObjectID != null && (typeof mernisDeathReasonsObjectID === "string")) {
            let mernisDeathReasons = that.outMorgueRequestFormViewModel.MernisDeathReasonDefinitions.find(o => o.ObjectID.toString() === mernisDeathReasonsObjectID.toString());
             if (mernisDeathReasons) {
                that.outMorgueRequestFormViewModel._Morgue.MernisDeathReasons = mernisDeathReasons;
            }
        }
        let episodeObjectID = that.outMorgueRequestFormViewModel._Morgue["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.outMorgueRequestFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.outMorgueRequestFormViewModel._Morgue.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === "string")) {
                    let patient = that.outMorgueRequestFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                    if (patient != null) {
                        let sexObjectID = patient["Sex"];
                        if (sexObjectID != null && (typeof sexObjectID === "string")) {
                            let sex = that.outMorgueRequestFormViewModel.SKRSCinsiyets.find(o => o.ObjectID.toString() === sexObjectID.toString());
                             if (sex) {
                                patient.Sex = sex;
                            }
                        }
                    }
                    /*if (patient != null) {
                        let cityOfBirthObjectID = patient["CityOfBirth"];
                        if (cityOfBirthObjectID != null && (typeof cityOfBirthObjectID === "string")) {
                            let cityOfBirth = that.outMorgueRequestFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === cityOfBirthObjectID.toString());
                            patient.CityOfBirth = cityOfBirth;
                        }
                    }*/
                }
            }
        }
        let senderDoctorObjectID = that.outMorgueRequestFormViewModel._Morgue["SenderDoctor"];
        if (senderDoctorObjectID != null && (typeof senderDoctorObjectID === "string")) {
            let senderDoctor = that.outMorgueRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === senderDoctorObjectID.toString());
             if (senderDoctor) {
                that.outMorgueRequestFormViewModel._Morgue.SenderDoctor = senderDoctor;
            }
        }

    }

    async ngOnInit() {
        await this.load();
    }

    public onAddressOfAdmittedFromChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.AddressOfAdmittedFrom != event) {
                this._Morgue.AddressOfAdmittedFrom = event;
            }
        }
    }

    public onBirthPlaceChanged(event): void {
        /*if (event != null) {
            if (this._Morgue != null &&
                this._Morgue.Episode != null &&
                this._Morgue.Episode.Patient != null && this._Morgue.Episode.Patient.CityOfBirth != event) {
                this._Morgue.Episode.Patient.CityOfBirth = event;
            }
        }*/
    }

    public onBirthDateChanged(event): void {
        /*if (event != null) {
            if (this._Morgue != null &&
                this._Morgue.Episode != null &&
                this._Morgue.Episode.Patient != null && this._Morgue.Episode.Patient.BirthDate != event) {
                this._Morgue.Episode.Patient.BirthDate = event;
            }
        }*/
    }

    public onCitizenshipNoOfAdmittedFromChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.CitizenshipNoOfAdmittedFrom != event) {
                this._Morgue.CitizenshipNoOfAdmittedFrom = event;
            }
        }
    }

    public onDateOfDeathReportChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DateOfDeathReport != event) {
                this._Morgue.DateOfDeathReport = event;
            }
        }
    }

    public onDateTimeOfDeathChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DateTimeOfDeath != event) {
                this._Morgue.DateTimeOfDeath = event;
            }
        }
    }

    public onDeathBodyAdmittedFromChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DeathBodyAdmittedFrom != event) {
                this._Morgue.DeathBodyAdmittedFrom = event;
            }
        }
    }

    public onSKRSDeathPlaceChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SKRSDeathPlace != event) {
                this._Morgue.SKRSDeathPlace = event;
            }
        }
    }

    public onDeathReportNoChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.DeathReportNo != event) {
                this._Morgue.DeathReportNo = event;
            }
        }
    }

    public onMernisDeathReasonChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.MernisDeathReasons != event) {
                this._Morgue.MernisDeathReasons = event;
            }
        }
    }

    public onPatientSexChanged(event): void {
        if (event != null) {
            if (this._Morgue != null &&
                this._Morgue.Episode != null &&
                this._Morgue.Episode.Patient != null && this._Morgue.Episode.Patient.Sex != event) {
                this._Morgue.Episode.Patient.Sex = event;
            }
        }
    }

    public onPhoneNumberOfAdmittedFromChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.PhoneNumberOfAdmittedFrom != event) {
                this._Morgue.PhoneNumberOfAdmittedFrom = event;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ProtocolNo != event) {
                this._Morgue.ProtocolNo = event;
            }
        }
    }

    public onSenderDoctorChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.SenderDoctor != event) {
                this._Morgue.SenderDoctor = event;
            }
        }
    }

    public onStatisticalDeathReasonChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.StatisticalDeathReason != event) {
                this._Morgue.StatisticalDeathReason = event;
            }
        }
    }

    public onttobjectlistbox1Changed(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.Nurse != event) {
                this._Morgue.Nurse = event;
            }
        }
    }

    public onTTRichTextBoxUserControlChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.Report != event) {
                this._Morgue.Report = event;
            }
        }
    }

    public onFoundationToFixDeathChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.FoundationToFixDeath != event) {
                this._Morgue.FoundationToFixDeath = event;
            }
        }
    }

    public onExternalDoctorFixedUniqueNoChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ExternalDoctorFixedUniqueNo != event) {
                this._Morgue.ExternalDoctorFixedUniqueNo = event;
            }
        }
    }

    public onExternalDoctorFixedChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ExternalDoctorFixed != event) {
                this._Morgue.ExternalDoctorFixed = event;
            }
        }
    }

    public onObjectsFromPatientChanged(event): void {
        if (event != null) {
            if (this._Morgue != null && this._Morgue.ObjectsFromPatient != event) {
                this._Morgue.ObjectsFromPatient = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.FoundationToFixDeath, "Text", this.__ttObject, "FoundationToFixDeath");
        redirectProperty(this.DeathReportNo, "Text", this.__ttObject, "DeathReportNo");
        redirectProperty(this.PatientSex, "Value", this.__ttObject, "Episode.Patient.Sex");
        redirectProperty(this.ObjectsFromPatient, "Text", this.__ttObject, "ObjectsFromPatient");
        redirectProperty(this.ExternalDoctorFixedUniqueNo, "Text", this.__ttObject, "ExternalDoctorFixedUniqueNo");
        redirectProperty(this.DateTimeOfDeath, "Value", this.__ttObject, "DateTimeOfDeath");
        redirectProperty(this.StatisticalDeathReason, "Value", this.__ttObject, "StatisticalDeathReason");
        redirectProperty(this.DeathBodyAdmittedFrom, "Text", this.__ttObject, "DeathBodyAdmittedFrom");
        redirectProperty(this.CitizenshipNoOfAdmittedFrom, "Text", this.__ttObject, "CitizenshipNoOfAdmittedFrom");
        redirectProperty(this.PhoneNumberOfAdmittedFrom, "Text", this.__ttObject, "PhoneNumberOfAdmittedFrom");
        redirectProperty(this.AddressOfAdmittedFrom, "Text", this.__ttObject, "AddressOfAdmittedFrom");
        redirectProperty(this.ExternalDoctorFixed, "Text", this.__ttObject, "ExternalDoctorFixed");
        redirectProperty(this.DateOfDeathReport, "Value", this.__ttObject, "DateOfDeathReport");
        redirectProperty(this.TTRichTextBoxUserControl, "Rtf", this.__ttObject, "Report");
    }

    public initFormControls(): void {
        this.tttabcontrolMain = new TTVisual.TTTabControl();
        this.tttabcontrolMain.Name = "tttabcontrolMain";
        this.tttabcontrolMain.TabIndex = 0;

        this.tttabpageMorgue = new TTVisual.TTTabPage();
        this.tttabpageMorgue.DisplayIndex = 0;
        this.tttabpageMorgue.BackColor = "#FFFFFF";
        this.tttabpageMorgue.TabIndex = 0;
        this.tttabpageMorgue.Text = i18n("M19124", "Morg");
        this.tttabpageMorgue.Name = "tttabpageMorgue";

        this.ObjectsFromPatient = new TTVisual.TTTextBox();
        this.ObjectsFromPatient.Multiline = true;
        this.ObjectsFromPatient.Name = "ObjectsFromPatient";
        this.ObjectsFromPatient.Height = "72px";
        this.ObjectsFromPatient.TabIndex = 121;

        this.SKRSDeathPlace = new TTVisual.TTObjectListBox();
        this.SKRSDeathPlace.ListDefName = "SKRSOlumYeriList";
        this.SKRSDeathPlace.Name = "SKRSDeathPlace";
        this.SKRSDeathPlace.TabIndex = 122;

        this.cmdAutopsy = new TTVisual.TTButton();
        this.cmdAutopsy.Text = i18n("M19825", "Otopsi İstek");
        this.cmdAutopsy.Name = "cmdAutopsy";
        this.cmdAutopsy.TabIndex = 58;
        this.cmdAutopsy.Visible = false;

        this.ttlabel19 = new TTVisual.TTLabel();
        this.ttlabel19.Text = "Çıkanlar";
        this.ttlabel19.Name = "ttlabel19";
        this.ttlabel19.TabIndex = 120;

        this.ttlabel17 = new TTVisual.TTLabel();
        this.ttlabel17.Text = "Hastanın Üzerinden";
        this.ttlabel17.Name = "ttlabel17";
        this.ttlabel17.TabIndex = 119;

        this.ExternalDoctorFixed = new TTVisual.TTTextBox();
        this.ExternalDoctorFixed.Name = "ExternalDoctorFixed";
        this.ExternalDoctorFixed.TabIndex = 12;

        this.ExternalDoctorFixedUniqueNo = new TTVisual.TTTextBox();
        this.ExternalDoctorFixedUniqueNo.Name = "ExternalDoctorFixedUniqueNo";
        this.ExternalDoctorFixedUniqueNo.TabIndex = 13;

        this.ttlabel18 = new TTVisual.TTLabel();
        this.ttlabel18.Text = i18n("M12860", "Diploma No");
        this.ttlabel18.BackColor = "#000000";
        this.ttlabel18.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel18.ForeColor = "#000000";
        this.ttlabel18.Name = "ttlabel18";
        this.ttlabel18.TabIndex = 38;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "UserListDefinition";
        this.ttobjectlistbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttobjectlistbox1.ForeColor = "#000000";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 15;

        this.ttlabel16 = new TTVisual.TTLabel();
        this.ttlabel16.Text = "Hemşire";
        this.ttlabel16.BackColor = "#000000";
        this.ttlabel16.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel16.ForeColor = "#000000";
        this.ttlabel16.Name = "ttlabel16";
        this.ttlabel16.TabIndex = 23;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = i18n("M19937", " Ölüm Sebebi");
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 118;

        this.StatisticalDeathReason = new TTVisual.TTEnumComboBox();
        this.StatisticalDeathReason.DataTypeName = "StatisticalDeathReason";
        this.StatisticalDeathReason.Required = true;
        this.StatisticalDeathReason.BackColor = "#FFE3C6";
        this.StatisticalDeathReason.Name = "StatisticalDeathReason";
        this.StatisticalDeathReason.TabIndex = 8;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = i18n("M16587", "İstatistiksel");
        this.ttlabel14.BackColor = "#000000";
        this.ttlabel14.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel14.ForeColor = "#000000";
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 116;

        this.MernisDeathReason = new TTVisual.TTObjectListBox();
        this.MernisDeathReason.ListDefName = "MernisDeathReasonList";
        this.MernisDeathReason.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MernisDeathReason.ForeColor = "#000000";
        this.MernisDeathReason.Name = "MernisDeathReason";
        this.MernisDeathReason.TabIndex = 7;

        this.labelReasonForDeath = new TTVisual.TTLabel();
        this.labelReasonForDeath.Text = "Mernis Ölüm Sebebi";
        this.labelReasonForDeath.BackColor = "#000000";
        this.labelReasonForDeath.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReasonForDeath.ForeColor = "#000000";
        this.labelReasonForDeath.Name = "labelReasonForDeath";
        this.labelReasonForDeath.TabIndex = 114;

        this.PatientSex = new TTVisual.TTEnumComboBox();
        this.PatientSex.DataTypeName = "SexEnum";
        this.PatientSex.BackColor = "#F0F0F0";
        this.PatientSex.Enabled = false;
        this.PatientSex.Name = "PatientSex";
        this.PatientSex.TabIndex = 4;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M19948", "Ölüm Yeri");
        this.ttlabel13.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel13.ForeColor = "#000000";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 97;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M12186", "Cenazeyi Getirenin");
        this.ttgroupbox1.BackColor = "#FFFFFF";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 96;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M10517", "Adı Soyadı");
        this.ttlabel4.BackColor = "#000000";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 50;

        this.CitizenshipNoOfAdmittedFrom = new TTVisual.TTTextBox();
        this.CitizenshipNoOfAdmittedFrom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CitizenshipNoOfAdmittedFrom.Name = "CitizenshipNoOfAdmittedFrom";
        this.CitizenshipNoOfAdmittedFrom.TabIndex = 1;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M22941", "TC Kimlik Numarası");
        this.ttlabel5.BackColor = "#000000";
        this.ttlabel5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 52;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M10553", "Adresi");
        this.ttlabel6.BackColor = "#000000";
        this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 54;

        this.DeathBodyAdmittedFrom = new TTVisual.TTTextBox();
        this.DeathBodyAdmittedFrom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DeathBodyAdmittedFrom.Name = "DeathBodyAdmittedFrom";
        this.DeathBodyAdmittedFrom.TabIndex = 0;

        this.AddressOfAdmittedFrom = new TTVisual.TTTextBox();
        this.AddressOfAdmittedFrom.Multiline = true;
        this.AddressOfAdmittedFrom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.AddressOfAdmittedFrom.Name = "AddressOfAdmittedFrom";
        this.AddressOfAdmittedFrom.TabIndex = 3;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M23138", "Telefon Numarası");
        this.ttlabel7.BackColor = "#000000";
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 56;

        this.PhoneNumberOfAdmittedFrom = new TTVisual.TTTextBox();
        this.PhoneNumberOfAdmittedFrom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PhoneNumberOfAdmittedFrom.Name = "PhoneNumberOfAdmittedFrom";
        this.PhoneNumberOfAdmittedFrom.TabIndex = 2;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M23258", "Tespit Eden Kurum");
        this.ttlabel12.ForeColor = "#000000";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 95;

        this.BirthDate = new TTVisual.TTDateTimePicker();
        this.BirthDate.BackColor = "#F0F0F0";
        this.BirthDate.CustomFormat = "";
        this.BirthDate.Format = DateTimePickerFormat.Short;
        this.BirthDate.Enabled = false;
        this.BirthDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BirthDate.Name = "BirthDate";
        this.BirthDate.TabIndex = 3;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#000000";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 35;

        this.BirthPlace = new TTVisual.TTTextBox();
        this.BirthPlace.ReadOnly = true;
        this.BirthPlace.Name = "BirthPlace";
        this.BirthPlace.TabIndex = 2;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 0;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "Cinsiyeti";
        this.ttlabel9.BackColor = "#000000";
        this.ttlabel9.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 92;

        this.labelDoctorFixed = new TTVisual.TTLabel();
        this.labelDoctorFixed.Text = i18n("M19956", "Ölümü Tespit Eden Tabip");
        this.labelDoctorFixed.BackColor = "#000000";
        this.labelDoctorFixed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelDoctorFixed.ForeColor = "#000000";
        this.labelDoctorFixed.Name = "labelDoctorFixed";
        this.labelDoctorFixed.TabIndex = 38;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M13132", "Doğum Tarihi");
        this.ttlabel8.BackColor = "#000000";
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 90;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M13139", "Doğum Yeri");
        this.ttlabel10.BackColor = "#000000";
        this.ttlabel10.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 88;

        this.labelDateTimeOfDeath = new TTVisual.TTLabel();
        this.labelDateTimeOfDeath.Text = i18n("M19945", "Ölüm Tarihi ve Saati");
        this.labelDateTimeOfDeath.BackColor = "#000000";
        this.labelDateTimeOfDeath.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelDateTimeOfDeath.ForeColor = "#000000";
        this.labelDateTimeOfDeath.Name = "labelDateTimeOfDeath";
        this.labelDateTimeOfDeath.TabIndex = 34;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M10517", "Adı Soyadı");
        this.ttlabel11.BackColor = "#000000";
        this.ttlabel11.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel11.ForeColor = "#000000";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 87;

        this.DateTimeOfDeath = new TTVisual.TTDateTimePicker();
        this.DateTimeOfDeath.CustomFormat = "dd/MM/yyyy HH:mm";
        this.DateTimeOfDeath.Format = DateTimePickerFormat.Custom;
        this.DateTimeOfDeath.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DateTimeOfDeath.Name = "DateTimeOfDeath";
        this.DateTimeOfDeath.TabIndex = 5;

        this.PatientName = new TTVisual.TTTextBox();
        this.PatientName.BackColor = "#F0F0F0";
        this.PatientName.ReadOnly = true;
        this.PatientName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientName.Name = "PatientName";
        this.PatientName.TabIndex = 1;

        this.labelSenderDoctor = new TTVisual.TTLabel();
        this.labelSenderDoctor.Text = i18n("M19139", "Morga Gönderen Tabip");
        this.labelSenderDoctor.BackColor = "#000000";
        this.labelSenderDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSenderDoctor.ForeColor = "#000000";
        this.labelSenderDoctor.Name = "labelSenderDoctor";
        this.labelSenderDoctor.TabIndex = 37;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M19935", "Ölüm Raporunun Numarası");
        this.ttlabel3.BackColor = "#000000";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 48;

        this.DeathReportNo = new TTVisual.TTTextBox();
        this.DeathReportNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DeathReportNo.Name = "DeathReportNo";
        this.DeathReportNo.TabIndex = 10;

        this.SenderDoctor = new TTVisual.TTObjectListBox();
        this.SenderDoctor.ListDefName = "UserListDefinition";
        this.SenderDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SenderDoctor.ForeColor = "#000000";
        this.SenderDoctor.Name = "SenderDoctor";
        this.SenderDoctor.TabIndex = 14;

        this.DateOfDeathReport = new TTVisual.TTDateTimePicker();
        this.DateOfDeathReport.CustomFormat = "";
        this.DateOfDeathReport.Format = DateTimePickerFormat.Short;
        this.DateOfDeathReport.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DateOfDeathReport.Name = "DateOfDeathReport";
        this.DateOfDeathReport.TabIndex = 11;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M19936", "Ölüm Raporunun Tarihi");
        this.ttlabel2.BackColor = "#000000";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 45;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M19932", "Ölüm Nedenini");
        this.ttlabel1.BackColor = "#000000";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 43;

        this.FoundationToFixDeath = new TTVisual.TTTextBox();
        this.FoundationToFixDeath.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FoundationToFixDeath.Name = "FoundationToFixDeath";
        this.FoundationToFixDeath.TabIndex = 9;

        this.tttabpageRreport = new TTVisual.TTTabPage();
        this.tttabpageRreport.DisplayIndex = 1;
        this.tttabpageRreport.BackColor = "#FFFFFF";
        this.tttabpageRreport.TabIndex = 1;
        this.tttabpageRreport.Text = "Rapor";
        this.tttabpageRreport.Name = "tttabpageRreport";

        this.TTRichTextBoxUserControl = new TTVisual.TTRichTextBoxControl();
        this.TTRichTextBoxUserControl.DisplayText = "Rapor";
        this.TTRichTextBoxUserControl.TemplateGroupName = "MORGUEREPORT";
        this.TTRichTextBoxUserControl.BackColor = "#FFFFFF";
        this.TTRichTextBoxUserControl.Name = "TTRichTextBoxUserControl";
        this.TTRichTextBoxUserControl.TabIndex = 41;

        this.tttabcontrolMain.Controls = [this.tttabpageMorgue, this.tttabpageRreport];
        this.tttabpageMorgue.Controls = [this.ObjectsFromPatient, this.cmdAutopsy, this.ttlabel19, this.ttlabel17, this.ExternalDoctorFixed, this.ExternalDoctorFixedUniqueNo, this.ttlabel18, this.ttobjectlistbox1, this.ttlabel16, this.ttlabel15, this.StatisticalDeathReason, this.ttlabel14, this.MernisDeathReason, this.labelReasonForDeath, this.PatientSex, this.ttlabel13, this.ttgroupbox1, this.ttlabel12, this.BirthDate, this.labelProtocolNo, this.BirthPlace, this.ProtocolNo, this.ttlabel9, this.labelDoctorFixed, this.ttlabel8, this.ttlabel10, this.labelDateTimeOfDeath, this.ttlabel11, this.DateTimeOfDeath, this.PatientName, this.labelSenderDoctor, this.ttlabel3, this.DeathReportNo, this.SenderDoctor, this.DateOfDeathReport, this.ttlabel2, this.ttlabel1, this.FoundationToFixDeath];
        this.ttgroupbox1.Controls = [this.ttlabel4, this.CitizenshipNoOfAdmittedFrom, this.ttlabel5, this.ttlabel6, this.DeathBodyAdmittedFrom, this.AddressOfAdmittedFrom, this.ttlabel7, this.PhoneNumberOfAdmittedFrom];
        this.tttabpageRreport.Controls = [this.TTRichTextBoxUserControl];
        this.Controls = [this.SKRSDeathPlace, this.tttabcontrolMain, this.tttabpageMorgue, this.ObjectsFromPatient, this.cmdAutopsy, this.ttlabel19, this.ttlabel17, this.ExternalDoctorFixed, this.ExternalDoctorFixedUniqueNo, this.ttlabel18, this.ttobjectlistbox1, this.ttlabel16, this.ttlabel15, this.StatisticalDeathReason, this.ttlabel14, this.MernisDeathReason, this.labelReasonForDeath, this.PatientSex, this.ttlabel13, this.ttgroupbox1, this.ttlabel4, this.CitizenshipNoOfAdmittedFrom, this.ttlabel5, this.ttlabel6, this.DeathBodyAdmittedFrom, this.AddressOfAdmittedFrom, this.ttlabel7, this.PhoneNumberOfAdmittedFrom, this.ttlabel12, this.BirthDate, this.labelProtocolNo, this.BirthPlace, this.ProtocolNo, this.ttlabel9, this.labelDoctorFixed, this.ttlabel8, this.ttlabel10, this.labelDateTimeOfDeath, this.ttlabel11, this.DateTimeOfDeath, this.PatientName, this.labelSenderDoctor, this.ttlabel3, this.DeathReportNo, this.SenderDoctor, this.DateOfDeathReport, this.ttlabel2, this.ttlabel1, this.FoundationToFixDeath, this.tttabpageRreport, this.TTRichTextBoxUserControl];

    }


}
