
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
    /// Reçete Detayları Oluşturma
    /// </summary>
    public partial class CreatePresDetailActionForm : TTForm
    {
        protected TTObjectClasses.CreatePresDetailAction _CreatePresDetailAction
        {
            get { return (TTObjectClasses.CreatePresDetailAction)_ttObject; }
        }

        protected ITTGrid PresActionDetails;
        protected ITTTextBoxColumn SerialNoPresActionDetail;
        protected ITTTextBoxColumn VolumeNoPresActionDetail;
        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        protected ITTTextBox ID;
        protected ITTTextBox seriNo;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox5;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelMainStoreDefinition;
        protected ITTObjectListBox MainStoreDefinition;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTButton ttbuttonSorgula;
        protected ITTLabel ttCiltno;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel9;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox bitNo;
        protected ITTTextBox basNo;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            PresActionDetails = (ITTGrid)AddControl(new Guid("081534e6-9874-4398-8d7c-1925144fac1a"));
            SerialNoPresActionDetail = (ITTTextBoxColumn)AddControl(new Guid("ba0e18a1-8f29-4959-8dd6-0852ddb10a13"));
            VolumeNoPresActionDetail = (ITTTextBoxColumn)AddControl(new Guid("13ab45f3-8f2d-405e-8e9b-9629afb1cdf0"));
            labelAmount = (ITTLabel)AddControl(new Guid("bc75bd00-29a4-48d6-b9d0-8df729054fe3"));
            Amount = (ITTTextBox)AddControl(new Guid("a39906fd-8427-4684-b40e-45181fe60ddc"));
            ID = (ITTTextBox)AddControl(new Guid("cbe1c9d2-8059-4444-8c0d-b32f1e53131a"));
            seriNo = (ITTTextBox)AddControl(new Guid("de74befd-64e1-4459-bc8c-19c8662f2b52"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("a1e8a073-9dc5-48ae-813d-2fc8254f6e4c"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("d18db76a-2d2a-408d-98f4-4b49f706dad8"));
            labelMaterial = (ITTLabel)AddControl(new Guid("0e1ad0f1-30b3-47f1-86a5-409d4f5960c0"));
            Material = (ITTObjectListBox)AddControl(new Guid("327256d1-015e-40ea-a9ad-f7f143860b66"));
            labelMainStoreDefinition = (ITTLabel)AddControl(new Guid("e1c004ed-17e7-42a4-9353-2566368e16fa"));
            MainStoreDefinition = (ITTObjectListBox)AddControl(new Guid("389759be-f46c-4d2d-8dd9-33b55570dbc2"));
            labelID = (ITTLabel)AddControl(new Guid("1dafc80a-977e-4334-96c2-990afd8ef7d0"));
            labelActionDate = (ITTLabel)AddControl(new Guid("8a2b4342-f711-4487-b2df-c1d3be243b47"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("7963014a-96de-41f8-969b-cfbc2b1f748c"));
            ttbuttonSorgula = (ITTButton)AddControl(new Guid("07cb1257-8b40-4d5d-a062-80770643f205"));
            ttCiltno = (ITTLabel)AddControl(new Guid("15ed429d-3f6a-4c71-a318-f5b46f5689e2"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("9b9ff353-718f-4a7f-acd2-8aab80918bd3"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("37bdbe69-03ef-46d6-8cc2-f3438ad82ba3"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("d564f9eb-4c88-4394-9876-00da0050b706"));
            bitNo = (ITTTextBox)AddControl(new Guid("0eb9646b-83fe-4abe-a5b5-065ce564ecc4"));
            basNo = (ITTTextBox)AddControl(new Guid("c8266d5b-edab-49a4-ac3a-6d1be1fa82e6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6f634634-ee8b-42da-aeb6-245ad746c9d7"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0d40e4a0-81a5-44bf-b32e-6e9454327e3c"));
            base.InitializeControls();
        }

        public CreatePresDetailActionForm() : base("CREATEPRESDETAILACTION", "CreatePresDetailActionForm")
        {
        }

        protected CreatePresDetailActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}