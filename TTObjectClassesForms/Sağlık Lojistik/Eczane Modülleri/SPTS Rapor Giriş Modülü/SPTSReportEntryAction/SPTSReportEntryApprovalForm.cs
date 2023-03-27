
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
    /// SPTS Onay
    /// </summary>
    public partial class SPTSReportEntryApprovalForm : TTForm
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
#region SPTSReportEntryApprovalForm_PreScript
    base.PreScript();
            if (_SPTSReportEntryAction.SPTSMessageID != null)
            {
                TTMessage message = TTMessageFactory.GetMessage((Guid)_SPTSReportEntryAction.SPTSMessageID);
                if (message.MessageStatus != TTMessageStatusEnum.Waiting)
                {
                    XXXXXXSptsClasses.ProvReturn returnmsg = (XXXXXXSptsClasses.ProvReturn)message.ReturnValue;
                    if (returnmsg.sonuckodu != -1)
                    {
                        TTVisual.InfoBox.Alert("Rapor başarı ile SPTS'ye gönderilmiştir.", MessageIconEnum.InformationMessage);
                        this.DropStateButton(SPTSReportEntryAction.States.Request);
                    }
                    else
                    {
                        this.DropStateButton(SPTSReportEntryAction.States.Completed);
                        TTVisual.InfoBox.Alert(returnmsg.SonucAciklamasi.ToString(), MessageIconEnum.ErrorMessage);
                    }
                }
                else
                {
                    TTVisual.InfoBox.Alert("SPTS'den rapor sonucu henüz dönmedi!", MessageIconEnum.InformationMessage);
                    this.DropStateButton(SPTSReportEntryAction.States.Completed);
                    this.DropStateButton(SPTSReportEntryAction.States.Request);
                }
            }
#endregion SPTSReportEntryApprovalForm_PreScript

            }
                }
}