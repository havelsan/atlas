
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
    public  partial class NursingGlaskowComaScale : BaseNursingDataEntry
    {
#region Methods
        public static GlaskowComaScaleScoreEnum? CalcGlaskowComaScaleTotalScore(NursingGlaskowComaScale nursingGlaskowComaScale)
        {
            int? toplam=0;
            
            if(nursingGlaskowComaScale.Eyes!=null)
                toplam+= nursingGlaskowComaScale.Eyes.Score;
            if(nursingGlaskowComaScale.MotorAnswer!=null)
                toplam+= nursingGlaskowComaScale.MotorAnswer.Score;
            if(nursingGlaskowComaScale.OralAnswer!=null)
                toplam+= nursingGlaskowComaScale.OralAnswer.Score;
            
            
            if(toplam>=15){
                nursingGlaskowComaScale.TotalScore=GlaskowComaScaleScoreEnum.Normal;//oryante
            }else if(toplam >= 13){
                nursingGlaskowComaScale.TotalScore=GlaskowComaScaleScoreEnum.Weak;//konfüze
            }else if(toplam >= 8 ){
                nursingGlaskowComaScale.TotalScore=GlaskowComaScaleScoreEnum.Medium;//stupor
            }else if (toplam >= 4 )
            {
                nursingGlaskowComaScale.TotalScore = GlaskowComaScaleScoreEnum.Perikoma;//perikoma
            }
            else 
            {
                nursingGlaskowComaScale.TotalScore=GlaskowComaScaleScoreEnum.Coma;//koma
            }
            return nursingGlaskowComaScale.TotalScore;
        }
        
        //protected override bool IsReadOnly()
        //{
        //    if(((ITTObject)this).IsNew!=true)
        //        return true;
            
        //    return false;
        //}

        public override string GetApplicationSummary()
        {
            string tempString = String.Empty;

            if (Eyes!=null && Eyes.ObjectID != null)
            {
                tempString += " Gözler: " + Eyes.Name_Shadow + ",";
            }

            if (OralAnswer != null && OralAnswer.ObjectID != null)
            {
                tempString += " Sözel Cevap: " + OralAnswer.Name_Shadow + ",";
            }

            if (MotorAnswer != null && MotorAnswer.ObjectID != null)
            {
                tempString += " Motor Cevap: " + MotorAnswer.Name_Shadow;
            }

            if (tempString != String.Empty)
                tempString = " Toplam Puan: " + (GlaskowComaScaleScoreEnum)TotalScore.Value + "," + tempString ;

            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }
        #endregion Methods

    }

}