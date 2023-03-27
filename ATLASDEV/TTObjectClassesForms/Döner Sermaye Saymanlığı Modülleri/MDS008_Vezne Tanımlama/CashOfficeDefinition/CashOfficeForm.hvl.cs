
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
    /// Vezne / Fatura Servisi Tanımı
    /// </summary>
    public partial class CashOfficeForm : TTDefinitionForm
    {
    /// <summary>
    /// Sayman Mutemetliği / Vezne / Fatura Servisi Tanımı
    /// </summary>
        protected TTObjectClasses.CashOfficeDefinition _CashOfficeDefinition
        {
            get { return (TTObjectClasses.CashOfficeDefinition)_ttObject; }
        }

        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox NAME;
        protected ITTTextBox QREF;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel Label2;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox TYPE;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox BANKACCOUNT;
        protected ITTLabel ttlabel6;
        override protected void InitializeControls()
        {
            labelLocation = (ITTLabel)AddControl(new Guid("c67673cf-b524-4a07-b47f-08daaf87d34c"));
            Location = (ITTTextBox)AddControl(new Guid("2f103a71-76c7-40a0-8d6f-aea39e16bffe"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("da8787c8-e8fc-4e6e-a0f9-10b50e5f9f0f"));
            NAME = (ITTTextBox)AddControl(new Guid("a14740e0-1145-411c-a46d-29d70dc66448"));
            QREF = (ITTTextBox)AddControl(new Guid("e706e066-330e-4070-b7b3-49bd4735a044"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("9a8d2f23-aa9b-48c7-9f2f-1f90e7d50e68"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("349c03f4-bf56-4c91-8e71-1c5fc53c3d1a"));
            Label2 = (ITTLabel)AddControl(new Guid("b5fc1314-3a5c-47ff-8ecc-2363ee501c29"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cd39e05e-c1af-44d6-bff1-8baafdfe8a6e"));
            TYPE = (ITTEnumComboBox)AddControl(new Guid("2c3fd870-4522-4d30-870f-a96897f33607"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d4de1cdc-0fab-4adf-924a-c21a858ca9ac"));
            BANKACCOUNT = (ITTObjectListBox)AddControl(new Guid("ee322c26-aad9-4dfe-b33a-07454e04a449"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("442da80a-612f-4de2-bace-1228bda4a4cf"));
            base.InitializeControls();
        }

        public CashOfficeForm() : base("CASHOFFICEDEFINITION", "CashOfficeForm")
        {
        }

        protected CashOfficeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}