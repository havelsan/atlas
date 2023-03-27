
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
    /// Bakım / Kalibrasyon Planlama
    /// </summary>
    public partial class MaintenancePlanForm : TTForm
    {
    /// <summary>
    /// Bakım ve Kalibrasyon Planlama
    /// </summary>
        protected TTObjectClasses.MaintenancePlan _MaintenancePlan
        {
            get { return (TTObjectClasses.MaintenancePlan)_ttObject; }
        }

        protected ITTButton cmdList;
        protected ITTCheckBox HasError;
        protected ITTLabel ttlabel4;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage PlannedWordTab;
        protected ITTGrid PlannedWorksGrid;
        protected ITTListBoxColumn Service2;
        protected ITTListBoxColumn Device2;
        protected ITTListBoxColumn WorkShopUser2;
        protected ITTDateTimePickerColumn Date;
        protected ITTEnumComboBoxColumn MaintenancePlanType2;
        protected ITTTabPage PlannedWorkDetailsTab;
        protected ITTGrid PlannedWorkDetailsGrid;
        protected ITTDateTimePickerColumn Date5;
        protected ITTTextBoxColumn Workload5;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage byDeviceTab;
        protected ITTGrid DevicesGrid;
        protected ITTListBoxColumn FixedAssetMaterial;
        protected ITTTextBoxColumn MaintenanceWorkload3;
        protected ITTTextBoxColumn CalibrationWorkload3;
        protected ITTTabPage byServiceTab;
        protected ITTGrid ServicesGrid;
        protected ITTListBoxColumn Service;
        protected ITTTextBoxColumn WorkLoad;
        protected ITTListBoxColumn WorkShopUser3;
        protected ITTTextBox Year;
        protected ITTEnumComboBox MaintenancePlanType;
        protected ITTEnumComboBox PlanStrategy;
        protected ITTLabel ttlabel3;
        protected ITTButton cmdPlan;
        protected ITTGrid PersonelGrid;
        protected ITTListBoxColumn WorkShopUser;
        protected ITTTextBoxColumn WorkLoad2;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTLabel labelOwnerMilitaryUnit;
        override protected void InitializeControls()
        {
            cmdList = (ITTButton)AddControl(new Guid("d2049448-6485-4185-b3f6-aeb3e0457f9c"));
            HasError = (ITTCheckBox)AddControl(new Guid("a63b868f-e32d-4144-8c6e-eb9a2a7e5c06"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("a43b529f-57b0-44cd-8fcd-0741ede88bd3"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("5816c3ed-bb7a-4305-b87f-44a5e8c160ed"));
            PlannedWordTab = (ITTTabPage)AddControl(new Guid("c658c6c0-3960-4537-b3a0-c3e478227764"));
            PlannedWorksGrid = (ITTGrid)AddControl(new Guid("506ef77a-1287-4fa6-afbd-877c0a25982d"));
            Service2 = (ITTListBoxColumn)AddControl(new Guid("7085f1d3-ad87-4ad2-8f05-68eb715b9556"));
            Device2 = (ITTListBoxColumn)AddControl(new Guid("f2f611d3-68d3-4ef7-b01e-4de60eff6c0b"));
            WorkShopUser2 = (ITTListBoxColumn)AddControl(new Guid("22e29153-82f3-43bc-b20d-38e4849cd3cb"));
            Date = (ITTDateTimePickerColumn)AddControl(new Guid("c089bac0-3227-4787-8207-96188439d8a6"));
            MaintenancePlanType2 = (ITTEnumComboBoxColumn)AddControl(new Guid("7ebeeed5-1435-4127-9ea3-ca05658d66f9"));
            PlannedWorkDetailsTab = (ITTTabPage)AddControl(new Guid("3be06878-5f0b-44d4-b93b-1f7cf45d87fc"));
            PlannedWorkDetailsGrid = (ITTGrid)AddControl(new Guid("214d4ee0-5f36-47c7-aa8e-a1c286d11565"));
            Date5 = (ITTDateTimePickerColumn)AddControl(new Guid("fce40b8d-2434-476a-96c2-5def8513072e"));
            Workload5 = (ITTTextBoxColumn)AddControl(new Guid("73e91fcb-d6ba-4908-a1b4-cd4a3b018c82"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("13929df8-4930-45f5-80d0-1f9e6535749b"));
            byDeviceTab = (ITTTabPage)AddControl(new Guid("de5e0af7-187a-46bb-b03f-41cced3fe5a5"));
            DevicesGrid = (ITTGrid)AddControl(new Guid("f0a1c49a-b53e-48ca-b967-381d2b8a96e4"));
            FixedAssetMaterial = (ITTListBoxColumn)AddControl(new Guid("7f1c3221-5110-48c0-bc62-99b16d118496"));
            MaintenanceWorkload3 = (ITTTextBoxColumn)AddControl(new Guid("2caf0127-c8f2-4729-95be-222adab15d85"));
            CalibrationWorkload3 = (ITTTextBoxColumn)AddControl(new Guid("7120f6e6-28a4-4219-ba55-631911b12127"));
            byServiceTab = (ITTTabPage)AddControl(new Guid("53dfc854-30fc-4208-980f-f3dd972cb32b"));
            ServicesGrid = (ITTGrid)AddControl(new Guid("375b2937-e153-431b-b951-2324160231f3"));
            Service = (ITTListBoxColumn)AddControl(new Guid("7cd18119-ab47-4f34-b07b-0fa55c0b226b"));
            WorkLoad = (ITTTextBoxColumn)AddControl(new Guid("533eda08-6481-49ae-b9b5-b660d8b21084"));
            WorkShopUser3 = (ITTListBoxColumn)AddControl(new Guid("5dd977c7-8741-4193-a301-03c59fab333c"));
            Year = (ITTTextBox)AddControl(new Guid("85feaac5-bdf8-4fe2-bf22-8093a9894bd6"));
            MaintenancePlanType = (ITTEnumComboBox)AddControl(new Guid("15196bd9-ff4e-468e-b0df-cc0c55b36ac6"));
            PlanStrategy = (ITTEnumComboBox)AddControl(new Guid("64438d6d-7baa-4f65-8bc0-43037aab1333"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5ceed4b3-c689-4dc8-b0b6-31c23a6eb54c"));
            cmdPlan = (ITTButton)AddControl(new Guid("1c34da48-d53d-4d06-b27d-14549dc0e6c8"));
            PersonelGrid = (ITTGrid)AddControl(new Guid("489e174a-3f7f-4575-b22e-789b3327e2aa"));
            WorkShopUser = (ITTListBoxColumn)AddControl(new Guid("21b559e7-bf60-468e-a223-853b95357410"));
            WorkLoad2 = (ITTTextBoxColumn)AddControl(new Guid("76a4f8b9-e81b-4e4a-95fc-68c0655187f3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("dd6ef1c2-0a9f-45f4-9d83-62a7d367dc2a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b8a752e9-9347-4245-b909-e2cdd0d9a1bd"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("9c8f21f1-4587-4d10-bf76-9306a93da597"));
            labelOwnerMilitaryUnit = (ITTLabel)AddControl(new Guid("b4412ae8-9d79-4df1-b41b-30279309f65c"));
            base.InitializeControls();
        }

        public MaintenancePlanForm() : base("MAINTENANCEPLAN", "MaintenancePlanForm")
        {
        }

        protected MaintenancePlanForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}