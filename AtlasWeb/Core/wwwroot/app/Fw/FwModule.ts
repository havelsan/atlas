import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Http, XHRBackend, RequestOptions } from '@angular/http';
import { HvlTabControl } from './Components/Tabs/HvlTabControl';
import { HvlTabPage } from './Components/Tabs/HvlTabPage';
import { HvlDatePicker } from './Components/HvlDatePicker';
import { HvlListBox } from './Components/HvlListBox';
import { HvlValueListBox } from './Components/HvlValueListBox';
import { HvlMaskTextBox } from './Components/HvlMaskTextBox';
import { HvlGroupBox } from './Components/HvlGroupBox';
import { HvlMenu } from './Components/HvlMenu';
import { HvlNumberBox } from './Components/HvlNumberBox';
import { AtlasRichTextBox } from './Components/AtlasRichTextBox';
import { HvlTab } from './Components/HvlTab';
import { HvlTabPanel } from './Components/HvlTabPanel';
import { HvlTextBox } from './Components/HvlTextBox';
import { ComposeComponent } from './Components/ComposeComponent';
import { HvlSliderPanel } from './Components/HvlSlider';
import { HvlButton } from './Components/HvlButton';
import { HvlCheckBox } from './Components/HvlCheckBox';
import { HvlCheckBoxImage } from './Components/HvlCheckBoxImage';
import { HvlListDefComboBox } from './Components/HvlListDefComboBox';
import { HvlEnumComboBox } from './Components/HvlEnumComboBox';
import { HvlComboBox } from './Components/HvlComboBox';
import { HvlMultiSearchPanel } from './Components/HvlMultiSearchPanel';
import { HvlDataGrid } from './Components/HvlDataGrid';
import { HvlRadioButtonGroup } from './Components/HvlRadioButtonGroup';
import { HvlListView } from './Components/HvlListView';
import { HvlDialog } from './Components/HvlDialog';
import { HvlAutoCompleteGrid } from './Components/HvlAutoCompleteGrid';
import { ServiceContainer } from './Services/ServiceContainer';
import { NotificationService } from './Services/NotificationService';
import { DockPanelService } from './Services/DockPanelService';
import { GlobalsService } from './Services/GlobalsService';
import { TypeCacheService } from './Services/TypeCacheService';
import { HvlHttp } from './Services/HvlHttp';
import { ArrayFilterPipe } from './Pipes/ArrayFilterPipe';
import { DebugPipe } from './Pipes/DebugPipe';
import { SafePipe } from './Pipes/SafePipe';
import { ListSelectionPipe } from './Pipes/ListSelectionPipe';
import { DevExtremeModule } from 'devextreme-angular';
import { NeStatePanelComponent } from './Components/state-panel.component';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { HvlButtonRadioGroup } from './Components/HvlRadioButtonGroup';
import { HvlVerticalButtonRadioGroup } from './Components/HvlRadioButtonGroup';
import { HvlImageRadioGroup } from './Components/HvlRadioButtonGroup';
import { HvlEnumRadio } from './Components/HvlEnumRadioButton';
import { HvlEnumRadioButton } from './Components/HvlEnumRadioButton';
import { HvlEnumVerticalRadioButton } from './Components/HvlEnumRadioButton';
import { HvlEnumImageRadioButton } from './Components/HvlEnumRadioButton';
import { HvlGlaskowButtonRadioGroup } from './Components/HvlRadioButtonGroup';
import { HvlButtonTextBox } from './Components/HvlButtonTextBox';
import { PhotoCapture } from './Components/PhotoCapture';
import { AtlasListDefComponent } from './Components/AtlasListDefComponent';
import { AtlasObjectDefinitionService } from "./Services/AtlasObjectDefinitionService";
import { UserSearchCriteriaPanel } from '../UserSearchCriteriaPanel/UserSearchCriteriaPanel';
import { PhotoCaptureWebcamjsPanel } from './Components/PhotoCaptureWebcamjs';
import { FillHeightDirective } from 'Fw/Directives/fill-height.directive';
import { SummerNoteEditor } from 'Fw/Components/SummerNoteEditor';
import { NgxSummernoteModule } from 'app/SummerNote/public_api';
import { QuickSidebarComponent } from 'app/template/content/partials/layout/quick-sidebar/quick-sidebar.component';
import { CoreModule } from 'app/template/core/core.module';
import { AclService } from 'app/template/core/services/acl.service';
import { LayoutConfigService } from 'app/template/core/services/layout-config.service';
import { LayoutConfigStorageService } from 'app/template/core/services/layout-config-storage.service';
import { LayoutRefService } from 'app/template/core/services/layout/layout-ref.service';
import { MenuConfigService } from 'app/template/core/services/menu-config.service';
import { PageConfigService } from 'app/template/core/services/page-config.service';
import { UserService } from 'app/template/core/services/user.service';
import { UtilsService } from 'app/template/core/services/utils.service';
import { ClassInitService } from 'app/template/core/services/class-init.service';
import { MessengerService } from 'app/template/core/services/messenger.service';
import { ClipboardService } from 'app/template/core/services/clipboard.sevice';
import { LogsService } from 'app/template/core/services/logs.service';
import { QuickSearchService } from 'app/template/core/services/quick-search.service';
import { DataTableService } from 'app/template/core/services/datatable.service';
import { SubheaderService } from 'app/template/core/services/layout/subheader.service';
import { HeaderService } from 'app/template/core/services/layout/header.service';
import { MenuHorizontalService } from 'app/template/core/services/layout/menu-horizontal.service';
import { MenuAsideService } from 'app/template/core/services/layout/menu-aside.service';
import { LayoutModule } from 'app/template/content/layout/layout.module';
import { ENabizButon } from './Components/ENabizButon';
export function httpFactory(xhrBackend: XHRBackend, requestOptions: RequestOptions, container: ServiceContainer, messageService: MessageService) {
    return new HvlHttp(xhrBackend, requestOptions, container, messageService);
}

