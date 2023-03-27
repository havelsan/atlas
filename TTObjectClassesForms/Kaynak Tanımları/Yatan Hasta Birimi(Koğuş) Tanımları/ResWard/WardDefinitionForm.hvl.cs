
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
    /// Yatan Hasta Birimi Tanımı
    /// </summary>
    public partial class WardDefinitionForm : TTForm
    {
    /// <summary>
    /// Yatan Hasta Birimi(Koğuş)
    /// </summary>
        protected TTObjectClasses.ResWard _ResWard
        {
            get { return (TTObjectClasses.ResWard)_ttObject; }
        }

        protected ITTLabel labelFloor;
        protected ITTTextBox Floor;
        protected ITTTextBox InpatientQuota;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelInpatientQuota;
        protected ITTCheckBox IgnoreQuotaControl;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox Active;
        protected ITTLabel labelStore;
        protected ITTGrid re;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox Store;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox Hospital;
        protected ITTCheckBox IsIntensiveCare;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelFloor = (ITTLabel)AddControl(new Guid("c27620b9-cbdc-43f9-9661-5f0d98b16d9e"));
            Floor = (ITTTextBox)AddControl(new Guid("0fb490af-782d-4e15-a90a-a6e76fc7df44"));
            InpatientQuota = (ITTTextBox)AddControl(new Guid("e5cf641a-bb42-470a-bddd-577d1dd4da5c"));
            Qref = (ITTTextBox)AddControl(new Guid("2ba7f159-c7bc-4eda-8814-376cb210d97a"));
            Name = (ITTTextBox)AddControl(new Guid("ac28bba0-de0b-4520-8d04-fc56b4d4a747"));
            Location = (ITTTextBox)AddControl(new Guid("3d3a2fc3-7d21-420c-8e19-e4959b1120e1"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("3f8e03c1-d340-425b-9e11-ba0938c3af9c"));
            labelInpatientQuota = (ITTLabel)AddControl(new Guid("de61fda6-f11b-4097-92e1-30d81a5df948"));
            IgnoreQuotaControl = (ITTCheckBox)AddControl(new Guid("f27766df-f0bb-4381-9cba-fb3ca538fdfd"));
            labelQref = (ITTLabel)AddControl(new Guid("a4bfed4c-791d-456c-9a95-45a6ba8bb16b"));
            labelName = (ITTLabel)AddControl(new Guid("300f0848-f7b4-46b9-80d6-339d9b1a99da"));
            Active = (ITTCheckBox)AddControl(new Guid("5aedc19b-c593-4559-b451-dcb35f3d1b0b"));
            labelStore = (ITTLabel)AddControl(new Guid("199ebeb3-4ba8-4c36-a28d-d8278814f42b"));
            re = (ITTGrid)AddControl(new Guid("44bd4a4d-fbf1-487e-b369-e20f314b8df3"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("b469901b-2d9c-421f-be6c-ac3b6fb343bf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a5e48def-e5c0-4476-8db7-206920cbfc31"));
            Store = (ITTObjectListBox)AddControl(new Guid("f3eb8050-a983-4989-ac19-6e36be25a6d7"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("500a0e83-f5e2-49bc-8abf-9d3eb2223587"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("922ea30a-3a92-4ab5-8758-afa6c587bc5c"));
            IsIntensiveCare = (ITTCheckBox)AddControl(new Guid("392078b2-5a46-4326-b1f7-5a89248069ef"));
            labelLocation = (ITTLabel)AddControl(new Guid("592e8f02-61ca-41bc-9403-50040cf3314a"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("99108926-8a1e-4c7f-8481-f143b36d42cf"));
            base.InitializeControls();
        }

        public WardDefinitionForm() : base("RESWARD", "WardDefinitionForm")
        {
        }

        protected WardDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}