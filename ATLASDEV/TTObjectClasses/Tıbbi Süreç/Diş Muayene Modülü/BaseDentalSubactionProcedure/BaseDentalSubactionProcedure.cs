
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
    public  partial class BaseDentalSubactionProcedure : SubactionProcedureWithDiagnosis
    {
#region Methods
        public override TreatmentDischarge MyTreatmentDischarge()
        {
            //foreach (TreatmentDischarge treatmentDischarge in this.TreatmentDischarges)
            //{
            //    if( !treatmentDischarge.IsCancelled && treatmentDischarge.CurrentStateDef.Status!= StateStatusEnum.CompletedUnsuccessfully)
            //    {
            //        return treatmentDischarge;
            //    }
            //}
            
            // muayene formunda  yeni oluşturulam MTS ayrı contextde olduğu için bide veri tabanından bakılır
            //TTObjectContext context= new TTObjectContext(true);
            //BindingList<TTObjectClasses.TreatmentDischarge> treatmentDischargeList = TTObjectClasses.TreatmentDischarge.GetTreatmentDischargeByEpisode(context, this.Episode.ObjectID);
            //foreach(TTObjectClasses.TreatmentDischarge trDis in treatmentDischargeList)
            //{
            //    if((!trDis.IsCancelled) && trDis.CurrentStateDef.Status!= StateStatusEnum.CompletedUnsuccessfully && trDis.BaseDentalSubactionProcedure!=null && trDis.BaseDentalSubactionProcedure.ObjectID==this.ObjectID)
            //        return trDis;
            //}
            return null;
            
        }
        
#endregion Methods

    }
}