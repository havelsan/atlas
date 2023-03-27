
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
    /// MKYS Malzeme Eşleştirme
    /// </summary>
    public  partial class MalzemeGetData : TerminologyManagerDef
    {
        public partial class GetmalzemeGetDataList_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static void AddMKYSMalzemeGetData (DateTime time)
        {
            
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSSERVISUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MKYSSERVISPASSWORD", "XXXXXX");

            //MkysServis.SoapKontrol S = new MkysServis.SoapKontrol();
            


            if (userName != null && password != null)
            {
               MkysServis.malzemeItem [] malzemeItems = MkysServis.WebMethods.malzemeGetDataSync(Sites.SiteLocalHost, time);
              
                

                for (int i =0; i < malzemeItems.Length; i++)
                {
                     TTObjectContext objectContext = new TTObjectContext(false);
                    string filter = "(MALZEMEKAYITID = " + malzemeItems[i].malzemeKayitID.ToString() + " )";
                    MalzemeGetData foundRec = null;


                    BindingList <MalzemeGetData> bindingList = objectContext.QueryObjects<MalzemeGetData>(filter);
                    if(bindingList != null  && bindingList.Count > 0 )
                       foundRec = bindingList[0];


                   

                    if ( foundRec == null )
                    {
                        //eklle
                        MalzemeGetData malzemeGetData = new MalzemeGetData(objectContext);

                        malzemeGetData.malzemeKayitID = malzemeItems[i].malzemeKayitID;
                        malzemeGetData.malzemeKodu = malzemeItems[i].malzemeKodu;
                        malzemeGetData.malzemeAdi = malzemeItems[i].malzemeAdi;
                        malzemeGetData.degisiklikTarihi = malzemeItems[i].degisiklikTarihi;
                        malzemeGetData.olcuBirimiID = malzemeItems[i].olcuBirimID;
                        malzemeGetData.malzemeTurID = malzemeItems[i].malzemeTurID;
                        malzemeGetData.eskiMalzemeKodu = malzemeItems[i].eskiMalzemeKodu;
                    }
                    else
                    {
                        
                        foundRec.malzemeKodu = malzemeItems[i].malzemeKodu;
                        foundRec.malzemeAdi = malzemeItems[i].malzemeAdi;
                        foundRec.degisiklikTarihi = malzemeItems[i].degisiklikTarihi;
                        foundRec.olcuBirimiID = malzemeItems[i].olcuBirimID;
                        foundRec.malzemeTurID = malzemeItems[i].malzemeTurID;
                        foundRec.eskiMalzemeKodu = malzemeItems[i].eskiMalzemeKodu;
                    }
                    
                    
                    objectContext.Save();
                    objectContext.Dispose();
        
                }
            }
            
            
        }
        
#endregion Methods

    }
}