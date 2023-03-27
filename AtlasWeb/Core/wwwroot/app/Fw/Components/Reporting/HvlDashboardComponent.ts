import { Component, AfterViewInit, ElementRef, OnDestroy } from '@angular/core';
import { DashboardControl, ResourceManager, DashboardPanelExtension } from 'devexpress-dashboard';
import { environment } from 'app/environments/environment';
import DevExpress from "@devexpress/analytics-core";
@Component({
    selector: 'hvl-dashboard',
    templateUrl: './HvlDashboardComponent.html',
    
})

export class HvlDashboardComponent implements AfterViewInit, OnDestroy {
    private dashboardControl: DashboardControl;
    constructor(private element: ElementRef) {
        ResourceManager.embedBundledResources();
        DevExpress.Analytics.Utils.ajaxSetup.ajaxSettings = {
            headers: { 'Authorization': 'Bearer ' + sessionStorage.getItem('token') }
        };
    }
    ngAfterViewInit(): void {
        this.dashboardControl = new DashboardControl(this.element.nativeElement.querySelector(".dashboard-container"), {
            // Specifies a URL where the Web Dashboard's server side is hosted.          
            endpoint: environment.apiRoot + "/api/dashboard",
            workingMode: "Designer",
            ajaxRemoteService: {
                headers: {
                    'Authorization': 'Bearer ' + sessionStorage.getItem('token')
                }
            }
        });

        this.dashboardControl.render();
    }
    ngOnDestroy(): void {
        this.dashboardControl && this.dashboardControl.dispose();
    }
}