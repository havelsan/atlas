
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
    /// Muayene Tedavi Sonuç Kopya Sayısı Tanımları
    /// </summary>
    public partial class TreamentDischargeByPatientGroupDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Muayene Tedavi Sonuç Kopya Sayısı Tanımlama Modülü
    /// </summary>
        protected TTObjectClasses.TreatmentDischargeByPatientGroupDefinition _TreatmentDischargeByPatientGroupDefinition
        {
            get { return (TTObjectClasses.TreatmentDischargeByPatientGroupDefinition)_ttObject; }
        }

        protected ITTEnumComboBox OutpatientApprovement;
        protected ITTLabel labelInpatientApprovement;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel labelPatientGroup;
        protected ITTLabel labelOutpatientApprovement;
        protected ITTGrid InpatientNumberOfCopies;
        protected ITTCheckBoxColumn AutoPrint;
        protected ITTCheckBoxColumn NotPrintIfMilitaryUnitIsEqualToSenderChair;
        protected ITTCheckBoxColumn NotPrintOtherIfHospExist;
        protected ITTCheckBoxColumn PrintFileIfHospitalExits;
        protected ITTTextBoxColumn ToAccountingOffice;
        protected ITTTextBoxColumn ToExaminationSenderUnit;
        protected ITTTextBoxColumn ToHospitalSendingTo;
        protected ITTTextBoxColumn ToMilitaryOffice;
        protected ITTTextBoxColumn ToMilitaryUnit;
        protected ITTTextBoxColumn ToPatientFolder;
        protected ITTTextBoxColumn ToSupplierUnit;
        protected ITTGrid OutpatientNumberOfCopies;
        protected ITTCheckBoxColumn OPAutoPrint;
        protected ITTCheckBoxColumn OPNotPrintIfMilitaryUnitIsEqualToSenderChair;
        protected ITTCheckBoxColumn OPNotPrintOthersIfHospExists;
        protected ITTCheckBoxColumn OPPrintFileIfHospitalExits;
        protected ITTTextBoxColumn OPToAccountingOffice;
        protected ITTTextBoxColumn OPToExaminationSenderUnit;
        protected ITTTextBoxColumn OPToHospitalSendingTo;
        protected ITTTextBoxColumn OPToMilitaryOffice;
        protected ITTTextBoxColumn OPToMilitaryUnit;
        protected ITTTextBoxColumn OPToPatientFolder;
        protected ITTTextBoxColumn OPToSupplierUnit;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox Active;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox InpatientApprovement;
        override protected void InitializeControls()
        {
            OutpatientApprovement = (ITTEnumComboBox)AddControl(new Guid("8524ed5d-89de-4ee9-bac0-027db29a1fbd"));
            labelInpatientApprovement = (ITTLabel)AddControl(new Guid("40c2fda5-598f-457c-8e2e-10fc10d93e45"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("a8f14d13-7e83-46f0-96bf-17d250fc0145"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("d672af9c-3ffe-42f3-94b8-1b55927e8e7e"));
            labelOutpatientApprovement = (ITTLabel)AddControl(new Guid("9694f359-5c92-407c-aaa5-2d31bc4e222f"));
            InpatientNumberOfCopies = (ITTGrid)AddControl(new Guid("d37e0c80-dfe6-4d77-b6a5-2f40e73d4564"));
            AutoPrint = (ITTCheckBoxColumn)AddControl(new Guid("80ae7b35-c9dc-4b4f-9ff2-b18907a2be33"));
            NotPrintIfMilitaryUnitIsEqualToSenderChair = (ITTCheckBoxColumn)AddControl(new Guid("7fb4e1db-6daf-447d-b4c7-3109cb27892a"));
            NotPrintOtherIfHospExist = (ITTCheckBoxColumn)AddControl(new Guid("d2be76b1-a5a6-4fba-a80b-b54471bbcb1a"));
            PrintFileIfHospitalExits = (ITTCheckBoxColumn)AddControl(new Guid("4d533f37-96d3-4c9e-8104-a4df9fce44ab"));
            ToAccountingOffice = (ITTTextBoxColumn)AddControl(new Guid("468cf448-3608-49c9-898f-177c0b3e3a88"));
            ToExaminationSenderUnit = (ITTTextBoxColumn)AddControl(new Guid("112ff391-9d09-45c3-b664-24a509564166"));
            ToHospitalSendingTo = (ITTTextBoxColumn)AddControl(new Guid("7655c617-074e-441a-9e3d-9fa54bd59d91"));
            ToMilitaryOffice = (ITTTextBoxColumn)AddControl(new Guid("d96d86bc-ced4-4dc7-81cc-f997c5118eac"));
            ToMilitaryUnit = (ITTTextBoxColumn)AddControl(new Guid("0b249acf-c76f-4096-a749-5d9c326d9627"));
            ToPatientFolder = (ITTTextBoxColumn)AddControl(new Guid("d79acd38-9349-4847-b963-44cabb7bd29a"));
            ToSupplierUnit = (ITTTextBoxColumn)AddControl(new Guid("598d7892-f779-41d5-924c-369d9bb46e6a"));
            OutpatientNumberOfCopies = (ITTGrid)AddControl(new Guid("69ed928d-be61-49c4-9493-5d1756dbbb60"));
            OPAutoPrint = (ITTCheckBoxColumn)AddControl(new Guid("d8edc85a-dae8-463d-8f53-ed9174065fb9"));
            OPNotPrintIfMilitaryUnitIsEqualToSenderChair = (ITTCheckBoxColumn)AddControl(new Guid("f288a3bf-23ea-4743-882a-e73441d17d9c"));
            OPNotPrintOthersIfHospExists = (ITTCheckBoxColumn)AddControl(new Guid("bb73ba51-57b5-496a-b98e-01a376372b06"));
            OPPrintFileIfHospitalExits = (ITTCheckBoxColumn)AddControl(new Guid("bbba7a3b-7652-4f07-8f39-4f85c5059401"));
            OPToAccountingOffice = (ITTTextBoxColumn)AddControl(new Guid("69e22a99-666e-4bd1-a1a1-d732aaaae836"));
            OPToExaminationSenderUnit = (ITTTextBoxColumn)AddControl(new Guid("d199d0fe-8b41-489d-86bb-78ef1e639684"));
            OPToHospitalSendingTo = (ITTTextBoxColumn)AddControl(new Guid("c9c58916-7b24-4009-a2dd-ee5f0a51b453"));
            OPToMilitaryOffice = (ITTTextBoxColumn)AddControl(new Guid("d764cd18-4acb-445d-9754-989e2234b896"));
            OPToMilitaryUnit = (ITTTextBoxColumn)AddControl(new Guid("0e5bbd25-27f5-47ad-ba1d-db733b536399"));
            OPToPatientFolder = (ITTTextBoxColumn)AddControl(new Guid("b041316a-56fb-4dd2-be5d-cc7c3d0399cc"));
            OPToSupplierUnit = (ITTTextBoxColumn)AddControl(new Guid("62f77d73-6bd3-4031-839f-543bfce2c621"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f0d58408-dd80-415e-93b6-612de3a8316a"));
            Active = (ITTCheckBox)AddControl(new Guid("3aecaf68-6584-4b75-bf6c-6f0399c3e222"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("847ea712-2e84-4f87-9a05-b357ea0fde48"));
            InpatientApprovement = (ITTEnumComboBox)AddControl(new Guid("6a3aceb9-69db-4d55-82b8-c888580f76aa"));
            base.InitializeControls();
        }

        public TreamentDischargeByPatientGroupDefinitionForm() : base("TREATMENTDISCHARGEBYPATIENTGROUPDEFINITION", "TreamentDischargeByPatientGroupDefinitionForm")
        {
        }

        protected TreamentDischargeByPatientGroupDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}