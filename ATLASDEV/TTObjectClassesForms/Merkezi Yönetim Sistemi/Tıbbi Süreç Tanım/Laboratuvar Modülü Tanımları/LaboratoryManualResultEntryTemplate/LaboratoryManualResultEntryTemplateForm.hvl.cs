
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
    /// Laboratuvar Manual Sonuç Giriş Panel Tanım Formu
    /// </summary>
    public partial class LaboratoryManualResultEntryTemplateForm : TTForm
    {
    /// <summary>
    /// Laboratuvar Manual Sonuç Giriş Panel Tanımı
    /// </summary>
        protected TTObjectClasses.LaboratoryManualResultEntryTemplate _LaboratoryManualResultEntryTemplate
        {
            get { return (TTObjectClasses.LaboratoryManualResultEntryTemplate)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ResUser;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn LaboratoryTest;
        protected ITTCheckBoxColumn SelectedTest;
        protected ITTLabel ttlabel2;
        protected ITTTextBox TemplateName;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("5fd3baa6-19d9-4730-bf25-a35bcb7f3a00"));
            ResUser = (ITTObjectListBox)AddControl(new Guid("63dff935-afb8-4a39-8867-050fd7a0afd5"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("dbc91368-1ecc-4d42-a47c-03bce08fcae6"));
            LaboratoryTest = (ITTListBoxColumn)AddControl(new Guid("79886d45-0742-4bb3-8c4f-f6c5cadfa26e"));
            SelectedTest = (ITTCheckBoxColumn)AddControl(new Guid("e99ee87c-714f-40cb-a52b-2a469c755baf"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("790fbfcf-c62b-43b3-b570-06610d4d8cdb"));
            TemplateName = (ITTTextBox)AddControl(new Guid("894c972b-f0d2-4e6c-9540-ca82bab64438"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a0ed1b36-4c2b-4e18-94b4-6f917b32f88d"));
            base.InitializeControls();
        }

        public LaboratoryManualResultEntryTemplateForm() : base("LABORATORYMANUALRESULTENTRYTEMPLATE", "LaboratoryManualResultEntryTemplateForm")
        {
        }

        protected LaboratoryManualResultEntryTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}