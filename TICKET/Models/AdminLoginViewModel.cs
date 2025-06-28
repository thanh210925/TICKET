using System.ComponentModel.DataAnnotations;

namespace TICKET.Models
{
    public class AdminLoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn quyền")]
        public string Role { get; set; } // SuperAdmin hoặc Manager
    }
}
