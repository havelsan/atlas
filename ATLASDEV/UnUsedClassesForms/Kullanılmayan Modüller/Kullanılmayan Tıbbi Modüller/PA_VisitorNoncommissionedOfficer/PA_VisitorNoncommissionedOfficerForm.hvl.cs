
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
    /// Misafir Astsubay Kabulü
    /// </summary>
    public partial class PA_VisitorNoncommissionedOfficerForm : PA_VisitorMilitaryForm
    {
    /// <summary>
    /// Misafir Astsubay Kabulü
    /// </summary>
        protected TTObjectClasses.PA_VisitorNoncommissionedOfficer _PA_VisitorNoncommissionedOfficer
        {
            get { return (TTObjectClasses.PA_VisitorNoncommissionedOfficer)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox MilitaryClass;
        protected ITTObjectListBox Rank;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("cea1ba47-c2df-4cc2-a0e8-9b0afa77233d"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b1b57be2-414b-483a-8fda-09242fa9e604"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("a3169745-c25e-4f13-b121-4c47c9f298e0"));
            Rank = (ITTObjectListBox)AddControl(new Guid("ae4d506c-2c4b-4aad-9b18-8c975f2d1778"));
            base.InitializeControls();
        }

        public PA_VisitorNoncommissionedOfficerForm() : base("PA_VISITORNONCOMMISSIONEDOFFICER", "PA_VisitorNoncommissionedOfficerForm")
        {
        }

        protected PA_VisitorNoncommissionedOfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}