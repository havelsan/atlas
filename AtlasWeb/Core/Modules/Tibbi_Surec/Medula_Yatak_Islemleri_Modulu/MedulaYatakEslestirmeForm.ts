import { Component, Input, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "app/Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import { DynamicSidebarMenuItem } from "app/SidebarMenu/Models/DynamicSidebarMenuItem";
import { ISidebarMenuService } from "app/Fw/Services/ISidebarMenuService";
import { SystemParameterService } from "app/NebulaClient/Services/ObjectService/SystemParameterService";
import { UsernamePwdInput, UsernamePwdBox } from "app/NebulaClient/Visual/UsernamePwdBox";
import { DialogResult } from "app/NebulaClient/Utils/Enums/DialogResult";
import { ModalActionResult } from "app/Fw/Models/ModalInfo";
import { UsernamePwdFormViewModel } from "app/Fw/Components/UsernamePwdFormComponent";
import List from "app/NebulaClient/System/Collections/List";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { MedulaYardimciIslemler } from "app/NebulaClient/Services/External/MedulaYardimciIslemler";
import { DxDataGridComponent } from "devextreme-angular";
import { threadId } from "worker_threads";
@Component({
    selector: "MedulaYatakEslestirmeForm",
    templateUrl: './MedulaYatakEslestirmeForm.html',
})
export class MedulaYatakEslestirmeForm {

    public SelectedBeds = [];
    public SelectedMedulaBeds = [];
    public LoadPanelMessage = "";
    public showLoadPanel = false;
    public selectedMedulaBed: any;
    public selectedBed: any;
    public medulaYatakEslestirmeViewModel: MedulaYatakEslestirmeModel = new MedulaYatakEslestirmeModel();


    constructor(private httpService: NeHttpService,
        protected messageService: MessageService,
        private sideBarMenuService: ISidebarMenuService
    ) {
    }
    async ngOnInit() {
        this.loadPanelOperation(true, "Yatak Verileri Yükleniyor, Lütfen Bekleyin...");
        let url: string = '/api/MedulaYatakEslestirmeFormService/getViewModel';
        await this.httpService.get<MedulaYatakEslestirmeModel>(url).then(response => {
            this.medulaYatakEslestirmeViewModel = response;
        }).catch(ex => {
            this.loadPanelOperation(false, "");
        });
        this.loadPanelOperation(false, "");
    }

    public UnMatchedMedulaBedGridColumns =
        [
            {
                caption: 'Medula Yatak No',
                dataField: 'yatakKodu',
                width: "auto",
                allowEditing: false

            },
            {
                caption: 'Yatak Türü',
                dataField: 'turu',
                width: "auto",
                allowEditing: false
            },
            {
                caption: 'Seviye',
                dataField: 'seviye',
                width: "auto",
                allowEditing: false
            },
            {
                caption: "Geçerlilik Başlangıç Tarihi",
                dataField: 'gecerlilikBaslangicTarihi'
            }
        ];

    public UnMatchedBedGridColumns =
        [
            {
                caption: 'Klinik',
                dataField: 'Ward',
                width: "auto",
                allowEditing: false

            },
            {
                caption: 'Oda',
                dataField: 'Room',
                width: "auto",
                allowEditing: false

            },
            {
                caption: 'Yatak',
                dataField: 'BedNumber',
                width: "auto",
                allowEditing: false
            },
            {
                caption: 'Basamak Bilgisi',
                dataField: 'BedLevel',
                width: "auto",
                cellTemplate: 'bedLevelCellTemplate'
            }
        ];

    public MatchedBedGridColumns =
        [
            {
                caption: 'Klinik',
                dataField: 'Ward',
                width: "auto",
                allowEditing: false

            },
            {
                caption: 'Oda',
                dataField: 'Room',
                width: "auto",
                allowEditing: false

            },
            {
                caption: 'Yatak',
                dataField: 'BedNumber',
                width: "auto",
                allowEditing: false
            },
            {
                caption: 'Yatak Türü',
                dataField: 'BedType',
                width: "auto",
                allowEditing: false
            },
            {
                caption: 'Basamak Bilgisi',
                dataField: 'BedLevel',
                width: "auto",
                cellTemplate: 'bedLevelCellTemplate'
            },
            {
                caption: i18n("M27286", "Sil"),
                name: 'RowDelete',
                width: '50',
                cellTemplate: 'deleteCellTemplate'
            }
        ];



    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    @ViewChild('matchedBedsGrid') matchedBedsGrid: DxDataGridComponent;

    async deleteRelation(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    let that = this;
                    this.loadPanelOperation(true, "Eşleştirme Verisi Siliniyor, Lütfen Bekleyin...");
                    let url: string = '/api/MedulaYatakEslestirmeFormService/DeleteMedulaMatchFromBed?bedObjectId=' + data.row.key.BedObjectId.toString();
                    await this.httpService.get<boolean>(url).then(response => {
                        if (response == true) {
                            let medulaBed = that.medulaYatakEslestirmeViewModel.MedulaBedList.find(t => t.yatakKodu == data.row.key.MedulaBedCode);
                            that.medulaYatakEslestirmeViewModel.UnMatchedMedulaBedList.unshift(medulaBed);
                            data.row.key.MedulaBedCode = "";
                            that.medulaYatakEslestirmeViewModel.UnMatchedBedList.unshift(data.row.key);                            
                            that.matchedBedsGrid.instance.deleteRow(data.rowIndex);
                        }
                    }).catch(ex => {
                        this.loadPanelOperation(false, "");
                    });
                    this.loadPanelOperation(false, "");
                }
            }
        }
    }

    selectMedulaBed(e) {
        this.selectedMedulaBed = e.selectedRowKeys[0];
    }

    selectBed(e) {
        this.selectedBed = e.selectedRowKeys[0];
    }

    public async RefreshScreen() {
        this.loadPanelOperation(true, "Yatak Verileri Yükleniyor, Lütfen Bekleyin...");
        let url: string = '/api/MedulaYatakEslestirmeFormService/getViewModel';
        await this.httpService.get<MedulaYatakEslestirmeModel>(url).then(response => {
            this.medulaYatakEslestirmeViewModel = response;
        }).catch(ex => {
            this.loadPanelOperation(false, "");
        });
        this.loadPanelOperation(false, "");
    }

    public async matchBedWithMedulaBed() {
        let that = this;
        if (this.selectedBed == null || this.selectedMedulaBed == null) {
            ServiceLocator.MessageService.showError("Medula yatağı veya XXXXXX yatağı seçmediğiniz için eşleştirme yapamazsınız.!");
            return;
        }
        debugger;
        let url: string = '/api/MedulaYatakEslestirmeFormService/MatchMedulaBed?bedObjectId=' + this.selectedBed.BedObjectId.toString() + '&bedCodeForMedula=' + this.selectedMedulaBed.yatakKodu;
        await this.httpService.get<boolean>(url).then(response => {
            if (response == true) {
                let newMatchedBed = that.medulaYatakEslestirmeViewModel.UnMatchedBedList.find(t => t.BedObjectId.toString() == that.selectedBed.BedObjectId.toString());
                newMatchedBed.MedulaBedCode = that.selectedMedulaBed.yatakKodu;
                that.medulaYatakEslestirmeViewModel.MatchedBedList.unshift(newMatchedBed);
                that.medulaYatakEslestirmeViewModel.UnMatchedBedList = that.medulaYatakEslestirmeViewModel.UnMatchedBedList.filter(u => u.BedObjectId.toString() != that.selectedBed.BedObjectId.toString());

                that.medulaYatakEslestirmeViewModel.UnMatchedMedulaBedList = that.medulaYatakEslestirmeViewModel.UnMatchedMedulaBedList.filter(u => u.yatakKodu != that.selectedMedulaBed.yatakKodu);
                that.selectedBed = null;
                that.selectedMedulaBed = null;
            }
        }).catch(ex => {
            this.loadPanelOperation(false, "");
        });
    }

}

export class MedulaYatakEslestirmeModel {
    public MedulaBedList: Array<MedulaYardimciIslemler.tesisYatakBilgiDVO> = new Array<MedulaYardimciIslemler.tesisYatakBilgiDVO>();
    public UnMatchedMedulaBedList: Array<MedulaYardimciIslemler.tesisYatakBilgiDVO> = new Array<MedulaYardimciIslemler.tesisYatakBilgiDVO>();
    public UnMatchedBedList: Array<BedModel> = new Array<BedModel>();
    public MatchedBedList: Array<BedModel> = new Array<BedModel>();
}

export class BedModel {
    public BedObjectId: Guid;
    public Room: string;
    public BedNumber: string;
    public BedType: string;
    public BedLevel: string;
    public MedulaBedCode: string;
}
