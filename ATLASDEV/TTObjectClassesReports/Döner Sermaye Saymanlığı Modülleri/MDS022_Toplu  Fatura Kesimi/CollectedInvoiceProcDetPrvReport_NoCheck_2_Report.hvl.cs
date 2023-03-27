
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Hizmet Detay Bilgisi Öndökümü
    /// </summary>
    public partial class CollectedInvoiceProcDetPrvReport_NoCheck_2 : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string DOCUMENTNO = (string)TTObjectDefManager.Instance.DataTypes["String30"].ConvertValue("");
            public List<string> RESOURCES = new List<string>();
            public List<string> RESOURCESFILTER = new List<string>();
            public List<string> RES = new List<string>();
            public List<string> EPISODES = new List<string>();
            public List<string> PAYERS = new List<string>();
            public int? PATIENTSTATUS = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CollectedInvoiceProcDetPrvReport_NoCheck_2 MyParentReport
            {
                get { return (CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public CollectedInvoiceProcDetPrvReport_NoCheck_2 MyParentReport
                {
                    get { return (CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    ((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Clear();
            
            if (((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RES == null)
                ((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER = ((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCES;
            else
            {
                foreach (string objectID in ((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RES)
                {
                    ResSection section = (ResSection)this.ParentReport.ReportObjectContext.GetObject(new Guid(objectID),"ResSection");
                    if (section is ResDepartment)
                    {
                        ResDepartment department = (ResDepartment)section;
                        // Bölüme direkt bağlı poliklinik ve klinikler listeye eklenir
                        foreach (ResPoliclinic Pol in department.Policlinics)
                        {
                            //((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Add(Pol.ObjectID.ToString());
                            foreach(ResourceSpecialityGrid polSpeciality in Pol.ResourceSpecialities)
                            {
                                if(polSpeciality.Speciality != null)
                                    ((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Add(polSpeciality.Speciality.ObjectID.ToString());
                            }
                        }
                        foreach (ResClinic Cln in department.Clinics)
                        {
                            //((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Add(Cln.ObjectID.ToString());
                            foreach(ResourceSpecialityGrid clnSpeciality in Cln.ResourceSpecialities)
                            {
                                if(clnSpeciality.Speciality != null)
                                    ((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Add(clnSpeciality.Speciality.ObjectID.ToString());
                            }
                        }
                        
                        // Bölümün alt bölümleri varsa herbir alt bölümün de poliklinik ve klinikleri listeye eklenmeli
                        foreach (ResDepartment childDepartment in department.Departments)
                        {
                            foreach (ResPoliclinic Pol in childDepartment.Policlinics)
                            {
                                //((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Add(Pol.ObjectID.ToString());
                                foreach(ResourceSpecialityGrid polSpeciality in Pol.ResourceSpecialities)
                                {
                                    if(polSpeciality.Speciality != null)
                                        ((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Add(polSpeciality.Speciality.ObjectID.ToString());
                                }
                            }
                            foreach (ResClinic Cln in childDepartment.Clinics)
                            {
                                //((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Add(Cln.ObjectID.ToString());
                                foreach(ResourceSpecialityGrid clnSpeciality in Cln.ResourceSpecialities)
                                {
                                    if(clnSpeciality.Speciality != null)
                                        ((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Add(clnSpeciality.Speciality.ObjectID.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        //((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Add(objectID.ToString());
                        foreach(ResourceSpecialityGrid resSpeciality in section.ResourceSpecialities)
                        {
                            if(resSpeciality.Speciality != null)
                                ((CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport).RuntimeParameters.RESOURCESFILTER.Add(resSpeciality.Speciality.ObjectID.ToString());
                        }
                    }
                }
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CollectedInvoiceProcDetPrvReport_NoCheck_2 MyParentReport
                {
                    get { return (CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class HEADGroup : TTReportGroup
        {
            public CollectedInvoiceProcDetPrvReport_NoCheck_2 MyParentReport
            {
                get { return (CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField NewField1101 { get {return Header().NewField1101;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField HASTAADI { get {return Header().HASTAADI;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportField HASTASIRANO { get {return Header().HASTASIRANO;} }
            public TTReportField NewField121111 { get {return Header().NewField121111;} }
            public TTReportField NewField111121 { get {return Header().NewField111121;} }
            public TTReportField YAS { get {return Header().YAS;} }
            public TTReportField NewField1111121 { get {return Header().NewField1111121;} }
            public TTReportField NewField121121 { get {return Header().NewField121121;} }
            public TTReportField NewField1211121 { get {return Header().NewField1211121;} }
            public TTReportField SAYFANO { get {return Header().SAYFANO;} }
            public TTReportField NewField1121121 { get {return Header().NewField1121121;} }
            public TTReportField NewField11211121 { get {return Header().NewField11211121;} }
            public TTReportField NewField111122 { get {return Header().NewField111122;} }
            public TTReportField NewField121112 { get {return Header().NewField121112;} }
            public TTReportField NewField121113 { get {return Header().NewField121113;} }
            public TTReportField TARIH1LBL { get {return Header().TARIH1LBL;} }
            public TTReportField NewField121115 { get {return Header().NewField121115;} }
            public TTReportField NewField121116 { get {return Header().NewField121116;} }
            public TTReportField NewField1611121 { get {return Header().NewField1611121;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField1111122 { get {return Header().NewField1111122;} }
            public TTReportField NewField11211111 { get {return Header().NewField11211111;} }
            public TTReportField NewField111113 { get {return Header().NewField111113;} }
            public TTReportField NewField1111112 { get {return Header().NewField1111112;} }
            public TTReportField NewField1111123 { get {return Header().NewField1111123;} }
            public TTReportField NewField11211112 { get {return Header().NewField11211112;} }
            public TTReportField NewField1121123 { get {return Header().NewField1121123;} }
            public TTReportField NewField11211123 { get {return Header().NewField11211123;} }
            public TTReportField NewField1121124 { get {return Header().NewField1121124;} }
            public TTReportField NewField11211124 { get {return Header().NewField11211124;} }
            public TTReportField KURUMADI { get {return Header().KURUMADI;} }
            public TTReportField HOSPITALPROTOCOLNO { get {return Header().HOSPITALPROTOCOLNO;} }
            public TTReportField KURUMKODU { get {return Header().KURUMKODU;} }
            public TTReportField ICD10KOD { get {return Header().ICD10KOD;} }
            public TTReportField ICD10 { get {return Header().ICD10;} }
            public TTReportField TARIH1 { get {return Header().TARIH1;} }
            public TTReportField BRANS { get {return Header().BRANS;} }
            public TTReportField HASTATIP { get {return Header().HASTATIP;} }
            public TTReportField FATURANO { get {return Header().FATURANO;} }
            public TTReportField CINSIYET { get {return Header().CINSIYET;} }
            public TTReportField PROVIZYONNO { get {return Header().PROVIZYONNO;} }
            public TTReportField HASTATURU { get {return Header().HASTATURU;} }
            public TTReportField EPISODE { get {return Header().EPISODE;} }
            public TTReportField PATIENT { get {return Header().PATIENT;} }
            public TTReportField TARIH2LBL { get {return Header().TARIH2LBL;} }
            public TTReportField TARIH2 { get {return Header().TARIH2;} }
            public TTReportField OPENINGDATE { get {return Header().OPENINGDATE;} }
            public TTReportField QUARANTINEINPATIENTDATE { get {return Header().QUARANTINEINPATIENTDATE;} }
            public TTReportField NewField1411121 { get {return Header().NewField1411121;} }
            public TTReportField NewField11111121 { get {return Header().NewField11111121;} }
            public TTReportField EVTELEFONU { get {return Header().EVTELEFONU;} }
            public TTReportField NewField1711121 { get {return Header().NewField1711121;} }
            public TTReportField NewField12111121 { get {return Header().NewField12111121;} }
            public TTReportField EVADRESI { get {return Header().EVADRESI;} }
            public TTReportField GAZISICILNOLABEL { get {return Header().GAZISICILNOLABEL;} }
            public TTReportField GAZISICILNOLABEL2 { get {return Header().GAZISICILNOLABEL2;} }
            public TTReportField GAZISICILNO { get {return Header().GAZISICILNO;} }
            public TTReportField QUARANTINEDISCHARGEDATE { get {return Header().QUARANTINEDISCHARGEDATE;} }
            public TTReportShape HEADERLINE1 { get {return Header().HEADERLINE1;} }
            public TTReportField TOPLAMFIYATLBL1 { get {return Header().TOPLAMFIYATLBL1;} }
            public TTReportField BIRIMFIYATLBL1 { get {return Header().BIRIMFIYATLBL1;} }
            public TTReportField HIZMETADILBL1 { get {return Header().HIZMETADILBL1;} }
            public TTReportField ADETLBL1 { get {return Header().ADETLBL1;} }
            public TTReportField TARIHLBL1 { get {return Header().TARIHLBL1;} }
            public TTReportShape HEADERLINE2 { get {return Header().HEADERLINE2;} }
            public TTReportField TOPLAMFIYATLBL2 { get {return Header().TOPLAMFIYATLBL2;} }
            public TTReportField BIRIMFIYATLBL2 { get {return Header().BIRIMFIYATLBL2;} }
            public TTReportField HIZMETADILBL2 { get {return Header().HIZMETADILBL2;} }
            public TTReportField ADETLBL2 { get {return Header().ADETLBL2;} }
            public TTReportField TARIHLBL2 { get {return Header().TARIHLBL2;} }
            public TTReportField DIS18 { get {return Header().DIS18;} }
            public TTReportField DIS18LBL { get {return Header().DIS18LBL;} }
            public TTReportField DIS17 { get {return Header().DIS17;} }
            public TTReportField DIS17LBL { get {return Header().DIS17LBL;} }
            public TTReportField DIS16 { get {return Header().DIS16;} }
            public TTReportField DIS16LBL { get {return Header().DIS16LBL;} }
            public TTReportField DIS15 { get {return Header().DIS15;} }
            public TTReportField DIS15LBL { get {return Header().DIS15LBL;} }
            public TTReportField DIS14 { get {return Header().DIS14;} }
            public TTReportField DIS14LBL { get {return Header().DIS14LBL;} }
            public TTReportField DIS13 { get {return Header().DIS13;} }
            public TTReportField DIS13LBL { get {return Header().DIS13LBL;} }
            public TTReportField DIS12 { get {return Header().DIS12;} }
            public TTReportField DIS12LBL { get {return Header().DIS12LBL;} }
            public TTReportField DIS11 { get {return Header().DIS11;} }
            public TTReportField DIS11LBL { get {return Header().DIS11LBL;} }
            public TTReportField DIS55 { get {return Header().DIS55;} }
            public TTReportField DIS55LBL { get {return Header().DIS55LBL;} }
            public TTReportField DIS54 { get {return Header().DIS54;} }
            public TTReportField DIS54LBL { get {return Header().DIS54LBL;} }
            public TTReportField DIS53 { get {return Header().DIS53;} }
            public TTReportField DIS53LBL { get {return Header().DIS53LBL;} }
            public TTReportField DIS52 { get {return Header().DIS52;} }
            public TTReportField DIS52LBL { get {return Header().DIS52LBL;} }
            public TTReportField DIS51 { get {return Header().DIS51;} }
            public TTReportField DIS51LBL { get {return Header().DIS51LBL;} }
            public TTReportShape DISLINE1 { get {return Header().DISLINE1;} }
            public TTReportShape DISLINE2 { get {return Header().DISLINE2;} }
            public TTReportField DIS48 { get {return Header().DIS48;} }
            public TTReportField DIS48LBL { get {return Header().DIS48LBL;} }
            public TTReportField DIS47 { get {return Header().DIS47;} }
            public TTReportField DIS47LBL { get {return Header().DIS47LBL;} }
            public TTReportField DIS46 { get {return Header().DIS46;} }
            public TTReportField DIS46LBL { get {return Header().DIS46LBL;} }
            public TTReportField DIS45 { get {return Header().DIS45;} }
            public TTReportField DIS45LBL { get {return Header().DIS45LBL;} }
            public TTReportField DIS44 { get {return Header().DIS44;} }
            public TTReportField DIS44LBL { get {return Header().DIS44LBL;} }
            public TTReportField DIS43 { get {return Header().DIS43;} }
            public TTReportField DIS43LBL { get {return Header().DIS43LBL;} }
            public TTReportField DIS42 { get {return Header().DIS42;} }
            public TTReportField DIS42LBL { get {return Header().DIS42LBL;} }
            public TTReportField DIS41 { get {return Header().DIS41;} }
            public TTReportField DIS41LBL { get {return Header().DIS41LBL;} }
            public TTReportField DIS85 { get {return Header().DIS85;} }
            public TTReportField DIS85LBL { get {return Header().DIS85LBL;} }
            public TTReportField DIS84 { get {return Header().DIS84;} }
            public TTReportField DIS84LBL { get {return Header().DIS84LBL;} }
            public TTReportField DIS83 { get {return Header().DIS83;} }
            public TTReportField DIS83LBL { get {return Header().DIS83LBL;} }
            public TTReportField DIS82 { get {return Header().DIS82;} }
            public TTReportField DIS82LBL { get {return Header().DIS82LBL;} }
            public TTReportField DIS81 { get {return Header().DIS81;} }
            public TTReportField DIS81LBL { get {return Header().DIS81LBL;} }
            public TTReportField DIS21 { get {return Header().DIS21;} }
            public TTReportField DIS21LBL { get {return Header().DIS21LBL;} }
            public TTReportField DIS22 { get {return Header().DIS22;} }
            public TTReportField DIS22LBL { get {return Header().DIS22LBL;} }
            public TTReportField DIS23 { get {return Header().DIS23;} }
            public TTReportField DIS23LBL { get {return Header().DIS23LBL;} }
            public TTReportField DIS24 { get {return Header().DIS24;} }
            public TTReportField DIS24LBL { get {return Header().DIS24LBL;} }
            public TTReportField DIS25 { get {return Header().DIS25;} }
            public TTReportField DIS25LBL { get {return Header().DIS25LBL;} }
            public TTReportField DIS26 { get {return Header().DIS26;} }
            public TTReportField DIS26LBL { get {return Header().DIS26LBL;} }
            public TTReportField DIS27 { get {return Header().DIS27;} }
            public TTReportField DIS27LBL { get {return Header().DIS27LBL;} }
            public TTReportField DIS28 { get {return Header().DIS28;} }
            public TTReportField DIS28LBL { get {return Header().DIS28LBL;} }
            public TTReportField DIS61 { get {return Header().DIS61;} }
            public TTReportField DIS61LBL { get {return Header().DIS61LBL;} }
            public TTReportField DIS62 { get {return Header().DIS62;} }
            public TTReportField DIS62LBL { get {return Header().DIS62LBL;} }
            public TTReportField DIS63 { get {return Header().DIS63;} }
            public TTReportField DIS63LBL { get {return Header().DIS63LBL;} }
            public TTReportField DIS64 { get {return Header().DIS64;} }
            public TTReportField DIS64LBL { get {return Header().DIS64LBL;} }
            public TTReportField DIS65 { get {return Header().DIS65;} }
            public TTReportField DIS65LBL { get {return Header().DIS65LBL;} }
            public TTReportField DIS31 { get {return Header().DIS31;} }
            public TTReportField DIS31LBL { get {return Header().DIS31LBL;} }
            public TTReportField DIS32 { get {return Header().DIS32;} }
            public TTReportField DIS32LBL { get {return Header().DIS32LBL;} }
            public TTReportField DIS33 { get {return Header().DIS33;} }
            public TTReportField DIS33LBL { get {return Header().DIS33LBL;} }
            public TTReportField DIS34 { get {return Header().DIS34;} }
            public TTReportField DIS34LBL { get {return Header().DIS34LBL;} }
            public TTReportField DIS35 { get {return Header().DIS35;} }
            public TTReportField DIS35LBL { get {return Header().DIS35LBL;} }
            public TTReportField DIS36 { get {return Header().DIS36;} }
            public TTReportField DIS36LBL { get {return Header().DIS36LBL;} }
            public TTReportField DIS37 { get {return Header().DIS37;} }
            public TTReportField DIS37LBL { get {return Header().DIS37LBL;} }
            public TTReportField DIS38 { get {return Header().DIS38;} }
            public TTReportField DIS38LBL { get {return Header().DIS38LBL;} }
            public TTReportField DIS71 { get {return Header().DIS71;} }
            public TTReportField DIS71LBL { get {return Header().DIS71LBL;} }
            public TTReportField DIS72 { get {return Header().DIS72;} }
            public TTReportField DIS72LBL { get {return Header().DIS72LBL;} }
            public TTReportField DIS73 { get {return Header().DIS73;} }
            public TTReportField DIS73LBL { get {return Header().DIS73LBL;} }
            public TTReportField DIS74 { get {return Header().DIS74;} }
            public TTReportField DIS74LBL { get {return Header().DIS74LBL;} }
            public TTReportField DIS75 { get {return Header().DIS75;} }
            public TTReportField DIS75LBL { get {return Header().DIS75LBL;} }
            public TTReportField SAGUSTCENELBL { get {return Header().SAGUSTCENELBL;} }
            public TTReportField SOLUSTCENELBL { get {return Header().SOLUSTCENELBL;} }
            public TTReportField SAGALTCENELBL { get {return Header().SAGALTCENELBL;} }
            public TTReportField SOLALTCENELBL { get {return Header().SOLALTCENELBL;} }
            public TTReportField DOKTORLBL1 { get {return Header().DOKTORLBL1;} }
            public TTReportField DOKTORLBL2 { get {return Header().DOKTORLBL2;} }
            public TTReportField DOKTOR { get {return Header().DOKTOR;} }
            public TTReportField HASTADURUMU { get {return Header().HASTADURUMU;} }
            public TTReportField TOPLAMFIYAT { get {return Footer().TOPLAMFIYAT;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public TTReportField NewField11116111 { get {return Footer().NewField11116111;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class>("CollectedInvoiceProcDetPreviewReportQuery2", AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2((List<string>) MyParentReport.RuntimeParameters.PAYERS,(List<string>) MyParentReport.RuntimeParameters.RESOURCES,(List<string>) MyParentReport.RuntimeParameters.RESOURCESFILTER,(List<string>) MyParentReport.RuntimeParameters.EPISODES,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PATIENTSTATUS)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public CollectedInvoiceProcDetPrvReport_NoCheck_2 MyParentReport
                {
                    get { return (CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport; }
                }
                
                public TTReportField NewField1101;
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField HASTAADI;
                public TTReportField TCKIMLIKNO;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField12111;
                public TTReportField HASTASIRANO;
                public TTReportField NewField121111;
                public TTReportField NewField111121;
                public TTReportField YAS;
                public TTReportField NewField1111121;
                public TTReportField NewField121121;
                public TTReportField NewField1211121;
                public TTReportField SAYFANO;
                public TTReportField NewField1121121;
                public TTReportField NewField11211121;
                public TTReportField NewField111122;
                public TTReportField NewField121112;
                public TTReportField NewField121113;
                public TTReportField TARIH1LBL;
                public TTReportField NewField121115;
                public TTReportField NewField121116;
                public TTReportField NewField1611121;
                public TTReportField NewField1111111;
                public TTReportField NewField1111122;
                public TTReportField NewField11211111;
                public TTReportField NewField111113;
                public TTReportField NewField1111112;
                public TTReportField NewField1111123;
                public TTReportField NewField11211112;
                public TTReportField NewField1121123;
                public TTReportField NewField11211123;
                public TTReportField NewField1121124;
                public TTReportField NewField11211124;
                public TTReportField KURUMADI;
                public TTReportField HOSPITALPROTOCOLNO;
                public TTReportField KURUMKODU;
                public TTReportField ICD10KOD;
                public TTReportField ICD10;
                public TTReportField TARIH1;
                public TTReportField BRANS;
                public TTReportField HASTATIP;
                public TTReportField FATURANO;
                public TTReportField CINSIYET;
                public TTReportField PROVIZYONNO;
                public TTReportField HASTATURU;
                public TTReportField EPISODE;
                public TTReportField PATIENT;
                public TTReportField TARIH2LBL;
                public TTReportField TARIH2;
                public TTReportField OPENINGDATE;
                public TTReportField QUARANTINEINPATIENTDATE;
                public TTReportField NewField1411121;
                public TTReportField NewField11111121;
                public TTReportField EVTELEFONU;
                public TTReportField NewField1711121;
                public TTReportField NewField12111121;
                public TTReportField EVADRESI;
                public TTReportField GAZISICILNOLABEL;
                public TTReportField GAZISICILNOLABEL2;
                public TTReportField GAZISICILNO;
                public TTReportField QUARANTINEDISCHARGEDATE;
                public TTReportShape HEADERLINE1;
                public TTReportField TOPLAMFIYATLBL1;
                public TTReportField BIRIMFIYATLBL1;
                public TTReportField HIZMETADILBL1;
                public TTReportField ADETLBL1;
                public TTReportField TARIHLBL1;
                public TTReportShape HEADERLINE2;
                public TTReportField TOPLAMFIYATLBL2;
                public TTReportField BIRIMFIYATLBL2;
                public TTReportField HIZMETADILBL2;
                public TTReportField ADETLBL2;
                public TTReportField TARIHLBL2;
                public TTReportField DIS18;
                public TTReportField DIS18LBL;
                public TTReportField DIS17;
                public TTReportField DIS17LBL;
                public TTReportField DIS16;
                public TTReportField DIS16LBL;
                public TTReportField DIS15;
                public TTReportField DIS15LBL;
                public TTReportField DIS14;
                public TTReportField DIS14LBL;
                public TTReportField DIS13;
                public TTReportField DIS13LBL;
                public TTReportField DIS12;
                public TTReportField DIS12LBL;
                public TTReportField DIS11;
                public TTReportField DIS11LBL;
                public TTReportField DIS55;
                public TTReportField DIS55LBL;
                public TTReportField DIS54;
                public TTReportField DIS54LBL;
                public TTReportField DIS53;
                public TTReportField DIS53LBL;
                public TTReportField DIS52;
                public TTReportField DIS52LBL;
                public TTReportField DIS51;
                public TTReportField DIS51LBL;
                public TTReportShape DISLINE1;
                public TTReportShape DISLINE2;
                public TTReportField DIS48;
                public TTReportField DIS48LBL;
                public TTReportField DIS47;
                public TTReportField DIS47LBL;
                public TTReportField DIS46;
                public TTReportField DIS46LBL;
                public TTReportField DIS45;
                public TTReportField DIS45LBL;
                public TTReportField DIS44;
                public TTReportField DIS44LBL;
                public TTReportField DIS43;
                public TTReportField DIS43LBL;
                public TTReportField DIS42;
                public TTReportField DIS42LBL;
                public TTReportField DIS41;
                public TTReportField DIS41LBL;
                public TTReportField DIS85;
                public TTReportField DIS85LBL;
                public TTReportField DIS84;
                public TTReportField DIS84LBL;
                public TTReportField DIS83;
                public TTReportField DIS83LBL;
                public TTReportField DIS82;
                public TTReportField DIS82LBL;
                public TTReportField DIS81;
                public TTReportField DIS81LBL;
                public TTReportField DIS21;
                public TTReportField DIS21LBL;
                public TTReportField DIS22;
                public TTReportField DIS22LBL;
                public TTReportField DIS23;
                public TTReportField DIS23LBL;
                public TTReportField DIS24;
                public TTReportField DIS24LBL;
                public TTReportField DIS25;
                public TTReportField DIS25LBL;
                public TTReportField DIS26;
                public TTReportField DIS26LBL;
                public TTReportField DIS27;
                public TTReportField DIS27LBL;
                public TTReportField DIS28;
                public TTReportField DIS28LBL;
                public TTReportField DIS61;
                public TTReportField DIS61LBL;
                public TTReportField DIS62;
                public TTReportField DIS62LBL;
                public TTReportField DIS63;
                public TTReportField DIS63LBL;
                public TTReportField DIS64;
                public TTReportField DIS64LBL;
                public TTReportField DIS65;
                public TTReportField DIS65LBL;
                public TTReportField DIS31;
                public TTReportField DIS31LBL;
                public TTReportField DIS32;
                public TTReportField DIS32LBL;
                public TTReportField DIS33;
                public TTReportField DIS33LBL;
                public TTReportField DIS34;
                public TTReportField DIS34LBL;
                public TTReportField DIS35;
                public TTReportField DIS35LBL;
                public TTReportField DIS36;
                public TTReportField DIS36LBL;
                public TTReportField DIS37;
                public TTReportField DIS37LBL;
                public TTReportField DIS38;
                public TTReportField DIS38LBL;
                public TTReportField DIS71;
                public TTReportField DIS71LBL;
                public TTReportField DIS72;
                public TTReportField DIS72LBL;
                public TTReportField DIS73;
                public TTReportField DIS73LBL;
                public TTReportField DIS74;
                public TTReportField DIS74LBL;
                public TTReportField DIS75;
                public TTReportField DIS75LBL;
                public TTReportField SAGUSTCENELBL;
                public TTReportField SOLUSTCENELBL;
                public TTReportField SAGALTCENELBL;
                public TTReportField SOLALTCENELBL;
                public TTReportField DOKTORLBL1;
                public TTReportField DOKTORLBL2;
                public TTReportField DOKTOR;
                public TTReportField HASTADURUMU; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 142;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 12, 197, 17, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1101.TextFont.Name = "Arial";
                    NewField1101.TextFont.Size = 9;
                    NewField1101.TextFont.Bold = true;
                    NewField1101.TextFont.Underline = true;
                    NewField1101.TextFont.CharSet = 162;
                    NewField1101.Value = @"HİZMET DETAY BİLGİSİ ÖNDÖKÜMÜ";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 24, 33, 28, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Hasta Adı";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 29, 33, 33, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"TC Kimlik No";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 24, 107, 28, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HASTAADI.TextFont.Name = "Arial";
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#PATIENTNAME#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 29, 107, 33, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 24, 35, 28, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 8;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @":";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 29, 35, 33, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Size = 8;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @":";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 19, 33, 23, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.TextFont.Name = "Arial";
                    NewField12111.TextFont.Size = 8;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @"Hasta Sıra No";

                    HASTASIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 19, 107, 23, false);
                    HASTASIRANO.Name = "HASTASIRANO";
                    HASTASIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASIRANO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HASTASIRANO.TextFont.Name = "Arial";
                    HASTASIRANO.TextFont.Size = 8;
                    HASTASIRANO.TextFont.CharSet = 162;
                    HASTASIRANO.Value = @"{@groupcounter@}";

                    NewField121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 19, 35, 23, false);
                    NewField121111.Name = "NewField121111";
                    NewField121111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121111.TextFont.Name = "Arial";
                    NewField121111.TextFont.Size = 8;
                    NewField121111.TextFont.Bold = true;
                    NewField121111.TextFont.CharSet = 162;
                    NewField121111.Value = @":";

                    NewField111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 34, 33, 38, false);
                    NewField111121.Name = "NewField111121";
                    NewField111121.TextFont.Name = "Arial";
                    NewField111121.TextFont.Size = 8;
                    NewField111121.TextFont.Bold = true;
                    NewField111121.TextFont.CharSet = 162;
                    NewField111121.Value = @"Yaşı";

                    YAS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 34, 107, 38, false);
                    YAS.Name = "YAS";
                    YAS.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    YAS.TextFont.Name = "Arial";
                    YAS.TextFont.Size = 8;
                    YAS.TextFont.CharSet = 162;
                    YAS.Value = @"";

                    NewField1111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 34, 35, 38, false);
                    NewField1111121.Name = "NewField1111121";
                    NewField1111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111121.TextFont.Name = "Arial";
                    NewField1111121.TextFont.Size = 8;
                    NewField1111121.TextFont.Bold = true;
                    NewField1111121.TextFont.CharSet = 162;
                    NewField1111121.Value = @":";

                    NewField121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 24, 147, 28, false);
                    NewField121121.Name = "NewField121121";
                    NewField121121.TextFont.Name = "Arial";
                    NewField121121.TextFont.Size = 8;
                    NewField121121.TextFont.Bold = true;
                    NewField121121.TextFont.CharSet = 162;
                    NewField121121.Value = @"Fatura No";

                    NewField1211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 24, 149, 28, false);
                    NewField1211121.Name = "NewField1211121";
                    NewField1211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211121.TextFont.Name = "Arial";
                    NewField1211121.TextFont.Size = 8;
                    NewField1211121.TextFont.Bold = true;
                    NewField1211121.TextFont.CharSet = 162;
                    NewField1211121.Value = @":";

                    SAYFANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 19, 190, 23, false);
                    SAYFANO.Name = "SAYFANO";
                    SAYFANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYFANO.TextFont.Name = "Arial";
                    SAYFANO.TextFont.Size = 8;
                    SAYFANO.TextFont.CharSet = 162;
                    SAYFANO.Value = @"{@pagenumber@}";

                    NewField1121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 19, 147, 23, false);
                    NewField1121121.Name = "NewField1121121";
                    NewField1121121.TextFont.Name = "Arial";
                    NewField1121121.TextFont.Size = 8;
                    NewField1121121.TextFont.Bold = true;
                    NewField1121121.TextFont.CharSet = 162;
                    NewField1121121.Value = @"Sayfa No";

                    NewField11211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 19, 149, 23, false);
                    NewField11211121.Name = "NewField11211121";
                    NewField11211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211121.TextFont.Name = "Arial";
                    NewField11211121.TextFont.Size = 8;
                    NewField11211121.TextFont.Bold = true;
                    NewField11211121.TextFont.CharSet = 162;
                    NewField11211121.Value = @":";

                    NewField111122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 39, 33, 43, false);
                    NewField111122.Name = "NewField111122";
                    NewField111122.TextFont.Name = "Arial";
                    NewField111122.TextFont.Size = 8;
                    NewField111122.TextFont.Bold = true;
                    NewField111122.TextFont.CharSet = 162;
                    NewField111122.Value = @"H.Protokol No";

                    NewField121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 54, 33, 58, false);
                    NewField121112.Name = "NewField121112";
                    NewField121112.TextFont.Name = "Arial";
                    NewField121112.TextFont.Size = 8;
                    NewField121112.TextFont.Bold = true;
                    NewField121112.TextFont.CharSet = 162;
                    NewField121112.Value = @"Kurum Adı";

                    NewField121113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 59, 33, 63, false);
                    NewField121113.Name = "NewField121113";
                    NewField121113.TextFont.Name = "Arial";
                    NewField121113.TextFont.Size = 8;
                    NewField121113.TextFont.Bold = true;
                    NewField121113.TextFont.CharSet = 162;
                    NewField121113.Value = @"Kurum Kodu";

                    TARIH1LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 64, 34, 68, false);
                    TARIH1LBL.Name = "TARIH1LBL";
                    TARIH1LBL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH1LBL.TextFont.Name = "Arial";
                    TARIH1LBL.TextFont.Size = 8;
                    TARIH1LBL.TextFont.Bold = true;
                    TARIH1LBL.TextFont.CharSet = 162;
                    TARIH1LBL.Value = @"";

                    NewField121115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 69, 33, 73, false);
                    NewField121115.Name = "NewField121115";
                    NewField121115.TextFont.Name = "Arial";
                    NewField121115.TextFont.Size = 8;
                    NewField121115.TextFont.Bold = true;
                    NewField121115.TextFont.CharSet = 162;
                    NewField121115.Value = @"ICD10 Kodu";

                    NewField121116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 74, 33, 78, false);
                    NewField121116.Name = "NewField121116";
                    NewField121116.TextFont.Name = "Arial";
                    NewField121116.TextFont.Size = 8;
                    NewField121116.TextFont.Bold = true;
                    NewField121116.TextFont.CharSet = 162;
                    NewField121116.Value = @"ICD10 Açıklama";

                    NewField1611121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 85, 33, 89, false);
                    NewField1611121.Name = "NewField1611121";
                    NewField1611121.TextFont.Name = "Arial";
                    NewField1611121.TextFont.Size = 8;
                    NewField1611121.TextFont.Bold = true;
                    NewField1611121.TextFont.CharSet = 162;
                    NewField1611121.Value = @"Bölüm";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 54, 35, 58, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.TextFont.Name = "Arial";
                    NewField1111111.TextFont.Size = 8;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @":";

                    NewField1111122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 39, 35, 43, false);
                    NewField1111122.Name = "NewField1111122";
                    NewField1111122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111122.TextFont.Name = "Arial";
                    NewField1111122.TextFont.Size = 8;
                    NewField1111122.TextFont.Bold = true;
                    NewField1111122.TextFont.CharSet = 162;
                    NewField1111122.Value = @":";

                    NewField11211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 59, 35, 63, false);
                    NewField11211111.Name = "NewField11211111";
                    NewField11211111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211111.TextFont.Name = "Arial";
                    NewField11211111.TextFont.Size = 8;
                    NewField11211111.TextFont.Bold = true;
                    NewField11211111.TextFont.CharSet = 162;
                    NewField11211111.Value = @":";

                    NewField111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 69, 35, 73, false);
                    NewField111113.Name = "NewField111113";
                    NewField111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111113.TextFont.Name = "Arial";
                    NewField111113.TextFont.Size = 8;
                    NewField111113.TextFont.Bold = true;
                    NewField111113.TextFont.CharSet = 162;
                    NewField111113.Value = @":";

                    NewField1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 74, 35, 78, false);
                    NewField1111112.Name = "NewField1111112";
                    NewField1111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111112.TextFont.Name = "Arial";
                    NewField1111112.TextFont.Size = 8;
                    NewField1111112.TextFont.Bold = true;
                    NewField1111112.TextFont.CharSet = 162;
                    NewField1111112.Value = @":";

                    NewField1111123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 64, 35, 68, false);
                    NewField1111123.Name = "NewField1111123";
                    NewField1111123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111123.TextFont.Name = "Arial";
                    NewField1111123.TextFont.Size = 8;
                    NewField1111123.TextFont.Bold = true;
                    NewField1111123.TextFont.CharSet = 162;
                    NewField1111123.Value = @":";

                    NewField11211112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 85, 35, 89, false);
                    NewField11211112.Name = "NewField11211112";
                    NewField11211112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211112.TextFont.Name = "Arial";
                    NewField11211112.TextFont.Size = 8;
                    NewField11211112.TextFont.Bold = true;
                    NewField11211112.TextFont.CharSet = 162;
                    NewField11211112.Value = @":";

                    NewField1121123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 29, 147, 33, false);
                    NewField1121123.Name = "NewField1121123";
                    NewField1121123.TextFont.Name = "Arial";
                    NewField1121123.TextFont.Size = 8;
                    NewField1121123.TextFont.Bold = true;
                    NewField1121123.TextFont.CharSet = 162;
                    NewField1121123.Value = @"Cinsiyet";

                    NewField11211123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 29, 149, 33, false);
                    NewField11211123.Name = "NewField11211123";
                    NewField11211123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211123.TextFont.Name = "Arial";
                    NewField11211123.TextFont.Size = 8;
                    NewField11211123.TextFont.Bold = true;
                    NewField11211123.TextFont.CharSet = 162;
                    NewField11211123.Value = @":";

                    NewField1121124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 34, 147, 38, false);
                    NewField1121124.Name = "NewField1121124";
                    NewField1121124.TextFont.Name = "Arial";
                    NewField1121124.TextFont.Size = 8;
                    NewField1121124.TextFont.Bold = true;
                    NewField1121124.TextFont.CharSet = 162;
                    NewField1121124.Value = @"Provizyon No";

                    NewField11211124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 34, 149, 38, false);
                    NewField11211124.Name = "NewField11211124";
                    NewField11211124.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211124.TextFont.Name = "Arial";
                    NewField11211124.TextFont.Size = 8;
                    NewField11211124.TextFont.Bold = true;
                    NewField11211124.TextFont.CharSet = 162;
                    NewField11211124.Value = @":";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 54, 197, 58, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KURUMADI.TextFont.Name = "Arial";
                    KURUMADI.TextFont.Size = 8;
                    KURUMADI.TextFont.CharSet = 162;
                    KURUMADI.Value = @"{#PAYERNAME#}";

                    HOSPITALPROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 39, 107, 43, false);
                    HOSPITALPROTOCOLNO.Name = "HOSPITALPROTOCOLNO";
                    HOSPITALPROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPITALPROTOCOLNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPITALPROTOCOLNO.TextFont.Name = "Arial";
                    HOSPITALPROTOCOLNO.TextFont.Size = 8;
                    HOSPITALPROTOCOLNO.TextFont.CharSet = 162;
                    HOSPITALPROTOCOLNO.Value = @"{#HOSPITALPROTOCOLNO#}";

                    KURUMKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 59, 107, 63, false);
                    KURUMKODU.Name = "KURUMKODU";
                    KURUMKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMKODU.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KURUMKODU.TextFont.Name = "Arial";
                    KURUMKODU.TextFont.Size = 8;
                    KURUMKODU.TextFont.CharSet = 162;
                    KURUMKODU.Value = @"{#PAYERCODE#}";

                    ICD10KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 69, 197, 73, false);
                    ICD10KOD.Name = "ICD10KOD";
                    ICD10KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICD10KOD.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ICD10KOD.TextFont.Name = "Arial";
                    ICD10KOD.TextFont.Size = 8;
                    ICD10KOD.TextFont.CharSet = 162;
                    ICD10KOD.Value = @"";

                    ICD10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 74, 197, 84, false);
                    ICD10.Name = "ICD10";
                    ICD10.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICD10.MultiLine = EvetHayirEnum.ehEvet;
                    ICD10.WordBreak = EvetHayirEnum.ehEvet;
                    ICD10.TextFont.Name = "Arial";
                    ICD10.TextFont.Size = 8;
                    ICD10.TextFont.CharSet = 162;
                    ICD10.Value = @"";

                    TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 64, 107, 68, false);
                    TARIH1.Name = "TARIH1";
                    TARIH1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH1.TextFormat = @"Short Date";
                    TARIH1.TextFont.Name = "Arial";
                    TARIH1.TextFont.Size = 8;
                    TARIH1.TextFont.CharSet = 162;
                    TARIH1.Value = @"";

                    BRANS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 85, 197, 89, false);
                    BRANS.Name = "BRANS";
                    BRANS.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRANS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BRANS.TextFont.Name = "Arial";
                    BRANS.TextFont.Size = 8;
                    BRANS.TextFont.CharSet = 162;
                    BRANS.Value = @"{#SPECIALITYNAME#}";

                    HASTATIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 44, 190, 48, false);
                    HASTATIP.Name = "HASTATIP";
                    HASTATIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATIP.TextFormat = @"Short Date";
                    HASTATIP.TextFont.Name = "Arial";
                    HASTATIP.TextFont.Size = 8;
                    HASTATIP.TextFont.CharSet = 162;
                    HASTATIP.Value = @"";

                    FATURANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 24, 190, 28, false);
                    FATURANO.Name = "FATURANO";
                    FATURANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURANO.TextFont.Name = "Arial";
                    FATURANO.TextFont.Size = 8;
                    FATURANO.TextFont.CharSet = 162;
                    FATURANO.Value = @"{@DOCUMENTNO@}";

                    CINSIYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 29, 190, 33, false);
                    CINSIYET.Name = "CINSIYET";
                    CINSIYET.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYET.TextFont.Name = "Arial";
                    CINSIYET.TextFont.Size = 8;
                    CINSIYET.TextFont.CharSet = 162;
                    CINSIYET.Value = @"{#SEX#}";

                    PROVIZYONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 34, 190, 38, false);
                    PROVIZYONNO.Name = "PROVIZYONNO";
                    PROVIZYONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIZYONNO.TextFont.Name = "Arial";
                    PROVIZYONNO.TextFont.Size = 8;
                    PROVIZYONNO.TextFont.CharSet = 162;
                    PROVIZYONNO.Value = @"";

                    HASTATURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 15, 263, 19, false);
                    HASTATURU.Name = "HASTATURU";
                    HASTATURU.Visible = EvetHayirEnum.ehHayir;
                    HASTATURU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTATURU.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HASTATURU.TextFont.Name = "Arial";
                    HASTATURU.TextFont.Size = 8;
                    HASTATURU.TextFont.CharSet = 162;
                    HASTATURU.Value = @"{#PATIENTSTATUS#}";

                    EPISODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 21, 263, 25, false);
                    EPISODE.Name = "EPISODE";
                    EPISODE.Visible = EvetHayirEnum.ehHayir;
                    EPISODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODE.TextFont.Name = "Arial";
                    EPISODE.TextFont.Size = 8;
                    EPISODE.TextFont.CharSet = 162;
                    EPISODE.Value = @"{#EOBJID#}";

                    PATIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 27, 263, 31, false);
                    PATIENT.Name = "PATIENT";
                    PATIENT.Visible = EvetHayirEnum.ehHayir;
                    PATIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENT.TextFont.Name = "Arial";
                    PATIENT.TextFont.Size = 8;
                    PATIENT.TextFont.CharSet = 162;
                    PATIENT.Value = @"{#POBJID#}";

                    TARIH2LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 64, 149, 68, false);
                    TARIH2LBL.Name = "TARIH2LBL";
                    TARIH2LBL.TextFont.Name = "Arial";
                    TARIH2LBL.TextFont.Size = 8;
                    TARIH2LBL.TextFont.Bold = true;
                    TARIH2LBL.TextFont.CharSet = 162;
                    TARIH2LBL.Value = @"Taburcu Tarihi :";

                    TARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 64, 190, 68, false);
                    TARIH2.Name = "TARIH2";
                    TARIH2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH2.TextFormat = @"Short Date";
                    TARIH2.TextFont.Name = "Arial";
                    TARIH2.TextFont.Size = 8;
                    TARIH2.TextFont.CharSet = 162;
                    TARIH2.Value = @"";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 48, 263, 52, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.Visible = EvetHayirEnum.ehHayir;
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"Short Date";
                    OPENINGDATE.TextFont.Name = "Arial";
                    OPENINGDATE.TextFont.Size = 8;
                    OPENINGDATE.TextFont.CharSet = 162;
                    OPENINGDATE.Value = @"{#OPENINGDATE#}";

                    QUARANTINEINPATIENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 54, 263, 58, false);
                    QUARANTINEINPATIENTDATE.Name = "QUARANTINEINPATIENTDATE";
                    QUARANTINEINPATIENTDATE.Visible = EvetHayirEnum.ehHayir;
                    QUARANTINEINPATIENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEINPATIENTDATE.TextFormat = @"Short Date";
                    QUARANTINEINPATIENTDATE.TextFont.Name = "Arial";
                    QUARANTINEINPATIENTDATE.TextFont.Size = 8;
                    QUARANTINEINPATIENTDATE.TextFont.CharSet = 162;
                    QUARANTINEINPATIENTDATE.Value = @"{#HOSPITALINPATIENTDATE#}";

                    NewField1411121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 44, 33, 48, false);
                    NewField1411121.Name = "NewField1411121";
                    NewField1411121.TextFont.Name = "Arial";
                    NewField1411121.TextFont.Size = 8;
                    NewField1411121.TextFont.Bold = true;
                    NewField1411121.TextFont.CharSet = 162;
                    NewField1411121.Value = @"Ev Telefonu";

                    NewField11111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 44, 35, 48, false);
                    NewField11111121.Name = "NewField11111121";
                    NewField11111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111121.TextFont.Name = "Arial";
                    NewField11111121.TextFont.Size = 8;
                    NewField11111121.TextFont.Bold = true;
                    NewField11111121.TextFont.CharSet = 162;
                    NewField11111121.Value = @":";

                    EVTELEFONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 44, 107, 48, false);
                    EVTELEFONU.Name = "EVTELEFONU";
                    EVTELEFONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVTELEFONU.TextFont.Name = "Arial";
                    EVTELEFONU.TextFont.Size = 8;
                    EVTELEFONU.TextFont.CharSet = 162;
                    EVTELEFONU.Value = @"{#HOMEPHONE#}";

                    NewField1711121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 49, 33, 53, false);
                    NewField1711121.Name = "NewField1711121";
                    NewField1711121.TextFont.Name = "Arial";
                    NewField1711121.TextFont.Size = 8;
                    NewField1711121.TextFont.Bold = true;
                    NewField1711121.TextFont.CharSet = 162;
                    NewField1711121.Value = @"Ev Adresi";

                    NewField12111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 49, 35, 53, false);
                    NewField12111121.Name = "NewField12111121";
                    NewField12111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111121.TextFont.Name = "Arial";
                    NewField12111121.TextFont.Size = 8;
                    NewField12111121.TextFont.Bold = true;
                    NewField12111121.TextFont.CharSet = 162;
                    NewField12111121.Value = @":";

                    EVADRESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 49, 197, 53, false);
                    EVADRESI.Name = "EVADRESI";
                    EVADRESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVADRESI.TextFont.Name = "Arial";
                    EVADRESI.TextFont.Size = 8;
                    EVADRESI.TextFont.CharSet = 162;
                    EVADRESI.Value = @"{#HOMEADDRESS#} {#HOMECITY#}";

                    GAZISICILNOLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 39, 147, 43, false);
                    GAZISICILNOLABEL.Name = "GAZISICILNOLABEL";
                    GAZISICILNOLABEL.TextFont.Name = "Arial";
                    GAZISICILNOLABEL.TextFont.Size = 8;
                    GAZISICILNOLABEL.TextFont.Bold = true;
                    GAZISICILNOLABEL.TextFont.CharSet = 162;
                    GAZISICILNOLABEL.Value = @"Gazi Sicil No";

                    GAZISICILNOLABEL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 39, 149, 43, false);
                    GAZISICILNOLABEL2.Name = "GAZISICILNOLABEL2";
                    GAZISICILNOLABEL2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GAZISICILNOLABEL2.TextFont.Name = "Arial";
                    GAZISICILNOLABEL2.TextFont.Size = 8;
                    GAZISICILNOLABEL2.TextFont.Bold = true;
                    GAZISICILNOLABEL2.TextFont.CharSet = 162;
                    GAZISICILNOLABEL2.Value = @":";

                    GAZISICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 39, 190, 43, false);
                    GAZISICILNO.Name = "GAZISICILNO";
                    GAZISICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    GAZISICILNO.TextFont.Name = "Arial";
                    GAZISICILNO.TextFont.Size = 8;
                    GAZISICILNO.TextFont.CharSet = 162;
                    GAZISICILNO.Value = @"";

                    QUARANTINEDISCHARGEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 37, 263, 41, false);
                    QUARANTINEDISCHARGEDATE.Name = "QUARANTINEDISCHARGEDATE";
                    QUARANTINEDISCHARGEDATE.Visible = EvetHayirEnum.ehHayir;
                    QUARANTINEDISCHARGEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINEDISCHARGEDATE.TextFormat = @"Short Date";
                    QUARANTINEDISCHARGEDATE.TextFont.Name = "Arial";
                    QUARANTINEDISCHARGEDATE.TextFont.Size = 8;
                    QUARANTINEDISCHARGEDATE.TextFont.CharSet = 162;
                    QUARANTINEDISCHARGEDATE.Value = @"{#HOSPITALDISCHARGEDATE#}";

                    HEADERLINE1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 96, 197, 96, false);
                    HEADERLINE1.Name = "HEADERLINE1";
                    HEADERLINE1.DrawStyle = DrawStyleConstants.vbSolid;
                    HEADERLINE1.DrawWidth = 2;

                    TOPLAMFIYATLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 91, 197, 95, false);
                    TOPLAMFIYATLBL1.Name = "TOPLAMFIYATLBL1";
                    TOPLAMFIYATLBL1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMFIYATLBL1.TextFont.Name = "Arial";
                    TOPLAMFIYATLBL1.TextFont.Size = 8;
                    TOPLAMFIYATLBL1.TextFont.Bold = true;
                    TOPLAMFIYATLBL1.TextFont.CharSet = 162;
                    TOPLAMFIYATLBL1.Value = @"Toplam Fiyat";

                    BIRIMFIYATLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 91, 173, 95, false);
                    BIRIMFIYATLBL1.Name = "BIRIMFIYATLBL1";
                    BIRIMFIYATLBL1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BIRIMFIYATLBL1.TextFont.Name = "Arial";
                    BIRIMFIYATLBL1.TextFont.Size = 8;
                    BIRIMFIYATLBL1.TextFont.Bold = true;
                    BIRIMFIYATLBL1.TextFont.CharSet = 162;
                    BIRIMFIYATLBL1.Value = @"Birim Fiyat";

                    HIZMETADILBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 91, 143, 95, false);
                    HIZMETADILBL1.Name = "HIZMETADILBL1";
                    HIZMETADILBL1.TextFont.Name = "Arial";
                    HIZMETADILBL1.TextFont.Size = 8;
                    HIZMETADILBL1.TextFont.Bold = true;
                    HIZMETADILBL1.TextFont.CharSet = 162;
                    HIZMETADILBL1.Value = @"Hizmet Adı";

                    ADETLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 91, 153, 95, false);
                    ADETLBL1.Name = "ADETLBL1";
                    ADETLBL1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADETLBL1.TextFont.Name = "Arial";
                    ADETLBL1.TextFont.Size = 8;
                    ADETLBL1.TextFont.Bold = true;
                    ADETLBL1.TextFont.CharSet = 162;
                    ADETLBL1.Value = @"Adet";

                    TARIHLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 91, 27, 95, false);
                    TARIHLBL1.Name = "TARIHLBL1";
                    TARIHLBL1.TextFont.Name = "Arial";
                    TARIHLBL1.TextFont.Size = 8;
                    TARIHLBL1.TextFont.Bold = true;
                    TARIHLBL1.TextFont.CharSet = 162;
                    TARIHLBL1.Value = @"Tarih";

                    HEADERLINE2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 141, 197, 141, false);
                    HEADERLINE2.Name = "HEADERLINE2";
                    HEADERLINE2.DrawStyle = DrawStyleConstants.vbSolid;
                    HEADERLINE2.DrawWidth = 2;

                    TOPLAMFIYATLBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 136, 197, 140, false);
                    TOPLAMFIYATLBL2.Name = "TOPLAMFIYATLBL2";
                    TOPLAMFIYATLBL2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMFIYATLBL2.TextFont.Name = "Arial";
                    TOPLAMFIYATLBL2.TextFont.Size = 8;
                    TOPLAMFIYATLBL2.TextFont.Bold = true;
                    TOPLAMFIYATLBL2.TextFont.CharSet = 162;
                    TOPLAMFIYATLBL2.Value = @"Toplam Fiyat";

                    BIRIMFIYATLBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 136, 173, 140, false);
                    BIRIMFIYATLBL2.Name = "BIRIMFIYATLBL2";
                    BIRIMFIYATLBL2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BIRIMFIYATLBL2.TextFont.Name = "Arial";
                    BIRIMFIYATLBL2.TextFont.Size = 8;
                    BIRIMFIYATLBL2.TextFont.Bold = true;
                    BIRIMFIYATLBL2.TextFont.CharSet = 162;
                    BIRIMFIYATLBL2.Value = @"Birim Fiyat";

                    HIZMETADILBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 136, 143, 140, false);
                    HIZMETADILBL2.Name = "HIZMETADILBL2";
                    HIZMETADILBL2.TextFont.Name = "Arial";
                    HIZMETADILBL2.TextFont.Size = 8;
                    HIZMETADILBL2.TextFont.Bold = true;
                    HIZMETADILBL2.TextFont.CharSet = 162;
                    HIZMETADILBL2.Value = @"Hizmet Adı";

                    ADETLBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 136, 153, 140, false);
                    ADETLBL2.Name = "ADETLBL2";
                    ADETLBL2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADETLBL2.TextFont.Name = "Arial";
                    ADETLBL2.TextFont.Size = 8;
                    ADETLBL2.TextFont.Bold = true;
                    ADETLBL2.TextFont.CharSet = 162;
                    ADETLBL2.Value = @"Adet";

                    TARIHLBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 136, 27, 140, false);
                    TARIHLBL2.Name = "TARIHLBL2";
                    TARIHLBL2.TextFont.Name = "Arial";
                    TARIHLBL2.TextFont.Size = 8;
                    TARIHLBL2.TextFont.Bold = true;
                    TARIHLBL2.TextFont.CharSet = 162;
                    TARIHLBL2.Value = @"Tarih";

                    DIS18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 104, 24, 109, false);
                    DIS18.Name = "DIS18";
                    DIS18.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS18.Value = @"";

                    DIS18LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 104, 29, 109, false);
                    DIS18LBL.Name = "DIS18LBL";
                    DIS18LBL.Value = @"18";

                    DIS17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 104, 34, 109, false);
                    DIS17.Name = "DIS17";
                    DIS17.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS17.Value = @"";

                    DIS17LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 104, 39, 109, false);
                    DIS17LBL.Name = "DIS17LBL";
                    DIS17LBL.Value = @"17";

                    DIS16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 104, 44, 109, false);
                    DIS16.Name = "DIS16";
                    DIS16.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS16.Value = @"";

                    DIS16LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 104, 49, 109, false);
                    DIS16LBL.Name = "DIS16LBL";
                    DIS16LBL.Value = @"16";

                    DIS15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 104, 54, 109, false);
                    DIS15.Name = "DIS15";
                    DIS15.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS15.Value = @"";

                    DIS15LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 104, 59, 109, false);
                    DIS15LBL.Name = "DIS15LBL";
                    DIS15LBL.Value = @"15";

                    DIS14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 104, 64, 109, false);
                    DIS14.Name = "DIS14";
                    DIS14.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS14.Value = @"";

                    DIS14LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 104, 69, 109, false);
                    DIS14LBL.Name = "DIS14LBL";
                    DIS14LBL.Value = @"14";

                    DIS13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 104, 74, 109, false);
                    DIS13.Name = "DIS13";
                    DIS13.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS13.MultiLine = EvetHayirEnum.ehEvet;
                    DIS13.Value = @"";

                    DIS13LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 104, 79, 109, false);
                    DIS13LBL.Name = "DIS13LBL";
                    DIS13LBL.Value = @"13";

                    DIS12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 104, 84, 109, false);
                    DIS12.Name = "DIS12";
                    DIS12.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS12.Value = @"";

                    DIS12LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 104, 89, 109, false);
                    DIS12LBL.Name = "DIS12LBL";
                    DIS12LBL.Value = @"12";

                    DIS11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 104, 94, 109, false);
                    DIS11.Name = "DIS11";
                    DIS11.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS11.Value = @"";

                    DIS11LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 104, 99, 109, false);
                    DIS11LBL.Name = "DIS11LBL";
                    DIS11LBL.Value = @"11";

                    DIS55 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 110, 54, 115, false);
                    DIS55.Name = "DIS55";
                    DIS55.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS55.Value = @"";

                    DIS55LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 110, 59, 115, false);
                    DIS55LBL.Name = "DIS55LBL";
                    DIS55LBL.Value = @"55";

                    DIS54 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 110, 64, 115, false);
                    DIS54.Name = "DIS54";
                    DIS54.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS54.Value = @"";

                    DIS54LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 110, 69, 115, false);
                    DIS54LBL.Name = "DIS54LBL";
                    DIS54LBL.Value = @"54";

                    DIS53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 110, 74, 115, false);
                    DIS53.Name = "DIS53";
                    DIS53.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS53.Value = @"";

                    DIS53LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 110, 79, 115, false);
                    DIS53LBL.Name = "DIS53LBL";
                    DIS53LBL.Value = @"53";

                    DIS52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 110, 84, 115, false);
                    DIS52.Name = "DIS52";
                    DIS52.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS52.Value = @"";

                    DIS52LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 110, 89, 115, false);
                    DIS52LBL.Name = "DIS52LBL";
                    DIS52LBL.Value = @"52";

                    DIS51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 110, 94, 115, false);
                    DIS51.Name = "DIS51";
                    DIS51.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS51.Value = @"";

                    DIS51LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 110, 99, 115, false);
                    DIS51LBL.Name = "DIS51LBL";
                    DIS51LBL.Value = @"51";

                    DISLINE1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 99, 103, 134, false);
                    DISLINE1.Name = "DISLINE1";
                    DISLINE1.DrawStyle = DrawStyleConstants.vbSolid;

                    DISLINE2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 21, 116, 185, 116, false);
                    DISLINE2.Name = "DISLINE2";
                    DISLINE2.DrawStyle = DrawStyleConstants.vbSolid;

                    DIS48 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 129, 24, 134, false);
                    DIS48.Name = "DIS48";
                    DIS48.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS48.TextFont.CharSet = 162;
                    DIS48.Value = @"";

                    DIS48LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 129, 29, 134, false);
                    DIS48LBL.Name = "DIS48LBL";
                    DIS48LBL.Value = @"48";

                    DIS47 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 129, 33, 134, false);
                    DIS47.Name = "DIS47";
                    DIS47.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS47.TextFont.CharSet = 162;
                    DIS47.Value = @"";

                    DIS47LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 129, 39, 134, false);
                    DIS47LBL.Name = "DIS47LBL";
                    DIS47LBL.Value = @"47";

                    DIS46 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 129, 44, 134, false);
                    DIS46.Name = "DIS46";
                    DIS46.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS46.TextFont.CharSet = 162;
                    DIS46.Value = @"";

                    DIS46LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 129, 49, 134, false);
                    DIS46LBL.Name = "DIS46LBL";
                    DIS46LBL.Value = @"46";

                    DIS45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 129, 54, 134, false);
                    DIS45.Name = "DIS45";
                    DIS45.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS45.TextFont.CharSet = 162;
                    DIS45.Value = @"";

                    DIS45LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 129, 59, 134, false);
                    DIS45LBL.Name = "DIS45LBL";
                    DIS45LBL.Value = @"45";

                    DIS44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 129, 64, 134, false);
                    DIS44.Name = "DIS44";
                    DIS44.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS44.Value = @"";

                    DIS44LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 129, 69, 134, false);
                    DIS44LBL.Name = "DIS44LBL";
                    DIS44LBL.Value = @"44";

                    DIS43 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 129, 74, 134, false);
                    DIS43.Name = "DIS43";
                    DIS43.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS43.Value = @"";

                    DIS43LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 129, 79, 134, false);
                    DIS43LBL.Name = "DIS43LBL";
                    DIS43LBL.Value = @"43";

                    DIS42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 129, 84, 134, false);
                    DIS42.Name = "DIS42";
                    DIS42.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS42.Value = @"";

                    DIS42LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 129, 89, 134, false);
                    DIS42LBL.Name = "DIS42LBL";
                    DIS42LBL.Value = @"42";

                    DIS41 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 129, 94, 134, false);
                    DIS41.Name = "DIS41";
                    DIS41.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS41.Value = @"";

                    DIS41LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 129, 99, 134, false);
                    DIS41LBL.Name = "DIS41LBL";
                    DIS41LBL.Value = @"41";

                    DIS85 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 123, 54, 128, false);
                    DIS85.Name = "DIS85";
                    DIS85.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS85.Value = @"";

                    DIS85LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 123, 59, 128, false);
                    DIS85LBL.Name = "DIS85LBL";
                    DIS85LBL.Value = @"85";

                    DIS84 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 123, 64, 128, false);
                    DIS84.Name = "DIS84";
                    DIS84.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS84.Value = @"";

                    DIS84LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 123, 69, 128, false);
                    DIS84LBL.Name = "DIS84LBL";
                    DIS84LBL.Value = @"84";

                    DIS83 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 123, 74, 128, false);
                    DIS83.Name = "DIS83";
                    DIS83.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS83.Value = @"";

                    DIS83LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 123, 79, 128, false);
                    DIS83LBL.Name = "DIS83LBL";
                    DIS83LBL.Value = @"83";

                    DIS82 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 123, 84, 128, false);
                    DIS82.Name = "DIS82";
                    DIS82.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS82.Value = @"";

                    DIS82LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 123, 89, 128, false);
                    DIS82LBL.Name = "DIS82LBL";
                    DIS82LBL.Value = @"82";

                    DIS81 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 123, 94, 128, false);
                    DIS81.Name = "DIS81";
                    DIS81.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS81.Value = @"";

                    DIS81LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 123, 99, 128, false);
                    DIS81LBL.Name = "DIS81LBL";
                    DIS81LBL.Value = @"81";

                    DIS21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 104, 111, 109, false);
                    DIS21.Name = "DIS21";
                    DIS21.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS21.Value = @"";

                    DIS21LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 104, 116, 109, false);
                    DIS21LBL.Name = "DIS21LBL";
                    DIS21LBL.Value = @"21";

                    DIS22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 104, 121, 109, false);
                    DIS22.Name = "DIS22";
                    DIS22.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS22.Value = @"";

                    DIS22LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 104, 126, 109, false);
                    DIS22LBL.Name = "DIS22LBL";
                    DIS22LBL.Value = @"22";

                    DIS23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 104, 131, 109, false);
                    DIS23.Name = "DIS23";
                    DIS23.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS23.Value = @"";

                    DIS23LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 104, 136, 109, false);
                    DIS23LBL.Name = "DIS23LBL";
                    DIS23LBL.Value = @"23";

                    DIS24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 104, 141, 109, false);
                    DIS24.Name = "DIS24";
                    DIS24.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS24.Value = @"";

                    DIS24LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 104, 146, 109, false);
                    DIS24LBL.Name = "DIS24LBL";
                    DIS24LBL.Value = @"24";

                    DIS25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 104, 151, 109, false);
                    DIS25.Name = "DIS25";
                    DIS25.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS25.Value = @"";

                    DIS25LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 104, 156, 109, false);
                    DIS25LBL.Name = "DIS25LBL";
                    DIS25LBL.Value = @"25";

                    DIS26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 104, 161, 109, false);
                    DIS26.Name = "DIS26";
                    DIS26.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS26.Value = @"";

                    DIS26LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 104, 166, 109, false);
                    DIS26LBL.Name = "DIS26LBL";
                    DIS26LBL.Value = @"26";

                    DIS27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 104, 171, 109, false);
                    DIS27.Name = "DIS27";
                    DIS27.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS27.Value = @"";

                    DIS27LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 104, 176, 109, false);
                    DIS27LBL.Name = "DIS27LBL";
                    DIS27LBL.Value = @"27";

                    DIS28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 104, 181, 109, false);
                    DIS28.Name = "DIS28";
                    DIS28.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS28.Value = @"";

                    DIS28LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 104, 186, 109, false);
                    DIS28LBL.Name = "DIS28LBL";
                    DIS28LBL.Value = @"28";

                    DIS61 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 110, 111, 115, false);
                    DIS61.Name = "DIS61";
                    DIS61.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS61.Value = @"";

                    DIS61LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 110, 116, 115, false);
                    DIS61LBL.Name = "DIS61LBL";
                    DIS61LBL.Value = @"61";

                    DIS62 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 110, 121, 115, false);
                    DIS62.Name = "DIS62";
                    DIS62.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS62.Value = @"";

                    DIS62LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 110, 126, 115, false);
                    DIS62LBL.Name = "DIS62LBL";
                    DIS62LBL.Value = @"62";

                    DIS63 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 110, 131, 115, false);
                    DIS63.Name = "DIS63";
                    DIS63.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS63.Value = @"";

                    DIS63LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 110, 136, 115, false);
                    DIS63LBL.Name = "DIS63LBL";
                    DIS63LBL.Value = @"63";

                    DIS64 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 110, 141, 115, false);
                    DIS64.Name = "DIS64";
                    DIS64.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS64.Value = @"";

                    DIS64LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 110, 146, 115, false);
                    DIS64LBL.Name = "DIS64LBL";
                    DIS64LBL.Value = @"64";

                    DIS65 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 110, 151, 115, false);
                    DIS65.Name = "DIS65";
                    DIS65.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS65.Value = @"";

                    DIS65LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 110, 156, 115, false);
                    DIS65LBL.Name = "DIS65LBL";
                    DIS65LBL.Value = @"65";

                    DIS31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 129, 111, 134, false);
                    DIS31.Name = "DIS31";
                    DIS31.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS31.Value = @"";

                    DIS31LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 129, 116, 134, false);
                    DIS31LBL.Name = "DIS31LBL";
                    DIS31LBL.Value = @"31";

                    DIS32 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 129, 121, 134, false);
                    DIS32.Name = "DIS32";
                    DIS32.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS32.Value = @"";

                    DIS32LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 129, 126, 134, false);
                    DIS32LBL.Name = "DIS32LBL";
                    DIS32LBL.Value = @"32";

                    DIS33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 129, 131, 134, false);
                    DIS33.Name = "DIS33";
                    DIS33.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS33.Value = @"";

                    DIS33LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 129, 136, 134, false);
                    DIS33LBL.Name = "DIS33LBL";
                    DIS33LBL.Value = @"33";

                    DIS34 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 129, 141, 134, false);
                    DIS34.Name = "DIS34";
                    DIS34.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS34.Value = @"";

                    DIS34LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 129, 146, 134, false);
                    DIS34LBL.Name = "DIS34LBL";
                    DIS34LBL.Value = @"34";

                    DIS35 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 129, 151, 134, false);
                    DIS35.Name = "DIS35";
                    DIS35.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS35.Value = @"";

                    DIS35LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 129, 156, 134, false);
                    DIS35LBL.Name = "DIS35LBL";
                    DIS35LBL.Value = @"35";

                    DIS36 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 129, 161, 134, false);
                    DIS36.Name = "DIS36";
                    DIS36.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS36.Value = @"";

                    DIS36LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 129, 166, 134, false);
                    DIS36LBL.Name = "DIS36LBL";
                    DIS36LBL.Value = @"36";

                    DIS37 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 129, 171, 134, false);
                    DIS37.Name = "DIS37";
                    DIS37.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS37.Value = @"";

                    DIS37LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 129, 176, 134, false);
                    DIS37LBL.Name = "DIS37LBL";
                    DIS37LBL.Value = @"37";

                    DIS38 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 129, 181, 134, false);
                    DIS38.Name = "DIS38";
                    DIS38.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS38.Value = @"";

                    DIS38LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 129, 186, 134, false);
                    DIS38LBL.Name = "DIS38LBL";
                    DIS38LBL.Value = @"38";

                    DIS71 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 123, 111, 128, false);
                    DIS71.Name = "DIS71";
                    DIS71.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS71.Value = @"";

                    DIS71LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 123, 116, 128, false);
                    DIS71LBL.Name = "DIS71LBL";
                    DIS71LBL.Value = @"71";

                    DIS72 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 123, 121, 128, false);
                    DIS72.Name = "DIS72";
                    DIS72.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS72.Value = @"";

                    DIS72LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 123, 126, 128, false);
                    DIS72LBL.Name = "DIS72LBL";
                    DIS72LBL.Value = @"72";

                    DIS73 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 123, 131, 128, false);
                    DIS73.Name = "DIS73";
                    DIS73.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS73.Value = @"";

                    DIS73LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 123, 136, 128, false);
                    DIS73LBL.Name = "DIS73LBL";
                    DIS73LBL.Value = @"73";

                    DIS74 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 123, 141, 128, false);
                    DIS74.Name = "DIS74";
                    DIS74.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS74.Value = @"";

                    DIS74LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 123, 146, 128, false);
                    DIS74LBL.Name = "DIS74LBL";
                    DIS74LBL.Value = @"74";

                    DIS75 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 123, 151, 128, false);
                    DIS75.Name = "DIS75";
                    DIS75.DrawStyle = DrawStyleConstants.vbSolid;
                    DIS75.Value = @"";

                    DIS75LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 123, 156, 128, false);
                    DIS75LBL.Name = "DIS75LBL";
                    DIS75LBL.Value = @"75";

                    SAGUSTCENELBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 98, 99, 103, false);
                    SAGUSTCENELBL.Name = "SAGUSTCENELBL";
                    SAGUSTCENELBL.Value = @"Sağ Üst Çene";

                    SOLUSTCENELBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 98, 126, 103, false);
                    SOLUSTCENELBL.Name = "SOLUSTCENELBL";
                    SOLUSTCENELBL.Value = @"Sol Üst Çene";

                    SAGALTCENELBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 117, 99, 122, false);
                    SAGALTCENELBL.Name = "SAGALTCENELBL";
                    SAGALTCENELBL.Value = @"Sağ Alt Çene";

                    SOLALTCENELBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 117, 126, 122, false);
                    SOLALTCENELBL.Name = "SOLALTCENELBL";
                    SOLALTCENELBL.Value = @"Sol Alt Çene";

                    DOKTORLBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 59, 148, 63, false);
                    DOKTORLBL1.Name = "DOKTORLBL1";
                    DOKTORLBL1.TextFont.Name = "Arial";
                    DOKTORLBL1.TextFont.Size = 8;
                    DOKTORLBL1.TextFont.Bold = true;
                    DOKTORLBL1.TextFont.CharSet = 162;
                    DOKTORLBL1.Value = @"Doktor";

                    DOKTORLBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 59, 149, 63, false);
                    DOKTORLBL2.Name = "DOKTORLBL2";
                    DOKTORLBL2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOKTORLBL2.TextFont.Name = "Arial";
                    DOKTORLBL2.TextFont.Size = 8;
                    DOKTORLBL2.TextFont.Bold = true;
                    DOKTORLBL2.TextFont.CharSet = 162;
                    DOKTORLBL2.Value = @":";

                    DOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 59, 197, 63, false);
                    DOKTOR.Name = "DOKTOR";
                    DOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTOR.TextFont.Name = "Arial";
                    DOKTOR.TextFont.Size = 8;
                    DOKTOR.TextFont.CharSet = 162;
                    DOKTOR.Value = @"";

                    HASTADURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 9, 263, 13, false);
                    HASTADURUMU.Name = "HASTADURUMU";
                    HASTADURUMU.Visible = EvetHayirEnum.ehHayir;
                    HASTADURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTADURUMU.TextFont.Name = "Arial";
                    HASTADURUMU.TextFont.Size = 8;
                    HASTADURUMU.TextFont.CharSet = 162;
                    HASTADURUMU.Value = @"{@PATIENTSTATUS@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class dataset_CollectedInvoiceProcDetPreviewReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class>(0);
                    NewField1101.CalcValue = NewField1101.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    HASTAADI.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Patientname) : "");
                    TCKIMLIKNO.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.UniqueRefNo) : "");
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    HASTASIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    NewField121111.CalcValue = NewField121111.Value;
                    NewField111121.CalcValue = NewField111121.Value;
                    YAS.CalcValue = @"";
                    NewField1111121.CalcValue = NewField1111121.Value;
                    NewField121121.CalcValue = NewField121121.Value;
                    NewField1211121.CalcValue = NewField1211121.Value;
                    SAYFANO.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    NewField1121121.CalcValue = NewField1121121.Value;
                    NewField11211121.CalcValue = NewField11211121.Value;
                    NewField111122.CalcValue = NewField111122.Value;
                    NewField121112.CalcValue = NewField121112.Value;
                    NewField121113.CalcValue = NewField121113.Value;
                    TARIH1LBL.CalcValue = @"";
                    NewField121115.CalcValue = NewField121115.Value;
                    NewField121116.CalcValue = NewField121116.Value;
                    NewField1611121.CalcValue = NewField1611121.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField1111122.CalcValue = NewField1111122.Value;
                    NewField11211111.CalcValue = NewField11211111.Value;
                    NewField111113.CalcValue = NewField111113.Value;
                    NewField1111112.CalcValue = NewField1111112.Value;
                    NewField1111123.CalcValue = NewField1111123.Value;
                    NewField11211112.CalcValue = NewField11211112.Value;
                    NewField1121123.CalcValue = NewField1121123.Value;
                    NewField11211123.CalcValue = NewField11211123.Value;
                    NewField1121124.CalcValue = NewField1121124.Value;
                    NewField11211124.CalcValue = NewField11211124.Value;
                    KURUMADI.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Payername) : "");
                    HOSPITALPROTOCOLNO.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.HospitalProtocolNo) : "");
                    KURUMKODU.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Payercode) : "");
                    ICD10KOD.CalcValue = @"";
                    ICD10.CalcValue = @"";
                    TARIH1.CalcValue = @"";
                    BRANS.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Specialityname) : "");
                    HASTATIP.CalcValue = @"";
                    FATURANO.CalcValue = MyParentReport.RuntimeParameters.DOCUMENTNO.ToString();
                    CINSIYET.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Sex) : "");
                    PROVIZYONNO.CalcValue = @"";
                    HASTATURU.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.PatientStatus) : "");
                    EPISODE.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Eobjid) : "");
                    PATIENT.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Pobjid) : "");
                    TARIH2LBL.CalcValue = TARIH2LBL.Value;
                    TARIH2.CalcValue = @"";
                    OPENINGDATE.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.OpeningDate) : "");
                    QUARANTINEINPATIENTDATE.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.HospitalInPatientDate) : "");
                    NewField1411121.CalcValue = NewField1411121.Value;
                    NewField11111121.CalcValue = NewField11111121.Value;
                    EVTELEFONU.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Homephone) : "");
                    NewField1711121.CalcValue = NewField1711121.Value;
                    NewField12111121.CalcValue = NewField12111121.Value;
                    EVADRESI.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Homeaddress) : "") + @" " + (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Homecity) : "");
                    GAZISICILNOLABEL.CalcValue = GAZISICILNOLABEL.Value;
                    GAZISICILNOLABEL2.CalcValue = GAZISICILNOLABEL2.Value;
                    GAZISICILNO.CalcValue = @"";
                    QUARANTINEDISCHARGEDATE.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.HospitalDischargeDate) : "");
                    TOPLAMFIYATLBL1.CalcValue = TOPLAMFIYATLBL1.Value;
                    BIRIMFIYATLBL1.CalcValue = BIRIMFIYATLBL1.Value;
                    HIZMETADILBL1.CalcValue = HIZMETADILBL1.Value;
                    ADETLBL1.CalcValue = ADETLBL1.Value;
                    TARIHLBL1.CalcValue = TARIHLBL1.Value;
                    TOPLAMFIYATLBL2.CalcValue = TOPLAMFIYATLBL2.Value;
                    BIRIMFIYATLBL2.CalcValue = BIRIMFIYATLBL2.Value;
                    HIZMETADILBL2.CalcValue = HIZMETADILBL2.Value;
                    ADETLBL2.CalcValue = ADETLBL2.Value;
                    TARIHLBL2.CalcValue = TARIHLBL2.Value;
                    DIS18.CalcValue = DIS18.Value;
                    DIS18LBL.CalcValue = DIS18LBL.Value;
                    DIS17.CalcValue = DIS17.Value;
                    DIS17LBL.CalcValue = DIS17LBL.Value;
                    DIS16.CalcValue = DIS16.Value;
                    DIS16LBL.CalcValue = DIS16LBL.Value;
                    DIS15.CalcValue = DIS15.Value;
                    DIS15LBL.CalcValue = DIS15LBL.Value;
                    DIS14.CalcValue = DIS14.Value;
                    DIS14LBL.CalcValue = DIS14LBL.Value;
                    DIS13.CalcValue = DIS13.Value;
                    DIS13LBL.CalcValue = DIS13LBL.Value;
                    DIS12.CalcValue = DIS12.Value;
                    DIS12LBL.CalcValue = DIS12LBL.Value;
                    DIS11.CalcValue = DIS11.Value;
                    DIS11LBL.CalcValue = DIS11LBL.Value;
                    DIS55.CalcValue = DIS55.Value;
                    DIS55LBL.CalcValue = DIS55LBL.Value;
                    DIS54.CalcValue = DIS54.Value;
                    DIS54LBL.CalcValue = DIS54LBL.Value;
                    DIS53.CalcValue = DIS53.Value;
                    DIS53LBL.CalcValue = DIS53LBL.Value;
                    DIS52.CalcValue = DIS52.Value;
                    DIS52LBL.CalcValue = DIS52LBL.Value;
                    DIS51.CalcValue = DIS51.Value;
                    DIS51LBL.CalcValue = DIS51LBL.Value;
                    DIS48.CalcValue = DIS48.Value;
                    DIS48LBL.CalcValue = DIS48LBL.Value;
                    DIS47.CalcValue = DIS47.Value;
                    DIS47LBL.CalcValue = DIS47LBL.Value;
                    DIS46.CalcValue = DIS46.Value;
                    DIS46LBL.CalcValue = DIS46LBL.Value;
                    DIS45.CalcValue = DIS45.Value;
                    DIS45LBL.CalcValue = DIS45LBL.Value;
                    DIS44.CalcValue = DIS44.Value;
                    DIS44LBL.CalcValue = DIS44LBL.Value;
                    DIS43.CalcValue = DIS43.Value;
                    DIS43LBL.CalcValue = DIS43LBL.Value;
                    DIS42.CalcValue = DIS42.Value;
                    DIS42LBL.CalcValue = DIS42LBL.Value;
                    DIS41.CalcValue = DIS41.Value;
                    DIS41LBL.CalcValue = DIS41LBL.Value;
                    DIS85.CalcValue = DIS85.Value;
                    DIS85LBL.CalcValue = DIS85LBL.Value;
                    DIS84.CalcValue = DIS84.Value;
                    DIS84LBL.CalcValue = DIS84LBL.Value;
                    DIS83.CalcValue = DIS83.Value;
                    DIS83LBL.CalcValue = DIS83LBL.Value;
                    DIS82.CalcValue = DIS82.Value;
                    DIS82LBL.CalcValue = DIS82LBL.Value;
                    DIS81.CalcValue = DIS81.Value;
                    DIS81LBL.CalcValue = DIS81LBL.Value;
                    DIS21.CalcValue = DIS21.Value;
                    DIS21LBL.CalcValue = DIS21LBL.Value;
                    DIS22.CalcValue = DIS22.Value;
                    DIS22LBL.CalcValue = DIS22LBL.Value;
                    DIS23.CalcValue = DIS23.Value;
                    DIS23LBL.CalcValue = DIS23LBL.Value;
                    DIS24.CalcValue = DIS24.Value;
                    DIS24LBL.CalcValue = DIS24LBL.Value;
                    DIS25.CalcValue = DIS25.Value;
                    DIS25LBL.CalcValue = DIS25LBL.Value;
                    DIS26.CalcValue = DIS26.Value;
                    DIS26LBL.CalcValue = DIS26LBL.Value;
                    DIS27.CalcValue = DIS27.Value;
                    DIS27LBL.CalcValue = DIS27LBL.Value;
                    DIS28.CalcValue = DIS28.Value;
                    DIS28LBL.CalcValue = DIS28LBL.Value;
                    DIS61.CalcValue = DIS61.Value;
                    DIS61LBL.CalcValue = DIS61LBL.Value;
                    DIS62.CalcValue = DIS62.Value;
                    DIS62LBL.CalcValue = DIS62LBL.Value;
                    DIS63.CalcValue = DIS63.Value;
                    DIS63LBL.CalcValue = DIS63LBL.Value;
                    DIS64.CalcValue = DIS64.Value;
                    DIS64LBL.CalcValue = DIS64LBL.Value;
                    DIS65.CalcValue = DIS65.Value;
                    DIS65LBL.CalcValue = DIS65LBL.Value;
                    DIS31.CalcValue = DIS31.Value;
                    DIS31LBL.CalcValue = DIS31LBL.Value;
                    DIS32.CalcValue = DIS32.Value;
                    DIS32LBL.CalcValue = DIS32LBL.Value;
                    DIS33.CalcValue = DIS33.Value;
                    DIS33LBL.CalcValue = DIS33LBL.Value;
                    DIS34.CalcValue = DIS34.Value;
                    DIS34LBL.CalcValue = DIS34LBL.Value;
                    DIS35.CalcValue = DIS35.Value;
                    DIS35LBL.CalcValue = DIS35LBL.Value;
                    DIS36.CalcValue = DIS36.Value;
                    DIS36LBL.CalcValue = DIS36LBL.Value;
                    DIS37.CalcValue = DIS37.Value;
                    DIS37LBL.CalcValue = DIS37LBL.Value;
                    DIS38.CalcValue = DIS38.Value;
                    DIS38LBL.CalcValue = DIS38LBL.Value;
                    DIS71.CalcValue = DIS71.Value;
                    DIS71LBL.CalcValue = DIS71LBL.Value;
                    DIS72.CalcValue = DIS72.Value;
                    DIS72LBL.CalcValue = DIS72LBL.Value;
                    DIS73.CalcValue = DIS73.Value;
                    DIS73LBL.CalcValue = DIS73LBL.Value;
                    DIS74.CalcValue = DIS74.Value;
                    DIS74LBL.CalcValue = DIS74LBL.Value;
                    DIS75.CalcValue = DIS75.Value;
                    DIS75LBL.CalcValue = DIS75LBL.Value;
                    SAGUSTCENELBL.CalcValue = SAGUSTCENELBL.Value;
                    SOLUSTCENELBL.CalcValue = SOLUSTCENELBL.Value;
                    SAGALTCENELBL.CalcValue = SAGALTCENELBL.Value;
                    SOLALTCENELBL.CalcValue = SOLALTCENELBL.Value;
                    DOKTORLBL1.CalcValue = DOKTORLBL1.Value;
                    DOKTORLBL2.CalcValue = DOKTORLBL2.Value;
                    DOKTOR.CalcValue = @"";
                    HASTADURUMU.CalcValue = MyParentReport.RuntimeParameters.PATIENTSTATUS.ToString();
                    return new TTReportObject[] { NewField1101,NewField1111,NewField1121,HASTAADI,TCKIMLIKNO,NewField11111,NewField111111,NewField12111,HASTASIRANO,NewField121111,NewField111121,YAS,NewField1111121,NewField121121,NewField1211121,SAYFANO,NewField1121121,NewField11211121,NewField111122,NewField121112,NewField121113,TARIH1LBL,NewField121115,NewField121116,NewField1611121,NewField1111111,NewField1111122,NewField11211111,NewField111113,NewField1111112,NewField1111123,NewField11211112,NewField1121123,NewField11211123,NewField1121124,NewField11211124,KURUMADI,HOSPITALPROTOCOLNO,KURUMKODU,ICD10KOD,ICD10,TARIH1,BRANS,HASTATIP,FATURANO,CINSIYET,PROVIZYONNO,HASTATURU,EPISODE,PATIENT,TARIH2LBL,TARIH2,OPENINGDATE,QUARANTINEINPATIENTDATE,NewField1411121,NewField11111121,EVTELEFONU,NewField1711121,NewField12111121,EVADRESI,GAZISICILNOLABEL,GAZISICILNOLABEL2,GAZISICILNO,QUARANTINEDISCHARGEDATE,TOPLAMFIYATLBL1,BIRIMFIYATLBL1,HIZMETADILBL1,ADETLBL1,TARIHLBL1,TOPLAMFIYATLBL2,BIRIMFIYATLBL2,HIZMETADILBL2,ADETLBL2,TARIHLBL2,DIS18,DIS18LBL,DIS17,DIS17LBL,DIS16,DIS16LBL,DIS15,DIS15LBL,DIS14,DIS14LBL,DIS13,DIS13LBL,DIS12,DIS12LBL,DIS11,DIS11LBL,DIS55,DIS55LBL,DIS54,DIS54LBL,DIS53,DIS53LBL,DIS52,DIS52LBL,DIS51,DIS51LBL,DIS48,DIS48LBL,DIS47,DIS47LBL,DIS46,DIS46LBL,DIS45,DIS45LBL,DIS44,DIS44LBL,DIS43,DIS43LBL,DIS42,DIS42LBL,DIS41,DIS41LBL,DIS85,DIS85LBL,DIS84,DIS84LBL,DIS83,DIS83LBL,DIS82,DIS82LBL,DIS81,DIS81LBL,DIS21,DIS21LBL,DIS22,DIS22LBL,DIS23,DIS23LBL,DIS24,DIS24LBL,DIS25,DIS25LBL,DIS26,DIS26LBL,DIS27,DIS27LBL,DIS28,DIS28LBL,DIS61,DIS61LBL,DIS62,DIS62LBL,DIS63,DIS63LBL,DIS64,DIS64LBL,DIS65,DIS65LBL,DIS31,DIS31LBL,DIS32,DIS32LBL,DIS33,DIS33LBL,DIS34,DIS34LBL,DIS35,DIS35LBL,DIS36,DIS36LBL,DIS37,DIS37LBL,DIS38,DIS38LBL,DIS71,DIS71LBL,DIS72,DIS72LBL,DIS73,DIS73LBL,DIS74,DIS74LBL,DIS75,DIS75LBL,SAGUSTCENELBL,SOLUSTCENELBL,SAGALTCENELBL,SOLALTCENELBL,DOKTORLBL1,DOKTORLBL2,DOKTOR,HASTADURUMU};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    //            string eObjectId = EPISODE.CalcValue;
