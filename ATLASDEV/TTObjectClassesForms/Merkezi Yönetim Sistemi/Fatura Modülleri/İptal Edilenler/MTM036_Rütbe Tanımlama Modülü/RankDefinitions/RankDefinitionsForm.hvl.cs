
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
    /// Rütbe Tanımları
    /// </summary>
    public partial class RankDefinitionsForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Rütbe Tanımları
    /// </summary>
        protected TTObjectClasses.RankDefinitions _RankDefinitions
        {
            get { return (TTObjectClasses.RankDefinitions)_ttObject; }
        }

        protected ITTLabel labelOrderNO;
        protected ITTTextBox OrderNO;
        protected ITTTextBox ExternalCode;
        protected ITTTextBox Name;
        protected ITTTextBox ID;
        protected ITTTextBox Code;
        protected ITTLabel labelExternalCode;
        protected ITTLabel labelName;
        protected ITTLabel labelID;
        protected ITTLabel labelCode;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox ttenumcombobox1;
        override protected void InitializeControls()
        {
            labelOrderNO = (ITTLabel)AddControl(new Guid("57b43409-83e0-49bd-a935-22d4f6375d06"));
            OrderNO = (ITTTextBox)AddControl(new Guid("3a6c3d79-696f-417f-a899-6547a4d8fc85"));
            ExternalCode = (ITTTextBox)AddControl(new Guid("91d6ef19-a8f2-45ea-bd72-aabeebbf8064"));
            Name = (ITTTextBox)AddControl(new Guid("aed245e1-c49c-4ae2-a424-950c0f2c1e10"));
            ID = (ITTTextBox)AddControl(new Guid("4f5b4ee6-7782-4063-afe0-90c2dd54ed71"));
            Code = (ITTTextBox)AddControl(new Guid("9e2f0c0c-6b6b-4e11-8fcb-03b9a55b18bd"));
            labelExternalCode = (ITTLabel)AddControl(new Guid("e017e71a-f6e9-4540-8726-07cbea5def1f"));
            labelName = (ITTLabel)AddControl(new Guid("0a464973-7e1a-419b-8def-5339fb341067"));
            labelID = (ITTLabel)AddControl(new Guid("afa06ced-3f44-499f-97f1-dc0ddc87c4c9"));
            labelCode = (ITTLabel)AddControl(new Guid("bd3e7fb2-d5ef-40be-b3d2-79258cedca6d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e3642ccc-5c8e-43a9-b6b9-c6ad260e6c78"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("1d924cde-0fee-4652-bef2-052bdff2f80b"));
            base.InitializeControls();
        }

        public RankDefinitionsForm() : base("RANKDEFINITIONS", "RankDefinitionsForm")
        {
        }

        protected RankDefinitionsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}