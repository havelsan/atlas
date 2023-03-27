
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
    /// Defter-i Kebir
    /// </summary>
    public partial class LedgerPropertiesForm : TTForm
    {
    /// <summary>
    /// Muhasebe Defterleri
    /// </summary>
        protected TTObjectClasses.MhSAccountingBooks _MhSAccountingBooks
        {
            get { return (TTObjectClasses.MhSAccountingBooks)_ttObject; }
        }

        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker FinishDate;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel labelAccountDepth;
        protected ITTLabel labelFinishDate;
        protected ITTCheckBox ttcheckbox1;
        protected ITTTextBox AccountDepth;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTCheckBox ttcheckbox3;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ttcheckbox2;
        protected ITTTextBox tttextbox2;
        protected ITTDateTimePicker StartDate;
        protected ITTCheckBox ttcheckbox5;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTGroupBox ttgroupbox1;
        override protected void InitializeControls()
        {
            labelStartDate = (ITTLabel)AddControl(new Guid("4d0b5da3-1065-4a02-97bb-0232ca902809"));
            FinishDate = (ITTDateTimePicker)AddControl(new Guid("325ecdb8-9bed-45c5-896f-fb4c15b79653"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("a9fe101b-47cb-4788-99ff-c41be6952334"));
            labelAccountDepth = (ITTLabel)AddControl(new Guid("d721d5b6-00b5-40cc-8ce5-b74a530b2a77"));
            labelFinishDate = (ITTLabel)AddControl(new Guid("6f5e4e0f-d117-424d-b1a8-cc22d5503d1c"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("3dd039ac-4287-4b15-a1c9-b51fd98abf95"));
            AccountDepth = (ITTTextBox)AddControl(new Guid("4cd206a1-448b-48a3-9cc1-c7695416b4a2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6a7c4fc1-c95c-4443-85ef-9c862abb3f56"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("5c336f7f-5146-4108-af1a-ed9a3755977d"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("854fc507-f3a2-4425-b370-7a494d781c8e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("79326dbb-91cd-4cb5-bf58-83767f9a44d9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5d425e41-c66a-4c34-9e9e-6da6c7fbee76"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("cec9e8a9-493b-4363-b3a0-3e93b0fedc65"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("ae54b415-5c8a-4146-9f1a-14985c15c412"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("513f1f88-a90a-4884-9955-26c716f8c2f2"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("3abd0e06-571c-4d26-a624-1302a21ffffc"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("39219c00-804a-42f8-9a1c-075925510c5d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("36f92daf-9263-44c1-95c6-984a0d8c0bd3"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("95880d33-a4ea-44d2-b157-f57f06d17f5b"));
            base.InitializeControls();
        }

        public LedgerPropertiesForm() : base("MHSACCOUNTINGBOOKS", "LedgerPropertiesForm")
        {
        }

        protected LedgerPropertiesForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}