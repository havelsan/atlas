
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
    /// Muhasebe Kodları Tanımı
    /// </summary>
    public partial class AccountCodeDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Muhasebe Kodları Tanımlama Modülü
    /// </summary>
        protected TTObjectClasses.AccountCodeDefinition _AccountCodeDefinition
        {
            get { return (TTObjectClasses.AccountCodeDefinition)_ttObject; }
        }

        protected ITTTextBox ACCOUNTCODE;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox ACCOUNTTYPE;
        override protected void InitializeControls()
        {
            ACCOUNTCODE = (ITTTextBox)AddControl(new Guid("97ccd42b-b9fc-4598-8883-453bac1132e9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("0f46db50-68d0-431f-82d0-231546bf66c4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2ba55f4b-6167-46e9-8251-7204e059f20b"));
            ACCOUNTTYPE = (ITTEnumComboBox)AddControl(new Guid("c0706653-5ffa-4819-9884-8c7c8bce4eac"));
            base.InitializeControls();
        }

        public AccountCodeDefinitionForm() : base("ACCOUNTCODEDEFINITION", "AccountCodeDefinitionForm")
        {
        }

        protected AccountCodeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}