import { Component } from '@angular/core';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';

@Component({
    selector: 'object-test-component',
    template: `<h1>Object Test Module</h1>`,
})
export class ObjectTestComponent {
    private episodeAction: EpisodeAction;
    // private episodeAccountAction: EpisodeAccountAction;
    // private packageTransfer: PackageTransfer;
    constructor() {
        this.episodeAction = new EpisodeAction();
        // this.episodeAccountAction = new EpisodeAccountAction();
        // this.packageTransfer = new PackageTransfer();
    }
}