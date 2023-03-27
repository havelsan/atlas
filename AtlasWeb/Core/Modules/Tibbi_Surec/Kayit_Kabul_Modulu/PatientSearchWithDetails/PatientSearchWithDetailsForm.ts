//$175663FD

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Component, OnInit, EventEmitter } from '@angular/core';
import { PatientSearchWithDetailsFormViewModel } from "./PatientSearchWithDetailsFormViewModel";

import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

@Component({
    selector: 'PatientSearchWithDetailsForm',
    templateUrl: './PatientSearchWithDetailsForm.html',
    outputs: ['SelectedPatientChanged']
})
export class PatientSearchWithDetailsForm extends TTVisual.TTForm implements OnInit {

    public patientSearchWithDetailsFormViewModel: PatientSearchWithDetailsFormViewModel;
    PayerList: TTVisual.ITTObjectListBox;
    Policlinic: TTVisual.ITTObjectListBox;
    AdmissionType: TTVisual.ITTListDefComboBox;
    Building: TTVisual.ITTObjectListBox;
    DispatchHospitalResources: TTVisual.ITTObjectListBox;
    DispatchHospitalDoctors: TTVisual.ITTObjectListBox;
    SelectedPatientChanged: EventEmitter<any> = new EventEmitter<any>();
    PatientlistView: TTVisual.ITTListView;
    CityOfBirth: TTVisual.ITTObjectListBox;
    BirthDate: TTVisual.ITTDateTimePicker;
    FatherName: TTVisual.ITTTextBox;
    MotherName: TTVisual.ITTTextBox;
    Surname: TTVisual.ITTTextBox;
    Name: TTVisual.ITTTextBox;

