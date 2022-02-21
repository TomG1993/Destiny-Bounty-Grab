using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny_Bounty_Grab
{
    class GroupQuery
    {
        public string name { get; set; }
        public int groupType { get; set; }

        public string? creationDate { get; set; }

        public int? sortBy { get; set; }

        public int? groupMemberCountFilter { get; set; }

        public string? localeFilter { get; set; }

        public string? tagText { get; set; }

        public int? itemsPerPage { get; set; }

        public int? currentPage { get; set; }

        public string? requestContinuationToken { get; set; }
    }

    class groupQueryResult
    {
        public string results { get; set; }
    }

    class Group
    {
        public int groupId { get; set; }

    }


    public class ClanBannerData
    {
        public long decalId { get; set; }
        public long decalColorId { get; set; }
        public long decalBackgroundColorId { get; set; }
        public int gonfalonId { get; set; }
        public long gonfalonColorId { get; set; }
        public int gonfalonDetailId { get; set; }
        public long gonfalonDetailColorId { get; set; }
    }

    public class ClanInfo
    {
        public string clanCallsign { get; set; }
        public ClanBannerData clanBannerData { get; set; }
    }

    public class Result
    {
        public string groupId { get; set; }
        public string name { get; set; }
        public int groupType { get; set; }
        public DateTime creationDate { get; set; }
        public string about { get; set; }
        public string motto { get; set; }
        public int memberCount { get; set; }
        public string locale { get; set; }
        public int membershipOption { get; set; }
        public int capabilities { get; set; }
        public ClanInfo clanInfo { get; set; }
        public string avatarPath { get; set; }
        public string theme { get; set; }
    }

    public class Query
    {
        public string name { get; set; }
        public int groupType { get; set; }
        public int creationDate { get; set; }
        public int sortBy { get; set; }
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }
    }

    public class Response
    {
        public List<Result> results { get; set; }
        public int totalResults { get; set; }
        public bool hasMore { get; set; }
        public Query query { get; set; }
        public bool useTotalResults { get; set; }
    }

    public class MessageData
    {
    }

    public class Root
    {
        public Response Response { get; set; }
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public MessageData MessageData { get; set; }
    }
}

