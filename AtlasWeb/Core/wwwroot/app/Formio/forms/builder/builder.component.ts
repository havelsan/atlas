import { Component, AfterViewInit, ViewChild, ElementRef, Input, Output, EventEmitter, OnInit, ChangeDetectorRef } from '@angular/core';
import { PrismService } from 'app/Formio/prism/Prism.service';

@Component({
  selector: 'app-builder',
  templateUrl: './builder.component.html',
  styleUrls: ['./builder.component.scss']
})
export class BuilderComponent implements AfterViewInit, OnInit {


  public ready: boolean = false;
  private _JsonTemplate: string;
  @Input() set JsonTemplate(value: string) {
    this._JsonTemplate = value;
  }
  get JsonTemplate(): string {
    return this._JsonTemplate;
  }

  @Output() OnChange = new EventEmitter<any>();

  @ViewChild('json') jsonElement?: ElementRef;
  @ViewChild('code') codeElement?: ElementRef;
  public form: Object;
  constructor(public prism: PrismService, private changeDetectorRef: ChangeDetectorRef) {

    this.form = { components: [] };
  }


  onChange(event) {

    this.setJsonToTextbox(event.form);
    this.OnChange.emit(event.form);

  }

  setJsonToTextbox(form: any) {

    this.jsonElement.nativeElement.innerHTML = '';
    this.jsonElement.nativeElement.appendChild(document.createTextNode(JSON.stringify(form, null, 4)));
    this.prism.init();
  }
  ngOnInit(): void {

  }
  ngAfterViewInit() {

    if (this.JsonTemplate) {
      let form = JSON.parse(this.JsonTemplate);
      this.setJsonToTextbox(form);

      this.form = form;
    }

    this.ready = true;
    this.changeDetectorRef.detectChanges();
    this.prism.init();
  }
}
