
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
    /// Ayrılmış Sözleşmeli Astsubay Ailesi
    /// </summary>
    public partial class DischargedContractedNoncomFamilyFrom : PatientAdmissionForm
    {
    /// <summary>
    /// Ayrılmış Sözleşmeli Astsubay Ailesi
    /// </summary>
        protected TTObjectClasses.PA_DischargedContractedNoncomFamily _PA_DischargedContractedNoncomFamily
        {
            get { return (TTObjectClasses.PA_DischargedContractedNoncomFamily)_ttObject; }
        }

        protected ITTGroupBox Family;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTMaskedTextBox HeadOfFamtxt;
        protected ITTTextBox EmploymentRecordID;
        protected ITTObjectListBox ttobjectlistboxForcesCommand;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel labelMilitaryClass;
        protected ITTLabel labelRank;
        protected ITTObjectListBox MilitaryClass;
        protected ITTTextBox HOFHealtSlipNumber;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelMilitaryUnit;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTObjectListBox Relationship;
        protected ITTLabel labelRelationship;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel ttlabel9;
        protected ITTTextBox tttextbox3;
        protected ITTLabel labelRetirementFundID;
        override protected void InitializeControls()
        {
            Family = (ITTGroupBox)AddControl(new Guid("67da4255-da11-4826-8dd0-3ca4eea75528"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("9cdd1fb8-d584-4bdd-87a2-67a6b3a76348"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("c6869f2f-1a2a-4656-a104-7080b990cbe6"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("ff878371-5dca-4353-a714-a0653e8ba046"));
            ttobjectlistboxForcesCommand = (ITTObjectListBox)AddControl(new Guid("802e6bfa-bc76-41d4-89fa-124c09757af2"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("ea77844d-5d6d-409b-8fda-3cfe601b4947"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f31a5d58-956d-47bc-9f34-a535c1ccfbfb"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ff8fce7d-6e80-479a-a0ef-af5518801fb6"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("cc6fc861-4a19-41ca-abee-aa9f6c5d0807"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("dd13b50f-444e-4071-9910-0ee80abe48e7"));
            labelRank = (ITTLabel)AddControl(new Guid("4a263297-111b-4208-be52-0efe6765e676"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("ed11594b-771b-4c46-aa81-eccfdd28036c"));
            HOFHealtSlipNumber = (ITTTextBox)AddControl(new Guid("0be5866d-9500-4970-baf8-40422c9454a6"));
            Rank = (ITTObjectListBox)AddControl(new Guid("d03af3ba-4699-4e0e-872b-da2563303a3d"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("d94d972d-5df8-4f86-8078-b08aaf7178ac"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("b553ed0b-e7d1-460e-aea2-fdc3ef4c1f98"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("f1980946-9ef1-4925-ad74-48b3518578e0"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("2141fec3-70a7-48ef-838d-3405747d31d4"));
            labelRelationship = (ITTLabel)AddControl(new Guid("67ab4d1b-46f3-45c6-9186-178ef0211526"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("b4186407-6904-4927-aff6-208b1f4736b1"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("a117c755-56c8-4355-a60a-ca470b540835"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("1abef1d4-47d6-4f6b-a08e-b08f4844b51f"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("a4191d95-e3fc-4dc4-b64f-06aea775e017"));
            base.InitializeControls();
        }

        public DischargedContractedNoncomFamilyFrom() : base("PA_DISCHARGEDCONTRACTEDNONCOMFAMILY", "DischargedContractedNoncomFamilyFrom")
        {
        }

        protected DischargedContractedNoncomFamilyFrom(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}