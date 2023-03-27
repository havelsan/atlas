
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
    /// İşcilik Saat Ücreti Tanımlama
    /// </summary>
    public partial class WorkLoadPriceDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.WorkLoadPriceDefinition _WorkLoadPriceDefinition
        {
            get { return (TTObjectClasses.WorkLoadPriceDefinition)_ttObject; }
        }

        protected ITTLabel labelTechnicianWorkLoadPrice;
        protected ITTTextBox TechnicianWorkLoadPrice;
        protected ITTTextBox EngineerWorkLoadPrice;
        protected ITTLabel labelEngineerWorkLoadPrice;
        override protected void InitializeControls()
        {
            labelTechnicianWorkLoadPrice = (ITTLabel)AddControl(new Guid("2f4f8771-84c0-4d60-8d7f-9787bbfb4a04"));
            TechnicianWorkLoadPrice = (ITTTextBox)AddControl(new Guid("0bcc647c-2b0a-4d39-b5bf-28d9f2cdeadd"));
            EngineerWorkLoadPrice = (ITTTextBox)AddControl(new Guid("ea2adb49-2ccb-4b37-b3e0-1884dc89ab3b"));
            labelEngineerWorkLoadPrice = (ITTLabel)AddControl(new Guid("744e543e-c8c2-4e29-99d8-8b5ef9b3c2d0"));
            base.InitializeControls();
        }

        public WorkLoadPriceDefinitionForm() : base("WORKLOADPRICEDEFINITION", "WorkLoadPriceDefinitionForm")
        {
        }

        protected WorkLoadPriceDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}