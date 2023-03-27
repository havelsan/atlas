
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
    public  partial class NursingWaterlowRisk : TTObject
    {
#region Methods
        public static void CalcWaterlowRiskScore(NursingWaterlowRisk nursingWaterlowRisk){
            int? toplam=0;
            
            if(nursingWaterlowRisk.HeightSizeRate != null)
                toplam+= nursingWaterlowRisk.HeightSizeRate.Score;
            if(nursingWaterlowRisk.SkinType !=null)
                toplam+= nursingWaterlowRisk.SkinType.Score;
            if(nursingWaterlowRisk.TextureMalnutrusyon !=null)
                toplam+= nursingWaterlowRisk.TextureMalnutrusyon.Score;
            if(nursingWaterlowRisk.Kontinans !=null)
                toplam+= nursingWaterlowRisk.Kontinans.Score;
            if(nursingWaterlowRisk.Mobilite !=null)
                toplam+= nursingWaterlowRisk.Mobilite.Score;
            if(nursingWaterlowRisk.Appetite !=null)
                toplam+= nursingWaterlowRisk.Appetite.Score;
            if(nursingWaterlowRisk.NeurologicalProblem !=null)
                toplam+= nursingWaterlowRisk.NeurologicalProblem.Score;
            if(nursingWaterlowRisk.SurgerAndTrauma !=null)
                toplam+= nursingWaterlowRisk.SurgerAndTrauma.Score;
            if(nursingWaterlowRisk.Drugs !=null)
                toplam+= nursingWaterlowRisk.Drugs.Score;
            if(nursingWaterlowRisk.Sex !=null)
                toplam+= nursingWaterlowRisk.Sex.Score;
            if(nursingWaterlowRisk.Age !=null)
                toplam+= nursingWaterlowRisk.Age.Score;
            
            if(toplam>=20){
                nursingWaterlowRisk.RiskScore =WaterlowScoreEnum.TwentyPlusRisk;
            }else if(toplam>=15){
                nursingWaterlowRisk.RiskScore =WaterlowScoreEnum.FifteenPlusRisk;
            }else if(toplam>=10){
                nursingWaterlowRisk.RiskScore =WaterlowScoreEnum.TenPlusRisk;
            }else{
                nursingWaterlowRisk.RiskScore =WaterlowScoreEnum.LowThenTen;
            }
        }
        protected override bool IsReadOnly()
        {
            if(((ITTObject)this).IsNew!=true)
                return true;
            
            return false;
        }
        
#endregion Methods

    }
}