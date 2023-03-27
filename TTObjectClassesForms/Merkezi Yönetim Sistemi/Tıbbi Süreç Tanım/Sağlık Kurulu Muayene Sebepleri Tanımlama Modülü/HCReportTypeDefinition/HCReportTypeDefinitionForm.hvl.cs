
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
    public partial class HCReportTypeDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Sağlık Kurulu Rapor Grubu Tanımlama
    /// </summary>
        protected TTObjectClasses.HCReportTypeDefinition _HCReportTypeDefinition
        {
            get { return (TTObjectClasses.HCReportTypeDefinition)_ttObject; }
        }

        protected ITTCheckBox SinglePhysicianReport;
        protected ITTCheckBox IsStatusNotification;
        protected ITTCheckBox IsDisabled;
        protected ITTCheckBox active;
        protected ITTLabel labelReportGroupName;
        protected ITTTextBox ReportGroupName;
        protected ITTTextBox Code;
        protected ITTLabel labelSKRSRaporTuru;
        protected ITTObjectListBox SKRSRaporTuru;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            SinglePhysicianReport = (ITTCheckBox)AddControl(new Guid("00504edc-3e8f-41df-b7d3-10db0113e3cd"));
            IsStatusNotification = (ITTCheckBox)AddControl(new Guid("da42a9c2-c456-4cee-b4a3-4be3384f5d72"));
            IsDisabled = (ITTCheckBox)AddControl(new Guid("fdaac5b2-cabc-4de6-a4e5-6d79254e5815"));
            active = (ITTCheckBox)AddControl(new Guid("a70ebe21-d22f-4bad-8e9e-d12316233a9c"));
            labelReportGroupName = (ITTLabel)AddControl(new Guid("8da6a1b7-8577-46da-bb97-d2cb70c892e0"));
            ReportGroupName = (ITTTextBox)AddControl(new Guid("4c1b4fd4-bae2-4050-9ae4-63563dd862e2"));
            Code = (ITTTextBox)AddControl(new Guid("d4abd82d-b394-4fcd-8bd2-5e5df2b40411"));
            labelSKRSRaporTuru = (ITTLabel)AddControl(new Guid("3a4e44aa-5302-4241-a07a-d462dced61da"));
            SKRSRaporTuru = (ITTObjectListBox)AddControl(new Guid("ef2c0cae-0191-4497-918a-08cfcf5fe575"));
            labelCode = (ITTLabel)AddControl(new Guid("ba86b90f-e48f-41fb-9637-b67e306bb47c"));
            base.InitializeControls();
        }

        public HCReportTypeDefinitionForm() : base("HCREPORTTYPEDEFINITION", "HCReportTypeDefinitionForm")
        {
        }

        protected HCReportTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}