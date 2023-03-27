
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
    /// Eczaneye İlaç İade
    /// </summary>
    public partial class DrugReturnActionCompletedForm : TTForm
    {
    /// <summary>
    /// Eczaneye İlaç İade
    /// </summary>
        protected TTObjectClasses.DrugReturnAction _DrugReturnAction
        {
            get { return (TTObjectClasses.DrugReturnAction)_ttObject; }
        }

        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox PharmacyStoreDefinition;
        protected ITTLabel labelPharmacyStoreDefinition;
        protected ITTGrid DrugReturnActionDetails;
        protected ITTListBoxColumn DrugOrderTransactionDrugReturnActionDetail;
        protected ITTTextBoxColumn SendAmount;
        protected ITTTextBoxColumn AmountDrugReturnActionDetail;
        override protected void InitializeControls()
        {
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("5719149c-5699-4c39-b70f-dc065512f2b0"));
            labelID = (ITTLabel)AddControl(new Guid("f715a19c-8b67-4bc1-92ef-26b26450de11"));
            ID = (ITTTextBox)AddControl(new Guid("5df194d9-3889-465f-a0fb-b5f4e739e4d5"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("f16e61d6-1799-4e3c-9bb5-e9d4bd0ed7bf"));
            labelActionDate = (ITTLabel)AddControl(new Guid("dcba98f6-008d-4866-bd8a-ca4872f2a2f8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("426368db-f184-4ef2-a93a-2db05b044dda"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a70918c9-c6ae-4b1e-b28f-dc436ec5d815"));
            PharmacyStoreDefinition = (ITTObjectListBox)AddControl(new Guid("c847d0d7-0d2a-42db-a152-032cfdd513b9"));
            labelPharmacyStoreDefinition = (ITTLabel)AddControl(new Guid("afc694ad-f86c-4287-9fbd-666465904506"));
            DrugReturnActionDetails = (ITTGrid)AddControl(new Guid("df838b9a-469c-4b7d-bf86-83fa9362922f"));
            DrugOrderTransactionDrugReturnActionDetail = (ITTListBoxColumn)AddControl(new Guid("9b9c4fb1-ad3b-49ca-bf0f-d8abb0356068"));
            SendAmount = (ITTTextBoxColumn)AddControl(new Guid("6336f52f-13a1-4b7f-9491-a99b5ab0910b"));
            AmountDrugReturnActionDetail = (ITTTextBoxColumn)AddControl(new Guid("beb74ba8-f840-4605-b531-2063b3ad6dc1"));
            base.InitializeControls();
        }

        public DrugReturnActionCompletedForm() : base("DRUGRETURNACTION", "DrugReturnActionCompletedForm")
        {
        }

        protected DrugReturnActionCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}