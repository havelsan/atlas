
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
    /// Yardımcı Atölye İş İstek
    /// </summary>
    public partial class WorkStepNewForm : TTForm
    {
    /// <summary>
    /// Yardımcı Atölye İş İstek
    /// </summary>
        protected TTObjectClasses.WorkStep _WorkStep
        {
            get { return (TTObjectClasses.WorkStep)_ttObject; }
        }

        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelSection;
        protected ITTObjectListBox Section;
        protected ITTLabel labelSenderSection;
        protected ITTObjectListBox SenderSection;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNo;
        protected ITTLabel labelRequestNo;
        override protected void InitializeControls()
        {
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("e4ff3896-bded-4025-a4b9-ae5388e7a10a"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("067a6a8e-8ca4-4ab8-b96d-fbb7942e3a61"));
            labelSection = (ITTLabel)AddControl(new Guid("7e9f3d28-3ed1-4fda-92cc-79b67c810eb5"));
            Section = (ITTObjectListBox)AddControl(new Guid("fd7139b4-9a12-461e-8be4-ceee6ac834a3"));
            labelSenderSection = (ITTLabel)AddControl(new Guid("088374cf-5596-47a8-ab7b-76083431c1ff"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("52ab248a-fbcf-473d-af9c-2ca83dcefb4d"));
            labelDescription = (ITTLabel)AddControl(new Guid("c9fa88e0-ad18-48c5-9dca-e92465754359"));
            Description = (ITTTextBox)AddControl(new Guid("ec059b32-c397-46ca-bf68-b3d9203b50ff"));
            RequestNo = (ITTTextBox)AddControl(new Guid("027947a8-c01f-40ac-841a-f5e69aa2e439"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("416d9354-99d9-48a6-a0a4-c89b70ec4b32"));
            base.InitializeControls();
        }

        public WorkStepNewForm() : base("WORKSTEP", "WorkStepNewForm")
        {
        }

        protected WorkStepNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}