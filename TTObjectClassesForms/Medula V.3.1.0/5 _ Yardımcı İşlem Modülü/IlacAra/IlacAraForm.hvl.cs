
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
    /// İlaç Ara
    /// </summary>
    public partial class IlacAraForm : BaseIlacAraForm
    {
    /// <summary>
    /// İlaç Ara
    /// </summary>
        protected TTObjectClasses.IlacAra _IlacAra
        {
            get { return (TTObjectClasses.IlacAra)_ttObject; }
        }

        public IlacAraForm() : base("ILACARA", "IlacAraForm")
        {
        }

        protected IlacAraForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}