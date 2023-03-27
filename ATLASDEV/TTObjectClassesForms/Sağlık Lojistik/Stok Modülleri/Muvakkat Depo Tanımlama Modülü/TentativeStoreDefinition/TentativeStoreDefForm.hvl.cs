
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
    /// Muvakkat Depo Tanımlama
    /// </summary>
    public partial class TentativeStoreDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Muvakkat Depo
    /// </summary>
        protected TTObjectClasses.TentativeStoreDefinition _TentativeStoreDefinition
        {
            get { return (TTObjectClasses.TentativeStoreDefinition)_ttObject; }
        }

        protected ITTTextBox Description;
        protected ITTEnumComboBox Status;
        protected ITTLabel labelStatus;
        protected ITTLabel labelQREF;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTLabel labelDescription;
        protected ITTTextBox QREF;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            Description = (ITTTextBox)AddControl(new Guid("e96d8424-1ba2-4a74-baa2-8f17a9169b4c"));
            Status = (ITTEnumComboBox)AddControl(new Guid("da4ef9ee-c441-4cf1-a9cc-9cf89174f426"));
            labelStatus = (ITTLabel)AddControl(new Guid("f619825f-3bf5-4ae9-9b24-2712e58da27e"));
            labelQREF = (ITTLabel)AddControl(new Guid("45a42c4c-7d5d-4142-9f8f-3c5227356a6d"));
            Name = (ITTTextBox)AddControl(new Guid("f1910abe-0f88-46f6-86a9-989997fcf09b"));
            labelName = (ITTLabel)AddControl(new Guid("64bb75e2-1aeb-4ee1-812f-793c8502c125"));
            labelDescription = (ITTLabel)AddControl(new Guid("bd7e247c-25fb-4667-b1c2-490873fb1d12"));
            QREF = (ITTTextBox)AddControl(new Guid("c6337fe4-4ff0-4be6-aa87-a8df9bbf13dd"));
            IsActive = (ITTCheckBox)AddControl(new Guid("e0518c31-c2e4-4a38-97ca-7437eb3c8f58"));
            base.InitializeControls();
        }

        public TentativeStoreDefForm() : base("TENTATIVESTOREDEFINITION", "TentativeStoreDefForm")
        {
        }

        protected TentativeStoreDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}