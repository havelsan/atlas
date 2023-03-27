
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
    public partial class DrugReturnActionApprovalForm : TTForm
    {
    /// <summary>
    /// Eczaneye İlaç İade
    /// </summary>
        protected TTObjectClasses.DrugReturnAction _DrugReturnAction
        {
            get { return (TTObjectClasses.DrugReturnAction)_ttObject; }
        }

        protected ITTGrid DrugReturnActionDetails;
        protected ITTListBoxColumn DrugOrderTransactionDrugReturnActionDetail;
        protected ITTTextBoxColumn SendAmount;
        protected ITTTextBoxColumn AmountDrugReturnActionDetail;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox PharmacyStoreDefinition;
        protected ITTLabel labelPharmacyStoreDefinition;
        override protected void InitializeControls()
        {
            DrugReturnActionDetails = (ITTGrid)AddControl(new Guid("109f141f-b967-42da-b22e-292066a428e6"));
            DrugOrderTransactionDrugReturnActionDetail = (ITTListBoxColumn)AddControl(new Guid("4fcbae80-a632-42e8-a7f8-dbe350a9306f"));
            SendAmount = (ITTTextBoxColumn)AddControl(new Guid("501e5f56-1512-44bb-a5d7-d131fed7ce61"));
            AmountDrugReturnActionDetail = (ITTTextBoxColumn)AddControl(new Guid("99187a12-251a-4849-9601-2f38855c5d35"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("4ebb2427-d53d-4a62-a42d-ca0d70fbac74"));
            labelID = (ITTLabel)AddControl(new Guid("25f6d074-e71c-4133-8a10-8b0229db8d4b"));
            ID = (ITTTextBox)AddControl(new Guid("475166a8-24f7-4330-85a1-3d98c8d40060"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("3827faa6-3fbc-4b04-a8bd-a852c31e16e7"));
            labelActionDate = (ITTLabel)AddControl(new Guid("df051c95-27d1-416b-a7ed-d32811f7dea8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5e3d19f9-0c80-4685-97fd-9641ad102a02"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e74e685e-82b7-4ca4-9eb8-f604c26e0a83"));
            PharmacyStoreDefinition = (ITTObjectListBox)AddControl(new Guid("571c7efb-8391-49fd-91fc-1000579c7d94"));
            labelPharmacyStoreDefinition = (ITTLabel)AddControl(new Guid("9283b6ae-9bcd-4ccc-bfdf-4188fbff3d91"));
            base.InitializeControls();
        }

        public DrugReturnActionApprovalForm() : base("DRUGRETURNACTION", "DrugReturnActionApprovalForm")
        {
        }

        protected DrugReturnActionApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}