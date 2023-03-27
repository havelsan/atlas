import {
    NgModule, ApplicationRef, Injector, Compiler, APP_INITIALIZER,
    NgModuleFactoryLoader, SystemJsNgModuleLoader, ErrorHandler
} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpModule, XHRBackend, RequestOptions } from '@angular/http';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HvlApp } from './Fw/Components/HvlApp';
import { FwModule } from './Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { SystemModule } from './System/SystemModule';
import { AuthenticationService } from './System/Services/AuthenticationService';
import { ModalModule, ModalService } from 'Fw/ModalModule';
import { IModalService } from 'Fw/Services/IModalService';
import { NavigationService } from 'Fw/Services/NavigationService';
import { ModalStateService } from 'Fw/Models/ModalInfo';
import { IActivePatientService } from 'Fw/Services/IActivePatientService';
import { IActiveTabService } from 'Fw/Services/IActiveTabService';
import { ActivePatientService } from 'Fw/Services/ActivePatientService';
import { HelpMenuService } from 'Fw/Services/HelpMenuService';
import { EpisodeActionHelper } from 'app/Helper/EpisodeActionHelper';
import { ActiveTabService } from 'Fw/Services/ActiveTabService';
import { IActiveEpisodeService } from 'Fw/Services/IActiveEpisodeService';
import { ActiveEpisodeService } from 'Fw/Services/ActiveEpisodeService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ActiveUserService } from 'Fw/Services/ActiveUserService';
import { IActiveEpisodeActionService } from 'Fw/Services/IActiveEpisodeActionService';
import { ActiveEpisodeActionService } from 'Fw/Services/ActiveEpisodeActionService';
import { AppRoutingModule } from './app-routing.module';
import { ProcedureRequestSharedService } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestSharedService';
import { ConfigurationCacheService } from 'Fw/Services/ConfigurationCacheService';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { SidebarMenuService } from './SidebarMenu/Services/sidebar-menu.service';
import { AtlasModuleLoader } from 'Fw/Services/AtlasModuleLoader';
import { AtlasErrorHandler } from 'Fw/Services/AtlasErrorHandler';
import { IAuthenticationService } from 'Fw/Services/IAuthenticationService';
import { AtlasAuthenticationService } from 'Fw/Services/AtlasAuthenticationService';
import { AtlasAuthGuardService } from 'Fw/Services/AtlasAuthGuardService';
import { CashOfficeAuthGuardService } from 'Fw/Services/CashOfficeAuthGuardService';
import { AtlasAuthModule } from './auth.module';
import { AtlasConfigurationService } from 'Fw/Services/AtlasConfigurationService';
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';
import { EpisodeActionWorkListSharedService } from 'Fw/Services/EpisodeActionWorkListSharedService';
import { EpisodeActionDisplayFormSharedService } from 'Fw/Services/EpisodeActionDisplayFormSharedService';
import { AtlasReportModule } from './Report/AtlasReportModule';
import { LoginModule } from './System/LoginModule';
import { DynamicComponentHostDirective } from 'Fw/Components/DynamicComponentHostDirective';
import { AtlasEditorTemplateModule } from './EditorTemplate/AtlasEditorTemplateModule';
import { AtlasHashService } from 'Fw/Services/AtlasHashService';
import { IHashService } from 'Fw/Services/IHashService';
import { AtlasBarcodePrintService } from './Barcode/Services/AtlasBarcodePrintService';
import { IBarcodePrintService } from './Barcode/Services/IBarcodePrintService';
import { NotificationDevelopmentService } from './Notification/Services/NotificationDevelopmentService';
import { INotificationDevelopmentService } from './Notification/Services/INotificationDevelopmentService';
import { AtlasUnsavedChangesGuardService } from 'Fw/Services/AtlasUnsavedChangesGuardService';
import { AtlasActiveComponentRegistryService } from 'Fw/Services/AtlasActiveComponentRegistryService';
import { IActiveComponentRegistryService } from 'Fw/Services/IActiveComponentRegistryService';
import { IAuditObjectService } from 'Fw/Services/IAuditObjectService';
import { AuditObjectService } from 'Fw/Services/AuditObjectService';
import { AtlasSignalRService } from 'Fw/Services/AtlasSignalRService';
import { IHelpService } from 'Fw/Services/IHelpService';
import { AtlasHelpService } from 'Fw/Services/AtlasHelpService';
import { WindowRef } from 'NebulaClient/Mscorlib/WindowRef';
import { ENabizButtonSharedService } from 'Fw/Services/ENabizButtonSharedService';
import { DentalCommitmentFormSharedService } from 'Fw/Services/DentalCommitmentFormSharedService';
import { LayoutModule } from 'app/template/content/layout/layout.module';
import { CoreModule } from 'app/template/core/core.module';
import { IQuickActionsMenuService } from './Fw/Services/IQuickActionsMenuService';
import { QuickActionsMenuService } from './template/content/layout/header/topbar/quick-action/QuickActionsMenuService';
import { ThemeService } from 'app/Fw/Services/ThemeService';
import { IThemeService } from 'app/Fw/Services/IThemeService';
import './localization';
import { ApiXHRBackend, AtlasHttpInterceptor } from './Fw/Services/HttpInterceptor';
import { IFavoriteService } from 'app/Favorites/IFavoriteService';
import { FavoriteService } from 'app/Favorites/FavoriteService';
import { AngularDraggableModule } from 'angular2-draggable';
import { DevexpressReportingModule } from './DevexpressReporting/DevexpressReportingModule';
import { RequestedProcedureSharedService } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/RequestedProcedureSharedService';
import { FormsModule } from '@angular/forms';
import * as fm from './Formio/forms/forms.module';
import { PrismService } from './Formio/prism/Prism.service';
import * as af from 'angular-formio';
import { MedicalStuffReportSharedService } from 'Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/MedicalStuffReportSharedService';
import { DiagnosisGridSharedService } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridSharedService';
import { SurgeryAppointmentSharedService } from 'Modules/Tibbi_Surec/Ameliyat_Modulu/SurgeryAppointmentSharedService';
af.Formio["Templates"].framework = 'bootstrap3';

