
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
    /// Hizmet Talimat/İstek
    /// </summary>
    public partial class ProcedureOrderForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ProcedureOrderForm_PostScript
    base.PostScript(transDef);
#endregion ProcedureOrderForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ProcedureOrderForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
             if(transDef != null && transDef.ToStateDefID == ProcedureOrder.States.Cancelled)
            {
                string result=ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır", "E,H", "Uyarı", "Emin misiniz?","Bu işlem iptal edildiğinde işleme bağlı tüm talimatlar iptal edilecektir.Devam etmek istediğinize emin misiniz?", 1);
                if(result == "H")
                    throw new Exception("İşlem iptalden vazgeçildi.");
            }
#endregion ProcedureOrderForm_ClientSidePostScript

        }
    }
}