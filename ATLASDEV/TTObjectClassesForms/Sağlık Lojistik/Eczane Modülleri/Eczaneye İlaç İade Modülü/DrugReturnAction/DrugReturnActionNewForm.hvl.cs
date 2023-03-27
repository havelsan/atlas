
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
    public partial class DrugReturnActionNewForm : TTForm
    {
    /// <summary>
    /// Eczaneye İlaç İade
    /// </summary>
        protected TTObjectClasses.DrugReturnAction _DrugReturnAction
        {
            get { return (TTObjectClasses.DrugReturnAction)_ttObject; }
        }

        protected ITTLabel labelPharmacyStoreDefinition;
        protected ITTObjectListBox PharmacyStoreDefinition;
        protected ITTGrid DrugReturnActionDetails;
        protected ITTListBoxColumn DrugOrderTransactionDrugReturnActionDetail;
        protected ITTTextBoxColumn AmountDrugReturnActionDetail;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            labelPharmacyStoreDefinition = (ITTLabel)AddControl(new Guid("0e15f9cf-a8d5-4be8-80a7-c47484e24078"));
            PharmacyStoreDefinition = (ITTObjectListBox)AddControl(new Guid("340faea9-1903-4588-96f2-761f71011916"));
            DrugReturnActionDetails = (ITTGrid)AddControl(new Guid("1a24e39e-cfe7-4f97-a79d-50b6ef9a6b3e"));
            DrugOrderTransactionDrugReturnActionDetail = (ITTListBoxColumn)AddControl(new Guid("cf6e786f-8969-4704-ade6-22767329fcc7"));
            AmountDrugReturnActionDetail = (ITTTextBoxColumn)AddControl(new Guid("7fdcb2c1-b116-4ffe-bc0c-48b41c4b5b2b"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("7520e320-4332-43e7-8320-50ee04930ec5"));
            labelID = (ITTLabel)AddControl(new Guid("7a24f4c4-9424-4a4d-8066-df71fd820006"));
            ID = (ITTTextBox)AddControl(new Guid("037086a0-4abd-4ea4-a917-ff27822f7ac3"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("fc5a959c-947b-40fa-af81-8e46ffa6e7bf"));
            labelActionDate = (ITTLabel)AddControl(new Guid("98ce84bf-fdbe-4a36-9fd8-39be32332ec2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b32b14b9-92be-498e-b12e-888cccdad4ad"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7e19155a-c2e6-4efa-ad28-d76ca8324414"));
            base.InitializeControls();
        }

        public DrugReturnActionNewForm() : base("DRUGRETURNACTION", "DrugReturnActionNewForm")
        {
        }

        protected DrugReturnActionNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}