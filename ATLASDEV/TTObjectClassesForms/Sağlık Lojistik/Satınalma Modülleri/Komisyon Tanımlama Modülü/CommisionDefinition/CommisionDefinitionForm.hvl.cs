
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
    /// Komisyon Tanımlama
    /// </summary>
    public partial class CommisionDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Komisyon Tanımlama
    /// </summary>
        protected TTObjectClasses.CommisionDefinition _CommisionDefinition
        {
            get { return (TTObjectClasses.CommisionDefinition)_ttObject; }
        }

        protected ITTGrid CommisionDefinitionMembers;
        protected ITTListBoxColumn ResUserCommisionDefinitionMember;
        protected ITTEnumComboBoxColumn SignUserTypeCommisionDefinitionMember;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelCommisionType;
        protected ITTEnumComboBox CommisionType;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            CommisionDefinitionMembers = (ITTGrid)AddControl(new Guid("2654abc6-121e-41dc-b6f8-a7e200d99627"));
            ResUserCommisionDefinitionMember = (ITTListBoxColumn)AddControl(new Guid("40925c61-aa3f-4790-b1fd-af8e0caea3a4"));
            SignUserTypeCommisionDefinitionMember = (ITTEnumComboBoxColumn)AddControl(new Guid("763fe4a5-bb16-4321-9f06-38e4194ecd0b"));
            labelEndDate = (ITTLabel)AddControl(new Guid("cccbce99-eb2c-4faa-9737-85935294905d"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("54be5e04-f24d-4b89-bfd1-fa674c6d9531"));
            labelStartDate = (ITTLabel)AddControl(new Guid("5add4f38-23c3-4837-b8bb-f93312e45285"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("8e9c8b67-0439-4f8a-870b-2832ad821e60"));
            labelCommisionType = (ITTLabel)AddControl(new Guid("0a0b714f-5355-4cf6-ace2-8543f8b051f6"));
            CommisionType = (ITTEnumComboBox)AddControl(new Guid("2b5e251e-058e-45b9-bbf6-f9d37d0ca36b"));
            IsActive = (ITTCheckBox)AddControl(new Guid("365fda99-9a57-4223-940d-8468c8b98a83"));
            base.InitializeControls();
        }

        public CommisionDefinitionForm() : base("COMMISIONDEFINITION", "CommisionDefinitionForm")
        {
        }

        protected CommisionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}