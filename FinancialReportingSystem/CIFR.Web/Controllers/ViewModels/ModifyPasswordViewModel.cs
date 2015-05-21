using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIFR.Web.Controllers.ViewModels
{
    public class ModifyPasswordViewModel
    {
        public ModifyPasswordViewModel() { }

        public string ManagerAccount { set; get; }

        [MaxLength(20, ErrorMessage = "密码长度不能超过20")]
        [Required(ErrorMessage = "原始密码不能为空")]
        public string OriginalPassword { set; get; }

        [Required(ErrorMessage = "新的密码不能为空")]
        [MaxLength(20, ErrorMessage = "密码长度不能超过20")]
        [MinLength(6, ErrorMessage = "密码长度不能低于6")]
        public string NewPassword { set; get; }

        [Required(ErrorMessage = "确认密码不能为空")]
        [MaxLength(20, ErrorMessage = "密码长度不能超过20")]
        [MinLength(6, ErrorMessage = "密码长度不能低于6")]
        public string SecondPassword { set; get; }
    }
}
