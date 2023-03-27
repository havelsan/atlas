
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
    /// Pupil Bulgular
    /// </summary>
    public partial class NursingPupilSymptomsForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Pupil Bulgular
    /// </summary>
        protected TTObjectClasses.NursingPupilSymptoms _NursingPupilSymptoms
        {
            get { return (TTObjectClasses.NursingPupilSymptoms)_ttObject; }
        }

        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelRightPupilWideness;
        protected ITTEnumComboBox RightPupilWideness;
        protected ITTLabel labelRightPupil;
        protected ITTEnumComboBox RightPupil;
        protected ITTLabel labelRightGleamRef;
        protected ITTEnumComboBox RightGleamRef;
        protected ITTLabel labelLeftPupilWideness;
        protected ITTEnumComboBox LeftPupilWideness;
        protected ITTLabel labelLeftPupil;
        protected ITTEnumComboBox LeftPupil;
        protected ITTLabel labelLeftGleamRef;
        protected ITTEnumComboBox LeftGleamRef;
        override protected void InitializeControls()
        {
            labelApplicationDate = (ITTLabel)AddControl(new Guid("3177e1e6-9e1e-4bb1-9d1c-dd6ff2b0ad4b"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("0f4cf126-72d2-445e-8308-dcf78316b06e"));
            labelRightPupilWideness = (ITTLabel)AddControl(new Guid("0b8a75a7-7e32-451e-81a5-09149f63fcdc"));
            RightPupilWideness = (ITTEnumComboBox)AddControl(new Guid("17d75610-dadd-4bff-b9ff-01dbca5a0cac"));
            labelRightPupil = (ITTLabel)AddControl(new Guid("77928c1e-55e6-4595-bcc0-23ac281985e0"));
            RightPupil = (ITTEnumComboBox)AddControl(new Guid("1105c681-f218-4197-a7e2-5d7751a97f70"));
            labelRightGleamRef = (ITTLabel)AddControl(new Guid("79b23ce5-476b-415c-adca-52ead34ea1b8"));
            RightGleamRef = (ITTEnumComboBox)AddControl(new Guid("bf11da1d-a4b4-483e-a643-5888b19b1e2d"));
            labelLeftPupilWideness = (ITTLabel)AddControl(new Guid("1d90fe72-bbf5-433f-9336-9e994e286bd8"));
            LeftPupilWideness = (ITTEnumComboBox)AddControl(new Guid("fc22100c-6d70-46da-8ac0-5d2f416676fb"));
            labelLeftPupil = (ITTLabel)AddControl(new Guid("6c675b82-38ac-4ffb-818f-349e44b758c7"));
            LeftPupil = (ITTEnumComboBox)AddControl(new Guid("000c862d-649b-4aff-8006-a1d02eeee8a0"));
            labelLeftGleamRef = (ITTLabel)AddControl(new Guid("2bd1d4f1-dc2b-46bd-985e-28a6131909f0"));
            LeftGleamRef = (ITTEnumComboBox)AddControl(new Guid("a31fbd4f-a05a-4a69-9d5d-8e2a4a14f003"));
            base.InitializeControls();
        }

        public NursingPupilSymptomsForm() : base("NURSINGPUPILSYMPTOMS", "NursingPupilSymptomsForm")
        {
        }

        protected NursingPupilSymptomsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}