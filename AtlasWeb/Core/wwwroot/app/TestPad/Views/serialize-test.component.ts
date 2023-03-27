import { Component } from '@angular/core';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { deserialize, plainToClass, classToPlain, getClassType, getClassTypeWithObjectDefID } from 'NebulaClient/ClassTransformer';
import { SerializeTest } from '../Models/SerializeTestModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ChattelDocumentInputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { CurrencyTestModel } from '../Models/CurrencyTestModel';
import { PatientExamination } from 'NebulaClient/Model/AtlasClientModel';
import { NeSerializer } from 'NebulaClient/ClassTransformer/NeSerializer';
import { ParentEntity } from '../Models/ParentEntity';
import { ChildEntity } from '../Models/ChildEntity';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { UserHelper } from '../../Helper/UserHelper';
import { HttpClient, HttpHeaders } from "@angular/common/http";

const OriginalValuesPropertyName = 'OriginalValues';

@Component({
    selector: 'serialize-test-component',
    template: `
<h2>Object Serialization</h2>

<div class="row">
<div class="col-lg-4"><dx-button text="Send Binary Data" (onClick)="sendBinaryData()"></dx-button></div>
<div class="col-lg-8">
        Select file: <input type="file" (change)="onChange($event)">
    </div>
</div>

<div class="row">
<div class="col-lg-7"><h4>Plain to class Test</h4></div>
<div class="col-lg-3"><dx-button text="Plain to class test" (onClick)="plainToClassTest()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>hasta nesnesi değişti mi kontrol edilecek</h4></div>
    <div class="col-lg-3"><dx-button text="Get Patient" (onClick)="loadSamplePatientForModifiedTest()"></dx-button></div>
    <div class="col-lg-3">&nbsp;</div>
</div>


<div class="row">
    <div class="col-lg-7"><h4>Örnek hasta nesnesi al</h4></div>
    <div class="col-lg-3"><dx-button text="Get Sample Patient" (onClick)="loadSamplePatient()"></dx-button></div>
    <div class="col-lg-3"><dx-button text="Post Sample Patient" (onClick)="postSamplePatient()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Basit resource nesnesi al</h4></div>
    <div class="col-lg-3"><dx-button text="Get Basic Resource" (onClick)="getBasicResoruce()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>TTObject'den türemiş resource nesnesi al</h4></div>
    <div class="col-lg-3"><dx-button text="Get Derived Resource" (onClick)="getTTObjectDerivedResoruce()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Private bir özellik için Expose Denemesi</h4></div>
    <div class="col-lg-3"><dx-button text="Get Resource With Expose" (onClick)="getResourceWithExpose()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Diğer bir nesnesyi içeren resource nesnesi al</h4></div>
    <div class="col-lg-3"><dx-button text="Get Resource" (onClick)="getResource()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Resource nesnesi için ChildRelation yükle (ResourceSpecialities)</h4></div>
    <div class="col-lg-3"><dx-button text="Get Resource ChildRelation" (onClick)="getResourceSpecialities()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Resource Nesnesi Type bilgisi içeren</h4></div>
    <div class="col-lg-3"><dx-button text="Get Resource With Type" (onClick)="getResourceWithType()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Taşınır nesnesi ile base class türünde serialize</h4></div>
    <div class="col-lg-3"><dx-button text="Serialize Test With Base Type" (onClick)="serializeTestWithBaseType()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Taşınır nesnesi ile $type olmadan serialize</h4></div>
    <div class="col-lg-3"><dx-button text="Serialize Test Without TypeName" (onClick)="serializeTestWithoutTypeName()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Örnek Taşınır nesnesi JSON sunucudan al</h4></div>
    <div class="col-lg-3"><dx-button text="Get Sample ChattelDocumentInputWithAccountancy" (onClick)="getSampleJson()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Currency serialize test</h4></div>
    <div class="col-lg-3"><dx-button text="Post currency type" (onClick)="postCurrencyType()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>RTF serialize test</h4></div>
    <div class="col-lg-3"><dx-button text="Post RTF type" (onClick)="postRtfType()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>RTF load test</h4></div>
    <div class="col-lg-3"><dx-button text="Post RTF type" (onClick)="getRtfType()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Date Serialization Test</h4></div>
    <div class="col-lg-3"><dx-button text="Test Date Serialization" (onClick)="testDateSerialization()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Query Parameters Serialization Test</h4></div>
    <div class="col-lg-3"><dx-button text="Test query Parameter Dictionary Serialization" (onClick)="testQueryParamsSerialization()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Test TTObjectState test </h4></div>
    <div class="col-lg-3"><dx-button text="Test ObjectState Post" (onClick)="testObjectStatePost()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-3"><dx-button text="Tarih Al" (click)="tarihAl()"></dx-button></div>
    <div class="col-lg-3"><dx-button text="Tarih Gönder" (click)="tarihGonder()"></dx-button></div>
    <div class="col-lg-6">  <dx-date-box
                [(value)]="DateTimeTest.dateValue"
                type="datetime">
            </dx-date-box></div>
</div>

<div class="row">
    <div class="col-lg-7"><h4>Test Circular Reference </h4></div>
    <div class="col-lg-3"><dx-button text="Test Circular Reference" (onClick)="testCircularReference()"></dx-button></div>
</div>

<div class="row">
<div class="col-lg-7"><h4>Load user resources</h4></div>
<div class="col-lg-3"><dx-button text="Load User Resources" (onClick)="loadUserResources()"></dx-button></div>
</div>



`
})
export class SerializeTestComponent {


