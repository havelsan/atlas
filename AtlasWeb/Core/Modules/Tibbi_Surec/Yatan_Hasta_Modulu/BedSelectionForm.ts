//$4AA66E64
import { Component, Input, Output, EventEmitter } from '@angular/core';

import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { BedSelectionFormViewModel, BedSelectionForm_InputParam, SelectedBedViewModel} from './BedSelectionFormViewModel';
import { ResWard } from 'NebulaClient/Model/AtlasClientModel';
import { ResWardService } from 'NebulaClient/Services/ObjectService/ResWardService';
import { ResBed } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoomGroup } from 'NebulaClient/Model/AtlasClientModel';
import { UsedStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';




@Component({
    selector: 'BedSelectionForm',
    templateUrl: './BedSelectionForm.html',
    providers: [MessageService]
})
export class BedSelectionForm extends TTVisual.TTForm   {

    Bed: TTVisual.ITTObjectListBox;
    Room: TTVisual.ITTObjectListBox;
    RoomGroup: TTVisual.ITTObjectListBox;
    PhysicalStateClinic: TTVisual.ITTObjectListBox;
    btnOpenBedSelectionPopup: TTVisual.ITTButton;
    IsOnlyEmptyBeds: TTVisual.ITTCheckBox;


    private BedSelectionForm_DocumentUrl: string = '/api/BedSelectionFormService/';



    public bedSelectionFormViewModel: BedSelectionFormViewModel = new BedSelectionFormViewModel();
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super("", "BedSelectionForm");
        this._DocumentServiceUrl = this.BedSelectionForm_DocumentUrl;
        this.getPhysicalStateClinicList();
        this.initViewModel();
        this.initFormControls();
        this.bedSelectionFormViewModel.isOnlyEmptyBeds = false;
    }

    public Width: any;
    public sizeControl: boolean = false;
    async ngOnInit() {
        this.Width = window.screen.width;
        if(this.Width < 1700){
            this.sizeControl = true;
        }
        else
            this.sizeControl = false;

        this.GetCleaningModuleActivityStatus();
    }

    public isCleaningModuleActive: boolean;
    async GetCleaningModuleActivityStatus(){
        let requiredField: string = (await SystemParameterService.GetParameterValue('ISCLEANINGMODULEACTIVE', 'FALSE'));
        if (requiredField === 'TRUE') {
            this.isCleaningModuleActive = true;
        }
        else {
        this.isCleaningModuleActive = false;
    }
    }

    public physicalStateClinicList: any;
    public oldPhysicalStateClinic: ResWard;

    public showBedSelectionPopup: boolean;
    public showBtnSave: boolean;

    public roomBedVisible: boolean = true;
    public selectedPhysicalClinicObjectId: string;

    public selectedBedInfo: string;

    private _selectedBedObjectId: Guid;
    set selectedBedObjectId(value: Guid) {
        if (this.IsReadOnly != true && value != null && value.valueOf() != Guid.Empty.valueOf())
            this.showBtnSave = true;
        else
            this.showBtnSave = false;
        this._selectedBedObjectId = value;

    }
    get selectedBedObjectId() {
        return this._selectedBedObjectId;
    }

    private _isReadOnly: boolean;
    @Input() set IsReadOnly(value: boolean) {
        if (value != true && this.selectedBedObjectId != null && this.selectedBedObjectId.valueOf() != Guid.Empty.valueOf())
            this.showBtnSave = true;
        else
            this.showBtnSave = false;
        this._isReadOnly = value;
    }
    get IsReadOnly() {
        return this._isReadOnly;
    }

    @Input() set RoomBedVisible(value: boolean) {
        this.roomBedVisible = value;
    }
    get RoomBedVisible() {
        return this.roomBedVisible;
    }


    @Input() set selectedPhysicalStateClinic(value: ResWard) {

        this.bedSelectionFormViewModel.selectedPhysicalStateClinic = value;

        if (value != null && value.ObjectID != null) {
            if (this.IsReadOnly != true) {
                this.selectedPhysicalClinicObjectId = value.ObjectID.toString();
                if (this.oldPhysicalStateClinic != null && this.oldPhysicalStateClinic.ObjectID != null) {
                    if (this.oldPhysicalStateClinic.ObjectID != value.ObjectID) {
                        this.setBedEmpty(value);
                        this.openBedSelectionPopup();
                    }
                }
            }
            if (value == null || value.ObjectID != null)
                this.oldPhysicalStateClinic = value;
        }
        else
        {
            this.selectedPhysicalClinicObjectId = null;
        }
    }
    get selectedPhysicalStateClinic()
    {
        return this.bedSelectionFormViewModel.selectedPhysicalStateClinic;
    }
    @Input() set selectedRoomGroup(value: ResRoomGroup) {
            this.bedSelectionFormViewModel.selectedRoomGroup = value;
    }
    get selectedRoomGroup() {
        return this.bedSelectionFormViewModel.selectedRoomGroup;
    }

    @Input() set selectedRoom(value: ResRoom) {
        this.bedSelectionFormViewModel.selectedRoom = value;
    }
    get selectedRoom() {
        return this.bedSelectionFormViewModel.selectedRoom;
    }

    @Input() set selectedBed(value: ResBed) {
        this.bedSelectionFormViewModel.selectedBed = value;
        if (value != null && value.ObjectID)
            this.selectedBedObjectId = value.ObjectID;
        else
            this.selectedBedObjectId = Guid.Empty;
    }

    @Input() patientSex: String;

    @Output() sendSelectedBed: EventEmitter<SelectedBedViewModel> = new EventEmitter<SelectedBedViewModel>();

    @Output() sendSelectedPhysicalStateClinic: EventEmitter<ResWard> = new EventEmitter<ResWard>();

    btnOpenBedSelectionPopup_Click()
    {
        this.openBedSelectionPopup();
    }



    private async getPhysicalStateClinicList()
    {
       // this.physicalStateClinicList = await ResSectionService.GetAllResWardListWithEmtyBedCount();

        let that = this;
        this.httpService.get<ResSection.GetAllResWardListWithEmtyBedCount_Class>(this._DocumentServiceUrl + "GetAllResWardListWithEmtyBedCount" )
            .then(response => {
                this.physicalStateClinicList = response;
            })
            .catch(error => {
                console.log(error);
            });
    }

    protected openBedSelectionPopup()
    {
        this.showBedSelectionPopup = true;
        this.getBedSelectionFormViewModel();
    }

    customizeLabel(arg) {
        return arg.argumentText +": "+ arg.valueText;
    }

    public customizePoint(point)
{
    if(point.data.id == 1)
        return {
            color:'black'
        }
    else if(point.data.id == 2)
        return{
            color: '#f3889b'
        }
    else if (point.data.id == 3)
        return{
            color: '#2da0e6'
        }
    else if (point.data.id == 4)
        return{
            color: '#f7d06a'
        }
    else if (point.data.id == 5)
        return{
            color: '#808080'
        }
    else if (point.data.id == 6)
        return{
            color: 'lightpink'
        }
    else if (point.data.id == 7)
        return{
            color: 'lightblue'
        }
}



    public pieDataSource: any;
    public getBedSelectionFormViewModel() {
        let that = this;
        let inputparam: BedSelectionForm_InputParam = new BedSelectionForm_InputParam();
        inputparam.selectedPhysicalStateClinic = this.bedSelectionFormViewModel.selectedPhysicalStateClinic;
        inputparam.isOnlyEmptyBeds = this.bedSelectionFormViewModel.isOnlyEmptyBeds == null ? false : this.bedSelectionFormViewModel.isOnlyEmptyBeds;
        this.httpService.post<BedSelectionFormViewModel>(this._DocumentServiceUrl + "BedSelectionForm", inputparam)
            .then(response => {
                let result: any = response;
                this.bedSelectionFormViewModel.BedsPropertysByResWardList = result.BedsPropertysByResWardList;
                this.bedSelectionFormViewModel.emptyBeds = result.emptyBeds;
                this.bedSelectionFormViewModel.usedBedsMan = result.usedBedsMan;
                this.bedSelectionFormViewModel.usedBedsWoman = result.usedBedsWoman;
                this.bedSelectionFormViewModel.cleaningStatusBeds = result.cleaningStatusBeds;
                this.bedSelectionFormViewModel.reservedToUseMan = result.reservedToUseMan;
                this.bedSelectionFormViewModel.reservedToUseWoman = result.reservedToUseWoman;
                that.arrangeRoomPropertiesList(this.bedSelectionFormViewModel.BedsPropertysByResWardList);

                if(this.isCleaningModuleActive == false){
                    this.bedSelectionFormViewModel.emptyBeds = this.bedSelectionFormViewModel.emptyBeds + this.bedSelectionFormViewModel.cleaningStatusBeds;
                }
                this.pieDataSource =
                [
                    {
                        "id": 1,
                        "arg": "Yatışa Uygun",
                        "val": this.bedSelectionFormViewModel.emptyBeds
                        
                    },
                    {
                        "id": 2,
                        "arg": "Dolu Yatak (Kadın)",
                        "val":  this.bedSelectionFormViewModel.usedBedsWoman
                    },
                    {
                        "id": 3,
                        "arg": "Dolu Yatak (Erkek)",
                        "val": this.bedSelectionFormViewModel.usedBedsMan
                    },
                    {
                        "id": 4,
                        "arg": "İzole Yatak",
                        "val": this.bedSelectionFormViewModel.isolatedBed
                    },
                    {
                        "id": 5,
                        "arg": "Temizlenecek + Temizleniyor",
                        "val": this.bedSelectionFormViewModel.cleaningStatusBeds
                    },
                    {
                        "id": 6,
                        "arg": "Rezerve Yatak (Kadın)",
                        "val": this.bedSelectionFormViewModel.reservedToUseWoman
                    },       
                    {
                        "id": 7,
                        "arg": "Rezerve Yatak (Erkek)",
                        "val": this.bedSelectionFormViewModel.reservedToUseMan
                    }
                ]
            })
            .catch(error => {
                console.log(error);
            });
    }

    

    public firstChoice: Guid;
    public roomPropertiesList: Array<RoomProperties> = new Array<RoomProperties>();
    public tempRoomPropertiesList: ArrayClass = new ArrayClass();
    public rowList: Array<ArrayClass> = new Array<ArrayClass>();
    public arrangeRoomPropertiesList(BedsPropertysByResWardList: Array<ResBed.GetBedsPropertysByResWard_Class>) {
        this.roomPropertiesList = new Array<RoomProperties>();
        let selected: boolean = false;
        let lastRoom: RoomProperties = null;
        for (let BedsPropertys of BedsPropertysByResWardList) {
            if (lastRoom == null || lastRoom.RoomObjectId != BedsPropertys.Roomobjectid) {
                let roomProperties: RoomProperties = new RoomProperties();
                roomProperties.RoomObjectId = BedsPropertys.Roomobjectid;
                roomProperties.RoomName = BedsPropertys.Roomname;
                roomProperties.BedPropertiesList = new Array<BedProperties>();
                this.roomPropertiesList.push(roomProperties);
                let fullBedOfRoom = BedsPropertysByResWardList.find(dr => dr.Roomobjectid == roomProperties.RoomObjectId && dr.Sex != null);
                if (fullBedOfRoom == null)
                    roomProperties.Sex = null;
                else
                    roomProperties.Sex = fullBedOfRoom.Sex;

               let isolatedRoom = BedsPropertysByResWardList.find(bed => bed.Roomobjectid == roomProperties.RoomObjectId && (bed.HasAirborneContactIsolation == true || bed.HasContactIsolation == true || bed.HasDropletIsolation == true || bed.HasTightContactIsolation == true ))
               if(isolatedRoom == null){
                   roomProperties.IsIsolated = false;
               }
               else{
                   roomProperties.IsIsolated = true;
                   this.bedSelectionFormViewModel.isolatedRoom += 1;
               }

               lastRoom = roomProperties;

            }
            let bedProperties: BedProperties = new BedProperties();
            bedProperties.BedName = BedsPropertys.Bedname;
            bedProperties.BedObjectId = BedsPropertys.Bedobjectid;
            bedProperties.HasFallingRisk = BedsPropertys.HasFallingRisk;
            bedProperties.HasAirborneContactIsolation = BedsPropertys.HasAirborneContactIsolation;
            bedProperties.HasDropletIsolation = BedsPropertys.HasDropletIsolation;
            bedProperties.HasContactIsolation = BedsPropertys.HasContactIsolation;
            bedProperties.HasTightContactIsolation = BedsPropertys.HasTightContactIsolation;
            bedProperties.Sex = BedsPropertys.Sex;
            bedProperties.UsedSatus = BedsPropertys.Usedstatus;
            bedProperties.PatientName = BedsPropertys.Patientname;
            bedProperties.PatientSurname = BedsPropertys.Patientsurname;
            bedProperties.isClean = BedsPropertys.IsClean;



            // Set selectedBed
            if (selected == false) {
                if (BedsPropertys.Usedstatus.toString() == UsedStatusEnum.NotUsed.toString()) {
                    if ((lastRoom.Sex == null || lastRoom.Sex == this.patientSex) && ((this.isCleaningModuleActive == true && (bedProperties.isClean == null || bedProperties.isClean == true)) || this.isCleaningModuleActive == false) && lastRoom.IsIsolated == false) {
                        selected = true;
                        bedProperties.Selected = true;
                        this.selectedBedObjectId = BedsPropertys.Bedobjectid;
                        this.firstChoice = this.selectedBedObjectId;
                        this.selectedBedInfo = "Seçili Oda: " + lastRoom.RoomName + " - Seçili Yatak: "+ bedProperties.BedName; 
                    }

                }
            }
            lastRoom.BedPropertiesList.push(bedProperties);

        }
        this.bedSelectionFormViewModel.isolatedBed = 0; 
        this.roomPropertiesList.forEach(room => {
            if(room.IsIsolated == true){
                
            room.BedPropertiesList.forEach(bed => {
                this.bedSelectionFormViewModel.isolatedBed += 1;    
            })
        }
        });
        
        this.tempRoomPropertiesList = new ArrayClass();
        this.rowList = new Array<ArrayClass>();
        let i = 0;
        this.roomPropertiesList.forEach(room => {
            if(i != 12){
                this.tempRoomPropertiesList.tempArray.push(room);
                i++;
            }
            else{
                this.rowList.push(this.tempRoomPropertiesList);
                this.tempRoomPropertiesList = new ArrayClass();
                this.tempRoomPropertiesList.tempArray.push(room);
                i = 1;
            }
        });

        if(this.tempRoomPropertiesList.tempArray.length > 0){
            this.rowList.push(this.tempRoomPropertiesList);
        }

    }

    GetBedStyle(bedProperties: BedProperties) {
        let color: any = 'black'; //koyu gri
        let marginleft: any = '23px';
        let backgroundColor: any = 'white';
        if (bedProperties.UsedSatus.toString() == UsedStatusEnum.Used.toString()) {
            if (bedProperties.Sex == '1') {
                color = '#2da0e6';
            }
            else if (bedProperties.Sex == '2') {
                color = '#fd6b85';
            }
        /*    else if (bedProperties.Sex == null) {
                color = 'black';
            }*/
        }
        else if (bedProperties.UsedSatus.toString() == UsedStatusEnum.ReservedToUse.toString()) {
            if (bedProperties.Sex == '1') {
                color = '#84bacc';
            }
            else if (bedProperties.Sex == '2') {
                color = '#daa6ad';
            }
         /*   else if (bedProperties.Sex == null) {
                color = 'black';
            } */
        }
        if(bedProperties.HasAirborneContactIsolation || bedProperties.HasContactIsolation || bedProperties.HasDropletIsolation || bedProperties.HasFallingRisk || bedProperties.HasTightContactIsolation){
            marginleft =  '0px';
        }

        return {
            'color': color
/*            'padding-right': '20px',
            'margin-left': marginleft*/
        };

    }

    
    GetRoomStyle(roomProperties: RoomProperties, bedProperties:BedProperties) {
        let textAlign: any = 'center';

        if(bedProperties.HasAirborneContactIsolation || bedProperties.HasContactIsolation || bedProperties.HasDropletIsolation || bedProperties.HasFallingRisk || bedProperties.HasTightContactIsolation){
            textAlign = 'right';
        }

        if(roomProperties.IsIsolated == true){
            return {
                'background-color':'#f7d06a',
                 'border-bottom': 'black',
                 'border-bottom-style': 'groove',
                 'border-bottom-width': '1px',
                 'text-align': textAlign,
            };

        }

        else{
    
        return {
             'border-bottom': 'black',
             'border-bottom-style': 'groove',
             'border-bottom-width': '1px',
             'text-align': textAlign
        };
    }

    }

    GetStyleForBackground(bedProperties: BedProperties){
        if(bedProperties.isClean == false &&bedProperties.UsedSatus.toString() == UsedStatusEnum.NotUsed.toString()){
            return {
                'background-color':'#808080',
                'margin-bottom': '0'
           };        
        }
        
        else{
            return {
                'margin-bottom': '0'
           };  
        }
    }


    GetHint(bedProperties:BedProperties) {
        if(bedProperties != null && bedProperties.PatientName != null && bedProperties.PatientSurname != null)
           return bedProperties.BedName + " - "+ bedProperties.PatientName + " " + bedProperties.PatientSurname;
        else
          return bedProperties.BedName;
        
    }
    public warningMessage: string;
    public showWarningMessage: boolean = false;
    async SelectBed(bedProperties: BedProperties) {
        if (this.IsReadOnly != true) {
            if (this.selectedBedObjectId != bedProperties.BedObjectId && bedProperties.UsedSatus.toString() == "0") {
                if(this.isCleaningModuleActive == true){
                if(!(bedProperties.isClean == null || bedProperties.isClean == true)){
                    ServiceLocator.MessageService.showError(i18n("M16907", "Temizlenecek / Temizleniyor durumundaki yataklar seçilemez"));
                    return;
                }
            }
                this.selectedBedObjectId = bedProperties.BedObjectId;
                for (let roomProperties of this.roomPropertiesList) {
                    for (let otherbedProperties of roomProperties.BedPropertiesList) {
                        if (otherbedProperties.BedObjectId == bedProperties.BedObjectId){
                            otherbedProperties.Selected = true;
                            this.selectedBedInfo = "Seçili Oda: " + roomProperties.RoomName + " - Seçili Yatak: "+ bedProperties.BedName; 

                            if(roomProperties.IsIsolated == true){
                            this.warningMessage = "Seçtiğiniz odada ";

                            for (let beds of roomProperties.BedPropertiesList){
                                if(beds.HasAirborneContactIsolation == true){
                                    this.warningMessage += "Solunum İzolasyonu, "
                                }
                                if(beds.HasContactIsolation == true){
                                    this.warningMessage += "Temas İzolasyonu, "
                                }
                                if(beds.HasDropletIsolation == true){
                                    this.warningMessage += "Damlacık İzolasyonu, "
                                }
                                if(beds.HasTightContactIsolation == true){
                                    this.warningMessage += "Sıkı Temas İzolasyonu, "
                                }
                            }
                            this.warningMessage = this.warningMessage.replace(/,\s*$/, " ");
                            this.warningMessage+="seçili hasta(lar) bulunmaktadır."
                            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Devam Et,&Vazgeç", "D,V", i18n("M23735", "Uyarı"), i18n("M23735", ""), i18n("M21560", this.warningMessage), 1);
                            if (result === "V") {
                                this.selectedBedObjectId = null;
                                otherbedProperties.Selected = false;
                                ServiceLocator.MessageService.showError(i18n("M16907", "Seçimden vazgeçildi"));
                                return;
                            }
                            

                        }
                    }
                        else
                            otherbedProperties.Selected = false;
                    }
                }
            }
        }
    }

    public isSelected: boolean = false;
    public infoMessage: string;
    public showInfoMessage: boolean = false;
    public firstSelection: BedProperties;
    public autoSelectedRoom: String;
    public autoSelectedBed: String;
    public AutomaticallySelectedBed: BedProperties;

    public SelectBedAutomatically(){
        for(let room of this.roomPropertiesList){
           let selectBed  = room.BedPropertiesList.filter(x => x.Selected == true)
           if(selectBed[0] != null){
               this.firstSelection = selectBed[0];
               selectBed[0].Selected = false;
               this.selectedBedObjectId = null;
           }
        }
        for(let room of this.roomPropertiesList){
            if(room.IsIsolated == false && (room.Sex == this.patientSex || room.Sex == null)){
                for(let bed of room.BedPropertiesList){
                    if(bed.UsedSatus.toString() == UsedStatusEnum.NotUsed.toString() && ((this.isCleaningModuleActive == true && (bed.isClean == null || bed.isClean == true)) || this.isCleaningModuleActive == false)){
   
                        this.AutomaticallySelectedBed = bed;
                        this.showInfoMessage = true;
                        this.isSelected = true;
                        this.infoMessage = room.RoomName + "-" +bed.BedName + " seçildi. "
                        this.autoSelectedRoom = room.RoomName;
                        this.autoSelectedBed = bed.BedName;
                        return;
                    }
                }
            }
 
        }
        if(this.isSelected == false){
            ServiceLocator.MessageService.showInfo(i18n("M16830", "Otomatik yatak seçimi için uygun oda / yatak bulunamamıştır."));
            return; 
        }
    }

    public onBedConfirmation(event){
        this.selectedBedObjectId = this.AutomaticallySelectedBed.BedObjectId;
        this.AutomaticallySelectedBed.Selected = true;
        this.showInfoMessage = false;
        this.selectedBedInfo = "Seçili Oda: " + this.autoSelectedRoom + " - Seçili Yatak: "+ this.autoSelectedBed; 
        ServiceLocator.MessageService.showSuccess(i18n("M16830", "Yatak seçimi onaylandı"));
        this.getSelectedBedOutPutAndEmit();
        this.showBedSelectionPopup = false;
    }

    public onBedCancel(){
        this.selectedBedObjectId = this.firstChoice;
        this.showInfoMessage = false;
        this.selectedBedObjectId = null;
        this.firstSelection.Selected = true;
        this.selectedBedObjectId = this.firstSelection.BedObjectId;
        ServiceLocator.MessageService.showError(i18n("M16907", "Yatak seçiminden vazgeçildi"));
    }

    public onBedCancelForMainScreen(){

        this.selectedBedObjectId = null;
        this.showBedSelectionPopup = false;


    }

    btnSave_Click() {
        this.getSelectedBedOutPutAndEmit();
        this.showBedSelectionPopup = false;
    }


    //public onPopup_Hiding() {
    //    if (this.IsReadOnly != true) {// readonly true ise Hide ederken hiç bişey yapmaz
    //        if (this.oldBed != null) {
    //            this.selectedBedObjectId = this.oldBed.ObjectID;
    //            this.getSelectedBedOutPutAndEmit();
    //        }
    //    }
    //}

    getSelectedBedOutPutAndEmit() {
        let that = this;
            this.httpService.get<SelectedBedViewModel>(this._DocumentServiceUrl + "GetSelectedBedOutPut?selectedBedObjectId=" + this.selectedBedObjectId)
                .then(response => {
                    let selectedBedViewModel: SelectedBedViewModel = response as SelectedBedViewModel;
                    this.sendSelectedBed.emit(selectedBedViewModel);
                })
                .catch(error => {
                    console.log(error);
                });
        }



    setBedEmpty(physicalStateClinic: ResWard) {
        this.selectedRoomGroup = null;
        this.selectedRoom = null;
        this.selectedBed = null;
        // boş yatağı olmayan klinik seçildiğinde yatak boşalsın diye
        let selectedBedViewModel: SelectedBedViewModel = new SelectedBedViewModel;
        selectedBedViewModel.PhysicalStateClinic = physicalStateClinic;
        selectedBedViewModel.RoomGroup = null;
        selectedBedViewModel.Room = null;
        selectedBedViewModel.Bed = null;
        this.sendSelectedBed.emit(selectedBedViewModel);
    }



    public initViewModel(): void {
        this.bedSelectionFormViewModel = new BedSelectionFormViewModel();
        this._ViewModel = this.bedSelectionFormViewModel;

    }

    public onBedChanged(event): void {
        if (event != null) {
            if (this.selectedBed != event)
                this.selectedBed = event;
            if (this.bedSelectionFormViewModel != null && this.bedSelectionFormViewModel.selectedBed != event) {
                this.bedSelectionFormViewModel.selectedBed = event;
            }
        }
    }

    public onRoomChanged(event): void {
        if (event != null) {
            if (this.selectedRoom != event)
                this.selectedRoom = event;
            if (this.bedSelectionFormViewModel != null && this.bedSelectionFormViewModel.selectedRoom != event) {
                this.bedSelectionFormViewModel.selectedRoom = event;
            }
        }
        this.Room_SelectedObjectChanged();
    }

    public onRoomGroupChanged(event): void {
        if (event != null) {
            if (this.selectedRoomGroup != event)
                this.selectedRoomGroup = event;
            if (this.bedSelectionFormViewModel != null && this.bedSelectionFormViewModel.selectedRoomGroup != event) {
                this.bedSelectionFormViewModel.selectedRoomGroup = event;
            }
        }
        this.RoomGroup_SelectedObjectChanged();
    }

    // Kullanılmıyor
    //public onPhysicalStateClinicChanged(event): void {
    //    if (event != null) {
    //        if (this.selectedPhysicalStateClinic != event)
    //            this.selectedPhysicalStateClinic = event;
    //        if (this.bedSelectionFormViewModel != null && this.bedSelectionFormViewModel.selectedPhysicalStateClinic != event) {
    //            this.bedSelectionFormViewModel.selectedPhysicalStateClinic = event;
    //        }
    //    }
    //    this.PhysicalStateClinic_SelectedObjectChanged();
    //}

    // KUllanılıyor
    async PhysicalStateChanged(val: any) {
        if (val != null && val.value != null) {
           // this.physicalStateClinicHasEmptyBed = val.
            let arr = await ResWardService.GetByID(val.value);
            if (arr.length > 0) {
                this.bedSelectionFormViewModel.selectedPhysicalStateClinic = arr[0];
                this.selectedPhysicalStateClinic = arr[0];
                this.sendSelectedPhysicalStateClinic.emit(this.selectedPhysicalStateClinic);
            }
        }
        else {
            this.sendSelectedPhysicalStateClinic.emit(null);
        }

    }

    public onIsOnlyEmptyBedsChanged(event): void {
        if (event != null) {
            if (this.bedSelectionFormViewModel != null && this.bedSelectionFormViewModel != event) {
                this.bedSelectionFormViewModel.isOnlyEmptyBeds = event;
            }
        }
    }

    //private async PhysicalStateClinic_SelectedObjectChanged(): Promise<void> {

    //}
    public async Room_SelectedObjectChanged(): Promise<void> {

    }
    public async RoomGroup_SelectedObjectChanged(): Promise<void> {

    }



    public initFormControls(): void {

        this.btnOpenBedSelectionPopup = new TTVisual.TTButton();
        this.btnOpenBedSelectionPopup.Text = i18n("M24366", "Yatak Seç");
        this.btnOpenBedSelectionPopup.Name = "btnOpenBedSelectionPopup";
        this.btnOpenBedSelectionPopup.TabIndex = 69;


        this.Bed = new TTVisual.TTObjectListBox();
        this.Bed.ReadOnly = true;
        this.Bed.Required = true;
        this.Bed.LinkedControlName = "Room";
        this.Bed.ForceLinkedParentSelection = true;
        this.Bed.ListFilterExpression = "UsedByBedProcedure is Null";
        this.Bed.ListDefName = "BedListDefinition";
        this.Bed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Bed.Name = "Bed";
        this.Bed.TabIndex = 16;

        this.Room = new TTVisual.TTObjectListBox();
        this.Room.ReadOnly = true;
        this.Room.LinkedControlName = "RoomGroup";
        this.Room.ForceLinkedParentSelection = true;
        this.Room.ListDefName = "RoomListDefinition";
        this.Room.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Room.Name = "Room";
        this.Room.TabIndex = 15;

        this.RoomGroup = new TTVisual.TTObjectListBox();
        this.RoomGroup.ReadOnly = true;
        this.RoomGroup.LinkedControlName = "PhysicalStateClinic";
        this.RoomGroup.ForceLinkedParentSelection = true;
        this.RoomGroup.ListDefName = "RoomGroupListDefinition";
        this.RoomGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RoomGroup.Name = "RoomGroup";
        this.RoomGroup.TabIndex = 13;

        this.PhysicalStateClinic = new TTVisual.TTObjectListBox();
        this.PhysicalStateClinic.ListDefName = "WardListDefinition";
        this.PhysicalStateClinic.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PhysicalStateClinic.Name = "PhysicalStateClinic";
        this.PhysicalStateClinic.TabIndex = 12;

        this.IsOnlyEmptyBeds = new TTVisual.TTCheckBox();
        this.IsOnlyEmptyBeds.Value = false;
        this.IsOnlyEmptyBeds.Title = i18n("M24274", "Yanlızca Boş Yataklar");
        this.IsOnlyEmptyBeds.Name = "IsOnlyEmptyBeds";
        this.IsOnlyEmptyBeds.TabIndex = 14;



        this.Controls = [this.PhysicalStateClinic, this.RoomGroup, this.Room, this.Bed, this.btnOpenBedSelectionPopup];

    }

}

export class BedProperties {
    public BedObjectId: Guid;
    public BedName: String;
    public HasFallingRisk: boolean;
    public HasAirborneContactIsolation: boolean;
    public HasDropletIsolation: boolean;
    public HasContactIsolation: boolean;
    public HasTightContactIsolation: boolean;
    public UsedSatus: Object;
    public Sex: String;
    public Selected: Boolean;
    public PatientName: String;
    public PatientSurname: String;
    public isClean: boolean;
}

export class RoomProperties {
    public RoomObjectId: Guid;
    public RoomName: String;
    public BedPropertiesList: Array<BedProperties> = new Array<BedProperties>();
    public Sex: String;
    public IsIsolated: boolean;
}

export class ArrayClass{
    public tempArray: Array <RoomProperties> = new Array<RoomProperties>();
}



