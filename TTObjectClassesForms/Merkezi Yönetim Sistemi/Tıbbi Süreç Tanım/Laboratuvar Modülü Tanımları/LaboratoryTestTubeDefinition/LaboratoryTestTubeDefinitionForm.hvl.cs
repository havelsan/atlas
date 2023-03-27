
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
    /// Laboratuvar Test Tüp Tanımları
    /// </summary>
    public partial class LaboratoryTestTubeDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.LaboratoryTestTubeDefinition _LaboratoryTestTubeDefinition
        {
            get { return (TTObjectClasses.LaboratoryTestTubeDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox2;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("a35572b9-faa4-460e-97a8-9fd013b42cbf"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d134ccc4-a268-41f1-8a94-c87407bbaa77"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("f6188f97-273b-41ed-8884-57c0bdbb615e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("01de11be-c843-4732-8904-7fac39951bbf"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("fc8c1f06-5428-4439-9547-dc0a72e2dbfa"));
            base.InitializeControls();
        }

        public LaboratoryTestTubeDefinitionForm() : base("LABORATORYTESTTUBEDEFINITION", "LaboratoryTestTubeDefinitionForm")
        {
        }

        protected LaboratoryTestTubeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}