using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CIL.Models
{
    public class User : IdentityUser<Guid>
    {
        //By default: Id, Email, PasswordHash, PhoneNumber, UserName
        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }
        public string UserLevel { get; set; }

        public string UserRole { get; set; }

        [IgnoreDataMember]
        public ICollection<ParentChild> UserParents { get; set; }

        [IgnoreDataMember]
        public ICollection<ParentChild> UserChilds { get; set; }

        [IgnoreDataMember]
        public ICollection<DailyTestResult> DailyTestResults { get; set; }

        [IgnoreDataMember]
        public ICollection<Answer> Answers { get; set; }

        [IgnoreDataMember]
        public ICollection<ObservationResult> ObservationResults { get; set; }

        [IgnoreDataMember]
        public ICollection<Dairy> Dairies { get; set; }

        [IgnoreDataMember]
        public ICollection<GameResult> GameResults { get; set; }
    }
}
