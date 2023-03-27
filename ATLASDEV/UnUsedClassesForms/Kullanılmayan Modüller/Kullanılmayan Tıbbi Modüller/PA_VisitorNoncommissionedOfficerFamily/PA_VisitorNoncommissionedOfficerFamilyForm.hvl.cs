
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
    /// Misafir Astsubay Ailesi Kabulü
    /// </summary>
    public partial class PA_VisitorNoncommissionedOfficerFamilyForm : PA_VisitorMilitaryFamiliyForm
    {
    /// <summary>
    /// Misafir Astsubay Ailesi Kabulü
    /// </summary>
        protected TTObjectClasses.PA_VisitorNoncommissionedOfficerFamily _PA_VisitorNoncommissionedOfficerFamily
        {
            get { return (TTObjectClasses.PA_VisitorNoncommissionedOfficerFamily)_ttObject; }
        }

        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTObjectListBox ttobjectlistbox1;
        override protected void InitializeControls()
        {
            ttlabel11 = (ITTLabel)AddControl(new Guid("72b00349-8451-42c7-b994-9c2a1bc05d22"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("515d9505-4335-4226-8914-7ada9c424f57"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("db9a9d0c-6597-404c-9a80-05ed018677ad"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("453d1683-55d6-484c-8b0f-a7b11446b47c"));
            base.InitializeControls();
        }

        public PA_VisitorNoncommissionedOfficerFamilyForm() : base("PA_VISITORNONCOMMISSIONEDOFFICERFAMILY", "PA_VisitorNoncommissionedOfficerFamilyForm")
        {
        }

        protected PA_VisitorNoncommissionedOfficerFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}