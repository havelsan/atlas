
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
    /// Hasta Grup Tanımı
    /// </summary>
    public partial class PatientGroupDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hasta Grup Tanımı
    /// </summary>
        protected TTObjectClasses.PatientGroupDefinition _PatientGroupDefinition
        {
            get { return (TTObjectClasses.PatientGroupDefinition)_ttObject; }
        }

        protected ITTCheckBox PassQuarantineForInpatient;
        protected ITTLabel labelSecureType;
        protected ITTEnumComboBox SecureType;
        protected ITTLabel labelEpisodeClosingDayLimit;
        protected ITTTextBox EpisodeClosingDayLimit;
        protected ITTTextBox OrderNo;
        protected ITTGroupBox MedulaRequrements;
        protected ITTListDefComboBox provizyonTipi;
        protected ITTLabel labeltedaviTipi;
        protected ITTLabel labelsigortaliTuru;
        protected ITTLabel labeltakipTipi;
        protected ITTListDefComboBox sigortaliTuru;
        protected ITTLabel labeldevredilenKurum;
        protected ITTListDefComboBox takipTipi;
        protected ITTListDefComboBox devredilenKurum;
        protected ITTListDefComboBox tedaviTipi;
        protected ITTLabel labeltedaviTuru;
        protected ITTLabel labelprovizyonTipi;
        protected ITTListDefComboBox tedaviTuru;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox RequiredAdvance;
        protected ITTCheckBox MlitaryPersonnel;
        protected ITTCheckBox RequiredFinancialDepartmentControl;
        protected ITTEnumComboBox PatientGroupEnum;
        protected ITTLabel labelPatientGroupEnum;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelOrderNo;
        protected ITTCheckBox AdmitAccordingToMainGroup;
        protected ITTCheckBox ttcheckbox1;
        protected ITTGrid ReasonForAdmissions;
        protected ITTEnumComboBoxColumn ReasonForAdmission;
        protected ITTLabel labelBeneficiary;
        protected ITTEnumComboBox Beneficiary;
        protected ITTCheckBox RequiredQuota;
        protected ITTCheckBox RequiredMedulaProvision;
        protected ITTEnumComboBox ForeignUsage;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox IsRequiredSmartdCard;
        protected ITTCheckBox GetPatientParticipation;
        protected ITTCheckBox chkIsActive;
        protected ITTEnumComboBox PatientGroupType;
        protected ITTLabel ttlabel4;
        protected ITTCheckBox SGK;
        override protected void InitializeControls()
        {
            PassQuarantineForInpatient = (ITTCheckBox)AddControl(new Guid("5f44ff75-ec86-468d-b20b-74fa991d20dc"));
            labelSecureType = (ITTLabel)AddControl(new Guid("8a6e7eaa-867e-4139-9cc1-8dd753564c41"));
            SecureType = (ITTEnumComboBox)AddControl(new Guid("acd97ad9-ce69-4968-97eb-ad55da822c20"));
            labelEpisodeClosingDayLimit = (ITTLabel)AddControl(new Guid("52a24887-c15b-4419-a322-608932dc7444"));
            EpisodeClosingDayLimit = (ITTTextBox)AddControl(new Guid("6d224610-72b8-42ce-9ac6-88a85d0b2464"));
            OrderNo = (ITTTextBox)AddControl(new Guid("3e7b2327-9352-408a-942e-88e63fac56fc"));
            MedulaRequrements = (ITTGroupBox)AddControl(new Guid("032d8662-c728-4b0f-9e4d-02e1a2844bf6"));
            provizyonTipi = (ITTListDefComboBox)AddControl(new Guid("aaeaf991-5d7c-4b17-af89-7507b70b4144"));
            labeltedaviTipi = (ITTLabel)AddControl(new Guid("86591bb0-cd0e-4878-8d88-e7afa1811160"));
            labelsigortaliTuru = (ITTLabel)AddControl(new Guid("6d78bfcb-6369-403b-8a06-3cd7b515ff83"));
            labeltakipTipi = (ITTLabel)AddControl(new Guid("2362ad97-e26e-46e5-813e-340378ff0a5f"));
            sigortaliTuru = (ITTListDefComboBox)AddControl(new Guid("d6e1ef9c-8799-4621-8917-0a847ac945ef"));
            labeldevredilenKurum = (ITTLabel)AddControl(new Guid("42053879-7993-4aa5-9519-a5a77b8b3f01"));
            takipTipi = (ITTListDefComboBox)AddControl(new Guid("1c261d8d-c90c-4786-82c8-0fc63d205486"));
            devredilenKurum = (ITTListDefComboBox)AddControl(new Guid("32d33c7c-7392-4fba-a65e-068959b2d614"));
            tedaviTipi = (ITTListDefComboBox)AddControl(new Guid("16503282-c1de-4883-bf07-dd51e15a8e16"));
            labeltedaviTuru = (ITTLabel)AddControl(new Guid("97f34361-fc10-425e-9ce5-d6191f16d03d"));
            labelprovizyonTipi = (ITTLabel)AddControl(new Guid("ea1a360a-cd70-49ed-a031-a5ca4bf132a3"));
            tedaviTuru = (ITTListDefComboBox)AddControl(new Guid("f9c87377-0d59-4016-b9c5-d2f6e8ad4564"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b63f2f37-02bd-40ec-9822-19ed435ec8fd"));
            RequiredAdvance = (ITTCheckBox)AddControl(new Guid("c7c7d727-57ab-4eb0-9a1d-1f827c4dac8d"));
            MlitaryPersonnel = (ITTCheckBox)AddControl(new Guid("485752b8-c832-493f-b20c-80dd26afac3b"));
            RequiredFinancialDepartmentControl = (ITTCheckBox)AddControl(new Guid("f325cff6-3f8a-4b2f-9537-f618ef671a18"));
            PatientGroupEnum = (ITTEnumComboBox)AddControl(new Guid("8ca7b762-5662-4fa5-8b45-5cb1a05e2523"));
            labelPatientGroupEnum = (ITTLabel)AddControl(new Guid("31bb42ac-9ea7-478a-a94d-b3ffc924808e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ba044bea-cc2c-406f-8df3-95029b777de8"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("e4ee23de-b625-4891-ae41-6b7d511e20c0"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("a18592c6-a410-40d0-899f-542d1b3f578a"));
            AdmitAccordingToMainGroup = (ITTCheckBox)AddControl(new Guid("1c442821-2532-446f-b7d3-0bfce03e100d"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("5fb030e1-62b7-46ea-9fe9-ed40c407dcf2"));
            ReasonForAdmissions = (ITTGrid)AddControl(new Guid("192cda71-53f9-4b23-91cf-29798ae8d3cc"));
            ReasonForAdmission = (ITTEnumComboBoxColumn)AddControl(new Guid("39c6715f-3fba-4f08-9374-4f77145417ec"));
            labelBeneficiary = (ITTLabel)AddControl(new Guid("19ab6990-0cae-40ff-81ee-852cf87ae8b6"));
            Beneficiary = (ITTEnumComboBox)AddControl(new Guid("a14396e7-a9ed-40f0-b591-78d600a2594a"));
            RequiredQuota = (ITTCheckBox)AddControl(new Guid("c00445ac-30a6-443a-9a71-aa0e3ea24af8"));
            RequiredMedulaProvision = (ITTCheckBox)AddControl(new Guid("bff05168-ff9b-4516-80d7-b65377b59ae5"));
            ForeignUsage = (ITTEnumComboBox)AddControl(new Guid("29af1f5f-2b07-446c-8b70-fc76d5d02db9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("441f2c76-6436-44b5-a99b-eedfcbb7e7de"));
            IsRequiredSmartdCard = (ITTCheckBox)AddControl(new Guid("21a159ae-24a0-4dc0-99f1-23d3a71f04bc"));
            GetPatientParticipation = (ITTCheckBox)AddControl(new Guid("f215d267-35a6-4eb8-bc8b-f60ba62ba7a6"));
            chkIsActive = (ITTCheckBox)AddControl(new Guid("ca446832-49ee-4310-81d2-bc0e18a310c5"));
            PatientGroupType = (ITTEnumComboBox)AddControl(new Guid("6e18d1db-04d3-41b5-b4d8-4b26cdef36e3"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c88a37dc-5569-4707-a5ed-08978e4d63a9"));
            SGK = (ITTCheckBox)AddControl(new Guid("b3b0f0ed-e778-4dd3-9bf3-d37d5341bba8"));
            base.InitializeControls();
        }

        public PatientGroupDefinitionForm() : base("PATIENTGROUPDEFINITION", "PatientGroupDefinitionForm")
        {
        }

        protected PatientGroupDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}