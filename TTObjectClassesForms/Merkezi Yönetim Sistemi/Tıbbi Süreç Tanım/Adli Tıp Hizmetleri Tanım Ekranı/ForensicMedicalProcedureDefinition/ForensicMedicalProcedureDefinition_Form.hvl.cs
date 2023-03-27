
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
    /// Adli Tıp Hizmetleri Tanımı
    /// </summary>
    public partial class ForensicMedicalProcedureDefinition : TerminologyManagerDefForm
    {
    /// <summary>
    /// Adli Tıp Hizmetleri Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.ForensicMedicalProcedureDefinition _ForensicMedicalProcedureDefinition
        {
            get { return (TTObjectClasses.ForensicMedicalProcedureDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTCheckBox isForensicMedicalExamination;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTTextBox ID;
        protected ITTTextBox Qref;
        protected ITTLabel labelName;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTLabel labelQref;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelCode;
        protected ITTLabel labelID;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("3518c607-712f-4054-b1e1-a4fab2328beb"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("cf876fe9-2941-4629-b4f4-cf6a018fffea"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("69103949-c07f-45e1-9317-e1afa3b501db"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("5549f80e-5b4a-4042-ba84-cf8ebffc5e86"));
            isForensicMedicalExamination = (ITTCheckBox)AddControl(new Guid("e903dd29-43dc-4a03-8f4f-8a0b2e849824"));
            Description = (ITTTextBox)AddControl(new Guid("860a73e7-9348-4dac-afd2-ccb06b0e7d87"));
            Name = (ITTTextBox)AddControl(new Guid("4d49acd8-a753-4415-b5e4-c48f155a555f"));
            Code = (ITTTextBox)AddControl(new Guid("cd4677e4-2b87-4967-976b-2099c6c9b673"));
            ID = (ITTTextBox)AddControl(new Guid("218f409f-f888-48ae-9a4e-1b31ac72cf5e"));
            Qref = (ITTTextBox)AddControl(new Guid("1a4abed7-1a5b-41c7-b4d3-11a088ca74fc"));
            labelName = (ITTLabel)AddControl(new Guid("5cb09b53-bc93-4e3c-8b3f-a71a32b291f2"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("a3df4998-b1dd-4d02-8987-e3dadf3697b1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0e4a2f62-fb20-4cb0-8e5c-3a04d9a3aa5c"));
            labelDescription = (ITTLabel)AddControl(new Guid("4e62fdf8-ea83-4dd5-978d-ed1bf7399530"));
            labelQref = (ITTLabel)AddControl(new Guid("8c4946f0-ee58-4fa1-add8-6f4942d3a50c"));
            IsActive = (ITTCheckBox)AddControl(new Guid("b6260d14-1184-4852-9051-6a779b5b4b82"));
            labelCode = (ITTLabel)AddControl(new Guid("4a46d081-2cfa-4115-9c0b-b942545ebcca"));
            labelID = (ITTLabel)AddControl(new Guid("104eb1d6-9977-4c60-a24f-437d514e3a63"));
            base.InitializeControls();
        }

        public ForensicMedicalProcedureDefinition() : base("FORENSICMEDICALPROCEDUREDEFINITION", "ForensicMedicalProcedureDefinition")
        {
        }

        protected ForensicMedicalProcedureDefinition(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}