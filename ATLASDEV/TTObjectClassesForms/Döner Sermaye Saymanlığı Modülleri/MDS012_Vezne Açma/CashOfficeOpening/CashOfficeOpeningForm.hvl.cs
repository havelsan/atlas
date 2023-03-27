
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
    /// Sayman Mutemetliği / Vezne / Fatura Servisi Açma
    /// </summary>
    public partial class CashOfficeOpeningForm : TTForm
    {
    /// <summary>
    /// Muh.Yet. Mutemetliği/Vezne/Fatura Servisi Açma
    /// </summary>
        protected TTObjectClasses.CashOfficeOpening _CashOfficeOpening
        {
            get { return (TTObjectClasses.CashOfficeOpening)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker OPENINGDATE;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel6;
        protected ITTTextBox RESUSER;
        protected ITTTextBox CASHOFFICE;
        protected ITTTextBox COMPUTERNAME;
        protected ITTTextBox LOGID;
        protected ITTLabel AdLabel;
        protected ITTLabel ttlabel4;
        protected ITTLabel LogLabel;
        protected ITTLabel TarihLabel;
        override protected void InitializeControls()
        {
            ttlabel2 = (ITTLabel)AddControl(new Guid("0642b11e-ccf5-4129-a30d-24b40c61f584"));
            OPENINGDATE = (ITTDateTimePicker)AddControl(new Guid("ca84a087-e462-4eb3-9212-2988e52ac9c2"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("8bf6cb89-db75-4593-a8ec-475c156383e6"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("66ed1e3b-1e5a-40af-9d0c-7fc3e4870a56"));
            RESUSER = (ITTTextBox)AddControl(new Guid("7d73fe7d-b6b3-45be-8a3f-81346522c84c"));
            CASHOFFICE = (ITTTextBox)AddControl(new Guid("16c77d79-7161-445d-a697-9235e3052988"));
            COMPUTERNAME = (ITTTextBox)AddControl(new Guid("e1d5492d-9543-4440-a943-cc8254f9c752"));
            LOGID = (ITTTextBox)AddControl(new Guid("d6a527cb-73fc-41bf-a0b4-d11d215ceeb6"));
            AdLabel = (ITTLabel)AddControl(new Guid("7dba6dc5-ccc9-415b-b818-8b4e5b96b15c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("081abc36-75e4-4cb2-89fd-9a39814de859"));
            LogLabel = (ITTLabel)AddControl(new Guid("e251ee31-a594-4cb0-959a-a163976b607c"));
            TarihLabel = (ITTLabel)AddControl(new Guid("b8552cf7-06c3-404c-bfcd-e7a9b6087d8d"));
            base.InitializeControls();
        }

        public CashOfficeOpeningForm() : base("CASHOFFICEOPENING", "CashOfficeOpeningForm")
        {
        }

        protected CashOfficeOpeningForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}