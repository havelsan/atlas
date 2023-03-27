
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
    /// Yevmiye Defteri
    /// </summary>
    public partial class JournalEntryPropertiesForm : TTForm
    {
    /// <summary>
    /// Muhasebe Defterleri
    /// </summary>
        protected TTObjectClasses.MhSAccountingBooks _MhSAccountingBooks
        {
            get { return (TTObjectClasses.MhSAccountingBooks)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox ttcheckbox5;
        protected ITTGroupBox ttgroupbox1;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTDateTimePicker FinishDate;
        protected ITTLabel labelType;
        protected ITTLabel labelFinishDate;
        protected ITTTextBox SlipNo;
        protected ITTLabel labelOrder;
        protected ITTCheckBox ttcheckbox3;
        protected ITTLabel labelSlipNo;
        protected ITTLabel labelStartDate;
        protected ITTEnumComboBox ttenumcombobox2;
        protected ITTCheckBox Approve;
        protected ITTCheckBox ttcheckbox1;
        protected ITTDateTimePicker StartDate;
        protected ITTCheckBox ttcheckbox2;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("536f9499-f1ae-46fe-b240-110a1485aa1c"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a9e48ff3-8a3a-489b-8e47-de38b1915828"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("99b2e60f-1368-4ba3-9dbc-ffd1db5a1689"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("9371258b-215c-4c35-abc3-a382d6f6dae0"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("9fcf6db8-d04d-4575-a5f8-8c44232d7ddf"));
            FinishDate = (ITTDateTimePicker)AddControl(new Guid("af76b3dd-bf12-4be7-8dd7-90f46286dfe2"));
            labelType = (ITTLabel)AddControl(new Guid("079eb665-6668-4c16-94c1-954d616b2376"));
            labelFinishDate = (ITTLabel)AddControl(new Guid("71d7f7ca-02e0-4cc2-996f-92c844a8221d"));
            SlipNo = (ITTTextBox)AddControl(new Guid("f0ff10ed-711c-4f5b-8522-576f753555c1"));
            labelOrder = (ITTLabel)AddControl(new Guid("4feb3682-ed34-4977-843e-6cb0c4613866"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("9a0e68e9-e8a0-44db-aad4-66caac34953f"));
            labelSlipNo = (ITTLabel)AddControl(new Guid("8e3b33c0-1e1f-4ae6-a015-5978b06ba40b"));
            labelStartDate = (ITTLabel)AddControl(new Guid("d1f68964-71fa-4842-8b9e-86e608b04223"));
            ttenumcombobox2 = (ITTEnumComboBox)AddControl(new Guid("5046e450-acef-4c31-b4d2-455245cfcce7"));
            Approve = (ITTCheckBox)AddControl(new Guid("133ce3ae-f912-4bbc-837f-6393c7adabd4"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("7fe914a7-2f60-4504-8f39-51a907c6eff5"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("85626c45-149e-4264-9472-df21ac60975e"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("dc1d2ee4-1889-4fde-97f2-f870cbc808a8"));
            base.InitializeControls();
        }

        public JournalEntryPropertiesForm() : base("MHSACCOUNTINGBOOKS", "JournalEntryPropertiesForm")
        {
        }

        protected JournalEntryPropertiesForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}