
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
    /// Sağlık Kurulu Tümör Raporu (Arkalı-Önlü-A4)
    /// </summary>
    public partial class HealthCommitteeTumourReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class ARKASAYFAGroup : TTReportGroup
        {
            public HealthCommitteeTumourReport MyParentReport
            {
                get { return (HealthCommitteeTumourReport)ParentReport; }
            }

            new public ARKASAYFAGroupHeader Header()
            {
                return (ARKASAYFAGroupHeader)_header;
            }

            new public ARKASAYFAGroupFooter Footer()
            {
                return (ARKASAYFAGroupFooter)_footer;
            }

            public TTReportField TANI { get {return Header().TANI;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField MADDEKARAR { get {return Header().MADDEKARAR;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportShape shape1 { get {return Header().shape1;} }
            public TTReportField PATINFO { get {return Header().PATINFO;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField BASTABIP { get {return Header().BASTABIP;} }
            public TTReportField USTMAKAMONAYI { get {return Header().USTMAKAMONAYI;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportShape shape2 { get {return Header().shape2;} }
            public TTReportField MEMBERS { get {return Header().MEMBERS;} }
            public TTReportField OYBIRLIGI { get {return Header().OYBIRLIGI;} }
            public TTReportShape shape3 { get {return Header().shape3;} }
            public TTReportShape shape4 { get {return Header().shape4;} }
            public TTReportField UNVAN { get {return Header().UNVAN;} }
            public TTReportField ADI { get {return Header().ADI;} }
            public TTReportField SICNO { get {return Header().SICNO;} }
            public TTReportField KARAR { get {return Header().KARAR;} }
            public TTReportField MADDE { get {return Header().MADDE;} }
            public TTReportField SKRAPORALTBASLIK { get {return Header().SKRAPORALTBASLIK;} }
            public TTReportField DTARIHI { get {return Header().DTARIHI;} }
            public ARKASAYFAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ARKASAYFAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommittee.GetCurrentHealthCommittee_Class>("GetCurrentHealthCommittee", HealthCommittee.GetCurrentHealthCommittee((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ARKASAYFAGroupHeader(this);
                _footer = new ARKASAYFAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ARKASAYFAGroupHeader : TTReportSection
            {
                public HealthCommitteeTumourReport MyParentReport
                {
                    get { return (HealthCommitteeTumourReport)ParentReport; }
                }
                
                public TTReportField TANI;
                public TTReportField NewField1;
                public TTReportField MADDEKARAR;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportShape shape1;
                public TTReportField PATINFO;
                public TTReportField NewField13;
                public TTReportField BASTABIP;
                public TTReportField USTMAKAMONAYI;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportShape shape2;
                public TTReportField MEMBERS;
                public TTReportField OYBIRLIGI;
                public TTReportShape shape3;
                public TTReportShape shape4;
                public TTReportField UNVAN;
                public TTReportField ADI;
                public TTReportField SICNO;
                public TTReportField KARAR;
                public TTReportField MADDE;
                public TTReportField SKRAPORALTBASLIK;
                public TTReportField DTARIHI; 
                public ARKASAYFAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 119;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 11, 195, 27, false);
                    TANI.Name = "TANI";
                    TANI.DrawStyle = DrawStyleConstants.vbSolid;
                    TANI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 40, 27, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.Value = @"Tanı";

                    MADDEKARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 32, 195, 58, false);
                    MADDEKARAR.Name = "MADDEKARAR";
                    MADDEKARAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    MADDEKARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDEKARAR.MultiLine = EvetHayirEnum.ehEvet;
                    MADDEKARAR.WordBreak = EvetHayirEnum.ehEvet;
                    MADDEKARAR.TextFont.Name = "Arial Narrow";
                    MADDEKARAR.TextFont.Size = 8;
                    MADDEKARAR.Value = @"{%ARKASAYFA.MADDE%}
{%ARKASAYFA.KARAR%}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 27, 40, 58, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.Value = @"Karar(*)";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 58, 191, 67, false);
                    NewField4.Name = "NewField4";
                    NewField4.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.Value = @"NOT : Raporun imza yerlerine imzadan önce ve imza üstüne makine ile imza sahibinin rütbe, sicil no, ihtisas, adı ve soyadı yazılacaktır.";

                    shape1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 58, 10, 150, false);
                    shape1.Name = "shape1";
                    shape1.DrawStyle = DrawStyleConstants.vbSolid;

                    PATINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 195, 10, false);
                    PATINFO.Name = "PATINFO";
                    PATINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATINFO.TextFont.Name = "Arial Narrow";
                    PATINFO.Value = @"{#PNAME#} {#PSURNAME#} ({#DOGUMYERI#} / {%DTARIHI%}) {#ISLEMNO#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 133, 195, 138, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.Value = @"(*) Karar hanesine S.Y. Yönetmeliğinin tanıya uygun madde ve fıkra No.ları yazılması zorunludur.";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 139, 195, 179, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.DrawStyle = DrawStyleConstants.vbSolid;
                    BASTABIP.FillStyle = FillStyleConstants.vbFSTransparent;
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Name = "Arial Narrow";
                    BASTABIP.Value = @"";

                    USTMAKAMONAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 179, 195, 214, false);
                    USTMAKAMONAYI.Name = "USTMAKAMONAYI";
                    USTMAKAMONAYI.DrawStyle = DrawStyleConstants.vbSolid;
                    USTMAKAMONAYI.FillStyle = FillStyleConstants.vbFSTransparent;
                    USTMAKAMONAYI.FieldType = ReportFieldTypeEnum.ftVariable;
                    USTMAKAMONAYI.MultiLine = EvetHayirEnum.ehEvet;
                    USTMAKAMONAYI.TextFont.Name = "Arial Narrow";
                    USTMAKAMONAYI.Value = @"XXXXXX, XXXXXX, XXXXXX, Menzil Baştabipleri Onayı
Sağlık Kurulu tarafından verilen karar S.Y. Yönetmeliği {%MADDE%}  maddelerine/fıkralarına uygundur.


                                                                             Rütbesi, Sicil No.
                                                                             Adı Soyadı
                                                                             İmza, mühür";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 214, 195, 235, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.TextFont.Name = "Arial Narrow";
                    NewField17.Value = @"Kara, Deniz, Hava Kuvvetleri XXXXXXlıkları Sağlık Daire Başkanları Onayı

                                                       /        / 20      .......................................................................................................... K.K.K.lığı Sağlık Daire Bşk.";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 235, 195, 252, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField18.MultiLine = EvetHayirEnum.ehEvet;
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.Value = @"Milli Savunma Bakanlığı Sağlık Daire Başkanı Onayı";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 252, 195, 269, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.Name = "Arial Narrow";
                    NewField19.Value = @"Ek rapor yazılacak kısım :";

                    shape2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 58, 195, 149, false);
                    shape2.Name = "shape2";
                    shape2.DrawStyle = DrawStyleConstants.vbSolid;

                    MEMBERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 63, 194, 132, false);
                    MEMBERS.Name = "MEMBERS";
                    MEMBERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEMBERS.MultiLine = EvetHayirEnum.ehEvet;
                    MEMBERS.WordBreak = EvetHayirEnum.ehEvet;
                    MEMBERS.ExpandTabs = EvetHayirEnum.ehEvet;
                    MEMBERS.TextFont.Size = 6;
                    MEMBERS.TextFont.Bold = true;
                    MEMBERS.Value = @"";

                    OYBIRLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 27, 195, 32, false);
                    OYBIRLIGI.Name = "OYBIRLIGI";
                    OYBIRLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OYBIRLIGI.TextFont.Name = "Arial Narrow";
                    OYBIRLIGI.Value = @"";

                    shape3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, 58, 195, 58, false);
                    shape3.Name = "shape3";
                    shape3.DrawStyle = DrawStyleConstants.vbSolid;

                    shape4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 195, 27, 195, 59, false);
                    shape4.Name = "shape4";
                    shape4.DrawStyle = DrawStyleConstants.vbSolid;

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 160, 136, 165, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.TextColor = System.Drawing.Color.Red;
                    UNVAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.Value = @"";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 165, 173, 170, false);
                    ADI.Name = "ADI";
                    ADI.Visible = EvetHayirEnum.ehHayir;
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.TextColor = System.Drawing.Color.Red;
                    ADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADI.TextFont.Name = "Arial Narrow";
                    ADI.Value = @"";

                    SICNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 160, 173, 165, false);
                    SICNO.Name = "SICNO";
                    SICNO.Visible = EvetHayirEnum.ehHayir;
                    SICNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICNO.TextColor = System.Drawing.Color.Red;
                    SICNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SICNO.TextFont.Name = "Arial Narrow";
                    SICNO.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 35, 236, 40, false);
                    KARAR.Name = "KARAR";
                    KARAR.Visible = EvetHayirEnum.ehHayir;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.TextFormat = @"NOCR";
                    KARAR.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 29, 236, 34, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFormat = @"NOCR/";
                    MADDE.Value = @"";

                    SKRAPORALTBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 40, 239, 45, false);
                    SKRAPORALTBASLIK.Name = "SKRAPORALTBASLIK";
                    SKRAPORALTBASLIK.Visible = EvetHayirEnum.ehHayir;
                    SKRAPORALTBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    SKRAPORALTBASLIK.TextFormat = @"NOCR /";
                    SKRAPORALTBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORALTBASLIK"","""")";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 45, 236, 50, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#DTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    TANI.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    MADDEKARAR.CalcValue = MyParentReport.ARKASAYFA.MADDE.FormattedValue + @"
" + MyParentReport.ARKASAYFA.KARAR.FormattedValue;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    PATINFO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "") + @" (" + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "") + @" / " + MyParentReport.ARKASAYFA.DTARIHI.FormattedValue + @") " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
                    NewField13.CalcValue = NewField13.Value;
                    BASTABIP.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    USTMAKAMONAYI.CalcValue = @"XXXXXX, XXXXXX, XXXXXX, Menzil Baştabipleri Onayı
Sağlık Kurulu tarafından verilen karar S.Y. Yönetmeliği " + MyParentReport.ARKASAYFA.MADDE.FormattedValue + @"  maddelerine/fıkralarına uygundur.


                                                                             Rütbesi, Sicil No.
                                                                             Adı Soyadı
                                                                             İmza, mühür";
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    MEMBERS.CalcValue = @"";
                    OYBIRLIGI.CalcValue = @"";
                    UNVAN.CalcValue = @"";
                    ADI.CalcValue = @"";
                    SICNO.CalcValue = @"";
                    KARAR.CalcValue = @"";
                    SKRAPORALTBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKRAPORALTBASLIK","");
                    return new TTReportObject[] { TANI,NewField1,MADDEKARAR,NewField3,NewField4,DTARIHI,PATINFO,NewField13,BASTABIP,MADDE,USTMAKAMONAYI,NewField17,NewField18,NewField19,MEMBERS,OYBIRLIGI,UNVAN,ADI,SICNO,KARAR,SKRAPORALTBASLIK};
                }

                public override void RunScript()
                {
#region ARKASAYFA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
            //Oy Birliği
            if(hc.Unanimity != null && hc.Unanimity == LargeMajorityUnanimityEnum.Unanimity)
                this.OYBIRLIGI.CalcValue = "KARAR OY BİRLİĞİ İLE ALINMIŞTIR";
            else if (hc.Unanimity != null && hc.Unanimity == LargeMajorityUnanimityEnum.LargeMajority)
                this.OYBIRLIGI.CalcValue = "KARAR OY ÇOKLUĞU İLE ALINMIŞTIR";
            //Madde-Dilim-Fıkra
            this.MADDE.CalcValue = "[";
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
            {
                this.MADDE.CalcValue += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                this.MADDE.CalcValue += "\t";
            }
            this.MADDE.CalcValue += "]";
            //Tanı
            int nCount = 1;
            this.TANI.CalcValue = "";
            BindingList<HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class> pDiagnosis = HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID(sObjectID);
            foreach(HealthCommittee_DiagnosisGrid.GetDiagnosisByParentObjectID_Class pGrid in pDiagnosis)
            {
                this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Tanikodu + " " + pGrid.Taniadi;
                this.TANI.CalcValue += "\r\n";
                nCount++;
            }
            //Baştabip
            string sCrLf = "\r\n";
            foreach (MemberOfHealthCommiittee member in hc.Members)
            {
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.ChiefOfMedicine)
                {
                    string sEmpID = member.MemberDoctor.EmploymentRecordID;
                    string sTitle = (member.MemberDoctor.MilitaryClass == null ? "" : member.MemberDoctor.MilitaryClass.Name);
                    sTitle += " " + (member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.Name);
                    string sMasterText = "";
                    
                    sMasterText += "YETKİLİ ÜST MAKAM ONAYLARI:"+sCrLf;
                    sMasterText += "Sağlık Kurulu tarafından verilen karar S.Y. Yönetmeliği " + this.MADDE.CalcValue + " maddelerine/fıkralarına uygundur." + sCrLf;
                    sMasterText += sCrLf;

                    if(this.SKRAPORALTBASLIK.CalcValue == "")
                        sMasterText = sMasterText + "                                                                                         .......................................        /      / 20" + sCrLf;
                    else
                        sMasterText = sMasterText + "                     " + this.SKRAPORALTBASLIK.CalcValue + "         /      / 20" + sCrLf;

                    sMasterText = sMasterText + "" + sCrLf;
                    sMasterText = sMasterText + "                                                                             Rütbesi, Sicil No. " + sTitle + " (" + sEmpID + ")" + sCrLf;
                    sMasterText = sMasterText + "                                                                             Adı Soyadı           " + member.MemberDoctor.Name + sCrLf;
                    sMasterText = sMasterText + "                                                                             İmza, mühür" + sCrLf;
                    this.BASTABIP.CalcValue = sMasterText;
                }
                //Members
                if (member.HealthCommitteeType == MemberOfHCTypeEnum.MemberOfHealthCommittee)
                {
                    string sMembersText = sCrLf;
                    string sMemberName = "", sMemberMilClass = "", sMemberRank = "", sMemberTitle = "";

                    const int COLUMN_COUNT = 3;
                    const int SPACE_COUNT = 60;
                    int nCounter = 0;
                    int nRow = 0;

                    string sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                    string sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                    string sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);


                    sMemberName = member.MemberDoctor.Name;
                    sMemberMilClass = member.MemberDoctor.MilitaryClass == null ? "" : member.MemberDoctor.MilitaryClass.Name;
                    sMemberRank = member.MemberDoctor.Rank == null ? "" : member.MemberDoctor.Rank.Name;
                    sMemberTitle = member.MemberDoctor.Title == null ? "" : member.MemberDoctor.Title.ToString();

                    sNameRow = sNameRow.Insert(nCounter, sMemberName);
                    sRankRow = sRankRow.Insert(nCounter, sMemberRank + " " + sMemberMilClass);
                    sTitleRow = sTitleRow.Insert(nCounter, sMemberTitle);

                    nCounter += SPACE_COUNT;

                    nRow = nCounter / SPACE_COUNT;
                    int nRate = nRow % COLUMN_COUNT;
                    if (nRate == 0)
                    {
                        sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sNameRow + "\r\n";
                        sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sRankRow + "\r\n";
                        sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                        sMembersText += sTitleRow + "\r\n";

                        sNameRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sRankRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);
                        sTitleRow = new string(' ', SPACE_COUNT * COLUMN_COUNT);

                        sMembersText += sCrLf + sCrLf + sCrLf;
                        nCounter = 0;
                    }



                    sNameRow = sNameRow.TrimEnd(new char[] { ' ' });
                    sMembersText += sNameRow + "\r\n";
                    sRankRow = sRankRow.TrimEnd(new char[] { ' ' });
                    sMembersText += sRankRow + "\r\n";
                    sTitleRow = sTitleRow.TrimEnd(new char[] { ' ' });
                    sMembersText += sTitleRow + "\r\n";

                    this.MEMBERS.CalcValue = sMembersText;
                }
            }
#endregion ARKASAYFA HEADER_Script
                }
            }
            public partial class ARKASAYFAGroupFooter : TTReportSection
            {
                public HealthCommitteeTumourReport MyParentReport
                {
                    get { return (HealthCommitteeTumourReport)ParentReport; }
                }
                 
                public ARKASAYFAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ARKASAYFAGroup ARKASAYFA;

        public partial class ANAGroup : TTReportGroup
        {
            public HealthCommitteeTumourReport MyParentReport
            {
                get { return (HealthCommitteeTumourReport)ParentReport; }
            }

            new public ANAGroupHeader Header()
            {
                return (ANAGroupHeader)_header;
            }

            new public ANAGroupFooter Footer()
            {
                return (ANAGroupFooter)_footer;
            }

            public TTReportField FRESOURCE { get {return Header().FRESOURCE;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField53 { get {return Header().NewField53;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField MAKSAD { get {return Header().MAKSAD;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField KARANTINANO { get {return Header().KARANTINANO;} }
            public TTReportField YATISTARIHI { get {return Header().YATISTARIHI;} }
            public TTReportField TABURCUTARIHI { get {return Header().TABURCUTARIHI;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NewField25 { get {return Header().NewField25;} }
            public TTReportField LBLSICIL { get {return Header().LBLSICIL;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField SINIFRUTBE { get {return Header().SINIFRUTBE;} }
            public TTReportField SICILNO { get {return Header().SICILNO;} }
            public TTReportField NewField33 { get {return Header().NewField33;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField DTYER { get {return Header().DTYER;} }
            public TTReportField SKBASLIK { get {return Header().SKBASLIK;} }
            public TTReportField EMIRTARIHI { get {return Header().EMIRTARIHI;} }
            public TTReportField NewField40 { get {return Header().NewField40;} }
            public TTReportField EMIRNO { get {return Header().EMIRNO;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField42 { get {return Header().NewField42;} }
            public TTReportField NewField44 { get {return Header().NewField44;} }
            public TTReportField NewField45 { get {return Header().NewField45;} }
            public TTReportField BOY { get {return Header().BOY;} }
            public TTReportField NewField48 { get {return Header().NewField48;} }
            public TTReportField AGIRLIK { get {return Header().AGIRLIK;} }
            public TTReportField SKNEFESVERME { get {return Header().SKNEFESVERME;} }
            public TTReportField SKNEFESALMA { get {return Header().SKNEFESALMA;} }
            public TTReportField NewField49 { get {return Header().NewField49;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField MUAMELESAYISI { get {return Header().MUAMELESAYISI;} }
            public TTReportField NewField51 { get {return Header().NewField51;} }
            public TTReportField NewField520 { get {return Header().NewField520;} }
            public TTReportField NewField52 { get {return Header().NewField52;} }
            public TTReportField KIMLIKNO { get {return Header().KIMLIKNO;} }
            public TTReportField TCNO { get {return Header().TCNO;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField ASKSUBE { get {return Header().ASKSUBE;} }
            public TTReportShape shape13 { get {return Footer().shape13;} }
            public ANAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ANAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                HealthCommittee.GetCurrentHealthCommittee_Class dataSet_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);    
                return new object[] {(dataSet_GetCurrentHealthCommittee==null ? null : dataSet_GetCurrentHealthCommittee.Healthcommitteeobjectid)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new ANAGroupHeader(this);
                _footer = new ANAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class ANAGroupHeader : TTReportSection
            {
                public HealthCommitteeTumourReport MyParentReport
                {
                    get { return (HealthCommitteeTumourReport)ParentReport; }
                }
                
                public TTReportField FRESOURCE;
                public TTReportField NewField3;
                public TTReportField NewField53;
                public TTReportField NewField21;
                public TTReportField NewField0;
                public TTReportField NewField1;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField10;
                public TTReportField MAKSAD;
                public TTReportField MAKAM;
                public TTReportField RAPORTARIHI;
                public TTReportField KARANTINANO;
                public TTReportField YATISTARIHI;
                public TTReportField TABURCUTARIHI;
                public TTReportField NewField20;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField25;
                public TTReportField LBLSICIL;
                public TTReportField NAME;
                public TTReportField FATHERNAME;
                public TTReportField BIRLIK;
                public TTReportField SINIFRUTBE;
                public TTReportField SICILNO;
                public TTReportField NewField33;
                public TTReportField ADRES;
                public TTReportField DTYER;
                public TTReportField SKBASLIK;
                public TTReportField EMIRTARIHI;
                public TTReportField NewField40;
                public TTReportField EMIRNO;
                public TTReportField RAPORNO;
                public TTReportField NewField2;
                public TTReportField NewField42;
                public TTReportField NewField44;
                public TTReportField NewField45;
                public TTReportField BOY;
                public TTReportField NewField48;
                public TTReportField AGIRLIK;
                public TTReportField SKNEFESVERME;
                public TTReportField SKNEFESALMA;
                public TTReportField NewField49;
                public TTReportField NewField24;
                public TTReportField MUAMELESAYISI;
                public TTReportField NewField51;
                public TTReportField NewField520;
                public TTReportField NewField52;
                public TTReportField KIMLIKNO;
                public TTReportField TCNO;
                public TTReportField NewField112;
                public TTReportField DYER;
                public TTReportField NewField1211;
                public TTReportField ASKSUBE; 
                public ANAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 110;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    FRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 53, 86, 66, false);
                    FRESOURCE.Name = "FRESOURCE";
                    FRESOURCE.DrawStyle = DrawStyleConstants.vbSolid;
                    FRESOURCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    FRESOURCE.DrawWidth = 2;
                    FRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FRESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    FRESOURCE.WordBreak = EvetHayirEnum.ehEvet;
                    FRESOURCE.TextFont.Name = "Arial Narrow";
                    FRESOURCE.TextFont.Size = 8;
                    FRESOURCE.Value = @"{#ARKASAYFA.FRESOURCE#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 66, 36, 81, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField3.DrawWidth = 2;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"Muayeneye gönderen makam :";

                    NewField53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 16, 196, 66, false);
                    NewField53.Name = "NewField53";
                    NewField53.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField53.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField53.DrawWidth = 2;
                    NewField53.TextFont.Name = "Arial Narrow";
                    NewField53.Value = @"";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 66, 110, 71, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField21.DrawWidth = 2;
                    NewField21.MultiLine = EvetHayirEnum.ehEvet;
                    NewField21.WordBreak = EvetHayirEnum.ehEvet;
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.TextFont.Size = 9;
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @"D. Tarihi";

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 36, 25, false);
                    NewField0.Name = "NewField0";
                    NewField0.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField0.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField0.MultiLine = EvetHayirEnum.ehEvet;
                    NewField0.WordBreak = EvetHayirEnum.ehEvet;
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.TextFont.Size = 9;
                    NewField0.TextFont.Bold = true;
                    NewField0.Value = @"Muayene Yapan Sağlık Kurulu































































































";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 36, 66, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1.DrawWidth = 2;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"XXXXXXde tedavide iken sağlık kuruluna sevk eden servis";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 38, 36, 43, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField4.DrawWidth = 2;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"Karantina Nu";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 81, 36, 86, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField5.DrawWidth = 2;
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.TextFont.Size = 9;
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"Emir Tarihi";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 36, 30, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField6.DrawWidth = 2;
                    NewField6.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Size = 9;
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"Rapor Numarası";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 91, 110, 101, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField7.DrawWidth = 2;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 9;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Ne maksatla muayene edildiği";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 43, 36, 48, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField8.DrawWidth = 2;
                    NewField8.MultiLine = EvetHayirEnum.ehEvet;
                    NewField8.WordBreak = EvetHayirEnum.ehEvet;
                    NewField8.TextFont.Name = "Arial Narrow";
                    NewField8.TextFont.Size = 9;
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"XXXXXXye Giriş";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 36, 53, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField10.DrawWidth = 2;
                    NewField10.MultiLine = EvetHayirEnum.ehEvet;
                    NewField10.WordBreak = EvetHayirEnum.ehEvet;
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 9;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"XXXXXXden Çıkış";

                    MAKSAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 91, 196, 101, false);
                    MAKSAD.Name = "MAKSAD";
                    MAKSAD.DrawStyle = DrawStyleConstants.vbSolid;
                    MAKSAD.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAKSAD.DrawWidth = 2;
                    MAKSAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKSAD.MultiLine = EvetHayirEnum.ehEvet;
                    MAKSAD.WordBreak = EvetHayirEnum.ehEvet;
                    MAKSAD.TextFont.Name = "Arial Narrow";
                    MAKSAD.TextFont.Size = 8;
                    MAKSAD.Value = @"{#ARKASAYFA.SKSEBEBI#}";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 66, 86, 81, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.DrawStyle = DrawStyleConstants.vbSolid;
                    MAKAM.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAKAM.DrawWidth = 2;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    MAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    MAKAM.TextFont.Name = "Arial Narrow";
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 30, 86, 38, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORTARIHI.DrawWidth = 2;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.TextFont.Name = "Arial Narrow";
                    RAPORTARIHI.TextFont.Size = 8;
                    RAPORTARIHI.Value = @"{#ARKASAYFA.RAPORTARIHI#}";

                    KARANTINANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 38, 86, 43, false);
                    KARANTINANO.Name = "KARANTINANO";
                    KARANTINANO.DrawStyle = DrawStyleConstants.vbSolid;
                    KARANTINANO.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARANTINANO.DrawWidth = 2;
                    KARANTINANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARANTINANO.MultiLine = EvetHayirEnum.ehEvet;
                    KARANTINANO.WordBreak = EvetHayirEnum.ehEvet;
                    KARANTINANO.TextFont.Name = "Arial Narrow";
                    KARANTINANO.TextFont.Size = 8;
                    KARANTINANO.Value = @"{#ARKASAYFA.KPROKOLNO#}";

                    YATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 43, 86, 48, false);
                    YATISTARIHI.Name = "YATISTARIHI";
                    YATISTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    YATISTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    YATISTARIHI.DrawWidth = 2;
                    YATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI.TextFormat = @"Short Date";
                    YATISTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    YATISTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    YATISTARIHI.TextFont.Name = "Arial Narrow";
                    YATISTARIHI.TextFont.Size = 8;
                    YATISTARIHI.Value = @"{#ARKASAYFA.HGTARIHI#}";

                    TABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 48, 86, 53, false);
                    TABURCUTARIHI.Name = "TABURCUTARIHI";
                    TABURCUTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCUTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    TABURCUTARIHI.DrawWidth = 2;
                    TABURCUTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUTARIHI.TextFormat = @"Short Date";
                    TABURCUTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCUTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCUTARIHI.TextFont.Name = "Arial Narrow";
                    TABURCUTARIHI.TextFont.Size = 8;
                    TABURCUTARIHI.Value = @"{#ARKASAYFA.TABURCUTARIHI#}";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 16, 164, 25, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField20.DrawWidth = 2;
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField20.TextFont.Name = "Arial Narrow";
                    NewField20.TextFont.Size = 9;
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @"KÜNYE";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 38, 110, 43, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField22.DrawWidth = 2;
                    NewField22.MultiLine = EvetHayirEnum.ehEvet;
                    NewField22.WordBreak = EvetHayirEnum.ehEvet;
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Size = 9;
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @"Adı Soyadı";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 43, 110, 48, false);
                    NewField23.Name = "NewField23";
                    NewField23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField23.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField23.DrawWidth = 2;
                    NewField23.MultiLine = EvetHayirEnum.ehEvet;
                    NewField23.WordBreak = EvetHayirEnum.ehEvet;
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.TextFont.Size = 9;
                    NewField23.TextFont.Bold = true;
                    NewField23.Value = @"Baba Adı";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 48, 110, 53, false);
                    NewField25.Name = "NewField25";
                    NewField25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField25.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField25.DrawWidth = 2;
                    NewField25.MultiLine = EvetHayirEnum.ehEvet;
                    NewField25.WordBreak = EvetHayirEnum.ehEvet;
                    NewField25.TextFont.Name = "Arial Narrow";
                    NewField25.TextFont.Size = 9;
                    NewField25.TextFont.Bold = true;
                    NewField25.Value = @"Sınıf Rütbe";

                    LBLSICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 53, 110, 66, false);
                    LBLSICIL.Name = "LBLSICIL";
                    LBLSICIL.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLSICIL.FillStyle = FillStyleConstants.vbFSTransparent;
                    LBLSICIL.DrawWidth = 2;
                    LBLSICIL.MultiLine = EvetHayirEnum.ehEvet;
                    LBLSICIL.WordBreak = EvetHayirEnum.ehEvet;
                    LBLSICIL.TextFont.Name = "Arial Narrow";
                    LBLSICIL.TextFont.Size = 9;
                    LBLSICIL.TextFont.Bold = true;
                    LBLSICIL.Value = @"Sicil Nu";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 38, 164, 43, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    NAME.DrawWidth = 2;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 8;
                    NAME.Value = @"{#ARKASAYFA.PNAME#} {#ARKASAYFA.PSURNAME#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 43, 164, 48, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    FATHERNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    FATHERNAME.DrawWidth = 2;
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    FATHERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    FATHERNAME.TextFont.Name = "Arial Narrow";
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.Value = @"{#ARKASAYFA.FATHERNAME#}";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 30, 164, 38, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRLIK.DrawWidth = 2;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.Value = @"";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 48, 164, 53, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.DrawStyle = DrawStyleConstants.vbSolid;
                    SINIFRUTBE.FillStyle = FillStyleConstants.vbFSTransparent;
                    SINIFRUTBE.DrawWidth = 2;
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.WordBreak = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.TextFont.Name = "Arial Narrow";
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 53, 164, 66, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SICILNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    SICILNO.DrawWidth = 2;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 8;
                    SICILNO.Value = @"";

                    NewField33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 81, 110, 91, false);
                    NewField33.Name = "NewField33";
                    NewField33.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField33.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField33.DrawWidth = 2;
                    NewField33.MultiLine = EvetHayirEnum.ehEvet;
                    NewField33.WordBreak = EvetHayirEnum.ehEvet;
                    NewField33.TextFont.Name = "Arial Narrow";
                    NewField33.TextFont.Size = 9;
                    NewField33.TextFont.Bold = true;
                    NewField33.Value = @"Devamlı Adresi";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 81, 196, 91, false);
                    ADRES.Name = "ADRES";
                    ADRES.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRES.FillStyle = FillStyleConstants.vbFSTransparent;
                    ADRES.DrawWidth = 2;
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Name = "Arial Narrow";
                    ADRES.TextFont.Size = 8;
                    ADRES.Value = @"{#ARKASAYFA.ADRES#}";

                    DTYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 66, 164, 71, false);
                    DTYER.Name = "DTYER";
                    DTYER.DrawStyle = DrawStyleConstants.vbSolid;
                    DTYER.FillStyle = FillStyleConstants.vbFSTransparent;
                    DTYER.DrawWidth = 2;
                    DTYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTYER.TextFormat = @"Short Date";
                    DTYER.MultiLine = EvetHayirEnum.ehEvet;
                    DTYER.WordBreak = EvetHayirEnum.ehEvet;
                    DTYER.TextFont.Name = "Arial Narrow";
                    DTYER.TextFont.Size = 8;
                    DTYER.Value = @"{#ARKASAYFA.DTARIHI#}";

                    SKBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 16, 86, 25, false);
                    SKBASLIK.Name = "SKBASLIK";
                    SKBASLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    SKBASLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    SKBASLIK.DrawWidth = 2;
                    SKBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    SKBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    SKBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    SKBASLIK.TextFont.Name = "Arial Narrow";
                    SKBASLIK.TextFont.Size = 9;
                    SKBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SKRAPORHEADER"","""")";

                    EMIRTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 81, 86, 86, false);
                    EMIRTARIHI.Name = "EMIRTARIHI";
                    EMIRTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    EMIRTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    EMIRTARIHI.DrawWidth = 2;
                    EMIRTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRTARIHI.TextFormat = @"dd\-mm\-yyyy";
                    EMIRTARIHI.TextFont.Name = "Arial Narrow";
                    EMIRTARIHI.TextFont.Size = 8;
                    EMIRTARIHI.Value = @"{#ARKASAYFA.EVRAKTARIHI#}";

                    NewField40 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 86, 36, 91, false);
                    NewField40.Name = "NewField40";
                    NewField40.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField40.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField40.DrawWidth = 2;
                    NewField40.MultiLine = EvetHayirEnum.ehEvet;
                    NewField40.WordBreak = EvetHayirEnum.ehEvet;
                    NewField40.TextFont.Name = "Arial Narrow";
                    NewField40.TextFont.Size = 9;
                    NewField40.TextFont.Bold = true;
                    NewField40.Value = @"Emir Şube ve Nu";

                    EMIRNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 86, 86, 91, false);
                    EMIRNO.Name = "EMIRNO";
                    EMIRNO.DrawStyle = DrawStyleConstants.vbSolid;
                    EMIRNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    EMIRNO.DrawWidth = 2;
                    EMIRNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRNO.TextFont.Name = "Arial Narrow";
                    EMIRNO.TextFont.Size = 8;
                    EMIRNO.Value = @"{#ARKASAYFA.EVRAKSAYISI#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 25, 86, 30, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORNO.DrawWidth = 2;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 8;
                    RAPORNO.Value = @"{#ARKASAYFA.RAPORNO#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 30, 36, 38, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField2.DrawWidth = 2;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Rapor Tarihi";

                    NewField42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 96, 22, 101, false);
                    NewField42.Name = "NewField42";
                    NewField42.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField42.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField42.DrawWidth = 2;
                    NewField42.MultiLine = EvetHayirEnum.ehEvet;
                    NewField42.WordBreak = EvetHayirEnum.ehEvet;
                    NewField42.TextFont.Name = "Arial Narrow";
                    NewField42.TextFont.Size = 9;
                    NewField42.TextFont.Bold = true;
                    NewField42.Value = @"Ağırlık";

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 96, 66, 101, false);
                    NewField44.Name = "NewField44";
                    NewField44.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField44.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField44.DrawWidth = 2;
                    NewField44.MultiLine = EvetHayirEnum.ehEvet;
                    NewField44.WordBreak = EvetHayirEnum.ehEvet;
                    NewField44.TextFont.Name = "Arial Narrow";
                    NewField44.Value = @"Soluk Verme";

                    NewField45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 91, 22, 96, false);
                    NewField45.Name = "NewField45";
                    NewField45.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField45.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField45.DrawWidth = 2;
                    NewField45.MultiLine = EvetHayirEnum.ehEvet;
                    NewField45.WordBreak = EvetHayirEnum.ehEvet;
                    NewField45.TextFont.Name = "Arial Narrow";
                    NewField45.TextFont.Size = 9;
                    NewField45.TextFont.Bold = true;
                    NewField45.Value = @"Boy";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 91, 48, 96, false);
                    BOY.Name = "BOY";
                    BOY.DrawStyle = DrawStyleConstants.vbSolid;
                    BOY.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOY.DrawWidth = 2;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.MultiLine = EvetHayirEnum.ehEvet;
                    BOY.WordBreak = EvetHayirEnum.ehEvet;
                    BOY.TextFont.Name = "Arial Narrow";
                    BOY.TextFont.Size = 8;
                    BOY.Value = @"{#ARKASAYFA.BOY#}";

                    NewField48 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 91, 66, 96, false);
                    NewField48.Name = "NewField48";
                    NewField48.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField48.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField48.DrawWidth = 2;
                    NewField48.MultiLine = EvetHayirEnum.ehEvet;
                    NewField48.WordBreak = EvetHayirEnum.ehEvet;
                    NewField48.TextFont.Name = "Arial Narrow";
                    NewField48.Value = @"Soluk Alma";

                    AGIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 96, 48, 101, false);
                    AGIRLIK.Name = "AGIRLIK";
                    AGIRLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    AGIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    AGIRLIK.DrawWidth = 2;
                    AGIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    AGIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    AGIRLIK.TextFont.Name = "Arial Narrow";
                    AGIRLIK.TextFont.Size = 8;
                    AGIRLIK.Value = @"{#ARKASAYFA.KILO#}";

                    SKNEFESVERME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 96, 86, 101, false);
                    SKNEFESVERME.Name = "SKNEFESVERME";
                    SKNEFESVERME.DrawStyle = DrawStyleConstants.vbSolid;
                    SKNEFESVERME.FillStyle = FillStyleConstants.vbFSTransparent;
                    SKNEFESVERME.DrawWidth = 2;
                    SKNEFESVERME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKNEFESVERME.MultiLine = EvetHayirEnum.ehEvet;
                    SKNEFESVERME.WordBreak = EvetHayirEnum.ehEvet;
                    SKNEFESVERME.TextFont.Name = "Arial Narrow";
                    SKNEFESVERME.TextFont.Size = 8;
                    SKNEFESVERME.Value = @"";

                    SKNEFESALMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 91, 86, 96, false);
                    SKNEFESALMA.Name = "SKNEFESALMA";
                    SKNEFESALMA.DrawStyle = DrawStyleConstants.vbSolid;
                    SKNEFESALMA.FillStyle = FillStyleConstants.vbFSTransparent;
                    SKNEFESALMA.DrawWidth = 2;
                    SKNEFESALMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKNEFESALMA.MultiLine = EvetHayirEnum.ehEvet;
                    SKNEFESALMA.WordBreak = EvetHayirEnum.ehEvet;
                    SKNEFESALMA.TextFont.Name = "Arial Narrow";
                    SKNEFESALMA.TextFont.Size = 8;
                    SKNEFESALMA.Value = @"";

                    NewField49 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 66, 196, 81, false);
                    NewField49.Name = "NewField49";
                    NewField49.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField49.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField49.DrawWidth = 2;
                    NewField49.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField49.MultiLine = EvetHayirEnum.ehEvet;
                    NewField49.WordBreak = EvetHayirEnum.ehEvet;
                    NewField49.TextFont.Name = "Arial Narrow";
                    NewField49.TextFont.Size = 8;
                    NewField49.Value = @"Kaçıncı işlemi
