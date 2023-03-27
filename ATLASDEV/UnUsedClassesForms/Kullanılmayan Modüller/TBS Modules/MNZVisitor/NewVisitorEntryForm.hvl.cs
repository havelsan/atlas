
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
    /// yeni ziyaretçi giriş formu
    /// </summary>
    public partial class NewVisitorEntryForm : TTForm
    {
    /// <summary>
    /// Ziyaretçi
    /// </summary>
        protected TTObjectClasses.MNZVisitor _MNZVisitor
        {
            get { return (TTObjectClasses.MNZVisitor)_ttObject; }
        }

        protected ITTObjectListBox VisitorType;
        protected ITTLabel labelBirthDate;
        protected ITTLabel labelMotherName;
        protected ITTTextBox Name;
        protected ITTTextBox HomePhone;
        protected ITTLabel labelPatient;
        protected ITTDateTimePicker ExitTime;
        protected ITTDateTimePicker VisitTime;
        protected ITTTextBox Surname;
        protected ITTObjectListBox VisitReason;
        protected ITTDateTimePicker VisitDate;
        protected ITTLabel labelVisitorType;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelHomePhone;
        protected ITTLabel labelLisencePlate;
        protected ITTLabel labelVisitTime;
        protected ITTObjectListBox Patient;
        protected ITTLabel labelExitTime;
        protected ITTLabel labelVisitReason;
        protected ITTLabel ttlabel2;
        protected ITTTextBox CellPhone;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelDescription;
        protected ITTTextBox FatherName;
        protected ITTLabel labelCellPhone;
        protected ITTLabel labelSurname;
        protected ITTTextBox NationalIdentity;
        protected ITTTextBox LisencePlate;
        protected ITTLabel labelName;
        protected ITTTextBox MotherName;
        protected ITTLabel labelNationalIdentity;
        protected ITTTextBox Description;
        protected ITTGroupBox ttgroupbox1;
        override protected void InitializeControls()
        {
            VisitorType = (ITTObjectListBox)AddControl(new Guid("fca0e72f-1d66-4799-a84f-009518f6a3df"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("53445a39-983b-4c3a-976f-e91954248ea7"));
            labelMotherName = (ITTLabel)AddControl(new Guid("45d90621-6393-4464-9e92-cc8041321e29"));
            Name = (ITTTextBox)AddControl(new Guid("b0dea8ee-0564-44ff-8426-ae9802925c5b"));
            HomePhone = (ITTTextBox)AddControl(new Guid("1fe463e4-1138-4086-a3fd-d2c0933139f1"));
            labelPatient = (ITTLabel)AddControl(new Guid("d5c65479-41de-40fe-9964-c6224f4803e1"));
            ExitTime = (ITTDateTimePicker)AddControl(new Guid("18b7526a-5e2f-4a2b-9e42-99452f468d43"));
            VisitTime = (ITTDateTimePicker)AddControl(new Guid("52a7c55e-cf26-4486-8e33-9ee0dd6ada98"));
            Surname = (ITTTextBox)AddControl(new Guid("b5d18c67-15e2-4463-9f31-a112f12196c7"));
            VisitReason = (ITTObjectListBox)AddControl(new Guid("3a03041e-08b8-4fe5-8935-7a9b0ebe26f1"));
            VisitDate = (ITTDateTimePicker)AddControl(new Guid("b9d87391-2d52-4d8a-9b13-a18cfaab870d"));
            labelVisitorType = (ITTLabel)AddControl(new Guid("c4399b06-2d7b-422f-8a95-9cb5d41b50e6"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("d83c7b3e-60af-4b61-a3a6-81740dd6f502"));
            labelHomePhone = (ITTLabel)AddControl(new Guid("ac423e07-eb26-43f8-8337-90bade757ad4"));
            labelLisencePlate = (ITTLabel)AddControl(new Guid("93d17870-5aa7-4da4-85e3-475c67f99fe4"));
            labelVisitTime = (ITTLabel)AddControl(new Guid("d3ed68ae-c3c3-4030-a054-f43941d641be"));
            Patient = (ITTObjectListBox)AddControl(new Guid("86e7fca3-1ca9-44db-ad7c-70d55cbad57e"));
            labelExitTime = (ITTLabel)AddControl(new Guid("87ead784-a67d-418e-b825-470a2957f5fd"));
            labelVisitReason = (ITTLabel)AddControl(new Guid("26551955-51e4-4ac0-afe0-45f7d61d1bb4"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("270e4edd-31c5-422f-af84-6875e0de3d40"));
            CellPhone = (ITTTextBox)AddControl(new Guid("88757181-a3aa-4d98-b254-599a0ddf5962"));
            labelFatherName = (ITTLabel)AddControl(new Guid("5a69dc4e-8f7b-48b1-9299-66c001407dec"));
            labelDescription = (ITTLabel)AddControl(new Guid("b820ff9a-3630-40cc-bb56-338b8232b446"));
            FatherName = (ITTTextBox)AddControl(new Guid("b53fb13a-0f4e-4aa9-92c5-335e165fba40"));
            labelCellPhone = (ITTLabel)AddControl(new Guid("57c740da-fa18-459f-a65b-27dcfbb5f60b"));
            labelSurname = (ITTLabel)AddControl(new Guid("5d5cef58-bad9-4518-996e-52933531ec26"));
            NationalIdentity = (ITTTextBox)AddControl(new Guid("9b1034c6-5864-41ce-9b25-2cfbc6f29442"));
            LisencePlate = (ITTTextBox)AddControl(new Guid("4ed569cd-0311-4473-ba43-1d2440f34292"));
            labelName = (ITTLabel)AddControl(new Guid("25e4a4a9-1d7d-419d-87a5-31717bd08c46"));
            MotherName = (ITTTextBox)AddControl(new Guid("26d3cec3-f7a1-4c74-9cab-007de4187e9f"));
            labelNationalIdentity = (ITTLabel)AddControl(new Guid("d8823b71-9004-4528-a80f-0230fcb12499"));
            Description = (ITTTextBox)AddControl(new Guid("5f7165cd-b8a1-48a6-9872-4b71180698fe"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("4cc6dda5-d329-4e00-86ab-f691f9c624f0"));
            base.InitializeControls();
        }

        public NewVisitorEntryForm() : base("MNZVISITOR", "NewVisitorEntryForm")
        {
        }

        protected NewVisitorEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}