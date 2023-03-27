
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
    /// Ana Depo Dağıtım Yeni
    /// </summary>
    public partial class MainStoreDistDocNewForm : BaseMainStoreDistributionDocForm
    {
    /// <summary>
    /// Ana Depo Dağıtım Belgesi
    /// </summary>
        protected TTObjectClasses.MainStoreDistributionDoc _MainStoreDistributionDoc
        {
            get { return (TTObjectClasses.MainStoreDistributionDoc)_ttObject; }
        }

        public MainStoreDistDocNewForm() : base("MAINSTOREDISTRIBUTIONDOC", "MainStoreDistDocNewForm")
        {
        }

        protected MainStoreDistDocNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}