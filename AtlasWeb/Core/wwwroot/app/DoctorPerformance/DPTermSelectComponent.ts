//$B031EBC6
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { LookupColumn, DoctorPerformanceTermModel, DoctorPerformanceTermStatesString } from './DoctorPerformanceViewModel';
import { DoctorPerformanceTerm } from 'NebulaClient/Model/AtlasClientModel';
import { DatePipe } from '@angular/common';

@Component({
    selector: "DPTermSelectComponent",
    templateUrl: './DPTermSelectComponent.html',
    providers: [DatePipe]
})
export class DPTermSelectComponent  implements OnInit {
    public termDataSource: Array<LookupColumn>;
    public termValue: string;
    @Output() valueChange: EventEmitter<any> = new EventEmitter<any>();
    @Input() value: any;

    constructor(private datePipe: DatePipe, protected http: NeHttpService) {
        this.termDataSource = new Array<LookupColumn>();
    }

    ngOnInit() {
        this.loadDataSource();
    }

    loadDataSource(): void {
        this.termDataSource = new Array<LookupColumn>();
        this.http.get<Array<DoctorPerformanceTermModel>>("api/DoctorPerformanceApi/GetDoctorPerformanceTerm").then(result => {
            result.forEach(x => {
                let stateString = "";
                if (x.CurrentState == DoctorPerformanceTerm.DoctorPerformanceTermStates.Cancelled.toString())
                    stateString = DoctorPerformanceTermStatesString.Cancelled;
                else if (x.CurrentState == DoctorPerformanceTerm.DoctorPerformanceTermStates.Close.toString())
                    stateString = DoctorPerformanceTermStatesString.Close;
                else if (x.CurrentState == DoctorPerformanceTerm.DoctorPerformanceTermStates.Open.toString())
                    stateString = DoctorPerformanceTermStatesString.Open;

                let tempName = x.Name + " || " + this.datePipe.transform(x.StartDate, 'dd.MM.yyyy') + "-" + this.datePipe.transform(x.EndDate, 'dd.MM.yyyy') + " || " + stateString;
                this.termDataSource.push(new LookupColumn(x.ObjectID.toString(), tempName, x.CurrentState));
            });
        });
    }

    onValueChangedTermSelectBox(event: any) {
        this.valueChange.emit(this.value);
    }
    onOpenedTermSelectBox(event: any) {
        this.loadDataSource();
    }

}