//            Episode e = (Episode)this.ParentReport.ReportObjectContext.GetObject(new Guid(eObjectId),"Episode");
//            
//            YAS.CalcValue = e.Patient.AgeBySpecificDate((DateTime)e.OpeningDate).ToString();
//            
//            //if(HASTATURU.FormattedValue == "OUTPATIENT" || HASTATURU.FormattedValue == "OUTPATİENT" || HASTATURU.FormattedValue == "0")
//            if(HASTADURUMU.CalcValue == "0")
//            {
//                TARIH1LBL.CalcValue = "Geliş Tarihi";
//                TARIH1.CalcValue = OPENINGDATE.CalcValue;
//                HASTATIP.CalcValue = "Poliklinik Hastası";
//                TARIH2LBL.Visible = TTReportTool.EvetHayirEnum.ehHayir;
//                TARIH2.Visible = TTReportTool.EvetHayirEnum.ehHayir;
//            }
//            else
//            {
//                TARIH1LBL.CalcValue = "Yatış Tarihi";
//                TARIH1.CalcValue = QUARANTINEINPATIENTDATE.CalcValue;
//                HASTATIP.CalcValue = "Yatan Hasta";
//                TARIH2LBL.Visible = TTReportTool.EvetHayirEnum.ehEvet;
//                TARIH2.Visible = TTReportTool.EvetHayirEnum.ehEvet;
//                
//                IList inpatientTreatmentClinicList = new List<InPatientTreatmentClinicApplication>();
//                inpatientTreatmentClinicList = InPatientTreatmentClinicApplication.GetAllClinicDischargeDatesByEpisode(this.ParentReport.ReportObjectContext, e.ObjectID.ToString());
//                foreach(InPatientTreatmentClinicApplication clinicApp in inpatientTreatmentClinicList)
//                {
//                    this.TARIH2.CalcValue = clinicApp.ClinicDischargeDate.ToString();
//                    break;
//                }
//                if(e.QuarantineInPatientDate != null)
//                    YAS.CalcValue = e.Patient.AgeBySpecificDate((DateTime)e.QuarantineInPatientDate).ToString();
//            }
//            
//            if(CINSIYET.CalcValue == "Male")
//                CINSIYET.CalcValue = "Erkek";
//            else if(CINSIYET.CalcValue == "Female")
//                CINSIYET.CalcValue = "Kadın";
//            else
//                CINSIYET.CalcValue = "Belirlenmemiş";
//            
//            string ICDKod = "";
//            string ICD = "";
//            IList diagnosisCodeList = new List<string>();
//            
//            foreach(DiagnosisGrid dg in e.Diagnosis)
//            {
//                if(!diagnosisCodeList.Contains(dg.Diagnose.Code))
//                {
//                    ICDKod = ICDKod + dg.Diagnose.Code + ",";
//                    ICD = ICD + dg.Diagnose.Name + ",";
//                    diagnosisCodeList.Add(dg.Diagnose.Code);
//                }
//            }
//            
//            if(ICDKod != "")
//                ICDKod = ICDKod.Substring(0, ICDKod.Length - 1);
//            
//            if(ICD != "")
//                ICD = ICD.Substring(0, ICD.Length - 1);
//            
//            ICD10KOD.CalcValue = ICDKod;
//            ICD10.CalcValue = ICD;
//            
//            if(this.GAZISICILNO.CalcValue == "")
//            {
//                this.GAZISICILNO.Visible = TTReportTool.EvetHayirEnum.ehHayir;
//                this.GAZISICILNOLABEL.Visible = TTReportTool.EvetHayirEnum.ehHayir;
//                this.GAZISICILNOLABEL2.Visible = TTReportTool.EvetHayirEnum.ehHayir;
//            }
//            else
//            {
//                this.GAZISICILNO.Visible = TTReportTool.EvetHayirEnum.ehEvet;
//                this.GAZISICILNOLABEL.Visible = TTReportTool.EvetHayirEnum.ehEvet;
//                this.GAZISICILNOLABEL2.Visible = TTReportTool.EvetHayirEnum.ehEvet;
//            }
//
//            // Provizyon Numarasını getirir
//            this.PROVIZYONNO.CalcValue = e.PatientAdmission.ProvisionNo;
//            
//            // Doktor Adı
//            if(TTObjectClasses.SystemParameter.GetParameterValue("SHOWDOCTORATCOLLECTEDINVOICEPROCEDUREDETAILREPORT", "FALSE") == "TRUE")
//            {
//                this.DOKTOR.Visible = TTReportTool.EvetHayirEnum.ehEvet;
//                this.DOKTORLBL1.Visible = TTReportTool.EvetHayirEnum.ehEvet;
//                this.DOKTORLBL2.Visible = TTReportTool.EvetHayirEnum.ehEvet;
//                
//                foreach(PatientAuthorizedResource patientAuthRes in e.PatientAuthorizedResources)
//                {
//                    if(patientAuthRes.Resource != null)
//                    {
//                        if(patientAuthRes.Resource.Name != null)
//                        {
//                            this.DOKTOR.CalcValue = patientAuthRes.Resource.Name;
//                            break;
//                        }
//                    }
//                }
//            }
//            else
//            {
//                this.DOKTOR.Visible = TTReportTool.EvetHayirEnum.ehHayir;
//                this.DOKTORLBL1.Visible = TTReportTool.EvetHayirEnum.ehHayir;
//                this.DOKTORLBL2.Visible = TTReportTool.EvetHayirEnum.ehHayir;
//            }
//            
//            // Aşağıdaki kısım Diş Şeması için
//            string toothNumbers = string.Empty;
//            bool dentalExaminationExists = false;
//            bool addToSchema;
//            
////            foreach(EpisodeAction ea in e.EpisodeActions)
////            {
////                if(ea is BaseDentalEpisodeAction)
////                {
////                    addToSchema = false;
////                    if(ea is DentalExamination)
////                    {
////                        if(((DentalExamination)ea).CurrentStateDefID != DentalExamination.States.Cancelled && ((DentalExamination)ea).CurrentStateDefID != DentalExamination.States.PatientNoShown)
////                            addToSchema = true;
////                    }
////                    else if(ea is DentalTreatmentRequest)
////                    {
////                        if(((DentalTreatmentRequest)ea).CurrentStateDefID != DentalTreatmentRequest.States.Rejected)
////                            addToSchema = true;
////                    }
////                    else if(ea is DentalProsthesisRequest)
////                    {
////                        if(((DentalProsthesisRequest)ea).CurrentStateDefID != DentalProsthesisRequest.States.Rejected)
////                            addToSchema = true;
////                    }
////                    
////                    if(addToSchema)
////                    {
////                        dentalExaminationExists = true;
////                        if(((BaseDentalEpisodeAction)ea).ToothNumbers != null)
////                        {
////                            foreach(string tooth in TTObjectClasses.Common.ParseString(((BaseDentalEpisodeAction)ea).ToothNumbers.ToString(),','))
////                            {
////                                if(tooth == "10" || tooth == "20" || tooth == "30" || tooth == "40" || tooth == "50" || tooth == "60" || tooth == "70" || tooth == "80" || tooth == "1020" || tooth == "3040" || tooth == "5060" || tooth == "7080" || tooth == "1234" || tooth == "5678")
////                                {
////                                    if (tooth == "10" || tooth == "1020" || tooth == "1234")
////                                    {
////                                        for(int i=11; i<=18; i++)
////                                        {
////                                            TTReportField rf = FieldsByName("DIS" + i.ToString());
////                                            rf.CalcValue = "X";
////                                        }
////                                    }
////                                    if (tooth == "20" || tooth == "1020" || tooth == "1234")
////                                    {
////                                        for(int i=21; i<=28; i++)
////                                        {
////                                            TTReportField rf = FieldsByName("DIS" + i.ToString());
////                                            rf.CalcValue = "X";
////                                        }
////                                    }
////                                    if (tooth == "30" || tooth == "3040" || tooth == "1234")
////                                    {
////                                        for(int i=31; i<=38; i++)
////                                        {
////                                            TTReportField rf = FieldsByName("DIS" + i.ToString());
////                                            rf.CalcValue = "X";
////                                        }
////                                    }
////                                    if (tooth == "40" || tooth == "3040" || tooth == "1234")
////                                    {
////                                        for(int i=41; i<=48; i++)
////                                        {
////                                            TTReportField rf = FieldsByName("DIS" + i.ToString());
////                                            rf.CalcValue = "X";
////                                        }
////                                    }
////                                    if (tooth == "50" || tooth == "5060" || tooth == "5678")
////                                    {
////                                        for(int i=51; i<=55; i++)
////                                        {
////                                            TTReportField rf = FieldsByName("DIS" + i.ToString());
////                                            rf.CalcValue = "X";
////                                        }
////                                    }
////                                    if (tooth == "60" || tooth == "5060" || tooth == "5678")
////                                    {
////                                        for(int i=61; i<=65; i++)
////                                        {
////                                            TTReportField rf = FieldsByName("DIS" + i.ToString());
////                                            rf.CalcValue = "X";
////                                        }
////                                    }
////                                    if (tooth == "70" || tooth == "7080" || tooth == "5678")
////                                    {
////                                        for(int i=71; i<=75; i++)
////                                        {
////                                            TTReportField rf = FieldsByName("DIS" + i.ToString());
////                                            rf.CalcValue = "X";
////                                        }
////                                    }
////                                    if (tooth == "80" || tooth == "7080" || tooth == "5678")
////                                    {
////                                        for(int i=81; i<=85; i++)
////                                        {
////                                            TTReportField rf = FieldsByName("DIS" + i.ToString());
////                                            rf.CalcValue = "X";
////                                        }
////                                    }
////                                }
////                                else
////                                {
////                                    TTReportField rf = FieldsByName("DIS" + tooth);
////                                    rf.CalcValue = "X";
////                                }
////                            }
////                        }
////                    }
////                }
////            }
//            
//            
//            if(dentalExaminationExists)
//            {
//                this.TARIHLBL1.Visible = EvetHayirEnum.ehEvet;
//                this.TARIHLBL1.CalcValue = "Diş No";
//                this.HIZMETADILBL1.Visible = EvetHayirEnum.ehHayir;
//                this.ADETLBL1.Visible = EvetHayirEnum.ehHayir;
//                this.BIRIMFIYATLBL1.Visible = EvetHayirEnum.ehHayir;
//                this.TOPLAMFIYATLBL1.Visible = EvetHayirEnum.ehHayir;
//                this.HEADERLINE1.Visible = EvetHayirEnum.ehHayir;
//                this.SAGUSTCENELBL.Visible = EvetHayirEnum.ehEvet;
//                this.SOLUSTCENELBL.Visible = EvetHayirEnum.ehEvet;
//                this.SAGALTCENELBL.Visible = EvetHayirEnum.ehEvet;
//                this.SOLALTCENELBL.Visible = EvetHayirEnum.ehEvet;
//                this.DISLINE1.Visible = EvetHayirEnum.ehEvet;
//                this.DISLINE2.Visible = EvetHayirEnum.ehEvet;
//                this.TARIHLBL2.Visible = EvetHayirEnum.ehEvet;
//                this.HIZMETADILBL2.Visible = EvetHayirEnum.ehEvet;
//                this.ADETLBL2.Visible = EvetHayirEnum.ehEvet;
//                this.BIRIMFIYATLBL2.Visible = EvetHayirEnum.ehEvet;
//                this.TOPLAMFIYATLBL2.Visible = EvetHayirEnum.ehEvet;
//                this.HEADERLINE2.Visible = EvetHayirEnum.ehEvet;
//                
//                for(int i=11; i<=85; i++)
//                {
//                    TTReportField rf = FieldsByName("DIS" + i.ToString());
//                    if(rf != null)
//                        rf.Visible = EvetHayirEnum.ehEvet;
//                    
//                    TTReportField rfLbl = FieldsByName("DIS" + i.ToString() + "LBL");
//                    if(rfLbl != null)
//                        rfLbl.Visible = EvetHayirEnum.ehEvet;
//                }
//            }
//            else
//            {
//                this.TARIHLBL1.Visible = EvetHayirEnum.ehEvet;
//                this.TARIHLBL1.CalcValue = "Tarih";
//                this.HIZMETADILBL1.Visible = EvetHayirEnum.ehEvet;
//                this.ADETLBL1.Visible = EvetHayirEnum.ehEvet;
//                this.BIRIMFIYATLBL1.Visible = EvetHayirEnum.ehEvet;
//                this.TOPLAMFIYATLBL1.Visible = EvetHayirEnum.ehEvet;
//                this.HEADERLINE1.Visible = EvetHayirEnum.ehEvet;
//                this.SAGUSTCENELBL.Visible = EvetHayirEnum.ehHayir;
//                this.SOLUSTCENELBL.Visible = EvetHayirEnum.ehHayir;
//                this.SAGALTCENELBL.Visible = EvetHayirEnum.ehHayir;
//                this.SOLALTCENELBL.Visible = EvetHayirEnum.ehHayir;
//                this.DISLINE1.Visible = EvetHayirEnum.ehHayir;
//                this.DISLINE2.Visible = EvetHayirEnum.ehHayir;
//                this.TARIHLBL2.Visible = EvetHayirEnum.ehHayir;
//                this.HIZMETADILBL2.Visible = EvetHayirEnum.ehHayir;
//                this.ADETLBL2.Visible = EvetHayirEnum.ehHayir;
//                this.BIRIMFIYATLBL2.Visible = EvetHayirEnum.ehHayir;
//                this.TOPLAMFIYATLBL2.Visible = EvetHayirEnum.ehHayir;
//                this.HEADERLINE2.Visible = EvetHayirEnum.ehHayir;
//                
//                for(int i=11; i<=85; i++)
//                {
//                    TTReportField rf = FieldsByName("DIS" + i.ToString());
//                    if (rf != null)
//                        rf.Visible = EvetHayirEnum.ehHayir;
//                    
//                    TTReportField rfLbl = FieldsByName("DIS" + i.ToString() + "LBL");
//                    if (rfLbl != null)
//                        rfLbl.Visible = EvetHayirEnum.ehHayir;
//                }
//            }
//
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public CollectedInvoiceProcDetPrvReport_NoCheck_2 MyParentReport
                {
                    get { return (CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport; }
                }
                
                public TTReportField TOPLAMFIYAT;
                public TTReportShape NewLine11111;
                public TTReportField NewField11116111; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOPLAMFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 2, 197, 6, false);
                    TOPLAMFIYAT.Name = "TOPLAMFIYAT";
                    TOPLAMFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMFIYAT.TextFormat = @"#,##0.#0";
                    TOPLAMFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMFIYAT.TextFont.Name = "Arial";
                    TOPLAMFIYAT.TextFont.Size = 8;
                    TOPLAMFIYAT.TextFont.CharSet = 162;
                    TOPLAMFIYAT.Value = @"{@sumof(TOPLAMFIYAT1)@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 1, 197, 1, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                    NewField11116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 2, 173, 6, false);
                    NewField11116111.Name = "NewField11116111";
                    NewField11116111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11116111.TextFont.Name = "Arial";
                    NewField11116111.TextFont.Size = 8;
                    NewField11116111.TextFont.Bold = true;
                    NewField11116111.TextFont.CharSet = 162;
                    NewField11116111.Value = @"Toplam Tutar :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class dataset_CollectedInvoiceProcDetPreviewReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class>(0);
                    TOPLAMFIYAT.CalcValue = ParentGroup.FieldSums["TOPLAMFIYAT1"].Value.ToString();;
                    NewField11116111.CalcValue = NewField11116111.Value;
                    return new TTReportObject[] { TOPLAMFIYAT,NewField11116111};
                }
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public CollectedInvoiceProcDetPrvReport_NoCheck_2 MyParentReport
            {
                get { return (CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HIZMET { get {return Body().HIZMET;} }
            public TTReportField TOPLAMFIYAT { get {return Body().TOPLAMFIYAT;} }
            public TTReportField BIRIMFIYAT { get {return Body().BIRIMFIYAT;} }
            public TTReportField ADET { get {return Body().ADET;} }
            public TTReportField TOPLAMFIYAT1 { get {return Body().TOPLAMFIYAT1;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField ACCTRXOBJECTID { get {return Body().ACCTRXOBJECTID;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class dataSet_CollectedInvoiceProcDetPreviewReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class>(0);    
                return new object[] {(dataSet_CollectedInvoiceProcDetPreviewReportQuery2==null ? null : dataSet_CollectedInvoiceProcDetPreviewReportQuery2.HospitalProtocolNo)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public CollectedInvoiceProcDetPrvReport_NoCheck_2 MyParentReport
                {
                    get { return (CollectedInvoiceProcDetPrvReport_NoCheck_2)ParentReport; }
                }
                
                public TTReportField HIZMET;
                public TTReportField TOPLAMFIYAT;
                public TTReportField BIRIMFIYAT;
                public TTReportField ADET;
                public TTReportField TOPLAMFIYAT1;
                public TTReportField TARIH;
                public TTReportField ACCTRXOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    HIZMET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 1, 143, 5, false);
                    HIZMET.Name = "HIZMET";
                    HIZMET.FieldType = ReportFieldTypeEnum.ftVariable;
                    HIZMET.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HIZMET.MultiLine = EvetHayirEnum.ehEvet;
                    HIZMET.NoClip = EvetHayirEnum.ehEvet;
                    HIZMET.WordBreak = EvetHayirEnum.ehEvet;
                    HIZMET.ExpandTabs = EvetHayirEnum.ehEvet;
                    HIZMET.TextFont.Name = "Arial";
                    HIZMET.TextFont.Size = 8;
                    HIZMET.TextFont.CharSet = 162;
                    HIZMET.Value = @"{#HEAD.EXTERNALCODE#} {#HEAD.DESCRIPTION#}";

                    TOPLAMFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 1, 197, 5, false);
                    TOPLAMFIYAT.Name = "TOPLAMFIYAT";
                    TOPLAMFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMFIYAT.TextFormat = @"#,##0.#0";
                    TOPLAMFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMFIYAT.TextFont.Name = "Arial";
                    TOPLAMFIYAT.TextFont.Size = 8;
                    TOPLAMFIYAT.TextFont.CharSet = 162;
                    TOPLAMFIYAT.Value = @"{#HEAD.TOTALPRICE#}";

                    BIRIMFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 1, 173, 5, false);
                    BIRIMFIYAT.Name = "BIRIMFIYAT";
                    BIRIMFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMFIYAT.TextFormat = @"#,##0.#0";
                    BIRIMFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BIRIMFIYAT.TextFont.Name = "Arial";
                    BIRIMFIYAT.TextFont.Size = 8;
                    BIRIMFIYAT.TextFont.CharSet = 162;
                    BIRIMFIYAT.Value = @"{#HEAD.UNITPRICE#}";

                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 1, 153, 5, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADET.TextFont.Name = "Arial";
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"{#HEAD.AMOUNT#}";

                    TOPLAMFIYAT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 236, 5, false);
                    TOPLAMFIYAT1.Name = "TOPLAMFIYAT1";
                    TOPLAMFIYAT1.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMFIYAT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMFIYAT1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMFIYAT1.TextFont.Name = "Arial";
                    TOPLAMFIYAT1.TextFont.Size = 8;
                    TOPLAMFIYAT1.TextFont.CharSet = 162;
                    TOPLAMFIYAT1.Value = @"{#HEAD.TOTALPRICE#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 27, 5, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFont.Name = "Arial";
                    TARIH.TextFont.Size = 8;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#HEAD.DAY#}.{#HEAD.MONTH#}.{#HEAD.YEAR#}";

                    ACCTRXOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 1, 269, 5, false);
                    ACCTRXOBJECTID.Name = "ACCTRXOBJECTID";
                    ACCTRXOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    ACCTRXOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCTRXOBJECTID.TextFont.Name = "Arial";
                    ACCTRXOBJECTID.TextFont.Size = 8;
                    ACCTRXOBJECTID.TextFont.CharSet = 162;
                    ACCTRXOBJECTID.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class dataset_CollectedInvoiceProcDetPreviewReportQuery2 = MyParentReport.HEAD.rsGroup.GetCurrentRecord<AccountTransaction.CollectedInvoiceProcDetPreviewReportQuery2_Class>(0);
                    HIZMET.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.ExternalCode) : "") + @" " + (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Description) : "");
                    TOPLAMFIYAT.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Totalprice) : "");
                    BIRIMFIYAT.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.UnitPrice) : "");
                    ADET.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Amount) : "");
                    TOPLAMFIYAT1.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Totalprice) : "");
                    TARIH.CalcValue = (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Day) : "") + @"." + (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Month) : "") + @"." + (dataset_CollectedInvoiceProcDetPreviewReportQuery2 != null ? Globals.ToStringCore(dataset_CollectedInvoiceProcDetPreviewReportQuery2.Year) : "");
                    ACCTRXOBJECTID.CalcValue = @"";
                    return new TTReportObject[] { HIZMET,TOPLAMFIYAT,BIRIMFIYAT,ADET,TOPLAMFIYAT1,TARIH,ACCTRXOBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    /*            
            string objectID = this.ACCTRXOBJECTID.CalcValue;
            
            TTObjectContext objectContext = new TTObjectContext(true);
            AccountTransaction acctrx = (AccountTransaction)objectContext.GetObject(new Guid(objectID),"AccountTransaction");
            
            if (acctrx.SubActionProcedure != null)
            {
                if (acctrx.SubActionProcedure is DentalProcedure)
                {
                    if(((DentalProcedure)acctrx.SubActionProcedure).ToothNumber != null)
                        this.HIZMET.CalcValue += " (No: " + ((DentalProcedure)acctrx.SubActionProcedure).ToothNumber.ToString() + ")";
                }
                if (acctrx.PricingDetail != null)
                {
                    if(acctrx.PricingDetail.ExternalCode == "520010")
                    {
                        if (acctrx.SubActionProcedure.ProcedureSpeciality != null)
                            this.HIZMET.CalcValue += " (" + acctrx.SubActionProcedure.ProcedureSpeciality.Name + ")";
                    }
                }
            }
            */
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CollectedInvoiceProcDetPrvReport_NoCheck_2()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            HEAD = new HEADGroup(PARTA,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("DOCUMENTNO", "", "Fatura No", @"", false, true, false, new Guid("5dcf77fd-4b8d-479a-9e5e-e5e7414cf8b6"));
            reportParameter = Parameters.Add("RESOURCES", "", "Poliklinik", @"", true, false, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("RESOURCESFILTER", "", "Poliklinik ve Klinik", @"", false, false, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("RES", "", "Ana Bilim Dalı/Poliklinik/Klinik Listesi", @"", false, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("5ad418c0-c7f0-4c19-b07d-d604502886fe");
            reportParameter = Parameters.Add("EPISODES", "", "Epizotlar", @"", true, false, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("PAYERS", "", "Kurumlar", @"", true, false, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("PATIENTSTATUS", "", "Hasta Durumu", @"", true, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DOCUMENTNO"))
                _runtimeParameters.DOCUMENTNO = (string)TTObjectDefManager.Instance.DataTypes["String30"].ConvertValue(parameters["DOCUMENTNO"]);
            if (parameters.ContainsKey("RESOURCES"))
                _runtimeParameters.RESOURCES = (List<string>)parameters["RESOURCES"];
            if (parameters.ContainsKey("RESOURCESFILTER"))
                _runtimeParameters.RESOURCESFILTER = (List<string>)parameters["RESOURCESFILTER"];
            if (parameters.ContainsKey("RES"))
                _runtimeParameters.RES = (List<string>)parameters["RES"];
            if (parameters.ContainsKey("EPISODES"))
                _runtimeParameters.EPISODES = (List<string>)parameters["EPISODES"];
            if (parameters.ContainsKey("PAYERS"))
                _runtimeParameters.PAYERS = (List<string>)parameters["PAYERS"];
            if (parameters.ContainsKey("PATIENTSTATUS"))
                _runtimeParameters.PATIENTSTATUS = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTSTATUS"]);
            Name = "COLLECTEDINVOICEPROCDETPRVREPORT_NOCHECK_2";
            Caption = "Hizmet Detay Bilgisi Öndökümü (Checksiz 2)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}