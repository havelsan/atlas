
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
    /// Kaynak Tipi Tanımı
    /// </summary>
    public partial class ResourceTypeTreeForm : TTForm
    {
    /// <summary>
    /// Kaynak Tip Ağacı
    /// </summary>
        protected TTObjectClasses.ResourceTypeTree _ResourceTypeTree
        {
            get { return (TTObjectClasses.ResourceTypeTree)_ttObject; }
        }

        protected ITTTextBox RelationDefID;
        protected ITTComboBox ParentObjectDefName;
        protected ITTComboBox RelationDefComboBox;
        override protected void InitializeControls()
        {
            RelationDefID = (ITTTextBox)AddControl(new Guid("521dc495-be7b-4182-b167-7b05f072d88e"));
            ParentObjectDefName = (ITTComboBox)AddControl(new Guid("f95bff5d-faa4-4335-8cec-2d45ad809faf"));
            RelationDefComboBox = (ITTComboBox)AddControl(new Guid("af7301a7-adfe-4292-a21d-dab850287833"));
            base.InitializeControls();
        }

        public ResourceTypeTreeForm() : base("RESOURCETYPETREE", "ResourceTypeTreeForm")
        {
        }

        protected ResourceTypeTreeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}