import { ComponentRef } from "@angular/core";

export abstract class IActiveComponentRegistryService {
    abstract registerComponent(componentRef: ComponentRef<any>);
    abstract unregisterComponent(componentRef: ComponentRef<any>);
    abstract activeComponents(): Array<ComponentRef<any>>;
}