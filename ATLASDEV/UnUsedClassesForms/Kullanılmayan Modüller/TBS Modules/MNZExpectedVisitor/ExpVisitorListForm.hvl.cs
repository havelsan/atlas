
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
    /// Beklenen Ziyaretçi Listesi
    /// </summary>
    public partial class ExpVisitorListForm : TTForm
    {
    /// <summary>
    /// Beklenen Ziyaretçi
    /// </summary>
        protected TTObjectClasses.MNZExpectedVisitor _MNZExpectedVisitor
        {
            get { return (TTObjectClasses.MNZExpectedVisitor)_ttObject; }
        }

        protected ITTLabel labelVisitTime;
        protected ITTLabel labelExitTime;
        protected ITTDateTimePicker VisitDate;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelVisitDate;
        protected ITTLabel labelVisitReason;
        protected ITTLabel labelLisencePlate;
        protected ITTTextBox Surname;
        protected ITTTextBox LisencePlate;
        protected ITTLabel labelSurname;
        protected ITTLabel labelBirthDate;
        protected ITTObjectListBox VisitReason;
        protected ITTTextBox Name;
        protected ITTLabel labelEntranceTime;
        protected ITTDateTimePicker EntranceTime;
        protected ITTGrid ttgrid1;
        protected ITTDateTimePicker ExitTime;
        protected ITTDateTimePicker VisitTime;
        protected ITTCheckBox IsConfirmed;
        protected ITTLabel labelNationalIdentity;
        protected ITTTextBox NationalIdentity;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelVisitTime = (ITTLabel)AddControl(new Guid("50e3ebaf-ec6f-4351-b314-04ecc925e562"));
            labelExitTime = (ITTLabel)AddControl(new Guid("7d5ae564-f927-43ba-950c-aaa30e733866"));
            VisitDate = (ITTDateTimePicker)AddControl(new Guid("243195d9-25ee-4915-8fe0-bb3e6ea40f41"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("f41798b5-fad2-4a15-8dc7-7d0efb90b056"));
            labelVisitDate = (ITTLabel)AddControl(new Guid("9bf955e1-4986-4c4b-9180-9735d2313873"));
            labelVisitReason = (ITTLabel)AddControl(new Guid("e2462d0f-8b17-4714-91b4-8c7a3a3d767d"));
            labelLisencePlate = (ITTLabel)AddControl(new Guid("db134680-afd3-42bc-86ad-7fdb018ce06b"));
            Surname = (ITTTextBox)AddControl(new Guid("82037f92-0400-4fec-a949-6b681ccdbff8"));
            LisencePlate = (ITTTextBox)AddControl(new Guid("3a5531c9-ac92-4064-9e82-4913a5ccc9b7"));
            labelSurname = (ITTLabel)AddControl(new Guid("6fc6f248-4b2e-4428-ae91-5c6dfbaa7187"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("208bd2e8-3274-4b57-bb81-3d635559d63f"));
            VisitReason = (ITTObjectListBox)AddControl(new Guid("8ab7c053-3e40-4160-af8d-402c6dd8dc6f"));
            Name = (ITTTextBox)AddControl(new Guid("b6ddf0b3-01e1-473e-9e99-39197b9ac85a"));
            labelEntranceTime = (ITTLabel)AddControl(new Guid("c230eac7-cfdd-45dc-a853-48ced74571f1"));
            EntranceTime = (ITTDateTimePicker)AddControl(new Guid("b93bda70-3539-44fd-8f3f-2e288d4f6feb"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("adb75806-9fdf-404f-a088-216b051cb70e"));
            ExitTime = (ITTDateTimePicker)AddControl(new Guid("ac9d725f-014d-405d-b00f-2bba3877a289"));
            VisitTime = (ITTDateTimePicker)AddControl(new Guid("6fa8722e-178d-40a3-8911-151474f51fff"));
            IsConfirmed = (ITTCheckBox)AddControl(new Guid("af406b70-38bc-405e-89bc-154d9a1ac11c"));
            labelNationalIdentity = (ITTLabel)AddControl(new Guid("f251be0d-e665-4579-985f-19d8c04a21c0"));
            NationalIdentity = (ITTTextBox)AddControl(new Guid("cd4bed02-f251-4985-82a1-eb8573082036"));
            labelName = (ITTLabel)AddControl(new Guid("2970a588-4bc6-4de3-87fb-cfd30a218838"));
            base.InitializeControls();
        }

        public ExpVisitorListForm() : base("MNZEXPECTEDVISITOR", "ExpVisitorListForm")
        {
        }

        protected ExpVisitorListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}