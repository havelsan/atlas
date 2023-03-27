
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
    /// Sağlık Kurulu Zeyil/Ek Raporları
    /// </summary>
    public partial class HCAdditionalReportForm : TTForm
    {
    /// <summary>
    /// Sağlık Kurulu Zeyil/Ek Raporları
    /// </summary>
        protected TTObjectClasses.HealthCommitteeAdditionalReport _HealthCommitteeAdditionalReport
        {
            get { return (TTObjectClasses.HealthCommitteeAdditionalReport)_ttObject; }
        }

        protected ITTPanel ttpanel1;
        protected ITTEnumComboBox CommitteeTypeCombo;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker HCDate;
        protected ITTTextBox HCReportNo;
        protected ITTLabel ttlabel6;
        protected ITTTextBox HCHospitalName;
        protected ITTCheckBox IsOtherHospitalHC;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel7;
        protected ITTTextBox txtReportNo;
        protected ITTLabel ttlabel4;
        protected ITTRichTextBoxControl rchReport;
        protected ITTDateTimePicker dtReportDate;
        protected ITTEnumComboBox cmbReportType;
        protected ITTObjectListBox lstHealthCommittee;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ttpanel1 = (ITTPanel)AddControl(new Guid("95eac924-b491-49eb-90a4-ab773b2d3f56"));
            CommitteeTypeCombo = (ITTEnumComboBox)AddControl(new Guid("4908880c-3ffd-4507-a46d-d97c0c4bab14"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("3af91939-3e62-43e4-8247-9897ad897784"));
            HCDate = (ITTDateTimePicker)AddControl(new Guid("0dba04e0-bb1e-4da9-a327-32520237275e"));
            HCReportNo = (ITTTextBox)AddControl(new Guid("23050b7d-813c-405b-8db4-12f1d24810b8"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("84d6eb65-b278-4227-a1b5-8cb53fe394cf"));
            HCHospitalName = (ITTTextBox)AddControl(new Guid("9e26a401-5928-4be4-9103-907d5ffa4487"));
            IsOtherHospitalHC = (ITTCheckBox)AddControl(new Guid("9c02663f-f0ab-4090-891c-97ffd7ff4636"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("972c627d-76d9-4d3a-be76-157d1cb93101"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("e1bce7a2-6f66-4615-a41b-d863bf6400e5"));
            txtReportNo = (ITTTextBox)AddControl(new Guid("c67950bc-14ca-47aa-a825-583cda5a42b9"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("0b116edb-7525-4276-b775-adae34022791"));
            rchReport = (ITTRichTextBoxControl)AddControl(new Guid("b18c6e02-3c79-4943-82d7-0d4041305e0f"));
            dtReportDate = (ITTDateTimePicker)AddControl(new Guid("215c0b20-3f5d-4e3c-9935-0a0faad72720"));
            cmbReportType = (ITTEnumComboBox)AddControl(new Guid("1d82abad-969a-47aa-a751-35db1c054603"));
            lstHealthCommittee = (ITTObjectListBox)AddControl(new Guid("6d781ad1-f17e-4eae-af97-36a59437dd57"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("425942b8-ca17-4c25-9cfc-47da73944fd3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("65db9010-8a53-44cd-b949-40f8014bc302"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8aad10cd-9701-4202-8598-7094ea767e73"));
            base.InitializeControls();
        }

        public HCAdditionalReportForm() : base("HEALTHCOMMITTEEADDITIONALREPORT", "HCAdditionalReportForm")
        {
        }

        protected HCAdditionalReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}