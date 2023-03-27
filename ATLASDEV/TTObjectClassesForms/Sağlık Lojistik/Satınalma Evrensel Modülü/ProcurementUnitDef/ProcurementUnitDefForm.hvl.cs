
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
    /// Tedarik Birimi Tanımlama
    /// </summary>
    public partial class ProcurementUnitDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ProcurementUnitDef _ProcurementUnitDef
        {
            get { return (TTObjectClasses.ProcurementUnitDef)_ttObject; }
        }

        protected ITTLabel labelTelephone;
        protected ITTTextBox Telephone;
        protected ITTLabel labelFax;
        protected ITTTextBox Fax;
        protected ITTLabel labeleMail;
        protected ITTTextBox eMail;
        protected ITTLabel labelAddress;
        protected ITTTextBox Address;
        protected ITTLabel labelMilitaryUnit;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelTelephone = (ITTLabel)AddControl(new Guid("b000aa2f-8987-4b8c-89b8-443ed00929c2"));
            Telephone = (ITTTextBox)AddControl(new Guid("e20b06a6-0cd3-475c-a67a-9e12bea51e6f"));
            labelFax = (ITTLabel)AddControl(new Guid("5b9548a0-442b-4729-bca8-ec99d7a73153"));
            Fax = (ITTTextBox)AddControl(new Guid("f8082a97-95ac-44a4-888d-733c8aa11b0d"));
            labeleMail = (ITTLabel)AddControl(new Guid("5eaa060c-8e8b-4fb9-afa5-eea08f93cb8c"));
            eMail = (ITTTextBox)AddControl(new Guid("03f016d4-06d9-4487-97c8-09a02cbb7174"));
            labelAddress = (ITTLabel)AddControl(new Guid("bc510ed7-4645-4ec0-ab00-4670719832ec"));
            Address = (ITTTextBox)AddControl(new Guid("2e05ef69-3393-4f0c-a5d0-6b02e2579ab7"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("1e82d757-2c78-4080-8b7b-e09b8f1b3ffe"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("99341908-e1eb-4bc4-be0a-d28a1873b684"));
            labelName = (ITTLabel)AddControl(new Guid("17d9a6cf-287b-4f3a-994c-0e48ba93b707"));
            Name = (ITTTextBox)AddControl(new Guid("623d5337-bd25-4751-9972-7790a48ed216"));
            base.InitializeControls();
        }

        public ProcurementUnitDefForm() : base("PROCUREMENTUNITDEF", "ProcurementUnitDefForm")
        {
        }

        protected ProcurementUnitDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}