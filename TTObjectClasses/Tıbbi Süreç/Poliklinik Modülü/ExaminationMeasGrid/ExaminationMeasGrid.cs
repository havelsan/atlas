
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
    /// Muayene Ölçümleri
    /// </summary>
    public  partial class ExaminationMeasGrid : TTObject
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "EPISODEACTION":
                    {
                        EpisodeAction value = (EpisodeAction)newValue;
#region EPISODEACTION_SetParentScript
                        if(value!=null){
                Episode=value.Episode;
            }
#endregion EPISODEACTION_SetParentScript
                    }
                    break;
                case "SUBACTIONPROCEDURE":
                    {
                        SubactionProcedureFlowable value = (SubactionProcedureFlowable)newValue;
#region SUBACTIONPROCEDURE_SetParentScript
                        if(value!=null){
                Episode=value.Episode;
            }
#endregion SUBACTIONPROCEDURE_SetParentScript
                    }
                    break;

            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            CheckAndSetDefaultProperties();
#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
#endregion PreUpdate
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true && MeasDate == null)
                MeasDate = Common.RecTime();
        }
        
        protected void CheckAndSetDefaultProperties()
        {
            if (MeasDate==null)
            {
                MeasDate= Common.RecTime();
            }
            if(EpisodeAction != null)
            {
                if(Heigth != null)
                    EpisodeAction.Episode.Patient.Heigth = Heigth;
                if(Weight != null)
                    EpisodeAction.Episode.Patient.Weight = Weight;
                if(HeadCircumference != null)
                    EpisodeAction.Episode.Patient.HeadCircumference = HeadCircumference;
                if(ChestCircumference != null)
                    EpisodeAction.Episode.Patient.ChestCircumference = ChestCircumference;
            }
            else if(SubactionProcedure != null)
            {
                if(Heigth != null)
                    SubactionProcedure.Episode.Patient.Heigth = Heigth;
                if(Weight != null)
                    SubactionProcedure.Episode.Patient.Weight = Weight;
                if(HeadCircumference != null)
                    SubactionProcedure.Episode.Patient.HeadCircumference = HeadCircumference;
                if(ChestCircumference != null)
                    SubactionProcedure.Episode.Patient.ChestCircumference = ChestCircumference;
            }
        }
        
#endregion Methods

    }
}