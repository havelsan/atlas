
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
    public partial class ApacheScore : BaseMultipleDataEntry
    {
        public override string GetSummary()
        {
            string tempString = String.Empty;

            if (ApacheIITotal != null)
            {
                tempString += " Apache II: " + ApacheIITotal + ",";
            }

            if (ExpectedMortalityRate != null)
            {
                tempString += " Beklenen Ölüm Oranı: " + ExpectedMortalityRate + "%";
            }



            return tempString;
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            Send501ToENabiz();
            //this.Send502ToENabiz();
            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            Send501ToENabiz();
            //this.Send502ToENabiz();
            #endregion PostUpdate
        }


        public void Send501ToENabiz()
        {
            var myIntensiveCareSpecialityObj = PhysicianApplication.GetMyIntensiveCareSpecialityObj();
            if (myIntensiveCareSpecialityObj != null)
                myIntensiveCareSpecialityObj.Send501ToENabiz();
        }
        //public void Send502ToENabiz()
        //{
        //    var myIntensiveCareSpecialityObj = this.PhysicianApplication.GetMyIntensiveCareSpecialityObj();
        //    if (myIntensiveCareSpecialityObj != null)
        //        //myIntensiveCareSpecialityObj.Send502ToENabiz();
        //}
    }
}