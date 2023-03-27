import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { PatientExamination } from 'NebulaClient/Model/AtlasClientModel';
import { TreatmentMaterialFormViewModel } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialFormViewModel';

@Component({
    selector: 'treatment-material-test',
    template: `<h1>Base Treatment Material Serialize Test</h1>

    <button (click)="loadTreatmentMaterial()">Load Treatment Material</button>
    <hr/>
    <button (click)="sendTreatmentMaterial()">Send Treatment Material</button>


    `,
})
export class TreatmentMaterialTestComponent implements OnInit   {

    private TreatmentMaterialForm_DocumentUrl: string = '/api/TreatmentMaterialService/';
    private _viewModelJson: any;
    private _viewModel: any;

    constructor(private http: NeHttpService) {

    }

    ngOnInit() {

    }

    loadTreatmentMaterial() {
        let that = this;
        let materialObjectId = '6a87fc69-99ca-4afb-9e42-08bbf5a7cc6a';
        let episodeActionObjectDefID = PatientExamination.ObjectDefID;
        let url = `${this.TreatmentMaterialForm_DocumentUrl}/GetAddedTreatmentMaterial?materialObjectId=${materialObjectId}&EpisodeActionObjectDefID=${episodeActionObjectDefID}`;

        this.http.get<TreatmentMaterialFormViewModel>(url).then(r => {
            console.log(r);
            that._viewModelJson = r;
            that._viewModel = r as TreatmentMaterialFormViewModel;
            console.log(that._viewModelJson);
            console.log(that._viewModel);
        }).catch(err => {
            console.log(err);
        });
    }

    sendTreatmentMaterial() {
        let that = this;
        let url = `${this.TreatmentMaterialForm_DocumentUrl}/SendAddedTreatmentMaterial`;
        console.log(this._viewModel);
        console.log(this._viewModelJson);
        this.http.post(url, this._viewModel).then(r => {
            console.log(r);
            that._viewModel = r;
        }).catch(err => {
            console.log(err);
        });
    }

}