    private static SampleJsonWithType: string = `{
    "$type": "TTObjectClasses.ChattelDocumentInputWithAccountancy, TTLogisticsAssembly",
    "ObjectDefID": "1c5c4fc6-72e8-4c58-8d6a-21e17d1eacf3",
    "ObjectID": "dde3120a-b60d-40b4-b9df-1826f7021b45",
    "CurrentStateDefID": "b74d6c04-3830-4382-93fd-c41c37d6a56d",
    "ActionDate": "2016-12-14T15:00:16",
    "Cancelled": 0,
    "Active": 0,
    "WorkListDate": "2016-12-14T15:03:39",
    "ID": 155033,
    "TransactionDate": "2016-12-14T15:00:16",
    "StockActionID": 35460,
    "AdditionalDocumentCount": 33,
    "GrandTotal": 0.0,
    "TotalPrice": 0.0,
    "MKYS_EAlimYontemi": 0,
    "MKYS_ETedarikTuru": 0,
    "MKYS_EMalzemeGrup": 0,
    "AccountingTerm": "778acbe7-1caf-49f6-8ca6-0127fcfa89c1",
    "Store": "b5b31a04-67e8-4e27-a68f-6617eced5a87",
    "Accountancy": "42f71d25-286c-49d4-a1d6-dd1edf52f22a"
}`;

    private static SampleJsonWithoutType: string = `{
    "ObjectDefID": "1c5c4fc6-72e8-4c58-8d6a-21e17d1eacf3",
    "ObjectID": "dde3120a-b60d-40b4-b9df-1826f7021b45",
    "CurrentStateDefID": "b74d6c04-3830-4382-93fd-c41c37d6a56d",
    "ActionDate": "2016-12-14T15:00:16",
    "Cancelled": 0,
    "Active": 0,
    "WorkListDate": "2016-12-14T15:03:39",
    "ID": 155033,
    "TransactionDate": "2016-12-14T15:00:16",
    "StockActionID": 35460,
    "AdditionalDocumentCount": 33,
    "GrandTotal": 0.0,
    "TotalPrice": 0.0,
    "MKYS_EAlimYontemi": 0,
    "MKYS_ETedarikTuru": 0,
    "MKYS_EMalzemeGrup": 0,
    "AccountingTerm": "778acbe7-1caf-49f6-8ca6-0127fcfa89c1",
    "Store": "b5b31a04-67e8-4e27-a68f-6617eced5a87",
    "Accountancy": "42f71d25-286c-49d4-a1d6-dd1edf52f22a"
}`;

    private _patient: Patient;
    private _viewModel: any;

    private uploadFileName: string;
    private fileContent: any;

    public DateTimeTest: SerializeTest.DateTimeTestInput;

