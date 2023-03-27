
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
    /// Sağlık Teşkili Tanımı
    /// </summary>
    public partial class HealtUnitDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Sağlık Teşkili Tanımı
    /// </summary>
        protected TTObjectClasses.HealtUnitDefinition _HealtUnitDefinition
        {
            get { return (TTObjectClasses.HealtUnitDefinition)_ttObject; }
        }

        protected ITTLabel labelYearlyStatistics;
        protected ITTTextBox YearlyStatistics;
        protected ITTLabel labelType;
        protected ITTTextBox Type;
        protected ITTLabel labelTreatmentAxe;
        protected ITTTextBox TreatmentAxe;
        protected ITTLabel labelTechAssistancePersonalStatus;
        protected ITTTextBox TechAssistancePersonalStatus;
        protected ITTLabel labelTaficsStatus;
        protected ITTTextBox TaficsStatus;
        protected ITTLabel labelSuntrapArea;
        protected ITTTextBox SuntrapArea;
        protected ITTLabel labelPersonalStatus;
        protected ITTTextBox PersonalStatus;
        protected ITTLabel labelOperationCount;
        protected ITTTextBox OperationCount;
        protected ITTLabel labelNearestTafics;
        protected ITTTextBox NearestTafics;
        protected ITTLabel labelMilitaryUnit;
        protected ITTTextBox MilitaryUnit;
        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTLabel labelITSystems;
        protected ITTTextBox ITSystems;
        protected ITTLabel labelHealtUnitPersonelCount;
        protected ITTTextBox HealtUnitPersonelCount;
        protected ITTLabel labelHealtUnitName;
        protected ITTTextBox HealtUnitName;
        protected ITTLabel labelHealthDepartment;
        protected ITTTextBox HealthDepartment;
        protected ITTLabel labelDeliveryEquipment;
        protected ITTTextBox DeliveryEquipment;
        protected ITTLabel labelBriskness;
        protected ITTTextBox Briskness;
        protected ITTLabel labelBedCount;
        protected ITTTextBox BedCount;
        override protected void InitializeControls()
        {
            labelYearlyStatistics = (ITTLabel)AddControl(new Guid("fca8c7ac-0f91-4608-a2dc-cb3162bb1caa"));
            YearlyStatistics = (ITTTextBox)AddControl(new Guid("1437f275-d207-45aa-bbcb-9e4a3e866e07"));
            labelType = (ITTLabel)AddControl(new Guid("a4656be8-ab2d-4a57-8ae7-be130e70605f"));
            Type = (ITTTextBox)AddControl(new Guid("76aa4a15-d5d3-4279-94d0-27397f9e819c"));
            labelTreatmentAxe = (ITTLabel)AddControl(new Guid("f9431315-c52a-4014-abb2-52cad3543a5a"));
            TreatmentAxe = (ITTTextBox)AddControl(new Guid("b4d1aec7-5101-4b22-804a-1aa836db8aed"));
            labelTechAssistancePersonalStatus = (ITTLabel)AddControl(new Guid("819e1af8-4656-4c11-b0e7-02c3e7defa39"));
            TechAssistancePersonalStatus = (ITTTextBox)AddControl(new Guid("398d29ba-ed8f-4b4f-8582-9b21d6a92c58"));
            labelTaficsStatus = (ITTLabel)AddControl(new Guid("305e8ab4-25f8-4dc0-a5d7-a0b27663bb13"));
            TaficsStatus = (ITTTextBox)AddControl(new Guid("79aeb4db-b6ea-4597-82af-fbaecc213702"));
            labelSuntrapArea = (ITTLabel)AddControl(new Guid("4f5d988a-9a99-4345-aafb-995280fef465"));
            SuntrapArea = (ITTTextBox)AddControl(new Guid("b4d8a4b5-1a80-4521-a214-6989440acd11"));
            labelPersonalStatus = (ITTLabel)AddControl(new Guid("0a216f8a-37c6-4d4b-93a9-f7c65bbbaa77"));
            PersonalStatus = (ITTTextBox)AddControl(new Guid("524c8615-445b-46eb-a9a6-ac7c174736fd"));
            labelOperationCount = (ITTLabel)AddControl(new Guid("91941cab-26c9-4fb5-b449-b89fdbbf36ec"));
            OperationCount = (ITTTextBox)AddControl(new Guid("afb5b9a6-d88e-40e3-ad88-4aa17c994b9f"));
            labelNearestTafics = (ITTLabel)AddControl(new Guid("5106a839-6f27-4b6b-aca1-cbefe1b7fe5d"));
            NearestTafics = (ITTTextBox)AddControl(new Guid("9613f879-ea0f-497d-93bc-61ef032cc1c2"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("a42774d3-b7f5-406b-ba10-787e5fbba378"));
            MilitaryUnit = (ITTTextBox)AddControl(new Guid("4c74641c-b6fe-4886-a4fe-ffd142ef4dc7"));
            labelLocation = (ITTLabel)AddControl(new Guid("106c3268-6d70-48b2-abb0-ae774f7b3ffd"));
            Location = (ITTTextBox)AddControl(new Guid("c8592fbb-5fd7-42b7-b83d-3128d591bb53"));
            labelITSystems = (ITTLabel)AddControl(new Guid("987303be-a759-4fe7-bd47-57bf110ea551"));
            ITSystems = (ITTTextBox)AddControl(new Guid("3907213a-1e0a-4e37-99ee-4a4c5d3657e5"));
            labelHealtUnitPersonelCount = (ITTLabel)AddControl(new Guid("aa4c99ec-3bca-4c23-b143-8e39306208f3"));
            HealtUnitPersonelCount = (ITTTextBox)AddControl(new Guid("32d4c792-bbd3-47bf-9af6-79282398f76c"));
            labelHealtUnitName = (ITTLabel)AddControl(new Guid("b7b1e4b6-7133-4f81-a6a9-7413635db5bb"));
            HealtUnitName = (ITTTextBox)AddControl(new Guid("43fccd1e-2546-4e97-a507-b075745d8d94"));
            labelHealthDepartment = (ITTLabel)AddControl(new Guid("1061c3ad-e4f4-4b64-bc0c-46eced66d031"));
            HealthDepartment = (ITTTextBox)AddControl(new Guid("6b758128-d582-4555-81ca-a1373827e148"));
            labelDeliveryEquipment = (ITTLabel)AddControl(new Guid("9225527e-b769-4ea1-9846-d0b1900b4142"));
            DeliveryEquipment = (ITTTextBox)AddControl(new Guid("a4a180bb-eb05-4a51-8970-262a223ef2ca"));
            labelBriskness = (ITTLabel)AddControl(new Guid("97aa904e-da4a-4514-9a0c-ee811aaf2d57"));
            Briskness = (ITTTextBox)AddControl(new Guid("3a319451-cb29-4a14-9ab1-73f59b7ce80f"));
            labelBedCount = (ITTLabel)AddControl(new Guid("df31843e-fba6-4823-95da-0ac12301152f"));
            BedCount = (ITTTextBox)AddControl(new Guid("85e27e4d-cb3a-4d0e-8d92-209d85621f9e"));
            base.InitializeControls();
        }

        public HealtUnitDefForm() : base("HEALTUNITDEFINITION", "HealtUnitDefForm")
        {
        }

        protected HealtUnitDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}