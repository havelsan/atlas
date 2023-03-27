
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
    /// Hasta Geçmişi Fizyoterapi İstek
    /// </summary>
    public partial class OldPhysiotherapyRequestForm : TTForm
    {
    /// <summary>
    /// F.T.R. İstek İşlemlerinin Gerçekleştirildiği  Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyRequest _PhysiotherapyRequest
        {
            get { return (TTObjectClasses.PhysiotherapyRequest)_ttObject; }
        }

        public OldPhysiotherapyRequestForm() : base("PHYSIOTHERAPYREQUEST", "OldPhysiotherapyRequestForm")
        {
        }

        protected OldPhysiotherapyRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}