
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
    /// New Form
    /// </summary>
    public partial class BaseCMRActionForm : ActionForm
    {
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseCMRActionForm_PostScript
    base.PostScript(transDef);
#endregion BaseCMRActionForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseCMRActionForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef !=null)
            {
                if(_CMRAction is Calibration)
                {
                    if (transDef.ToStateDefID  == Calibration.States.Cancelled)
                    {
                        string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "İşlem İptali!", "Kalibrasyon işlemini iptal etmek üzeresiniz!\r\nDevam Etmek İstiyor Musunuz?");
                        if (result == "V")
                            throw new Exception("İptal işleminden vazgeçildi.");
                    }
                }
                
                if(_CMRAction is Repair)
                {
                    if (transDef.ToStateDefID  == Repair.States.Cancelled)
                    {
                        string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "İşlem İptali!", "Onarım işlemini iptal etmek üzeresiniz!\r\nDevam Etmek İstiyor Musunuz?");
                        if (result == "V")
                            throw new Exception("İptal işleminden vazgeçildi.");
                    }
                }
                if(_CMRAction is Maintenance)
                {
                    if (transDef.ToStateDefID  == Maintenance.States.Cancelled)
                    {
                        string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "İşlem İptali!", "Bakım işlemini iptal etmek üzeresiniz!\r\nDevam Etmek İstiyor Musunuz?");
                        if (result == "V")
                            throw new Exception("İptal işleminden vazgeçildi.");
                    }
                }
            }
#endregion BaseCMRActionForm_ClientSidePostScript

        }
    }
}