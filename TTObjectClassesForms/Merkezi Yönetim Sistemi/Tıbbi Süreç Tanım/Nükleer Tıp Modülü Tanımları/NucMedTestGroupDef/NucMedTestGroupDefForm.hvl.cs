
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
    /// Nükleer Tıp Test Grubu Tanımları
    /// </summary>
    public partial class NucMedTestGroupDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Nükleer Tıp Test Grup Tanımı
    /// </summary>
        protected TTObjectClasses.NucMedTestGroupDef _NucMedTestGroupDef
        {
            get { return (TTObjectClasses.NucMedTestGroupDef)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTTextBox tabOrdertxt;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelName;
        protected ITTTextBox nametxt;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("527086b1-127f-4859-9cbf-d7753267aca2"));
            tabOrdertxt = (ITTTextBox)AddControl(new Guid("943a30db-d43a-4ad4-b02e-bb59fd74a098"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("56ea8539-c960-45bf-8f64-27148d086813"));
            labelName = (ITTLabel)AddControl(new Guid("e3def318-472f-402c-b4c6-89b984262b0e"));
            nametxt = (ITTTextBox)AddControl(new Guid("435b4bb5-0c6e-4b38-8b93-bdf26897ddab"));
            base.InitializeControls();
        }

        public NucMedTestGroupDefForm() : base("NUCMEDTESTGROUPDEF", "NucMedTestGroupDefForm")
        {
        }

        protected NucMedTestGroupDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}