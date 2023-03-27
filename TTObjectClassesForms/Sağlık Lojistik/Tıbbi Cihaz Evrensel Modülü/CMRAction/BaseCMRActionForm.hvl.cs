
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
    public partial class BaseCMRActionForm : ActionForm
    {
    /// <summary>
    /// Tıbbi Cihaz İşlemleri Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.CMRAction _CMRAction
        {
            get { return (TTObjectClasses.CMRAction)_ttObject; }
        }

        public BaseCMRActionForm() : base("CMRACTION", "BaseCMRActionForm")
        {
        }

        protected BaseCMRActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}