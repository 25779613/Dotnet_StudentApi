using System.ComponentModel.DataAnnotations;

namespace StudentApi.Modals.DTO.Request
{
    public class UserLoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email{get;set;}
        [Required]
        public string Password{get;set;}

    }
}