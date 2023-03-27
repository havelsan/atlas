
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
    public partial class VitalSignValueDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Vital Bulgular Normal Değer Tanımları
    /// </summary>
        protected TTObjectClasses.VitalSignValueDefinition _VitalSignValueDefinition
        {
            get { return (TTObjectClasses.VitalSignValueDefinition)_ttObject; }
        }

        protected ITTLabel labelSex;
        protected ITTObjectListBox Sex;
        protected ITTLabel labelMinValueWarning;
        protected ITTTextBox MinValueWarning;
        protected ITTTextBox MaxValueWarning;
        protected ITTTextBox MaxValue;
        protected ITTTextBox MinValue;
        protected ITTTextBox MaxAge;
        protected ITTTextBox MinAge;
        protected ITTLabel labelMaxValueWarning;
        protected ITTCheckBox chkIsActive;
        protected ITTLabel labelMaxValue;
        protected ITTLabel labelMinValue;
        protected ITTLabel labelMaxAge;
        protected ITTLabel labelMinAge;
        protected ITTLabel labelVitalSignType;
        protected ITTEnumComboBox VitalSignType;
        override protected void InitializeControls()
        {
            labelSex = (ITTLabel)AddControl(new Guid("97cf660a-75b2-46d6-a9c0-682e276cc23f"));
            Sex = (ITTObjectListBox)AddControl(new Guid("99a87ca0-7d95-4475-a774-7b401933a60f"));
            labelMinValueWarning = (ITTLabel)AddControl(new Guid("32be3394-54b4-4529-baf7-3948a5408c81"));
            MinValueWarning = (ITTTextBox)AddControl(new Guid("0b8b5785-1a17-4c13-b56c-ae748984fca5"));
            MaxValueWarning = (ITTTextBox)AddControl(new Guid("dc70935f-b282-4067-b39e-2baab50f95ea"));
            MaxValue = (ITTTextBox)AddControl(new Guid("9fe27ad7-5659-4841-9ab5-33c5efc8233e"));
            MinValue = (ITTTextBox)AddControl(new Guid("efe925c3-dfc7-44bd-9d24-d43ee332def7"));
            MaxAge = (ITTTextBox)AddControl(new Guid("347df195-196e-477d-a8d8-575736b41d67"));
            MinAge = (ITTTextBox)AddControl(new Guid("a9eeb2dd-75da-4a72-bc05-5fd26d13b085"));
            labelMaxValueWarning = (ITTLabel)AddControl(new Guid("4b4ad38a-00cf-44f4-a106-fca0126ca4ec"));
            chkIsActive = (ITTCheckBox)AddControl(new Guid("c3ee0dbd-78bf-41a2-8070-a815ecc4cf8f"));
            labelMaxValue = (ITTLabel)AddControl(new Guid("d948d435-8982-4dcd-a06d-0d58083aabc3"));
            labelMinValue = (ITTLabel)AddControl(new Guid("c6401168-e76c-4c6b-9f8d-520af127f546"));
            labelMaxAge = (ITTLabel)AddControl(new Guid("22a6474d-766e-4e35-b808-377b4aa47761"));
            labelMinAge = (ITTLabel)AddControl(new Guid("73b72ff2-e867-412b-a2c7-3bfdfedf58d2"));
            labelVitalSignType = (ITTLabel)AddControl(new Guid("40abeb50-2405-4929-9e8a-cba49041f7b2"));
            VitalSignType = (ITTEnumComboBox)AddControl(new Guid("140e778b-a132-46a2-bde8-2cc7d2494d51"));
            base.InitializeControls();
        }

        public VitalSignValueDefinitionForm() : base("VITALSIGNVALUEDEFINITION", "VitalSignValueDefinitionForm")
        {
        }

        protected VitalSignValueDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}