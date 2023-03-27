
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
    /// Firma Bilgileri
    /// </summary>
    public partial class FirmDetailForm : TTForm
    {
    /// <summary>
    /// Firma
    /// </summary>
        protected TTObjectClasses.MhSFirm _MhSFirm
        {
            get { return (TTObjectClasses.MhSFirm)_ttObject; }
        }

        protected ITTLabel labelActivePeriod;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTGrid Periods;
        override protected void InitializeControls()
        {
            labelActivePeriod = (ITTLabel)AddControl(new Guid("ed3d595e-4785-4395-a8c8-0640b0bf206e"));
            Name = (ITTTextBox)AddControl(new Guid("ab1fa2f4-ef4e-4ed3-b63e-5215a8be1fa1"));
            labelName = (ITTLabel)AddControl(new Guid("40cad12a-fe35-4b5a-86f1-49a973b86b45"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("7499c326-ad14-4073-9f48-b62fe211276b"));
            Periods = (ITTGrid)AddControl(new Guid("4cbd66bb-d4a9-49ce-9efe-b96b4711fef5"));
            base.InitializeControls();
        }

        public FirmDetailForm() : base("MHSFIRM", "FirmDetailForm")
        {
        }

        protected FirmDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}