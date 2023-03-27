
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
    /// Problem Hata Ana Kategori Tanımı
    /// </summary>
    public partial class ErrorReportMainCatDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Problem / Hata Ana Kategori
    /// </summary>
        protected TTObjectClasses.ErrorReportMainCategory _ErrorReportMainCategory
        {
            get { return (TTObjectClasses.ErrorReportMainCategory)_ttObject; }
        }

        protected ITTGrid ErrorReportCategories;
        protected ITTTextBoxColumn CodeErrorReportCategory;
        protected ITTTextBoxColumn NameErrorReportCategory;
        protected ITTListBoxColumn ToResourceErrorReportCategory;
        protected ITTListBoxColumn OwnerResourceErrorReportCategory;
        protected ITTEnumComboBoxColumn CategoryPriorityErrorReportCategory;
        protected ITTCheckBoxColumn InventoryRequiredErrorReportCategory;
        protected ITTCheckBox isActiveCheckBox;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            ErrorReportCategories = (ITTGrid)AddControl(new Guid("fc34daf4-c4b1-4ca0-937e-f65f78c6eff2"));
            CodeErrorReportCategory = (ITTTextBoxColumn)AddControl(new Guid("e8dbc352-294d-49f5-b3ea-845758904030"));
            NameErrorReportCategory = (ITTTextBoxColumn)AddControl(new Guid("8db4ec39-17ed-4f1f-8e8f-d1c27f453373"));
            ToResourceErrorReportCategory = (ITTListBoxColumn)AddControl(new Guid("529fe8e2-0933-4270-948f-a1484166e99d"));
            OwnerResourceErrorReportCategory = (ITTListBoxColumn)AddControl(new Guid("b97e8c17-3db5-4b5b-8f3b-2bfd16db79bc"));
            CategoryPriorityErrorReportCategory = (ITTEnumComboBoxColumn)AddControl(new Guid("0d06eefb-aa71-49fb-a38f-be60206f6a0a"));
            InventoryRequiredErrorReportCategory = (ITTCheckBoxColumn)AddControl(new Guid("6525ad7f-cd0c-43f0-b054-163ba92d5d5b"));
            isActiveCheckBox = (ITTCheckBox)AddControl(new Guid("eb0ea33e-7903-4948-ab17-2a81319d3422"));
            labelName = (ITTLabel)AddControl(new Guid("9b0eb356-2c66-48fd-ba17-9bd4d1e5fad1"));
            Name = (ITTTextBox)AddControl(new Guid("5c8611c5-0fc3-4e10-bec1-6b693c438c8b"));
            Code = (ITTTextBox)AddControl(new Guid("c5ca27bb-8747-4fab-9c34-562fc3ea4854"));
            labelCode = (ITTLabel)AddControl(new Guid("2d9429b3-00b0-4f16-85b2-b4840d19d7ef"));
            base.InitializeControls();
        }

        public ErrorReportMainCatDefinitionForm() : base("ERRORREPORTMAINCATEGORY", "ErrorReportMainCatDefinitionForm")
        {
        }

        protected ErrorReportMainCatDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}