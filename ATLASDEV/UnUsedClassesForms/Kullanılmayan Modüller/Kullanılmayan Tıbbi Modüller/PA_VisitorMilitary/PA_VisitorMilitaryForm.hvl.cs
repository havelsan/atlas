
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
    /// Misafir XXXXXX Personel Form
    /// </summary>
    public partial class PA_VisitorMilitaryForm : PatientAdmissionForm
    {
    /// <summary>
    /// Misafir XXXXXX Personel
    /// </summary>
        protected TTObjectClasses.PA_VisitorMilitary _PA_VisitorMilitary
        {
            get { return (TTObjectClasses.PA_VisitorMilitary)_ttObject; }
        }

        protected ITTLabel labelVisitingReason;
        protected ITTEnumComboBox VisitingReason;
        protected ITTTextBox TemporaryHealthNo;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelDocumentNumber;
        protected ITTObjectListBox Country;
        protected ITTObjectListBox SenderChair;
        protected ITTTextBox HealtSlipNumber;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelDocumentDate;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelCountry;
        override protected void InitializeControls()
        {
            labelVisitingReason = (ITTLabel)AddControl(new Guid("77f833be-41b7-4a98-9b29-4343ebd18467"));
            VisitingReason = (ITTEnumComboBox)AddControl(new Guid("c8f69118-af2c-49a1-bb2c-8cb9c48fa855"));
            TemporaryHealthNo = (ITTTextBox)AddControl(new Guid("ede7f7fb-09e4-47d9-bf37-1dd2904188cd"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("ea9bc2be-8b7e-4065-87aa-23222d364ebe"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("3d75be42-b089-4f9c-92a3-797ce471b6af"));
            Country = (ITTObjectListBox)AddControl(new Guid("251c613f-4975-46d2-9b0f-605ea572052b"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("b4f83d26-d134-4466-ba17-585cd286d38e"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("0a111841-9703-4aac-a446-5120cccd5692"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("3e12adf2-297a-40b6-8435-f0198e11a4ec"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("964fa253-1d32-4847-b312-2f62d50ef12c"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("b08f8cd2-d862-4275-b747-10e620eb9cd5"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("868e2e46-0beb-4f26-a919-a4432510cee0"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fc0f9da6-7882-43df-8ce9-8c96e9a03d35"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("e90dba13-7690-4f23-b5bf-cc743214bd22"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("b41d4fe1-0d04-4b58-83ec-94a047c7888f"));
            labelCountry = (ITTLabel)AddControl(new Guid("6de9f231-3f52-4101-8131-06e764660eb1"));
            base.InitializeControls();
        }

        public PA_VisitorMilitaryForm() : base("PA_VISITORMILITARY", "PA_VisitorMilitaryForm")
        {
        }

        protected PA_VisitorMilitaryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}