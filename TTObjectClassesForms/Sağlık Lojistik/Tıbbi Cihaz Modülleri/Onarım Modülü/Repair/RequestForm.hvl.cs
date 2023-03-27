
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
    /// Onarım İstek
    /// </summary>
    public partial class RequestForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip2;
        protected ITTObjectListBox objDeviceUser;
        protected ITTLabel labelRequestNO;
        protected ITTTextBox RequestNO;
        protected ITTMaskedTextBox UserTel;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Comments;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTTextBox Description;
        protected ITTObjectListBox FixedAsset;
        protected ITTTextBox tttextbox4;
        protected ITTDateTimePicker RequestDate;
        override protected void InitializeControls()
        {
            tttoolstrip2 = (ITTToolStrip)AddControl(new Guid("ee815121-7197-4adb-bf48-4f49a2294f67"));
            objDeviceUser = (ITTObjectListBox)AddControl(new Guid("19612aae-5d50-4eae-bd0b-6b82b9337fa6"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("93b6b9d6-fe36-4398-b56c-076c34030ec7"));
            RequestNO = (ITTTextBox)AddControl(new Guid("e3586397-bb7b-45e8-af3b-b1b635556843"));
            UserTel = (ITTMaskedTextBox)AddControl(new Guid("9fd90be6-4519-4bde-9941-7d3fadaf8ebc"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("a6782b9c-95d4-49de-acc3-000f858e8811"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("cafc1b84-bec1-4dfe-834d-7f0f1c722772"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("a5ba39cb-7952-4d4a-b1f3-8cc14c7cd874"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("addc883c-3a66-4951-acae-39073ccdf98f"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("18849a85-3626-4082-97e6-00a7b37125e6"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("2634934f-282b-4bec-8952-140727c798df"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("96f147f6-b733-4357-88fb-180cc5aa75e6"));
            labelDescription = (ITTLabel)AddControl(new Guid("b2910e65-8252-4edb-90e3-56dee49bb075"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("37f67ed1-c9d7-44b2-91e3-6f045337fbce"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("4a0470bd-6220-4b44-955f-714c8727f0fe"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0009f2b0-f2bb-4fad-ae43-79eb2cdff29f"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("f61ce810-a9b2-4a3a-a0e2-83d0e246cc97"));
            labelFromResource = (ITTLabel)AddControl(new Guid("1e2b5757-dd3d-4eb6-a871-86b81f1faeca"));
            Description = (ITTTextBox)AddControl(new Guid("f47ea8f2-e88e-4b13-86d5-b150d452468d"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("c72f9751-274b-4c52-b412-e82a19f39eb4"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("b692ae99-1f6a-4303-8b49-e985392aaba5"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("eba08249-3ead-4f01-a50e-eb5d29d19688"));
            base.InitializeControls();
        }

        public RequestForm() : base("REPAIR", "RequestForm")
        {
        }

        protected RequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}