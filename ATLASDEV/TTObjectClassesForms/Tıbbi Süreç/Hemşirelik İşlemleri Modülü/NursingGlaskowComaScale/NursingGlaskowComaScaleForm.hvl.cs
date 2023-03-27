
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
    /// Glaskow Koma  Skalası
    /// </summary>
    public partial class NursingGlaskowComaScaleForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Glaskow Koma Skalası
    /// </summary>
        protected TTObjectClasses.NursingGlaskowComaScale _NursingGlaskowComaScale
        {
            get { return (TTObjectClasses.NursingGlaskowComaScale)_ttObject; }
        }

        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelMotorAnswer;
        protected ITTObjectListBox MotorAnswer;
        protected ITTLabel labelEyes;
        protected ITTObjectListBox Eyes;
        protected ITTLabel labelOralAnswer;
        protected ITTObjectListBox OralAnswer;
        protected ITTLabel labelTotalScore;
        protected ITTEnumComboBox TotalScore;
        protected ITTLabel labelNote;
        protected ITTTextBox Note;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelApplicationDate = (ITTLabel)AddControl(new Guid("1d4f7a55-330f-4a3f-becf-e333f501cd22"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("30427577-56f8-4457-9fbe-0c29e9e8f79d"));
            labelMotorAnswer = (ITTLabel)AddControl(new Guid("194a174e-ba46-48cd-a060-1e95805e14fa"));
            MotorAnswer = (ITTObjectListBox)AddControl(new Guid("82dc4155-ec11-4b0f-9b70-fb987ed8aba8"));
            labelEyes = (ITTLabel)AddControl(new Guid("fcf09f54-88a2-4d98-962f-fae1fcfb5b1b"));
            Eyes = (ITTObjectListBox)AddControl(new Guid("0d7068e0-7aed-45a5-9774-41f83ba1f29b"));
            labelOralAnswer = (ITTLabel)AddControl(new Guid("bbed777b-0fcf-4e6b-aed0-bc5454265193"));
            OralAnswer = (ITTObjectListBox)AddControl(new Guid("5ac12fc5-e988-4624-8040-fdebe10efea7"));
            labelTotalScore = (ITTLabel)AddControl(new Guid("20812c38-7b5e-48fc-97f0-c5389b037942"));
            TotalScore = (ITTEnumComboBox)AddControl(new Guid("1a4f3be5-8675-4f65-9106-a7b384d59a95"));
            labelNote = (ITTLabel)AddControl(new Guid("86910764-1980-41f0-9328-4b0d4d66af2c"));
            Note = (ITTTextBox)AddControl(new Guid("81b89346-c5ef-49b8-85b4-74ad161a27d5"));
            labelActionDate = (ITTLabel)AddControl(new Guid("3966b9e4-8144-4c44-8518-70f0adc073cf"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("1ca0d0d8-cb0e-41ac-9525-d9a028acb800"));
            base.InitializeControls();
        }

        public NursingGlaskowComaScaleForm() : base("NURSINGGLASKOWCOMASCALE", "NursingGlaskowComaScaleForm")
        {
        }

        protected NursingGlaskowComaScaleForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}