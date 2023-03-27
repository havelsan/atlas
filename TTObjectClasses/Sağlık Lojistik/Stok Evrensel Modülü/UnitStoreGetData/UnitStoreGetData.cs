
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
    public  partial class UnitStoreGetData : TerminologyManagerDef
    {
        public partial class GetUnitStoreGetDataList_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static void AddMKYSUnitStoreGetData ()
        {
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MKYSSERVISUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MKYSSERVISPASSWORD", "XXXXXX");
            //MkysServis.SoapKontrol S = new MkysServis.SoapKontrol();

            if (userName != null && password != null)
            {
                MkysServis.birimDepoItem[] birimDepoItems = MkysServis.WebMethods.birimDepoGetDataSync(Sites.SiteLocalHost);
                
                
                for (int i =0; i < birimDepoItems.Length; i++)
                {
                    string filter = "(STORERECORDNO = " + birimDepoItems[i].depoKayitNo.ToString() + " )";
                    UnitStoreGetData foundRec = null;

                    TTObjectContext objectContext = new TTObjectContext(false);
                    
                    BindingList <UnitStoreGetData> bindingList = objectContext.QueryObjects<UnitStoreGetData>(filter);
                    if(bindingList != null  && bindingList.Count > 0 )
                        foundRec = bindingList[0];

                    if ( foundRec == null )
                    {
                        UnitStoreGetData unitStoreGetData = new UnitStoreGetData(objectContext);
                        unitStoreGetData.StoreRecordNo = birimDepoItems[i].depoKayitNo;
                        unitStoreGetData.StoreCode = birimDepoItems[i].depoKodu;
                        unitStoreGetData.StoreDefinition = birimDepoItems[i].depoTanimi;
                        unitStoreGetData.IntegrationScope = birimDepoItems[i].entegrasyonKapsaminda;
                        unitStoreGetData.UnitRecordNo = birimDepoItems[i].birimKayitNo;
                    }
                    else
                    {
                        foundRec.StoreRecordNo = birimDepoItems[i].depoKayitNo;
                        foundRec.StoreCode = birimDepoItems[i].depoKodu;
                        foundRec.StoreDefinition = birimDepoItems[i].depoTanimi;
                        foundRec.IntegrationScope = birimDepoItems[i].entegrasyonKapsaminda;
                        foundRec.UnitRecordNo = birimDepoItems[i].birimKayitNo;
                    }
                    objectContext.Save();
                    objectContext.Dispose();
                    
                }
            }
            
        }
        
#endregion Methods

    }
}