    constructor(private httpService: NeHttpService, private http: HttpClient) {
        this.DateTimeTest = new SerializeTest.DateTimeTestInput();
    }

    public async getBasicResoruce() {
        let objectID: Guid = new Guid('a9135cc7-f507-4e6c-98d1-41d562c6dc0d');
        const testGuidEmpty = Guid.Empty;

        console.log(Guid.Empty.valueOf() === objectID.valueOf());
        console.log(Guid.Empty.valueOf() === testGuidEmpty.valueOf());

        let objectDefID: Guid = new Guid('fbcf3da3-a1fb-4dad-96fe-07d23230e9f5');
        let json = await ServiceLocator.getObject(objectID, objectDefID);
        let testInstance: SerializeTest.ResourceBasic = plainToClass(SerializeTest.ResourceBasic, json);
        console.log(testInstance);
        console.log(testInstance.toString());
        let check = testInstance instanceof SerializeTest.ResourceBasic;
        console.log(check);
    }

    public async getTTObjectDerivedResoruce() {
        let objectID: Guid = new Guid('a9135cc7-f507-4e6c-98d1-41d562c6dc0d');
        let objectDefID: Guid = new Guid('fbcf3da3-a1fb-4dad-96fe-07d23230e9f5');
        let json = await ServiceLocator.getObject(objectID, objectDefID);
        let testInstance: SerializeTest.ResourceDerived = plainToClass(SerializeTest.ResourceDerived, json);
        console.log(testInstance);
        console.log(testInstance.toString());
        let check = testInstance instanceof SerializeTest.ResourceDerived;
        console.log(check);
    }

    public async getResourceWithExpose() {
        let objectID: Guid = new Guid('a9135cc7-f507-4e6c-98d1-41d562c6dc0d');
        let objectDefID: Guid = new Guid('fbcf3da3-a1fb-4dad-96fe-07d23230e9f5');
        let json = await ServiceLocator.getObject(objectID, objectDefID);
        let testInstance: SerializeTest.ResourceWithExpose = plainToClass(SerializeTest.ResourceWithExpose, json);
        console.log(testInstance);
        console.log(testInstance.toString());
        let check = testInstance instanceof SerializeTest.ResourceWithExpose;
        console.log(check);

        console.log(testInstance._store);
    }

    public async getResourceSpecialities() {

        let objectID: Guid = new Guid('8c48d1ad-016c-491b-8c6a-13deab25c412');
        let objectDefID: Guid = new Guid('55df754b-9d32-4df9-a983-4d18b38bf044');
        let json = await ServiceLocator.getObject(objectID, objectDefID);
        let testInstance: SerializeTest.Resource = plainToClass(SerializeTest.Resource, json);
        console.log(testInstance);
        console.log(testInstance.toString());
        let check = testInstance instanceof SerializeTest.Resource;
        console.log(check);

        let resourceSpecialities = await testInstance.loadResourceSpecialities();
        console.log(resourceSpecialities.length);

        for (let gridItem of testInstance._resourceSpecialities) {
            console.log(gridItem.ObjectID);
        }
    }

    public async getResource() {
        let objectID: Guid = new Guid('8c48d1ad-016c-491b-8c6a-13deab25c412');
        let objectDefID: Guid = new Guid('55df754b-9d32-4df9-a983-4d18b38bf044');
        let json = await ServiceLocator.getObject(objectID, objectDefID);
        let testInstance: SerializeTest.Resource = plainToClass(SerializeTest.Resource, json);
        console.log(testInstance);
        console.log(testInstance.toString());
        let check = testInstance instanceof SerializeTest.Resource;
        console.log(check);

        let store1 = await testInstance.loadStore();
        if (store1 != null) {
            console.log(store1.Name);
            console.log(testInstance._store.Name);
        }

        let storeTypeName = typeof SerializeTest.Store;
        console.log(storeTypeName);
        let storeConstructorTypeName = typeof SerializeTest.Store.constructor;
        console.log(storeConstructorTypeName);

        // ikinci istekte sunucuya gitmez
        // promise sadece bir kez resolve edilebilir
        let store2 = await testInstance.loadStore();
        if (store2 != null) {
            console.log(store2.Name);
        }

        let newJson = classToPlain(testInstance);
        console.log(newJson);

        let store3 = new SerializeTest.Store();
        store3.ObjectID = Guid.newGuid();
        store3.Name = 'Store3';

        testInstance._store = store3;
        let json2 = JSON.stringify(testInstance);
        console.log(json2);

        let str1 = NeSerializer.stringify(testInstance);
        console.log(str1);

        let target = classToPlain(testInstance);
        let str2 = NeSerializer.stringify(target);
        console.log(str2);

    }


