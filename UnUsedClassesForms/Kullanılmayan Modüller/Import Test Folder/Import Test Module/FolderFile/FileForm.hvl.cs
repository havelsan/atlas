
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
    public partial class FileForm : TTForm
    {
        protected TTObjectClasses.FolderFile _FolderFile
        {
            get { return (TTObjectClasses.FolderFile)_ttObject; }
        }

        protected ITTTextBox txtGuidProp;
        protected ITTLabel ttlabel1;
        protected ITTButton ttbutton1;
        protected ITTLabel labelParentFile;
        protected ITTObjectListBox ParentFile;
        protected ITTLabel labelFolder;
        protected ITTObjectListBox Folder;
        protected ITTLabel labelSize;
        protected ITTTextBox Size;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelFiyat;
        protected ITTTextBox Fiyat;
        protected ITTLabel labelBigFiyat;
        protected ITTTextBox BigFiyat;
        override protected void InitializeControls()
        {
            txtGuidProp = (ITTTextBox)AddControl(new Guid("6b921bc0-e2e9-4eeb-b77f-0549cf044727"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d13f8b62-15f4-4e21-b3f5-4e38ea5d1d7b"));
            ttbutton1 = (ITTButton)AddControl(new Guid("db59c0d2-5eb4-495b-879f-0db08e8c5f0e"));
            labelParentFile = (ITTLabel)AddControl(new Guid("83d4322a-759c-4974-8b46-66301a48f47b"));
            ParentFile = (ITTObjectListBox)AddControl(new Guid("dd4acf29-098f-4a54-bd05-e554e212010f"));
            labelFolder = (ITTLabel)AddControl(new Guid("9e5edcf7-4401-4108-a5df-94bbf548f661"));
            Folder = (ITTObjectListBox)AddControl(new Guid("fe031b4d-c77f-46dc-b531-9463e39704a1"));
            labelSize = (ITTLabel)AddControl(new Guid("44f1d052-1029-49dc-b846-dc20230f11fe"));
            Size = (ITTTextBox)AddControl(new Guid("4bb1ad93-d800-43d7-9e3b-2557c1f1cb05"));
            labelName = (ITTLabel)AddControl(new Guid("e03bacb3-5e08-488d-a922-dc4645256732"));
            Name = (ITTTextBox)AddControl(new Guid("68be6fa0-eb3e-4d72-8b49-8e50ec585164"));
            labelFiyat = (ITTLabel)AddControl(new Guid("6d881618-700c-440f-9d66-293262b6f353"));
            Fiyat = (ITTTextBox)AddControl(new Guid("9f5d3f03-ee49-46be-9c12-1b2781c7f394"));
            labelBigFiyat = (ITTLabel)AddControl(new Guid("4bec757e-4be5-48d7-9ab7-046667b22113"));
            BigFiyat = (ITTTextBox)AddControl(new Guid("fbd50044-4a8d-4b6e-9202-84e2cf30ed77"));
            base.InitializeControls();
        }

        public FileForm() : base("FOLDERFILE", "FileForm")
        {
        }

        protected FileForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}