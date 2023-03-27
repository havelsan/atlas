
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
    /// Hasta Yatış Oku
    /// </summary>
    public partial class HastaYatisOkuForm : BaseHastaYatisOkuForm
    {
    /// <summary>
    /// Hasta Yatış Oku
    /// </summary>
        protected TTObjectClasses.HastaYatisOku _HastaYatisOku
        {
            get { return (TTObjectClasses.HastaYatisOku)_ttObject; }
        }

        public HastaYatisOkuForm() : base("HASTAYATISOKU", "HastaYatisOkuForm")
        {
        }

        protected HastaYatisOkuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}