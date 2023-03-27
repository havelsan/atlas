
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
    /// Bağlı Malzemeyi Ayırma
    /// </summary>
    public partial class JoinedMaterialRemovalForm : BaseJoinMaterialRemovalForm
    {
    /// <summary>
    /// Birleştirilen Malzemeyi Düzeltme
    /// </summary>
        protected TTObjectClasses.JoinMaterialRemoval _JoinMaterialRemoval
        {
            get { return (TTObjectClasses.JoinMaterialRemoval)_ttObject; }
        }

        public JoinedMaterialRemovalForm() : base("JOINMATERIALREMOVAL", "JoinedMaterialRemovalForm")
        {
        }

        protected JoinedMaterialRemovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}