
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
    public partial class MedicalStuffPrescriptionForm : TTForm
    {
    /// <summary>
    /// Tıbbi Malzeme Reçetesi
    /// </summary>
        protected TTObjectClasses.MedicalStuffPrescription _MedicalStuffPrescription
        {
            get { return (TTObjectClasses.MedicalStuffPrescription)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelDrugDescriptionType;
        protected ITTEnumComboBox DescriptionType;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage TabPage;
        protected ITTGrid MedicalStuffGrid;
        protected ITTTextBoxColumn Name;
        protected ITTTextBoxColumn Code;
        protected ITTListBoxColumn StuffGroup;
        protected ITTTextBoxColumn StuffAmount;
        protected ITTTextBoxColumn PeriodUnit;
        protected ITTEnumComboBoxColumn PeriodUnitType;
        protected ITTListBoxColumn StuffUsageType;
        protected ITTTextBoxColumn StuffOdyometryTestId;
        protected ITTListBoxColumn StuffUseofPlace;
        protected ITTTextBoxColumn StuffDescription;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("85bee2c5-5a57-4678-89fc-e9a09276dee5"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("11af4dc0-96a0-4f4d-8a2b-9f60838df81f"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("3b16b80f-0a11-4930-80de-184bfbb52a12"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("963fee77-4122-4d48-bcf9-daa3eb0096af"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("7ff06b9f-c223-4763-a8ad-391ffac24afa"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("6ae5984d-7a90-4c5f-9413-724da3275b97"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("15ccae55-3f44-4b6c-93b1-c2eb5b40e386"));
            labelDrugDescriptionType = (ITTLabel)AddControl(new Guid("a029aa03-d546-4e53-a403-37a815a7e5ee"));
            DescriptionType = (ITTEnumComboBox)AddControl(new Guid("7ece4d72-27ba-4d5f-8ad8-2934b5158c60"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("220eefb1-5b28-46c0-839f-cdb166ff9651"));
            TabPage = (ITTTabPage)AddControl(new Guid("b143abfb-c5cb-4532-87c5-38af2f679256"));
            MedicalStuffGrid = (ITTGrid)AddControl(new Guid("af858479-da1d-46d1-b2d5-cfc4cb08cffa"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("15990d0b-8914-4635-a060-4f1d272f65eb"));
            Code = (ITTTextBoxColumn)AddControl(new Guid("739a381c-4955-4829-8ea5-ee6b36bf953f"));
            StuffGroup = (ITTListBoxColumn)AddControl(new Guid("a4d9d87a-5282-4be7-916a-073addf3c6d1"));
            StuffAmount = (ITTTextBoxColumn)AddControl(new Guid("874a2e92-35c1-4858-9d08-a55c93ac0cb7"));
            PeriodUnit = (ITTTextBoxColumn)AddControl(new Guid("753ce87e-48b3-46fe-ac1f-eb534a18dcbf"));
            PeriodUnitType = (ITTEnumComboBoxColumn)AddControl(new Guid("516eaa0f-8224-4952-a5d4-6c24c2e15a52"));
            StuffUsageType = (ITTListBoxColumn)AddControl(new Guid("24c2edcd-82aa-435f-84b0-4d20ae953a75"));
            StuffOdyometryTestId = (ITTTextBoxColumn)AddControl(new Guid("db4e05ac-ecfb-4c16-8bfa-38df4b2f37a7"));
            StuffUseofPlace = (ITTListBoxColumn)AddControl(new Guid("ad7d955a-0351-4965-a7da-600fa063390a"));
            StuffDescription = (ITTTextBoxColumn)AddControl(new Guid("7df34eec-78ff-4ad8-9036-7320ea4c5e40"));
            base.InitializeControls();
        }

        public MedicalStuffPrescriptionForm() : base("MEDICALSTUFFPRESCRIPTION", "MedicalStuffPrescriptionForm")
        {
        }

        protected MedicalStuffPrescriptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}