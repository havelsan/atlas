
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
    /// Sağlık Kurulu Heyet Tanımları
    /// </summary>
    public partial class MemberOfHealthCommitteeDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Sağlık Kurulu Heyet Tanımları
    /// </summary>
        protected TTObjectClasses.MemberOfHealthCommitteeDefinition _MemberOfHealthCommitteeDefinition
        {
            get { return (TTObjectClasses.MemberOfHealthCommitteeDefinition)_ttObject; }
        }

        protected ITTLabel labelCommitteeName;
        protected ITTTextBox CommitteeName;
        protected ITTTextBox TempBox;
        protected ITTTextBox GroupNo;
        protected ITTGrid Members;
        protected ITTTextBoxColumn OrderNo;
        protected ITTListBoxColumn Doctor;
        protected ITTListBoxColumn datagridviewcolumn1;
        protected ITTTextBoxColumn Work;
        protected ITTLabel labelMasterOfHealthCommittee;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelGroupNo;
        protected ITTObjectListBox MasterOfHealthCommittee;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox MasterOfHealthCommittee2;
        override protected void InitializeControls()
        {
            labelCommitteeName = (ITTLabel)AddControl(new Guid("8a9c2315-8878-4938-959c-3cab5b95bb24"));
            CommitteeName = (ITTTextBox)AddControl(new Guid("c3936ee7-d0d3-4924-b82e-a6746d0ebe95"));
            TempBox = (ITTTextBox)AddControl(new Guid("42479703-2b37-48b8-985f-525d920b809c"));
            GroupNo = (ITTTextBox)AddControl(new Guid("4a182f7a-8512-473b-bfbd-c90961afdd1b"));
            Members = (ITTGrid)AddControl(new Guid("39760a8f-520a-40cd-ac88-2c312b680b7e"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("25226b6c-175a-44f5-95b9-ff87089de5bc"));
            Doctor = (ITTListBoxColumn)AddControl(new Guid("b078aa24-8b2c-46c7-8d5a-99407b2d62b1"));
            datagridviewcolumn1 = (ITTListBoxColumn)AddControl(new Guid("230f162c-4fd7-4414-be7c-2a941352f79b"));
            Work = (ITTTextBoxColumn)AddControl(new Guid("0cfd2518-d381-4bd4-b82c-450f57bcad58"));
            labelMasterOfHealthCommittee = (ITTLabel)AddControl(new Guid("b8f6ce20-d5be-42f9-a075-4df48d15ebdc"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c209eafc-b273-4ec5-b262-7726e3f11af7"));
            labelGroupNo = (ITTLabel)AddControl(new Guid("068cdb70-8033-4aa1-9122-b0f5dbd3691b"));
            MasterOfHealthCommittee = (ITTObjectListBox)AddControl(new Guid("a12bb12e-261c-4d5a-9642-ce4f08591773"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("de6a34be-ba0c-445b-9e7e-42698f123780"));
            MasterOfHealthCommittee2 = (ITTObjectListBox)AddControl(new Guid("63e1b523-5690-4633-b640-5f26fa71d1a1"));
            base.InitializeControls();
        }

        public MemberOfHealthCommitteeDefinitionForm() : base("MEMBEROFHEALTHCOMMITTEEDEFINITION", "MemberOfHealthCommitteeDefinitionForm")
        {
        }

        protected MemberOfHealthCommitteeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}