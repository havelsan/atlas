
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
    /// Vezne / Fatura Servisi Bilgisayar Kullanıcı Tanımı
    /// </summary>
    public partial class CashOfficeComputerUserForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region CashOfficeComputerUserForm_PreScript
    base.PreScript();
            if (this._CashOfficeComputerUserDefinition.ComputerName == null)
                this._CashOfficeComputerUserDefinition.ComputerName = Common.GetCurrentUserComputerName();
#endregion CashOfficeComputerUserForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CashOfficeComputerUserForm_PostScript
    base.PostScript(transDef);
//            foreach (CashOfficeComputerUserDefinition cashOfficeUser in CashOfficeComputerUserDefinition.GetAll(this._CashOfficeComputerUserDefinition.ObjectContext))
//            {
//                if(this._CashOfficeComputerUserDefinition.ResUser  == cashOfficeUser.ResUser && this._CashOfficeComputerUserDefinition.ComputerName == cashOfficeUser.ComputerName)
//                {
//                    throw new TTException("Aynı kullanıcı ve bilgisayar adı için tanımlama mevcut!");
//                    break;
//                }
//            }
#endregion CashOfficeComputerUserForm_PostScript

            }
                }
}