
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
    /// Emekli XXXXXX Ailesi Kabülü
    /// </summary>
    public partial class PA_MilitaryRetiredFamiliyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Emekli XXXXXX Aliesi
    /// </summary>
        protected TTObjectClasses.PA_MilitaryRetiredFamily _PA_MilitaryRetiredFamily
        {
            get { return (TTObjectClasses.PA_MilitaryRetiredFamily)_ttObject; }
        }

        protected ITTGroupBox FamilyInfo;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTTextBox EmploymentRecordID;
        protected ITTMaskedTextBox HeadOfFamtxt;
        protected ITTLabel labelForcesCommand;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelRank;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox Rank;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelRetirementFundID;
        protected ITTLabel ttlabel11;
        protected ITTObjectListBox PayerCity;
        protected ITTTextBox RetirementFundID;
        protected ITTObjectListBox Payer;
        protected ITTObjectListBox Protocol;
        protected ITTObjectListBox Relationship;
        protected ITTLabel labelRelationship;
        override protected void InitializeControls()
        {
            FamilyInfo = (ITTGroupBox)AddControl(new Guid("ffc58060-7a1b-4b97-b3af-1cbaec773bf1"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("323a1335-d3ae-4e28-b0a9-c3cef9f69f10"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("af43785a-9498-4f98-b3bd-41982d9ead25"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6f28fd33-87b5-4f77-b49d-170ed7c86831"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("ca81d98c-8c49-48b3-9760-698b52f92ec4"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("3670e759-8441-4a76-81ea-bc20f1656249"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("6706bc74-7e31-45df-8083-46398b61ea65"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("74ca864a-b7fa-45e4-a38a-f5581c67dc38"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("56f5220d-7714-4076-a349-ec86f8d24131"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("fbd52d28-3afd-40bf-989b-9a807655a164"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b2eec890-91b7-407b-a3a4-4a516ce17574"));
            labelRank = (ITTLabel)AddControl(new Guid("f295fc31-ce72-4026-ac25-9c860346fd24"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("87cf0a7a-28c3-43be-a09b-1e7326ec5676"));
            Rank = (ITTObjectListBox)AddControl(new Guid("218cd2ab-b8e8-49a7-9d3d-348d2c3ec1e1"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("86777756-9150-4edc-b597-0c8bf16c96f3"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("42244b43-e0fb-4aa5-8e00-f43f61d2ad8a"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("af106f2d-aefb-469d-b0b9-a93eeedd1d19"));
            PayerCity = (ITTObjectListBox)AddControl(new Guid("953d5add-63b5-4746-b823-10893cc6a4ad"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("ece85615-f68a-4d91-b210-5e3f08e7a5d1"));
            Payer = (ITTObjectListBox)AddControl(new Guid("96847174-a474-4921-bea2-2fe18d4d33a3"));
            Protocol = (ITTObjectListBox)AddControl(new Guid("386ad815-0792-44c6-9a8e-222da0b2fc96"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("a446e7d1-5c9a-48c9-8993-137f5df4f826"));
            labelRelationship = (ITTLabel)AddControl(new Guid("f496be66-aa89-40f7-a6d4-718528043ab7"));
            base.InitializeControls();
        }

        public PA_MilitaryRetiredFamiliyForm() : base("PA_MILITARYRETIREDFAMILY", "PA_MilitaryRetiredFamiliyForm")
        {
        }

        protected PA_MilitaryRetiredFamiliyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}