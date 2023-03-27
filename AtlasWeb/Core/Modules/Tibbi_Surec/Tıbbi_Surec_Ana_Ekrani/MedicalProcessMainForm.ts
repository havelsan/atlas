import { Component, ViewChild } from '@angular/core';
import { DynamicComponentInfoDVO } from "../Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DxAccordionComponent } from "devextreme-angular";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from 'Fw/Services/NeHttpService';

@Component({
    selector: "medical_process_main_form",
    templateUrl: './MedicalProcessMainForm.html',

})
export class MedicalProcessMainForm  {

    public SelectedObjectID: Guid;
    public SelectedObjectDefName: string;
    public componentInfo: DynamicComponentInfo;
    public selectedAccordionItem: any;

    @ViewChild('menuAccordion') accordion: DxAccordionComponent;

    constructor(container: ServiceContainer, private http: NeHttpService) {

    }

    ObjectSelected(SelectedObjectID: Guid) {
         this.http.get<DynamicComponentInfoDVO>("api/EpisodeActionWorkListService/GetDynamicComponentInfo?ObjectId=" + SelectedObjectID).then((result: DynamicComponentInfoDVO) => {
            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            compInfo.ComponentName = result.ComponentName;
            compInfo.ModuleName = result.ModuleName;
            compInfo.ModulePath = result.ModulePath;
            compInfo.objectID = result.objectID;
            this.componentInfo = compInfo;
        });
    }
}