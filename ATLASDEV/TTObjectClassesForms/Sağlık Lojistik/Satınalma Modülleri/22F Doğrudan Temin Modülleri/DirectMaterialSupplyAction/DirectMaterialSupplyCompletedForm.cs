
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Doğrudan Malzeme Tedarik 22F
    /// </summary>
    public partial class DirectMaterialSupplyCompletedForm : BaseDirectMaterialSupplyForm
    {
        override protected void BindControlEvents()
        {
            SendToXXXXXX.Click += new TTControlEventDelegate(SendToXXXXXX_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SendToXXXXXX.Click -= new TTControlEventDelegate(SendToXXXXXX_Click);
            base.UnBindControlEvents();
        }


        private void SendToXXXXXX_Click()
        {
            if (!(bool)this._DirectMaterialSupplyAction.XXXXXXIslemBasarili)
            {
                string messsage = DirectMaterialSupplyAction.Send22F_SupplyRequestToXXXXXX_TS(this._DirectMaterialSupplyAction);
            }
        }
    }
}