import {
    Component, ComponentRef
    , ViewChild, OnDestroy
} from '@angular/core';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ComposeComponent } from 'Fw/Components/ComposeComponent';

@Component({
    selector: 'dynamic-component-test-comp',
    template: `<h2>Parent Component With Dynamic Child</h2>

<div>
    <button (click)='navigateComponent1()'>Navigate Test1 Component</button>
    <button (click)='navigateComponent2()'>Navigate Test2 Component</button>
    <button (click)='startTest()'>Start Test</button>
    <button (click)='stopTest()'>Stop Test</button>
    </div>

<div>
    <comp-compose #dynComp [Info]="componentInfo1"></comp-compose>
</div>


 `
})
export class MemoryLeakTestComponent implements OnDestroy {
    public componentInfo1: DynamicComponentInfo;

    private interval: any;
    private timeout: any;

    constructor() {
    }

    public navigateComponent1(): void {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = "PatientAdmissionForm";
        componentInfo.ModuleName = "KayitKabulModule";
        componentInfo.ModulePath = "/Modules/Tibbi_Surec/Kayit_Kabul_Modulu/KayitKabulModule";
        this.componentInfo1 = componentInfo;
    }

    public navigateComponent2(): void {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = "AppointmentForm";
        componentInfo.ModuleName = "RandevuModule";
        componentInfo.ModulePath = "/Modules/Tibbi_Surec/Randevu_Modulu/RandevuModule";
        this.componentInfo1 = componentInfo;
    }

    startTest() {
        let that = this;
        this.interval = setInterval(() => {
            that.navigateComponent1();
            that.timeout = setTimeout(function () {
                that.navigateComponent2();
            }, 5000);
        }, 3000);
    }

    stopTest() {
        if (this.timeout) {
            clearTimeout(this.timeout);
        }
        if (this.interval) {
            clearInterval(this.interval);
        }
    }

    ngOnDestroy() {
        if (this.timeout) {
            clearTimeout(this.timeout);
        }
        if (this.interval) {
            clearInterval(this.interval);
        }
    }
}
