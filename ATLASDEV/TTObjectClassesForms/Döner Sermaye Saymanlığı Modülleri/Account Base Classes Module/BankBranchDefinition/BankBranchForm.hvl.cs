
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
    /// Banka Şube Tanımı
    /// </summary>
    public partial class BankBranchForm : TTDefinitionForm
    {
    /// <summary>
    /// Banka Şube Tanımı
    /// </summary>
        protected TTObjectClasses.BankBranchDefinition _BankBranchDefinition
        {
            get { return (TTObjectClasses.BankBranchDefinition)_ttObject; }
        }

        protected ITTTextBox NAME;
        protected ITTLabel ttlabel1;
        protected ITTTextBox CODE;
        protected ITTLabel ttlabel2;
        protected ITTValueListBox BANK;
        protected ITTLabel TTLABEL8;
        override protected void InitializeControls()
        {
            NAME = (ITTTextBox)AddControl(new Guid("98b2c298-7a05-4dd8-b430-c7cccf38bf1d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3fd34bb3-0a8f-4ae9-a8f2-e7acc6355716"));
            CODE = (ITTTextBox)AddControl(new Guid("1e4620f6-1675-4ffd-928f-e8c2a8719d1d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("35ef32ce-fa26-49a9-ae4b-0cc5836cf4a3"));
            BANK = (ITTValueListBox)AddControl(new Guid("400f80ca-622a-400b-b31c-9906bee6f012"));
            TTLABEL8 = (ITTLabel)AddControl(new Guid("d34d6595-a9c3-47e4-a0d5-2ea4bc20573f"));
            base.InitializeControls();
        }

        public BankBranchForm() : base("BANKBRANCHDEFINITION", "BankBranchForm")
        {
        }

        protected BankBranchForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}