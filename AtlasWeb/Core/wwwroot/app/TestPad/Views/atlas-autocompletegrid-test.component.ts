import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Component, OnInit } from '@angular/core';
import { Headers, Response, Http, RequestOptions } from "@angular/http";
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ExtendExpDateApprovalFormViewModel } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Miad_Uzatim_Modulu/ExtendExpDateApprovalFormViewModel';
import { AutoCompleteMode } from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';
import {Observable} from "rxjs";
import { map } from 'rxjs/operators'

@Component({
    selector: 'atlas-autocompletegrid-test-component',
    template: `<h1>Hello </h1>

    <hvl-list-box [DefinitionName]="'MaterialListDefinition'" [Enabled]="true" [ReadOnly]="false" [ListFilterExpression]="''"
    [PopupDialogGridColumns]='Columns' [DisplayExpressionsCache]="extendExpDateNewFormViewModel?.ListDefDisplayExpressions"
    [AutoCompleteMode]="autoCompleteMode"
    [SelectedObject]="extendExpDateNewFormViewModel?.Materials[0]"
    ></hvl-list-box>

    <form [formGroup]="messageForm" novalidate (ngSubmit)="send()">
    <h3>Profile Settings</h3>
    <div class="dx-fieldset">

        <div class="dx-field">
            <div class="dx-field-label">First Name:</div>
            <dx-text-box formControlName="firstName" class="dx-field-value" value="John"></dx-text-box>
        </div>
        <div class="dx-field">
            <div class="dx-field-label">Last Name:</div>
            <dx-text-box formControlName="lastName" class="dx-field-value" value="Smith"></dx-text-box>
        </div>
    </div>
    <div id="fileuploader-container">
        <dx-file-uploader formControlName="attachment" selectButtonText="Select photo" labelText="" accept="image/*" uploadMode="useForm">
        </dx-file-uploader>
    </div>
    <input type="hidden" formControlName="eMail" />
    <button type="submit">Send</button>
</form>



    `,
})
export class AtlasAutoCompleteGridTestComponent implements OnInit {
    private ExtendExpDateApprovalForm_DocumentUrl: string = '/api/ExtendExpirationDateService/ExtendExpDateApprovalForm';
    public extendExpDateNewFormViewModel: ExtendExpDateApprovalFormViewModel = new ExtendExpDateApprovalFormViewModel();

    public messageForm: FormGroup;

    ID: string = Guid.empty().toString();
    eMail: string = 'my@my.com';

    form: FormGroup;

    public Columns: [
        {
            dataField: 'GeneratedDisplayExpression',
            width: '100%',
            caption: 'Name90213kj',
        }
    ];

    public autoCompleteMode: AutoCompleteMode = AutoCompleteMode.List;

    constructor(private formBuilder: FormBuilder, private http: NeHttpService, private http2: Http) {
    }

    public ngOnInit() {

        this.messageForm = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            eMail: new FormControl(),
            attachment: new FormControl()
        });

        /*let that = this;
        const uri = `${this.ExtendExpDateApprovalForm_DocumentUrl}/3cf8a224-182f-4714-8f35-fc4a4a429e98`;
        this.http.get<ExtendExpDateApprovalFormViewModel>(uri).then(result => {
            that.extendExpDateNewFormViewModel = result;
        }).catch(error => {
            console.log(error);
        }); */
    }


    updateClick(e) {
        alert('Uncomment the line to enable sending a form to the server.", "Click Handler');
        const action: string = "/api/Test/FileSelection";
        const value = this.form.value;
        this.http.post(action, value).then(x => {
            console.log('ok');
        }).catch(err => {
            console.log(err);
        });
    }

    public sendMessage(newMessage) {
        let sendMessagePath = 'api/Test/Upload';
        let data = new FormData();
        let frm: any  = this.messageForm;
        data.append('file', frm.controls.attachment.value[0]);
        data.append('firstName', this.messageForm.value.firstName);
        data.append('lastName', this.messageForm.value.lastName);
        data.append('eMail', this.messageForm.value.eMail);
        const options = new RequestOptions();
        options.headers = this.getHeaders();
        return this.http2.post(sendMessagePath, data, options)
          .pipe(map((res: Response) => {
            console.log(res);
       }))

      }
      private handleError (error: any) {
        let errorMsg = error.message || ` Problem in Messages retrieving`;
        console.error(errorMsg);
        return Observable.throw(errorMsg);
      }

      private getHeaders(){
        let token = sessionStorage.getItem('token');
        let headers = new Headers();
        headers.append('Accept', 'application/json');
        headers.append('Authorization', `Bearer ${token}`);
        return headers;
      }


}


