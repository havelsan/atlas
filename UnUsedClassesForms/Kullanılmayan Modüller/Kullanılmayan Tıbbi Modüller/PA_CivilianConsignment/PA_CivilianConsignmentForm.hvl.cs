
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
    /// Sivil Sevkli Kabulü
    /// </summary>
    public partial class PA_CivilianConsignmentForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sivil Sevkli Kabul 
    /// </summary>
        protected TTObjectClasses.PA_CivilianConsignment _PA_CivilianConsignment
        {
            get { return (TTObjectClasses.PA_CivilianConsignment)_ttObject; }
        }

        protected ITTCheckBox chkIsSGKPatient;
        protected ITTCheckBox ConsignmentDocumentTakenCheckBox;
        protected ITTCheckBox IdCardCopyTakenCheckBox;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelDocumentNumber;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelProtocol;
        protected ITTLabel labelCity;
        protected ITTLabel labelFoundation;
        protected ITTObjectListBox PayerCity;
        protected ITTLabel labelRelationship;
        protected ITTObjectListBox Relationship;
        protected ITTObjectListBox Payer;
        protected ITTObjectListBox Protocol;
        override protected void InitializeControls()
        {
            chkIsSGKPatient = (ITTCheckBox)AddControl(new Guid("467046de-61e4-4c60-bd99-55c58137480c"));
            ConsignmentDocumentTakenCheckBox = (ITTCheckBox)AddControl(new Guid("ed69c99c-71e4-49bf-8f6b-c3ea58f8dfef"));
            IdCardCopyTakenCheckBox = (ITTCheckBox)AddControl(new Guid("0a85a48d-b0e6-466f-82e5-4bead96f3f53"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("0cb58fb6-8c64-4b57-b415-eed4608e0dc3"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("77daf326-84e5-465e-8957-30bea3738c20"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("ee4d5737-aed8-4ffb-b2e2-51296a53ed90"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("65dca34e-b687-404c-bf5b-83db8eb42f8a"));
            labelProtocol = (ITTLabel)AddControl(new Guid("93e7c134-e084-41f6-9e18-03677945de4e"));
            labelCity = (ITTLabel)AddControl(new Guid("944f2507-3c71-46b3-a515-0c16a8e2a9b8"));
            labelFoundation = (ITTLabel)AddControl(new Guid("cd00d692-58c3-4217-92f7-15851d66e492"));
            PayerCity = (ITTObjectListBox)AddControl(new Guid("0e2bfe77-0aaf-4181-9a78-479f56f84434"));
            labelRelationship = (ITTLabel)AddControl(new Guid("9843b619-db86-40b3-b56f-66bc94d5405b"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("308dcd54-dc8d-45a7-8d71-69c323f6d134"));
            Payer = (ITTObjectListBox)AddControl(new Guid("023c0bf8-f6f1-491e-bc1a-cfb81c98bcd9"));
            Protocol = (ITTObjectListBox)AddControl(new Guid("6997824c-dff9-43a7-a235-d416dbacac54"));
            base.InitializeControls();
        }

        public PA_CivilianConsignmentForm() : base("PA_CIVILIANCONSIGNMENT", "PA_CivilianConsignmentForm")
        {
        }

        protected PA_CivilianConsignmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}