
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
    public partial class EmergInterInjuryLocationForm : EpisodeActionForm
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
#region EmergInterInjuryLocationForm_PreScript
    base.PreScript();
            
            //            if(_EmergencyInterventionInjuryLocation.Episode.Rank != null)
            //            {
            //                MilitaryUnitEpisode.Visible = true;
            //                PayerEpisode.Visible = false;
            //            }
            //            else
            if(_EmergencyInterventionInjuryLocation.Episode.Payer != null)
            {
                MilitaryUnitEpisode.Visible = false;
                PayerEpisode.Visible = true;
            }

            if (_EmergencyInterventionInjuryLocation.InjuryLocationImage == null)
            {
                BindingList<IMGTemplate> img = IMGTemplate.GetIMGTemplateForEmergInjuryLocation(_EmergencyInterventionInjuryLocation.ObjectContext);
                if (img.Count > 0)
                {
                    this.ImageBox.Image = (Image)img[0].Content;
                }
            }
#endregion EmergInterInjuryLocationForm_PreScript

            }
                }
}