    public getResourceWithType() {

        let testInstance: SerializeTest.ResourceBasic = new SerializeTest.ResourceBasic();
        testInstance.ID = 1;
        testInstance.Name = 'sşladkşaldkşa';
        testInstance.Name_Shadow = 'SŞLADKŞALDKŞA';
        testInstance.Qref = 'QREF';

        let plainObject = classToPlain(testInstance);
        plainObject['$type'] = 'SerializeTest.ResourceBasic';
        let stringJson = JSON.stringify(plainObject);
        console.log(stringJson);
    }

    public serializeTestWithBaseType() {
        let instance = new ChattelDocumentInputWithAccountancy();
        instance.ObjectID = new Guid('dde3120a-b60d-40b4-b9df-1826f7021b45');
        instance.CurrentStateDefID = new Guid('b74d6c04-3830-4382-93fd-c41c37d6a56d');
        instance.ActionDate = new Date(2016, 12, 14, 15, 3, 39, 0);

        let newInstance: any = {};
        newInstance['$type'] = 'TTObjectClasses.ChattelDocumentInputWithAccountancy, TTLogisticsAssembly';
        Object.assign(newInstance, instance);
        newInstance.Accountancy = '42f71d25-286c-49d4-a1d6-dd1edf52f22a';
        newInstance.AccountingTerm = '778acbe7-1caf-49f6-8ca6-0127fcfa89c1';
        console.log(newInstance);

        let itemInstance = JSON.parse(SerializeTestComponent.SampleJsonWithType);
        let url = 'api/ObjectContext/SerializeWithBaseType';
        ServiceLocator.NeHttpService.post(url, itemInstance);
    }

    public serializeTestWithoutTypeName() {

        let x: SerializeTest.Resource = new SerializeTest.Resource();
        x.ID = 1;
        x.Name = 'Resource';
        x.Name_Shadow = 'RESOURCE';
        x.ObjectID = Guid.newGuid();
        x.ObjectDefID = Guid.newGuid();

        console.log(x.toJSON());

        let stringResult1 = JSON.stringify(x);
        console.log(stringResult1);
        let y = classToPlain(x);
        let stringResult2 = JSON.stringify(y);
        console.log(stringResult2);
        let itemInstance = JSON.parse(SerializeTestComponent.SampleJsonWithoutType);
        let url = 'api/ObjectContext/SerializeWithoutType';
        ServiceLocator.NeHttpService.post(url, itemInstance);
    }

    public getSampleJson() {
        let url = 'api/ObjectContext/GetTestObject';
        ServiceLocator.NeHttpService.get(url).then(response => {
            let jsonResult = response;
            console.log(jsonResult);
        });
    }

    public postCurrencyType(): void {
        let url = 'api/ObjectContext/CurrencyTest';
        let model = new CurrencyTestModel();
        model.Toplam = 1245;
        model.GenelToplam = 986;

        this.httpService.post(url, model);
    }

    public postRtfType(): void {
        let url = 'api/ObjectContext/RtfTest';
        let model = new PatientExamination();
        model.ObjectID = Guid.newGuid();
        model.ObjectDefID = PatientExamination.ObjectDefID;
        model.Complaint = '<p>Single paragraph</p>';
        this.httpService.post(url, model);
    }

    public getRtfType(): void {
        let url = 'api/ObjectContext/RtfTestGet';
        this.httpService.get(url).then(r => {
            let patExam = r as PatientExamination;
            console.log(patExam.Complaint);
            console.log('OK');
        });
    }

    public testDateSerialization(): void {
        let url = 'api/Test/LoadDateSample';
        this.httpService.get<SerializeTest.DateSerializationSampleDto>(url).then(r => {
            let deserialized = plainToClass(SerializeTest.DateSerializationSampleDto, r);
            console.log(deserialized);
            console.log('OK');
        });
    }

