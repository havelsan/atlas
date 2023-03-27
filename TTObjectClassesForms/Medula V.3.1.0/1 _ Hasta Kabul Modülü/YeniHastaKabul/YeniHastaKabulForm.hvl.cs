
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
    /// Yeni Hasta Kabul
    /// </summary>
    public partial class YeniHastaKabulForm : BaseHastaKabulForm
    {
    /// <summary>
    /// Yeni Hasta Kabul
    /// </summary>
        protected TTObjectClasses.YeniHastaKabul _YeniHastaKabul
        {
            get { return (TTObjectClasses.YeniHastaKabul)_ttObject; }
        }

        public YeniHastaKabulForm() : base("YENIHASTAKABUL", "YeniHastaKabulForm")
        {
        }

        protected YeniHastaKabulForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}