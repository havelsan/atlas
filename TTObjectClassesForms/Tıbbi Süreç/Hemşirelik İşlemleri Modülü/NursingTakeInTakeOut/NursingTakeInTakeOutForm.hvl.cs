
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
    /// Aldığı Çıkardığı Formu
    /// </summary>
    public partial class NursingTakeInTakeOutForm : TTForm
    {
        protected TTObjectClasses.NursingTakeInTakeOut _NursingTakeInTakeOut
        {
            get { return (TTObjectClasses.NursingTakeInTakeOut)_ttObject; }
        }

        protected ITTLabel labelTakeInTakeOut;
        protected ITTObjectListBox TakeInTakeOut;
        protected ITTLabel labelVomiting;
        protected ITTTextBox Vomiting;
        protected ITTLabel labelUretic;
        protected ITTTextBox Uretic;
        protected ITTLabel labelOral;
        protected ITTTextBox Oral;
        protected ITTLabel labelIVInf;
        protected ITTTextBox IVInf;
        protected ITTLabel labelGaita;
        protected ITTTextBox Gaita;
        protected ITTLabel labelDren;
        protected ITTTextBox Dren;
        protected ITTLabel labelBleeding;
        protected ITTTextBox Bleeding;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTEnumComboBox HourInterval;
        protected ITTLabel labelHourInterval;
        protected ITTLabel labelNote;
        protected ITTTextBox Explanation;
        override protected void InitializeControls()
        {
            labelTakeInTakeOut = (ITTLabel)AddControl(new Guid("1e6eb518-1afa-4854-9109-864d5954adf1"));
            TakeInTakeOut = (ITTObjectListBox)AddControl(new Guid("5fe97e0a-cd32-4786-8b2d-0b6328db02c9"));
            labelVomiting = (ITTLabel)AddControl(new Guid("2ddc0a0e-4804-47bd-9f4d-35f37f22ece9"));
            Vomiting = (ITTTextBox)AddControl(new Guid("5258b0b2-5c36-4ec5-abba-830254dcb8ab"));
            labelUretic = (ITTLabel)AddControl(new Guid("131b23c5-9380-46b5-8708-e3c28bc71171"));
            Uretic = (ITTTextBox)AddControl(new Guid("ec668f21-ddcd-47ee-a877-3bde09e923d8"));
            labelOral = (ITTLabel)AddControl(new Guid("ed7e853e-69d3-4034-bb26-0f7988aa7d4e"));
            Oral = (ITTTextBox)AddControl(new Guid("6371c497-7b9e-4538-ac24-79c3103a82c8"));
            labelIVInf = (ITTLabel)AddControl(new Guid("0866484c-05be-4b2e-9291-2175b3498177"));
            IVInf = (ITTTextBox)AddControl(new Guid("7df3eb9b-b65c-4874-ab81-54e8408bc33e"));
            labelGaita = (ITTLabel)AddControl(new Guid("af2a011b-7dde-4039-a293-a9a0583a09fb"));
            Gaita = (ITTTextBox)AddControl(new Guid("5763042c-b937-4283-8293-624c27fe58c5"));
            labelDren = (ITTLabel)AddControl(new Guid("c39f4afc-50f6-4c47-8193-bfec6a5da296"));
            Dren = (ITTTextBox)AddControl(new Guid("eb78db79-3caa-4b88-aabd-1735a872f834"));
            labelBleeding = (ITTLabel)AddControl(new Guid("24094942-761f-46ed-84c2-feaea16f1d4a"));
            Bleeding = (ITTTextBox)AddControl(new Guid("2b83fd57-3437-4c57-b491-f225fdbc531b"));
            labelActionDate = (ITTLabel)AddControl(new Guid("0fea855e-f9cf-4b1b-979d-84a7a5d48311"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("6b89477f-bb2c-4762-abe4-9afe530f6f00"));
            HourInterval = (ITTEnumComboBox)AddControl(new Guid("aec795f2-eaa3-4eae-9a78-a7a0f750afdc"));
            labelHourInterval = (ITTLabel)AddControl(new Guid("7cedf3de-149e-4c42-8bed-e48181dd724f"));
            labelNote = (ITTLabel)AddControl(new Guid("7bd614d9-4732-4df3-9e62-53168aa6ae72"));
            Explanation = (ITTTextBox)AddControl(new Guid("58abcfc0-f5e9-4a95-b53b-c0cc78cdfb50"));
            base.InitializeControls();
        }

        public NursingTakeInTakeOutForm() : base("NURSINGTAKEINTAKEOUT", "NursingTakeInTakeOutForm")
        {
        }

        protected NursingTakeInTakeOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}