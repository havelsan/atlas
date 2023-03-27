
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
    /// Set Sistem Ãœnite Tanımlama
    /// </summary>
    public  partial class SetSystemUnitRequestDef : BaseCentralAction
    {
        
                    
        protected override void PreInsert()
        {
#region PreInsert
            
            base.PreInsert();
             if (string.IsNullOrEmpty(Detail) == false)
                WorkListDescription = Detail;


#endregion PreInsert
        }

        protected void PreTransition_StateTwo2StateThree()
        {
            // From State : StateTwo   To State : StateThree
#region PreTransition_StateTwo2StateThree
            
            
            List<TTObject> objList = PrepareRemoteObject(this);
           // SetSystemUnitRequestDef.RemoteMethods.SendSetSystemUnitRequest(Sites.SiteMerkezSagKom, objList);
#endregion PreTransition_StateTwo2StateThree
        }

        protected void PreTransition_StateThree2Completed()
        {
            // From State : StateThree   To State : Completed
#region PreTransition_StateThree2Completed
            
            

            SetSystemUnitDefinition setMaterial = new SetSystemUnitDefinition(_objectContext);
            setMaterial.Barcode = Barcode == null ? null : Barcode;
            setMaterial.CalibrationPeriod = CalibrationPeriod == null ? null : CalibrationPeriod;
            setMaterial.Desciption = Desciption == null ? null : Desciption;
            setMaterial.FixedAssetDetailMarkDef = FixedAssetDetailMarkDef == null ? null : FixedAssetDetailMarkDef;
            setMaterial.FixedAssetDetailModelDef = FixedAssetDetailModelDef == null ? null : FixedAssetDetailModelDef;
            setMaterial.GuarantiePeriod = GuarantiePeriod == null ? null : GuarantiePeriod;
            setMaterial.GuarantyStartDate = GuarantyStartDate == null ? null : GuarantyStartDate;
            setMaterial.LifePeriod = LifePeriod == null ? null : LifePeriod;
            setMaterial.MaintenancePeriod = MaintenancePeriod == null ? null : MaintenancePeriod;
            setMaterial.MaterialCategory = MaterialCategory == null ? null : MaterialCategory;
            setMaterial.Name = Detail == null ? null : Detail;
            setMaterial.NeedCalibration = NeedCalibration == null ? null : NeedCalibration;
            setMaterial.NeedMaintenance = NeedMaintenance == null ? null : NeedMaintenance;
            setMaterial.Producer = Producer == null ? null : Producer;
            setMaterial.ReferansNo = ReferansNo == null ? null : ReferansNo;
            setMaterial.UseGoal = UseGoal == null ? null : UseGoal;
            setMaterial.UsePlaces = UsePlaces == null ? null : UsePlaces;
            setMaterial.Sites = FromSite == null ? null : FromSite;
            setMaterial.TechnicalSpecificationsNo = TechnicalSpecificationsNo == null ? null : TechnicalSpecificationsNo;
            


#endregion PreTransition_StateThree2Completed
        }

        protected void PostTransition_StateThree2Completed()
        {
            // From State : StateThree   To State : Completed
#region PostTransition_StateThree2Completed
            
            
            
            List<TTObject> objList = PrepareRemoteObject(this);
           // SetSystemUnitRequestDef.RemoteMethods.SendSetSystemUnitRequest(this.FromSite.ObjectID, objList);

#endregion PostTransition_StateThree2Completed
        }

        protected void PostTransition_StateThree2StateOne()
        {
            // From State : StateThree   To State : StateOne
#region PostTransition_StateThree2StateOne
            
            
            
            List<TTObject> objList = PrepareRemoteObject(this);
         //   SetSystemUnitRequestDef.RemoteMethods.SendSetSystemUnitRequest(this.FromSite.ObjectID, objList);
#endregion PostTransition_StateThree2StateOne
        }

#region Methods
        public List<TTObject> PrepareRemoteObject (SetSystemUnitRequestDef setSystemUnitRequestDef)
        {
            List<TTObject> objList = new List<TTObject>();
            objList.Add(setSystemUnitRequestDef);
            return objList;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SetSystemUnitRequestDef).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SetSystemUnitRequestDef.States.StateTwo && toState == SetSystemUnitRequestDef.States.StateThree)
                PreTransition_StateTwo2StateThree();
            else if (fromState == SetSystemUnitRequestDef.States.StateThree && toState == SetSystemUnitRequestDef.States.Completed)
                PreTransition_StateThree2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SetSystemUnitRequestDef).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SetSystemUnitRequestDef.States.StateThree && toState == SetSystemUnitRequestDef.States.Completed)
                PostTransition_StateThree2Completed();
            else if (fromState == SetSystemUnitRequestDef.States.StateThree && toState == SetSystemUnitRequestDef.States.StateOne)
                PostTransition_StateThree2StateOne();
        }

    }
}