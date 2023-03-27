
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
    /// Muavin Defteri
    /// </summary>
    public partial class SubsidaryLedgerPropertiesForm : TTForm
    {
    /// <summary>
    /// Muhasebe Defterleri
    /// </summary>
        protected TTObjectClasses.MhSAccountingBooks _MhSAccountingBooks
        {
            get { return (TTObjectClasses.MhSAccountingBooks)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel2;
        protected ITTListDefComboBox ttlistdefcombobox2;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelStartDate;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox ttcheckbox1;
        protected ITTDateTimePicker StartDate;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelFinishDate;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox ttcheckbox2;
        protected ITTDateTimePicker FinishDate;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("142d529c-8a27-4182-934f-14032b9aaaa1"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3283e148-ba46-4e4a-912a-d31596e014fb"));
            ttlistdefcombobox2 = (ITTListDefComboBox)AddControl(new Guid("74811627-33b8-4056-938e-ff46c30322c7"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("a45d58b7-f094-44b9-aa6e-e517d95ace6b"));
            labelStartDate = (ITTLabel)AddControl(new Guid("8d41f634-42bf-4365-9a70-c45ba46ee6df"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("bab5a1d3-39c7-4113-a7ce-a4742823474d"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("4bd564ca-4086-4226-87f3-acffe679a70a"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("657dc25d-f0b9-4209-893e-fa576f4027a8"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("371a3d22-ad06-4d10-98a0-77ae9db6497e"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("837a7eb6-8590-4f93-922c-8177daa1a272"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("a340bbde-db99-4ffd-a6a5-9771c7beef58"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("68b1b659-ab1b-4782-b4a9-61ff77828e16"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b95c6dc5-e666-46e6-8a65-5ba589fe3428"));
            labelFinishDate = (ITTLabel)AddControl(new Guid("d3eb76c0-a562-45e7-bf9f-5dbbd1638013"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("0214a168-b636-4502-9899-4c1c993839f5"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("fb9f1bac-3d14-4076-96f2-6bc4c80cfdbe"));
            FinishDate = (ITTDateTimePicker)AddControl(new Guid("f38dd51f-5714-492c-93dc-f64a059b0a00"));
            base.InitializeControls();
        }

        public SubsidaryLedgerPropertiesForm() : base("MHSACCOUNTINGBOOKS", "SubsidaryLedgerPropertiesForm")
        {
        }

        protected SubsidaryLedgerPropertiesForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}