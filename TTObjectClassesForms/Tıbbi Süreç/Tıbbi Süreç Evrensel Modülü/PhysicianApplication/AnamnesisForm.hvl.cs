
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
    public partial class AnamnesisForm : TTForm
    {
    /// <summary>
    /// Muayene,Kontrol Muayenesi,Konsültasyon, Klinik Doktor İşlemleri gibi doktor işlemlerinin ana objesi
    /// </summary>
        protected TTObjectClasses.PhysicianApplication _PhysicianApplication
        {
            get { return (TTObjectClasses.PhysicianApplication)_ttObject; }
        }

        protected ITTLabel labelMTSConclusion;
        protected ITTRichTextBoxControl MTSConclusion;
        protected ITTLabel labelPhysicalExamination;
        protected ITTRichTextBoxControl PhysicalExamination;
        protected ITTLabel labelPatientHistory;
        protected ITTRichTextBoxControl PatientHistory;
        protected ITTLabel labelComplaint;
        protected ITTRichTextBoxControl Complaint;
        override protected void InitializeControls()
        {
            labelMTSConclusion = (ITTLabel)AddControl(new Guid("2f04aa31-87ae-4802-ac09-6025956f6fd7"));
            MTSConclusion = (ITTRichTextBoxControl)AddControl(new Guid("9f5d7201-7e8c-4228-991c-f7782bff4722"));
            labelPhysicalExamination = (ITTLabel)AddControl(new Guid("bdd66e3d-84e9-447d-ab81-35bc8cef4853"));
            PhysicalExamination = (ITTRichTextBoxControl)AddControl(new Guid("019c693b-ca0f-40bb-b9e7-d003cedaa07a"));
            labelPatientHistory = (ITTLabel)AddControl(new Guid("afa0ec45-671f-41b5-b121-d4e93382332b"));
            PatientHistory = (ITTRichTextBoxControl)AddControl(new Guid("d8731e76-b904-4260-a3aa-5ef0c1f24de8"));
            labelComplaint = (ITTLabel)AddControl(new Guid("0520e0d4-c0cb-4aca-be56-f19f32cc014a"));
            Complaint = (ITTRichTextBoxControl)AddControl(new Guid("b4487192-11c7-4941-bd4a-2517f66dab7d"));
            base.InitializeControls();
        }

        public AnamnesisForm() : base("PHYSICIANAPPLICATION", "AnamnesisForm")
        {
        }

        protected AnamnesisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}