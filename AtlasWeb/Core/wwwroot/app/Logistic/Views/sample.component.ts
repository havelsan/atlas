import { Component } from '@angular/core';

@Component({
    selector: "comp-sample",
    template: `
<h1>Sample Component</h1>
<hr/>
{{ObjectID}}
`
})
export class SampleComponent  {
    public ObjectID: string;
}