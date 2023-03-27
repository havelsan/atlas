
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
    public partial class EpisodeCreationAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            ///Hasta Kabul sırasında yeni bir episode yaratmaya ve içini doldurmaya yarar...
            
            bool isNew=false;
            if(Interface.GetEpisode()==null)
            {
                if (Interface.GetMasterAction()==null)
                {
                    isNew=true;
                    Episode episode = new Episode(ObjectContext);
                  
                   // episode.Patient=Interface.Patient;
                    episode.CurrentStateDefID=Episode.States.Open;
                    episode.OpeningDate = Common.RecTime();
                    episode.PatientStatus=PatientStatusEnum.Outpatient;
                    episode.ID.GetNextValue();                    
                   
                    Interface.SetEpisode(episode);
                }
            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}