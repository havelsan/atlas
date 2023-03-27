
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
    /// Kurum Grubu Tanımı
    /// </summary>
    public partial class PayerGroupForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Kurum Grubu
    /// </summary>
        protected TTObjectClasses.PayerGroupDefinition _PayerGroupDefinition
        {
            get { return (TTObjectClasses.PayerGroupDefinition)_ttObject; }
        }

        protected ITTTextBox NAME;
        protected ITTTextBox ID;
        protected ITTCheckBox ISACTIVE;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            NAME = (ITTTextBox)AddControl(new Guid("75f2f14f-c792-428b-a8b9-5c7ef4e0dbbe"));
            ID = (ITTTextBox)AddControl(new Guid("7f277307-1133-40f7-a018-8723d491cdfd"));
            ISACTIVE = (ITTCheckBox)AddControl(new Guid("570aba8d-3b46-4e4b-b2a8-f7ddae33c438"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c9628b06-c445-4abc-94e5-ee8d6e8bfcbd"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("926f6e21-1cd2-4917-ab96-54a03dceb8a0"));
            base.InitializeControls();
        }

        public PayerGroupForm() : base("PAYERGROUPDEFINITION", "PayerGroupForm")
        {
        }

        protected PayerGroupForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}