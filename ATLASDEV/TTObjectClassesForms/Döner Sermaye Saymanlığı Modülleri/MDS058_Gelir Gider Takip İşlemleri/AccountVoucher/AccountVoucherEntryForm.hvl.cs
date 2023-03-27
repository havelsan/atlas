
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
    public partial class AccountVoucherEntryForm : TTForm
    {
        protected TTObjectClasses.AccountVoucher _AccountVoucher
        {
            get { return (TTObjectClasses.AccountVoucher)_ttObject; }
        }

        protected ITTLabel labelSupplier;
        protected ITTObjectListBox Supplier;
        protected ITTLabel labelAccountVoucherCodeDefinition;
        protected ITTObjectListBox AccountVoucherCodeDefinition;
        protected ITTLabel labelAccountPeriod;
        protected ITTObjectListBox AccountPeriod;
        protected ITTLabel labelTotalPrice;
        protected ITTTextBox TotalPrice;
        protected ITTCheckBox IsDept;
        override protected void InitializeControls()
        {
            labelSupplier = (ITTLabel)AddControl(new Guid("01c1d9c9-cd47-46a3-a609-ffa14a5c5475"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("d1febc20-cb9f-42a1-add6-ef1578c785ce"));
            labelAccountVoucherCodeDefinition = (ITTLabel)AddControl(new Guid("b0c22904-22d7-416e-9069-48656b49e635"));
            AccountVoucherCodeDefinition = (ITTObjectListBox)AddControl(new Guid("6faab215-2e08-4505-9c66-db0391fa11fb"));
            labelAccountPeriod = (ITTLabel)AddControl(new Guid("1e12bc0b-c08e-45f6-a292-8f18bdadb25d"));
            AccountPeriod = (ITTObjectListBox)AddControl(new Guid("bb4a6867-0246-43fa-a381-6c4c62b98f9d"));
            labelTotalPrice = (ITTLabel)AddControl(new Guid("2839ea62-1aac-4478-845f-29c1b75d871d"));
            TotalPrice = (ITTTextBox)AddControl(new Guid("c925fe26-bedb-4dd2-87bd-ecb7fffa31bf"));
            IsDept = (ITTCheckBox)AddControl(new Guid("d263d745-c792-453d-93da-d89e5703e6f0"));
            base.InitializeControls();
        }

        public AccountVoucherEntryForm() : base("ACCOUNTVOUCHER", "AccountVoucherEntryForm")
        {
        }

        protected AccountVoucherEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}