
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
    /// Kasa Defteri
    /// </summary>
    public partial class CashBookPropertiesForm : TTForm
    {
    /// <summary>
    /// Muhasebe Defterleri
    /// </summary>
        protected TTObjectClasses.MhSAccountingBooks _MhSAccountingBooks
        {
            get { return (TTObjectClasses.MhSAccountingBooks)_ttObject; }
        }

        protected ITTDateTimePicker FinishDate;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelStartDate;
        protected ITTCheckBox ttcheckbox2;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTGroupBox ttgroupbox1;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelFinishDate;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTTextBox tttextbox1;
        override protected void InitializeControls()
        {
            FinishDate = (ITTDateTimePicker)AddControl(new Guid("9fc6d6d8-1237-46b6-b875-0575edde3451"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("955dc988-0420-4af0-b0e6-15cf8f7c6c8e"));
            labelStartDate = (ITTLabel)AddControl(new Guid("0bf10ab8-94d8-47d0-a580-0c7b7c68f98a"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("29ae23d4-570d-4a07-ad05-533b4c7b22bf"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("af609d94-6d7c-4af5-ab46-8e4df03b43da"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("dffa211e-9d1e-4b15-a22e-7633c3dfc2ff"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("6220dbca-e132-42a8-82c3-82186e7978a2"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("1198c5a2-dc6e-4af0-baf9-a0883fffcb2c"));
            labelFinishDate = (ITTLabel)AddControl(new Guid("4d7e8bd8-f889-452a-aa61-c02cd779c0b1"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("10de65c0-736d-4084-9619-e6db1c92f1c7"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2f4a55f6-28a7-49f6-84b0-d73e7457df03"));
            base.InitializeControls();
        }

        public CashBookPropertiesForm() : base("MHSACCOUNTINGBOOKS", "CashBookPropertiesForm")
        {
        }

        protected CashBookPropertiesForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}