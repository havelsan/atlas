
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
    /// Misafir XXXXXX Ögrenci  Ailesi Kabulü
    /// </summary>
    public partial class PA_VisitorCadetFamilyForm : PA_VisitorMilitaryFamiliyForm
    {
    /// <summary>
    /// Misafir XXXXXX Ögrenci Ailesi Kabul
    /// </summary>
        protected TTObjectClasses.PA_VisitorCadetFamily _PA_VisitorCadetFamily
        {
            get { return (TTObjectClasses.PA_VisitorCadetFamily)_ttObject; }
        }

        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel ttlabel11;
        override protected void InitializeControls()
        {
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("7a55a0c0-e442-4d24-b8cf-b3fb04508682"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("a8b4b7f2-f0f3-43e0-aabe-99ae9d473b3b"));
            base.InitializeControls();
        }

        public PA_VisitorCadetFamilyForm() : base("PA_VISITORCADETFAMILY", "PA_VisitorCadetFamilyForm")
        {
        }

        protected PA_VisitorCadetFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}