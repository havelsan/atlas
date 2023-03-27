
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
    /// Geçici Köy Korucusu Kabulü
    /// </summary>
    public partial class PA_TemporaryVillageSecurityForm : PatientAdmissionForm
    {
    /// <summary>
    /// Geçici Köy Korucusu Kabul 
    /// </summary>
        protected TTObjectClasses.PA_TemporaryVillageSecurity _PA_TemporaryVillageSecurity
        {
            get { return (TTObjectClasses.PA_TemporaryVillageSecurity)_ttObject; }
        }

        protected ITTObjectListBox Protocol;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel labelFoundation;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel ttlabel6;
        protected ITTTextBox HealtSlipNumber;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox Relationship;
        protected ITTObjectListBox Payer;
        override protected void InitializeControls()
        {
            Protocol = (ITTObjectListBox)AddControl(new Guid("c1a6db58-5aad-462d-a5b6-4aab6c269a26"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("b44b9332-c4ec-44c8-b058-8d7eb04df83c"));
            labelFoundation = (ITTLabel)AddControl(new Guid("0210709d-e7c4-4856-b632-919a4dfa6ad0"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("31ce89f4-039c-4a76-8ac2-a07c994a45c3"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("14a267a9-ecfd-464f-af68-a22511103e0b"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("4c8ce1e1-bea2-4e83-a284-b29552e515c3"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("3511b282-e879-40a2-9377-baf248b29a07"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("7b63f6f4-945d-4fda-9a45-c28b36fcbc75"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5a648fec-462f-4af2-8800-dcee7f730e1b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("7c0eeda4-4550-4943-84d2-eccb6bdd648f"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("85d598f6-f507-4fdb-8405-fb5d1774c8aa"));
            Payer = (ITTObjectListBox)AddControl(new Guid("d0e708b3-662e-4d2e-b409-ff1bccddacbe"));
            base.InitializeControls();
        }

        public PA_TemporaryVillageSecurityForm() : base("PA_TEMPORARYVILLAGESECURITY", "PA_TemporaryVillageSecurityForm")
        {
        }

        protected PA_TemporaryVillageSecurityForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}