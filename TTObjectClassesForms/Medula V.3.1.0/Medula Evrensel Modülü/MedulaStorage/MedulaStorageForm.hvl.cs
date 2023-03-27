
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
    /// Medula Depolama Birimi
    /// </summary>
    public partial class MedulaStorageForm : TTForm
    {
    /// <summary>
    /// Medula Depolama Birimi
    /// </summary>
        protected TTObjectClasses.MedulaStorage _MedulaStorage
        {
            get { return (TTObjectClasses.MedulaStorage)_ttObject; }
        }

        protected ITTLabel labelStorageNumber;
        protected ITTTextBox StorageNumber;
        protected ITTTextBox FilePath;
        protected ITTTextBox FileName;
        protected ITTLabel labelFilePath;
        protected ITTLabel labelFileName;
        override protected void InitializeControls()
        {
            labelStorageNumber = (ITTLabel)AddControl(new Guid("dafe76eb-395f-41b6-978f-bcac4d768a1f"));
            StorageNumber = (ITTTextBox)AddControl(new Guid("af0e69a9-af43-4e05-9241-2bfc05aed826"));
            FilePath = (ITTTextBox)AddControl(new Guid("5d94d009-0b87-4cd2-a62c-57c283f254a4"));
            FileName = (ITTTextBox)AddControl(new Guid("098f4482-bd8e-41fa-a78a-3f48af0031a4"));
            labelFilePath = (ITTLabel)AddControl(new Guid("698d1c46-e450-46ea-9f1a-e6efeac401d2"));
            labelFileName = (ITTLabel)AddControl(new Guid("359f662d-2679-4da8-8e72-f249cbe52d0e"));
            base.InitializeControls();
        }

        public MedulaStorageForm() : base("MEDULASTORAGE", "MedulaStorageForm")
        {
        }

        protected MedulaStorageForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}