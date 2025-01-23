namespace Gatocan.Model;

    public class User
    {
        public int Id { get; set; }          
        public string Name { get; set; }    
        public string Lastname { get; set; } 
        public string Email { get; set; }   
        public string Password { get; set; } 
        public double Balance { get; set; } 
        public string Role { get; set; }    
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




