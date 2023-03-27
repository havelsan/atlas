
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
    /// Patoloji Kavanoz Tipi Tanımlama
    /// </summary>
    public partial class PathologyJarTypeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Patoloji Kavanoz Tipi Tanımları
    /// </summary>
        protected TTObjectClasses.PathologyJarTypeDef _PathologyJarTypeDef
        {
            get { return (TTObjectClasses.PathologyJarTypeDef)_ttObject; }
        }

        protected ITTLabel labelJarType;
        protected ITTTextBox JarType;
        override protected void InitializeControls()
        {
            labelJarType = (ITTLabel)AddControl(new Guid("4b546da1-7197-49f9-87b2-1ccc039a6ee6"));
            JarType = (ITTTextBox)AddControl(new Guid("a508f328-623f-4fe9-a6e0-7218d3e14b4b"));
            base.InitializeControls();
        }

        public PathologyJarTypeForm() : base("PATHOLOGYJARTYPEDEF", "PathologyJarTypeForm")
        {
        }

        protected PathologyJarTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}