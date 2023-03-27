
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
    /// Hemşirelik Uygulamaları -Yaşam Bulguları (Vital Bulgular) Tanımlama
    /// </summary>
    public partial class VitalSignAndNursingDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Vital Bulgu ve Hemşirelik İşlemleri Tanımlama
    /// </summary>
        protected TTObjectClasses.VitalSignAndNursingDefinition _VitalSignAndNursingDefinition
        {
            get { return (TTObjectClasses.VitalSignAndNursingDefinition)_ttObject; }
        }

        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTGrid Values;
        protected ITTTextBoxColumn NameVitalSignAndNursingValueDefinition;
        protected ITTLabel labelVitalSignType;
        protected ITTEnumComboBox VitalSignType;
        protected ITTCheckBox DontNeedDataDuringApplication;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTCheckBox Chargable;
        override protected void InitializeControls()
        {
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("5557a1de-75e8-45c5-91d1-d7bed3ed8ece"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("72d79f34-9626-46f5-a311-2195d3a149b3"));
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("065202f8-809c-441e-8c79-90738b0511c7"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("135782f9-d92b-435c-83b2-1a35eae609cb"));
            Values = (ITTGrid)AddControl(new Guid("e3932bfe-b513-4a79-b0e7-34a4127fe087"));
            NameVitalSignAndNursingValueDefinition = (ITTTextBoxColumn)AddControl(new Guid("3b99f84f-3bd7-44e1-9f41-9515a5550f4c"));
            labelVitalSignType = (ITTLabel)AddControl(new Guid("105c59ea-34f4-4458-afe6-14d2d7f0b06d"));
            VitalSignType = (ITTEnumComboBox)AddControl(new Guid("dc7d404f-5fc9-44f3-8d61-1ecb3547057c"));
            DontNeedDataDuringApplication = (ITTCheckBox)AddControl(new Guid("c3177414-a754-4335-9a78-b6bc757c5514"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c623e834-26d9-498c-a9ef-e78999a83c6f"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("f5fc2e07-e2ac-4df4-95de-009593778f35"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6d6ed74a-7a3c-488c-b63b-ba9b76181468"));
            labelQref = (ITTLabel)AddControl(new Guid("1b4d2c36-e0d5-468e-832e-452502d99e90"));
            Qref = (ITTTextBox)AddControl(new Guid("f94cfaae-473d-45c5-a264-a896144f049f"));
            Name = (ITTTextBox)AddControl(new Guid("480a5915-bacf-42ff-a6ff-4ef84347990f"));
            EnglishName = (ITTTextBox)AddControl(new Guid("8cc4ba4d-8f61-47ee-895d-3d422cef07c9"));
            Description = (ITTTextBox)AddControl(new Guid("03d5f5f9-d22a-4811-a826-b7789388c365"));
            Code = (ITTTextBox)AddControl(new Guid("1bc5f18c-306c-4f54-ad0c-e666879f92e0"));
            labelName = (ITTLabel)AddControl(new Guid("a8dff9a8-1c7e-44e5-baf1-6d9e903899da"));
            IsActive = (ITTCheckBox)AddControl(new Guid("cc382730-1072-4a12-a8a3-a0508cd567ca"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("37069aec-e4fe-4ff0-bbbe-dc016d6ec2bf"));
            labelDescription = (ITTLabel)AddControl(new Guid("fe5a46eb-f097-42d2-bad1-7d33cb4880a3"));
            labelCode = (ITTLabel)AddControl(new Guid("324c2edc-a533-45dd-8353-73a6784be685"));
            Chargable = (ITTCheckBox)AddControl(new Guid("77b6c92b-dbba-4d6d-8777-c8cac187bd43"));
            base.InitializeControls();
        }

        public VitalSignAndNursingDefinitionForm() : base("VITALSIGNANDNURSINGDEFINITION", "VitalSignAndNursingDefinitionForm")
        {
        }

        protected VitalSignAndNursingDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}