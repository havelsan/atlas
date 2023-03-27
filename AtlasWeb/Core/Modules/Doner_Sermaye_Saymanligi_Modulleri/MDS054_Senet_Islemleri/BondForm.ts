//$A0795667
import { Component, OnInit, NgZone } from '@angular/core';
import { BondFormViewModel } from './BondFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Bond } from 'NebulaClient/Model/AtlasClientModel';
import { BondDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BondDocument } from 'NebulaClient/Model/AtlasClientModel';
import { BondPerson } from 'NebulaClient/Model/AtlasClientModel';
import { BondProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIlceKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { PatientStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";

import { Convert } from 'app/NebulaClient/Mscorlib/Convert';

@Component({
    selector: 'BondForm',
    templateUrl: './BondForm.html',
    providers: [MessageService]
})
export class BondForm extends TTVisual.TTForm implements OnInit {
    BDSTATUS: TTVisual.TTTextBoxColumn;
    BDDATE: TTVisual.ITTDateTimePickerColumn;
    BDDESCRIPTION: TTVisual.ITTTextBoxColumn;
    BDPAYMENTDATE: TTVisual.ITTDateTimePickerColumn;
    BDPRICE: TTVisual.ITTTextBoxColumn;
    BondDetail: TTVisual.ITTTabPage;
    BondPayerTab: TTVisual.ITTTabPage;
    BondProceduresTab: TTVisual.ITTTabPage;
    BondTabs: TTVisual.ITTTabControl;
    BPACTIONDATE: TTVisual.TTDateTimePickerColumn;
    BPAMOUNT: TTVisual.ITTTextBoxColumn;
    BPDESCRIPTION: TTVisual.ITTTextBoxColumn;
    BPEXTERNALCODE: TTVisual.ITTTextBoxColumn;
    BPREMAININGPRICE: TTVisual.ITTTextBoxColumn;
    BPTOTALPRICE: TTVisual.ITTTextBoxColumn;
    BPUNITPRICE: TTVisual.ITTTextBoxColumn;
    btnCalcBondDetail: TTVisual.ITTButton;
    dtPickerBondDate: TTVisual.ITTDateTimePicker;
    dtPickerFirstNoficationDate: TTVisual.ITTDateTimePicker;
    dtPickerPayerBirthDate: TTVisual.ITTDateTimePicker;
    dtPickerSecondNotificationDate: TTVisual.ITTDateTimePicker;
    GrdBondDetails: TTVisual.ITTGrid;
    GrdBondProcedure: TTVisual.ITTGrid;
    grpBoxBondInfo: TTVisual.ITTGroupBox;
    lblAdavnceTaken: TTVisual.ITTLabel;
    lblBondDate: TTVisual.ITTLabel;
    lblBondDescription: TTVisual.ITTLabel;
    lblBondNo: TTVisual.ITTLabel;
    lblBondPrice: TTVisual.ITTLabel;
    lblFirstGuarantorAddress: TTVisual.ITTLabel;
    lblFirstGuarantorBirthDate: TTVisual.ITTLabel;
    lblFirstGuarantorCityOfBirth: TTVisual.ITTLabel;
    lblFirstGuarantorDescription: TTVisual.ITTLabel;
    lblFirstGuarantorFatherName: TTVisual.ITTLabel;
    lblFirstGuarantorHomeCity: TTVisual.ITTLabel;
    lblFirstGuarantorHomeTown: TTVisual.ITTLabel;
    lblFirstGuarantorIdentificationCardNo: TTVisual.ITTLabel;
    lblFirstGuarantorMotherName: TTVisual.ITTLabel;
    lblFirstGuarantorName: TTVisual.ITTLabel;
    lblFirstGuarantorPhone: TTVisual.ITTLabel;
    lblFirstGuarantorSurname: TTVisual.ITTLabel;
    lblFirstGuarantorUniqueRefNo: TTVisual.ITTLabel;
    lblFirstNotificationDate: TTVisual.ITTLabel;
    lblPayerAddress: TTVisual.ITTLabel;
    lblPayerBirthDate: TTVisual.ITTLabel;
    lblPayerCityOfBirth: TTVisual.ITTLabel;
    lblPayerCityOfResgistry: TTVisual.ITTLabel;
    lblPayerDescription: TTVisual.ITTLabel;
    lblPayerFatherName: TTVisual.ITTLabel;
    lblPayerHomeCity: TTVisual.ITTLabel;
    lblPayerHomeTown: TTVisual.ITTLabel;
    lblPayerIdentificationCardNo: TTVisual.ITTLabel;
    lblPayerMotherName: TTVisual.ITTLabel;
    lblPayerName: TTVisual.ITTLabel;
    lblPayerPhone: TTVisual.ITTLabel;
    lblPayerSurname: TTVisual.ITTLabel;
    lblPayerTownOfRegistry: TTVisual.ITTLabel;
    lblPayerUniqueRefNo: TTVisual.ITTLabel;
    lblRestructuredBond: TTVisual.ITTLabel;
    lblSecondNotificationDate: TTVisual.ITTLabel;
    TTListBox: TTVisual.ITTTabPage;
    //TTListBoxCityOfBirth: TTVisual.ITTObjectListBox;
    TTListBoxFirstGuarantorBirthDate: TTVisual.ITTDateTimePicker;
    //TTListBoxFirstGuarantorCityOfBirth: TTVisual.ITTObjectListBox;
    TTListBoxFirstGuarantorHomeCity: TTVisual.ITTObjectListBox;
    TTListBoxPayerCityOfRegistry: TTVisual.ITTObjectListBox;
    TTListBoxPayerHomeCity: TTVisual.ITTObjectListBox;
    TTListBoxPayerHomeTown: TTVisual.ITTObjectListBox;
    TTListBoxPayerTownOfRegistry: TTVisual.ITTObjectListBox;
    tttextbox11: TTVisual.ITTTextBox;
    txtBondPayerDescription: TTVisual.ITTTextBox;
    txtAdvanceTaken: TTVisual.ITTTextBox;
    txtBondDescription: TTVisual.ITTTextBox;
    txtBondNo: TTVisual.ITTTextBox;
    txtBondPayerName: TTVisual.ITTTextBox;
    txtBondPrice: TTVisual.ITTTextBox;
    txtFirstGuarantorAddress: TTVisual.ITTTextBox;
    txtFirstGuarantorDescription: TTVisual.ITTTextBox;
    txtFirstGuarantorFatherName: TTVisual.ITTTextBox;
    TTListBoxFirstGuarantorHomeTown: TTVisual.ITTObjectListBox;
    txtFirstGuarantorIdentificationCardNo: TTVisual.ITTTextBox;
    txtFirstGuarantorMotherName: TTVisual.ITTTextBox;
    txtFirstGuarantorName: TTVisual.ITTTextBox;
    //txtFirstGuarantorPhone: TTVisual.ITTTextBox;
    txtFirstGuarantorSurname: TTVisual.ITTTextBox;
    txtFirstGuarantorUniqueRefNo: TTVisual.ITTTextBox;
    txtPayerAddress: TTVisual.ITTTextBox;
    txtPayerFatherName: TTVisual.ITTTextBox;
    txtPayerIdentificationCardNo: TTVisual.ITTTextBox;
    txtPayerMotherName: TTVisual.ITTTextBox;
    txtPayerSurname: TTVisual.ITTTextBox;
    txtPayerUniqueRefNo: TTVisual.ITTTextBox;
    txtRestructuredBond: TTVisual.ITTTextBox;
    FIRSTGUARANTORPHONE: TTVisual.ITTMaskedTextBox;
    BONDPAYERPHONE: TTVisual.ITTMaskedTextBox;
    public GrdBondDetailsColumns = [];
    public GrdBondProcedureColumns = [];

    SaveButtonVisibility: boolean = true;
    StateCommandsVisible: boolean = true;
    txtUniqueRefNoReadOnly: boolean = false;
    NumberOfTerms: number;
    txtNumberOfTermsReadOnly: boolean = true;
    //phoneReadOnly: boolean = false;
    termsClass: any = 'col-sm-2 col-sm-offset-9';
    txtBirthPlaceReadOnly: boolean = false;

    public bondFormViewModel: BondFormViewModel = new BondFormViewModel();
    public get _Bond(): Bond {
        return this._TTObject as Bond;
    }
    private BondForm_DocumentUrl: string = '/api/BondService/BondForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super('BOND', 'BondForm');
        this._DocumentServiceUrl = this.BondForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****
    protected async ClientSidePreScript(): Promise<void> {
        this.BDDATE.ReadOnly = true;

        this.DropStateButton(Bond.BondStates.PartialPaid);
        this.DropStateButton(Bond.BondStates.Paid);

        switch (this.bondFormViewModel._Bond.CurrentStateDefID.valueOf()) {
            case Bond.BondStates.New.valueOf():
                this.BDPAYMENTDATE.ReadOnly = true;
                this.SaveButtonVisibility = false;
                this.dtPickerFirstNoficationDate.ReadOnly = true;
                this.dtPickerSecondNotificationDate.ReadOnly = true;
                this.btnCalcBondDetail.Visible = true;
                this.txtNumberOfTermsReadOnly = false;
                this.termsClass = 'col-sm-2 col-sm-offset-8';
                this.BDDATE.ReadOnly = false;
                this.BDPRICE.ReadOnly = false;
                break;
            case Bond.BondStates.UnPaid.valueOf():

                break;
            case Bond.BondStates.PartialPaid.valueOf():
                this.DropStateButton(Bond.BondStates.UnPaid);
                break;
            case Bond.BondStates.LegalProcess.valueOf():
                this.dtPickerFirstNoficationDate.ReadOnly = true;
                this.dtPickerSecondNotificationDate.ReadOnly = true;
                break;
            case Bond.BondStates.Cancelled.valueOf():
            case Bond.BondStates.Restructured.valueOf():
            case Bond.BondStates.Paid.valueOf():
                this.StateCommandsVisible = false;
                this.SaveButtonVisibility = false;
                break;
            default:
                break;
        }
        if (this.bondFormViewModel._Bond.CurrentStateDefID.valueOf() != "9fa90413-e8c9-4f04-8f8a-3462b7ee02a5") {
            for (let index = 0; index < this.Controls.length; index++) {
                let element = this.Controls[index];
                if (element.Name != undefined && !(element instanceof TTVisual.TTLabel))
                    element.ReadOnly = true;
                if (element instanceof TTVisual.TTObjectListBox)
                    element.Enabled = false;
            }
            this.txtBirthPlaceReadOnly = true;
            this.txtUniqueRefNoReadOnly = true;
            this.FIRSTGUARANTORPHONE.ReadOnly = true;
            this.BONDPAYERPHONE.ReadOnly = true;
            //this.phoneReadOnly= true;
        }
        if (this.bondFormViewModel._Bond.BondDetails != null && this.bondFormViewModel._Bond.BondDetails.length > 0)
            this.NumberOfTerms = this.bondFormViewModel._Bond.BondDetails.length;
        // if (this.bondFormViewModel._Bond.IsNew || this.bondFormViewModel._Bond.CurrentStateDefID.valueOf() === Bond.BondStates.New.id) {
        //     this.BDPAYMENTDATE.ReadOnly = true;
        //     this.SaveButtonVisibility = false;
        //     this.dtPickerFirstNoficationDate.ReadOnly = true;
        //     this.dtPickerSecondNotificationDate.ReadOnly = true;
        //     this.btnCalcBondDetail.Visible = true;
        //     this.txtNumberOfTermsReadOnly = false;
        //     this.termsClass = 'col-sm-2 col-sm-offset-8';
        //     this.BDDATE.ReadOnly = false;
        //     this.BDPRICE.ReadOnly = false;
        // }
        // else
        //     this.NumberOfTerms = this.bondFormViewModel._Bond.BondDetails.length;

        if (this._Bond.FirstNotificationDate != null) {
            this.dtPickerSecondNotificationDate.ReadOnly = false;
            this.dtPickerSecondNotificationDate.ReadOnly = true;
        }
        else
            this.dtPickerSecondNotificationDate.ReadOnly = true;

        if (this._Bond.SecondNotificationDate != null) {
            this.dtPickerSecondNotificationDate.ReadOnly = true;
            this.dtPickerSecondNotificationDate.ReadOnly = true;
        }

        //Senedin geçmiş vadesi var ise ihbar tarihlerini aç
        if (this.bondFormViewModel._Bond.BondDetails.filter(x => x.PaymentDate == null && Convert.ToDateTime(x.Date) < new Date()).length > 0
            && (this.bondFormViewModel._Bond.CurrentStateDefID == Bond.BondStates.PartialPaid || this.bondFormViewModel._Bond.CurrentStateDefID == Bond.BondStates.UnPaid)) {
            this.dtPickerFirstNoficationDate.ReadOnly = false;
            this.dtPickerSecondNotificationDate.ReadOnly = false;
            this.SaveButtonVisibility = true;
        }
        else {
            this.DropStateButton(Bond.BondStates.LegalProcess);
            this.dtPickerFirstNoficationDate.ReadOnly = true;
        }
        this.TTListBoxFirstGuarantorHomeTown.ListFilterExpression = 'ILKODU =' + 0;
        this.TTListBoxPayerTownOfRegistry.ListFilterExpression = 'ILKODU =' + 0;
        this.TTListBoxPayerTownOfRegistry.ListFilterExpression = 'ILKODU =' + 0;
    }
    public initViewModel(): void {
        this._TTObject = new Bond();
        this.bondFormViewModel = new BondFormViewModel();
        this._ViewModel = this.bondFormViewModel;
        this.bondFormViewModel._Bond = this._TTObject as Bond;
        this.bondFormViewModel._Bond.BondPayer = new BondPerson();
        this.bondFormViewModel._Bond.BondPayer.HomeTown = new SKRSIlceKodlari();
        this.bondFormViewModel._Bond.BondPayer.HomeCity = new SKRSILKodlari();
        this.bondFormViewModel._Bond.BondPayer.TownOfRegistrySKRS = new SKRSIlceKodlari();
        this.bondFormViewModel._Bond.BondPayer.CityOfRegistry = new SKRSILKodlari();
        //this.bondFormViewModel._Bond.BondPayer.CityOfBirth = new SKRSILKodlari();
        this.bondFormViewModel._Bond.FirstBondGuarantor = new BondPerson();
        this.bondFormViewModel._Bond.FirstBondGuarantor.HomeTown = new SKRSIlceKodlari();
        this.bondFormViewModel._Bond.FirstBondGuarantor.HomeCity = new SKRSILKodlari();
        // this.bondFormViewModel._Bond.FirstBondGuarantor.CityOfBirth = new SKRSILKodlari();
        this.bondFormViewModel._Bond.BondDetails = new Array<BondDetail>();
        this.bondFormViewModel._Bond.BondProcedures = new Array<BondProcedure>();
        this.bondFormViewModel._Bond.OriginalBond = new Bond();
        this.bondFormViewModel._Bond.OriginalBond.BondDocument = new BondDocument();
        this.bondFormViewModel._Bond.BondDocument = new BondDocument();
    }

    protected loadViewModel() {
        let that = this;

        that.bondFormViewModel = this._ViewModel as BondFormViewModel;
        that._TTObject = this.bondFormViewModel._Bond;
        if (this.bondFormViewModel == null)
            this.bondFormViewModel = new BondFormViewModel();
        if (this.bondFormViewModel._Bond == null)
            this.bondFormViewModel._Bond = new Bond();
        let bondPayerObjectID = that.bondFormViewModel._Bond['BondPayer'];
        if (bondPayerObjectID != null && (typeof bondPayerObjectID === 'string')) {
            let bondPayer = that.bondFormViewModel.BondPersons.find(o => o.ObjectID.toString() === bondPayerObjectID.toString());
            if (bondPayer) {
                that.bondFormViewModel._Bond.BondPayer = bondPayer;
            }
            if (bondPayer != null) {
                let homeTownObjectID = bondPayer['HomeTown'];
                if (homeTownObjectID != null && (typeof homeTownObjectID === 'string')) {
                    let homeTown = that.bondFormViewModel.SKRSIlceKodlaris.find(o => o.ObjectID.toString() === homeTownObjectID.toString());
                    if (homeTown) {
                        bondPayer.HomeTown = homeTown;
                    }
                }
            }
            if (bondPayer != null) {
                let homeCityObjectID = bondPayer['HomeCity'];
                if (homeCityObjectID != null && (typeof homeCityObjectID === 'string')) {
                    let homeCity = that.bondFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === homeCityObjectID.toString());
                    if (homeCity) {
                        bondPayer.HomeCity = homeCity;
                    }
                }
            }
            if (bondPayer != null) {
                let townOfRegistrySKRSObjectID = bondPayer['TownOfRegistrySKRS'];
                if (townOfRegistrySKRSObjectID != null && (typeof townOfRegistrySKRSObjectID === 'string')) {
                    let townOfRegistrySKRS = that.bondFormViewModel.SKRSIlceKodlaris.find(o => o.ObjectID.toString() === townOfRegistrySKRSObjectID.toString());
                    if (townOfRegistrySKRS) {
                        bondPayer.TownOfRegistrySKRS = townOfRegistrySKRS;
                    }
                }
            }
            if (bondPayer != null) {
                let cityOfRegistryObjectID = bondPayer['CityOfRegistry'];
                if (cityOfRegistryObjectID != null && (typeof cityOfRegistryObjectID === 'string')) {
                    let cityOfRegistry = that.bondFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === cityOfRegistryObjectID.toString());
                    if (cityOfRegistry) {
                        bondPayer.CityOfRegistry = cityOfRegistry;
                    }
                }
            }
            /* if (bondPayer != null) {
                 let cityOfBirthObjectID = bondPayer['CityOfBirth'];
                 if (cityOfBirthObjectID != null && (typeof cityOfBirthObjectID === 'string')) {
                     let cityOfBirth = that.bondFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === cityOfBirthObjectID.toString());
                     bondPayer.CityOfBirth = cityOfBirth;
                 }
             }*/
        }
        let firstBondGuarantorObjectID = that.bondFormViewModel._Bond['FirstBondGuarantor'];
        if (firstBondGuarantorObjectID != null && (typeof firstBondGuarantorObjectID === 'string')) {
            let firstBondGuarantor = that.bondFormViewModel.BondPersons.find(o => o.ObjectID.toString() === firstBondGuarantorObjectID.toString());
            if (firstBondGuarantor) {
                that.bondFormViewModel._Bond.FirstBondGuarantor = firstBondGuarantor;
            }
            if (firstBondGuarantor != null) {
                let homeTownObjectID = firstBondGuarantor['HomeTown'];
                if (homeTownObjectID != null && (typeof homeTownObjectID === 'string')) {
                    let homeTown = that.bondFormViewModel.SKRSIlceKodlaris.find(o => o.ObjectID.toString() === homeTownObjectID.toString());
                    if (homeTown) {
                        firstBondGuarantor.HomeTown = homeTown;
                    }
                }
            }
            if (firstBondGuarantor != null) {
                let homeCityObjectID = firstBondGuarantor['HomeCity'];
                if (homeCityObjectID != null && (typeof homeCityObjectID === 'string')) {
                    let homeCity = that.bondFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === homeCityObjectID.toString());
                    if (homeCity) {
                        firstBondGuarantor.HomeCity = homeCity;
                    }
                }
            }
            /* if (firstBondGuarantor != null) {
                 let cityOfBirthObjectID = firstBondGuarantor['CityOfBirth'];
                 if (cityOfBirthObjectID != null && (typeof cityOfBirthObjectID === 'string')) {
                     let cityOfBirth = that.bondFormViewModel.SKRSILKodlaris.find(o => o.ObjectID.toString() === cityOfBirthObjectID.toString());
                     firstBondGuarantor.CityOfBirth = cityOfBirth;
                 }
             }*/
        }
        else
            this.bondFormViewModel._Bond.FirstBondGuarantor = new BondPerson();
        that.bondFormViewModel._Bond.BondDetails = that.bondFormViewModel.GrdBondDetailsGridList;
        for (let detailItem of that.bondFormViewModel.GrdBondDetailsGridList) {
        }
        that.bondFormViewModel._Bond.BondProcedures = that.bondFormViewModel.GrdBondProcedureGridList;
        for (let detailItem of that.bondFormViewModel.GrdBondProcedureGridList) {
        }
        let originalBondObjectID = that.bondFormViewModel._Bond['OriginalBond'];
        if (originalBondObjectID != null && (typeof originalBondObjectID === 'string')) {
            let originalBond = that.bondFormViewModel.Bonds.find(o => o.ObjectID.toString() === originalBondObjectID.toString());
            if (originalBond) {
                that.bondFormViewModel._Bond.OriginalBond = originalBond;
            }
            if (originalBond != null) {
                let bondDocumentObjectID = originalBond['BondDocument'];
                if (bondDocumentObjectID != null && (typeof bondDocumentObjectID === 'string')) {
                    let bondDocument = that.bondFormViewModel.BondDocuments.find(o => o.ObjectID.toString() === bondDocumentObjectID.toString());
                    if (bondDocument) {
                        originalBond.BondDocument = bondDocument;
                    }
                }
            }
        }
        let bondDocumentObjectID = that.bondFormViewModel._Bond['BondDocument'];
        if (bondDocumentObjectID != null && (typeof bondDocumentObjectID === 'string')) {
            let bondDocument = that.bondFormViewModel.BondDocuments.find(o => o.ObjectID.toString() === bondDocumentObjectID.toString());
            if (bondDocument) {
                that.bondFormViewModel._Bond.BondDocument = bondDocument;
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(BondFormViewModel);

    }


    public ondtPickerBondDateChanged(event): void {
        if (event != null) {
            if (this._Bond != null && this._Bond.Date != event) {
                this._Bond.Date = event;
            }
        }
    }

    public ondtPickerFirstNoficationDateChanged(event): void {
        if (event != null) {
            if (this._Bond != null && this._Bond.FirstNotificationDate != event) {
                this._Bond.FirstNotificationDate = event;
            }
        }
    }

    public ondtPickerPayerBirthDateChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.BirthDate != event) {
                this._Bond.BondPayer.BirthDate = event;
            }
        }
    }

    public ondtPickerSecondNotificationDateChanged(event): void {
        if (event != null) {
            if (this._Bond != null && this._Bond.SecondNotificationDate != event) {
                this._Bond.SecondNotificationDate = event;
            }
        }
    }

    // public onTTListBoxCityOfBirthChanged(event): void {
    //     if (event != null) {
    //         if (this._Bond != null &&
    //             this._Bond.BondPayer != null && this._Bond.BondPayer.BirthPlace != event) {
    //             this._Bond.BondPayer.BirthPlace = event;
    //         }
    //     }
    // }

    public onTTListBoxFirstGuarantorBirthDateChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.BirthDate != event) {
                this._Bond.FirstBondGuarantor.BirthDate = event;
            }
        }
    }

    // public onTTListBoxFirstGuarantorCityOfBirthChanged(event): void {
    //     if (event != null) {
    //         if (this._Bond != null &&
    //             this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.BirthPlace != event) {
    //             this._Bond.FirstBondGuarantor.BirthPlace = event;
    //         }
    //     }
    // }

    public onTTListBoxFirstGuarantorHomeCityChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.HomeCity != event) {
                this._Bond.FirstBondGuarantor.HomeCity = event;
                this._Bond.FirstBondGuarantor.HomeTown = null;
                this.TTListBoxFirstGuarantorHomeTown.ListFilterExpression = 'ILKODU = ' + this._Bond.FirstBondGuarantor.HomeCity.KODU;
            }
        }
        else {
            this._Bond.FirstBondGuarantor.HomeTown = null;
            this.TTListBoxFirstGuarantorHomeTown.ListFilterExpression = 'ILKODU = ' + 0;
        }
    }

    public onTTListBoxPayerCityOfRegistryChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.CityOfRegistry != event) {
                this._Bond.BondPayer.CityOfRegistry = event;
                this._Bond.BondPayer.TownOfRegistry = null;
                this.TTListBoxPayerTownOfRegistry.ListFilterExpression = 'ILKODU = ' + this._Bond.BondPayer.CityOfRegistry.KODU;
            }
        }
        else {
            this._Bond.BondPayer.TownOfRegistrySKRS = null;
            this.TTListBoxPayerTownOfRegistry.ListFilterExpression = 'ILKODU = ' + 0;
        }
    }

    public onTTListBoxPayerHomeCityChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.HomeCity != event) {
                this._Bond.BondPayer.HomeCity = event;
                this._Bond.BondPayer.HomeTown = null;
                this.TTListBoxPayerHomeTown.ListFilterExpression = 'ILKODU = ' + this._Bond.BondPayer.HomeCity.KODU;
            }
        }
        else {
            this._Bond.BondPayer.HomeTown = null;
            this.TTListBoxPayerHomeTown.ListFilterExpression = 'ILKODU = ' + 0;
        }
    }

    public onTTListBoxPayerHomeTownChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.HomeTown != event) {
                this._Bond.BondPayer.HomeTown = event;
            }
        }
    }

    public onTTListBoxPayerTownOfRegistryChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.TownOfRegistrySKRS != event) {
                this._Bond.BondPayer.TownOfRegistrySKRS = event;
            }
        }
    }

    // public ontttextbox11Changed(event): void {
    //     if (event != null) {
    //         if (this._Bond != null &&
    //             this._Bond.BondPayer != null && this._Bond.BondPayer.Phone != event) {
    //             this._Bond.BondPayer.Phone = event;
    //         }
    //     }
    // }

    txtPhoneKeyPress(event: KeyboardEvent, payerType: number) {
        if (event.charCode === 44)
            event.preventDefault();
        if (isNaN(parseInt(event.key)) && event.charCode !== 46)
            event.preventDefault();
    }

    public ontxtBondPayerDescriptionChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.Description != event) {
                this._Bond.BondPayer.Description = event;
            }
        }
    }

    public ontxtAdvanceTakenChanged(event): void {
        if (event != null) {
            if (this._Bond != null && this._Bond.AdvanceTaken != event) {
                this._Bond.AdvanceTaken = event;
            }
        }
    }

    public ontxtBondDescriptionChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondDocument != null && this._Bond.BondDocument.Description != event) {
                this._Bond.BondDocument.Description = event;
            }
        }
    }

    public ontxtBondNoChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondDocument != null && this._Bond.BondDocument.DocumentNo != event) {
                this._Bond.BondDocument.DocumentNo = event;
            }
        }
    }

    public ontxtBondPayerNameChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.Name != event) {
                this._Bond.BondPayer.Name = event;
            }
        }
    }

    public ontxtBondPriceChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondDocument != null && this._Bond.BondDocument.TotalPrice != event) {
                this._Bond.BondDocument.TotalPrice = event;
            }
        }
    }

    public ontxtFirstGuarantorAddressChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.Address != event) {
                this._Bond.FirstBondGuarantor.Address = event;
            }
        }
    }

    public ontxtFirstGuarantorDescriptionChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.Description != event) {
                this._Bond.FirstBondGuarantor.Description = event;
            }
        }
    }

    public ontxtFirstGuarantorFatherNameChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.FatherName != event) {
                this._Bond.FirstBondGuarantor.FatherName = event;
            }
        }
    }

    public onTTListBoxFirstGuarantorHomeTownChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.HomeTown != event) {
                this._Bond.FirstBondGuarantor.HomeTown = event;
            }
        }
    }

    public ontxtFirstGuarantorIdentificationCardNoChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.IdentificationCardNo != event) {
                this._Bond.FirstBondGuarantor.IdentificationCardNo = event;
            }
        }
    }

    public ontxtFirstGuarantorMotherNameChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.MotherName != event) {
                this._Bond.FirstBondGuarantor.MotherName = event;
            }
        }
    }

    public ontxtFirstGuarantorNameChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.Name != event) {
                this._Bond.FirstBondGuarantor.Name = event;
            }
        }
    }

    // public ontxtFirstGuarantorPhoneChanged(event): void {
    //     if (event != null) {
    //         if (this._Bond != null &&
    //             this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.Phone != event) {
    //             this._Bond.FirstBondGuarantor.Phone = event;
    //         }
    //     }
    // }

    public ontxtFirstGuarantorSurnameChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.Surname != event) {
                this._Bond.FirstBondGuarantor.Surname = event;
            }
        }
    }

    public ontxtFirstGuarantorUniqueRefNoChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.FirstBondGuarantor != null && this._Bond.FirstBondGuarantor.UniqueRefNo != event) {
                this._Bond.FirstBondGuarantor.UniqueRefNo = event.value;
            }
        }
    }

    public ontxtPayerAddressChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.Address != event) {
                this._Bond.BondPayer.Address = event;
            }
        }
    }

    public ontxtPayerFatherNameChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.FatherName != event) {
                this._Bond.BondPayer.FatherName = event;
            }
        }
    }

    public ontxtPayerIdentificationCardNoChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.IdentificationCardNo != event) {
                this._Bond.BondPayer.IdentificationCardNo = event;
            }
        }
    }

    public ontxtPayerMotherNameChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.MotherName != event) {
                this._Bond.BondPayer.MotherName = event;
            }
        }
    }

    public ontxtPayerSurnameChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.BondPayer != null && this._Bond.BondPayer.Surname != event) {
                this._Bond.BondPayer.Surname = event;
            }
        }
    }

    public onFirstGuarantorPhoneChanged(event): void {

        if (this.bondFormViewModel._Bond.FirstBondGuarantor.Phone != event) {
            this.bondFormViewModel._Bond.FirstBondGuarantor.Phone = event;
        }
    }
    public onBondPayerPhoneChanged(event): void {

        if (this.bondFormViewModel._Bond.BondPayer.Phone != event) {
            this.bondFormViewModel._Bond.BondPayer.Phone = event;
        }
    }
    // public ontxtPayerUniqueRefNoChanged(event): void {
    //     if (event != null) {
    //         if (this._Bond != null &&
    //             this._Bond.BondPayer != null && this._Bond.BondPayer.UniqueRefNo != event) {
    //             this._Bond.BondPayer.UniqueRefNo = event;
    //         }
    //     }
    // }

    // txtUniqueRefNo_ValueChanged(event: any) {
    //     debugger;
    // }

    public txtUniqueRefNoPaymentKeyPress(event: KeyboardEvent, payerType: number) {
        if (event.charCode === 44)
            event.preventDefault();
        if (isNaN(parseInt(event.key)))
            event.preventDefault();
    }

    ontxtRestructuredBondChanged(event): void {
        if (event != null) {
            if (this._Bond != null &&
                this._Bond.OriginalBond != null &&
                this._Bond.OriginalBond.BondDocument != null && this._Bond.OriginalBond.BondDocument.DocumentNo != event) {
                this._Bond.OriginalBond.BondDocument.DocumentNo = event;
            }
        }
    }

    public onCellValueChanged(event: any) {
        if (this.NumberOfTerms != null && this.bondFormViewModel.GrdBondDetailsGridList.length == parseInt(this.NumberOfTerms.toString(), 0) && this.bondFormViewModel._Bond.CurrentStateDefID == Bond.BondStates.New) {
            if (event.RowIndex === 0 && event.ColIndex === 1 && event.Column instanceof TTVisual.TTTextBoxColumn) {
                let firstBondDetail: BondDetail = this._Bond.BondDetails.reduce((a, b) => { return a.Date < b.Date ? a : b; });
                if (Math.Round(firstBondDetail.Price, 2) > this._Bond.TotalPrice) {
                    this.btnCalcOnLick(true);
                    return false;
                }
                firstBondDetail.Price = Math.Round(firstBondDetail.Price, 2);
                let remainingBondDetailsPrice: number = Math.Round((Math.Round(this._Bond.BondDocument.TotalPrice - Math.Round(firstBondDetail.Price, 2), 2)) / (this.NumberOfTerms - 1), 2);

                let editedbondDetailTotals: number = firstBondDetail.Price;
                for (let index = 0; index < this._Bond.BondDetails.length; index++) {
                    let element = this._Bond.BondDetails[index];
                    if (element.Date != firstBondDetail.Date && index != this._Bond.BondDetails.length - 1) {
                        element.Price = Math.Round(remainingBondDetailsPrice, 2);
                        editedbondDetailTotals += element.Price;
                    }
                    else if (index == this._Bond.BondDetails.length - 1)
                        element.Price = Math.Round(this._Bond.TotalPrice - editedbondDetailTotals, 2);
                }
            }
            else {
                if (this._Bond.BondDocument.TotalPrice !== Math.Round(this.bondFormViewModel.GrdBondDetailsGridList.reduce((a, b) => a + b.Price, 0), 2))
                    this.btnCalcOnLick(true);
            }
        }
    }

    onRowPrepared(event: any) {

    }

    protected redirectProperties(): void {
        redirectProperty(this.txtBondNo, 'Text', this.__ttObject, 'BondDocument.DocumentNo');
        redirectProperty(this.dtPickerBondDate, 'Value', this.__ttObject, 'Date');
        redirectProperty(this.txtBondPrice, 'Text', this.__ttObject, 'BondDocument.TotalPrice');
        redirectProperty(this.txtAdvanceTaken, 'Text', this.__ttObject, 'AdvanceTaken');
        redirectProperty(this.txtRestructuredBond, 'Text', this.__ttObject, 'OriginalBond.BondDocument.DocumentNo');
        redirectProperty(this.dtPickerFirstNoficationDate, 'Value', this.__ttObject, 'FirstNotificationDate');
        redirectProperty(this.dtPickerSecondNotificationDate, 'Value', this.__ttObject, 'SecondNotificationDate');
        redirectProperty(this.txtBondDescription, 'Text', this.__ttObject, 'BondDocument.Description');
        redirectProperty(this.txtPayerUniqueRefNo, 'Text', this.__ttObject, 'BondPayer.UniqueRefNo');
        redirectProperty(this.txtPayerIdentificationCardNo, 'Text', this.__ttObject, 'BondPayer.IdentificationCardNo');
        redirectProperty(this.txtBondPayerName, 'Text', this.__ttObject, 'BondPayer.Name');
        redirectProperty(this.txtPayerSurname, 'Text', this.__ttObject, 'BondPayer.Surname');
        redirectProperty(this.txtPayerFatherName, 'Text', this.__ttObject, 'BondPayer.FatherName');
        redirectProperty(this.txtPayerMotherName, 'Text', this.__ttObject, 'BondPayer.MotherName');
        redirectProperty(this.dtPickerPayerBirthDate, 'Value', this.__ttObject, 'BondPayer.BirthDate');
        redirectProperty(this.txtPayerAddress, 'Text', this.__ttObject, 'BondPayer.Address');
        //redirectProperty(this.tttextbox11, 'Text', this.__ttObject, 'BondPayer.Phone');
        redirectProperty(this.txtBondPayerDescription, 'Text', this.__ttObject, 'BondPayer.Description');
        //redirectProperty(this.txtFirstGuarantorUniqueRefNo, 'Text', this.__ttObject, 'FirstBondGuarantor.UniqueRefNo');
        redirectProperty(this.txtFirstGuarantorIdentificationCardNo, 'Text', this.__ttObject, 'FirstBondGuarantor.IdentificationCardNo');
        redirectProperty(this.txtFirstGuarantorName, 'Text', this.__ttObject, 'FirstBondGuarantor.Name');
        redirectProperty(this.txtFirstGuarantorSurname, 'Text', this.__ttObject, 'FirstBondGuarantor.Surname');
        redirectProperty(this.txtFirstGuarantorFatherName, 'Text', this.__ttObject, 'FirstBondGuarantor.FatherName');
        redirectProperty(this.txtFirstGuarantorMotherName, 'Text', this.__ttObject, 'FirstBondGuarantor.MotherName');
        redirectProperty(this.TTListBoxFirstGuarantorBirthDate, 'Value', this.__ttObject, 'FirstBondGuarantor.BirthDate');
        redirectProperty(this.txtFirstGuarantorAddress, 'Text', this.__ttObject, 'FirstBondGuarantor.Address');
        //redirectProperty(this.txtFirstGuarantorPhone, 'Text', this.__ttObject, 'FirstBondGuarantor.Phone');
        redirectProperty(this.txtFirstGuarantorDescription, 'Text', this.__ttObject, 'FirstBondGuarantor.Description');
        redirectProperty(this.FIRSTGUARANTORPHONE, "Text", this.__ttObject, "FirstBondGuarantor.Phone");
        redirectProperty(this.BONDPAYERPHONE, "Text", this.__ttObject, "BondPayer.Phone");
    }

    public async stateChange(e: FormSaveInfo) {
        if (e.transDef.ToStateDefID.valueOf() === Bond.BondStates.LegalProcess.id) {
            let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), i18n("M21594", "Senedi yapılandırmak istediğinize emin misiniz?"));
            if (result === 'OK')
                await super.setState(e.transDef, e);
        }
        else
            await super.setState(e.transDef, e);
    }

    public btnCalcOnLick(triggered: boolean) {

        //if (!triggered)
        //this.NumberOfTerms = parseInt(await InputForm.GetText('Vade Sayısını Giriniz', '1'));

        if (isNaN(this.NumberOfTerms))
            return false;
        if (this.NumberOfTerms != null && this.NumberOfTerms != null) {
            let paymentAmount = Math.Round(this._Bond.BondDocument.TotalPrice / this.NumberOfTerms, 2);
            if (this.NumberOfTerms > 0) {
                this.bondFormViewModel.GrdBondDetailsGridList.Clear();
                let termMockDate: Date;

                if (this._Bond.Episode.PatientStatus === PatientStatusEnum.Outpatient)
                    termMockDate = new Date().AddDays(this.bondFormViewModel.OutPatientBondDayVariable);
                else
                    termMockDate = new Date().AddDays(this.bondFormViewModel.InPatientBondDayVariable);

                let termStartMonth: number = termMockDate.getMonth();
                let termStartDate: number = termMockDate.getDate();
                let termStartYear: number = termMockDate.getFullYear();

                for (let i = 0; i < this.NumberOfTerms; i++) {
                    let detail: BondDetail = new BondDetail();
                    //detail.Bond = this._Bond;
                    if (i != 0)
                        termStartMonth++;

                    if (termStartMonth > 12) {
                        termStartYear = termStartYear + 1;
                        termStartMonth = 1;
                    }

                    let termControlDate = new Date(termStartYear, termStartMonth);
                    let termDate: Date;

                    if (termControlDate.daysinMonth() < termStartDate)
                        termDate = new Date(termStartYear, termStartMonth, termControlDate.daysinMonth());
                    else
                        termDate = new Date(termStartYear, termStartMonth, termStartDate);

                    detail.Date = termDate;
                    detail.Description = (i + 1) + i18n("M10023", ". Taksit");
                    detail.PaymentDate = null;
                    detail.CurrentStateDefID = BondDetail.BondDetailStates.New;
                    detail.Status = i18n("M19890", "Ödenmedi");
                    if (i !== this.NumberOfTerms - 1)
                        detail.Price = paymentAmount;
                    else
                        detail.Price = Math.Round(this._Bond.TotalPrice - this.bondFormViewModel.GrdBondDetailsGridList.reduce((a, b) => a + b.Price, 0), 2);

                    //detail.Paid = false;
                    //detail.CurrentStateDefID = BondDetail.BondDetailStates.New;
                    this.bondFormViewModel.GrdBondDetailsGridList.push(detail);
                }
                this.bondFormViewModel.NumberOfPayments = this.NumberOfTerms;
                this.BondTabs.SelectedTab = this.BondDetail;
            }
            else
                ServiceLocator.MessageService.showError(i18n("M24005", "Vade sayısı sıfırdan büyük olmalıdır!"));
        }
        else
            ServiceLocator.MessageService.showError(i18n("M14603", "Geçersiz bir vade tutarı girdiniz. Vade tutarı sayısal bir değer olmalıdır."));
        /* });*/
    }

    txtNumberOfTermsKeyPress(event: KeyboardEvent) {
        if (event.charCode === 44)
            event.preventDefault();
        if (isNaN(parseInt(event.key)))
            event.preventDefault();
    }

    public initFormControls(): void {
        this.BondTabs = new TTVisual.TTTabControl();
        this.BondTabs.Name = 'BondTabs';

        this.BondPayerTab = new TTVisual.TTTabPage();
        this.BondPayerTab.DisplayIndex = 0;
        this.BondPayerTab.Text = i18n("M11977", "Borçlu Bilgileri");
        this.BondPayerTab.Name = 'BondPayerTab';

        this.lblPayerPhone = new TTVisual.TTLabel();
        this.lblPayerPhone.Text = 'Telefon';
        this.lblPayerPhone.Name = 'lblPayerPhone';

        this.tttextbox11 = new TTVisual.TTTextBox();
        this.tttextbox11.Name = 'tttextbox11';

        this.lblPayerDescription = new TTVisual.TTLabel();
        this.lblPayerDescription.Text = i18n("M10469", "Açıklama");
        this.lblPayerDescription.Name = 'lblPayerDescription';

        this.txtBondPayerDescription = new TTVisual.TTTextBox();
        this.txtBondPayerDescription.Name = 'txtBondPayerDescription';

        this.lblPayerAddress = new TTVisual.TTLabel();
        this.lblPayerAddress.Text = 'Adres';
        this.lblPayerAddress.Name = 'lblPayerAddress';

        this.txtPayerAddress = new TTVisual.TTTextBox();
        this.txtPayerAddress.Name = 'txtPayerAddress';

        this.lblPayerHomeTown = new TTVisual.TTLabel();
        this.lblPayerHomeTown.Text = i18n("M16400", "İlçesi");
        this.lblPayerHomeTown.Name = 'lblPayerHomeTown';

        this.TTListBoxPayerHomeTown = new TTVisual.TTObjectListBox();
        this.TTListBoxPayerHomeTown.ListDefName = 'SKRSIlceKodlariList';
        this.TTListBoxPayerHomeTown.Name = 'TTListBoxPayerHomeTown';

        this.lblPayerHomeCity = new TTVisual.TTLabel();
        this.lblPayerHomeCity.Text = 'İli';
        this.lblPayerHomeCity.Name = 'lblPayerHomeCity';

        this.TTListBoxPayerHomeCity = new TTVisual.TTObjectListBox();
        this.TTListBoxPayerHomeCity.ListDefName = 'SKRSILKodlariList';
        this.TTListBoxPayerHomeCity.Name = 'TTListBoxPayerHomeCity';

        this.lblPayerTownOfRegistry = new TTVisual.TTLabel();
        this.lblPayerTownOfRegistry.Text = i18n("M19560", "Nüfusa Kayıtlı Olduğu İlçe");
        this.lblPayerTownOfRegistry.Name = 'lblPayerTownOfRegistry';

        this.TTListBoxPayerTownOfRegistry = new TTVisual.TTObjectListBox();
        this.TTListBoxPayerTownOfRegistry.ListDefName = 'SKRSIlceKodlariList';
        this.TTListBoxPayerTownOfRegistry.Name = 'TTListBoxPayerTownOfRegistry';

        this.lblPayerCityOfResgistry = new TTVisual.TTLabel();
        this.lblPayerCityOfResgistry.Text = i18n("M19559", "Nüfusa Kayıtlı Olduğu il");
        this.lblPayerCityOfResgistry.Name = 'lblPayerCityOfResgistry';

        this.TTListBoxPayerCityOfRegistry = new TTVisual.TTObjectListBox();
        this.TTListBoxPayerCityOfRegistry.ListDefName = 'SKRSILKodlariList';
        this.TTListBoxPayerCityOfRegistry.Name = 'TTListBoxPayerCityOfRegistry';

        this.lblPayerBirthDate = new TTVisual.TTLabel();
        this.lblPayerBirthDate.Text = i18n("M13132", "Doğum Tarihi");
        this.lblPayerBirthDate.Name = 'lblPayerBirthDate';

        this.dtPickerPayerBirthDate = new TTVisual.TTDateTimePicker();
        this.dtPickerPayerBirthDate.Format = DateTimePickerFormat.Long;
        this.dtPickerPayerBirthDate.Name = 'dtPickerPayerBirthDate';

        this.lblPayerCityOfBirth = new TTVisual.TTLabel();
        this.lblPayerCityOfBirth.Text = i18n("M13139", "Doğum Yeri");
        this.lblPayerCityOfBirth.Name = 'lblPayerCityOfBirth';

        // this.TTListBoxCityOfBirth = new TTVisual.TTObjectListBox();
        // this.TTListBoxCityOfBirth.ListDefName = 'SKRSILKodlariList';
        // this.TTListBoxCityOfBirth.Name = 'TTListBoxCityOfBirth';

        this.lblPayerMotherName = new TTVisual.TTLabel();
        this.lblPayerMotherName.Text = i18n("M11037", "Anne Adı");
        this.lblPayerMotherName.Name = 'lblPayerMotherName';

        this.txtPayerMotherName = new TTVisual.TTTextBox();
        this.txtPayerMotherName.Name = 'txtPayerMotherName';

        this.lblPayerFatherName = new TTVisual.TTLabel();
        this.lblPayerFatherName.Text = i18n("M11390", "Baba Adı");
        this.lblPayerFatherName.Name = 'lblPayerFatherName';

        this.txtPayerFatherName = new TTVisual.TTTextBox();
        this.txtPayerFatherName.Name = 'txtPayerFatherName';

        this.lblPayerSurname = new TTVisual.TTLabel();
        this.lblPayerSurname.Text = i18n("M22205", "Soyadı");
        this.lblPayerSurname.Name = 'lblPayerSurname';

        this.txtPayerSurname = new TTVisual.TTTextBox();
        this.txtPayerSurname.Name = 'txtPayerSurname';

        this.lblPayerIdentificationCardNo = new TTVisual.TTLabel();
        this.lblPayerIdentificationCardNo.Text = i18n("M12300", "Cüzdan No");
        this.lblPayerIdentificationCardNo.Name = 'lblPayerIdentificationCardNo';

        this.lblPayerUniqueRefNo = new TTVisual.TTLabel();
        this.lblPayerUniqueRefNo.Text = i18n("M22944", "TC No");
        this.lblPayerUniqueRefNo.Name = 'lblPayerUniqueRefNo';

        this.txtPayerIdentificationCardNo = new TTVisual.TTTextBox();
        this.txtPayerIdentificationCardNo.Name = 'txtPayerIdentificationCardNo';

        this.txtPayerUniqueRefNo = new TTVisual.TTTextBox();
        this.txtPayerUniqueRefNo.Name = 'txtPayerUniqueRefNo';

        this.lblPayerName = new TTVisual.TTLabel();
        this.lblPayerName.Text = i18n("M10514", "Adı");
        this.lblPayerName.Name = 'lblPayerName';

        this.txtBondPayerName = new TTVisual.TTTextBox();
        this.txtBondPayerName.Name = 'txtBondPayerName';

        this.TTListBox = new TTVisual.TTTabPage();
        this.TTListBox.DisplayIndex = 1;
        this.TTListBox.Text = i18n("M17473", "Kefil Bilgileri");
        this.TTListBox.Name = 'TTListBox';

        this.lblFirstGuarantorPhone = new TTVisual.TTLabel();
        this.lblFirstGuarantorPhone.Text = 'Telefon';
        this.lblFirstGuarantorPhone.Name = 'lblFirstGuarantorPhone';

        // this.txtFirstGuarantorPhone = new TTVisual.TTTextBox();
        // this.txtFirstGuarantorPhone.Name = 'txtFirstGuarantorPhone';

        this.txtFirstGuarantorDescription = new TTVisual.TTTextBox();
        this.txtFirstGuarantorDescription.Name = 'txtFirstGuarantorDescription';

        this.lblFirstGuarantorDescription = new TTVisual.TTLabel();
        this.lblFirstGuarantorDescription.Text = i18n("M10469", "Açıklama");
        this.lblFirstGuarantorDescription.Name = 'lblFirstGuarantorDescription';

        this.txtFirstGuarantorName = new TTVisual.TTTextBox();
        this.txtFirstGuarantorName.Name = 'txtFirstGuarantorName';

        this.lblFirstGuarantorName = new TTVisual.TTLabel();
        this.lblFirstGuarantorName.Text = i18n("M10514", "Adı");
        this.lblFirstGuarantorName.Name = 'lblFirstGuarantorName';

        this.lblFirstGuarantorAddress = new TTVisual.TTLabel();
        this.lblFirstGuarantorAddress.Text = 'Adres';
        this.lblFirstGuarantorAddress.Name = 'lblFirstGuarantorAddress';

        this.txtFirstGuarantorUniqueRefNo = new TTVisual.TTTextBox();
        this.txtFirstGuarantorUniqueRefNo.Name = 'txtFirstGuarantorUniqueRefNo';

        this.txtFirstGuarantorAddress = new TTVisual.TTTextBox();
        this.txtFirstGuarantorAddress.Name = 'txtFirstGuarantorAddress';

        this.txtFirstGuarantorIdentificationCardNo = new TTVisual.TTTextBox();
        this.txtFirstGuarantorIdentificationCardNo.Name = 'txtFirstGuarantorIdentificationCardNo';

        this.lblFirstGuarantorHomeTown = new TTVisual.TTLabel();
        this.lblFirstGuarantorHomeTown.Text = i18n("M16400", "İlçesi");
        this.lblFirstGuarantorHomeTown.Name = 'lblFirstGuarantorHomeTown';

        this.lblFirstGuarantorUniqueRefNo = new TTVisual.TTLabel();
        this.lblFirstGuarantorUniqueRefNo.Text = i18n("M22944", "TC No");
        this.lblFirstGuarantorUniqueRefNo.Name = 'lblFirstGuarantorUniqueRefNo';

        this.TTListBoxFirstGuarantorHomeTown = new TTVisual.TTObjectListBox();
        this.TTListBoxFirstGuarantorHomeTown.ListDefName = 'SKRSIlceKodlariList';
        this.TTListBoxFirstGuarantorHomeTown.Name = 'txtFirstGuarantorHomeTown';

        this.lblFirstGuarantorIdentificationCardNo = new TTVisual.TTLabel();
        this.lblFirstGuarantorIdentificationCardNo.Text = i18n("M12300", "Cüzdan No");
        this.lblFirstGuarantorIdentificationCardNo.Name = 'lblFirstGuarantorIdentificationCardNo';

        this.lblFirstGuarantorHomeCity = new TTVisual.TTLabel();
        this.lblFirstGuarantorHomeCity.Text = 'İli';
        this.lblFirstGuarantorHomeCity.Name = 'lblFirstGuarantorHomeCity';

        this.txtFirstGuarantorSurname = new TTVisual.TTTextBox();
        this.txtFirstGuarantorSurname.Name = 'txtFirstGuarantorSurname';

        this.TTListBoxFirstGuarantorHomeCity = new TTVisual.TTObjectListBox();
        this.TTListBoxFirstGuarantorHomeCity.ListDefName = 'SKRSILKodlariList';
        this.TTListBoxFirstGuarantorHomeCity.Name = 'TTListBoxFirstGuarantorHomeCity';

        this.lblFirstGuarantorSurname = new TTVisual.TTLabel();
        this.lblFirstGuarantorSurname.Text = i18n("M22205", "Soyadı");
        this.lblFirstGuarantorSurname.Name = 'lblFirstGuarantorSurname';

        this.txtFirstGuarantorFatherName = new TTVisual.TTTextBox();
        this.txtFirstGuarantorFatherName.Name = 'txtFirstGuarantorFatherName';

        this.lblFirstGuarantorFatherName = new TTVisual.TTLabel();
        this.lblFirstGuarantorFatherName.Text = i18n("M11390", "Baba Adı");
        this.lblFirstGuarantorFatherName.Name = 'lblFirstGuarantorFatherName';

        this.txtFirstGuarantorMotherName = new TTVisual.TTTextBox();
        this.txtFirstGuarantorMotherName.Name = 'txtFirstGuarantorMotherName';

        this.lblFirstGuarantorMotherName = new TTVisual.TTLabel();
        this.lblFirstGuarantorMotherName.Text = i18n("M11037", "Anne Adı");
        this.lblFirstGuarantorMotherName.Name = 'lblFirstGuarantorMotherName';

        this.lblFirstGuarantorBirthDate = new TTVisual.TTLabel();
        this.lblFirstGuarantorBirthDate.Text = i18n("M13132", "Doğum Tarihi");
        this.lblFirstGuarantorBirthDate.Name = 'lblFirstGuarantorBirthDate';

        // this.TTListBoxFirstGuarantorCityOfBirth = new TTVisual.TTObjectListBox();
        // this.TTListBoxFirstGuarantorCityOfBirth.ListDefName = 'SKRSILKodlariList';
        // this.TTListBoxFirstGuarantorCityOfBirth.Name = 'TTListBoxFirstGuarantorCityOfBirth';

        this.TTListBoxFirstGuarantorBirthDate = new TTVisual.TTDateTimePicker();
        this.TTListBoxFirstGuarantorBirthDate.Format = DateTimePickerFormat.Long;
        this.TTListBoxFirstGuarantorBirthDate.Name = 'TTListBoxFirstGuarantorBirthDate';

        this.lblFirstGuarantorCityOfBirth = new TTVisual.TTLabel();
        this.lblFirstGuarantorCityOfBirth.Text = i18n("M13139", "Doğum Yeri");
        this.lblFirstGuarantorCityOfBirth.Name = 'lblFirstGuarantorCityOfBirth';

        this.BondDetail = new TTVisual.TTTabPage();
        this.BondDetail.DisplayIndex = 2;
        this.BondDetail.Text = i18n("M21598", "Senet Detay");
        this.BondDetail.Name = 'BondDetail';

        this.GrdBondDetails = new TTVisual.TTGrid();
        this.GrdBondDetails.Name = 'GrdBondDetails';
        this.GrdBondDetails.AllowUserToDeleteRows = false;
        this.GrdBondDetails.AllowUserToResizeColumns = false;
        this.GrdBondDetails.AllowUserToResizeRows = false;
        this.GrdBondDetails.AllowUserToAddRows = false;
        this.GrdBondDetails.AllowUserToDeleteRows = false;
        this.GrdBondDetails.AllowUserToOrderColumns = false;
        this.GrdBondDetails.AllowUserToResizeColumns = false;
        this.GrdBondDetails.AllowUserToResizeRows = false;
        //this.GrdBondDetails.Height = 200;

        this.BDDATE = new TTVisual.TTDateTimePickerColumn();
        this.BDDATE.DataMember = 'Date';
        this.BDDATE.DisplayIndex = 0;
        this.BDDATE.HeaderText = i18n("M24007", "Vade Tarihi");
        this.BDDATE.Name = 'BDDATE';
        this.BDDATE.ReadOnly = true;
        //this.BDDATE.Width = 100;

        this.BDPRICE = new TTVisual.TTTextBoxColumn();
        this.BDPRICE.DataMember = 'Price';
        this.BDPRICE.DisplayIndex = 1;
        this.BDPRICE.HeaderText = i18n("M24009", "Vade Tutarı");
        this.BDPRICE.Name = 'BDPRICE';
        this.BDPRICE.ReadOnly = true;
        //this.BDPRICE.Width = 100;

        this.BDPAYMENTDATE = new TTVisual.TTDateTimePickerColumn();
        this.BDPAYMENTDATE.DataMember = 'PaymentDate';
        this.BDPAYMENTDATE.DisplayIndex = 2;
        this.BDPAYMENTDATE.HeaderText = i18n("M19864", "Ödeme Tarihi");
        this.BDPAYMENTDATE.Name = 'BDPAYMENTDATE';
        //this.BDPAYMENTDATE.Width = 100;

        this.BDDESCRIPTION = new TTVisual.TTTextBoxColumn();
        this.BDDESCRIPTION.DataMember = 'Description';
        this.BDDESCRIPTION.DisplayIndex = 3;
        this.BDDESCRIPTION.HeaderText = i18n("M10469", "Açıklama");
        this.BDDESCRIPTION.Name = 'BDDESCRIPTION';
        this.BDDESCRIPTION.Width = 150;

        this.BDSTATUS = new TTVisual.TTTextBoxColumn();
        this.BDSTATUS.DisplayIndex = 4;
        this.BDSTATUS.HeaderText = 'Durum';
        this.BDSTATUS.Name = 'BDSTATUS';
        //this.BDBUTTONPAID.Width = 100;
        this.BDSTATUS.DataMember = 'Status';
        this.BDSTATUS.ReadOnly = true;

        this.BondProceduresTab = new TTVisual.TTTabPage();
        this.BondProceduresTab.DisplayIndex = 3;
        this.BondProceduresTab.Text = i18n("M15953", "Hizmetler");
        this.BondProceduresTab.Name = 'BondProceduresTab';

        this.GrdBondProcedure = new TTVisual.TTGrid();
        this.GrdBondProcedure.AllowUserToDeleteRows = false;
        this.GrdBondProcedure.AllowUserToResizeColumns = false;
        this.GrdBondProcedure.AllowUserToResizeRows = false;
        this.GrdBondProcedure.Name = 'GrdBondProcedure';
        this.GrdBondProcedure.AllowUserToAddRows = false;
        this.GrdBondProcedure.AllowUserToDeleteRows = false;
        this.GrdBondProcedure.AllowUserToOrderColumns = false;
        this.GrdBondProcedure.AllowUserToResizeColumns = false;
        this.GrdBondProcedure.AllowUserToResizeRows = false;

        this.BPACTIONDATE = new TTVisual.TTDateTimePickerColumn();
        this.BPACTIONDATE.CustomFormat = "dd.MM.yyyy";
        this.BPACTIONDATE.DataMember = 'ActionDate';
        this.BPACTIONDATE.DisplayIndex = 0;
        this.BPACTIONDATE.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.BPACTIONDATE.Name = 'BPACTIONDATE';
        this.BPACTIONDATE.ReadOnly = true;
        //this.BPACTIONDATE.Width = 100;


        this.BPEXTERNALCODE = new TTVisual.TTTextBoxColumn();
        this.BPEXTERNALCODE.DataMember = 'ExternalCode';
        this.BPEXTERNALCODE.DisplayIndex = 1;
        this.BPEXTERNALCODE.HeaderText = 'Kodu';
        this.BPEXTERNALCODE.Name = 'BPEXTERNALCODE';
        this.BPEXTERNALCODE.ReadOnly = true;
        //this.BPEXTERNALCODE.Width = 100;

        this.BPAMOUNT = new TTVisual.TTTextBoxColumn();
        this.BPAMOUNT.DataMember = 'Amount';
        this.BPAMOUNT.DisplayIndex = 2;
        this.BPAMOUNT.HeaderText = i18n("M19030", "Miktar");
        this.BPAMOUNT.Name = 'BPAMOUNT';
        this.BPAMOUNT.ReadOnly = true;
        //this.BPAMOUNT.Width = 100;

        this.BPREMAININGPRICE = new TTVisual.TTTextBoxColumn();
        this.BPREMAININGPRICE.DataMember = 'RemainingPrice';
        this.BPREMAININGPRICE.DisplayIndex = 3;
        this.BPREMAININGPRICE.HeaderText = i18n("M17087", "Kalan Tutar");
        this.BPREMAININGPRICE.Name = 'BPREMAININGPRICE';
        this.BPREMAININGPRICE.ReadOnly = true;
        //this.BPREMAININGPRICE.Width = 100;

        this.BPTOTALPRICE = new TTVisual.TTTextBoxColumn();
        this.BPTOTALPRICE.DataMember = 'TotalPrice';
        this.BPTOTALPRICE.DisplayIndex = 4;
        this.BPTOTALPRICE.HeaderText = i18n("M23526", "Toplam Tutar");
        this.BPTOTALPRICE.Name = 'BPTOTALPRICE';
        this.BPTOTALPRICE.ReadOnly = true;
        //this.BPTOTALPRICE.Width = 100;

        this.BPUNITPRICE = new TTVisual.TTTextBoxColumn();
        this.BPUNITPRICE.DataMember = 'UnitPrice';
        this.BPUNITPRICE.DisplayIndex = 5;
        this.BPUNITPRICE.HeaderText = i18n("M11855", "Birim Fiyat");
        this.BPUNITPRICE.Name = 'BPUNITPRICE';
        this.BPUNITPRICE.ReadOnly = true;
        //this.BPUNITPRICE.Width = 100;

        this.BPDESCRIPTION = new TTVisual.TTTextBoxColumn();
        this.BPDESCRIPTION.DataMember = 'Description';
        this.BPDESCRIPTION.DisplayIndex = 6;
        this.BPDESCRIPTION.HeaderText = i18n("M10514", "Adı");
        this.BPDESCRIPTION.Name = 'BPDESCRIPTION';
        this.BPDESCRIPTION.ReadOnly = true;
        //this.BPDESCRIPTION.Width = 100;

        this.grpBoxBondInfo = new TTVisual.TTGroupBox();
        this.grpBoxBondInfo.Text = i18n("M21597", "Senet Bilgisi");
        this.grpBoxBondInfo.Name = 'grpBoxBondInfo';

        this.lblRestructuredBond = new TTVisual.TTLabel();
        this.lblRestructuredBond.Text = i18n("M24285", "Yapılandırılmış Senet No");
        this.lblRestructuredBond.Name = 'lblRestructuredBond';

        this.txtRestructuredBond = new TTVisual.TTTextBox();
        this.txtRestructuredBond.BackColor = '#F0F0F0';
        this.txtRestructuredBond.ReadOnly = true;
        this.txtRestructuredBond.Name = 'txtRestructuredBond';

        this.lblAdavnceTaken = new TTVisual.TTLabel();
        this.lblAdavnceTaken.Text = i18n("M11271", "AvansTutarı");
        this.lblAdavnceTaken.Name = 'lblAdavnceTaken';

        this.txtAdvanceTaken = new TTVisual.TTTextBox();
        this.txtAdvanceTaken.BackColor = '#F0F0F0';
        this.txtAdvanceTaken.ReadOnly = true;
        this.txtAdvanceTaken.Name = 'txtAdvanceTaken';

        this.btnCalcBondDetail = new TTVisual.TTButton();
        this.btnCalcBondDetail.Text = i18n("M24004", "Vade Hesapla");
        this.btnCalcBondDetail.Name = 'btnCalcBondDetail';
        this.btnCalcBondDetail.Visible = false;

        this.lblBondPrice = new TTVisual.TTLabel();
        this.lblBondPrice.Text = i18n("M23606", "Tutar");
        this.lblBondPrice.Enabled = false;
        this.lblBondPrice.Name = 'lblBondPrice';

        this.txtBondPrice = new TTVisual.TTTextBox();
        this.txtBondPrice.BackColor = '#F0F0F0';
        this.txtBondPrice.ReadOnly = true;
        this.txtBondPrice.Name = 'txtBondPrice';

        this.lblBondDescription = new TTVisual.TTLabel();
        this.lblBondDescription.Text = i18n("M10469", "Açıklama");
        this.lblBondDescription.Name = 'lblBondDescription';

        this.lblSecondNotificationDate = new TTVisual.TTLabel();
        this.lblSecondNotificationDate.Text = i18n("M10194", "2. İhbarname Tarihi");
        this.lblSecondNotificationDate.Name = 'lblSecondNotificationDate';

        this.lblFirstNotificationDate = new TTVisual.TTLabel();
        this.lblFirstNotificationDate.Text = i18n("M10085", "1. İhbarname Tarihi");
        this.lblFirstNotificationDate.Name = 'lblFirstNotificationDate';

        this.lblBondDate = new TTVisual.TTLabel();
        this.lblBondDate.Text = i18n("M13413", "Düzenlenme Tarihi");
        this.lblBondDate.Name = 'lblBondDate';

        this.lblBondNo = new TTVisual.TTLabel();
        this.lblBondNo.Text = i18n("M21606", "Senet No");
        this.lblBondNo.Name = 'lblBondNo';

        this.txtBondDescription = new TTVisual.TTTextBox();
        this.txtBondDescription.Name = 'txtBondDescription';

        this.dtPickerBondDate = new TTVisual.TTDateTimePicker();
        this.dtPickerBondDate.BackColor = '#F0F0F0';
        this.dtPickerBondDate.Format = DateTimePickerFormat.Long;
        this.dtPickerBondDate.Enabled = false;
        this.dtPickerBondDate.Name = 'dtPickerBondDate';
        this.dtPickerBondDate.ReadOnly = true;

        this.txtBondNo = new TTVisual.TTTextBox();
        this.txtBondNo.BackColor = '#F0F0F0';
        this.txtBondNo.ReadOnly = true;
        this.txtBondNo.Name = 'txtBondNo';

        this.dtPickerSecondNotificationDate = new TTVisual.TTDateTimePicker();
        this.dtPickerSecondNotificationDate.Format = DateTimePickerFormat.Long;
        this.dtPickerSecondNotificationDate.Name = 'dtPickerSecondNotificationDate';

        this.dtPickerFirstNoficationDate = new TTVisual.TTDateTimePicker();
        this.dtPickerFirstNoficationDate.Format = DateTimePickerFormat.Long;
        this.dtPickerFirstNoficationDate.Name = 'dtPickerFirstNoficationDate';

        this.FIRSTGUARANTORPHONE = new TTVisual.TTMaskedTextBox();
        this.FIRSTGUARANTORPHONE.Mask = "999 9999999";
        this.FIRSTGUARANTORPHONE.Name = "PHONE";
        this.FIRSTGUARANTORPHONE.TabIndex = 7;

        this.BONDPAYERPHONE = new TTVisual.TTMaskedTextBox();
        this.BONDPAYERPHONE.Mask = "999 9999999";
        this.BONDPAYERPHONE.Name = "PHONE";
        this.BONDPAYERPHONE.TabIndex = 7;

        this.GrdBondDetailsColumns = [this.BDDATE, this.BDPRICE, this.BDPAYMENTDATE, this.BDDESCRIPTION, this.BDSTATUS];

        this.GrdBondProcedureColumns = [this.BPACTIONDATE, this.BPEXTERNALCODE, this.BPDESCRIPTION, this.BPAMOUNT, this.BPUNITPRICE, this.BPTOTALPRICE, this.BPREMAININGPRICE];
        this.BondTabs.Controls = [this.BondPayerTab, this.TTListBox, this.BondDetail, this.BondProceduresTab];
        this.BondPayerTab.Controls = [this.lblPayerPhone, this.tttextbox11, this.lblPayerDescription, this.txtBondPayerDescription, this.lblPayerAddress, this.txtPayerAddress,
        this.lblPayerHomeTown, this.TTListBoxPayerHomeTown, this.lblPayerHomeCity, this.TTListBoxPayerHomeCity, this.lblPayerTownOfRegistry,
        this.TTListBoxPayerTownOfRegistry, this.lblPayerCityOfResgistry, this.TTListBoxPayerCityOfRegistry, this.lblPayerBirthDate,
        this.dtPickerPayerBirthDate, this.lblPayerCityOfBirth, /*this.TTListBoxCityOfBirth,*/ this.lblPayerMotherName, this.txtPayerMotherName,
        this.lblPayerFatherName, this.txtPayerFatherName, this.lblPayerSurname, this.txtPayerSurname, this.lblPayerIdentificationCardNo,
        this.lblPayerUniqueRefNo, this.txtPayerIdentificationCardNo, this.txtPayerUniqueRefNo, this.lblPayerName, this.txtBondPayerName, this.BONDPAYERPHONE];
        this.TTListBox.Controls = [this.lblFirstGuarantorPhone, /*this.txtFirstGuarantorPhone,*/ this.txtFirstGuarantorDescription, this.FIRSTGUARANTORPHONE,
        this.lblFirstGuarantorDescription, this.txtFirstGuarantorName, this.lblFirstGuarantorName, this.lblFirstGuarantorAddress,
        this.txtFirstGuarantorUniqueRefNo, this.txtFirstGuarantorAddress, this.txtFirstGuarantorIdentificationCardNo,
        this.lblFirstGuarantorHomeTown, this.lblFirstGuarantorUniqueRefNo, this.TTListBoxFirstGuarantorHomeTown,
        this.lblFirstGuarantorIdentificationCardNo, this.lblFirstGuarantorHomeCity, this.txtFirstGuarantorSurname,
        this.TTListBoxFirstGuarantorHomeCity, this.lblFirstGuarantorSurname, this.txtFirstGuarantorFatherName, this.lblFirstGuarantorFatherName,
        this.txtFirstGuarantorMotherName, this.lblFirstGuarantorMotherName, this.lblFirstGuarantorBirthDate, /*this.TTListBoxFirstGuarantorCityOfBirth,*/
        this.TTListBoxFirstGuarantorBirthDate, this.lblFirstGuarantorCityOfBirth];
        this.BondDetail.Controls = [this.GrdBondDetails];
        this.BondProceduresTab.Controls = [this.GrdBondProcedure];
        this.grpBoxBondInfo.Controls = [this.lblRestructuredBond, this.txtRestructuredBond, this.lblAdavnceTaken, this.txtAdvanceTaken,
        this.btnCalcBondDetail, this.lblBondPrice, this.txtBondPrice, this.lblBondDescription, this.lblSecondNotificationDate,
        this.lblFirstNotificationDate, this.lblBondDate, this.lblBondNo, this.txtBondDescription, this.dtPickerBondDate, this.txtBondNo, this.dtPickerSecondNotificationDate,
        this.dtPickerFirstNoficationDate];

        this.Controls = [this.BondTabs, this.BondPayerTab, this.lblPayerPhone, this.tttextbox11, this.lblPayerDescription, this.txtBondPayerDescription,
        this.lblPayerAddress, this.txtPayerAddress, this.lblPayerHomeTown, this.TTListBoxPayerHomeTown, this.lblPayerHomeCity, this.TTListBoxPayerHomeCity,
        this.lblPayerTownOfRegistry, this.TTListBoxPayerTownOfRegistry, this.lblPayerCityOfResgistry, this.TTListBoxPayerCityOfRegistry, this.lblPayerBirthDate,
        this.dtPickerPayerBirthDate, this.lblPayerCityOfBirth, /*this.TTListBoxCityOfBirth,*/ this.lblPayerMotherName, this.txtPayerMotherName, this.lblPayerFatherName,
        this.txtPayerFatherName, this.lblPayerSurname, this.txtPayerSurname, this.lblPayerIdentificationCardNo, this.lblPayerUniqueRefNo, this.txtPayerIdentificationCardNo,
        this.txtPayerUniqueRefNo, this.lblPayerName, this.txtBondPayerName, this.TTListBox, this.lblFirstGuarantorPhone, /*this.txtFirstGuarantorPhone,*/
        this.txtFirstGuarantorDescription, this.lblFirstGuarantorDescription, this.txtFirstGuarantorName, this.lblFirstGuarantorName, this.lblFirstGuarantorAddress,
        this.txtFirstGuarantorUniqueRefNo, this.txtFirstGuarantorAddress, this.txtFirstGuarantorIdentificationCardNo, this.lblFirstGuarantorHomeTown,
        this.lblFirstGuarantorUniqueRefNo, this.TTListBoxFirstGuarantorHomeTown, this.lblFirstGuarantorIdentificationCardNo, this.lblFirstGuarantorHomeCity,
        this.txtFirstGuarantorSurname, this.TTListBoxFirstGuarantorHomeCity, this.lblFirstGuarantorSurname, this.txtFirstGuarantorFatherName,
        this.lblFirstGuarantorFatherName, this.txtFirstGuarantorMotherName, this.lblFirstGuarantorMotherName, this.lblFirstGuarantorBirthDate,
        /*this.TTListBoxFirstGuarantorCityOfBirth,*/ this.TTListBoxFirstGuarantorBirthDate, this.lblFirstGuarantorCityOfBirth, this.BondDetail,
        this.GrdBondDetails, this.BDDATE, this.BDPRICE, this.BDPAYMENTDATE, this.BDDESCRIPTION, this.BDSTATUS, this.BondProceduresTab, this.GrdBondProcedure,
        this.BPACTIONDATE, this.BPEXTERNALCODE, this.BPAMOUNT, this.BPREMAININGPRICE, this.BPTOTALPRICE, this.BPUNITPRICE, this.BPDESCRIPTION, this.grpBoxBondInfo,
        this.lblRestructuredBond, this.txtRestructuredBond, this.lblAdavnceTaken, this.txtAdvanceTaken, this.btnCalcBondDetail, this.lblBondPrice, this.txtBondPrice,
        this.lblBondDescription, this.lblSecondNotificationDate, this.lblFirstNotificationDate, this.lblBondDate, this.lblBondNo, this.txtBondDescription,
        this.dtPickerBondDate, this.txtBondNo, this.dtPickerSecondNotificationDate, this.dtPickerFirstNoficationDate, this.FIRSTGUARANTORPHONE, this.BONDPAYERPHONE];

    }


}
