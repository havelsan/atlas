
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
    /// Medula İş Listesi Kriterleri
    /// </summary>
    public partial class MedulaWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTComboBox StatusBox;
        protected ITTLabel ttlabel2;
        protected ITTTextBox MedulaActionID;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            StatusBox = (ITTComboBox)AddControl(new Guid("0b3ffa98-67de-4cab-b512-c9f2c84c0a22"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8986edc4-86f0-47d4-b913-57e3f01900f9"));
            MedulaActionID = (ITTTextBox)AddControl(new Guid("742ca85d-f4ac-4c3a-99b7-adf1811c93f1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("906be0fc-98be-4b32-b6e3-84b48e1baf9c"));
            base.InitializeControls();
        }

        public MedulaWLCriteriaForm() : base("MedulaWLCriteriaForm")
        {
        }

        protected MedulaWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}