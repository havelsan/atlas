//$26B487F3
import { Component } from '@angular/core';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { WindowRef } from 'NebulaClient/Mscorlib/WindowRef';

@Component({
    selector: 'show-message-test-component',
    template: `
    <h1>Server Side Message Test</h1>
<dx-button text="Server Side InfoBox Test" (onClick)="testInfoBox()"></dx-button>

<br/><code>{{EchoResult}}</code>
<br/><code>{{InfoBoxMessage}}</code>

<dx-button text="Show Modal" (onClick)="showModal()"></dx-button>

<dx-button text="GoTo Doctor Performance Site" (onClick)="showDpSite()"></dx-button>

<dx-button text="Show Help" (onClick)="showHelp()"></dx-button>

    `,
    providers: [WindowRef]
})
export class ShowMessageTestComponent {
    public InfoBoxMessage: string;
    public EchoResult: string;

    constructor(private http: NeHttpService, private winRef: WindowRef) {
    }


    public testInfoBox() {
        let that = this;
        const url = '/api/Test/Echo?message=OK';
        this.http.get(url).then(response => {
            that.EchoResult = response.toString();
        });
    }

    public showModal() {

        let textValue = ` Lorem Ipsum, dizgi ve baskı\r\n endüstrisinde kullanılan mıgır metinlerdir.\r\n
         Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı
          oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden
          beri endüstri standardı sahte metinler olarak kullanılmıştır.<br/>
          Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.
           1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker
            gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.`;

        TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n('M23735', 'Uyarı'), i18n('M20964', 'Reçete Türü'), textValue).then(r => {
            console.log('OK');
        });
    }

    public showDpSite(): void {
        const url = 'http://localhost:83/doctorperformance';

        let token = sessionStorage.getItem('token');
        if (token) {
            localStorage.setItem('dp-token', token);
        }

        const newWindow = window.open(url);

        if (newWindow) {
            newWindow.sessionStorage.setItem('token', token);
            localStorage.setItem('dp-token', token);
            newWindow.postMessage(token, '*');

            console.log('message sent');

            // newWindow.postMessage(token, "http://localhost:83");
        }

    }

    public showHelp(): void {
        const nativeWindow = this.winRef.getNativeWindow();
        nativeWindow.open('/Help/PatientAdmission.html');
    }

}
