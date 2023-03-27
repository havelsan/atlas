
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
    /// Banka Tanımı
    /// </summary>
    public partial class BankForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Banka Tanımı
    /// </summary>
        protected TTObjectClasses.BankDefinition _BankDefinition
        {
            get { return (TTObjectClasses.BankDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox NAME;
        protected ITTTextBox CODE;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("75656d2c-ca11-423a-89ba-4a8081ebf000"));
            NAME = (ITTTextBox)AddControl(new Guid("81473bc9-2e07-4888-bda3-58afda8d8eeb"));
            CODE = (ITTTextBox)AddControl(new Guid("965f9e28-911d-4b46-b923-955bbb490361"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9c44f54b-6eaf-4045-8d8f-978fd2b3edd8"));
            base.InitializeControls();
        }

        public BankForm() : base("BANKDEFINITION", "BankForm")
        {
        }

        protected BankForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}