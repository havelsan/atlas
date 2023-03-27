
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
    /// Diş Protez
    /// </summary>
    public partial class DentalProsthesisRequestForm : BaseDentalEpisodeActionForm
    {
    /// <summary>
    /// Diş Protez İstek  İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.DentalProsthesisRequest _DentalProsthesisRequest
        {
            get { return (TTObjectClasses.DentalProsthesisRequest)_ttObject; }
        }

        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage SuggestedDentalProsthesis;
        protected ITTGrid SuggestedProsthesis;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn SuggestedProsthesisProcedure;
        protected ITTEnumComboBoxColumn ToothNum;
        protected ITTEnumComboBoxColumn DentalPosition;
        protected ITTButtonColumn SuggestedToothSchema;
        protected ITTListBoxColumn Department;
        protected ITTTextBoxColumn Definition;
        protected ITTTextBoxColumn ToothColor;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox DentalExaminationFile;
        protected ITTLabel labelDentalExaminationFile;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            LabelRequestDate = (ITTLabel)AddControl(new Guid("c76604ca-9caa-4839-a70e-f9c62c30918e"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("b39464c0-ea4d-499e-b779-b09856150c50"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("3958ea1a-0732-48da-85a3-08554da76375"));
            SuggestedDentalProsthesis = (ITTTabPage)AddControl(new Guid("41f144be-cab0-4323-b40d-d0aaa1eceda6"));
            SuggestedProsthesis = (ITTGrid)AddControl(new Guid("84372fc7-f28f-4615-a1e8-5a0ac1847a5e"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("b77fcaf1-999d-4619-a676-6b1b8473da50"));
            SuggestedProsthesisProcedure = (ITTListBoxColumn)AddControl(new Guid("ec8b8630-9ef2-44be-a859-b7cd97d76b6b"));
            ToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("aa29e964-f172-49ea-9055-450f038f128b"));
            DentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("38516025-4083-4fdb-9c9a-061b96ad7820"));
            SuggestedToothSchema = (ITTButtonColumn)AddControl(new Guid("07250663-d689-433c-9a11-f732beeba279"));
            Department = (ITTListBoxColumn)AddControl(new Guid("3a9619ae-bfa3-45c3-bcfe-85dac868749c"));
            Definition = (ITTTextBoxColumn)AddControl(new Guid("f5170fae-ad47-4a38-9351-d68b3fde9a9c"));
            ToothColor = (ITTTextBoxColumn)AddControl(new Guid("f6a17c87-07fd-4e21-9f05-64b8e40ce2df"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("d7639e25-e388-421d-8ed6-254a51a45393"));
            DentalExaminationFile = (ITTTextBox)AddControl(new Guid("1388ad4e-20ef-4ed1-ae55-fd5ef81caa59"));
            labelDentalExaminationFile = (ITTLabel)AddControl(new Guid("19f2f419-426f-4e59-b8b9-3b07f1771dee"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("1ce06903-44a6-4c8c-92c6-ea34527dfe59"));
            base.InitializeControls();
        }

        public DentalProsthesisRequestForm() : base("DENTALPROSTHESISREQUEST", "DentalProsthesisRequestForm")
        {
        }

        protected DentalProsthesisRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}