    public testQueryParamsSerialization(): void {
        let url = 'api/Test/TestObjectDictionary';
        let queryParams = {};
        //queryParams['DEGER1'] = new BooleanParam(true);
        //queryParams['DEGER2'] = new DateParam(new Date());
        //queryParams['DEGER3'] = new DecimalParam(1.25);
        //queryParams['DEGER4'] = new GuidParam(Guid.newGuid());
        //queryParams['DEGER5'] = new IntegerParam(75);
        //queryParams['DEGER6'] = new StringParam('adkjfadşlsfkasdf');

        this.httpService.post(url, queryParams).then(r => {
            console.log('OK');
        });
    }

    public testObjectStatePost(): void {
        //queryParams['DEGER1'] = new BooleanParam(true);
        //queryParams['DEGER2'] = new DateParam(new Date());
        //queryParams['DEGER3'] = new DecimalParam(1.25);
        //queryParams['DEGER4'] = new GuidParam(Guid.newGuid());
        //queryParams['DEGER5'] = new IntegerParam(75);
        //queryParams['DEGER6'] = new StringParam('adkjfadşlsfkasdf');
    }

    public tarihAl(): void {
        let url = 'api/Test/DateTimeTestGet';
        let that = this;
        this.httpService.get<SerializeTest.DateTimeTestInput>(url).then(r => {
            let deserialized = plainToClass(SerializeTest.DateTimeTestInput, r);
            that.DateTimeTest = deserialized;
            console.log(deserialized);
            console.log('OK');
        });
    }

    public tarihGonder(): void {
        let url = 'api/Test/DateTimeTestPost';

        let payload = classToPlain(this.DateTimeTest);
        let jsonString1 = JSON.stringify(payload);
        let jsonString2 = NeSerializer.stringify(payload);
        console.log(jsonString1);
        console.log(jsonString2);
        this.httpService.post<SerializeTest.DateTimeTestInput>(url, this.DateTimeTest).then(r => {
            console.log('OK');
        });
    }

    public testCircularReference(): void {
        let child = new ChildEntity();
        child.ID = 1;
        child.Name = 'Child01';
        let parent = new ParentEntity();
        console.log('OK');

        const test1 = getClassTypeWithObjectDefID(Patient.ObjectDefID.toString());
        console.log(test1);

        let constructor = getClassType('ChildEntity');
        let childDyn = Object.create(constructor.prototype) as ChildEntity;
        childDyn.ID = 2;
        childDyn.Name = 'Child02';

        console.log(JSON.stringify(childDyn));
        parent.Children = new Array<ChildEntity>();
        parent.Children.push(child);
        parent.Children.push(childDyn);

        const jsonParent = JSON.stringify(parent);
        console.log(jsonParent);

        const newObj = plainToClass<ParentEntity, {}>(ParentEntity, JSON.parse(jsonParent));
        console.log(newObj);
    }

    public loadSamplePatient() {
        let that = this;
        let url = `api/Test/LoadPatient?objectID=996287d0-8ad8-4661-8991-f434d9c053d0`;
        ServiceLocator.NeHttpService.get(url).then((res: any) => {
            that._viewModel = res;
            that._patient = res._Patient;
            console.log(res);
        });
    }

    private getKeys(object: Object): string[] {
        let keys: any[] = [];
        if (object instanceof Map) {
            keys = Array.from(object.keys());
        } else {
            keys = Object.keys(object);
        }
        return keys;
    }

    private findTTObjects(source: any, objectCache: Map<string, any>): void {

        if (source.hasOwnProperty('ObjectID') && source.hasOwnProperty('ObjectDefID')) {
            const objectID = source['ObjectID'];
            objectCache.set(objectID, source);
        } else {
            const isArray = (Object.prototype.toString.call(source) === '[object Array]');
            if (isArray) {
                const array = source as Array<any>;
                for (let item of array) {
                    this.findTTObjects(item, objectCache);
                }
            } else if (source instanceof Object) {
                const keys = this.getKeys(source);
                for (let key in keys) {
                    if (key === OriginalValuesPropertyName) {
                        continue;
                    }
                    const propertyValue = source[key];
                    if (propertyValue instanceof Object) {
                        this.findTTObjects(propertyValue, objectCache);
                    }
                }
            }
        }
    }

