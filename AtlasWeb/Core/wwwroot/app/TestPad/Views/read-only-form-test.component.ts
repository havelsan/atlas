import { Component, ComponentRef } from '@angular/core';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { TTFormBase } from 'NebulaClient/Visual/TTFormBase';

@Component({
    selector: 'read-only-form-test',
    template: `<h1>Readonly Form Test</h1>
    <button (click)="showForm()">Show Form</button>
    <button (click)="setFormReadonly()">Set Form Readonly</button>
    <button (click)="setFormWritable()">Set Form Writable</button>
    <button (click)="toggleSaveAndCloseButton()">Toggle Save And Close Button</button>
<comp-compose [SaveAndCloseCommandVisible]="_saveAndCloseCommandVisible" [Info]="_componentInfo" (ComponentCreated)="dynamicComponentCreated($event)"></comp-compose>
    `,
})
export class ReadOnlyFormTestComponent {

    public _formInstance: any;
    public _componentInfo: DynamicComponentInfo;
    public _saveAndCloseCommandVisible: boolean = false;

    showForm() {
        let compInfo = new DynamicComponentInfo();
        compInfo.ComponentName = 'ChattelDocumentInputWithAccountancyNewForm';
        compInfo.ModuleName = 'TasinirMalIslemModule';
        compInfo.ModulePath = 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/TasinirMalIslemModule';
        compInfo.InputParam = null;
        compInfo.objectID = null; 
        this._componentInfo = compInfo;
    }

    dynamicComponentCreated(compRef: ComponentRef<any>) {
        this._formInstance = compRef.instance;
    }

    toggleSaveAndCloseButton() {
        this._saveAndCloseCommandVisible = !this._saveAndCloseCommandVisible;
    }

    setFormReadonly() {
        if ( this._formInstance != null )  {
            let formBase = this._formInstance as TTFormBase;
            formBase.ReadOnly = true;
        }
    }

    setFormWritable() {
        if ( this._formInstance != null )  {
            let formBase = this._formInstance as TTFormBase;
            formBase.ReadOnly = false;
        }
    }

}