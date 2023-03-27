
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
    /// Ziyaretçi Listesi
    /// </summary>
    public partial class VisitorListForm : TTForm
    {
    /// <summary>
    /// Ziyaretçi
    /// </summary>
        protected TTObjectClasses.MNZVisitor _MNZVisitor
        {
            get { return (TTObjectClasses.MNZVisitor)_ttObject; }
        }

        protected ITTLabel labelLisencePlate;
        protected ITTGrid NewGrid;
        protected ITTObjectListBox VisitorType;
        protected ITTTextBox LisencePlate;
        protected ITTObjectListBox VisitReason;
        protected ITTTextBox Surname;
        protected ITTLabel labelBirthDate;
        protected ITTTextBox FatherName;
        protected ITTLabel labelVisitDate;
        protected ITTTextBox MotherName;
        protected ITTTextBox Name;
        protected ITTLabel labelVisitReason;
        protected ITTDateTimePicker VisitTime;
        protected ITTLabel labelVisitTime;
        protected ITTLabel labelMotherName;
        protected ITTDateTimePicker BirthDate;
        protected ITTGrid VisitorListGrid;
        protected ITTLabel labelName;
        protected ITTLabel labelNationalIdentity;
        protected ITTTextBox NationalIdentity;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelVisitorType;
        protected ITTDateTimePicker VisitDate;
        protected ITTLabel labelSurname;
        override protected void InitializeControls()
        {
            labelLisencePlate = (ITTLabel)AddControl(new Guid("8a98a3da-d145-4a4f-97f0-082726267b12"));
            NewGrid = (ITTGrid)AddControl(new Guid("ddfe2736-0222-40e0-b13f-cdfc6405056c"));
            VisitorType = (ITTObjectListBox)AddControl(new Guid("00b75fcd-71cd-4719-8471-da07f4bb6daf"));
            LisencePlate = (ITTTextBox)AddControl(new Guid("652b29ef-4456-413e-954c-9f5ecff8a68a"));
            VisitReason = (ITTObjectListBox)AddControl(new Guid("c11da4c4-da12-45ec-9531-943681ac9843"));
            Surname = (ITTTextBox)AddControl(new Guid("dcc047b8-3cf2-4012-9c3a-69357227bbd9"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("522992c4-d7fd-42f1-b6fd-a190817dd4e0"));
            FatherName = (ITTTextBox)AddControl(new Guid("5064919f-2b30-41e1-b0c7-766eee5a173f"));
            labelVisitDate = (ITTLabel)AddControl(new Guid("544ecf32-314f-4a16-b88c-329fffe2da68"));
            MotherName = (ITTTextBox)AddControl(new Guid("a654557a-7da1-442e-9338-4550069a3a03"));
            Name = (ITTTextBox)AddControl(new Guid("14833101-a311-437f-bd65-50893d9d93c9"));
            labelVisitReason = (ITTLabel)AddControl(new Guid("47a5b168-d15d-4691-9d5f-460ba4751e8c"));
            VisitTime = (ITTDateTimePicker)AddControl(new Guid("49350bdd-c07c-4de8-8420-6f6d8c97af33"));
            labelVisitTime = (ITTLabel)AddControl(new Guid("44640c48-0c09-4519-904b-35106bcd6129"));
            labelMotherName = (ITTLabel)AddControl(new Guid("26eaaaa4-1c01-4f65-8aff-33c758daab98"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("73f5b411-cdc8-4dd4-bf6a-4491dfb330bc"));
            VisitorListGrid = (ITTGrid)AddControl(new Guid("6f2ac5c8-8250-462a-af0a-4e2353f5211f"));
            labelName = (ITTLabel)AddControl(new Guid("9317a8d4-be02-44f7-8160-34530b04c10f"));
            labelNationalIdentity = (ITTLabel)AddControl(new Guid("b01b6e4a-82ae-4c70-ab4c-3a2afbbc2649"));
            NationalIdentity = (ITTTextBox)AddControl(new Guid("1e1bd43a-b0f7-4287-b3bd-51e709ced60c"));
            labelFatherName = (ITTLabel)AddControl(new Guid("c756a9b7-2856-4342-b014-228307cb6c89"));
            labelVisitorType = (ITTLabel)AddControl(new Guid("095ff954-45f1-4d9f-a0af-1a41b6c88399"));
            VisitDate = (ITTDateTimePicker)AddControl(new Guid("eaa60972-4748-4791-bb22-b7386f46fcac"));
            labelSurname = (ITTLabel)AddControl(new Guid("448ed692-0809-406c-a3cf-dc75cac4855a"));
            base.InitializeControls();
        }

        public VisitorListForm() : base("MNZVISITOR", "VisitorListForm")
        {
        }

        protected VisitorListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}