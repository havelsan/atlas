
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
    /// Sevk Süresi Uzatma Sebep Tanımları
    /// </summary>
    public partial class ReasonOfDayLimitChangeDefinitionForm : TTForm
    {
    /// <summary>
    /// Sevk Süresi Uzatma Sebepleri
    /// </summary>
        protected TTObjectClasses.ReasonOfDayLimitChangeDefinition _ReasonOfDayLimitChangeDefinition
        {
            get { return (TTObjectClasses.ReasonOfDayLimitChangeDefinition)_ttObject; }
        }

        protected ITTTextBox REASON;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox CODE;
        override protected void InitializeControls()
        {
            REASON = (ITTTextBox)AddControl(new Guid("6eb50515-e738-4f8e-b0c6-dde55854046c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("48485d2e-28d8-4ef9-bd92-5bc61cddccf0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d4b90340-59f3-4f35-9469-c730ee0ac799"));
            CODE = (ITTTextBox)AddControl(new Guid("b39db7f6-7193-4251-88c2-67da04cf25a3"));
            base.InitializeControls();
        }

        public ReasonOfDayLimitChangeDefinitionForm() : base("REASONOFDAYLIMITCHANGEDEFINITION", "ReasonOfDayLimitChangeDefinitionForm")
        {
        }

        protected ReasonOfDayLimitChangeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}