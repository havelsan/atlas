
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
    /// Tıbbi Araştırma Dönem Tanımı 
    /// </summary>
    public partial class MedicalResarchTermDefFrom : TTDefinitionForm
    {
        protected TTObjectClasses.MedicalResarchTermDef _MedicalResarchTermDef
        {
            get { return (TTObjectClasses.MedicalResarchTermDef)_ttObject; }
        }

        protected ITTLabel labelDesciption;
        protected ITTTextBox Desciption;
        protected ITTTextBox TermBudgetPrice;
        protected ITTTextBox TermCode;
        protected ITTTextBox TermName;
        protected ITTLabel labelTermBudgetPrice;
        protected ITTLabel labelTermCode;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelTermName;
        override protected void InitializeControls()
        {
            labelDesciption = (ITTLabel)AddControl(new Guid("3e600708-a4fa-40e8-b232-1951fcbe9c27"));
            Desciption = (ITTTextBox)AddControl(new Guid("cbf51556-7680-4023-a119-ba6dca0c10ec"));
            TermBudgetPrice = (ITTTextBox)AddControl(new Guid("4f33de0d-ec44-4bec-8c3b-900ae6636d0d"));
            TermCode = (ITTTextBox)AddControl(new Guid("15825854-eab6-40a9-8c82-d3d7964ba232"));
            TermName = (ITTTextBox)AddControl(new Guid("967dd27a-75ea-4d6b-acd5-89971dbb1a59"));
            labelTermBudgetPrice = (ITTLabel)AddControl(new Guid("93963e91-db40-4b60-9e87-53ac3add472b"));
            labelTermCode = (ITTLabel)AddControl(new Guid("6bcf9856-e407-4317-a512-aa37cdf53e0d"));
            labelEndDate = (ITTLabel)AddControl(new Guid("0feb2329-c027-4dad-a614-09d694e0997a"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("515cf415-ed5e-44b1-8a56-b2f1bfcf8f62"));
            labelStartDate = (ITTLabel)AddControl(new Guid("aa890a02-f00d-4250-af83-26727496f6a0"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("ae04c1fe-cbb6-40a7-aa3f-ea71c7fecd27"));
            labelTermName = (ITTLabel)AddControl(new Guid("447ac0d3-ad9c-48d2-ad77-33051a0c9a45"));
            base.InitializeControls();
        }

        public MedicalResarchTermDefFrom() : base("MEDICALRESARCHTERMDEF", "MedicalResarchTermDefFrom")
        {
        }

        protected MedicalResarchTermDefFrom(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}