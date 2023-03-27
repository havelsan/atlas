
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
    public partial class BaseEpisodeActionDataCorrectionForm : BaseEpisodeDataCorrectionForm
    {
        override protected void BindControlEvents()
        {
            ShowEpisodeActionButton.Click += new TTControlEventDelegate(ShowEpisodeActionButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ShowEpisodeActionButton.Click -= new TTControlEventDelegate(ShowEpisodeActionButton_Click);
            base.UnBindControlEvents();
        }

        private void ShowEpisodeActionButton_Click()
        {
#region BaseEpisodeActionDataCorrectionForm_ShowEpisodeActionButton_Click
   try
            {
                InfoBox.Show("ShowEpisodeAction(this, _BaseEpisodeActionDataCorrection.EpisodeAction);");
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion BaseEpisodeActionDataCorrectionForm_ShowEpisodeActionButton_Click
        }

        protected override void ClientSidePreScript()
        {
#region BaseEpisodeActionDataCorrectionForm_ClientSidePreScript
    base.ClientSidePreScript();
#endregion BaseEpisodeActionDataCorrectionForm_ClientSidePreScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseEpisodeActionDataCorrectionForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
#endregion BaseEpisodeActionDataCorrectionForm_ClientSidePostScript

        }

#region BaseEpisodeActionDataCorrectionForm_ClientSideMethods
        //private void ShowEpisodeAction(System.Windows.Forms.Form parentForm, EpisodeAction episodeAction)
        //{
        //    //TTObjectContext readOnlyObjectContext = null;
        //    //try
        //    //{
        //    //    readOnlyObjectContext = new TTObjectContext(true);
        //    //    TTObject refreshedObject = readOnlyObjectContext.GetObject(episodeAction.ObjectID, episodeAction.ObjectDef);
        //    //    TTForm ttForm = TTForm.GetEditForm(episodeAction);
        //    //    ttForm.ShowReadOnly(parentForm, refreshedObject);
        //    //}
        //    //finally
        //    //{
        //    //    if (readOnlyObjectContext != null)
        //    //        readOnlyObjectContext.Dispose();
        //    //}
        //}
        
#endregion BaseEpisodeActionDataCorrectionForm_ClientSideMethods
    }
}