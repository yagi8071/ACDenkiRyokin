using System.ComponentModel.DataAnnotations;

namespace ACDenkiRyokin.Models
{
    public class AuthModel
    {
        [Display(Name = "ログインID")]
        [Required(ErrorMessage = "ユーザーIDは必須入力です。")]
        public string Id { get; set; }

        [Display(Name = "パスワード")]
        [Required(ErrorMessage = "パスワードは必須入力です。")]
        public string Password { get; set; }
    }
}