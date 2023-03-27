
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
    /// Genel İş Listesi
    /// </summary>
    public partial class GeneralWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTTextBox ActionID;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ActionID = (ITTTextBox)AddControl(new Guid("7a176ed9-b8b9-4a7b-8011-055c80c5d951"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e7363e10-6daf-44ca-9cc5-c1ffe7a440ba"));
            base.InitializeControls();
        }

        public GeneralWLCriteriaForm() : base("GeneralWLCriteriaForm")
        {
        }

        protected GeneralWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}