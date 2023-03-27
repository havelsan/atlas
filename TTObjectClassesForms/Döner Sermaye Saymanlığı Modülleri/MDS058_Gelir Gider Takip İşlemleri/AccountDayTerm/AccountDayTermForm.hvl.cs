
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
    /// Muhasebeleştirme Gün Süresi
    /// </summary>
    public partial class AccountDayTermForm : TTForm
    {
        protected TTObjectClasses.AccountDayTerm _AccountDayTerm
        {
            get { return (TTObjectClasses.AccountDayTerm)_ttObject; }
        }

        protected ITTLabel labelAccountPeriod;
        protected ITTObjectListBox AccountPeriod;
        protected ITTLabel labelProcedureAverage;
        protected ITTTextBox ProcedureAverage;
        protected ITTTextBox MovableAverage;
        protected ITTTextBox Average;
        protected ITTLabel labelMovableAverage;
        protected ITTLabel labelAverage;
        override protected void InitializeControls()
        {
            labelAccountPeriod = (ITTLabel)AddControl(new Guid("e72a7586-c7ac-4da6-a552-408a59c1eff5"));
            AccountPeriod = (ITTObjectListBox)AddControl(new Guid("86a78877-53b6-492d-a2b6-acc0ee33484d"));
            labelProcedureAverage = (ITTLabel)AddControl(new Guid("daeaa7dc-6588-4dbc-bba8-dd6db67c9028"));
            ProcedureAverage = (ITTTextBox)AddControl(new Guid("6650b45a-f848-47e0-83a7-d1b38fa08ca9"));
            MovableAverage = (ITTTextBox)AddControl(new Guid("2d0a1c36-edc8-4d0e-a468-8877e48c26ef"));
            Average = (ITTTextBox)AddControl(new Guid("3cd27912-573f-4173-bb97-31e7c25dd939"));
            labelMovableAverage = (ITTLabel)AddControl(new Guid("8c849c01-55c5-4b5a-b016-d94be11c03b6"));
            labelAverage = (ITTLabel)AddControl(new Guid("7c2c5148-5956-40ec-9baf-b4fb843df39e"));
            base.InitializeControls();
        }

        public AccountDayTermForm() : base("ACCOUNTDAYTERM", "AccountDayTermForm")
        {
        }

        protected AccountDayTermForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}