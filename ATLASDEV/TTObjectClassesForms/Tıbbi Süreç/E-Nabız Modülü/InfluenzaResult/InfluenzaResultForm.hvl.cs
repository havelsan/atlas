
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
    public partial class InfluenzaResultForm : TTForm
    {
    /// <summary>
    /// Influenza Sonuş Ekranı
    /// </summary>
        protected TTObjectClasses.InfluenzaResult _InfluenzaResult
        {
            get { return (TTObjectClasses.InfluenzaResult)_ttObject; }
        }

        protected ITTLabel labelErrorMessage;
        protected ITTTextBox ErrorMessage;
        protected ITTLabel labelInfluenzaResultProp;
        protected ITTEnumComboBox InfluenzaResultProp;
        override protected void InitializeControls()
        {
            labelErrorMessage = (ITTLabel)AddControl(new Guid("5e76a68d-d035-4e57-9149-ab130ed07338"));
            ErrorMessage = (ITTTextBox)AddControl(new Guid("dfb9bece-5194-4d62-bab5-e0c59e962e9a"));
            labelInfluenzaResultProp = (ITTLabel)AddControl(new Guid("a7079863-7c5c-4360-a526-2a9f561ed1c5"));
            InfluenzaResultProp = (ITTEnumComboBox)AddControl(new Guid("4b5884ee-810f-4e4a-b47f-db3111e6018f"));
            base.InitializeControls();
        }

        public InfluenzaResultForm() : base("INFLUENZARESULT", "InfluenzaResultForm")
        {
        }

        protected InfluenzaResultForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}