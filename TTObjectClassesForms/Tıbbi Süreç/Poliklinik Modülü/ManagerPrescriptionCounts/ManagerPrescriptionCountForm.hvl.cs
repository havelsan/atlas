
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
    public partial class ManagerPrescriptionCountForm : TTForm
    {
        protected TTObjectClasses.ManagerPrescriptionCounts _ManagerPrescriptionCounts
        {
            get { return (TTObjectClasses.ManagerPrescriptionCounts)_ttObject; }
        }

        protected ITTLabel labelPrescriptionCountRate;
        protected ITTTextBox PrescriptionCountRate;
        protected ITTTextBox TotalPrescriptionCounts;
        protected ITTTextBox PaperPrescriptionCount;
        protected ITTTextBox ePrescriptionCount;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelTotalPrescriptionCounts;
        protected ITTLabel labelPaperPrescriptionCount;
        protected ITTLabel labelePrescriptionCount;
        override protected void InitializeControls()
        {
            labelPrescriptionCountRate = (ITTLabel)AddControl(new Guid("0216a8a0-6946-4f86-a81c-79dbf660ac86"));
            PrescriptionCountRate = (ITTTextBox)AddControl(new Guid("722b5680-bcab-493f-b7ae-5f8d25b73a21"));
            TotalPrescriptionCounts = (ITTTextBox)AddControl(new Guid("67d289d9-c263-4344-a181-2878ffb261ff"));
            PaperPrescriptionCount = (ITTTextBox)AddControl(new Guid("e05c8872-eedd-4d1f-b894-1a554340f565"));
            ePrescriptionCount = (ITTTextBox)AddControl(new Guid("15671105-d5a7-48ac-8326-627743718c8a"));
            labelEndDate = (ITTLabel)AddControl(new Guid("513c3cc9-f542-45b8-b652-8d6bb38c80dd"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("74e34d94-c10c-4e76-8234-1bf741a17b1e"));
            labelStartDate = (ITTLabel)AddControl(new Guid("e38b506f-5e80-4687-b974-ec5f3f0992c7"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("17f36d98-e04f-4c8b-a050-2d42b94844fd"));
            labelTotalPrescriptionCounts = (ITTLabel)AddControl(new Guid("6fca331c-270b-4e86-abd7-e3f657fdc842"));
            labelPaperPrescriptionCount = (ITTLabel)AddControl(new Guid("2f4e6388-885c-4995-b8d3-546a41daaffd"));
            labelePrescriptionCount = (ITTLabel)AddControl(new Guid("55115884-066c-4ed9-b15f-2c948959f5e2"));
            base.InitializeControls();
        }

        public ManagerPrescriptionCountForm() : base("MANAGERPRESCRIPTIONCOUNTS", "ManagerPrescriptionCountForm")
        {
        }

        protected ManagerPrescriptionCountForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}