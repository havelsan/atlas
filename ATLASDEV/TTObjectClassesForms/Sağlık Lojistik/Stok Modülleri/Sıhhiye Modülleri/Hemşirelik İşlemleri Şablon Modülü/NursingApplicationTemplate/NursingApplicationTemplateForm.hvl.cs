
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
    /// Hemşilerik İşlemleri Şablon Oluşturma Formu
    /// </summary>
    public partial class NursingApplicationTemplateForm : TTForm
    {
    /// <summary>
    /// Hemşirelik İşlemleri Şablon
    /// </summary>
        protected TTObjectClasses.NursingApplicationTemplate _NursingApplicationTemplate
        {
            get { return (TTObjectClasses.NursingApplicationTemplate)_ttObject; }
        }

        protected ITTLabel labelTemplateName;
        protected ITTTextBox TemplateName;
        protected ITTGrid NursingAppTempDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn MBarcode;
        protected ITTTextBoxColumn DistributionType;
        override protected void InitializeControls()
        {
            labelTemplateName = (ITTLabel)AddControl(new Guid("49d7f761-4f21-44db-92cb-a2b38478f779"));
            TemplateName = (ITTTextBox)AddControl(new Guid("cdb371b5-e650-4539-9d33-3b5c2db6186a"));
            NursingAppTempDetails = (ITTGrid)AddControl(new Guid("b7f6db38-0234-4908-9ce1-c8de1fb5c4ae"));
            Material = (ITTListBoxColumn)AddControl(new Guid("0125735e-0fa6-4587-9a8f-60354dc04c55"));
            MBarcode = (ITTTextBoxColumn)AddControl(new Guid("4db825ce-d6b8-4eb6-8779-8d1007b3dfb0"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("0c0b59c8-01ea-4c87-af31-2009e56e7100"));
            base.InitializeControls();
        }

        public NursingApplicationTemplateForm() : base("NURSINGAPPLICATIONTEMPLATE", "NursingApplicationTemplateForm")
        {
        }

        protected NursingApplicationTemplateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}