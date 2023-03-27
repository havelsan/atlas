
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
    /// Bölüm Tanımı
    /// </summary>
    public partial class DivisionDefinitionForm : TTForm
    {
    /// <summary>
    /// Bölüm Tanımı
    /// </summary>
        protected TTObjectClasses.ResDivision _ResDivision
        {
            get { return (TTObjectClasses.ResDivision)_ttObject; }
        }

        protected ITTObjectListBox HeaderShip;
        protected ITTTextBox Name;
        protected ITTTextBox Qref;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox Active;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelHeaderShip;
        protected ITTLabel labelEnabledType;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            HeaderShip = (ITTObjectListBox)AddControl(new Guid("fb058210-ceb5-42f2-830b-5d569c211ccd"));
            Name = (ITTTextBox)AddControl(new Guid("d44112f1-ec6d-4477-9343-5061c0f09a40"));
            Qref = (ITTTextBox)AddControl(new Guid("556228c6-43cb-42fd-b129-a2350ed58c8b"));
            Location = (ITTTextBox)AddControl(new Guid("8c4af78e-e583-4ad3-bfec-3780259d7736"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("3f299a6f-91c1-46d1-8ec4-53eea8c9cee4"));
            labelQref = (ITTLabel)AddControl(new Guid("a13fe38d-668a-47a2-b008-26d593ac3b86"));
            labelName = (ITTLabel)AddControl(new Guid("b4093b2f-c2ca-4ec4-8372-d74dedbeb19a"));
            Active = (ITTCheckBox)AddControl(new Guid("08b08b68-3af2-4d71-8a00-887ceea467a7"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("78dc03d5-83c4-40da-8325-6e13e914d191"));
            labelHeaderShip = (ITTLabel)AddControl(new Guid("8e336448-17cd-4b27-a490-d472b78c0af0"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("5fa91689-e882-4202-a83a-a59c697bb28f"));
            labelStore = (ITTLabel)AddControl(new Guid("796eab5b-4516-4d53-93ad-096b909c7d23"));
            Store = (ITTObjectListBox)AddControl(new Guid("856eedb5-0397-4c8d-bd25-5d7b6416c3d6"));
            labelLocation = (ITTLabel)AddControl(new Guid("0d3f574f-5364-4562-9aad-e5a406663fca"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("6609e812-8885-4f9a-9d5b-5469a02346db"));
            base.InitializeControls();
        }

        public DivisionDefinitionForm() : base("RESDIVISION", "DivisionDefinitionForm")
        {
        }

        protected DivisionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}