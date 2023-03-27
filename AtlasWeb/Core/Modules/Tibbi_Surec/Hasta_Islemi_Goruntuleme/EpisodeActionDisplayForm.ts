import { Component, OnDestroy } from '@angular/core';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { EpisodeActionDisplayFormViewModel, ActiveInfoDVO } from "./EpisodeActionDisplayFormViewModel";
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { Subscription } from 'rxjs';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';

@Component({
    selector: "EpisodeActionDisplayForm",
    inputs: ['Model'],
    templateUrl: './EpisodeActionDisplayForm.html',
    providers: [SystemApiService],
})
export class EpisodeActionDisplayForm extends BaseComponent<EpisodeActionDisplayFormViewModel> implements OnDestroy {
    public componentInfo: DynamicComponentInfo;

    private episodeActionDisplayFormSubscription: Subscription;

   constructor(container: ServiceContainer, protected httpService: NeHttpService, public systemApiService: SystemApiService) {
        super(container);

        this.episodeActionDisplayFormSubscription = this.httpService.episodeActionDisplayFormSharedService.EpisodeActionDisplayItem.subscribe(
            episodeActionDisplayFormViewModel => {
                this.openDynamicComponent(episodeActionDisplayFormViewModel.ObjectDefName, episodeActionDisplayFormViewModel.ObjectID, episodeActionDisplayFormViewModel.FormDefID, episodeActionDisplayFormViewModel.InputParam);
            }
        );


    }

    ngOnDestroy() {
        if (this.episodeActionDisplayFormSubscription != null) {
            this.episodeActionDisplayFormSubscription.unsubscribe();
            this.episodeActionDisplayFormSubscription = null;
        }

    }

    clientPreScript(): void {
    }

    clientPostScript(state: String) {
    }

    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam);

        }
        else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
            });
        }
    }

    closeDynamicComponent() {
        this.systemApiService.componentInfo = null;
    }
}