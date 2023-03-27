
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
    /// New Form
    /// </summary>
    public partial class ProtocolPriceCalculationForm : TTForm
    {
        protected TTObjectClasses.ProtocolPriceCalculation _ProtocolPriceCalculation
        {
            get { return (TTObjectClasses.ProtocolPriceCalculation)_ttObject; }
        }

        protected ITTLabel ttlabel7;
        protected ITTTextBox PACKAGEPRICE;
        protected ITTObjectListBox PROTOCOL;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox MATERIAL;
        protected ITTLabel ttlabel5;
        protected ITTEnumComboBox PATIENTSTATUS;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox PROCEDURE;
        protected ITTObjectListBox PACKAGE;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel6;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel ttlabel1;
        protected ITTButton CalculateButon;
        protected ITTTextBox PATIENTPRICE;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel8;
        override protected void InitializeControls()
        {
            ttlabel7 = (ITTLabel)AddControl(new Guid("4bef29f3-fae0-4adf-b093-1b34389cab70"));
            PACKAGEPRICE = (ITTTextBox)AddControl(new Guid("ff319df3-ad9b-48a1-9a62-4a0cebb27199"));
            PROTOCOL = (ITTObjectListBox)AddControl(new Guid("adf9c9e5-985a-4c88-ae17-634f4dd18d76"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("26e9aa44-c355-4248-9ecd-578b2c26545d"));
            MATERIAL = (ITTObjectListBox)AddControl(new Guid("9f83d579-b30f-445a-9446-56d8aa3a4a5c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b3447ce8-9c42-4a0b-aa0c-75c46e3962e5"));
            PATIENTSTATUS = (ITTEnumComboBox)AddControl(new Guid("dfb8c22e-9801-4768-b056-69d2e50e1afe"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("0c60de7c-0f64-442d-b7b6-7a55616c906e"));
            PROCEDURE = (ITTObjectListBox)AddControl(new Guid("6463df1b-c40c-40f1-9e94-7d6f820067c4"));
            PACKAGE = (ITTObjectListBox)AddControl(new Guid("59f70bc3-440f-4a0b-bca1-8dc903fb6390"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("53be38a0-90ab-47f7-bfc5-99e2219d5ffc"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("cb405e6a-35df-4083-ac15-9913c600b753"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("6c6e1062-a41f-4b5e-873e-b705774df00d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a433d753-bf9f-4319-b2af-b79094784594"));
            CalculateButon = (ITTButton)AddControl(new Guid("b78c8938-e0e6-4355-b588-bef80e3656d5"));
            PATIENTPRICE = (ITTTextBox)AddControl(new Guid("86362cb0-a69e-4282-9231-d2e959e2b2ad"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a0f93a96-5dbc-4128-83b0-de084a7f66d1"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("aeee1907-9276-45c7-a635-f13ae5ecdfe0"));
            base.InitializeControls();
        }

        public ProtocolPriceCalculationForm() : base("PROTOCOLPRICECALCULATION", "ProtocolPriceCalculationForm")
        {
        }

        protected ProtocolPriceCalculationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}