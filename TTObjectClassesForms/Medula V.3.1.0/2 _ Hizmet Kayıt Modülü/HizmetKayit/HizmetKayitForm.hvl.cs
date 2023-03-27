
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
    /// Hizmet Kayıt
    /// </summary>
    public partial class HizmetKayitForm : BaseHizmetKayitForm
    {
    /// <summary>
    /// Hizmet Kayıt
    /// </summary>
        protected TTObjectClasses.HizmetKayit _HizmetKayit
        {
            get { return (TTObjectClasses.HizmetKayit)_ttObject; }
        }

        public HizmetKayitForm() : base("HIZMETKAYIT", "HizmetKayitForm")
        {
        }

        protected HizmetKayitForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}