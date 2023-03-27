
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
    /// Misafir Subay Ailesi Kabulü
    /// </summary>
    public partial class PA_VisitorOfficerFamilyForm : PA_VisitorMilitaryFamiliyForm
    {
    /// <summary>
    /// Misafir Subay  Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_VisitorOfficerFamily _PA_VisitorOfficerFamily
        {
            get { return (TTObjectClasses.PA_VisitorOfficerFamily)_ttObject; }
        }

        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTObjectListBox ttobjectlistbox1;
        override protected void InitializeControls()
        {
            ttlabel11 = (ITTLabel)AddControl(new Guid("5e015e30-626f-470f-95e1-c67643eb9a02"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("e34ddce0-ecff-4aa2-ae3b-487538dc1a8d"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("fa4764d9-fbab-4c35-9028-4e3be78b855e"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("29bb3f72-93b9-49e5-a979-700ebffadf6b"));
            base.InitializeControls();
        }

        public PA_VisitorOfficerFamilyForm() : base("PA_VISITOROFFICERFAMILY", "PA_VisitorOfficerFamilyForm")
        {
        }

        protected PA_VisitorOfficerFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}