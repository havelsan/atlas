
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
    /// Anestezi ve Reanimasyon
    /// </summary>
    public partial class AnesthesiaRequestForm : EpisodeActionForm
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
#region AnesthesiaRequestForm_PreScript
    base.PreScript();
            this.DropStateButton(AnesthesiaAndReanimation.States.Cancelled);
            
            //----------------------
            int consLimit = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("AnesthesiaConsultationAvailabilityDate","30"));
            DateTime limitDate= ((DateTime)Common.RecTime()).AddDays(-1*consLimit);
            TTObjectContext context = new TTObjectContext(true);
            IList<AnesthesiaConsultation> anestCons = AnesthesiaConsultation.GetByDateLimitAndPatient(context,limitDate,this._AnesthesiaAndReanimation.Episode.Patient.ObjectID);
            AnesthesiaConsultation anestezi=null;
            DateTime time=Convert.ToDateTime("01.01.1999");
            foreach(AnesthesiaConsultation ac in anestCons)
            {
                if(time<ac.ProcessDate)
                    anestezi=ac;
            }
            if(anestezi!=null)
            {
                this._AnesthesiaAndReanimation.ASAType=anestezi.ASAType;
            }
#endregion AnesthesiaRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AnesthesiaRequestForm_PostScript
    base.PostScript(transDef);
#endregion AnesthesiaRequestForm_PostScript

            }
                }
}