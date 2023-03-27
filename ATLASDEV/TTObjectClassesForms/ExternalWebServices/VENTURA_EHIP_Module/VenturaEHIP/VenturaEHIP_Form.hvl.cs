
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
    public partial class XXXXXXEHIP : TTForm
    {
    /// <summary>
    /// EHİP WEB SERVİS Entegrasyon Nesnesi
    /// </summary>
        protected TTObjectClasses.XXXXXXEHIP _XXXXXXEHIP
        {
            get { return (TTObjectClasses.XXXXXXEHIP)_ttObject; }
        }

        public XXXXXXEHIP() : base("XXXXXXEHIP", "XXXXXXEHIP")
        {
        }

        protected XXXXXXEHIP(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}