(Sağlık fişine göre)";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 30, 110, 38, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField24.DrawWidth = 2;
                    NewField24.MultiLine = EvetHayirEnum.ehEvet;
                    NewField24.WordBreak = EvetHayirEnum.ehEvet;
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Size = 9;
                    NewField24.TextFont.Bold = true;
                    NewField24.Value = @"Birlik";

                    MUAMELESAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 76, 194, 80, false);
                    MUAMELESAYISI.Name = "MUAMELESAYISI";
                    MUAMELESAYISI.FillStyle = FillStyleConstants.vbFSTransparent;
                    MUAMELESAYISI.DrawWidth = 2;
                    MUAMELESAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAMELESAYISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MUAMELESAYISI.MultiLine = EvetHayirEnum.ehEvet;
                    MUAMELESAYISI.WordBreak = EvetHayirEnum.ehEvet;
                    MUAMELESAYISI.TextFont.Name = "Arial Narrow";
                    MUAMELESAYISI.TextFont.Size = 8;
                    MUAMELESAYISI.Value = @"{#ARKASAYFA.MUAMELESAYISI#}";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 101, 48, 110, false);
                    NewField51.Name = "NewField51";
                    NewField51.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField51.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField51.DrawWidth = 2;
                    NewField51.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField51.MultiLine = EvetHayirEnum.ehEvet;
                    NewField51.WordBreak = EvetHayirEnum.ehEvet;
                    NewField51.TextFont.Name = "Arial Narrow";
                    NewField51.TextFont.Size = 9;
                    NewField51.TextFont.Bold = true;
                    NewField51.Value = @"Muayene ve tetkik yapan servis ve  laboratuvarlar";

                    NewField520 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 101, 196, 110, false);
                    NewField520.Name = "NewField520";
                    NewField520.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField520.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField520.DrawWidth = 2;
                    NewField520.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField520.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField520.TextFont.Name = "Arial Narrow";
                    NewField520.TextFont.Size = 9;
                    NewField520.TextFont.Bold = true;
                    NewField520.Value = @"BULGULAR";

                    NewField52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 187, 14, false);
                    NewField52.Name = "NewField52";
                    NewField52.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField52.TextFont.Name = "Arial Narrow";
                    NewField52.TextFont.Size = 14;
                    NewField52.TextFont.Bold = true;
                    NewField52.Value = @"TÜRK SİLAHLI KUVVETLERİ SAĞLIK RAPORU";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 25, 110, 30, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    KIMLIKNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    KIMLIKNO.DrawWidth = 2;
                    KIMLIKNO.TextFont.Name = "Arial Narrow";
                    KIMLIKNO.TextFont.Size = 9;
                    KIMLIKNO.TextFont.Bold = true;
                    KIMLIKNO.Value = @"T.C. Kimlik Nu";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 25, 164, 30, false);
                    TCNO.Name = "TCNO";
                    TCNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TCNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    TCNO.DrawWidth = 2;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.TextFont.Name = "Arial Narrow";
                    TCNO.TextFont.Size = 9;
                    TCNO.Value = @"{#ARKASAYFA.TCNO#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 71, 111, 76, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField112.DrawWidth = 2;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.TextFont.Size = 9;
                    NewField112.TextFont.Bold = true;
                    NewField112.Value = @"Doğum Yeri";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 71, 164, 76, false);
                    DYER.Name = "DYER";
                    DYER.DrawStyle = DrawStyleConstants.vbSolid;
                    DYER.FillStyle = FillStyleConstants.vbFSTransparent;
                    DYER.DrawWidth = 2;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFormat = @"Short Date";
                    DYER.MultiLine = EvetHayirEnum.ehEvet;
                    DYER.WordBreak = EvetHayirEnum.ehEvet;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 8;
                    DYER.Value = @"{#ARKASAYFA.DTARIHI#}";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 76, 110, 81, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1211.DrawWidth = 2;
                    NewField1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211.TextFont.Name = "Arial Narrow";
                    NewField1211.TextFont.Size = 8;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.Value = @"Kayıtlı olduğu As. Ş.";

                    ASKSUBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 76, 164, 81, false);
                    ASKSUBE.Name = "ASKSUBE";
                    ASKSUBE.DrawStyle = DrawStyleConstants.vbSolid;
                    ASKSUBE.FillStyle = FillStyleConstants.vbFSTransparent;
                    ASKSUBE.DrawWidth = 2;
                    ASKSUBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASKSUBE.TextFormat = @"Short Date";
                    ASKSUBE.MultiLine = EvetHayirEnum.ehEvet;
                    ASKSUBE.WordBreak = EvetHayirEnum.ehEvet;
                    ASKSUBE.TextFont.Name = "Arial Narrow";
                    ASKSUBE.TextFont.Size = 8;
                    ASKSUBE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.ARKASAYFA.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    FRESOURCE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Fresource) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField53.CalcValue = NewField53.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField0.CalcValue = NewField0.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField10.CalcValue = NewField10.Value;
                    MAKSAD.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Sksebebi) : "");
                    MAKAM.CalcValue = @"";
                    RAPORTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    KARANTINANO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Kprokolno) : "");
                    YATISTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Hgtarihi) : "");
                    TABURCUTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Taburcutarihi) : "");
                    NewField20.CalcValue = NewField20.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField25.CalcValue = NewField25.Value;
                    LBLSICIL.CalcValue = LBLSICIL.Value;
                    NAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    FATHERNAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    BIRLIK.CalcValue = @"";
                    SINIFRUTBE.CalcValue = @"";
                    SICILNO.CalcValue = @"";
                    NewField33.CalcValue = NewField33.Value;
                    ADRES.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Adres) : "");
                    DTYER.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    EMIRTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraktarihi) : "");
                    NewField40.CalcValue = NewField40.Value;
                    EMIRNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraksayisi) : "");
                    RAPORNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "");
                    NewField2.CalcValue = NewField2.Value;
                    NewField42.CalcValue = NewField42.Value;
                    NewField44.CalcValue = NewField44.Value;
                    NewField45.CalcValue = NewField45.Value;
                    BOY.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Boy) : "");
                    NewField48.CalcValue = NewField48.Value;
                    AGIRLIK.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Kilo) : "");
                    SKNEFESVERME.CalcValue = @"";
                    SKNEFESALMA.CalcValue = @"";
                    NewField49.CalcValue = NewField49.Value;
                    NewField24.CalcValue = NewField24.Value;
                    MUAMELESAYISI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Muamelesayisi) : "");
                    NewField51.CalcValue = NewField51.Value;
                    NewField520.CalcValue = NewField520.Value;
                    NewField52.CalcValue = NewField52.Value;
                    KIMLIKNO.CalcValue = KIMLIKNO.Value;
                    TCNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    NewField112.CalcValue = NewField112.Value;
                    DYER.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    NewField1211.CalcValue = NewField1211.Value;
                    ASKSUBE.CalcValue = @"";
                    SKBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SKRAPORHEADER","");
                    return new TTReportObject[] { FRESOURCE,NewField3,NewField53,NewField21,NewField0,NewField1,NewField4,NewField5,NewField6,NewField7,NewField8,NewField10,MAKSAD,MAKAM,RAPORTARIHI,KARANTINANO,YATISTARIHI,TABURCUTARIHI,NewField20,NewField22,NewField23,NewField25,LBLSICIL,NAME,FATHERNAME,BIRLIK,SINIFRUTBE,SICILNO,NewField33,ADRES,DTYER,EMIRTARIHI,NewField40,EMIRNO,RAPORNO,NewField2,NewField42,NewField44,NewField45,BOY,NewField48,AGIRLIK,SKNEFESVERME,SKNEFESALMA,NewField49,NewField24,MUAMELESAYISI,NewField51,NewField520,NewField52,KIMLIKNO,TCNO,NewField112,DYER,NewField1211,ASKSUBE,SKBASLIK};
                }
                public override void RunPreScript()
                {
#region ANA HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealtCommittee is null");
            
//            MilitaryClassDefinitions pMilClass = hc.Episode.MyMilitaryClass();
//            RankDefinitions pRank = hc.Episode.MyRank();
//            
//            this.SINIFRUTBE.Value = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
#endregion ANA HEADER_PreScript
                }
            }
            public partial class ANAGroupFooter : TTReportSection
            {
                public HealthCommitteeTumourReport MyParentReport
                {
                    get { return (HealthCommitteeTumourReport)ParentReport; }
                }
                
                public TTReportShape shape13; 
                public ANAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    shape13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 196, 0, false);
                    shape13.Name = "shape13";
                    shape13.DrawStyle = DrawStyleConstants.vbSolid;
                    shape13.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.ARKASAYFA.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public ANAGroup ANA;

        public partial class OLCUMGroup : TTReportGroup
        {
            public HealthCommitteeTumourReport MyParentReport
            {
                get { return (HealthCommitteeTumourReport)ParentReport; }
            }

            new public OLCUMGroupHeader Header()
            {
                return (OLCUMGroupHeader)_header;
            }

            new public OLCUMGroupFooter Footer()
            {
                return (OLCUMGroupFooter)_footer;
            }

            public TTReportField PATINFO { get {return Header().PATINFO;} }
            public TTReportField DTARIHI { get {return Header().DTARIHI;} }
            public TTReportShape shape12 { get {return Footer().shape12;} }
            public TTReportShape shape11 { get {return Footer().shape11;} }
            public TTReportShape shape10 { get {return Footer().shape10;} }
            public TTReportField OLCUMLER { get {return Footer().OLCUMLER;} }
            public TTReportField BOY { get {return Footer().BOY;} }
            public TTReportField KILO { get {return Footer().KILO;} }
            public OLCUMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public OLCUMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new OLCUMGroupHeader(this);
                _footer = new OLCUMGroupFooter(this);

            }

            public partial class OLCUMGroupHeader : TTReportSection
            {
                public HealthCommitteeTumourReport MyParentReport
                {
                    get { return (HealthCommitteeTumourReport)ParentReport; }
                }
                
                public TTReportField PATINFO;
                public TTReportField DTARIHI; 
                public OLCUMGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PATINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 2, 194, 7, false);
                    PATINFO.Name = "PATINFO";
                    PATINFO.FillStyle = FillStyleConstants.vbFSTransparent;
                    PATINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATINFO.TextFont.Name = "Arial Narrow";
                    PATINFO.Value = @"{#ARKASAYFA.PNAME#} {#ARKASAYFA.PSURNAME#} ({%DTARIHI%}) {#ARKASAYFA.ISLEMNO#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 3, 238, 8, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#ARKASAYFA.DTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.ARKASAYFA.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    DTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    PATINFO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "") + @" (" + MyParentReport.OLCUM.DTARIHI.FormattedValue + @") " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
                    return new TTReportObject[] { DTARIHI,PATINFO};
                }
            }
            public partial class OLCUMGroupFooter : TTReportSection
            {
                public HealthCommitteeTumourReport MyParentReport
                {
                    get { return (HealthCommitteeTumourReport)ParentReport; }
                }
                
                public TTReportShape shape12;
                public TTReportShape shape11;
                public TTReportShape shape10;
                public TTReportField OLCUMLER;
                public TTReportField BOY;
                public TTReportField KILO; 
                public OLCUMGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    shape12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 3, 10, 8, false);
                    shape12.Name = "shape12";
                    shape12.DrawStyle = DrawStyleConstants.vbSolid;
                    shape12.DrawWidth = 2;
                    shape12.ExtendTo = ExtendToEnum.extPageHeight;

                    shape11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 3, 48, 8, false);
                    shape11.Name = "shape11";
                    shape11.DrawStyle = DrawStyleConstants.vbSolid;
                    shape11.DrawWidth = 2;
                    shape11.ExtendTo = ExtendToEnum.extPageHeight;

                    shape10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 3, 196, 8, false);
                    shape10.Name = "shape10";
                    shape10.DrawStyle = DrawStyleConstants.vbSolid;
                    shape10.DrawWidth = 2;
                    shape10.ExtendTo = ExtendToEnum.extPageHeight;

                    OLCUMLER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 4, 195, 9, false);
                    OLCUMLER.Name = "OLCUMLER";
                    OLCUMLER.FillStyle = FillStyleConstants.vbFSTransparent;
                    OLCUMLER.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUMLER.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUMLER.NoClip = EvetHayirEnum.ehEvet;
                    OLCUMLER.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUMLER.ExpandTabs = EvetHayirEnum.ehEvet;
                    OLCUMLER.TextFont.Name = "Arial Narrow";
                    OLCUMLER.TextFont.Size = 7;
                    OLCUMLER.Value = @"";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 239, 6, false);
                    BOY.Name = "BOY";
                    BOY.Visible = EvetHayirEnum.ehHayir;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.Value = @"{#ARKASAYFA.BOY#}";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 6, 239, 11, false);
                    KILO.Name = "KILO";
                    KILO.Visible = EvetHayirEnum.ehHayir;
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.Value = @"{#ARKASAYFA.KILO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = MyParentReport.ARKASAYFA.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    OLCUMLER.CalcValue = @"";
                    BOY.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Boy) : "");
                    KILO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Kilo) : "");
                    return new TTReportObject[] { OLCUMLER,BOY,KILO};
                }
                public override void RunPreScript()
                {
#region OLCUM FOOTER_PreScript
                    if (this.BOY.CalcValue != "" || this.KILO.CalcValue != "")
            {
                string sMeasure = "Sağlık Kurulu Huzurunda Ölçülmüştür:";
                string s1 = "",s2 = "";
                
                if (this.BOY.CalcValue != "") s1="Boy:" + this.BOY.CalcValue + " cm.";
                if (this.KILO.CalcValue != "" ) s2 ="Ağırlık:" + this.KILO.CalcValue + " kg.";

                this.OLCUMLER.Value = sMeasure + "\r\n" + s1 + "\r\n" + s2 + "\r\n";
            }
#endregion OLCUM FOOTER_PreScript
                }
            }

        }

        public OLCUMGroup OLCUM;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeTumourReport MyParentReport
            {
                get { return (HealthCommitteeTumourReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField YENIBOLUM { get {return Body().YENIBOLUM;} }
            public TTReportShape shape6 { get {return Body().shape6;} }
            public TTReportField BOLUMRAPOR { get {return Body().BOLUMRAPOR;} }
            public TTReportField BOLUMRAPOR1 { get {return Body().BOLUMRAPOR1;} }
            public TTReportShape shape8 { get {return Body().shape8;} }
            public TTReportShape shape9 { get {return Body().shape9;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>("GetHCExaminationByMasterAction", HealthCommitteeExamination.GetHCExaminationByMasterAction((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HealthCommitteeTumourReport MyParentReport
                {
                    get { return (HealthCommitteeTumourReport)ParentReport; }
                }
                
                public TTReportField YENIBOLUM;
                public TTReportShape shape6;
                public TTReportField BOLUMRAPOR;
                public TTReportField BOLUMRAPOR1;
                public TTReportShape shape8;
                public TTReportShape shape9;
                public TTReportField RAPORTARIHI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    YENIBOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 47, 13, false);
                    YENIBOLUM.Name = "YENIBOLUM";
                    YENIBOLUM.FillStyle = FillStyleConstants.vbFSTransparent;
                    YENIBOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIBOLUM.CaseFormat = CaseFormatEnum.fcTitleCase;
                    YENIBOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    YENIBOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    YENIBOLUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    YENIBOLUM.TextFont.Name = "Arial Narrow";
                    YENIBOLUM.TextFont.Size = 7;
                    YENIBOLUM.Value = @"{#BOLUM#} ({#RAPORNO#} / {%RAPORTARIHI%}) Raporu";

                    shape6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 10, 8, false);
                    shape6.Name = "shape6";
                    shape6.DrawStyle = DrawStyleConstants.vbSolid;
                    shape6.DrawWidth = 2;
                    shape6.ExtendTo = ExtendToEnum.extPageHeight;

                    BOLUMRAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 0, 190, 3, false);
                    BOLUMRAPOR.Name = "BOLUMRAPOR";
                    BOLUMRAPOR.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUMRAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR.TextFont.Size = 7;
                    BOLUMRAPOR.Value = @"{#RAPOR#}";

                    BOLUMRAPOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 5, 97, 7, false);
                    BOLUMRAPOR1.Name = "BOLUMRAPOR1";
                    BOLUMRAPOR1.Visible = EvetHayirEnum.ehHayir;
                    BOLUMRAPOR1.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOLUMRAPOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMRAPOR1.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.NoClip = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BOLUMRAPOR1.TextFont.Name = "Arial Narrow";
                    BOLUMRAPOR1.TextFont.Size = 7;
                    BOLUMRAPOR1.Value = @"{#DOKTORADI#}
{#DOKTORSINIFI#} {#DOKTORRUTBE#}
{#DOKTORUNVAN#}";

                    shape8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 1, 48, 8, false);
                    shape8.Name = "shape8";
                    shape8.DrawStyle = DrawStyleConstants.vbSolid;
                    shape8.DrawWidth = 2;
                    shape8.ExtendTo = ExtendToEnum.extPageHeight;

                    shape9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 1, 196, 8, false);
                    shape9.Name = "shape9";
                    shape9.DrawStyle = DrawStyleConstants.vbSolid;
                    shape9.DrawWidth = 2;
                    shape9.ExtendTo = ExtendToEnum.extPageHeight;

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 3, 239, 8, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.Visible = EvetHayirEnum.ehHayir;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeExamination.GetHCExaminationByMasterAction_Class dataset_GetHCExaminationByMasterAction = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>(0);
                    RAPORTARIHI.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raportarihi) : "");
                    YENIBOLUM.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Bolum) : "") + @" (" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Raporno) : "") + @" / " + MyParentReport.MAIN.RAPORTARIHI.FormattedValue + @") Raporu";
                    BOLUMRAPOR.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Rapor) : "");
                    BOLUMRAPOR1.CalcValue = (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktoradi) : "") + @"
" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorsinifi) : "") + @" " + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorrutbe) : "") + @"
" + (dataset_GetHCExaminationByMasterAction != null ? Globals.ToStringCore(dataset_GetHCExaminationByMasterAction.Doktorunvan) : "");
                    return new TTReportObject[] { RAPORTARIHI,YENIBOLUM,BOLUMRAPOR,BOLUMRAPOR1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HealthCommitteeTumourReport()
        {
            ARKASAYFA = new ARKASAYFAGroup(this,"ARKASAYFA");
            ANA = new ANAGroup(ARKASAYFA,"ANA");
            OLCUM = new OLCUMGroup(ANA,"OLCUM");
            MAIN = new MAINGroup(OLCUM,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HEALTHCOMMITTEETUMOURREPORT";
            Caption = "Sağlık Kurulu Raporu";
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
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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