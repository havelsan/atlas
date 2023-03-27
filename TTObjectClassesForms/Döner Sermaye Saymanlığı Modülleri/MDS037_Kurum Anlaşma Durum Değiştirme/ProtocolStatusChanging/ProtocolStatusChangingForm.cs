
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
    /// Kurum Anlaşma Durum Değiştirme
    /// </summary>
    public partial class ProtocolStatusChangingForm : TTForm
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
            #region ProtocolStatusChangingForm_PreScript
            base.PreScript();
            if (_ProtocolStatusChanging.CurrentStateDefID == ProtocolStatusChanging.States.New)
            {
                IList sepList = SubEpisodeProtocol.GetSEPByEpisode(_ProtocolStatusChanging.ObjectContext, _ProtocolStatusChanging.Episode.ObjectID);
                this.cmdOK.Visible = false;

                foreach (SubEpisodeProtocol sep in sepList)
                {
                    if (sep.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled)
                    {
                        ProtocolStatusChangingDetail prtStatusDetail = new ProtocolStatusChangingDetail(_ProtocolStatusChanging.ObjectContext);
                        prtStatusDetail.SEP = sep;

                        if (sep.CurrentStateDefID == SubEpisodeProtocol.States.Open)
                            prtStatusDetail.Status = SEPStateEnum.Open;
                        else if (sep.CurrentStateDefID == SubEpisodeProtocol.States.Closed)
                            prtStatusDetail.Status = SEPStateEnum.Closed;

                        _ProtocolStatusChanging.ProtocolStatusChangingDetails.Add(prtStatusDetail);
                    }
                }
            }
            #endregion ProtocolStatusChangingForm_PreScript

        }
    }
}