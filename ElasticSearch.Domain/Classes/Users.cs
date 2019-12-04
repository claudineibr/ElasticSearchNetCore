using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElasticSearch.Domain.Classes
{
    public partial class Users
    {
        public Users()
        {
            Applications = new HashSet<Applications>();
            AttributeCategories = new HashSet<AttributeCategories>();
            AttributeDescriptions = new HashSet<AttributeDescriptions>();
            Attributes = new HashSet<Attributes>();
            AuthProviders = new HashSet<AuthProviders>();
            BrokerActiveRealtiesUpdatedByUser = new HashSet<BrokerActiveRealties>();
            BrokerActiveRealtiesUser = new HashSet<BrokerActiveRealties>();
            BrokerPastSalesUpdatedByUser = new HashSet<BrokerPastSales>();
            BrokerPastSalesUser = new HashSet<BrokerPastSales>();
            BrokersUpdatedByUser = new HashSet<Brokers>();
            Categories = new HashSet<Categories>();
            CategoryTypes = new HashSet<CategoryTypes>();
            Companies = new HashSet<Companies>();
            CompanyAddresses = new HashSet<CompanyAddresses>();
            CompanyCompanyGroups = new HashSet<CompanyCompanyGroups>();
            CompanyGroups = new HashSet<CompanyGroups>();
            ConstructionStages = new HashSet<ConstructionStages>();
            ContactChannels = new HashSet<ContactChannels>();
            ContactTypes = new HashSet<ContactTypes>();
            DesignFunding = new HashSet<DesignFunding>();
            DesignUnitCategoryTypes = new HashSet<DesignUnitCategoryTypes>();
            DesignUnitMultimedia = new HashSet<DesignUnitMultimedia>();
            DesignUnits = new HashSet<DesignUnits>();
            DivisionMultimedia = new HashSet<DivisionMultimedia>();
            GeographicalZoneLocalities = new HashSet<GeographicalZoneLocalities>();
            GeographicalZones = new HashSet<GeographicalZones>();
            Leads = new HashSet<Leads>();
            LeadTypes = new HashSet<LeadTypes>();
            Localities = new HashSet<Localities>();
            LocalityInfos = new HashSet<LocalityInfos>();
            MarketingTypes = new HashSet<MarketingTypes>();
            MultimediaSubTypes = new HashSet<MultimediaSubTypes>();
            MultimediaTypes = new HashSet<MultimediaTypes>();
            NeighborhoodInfoes = new HashSet<NeighborhoodInfoes>();
            Neighborhoods = new HashSet<Neighborhoods>();
            PublishStatus = new HashSet<PublishStatus>();
            Realties = new HashSet<Realties>();
            RealtyAddresses = new HashSet<RealtyAddresses>();
            RealtyAttributes = new HashSet<RealtyAttributes>();
            RealtyCompanies = new HashSet<RealtyCompanies>();
            RealtyContacts = new HashSet<RealtyContacts>();
            RealtyDivisions = new HashSet<RealtyDivisions>();
            RealtyMultimedia = new HashSet<RealtyMultimedia>();
            RealtyStakeholders = new HashSet<RealtyStakeholders>();
            RealtyStandouts = new HashSet<RealtyStandouts>();
            SaleStages = new HashSet<SaleStages>();
            SchoolCategories = new HashSet<SchoolCategories>();
            SchoolCategoryTypes = new HashSet<SchoolCategoryTypes>();
            SchoolTypes = new HashSet<SchoolTypes>();
            SourceSites = new HashSet<SourceSites>();
            Stakeholders = new HashSet<Stakeholders>();
            StakeholderTypes = new HashSet<StakeholderTypes>();
            States = new HashSet<States>();
            SubsidiaryTypes = new HashSet<SubsidiaryTypes>();
            UserAddressesUpdatedByUser = new HashSet<UserAddresses>();
            UserApplicationsUpdatedByUser = new HashSet<UserApplications>();
            UserApplicationsUser = new HashSet<UserApplications>();
            UserAttachmentsUpdatedByUser = new HashSet<UserAttachments>();
            UserAttachmentsUser = new HashSet<UserAttachments>();
            UserDocumentsUpdatedByUser = new HashSet<UserDocuments>();
            UserDocumentsUser = new HashSet<UserDocuments>();
            UserDocumentTypes = new HashSet<UserDocumentTypes>();
            UserEntityTypes = new HashSet<UserEntityTypes>();
            UserMaritalStatus = new HashSet<UserMaritalStatus>();
            UserPrenupcialAgreements = new HashSet<UserPrenupcialAgreements>();
            UserProfessions = new HashSet<UserProfessions>();
            UserSituations = new HashSet<UserSituations>();
            UserTitles = new HashSet<UserTitles>();
            ValueZones = new HashSet<ValueZones>();
            ZipCodeAddresses = new HashSet<ZipCodeAddresses>();
            BrokerReviewsApprovalUser = new HashSet<BrokerReviews>();
            BrokerReviewsBroker = new HashSet<BrokerReviews>();
            BrokerReviewsUpdatedByUser = new HashSet<BrokerReviews>();
            BrokerReviewsUser = new HashSet<BrokerReviews>();
            BrokerStandouts = new HashSet<BrokerStandouts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }

        [NotMapped]
        public bool IsMobilePhone {
            get
            {

                if (!String.IsNullOrEmpty(this.Telephone))
                {
                    if(this.Telephone.Length >= 9)
                    {
                        if (this.Telephone[2] == '9' || this.Telephone[2] == '8' || this.Telephone[2] == '7' || this.Telephone[2] == '6')
                            return true;
                    }
                }
                return false;

            }
         }

        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Origin { get; set; }
        public string Cpf { get; set; }
        public int? UserSituationId { get; set; }
        public int? UserMaritalStatusId { get; set; }
        public int? NationalityId { get; set; }
        public int? UserEntityTypeId { get; set; }
        public int? UserTitleId { get; set; }
        public int? UserProfessionId { get; set; }
        public int? UserPrenupcialAgreementId { get; set; }
        public int? LocalityId { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime? WeddingDate { get; set; }
        public string CompanyName { get; set; }
        public decimal? FamilyIncome { get; set; }
        public DateTime? LastContactDate { get; set; }
        public DateTime? LastContactCampaignDate { get; set; }
        public string ReceiveEmailFlag { get; set; }
        public string ReceiveCallFlag { get; set; }
        public string ReceiveDirectMailFlag { get; set; }
        public string ReceivePartnerActionsFlag { get; set; }
        public string ReceiveSmsFlag { get; set; }
        public string Token { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public int UpdatedByUserId { get; set; }
        public int? Permissions { get; set; }
        public string ProviderUserId { get; set; }
        public int? AuthProviderId { get; set; }
        public string Reference { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeDescription { get; set; }

        [NotMapped]
        public string UnCryptographyPassword { get; set; }

        [NotMapped]
        public string MiniCurriculo { get; set; }

        [JsonIgnore]
        public virtual ICollection<Applications> Applications { get; set; }
        [JsonIgnore]
        public virtual ICollection<AttributeCategories> AttributeCategories { get; set; }
        [JsonIgnore]
        public virtual ICollection<AttributeDescriptions> AttributeDescriptions { get; set; }
        [JsonIgnore]
        public virtual ICollection<Attributes> Attributes { get; set; }
        [JsonIgnore]
        public virtual ICollection<AuthProviders> AuthProviders { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrokerActiveRealties> BrokerActiveRealtiesUpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrokerActiveRealties> BrokerActiveRealtiesUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrokerPastSales> BrokerPastSalesUpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrokerPastSales> BrokerPastSalesUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrokerReviews> BrokerReviewsApprovalUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrokerReviews> BrokerReviewsBroker { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrokerReviews> BrokerReviewsUpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrokerReviews> BrokerReviewsUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrokerStandouts> BrokerStandouts { get; set; }

        [JsonIgnore]
        public virtual ICollection<Brokers> BrokersUpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual Brokers BrokersUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<Categories> Categories { get; set; }
        [JsonIgnore]
        public virtual ICollection<CategoryTypes> CategoryTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Companies> Companies { get; set; }
        [JsonIgnore]
        public virtual ICollection<CompanyAddresses> CompanyAddresses { get; set; }
        [JsonIgnore]
        public virtual ICollection<CompanyCompanyGroups> CompanyCompanyGroups { get; set; }
        [JsonIgnore]
        public virtual ICollection<CompanyGroups> CompanyGroups { get; set; }
        [JsonIgnore]
        public virtual ICollection<ConstructionStages> ConstructionStages { get; set; }
        [JsonIgnore]
        public virtual ICollection<ContactChannels> ContactChannels { get; set; }
        [JsonIgnore]
        public virtual ICollection<ContactTypes> ContactTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<DesignFunding> DesignFunding { get; set; }
        [JsonIgnore]
        public virtual ICollection<DesignUnitCategoryTypes> DesignUnitCategoryTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<DesignUnitMultimedia> DesignUnitMultimedia { get; set; }
        [JsonIgnore]
        public virtual ICollection<DesignUnits> DesignUnits { get; set; }
        [JsonIgnore]
        public virtual ICollection<DivisionMultimedia> DivisionMultimedia { get; set; }
        [JsonIgnore]
        public virtual ICollection<GeographicalZoneLocalities> GeographicalZoneLocalities { get; set; }
        [JsonIgnore]
        public virtual ICollection<GeographicalZones> GeographicalZones { get; set; }
        [JsonIgnore]
        public virtual ICollection<Leads> Leads { get; set; }
        [JsonIgnore]

        public virtual ICollection<LeadsGauge> LeadsGauge { get; set; }
        [JsonIgnore]
        public virtual ICollection<LeadTypes> LeadTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Localities> Localities { get; set; }
        [JsonIgnore]
        public virtual ICollection<LocalityInfos> LocalityInfos { get; set; }
        [JsonIgnore]
        public virtual ICollection<MarketingTypes> MarketingTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<MultimediaSubTypes> MultimediaSubTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<MultimediaTypes> MultimediaTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<NeighborhoodInfoes> NeighborhoodInfoes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Neighborhoods> Neighborhoods { get; set; }
        [JsonIgnore]
        public virtual ICollection<PublishStatus> PublishStatus { get; set; }
        [JsonIgnore]
        public virtual ICollection<Realties> Realties { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyAddresses> RealtyAddresses { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyAttributes> RealtyAttributes { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyCompanies> RealtyCompanies { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyContacts> RealtyContacts { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyDivisions> RealtyDivisions { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyMultimedia> RealtyMultimedia { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyStakeholders> RealtyStakeholders { get; set; }
        [JsonIgnore]
        public virtual ICollection<RealtyStandouts> RealtyStandouts { get; set; }
        [JsonIgnore]
        public virtual ICollection<SaleStages> SaleStages { get; set; }
        [JsonIgnore]
        public virtual ICollection<SchoolCategories> SchoolCategories { get; set; }
        [JsonIgnore]
        public virtual ICollection<SchoolCategoryTypes> SchoolCategoryTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<SchoolTypes> SchoolTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<SourceSites> SourceSites { get; set; }
        [JsonIgnore]
        public virtual ICollection<Stakeholders> Stakeholders { get; set; }
        [JsonIgnore]
        public virtual ICollection<StakeholderTypes> StakeholderTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<States> States { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubsidiaryTypes> SubsidiaryTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserAddresses> UserAddressesUpdatedByUser { get; set; }
        public virtual UserAddresses UserAddressesUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserApplications> UserApplicationsUpdatedByUser { get; set; }
        public virtual ICollection<UserApplications> UserApplicationsUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserAttachments> UserAttachmentsUpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserAttachments> UserAttachmentsUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserDocuments> UserDocumentsUpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserDocuments> UserDocumentsUser { get; set; }
        public virtual ICollection<UserDocumentTypes> UserDocumentTypes { get; set; }
        public virtual ICollection<UserEntityTypes> UserEntityTypes { get; set; }
        public virtual ICollection<UserMaritalStatus> UserMaritalStatus { get; set; }
        public virtual ICollection<UserPrenupcialAgreements> UserPrenupcialAgreements { get; set; }
        public virtual ICollection<UserProfessions> UserProfessions { get; set; }
        public virtual ICollection<UserSituations> UserSituations { get; set; }
        public virtual ICollection<UserTitles> UserTitles { get; set; }
        [JsonIgnore]
        public virtual ICollection<ValueZones> ValueZones { get; set; }
        [JsonIgnore]
        public virtual ICollection<ZipCodeAddresses> ZipCodeAddresses { get; set; }
        public virtual AuthProviders AuthProvider { get; set; }
        [JsonIgnore]
        public virtual Users UpdatedByUser { get; set; }
        [JsonIgnore]
        public virtual ICollection<Users> InverseUpdatedByUser { get; set; }
        public virtual UserEntityTypes UserEntityType { get; set; }
        public virtual UserMaritalStatus UserMaritalStatusNavigation { get; set; }
        public virtual UserPrenupcialAgreements UserPrenupcialAgreement { get; set; }
        public virtual UserProfessions UserProfession { get; set; }
        public virtual UserSituations UserSituation { get; set; }
        public virtual UserTitles UserTitle { get; set; }
        public virtual UserTypes UserType { get; set; }
    }
}
