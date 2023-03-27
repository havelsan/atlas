
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Yatan Hasta Hastanın Güncesi Sekmesi
    /// </summary>
    public partial class InPatientPhysicianProgresses : TTObject
    {
        public partial class GetInpatienPhProgressesBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetInpatienPhProgressesByEpisode_Class : TTReportNqlObject
        {
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            if (EntryEpisodeAction.SendToENabiz()) // Klinik seyir eklendikçe  103 paketi yollanır
                    new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "103", Common.RecTime());
            #endregion PostInsert
        }

        #region Methods

        public InPatientPhysicianProgresses(string progressDescription,DateTime progressDate, EpisodeAction episodeAction):this(episodeAction.ObjectContext)
        {
            EntryEpisodeAction = episodeAction;
            SubEpisode = episodeAction.SubEpisode;
            Description = progressDescription;
            ProgressDate = progressDate;
            if (ProcedureDoctor == null)
                ProcedureDoctor = Common.CurrentDoctor != null ? Common.CurrentDoctor : episodeAction.ProcedureDoctor;
        }




        #endregion Methods

    }
}