    private isNonEmptyArrayLike(obj) {
        try { // don't bother with `typeof` - just access `length` and `catch`
            return obj.length > 0 && '0' in Object(obj);
        }
        catch (e) {
            return false;
        }
    }

    private updateOriginalValues(viewModel: any, sourceTTObjects: Array<any>) {
        if (this.isNonEmptyArrayLike(sourceTTObjects)) {
            return;
        }

        const objectCache: Map<string, any> = new Map<string, any>();
        this.findTTObjects(viewModel, objectCache);

        for (let sourceTTObject of sourceTTObjects) {
            const objectID = sourceTTObject['ObjectID'];
            const destTTObject = objectCache.get(objectID);
            if (destTTObject) {
                const newOriginalValues: any = Object.create(Object.prototype);
                Object.assign(newOriginalValues, sourceTTObject, sourceTTObject.OriginalValues);
                delete newOriginalValues.OriginalValues;
                destTTObject.OriginalValues = newOriginalValues;
            }
        }
    }

    public postSamplePatient() {
        let url = 'api/Test/UpdatePatient';
        let that = this;
        const httpService = ServiceLocator.NeHttpService;
        this._patient.Name = "YUNUS3";
        let viewModel = that._viewModel;
        httpService.post(url, viewModel).then((res1: any) => {
            console.log('POST Completed');
            that.updateOriginalValues(viewModel, res1.UpdatedObjects);

            that._patient.Name = "YUNUS4";
            let viewModel1 = that._viewModel;
            httpService.post(url, viewModel1).then((res2: any) => {
                console.log('POST Completed');
            });
        });
    }

    public loadUserResources() {
        UserHelper.UserResources.then(res => {
            console.log(res);
        });
    }

    plainToClassTest() {

        const dto = new SerializeTest.DateSerializationSampleDto();
        dto.ID = 1;
        dto.BirthDate = new Date();
        dto.Name = 'Name';
        dto.dateValue = new Date();

        const json = NeSerializer.stringify(dto);

        const dto1 = deserialize<SerializeTest.DateSerializationSampleDto>(SerializeTest.DateSerializationSampleDto, json);

        console.log(dto1);

    }

    onChange($event) {

        let that = this;
        const file: File = $event.target.files[0];
        const fileReader: FileReader = new FileReader();
        const fileType = $event.target.parentElement.id;
        fileReader.onloadend = (e) => {
            that.fileContent = fileReader.result;
            that.uploadFileName = file.name,
                console.log(typeof fileReader.result);
        };

        fileReader.readAsArrayBuffer(file);
    }

    sendBinaryData() {
        if (this.fileContent) {
            let token = sessionStorage.getItem('token');
            const headers = new HttpHeaders()
                .append('Authorization', `Bearer ${token}`);


            const blob = new Blob([new Uint8Array(this.fileContent)], { type: 'application/octet-binary' });
            const formData = new FormData();
            formData.append('Id', '1');
            formData.append('FileName', this.uploadFileName);
            formData.append('FileContent', blob);

            this.http.post('/api/test/SendBinary', formData, { headers: headers }).toPromise().then(r => {
                console.log('Success');
            }).catch(error => {
                console.log(error);
            });
        }
    }

    loadSamplePatientForModifiedTest() {
        let that = this;
        let url = `api/Test/LoadPatient?objectID=996287d0-8ad8-4661-8991-f434d9c053d0`;
        ServiceLocator.NeHttpService.get<any>(url).then((res: any) => {
            console.log(res);
            const pat = res._Patient as Patient;

            const modifiedMemberName = pat.getModifiedMemberName();
            console.log(modifiedMemberName);

            const originalName = pat.Name;

            pat.Name = "123789";

            const isModifiedAfter = pat.getModifiedMemberName();
            console.log(isModifiedAfter);

            pat.Name = originalName;

            const isModifiedAfterRestore = pat.getModifiedMemberName();
            console.log(isModifiedAfterRestore);

        });
    }

}