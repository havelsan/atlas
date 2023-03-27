
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
    public partial class DischargedContractedOfficerFamilyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Ayrılmış Sözleşmeli Subay Ailesi
    /// </summary>
        protected TTObjectClasses.PA_DischargedContractedOfficerFamily _PA_DischargedContractedOfficerFamily
        {
            get { return (TTObjectClasses.PA_DischargedContractedOfficerFamily)_ttObject; }
        }

        protected ITTGroupBox Family;
        protected ITTLabel ttlabel13;
        protected ITTMaskedTextBox ttmaskedtextbox2;
        protected ITTTextBox tttextbox6;
        protected ITTObjectListBox ttobjectlistbox6;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel16;
        protected ITTTextBox tttextbox7;
        protected ITTLabel ttlabel17;
        protected ITTLabel ttlabel18;
        protected ITTObjectListBox ttobjectlistbox7;
        protected ITTTextBox tttextbox8;
        protected ITTObjectListBox ttobjectlistbox8;
        protected ITTLabel ttlabel19;
        protected ITTObjectListBox ttobjectlistbox9;
        protected ITTLabel ttlabel20;
        protected ITTObjectListBox Relationship;
        protected ITTLabel labelRelationship;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel ttlabel9;
        protected ITTTextBox tttextbox3;
        protected ITTLabel labelRetirementFundID;
        override protected void InitializeControls()
        {
            Family = (ITTGroupBox)AddControl(new Guid("0cf95086-7a6c-46c7-b563-5ec4dbdb4413"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("b7b56cfc-ad61-4359-9271-3e6f2ff50f29"));
            ttmaskedtextbox2 = (ITTMaskedTextBox)AddControl(new Guid("a1a4df45-dfe8-40a5-820d-aad883fa36ab"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("1684a089-62b6-4518-96ce-94a015e224fe"));
            ttobjectlistbox6 = (ITTObjectListBox)AddControl(new Guid("08389a8f-c58b-4cc2-a8a4-0cfae0ca206f"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("a82251d6-b3ff-46b5-8796-03087d8c6671"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("081209e5-73e1-43b1-86cc-bfd3c8acd1b6"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("fd432872-7d9b-44bf-a346-1f9f858fed88"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("2a50bdab-7083-494e-9929-168baa840566"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("79430d50-bd18-403b-8857-d099224efe9a"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("44742098-f468-4276-9b13-e0684bf34dae"));
            ttobjectlistbox7 = (ITTObjectListBox)AddControl(new Guid("0dda7694-76c4-420a-af74-b53083653923"));
            tttextbox8 = (ITTTextBox)AddControl(new Guid("6ce8aa54-17d8-4b3a-956b-fc77bbcae256"));
            ttobjectlistbox8 = (ITTObjectListBox)AddControl(new Guid("471a451e-a967-4b04-8caf-611378005b18"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("5e3d62fb-e822-4b7b-973e-ae88ee28f43e"));
            ttobjectlistbox9 = (ITTObjectListBox)AddControl(new Guid("b8363913-3f56-4fd5-8d89-71704d0d7860"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("f899d8d1-f00c-4cf0-a402-1ec58afd8100"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("c190a7f0-4202-49a8-801d-ea794ded7b48"));
            labelRelationship = (ITTLabel)AddControl(new Guid("6bf0e931-70f2-4fb0-a2ca-28cb2222ca93"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("21d311f2-ef20-421b-8c19-5feff7a480c8"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("653d509b-63aa-45de-a0f3-bdba737a46cc"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("d681790e-60f4-4761-951d-b2a7c77e64b8"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("c0e96cce-e17c-4252-b3d5-8b3453107e4d"));
            base.InitializeControls();
        }

        public DischargedContractedOfficerFamilyForm() : base("PA_DISCHARGEDCONTRACTEDOFFICERFAMILY", "DischargedContractedOfficerFamilyForm")
        {
        }

        protected DischargedContractedOfficerFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}