@NgModule({
    declarations: [
        QuickSidebarComponent, ENabizButon,
        HvlDatePicker, HvlListBox, HvlMaskTextBox, HvlMenu, HvlNumberBox,
        HvlTab, HvlTabPanel, HvlTextBox,
        HvlButton,
        ArrayFilterPipe, DebugPipe, SafePipe, HvlCheckBox, HvlCheckBoxImage, HvlListDefComboBox, HvlEnumComboBox,
        HvlComboBox, HvlDataGrid, HvlGroupBox, HvlMultiSearchPanel, HvlButtonTextBox,
        HvlValueListBox, HvlEnumRadioButton, HvlEnumRadio, HvlEnumVerticalRadioButton, HvlEnumImageRadioButton,
        HvlTabControl, HvlTabPage, HvlSliderPanel,
        ListSelectionPipe, ComposeComponent, NeStatePanelComponent, HvlListView, AtlasRichTextBox, SummerNoteEditor,
        HvlAutoCompleteGrid, HvlRadioButtonGroup, HvlButtonRadioGroup, HvlVerticalButtonRadioGroup,
        HvlImageRadioGroup, HvlDialog, FillHeightDirective, HvlGlaskowButtonRadioGroup, PhotoCapture,
        AtlasListDefComponent, UserSearchCriteriaPanel, PhotoCaptureWebcamjsPanel],
    imports: [CommonModule, FormsModule, ReactiveFormsModule, DevExtremeModule, NgxSummernoteModule, CoreModule, LayoutModule],
    providers: [ServiceContainer, NotificationService, GlobalsService, TypeCacheService,
        NeHttpService, MessageService, ObjectContextService, AtlasObjectDefinitionService, DockPanelService,
        {
            provide: Http, useFactory: httpFactory, deps: [XHRBackend, RequestOptions, ServiceContainer, MessageService]
        },
        AclService,
        LayoutConfigService,
        LayoutConfigStorageService,
        LayoutRefService,
        MenuConfigService,
        PageConfigService,
        UserService,
        UtilsService,
        ClassInitService,
        MessengerService,
        ClipboardService,
        LogsService,
        QuickSearchService,
        DataTableService,
        SubheaderService,
        HeaderService,
        MenuHorizontalService,
        MenuAsideService,],
    exports: [HvlDatePicker, HvlListBox, HvlMaskTextBox, HvlMenu, HvlNumberBox,
        HvlTab, HvlTabPanel, HvlTextBox
        , HvlButton, HvlButtonTextBox
        , ArrayFilterPipe, DebugPipe, SafePipe, HvlCheckBox, HvlCheckBoxImage, HvlListDefComboBox, HvlEnumComboBox,
        HvlComboBox, HvlDataGrid, HvlGroupBox, HvlSliderPanel, HvlMultiSearchPanel,
        HvlEnumRadioButton, HvlEnumRadio, HvlEnumVerticalRadioButton, HvlEnumImageRadioButton,
        HvlValueListBox, HvlTabControl, AtlasRichTextBox, SummerNoteEditor,
        HvlTabPage, ListSelectionPipe, ComposeComponent, NeStatePanelComponent, HvlListView, PhotoCapture,
        HvlAutoCompleteGrid, HvlRadioButtonGroup, HvlButtonRadioGroup, HvlVerticalButtonRadioGroup,
        HvlImageRadioGroup, HvlDialog, FillHeightDirective, HvlGlaskowButtonRadioGroup,
        AtlasListDefComponent, UserSearchCriteriaPanel, PhotoCaptureWebcamjsPanel, ENabizButon,
        QuickSidebarComponent],
    entryComponents: [HvlDatePicker, HvlListBox, HvlMaskTextBox, HvlMenu, HvlNumberBox,
        HvlTab, HvlTabPanel, HvlTextBox
        , HvlButton, HvlButtonTextBox
        , HvlCheckBox, HvlCheckBoxImage, HvlListDefComboBox, HvlEnumComboBox,
        HvlComboBox, HvlDataGrid, HvlGroupBox, HvlMultiSearchPanel,
        HvlEnumRadioButton, HvlEnumRadio, HvlEnumVerticalRadioButton, HvlEnumImageRadioButton,
        HvlValueListBox, HvlTabControl, AtlasRichTextBox, SummerNoteEditor,
        ComposeComponent, NeStatePanelComponent, HvlListView, PhotoCapture,
        HvlAutoCompleteGrid, HvlRadioButtonGroup, HvlButtonRadioGroup, HvlVerticalButtonRadioGroup,
        HvlImageRadioGroup, HvlDialog, HvlGlaskowButtonRadioGroup,
        AtlasListDefComponent, UserSearchCriteriaPanel, PhotoCaptureWebcamjsPanel, ENabizButon,
        QuickSidebarComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class FwModule {
    static dynamicComponentsMap = {
        HvlDatePicker,
        HvlListBox,
        HvlMaskTextBox,
        HvlMenu,
        HvlNumberBox,
        HvlTab,
        HvlTabPanel,
        HvlTextBox,
        HvlButton,
        HvlButtonTextBox,
        ArrayFilterPipe,
        DebugPipe,
        SafePipe,
        HvlCheckBox,
        HvlCheckBoxImage,
        HvlListDefComboBox,
        HvlEnumComboBox,
        HvlComboBox,
        HvlDataGrid,
        HvlGroupBox,
        HvlSliderPanel,
        HvlMultiSearchPanel,
        HvlEnumRadioButton,
        HvlEnumRadio,
        HvlEnumVerticalRadioButton,
        HvlEnumImageRadioButton,
        HvlValueListBox,
        HvlTabControl,
        AtlasRichTextBox,
        SummerNoteEditor,
        HvlTabPage,
        ListSelectionPipe,
        ComposeComponent,
        NeStatePanelComponent,
        HvlListView,
        PhotoCapture,
        HvlAutoCompleteGrid,
        HvlRadioButtonGroup,
        HvlButtonRadioGroup,
        HvlVerticalButtonRadioGroup,
        HvlImageRadioGroup,
        HvlDialog,
        FillHeightDirective,
        HvlGlaskowButtonRadioGroup,
        AtlasListDefComponent,
        UserSearchCriteriaPanel,
        PhotoCaptureWebcamjsPanel,
        ENabizButon,
        QuickSidebarComponent
    };

}
