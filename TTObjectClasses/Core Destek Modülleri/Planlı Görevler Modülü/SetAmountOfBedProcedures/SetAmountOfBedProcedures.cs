
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
    public partial class SetAmountOfBedProcedures : BaseScheduledTask
    {
        public override void TaskScript()
        {
            try
            {
                AddLog("SetAmountOfBedProcedures has started");
                TTObjectContext roContext = new TTObjectContext(true);
                DateTime currentDate = Common.RecTime().Date;

                foreach (BaseBedProcedure item in BaseBedProcedure.GetActiveBedProcedures(roContext))
                {
                    try
                    {
                        TTObjectContext context = new TTObjectContext(false);
                        BaseBedProcedure bedProcedure = context.GetObject<BaseBedProcedure>(item.ObjectID);
                        int amount = Common.DateDiff(0, currentDate, bedProcedure.BedInPatientDate.Value.Date);
                        if (amount > 0) // BedInPatientDate ile currentDate aynı gün olursa amount u sıfırlamasın diye
                        {
                            bedProcedure.Amount = amount;
                            context.Save();
                        }

                        context.Dispose();
                    }
                    catch (Exception ex)
                    {
                        AddLog("'" + item.ObjectID.ToString() + "' ObjectId li yatak hizmetinin miktarı değiştirilirken hata alındı. ERROR: " + ex.ToString());
                    }
                }

                roContext.Dispose();
                AddLog("SetAmountOfBedProcedures has finished succesfully");
            }
            catch (Exception ex)
            {
                AddLog("ERROR: " + ex.ToString());
            }
        }
    }
}