
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// TestCPT4ListForm
    /// </summary>
    public partial class TestCPT4ListForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton4.Click += new TTControlEventDelegate(ttbutton4_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton4.Click -= new TTControlEventDelegate(ttbutton4_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton4_Click()
        {
#region TestCPT4ListForm_ttbutton4_Click
   TurnSurgeryDefinitionBUTToCPT4();
#endregion TestCPT4ListForm_ttbutton4_Click
        }

#region TestCPT4ListForm_Methods
        private void TurnSurgeryDefinitionBUTToCPT4()
        {
            TTInstanceManagement.TTObjectContext context =new TTInstanceManagement.TTObjectContext(false);
            Dictionary<string,SurgeryDefinition> list = new Dictionary<string,SurgeryDefinition>();
            int deletedCount=0;
            int total=0;
            int added=0;
            int countPrice=0;
            int tekrar=0;
            foreach( SurgeryDefinition sd in context.QueryObjects(typeof(SurgeryDefinition).Name))
            {   total++;
                if(!String.IsNullOrEmpty(sd.Qref))
                {
                    IList ButList= context.QueryObjects(typeof(SUTDefinition).Name," CODE ='" + sd.Qref + "'");
                    if(ButList.Count<1 && sd.Code==sd.Qref) // But kodu oladuğunu burdan anlıyor
                    {
                        ((ITTObject)sd).Delete();
                        deletedCount++;
                    }
                    else
                    {
                        int count = 0;
                        double surgeryPoint = 0;
                        PricingDetailDefinition pd=null;
                        SurgeryPointGroupEnum? surgeryPointGroup=null;
                        foreach (MatchingCPT4AndSUTDefinitions cptmatch in ((SUTDefinition)ButList[0]).CPT4Definitions )
                        {
                            if(count==0)
                            {
                                surgeryPoint=(double)sd.GetSUTPoint();
                                surgeryPointGroup=sd.SurgeryPointGroup;
                                foreach(ProcedurePriceDefinition ppd in sd.ProcedurePrice)
                                {
                                    pd=ppd.PricingDetail;
                                    break;
                                }
                                SurgeryDefinition sdold=null;
                                if(list.TryGetValue(cptmatch.CPT4Definition.CPTCode.ToString(),out sdold))
                                {
                                    if(sd.Code!=sdold.Qref)
                                    {
                                        //sdold.SurgeryPoint=surgeryPoint;//??????
                                        sdold.SurgeryPointGroup=surgeryPointGroup;//??????
                                        foreach(ProcedurePriceDefinition ppd in sd.ProcedurePrice)
                                        {
                                            sdold.ProcedurePrice.Add(ppd);
                                        }
                                        ((ITTObject)sd).Delete();
                                        tekrar++;
                                    }
                                }
                                else
                                {
                                    sd.Name=cptmatch.CPT4Definition.TurkishName;
                                    sd.EnglishName=cptmatch.CPT4Definition.EnglishName;
                                    sd.Code=cptmatch.CPT4Definition.CPTCode;
                                    sd.IsActive=cptmatch.CPT4Definition.IsActive;
                                    list.Add(cptmatch.CPT4Definition.CPTCode.ToString(),sd);
                                    countPrice++;
                                }
                            }
                            else
                            {
                                if(!list.ContainsKey(cptmatch.CPT4Definition.CPTCode.ToString()))
                                {
                                    SurgeryDefinition sd2= (SurgeryDefinition)context.CreateObject(typeof(SurgeryDefinition).Name);
                                    sd2.Name=cptmatch.CPT4Definition.TurkishName;
                                    sd2.EnglishName=cptmatch.CPT4Definition.EnglishName;
                                    sd2.Code=cptmatch.CPT4Definition.CPTCode;
                                    sd2.IsActive=cptmatch.CPT4Definition.IsActive;
                                    sd2.SurgeryPointGroup=surgeryPointGroup;
                                    //sd2.SurgeryPoint=surgeryPoint;
                                    if(pd!=null)
                                    {
                                        ProcedurePriceDefinition ppdef= (ProcedurePriceDefinition)context.CreateObject(typeof(ProcedurePriceDefinition).Name);
                                        ppdef.PricingDetail = pd;
                                        ppdef.AMOUNT = 1;
                                        ppdef.ProcedureObject = sd2;
                                        countPrice++;
                                    }
                                    added++;
                                    list.Add(cptmatch.CPT4Definition.CPTCode.ToString(),sd2);
                                }
                            }
                            count++;
                        }
                        if(count==0 && sd.Code==sd.Qref)
                        {
                            sd.ProcedurePrice.DeleteChildren();
                            ((ITTObject)sd).Delete();
                            deletedCount++;
                            countPrice--;

                        }
                    }
                }
            }
            InfoBox.Show(total +" kayıttan " + deletedCount  + "tane kayıt silindi");
            
            
            foreach( CPT4Definition cpt in context.QueryObjects(typeof(CPT4Definition).Name," PROCEDURETYPE.PROCEDURETYPENAME = 'Ameliyat'"))//CPT4 'de ameliyat altında olup Ameliyat tanımlarında olmayanlar
            {
                if(!list.ContainsKey(cpt.CPTCode.ToString()))
                {
                    SurgeryDefinition sd2= (SurgeryDefinition)context.CreateObject(typeof(SurgeryDefinition).Name);
                    sd2.Name=cpt.TurkishName;
                    sd2.EnglishName=cpt.EnglishName;
                    sd2.Code=cpt.CPTCode;
                    sd2.IsActive=cpt.IsActive;
                    list.Add(cpt.CPTCode.ToString(),sd2);
                    added++;
                    foreach (MatchingCPT4AndSUTDefinitions m in cpt.SUTDefinitions)
                    {
                        foreach( PricingDetailDefinition pdd in context.QueryObjects(typeof(PricingDetailDefinition).Name," EXTERNALCODE = '" + m.SUTDefinition.Code + "'"))
                        {
                            ProcedurePriceDefinition ppdef= (ProcedurePriceDefinition)context.CreateObject(typeof(ProcedurePriceDefinition).Name);
                            ppdef.PricingDetail = pdd;
                            ppdef.AMOUNT = 1;
                            ppdef.ProcedureObject = sd2;
                            break;
                            //countPrice++;
                        }
                        
                    }
                }
            }
            InfoBox.Show(added  + " tane kayıt eklendi");
            InfoBox.Show("Toplam Ameliyat CPT4 sayısı " + list.Count.ToString());
            //context.Save();
        }
        
#endregion TestCPT4ListForm_Methods
    }
}