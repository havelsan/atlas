
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
    /// Döküman Tanımlama
    /// </summary>
    public partial class DocumentDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.DocumentDefinition _DocumentDefinition
        {
            get { return (TTObjectClasses.DocumentDefinition)_ttObject; }
        }

        protected ITTLabel labelOrder;
        protected ITTTextBox Order;
        protected ITTTextBox Name;
        protected ITTLabel labelParentDocumentDefinition;
        protected ITTObjectListBox ParentDocumentDefinition;
        protected ITTCheckBox IsMainGroup;
        protected ITTCheckBox IsGroup;
        protected ITTLabel labelName;
        protected ITTButton cmdAddButton;
        protected ITTButton cmdOpenButton;
        override protected void InitializeControls()
        {
            labelOrder = (ITTLabel)AddControl(new Guid("dcda4186-7cf2-48cb-9523-2a3644d541fb"));
            Order = (ITTTextBox)AddControl(new Guid("f655e431-9ede-4870-9ab8-e072e0c0393e"));
            Name = (ITTTextBox)AddControl(new Guid("326bae83-2eb8-402c-9018-e7c78535b03d"));
            labelParentDocumentDefinition = (ITTLabel)AddControl(new Guid("aa03a1dc-efa9-4aa2-a9cd-a43eaf225639"));
            ParentDocumentDefinition = (ITTObjectListBox)AddControl(new Guid("6106f6b7-72ff-4fce-a938-87bf4efe8e23"));
            IsMainGroup = (ITTCheckBox)AddControl(new Guid("453c8fc0-0e82-4ca5-8026-cc8f5a038a2f"));
            IsGroup = (ITTCheckBox)AddControl(new Guid("52b95947-bb4c-4e9e-b45c-3e68bfdc2d9b"));
            labelName = (ITTLabel)AddControl(new Guid("f9c5c9dc-0458-47f1-a012-f933682d7d11"));
            cmdAddButton = (ITTButton)AddControl(new Guid("65342638-f6b6-4437-972b-594a98f39dbd"));
            cmdOpenButton = (ITTButton)AddControl(new Guid("70361d4a-19bc-42d2-885e-1285ab277cdd"));
            base.InitializeControls();
        }

        public DocumentDefinitionForm() : base("DOCUMENTDEFINITION", "DocumentDefinitionForm")
        {
        }

        protected DocumentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}