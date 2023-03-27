
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
    /// Depoya Göre Sayım Emri Belgesi
    /// </summary>
    public partial class CensusOrderByStoreNewForm : BaseCensusOrderByStoreForm
    {
    /// <summary>
    /// Sayım işlemi depo seçilerek
    /// </summary>
        protected TTObjectClasses.CensusOrderByStore _CensusOrderByStore
        {
            get { return (TTObjectClasses.CensusOrderByStore)_ttObject; }
        }

        public CensusOrderByStoreNewForm() : base("CENSUSORDERBYSTORE", "CensusOrderByStoreNewForm")
        {
        }

        protected CensusOrderByStoreNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}