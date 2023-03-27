import { Component, AfterViewInit, Input } from '@angular/core';
import { PrismService } from 'app/Formio/prism/Prism.service';

@Component({
  selector: 'app-renderer',
  templateUrl: './renderer.component.html',
  styleUrls: ['./renderer.component.scss']
})
export class RendererComponent implements AfterViewInit {
  private _JsonTemplate: string;
  form: any;
  @Input() set JsonTemplate(value: string) {
    this._JsonTemplate = value;
  }
  get JsonTemplate(): string {
    return this._JsonTemplate;
  }
  constructor(public prism: PrismService) { }
  ngAfterViewInit() {
    this.prism.init();

    if (this.JsonTemplate) {
      let form = JSON.parse(this.JsonTemplate);
    
      this.form = form;
    }
  }

}
