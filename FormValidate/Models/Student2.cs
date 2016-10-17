using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FormValidate.Models
{
    public class Student2
    {
        [Required(ErrorMessage ="姓名不能为空")]
        public string name { get; set; }

        [Required(ErrorMessage ="邮箱不能为空")]
        [EmailAddress(ErrorMessage ="邮箱格式不正确")]
        public string email { get; set; }
    }
}