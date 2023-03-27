
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
    /// Çalışma Durumu Tanımlama
    /// </summary>
    public partial class WorkStatusDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Çalışma Durumu Tanımlama
    /// </summary>
        protected TTObjectClasses.WorkStatusDefinition _WorkStatusDefinition
        {
            get { return (TTObjectClasses.WorkStatusDefinition)_ttObject; }
        }

        protected ITTLabel labelSortName;
        protected ITTTextBox SortName;
        protected ITTLabel labelExternalCode;
        protected ITTTextBox ExternalCode;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelSortName = (ITTLabel)AddControl(new Guid("07c8d161-bfe4-42f0-994b-ae34f8f0c522"));
            SortName = (ITTTextBox)AddControl(new Guid("0941c35a-3c4b-434c-a4c3-6328dc740df7"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("97a9b536-01aa-494e-98c2-5ad335cdaf8e"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("558c6e84-6209-49c8-8c23-435a71030727"));
            labelName = (ITTLabel)AddControl(new Guid("05a70f1d-4f7d-4335-ac4d-73926e04edfa"));
            Name = (ITTTextBox)AddControl(new Guid("663232aa-32e8-4a93-92ee-8731807ff076"));
            base.InitializeControls();
        }

        public WorkStatusDefinitionForm() : base("WORKSTATUSDEFINITION", "WorkStatusDefinitionForm")
        {
        }

        protected WorkStatusDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}