    public SelectedPatient: Patient = null;

    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("CONVTEST", "ConvTestForm");
        this.patientSearchWithDetailsFormViewModel = new PatientSearchWithDetailsFormViewModel();
        this.loadAll();


    }
    private ValidateViewModelLoadedParameterCount(): number {
        let Counter: number = 0;
        if (this.patientSearchWithDetailsFormViewModel != null) {
            if (this.patientSearchWithDetailsFormViewModel.PasaportNo != null && this.patientSearchWithDetailsFormViewModel.PasaportNo != "")
                Counter = 2;     //pasaprt tek başına yeterli
            if (this.patientSearchWithDetailsFormViewModel.Name != null && this.patientSearchWithDetailsFormViewModel.Name != "")
                Counter++;
            if (this.patientSearchWithDetailsFormViewModel.Surname != null && this.patientSearchWithDetailsFormViewModel.Surname != "")
                Counter++;
            if (this.patientSearchWithDetailsFormViewModel.MotherName != null && this.patientSearchWithDetailsFormViewModel.MotherName != "")
                Counter++;
            if (this.patientSearchWithDetailsFormViewModel.FatherName != null && this.patientSearchWithDetailsFormViewModel.FatherName != "")
                Counter++;
            if (this.patientSearchWithDetailsFormViewModel.BirthDate != null )
                Counter++;
            if (this.patientSearchWithDetailsFormViewModel.BirthPlace != null && this.patientSearchWithDetailsFormViewModel.BirthPlace != "")
                Counter++;
        }
        return Counter;
    }

    async SearchPatientWithDetails() {

        let that = this;
        if (that.patientSearchWithDetailsFormViewModel != null) {

            let EntryCount: number = this.ValidateViewModelLoadedParameterCount();
            if (EntryCount < 2)
                ServiceLocator.MessageService.showInfo(i18n("M15148", "Hasta arama kriterlerinden en az 2 adet giriş yapmalısınız!"));
            else {
                try {

                    let that = this;
                    let body = JSON.stringify(that.patientSearchWithDetailsFormViewModel);
                    let apiUrlForPASearchUrl: string = '/api/PatientSearchWithDetailsService/PatientSearchWithDetailsForm?model=';
                    let result = await this.httpService.post(apiUrlForPASearchUrl, that.patientSearchWithDetailsFormViewModel);

                    if (result != null) {
                        that.SelectedPatient = null;
                        if (result != null) {
                            if (result["length"] == 1) {
                                that.SelectedPatient = result[0];
                                that.SelectedPatientChanged.emit(that.SelectedPatient);
                                that.LoadSearchingPatientList(result);
                            } else {
                                that.LoadSearchingPatientList(result);
                            }
                        } else {
                            ServiceLocator.MessageService.showInfo(i18n("M11087", "Aranılan kıriterler ile eşleşen bir hasta bulunamadı.Hasta arama alanından TC Kimlik numarası ile denemeniz önerilir."));
                        }
                    }
                }
                catch (ex) {
                    TTVisual.InfoBox.Show(ex);
                }
            }
        }
    }

    LoadSearchingPatientList(result: any): void {
        let PatientAdmissionNumber = 1;
        try {
            let itemList = new Array<any>();
            for (let patientObj of result) {

                let p = {
                    Object: patientObj,
                    SubItems:
                    [
                        { Text: patientObj.Name + " " + patientObj.Surname },
                        { Text: patientObj.MotherName },
                        { Text: patientObj.FatherName },
                        { Text: patientObj.BirthPlace },
                        { Text: patientObj.BirthDate },
                        { Text: "..." }
                    ]
                };

                itemList.push(p);
                ++PatientAdmissionNumber;
            }
            this.PatientlistView.Items = itemList;
        } catch (e) {
            alert((<Error>e).message);
        }
    }

    public async PatientlistView_Click(val: any): Promise<void> {

        this.SelectedPatientChanged.emit(val.Object);
    }

    ngOnInit() {

    }

    public onPayerListChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.Payer != event) {
                this.patientSearchWithDetailsFormViewModel.Payer = event;
            }
        }
    }

    public onPoliclinicChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.AdmissionPoliclinic != event) {
                this.patientSearchWithDetailsFormViewModel.AdmissionPoliclinic = event;
            }
        }
    }

    public onAdmissionTypeChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.AdmissionType != event) {
                this.patientSearchWithDetailsFormViewModel.AdmissionType = event;
            }
        }
    }

    public onBuildingChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.DistrictPoliclinicName != event) {
                this.patientSearchWithDetailsFormViewModel.DistrictPoliclinicName = event;
            }
        }
    }

    public onDispatchHospitalResourcesChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.PatientInServiceName != event) {
                this.patientSearchWithDetailsFormViewModel.PatientInServiceName = event;
            }
        }
    }

    public onDispatchHospitalDoctorsChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.DoctorName != event) {
                this.patientSearchWithDetailsFormViewModel.DoctorName = event;
            }
        }
    }


    public onBirthDateChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.BirthDate != event) {
                this.patientSearchWithDetailsFormViewModel.BirthDate = event;
            }
        }
    }

    public onPasaportNoChanged(event): void {
        if (event != null && event.value != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.PasaportNo != event.value) {
                this.patientSearchWithDetailsFormViewModel.PasaportNo = event.value;
            }
        }
    }


    public onAdmissionDateFirstChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.AdmissionDateFirst != event) {
                this.patientSearchWithDetailsFormViewModel.AdmissionDateFirst = event;
            }
        }
    }
    public onAdmissionDateSecondChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.AdmissionDateSecond != event) {
                this.patientSearchWithDetailsFormViewModel.AdmissionDateSecond = event;
            }
        }
    }
    public onNameChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.Name != event) {
                this.patientSearchWithDetailsFormViewModel.Name = event;
            }
        }
    }
    public onSurnameChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.Surname != event) {
                this.patientSearchWithDetailsFormViewModel.Surname = event;
            }
        }
    }
    public onAgeChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.Age != event) {
                this.patientSearchWithDetailsFormViewModel.Age = event;
            }
        }
    }
    public onMotherNameChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.MotherName != event) {
                this.patientSearchWithDetailsFormViewModel.MotherName = event;
            }
        }
    }
    public onFatherNameChanged(event): void {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.FatherName != event) {
                this.patientSearchWithDetailsFormViewModel.FatherName = event;
            }
        }
    }

    public onCityOfBirthChanged(event) {
        if (event != null) {
            if (this.patientSearchWithDetailsFormViewModel != null && this.patientSearchWithDetailsFormViewModel.BirthPlace != event) {
                this.patientSearchWithDetailsFormViewModel.BirthPlace = event;
            }
        }
    }

    loadAll(): void {
        this.PayerList = new TTVisual.TTObjectListBox();
        this.PayerList.ListDefName = "PayerListDefinition";
        this.PayerList.Name = "PayerList";
        this.PayerList.TabIndex = 4;

        this.DispatchHospitalResources = new TTVisual.TTObjectListBox();
        this.DispatchHospitalResources.ListDefName = "PoliclinicAndEmergencyListDefinition";
        this.DispatchHospitalResources.Name = "DispatchHospitalResources";
        this.DispatchHospitalResources.TabIndex = 5;



        this.AdmissionType = new TTVisual.TTListDefComboBox();
        this.AdmissionType.ListDefName = "ProvizyonTipiListDefinition";
        this.AdmissionType.Required = false;
        this.AdmissionType.BackColor = "#fff";
        this.AdmissionType.Name = "AdmissionType";
        this.AdmissionType.TabIndex = 167;

        this.Policlinic = new TTVisual.TTObjectListBox();
        this.Policlinic.LinkedControlName = "Branch";
        this.Policlinic.LinkedRelationPath = "RESOURCESPECIALITIES.SPECIALITY";
        this.Policlinic.ListDefName = "PoliclinicAndEmergencyListDefinition";
        this.Policlinic.Name = "Policlinic";
        this.Policlinic.TabIndex = 161;

        this.Building = new TTVisual.TTObjectListBox();
        this.Building.ListDefName = "BuildinglistDefinition";
        this.Building.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Building.Name = "Building";
        this.Building.TabIndex = 152;

        this.DispatchHospitalDoctors = new TTVisual.TTObjectListBox();
        this.DispatchHospitalDoctors.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.DispatchHospitalDoctors.ListDefName = "SpecialistDoctorListDefinition";
        this.DispatchHospitalDoctors.Name = "DispatchHospitalDoctors";
        this.DispatchHospitalDoctors.TabIndex = 6;

        this.CityOfBirth = new TTVisual.TTObjectListBox();
        this.CityOfBirth.ListDefName = "SKRSILKodlariList";
        this.CityOfBirth.Name = "CityOfBirth";
        this.CityOfBirth.TabIndex = 49;

        this.PatientlistView = <TTVisual.TTListView>{
            Visible: true,
            ReadOnly: false,
            BackColor: "black",
            ForeColor: "yellow",
            Font: {
                Bold: false,
                Italic: false,
                Name: "Impact",
                Size: 11,
                Strikeout: false,
                Underline: false
            },
            Columns: [
                { Text: i18n("M10498", "Ad Soyad") },
                { Text: i18n("M11037", "Anne Adı") },
                { Text: i18n("M11390", "Baba Adı") },
                { Text: i18n("M13139", "Doğum Yeri") },
                { Text: i18n("M13132", "Doğum Tarihi") },
                { Text: i18n("M14664", "Geliş Sebebi") }
            ]
        };
        this.PatientlistView.Name = "PatientlistView";
        this.PatientlistView.TabIndex = 0;
        this.PatientlistView.MultiSelect = false;

    }
}