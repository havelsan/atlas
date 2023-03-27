
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
    /// Sivil Stajyer Öğrenci Bilgileri
    /// </summary>
    public partial class NewCivilTraineeStudentForm : TTForm
    {
    /// <summary>
    /// Sivil Stajyer Öğrenci
    /// </summary>
        protected TTObjectClasses.MPBSCivilTraineeStudent _MPBSCivilTraineeStudent
        {
            get { return (TTObjectClasses.MPBSCivilTraineeStudent)_ttObject; }
        }

        protected ITTObjectListBox TrainingUnit;
        protected ITTTextBox IdentityNumber;
        protected ITTDateTimePicker StartDate;
        protected ITTTextBox Name;
        protected ITTTextBox Surname;
        protected ITTLabel labelTrainingUnit;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelName;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelIdentityNumber;
        protected ITTLabel labelSurname;
        protected ITTLabel labelEndDate;
        override protected void InitializeControls()
        {
            TrainingUnit = (ITTObjectListBox)AddControl(new Guid("1c6f8215-1dc2-42b4-9b9a-0337800fc597"));
            IdentityNumber = (ITTTextBox)AddControl(new Guid("bff54865-2d4d-46a5-bec8-049bc3bbc3bb"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("ec048a54-834d-4acf-a90e-25f3072c987e"));
            Name = (ITTTextBox)AddControl(new Guid("2441a3b4-4047-4ed8-927f-46c03a1d6d06"));
            Surname = (ITTTextBox)AddControl(new Guid("e94ea801-5524-4685-bf65-8a5367c3931b"));
            labelTrainingUnit = (ITTLabel)AddControl(new Guid("f1de322c-29a6-4010-97fa-a2a9a20723a6"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("29c0f5a7-e9dc-4038-9cf0-b3d4de1faa4e"));
            labelName = (ITTLabel)AddControl(new Guid("48cbeb7a-580c-4fb8-bee5-dfe92d08a5ac"));
            labelStartDate = (ITTLabel)AddControl(new Guid("772ec878-6267-4a92-a1e1-efc458def958"));
            labelIdentityNumber = (ITTLabel)AddControl(new Guid("8f94d702-a797-4c07-b122-e33799436d55"));
            labelSurname = (ITTLabel)AddControl(new Guid("d5fbfbdb-63d5-4b64-a3ad-f64956ecea0b"));
            labelEndDate = (ITTLabel)AddControl(new Guid("f40b2044-8d92-4120-a5b8-f3c4b7611de6"));
            base.InitializeControls();
        }

        public NewCivilTraineeStudentForm() : base("MPBSCIVILTRAINEESTUDENT", "NewCivilTraineeStudentForm")
        {
        }

        protected NewCivilTraineeStudentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}