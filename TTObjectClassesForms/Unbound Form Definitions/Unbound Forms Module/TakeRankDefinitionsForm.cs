
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
    /// Rütbe Bilgileri Alma Formu
    /// </summary>
    public partial class TakeRankDefinitionsForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region TakeRankDefinitionsForm_ttbutton1_Click
   System.Diagnostics.Debugger.Break();
            RankDefinitions  rank = new RankDefinitions();
            rank.Code = Convert.ToInt32(CODE.Text);
            rank.ExternalCode = EXTERNALCODE.Text.ToString();
            rank.ID = Convert.ToInt32(ID.Text);
            rank.Name = NAME.Text.ToString();
            //rank.Type = TYPE.Text;
            rank.IsActive  = Convert.ToBoolean(ACTIVE.Text);
            //TTMessage m = RankDefinitions.RemoteMethods.SaveRank(Sites.SiteLocalHost,rank);
            //TTMessage mID  = TTMessageFactory.GetMessage(m.MessageID);
            //string return = mID.ReturnValue;
#endregion TakeRankDefinitionsForm_ttbutton1_Click
        }
    }
}