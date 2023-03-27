
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
    public partial class AccountVoucherCodeDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Gelir Gider hesap kodu tanımlama
    /// </summary>
        protected TTObjectClasses.AccountVoucherCodeDefinition _AccountVoucherCodeDefinition
        {
            get { return (TTObjectClasses.AccountVoucherCodeDefinition)_ttObject; }
        }

        protected ITTCheckBox IsDept;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            IsDept = (ITTCheckBox)AddControl(new Guid("810f4865-15be-4fe4-b17d-b03c8868f008"));
            labelDescription = (ITTLabel)AddControl(new Guid("2e0c44fa-f11a-4312-832a-a3945796472a"));
            Description = (ITTTextBox)AddControl(new Guid("92d1b80f-abb9-49e9-8e7a-bdb0c3497bd8"));
            Code = (ITTTextBox)AddControl(new Guid("26c9380b-4d14-4cf3-a1b4-998e0d885446"));
            labelCode = (ITTLabel)AddControl(new Guid("7b210a18-e1d7-4a87-90c9-6ad43ad705c7"));
            base.InitializeControls();
        }

        public AccountVoucherCodeDefinitionForm() : base("ACCOUNTVOUCHERCODEDEFINITION", "AccountVoucherCodeDefinitionForm")
        {
        }

        protected AccountVoucherCodeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}