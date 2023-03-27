
import { Input, Component, ViewChild, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { RefactoredFrequencyEnum, HospitalTimeSchedule, HospitalTimeScheduleDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent } from 'devextreme-angular';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { HospitalTimeScheduleFormViewModel, GetHospitalTimeSchedule_Input, GetHospitalTimeSchedule_OutPut } from './HospitalTimeScheduleFormViewModel';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';

@Component({
    selector: 'hospital-time-schedule-component',
    templateUrl: './HospitalTimeScheduleComponentFormView.html',
    providers: []
})

export class HospitalTimeScheduleComponent implements OnInit {

    public _formClasses;
    @Input() set FormClasses(propVal: any) {
        this._formClasses = propVal;
    }
    get FormClasses(): any {
        return this._formClasses;
    }

    @ViewChild('timeschedulegrid') timeschedulegrid: DxDataGridComponent;

    private selectedTimeScheduleObjectID: Guid;
    public url = 'api/HospitalTimeScheduleService/';
    public hospitalTimeScheduleFormViewModel: HospitalTimeScheduleFormViewModel = new HospitalTimeScheduleFormViewModel();
    public selectedRefactoredFrequencyEnum: RefactoredFrequencyEnum;
    public FrequencyDataSource = RefactoredFrequencyEnum.Items;
    public HospitalTimeSchedules: Array<HospitalTimeSchedule>;
    public timeScheduleDetailCount: number = 1;
    public selectedItemFromOpen: boolean = false;
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string = "İşleminiz Yapılıyor Lütfen Bekleyiniz..";

    //Zaman dilimi grid kolonları
    public TimeScheduleGridColumns = [
        {
            caption: 'T',
            dataField: 'TimeNumber',
            dataType: 'number',
            allowEditing: false,
            width: 40
        },
        {
            caption: 'Saat',
            dataField: 'Time',
            dataType: "date",
            format: "shortTime",
            width: 80,
            editorOptions: {
                type: "time"
            }
        }
    ];

    hospitalTimeScheduleDataColumn = [
        {
            caption: 'ObjectID',
            dataField: 'ObjectID',
            visible: false,
        },
        {
            caption: 'Order Adı',
            dataField: 'Name',
            width: 100,
        },
        {
            caption: "Aktif",
            dataField: 'Active',
            dataType: 'boolean',
            width: 80,
        }
    ];

    constructor(protected http: NeHttpService) {

    }

    private collapseAttr = 0;
    public collapseSelectedDivProperties(): string {
        if (this.collapseAttr == 1) {
            return "hidden";
        }
        return "col-md-3";

    }
    public collapseIconProperties(): string {

        if (this.collapseAttr == 1) {
            return "fa fa-2x fa-angle-up";
        }
        return "fa fa-2x fa-angle-left";

    }

    btnCollapse() {
        if (this.collapseAttr == 1) {
            this.collapseAttr = 0;
        } else
            this.collapseAttr = 1;
    }
    public collapseBtnProperties(): string {

        if (this.collapseAttr == 1) {
            return "float-left";
        }
        return "float-right";

    }

    public collapsedPanelProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-11 episodeColMd11 col-sm-12 col-xs-12";
        }
        return "col-md-9";

    }

    public collapseSelectedHiddenDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-1 episodeColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }

    ngOnInit(): void {
        this.GetHospitalTimeSchedules();
    }

    //Tanımın detaylarını (Zaman dilimlerini) getirir.
    async GetSelectedTimeScheduleDetails() {
        if (this.selectedTimeScheduleObjectID != null) {
            let input: GetHospitalTimeSchedule_Input = new GetHospitalTimeSchedule_Input();
            input.hospitalTimeScheduleID = this.selectedTimeScheduleObjectID;
            let result = await this.http.post<GetHospitalTimeSchedule_OutPut>(this.url + 'GetSelectedHospitalTimeSchedule', input);
            this.hospitalTimeScheduleFormViewModel = result.hospitalTimeScheduleFormViewModel;
        }
    }

    //Form init eder. Kayıtlı tanımları getirir.
    public GetHospitalTimeSchedules() {
        this.http.get<Array<HospitalTimeSchedule>>(this.url + 'InitHospitalTimeScheduleForm').then(result => {
            this.HospitalTimeSchedules = result;
        });
    }

    //Yeni bir kayıt oluşturmak için.
    public CreateNewHospitalTimeSchedule() {
        this.selectedItemFromOpen = true;
        this.hospitalTimeScheduleFormViewModel = new HospitalTimeScheduleFormViewModel();
    }

    //Oluşan detayları saate göre sıralar ve numaralandırır.
    public CreateTimeNumbers() {
        this.hospitalTimeScheduleFormViewModel.HospitalTimeScheduleDetails = this.hospitalTimeScheduleFormViewModel.HospitalTimeScheduleDetails.sort((x1, x2) => {
            if (x1.Time != null && x2.Time != null) {
                let tempX1 = new Date(1, 1, 1, x1.Time.getHours(), x1.Time.getMinutes());
                let tempX2 = new Date(1, 1, 1, x2.Time.getHours(), x2.Time.getMinutes());
                if (tempX1 > tempX2)
                    return 1;
                if (tempX1 < tempX2)
                    return -1;
            }
            else if (x1.Time == null && x2.Time != null)
                return 1;
            else if (x2.Time == null && x1.Time != null)
                return -1;
            else
                return -1;
        });
        let timeNumber = 1;
        this.hospitalTimeScheduleFormViewModel.HospitalTimeScheduleDetails.filter(x => x.EntityState != EntityStateEnum.Deleted && x.Time != null && x.Time != undefined).forEach(element => {
            element.TimeNumber = timeNumber;
            timeNumber++;
        });
        this.selectedTimeScheduleObjectID = null;
    }

    //Yeni zaman dilimleirini kayıt eder, değişiklik yapılanları günceller.
    public SaveTimeSchedule() {
        if (this.hospitalTimeScheduleFormViewModel.HospitalTimeScheduleDetails.filter(x => x.Time == null).length > 0)
            ServiceLocator.MessageService.showError('Saat seçimi yapılmamış kayıtlar mevcut! Lütfen saat seçimi yapınız.');
        else {
            this.SaveGridChanges();
            this.http.post<boolean>(this.url + 'HospitalTimeSchedule', this.hospitalTimeScheduleFormViewModel).then(result => {
                if (result) {
                    this.GetHospitalTimeSchedules();
                    this.GetSelectedTimeScheduleDetails();
                }
            });
        }
    }

    //Seçilen tanımın Kayıtlı Zaman Dilimlerini getirir.
    public async onHospitalTimeScheduleValueChanged(event: any) {
        this.selectedTimeScheduleObjectID = event.value;
        this.GetSelectedTimeScheduleDetails();
    }

    async selectionGridEvent(e) {
        if (e.selectedRowsData != null && e.selectedRowsData.length > 0) {
            this.loadingVisible = true;
            this.selectedItemFromOpen = true;
            this.selectedTimeScheduleObjectID = e.selectedRowsData[0].ObjectID;
            this.GetSelectedTimeScheduleDetails();
            this.loadingVisible = false;
        }
    }

    //Grid'e satır (Yeni Zaman Dilimi) eklendiğinde tekrar sırala.
    public onTimeScheduleGridRowInsterted(event: any) {
        let data = <HospitalTimeScheduleDetail>event.key;
        if (event.key.Time != null)
            this.CreateTimeNumbers();
        data.EntityState = EntityStateEnum.Added;
        this.SaveGridChanges();
    }
    /*Grid kolonlarında bir değişiklik yapıldıktan sonra bir action çağırılırken
    modele bind işleminin yapılması için çağırılan metod.*/
    public SaveGridChanges() {
        this.timeschedulegrid.instance.closeEditCell();
        this.timeschedulegrid.instance.saveEditData();
    }

    //Grid'de değişiklik yapıldığında zaman dilimlerini tekrar hesaplar.
    public onRowUpdated(event: any) {
        this.CreateTimeNumbers();
    }

    //Grid satır silme.
    public onTimeScheduleGridRowRemoving(event: any) {
        if (event.key != null && event.key.EntityStateEnum == EntityStateEnum.Added) {
            event.key.EntityState = EntityStateEnum.Deleted;
            this.timeschedulegrid.instance.filter(['EntityState', '<>', 1]);
            if (event.key instanceof HospitalTimeScheduleDetail) {
                event.cancel = true;
            }
        }
        this.CreateTimeNumbers();
        this.timeschedulegrid.instance.refresh();
    }

    //Kaç tane zaman dilimi oluşturulacağı.
    public onTimeScheduleDetailCountValueChanged(event) {
        if (Number.isInteger(24 / event.value))
            this.timeScheduleDetailCount = event.value;
        else {
            this.timeScheduleDetailCount = 1;
            ServiceLocator.MessageService.showError('Lütflen 24 Saate tam bölünebilecek bir sayı giriniz!');
        }
    }

    //Zaman dilimlerini otomatik oluşturan metod.
    public onAutoGenerateTimeScheduleDetails() {
        if (this.timeScheduleDetailCount != null && this.timeScheduleDetailCount > 0) {
            this.hospitalTimeScheduleFormViewModel.HospitalTimeScheduleDetails.forEach(element => {
                if (element instanceof HospitalTimeScheduleDetail)
                    element.EntityState = EntityStateEnum.Deleted;
            });
            this.timeschedulegrid.instance.filter(['EntityState', '<>', 1]);
            this.timeschedulegrid.instance.refresh();
            //this.hospitalTimeScheduleFormViewModel.HospitalTimeScheduleDetails = new Array<HospitalTimeScheduleDetail>();
            let detailTimePeriod = 24 / this.timeScheduleDetailCount;
            let time = new Date(2000, 1, 1, 0, 0, 0, 0);
            for (let index = 0; index < this.timeScheduleDetailCount; index++) {
                let hospitalTimeScheduleDetail = new HospitalTimeScheduleDetail();
                hospitalTimeScheduleDetail.Time = new Date(time.toString());
                time = time.AddHours(detailTimePeriod);
                this.hospitalTimeScheduleFormViewModel.HospitalTimeScheduleDetails.push(hospitalTimeScheduleDetail);
            }
            this.CreateTimeNumbers();
        }
    }

    Cancel() {
        this.selectedItemFromOpen = false;
        this.hospitalTimeScheduleFormViewModel = new HospitalTimeScheduleFormViewModel();
    }
}

