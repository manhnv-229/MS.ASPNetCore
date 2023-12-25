using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Library.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        /// 
        [JsonProperty("Name")]
        [MaxLength(20, ErrorMessage = "MÃ khách hàng không được hơn 2 ký tự.")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        /// 
        [Required(ErrorMessage = "Họ và tên trống rồi")]
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
