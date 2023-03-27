
import { Component, AfterViewInit } from '@angular/core';

import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";

@Component({
    selector: "sendtoenabiztestform",
    templateUrl: './SendToENabizTestForm.html',
})
export class SendToENabizTestForm extends BaseComponent<any> implements AfterViewInit {
    showDatePicker = false;
    _selectedDate: Date;

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    packageCount: number = 0;



    constructor(protected http: NeHttpService, services: ServiceContainer) {
        super(services);
    }

    ngAfterViewInit(): void {

    }


    onSend101()
    {

        this.http.post('api/SendToENabizTestService/Send101', '');
    }

    onSend102() {

        this.http.post('api/SendToENabizTestService/Send102', '');
    }

    onSend103() {

        this.http.post('api/SendToENabizTestService/Send103', '');
    }

    onSend105() {

        this.http.post('api/SendToENabizTestService/Send105', '');
    }

    onSend407() {

        this.http.post('api/SendToENabizTestService/Send407', '');
    }
  onSend219() {

        this.http.post('api/SendToENabizTestService/Send219', '');
    }

  onSend106() {

      this.http.post('api/SendToENabizTestService/Send106', '');
  }

  onSend215() {

      this.http.post('api/SendToENabizTestService/Send215', '');
  }

  onSend235() {

      this.http.post('api/SendToENabizTestService/Send235', '');
  }
  onSend302() {

      this.http.post('api/SendToENabizTestService/Send302', '');
  }

  onSend301() {

      this.http.post('api/SendToENabizTestService/Send301', '');
  }

  onSend201() {

      this.http.post('api/SendToENabizTestService/Send201', '');
  }
  onSend250() {
      this.http.post('api/SendToENabizTestService/Send250', '');
  }
  onSend214() {
      this.http.post('api/SendToENabizTestService/Send214', '');
  }
  onSend200() {
      this.http.post('api/SendToENabizTestService/Send200', '');
  }
  onSend104() {
      this.http.post('api/SendToENabizTestService/Send104', '');
  }

  onSend226() {
      this.http.post('api/SendToENabizTestService/Send226', '');
  }

  onSend409() {
      this.http.post('api/SendToENabizTestService/Send409', '');
  }

  onSend203() {
      this.http.post('api/SendToENabizTestService/Send203', '');
  }



  onSend901() {

      this.showDatePicker = true;


  }


  onSelectDate()
  {

      this.http.get("api/SendToENabizTestService/Send901?Date=" + this._selectedDate)
          .then(response => {

          })
          .catch(error => {


          });

  }
}