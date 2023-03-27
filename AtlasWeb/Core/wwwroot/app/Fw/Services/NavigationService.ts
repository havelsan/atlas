import { Injectable} from '@angular/core';
import { Router } from '@angular/router';
import { IModalService } from 'Fw/Services/IModalService';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';

export class RoutingParameter {
    Data: any;
    IsPopup: boolean;
    CompInfo?: DynamicComponentInfo;
}

export class RoutingParameters {
    [propName: string]: RoutingParameter;
}

@Injectable()
export class NavigationService {
    private TransferData: RoutingParameters = new RoutingParameters();
    constructor(private router: Router, private modalService: IModalService) {
    }

    navigate(routeLink: string) {
        let parameter = this.getTransferParameter(routeLink, false);
        if (parameter && parameter.IsPopup) {
            this.modalService.create(parameter.CompInfo, null);
            return;
        }
        this.router.navigate([routeLink]);
    }

    setTransferParametersPopup(path: string, data: any, modulePath: string, moduleName: string, compName: string) {
        this.TransferData[path] = {
            Data: data, IsPopup: true, CompInfo: {
                ComponentName: compName,
                ModuleName: moduleName,
                ModulePath: modulePath,
                objectID: null,
                InputParam: null
            }
        };
    }

    setTransferParameters(path: string, data: any) {
        this.TransferData[path] = {
            Data: data, IsPopup: false
        };
    }

    getTransferParameter(path: string, removeParameter: boolean = true): RoutingParameter {
        let result = this.TransferData[path];
        if (result) {
            let data = JSON.parse(JSON.stringify(result));
            if (removeParameter) {
                delete this.TransferData[path];
            }
            return data;
        }
    }

    removeParameter(path: string) {
        delete this.TransferData[path];
    }
}