export function init(http: AtlasHttpService, configService: AtlasConfigurationService, userService: IActiveUserService) {
    return () => configService.initialize();
}

export function httpFactory(xhrBackend: XHRBackend, requestOptions: RequestOptions) {
    return new AtlasHttpService(xhrBackend, requestOptions);
}


@NgModule({
    declarations: [HvlApp, DynamicComponentHostDirective],
    imports: [
        BrowserModule,
        AtlasAuthModule.forRoot(),
        AppRoutingModule,
        DevExtremeModule,
        ReactiveFormsModule,
        HttpClientModule,
        HttpModule,
        FormsModule,
        BrowserAnimationsModule,
        FwModule,
        LoginModule,
        LayoutModule,
        CoreModule,
        SystemModule,
        ModalModule,
        AtlasReportModule,
        AtlasEditorTemplateModule,
        AngularDraggableModule,
        DevexpressReportingModule,
        fm.FormsModule
    ],
    entryComponents: [HvlApp],
    providers: [
        { provide: XHRBackend, useClass: ApiXHRBackend },
        { provide: HTTP_INTERCEPTORS, useClass: AtlasHttpInterceptor, multi: true },
        {
            provide: AtlasHttpService,
            useFactory: httpFactory,
            deps: [XHRBackend, RequestOptions]
        },
        {
            provide: AtlasHttpService,
            useFactory: httpFactory,
            deps: [XHRBackend, RequestOptions]
        },
        {
            provide: APP_INITIALIZER,
            useFactory: init,
            deps: [AtlasHttpService, AtlasConfigurationService, IActiveUserService],
            multi: true
        },
        ModalStateService, ProcedureRequestSharedService,DiagnosisGridSharedService, SurgeryAppointmentSharedService, AtlasSignalRService
        , NavigationService, AuthenticationService, EpisodeActionHelper
        , HelpMenuService, ConfigurationCacheService, AtlasModuleLoader
        , AtlasUnsavedChangesGuardService, AtlasAuthGuardService, WindowRef
        , CashOfficeAuthGuardService, AtlasConfigurationService, QuickActionsMenuService, ThemeService,
        { provide: NgModuleFactoryLoader, useClass: SystemJsNgModuleLoader },
        { provide: IModalService, useClass: ModalService },
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService },
        { provide: IActivePatientService, useClass: ActivePatientService },
        { provide: IActiveTabService, useClass: ActiveTabService },
        { provide: IActiveEpisodeService, useClass: ActiveEpisodeService },
        { provide: IActiveEpisodeActionService, useClass: ActiveEpisodeActionService },
        { provide: IActiveUserService, useClass: ActiveUserService },
        { provide: IAuthenticationService, useClass: AtlasAuthenticationService },
        { provide: IActiveComponentRegistryService, useClass: AtlasActiveComponentRegistryService },
        { provide: IHelpService, useClass: AtlasHelpService },
        { provide: ISidebarMenuService, useClass: SidebarMenuService },
        { provide: ErrorHandler, useClass: AtlasErrorHandler },
        { provide: EpisodeActionWorkListSharedService, useClass: EpisodeActionWorkListSharedService },
        { provide: EpisodeActionDisplayFormSharedService, useClass: EpisodeActionDisplayFormSharedService },
        { provide: IHashService, useClass: AtlasHashService },
        { provide: INotificationDevelopmentService, useClass: NotificationDevelopmentService },
        { provide: IAuditObjectService, useClass: AuditObjectService },
        { provide: ENabizButtonSharedService, useClass: ENabizButtonSharedService },
        { provide: DentalCommitmentFormSharedService, useClass: DentalCommitmentFormSharedService },
        { provide: RequestedProcedureSharedService, useClass: RequestedProcedureSharedService },
        { provide: MedicalStuffReportSharedService, useClass: MedicalStuffReportSharedService },
        { provide: IQuickActionsMenuService, useClass: QuickActionsMenuService },
        { provide: IThemeService, useClass: ThemeService },
        { provide: IFavoriteService, useClass: FavoriteService },
        PrismService
    ]
})
export class HvlAppModule {
	
    constructor(private configService: AtlasConfigurationService,
        private injector: Injector,
        private compiler: Compiler) {
    }

    ngDoBootstrap(applicationRef: ApplicationRef) {
        ApplicationGlobals.getInstance().compiler = this.compiler;
        ApplicationGlobals.getInstance().injector = this.injector;
        applicationRef.bootstrap(HvlApp);
    }
}
