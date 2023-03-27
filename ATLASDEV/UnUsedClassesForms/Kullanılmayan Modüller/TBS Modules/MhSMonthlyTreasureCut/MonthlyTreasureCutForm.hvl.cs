
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
    /// Aylık Hazine Kesintisi Hesaplama
    /// </summary>
    public partial class MonthlyTreasureCutForm : TTForm
    {
    /// <summary>
    /// Aylık Hazine Payı İşlemleri
    /// </summary>
        protected TTObjectClasses.MhSMonthlyTreasureCut _MhSMonthlyTreasureCut
        {
            get { return (TTObjectClasses.MhSMonthlyTreasureCut)_ttObject; }
        }

        protected ITTEnumComboBox Month;
        protected ITTTextBox Account600Balance;
        protected ITTButton buttonPaymentSlip;
        protected ITTLabel labelMonth;
        protected ITTDateTimePicker Date;
        protected ITTLabel labelCutRatio;
        protected ITTLabel labelAccount600Balance;
        protected ITTTextBox CutAmount;
        protected ITTLabel labelCutAmount;
        protected ITTLabel labelDate;
        protected ITTLabel labelRemainingAmount;
        protected ITTTextBox RemainingAmount;
        protected ITTButton buttonChargingSlip;
        protected ITTTextBox CutRatio;
        override protected void InitializeControls()
        {
            Month = (ITTEnumComboBox)AddControl(new Guid("79e64085-33b6-4ef5-957f-1289c2e7337b"));
            Account600Balance = (ITTTextBox)AddControl(new Guid("a70a847f-8e28-450d-a842-2d3e42ec5ace"));
            buttonPaymentSlip = (ITTButton)AddControl(new Guid("f9fcd603-21ab-4f79-9b27-277dd4a0e7a8"));
            labelMonth = (ITTLabel)AddControl(new Guid("fe34fe6f-d21a-4f5d-aab2-3a6e0a24226d"));
            Date = (ITTDateTimePicker)AddControl(new Guid("0deb0e48-6a1e-428d-b152-7122e319098c"));
            labelCutRatio = (ITTLabel)AddControl(new Guid("64aa1f87-2c9f-4bdb-a870-6d247839b37b"));
            labelAccount600Balance = (ITTLabel)AddControl(new Guid("c7ddc137-e858-486b-9c93-8bc4b232c208"));
            CutAmount = (ITTTextBox)AddControl(new Guid("d8fdb7a4-eedf-4d71-b58f-b4b64d257b54"));
            labelCutAmount = (ITTLabel)AddControl(new Guid("a193c544-8150-4cdb-8a10-cc41b5573304"));
            labelDate = (ITTLabel)AddControl(new Guid("3d94035f-5670-4450-a482-d5db8801c977"));
            labelRemainingAmount = (ITTLabel)AddControl(new Guid("dede6dd6-2b24-465f-965c-ce2486d46113"));
            RemainingAmount = (ITTTextBox)AddControl(new Guid("7bda1ab2-230f-4e0e-9439-d64f4773e71e"));
            buttonChargingSlip = (ITTButton)AddControl(new Guid("945c739f-de91-4deb-b3e1-f021e0fe7f9a"));
            CutRatio = (ITTTextBox)AddControl(new Guid("2035ac5a-e973-4ed5-a6e0-e2bd17836ba2"));
            base.InitializeControls();
        }

        public MonthlyTreasureCutForm() : base("MHSMONTHLYTREASURECUT", "MonthlyTreasureCutForm")
        {
        }

        protected MonthlyTreasureCutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}