
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
    /// yeni Beklenen Ziyaretçi
    /// </summary>
    public partial class NewExpectedVisitor : TTForm
    {
    /// <summary>
    /// Beklenen Ziyaretçi
    /// </summary>
        protected TTObjectClasses.MNZExpectedVisitor _MNZExpectedVisitor
        {
            get { return (TTObjectClasses.MNZExpectedVisitor)_ttObject; }
        }

        protected ITTLabel labelBirthDate;
        protected ITTGroupBox ttgroupbox1;
        protected ITTDateTimePicker VisitDate;
        protected ITTLabel labelEntranceTime;
        protected ITTTextBox Name;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelVisitReason;
        protected ITTLabel labelName;
        protected ITTTextBox MotherName;
        protected ITTLabel labelLisencePlate;
        protected ITTLabel labelSurname;
        protected ITTLabel labelVisitTime;
        protected ITTTextBox HomePhone;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelCellPhone;
        protected ITTObjectListBox VisitReason;
        protected ITTTextBox LisencePlate;
        protected ITTDateTimePicker VisitTime;
        protected ITTLabel labelExitTime;
        protected ITTDateTimePicker EntranceTime;
        protected ITTObjectListBox objectListDefBoxPersonnel;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelMotherName;
        protected ITTDateTimePicker ExitTime;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox CellPhone;
        protected ITTLabel labelVisitDate;
        protected ITTTextBox FatherName;
        protected ITTTextBox Surname;
        protected ITTLabel labelDescription;
        protected ITTLabel labelHomePhone;
        override protected void InitializeControls()
        {
            labelBirthDate = (ITTLabel)AddControl(new Guid("2e73a82a-315c-456b-ae43-0130923038a3"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("9deca33e-1716-4313-a3c1-efb3d4d7d9e8"));
            VisitDate = (ITTDateTimePicker)AddControl(new Guid("b37f85ec-7d01-4ce1-a1c4-f9c4f8278314"));
            labelEntranceTime = (ITTLabel)AddControl(new Guid("c5b11112-1abf-4aaf-865f-dfbad6a70a02"));
            Name = (ITTTextBox)AddControl(new Guid("b6c1652d-f2fb-441c-b314-fd62482f7f6f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("78dbc380-cc7d-49aa-850d-bc3a0ce17423"));
            labelVisitReason = (ITTLabel)AddControl(new Guid("ab20f3fb-a956-451d-8c01-bcfc72dd9002"));
            labelName = (ITTLabel)AddControl(new Guid("3c312129-9e27-437b-a1ff-ea52562cf5f5"));
            MotherName = (ITTTextBox)AddControl(new Guid("446d5aed-200f-42bc-adbd-ec2a91d1093d"));
            labelLisencePlate = (ITTLabel)AddControl(new Guid("aff6d1bb-c5ae-4798-8ecd-bc78f9ad78a4"));
            labelSurname = (ITTLabel)AddControl(new Guid("f905cd58-41ff-47bc-918b-c76b876d88d6"));
            labelVisitTime = (ITTLabel)AddControl(new Guid("ed579ad2-31a9-4686-b2fe-b27f29910bd9"));
            HomePhone = (ITTTextBox)AddControl(new Guid("1f86eced-1272-4d19-b3a7-9546d1ca690c"));
            labelFatherName = (ITTLabel)AddControl(new Guid("a9a21302-01d1-4d09-a4b2-931fa048911b"));
            labelCellPhone = (ITTLabel)AddControl(new Guid("5d82a5ef-0deb-4e75-8975-7b3b3fddcd3e"));
            VisitReason = (ITTObjectListBox)AddControl(new Guid("0101b39e-682a-4a88-9942-ef2143e5c1c4"));
            LisencePlate = (ITTTextBox)AddControl(new Guid("00b03a8f-01cd-49fe-8ddd-7bcd9167ed25"));
            VisitTime = (ITTDateTimePicker)AddControl(new Guid("c8e75a47-2dd2-4593-b3b9-a2a1c397880b"));
            labelExitTime = (ITTLabel)AddControl(new Guid("4f148048-1be6-4f34-aed2-6a111649d73c"));
            EntranceTime = (ITTDateTimePicker)AddControl(new Guid("1418f964-6664-4a18-808d-a9b295604c92"));
            objectListDefBoxPersonnel = (ITTObjectListBox)AddControl(new Guid("30d3d661-c8c2-41bd-a6ae-6d2843c59570"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("c2269ad1-2de1-4811-8858-547ba132683e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("50b00b1f-b2f2-4fb6-9937-86c2b905d401"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("56c2ea66-9890-44c4-a9c7-45bc8395973f"));
            labelMotherName = (ITTLabel)AddControl(new Guid("fdb32b3d-a2e0-41b5-898d-28145c89ebcc"));
            ExitTime = (ITTDateTimePicker)AddControl(new Guid("1ff2592a-bbc4-4398-86cf-3bd334d9c2b9"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("3ffa887c-e1f0-4f0b-add6-0e678c9efd7f"));
            CellPhone = (ITTTextBox)AddControl(new Guid("ce697002-d23e-4d59-83dd-16496323d9e5"));
            labelVisitDate = (ITTLabel)AddControl(new Guid("b2792fb4-58df-471e-8b97-06b66effaceb"));
            FatherName = (ITTTextBox)AddControl(new Guid("9af18451-0f42-4114-acd7-071ebb98ad92"));
            Surname = (ITTTextBox)AddControl(new Guid("aada1ac5-539f-45fa-a5c0-072588381f59"));
            labelDescription = (ITTLabel)AddControl(new Guid("7302d194-f0b7-48a8-85d5-8d871c733f87"));
            labelHomePhone = (ITTLabel)AddControl(new Guid("e48b1ff0-5270-426e-9f6a-e11e568d04ef"));
            base.InitializeControls();
        }

        public NewExpectedVisitor() : base("MNZEXPECTEDVISITOR", "NewExpectedVisitor")
        {
        }

        protected NewExpectedVisitor(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}