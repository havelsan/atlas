import {
    Component, ComponentRef, ModuleWithComponentFactories
    , Compiler, ComponentFactoryResolver, Injector
    , ViewChild, Renderer2

} from '@angular/core';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { ComposeComponent } from 'Fw/Components/ComposeComponent';

@Component({
    selector: 'dynamic-component-test-comp',
    template: `<h2>Parent Component With Dynamic Child</h2>

    <button (click)='testDynamicForm()'>Test Dynamic Form</button>

    <button (click)='testMhrsExceptionalForm()'>Test Mhrs ExceptionalForm</button>

    <button (click)='testLoadModule()'>Test Load Module</button>

<div>
<comp-compose #dynComp [Info]="componentInfo1" (ComponentCreated)="onComponentCreated($event)" ></comp-compose>
</div>

<hr/>
<button (click)='testPreRenderCheck2()'>Test Pre Render Check (Render)</button>
<button (click)='testPreRenderCheck1()'>Test Pre Render Check (Don't Render)</button>
<comp-compose [Info]="componentInfo2"></comp-compose>

<hr/>
<button (click)='testBoundFormDispose()'>Test TTBoundFormBase derived component</button>
<comp-compose [Info]="componentInfo3" [ReadOnlyByCode]="true" ></comp-compose>


 `
})
export class DynamicComponentTestComponent {
    public componentInfo1: DynamicComponentInfo;
    public componentInfo2: DynamicComponentInfo;
    public componentInfo3: DynamicComponentInfo;
    private unListenOnClick: Function;



    private message: string = 'this is a message';

    constructor(
        private compiler: Compiler,
        private injector: Injector,
        private renderer: Renderer2,
        private componentFactorResolver: ComponentFactoryResolver,
        private http: NeHttpService,
        private messageService: MessageService) {

        this.componentInfo1 = new DynamicComponentInfo();
        this.componentInfo1.ComponentName = 'DynamicTestComponent';
        this.componentInfo1.ModuleName = 'DynamicTestModule';
        this.componentInfo1.ModulePath = '/app/TestPad/DynamicTestModule';

    }

    public onClick(e: any) {
        console.log(e);
        console.log(this.message);
    }

    public onComponentCreated(componentRef: ComponentRef<any>): void {
        let boundedFunc = this.onClick.bind(this);
        this.unListenOnClick =  this.renderer.listen(componentRef.location.nativeElement, 'click', boundedFunc);

        // OnDestroy
        // aboneliğin kaldırılması
        // this.unListenOnClick();
    }

    public testPreRenderCheck1(): void {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'DynamicTestComponent';
        componentInfo.ModuleName = 'DynamicTestModule';
        componentInfo.ModulePath = '/app/TestPad/DynamicTestModule';
        componentInfo.RenderPreCheckUri = '/api/Test/IsFormRender';
        this.componentInfo2 = componentInfo;
    }

    public testPreRenderCheck2(): void {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'DynamicTestComponent';
        componentInfo.ModuleName = 'DynamicTestModule';
        componentInfo.ModulePath = '/app/TestPad/DynamicTestModule';
        componentInfo.RenderPreCheckUri = '/api/Test/CheckFormRender';
        this.componentInfo2 = componentInfo;
    }

    public testLoadModule(): void {

        let that = this;
        let Info = new DynamicComponentInfo();
        Info.ComponentName = 'UserMessageBoxForm';
        Info.ModuleName = 'KullaniciMesajlariModule';
        Info.ModulePath = '/Modules/Core_Destek_Modulleri/Kullanici_Mesajlari_Modulu/KullaniciMesajlariModule';

        const jsonString: string =  JSON.stringify(Info);
        const calculatedHash = jsonString.hashCode();

        (<any>window).System.import(Info.ModulePath)
            .then((module: any) => {
                let modx = module[Info.ModuleName];
                return modx;
            })
            .then((type: any) => {
                let res = that.compiler.compileModuleAndAllComponentsAsync(type);
                return res;
            })
            .then((moduleWithFactories: ModuleWithComponentFactories<any>) => {
                const factory = moduleWithFactories.componentFactories.find(x => x.componentType.name === Info.ComponentName);
                console.log(factory);
            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public testBoundFormDispose() {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'ConvTestForm';
        componentInfo.ModuleName = 'TestModule';
        componentInfo.ModulePath = '/Modules/Core_Destek_Modulleri/Test_Modulu/TestModule';
        this.componentInfo3 = componentInfo;
    }

    testMhrsExceptionalForm() {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'MHRSExceptionalForm';
        componentInfo.ModuleName = 'MHRSExceptionalModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Randevu_Modulu/MHRSExceptionalModule';
        this.componentInfo3 = componentInfo;
    }

    public testDynamicForm(): void {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'ZForm2';
        componentInfo.ModuleName = 'TestModule';
        componentInfo.ModulePath = 'Modules/Core_Destek_Modulleri/Test_Modulu/TestModule';
        componentInfo.objectID = "12eca5ea-bae7-48c4-bf8e-90ce523fd8ce";



        /*componentInfo.ComponentName = "SupplyRqstPlDetailForm";
        componentInfo.ModuleName = "SatinalmaIstekModule";
        componentInfo.ModulePath = "/Modules/Saglik_Lojistik/Satinalma_Modulleri/Satinalma_Istek_Modulu/SatinalmaIstekModule"; */
        this.componentInfo3 = componentInfo;
    }

}
