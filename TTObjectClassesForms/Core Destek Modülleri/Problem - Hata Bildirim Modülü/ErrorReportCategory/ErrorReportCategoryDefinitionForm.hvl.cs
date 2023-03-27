
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
    /// Problem / Hata Kategorisi Tanımlama
    /// </summary>
    public partial class ErrorReportCategoryDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.ErrorReportCategory _ErrorReportCategory
        {
            get { return (TTObjectClasses.ErrorReportCategory)_ttObject; }
        }

        protected ITTCheckBox isActiveCheckbox;
        protected ITTLabel labelOwnerResource;
        protected ITTObjectListBox OwnerResource;
        protected ITTObjectListBox MainCategory;
        protected ITTLabel labelMainCategory;
        protected ITTLabel labelCategoryPriority;
        protected ITTEnumComboBox CategoryPriority;
        protected ITTCheckBox InventoryRequired;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            isActiveCheckbox = (ITTCheckBox)AddControl(new Guid("8e49a093-fed1-4bef-9c7a-46500d62893e"));
            labelOwnerResource = (ITTLabel)AddControl(new Guid("9181523c-ef1b-44eb-95bc-64e11e68e261"));
            OwnerResource = (ITTObjectListBox)AddControl(new Guid("9b6d40d9-1a00-4e30-a869-742bf570f9a9"));
            MainCategory = (ITTObjectListBox)AddControl(new Guid("81e6e47e-660b-4c66-a9ba-8d08d0646113"));
            labelMainCategory = (ITTLabel)AddControl(new Guid("dd56c26c-a4f1-4f2f-b300-c45e68573838"));
            labelCategoryPriority = (ITTLabel)AddControl(new Guid("8d32af5a-5f1b-4919-8ccc-8f181223e8be"));
            CategoryPriority = (ITTEnumComboBox)AddControl(new Guid("4ab52bf7-b038-4740-9568-2a9a2f06d371"));
            InventoryRequired = (ITTCheckBox)AddControl(new Guid("39e60aa2-12e1-4642-a229-2ea01b5301e9"));
            labelToResource = (ITTLabel)AddControl(new Guid("56d7eca9-13a8-4da3-862f-af8d73aaa39b"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("afb530c3-4ed0-4bb3-939c-d5dcca9a64d5"));
            labelName = (ITTLabel)AddControl(new Guid("49d2fb04-68a0-4684-8e75-d7c6f369125a"));
            Name = (ITTTextBox)AddControl(new Guid("da839c8b-4377-471f-95a7-7f7e45beffe4"));
            Code = (ITTTextBox)AddControl(new Guid("575710a7-9926-4744-bf7e-75da5ae44bb2"));
            labelCode = (ITTLabel)AddControl(new Guid("f13646cd-3280-4c38-8777-cff21d31e598"));
            base.InitializeControls();
        }

        public ErrorReportCategoryDefinitionForm() : base("ERRORREPORTCATEGORY", "ErrorReportCategoryDefinitionForm")
        {
        }

        protected ErrorReportCategoryDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}