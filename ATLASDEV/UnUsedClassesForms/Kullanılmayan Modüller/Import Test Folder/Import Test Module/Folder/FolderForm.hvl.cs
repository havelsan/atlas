
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
    /// New Form
    /// </summary>
    public partial class FolderForm : TTForm
    {
        protected TTObjectClasses.Folder _Folder
        {
            get { return (TTObjectClasses.Folder)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage tttabpage2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTTabPage tttabpage3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTTabPage tttabpage4;
        protected ITTRichTextBoxControl ttrichtextboxcontrol4;
        protected ITTTabPage tttabpage5;
        protected ITTPictureBoxControl ttpictureboxcontrol1;
        protected ITTTextBox TestID;
        protected ITTTextBox Size;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTButton ttbutton2;
        protected ITTObjectListBox TTListBox2;
        protected ITTObjectListBox TTListBox;
        protected ITTButton ttbutton1;
        protected ITTGrid Files;
        protected ITTListBoxColumn ParentFile;
        protected ITTTextBoxColumn Name;
        protected ITTMaskedTextBoxColumn datagridviewcolumn1;
        protected ITTLabel labelParentFolder;
        protected ITTObjectListBox ParentFolder;
        protected ITTLabel labelTestID;
        protected ITTLabel labelSize;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("827e7e03-b1f7-4229-9256-0198d9c35d27"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("85024a91-fd56-46de-ba2d-61a0f11e15df"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("265b4218-097f-42c9-b800-9e43c9d68287"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("2f73ba9f-a3ea-4d7f-ba9d-422486f66a6f"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("f8adf74a-df96-4255-95af-154c4a83674d"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("acaf7da0-be82-4572-bb14-73d92dc7d610"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("c8454620-353e-4203-a762-fcc1d24c2bce"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("6b052b9b-e924-4927-94f0-1a709e0b0ac6"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("36dd8ed2-1787-4290-9c15-fe5e196597ff"));
            ttrichtextboxcontrol4 = (ITTRichTextBoxControl)AddControl(new Guid("3fe2856c-ff86-421a-aead-c3118eb235e3"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("155f35b4-ea85-449a-ba69-beac880dae8c"));
            ttpictureboxcontrol1 = (ITTPictureBoxControl)AddControl(new Guid("ec752d11-da91-434b-abd9-51a7802399e4"));
            TestID = (ITTTextBox)AddControl(new Guid("e01b5009-7196-4cf3-994e-e9487f4c7ebb"));
            Size = (ITTTextBox)AddControl(new Guid("40600b11-6cf5-44ec-b84a-e8da0b8f1dc2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("277edff7-e8ce-4062-8446-d58ebd668c52"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("4b90423a-b361-4513-8098-9d5160ae4d7e"));
            ttbutton2 = (ITTButton)AddControl(new Guid("9b23e89c-db18-4f56-ac53-d2025b74d93f"));
            TTListBox2 = (ITTObjectListBox)AddControl(new Guid("bd3d674a-bd4a-4ab8-bca6-51c81de83220"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("53036eac-1cd1-4894-942c-f9576db94178"));
            ttbutton1 = (ITTButton)AddControl(new Guid("4bd146a0-ceac-4c08-9f1c-97fc6c08a230"));
            Files = (ITTGrid)AddControl(new Guid("2c731089-15f0-4e7d-811a-a75a11a25ede"));
            ParentFile = (ITTListBoxColumn)AddControl(new Guid("c52e2ddb-95eb-443f-8343-724eba0bfc13"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("2211e6b0-2cec-4f98-b9ee-a50d86c6ab5b"));
            datagridviewcolumn1 = (ITTMaskedTextBoxColumn)AddControl(new Guid("ec269df9-54d8-4282-9279-025130b98423"));
            labelParentFolder = (ITTLabel)AddControl(new Guid("4fc596cb-a358-4389-918f-6653b7281824"));
            ParentFolder = (ITTObjectListBox)AddControl(new Guid("ebc5b35c-d556-45ec-b3fd-6b90c4cdcab6"));
            labelTestID = (ITTLabel)AddControl(new Guid("30e2b308-94ad-487a-9b56-0c13df1c5690"));
            labelSize = (ITTLabel)AddControl(new Guid("4772abc4-37c6-4c3d-981c-a13070611e15"));
            labelName = (ITTLabel)AddControl(new Guid("e170c5d2-3234-4937-a70a-119acbb79a3e"));
            base.InitializeControls();
        }

        public FolderForm() : base("FOLDER", "FolderForm")
        {
        }

        protected FolderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}