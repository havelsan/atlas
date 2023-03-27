
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
    /// Misafir Subay Kabulü
    /// </summary>
    public partial class PA_VisitorOfficerForm : PA_VisitorMilitaryForm
    {
    /// <summary>
    /// Misafir Subay  Kabul 
    /// </summary>
        protected TTObjectClasses.PA_VisitorOfficer _PA_VisitorOfficer
        {
            get { return (TTObjectClasses.PA_VisitorOfficer)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox MilitaryClass;
        protected ITTObjectListBox Rank;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("87e16ba5-03d9-4dd6-b592-0a283dc320fc"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("46abb124-cba6-4d55-9d1c-4150299c9fcb"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("3a4b165d-88f5-4da2-a45c-5a31a657ec1c"));
            Rank = (ITTObjectListBox)AddControl(new Guid("40b2c678-5bd9-40de-8bad-63bf8047c392"));
            base.InitializeControls();
        }

        public PA_VisitorOfficerForm() : base("PA_VISITOROFFICER", "PA_VisitorOfficerForm")
        {
        }

        protected PA_VisitorOfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}