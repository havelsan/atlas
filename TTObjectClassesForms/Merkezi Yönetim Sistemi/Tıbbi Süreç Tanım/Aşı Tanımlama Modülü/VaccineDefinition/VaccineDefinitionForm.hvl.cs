
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
    /// Aşı Tanımlama Formu
    /// </summary>
    public partial class VaccineDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Aşı Tanımlama Modülü
    /// </summary>
        protected TTObjectClasses.VaccineDefinition _VaccineDefinition
        {
            get { return (TTObjectClasses.VaccineDefinition)_ttObject; }
        }

        protected ITTCheckBox cbxIsActive;
        protected ITTLabel labelSKRSAsiKodu;
        protected ITTObjectListBox SKRSAsiKodu;
        protected ITTGrid VaccinePeriodGrid;
        protected ITTTextBoxColumn PeriodNumberVaccinePeriodGrid;
        protected ITTTextBoxColumn PeriodDescriptionVaccinePeriodGrid;
        protected ITTTextBoxColumn PeriodVaccinePeriodGrid;
        protected ITTEnumComboBoxColumn PeriodTypeVaccinePeriodGrid;
        protected ITTLabel labelPeriodCriterion;
        protected ITTEnumComboBox PeriodCriterion;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox MaxPeriodRange;
        protected ITTTextBox Code;
        protected ITTLabel labelMaxPeriodRangeUnit;
        protected ITTEnumComboBox MaxPeriodRangeUnit;
        protected ITTLabel labelMaxPeriodRange;
        protected ITTLabel labelCode;
        protected ITTLabel labelAutoAddAgeType;
        protected ITTEnumComboBox AutoAddAgeType;
        protected ITTCheckBox AutoAdd;
        override protected void InitializeControls()
        {
            cbxIsActive = (ITTCheckBox)AddControl(new Guid("6f25d449-4c84-42b3-81ad-5e3d54aa6650"));
            labelSKRSAsiKodu = (ITTLabel)AddControl(new Guid("de018a27-842a-4f78-a6c9-f4a62997f50f"));
            SKRSAsiKodu = (ITTObjectListBox)AddControl(new Guid("4bf213d1-04aa-476b-bf8a-687bee9c4b4e"));
            VaccinePeriodGrid = (ITTGrid)AddControl(new Guid("085e7113-6928-41c8-9b98-7cdc1452317e"));
            PeriodNumberVaccinePeriodGrid = (ITTTextBoxColumn)AddControl(new Guid("a4da0200-df17-4ad6-8c6e-184e757bf2a2"));
            PeriodDescriptionVaccinePeriodGrid = (ITTTextBoxColumn)AddControl(new Guid("87b3469a-3026-41ad-be8a-5f164888baeb"));
            PeriodVaccinePeriodGrid = (ITTTextBoxColumn)AddControl(new Guid("8f363abc-8cf6-433d-bfa6-47949a7f7722"));
            PeriodTypeVaccinePeriodGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("d9cafe1b-1b35-4b60-a52d-a3d9bd54ca9a"));
            labelPeriodCriterion = (ITTLabel)AddControl(new Guid("a8f8f5a6-91be-4200-8234-11b5fb39ad7d"));
            PeriodCriterion = (ITTEnumComboBox)AddControl(new Guid("5507fa78-72d1-4450-93bf-6e57929405be"));
            labelName = (ITTLabel)AddControl(new Guid("c0cb8819-307d-4437-a1b5-4fd5a6098cb1"));
            Name = (ITTTextBox)AddControl(new Guid("f71b5425-de87-4ffe-8d83-af3612409f06"));
            MaxPeriodRange = (ITTTextBox)AddControl(new Guid("656f8bf1-e677-430d-9a70-421818ceff36"));
            Code = (ITTTextBox)AddControl(new Guid("680a6814-f04d-4654-96ad-fb46c122f5c7"));
            labelMaxPeriodRangeUnit = (ITTLabel)AddControl(new Guid("3229873f-1a74-4b77-8a07-c60270e16313"));
            MaxPeriodRangeUnit = (ITTEnumComboBox)AddControl(new Guid("c7a3be8a-a5bc-4732-996f-19b71bba3a88"));
            labelMaxPeriodRange = (ITTLabel)AddControl(new Guid("1c88945c-9405-4039-9cfd-6ebea5cf4ba4"));
            labelCode = (ITTLabel)AddControl(new Guid("ff3f2b38-eb43-4b3b-9275-87e0ddbe6c61"));
            labelAutoAddAgeType = (ITTLabel)AddControl(new Guid("0143ff89-886e-4aff-9610-c961eccded79"));
            AutoAddAgeType = (ITTEnumComboBox)AddControl(new Guid("8b9dfce8-7067-4866-b7ae-a8ad81809109"));
            AutoAdd = (ITTCheckBox)AddControl(new Guid("19c875f6-3e01-41e5-af8f-2f3c74795041"));
            base.InitializeControls();
        }

        public VaccineDefinitionForm() : base("VACCINEDEFINITION", "VaccineDefinitionForm")
        {
        }

        protected VaccineDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}