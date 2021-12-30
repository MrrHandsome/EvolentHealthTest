﻿namespace EvolentHealthTest.Entities
{
    public class Contact
    {
        #region Public Property

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }

        #endregion  
    }
}
