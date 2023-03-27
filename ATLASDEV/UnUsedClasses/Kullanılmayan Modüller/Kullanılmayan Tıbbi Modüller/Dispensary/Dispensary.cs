
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
    /// Bakımevi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class Dispensary : EpisodeAction, IReasonOfReject, IWorkListEpisodeAction
    {
        protected void PostTransition_DispansaryCheckIn2Cancelled()
        {
            // From State : DispansaryCheckIn   To State : Cancelled
#region PostTransition_DispansaryCheckIn2Cancelled
            
            Cancel();
#endregion PostTransition_DispansaryCheckIn2Cancelled
        }

        protected void PostTransition_Dispansary2Cancelled()
        {
            // From State : Dispansary   To State : Cancelled
#region PostTransition_Dispansary2Cancelled
            
            Cancel();
#endregion PostTransition_Dispansary2Cancelled
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.Dispensary;
            }
        }
        
        public override void Cancel()
        {
            base.Cancel();
        }
        /*
        protected override List<OldActionPropertyObject> OldActionPropertyList()
        {
            List<OldActionPropertyObject> propertyList;
            if(base.OldActionPropertyList()==null)
                propertyList = new List<OldActionPropertyObject>();
            else
                propertyList = base.OldActionPropertyList();
            //-------------------------------------
            propertyList.Add(new OldActionPropertyObject("İstek Tarihi",Common.ReturnObjectAsString(RequestDate)));
            propertyList.Add(new OldActionPropertyObject("Protokol No",Common.ReturnObjectAsString(this.ProtocolNo)));
            propertyList.Add(new OldActionPropertyObject("Yatış Tarihi",Common.ReturnObjectAsString(StayingDate)));
            propertyList.Add(new OldActionPropertyObject("Çıkış Tarihi",Common.ReturnObjectAsString(DepartureDate)));
            
            propertyList.Add(new OldActionPropertyObject("Geçmişte Kalınan Gün Sayısı",Common.ReturnObjectAsString(NumberOfLastStayDays)));
            
            propertyList.Add(new OldActionPropertyObject("Geçmiş Vukuatlar",Common.ReturnObjectAsString(LastEvents)));
            
            if(Room != null)
                propertyList.Add(new OldActionPropertyObject("İstek Yapan Birim",Common.ReturnObjectAsString(Room.Name)));

            propertyList.Add(new OldActionPropertyObject("Gazilik Tanı",Common.ReturnObjectAsString(GhaziDiagnosis)));
            propertyList.Add(new OldActionPropertyObject("Kalış Sebebi",Common.ReturnObjectAsString(ReasonForStay)));
            propertyList.Add(new OldActionPropertyObject("Kalış Bilgisi",Common.ReturnObjectAsString(StayingInfo)));
            propertyList.Add(new OldActionPropertyObject("Vukuat",Common.ReturnObjectAsString(Events)));
            propertyList.Add(new OldActionPropertyObject("Doktor Notu",Common.ReturnObjectAsString(DoctorNote)));
            propertyList.Add(new OldActionPropertyObject("Sosyal Not",Common.ReturnObjectAsString(SocialNote)));
            propertyList.Add(new OldActionPropertyObject("Hemşire Notu",Common.ReturnObjectAsString(NurseNote)));
            propertyList.Add(new OldActionPropertyObject("Çıkış Nedeni",Common.ReturnObjectAsString(ReasonForDeparture)));
            //---------------------------------------
            return propertyList;
        }

        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        {
            List<List<List<OldActionPropertyObject>>> gridList;
            if(base.OldActionChildRelationList()==null)
                gridList=new List<List<List<OldActionPropertyObject>>>();
            else
                gridList=base.OldActionChildRelationList();

            List<List<OldActionPropertyObject>> gridProceduresRowList=new List<List<OldActionPropertyObject>>();
            //---------------------------------------

            foreach(DispensaryDrugs drug in DispensaryDrugs)
            {
                List<OldActionPropertyObject> gridProceduresRowColumnList=new List<OldActionPropertyObject>();
                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Y?lem Tarihi",Common.ReturnObjectAsString(Procedure.ActionDate)));

                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Ta? Kyrma Y?lemi",Common.ReturnObjectAsString(Procedure.ProcedureObject.Name)));

                if(Procedure.PartOfStone!=null)

                    gridProceduresRowColumnList.Add(new OldActionPropertyObject("Lokasyon",Common.ReturnObjectAsString(Procedure.PartOfStone.PartOfStone)));

                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Ta? Boyutu(mm)",Common.ReturnObjectAsString(Procedure.StoneDimension)));

                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Kaçyncy Seans",Common.ReturnObjectAsString(Procedure.NumberOfProcedure)));

                gridProceduresRowColumnList.Add(new OldActionPropertyObject("Taraf",Common.ReturnObjectAsString(Procedure.ZoneOfStone)));

                //---------------------------------------

                gridProceduresRowList.Add(gridProceduresRowColumnList);

            }

            gridList.Add(gridProceduresRowList);


            return gridList;
        }
        
        */
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Dispensary).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.DispansaryCheckIn && toState == States.Cancelled)
                PostTransition_DispansaryCheckIn2Cancelled();
            else if (fromState == States.Dispansary && toState == States.Cancelled)
                PostTransition_Dispansary2Cancelled();
        }

    }
}