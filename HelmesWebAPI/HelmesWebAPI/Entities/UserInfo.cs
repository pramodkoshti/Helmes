using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace HelmesWebAPI.Entities
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string SectorsIds { get; set; }
        public bool IsAgreeToTerms { get; set; }
        public Guid SessionId { get; set; }
    }
}
