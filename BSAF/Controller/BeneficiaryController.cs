using BSAF.Entity;
using BSAF.Models;
using BSAF.Models.Tables;
using BSAF.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BSAF.Helper
{
    public class BeneficiaryController
    {
        public static int Add(BeneficiaryVM model)
        {
            dbContext db = new dbContext();

            var bene = model;
            //if(string.IsNullOrEmpty(UserInfo.ID) && string.IsNullOrEmpty(UserInfo.StationCode))
            //{
            //    return false;
            //}
            using (var trans = db.Database.BeginTransaction())
            {
                try
                {
                    var beneficiary = new Beneficiary
                    {
                        CardID = GetCardID(),
                        ScreeningDate = model.ScreeningDate,
                        ProvinceBCP = model.ProvinceBCP,
                        BorderPoint = model.BorderPoint,
                        BeneficiaryType = model.BeneficiaryType,
                        ReturnStatus = model.ReturnStatus,
                        OriginProvince = model.OriginProvince,
                        OriginDistrict = model.OriginDistrict,
                        OriginVillage = model.OriginVillage,
                        ReturnProvince = model.ReturnProvince,
                        ReturnDistrict = model.ReturnDistrict,
                        ReturnVillage = model.ReturnVillage,
                        LeavingReason1 = model.LeavingReason1,
                        LeavingReason1Other = model.LeavingReason1Other,
                        LeavingReason2 = model.LeavingReason2,
                        LeavingReason2Other = model.LeavingReason2Other,
                        LeavingReason3 = model.LeavingReason3,
                        LeavingReason3Other = model.LeavingReason3Other,
                        OwnHouse = model.OwnHouse,
                        WhereWillLive = model.WhereWillLive,
                        RentPayForAccom = model.RentPayForAccom,
                        RentPayCurrency = model.RentPayCurrency,
                        AllowForJob = model.AllowForJob,
                        CountryOfExile = model.CountryOfExile,
                        CountryOfExilOther = model.CountryOfExilOther,
                        BeforReturnProvince = model.BeforReturnProvince,
                        BeforReturnDistrictID = model.BeforReturnDistrictID,
                        BeforReturnRemarks = model.BeforReturnRemarks,
                        FamilyMemStayedBehind = model.FamilyMemStayedBehind,
                        FamilyMemStayedBehindNo = model.FamilyMemStayedBehindNo,
                        LengthOfStayYears = model.LengthOfStayYears,
                        LengthOfStayMonths = model.LengthOfStayMonths,
                        LengthOfStayDays = model.LengthOfStayDays,
                        WouldYouReturn = model.WouldYouReturn,
                        HaveFamilyBenefited = model.HaveFamilyBenefited,
                        TransportationDate = model.TransportationDate,
                        TransportationInfo = model.TransportationInfo,
                        TransportAccompaniedBy = model.TransportAccompaniedBy,
                        TransportAccomByNo = model.TransportAccomByNo,
                        TopNeed1 = model.TopNeed1,
                        TopNeed1Other = model.TopNeed1Other,
                        TopNeed2 = model.TopNeed2,
                        TopNeed2Other = model.TopNeed2Other,
                        TopNeed3 = model.TopNeed3,
                        TopNeed3Other = model.TopNeed3Other,
                        IntendToDo = model.IntendToDo,
                        IntendToReturnToHostReason = model.IntendToReturnToHostReason,
                        ProfessionInHostCountry = model.ProfessionInHostCountry,
                        ProfessionInHostCountryOther = model.ProfessionInHostCountryOther,
                        HoHCanReadWrite = model.HoHCanReadWrite,
                        HoHEducationLevel = model.HoHEducationLevel,
                        HoHEducationLevelOther = model.HoHEducationLevelOther,
                        NumHHHaveTaskira = model.NumHHHaveTaskira,
                        NumHHHavePassport = model.NumHHHavePassport,
                        NumHHHaveDocOther = model.NumHHHaveDocOther,
                        DoHaveSecureLivelihood = model.DoHaveSecureLivelihood,
                        DidChildrenGoToSchoole = model.DidChildrenGoToSchoole,
                        NumChildrenAttendedSchoole = model.NumChildrenAttendedSchoole,
                        Photo = model.Photo,
                        IsCardIssued = model.IsCardIssued,
                        //TODO: add user information from db
                        InsertedBy = UserInfo.ID,
                        InsertedDate = DateTime.Now,
                        //END TODO
                        IsActive = true
                    };
                    db.Beneficiaries.Add(beneficiary);
                    db.SaveChanges();
                    var setting = db.UserSettings.FirstOrDefault();
                    setting.RecentReturnNumber = setting.RecentReturnNumber + 1;
                    db.SaveChanges();

                    foreach (var ind in model.Individuals)
                    {
                        var member = new Individual {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            Name = ind.Name,
                            DrName = ind.DrName,
                            FName = ind.FName,
                            DrFName = ind.DrFName,
                            GenderCode = ind.GenderCode,
                            MaritalStatusCode = ind.MaritalStatusCode,
                            Age = ind.Age,
                            IDTypeCode = ind.IDTypeCode,
                            IDNo = ind.IDNo,
                            RelationshipCode = ind.RelationshipCode,
                            ContactNumber = ind.ContactNumber
                        };
                        db.Individuals.Add(member);
                    }

                    foreach (var psn in model.PSNs)
                    {
                        var psnObj = new PSN {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            PSNCode = psn.PSNCode,
                            PSNOther = psn.PSNOther
                        };
                        db.PSNs.Add(psnObj);
                    }

                    foreach (var rReason in model.ReturnReasons)
                    {
                        var rrObj = new ReturnReason {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            ReasonCode = rReason.ReasonCode,
                            Other = rReason.Other
                        };
                        db.ReturnReasons.Add(rrObj);
                    }

                    foreach (var d in model.Determinations)
                    {
                        var dObj = new Determination {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            DeterminationCode = d.DeterminationCode,
                            AnswerCode = d.AnswerCode,
                            Other = d.Other
                        };
                        db.Determinations.Add(dObj);
                    }

                    foreach (var m in model.MoneySources)
                    {
                        var moneySObj = new MoneySource {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            MoneySourceCode = m.MoneySourceCode,
                            MoneySourceOther = m.MoneySourceOther
                        };
                        db.MoneySources.Add(moneySObj);
                    }

                    foreach (var bi in model.BroughtItems)
                    {
                        var biObj = new BroughtItem {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            ItemCode = bi.ItemCode,
                            ItemOther = bi.ItemOther
                        };
                        db.BroughtItems.Add(biObj);
                    }

                    foreach (var p in model.PostArrivalNeeds) {
                        var panObj = new PostArrivalNeed {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            NeedCode = p.NeedCode,
                            Provided = p.Provided,
                            ProvidedDate = p.ProvidedDate,
                            Comment = p.Comment
                        };
                        db.PostArrivalNeeds.Add(panObj);
                    }

                    if (model.HaveFamilyBenefited == true)
                    {
                        foreach (var a in model.BenefitedFromOrgs)
                        {
                            var assisOrgInfo = new BenefitedFromOrg
                            {
                                BeneficiaryID = beneficiary.BeneficiaryID,
                                Date = a.Date,
                                ProvinceCode = a.ProvinceCode,
                                DistrictID = a.DistrictID,
                                Village = a.Village,
                                OrgCode = a.OrgCode,
                                AssistanceProvided = a.AssistanceProvided
                            };
                            db.BenefitedFromOrgs.Add(assisOrgInfo);
                        }
                    }

                    foreach (var tran in model.Transportations)
                    {
                        var tranObj = new Transportation {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            TypedCode = tran.TypedCode,
                            Other = tran.Other
                        };
                        db.Transportations.Add(tranObj);
                    }

                    foreach (var li in model.LivelihoodEmpNeeds)
                    {
                        var liObj = new LivelihoodEmpNeed {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            NeedCode = li.NeedCode
                        };
                        db.LivelihoodEmpNeeds.Add(liObj);
                    }

                    foreach (var needTool in model.NeedTools)
                    {
                        var needToolObj = new NeedTool {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            ToolCode = needTool.ToolCode,
                            Other = needTool.Other
                        };
                        db.NeedTools.Add(needToolObj);
                    }

                    foreach (var mConcern in model.MainConcerns)
                    {
                        var mcObj = new MainConcern {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            ConcernCode = mConcern.ConcernCode,
                            Other = mConcern.Other
                        };
                        db.MainConcerns.Add(mcObj);
                    }

                    foreach (var hc in model.HostCountrySchools)
                    {
                        var hcObj = new HostCountrySchool {
                            BeneficiaryID = beneficiary.BeneficiaryID,
                            SchoolTypeCode = hc.SchoolTypeCode
                        };
                        db.HostCountrySchools.Add(hcObj);
                    }

                    db.SaveChanges();

                    trans.Commit();
                    return beneficiary.BeneficiaryID;
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    return 0;
                }
            }

        }

        public static BeneficiaryVM GetBeneficiary(int? beneficiaryID)
        {
            dbContext db = new dbContext();
            BeneficiaryVM benefVM = new BeneficiaryVM();
            if (beneficiaryID != null && beneficiaryID != 0)
            {
                var benefInDB = db.Beneficiaries.Where(b => b.BeneficiaryID == beneficiaryID && b.IsActive == true).FirstOrDefault();
                if (benefInDB != null)
                {
                    benefVM.BeneficiaryID = benefInDB.BeneficiaryID;
                    benefVM.CardID = benefInDB.CardID;
                    benefVM.ScreeningDate = benefInDB.ScreeningDate;
                    benefVM.ProvinceBCP = benefInDB.ProvinceBCP;
                    benefVM.BorderPoint = benefInDB.BorderPoint;
                    benefVM.BeneficiaryType = benefInDB.BeneficiaryType;
                    benefVM.ReturnStatus = benefInDB.ReturnStatus;
                    benefVM.OriginProvince = benefInDB.OriginProvince;
                    benefVM.OriginDistrict = benefInDB.OriginDistrict;
                    benefVM.OriginVillage = benefInDB.OriginVillage;
                    benefVM.ReturnProvince = benefInDB.ReturnProvince;
                    benefVM.ReturnDistrict = benefInDB.ReturnDistrict;
                    benefVM.ReturnVillage = benefInDB.ReturnVillage;
                    benefVM.LeavingReason1 = benefInDB.LeavingReason1;
                    benefVM.LeavingReason1Other = benefInDB.LeavingReason1Other;
                    benefVM.LeavingReason2 = benefInDB.LeavingReason2;
                    benefVM.LeavingReason2Other = benefInDB.LeavingReason2Other;
                    benefVM.LeavingReason3 = benefInDB.LeavingReason3;
                    benefVM.LeavingReason3Other = benefInDB.LeavingReason3Other;
                    benefVM.OwnHouse = benefInDB.OwnHouse;
                    benefVM.WhereWillLive = benefInDB.WhereWillLive;
                    benefVM.RentPayForAccom = benefInDB.RentPayForAccom;
                    benefVM.RentPayCurrency = benefInDB.RentPayCurrency;
                    benefVM.AllowForJob = benefInDB.AllowForJob;
                    benefVM.CountryOfExile = benefInDB.CountryOfExile;
                    benefVM.CountryOfExilOther = benefInDB.CountryOfExilOther;
                    benefVM.BeforReturnProvince = benefInDB.BeforReturnProvince;
                    benefVM.BeforReturnDistrictID = benefInDB.BeforReturnDistrictID;
                    benefVM.BeforReturnRemarks = benefInDB.BeforReturnRemarks;
                    benefVM.FamilyMemStayedBehind = benefInDB.FamilyMemStayedBehind;
                    benefVM.FamilyMemStayedBehindNo = benefInDB.FamilyMemStayedBehindNo;
                    benefVM.LengthOfStayYears = benefInDB.LengthOfStayYears;
                    benefVM.LengthOfStayMonths = benefInDB.LengthOfStayMonths;
                    benefVM.LengthOfStayDays = benefInDB.LengthOfStayDays;
                    benefVM.WouldYouReturn = benefInDB.WouldYouReturn;
                    benefVM.HaveFamilyBenefited = benefInDB.HaveFamilyBenefited;
                    benefVM.TransportationDate = benefInDB.TransportationDate;
                    benefVM.TransportationInfo = benefInDB.TransportationInfo;
                    benefVM.TransportAccompaniedBy = benefInDB.TransportAccompaniedBy;
                    benefVM.TransportAccomByNo = benefInDB.TransportAccomByNo;
                    benefVM.TopNeed1 = benefInDB.TopNeed1;
                    benefVM.TopNeed1Other = benefInDB.TopNeed1Other;
                    benefVM.TopNeed2 = benefInDB.TopNeed2;
                    benefVM.TopNeed2Other = benefInDB.TopNeed2Other;
                    benefVM.TopNeed3 = benefInDB.TopNeed3;
                    benefVM.TopNeed3Other = benefInDB.TopNeed3Other;
                    benefVM.IntendToDo = benefInDB.IntendToDo;
                    benefVM.IntendToReturnToHostReason = benefInDB.IntendToReturnToHostReason;
                    benefVM.ProfessionInHostCountry = benefInDB.ProfessionInHostCountry;
                    benefVM.ProfessionInHostCountryOther = benefInDB.ProfessionInHostCountryOther;
                    benefVM.HoHCanReadWrite = benefInDB.HoHCanReadWrite;
                    benefVM.HoHEducationLevel = benefInDB.HoHEducationLevel;
                    benefVM.HoHEducationLevelOther = benefInDB.HoHEducationLevelOther;
                    benefVM.NumHHHaveTaskira = benefInDB.NumHHHaveTaskira;
                    benefVM.NumHHHavePassport = benefInDB.NumHHHavePassport;
                    benefVM.NumHHHaveDocOther = benefInDB.NumHHHaveDocOther;
                    benefVM.DoHaveSecureLivelihood = benefInDB.DoHaveSecureLivelihood;
                    benefVM.DidChildrenGoToSchoole = benefInDB.DidChildrenGoToSchoole;
                    benefVM.NumChildrenAttendedSchoole = benefInDB.NumChildrenAttendedSchoole;
                    benefVM.InsertedDate = benefInDB.InsertedDate;
                    benefVM.LastUpdatedBy = benefInDB.LastUpdatedBy;
                    benefVM.LastUpdatedDate = benefInDB.LastUpdatedDate;
                    benefVM.IsActive = benefInDB.IsActive;
                    benefVM.IsSubmitted = benefInDB.IsSubmitted;
                    benefVM.IsCardIssued = benefInDB.IsCardIssued;
                    benefVM.Photo = benefInDB.Photo;
                    if (benefInDB.Photo != null)
                    {
                        Photo.photo = new System.Drawing.Bitmap(new MemoryStream(benefInDB.Photo));
                    }

                }

                List<IndividualVM> individualsInDB = db.Individuals.
                    Where(i => i.BeneficiaryID == beneficiaryID).Select(i =>
                    new IndividualVM {
                        IndividualID = i.IndividualID,
                        BeneficiaryID = i.BeneficiaryID,
                        Name = i.Name,
                        DrName = i.DrName,
                        FName = i.FName,
                        DrFName = i.DrFName,
                        GenderCode = i.GenderCode,
                        Gender = db.LookupValues.Where(l => l.ValueCode == i.GenderCode).Select(l => l.EnName).FirstOrDefault(),
                        MaritalStatusCode = i.MaritalStatusCode,
                        MaritalStatus = db.LookupValues.Where(l => l.ValueCode == i.MaritalStatusCode).Select(l => l.EnName).FirstOrDefault(),
                        Age = i.Age,
                        IDTypeCode = i.IDTypeCode,
                        IDType = db.LookupValues.Where(l => l.ValueCode == i.IDTypeCode).Select(l => l.EnName).FirstOrDefault(),
                        IDNo = i.IDNo,
                        RelationshipCode = i.RelationshipCode,
                        Relationship = db.LookupValues.Where(l => l.ValueCode == i.RelationshipCode).Select(l => l.EnName).FirstOrDefault(),
                        ContactNumber = i.ContactNumber
                    }).ToList();
                benefVM.Individuals = individualsInDB;

                var psnInDB = db.PSNs.Where(p => p.BeneficiaryID == beneficiaryID).ToList();
                benefVM.PSNs = psnInDB;

                var returnReasonsInDB = db.ReturnReasons.Where(r => r.BeneficiaryID == beneficiaryID).ToList();
                benefVM.ReturnReasons = returnReasonsInDB;

                var determinationsInDB = db.Determinations.Where(d => d.BeneficiaryID == beneficiaryID).ToList();
                benefVM.Determinations = determinationsInDB;

                var moneySourcesInDB = db.MoneySources.Where(m => m.BeneficiaryID == beneficiaryID).ToList();
                benefVM.MoneySources = moneySourcesInDB;

                var broughtItemsInDB = db.BroughtItems.Where(b => b.BeneficiaryID == beneficiaryID).ToList();
                benefVM.BroughtItems = broughtItemsInDB;

                var postArivalNeedsInDB = db.PostArrivalNeeds.Where(p => p.BeneficiaryID == beneficiaryID).ToList();
                benefVM.PostArrivalNeeds = postArivalNeedsInDB;

                var benefitedFromOrgs = db.BenefitedFromOrgs.Where(b => b.BeneficiaryID == beneficiaryID).ToList();
                benefVM.BenefitedFromOrgs = benefitedFromOrgs;

                var transportsInDB = db.Transportations.Where(t => t.BeneficiaryID == beneficiaryID).ToList();
                benefVM.Transportations = transportsInDB;

                var livelihoodNeedsInDB = db.LivelihoodEmpNeeds.Where(l => l.BeneficiaryID == beneficiaryID).ToList();
                benefVM.LivelihoodEmpNeeds = livelihoodNeedsInDB;

                var needToolsInDB = db.NeedTools.Where(b => b.BeneficiaryID == beneficiaryID).ToList();
                benefVM.NeedTools = needToolsInDB;

                var mainConcernsInDB = db.MainConcerns.Where(m => m.BeneficiaryID == beneficiaryID).ToList();
                benefVM.MainConcerns = mainConcernsInDB;

                var hostCountryShoolsInDB = db.HostCountrySchools.Where(s => s.BeneficiaryID == beneficiaryID).ToList();
                benefVM.HostCountrySchools = hostCountryShoolsInDB;
            }
            return benefVM;
        }

        internal static int Update(BeneficiaryVM model)
        {
            dbContext db = new dbContext();

            var bene = model;
            using (var trans = db.Database.BeginTransaction())
            {
                try
                {
                    #region Beneficiary update
                    var beneficiaryInDB = db.Beneficiaries.Find(model.BeneficiaryID);
                    beneficiaryInDB.ScreeningDate = model.ScreeningDate;
                    beneficiaryInDB.ProvinceBCP = model.ProvinceBCP;
                    beneficiaryInDB.BorderPoint = model.BorderPoint;
                    beneficiaryInDB.BeneficiaryType = model.BeneficiaryType;
                    beneficiaryInDB.ReturnStatus = model.ReturnStatus;
                    beneficiaryInDB.OriginProvince = model.OriginProvince;
                    beneficiaryInDB.OriginDistrict = model.OriginDistrict;
                    beneficiaryInDB.OriginVillage = model.OriginVillage;
                    beneficiaryInDB.ReturnProvince = model.ReturnProvince;
                    beneficiaryInDB.ReturnDistrict = model.ReturnDistrict;
                    beneficiaryInDB.ReturnVillage = model.ReturnVillage;
                    beneficiaryInDB.LeavingReason1 = model.LeavingReason1;
                    beneficiaryInDB.LeavingReason1Other = model.LeavingReason1Other;
                    beneficiaryInDB.LeavingReason2 = model.LeavingReason2;
                    beneficiaryInDB.LeavingReason2Other = model.LeavingReason2Other;
                    beneficiaryInDB.LeavingReason3 = model.LeavingReason3;
                    beneficiaryInDB.LeavingReason3Other = model.LeavingReason3Other;
                    beneficiaryInDB.OwnHouse = model.OwnHouse;
                    beneficiaryInDB.WhereWillLive = model.WhereWillLive;
                    beneficiaryInDB.RentPayForAccom = model.RentPayForAccom;
                    beneficiaryInDB.RentPayCurrency = model.RentPayCurrency;
                    beneficiaryInDB.AllowForJob = model.AllowForJob;
                    beneficiaryInDB.CountryOfExile = model.CountryOfExile;
                    beneficiaryInDB.CountryOfExilOther = model.CountryOfExilOther;
                    beneficiaryInDB.BeforReturnProvince = model.BeforReturnProvince;
                    beneficiaryInDB.BeforReturnDistrictID = model.BeforReturnDistrictID;
                    beneficiaryInDB.BeforReturnRemarks = model.BeforReturnRemarks;
                    beneficiaryInDB.FamilyMemStayedBehind = model.FamilyMemStayedBehind;
                    beneficiaryInDB.FamilyMemStayedBehindNo = model.FamilyMemStayedBehindNo;
                    beneficiaryInDB.LengthOfStayYears = model.LengthOfStayYears;
                    beneficiaryInDB.LengthOfStayMonths = model.LengthOfStayMonths;
                    beneficiaryInDB.LengthOfStayDays = model.LengthOfStayDays;
                    beneficiaryInDB.WouldYouReturn = model.WouldYouReturn;
                    beneficiaryInDB.HaveFamilyBenefited = model.HaveFamilyBenefited;
                    beneficiaryInDB.TransportationDate = model.TransportationDate;
                    beneficiaryInDB.TransportationInfo = model.TransportationInfo;
                    beneficiaryInDB.TransportAccompaniedBy = model.TransportAccompaniedBy;
                    beneficiaryInDB.TransportAccomByNo = model.TransportAccomByNo;
                    beneficiaryInDB.TopNeed1 = model.TopNeed1;
                    beneficiaryInDB.TopNeed1Other = model.TopNeed1Other;
                    beneficiaryInDB.TopNeed2 = model.TopNeed2;
                    beneficiaryInDB.TopNeed2Other = model.TopNeed2Other;
                    beneficiaryInDB.TopNeed3 = model.TopNeed3;
                    beneficiaryInDB.TopNeed3Other = model.TopNeed3Other;
                    beneficiaryInDB.IntendToDo = model.IntendToDo;
                    beneficiaryInDB.IntendToReturnToHostReason = model.IntendToReturnToHostReason;
                    beneficiaryInDB.ProfessionInHostCountry = model.ProfessionInHostCountry;
                    beneficiaryInDB.ProfessionInHostCountryOther = model.ProfessionInHostCountryOther;
                    beneficiaryInDB.HoHCanReadWrite = model.HoHCanReadWrite;
                    beneficiaryInDB.HoHEducationLevel = model.HoHEducationLevel;
                    beneficiaryInDB.HoHEducationLevelOther = model.HoHEducationLevelOther;
                    beneficiaryInDB.NumHHHaveTaskira = model.NumHHHaveTaskira;
                    beneficiaryInDB.NumHHHavePassport = model.NumHHHavePassport;
                    beneficiaryInDB.NumHHHaveDocOther = model.NumHHHaveDocOther;
                    beneficiaryInDB.DoHaveSecureLivelihood = model.DoHaveSecureLivelihood;
                    beneficiaryInDB.DidChildrenGoToSchoole = model.DidChildrenGoToSchoole;
                    beneficiaryInDB.Photo = model.Photo;
                    beneficiaryInDB.NumChildrenAttendedSchoole = model.NumChildrenAttendedSchoole;
                    beneficiaryInDB.LastUpdatedBy = UserInfo.UserName;
                    beneficiaryInDB.LastUpdatedDate = DateTime.Now;
                    beneficiaryInDB.IsSubmitted = model.IsSubmitted;
                    beneficiaryInDB.IsCardIssued = model.IsCardIssued;
                    db.SaveChanges();
                    #endregion

                    #region Update individuals
                    db.Individuals.RemoveRange(db.Individuals.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var ind in model.Individuals)
                    {
                        var member = new Individual
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            Name = ind.Name,
                            DrName = ind.DrName,
                            FName = ind.FName,
                            DrFName = ind.DrFName,
                            GenderCode = ind.GenderCode,
                            MaritalStatusCode = ind.MaritalStatusCode,
                            Age = ind.Age,
                            IDTypeCode = ind.IDTypeCode,
                            IDNo = ind.IDNo,
                            RelationshipCode = ind.RelationshipCode,
                            ContactNumber = ind.ContactNumber,
                        };
                        db.Individuals.Add(member);
                    }

                    #endregion

                    #region update PSN
                    db.PSNs.RemoveRange(db.PSNs.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var psn in model.PSNs)
                    {
                        var psnObj = new PSN
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            PSNCode = psn.PSNCode,
                            PSNOther = psn.PSNOther
                        };
                        db.PSNs.Add(psnObj);
                    }
                    #endregion

                    #region Upate Return Reason
                    db.ReturnReasons.RemoveRange(db.ReturnReasons.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var rReason in model.ReturnReasons)
                    {
                        var rrObj = new ReturnReason
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            ReasonCode = rReason.ReasonCode,
                            Other = rReason.Other
                        };
                        db.ReturnReasons.Add(rrObj);
                    }
                    #endregion

                    #region Update determination
                    db.Determinations.RemoveRange(db.Determinations.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var d in model.Determinations)
                    {
                        var dObj = new Determination
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            DeterminationCode = d.DeterminationCode,
                            AnswerCode = d.AnswerCode,
                            Other = d.Other
                        };
                        db.Determinations.Add(dObj);
                    }
                    #endregion

                    #region Update Money Sources
                    db.MoneySources.RemoveRange(db.MoneySources.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var m in model.MoneySources)
                    {
                        var moneySObj = new MoneySource
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            MoneySourceCode = m.MoneySourceCode,
                            MoneySourceOther = m.MoneySourceOther
                        };
                        db.MoneySources.Add(moneySObj);
                    }
                    #endregion

                    #region Update Brought Items
                    db.BroughtItems.RemoveRange(db.BroughtItems.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var bi in model.BroughtItems)
                    {
                        var biObj = new BroughtItem
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            ItemCode = bi.ItemCode,
                            ItemOther = bi.ItemOther
                        };
                        db.BroughtItems.Add(biObj);
                    }
                    #endregion

                    #region Update post arrival needs
                    db.PostArrivalNeeds.RemoveRange(db.PostArrivalNeeds.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var p in model.PostArrivalNeeds)
                    {
                        var panObj = new PostArrivalNeed
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            NeedCode = p.NeedCode,
                            Provided = p.Provided,
                            ProvidedDate = p.ProvidedDate,
                            Comment = p.Comment
                        };
                        db.PostArrivalNeeds.Add(panObj);
                    }
                    #endregion

                    #region Update Assistance reveived from org
                    db.BenefitedFromOrgs.RemoveRange(db.BenefitedFromOrgs.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    if (model.HaveFamilyBenefited == true)
                    {
                        foreach (var a in model.BenefitedFromOrgs)
                        {
                            var assisOrgInfo = new BenefitedFromOrg
                            {
                                BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                                Date = a.Date,
                                ProvinceCode = a.ProvinceCode,
                                DistrictID = a.DistrictID,
                                Village = a.Village,
                                OrgCode = a.OrgCode,
                                AssistanceProvided = a.AssistanceProvided
                            };
                            db.BenefitedFromOrgs.Add(assisOrgInfo);
                        }
                    }
                    #endregion

                    #region Update transportation
                    db.Transportations.RemoveRange(db.Transportations.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var tran in model.Transportations)
                    {
                        var tranObj = new Transportation
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            TypedCode = tran.TypedCode,
                            Other = tran.Other
                        };
                        db.Transportations.Add(tranObj);
                    }
                    #endregion

                    #region Update Need for livelihood and emplyment
                    db.LivelihoodEmpNeeds.RemoveRange(db.LivelihoodEmpNeeds.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var li in model.LivelihoodEmpNeeds)
                    {
                        var liObj = new LivelihoodEmpNeed
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            NeedCode = li.NeedCode
                        };
                        db.LivelihoodEmpNeeds.Add(liObj);
                    }
                    #endregion

                    #region Update Need Tools
                    db.NeedTools.RemoveRange(db.NeedTools.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var needTool in model.NeedTools)
                    {
                        var needToolObj = new NeedTool
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            ToolCode = needTool.ToolCode,
                            Other = needTool.Other
                        };
                        db.NeedTools.Add(needToolObj);
                    }
                    #endregion

                    #region Update 3 main concerns
                    db.MainConcerns.RemoveRange(db.MainConcerns.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var mConcern in model.MainConcerns)
                    {
                        var mcObj = new MainConcern
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            ConcernCode = mConcern.ConcernCode,
                            Other = mConcern.Other
                        };
                        db.MainConcerns.Add(mcObj);
                    }
                    #endregion

                    #region Update host country schools
                    db.HostCountrySchools.RemoveRange(db.HostCountrySchools.Where(b => b.BeneficiaryID == beneficiaryInDB.BeneficiaryID));
                    db.SaveChanges();
                    foreach (var hc in model.HostCountrySchools)
                    {
                        var hcObj = new HostCountrySchool
                        {
                            BeneficiaryID = beneficiaryInDB.BeneficiaryID,
                            SchoolTypeCode = hc.SchoolTypeCode
                        };
                        db.HostCountrySchools.Add(hcObj);
                    }
                    #endregion

                    db.SaveChanges();

                    trans.Commit();
                    return 1;
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    return 0;
                }
            }
        }

        public static string GetCardID()
        {
            string id;
            using (dbContext db = new dbContext())
            {
                var setting = db.UserSettings.FirstOrDefault();              
                    var NewNo = setting.RecentReturnNumber+ 1;
                   id= string.Format("{0}-{1}-{2}", setting.BCP,setting.Alphabet, NewNo.ToString("D6"));           
            }
            return id;           
        }

        public static bool Delete(int BeneficiaryID)
        {
            dbContext db = new dbContext();
     
           using (var trans = db.Database.BeginTransaction())
          {
        
                    try
                    {
                   // var ben = db.Beneficiaries.Find(BeneficiaryID);

                    //   db.Beneficiaries.Remove(ben);
                   // db.SaveChanges();
                    db.Individuals.RemoveRange(db.Individuals.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                    db.PSNs.RemoveRange(db.PSNs.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                    db.ReturnReasons.RemoveRange(db.ReturnReasons.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                    db.Determinations.RemoveRange(db.Determinations.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                        db.MoneySources.RemoveRange(db.MoneySources.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                    db.BroughtItems.RemoveRange(db.BroughtItems.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                    db.PostArrivalNeeds.RemoveRange(db.PostArrivalNeeds.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                    db.BenefitedFromOrgs.RemoveRange(db.BenefitedFromOrgs.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                    db.Transportations.RemoveRange(db.Transportations.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                    db.LivelihoodEmpNeeds.RemoveRange(db.LivelihoodEmpNeeds.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                    db.NeedTools.RemoveRange(db.NeedTools.Where(b => b.BeneficiaryID == BeneficiaryID));
                    db.SaveChanges();
                        db.MainConcerns.RemoveRange(db.MainConcerns.Where(b => b.BeneficiaryID == BeneficiaryID));
                        db.SaveChanges();
                    db.HostCountrySchools.RemoveRange(db.HostCountrySchools.Where(b => b.BeneficiaryID == BeneficiaryID));
                        db.SaveChanges();
                    trans.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                       trans.Rollback();
                        return false;
                    }
             
            }
        }

    }
}
