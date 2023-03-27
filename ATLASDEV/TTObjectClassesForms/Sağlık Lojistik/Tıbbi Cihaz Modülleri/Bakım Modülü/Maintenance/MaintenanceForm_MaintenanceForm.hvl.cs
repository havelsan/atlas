
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Bakım
    /// </summary>
    public partial class MaintenanceForm_Maintenance : MaintenanceBaseForm
    {
    /// <summary>
    /// Bakım
    /// </summary>
        protected TTObjectClasses.Maintenance _Maintenance
        {
            get { return (TTObjectClasses.Maintenance)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid DeviceCheckLists;
        protected ITTListBoxColumn MaintenanceParameterDefDeviceCheckList;
        protected ITTCheckBoxColumn CheckDeviceCheckList;
        protected ITTTextBoxColumn DescriptionDeviceCheckList;
        protected ITTTabPage tttabpage2;
        protected ITTGrid MaintenanceCheckLists;
        protected ITTListBoxColumn MaintenanceParameterDefMaintenanceCheckList;
        protected ITTCheckBoxColumn CheckMaintenanceCheckList;
        protected ITTTextBoxColumn DescriptionMaintenanceCheckList;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        protected ITTRichTextBoxControl Result;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelStartDate;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox FromResource;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelResponsibleResource;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker StartDate;
        protected ITTObjectListBox Stage;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("596893f1-d632-4546-85dd-cae974192ee7"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("9c91a617-4d0c-4619-a90e-46af447fc51a"));
            DeviceCheckLists = (ITTGrid)AddControl(new Guid("37f7eb50-6f6d-41bf-b730-4154bb3487c4"));
            MaintenanceParameterDefDeviceCheckList = (ITTListBoxColumn)AddControl(new Guid("b5ef9ebc-fdf6-489d-828d-f9f27a258652"));
            CheckDeviceCheckList = (ITTCheckBoxColumn)AddControl(new Guid("8174e6ce-1abd-4ecf-97b2-bf934846325c"));
            DescriptionDeviceCheckList = (ITTTextBoxColumn)AddControl(new Guid("d8ad3e8d-e27f-49ec-bfab-763b8b25504e"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("c7ede045-c8c4-4431-810c-f16c3ec63390"));
            MaintenanceCheckLists = (ITTGrid)AddControl(new Guid("9e555bcb-7ff3-4349-a280-8e4182ce4fbe"));
            MaintenanceParameterDefMaintenanceCheckList = (ITTListBoxColumn)AddControl(new Guid("3dc8fa5b-5c52-4d2a-8b8f-ecd389fc7a94"));
            CheckMaintenanceCheckList = (ITTCheckBoxColumn)AddControl(new Guid("5e22f4f4-60ed-46b5-b5f5-6b66d21b73c4"));
            DescriptionMaintenanceCheckList = (ITTTextBoxColumn)AddControl(new Guid("a1335c4f-5be4-4eb7-879b-dd14f5cdfbfb"));
            Description = (ITTTextBox)AddControl(new Guid("a5675f29-3a90-4066-b92a-b04af3320e8d"));
            RequestNO = (ITTTextBox)AddControl(new Guid("0148d1a1-652c-42ab-8fbc-f225c05f4424"));
            Result = (ITTRichTextBoxControl)AddControl(new Guid("353c00da-82ce-41e6-b827-f3ad625d1add"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("3f42f2e4-1a2e-40c8-a3f1-84ba8dbd81b9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bed360af-506c-4e4c-86b4-c4cfdaad13da"));
            labelDescription = (ITTLabel)AddControl(new Guid("a0d28c6c-dc82-4815-80fb-212b4e2c76ea"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("1502dd7d-2d9f-42ae-8d81-2379d65c1d1c"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("8bace1a9-2680-46f0-95d3-4aea8d9c4443"));
            labelStartDate = (ITTLabel)AddControl(new Guid("b8bc6f78-e458-4ff0-8f7a-5fe1c469fe26"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("e73632a1-b625-487a-a9e4-6214b4b886ca"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("d890522d-3bd2-4dde-aed8-6338f82c7a18"));
            labelFromResource = (ITTLabel)AddControl(new Guid("a07633bc-d8c4-4e8c-a4b3-91e7edbf4093"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("d7fb7ad9-b732-46d2-9e8c-c7fd279ec6c6"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("77c5fee1-573c-44db-b44a-de3d5024f053"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("dcf1910c-4c88-40ff-8f1c-e4a6036fbb73"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("738be886-f9a3-4398-a99b-e7d1140232ca"));
            labelToResource = (ITTLabel)AddControl(new Guid("e5e6e8f1-f12b-49d3-ac5e-eba83387b4b9"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("cbf0817b-8889-49f1-96c0-ece15cc4f237"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("50875913-4eac-48d8-a1f5-f94afe2fc961"));
            Stage = (ITTObjectListBox)AddControl(new Guid("21f17a8e-ad10-4532-b0f1-8018d33e252b"));
            base.InitializeControls();
        }

        public MaintenanceForm_Maintenance() : base("MAINTENANCE", "MaintenanceForm_Maintenance")
        {
        }

        protected MaintenanceForm_Maintenance(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}