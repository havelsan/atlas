
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
    /// Gövde Yapısı Tanımı
    /// </summary>
    public partial class FixedAssetDetailBodyDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.FixedAssetDetailBodyDef _FixedAssetDetailBodyDef
        {
            get { return (TTObjectClasses.FixedAssetDetailBodyDef)_ttObject; }
        }

        protected ITTLabel labelFixedAssetDetailMainClass;
        protected ITTObjectListBox FixedAssetDetailMainClass;
        protected ITTLabel labelBodyName;
        protected ITTTextBox BodyName;
        override protected void InitializeControls()
        {
            labelFixedAssetDetailMainClass = (ITTLabel)AddControl(new Guid("a13712fb-66b1-4be0-ab7c-2c7c9ccf2b68"));
            FixedAssetDetailMainClass = (ITTObjectListBox)AddControl(new Guid("3bc9c418-e77c-4732-b482-bacc872119ff"));
            labelBodyName = (ITTLabel)AddControl(new Guid("8dd72ec9-8c8b-405d-9e71-e25f880acfb7"));
            BodyName = (ITTTextBox)AddControl(new Guid("9b0d5e3b-c5ba-4670-a04e-177d1306983d"));
            base.InitializeControls();
        }

        public FixedAssetDetailBodyDefForm() : base("FIXEDASSETDETAILBODYDEF", "FixedAssetDetailBodyDefForm")
        {
        }

        protected FixedAssetDetailBodyDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}