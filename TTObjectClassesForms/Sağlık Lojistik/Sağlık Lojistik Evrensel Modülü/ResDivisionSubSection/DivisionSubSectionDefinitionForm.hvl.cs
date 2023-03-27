
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
    /// Alt Kısım Tanımı
    /// </summary>
    public partial class DivisionSubSectionDefinitionForm : TTForm
    {
    /// <summary>
    /// Alt Kısım Tanımı
    /// </summary>
        protected TTObjectClasses.ResDivisionSubSection _ResDivisionSubSection
        {
            get { return (TTObjectClasses.ResDivisionSubSection)_ttObject; }
        }

        protected ITTObjectListBox DivisionSection;
        protected ITTTextBox Name;
        protected ITTTextBox Qref;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox Active;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelDivisionSection;
        protected ITTLabel labelEnabledType;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            DivisionSection = (ITTObjectListBox)AddControl(new Guid("6e7051fe-4707-4ac9-b8f2-cd7c119bd1e0"));
            Name = (ITTTextBox)AddControl(new Guid("eae675c5-e6e8-4a06-ad60-d0cc6820c249"));
            Qref = (ITTTextBox)AddControl(new Guid("58e4261d-28e7-42eb-8f24-fec5f103ae5a"));
            Location = (ITTTextBox)AddControl(new Guid("2d9d55e6-b8cb-4c24-8c95-244b00109be2"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("519921c8-2344-4da2-a91a-33ebefc04e38"));
            labelQref = (ITTLabel)AddControl(new Guid("e007e313-62c3-498a-9f87-4a0e3fc61b4c"));
            labelName = (ITTLabel)AddControl(new Guid("afceb8c8-5cf1-4fe1-aac7-725902abef89"));
            Active = (ITTCheckBox)AddControl(new Guid("e580a419-ff27-40d8-b968-48fa6507b696"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("45ac735d-ba69-4270-b43b-ff719f6c0dd3"));
            labelDivisionSection = (ITTLabel)AddControl(new Guid("fa32a922-3e97-44e1-b3b5-1a35679cf1db"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("15afb504-8d53-4810-911f-b44d89ca7ff3"));
            labelStore = (ITTLabel)AddControl(new Guid("94362bc7-3ef6-499c-b920-462b8ff5e2cd"));
            Store = (ITTObjectListBox)AddControl(new Guid("419323e7-4380-41b8-96e1-d568bd9d6246"));
            labelLocation = (ITTLabel)AddControl(new Guid("ef765d17-df50-406a-adba-10f277a33ac2"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("f7997fc0-ac2d-4ea7-9530-58493995ca17"));
            base.InitializeControls();
        }

        public DivisionSubSectionDefinitionForm() : base("RESDIVISIONSUBSECTION", "DivisionSubSectionDefinitionForm")
        {
        }

        protected DivisionSubSectionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}