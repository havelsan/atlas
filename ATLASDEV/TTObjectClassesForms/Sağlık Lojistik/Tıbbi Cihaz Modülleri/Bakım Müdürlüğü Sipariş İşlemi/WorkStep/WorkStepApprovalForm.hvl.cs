
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
    public partial class WorkStepApprovalForm : TTForm
    {
    /// <summary>
    /// Yardımcı Atölye İş İstek
    /// </summary>
        protected TTObjectClasses.WorkStep _WorkStep
        {
            get { return (TTObjectClasses.WorkStep)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        protected ITTLabel labelResponsibleUser;
        protected ITTObjectListBox ResponsibleUser;
        protected ITTLabel labelWorkShop;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelSection;
        protected ITTObjectListBox Section;
        protected ITTLabel labelSenderSection;
        protected ITTObjectListBox SenderSection;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTLabel labelRequestNo;
        protected ITTTextBox RequestNo;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("1d791819-d167-4ce0-b053-c8c1c243e0c8"));
            labelResponsibleUser = (ITTLabel)AddControl(new Guid("c285cf9b-922e-446d-9d53-a9e8b143f4c4"));
            ResponsibleUser = (ITTObjectListBox)AddControl(new Guid("7d29ec09-b945-44fa-85f2-d00506dbbd07"));
            labelWorkShop = (ITTLabel)AddControl(new Guid("889a7154-95e3-4e62-adf2-776bd52f37ce"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("fb36dec3-0e83-4dc6-b217-db364f9aeade"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("da74acad-642d-4777-abea-8559e4258641"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("57d4db9a-8687-44d6-a0b8-8003dcb357ca"));
            labelSection = (ITTLabel)AddControl(new Guid("9e34d812-f5fe-4c0f-bdef-91034b8ef5ce"));
            Section = (ITTObjectListBox)AddControl(new Guid("84345d92-d017-4c53-a222-295fac9ea179"));
            labelSenderSection = (ITTLabel)AddControl(new Guid("212977bd-af22-4d52-a226-21ca1637c91b"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("1704ade5-f33a-443f-9bc7-4f7e3c0229d4"));
            labelDescription = (ITTLabel)AddControl(new Guid("b063bb56-9c6a-4397-87d6-5076c6f9046b"));
            Description = (ITTTextBox)AddControl(new Guid("702bfeed-5e02-4365-a093-dd3bbddf937f"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("bf665025-b1d5-4233-921c-ad75e381dd5a"));
            RequestNo = (ITTTextBox)AddControl(new Guid("31971c48-476a-4a9e-8108-fe1af8bf4e83"));
            base.InitializeControls();
        }

        public WorkStepApprovalForm() : base("WORKSTEP", "WorkStepApprovalForm")
        {
        }

        protected WorkStepApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}