using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Models.Base
{
    [DataContract]
    public class BaseEntity    
    {
        [Key]       

        public long? Id { get; set; }
    }
}
