
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
    /// ÜFE Tanımlama
    /// </summary>
    public partial class UFEDefForm : TTDefinitionForm
    {
        protected TTObjectClasses.UFEDefinition _UFEDefinition
        {
            get { return (TTObjectClasses.UFEDefinition)_ttObject; }
        }

        protected ITTLabel labelNameUFESectorDefinition;
        protected ITTObjectListBox NameUFESectorDefinition;
        protected ITTLabel labelIndex;
        protected ITTTextBox Index;
        protected ITTLabel labelMonth;
        protected ITTEnumComboBox Month;
        protected ITTLabel labelYear;
        protected ITTTextBox Year;
        override protected void InitializeControls()
        {
            labelNameUFESectorDefinition = (ITTLabel)AddControl(new Guid("30d85ccd-80c8-4dde-ba9b-9a76e846e339"));
            NameUFESectorDefinition = (ITTObjectListBox)AddControl(new Guid("0c824e4c-55cc-477e-96de-06e6c1254270"));
            labelIndex = (ITTLabel)AddControl(new Guid("5e8454fb-5643-44e1-b02b-8c90006cc1a1"));
            Index = (ITTTextBox)AddControl(new Guid("caaebae1-ed31-4b1a-a627-1f0df493b56c"));
            labelMonth = (ITTLabel)AddControl(new Guid("0ab821b7-06ef-4db1-ade9-279d38fe5098"));
            Month = (ITTEnumComboBox)AddControl(new Guid("329efdad-37f5-460d-a792-27c836e4d902"));
            labelYear = (ITTLabel)AddControl(new Guid("0e90e3a0-0c4b-46d0-b9ac-aecd2ceb8115"));
            Year = (ITTTextBox)AddControl(new Guid("cfabfe5a-7e22-4296-bd04-3fc654598875"));
            base.InitializeControls();
        }

        public UFEDefForm() : base("UFEDEFINITION", "UFEDefForm")
        {
        }

        protected UFEDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}