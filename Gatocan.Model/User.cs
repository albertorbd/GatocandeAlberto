using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Gatocan.Model;



    public class User
    {
        [Key]
        public int Id { get; set; }
         [Required]          
        public string? Name { get; set; }  
        [Required]  
        public string Lastname { get; set; } 
         [Required]
        public string Email { get; set; } 
         [Required]  
        public string Password { get; set; } 
        public double Balance { get; set; } 
        [Required]
        public string Role { get; set; } = Roles.User;
        
        
        [Phone]
        public string? Phone { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }
         [JsonIgnore] 
        public List<Transaction> Transactions { get; set; }
        
    
    public User() {}

    public User(string name, string lastname, string email, string password){

    Name=name;
    Lastname=lastname;
    Email=email;
    Password=password;
    Balance=0.0;
    Transactions= new List<Transaction>();


    }
}




