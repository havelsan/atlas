
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
    /// Hizmet Grubu Tanımı
    /// </summary>
    public partial class ProcedureTreeForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ProcedureTreeDefinition _ProcedureTreeDefinition
        {
            get { return (TTObjectClasses.ProcedureTreeDefinition)_ttObject; }
        }

        protected ITTTextBox EXTERNALCODE;
        protected ITTTextBox Description;
        protected ITTTextBox ID;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTLabel labelExternalCode;
        protected ITTObjectListBox PARENTID;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox REVENUESUBACCOUNTCODE;
        override protected void InitializeControls()
        {
            EXTERNALCODE = (ITTTextBox)AddControl(new Guid("28d53cb1-319a-41ce-9c23-00f2388113db"));
            Description = (ITTTextBox)AddControl(new Guid("086bd690-2fd6-4ea8-bbc0-0dc7afce7148"));
            ID = (ITTTextBox)AddControl(new Guid("ba27d036-8a56-4a85-a7f3-12abe133ba5a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("170a21e9-2f7a-4f81-b2bd-5f4a8c5db12d"));
            labelDescription = (ITTLabel)AddControl(new Guid("6036dd59-8a89-4b4a-a947-b1e100d9ef54"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("6155517a-edd3-4979-9fe9-c360d44bac86"));
            PARENTID = (ITTObjectListBox)AddControl(new Guid("d42144ac-c107-4fbd-a680-e0647ca34988"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("20ccc77f-5803-4dc6-80e5-6c3a42a848d2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("920c28c2-ef66-41b6-a681-c1f656c163bd"));
            REVENUESUBACCOUNTCODE = (ITTObjectListBox)AddControl(new Guid("6258edc4-aa41-43b9-9358-8e5c9b786a3b"));
            base.InitializeControls();
        }

        public ProcedureTreeForm() : base("PROCEDURETREEDEFINITION", "ProcedureTreeForm")
        {
        }

        protected ProcedureTreeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}