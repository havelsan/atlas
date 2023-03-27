
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
    public partial class ManualDexterityTestsForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// El beceri testleri
    /// </summary>
        protected TTObjectClasses.ManualDexterityTestsForm _ManualDexterityTestsForm
        {
            get { return (TTObjectClasses.ManualDexterityTestsForm)_ttObject; }
        }

        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelCode;
        protected ITTTextBox Code;
        protected ITTTextBox DellonTest;
        protected ITTTextBox BimanuelFineMotorTest;
        protected ITTTextBox MobergTest;
        protected ITTTextBox NineHolePegTest;
        protected ITTTextBox OConnorTest;
        protected ITTTextBox PurduePegboardTest;
        protected ITTLabel labelDellonTest;
        protected ITTLabel labelBimanuelFineMotorTest;
        protected ITTLabel labelMobergTest;
        protected ITTLabel labelNineHolePegTest;
        protected ITTLabel labelOConnorTest;
        protected ITTLabel labelPurduePegboardTest;
        override protected void InitializeControls()
        {
            labelCreationDate = (ITTLabel)AddControl(new Guid("8b8c017a-d553-4142-84ce-d1f6fcea739c"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("80585d9f-1e0e-47bf-9071-379806bea727"));
            labelCode = (ITTLabel)AddControl(new Guid("616bf295-7f1b-4b82-a4df-62d32e206259"));
            Code = (ITTTextBox)AddControl(new Guid("277743bf-0dbc-46fd-affe-8235f690328f"));
            DellonTest = (ITTTextBox)AddControl(new Guid("e62cb4f3-2127-4f26-a197-1c22758346a2"));
            BimanuelFineMotorTest = (ITTTextBox)AddControl(new Guid("4cd09081-47b7-486b-8186-3e7261df7830"));
            MobergTest = (ITTTextBox)AddControl(new Guid("ce773888-853b-4ab7-b80a-19e87a0ca9e5"));
            NineHolePegTest = (ITTTextBox)AddControl(new Guid("3b22f893-8b00-44fc-a64b-3d34e50e3f81"));
            OConnorTest = (ITTTextBox)AddControl(new Guid("3b97331c-9fce-4e39-9389-34563fe20793"));
            PurduePegboardTest = (ITTTextBox)AddControl(new Guid("80694e13-b034-420f-aed1-587ae7d14f93"));
            labelDellonTest = (ITTLabel)AddControl(new Guid("73edf9fa-623f-439e-bbf6-60f06176da3c"));
            labelBimanuelFineMotorTest = (ITTLabel)AddControl(new Guid("2d2f56eb-00dd-4f16-9f04-8605e36d4763"));
            labelMobergTest = (ITTLabel)AddControl(new Guid("0515129c-c778-4446-9881-9ea39514458e"));
            labelNineHolePegTest = (ITTLabel)AddControl(new Guid("b5014866-f14b-464a-916b-7b75f96b2980"));
            labelOConnorTest = (ITTLabel)AddControl(new Guid("4b2cee07-221d-4f2d-bd7c-abdbe5396067"));
            labelPurduePegboardTest = (ITTLabel)AddControl(new Guid("754cdc60-6e5f-46a5-9b41-5be309daaa14"));
            base.InitializeControls();
        }

        public ManualDexterityTestsForm() : base("MANUALDEXTERITYTESTSFORM", "ManualDexterityTestsForm")
        {
        }

        protected ManualDexterityTestsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}