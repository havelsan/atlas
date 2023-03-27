import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, AfterViewInit } from '@angular/core';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { PrismService } from 'app/Formio/prism/Prism.service';
import { DynamicFormGridResultDto } from './HvlDynamicForm';
import { ShowBox } from 'app/NebulaClient/Visual/ShowBox';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({

    selector: 'dynamic-form-history',
    templateUrl: 'DynamicFormHistory.html',
})
export class DynamicFormHistory implements OnInit {
    

    public isReady : boolean = false;
    public dataSource : any;
    selectedItem: string = "";
    constructor(private httpService: NeHttpService, public prism: PrismService) {
        
    }

    @Input() DynamicFormID: string;
    submission : any =  {};
    public _Parameters: any;
    @Input() set Parameters(value: any) {
        this._Parameters = value;

    }
    get Parameters(): any {
        return this._Parameters;
    }


    @Output() SubmissionChanged = new EventEmitter<any>();

    gridColumns : any  = [];

    ngOnInit() {
        this.loadHistoryGrid();
    }
    selectionChanged(e){
        if(e.selectedRowKeys.length > 0) {
            this.selectedItem = e.selectedRowKeys[0].dynamicFormSubmissionId;
        }
        this.SubmissionChanged.emit(e);
        console.log(e);
    }

    async deleteSubmission(e) {
        if(this.selectedItem) {
            let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&İptal', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', 'Silmek istediğinize emin misiniz?');
            if(result == "OK") {
                this.httpService.post('/api/DynamicForm/DeleteDynamicFormSubmission', { RevisionId: this.selectedItem }).then(p => {
                    if(p) {
                        this.selectedItem = "";
                        this.loadHistoryGrid();
                    }
                });
            }

        }
    }

    loadHistoryGrid(){

        this.httpService.post<DynamicFormGridResultDto>("/api/DynamicForm/GetDynamicFormGrid",
        {
            DynamicFormID : this.DynamicFormID,
            FormParamsJson: JSON.stringify(this.Parameters),

        }).then(x => {


            this.gridColumns = x.Columns;
            this.dataSource = x.ResultSet;

            this.isReady = true;
            console.log(x);

        });
    }
}
