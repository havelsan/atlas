import { Component, AfterViewInit, Input, ApplicationRef, ViewChild, ElementRef } from '@angular/core';
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { TestResultQueryInputDVO } from "./ProcedureRequestViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";


@Component({
    selector: 'testresults-form',
    templateUrl: './TestResultsForm.html',
    providers: []
})

export class TestResultsForm extends TTUnboundForm implements AfterViewInit {
    @ViewChild('frame') Frame: ElementRef;
    viewResultURL: string = "";
    @Input() ViewType: string;

    private _episodeID: string;
    @Input() set EpisodeID(value: string) {
        this._episodeID = value;
        if (this.EpisodeID != null)
        {
            this.GetViewResultURL(this.ViewType).then(() => {
                this.SetUrl(this.viewResultURL);
            });
        }
    }
    get EpisodeID(): string {
        return this._episodeID;
    }


    constructor(protected httpService: NeHttpService, private detector: ApplicationRef) {
        super("", "");
    }

    ngAfterViewInit(): void {
        this.SetUrl(this.viewResultURL);
    }

    SetUrl(url: String) {
        if (url != null)
        {
            if (this.Frame) {
                this.Frame.nativeElement.src = url;
            }
        }
    }

    public async GetViewResultURL(viewType: string): Promise<void>
    {

        let that = this;
        let inputDVO = new TestResultQueryInputDVO();
        inputDVO.ViewType = viewType;
        inputDVO.EpisodeID = this.EpisodeID.toString();

        let apiUrl: string = 'api/ProcedureRequestService/GetURLForAllTestResults'; //?ViewType=' + viewType + "&EpisodeID=" + this.EpisodeAction.Episode.ID.toString();
        let result = await this.httpService.post<string>(apiUrl, inputDVO);
        this.viewResultURL = result;
    }




}