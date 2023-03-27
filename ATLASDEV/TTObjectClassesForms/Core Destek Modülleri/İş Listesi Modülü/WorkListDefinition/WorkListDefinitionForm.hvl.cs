
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
    /// İş Listesi Tanımı
    /// </summary>
    public partial class WorkListDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.WorkListDefinition _WorkListDefinition
        {
            get { return (TTObjectClasses.WorkListDefinition)_ttObject; }
        }

        protected ITTCheckBox ttcheckbox1;
        protected ITTTextBox tttextbox2;
        protected ITTPictureBoxControl ttpictureboxcontrol1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ColumsTabPage;
        protected ITTGrid ColumnDefinitions;
        protected ITTTextBoxColumn Caption;
        protected ITTTextBoxColumn ColumnName;
        protected ITTCheckBoxColumn IsUnique;
        protected ITTTextBoxColumn TypeName;
        protected ITTTextBoxColumn MemberName;
        protected ITTTextBoxColumn ColumnWidth;
        protected ITTCheckBoxColumn IsVisible;
        protected ITTTextBoxColumn ColumnOrder;
        protected ITTCheckBoxColumn IsEnum;
        protected ITTCheckBoxColumn IsObject;
        protected ITTTextBoxColumn DateFormat;
        protected ITTTabPage MenuDefinitionsTabPage;
        protected ITTGrid MenuDefinitions;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn tttextboxcolumn3;
        protected ITTTabPage CriterionTabPage;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTTextBoxColumn tttextboxcolumn5;
        protected ITTTextBoxColumn DefaultValue;
        protected ITTTextBox RightDefID;
        protected ITTTextBox FormName;
        protected ITTTextBox WLCaption;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox ReportDefName;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelFormName;
        protected ITTLabel labelCaption;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        protected ITTLabel lblReportDefName;
        override protected void InitializeControls()
        {
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("eab51ffb-6018-4001-bbbc-841d1800ede1"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("f93a029f-9652-4299-a7c5-7679cc6dbfe0"));
            ttpictureboxcontrol1 = (ITTPictureBoxControl)AddControl(new Guid("4304cd3f-5a97-4954-90dc-943e0e8f82d1"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f9875226-d566-44b5-b016-f08791dff182"));
            ColumsTabPage = (ITTTabPage)AddControl(new Guid("6a053b4e-1fba-49b2-9a5f-bc294c862512"));
            ColumnDefinitions = (ITTGrid)AddControl(new Guid("dc339792-dbea-480e-9512-4db03f5e39d6"));
            Caption = (ITTTextBoxColumn)AddControl(new Guid("ca1dd868-7027-4204-9e21-29b719dd687a"));
            ColumnName = (ITTTextBoxColumn)AddControl(new Guid("487ef672-ed7e-4f5b-a586-32982abc507f"));
            IsUnique = (ITTCheckBoxColumn)AddControl(new Guid("cabaeafc-67fc-4a41-bbc2-c8b2123db283"));
            TypeName = (ITTTextBoxColumn)AddControl(new Guid("8ce40835-7bcd-46ce-829f-bf69710fe262"));
            MemberName = (ITTTextBoxColumn)AddControl(new Guid("94dd834d-56c5-4867-ab02-79b950d79d9b"));
            ColumnWidth = (ITTTextBoxColumn)AddControl(new Guid("abcd67f4-e7be-4bd7-9afb-a1f37216d5fe"));
            IsVisible = (ITTCheckBoxColumn)AddControl(new Guid("973ba7b1-3b09-405a-a0a9-c6b4323878ab"));
            ColumnOrder = (ITTTextBoxColumn)AddControl(new Guid("ffe40cf2-497d-43c2-b3f2-95ab913ad444"));
            IsEnum = (ITTCheckBoxColumn)AddControl(new Guid("8a356ebd-99cc-49f5-9ea5-57fb600f290f"));
            IsObject = (ITTCheckBoxColumn)AddControl(new Guid("23855ba4-4acf-49b0-a6c9-19230e6e4fcd"));
            DateFormat = (ITTTextBoxColumn)AddControl(new Guid("d8d69d13-42d9-43ba-8ce9-eb805ac7e60e"));
            MenuDefinitionsTabPage = (ITTTabPage)AddControl(new Guid("51a1b4e1-7378-4715-b308-d65ad05d4122"));
            MenuDefinitions = (ITTGrid)AddControl(new Guid("44e61ad0-8bd6-466f-9740-9b198709c327"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("fa7c129f-288d-400a-a65e-32f343f3870c"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("1bd54815-cc2f-4ec7-a9e0-b919cac80100"));
            tttextboxcolumn3 = (ITTTextBoxColumn)AddControl(new Guid("224d369f-3e42-4ce5-a231-c05357488321"));
            CriterionTabPage = (ITTTabPage)AddControl(new Guid("fb0a1144-23a3-43ec-af92-5ea5ef60d26d"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("ad8f1e70-6e92-4226-ad84-391f63da3fcf"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("8ec5db7b-8401-4591-9e0b-a76d8ce79d64"));
            tttextboxcolumn5 = (ITTTextBoxColumn)AddControl(new Guid("6859fbc9-e73e-4ecd-b89a-51c51a56f31c"));
            DefaultValue = (ITTTextBoxColumn)AddControl(new Guid("f648202c-bf9e-4ea1-a17a-764e8146d4e6"));
            RightDefID = (ITTTextBox)AddControl(new Guid("0b292e79-e1fb-4a92-8518-61471cee37c2"));
            FormName = (ITTTextBox)AddControl(new Guid("430d6878-0750-473b-891e-07abcd88d4d1"));
            WLCaption = (ITTTextBox)AddControl(new Guid("6c82b9d3-301e-4bef-8bd9-df4cd18b6c95"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("d6180d1a-8f8d-412f-a667-b6c6a06bf735"));
            ReportDefName = (ITTTextBox)AddControl(new Guid("e8ed1939-3414-4abc-8b07-38b467516538"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("24f614d2-8ef9-460f-a05f-c3774be8d126"));
            labelFormName = (ITTLabel)AddControl(new Guid("60f47fed-38bf-420b-b94b-536cd8417c07"));
            labelCaption = (ITTLabel)AddControl(new Guid("4ca72f32-c643-4e7d-be48-e6b6dc272791"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2173a824-9525-45b3-8690-52684f504bf5"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5ec2c7fd-da2c-4c6b-a093-ef4a5b7055e6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bc39dfb3-af8a-4b3c-a562-dff137471f10"));
            lblReportDefName = (ITTLabel)AddControl(new Guid("e86545e1-39db-4f0c-90b4-aa3f046fe43d"));
            base.InitializeControls();
        }

        public WorkListDefinitionForm() : base("WORKLISTDEFINITION", "WorkListDefinitionForm")
        {
        }

        protected WorkListDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}